<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMagazzinoRisorsa
    Inherits baseFormInternaRedim

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMagazzinoRisorsa))
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.lblM2 = New System.Windows.Forms.Label()
        Me.cmbUnitaMisura = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnNewGruppo = New System.Windows.Forms.Button()
        Me.cmbGruppo = New Telerik.WinControls.UI.RadCheckedDropDownList()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.UcPictureWizard = New Former.ucPictureWizard()
        Me.pctFoto = New System.Windows.Forms.PictureBox()
        Me.txtFoto = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkStatoAttivo = New System.Windows.Forms.CheckBox()
        Me.chkLstMacchinari = New System.Windows.Forms.CheckedListBox()
        Me.chkProdottoFinito = New System.Windows.Forms.CheckBox()
        Me.pctRep = New System.Windows.Forms.PictureBox()
        Me.btnDettTipo = New System.Windows.Forms.Button()
        Me.lblGrammatura = New System.Windows.Forms.Label()
        Me.txtGrammatura = New Former.ucNumericTextBox()
        Me.btnNewTipo = New System.Windows.Forms.Button()
        Me.cmbTipoCarta = New System.Windows.Forms.ComboBox()
        Me.lblTipoCarta = New System.Windows.Forms.Label()
        Me.lblLunghezza = New System.Windows.Forms.Label()
        Me.txtLunghezza = New Former.ucNumericTextBox()
        Me.lblLarghezza = New System.Windows.Forms.Label()
        Me.txtLarghezza = New Former.ucNumericTextBox()
        Me.lblCostoVenduto = New System.Windows.Forms.Label()
        Me.txtCostoVenduto = New Former.ucNumericTextBox()
        Me.cmbTipoOff = New System.Windows.Forms.ComboBox()
        Me.lblTipoOffset = New System.Windows.Forms.Label()
        Me.lblCostoFoglioEsteso = New System.Windows.Forms.Label()
        Me.txtCostoFoglioSteso = New Former.ucNumericTextBox()
        Me.lblCostoTotale = New System.Windows.Forms.Label()
        Me.txtCostoTotale = New Former.ucNumericTextBox()
        Me.lblNumLastre = New System.Windows.Forms.Label()
        Me.txtNumLastre = New Former.ucNumericTextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtGiacenzaMin = New Former.ucNumericTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGiacenza = New System.Windows.Forms.TextBox()
        Me.cmbTipoRis = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodice = New System.Windows.Forms.TextBox()
        Me.lblReparto = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tbMovimenti = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoMgrMovimenti = New Former.ucMagazzinoMgrMovimenti()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.tpSottoScorta = New System.Windows.Forms.TabPage()
        Me.btnSearchPdf = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFilePDF = New System.Windows.Forms.TextBox()
        Me.txtQta = New Former.ucNumericTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbListini = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.rdoSSInviaMessaggio = New System.Windows.Forms.RadioButton()
        Me.rdoSSRiordina = New System.Windows.Forms.RadioButton()
        Me.rdoSSNoAzioni = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tpDecodificaVociCosto = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoDecodificaVociCosto = New Former.ucMagazzinoDecodificaVociCosto()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lnkRicalcola = New System.Windows.Forms.LinkLabel()
        Me.lnkPeso = New System.Windows.Forms.LinkLabel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.OpenFilePDF = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.cmbGruppo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctRep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMovimenti.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSottoScorta.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDecodificaVociCosto.SuspendLayout()
        Me.gbPulsanti.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tbMovimenti)
        Me.TabMain.Controls.Add(Me.tpSottoScorta)
        Me.TabMain.Controls.Add(Me.tpDecodificaVociCosto)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1098, 639)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblM2)
        Me.tbProd.Controls.Add(Me.cmbUnitaMisura)
        Me.tbProd.Controls.Add(Me.Label18)
        Me.tbProd.Controls.Add(Me.btnNewGruppo)
        Me.tbProd.Controls.Add(Me.cmbGruppo)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.UcPictureWizard)
        Me.tbProd.Controls.Add(Me.btnSearch)
        Me.tbProd.Controls.Add(Me.Label17)
        Me.tbProd.Controls.Add(Me.pctFoto)
        Me.tbProd.Controls.Add(Me.PictureBox3)
        Me.tbProd.Controls.Add(Me.Label16)
        Me.tbProd.Controls.Add(Me.txtFoto)
        Me.tbProd.Controls.Add(Me.PictureBox2)
        Me.tbProd.Controls.Add(Me.txtBarCode)
        Me.tbProd.Controls.Add(Me.Label13)
        Me.tbProd.Controls.Add(Me.cmbCategoria)
        Me.tbProd.Controls.Add(Me.lblCategoria)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.chkStatoAttivo)
        Me.tbProd.Controls.Add(Me.chkLstMacchinari)
        Me.tbProd.Controls.Add(Me.chkProdottoFinito)
        Me.tbProd.Controls.Add(Me.pctRep)
        Me.tbProd.Controls.Add(Me.btnDettTipo)
        Me.tbProd.Controls.Add(Me.lblGrammatura)
        Me.tbProd.Controls.Add(Me.txtGrammatura)
        Me.tbProd.Controls.Add(Me.btnNewTipo)
        Me.tbProd.Controls.Add(Me.cmbTipoCarta)
        Me.tbProd.Controls.Add(Me.lblTipoCarta)
        Me.tbProd.Controls.Add(Me.lblLunghezza)
        Me.tbProd.Controls.Add(Me.txtLunghezza)
        Me.tbProd.Controls.Add(Me.lblLarghezza)
        Me.tbProd.Controls.Add(Me.txtLarghezza)
        Me.tbProd.Controls.Add(Me.lblCostoVenduto)
        Me.tbProd.Controls.Add(Me.txtCostoVenduto)
        Me.tbProd.Controls.Add(Me.cmbTipoOff)
        Me.tbProd.Controls.Add(Me.lblTipoOffset)
        Me.tbProd.Controls.Add(Me.lblCostoFoglioEsteso)
        Me.tbProd.Controls.Add(Me.txtCostoFoglioSteso)
        Me.tbProd.Controls.Add(Me.lblCostoTotale)
        Me.tbProd.Controls.Add(Me.txtCostoTotale)
        Me.tbProd.Controls.Add(Me.lblNumLastre)
        Me.tbProd.Controls.Add(Me.txtNumLastre)
        Me.tbProd.Controls.Add(Me.Label40)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtGiacenzaMin)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtGiacenza)
        Me.tbProd.Controls.Add(Me.cmbTipoRis)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtDescr)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtCodice)
        Me.tbProd.Controls.Add(Me.lblReparto)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1090, 613)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Risorsa"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lblM2
        '
        Me.lblM2.AutoSize = True
        Me.lblM2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblM2.ForeColor = System.Drawing.Color.Black
        Me.lblM2.Location = New System.Drawing.Point(785, 225)
        Me.lblM2.Name = "lblM2"
        Me.lblM2.Size = New System.Drawing.Size(12, 15)
        Me.lblM2.TabIndex = 126
        Me.lblM2.Text = "-"
        '
        'cmbUnitaMisura
        '
        Me.cmbUnitaMisura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnitaMisura.FormattingEnabled = True
        Me.cmbUnitaMisura.Location = New System.Drawing.Point(662, 78)
        Me.cmbUnitaMisura.Name = "cmbUnitaMisura"
        Me.cmbUnitaMisura.Size = New System.Drawing.Size(75, 21)
        Me.cmbUnitaMisura.TabIndex = 125
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(628, 81)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(31, 15)
        Me.Label18.TabIndex = 123
        Me.Label18.Text = "U.M."
        '
        'btnNewGruppo
        '
        Me.btnNewGruppo.Location = New System.Drawing.Point(631, 160)
        Me.btnNewGruppo.Name = "btnNewGruppo"
        Me.btnNewGruppo.Size = New System.Drawing.Size(75, 23)
        Me.btnNewGruppo.TabIndex = 122
        Me.btnNewGruppo.Text = "Nuovo"
        Me.btnNewGruppo.UseVisualStyleBackColor = True
        '
        'cmbGruppo
        '
        Me.cmbGruppo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbGruppo.Location = New System.Drawing.Point(207, 162)
        Me.cmbGruppo.Name = "cmbGruppo"
        Me.cmbGruppo.Size = New System.Drawing.Size(418, 20)
        Me.cmbGruppo.TabIndex = 121
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(61, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 15)
        Me.Label11.TabIndex = 120
        Me.Label11.Text = "Gruppi"
        '
        'UcPictureWizard
        '
        Me.UcPictureWizard.AutoSize = True
        Me.UcPictureWizard.ImgHeight = 128
        Me.UcPictureWizard.ImgWidth = 128
        Me.UcPictureWizard.Location = New System.Drawing.Point(817, 317)
        Me.UcPictureWizard.Name = "UcPictureWizard"
        Me.UcPictureWizard.RifPictureBox = Me.pctFoto
        Me.UcPictureWizard.RifTextBoxPath = Me.txtFoto
        Me.UcPictureWizard.Size = New System.Drawing.Size(77, 23)
        Me.UcPictureWizard.TabIndex = 118
        '
        'pctFoto
        '
        Me.pctFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctFoto.Location = New System.Drawing.Point(919, 212)
        Me.pctFoto.Name = "pctFoto"
        Me.pctFoto.Size = New System.Drawing.Size(128, 128)
        Me.pctFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctFoto.TabIndex = 86
        Me.pctFoto.TabStop = False
        '
        'txtFoto
        '
        Me.txtFoto.Location = New System.Drawing.Point(207, 319)
        Me.txtFoto.MaxLength = 30
        Me.txtFoto.Name = "txtFoto"
        Me.txtFoto.ReadOnly = True
        Me.txtFoto.Size = New System.Drawing.Size(572, 20)
        Me.txtFoto.TabIndex = 83
        Me.toolTipHelp.SetToolTip(Me.txtFoto, "Indicare marca - grammatura - dimensioni")
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(785, 319)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 21)
        Me.btnSearch.TabIndex = 88
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(932, 343)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 18)
        Me.Label17.TabIndex = 87
        Me.Label17.Text = "(128px - 128px)"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Former.My.Resources.Resources._Foto
        Me.PictureBox3.Location = New System.Drawing.Point(64, 319)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 85
        Me.PictureBox3.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(94, 322)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 15)
        Me.Label16.TabIndex = 84
        Me.Label16.Text = "Foto"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources._barcode
        Me.PictureBox2.Location = New System.Drawing.Point(64, 292)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 20)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 82
        Me.PictureBox2.TabStop = False
        '
        'txtBarCode
        '
        Me.txtBarCode.Location = New System.Drawing.Point(207, 292)
        Me.txtBarCode.MaxLength = 30
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(218, 20)
        Me.txtBarCode.TabIndex = 81
        Me.toolTipHelp.SetToolTip(Me.txtBarCode, "Indicare marca - grammatura - dimensioni")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(94, 295)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 15)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "Barcode"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(207, 105)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(218, 21)
        Me.cmbCategoria.TabIndex = 79
        Me.cmbCategoria.Visible = False
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblCategoria.ForeColor = System.Drawing.Color.Black
        Me.lblCategoria.Location = New System.Drawing.Point(61, 108)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(61, 15)
        Me.lblCategoria.TabIndex = 78
        Me.lblCategoria.Text = "Categoria"
        Me.lblCategoria.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(61, 353)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 15)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "Macchinari compatibili"
        '
        'chkStatoAttivo
        '
        Me.chkStatoAttivo.AutoSize = True
        Me.chkStatoAttivo.BackColor = System.Drawing.Color.Green
        Me.chkStatoAttivo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkStatoAttivo.ForeColor = System.Drawing.Color.White
        Me.chkStatoAttivo.Location = New System.Drawing.Point(712, 11)
        Me.chkStatoAttivo.Name = "chkStatoAttivo"
        Me.chkStatoAttivo.Size = New System.Drawing.Size(67, 19)
        Me.chkStatoAttivo.TabIndex = 77
        Me.chkStatoAttivo.Text = "ATTIVO"
        Me.toolTipHelp.SetToolTip(Me.chkStatoAttivo, "I prodotti finiti non possono essere tagliati o suddivisi e di fatto ne viene uti" &
        "lizzato uno per ogni prodotto realizzato")
        Me.chkStatoAttivo.UseVisualStyleBackColor = False
        '
        'chkLstMacchinari
        '
        Me.chkLstMacchinari.CheckOnClick = True
        Me.chkLstMacchinari.FormattingEnabled = True
        Me.chkLstMacchinari.Location = New System.Drawing.Point(207, 353)
        Me.chkLstMacchinari.Name = "chkLstMacchinari"
        Me.chkLstMacchinari.Size = New System.Drawing.Size(572, 256)
        Me.chkLstMacchinari.TabIndex = 73
        '
        'chkProdottoFinito
        '
        Me.chkProdottoFinito.AutoSize = True
        Me.chkProdottoFinito.Location = New System.Drawing.Point(468, 107)
        Me.chkProdottoFinito.Name = "chkProdottoFinito"
        Me.chkProdottoFinito.Size = New System.Drawing.Size(133, 19)
        Me.chkProdottoFinito.TabIndex = 76
        Me.chkProdottoFinito.Text = "E' un prodotto finito"
        Me.toolTipHelp.SetToolTip(Me.chkProdottoFinito, "I prodotti finiti non possono essere tagliati o suddivisi e di fatto ne viene uti" &
        "lizzato uno per ogni prodotto realizzato")
        Me.chkProdottoFinito.UseVisualStyleBackColor = True
        '
        'pctRep
        '
        Me.pctRep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctRep.Image = Global.Former.My.Resources.Resources.icoRis
        Me.pctRep.Location = New System.Drawing.Point(883, 6)
        Me.pctRep.Name = "pctRep"
        Me.pctRep.Size = New System.Drawing.Size(200, 200)
        Me.pctRep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctRep.TabIndex = 75
        Me.pctRep.TabStop = False
        '
        'btnDettTipo
        '
        Me.btnDettTipo.Location = New System.Drawing.Point(631, 132)
        Me.btnDettTipo.Name = "btnDettTipo"
        Me.btnDettTipo.Size = New System.Drawing.Size(25, 23)
        Me.btnDettTipo.TabIndex = 72
        Me.btnDettTipo.Text = "..."
        Me.btnDettTipo.UseVisualStyleBackColor = True
        '
        'lblGrammatura
        '
        Me.lblGrammatura.AutoSize = True
        Me.lblGrammatura.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblGrammatura.ForeColor = System.Drawing.Color.Black
        Me.lblGrammatura.Location = New System.Drawing.Point(586, 225)
        Me.lblGrammatura.Name = "lblGrammatura"
        Me.lblGrammatura.Size = New System.Drawing.Size(77, 15)
        Me.lblGrammatura.TabIndex = 71
        Me.lblGrammatura.Text = "Grammatura"
        '
        'txtGrammatura
        '
        Me.txtGrammatura.My_AccettaNegativi = False
        Me.txtGrammatura.My_DefaultValue = 0
        Me.txtGrammatura.Location = New System.Drawing.Point(669, 222)
        Me.txtGrammatura.MaxLength = 20
        Me.txtGrammatura.My_MaxValue = 1.0E+10!
        Me.txtGrammatura.My_MinValue = 0!
        Me.txtGrammatura.Name = "txtGrammatura"
        Me.txtGrammatura.My_AllowOnlyInteger = True
        Me.txtGrammatura.My_ReplaceWithDefaultValue = True
        Me.txtGrammatura.Size = New System.Drawing.Size(110, 20)
        Me.txtGrammatura.TabIndex = 12
        Me.txtGrammatura.Text = "0"
        Me.txtGrammatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnNewTipo
        '
        Me.btnNewTipo.Location = New System.Drawing.Point(662, 132)
        Me.btnNewTipo.Name = "btnNewTipo"
        Me.btnNewTipo.Size = New System.Drawing.Size(75, 23)
        Me.btnNewTipo.TabIndex = 5
        Me.btnNewTipo.Text = "Nuovo"
        Me.btnNewTipo.UseVisualStyleBackColor = True
        '
        'cmbTipoCarta
        '
        Me.cmbTipoCarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCarta.FormattingEnabled = True
        Me.cmbTipoCarta.Location = New System.Drawing.Point(207, 132)
        Me.cmbTipoCarta.Name = "cmbTipoCarta"
        Me.cmbTipoCarta.Size = New System.Drawing.Size(418, 21)
        Me.cmbTipoCarta.TabIndex = 4
        '
        'lblTipoCarta
        '
        Me.lblTipoCarta.AutoSize = True
        Me.lblTipoCarta.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblTipoCarta.ForeColor = System.Drawing.Color.Black
        Me.lblTipoCarta.Location = New System.Drawing.Point(61, 135)
        Me.lblTipoCarta.Name = "lblTipoCarta"
        Me.lblTipoCarta.Size = New System.Drawing.Size(139, 15)
        Me.lblTipoCarta.TabIndex = 67
        Me.lblTipoCarta.Text = "Tipo Carta listino Online"
        '
        'lblLunghezza
        '
        Me.lblLunghezza.AutoSize = True
        Me.lblLunghezza.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblLunghezza.ForeColor = System.Drawing.Color.Black
        Me.lblLunghezza.Location = New System.Drawing.Point(332, 225)
        Me.lblLunghezza.Name = "lblLunghezza"
        Me.lblLunghezza.Size = New System.Drawing.Size(72, 15)
        Me.lblLunghezza.TabIndex = 65
        Me.lblLunghezza.Text = "Altezza (cm)"
        '
        'txtLunghezza
        '
        Me.txtLunghezza.My_AccettaNegativi = False
        Me.txtLunghezza.My_DefaultValue = 0
        Me.txtLunghezza.Location = New System.Drawing.Point(432, 222)
        Me.txtLunghezza.MaxLength = 20
        Me.txtLunghezza.My_MaxValue = 1.0E+10!
        Me.txtLunghezza.My_MinValue = 0!
        Me.txtLunghezza.Name = "txtLunghezza"
        Me.txtLunghezza.My_AllowOnlyInteger = False
        Me.txtLunghezza.My_ReplaceWithDefaultValue = True
        Me.txtLunghezza.Size = New System.Drawing.Size(110, 20)
        Me.txtLunghezza.TabIndex = 11
        Me.txtLunghezza.Text = "0"
        Me.txtLunghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLarghezza
        '
        Me.lblLarghezza.AutoSize = True
        Me.lblLarghezza.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblLarghezza.ForeColor = System.Drawing.Color.Black
        Me.lblLarghezza.Location = New System.Drawing.Point(61, 225)
        Me.lblLarghezza.Name = "lblLarghezza"
        Me.lblLarghezza.Size = New System.Drawing.Size(91, 15)
        Me.lblLarghezza.TabIndex = 63
        Me.lblLarghezza.Text = "Larghezza (cm)"
        '
        'txtLarghezza
        '
        Me.txtLarghezza.My_AccettaNegativi = False
        Me.txtLarghezza.My_DefaultValue = 0
        Me.txtLarghezza.Location = New System.Drawing.Point(207, 222)
        Me.txtLarghezza.MaxLength = 20
        Me.txtLarghezza.My_MaxValue = 1.0E+10!
        Me.txtLarghezza.My_MinValue = 0!
        Me.txtLarghezza.Name = "txtLarghezza"
        Me.txtLarghezza.My_AllowOnlyInteger = False
        Me.txtLarghezza.My_ReplaceWithDefaultValue = True
        Me.txtLarghezza.Size = New System.Drawing.Size(110, 20)
        Me.txtLarghezza.TabIndex = 10
        Me.txtLarghezza.Text = "0"
        Me.txtLarghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCostoVenduto
        '
        Me.lblCostoVenduto.AutoSize = True
        Me.lblCostoVenduto.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblCostoVenduto.ForeColor = System.Drawing.Color.Black
        Me.lblCostoVenduto.Location = New System.Drawing.Point(548, 199)
        Me.lblCostoVenduto.Name = "lblCostoVenduto"
        Me.lblCostoVenduto.Size = New System.Drawing.Size(115, 15)
        Me.lblCostoVenduto.TabIndex = 59
        Me.lblCostoVenduto.Text = "Costo venduto (mq)"
        '
        'txtCostoVenduto
        '
        Me.txtCostoVenduto.My_AccettaNegativi = False
        Me.txtCostoVenduto.My_DefaultValue = 0
        Me.txtCostoVenduto.Location = New System.Drawing.Point(669, 196)
        Me.txtCostoVenduto.MaxLength = 20
        Me.txtCostoVenduto.My_MaxValue = 0!
        Me.txtCostoVenduto.My_MinValue = -1.0E+9!
        Me.txtCostoVenduto.Name = "txtCostoVenduto"
        Me.txtCostoVenduto.My_AllowOnlyInteger = False
        Me.txtCostoVenduto.My_ReplaceWithDefaultValue = True
        Me.txtCostoVenduto.Size = New System.Drawing.Size(110, 20)
        Me.txtCostoVenduto.TabIndex = 9
        Me.txtCostoVenduto.Text = "0"
        Me.txtCostoVenduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoOff
        '
        Me.cmbTipoOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoOff.FormattingEnabled = True
        Me.cmbTipoOff.Location = New System.Drawing.Point(468, 78)
        Me.cmbTipoOff.Name = "cmbTipoOff"
        Me.cmbTipoOff.Size = New System.Drawing.Size(157, 21)
        Me.cmbTipoOff.TabIndex = 3
        '
        'lblTipoOffset
        '
        Me.lblTipoOffset.AutoSize = True
        Me.lblTipoOffset.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblTipoOffset.ForeColor = System.Drawing.Color.Black
        Me.lblTipoOffset.Location = New System.Drawing.Point(431, 81)
        Me.lblTipoOffset.Name = "lblTipoOffset"
        Me.lblTipoOffset.Size = New System.Drawing.Size(31, 15)
        Me.lblTipoOffset.TabIndex = 56
        Me.lblTipoOffset.Text = "Tipo"
        '
        'lblCostoFoglioEsteso
        '
        Me.lblCostoFoglioEsteso.AutoSize = True
        Me.lblCostoFoglioEsteso.Enabled = False
        Me.lblCostoFoglioEsteso.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblCostoFoglioEsteso.ForeColor = System.Drawing.Color.Black
        Me.lblCostoFoglioEsteso.Location = New System.Drawing.Point(323, 199)
        Me.lblCostoFoglioEsteso.Name = "lblCostoFoglioEsteso"
        Me.lblCostoFoglioEsteso.Size = New System.Drawing.Size(107, 15)
        Me.lblCostoFoglioEsteso.TabIndex = 54
        Me.lblCostoFoglioEsteso.Text = "Costo foglio steso"
        '
        'txtCostoFoglioSteso
        '
        Me.txtCostoFoglioSteso.My_AccettaNegativi = False
        Me.txtCostoFoglioSteso.My_DefaultValue = 0
        Me.txtCostoFoglioSteso.Enabled = False
        Me.txtCostoFoglioSteso.Location = New System.Drawing.Point(432, 196)
        Me.txtCostoFoglioSteso.MaxLength = 20
        Me.txtCostoFoglioSteso.My_MaxValue = 0!
        Me.txtCostoFoglioSteso.My_MinValue = -1.0E+9!
        Me.txtCostoFoglioSteso.Name = "txtCostoFoglioSteso"
        Me.txtCostoFoglioSteso.My_AllowOnlyInteger = False
        Me.txtCostoFoglioSteso.My_ReplaceWithDefaultValue = True
        Me.txtCostoFoglioSteso.Size = New System.Drawing.Size(110, 20)
        Me.txtCostoFoglioSteso.TabIndex = 8
        Me.txtCostoFoglioSteso.Text = "0"
        Me.txtCostoFoglioSteso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCostoTotale
        '
        Me.lblCostoTotale.AutoSize = True
        Me.lblCostoTotale.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblCostoTotale.ForeColor = System.Drawing.Color.Black
        Me.lblCostoTotale.Location = New System.Drawing.Point(61, 199)
        Me.lblCostoTotale.Name = "lblCostoTotale"
        Me.lblCostoTotale.Size = New System.Drawing.Size(73, 15)
        Me.lblCostoTotale.TabIndex = 52
        Me.lblCostoTotale.Text = "Costo totale"
        '
        'txtCostoTotale
        '
        Me.txtCostoTotale.My_AccettaNegativi = False
        Me.txtCostoTotale.My_DefaultValue = 0
        Me.txtCostoTotale.Location = New System.Drawing.Point(207, 196)
        Me.txtCostoTotale.MaxLength = 20
        Me.txtCostoTotale.My_MaxValue = 0!
        Me.txtCostoTotale.My_MinValue = -1.0E+9!
        Me.txtCostoTotale.Name = "txtCostoTotale"
        Me.txtCostoTotale.My_AllowOnlyInteger = False
        Me.txtCostoTotale.My_ReplaceWithDefaultValue = True
        Me.txtCostoTotale.Size = New System.Drawing.Size(110, 20)
        Me.txtCostoTotale.TabIndex = 6
        Me.txtCostoTotale.Text = "0"
        Me.txtCostoTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumLastre
        '
        Me.lblNumLastre.AutoSize = True
        Me.lblNumLastre.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblNumLastre.ForeColor = System.Drawing.Color.Black
        Me.lblNumLastre.Location = New System.Drawing.Point(429, 274)
        Me.lblNumLastre.Name = "lblNumLastre"
        Me.lblNumLastre.Size = New System.Drawing.Size(90, 15)
        Me.lblNumLastre.TabIndex = 50
        Me.lblNumLastre.Text = "Numero Lastre"
        Me.lblNumLastre.Visible = False
        '
        'txtNumLastre
        '
        Me.txtNumLastre.My_AccettaNegativi = False
        Me.txtNumLastre.My_DefaultValue = 0
        Me.txtNumLastre.Location = New System.Drawing.Point(432, 292)
        Me.txtNumLastre.MaxLength = 20
        Me.txtNumLastre.My_MaxValue = 1.0E+10!
        Me.txtNumLastre.My_MinValue = 0!
        Me.txtNumLastre.Name = "txtNumLastre"
        Me.txtNumLastre.My_AllowOnlyInteger = True
        Me.txtNumLastre.ReadOnly = True
        Me.txtNumLastre.My_ReplaceWithDefaultValue = True
        Me.txtNumLastre.Size = New System.Drawing.Size(110, 20)
        Me.txtNumLastre.TabIndex = 7
        Me.txtNumLastre.Text = "0"
        Me.txtNumLastre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNumLastre.Visible = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(548, 251)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(240, 15)
        Me.Label40.TabIndex = 46
        Me.Label40.Text = "* (lasciando 0 non sarà gestito il sottoscorta)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(323, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Giacenza minima"
        '
        'txtGiacenzaMin
        '
        Me.txtGiacenzaMin.My_AccettaNegativi = False
        Me.txtGiacenzaMin.My_DefaultValue = 0
        Me.txtGiacenzaMin.Location = New System.Drawing.Point(432, 248)
        Me.txtGiacenzaMin.MaxLength = 20
        Me.txtGiacenzaMin.My_MaxValue = 1.0E+10!
        Me.txtGiacenzaMin.My_MinValue = 0!
        Me.txtGiacenzaMin.Name = "txtGiacenzaMin"
        Me.txtGiacenzaMin.My_AllowOnlyInteger = True
        Me.txtGiacenzaMin.My_ReplaceWithDefaultValue = True
        Me.txtGiacenzaMin.Size = New System.Drawing.Size(110, 20)
        Me.txtGiacenzaMin.TabIndex = 14
        Me.txtGiacenzaMin.Text = "0"
        Me.txtGiacenzaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(61, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Giacenza"
        '
        'txtGiacenza
        '
        Me.txtGiacenza.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtGiacenza.Location = New System.Drawing.Point(207, 248)
        Me.txtGiacenza.MaxLength = 20
        Me.txtGiacenza.Name = "txtGiacenza"
        Me.txtGiacenza.ReadOnly = True
        Me.txtGiacenza.Size = New System.Drawing.Size(110, 21)
        Me.txtGiacenza.TabIndex = 13
        Me.txtGiacenza.Text = "0"
        Me.txtGiacenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoRis
        '
        Me.cmbTipoRis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoRis.FormattingEnabled = True
        Me.cmbTipoRis.Location = New System.Drawing.Point(207, 78)
        Me.cmbTipoRis.Name = "cmbTipoRis"
        Me.cmbTipoRis.Size = New System.Drawing.Size(218, 21)
        Me.cmbTipoRis.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(61, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo Risorsa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(61, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Descrizione del prodotto"
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(207, 51)
        Me.txtDescr.MaxLength = 100
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(418, 20)
        Me.txtDescr.TabIndex = 1
        Me.toolTipHelp.SetToolTip(Me.txtDescr, "Indicare marca - grammatura - dimensioni")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(17, 444)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Codice Interno"
        Me.Label7.Visible = False
        '
        'txtCodice
        '
        Me.txtCodice.Location = New System.Drawing.Point(19, 461)
        Me.txtCodice.MaxLength = 50
        Me.txtCodice.Name = "txtCodice"
        Me.txtCodice.Size = New System.Drawing.Size(157, 20)
        Me.txtCodice.TabIndex = 0
        Me.txtCodice.Visible = False
        '
        'lblReparto
        '
        Me.lblReparto.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReparto.ForeColor = System.Drawing.Color.White
        Me.lblReparto.Location = New System.Drawing.Point(193, 6)
        Me.lblReparto.Name = "lblReparto"
        Me.lblReparto.Size = New System.Drawing.Size(394, 34)
        Me.lblReparto.TabIndex = 15
        Me.lblReparto.Text = "-"
        Me.lblReparto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Risorsa
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(48, 48)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(60, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(75, 22)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Risorsa"
        '
        'tbMovimenti
        '
        Me.tbMovimenti.Controls.Add(Me.UcMagazzinoMgrMovimenti)
        Me.tbMovimenti.Controls.Add(Me.Label3)
        Me.tbMovimenti.Controls.Add(Me.Label6)
        Me.tbMovimenti.Controls.Add(Me.PictureBox4)
        Me.tbMovimenti.Location = New System.Drawing.Point(4, 22)
        Me.tbMovimenti.Name = "tbMovimenti"
        Me.tbMovimenti.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMovimenti.Size = New System.Drawing.Size(1090, 613)
        Me.tbMovimenti.TabIndex = 1
        Me.tbMovimenti.Text = "Movimenti"
        Me.tbMovimenti.UseVisualStyleBackColor = True
        '
        'UcMagazzinoMgrMovimenti
        '
        Me.UcMagazzinoMgrMovimenti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcMagazzinoMgrMovimenti.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoMgrMovimenti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoMgrMovimenti.IdRis = 0
        Me.UcMagazzinoMgrMovimenti.Location = New System.Drawing.Point(53, 64)
        Me.UcMagazzinoMgrMovimenti.Name = "UcMagazzinoMgrMovimenti"
        Me.UcMagazzinoMgrMovimenti.OnlyMaterialeDiConsumo = False
        Me.UcMagazzinoMgrMovimenti.OnlyRichiesteAcquistoInCoda = False
        Me.UcMagazzinoMgrMovimenti.Size = New System.Drawing.Size(1029, 543)
        Me.UcMagazzinoMgrMovimenti.TabIndex = 55
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label3.Location = New System.Drawing.Point(49, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 22)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Magazzino"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(154, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(764, 22)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "In questa schermata vengono visualizzati tutti i movimenti di magazzino di questa" &
    " risorsa."
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.Former.My.Resources.Resources._Magazzino
        Me.PictureBox4.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox4.TabIndex = 53
        Me.PictureBox4.TabStop = False
        '
        'tpSottoScorta
        '
        Me.tpSottoScorta.Controls.Add(Me.btnSearchPdf)
        Me.tpSottoScorta.Controls.Add(Me.Label15)
        Me.tpSottoScorta.Controls.Add(Me.txtFilePDF)
        Me.tpSottoScorta.Controls.Add(Me.txtQta)
        Me.tpSottoScorta.Controls.Add(Me.Label12)
        Me.tpSottoScorta.Controls.Add(Me.cmbListini)
        Me.tpSottoScorta.Controls.Add(Me.Label14)
        Me.tpSottoScorta.Controls.Add(Me.rdoSSInviaMessaggio)
        Me.tpSottoScorta.Controls.Add(Me.rdoSSRiordina)
        Me.tpSottoScorta.Controls.Add(Me.rdoSSNoAzioni)
        Me.tpSottoScorta.Controls.Add(Me.Label9)
        Me.tpSottoScorta.Controls.Add(Me.Label10)
        Me.tpSottoScorta.Controls.Add(Me.PictureBox1)
        Me.tpSottoScorta.Location = New System.Drawing.Point(4, 22)
        Me.tpSottoScorta.Name = "tpSottoScorta"
        Me.tpSottoScorta.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSottoScorta.Size = New System.Drawing.Size(1090, 613)
        Me.tpSottoScorta.TabIndex = 2
        Me.tpSottoScorta.Text = "Sottoscorta"
        Me.tpSottoScorta.UseVisualStyleBackColor = True
        '
        'btnSearchPdf
        '
        Me.btnSearchPdf.Location = New System.Drawing.Point(661, 269)
        Me.btnSearchPdf.Name = "btnSearchPdf"
        Me.btnSearchPdf.Size = New System.Drawing.Size(26, 21)
        Me.btnSearchPdf.TabIndex = 70
        Me.btnSearchPdf.Text = "..."
        Me.btnSearchPdf.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(82, 272)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 15)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "File PDF"
        '
        'txtFilePDF
        '
        Me.txtFilePDF.Location = New System.Drawing.Point(176, 269)
        Me.txtFilePDF.Name = "txtFilePDF"
        Me.txtFilePDF.ReadOnly = True
        Me.txtFilePDF.Size = New System.Drawing.Size(479, 20)
        Me.txtFilePDF.TabIndex = 69
        Me.txtFilePDF.TabStop = False
        '
        'txtQta
        '
        Me.txtQta.My_AccettaNegativi = False
        Me.txtQta.My_DefaultValue = 1
        Me.txtQta.Location = New System.Drawing.Point(176, 242)
        Me.txtQta.MaxLength = 6
        Me.txtQta.My_MaxValue = 999999.0!
        Me.txtQta.My_MinValue = 1.0!
        Me.txtQta.Name = "txtQta"
        Me.txtQta.My_AllowOnlyInteger = True
        Me.txtQta.My_ReplaceWithDefaultValue = True
        Me.txtQta.Size = New System.Drawing.Size(82, 20)
        Me.txtQta.TabIndex = 67
        Me.txtQta.Text = "1"
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.toolTipHelp.SetToolTip(Me.txtQta, "La quantità dell'omaggio deve essere minimo di 1")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(82, 245)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 15)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Quantità"
        Me.toolTipHelp.SetToolTip(Me.Label12, "La quantità dell'omaggio deve essere minimo di 1")
        '
        'cmbListini
        '
        Me.cmbListini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListini.FormattingEnabled = True
        Me.cmbListini.Location = New System.Drawing.Point(176, 213)
        Me.cmbListini.Name = "cmbListini"
        Me.cmbListini.Size = New System.Drawing.Size(511, 21)
        Me.cmbListini.TabIndex = 64
        Me.toolTipHelp.SetToolTip(Me.cmbListini, "L'omaggio oggetto della regola")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(82, 216)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 15)
        Me.Label14.TabIndex = 65
        Me.Label14.Text = "Listino"
        Me.toolTipHelp.SetToolTip(Me.Label14, "L'omaggio oggetto della regola")
        '
        'rdoSSInviaMessaggio
        '
        Me.rdoSSInviaMessaggio.AutoSize = True
        Me.rdoSSInviaMessaggio.Location = New System.Drawing.Point(70, 130)
        Me.rdoSSInviaMessaggio.Name = "rdoSSInviaMessaggio"
        Me.rdoSSInviaMessaggio.Size = New System.Drawing.Size(258, 19)
        Me.rdoSSInviaMessaggio.TabIndex = 60
        Me.rdoSSInviaMessaggio.Text = "Inserisci una richiesta automatica di riordino"
        Me.rdoSSInviaMessaggio.UseVisualStyleBackColor = True
        '
        'rdoSSRiordina
        '
        Me.rdoSSRiordina.AutoSize = True
        Me.rdoSSRiordina.Location = New System.Drawing.Point(70, 188)
        Me.rdoSSRiordina.Name = "rdoSSRiordina"
        Me.rdoSSRiordina.Size = New System.Drawing.Size(220, 19)
        Me.rdoSSRiordina.TabIndex = 59
        Me.rdoSSRiordina.Text = "Inserisci automaticamente un Ordine"
        Me.rdoSSRiordina.UseVisualStyleBackColor = True
        '
        'rdoSSNoAzioni
        '
        Me.rdoSSNoAzioni.AutoSize = True
        Me.rdoSSNoAzioni.Checked = True
        Me.rdoSSNoAzioni.Location = New System.Drawing.Point(70, 70)
        Me.rdoSSNoAzioni.Name = "rdoSSNoAzioni"
        Me.rdoSSNoAzioni.Size = New System.Drawing.Size(185, 19)
        Me.rdoSSNoAzioni.TabIndex = 58
        Me.rdoSSNoAzioni.TabStop = True
        Me.rdoSSNoAzioni.Text = "Non effettuare nessuna azione"
        Me.rdoSSNoAzioni.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label9.Location = New System.Drawing.Point(49, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 22)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Sottoscorta"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Location = New System.Drawing.Point(162, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(764, 22)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "In questa schermata si potranno gestire le regole per il sottoscorta di questa ri" &
    "sorsa"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Sottoscorta
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 56
        Me.PictureBox1.TabStop = False
        '
        'tpDecodificaVociCosto
        '
        Me.tpDecodificaVociCosto.Controls.Add(Me.UcMagazzinoDecodificaVociCosto)
        Me.tpDecodificaVociCosto.Location = New System.Drawing.Point(4, 22)
        Me.tpDecodificaVociCosto.Name = "tpDecodificaVociCosto"
        Me.tpDecodificaVociCosto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDecodificaVociCosto.Size = New System.Drawing.Size(1090, 613)
        Me.tpDecodificaVociCosto.TabIndex = 3
        Me.tpDecodificaVociCosto.Text = "Decodifica Voci Costo"
        Me.tpDecodificaVociCosto.UseVisualStyleBackColor = True
        '
        'UcMagazzinoDecodificaVociCosto
        '
        Me.UcMagazzinoDecodificaVociCosto.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoDecodificaVociCosto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoDecodificaVociCosto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoDecodificaVociCosto.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoDecodificaVociCosto.Name = "UcMagazzinoDecodificaVociCosto"
        Me.UcMagazzinoDecodificaVociCosto.Size = New System.Drawing.Size(1084, 607)
        Me.UcMagazzinoDecodificaVociCosto.TabIndex = 0
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lnkRicalcola)
        Me.gbPulsanti.Controls.Add(Me.lnkPeso)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 639)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Padding = New System.Windows.Forms.Padding(0)
        Me.gbPulsanti.Size = New System.Drawing.Size(1098, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'lnkRicalcola
        '
        Me.lnkRicalcola.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRicalcola.ForeColor = System.Drawing.Color.Black
        Me.lnkRicalcola.Image = Global.Former.My.Resources.Resources._Calcolatrice
        Me.lnkRicalcola.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRicalcola.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRicalcola.Location = New System.Drawing.Point(76, 9)
        Me.lnkRicalcola.Name = "lnkRicalcola"
        Me.lnkRicalcola.Size = New System.Drawing.Size(134, 37)
        Me.lnkRicalcola.TabIndex = 68
        Me.lnkRicalcola.TabStop = True
        Me.lnkRicalcola.Text = "Ricalcola Giacenza"
        Me.lnkRicalcola.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkPeso
        '
        Me.lnkPeso.BackColor = System.Drawing.Color.White
        Me.lnkPeso.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lnkPeso.ForeColor = System.Drawing.Color.Black
        Me.lnkPeso.Image = Global.Former.My.Resources.Resources.scale
        Me.lnkPeso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkPeso.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkPeso.Location = New System.Drawing.Point(6, 11)
        Me.lnkPeso.Name = "lnkPeso"
        Me.lnkPeso.Size = New System.Drawing.Size(64, 32)
        Me.lnkPeso.TabIndex = 67
        Me.lnkPeso.TabStop = True
        Me.lnkPeso.Text = "Peso"
        Me.lnkPeso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1016, 9)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(76, 30)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(939, 9)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(71, 30)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'OpenFilePDF
        '
        Me.OpenFilePDF.Filter = "File PDF|*.pdf"
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        '
        'frmMagazzinoRisorsa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1098, 687)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMagazzinoRisorsa"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Risorsa"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.cmbGruppo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctRep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMovimenti.ResumeLayout(False)
        Me.tbMovimenti.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSottoScorta.ResumeLayout(False)
        Me.tpSottoScorta.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDecodificaVociCosto.ResumeLayout(False)
        Me.gbPulsanti.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGiacenza As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoRis As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCodice As System.Windows.Forms.TextBox
    Friend WithEvents lblReparto As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtGiacenzaMin As ucNumericTextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblNumLastre As System.Windows.Forms.Label
    Friend WithEvents txtNumLastre As ucNumericTextBox
    Friend WithEvents lblCostoTotale As System.Windows.Forms.Label
    Friend WithEvents txtCostoTotale As ucNumericTextBox
    Friend WithEvents lblCostoFoglioEsteso As System.Windows.Forms.Label
    Friend WithEvents txtCostoFoglioSteso As ucNumericTextBox
    Friend WithEvents tbMovimenti As System.Windows.Forms.TabPage
    Friend WithEvents lblCostoVenduto As System.Windows.Forms.Label
    Friend WithEvents txtCostoVenduto As ucNumericTextBox
    Friend WithEvents cmbTipoOff As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoOffset As System.Windows.Forms.Label
    Friend WithEvents lblLunghezza As System.Windows.Forms.Label
    Friend WithEvents txtLunghezza As ucNumericTextBox
    Friend WithEvents lblLarghezza As System.Windows.Forms.Label
    Friend WithEvents txtLarghezza As ucNumericTextBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCarta As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoCarta As System.Windows.Forms.Label
    Friend WithEvents btnNewTipo As System.Windows.Forms.Button
    Friend WithEvents lblGrammatura As System.Windows.Forms.Label
    Friend WithEvents txtGrammatura As ucNumericTextBox
    Friend WithEvents btnDettTipo As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents chkLstMacchinari As CheckedListBox
    Friend WithEvents lnkPeso As LinkLabel
    Friend WithEvents pctRep As PictureBox
    Friend WithEvents tpSottoScorta As TabPage
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents rdoSSInviaMessaggio As RadioButton
    Friend WithEvents rdoSSRiordina As RadioButton
    Friend WithEvents rdoSSNoAzioni As RadioButton
    Friend WithEvents txtQta As ucNumericTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbListini As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnSearchPdf As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents txtFilePDF As TextBox
    Friend WithEvents OpenFilePDF As OpenFileDialog
    Friend WithEvents chkProdottoFinito As CheckBox
    Friend WithEvents chkStatoAttivo As CheckBox
    Friend WithEvents cmbCategoria As ComboBox
    Friend WithEvents lblCategoria As Label
    Friend WithEvents lnkRicalcola As LinkLabel
    Friend WithEvents UcMagazzinoMgrMovimenti As ucMagazzinoMgrMovimenti
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtFoto As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents txtBarCode As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents pctFoto As PictureBox
    Friend WithEvents OpenFileImg As OpenFileDialog
    Friend WithEvents UcPictureWizard As ucPictureWizard
    Friend WithEvents cmbGruppo As Telerik.WinControls.UI.RadCheckedDropDownList
    Friend WithEvents Label11 As Label
    Friend WithEvents btnNewGruppo As Button
    Friend WithEvents cmbUnitaMisura As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents tpDecodificaVociCosto As TabPage
    Friend WithEvents UcMagazzinoDecodificaVociCosto As ucMagazzinoDecodificaVociCosto
    Friend WithEvents lblM2 As Label
End Class
