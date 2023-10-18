#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.5.18.31939 
'Author: Diego Lunadei
'Date: 14/10/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports System.Drawing

''' <summary>
''' 
'''Entity Class for table Ordini
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class OrdineWeb
    Inherits _OrdineWeb
    Implements IOrdineWeb, IOrdineBox, ICloneable

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"

    Public Sub New()
        MyBase.New()
    End Sub
    Private _L As ListinoBaseW = Nothing
    Public ReadOnly Property L As ListinoBaseW Implements IOrdineBox.ListinoBase
        Get
            If _L Is Nothing Then
                _L = New ListinoBaseW
                _L.Read(IdListinoBase)
            End If
            Return _L
        End Get
    End Property
    Private _P As PreventivazioneW = Nothing
    Public ReadOnly Property P As PreventivazioneW
        Get
            If _P Is Nothing Then
                _P = New PreventivazioneW
                _P.Read(L.IdPrev)
            End If
            Return _P
        End Get
    End Property
    Private _F As FormatoProdottoW = Nothing
    Public ReadOnly Property F As FormatoProdottoW
        Get
            If _F Is Nothing Then
                _F = New FormatoProdottoW
                _F.Read(L.IdFormProd)
            End If
            Return _F
        End Get
    End Property
    Private _TC As TipoCartaW = Nothing
    Public ReadOnly Property TC As TipoCartaW
        Get
            If _TC Is Nothing Then
                _TC = New TipoCartaW
                _TC.Read(L.IdTipoCarta)
            End If
            Return _TC
        End Get
    End Property
    Private _C As ColoreStampaW = Nothing
    Public ReadOnly Property C As ColoreStampaW
        Get
            If _C Is Nothing Then
                _C = New ColoreStampaW
                _C.Read(L.IdColoreStampa)
            End If
            Return _C
        End Get
    End Property
    Private _Corriere As CorriereW = Nothing
    Public ReadOnly Property Corriere As CorriereW
        Get
            If _Corriere Is Nothing Then
                _Corriere = New CorriereW
                _Corriere.Read(IdCorriere)
            End If
            Return _Corriere
        End Get
    End Property

    Public ReadOnly Property PercPromo As Integer Implements IOrdineBox.Promo
        Get
            Return IdPromo
        End Get
    End Property

    Public ReadOnly Property IdProdotto As Integer Implements IOrdineBox.IdProdotto
        Get
            Return L.IdListinoBase
        End Get
    End Property

    Public ReadOnly Property NOrdineStr As String Implements IOrdineBox.NOrdineStr
        Get
            Dim Ris As String = "-"
            If IdOrdineInt Then
                Ris = IdOrdineInt
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property AltezzaI As Integer Implements IOrdineBox.Altezza
        Get
            Return Altezza
        End Get
    End Property
    Public ReadOnly Property LarghezzaI As Integer Implements IOrdineBox.Base
        Get
            Return Larghezza
        End Get
    End Property
    Public ReadOnly Property ProfonditaI As Integer Implements IOrdineBox.Profondita
        Get
            Return Profondita
        End Get
    End Property

    Public ReadOnly Property IdTipoFustellaI As Integer Implements IOrdineBox.IdTipoFustella
        Get
            Return IdTipoFustella
        End Get
    End Property

    Public Overrides Property Stato As Integer Implements IOrdineBox.StatoOrdine
        Get
            Return MyBase.Stato
        End Get
        Set(value As Integer)
            MyBase.Stato = value
        End Set
    End Property

    Public ReadOnly Property IdOrdineWithAttach As String
        Get
            Return "former:" & IdOrdine
        End Get
    End Property

    Public ReadOnly Property IdRiferimentoOrdine As Integer Implements IOrdineBox.IdRiferimentoOrdine
        Get
            Return IdOrdine
        End Get
    End Property

    Public ReadOnly Property QtaStr As String Implements IOrdineBox.QtaStr
        Get
            Return FormerHelper.Stringhe.FormattaNumero(Qta)
        End Get
    End Property

    Public ReadOnly Property ColoriDiStampaStr As String Implements IOrdineBox.ColoriStampaStr
        Get
            Return C.Descrizione
        End Get
    End Property

    Public ReadOnly Property IdOrdineWeb As Integer Implements IOrdineBox.IdOrdineWeb
        Get
            Return IdOrdine
        End Get
    End Property

    Public ReadOnly Property CorriereStr As String Implements IOrdineBox.CorriereStr
        Get
            Return Corriere.Descrizione
        End Get
    End Property

    Public ReadOnly Property ColliStr As String Implements IOrdineBox.ColliStr
        Get
            Return NumeroColli
        End Get
    End Property

    Public ReadOnly Property NomeLavoroStr As String Implements IOrdineBox.NomeLavoro
        Get
            Return NomeLavoro
        End Get
    End Property

    Public ReadOnly Property NFogliVisStr As String Implements IOrdineBox.NFogliVisStr
        Get
            Return NFogliVis
        End Get
    End Property

    Public ReadOnly Property OrientamentoSelezionato As Integer Implements IOrdineBox.OrientamentoSelezionato
        Get
            Return Orientamento
        End Get
    End Property

    Public ReadOnly Property OrientamentoSelezionatoStr As String Implements IOrdineBox.OrientamentoSelezionatoStr
        Get
            Return FormerEnumHelper.OrientamentoStr(Orientamento)
        End Get
    End Property

    Public ReadOnly Property NFogliVis As Integer
        Get
            Dim Ris As Integer = 0
            If L.Target = enTargetListinoBase.Foglio Then
                Ris = Nfogli
            Else
                If C.FR Then
                    Ris = Nfogli * 2
                Else
                    Ris = Nfogli
                End If
            End If
            Return Ris
        End Get
    End Property

    Private _ElencoLavorazioni As List(Of LavorazioneW) = Nothing
    Public ReadOnly Property ElencoLavorazioni(Optional EscludiLavorazioniInterne As Boolean = False) As List(Of LavorazioneW)
        Get
            If _ElencoLavorazioni Is Nothing Then
                _ElencoLavorazioni = New List(Of LavorazioneW)
                If Lavorazioni.Length Then
                    Dim Lav() As String = Lavorazioni.Split(",")

                    For Each L As String In Lav
                        If L.Trim.Length Then
                            Dim SingLav As New LavorazioneW
                            SingLav.Read(L)

                            If EscludiLavorazioniInterne Then
                                If SingLav.LavorazioneInterna = enSiNo.No Then _ElencoLavorazioni.Add(SingLav)
                            Else
                                _ElencoLavorazioni.Add(SingLav)
                            End If

                        End If

                    Next
                End If
            End If
            Return _ElencoLavorazioni

        End Get
    End Property

    Public ReadOnly Property PesoVolumetrico As Integer
        Get

            Dim Ris As Integer = 0

            Dim Altezza As Single = L.FormatoProdotto.Fc.Altezza + 3
            Dim Larghezza As Single = L.FormatoProdotto.Fc.Larghezza + 3
            Dim Profondita As Single = L.TipoCarta.CalcolaSpessoreCM(Qta)

            If L.Preventivazione.IdReparto <> enRepartoWeb.StampaOffset Then
                If L.IdModelloCubetto Then
                    Using M As New ModelloCubettoW
                        M.Read(L.IdModelloCubetto)
                        Altezza = M.Lunghezza / 10
                        Larghezza = M.Larghezza / 10
                        Profondita = M.Profondita / 10
                    End Using

                    Ris = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)
                    Ris = Ris * NumeroColli
                End If
            End If

            If Ris = 0 Then Ris = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)

            Return Ris

        End Get
    End Property

    Public ReadOnly Property PesoStr As String Implements IOrdineBox.PesoStr
        Get
            Dim Ris As String = Peso

            If PesoVolumetrico > Peso Then Ris = PesoVolumetrico

            Return Ris
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get

            Dim Ris As String = Qta & " "
            Ris &= L.Nome

            If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                'qui ci va anche altezza e larghezza
                Ris &= " (" & Altezza & "x" & Larghezza & " cm)"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property NomeProdotto As String Implements IOrdineBox.NomeProdotto
        Get
            Return L.Nome
        End Get
    End Property

    Public ReadOnly Property NomeCliente As String
        Get
            Return Utente.Nominativo
        End Get
    End Property


    Public ReadOnly Property AnteprimaWeb As String Implements IOrdineBox.AnteprimaWeb
        Get
            Dim ris As String = String.Empty
            If Anteprima.Length Then
                ris = Anteprima
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property ImportoNettoOrigStr As String Implements IOrdineBox.ImportoNettoOrigStr
        Get
            'Return FormerHelper.Stringhe.FormattaPrezzo(PrezzoCalcolatoNetto)
            Return FormerHelper.Stringhe.FormattaPrezzo(ImportoNettoOrig)
        End Get
    End Property


    Public ReadOnly Property ImportoNettoStr As String Implements IOrdineBox.ImportoNettoStr
        Get
            'Return FormerHelper.Stringhe.FormattaPrezzo(PrezzoCalcolatoNetto)
            Return FormerHelper.Stringhe.FormattaPrezzo(ImportoNetto)
        End Get
    End Property

    Public ReadOnly Property PagatoStr As String
        Get
            Dim ris As String = "No"

            If ConsegnaAssociata.HaUnPagamento Then
                ris = "Si"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property ImportoNettoOrig As Decimal
        Get
            Dim ris As Decimal = PrezzoCalcolatoNetto + Ricarico

            If IdCoupon = 0 Then
                ris -= Sconto
            End If

            If ris < 0 Then ris = 0
            Return ris
        End Get
    End Property


    Public ReadOnly Property ImportoNetto As Decimal
        Get
            Dim ris As Decimal = PrezzoCalcolatoNetto - Sconto + Ricarico
            If ris < 0 Then ris = 0
            Return ris
        End Get
    End Property

    Public ReadOnly Property DataInsStr As String
        Get
            Return StrConv(DataIns.ToString("ddd dd/MM/yyyy HH:mm"), vbProperCase)
        End Get
    End Property

    Public Overrides Property DataPrevProduzione As Date
        Get
            'qui ci va della logica 
            'se l'ordine e' in stato da inviare 
            Dim Ris As Date = Date.MinValue
            If Stato = enStatoOrdine.InAttesaAllegati Or Stato = enStatoOrdine.InAttesaPagamento Then
                'qui la devo calcolare 
                Dim l As New List(Of ILavorazioneB)
                For Each singLav As LavorazioneW In ElencoLavorazioni
                    l.Add(singLav)
                Next

                Dim C As New CorriereW
                C.Read(IdCorriere)
                Dim DateConsegna As RisDataConsegna = MgrDataConsegna.CalcolaDateConsegna(P, C, l)
                Select Case TipoConsegna
                    Case enTipoConsegna.Fast
                        Ris = DateConsegna.DataFastProduzione
                    Case enTipoConsegna.Normale
                        Ris = DateConsegna.DataNormaleProduzione
                    Case enTipoConsegna.Slow
                        Ris = DateConsegna.DataSlowProduzione
                End Select
            Else
                Ris = MyBase.DataPrevProduzione
            End If
            Return Ris
        End Get
        Set(value As Date)
            MyBase.DataPrevProduzione = value
        End Set
    End Property

    Public Overrides Property DataPrevConsegna As Date
        Get
            'qui ci va della logica 
            'se l'ordine e' in stato da inviare 
            Dim Ris As Date = Date.MinValue
            If Stato = enStatoOrdine.InAttesaAllegati Then
                'qui la devo calcolare 

                Dim l As New List(Of ILavorazioneB)
                For Each singLav As LavorazioneW In ElencoLavorazioni
                    l.Add(singLav)
                Next

                Dim C As New CorriereW
                C.Read(IdCorriere)
                Dim DateConsegna As RisDataConsegna = MgrDataConsegna.CalcolaDateConsegna(P, C, l)
                Select Case TipoConsegna
                    Case enTipoConsegna.Fast
                        Ris = DateConsegna.DataFast
                    Case enTipoConsegna.Normale
                        Ris = DateConsegna.DataNormale
                    Case enTipoConsegna.Slow
                        Ris = DateConsegna.DataSlow
                End Select
            Else
                Ris = MyBase.DataPrevConsegna
            End If
            Return Ris
        End Get
        Set(value As Date)
            MyBase.DataPrevConsegna = value
        End Set
    End Property

    Public ReadOnly Property DataConsegnaStr As String Implements IOrdineBox.DataConsegnaStr
        Get
            Return StrConv(DataPrevConsegna.ToString("dddd dd/MM/yyyy"), vbProperCase)
        End Get
    End Property

    Public ReadOnly Property DimensioniStr As String Implements IOrdineBox.DimensioniStr
        Get
            Dim Ris As String = String.Empty


            Dim Etichetta As String = FormerEnumHelper.TipoUnitaDiMisura(L.TipoUnitaMisuraInInput)


            If L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri OrElse L.TipoPrezzo = enTipoPrezzo.SuFoglio Then
                'qui ci va anche altezza e larghezza
                Ris = " (" & Larghezza & "B x " & Altezza & "A " & Etichetta & ")"
            ElseIf L.Preventivazione.IdReparto = enRepartoWeb.Packaging AndAlso L.Preventivazione.IdFunzionePack <> 0 Then
                Ris = " (" & Larghezza & "B x " & Altezza & "A x " & Profondita & "P " & Etichetta & " Chiuso)"
            ElseIf L.Preventivazione.IdPluginToUse = enPluginOnline.Etichette Then
                Ris = " (" & Larghezza & "B x " & Altezza & "A " & Etichetta & ")"
            ElseIf L.Preventivazione.IdPluginToUse = enPluginOnline.EtichetteCm Then
                Ris = " (" & Larghezza & "B x " & Altezza & "A " & Etichetta & ")"
            ElseIf L.AllowCustomSize = enSiNo.Si OrElse L.idGruppoLogico Then
                If (Larghezza <> 0 And Larghezza <> F.Larghezza) OrElse (Altezza <> 0 And Altezza <> F.Lunghezza) Then
                    Ris = " (" & Larghezza & "B x " & Altezza & "A " & Etichetta & ")"
                Else
                    Ris = F.FormatoCartaStr
                End If
            Else
                Ris = F.FormatoCartaStr
            End If


            Return Ris
        End Get
    End Property

    Private _StatoStr As String = String.Empty
    Public Property StatoStr As String Implements IOrdineBox.StatoStr
        Get
            If _StatoStr.Length = 0 Then
                If Omaggio = enSiNo.Si Then
                    _StatoStr = "OMAGGIO"
                Else
                    _StatoStr = FormerEnumHelper.StatoOrdineString(Stato, True, IdCorriere)
                End If

            End If
            Return _StatoStr

        End Get
        Set(value As String)
            _StatoStr = value
        End Set

    End Property

    Public ReadOnly Property IdOrdineInterno As Integer Implements IOrdineBox.IdOrdineInt
        Get
            Return IdOrdineInt
        End Get
    End Property

    Public ReadOnly Property Modificabile As Boolean
        Get
            Dim ris As Boolean = False

            If Stato < enStatoOrdine.Registrato Then
                If IdOrdineInt = 0 Then
                    ris = True
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property ColoreStato As System.Drawing.Color
        Get

            Dim Ris As Drawing.Color
            If Omaggio = enSiNo.Si Then
                Ris = FormerColori.ColoreOrdineOmaggio
            Else
                Ris = FormerColori.GetColoreStatoOrdine(Stato)
            End If
            Return Ris

        End Get
    End Property

    Public ReadOnly Property ColoreStatoHTML() As String Implements IOrdineBox.ColoreStatoHTML
        Get
            Dim ris As String = String.Empty

            If Omaggio = enSiNo.Si Then
                ris = ColorTranslator.ToHtml(FormerColori.ColoreOrdineOmaggio)
            Else
                ris = FormerColori.GetColoreStatoOrdineHtml(Stato)
            End If

            Return ris

        End Get
    End Property

    Public ReadOnly Property BoxTitolo As String Implements IOrdineBox.BoxTitolo
        Get
            Dim ris As String = String.Empty
            ris = P.Descrizione
            Return ris
        End Get
    End Property

    Public ReadOnly Property IconaStato As String Implements IOrdineBox.IconaStato
        Get
            Dim ris As String = FormerEnumHelper.GetIconaStato(Stato)

            Return ris
        End Get
    End Property

    Public ReadOnly Property SupportoStr As String Implements IOrdineBox.SupportoStr
        Get
            Return TC.RiassuntoCarrello
        End Get
    End Property

    Public ReadOnly Property PathTemplate As String Implements IOrdineBox.PathTemplate
        Get
            Return F.PdfTemplate
        End Get
    End Property

    Public ReadOnly Property SchedaProdottoStr As String Implements IOrdineBox.SchedaProdotto
        Get
            Dim Ris As String = "/" & P.IdPrev & "/" & F.IdFormProd & "/" & TC.IdTipoCarta & "/" & C.IdColoreStampa & "/" & (L.faccmin / 2) & "/"
            Ris &= "Stampa-" & P.NomeInUrl & "-" & F.NomeInUrl & "-" & TC.NomeInUrl & "-" & C.NomeInUrl

            Return Ris
        End Get
    End Property

    Public ReadOnly Property RiassuntoBox As String
        Get
            Dim ris As String = Riassunto

            If ris.Length > 30 Then ris = ris.Substring(0, 27) & "..."

            Return ris
        End Get
    End Property

    Public ReadOnly Property BoxImgRif As String Implements IOrdineBox.BoxImgRif
        Get
            Dim Ris As String = String.Empty
            Select Case L.PrendiIcoDa
                Case enPrendiIcoDa.FormatoProdotto
                    Ris = L.FormatoProdotto.ImgRif
                Case enPrendiIcoDa.ColoreDiStampa
                    Ris = L.ColoreStampa.imgrif
                Case enPrendiIcoDa.Preventivazione
                    Ris = P.ImgRif
                Case enPrendiIcoDa.TipoCarta
                    Ris = L.TipoCarta.ImgRif
            End Select
            Return Ris
        End Get
    End Property

    Public ReadOnly Property BoxLavorazioni As List(Of String) Implements IOrdineBox.BoxLavorazioni
        Get
            Dim ris As New List(Of String)
            If Lavorazioni.Length Then


                Dim Lav() As String = Lavorazioni.Split(",")

                For Each L As String In Lav
                    If L.Length Then
                        Dim SingLav As New LavorazioneW
                        SingLav.Read(L)
                        If SingLav.LavorazioneInterna = enSiNo.No Then ris.Add(SingLav.Descrizione)
                        SingLav = Nothing
                    End If

                Next
            End If
            Return ris

        End Get
    End Property

    Public ReadOnly Property NoteOrd As String Implements IOrdineBox.NoteOrd
        Get
            Return Annotazioni
        End Get
    End Property

    Private ReadOnly Property IOrdineBox_IdCoupon As Integer Implements IOrdineBox.IdCoupon
        Get
            Return IdCoupon
        End Get
    End Property

    Public ReadOnly Property ImportoTotaleScontiStr As String Implements IOrdineBox.ImportoTotaleScontiStr
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Sconto)
        End Get
    End Property

    Public ReadOnly Property FileModificabili As Boolean
        Get
            Dim ris As Boolean = True
            If Stato < enStatoOrdine.Registrato Then
                If SorgenteFronte.Length Then
                    If TipoRetro = enTipoRetro.RetroDifferente Then
                        If SorgenteRetro.Length Then
                            ris = False
                        End If
                    Else
                        ris = False
                    End If
                End If
            Else
                ris = False
            End If
            Return ris
        End Get
    End Property

    Private _ConsegnaAssociata As Consegna = Nothing
    Public ReadOnly Property ConsegnaAssociata As Consegna
        Get
            If _ConsegnaAssociata Is Nothing Then
                _ConsegnaAssociata = New Consegna
                _ConsegnaAssociata.Read(IdCons)
            End If
            Return _ConsegnaAssociata
        End Get
    End Property

    Public Property FileScaricatiNomeAnteprima As String = String.Empty
    Public Property FileScaricatiNomeFronte As String = String.Empty
    Public Property FileScaricatiNomeRetro As String = String.Empty

    Public ReadOnly Property Omaggio As Integer Implements IOrdineBox.Omaggio
        Get
            Dim ris As Integer = enSiNo.No

            ris = OrdineInOmaggio

            Return ris
        End Get
    End Property

#End Region

    Private _Utente As Utente = Nothing
    Public ReadOnly Property Utente As Utente
        Get
            If _Utente Is Nothing Then
                _Utente = New Utente
                _Utente.Read(IdUt)
            End If
            Return _Utente
        End Get
    End Property


#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IOrdineWeb.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IOrdineWeb.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IOrdineWeb.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Ordini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IOrdineWeb
    Inherits _IOrdineWeb

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface