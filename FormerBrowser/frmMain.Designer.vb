<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tpOpzioni = New System.Windows.Forms.TabPage()
        Me.tpNewTab = New System.Windows.Forms.TabPage()
        Me.imlMain = New System.Windows.Forms.ImageList(Me.components)
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.tabSchede = New System.Windows.Forms.TabControl()
        Me.tpScheda = New System.Windows.Forms.TabPage()
        Me.splitScheda = New System.Windows.Forms.SplitContainer()
        Me.pnlScheda = New System.Windows.Forms.Panel()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblLastUpd = New System.Windows.Forms.Label()
        Me.chkLavorato = New System.Windows.Forms.CheckBox()
        Me.txtCap = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAddCat = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.cmbCat = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.txtCitta = New System.Windows.Forms.TextBox()
        Me.txtIndirizzo = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtSito = New System.Windows.Forms.TextBox()
        Me.txtNomeAz = New System.Windows.Forms.TextBox()
        Me.pnlFiltri = New System.Windows.Forms.Panel()
        Me.chkSoloLavorati = New System.Windows.Forms.CheckBox()
        Me.cmbFindCat = New System.Windows.Forms.ComboBox()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.lblTot = New System.Windows.Forms.Label()
        Me.chkSoloDaLav = New System.Windows.Forms.CheckBox()
        Me.dgSchede = New System.Windows.Forms.DataGridView()
        Me.NomeAzienda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Indirizzo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Citta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Categoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataAcquisiz = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuLista = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CercaToolStripMenuItem = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripMostraTutti = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabMain.SuspendLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.tabSchede.SuspendLayout()
        Me.tpScheda.SuspendLayout()
        CType(Me.splitScheda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitScheda.Panel1.SuspendLayout()
        Me.splitScheda.Panel2.SuspendLayout()
        Me.splitScheda.SuspendLayout()
        Me.pnlScheda.SuspendLayout()
        Me.pnlFiltri.SuspendLayout()
        CType(Me.dgSchede, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuLista.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tpOpzioni)
        Me.tabMain.Controls.Add(Me.tpNewTab)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.HotTrack = True
        Me.tabMain.ImageList = Me.imlMain
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.ShowToolTips = True
        Me.tabMain.Size = New System.Drawing.Size(858, 731)
        Me.tabMain.TabIndex = 4
        '
        'tpOpzioni
        '
        Me.tpOpzioni.ImageKey = "Settings-&-Info20-2.png"
        Me.tpOpzioni.Location = New System.Drawing.Point(4, 28)
        Me.tpOpzioni.Name = "tpOpzioni"
        Me.tpOpzioni.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOpzioni.Size = New System.Drawing.Size(850, 699)
        Me.tpOpzioni.TabIndex = 1
        Me.tpOpzioni.Tag = "F"
        Me.tpOpzioni.Text = "Opzioni"
        Me.tpOpzioni.UseVisualStyleBackColor = True
        '
        'tpNewTab
        '
        Me.tpNewTab.ImageKey = "Symbols20-5.png"
        Me.tpNewTab.Location = New System.Drawing.Point(4, 28)
        Me.tpNewTab.Name = "tpNewTab"
        Me.tpNewTab.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNewTab.Size = New System.Drawing.Size(854, 699)
        Me.tpNewTab.TabIndex = 2
        Me.tpNewTab.Tag = "F"
        Me.tpNewTab.UseVisualStyleBackColor = True
        '
        'imlMain
        '
        Me.imlMain.ImageStream = CType(resources.GetObject("imlMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMain.Images.SetKeyName(0, "Symbols20-5.png")
        Me.imlMain.Images.SetKeyName(1, "Settings-&-Info20-2.png")
        Me.imlMain.Images.SetKeyName(2, "Localisation20-2.png")
        Me.imlMain.Images.SetKeyName(3, "Default-Tab-Bar-Icon20-9.png")
        '
        'splitMain
        '
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitMain.Location = New System.Drawing.Point(0, 0)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.Controls.Add(Me.tabMain)
        Me.splitMain.Panel1MinSize = 300
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.tabSchede)
        Me.splitMain.Panel2MinSize = 300
        Me.splitMain.Size = New System.Drawing.Size(1403, 731)
        Me.splitMain.SplitterDistance = 858
        Me.splitMain.SplitterWidth = 8
        Me.splitMain.TabIndex = 5
        '
        'tabSchede
        '
        Me.tabSchede.Controls.Add(Me.tpScheda)
        Me.tabSchede.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabSchede.ImageList = Me.imlMain
        Me.tabSchede.Location = New System.Drawing.Point(0, 0)
        Me.tabSchede.Name = "tabSchede"
        Me.tabSchede.SelectedIndex = 0
        Me.tabSchede.Size = New System.Drawing.Size(537, 731)
        Me.tabSchede.TabIndex = 0
        '
        'tpScheda
        '
        Me.tpScheda.Controls.Add(Me.splitScheda)
        Me.tpScheda.ImageIndex = 3
        Me.tpScheda.Location = New System.Drawing.Point(4, 28)
        Me.tpScheda.Name = "tpScheda"
        Me.tpScheda.Padding = New System.Windows.Forms.Padding(3)
        Me.tpScheda.Size = New System.Drawing.Size(529, 699)
        Me.tpScheda.TabIndex = 0
        Me.tpScheda.Text = "Scheda"
        Me.tpScheda.UseVisualStyleBackColor = True
        '
        'splitScheda
        '
        Me.splitScheda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitScheda.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitScheda.Location = New System.Drawing.Point(3, 3)
        Me.splitScheda.Name = "splitScheda"
        Me.splitScheda.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitScheda.Panel1
        '
        Me.splitScheda.Panel1.Controls.Add(Me.pnlScheda)
        Me.splitScheda.Panel1MinSize = 100
        '
        'splitScheda.Panel2
        '
        Me.splitScheda.Panel2.Controls.Add(Me.pnlFiltri)
        Me.splitScheda.Panel2.Controls.Add(Me.dgSchede)
        Me.splitScheda.Panel2MinSize = 100
        Me.splitScheda.Size = New System.Drawing.Size(523, 693)
        Me.splitScheda.SplitterDistance = 370
        Me.splitScheda.SplitterWidth = 8
        Me.splitScheda.TabIndex = 2
        '
        'pnlScheda
        '
        Me.pnlScheda.Controls.Add(Me.cmbTipo)
        Me.pnlScheda.Controls.Add(Me.Label11)
        Me.pnlScheda.Controls.Add(Me.lblLastUpd)
        Me.pnlScheda.Controls.Add(Me.chkLavorato)
        Me.pnlScheda.Controls.Add(Me.txtCap)
        Me.pnlScheda.Controls.Add(Me.Label10)
        Me.pnlScheda.Controls.Add(Me.Label1)
        Me.pnlScheda.Controls.Add(Me.btnDel)
        Me.pnlScheda.Controls.Add(Me.Label9)
        Me.pnlScheda.Controls.Add(Me.btnAddCat)
        Me.pnlScheda.Controls.Add(Me.btnSave)
        Me.pnlScheda.Controls.Add(Me.btnNew)
        Me.pnlScheda.Controls.Add(Me.cmbCat)
        Me.pnlScheda.Controls.Add(Me.Label8)
        Me.pnlScheda.Controls.Add(Me.Label7)
        Me.pnlScheda.Controls.Add(Me.Label6)
        Me.pnlScheda.Controls.Add(Me.Label5)
        Me.pnlScheda.Controls.Add(Me.Label4)
        Me.pnlScheda.Controls.Add(Me.Label3)
        Me.pnlScheda.Controls.Add(Me.Label2)
        Me.pnlScheda.Controls.Add(Me.txtNote)
        Me.pnlScheda.Controls.Add(Me.txtFax)
        Me.pnlScheda.Controls.Add(Me.txtTel)
        Me.pnlScheda.Controls.Add(Me.txtCitta)
        Me.pnlScheda.Controls.Add(Me.txtIndirizzo)
        Me.pnlScheda.Controls.Add(Me.txtEmail)
        Me.pnlScheda.Controls.Add(Me.txtSito)
        Me.pnlScheda.Controls.Add(Me.txtNomeAz)
        Me.pnlScheda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlScheda.Location = New System.Drawing.Point(0, 0)
        Me.pnlScheda.Name = "pnlScheda"
        Me.pnlScheda.Size = New System.Drawing.Size(523, 370)
        Me.pnlScheda.TabIndex = 0
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(97, 191)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(176, 23)
        Me.cmbTipo.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 194)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 15)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Tipo"
        '
        'lblLastUpd
        '
        Me.lblLastUpd.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblLastUpd.Location = New System.Drawing.Point(337, 349)
        Me.lblLastUpd.Name = "lblLastUpd"
        Me.lblLastUpd.Size = New System.Drawing.Size(160, 15)
        Me.lblLastUpd.TabIndex = 24
        Me.lblLastUpd.Text = "-"
        Me.lblLastUpd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkLavorato
        '
        Me.chkLavorato.AutoSize = True
        Me.chkLavorato.Location = New System.Drawing.Point(97, 348)
        Me.chkLavorato.Name = "chkLavorato"
        Me.chkLavorato.Size = New System.Drawing.Size(146, 19)
        Me.chkLavorato.TabIndex = 23
        Me.chkLavorato.Text = "Segna come Lavorato"
        Me.chkLavorato.UseVisualStyleBackColor = True
        '
        'txtCap
        '
        Me.txtCap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCap.Location = New System.Drawing.Point(451, 138)
        Me.txtCap.MaxLength = 255
        Me.txtCap.Name = "txtCap"
        Me.txtCap.Size = New System.Drawing.Size(67, 21)
        Me.txtCap.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(414, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 15)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "CAP"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(6, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Nome Azienda"
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.FlatAppearance.BorderSize = 0
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.Image = Global.FormerBrowser.My.Resources.Resources.Default_Tool_Bar20_4
        Me.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDel.Location = New System.Drawing.Point(434, 3)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(83, 21)
        Me.btnDel.TabIndex = 19
        Me.btnDel.Text = "Elimina"
        Me.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 222)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Categoria"
        '
        'btnAddCat
        '
        Me.btnAddCat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCat.FlatAppearance.BorderSize = 0
        Me.btnAddCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddCat.Image = Global.FormerBrowser.My.Resources.Resources.Default_Tool_Bar20_6
        Me.btnAddCat.Location = New System.Drawing.Point(492, 219)
        Me.btnAddCat.Name = "btnAddCat"
        Me.btnAddCat.Size = New System.Drawing.Size(25, 21)
        Me.btnAddCat.TabIndex = 17
        Me.btnAddCat.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Image = Global.FormerBrowser.My.Resources.Resources.Default_Tool_Bar20_1
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(357, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(71, 21)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Salva"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.FlatAppearance.BorderSize = 0
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNew.Image = Global.FormerBrowser.My.Resources.Resources.Default_Tool_Bar20_6
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(276, 3)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 21)
        Me.btnNew.TabIndex = 9
        Me.btnNew.Text = "Nuovo"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'cmbCat
        '
        Me.cmbCat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(97, 219)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(389, 23)
        Me.cmbCat.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Annotazioni"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(310, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Fax"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Città"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Telefono"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Indirizzo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Email"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Sito"
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Location = New System.Drawing.Point(97, 248)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(420, 94)
        Me.txtNote.TabIndex = 8
        '
        'txtFax
        '
        Me.txtFax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFax.Location = New System.Drawing.Point(342, 165)
        Me.txtFax.MaxLength = 255
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(176, 21)
        Me.txtFax.TabIndex = 6
        '
        'txtTel
        '
        Me.txtTel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTel.Location = New System.Drawing.Point(97, 165)
        Me.txtTel.MaxLength = 255
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(180, 21)
        Me.txtTel.TabIndex = 5
        '
        'txtCitta
        '
        Me.txtCitta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCitta.Location = New System.Drawing.Point(97, 138)
        Me.txtCitta.MaxLength = 255
        Me.txtCitta.Name = "txtCitta"
        Me.txtCitta.Size = New System.Drawing.Size(315, 21)
        Me.txtCitta.TabIndex = 4
        '
        'txtIndirizzo
        '
        Me.txtIndirizzo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIndirizzo.Location = New System.Drawing.Point(97, 111)
        Me.txtIndirizzo.MaxLength = 255
        Me.txtIndirizzo.Name = "txtIndirizzo"
        Me.txtIndirizzo.Size = New System.Drawing.Size(420, 21)
        Me.txtIndirizzo.TabIndex = 3
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.Location = New System.Drawing.Point(97, 84)
        Me.txtEmail.MaxLength = 255
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(420, 21)
        Me.txtEmail.TabIndex = 2
        '
        'txtSito
        '
        Me.txtSito.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSito.Location = New System.Drawing.Point(97, 57)
        Me.txtSito.MaxLength = 255
        Me.txtSito.Name = "txtSito"
        Me.txtSito.Size = New System.Drawing.Size(420, 21)
        Me.txtSito.TabIndex = 1
        '
        'txtNomeAz
        '
        Me.txtNomeAz.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNomeAz.Location = New System.Drawing.Point(97, 30)
        Me.txtNomeAz.MaxLength = 255
        Me.txtNomeAz.Name = "txtNomeAz"
        Me.txtNomeAz.Size = New System.Drawing.Size(420, 21)
        Me.txtNomeAz.TabIndex = 0
        '
        'pnlFiltri
        '
        Me.pnlFiltri.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.pnlFiltri.Controls.Add(Me.chkSoloLavorati)
        Me.pnlFiltri.Controls.Add(Me.cmbFindCat)
        Me.pnlFiltri.Controls.Add(Me.lnkAggiorna)
        Me.pnlFiltri.Controls.Add(Me.lblTot)
        Me.pnlFiltri.Controls.Add(Me.chkSoloDaLav)
        Me.pnlFiltri.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltri.Location = New System.Drawing.Point(0, 0)
        Me.pnlFiltri.Name = "pnlFiltri"
        Me.pnlFiltri.Size = New System.Drawing.Size(523, 27)
        Me.pnlFiltri.TabIndex = 2
        '
        'chkSoloLavorati
        '
        Me.chkSoloLavorati.AutoSize = True
        Me.chkSoloLavorati.Location = New System.Drawing.Point(194, 6)
        Me.chkSoloLavorati.Name = "chkSoloLavorati"
        Me.chkSoloLavorati.Size = New System.Drawing.Size(69, 19)
        Me.chkSoloLavorati.TabIndex = 9
        Me.chkSoloLavorati.Text = "Lavorati"
        Me.chkSoloLavorati.UseVisualStyleBackColor = True
        '
        'cmbFindCat
        '
        Me.cmbFindCat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFindCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFindCat.FormattingEnabled = True
        Me.cmbFindCat.Location = New System.Drawing.Point(318, 2)
        Me.cmbFindCat.Name = "cmbFindCat"
        Me.cmbFindCat.Size = New System.Drawing.Size(142, 23)
        Me.cmbFindCat.TabIndex = 8
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.ForeColor = System.Drawing.Color.Black
        Me.lnkAggiorna.Image = Global.FormerBrowser.My.Resources.Resources.Default_Tool_Bar20_7
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.Black
        Me.lnkAggiorna.Location = New System.Drawing.Point(6, 4)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(81, 21)
        Me.lnkAggiorna.TabIndex = 3
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTot
        '
        Me.lblTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTot.Location = New System.Drawing.Point(466, 6)
        Me.lblTot.Name = "lblTot"
        Me.lblTot.Size = New System.Drawing.Size(45, 13)
        Me.lblTot.TabIndex = 2
        Me.lblTot.Text = "-"
        Me.lblTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkSoloDaLav
        '
        Me.chkSoloDaLav.AutoSize = True
        Me.chkSoloDaLav.Location = New System.Drawing.Point(95, 6)
        Me.chkSoloDaLav.Name = "chkSoloDaLav"
        Me.chkSoloDaLav.Size = New System.Drawing.Size(93, 19)
        Me.chkSoloDaLav.TabIndex = 1
        Me.chkSoloDaLav.Text = "Da Lavorare"
        Me.chkSoloDaLav.UseVisualStyleBackColor = True
        '
        'dgSchede
        '
        Me.dgSchede.AllowUserToAddRows = False
        Me.dgSchede.AllowUserToDeleteRows = False
        Me.dgSchede.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSchede.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgSchede.BackgroundColor = System.Drawing.Color.White
        Me.dgSchede.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgSchede.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSchede.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomeAzienda, Me.Sito, Me.Email, Me.Indirizzo, Me.Citta, Me.Telefono, Me.Fax, Me.Categoria, Me.DataAcquisiz})
        Me.dgSchede.ContextMenuStrip = Me.MenuLista
        Me.dgSchede.Location = New System.Drawing.Point(0, 30)
        Me.dgSchede.MultiSelect = False
        Me.dgSchede.Name = "dgSchede"
        Me.dgSchede.ReadOnly = True
        Me.dgSchede.RowHeadersVisible = False
        Me.dgSchede.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSchede.Size = New System.Drawing.Size(519, 257)
        Me.dgSchede.TabIndex = 1
        '
        'NomeAzienda
        '
        Me.NomeAzienda.DataPropertyName = "NomeAzienda"
        Me.NomeAzienda.Frozen = True
        Me.NomeAzienda.HeaderText = "Azienda"
        Me.NomeAzienda.Name = "NomeAzienda"
        Me.NomeAzienda.ReadOnly = True
        Me.NomeAzienda.Width = 75
        '
        'Sito
        '
        Me.Sito.DataPropertyName = "Sito"
        Me.Sito.HeaderText = "Sito"
        Me.Sito.Name = "Sito"
        Me.Sito.ReadOnly = True
        Me.Sito.Width = 53
        '
        'Email
        '
        Me.Email.DataPropertyName = "Email"
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 64
        '
        'Indirizzo
        '
        Me.Indirizzo.DataPropertyName = "indirizzo"
        Me.Indirizzo.HeaderText = "Indirizzo"
        Me.Indirizzo.Name = "Indirizzo"
        Me.Indirizzo.ReadOnly = True
        Me.Indirizzo.Width = 76
        '
        'Citta
        '
        Me.Citta.DataPropertyName = "citta"
        Me.Citta.HeaderText = "Citta"
        Me.Citta.Name = "Citta"
        Me.Citta.ReadOnly = True
        Me.Citta.Width = 57
        '
        'Telefono
        '
        Me.Telefono.DataPropertyName = "telefono"
        Me.Telefono.HeaderText = "Telefono"
        Me.Telefono.Name = "Telefono"
        Me.Telefono.ReadOnly = True
        Me.Telefono.Width = 79
        '
        'Fax
        '
        Me.Fax.DataPropertyName = "fax"
        Me.Fax.HeaderText = "Fax"
        Me.Fax.Name = "Fax"
        Me.Fax.ReadOnly = True
        Me.Fax.Width = 51
        '
        'Categoria
        '
        Me.Categoria.DataPropertyName = "CategoriaStr"
        Me.Categoria.HeaderText = "Categoria"
        Me.Categoria.Name = "Categoria"
        Me.Categoria.ReadOnly = True
        Me.Categoria.Width = 86
        '
        'DataAcquisiz
        '
        Me.DataAcquisiz.DataPropertyName = "DataAcqStr"
        Me.DataAcquisiz.HeaderText = "Data Ultimo Salvataggio"
        Me.DataAcquisiz.Name = "DataAcquisiz"
        Me.DataAcquisiz.ReadOnly = True
        Me.DataAcquisiz.Width = 150
        '
        'MenuLista
        '
        Me.MenuLista.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MenuLista.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CercaToolStripMenuItem, Me.ToolStripSeparator1, Me.toolStripMostraTutti})
        Me.MenuLista.Name = "MenuLista"
        Me.MenuLista.Size = New System.Drawing.Size(213, 57)
        '
        'CercaToolStripMenuItem
        '
        Me.CercaToolStripMenuItem.Name = "CercaToolStripMenuItem"
        Me.CercaToolStripMenuItem.Size = New System.Drawing.Size(152, 23)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(209, 6)
        '
        'toolStripMostraTutti
        '
        Me.toolStripMostraTutti.Name = "toolStripMostraTutti"
        Me.toolStripMostraTutti.Size = New System.Drawing.Size(212, 22)
        Me.toolStripMostraTutti.Text = "Mostra tutti"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1403, 731)
        Me.Controls.Add(Me.splitMain)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "FormerBrowser"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tabMain.ResumeLayout(False)
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel2.ResumeLayout(False)
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.tabSchede.ResumeLayout(False)
        Me.tpScheda.ResumeLayout(False)
        Me.splitScheda.Panel1.ResumeLayout(False)
        Me.splitScheda.Panel2.ResumeLayout(False)
        CType(Me.splitScheda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitScheda.ResumeLayout(False)
        Me.pnlScheda.ResumeLayout(False)
        Me.pnlScheda.PerformLayout()
        Me.pnlFiltri.ResumeLayout(False)
        Me.pnlFiltri.PerformLayout()
        CType(Me.dgSchede, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuLista.ResumeLayout(False)
        Me.MenuLista.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpOpzioni As System.Windows.Forms.TabPage
    Friend WithEvents tpNewTab As System.Windows.Forms.TabPage
    Friend WithEvents imlMain As System.Windows.Forms.ImageList
    Friend WithEvents splitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents tabSchede As System.Windows.Forms.TabControl
    Friend WithEvents tpScheda As System.Windows.Forms.TabPage
    Friend WithEvents pnlScheda As System.Windows.Forms.Panel
    Friend WithEvents dgSchede As System.Windows.Forms.DataGridView
    Friend WithEvents splitScheda As System.Windows.Forms.SplitContainer
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents txtCitta As System.Windows.Forms.TextBox
    Friend WithEvents txtIndirizzo As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtSito As System.Windows.Forms.TextBox
    Friend WithEvents txtNomeAz As System.Windows.Forms.TextBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnAddCat As System.Windows.Forms.Button
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents MenuLista As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CercaToolStripMenuItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripMostraTutti As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NomeAzienda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Indirizzo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Citta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Telefono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Categoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataAcquisiz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCap As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlFiltri As System.Windows.Forms.Panel
    Friend WithEvents chkLavorato As System.Windows.Forms.CheckBox
    Friend WithEvents chkSoloDaLav As System.Windows.Forms.CheckBox
    Friend WithEvents lblTot As System.Windows.Forms.Label
    Friend WithEvents lblLastUpd As System.Windows.Forms.Label
    Friend WithEvents lnkAggiorna As System.Windows.Forms.LinkLabel
    Friend WithEvents cmbFindCat As System.Windows.Forms.ComboBox
    Friend WithEvents chkSoloLavorati As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
