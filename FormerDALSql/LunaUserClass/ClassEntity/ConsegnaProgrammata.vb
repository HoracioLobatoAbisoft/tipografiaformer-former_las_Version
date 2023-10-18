#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports System.Drawing
Imports FormerLib


''' <summary>
'''Entity Class for table T_cons
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ConsegnaProgrammata
    Inherits _ConsegnaProgrammata
    Implements IConsegnaProgrammata
    Implements ICloneable

    Public Diritti As New ConsegnaDiritti(Me)

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

    Public Overrides Property EmailNotificheCorriere As String
        Get
            Dim Ris As String = MyBase.EmailNotificheCorriere

            If Ris.Length = 0 Then
                If Cliente.EmailAmministrativa.Length AndAlso
                   Cliente.EmailAmministrativa <> FormerConst.EmailNonDisponibile Then
                    Ris = Cliente.EmailAmministrativa
                End If
            End If

            'Ris = Cliente.Email

            Return Ris
        End Get
        Set(value As String)
            MyBase.EmailNotificheCorriere = value
        End Set
    End Property

#Region "Logic Field"

    Private _DataOrdineStato As enStatoDataOrdine = enStatoDataOrdine.NonDefinita
    Public ReadOnly Property DataOrdineStato As enStatoDataOrdine
        Get
            If _DataOrdineStato = enStatoDataOrdine.NonDefinita Then
                If IdStatoConsegna <> enStatoConsegna.Consegnata Then
                    _DataOrdineStato = enStatoDataOrdine.Prevista
                    If HaOrdiniConDataGarantita Then
                        _DataOrdineStato = enStatoDataOrdine.Garantita
                    ElseIf Not PagamentoAnticipato Is Nothing Then
                        _DataOrdineStato = enStatoDataOrdine.Confermata
                    Else
                        'qui controllo se tutti gli ordini dentro sono in stato da stampa in corso in poi e la metto comunque
                        'confermata
                        If ListaOrdini.FindAll(Function(x) x.Stato < enStatoOrdine.StampaInizio).Count = 0 Then
                            _DataOrdineStato = enStatoDataOrdine.Confermata
                        End If
                    End If
                Else
                    _DataOrdineStato = enStatoDataOrdine.Consegnata
                End If
            End If
            Return _DataOrdineStato
        End Get
    End Property

    Private _DataUltimaUscitaDaMagazzino As Date = Date.MinValue
    Public ReadOnly Property DataUltimaUscitaDaMagazzino As Date
        Get
            'Dim dataRis As Date = Giorno
            If _DataUltimaUscitaDaMagazzino = Date.MinValue Then
                If ListaOrdini.Count Then
                    ListaOrdini.Sort(Function(x, y) y.DataEffConsegna.CompareTo(x.DataEffConsegna))
                    If ListaOrdini(0).DataEffConsegna <> Date.MinValue Then _DataUltimaUscitaDaMagazzino = ListaOrdini(0).DataEffConsegna
                End If
            End If

            Return _DataUltimaUscitaDaMagazzino
        End Get
    End Property

    Public ReadOnly Property DataPrevistaProduzione As Date
        Get
            Return Giorno
        End Get
    End Property

    Public ReadOnly Property DataPrevistaConsegna As Date
        Get
            Return MgrDataConsegna.PosticipaDataConsegna(Giorno, IdCorr, Corriere.GGConsegna)
        End Get
    End Property

    Protected _DataEffConsegna As DateTime = Nothing

    <XmlElementAttribute("DataEffConsegna")> _
    Public Property DataEffConsegna() As DateTime
        Get
            If _DataEffConsegna <> Date.MinValue Then
                Return _DataEffConsegna
            Else
                Return _Giorno
            End If
        End Get
        Set(ByVal value As DateTime)
            If _DataEffConsegna <> value Then
                IsChanged = True
                _DataEffConsegna = value
            End If
        End Set
    End Property

    Private _Corriere As Corriere = Nothing
    Public ReadOnly Property Corriere As Corriere
        Get
            If _Corriere Is Nothing Then
                _Corriere = New Corriere
                If IdCorr Then _Corriere.Read(IdCorr)
            End If
            Return _Corriere
        End Get
    End Property

    Private _MetodoPagamento As TipoPagamento = Nothing
    Public ReadOnly Property MetodoPagamento As TipoPagamento
        Get
            If _MetodoPagamento Is Nothing Then
                _MetodoPagamento = New TipoPagamento
                If IdPagam Then _MetodoPagamento.Read(IdPagam)
            End If
            Return _MetodoPagamento
        End Get
    End Property

    Private _CorriereNome As String = ""
    Public Property CorriereNome As String
        Get
            Dim ris As String = _CorriereNome
            If ris.Length = 0 Then ris = Corriere.NomeBreve

            Return ris
        End Get
        Set(value As String)
            _CorriereNome = value
        End Set
    End Property

    Public ReadOnly Property ColoreStatoConsegna As Color
        Get
            Dim ris As Color = FormerColori.GetColoreStatoConsegna(IdStatoConsegna)

            Return ris

        End Get
    End Property

    Public ReadOnly Property ImpContrassegnoStr As String
        Get
            Dim ris As String = "-"
            Dim val As Decimal = 0

            If IdPagam = enMetodoPagamento.ContrassegnoAlRitiro Then

                'qui devo vedere se esiste un documento 

                If HaDocumentiFiscali Then

                    Dim IdDoc As Integer = ListaIdDocumenti(0)

                    Using r As New Ricavo
                        r.Read(IdDoc)
                        val = r.Totale
                    End Using

                End If

            End If

            If val Then
                ris = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(val)
            End If

            Return ris

        End Get
    End Property

    Private _Cliente As VoceRubrica = Nothing
    Public ReadOnly Property Cliente As VoceRubrica
        Get
            If _Cliente Is Nothing Then
                _Cliente = New VoceRubrica
                _Cliente.Read(IdRub)
            End If
            Return _Cliente
        End Get
    End Property

    Private _RagSoc As String = ""
    Public Property RagSoc As String
        Get
            Dim ris As String = _RagSoc
            If ris.Length = 0 Then
                ris = Cliente.RagSocNome
            End If
            Return ris
        End Get
        Set(value As String)
            _RagSoc = value
        End Set
    End Property

    Public ReadOnly Property ListaDocumenti As List(Of Ricavo)
        Get
            Dim ris As New List(Of Ricavo)

            For Each SingIdDoc In ListaIdDocumenti
                Using R As New Ricavo
                    R.Read(SingIdDoc)
                    ris.Add(R)
                End Using
            Next

            Return ris
        End Get
    End Property

    Public ReadOnly Property ListaIdDocumenti As List(Of Integer)
        Get
            Dim Ris As New List(Of Integer)

            For Each O As Ordine In ListaOrdini
                If O.IdDoc Then
                    If Ris.Exists(Function(x) x = O.IdDoc) = False Then Ris.Add(O.IdDoc)
                End If
            Next

            Return Ris

        End Get
    End Property

    Public ReadOnly Property HaDocumentiFiscali As Boolean
        Get
            Dim ris As Boolean = False

            If ListaIdDocumenti.Count Then ris = True

            Return ris
        End Get
    End Property

    Public Sub AggiornaColliPeso(Optional ByVal PesoForzato As Single = 0)

        If IdStatoConsegna = enStatoConsegna.InLavorazione OrElse _
            IdStatoConsegna = enStatoConsegna.Sospesa OrElse _
            IdStatoConsegna = enStatoConsegna.Eliminata Then
            'If HaUnPagamentoAnticipato = False Then

            'calcolo dal db il numero di colli reali e il peso reale prendendoli dai dati dell'ordine e del prodotto associato

            Dim l As List(Of ConsProgrOrdini) = Nothing
                Using mgr As New ConsProgrOrdiniDAO
                    l = mgr.FindAll(New LUNA.LunaSearchParameter("IdCons", IdCons))
                End Using

                Dim TotColli As Integer = 0
                Dim TotPeso As Integer = 0

                Dim ListaScatole As New List(Of Integer)

                For Each co As ConsProgrOrdini In l

                    'per ogni ordine devo vedere se sta inballato in scatola e prendere come numero di colli reali quello 
                    'Dim lOs As List(Of OrdineScatola)
                    'Using mgr As New OrdiniScatoleDAO
                    '    lOs = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrdine", co.IdOrd))
                    'End Using

                    Dim O As New Ordine
                    O.Read(co.IdOrd)
                    Dim ColliOrdine As Integer = O.NumeroRealeColli
                    'qui prima di aggiungere il numero di colli controllo quanti di questi sono contenuti dentro una scatola
                    Using mgr As New OrdiniScatoleDAO
                        Dim listaOS As List(Of OrdineScatola) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrdine", O.IdOrd))
                        ColliOrdine -= listaOS.Count

                        For Each singOs As OrdineScatola In listaOS
                            If ListaScatole.IndexOf(singOs.IdScatola) = -1 Then
                                ListaScatole.Add(singOs.IdScatola)
                            End If
                        Next

                    End Using

                    TotColli += ColliOrdine
                    TotPeso += O.Prodotto.PesoComplessivo

                Next

                TotColli += ListaScatole.Count

                NumColli = TotColli
                If PesoForzato Then
                    Peso = PesoForzato
                Else
                    Peso = TotPeso
                End If
                LastUpdate = 1

            'LastUpdate = 1
            'salva se stessa
            Save()

            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, IdCons, "Aggiornati COLLI a " & NumColli & " e PESO a " & Peso)

            'End If

        End If

    End Sub

    Public Function CalcolaImportoSpedizioni(Optional AncheAssociati As Boolean = False) As Decimal

        Dim ris As Decimal = 0

        If IdCorr <> enCorriere.RitiroCliente Then

            Dim TotImp As Decimal = 0
            Dim KgPeso As Single = 0
            Dim PesiVolumetrici As Single = 0

            For Each O As Ordine In ListaOrdini

                TotImp += O.TotaleImponibile

                KgPeso += O.Prodotto.PesoComplessivo

                If O.Prodotto.IdListinoBase Then

                    Dim L As ListinoBase = O.Prodotto.ListinoBase

                    Dim Altezza As Single = L.FormatoProdotto.FormatoCarta.Altezza + 3
                    Dim Larghezza As Single = L.FormatoProdotto.FormatoCarta.Larghezza + 3
                    Dim Profondita As Single = L.TipoCarta.CalcolaSpessoreCM(O.QtaOrdine) 'O.Prodotto.NumPezzi)'MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO

                    Dim SingPesoVolum As Single = 0
                    If L.Preventivazione.IdReparto <> enRepartoWeb.StampaOffset Then
                        If L.IdModelloCubetto Then
                            Using M As New ModelloCubetto
                                M.Read(L.IdModelloCubetto)
                                Altezza = M.Lunghezza / 10
                                Larghezza = M.Larghezza / 10
                                Profondita = M.Profondita / 10
                            End Using

                            SingPesoVolum = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)
                            SingPesoVolum = SingPesoVolum * O.NumeroRealeColli
                        End If
                    End If

                    If SingPesoVolum = 0 Then SingPesoVolum = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)

                    PesiVolumetrici += SingPesoVolum

                End If

            Next

            If AncheAssociati Then

                For Each O As Ordine In ListaOrdiniAssociati
                    TotImp += O.TotaleImponibile

                    KgPeso += O.Prodotto.PesoComplessivo

                    If O.Prodotto.IdListinoBase Then

                        Dim L As ListinoBase = O.Prodotto.ListinoBase

                        Dim Altezza As Single = L.FormatoProdotto.FormatoCarta.Altezza + 3
                        Dim Larghezza As Single = L.FormatoProdotto.FormatoCarta.Larghezza + 3
                        Dim Profondita As Single = L.TipoCarta.CalcolaSpessoreCM(O.QtaOrdine) 'O.Prodotto.NumPezzi)'MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO

                        Dim SingPesoVolum As Single = 0
                        If L.Preventivazione.IdReparto <> enRepartoWeb.StampaOffset Then
                            If L.IdModelloCubetto Then
                                Using M As New ModelloCubetto
                                    M.Read(L.IdModelloCubetto)
                                    Altezza = M.Lunghezza / 10
                                    Larghezza = M.Larghezza / 10
                                    Profondita = M.Profondita / 10
                                End Using

                                SingPesoVolum = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)
                                SingPesoVolum = SingPesoVolum * O.NumeroRealeColli
                            End If
                        End If

                        If SingPesoVolum = 0 Then SingPesoVolum = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)

                        PesiVolumetrici += SingPesoVolum
                    End If
                Next

            End If

            If Peso Then
                KgPeso = Peso
            End If

            ris = MgrCorriere.CalcolaTariffa(Corriere, PesiVolumetrici, KgPeso, TotImp, MetodoPagamento)

        End If

        Return ris

    End Function

    Public Function ReadByIdOrd(IdOrd As Integer) As Integer
        'Return 0 if all ok
        Dim Ris As Integer = 0
        Try
            Using Mgr As New ConsegneProgrammateDAO
                Dim int As ConsegnaProgrammata = Mgr.ReadByIdOrd(IdOrd)
                _IdCons = int.IdCons
                _Giorno = int.Giorno
                _IdRub = int.IdRub
                _Annotazioni = int.Annotazioni
                _MatPom = int.MatPom
                _IdCorr = int.IdCorr
                _CodTrack = int.CodTrack
                _IdOperatore = int.IdOperatore
                _IdStatoConsegna = int.IdStatoConsegna
                _NumColli = int.NumColli
                _IdPagam = int.IdPagam
                _Peso = int.Peso
                _Eliminato = int.Eliminato
                _DataEffettiva = int.DataEffettiva
                _LastUpdate = int.LastUpdate
                _DataPrevistaOriginale = int.DataPrevistaOriginale
            End Using
        Catch ex As Exception
            ManageError(ex)
            Ris = 1
        End Try
        Return Ris
    End Function

    Public Sub SetLastUpdate(LastUpdateValue As Integer)
        LastUpdate = LastUpdateValue
        Using mgr As New ConsegneProgrammateDAO
            mgr.SetLastUpdate(IdCons, LastUpdateValue)
        End Using

    End Sub

    Private _IndirizzoRif As Indirizzo = Nothing
    Public ReadOnly Property IndirizzoRif As Indirizzo
        Get
            If _IndirizzoRif Is Nothing Then
                _IndirizzoRif = New Indirizzo
                If IdIndirizzo Then
                    _IndirizzoRif.Read(IdIndirizzo)
                Else
                    _IndirizzoRif.IdRubrica = Cliente.IdRub
                    _IndirizzoRif.Cap = Cliente.CAP
                    _IndirizzoRif.Citta = Cliente.Citta
                    _IndirizzoRif.IdComune = Cliente.IdComune
                    _IndirizzoRif.Indirizzo = Cliente.Indirizzo
                End If
            End If
            Return _IndirizzoRif
        End Get
    End Property

    Public ReadOnly Property IndirizzoRiassunto As String
        Get
            Dim ris As String = IndirizzoStr(False)

            If ris.StartsWith(Cliente.RagSocNome) Then
                ris = ris.Substring(Cliente.RagSocNome.Length + 2)
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property IndirizzoStr(Optional WithNome As Boolean = True) As String
        Get
            Dim Ris As String = String.Empty
            Ris = IndirizzoRif.Riassunto(WithNome)
            'If IdIndirizzo Then
            '    Using i As New Indirizzo
            '        i.Read(IdIndirizzo)
            '        Ris = i.Riassunto(WithNome)
            '    End Using
            'Else
            '    Ris = Cliente.IndirizzoPredefinito
            'End If
            Return Ris
        End Get
    End Property

    Public Function ListaOrdiniCP() As List(Of ConsProgrOrdini)
        Dim LOrd As New List(Of ConsProgrOrdini)
        Using mgr As New ConsProgrOrdiniDAO
            LOrd = mgr.FindAll(New LUNA.LunaSearchParameter("IdCons", IdCons))

        End Using
        Return LOrd

    End Function

    Public Function ListaIdOrdiniAssociati() As String

        Dim Ris As String = String.Empty

        For Each O As Ordine In (New OrdiniDAO).FindAll(New LUNA.LunaSearchParameter("IdConsRiferimento", IdCons))
            Ris &= O.IdOrd & ","
        Next
        Ris = Ris.TrimEnd(",")

        Return Ris

    End Function

    Public Function ListaIdOrdini() As String

        Dim Ris As String = String.Empty

        For Each O As ConsProgrOrdini In ListaOrdiniCP()
            Ris &= O.IdOrd & ","
        Next
        Ris = Ris.TrimEnd(",")

        Return Ris

    End Function

    Private _ListaOrdini As List(Of Ordine)
    Public Property ListaOrdini As List(Of Ordine)
        Get
            'If _ListaOrdini Is Nothing Then
            Using mgr As New OrdiniDAO
                _ListaOrdini = mgr.ListaOrdiniByIdCons(_IdCons)
            End Using
            'End If
            Return _ListaOrdini
        End Get
        Set(value As List(Of Ordine))
            _ListaOrdini = value
        End Set
    End Property

    Public ReadOnly Property ListaOrdiniAssociati As List(Of Ordine)
        Get
            Dim l As List(Of Ordine)
            Using mgr As New OrdiniDAO
                l = mgr.ListaOrdiniAssociatiByIdCons(_IdCons)
            End Using
            Return l
        End Get
    End Property

    Public ReadOnly Property DisponibilePerIlPlanning As Boolean
        Get
            Dim ris As Boolean = True

            For Each O As Ordine In ListaOrdini
                If O.Stato > enStatoOrdine.UscitoMagazzino Then
                    ris = False
                    Exit For
                End If
            Next
            Return ris
        End Get
    End Property

    Public ReadOnly Property HaSoloOrdiniUscitiDaMagazzino As Boolean
        Get
            Dim ris As Boolean = True

            For Each O As Ordine In ListaOrdini
                If O.Stato <> enStatoOrdine.UscitoMagazzino Then
                    ris = False
                    Exit For
                End If
            Next
            Return ris
        End Get
    End Property

    Public ReadOnly Property PresentiOrdiniUscitiDaMagazzino As Boolean
        Get
            Dim ris As Boolean = False

            For Each O As Ordine In ListaOrdini
                If O.Stato >= enStatoOrdine.UscitoMagazzino Then
                    ris = True
                    Exit For
                End If
            Next
            Return ris
        End Get
    End Property

    Public ReadOnly Property HaUnPagamentoAnticipato As Boolean
        Get
            Dim ris As Boolean = False

            If Not PagamentoAnticipato Is Nothing Then
                ris = True
            End If

            'Using mgr As New PagamentiDAO
            '    Dim l As List(Of Pagamento) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Pagamento.IdConsegna, IdCons))
            '    If l.Count Then
            '        ris = True
            '    End If
            'End Using
            Return ris
        End Get
    End Property

    Public ReadOnly Property PagamentoAnticipato As Pagamento
        Get
            Dim ris As Pagamento = Nothing

            Using mgr As New PagamentiDAO
                ris = mgr.Find(New LUNA.LunaSearchParameter(LFM.Pagamento.IdConsegna, IdCons))
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property HaOrdiniConDataGarantita As Boolean
        Get
            Dim ris As Boolean = False
            If ListaOrdini.FindAll(Function(x) x.ConsegnaGarantita <> Date.MinValue).Count Then ris = True
            Return ris
        End Get
    End Property

    'Private Function ModificabileEx(VoglioCambiareGiorno As Boolean,
    '                               VoglioCambiareIndirizzo As Boolean,
    '                               VoglioModificareOrdiniContenutioAccorpareConUnAltra As Boolean,
    '                               VoglioCambiareTipoDocumentoFiscaleAOrdini As Boolean,
    '                               ConsideraUscitiDaMagazzinoComeBloccanti As Boolean) As RisConsegnaModificabile
    '    Dim ris As New RisConsegnaModificabile

    '    'If IdStatoConsegna <> enStatoConsegna.InLavorazione Then
    '    '    ris = False
    '    'End If

    '    'If Blocco = enSiNo.Si Then
    '    '    ris = False
    '    'End If

    '    'If ControllaUscitiMagazzino Then
    '    '    If PresentiOrdiniUscitiDaMagazzino Then
    '    '        ris = False
    '    '    End If
    '    'End If

    '    ''qui controllo che non ci siano pagamenti registrati 
    '    'If HaUnPagamentoAnticipato Then
    '    '    ris = False
    '    'End If

    '    ''NON SI MODIFICANO CONSEGNE CHE HANNO DOCUMENTI FISCALI
    '    'If HaDocumentiFiscali Then
    '    '    ris = False
    '    'End If

    '    If VoglioCambiareGiorno Then
    '        If HaDocumentiFiscali Then
    '            ris.Modificabile = False
    '            ris.AddProblem("Ha documenti fiscali già emessi")
    '        End If

    '        If HaUnPagamentoAnticipato Then
    '            ris.Modificabile = False
    '            ris.AddProblem("Ha un pagamento anticipato")
    '        End If

    '        If HaOrdiniConDataGarantita Then
    '            ris.Modificabile = False
    '            ris.AddProblem("Ha ordini con data garantita")
    '        End If

    '        If IdStatoConsegna <> enStatoConsegna.InLavorazione Then
    '            ris.Modificabile = False
    '            ris.AddProblem("La consegna non è più in stato modificabile")
    '        End If

    '        If Blocco = enSiNo.Si Then
    '            ris.Modificabile = False
    '            ris.AddProblem("La consegna ha il lucchetto")
    '        End If
    '    End If

    '    If VoglioCambiareIndirizzo AndAlso ris.Modificabile = True Then
    '        If HaDocumentiFiscali Then
    '            ris.Modificabile = False
    '            ris.AddProblem("Ha documenti fiscali già emessi")
    '        End If

    '        If HaUnPagamentoAnticipato Then 'DA SISTEMARE FACENDOSI PASSARE IL CAP
    '            ris.Modificabile = False
    '            ris.AddProblem("Ha un pagamento anticipato")
    '        End If

    '        If IdStatoConsegna <> enStatoConsegna.InLavorazione Then
    '            ris.Modificabile = False
    '            ris.AddProblem("La consegna non è più in stato modificabile")
    '        End If

    '        If Blocco = enSiNo.Si Then
    '            ris.Modificabile = False
    '            ris.AddProblem("La consegna ha il lucchetto")
    '        End If
    '    End If

    '    If VoglioModificareOrdiniContenutioAccorpareConUnAltra AndAlso ris.Modificabile = True Then
    '        If HaDocumentiFiscali Then
    '            ris.Modificabile = False
    '            ris.AddProblem("Ha documenti fiscali già emessi")
    '        End If

    '        If HaUnPagamentoAnticipato Then
    '            ris.Modificabile = False
    '            ris.AddProblem("Ha un pagamento anticipato")
    '        End If

    '        If IdStatoConsegna <> enStatoConsegna.InLavorazione Then
    '            ris.Modificabile = False
    '            ris.AddProblem("La consegna non è più in stato modificabile")
    '        End If

    '        If Blocco = enSiNo.Si Then
    '            ris.Modificabile = False
    '            ris.AddProblem("La consegna ha il lucchetto")
    '        End If
    '    End If

    '    If VoglioCambiareTipoDocumentoFiscaleAOrdini AndAlso ris.Modificabile = True Then
    '        If HaDocumentiFiscali Then
    '            ris.Modificabile = False
    '            ris.AddProblem("Ha documenti fiscali già emessi")
    '        End If

    '        If HaUnPagamentoAnticipato Then
    '            ris.Modificabile = False
    '            ris.AddProblem("Ha un pagamento anticipato")
    '        End If

    '        If IdStatoConsegna <> enStatoConsegna.InLavorazione Then
    '            ris.Modificabile = False
    '            ris.AddProblem("La consegna non è più in stato modificabile")
    '        End If

    '        If Blocco = enSiNo.Si Then
    '            ris.Modificabile = False
    '            ris.AddProblem("La consegna ha il lucchetto")
    '        End If
    '    End If

    '    If ConsideraUscitiDaMagazzinoComeBloccanti AndAlso ris.Modificabile = True Then
    '        If PresentiOrdiniUscitiDaMagazzino Then
    '            ris.Modificabile = False
    '            ris.AddProblem("Sono presenti ordini usciti da magazzino")
    '        End If
    '    End If

    '    Return ris
    'End Function
    'Public Function ModificabileEx(InputRequest As InputModificareConsegna) As RisConsegnaModificabile

    '    Return ModificabileEx(InputRequest.VoglioCambiareGiorno,
    '                          InputRequest.VoglioCambiareIndirizzo,
    '                          InputRequest.VoglioModificareOrdiniContenuti,
    '                          InputRequest.VoglioAccorparlaConUnAltraConsegna,
    '                          InputRequest.VoglioCambiareTipoDocumentoFiscaleAOrdini,
    '                          InputRequest.ConsideraUscitiDaMagazzinoComeBloccanti)

    'End Function
    '<Obsolete("This method is deprecated, use ModificabileEx with InputParameter Class instead.")>
    'Public Function ModificabileEx(VoglioCambiareGiorno As Boolean,
    '                               VoglioCambiareIndirizzo As Boolean,
    '                               VoglioModificareOrdiniContenuti As Boolean,
    '                               VoglioAccorparlaConUnAltraConsegna As Boolean,
    '                               VoglioCambiareTipoDocumentoFiscaleAOrdini As Boolean,
    '                               ConsideraUscitiDaMagazzinoComeBloccanti As Boolean) As RisConsegnaModificabile

    '    Dim VoglioModificareOrdiniContenutioAccorpareConUnAltra As Boolean = False

    '    If VoglioModificareOrdiniContenuti Or VoglioAccorparlaConUnAltraConsegna Then
    '        VoglioModificareOrdiniContenutioAccorpareConUnAltra = True
    '    End If

    '    Return ModificabileEx(VoglioCambiareGiorno, VoglioCambiareIndirizzo, VoglioModificareOrdiniContenutioAccorpareConUnAltra, VoglioCambiareTipoDocumentoFiscaleAOrdini, ConsideraUscitiDaMagazzinoComeBloccanti)

    'End Function

    'Public Function Modificabile(ControllaUscitiMagazzino As Boolean) As Boolean

    '    Dim Ris As Boolean = True

    '    If IdStatoConsegna <> enStatoConsegna.InLavorazione Then
    '        Ris = False
    '    End If

    '    If Blocco = enSiNo.Si Then
    '        Ris = False
    '    End If

    '    If ControllaUscitiMagazzino Then
    '        If PresentiOrdiniUscitiDaMagazzino Then
    '            Ris = False
    '        End If
    '    End If

    '    'qui controllo che non ci siano pagamenti registrati 
    '    If HaUnPagamentoAnticipato Then
    '        Ris = False
    '    End If

    '    'NON SI MODIFICANO CONSEGNE CHE HANNO DOCUMENTI FISCALI
    '    If HaDocumentiFiscali Then
    '        Ris = False
    '    End If

    '    ''NON SI POSSONO MODIFICARE LE CONSEGNE CON ORDINI CON CONSEGNA GARANTITA
    '    'If ListaOrdini.FindAll(Function(x) x.ConsegnaGarantita <> Date.MinValue).Count Then
    '    '    Ris = False
    '    'End If

    '    Return Ris

    'End Function

    Public ReadOnly Property HaSoloOrdiniProntiConsegna As Boolean
        Get
            Dim ris As Boolean = True
            For Each O As Ordine In ListaOrdini
                If O.Stato <> enStatoOrdine.ProntoRitiro Then
                    ris = False
                    Exit For
                End If
            Next
            Return ris
        End Get
    End Property

    Public Property Forzata As Boolean = False

    Public ReadOnly Property SpedibileConGls As Boolean
        Get
            Dim ris As Boolean = True
            'If Giorno < Date.Today Then
            '    ris = False
            'Else
            If HaSoloOrdiniProntiConsegna = False And Forzata = False Then
                ris = False
            Else
                If IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
                    ris = False
                Else
                    If Corriere.IdCorriere <> enCorriere.GLS And
                        Corriere.IdCorriere <> enCorriere.PortoAssegnatoGLS And
                        Corriere.IdCorriere <> enCorriere.GLSIsole Then
                        ris = False
                    End If
                End If
            End If
            'End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property StatoStr As String
        Get
            Dim ris As String = FormerLib.FormerEnum.FormerEnumHelper.StatoConsegnaString(IdStatoConsegna)
            Return ris
        End Get
    End Property

    Public ReadOnly Property PagamentoStr As String
        Get
            Dim ris As String = String.Empty

            If IdPagam Then
                Using p As New TipoPagamento
                    p.Read(IdPagam)
                    ris = p.TipoPagam

                End Using

            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property SpedibileConBrt As Boolean
        Get
            Dim ris As Boolean = True
            'If Giorno < Date.Today Then
            '    ris = False
            'Else
            If HaSoloOrdiniProntiConsegna = False And Forzata = False Then
                ris = False
            Else
                If IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
                    ris = False
                Else
                    If Corriere.IdCorriere <> enCorriere.Bartolini And Corriere.IdCorriere <> enCorriere.PortoAssegnatoBartolini Then
                        ris = False
                    End If
                End If
            End If
            'End If
            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IConsegnaProgrammata.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IConsegnaProgrammata.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IConsegnaProgrammata.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class

Public Class ConsegnaRicerca
    Inherits ConsegnaProgrammata

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

    'CLASSE DI RICERCA PER LE CONSEGNE CHE INCLUDE LE CONSEGNE PREVISTE E PROGRAMMATE
    Private _Programmata As Boolean = True
    Public Property Programmata As Boolean
        Get
            Return _Programmata
        End Get
        Set(value As Boolean)
            _Programmata = value
        End Set
    End Property

    'Private _RagSoc As String = ""
    'Public Property RagSoc As String
    '    Get
    '        Return _RagSoc
    '    End Get
    '    Set(value As String)
    '        _RagSoc = value
    '    End Set
    'End Property

    'Private _CorriereNome As String = ""
    'Public Property CorriereNome As String
    '    Get
    '        Return _CorriereNome
    '    End Get
    '    Set(value As String)
    '        _CorriereNome = value
    '    End Set
    'End Property

    Public Overrides Function ToString() As String
        Dim ris As String = Cliente.RagSocNome & " - " & IndirizzoStr
        Return ris
    End Function

    Public ReadOnly Property DataConsPrevKey As String
        Get
            Return Giorno.ToString("ddMMyyyy")
        End Get
    End Property

    Public ReadOnly Property DataConsPrevShort As String
        Get
            Return Giorno.ToString("dd.MM.yy")
        End Get
    End Property

    Private _IdOrd As Integer = 0
    Public Property IdOrd As Integer
        Get
            Return _IdOrd
        End Get
        Set(value As Integer)
            _IdOrd = value
        End Set
    End Property

    Private _Inserito As Integer = 0
    Public Property Inserito As Integer
        Get
            Return _Inserito
        End Get
        Set(value As Integer)
            _Inserito = value
        End Set
    End Property

    Private _StatoOrdine As Integer = 0
    Public Property StatoOrdine As Integer
        Get
            Return _StatoOrdine
        End Get
        Set(value As Integer)
            _StatoOrdine = value
        End Set
    End Property

    Private _ProdottoNome As String = ""
    Public Property ProdottoNome As String
        Get
            Return _ProdottoNome
        End Get
        Set(value As String)
            _ProdottoNome = value
        End Set
    End Property

    Private _Ordine As Ordine = Nothing
    Public ReadOnly Property Ordine As Ordine
        Get
            If _Ordine Is Nothing Then
                _Ordine = New Ordine
                _Ordine.Read(IdOrd)
            End If
            Return _Ordine
        End Get
    End Property

End Class


''' <summary>
'''Interface for table T_cons
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IConsegnaProgrammata
    Inherits _IConsegnaProgrammata

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface