Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerPrinter
Imports FormerConfig
Imports FormerBusinessLogic
Imports System.IO
Imports FormerBusinessLogicInterface

Public Class frmLogin
    'Inherits frmUsbResponsiveForm

    Private Function ProceduraTest() As Integer
        Dim ris As Integer = 0

        'Using f As New frmPercorsoConsegna
        '    f.Carica("Via Adria 85, Cerenova")
        'End Using

        'Using f As New baseFormInternaFixed
        '    f.ShowDialog()
        'End Using

        'Using f As New frmDocumentoContabile
        '    f.Carica(1)
        'End Using

        'ris = 1

        Return ris

    End Function

    Private Sub CaricaCombo()

        Using mgr As New UtentiDAO
            Dim parNoAdmin As LUNA.LunaSearchParameter = Nothing

            If System.Environment.MachineName <> "THECELL" AndAlso System.Environment.MachineName <> "LUNADIXLAB" Then
                parNoAdmin = New LUNA.LunaSearchParameter
                parNoAdmin.Value = 1
                parNoAdmin.FieldName = "IdUt"
                parNoAdmin.SqlOperator = "<>"
            End If

            cmbAdmin.DisplayMember = "LoginEx"
            cmbAdmin.ValueMember = "IdUt"
            cmbAdmin.DataSource = mgr.FindAll(New LUNA.LunaSearchOption With {.AddEmptyItem = False, .OrderBy = "Login"},
                                              New LUNA.LunaSearchParameter(LFM.Utente.Attivo, enSiNo.Si),
                                              New LUNA.LunaSearchParameter(LFM.Utente.Tipo, enTipoUtente.Operatore, "<>"),
                                              parNoAdmin)
        End Using

        Using mgr As New UtentiDAO
            cmbOperatori.DisplayMember = "LoginEx"
            cmbOperatori.ValueMember = "IdUt"
            cmbOperatori.DataSource = mgr.FindAll(New LUNA.LunaSearchOption With {.AddEmptyItem = True, .OrderBy = "Login"},
                                              New LUNA.LunaSearchParameter(LFM.Utente.Attivo, enSiNo.Si),
                                              New LUNA.LunaSearchParameter(LFM.Utente.Tipo, enTipoUtente.Operatore))

        End Using

        TabMain.TabPages.Remove(tbLogin)

        'cmbTest.Carica(enTipoRubrica.Tutto)

        'UcComboRubrica.Carica(enTipoRubrica.Tutto)
        ' cmbRubrica.Carica(enTipoRubrica.Tutto)

    End Sub

    Private Sub Login()

        Try
            'btnOk.Enabled = False
            AccediToolStripMenuItem.Enabled = False
            txtPwd.Enabled = False

            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()
            Dim Autenticato As Integer = 0
            Dim utSel As Utente = Nothing

            If rdoAdmin.Checked Then
                'login amministratore
                If cmbAdmin.SelectedValue Then
                    If txtPwd.Text.Length <> 0 Then
                        Using utMan As New UtentiDAO
                            utSel = utMan.LoginUt(cmbAdmin.Text, txtPwd.Text)
                        End Using
                    End If
                End If
            Else
                'login operatore
                If cmbOperatori.SelectedValue Then
                    utSel = New Utente
                    utSel.Read(cmbOperatori.SelectedValue)
                End If
            End If

            If Not utSel Is Nothing Then

                Dim OkLoginEsclusivo As Boolean = True
                Dim loggato As RisUserLogged = FormerSecurity.IsUserLogged(utSel.IdUt)

                If loggato.IsLogged Then
                    'qui non posso entrare ammenoche non sia gia loggato sulla stessa postazione
                    If loggato.Postazione <> System.Environment.MachineName Then
                        OkLoginEsclusivo = False
                    End If
                End If

                If OkLoginEsclusivo = False Then
                    If MessageBox.Show("Utente '" & utSel.Login & "' loggato dal '" & loggato.DaQuando & "' sulla postazione " & loggato.Postazione.ToUpper & ". Si vuole forzare la chiusura della sessione già attiva?", "Sessione esistente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_Service, "DISCONNECT", utSel.Login)
                        OkLoginEsclusivo = True
                    End If
                End If

                If OkLoginEsclusivo Then
                    PostazioneCorrente.UtenteConnesso = utSel
                    LUNA.LunaContext.SetUtenteConnesso(PostazioneCorrente.UtenteConnesso)

                    FormerSecurity.RegistraLogin(utSel.IdUt)

                    FormerLog.RegistraAccessoPostazione(PostazioneCorrente.UtenteConnesso.Login, PostazioneCorrente.Versione)


                    If File.Exists(FormerPath.PathFileLastUser) Then
                        Try
                            File.Delete(FormerPath.PathFileLastUser)
                        Catch ex As Exception

                        End Try

                    End If

                    Using w As New StreamWriter(FormerPath.PathFileLastUser)
                        w.Write(PostazioneCorrente.UtenteConnesso.IdUt)
                    End Using

                    Dispose(True)

                    PostazioneCorrente.MostraAttesa()

                    If PostazioneCorrente.TracciamentoAttivo Then Trace.Listeners.Add(New TextWriterTraceListener("C:\temp\FormerLog-" & Now.ToString("HH.mm.ss") & ".txt"))
                    If PostazioneCorrente.TracciamentoAttivo Then Trace.AutoFlush = True
                    If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento principale")
                    Dim NewPrincip As frmMain
                    NewPrincip = New frmMain
                    If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - frmMain.Carica")

                    NewPrincip.Carica()

                Else

                    Me.Cursor = Cursors.Default
                    AccediToolStripMenuItem.Enabled = True
                    txtPwd.Enabled = True

                    'Me.Cursor = Cursors.Default
                    '    MessageBox.Show("Impossibile accedere! Utente '" & utSel.Login & "' loggato dal '" & loggato.DaQuando & "' sulla postazione " & loggato.Postazione.ToUpper)
                    '    btnOk.Enabled = True
                    '    txtPwd.Enabled = True
                End If

            Else
                If txtPwd.Text.Length <> 0 Then
                    MessageBox.Show("Login errata! Selezionare un amministratore o un operatore e inserire la password corretta se richiesta", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Inserire la password!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                AccediToolStripMenuItem.Enabled = True
                txtPwd.Enabled = True
                Me.Cursor = Cursors.Default
                txtPwd.Focus()
                txtPwd.SelectAll()
            End If

        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub


    'Private Sub frmLogin_ChiaveUSBConnessa() Handles Me.ChiaveUSBConnessa

    '    UsbLogin()

    'End Sub

    Private Sub UsbLogin(Optional WithMessage As Boolean = False)
        pnlCollegata.Visible = True
        Application.DoEvents()
        Dim U As Utente = MgrUsbLogin.TryLogin(WithMessage)

        If Not U Is Nothing Then

            Dim OkLoginEsclusivo As Boolean = True
            Dim loggato As RisUserLogged = FormerSecurity.IsUserLogged(U.IdUt)

            If loggato.IsLogged Then
                'qui non posso entrare ammenoche non sia gia loggato sulla stessa postazione
                If loggato.Postazione <> System.Environment.MachineName Then
                    OkLoginEsclusivo = False
                End If
            End If

            If OkLoginEsclusivo Then
                PostazioneCorrente.UtenteConnesso = U
                PostazioneCorrente.IsUsbLogin = True

                FormerSecurity.RegistraLogin(U.IdUt)

                FormerLog.RegistraAccessoPostazione(PostazioneCorrente.UtenteConnesso.Login, PostazioneCorrente.Versione, True)

                Dim NewPrincip As frmMain
                NewPrincip = New frmMain
                NewPrincip.Carica()
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("Impossibile accedere! Utente '" & U.Login & "' loggato dal '" & loggato.DaQuando & "' sulla postazione " & loggato.Postazione.ToUpper)
            End If

            Dispose(True)
        Else
            pnlCollegata.Visible = False
        End If

    End Sub

    Private Sub CaricamentoIniziale()

        Application.EnableVisualStyles()
        Application.DoEvents()

        Try
            FormerDebug.DebugAttivo = FConfiguration.Debug.DebugAttivo ' Configuration.ConfigurationManager.AppSettings("DebugAttivo")

        Catch ex As Exception

        End Try

        'If Postazione.ReadXml() = False Then
        '    'qui non è stato trovato il file ini
        '    'vedremo cosa fare
        '    Dim x As New frmOpzioni
        '    If x.Carica() Then
        '        Postazione.SaveXml()
        '    Else
        '        End
        '    End If
        '    x.Dispose()
        '    x = Nothing
        'End If

        '        ProxyStampa.StampanteLibera = PostazioneCorrente.StampanteLibera
        '       ProxyStampa.StampanteFatture = PostazioneCorrente.StampanteFatture

        'qui tutto  ok apro la connessione  in modo da poter caricare le combo
        'If Postazione.ApriConn() <> 0 Then
        '    MessageBox.Show("Impossibile aprire la connessione al database principale!", Postazione.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Application.Exit()
        'End If

        CaricaCombo()
        If FormerDebug.DebugAttivo Then

            lblDebug.Text = "#DEV SERVER: "

            If PostazioneCorrente.DbInUsoEsercizio = False Then
                lblDebug.Text &= " SVILUPPO"
                lblDebug.ForeColor = Color.Green
            Else
                lblDebug.Text &= " ESERCIZIO"
                lblDebug.ForeColor = Color.Red
            End If

        End If

        Version.Text = PostazioneCorrente.Versione
        lblVer.Text = PostazioneCorrente.Versione

        SelezionaUtenteDefault()

        If FormerDebug.DebugAttivo Then
            'GestisciSpazio()
            If PostazioneCorrente.DbInUsoEsercizio Then
                MessageBox.Show("ATTENZIONE!!! SEI SUL DB DI ESERCIZIO")
            End If
        End If

        'LUNA.LunaContext.SetPostazione(Postazione)

        'se arrivo qui tutto e' andato bene
        'Dim utList As New UtentiDAO

        'cmbUtenti.DataSource = utList.GetAll("Login")

        'UsbLogin()

        'If FormerDebug.DebugAttivo And pnlCollegata.Visible = False Then

        '    'MessageBox.Show(FormerConfig.FConfiguration.Printer.Etichette)
        '    If ProceduraTest() = 0 Then
        '        AvvioAutomaticoAdmin()
        '    Else
        '        End
        '    End If


        '    'Using f As New frmOrdineCreaOnline
        '    '    f.Carica(0)
        '    'End Using

        'End If

        '        btnOk.FlatAppearance.BorderSize = 0

        'Using f As New frmOrdineAllegaFileOnline
        '    f.Carica(7749)
        'End Using



    End Sub

    Private Sub SelezionaUtenteDefault()
        Try
            If System.IO.File.Exists(FormerPath.PathFileLastUser) Then
                Dim Buffer As String = String.Empty
                Using r As New StreamReader(FormerPath.PathFileLastUser)
                    Buffer = r.ReadToEnd
                End Using

                Dim IdUser As Integer = Buffer

                'ora qui lo seleziono 

                Using U As New Utente
                    U.Read(IdUser)
                    If U.Tipo = enTipoUtente.Operatore Then
                        'rdoAdmin.Checked = False
                        rdoOperat.Checked = True
                        MgrControl.SelectIndexCombo(cmbOperatori, IdUser)
                        'btnOk.Focus()
                        'cmbOperatori.Focus()
                    Else
                        'rdoOperat.Checked = False
                        rdoAdmin.Checked = True
                        MgrControl.SelectIndexCombo(cmbAdmin, IdUser)
                        txtPwd.Focus()
                    End If
                End Using

            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CaricamentoIniziale()

    End Sub

    Private Sub AvvioAutomaticoAdmin()
        cmbAdmin.SelectedValue = 1
        txtPwd.Text = "admin"
        Login()
    End Sub

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        'qui controllo se si tratta di debug attivo o no

        'DebugAttivo = My.Application.CommandLineArgs.Contains("debug")

        ' If Now.Day > 22 Then rallentamentoGenerico = True

    End Sub

    Private Sub btnChiudi_Click(sender As Object, e As EventArgs)

        'UpdateAppAtShutdown = True

        Application.Exit()

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pctKey_Click(sender As Object, e As EventArgs) Handles pctKey.Click
        If FormerDebug.DebugAttivo Then
            If MessageBox.Show("Confermi?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then






                'Dim direc As New DirectoryInfo("\\former-server\Z\FormerEsercizio\Listino\template")

                'For Each F As FileInfo In direc.GetFiles("*.pdf")

                '    Dim NomePreview As String = "\\former-server\Z\FormerEsercizio\Listino\template\" & F.Name & ".jpg"

                '    Try
                '        If File.Exists(NomePreview) = False Then
                '            FormerHelper.PDF.GetPdfThumbnail(F.FullName, NomePreview)
                '        End If

                '    Catch ex As Exception
                '        'Using w As New StreamWriter("D:\temp\p\" & F.Name & ".err")
                '        '    w.Write(ex.ToString)
                '        'End Using
                '    End Try
                'Next

                MessageBox.Show("OK")

            End If
        End If
    End Sub

    Private Sub cmbAdmin_MouseClick(sender As Object, e As MouseEventArgs) Handles cmbAdmin.MouseClick
        rdoAdmin.Checked = True
    End Sub

    Private Sub cmbOperatori_MouseClick(sender As Object, e As MouseEventArgs) Handles cmbOperatori.MouseClick
        rdoOperat.Checked = True
    End Sub

    Private Sub txtPwd_GotFocus(sender As Object, e As EventArgs) Handles txtPwd.GotFocus
        If sender.focus Then rdoAdmin.Checked = True
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        rdoOperat.Checked = True
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        rdoAdmin.Checked = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If FormerDebug.DebugAttivo Then

            Dim f As New frmOrdineCreaOnline
            f.Carica()
            'End Using

        End If
    End Sub

    Public Shared Function RiControllaListiniBase(Optional IdListinoBaseSpecifico As Integer = 0) As Integer
        Dim RisModificati As Integer = 0
        Using mgr As New ListinoBaseDAO

            Dim p As LUNA.LunaSearchParameter = Nothing

            If IdListinoBaseSpecifico Then
                p = New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBase, IdListinoBaseSpecifico)
            End If

            Dim l As List(Of ListinoBase) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.VMotoreCalcolo, MgrPreventivazioneB.VMotoreCalcolo, "<>"),
                                                        p)

            'qui ho tutti i listinibase non compatibili
            For Each lb As ListinoBase In l

                'qui devo ricalcolare le percentuali di ricarico di ogni quantità
                lb.CaricaLavorazioni()
                lb.NumFacciate = lb.FaccMin

                Dim V1 As Single = lb.p1
                Dim V2 As Single = lb.p2
                Dim V3 As Single = lb.p3
                Dim V4 As Single = lb.p4
                Dim V5 As Single = lb.p5
                Dim V6 As Single = lb.p6

                Dim ris As RisListinoBase = MgrPreventivazioneB.CalcolaPrezzi(lb,
                                                                              lb.LavorazioniBaseB)

                If lb.p1 <> V1 OrElse
                   lb.p2 <> V2 OrElse
                   lb.p3 <> V3 OrElse
                   lb.p4 <> V4 OrElse
                   lb.p5 <> V5 OrElse
                   lb.p6 <> V6 Then

                    RisModificati += 1

                End If

                lb.VMotoreCalcolo = MgrPreventivazioneB.VMotoreCalcolo
                lb.Save()

            Next

        End Using
        Return RisModificati
    End Function


    Private Sub frmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            Login()
        End If

    End Sub

    Private Sub ChiudiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChiudiToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SalvaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccediToolStripMenuItem.Click
        Login()
    End Sub
End Class
