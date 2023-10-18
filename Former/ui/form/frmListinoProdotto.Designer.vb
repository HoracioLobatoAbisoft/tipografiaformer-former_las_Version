<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoProdotto
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
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.UcCaratProdotto = New Former.ucCaratteristicheProdotto()
        Me.btnSelCat = New System.Windows.Forms.Button()
        Me.lblCat = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPercLow = New Former.ucNumericTextBox()
        Me.txtGGLow = New Former.ucNumericTextBox()
        Me.txtPercNorm = New Former.ucNumericTextBox()
        Me.txtGGNorm = New Former.ucNumericTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPercFast = New Former.ucNumericTextBox()
        Me.txtGGFast = New Former.ucNumericTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNumDuplic = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNumSpazi = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPesoComplessivo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNumOreMax = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNumPezzi = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumColli = New System.Windows.Forms.TextBox()
        Me.lblTotRiv = New System.Windows.Forms.Label()
        Me.lblTot = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblIvaRiv = New System.Windows.Forms.Label()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtScarto = New System.Windows.Forms.TextBox()
        Me.pctAlertCodice = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrezzoRiv = New System.Windows.Forms.TextBox()
        Me.txtPrezzo = New System.Windows.Forms.TextBox()
        Me.chkFR = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescrEstesa = New System.Windows.Forms.TextBox()
        Me.cmbTipoProd = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodice = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpCarat = New System.Windows.Forms.TabPage()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cmbTipoCarta = New Former.ucComboWithImage()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbFormato = New Former.ucComboWithImage()
        Me.UcLavorazioni = New Former.ucLavorazioni()
        Me.tpAnteprima = New System.Windows.Forms.TabPage()
        Me.WebAnteprima = New System.Windows.Forms.WebBrowser()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.ToolTipEsistente = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblListinoBase = New System.Windows.Forms.Label()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pctAlertCodice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCarat.SuspendLayout()
        Me.tpAnteprima.SuspendLayout()
        Me.gbPulsanti.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpCarat)
        Me.TabMain.Controls.Add(Me.tpAnteprima)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(901, 549)
        Me.TabMain.TabIndex = 0
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblListinoBase)
        Me.tbProd.Controls.Add(Me.Label24)
        Me.tbProd.Controls.Add(Me.UcCaratProdotto)
        Me.tbProd.Controls.Add(Me.btnSelCat)
        Me.tbProd.Controls.Add(Me.lblCat)
        Me.tbProd.Controls.Add(Me.Panel1)
        Me.tbProd.Controls.Add(Me.Label15)
        Me.tbProd.Controls.Add(Me.txtNumDuplic)
        Me.tbProd.Controls.Add(Me.Label14)
        Me.tbProd.Controls.Add(Me.txtNumSpazi)
        Me.tbProd.Controls.Add(Me.Label13)
        Me.tbProd.Controls.Add(Me.txtPesoComplessivo)
        Me.tbProd.Controls.Add(Me.Label12)
        Me.tbProd.Controls.Add(Me.txtNumOreMax)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.txtNumPezzi)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.txtNumColli)
        Me.tbProd.Controls.Add(Me.lblTotRiv)
        Me.tbProd.Controls.Add(Me.lblTot)
        Me.tbProd.Controls.Add(Me.Label25)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.lblIvaRiv)
        Me.tbProd.Controls.Add(Me.lblIva)
        Me.tbProd.Controls.Add(Me.Label23)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtScarto)
        Me.tbProd.Controls.Add(Me.pctAlertCodice)
        Me.tbProd.Controls.Add(Me.Label22)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtPrezzoRiv)
        Me.tbProd.Controls.Add(Me.txtPrezzo)
        Me.tbProd.Controls.Add(Me.chkFR)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtDescrEstesa)
        Me.tbProd.Controls.Add(Me.cmbTipoProd)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtDescr)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtCodice)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(893, 523)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Prodotto"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.White
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(57, 430)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(144, 15)
        Me.Label24.TabIndex = 103
        Me.Label24.Text = "Riepilogo Caratteristiche"
        '
        'UcCaratProdotto
        '
        Me.UcCaratProdotto.BackColor = System.Drawing.Color.White
        Me.UcCaratProdotto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcCaratProdotto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UcCaratProdotto.Location = New System.Drawing.Point(57, 445)
        Me.UcCaratProdotto.Name = "UcCaratProdotto"
        Me.UcCaratProdotto.Size = New System.Drawing.Size(828, 70)
        Me.UcCaratProdotto.TabIndex = 102
        '
        'btnSelCat
        '
        Me.btnSelCat.Location = New System.Drawing.Point(770, 193)
        Me.btnSelCat.Name = "btnSelCat"
        Me.btnSelCat.Size = New System.Drawing.Size(24, 23)
        Me.btnSelCat.TabIndex = 5
        Me.btnSelCat.Text = "..."
        Me.btnSelCat.UseVisualStyleBackColor = True
        '
        'lblCat
        '
        Me.lblCat.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCat.Location = New System.Drawing.Point(154, 192)
        Me.lblCat.Name = "lblCat"
        Me.lblCat.Size = New System.Drawing.Size(610, 24)
        Me.lblCat.TabIndex = 4
        Me.lblCat.Text = "..."
        Me.lblCat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txtPercLow)
        Me.Panel1.Controls.Add(Me.txtGGLow)
        Me.Panel1.Controls.Add(Me.txtPercNorm)
        Me.Panel1.Controls.Add(Me.txtGGNorm)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtPercFast)
        Me.Panel1.Controls.Add(Me.txtGGFast)
        Me.Panel1.Location = New System.Drawing.Point(621, 244)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 122)
        Me.Panel1.TabIndex = 99
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(5, 92)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(98, 21)
        Me.Label21.TabIndex = 95
        Me.Label21.Text = "Slow"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Silver
        Me.Label20.Location = New System.Drawing.Point(5, 66)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 21)
        Me.Label20.TabIndex = 95
        Me.Label20.Text = "Normale"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Lime
        Me.Label19.Location = New System.Drawing.Point(4, 39)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 21)
        Me.Label19.TabIndex = 94
        Me.Label19.Text = "Fast24"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(58, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 15)
        Me.Label18.TabIndex = 93
        Me.Label18.Text = "Modalità di Consegna"
        '
        'txtPercLow
        '
        Me.txtPercLow.My_AccettaNegativi = False
        Me.txtPercLow.My_DefaultValue = 0
        Me.txtPercLow.Location = New System.Drawing.Point(171, 92)
        Me.txtPercLow.My_MaxValue = 1.0E+10!
        Me.txtPercLow.My_MinValue = 0!
        Me.txtPercLow.Name = "txtPercLow"
        Me.txtPercLow.My_AllowOnlyInteger = True
        Me.txtPercLow.My_ReplaceWithDefaultValue = True
        Me.txtPercLow.Size = New System.Drawing.Size(65, 20)
        Me.txtPercLow.TabIndex = 20
        Me.txtPercLow.Text = "0"
        Me.txtPercLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGGLow
        '
        Me.txtGGLow.My_AccettaNegativi = False
        Me.txtGGLow.My_DefaultValue = 0
        Me.txtGGLow.Location = New System.Drawing.Point(109, 92)
        Me.txtGGLow.My_MaxValue = 1.0E+10!
        Me.txtGGLow.My_MinValue = 0!
        Me.txtGGLow.Name = "txtGGLow"
        Me.txtGGLow.My_AllowOnlyInteger = True
        Me.txtGGLow.My_ReplaceWithDefaultValue = True
        Me.txtGGLow.Size = New System.Drawing.Size(51, 20)
        Me.txtGGLow.TabIndex = 19
        Me.txtGGLow.Text = "0"
        Me.txtGGLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPercNorm
        '
        Me.txtPercNorm.My_AccettaNegativi = False
        Me.txtPercNorm.My_DefaultValue = 0
        Me.txtPercNorm.Location = New System.Drawing.Point(171, 66)
        Me.txtPercNorm.My_MaxValue = 1.0E+10!
        Me.txtPercNorm.My_MinValue = 0!
        Me.txtPercNorm.Name = "txtPercNorm"
        Me.txtPercNorm.My_AllowOnlyInteger = True
        Me.txtPercNorm.ReadOnly = True
        Me.txtPercNorm.My_ReplaceWithDefaultValue = True
        Me.txtPercNorm.Size = New System.Drawing.Size(65, 20)
        Me.txtPercNorm.TabIndex = 90
        Me.txtPercNorm.Text = "0"
        Me.txtPercNorm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGGNorm
        '
        Me.txtGGNorm.My_AccettaNegativi = False
        Me.txtGGNorm.My_DefaultValue = 1
        Me.txtGGNorm.Location = New System.Drawing.Point(109, 66)
        Me.txtGGNorm.My_MaxValue = 1.0E+10!
        Me.txtGGNorm.My_MinValue = 1.0!
        Me.txtGGNorm.Name = "txtGGNorm"
        Me.txtGGNorm.My_AllowOnlyInteger = True
        Me.txtGGNorm.My_ReplaceWithDefaultValue = True
        Me.txtGGNorm.Size = New System.Drawing.Size(51, 20)
        Me.txtGGNorm.TabIndex = 18
        Me.txtGGNorm.Text = "1"
        Me.txtGGNorm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(168, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 15)
        Me.Label17.TabIndex = 88
        Me.Label17.Text = "% su costo"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(122, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(21, 15)
        Me.Label16.TabIndex = 87
        Me.Label16.Text = "gg"
        '
        'txtPercFast
        '
        Me.txtPercFast.My_AccettaNegativi = False
        Me.txtPercFast.My_DefaultValue = 0
        Me.txtPercFast.Location = New System.Drawing.Point(171, 39)
        Me.txtPercFast.My_MaxValue = 1.0E+10!
        Me.txtPercFast.My_MinValue = 0!
        Me.txtPercFast.Name = "txtPercFast"
        Me.txtPercFast.My_AllowOnlyInteger = True
        Me.txtPercFast.My_ReplaceWithDefaultValue = True
        Me.txtPercFast.Size = New System.Drawing.Size(65, 20)
        Me.txtPercFast.TabIndex = 17
        Me.txtPercFast.Text = "0"
        Me.txtPercFast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGGFast
        '
        Me.txtGGFast.My_AccettaNegativi = False
        Me.txtGGFast.My_DefaultValue = 0
        Me.txtGGFast.Location = New System.Drawing.Point(109, 39)
        Me.txtGGFast.My_MaxValue = 1.0E+10!
        Me.txtGGFast.My_MinValue = 0!
        Me.txtGGFast.Name = "txtGGFast"
        Me.txtGGFast.My_AllowOnlyInteger = True
        Me.txtGGFast.My_ReplaceWithDefaultValue = True
        Me.txtGGFast.Size = New System.Drawing.Size(51, 20)
        Me.txtGGFast.TabIndex = 16
        Me.txtGGFast.Text = "0"
        Me.txtGGFast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(54, 328)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 15)
        Me.Label15.TabIndex = 98
        Me.Label15.Text = "Num. Duplicati"
        '
        'txtNumDuplic
        '
        Me.txtNumDuplic.Location = New System.Drawing.Point(154, 325)
        Me.txtNumDuplic.MaxLength = 20
        Me.txtNumDuplic.Name = "txtNumDuplic"
        Me.txtNumDuplic.Size = New System.Drawing.Size(118, 20)
        Me.txtNumDuplic.TabIndex = 13
        Me.txtNumDuplic.Text = "0"
        Me.txtNumDuplic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(54, 301)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 15)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Num. Spazi"
        '
        'txtNumSpazi
        '
        Me.txtNumSpazi.Location = New System.Drawing.Point(154, 298)
        Me.txtNumSpazi.MaxLength = 20
        Me.txtNumSpazi.Name = "txtNumSpazi"
        Me.txtNumSpazi.Size = New System.Drawing.Size(118, 20)
        Me.txtNumSpazi.TabIndex = 11
        Me.txtNumSpazi.Text = "0"
        Me.txtNumSpazi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(295, 274)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 15)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "Peso Complessivo"
        '
        'txtPesoComplessivo
        '
        Me.txtPesoComplessivo.Location = New System.Drawing.Point(436, 271)
        Me.txtPesoComplessivo.MaxLength = 100
        Me.txtPesoComplessivo.Name = "txtPesoComplessivo"
        Me.txtPesoComplessivo.Size = New System.Drawing.Size(118, 20)
        Me.txtPesoComplessivo.TabIndex = 10
        Me.txtPesoComplessivo.Text = "0"
        Me.txtPesoComplessivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(295, 301)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(132, 15)
        Me.Label12.TabIndex = 92
        Me.Label12.Text = "Tempo Max Produzione"
        '
        'txtNumOreMax
        '
        Me.txtNumOreMax.Location = New System.Drawing.Point(436, 298)
        Me.txtNumOreMax.MaxLength = 100
        Me.txtNumOreMax.Name = "txtNumOreMax"
        Me.txtNumOreMax.Size = New System.Drawing.Size(118, 20)
        Me.txtNumOreMax.TabIndex = 12
        Me.txtNumOreMax.Text = "0"
        Me.txtNumOreMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(50, 197)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 15)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Categoria"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(295, 247)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 15)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "N° Pezzi Fattura"
        '
        'txtNumPezzi
        '
        Me.txtNumPezzi.Location = New System.Drawing.Point(436, 244)
        Me.txtNumPezzi.MaxLength = 100
        Me.txtNumPezzi.Name = "txtNumPezzi"
        Me.txtNumPezzi.ReadOnly = True
        Me.txtNumPezzi.Size = New System.Drawing.Size(118, 20)
        Me.txtNumPezzi.TabIndex = 8
        Me.txtNumPezzi.Text = "0"
        Me.txtNumPezzi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(54, 247)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 15)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "N° Colli"
        '
        'txtNumColli
        '
        Me.txtNumColli.Location = New System.Drawing.Point(154, 244)
        Me.txtNumColli.MaxLength = 100
        Me.txtNumColli.Name = "txtNumColli"
        Me.txtNumColli.Size = New System.Drawing.Size(118, 20)
        Me.txtNumColli.TabIndex = 7
        Me.txtNumColli.Text = "0"
        Me.txtNumColli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotRiv
        '
        Me.lblTotRiv.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotRiv.ForeColor = System.Drawing.Color.Black
        Me.lblTotRiv.Location = New System.Drawing.Point(436, 400)
        Me.lblTotRiv.Name = "lblTotRiv"
        Me.lblTotRiv.Size = New System.Drawing.Size(118, 15)
        Me.lblTotRiv.TabIndex = 83
        Me.lblTotRiv.Text = "0"
        Me.lblTotRiv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTot
        '
        Me.lblTot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTot.ForeColor = System.Drawing.Color.Black
        Me.lblTot.Location = New System.Drawing.Point(154, 400)
        Me.lblTot.Name = "lblTot"
        Me.lblTot.Size = New System.Drawing.Size(118, 15)
        Me.lblTot.TabIndex = 83
        Me.lblTot.Text = "0"
        Me.lblTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(336, 400)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(73, 15)
        Me.Label25.TabIndex = 82
        Me.Label25.Text = "Prezzo finale"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(54, 400)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 15)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "Prezzo finale"
        '
        'lblIvaRiv
        '
        Me.lblIvaRiv.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIvaRiv.ForeColor = System.Drawing.Color.Black
        Me.lblIvaRiv.Location = New System.Drawing.Point(436, 379)
        Me.lblIvaRiv.Name = "lblIvaRiv"
        Me.lblIvaRiv.Size = New System.Drawing.Size(118, 15)
        Me.lblIvaRiv.TabIndex = 81
        Me.lblIvaRiv.Text = "0"
        Me.lblIvaRiv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIva
        '
        Me.lblIva.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIva.ForeColor = System.Drawing.Color.Black
        Me.lblIva.Location = New System.Drawing.Point(154, 379)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(118, 15)
        Me.lblIva.TabIndex = 81
        Me.lblIva.Text = "0"
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(336, 379)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(26, 15)
        Me.Label23.TabIndex = 80
        Me.Label23.Text = "IVA"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(54, 379)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 15)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "IVA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(54, 274)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Scarto"
        '
        'txtScarto
        '
        Me.txtScarto.Location = New System.Drawing.Point(154, 271)
        Me.txtScarto.MaxLength = 20
        Me.txtScarto.Name = "txtScarto"
        Me.txtScarto.Size = New System.Drawing.Size(118, 20)
        Me.txtScarto.TabIndex = 9
        Me.txtScarto.Text = "0"
        Me.txtScarto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.ToolTipEsistente.SetToolTip(Me.pctAlertCodice, "Codice prodotto già esistente")
        Me.pctAlertCodice.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(336, 357)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 15)
        Me.Label22.TabIndex = 27
        Me.Label22.Text = "Prezzo Pubbl."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(54, 357)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Prezzo"
        '
        'txtPrezzoRiv
        '
        Me.txtPrezzoRiv.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrezzoRiv.ForeColor = System.Drawing.Color.Red
        Me.txtPrezzoRiv.Location = New System.Drawing.Point(436, 352)
        Me.txtPrezzoRiv.MaxLength = 20
        Me.txtPrezzoRiv.Name = "txtPrezzoRiv"
        Me.txtPrezzoRiv.Size = New System.Drawing.Size(118, 27)
        Me.txtPrezzoRiv.TabIndex = 14
        Me.txtPrezzoRiv.Text = "0"
        Me.txtPrezzoRiv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrezzo
        '
        Me.txtPrezzo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrezzo.ForeColor = System.Drawing.Color.Red
        Me.txtPrezzo.Location = New System.Drawing.Point(154, 352)
        Me.txtPrezzo.MaxLength = 20
        Me.txtPrezzo.Name = "txtPrezzo"
        Me.txtPrezzo.Size = New System.Drawing.Size(118, 27)
        Me.txtPrezzo.TabIndex = 14
        Me.txtPrezzo.Text = "0"
        Me.txtPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkFR
        '
        Me.chkFR.AutoSize = True
        Me.chkFR.Location = New System.Drawing.Point(154, 219)
        Me.chkFR.Name = "chkFR"
        Me.chkFR.Size = New System.Drawing.Size(85, 19)
        Me.chkFR.TabIndex = 6
        Me.chkFR.Text = "Fronteretro"
        Me.chkFR.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 33)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Descrizione (estesa)"
        '
        'txtDescrEstesa
        '
        Me.txtDescrEstesa.Location = New System.Drawing.Point(154, 111)
        Me.txtDescrEstesa.MaxLength = 100
        Me.txtDescrEstesa.Multiline = True
        Me.txtDescrEstesa.Name = "txtDescrEstesa"
        Me.txtDescrEstesa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescrEstesa.Size = New System.Drawing.Size(711, 73)
        Me.txtDescrEstesa.TabIndex = 3
        '
        'cmbTipoProd
        '
        Me.cmbTipoProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoProd.FormattingEnabled = True
        Me.cmbTipoProd.Location = New System.Drawing.Point(415, 57)
        Me.cmbTipoProd.Name = "cmbTipoProd"
        Me.cmbTipoProd.Size = New System.Drawing.Size(164, 21)
        Me.cmbTipoProd.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(378, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Descrizione"
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(154, 84)
        Me.txtDescr.MaxLength = 100
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(711, 20)
        Me.txtDescr.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Codice"
        '
        'txtCodice
        '
        Me.txtCodice.Location = New System.Drawing.Point(154, 57)
        Me.txtCodice.MaxLength = 50
        Me.txtCodice.Name = "txtCodice"
        Me.txtCodice.Size = New System.Drawing.Size(218, 20)
        Me.txtCodice.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Prodotto
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
        Me.lblTipo.Size = New System.Drawing.Size(78, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Prodotto"
        '
        'tpCarat
        '
        Me.tpCarat.Controls.Add(Me.Label28)
        Me.tpCarat.Controls.Add(Me.Label27)
        Me.tpCarat.Controls.Add(Me.cmbTipoCarta)
        Me.tpCarat.Controls.Add(Me.Label26)
        Me.tpCarat.Controls.Add(Me.cmbFormato)
        Me.tpCarat.Controls.Add(Me.UcLavorazioni)
        Me.tpCarat.Location = New System.Drawing.Point(4, 22)
        Me.tpCarat.Name = "tpCarat"
        Me.tpCarat.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCarat.Size = New System.Drawing.Size(893, 523)
        Me.tpCarat.TabIndex = 2
        Me.tpCarat.Text = "Caratteristiche Prodotto"
        Me.tpCarat.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.White
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(19, 177)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(336, 15)
        Me.Label28.TabIndex = 94
        Me.Label28.Text = "Seleziona le lavorazioni obbligatorie/opzionali del prodotto:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.White
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(19, 90)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(259, 15)
        Me.Label27.TabIndex = 93
        Me.Label27.Text = "Seleziona la tipologia della carta del prodotto:"
        '
        'cmbTipoCarta
        '
        Me.cmbTipoCarta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbTipoCarta.DropDownHeight = 500
        Me.cmbTipoCarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCarta.FormattingEnabled = True
        Me.cmbTipoCarta.HeightImg = 60
        Me.cmbTipoCarta.IntegralHeight = False
        Me.cmbTipoCarta.ItemHeight = 60
        Me.cmbTipoCarta.Location = New System.Drawing.Point(22, 108)
        Me.cmbTipoCarta.Name = "cmbTipoCarta"
        Me.cmbTipoCarta.Size = New System.Drawing.Size(847, 66)
        Me.cmbTipoCarta.TabIndex = 92
        Me.cmbTipoCarta.WidthImg = 80
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.White
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(19, 3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(194, 15)
        Me.Label26.TabIndex = 91
        Me.Label26.Text = "Seleziona il formato del prodotto:"
        '
        'cmbFormato
        '
        Me.cmbFormato.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbFormato.DropDownHeight = 500
        Me.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormato.FormattingEnabled = True
        Me.cmbFormato.HeightImg = 60
        Me.cmbFormato.IntegralHeight = False
        Me.cmbFormato.ItemHeight = 60
        Me.cmbFormato.Location = New System.Drawing.Point(22, 21)
        Me.cmbFormato.Name = "cmbFormato"
        Me.cmbFormato.Size = New System.Drawing.Size(847, 66)
        Me.cmbFormato.TabIndex = 85
        Me.cmbFormato.WidthImg = 80
        '
        'UcLavorazioni
        '
        Me.UcLavorazioni.BackColor = System.Drawing.Color.White
        Me.UcLavorazioni.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcLavorazioni.Location = New System.Drawing.Point(13, 195)
        Me.UcLavorazioni.Name = "UcLavorazioni"
        Me.UcLavorazioni.Size = New System.Drawing.Size(856, 320)
        Me.UcLavorazioni.SolaLettura = False
        Me.UcLavorazioni.TabIndex = 84
        '
        'tpAnteprima
        '
        Me.tpAnteprima.Controls.Add(Me.WebAnteprima)
        Me.tpAnteprima.Location = New System.Drawing.Point(4, 22)
        Me.tpAnteprima.Name = "tpAnteprima"
        Me.tpAnteprima.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAnteprima.Size = New System.Drawing.Size(893, 523)
        Me.tpAnteprima.TabIndex = 1
        Me.tpAnteprima.Text = "Anteprima"
        Me.tpAnteprima.UseVisualStyleBackColor = True
        '
        'WebAnteprima
        '
        Me.WebAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebAnteprima.Location = New System.Drawing.Point(3, 3)
        Me.WebAnteprima.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebAnteprima.Name = "WebAnteprima"
        Me.WebAnteprima.Size = New System.Drawing.Size(887, 517)
        Me.WebAnteprima.TabIndex = 0
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 549)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(901, 56)
        Me.gbPulsanti.TabIndex = 4
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
        Me.btnCancel.Location = New System.Drawing.Point(853, 14)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 36)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark
        Me.btnOk.Location = New System.Drawing.Point(813, 16)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 21
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'ToolTipEsistente
        '
        Me.ToolTipEsistente.ToolTipTitle = "Attenzione!"
        '
        'lblListinoBase
        '
        Me.lblListinoBase.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblListinoBase.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblListinoBase.ForeColor = System.Drawing.Color.Green
        Me.lblListinoBase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblListinoBase.Location = New System.Drawing.Point(152, 9)
        Me.lblListinoBase.Name = "lblListinoBase"
        Me.lblListinoBase.Size = New System.Drawing.Size(713, 30)
        Me.lblListinoBase.TabIndex = 113
        Me.lblListinoBase.Text = "-"
        '
        'frmListinoProdotto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(901, 605)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "frmListinoProdotto"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Prodotto"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pctAlertCodice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCarat.ResumeLayout(False)
        Me.tpCarat.PerformLayout()
        Me.tpAnteprima.ResumeLayout(False)
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCodice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoProd As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPrezzo As System.Windows.Forms.TextBox
    Friend WithEvents chkFR As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescrEstesa As System.Windows.Forms.TextBox
    Friend WithEvents pctAlertCodice As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTipEsistente As System.Windows.Forms.ToolTip
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtScarto As System.Windows.Forms.TextBox
    Friend WithEvents lblTot As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents UcLavorazioni As Former.ucLavorazioni
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNumPezzi As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumColli As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNumOreMax As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPesoComplessivo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNumSpazi As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNumDuplic As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtPercFast As ucNumericTextBox
    Friend WithEvents txtGGFast As ucNumericTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtPercLow As ucNumericTextBox
    Friend WithEvents txtGGLow As ucNumericTextBox
    Friend WithEvents txtPercNorm As ucNumericTextBox
    Friend WithEvents txtGGNorm As ucNumericTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tpAnteprima As System.Windows.Forms.TabPage
    Friend WithEvents WebAnteprima As System.Windows.Forms.WebBrowser
    Friend WithEvents lblTotRiv As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblIvaRiv As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtPrezzoRiv As System.Windows.Forms.TextBox
    Friend WithEvents btnSelCat As System.Windows.Forms.Button
    Friend WithEvents lblCat As System.Windows.Forms.Label
    Friend WithEvents tpCarat As System.Windows.Forms.TabPage
    Friend WithEvents UcCaratProdotto As Former.ucCaratteristicheProdotto
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCarta As ucComboWithImage
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbFormato As ucComboWithImage
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblListinoBase As Label
End Class
