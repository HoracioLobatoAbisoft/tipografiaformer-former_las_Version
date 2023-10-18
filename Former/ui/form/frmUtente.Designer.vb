<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUtente
    Inherits baseFormInternaFixed

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbMensilita = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtStipendio = New Former.ucNumericTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSfoglia = New System.Windows.Forms.Button()
        Me.txtFoto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pctOperatore = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkRepImballaggio = New System.Windows.Forms.CheckBox()
        Me.chkAttivo = New System.Windows.Forms.CheckBox()
        Me.grpMacchinari = New System.Windows.Forms.GroupBox()
        Me.chkMacchinari = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNomeReale = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.pctAlertCodice = New System.Windows.Forms.PictureBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.ToolTipEsistente = New System.Windows.Forms.ToolTip(Me.components)
        Me.dlgFoto = New System.Windows.Forms.OpenFileDialog()
        Me.cmbAzienda = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pctOperatore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMacchinari.SuspendLayout()
        CType(Me.pctAlertCodice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 657)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(703, 51)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(668, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.TabStop = False
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.Location = New System.Drawing.Point(632, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
        Me.btnOk.TabIndex = 15
        Me.btnOk.TabStop = False
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(703, 657)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.btnSfoglia)
        Me.tbProd.Controls.Add(Me.txtFoto)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.pctOperatore)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.chkRepImballaggio)
        Me.tbProd.Controls.Add(Me.chkAttivo)
        Me.tbProd.Controls.Add(Me.grpMacchinari)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtNomeReale)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtPassword)
        Me.tbProd.Controls.Add(Me.pctAlertCodice)
        Me.tbProd.Controls.Add(Me.cmbTipo)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtLogin)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(695, 631)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Operatore"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(50, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Dati Economici"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbAzienda)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmbMensilita)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtStipendio)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(169, 194)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(518, 57)
        Me.GroupBox1.TabIndex = 111
        Me.GroupBox1.TabStop = False
        '
        'cmbMensilita
        '
        Me.cmbMensilita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMensilita.FormattingEnabled = True
        Me.cmbMensilita.Items.AddRange(New Object() {"13", "14", "15"})
        Me.cmbMensilita.Location = New System.Drawing.Point(292, 16)
        Me.cmbMensilita.Name = "cmbMensilita"
        Me.cmbMensilita.Size = New System.Drawing.Size(65, 21)
        Me.cmbMensilita.TabIndex = 116
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(231, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 15)
        Me.Label10.TabIndex = 115
        Me.Label10.Text = "Mensilità"
        '
        'txtStipendio
        '
        Me.txtStipendio.My_AccettaNegativi = False
        Me.txtStipendio.My_DefaultValue = 0
        Me.txtStipendio.Location = New System.Drawing.Point(147, 16)
        Me.txtStipendio.MaxLength = 5
        Me.txtStipendio.My_MaxValue = 10000.0!
        Me.txtStipendio.My_MinValue = 0!
        Me.txtStipendio.Name = "txtStipendio"
        Me.txtStipendio.My_AllowOnlyInteger = True
        Me.txtStipendio.My_ReplaceWithDefaultValue = True
        Me.txtStipendio.Size = New System.Drawing.Size(78, 20)
        Me.txtStipendio.TabIndex = 114
        Me.txtStipendio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 15)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "Stipendio Mensile Lordo"
        '
        'btnSfoglia
        '
        Me.btnSfoglia.Location = New System.Drawing.Point(535, 166)
        Me.btnSfoglia.Name = "btnSfoglia"
        Me.btnSfoglia.Size = New System.Drawing.Size(25, 23)
        Me.btnSfoglia.TabIndex = 110
        Me.btnSfoglia.Text = "..."
        Me.btnSfoglia.UseVisualStyleBackColor = True
        '
        'txtFoto
        '
        Me.txtFoto.Location = New System.Drawing.Point(169, 167)
        Me.txtFoto.MaxLength = 50
        Me.txtFoto.Name = "txtFoto"
        Me.txtFoto.ReadOnly = True
        Me.txtFoto.Size = New System.Drawing.Size(360, 20)
        Me.txtFoto.TabIndex = 109
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(50, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 15)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "Fotografia"
        '
        'pctOperatore
        '
        Me.pctOperatore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctOperatore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctOperatore.Location = New System.Drawing.Point(559, 33)
        Me.pctOperatore.Name = "pctOperatore"
        Me.pctOperatore.Size = New System.Drawing.Size(128, 128)
        Me.pctOperatore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctOperatore.TabIndex = 107
        Me.pctOperatore.TabStop = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(50, 594)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 15)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "IMBALLAGGIO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Green
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(50, 277)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "PRODUZIONE"
        '
        'chkRepImballaggio
        '
        Me.chkRepImballaggio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkRepImballaggio.AutoSize = True
        Me.chkRepImballaggio.Location = New System.Drawing.Point(169, 593)
        Me.chkRepImballaggio.Name = "chkRepImballaggio"
        Me.chkRepImballaggio.Size = New System.Drawing.Size(176, 19)
        Me.chkRepImballaggio.TabIndex = 58
        Me.chkRepImballaggio.Text = "Abilita il reparto Imballaggio"
        Me.chkRepImballaggio.UseVisualStyleBackColor = True
        '
        'chkAttivo
        '
        Me.chkAttivo.AutoSize = True
        Me.chkAttivo.Location = New System.Drawing.Point(332, 59)
        Me.chkAttivo.Name = "chkAttivo"
        Me.chkAttivo.Size = New System.Drawing.Size(96, 19)
        Me.chkAttivo.TabIndex = 56
        Me.chkAttivo.Text = "Utente Attivo"
        Me.chkAttivo.UseVisualStyleBackColor = True
        '
        'grpMacchinari
        '
        Me.grpMacchinari.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMacchinari.Controls.Add(Me.chkMacchinari)
        Me.grpMacchinari.Location = New System.Drawing.Point(169, 257)
        Me.grpMacchinari.Name = "grpMacchinari"
        Me.grpMacchinari.Size = New System.Drawing.Size(518, 330)
        Me.grpMacchinari.TabIndex = 55
        Me.grpMacchinari.TabStop = False
        Me.grpMacchinari.Tag = "Macchinari assegnati"
        Me.grpMacchinari.Text = "Macchinari assegnati (0)"
        '
        'chkMacchinari
        '
        Me.chkMacchinari.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMacchinari.CheckOnClick = True
        Me.chkMacchinari.FormattingEnabled = True
        Me.chkMacchinari.Location = New System.Drawing.Point(6, 20)
        Me.chkMacchinari.Name = "chkMacchinari"
        Me.chkMacchinari.Size = New System.Drawing.Size(506, 274)
        Me.chkMacchinari.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 15)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Nome reale"
        '
        'txtNomeReale
        '
        Me.txtNomeReale.Location = New System.Drawing.Point(169, 111)
        Me.txtNomeReale.MaxLength = 50
        Me.txtNomeReale.Name = "txtNomeReale"
        Me.txtNomeReale.Size = New System.Drawing.Size(157, 20)
        Me.txtNomeReale.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(169, 84)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(157, 20)
        Me.txtPassword.TabIndex = 1
        '
        'pctAlertCodice
        '
        Me.pctAlertCodice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctAlertCodice.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.pctAlertCodice.Location = New System.Drawing.Point(18, 57)
        Me.pctAlertCodice.Name = "pctAlertCodice"
        Me.pctAlertCodice.Size = New System.Drawing.Size(26, 26)
        Me.pctAlertCodice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pctAlertCodice.TabIndex = 47
        Me.pctAlertCodice.TabStop = False
        Me.ToolTipEsistente.SetToolTip(Me.pctAlertCodice, "La Login inserità è già associata a un altro operatore")
        Me.pctAlertCodice.Visible = False
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(169, 138)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(157, 21)
        Me.cmbTipo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Login"
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(169, 57)
        Me.txtLogin.MaxLength = 50
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(157, 20)
        Me.txtLogin.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.user_1_
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(87, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Operatore"
        '
        'ToolTipEsistente
        '
        Me.ToolTipEsistente.ToolTipTitle = "Attenzione!"
        '
        'dlgFoto
        '
        Me.dlgFoto.Filter = "Immagini PNG|*.png|Immagini JPG|*.jpg"
        '
        'cmbAzienda
        '
        Me.cmbAzienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAzienda.FormattingEnabled = True
        Me.cmbAzienda.Location = New System.Drawing.Point(418, 16)
        Me.cmbAzienda.Name = "cmbAzienda"
        Me.cmbAzienda.Size = New System.Drawing.Size(94, 21)
        Me.cmbAzienda.TabIndex = 117
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(363, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 15)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "Azienda"
        '
        'frmUtente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(703, 708)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmUtente"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Operatore"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctOperatore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMacchinari.ResumeLayout(False)
        CType(Me.pctAlertCodice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctAlertCodice As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNomeReale As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ToolTipEsistente As System.Windows.Forms.ToolTip
    Friend WithEvents grpMacchinari As System.Windows.Forms.GroupBox
    Friend WithEvents chkMacchinari As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkAttivo As System.Windows.Forms.CheckBox
    Friend WithEvents chkRepImballaggio As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFoto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents pctOperatore As PictureBox
    Friend WithEvents btnSfoglia As Button
    Friend WithEvents dlgFoto As OpenFileDialog
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbMensilita As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtStipendio As ucNumericTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbAzienda As ComboBox
    Friend WithEvents Label11 As Label
End Class
