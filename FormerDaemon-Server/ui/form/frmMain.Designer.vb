<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.tabServices = New System.Windows.Forms.TabControl()
        Me.tpServices = New System.Windows.Forms.TabPage()
        Me.lnkRestartRouter = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEsegui1Syncronizer = New System.Windows.Forms.Button()
        Me.imlMain = New System.Windows.Forms.ImageList(Me.components)
        Me.lblStatoServNewOrd = New System.Windows.Forms.Label()
        Me.lblStatoServSyncronizer = New System.Windows.Forms.Label()
        Me.btnApriLogSyncronizer = New System.Windows.Forms.Button()
        Me.btnStopSyncronizer = New System.Windows.Forms.Button()
        Me.btnStartSyncronizer = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLastOpSyncronizer = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnPrendiInCaricoChiamata = New System.Windows.Forms.Button()
        Me.btnApriLogCaller = New System.Windows.Forms.Button()
        Me.btnStopCaller = New System.Windows.Forms.Button()
        Me.btnStartCaller = New System.Windows.Forms.Button()
        Me.lblStatoCaller = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblLastOpCaller = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnEseguiTxtToHCC = New System.Windows.Forms.Button()
        Me.lblStatoServOrario = New System.Windows.Forms.Label()
        Me.lblStatoServCheckNewVer = New System.Windows.Forms.Label()
        Me.lblStatoServTxtToHCC = New System.Windows.Forms.Label()
        Me.btnApriLogService = New System.Windows.Forms.Button()
        Me.btnStopService = New System.Windows.Forms.Button()
        Me.btnStartService = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLastOpService = New System.Windows.Forms.Label()
        Me.pctServices = New System.Windows.Forms.PictureBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnApriLogPrinter = New System.Windows.Forms.Button()
        Me.btnStopPrinter = New System.Windows.Forms.Button()
        Me.btnStartPrinter = New System.Windows.Forms.Button()
        Me.lblStatoPrinter = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblLastOpPrinter = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnEsegui1Messenger = New System.Windows.Forms.Button()
        Me.btnApriLogMessenger = New System.Windows.Forms.Button()
        Me.btnStopMessenger = New System.Windows.Forms.Button()
        Me.btnStartMessenger = New System.Windows.Forms.Button()
        Me.lblStatoMessenger = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblLastOpMessenger = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.tpServicesLog = New System.Windows.Forms.TabPage()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.btnRefreshLog = New System.Windows.Forms.Button()
        Me.DgLog = New System.Windows.Forms.DataGridView()
        Me.IcoTipo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Prio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOrdLista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpSyncronizer = New System.Windows.Forms.TabPage()
        Me.txtSyncronizer = New System.Windows.Forms.TextBox()
        Me.tpService = New System.Windows.Forms.TabPage()
        Me.txtService = New System.Windows.Forms.TextBox()
        Me.tpMessenger = New System.Windows.Forms.TabPage()
        Me.txtMessenger = New System.Windows.Forms.TextBox()
        Me.tpPrinter = New System.Windows.Forms.TabPage()
        Me.txtPrinter = New System.Windows.Forms.TextBox()
        Me.tpCaller = New System.Windows.Forms.TabPage()
        Me.txtCaller = New System.Windows.Forms.TextBox()
        Me.tpPostazioni = New System.Windows.Forms.TabPage()
        Me.lblLastVer = New System.Windows.Forms.Label()
        Me.lblLastCheckPostazioni = New System.Windows.Forms.Label()
        Me.btnAggiornaPostaz = New System.Windows.Forms.Button()
        Me.tvwPostazioni = New System.Windows.Forms.TreeView()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.tpOpzioni = New System.Windows.Forms.TabPage()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnCopia = New System.Windows.Forms.Button()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.cmbStampanti = New System.Windows.Forms.ComboBox()
        Me.btnTestTB = New System.Windows.Forms.Button()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.btnReconnect = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnMessage = New System.Windows.Forms.Button()
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.btnTestGhostscript = New System.Windows.Forms.Button()
        Me.btnForzaturaOperazioni = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.chkAutoStartCaller = New System.Windows.Forms.CheckBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.chkAutoStartPrinter = New System.Windows.Forms.CheckBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.chkAutoStartMessenger = New System.Windows.Forms.CheckBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.chkAutoStartService = New System.Windows.Forms.CheckBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.chkAutoStartSyncronizer = New System.Windows.Forms.CheckBox()
        Me.statusBar = New System.Windows.Forms.StatusStrip()
        Me.lblInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblServerInterno = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblInternet = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblSitoWeb = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblServerVirtuale = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblProc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrPostazioni = New System.Windows.Forms.Timer(Me.components)
        Me.tmrLog = New System.Windows.Forms.Timer(Me.components)
        Me.tabMain.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.tabServices.SuspendLayout()
        Me.tpServices.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pctServices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpServicesLog.SuspendLayout()
        CType(Me.DgLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSyncronizer.SuspendLayout()
        Me.tpService.SuspendLayout()
        Me.tpMessenger.SuspendLayout()
        Me.tpPrinter.SuspendLayout()
        Me.tpCaller.SuspendLayout()
        Me.tpPostazioni.SuspendLayout()
        Me.tpOpzioni.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.Controls.Add(Me.tpMain)
        Me.tabMain.Controls.Add(Me.tpSyncronizer)
        Me.tabMain.Controls.Add(Me.tpService)
        Me.tabMain.Controls.Add(Me.tpMessenger)
        Me.tabMain.Controls.Add(Me.tpPrinter)
        Me.tabMain.Controls.Add(Me.tpCaller)
        Me.tabMain.Controls.Add(Me.tpPostazioni)
        Me.tabMain.Controls.Add(Me.tpOpzioni)
        Me.tabMain.ImageList = Me.imlTab
        Me.tabMain.Location = New System.Drawing.Point(3, 3)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(981, 666)
        Me.tabMain.TabIndex = 1
        '
        'tpMain
        '
        Me.tpMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tpMain.Controls.Add(Me.tabServices)
        Me.tpMain.ImageKey = "_Step.png"
        Me.tpMain.Location = New System.Drawing.Point(4, 31)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(973, 631)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Servizi"
        '
        'tabServices
        '
        Me.tabServices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabServices.Controls.Add(Me.tpServices)
        Me.tabServices.Controls.Add(Me.tpServicesLog)
        Me.tabServices.Location = New System.Drawing.Point(6, 9)
        Me.tabServices.Name = "tabServices"
        Me.tabServices.SelectedIndex = 0
        Me.tabServices.Size = New System.Drawing.Size(959, 616)
        Me.tabServices.TabIndex = 9
        '
        'tpServices
        '
        Me.tpServices.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tpServices.Controls.Add(Me.lnkRestartRouter)
        Me.tpServices.Controls.Add(Me.GroupBox1)
        Me.tpServices.Controls.Add(Me.GroupBox5)
        Me.tpServices.Controls.Add(Me.GroupBox2)
        Me.tpServices.Controls.Add(Me.GroupBox4)
        Me.tpServices.Controls.Add(Me.GroupBox3)
        Me.tpServices.Location = New System.Drawing.Point(4, 24)
        Me.tpServices.Name = "tpServices"
        Me.tpServices.Padding = New System.Windows.Forms.Padding(3)
        Me.tpServices.Size = New System.Drawing.Size(951, 588)
        Me.tpServices.TabIndex = 0
        Me.tpServices.Text = "Services"
        '
        'lnkRestartRouter
        '
        Me.lnkRestartRouter.AutoSize = True
        Me.lnkRestartRouter.Image = Global.FormerDaemon_Server.My.Resources.Resources._Aggiorna
        Me.lnkRestartRouter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRestartRouter.LinkColor = System.Drawing.Color.White
        Me.lnkRestartRouter.Location = New System.Drawing.Point(10, 553)
        Me.lnkRestartRouter.Name = "lnkRestartRouter"
        Me.lnkRestartRouter.Padding = New System.Windows.Forms.Padding(30, 5, 0, 5)
        Me.lnkRestartRouter.Size = New System.Drawing.Size(112, 25)
        Me.lnkRestartRouter.TabIndex = 5
        Me.lnkRestartRouter.TabStop = True
        Me.lnkRestartRouter.Text = "Riavvia Router"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnEsegui1Syncronizer)
        Me.GroupBox1.Controls.Add(Me.lblStatoServNewOrd)
        Me.GroupBox1.Controls.Add(Me.lblStatoServSyncronizer)
        Me.GroupBox1.Controls.Add(Me.btnApriLogSyncronizer)
        Me.GroupBox1.Controls.Add(Me.btnStopSyncronizer)
        Me.GroupBox1.Controls.Add(Me.btnStartSyncronizer)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblLastOpSyncronizer)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(939, 104)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Syncronizer"
        '
        'btnEsegui1Syncronizer
        '
        Me.btnEsegui1Syncronizer.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnEsegui1Syncronizer.ForeColor = System.Drawing.Color.Black
        Me.btnEsegui1Syncronizer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEsegui1Syncronizer.ImageKey = "_Aggiorna.png"
        Me.btnEsegui1Syncronizer.ImageList = Me.imlMain
        Me.btnEsegui1Syncronizer.Location = New System.Drawing.Point(427, 70)
        Me.btnEsegui1Syncronizer.Name = "btnEsegui1Syncronizer"
        Me.btnEsegui1Syncronizer.Size = New System.Drawing.Size(120, 25)
        Me.btnEsegui1Syncronizer.TabIndex = 12
        Me.btnEsegui1Syncronizer.Text = "Scarica Ordini"
        Me.btnEsegui1Syncronizer.UseVisualStyleBackColor = False
        '
        'imlMain
        '
        Me.imlMain.ImageStream = CType(resources.GetObject("imlMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMain.Images.SetKeyName(0, "_Play.png")
        Me.imlMain.Images.SetKeyName(1, "_StopRed.png")
        Me.imlMain.Images.SetKeyName(2, "_CartellaAperta.png")
        Me.imlMain.Images.SetKeyName(3, "_ChiamataPersa.png")
        Me.imlMain.Images.SetKeyName(4, "_Aggiorna.png")
        '
        'lblStatoServNewOrd
        '
        Me.lblStatoServNewOrd.BackColor = System.Drawing.Color.White
        Me.lblStatoServNewOrd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatoServNewOrd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatoServNewOrd.ForeColor = System.Drawing.Color.Red
        Me.lblStatoServNewOrd.Location = New System.Drawing.Point(172, 21)
        Me.lblStatoServNewOrd.Name = "lblStatoServNewOrd"
        Me.lblStatoServNewOrd.Size = New System.Drawing.Size(250, 20)
        Me.lblStatoServNewOrd.TabIndex = 13
        Me.lblStatoServNewOrd.Text = "NUOVI ORDINI (4 min.)"
        Me.lblStatoServNewOrd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatoServSyncronizer
        '
        Me.lblStatoServSyncronizer.BackColor = System.Drawing.Color.White
        Me.lblStatoServSyncronizer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatoServSyncronizer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatoServSyncronizer.ForeColor = System.Drawing.Color.Red
        Me.lblStatoServSyncronizer.Location = New System.Drawing.Point(428, 21)
        Me.lblStatoServSyncronizer.Name = "lblStatoServSyncronizer"
        Me.lblStatoServSyncronizer.Size = New System.Drawing.Size(250, 20)
        Me.lblStatoServSyncronizer.TabIndex = 12
        Me.lblStatoServSyncronizer.Text = "SYNCRONIZER (4 min)"
        Me.lblStatoServSyncronizer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnApriLogSyncronizer
        '
        Me.btnApriLogSyncronizer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApriLogSyncronizer.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnApriLogSyncronizer.ForeColor = System.Drawing.Color.Black
        Me.btnApriLogSyncronizer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApriLogSyncronizer.ImageKey = "_CartellaAperta.png"
        Me.btnApriLogSyncronizer.ImageList = Me.imlMain
        Me.btnApriLogSyncronizer.Location = New System.Drawing.Point(813, 70)
        Me.btnApriLogSyncronizer.Name = "btnApriLogSyncronizer"
        Me.btnApriLogSyncronizer.Size = New System.Drawing.Size(120, 25)
        Me.btnApriLogSyncronizer.TabIndex = 7
        Me.btnApriLogSyncronizer.Text = "Apri Log"
        Me.btnApriLogSyncronizer.UseVisualStyleBackColor = False
        '
        'btnStopSyncronizer
        '
        Me.btnStopSyncronizer.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStopSyncronizer.Enabled = False
        Me.btnStopSyncronizer.ForeColor = System.Drawing.Color.Black
        Me.btnStopSyncronizer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStopSyncronizer.ImageKey = "_StopRed.png"
        Me.btnStopSyncronizer.ImageList = Me.imlMain
        Me.btnStopSyncronizer.Location = New System.Drawing.Point(301, 70)
        Me.btnStopSyncronizer.Name = "btnStopSyncronizer"
        Me.btnStopSyncronizer.Size = New System.Drawing.Size(120, 25)
        Me.btnStopSyncronizer.TabIndex = 6
        Me.btnStopSyncronizer.Text = "Interrompi"
        Me.btnStopSyncronizer.UseVisualStyleBackColor = False
        '
        'btnStartSyncronizer
        '
        Me.btnStartSyncronizer.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStartSyncronizer.ForeColor = System.Drawing.Color.Black
        Me.btnStartSyncronizer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStartSyncronizer.ImageKey = "_Play.png"
        Me.btnStartSyncronizer.ImageList = Me.imlMain
        Me.btnStartSyncronizer.Location = New System.Drawing.Point(175, 70)
        Me.btnStartSyncronizer.Name = "btnStartSyncronizer"
        Me.btnStartSyncronizer.Size = New System.Drawing.Size(120, 25)
        Me.btnStartSyncronizer.TabIndex = 5
        Me.btnStartSyncronizer.Text = "Avvia"
        Me.btnStartSyncronizer.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(54, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Ultima Operazione:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Stato Servizio:"
        '
        'lblLastOpSyncronizer
        '
        Me.lblLastOpSyncronizer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastOpSyncronizer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastOpSyncronizer.Location = New System.Drawing.Point(172, 46)
        Me.lblLastOpSyncronizer.Name = "lblLastOpSyncronizer"
        Me.lblLastOpSyncronizer.Size = New System.Drawing.Size(761, 21)
        Me.lblLastOpSyncronizer.TabIndex = 1
        Me.lblLastOpSyncronizer.Text = "-"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = Global.FormerDaemon_Server.My.Resources.Resources._Aggiorna
        Me.PictureBox1.Location = New System.Drawing.Point(7, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.btnPrendiInCaricoChiamata)
        Me.GroupBox5.Controls.Add(Me.btnApriLogCaller)
        Me.GroupBox5.Controls.Add(Me.btnStopCaller)
        Me.GroupBox5.Controls.Add(Me.btnStartCaller)
        Me.GroupBox5.Controls.Add(Me.lblStatoCaller)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.lblLastOpCaller)
        Me.GroupBox5.Controls.Add(Me.PictureBox5)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(6, 446)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(939, 104)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Caller"
        '
        'btnPrendiInCaricoChiamata
        '
        Me.btnPrendiInCaricoChiamata.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrendiInCaricoChiamata.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnPrendiInCaricoChiamata.ForeColor = System.Drawing.Color.Black
        Me.btnPrendiInCaricoChiamata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrendiInCaricoChiamata.ImageKey = "_ChiamataPersa.png"
        Me.btnPrendiInCaricoChiamata.ImageList = Me.imlMain
        Me.btnPrendiInCaricoChiamata.Location = New System.Drawing.Point(687, 70)
        Me.btnPrendiInCaricoChiamata.Name = "btnPrendiInCaricoChiamata"
        Me.btnPrendiInCaricoChiamata.Size = New System.Drawing.Size(120, 25)
        Me.btnPrendiInCaricoChiamata.TabIndex = 8
        Me.btnPrendiInCaricoChiamata.Text = "Prendi in Carico"
        Me.btnPrendiInCaricoChiamata.UseVisualStyleBackColor = False
        '
        'btnApriLogCaller
        '
        Me.btnApriLogCaller.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApriLogCaller.AutoEllipsis = True
        Me.btnApriLogCaller.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnApriLogCaller.ForeColor = System.Drawing.Color.Black
        Me.btnApriLogCaller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApriLogCaller.ImageKey = "_CartellaAperta.png"
        Me.btnApriLogCaller.ImageList = Me.imlMain
        Me.btnApriLogCaller.Location = New System.Drawing.Point(813, 70)
        Me.btnApriLogCaller.Name = "btnApriLogCaller"
        Me.btnApriLogCaller.Size = New System.Drawing.Size(120, 25)
        Me.btnApriLogCaller.TabIndex = 7
        Me.btnApriLogCaller.Text = "Apri Log"
        Me.btnApriLogCaller.UseVisualStyleBackColor = False
        '
        'btnStopCaller
        '
        Me.btnStopCaller.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStopCaller.Enabled = False
        Me.btnStopCaller.ForeColor = System.Drawing.Color.Black
        Me.btnStopCaller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStopCaller.ImageKey = "_StopRed.png"
        Me.btnStopCaller.ImageList = Me.imlMain
        Me.btnStopCaller.Location = New System.Drawing.Point(301, 70)
        Me.btnStopCaller.Name = "btnStopCaller"
        Me.btnStopCaller.Size = New System.Drawing.Size(120, 25)
        Me.btnStopCaller.TabIndex = 6
        Me.btnStopCaller.Text = "Interrompi"
        Me.btnStopCaller.UseVisualStyleBackColor = False
        '
        'btnStartCaller
        '
        Me.btnStartCaller.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStartCaller.ForeColor = System.Drawing.Color.Black
        Me.btnStartCaller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStartCaller.ImageKey = "_Play.png"
        Me.btnStartCaller.ImageList = Me.imlMain
        Me.btnStartCaller.Location = New System.Drawing.Point(175, 70)
        Me.btnStartCaller.Name = "btnStartCaller"
        Me.btnStartCaller.Size = New System.Drawing.Size(120, 25)
        Me.btnStartCaller.TabIndex = 5
        Me.btnStartCaller.Text = "Avvia"
        Me.btnStartCaller.UseVisualStyleBackColor = False
        '
        'lblStatoCaller
        '
        Me.lblStatoCaller.BackColor = System.Drawing.Color.White
        Me.lblStatoCaller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatoCaller.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatoCaller.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblStatoCaller.Location = New System.Drawing.Point(172, 21)
        Me.lblStatoCaller.Name = "lblStatoCaller"
        Me.lblStatoCaller.Size = New System.Drawing.Size(250, 21)
        Me.lblStatoCaller.TabIndex = 4
        Me.lblStatoCaller.Text = "-"
        Me.lblStatoCaller.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(54, 46)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 15)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Ultima Operazione:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(54, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 15)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Stato Servizio:"
        '
        'lblLastOpCaller
        '
        Me.lblLastOpCaller.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastOpCaller.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastOpCaller.Location = New System.Drawing.Point(172, 46)
        Me.lblLastOpCaller.Name = "lblLastOpCaller"
        Me.lblLastOpCaller.Size = New System.Drawing.Size(761, 21)
        Me.lblLastOpCaller.TabIndex = 1
        Me.lblLastOpCaller.Text = "-"
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.White
        Me.PictureBox5.Image = Global.FormerDaemon_Server.My.Resources.Resources._Chiamata
        Me.PictureBox5.Location = New System.Drawing.Point(7, 21)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox5.TabIndex = 0
        Me.PictureBox5.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnEseguiTxtToHCC)
        Me.GroupBox2.Controls.Add(Me.lblStatoServOrario)
        Me.GroupBox2.Controls.Add(Me.lblStatoServCheckNewVer)
        Me.GroupBox2.Controls.Add(Me.lblStatoServTxtToHCC)
        Me.GroupBox2.Controls.Add(Me.btnApriLogService)
        Me.GroupBox2.Controls.Add(Me.btnStopService)
        Me.GroupBox2.Controls.Add(Me.btnStartService)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lblLastOpService)
        Me.GroupBox2.Controls.Add(Me.pctServices)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(6, 116)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(939, 104)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Service"
        '
        'btnEseguiTxtToHCC
        '
        Me.btnEseguiTxtToHCC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnEseguiTxtToHCC.ForeColor = System.Drawing.Color.Black
        Me.btnEseguiTxtToHCC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEseguiTxtToHCC.ImageKey = "_Aggiorna.png"
        Me.btnEseguiTxtToHCC.ImageList = Me.imlMain
        Me.btnEseguiTxtToHCC.Location = New System.Drawing.Point(427, 70)
        Me.btnEseguiTxtToHCC.Name = "btnEseguiTxtToHCC"
        Me.btnEseguiTxtToHCC.Size = New System.Drawing.Size(120, 25)
        Me.btnEseguiTxtToHCC.TabIndex = 12
        Me.btnEseguiTxtToHCC.Text = "Run TxtToHcc"
        Me.btnEseguiTxtToHCC.UseVisualStyleBackColor = False
        '
        'lblStatoServOrario
        '
        Me.lblStatoServOrario.BackColor = System.Drawing.Color.White
        Me.lblStatoServOrario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatoServOrario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatoServOrario.ForeColor = System.Drawing.Color.Red
        Me.lblStatoServOrario.Location = New System.Drawing.Point(684, 21)
        Me.lblStatoServOrario.Name = "lblStatoServOrario"
        Me.lblStatoServOrario.Size = New System.Drawing.Size(250, 20)
        Me.lblStatoServOrario.TabIndex = 11
        Me.lblStatoServOrario.Text = "PROCEDURE INTERNE (4 min.)"
        Me.lblStatoServOrario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatoServCheckNewVer
        '
        Me.lblStatoServCheckNewVer.BackColor = System.Drawing.Color.White
        Me.lblStatoServCheckNewVer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatoServCheckNewVer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatoServCheckNewVer.ForeColor = System.Drawing.Color.Red
        Me.lblStatoServCheckNewVer.Location = New System.Drawing.Point(428, 21)
        Me.lblStatoServCheckNewVer.Name = "lblStatoServCheckNewVer"
        Me.lblStatoServCheckNewVer.Size = New System.Drawing.Size(250, 20)
        Me.lblStatoServCheckNewVer.TabIndex = 10
        Me.lblStatoServCheckNewVer.Text = "CHECK NEW VERSION  (4 min.)"
        Me.lblStatoServCheckNewVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatoServTxtToHCC
        '
        Me.lblStatoServTxtToHCC.BackColor = System.Drawing.Color.White
        Me.lblStatoServTxtToHCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatoServTxtToHCC.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatoServTxtToHCC.ForeColor = System.Drawing.Color.Red
        Me.lblStatoServTxtToHCC.Location = New System.Drawing.Point(172, 21)
        Me.lblStatoServTxtToHCC.Name = "lblStatoServTxtToHCC"
        Me.lblStatoServTxtToHCC.Size = New System.Drawing.Size(250, 20)
        Me.lblStatoServTxtToHCC.TabIndex = 8
        Me.lblStatoServTxtToHCC.Text = "TXT TO HCC (4 min.)"
        Me.lblStatoServTxtToHCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnApriLogService
        '
        Me.btnApriLogService.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApriLogService.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnApriLogService.ForeColor = System.Drawing.Color.Black
        Me.btnApriLogService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApriLogService.ImageKey = "_CartellaAperta.png"
        Me.btnApriLogService.ImageList = Me.imlMain
        Me.btnApriLogService.Location = New System.Drawing.Point(813, 70)
        Me.btnApriLogService.Name = "btnApriLogService"
        Me.btnApriLogService.Size = New System.Drawing.Size(120, 25)
        Me.btnApriLogService.TabIndex = 7
        Me.btnApriLogService.Text = "Apri Log"
        Me.btnApriLogService.UseVisualStyleBackColor = False
        '
        'btnStopService
        '
        Me.btnStopService.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStopService.Enabled = False
        Me.btnStopService.ForeColor = System.Drawing.Color.Black
        Me.btnStopService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStopService.ImageKey = "_StopRed.png"
        Me.btnStopService.ImageList = Me.imlMain
        Me.btnStopService.Location = New System.Drawing.Point(301, 70)
        Me.btnStopService.Name = "btnStopService"
        Me.btnStopService.Size = New System.Drawing.Size(120, 25)
        Me.btnStopService.TabIndex = 6
        Me.btnStopService.Text = "Interrompi tutto"
        Me.btnStopService.UseVisualStyleBackColor = False
        '
        'btnStartService
        '
        Me.btnStartService.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStartService.ForeColor = System.Drawing.Color.Black
        Me.btnStartService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStartService.ImageKey = "_Play.png"
        Me.btnStartService.ImageList = Me.imlMain
        Me.btnStartService.Location = New System.Drawing.Point(175, 70)
        Me.btnStartService.Name = "btnStartService"
        Me.btnStartService.Size = New System.Drawing.Size(120, 25)
        Me.btnStartService.TabIndex = 5
        Me.btnStartService.Text = "Avvia tutto"
        Me.btnStartService.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(54, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Ultima Operazione:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(54, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Stato Servizi:"
        '
        'lblLastOpService
        '
        Me.lblLastOpService.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastOpService.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastOpService.Location = New System.Drawing.Point(172, 46)
        Me.lblLastOpService.Name = "lblLastOpService"
        Me.lblLastOpService.Size = New System.Drawing.Size(761, 21)
        Me.lblLastOpService.TabIndex = 1
        Me.lblLastOpService.Text = "-"
        '
        'pctServices
        '
        Me.pctServices.BackColor = System.Drawing.Color.White
        Me.pctServices.Image = Global.FormerDaemon_Server.My.Resources.Resources._Opzioni
        Me.pctServices.Location = New System.Drawing.Point(7, 21)
        Me.pctServices.Name = "pctServices"
        Me.pctServices.Size = New System.Drawing.Size(40, 40)
        Me.pctServices.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctServices.TabIndex = 0
        Me.pctServices.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btnApriLogPrinter)
        Me.GroupBox4.Controls.Add(Me.btnStopPrinter)
        Me.GroupBox4.Controls.Add(Me.btnStartPrinter)
        Me.GroupBox4.Controls.Add(Me.lblStatoPrinter)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.lblLastOpPrinter)
        Me.GroupBox4.Controls.Add(Me.PictureBox4)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(6, 336)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(939, 104)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "UDP"
        '
        'btnApriLogPrinter
        '
        Me.btnApriLogPrinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApriLogPrinter.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnApriLogPrinter.ForeColor = System.Drawing.Color.Black
        Me.btnApriLogPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApriLogPrinter.ImageKey = "_CartellaAperta.png"
        Me.btnApriLogPrinter.ImageList = Me.imlMain
        Me.btnApriLogPrinter.Location = New System.Drawing.Point(813, 70)
        Me.btnApriLogPrinter.Name = "btnApriLogPrinter"
        Me.btnApriLogPrinter.Size = New System.Drawing.Size(120, 25)
        Me.btnApriLogPrinter.TabIndex = 7
        Me.btnApriLogPrinter.Text = "Apri Log"
        Me.btnApriLogPrinter.UseVisualStyleBackColor = False
        '
        'btnStopPrinter
        '
        Me.btnStopPrinter.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStopPrinter.Enabled = False
        Me.btnStopPrinter.ForeColor = System.Drawing.Color.Black
        Me.btnStopPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStopPrinter.ImageKey = "_StopRed.png"
        Me.btnStopPrinter.ImageList = Me.imlMain
        Me.btnStopPrinter.Location = New System.Drawing.Point(301, 70)
        Me.btnStopPrinter.Name = "btnStopPrinter"
        Me.btnStopPrinter.Size = New System.Drawing.Size(120, 25)
        Me.btnStopPrinter.TabIndex = 6
        Me.btnStopPrinter.Text = "Interrompi"
        Me.btnStopPrinter.UseVisualStyleBackColor = False
        '
        'btnStartPrinter
        '
        Me.btnStartPrinter.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStartPrinter.ForeColor = System.Drawing.Color.Black
        Me.btnStartPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStartPrinter.ImageKey = "_Play.png"
        Me.btnStartPrinter.ImageList = Me.imlMain
        Me.btnStartPrinter.Location = New System.Drawing.Point(175, 70)
        Me.btnStartPrinter.Name = "btnStartPrinter"
        Me.btnStartPrinter.Size = New System.Drawing.Size(120, 25)
        Me.btnStartPrinter.TabIndex = 5
        Me.btnStartPrinter.Text = "Avvia"
        Me.btnStartPrinter.UseVisualStyleBackColor = False
        '
        'lblStatoPrinter
        '
        Me.lblStatoPrinter.BackColor = System.Drawing.Color.White
        Me.lblStatoPrinter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatoPrinter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatoPrinter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblStatoPrinter.Location = New System.Drawing.Point(172, 21)
        Me.lblStatoPrinter.Name = "lblStatoPrinter"
        Me.lblStatoPrinter.Size = New System.Drawing.Size(250, 21)
        Me.lblStatoPrinter.TabIndex = 4
        Me.lblStatoPrinter.Text = "-"
        Me.lblStatoPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(54, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 15)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Ultima Operazione:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(54, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 15)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Stato Servizio:"
        '
        'lblLastOpPrinter
        '
        Me.lblLastOpPrinter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastOpPrinter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastOpPrinter.Location = New System.Drawing.Point(172, 46)
        Me.lblLastOpPrinter.Name = "lblLastOpPrinter"
        Me.lblLastOpPrinter.Size = New System.Drawing.Size(761, 21)
        Me.lblLastOpPrinter.TabIndex = 1
        Me.lblLastOpPrinter.Text = "-"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.White
        Me.PictureBox4.Image = Global.FormerDaemon_Server.My.Resources.Resources._Stampa
        Me.PictureBox4.Location = New System.Drawing.Point(7, 21)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.btnEsegui1Messenger)
        Me.GroupBox3.Controls.Add(Me.btnApriLogMessenger)
        Me.GroupBox3.Controls.Add(Me.btnStopMessenger)
        Me.GroupBox3.Controls.Add(Me.btnStartMessenger)
        Me.GroupBox3.Controls.Add(Me.lblStatoMessenger)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.lblLastOpMessenger)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(6, 226)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(939, 104)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Messenger"
        '
        'btnEsegui1Messenger
        '
        Me.btnEsegui1Messenger.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnEsegui1Messenger.ForeColor = System.Drawing.Color.Black
        Me.btnEsegui1Messenger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEsegui1Messenger.ImageKey = "_Aggiorna.png"
        Me.btnEsegui1Messenger.ImageList = Me.imlMain
        Me.btnEsegui1Messenger.Location = New System.Drawing.Point(427, 70)
        Me.btnEsegui1Messenger.Name = "btnEsegui1Messenger"
        Me.btnEsegui1Messenger.Size = New System.Drawing.Size(120, 25)
        Me.btnEsegui1Messenger.TabIndex = 8
        Me.btnEsegui1Messenger.Text = "Run"
        Me.btnEsegui1Messenger.UseVisualStyleBackColor = False
        '
        'btnApriLogMessenger
        '
        Me.btnApriLogMessenger.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApriLogMessenger.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnApriLogMessenger.ForeColor = System.Drawing.Color.Black
        Me.btnApriLogMessenger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApriLogMessenger.ImageKey = "_CartellaAperta.png"
        Me.btnApriLogMessenger.ImageList = Me.imlMain
        Me.btnApriLogMessenger.Location = New System.Drawing.Point(813, 70)
        Me.btnApriLogMessenger.Name = "btnApriLogMessenger"
        Me.btnApriLogMessenger.Size = New System.Drawing.Size(120, 25)
        Me.btnApriLogMessenger.TabIndex = 7
        Me.btnApriLogMessenger.Text = "Apri Log"
        Me.btnApriLogMessenger.UseVisualStyleBackColor = False
        '
        'btnStopMessenger
        '
        Me.btnStopMessenger.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStopMessenger.Enabled = False
        Me.btnStopMessenger.ForeColor = System.Drawing.Color.Black
        Me.btnStopMessenger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStopMessenger.ImageKey = "_StopRed.png"
        Me.btnStopMessenger.ImageList = Me.imlMain
        Me.btnStopMessenger.Location = New System.Drawing.Point(301, 70)
        Me.btnStopMessenger.Name = "btnStopMessenger"
        Me.btnStopMessenger.Size = New System.Drawing.Size(120, 25)
        Me.btnStopMessenger.TabIndex = 6
        Me.btnStopMessenger.Text = "Interrompi"
        Me.btnStopMessenger.UseVisualStyleBackColor = False
        '
        'btnStartMessenger
        '
        Me.btnStartMessenger.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStartMessenger.ForeColor = System.Drawing.Color.Black
        Me.btnStartMessenger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStartMessenger.ImageKey = "_Play.png"
        Me.btnStartMessenger.ImageList = Me.imlMain
        Me.btnStartMessenger.Location = New System.Drawing.Point(175, 70)
        Me.btnStartMessenger.Name = "btnStartMessenger"
        Me.btnStartMessenger.Size = New System.Drawing.Size(120, 25)
        Me.btnStartMessenger.TabIndex = 5
        Me.btnStartMessenger.Text = "Avvia"
        Me.btnStartMessenger.UseVisualStyleBackColor = False
        '
        'lblStatoMessenger
        '
        Me.lblStatoMessenger.BackColor = System.Drawing.Color.White
        Me.lblStatoMessenger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatoMessenger.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatoMessenger.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblStatoMessenger.Location = New System.Drawing.Point(172, 21)
        Me.lblStatoMessenger.Name = "lblStatoMessenger"
        Me.lblStatoMessenger.Size = New System.Drawing.Size(250, 21)
        Me.lblStatoMessenger.TabIndex = 4
        Me.lblStatoMessenger.Text = "-"
        Me.lblStatoMessenger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(54, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 15)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Ultima Operazione:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(54, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 15)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Stato Servizio:"
        '
        'lblLastOpMessenger
        '
        Me.lblLastOpMessenger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastOpMessenger.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastOpMessenger.Location = New System.Drawing.Point(172, 46)
        Me.lblLastOpMessenger.Name = "lblLastOpMessenger"
        Me.lblLastOpMessenger.Size = New System.Drawing.Size(761, 21)
        Me.lblLastOpMessenger.TabIndex = 1
        Me.lblLastOpMessenger.Text = "-"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.White
        Me.PictureBox3.Image = Global.FormerDaemon_Server.My.Resources.Resources._Mail
        Me.PictureBox3.Location = New System.Drawing.Point(7, 21)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'tpServicesLog
        '
        Me.tpServicesLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tpServicesLog.Controls.Add(Me.btnReset)
        Me.tpServicesLog.Controls.Add(Me.Label1)
        Me.tpServicesLog.Controls.Add(Me.txtCerca)
        Me.tpServicesLog.Controls.Add(Me.btnRefreshLog)
        Me.tpServicesLog.Controls.Add(Me.DgLog)
        Me.tpServicesLog.Location = New System.Drawing.Point(4, 24)
        Me.tpServicesLog.Name = "tpServicesLog"
        Me.tpServicesLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tpServicesLog.Size = New System.Drawing.Size(951, 588)
        Me.tpServicesLog.TabIndex = 1
        Me.tpServicesLog.Text = "Log"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(273, 8)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(22, 21)
        Me.btnReset.TabIndex = 55
        Me.btnReset.Text = "X"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 15)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Cerca"
        '
        'txtCerca
        '
        Me.txtCerca.Location = New System.Drawing.Point(52, 8)
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(215, 23)
        Me.txtCerca.TabIndex = 53
        '
        'btnRefreshLog
        '
        Me.btnRefreshLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnRefreshLog.ForeColor = System.Drawing.Color.Black
        Me.btnRefreshLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefreshLog.ImageKey = "_Aggiorna.png"
        Me.btnRefreshLog.ImageList = Me.imlMain
        Me.btnRefreshLog.Location = New System.Drawing.Point(825, 6)
        Me.btnRefreshLog.Name = "btnRefreshLog"
        Me.btnRefreshLog.Size = New System.Drawing.Size(120, 25)
        Me.btnRefreshLog.TabIndex = 52
        Me.btnRefreshLog.Text = "Refresh"
        Me.btnRefreshLog.UseVisualStyleBackColor = False
        '
        'DgLog
        '
        Me.DgLog.AllowUserToAddRows = False
        Me.DgLog.AllowUserToDeleteRows = False
        Me.DgLog.AllowUserToOrderColumns = True
        Me.DgLog.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.DgLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgLog.BackgroundColor = System.Drawing.Color.White
        Me.DgLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLog.ColumnHeadersHeight = 20
        Me.DgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IcoTipo, Me.Prio, Me.IdOrdLista, Me.Descrizione})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLog.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLog.EnableHeadersVisualStyles = False
        Me.DgLog.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLog.Location = New System.Drawing.Point(6, 37)
        Me.DgLog.MultiSelect = False
        Me.DgLog.Name = "DgLog"
        Me.DgLog.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLog.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgLog.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLog.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgLog.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgLog.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLog.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLog.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLog.ShowCellToolTips = False
        Me.DgLog.ShowEditingIcon = False
        Me.DgLog.Size = New System.Drawing.Size(939, 573)
        Me.DgLog.TabIndex = 51
        Me.DgLog.TabStop = False
        '
        'IcoTipo
        '
        Me.IcoTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IcoTipo.DataPropertyName = "IcoTipo"
        Me.IcoTipo.HeaderText = ""
        Me.IcoTipo.Name = "IcoTipo"
        Me.IcoTipo.ReadOnly = True
        Me.IcoTipo.Width = 16
        '
        'Prio
        '
        Me.Prio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Prio.DataPropertyName = "QuandoStr"
        Me.Prio.HeaderText = "Quando"
        Me.Prio.MinimumWidth = 100
        Me.Prio.Name = "Prio"
        Me.Prio.ReadOnly = True
        Me.Prio.Width = 150
        '
        'IdOrdLista
        '
        Me.IdOrdLista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IdOrdLista.DataPropertyName = "ServizioStr"
        Me.IdOrdLista.HeaderText = "Servizio"
        Me.IdOrdLista.Name = "IdOrdLista"
        Me.IdOrdLista.ReadOnly = True
        Me.IdOrdLista.Width = 150
        '
        'Descrizione
        '
        Me.Descrizione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Descrizione.DataPropertyName = "Descrizione"
        Me.Descrizione.HeaderText = "Descrizione"
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.ReadOnly = True
        Me.Descrizione.Width = 91
        '
        'tpSyncronizer
        '
        Me.tpSyncronizer.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tpSyncronizer.Controls.Add(Me.txtSyncronizer)
        Me.tpSyncronizer.ImageKey = "_Aggiorna.png"
        Me.tpSyncronizer.Location = New System.Drawing.Point(4, 31)
        Me.tpSyncronizer.Name = "tpSyncronizer"
        Me.tpSyncronizer.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSyncronizer.Size = New System.Drawing.Size(973, 631)
        Me.tpSyncronizer.TabIndex = 2
        Me.tpSyncronizer.Text = "Syncronizer"
        '
        'txtSyncronizer
        '
        Me.txtSyncronizer.BackColor = System.Drawing.Color.Black
        Me.txtSyncronizer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSyncronizer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtSyncronizer.ForeColor = System.Drawing.Color.Lime
        Me.txtSyncronizer.Location = New System.Drawing.Point(3, 3)
        Me.txtSyncronizer.Multiline = True
        Me.txtSyncronizer.Name = "txtSyncronizer"
        Me.txtSyncronizer.ReadOnly = True
        Me.txtSyncronizer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSyncronizer.Size = New System.Drawing.Size(967, 625)
        Me.txtSyncronizer.TabIndex = 0
        '
        'tpService
        '
        Me.tpService.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tpService.Controls.Add(Me.txtService)
        Me.tpService.ImageKey = "_Ftp.png"
        Me.tpService.Location = New System.Drawing.Point(4, 31)
        Me.tpService.Name = "tpService"
        Me.tpService.Padding = New System.Windows.Forms.Padding(3)
        Me.tpService.Size = New System.Drawing.Size(973, 631)
        Me.tpService.TabIndex = 3
        Me.tpService.Text = "Service"
        '
        'txtService
        '
        Me.txtService.BackColor = System.Drawing.Color.Black
        Me.txtService.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtService.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtService.ForeColor = System.Drawing.Color.Red
        Me.txtService.Location = New System.Drawing.Point(3, 3)
        Me.txtService.Multiline = True
        Me.txtService.Name = "txtService"
        Me.txtService.ReadOnly = True
        Me.txtService.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtService.Size = New System.Drawing.Size(967, 625)
        Me.txtService.TabIndex = 1
        '
        'tpMessenger
        '
        Me.tpMessenger.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tpMessenger.Controls.Add(Me.txtMessenger)
        Me.tpMessenger.ImageKey = "_Mail.png"
        Me.tpMessenger.Location = New System.Drawing.Point(4, 31)
        Me.tpMessenger.Name = "tpMessenger"
        Me.tpMessenger.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMessenger.Size = New System.Drawing.Size(973, 631)
        Me.tpMessenger.TabIndex = 5
        Me.tpMessenger.Text = "Messenger"
        '
        'txtMessenger
        '
        Me.txtMessenger.BackColor = System.Drawing.Color.Black
        Me.txtMessenger.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMessenger.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtMessenger.ForeColor = System.Drawing.Color.Cyan
        Me.txtMessenger.Location = New System.Drawing.Point(3, 3)
        Me.txtMessenger.Multiline = True
        Me.txtMessenger.Name = "txtMessenger"
        Me.txtMessenger.ReadOnly = True
        Me.txtMessenger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessenger.Size = New System.Drawing.Size(967, 625)
        Me.txtMessenger.TabIndex = 1
        '
        'tpPrinter
        '
        Me.tpPrinter.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tpPrinter.Controls.Add(Me.txtPrinter)
        Me.tpPrinter.ImageKey = "_Stampa.png"
        Me.tpPrinter.Location = New System.Drawing.Point(4, 31)
        Me.tpPrinter.Name = "tpPrinter"
        Me.tpPrinter.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPrinter.Size = New System.Drawing.Size(973, 631)
        Me.tpPrinter.TabIndex = 4
        Me.tpPrinter.Text = "UDP"
        '
        'txtPrinter
        '
        Me.txtPrinter.BackColor = System.Drawing.Color.Black
        Me.txtPrinter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPrinter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrinter.ForeColor = System.Drawing.Color.White
        Me.txtPrinter.Location = New System.Drawing.Point(3, 3)
        Me.txtPrinter.Multiline = True
        Me.txtPrinter.Name = "txtPrinter"
        Me.txtPrinter.ReadOnly = True
        Me.txtPrinter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPrinter.Size = New System.Drawing.Size(967, 625)
        Me.txtPrinter.TabIndex = 1
        '
        'tpCaller
        '
        Me.tpCaller.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tpCaller.Controls.Add(Me.txtCaller)
        Me.tpCaller.ImageKey = "_ChiamataPersa.png"
        Me.tpCaller.Location = New System.Drawing.Point(4, 31)
        Me.tpCaller.Name = "tpCaller"
        Me.tpCaller.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCaller.Size = New System.Drawing.Size(973, 631)
        Me.tpCaller.TabIndex = 6
        Me.tpCaller.Text = "Caller"
        '
        'txtCaller
        '
        Me.txtCaller.BackColor = System.Drawing.Color.Black
        Me.txtCaller.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCaller.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtCaller.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCaller.Location = New System.Drawing.Point(3, 3)
        Me.txtCaller.Multiline = True
        Me.txtCaller.Name = "txtCaller"
        Me.txtCaller.ReadOnly = True
        Me.txtCaller.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCaller.Size = New System.Drawing.Size(967, 625)
        Me.txtCaller.TabIndex = 1
        '
        'tpPostazioni
        '
        Me.tpPostazioni.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tpPostazioni.Controls.Add(Me.lblLastVer)
        Me.tpPostazioni.Controls.Add(Me.lblLastCheckPostazioni)
        Me.tpPostazioni.Controls.Add(Me.btnAggiornaPostaz)
        Me.tpPostazioni.Controls.Add(Me.tvwPostazioni)
        Me.tpPostazioni.ImageKey = "_Postazione.png"
        Me.tpPostazioni.Location = New System.Drawing.Point(4, 31)
        Me.tpPostazioni.Name = "tpPostazioni"
        Me.tpPostazioni.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPostazioni.Size = New System.Drawing.Size(973, 631)
        Me.tpPostazioni.TabIndex = 7
        Me.tpPostazioni.Text = "Postazioni"
        '
        'lblLastVer
        '
        Me.lblLastVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastVer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastVer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblLastVer.Location = New System.Drawing.Point(777, 13)
        Me.lblLastVer.Name = "lblLastVer"
        Me.lblLastVer.Size = New System.Drawing.Size(188, 20)
        Me.lblLastVer.TabIndex = 8
        Me.lblLastVer.Text = "-"
        Me.lblLastVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastCheckPostazioni
        '
        Me.lblLastCheckPostazioni.AutoSize = True
        Me.lblLastCheckPostazioni.ForeColor = System.Drawing.Color.White
        Me.lblLastCheckPostazioni.Location = New System.Drawing.Point(132, 13)
        Me.lblLastCheckPostazioni.Name = "lblLastCheckPostazioni"
        Me.lblLastCheckPostazioni.Size = New System.Drawing.Size(12, 15)
        Me.lblLastCheckPostazioni.TabIndex = 7
        Me.lblLastCheckPostazioni.Text = "-"
        '
        'btnAggiornaPostaz
        '
        Me.btnAggiornaPostaz.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAggiornaPostaz.ForeColor = System.Drawing.Color.Black
        Me.btnAggiornaPostaz.Location = New System.Drawing.Point(6, 8)
        Me.btnAggiornaPostaz.Name = "btnAggiornaPostaz"
        Me.btnAggiornaPostaz.Size = New System.Drawing.Size(120, 25)
        Me.btnAggiornaPostaz.TabIndex = 6
        Me.btnAggiornaPostaz.Text = "Aggiorna"
        Me.btnAggiornaPostaz.UseVisualStyleBackColor = False
        '
        'tvwPostazioni
        '
        Me.tvwPostazioni.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwPostazioni.ImageIndex = 0
        Me.tvwPostazioni.ImageList = Me.imlTab
        Me.tvwPostazioni.Location = New System.Drawing.Point(6, 39)
        Me.tvwPostazioni.Name = "tvwPostazioni"
        Me.tvwPostazioni.SelectedImageIndex = 0
        Me.tvwPostazioni.Size = New System.Drawing.Size(961, 556)
        Me.tvwPostazioni.TabIndex = 0
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.White
        Me.imlTab.Images.SetKeyName(0, "_Step.png")
        Me.imlTab.Images.SetKeyName(1, "_Aggiorna.png")
        Me.imlTab.Images.SetKeyName(2, "_Stampa.png")
        Me.imlTab.Images.SetKeyName(3, "_Mail.png")
        Me.imlTab.Images.SetKeyName(4, "_Ftp.png")
        Me.imlTab.Images.SetKeyName(5, "_ChiamataPersa.png")
        Me.imlTab.Images.SetKeyName(6, "_Opzioni.png")
        Me.imlTab.Images.SetKeyName(7, "_Postazione.png")
        Me.imlTab.Images.SetKeyName(8, "_F.png")
        '
        'tpOpzioni
        '
        Me.tpOpzioni.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.tpOpzioni.Controls.Add(Me.GroupBox13)
        Me.tpOpzioni.Controls.Add(Me.btnTestTB)
        Me.tpOpzioni.Controls.Add(Me.GroupBox12)
        Me.tpOpzioni.Controls.Add(Me.GroupBox6)
        Me.tpOpzioni.Controls.Add(Me.btnTestGhostscript)
        Me.tpOpzioni.Controls.Add(Me.btnForzaturaOperazioni)
        Me.tpOpzioni.Controls.Add(Me.GroupBox7)
        Me.tpOpzioni.Controls.Add(Me.GroupBox8)
        Me.tpOpzioni.Controls.Add(Me.GroupBox9)
        Me.tpOpzioni.Controls.Add(Me.GroupBox10)
        Me.tpOpzioni.Controls.Add(Me.GroupBox11)
        Me.tpOpzioni.ImageKey = "_Opzioni.png"
        Me.tpOpzioni.Location = New System.Drawing.Point(4, 31)
        Me.tpOpzioni.Name = "tpOpzioni"
        Me.tpOpzioni.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOpzioni.Size = New System.Drawing.Size(973, 631)
        Me.tpOpzioni.TabIndex = 1
        Me.tpOpzioni.Text = "Opzioni"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btnRefresh)
        Me.GroupBox13.Controls.Add(Me.btnCopia)
        Me.GroupBox13.Controls.Add(Me.PictureBox11)
        Me.GroupBox13.Controls.Add(Me.cmbStampanti)
        Me.GroupBox13.ForeColor = System.Drawing.Color.White
        Me.GroupBox13.Location = New System.Drawing.Point(6, 462)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(959, 70)
        Me.GroupBox13.TabIndex = 76
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Elenco Stampanti installate nel sistema"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnRefresh.ForeColor = System.Drawing.Color.Black
        Me.btnRefresh.Location = New System.Drawing.Point(899, 24)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(54, 29)
        Me.btnRefresh.TabIndex = 78
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnCopia
        '
        Me.btnCopia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCopia.ForeColor = System.Drawing.Color.Black
        Me.btnCopia.Location = New System.Drawing.Point(844, 24)
        Me.btnCopia.Name = "btnCopia"
        Me.btnCopia.Size = New System.Drawing.Size(54, 29)
        Me.btnCopia.TabIndex = 77
        Me.btnCopia.Text = "Copia"
        Me.btnCopia.UseVisualStyleBackColor = False
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = Global.FormerDaemon_Server.My.Resources.Resources.Message1
        Me.PictureBox11.Location = New System.Drawing.Point(7, 19)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox11.TabIndex = 76
        Me.PictureBox11.TabStop = False
        '
        'cmbStampanti
        '
        Me.cmbStampanti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStampanti.FormattingEnabled = True
        Me.cmbStampanti.Location = New System.Drawing.Point(53, 24)
        Me.cmbStampanti.Name = "cmbStampanti"
        Me.cmbStampanti.Size = New System.Drawing.Size(785, 23)
        Me.cmbStampanti.TabIndex = 74
        '
        'btnTestTB
        '
        Me.btnTestTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnTestTB.ForeColor = System.Drawing.Color.Black
        Me.btnTestTB.Location = New System.Drawing.Point(321, 602)
        Me.btnTestTB.Name = "btnTestTB"
        Me.btnTestTB.Size = New System.Drawing.Size(148, 25)
        Me.btnTestTB.TabIndex = 14
        Me.btnTestTB.Text = "Test Transactionbox"
        Me.btnTestTB.UseVisualStyleBackColor = False
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.btnDisconnect)
        Me.GroupBox12.Controls.Add(Me.btnReconnect)
        Me.GroupBox12.ForeColor = System.Drawing.Color.White
        Me.GroupBox12.Location = New System.Drawing.Point(6, 538)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(959, 62)
        Me.GroupBox12.TabIndex = 13
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "DB Connection"
        '
        'btnDisconnect
        '
        Me.btnDisconnect.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnDisconnect.ForeColor = System.Drawing.Color.Black
        Me.btnDisconnect.Location = New System.Drawing.Point(198, 20)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(281, 27)
        Me.btnDisconnect.TabIndex = 1
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = False
        '
        'btnReconnect
        '
        Me.btnReconnect.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnReconnect.ForeColor = System.Drawing.Color.Black
        Me.btnReconnect.Location = New System.Drawing.Point(485, 20)
        Me.btnReconnect.Name = "btnReconnect"
        Me.btnReconnect.Size = New System.Drawing.Size(281, 27)
        Me.btnReconnect.TabIndex = 2
        Me.btnReconnect.Text = "Reconnect"
        Me.btnReconnect.UseVisualStyleBackColor = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.PictureBox2)
        Me.GroupBox6.Controls.Add(Me.btnMessage)
        Me.GroupBox6.Controls.Add(Me.txtMsg)
        Me.GroupBox6.ForeColor = System.Drawing.Color.White
        Me.GroupBox6.Location = New System.Drawing.Point(6, 386)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(959, 70)
        Me.GroupBox6.TabIndex = 12
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Messaggio Broadcast"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.FormerDaemon_Server.My.Resources.Resources.Message1
        Me.PictureBox2.Location = New System.Drawing.Point(7, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'btnMessage
        '
        Me.btnMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnMessage.ForeColor = System.Drawing.Color.Black
        Me.btnMessage.Location = New System.Drawing.Point(844, 25)
        Me.btnMessage.Name = "btnMessage"
        Me.btnMessage.Size = New System.Drawing.Size(109, 29)
        Me.btnMessage.TabIndex = 0
        Me.btnMessage.Text = "Invia"
        Me.btnMessage.UseVisualStyleBackColor = False
        '
        'txtMsg
        '
        Me.txtMsg.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtMsg.ForeColor = System.Drawing.Color.Black
        Me.txtMsg.Location = New System.Drawing.Point(53, 25)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(785, 32)
        Me.txtMsg.TabIndex = 4
        '
        'btnTestGhostscript
        '
        Me.btnTestGhostscript.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnTestGhostscript.ForeColor = System.Drawing.Color.Black
        Me.btnTestGhostscript.Location = New System.Drawing.Point(167, 602)
        Me.btnTestGhostscript.Name = "btnTestGhostscript"
        Me.btnTestGhostscript.Size = New System.Drawing.Size(148, 25)
        Me.btnTestGhostscript.TabIndex = 11
        Me.btnTestGhostscript.Text = "Test Ghostscript"
        Me.btnTestGhostscript.UseVisualStyleBackColor = False
        Me.btnTestGhostscript.Visible = False
        '
        'btnForzaturaOperazioni
        '
        Me.btnForzaturaOperazioni.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnForzaturaOperazioni.ForeColor = System.Drawing.Color.Black
        Me.btnForzaturaOperazioni.Location = New System.Drawing.Point(13, 602)
        Me.btnForzaturaOperazioni.Name = "btnForzaturaOperazioni"
        Me.btnForzaturaOperazioni.Size = New System.Drawing.Size(148, 25)
        Me.btnForzaturaOperazioni.TabIndex = 10
        Me.btnForzaturaOperazioni.Text = "Forzatura Operazioni"
        Me.btnForzaturaOperazioni.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.chkAutoStartCaller)
        Me.GroupBox7.Controls.Add(Me.PictureBox6)
        Me.GroupBox7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox7.ForeColor = System.Drawing.Color.White
        Me.GroupBox7.Location = New System.Drawing.Point(6, 310)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(959, 70)
        Me.GroupBox7.TabIndex = 9
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Caller"
        '
        'chkAutoStartCaller
        '
        Me.chkAutoStartCaller.AutoSize = True
        Me.chkAutoStartCaller.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkAutoStartCaller.Location = New System.Drawing.Point(53, 20)
        Me.chkAutoStartCaller.Name = "chkAutoStartCaller"
        Me.chkAutoStartCaller.Size = New System.Drawing.Size(120, 19)
        Me.chkAutoStartCaller.TabIndex = 4
        Me.chkAutoStartCaller.Text = "Avvio automatico"
        Me.chkAutoStartCaller.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAutoStartCaller.UseVisualStyleBackColor = True
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.FormerDaemon_Server.My.Resources.Resources._AddressBook
        Me.PictureBox6.Location = New System.Drawing.Point(7, 21)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox6.TabIndex = 0
        Me.PictureBox6.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.Controls.Add(Me.PictureBox7)
        Me.GroupBox8.Controls.Add(Me.chkAutoStartPrinter)
        Me.GroupBox8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox8.ForeColor = System.Drawing.Color.White
        Me.GroupBox8.Location = New System.Drawing.Point(6, 234)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(959, 70)
        Me.GroupBox8.TabIndex = 8
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Printer"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.FormerDaemon_Server.My.Resources.Resources.Printer
        Me.PictureBox7.Location = New System.Drawing.Point(7, 21)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox7.TabIndex = 0
        Me.PictureBox7.TabStop = False
        '
        'chkAutoStartPrinter
        '
        Me.chkAutoStartPrinter.AutoSize = True
        Me.chkAutoStartPrinter.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkAutoStartPrinter.Location = New System.Drawing.Point(53, 21)
        Me.chkAutoStartPrinter.Name = "chkAutoStartPrinter"
        Me.chkAutoStartPrinter.Size = New System.Drawing.Size(120, 19)
        Me.chkAutoStartPrinter.TabIndex = 3
        Me.chkAutoStartPrinter.Text = "Avvio automatico"
        Me.chkAutoStartPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAutoStartPrinter.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox9.Controls.Add(Me.PictureBox8)
        Me.GroupBox9.Controls.Add(Me.chkAutoStartMessenger)
        Me.GroupBox9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox9.ForeColor = System.Drawing.Color.White
        Me.GroupBox9.Location = New System.Drawing.Point(6, 158)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(959, 70)
        Me.GroupBox9.TabIndex = 7
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Messenger"
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.FormerDaemon_Server.My.Resources.Resources.Message
        Me.PictureBox8.Location = New System.Drawing.Point(7, 21)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox8.TabIndex = 0
        Me.PictureBox8.TabStop = False
        '
        'chkAutoStartMessenger
        '
        Me.chkAutoStartMessenger.AutoSize = True
        Me.chkAutoStartMessenger.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkAutoStartMessenger.Location = New System.Drawing.Point(53, 20)
        Me.chkAutoStartMessenger.Name = "chkAutoStartMessenger"
        Me.chkAutoStartMessenger.Size = New System.Drawing.Size(120, 19)
        Me.chkAutoStartMessenger.TabIndex = 2
        Me.chkAutoStartMessenger.Text = "Avvio automatico"
        Me.chkAutoStartMessenger.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAutoStartMessenger.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox10.Controls.Add(Me.PictureBox9)
        Me.GroupBox10.Controls.Add(Me.chkAutoStartService)
        Me.GroupBox10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox10.ForeColor = System.Drawing.Color.White
        Me.GroupBox10.Location = New System.Drawing.Point(6, 82)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(959, 70)
        Me.GroupBox10.TabIndex = 6
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Service"
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = Global.FormerDaemon_Server.My.Resources.Resources._TrafficCone
        Me.PictureBox9.Location = New System.Drawing.Point(7, 21)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox9.TabIndex = 0
        Me.PictureBox9.TabStop = False
        '
        'chkAutoStartService
        '
        Me.chkAutoStartService.AutoSize = True
        Me.chkAutoStartService.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkAutoStartService.Location = New System.Drawing.Point(53, 20)
        Me.chkAutoStartService.Name = "chkAutoStartService"
        Me.chkAutoStartService.Size = New System.Drawing.Size(120, 19)
        Me.chkAutoStartService.TabIndex = 1
        Me.chkAutoStartService.Text = "Avvio automatico"
        Me.chkAutoStartService.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAutoStartService.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox11.Controls.Add(Me.PictureBox10)
        Me.GroupBox11.Controls.Add(Me.chkAutoStartSyncronizer)
        Me.GroupBox11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox11.ForeColor = System.Drawing.Color.White
        Me.GroupBox11.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(959, 70)
        Me.GroupBox11.TabIndex = 5
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Syncronizer"
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = Global.FormerDaemon_Server.My.Resources.Resources._ButtonReload
        Me.PictureBox10.Location = New System.Drawing.Point(7, 21)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox10.TabIndex = 0
        Me.PictureBox10.TabStop = False
        '
        'chkAutoStartSyncronizer
        '
        Me.chkAutoStartSyncronizer.AutoSize = True
        Me.chkAutoStartSyncronizer.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkAutoStartSyncronizer.Location = New System.Drawing.Point(53, 21)
        Me.chkAutoStartSyncronizer.Name = "chkAutoStartSyncronizer"
        Me.chkAutoStartSyncronizer.Size = New System.Drawing.Size(120, 19)
        Me.chkAutoStartSyncronizer.TabIndex = 0
        Me.chkAutoStartSyncronizer.Text = "Avvio automatico"
        Me.chkAutoStartSyncronizer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAutoStartSyncronizer.UseVisualStyleBackColor = True
        '
        'statusBar
        '
        Me.statusBar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblInfo, Me.lblServerInterno, Me.lblInternet, Me.lblSitoWeb, Me.lblServerVirtuale, Me.lblProc})
        Me.statusBar.Location = New System.Drawing.Point(0, 669)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(984, 22)
        Me.statusBar.TabIndex = 2
        Me.statusBar.Text = "StatusStrip1"
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(71, 17)
        Me.lblInfo.Text = "FD - Server"
        '
        'lblServerInterno
        '
        Me.lblServerInterno.AutoToolTip = True
        Me.lblServerInterno.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblServerInterno.ForeColor = System.Drawing.Color.White
        Me.lblServerInterno.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.lblServerInterno.Name = "lblServerInterno"
        Me.lblServerInterno.Size = New System.Drawing.Size(12, 17)
        Me.lblServerInterno.Text = "-"
        '
        'lblInternet
        '
        Me.lblInternet.AutoToolTip = True
        Me.lblInternet.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblInternet.ForeColor = System.Drawing.Color.White
        Me.lblInternet.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.lblInternet.Name = "lblInternet"
        Me.lblInternet.Size = New System.Drawing.Size(12, 17)
        Me.lblInternet.Text = "-"
        '
        'lblSitoWeb
        '
        Me.lblSitoWeb.AutoToolTip = True
        Me.lblSitoWeb.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSitoWeb.ForeColor = System.Drawing.Color.White
        Me.lblSitoWeb.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.lblSitoWeb.Name = "lblSitoWeb"
        Me.lblSitoWeb.Size = New System.Drawing.Size(12, 17)
        Me.lblSitoWeb.Text = "-"
        '
        'lblServerVirtuale
        '
        Me.lblServerVirtuale.AutoToolTip = True
        Me.lblServerVirtuale.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblServerVirtuale.ForeColor = System.Drawing.Color.White
        Me.lblServerVirtuale.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.lblServerVirtuale.Name = "lblServerVirtuale"
        Me.lblServerVirtuale.Size = New System.Drawing.Size(12, 17)
        Me.lblServerVirtuale.Text = "-"
        '
        'lblProc
        '
        Me.lblProc.AutoToolTip = True
        Me.lblProc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblProc.ForeColor = System.Drawing.Color.White
        Me.lblProc.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.lblProc.Name = "lblProc"
        Me.lblProc.Size = New System.Drawing.Size(12, 17)
        Me.lblProc.Text = "-"
        '
        'tmrPostazioni
        '
        Me.tmrPostazioni.Enabled = True
        Me.tmrPostazioni.Interval = 1800000
        '
        'tmrLog
        '
        Me.tmrLog.Enabled = True
        Me.tmrLog.Interval = 300000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(984, 691)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.tabMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Former Daemon - Server"
        Me.tabMain.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tabServices.ResumeLayout(False)
        Me.tpServices.ResumeLayout(False)
        Me.tpServices.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pctServices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpServicesLog.ResumeLayout(False)
        Me.tpServicesLog.PerformLayout()
        CType(Me.DgLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSyncronizer.ResumeLayout(False)
        Me.tpSyncronizer.PerformLayout()
        Me.tpService.ResumeLayout(False)
        Me.tpService.PerformLayout()
        Me.tpMessenger.ResumeLayout(False)
        Me.tpMessenger.PerformLayout()
        Me.tpPrinter.ResumeLayout(False)
        Me.tpPrinter.PerformLayout()
        Me.tpCaller.ResumeLayout(False)
        Me.tpCaller.PerformLayout()
        Me.tpPostazioni.ResumeLayout(False)
        Me.tpPostazioni.PerformLayout()
        Me.tpOpzioni.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents tpOpzioni As System.Windows.Forms.TabPage
    Friend WithEvents statusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblInternet As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents imlTab As System.Windows.Forms.ImageList
    Friend WithEvents lblSitoWeb As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblServerVirtuale As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tpSyncronizer As System.Windows.Forms.TabPage
    Friend WithEvents tpService As System.Windows.Forms.TabPage
    Friend WithEvents tpPrinter As System.Windows.Forms.TabPage
    Friend WithEvents tpMessenger As System.Windows.Forms.TabPage
    Friend WithEvents tpCaller As System.Windows.Forms.TabPage
    Friend WithEvents txtSyncronizer As System.Windows.Forms.TextBox
    Friend WithEvents lblServerInterno As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtService As System.Windows.Forms.TextBox
    Friend WithEvents txtMessenger As System.Windows.Forms.TextBox
    Friend WithEvents txtPrinter As System.Windows.Forms.TextBox
    Friend WithEvents txtCaller As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnApriLogSyncronizer As System.Windows.Forms.Button
    Friend WithEvents btnStopSyncronizer As System.Windows.Forms.Button
    Friend WithEvents btnStartSyncronizer As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLastOpSyncronizer As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnApriLogCaller As System.Windows.Forms.Button
    Friend WithEvents btnStopCaller As System.Windows.Forms.Button
    Friend WithEvents btnStartCaller As System.Windows.Forms.Button
    Friend WithEvents lblStatoCaller As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblLastOpCaller As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnApriLogPrinter As System.Windows.Forms.Button
    Friend WithEvents btnStopPrinter As System.Windows.Forms.Button
    Friend WithEvents btnStartPrinter As System.Windows.Forms.Button
    Friend WithEvents lblStatoPrinter As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblLastOpPrinter As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnApriLogMessenger As System.Windows.Forms.Button
    Friend WithEvents btnStopMessenger As System.Windows.Forms.Button
    Friend WithEvents btnStartMessenger As System.Windows.Forms.Button
    Friend WithEvents lblStatoMessenger As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblLastOpMessenger As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnApriLogService As System.Windows.Forms.Button
    Friend WithEvents btnStopService As System.Windows.Forms.Button
    Friend WithEvents btnStartService As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLastOpService As System.Windows.Forms.Label
    Friend WithEvents pctServices As System.Windows.Forms.PictureBox
    Friend WithEvents chkAutoStartCaller As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoStartPrinter As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoStartMessenger As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoStartService As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoStartSyncronizer As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatoServTxtToHCC As System.Windows.Forms.Label
    Friend WithEvents lblStatoServCheckNewVer As System.Windows.Forms.Label
    Friend WithEvents lblStatoServOrario As System.Windows.Forms.Label
    Friend WithEvents lblProc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatoServNewOrd As System.Windows.Forms.Label
    Friend WithEvents lblStatoServSyncronizer As System.Windows.Forms.Label
    Friend WithEvents tpPostazioni As System.Windows.Forms.TabPage
    Friend WithEvents btnAggiornaPostaz As System.Windows.Forms.Button
    Friend WithEvents tvwPostazioni As System.Windows.Forms.TreeView
    Friend WithEvents lblLastCheckPostazioni As System.Windows.Forms.Label
    Friend WithEvents tmrPostazioni As System.Windows.Forms.Timer
    Friend WithEvents lblLastVer As System.Windows.Forms.Label
    Friend WithEvents btnForzaturaOperazioni As System.Windows.Forms.Button
    Friend WithEvents btnPrendiInCaricoChiamata As Button
    Friend WithEvents btnTestGhostscript As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnMessage As Button
    Friend WithEvents txtMsg As TextBox
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents btnDisconnect As Button
    Friend WithEvents btnReconnect As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents imlMain As ImageList
    Friend WithEvents btnEsegui1Messenger As Button
    Friend WithEvents btnEseguiTxtToHCC As Button
    Friend WithEvents btnEsegui1Syncronizer As Button
    Friend WithEvents tmrLog As Timer
    Friend WithEvents tabServices As TabControl
    Friend WithEvents tpServices As TabPage
    Friend WithEvents tpServicesLog As TabPage
    Friend WithEvents btnRefreshLog As Button
    Friend WithEvents DgLog As DataGridView
    Friend WithEvents btnReset As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCerca As TextBox
    Friend WithEvents IcoTipo As DataGridViewImageColumn
    Friend WithEvents Prio As DataGridViewTextBoxColumn
    Friend WithEvents IdOrdLista As DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As DataGridViewTextBoxColumn
    Friend WithEvents lnkRestartRouter As LinkLabel
    Friend WithEvents btnTestTB As Button
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents btnCopia As Button
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents cmbStampanti As ComboBox
    Friend WithEvents btnRefresh As Button
End Class
