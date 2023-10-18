Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogic
Imports FormerPrinter
Imports Telerik.WinControls

Public Class ucMainToolbar
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ColoraSfondo(lnkCalc)
        'ColoraSfondo(lnkCercaBarCode)
        'ColoraSfondo(lnkPeso)
        ''ColoraSfondo(lnkNewOrdWiz)
        'ColoraSfondo(lnkPubblWeb)
        'ColoraSfondo(lnkCalcDigitale)
        'ColoraSfondo(lnkNumAuto)
        CaricaCombo()

        RadNotification.Popup.AlertElement.BackColor = Color.FromArgb(214, 224, 61)
        RadNotification.Popup.AlertElement.GradientStyle = GradientStyles.Solid
        RadNotification.Popup.AlertElement.BorderColor = Color.Black
        RadNotification.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        RadNotification.Popup.AlertElement.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        RadNotification.Popup.AlertElement.CaptionElement.CaptionGrip.BackColor = Color.FromArgb(64, 64, 64)

        RadCentrale.Popup.AlertElement.BackColor = Color.Orange
        RadCentrale.Popup.AlertElement.ForeColor = Color.White
        RadCentrale.Popup.AlertElement.GradientStyle = GradientStyles.Solid
        RadCentrale.Popup.AlertElement.BorderColor = Color.Black
        RadCentrale.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        RadCentrale.Popup.AlertElement.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        RadCentrale.Popup.AlertElement.CaptionElement.CaptionGrip.BackColor = Color.FromArgb(64, 64, 64)
        RadCentrale.AutoClose = True
        RadCentrale.AutoCloseDelay = 3

    End Sub

    Private Sub CaricaCombo()

        Using mgr As New UtentiDAO

            Dim l As List(Of Utente) = mgr.FindAll(LFM.Utente.Login,
                                                   New LUNA.LunaSearchParameter(LFM.Utente.Attivo, enSiNo.Si),
                                                   New LUNA.LunaSearchParameter(LFM.Utente.Tipo, enTipoUtente.Operatore))
            cmbUtenteLoggato.DisplayMember = "Login"
            cmbUtenteLoggato.ValueMember = "IdUt"
            cmbUtenteLoggato.DataSource = l

        End Using

        If PostazioneCorrente.DbInUsoEsercizio And FormerDebug.DebugAttivo = True Then
            lblCounter.StartBlink()
        End If

        If IntPtr.Size = 4 Then
            lblConn.Text = 32
        Else
            lblConn.Text = 64
        End If


    End Sub

    Private Sub SetTimerReminder()
        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin AndAlso FormerDebug.DebugAttivo = False Then

            Dim Diff As Integer = 0
            Dim DataRif As Date = Now
            DataRif = New Date(DataRif.Year, DataRif.Month, DataRif.Day, 11, 15, 0)
            Diff = DateDiff(DateInterval.Second, Now, DataRif)
            If Diff <= 0 Then
                DataRif = New Date(DataRif.Year, DataRif.Month, DataRif.Day, 16, 15, 0)
                Diff = DateDiff(DateInterval.Second, Now, DataRif)
                If Diff <= 0 Then
                    DataRif = DataRif.AddDays(1)
                    DataRif = New Date(DataRif.Year, DataRif.Month, DataRif.Day, 11, 15, 0)
                    Diff = DateDiff(DateInterval.Second, Now, DataRif)
                End If
            End If

            tmrReminder.Interval = Diff * 1000
            tmrReminder.Enabled = True
            'tmrReminder.Start()

        End If


    End Sub
    Public Sub Carica()

        'FormerDebug.Traccia("CARICAMENTO INIZIALE")

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Or
           PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.SuperOperatore Then

            cmbUtenteLoggato.Visible = False
            'lblBonusMaturato.Visible = False
            'If FormerDebug.DebugAttivo Then
            'lnkPubblWeb.Visible = True
            'Else
            ' lnkPubblWeb.Visible = False
            'End If

            'lnkNewOrdWiz.Visible = True
            'TestConnessioneDemone()
            toolTipMsg.RemoveAll()
            toolTipMsg.SetToolTip(lblConn, "In Connessione... La prima connessione può impiegare al massimo 2 minuti")
            lblConn.BackColor = Color.LightGray
            tmrConnDemone.Enabled = True
            'lnkCaricoMagazzino.Visible = False

            'Dim LockPre As IsLockedRis = FormerLock.IsLocked(enFunctionLock.PreRefine)
            'If LockPre.IdUt = PostazioneCorrente.UtenteConnesso.IdUt AndAlso LockPre.IsLocked = True Then
            '    PreRefineToolStripMenuItem.BackColor = FormerColori.ColoreFunctionLocked
            '    PreRefineToolStripMenuItem.Tag = enSiNo.Si
            'End If

            'Dim LockCom As IsLockedRis = FormerLock.IsLocked(enFunctionLock.CreazioneCommesse)
            'If LockCom.IdUt = PostazioneCorrente.UtenteConnesso.IdUt AndAlso LockCom.IsLocked = True Then
            '    CreazioneCommesseToolStripMenuItem.BackColor = FormerColori.ColoreFunctionLocked
            '    CreazioneCommesseToolStripMenuItem.Tag = enSiNo.Si
            'End If

            'CalcolaLockAttivi()

            lblConn.Visible = True
            'AggiornaChiamatePerse()

            SetTimerReminder()

        Else

            cmbUtenteLoggato.Visible = True
            If cmbUtenteLoggato.SelectedValue <> PostazioneCorrente.UtenteConnesso.IdUt Then MgrControl.SelectIndexCombo(cmbUtenteLoggato, PostazioneCorrente.UtenteConnesso.IdUt)
            If PostazioneCorrente.IsUsbLogin Then
                cmbUtenteLoggato.Enabled = False
            End If
            'lblUtLoggato.Text = PostazioneCorrente.UtenteConnesso.Login)
            'lblBonusMaturato.Visible = True
            PubblicazioneListinoToolStripMenuItem.Visible = False
            HotFolderToolStripMenuItem.Visible = False
            toolstripInserisciOrdine.Enabled = False
            CercaToolStripMenuItem.Visible = False
            BarcodeToolStripMenuItem.Visible = False
            lnkChiamate.Visible = False
            CercaToolStripMenuItem.Enabled = False
            FunctionLockToolStripMenuItem.Visible = False
            StampaComandaOperatoreToolStripMenuItem.Visible = False
            ToolStripSeparator5.Visible = False
            'StrumentiToolStripMenuItem.Visible = False
            'lnkCalcDigitale.Visible = False
            'lnkNumAuto.Visible = False
            'lnkCercaBarCode.Visible = False

            'If FormerDebug.DebugAttivo = False Then lnkCaricoMagazzino.Visible = False

            'lnkTicket.Visible = False
            'lnkNewOrdWiz.Visible = False
        End If

    End Sub

    Private Sub lnkNewOrd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Dim frmRif As New frmOrdine

        Dim Ris As Integer = 0
        ParentFormEx.Sottofondo()
        Ris = frmRif.Carica()

        ParentFormEx.Sottofondo()
        frmRif.Dispose()

    End Sub

    'Public Property BonusMaturato() As String
    '    Get
    '        Return lblUtLoggato.Text
    '    End Get
    '    Set(ByVal value As String)
    '        lblUtLoggato.Text = value
    '    End Set
    'End Property

    Private Sub lnkChangeOperat_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Application.Restart()
    End Sub

    Private Sub lnkPeso_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub CercaConBarcode()

        Dim Ris As String = ""

        If 1 <> 1 Then 'DebugAttivo Then
            Ris = InputBox("inserisci il barcode")
        Else
            ParentFormEx.Sottofondo()
            Using x As New frmMagazzinoBarCodeRCTF
                Ris = x.Carica
            End Using
            ParentFormEx.Sottofondo()
        End If

        Ris = Ris.TrimEnd
        Ris = Ris.TrimStart
        'se ris e' pieno ho il codice in formato testo di ordine e numero collo caricato

        If Ris.Length = 13 Or Ris.Length = 12 Then

            Ris = Ris.Substring(0, 12)
            'qui si puo trattare di un ordine in consegna tramite corriere o diretto quindi ho i due codici da gestire
            Dim CodiceRifs As String = ""
            Dim CodiceRif As Integer = 0
            Dim NumCollo As Integer = 0
            If Ris.StartsWith("9") Then ' CONSEGNA
                CodiceRifs = Ris.Substring(1, 7)
                NumCollo = Ris.Substring(8, 4)
                CodiceRif = CInt(CodiceRifs)

                Dim IdScatola As Integer = 0
                'qui devo riaprire la consegna in gestione scatole ma partendo dall'id della scatola
                Using mgr As New OrdiniScatoleDAO
                    Dim l As List(Of OrdineScatola) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.OrdineScatola.IdScatola, CodiceRif))

                    If l.Count Then
                        IdScatola = l(0).IdScatola
                    End If

                End Using

                If IdScatola Then
                    Using xf As New frmConsegnaImballaggio
                        ParentFormEx.Sottofondo()
                        xf.Carica(CodiceRif)
                        ParentFormEx.Sottofondo()
                    End Using

                Else
                    Beep()
                End If
            ElseIf Ris.StartsWith("0") Then 'ORDINE
                CodiceRifs = Ris.Substring(0, 7)
                NumCollo = Ris.Substring(7, 4)

                'PACCO ORDINE
                CodiceRif = CInt(CodiceRifs)
                Using xf As New frmOrdine
                    ParentFormEx.Sottofondo()
                    xf.Carica(CodiceRif)
                    ParentFormEx.Sottofondo()
                End Using

            ElseIf Ris.StartsWith("8") Then 'documento fiscale 'apro per pagare

                CodiceRifs = Ris.Substring(1)
                'CodiceRifs = CodiceRifs.Substring(0, CodiceRifs.Length - 1)
                CodiceRif = CInt(CodiceRifs)
                Dim l As List(Of Ricavo) = Nothing
                Using mgr As New RicaviDAO
                    l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.IdRicavo, CodiceRif))
                End Using

                If l.Count Then
                    ParentFormEx.Sottofondo()

                    Dim Differenza As Single = 0
                    Using mgr As New PagamentiDAO
                        Differenza = mgr.ImportoAncoraDaPagareDocumento(CodiceRif, enTipoVoceContab.VoceVendita)
                    End Using

                    If Differenza Then
                        'ParentFormerForm.Sottofondo 

                        Using frmP As New frmContabilitaPagamento
                            frmP.Carica(, , CodiceRif, enTipoVoceContab.VoceVendita)
                        End Using

                        'Using frmC As New frmDocumentoContabile
                        '    frmC.Carica(CodiceRif, enTipoVoceContab.enTipoVoceVendita)
                        'End Using

                        'ParentFormerForm.Sottofondo 
                    Else
                        MessageBox.Show("Il documento risulta già pagato")
                    End If

                    'Using frmC As New frmDocumentoContabile
                    '    frmC.Carica(CodiceRif, enTipoVoceContab.enTipoVoceVendita)
                    'End Using

                    ParentFormEx.Sottofondo()
                Else
                    MessageBox.Show("Il documento non esiste")
                End If

            End If
        Else
            If Ris.Length <> 0 Then MessageBox.Show("Codice inserito formalmente non valido!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub lnkCercaBarCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)


    End Sub

    Private _BufferNotificheChiamate As String = String.Empty
    Private _CounterNotificheChiamate As Integer = 0

    Private _BufferNotifiche As String = String.Empty
    Private _CounterNotifiche As Integer = 0

    Public Sub AddNotifica(Testo As String) ', TipoNotifica As enTipoNotifica)

        If Testo.StartsWith("Chiamata da") = False Then
            If _BufferNotifiche = String.Empty Or _BufferNotifiche = "Non ci sono notifiche da visualizzare." Then
                _BufferNotifiche = "Fai doppio click per segnare tutte le notifiche come lette." & ControlChars.NewLine & ControlChars.NewLine
            End If

            _BufferNotifiche = Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & "." & Now.Second.ToString("00") & " - " & Testo & ControlChars.NewLine & _BufferNotifiche
            _CounterNotifiche += 1


            RadNotification.CaptionText = "FORMER GESTIONALE"
            RadNotification.ContentText = Testo
            RadNotification.Show()
        Else
            'qui si tratta di chiamate
            If _BufferNotificheChiamate = String.Empty Or _BufferNotificheChiamate = "Non ci sono notifiche da visualizzare." Then
                _BufferNotificheChiamate = "Fai doppio click per segnare tutte le notifiche come lette." & ControlChars.NewLine & ControlChars.NewLine
            End If

            _BufferNotificheChiamate = Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & "." & Now.Second.ToString("00") & " - " & Testo & ControlChars.NewLine & _BufferNotificheChiamate
            _CounterNotificheChiamate += 1


        End If




        SetNotifiche()

        'If Testo.StartsWith("Chiamata da") = False Then
        '    RadNotification.CaptionText = "FORMER GESTIONALE"
        '    RadNotification.ContentText = Testo
        '    RadNotification.Show()
        'End If

    End Sub

    Public Sub ResetNotifiche()

        _BufferNotifiche = "Non ci sono notifiche da visualizzare."
        _CounterNotifiche = 0
        SetNotifiche()

    End Sub

    Public Sub ResetNotificheChiamate()

        _BufferNotificheChiamate = "Non ci sono notifiche da visualizzare."
        _CounterNotificheChiamate = 0
        SetNotifiche()

    End Sub

    Private Sub SetNotifiche()
        If _CounterNotifiche Then
            lblNotifiche.BackColor = Color.FromArgb(214, 224, 61)
        Else
            lblNotifiche.BackColor = Color.White
        End If
        lblNotifiche.Text = _CounterNotifiche
        toolTipHelp.SetToolTip(lblNotifiche, _BufferNotifiche)


        If _CounterNotificheChiamate Then
            lnkChiamate.BackColor = Color.FromArgb(214, 224, 61)
        Else
            lnkChiamate.BackColor = Color.White
        End If
        lnkChiamate.Text = _CounterNotificheChiamate
        toolTipHelp.SetToolTip(lnkChiamate, _BufferNotificheChiamate)


    End Sub

    'Private Sub lnkNewOrdWiz_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    '    Dim frmRif As New frmWizOrd

    '    Dim Ris As Integer = 0

    '    ParentFormerForm.Sottofondo 
    '    'in ris ho l'id dell'ordine se mi arriva
    '    Ris = frmRif.Carica()
    '    ParentFormerForm.Sottofondo 
    '    frmRif.Dispose()
    'End Sub

    Private Sub lnkPubblWeb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub tmrConnAtt_Tick(sender As Object, e As EventArgs) Handles tmrConnAtt.Tick

        tmrConnAtt.Enabled = False

        If FormerDebug.DebugAttivo Then
            lblCounter.Visible = True
            Dim txt As String = "C" & LUNA.LunaContext.TotConnAttive & "-T" & LUNA.LunaContext.TotTransactionAttive

            Dim c As Process = Process.GetCurrentProcess
            txt &= " mem " & Math.Round(c.PagedMemorySize64 / 1024) & "kb #DEV SERVER: "

            If PostazioneCorrente.DbInUsoEsercizio Then
                txt &= "ESERCIZIO!!!"
                lblCounter.BackColor = Color.Red
                lblCounter.ForeColor = Color.White
            Else
                txt &= "SVILUPPO!!!"
                lblCounter.BackColor = Color.Green
                lblCounter.ForeColor = Color.White
            End If

            lblCounter.Text = txt

            Application.DoEvents()

            tmrConnAtt.Enabled = True
        Else
            lblCounter.Visible = False
        End If

    End Sub

    Private Sub TestConnessioneDemone()
        Dim ConnServerOk As Boolean = False

        If FormerDebug.DebugAttivo = False Then
            ConnServerOk = FormerEnvironment.ISServiceUp

            Dim MessaggioTooltip As String = String.Empty

            If ConnServerOk Then
                If PostazioneCorrente.ScaricamentoOrdiniInCorso Then
                    MessaggioTooltip = "Scaricamento Ordini in corso..."
                    lblConn.BackColor = Color.FromArgb(253, 231, 110) ' Color.Green
                    lblConn.Image = My.Resources._Download
                Else
                    lblConn.Image = My.Resources._ConnessioneServer
                    MessaggioTooltip = "Connessione al Demone Attiva"
                    lblConn.BackColor = Color.FromArgb(214, 224, 61) ' Color.Green
                End If
            Else
                lblConn.Image = My.Resources._ConnessioneServer
                MessaggioTooltip = "Connessione al Demone NON Attiva dalle " & FormerEnvironment.LastDaemonPing.ToString("HH:mm.ss")
                lblConn.BackColor = Color.Red
            End If

            If toolTipMsg.GetToolTip(lblConn) <> MessaggioTooltip Then
                toolTipMsg.RemoveAll()
                toolTipMsg.SetToolTip(lblConn, MessaggioTooltip)
            End If
        End If



    End Sub

    Private Sub lblBonus_Click(sender As Object, e As EventArgs)
        MessageBox.Show(MostraInfoDebug())
    End Sub

    Private Function MostraInfoDebug() As String

        Dim c As Process = Process.GetCurrentProcess()

        Dim MemUse As String = "Mem Usage (Working Set): " & c.WorkingSet64 / 1024 & " K" &
         "VM Size (Private Bytes): " & c.PagedMemorySize64 / 1024 & " K" &
         "GC TotalMemory: " & GC.GetTotalMemory(True) & " bytes - Luna Conn Attive: " & LUNA.LunaContext.TotConnAttive
        Return MemUse

    End Function

    Private Sub lnkCalcDigitale_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub tmrPulisciMemoria_Tick(sender As Object, e As EventArgs) Handles tmrPulisciMemoria.Tick

        tmrPulisciMemoria.Enabled = False

        RipulisciMemoria()

        'AggiornaChiamatePerse()

        tmrPulisciMemoria.Enabled = True

    End Sub

    Private Sub AggiornaChiamatePerse()

        Try
            Using mgr As New MessaggiDAO

                Dim l As List(Of Messaggio) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Messaggio.TipoMsg, enTipoMessaggio.Chiamata),
                                                          New LUNA.LunaSearchParameter(LFM.Messaggio.Letto, enSiNo.No),
                                                          New LUNA.LunaSearchParameter(LFM.Messaggio.IdDest, PostazioneCorrente.UtenteConnesso.IdUt))

                If l.Count Then
                    'lnkChiamate.Image = My.Resources._ChiamataPersa
                    lnkChiamate.BackColor = Color.FromArgb(214, 224, 61)
                    toolTipHelp.SetToolTip(lnkChiamate, "Ci sono delle chiamate da gestire, guarda nei messaggi!")
                Else
                    'lnkChiamate.Image = My.Resources._Chiamata
                    lnkChiamate.BackColor = Color.White
                    toolTipHelp.SetToolTip(lnkChiamate, "Non ci sono chiamate da gestire")
                End If
                lnkChiamate.Text = l.Count

            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RipulisciMemoria()
        'Cursor = Cursors.WaitCursor
        Try
            Cursor = Cursors.WaitCursor
            GC.Collect()
            Cursor = Cursors.Default
            'Beep()

        Catch ex As Exception

        End Try
        'Cursor = Cursors.Default

    End Sub

    Private Sub tmrConnDemone_Tick(sender As Object, e As EventArgs) Handles tmrConnDemone.Tick
        tmrConnDemone.Enabled = False
        TestConnessioneDemone()
        tmrConnDemone.Enabled = True
    End Sub

    Private Sub cmbUtenteLoggato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUtenteLoggato.SelectedIndexChanged

        If sender.focused Then
            Cursor.Current = Cursors.WaitCursor
            'cambio utente
            If PostazioneCorrente.UtenteConnesso.IdUt <> cmbUtenteLoggato.SelectedValue Then
                ParentFormEx.Sottofondo()
                Dim IdNewUt As Integer = cmbUtenteLoggato.SelectedValue

                Dim NuovoUtente As New Utente
                NuovoUtente.Read(IdNewUt)

                Dim OkLoginEsclusivo As Boolean = True
                Dim loggato As RisUserLogged = FormerSecurity.IsUserLogged(NuovoUtente.IdUt)

                If loggato.IsLogged Then
                    'qui non posso entrare ammenoche non sia gia loggato sulla stessa postazione
                    If loggato.Postazione <> System.Environment.MachineName Then
                        OkLoginEsclusivo = False
                    End If
                End If

                If OkLoginEsclusivo Then
                    'ricarico tutto
                    Try
                        FormerSecurity.RegistraLogOut(PostazioneCorrente.UtenteConnesso.IdUt)
                    Catch ex As Exception

                    End Try

                    PostazioneCorrente.UtenteConnesso = NuovoUtente

                    FormerSecurity.RegistraLogin(NuovoUtente.IdUt)

                    LUNA.LunaContext.SetUtenteConnesso(PostazioneCorrente.UtenteConnesso)

                    FormerLog.RegistraAccessoPostazione(PostazioneCorrente.UtenteConnesso.Login, PostazioneCorrente.Versione)

                    'MgrControl.SelectIndexCombo(cmbUtenteLoggato, PostazioneCorrente.UtenteConnesso.IdUt)

                    FormPrincipale.AdattaAmbienteByUtente(False)
                Else
                    MessageBox.Show("Impossibile accedere! Utente '" & NuovoUtente.Login & "' loggato dal '" & loggato.DaQuando & "' sulla postazione " & loggato.Postazione.ToUpper)
                End If


                ParentFormEx.Sottofondo()
                'FormPrincipale.Refresh()
            End If

            Cursor.Current = Cursors.Default

        End If

    End Sub

    Private Sub lblNotifiche_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lblNotifiche.MouseDoubleClick
        ResetNotifiche()
    End Sub

    Private Sub CalcolatricePesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcolatricePesoToolStripMenuItem.Click

        ParentFormEx.Sottofondo()
        Using x As New frmCalcPeso
            x.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub CalcolatriceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcolatriceToolStripMenuItem.Click

        Shell("calc.exe")

    End Sub

    Private Sub CalcolatriceDigitaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcolatriceDigitaleToolStripMenuItem.Click

        ParentFormEx.Sottofondo()
        Using f As New frmCalcPrezzoIndicativo
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub ConBarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConBarcodeToolStripMenuItem.Click
        CercaConBarcode()
    End Sub

    Private Sub LogOperatoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOperatoreToolStripMenuItem.Click

        ParentFormEx.Sottofondo()
        Using f As New frmOperatoreLog
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub NumerazioneAutomaticaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NumerazioneAutomaticaToolStripMenuItem.Click

        ParentFormEx.Sottofondo()
        Using f As New frmCalcNumerazione
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub CaricoMagazzinoOperatoreToolStripMenuItem_Click(sender As Object, e As EventArgs)

        ParentFormEx.Sottofondo()
        Using f As New frmMagazzinoCaricoOperatore
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub ProcedimentoFustelleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcedimentoFustelleToolStripMenuItem.Click

        ParentFormEx.Sottofondo()
        Using f As New frmCalcFustella
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub HotFolderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HotFolderToolStripMenuItem.Click

        'carico la gestione hotfolder
        ParentFormEx.Sottofondo()
        Using f As New frmHotFolderMgr
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub BarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarcodeToolStripMenuItem.Click
        CercaConBarcode()
    End Sub

    Private Sub toolstripInserisciOrdine_Click(sender As Object, e As EventArgs) Handles toolstripInserisciOrdine.Click

        'ParentFormEx.Sottofondo()
        Cursor.Current = Cursors.WaitCursor

        Dim f As New frmOrdineCreaOnline
        f.Carica()

        Cursor.Current = Cursors.Default
        'ParentFormEx.Sottofondo()

    End Sub

    Private Sub lblNewVer_Click(sender As Object, e As EventArgs) Handles lblNewVer.Click
        If MessageBox.Show("Vuoi forzare l'aggiornamento automatico del Gestionale Former?", "Aggiornamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            UpdateAppAtShutdown = True
            Application.Exit()
        End If
    End Sub

    Private _NewVersion As Boolean = False

    Public Sub ShowNote(Testo As String)

        RadCentrale.Hide()

        If Testo.Length Then
            RadCentrale.PlaySound = True
            RadCentrale.ContentText = Testo
            RadCentrale.Show()
        End If

    End Sub

    Public Sub NewVersion()

        'lblNewVer.Visible = True
        If _NewVersion = False Then
            _NewVersion = True

            lblNewVer.Image = My.Resources._NewVersionB
            'lblNewVer.BackColor = Color.Orange

            toolTipHelp.SetToolTip(lblNewVer, "E' disponibile una nuova versione del gestionale FORMER. Clicca qui per aggiornare!")
            RadNotification.CaptionText = "FORMER GESTIONALE"
            RadNotification.ContentText = "E' disponibile una nuova versione del gestionale FORMER"
            RadNotification.Show()
        End If



        'lblNewVer.StartBlink()

    End Sub

    Private Sub PubblicazioneListinoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PubblicazioneListinoToolStripMenuItem.Click

        Using frmRif As New frmListinoPubblicazioneOnline

            Dim Ris As Integer = 0

            ParentFormEx.Sottofondo()
            'in ris ho l'id dell'ordine se mi arriva
            Ris = frmRif.Carica()
            ParentFormEx.Sottofondo()

        End Using

    End Sub

    'Private Sub LockClick(Sender As Object, Funzione As enFunctionLock)

    '    Dim ris As IsLockedRis = FormerLock.IsLocked(Funzione)

    '    If ris.IsLocked = False Then
    '        If FormerLock.Lock(PostazioneCorrente.UtenteConnesso.IdUt, Funzione) Then
    '            Sender.BackColor = FormerColori.ColoreFunctionLocked
    '            Sender.tag = enSiNo.Si
    '        End If
    '    Else
    '        If ris.IdUt = PostazioneCorrente.UtenteConnesso.IdUt Then
    '            'qui lo devo sbloccare
    '            FormerLock.UnLock(PostazioneCorrente.UtenteConnesso.IdUt, Funzione)
    '            Sender.BackColor = FormerColori.ColoreFunctionUnlocked
    '            Sender.tag = enSiNo.No
    '        Else
    '            MessageBox.Show("La funzione è già bloccata sulla postazione " & ris.Postazione.ToUpper & " da '" & ris.Utente.Login & "'")
    '        End If
    '    End If

    '    CalcolaLockAttivi

    'End Sub

    Private Sub CalcolaLockAttivi()

        Dim Ris As Integer = 0

        For Each mnu As ToolStripMenuItem In FunctionLockToolStripMenuItem.DropDownItems

            If mnu.Tag = enSiNo.Si Then
                Ris += 1
            End If

        Next

        If Ris Then
            FunctionLockToolStripMenuItem.BackColor = FormerColori.ColoreFunctionLocked
        Else
            FunctionLockToolStripMenuItem.BackColor = FormerColori.ColoreFunctionUnlocked
        End If

        FunctionLockToolStripMenuItem.Text = "FunctionLock (" & Ris & ")"

    End Sub

    Private Sub StampaComandaOperatoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StampaComandaOperatoreToolStripMenuItem.Click

        ParentFormEx.Sottofondo()
        Using f As New frmOperatoreComanda
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub AiutoProcedureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AiutoProcedureToolStripMenuItem.Click

        ParentFormEx.Sottofondo()
        Using f As New frmProcedure
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub lblConn_Click(sender As Object, e As EventArgs) Handles lblConn.Click

        ParentFormEx.Sottofondo()
        Using f As New frmDaemonMonitor
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

        'ThemeResolutionService.ApplicationThemeName = "VisualStudio2012DarkTheme" 'FormerConfig.FConfiguration.Environment.TelerikTheme

    End Sub

    Private Sub StampaEtichettaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StampaEtichettaToolStripMenuItem.Click

        ParentFormEx.Sottofondo()
        Using f As New frmStampaEtichette
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub SegnalazioneAnomaliaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SegnalazioneAnomaliaToolStripMenuItem.Click

        Using f As New frmBug
            f.Carica(Me.ParentFormEx)
        End Using

    End Sub

    Private Sub GeneraListinoPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraListinoPDFToolStripMenuItem.Click

        ParentFormEx.Sottofondo()

        Using f As New frmCreaListinoPDF
            f.Carica()
        End Using

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub ProdottiDiConsumoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PDFToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PDFToolsToolStripMenuItem.Click
        ParentFormEx.Sottofondo()

        Using f As New frmPdfTools
            f.Carica()
        End Using

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub ScaricoMaterialeDiConsumoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScaricoMaterialeDiConsumoToolStripMenuItem.Click

        ParentFormEx.Sottofondo()

        Using f As New frmMagazzinoScaricoConsumo
            f.Carica()
        End Using

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub StornoRisorsaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StornoRisorsaToolStripMenuItem.Click

        ParentFormEx.Sottofondo()

        Using f As New frmMagazzinoStorno
            f.Carica()
        End Using

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub SegnalazioneAcquistoRisorsaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SegnalazioneAcquistoRisorsaToolStripMenuItem.Click

        ParentFormEx.Sottofondo()

        Using f As New frmMagazzinoRichiesta
            f.Carica()
        End Using

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub InviaSchermataCorrenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InviaSchermataCorrenteToolStripMenuItem.Click

        Using f As New frmScreenShoot
            f.Carica(Me.ParentFormEx)
        End Using

    End Sub

    Private Sub CalcoloPrezzoLavorazioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcoloPrezzoLavorazioneToolStripMenuItem.Click
        ParentFormEx.Sottofondo()

        Using f As New frmCalcPrezzoLavorazioni
            f.Carica()
        End Using

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub CercaFileSorgentiGrandiDimensioniToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CercaFileSorgentiGrandiDimensioniToolStripMenuItem.Click

        'ParentFormEx.Sottofondo()

        Dim f As New frmToolPulisciBigFile
        f.Carica()

        'Using f As New frmToolPulisciBigFile
        '    f.Carica()
        'End Using

        'ParentFormEx.Sottofondo()
    End Sub

    Private Sub lblNotifiche_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblNotifiche.LinkClicked

    End Sub

    Private Sub tmrReminder_Tick(sender As Object, e As EventArgs) Handles tmrReminder.Tick
        tmrReminder.Enabled = False
        Dim F As New frmReminder
        F.Carica()
        SetTimerReminder()
    End Sub

    Private Sub AllegaFileOnlineMenuItem_Click(sender As Object, e As EventArgs) Handles AllegaFileOnlineMenuItem.Click

        Dim IdOrdineOnline As Integer = 0

        Try
            Dim NumeroLavoro As String = InputBox("Inserisci il numero di Lavoro online", "Allega file a Lavoro Online")

            If IsNumeric(NumeroLavoro) Then
                ParentFormEx.Sottofondo()
                Using f As New frmOrdineAllegaFileOnline
                    f.Carica(NumeroLavoro)
                End Using
                ParentFormEx.Sottofondo()

            Else
                MessageBox.Show("Inserire un numero di lavoro valido")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DocumentoDiCaricoDiMagazzinoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentoDiCaricoDiMagazzinoToolStripMenuItem.Click

        ParentFormEx.Sottofondo()

        Using f As New frmMagazzinoCaricoDiMagazzino
            f.Carica()
        End Using

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub LnkChiamate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkChiamate.LinkClicked

    End Sub

    Private Sub lnkChiamate_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lnkChiamate.MouseDoubleClick
        ResetNotificheChiamate()
    End Sub

    Private Sub VediLultimoReleaseNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VediLultimoReleaseNoteToolStripMenuItem.Click
        ParentFormEx.Sottofondo()
        Using f As New frmReleaseNote
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If PostazioneCorrente.ScaricamentoOrdiniInCorso Then
            MessageBox.Show("Il Demone sta già scaricando gli ordini")
        Else
            FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_ForzaScaricamentoOrdini, "SCARICAMENTO")
            MessageBox.Show("Scaricamento forzato ordini richiesto.")
        End If
    End Sub

    Private Sub SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SbloccaOrdiniLockedDaPiùDi5MinutiToolStripMenuItem.Click

        If MessageBox.Show("Confermi lo sblocco di tutti gli ordini Locked da più di 5 minuti?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'sblocco tutti gli ordini da utenti non demone

            Using mgr As New FunctionLockDAO
                Dim L As List(Of FunctionLock) = mgr.FindAll(New LUNA.LSP(LFM.FunctionLock.IdFunction, enFunctionLock.OrdineAperto),
                                                             New LUNA.LSP(LFM.FunctionLock.IdUt, FormerConst.UtentiSpecifici.IdUtenteAdmin, "<>"))

                For Each singLock In L
                    Dim Diff As Integer = DateDiff(DateInterval.Minute, singLock.Quando, Now)

                    If Diff > 5 Then
                        'qui lo cancello
                        mgr.Delete(singLock.IdFunctionLock)
                    End If
                Next

            End Using

            MessageBox.Show("Tutti i gli ordini con lock superiori ai 5 minuti sono stati sbloccati")
        End If

    End Sub

    'Private Sub PreRefineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreRefineToolStripMenuItem.Click

    '    LockClick(sender, enFunctionLock.PreRefine)

    'End Sub

    'Private Sub CreazioneCommesseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreazioneCommesseToolStripMenuItem.Click

    '    LockClick(sender, enFunctionLock.CreazioneCommesse)

    'End Sub
End Class
