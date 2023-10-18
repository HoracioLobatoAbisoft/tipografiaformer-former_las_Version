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
Imports System.Drawing
Imports System.IO
Imports FormerLib
Imports FormerConfig
Imports System.Web
Imports FormerBusinessLogicInterface
''' <summary>
'''Entity Class for table T_ordini
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Ordine
    Inherits _Ordine
    Implements IOrdine, ICloneable

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

    Public Sub New()
        _DataIns = Now
        _Stato = enStatoOrdine.Preinserito
    End Sub

#Region "Logic Field"

    Public ReadOnly Property NomeGarante As String
        Get
            Dim ris As String = String.Empty

            If ConsegnaGarantita <> Date.MinValue Then
                Using u As New Utente
                    u.Read(ConsegnaGarantitaDa)
                    ris = u.NomeReale
                End Using
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property CouponUtilizzato As Coupon
        Get
            Dim ris As Coupon = Nothing
            If IdCoupon Then

                Using mgr As New CouponDAO
                    ris = mgr.Find(New LUNA.LunaSearchParameter(LFM.Coupon.IdCouponOnline, IdCoupon))
                End Using

            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property Fatturabile As Boolean
        Get
            Dim ris As Boolean = True

            'If VoceRubrica.NoCheckDatiFisc <> enSiNo.Si Then
            If Preventivo = enSiNo.No Then
                'se non è a preventivo
                If Not ConsegnaAssociata Is Nothing Then
                    If ConsegnaAssociata.TipoDoc <> enTipoDocumento.DDT Then
                        'If IdRub = 1136 Then Stop
                        If VoceRubrica.Fatturabile.Length Then
                            ris = False
                        End If
                    End If
                Else
                    ris = False
                End If
            End If

            'End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoRetroStr As String
        Get
            Dim ris As String = String.Empty

            If Not ListinoBase Is Nothing Then
                If ListinoBase.ColoreStampa.FR Then
                    ris = FormerEnumHelper.TipoRetroStr(TipoRetro)
                Else
                    ris = "Solo fronte"
                End If
            Else
                ris = "-"
            End If

            Return ris.ToUpper
        End Get
    End Property

    Public ReadOnly Property CalcoloSoluzioniIdFormatoProdotto As Integer
        Get
            Dim ris As Integer = 0
            If ForzaIdFormatoProdotto Then
                ris = ForzaIdFormatoProdotto
            Else
                If Not ListinoBase Is Nothing Then ris = ListinoBase.IdFormProd
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property CalcoloSoluzioniIdFormatoCarta As Integer
        Get
            Dim ris As Integer = 0
            If ForzaIdFormatoProdotto Then
                Using f As New FormatoProdotto
                    f.Read(ForzaIdFormatoProdotto)
                    ris = f.IdFormCarta
                End Using
            Else
                ris = ListinoBase.FormatoProdotto.IdFormCarta
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property CalcoloSoluzioniIdTipoCarta As Integer
        Get
            Dim ris As Integer = 0
            If ForzaIdTipoCarta Then
                ris = ForzaIdTipoCarta
            Else
                ris = ListinoBase.IdTipoCarta
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property CalcoloSoluzioniQTA As Integer
        Get
            Dim ris As Integer = 0
            If ForzaQta Then
                ris = ForzaQta
            Else
                ris = QtaOrdine
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property QtaOrdine As Integer
        Get
            Dim ris As Integer = 0
            ris = Qta 'Prodotto.NumPezzi
            Return ris
        End Get
    End Property

    Public Property ModificatiLavLog As Boolean = False

    Public ReadOnly Property Numero As Integer
        Get
            Return _IdOrd
        End Get
    End Property

    Private _IdListinoBase As Integer = 0 'MODIFICA PER FARE FUNZIONARE IL COSTRUTTORE DEGLI ORDINI ARCHIVIATI
    Public Property IdListinoBase As Integer
        Get

            Dim Ris As Integer = 0

            If _IdListinoBase Then
                Ris = _IdListinoBase
            Else
                Ris = Prodotto.IdListinoBase
            End If

            Return Ris
        End Get
        Set(value As Integer)
            _IdListinoBase = value
        End Set
    End Property

    Private _SorgenteCliente As String = "Nan"

    Public Property SorgenteCliente As String
        Get
            If _SorgenteCliente = "Nan" Then
                _SorgenteCliente = VoceRubrica.Sorgente
            End If
            Return _SorgenteCliente
        End Get
        Set(value As String)
            _SorgenteCliente = value
        End Set
    End Property

    Public ReadOnly Property DataInsStr As String
        Get
            Return _DataIns.ToString("dd.MM.yy HH:mm ")
        End Get
    End Property

    Public ReadOnly Property IdComStr As String
        Get
            If _IdCom Then
                Return _IdCom
            Else
                Return "-"
            End If
        End Get
    End Property

    Public ReadOnly Property Totale As Decimal
        Get
            Return TotaleFornitura
        End Get
    End Property

    Public ReadOnly Property ListExtraData As List(Of ExtraData)
        Get
            Dim l As New List(Of ExtraData)
            If ExtraData.Length Then
                For Each coppia As String In ExtraData.Split(";")
                    If coppia.Length Then
                        Dim Chiave As String = coppia.Substring(0, coppia.IndexOf(":"))
                        Dim Valore As String = coppia.Substring(coppia.IndexOf(":") + 1)
                        Dim E As New ExtraData
                        E.Chiave = Chiave
                        E.Valore = Valore
                        l.Add(E)
                    End If
                Next
            End If

            Return l
        End Get
    End Property

    Public ReadOnly Property TotaleStrEx As String
        Get
            Dim ris As String = String.Empty

            If OrdineInOmaggio = enSiNo.Si Then
                ris = "OMAGGIO"
            Else
                ' Dim totale As Decimal = _TotaleForn + _Ricarico - _Sconto
                ris = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Totale)
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property TotaleStr As String
        Get
            Dim ris As String = TotaleStrEx 'String.Empty

            ' Dim totale As Decimal = _TotaleForn + _Ricarico - _Sconto
            'ris = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(totale)

            Return ris
        End Get
    End Property

    Public ReadOnly Property TotaleFornitura As Decimal
        Get
            Dim totale As Decimal = _TotaleForn + _Ricarico - _Sconto
            Return totale
        End Get
    End Property

    Public ReadOnly Property DocumentoFiscale As Ricavo
        Get
            'questa puo essere nothing!!!
            Dim ris As Ricavo = Nothing
            If IdDoc Then
                ris = New Ricavo
                ris.Read(IdDoc)
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property InseritoNelPacco As Boolean
        Get
            Dim ris As Boolean = False

            Using mgr As New ConsProgrOrdiniDAO
                Dim ls As List(Of ConsProgrOrdini) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", IdOrd))
                If ls.Count Then
                    ris = ls(0).Inserito
                End If
            End Using

            Return ris
        End Get
    End Property

    Private _ListinoBase As ListinoBase = Nothing
    Public ReadOnly Property ListinoBase As ListinoBase
        Get
            If _ListinoBase Is Nothing Then
                If IdListinoBase Then
                    _ListinoBase = New ListinoBase
                    _ListinoBase.Read(IdListinoBase)
                End If
            End If
            Return _ListinoBase
        End Get
    End Property

    Private _ModelloCubettoScelto As ModelloCubetto = Nothing
    Public ReadOnly Property ModelloCubettoScelto As ModelloCubetto
        Get
            If Not ListinoBase Is Nothing Then
                If ListinoBase.IdModelloCubetto Then
                    If _ModelloCubettoScelto Is Nothing Then

                        _ModelloCubettoScelto = New ModelloCubetto
                        _ModelloCubettoScelto.Read(ListinoBase.IdModelloCubetto)

                    End If
                End If

            End If

            Return _ModelloCubettoScelto
        End Get
    End Property

    Public ReadOnly Property IcoTipo As Image
        Get
            Dim ris As Image = Nothing
            Select Case _TipoConsegna
                Case enTipoConsegna.Normale
                    ris = My.Resources.iconormal
                Case enTipoConsegna.Fast
                    ris = My.Resources.icofast
                Case enTipoConsegna.Slow
                    If IdPromo Then
                        ris = My.Resources.icopromo
                    Else
                        ris = My.Resources.icolow
                    End If

            End Select
            Return ris
        End Get
    End Property

    Public ReadOnly Property IdCons As Integer
        Get
            Dim Ris As Integer = 0

            Using mgr As New ConsProgrOrdiniDAO

                Dim cons As ConsProgrOrdini = mgr.Find(New LUNA.LunaSearchParameter(LFM.ConsProgrOrdini.IdOrd, IdOrd))
                If Not cons Is Nothing Then Ris = cons.IdCons

            End Using

            Return Ris

        End Get
    End Property

    Public ReadOnly Property QtaRifStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaNumero(QtaRif)
        End Get
    End Property

    Public ReadOnly Property QtaRif As Integer
        Get
            'MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
            'Dim Ris As Integer = Prodotto.NumPezzi

            'If Not Prodotto.ListinoBase Is Nothing Then
            '    If Prodotto.ListinoBase.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            '        Ris = Qta
            '    ElseIf Prodotto.ListinoBase.TipoPrezzo = enTipoPrezzo.SuCopie Then
            '        Ris = Qta
            '    End If
            'End If

            'Return Ris
            Dim Ris As Integer = QtaOrdine
            Return Ris

        End Get
    End Property

    Public ReadOnly Property DataConsPrevShort As String
        Get
            Return _DataPrevConsegna.ToString("dd.MM.yy")
        End Get
    End Property

    Public ReadOnly Property DataConsPrevStr As String
        Get
            Return _DataPrevConsegna.ToString("dd.MM.yy")
        End Get
    End Property

    Public ReadOnly Property DataConsPrevKey As String
        Get
            Return _DataPrevConsegna.ToString("ddMMyyyy")
        End Get
    End Property

    Private _NumeroMessaggi As Integer = 0
    Public Property NumeroMessaggi As Integer
        Get
            Return _NumeroMessaggi
        End Get
        Set(value As Integer)
            _NumeroMessaggi = value
        End Set
    End Property

    Public ReadOnly Property IcoMsg As Image
        Get
            If ConsegnaGarantita <> Date.MinValue Then
                Return My.Resources._DataGarantita26
            Else
                If _NumeroMessaggi Then
                    Return My.Resources.attach
                Else
                    Return My.Resources.blank
                End If
            End If

        End Get
    End Property

    Public Sub SvuotaConsegnaAssociata()
        _ConsegnaAssociata = Nothing
    End Sub

    Public ReadOnly Property CorriereStr As String
        Get
            Dim ris As String = String.Empty

            ris = ConsegnaAssociata.Corriere.Descrizione

            Return ris
        End Get
    End Property

    Private _ConsegnaAssociata As ConsegnaProgrammata = Nothing
    Public ReadOnly Property ConsegnaAssociata As ConsegnaProgrammata
        Get
            If _ConsegnaAssociata Is Nothing Then

                Using mgr As New ConsProgrOrdiniDAO

                    Dim l As List(Of ConsProgrOrdini) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsProgrOrdini.IdOrd, IdOrd))

                    If l.Count Then

                        Dim IdConsProgr As Integer = l(0).IdCons

                        _ConsegnaAssociata = New ConsegnaProgrammata
                        _ConsegnaAssociata.Read(IdConsProgr)

                    End If

                End Using

            End If

            Return _ConsegnaAssociata
        End Get
    End Property

    Private _Commessa As Commessa = Nothing
    Public ReadOnly Property Commessa As Commessa
        Get
            If _Commessa Is Nothing AndAlso IdCom <> 0 Then
                _Commessa = New Commessa
                _Commessa.Read(IdCom)
            End If

            Return _Commessa
        End Get
    End Property

    Public ReadOnly Property PrioritaStr As String
        Get
            Dim Ris As String = ""
            If Priorita = enSiNo.Si Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property StatoStr As String
        Get
            Dim stOrd As enStatoOrdine = _Stato
            Dim IdCorr As Integer = 0
            If Not ConsegnaAssociata Is Nothing Then
                IdCorr = ConsegnaAssociata.IdCorr
            Else
                IdCorr = IdCorriere
            End If

            Dim ris As String = String.Empty

            Dim StatoLav As String = String.Empty

            If _Stato = enStatoOrdine.StampaFine Or
                _Stato = enStatoOrdine.FinituraCommessaInizio Or
                _Stato = enStatoOrdine.FinituraProdottoInizio Then
                For Each singlav As LavLog In ListaLavLogCompleta

                    If singlav.DataOraInizio = Date.MinValue Then
                        StatoLav = "In attesa di " & singlav.LavorazioneStr
                    ElseIf singlav.DataOraFine = Date.MinValue Then
                        StatoLav = singlav.LavorazioneStr
                    End If

                    If StatoLav.Length Then Exit For

                Next
            End If

            If _Stato = enStatoOrdine.StampaFine Then
                If StatoLav.Length Then
                    ris = StatoLav
                Else
                    ris = FormerEnumHelper.StatoOrdineString(stOrd, , IdCorr)
                End If
            ElseIf _Stato = enStatoOrdine.FinituraCommessaInizio Then
                If StatoLav.Length Then
                    ris = StatoLav
                Else
                    ris = FormerEnumHelper.StatoOrdineString(stOrd, , IdCorr)
                End If
            ElseIf _Stato = enStatoOrdine.FinituraProdottoInizio Then
                If StatoLav.Length Then
                    ris = StatoLav
                Else
                    ris = FormerEnumHelper.StatoOrdineString(stOrd, , IdCorr)
                End If
            Else
                ris = FormerEnumHelper.StatoOrdineString(stOrd, , IdCorr)
            End If

            Return ris

        End Get
    End Property

    Private _StatoColore As Color = Color.Transparent
    Public ReadOnly Property StatoColore As Color
        Get
            If _StatoColore = Color.Transparent Then
                _StatoColore = FormerColori.GetColoreStatoOrdine(_Stato)
            End If
            Return _StatoColore

        End Get
    End Property

    Public ReadOnly Property StatoColoreHTML As String
        Get
            Dim statoCol As String = ""
            statoCol = ColorTranslator.ToHtml(FormerColori.GetColoreStatoOrdine(_Stato))
            Return statoCol

        End Get
    End Property

    Public Property UsaLavorazioniDefault As Boolean = False
    Public Property ListaLavorazioniCustom As Integer()

    Private _Lavorazioni As String = String.Empty
    Public ReadOnly Property Lavorazioni As String
        Get
            Dim Ris As String = String.Empty
            If _Lavorazioni.Length Then
                Using LMgr As New LavLogDAO
                    Dim l As List(Of LavLog) = LMgr.FindAll(New LUNA.LunaSearchParameter("IdOrdine", _IdOrd))

                    For Each sl As LavLog In l
                        Ris &= sl.Idlav & ","
                    Next

                End Using
                Ris = Ris.TrimEnd(",")
            End If

            Return Ris

        End Get
    End Property

    Private _ListaLavLogCompleta As List(Of LavLog) = Nothing
    Public ReadOnly Property ListaLavLogCompleta As List(Of LavLog)
        Get
            If _ListaLavLogCompleta Is Nothing Then
                Using mgr As New LavLogDAO()
                    Dim PCom As LUNA.LunaSearchParameter = Nothing

                    If IdCom Then
                        PCom = New LUNA.LunaSearchParameter("IdCom", IdCom,, LUNA.enLogicOperator.enOR)
                    End If

                    _ListaLavLogCompleta = mgr.FindAll("Ordine",
                                                        New LUNA.LunaSearchParameter("IdOrd", IdOrd),
                                                        PCom)

                End Using
            End If
            Return _ListaLavLogCompleta
        End Get
    End Property

    'RELAZIONE INDIRETTA
    Private _ListLavLog As List(Of LavLog) = Nothing
    <XmlElementAttribute("ListLavLog")>
    Public Property ListLavLog() As List(Of LavLog)
        Get
            If _ListLavLog Is Nothing Or LUNA.LunaContext.DisableLazyLoading = True Then
                Using Mgr As New LavLogDAO
                    Dim Param1 As New LUNA.LunaSearchParameter("IdOrd", _IdOrd)
                    _ListLavLog = Mgr.FindAll("Ordine", Param1)
                End Using
            End If
            Return _ListLavLog
        End Get
        Set(ByVal value As List(Of LavLog))
            _ListLavLog = value
        End Set
    End Property

    Private _ListaLavori As List(Of Lavorazione) = Nothing
    Public ReadOnly Property ListaLavori As List(Of Lavorazione)
        Get
            If _ListaLavori Is Nothing Then
                Using mgr As New LavorazioniDAO
                    _ListaLavori = mgr.ListaLavorazioni(IdOrd)
                End Using
            End If
            Return _ListaLavori
        End Get
    End Property

    Public Function CalcolaDataConsegna(Optional ByVal TipoConsegnaForzata As Integer = -1,
                                        Optional ByVal IdProdotto As Integer = -1,
                                        Optional ByVal IdCorr As Integer = -1) As Date

        'qui devo calcolare la data di consegna prevista in base ai parametri presenti nell'ordine
        'questa funzione viene chiamata solo in fase di inserimento e scaricamento automatico dell'ordine
        Dim DataPrevistaConsegna As Date = Now.Date.AddDays(3)
        Dim VarProd As Integer = _IdProd
        Dim VarCorr As Integer = _IdCorriere
        If IdProdotto <> -1 Then VarProd = IdProdotto
        If IdCorr <> -1 Then VarCorr = IdCorr

        If VarProd <> 0 And VarCorr <> 0 Then

            Dim Prod As New Prodotto
            Prod.Read(VarProd)

            If Prod.GGNormale Then

                'Dim Corr As New Corriere

                'Corr.Read(VarCorr)
                Dim GGCorr As Integer = 0 ' Corr.GGConsegna
                'Corr = Nothing

                DataPrevistaConsegna = Now.Date.AddDays(GGCorr)
                Dim VarTipo As Integer = _TipoConsegna
                If TipoConsegnaForzata <> -1 Then VarTipo = TipoConsegnaForzata

                Select Case VarTipo
                    Case enTipoConsegna.Normale
                        DataPrevistaConsegna = DataPrevistaConsegna.AddDays(Prod.GGNormale - 1)
                    Case enTipoConsegna.Fast
                        DataPrevistaConsegna = DataPrevistaConsegna.AddDays(Prod.GGFast - 1)
                    Case enTipoConsegna.Slow
                        DataPrevistaConsegna = DataPrevistaConsegna.AddDays(Prod.GGLow - 1)

                End Select
                'qui devo anche calcolare che se c'e' una domenica di mezzo devo aggiungere un altro giorno

                If Now.Hour >= 13 Then DataPrevistaConsegna = DataPrevistaConsegna.AddDays(1)

                Dim DomenicheTrovate As Integer = TrovaDomeniche(DataPrevistaConsegna)
                DataPrevistaConsegna = DataPrevistaConsegna.AddDays(DomenicheTrovate)

                If DataPrevistaConsegna.DayOfWeek = DayOfWeek.Sunday Then DataPrevistaConsegna = DataPrevistaConsegna.AddDays(1)

            End If
        End If
        Return DataPrevistaConsegna

    End Function

    Public ReadOnly Property TipoImballo As Integer
        Get
            Dim Ris As Integer = Prodotto.TipoImballo

            Return Ris
        End Get
    End Property

    Public ReadOnly Property NumeroColliCalcolatiStr As String
        Get
            Dim Ris As String = "?"

            If NumeroColliCalcolati Then
                Ris = NumeroColliCalcolati
            End If

            Return Ris
        End Get
    End Property

    Public ReadOnly Property ImgAnteprima As Image
        Get
            Dim ImgPreview As Image
            Dim PathRiferimento As String = FilePath
            Dim ImgNew As Image = Nothing

            If Not ListinoBase Is Nothing AndAlso ListinoBase.NoAttachFile = enSiNo.Si Then
                ImgNew = FormerThumbnail.GetForOrdineCommessa(ListinoBase.FormatoProdotto.Img)
            Else
                Dim PathLocaleImg As String = FormerPath.PathTempImg & "O" & FormerHelper.File.EstraiNomeFile(PathRiferimento)

                If FileIO.FileSystem.FileExists(PathLocaleImg) Then
                    Try
                        ImgNew = Image.FromFile(PathLocaleImg)
                    Catch ex As Exception

                    End Try
                Else
                    Try
                        If FileIO.FileSystem.FileExists(FilePath) Then
                            ImgPreview = Image.FromFile(FilePath)

                            ImgNew = FormerThumbnail.GetForOrdineCommessa(ImgPreview)
                        End If
                    Catch ex As Exception
                        ImgNew = Nothing
                    End Try

                    If Not ImgNew Is Nothing Then
                        Try
                            ImgNew.Save(PathLocaleImg)
                        Catch ex As Exception

                        End Try
                    End If

                End If
            End If

            If ImgNew Is Nothing Then ImgNew = New Bitmap(My.Resources.no_image, New Size(75, 50))

            Return ImgNew
        End Get
    End Property

    Public ReadOnly Property ImgTipoImballo As Image
        Get
            Dim Img As Image = Nothing

            Select Case TipoImballo
                Case enTipoImballo.Fascette
                    Img = My.Resources.icoImballoFascette
                Case enTipoImballo.Termoretraibile
                    Img = My.Resources.icoImballoTermo
                Case enTipoImballo.Scatola
                    Img = My.Resources.icoImballoScatola
            End Select

            Return Img

        End Get
    End Property

    Public ReadOnly Property NumeroColliCalcolati() As Integer
        Get
            Dim Ris As Integer = 0
            Dim QtaRiferimento As Integer = 1

            If Prodotto.QtaCollo Then QtaRiferimento = Prodotto.QtaCollo

            Select Case TipoImballo
                Case enTipoImballo.Fascette
                    Ris = Math.Ceiling(QtaRif / QtaRiferimento)
                Case enTipoImballo.Termoretraibile
                    Ris = Math.Ceiling(QtaRif / QtaRiferimento)
                Case enTipoImballo.Scatola
                    Ris = QtaRiferimento
            End Select

            Return Ris
        End Get
    End Property

    Private Function TrovaDomeniche(ByVal DataFinale As Date) As Integer

        Dim Ris As Integer = 0
        Dim dataIn As Date = Now
        While DataFinale >= dataIn

            If dataIn.DayOfWeek = DayOfWeek.Sunday Then Ris += 1
            dataIn = dataIn.AddDays(1)
        End While

        Return Ris

    End Function

    Public Function CalcolaPrezzo(ByVal Prezzo As Decimal, ByVal PercFast As Integer, ByVal PercLow As Integer) As Decimal
        Dim PrezzoRif As Decimal
        PrezzoRif = Prezzo

        If _TipoConsegna = enTipoConsegna.Fast Then
            PrezzoRif += PrezzoRif * PercFast / 100
        End If
        If _TipoConsegna = enTipoConsegna.Slow Then
            PrezzoRif -= PrezzoRif * PercLow / 100
        End If
        Return PrezzoRif
    End Function

    'Public Overrides Function Save() As Integer

    '    Return MyClass.Save()

    '    Stop
    'End Function

    Public ReadOnly Property TotaleImponibile() As Decimal
        Get
            Return _TotaleForn + _Ricarico - _Sconto
        End Get
    End Property

    Public ReadOnly Property ListaFileAllegati As List(Of FileAllegato)
        Get
            Dim l As List(Of FileAllegato) = Nothing
            Using mgr As New FileAllegatiDAO
                l = mgr.FindAll(LFM.FileAllegato.FilePath,
                                New LUNA.LunaSearchParameter(LFM.FileAllegato.IdOrd, IdOrd))
            End Using
            Return l
        End Get
    End Property

    Public ReadOnly Property ListaSorgenti As List(Of FileSorgente)
        Get
            Dim l As List(Of FileSorgente) = Nothing
            Using mgr As New FileSorgentiDAO
                l = mgr.FindAll(LFM.FileSorgente.NumPagina, New LUNA.LunaSearchParameter(LFM.FileSorgente.IdOrd, IdOrd))
            End Using
            Return l
        End Get
    End Property

    'Public ReadOnly Property CreaRiepilogo() As String
    '    Get
    '        Dim bufferHtml As String = ""

    '        Dim _ordsel As Ordine = Me

    '        'bufferHtml = "<html><head><meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8""><TITLE>Riepilogo</TITLE><style>BODY {font-family: 'Segoe UI';}</style></HEAD><BODY BGCOLOR=""WHITE""><FONT SIZE=1 face=Arial>" & ControlChars.NewLine

    '        'qui carico se ha immagini e in caso faccio il box incorniciato

    '        bufferHtml &= "<font size=4><center>Riepilogo Ordine</center></font><br><br>"

    '        bufferHtml &= "Prodotto <br>"

    '        Using p As New Prodotto
    '            p.Read(_ordsel.IdProd)

    '            bufferHtml &= "<FONT SIZE=6>" & p.Descrizione

    '            If _ordsel.ListinoBase.FormatoProdotto.Orientabile = enSiNo.Si Then
    '                bufferHtml &= " Orientamento:" & FormerEnumHelper.OrientamentoStr(_ordsel.Orientamento)
    '            End If

    '            bufferHtml &= "<BR><BR>"

    '            If p.IdFormato Then
    '                Dim ImgRifF As String = p.FormatoProdotto.ImgRif
    '                bufferHtml &= "<IMG SRC=""" & ImgRifF & """> "
    '            End If

    '            If p.IdTipoCarta Then
    '                Dim ImgRifT As String = p.TipoCarta.ImgRif
    '                bufferHtml &= "<IMG SRC=""" & ImgRifT & """> "
    '            End If

    '        End Using

    '        bufferHtml &= "<TABLE WIDTH=100%>"
    '        bufferHtml &= "<TR>"
    '        bufferHtml &= "<TD VALIGN=Top width=50%>"
    '        bufferHtml &= "<FONT Face=Arial>"

    '        bufferHtml &= "<FONT SIZE=1> Data: <FONT SIZE=3><b>" & _ordsel.DataIns & "</b></FONT><BR><BR>"
    '        bufferHtml &= "Ordine N: <FONT SIZE=6>" & _ordsel.Numero & "</FONT><BR><BR>"
    '        bufferHtml &= "Nome file originale: <FONT SIZE=3><b>" & _ordsel.NomeFileOriginale.ToString & "</b></FONT><BR><BR>"
    '        'bufferHtml &= "Ordine Email: <FONT SIZE=3><b>" & IIf(_ordsel.OrdMail, "SI", "NO") & "</b></FONT><BR><BR>"


    '        Dim cli As New VoceRubrica
    '        cli.Read(_ordsel.IdRub)

    '        bufferHtml &= "Cliente:<BR> <FONT SIZE=3><B>" & IIf(cli.RagSocNome.Length, cli.RagSocNome & "<BR>", "") & IIf(cli.Cognome.Length, cli.Cognome & " " & cli.Nome & "<BR>", "") & cli.Indirizzo & "<BR>" & cli.Tel & "</B></FONT><BR><BR>"

    '        'qui carico i dettagli delle lavorazioni per questo ordine

    '        ' Dim x As New cLavoriColl
    '        'Dim Dt As DataTable, Dr As DataRow
    '        bufferHtml &= "Lavorazioni:<BR> <FONT SIZE=3>"

    '        'Dt = x.ListaLavoriOrd(_ordsel.IdOrd)

    '        For Each ll As LavLog In _ordsel.ListLavLog
    '            Dim PathImg As String
    '            Dim Lavoro As New LavorazioneEx
    '            Lavoro.Read(ll.Idlav)
    '            If Lavoro.ImgRifLocale.Length AndAlso File.Exists(Lavoro.ImgRifLocale) Then
    '                PathImg = Lavoro.ImgRifLocale
    '            Else
    '                PathImg = Lavoro.ImgRif
    '            End If

    '            bufferHtml &= "<IMG SRC=""" & PathImg & """ width=""32"" ALIGN=""ABSMIDDLE""> - <B>" & ll.Descrizione & "</B><BR>"

    '        Next

    '        bufferHtml &= RiepilogoExtraData()

    '        bufferHtml &= "</FONT><BR><BR>"

    '        If _ordsel.OrdineInOmaggio = enSiNo.Si Then
    '            bufferHtml &= "<br><b style=""font-size:14px;background-color:#850c70;color:white;"">OMAGGIO</b><br><br>"
    '        End If

    '        bufferHtml &= "Condizioni economiche:<BR><TABLE width=200>"

    '        bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Prezzo </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_ordsel.Totale) & "</B></FONT><BR></TD></TR>"
    '        bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Qta </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & _ordsel.Qta & "</B></FONT><BR></TD></TR>"
    '        bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Totale Fornitura </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_ordsel.TotaleForn) & "</B></FONT><BR></TD></TR>"
    '        bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Iva </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_ordsel.Iva) & "</B></FONT><BR></TD></TR>"
    '        bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Corriere </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_ordsel.CostoSped) & "</B></FONT><BR></TD></TR>"
    '        bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Sconto </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_ordsel.Sconto) & "</B></FONT><BR></TD></TR>"
    '        bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Ricarico </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_ordsel.Ricarico) & "</B></FONT><BR></TD></TR>"
    '        bufferHtml &= "<TR><TD><FONT FACE=Arial><FONT SIZE=3>TOT. ORDINE </TD><TD align=right><FONT FACE=Arial><FONT SIZE=5><B>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_ordsel.TotaleStr) & "</B></FONT><BR></TD></TR>"
    '        If _ordsel.IdPromo Then
    '            bufferHtml &= "<TR><TD colspan=2><div style=""background-color:#009ec9;border-radius:3px;padding:2px;color:white;"">Promo " & _ordsel.IdPromo & "%</div></TD></TR>"
    '        End If

    '        If _ordsel.IdCoupon Then
    '            bufferHtml &= "<TR><TD colspan=2><div style=""background-color:#1aaf5d;border-radius:3px;padding:2px;color:white;"">Coupon di sconto</div></TD></TR>"
    '        End If

    '        bufferHtml &= "</TABLE>"
    '        bufferHtml &= "</FONT>"
    '        bufferHtml &= "</TD>"
    '        bufferHtml &= "<TD VALIGN=Top width=50%><IMG SRC=""" & _ordsel.FilePath & """ WIDTH=400>"
    '        bufferHtml &= "</TD>"

    '        bufferHtml &= "</TR>"
    '        bufferHtml &= "</TABLE>"

    '        'bufferHtml &= "</BODY></HTML>" & ControlChars.NewLine

    '        Return bufferHtml
    '    End Get
    'End Property

    Public ReadOnly Property CreaRiepilogoStatoLavori() As String
        Get

            Dim bufferHtml As String = ""

            Dim _ordsel As Ordine = Me
            'bufferHtml = "<HTML><HEAD><TITLE>Stato Lavorazioni</TITLE></HEAD><BODY BGCOLOR=""WHITE"">"
            'bufferHtml = "<br>" & ControlChars.NewLine
            Try
                Using mgr As New LavLogDAO
                    Dim PCom As LUNA.LunaSearchParameter = Nothing

                    If _ordsel.IdCom Then
                        PCom = New LUNA.LunaSearchParameter(LFM.LavLog.IdCom, _ordsel.IdCom,, LUNA.enLogicOperator.enOR)
                    End If

                    Dim l As List(Of LavLog) = mgr.FindAll(LFM.LavLog.Ordine,
                                                           New LUNA.LunaSearchParameter(LFM.LavLog.IdOrd, _ordsel.IdOrd),
                                                           PCom)

                    l.Sort(AddressOf FormerListSorter.LavLogSorter.SortPerAnteprima)

                    bufferHtml &= "<div class=""divTable divOperatore""><table>"
                    bufferHtml &= "<tr style=""background-color:#EDEDED;""><td height=25>&nbsp;</td><td>&nbsp;</td><td><b>QUANDO</td><td><b>LAVORAZIONE/FASE</td><td><b>MIN</b></td></tr>"

                    For Each singLav As LavLog In l
                        bufferHtml &= "<tr>"
                        bufferHtml &= "<td width=25 height=25 "

                        If singLav.Lavorazione.Categoria.TipoCaratteristica <> enSiNo.Si Then
                            If singLav.DataOraInizio <> Date.MinValue Then
                                bufferHtml &= " style=""background-color:green;"""
                            Else
                                bufferHtml &= " style=""background-color:red;"""
                            End If
                        End If

                        bufferHtml &= ">"
                        bufferHtml &= "</td>"
                        bufferHtml &= "<td width=25 height=25 "
                        If singLav.Lavorazione.Categoria.TipoCaratteristica <> enSiNo.Si Then
                            If singLav.DataOraFine <> Date.MinValue Then
                                bufferHtml &= " style=""background-color:green;"""
                            Else
                                bufferHtml &= " style=""background-color:red;"""
                            End If
                        End If
                        bufferHtml &= ">"
                        bufferHtml &= "</td>"

                        bufferHtml &= "<td align=left valign=center style=""background-color:white;"">"

                        If singLav.DataOraFine <> Date.MinValue Then
                            bufferHtml &= singLav.DataOraFine.ToString("HH:mm.ss dd/MM/yyyy")
                        ElseIf singLav.DataOraInizio <> Date.MinValue Then
                            bufferHtml &= singLav.DataOraInizio.ToString("HH:mm.ss dd/MM/yyyy")
                        Else
                            bufferHtml &= "<i>da effettuare</i>"
                        End If

                        bufferHtml &= "&nbsp;"

                        bufferHtml &= "</td><td align=left valign=center style=""background-color:white;"">"

                        bufferHtml &= singLav.LavorazioneStr

                        bufferHtml &= "</td><td align=right valign=center style=""background-color:white;"">"

                        bufferHtml &= singLav.Tempo

                        bufferHtml &= "</td>"

                        bufferHtml &= "</tr>"
                    Next

                    bufferHtml &= "</table></div>"

                End Using
            Catch ex As Exception

            End Try

            'bufferHtml &= "</body></html>" & ControlChars.NewLine

            Return bufferHtml

        End Get
    End Property

    Public Sub InviaMailPresoInCarico()

        Dim SoggettoMail As String = "Conferma presa in carico Lavoro numero: " & IdOrd
        Dim TestoMail As String = ""
        Dim Attach As String = ""
        Dim MailDest As String = ""

        'mi trvo la mail del destinatario

        MailDest = VoceRubrica.Email.ToString
        'MailDest = "soft@tipografiaformer.it"

        If MailDest.Length Then

            TestoMail = "Siamo lieti di confermarle che il suo lavoro numero <b>" & IdOrd & "</b> del " & DataIns & "<br><br>"

            TestoMail &= "è stato preso in carico.<br><br>"

            TestoMail &= "La informiamo che il " & ConsegnaAssociata.Giorno.ToString("dd/MM/yyyy") & " il materiale sarà pronto per "

            If IdCorriere Then
                Using corr As New Corriere
                    corr.Read(IdCorriere)
                    TestoMail &= corr.TestoMail
                End Using
            Else
                TestoMail &= " essere ritirato presso la nostra sede di Roma. "
            End If

            TestoMail &= "<br><br><table style=""padding:10px 20px 10px 20px;width:500px;heigth:50px;border-radius:5px;background-color:#f1f1f1;font-weight:bold;""><tr><td><img src=""http://www.tipografiaformer.it/img/icoLavoro20.png""> <a href=""http://www.tipografiaformer.it/" & IdOrdOnline & "/dettaglio-lavoro"" style=""color:#2b2b2b;"">Clicca qui e vai al dettaglio del lavoro</a></td></tr></table>"

            Attach = FilePath

            FormerHelper.Mail.InviaMail(SoggettoMail, TestoMail, MailDest, , , Attach)
        End If

    End Sub

    Public Sub InviaMailCambioStato()

        If Stato > enStatoOrdine.Registrato Then

            Dim SoggettoMail As String = "Lavoro N° " & IdOrd & " " & StatoStr '"Aggiornamento stato Lavoro numero: " & IdOrd
            Dim TestoMail As String = ""
            Dim Attach As String = ""
            Dim MailDest As String = ""

            'mi trvo la mail del destinatario

            MailDest = VoceRubrica.Email.ToString

            If MailDest.Length Then

                TestoMail = "Siamo lieti di informarla che il suo lavoro numero <b>" & IdOrd & "</b> del " & DataIns & "<br><br>"

                TestoMail &= "è passato allo stato <b>" & StatoStr & "</b><br><br>"

                If Stato = enStatoOrdine.ProntoRitiro Then
                    If IdCorriere Then
                        TestoMail &= "Il materiale è pronto per "
                        Using corr As New Corriere
                            corr.Read(IdCorriere)
                            TestoMail &= corr.TestoMail
                        End Using
                        TestoMail &= "<br><br>"
                    End If

                End If

                Dim Cid As String = FormerHelper.File.EstraiNomeFile(FilePath)

                TestoMail &= "<table style=""padding:10px 20px 10px 20px;heigth:50px;width:500px;border-radius:5px;background-color:#f1f1f1;font-weight:bold;""><tr><td><a href=""http://www.tipografiaformer.it/" & IdOrdOnline & "/dettaglio-lavoro"" style=""color:#2b2b2b;""><img src=""cid:" & Cid & """ width=""100"" align=middle> CLICCA QUI e vai al dettaglio del lavoro</a></td></tr></table>"

                'TestoMail &= "Cordiali saluti" & ControlChars.NewLine & ControlChars.NewLine
                'TestoMail &= "Tipografia FORMER " & ControlChars.NewLine
                'TestoMail &= "tel 06.30884057" & ControlChars.NewLine
                'TestoMail &= "info@tipografiaformer.com" & ControlChars.NewLine
                'TestoMail &= "http://www.tipografiaformer.it" & ControlChars.NewLine

                Attach = FilePath

                FormerHelper.Mail.InviaMail(SoggettoMail, TestoMail, MailDest, , , Attach)

            End If
        End If

    End Sub

    Public Function RiepilogoExtraData() As String

        Dim ris As String = String.Empty

        For Each Dato As ExtraData In ListExtraData

            ris &= Dato.Chiave.ToUpper & ": <b>" & Dato.Valore & "</b><br>"

        Next

        'If ris.Length Then
        '    ris = "<div>INFORMAZIONI EXTRA<br><br>" & ris & "</div>"
        'End If

        Return ris

    End Function

    Public ReadOnly Property CreaRiepilogoCommessa As String
        Get
            Dim ris As String = String.Empty
            Dim bufferHtml As String = String.Empty
            If IdCom Then
                bufferHtml &= "<br><br><div class=""divOperatore"" style=""font-size:16px;"">Inserito in <h4>Commessa " & Commessa.IdCom & "</h4>"
                bufferHtml &= "<div style=""text-align:center;background-color:" & Commessa.StatoColoreHTML & ";""><b>" & Commessa.StatoStr & "</b></div>"

                bufferHtml &= "</center>"
                bufferHtml &= "<img src=""" & FormerPathCreator.GetAnteprima(Commessa) & """>"
                bufferHtml &= "</center>"
                ris = bufferHtml
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property CreaRiepilogo(Optional Operatore As Boolean = False) As String
        Get
            Dim bufferHtml As String = ""

            Dim _ordsel As Ordine = Me

            'bufferHtml = "<html><head><title>Riepilogo</title><style>body {font-family: 'Tahoma';}</style>"
            'bufferHtml &= "</head><body bgcolor=""WHITE""><font size=1>" & ControlChars.NewLine

            'qui carico se ha immagini e in caso faccio il box incorniciato

            '            bufferHtml &= "<FONT SIZE=4><CENTER>Riepilogo Ordine</CENTER></FONT><BR><BR>"

            Dim cli As New VoceRubrica
            cli.Read(_ordsel.IdRub)
            Dim p As New Prodotto
            p.Read(_ordsel.IdProd)

            bufferHtml &= "<div class=""divOperatore""><h4 style='color:#850c70;background-color:white;padding:3px;'>" & cli.RagSocNome & "</h4><b>"
            bufferHtml &= "<b> - " & FormerEnumHelper.TipoRubricaStr(cli.Tipo, cli.IsFornitore).ToUpper & "</b><br>"
            If cli.RagSoc.Length Then
                bufferHtml &= IIf(cli.Cognome.Length, cli.Cognome & " " & cli.Nome & "<br>", "")
            End If
            bufferHtml &= " (Id " & cli.IdRub & ") </b><br>" &
                cli.Indirizzo & " " & cli.CAP & " " & cli.Citta & "<br>" &
                "Tel. <b>" & cli.Tel & IIf(cli.TelRif.Length, " (" & cli.TelRif & ")", "") & "</b><br>"
            If cli.Cellulare.Length Then
                bufferHtml &= "Cel.<b>" & cli.Cellulare & IIf(cli.CellulareRif.Length, " (" & cli.CellulareRif & ")", "") & "</b><br> "
            End If
            If cli.AltroTel.Length Then
                bufferHtml &= "Altro Tel.<b>" & cli.AltroTel & IIf(cli.AltroTelRif.Length, " (" & cli.AltroTelRif & ")", "") & "</b><br> "
            End If

            bufferHtml &= "<a href=""mailto:" & cli.Email & """>" & cli.Email & "</a><br>" &
                "P.Iva " & cli.PivaEx & "<br>"

            Dim LrisTSC As List(Of RisSituazioneCliente) = MgrSituazioneCliente.GetSituazioneClienti(cli.IdRub)
            If LrisTSC.Count Then
                Dim risTSC As RisSituazioneCliente = LrisTSC(0)

                If Not risTSC.UltimoPagamento Is Nothing Then
                    bufferHtml &= "UP: <b>" & risTSC.UltimoPagamento.ImportoStr & "</b> del <b>" & risTSC.UltimoPagamento.DataPag.ToString("dd/MM/yyyy") & "</b>"
                Else
                    bufferHtml &= "UP: "
                End If

                bufferHtml &= " - TSC: <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(risTSC.TotaleScopertoComplessivo) & "</b>"
            Else
                bufferHtml &= "UP: - TSC: -"
            End If

            bufferHtml &= " </div>" ' & " <br><font size=1>Chiave </FONT>" & cli.CalcolaChiave & "<br>" & _
            '"<font size=1>Pagamento </FONT>" & cli.Pagamento & "<bR><font size=1>Corriere </FONT>" & Corr.Descrizione & "</FONT><BR><BR>"

            bufferHtml &= "<div Class=""divOperatore""><h4>Ordine " & _ordsel.Numero & " (Id Online " & _ordsel.IdOrdOnline & ")</h4>"
            bufferHtml &= "<div style=""text-align:center;background-color:" & _ordsel.StatoColoreHTML & ";""><b>" & _ordsel.StatoStr & "</b></div>"
            If Not _ordsel.ListinoBase Is Nothing Then
                bufferHtml &= "PRODOTTO: <b>" & _ordsel.ListinoBase.NomeEx.ToUpper & "</b><br>"
            Else
                bufferHtml &= "PRODOTTO: <b>" & p.Descrizione.ToUpper & "</b><br>"
            End If
            Dim etichetta As String = String.Empty

            If Not _ordsel.ListinoBase Is Nothing Then
                etichetta = FormerEnumHelper.TipoUnitaDiMisura(_ordsel.ListinoBase.TipoUnitaMisuraInInput)
            End If
            If _ordsel.IdTipoProd <> enRepartoWeb.StampaOffset Then


                bufferHtml &= "DIMENSIONI: <b>" & _ordsel.Largo & " (base) x " & _ordsel.Lungo & " (altezza) "
                If _ordsel.Profondita Then
                    bufferHtml &= " x " & _ordsel.Profondita & " (profondità)"
                End If
                bufferHtml &= etichetta & "</b><br>"

            End If

            If _ordsel.ListaLavori.FindAll(Function(x) x.IdLavoro = FormerConst.Lavorazioni.TaglioAMisura).Count Then
                bufferHtml &= "<br><b style='color:red;'>TAGLIO A MISURA</b>: <b>" & _ordsel.Largo & " (base) x " & _ordsel.Lungo & " (altezza) "
                If _ordsel.Profondita Then
                    bufferHtml &= " x " & _ordsel.Profondita & " (profondità)"
                End If
                bufferHtml &= "</b><br><br>"
            End If

            bufferHtml &= "TIPO RETRO: <b>" & _ordsel.TipoRetroStr & "</b><br>"
            bufferHtml &= "QUANTITA': <b>" & _ordsel.QtaRif & "</b><br>"
            If Not _ordsel.ListinoBase Is Nothing AndAlso _ordsel.ListinoBase.FormatoProdotto.Orientabile = enSiNo.Si Then
                bufferHtml &= "ORIENTAMENTO: <b>"
                bufferHtml &= FormerEnumHelper.OrientamentoStr(_ordsel.Orientamento)
                bufferHtml &= etichetta & "</b><br>"
            End If

            If _ordsel.IdTipoFustella Then
                Using tf As New TipoFustella
                    tf.Read(_ordsel.IdTipoFustella)
                    bufferHtml &= "FUSTELLA: <b>" & tf.Riassunto & "</b><br>"
                End Using
            End If

            'If _ordsel.NFogli <> 1 Then
            '    bufferHtml &= "NUMERO FOGLI: <b>" & _ordsel.NFogli & "</b> FACCIATE: <b>" & _ordsel.NFogli * 2 & "</b><br>"
            'End If

            If _ordsel.NFogli <> 1 Then

                If Not _ordsel.ListinoBase Is Nothing AndAlso _ordsel.ListinoBase.NoFaccSuImpianti = True Then
                    'blocchi
                    bufferHtml &= "NUMERO FOGLI: <b>" & _ordsel.NFogli

                    Dim CounterCarta As Integer = 0
                    If _ordsel.ListinoBase.TipoCarta.ComposizioniCarta.Count Then
                        For Each tc In _ordsel.ListinoBase.TipoCarta.ComposizioniCarta
                            CounterCarta += tc.NumFogli
                        Next
                    End If

                    If CounterCarta Then
                        bufferHtml &= "x" & CounterCarta
                    End If
                Else
                    'riviste
                    bufferHtml &= "FACCIATE: <b>" & (_ordsel.NFogli * 2)
                End If
                bufferHtml &= "</b><br>"
            End If

            If _ordsel.NomeLavoro.Length Then
                bufferHtml &= "NOME LAVORO: <b>" & _ordsel.NomeLavoro & "</b><br>"
                bufferHtml &= "USA NOME LAVORO IN FATTURA: <b>" & IIf(_ordsel.UsaNomeLavoroInFattura = enSiNo.Si, "SI", "NO") & "</b><br>"

            End If
            bufferHtml &= "<br>"
            bufferHtml &= "INSERITO IL: <b>" & _ordsel.DataInsStr & "</b><br>"
            'bufferHtml &= "consegna il " & _ordsel.DataPrevConsegna & "<br>"
            If _ordsel.ConsegnaAssociata Is Nothing Then
                bufferHtml &= "CONSEGNA NON PROGRAMMATA<br>"
            Else
                bufferHtml &= "CONSEGNA IL <b>" & _ordsel.ConsegnaAssociata.Giorno.ToString("dd/MM/yyyy") & "</b><br>"

                If _ordsel.ConsegnaGarantita <> Date.MinValue Then
                    ' Using u As New Utente
                    ' u.Read(_ordsel.ConsegnaGarantitaDa)
                    bufferHtml &= "<br><center><span style=""font-size:14px;background-color:#dcedc8;color:black;padding:6px;text-align:center;font-weight:bold;"">CONSEGNA GARANTITA " & _ordsel.ConsegnaGarantita.ToString("dd/MM/yyyy") & "</span></center><br><br>"
                    ' End Using
                End If
            End If

            bufferHtml &= "PREVENTIVO: <b>" & IIf(_ordsel.Preventivo = enSiNo.No, "No", "Si") & "</b><br>"
            bufferHtml &= "TOTALE IMPONIBILE: <b>" & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_ordsel.TotaleImponibile) & "</b><br>"

            If _ordsel.MantieniCampione = enSiNo.Si Then
                bufferHtml &= "<center><b style='color:red;'>MANTENERE UN CAMPIONE</b></center><br>"
            End If

            bufferHtml &= RiepilogoExtraData()

            If _ordsel.OrdineInOmaggio = enSiNo.Si Then
                bufferHtml &= "<br><b style=""font-size:14px;background-color:#850c70;color:white;"">OMAGGIO</b><br><br>"
            End If

            If _ordsel.IdPromo Then
                bufferHtml &= "<br><b style=""background-color:#009ec9;border-radius:3px;padding:2px;color:white;"">PROMO " & _ordsel.IdPromo & "%</b><br><br>"
            End If

            If _ordsel.IdCoupon Then
                bufferHtml &= "<br><b style=""background-color:#1aaf5d;border-radius:3px;padding:2px;color:white;"">COUPON DI SCONTO"

                If Not _ordsel.CouponUtilizzato Is Nothing Then
                    bufferHtml &= " '" & _ordsel.CouponUtilizzato.Codice.ToUpper & "'"
                Else
                    bufferHtml &= " AUTOMATICO"
                End If

                bufferHtml &= "</b><br><br>"
            End If
            bufferHtml &= "<br><center>"
            If Operatore Then
                bufferHtml &= "<img src=""" & _ordsel.FilePath & """>"
            Else
                bufferHtml &= "<a href=""" & _ordsel.FilePath & """ target=""_new""><img src=""" & _ordsel.FilePath & """ width=150  border=0></a>"
            End If
            bufferHtml &= "</center>"
            bufferHtml &= "<div class=""note""><b>NOTE</b><br>"
            bufferHtml &= HttpUtility.HtmlDecode(_ordsel.Annotazioni) & "</div>"

            ' bufferHtml &= "<FONT FACE=Tahoma size=1>Prezzo <FONT FACE=Tahoma><FONT SIZE=2><B>" & FormattaPrezzo(_ordsel.PrezzoProd) & "</B></FONT><BR>"



            '            bufferHtml &= "<FONT FACE=Tahoma size=1>Iva <FONT FACE=Tahoma><FONT SIZE=2><B>" & FormattaPrezzo(_ordsel.Iva) & "</B></FONT><BR>"
            '            bufferHtml &= "<FONT FACE=Tahoma size=1>Corriere <FONT FACE=Tahoma><FONT SIZE=2><B>" & FormattaPrezzo(_ordsel.CostoSped) & "</B></FONT><BR>"
            '            bufferHtml &= "<FONT FACE=Tahoma size=1>Sconto <FONT FACE=Tahoma><FONT SIZE=2><B>" & FormattaPrezzo(_ordsel.Sconto) & "</B></FONT><BR>"
            '            bufferHtml &= "<FONT FACE=Tahoma><FONT SIZE=2>TOT. ORDINE <FONT FACE=Tahoma><FONT SIZE=3><B>" & FormattaPrezzo(_ordsel.Prezzo) & "</B></FONT><BR>"
            p = Nothing
            bufferHtml &= "</div>"

            If Not _ordsel.ConsegnaAssociata Is Nothing Then
                If _ordsel.IdCorriere <> enCorriere.RitiroCliente Then
                    bufferHtml &= "<div class=""divOperatore""><h4>Consegna</h4>"
                    bufferHtml &= "PRODUZIONE PREVISTA PER: <b>" & _ordsel.ConsegnaAssociata.DataPrevistaProduzione.ToString("dddd dd MMMM").ToUpper & " </b><br>"
                    bufferHtml &= "CORRIERE: <b>" & _ordsel.ConsegnaAssociata.Corriere.Descrizione & " </b><br><br>"

                    If _ordsel.ConsegnaAssociata.IdIndirizzo Then
                        Dim Ind As New Indirizzo
                        Ind.Read(_ordsel.ConsegnaAssociata.IdIndirizzo)

                        bufferHtml &= "INDIRIZZO ALTERNATIVO: <b>" & Ind.Riassunto(False) & "</b>"
                    Else
                        bufferHtml &= "INDIRIZZO <b>" & _ordsel.ConsegnaAssociata.IndirizzoRiassunto & "</b>"
                    End If
                    bufferHtml &= "</div>"
                Else
                    bufferHtml &= "<div class=""divOperatore""><h4>Ritiro</h4>"
                    bufferHtml &= "RITIRO CLIENTE PREVISTO PER: <b>" & _ordsel.ConsegnaAssociata.DataPrevistaProduzione.ToString("dddd dd MMMM").ToUpper & " </b>"
                    bufferHtml &= "</div>"
                End If
            End If

            bufferHtml &= "<div class=""divOperatore""><h4>Documento Fiscale</h4>"
            If _ordsel.IdDoc Then


                Using doc As New Ricavo
                    Dim DescrDoc As String = ""

                    doc.Read(_ordsel.IdDoc)
                    If doc.IdDocRif Then
                        doc.Read(doc.IdDocRif)
                    End If
                    DescrDoc = "<b>" & MgrAziende.GetAziendaStr(doc.IdAzienda) & "</b> " & doc.TipoDocStr.ToUpper & " numero " & doc.Numero & " del " & doc.DataRicavo.Date
                    bufferHtml &= DescrDoc
                End Using
            Else
                bufferHtml &= "Non è presente un documento fiscale"
            End If

            bufferHtml &= "<br></div>"

            bufferHtml &= "<div class=""divOperatore""><h4>Pagamento</h4>"
            If Not _ordsel.ConsegnaAssociata Is Nothing AndAlso Not _ordsel.ConsegnaAssociata.PagamentoAnticipato Is Nothing Then
                bufferHtml &= "PAGAMENTO ANTICIPATO: <b>" & _ordsel.ConsegnaAssociata.PagamentoAnticipato.ImportoStr & " &euro; con " & FormerEnumHelper.TipoPagamentoStr(_ordsel.ConsegnaAssociata.PagamentoAnticipato.IdTipoPagamento).ToUpper & "</b> <img src=""http://www.tipografiaformer.it" & _ordsel.ConsegnaAssociata.PagamentoAnticipato.TipoPagamento.imgWeb & """/><br>"
            ElseIf Not _ordsel.ConsegnaAssociata Is Nothing Then
                bufferHtml &= "MODALITA' DI PAGAMENTO: <b>" & _ordsel.ConsegnaAssociata.PagamentoStr & "</b><br>"
            End If
            bufferHtml &= "</div>"


            bufferHtml &= "<div class=""divPiccolo divOperatore""><h4>File sorgenti</h4>"
            If _ordsel.FilePath.ToString.Length Then

                bufferHtml &= "(A) <b><a href=""" & _ordsel.FilePath.ToString & """ target=""_new"">" & _ordsel.FilePath.ToLower.Replace(FormerPath.PathCommesse.ToLower, "") & "</a></b><br>"

            End If

            For Each Sorgente In _ordsel.ListaSorgenti
                bufferHtml &= "(S) <b><a href=""" & Sorgente.FilePath.ToLower & """>" & Sorgente.FilePath.ToLower.Replace(FormerPath.PathCommesse.ToLower, "") & "</a></b><br>"
            Next
            bufferHtml &= "</div>"

            If _ordsel.ListaFileAllegati.Count Then
                bufferHtml &= "<div class=""divPiccolo divOperatore""><h4>File allegati</h4>"
                For Each Allegato In _ordsel.ListaFileAllegati
                    bufferHtml &= "<b><a href=""" & Allegato.FilePath.ToLower & """>" & Allegato.FilePath.ToLower.Replace(FormerPath.PathCommesse.ToLower, "") & "</a></b><br>"
                Next
                bufferHtml &= "</div>"
            End If
            'bufferHtml &= "</BODY></HTML>" & ControlChars.NewLine

            Return bufferHtml
        End Get
    End Property

    Public ReadOnly Property CreaRiepilogoImballo()
        Get
            Dim bufferHtml As String = ""

            Dim _ordsel As Ordine = Me

            'bufferHtml = "<html><head><title>Riepilogo</title><style>body {font-family: 'Tahoma';}</style>"
            'bufferHtml &= "</head><body bgcolor=""WHITE""><font size=1>" & ControlChars.NewLine
            'qui carico se ha immagini e in caso faccio il box incorniciato

            'bufferHtml &= "<FONT SIZE=4><CENTER>Riepilogo Ordine</CENTER></FONT><BR><BR>"

            Dim cli As New VoceRubrica
            cli.Read(_ordsel.IdRub)
            Dim p As New Prodotto
            p.Read(_ordsel.IdProd)

            bufferHtml &= "<DIV style=""background-color:#EDEDED;""><B><font size=2>" &
                IIf(cli.RagSocNome.Length, cli.RagSocNome & "<BR>", "") & "</b>" &
                IIf(cli.Cognome.Length, cli.Cognome & " " & cli.Nome & "<BR>", "") &
                "</font></b><br>"

            Dim Corr As New Corriere

            bufferHtml &= "<FONT SIZE=2><B>" & p.Descrizione & "</B></font><br>"

            'cli = Nothing
            Dim strWidth As String = ""

            Try
                'Dim x As Image = Image.FromFile(_ordsel.File)

                'If x.Width > x.Height Then
                strWidth = " width=150 "
                'Else
                'strWidth = " height=100 "
                'End If

            Catch ex As Exception

            End Try

            bufferHtml &= "<A HREF=""" & _ordsel.FilePath & """ target=""_new""><IMG SRC=""" & _ordsel.FilePath & """ " & strWidth & " border=0></A><BR>"
            bufferHtml &= "Note: <BR>"

            Corr.Read(_ordsel.IdCorriere)

            '            bufferHtml &= "<br><B>Trasporto:</B>: "
            bufferHtml &= "<FONT size=1>Trasporto <FONT SIZE=2><B>" & Corr.Descrizione & " </B></FONT></FONT><BR>"
            Corr = Nothing
            ' bufferHtml &= "<FONT FACE=Tahoma size=1>Prezzo <FONT FACE=Tahoma><FONT SIZE=2><B>" & FormattaPrezzo(_ordsel.PrezzoProd) & "</B></FONT><BR>"
            bufferHtml &= "<FONT size=1>Qta <FONT SIZE=2><B>" & _ordsel.QtaRif & "</B></FONT></FONT>"
            bufferHtml &= "</div>"

            bufferHtml &= "</FONT>" & ControlChars.NewLine

            Return bufferHtml
        End Get
    End Property

    Public ReadOnly Property ContenutoInQualcheScatolaConAltri As Boolean
        Get
            Dim ris As Boolean = False
            Dim LOrd As New List(Of Integer)
            Using mgr As New OrdiniScatoleDAO
                Dim l As List(Of OrdineScatola) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrdine", IdOrd))
                For Each singOs As OrdineScatola In l
                    If LOrd.IndexOf(singOs.IdOrdine) = -1 Then
                        LOrd.Add(singOs.IdOrdine)
                    End If
                Next
            End Using
            If LOrd.Count > 1 Then ris = True
            Return ris
        End Get
    End Property

    Public Function GetNumColli() As Integer
        Dim Ris As Integer = 0

        Dim P As New Prodotto
        P.Read(_IdProd)
        Ris = P.NumColli
        P = Nothing

        Return Ris

    End Function

    Public Function SaveFirstTime(Optional IdInseritoDa As Integer = 0) As Integer
        Dim Ris As Integer = 0
        Try
            Ris = Save()
            Using mO As New OrdiniDAO

                mO.InserisciLog(Me, Stato, IdInseritoDa)

                mO.InserisciLavorazioni(Me)

            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return Ris
    End Function

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IOrdine.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()

        'AGGIUNTO PER NON USARE PIU IL LISTINO VECCHIO
        If IdOrd = 0 Then
            If IdListinoBase = 0 Then Ris = False
        End If

        If NFogli = 0 Then NFogli = 1 'PATCH TEMPORANEA
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IOrdine.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IOrdine.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

    Public ReadOnly Property DescrizioneProdotto As String
        Get
            Dim ris As String = String.Empty

            ris = Prodotto.Descrizione

            Return ris
        End Get
    End Property

    Public ReadOnly Property DescrizioneCliente As String
        Get
            Dim ris As String = String.Empty

            ris = VoceRubrica.RagSocNome

            If ris.Length = 0 Then ris = VoceRubrica.Nome & " " & VoceRubrica.Cognome

            Return ris
        End Get
    End Property

    Public ReadOnly Property PreventivoStr As String
        Get
            Dim ris As String = String.Empty

            If Preventivo = enSiNo.Si Then
                ris = "Si"
            Else
                ris = "No"
            End If

            Return ris
        End Get
    End Property

    'EMBEDDED CLASS
    Protected _Prodotto As Prodotto
    Public Property Prodotto(Optional ByVal ForceLoad As Boolean = False) As Prodotto
        Get
            If _Prodotto Is Nothing Or ForceLoad = True Then
                Using Mgr As New ProdottiDAO
                    _Prodotto = Mgr.Read(IdProd)
                End Using
            End If
            Return _Prodotto
        End Get
        Set(ByVal value As Prodotto)
            _Prodotto = value
            _IdProd = _Prodotto.IdProd
        End Set
    End Property

    Protected _VoceRubrica As VoceRubrica
    Public Property VoceRubrica(Optional ByVal ForceLoad As Boolean = False) As VoceRubrica
        Get
            If _VoceRubrica Is Nothing Or ForceLoad = True Then
                Using Mgr As New VociRubricaDAO
                    _VoceRubrica = Mgr.Read(_IdRub)
                End Using
            End If
            Return _VoceRubrica
        End Get
        Set(ByVal value As VoceRubrica)
            _VoceRubrica = value
            _IdRub = _VoceRubrica.IdRub
        End Set
    End Property

    Public Sub SetLastUpdate(LastUpdateValue As Integer)
        LastUpdate = LastUpdateValue
        Using mgr As New OrdiniDAO
            mgr.SetLastUpdate(IdOrd, LastUpdateValue)
        End Using
    End Sub

    Public ReadOnly Property GGMancanti As String
        Get
            Dim ris As String = String.Empty

            If Stato < enStatoOrdine.Imballaggio Then
                If Not ConsegnaAssociata Is Nothing Then
                    Dim DataEnd As Date = ConsegnaAssociata.Giorno 'DataPrevProduzione
                    'Dim DiffDate As Integer = DateDiff(DateInterval.Day, ConsegnaAssociata.Giorno, DataPrevProduzione)

                    'If DiffDate > 0 Then
                    'DataEnd = ConsegnaAssociata.Giorno
                    'End If

                    'calcolo i giorni mancanti con la piu urgente tra dataprevista e consegna associata

                    ris = MgrDataConsegna.CalcolaGiorniMancanti(Now, ConsegnaAssociata.IdCorr, DataEnd)
                    'Dim DataEsaminata As Date = Now
                    'Dim OraRif As Integer = 19

                    'If ConsegnaAssociata.IdCorr <> enCorriere.GLS And
                    '   ConsegnaAssociata.IdCorr <> enCorriere.GLSIsole And
                    '   ConsegnaAssociata.IdCorr <> enCorriere.PortoAssegnatoGLS Then

                    '    OraRif = 14

                    'End If

                    'Dim DataFineGiornata As New Date(DataEsaminata.Year, DataEsaminata.Month, DataEsaminata.Day, OraRif, 0, 0)

                    'Dim DiffOre As Integer = DateDiff(DateInterval.Hour, DataEsaminata, DataFineGiornata)
                    'Dim DiffGiorni As Integer = 0

                    'Do Until DataEsaminata > DataEnd
                    '    DataEsaminata = DataEsaminata.AddDays(1)

                    '    If DataEsaminata.DayOfWeek <> DayOfWeek.Sunday AndAlso MgrDataConsegna.IsFestivita(DataEsaminata) = False Then
                    '        DiffGiorni += 1
                    '    End If

                    'Loop

                    'If DiffOre = 0 And DiffGiorni = 0 Then
                    '    Dim Differenza As Integer = 0
                    '    Differenza = DateDiff(DateInterval.Day, Now, ConsegnaAssociata.DataEffConsegna)
                    '    If Differenza = 0 Then
                    '        ris = "Scade Oggi"
                    '    Else
                    '        ris = "Scaduto da " & Math.Abs(Differenza) & "g"
                    '    End If

                    'Else
                    '    If DiffGiorni Then
                    '        ris = DiffGiorni & "g"
                    '    End If

                    '    If DiffOre Then
                    '        ris &= IIf(ris.Length, ",", "") & DiffOre & "h" '
                    '    End If

                    'End If
                Else
                    ris = "-"
                End If
            Else
                ris = "-"
            End If

            Return ris
        End Get
    End Property

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class

Public Class OrdineRicerca
    Inherits Ordine

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

    Public Sub New(O As Archiviato)

        'qui creo l'oggetto a partire da un ordine riempiendo solo le proprieta necessarie
        IdProd = O.IdProd
        DataIns = O.DataIns
        Qta = O.Qta
        TotaleForn = O.TotaleForn
        Sconto = O.Sconto
        Ricarico = O.Ricarico
        IdCorriere = O.IdCorriere
        IdListinoBase = O.IdListinoBase
        SorgenteCliente = O.Sorgente

    End Sub

    '    Private _ProdottoDescrizione As String = ""
    Public ReadOnly Property ProdottoDescrizione As String
        Get
            Dim ris As String = String.Empty
            If IdProd AndAlso Not Prodotto Is Nothing Then
                If Prodotto.IdListinoBase Then
                    ris = ListinoBase.NomeEx
                Else
                    ris = Prodotto.Descrizione
                End If
            Else
                ris = "FUORI LISTINO"
            End If

            Return ris
        End Get
        'Set(value As String)
        '    _ProdottoDescrizione = value
        'End Set
    End Property

    Private _ClienteNominativo As String = ""
    Public Property ClienteNominativo As String
        Get
            Return _ClienteNominativo
        End Get
        Set(value As String)
            _ClienteNominativo = value
        End Set
    End Property

    Public ReadOnly Property TipoCartaStr As String
        Get
            Dim ris As String = String.Empty
            If IdListinoBase Then
                ris = ListinoBase.TipoCartaStr
            End If
            Return ris
        End Get
    End Property

    Private _CorriereStr As String = ""
    Public Overloads Property CorriereStr As String
        Get

            If Not ConsegnaAssociata Is Nothing Then
                _CorriereStr = ConsegnaAssociata.Corriere.NomeBreve
            End If

            Return _CorriereStr
        End Get
        Set(value As String)
            _CorriereStr = value
        End Set
    End Property

    Public ReadOnly Property ProgrammataConsegna As Boolean
        Get
            Dim ris As Boolean = False
            'If _DataConsProgr <> Date.MinValue Then
            '    ris = True
            'End If
            If Not ConsegnaAssociata Is Nothing Then
                ris = True
            End If
            Return ris
        End Get
    End Property

    'Private _DataConsProgr As Date = Date.MinValue
    Public ReadOnly Property DataConsProgr As Date
        Get
            Dim Ris As Date = Date.MinValue
            'If _DataConsProgr <> Date.MinValue Then
            '    Return _DataConsProgr
            'Else
            '    Return DataPrevConsegna
            'End If
            If Not ConsegnaAssociata Is Nothing Then
                Ris = ConsegnaAssociata.Giorno
            Else
                Ris = DataPrevConsegna
            End If
            Return Ris
        End Get
        'Set(value As Date)
        '    _DataConsProgr = value
        'End Set
    End Property

    Private _DataConsProgrStr As String = ""
    Public ReadOnly Property DataConsProgrStr As String
        Get
            'If _DataConsProgr <> Date.MinValue Then
            '    Return "(P) " & _DataConsProgr.ToString("dd.MM.yy")
            'Else
            '    Return DataConsPrevStr
            'End If
            Return DataConsProgr.ToString("dd.MM.yy")

        End Get
    End Property

    Private _NumSpazi As Integer = 0
    Public Property NumSpazi As Integer
        Get
            Return _NumSpazi
        End Get
        Set(value As Integer)
            _NumSpazi = value
        End Set
    End Property

    Private _NumDuplicati As Integer = 0
    Public Property NumDuplicati As Integer
        Get
            Return _NumDuplicati
        End Get
        Set(value As Integer)
            _NumDuplicati = value
        End Set
    End Property
End Class

Public Class OrdineOperatore
    Inherits OrdineRicerca

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

    Private _InCaricoAStr As String = ""
    Public ReadOnly Property InCaricoAStr() As String
        Get
            Dim Ris As String = ""
            If _InCaricoAStr.Length Then
                Ris = _InCaricoAStr
            Else
                If _IdOperatore Then
                    Dim U As New Utente
                    U.Read(_IdOperatore)
                    Ris = U.Login
                    U = Nothing
                End If

            End If
            Return Ris
        End Get
    End Property

    Private _LavorazioneStr As String = ""
    Public Property LavorazioneStr() As String
        Get
            Return _LavorazioneStr
        End Get
        Set(value As String)
            _LavorazioneStr = value
        End Set
    End Property

    Private _IdOperatore As Integer = 0
    Public Property IdOperatore() As Integer
        Get
            Return _IdOperatore
        End Get
        Set(value As Integer)
            _IdOperatore = value
        End Set
    End Property

End Class


''' <summary>
'''Interface for table T_ordini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IOrdine
    Inherits _IOrdine

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface