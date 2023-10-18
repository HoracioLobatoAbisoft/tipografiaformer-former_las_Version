<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmListinoTipoCarta
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnHotFolder = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.UcPictureWizard = New Former.ucPictureWizard()
        Me.pctImgLav = New System.Windows.Forms.PictureBox()
        Me.txtImgLav = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtLarghezza = New Former.ucNumericTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtAltezza = New Former.ucNumericTextBox()
        Me.lnkSuggerisci = New System.Windows.Forms.LinkLabel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCostoRif = New Former.ucNumericTextBox()
        Me.cmbTipoPrezzo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDescEst = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lstTipiCarta = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtMicron = New Former.ucNumericTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrezzoKg = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSigla = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGrammi = New Former.ucNumericTextBox()
        Me.cmbFinitura = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescrizione = New System.Windows.Forms.TextBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpCartaMagazzino = New System.Windows.Forms.TabPage()
        Me.btnRimuovi = New System.Windows.Forms.Button()
        Me.lnkAddRis = New System.Windows.Forms.Button()
        Me.DgRiso = New System.Windows.Forms.DataGridView()
        Me.IdRis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Risorsa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoCartaCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Giacenza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.tpImpatto = New System.Windows.Forms.TabPage()
        Me.UcListinoImpatto = New Former.ucListinoImpatto()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.dlgFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCartaMagazzino.SuspendLayout()
        CType(Me.DgRiso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpImpatto.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 703)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(900, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(858, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 36)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark2
        Me.btnOk.Location = New System.Drawing.Point(824, 10)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpCartaMagazzino)
        Me.TabMain.Controls.Add(Me.tpImpatto)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(900, 703)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.Label14)
        Me.tbProd.Controls.Add(Me.btnHotFolder)
        Me.tbProd.Controls.Add(Me.txtPath)
        Me.tbProd.Controls.Add(Me.UcPictureWizard)
        Me.tbProd.Controls.Add(Me.Label17)
        Me.tbProd.Controls.Add(Me.txtLarghezza)
        Me.tbProd.Controls.Add(Me.Label16)
        Me.tbProd.Controls.Add(Me.txtAltezza)
        Me.tbProd.Controls.Add(Me.lnkSuggerisci)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.txtCostoRif)
        Me.tbProd.Controls.Add(Me.cmbTipoPrezzo)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.txtDescEst)
        Me.tbProd.Controls.Add(Me.Label13)
        Me.tbProd.Controls.Add(Me.cmbTipo)
        Me.tbProd.Controls.Add(Me.btnDel)
        Me.tbProd.Controls.Add(Me.btnAdd)
        Me.tbProd.Controls.Add(Me.lstTipiCarta)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.PictureBox2)
        Me.tbProd.Controls.Add(Me.txtMicron)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtPrezzoKg)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtSigla)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtGrammi)
        Me.tbProd.Controls.Add(Me.cmbFinitura)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.btnSearch)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.txtImgLav)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.pctImgLav)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtDescrizione)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(892, 677)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Tipo Carta"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._HotFolder
        Me.PictureBox1.Location = New System.Drawing.Point(53, 624)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 190
        Me.PictureBox1.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(85, 632)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 15)
        Me.Label14.TabIndex = 189
        Me.Label14.Text = "HotFolder"
        '
        'btnHotFolder
        '
        Me.btnHotFolder.Location = New System.Drawing.Point(580, 629)
        Me.btnHotFolder.Name = "btnHotFolder"
        Me.btnHotFolder.Size = New System.Drawing.Size(26, 21)
        Me.btnHotFolder.TabIndex = 188
        Me.btnHotFolder.Text = "..."
        Me.btnHotFolder.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(169, 629)
        Me.txtPath.MaxLength = 50
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(405, 20)
        Me.txtPath.TabIndex = 187
        '
        'UcPictureWizard
        '
        Me.UcPictureWizard.AutoSize = True
        Me.UcPictureWizard.ImgHeight = 128
        Me.UcPictureWizard.ImgWidth = 128
        Me.UcPictureWizard.Location = New System.Drawing.Point(474, 259)
        Me.UcPictureWizard.Name = "UcPictureWizard"
        Me.UcPictureWizard.RifPictureBox = Me.pctImgLav
        Me.UcPictureWizard.RifTextBoxPath = Me.txtImgLav
        Me.UcPictureWizard.Size = New System.Drawing.Size(77, 23)
        Me.UcPictureWizard.TabIndex = 186
        '
        'pctImgLav
        '
        Me.pctImgLav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctImgLav.Location = New System.Drawing.Point(478, 55)
        Me.pctImgLav.Name = "pctImgLav"
        Me.pctImgLav.Size = New System.Drawing.Size(128, 128)
        Me.pctImgLav.TabIndex = 57
        Me.pctImgLav.TabStop = False
        '
        'txtImgLav
        '
        Me.txtImgLav.Location = New System.Drawing.Point(169, 261)
        Me.txtImgLav.MaxLength = 50
        Me.txtImgLav.Name = "txtImgLav"
        Me.txtImgLav.ReadOnly = True
        Me.txtImgLav.Size = New System.Drawing.Size(267, 20)
        Me.txtImgLav.TabIndex = 59
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(297, 347)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 15)
        Me.Label17.TabIndex = 185
        Me.Label17.Text = "Larghezza"
        '
        'txtLarghezza
        '
        Me.txtLarghezza.Location = New System.Drawing.Point(386, 344)
        Me.txtLarghezza.MaxLength = 50
        Me.txtLarghezza.My_AccettaNegativi = False
        Me.txtLarghezza.My_AllowOnlyInteger = True
        Me.txtLarghezza.My_DefaultValue = 0
        Me.txtLarghezza.My_MaxValue = 1.0E+10!
        Me.txtLarghezza.My_MinValue = 0!
        Me.txtLarghezza.My_ReplaceWithDefaultValue = True
        Me.txtLarghezza.Name = "txtLarghezza"
        Me.txtLarghezza.Size = New System.Drawing.Size(82, 20)
        Me.txtLarghezza.TabIndex = 184
        Me.txtLarghezza.Text = "0"
        Me.txtLarghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(50, 347)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 15)
        Me.Label16.TabIndex = 183
        Me.Label16.Text = "Altezza"
        '
        'txtAltezza
        '
        Me.txtAltezza.Location = New System.Drawing.Point(169, 344)
        Me.txtAltezza.MaxLength = 50
        Me.txtAltezza.My_AccettaNegativi = False
        Me.txtAltezza.My_AllowOnlyInteger = True
        Me.txtAltezza.My_DefaultValue = 0
        Me.txtAltezza.My_MaxValue = 1.0E+10!
        Me.txtAltezza.My_MinValue = 0!
        Me.txtAltezza.My_ReplaceWithDefaultValue = True
        Me.txtAltezza.Name = "txtAltezza"
        Me.txtAltezza.Size = New System.Drawing.Size(82, 20)
        Me.txtAltezza.TabIndex = 182
        Me.txtAltezza.Text = "0"
        Me.txtAltezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lnkSuggerisci
        '
        Me.lnkSuggerisci.AutoSize = True
        Me.lnkSuggerisci.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSuggerisci.Location = New System.Drawing.Point(612, 374)
        Me.lnkSuggerisci.Name = "lnkSuggerisci"
        Me.lnkSuggerisci.Size = New System.Drawing.Size(61, 15)
        Me.lnkSuggerisci.TabIndex = 181
        Me.lnkSuggerisci.TabStop = True
        Me.lnkSuggerisci.Text = "Suggerisci"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Orange
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(322, 374)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 15)
        Me.Label11.TabIndex = 180
        Me.Label11.Text = "Costo Rif"
        '
        'txtCostoRif
        '
        Me.txtCostoRif.Location = New System.Drawing.Point(386, 371)
        Me.txtCostoRif.MaxLength = 50
        Me.txtCostoRif.My_AccettaNegativi = False
        Me.txtCostoRif.My_AllowOnlyInteger = False
        Me.txtCostoRif.My_DefaultValue = 0
        Me.txtCostoRif.My_MaxValue = 1.0E+10!
        Me.txtCostoRif.My_MinValue = 0!
        Me.txtCostoRif.My_ReplaceWithDefaultValue = True
        Me.txtCostoRif.Name = "txtCostoRif"
        Me.txtCostoRif.Size = New System.Drawing.Size(82, 20)
        Me.txtCostoRif.TabIndex = 179
        Me.txtCostoRif.Text = "0"
        Me.txtCostoRif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoPrezzo
        '
        Me.cmbTipoPrezzo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPrezzo.FormattingEnabled = True
        Me.cmbTipoPrezzo.Location = New System.Drawing.Point(169, 371)
        Me.cmbTipoPrezzo.Name = "cmbTipoPrezzo"
        Me.cmbTipoPrezzo.Size = New System.Drawing.Size(141, 21)
        Me.cmbTipoPrezzo.TabIndex = 178
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Orange
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(50, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 15)
        Me.Label6.TabIndex = 155
        Me.Label6.Text = "Descrizione sito"
        '
        'txtDescEst
        '
        Me.txtDescEst.Location = New System.Drawing.Point(169, 109)
        Me.txtDescEst.MaxLength = 255
        Me.txtDescEst.Multiline = True
        Me.txtDescEst.Name = "txtDescEst"
        Me.txtDescEst.Size = New System.Drawing.Size(299, 146)
        Me.txtDescEst.TabIndex = 154
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Orange
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(279, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 15)
        Me.Label13.TabIndex = 153
        Me.Label13.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(316, 55)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(152, 21)
        Me.cmbTipo.TabIndex = 152
        '
        'btnDel
        '
        Me.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDel.FlatAppearance.BorderSize = 0
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.ForeColor = System.Drawing.Color.Black
        Me.btnDel.Image = Global.Former.My.Resources.Resources._remove
        Me.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDel.Location = New System.Drawing.Point(53, 452)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(84, 30)
        Me.btnDel.TabIndex = 151
        Me.btnDel.Text = "Elimina"
        Me.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(53, 416)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(91, 30)
        Me.btnAdd.TabIndex = 150
        Me.btnAdd.Text = "Aggiungi"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lstTipiCarta
        '
        Me.lstTipiCarta.FormattingEnabled = True
        Me.lstTipiCarta.Location = New System.Drawing.Point(169, 398)
        Me.lstTipiCarta.Name = "lstTipiCarta"
        Me.lstTipiCarta.Size = New System.Drawing.Size(437, 225)
        Me.lstTipiCarta.TabIndex = 149
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Orange
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(50, 398)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 15)
        Me.Label12.TabIndex = 148
        Me.Label12.Text = "Tipi Carta contenuti"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources._TipoCarta
        Me.PictureBox2.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 96
        Me.PictureBox2.TabStop = False
        '
        'txtMicron
        '
        Me.txtMicron.Location = New System.Drawing.Point(386, 317)
        Me.txtMicron.My_AccettaNegativi = False
        Me.txtMicron.My_AllowOnlyInteger = True
        Me.txtMicron.My_DefaultValue = 0
        Me.txtMicron.My_MaxValue = 1.0E+10!
        Me.txtMicron.My_MinValue = 0!
        Me.txtMicron.My_ReplaceWithDefaultValue = True
        Me.txtMicron.Name = "txtMicron"
        Me.txtMicron.Size = New System.Drawing.Size(82, 20)
        Me.txtMicron.TabIndex = 75
        Me.txtMicron.Text = "0"
        Me.txtMicron.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(297, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 15)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Altezza Micron"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Orange
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(50, 374)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 15)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "Tipo Costo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Orange
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(474, 374)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 15)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Costo Kg"
        '
        'txtPrezzoKg
        '
        Me.txtPrezzoKg.Location = New System.Drawing.Point(538, 371)
        Me.txtPrezzoKg.MaxLength = 50
        Me.txtPrezzoKg.My_AccettaNegativi = False
        Me.txtPrezzoKg.My_AllowOnlyInteger = False
        Me.txtPrezzoKg.My_DefaultValue = 0
        Me.txtPrezzoKg.My_MaxValue = 1.0E+10!
        Me.txtPrezzoKg.My_MinValue = 0!
        Me.txtPrezzoKg.My_ReplaceWithDefaultValue = True
        Me.txtPrezzoKg.Name = "txtPrezzoKg"
        Me.txtPrezzoKg.ReadOnly = True
        Me.txtPrezzoKg.Size = New System.Drawing.Size(68, 20)
        Me.txtPrezzoKg.TabIndex = 71
        Me.txtPrezzoKg.Text = "0"
        Me.txtPrezzoKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Orange
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Sigla"
        '
        'txtSigla
        '
        Me.txtSigla.Location = New System.Drawing.Point(169, 55)
        Me.txtSigla.MaxLength = 50
        Me.txtSigla.Name = "txtSigla"
        Me.txtSigla.Size = New System.Drawing.Size(82, 20)
        Me.txtSigla.TabIndex = 69
        Me.txtSigla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Orange
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 320)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Grammi"
        '
        'txtGrammi
        '
        Me.txtGrammi.Location = New System.Drawing.Point(169, 317)
        Me.txtGrammi.MaxLength = 50
        Me.txtGrammi.My_AccettaNegativi = False
        Me.txtGrammi.My_AllowOnlyInteger = True
        Me.txtGrammi.My_DefaultValue = 0
        Me.txtGrammi.My_MaxValue = 1.0E+10!
        Me.txtGrammi.My_MinValue = 0!
        Me.txtGrammi.My_ReplaceWithDefaultValue = True
        Me.txtGrammi.Name = "txtGrammi"
        Me.txtGrammi.Size = New System.Drawing.Size(82, 20)
        Me.txtGrammi.TabIndex = 67
        Me.txtGrammi.Text = "0"
        Me.txtGrammi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbFinitura
        '
        Me.cmbFinitura.FormattingEnabled = True
        Me.cmbFinitura.Location = New System.Drawing.Point(169, 288)
        Me.cmbFinitura.Name = "cmbFinitura"
        Me.cmbFinitura.Size = New System.Drawing.Size(299, 21)
        Me.cmbFinitura.TabIndex = 66
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 291)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Finitura"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(442, 261)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 21)
        Me.btnSearch.TabIndex = 61
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(50, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Immagine"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(492, 186)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 18)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "(128px - 128px)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Orange
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Descrizione"
        '
        'txtDescrizione
        '
        Me.txtDescrizione.Location = New System.Drawing.Point(169, 82)
        Me.txtDescrizione.MaxLength = 50
        Me.txtDescrizione.Name = "txtDescrizione"
        Me.txtDescrizione.Size = New System.Drawing.Size(299, 20)
        Me.txtDescrizione.TabIndex = 0
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(88, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Tipo Carta"
        '
        'tpCartaMagazzino
        '
        Me.tpCartaMagazzino.Controls.Add(Me.btnRimuovi)
        Me.tpCartaMagazzino.Controls.Add(Me.lnkAddRis)
        Me.tpCartaMagazzino.Controls.Add(Me.DgRiso)
        Me.tpCartaMagazzino.Controls.Add(Me.Label15)
        Me.tpCartaMagazzino.Controls.Add(Me.pctTipo)
        Me.tpCartaMagazzino.Location = New System.Drawing.Point(4, 22)
        Me.tpCartaMagazzino.Name = "tpCartaMagazzino"
        Me.tpCartaMagazzino.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCartaMagazzino.Size = New System.Drawing.Size(892, 677)
        Me.tpCartaMagazzino.TabIndex = 1
        Me.tpCartaMagazzino.Text = "Risorse Magazzino Collegate"
        Me.tpCartaMagazzino.UseVisualStyleBackColor = True
        '
        'btnRimuovi
        '
        Me.btnRimuovi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRimuovi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRimuovi.FlatAppearance.BorderSize = 0
        Me.btnRimuovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRimuovi.ForeColor = System.Drawing.Color.Black
        Me.btnRimuovi.Image = Global.Former.My.Resources.Resources._remove
        Me.btnRimuovi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRimuovi.Location = New System.Drawing.Point(795, 10)
        Me.btnRimuovi.Name = "btnRimuovi"
        Me.btnRimuovi.Size = New System.Drawing.Size(86, 30)
        Me.btnRimuovi.TabIndex = 152
        Me.btnRimuovi.TabStop = False
        Me.btnRimuovi.Text = "Rimuovi"
        Me.btnRimuovi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRimuovi.UseVisualStyleBackColor = True
        '
        'lnkAddRis
        '
        Me.lnkAddRis.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAddRis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.lnkAddRis.FlatAppearance.BorderSize = 0
        Me.lnkAddRis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkAddRis.ForeColor = System.Drawing.Color.Black
        Me.lnkAddRis.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAddRis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAddRis.Location = New System.Drawing.Point(698, 10)
        Me.lnkAddRis.Name = "lnkAddRis"
        Me.lnkAddRis.Size = New System.Drawing.Size(91, 30)
        Me.lnkAddRis.TabIndex = 151
        Me.lnkAddRis.TabStop = False
        Me.lnkAddRis.Text = "Aggiungi"
        Me.lnkAddRis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkAddRis.UseVisualStyleBackColor = True
        '
        'DgRiso
        '
        Me.DgRiso.AllowUserToAddRows = False
        Me.DgRiso.AllowUserToDeleteRows = False
        Me.DgRiso.AllowUserToOrderColumns = True
        Me.DgRiso.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRiso.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgRiso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgRiso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DgRiso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgRiso.BackgroundColor = System.Drawing.Color.White
        Me.DgRiso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgRiso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgRiso.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgRiso.ColumnHeadersHeight = 20
        Me.DgRiso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgRiso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdRis, Me.Risorsa, Me.TipoCartaCol, Me.Stato, Me.Giacenza})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRiso.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgRiso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgRiso.EnableHeadersVisualStyles = False
        Me.DgRiso.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgRiso.Location = New System.Drawing.Point(6, 46)
        Me.DgRiso.MultiSelect = False
        Me.DgRiso.Name = "DgRiso"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRiso.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgRiso.RowHeadersVisible = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRiso.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DgRiso.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgRiso.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgRiso.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRiso.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRiso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgRiso.Size = New System.Drawing.Size(880, 625)
        Me.DgRiso.TabIndex = 100
        Me.DgRiso.TabStop = False
        '
        'IdRis
        '
        Me.IdRis.DataPropertyName = "IdRis"
        Me.IdRis.HeaderText = "IdRis"
        Me.IdRis.Name = "IdRis"
        Me.IdRis.Width = 56
        '
        'Risorsa
        '
        Me.Risorsa.DataPropertyName = "Descrizione"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Format = "0.00"
        Me.Risorsa.DefaultCellStyle = DataGridViewCellStyle3
        Me.Risorsa.FillWeight = 500.0!
        Me.Risorsa.HeaderText = "Riassunto"
        Me.Risorsa.MinimumWidth = 300
        Me.Risorsa.Name = "Risorsa"
        Me.Risorsa.Width = 300
        '
        'TipoCartaCol
        '
        Me.TipoCartaCol.DataPropertyName = "RiassuntoTipoCarta"
        Me.TipoCartaCol.HeaderText = "Tipo Carta"
        Me.TipoCartaCol.MinimumWidth = 250
        Me.TipoCartaCol.Name = "TipoCartaCol"
        Me.TipoCartaCol.Width = 250
        '
        'Stato
        '
        Me.Stato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Stato.DataPropertyName = "StatoStr"
        Me.Stato.HeaderText = "Stato"
        Me.Stato.MinimumWidth = 80
        Me.Stato.Name = "Stato"
        Me.Stato.Width = 80
        '
        'Giacenza
        '
        Me.Giacenza.DataPropertyName = "Giacenza"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Giacenza.DefaultCellStyle = DataGridViewCellStyle4
        Me.Giacenza.HeaderText = "Giacenza"
        Me.Giacenza.Name = "Giacenza"
        Me.Giacenza.Width = 78
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(49, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(141, 21)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Risorse Collegate"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Risorsa
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 17
        Me.pctTipo.TabStop = False
        '
        'tpImpatto
        '
        Me.tpImpatto.Controls.Add(Me.UcListinoImpatto)
        Me.tpImpatto.Location = New System.Drawing.Point(4, 22)
        Me.tpImpatto.Name = "tpImpatto"
        Me.tpImpatto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpImpatto.Size = New System.Drawing.Size(892, 677)
        Me.tpImpatto.TabIndex = 2
        Me.tpImpatto.Text = "Influisce su..."
        Me.tpImpatto.UseVisualStyleBackColor = True
        '
        'UcListinoImpatto
        '
        Me.UcListinoImpatto.BackColor = System.Drawing.Color.White
        Me.UcListinoImpatto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcListinoImpatto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcListinoImpatto.Location = New System.Drawing.Point(3, 3)
        Me.UcListinoImpatto.Name = "UcListinoImpatto"
        Me.UcListinoImpatto.Size = New System.Drawing.Size(886, 671)
        Me.UcListinoImpatto.TabIndex = 0
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        '
        'frmListinoTipoCarta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(900, 751)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoTipoCarta"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Tipo Carta"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCartaMagazzino.ResumeLayout(False)
        Me.tpCartaMagazzino.PerformLayout()
        CType(Me.DgRiso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpImpatto.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pctImgLav As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtImgLav As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbFinitura As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSigla As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMicron As ucNumericTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtGrammi As ucNumericTextBox
    Friend WithEvents txtPrezzoKg As ucNumericTextBox
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lstTipiCarta As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescEst As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPrezzo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCostoRif As ucNumericTextBox
    Friend WithEvents tpCartaMagazzino As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DgRiso As System.Windows.Forms.DataGridView
    Friend WithEvents lnkAddRis As System.Windows.Forms.Button
    Friend WithEvents tpImpatto As System.Windows.Forms.TabPage
    Friend WithEvents UcListinoImpatto As Former.ucListinoImpatto
    Friend WithEvents lnkSuggerisci As LinkLabel
    Friend WithEvents Label17 As Label
    Friend WithEvents txtLarghezza As ucNumericTextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtAltezza As ucNumericTextBox
    Friend WithEvents btnRimuovi As Button
    Friend WithEvents UcPictureWizard As ucPictureWizard
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnHotFolder As Button
    Friend WithEvents txtPath As TextBox
    Friend WithEvents dlgFolder As FolderBrowserDialog
    Friend WithEvents IdRis As DataGridViewTextBoxColumn
    Friend WithEvents Risorsa As DataGridViewTextBoxColumn
    Friend WithEvents TipoCartaCol As DataGridViewTextBoxColumn
    Friend WithEvents Stato As DataGridViewTextBoxColumn
    Friend WithEvents Giacenza As DataGridViewTextBoxColumn
End Class
