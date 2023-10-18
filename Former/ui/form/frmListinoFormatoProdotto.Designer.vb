<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoFormatoProdotto
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
        Me.components = New System.ComponentModel.Container()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.UcInfoBox = New Former.ucInfoBox()
        Me.chkIsLastra = New System.Windows.Forms.CheckBox()
        Me.lnkGeneraTemplate = New System.Windows.Forms.LinkLabel()
        Me.chkIsRotolo = New System.Windows.Forms.CheckBox()
        Me.UcPictureWizard = New Former.ucPictureWizard()
        Me.pctImgLav = New System.Windows.Forms.PictureBox()
        Me.txtImgLav = New System.Windows.Forms.TextBox()
        Me.txtLarghezza = New Former.ucNumericTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtLunghezza = New Former.ucNumericTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbCatFormato = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNomeAlbero = New System.Windows.Forms.TextBox()
        Me.chkOrientabile = New System.Windows.Forms.CheckBox()
        Me.btnSearchPdf3d = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPdfTemplate3D = New System.Windows.Forms.TextBox()
        Me.chkProdottoFinito = New System.Windows.Forms.CheckBox()
        Me.btnSearchPdf = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPdfTemplate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescEst = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmbFormatoCarta = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSigla = New System.Windows.Forms.TextBox()
        Me.cmbOrientamento = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescrizione = New System.Windows.Forms.TextBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpImpatto = New System.Windows.Forms.TabPage()
        Me.UcListinoImpatto = New Former.ucListinoImpatto()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 697)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(836, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(753, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(77, 30)
        Me.btnCancel.TabIndex = 16
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
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(675, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 30)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpImpatto)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(836, 697)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.UcInfoBox)
        Me.tbProd.Controls.Add(Me.chkIsLastra)
        Me.tbProd.Controls.Add(Me.lnkGeneraTemplate)
        Me.tbProd.Controls.Add(Me.chkIsRotolo)
        Me.tbProd.Controls.Add(Me.UcPictureWizard)
        Me.tbProd.Controls.Add(Me.txtLarghezza)
        Me.tbProd.Controls.Add(Me.Label13)
        Me.tbProd.Controls.Add(Me.txtLunghezza)
        Me.tbProd.Controls.Add(Me.Label14)
        Me.tbProd.Controls.Add(Me.cmbCatFormato)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.txtNomeAlbero)
        Me.tbProd.Controls.Add(Me.chkOrientabile)
        Me.tbProd.Controls.Add(Me.btnSearchPdf3d)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.txtPdfTemplate3D)
        Me.tbProd.Controls.Add(Me.chkProdottoFinito)
        Me.tbProd.Controls.Add(Me.btnSearchPdf)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtPdfTemplate)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtDescEst)
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.cmbFormatoCarta)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.txtSigla)
        Me.tbProd.Controls.Add(Me.cmbOrientamento)
        Me.tbProd.Controls.Add(Me.Label1)
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
        Me.tbProd.Size = New System.Drawing.Size(828, 671)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Formato Prodotto"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'UcInfoBox
        '
        Me.UcInfoBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.UcInfoBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcInfoBox.HelpText = "Se il formato è di tipo ROTOLO e ha LE MISURE diventa non pannellizzabile e la su" &
    "a unità di misura diventa mm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.UcInfoBox.Location = New System.Drawing.Point(58, 614)
        Me.UcInfoBox.Name = "UcInfoBox"
        Me.UcInfoBox.Size = New System.Drawing.Size(678, 40)
        Me.UcInfoBox.TabIndex = 120
        '
        'chkIsLastra
        '
        Me.chkIsLastra.AutoSize = True
        Me.chkIsLastra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkIsLastra.Location = New System.Drawing.Point(602, 484)
        Me.chkIsLastra.Name = "chkIsLastra"
        Me.chkIsLastra.Size = New System.Drawing.Size(102, 19)
        Me.chkIsLastra.TabIndex = 119
        Me.chkIsLastra.Text = "E' una LASTRA"
        Me.toolTipHelp.SetToolTip(Me.chkIsLastra, "Selezionare questa opzione se il formato prodotto prevede che possa essere vendut" &
        "o in sezioni e si tratta di una LASTRA")
        Me.chkIsLastra.UseVisualStyleBackColor = True
        '
        'lnkGeneraTemplate
        '
        Me.lnkGeneraTemplate.AutoSize = True
        Me.lnkGeneraTemplate.Image = Global.Former.My.Resources.Resources._Wizard20
        Me.lnkGeneraTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkGeneraTemplate.LinkColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lnkGeneraTemplate.Location = New System.Drawing.Point(746, 402)
        Me.lnkGeneraTemplate.Name = "lnkGeneraTemplate"
        Me.lnkGeneraTemplate.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lnkGeneraTemplate.Size = New System.Drawing.Size(73, 15)
        Me.lnkGeneraTemplate.TabIndex = 118
        Me.lnkGeneraTemplate.TabStop = True
        Me.lnkGeneraTemplate.Text = "Genera..."
        '
        'chkIsRotolo
        '
        Me.chkIsRotolo.AutoSize = True
        Me.chkIsRotolo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkIsRotolo.Location = New System.Drawing.Point(497, 484)
        Me.chkIsRotolo.Name = "chkIsRotolo"
        Me.chkIsRotolo.Size = New System.Drawing.Size(99, 19)
        Me.chkIsRotolo.TabIndex = 117
        Me.chkIsRotolo.Text = "E' un ROTOLO"
        Me.toolTipHelp.SetToolTip(Me.chkIsRotolo, "Selezionare questa opzione se il formato prodotto prevede che possa essere vendut" &
        "o in sezioni e si tratta di un ROTOLO")
        Me.chkIsRotolo.UseVisualStyleBackColor = True
        '
        'UcPictureWizard
        '
        Me.UcPictureWizard.AutoSize = True
        Me.UcPictureWizard.ImgHeight = 128
        Me.UcPictureWizard.ImgWidth = 128
        Me.UcPictureWizard.Location = New System.Drawing.Point(742, 370)
        Me.UcPictureWizard.Name = "UcPictureWizard"
        Me.UcPictureWizard.PrefissoDaApplicare = ""
        Me.UcPictureWizard.RifPictureBox = Me.pctImgLav
        Me.UcPictureWizard.RifTextBoxPath = Me.txtImgLav
        Me.UcPictureWizard.Size = New System.Drawing.Size(77, 23)
        Me.UcPictureWizard.TabIndex = 116
        '
        'pctImgLav
        '
        Me.pctImgLav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctImgLav.Location = New System.Drawing.Point(691, 52)
        Me.pctImgLav.Name = "pctImgLav"
        Me.pctImgLav.Size = New System.Drawing.Size(128, 128)
        Me.pctImgLav.TabIndex = 57
        Me.pctImgLav.TabStop = False
        '
        'txtImgLav
        '
        Me.txtImgLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtImgLav.Location = New System.Drawing.Point(169, 372)
        Me.txtImgLav.MaxLength = 50
        Me.txtImgLav.Name = "txtImgLav"
        Me.txtImgLav.ReadOnly = True
        Me.txtImgLav.Size = New System.Drawing.Size(535, 23)
        Me.txtImgLav.TabIndex = 59
        '
        'txtLarghezza
        '
        Me.txtLarghezza.Location = New System.Drawing.Point(169, 537)
        Me.txtLarghezza.MaxLength = 4
        Me.txtLarghezza.My_AccettaNegativi = False
        Me.txtLarghezza.My_AllowOnlyInteger = True
        Me.txtLarghezza.My_DefaultValue = 0
        Me.txtLarghezza.My_MaxValue = 9999.0!
        Me.txtLarghezza.My_MinValue = 0!
        Me.txtLarghezza.My_ReplaceWithDefaultValue = True
        Me.txtLarghezza.Name = "txtLarghezza"
        Me.txtLarghezza.Size = New System.Drawing.Size(82, 20)
        Me.txtLarghezza.TabIndex = 106
        Me.txtLarghezza.Text = "1"
        Me.txtLarghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(55, 540)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 15)
        Me.Label13.TabIndex = 105
        Me.Label13.Text = "Larghezza (mm)"
        '
        'txtLunghezza
        '
        Me.txtLunghezza.Location = New System.Drawing.Point(169, 511)
        Me.txtLunghezza.MaxLength = 4
        Me.txtLunghezza.My_AccettaNegativi = False
        Me.txtLunghezza.My_AllowOnlyInteger = True
        Me.txtLunghezza.My_DefaultValue = 0
        Me.txtLunghezza.My_MaxValue = 9999.0!
        Me.txtLunghezza.My_MinValue = 0!
        Me.txtLunghezza.My_ReplaceWithDefaultValue = True
        Me.txtLunghezza.Name = "txtLunghezza"
        Me.txtLunghezza.Size = New System.Drawing.Size(82, 20)
        Me.txtLunghezza.TabIndex = 104
        Me.txtLunghezza.Text = "1"
        Me.txtLunghezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(55, 514)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 15)
        Me.Label14.TabIndex = 103
        Me.Label14.Text = "Altezza (mm)"
        '
        'cmbCatFormato
        '
        Me.cmbCatFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCatFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCatFormato.FormattingEnabled = True
        Me.cmbCatFormato.Items.AddRange(New Object() {"Orizzontale", "Verticale"})
        Me.cmbCatFormato.Location = New System.Drawing.Point(165, 563)
        Me.cmbCatFormato.Name = "cmbCatFormato"
        Me.cmbCatFormato.Size = New System.Drawing.Size(216, 23)
        Me.cmbCatFormato.TabIndex = 101
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(55, 566)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Categoria"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(391, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 15)
        Me.Label11.TabIndex = 99
        Me.Label11.Text = "(max 30 caratteri)"
        Me.toolTipHelp.SetToolTip(Me.Label11, "Nome visualizzato sull'albero delle preventivazioni")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(55, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 15)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "Nome su Albero"
        Me.toolTipHelp.SetToolTip(Me.Label10, "Nome visualizzato sull'albero delle preventivazioni")
        '
        'txtNomeAlbero
        '
        Me.txtNomeAlbero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNomeAlbero.Location = New System.Drawing.Point(169, 106)
        Me.txtNomeAlbero.MaxLength = 30
        Me.txtNomeAlbero.Name = "txtNomeAlbero"
        Me.txtNomeAlbero.Size = New System.Drawing.Size(216, 23)
        Me.txtNomeAlbero.TabIndex = 97
        Me.toolTipHelp.SetToolTip(Me.txtNomeAlbero, "Nome visualizzato sull'albero delle preventivazioni")
        '
        'chkOrientabile
        '
        Me.chkOrientabile.AutoSize = True
        Me.chkOrientabile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkOrientabile.Location = New System.Drawing.Point(297, 455)
        Me.chkOrientabile.Name = "chkOrientabile"
        Me.chkOrientabile.Size = New System.Drawing.Size(84, 19)
        Me.chkOrientabile.TabIndex = 96
        Me.chkOrientabile.Text = "Orientabile"
        Me.chkOrientabile.UseVisualStyleBackColor = True
        '
        'btnSearchPdf3d
        '
        Me.btnSearchPdf3d.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSearchPdf3d.Location = New System.Drawing.Point(710, 426)
        Me.btnSearchPdf3d.Name = "btnSearchPdf3d"
        Me.btnSearchPdf3d.Size = New System.Drawing.Size(26, 21)
        Me.btnSearchPdf3d.TabIndex = 95
        Me.btnSearchPdf3d.Text = "..."
        Me.btnSearchPdf3d.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(55, 426)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 15)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "PDF Template 3D"
        '
        'txtPdfTemplate3D
        '
        Me.txtPdfTemplate3D.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPdfTemplate3D.Location = New System.Drawing.Point(169, 426)
        Me.txtPdfTemplate3D.MaxLength = 50
        Me.txtPdfTemplate3D.Name = "txtPdfTemplate3D"
        Me.txtPdfTemplate3D.ReadOnly = True
        Me.txtPdfTemplate3D.Size = New System.Drawing.Size(535, 23)
        Me.txtPdfTemplate3D.TabIndex = 93
        '
        'chkProdottoFinito
        '
        Me.chkProdottoFinito.AutoSize = True
        Me.chkProdottoFinito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkProdottoFinito.Location = New System.Drawing.Point(297, 484)
        Me.chkProdottoFinito.Name = "chkProdottoFinito"
        Me.chkProdottoFinito.Size = New System.Drawing.Size(106, 19)
        Me.chkProdottoFinito.TabIndex = 7
        Me.chkProdottoFinito.Text = "Prodotto Finito"
        Me.chkProdottoFinito.UseVisualStyleBackColor = True
        '
        'btnSearchPdf
        '
        Me.btnSearchPdf.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSearchPdf.Location = New System.Drawing.Point(710, 399)
        Me.btnSearchPdf.Name = "btnSearchPdf"
        Me.btnSearchPdf.Size = New System.Drawing.Size(26, 21)
        Me.btnSearchPdf.TabIndex = 92
        Me.btnSearchPdf.Text = "..."
        Me.btnSearchPdf.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(55, 399)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 15)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "PDF Template"
        '
        'txtPdfTemplate
        '
        Me.txtPdfTemplate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPdfTemplate.Location = New System.Drawing.Point(169, 399)
        Me.txtPdfTemplate.MaxLength = 50
        Me.txtPdfTemplate.Name = "txtPdfTemplate"
        Me.txtPdfTemplate.ReadOnly = True
        Me.txtPdfTemplate.Size = New System.Drawing.Size(535, 23)
        Me.txtPdfTemplate.TabIndex = 90
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Orange
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(55, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Descrizione sito"
        '
        'txtDescEst
        '
        Me.txtDescEst.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescEst.Location = New System.Drawing.Point(169, 133)
        Me.txtDescEst.MaxLength = 255
        Me.txtDescEst.Multiline = True
        Me.txtDescEst.Name = "txtDescEst"
        Me.txtDescEst.Size = New System.Drawing.Size(216, 233)
        Me.txtDescEst.TabIndex = 88
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._FormatoProdotto
        Me.PictureBox1.Location = New System.Drawing.Point(17, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 87
        Me.PictureBox1.TabStop = False
        '
        'cmbFormatoCarta
        '
        Me.cmbFormatoCarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormatoCarta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbFormatoCarta.FormattingEnabled = True
        Me.cmbFormatoCarta.Items.AddRange(New Object() {"Orizzontale", "Verticale"})
        Me.cmbFormatoCarta.Location = New System.Drawing.Point(169, 482)
        Me.cmbFormatoCarta.Name = "cmbFormatoCarta"
        Me.cmbFormatoCarta.Size = New System.Drawing.Size(121, 23)
        Me.cmbFormatoCarta.TabIndex = 67
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Orange
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(55, 485)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Formato Carta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Orange
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(55, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 15)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Sigla"
        '
        'txtSigla
        '
        Me.txtSigla.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSigla.Location = New System.Drawing.Point(169, 52)
        Me.txtSigla.MaxLength = 50
        Me.txtSigla.Name = "txtSigla"
        Me.txtSigla.Size = New System.Drawing.Size(57, 23)
        Me.txtSigla.TabIndex = 64
        '
        'cmbOrientamento
        '
        Me.cmbOrientamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrientamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbOrientamento.FormattingEnabled = True
        Me.cmbOrientamento.Items.AddRange(New Object() {"Orizzontale", "Verticale", "Neutro"})
        Me.cmbOrientamento.Location = New System.Drawing.Point(169, 453)
        Me.cmbOrientamento.Name = "cmbOrientamento"
        Me.cmbOrientamento.Size = New System.Drawing.Size(121, 23)
        Me.cmbOrientamento.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(55, 456)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Orientamento"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSearch.Location = New System.Drawing.Point(710, 372)
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
        Me.Label9.Location = New System.Drawing.Point(55, 372)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Immagine"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(705, 185)
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
        Me.Label7.Location = New System.Drawing.Point(55, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Descrizione"
        '
        'txtDescrizione
        '
        Me.txtDescrizione.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescrizione.Location = New System.Drawing.Point(169, 79)
        Me.txtDescrizione.MaxLength = 50
        Me.txtDescrizione.Name = "txtDescrizione"
        Me.txtDescrizione.Size = New System.Drawing.Size(451, 23)
        Me.txtDescrizione.TabIndex = 0
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
        Me.lblTipo.Text = "Formato Prodotto"
        '
        'tpImpatto
        '
        Me.tpImpatto.Controls.Add(Me.UcListinoImpatto)
        Me.tpImpatto.Location = New System.Drawing.Point(4, 22)
        Me.tpImpatto.Name = "tpImpatto"
        Me.tpImpatto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpImpatto.Size = New System.Drawing.Size(828, 671)
        Me.tpImpatto.TabIndex = 1
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
        Me.UcListinoImpatto.Size = New System.Drawing.Size(822, 665)
        Me.UcListinoImpatto.TabIndex = 0
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        '
        'frmListinoFormatoProdotto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(836, 745)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoFormatoProdotto"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Formato"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctImgLav, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmbOrientamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtImgLav As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSigla As System.Windows.Forms.TextBox
    Friend WithEvents cmbFormatoCarta As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescEst As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchPdf As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPdfTemplate As System.Windows.Forms.TextBox
    Friend WithEvents chkProdottoFinito As System.Windows.Forms.CheckBox
    Friend WithEvents btnSearchPdf3d As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPdfTemplate3D As System.Windows.Forms.TextBox
    Friend WithEvents chkOrientabile As System.Windows.Forms.CheckBox
    Friend WithEvents tpImpatto As System.Windows.Forms.TabPage
    Friend WithEvents UcListinoImpatto As Former.ucListinoImpatto
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNomeAlbero As TextBox
    Friend WithEvents cmbCatFormato As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtLarghezza As ucNumericTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtLunghezza As ucNumericTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents UcPictureWizard As ucPictureWizard
    Friend WithEvents chkIsRotolo As CheckBox
    Friend WithEvents lnkGeneraTemplate As LinkLabel
    Friend WithEvents chkIsLastra As CheckBox
    Friend WithEvents UcInfoBox As ucInfoBox
End Class
