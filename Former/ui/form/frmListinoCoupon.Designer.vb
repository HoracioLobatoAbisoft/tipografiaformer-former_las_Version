<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoCoupon
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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMinimoDiSpesa = New Former.ucNumericTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkVisibOnline = New System.Windows.Forms.CheckBox()
        Me.rdoRiv = New System.Windows.Forms.RadioButton()
        Me.rdoCli = New System.Windows.Forms.RadioButton()
        Me.rdoTutti = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblStato = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMaxVolte = New Former.ucNumericTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtQtaSpec = New Former.ucNumericTextBox()
        Me.cmbCli = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtStart = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtImportoFisso = New Former.ucNumericTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPerc = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodice = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoProd = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 418)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(694, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(652, 14)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 30)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.Location = New System.Drawing.Point(618, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 14
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(694, 418)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label16)
        Me.tbProd.Controls.Add(Me.txtMinimoDiSpesa)
        Me.tbProd.Controls.Add(Me.Label17)
        Me.tbProd.Controls.Add(Me.chkVisibOnline)
        Me.tbProd.Controls.Add(Me.rdoRiv)
        Me.tbProd.Controls.Add(Me.rdoCli)
        Me.tbProd.Controls.Add(Me.rdoTutti)
        Me.tbProd.Controls.Add(Me.Label15)
        Me.tbProd.Controls.Add(Me.lblStato)
        Me.tbProd.Controls.Add(Me.Label13)
        Me.tbProd.Controls.Add(Me.Label14)
        Me.tbProd.Controls.Add(Me.txtMaxVolte)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.txtQtaSpec)
        Me.tbProd.Controls.Add(Me.cmbCli)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.dtEnd)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.dtStart)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.txtImportoFisso)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtPerc)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtCodice)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbTipoProd)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtNome)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(686, 392)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Coupon"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(200, 165)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(13, 15)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "€"
        '
        'txtMinimoDiSpesa
        '
        Me.txtMinimoDiSpesa.My_AccettaNegativi = False
        Me.txtMinimoDiSpesa.My_DefaultValue = 0
        Me.txtMinimoDiSpesa.Location = New System.Drawing.Point(155, 162)
        Me.txtMinimoDiSpesa.MaxLength = 5
        Me.txtMinimoDiSpesa.My_MaxValue = 99999.0!
        Me.txtMinimoDiSpesa.My_MinValue = 0!
        Me.txtMinimoDiSpesa.Name = "txtMinimoDiSpesa"
        Me.txtMinimoDiSpesa.My_AllowOnlyInteger = True
        Me.txtMinimoDiSpesa.My_ReplaceWithDefaultValue = True
        Me.txtMinimoDiSpesa.Size = New System.Drawing.Size(39, 20)
        Me.txtMinimoDiSpesa.TabIndex = 43
        Me.txtMinimoDiSpesa.Text = "0"
        Me.txtMinimoDiSpesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(51, 165)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(94, 15)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Minimo di spesa"
        '
        'chkVisibOnline
        '
        Me.chkVisibOnline.AutoSize = True
        Me.chkVisibOnline.Location = New System.Drawing.Point(550, 300)
        Me.chkVisibOnline.Name = "chkVisibOnline"
        Me.chkVisibOnline.Size = New System.Drawing.Size(101, 19)
        Me.chkVisibOnline.TabIndex = 13
        Me.chkVisibOnline.Text = "Visibile Online"
        Me.chkVisibOnline.UseVisualStyleBackColor = True
        '
        'rdoRiv
        '
        Me.rdoRiv.AutoSize = True
        Me.rdoRiv.Location = New System.Drawing.Point(269, 217)
        Me.rdoRiv.Name = "rdoRiv"
        Me.rdoRiv.Size = New System.Drawing.Size(82, 19)
        Me.rdoRiv.TabIndex = 9
        Me.rdoRiv.Text = "Rivenditori"
        Me.rdoRiv.UseVisualStyleBackColor = True
        '
        'rdoCli
        '
        Me.rdoCli.AutoSize = True
        Me.rdoCli.Location = New System.Drawing.Point(203, 217)
        Me.rdoCli.Name = "rdoCli"
        Me.rdoCli.Size = New System.Drawing.Size(59, 19)
        Me.rdoCli.TabIndex = 8
        Me.rdoCli.Text = "Clienti"
        Me.rdoCli.UseVisualStyleBackColor = True
        '
        'rdoTutti
        '
        Me.rdoTutti.AutoSize = True
        Me.rdoTutti.Checked = True
        Me.rdoTutti.Location = New System.Drawing.Point(155, 217)
        Me.rdoTutti.Name = "rdoTutti"
        Me.rdoTutti.Size = New System.Drawing.Size(50, 19)
        Me.rdoTutti.TabIndex = 7
        Me.rdoTutti.TabStop = True
        Me.rdoTutti.Text = "Tutti"
        Me.rdoTutti.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(52, 219)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 15)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Riservato a "
        '
        'lblStato
        '
        Me.lblStato.BackColor = System.Drawing.Color.Red
        Me.lblStato.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStato.ForeColor = System.Drawing.Color.White
        Me.lblStato.Location = New System.Drawing.Point(541, 3)
        Me.lblStato.Name = "lblStato"
        Me.lblStato.Size = New System.Drawing.Size(142, 23)
        Me.lblStato.TabIndex = 41
        Me.lblStato.Text = "Non Pubblicato"
        Me.lblStato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(200, 301)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 15)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "volta/e"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(50, 301)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 15)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Utilizzabile N°"
        '
        'txtMaxVolte
        '
        Me.txtMaxVolte.My_AccettaNegativi = False
        Me.txtMaxVolte.My_DefaultValue = 1
        Me.txtMaxVolte.Location = New System.Drawing.Point(155, 298)
        Me.txtMaxVolte.MaxLength = 2
        Me.txtMaxVolte.My_MaxValue = 10.0!
        Me.txtMaxVolte.My_MinValue = 1.0!
        Me.txtMaxVolte.Name = "txtMaxVolte"
        Me.txtMaxVolte.My_AllowOnlyInteger = True
        Me.txtMaxVolte.My_ReplaceWithDefaultValue = True
        Me.txtMaxVolte.Size = New System.Drawing.Size(39, 20)
        Me.txtMaxVolte.TabIndex = 12
        Me.txtMaxVolte.Text = "1"
        Me.txtMaxVolte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(251, 274)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 15)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "pz"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(50, 274)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 15)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Quantita Prodotto"
        '
        'txtQtaSpec
        '
        Me.txtQtaSpec.My_AccettaNegativi = False
        Me.txtQtaSpec.My_DefaultValue = 0
        Me.txtQtaSpec.Location = New System.Drawing.Point(155, 271)
        Me.txtQtaSpec.MaxLength = 6
        Me.txtQtaSpec.My_MaxValue = 1000000.0!
        Me.txtQtaSpec.My_MinValue = 0!
        Me.txtQtaSpec.Name = "txtQtaSpec"
        Me.txtQtaSpec.My_AllowOnlyInteger = True
        Me.txtQtaSpec.My_ReplaceWithDefaultValue = True
        Me.txtQtaSpec.Size = New System.Drawing.Size(90, 20)
        Me.txtQtaSpec.TabIndex = 11
        Me.txtQtaSpec.Text = "0"
        Me.txtQtaSpec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCli
        '
        Me.cmbCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCli.FormattingEnabled = True
        Me.cmbCli.Location = New System.Drawing.Point(155, 188)
        Me.cmbCli.Name = "cmbCli"
        Me.cmbCli.Size = New System.Drawing.Size(500, 21)
        Me.cmbCli.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(51, 191)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 15)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Cliente"
        '
        'dtEnd
        '
        Me.dtEnd.Location = New System.Drawing.Point(454, 82)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(201, 20)
        Me.dtEnd.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(342, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 15)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Data Fine Validità"
        '
        'dtStart
        '
        Me.dtStart.Location = New System.Drawing.Point(454, 56)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(201, 20)
        Me.dtStart.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(342, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 15)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Data Inizio Validità"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(200, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "€"
        '
        'txtImportoFisso
        '
        Me.txtImportoFisso.My_AccettaNegativi = False
        Me.txtImportoFisso.My_DefaultValue = 0
        Me.txtImportoFisso.Location = New System.Drawing.Point(155, 136)
        Me.txtImportoFisso.MaxLength = 5
        Me.txtImportoFisso.My_MaxValue = 99999.0!
        Me.txtImportoFisso.My_MinValue = 0!
        Me.txtImportoFisso.Name = "txtImportoFisso"
        Me.txtImportoFisso.My_AllowOnlyInteger = True
        Me.txtImportoFisso.My_ReplaceWithDefaultValue = True
        Me.txtImportoFisso.Size = New System.Drawing.Size(39, 20)
        Me.txtImportoFisso.TabIndex = 5
        Me.txtImportoFisso.Text = "0"
        Me.txtImportoFisso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(51, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 15)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Importo Fisso"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(200, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 15)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "%"
        '
        'txtPerc
        '
        Me.txtPerc.My_AccettaNegativi = False
        Me.txtPerc.My_DefaultValue = 0
        Me.txtPerc.Location = New System.Drawing.Point(155, 109)
        Me.txtPerc.MaxLength = 2
        Me.txtPerc.My_MaxValue = 99.0!
        Me.txtPerc.My_MinValue = 0!
        Me.txtPerc.Name = "txtPerc"
        Me.txtPerc.My_AllowOnlyInteger = True
        Me.txtPerc.My_ReplaceWithDefaultValue = True
        Me.txtPerc.Size = New System.Drawing.Size(39, 20)
        Me.txtPerc.TabIndex = 4
        Me.txtPerc.Text = "0"
        Me.txtPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(51, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Percentuale"
        '
        'txtCodice
        '
        Me.txtCodice.Location = New System.Drawing.Point(155, 82)
        Me.txtCodice.MaxLength = 50
        Me.txtCodice.Name = "txtCodice"
        Me.txtCodice.Size = New System.Drawing.Size(157, 20)
        Me.txtCodice.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(51, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Nome"
        '
        'cmbTipoProd
        '
        Me.cmbTipoProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoProd.FormattingEnabled = True
        Me.cmbTipoProd.Location = New System.Drawing.Point(155, 242)
        Me.cmbTipoProd.Name = "cmbTipoProd"
        Me.cmbTipoProd.Size = New System.Drawing.Size(500, 21)
        Me.cmbTipoProd.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(51, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Prodotto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(51, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Codice"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(155, 56)
        Me.txtNome.MaxLength = 50
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(157, 20)
        Me.txtNome.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Coupon
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
        Me.lblTipo.Size = New System.Drawing.Size(146, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Coupon di Sconto"
        '
        'frmListinoCoupon
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(694, 466)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoCoupon"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Coupon"
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
    Friend WithEvents cmbTipoProd As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtImportoFisso As ucNumericTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPerc As ucNumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodice As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMaxVolte As ucNumericTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtQtaSpec As ucNumericTextBox
    Friend WithEvents cmbCli As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblStato As System.Windows.Forms.Label
    Friend WithEvents rdoRiv As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCli As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTutti As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkVisibOnline As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtMinimoDiSpesa As ucNumericTextBox
    Friend WithEvents Label17 As Label
End Class
