<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMailPreventivi
    Inherits ucFormerUserControl


    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMailPreventivi))
        Me.tvwMail = New System.Windows.Forms.TreeView()
        Me.imlMail = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuPrev = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RiapriToolStripmenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlCreaOrdine = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AssegnaAClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtCercaCli = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.SegnaComeLettaToolstripmenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SegnaDaLeggereToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.StampaToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SegnaComeLavorataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SegnaDaLavorareToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EliminaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.lnkRispondi = New System.Windows.Forms.LinkLabel()
        Me.splitMail = New System.Windows.Forms.SplitContainer()
        Me.UcMailPreview = New Former.ucMailPreview()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.lnkScarica = New System.Windows.Forms.LinkLabel()
        Me.mnuAllegato = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ApriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiaPercorsoFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCercaAvanzata = New System.Windows.Forms.Button()
        Me.pnlCercaAvanzato = New System.Windows.Forms.Panel()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtDataAl = New System.Windows.Forms.DateTimePicker()
        Me.chkDataAl = New System.Windows.Forms.CheckBox()
        Me.dtDataDal = New System.Windows.Forms.DateTimePicker()
        Me.chkDataDal = New System.Windows.Forms.CheckBox()
        Me.dlgFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.mnuPrev.SuspendLayout()
        CType(Me.splitMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMail.Panel1.SuspendLayout()
        Me.splitMail.Panel2.SuspendLayout()
        Me.splitMail.SuspendLayout()
        Me.mnuAllegato.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCercaAvanzato.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvwMail
        '
        Me.tvwMail.AllowDrop = True
        Me.tvwMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwMail.ImageIndex = 0
        Me.tvwMail.ImageList = Me.imlMail
        Me.tvwMail.ItemHeight = 22
        Me.tvwMail.Location = New System.Drawing.Point(0, 0)
        Me.tvwMail.Name = "tvwMail"
        Me.tvwMail.SelectedImageIndex = 0
        Me.tvwMail.Size = New System.Drawing.Size(723, 499)
        Me.tvwMail.TabIndex = 0
        '
        'imlMail
        '
        Me.imlMail.ImageStream = CType(resources.GetObject("imlMail.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMail.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMail.Images.SetKeyName(0, "ico_CL_R.png")
        Me.imlMail.Images.SetKeyName(1, "ico_F_R.png")
        Me.imlMail.Images.SetKeyName(2, "ico_DL_R.png")
        Me.imlMail.Images.SetKeyName(3, "ico_LV_R.png")
        Me.imlMail.Images.SetKeyName(4, "_Allega.png")
        Me.imlMail.Images.SetKeyName(5, "_Elimina.png")
        Me.imlMail.Images.SetKeyName(6, "_Calendario.png")
        Me.imlMail.Images.SetKeyName(7, "ico_1_R.png")
        Me.imlMail.Images.SetKeyName(8, "ico_2_R.png")
        Me.imlMail.Images.SetKeyName(9, "ico_3_R.png")
        Me.imlMail.Images.SetKeyName(10, "ico_4_R.png")
        Me.imlMail.Images.SetKeyName(11, "ico_5_R.png")
        Me.imlMail.Images.SetKeyName(12, "ico_6_R.png")
        Me.imlMail.Images.SetKeyName(13, "ico_7_R.png")
        Me.imlMail.Images.SetKeyName(14, "ico_8_R.png")
        Me.imlMail.Images.SetKeyName(15, "ico_9_R.png")
        Me.imlMail.Images.SetKeyName(16, "ico_10_R.png")
        Me.imlMail.Images.SetKeyName(17, "ico_11_R.png")
        Me.imlMail.Images.SetKeyName(18, "ico_12_R.png")
        Me.imlMail.Images.SetKeyName(19, "ico_13_R.png")
        Me.imlMail.Images.SetKeyName(20, "ico_14_R.png")
        Me.imlMail.Images.SetKeyName(21, "ico_15_R.png")
        Me.imlMail.Images.SetKeyName(22, "ico_16_R.png")
        Me.imlMail.Images.SetKeyName(23, "ico_17_R.png")
        Me.imlMail.Images.SetKeyName(24, "ico_18_R.png")
        Me.imlMail.Images.SetKeyName(25, "ico_19_R.png")
        Me.imlMail.Images.SetKeyName(26, "ico_20_R.png")
        Me.imlMail.Images.SetKeyName(27, "ico_21_R.png")
        Me.imlMail.Images.SetKeyName(28, "ico_22_R.png")
        Me.imlMail.Images.SetKeyName(29, "ico_23_R.png")
        Me.imlMail.Images.SetKeyName(30, "ico_24_R.png")
        Me.imlMail.Images.SetKeyName(31, "ico_25_R.png")
        Me.imlMail.Images.SetKeyName(32, "ico_26_R.png")
        Me.imlMail.Images.SetKeyName(33, "ico_27_R.png")
        Me.imlMail.Images.SetKeyName(34, "ico_28_R.png")
        Me.imlMail.Images.SetKeyName(35, "ico_29_R.png")
        Me.imlMail.Images.SetKeyName(36, "ico_30_R.png")
        Me.imlMail.Images.SetKeyName(37, "ico_31_R.png")
        '
        'mnuPrev
        '
        Me.mnuPrev.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RiapriToolStripmenu, Me.tlCreaOrdine, Me.ToolStripSeparator4, Me.AssegnaAClienteToolStripMenuItem, Me.ToolStripSeparator6, Me.SegnaComeLettaToolstripmenu, Me.SegnaDaLeggereToolStripMenuItem, Me.ToolStripSeparator5, Me.StampaToolStripMenu, Me.ToolStripSeparator1, Me.SegnaComeLavorataToolStripMenuItem, Me.SegnaDaLavorareToolStripMenu, Me.ToolStripSeparator2, Me.EliminaToolStripMenuItem})
        Me.mnuPrev.Name = "mnuPrev"
        Me.mnuPrev.Size = New System.Drawing.Size(188, 232)
        '
        'RiapriToolStripmenu
        '
        Me.RiapriToolStripmenu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RiapriToolStripmenu.Image = Global.Former.My.Resources.Resources.reply
        Me.RiapriToolStripmenu.Name = "RiapriToolStripmenu"
        Me.RiapriToolStripmenu.Size = New System.Drawing.Size(187, 22)
        Me.RiapriToolStripmenu.Text = "Rispondi"
        '
        'tlCreaOrdine
        '
        Me.tlCreaOrdine.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tlCreaOrdine.Image = Global.Former.My.Resources.Resources._Ordine
        Me.tlCreaOrdine.Name = "tlCreaOrdine"
        Me.tlCreaOrdine.Size = New System.Drawing.Size(187, 22)
        Me.tlCreaOrdine.Text = "Crea Ordine"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(184, 6)
        '
        'AssegnaAClienteToolStripMenuItem
        '
        Me.AssegnaAClienteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtCercaCli})
        Me.AssegnaAClienteToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.AssegnaAClienteToolStripMenuItem.Name = "AssegnaAClienteToolStripMenuItem"
        Me.AssegnaAClienteToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.AssegnaAClienteToolStripMenuItem.Text = "Assegna a Cliente"
        '
        'txtCercaCli
        '
        Me.txtCercaCli.Name = "txtCercaCli"
        Me.txtCercaCli.Size = New System.Drawing.Size(100, 23)
        Me.txtCercaCli.ToolTipText = "Cerca un cliente tra quelli in rubrica. Scrivi almeno 4 caratteri"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(184, 6)
        '
        'SegnaComeLettaToolstripmenu
        '
        Me.SegnaComeLettaToolstripmenu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SegnaComeLettaToolstripmenu.Name = "SegnaComeLettaToolstripmenu"
        Me.SegnaComeLettaToolstripmenu.Size = New System.Drawing.Size(187, 22)
        Me.SegnaComeLettaToolstripmenu.Text = "Segna come letta"
        '
        'SegnaDaLeggereToolStripMenuItem
        '
        Me.SegnaDaLeggereToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SegnaDaLeggereToolStripMenuItem.Name = "SegnaDaLeggereToolStripMenuItem"
        Me.SegnaDaLeggereToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.SegnaDaLeggereToolStripMenuItem.Text = "Segna da leggere"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(184, 6)
        '
        'StampaToolStripMenu
        '
        Me.StampaToolStripMenu.Name = "StampaToolStripMenu"
        Me.StampaToolStripMenu.Size = New System.Drawing.Size(187, 22)
        Me.StampaToolStripMenu.Text = "Stampa"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
        '
        'SegnaComeLavorataToolStripMenuItem
        '
        Me.SegnaComeLavorataToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SegnaComeLavorataToolStripMenuItem.Image = Global.Former.My.Resources.Resources.Actions20_19
        Me.SegnaComeLavorataToolStripMenuItem.Name = "SegnaComeLavorataToolStripMenuItem"
        Me.SegnaComeLavorataToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.SegnaComeLavorataToolStripMenuItem.Text = "Segna come Lavorata"
        '
        'SegnaDaLavorareToolStripMenu
        '
        Me.SegnaDaLavorareToolStripMenu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SegnaDaLavorareToolStripMenu.Name = "SegnaDaLavorareToolStripMenu"
        Me.SegnaDaLavorareToolStripMenu.Size = New System.Drawing.Size(187, 22)
        Me.SegnaDaLavorareToolStripMenu.Text = "Segna da Lavorare"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(184, 6)
        '
        'EliminaToolStripMenuItem
        '
        Me.EliminaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.EliminaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Elimina
        Me.EliminaToolStripMenuItem.Name = "EliminaToolStripMenuItem"
        Me.EliminaToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.EliminaToolStripMenuItem.Text = "Elimina"
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(3, 3)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(98, 32)
        Me.lnkAggiorna.TabIndex = 50
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Mostra tutto"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkRispondi
        '
        Me.lnkRispondi.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkRispondi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRispondi.Image = Global.Former.My.Resources.Resources.ico_F_R1
        Me.lnkRispondi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRispondi.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRispondi.Location = New System.Drawing.Point(107, 3)
        Me.lnkRispondi.Name = "lnkRispondi"
        Me.lnkRispondi.Size = New System.Drawing.Size(85, 32)
        Me.lnkRispondi.TabIndex = 55
        Me.lnkRispondi.TabStop = True
        Me.lnkRispondi.Text = "Rispondi"
        Me.lnkRispondi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'splitMail
        '
        Me.splitMail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitMail.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitMail.Location = New System.Drawing.Point(6, 38)
        Me.splitMail.Name = "splitMail"
        '
        'splitMail.Panel1
        '
        Me.splitMail.Panel1.Controls.Add(Me.tvwMail)
        '
        'splitMail.Panel2
        '
        Me.splitMail.Panel2.Controls.Add(Me.UcMailPreview)
        Me.splitMail.Size = New System.Drawing.Size(1170, 499)
        Me.splitMail.SplitterDistance = 723
        Me.splitMail.TabIndex = 56
        '
        'UcMailPreview
        '
        Me.UcMailPreview.BackColor = System.Drawing.Color.White
        Me.UcMailPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMailPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMailPreview.Location = New System.Drawing.Point(0, 0)
        Me.UcMailPreview.Name = "UcMailPreview"
        Me.UcMailPreview.Size = New System.Drawing.Size(443, 499)
        Me.UcMailPreview.TabIndex = 1
        '
        'txtCerca
        '
        Me.txtCerca.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtCerca.Location = New System.Drawing.Point(457, 7)
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(255, 27)
        Me.txtCerca.TabIndex = 57
        Me.toolTipHelp.SetToolTip(Me.txtCerca, "Cerca in tutte le mail, nei nomi dei file e nel nominativo del mittente (inserire" &
        " almeno 3 caratteri)")
        '
        'lnkScarica
        '
        Me.lnkScarica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkScarica.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkScarica.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkScarica.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkScarica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkScarica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkScarica.Location = New System.Drawing.Point(1097, 3)
        Me.lnkScarica.Name = "lnkScarica"
        Me.lnkScarica.Size = New System.Drawing.Size(79, 32)
        Me.lnkScarica.TabIndex = 59
        Me.lnkScarica.TabStop = True
        Me.lnkScarica.Text = "Stampa"
        Me.lnkScarica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mnuAllegato
        '
        Me.mnuAllegato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuAllegato.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApriToolStripMenuItem, Me.ToolStripSeparator3, Me.CopiaToolStripMenuItem, Me.CopiaPercorsoFileToolStripMenuItem})
        Me.mnuAllegato.Name = "mnuAllegato"
        Me.mnuAllegato.Size = New System.Drawing.Size(174, 76)
        '
        'ApriToolStripMenuItem
        '
        Me.ApriToolStripMenuItem.Name = "ApriToolStripMenuItem"
        Me.ApriToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ApriToolStripMenuItem.Text = "Apri"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(170, 6)
        '
        'CopiaToolStripMenuItem
        '
        Me.CopiaToolStripMenuItem.Name = "CopiaToolStripMenuItem"
        Me.CopiaToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CopiaToolStripMenuItem.Text = "Copia file"
        '
        'CopiaPercorsoFileToolStripMenuItem
        '
        Me.CopiaPercorsoFileToolStripMenuItem.Name = "CopiaPercorsoFileToolStripMenuItem"
        Me.CopiaPercorsoFileToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CopiaPercorsoFileToolStripMenuItem.Text = "Copia percorso file"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Cerca
        Me.PictureBox1.Location = New System.Drawing.Point(425, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 60
        Me.PictureBox1.TabStop = False
        '
        'btnCercaAvanzata
        '
        Me.btnCercaAvanzata.Location = New System.Drawing.Point(712, 6)
        Me.btnCercaAvanzata.Name = "btnCercaAvanzata"
        Me.btnCercaAvanzata.Size = New System.Drawing.Size(17, 26)
        Me.btnCercaAvanzata.TabIndex = 61
        Me.btnCercaAvanzata.Text = "▼"
        Me.btnCercaAvanzata.UseVisualStyleBackColor = True
        '
        'pnlCercaAvanzato
        '
        Me.pnlCercaAvanzato.BackColor = System.Drawing.SystemColors.Control
        Me.pnlCercaAvanzato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCercaAvanzato.Controls.Add(Me.lnkCerca)
        Me.pnlCercaAvanzato.Controls.Add(Me.Label2)
        Me.pnlCercaAvanzato.Controls.Add(Me.dtDataAl)
        Me.pnlCercaAvanzato.Controls.Add(Me.chkDataAl)
        Me.pnlCercaAvanzato.Controls.Add(Me.dtDataDal)
        Me.pnlCercaAvanzato.Controls.Add(Me.chkDataDal)
        Me.pnlCercaAvanzato.Location = New System.Drawing.Point(425, 31)
        Me.pnlCercaAvanzato.Name = "pnlCercaAvanzato"
        Me.pnlCercaAvanzato.Size = New System.Drawing.Size(303, 154)
        Me.pnlCercaAvanzato.TabIndex = 1
        Me.pnlCercaAvanzato.Visible = False
        '
        'lnkCerca
        '
        Me.lnkCerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkCerca.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(215, 108)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(70, 32)
        Me.lnkCerca.TabIndex = 56
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Cerca"
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(5, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ricerca Avanzata"
        '
        'dtDataAl
        '
        Me.dtDataAl.Location = New System.Drawing.Point(72, 71)
        Me.dtDataAl.Name = "dtDataAl"
        Me.dtDataAl.Size = New System.Drawing.Size(200, 23)
        Me.dtDataAl.TabIndex = 3
        '
        'chkDataAl
        '
        Me.chkDataAl.AutoSize = True
        Me.chkDataAl.Location = New System.Drawing.Point(21, 73)
        Me.chkDataAl.Name = "chkDataAl"
        Me.chkDataAl.Size = New System.Drawing.Size(37, 19)
        Me.chkDataAl.TabIndex = 2
        Me.chkDataAl.Text = "Al"
        Me.chkDataAl.UseVisualStyleBackColor = True
        '
        'dtDataDal
        '
        Me.dtDataDal.Location = New System.Drawing.Point(72, 41)
        Me.dtDataDal.Name = "dtDataDal"
        Me.dtDataDal.Size = New System.Drawing.Size(200, 23)
        Me.dtDataDal.TabIndex = 1
        '
        'chkDataDal
        '
        Me.chkDataDal.AutoSize = True
        Me.chkDataDal.Location = New System.Drawing.Point(21, 43)
        Me.chkDataDal.Name = "chkDataDal"
        Me.chkDataDal.Size = New System.Drawing.Size(43, 19)
        Me.chkDataDal.TabIndex = 0
        Me.chkDataDal.Text = "Dal"
        Me.chkDataDal.UseVisualStyleBackColor = True
        '
        'ucMailPreventivi
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Controls.Add(Me.pnlCercaAvanzato)
        Me.Controls.Add(Me.btnCercaAvanzata)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lnkScarica)
        Me.Controls.Add(Me.txtCerca)
        Me.Controls.Add(Me.splitMail)
        Me.Controls.Add(Me.lnkRispondi)
        Me.Controls.Add(Me.lnkAggiorna)
        Me.Name = "ucMailPreventivi"
        Me.Size = New System.Drawing.Size(1179, 540)
        Me.mnuPrev.ResumeLayout(False)
        Me.splitMail.Panel1.ResumeLayout(False)
        Me.splitMail.Panel2.ResumeLayout(False)
        CType(Me.splitMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMail.ResumeLayout(False)
        Me.mnuAllegato.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCercaAvanzato.ResumeLayout(False)
        Me.pnlCercaAvanzato.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tvwMail As TreeView
    Friend WithEvents lnkAggiorna As LinkLabel
    Friend WithEvents imlMail As ImageList
    Friend WithEvents lnkRispondi As LinkLabel
    Friend WithEvents mnuPrev As ContextMenuStrip
    Friend WithEvents SegnaDaLeggereToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssegnaAClienteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents EliminaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents splitMail As SplitContainer
    Friend WithEvents txtCerca As TextBox
    Friend WithEvents lnkScarica As LinkLabel
    Friend WithEvents SegnaComeLavorataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SegnaDaLavorareToolStripMenu As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuAllegato As ContextMenuStrip
    Friend WithEvents ApriToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents CopiaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RiapriToolStripmenu As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents CopiaPercorsoFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtCercaCli As ToolStripTextBox
    Friend WithEvents btnCercaAvanzata As Button
    Friend WithEvents pnlCercaAvanzato As Panel
    Friend WithEvents dtDataAl As DateTimePicker
    Friend WithEvents chkDataAl As CheckBox
    Friend WithEvents dtDataDal As DateTimePicker
    Friend WithEvents chkDataDal As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lnkCerca As LinkLabel
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents StampaToolStripMenu As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents SegnaComeLettaToolstripmenu As ToolStripMenuItem
    Friend WithEvents dlgFolder As FolderBrowserDialog
    Friend WithEvents tlCreaOrdine As ToolStripMenuItem
    Friend WithEvents UcMailPreview As ucMailPreview
End Class
