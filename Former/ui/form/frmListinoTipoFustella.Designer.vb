<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoTipoFustella
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
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtCodice = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSearchPdf = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTemplatePDF = New System.Windows.Forms.TextBox()
        Me.lstCat = New System.Windows.Forms.CheckedListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pctImgLav = New System.Windows.Forms.PictureBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtImgRif = New System.Windows.Forms.TextBox()
        Me.chkOrientabile = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProfondita = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAltezza = New Former.ucNumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBase = New Former.ucNumericTextBox()
        Me.chkDisponibile = New System.Windows.Forms.CheckBox()
        Me.cmbPrev = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFilePDF = New System.Windows.Forms.OpenFileDialog()
        Me.UcPictureWizard = New Former.ucPictureWizard()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 595)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(809, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(767, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 33)
        Me.btnCancel.TabIndex = 10
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
        Me.btnOk.Location = New System.Drawing.Point(733, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 9
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
        Me.TabMain.Size = New System.Drawing.Size(809, 595)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.UcPictureWizard)
        Me.tbProd.Controls.Add(Me.Label15)
        Me.tbProd.Controls.Add(Me.Label14)
        Me.tbProd.Controls.Add(Me.Label13)
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.txtCodice)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.btnSearchPdf)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.txtTemplatePDF)
        Me.tbProd.Controls.Add(Me.lstCat)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.pctImgLav)
        Me.tbProd.Controls.Add(Me.btnSearch)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.txtImgRif)
        Me.tbProd.Controls.Add(Me.chkOrientabile)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtProfondita)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtAltezza)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtBase)
        Me.tbProd.Controls.Add(Me.chkDisponibile)
        Me.tbProd.Controls.Add(Me.cmbPrev)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(801, 569)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Tipo Fustella"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(9, 168)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 25)
        Me.Label15.TabIndex = 199
        Me.Label15.Text = "(P)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(8, 141)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 25)
        Me.Label14.TabIndex = 198
        Me.Label14.Text = "(A)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(8, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 25)
        Me.Label13.TabIndex = 197
        Me.Label13.Text = "(B)"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources.packagingMisure
        Me.PictureBox1.Location = New System.Drawing.Point(662, 63)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 196
        Me.PictureBox1.TabStop = False
        '
        'txtCodice
        '
        Me.txtCodice.Location = New System.Drawing.Point(154, 92)
        Me.txtCodice.Name = "txtCodice"
        Me.txtCodice.Size = New System.Drawing.Size(111, 20)
        Me.txtCodice.TabIndex = 70
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(50, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "Codice"
        '
        'btnSearchPdf
        '
        Me.btnSearchPdf.Location = New System.Drawing.Point(630, 260)
        Me.btnSearchPdf.Name = "btnSearchPdf"
        Me.btnSearchPdf.Size = New System.Drawing.Size(26, 21)
        Me.btnSearchPdf.TabIndex = 67
        Me.btnSearchPdf.Text = "..."
        Me.btnSearchPdf.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(50, 263)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 15)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Template PDF"
        '
        'txtTemplatePDF
        '
        Me.txtTemplatePDF.Location = New System.Drawing.Point(154, 260)
        Me.txtTemplatePDF.Name = "txtTemplatePDF"
        Me.txtTemplatePDF.ReadOnly = True
        Me.txtTemplatePDF.Size = New System.Drawing.Size(470, 20)
        Me.txtTemplatePDF.TabIndex = 66
        Me.txtTemplatePDF.TabStop = False
        '
        'lstCat
        '
        Me.lstCat.CheckOnClick = True
        Me.lstCat.FormattingEnabled = True
        Me.lstCat.Location = New System.Drawing.Point(154, 287)
        Me.lstCat.Name = "lstCat"
        Me.lstCat.Size = New System.Drawing.Size(470, 256)
        Me.lstCat.TabIndex = 65
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(676, 418)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 18)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "(128px - 128px)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctImgLav
        '
        Me.pctImgLav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctImgLav.Location = New System.Drawing.Point(662, 287)
        Me.pctImgLav.Name = "pctImgLav"
        Me.pctImgLav.Size = New System.Drawing.Size(128, 128)
        Me.pctImgLav.TabIndex = 63
        Me.pctImgLav.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(630, 233)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 21)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "..."
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(50, 236)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Immagine"
        '
        'txtImgRif
        '
        Me.txtImgRif.Location = New System.Drawing.Point(154, 233)
        Me.txtImgRif.Name = "txtImgRif"
        Me.txtImgRif.ReadOnly = True
        Me.txtImgRif.Size = New System.Drawing.Size(470, 20)
        Me.txtImgRif.TabIndex = 5
        Me.txtImgRif.TabStop = False
        '
        'chkOrientabile
        '
        Me.chkOrientabile.AutoSize = True
        Me.chkOrientabile.Location = New System.Drawing.Point(329, 207)
        Me.chkOrientabile.Name = "chkOrientabile"
        Me.chkOrientabile.Size = New System.Drawing.Size(84, 19)
        Me.chkOrientabile.TabIndex = 8
        Me.chkOrientabile.Text = "Orientabile"
        Me.chkOrientabile.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(50, 287)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 15)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Categoria"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(271, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "(mm)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(271, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "(mm)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(271, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "(mm)"
        '
        'txtProfondita
        '
        Me.txtProfondita.My_AccettaNegativi = False
        Me.txtProfondita.My_DefaultValue = 0
        Me.txtProfondita.Location = New System.Drawing.Point(154, 173)
        Me.txtProfondita.MaxLength = 5
        Me.txtProfondita.My_MaxValue = 1000.0!
        Me.txtProfondita.My_MinValue = 0!
        Me.txtProfondita.Name = "txtProfondita"
        Me.txtProfondita.My_AllowOnlyInteger = True
        Me.txtProfondita.My_ReplaceWithDefaultValue = True
        Me.txtProfondita.Size = New System.Drawing.Size(111, 20)
        Me.txtProfondita.TabIndex = 3
        Me.txtProfondita.Text = "0"
        Me.txtProfondita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Profondita"
        '
        'txtAltezza
        '
        Me.txtAltezza.My_AccettaNegativi = False
        Me.txtAltezza.My_DefaultValue = 0
        Me.txtAltezza.Location = New System.Drawing.Point(154, 146)
        Me.txtAltezza.MaxLength = 5
        Me.txtAltezza.My_MaxValue = 1000.0!
        Me.txtAltezza.My_MinValue = 0!
        Me.txtAltezza.Name = "txtAltezza"
        Me.txtAltezza.My_AllowOnlyInteger = True
        Me.txtAltezza.My_ReplaceWithDefaultValue = True
        Me.txtAltezza.Size = New System.Drawing.Size(111, 20)
        Me.txtAltezza.TabIndex = 2
        Me.txtAltezza.Text = "0"
        Me.txtAltezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Altezza"
        '
        'txtBase
        '
        Me.txtBase.My_AccettaNegativi = False
        Me.txtBase.My_DefaultValue = 0
        Me.txtBase.Location = New System.Drawing.Point(154, 119)
        Me.txtBase.MaxLength = 5
        Me.txtBase.My_MaxValue = 1000.0!
        Me.txtBase.My_MinValue = 0!
        Me.txtBase.Name = "txtBase"
        Me.txtBase.My_AllowOnlyInteger = True
        Me.txtBase.My_ReplaceWithDefaultValue = True
        Me.txtBase.Size = New System.Drawing.Size(111, 20)
        Me.txtBase.TabIndex = 1
        Me.txtBase.Text = "0"
        Me.txtBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkDisponibile
        '
        Me.chkDisponibile.AutoSize = True
        Me.chkDisponibile.Location = New System.Drawing.Point(154, 207)
        Me.chkDisponibile.Name = "chkDisponibile"
        Me.chkDisponibile.Size = New System.Drawing.Size(165, 19)
        Me.chkDisponibile.TabIndex = 4
        Me.chkDisponibile.Text = "Effettivamente Disponibile"
        Me.chkDisponibile.UseVisualStyleBackColor = True
        '
        'cmbPrev
        '
        Me.cmbPrev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrev.FormattingEnabled = True
        Me.cmbPrev.Location = New System.Drawing.Point(154, 63)
        Me.cmbPrev.Name = "cmbPrev"
        Me.cmbPrev.Size = New System.Drawing.Size(502, 21)
        Me.cmbPrev.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Preventivazione"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Base"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._FustellaTemplate
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
        Me.lblTipo.Size = New System.Drawing.Size(107, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Tipo Fustella"
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        '
        'OpenFilePDF
        '
        Me.OpenFilePDF.Filter = "File PDF|*.pdf"
        '
        'UcPictureWizard
        '
        Me.UcPictureWizard.AutoSize = True
        Me.UcPictureWizard.Location = New System.Drawing.Point(662, 231)
        Me.UcPictureWizard.Name = "UcPictureWizard"
        Me.UcPictureWizard.RifPictureBox = Me.pctImgLav
        Me.UcPictureWizard.RifTextBoxPath = Me.txtImgRif
        Me.UcPictureWizard.Size = New System.Drawing.Size(77, 23)
        Me.UcPictureWizard.TabIndex = 200
        '
        'frmListinoTipoFustella
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(809, 643)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoTipoFustella"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Tipo Fustella"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
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
    Friend WithEvents chkDisponibile As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPrev As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtProfondita As ucNumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAltezza As ucNumericTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBase As ucNumericTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtImgRif As System.Windows.Forms.TextBox
    Friend WithEvents chkOrientabile As System.Windows.Forms.CheckBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents OpenFileImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pctImgLav As System.Windows.Forms.PictureBox
    Friend WithEvents lstCat As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSearchPdf As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTemplatePDF As System.Windows.Forms.TextBox
    Friend WithEvents OpenFilePDF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtCodice As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents UcPictureWizard As ucPictureWizard
End Class
