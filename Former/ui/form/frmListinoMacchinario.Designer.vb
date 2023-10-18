<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoMacchinario
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
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.UcPictureWizard1 = New Former.ucPictureWizard()
        Me.pctImgBig = New System.Windows.Forms.PictureBox()
        Me.txtImgGrande = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnSearchImgGrande = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDescrizioneEstesa = New System.Windows.Forms.TextBox()
        Me.chkVisibileOnline = New System.Windows.Forms.CheckBox()
        Me.txtDescrizioneOnline = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.UcPictureWizard = New Former.ucPictureWizard()
        Me.pctImgLav = New System.Windows.Forms.PictureBox()
        Me.txtImgLav = New System.Windows.Forms.TextBox()
        Me.cmbReparto = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnHotFolder = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.txtAlertCommesse = New Former.ucNumericTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOrdinamento = New Former.ucNumericTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAltCaricoCm = New Former.ucNumericTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCopieOra = New Former.ucNumericTextBox()
        Me.txtMinutiAvv = New Former.ucNumericTextBox()
        Me.txtCaricoPrevMensile = New Former.ucNumericTextBox()
        Me.txtCostoMensile = New Former.ucNumericTextBox()
        Me.txtCostoSingCopia = New Former.ucNumericTextBox()
        Me.txtCostoMinAvv = New Former.ucNumericTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescrizione = New System.Windows.Forms.TextBox()
        Me.cmbTipoMacc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.dlgFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pctImgBig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 696)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(897, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(855, 17)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 24)
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
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.Location = New System.Drawing.Point(821, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 15
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
        Me.TabMain.Size = New System.Drawing.Size(897, 696)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label20)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.UcPictureWizard)
        Me.tbProd.Controls.Add(Me.cmbReparto)
        Me.tbProd.Controls.Add(Me.Label15)
        Me.tbProd.Controls.Add(Me.Label14)
        Me.tbProd.Controls.Add(Me.btnHotFolder)
        Me.tbProd.Controls.Add(Me.txtPath)
        Me.tbProd.Controls.Add(Me.txtAlertCommesse)
        Me.tbProd.Controls.Add(Me.Label13)
        Me.tbProd.Controls.Add(Me.txtOrdinamento)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.txtAltCaricoCm)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.txtCopieOra)
        Me.tbProd.Controls.Add(Me.txtMinutiAvv)
        Me.tbProd.Controls.Add(Me.txtCaricoPrevMensile)
        Me.tbProd.Controls.Add(Me.txtCostoMensile)
        Me.tbProd.Controls.Add(Me.txtCostoSingCopia)
        Me.tbProd.Controls.Add(Me.txtCostoMinAvv)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.pctImgLav)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.btnSearch)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.txtImgLav)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtDescrizione)
        Me.tbProd.Controls.Add(Me.cmbTipoMacc)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(889, 670)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Macchinario"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(267, 201)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(529, 15)
        Me.Label20.TabIndex = 193
        Me.Label20.Text = "(applicato al singolo pezzo se calcolato su copie, su metro quadro se applicato s" &
    "u metri quadri, ecc...)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.UcPictureWizard1)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.pctImgBig)
        Me.GroupBox1.Controls.Add(Me.btnSearchImgGrande)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtImgGrande)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtDescrizioneEstesa)
        Me.GroupBox1.Controls.Add(Me.chkVisibileOnline)
        Me.GroupBox1.Controls.Add(Me.txtDescrizioneOnline)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 447)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(854, 217)
        Me.GroupBox1.TabIndex = 192
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sito Web"
        '
        'UcPictureWizard1
        '
        Me.UcPictureWizard1.AutoSize = True
        Me.UcPictureWizard1.ImgHeight = 128
        Me.UcPictureWizard1.ImgWidth = 256
        Me.UcPictureWizard1.Location = New System.Drawing.Point(489, 77)
        Me.UcPictureWizard1.Name = "UcPictureWizard1"
        Me.UcPictureWizard1.PrefissoDaApplicare = ""
        Me.UcPictureWizard1.RifPictureBox = Me.pctImgBig
        Me.UcPictureWizard1.RifTextBoxPath = Me.txtImgGrande
        Me.UcPictureWizard1.Size = New System.Drawing.Size(77, 23)
        Me.UcPictureWizard1.TabIndex = 123
        '
        'pctImgBig
        '
        Me.pctImgBig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctImgBig.Location = New System.Drawing.Point(568, 22)
        Me.pctImgBig.Name = "pctImgBig"
        Me.pctImgBig.Size = New System.Drawing.Size(256, 128)
        Me.pctImgBig.TabIndex = 121
        Me.pctImgBig.TabStop = False
        '
        'txtImgGrande
        '
        Me.txtImgGrande.Location = New System.Drawing.Point(152, 78)
        Me.txtImgGrande.MaxLength = 50
        Me.txtImgGrande.Name = "txtImgGrande"
        Me.txtImgGrande.ReadOnly = True
        Me.txtImgGrande.Size = New System.Drawing.Size(299, 20)
        Me.txtImgGrande.TabIndex = 118
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(648, 153)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 18)
        Me.Label19.TabIndex = 122
        Me.Label19.Text = "(256px - 128px)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSearchImgGrande
        '
        Me.btnSearchImgGrande.Location = New System.Drawing.Point(457, 77)
        Me.btnSearchImgGrande.Name = "btnSearchImgGrande"
        Me.btnSearchImgGrande.Size = New System.Drawing.Size(26, 21)
        Me.btnSearchImgGrande.TabIndex = 120
        Me.btnSearchImgGrande.Text = "..."
        Me.btnSearchImgGrande.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(8, 78)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 15)
        Me.Label18.TabIndex = 119
        Me.Label18.Text = "Immagine Web"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Orange
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(8, 107)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(102, 15)
        Me.Label17.TabIndex = 117
        Me.Label17.Text = "Descrizione Estesa"
        '
        'txtDescrizioneEstesa
        '
        Me.txtDescrizioneEstesa.Location = New System.Drawing.Point(152, 104)
        Me.txtDescrizioneEstesa.MaxLength = 200
        Me.txtDescrizioneEstesa.Multiline = True
        Me.txtDescrizioneEstesa.Name = "txtDescrizioneEstesa"
        Me.txtDescrizioneEstesa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescrizioneEstesa.Size = New System.Drawing.Size(299, 50)
        Me.txtDescrizioneEstesa.TabIndex = 116
        '
        'chkVisibileOnline
        '
        Me.chkVisibileOnline.AutoSize = True
        Me.chkVisibileOnline.Location = New System.Drawing.Point(11, 22)
        Me.chkVisibileOnline.Name = "chkVisibileOnline"
        Me.chkVisibileOnline.Size = New System.Drawing.Size(101, 19)
        Me.chkVisibileOnline.TabIndex = 115
        Me.chkVisibileOnline.Text = "Visibile Online"
        Me.chkVisibileOnline.UseVisualStyleBackColor = True
        '
        'txtDescrizioneOnline
        '
        Me.txtDescrizioneOnline.Location = New System.Drawing.Point(152, 52)
        Me.txtDescrizioneOnline.MaxLength = 50
        Me.txtDescrizioneOnline.Name = "txtDescrizioneOnline"
        Me.txtDescrizioneOnline.Size = New System.Drawing.Size(299, 20)
        Me.txtDescrizioneOnline.TabIndex = 113
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(8, 55)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 15)
        Me.Label16.TabIndex = 114
        Me.Label16.Text = "Nome Online"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._HotFolder
        Me.PictureBox1.Location = New System.Drawing.Point(29, 405)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 191
        Me.PictureBox1.TabStop = False
        '
        'UcPictureWizard
        '
        Me.UcPictureWizard.AutoSize = True
        Me.UcPictureWizard.ImgHeight = 128
        Me.UcPictureWizard.ImgWidth = 128
        Me.UcPictureWizard.Location = New System.Drawing.Point(516, 142)
        Me.UcPictureWizard.Name = "UcPictureWizard"
        Me.UcPictureWizard.PrefissoDaApplicare = ""
        Me.UcPictureWizard.RifPictureBox = Me.pctImgLav
        Me.UcPictureWizard.RifTextBoxPath = Me.txtImgLav
        Me.UcPictureWizard.Size = New System.Drawing.Size(77, 23)
        Me.UcPictureWizard.TabIndex = 117
        '
        'pctImgLav
        '
        Me.pctImgLav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctImgLav.Location = New System.Drawing.Point(650, 64)
        Me.pctImgLav.Name = "pctImgLav"
        Me.pctImgLav.Size = New System.Drawing.Size(128, 128)
        Me.pctImgLav.TabIndex = 86
        Me.pctImgLav.TabStop = False
        '
        'txtImgLav
        '
        Me.txtImgLav.Location = New System.Drawing.Point(179, 144)
        Me.txtImgLav.MaxLength = 50
        Me.txtImgLav.Name = "txtImgLav"
        Me.txtImgLav.ReadOnly = True
        Me.txtImgLav.Size = New System.Drawing.Size(299, 20)
        Me.txtImgLav.TabIndex = 71
        '
        'cmbReparto
        '
        Me.cmbReparto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReparto.FormattingEnabled = True
        Me.cmbReparto.Location = New System.Drawing.Point(179, 91)
        Me.cmbReparto.Name = "cmbReparto"
        Me.cmbReparto.Size = New System.Drawing.Size(157, 21)
        Me.cmbReparto.TabIndex = 111
        Me.toolTipHelp.SetToolTip(Me.cmbReparto, "Il reparto di default è valido solo per i macchinari di tipo Produzione")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(26, 94)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 15)
        Me.Label15.TabIndex = 110
        Me.Label15.Text = "Reparto Default"
        Me.toolTipHelp.SetToolTip(Me.Label15, "Il reparto di default è valido solo per i macchinari di tipo Produzione")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(61, 413)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 15)
        Me.Label14.TabIndex = 108
        Me.Label14.Text = "HotFolder Flusso"
        '
        'btnHotFolder
        '
        Me.btnHotFolder.Location = New System.Drawing.Point(484, 410)
        Me.btnHotFolder.Name = "btnHotFolder"
        Me.btnHotFolder.Size = New System.Drawing.Size(26, 21)
        Me.btnHotFolder.TabIndex = 107
        Me.btnHotFolder.Text = "..."
        Me.btnHotFolder.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(179, 410)
        Me.txtPath.MaxLength = 50
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(299, 20)
        Me.txtPath.TabIndex = 106
        '
        'txtAlertCommesse
        '
        Me.txtAlertCommesse.Location = New System.Drawing.Point(179, 361)
        Me.txtAlertCommesse.MaxLength = 3
        Me.txtAlertCommesse.My_AccettaNegativi = False
        Me.txtAlertCommesse.My_AllowOnlyInteger = True
        Me.txtAlertCommesse.My_DefaultValue = 0
        Me.txtAlertCommesse.My_MaxValue = 100.0!
        Me.txtAlertCommesse.My_MinValue = 0!
        Me.txtAlertCommesse.My_ReplaceWithDefaultValue = True
        Me.txtAlertCommesse.Name = "txtAlertCommesse"
        Me.txtAlertCommesse.Size = New System.Drawing.Size(82, 20)
        Me.txtAlertCommesse.TabIndex = 105
        Me.txtAlertCommesse.Text = "0"
        Me.txtAlertCommesse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(26, 364)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 15)
        Me.Label13.TabIndex = 104
        Me.Label13.Text = "Alert N° Commesse"
        '
        'txtOrdinamento
        '
        Me.txtOrdinamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOrdinamento.Location = New System.Drawing.Point(179, 334)
        Me.txtOrdinamento.My_AccettaNegativi = False
        Me.txtOrdinamento.My_AllowOnlyInteger = True
        Me.txtOrdinamento.My_DefaultValue = 0
        Me.txtOrdinamento.My_MaxValue = 1.0E+10!
        Me.txtOrdinamento.My_MinValue = 0!
        Me.txtOrdinamento.My_ReplaceWithDefaultValue = True
        Me.txtOrdinamento.Name = "txtOrdinamento"
        Me.txtOrdinamento.ReadOnly = True
        Me.txtOrdinamento.Size = New System.Drawing.Size(82, 23)
        Me.txtOrdinamento.TabIndex = 97
        Me.txtOrdinamento.Text = "0"
        Me.txtOrdinamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.toolTipHelp.SetToolTip(Me.txtOrdinamento, "Controllo Dismesso")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(26, 337)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 15)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "Ordinamento"
        Me.toolTipHelp.SetToolTip(Me.Label12, "Controllo Dismesso")
        '
        'txtAltCaricoCm
        '
        Me.txtAltCaricoCm.Location = New System.Drawing.Point(179, 307)
        Me.txtAltCaricoCm.My_AccettaNegativi = False
        Me.txtAltCaricoCm.My_AllowOnlyInteger = True
        Me.txtAltCaricoCm.My_DefaultValue = 1
        Me.txtAltCaricoCm.My_MaxValue = 1.0E+10!
        Me.txtAltCaricoCm.My_MinValue = 1.0!
        Me.txtAltCaricoCm.My_ReplaceWithDefaultValue = True
        Me.txtAltCaricoCm.Name = "txtAltCaricoCm"
        Me.txtAltCaricoCm.Size = New System.Drawing.Size(82, 20)
        Me.txtAltCaricoCm.TabIndex = 95
        Me.txtAltCaricoCm.Text = "1"
        Me.txtAltCaricoCm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(26, 310)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 15)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "Altezza Carico (Cm)"
        '
        'txtCopieOra
        '
        Me.txtCopieOra.Location = New System.Drawing.Point(409, 280)
        Me.txtCopieOra.My_AccettaNegativi = False
        Me.txtCopieOra.My_AllowOnlyInteger = True
        Me.txtCopieOra.My_DefaultValue = 0
        Me.txtCopieOra.My_MaxValue = 1.0E+10!
        Me.txtCopieOra.My_MinValue = -1.0E+9!
        Me.txtCopieOra.My_ReplaceWithDefaultValue = True
        Me.txtCopieOra.Name = "txtCopieOra"
        Me.txtCopieOra.Size = New System.Drawing.Size(69, 20)
        Me.txtCopieOra.TabIndex = 93
        Me.txtCopieOra.Text = "0"
        Me.txtCopieOra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinutiAvv
        '
        Me.txtMinutiAvv.Location = New System.Drawing.Point(179, 280)
        Me.txtMinutiAvv.My_AccettaNegativi = False
        Me.txtMinutiAvv.My_AllowOnlyInteger = True
        Me.txtMinutiAvv.My_DefaultValue = 0
        Me.txtMinutiAvv.My_MaxValue = 1.0E+10!
        Me.txtMinutiAvv.My_MinValue = 0!
        Me.txtMinutiAvv.My_ReplaceWithDefaultValue = True
        Me.txtMinutiAvv.Name = "txtMinutiAvv"
        Me.txtMinutiAvv.Size = New System.Drawing.Size(82, 20)
        Me.txtMinutiAvv.TabIndex = 92
        Me.txtMinutiAvv.Text = "0"
        Me.txtMinutiAvv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCaricoPrevMensile
        '
        Me.txtCaricoPrevMensile.Location = New System.Drawing.Point(409, 225)
        Me.txtCaricoPrevMensile.My_AccettaNegativi = False
        Me.txtCaricoPrevMensile.My_AllowOnlyInteger = True
        Me.txtCaricoPrevMensile.My_DefaultValue = 0
        Me.txtCaricoPrevMensile.My_MaxValue = 1.0E+10!
        Me.txtCaricoPrevMensile.My_MinValue = -1.0E+9!
        Me.txtCaricoPrevMensile.My_ReplaceWithDefaultValue = True
        Me.txtCaricoPrevMensile.Name = "txtCaricoPrevMensile"
        Me.txtCaricoPrevMensile.Size = New System.Drawing.Size(69, 20)
        Me.txtCaricoPrevMensile.TabIndex = 91
        Me.txtCaricoPrevMensile.Text = "0"
        Me.txtCaricoPrevMensile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostoMensile
        '
        Me.txtCostoMensile.Location = New System.Drawing.Point(179, 225)
        Me.txtCostoMensile.My_AccettaNegativi = False
        Me.txtCostoMensile.My_AllowOnlyInteger = False
        Me.txtCostoMensile.My_DefaultValue = 0
        Me.txtCostoMensile.My_MaxValue = 1.0E+10!
        Me.txtCostoMensile.My_MinValue = -1.0E+9!
        Me.txtCostoMensile.My_ReplaceWithDefaultValue = True
        Me.txtCostoMensile.Name = "txtCostoMensile"
        Me.txtCostoMensile.Size = New System.Drawing.Size(82, 20)
        Me.txtCostoMensile.TabIndex = 90
        Me.txtCostoMensile.Text = "0"
        Me.txtCostoMensile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostoSingCopia
        '
        Me.txtCostoSingCopia.Location = New System.Drawing.Point(179, 198)
        Me.txtCostoSingCopia.My_AccettaNegativi = False
        Me.txtCostoSingCopia.My_AllowOnlyInteger = False
        Me.txtCostoSingCopia.My_DefaultValue = 0
        Me.txtCostoSingCopia.My_MaxValue = 1.0E+10!
        Me.txtCostoSingCopia.My_MinValue = 0!
        Me.txtCostoSingCopia.My_ReplaceWithDefaultValue = True
        Me.txtCostoSingCopia.Name = "txtCostoSingCopia"
        Me.txtCostoSingCopia.Size = New System.Drawing.Size(82, 20)
        Me.txtCostoSingCopia.TabIndex = 89
        Me.txtCostoSingCopia.Text = "0"
        Me.txtCostoSingCopia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostoMinAvv
        '
        Me.txtCostoMinAvv.Location = New System.Drawing.Point(179, 171)
        Me.txtCostoMinAvv.My_AccettaNegativi = False
        Me.txtCostoMinAvv.My_AllowOnlyInteger = False
        Me.txtCostoMinAvv.My_DefaultValue = 0
        Me.txtCostoMinAvv.My_MaxValue = 500.0!
        Me.txtCostoMinAvv.My_MinValue = 0!
        Me.txtCostoMinAvv.My_ReplaceWithDefaultValue = True
        Me.txtCostoMinAvv.Name = "txtCostoMinAvv"
        Me.txtCostoMinAvv.Size = New System.Drawing.Size(82, 20)
        Me.txtCostoMinAvv.TabIndex = 88
        Me.txtCostoMinAvv.Text = "0"
        Me.txtCostoMinAvv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(780, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 18)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "(128px - 128px)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(340, 283)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 15)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Copie Ora"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(26, 283)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 15)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Minuti Avviamento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(267, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 15)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "Carico Previsto Mensile"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(26, 228)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "Costo Mensile"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Orange
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(26, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Costo unitario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Orange
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(26, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 15)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Costo Minimo Avviamento"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(484, 144)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 21)
        Me.btnSearch.TabIndex = 73
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(26, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Immagine"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Orange
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(26, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Descrizione"
        '
        'txtDescrizione
        '
        Me.txtDescrizione.Location = New System.Drawing.Point(179, 118)
        Me.txtDescrizione.MaxLength = 50
        Me.txtDescrizione.Name = "txtDescrizione"
        Me.txtDescrizione.Size = New System.Drawing.Size(299, 20)
        Me.txtDescrizione.TabIndex = 69
        '
        'cmbTipoMacc
        '
        Me.cmbTipoMacc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMacc.FormattingEnabled = True
        Me.cmbTipoMacc.Location = New System.Drawing.Point(179, 64)
        Me.cmbTipoMacc.Name = "cmbTipoMacc"
        Me.cmbTipoMacc.Size = New System.Drawing.Size(157, 21)
        Me.cmbTipoMacc.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Orange
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(26, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Macchinari
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(48, 48)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(6, 6)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Padding = New System.Windows.Forms.Padding(50, 0, 0, 0)
        Me.lblTipo.Size = New System.Drawing.Size(875, 48)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Macchinario"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini PNG|*.png|Immagini JPG|*.jpg"
        '
        'frmListinoMacchinario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(897, 744)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoMacchinario"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Macchinario"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctImgBig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents cmbTipoMacc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtImgLav As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pctImgLav As System.Windows.Forms.PictureBox
    Friend WithEvents txtCopieOra As ucNumericTextBox
    Friend WithEvents txtMinutiAvv As ucNumericTextBox
    Friend WithEvents txtCaricoPrevMensile As ucNumericTextBox
    Friend WithEvents txtCostoMensile As ucNumericTextBox
    Friend WithEvents txtCostoSingCopia As ucNumericTextBox
    Friend WithEvents txtCostoMinAvv As ucNumericTextBox
    Friend WithEvents txtAltCaricoCm As ucNumericTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOrdinamento As ucNumericTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtAlertCommesse As ucNumericTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents btnHotFolder As Button
    Friend WithEvents txtPath As TextBox
    Friend WithEvents dlgFolder As FolderBrowserDialog
    Friend WithEvents cmbReparto As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents chkVisibileOnline As CheckBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtDescrizioneOnline As TextBox
    Friend WithEvents UcPictureWizard As ucPictureWizard
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnSearchImgGrande As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents txtImgGrande As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtDescrizioneEstesa As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents pctImgBig As PictureBox
    Friend WithEvents UcPictureWizard1 As ucPictureWizard
    Friend WithEvents Label20 As Label
End Class
