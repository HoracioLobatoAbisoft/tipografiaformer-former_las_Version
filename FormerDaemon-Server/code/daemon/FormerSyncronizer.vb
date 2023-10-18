Imports FW = FormerDALWeb
Imports F = FormerDALSql
Imports System.IO
Imports System.Configuration
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerBusinessLogic
Imports FormerConfig
Imports FormerDALSql
Imports FormerWebLabeling
Imports System.Text.RegularExpressions
Imports FormerIO
Friend Class FormerSyncronizer
    Inherits BaseService

#Region "Base Function"

    Private Shared Property _txtLog As TextBox = Nothing
    Private Shared Property _lblLastOp As Label = Nothing
    Private Shared Property _ModuleName As String = String.Empty
    Private Shared Property _ModuleSigla As String = String.Empty

    Public Shared ReadOnly Property ModuleSigla As String
        Get
            Return _ModuleSigla
        End Get
    End Property

    Public Shared Sub Initialize(ByRef txtLog As TextBox,
                                 ByRef lblLastOp As Label,
                                 ModuleName As String,
                                 ModuleSigla As String)
        _txtLog = txtLog
        _lblLastOp = lblLastOp
        _ModuleName = ModuleName
        _ModuleSigla = ModuleSigla

    End Sub

    Public Shared Sub LogMe(Testo As String,
             Optional DontStore As Boolean = False,
             Optional Errore As Exception = Nothing)
        _LogMe(_txtLog, _lblLastOp, Testo, _ModuleName, _ModuleSigla, DontStore, Errore)
    End Sub

#End Region

    Public Shared ReadOnly Property EmailNonDisponibile As String
        Get
            Dim Ris As String = FormerConst.EmailNonDisponibile 'ConfigurationManager.AppSettings("Syncronizer-EmailNonDisponibile")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalNewOrdMin As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Syncronizer-Interval-NewOrd")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalNewOrd As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Syncronizer-Interval-NewOrd")
            If Ris Then Ris = Ris * 60 * 1000
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalSyncroMin As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Syncronizer-Interval-Syncro")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalSyncro As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Syncronizer-Interval-Syncro")
            If Ris Then Ris = Ris * 60 * 1000
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalProcGiornMin As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Syncronizer-Interval-ProcGiorn")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalProcGiorn As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Syncronizer-Interval-ProcGiorn")
            If Ris Then Ris = Ris * 60 * 1000
            Return Ris
        End Get
    End Property

    Public Class Syncronizer
        'Inherits FormerService

        Public Shared Sub StartService()
            Stato = enStatoServizio.Attivo

            LogMe("***Syncronizer***")

            Try

                If Postazione.Network.ConnessioneInternetDisponibile AndAlso Postazione.Network.ConnessioneDbRemotoDisponibile Then
                    SincronizzaRubrica()
                    Application.DoEvents()
                    'Else
                    '    Throw New Exception("SINCRONIZZA RUBRICA - Connessione internet non disponibile")
                End If

                If Postazione.Network.ConnessioneInternetDisponibile AndAlso Postazione.Network.ConnessioneDbRemotoDisponibile Then
                    SincronizzaStatoOrdini()
                    Application.DoEvents()
                    'Else
                    '    Throw New Exception("SINCRONIZZA STATO ORDINI - Connessione internet non disponibile")
                End If

                If Postazione.Network.ConnessioneInternetDisponibile AndAlso Postazione.Network.ConnessioneDbRemotoDisponibile Then
                    SincronizzaStatoConsegne()
                    Application.DoEvents()
                    'Else
                    '    Throw New Exception("SINCRONIZZA STATO CONSEGNE - Connessione internet non disponibile")
                End If

            Catch ex As Exception
                LogMe("SORGENTE: Syncronizer(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try

            LogMe("***Syncronizer TERMINATO***")
            Stato = enStatoServizio.NonAttivo

        End Sub

        Private Shared Sub LogCoupon(Testo As String,
                          GruppoCoupon As String)

            Try

                Dim PathFolder As String = PathLogCoupon
                Using w As New StreamWriter(PathFolder & "LogCoupon" & GruppoCoupon & ".txt", True)
                    w.WriteLine(Now.ToString & " - " & Testo)
                End Using
            Catch ex As Exception

            End Try

        End Sub

        Private Shared Sub EmettiCoupon(V As VoceRubrica,
                                        GruppoCoupon As String)

            LogMe(GruppoCoupon & " - Richiesta Coupon IdRubrica " & V.IdRub & " " & V.RagSocNome)
            LogCoupon("Richiesta Coupon IdRubrica " & V.IdRub & " " & V.RagSocNome, GruppoCoupon)

            Try
                Select Case GruppoCoupon
                    Case "VISCOM2016" 'GRUPPO VISCOM 2016
                        If Now.Year < 2017 Then
                            Dim Codice As String = V.IdUtOnline & "-VISCOM2016"
                            Dim DataInizioValidita As Date = Now
                            Dim DataFineValidita As Date = New Date(2016, 12, 31)

                            Using mgr As New FormerDALWeb.CouponWDAO
                                Dim l As List(Of FormerDALWeb.CouponW) = mgr.FindAll(New FormerDALWeb.LUNA.LunaSearchParameter(FormerDALWeb.LFM.CouponW.Codice, Codice),
                                                                                     New FormerDALWeb.LUNA.LunaSearchParameter(FormerDALWeb.LFM.CouponW.Riservato, V.IdUtOnline))

                                If l.Count = 0 Then
                                    Using Conl As New FormerDALWeb.CouponW

                                        Conl.Codice = Codice
                                        Conl.Nome = "Sconto Viscom2016"
                                        Conl.IdListinoBase = 0
                                        Conl.Riservato = V.IdUtOnline
                                        Conl.Percentuale = 30
                                        Conl.ImportoFisso = 0
                                        Conl.QtaSpecifica = 0
                                        Conl.MaxVolte = 1
                                        Conl.DataInizioValidita = DataInizioValidita
                                        Conl.DataFineValidita = DataFineValidita
                                        Conl.RiservatoATipoUtente = enTipoRubrica.Rivenditore
                                        Conl.Save()

                                    End Using

                                    'INVIO LA MAIL DI AVVISO
                                    Dim Soggetto As String = "Ecco il tuo Coupon di sconto VISCOM 2016"
                                    Dim Buffer As String = ""

                                    Buffer &= "<center><img src=""https://www.tipografiaformer.it/emailattach/CouponDiSconto.png""></center><br><br><b>HAI RICEVUTO UN COUPON DI SCONTO</b><br><br>"

                                    Buffer &= "Gentile Cliente,<br><br>ringraziandoti della visita al nostro stand al <b>VISCOM 2016</b> ti inviamo come promesso il codice del Coupon di sconto con cui potrai ottenere il <b>30% di sconto</b> incondizionato sul primo ordine.<br><br>"

                                    Buffer &= "Il codice del coupon è: <b>" & Codice & "</b><br><br>"
                                    Buffer &= "La data di scadenza è il : <b>" & DataFineValidita.ToString & "</b><br><br>"
                                    Buffer &= "Troverai tutte le informazioni sulle modalità di utilizzo del Coupon sul nostro sito nella sezione <b>I tuoi Coupon</b> che puoi raggiungere all'indirizzo https://www.tipografiaformer.it/i-tuoi-coupon-di-sconto o cliccando <a href=""https://www.tipografiaformer.it/i-tuoi-coupon-di-sconto"">qui</a>."

                                    FormerLib.FormerHelper.Mail.InviaMail(Soggetto, Buffer, V.Email)

                                    LogCoupon("Emesso Coupon IdRubrica " & V.IdRub & " " & V.RagSocNome, GruppoCoupon)
                                    LogMe(GruppoCoupon & " - Emesso Coupon IdRubrica " & V.IdRub & " " & V.RagSocNome)
                                End If

                            End Using

                        End If

                    Case "SHOPEXPO2017"
                        If Now.Year < 2018 Then
                            Dim Codice As String = V.IdUtOnline & "-SHOPEXPO2017"
                            Dim DataInizioValidita As Date = Now
                            Dim DataFineValidita As Date = New Date(2017, 12, 31)

                            Using mgr As New FormerDALWeb.CouponWDAO
                                Dim l As List(Of FormerDALWeb.CouponW) = mgr.FindAll(New FormerDALWeb.LUNA.LunaSearchParameter("Codice", Codice),
                                                                                     New FormerDALWeb.LUNA.LunaSearchParameter("Riservato", V.IdUtOnline))

                                If l.Count = 0 Then
                                    Using Conl As New FormerDALWeb.CouponW

                                        Conl.Codice = Codice
                                        Conl.Nome = "Sconto SHOPEXPO2017"
                                        Conl.IdListinoBase = 0
                                        Conl.Riservato = V.IdUtOnline
                                        Conl.Percentuale = 30
                                        Conl.ImportoFisso = 0
                                        Conl.QtaSpecifica = 0
                                        Conl.MaxVolte = 1
                                        Conl.DataInizioValidita = DataInizioValidita
                                        Conl.DataFineValidita = DataFineValidita
                                        Conl.RiservatoATipoUtente = enTipoRubrica.Rivenditore
                                        Conl.Save()

                                    End Using

                                    'INVIO LA MAIL DI AVVISO
                                    Dim Soggetto As String = "Ecco il tuo Coupon di sconto SHOPEXPO 2017"
                                    Dim Buffer As String = ""

                                    Buffer &= "<center><img src=""https://www.tipografiaformer.it/emailattach/CouponDiSconto.png""></center><br><br><b>HAI RICEVUTO UN COUPON DI SCONTO</b><br><br>"

                                    Buffer &= "Gentile Cliente,<br><br>ringraziandoti della visita al nostro stand al <b>SHOPEXPO 2017</b> ti inviamo come promesso il codice del Coupon di sconto con cui potrai ottenere il <b>30% di sconto</b> incondizionato sul primo ordine.<br><br>"

                                    Buffer &= "Il codice del coupon è: <b>" & Codice & "</b><br><br>"
                                    Buffer &= "La data di scadenza è il : <b>" & DataFineValidita.ToString & "</b><br><br>"
                                    Buffer &= "Troverai tutte le informazioni sulle modalità di utilizzo del Coupon sul nostro sito nella sezione <b>I tuoi Coupon</b> che puoi raggiungere all'indirizzo https://www.tipografiaformer.it/i-tuoi-coupon-di-sconto o cliccando <a href=""https://www.tipografiaformer.it/i-tuoi-coupon-di-sconto"">qui</a>."

                                    FormerLib.FormerHelper.Mail.InviaMail(Soggetto, Buffer, V.Email)

                                    LogCoupon("Emesso Coupon IdRubrica " & V.IdRub & " " & V.RagSocNome, GruppoCoupon)
                                    LogMe(GruppoCoupon & " - Emesso Coupon IdRubrica " & V.IdRub & " " & V.RagSocNome)
                                End If

                            End Using

                        End If

                    Case Else
                        'PER ORA NON CI SONO ALTRI TIPI DI PROMOZIONI A COUPON

                End Select
            Catch ex As Exception
                LogMe("SORGENTE: EmettiCoupon(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try

        End Sub

        Private Shared Sub EmettiCouponNuovi(Vr As VoceRubrica)

            'VISCOM2016
            '******************
            'Dim IdCategoria2 As Integer = 85
            'Using mgr As New VoceRubricaMarketingDAO
            '    Dim l As List(Of VoceRubricaMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter("Email", Vr.Email),
            '                                                     New LUNA.LunaSearchParameter("IdCategoria2", IdCategoria2))
            '    If l.Count Then
            '        EmettiCoupon(Vr, "VISCOM2016")
            '    End If
            'End Using
            '******************

            'SHOPEXPO2017
            Dim IdCategoria2 As Integer = FormerConst.Coupon.GruppoCouponShopExpo2017
            Using mgr As New VoceRubricaMarketingDAO
                Dim l As List(Of VoceRubricaMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubricaMarketing.Email, Vr.Email),
                                                                     New LUNA.LunaSearchParameter(LFM.VoceRubricaMarketing.IdCategoria2, IdCategoria2))
                If l.Count Then
                    EmettiCoupon(Vr, "SHOPEXPO2017")
                End If
            End Using

        End Sub

        Private Shared Sub SincronizzaRubrica()

            Dim CurrentThreadID As Integer = Threading.Thread.CurrentThread.ManagedThreadId

            LogMe("***SINCRONIZZAZIONE RUBRICA***")

            Try
                'cerco tutte le voci rubrica che hanno un valore in lastupdate > ultimasincro
                'Dim LastSincRub As Date = Now.AddDays(-1)
                ''LogMe("***LEGGO ULTIMA SINCRONIZZAZIONE***")
                'If System.IO.File.Exists(PathLastSincRub) Then
                '    Using r As New StreamReader(PathLastSincRub)
                '        LastSincRub = r.ReadToEnd
                '    End Using
                'End If

                Dim l As List(Of F.VoceRubrica) = Nothing
                Using mgr As New F.VociRubricaDAO
                    l = mgr.ListaClientiByCambioStato()
                End Using
                Dim Counter As Integer = 0
                For Each r As F.VoceRubrica In l
                    LogMe("Sincronizzo Rubrica Interna Id " & r.IdRub)
                    '                Dim Trans As Data.Common.DbTransaction = Nothing
                    'Dim Conn As Data.Common.DbConnection = Nothing
                    Using Tb As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox()
                        Using mgr As New FW.UtentiDAO
                            Try
                                Dim U As FW.Utente = Nothing

                                'Using mgrU As New FW.UtentiDAO
                                U = mgr.Find(New FW.LUNA.LunaSearchParameter(FW.LFM.Utente.IdRubricaInt, r.IdRub))
                                If U Is Nothing Then
                                    U = New FW.Utente
                                End If
                                'End Using

                                If U.IdUt = 0 Then
                                    U.PasswordHash = FormerHelper.Security.GetMd5Hash(r.CalcolaChiave) 'calcolo la password con vecchia funzione
                                End If
                                U.Cap = r.CAP
                                U.Cellulare = r.Cellulare
                                U.Citta = r.Citta
                                U.CodFisc = r.CodFisc
                                U.Cognome = r.Cognome
                                If r.Email.Trim.Length = 0 Then
                                    r.Email = EmailNonDisponibile
                                End If
                                U.Email = r.Email
                                U.Fax = r.Fax
                                U.IdRubricaInt = r.IdRub
                                U.Indirizzo = r.Indirizzo
                                U.Nome = r.Nome
                                U.Piva = r.Piva
                                U.RagSoc = r.RagSoc
                                U.SitoWeb = r.SitoWeb
                                U.Tel = r.Tel
                                U.TipoRub = r.Tipo
                                U.IdComune = r.IdComune
                                U.IdProvincia = r.IdProvincia
                                U.PrefissoPIva = r.PrefissoPiva

                                'RIATTIVARE SE SI VUOLE SOVRASCRIVERE LA LORO SCELTA DI CORRIERE DI DEFAULT
                                U.IdCorriereDef = r.IdCorriere
                                U.IdPagamento = r.IdPagamento
                                U.IdTipoAttivita = r.IdTipoAttivita
                                U.NoMail = r.NoEmail
                                U.CodiceSDI = r.CodiceSDI
                                U.Pec = r.Pec
                                U.NoCheckDatiFisc = r.NoCheckDatiFisc
                                U.IdNazione = r.IdNazione
                                U.LastUpdate = Now

                                Tb.TransactionBegin()

                                U.Save()

                                If U.IdUt Then
                                    r.IdUtOnline = U.IdUt
                                End If
                                r.LastUpdate = Date.MinValue
                                r.Save()

                                Tb.TransactionCommit()
                                Counter += 1

                            Catch ex As Exception
                                Tb.TransactionRollBack()
                                LogMe("SORGENTE: SincronizzaRubrica(), Id Rubrica Interno " & r.IdRub & " - " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
                            End Try
                        End Using
                    End Using
                Next

                l = Nothing
                LogMe("SINCRONIZZATI " & Counter)
                LogMe("***SINCRONIZZAZIONE RUBRICA TERMINATA***")

                Counter = 0
                LogMe("***DOWNLOAD NUOVE REGISTRAZIONI***")

                'qui scarico quelli che vogliamo esplicitamente 
                Using mgr As New FW.UtentiDAO
                    'Dim lUt As List(Of FW.Utente) = mgr.FindAll(New FW.LUNA.LunaSearchParameter("DownloadEsplicito", enSiNo.Si), _
                    '                                            New FW.LUNA.LunaSearchParameter("IdRubricaInt", 0))
                    Dim lUt As List(Of FW.Utente) = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.Utente.IdRubricaInt, 0))

                    For Each singUt In lUt.ToList
                        Dim IdUtenteGiaTrovato As Integer = 0
                        Using mgrInt As New F.VociRubricaDAO
                            Dim lInt As List(Of F.VoceRubrica) = mgrInt.FindAll(New F.LUNA.LunaSearchParameter(F.LFM.VoceRubrica.Email, singUt.Email))
                            If lInt.Count > 1 Then
                                IdUtenteGiaTrovato = -1
                            ElseIf lInt.Count = 1 Then
                                If singUt.IdUt = lInt(0).IdUtOnline Then
                                    IdUtenteGiaTrovato = lInt(0).IdRub
                                Else
                                    IdUtenteGiaTrovato = -1
                                End If
                            End If
                        End Using
                        If IdUtenteGiaTrovato = 0 Then
                            Dim UInt As New F.VoceRubrica

                            CreaRubricaIntFromWeb(UInt, singUt, singUt.IdPagamento)

                            Using tb As F.LUNA.LunaTransactionBox = F.LUNA.LunaContext.CreateTransactionBox
                                Using tbO As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox
                                    Try
                                        tb.TransactionBegin()
                                        tbO.TransactionBegin()
                                        UInt.Save()
                                        singUt.IdRubricaInt = UInt.IdRub
                                        singUt.DownloadEsplicito = enSiNo.No
                                        singUt.Save()
                                        tb.TransactionCommit()
                                        tbO.TransactionCommit()

                                        EmettiCouponNuovi(UInt)
                                        Counter += 1
                                        LogMe("Salvato Nuovo Cliente dal sito: " & singUt.Nominativo)

                                    Catch ex As Exception
                                        tb.TransactionRollBack()
                                        tbO.TransactionRollBack()
                                        LogMe("SORGENTE: DOWNLOAD NUOVE REGISTRAZIONI Errore salvataggio nuovo cliente idUtOnline: " & singUt.IdUt & ", " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
                                    End Try
                                End Using
                            End Using
                        ElseIf IdUtenteGiaTrovato > 0 Then
                            LogMe("DOWNLOAD NUOVE REGISTRAZIONI, EMAIL GIA' PRESENTE ASSOCIATA A RUBRICA ESISTENTE: " & singUt.Nominativo)
                            'qui c'e' gia un utente e lo associo, per qualche motivo la registrazione e' adnata a buon fine a meta' 
                            singUt.IdRubricaInt = IdUtenteGiaTrovato
                            singUt.DownloadEsplicito = enSiNo.No
                            singUt.Save()
                        ElseIf IdUtenteGiaTrovato = -1 Then
                            'qui ci sono piu utenti interni con quella mail sitauzione limite e assurda, segnalo errore e mi mando una mail 
                            LogMe("ERRORE DOWNLOAD NUOVE REGISTRAZIONI, EMAIL GIA PRESENTE PIU VOLTE: " & singUt.Nominativo)
                            FormerHelper.Mail.InviaMail("Errore nuove registrazioni", "Questo utente risulta registrato piu volte nella nostra rubrica interna: idutonline " & singUt.IdUt & " email " & singUt.Email, FormerConst.EmailAssistenzaTecnica)

                        End If
                    Next
                End Using
                LogMe("DOWNLOAD NUOVI " & Counter)
                LogMe("***DOWNLOAD NUOVE REGISTRAZIONI TERMINATO***")

                LogMe("***DOWNLOAD NUOVI INDIRIZZI***")
                Counter = 0
                Dim lInd As List(Of FW.Indirizzo) = Nothing
                'qui scarico gli indirizzi
                Using mgr As New FW.IndirizziDAO

                    lInd = mgr.ListaNuoviIndirizzi

                End Using

                For Each singInd As FW.Indirizzo In lInd
                    Using tb As F.LUNA.LunaTransactionBox = F.LUNA.LunaContext.CreateTransactionBox()
                        NewOrder.CreaIndirizzoIntdaOnline(singInd, tb)
                        Counter += 1
                    End Using
                Next
                LogMe("NUOVI INDIRIZZI " & Counter)
                LogMe("***DOWNLOAD NUOVI INDIRIZZI TERMINATO***")

                Counter = 0
                LogMe("***SINCRONIZZAZIONE AGGIORNAMENTO DATI DA WEB***")

                Dim lDatiFisc As List(Of FW.Utente) = Nothing
                Using mgr As New FW.UtentiDAO
                    lDatiFisc = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.Utente.UpdateFromUser, enSiNo.Si),
                                            New FW.LUNA.LunaSearchParameter(FW.LFM.Utente.IdRubricaInt, 0, "<>"))

                    For Each singUt In lDatiFisc
                        Using tb As F.LUNA.LunaTransactionBox = F.LUNA.LunaContext.CreateTransactionBox
                            Using tbO As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox
                                Try

                                    Using Uint As New F.VoceRubrica
                                        Uint.Read(singUt.IdRubricaInt)
                                        tb.TransactionBegin()
                                        tbO.TransactionBegin()

                                        Uint.Pec = singUt.Pec
                                        Uint.CodiceSDI = singUt.CodiceSDI
                                        singUt.UpdateFromUser = enSiNo.No
                                        Uint.Save()
                                        singUt.Save()
                                        tb.TransactionCommit()
                                        tbO.TransactionCommit()
                                        Counter += 1
                                        'SCRIVERE NEL LOG DELLA RUBRICA
                                        FormerLib.FormerLog.ScriviVoceRubrica(Uint.IdRub, "AGGIORNATI DATI FISCALI DALL'UTENTE")

                                    End Using

                                Catch ex As Exception
                                    tb.TransactionRollBack()
                                    tbO.TransactionRollBack()
                                    LogMe("SORGENTE: SINCRONIZZAZIONE AGGIORNAMENTO DATI DA WEB cliente idUtOnline: " & singUt.IdUt & ", " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
                                End Try
                            End Using
                        End Using

                    Next

                End Using
                LogMe("SINCRONIZZATI DA WEB " & Counter)
                LogMe("***SINCRONIZZAZIONE AGGIORNAMENTO DATI DA WEB TERMINATO***")

                'LogMe("***SALVATAGGIO ULTIMA SINCRONIZZAZIONE***")
                'LastSincRub = Now
                'Using w As New StreamWriter(PathLastSincRub, False)
                '    w.Write(LastSincRub)
                'End Using

            Catch ex As Exception

                LogMe("SORGENTE: SincronizzaRubrica(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

            End Try

            GC.Collect()

        End Sub

        Private Shared Function OrdineOkOnline(OInt As F.Ordine) As Boolean
            Dim ris As Boolean = True

            If OInt.Preventivo = enSiNo.Si And OInt.Stato = enStatoOrdine.PagatoInteramente Then
                ris = False
            End If

            Return ris
        End Function

        Public Shared Sub CreaRubricaIntFromWeb(ByRef Uint As F.VoceRubrica, U As FW.Utente,
                                                Optional MetodoPagamento As enMetodoPagamento = enMetodoPagamento.PayPal)

            'qui devo salvare l'utente in rubrica 
            'o vedere se lo trovo tra i miei 
            '*********************SALVO NUOVO CLIENTE
            Uint.Tipo = U.TipoRub
            Uint.RagSoc = U.RagSoc
            Uint.Nome = U.Nome
            Uint.Cognome = U.Cognome
            Uint.CodFisc = U.CodFisc
            Uint.Piva = U.Piva
            Uint.Email = U.Email
            Uint.IdCorriere = U.IdCorriereDef
            Uint.Indirizzo = U.Indirizzo
            Uint.Tel = U.Tel
            Uint.Fax = U.Fax
            Uint.Cellulare = U.Cellulare
            Uint.CAP = U.Cap
            Uint.Citta = U.Citta
            Uint.IdPagamento = MetodoPagamento  'paypal predefinito
            Uint.SitoWeb = U.SitoWeb
            Uint.ScopertoMax = 1000
            Uint.IdUtOnline = U.IdUt
            Uint.Sorgente = "W"
            Uint.DataIns = U.DataIns
            Uint.IdProvincia = U.IdProvincia
            Uint.Provincia = U.Provincia
            Uint.IdComune = U.IdComune
            Uint.IdTipoAttivita = U.IdTipoAttivita
            Uint.TipoDoc = enTipoDocumento.Fattura
            Uint.NoEmail = U.NoMail
            Uint.StampaAutomaticaDocumenti = enSiNo.Si
            Uint.Pec = U.Pec
            Uint.CodiceSDI = U.CodiceSDI
            Uint.IdNazione = U.IdNazione
            Uint.PrefissoPiva = U.PrefissoPIva

        End Sub

        Private Shared Sub SincronizzaStatoOrdini()

            Dim CurrentThreadID As Integer = Threading.Thread.CurrentThread.ManagedThreadId
            'Dim LastSincOrd As Date = Now
            ''LogMe("***LEGGO ULTIMA SINCRONIZZAZIONE***")
            'If System.IO.File.Exists(PathLastSincOrd) Then
            '    Using r As New StreamReader(PathLastSincOrd)
            '        LastSincOrd = r.ReadToEnd
            '    End Using
            'End If

            Dim lOrd As List(Of F.Ordine) = Nothing
            Using mgr As New F.OrdiniDAO

                lOrd = mgr.ListaOrdiniByLastUpdate()

            End Using

            Dim lRubReview As New List(Of Integer)

            For Each OInt As F.Ordine In lOrd
                'lavoro ogni singolo ordine
                LogMe("Sincronizzo Lavoro Interno " & OInt.IdOrd)
                Try
                    Dim O As FW.OrdineWeb
                    Using mgrW As New FW.OrdiniWebDAO
                        Dim LOrdW As List(Of FW.OrdineWeb) = mgrW.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.IdOrdineInt, OInt.IdOrd))
                        If LOrdW.Count Then
                            O = LOrdW(0)
                        Else
                            O = New FW.OrdineWeb
                        End If
                    End Using

                    If OrdineOkOnline(OInt) Then
                        'ordine ok online
                        If O.IdOrdine = 0 Then
                            'ricreare l'ordine in base a quello interno
                            'CARICARE TUTTI I DATI DELL'ORDINE INTERNET CON I DATI DELL'oRDINE INTERNO
                            'CARICARE L'anteprima in ftp
                            'questo serve ancora per gli ordini duplicati

                            O.Stato = OInt.Stato
                            O.IdUt = OInt.VoceRubrica.IdUtOnline
                            O.IdOrdineInt = OInt.IdOrd
                            O.Altezza = OInt.Lungo
                            O.Larghezza = OInt.Largo
                            O.DataCambioStato = OInt.DataCambioStato
                            O.DataIns = OInt.DataIns
                            O.DataPrevConsegna = OInt.DataPrevConsegna
                            O.IdCorriere = OInt.IdCorriere
                            O.Lavorazioni = OInt.Lavorazioni
                            O.NumeroColli = OInt.Prodotto.NumColli
                            O.Peso = OInt.Prodotto.PesoComplessivo
                            O.Preventivo = OInt.Preventivo
                            O.PrezzoCalcolatoNetto = OInt.TotaleForn
                            O.OrdineInOmaggio = OInt.OrdineInOmaggio

                            O.ConsegnaGarantita = OInt.ConsegnaGarantita
                            O.ConsegnaGarantitaDa = OInt.ConsegnaGarantitaDa

                            O.Sconto = OInt.Sconto
                            O.Ricarico = OInt.Ricarico
                            O.NomeLavoro = OInt.NomeLavoro
                            O.Orientamento = OInt.Orientamento

                            O.PrezzoCorriere = OInt.CostoSped
                            O.TipoConsegna = OInt.TipoConsegna
                            O.TipoRetro = OInt.TipoRetro
                            O.Nfogli = OInt.NFogli

                            If OInt.Prodotto.IdListinoBase Then
                                O.Annotazioni = OInt.Annotazioni
                            Else
                                O.Annotazioni = OInt.Prodotto.Descrizione
                            End If

                            O.IdListinoBase = OInt.IdListinoBase
                            O.OrdineWeb = OInt.OrdMail

                            ''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                            'Dim QtaOrd As Integer = 0
                            'If OInt.IdProd Then
                            '    Dim P As New F.Prodotto
                            '    P.Read(OInt.IdProd)
                            '    If P.IdListinoBase Then
                            '        Dim L As New F.ListinoBase
                            '        L.Read(P.IdListinoBase)
                            '        If L.TipoPrezzo = enTipoPrezzo.SuQuantita Then
                            '            QtaOrd = O.qtaP.NumPezzi
                            '        ElseIf O.L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                            '            QtaOrd = O.Qta
                            '        ElseIf O.L.TipoPrezzo = enTipoPrezzo.SuCopie Then
                            '            QtaOrd = O.Qta
                            '        End If
                            '    Else
                            '        QtaOrd = P.NumPezzi
                            '    End If
                            'End If
                            'O.Qta = QtaOrd
                            O.Qta = OInt.QtaOrdine

                            'DA RIVEDERE DOPO NUOVA GESTIONE SORGENTI
                            Dim Pos As Integer = 0
                            For Each Sorgente In OInt.ListaSorgenti
                                If Pos = 0 Then
                                    O.SorgenteFronte = Path.GetFileName(Sorgente.FilePath.ToString())
                                ElseIf Pos = 1 Then
                                    O.SorgenteRetro = Path.GetFileName(Sorgente.FilePath.ToString())
                                End If

                                Pos += 1
                            Next

                            O.Save()
                            OInt.IdOrdOnline = O.IdOrdine
                            OInt.Save()

                            If OInt.FilePath.Length Then

                                Dim NomeFileTemp As String = OInt.FilePath

                                If System.IO.File.Exists(NomeFileTemp) Then

                                    Dim Fi As New FileInfo(NomeFileTemp)
                                    If Fi.Length < 1048576 Then
                                        Dim NomeAnteprima As String = Path.GetFileName(NomeFileTemp)
                                        Try
                                            Using Ftp As New FTPclient(FtpServer, FtpLogin, FtpPwd)

                                                Ftp.FtpCreateDirectory("tipografiaformer.it/ordini/" & O.IdOrdine)

                                                Dim NomeAnteprimaOnline As String = "/tipografiaformer.it/ordini/" & O.IdOrdine & "/" & NomeAnteprima

                                                Ftp.Upload(NomeFileTemp, NomeAnteprimaOnline)

                                            End Using
                                            O.Anteprima = NomeAnteprima
                                            Using mgrW As New FW.OrdiniWebDAO
                                                mgrW.SalvaAnteprima(O)
                                            End Using
                                        Catch ex As Exception
                                            LogMe("ERRORE UPLOAD ANTEPRIMA Lavoro " & OInt.IdOrd & ", MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, True, ex)
                                        End Try
                                    End If
                                End If
                            End If
                        Else
                            O.PrezzoCalcolatoNetto = OInt.TotaleForn
                            O.Sconto = OInt.Sconto
                            O.Ricarico = OInt.Ricarico

                            O.OrdineWeb = OInt.OrdMail
                            O.IdUt = OInt.VoceRubrica.IdUtOnline
                            O.Stato = OInt.Stato
                            O.Preventivo = OInt.Preventivo
                            O.DataCambioStato = OInt.DataCambioStato
                            O.Annotazioni = OInt.Annotazioni

                            O.Save()

                            If OInt.OrdineInOmaggio <> enSiNo.Si Then
                                Dim lC As List(Of F.CronoOrdine) = Nothing

                                Using mgrC As New F.CronoOrdiniDAO
                                    lC = mgrC.FindAll(New F.LUNA.LunaSearchParameter(F.LFM.CronoOrdine.IdOrd, OInt.IdOrd),
                                                      New F.LUNA.LunaSearchParameter(F.LFM.CronoOrdine.IdStato, OInt.Stato))
                                End Using
                                If lC.Count < 2 Then
                                    If OInt.Stato = enStatoOrdine.ProntoRitiro Then
                                        'TODO: GESTIRE IL FATTO CHE SE LA CONSEGNA E? BLOCCATA MANDA LA MAIL SOLO AL COMPELTAMENTO DELL?ULTIMO ORDINE DI TUTTA LA CONSEGNA
                                        If OInt.ConsegnaAssociata.IdCorr = enCorriere.RitiroCliente Then
                                            OInt.InviaMailCambioStato()
                                            LogMe("Inviata Mail cambio stato a Pronto Ritiro Idordine " & OInt.IdOrd)
                                        End If
                                    ElseIf OInt.Stato = enStatoOrdine.InConsegna Then

                                        If OInt.ConsegnaAssociata.IdCorr <> enCorriere.RitiroCliente Then
                                            OInt.InviaMailCambioStato()
                                            LogMe("Inviata Mail cambio stato a In Consegna Idordine " & OInt.IdOrd)
                                        End If

                                        'qui oltre a mandare l'email al cambio stato controllo che se non ha inserito ordini di questo tipo negli ultimi 30 giorni mando una mail 
                                        'per chiedere una recensione

                                        Using mgr As New F.OrdiniDAO

                                            Dim l As List(Of F.Ordine) = mgr.FindAll(New F.LUNA.LunaSearchParameter(F.LFM.Ordine.IdProd, "(select idprod from t_prodotti where idlistinobase = " & OInt.IdListinoBase & ")", " IN "),
                                                                                     New F.LUNA.LunaSearchParameter("DateDiff(""d"",DataIns,GetDate())", 30, "<="),
                                                                                     New F.LUNA.LunaSearchParameter(F.LFM.Ordine.IdRub, OInt.IdRub),
                                                                                     New F.LUNA.LunaSearchParameter(F.LFM.Ordine.IdOrd, OInt.IdOrd, " <> "))

                                            If l.Count = 0 Then

                                                If lRubReview.FindAll(Function(x) x = OInt.IdRub).Count = 0 Then

                                                    If OInt.ListinoBase.Preventivazione.DispOnline = True Then
                                                        'qui non ho mai trattato questa rubrica 
                                                        lRubReview.Add(OInt.IdRub)

                                                        If OInt.VoceRubrica.Email.Length <> 0 And OInt.VoceRubrica.Email <> FormerConst.EmailNonDisponibile Then
                                                            'qui posso mandare una email 
                                                            Dim M As New My.Templates.MailReview
                                                            M.U = OInt.VoceRubrica
                                                            M.O = OInt
                                                            Dim TestoMail As String = M.TransformText

                                                            LogMe("Inviata email x recensione a idrub= " & OInt.IdRub & " idlistinobase = " & OInt.IdListinoBase & " idord = " & OInt.IdOrd)

                                                            Try
                                                                FormerHelper.Mail.InviaMail("Aiutaci a migliorare, lascia una Recensione sul tuo recente ordine", TestoMail, OInt.VoceRubrica.Email)
                                                            Catch ex As Exception

                                                            End Try

                                                        End If
                                                    End If

                                                End If

                                            End If

                                        End Using

                                    End If

                                End If
                            End If

                        End If

                        'qui devo gestire la consegna dell'ordine online
                        'se la consegna non esiste la devo creare 

                        If O.IdCons = 0 Then

                        End If

                    Else
                        'ordine non ok online lo cancello se esisteva 
                        If O.IdOrdine Then
                            Using mgr As New FW.OrdiniWebDAO

                                Dim IdCons As Integer = O.IdCons
                                mgr.Delete(O.IdOrdine)

                                Using c As New FW.Consegna
                                    c.Read(IdCons)

                                    If c.ListaOrdini.Count = 0 Then

                                        Using mgrC As New FW.ConsegneDAO
                                            mgrC.Delete(IdCons)
                                        End Using

                                    End If

                                End Using

                            End Using
                        End If
                    End If

                    'levo il lastupdate dall'ordine
                    OInt.SetLastUpdate(enSiNo.No)

                Catch ex As Exception
                    LogMe("SORGENTE: SincronizzaStatoLavori(), Ordine Interno: " & OInt.IdOrd & " - " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

                End Try
            Next

            lOrd = Nothing

            'qui ripulisco tutti gli ordini online da piu di x giorni pagato interamente 
            'non piu necessario ci pensa quello che ripulisce le consegne
            'LogMe("***PULIZIA Lavori DA PIU GIORNI ***")
            'Using mgr As New FW.OrdiniWebDAO
            '    mgr.CleanFromOnline()
            'End Using

            'LogMe("***SALVATAGGIO ULTIMA SINCRONIZZAZIONE***")
            'LastSincOrd = Now
            'Using w As New StreamWriter(PathLastSincOrd, False)
            '    w.Write(LastSincOrd)
            'End Using

        End Sub

        Private Shared Sub AggiornaConsegnaOnlineFromInterna(ByRef ConsW As FW.Consegna,
                                                             ByRef ConsInt As F.ConsegnaProgrammata,
                                                             IdUtCons As Integer,
                                                             IdIndOnline As Integer)


            If ConsW Is Nothing Then
                ConsW = New FW.Consegna
                Dim GuidOrd As Guid = Guid.NewGuid()
                Dim GuidToSave As String = IdUtCons & "-" & GuidOrd.ToString
                ConsW.GuidTransazione = GuidToSave
                ConsW.Annotazioni = "Automatizzata"
            End If

            If ConsW.Blocco = enSiNo.Si Then
                'qui non devo fare niente sulla consegna tranne aggiornare giorno colli, peso e codtrack con lo stato 
                ConsW.Giorno = ConsInt.Giorno
                ConsW.CodTrack = ConsInt.CodTrack
                ConsW.IdStatoConsegna = ConsInt.IdStatoConsegna
                ConsW.NumColli = ConsInt.NumColli
                ConsW.Peso = ConsInt.Peso
            Else
                ConsW.IdConsegnaInt = ConsInt.IdCons
                ConsW.Annotazioni = ConsInt.Annotazioni
                ConsW.Giorno = ConsInt.Giorno
                ConsW.IdUt = IdUtCons
                ConsW.IdIndirizzo = IdIndOnline
                ConsW.IdCorriere = ConsInt.IdCorr
                ConsW.CodTrack = ConsInt.CodTrack
                ConsW.IdStatoConsegna = ConsInt.IdStatoConsegna
                ConsW.NumColli = ConsInt.NumColli
                ConsW.Peso = ConsInt.Peso
                ConsW.IdPagam = ConsInt.IdPagam
                ConsW.TipoDoc = ConsInt.TipoDoc
                ConsW.DataInserimento = Now
                ConsW.DataPrevistaOriginale = ConsInt.DataPrevistaOriginale
                ConsW.DataEffettiva = ConsInt.DataEffettiva
                ConsW.ImportoNetto = ConsInt.ImportoNetto
            End If

            ConsW.Save()

        End Sub

        Private Shared Sub SincronizzaStatoConsegne()

            Dim CurrentThreadID As Integer = Threading.Thread.CurrentThread.ManagedThreadId

            Dim lCons As List(Of F.ConsegnaProgrammata) = Nothing

            Using mgr As New F.ConsegneProgrammateDAO
                lCons = mgr.ListaConsegneByLastUpdate()
            End Using

            For Each ConsInt As F.ConsegnaProgrammata In lCons.ToList

                LogMe("Sincronizzo Consegna Interna " & ConsInt.IdCons)
                'Dim Conn As Data.Common.DbConnection = Nothing
                'Dim Trans As Data.Common.DbTransaction = Nothing
                Using TB As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox
                    Using mgr As New FW.ConsegneDAO
                        Try
                            If ConsInt.Eliminato Then 'qui la voce e' stata eliminata quindi sgancio gli ordini che erano legati a questa consegna

                                TB.TransactionBegin()
                                mgr.EliminaConsegnaByIDInt(ConsInt.IdCons)

                                Using mgrInt As New F.ConsegneProgrammateDAO
                                    mgrInt.Delete(ConsInt)
                                End Using
                                TB.TransactionCommit()

                            Else

                                'controllo prima se il destinatario della consegna è presente nella rubrica online altrimenti rimando al prossimo giro l'aggiornamento
                                Dim IdUtCons As Integer = 0
                                Dim IdIndirizzo As Integer = 0

                                Using mgrU As New FW.UtentiDAO
                                    Dim U As FW.Utente = Nothing
                                    Dim lU As List(Of FW.Utente) = mgrU.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.Utente.IdRubricaInt, ConsInt.IdRub))
                                    If lU.Count Then
                                        U = lU(0)
                                        IdUtCons = U.IdUt
                                    End If
                                End Using

                                If IdUtCons Then

                                    Dim OkOnline As Boolean = True

                                    If ConsInt.ListaOrdini.FindAll(Function(x) (x.Stato = enStatoOrdine.PagatoInteramente And x.Preventivo = enSiNo.Si)).Count = ConsInt.ListaOrdini.Count Then
                                        OkOnline = False
                                    End If

                                    If OkOnline Then
                                        Dim ListaIdOrd As String = ConsInt.ListaIdOrdini

                                        Dim IdIndOnline As Integer = 0

                                        If ConsInt.IdIndirizzo Then

                                            Using mgrI As New F.IndirizziDAO

                                                Dim Li As List(Of F.Indirizzo) = mgrI.FindAll(New F.LUNA.LunaSearchParameter(F.LFM.Indirizzo.IDIndirizzo, ConsInt.IdIndirizzo))

                                                IdIndOnline = Li(0).IdIndOnline

                                            End Using

                                        End If

                                        'qui cerco se esiste una consegna online per questa consegna interna
                                        Dim ConsW As FW.Consegna = Nothing
                                        Dim l As List(Of FW.Consegna) = Nothing
                                        Dim ConsegnaAppenaInserita As Boolean = False

                                        l = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.IdConsegnaInt, ConsInt.IdCons))

                                        If l.Count Then
                                            ConsW = l(0)
                                        Else
                                            'ConsW = New FW.Consegna
                                            'Dim GuidOrd As Guid = Guid.NewGuid()
                                            'Dim GuidToSave As String = IdUtCons & "-" & GuidOrd.ToString
                                            'ConsW.GuidTransazione = GuidToSave
                                            'ConsW.Annotazioni = "Automatizzata"
                                            ConsegnaAppenaInserita = True
                                        End If

                                        TB.TransactionBegin()

                                        AggiornaConsegnaOnlineFromInterna(ConsW, ConsInt, IdUtCons, IdIndOnline)

                                        ConsInt.IdConsOnline = ConsW.IdConsegna

                                        If ConsW.Blocco = enSiNo.No Then
                                            If ConsegnaAppenaInserita = False Then
                                                mgr.ResetOrdiniByIdCons(ConsW.IdConsegna)
                                            End If

                                            'ora collego gli ordini correttamente
                                            If ListaIdOrd.Length Then mgr.LegaOrdiniAConsegna(ConsW.IdConsegna, ListaIdOrd)

                                        End If

                                        TB.TransactionCommit()
                                        Dim IdByOrd As Integer = ConsW.GetIdUtentebyOrd

                                        If IdByOrd Then
                                            If IdByOrd <> ConsW.IdUt Then
                                                'ALLARME
                                                Try
                                                    FormerHelper.Mail.InviaMail("ERRORE Demone inconsistenza", "Errore inconsistenza consegna online id = " & ConsW.IdConsegna & " IdUtCons = " & ConsW.IdUt & " IdByOrd = " & IdByOrd, FormerConst.EmailAssistenzaTecnica)
                                                Catch ex As Exception

                                                End Try
                                            End If
                                        End If


                                        ''qui metto tutti i dati in modo da aggiornarla o caricarla nuova online
                                        'If ConsW.Blocco = enSiNo.Si Then
                                        '    'qui non devo fare niente sulla consegna tranne aggiornare giorno colli, peso e codtrack con lo stato 
                                        '    ConsW.Giorno = ConsInt.Giorno
                                        '    ConsW.CodTrack = ConsInt.CodTrack
                                        '    ConsW.IdStatoConsegna = ConsInt.IdStatoConsegna
                                        '    ConsW.NumColli = ConsInt.NumColli
                                        '    ConsW.Peso = ConsInt.Peso
                                        '    ConsW.Save()
                                        'Else
                                        '    ConsW.IdConsegnaInt = ConsInt.IdCons
                                        '    ConsW.Annotazioni = ConsInt.Annotazioni
                                        '    ConsW.Giorno = ConsInt.Giorno
                                        '    ConsW.IdUt = IdUtCons
                                        '    ConsW.IdIndirizzo = IdIndOnline
                                        '    ConsW.IdCorriere = ConsInt.IdCorr
                                        '    ConsW.CodTrack = ConsInt.CodTrack
                                        '    ConsW.IdStatoConsegna = ConsInt.IdStatoConsegna
                                        '    ConsW.NumColli = ConsInt.NumColli
                                        '    ConsW.Peso = ConsInt.Peso
                                        '    ConsW.IdPagam = ConsInt.IdPagam
                                        '    ConsW.TipoDoc = ConsInt.TipoDoc
                                        '    ConsW.DataInserimento = Now
                                        '    ConsW.DataPrevistaOriginale = ConsInt.DataPrevistaOriginale
                                        '    ConsW.DataEffettiva = ConsInt.DataEffettiva
                                        '    ConsW.ImportoNetto = ConsInt.ImportoNetto
                                        '    TB.TransactionBegin()

                                        '    ConsW.Save()

                                        '    If ConsegnaAppenaInserita = False Then
                                        '        mgr.ResetOrdiniByIdCons(ConsW.IdConsegna)
                                        '    End If

                                        '    'ora collego gli ordini correttamente
                                        '    If ListaIdOrd.Length Then mgr.LegaOrdiniAConsegna(ConsW.IdConsegna, ListaIdOrd)

                                        '    TB.TransactionCommit()

                                        '    If ConsW.GetIdUtentebyOrd <> ConsW.IdUt Then
                                        '        'ALLARME
                                        '        Try
                                        '            FormerHelper.Mail.InviaMail("ERRORE Demone inconsistenza", "Errore inconsistenza consegna online id = " & ConsW.IdConsegna & " IdUtCons = " & ConsW.IdUt & " IdByOrd = " & ConsW.GetIdUtentebyOrd, FormerConst.EmailAssistenzaTecnica)
                                        '        Catch ex As Exception

                                        '        End Try
                                        '    End If


                                        'End If

                                    End If
                                    'resetto il lastupdate
                                    ConsInt.LastUpdate = 0 '.SetLastUpdate(0)
                                    ConsInt.Save()

                                End If
                            End If

                        Catch ex As Exception
                            TB.TransactionRollBack()
                            LogMe("SORGENTE: SincronizzaStatoConsegne(), Consegna Interna: " & ConsInt.IdCons & " - " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

                        End Try
                    End Using
                End Using

            Next

            'qui ho lavorato tutte le consegne che sono cambiate, e cancello quelle piu vecchie di una settimana rispetto a ora che gira il processo 
            LogMe("***PULIZIA ORDINI VECCHI ***")

            Using tb As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox()
                Using mgr As New FW.ConsegneDAO
                    Try
                        tb.TransactionBegin()
                        mgr.CleanFromOnline()
                        tb.TransactionCommit()

                    Catch ex As Exception
                        tb.TransactionRollBack()
                        LogMe("SORGENTE: SincronizzaStatoConsegne(), Pulizia Ordini Vecchi - " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

                    End Try

                End Using
            End Using



        End Sub

    End Class

    Public Class RefineAutomatico
        'Inherits FormerService
        Private Shared Property MonitoraggioHotFolderAttivo As Boolean = False

        Private Shared Property MonitoraggioHotFolderStampaAttivo As Boolean = False

        Private Shared Sub HotFolderPostRefine(IdOrd As Integer) ', Path As String)

            Using O As New Ordine
                O.Read(IdOrd)

                If O.ListaSorgenti.Count = 1 AndAlso O.Commessa.ListaOrdini.Count = 1 Then
                    Dim Path As String = O.ListaSorgenti(0).FilePath
                    Dim IdHotFolderPostRefine As Integer = 0

                    IdHotFolderPostRefine = O.ListinoBase.IdHotFolderPostRefine

                    If IdHotFolderPostRefine Then

                        Using H As New HotFolder
                            H.Read(IdHotFolderPostRefine)

                            Dim PathDest As String = String.Empty
                            PathDest = H.Path & "\" & FormerLib.FormerHelper.File.EstraiNomeFile(Path)
                            Try
                                File.Copy(Path, PathDest, True)

                                'qui se la copia e' andata bene porto a pronta

                                If O.IdCom Then
                                    Using mgr As New CommesseDAO
                                        mgr.InserisciLog(O.Commessa, enStatoCommessa.Pronto, 0)
                                    End Using
                                End If

                            Catch ex As Exception
                                LogMe("ERRORE nella copia del file sorgente all'hotfolder post-refine: (IdOrdine " & IdOrd & ") da " & Path & " a " & PathDest,, ex)
                            End Try

                        End Using

                    End If
                End If
            End Using

        End Sub

        'Private Shared Sub MonitoraggioHotFolderStampa()

        '    If MonitoraggioHotFolderStampaAttivo = False Then
        '        LogMe("AVVIATO MONITORAGGIO HOTFOLDER STAMPA")

        '        LavoraPdfFattureGiaCreate()

        '        Try
        '            If FormerHelper.Web.IsPingable(FormerConfig.FConfiguration.Refine.Server) Then
        '                Dim wfStampa As New FileSystemWatcher
        '                wfStampa.Path = FormerPath.PathFattureTemp
        '                wfStampa.NotifyFilter = IO.NotifyFilters.DirectoryName
        '                wfStampa.NotifyFilter = wfStampa.NotifyFilter Or
        '                                            IO.NotifyFilters.FileName
        '                wfStampa.NotifyFilter = wfStampa.NotifyFilter Or
        '                                            IO.NotifyFilters.Attributes
        '                wfStampa.NotifyFilter = wfStampa.NotifyFilter Or
        '                                            IO.NotifyFilters.CreationTime

        '                AddHandler wfStampa.Created, AddressOf PrintFatturaEvent

        '                wfStampa.EnableRaisingEvents = True

        '                MonitoraggioHotFolderStampaAttivo = True

        '            Else
        '                LogMe("ERRORE: Il server HOTFOLDER STAMPA non è raggiungibile")
        '            End If

        '        Catch ex As Exception
        '            LogMe("ERRORE: Si è verificato un errore nel monitoraggio dei folder STAMPA",, ex)
        '        End Try
        '    End If


        'End Sub

        Private Shared Sub MonitoraggioHotFolder()

            If MonitoraggioHotFolderAttivo = False Then
                LogMe("AVVIATO MONITORAGGIO HOTFOLDER REFINE")

                Try
                    If FormerHelper.Web.IsPingable(FormerConfig.FConfiguration.Refine.Server) Then
                        Dim wfRefError As New FileSystemWatcher
                        wfRefError.Path = FormerPath.PathRefineError
                        wfRefError.NotifyFilter = IO.NotifyFilters.DirectoryName
                        wfRefError.NotifyFilter = wfRefError.NotifyFilter Or
                                                    IO.NotifyFilters.FileName
                        wfRefError.NotifyFilter = wfRefError.NotifyFilter Or
                                                    IO.NotifyFilters.Attributes

                        AddHandler wfRefError.Created, AddressOf RefineErrorEvent

                        wfRefError.EnableRaisingEvents = True

                        Dim wfRefWarning As New FileSystemWatcher
                        wfRefWarning.Path = FormerPath.PathRefineWarning
                        wfRefWarning.NotifyFilter = IO.NotifyFilters.DirectoryName
                        wfRefWarning.NotifyFilter = wfRefWarning.NotifyFilter Or
                                                    IO.NotifyFilters.FileName
                        wfRefWarning.NotifyFilter = wfRefWarning.NotifyFilter Or
                                                    IO.NotifyFilters.Attributes

                        AddHandler wfRefWarning.Created, AddressOf RefineWarningEvent

                        wfRefWarning.EnableRaisingEvents = True

                        Dim wfRefCancelled As New FileSystemWatcher
                        wfRefCancelled.Path = FormerPath.PathRefineCancelled
                        wfRefCancelled.NotifyFilter = IO.NotifyFilters.DirectoryName
                        wfRefCancelled.NotifyFilter = wfRefCancelled.NotifyFilter Or
                                                    IO.NotifyFilters.FileName
                        wfRefCancelled.NotifyFilter = wfRefCancelled.NotifyFilter Or
                                                    IO.NotifyFilters.Attributes

                        AddHandler wfRefCancelled.Created, AddressOf RefineCancelledEvent

                        wfRefCancelled.EnableRaisingEvents = True

                        Dim wfRefOK As New FileSystemWatcher
                        wfRefOK.Path = FormerPath.PathRefineSuccess
                        wfRefOK.NotifyFilter = IO.NotifyFilters.DirectoryName
                        wfRefOK.NotifyFilter = wfRefOK.NotifyFilter Or
                                                    IO.NotifyFilters.FileName
                        wfRefOK.NotifyFilter = wfRefOK.NotifyFilter Or
                                                    IO.NotifyFilters.Attributes

                        AddHandler wfRefOK.Created, AddressOf RefineSuccessEvent

                        wfRefOK.EnableRaisingEvents = True

                        MonitoraggioHotFolderAttivo = True

                    Else
                        LogMe("ERRORE: Il server Refine non è raggiungibile")
                    End If

                Catch ex As Exception
                    LogMe("ERRORE: Si è verificato un errore nel monitoraggio dei folder Refine",, ex)
                End Try
            End If

        End Sub

        Private Shared Sub RefineWarningEvent(ByVal source As Object,
                                         ByVal e As System.IO.FileSystemEventArgs)
            'l'evento si scatena al momento in cui un file viene creato nella cartella OK
            'MessageBox.Show(e.FullPath & " " & e.ChangeType.ToString)
            'l'evento si scatena al momento in cui un file viene creato nella cartella KO
            'MessageBox.Show(e.FullPath & " " & e.ChangeType.ToString)
            Dim IdOrd As Integer = 0
            Dim PathResult As String = String.Empty
            Using mgr As New FileSorgentiDAO
                Dim l As List(Of FileSorgente) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FileSorgente.FilePath, "%\" & e.Name, "LIKE"))

                If l.Count Then
                    Dim f As FileSorgente = l(0)
                    If f.StatoRefine = enStatoRefineSorgente.NonDefinito Or
                        f.StatoRefine = enStatoRefineSorgente.InAttesaDiRefine Then

                        Try
                            'qui il file va sovrascritto se e' finita la copia 
                            'questo serve ad aspettare se il file e' ancora lockato dal sistema
                            PathResult = FormerConfig.FormerPath.PathRefineResult & e.Name

                            Dim ris As Boolean = FormerHelper.File.IsFileLocked(PathResult)

                            If ris Then

                                While ris
                                    Threading.Thread.Sleep(1000)
                                    ris = FormerHelper.File.IsFileLocked(PathResult)
                                End While

                            End If

                            File.Copy(PathResult, f.FilePath, True)
                            f.StatoRefine = enStatoRefineSorgente.CompletatoWarning
                            f.Save()
                            IdOrd = f.IdOrd

                        Catch ex As Exception
                            LogMe("ERRORE nella copia del file OK dopo il refine al path originale: (IdOrdine " & f.IdOrd & ") da " & PathResult & " a " & f.FilePath,, ex)
                        End Try
                    End If
                End If
            End Using

            'If IdOrd Then
            '    RefineSetOrderStatus(IdOrd)

            '    'qui devo gestire gli hot folder post refine
            '    HotFolderPostRefine(IdOrd, PathResult)
            'End If

        End Sub

        Private Shared Sub RefineSuccessEvent(ByVal source As Object,
                                         ByVal e As System.IO.FileSystemEventArgs)
            'l'evento si scatena al momento in cui un file viene creato nella cartella OK
            'MessageBox.Show(e.FullPath & " " & e.ChangeType.ToString)
            'l'evento si scatena al momento in cui un file viene creato nella cartella KO
            'MessageBox.Show(e.FullPath & " " & e.ChangeType.ToString)
            Dim IdOrd As Integer = 0
            Dim PathResult As String = String.Empty
            Using mgr As New FileSorgentiDAO
                Dim l As List(Of FileSorgente) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FileSorgente.FilePath, "%\" & e.Name, "LIKE"))

                If l.Count Then
                    Dim f As FileSorgente = l(0)
                    If f.StatoRefine = enStatoRefineSorgente.NonDefinito Or
                        f.StatoRefine = enStatoRefineSorgente.InAttesaDiRefine Then

                        Try
                            'qui il file va sovrascritto se e' finita la copia 
                            'questo serve ad aspettare se il file e' ancora lockato dal sistema
                            PathResult = FormerConfig.FormerPath.PathRefineResult & e.Name

                            Dim ris As Boolean = FormerHelper.File.IsFileLocked(PathResult)

                            If ris Then

                                While ris
                                    Threading.Thread.Sleep(1000)
                                    ris = FormerHelper.File.IsFileLocked(PathResult)
                                End While

                            End If

                            File.Copy(PathResult, f.FilePath, True)
                            f.StatoRefine = enStatoRefineSorgente.CompletatoSuccess
                            f.Save()
                            IdOrd = f.IdOrd

                        Catch ex As Exception
                            LogMe("ERRORE nella copia del file OK dopo il refine al path originale: (IdOrdine " & f.IdOrd & ") da " & PathResult & " a " & f.FilePath,, ex)
                        End Try
                    End If
                End If
            End Using

            'If IdOrd Then
            '    RefineSetOrderStatus(IdOrd)
            '    'qui devo gestire gli hot folder post refine
            '    HotFolderPostRefine(IdOrd, PathResult)
            'End If

        End Sub

        Private Shared Sub RefineCancelledEvent(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
            'l'evento si scatena al momento in cui un file viene creato nella cartella KO
            'MessageBox.Show(e.FullPath & " " & e.ChangeType.ToString)
            Dim IdOrd As Integer = 0
            Using mgr As New FileSorgentiDAO
                Dim l As List(Of FileSorgente) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FileSorgente.FilePath, "%\" & e.Name, "LIKE"))

                If l.Count Then
                    Dim f As FileSorgente = l(0)
                    If f.StatoRefine = enStatoRefineSorgente.NonDefinito Or f.StatoRefine = enStatoRefineSorgente.InAttesaDiRefine Then
                        f.StatoRefine = enStatoRefineSorgente.CompletatoCancelled
                        f.Save()
                        IdOrd = f.IdOrd
                    End If
                End If
            End Using

            If IdOrd Then
                RefineSetOrderStatus(IdOrd)
            End If
        End Sub

        'Private Shared Sub PrintFatturaEvent(ByVal source As Object,
        '                                     ByVal e As System.IO.FileSystemEventArgs)

        '    LogMe(" - Lavoro da evento File Fattura Temp " & e.Name)

        '    LavoraPDFFatturaTemp(e.Name, e.FullPath)

        'End Sub

        Private Shared Sub RefineErrorEvent(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
            'l'evento si scatena al momento in cui un file viene creato nella cartella KO
            'MessageBox.Show(e.FullPath & " " & e.ChangeType.ToString)
            Dim IdOrd As Integer = 0
            Using mgr As New FileSorgentiDAO
                Dim l As List(Of FileSorgente) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FileSorgente.FilePath, "%\" & e.Name, "LIKE"))

                If l.Count Then
                    Dim f As FileSorgente = l(0)
                    If f.StatoRefine = enStatoRefineSorgente.NonDefinito Or f.StatoRefine = enStatoRefineSorgente.InAttesaDiRefine Then
                        f.StatoRefine = enStatoRefineSorgente.CompletatoErrore
                        f.Save()
                        IdOrd = f.IdOrd
                    End If
                End If
            End Using

            'If IdOrd Then
            '    RefineSetOrderStatus(IdOrd)
            'End If
        End Sub

        Private Shared Function RefineSetOrderStatus(IdOrd As Integer) As enStatoOrdine
            Dim ris As enStatoOrdine = 0
            Using singO As New Ordine
                singO.Read(IdOrd)

                If singO.Stato = enStatoOrdine.RefineAutomatico Then
                    Dim ListaSorgenti As List(Of FileSorgente) = singO.ListaSorgenti

                    If ListaSorgenti.FindAll(Function(x) x.StatoRefine > enStatoRefineSorgente.InAttesaDiRefine).Count = ListaSorgenti.Count Then
                        'se entra qui tutti i sorgenti sono stati presi in considerazione 
                        'altrimenti devo aspettare il prossimo giro
                        Using mgr As New OrdiniDAO
                            If ListaSorgenti.FindAll(Function(x) x.StatoRefine = enStatoRefineSorgente.CompletatoErrore).Count <> 0 OrElse
                                ListaSorgenti.FindAll(Function(x) x.StatoRefine = enStatoRefineSorgente.CompletatoCancelled).Count <> 0 Then
                                'qui almeno uno e' andato in errore
                                singO.PreRefineErrorCode += enErroriPreRefine.ErroreRefinePrinergy
                                singO.Save()
                                mgr.InserisciLog(singO, enStatoOrdine.Preinserito,, False)
                                ris = enStatoOrdine.Preinserito
                            Else
                                mgr.InserisciLog(singO, enStatoOrdine.Registrato,, False)
                                ris = enStatoOrdine.Registrato
                            End If
                        End Using
                    End If
                End If

            End Using
            Return ris
        End Function

        Private Shared Sub RefineAutomaticoOrdini()
            LogMe("***REFINE AUTOMATICO ORDINI***")

            Try
                'qui prima azzero tutti quelli che sono ancora in stato in attesa 
                'Using mgr As New FileSorgentiDAO
                '    mgr.AzzeraSorgentiRefine()
                'End Using

                'qui si entra con gli ordini in refine automatico e si esce che comunque vada hannoc ambiato stato
                Using mgr As New OrdiniDAO

                    Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.RefineAutomatico))

                    For Each singO As Ordine In l
                        'qui devo solo spostare tutti i sorgenti dell'ordine nella cartella di refine 
                        'Dim CambiatoQualcosa As Boolean = False

                        For Each sorg As FileSorgente In singO.ListaSorgenti
                            If sorg.StatoRefine = enStatoRefineSorgente.NonDefinito Then
                                Dim NuovoPath As String = String.Empty
                                Try
                                    Dim RisCopia As enStatoRefineSorgente = NewOrder.CopiaSorgenteToRefine(sorg.FilePath)
                                    sorg.StatoRefine = RisCopia
                                    sorg.Save()
                                Catch ex As Exception
                                    'qui per ora non faccio niente verra, ripreso in carico al giro successivo
                                    'se poi qualche ordine si incastra vediamo che fare
                                End Try
                            ElseIf sorg.StatoRefine = enStatoRefineSorgente.InAttesaDiRefine Then
                                'qui posso controllare in quale cartella si trova in caso sia rimasto appeso per qualche motivo
                                'se rimane appeso lo cerco prima in warning poi in error poi in success
                                Dim NomeSorgente As String = FormerLib.FormerHelper.File.EstraiNomeFile(sorg.FilePath)
                                Dim PathToCheck As String = FormerPath.PathRefineError & NomeSorgente

                                If File.Exists(PathToCheck) Then
                                    'qui e' andato in errore
                                    sorg.StatoRefine = enStatoRefineSorgente.CompletatoErrore
                                    sorg.Save()
                                    'CambiatoQualcosa = True
                                Else
                                    'controllo i warning
                                    PathToCheck = FormerPath.PathRefineWarning & NomeSorgente
                                    If File.Exists(PathToCheck) Then
                                        'qui è andato in warning
                                        Dim PathResult As String = String.Empty
                                        Try
                                            'qui il file va sovrascritto se e' finita la copia 
                                            'questo serve ad aspettare se il file e' ancora lockato dal sistema
                                            PathResult = FormerConfig.FormerPath.PathRefineResult & NomeSorgente

                                            Dim ris As Boolean = FormerHelper.File.IsFileLocked(PathResult)
                                            Dim OkLock As Boolean = False

                                            If ris Then
                                                Dim MaxVolte As Integer = 0
                                                While ris = True And MaxVolte < 10
                                                    Threading.Thread.Sleep(1000)
                                                    ris = FormerHelper.File.IsFileLocked(PathResult)
                                                    MaxVolte += 1
                                                End While

                                                If ris = False Then OkLock = True

                                            Else
                                                OkLock = True
                                            End If

                                            If OkLock Then
                                                File.Copy(PathResult, sorg.FilePath, True)
                                                sorg.StatoRefine = enStatoRefineSorgente.CompletatoWarning
                                                sorg.Save()
                                                'CambiatoQualcosa = True
                                            End If

                                        Catch ex As Exception
                                            LogMe("ERRORE nella copia del file OK dopo il refine al path originale: (IdOrdine " & sorg.IdOrd & ") da " & PathResult & " a " & sorg.FilePath,, ex)
                                        End Try
                                    Else
                                        'qui controllo success
                                        PathToCheck = FormerPath.PathRefineSuccess & NomeSorgente
                                        If File.Exists(PathToCheck) Then
                                            'qui è andato in warning
                                            Dim PathResult As String = String.Empty
                                            Try
                                                'qui il file va sovrascritto se e' finita la copia 
                                                'questo serve ad aspettare se il file e' ancora lockato dal sistema
                                                PathResult = FormerConfig.FormerPath.PathRefineResult & NomeSorgente

                                                Dim ris As Boolean = FormerHelper.File.IsFileLocked(PathResult)
                                                Dim OkLock As Boolean = False

                                                If ris Then
                                                    Dim MaxVolte As Integer = 0
                                                    While ris = True And MaxVolte < 10
                                                        Threading.Thread.Sleep(1000)
                                                        ris = FormerHelper.File.IsFileLocked(PathResult)
                                                        MaxVolte += 1
                                                    End While

                                                    If ris = False Then OkLock = True

                                                Else
                                                    OkLock = True
                                                End If

                                                If OkLock Then
                                                    File.Copy(PathResult, sorg.FilePath, True)
                                                    sorg.StatoRefine = enStatoRefineSorgente.CompletatoSuccess
                                                    sorg.Save()
                                                    'CambiatoQualcosa = True
                                                End If

                                            Catch ex As Exception
                                                LogMe("ERRORE nella copia del file OK dopo il refine al path originale: (IdOrdine " & sorg.IdOrd & ") da " & PathResult & " a " & sorg.FilePath,, ex)
                                            End Try
                                        End If
                                    End If

                                End If

                            End If
                        Next
                        'qui controllo se tutti i sorgenti sono stati lavorati se metterlo a preinserito o registrato.

                        'If CambiatoQualcosa Then
                        Dim RisReset As enStatoOrdine = RefineSetOrderStatus(singO.IdOrd)

                        If RisReset = enStatoOrdine.Registrato Then
                            If singO.OrdineInOmaggio <> enSiNo.Si Then
                                If NewOrder.CreaCommessaAutomatica(singO) Then
                                    HotFolderPostRefine(singO.IdOrd)
                                End If
                                'qui devo vedere se mandare tutto in hotfolder post refine 

                            End If

                        End If

                        'End If

                    Next

                End Using
            Catch ex As Exception
                LogMe("Errore Refine Automatico", , ex)
            End Try

            LogMe("***REFINE AUTOMATICO ORDINI TERMINATO***")

        End Sub

        Private Shared Property StatoServizioSpecifico As enStatoServizio = enStatoServizio.NonAttivo

        Public Shared Sub StartService()

            If StatoServizioSpecifico = enStatoServizio.NonAttivo Then
                ' LO IMPOSTO COSI E POSSO CHIAMARLO OVUNQUE PER FARE IL REFINE SIA SU RICHIESTA CHE NON 
                StatoServizioSpecifico = enStatoServizio.Attivo

                'LogMe("***Refine Automatico***")

                Try

                    MonitoraggioHotFolder()

                    'MonitoraggioHotFolderStampa()

                    RefineAutomaticoOrdini()

                Catch ex As Exception
                    LogMe("SORGENTE: Refine Automatico(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
                End Try

                'LogMe("***Refine Automatico TERMINATO***")
                StatoServizioSpecifico = enStatoServizio.NonAttivo
            Else
                LogMe("Richiesta di Refine Automatico scartata perchè il servizio era già in esecuzione")
            End If

        End Sub

    End Class

    Public Class NewOrder
        'Inherits FormerService

        Public Shared Property ScaricamentoInCorso As Boolean = False

        Public Shared Sub StartService()
            Stato = enStatoServizio.Attivo

            LogMe("***Nuovi Ordini***")

            Try
                If Postazione.Network.ConnessioneInternetDisponibile AndAlso
                    Postazione.Network.ConnessioneDbRemotoDisponibile Then
                    ScaricamentoInCorso = True
                    ScaricaNuoviOrdini()
                    ScaricamentoInCorso = False
                    'Else
                    '    Throw New Exception("NUOVI ORDINI - Connessione internet non disponibile")
                End If
            Catch ex As Exception
                ScaricamentoInCorso = False
                LogMe("SORGENTE: Nuovi Ordini(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try

            LogMe("***Nuovi Ordini TERMINATO***")
            Stato = enStatoServizio.NonAttivo

        End Sub

        Friend Shared Function CopiaSorgenteToRefine(FilePath As String) As enStatoRefineSorgente

            Dim ris As enStatoRefineSorgente = enStatoRefineSorgente.NonDefinito

            Try
                'qui copio il file solo nella cartella di refine e se tutto va bene ritorno lo stato enStatoRefineSorgente.InAttesaDiRefine 
                If FormerHelper.Web.IsPingable(FormerConfig.FConfiguration.Refine.Server) Then
                    Dim NewPath As String = FormerPath.PathRefineStart & FormerHelper.File.EstraiNomeFile(FilePath)

                    File.Copy(FilePath, NewPath, True)

                    ris = enStatoRefineSorgente.InAttesaDiRefine
                End If

            Catch ex As Exception
                LogMe("Errore copia Sorgente to Refine Start: " & ex.Message)
            End Try

            Return ris

        End Function

        Private Shared Sub CheckValiditaPromoAutomatici()

            'SCARICO GLI ORDINI 
            LogMe("***CHECK VALIDITA PROMO AUTOMATICI***")
            Try
                Using mgr As New FW.PromoWDAO
                    Dim l As List(Of FW.PromoW) = mgr.FindAll(New FW.LUNA.LSP(FW.LFM.PromoW.Automatico, enSiNo.Si))

                    For Each promoonline In l
                        Using Mgrl As New ListinoBaseDAO
                            Using SingL As New ListinoBase
                                SingL.Read(promoonline.IdListinoBase)

                                Dim lbP As New RisPromoSuLB(SingL)

                                lbP.FatturatoMensileTotale = Mgrl.GetFatturatoNelMese(lbP.IdListinoBase)
                                lbP.FatturatoMensileConPromo = Mgrl.GetFatturatoNelMese(lbP.IdListinoBase,,, True)

                                If promoonline.Stato = enStato.Attivo Then
                                    'PROMO ATTIVO CONTORLLO SE PER CASO VA DISATTIVATO
                                    If lbP.PercentualeSuFatturato >= lbP.ListinoBase.PercMaxPromoFatturato Then
                                        promoonline.Stato = enStato.NonAttivo
                                    End If
                                Else
                                    'PROMO NON ATTIVO CONTORLLO SE PER CASO SI DEBBA RIATTIVARE
                                    If lbP.PercentualeSuFatturato < lbP.ListinoBase.PercMaxPromoFatturato Then
                                        promoonline.Stato = enStato.Attivo
                                    End If
                                End If

                                If promoonline.IsChanged Then
                                    LogMe("***PROMO " & promoonline.IdPromo & " su '" & SingL.Nome & "' CAMBIATO lo salvo***")
                                    promoonline.Save()
                                End If

                            End Using
                        End Using

                    Next

                End Using


            Catch ex As Exception

            End Try

            LogMe("***FINE CHECK VALIDITA PROMO AUTOMATICI***")
        End Sub

        Private Shared Sub ScaricaNuoviOrdini()

            Dim CurrentThreadID As Integer = Threading.Thread.CurrentThread.ManagedThreadId

            'SCARICO GLI ORDINI 
            LogMe("***SCARICAMENTO ORDINI***")
            Try

                Dim TotOrdiniScaricati As Integer = 0
                TotOrdiniScaricati += ScaricaNuoviOrdiniStandard()
                Threading.Thread.Sleep(5000)
                TotOrdiniScaricati += ScaricaNuoviOrdiniConBlocco()
                Threading.Thread.Sleep(1000)

                'QUI VADO A RICONTROLLARE SE DEVO SPENGERE O RIACCENDERE I PROMO AUTOMATICI ATTIVI AL MOMENTO SUL SITO

                CheckValiditaPromoAutomatici

                RefineAutomatico.StartService()

                'QUI PER GLI ORDINI DI REPARTI NON OFFSET RICREO LE COMMESSE IN CASO NON SIANO PIU PRESENTI
                'LO FACCIO QUI PER EVITARE CHE ALTRI PROCESSI VADANO IN CONTRASTO CON QUESTO E SI SOVRAPPONGANO
                RiCreaCommesseMancanti()

                If TotOrdiniScaricati Then

                    FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Notifica, "Scaricati " & TotOrdiniScaricati & " nuovi ordini.", FormerLib.FormerUDP.DestUDP_Admin)

                End If

                CreazioneAutomaticaCommesseEx()

            Catch ex As Exception
                LogMe("SORGENTE: ScaricaNuoviOrdini(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try

            GC.Collect()

        End Sub

        Public Shared Sub RiCreaCommesseMancanti()
            LogMe("***RICREAZIONE AUTOMATICA COMMESSE MANCANTI***")
            Using mgr As New OrdiniDAO
                Dim Counter As Integer = 0
                Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdCom, 0),
                                                       New LUNA.LunaSearchParameter(LFM.Ordine.IdTipoProd, enTipoProdCom.StampaOffSet, "<>"),
                                                       New LUNA.LunaSearchParameter(LFM.Ordine.IdTipoProd, enTipoProdCom.Packaging, "<>"),
                                                       New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.Registrato))

                For Each O As Ordine In l
                    CreaCommessaAutomatica(O)
                    Counter += 1
                Next
                LogMe("Ricreate " & Counter & " commesse")
            End Using

        End Sub

        Public Shared Sub CreazioneAutomaticaCommesseEx()

            'DA RIATTIVARE IN CASO SI VUOLE USCIRE SENZA CREARE LE COMMESSE IN AUTOMATICO
            'Exit Sub
            Dim lCom As New List(Of Integer)
            Try
                LogMe("Creazione Automatica Commesse")

                Dim ParametriImpostati As New ParametriCreazioneSoluzione
                ParametriImpostati.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreBeta
                ParametriImpostati.CreazioneAutomaticaCommesse = True
                ParametriImpostati.MaxDuplicazioneSingoloOrdine = 10
                ParametriImpostati.SoloSoluzioniOttimali = True
                ParametriImpostati.UtilizzaSoloMacchinarioDefault = True
                ParametriImpostati.PermettiQtaMinoreOrdini = False

                Dim LstStati As String = enStatoOrdine.Registrato

                Dim L As List(Of OrdineRicerca)
                Dim LNew As New List(Of OrdineRicerca)
                Using OMgr As New OrdiniDAO
                    L = OMgr.Lista(, LstStati, , True, , , , , , , , , , enTipoProdCom.StampaOffSet, True)
                    For Each O As Ordine In L
                        If MgrOrderLock.IsLocked(O.IdOrd) = False Then
                            LNew.Add(O)
                        End If
                    Next

                End Using

                L = LNew

                Dim lSol As List(Of Soluzione) = MotoreCalcoloSoluzioni.ProponiSoluzioni(L, ParametriImpostati)

                'Dim SoluzionePerfetta As Soluzione = lSol.Find(Function(x) x.TipoSoluzione = enTipoSoluzione.Perfetta)

                'For Each soluz As Soluzione In lSol
                '    MessageBox.Show(soluz.TipoSoluzione & " - " & soluz.Commesse.Count)
                'Next

                If Not lSol Is Nothing Then
                    For Each s As Soluzione In lSol
                        For Each Commessa As CommessaProposta In s.Commesse
                            'qui posso valutare che le cose vadano bene per la creazione automatizzata della commessa
                            Using mgr As New CommesseDAO
                                Dim IdCom As Integer = mgr.CreaCommessaAutomaticaOffset(Commessa)
                                If IdCom Then
                                    lCom.Add(IdCom)
                                    LogMe(" - Creata commessa automatica " & IdCom)
                                    'QUI DEVO FARE LE OPERAZIONI DI POST CREAZIONE COMMESSA AUTOMATICA

                                    'EXPORT CTP?
                                    Using com As New Commessa
                                        com.Read(IdCom)
                                        Dim collOrd As OrdiniCTP = MgrCTP.GetListaOrdiniCTP(com)
                                        'LogMe(" - Export CTP Commessa " & IdCom)
                                        'Dim risExportCtp As Integer = MgrCTP.EsportaCTP(collOrd)

                                        'If risExportCtp = 1 Then LogMe("ERRORE: Nel modello commessa scelto non è presente un formato prodotto specifico o generico da cui poter capire l'orientamento. I file sorgenti NON sono stati quindi orientati")

                                        LogMe(" - Export JOB Commessa " & IdCom)
                                        Dim risExportJOB As Integer = MgrCTP.EsportaJOB(com.IdCom, collOrd)
                                        If risExportJOB = 1 Then LogMe("ERRORE: Si è verificato un errore nell' export del File JOB. Eseguire di nuovo l'operazione")

                                    End Using

                                End If
                            End Using
                        Next
                    Next
                End If

                LogMe("Creazione Automatica Commesse Terminata. Create " & lCom.Count & " Commesse")
            Catch ex As Exception
                LogMe("ERRORE Creazione Automatica Commesse",, ex)
            End Try

            If lCom.Count Then
                FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Notifica, "Create automaticamente " & lCom.Count & " commesse.", FormerLib.FormerUDP.DestUDP_Admin)
            End If

        End Sub
        'Public Shared Sub CreazioneAutomaticaCommesse()

        '    'DA RIATTIVARE IN CASO SI VUOLE USCIRE SENZA CREARE LE COMMESSE IN AUTOMATICO
        '    'Exit Sub
        '    Dim lCom As New List(Of Integer)
        '    Try
        '        LogMe("Creazione Automatica Commesse")

        '        Dim ParametriImpostati As ParametriCreazioneSoluzione = Nothing

        '        ParametriImpostati = New ParametriCreazioneSoluzione

        '        ParametriImpostati.CreazioneAutomaticaCommesse = True
        '        ParametriImpostati.NonMostrareTutteCombinazioni = True
        '        'ParametriImpostati.TieniContoLavorazioniEsclusive = True
        '        'ParametriImpostati.TieniContoRating = True
        '        ParametriImpostati.MaxDuplicazioneSingoloOrdine = 20
        '        ParametriImpostati.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreStabile

        '        Dim LstStati As String = enStatoOrdine.Preinserito & "," & enStatoOrdine.Registrato

        '        Dim L As List(Of OrdineRicerca)

        '        Using OMgr As New OrdiniDAO
        '            L = OMgr.Lista(, LstStati, , True, , , , , , , , , , enTipoProdCom.StampaOffSet, True)
        '        End Using

        '        Dim lSol As List(Of Soluzione) = MotoreCalcoloSoluzioni.ProponiSoluzioni(L, ParametriImpostati)

        '        Dim SoluzionePerfetta As Soluzione = lSol.Find(Function(x) x.TipoSoluzione = enTipoSoluzione.Perfetta)

        '        'For Each soluz As Soluzione In lSol
        '        '    MessageBox.Show(soluz.TipoSoluzione & " - " & soluz.Commesse.Count)
        '        'Next

        '        If Not SoluzionePerfetta Is Nothing Then
        '            For Each Commessa As CommessaProposta In SoluzionePerfetta.Commesse
        '                'qui posso valutare che le cose vadano bene per la creazione automatizzata della commessa
        '                Using mgr As New CommesseDAO
        '                    Dim IdCom As Integer = mgr.CreaCommessaAutomaticaOffset(Commessa)
        '                    If IdCom Then
        '                        lCom.Add(IdCom)
        '                        LogMe(" - Creata commessa automatica " & IdCom)
        '                        'Else
        '                        '    FormerHelper.Mail.InviaMail("Errore Creazione commesse automatiche", "Errore, IdCom = 0 Commessa Firma " & Commessa.Firma, "soft@tipografiaformer.it")
        '                    End If
        '                End Using
        '            Next
        '        End If

        '        LogMe("Creazione Automatica Commesse Terminata. Create " & lCom.Count & " Commesse")
        '    Catch ex As Exception
        '        LogMe("ERRORE Creazione Automatica Commesse",, ex)
        '    End Try

        '    If lCom.Count Then
        '        FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_Notifica, "Create automaticamente " & lCom.Count & " commesse.", FormerUDP.DestUDP_Admin)
        '    End If

        'End Sub

        Private Shared Sub GestisciOrdiniConPlugin(L As F.ListinoBase, ByRef Oint As F.Ordine, O As FW.OrdineWeb)

            'QUI VA GESTITA LA CREAZIONE DELLA FUSTELLA

            Select Case L.Preventivazione.IdPluginToUse 'L.Preventivazione.IdPluginToUse

                Case enPluginOnline.Packaging
                    If L.Preventivazione.IdFunzionePack <> 0 Then 'per il packaging e' obbligatoria la funzione di packaging da selezionare
                        If O.IdTipoFustella = 0 Then
                            If O.Altezza <> 0 And O.Profondita <> 0 And O.Larghezza <> 0 Then
                                Using mgr As New F.TipoFustelleDAO
                                    Dim lFustelle As List(Of F.TipoFustella) = mgr.GetAll()
                                    Dim SingF As F.TipoFustella = lFustelle.Find(Function(x) x.IdPrev = L.Preventivazione.IdPrev And
                                                                                        x.Altezza = O.Altezza And
                                                                                        x.Base = O.Larghezza And
                                                                                        x.Profondita = O.Profondita)
                                    Dim IdTipoFustellaDaUsare As Integer = 0
                                    If SingF Is Nothing Then
                                        'fustella da creare
                                        LogMe("Creato Nuovo Tipo Fustella " & O.Larghezza & "x" & O.Profondita & "x" & O.Altezza & ", Ordine Online " & O.IdOrdine)

                                        SingF = New F.TipoFustella
                                        SingF.IdPrev = L.Preventivazione.IdPrev
                                        SingF.Disponibile = enSiNo.Si
                                        SingF.Profondita = O.Profondita
                                        SingF.Altezza = O.Altezza
                                        SingF.Base = O.Larghezza
                                        IdTipoFustellaDaUsare = SingF.Save()

                                        SingF.Codice = "F" & SingF.IdTipoFustella
                                        SingF.Save()

                                        'LA INSERISCO PURE ONLINE
                                        Dim IdTipoFustellaOnline As Integer = 0
                                        Dim SingFW As New FW.TipoFustellaW
                                        SingFW.IdPrev = L.Preventivazione.IdPrev
                                        SingFW.Disponibile = enSiNo.Si
                                        SingFW.Profondita = O.Profondita
                                        SingFW.Altezza = O.Altezza
                                        SingFW.Base = O.Larghezza
                                        SingFW.CODICE = SingF.Codice
                                        IdTipoFustellaOnline = SingFW.Save()

                                    Else
                                        IdTipoFustellaDaUsare = SingF.IdTipoFustella
                                    End If
                                    Oint.IdTipoFustella = IdTipoFustellaDaUsare
                                End Using
                            End If
                        Else
                            'fustella gia esistente
                            Oint.IdTipoFustella = O.IdTipoFustella
                        End If
                    End If

                Case enPluginOnline.Etichette
                    'la fustella qui gia esiste obbligatoriamente
                    Oint.IdTipoFustella = O.IdTipoFustella

                Case enPluginOnline.EtichetteCm
                    'qui in realta non devo fare nulla

            End Select

        End Sub

        Private Shared Function ScaricaNuoviOrdiniStandard() As Integer
            Dim ris As Integer = 0

            'SCARICO GLI ORDINI 
            LogMe("***SCARICAMENTO NUOVI LAVORI STANDARD***")
            Try
                Dim OrdiniTrovati As Integer = 0
                Dim OrdiniScaricati As Integer = 0
                Dim LOrd As List(Of FW.OrdineWeb) = Nothing
                Using mgr As New FW.OrdiniWebDAO
                    LOrd = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.Stato, CInt(enStatoOrdine.Preinserito)),
                                       New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.StatoWeb, CInt(enStato.Attivo)),
                                       New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.IdOrdineInt, 0))
                End Using

                OrdiniTrovati = LOrd.Count

                LogMe("Apertura Connessione FTP")

                Using Ftp As New FTPclient(FtpServer, FtpLogin, FtpPwd)

                    'qui in L ho tutti gli ordini da lavorare in questo momento 
                    For Each O As FW.OrdineWeb In LOrd.ToList

                        Dim PreRefineErrorCode As Integer = enErroriPreRefine.Nessuno

                        If O.Utente.IdRubricaInt Then ' prendo in carico solo gli ordini in cui l'utente e' stato registrato senno lo salto e lascio prima al sincronizzatore l'incarico di registrarlo
                            If O.ConsegnaAssociata.Accorpabile Then
                                Application.DoEvents()
                                Using TB As F.LUNA.LunaTransactionBox = F.LUNA.LunaContext.CreateTransactionBox()
                                    Dim RilascioCli As Integer = 9999

                                    Try

                                        Dim RisultatoOrdine As enRisultatoOrdineScaricato = enRisultatoOrdineScaricato.Nessuno
                                        Dim NoteRisultatoOrdine As String = ""
                                        Dim OInt As F.Ordine = Nothing
                                        Dim UploadAnteprima As Boolean = False

                                        Dim U As New FW.Utente
                                        Dim Uint As New F.VoceRubrica

                                        U.Read(O.IdUt)
                                        Uint.Read(U.IdRubricaInt)

                                        'If U.IdRubricaInt = 0 Then
                                        '    'qui devo salvare l'utente in rubrica 
                                        '    'o vedere se lo trovo tra i miei 
                                        '    '*********************SALVO NUOVO CLIENTE

                                        '    Syncronizer.CreaRubricaIntFromWeb(Uint, U)

                                        '    'Uint.Tipo = U.TipoRub
                                        '    'Uint.RagSoc = U.RagSoc
                                        '    'Uint.Nome = U.Nome
                                        '    'Uint.Cognome = U.Cognome
                                        '    'Uint.CodFisc = U.CodFisc
                                        '    'Uint.Piva = U.Piva
                                        '    'Uint.Email = U.Email
                                        '    'Uint.IdCorriere = U.IdCorriereDef
                                        '    'Uint.Indirizzo = U.Indirizzo
                                        '    'Uint.Tel = U.Tel
                                        '    'Uint.Fax = U.Fax
                                        '    'Uint.Cellulare = U.Cellulare
                                        '    'Uint.CAP = U.Cap
                                        '    'Uint.Citta = U.Citta
                                        '    'Uint.IdPagamento = enMetodoPagamento.AllaConsegna  'alla consegna
                                        '    'Uint.SitoWeb = U.SitoWeb
                                        '    'Uint.ScopertoMax = 1000
                                        '    'Uint.IdUtOnline = U.IdUt
                                        '    'Uint.Sorgente = "W"
                                        '    'Uint.DataIns = U.DataIns
                                        '    'Uint.IdTipoAttivita = U.IdTipoAttivita
                                        '    'Try
                                        '    TB.TransactionBegin()
                                        '    Uint.Save()
                                        '    U.IdRubricaInt = Uint.IdRub
                                        '    U.Save()
                                        '    TB.TransactionCommit()
                                        '    'Catch ex As Exception

                                        '    'Throw ex
                                        '    'End Try

                                        '    LogMe("Salvato Nuovo Cliente dal sito, Ordine Online " & O.IdOrdine)

                                        'Else
                                        '    Uint.Read(U.IdRubricaInt)
                                        'End If

                                        '*********************SCARICO FILE
                                        Dim NomeSorgenteFronte As String = PathTemp & O.IdOrdine & "_" & O.SorgenteFronte
                                        Dim NomeSorgenteRetro As String = String.Empty

                                        Dim FileToDownloadFronte As String = "/tipografiaformer.it/ordini/" & O.IdOrdine & "/" & O.SorgenteFronte
                                        Dim FileToDownloadRetro As String = String.Empty

                                        If O.C.FR Then
                                            If O.TipoRetro = enTipoRetro.RetroDifferente Then
                                                FileToDownloadRetro = "/tipografiaformer.it/ordini/" & O.IdOrdine & "/" & O.SorgenteRetro
                                                NomeSorgenteRetro = PathTemp & O.IdOrdine & "_" & O.SorgenteRetro
                                            End If
                                        End If

                                        Dim CheckFileOk As Boolean = True
                                        Dim UsaFileOnline As Boolean = True

                                        If O.L.NoAttachFile <> enSiNo.Si Then
                                            If System.IO.File.Exists(NomeSorgenteFronte) Then
                                                UsaFileOnline = False
                                            Else
                                                If Ftp.FtpFileExists(FileToDownloadFronte) = False Then
                                                    CheckFileOk = False
                                                End If
                                            End If

                                            If FileToDownloadRetro.Length Then
                                                If System.IO.File.Exists(NomeSorgenteRetro) Then
                                                    UsaFileOnline = False
                                                Else
                                                    If Ftp.FtpFileExists(FileToDownloadRetro) = False Then
                                                        CheckFileOk = False
                                                    End If
                                                End If
                                            End If

                                            If CheckFileOk Then
                                                If UsaFileOnline Then
                                                    RilascioCli = 9999
                                                    LogMe("Scarico sorgenti, Lavoro Online " & O.IdOrdine)
                                                    Ftp.Download(FileToDownloadFronte, NomeSorgenteFronte, True)
                                                    If FileToDownloadRetro.Length Then
                                                        Ftp.Download(FileToDownloadRetro, NomeSorgenteRetro, True)
                                                        'ElseIf O.C.FR Then
                                                        '    If O.TipoRetro = enTipoRetro.RetroUgualeFronte Then
                                                        '        'ricopio il fronte con il nome diverso 
                                                        '        NomeSorgenteRetro = PathTemp & O.IdOrdine & "_R" & O.SorgenteFronte.Substring(1)
                                                        '        FileCopy(NomeSorgenteFronte, NomeSorgenteRetro)
                                                        '    ElseIf O.TipoRetro = enTipoRetro.RetroBianco Then
                                                        '        'copio un file bianco al posto del retro 
                                                        '        NomeSorgenteRetro = PathTemp & O.IdOrdine & "_R_bianco.pdf"
                                                        '        FileCopy(PathFileBianco, NomeSorgenteRetro)
                                                        '    End If
                                                    End If
                                                    LogMe("Scaricati sorgenti, Lavoro Online " & O.IdOrdine)
                                                Else
                                                    RilascioCli = 1
                                                    LogMe("Utilizzo file Offline, Lavoro Online " & O.IdOrdine)
                                                End If

                                                'sia che online che offline controllo se devo copiare i file 
                                                If O.C.FR Then
                                                    If O.TipoRetro = enTipoRetro.RetroUgualeFronte Then
                                                        'ricopio il fronte con il nome diverso 
                                                        NomeSorgenteRetro = PathTemp & O.IdOrdine & "_R" & O.SorgenteFronte.Substring(1)
                                                        FileCopy(NomeSorgenteFronte, NomeSorgenteRetro)
                                                        '******************************DISATTIVATO 13/11/2017 perche non serve piu 
                                                        'ElseIf O.TipoRetro = enTipoRetro.RetroBianco Then
                                                        '    'copio un file bianco al posto del retro 
                                                        '    NomeSorgenteRetro = PathTemp & O.IdOrdine & "_R_bianco.pdf"
                                                        '    FileCopy(PathFileBianco, NomeSorgenteRetro)
                                                    End If
                                                End If

                                                'PER L'ANTEPRIMA LA DEVO CREARE
                                                Dim NomeAnteprima As String = PathTemp & Path.GetFileNameWithoutExtension(NomeSorgenteFronte) & ".jpg"
                                                Try

                                                    If FileIO.FileSystem.FileExists(NomeSorgenteFronte) Then
                                                        If NomeSorgenteFronte.ToLower.EndsWith("pdf") Then
                                                            FormerHelper.PDF.GetPdfThumbnail(NomeSorgenteFronte, NomeAnteprima)
                                                            UploadAnteprima = True
                                                        End If
                                                    End If

                                                Catch ex As Exception
                                                    'qui c'è stato un errore nella creazione dell'anteprima
                                                    'metto un file temporaneo e poi vediamo
                                                    LogMe("Errore creazione Anteprima Ordine Web " & O.IdOrdine & " :" & ex.Message, , ex)
                                                    NomeAnteprima = PathTemp & "NoAnteprima.jpg"

                                                End Try

                                                O.FileScaricatiNomeAnteprima = NomeAnteprima
                                                O.FileScaricatiNomeFronte = NomeSorgenteFronte
                                                O.FileScaricatiNomeRetro = NomeSorgenteRetro
                                            Else
                                                RisultatoOrdine = enRisultatoOrdineScaricato.Rifiutato
                                                NoteRisultatoOrdine = "File allegati al lavoro non presenti o scartati, ricaricarli"
                                                O.Stato = enStatoOrdine.InAttesaAllegati

                                                O.Save()
                                                LogMe("ERRORE File allegati al lavoro non presenti o scartati, Lavoro Online " & O.IdOrdine)
                                            End If
                                        End If

                                        If RisultatoOrdine = enRisultatoOrdineScaricato.Nessuno Then
                                            'qui devo validare i sorgenti e comportarmi di conseguenza

                                            'qui devo fare la validazione dei sorgenti dopo averli scaricati

                                            Dim RisValidazioneOrdine As ValidationOrderResult = Nothing

                                            If MgrFormerException.ValidareFileSorgente(O.IdListinoBase) Then
                                                RisValidazioneOrdine = ValidaOrdineWeb(O)
                                                LogMe("Validazione EFFETTUATA, MaxErrorLevel = " & RisValidazioneOrdine.MaxErrorLevelStr)
                                            Else
                                                RisValidazioneOrdine = New ValidationOrderResult
                                            End If

                                            If RisValidazioneOrdine.MaxErrorLevel < enValidatorErrorLevel.Errore Then

                                                Dim IsOltreScopertoMax As Boolean = False


                                                'CHECK SU SCOPERTOMAX
                                                If O.InseritoDa = 0 Then
                                                    Using MgrR As New F.VociRubricaDAO
                                                        IsOltreScopertoMax = MgrR.OltreScopertoMax(Uint)
                                                    End Using
                                                End If

                                                If IsOltreScopertoMax = False Then
                                                    Dim L As New F.ListinoBase
                                                    L.Read(O.IdProdotto)
                                                    If L.IdListinoBase Then

                                                        Dim NFogliVis As Integer = 0

                                                        If O.L.Target = enTargetListinoBase.Foglio Then
                                                            NFogliVis = O.Nfogli
                                                        Else
                                                            If O.C.FR Then
                                                                NFogliVis = O.Nfogli * 2
                                                            Else
                                                                NFogliVis = O.Nfogli
                                                            End If
                                                        End If

                                                        Dim CodiceCalcolato As String = L.CreaCodProd(O.Qta,
                                                                                                      NFogliVis,
                                                                                                      O.L.ShowLabelFogli)

                                                        Dim P As F.Prodotto

                                                        Dim Pl As List(Of F.Prodotto) = Nothing

                                                        Using PMgr As New F.ProdottiDAO
                                                            Pl = PMgr.FindAll(New F.LUNA.LunaSearchParameter(LFM.Prodotto.Codice, CodiceCalcolato))
                                                        End Using

                                                        Dim PrezzoPubbl As Decimal = 0
                                                        Dim PrezzoRiv As Decimal = 0

                                                        If Uint.Tipo = enTipoRubrica.Cliente Then
                                                            PrezzoRiv = 0
                                                            PrezzoPubbl = O.PrezzoCalcolatoNetto
                                                        Else
                                                            PrezzoRiv = O.PrezzoCalcolatoNetto
                                                            PrezzoPubbl = 0
                                                        End If

                                                        Dim QuantitaProdotto As Integer = 1
                                                        Dim QuantitaAcquistata As Integer = 1

                                                        'If O.L.TipoPrezzo = enTipoPrezzo.SuQuantita Then
                                                        '    QuantitaProdotto = 1 'O.Qta ''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                                                        '    QuantitaAcquistata = O.Qta '1''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                                                        'ElseIf O.L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                                                        '    QuantitaProdotto = 1
                                                        '    QuantitaAcquistata = O.Qta
                                                        'ElseIf O.L.TipoPrezzo = enTipoPrezzo.SuCopie Then
                                                        '    QuantitaProdotto = 1
                                                        '    QuantitaAcquistata = O.Qta
                                                        'End If

                                                        QuantitaProdotto = 1
                                                        QuantitaAcquistata = O.Qta

                                                        If Pl.Count Then
                                                            P = Pl(0)
                                                            P.Descrizione = L.NomeEx '& " " & QuantitaProdotto
                                                            P.Prezzo = PrezzoRiv
                                                            P.PrezzoPubbl = PrezzoPubbl
                                                            P.NumColli = O.NumeroColli
                                                            P.PesoComplessivo = O.Peso
                                                            P.NumPezzi = QuantitaProdotto
                                                            P.TipoProd = O.P.TipoProd
                                                            If P.IdListinoBase = 0 Then P.IdListinoBase = O.IdListinoBase

                                                            If P.NumFacciate = 0 Then
                                                                P.NumFacciate = NFogliVis
                                                                P.NoImpiantiSuFacciate = IIf(O.L.nofaccsuimpianti, enSiNo.Si, enSiNo.No)  'IIf(O.L.ShowLabelFogli, enSiNo.Si, enSiNo.No)
                                                            End If

                                                            P.Save()
                                                        Else
                                                            P = L.CreaProdDaListinoBase(QuantitaProdotto,
                                                                                        NFogliVis,
                                                                                        O.NumeroColli,
                                                                                        O.Peso,
                                                                                         PrezzoRiv,
                                                                                         PrezzoPubbl,
                                                                                         O.L.ShowLabelFogli,
                                                                                         O.L.GetLabelFogli,
                                                                                         NFogliVis)
                                                            LogMe("Creato Nuovo Prodotto " & P.Codice & ", Lavoro Online " & O.IdOrdine)
                                                        End If

                                                        Dim IdOrd As Integer = 0

                                                        OInt = New F.Ordine
                                                        OInt.IdRub = U.IdRubricaInt
                                                        OInt.IdProd = P.IdProd
                                                        OInt.IdCorriere = O.IdCorriere
                                                        OInt.Preventivo = O.Preventivo
                                                        OInt.OrdineInOmaggio = O.OrdineInOmaggio

                                                        OInt.IdOrdineProvvisorio = O.IdCons

                                                        Dim Annotazioni As String = O.Annotazioni

                                                        If O.IdIndirizzo Then
                                                            'qui è stato scelto un indirizzo diverso. Per ora lo salvo nelle note e creo l'indirizzo interno 

                                                            Dim I As New FW.Indirizzo
                                                            I.Read(O.IdIndirizzo)

                                                            If I.IdIndirizzoInt = 0 Then
                                                                CreaIndirizzoIntdaOnline(I, TB)
                                                            End If

                                                            OInt.IdIndirizzo = I.IdIndirizzoInt
                                                            'Annotazioni &= ControlChars.NewLine & "INDIRIZZO CONSEGNA: " & I.Riassunto

                                                        End If

                                                        OInt.Annotazioni = Annotazioni
                                                        OInt.TipoConsegna = O.TipoConsegna
                                                        OInt.RilascioCli = RilascioCli 'in rilasciocli metto 9999 se dal sito, 1 se non ci sono i file online e allora e' dal gestionale 

                                                        OInt.NomeLavoro = O.NomeLavoro

                                                        OInt.IdMailPreventivo = O.IdMailPreventivo
                                                        '**********************************************
                                                        'PRODOTTI SPECIFICI
                                                        '**********************************************
                                                        If MgrFormerException.UsareNomeLavoroInFattura(OInt) Then
                                                            OInt.UsaNomeLavoroInFattura = enSiNo.Si
                                                        Else
                                                            OInt.UsaNomeLavoroInFattura = O.UsaNomeLavoroInFattura
                                                            'OInt.UsaNomeLavoroInFattura = enSiNo.No
                                                        End If

                                                        OInt.DataIns = O.DataIns ' Date.Now
                                                        OInt.DataPrevProduzione = O.DataPrevProduzione
                                                        OInt.DataPrevConsegna = O.DataPrevConsegna
                                                        OInt.Orientamento = O.Orientamento

                                                        OInt.DataCambioStato = Date.Now
                                                        OInt.IdTipoProd = O.P.IdReparto
                                                        OInt.Lungo = O.Altezza
                                                        OInt.Largo = O.Larghezza
                                                        OInt.Profondita = O.Profondita
                                                        OInt.Mq = O.Mq
                                                        OInt.IdMacchinarioProduzioneUtilizzato = O.IdMacchinarioProduzioneUtilizzato

                                                        OInt.ConsegnaGarantita = O.ConsegnaGarantita
                                                        OInt.ConsegnaGarantitaDa = O.ConsegnaGarantitaDa

                                                        'Dim VaiARefine As Boolean = True
                                                        If O.L.NoAttachFile <> enSiNo.Si Then
                                                            If O.P.IdReparto <> enRepartoWeb.StampaDigitale Then
                                                                Dim TotPagineNeiSorgenti As Integer = FormerHelper.PDF.GetNumeroPagine(NomeSorgenteFronte)
                                                                If NomeSorgenteRetro.Length Then TotPagineNeiSorgenti += FormerHelper.PDF.GetNumeroPagine(NomeSorgenteRetro)
                                                                PreRefineErrorCode = MgrPreRefineCheck.CheckOrder(RisValidazioneOrdine,
                                                                                                                  L,
                                                                                                                  TotPagineNeiSorgenti,
                                                                                                                  O.Nfogli,
                                                                                                                  O.TipoRetro)
                                                            End If
                                                        End If




                                                        'If RisValidazioneOrdine.HannoDimensioniErrate AndAlso O.L.Preventivazione.IdReparto <> enRepartoWeb.Ricamo Then
                                                        '    PreRefineErrorCode += enErroriPreRefine.DimensioniErrate
                                                        '    VaiARefine = False
                                                        'End If
                                                        'If VaiARefine Then
                                                        '    If O.L.Preventivazione.IdReparto = enRepartoWeb.StampaOffset Then
                                                        '        Using mgr As New ModelliCommessaDAO
                                                        '            Using fp As New FormatoProdotto
                                                        '                fp.Read(O.L.IdFormProd)
                                                        '                Dim Ml As List(Of ModelloCommessa) = mgr.FindByFormatoProdotto(fp)
                                                        '                Ml = Ml.FindAll(Function(x) x.FormatiProdotto.Count = 1)
                                                        '                If O.L.ColoreStampa.FR Then
                                                        '                    Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.Si)
                                                        '                Else
                                                        '                    Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.No)
                                                        '                End If

                                                        '                If Ml.Count = 0 Then
                                                        '                    PreRefineErrorCode += enErroriPreRefine.ModelloNonPresente
                                                        '                End If
                                                        '            End Using
                                                        '        End Using
                                                        '    End If

                                                        'End If

                                                        If O.L.NoAttachFile <> enSiNo.Si Then
                                                            If PreRefineErrorCode = enErroriPreRefine.Nessuno Then
                                                                'MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Nessun errore PreRefine, l'ordine passa a Refineautomatico")
                                                                OInt.Stato = enStatoOrdine.RefineAutomatico
                                                            Else
                                                                'MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Errore Prerefine " & PreRefineErrorCode & ", l'ordine passa a Preinserito")
                                                                OInt.Stato = enStatoOrdine.Preinserito
                                                            End If
                                                        Else
                                                            OInt.Stato = enStatoOrdine.Registrato
                                                        End If

                                                        OInt.PreRefineErrorCode = PreRefineErrorCode

                                                        'If RisValidazioneOrdine.HannoDimensioniErrate AndAlso OInt.ListinoBase.Preventivazione.IdReparto <> enRepartoWeb.Ricamo Then
                                                        '    OInt.Stato = enStatoOrdine.Preinserito
                                                        'Else
                                                        '    OInt.Stato = enStatoOrdine.RefineAutomatico
                                                        'End If

                                                        'OInt.Stato = enStatoOrdine.Preinserito

                                                        'If Not RisValidazioneOrdine Is Nothing AndAlso RisValidazioneOrdine.MaxErrorLevel = enValidatorErrorLevel.None Then
                                                        '    OInt.Stato = enStatoOrdine.Registrato
                                                        'End If

                                                        OInt.Qta = QuantitaAcquistata
                                                        OInt.PeriodoPrevConsegna = enMomentoConsegna.Pomeriggio
                                                        OInt.FilePath = O.FileScaricatiNomeAnteprima
                                                        OInt.NFogli = O.Nfogli
                                                        OInt.TipoRetro = O.TipoRetro
                                                        OInt.OrdMail = True

                                                        If Uint.Tipo = enTipoRubrica.Cliente Then
                                                            OInt.PrezzoProd = P.PrezzoPubbl
                                                        Else
                                                            OInt.PrezzoProd = P.Prezzo
                                                        End If

                                                        OInt.TotaleForn = O.PrezzoCalcolatoNetto

                                                        OInt.Sconto = O.Sconto
                                                        OInt.Ricarico = O.Ricarico

                                                        OInt.IdCoupon = O.IdCoupon
                                                        OInt.IdPromo = O.IdPromo

                                                        'qui devo gestire il coupon

                                                        OInt.CostoSped = O.PrezzoCorriere

                                                        Dim listLav As New List(Of Integer)
                                                        For Each singL As String In O.Lavorazioni.Split(",").ToList
                                                            If singL.Length Then listLav.Add(CInt(singL))
                                                        Next

                                                        If O.InseritoDa = 0 Then
                                                            Using MgrL As New F.LavorazioniDAO
                                                                listLav = MgrL.RiordinaListaLav(listLav, O.IdListinoBase)
                                                            End Using
                                                        End If

                                                        OInt.ListaLavorazioniCustom = listLav.ToArray

                                                        OInt.UsaLavorazioniDefault = False

                                                        OInt.IdOrdOnline = O.IdOrdine

                                                        GestisciOrdiniConPlugin(L, OInt, O)

                                                        OInt.ExtraData = O.ExtraData

                                                        'Select Case L.Preventivazione.IdPluginToUse
                                                        '    Case enPluginOnline.Packaging
                                                        '        If L.Preventivazione.IdFunzionePack <> 0 Then
                                                        '            If O.IdTipoFustella = 0 Then
                                                        '                If O.Altezza <> 0 And O.Profondita <> 0 And O.Larghezza <> 0 Then
                                                        '                    Using mgr As New F.TipoFustelleDAO
                                                        '                        Dim lFustelle As List(Of F.TipoFustella) = mgr.GetAll()
                                                        '                        Dim SingF As F.TipoFustella = lFustelle.Find(Function(x) x.IdPrev = L.Preventivazione.IdPrev And _
                                                        '                                                                         x.Altezza = O.Altezza And _
                                                        '                                                                         x.Base = O.Larghezza And _
                                                        '                                                                         x.Profondita = O.Profondita)
                                                        '                        Dim IdTipoFustellaDaUsare As Integer = 0
                                                        '                        If SingF Is Nothing Then
                                                        '                            'fustella da creare
                                                        '                            LogMe("Creata Nuova Fustella " & O.Larghezza & "x" & O.Profondita & "x" & O.Altezza & ", Lavoro Online " & O.IdOrdine)

                                                        '                            SingF = New F.TipoFustella
                                                        '                            SingF.IdPrev = L.Preventivazione.IdPrev
                                                        '                            SingF.Disponibile = enSiNo.No
                                                        '                            SingF.Profondita = O.Profondita
                                                        '                            SingF.Altezza = O.Altezza
                                                        '                            SingF.Base = O.Larghezza
                                                        '                            IdTipoFustellaDaUsare = SingF.Save()

                                                        '                        Else
                                                        '                            IdTipoFustellaDaUsare = SingF.IdTipoFustella
                                                        '                        End If
                                                        '                        OInt.IdTipoFustella = IdTipoFustellaDaUsare
                                                        '                    End Using
                                                        '                End If
                                                        '            Else
                                                        '                'fustella gia esistente
                                                        '                OInt.IdTipoFustella = O.IdTipoFustella
                                                        '            End If
                                                        '        End If

                                                        '    Case enPluginOnline.Etichette
                                                        '        'la fustella qui gia esiste obbligatoriamente
                                                        '        OInt.IdTipoFustella = O.IdTipoFustella
                                                        'End Select
                                                        '***********TB.TransactionBegin()

                                                        Dim ListaSorgentiFronte As New List(Of String)
                                                        Dim ListaSorgentiRetro As New List(Of String)

                                                        Dim NumPagFronte As Integer = 0
                                                        Dim NumPagRetro As Integer = 0

                                                        If O.L.NoAttachFile <> enSiNo.Si Then

                                                            NumPagFronte = FormerHelper.PDF.GetNumeroPagine(NomeSorgenteFronte)

                                                            If NumPagFronte > 1 Then
                                                                LogMe("Trovato File Fronte multipagina. (" & NumPagFronte & " pagine)")
                                                                Try
                                                                    For i As Integer = 1 To NumPagFronte

                                                                        Dim PathEnd As String = NomeSorgenteFronte.ToLower.Replace(".pdf", ".p" & i.ToString("0000") & ".pdf")

                                                                        FormerHelper.PDF.EstraiPaginaFromPdf(NomeSorgenteFronte, PathEnd, i)

                                                                        ListaSorgentiFronte.Add(PathEnd)

                                                                    Next
                                                                Catch ex As Exception
                                                                    LogMe("Si è verificato un errore nel estrazione della pagine dal sorgente",, ex)
                                                                End Try

                                                                Try
                                                                    System.IO.File.Delete(NomeSorgenteFronte)
                                                                Catch ex As Exception
                                                                    LogMe("Non sono riuscito a cancellare il file sorgente del fronte.")
                                                                End Try
                                                            Else
                                                                Dim NuovoNomeSorgenteFronte As String = PathTemp & O.IdOrdine & "_" & O.SorgenteFronte
                                                                Rename(NomeSorgenteFronte, NuovoNomeSorgenteFronte)
                                                                ListaSorgentiFronte.Add(NuovoNomeSorgenteFronte)

                                                            End If

                                                            If NomeSorgenteRetro.Length Then

                                                                NumPagRetro = FormerHelper.PDF.GetNumeroPagine(NomeSorgenteRetro)

                                                                If NumPagRetro > 1 Then
                                                                    LogMe("Trovato File retro multipagina. (" & NumPagRetro & " pagine)")
                                                                    Try
                                                                        For i As Integer = 1 To NumPagRetro

                                                                            Dim PathEnd As String = NomeSorgenteRetro.ToLower.Replace(".pdf", ".p" & i.ToString("0000") & ".pdf")

                                                                            FormerHelper.PDF.EstraiPaginaFromPdf(NomeSorgenteRetro, PathEnd, i)

                                                                            ListaSorgentiRetro.Add(PathEnd)

                                                                        Next
                                                                    Catch ex As Exception
                                                                        LogMe("Si è verificato un errore nel estrazione della pagine dal sorgente",, ex)
                                                                    End Try

                                                                    Try
                                                                        System.IO.File.Delete(NomeSorgenteRetro)
                                                                    Catch ex As Exception
                                                                        LogMe("Non sono riuscito a cancellare il file sorgente del retro.")
                                                                    End Try

                                                                    'delete originale
                                                                Else
                                                                    Dim ParteNuovoSorgenteRetro As String = NomeSorgenteRetro.Substring(NomeSorgenteRetro.IndexOf("_R_"))
                                                                    Dim NuovoNomeSorgenteRetro As String = PathTemp & O.IdOrdine & ParteNuovoSorgenteRetro

                                                                    Rename(NomeSorgenteRetro, NuovoNomeSorgenteRetro)
                                                                    ListaSorgentiRetro.Add(NuovoNomeSorgenteRetro)
                                                                End If

                                                            End If

                                                        End If

                                                        LogMe("Sorgenti fronte: " & ListaSorgentiFronte.Count & " Sorgenti retro: " & ListaSorgentiRetro.Count)

                                                        If ListaSorgentiFronte.Count = NumPagFronte AndAlso ListaSorgentiRetro.Count = NumPagRetro Then

                                                            LogMe("Avvio transazione (TransactionCall " & TB.TransactionCall & ")")
                                                            TB.TransactionBegin()
                                                            LogMe("Transazione avviata")

                                                            IdOrd = OInt.SaveFirstTime(O.InseritoDa)

                                                            If IdOrd = 0 Then
                                                                Throw New Exception("IdOrdine Interno salvato = 0 errore GRAVE")
                                                            End If

                                                            If Not RisValidazioneOrdine Is Nothing AndAlso RisValidazioneOrdine.MaxErrorLevel > enValidatorErrorLevel.None Then

                                                                'qui c'e' stato un errore di validazione e creo un messaggio

                                                                Dim BufferErrore As String = String.Empty
                                                                For Each sing In RisValidazioneOrdine.ValidationFileListKO.ToList
                                                                    BufferErrore &= "************" & ControlChars.NewLine & "PDF " & FormerEnumHelper.TipoSorgenteStr(sing.TipoSorgente).ToUpper & ": " & ControlChars.NewLine & "************" & ControlChars.NewLine
                                                                    BufferErrore &= sing.ErrorBuffer(True) & ControlChars.NewLine & ControlChars.NewLine
                                                                Next

                                                                If RisValidazioneOrdine.HannoOrientamentoDifferente Then
                                                                    BufferErrore &= "ATTENZIONE: I PDF di Fronte e Retro hanno un orientamento differente"
                                                                End If

                                                                Try
                                                                    Using m As New F.Messaggio
                                                                        m.IdOrd = IdOrd
                                                                        'm.IdDest = FormerConst.UtentiSpecifici.IdUtenteAndrea
                                                                        m.DataIns = Now
                                                                        m.IdMitt = 0
                                                                        m.Titolo = "Validazione Sorgenti"
                                                                        m.TipoMsg = enTipoMessaggio.Automatico
                                                                        m.Testo = BufferErrore
                                                                        m.Save()
                                                                    End Using
                                                                Catch ex As Exception
                                                                    LogMe("Errore Invio Messaggio Interno - testo: " & BufferErrore,, ex)
                                                                End Try

                                                            End If

                                                            O.IdOrdineInt = IdOrd

                                                            Dim ListaSorgFronte As New List(Of F.FileSorgente)
                                                            Dim ListaSorgRetro As New List(Of F.FileSorgente)
                                                            Dim NuovoNomeAnteprima As String = String.Empty

                                                            If O.L.NoAttachFile <> enSiNo.Si Then

                                                                NuovoNomeAnteprima = IdOrd & "_A" & Path.GetFileNameWithoutExtension(O.SorgenteFronte) & ".jpg"
                                                                If UploadAnteprima Then
                                                                    O.Anteprima = NuovoNomeAnteprima
                                                                    OInt.FilePath = PathTemp & NuovoNomeAnteprima
                                                                    Using mgr As New F.OrdiniDAO
                                                                        mgr.SalvaFile(OInt)
                                                                    End Using
                                                                End If

                                                                '***************************SALVO I SORGENTI 
                                                                Dim NumPagina As Integer = 1

                                                                Dim Sorg As F.FileSorgente


                                                                For Each PathEnd As String In ListaSorgentiFronte.ToList

                                                                    Dim risCopia As enStatoRefineSorgente = enStatoRefineSorgente.NonDefinito

                                                                    'If OInt.Stato = enStatoOrdine.RefineAutomatico Then
                                                                    '    risCopia = CopiaSorgenteToRefine(PathEnd)
                                                                    'End If

                                                                    Sorg = New F.FileSorgente
                                                                    Sorg.IdOrd = IdOrd
                                                                    Sorg.FilePath = PathEnd
                                                                    Sorg.NumPagina = NumPagina
                                                                    Sorg.StatoRefine = risCopia
                                                                    Sorg.Save()
                                                                    ListaSorgFronte.Add(Sorg)
                                                                    Sorg = Nothing

                                                                    NumPagina += 1

                                                                Next

                                                                For Each PathEnd As String In ListaSorgentiRetro.ToList

                                                                    Dim risCopia As enStatoRefineSorgente = enStatoRefineSorgente.NonDefinito

                                                                    'If OInt.Stato = enStatoOrdine.RefineAutomatico Then
                                                                    '    risCopia = CopiaSorgenteToRefine(PathEnd)
                                                                    'End If

                                                                    Sorg = New F.FileSorgente
                                                                    Sorg.IdOrd = IdOrd
                                                                    Sorg.FilePath = PathEnd
                                                                    Sorg.NumPagina = NumPagina
                                                                    Sorg.StatoRefine = risCopia
                                                                    Sorg.Save()
                                                                    ListaSorgRetro.Add(Sorg)

                                                                    Sorg = Nothing

                                                                    NumPagina += 1

                                                                Next

                                                            End If

                                                            'qui se il listino base non ha il cubetto o non ha la quantitacollo mando un alert a antonio
                                                            'InviaMsgAvviso
                                                            Dim MsgAvviso As String = String.Empty
                                                            If OInt.ListinoBase.IdModelloCubetto = 0 Then
                                                                MsgAvviso = "Listino Base: " & OInt.ListinoBase.NomeEx & ", Modello Cubetto non presente" & ControlChars.NewLine
                                                            End If

                                                            If OInt.ListinoBase.QtaCollo = 0 Or (OInt.ListinoBase.QtaCollo = 1 And OInt.ListinoBase.Preventivazione.IdReparto <> enRepartoWeb.StampaDigitale) Then
                                                                MsgAvviso = "Listino Base: " & OInt.ListinoBase.NomeEx & ", Quantità Collo non presente" & ControlChars.NewLine
                                                            End If

                                                            If MsgAvviso.Length Then
                                                                InviaMsgAvviso(MsgAvviso)
                                                            End If

                                                            'questo deve stare qui prima del commit per evitare inconsistenze
                                                            O.Save()

                                                            TB.TransactionCommit()

                                                            If O.L.NoAttachFile <> enSiNo.Si Then
                                                                For Each Sorg In ListaSorgFronte.ToList
                                                                    Dim risCopia As enStatoRefineSorgente = enStatoRefineSorgente.NonDefinito

                                                                    If OInt.Stato = enStatoOrdine.RefineAutomatico Then
                                                                        risCopia = CopiaSorgenteToRefine(Sorg.FilePath)
                                                                    End If
                                                                    Sorg.StatoRefine = risCopia
                                                                    Sorg.Save()
                                                                Next

                                                                For Each Sorg In ListaSorgRetro.ToList
                                                                    Dim risCopia As enStatoRefineSorgente = enStatoRefineSorgente.NonDefinito

                                                                    If OInt.Stato = enStatoOrdine.RefineAutomatico Then
                                                                        risCopia = CopiaSorgenteToRefine(Sorg.FilePath)
                                                                    End If
                                                                    Sorg.StatoRefine = risCopia
                                                                    Sorg.Save()
                                                                Next
                                                            End If

                                                            'copio effettivamente i sorgenti in refine

                                                            LogMe("Inserito Lavoro " & IdOrd)

                                                            'qui vado a spacchettare i sorgenti dell'ordine 


                                                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Scaricato Lavoro da sito. Lavoro Online " & O.IdOrdine)
                                                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Prodotto: " & P.Descrizione)
                                                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Cliente: " & Uint.RagSocNome)
                                                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Stato Iniziale: " & FormerEnumHelper.StatoOrdineString(OInt.Stato))
                                                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "PreRefineErrorCheck: " & OInt.PreRefineErrorCode)
                                                            Dim BufferLavorazioni As String = String.Empty

                                                            For Each lLav As Lavorazione In OInt.ListaLavori.ToList
                                                                BufferLavorazioni &= lLav.Descrizione & "; "
                                                            Next

                                                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Lavorazioni: " & BufferLavorazioni)
                                                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "****************************************")

                                                            Dim PathOrdine As String = FormerPath.PathLog & IdOrd & "\" & IdOrd & ".xml"
                                                            FormerSerializator.SerializeObjectToFile(OInt, PathOrdine)

                                                            'carico online l'anteprima
                                                            If O.L.NoAttachFile <> enSiNo.Si Then
                                                                If UploadAnteprima Then
                                                                    Try
                                                                        LogMe("Copio Anteprima da " & O.FileScaricatiNomeAnteprima & " a " & PathTemp & NuovoNomeAnteprima)
                                                                        FileCopy(O.FileScaricatiNomeAnteprima, PathTemp & NuovoNomeAnteprima)
                                                                    Catch ex As Exception
                                                                        LogMe("ERRORE COPIA ANTEPRIMA Lavoro " & IdOrd & ", MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace)
                                                                    End Try

                                                                    Try
                                                                        LogMe("Elimino vecchia Anteprima da " & O.FileScaricatiNomeAnteprima)
                                                                        System.IO.File.Delete(O.FileScaricatiNomeAnteprima)
                                                                    Catch ex As Exception
                                                                        LogMe("WARNING non sono riuscito a ELIMINARE ANTEPRIMA Lavoro " & IdOrd)
                                                                    End Try

                                                                    Dim NomeFileAnteprimaOnline As String = "/tipografiaformer.it/ordini/" & O.IdOrdine & "/" & NuovoNomeAnteprima

                                                                    Try
                                                                        Ftp.Upload(PathTemp & NuovoNomeAnteprima, NomeFileAnteprimaOnline)
                                                                    Catch ex As Exception
                                                                        LogMe("ERRORE UPLOAD ANTEPRIMA Lavoro " & IdOrd & ", MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace)
                                                                    End Try
                                                                End If
                                                            End If


                                                            RisultatoOrdine = enRisultatoOrdineScaricato.Accettato
                                                            OrdiniScaricati += 1

                                                            'qui creo la consegna programmata per l'ordine
                                                            'o gestisco il salvataggio della consegna esistente se bloccata per un pagamento

                                                            Using mgr As New F.ConsegneProgrammateDAO
                                                                Dim DataRifConsegna As Date = Now.Date
                                                                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "****************************************")

                                                                If OInt.IdCorriere = enCorriere.RitiroCliente Then
                                                                    DataRifConsegna = OInt.DataPrevProduzione
                                                                ElseIf OInt.IdCorriere = enCorriere.TipografiaFormer Or
                                                                       OInt.IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then
                                                                    DataRifConsegna = OInt.DataPrevConsegna
                                                                Else
                                                                    DataRifConsegna = O.ConsegnaAssociata.Giorno
                                                                End If

                                                                If DataRifConsegna = Date.MinValue Then
                                                                    DataRifConsegna = O.ConsegnaAssociata.Giorno
                                                                End If

                                                                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Data Consegna Iniziale: " & DataRifConsegna.ToString("dd/MM/yyyy"))
                                                                DataRifConsegna = MgrDataConsegna.ConfermaDataConsegna(OInt.DataIns,
                                                                                                       DataRifConsegna,
                                                                                                       OInt.IdCorriere)
                                                                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Data Consegna Confermata: " & DataRifConsegna.ToString("dd/MM/yyyy"))
                                                                If DataRifConsegna = Date.MinValue Then
                                                                    DataRifConsegna = OInt.DataPrevConsegna
                                                                End If
                                                                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Data Consegna Definitiva: " & DataRifConsegna.ToString("dd/MM/yyyy"))
                                                                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "****************************************")
                                                                ''qui devo aggiungere i giorni alla data in base a quanti giorni sono passati da quando e' stato fatto l'ordine rispetto a ora che e' stato scaricato
                                                                'Dim ggDiff As Integer = DateDiff(DateInterval.Day, OInt.DataIns, Now.Date)

                                                                'If ggDiff > 0 Then

                                                                '    Dim DataTemp As Date = OInt.DataIns
                                                                '    Dim ggDaTogliere As Integer = 0

                                                                '    For I As Integer = 1 To ggDiff
                                                                '        DataTemp = DataTemp.AddDays(1)

                                                                '        If MgrDataConsegna.IsFestivita(DataTemp) = True Then
                                                                '            ggDaTogliere += 1
                                                                '        ElseIf DataTemp.DayOfWeek = DayOfWeek.Sunday Then
                                                                '            ggDaTogliere += 1
                                                                '        ElseIf DataTemp.DayOfWeek = DayOfWeek.Saturday Then
                                                                '            'qui e' sabato 
                                                                '            'devo toglierlo solo se verra' tolto dal calcolo del posticipo
                                                                '            If OInt.IdCorriere = enCorriere.TipografiaFormer Or
                                                                '                OInt.IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then
                                                                '                ggDaTogliere += 1
                                                                '            End If
                                                                '        End If
                                                                '    Next

                                                                '    If ggDaTogliere Then
                                                                '        ggDiff -= ggDaTogliere
                                                                '    End If

                                                                '    'qui devo ricalcolare la data di consegna 
                                                                '    'senza calcolare i sabati e o le domeniche come nella funzione che posticipa
                                                                '    DataRifConsegna = MgrDataConsegna.PosticipaDataConsegna(DataRifConsegna,
                                                                '                                               OInt.IdCorriere,
                                                                '                                               ggDiff)
                                                                'End If

                                                                ''questo pezzo in teoria non dovrebbe servire
                                                                'If DataRifConsegna.DayOfWeek = DayOfWeek.Saturday Then
                                                                '    If OInt.IdCorriere <> enCorriere.TipografiaFormer And OInt.IdCorriere <> enCorriere.RitiroCliente And OInt.IdCorriere <> enCorriere.TipografiaFormerFuoriRaccordo Then
                                                                '        'qui se la data di prevista produzione e' il sabato e il corriere non e' tipografia former o ritiro cliente vado avanti fino al lunedi
                                                                '        'DataRifConsegna = MgrDataConsegna.PosticipaAProssimoGiornoUtile(DataRifConsegna, OInt.IdCorriere)
                                                                '        DataRifConsegna = MgrDataConsegna.GetPrimaDataDisponibile(DataRifConsegna, OInt.IdCorriere)
                                                                '    End If
                                                                'End If

                                                                Dim IdPagamSel As Integer = O.ConsegnaAssociata.IdPagam

                                                                Dim ForzareStampaDocumenti As Boolean = False
                                                                If MgrFormerException.ForzareStampaAutomaticaDocumenti(O.IdListinoBase) Then
                                                                    ForzareStampaDocumenti = True
                                                                End If

                                                                Dim momentoConsegna As enMomentoConsegna = enMomentoConsegna.Pomeriggio

                                                                If OInt.IdCorriere = enCorriere.RitiroCliente And DataRifConsegna.DayOfWeek = DayOfWeek.Saturday Then
                                                                    momentoConsegna = enMomentoConsegna.Mattina
                                                                End If

                                                                Dim ConsRis As F.ConsegnaProgrammata = mgr.RegistraConsegnaOrdineSuGiorno(OInt.IdOrd,
                                                                                                                                           OInt.IdCorriere,
                                                                                                                                           DataRifConsegna,
                                                                                                                                           OInt.IdRub,
                                                                                                                                           momentoConsegna,
                                                                                                                                           OInt.IdIndirizzo, , , , ,
                                                                                                                                           IdPagamSel,
                                                                                                                                           ForzareStampaDocumenti)

                                                                '*******************
                                                                'CHECK INDIRIZZO GLS 
                                                                '*******************
                                                                Try
                                                                    'CHECK INDIRIZZO DI CONSEGNA TRAMITE GLS

                                                                    If ConsRis.IndirizzoRif.Indirizzo.ToUpper <> FormerConst.FermoDeposito Then
                                                                        Dim OkIndirizzo As RisValidazioneIndirizzo = FormerWebLabeling.MgrWebLabelingGls.CheckAddress(ConsRis.IndirizzoRif.Provincia,
                                                                                                                                            ConsRis.IndirizzoRif.Cap,
                                                                                                                                            ConsRis.IndirizzoRif.Citta,
                                                                                                                                            ConsRis.IndirizzoRif.Indirizzo,
                                                                                                                                            ConsRis.IndirizzoRif.IdNazione)
                                                                        If OkIndirizzo.Valido = False Then

                                                                            'qui potrebbe esserci un problema con l'indirizzo 
                                                                            Dim Buffer As String = "L'indirizzo specificato nella consegna interna " & ConsRis.IdCons & " NON HA PASSATO la validazione GLS. Ricontrollare<br><br>"

                                                                            Buffer &= "Consegna " & ConsRis.IdCons & "<br>Giorno " & ConsRis.Giorno.ToString("dd/MM/yyyy") & "<br>Cliente " & ConsRis.Cliente.RagSocNome & " (id " & ConsRis.Cliente.IdRub & ")<br>Indirizzo " & ConsRis.IndirizzoRif.Riassunto(False)
                                                                            Buffer &= "<br><br>Informazioni supplementari: (IdComuneInElenco " & ConsRis.IndirizzoRif.IdComune & ")" & OkIndirizzo.Messaggio
                                                                            Try
                                                                                FormerLib.FormerHelper.Mail.InviaMail("Errore in validazione Indirizzo GLS", Buffer, "info@tipografiaformer.it", , , , )
                                                                            Catch ex As Exception

                                                                            End Try

                                                                            LogMe("Errore in validazione Indirizzo GLS - Indirizzo ID " & ConsRis.IndirizzoRif.IDIndirizzo)

                                                                            For Each Ord As F.Ordine In ConsRis.ListaOrdini.ToList
                                                                                Try
                                                                                    Using m As New F.Messaggio
                                                                                        m.IdOrd = Ord.IdOrd
                                                                                        m.IdDest = 0
                                                                                        m.DataIns = Now
                                                                                        m.IdMitt = 0
                                                                                        m.Titolo = "Errore in validazione Indirizzo GLS"
                                                                                        m.TipoMsg = enTipoMessaggio.Automatico
                                                                                        m.Testo = Buffer
                                                                                        m.Save()
                                                                                    End Using
                                                                                Catch ex As Exception
                                                                                    LogMe("Errore Invio Messaggio Interno - testo: " & Buffer,, ex)
                                                                                End Try

                                                                            Next

                                                                        Else
                                                                            LogMe("Validazione Indirizzo con GLS OK")
                                                                        End If
                                                                    End If

                                                                Catch ex As Exception
                                                                    Dim Buffer As String = "Si è verificato un errore nella gestione dell'indirizzo GLS sulla consegna interna " & ConsRis.IdCons & ": " & ex.Message

                                                                    FormerLib.FormerHelper.Mail.InviaMail("Errore in validazione Indirizzo GLS", Buffer, FormerConst.EmailAssistenzaTecnica)
                                                                End Try

                                                                'qui devo creare in automatico la commessa per gli ordini dei reparti non offset
                                                                'CreaCommessaAutomatica(OInt)

                                                            End Using

                                                            LogMe("Consegna creata/associata per il lavoro " & IdOrd)

                                                        Else
                                                            LogMe("Si è verificato un errore nell'estrazione dei file sorgenti dall'ordine Web " & O.IdOrdine)
                                                        End If

                                                    Else

                                                        'PRODOTTO NON PIU DISPONIBILE A LISTINO
                                                        RisultatoOrdine = enRisultatoOrdineScaricato.Rifiutato
                                                        NoteRisultatoOrdine = "Prodotto non più disponibile a listino"

                                                        'QUI CANCELLO DIRETTAMENTE L'ORDINE ONLINE
                                                        O.Stato = enStatoOrdine.Eliminato
                                                        O.StatoWeb = enStato.NonAttivo
                                                        O.Save()

                                                    End If

                                                Else

                                                    'Superato scoperto massimo
                                                    RisultatoOrdine = enRisultatoOrdineScaricato.Rifiutato
                                                    NoteRisultatoOrdine = "Superato limite massimo di scoperto"
                                                    'QUI METTO IN SOSPESO L'ORDINE ONLINE
                                                    O.Stato = enStatoOrdine.InSospeso
                                                    O.Save()
                                                End If


                                            End If

                                        End If

                                        If RisultatoOrdine <> enRisultatoOrdineScaricato.Nessuno Then
                                            Dim SuffissoOrdine As String = String.Empty
                                            If OInt Is Nothing Then
                                                OInt = New F.Ordine
                                                OInt.IdOrd = O.IdOrdine
                                                OInt.DataIns = Now
                                                SuffissoOrdine = "WEB"
                                            Else
                                                SuffissoOrdine = O.IdOrdine
                                            End If
                                            If O.NoEmailDemone <> enSiNo.Si Then InviaMailRispostaOrdine(RisultatoOrdine, OInt, NoteRisultatoOrdine, Uint.EmailAmministrativa, SuffissoOrdine)
                                        End If

                                    Catch ex As Exception
                                        TB.TransactionRollBack()
                                        LogMe("SORGENTE: LAVORO ONLINE " & O.IdOrdine & ", " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

                                        If ex.Message.IndexOf("Errore del server remoto: (425)") <> -1 OrElse
                                           ex.Message.IndexOf("Errore del server remoto: (550)") <> -1 Then
                                            LogMe("RICHIESTO RIAVVIO ROUTER CON BATCH")
                                            FormerLib.FormerHelper.File.ShellExtended(PathTST10)

                                        End If

                                    End Try

                                End Using
                            Else
                                OrdiniTrovati -= 1
                            End If
                        End If
                    Next

                    LogMe("Chiusura Connessione FTP")
                End Using

                LogMe("*********************************************", True)
                LogMe("LAVORI Trovati " & OrdiniTrovati)
                LogMe("LAVORI Scaricati " & OrdiniScaricati)
                LogMe("*********************************************", True)
                ris = OrdiniScaricati
            Catch ex As Exception
                LogMe("SORGENTE: ScaricaNuoviLavoriStandard(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try

            Return ris

        End Function

        Friend Shared Function CreaCommessaAutomatica(ByRef O As F.Ordine) As Integer

            Dim ris As Integer = 0
            Using mgr As New F.CommesseDAO

                Using OMgr As New F.OrdiniDAO
                    If MgrOrderLock.IsLocked(O.IdOrd) = False Then
                        Dim l As New List(Of Ordine)
                        l.Add(O)
                        Dim LockSpecifico As Integer = 0
                        Try
                            LockSpecifico = MgrOrderLock.Lock(FormerConst.UtentiSpecifici.IdUtenteAdmin, l, enFunctionLock.OrdineAperto)
                        Catch ex As Exception

                        End Try

                        If LockSpecifico Then
                            ris = mgr.CreaCommessaAutomaticaNonOffset(O)
                            Using mgrF As New FunctionLockDAO
                                mgrF.Delete(LockSpecifico)
                            End Using
                        End If

                    End If
                End Using

            End Using
            Return ris

        End Function

        Private Shared Sub InviaMsgAvviso(Testo As String,
                                          Optional IdDest As Integer = 13)
            Try
                Using m As New F.Messaggio
                    m.DataIns = Now
                    m.Titolo = "Alert dal Daemon-Synchronizer"
                    m.Testo = Testo
                    m.TipoMsg = enTipoMessaggio.Automatico
                    m.IdMitt = 0
                    m.IdDest = IdDest
                    m.Save()
                End Using
            Catch ex As Exception
                LogMe("Errore Invio Messaggio Interno - testo: " & Testo,, ex)
            End Try

        End Sub

        Public Shared Sub CreaIndirizzoIntdaOnline(IndOnline As FW.Indirizzo, ByRef TBExt As F.LUNA.LunaTransactionBox)
            Using Tb As F.LUNA.LunaTransactionBox = TBExt
                Try
                    Dim IndInt As New F.Indirizzo
                    IndInt.Nome = IndOnline.Nome
                    IndInt.Destinatario = IndOnline.Destinatario
                    IndInt.Telefono = IndOnline.Telefono
                    IndInt.Indirizzo = IndOnline.Indirizzo
                    IndInt.Citta = IndOnline.Citta
                    IndInt.Cap = IndOnline.Cap
                    IndInt.IdComune = IndOnline.IdComune
                    IndInt.IdProvincia = IndOnline.IdProvincia
                    IndInt.Predefinito = IndOnline.Predefinito
                    IndInt.IdIndOnline = IndOnline.IdIndirizzo
                    IndInt.IdRubrica = IndOnline.Utente.IdRubricaInt
                    IndInt.IdNazione = IndOnline.IdNazione
                    IndInt.Status = IndOnline.Status
                    Tb.TransactionBegin()
                    IndInt.Save()

                    IndOnline.IdIndirizzoInt = IndInt.IDIndirizzo
                    IndOnline.Save()
                    Tb.TransactionCommit()
                Catch ex As Exception
                    Tb.TransactionRollBack()
                    LogMe("SORGENTE: SincronizzaIndirizzi(), Id Indirizzo Online " & IndOnline.IdIndirizzo & " - " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
                    Throw ex
                End Try
            End Using
        End Sub

        Private Shared Function CreaIndirizzoIntdaOnline(IndOnline As FW.Indirizzo) As Integer
            Dim ris As Integer = 0

            Using IndInt As New F.Indirizzo
                IndInt.Nome = IndOnline.Nome
                IndInt.Destinatario = IndOnline.Destinatario
                IndInt.Telefono = IndOnline.Telefono
                IndInt.Indirizzo = IndOnline.Indirizzo
                IndInt.Citta = IndOnline.Citta
                IndInt.Cap = IndOnline.Cap
                IndInt.IdComune = IndOnline.IdComune
                IndInt.IdProvincia = IndOnline.IdProvincia
                IndInt.Predefinito = IndOnline.Predefinito
                IndInt.IdIndOnline = IndOnline.IdIndirizzo
                IndInt.IdRubrica = IndOnline.Utente.IdRubricaInt
                IndInt.IdNazione = IndOnline.IdNazione
                IndInt.Status = IndOnline.Status
                IndInt.Save()
                ris = IndInt.IDIndirizzo
            End Using

            Return ris
        End Function

        Private Shared Sub InviaMailRispostaOrdine(ByVal stato As enRisultatoOrdineScaricato,
                                                   ByVal Ord As F.Ordine,
                                                   ByVal Note As String,
                                                   ByVal Dest As String,
                                                   Optional SuffissoIdOrd As String = "")

            If Dest.Length Then
                Dim SoggettoMail As String = ""
                Dim TestoMail As String = ""
                Dim Attach As String = ""
                Dim ccn As String = ""

                If stato = enRisultatoOrdineScaricato.Accettato Then

                    'DISATTIVATO PER NON MANDARE PIU EMAIL AL MOMENTO DELLA RICEZIONE ORDINE

                    'SoggettoMail = "Il suo Ordine numero " & Ord.IdOrd & " è in ATTESA DI VERIFICA FILE"

                    'TestoMail = "Siamo lieti di informarla che il suo ordine:<br><br>"

                    'TestoMail &= "- data: " & Date.Now & "<br><br>"

                    'TestoMail &= "è in <b>ATTESA DI VERIFICA FILE</b>." & "<br><br>A breve verrà preso in carico da un operatore che dopo averlo verificato lo metterà in lavorazione.<br><br>"
                    'TestoMail &= "Tutte le successive comunicazioni relative a questo ordine avranno come riferimento il numero:" & "<br><br>"
                    'TestoMail &= "- numero ordine: " & Ord.IdOrd & "<br><br>"
                    'TestoMail &= "<a href=""http://www.tipografiaformer.it/" & SuffissoIdOrd & "/dettaglio-ordine"">Cliccando qui</a> puoi visualizzare il tuo ordine e controllare i file che ci hai inviato. <br><br>"
                    'TestoMail &= "<b>ATTENZIONE</b> In caso i file inviati non siano corretti invia una email a: <a href=""mailto:stampa@tipografiaformer.com?subject=File%20inviati%20non%20corretti%20Ordine%20" & Ord.IdOrd & """>stampa@tipografiaformer.com</a> in riferimento all'ordine " & Ord.IdOrd
                    'TestoMail &= "<br><b>IMPORTANTE</b>L'anteprima allegata è in bassa risoluzione al solo scopo di aiutare a identificare il lavoro in oggetto."

                    'If Attach.EndsWith("NoAnteprima.jpg") = False Then Attach = Ord.FilePath

                Else 'rifiutato

                    SoggettoMail = "Il suo ordine numero " & Ord.IdOrd & " " & SuffissoIdOrd & " è stato RIFIUTATO"

                    TestoMail = "Siamo spiacenti di informarla che il suo ordine:" & "<br><br>"

                    TestoMail &= "- data: " & Ord.DataIns & "<br><br>"

                    TestoMail &= "è stato RIFIUTATO per il seguente motivo:" & "<br><br>"
                    TestoMail &= Note & "<br><br>"
                    TestoMail &= "Restiamo a disposizione per eventuali chiarimenti. Cordiali saluti" & "<br><br>"
                    ccn = FormerConst.EmailAmministrazione
                End If

                If TestoMail.Length Then FormerHelper.Mail.InviaMail(SoggettoMail, TestoMail, Dest, , , Attach,, ccn)

            Else
                LogMe("ATTENZIONE! L' ordine " & Ord.IdOrd & " si riferisce a un cliente che ha un indirizzo email non valido")
            End If

        End Sub

        Private Shared Function ValidaOrdineWeb(ByRef O As FW.OrdineWeb) As ValidationOrderResult

            Dim RisValidazioneOrdine As ValidationOrderResult = FormerValidator.ValidaOrdineWeb(O)

            'Dim RisValidazioneOrdine As New ValidationOrderResult

            'RisValidazioneOrdine.IdOrdine = O.IdOrdine

            'Dim risValidazioneFronte As ValidationFileResult
            'Dim risValidazioneRetro As ValidationFileResult

            'Using L As New F.ListinoBase
            '    L.Read(O.IdListinoBase)

            '    risValidazioneFronte = FormerValidator.ValidateSourceFilePDF(L, O.FileScaricatiNomeFronte, O.Larghezza, O.Altezza, O.Orientamento)
            '    risValidazioneFronte.TipoSorgente = enFronteRetro.Fronte

            '    If O.TipoRetro <> enTipoRetro.RetroBianco And O.FileScaricatiNomeRetro.Length Then
            '        risValidazioneRetro = FormerValidator.ValidateSourceFilePDF(L, O.FileScaricatiNomeRetro, O.Larghezza, O.Altezza, O.Orientamento)
            '    Else
            '        risValidazioneRetro = New ValidationFileResult
            '    End If
            '    risValidazioneRetro.TipoSorgente = enFronteRetro.Retro
            'End Using

            'RisValidazioneOrdine.ValidationFileList.Add(risValidazioneFronte)
            'RisValidazioneOrdine.ValidationFileList.Add(risValidazioneRetro)

            If RisValidazioneOrdine.MaxErrorLevel > enValidatorErrorLevel.Attenzione Then 'era envalidatorerrorlevel.informazione
                Dim BufferMsg As String = String.Empty
                Dim TitoloMail As String = String.Empty

                For Each sing In RisValidazioneOrdine.ValidationFileListKO
                    BufferMsg &= "************************" & ControlChars.NewLine & "PDF " & FormerEnumHelper.TipoSorgenteStr(sing.TipoSorgente).ToUpper & ControlChars.NewLine & "************************" & ControlChars.NewLine
                    BufferMsg &= sing.ErrorBuffer & ControlChars.NewLine & ControlChars.NewLine
                Next

                If RisValidazioneOrdine.HannoOrientamentoDifferente Then
                    BufferMsg &= "ATTENZIONE - I PDF di Fronte e Retro hanno un orientamento differente;"
                End If

                If RisValidazioneOrdine.MaxErrorLevel = enValidatorErrorLevel.Errore Then
                    TitoloMail = "ATTENZIONE, Allegare nuovamente i file PDF al Lavoro " & O.IdOrdine
                    'invalido i file allegati all'ordine errati
                    'invio una mail spiegando il problema
                    'salvo un log da qualche parte che ho scartato l'ordine x per questo o quest'altro motivo

                    'SALVO UN LOG DELL'ANNULLAMENTO
                    LogMe("Rifiutato Ordine Online " & O.IdOrdine & " per mancata validazione sorgenti")

                    FormerLib.FormerLog.ScriviVoceOrdineInvalidato(O.IdOrdine, BufferMsg, O.Utente.Nominativo)

                    BufferMsg = "Gentile cliente,<br>in relazione al suo lavoro <b>" & O.IdOrdine & "</b> la informiamo che nei file PDF che ha allegato sono state riscontrate le seguenti anomalie <b>BLOCCANTI</b>: <br><br>" &
                    BufferMsg & "<br><br>Il lavoro è stato riportato nello stato <b>IN ATTESA DI ALLEGATI</b>, la preghiamo di risolvere i problemi indicati e allegare i nuovi file modificati al lavoro cliccando sul link sottostante:<br><br>" 'INTRODUZIONE ERRORE 
                    BufferMsg &= "<a href=""https://www.tipografiaformer.it/" & O.IdOrdine & "/dettaglio-lavoro""><b style=""color:red;"">ALLEGA DI NUOVO I FILE</b></a>"

                    'INVALIDO I FILE ALLEGATI ALL'ORDINE
                    O.SorgenteFronte = String.Empty
                    O.SorgenteRetro = String.Empty
                    O.Stato = enStatoOrdine.InAttesaAllegati
                    O.Save()

                    'CANCELLO I FILE FISICAMENTE CHE HO SCARICATO 
                    Try
                        If System.IO.File.Exists(O.FileScaricatiNomeFronte) Then
                            Dim PathDest As String = FormerPath.PathLogInvalidati & O.IdOrdine & "\" & FormerHelper.File.EstraiNomeFile(O.FileScaricatiNomeFronte)
                            System.IO.File.Copy(O.FileScaricatiNomeFronte, PathDest, True)
                            System.IO.File.Delete(O.FileScaricatiNomeFronte)
                        End If

                    Catch ex As Exception
                        LogMe("ATTENZIONE, Non sono riuscito a cancellare il file FRONTE relativo al lavoro Online " & O.IdOrdine)
                    End Try

                    Try
                        If System.IO.File.Exists(O.FileScaricatiNomeRetro) Then
                            Dim PathDest As String = FormerPath.PathLogInvalidati & O.IdOrdine & "\" & FormerHelper.File.EstraiNomeFile(O.FileScaricatiNomeRetro)
                            System.IO.File.Copy(O.FileScaricatiNomeRetro, PathDest, True)
                            System.IO.File.Delete(O.FileScaricatiNomeRetro)
                        End If

                    Catch ex As Exception
                        LogMe("ATTENZIONE, Non sono riuscito a cancellare il file RETRO relativo al lavoro Online " & O.IdOrdine)
                    End Try

                ElseIf RisValidazioneOrdine.MaxErrorLevel = enValidatorErrorLevel.Attenzione Then
                    TitoloMail = "INFORMAZIONI relative ai file PDF allegati al Lavoro " & O.IdOrdine
                    BufferMsg = "Gentile cliente,<br>in relazione al suo lavoro <b>" & O.IdOrdine & "</b> la informiamo che nei file PDF che ha allegato sono state riscontrate le seguenti anomalie <b>NON BLOCCANTI</b>. <br><br>" &
                         "Il processo di produzione procederà regolarmente e le anomalie riscontrate saranno risolte da un operatore.<br>Se saranno riscontrati ulteriori problemi la contatteremo prima della produzione.<br><br>La preghiamo per i prossimi ordini di fare più attenzione nella preparazione dei file PDF.<br><br>" & BufferMsg 'INTRODUZIONE ERRORE 
                End If

                If BufferMsg.Length Then
                    'qui ho qualcosa da inviargli
                    BufferMsg = BufferMsg.Replace(ControlChars.NewLine, "<br>")

                    'qui inserire un link alla guida online
                    Dim ccnAddress As String = String.Empty
                    If RisValidazioneOrdine.MaxErrorLevel = enValidatorErrorLevel.Errore Then
                        ccnAddress = "stampa@tipografiaformer.com"
                    End If
                    If O.InseritoDa = 0 Then
                        FormerLib.FormerHelper.Mail.InviaMail(TitoloMail, BufferMsg, O.Utente.Email, , , O.FileScaricatiNomeAnteprima, , ccnAddress)
                    End If

                End If
            End If

            Return RisValidazioneOrdine

        End Function

        'Private Shared Function ConfermaDataConsegna(DataInserimento As Date,
        '                                             DataDaConfermare As Date,
        '                                             IdCorriere As Integer) As Date

        '    Dim DataRiferimento As Date = DataDaConfermare
        '    Dim ggDiff As Integer = DateDiff(DateInterval.Day, DataInserimento.Date, Now.Date)

        '    If ggDiff > 0 Then

        '        Dim DataTemp As Date = DataInserimento
        '        Dim ggDaTogliere As Integer = 0

        '        For I As Integer = 1 To ggDiff
        '            DataTemp = DataTemp.AddDays(1)

        '            If MgrDataConsegna.IsFestivita(DataTemp) = True Then
        '                ggDaTogliere += 1
        '            ElseIf DataTemp.DayOfWeek = DayOfWeek.Sunday Then
        '                ggDaTogliere += 1
        '            ElseIf DataTemp.DayOfWeek = DayOfWeek.Saturday Then
        '                'qui e' sabato 
        '                'devo toglierlo solo se verra' tolto dal calcolo del posticipo 
        '                If IdCorriere = enCorriere.TipografiaFormer Or IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then
        '                    ggDaTogliere += 1
        '                End If
        '            End If
        '        Next

        '        If ggDaTogliere Then
        '            ggDiff -= ggDaTogliere
        '        End If
        '        DataRiferimento = MgrDataConsegna.PosticipaDataConsegna(DataRiferimento, IdCorriere, ggDiff)
        '    End If

        '    If IdCorriere <> enCorriere.RitiroCliente And
        '       IdCorriere <> enCorriere.TipografiaFormer And
        '       IdCorriere <> enCorriere.TipografiaFormerFuoriRaccordo Then

        '        If DataRiferimento.DayOfWeek = DayOfWeek.Saturday Then
        '            DataRiferimento = MgrDataConsegna.GetPrimaDataDisponibile(DataRiferimento, IdCorriere)
        '        End If

        '    End If

        '    Return DataRiferimento

        'End Function

        Private Shared Function ScaricaNuoviOrdiniConBlocco() As Integer

            Dim ris As Integer = 0

            'SCARICO GLI ORDINI 
            LogMe("***SCARICAMENTO NUOVI ORDINI***")
            Try
                Dim LavoriTrovati As Integer = 0
                Dim LavoriScaricati As Integer = 0
                Dim LCons As List(Of FW.Consegna) = Nothing

                Using mgr As New FW.ConsegneDAO
                    LCons = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.IdStatoConsegna, enStatoConsegna.InLavorazione),
                                        New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.Blocco, enSiNo.Si),
                                        New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.IdConsegnaInt, 0))
                    'queste viaggiano solo insieme
                End Using

                For Each singCons As FW.Consegna In LCons.ToList
                    Dim RilascioCli As Integer = 9999
                    Dim RisultatoOrdine As enRisultatoOrdineScaricato = enRisultatoOrdineScaricato.Nessuno
                    Dim NoteRisultatoOrdine As String = String.Empty

                    If singCons.Utente.IdRubricaInt <> 0 Then ' prendo in carico solo gli ordini in cui l'utente e' stato registrato senno lo salto e lascio prima al sincronizzatore l'incarico di registrarlo

                        'qui ciclo tutte le consegne e scarico tutti i sorgenti se non sono gia presenti in locale perche vuoldire che sono stati gia scaricati

                        Dim ScaricamentoSorgentiOk As Boolean = True
                        'prima scarico tutti i sorgenti
                        Dim LOrdCons As List(Of FW.OrdineWeb) = Nothing
                        Try

                            Using mgr As New FW.OrdiniWebDAO
                                LOrdCons = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.Stato, CInt(enStatoOrdine.Preinserito)),
                                                       New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.StatoWeb, CInt(enStato.Attivo)),
                                                       New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.IdOrdineInt, 0),
                                                       New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.IdCons, singCons.IdConsegna))
                            End Using

                            Dim LOrdConsTot As List(Of FW.OrdineWeb) = Nothing
                            Using mgr As New FW.OrdiniWebDAO
                                LOrdConsTot = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.StatoWeb, CInt(enStato.Attivo)),
                                                          New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.IdOrdineInt, 0),
                                                          New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.IdCons, singCons.IdConsegna))
                            End Using

                            If LOrdCons.Count = LOrdConsTot.Count Then
                                LogMe("SCARICAMENTO SORGENTI ORDINE " & singCons.IdConsegna)
                                'qui tutti i file sono stati allegati
                                LavoriTrovati += LOrdCons.Count

                                'LogMe("Apertura Connessione FTP")
                                Using Ftp As New FTPclient(FtpServer, FtpLogin, FtpPwd)
                                    LogMe("Apertura Connessione FTP")
                                    'scarico i file solo degli ordini di tipo NON OMAGGIO
                                    For Each O As FW.OrdineWeb In LOrdCons.FindAll(Function(x) x.Omaggio <> enSiNo.Si)

                                        If O.L.NoAttachFile <> enSiNo.Si Then
                                            '*********************SCARICO FILE
                                            Dim NomeSorgenteFronte As String = PathTemp & O.IdOrdine & "_" & O.SorgenteFronte
                                            Dim NomeSorgenteRetro As String = String.Empty
                                            LogMe("Cerco " & NomeSorgenteFronte)
                                            O.FileScaricatiNomeFronte = NomeSorgenteFronte

                                            Dim FileToDownloadFronte As String = "/tipografiaformer.it/ordini/" & O.IdOrdine & "/" & O.SorgenteFronte
                                            Dim FileToDownloadRetro As String = String.Empty

                                            If O.C.FR Then
                                                If O.TipoRetro = enTipoRetro.RetroDifferente Then
                                                    FileToDownloadRetro = "/tipografiaformer.it/ordini/" & O.IdOrdine & "/" & O.SorgenteRetro
                                                    NomeSorgenteRetro = PathTemp & O.IdOrdine & "_" & O.SorgenteRetro
                                                End If
                                            End If

                                            Dim CheckFileOk As Boolean = True
                                            Dim DownloadFileFronte As Boolean = True
                                            Dim DownloadFileRetro As Boolean = True

                                            'FRONTE
                                            If System.IO.File.Exists(NomeSorgenteFronte) Then
                                                'qui devo controllare se la grandezza del file e' corretta 
                                                'per ora non faccio questo controllo
                                                DownloadFileFronte = False
                                                'Dim F As New FileInfo(NomeSorgenteFronte)
                                            Else
                                                If Ftp.FtpFileExists(FileToDownloadFronte) = False Then
                                                    CheckFileOk = False
                                                End If
                                            End If
                                            'RETRO
                                            If FileToDownloadRetro.Length Then 'qui ci entro solo se il file retro va lavorato
                                                If System.IO.File.Exists(NomeSorgenteRetro) Then
                                                    DownloadFileRetro = False
                                                Else
                                                    If Ftp.FtpFileExists(FileToDownloadRetro) = False Then
                                                        CheckFileOk = False
                                                    End If
                                                End If
                                            Else
                                                DownloadFileRetro = False
                                            End If

                                            If CheckFileOk Then
                                                If DownloadFileFronte Then
                                                    RilascioCli = 9999
                                                    Ftp.Download(FileToDownloadFronte, NomeSorgenteFronte, True)
                                                Else
                                                    RilascioCli = 1
                                                End If

                                                If DownloadFileRetro Then
                                                    Ftp.Download(FileToDownloadRetro, NomeSorgenteRetro, True)
                                                Else
                                                    'sia che online che offline controllo se devo copiare i file 
                                                    'questa cosa potrei farla solo se downloadfileretro = false 
                                                    If O.C.FR Then
                                                        If O.TipoRetro = enTipoRetro.RetroUgualeFronte Then
                                                            'ricopio il fronte con il nome diverso 
                                                            NomeSorgenteRetro = PathTemp & O.IdOrdine & "_R" & O.SorgenteFronte.Substring(1)
                                                            FileCopy(NomeSorgenteFronte, NomeSorgenteRetro)

                                                            '******************************DISATTIVATO 13/11/2017 perche non serve piu 
                                                            'ElseIf O.TipoRetro = enTipoRetro.RetroBianco Then 
                                                            '    'copio un file bianco al posto del retro 
                                                            '    NomeSorgenteRetro = PathTemp & O.IdOrdine & "_R_bianco.pdf"
                                                            '    FileCopy(PathFileBianco, NomeSorgenteRetro)
                                                        End If
                                                    End If
                                                End If

                                                O.FileScaricatiNomeRetro = NomeSorgenteRetro

                                                LogMe("Scaricati sorgenti, Lavoro Online " & O.IdOrdine)
                                                Dim NomeAnteprima As String = PathTemp & Path.GetFileNameWithoutExtension(NomeSorgenteFronte) & ".jpg"
                                                Try
                                                    If FileIO.FileSystem.FileExists(NomeSorgenteFronte) Then
                                                        If NomeSorgenteFronte.EndsWith("pdf") Then
                                                            FormerHelper.PDF.GetPdfThumbnail(NomeSorgenteFronte, NomeAnteprima)
                                                        End If
                                                    End If
                                                Catch ex As Exception
                                                    'qui c'è stato un errore nella creazione dell'anteprima
                                                    'metto un file temporaneo e poi vediamo
                                                    LogMe("Errore creazione Anteprima Ordine Web " & O.IdOrdine & " :" & ex.Message, , ex)
                                                    NomeAnteprima = PathTemp & "NoAnteprima.jpg"

                                                End Try

                                                O.FileScaricatiNomeAnteprima = NomeAnteprima
                                            Else
                                                RisultatoOrdine = enRisultatoOrdineScaricato.Rifiutato
                                                NoteRisultatoOrdine = "File allegati all'ordine non presente, ricaricarli"
                                                ScaricamentoSorgentiOk = False
                                                O.Stato = enStatoOrdine.InAttesaAllegati
                                                O.Save()
                                                LogMe("ERRORE File allegati all'ordine non presenti, Ordine Online " & O.IdOrdine)
                                            End If
                                        End If

                                    Next

                                End Using
                                LogMe("Chiusura Connessione FTP")
                            Else
                                'qui non tutti gli ordini hanno ricevuto i file e erano relativi a un ordine pagato
                                ScaricamentoSorgentiOk = False
                            End If

                        Catch ex As Exception
                            LogMe("ATTENZIONE! C'è stato un errore nel collegamento FTP o nello scaricamento dei sorgenti")
                            ScaricamentoSorgentiOk = False
                        End Try

                        'qui se i sorgenti sono a posto inserisco tutti i record dell'ordine nel db
                        If ScaricamentoSorgentiOk Then

                            'qui devo fare la validazione dei sorgenti dopo averli scaricati
                            Dim ErrorLevelMaxValidazioneSorgenti As enValidatorErrorLevel = enValidatorErrorLevel.None
                            Dim ListaRisValidazioneOrdine As New List(Of ValidationOrderResult)

                            For Each O In LOrdCons.ToList
                                'QUESTO TOLIST SAREBBE SUPERFLUO MA IN REALTA VA MESSO PER EVITARE UN ERRORE CHE ORA NON MI RICORDO
                                Dim RisValidazioneOrdine As ValidationOrderResult = Nothing
                                If O.L.NoAttachFile <> enSiNo.Si Then
                                    If O.Omaggio <> enSiNo.Si Then
                                        If MgrFormerException.ValidareFileSorgente(O.IdListinoBase) = True Then
                                            RisValidazioneOrdine = ValidaOrdineWeb(O)
                                            LogMe("Validazione EFFETTUATA, MaxErrorLevel = " & RisValidazioneOrdine.MaxErrorLevelStr)
                                            ListaRisValidazioneOrdine.Add(RisValidazioneOrdine)
                                            'qui tengo il livello piu alto raggiunto da tutti gli ordini
                                            If RisValidazioneOrdine.MaxErrorLevel > ErrorLevelMaxValidazioneSorgenti Then ErrorLevelMaxValidazioneSorgenti = RisValidazioneOrdine.MaxErrorLevel
                                        End If
                                    End If
                                End If
                                If RisValidazioneOrdine Is Nothing Then
                                    RisValidazioneOrdine = New ValidationOrderResult
                                End If
                            Next

                            If ErrorLevelMaxValidazioneSorgenti < enValidatorErrorLevel.Errore Then
                                'qui processo ugualmente l'ordine 
                                'in caso è andato in errore ho gia fatto tutto 

                                Dim U As New FW.Utente
                                Dim Uint As New F.VoceRubrica
                                Dim CheckClienteOk As Boolean = True

                                U.Read(singCons.IdUt)
                                Uint.Read(U.IdRubricaInt)

                                'If U.IdRubricaInt = 0 Then
                                '    'qui devo salvare l'utente in rubrica 
                                '    'o vedere se lo trovo tra i miei 
                                '    '*********************SALVO NUOVO CLIENTE
                                '    Syncronizer.CreaRubricaIntFromWeb(Uint, U)

                                '    'Uint.Tipo = U.TipoRub
                                '    'Uint.RagSoc = U.RagSoc
                                '    'Uint.Nome = U.Nome
                                '    'Uint.Cognome = U.Cognome
                                '    'Uint.CodFisc = U.CodFisc
                                '    'Uint.Piva = U.Piva
                                '    'Uint.Email = U.Email
                                '    'Uint.IdCorriere = U.IdCorriereDef
                                '    'Uint.Indirizzo = U.Indirizzo
                                '    'Uint.Tel = U.Tel
                                '    'Uint.Fax = U.Fax
                                '    'Uint.Cellulare = U.Cellulare
                                '    'Uint.CAP = U.Cap
                                '    'Uint.Citta = U.Citta
                                '    'Uint.IdPagamento = enMetodoPagamento.PayPal  'paypal
                                '    'Uint.SitoWeb = U.SitoWeb
                                '    'Uint.ScopertoMax = 1000
                                '    'Uint.IdUtOnline = U.IdUt
                                '    'Uint.Sorgente = "W"
                                '    'Uint.DataIns = U.DataIns
                                '    'Uint.IdTipoAttivita = U.IdTipoAttivita

                                '    Using tb As F.LUNA.LunaTransactionBox = F.LUNA.LunaContext.CreateTransactionBox
                                '        Using tbO As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox
                                '            Try
                                '                tb.TransactionBegin()
                                '                tbO.TransactionBegin()
                                '                Uint.Save()
                                '                U.IdRubricaInt = Uint.IdRub
                                '                U.Save()

                                '                tb.TransactionCommit()
                                '                tbO.TransactionCommit()
                                '            Catch ex As Exception
                                '                CheckClienteOk = False
                                '                tb.TransactionRollBack()
                                '                tbO.TransactionRollBack()
                                '                LogMe("SORGENTE: ORDINE ONLINE " & singCons.IdConsegna & " Errore salvataggio nuovo cliente online: " & U.IdUt & ", " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
                                '            End Try
                                '        End Using
                                '    End Using
                                '    LogMe("Salvato Nuovo Cliente dal sito, Ordine Online " & singCons.IdConsegna)
                                'Else
                                '    Uint.Read(U.IdRubricaInt)
                                'End If
                                If CheckClienteOk Then
                                    Dim OltreScopertoMax As Boolean = False

                                    If singCons.HaUnPagamento = False Then

                                        'CHECK SU SCOPERTOMAX
                                        'If O.InseritoDa = 0 Then
                                        Dim InseritoDa As Integer = 0
                                        For Each O In singCons.ListaOrdini
                                            If O.InseritoDa Then
                                                InseritoDa = O.InseritoDa
                                                Exit For
                                            End If
                                        Next
                                        If InseritoDa = 0 Then
                                            Using MgrR As New F.VociRubricaDAO
                                                OltreScopertoMax = MgrR.OltreScopertoMax(Uint)
                                            End Using
                                        End If

                                        'End If



                                        'qui controllo che non si sia superato gia lo scoperto max
                                        ''Using MgrR As New F.VociRubricaDAO
                                        ''    If MgrR.OltreScopertoMax(Uint.IdRub, Uint.ScopertoMax) Then
                                        ''        OltreScopertoMax = True
                                        ''    End If
                                        ''End Using
                                    End If
                                    If OltreScopertoMax Then

                                        'qui avviso che l'ordine e' oltre lo scoperto massimo
                                        RisultatoOrdine = enRisultatoOrdineScaricato.Rifiutato
                                        NoteRisultatoOrdine = "Superato limite massimo di scoperto"
                                        singCons.IdStatoConsegna = enStatoConsegna.Sospesa
                                        singCons.Save()

                                    Else

                                        Dim AnteprimeToUpload As New Dictionary(Of String, String)

                                        'se arrivo qui i sorgenti sono stati sicuramente scaricati o per tutta la consegna o per il solo ordine ma in quel caso di una consegna non pagata
                                        Using tb As F.LUNA.LunaTransactionBox = F.LUNA.LunaContext.CreateTransactionBox
                                            Dim UltimoIdLavoroTrattato As Integer = 0
                                            Try
                                                '***************INIZIO TRANSAZIONE
                                                tb.TransactionBegin()
                                                'tb.TransactionBegin()
                                                'qui innanzitutto vado a inserire l'indirizzo 
                                                Dim IdIndirizzoScelto As Integer = 0

                                                If singCons.IdIndirizzo Then
                                                    'qui è stato scelto un indirizzo diverso. Per ora lo salvo nelle note e creo l'indirizzo interno 

                                                    Dim I As New FW.Indirizzo
                                                    I.Read(singCons.IdIndirizzo)

                                                    If I.IdIndirizzoInt = 0 Then
                                                        IdIndirizzoScelto = CreaIndirizzoIntdaOnline(I)
                                                    Else
                                                        IdIndirizzoScelto = I.IdIndirizzoInt
                                                    End If

                                                End If

                                                'qui innanzitutto vado a creare la consegna bloccata

                                                Dim ConsBloccata As New F.ConsegnaProgrammata
                                                Dim PagamentoRelativo As F.Pagamento = Nothing
                                                Dim DataRifOrdine As Date = singCons.Giorno

                                                DataRifOrdine = MgrDataConsegna.ConfermaDataConsegna(singCons.DataInserimento,
                                                                                     DataRifOrdine,
                                                                                     singCons.IdCorriere)

                                                'DISATTIVATA PER EVITARE CONSEGNE DI SABATO?
                                                'If singCons.IdCorriere = enCorriere.TipografiaFormer Or 
                                                'singCons.IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then DataRifOrdine = singCons.GiornoConsegna

                                                'Dim ggDiff As Integer = DateDiff(DateInterval.Day, singCons.DataInserimento.Date, Now.Date)

                                                'If ggDiff > 0 Then

                                                '    Dim DataTemp As Date = singCons.DataInserimento
                                                '    Dim ggDaTogliere As Integer = 0

                                                '    For I As Integer = 1 To ggDiff
                                                '        DataTemp = DataTemp.AddDays(1)

                                                '        If MgrDataConsegna.IsFestivita(DataTemp) = True Then
                                                '            ggDaTogliere += 1
                                                '        ElseIf DataTemp.DayOfWeek = DayOfWeek.Sunday Then
                                                '            ggDaTogliere += 1
                                                '        ElseIf DataTemp.DayOfWeek = DayOfWeek.Saturday Then
                                                '            'qui e' sabato 
                                                '            'devo toglierlo solo se verra' tolto dal calcolo del posticipo 
                                                '            If singCons.IdCorriere = enCorriere.TipografiaFormer Or
                                                '                singCons.IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then
                                                '                ggDaTogliere += 1
                                                '            End If
                                                '        End If
                                                '    Next

                                                '    If ggDaTogliere Then
                                                '        ggDiff -= ggDaTogliere
                                                '    End If

                                                '    'qui devo ricalcolare la data di consegna 
                                                '    'senza calcolare i sabati e o le domeniche come nella funzione che posticipa
                                                '    DataRifOrdine = MgrDataConsegna.PosticipaDataConsegna(DataRifOrdine,
                                                '                                               singCons.IdCorriere,
                                                '                                               ggDiff)
                                                'End If

                                                ''If ggDiff > 0 Then
                                                ''    Dim mg As New MgrDataConsegna
                                                ''    DataRifOrdine = mg.PosticipaDataConsegna(DataRifOrdine, _
                                                ''                                               singCons.IdCorriere, _
                                                ''                                               ggDiff)
                                                ''End If

                                                'If singCons.IdCorriere <> enCorriere.RitiroCliente And
                                                '    singCons.IdCorriere <> enCorriere.TipografiaFormer And
                                                '    singCons.IdCorriere <> enCorriere.TipografiaFormerFuoriRaccordo Then

                                                '    If DataRifOrdine.DayOfWeek = DayOfWeek.Saturday Then
                                                '        DataRifOrdine = MgrDataConsegna.GetPrimaDataDisponibile(DataRifOrdine, singCons.IdCorriere)
                                                '    End If

                                                'End If

                                                ConsBloccata.Giorno = DataRifOrdine
                                                ConsBloccata.DataPrevistaOriginale = singCons.GiornoConsegna
                                                ConsBloccata.IdCorr = singCons.IdCorriere

                                                If ConsBloccata.Giorno.DayOfWeek = DayOfWeek.Saturday Then
                                                    ConsBloccata.MatPom = enMomentoConsegna.Mattina
                                                Else
                                                    ConsBloccata.MatPom = enMomentoConsegna.Pomeriggio
                                                End If

                                                ConsBloccata.IdIndirizzo = IdIndirizzoScelto
                                                ConsBloccata.IdRub = Uint.IdRub
                                                ConsBloccata.NumColli = 0
                                                ConsBloccata.Peso = singCons.Peso
                                                ConsBloccata.IdPagam = singCons.IdPagam
                                                ConsBloccata.TipoDoc = singCons.TipoDoc
                                                ConsBloccata.LastUpdate = enSiNo.Si
                                                ConsBloccata.EmailNotificheCorriere = singCons.EmailNotificheCorriere
                                                ConsBloccata.IdConsOnline = singCons.IdConsegna

                                                If ConsBloccata.IdPagam <> enMetodoPagamento.ContrassegnoAlRitiro Then
                                                    If ConsBloccata.IdIndirizzo Then
                                                        'If MgrFormerException.InserireCartaceoNelPaccoSeIndirizzoDiverso(ConsBloccata) Then
                                                        ConsBloccata.NoCartaceo = enSiNo.Si
                                                        'Else
                                                        'ConsBloccata.NoCartaceo = enSiNo.No
                                                        'End If
                                                    Else
                                                        ConsBloccata.NoCartaceo = singCons.NoCartaceo
                                                    End If
                                                Else
                                                    ConsBloccata.NoCartaceo = singCons.NoCartaceo
                                                End If

                                                ConsBloccata.AssRilIntMitt = Uint.AssRilIntMitt
                                                ConsBloccata.ImportoNetto = singCons.ImportoNetto

                                                Dim ForzareStampaDocumenti As Boolean = False
                                                For Each O As FW.OrdineWeb In LOrdCons.ToList
                                                    If MgrFormerException.ForzareStampaAutomaticaDocumenti(O.IdListinoBase) Then
                                                        ForzareStampaDocumenti = True
                                                        Exit For
                                                    End If
                                                Next

                                                If singCons.HaUnPagamento OrElse
                                                    Uint.StampaAutomaticaDocumenti = enSiNo.Si OrElse
                                                    ForzareStampaDocumenti = True OrElse
                                                    (ConsBloccata.IdCorr <> enCorriere.RitiroCliente And
                                                    ConsBloccata.IdCorr <> enCorriere.TipografiaFormer And
                                                    ConsBloccata.IdCorr <> enCorriere.TipografiaFormerFuoriRaccordo) Then
                                                    ConsBloccata.StampaDocumenti = enStampaDocumenti.Si
                                                Else
                                                    ConsBloccata.StampaDocumenti = enStampaDocumenti.No
                                                End If

                                                'If singCons.HaUnPagamento Then

                                                Dim FatturareConSnc As Boolean = False

                                                For Each O In LOrdCons.ToList
                                                    If MgrFormerException.FatturareConSnc(O.IdListinoBase) Then
                                                        FatturareConSnc = True
                                                        Exit For
                                                    End If
                                                Next

                                                If FatturareConSnc Then
                                                    ConsBloccata.IdAziendaForzata = MgrAziende.IdAziende.AziendaSnc
                                                Else
                                                    ConsBloccata.IdAziendaForzata = MgrAziende.IdAziende.AziendaSrl
                                                End If

                                                'End If

                                                ConsBloccata.IdStatoConsegna = enStatoConsegna.InLavorazione
                                                ConsBloccata.Blocco = enSiNo.Si
                                                ConsBloccata.Save()

                                                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, ConsBloccata.IdCons, "CREATA NUOVA CONSEGNA CON PAGAMENTO ANTICIPATO")
                                                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, ConsBloccata.IdCons, "Giorno: " & DataRifOrdine.ToString("dd/MM/yyyy") & " Data Prevista Originale: " & singCons.GiornoConsegna.ToString("dd/MM/yyyy"))

                                                If singCons.HaUnPagamento Then
                                                    PagamentoRelativo = New F.Pagamento
                                                    PagamentoRelativo.IdConsegna = ConsBloccata.IdCons
                                                    PagamentoRelativo.IdRub = Uint.IdRub
                                                    PagamentoRelativo.Importo = singCons.PagamentoOrdine.Importo
                                                    PagamentoRelativo.DataPag = singCons.PagamentoOrdine.Quando
                                                    PagamentoRelativo.IdTipoPagamento = singCons.PagamentoOrdine.IdTipoPagamento
                                                    PagamentoRelativo.Descrizione = "Pagamento Anticipato con " & FormerEnumHelper.TipoPagamentoStr(singCons.PagamentoOrdine.IdTipoPagamento)
                                                    PagamentoRelativo.Tipo = enTipoVoceContab.VoceVendita
                                                    PagamentoRelativo.Save()
                                                End If

                                                For Each O As FW.OrdineWeb In LOrdCons.ToList 'ciclo negli ordini della consegna 

                                                    Dim PreRefineErrorCode As Integer = enErroriPreRefine.Nessuno

                                                    UltimoIdLavoroTrattato = O.IdOrdine

                                                    Dim L As New F.ListinoBase
                                                    L.Read(O.IdProdotto)

                                                    Dim NFogliVis As Integer = 0

                                                    If O.L.Target = enTargetListinoBase.Foglio Then
                                                        NFogliVis = O.Nfogli
                                                    Else
                                                        If O.C.FR Then
                                                            NFogliVis = O.Nfogli * 2
                                                        Else
                                                            NFogliVis = O.Nfogli
                                                        End If

                                                    End If

                                                    Dim CodiceCalcolato As String = L.CreaCodProd(O.Qta,
                                                                                                  NFogliVis,
                                                                                                  O.L.ShowLabelFogli)

                                                    Dim P As F.Prodotto

                                                    Dim Pl As List(Of F.Prodotto) = Nothing

                                                    Using PMgr As New F.ProdottiDAO
                                                        Pl = PMgr.FindAll(New F.LUNA.LunaSearchParameter(LFM.Prodotto.Codice, CodiceCalcolato))
                                                    End Using

                                                    Dim PrezzoPubbl As Decimal = 0
                                                    Dim PrezzoRiv As Decimal = 0

                                                    If Uint.Tipo = enTipoRubrica.Cliente Then
                                                        PrezzoRiv = 0
                                                        PrezzoPubbl = O.PrezzoCalcolatoNetto
                                                    Else
                                                        PrezzoRiv = O.PrezzoCalcolatoNetto
                                                        PrezzoPubbl = 0
                                                    End If

                                                    Dim QuantitaProdotto As Integer = 1
                                                    Dim QuantitaAcquistata As Integer = 1

                                                    'If O.L.TipoPrezzo = enTipoPrezzo.SuQuantita Then
                                                    '    QuantitaProdotto = 1 'O.Qta''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                                                    '    QuantitaAcquistata = O.Qta '1 ''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                                                    'ElseIf O.L.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                                                    '    QuantitaProdotto = 1
                                                    '    QuantitaAcquistata = O.Qta
                                                    'ElseIf O.L.TipoPrezzo = enTipoPrezzo.SuCopie Then
                                                    '    QuantitaProdotto = 1
                                                    '    QuantitaAcquistata = O.Qta
                                                    'End If

                                                    QuantitaProdotto = 1
                                                    QuantitaAcquistata = O.Qta

                                                    If Pl.Count Then
                                                        P = Pl(0)
                                                        P.Descrizione = L.NomeEx '& " " & QuantitaProdotto
                                                        P.Prezzo = PrezzoRiv
                                                        P.PrezzoPubbl = PrezzoPubbl
                                                        P.NumColli = O.NumeroColli
                                                        P.PesoComplessivo = O.Peso
                                                        P.NumPezzi = QuantitaProdotto
                                                        P.TipoProd = O.P.TipoProd
                                                        If P.IdListinoBase = 0 Then P.IdListinoBase = O.IdListinoBase

                                                        If P.NumFacciate = 0 Then
                                                            P.NumFacciate = NFogliVis
                                                            P.NoImpiantiSuFacciate = IIf(O.L.nofaccsuimpianti, enSiNo.Si, enSiNo.No)  'IIf(O.L.ShowLabelFogli, enSiNo.Si, enSiNo.No)
                                                        End If
                                                        P.Save()
                                                    Else
                                                        P = L.CreaProdDaListinoBase(QuantitaProdotto,
                                                                                    NFogliVis,
                                                                                    O.NumeroColli,
                                                                                    O.Peso,
                                                                                    PrezzoRiv,
                                                                                    PrezzoPubbl,
                                                                                    O.L.ShowLabelFogli,
                                                                                    O.L.GetLabelFogli,
                                                                                    NFogliVis)
                                                        LogMe("Creato Nuovo Prodotto " & P.Codice & ", Ordine Online " & O.IdOrdine)
                                                    End If

                                                    Dim IdOrd As Integer = 0

                                                    Dim OInt As New F.Ordine
                                                    OInt.IdRub = U.IdRubricaInt
                                                    OInt.IdProd = P.IdProd
                                                    OInt.IdCorriere = O.IdCorriere
                                                    If singCons.HaUnPagamento Then
                                                        OInt.Preventivo = enSiNo.No
                                                    Else
                                                        OInt.Preventivo = O.Preventivo
                                                    End If
                                                    OInt.IdIndirizzo = IdIndirizzoScelto
                                                    OInt.Orientamento = O.Orientamento

                                                    Dim Annotazioni As String = O.Annotazioni
                                                    OInt.Annotazioni = Annotazioni
                                                    OInt.TipoConsegna = O.TipoConsegna
                                                    OInt.RilascioCli = RilascioCli 'in rilasciocli metto 9999 se dal sito, 1 se non ci sono i file online e allora e' dal gestionale 

                                                    OInt.NomeLavoro = O.NomeLavoro

                                                    OInt.OrdineInOmaggio = O.OrdineInOmaggio

                                                    OInt.IdOrdineProvvisorio = singCons.IdConsegna

                                                    '**********************************************
                                                    'PRODOTTI SPECIFICI
                                                    '**********************************************
                                                    If MgrFormerException.UsareNomeLavoroInFattura(OInt) Then
                                                        OInt.UsaNomeLavoroInFattura = enSiNo.Si
                                                    Else
                                                        'OInt.UsaNomeLavoroInFattura = enSiNo.No
                                                        OInt.UsaNomeLavoroInFattura = O.UsaNomeLavoroInFattura
                                                    End If
                                                    OInt.IdMailPreventivo = O.IdMailPreventivo

                                                    OInt.DataIns = O.DataIns
                                                    OInt.DataPrevProduzione = O.DataPrevProduzione
                                                    OInt.DataPrevConsegna = O.DataPrevConsegna

                                                    OInt.DataCambioStato = Date.Now
                                                    OInt.IdTipoProd = O.P.IdReparto
                                                    OInt.Lungo = O.Altezza
                                                    OInt.Largo = O.Larghezza
                                                    OInt.Profondita = O.Profondita
                                                    OInt.IdMacchinarioProduzioneUtilizzato = O.IdMacchinarioProduzioneUtilizzato

                                                    OInt.ConsegnaGarantita = O.ConsegnaGarantita
                                                    OInt.ConsegnaGarantitaDa = O.ConsegnaGarantitaDa

                                                    Dim risValidazioneOrdine As ValidationOrderResult = ListaRisValidazioneOrdine.Find(Function(x) x.IdOrdine = O.IdOrdine)

                                                    If OInt.OrdineInOmaggio = enSiNo.Si Then
                                                        OInt.Stato = enStatoOrdine.Imballaggio
                                                    Else
                                                        If O.L.NoAttachFile <> enSiNo.Si Then
                                                            If O.P.IdReparto <> enRepartoWeb.StampaDigitale Then
                                                                Dim TotPagineNeiSorgenti As Integer = FormerHelper.PDF.GetNumeroPagine(O.FileScaricatiNomeFronte)
                                                                If O.FileScaricatiNomeRetro.Length Then TotPagineNeiSorgenti += FormerHelper.PDF.GetNumeroPagine(O.FileScaricatiNomeRetro)
                                                                PreRefineErrorCode = MgrPreRefineCheck.CheckOrder(risValidazioneOrdine,
                                                                                                          L,
                                                                                                          TotPagineNeiSorgenti,
                                                                                                          O.Nfogli,
                                                                                                          O.TipoRetro)
                                                            End If

                                                        End If

                                                        'Dim VaiARefine As Boolean = True
                                                        'If risValidazioneOrdine.HannoDimensioniErrate AndAlso OInt.ListinoBase.Preventivazione.IdReparto <> enRepartoWeb.Ricamo Then
                                                        '    VaiARefine = False
                                                        'End If
                                                        'If O.L.Preventivazione.IdReparto = enRepartoWeb.StampaOffset Then
                                                        '    If VaiARefine Then
                                                        '        Using mgr As New ModelliCommessaDAO
                                                        '            Using fp As New FormatoProdotto
                                                        '                fp.Read(O.L.IdFormProd)
                                                        '                Dim Ml As List(Of ModelloCommessa) = mgr.FindByFormatoProdotto(fp)
                                                        '                Ml = Ml.FindAll(Function(x) x.FormatiProdotto.Count = 1)
                                                        '                If O.L.ColoreStampa.FR Then
                                                        '                    Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.Si)
                                                        '                Else
                                                        '                    Ml = Ml.FindAll(Function(x) x.FronteRetro = enSiNo.No)
                                                        '                End If

                                                        '                If Ml.Count = 0 Then
                                                        '                    VaiARefine = False
                                                        '                End If
                                                        '            End Using
                                                        '        End Using
                                                        '    End If
                                                        'End If

                                                        If MgrFormerException.ValidareFileSorgente(O.IdListinoBase) Then
                                                            If PreRefineErrorCode = enErroriPreRefine.Nessuno Then
                                                                'MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Nessun errore PreRefine, l'ordine passa a Refineautomatico")
                                                                OInt.Stato = enStatoOrdine.RefineAutomatico
                                                            Else
                                                                'MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Errore Prerefine " & PreRefineErrorCode & ", l'ordine passa a Preinserito")
                                                                OInt.Stato = enStatoOrdine.Preinserito
                                                            End If
                                                        Else
                                                            OInt.Stato = enStatoOrdine.Registrato
                                                        End If



                                                        'OInt.Stato = enStatoOrdine.Preinserito

                                                        'If Not RisValidazioneOrdine Is Nothing AndAlso RisValidazioneOrdine.MaxErrorLevel = enValidatorErrorLevel.None Then
                                                        '    OInt.Stato = enStatoOrdine.Registrato

                                                    End If

                                                    OInt.PreRefineErrorCode = PreRefineErrorCode
                                                    OInt.Qta = QuantitaAcquistata
                                                    OInt.PeriodoPrevConsegna = enMomentoConsegna.Pomeriggio
                                                    OInt.FilePath = O.FileScaricatiNomeAnteprima
                                                    OInt.NFogli = O.Nfogli
                                                    OInt.TipoRetro = O.TipoRetro
                                                    OInt.OrdMail = True
                                                    OInt.Mq = O.Mq

                                                    If Uint.Tipo = enTipoRubrica.Cliente Then
                                                        OInt.PrezzoProd = P.PrezzoPubbl
                                                    Else
                                                        OInt.PrezzoProd = P.Prezzo
                                                    End If

                                                    OInt.TotaleForn = O.PrezzoCalcolatoNetto

                                                    OInt.Sconto = O.Sconto
                                                    OInt.Ricarico = O.Ricarico

                                                    OInt.IdCoupon = O.IdCoupon
                                                    OInt.IdPromo = O.IdPromo

                                                    OInt.CostoSped = O.PrezzoCorriere

                                                    Dim listLav As New List(Of Integer)
                                                    For Each singL As String In O.Lavorazioni.Split(",").ToList
                                                        If singL.Length Then listLav.Add(CInt(singL))
                                                    Next

                                                    If O.InseritoDa = 0 Then
                                                        Using MgrL As New F.LavorazioniDAO
                                                            listLav = MgrL.RiordinaListaLav(listLav, O.IdListinoBase)
                                                        End Using
                                                    End If

                                                    OInt.ListaLavorazioniCustom = listLav.ToArray

                                                    OInt.IdOrdOnline = O.IdOrdine

                                                    OInt.UsaLavorazioniDefault = False

                                                    'nuova gestione plugin
                                                    GestisciOrdiniConPlugin(L, OInt, O)

                                                    OInt.ExtraData = O.ExtraData

                                                    'PLUGIN PACKAGING
                                                    'If L.Preventivazione.IdReparto = enRepartoWeb.Packaging AndAlso L.Preventivazione.IdFunzionePack <> 0 Then
                                                    '    If O.IdTipoFustella = 0 Then
                                                    '        If O.Altezza <> 0 And O.Profondita <> 0 And O.Larghezza <> 0 Then
                                                    '            Using mgr As New F.TipoFustelleDAO
                                                    '                Dim lFustelle As List(Of F.TipoFustella) = mgr.GetAll()
                                                    '                Dim SingF As F.TipoFustella = lFustelle.Find(Function(x) x.IdPrev = L.Preventivazione.IdPrev And _
                                                    '                                                                    x.Altezza = O.Altezza And _
                                                    '                                                                    x.Base = O.Larghezza And _
                                                    '                                                                    x.Profondita = O.Profondita)
                                                    '                Dim IdTipoFustellaDaUsare As Integer = 0
                                                    '                If SingF Is Nothing Then
                                                    '                    'fustella da creare
                                                    '                    LogMe("Creata Nuova Fustella " & O.Larghezza & "x" & O.Profondita & "x" & O.Altezza & ", Ordine Online " & O.IdOrdine)

                                                    '                    SingF = New F.TipoFustella
                                                    '                    SingF.IdPrev = L.Preventivazione.IdPrev
                                                    '                    SingF.Disponibile = enSiNo.No
                                                    '                    SingF.Profondita = O.Profondita
                                                    '                    SingF.Altezza = O.Altezza
                                                    '                    SingF.Base = O.Larghezza
                                                    '                    IdTipoFustellaDaUsare = SingF.Save()

                                                    '                Else
                                                    '                    IdTipoFustellaDaUsare = SingF.IdTipoFustella
                                                    '                End If
                                                    '                OInt.IdTipoFustella = IdTipoFustellaDaUsare
                                                    '            End Using
                                                    '        End If
                                                    '    Else
                                                    '        'fustella gia esistente
                                                    '        OInt.IdTipoFustella = O.IdTipoFustella
                                                    '    End If
                                                    'End If

                                                    IdOrd = OInt.SaveFirstTime(O.InseritoDa)

                                                    If IdOrd = 0 Then
                                                        Throw New Exception("IdOrdine Interno salvato = 0 errore GRAVE")
                                                    End If

                                                    'CREAZIONE COMMESSA AUTOMATICA PER GLI ORDINI DI TIPO OMAGGIO
                                                    'If OInt.OrdineInOmaggio = enSiNo.Si Then
                                                    '    'per trovare la tiratura media la prendo dal modello commessa che sara' specifico per quel formato prodotto specifico
                                                    '    'se inferiori al 10% di giacenza creo la commessa automatica a carico di former
                                                    '    'inserisco l'ordine direttamente interno
                                                    '    Dim MinimaleGiacenza As Integer = 0

                                                    '    'If P.NumPezzi > MinimaleGiacenza Then
                                                    '    '    P.NumPezzi -= 1
                                                    '    '    P.Save()
                                                    '    'End If

                                                    'End If

                                                    If Not risValidazioneOrdine Is Nothing AndAlso risValidazioneOrdine.MaxErrorLevel > enValidatorErrorLevel.None Then

                                                        'qui c'e' stato un errore di validazione e creo un messaggio

                                                        Dim BufferErrore As String = String.Empty
                                                        For Each sing In risValidazioneOrdine.ValidationFileListKO
                                                            BufferErrore &= "************" & ControlChars.NewLine & "PDF " & FormerEnumHelper.TipoSorgenteStr(sing.TipoSorgente).ToUpper & ": " & ControlChars.NewLine & "************" & ControlChars.NewLine
                                                            BufferErrore &= sing.ErrorBuffer(True) & ControlChars.NewLine & ControlChars.NewLine
                                                        Next

                                                        If risValidazioneOrdine.HannoOrientamentoDifferente Then
                                                            BufferErrore &= "ATTENZIONE: I PDF di Fronte e Retro hanno un orientamento differente"
                                                        End If

                                                        Try
                                                            Using m As New F.Messaggio
                                                                m.IdOrd = IdOrd
                                                                'm.IdDest = FormerConst.UtentiSpecifici.IdUtenteAndrea
                                                                m.DataIns = Now
                                                                m.IdMitt = 0
                                                                m.Titolo = "Validazione Sorgenti"
                                                                m.TipoMsg = enTipoMessaggio.Automatico
                                                                m.Testo = BufferErrore
                                                                m.Save()
                                                            End Using
                                                        Catch ex As Exception
                                                            LogMe("Errore Invio Messaggio Interno - testo: " & BufferErrore,, ex)
                                                        End Try

                                                    End If

                                                    Dim UploadAnteprima As Boolean = False
                                                    If OInt.OrdineInOmaggio <> enSiNo.Si Then
                                                        If O.L.NoAttachFile <> enSiNo.Si Then
                                                            If OInt.FilePath <> PathTemp & "NoAnteprima.jpg" Then
                                                                UploadAnteprima = True
                                                            End If
                                                        End If
                                                    End If

                                                    O.IdOrdineInt = IdOrd
                                                    Dim NuovoNomeAnteprima As String = String.Empty

                                                    If O.L.NoAttachFile <> enSiNo.Si Then
                                                        NuovoNomeAnteprima = IdOrd & "_A" & Path.GetFileNameWithoutExtension(O.SorgenteFronte) & ".jpg"
                                                    End If

                                                    If UploadAnteprima Then
                                                        O.Anteprima = NuovoNomeAnteprima
                                                        OInt.FilePath = PathTemp & NuovoNomeAnteprima
                                                        Using mgr As New F.OrdiniDAO
                                                            mgr.SalvaFile(OInt)
                                                        End Using
                                                    End If

                                                    'O.Save()
                                                    Dim NumPagina As Integer = 1
                                                    '***************************SALVO I SORGENTI 
                                                    If OInt.OrdineInOmaggio <> enSiNo.Si Then

                                                        If O.L.NoAttachFile <> enSiNo.Si Then
                                                            Dim Sorg As F.FileSorgente

                                                            Dim NumPag As Integer = FormerHelper.PDF.GetNumeroPagine(O.FileScaricatiNomeFronte)

                                                            If NumPag > 1 Then
                                                                LogMe("Trovato File Fronte multipagina.")

                                                                Try
                                                                    For i As Integer = 1 To NumPag

                                                                        Dim PathEnd As String = O.FileScaricatiNomeFronte.ToLower.Replace(".pdf", ".p" & i.ToString("0000") & ".pdf")

                                                                        FormerHelper.PDF.EstraiPaginaFromPdf(O.FileScaricatiNomeFronte, PathEnd, i)

                                                                        Dim risCopia As enStatoRefineSorgente = enStatoRefineSorgente.NonDefinito
                                                                        If O.Stato = enStatoOrdine.RefineAutomatico Then
                                                                            risCopia = CopiaSorgenteToRefine(PathEnd)
                                                                        End If

                                                                        Sorg = New F.FileSorgente
                                                                        Sorg.IdOrd = IdOrd
                                                                        Sorg.FilePath = PathEnd
                                                                        Sorg.NumPagina = NumPagina
                                                                        Sorg.StatoRefine = risCopia
                                                                        Sorg.Save()
                                                                        Sorg = Nothing

                                                                        NumPagina += 1

                                                                    Next
                                                                Catch ex As Exception
                                                                    LogMe("Si è verificato un errore nel estrazione della pagine dal sorgente",, ex)
                                                                End Try

                                                                Try
                                                                    System.IO.File.Delete(O.FileScaricatiNomeFronte)
                                                                Catch ex As Exception
                                                                    LogMe("Non sono riuscito a cancellare il file sorgente del fronte.")
                                                                End Try
                                                            Else
                                                                Dim NuovoNomeSorgenteFronte As String = PathTemp & IdOrd & "_" & O.SorgenteFronte

                                                                Sorg = New F.FileSorgente
                                                                Sorg.IdOrd = IdOrd
                                                                Rename(O.FileScaricatiNomeFronte, NuovoNomeSorgenteFronte)

                                                                Dim risCopia As enStatoRefineSorgente = enStatoRefineSorgente.NonDefinito

                                                                If O.Stato = enStatoOrdine.RefineAutomatico Then
                                                                    risCopia = CopiaSorgenteToRefine(NuovoNomeSorgenteFronte)
                                                                End If

                                                                Sorg.FilePath = NuovoNomeSorgenteFronte
                                                                Sorg.NumPagina = NumPagina
                                                                Sorg.StatoRefine = risCopia
                                                                Sorg.Save()
                                                                Sorg = Nothing

                                                                NumPagina += 1
                                                            End If

                                                            If O.FileScaricatiNomeRetro.Length Then

                                                                NumPag = FormerHelper.PDF.GetNumeroPagine(O.FileScaricatiNomeRetro)

                                                                If NumPag > 1 Then
                                                                    LogMe("Trovato File retro multipagina.")
                                                                    Try
                                                                        For i As Integer = 1 To NumPag

                                                                            Dim PathEnd As String = O.FileScaricatiNomeRetro.ToLower.Replace(".pdf", ".p" & i.ToString("0000") & ".pdf")

                                                                            FormerHelper.PDF.EstraiPaginaFromPdf(O.FileScaricatiNomeRetro, PathEnd, i)

                                                                            Dim risCopia As enStatoRefineSorgente = enStatoRefineSorgente.NonDefinito
                                                                            If O.Stato = enStatoOrdine.RefineAutomatico Then
                                                                                risCopia = CopiaSorgenteToRefine(PathEnd)
                                                                            End If

                                                                            Sorg = New F.FileSorgente
                                                                            Sorg.IdOrd = IdOrd
                                                                            Sorg.FilePath = PathEnd
                                                                            Sorg.NumPagina = NumPagina
                                                                            Sorg.StatoRefine = risCopia
                                                                            Sorg.Save()
                                                                            Sorg = Nothing

                                                                            NumPagina += 1

                                                                        Next
                                                                    Catch ex As Exception
                                                                        LogMe("Si è verificato un errore nel estrazione della pagine dal sorgente",, ex)
                                                                    End Try

                                                                    Try
                                                                        System.IO.File.Delete(O.FileScaricatiNomeRetro)
                                                                    Catch ex As Exception
                                                                        LogMe("Non sono riuscito a cancellare il file sorgente del retro.")
                                                                    End Try

                                                                    'delete originale
                                                                Else
                                                                    Dim ParteNuovoSorgenteRetro As String = O.FileScaricatiNomeRetro.Substring(O.FileScaricatiNomeRetro.IndexOf("_R_"))
                                                                    Dim NuovoNomeSorgenteRetro As String = PathTemp & IdOrd & ParteNuovoSorgenteRetro

                                                                    Sorg = New F.FileSorgente
                                                                    Sorg.IdOrd = IdOrd
                                                                    Rename(O.FileScaricatiNomeRetro, NuovoNomeSorgenteRetro)

                                                                    Dim risCopia As enStatoRefineSorgente = enStatoRefineSorgente.NonDefinito
                                                                    If O.Stato = enStatoOrdine.RefineAutomatico Then
                                                                        risCopia = CopiaSorgenteToRefine(NuovoNomeSorgenteRetro)
                                                                    End If

                                                                    Sorg.FilePath = NuovoNomeSorgenteRetro
                                                                    Sorg.NumPagina = NumPagina
                                                                    Sorg.StatoRefine = risCopia
                                                                    Sorg.Save()
                                                                    Sorg = Nothing
                                                                End If

                                                            End If
                                                        End If


                                                        'qui se il listino base non ha il cubetto o non ha la quantitacollo mando un alert a antonio
                                                        'InviaMsgAvviso
                                                        Dim MsgAvviso As String = String.Empty
                                                        If OInt.ListinoBase.IdModelloCubetto = 0 Then
                                                            MsgAvviso = "Listino Base: " & OInt.ListinoBase.NomeEx & ", Modello Cubetto non presente" & ControlChars.NewLine
                                                        End If

                                                        If OInt.ListinoBase.QtaCollo = 0 Or (OInt.ListinoBase.QtaCollo = 1 And OInt.ListinoBase.Preventivazione.IdReparto <> enRepartoWeb.StampaDigitale) Then
                                                            MsgAvviso = "Listino Base: " & OInt.ListinoBase.NomeEx & ", Quantità Collo non presente" & ControlChars.NewLine
                                                        End If

                                                        If MsgAvviso.Length Then
                                                            InviaMsgAvviso(MsgAvviso)
                                                        End If

                                                    End If


                                                    LogMe("Inserito Lavoro " & IdOrd)

                                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Scaricato Lavoro da sito. Lavoro Online " & O.IdOrdine)
                                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Prodotto: " & P.Descrizione)
                                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Cliente: " & Uint.RagSocNome)
                                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Stato Iniziale: " & FormerEnumHelper.StatoOrdineString(OInt.Stato))
                                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "PreRefineErrorCheck: " & OInt.PreRefineErrorCode)
                                                    Dim BufferLavorazioni As String = String.Empty

                                                    For Each lLav As Lavorazione In OInt.ListaLavori
                                                        BufferLavorazioni &= lLav.Descrizione & "; "
                                                    Next

                                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Lavorazioni: " & BufferLavorazioni)
                                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "****************************************")

                                                    Dim PathOrdine As String = FormerPath.PathLog & IdOrd & "\" & IdOrd & ".xml"
                                                    FormerSerializator.SerializeObjectToFile(OInt, PathOrdine)

                                                    If OInt.OrdineInOmaggio = enSiNo.Si Then
                                                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "OMAGGIO " & OInt.NomeLavoro)
                                                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "****************************************")
                                                    End If

                                                    'carico online l'anteprima
                                                    If UploadAnteprima Then

                                                        Rename(O.FileScaricatiNomeAnteprima, PathTemp & NuovoNomeAnteprima)
                                                        Dim NomeFileAnteprimaOnline As String = "/tipografiaformer.it/ordini/" & O.IdOrdine & "/" & NuovoNomeAnteprima

                                                        AnteprimeToUpload.Add(PathTemp & NuovoNomeAnteprima, NomeFileAnteprimaOnline)

                                                    End If

                                                    RisultatoOrdine = enRisultatoOrdineScaricato.Accettato

                                                    'qui devo creare in automatico la commessa per gli ordini dei reparti non offset
                                                    'questo non serve piu qui
                                                    'If OInt.OrdineInOmaggio <> enSiNo.Si Then
                                                    '    CreaCommessaAutomatica(OInt)
                                                    'End If

                                                    'qui creo la consegna programmata per l'ordine
                                                    'o gestisco il salvataggio della consegna esistente se bloccata per un pagamento

                                                    Using mgr As New F.ConsegneProgrammateDAO
                                                        'questa parte va tutta rivista, devo inserire una consegna para para a quella online e bloccarla
                                                        'e salvare il pagamento

                                                        Dim DataRifConsegna As Date = OInt.DataPrevProduzione
                                                        If OInt.IdCorriere = enCorriere.TipografiaFormer Then DataRifConsegna = OInt.DataPrevConsegna

                                                        Dim momentoConsegna As enMomentoConsegna = enMomentoConsegna.Pomeriggio

                                                        If OInt.IdCorriere = enCorriere.RitiroCliente And DataRifConsegna.DayOfWeek = DayOfWeek.Saturday Then
                                                            momentoConsegna = enMomentoConsegna.Mattina
                                                        End If

                                                        mgr.RegistraConsegnaOrdineSuGiorno(OInt.IdOrd,
                                                                                            OInt.IdCorriere,
                                                                                            DataRifConsegna,
                                                                                            OInt.IdRub,
                                                                                            momentoConsegna,
                                                                                            OInt.IdIndirizzo,
                                                                                            ConsBloccata)

                                                    End Using

                                                    LogMe("Consegna " & ConsBloccata.IdCons & " creata per l'ordine " & IdOrd)
                                                    LavoriScaricati += 1
                                                Next 'next lavoro

                                                LogMe("Salvo la consegna bloccata")
                                                ConsBloccata.LastUpdate = 0
                                                ConsBloccata.Save()

                                                LogMe("Aggiorno la consegna online")
                                                'a questo punto vado a salvare online che la transazione e' andata bene
                                                Using tbOnline As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox()
                                                    Try
                                                        LogMe("Apro la transactionbox")
                                                        tbOnline.TransactionBegin()
                                                        Dim ConsOnline As New FW.Consegna
                                                        ConsOnline.Read(singCons.IdConsegna)
                                                        ConsOnline.IdConsegnaInt = ConsBloccata.IdCons
                                                        If Not PagamentoRelativo Is Nothing Then ConsOnline.PagamentoOrdine.IdPagInt = PagamentoRelativo.IdPag
                                                        LogMe("Salvo gli ordini")
                                                        For Each O As FW.IOrdineWeb In LOrdCons.ToList
                                                            O.Save()
                                                        Next
                                                        LogMe("Salvo la consegna online")
                                                        ConsOnline.Save()
                                                        If Not PagamentoRelativo Is Nothing Then ConsOnline.PagamentoOrdine.Save()
                                                        LogMe("Chiudo la transactionbox")
                                                        tbOnline.TransactionCommit()
                                                        LogMe("Transaction box chiusa")
                                                    Catch ex As Exception
                                                        LogMe("ERRORE TRANSAZIONE ONLINE, SORGENTE: ORDINE ONLINE " & singCons.IdConsegna & " ULTIMO LAVORO TRATTATO:" & UltimoIdLavoroTrattato & ", " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
                                                        tbOnline.TransactionRollBack()
                                                        Throw ex
                                                    End Try

                                                End Using

                                                tb.TransactionCommit()

                                                'qui carico online tutte le anteprime come prima cosa 

                                                For Each valore In AnteprimeToUpload
                                                    Try
                                                        Using Ftp As New FTPclient(FtpServer, FtpLogin, FtpPwd)
                                                            Ftp.Upload(valore.Key, valore.Value)
                                                        End Using
                                                    Catch ex As Exception
                                                        LogMe("ERRORE UPLOAD ANTEPRIMA file " & valore.Key & ", MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace)
                                                    End Try
                                                Next

                                                'qui vado ad esplodere i sorgenti di ogni ordine multipagina





                                                '*******************
                                                'CHECK INDIRIZZO GLS 
                                                '*******************
                                                Try
                                                    'CHECK INDIRIZZO DI CONSEGNA TRAMITE GLS

                                                    If ConsBloccata.IndirizzoRif.Indirizzo.ToUpper <> FormerConst.FermoDeposito Then
                                                        Dim OkIndirizzo As RisValidazioneIndirizzo = FormerWebLabeling.MgrWebLabelingGls.CheckAddress(ConsBloccata.IndirizzoRif.Provincia,
                                                                                                                           ConsBloccata.IndirizzoRif.Cap,
                                                                                                                           ConsBloccata.IndirizzoRif.Citta,
                                                                                                                           ConsBloccata.IndirizzoRif.Indirizzo,
                                                                                                                           ConsBloccata.IndirizzoRif.IdNazione)
                                                        If OkIndirizzo.Valido = False Then

                                                            'qui potrebbe esserci un problema con l'indirizzo 
                                                            Dim Buffer As String = "L'indirizzo specificato nella consegna interna " & ConsBloccata.IdCons & " NON HA PASSATO la validazione GLS. Ricontrollare<br><br>"

                                                            Buffer &= "Consegna " & ConsBloccata.IdCons & "<br>Giorno " & ConsBloccata.Giorno.ToString("dd/MM/yyyy") & "<br>Cliente " & ConsBloccata.Cliente.RagSocNome & " (id " & ConsBloccata.Cliente.IdRub & ")<br>Indirizzo " & ConsBloccata.IndirizzoRif.Riassunto(False)
                                                            Buffer &= "<br><br>Informazioni supplementari: (IdComuneInElenco " & ConsBloccata.IndirizzoRif.IdComune & ")" & OkIndirizzo.Messaggio
                                                            Try
                                                                FormerLib.FormerHelper.Mail.InviaMail("Errore in validazione Indirizzo GLS", Buffer, "info@tipografiaformer.it", , , , , FormerConst.EmailAssistenzaTecnica)
                                                            Catch ex As Exception

                                                            End Try

                                                            LogMe("Errore in validazione Indirizzo GLS - Indirizzo ID " & ConsBloccata.IndirizzoRif.IDIndirizzo)

                                                            For Each Ord As F.Ordine In ConsBloccata.ListaOrdini
                                                                Try
                                                                    Using m As New F.Messaggio
                                                                        m.IdOrd = Ord.IdOrd
                                                                        m.IdDest = 0
                                                                        m.DataIns = Now
                                                                        m.IdMitt = 0
                                                                        m.Titolo = "Errore in validazione Indirizzo GLS"
                                                                        m.TipoMsg = enTipoMessaggio.Automatico
                                                                        m.Testo = Buffer
                                                                        m.Save()
                                                                    End Using
                                                                Catch ex As Exception
                                                                    LogMe("Errore Invio Messaggio Interno - testo: " & Buffer,, ex)
                                                                End Try

                                                            Next

                                                        Else
                                                            LogMe("Validazione Indirizzo con GLS OK")
                                                        End If
                                                    End If

                                                Catch ex As Exception
                                                    Dim Buffer As String = "Si è verificato un errore nella gestione dell'indirizzo GLS sulla consegna interna " & ConsBloccata.IdCons & ": " & ex.Message

                                                    FormerLib.FormerHelper.Mail.InviaMail("Errore in validazione Indirizzo GLS", Buffer, FormerConst.EmailAssistenzaTecnica)
                                                End Try

                                            Catch ex As Exception
                                                LogMe("SORGENTE: ORDINE ONLINE " & singCons.IdConsegna & " ULTIMO LAVORO TRATTATO:" & UltimoIdLavoroTrattato & ", " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
                                                tb.TransactionRollBack()

                                                If ex.Message.IndexOf("Errore del server remoto: (425)") <> -1 OrElse
                                                   ex.Message.IndexOf("Errore del server remoto: (550)") <> -1 Then
                                                    LogMe("RICHIESTO RIAVVIO ROUTER CON BATCH")
                                                    FormerLib.FormerHelper.File.ShellExtended(PathTST10)

                                                End If

                                            End Try

                                        End Using
                                    End If
                                End If
                            End If

                        End If

                    End If

                Next

                LogMe("*********************************************", True)
                LogMe("LAVORI Trovati " & LavoriTrovati)
                LogMe("LAVORI Scaricati " & LavoriScaricati)
                LogMe("*********************************************", True)

                ris = LavoriScaricati

            Catch ex As Exception
                LogMe("SORGENTE: ScaricaNuoviOrdiniConPagamento(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

            End Try

            Return ris

        End Function

    End Class

    'Public Class ProceduraGiornaliera
    '    Inherits FormerService

    '    Public Sub New()

    '    End Sub

    '    Public Shared Sub StartService()
    '        Stato = enStatoServizio.Attivo

    '        LogMe("***Procedura Giornaliera***")

    '        Try

    '            If Postazione.Network.ConnessioneInternetDisponibile AndAlso Postazione.Network.ConnessioneDbRemotoDisponibile Then
    '                ProceduraGiornaliera()
    '                'Else
    '                '    Throw New Exception("PROCEDURA GIORNALIERA - Connessione internet non disponibile")
    '            End If

    '        Catch ex As Exception
    '            LogMe("SORGENTE: Procedura Giornaliera(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
    '        End Try

    '        LogMe("***Procedura Giornaliera TERMINATO***")
    '        Stato = enStatoServizio.NonAttivo

    '    End Sub

    '    Private Shared Sub ProceduraGiornaliera()

    '        ''A PRESCINDERE CARICO I DOCUMENTI FISCALI ONLINE
    '        'If Now.Hour >= 7 And Now.Hour <= 22 Then
    '        '    CaricaOnlinePdfFatture(MgrAziende.IdAziende.AziendaSnc)
    '        '    CaricaOnlinePdfFatture(MgrAziende.IdAziende.AziendaSrl)
    '        'End If

    '        'PROCEDURA INTERVALLO ORARIO ESEGUITA UNA SOLA VOLTA AL GIORNO
    '        Dim OraCorrente As Integer = Now.Hour
    '        Select Case OraCorrente



    '        End Select

    '    End Sub

    'End Class

End Class
