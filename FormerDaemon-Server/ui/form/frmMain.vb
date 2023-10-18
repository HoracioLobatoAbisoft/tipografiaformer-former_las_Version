Imports FormerLib
Imports System.ComponentModel
Imports FormerConfig
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerBusinessLogic
Imports FormerLib.MgrAziende

Public Class frmMain

    Private MaxErrCounter As Integer = 20
    Private MediumPingVelocity As Integer = 500
    Private DestErrMail As String = FormerConst.EmailAssistenzaTecnica
    Private AddressServerInterno As String = "former-server"

    Private ProcessiInEsecuzione As Integer = 0

    Private TRestart As Timers.Timer = Nothing

    Private TPingInterno As Timers.Timer = Nothing

    Private TTempPDF As Timers.Timer = Nothing

    Private TPing As Timers.Timer = Nothing
    Private TMem As Timers.Timer = Nothing

    Private TPostazioni As Timers.Timer = Nothing

    Private THCC As Timers.Timer = Nothing
    Private TCheckNewVer As Timers.Timer = Nothing
    Private TIntervalloOrario As Timers.Timer = Nothing

    Private TSyncronizer As Timers.Timer = Nothing
    Private TNewOrd As Timers.Timer = Nothing
    'Private TProcGiorn As Timers.Timer = Nothing

    Private TMessenger As Timers.Timer = Nothing

    Private _RichiestoRiavvio As Boolean = False

    Private Sub TickPingInterno(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        'STOPPO IL TIMER 
        t.Stop()

        Dim Messaggio As String = "Ping"

        If Not TNewOrd Is Nothing AndAlso TNewOrd.Enabled = False Then 'Syncronizer.NewOrder.Stato = FormerService.enStatoServizio.Attivo Then
            Messaggio = "NewOrder"
        End If

        FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Ping, Messaggio)

        t.Start()

    End Sub

    Private Sub TickTempPDF(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        'STOPPO IL TIMER 
        t.Stop()

        FormerService.IntervalloOrario.LavoraPdfFattureGiaCreate()

        t.Start()

    End Sub

    Private Sub CompleteCheckNetwork()
        Try
            CheckServerInterno()
        Catch ex As Exception

        End Try

        Try
            'statusBar.Refresh()
            CheckInternetConnection()
        Catch ex As Exception

        End Try

        Try
            'statusBar.Refresh()
            CheckWebSite()

        Catch ex As Exception

        End Try

        Try
            'statusBar.Refresh()
            CheckServerVirtuale()
            'statusBar.Refresh()
            'Application.DoEvents()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AggiornaThread()
        Dim ProcExec As Integer = ProcessiInEsecuzione
        lblProc.Text = "THREAD: " & ProcExec
        If ProcExec Then
            lblProc.BackColor = Color.Red
        Else
            lblProc.BackColor = Color.Green
        End If

        'Application.DoEvents()

    End Sub

    Private Sub ProcessoInEsecuzione(ByRef lbl As Label)

        If lbl.ForeColor = Color.Green Then
            lbl.ForeColor = Color.Orange
            lbl.BackColor = Color.Black
        Else
            lbl.ForeColor = Color.Green
            lbl.BackColor = Color.White
        End If

    End Sub

    Private Sub TickMemoryUsage(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)

        t.Stop()

        Dim c As Process = Process.GetCurrentProcess
        Text = "Former Daemon - Server " & Application.ProductVersion & " (mem " & Math.Round(c.PagedMemorySize64 / 1024) & "kb)"

        t.Start()

    End Sub

    Private Sub TickIntervalloOrario(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        'STOPPO IL TIMER 
        Dim NextRound As Date = Now.AddMilliseconds(t.Interval)
        t.Stop()
        ProcessoInEsecuzione(lblStatoServOrario)
        ProcessiInEsecuzione += 1
        lblStatoServOrario.Text = lblStatoServOrario.Tag & " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")
        FormerService.IntervalloOrario.StartService()
        ProcessiInEsecuzione -= 1
        ProcessoInEsecuzione(lblStatoServOrario)
        lblStatoMessenger.ForeColor = Color.Green
        t.Start()

    End Sub

    'Private Sub TickProcGiorn(ByVal sender As Object, ByVal myEventArgs As EventArgs)
    '    Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
    '    'STOPPO IL TIMER 
    '    Dim NextRound As Date = Now.AddMilliseconds(t.Interval)
    '    t.Stop()
    '    ProcessoInEsecuzione(lblStatoServProcGiorn)
    '    ProcessiInEsecuzione += 1
    '    lblStatoServProcGiorn.Text = lblStatoServProcGiorn.Tag & " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")
    '    Syncronizer.ProceduraGiornaliera.StartService()
    '    ProcessiInEsecuzione -= 1
    '    ProcessoInEsecuzione(lblStatoServProcGiorn)
    '    t.Start()
    'End Sub

    Private Sub TickNewOrd(ByVal sender As Object, ByVal myEventArgs As EventArgs)
        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        'STOPPO IL TIMER 
        Dim NextRound As Date = Now.AddMilliseconds(t.Interval)
        lblStatoServNewOrd.Text = lblStatoServNewOrd.Tag & " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")
        t.Stop()
        If FormerSyncronizer.NewOrder.ScaricamentoInCorso = False Then
            ProcessoInEsecuzione(lblStatoServNewOrd)
            ProcessiInEsecuzione += 1
            FormerSyncronizer.NewOrder.StartService()
            ProcessiInEsecuzione -= 1
            ProcessoInEsecuzione(lblStatoServNewOrd)
        End If

        t.Start()
    End Sub

    Private Sub TickRestart(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        t.Stop()

        If Now.Hour = 6 Then
            'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "Riavvio demone RICHIESTO!")
            FormerService.LogMe("Riavvio demone RICHIESTO!")
            Shutdown(False)
            t.Dispose()
            t = Nothing
            _RichiestoRiavvio = True
            'aspetta altri 20 secondi
            Threading.Thread.Sleep(20000)
            Application.Restart()
        Else
            t.Start()
        End If

    End Sub

    Private Sub TickSyncronizer(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        'STOPPO IL TIMER 
        Dim NextRound As Date = Now.AddMilliseconds(t.Interval)
        t.Stop()
        ProcessoInEsecuzione(lblStatoServSyncronizer)
        ProcessiInEsecuzione += 1
        lblStatoServSyncronizer.Text = lblStatoServSyncronizer.Tag & " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")
        FormerSyncronizer.Syncronizer.StartService()
        ProcessiInEsecuzione -= 1
        ProcessoInEsecuzione(lblStatoServSyncronizer)
        t.Start()

    End Sub

    Private Sub TickCheckNewVer(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        'STOPPO IL TIMER 
        Dim NextRound As Date = Now.AddMilliseconds(t.Interval)
        t.Stop()
        ProcessoInEsecuzione(lblStatoServCheckNewVer)
        ProcessiInEsecuzione += 1
        lblStatoServCheckNewVer.Text = lblStatoServCheckNewVer.Tag & " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")
        FormerService.NewVersionChecker.StartService()
        ProcessiInEsecuzione -= 1
        ProcessoInEsecuzione(lblStatoServCheckNewVer)
        t.Start()

    End Sub

    Private Sub TickPing(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        'STOPPO IL TIMER 
        t.Stop()

        AggiornaThread()

        CompleteCheckNetwork()

        t.Start()

    End Sub
    Dim MaxVolteErroreRete As Integer = 60
    Dim NumeroVolteErroreRete As Integer = 0
    Private Sub CheckInternetConnection()
        Dim ris As Integer = Postazione.Network.ConnessioneInternetDisponibile
        If ris Then
            If ris > MediumPingVelocity Then
                lblInternet.BackColor = Color.DarkOrange
            Else
                lblInternet.BackColor = Color.Green
            End If
            lblInternet.Text = "CONNESSIONE INTERNET: OK (" & ris & "ms)"
            NumeroVolteErroreRete = 0
        Else
            NumeroVolteErroreRete += 1
            lblInternet.BackColor = Color.Red
            lblInternet.Text = "CONNESSIONE INTERNET: KO"

            If NumeroVolteErroreRete >= MaxVolteErroreRete Then

                Postazione.Network.NetRenew()
                NumeroVolteErroreRete = 0

            End If

        End If
    End Sub

    Private CounterErrServerInterno As Integer = 0
    Private ErrServerInternoSended As Boolean = False

    Private Function CheckDB() As Integer
        Dim ris As Integer = 0



        Return ris
    End Function

    Private Function CheckServerInterno() As Integer
        Dim ris As Integer = Postazione.Network.IsPingable(AddressServerInterno)
        If ris Then
            Postazione.Network.ConnessioneServerInternoDisponibile = True
            If ris > MediumPingVelocity Then
                lblServerInterno.BackColor = Color.DarkOrange
            Else
                lblServerInterno.BackColor = Color.Green
            End If
            lblServerInterno.Text = "SERVER INTERNO: OK (" & ris & "ms)"
            CounterErrServerInterno = 0
            If ErrServerInternoSended Then
                ErrServerInternoSended = False
                FormerLib.FormerHelper.Mail.InviaMail("SERVER INTERNO OK", "Il SERVER INTERNO è di nuovo raggiungibile", DestErrMail)
            End If
        Else
            Postazione.Network.ConnessioneServerInternoDisponibile = False
            lblServerInterno.BackColor = Color.Red
            lblServerInterno.Text = "SERVER INTERNO: KO"
            If Postazione.Network.ConnessioneInternetDisponibile Then
                CounterErrServerInterno += 1
                If CounterErrServerInterno > MaxErrCounter And ErrServerInternoSended = False Then
                    'qui mando una mail perche e' un errore grave 
                    ErrServerInternoSended = True
                    FormerLib.FormerHelper.Mail.InviaMail("ERRORE SERVER INTERNO IRRAGGIUNGIBILE", "Attenzione il SERVER INTERNO non è raggiungibile", DestErrMail)
                End If
            End If
        End If
        Return ris
    End Function

    Private CounterErrWebSite As Integer = 0
    Private ErrWebSiteSended As Boolean = False

    Private Sub CheckWebSite()
        Dim ris As Integer = Postazione.Network.IsPingable("www.tipografiaformer.it", 1500)
        If ris Then
            If ris > MediumPingVelocity Then
                lblSitoWeb.BackColor = Color.DarkOrange
            Else
                lblSitoWeb.BackColor = Color.Green
            End If
            lblSitoWeb.Text = "SITO INTERNET: OK (" & ris & "ms)"
            CounterErrWebSite = 0
            If ErrWebSiteSended Then
                ErrWebSiteSended = False
                FormerLib.FormerHelper.Mail.InviaMail("SITO INTERNET OK", "Il SITO INTERNET è di nuovo raggiungibile", DestErrMail)
            End If
        Else
            lblSitoWeb.BackColor = Color.Red
            lblSitoWeb.Text = "SITO INTERNET: KO"
            If Postazione.Network.ConnessioneInternetDisponibile Then
                CounterErrWebSite += 1
                If CounterErrWebSite > MaxErrCounter And ErrWebSiteSended = False Then
                    'qui mando una mail perche e' un errore grave 
                    ErrWebSiteSended = True
                    FormerLib.FormerHelper.Mail.InviaMail("ERRORE SITO INTERNET IRRAGGIUNGIBILE", "Attenzione il SITO INTERNET non è raggiungibile", DestErrMail)
                End If
            End If
        End If

    End Sub

    Private CounterErrServerVirtuale As Integer = 0
    Private ErrServerVirtualeSended As Boolean = False

    Private Sub CheckServerVirtuale()
        Dim ris As Integer = Postazione.Network.ConnessioneDbRemotoDisponibile
        If ris Then
            If ris > MediumPingVelocity Then
                lblServerVirtuale.BackColor = Color.DarkOrange
            Else
                lblServerVirtuale.BackColor = Color.Green
            End If
            lblServerVirtuale.Text = "SERVER ARUBA: OK (" & ris & "ms)"
            CounterErrServerVirtuale = 0
            If ErrServerVirtualeSended Then
                ErrServerVirtualeSended = False
                FormerLib.FormerHelper.Mail.InviaMail("SERVER ARUBA OK", "Il SERVER ARUBA è di nuovo raggiungibile", DestErrMail)
            End If
        Else
            lblServerVirtuale.BackColor = Color.Red
            lblServerVirtuale.Text = "SERVER ARUBA: KO"
            If Postazione.Network.ConnessioneInternetDisponibile Then
                CounterErrServerVirtuale += 1
                If CounterErrServerVirtuale > MaxErrCounter And ErrServerVirtualeSended = False Then
                    'qui mando una mail perche e' un errore grave 
                    ErrServerVirtualeSended = True
                    FormerLib.FormerHelper.Mail.InviaMail("ERRORE SERVER ARUBA IRRAGGIUNGIBILE", "Attenzione il SERVER ARUBA non è raggiungibile", DestErrMail)
                End If
            End If
        End If

    End Sub

    Private ReadOnly Property DebugAttivo As Boolean
        Get
            Dim ris As Boolean = False

            If Environment.MachineName = "THECELL" OrElse Environment.MachineName = "LUNADIXLAB" Then
                ris = True
            End If

            Return ris
        End Get
    End Property

    Private Sub AddLogUI(L As DaemonLog)

        Dim Lista As List(Of DaemonLog) = DirectCast(DgLog.DataSource, List(Of DaemonLog))
        Lista.Insert(0, L)
        DgLog.AutoGenerateColumns = False
        DgLog.DataSource = Lista

    End Sub

    Private Sub BootStrap()

        If DebugAttivo Then
            'Using o As New Ordine
            '    o.Read(109754)
            '    FormerSyncronizer.NewOrder.CreaCommessaAutomatica(o)
            'End Using

            'FormerSyncronizer.NewOrder.RiCreaCommesseMancanti()
            '***********************************************
            '***********************************************
            '***********************************************
            'COMUNQUE VADA IL DEMONE NON PARTE MAI
            '***********************************************
            '***********************************************
            '***********************************************

            FormerService.IntervalloOrario.EsportaCSV()

            If MessageBox.Show("Vuoi avviare il demone?", "Avvio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Environment.Exit(0)
            End If

            '***********************************************
            '***********************************************
            '***********************************************

            'FormerMessenger.MonitoraggioPECEx(IdAziende.AziendaSrl)


        End If

        WindowState = FormWindowState.Maximized

        Cursor = Cursors.WaitCursor

        FormerUDP.Initialize(txtPrinter, lblLastOpPrinter, "UdpCommand", "UDP")
        FormerService.Initialize(txtService, lblLastOpService, "Service", "SRV")
        FormerSyncronizer.Initialize(txtSyncronizer, lblLastOpSyncronizer, "Syncronizer", "SYN")
        FormerMessenger.Initialize(txtMessenger, lblLastOpMessenger, "Messenger", "MSG")
        FormerCaller.Initialize(txtCaller, lblLastOpCaller, "Caller", "CLR")

        MGRPostazioni.lblLastCheckPostazioni = lblLastCheckPostazioni
        MGRPostazioni.lblLastVer = lblLastVer
        MGRPostazioni.tvw = tvwPostazioni

        lblStatoServTxtToHCC.Text = "TXT TO HCC (" & FormerService.IntervalTxtToHCCMinuti & " min.)"
        lblStatoServTxtToHCC.Tag = lblStatoServTxtToHCC.Text
        Dim NextRound As Date = Now.AddMilliseconds(FormerService.IntervalTxtToHCC)
        lblStatoServTxtToHCC.Text &= " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")

        lblStatoServCheckNewVer.Text = "NEW VERSION CHECKER (" & FormerService.IntervalNewVerMinuti & " min.)"
        lblStatoServCheckNewVer.Tag = lblStatoServCheckNewVer.Text
        NextRound = Now.AddMilliseconds(FormerService.IntervalNewVer)
        lblStatoServCheckNewVer.Text &= " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")

        lblStatoServOrario.Text = "PROC. INTERNE (" & FormerService.IntervalOrarioMinuti & " min.)"
        lblStatoServOrario.Tag = lblStatoServOrario.Text
        NextRound = Now.AddMilliseconds(FormerService.IntervalOrario)
        lblStatoServOrario.Text &= " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")

        lblStatoServSyncronizer.Text = "SYNCRONIZER (" & FormerSyncronizer.IntervalSyncroMin & " min.)"
        lblStatoServSyncronizer.Tag = lblStatoServSyncronizer.Text
        NextRound = Now.AddMilliseconds(FormerSyncronizer.IntervalSyncro)
        lblStatoServSyncronizer.Text &= " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")

        lblStatoServNewOrd.Text = "NUOVI ORDINI (" & FormerSyncronizer.IntervalNewOrdMin & " min.)"
        lblStatoServNewOrd.Tag = lblStatoServNewOrd.Text
        NextRound = Now.AddMilliseconds(FormerSyncronizer.IntervalNewOrd)
        lblStatoServNewOrd.Text &= " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")

        'lblStatoServProcGiorn.Text = "PROC. GIORNALIERA (" & Syncronizer.IntervalProcGiornMin & " min.)"
        'lblStatoServProcGiorn.Tag = lblStatoServProcGiorn.Text
        'NextRound = Now.AddMilliseconds(Syncronizer.IntervalProcGiorn)
        'lblStatoServProcGiorn.Text &= " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")

        If DebugAttivo = False Then
            Dim CheckGlobale As Integer = 0

            Using frm As New frmCheck
                CheckGlobale = frm.Carica()
            End Using

            'If CheckGlobale = 0 Then

            TPing = New Timers.Timer
            TPing.Interval = 500
            AddHandler TPing.Elapsed, AddressOf TickPing
            TPing.Start()

            TMem = New Timers.Timer
            TMem.Interval = 500
            AddHandler TMem.Elapsed, AddressOf TickMemoryUsage
            TMem.Start()

            TPingInterno = New Timers.Timer
            TPingInterno.Interval = 5000
            AddHandler TPingInterno.Elapsed, AddressOf TickPingInterno
            TPingInterno.Start()

            TTempPDF = New Timers.Timer
            TTempPDF.Interval = 60000
            AddHandler TTempPDF.Elapsed, AddressOf TickTempPDF
            TTempPDF.Start()

            AutoStartService()
        End If

        'CaricaService()

        CompleteCheckNetwork()

        CaricaPostazioniAttive()

        'Else
        'Close()
        'End If
        RefreshLog()

        CaricaStampantiDisponibili()

        Try
            'per sicurezzxa sblocco tutti gli ordini locked
            MgrOrderLock.UnlockAll(FormerConst.UtentiSpecifici.IdUtenteAdmin, enFunctionLock.OrdineAperto)
        Catch ex As Exception
            'MessageBox.Show("Si è verificato un errore nell'unlock degli ordini bloccati. Contattare assistenza")
        End Try

        Cursor = Cursors.Default
    End Sub

    Private frmWait As frmWait = Nothing

    Private Sub LanciaWait()

        frmWait = New frmWait
        frmWait.TopLevel = True
        frmWait.Show(Me)

    End Sub

    Private Sub CloseWait()
        Try
            frmWait.Close()


        Catch ex As Exception

        End Try
        Try
            frmWait.Dispose()
        Catch ex As Exception

        End Try
        Try
            frmWait = Nothing
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Shutdown(Optional AskForceClose As Boolean = True)

        Try
            Me.Enabled = False

            Cursor = Cursors.WaitCursor

            If FormerUDP.Stato = BaseService.enStatoServizio.Attivo Then
                FormerUDP.StopService()
            End If

            If FormerCaller.Stato = BaseService.enStatoServizio.Attivo Then
                FormerCaller.StopService()
            End If

            'qui devo controllare i processi in esecuzione
            If ProcessiInEsecuzione Then

                'qui devo aspettare un tot di secondi ragionevole e abilitare la possibilita di annullare l'operazione di chiusura 

                Dim OraInizioSD As Date = Now

                LanciaWait()

                Dim Uscito As Boolean = False

                For i As Integer = 1 To 60
                    Application.DoEvents()
                    If ProcessiInEsecuzione = 0 Then
                        Uscito = True
                        Exit For
                    Else
                        Threading.Thread.Sleep(1000)
                    End If
                Next

                CloseWait()
                If Uscito = False Then
                    If AskForceClose Then MessageBox.Show("I processi in esecuzione sono ancora attivi. Il Demone verrà comunque terminato")
                End If

            End If

            'disattivo i timer
            Try
                TPingInterno.Stop()
                TPingInterno.Dispose()
                TPingInterno = Nothing
            Catch ex As Exception

            End Try


            'disattivo i timer
            Try
                TPing.Stop()
                TPing.Dispose()
                TPing = Nothing
            Catch ex As Exception

            End Try

            'disattivo i timer
            Try
                TMem.Stop()
                TMem.Dispose()
                TMem = Nothing
            Catch ex As Exception

            End Try

            Try

                TMessenger.Stop()
                TMessenger.Dispose()
                TMessenger = Nothing
            Catch ex As Exception

            End Try

            Try

                THCC.Stop()
                THCC.Dispose()
                THCC = Nothing

            Catch ex As Exception

            End Try

            Try

                TCheckNewVer.Stop()
                TCheckNewVer.Dispose()
                TCheckNewVer = Nothing

            Catch ex As Exception

            End Try

            Try

                TIntervalloOrario.Stop()
                TIntervalloOrario.Dispose()
                TIntervalloOrario = Nothing

            Catch ex As Exception

            End Try

            Try

                TNewOrd.Stop()
                TNewOrd.Dispose()
                TNewOrd = Nothing

            Catch ex As Exception

            End Try

            Try

                TSyncronizer.Stop()
                TSyncronizer.Dispose()
                TSyncronizer = Nothing

            Catch ex As Exception

            End Try

            'Try

            '    TProcGiorn.Stop()
            '    TProcGiorn.Dispose()
            '    TProcGiorn = Nothing

            'Catch ex As Exception

            'End Try

            If AskForceClose = False Then
                'qui devo spegnere anche il timer di restart
                Try
                    TRestart.Stop()
                    TRestart.Dispose()
                    TRestart = Nothing
                Catch ex As Exception

                End Try
            End If

            'aspetta altri 5 secondi
            Threading.Thread.Sleep(5000)

            Cursor = Cursors.Default
        Catch ex As Exception

        End Try


    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Try
            If _RichiestoRiavvio = False Then Shutdown()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        BootStrap()

    End Sub

    Private Sub AutoStartService()
        If Postazione.Configurazione.AutoStartSyncronizer Then
            chkAutoStartSyncronizer.Checked = True
            'lancio il servizio 
            StartSyncronizer()
        End If
        If Postazione.Configurazione.AutoStartService Then
            chkAutoStartService.Checked = True
            'lancio il servizio 
            StartService()
        End If
        If Postazione.Configurazione.AutoStartMessenger Then
            chkAutoStartMessenger.Checked = True
            'lancio il servizio 
            StartMessenger()
        End If
        If Postazione.Configurazione.AutoStartCaller Then
            chkAutoStartCaller.Checked = True
            'lancio il servizio 
            StartCaller()
        End If
        If Postazione.Configurazione.AutoStartPrinter Then
            chkAutoStartPrinter.Checked = True
            'lancio il servizio 
            StartPrinter()
        End If

        StartRestart()

    End Sub

    Public Sub StartMessenger(Optional StartTmr As Boolean = True)
        Try
            'qui eseguo il sincronizzatore 
            btnStartMessenger.Enabled = False
            btnStopMessenger.Enabled = True
            btnEsegui1Messenger.Enabled = False

            lblStatoMessenger.ForeColor = Color.Green

            If StartTmr Then

                If FormerMessenger.IntervalMail Then
                    'FormerLog.LogMe(txtMessenger, lblLastOpMessenger, Messenger.ModuleName, Messenger.ModuleSigla, "Servizio AVVIATO!")
                    FormerMessenger.LogMe("Servizio AVVIATO!")
                    'imposto il timer e lo attivo 
                    TMessenger = New Timers.Timer
                    TMessenger.Interval = FormerMessenger.IntervalMail
                    AddHandler TMessenger.Elapsed, AddressOf TickMessenger
                    TMessenger.Start()

                    lblStatoMessenger.Text = "Servizio AVVIATO E ATTIVO"
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Errore " & ex.Message)
        End Try

    End Sub

    Public Sub RunTxtToHcc()

        FormerService.TxtToHCC.StartService()

    End Sub

    Public Sub StartCheckNewVer()
        If FormerService.IntervalNewVer Then
            'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "Servizio CHECK NEW VERSION AVVIATO!")
            FormerService.LogMe("Servizio CHECK NEW VERSION AVVIATO!")
            'imposto il timer e lo attivo 

            TCheckNewVer = New Timers.Timer
            TCheckNewVer.Interval = FormerService.IntervalNewVer
            AddHandler TCheckNewVer.Elapsed, AddressOf TickCheckNewVer
            TCheckNewVer.Start()

            lblStatoServCheckNewVer.ForeColor = Color.Green
        End If
    End Sub

    Public Sub StartIntervalloOrario()

        If FormerService.IntervalOrario Then
            'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "Servizio INTERVALLO ORARIO AVVIATO!")
            'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "- Ora Download Log: " & Service.HDownloadLog)
            'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "- Ora Marketing: " & Service.HMarketingBilanciato)
            'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "- Ora Spostamento Consegne: " & Service.HSpostamentoConsegne)
            'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "- Ora Backup: " & Service.HBackup)
            FormerService.LogMe("Servizio INTERVALLO ORARIO AVVIATO!")
            'imposto il timer e lo attivo 
            TIntervalloOrario = New Timers.Timer
            TIntervalloOrario.Interval = FormerService.IntervalOrario
            AddHandler TIntervalloOrario.Elapsed, AddressOf TickIntervalloOrario
            TIntervalloOrario.Start()

            lblStatoServOrario.ForeColor = Color.Green
        End If

    End Sub

    Public Sub StartTxtToHcc()

        If FormerService.IntervalTxtToHCC Then
            btnEseguiTxtToHCC.Enabled = False

            'TXT TO HCC 

            'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "Servizio CONVERSIONE TXT TO HCC AVVIATO!")
            FormerService.LogMe("Servizio CONVERSIONE TXT TO HCC AVVIATO!")


            THCC = New Timers.Timer
            THCC.Interval = FormerService.IntervalTxtToHCC
            AddHandler THCC.Elapsed, AddressOf TickTxtToHcc
            THCC.Start()

            ''imposto il timer e lo attivo 
            'tmrTxtToHcc.Interval = Service.IntervalTxtToHCC
            'tmrTxtToHcc.Enabled = True

            lblStatoServTxtToHCC.ForeColor = Color.Green
        End If

    End Sub

    Private Sub TickMessenger(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        'STOPPO IL TIMER 

        t.Stop()
        ProcessoInEsecuzione(lblStatoMessenger)
        ProcessiInEsecuzione += 1
        FormerMessenger.StartService()
        ProcessiInEsecuzione -= 1
        ProcessoInEsecuzione(lblStatoMessenger)
        t.Start()

    End Sub

    Private Sub TickTxtToHcc(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        'STOPPO IL TIMER 
        t.Stop()

        Dim NextRound As Date = Now.AddMilliseconds(t.Interval)
        ProcessoInEsecuzione(lblStatoServTxtToHCC)
        ProcessiInEsecuzione += 1
        lblStatoServTxtToHCC.Text = lblStatoServTxtToHCC.Tag & " " & NextRound.Hour.ToString("00") & ":" & NextRound.Minute.ToString("00") & "." & NextRound.Second.ToString("00")
        FormerService.TxtToHCC.StartService()
        ProcessiInEsecuzione -= 1
        ProcessoInEsecuzione(lblStatoServTxtToHCC)
        t.Start()

    End Sub

    Public Sub StopCheckNewVer()

        TCheckNewVer.Stop()
        TCheckNewVer = Nothing

        lblStatoServCheckNewVer.ForeColor = Color.Red
        FormerService.LogMe("Servizio CHECK NEW VERSION ARRESTATO!")
        'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "Servizio CHECK NEW VERSION ARRESTATO!")

    End Sub

    Public Sub StopIntervalloOrario()

        TIntervalloOrario.Stop()
        TIntervalloOrario = Nothing

        lblStatoServOrario.ForeColor = Color.Red
        'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "Servizio INTERVALLO ORARIO ARRESTATO!")
        FormerService.LogMe("Servizio INTERVALLO ORARIO ARRESTATO!")

    End Sub

    Public Sub StopTxtToHcc()

        btnEseguiTxtToHCC.Enabled = True
        THCC.Stop()
        THCC = Nothing
        lblStatoServTxtToHCC.ForeColor = Color.Red
        'FormerLog.LogMe(txtService, lblLastOpService, Service.ModuleName, Service.ModuleSigla, "Servizio CONVERSIONE TXT TO HCC ARRESTATO!")
        FormerService.LogMe("Servizio CONVERSIONE TXT TO HCC ARRESTATO!")

    End Sub

    Public Sub StopSyncroService()

        TSyncronizer.Stop()
        TSyncronizer = Nothing

        lblStatoServSyncronizer.ForeColor = Color.Red
        'FormerLog.LogMe(txtSyncronizer, lblLastOpSyncronizer, Syncronizer.ModuleName, Syncronizer.ModuleSigla, "Servizio SYNCRONIZER ARRESTATO!")
        FormerSyncronizer.LogMe("Servizio SYNCRONIZER ARRESTATO!")

    End Sub

    Public Sub StopNewOrd()

        TNewOrd.Stop()
        TNewOrd = Nothing

        lblStatoServNewOrd.ForeColor = Color.Red
        'FormerLog.LogMe(txtSyncronizer, lblLastOpSyncronizer, Syncronizer.ModuleName, Syncronizer.ModuleSigla, "Servizio NUOVI ORDINI ARRESTATO!")
        FormerSyncronizer.LogMe("Servizio NUOVI ORDINI ARRESTATO!")
    End Sub

    'Public Sub StopProcGiorn()

    '    TProcGiorn.Stop()
    '    TProcGiorn = Nothing

    '    lblStatoServProcGiorn.ForeColor = Color.Red
    '    FormerLog.LogMe(txtSyncronizer, lblLastOpSyncronizer, Syncronizer.ModuleName, Syncronizer.ModuleSigla, "Servizio PROCEDURA GIORNALIERA ARRESTATO!")

    'End Sub

    Public Sub StartRestart()

        TRestart = New Timers.Timer
        TRestart.Interval = 3540000
        AddHandler TRestart.Elapsed, AddressOf TickRestart
        TRestart.Start()
    End Sub

    Public Sub StartSyncronizer()
        Try
            'qui eseguo il sincronizzatore 
            btnStartSyncronizer.Enabled = False
            btnStopSyncronizer.Enabled = True
            btnEsegui1Syncronizer.Enabled = False

            StartSyncroService()
            StartNewOrder()
            'StartProcGiornaliera()

        Catch ex As Exception
            MessageBox.Show("Errore " & ex.Message)
        End Try
    End Sub

    Public Sub StartSyncroService()

        If FormerSyncronizer.IntervalSyncro Then
            'FormerLog.LogMe(txtSyncronizer, lblLastOpSyncronizer, Syncronizer.ModuleName, Syncronizer.ModuleSigla, "Servizio SYNCRONIZER AVVIATO!")
            FormerSyncronizer.LogMe("Servizio SYNCRONIZER AVVIATO!")
            'imposto il timer e lo attivo 
            TSyncronizer = New Timers.Timer
            TSyncronizer.Interval = FormerSyncronizer.IntervalSyncro
            AddHandler TSyncronizer.Elapsed, AddressOf TickSyncronizer
            TSyncronizer.Start()
            lblStatoServSyncronizer.ForeColor = Color.Green
        End If

    End Sub

    Public Sub StartNewOrder()

        If FormerSyncronizer.IntervalNewOrd Then
            'FormerLog.LogMe(txtSyncronizer, lblLastOpSyncronizer, Syncronizer.ModuleName, Syncronizer.ModuleSigla, "Servizio NUOVI ORDINI AVVIATO!")
            FormerSyncronizer.LogMe("Servizio NUOVI ORDINI AVVIATO!")
            'imposto il timer e lo attivo 
            TNewOrd = New Timers.Timer
            TNewOrd.Interval = FormerSyncronizer.IntervalNewOrd
            AddHandler TNewOrd.Elapsed, AddressOf TickNewOrd
            TNewOrd.Start()

            lblStatoServNewOrd.ForeColor = Color.Green
        End If

    End Sub

    'Public Sub StartProcGiornaliera()
    '    If Syncronizer.IntervalProcGiorn Then
    '        FormerLog.LogMe(txtSyncronizer, lblLastOpSyncronizer, Syncronizer.ModuleName, Syncronizer.ModuleSigla, "Servizio PROCEDURA GIORNALIERA AVVIATO!")
    '        'imposto il timer e lo attivo 
    '        TProcGiorn = New Timers.Timer
    '        TProcGiorn.Interval = Syncronizer.IntervalProcGiorn
    '        AddHandler TProcGiorn.Elapsed, AddressOf TickProcGiorn
    '        TProcGiorn.Start()

    '        lblStatoServProcGiorn.ForeColor = Color.Green
    '    End If

    'End Sub

    Public Sub StartService()

        Try
            btnStartService.Enabled = False
            btnStopService.Enabled = True

            StartTxtToHcc()
            StartCheckNewVer()
            StartIntervalloOrario()

        Catch ex As Exception
            MessageBox.Show("Errore " & ex.Message)
        End Try

    End Sub

    Public Sub StartPrinter()
        Try

            btnStartPrinter.Enabled = False
            btnStopPrinter.Enabled = True

            lblStatoPrinter.ForeColor = Color.Green

            FormerUDP.StartService()

            lblStatoPrinter.Text = "UDPCOMMAND AVVIATO E ATTIVO"

        Catch ex As Exception
            MessageBox.Show("Errore " & ex.Message)
        End Try
    End Sub

    Public Sub StartCaller()
        Try
            'qui eseguo il sincronizzatore 
            btnStartCaller.Enabled = False
            btnStopCaller.Enabled = True

            FormerCaller.StartService()

            lblStatoCaller.ForeColor = Color.Green
            lblStatoCaller.Text = "CALLER AVVIATO E ATTIVO"

        Catch ex As Exception
            MessageBox.Show("Errore " & ex.Message)
        End Try


    End Sub

    Public Sub StopMessenger(Optional StopMsg As Boolean = True)
        Try
            TMessenger.Stop()
            TMessenger = Nothing

            btnStartMessenger.Enabled = True
            btnStopMessenger.Enabled = False
            btnEsegui1Messenger.Enabled = True

            lblStatoMessenger.ForeColor = Color.Red

            If StopMsg Then lblStatoMessenger.Text = "MESSENGER ARRESTATO"
            'FormerLog.LogMe(txtMessenger, lblLastOpMessenger, Messenger.ModuleName, Messenger.ModuleSigla, "Servizio ARRESTATO!")
            FormerSyncronizer.LogMe("Servizio ARRESTATO!")

        Catch ex As Exception
            MessageBox.Show("Errore " & ex.Message)
        End Try

    End Sub

    Public Sub StopService()
        Try
            btnStartService.Enabled = True
            btnStopService.Enabled = False

            StopTxtToHcc()
            StopCheckNewVer()
            StopIntervalloOrario()

        Catch ex As Exception
            MessageBox.Show("Errore " & ex.Message)
        End Try

    End Sub

    Public Sub StopCaller()

        Try
            btnStartCaller.Enabled = True
            btnStopCaller.Enabled = False

            FormerCaller.StopService()

            lblStatoCaller.ForeColor = Color.Red

            lblStatoCaller.Text = "CALLER ARRESTATO"
        Catch ex As Exception
            MessageBox.Show("Errore " & ex.Message)
        End Try


    End Sub

    Public Sub StopSyncronizer()

        Try
            btnStartSyncronizer.Enabled = True
            btnStopSyncronizer.Enabled = False
            btnEsegui1Syncronizer.Enabled = True

            StopNewOrd()
            StopSyncroService()
            'StopProcGiorn()

        Catch ex As Exception
            MessageBox.Show("Errore " & ex.Message)
        End Try

    End Sub

    Public Sub StopPrinter()
        Try
            btnStartPrinter.Enabled = True
            btnStopPrinter.Enabled = False

            FormerUDP.StopService()

            lblStatoPrinter.ForeColor = Color.Red

            lblStatoPrinter.Text = "UDPCOMMAND ARRESTATO"
        Catch ex As Exception
            MessageBox.Show("Errore " & ex.Message)
        End Try
    End Sub

    Private Sub chkSyncronizer_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoStartSyncronizer.CheckedChanged
        If sender.focused Then
            Postazione.Configurazione.AutoStartSyncronizer = chkAutoStartSyncronizer.Checked
        End If
    End Sub

    Private Sub chkAutoStartService_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoStartService.CheckedChanged
        If sender.focused Then
            Postazione.Configurazione.AutoStartService = chkAutoStartService.Checked
        End If
    End Sub

    Private Sub chkAutoStartMessenger_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoStartMessenger.CheckedChanged
        If sender.focused Then
            Postazione.Configurazione.AutoStartMessenger = chkAutoStartMessenger.Checked
        End If
    End Sub

    Private Sub chkAutoStartPrinter_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoStartPrinter.CheckedChanged
        If sender.focused Then
            Postazione.Configurazione.AutoStartPrinter = chkAutoStartPrinter.Checked
        End If
    End Sub

    Private Sub chkAutoStartCaller_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoStartCaller.CheckedChanged
        If sender.focused Then
            Postazione.Configurazione.AutoStartCaller = chkAutoStartCaller.Checked
        End If
    End Sub

    Private Sub btnStartPrinter_Click(sender As Object, e As EventArgs) Handles btnStartPrinter.Click
        If MessageBox.Show("Confermi l'avvio del servizio?", "Avvio Servizio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then StartPrinter()
    End Sub

    Private Sub btnStopPrinter_Click(sender As Object, e As EventArgs) Handles btnStopPrinter.Click
        If MessageBox.Show("Confermi l'interruzione del servizio?", "Interruzione Servizio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then StopPrinter()
    End Sub

    Private Sub btnApriLogSyncronizer_Click(sender As Object, e As EventArgs) Handles btnApriLogSyncronizer.Click
        FormerHelper.File.ShellExtended(FormerLog.PathLog & "\" & FormerSyncronizer.ModuleSigla)
    End Sub

    Private Sub btnApriLogPrinter_Click(sender As Object, e As EventArgs) Handles btnApriLogPrinter.Click
        FormerHelper.File.ShellExtended(FormerLog.PathLog & "\" & FormerUDP.ModuleSigla)
    End Sub

    Private Sub btnApriLogService_Click(sender As Object, e As EventArgs) Handles btnApriLogService.Click
        FormerHelper.File.ShellExtended(FormerLog.PathLog & "\" & FormerService.ModuleSigla)
    End Sub

    Private Sub btnApriLogMessenger_Click(sender As Object, e As EventArgs) Handles btnApriLogMessenger.Click
        FormerHelper.File.ShellExtended(FormerLog.PathLog & "\" & FormerMessenger.ModuleSigla)
    End Sub

    Private Sub btnApriLogCaller_Click(sender As Object, e As EventArgs) Handles btnApriLogCaller.Click
        FormerHelper.File.ShellExtended(FormerLog.PathLog & "\" & FormerCaller.ModuleSigla)
    End Sub

    Private Sub btnStartSyncronizer_Click(sender As Object, e As EventArgs) Handles btnStartSyncronizer.Click
        If MessageBox.Show("Confermi l'avvio del servizio?", "Avvio Servizio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then StartSyncronizer()
    End Sub

    Private Sub btnStartService_Click(sender As Object, e As EventArgs) Handles btnStartService.Click
        If MessageBox.Show("Confermi l'avvio del servizio?", "Avvio Servizio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then StartService()
    End Sub

    Private Sub btnStartMessenger_Click(sender As Object, e As EventArgs) Handles btnStartMessenger.Click
        If MessageBox.Show("Confermi l'avvio del servizio?", "Avvio Servizio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then StartMessenger()
    End Sub

    Private Sub btnStartCaller_Click(sender As Object, e As EventArgs) Handles btnStartCaller.Click
        If MessageBox.Show("Confermi l'avvio del servizio?", "Avvio Servizio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then StartCaller()
    End Sub

    Private Sub btnStopSyncronizer_Click(sender As Object, e As EventArgs) Handles btnStopSyncronizer.Click
        If MessageBox.Show("Confermi l'interruzione del servizio?", "Interruzione Servizio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then StopSyncronizer()
    End Sub

    Private Sub btnStopService_Click(sender As Object, e As EventArgs) Handles btnStopService.Click
        If MessageBox.Show("Confermi l'interruzione del servizio?", "Interruzione Servizio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then StopService()
    End Sub

    Private Sub btnStopMessenger_Click(sender As Object, e As EventArgs) Handles btnStopMessenger.Click
        If MessageBox.Show("Confermi l'interruzione del servizio?", "Interruzione Servizio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then StopMessenger()
    End Sub

    Private Sub btnStopCaller_Click(sender As Object, e As EventArgs) Handles btnStopCaller.Click
        If MessageBox.Show("Confermi l'interruzione del servizio?", "Interruzione Servizio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then StopCaller()
    End Sub

    Private Sub btnEsegui1Messenger_Click(sender As Object, e As EventArgs)

        If MessageBox.Show("Confermi l'esecuzione immediata del servizio per una sola volta?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            StartMessenger(False)

            FormerMessenger.StartService()

            StopMessenger(False)

        End If

    End Sub

    'Private Sub tmrTxtToHcc_Tick(sender As Object, e As EventArgs)

    '    tmrTxtToHcc.Enabled = False
    '    ProcessiInEsecuzione += 1
    '    lblStatoServTxtToHCC.Text = lblStatoServTxtToHCC.Tag & " " & Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & "." & Now.Second.ToString("00")
    '    Service.TxtToHCC.StartService()
    '    ProcessiInEsecuzione -= 1
    '    tmrTxtToHcc.Enabled = True

    'End Sub

    Private Sub btnEseguiTxtToHCC_Click(sender As Object, e As EventArgs)

        If MessageBox.Show("Confermi l'esecuzione immediata del servizio Txt to HCC per una sola volta?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            btnStartService.Enabled = False

            FormerService.TxtToHCC.StartService()

            btnStartService.Enabled = True

        End If

    End Sub

    Private Sub btnEsegui1Syncronizer_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Confermi l'esecuzione immediata del servizio Scaricamento Ordini per una sola volta?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            btnEsegui1Syncronizer.Enabled = False
            ProcessiInEsecuzione += 1
            FormerSyncronizer.NewOrder.StartService()
            ProcessiInEsecuzione -= 1
            btnEsegui1Syncronizer.Enabled = True
        End If
    End Sub

    Private Sub pctServices_Click(sender As Object, e As EventArgs) Handles pctServices.Click

        'If MessageBox.Show("Vuoi effettuare la pulizia della cartella temp?", "CleanAndMove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        '    Service.IntervalloOrario.CleanAndMove()

        'End If

    End Sub

    Private Sub tpMain_Click(sender As Object, e As EventArgs) Handles tpMain.Click

    End Sub

    Private Sub txtSyncronizer_TextChanged(sender As Object, e As EventArgs) Handles txtSyncronizer.TextChanged

    End Sub

    Private Sub btnAggiornaPostaz_Click(sender As Object, e As EventArgs) Handles btnAggiornaPostaz.Click

        CaricaPostazioniAttive()

        FormerService.NewVersionChecker.StartService()

    End Sub

    Public Sub CaricaPostazioniAttive()
        Dim VersioneCorretta As String = String.Empty
        Try
            Dim F As FileVersionInfo = FileVersionInfo.GetVersionInfo(FormerPath.PathCentralizzato & "FormerEsercizio\bin\former\former.exe")
            VersioneCorretta = F.FileVersion
            lblLastVer.Text = "Last. Ver. " & VersioneCorretta

        Catch ex As Exception

        End Try

        Try
            Dim l As List(Of PostazioneDiLavoro) = MGRPostazioni.ListaPostazioni()

            tvwPostazioni.Nodes.Clear()

            For Each p In l

                Dim n As New TreeNode(p.Nome, 7, 7)
                n.Nodes.Add("Ultimo Accesso: " & p.UltimoAccesso)
                n.Nodes.Add("Utente Connesso: " & p.Utente)

                Dim NodoVer As New TreeNode("Versione: " & p.Versione)
                NodoVer.ForeColor = Color.White
                If VersioneCorretta <> p.Versione Then
                    NodoVer.BackColor = Color.Red
                Else
                    NodoVer.BackColor = Color.Green
                End If

                n.Nodes.Add(NodoVer)

                tvwPostazioni.Nodes.Add(n)

            Next

            tvwPostazioni.ExpandAll()

            lblLastCheckPostazioni.Text = "Ultimo controllo Postazioni Attive alle " & Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & "." & Now.Second.ToString("00")

        Catch ex As Exception
            Dim msg As String = ex.Message
        End Try

    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().


    End Sub

    Private Sub tmrPostazioni_Tick(sender As Object, e As EventArgs) Handles tmrPostazioni.Tick

        CaricaPostazioniAttive()

    End Sub

    Private Sub bkgWorker_DoWork(sender As Object, e As DoWorkEventArgs)

    End Sub

    Private Sub btnForzaturaOperazioni_Click(sender As Object, e As EventArgs) Handles btnForzaturaOperazioni.Click

        Using frm As New frmForzaAzione
            frm.Carica()
        End Using

    End Sub

    Private Sub btnPrendiInCaricoChiamata_Click(sender As Object, e As EventArgs) Handles btnPrendiInCaricoChiamata.Click

        Using frm As New frmPostit

            Dim Valori As String = lblLastOpCaller.Tag

            If Valori.Length Then
                Dim IdRub As Integer = 0
                Dim NumeroTrovato As String = String.Empty

                NumeroTrovato = Valori.Split(":")(0)
                IdRub = Valori.Split(":")(1)

                frm.Carica(IdRub, NumeroTrovato)
            Else
                MessageBox.Show("Non ci sono dati disponibili")
            End If

        End Using

    End Sub

    Private Sub btnTestGhostscript_Click(sender As Object, e As EventArgs) Handles btnTestGhostscript.Click

        Try
            Using o As New Ordine
                o.Read(88102)

                For Each s As FileSorgente In o.ListaSorgenti
                    FormerHelper.PDF.GetPdfThumbnail(s.FilePath, "C:\temp\" & FormerHelper.File.EstraiNomeFile(s.FilePath) & ".jpg")
                Next

                MessageBox.Show("Ok")
            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message)

            If Not ex.InnerException Is Nothing Then
                MessageBox.Show(ex.InnerException.Message)
            End If

        End Try



    End Sub

    Private Sub btnMessage_Click(sender As Object, e As EventArgs) Handles btnMessage.Click
        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Messaggio, txtMsg.Text)
            MessageBox.Show("Operazione effettuata")
            txtMsg.Text = String.Empty
        End If
    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Service, "DISCONNECT")
            MessageBox.Show("Operazione effettuata")
        End If
    End Sub

    Private Sub btnReconnect_Click(sender As Object, e As EventArgs) Handles btnReconnect.Click
        If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Service, "CONNECT")
            MessageBox.Show("Operazione effettuata")
        End If
    End Sub

    Private Sub btnEsegui1Syncronizer_Click_1(sender As Object, e As EventArgs)
        If MessageBox.Show("Confermi l'esecuzione immediata del servizio Scaricamento Ordini per una sola volta?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            btnEsegui1Syncronizer.Enabled = False
            ProcessiInEsecuzione += 1
            FormerSyncronizer.NewOrder.StartService()
            ProcessiInEsecuzione -= 1
            btnEsegui1Syncronizer.Enabled = True
        End If
    End Sub

    Private Sub btnEseguiTxtToHCC_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnEsegui1Messenger_Click_1(sender As Object, e As EventArgs) Handles btnEsegui1Messenger.Click
        If MessageBox.Show("Confermi l'esecuzione immediata del servizio per una sola volta?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            StartMessenger(False)

            FormerMessenger.StartService()

            StopMessenger(False)

        End If
    End Sub

    Private Sub btnEseguiTxtToHCC_Click_2(sender As Object, e As EventArgs) Handles btnEseguiTxtToHCC.Click
        If MessageBox.Show("Confermi l'esecuzione immediata del servizio Txt to HCC per una sola volta?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            btnStartService.Enabled = False

            FormerService.TxtToHCC.StartService()

            btnStartService.Enabled = True

        End If
    End Sub

    Private Sub btnEsegui1Syncronizer_Click_2(sender As Object, e As EventArgs) Handles btnEsegui1Syncronizer.Click
        If MessageBox.Show("Confermi l'esecuzione immediata del servizio Scaricamento Ordini per una sola volta?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            btnEsegui1Syncronizer.Enabled = False
            ProcessiInEsecuzione += 1
            FormerSyncronizer.NewOrder.StartService()
            ProcessiInEsecuzione -= 1
            btnEsegui1Syncronizer.Enabled = True
        End If
    End Sub

    Private Sub btnRefreshLog_Click(sender As Object, e As EventArgs)

        RefreshLog()

    End Sub

    Private Sub RefreshLog()
        Cursor.Current = Cursors.WaitCursor
        Using mgr As New DaemonLogDAO

            Dim Lp As LUNA.LunaSearchParameter = Nothing

            If txtCerca.Text.Trim.Length Then
                Lp = New LUNA.LunaSearchParameter(LFM.DaemonLog.Descrizione, "%" & txtCerca.Text.Trim & "%", "LIKE")
            End If

            Dim L As List(Of DaemonLog) = mgr.FindAll(New LUNA.LunaSearchOption With {.Top = 100, .OrderBy = LFM.DaemonLog.Quando.Name & " DESC"},
                                                      Lp)

            DgLog.AutoGenerateColumns = False
            DgLog.DataSource = L
        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub tmrLog_Tick(sender As Object, e As EventArgs) Handles tmrLog.Tick

        RefreshLog()

    End Sub

    Private Sub DgLog_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DgLog_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgLog.CellDoubleClick

        If DgLog.SelectedRows.Count Then
            Dim Riga As DataGridViewRow = DgLog.SelectedRows(0)
            Dim Log As DaemonLog = Riga.DataBoundItem
            Dim Testo As String = Log.QuandoStr & " - " & Log.ServizioStr & ControlChars.NewLine & Log.Descrizione

            MessageBox.Show(Testo)
        End If

    End Sub

    Private Sub DgLog_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgLog.RowPostPaint

        Dim R As DataGridViewRow = DgLog.Rows(e.RowIndex)

        Dim D As DaemonLog = R.DataBoundItem
        If D.Tipo = enDaemonLogType.Exception Then
            R.DefaultCellStyle.BackColor = Color.Red
        Else
            R.DefaultCellStyle.BackColor = Color.White
        End If

    End Sub

    Private Sub btnRefreshLog_Click_1(sender As Object, e As EventArgs) Handles btnRefreshLog.Click
        RefreshLog()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtCerca.Text = String.Empty
    End Sub

    Private Sub txtCerca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCerca.KeyPress

        If e.KeyChar = vbCr Then

            RefreshLog()

        End If

    End Sub

    Private Sub lnkRestartRouter_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRestartRouter.LinkClicked

        Dim PathTST10 As String = AppDomain.CurrentDomain.BaseDirectory & "tst10\reboot.bat"

        If MessageBox.Show("Confermi il riavvio del router? (" & PathTST10 & ")") Then
            FormerLib.FormerHelper.File.ShellExtended(PathTST10)
            MessageBox.Show("Router riavviato")
        End If

    End Sub

    Private Sub btnTestTB_Click(sender As Object, e As EventArgs) Handles btnTestTB.Click

        Using TB As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

            Dim result As String = String.Empty

            Try
                TB.TransactionBegin()

                Using mgr As New UtentiDAO
                    Dim l As List(Of Utente) = mgr.GetAll

                    For Each u As Utente In l
                        result &= u.Login & ControlChars.NewLine

                    Next

                End Using

                TB.TransactionCommit()

            Catch ex As Exception
                TB.TransactionRollBack()
                MessageBox.Show(ex.Message)
            End Try

            MessageBox.Show(result)


        End Using


    End Sub
    Private Sub btnCopia_Click(sender As Object, e As EventArgs) Handles btnCopia.Click
        Try
            Clipboard.SetText(cmbStampanti.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CaricaStampantiDisponibili()

        cmbStampanti.Items.Clear()
        For Each Stamp In FormerHelper.Printer.ElencoInstallate

            'cmbStampanteFatture.Items.Add(Stamp)
            cmbStampanti.Items.Add(Stamp)
            'cmbPrinterLibera.Items.Add(Stamp)
            'cmbPrinterOrdini.Items.Add(Stamp)

        Next

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        CaricaStampantiDisponibili()
    End Sub

    'Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    '    'Dim PathPdf As String = "C:\temp\test.pdf"
    '    'Dim PathAnteprima As String = PathPdf & ".jpg"
    '    'If IO.File.Exists(PathPdf) Then
    '    '    FormerHelper.PDF.GetPdfThumbnail(PathPdf, PathAnteprima)
    '    'End If

    'End Sub

End Class
