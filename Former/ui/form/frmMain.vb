#Region "Author"

'All rights reserved.

'Author: DC Consulting srl
'Date: Giugno 2008

#End Region
Imports FormerLib.FormerEnum
Imports FormerDALSql
Imports System.IO
Imports FormerLib
Imports FormerConfig
Imports FormerBusinessLogic

Public Class frmMain
    'Inherits frmUsbResponsiveForm

    Private WithEvents formCaller As frmCaller
    Private formLocked As frmLocked

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        '' Add any initialization after the InitializeComponent() call.
        'ColoraSfondo(lnkMaxSpace)
        'ColoraSfondo(btnMinimize)
        'ColoraSfondo(btnClose)
        'WindowState = FormWindowState.Maximized

    End Sub

    Public Sub CaricaTelefonate()

        UcMain.CaricaTelefonate()

    End Sub

    Public Sub PrendiInCaricoChiamata(Optional IdCli As Integer = 0,
                                      Optional NumeroTel As String = "")

        Sottofondo()

        Using f As New frmPostit
            f.Carica(,,,, IdCli, NumeroTel)
        End Using

        Sottofondo()

    End Sub

    Public Sub SelezionaClienteDaChiamata(IdCli As Integer)

        UcMain.SelezionaClienteDaChiamata(IdCli)

    End Sub

    Public Sub SelezionaOrdiniDaTipoFustella(IdTipoFustella As Integer)

        UcMain.SelezionaOrdiniDaTipoFustella(IdTipoFustella)

    End Sub

    Public Sub Carica()

        FormPrincipale = Me

        'LANCIO I METODI DI CARICAMENTO DEI VARI COMPONENTI
        PreparaAmbiente()

        KeyPreview = True
        'tmrOra.Enabled = True
        Show()

        AttivaAscolto()

        If PostazioneCorrente.UtenteConnesso.Tipo <> enTipoUtente.Operatore Then
            If File.Exists(PostazioneCorrente.PathReleaseNote) Then
                Sottofondo()
                Using f As New frmReleaseNote
                    f.Carica()
                End Using
                Sottofondo()
            End If
        End If

    End Sub

    Friend Sub CalcolaBonus()

        ''qui invoco il metodo calcolabonus dell'operatore loggato
        'Using mU As New UtentiDAO
        '    UcToolbarMain.BonusMaturato = FormattaPrezzo(mU.CalcolaBonus(Postazione.UtenteConnesso.IdUt))
        'End Using

    End Sub

    Friend Sub AdattaAmbienteByUtente(Optional CaricaToolbarMain As Boolean = True)
        '        FormerDebug.Traccia("CARICAMENTO INIZIALE")
        lblUtConn.Text = PostazioneCorrente.UtenteConnesso.Login

        If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento Toolbar main")
        If CaricaToolbarMain Then UcToolbarMain.Carica()

        If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento Main UC")
        UcMain.Carica()

        If PostazioneCorrente.IsUsbLogin Then
            lblUsbLogin.Visible = True
            lblClassicLogin.Visible = False
        Else
            lblUsbLogin.Visible = False
            lblClassicLogin.Visible = True
        End If

        'If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then
        '    RestringiSpazio()
        '    'UcCallerID.Visible = False
        'Else
        '    ResettaSpazio()
        'End If

        RestringiSpazio()

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then UcPostitMain.MostraDati()
        UcPostitMain.AttivaTimer()
    End Sub

    Private Sub RestringiSpazio()
        lnkMaxSpace.Text = "Restringi spazio"
        lnkMaxSpace.Image = My.Resources.endI
        SplitContainerPrincipale.SplitterDistance = 0
    End Sub

    Private Sub ResettaSpazio()
        lnkMaxSpace.Text = "Ottimizza spazio"
        lnkMaxSpace.Image = My.Resources.begin
        SplitContainerPrincipale.SplitterDistance = 260
    End Sub

    Private Sub AggiornaOrario(ByVal sender As Object, ByVal myEventArgs As EventArgs)
        Try
            lblOra.Text = Now.Hour & ":" & Now.Minute
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PreparaAmbiente()

        If PostazioneCorrente.Versione.StartsWith("99.") Then
            Text = "*** Former BETA *** Gestionale Tipografia " & PostazioneCorrente.Versione
        Else
            Text = "Former - Gestionale Tipografia " & PostazioneCorrente.Versione
        End If

        ' lblProfilo.Text = Postazione.UtenteConnesso.ProfiloLabel

        lblVersione.Text = PostazioneCorrente.Versione
        lblRilascio.Visible = False
        Label2.Visible = False

        lblOra.Text = Now.ToShortTimeString

        'SplitContainerPrincipale.DefaultWidth = 260

        AdattaAmbienteByUtente()

        ' UcNotifiche.MostraDati()

        If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Check Folder")

        If Directory.Exists(FormerPath.PathTempLocale) = False Then
            FormerHelper.File.CreateLongPath(FormerPath.PathTempLocale)
        End If

        Try
            If Directory.Exists(FormerPath.PathTemp) = False Then
                FormerHelper.File.CreateLongPath(FormerPath.PathTemp)
            End If
        Catch ex As Exception
            If FormerDebug.DebugAttivo Then MessageBox.Show("Si e' verificato un errore nella creazione del path " & FormerPath.PathTemp)
        End Try

        Try
            If Directory.Exists(FormerPath.PathStampaTemp) = False Then
                FormerHelper.File.CreateLongPath(FormerPath.PathStampaTemp)
            End If

        Catch ex As Exception
            If FormerDebug.DebugAttivo Then MessageBox.Show("Si e' verificato un errore nella creazione del path " & FormerPath.PathStampaTemp)
        End Try

        Try
            If Directory.Exists(FormerPath.PathFatture(MgrAziende.IdAziende.AziendaSnc)) = False Then
                FormerHelper.File.CreateLongPath(FormerPath.PathFatture(MgrAziende.IdAziende.AziendaSnc))
            End If
            If Directory.Exists(FormerPath.PathFatture(MgrAziende.IdAziende.AziendaSrl)) = False Then
                FormerHelper.File.CreateLongPath(FormerPath.PathFatture(MgrAziende.IdAziende.AziendaSrl))
            End If

        Catch ex As Exception
            If FormerDebug.DebugAttivo Then MessageBox.Show("Si e' verificato un errore nella creazione del path fatture")
        End Try

        Try
            If Directory.Exists(FormerPath.PathTempImg) = False Then
                FormerHelper.File.CreateLongPath(FormerPath.PathTempImg)
            End If

        Catch ex As Exception
            If FormerDebug.DebugAttivo Then MessageBox.Show("Si e' verificato un errore nella creazione del path " & FormerPath.PathTempImg)
        End Try

        'CaricaAnnoRange()

        If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Check LiveUpdate")
        Try
            Dim DirectoryLocale As String = My.Application.Info.DirectoryPath
            Dim PathDistribuzione As String = "z:\FormerEsercizio\bin\former"
            Dim PathExeRemoto As String = PathDistribuzione & "\formerliveupdate.exe"
            Dim PathExeLocale As String = DirectoryLocale & "\formerliveupdate.exe"
            Dim FRemoto As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathExeRemoto)
            Dim FLocale As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathExeLocale)

            If FLocale.FileVersion <> FRemoto.FileVersion Then
                MgrIO.FileCopia(Me, PathExeRemoto, PathExeLocale)
            End If
        Catch ex As Exception

        End Try

        PostazioneCorrente.NascondiAttesa()

        'qui devo capire se devo eliminare la cartella file temporanei 
        'dal listino
        'AttivaAscolto()
        If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Check Server date")
        Dim DataServer As Date = LUNA.LunaContext.GetServerDate

        Dim Differenza As Integer = DateDiff(DateInterval.Hour, DataServer, Now)

        If Differenza Then
            MessageBox.Show("Attenzione la data del Computer non è congruente con quella del server. Reimpostare la data!")
        End If

        TOrario = New Timers.Timer
        TOrario.Interval = 50000
        TOrario.Enabled = True
        AddHandler TOrario.Elapsed, AddressOf AggiornaOrario
        TOrario.Start()

        Try
            'per sicurezzxa sblocco tutti gli ordini locked
            MgrOrderLock.UnlockAll(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.OrdineAperto)
        Catch ex As Exception
            'MessageBox.Show("Si è verificato un errore nell'unlock degli ordini bloccati. Contattare assistenza")
        End Try

    End Sub

    Dim TOrario As Timers.Timer = Nothing

    Public Sub TerminaAscolto()
        Try
            If udp IsNot Nothing Then udp.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Delegate Sub delAddText(ByVal text As String)

    Private safeAddText As New delAddText(AddressOf AddText)

    Private Sub ChiudiFormCaller()
        If Not formCaller Is Nothing Then
            formCaller.Close()
            'formCaller.Dispose()
            formCaller = Nothing
        End If
    End Sub

    Private Sub ChiusuraForzataFormCaller() Handles formCaller.FormClosed
        formCaller = Nothing
    End Sub

    Private Sub AddText(ByVal text As String)
        'qui devo vedere se il destinatario sono io o tutti del messaggio
        Dim M As New MessaggioDiReteInterno(text)

        If M.Valido Then
            If M.Dest = FormerUDP.DestUDP_All Or
               M.Dest.ToLower = PostazioneCorrente.UtenteConnesso.Login.ToLower Or
               (M.Dest = FormerUDP.DestUDP_Admin And (PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Or PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.SuperOperatore)) Or
               (M.Dest = FormerUDP.DestUDP_Operatore And PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore) Then
                Select Case M.TipoMess
                    Case FormerUDP.TipoUDP_CallerID 'CALLERID
                        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Or
                           PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.SuperOperatore Then 'And FormerDebug.DebugAttivo = False Then
                            'PROTOCOLLO PER LA GESTIONE DELLE CHIAMATE
                            If M.Testo = "END" Then
                                ChiudiFormCaller()
                            Else
                                If formCaller Is Nothing Then
                                    'If FormerDebug.DebugAttivo = False Then
                                    ChiudiFormCaller()
                                    formCaller = New frmCaller
                                    Dim c As New cCaller(M.Testo)
                                    formCaller.Carica(c)
                                    c = Nothing
                                    'End If
                                End If

                                'Dim c As New cCaller(M.Testo)

                                'UcCallerID.Carica(c)

                                'c = Nothing
                            End If
                        End If

                    Case FormerUDP.TipoUDP_Versioning 'VERSIONING 
                        'in m.testo ho la versione del programma 
                        Dim VersioneDisp As String = M.Testo
                        Dim Versione As String = My.Application.Info.Version.ToString

                        If VersioneDisp <> Versione Then

                            Dim OkAvvisa As Boolean = False

                            If FormerConfig.FConfiguration.Debug.BetaVersion = False Then
                                If VersioneDisp.StartsWith("99.") = False Then
                                    OkAvvisa = True
                                End If
                            Else
                                'qui e' una versione beta devo capire se aggiornare o no 
                                If VersioneDisp.StartsWith("99.") Then
                                    OkAvvisa = True
                                Else
                                    'qui devo capire se la versione che non e' beta e' piu recente della beta

                                    Dim ValoriVDisp() As String = VersioneDisp.Split(".")
                                    Dim ValoriVAtt() As String = Versione.Split(".")
                                    'salto il primo valore che e' sempre maggiore essendo questa la beta

                                    If CInt(ValoriVDisp(1)) > CInt(ValoriVAtt(1)) Then '2018
                                        OkAvvisa = True
                                    ElseIf CInt(ValoriVDisp(1)) = CInt(ValoriVAtt(1)) Then '11
                                        If CInt(ValoriVDisp(2)) > CInt(ValoriVAtt(2)) Then
                                            OkAvvisa = True
                                        ElseIf CInt(ValoriVDisp(2)) = CInt(ValoriVAtt(2)) Then '2
                                            If CInt(ValoriVDisp(3)) > CInt(ValoriVAtt(3)) Then
                                                OkAvvisa = True
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                            'If VersioneDisp.StartsWith("99.") Then
                            '    'versione beta
                            '    If FormerConfig.FConfiguration.Debug.BetaVersion = False Then
                            '        'qui non devo aggiornare
                            '        OkAvvisa = False
                            '    End If
                            'Else
                            '    'versione normale
                            '    If FormerConfig.FConfiguration.Debug.BetaVersion = True Then
                            '        'qui non devo aggiornare
                            '        OkAvvisa = False
                            '    End If
                            'End If

                            If OkAvvisa Then
                                'UcToolbarMain.AddNotifica("ATTENZIONE! E' disponibile una nuova versione di FORMER (" & VersioneDisp & ")")
                                UcToolbarMain.NewVersion()
                            End If

                        End If

                        'If VersioneDisp <> Versione And PostazioneCorrente.MessageAggiornamentoAperto = False Then
                        '    PostazioneCorrente.MessageAggiornamentoAperto = True
                        '    If FormerDebug.DebugAttivo = False Then
                        '        If MessageBox.Show("ATTENZIONE! E' disponibile una nuova versione di FORMER (" & VersioneDisp & "). Vuoi chiudere il programma e aggiornarlo automaticamente?", "Aggiornamento " & VersioneDisp, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        '            UpdateAppAtShutdown = True
                        '            Application.Exit()
                        '        End If
                        '        PostazioneCorrente.MessageAggiornamentoAperto = False
                        '    End If
                        'End If

                    Case FormerUDP.TipoUDP_Messaggio 'PROTOCOLLO DI MESSAGGISTICA
                        MessageBox.Show(M.Testo)

                    Case FormerUDP.TipoUDP_Service
                        'PROTOCOLLO DI DISCONNESSIONE 
                        If M.Testo = "DISCONNECT" Then
                            formLocked = New frmLocked
                            If formSopra Is Nothing Then Sottofondo()
                            formLocked.Carica()
                            'Postazione.ChiudiConn()

                        ElseIf M.Testo = "CONNECT" Then
                            If Not formLocked Is Nothing Then
                                formLocked.Chiudi()
                                If Not formSopra Is Nothing Then Sottofondo()
                                formLocked = Nothing
                                'Postazione.ApriConn()
                            End If

                        End If

                    Case FormerUDP.TipoUDP_Ping
                        FormerEnvironment.LastDaemonPing = Now
                        PostazioneCorrente.ScaricamentoOrdiniInCorso = False
                        Dim MDemon As String = M.Testo

                        If MDemon = "Ping" Then
                            'qui non faccio niente 
                            'lo scrivo solo per ricordare il ping a vuoto
                        ElseIf MDemon = "NewOrder" Then
                            'il demone sta scaricando ordini 
                            PostazioneCorrente.ScaricamentoOrdiniInCorso = True
                        End If

                    Case FormerUDP.TipoUDP_Notifica
                        UcToolbarMain.AddNotifica(M.Testo)

                        If M.Testo.IndexOf("nuovi ordini") <> -1 Then
                            'qui devo ricaricare il contatore della produzione
                            If PostazioneCorrente.CaricamentiAutomatici Then UcMain.CaricaProduzioneInCoda()
                        ElseIf M.Testo.IndexOf("nuove email") <> -1 Then
                            'qui devo ricaricare il contatode delle mail
                            If PostazioneCorrente.CaricamentiAutomatici Then UcMain.CaricaMailInCoda()
                        End If

                End Select
            End If
        End If
    End Sub

    Private Sub ApriFormLocked()

    End Sub

    Private Sub ChiudiFormLocked()

    End Sub

    Private Sub AttivaAscolto()
        'If Postazione.UtenteConnesso.Tipo = enTipoUtente.Admin Then
        '    If Postazione.AttivaCallerId Then

        Dim t As New Threading.Thread(AddressOf listen)
        t.IsBackground = True
        t.Start()
        '    End If
        'End If
    End Sub

    Private Sub listen()

        Try
            udp = New Net.Sockets.UdpClient(PostazioneCorrente.PortaUDP)
            udp.EnableBroadcast = True
            Dim ep As New Net.IPEndPoint(Net.IPAddress.Broadcast, PostazioneCorrente.PortaUDP)
            Do
                Dim b() As Byte = udp.Receive(ep)
                Me.Invoke(safeAddText, System.Text.Encoding.UTF32.GetString(b))
            Loop
        Catch ex As Exception
            If udp IsNot Nothing Then udp.Close()
            'MessageBox.Show("Impossibile andare in ascolto protocollo FORMER. Errore " & ex.Message)
        End Try

        'If ComPort Is Nothing Then ComPort = New SerialPort
        'Try
        '    With ComPort
        '        .PortName = Postazione.PortaCom
        '        .BaudRate = 4800
        '        .Parity = Parity.None
        '        .DataBits = 8
        '        .StopBits = StopBits.One
        '    End With
        '    ComPort.Open()
        '    ComPort.Write(Postazione.PortaComInit & vbCr)
        'Catch ex As Exception
        '    MsgBox("ERRORE Rilevamento CallerId: " & ex.ToString)
        'End Try

    End Sub

    'Private Sub ComPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles ComPort.DataReceived
    '    '  Dim BufferLetto As String = ComPort.ReadLine

    '    'If ChiamataInArrivo = False Then
    '    '    'CheckForIllegalCrossThreadCalls = False
    '    '    'MessageBox.Show(BufferLetto)
    '    '    'If BufferLetto.Length Then
    '    '    'qui devo vedere se c'e' qualcosa 
    '    '    'se trovo un numero di telefono chiamo la formcallerid

    '    '    Dim Posiz As Integer = BufferLetto.ToUpper.IndexOf("NMBR")
    '    '    If Posiz <> -1 Then
    '    '        'MessageBox.Show(BufferLetto)
    '    '        ChiamataInArrivo = True
    '    '        'ComPort.Close()

    '    '        formCaller = New frmCaller
    '    '        formCaller.Carica(BufferLetto)
    '    '        'MessageBox.Show("USCITO DAL CARICAMENTO FORM")
    '    '        'Sottofondo()
    '    '        'f = Nothing
    '    '        'End If
    '    '    End If
    '    'End If

    'End Sub

    'Private Sub CaricaAnnoRange()

    '    cmbAnnoRange.Items.Add(" - Tutti gli anni")
    '    cmbAnnoRange.Items.Add(" - Ultimi sei mesi")
    '    cmbAnnoRange.Items.Add(" - Ultimo anno")
    '    'qui carico gli anni di ordini e commesse
    '    'Dim dt As DataTable, ComOrd As New cOrdiniCommesse, dr As DataRow
    '    'dt = ComOrd.ListaAnni

    '    'For Each dr In dt.Rows
    '    'cmbAnnoRange.Items.Add(dr("anno").ToString)
    '    'Next

    '    cmbAnnoRange.SelectedIndex = 0

    'End Sub

    'Private Sub tmrOra_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrOra.Tick
    '    lblOra.Text = Now.ToShortTimeString
    'End Sub

    Private Sub btnAggiorna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Postazione.AggiornaProgramma(Me)
    End Sub

    Public Sub ChiudiSessioneLavoro()

        PostazioneCorrente.ChiudiSessioneLavoro()
        'PostazioneCorrente
        ''If Not _cnOld Is Nothing Then

        ''    If _cnOld.State = ConnectionState.Open Then

        ''        _cnOld.Close()

        ''    End If

        ''    _cnOld.Dispose()
        ''    _cnOld = Nothing

        ''End If
        'If LUNA.LunaContext.ShareConnection Then LUNA.LunaContext.CloseDbConnection()
        ''ripulisco le stampe temp
        'TerminaAscolto()
        'Try
        '    Kill(FormerPath.PathStampaTemp & "*.htm")
        'Catch ex As Exception

        'End Try

        'Try
        'FormerLock.UnLock(PostazioneCorrente.UtenteConnesso.IdUt)
        'Catch ex As Exception

        'End Try

        'Try
        '    FormerSecurity.RegistraLogOut(PostazioneCorrente.UtenteConnesso.IdUt)
        'Catch ex As Exception

        'End Try

    End Sub

    'Private Sub frmMain_ChiaveUSBConnessa() Handles Me.ChiaveUSBConnessa

    'End Sub

    'Private Sub frmMain_ChiaveUSBDisconnessa() Handles Me.ChiaveUSBDisconnessa
    '    If PostazioneCorrente.IsUsbLogin Then
    '        Sottofondo()
    '        Dim NuovoLoginEffettuato As Boolean = False
    '        While NuovoLoginEffettuato = False
    '            Dim f As New frmInsertUsb
    '            Dim NuovoUtente As Utente = f.Carica()
    '            'se arrivo qui e' stata reinserita una chiave valida

    '            If NuovoUtente.IdUt <> PostazioneCorrente.UtenteConnesso.IdUt Then

    '                Dim OkLoginEsclusivo As Boolean = True
    '                Dim loggato As RisUserLogged = FormerSecurity.IsUserLogged(NuovoUtente.IdUt)

    '                If loggato.IsLogged Then
    '                    'qui non posso entrare ammenoche non sia gia loggato sulla stessa postazione
    '                    If loggato.Postazione <> System.Environment.MachineName Then
    '                        OkLoginEsclusivo = False
    '                    End If
    '                End If

    '                If OkLoginEsclusivo Then
    '                    'ricarico tutto
    '                    Try
    '                        FormerSecurity.RegistraLogOut(PostazioneCorrente.UtenteConnesso.IdUt)
    '                    Catch ex As Exception

    '                    End Try

    '                    PostazioneCorrente.UtenteConnesso = NuovoUtente

    '                    FormerSecurity.RegistraLogin(NuovoUtente.IdUt)

    '                    LUNA.LunaContext.SetUtenteConnesso(PostazioneCorrente.UtenteConnesso)
    '                    AdattaAmbienteByUtente()
    '                    NuovoLoginEffettuato = True
    '                Else
    '                    MessageBox.Show("Impossibile accedere! Utente '" & NuovoUtente.Login & "' loggato dal '" & loggato.DaQuando & "' sulla postazione " & loggato.Postazione.ToUpper)
    '                End If

    '            End If
    '        End While
    '        Sottofondo()
    '    End If

    'End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        'tmrOra.Enabled = False
        'PostazioneCorrente.MostraAttesa()

        ChiudiSessioneLavoro()

        Application.Exit()

    End Sub

    'Private Sub tmrAgg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAgg.Tick
    '    tmrAgg.Enabled = False
    '    Dim Ult As DCLibrary.LiveUpdate.cRilasci
    '    Ult = Postazione.CaricaAggiornamenti()

    '    If Ult.LastRilascioId > Postazione.Rilascio Then

    '        pctAgg.Visible = True

    '    End If
    '    tmrAgg.Enabled = True
    'End Sub

    'Private Sub pctAgg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctAgg.Click
    '    Postazione.AggiornaProgramma(Me, True)
    'End Sub

    'Private Sub lnkImpostazioni_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkImpostazioni.LinkClicked
    '    Postazione.AggiornaProgramma(Me, False)
    'End Sub

    Private Sub UcOrdini_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SplitContainerPrincipale_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainerPrincipale.DoubleClick

        If SplitContainerPrincipale.SplitterDistance = 0 Then
            SplitContainerPrincipale.SplitterDistance = 260
        Else
            SplitContainerPrincipale.SplitterDistance = 0
        End If


    End Sub

    Private Sub lnkMaxSpace_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMaxSpace.LinkClicked

        GestisciSpazio()
        '        SplitContainerOrdini.SplitterDistance = SplitContainerOrdini.Width - SplitContainerOrdini.DefaultWidth - 60

    End Sub

    Private Sub GestisciSpazio()
        If SplitContainerPrincipale.SplitterDistance = 0 Then
            ResettaSpazio()
        Else
            RestringiSpazio()
        End If
    End Sub

    Private Sub UcPostitMain_Load(sender As System.Object, e As System.EventArgs) Handles UcPostitMain.Load

    End Sub

    Private Sub lnkClose_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        End
    End Sub

    Private Sub lnkMinimize_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Try
        'PostazioneCorrente.MostraAttesa()
        Application.Exit()
        '
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub lnkImpostazioni_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkImpostazioni.LinkClicked
        Sottofondo()
        Dim x As New frmOpzioni

        If x.Carica() Then
            '    Postazione.SaveXml()
            Application.Restart()
        End If
        x.Dispose()
        x = Nothing
        Sottofondo()
    End Sub

    Private Sub pctMonitor_Click(sender As Object, e As EventArgs) Handles pctMonitor.Click
        Dim f As New frmMonitorOperatore
        f.Carica()
    End Sub

    Private Sub pctAgg_Click(sender As Object, e As EventArgs) Handles pctAgg.Click
        If MessageBox.Show("Vuoi forzare l'aggiornamento automatico del Gestionale Former?", "Aggiornamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            UpdateAppAtShutdown = True
            Application.Exit()
        End If
    End Sub

    Private Sub pctLogo_Click(sender As Object, e As EventArgs) Handles pctLogo.Click

        'If FormerDebug.DebugAttivo Then
        '    Using f As New frmAllegaFileOnline

        '        f.Carica(7725)

        '    End Using
        'End If

    End Sub

    Private Sub btnClose_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles btnClose.ChangeUICues

    End Sub
End Class
