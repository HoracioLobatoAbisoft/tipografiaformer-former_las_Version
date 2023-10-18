<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits baseFormInternaFixed

    'Form overrides dispose to clean up the component list.
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
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tpClassicLogin = New System.Windows.Forms.TabPage()
        Me.Version = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.rdoOperat = New System.Windows.Forms.RadioButton()
        Me.rdoAdmin = New System.Windows.Forms.RadioButton()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.cmbOperatori = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDebug = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.cmbAdmin = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.tbLogin = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlCollegata = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pctLoading = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.pctKey = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ChiudiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccediToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabMain.SuspendLayout()
        Me.tpClassicLogin.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbLogin.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCollegata.SuspendLayout()
        CType(Me.pctLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctKey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tpClassicLogin)
        Me.TabMain.Controls.Add(Me.tbLogin)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(601, 368)
        Me.TabMain.TabIndex = 1
        Me.TabMain.TabStop = False
        '
        'tpClassicLogin
        '
        Me.tpClassicLogin.Controls.Add(Me.Version)
        Me.tpClassicLogin.Controls.Add(Me.PictureBox3)
        Me.tpClassicLogin.Controls.Add(Me.rdoOperat)
        Me.tpClassicLogin.Controls.Add(Me.rdoAdmin)
        Me.tpClassicLogin.Controls.Add(Me.PictureBox8)
        Me.tpClassicLogin.Controls.Add(Me.cmbOperatori)
        Me.tpClassicLogin.Controls.Add(Me.Label5)
        Me.tpClassicLogin.Controls.Add(Me.lblDebug)
        Me.tpClassicLogin.Controls.Add(Me.PictureBox7)
        Me.tpClassicLogin.Controls.Add(Me.PictureBox2)
        Me.tpClassicLogin.Controls.Add(Me.PictureBox6)
        Me.tpClassicLogin.Controls.Add(Me.Label4)
        Me.tpClassicLogin.Controls.Add(Me.txtPwd)
        Me.tpClassicLogin.Controls.Add(Me.cmbAdmin)
        Me.tpClassicLogin.Controls.Add(Me.Label3)
        Me.tpClassicLogin.Controls.Add(Me.PictureBox5)
        Me.tpClassicLogin.Controls.Add(Me.lblVer)
        Me.tpClassicLogin.Location = New System.Drawing.Point(4, 24)
        Me.tpClassicLogin.Name = "tpClassicLogin"
        Me.tpClassicLogin.Padding = New System.Windows.Forms.Padding(3)
        Me.tpClassicLogin.Size = New System.Drawing.Size(593, 340)
        Me.tpClassicLogin.TabIndex = 1
        Me.tpClassicLogin.Text = "Login Standard"
        Me.tpClassicLogin.UseVisualStyleBackColor = True
        '
        'Version
        '
        Me.Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.ForeColor = System.Drawing.Color.Black
        Me.Version.Location = New System.Drawing.Point(410, 315)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(130, 19)
        Me.Version.TabIndex = 101
        Me.Version.Text = "Version {0}.{1:00}"
        Me.Version.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.Former.My.Resources.Resources.Newlogo
        Me.PictureBox3.Location = New System.Drawing.Point(546, 300)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(39, 34)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 102
        Me.PictureBox3.TabStop = False
        '
        'rdoOperat
        '
        Me.rdoOperat.AutoSize = True
        Me.rdoOperat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoOperat.Location = New System.Drawing.Point(63, 237)
        Me.rdoOperat.Name = "rdoOperat"
        Me.rdoOperat.Size = New System.Drawing.Size(14, 13)
        Me.rdoOperat.TabIndex = 37
        Me.rdoOperat.UseVisualStyleBackColor = True
        '
        'rdoAdmin
        '
        Me.rdoAdmin.AutoSize = True
        Me.rdoAdmin.Checked = True
        Me.rdoAdmin.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdoAdmin.Location = New System.Drawing.Point(63, 93)
        Me.rdoAdmin.Name = "rdoAdmin"
        Me.rdoAdmin.Size = New System.Drawing.Size(14, 13)
        Me.rdoAdmin.TabIndex = 36
        Me.rdoAdmin.TabStop = True
        Me.rdoAdmin.UseVisualStyleBackColor = True
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.Former.My.Resources.Resources.user_1_
        Me.PictureBox8.Location = New System.Drawing.Point(83, 228)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox8.TabIndex = 35
        Me.PictureBox8.TabStop = False
        '
        'cmbOperatori
        '
        Me.cmbOperatori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperatori.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbOperatori.FormattingEnabled = True
        Me.cmbOperatori.Location = New System.Drawing.Point(253, 233)
        Me.cmbOperatori.Name = "cmbOperatori"
        Me.cmbOperatori.Size = New System.Drawing.Size(193, 23)
        Me.cmbOperatori.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(117, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 24)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "OPERATORE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDebug
        '
        Me.lblDebug.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDebug.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblDebug.ForeColor = System.Drawing.Color.Red
        Me.lblDebug.Location = New System.Drawing.Point(8, 304)
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.Size = New System.Drawing.Size(396, 31)
        Me.lblDebug.TabIndex = 30
        Me.lblDebug.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.Former.My.Resources.Resources._password
        Me.PictureBox7.Location = New System.Drawing.Point(83, 135)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox7.TabIndex = 29
        Me.PictureBox7.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources.logo1
        Me.PictureBox2.Location = New System.Drawing.Point(8, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(297, 47)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 28
        Me.PictureBox2.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.Former.My.Resources.Resources._administrator
        Me.PictureBox6.Location = New System.Drawing.Point(83, 84)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox6.TabIndex = 27
        Me.PictureBox6.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(117, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Password"
        '
        'txtPwd
        '
        Me.txtPwd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPwd.Location = New System.Drawing.Point(253, 135)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(193, 23)
        Me.txtPwd.TabIndex = 100
        Me.txtPwd.TabStop = False
        '
        'cmbAdmin
        '
        Me.cmbAdmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAdmin.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbAdmin.FormattingEnabled = True
        Me.cmbAdmin.Location = New System.Drawing.Point(253, 89)
        Me.cmbAdmin.Name = "cmbAdmin"
        Me.cmbAdmin.Size = New System.Drawing.Size(193, 23)
        Me.cmbAdmin.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(117, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 24)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "AMMINISTRATORE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = Global.Former.My.Resources.Resources.Newlogo
        Me.PictureBox5.Location = New System.Drawing.Point(548, -37)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(39, 34)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 22
        Me.PictureBox5.TabStop = False
        '
        'lblVer
        '
        Me.lblVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVer.BackColor = System.Drawing.Color.Transparent
        Me.lblVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVer.ForeColor = System.Drawing.Color.Black
        Me.lblVer.Location = New System.Drawing.Point(356, -22)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(186, 19)
        Me.lblVer.TabIndex = 21
        Me.lblVer.Text = "Version {0}.{1:00}"
        Me.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbLogin
        '
        Me.tbLogin.BackColor = System.Drawing.Color.White
        Me.tbLogin.Controls.Add(Me.Panel1)
        Me.tbLogin.Controls.Add(Me.pnlCollegata)
        Me.tbLogin.Controls.Add(Me.PictureBox4)
        Me.tbLogin.Controls.Add(Me.pctKey)
        Me.tbLogin.Location = New System.Drawing.Point(4, 24)
        Me.tbLogin.Name = "tbLogin"
        Me.tbLogin.Padding = New System.Windows.Forms.Padding(3)
        Me.tbLogin.Size = New System.Drawing.Size(593, 340)
        Me.tbLogin.TabIndex = 0
        Me.tbLogin.Text = "Autenticazione con FormerKey"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(61, 82)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(495, 52)
        Me.Panel1.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(137, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(246, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Collega la FormerKey per essere autenticato..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.PictureBox1.Location = New System.Drawing.Point(105, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'pnlCollegata
        '
        Me.pnlCollegata.Controls.Add(Me.Label1)
        Me.pnlCollegata.Controls.Add(Me.pctLoading)
        Me.pnlCollegata.Location = New System.Drawing.Point(146, 217)
        Me.pnlCollegata.Name = "pnlCollegata"
        Me.pnlCollegata.Size = New System.Drawing.Size(310, 39)
        Me.pnlCollegata.TabIndex = 22
        Me.pnlCollegata.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(45, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Chiave USB Collegata, attendere prego..."
        '
        'pctLoading
        '
        Me.pctLoading.Image = Global.Former.My.Resources.Resources.loading
        Me.pctLoading.Location = New System.Drawing.Point(3, 3)
        Me.pctLoading.Name = "pctLoading"
        Me.pctLoading.Size = New System.Drawing.Size(32, 32)
        Me.pctLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pctLoading.TabIndex = 21
        Me.pctLoading.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.Former.My.Resources.Resources.logo1
        Me.PictureBox4.Location = New System.Drawing.Point(8, 6)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(297, 47)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 18
        Me.PictureBox4.TabStop = False
        '
        'pctKey
        '
        Me.pctKey.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctKey.Image = Global.Former.My.Resources.Resources.Formerkey
        Me.pctKey.Location = New System.Drawing.Point(220, 147)
        Me.pctKey.Name = "pctKey"
        Me.pctKey.Size = New System.Drawing.Size(154, 59)
        Me.pctKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctKey.TabIndex = 15
        Me.pctKey.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChiudiToolStripMenuItem, Me.AccediToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 368)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(601, 44)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ChiudiToolStripMenuItem
        '
        Me.ChiudiToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ChiudiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Annulla
        Me.ChiudiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ChiudiToolStripMenuItem.Name = "ChiudiToolStripMenuItem"
        Me.ChiudiToolStripMenuItem.Size = New System.Drawing.Size(80, 40)
        Me.ChiudiToolStripMenuItem.Text = "Chiudi"
        '
        'AccediToolStripMenuItem
        '
        Me.AccediToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.AccediToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Ok
        Me.AccediToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AccediToolStripMenuItem.Name = "AccediToolStripMenuItem"
        Me.AccediToolStripMenuItem.Size = New System.Drawing.Size(81, 40)
        Me.AccediToolStripMenuItem.Text = "Accedi"
        '
        'frmLogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(601, 412)
        Me.CloseOnEsc = True
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmLogin"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Login"
        Me.TabMain.ResumeLayout(False)
        Me.tpClassicLogin.ResumeLayout(False)
        Me.tpClassicLogin.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbLogin.ResumeLayout(False)
        Me.tbLogin.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCollegata.ResumeLayout(False)
        Me.pnlCollegata.PerformLayout()
        CType(Me.pctLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctKey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbLogin As System.Windows.Forms.TabPage
    Friend WithEvents pctKey As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents pctLoading As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCollegata As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tpClassicLogin As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents lblVer As System.Windows.Forms.Label
    Friend WithEvents cmbAdmin As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents lblDebug As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents cmbOperatori As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents rdoOperat As RadioButton
    Friend WithEvents rdoAdmin As RadioButton
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ChiudiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AccediToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Version As Label
    Friend WithEvents PictureBox3 As PictureBox
End Class
