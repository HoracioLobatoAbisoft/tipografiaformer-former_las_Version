<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarketingFiltro
    Inherits baseFormInternaRedim

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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.chkRicorsiva = New System.Windows.Forms.CheckBox()
        Me.btnDettGruppo = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbGruppoContatti = New System.Windows.Forms.ComboBox()
        Me.cmbTipoFiltro = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnkTest = New System.Windows.Forms.LinkLabel()
        Me.lblRisAtt = New System.Windows.Forms.Label()
        Me.btn12 = New System.Windows.Forms.Button()
        Me.txt12 = New System.Windows.Forms.TextBox()
        Me.btn11 = New System.Windows.Forms.Button()
        Me.txt11 = New System.Windows.Forms.TextBox()
        Me.btn10 = New System.Windows.Forms.Button()
        Me.txt10 = New System.Windows.Forms.TextBox()
        Me.btn08 = New System.Windows.Forms.Button()
        Me.txt08 = New System.Windows.Forms.TextBox()
        Me.btn07 = New System.Windows.Forms.Button()
        Me.txt07 = New System.Windows.Forms.TextBox()
        Me.btn06 = New System.Windows.Forms.Button()
        Me.txt06 = New System.Windows.Forms.TextBox()
        Me.btn05 = New System.Windows.Forms.Button()
        Me.txt05 = New System.Windows.Forms.TextBox()
        Me.btn04 = New System.Windows.Forms.Button()
        Me.txt04 = New System.Windows.Forms.TextBox()
        Me.btn03 = New System.Windows.Forms.Button()
        Me.txt03 = New System.Windows.Forms.TextBox()
        Me.btn02 = New System.Windows.Forms.Button()
        Me.txt02 = New System.Windows.Forms.TextBox()
        Me.btn01 = New System.Windows.Forms.Button()
        Me.txt01 = New System.Windows.Forms.TextBox()
        Me.btn09 = New System.Windows.Forms.Button()
        Me.txt09 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 672)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1030, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(988, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 36)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.Location = New System.Drawing.Point(954, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 0
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1030, 672)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.chkRicorsiva)
        Me.tbProd.Controls.Add(Me.btnDettGruppo)
        Me.tbProd.Controls.Add(Me.Label16)
        Me.tbProd.Controls.Add(Me.cmbGruppoContatti)
        Me.tbProd.Controls.Add(Me.cmbTipoFiltro)
        Me.tbProd.Controls.Add(Me.Label15)
        Me.tbProd.Controls.Add(Me.Label14)
        Me.tbProd.Controls.Add(Me.Label13)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.lnkTest)
        Me.tbProd.Controls.Add(Me.lblRisAtt)
        Me.tbProd.Controls.Add(Me.btn12)
        Me.tbProd.Controls.Add(Me.txt12)
        Me.tbProd.Controls.Add(Me.btn11)
        Me.tbProd.Controls.Add(Me.txt11)
        Me.tbProd.Controls.Add(Me.btn10)
        Me.tbProd.Controls.Add(Me.txt10)
        Me.tbProd.Controls.Add(Me.btn08)
        Me.tbProd.Controls.Add(Me.txt08)
        Me.tbProd.Controls.Add(Me.btn07)
        Me.tbProd.Controls.Add(Me.txt07)
        Me.tbProd.Controls.Add(Me.btn06)
        Me.tbProd.Controls.Add(Me.txt06)
        Me.tbProd.Controls.Add(Me.btn05)
        Me.tbProd.Controls.Add(Me.txt05)
        Me.tbProd.Controls.Add(Me.btn04)
        Me.tbProd.Controls.Add(Me.txt04)
        Me.tbProd.Controls.Add(Me.btn03)
        Me.tbProd.Controls.Add(Me.txt03)
        Me.tbProd.Controls.Add(Me.btn02)
        Me.tbProd.Controls.Add(Me.txt02)
        Me.tbProd.Controls.Add(Me.btn01)
        Me.tbProd.Controls.Add(Me.txt01)
        Me.tbProd.Controls.Add(Me.btn09)
        Me.tbProd.Controls.Add(Me.txt09)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtNome)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1022, 646)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Campagna Marketing"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'chkRicorsiva
        '
        Me.chkRicorsiva.AutoSize = True
        Me.chkRicorsiva.Checked = True
        Me.chkRicorsiva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRicorsiva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkRicorsiva.Location = New System.Drawing.Point(134, 136)
        Me.chkRicorsiva.Name = "chkRicorsiva"
        Me.chkRicorsiva.Size = New System.Drawing.Size(113, 19)
        Me.chkRicorsiva.TabIndex = 156
        Me.chkRicorsiva.Text = "Ripeti ogni anno"
        Me.toolTipHelp.SetToolTip(Me.chkRicorsiva, "Togliendo questo Check si creerà una campagna di marketing spot che non sarà eseg" &
        "uita ogni anno")
        Me.chkRicorsiva.UseVisualStyleBackColor = True
        '
        'btnDettGruppo
        '
        Me.btnDettGruppo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDettGruppo.Location = New System.Drawing.Point(433, 77)
        Me.btnDettGruppo.Name = "btnDettGruppo"
        Me.btnDettGruppo.Size = New System.Drawing.Size(30, 23)
        Me.btnDettGruppo.TabIndex = 155
        Me.btnDettGruppo.Text = "..."
        Me.btnDettGruppo.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(22, 80)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 15)
        Me.Label16.TabIndex = 154
        Me.Label16.Text = "Gruppo di contatti:"
        '
        'cmbGruppoContatti
        '
        Me.cmbGruppoContatti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGruppoContatti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbGruppoContatti.FormattingEnabled = True
        Me.cmbGruppoContatti.Location = New System.Drawing.Point(134, 77)
        Me.cmbGruppoContatti.Name = "cmbGruppoContatti"
        Me.cmbGruppoContatti.Size = New System.Drawing.Size(293, 23)
        Me.cmbGruppoContatti.TabIndex = 153
        '
        'cmbTipoFiltro
        '
        Me.cmbTipoFiltro.DisplayMember = "0"
        Me.cmbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoFiltro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbTipoFiltro.FormattingEnabled = True
        Me.cmbTipoFiltro.Location = New System.Drawing.Point(134, 106)
        Me.cmbTipoFiltro.Name = "cmbTipoFiltro"
        Me.cmbTipoFiltro.Size = New System.Drawing.Size(293, 23)
        Me.cmbTipoFiltro.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(22, 109)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 15)
        Me.Label15.TabIndex = 152
        Me.Label15.Text = "Tipo campagna:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(22, 517)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 15)
        Me.Label14.TabIndex = 151
        Me.Label14.Text = "Dicembre"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(22, 489)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 15)
        Me.Label13.TabIndex = 150
        Me.Label13.Text = "Novembre"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(22, 461)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 15)
        Me.Label12.TabIndex = 149
        Me.Label12.Text = "Ottobre"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(21, 433)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 15)
        Me.Label11.TabIndex = 148
        Me.Label11.Text = "Settembre"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(22, 405)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 15)
        Me.Label10.TabIndex = 147
        Me.Label10.Text = "Agosto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(22, 377)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 15)
        Me.Label9.TabIndex = 146
        Me.Label9.Text = "Luglio"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(22, 349)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 15)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "Giugno"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(22, 321)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 15)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "Maggio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(22, 293)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 15)
        Me.Label6.TabIndex = 143
        Me.Label6.Text = "Aprile"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(22, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 15)
        Me.Label5.TabIndex = 142
        Me.Label5.Text = "Marzo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(22, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Febbraio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(22, 209)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "Gennaio"
        '
        'lnkTest
        '
        Me.lnkTest.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkTest.Image = Global.Former.My.Resources.Resources._test
        Me.lnkTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkTest.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkTest.Location = New System.Drawing.Point(22, 172)
        Me.lnkTest.Name = "lnkTest"
        Me.lnkTest.Size = New System.Drawing.Size(120, 27)
        Me.lnkTest.TabIndex = 139
        Me.lnkTest.TabStop = True
        Me.lnkTest.Text = "Test Campagna"
        Me.lnkTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRisAtt
        '
        Me.lblRisAtt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRisAtt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRisAtt.Location = New System.Drawing.Point(677, 178)
        Me.lblRisAtt.Name = "lblRisAtt"
        Me.lblRisAtt.Size = New System.Drawing.Size(298, 15)
        Me.lblRisAtt.TabIndex = 138
        Me.lblRisAtt.Text = "Risultati attuali con il gruppo impostato: -"
        Me.lblRisAtt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn12
        '
        Me.btn12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn12.Location = New System.Drawing.Point(985, 513)
        Me.btn12.Name = "btn12"
        Me.btn12.Size = New System.Drawing.Size(27, 23)
        Me.btn12.TabIndex = 14
        Me.btn12.Text = "..."
        Me.btn12.UseVisualStyleBackColor = True
        '
        'txt12
        '
        Me.txt12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt12.Location = New System.Drawing.Point(114, 515)
        Me.txt12.MaxLength = 50
        Me.txt12.Multiline = True
        Me.txt12.Name = "txt12"
        Me.txt12.ReadOnly = True
        Me.txt12.Size = New System.Drawing.Size(865, 21)
        Me.txt12.TabIndex = 136
        '
        'btn11
        '
        Me.btn11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn11.Location = New System.Drawing.Point(985, 485)
        Me.btn11.Name = "btn11"
        Me.btn11.Size = New System.Drawing.Size(27, 23)
        Me.btn11.TabIndex = 13
        Me.btn11.Text = "..."
        Me.btn11.UseVisualStyleBackColor = True
        '
        'txt11
        '
        Me.txt11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt11.Location = New System.Drawing.Point(114, 487)
        Me.txt11.MaxLength = 50
        Me.txt11.Multiline = True
        Me.txt11.Name = "txt11"
        Me.txt11.ReadOnly = True
        Me.txt11.Size = New System.Drawing.Size(865, 21)
        Me.txt11.TabIndex = 134
        '
        'btn10
        '
        Me.btn10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn10.Location = New System.Drawing.Point(985, 457)
        Me.btn10.Name = "btn10"
        Me.btn10.Size = New System.Drawing.Size(27, 23)
        Me.btn10.TabIndex = 12
        Me.btn10.Text = "..."
        Me.btn10.UseVisualStyleBackColor = True
        '
        'txt10
        '
        Me.txt10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt10.Location = New System.Drawing.Point(114, 459)
        Me.txt10.MaxLength = 50
        Me.txt10.Multiline = True
        Me.txt10.Name = "txt10"
        Me.txt10.ReadOnly = True
        Me.txt10.Size = New System.Drawing.Size(865, 21)
        Me.txt10.TabIndex = 132
        '
        'btn08
        '
        Me.btn08.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn08.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn08.Location = New System.Drawing.Point(985, 401)
        Me.btn08.Name = "btn08"
        Me.btn08.Size = New System.Drawing.Size(27, 23)
        Me.btn08.TabIndex = 10
        Me.btn08.Text = "..."
        Me.btn08.UseVisualStyleBackColor = True
        '
        'txt08
        '
        Me.txt08.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt08.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt08.Location = New System.Drawing.Point(114, 403)
        Me.txt08.MaxLength = 50
        Me.txt08.Multiline = True
        Me.txt08.Name = "txt08"
        Me.txt08.ReadOnly = True
        Me.txt08.Size = New System.Drawing.Size(865, 21)
        Me.txt08.TabIndex = 130
        '
        'btn07
        '
        Me.btn07.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn07.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn07.Location = New System.Drawing.Point(985, 374)
        Me.btn07.Name = "btn07"
        Me.btn07.Size = New System.Drawing.Size(27, 23)
        Me.btn07.TabIndex = 9
        Me.btn07.Text = "..."
        Me.btn07.UseVisualStyleBackColor = True
        '
        'txt07
        '
        Me.txt07.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt07.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt07.Location = New System.Drawing.Point(114, 376)
        Me.txt07.MaxLength = 50
        Me.txt07.Multiline = True
        Me.txt07.Name = "txt07"
        Me.txt07.ReadOnly = True
        Me.txt07.Size = New System.Drawing.Size(865, 21)
        Me.txt07.TabIndex = 128
        '
        'btn06
        '
        Me.btn06.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn06.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn06.Location = New System.Drawing.Point(985, 345)
        Me.btn06.Name = "btn06"
        Me.btn06.Size = New System.Drawing.Size(27, 23)
        Me.btn06.TabIndex = 8
        Me.btn06.Text = "..."
        Me.btn06.UseVisualStyleBackColor = True
        '
        'txt06
        '
        Me.txt06.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt06.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt06.Location = New System.Drawing.Point(114, 347)
        Me.txt06.MaxLength = 50
        Me.txt06.Multiline = True
        Me.txt06.Name = "txt06"
        Me.txt06.ReadOnly = True
        Me.txt06.Size = New System.Drawing.Size(865, 21)
        Me.txt06.TabIndex = 126
        '
        'btn05
        '
        Me.btn05.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn05.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn05.Location = New System.Drawing.Point(985, 317)
        Me.btn05.Name = "btn05"
        Me.btn05.Size = New System.Drawing.Size(27, 23)
        Me.btn05.TabIndex = 7
        Me.btn05.Text = "..."
        Me.btn05.UseVisualStyleBackColor = True
        '
        'txt05
        '
        Me.txt05.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt05.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt05.Location = New System.Drawing.Point(114, 319)
        Me.txt05.MaxLength = 50
        Me.txt05.Multiline = True
        Me.txt05.Name = "txt05"
        Me.txt05.ReadOnly = True
        Me.txt05.Size = New System.Drawing.Size(865, 21)
        Me.txt05.TabIndex = 124
        '
        'btn04
        '
        Me.btn04.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn04.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn04.Location = New System.Drawing.Point(985, 289)
        Me.btn04.Name = "btn04"
        Me.btn04.Size = New System.Drawing.Size(27, 23)
        Me.btn04.TabIndex = 6
        Me.btn04.Text = "..."
        Me.btn04.UseVisualStyleBackColor = True
        '
        'txt04
        '
        Me.txt04.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt04.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt04.Location = New System.Drawing.Point(114, 291)
        Me.txt04.MaxLength = 50
        Me.txt04.Multiline = True
        Me.txt04.Name = "txt04"
        Me.txt04.ReadOnly = True
        Me.txt04.Size = New System.Drawing.Size(865, 21)
        Me.txt04.TabIndex = 122
        '
        'btn03
        '
        Me.btn03.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn03.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn03.Location = New System.Drawing.Point(985, 259)
        Me.btn03.Name = "btn03"
        Me.btn03.Size = New System.Drawing.Size(27, 23)
        Me.btn03.TabIndex = 5
        Me.btn03.Text = "..."
        Me.btn03.UseVisualStyleBackColor = True
        '
        'txt03
        '
        Me.txt03.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt03.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt03.Location = New System.Drawing.Point(114, 261)
        Me.txt03.MaxLength = 50
        Me.txt03.Multiline = True
        Me.txt03.Name = "txt03"
        Me.txt03.ReadOnly = True
        Me.txt03.Size = New System.Drawing.Size(865, 21)
        Me.txt03.TabIndex = 120
        '
        'btn02
        '
        Me.btn02.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn02.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn02.Location = New System.Drawing.Point(985, 232)
        Me.btn02.Name = "btn02"
        Me.btn02.Size = New System.Drawing.Size(27, 23)
        Me.btn02.TabIndex = 4
        Me.btn02.Text = "..."
        Me.btn02.UseVisualStyleBackColor = True
        '
        'txt02
        '
        Me.txt02.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt02.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt02.Location = New System.Drawing.Point(114, 234)
        Me.txt02.MaxLength = 50
        Me.txt02.Multiline = True
        Me.txt02.Name = "txt02"
        Me.txt02.ReadOnly = True
        Me.txt02.Size = New System.Drawing.Size(865, 21)
        Me.txt02.TabIndex = 118
        '
        'btn01
        '
        Me.btn01.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn01.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn01.Location = New System.Drawing.Point(985, 205)
        Me.btn01.Name = "btn01"
        Me.btn01.Size = New System.Drawing.Size(27, 23)
        Me.btn01.TabIndex = 3
        Me.btn01.Text = "..."
        Me.btn01.UseVisualStyleBackColor = True
        '
        'txt01
        '
        Me.txt01.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt01.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt01.Location = New System.Drawing.Point(114, 207)
        Me.txt01.MaxLength = 50
        Me.txt01.Multiline = True
        Me.txt01.Name = "txt01"
        Me.txt01.ReadOnly = True
        Me.txt01.Size = New System.Drawing.Size(865, 21)
        Me.txt01.TabIndex = 116
        '
        'btn09
        '
        Me.btn09.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn09.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn09.Location = New System.Drawing.Point(985, 429)
        Me.btn09.Name = "btn09"
        Me.btn09.Size = New System.Drawing.Size(27, 23)
        Me.btn09.TabIndex = 11
        Me.btn09.Text = "..."
        Me.btn09.UseVisualStyleBackColor = True
        '
        'txt09
        '
        Me.txt09.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt09.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt09.Location = New System.Drawing.Point(114, 431)
        Me.txt09.MaxLength = 50
        Me.txt09.Multiline = True
        Me.txt09.Name = "txt09"
        Me.txt09.ReadOnly = True
        Me.txt09.Size = New System.Drawing.Size(865, 21)
        Me.txt09.TabIndex = 114
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(22, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 15)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Nome campagna:"
        '
        'txtNome
        '
        Me.txtNome.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNome.Location = New System.Drawing.Point(134, 50)
        Me.txtNome.MaxLength = 50
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(293, 23)
        Me.txtNome.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Filtro
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
        Me.lblTipo.Size = New System.Drawing.Size(175, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Campagna Marketing"
        '
        'dlgOpen
        '
        Me.dlgOpen.Filter = "File HTM|*.htm|File HTML|*.html"
        '
        'frmMarketingFiltro
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1030, 720)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmMarketingFiltro"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Campagna Marketing"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents btn12 As System.Windows.Forms.Button
    Friend WithEvents txt12 As System.Windows.Forms.TextBox
    Friend WithEvents btn11 As System.Windows.Forms.Button
    Friend WithEvents txt11 As System.Windows.Forms.TextBox
    Friend WithEvents btn10 As System.Windows.Forms.Button
    Friend WithEvents txt10 As System.Windows.Forms.TextBox
    Friend WithEvents btn08 As System.Windows.Forms.Button
    Friend WithEvents txt08 As System.Windows.Forms.TextBox
    Friend WithEvents btn07 As System.Windows.Forms.Button
    Friend WithEvents txt07 As System.Windows.Forms.TextBox
    Friend WithEvents btn06 As System.Windows.Forms.Button
    Friend WithEvents txt06 As System.Windows.Forms.TextBox
    Friend WithEvents btn05 As System.Windows.Forms.Button
    Friend WithEvents txt05 As System.Windows.Forms.TextBox
    Friend WithEvents btn04 As System.Windows.Forms.Button
    Friend WithEvents txt04 As System.Windows.Forms.TextBox
    Friend WithEvents btn03 As System.Windows.Forms.Button
    Friend WithEvents txt03 As System.Windows.Forms.TextBox
    Friend WithEvents btn02 As System.Windows.Forms.Button
    Friend WithEvents txt02 As System.Windows.Forms.TextBox
    Friend WithEvents btn01 As System.Windows.Forms.Button
    Friend WithEvents txt01 As System.Windows.Forms.TextBox
    Friend WithEvents btn09 As System.Windows.Forms.Button
    Friend WithEvents txt09 As System.Windows.Forms.TextBox
    Friend WithEvents lblRisAtt As System.Windows.Forms.Label
    Friend WithEvents lnkTest As System.Windows.Forms.LinkLabel
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbTipoFiltro As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbGruppoContatti As ComboBox
    Friend WithEvents btnDettGruppo As Button
    Friend WithEvents chkRicorsiva As CheckBox
End Class
