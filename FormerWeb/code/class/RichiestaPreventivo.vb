Imports FormerBusinessLogicInterface
Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class RichiestaPreventivo

    Public Sub New()

        Dim x As Guid = Guid.NewGuid
        GuidRichiesta = x.ToString

    End Sub

    Private _LPart As ListinoBaseW = Nothing
    Public ReadOnly Property LPart As ListinoBaseW
        Get
            If _LPart Is Nothing Then
                _LPart = New ListinoBaseW
                _LPart.Read(IdListinoBasePartenza)
            End If
            Return _LPart
        End Get
    End Property

    Private _Lrif As ListinoBaseW = Nothing
    Public ReadOnly Property LRif As ListinoBaseW
        Get
            If _Lrif Is Nothing Then
                _Lrif = New ListinoBaseW
                _Lrif.Read(IdListinoBaseRif)
                _Lrif.CaricaLavorazioniBase()
                _Lrif.CaricaLavorazioniOpz()
            End If
            Return _Lrif
        End Get
    End Property

    Private _Cliente As Utente = Nothing
    Public ReadOnly Property Cliente As Utente
        Get
            If _Cliente Is Nothing Then
                _Cliente = New Utente
                _Cliente.Read(IdCliente)
            End If
            Return _Cliente
        End Get
    End Property

    Public ReadOnly Property QuandoStr As String
        Get
            Return Quando.ToString("dddd dd/MM/yyyy HH:mm.ss")
        End Get
    End Property

    Public Property GuidRichiesta As String = String.Empty

    Public Property Quando As Date = Date.MinValue
    Public Property IdCliente As Integer = 0
    Public Property IdListinoBasePartenza As Integer = 0
    Public Property IdListinoBaseRif As Integer = 0

    Public Property RagioneSocialeNome As String = String.Empty
    Public Property Email As String = String.Empty

    Public ReadOnly Property RepartoStr As String
        Get
            Return FormerEnumHelper.RepartoStr(Reparto)
        End Get
    End Property

    Public ReadOnly Property OrientamentoStr As String
        Get
            Return FormerEnumHelper.OrientamentoStr(Orientamento)
        End Get
    End Property

    Public Property NessunFormatoAdattabile As Boolean = False

    Public Property Reparto As Integer = 0
    Public Property NomeLavoro As String = String.Empty
    Public Property Qta As String = String.Empty
    Public Property Larghezza As String = String.Empty
    Public Property Lunghezza As String = String.Empty
    Public Property Orientamento As Integer = 0
    Public Property Finitura As String = String.Empty
    Public Property TipoCarta As String = String.Empty
    Public Property ColoreStampa As Integer = 0

    Public Property MultiPagina As Boolean = False
    Public Property NumeroFacciate As Integer = 0
    Public Property Autocopertinato As Boolean = False

    Public ReadOnly Property RepartoBkgColor As String
        Get
            Return FormerLib.FormerColori.GetColoreToHtml(FormerLib.FormerColori.GetColoreReparto(Reparto))
        End Get
    End Property

    Private _TipoCartaRif As TipoCartaW = Nothing
    Public ReadOnly Property TipoCartaRif As TipoCartaW
        Get
            If _TipoCartaRif Is Nothing Then

                Using Mgr As New TipiCartaWDAO
                    _TipoCartaRif = Mgr.Find(New LUNA.LunaSearchParameter(LFM.TipoCartaW.Tipologia, TipoCarta))
                End Using
            End If
            Return _TipoCartaRif
        End Get
    End Property

    Private _CS As ColoreStampaW = Nothing
    Public ReadOnly Property CS As ColoreStampaW
        Get
            If _CS Is Nothing Then
                _CS = New ColoreStampaW
                _CS.Read(ColoreStampa)
            End If
            Return _CS
        End Get
    End Property

    Public Property DataIndicativaConsegna As Date = Date.MinValue

    Public Property ElencoIdOpzioniBase As List(Of Integer) = Nothing
    Public Property ElencoIdOpzioniSel As List(Of Integer) = Nothing
    Public Property Annotazioni As String = String.Empty

    Private _ElencoOpzioniBase As List(Of LavorazioneW) = Nothing
    Public ReadOnly Property ElencoOpzioniBase As List(Of LavorazioneW)
        Get
            If _ElencoOpzioniBase Is Nothing Then
                _ElencoOpzioniBase = New List(Of LavorazioneW)

                For Each Id As Integer In ElencoIdOpzioniBase
                    Dim L As New LavorazioneW
                    L.Read(Id)
                    _ElencoOpzioniBase.Add(L)
                Next
            End If
            Return _ElencoOpzioniBase

        End Get
    End Property

    Private _ElencoOpzioniSel As List(Of LavorazioneW) = Nothing
    Public ReadOnly Property ElencoOpzioniSel As List(Of LavorazioneW)
        Get
            If _ElencoOpzioniSel Is Nothing Then
                _ElencoOpzioniSel = New List(Of LavorazioneW)

                For Each Id As Integer In ElencoIdOpzioniSel
                    Dim L As New LavorazioneW
                    L.Read(Id)
                    _ElencoOpzioniSel.Add(L)
                Next
            End If
            Return _ElencoOpzioniSel

        End Get
    End Property

    Public ReadOnly Property FormatoProdottoUtilizzabile As FormatoProdottoW
        Get
            Dim ris As FormatoProdottoW = Nothing

            ris = LRif.FormatoProdotto

            Return ris
        End Get
    End Property

    Public ReadOnly Property BufferPreventivo As String
        Get
            Dim ris As String = String.Empty

            'faccio tutti i check possibili e capisco se posso calcolare il preventivo 
            Dim PreventivoCalcolabile As Boolean = True
            Dim PreventivoCalcolabileMsg As String = String.Empty

            If IsNumeric(Qta) = False Then
                PreventivoCalcolabile = False
                PreventivoCalcolabileMsg &= "<li>La quantità non è espressa in un formato numerico comprensibile</li>"
            End If

            If TipoCartaRif Is Nothing Then
                PreventivoCalcolabile = False
                PreventivoCalcolabileMsg &= "<li>Non ho riconosciuto il tipo di carta specificato</li>"
            End If

            If TipoCartaRif.IdTipoCarta <> LRif.IdTipoCarta Then
                PreventivoCalcolabile = False
                PreventivoCalcolabileMsg &= "<li>Il tipo di carta specificato è diverso da quello previsto nel listinobase</li>"
            End If

            If CS.IdColoreStampa <> LRif.IdColoreStampa Then
                PreventivoCalcolabile = False
                PreventivoCalcolabileMsg &= "<li>Il colore di stampa specificato è diverso da quello previsto nel listinobase</li>"
            End If

            For Each lav In ElencoOpzioniBase
                If lav.Prezzi.FindAll(Function(x) x.IdFormProd = FormatoProdottoUtilizzabile.IdFormProd Or x.IdFormProd = 0).Count = 0 Then
                    PreventivoCalcolabile = False
                    PreventivoCalcolabileMsg &= "<li>La lavorazione scelta '" & lav.Descrizione & "' non ha un prezzo specifico per il formato prodotto del listino, ne un prezzo generico</li>"
                End If
            Next

            For Each lav In ElencoOpzioniSel
                If lav.Prezzi.FindAll(Function(x) x.IdFormProd = FormatoProdottoUtilizzabile.IdFormProd Or x.IdFormProd = 0).Count = 0 Then
                    PreventivoCalcolabile = False
                    PreventivoCalcolabileMsg &= "<li>La lavorazione scelta '" & lav.Descrizione & "' non ha un prezzo specifico per il formato prodotto del listino, ne un prezzo generico</li>"
                End If
            Next

            If NessunFormatoAdattabile Then
                PreventivoCalcolabile = False
                PreventivoCalcolabileMsg &= "<li>Non esiste nessun formato prodotto, che utilizza il tipo di carta specificata, adattabile alle dimensioni indicate</li>"
            End If

            For Each lav In LRif.LavorazioniBase.FindAll(Function(x) x.Accorpabile = enSiNo.Si)
                If ElencoIdOpzioniBase.FindAll(Function(x) x = lav.IdLavoro).Count = 0 AndAlso
                        ElencoIdOpzioniSel.FindAll(Function(x) x = lav.IdLavoro).Count = 0 Then
                    'qui un opzione base obbligatoria è stata esclusa quindi non si puo calcolare
                    PreventivoCalcolabile = False
                    PreventivoCalcolabileMsg &= "<li>La lavorazione '" & lav.Descrizione & "' prevista come obbligatoria nel listino selezionato, è stata esclusa</li>"
                End If
            Next

            If PreventivoCalcolabile Then

                Dim NumeroPezziScelti As Integer = Qta
                Dim QtaRichiesta As Single = NumeroPezziScelti
                Dim QtaSecondaria As Single = 0
                Dim Altezza As Integer = 1
                Dim Larghezza As Integer = 1

                Dim PrezzoCalcolatoNetto As Decimal = 0
                Dim PrezzoPubblico As Decimal = 0
                Dim PrezzoRiv As Decimal = 0

                Dim R As RisPrezzoIntermedio = CalcolaPrezzi(QtaRichiesta,
                                                           QtaSecondaria,
                                                           NumeroPezziScelti)

                If Cliente.TipoRub = enTipoRubrica.Cliente Then
                    PrezzoCalcolatoNetto = R.PrezzoPubbl
                Else
                    PrezzoCalcolatoNetto = R.PrezzoRiv
                End If

                'qui controllo quali lavori del listinobase riferimento sono stati effettivamente scelti e quali no e li evidenzio e quali aggiunti
                ris &= "<b>Opzioni</b>"
                ris &= "<table>"
                For Each lav In LRif.LavorazioniBase

                    ris &= "<tr><td width=64><img src='https://www.tipografiaformer.it/listino/img/" & lav.ImgRif & "' align=absmiddle style='border-radius:5px; border:1px solid #d6e03d; width:64px;'></td>"
                    ris &= "<td>" & lav.Descrizione & "</td>"

                    Dim Trovata As Boolean = False
                    If ElencoOpzioniBase.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count Then
                        Trovata = True
                    ElseIf ElencoOpzioniSel.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count Then
                        Trovata = True
                    End If

                    If Trovata Then
                        ris &= "<td><b style='color:green;'>OBBLIGATORIA Inserita</b></td>"
                    Else
                        ris &= "<td><b style='color:red;'>OBBLIGATORIA NON Inserita</b></td>"
                    End If

                    ris &= "</tr>"
                Next
                For Each lav In LRif.LavorazioniOpz
                    Dim Trovata As Boolean = False
                    If ElencoOpzioniBase.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count Then
                        Trovata = True
                    ElseIf ElencoOpzioniSel.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count Then
                        Trovata = True
                    End If

                    If Trovata Then
                        ris &= "<tr><td>" & lav.Descrizione & "</td>"
                        ris &= "<td><b style='color:green;'>OPZIONALE Inserita</b></td>"
                    End If
                    ris &= "</tr>"
                Next
                For Each lav In ElencoOpzioniSel
                    Dim Trovata As Boolean = False
                    If LRif.LavorazioniBase.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count Then
                        Trovata = True
                    End If
                    If LRif.LavorazioniBase.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count Then
                        Trovata = True
                    End If
                    If Trovata = False Then
                        ris &= "<tr><td>" & lav.Descrizione & "</td>"
                        ris &= "<td><b style='color:orange;'>NON PREVISTA Aggiunta</b></td></tr>"
                    End If
                Next

                ris &= "</table>"

                ris &= "<b>Prezzo suggerito</b><br><h2>" & FormerHelper.Stringhe.FormattaPrezzo(PrezzoCalcolatoNetto) & "</h2>"

            Else
                ris = "<h3>In base ai dati inseriti il preventivo non è calcolabile automaticamente</h3>"
                ris &= "<b>Problemi riscontrati:</b><br>"
                ris &= PreventivoCalcolabileMsg
            End If

            Return ris
        End Get
    End Property

    Private Function CalcolaPrezzi(QtaI As Single,
                                   QtaSecondaria As Single,
                                   NumeroPezzi As Integer) As RisPrezzoIntermedio
        'Dim QtaRichiesta As Integer = Convert.ToInt32(ddlQta.SelectedValue)
        'LRif.CaricaLavorazioniBase()

        Dim listaBaseB As New List(Of ILavorazioneB)
        Dim listaOpzB As New List(Of ILavorazioneB)
        Dim Lb As IListinoBaseB = LRif

        For Each lav In ElencoOpzioniBase
            listaBaseB.Add(lav)
        Next

        For Each lav In ElencoOpzioniSel
            listaOpzB.Add(lav)
        Next

        Lb.NumFacciate = NumeroFacciate

        'If Not FormatoProdottoUtilizzabile Is Nothing Then

        'End If

        Dim AltezzaI As Integer = 0
        Dim LarghezzaI As Integer = 0

        Dim R As RisPrezzoIntermedio = MgrPreventivazioneB.CalcolaPrezzoFinale(Lb,
                                                                                QtaI,
                                                                                listaBaseB,
                                                                                QtaSecondaria,
                                                                                listaOpzB,
                                                                                False,,
                                                                                AltezzaI,
                                                                                LarghezzaI,
                                                                                NumeroPezzi,
                                                                                True)

        Return R

    End Function

End Class
