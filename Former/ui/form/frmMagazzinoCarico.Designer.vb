<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMagazzinoCarico
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lnkRiapriDocFiscale = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.lblFatt = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPesoKg = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrezzoKg = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescrForn = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodiceForn = New System.Windows.Forms.TextBox()
        Me.txtPrezzoUnit = New System.Windows.Forms.TextBox()
        Me.txtPrezzo = New Former.ucNumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQta = New Former.ucNumericTextBox()
        Me.lblPrezzo = New System.Windows.Forms.Label()
        Me.lblPrezzoUnit = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pctSblocca = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCercaRis = New System.Windows.Forms.TextBox()
        Me.cmbRisorsa = New Former.ucComboWithImage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.pctRis = New Former.ucPictureWithZoom()
        Me.btnDett = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.grpCerca = New System.Windows.Forms.GroupBox()
        Me.lblProdotti = New System.Windows.Forms.Label()
        Me.DgArticoliForn = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.cmbTipoMov = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pctSblocca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctRis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCerca.SuspendLayout()
        CType(Me.DgArticoliForn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lnkRiapriDocFiscale)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 667)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(989, 48)
        Me.gbPulsanti.TabIndex = 1
        Me.gbPulsanti.TabStop = False
        '
        'lnkRiapriDocFiscale
        '
        Me.lnkRiapriDocFiscale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkRiapriDocFiscale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.lnkRiapriDocFiscale.FlatAppearance.BorderSize = 0
        Me.lnkRiapriDocFiscale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkRiapriDocFiscale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRiapriDocFiscale.Image = Global.Former.My.Resources.Resources._DocumentoFiscale
        Me.lnkRiapriDocFiscale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRiapriDocFiscale.Location = New System.Drawing.Point(6, 12)
        Me.lnkRiapriDocFiscale.Name = "lnkRiapriDocFiscale"
        Me.lnkRiapriDocFiscale.Size = New System.Drawing.Size(173, 30)
        Me.lnkRiapriDocFiscale.TabIndex = 2
        Me.lnkRiapriDocFiscale.Text = "Riapri documento fiscale"
        Me.lnkRiapriDocFiscale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkRiapriDocFiscale.UseVisualStyleBackColor = True
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
        Me.btnCancel.Location = New System.Drawing.Point(908, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
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
        Me.btnOk.Location = New System.Drawing.Point(833, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(69, 30)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(989, 667)
        Me.TabMain.TabIndex = 0
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblFatt)
        Me.tbProd.Controls.Add(Me.GroupBox2)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.grpCerca)
        Me.tbProd.Controls.Add(Me.cmbTipoMov)
        Me.tbProd.Controls.Add(Me.Label35)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(981, 641)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Magazzino"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lblFatt
        '
        Me.lblFatt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblFatt.Location = New System.Drawing.Point(527, 14)
        Me.lblFatt.Name = "lblFatt"
        Me.lblFatt.Size = New System.Drawing.Size(437, 22)
        Me.lblFatt.TabIndex = 15
        Me.lblFatt.Text = "-"
        Me.lblFatt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtPesoKg)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtPrezzoKg)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtNota)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtDescrForn)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtCodiceForn)
        Me.GroupBox2.Controls.Add(Me.txtPrezzoUnit)
        Me.GroupBox2.Controls.Add(Me.txtPrezzo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtQta)
        Me.GroupBox2.Controls.Add(Me.lblPrezzo)
        Me.GroupBox2.Controls.Add(Me.lblPrezzoUnit)
        Me.GroupBox2.Location = New System.Drawing.Point(54, 476)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(916, 152)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Inserisci l'effettiva Movimentazione"
        '
        'txtPesoKg
        '
        Me.txtPesoKg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPesoKg.Location = New System.Drawing.Point(807, 86)
        Me.txtPesoKg.MaxLength = 50
        Me.txtPesoKg.Name = "txtPesoKg"
        Me.txtPesoKg.ReadOnly = True
        Me.txtPesoKg.Size = New System.Drawing.Size(92, 23)
        Me.txtPesoKg.TabIndex = 36
        Me.txtPesoKg.TabStop = False
        Me.txtPesoKg.Text = "-"
        Me.txtPesoKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(744, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 15)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Peso Kg"
        '
        'txtPrezzoKg
        '
        Me.txtPrezzoKg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrezzoKg.Location = New System.Drawing.Point(807, 53)
        Me.txtPrezzoKg.MaxLength = 50
        Me.txtPrezzoKg.Name = "txtPrezzoKg"
        Me.txtPrezzoKg.ReadOnly = True
        Me.txtPrezzoKg.Size = New System.Drawing.Size(92, 23)
        Me.txtPrezzoKg.TabIndex = 34
        Me.txtPrezzoKg.TabStop = False
        Me.txtPrezzoKg.Text = "-"
        Me.txtPrezzoKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(744, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Prezzo Kg"
        '
        'txtNota
        '
        Me.txtNota.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNota.Location = New System.Drawing.Point(121, 80)
        Me.txtNota.MaxLength = 250
        Me.txtNota.Multiline = True
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(409, 56)
        Me.txtNota.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(5, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Annotazioni"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(5, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 15)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Codice Fornitore"
        '
        'txtDescrForn
        '
        Me.txtDescrForn.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescrForn.Location = New System.Drawing.Point(121, 53)
        Me.txtDescrForn.MaxLength = 150
        Me.txtDescrForn.Name = "txtDescrForn"
        Me.txtDescrForn.Size = New System.Drawing.Size(409, 23)
        Me.txtDescrForn.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(5, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 15)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Descrizione Forn."
        '
        'txtCodiceForn
        '
        Me.txtCodiceForn.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCodiceForn.Location = New System.Drawing.Point(121, 26)
        Me.txtCodiceForn.MaxLength = 50
        Me.txtCodiceForn.Name = "txtCodiceForn"
        Me.txtCodiceForn.Size = New System.Drawing.Size(145, 23)
        Me.txtCodiceForn.TabIndex = 0
        '
        'txtPrezzoUnit
        '
        Me.txtPrezzoUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrezzoUnit.Location = New System.Drawing.Point(646, 53)
        Me.txtPrezzoUnit.MaxLength = 50
        Me.txtPrezzoUnit.Name = "txtPrezzoUnit"
        Me.txtPrezzoUnit.ReadOnly = True
        Me.txtPrezzoUnit.Size = New System.Drawing.Size(92, 23)
        Me.txtPrezzoUnit.TabIndex = 3
        Me.txtPrezzoUnit.TabStop = False
        Me.txtPrezzoUnit.Text = "0"
        Me.txtPrezzoUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrezzo
        '
        Me.txtPrezzo.My_AccettaNegativi = False
        Me.txtPrezzo.My_DefaultValue = 0
        Me.txtPrezzo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrezzo.Location = New System.Drawing.Point(646, 115)
        Me.txtPrezzo.MaxLength = 50
        Me.txtPrezzo.My_MaxValue = 1.0E+10!
        Me.txtPrezzo.My_MinValue = 0!
        Me.txtPrezzo.Name = "txtPrezzo"
        Me.txtPrezzo.My_AllowOnlyInteger = False
        Me.txtPrezzo.My_ReplaceWithDefaultValue = True
        Me.txtPrezzo.Size = New System.Drawing.Size(92, 23)
        Me.txtPrezzo.TabIndex = 5
        Me.txtPrezzo.Text = "0"
        Me.txtPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(551, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Quantità"
        '
        'txtQta
        '
        Me.txtQta.My_AccettaNegativi = False
        Me.txtQta.My_DefaultValue = 1
        Me.txtQta.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtQta.Location = New System.Drawing.Point(646, 80)
        Me.txtQta.MaxLength = 50
        Me.txtQta.My_MaxValue = 1.0E+10!
        Me.txtQta.My_MinValue = 1.0!
        Me.txtQta.Name = "txtQta"
        Me.txtQta.My_AllowOnlyInteger = False
        Me.txtQta.My_ReplaceWithDefaultValue = True
        Me.txtQta.Size = New System.Drawing.Size(92, 32)
        Me.txtQta.TabIndex = 4
        Me.txtQta.Text = "1"
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrezzo
        '
        Me.lblPrezzo.AutoSize = True
        Me.lblPrezzo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPrezzo.ForeColor = System.Drawing.Color.Black
        Me.lblPrezzo.Location = New System.Drawing.Point(551, 119)
        Me.lblPrezzo.Name = "lblPrezzo"
        Me.lblPrezzo.Size = New System.Drawing.Size(75, 15)
        Me.lblPrezzo.TabIndex = 17
        Me.lblPrezzo.Text = "Prezzo Totale"
        '
        'lblPrezzoUnit
        '
        Me.lblPrezzoUnit.AutoSize = True
        Me.lblPrezzoUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPrezzoUnit.ForeColor = System.Drawing.Color.Black
        Me.lblPrezzoUnit.Location = New System.Drawing.Point(551, 56)
        Me.lblPrezzoUnit.Name = "lblPrezzoUnit"
        Me.lblPrezzoUnit.Size = New System.Drawing.Size(86, 15)
        Me.lblPrezzoUnit.TabIndex = 17
        Me.lblPrezzoUnit.Text = "Prezzo Unitario"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.pctSblocca)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtCercaRis)
        Me.GroupBox1.Controls.Add(Me.cmbRisorsa)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmbCategoria)
        Me.GroupBox1.Controls.Add(Me.pctRis)
        Me.GroupBox1.Controls.Add(Me.btnDett)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lnkNew)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(53, 350)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(917, 120)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cerca e Seleziona la generica risorsa da magazzino"
        '
        'pctSblocca
        '
        Me.pctSblocca.Image = Global.Former.My.Resources.Resources._LucchettoAperto
        Me.pctSblocca.Location = New System.Drawing.Point(27, 78)
        Me.pctSblocca.Name = "pctSblocca"
        Me.pctSblocca.Size = New System.Drawing.Size(37, 34)
        Me.pctSblocca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctSblocca.TabIndex = 129
        Me.pctSblocca.TabStop = False
        Me.toolTipHelp.SetToolTip(Me.pctSblocca, "Blocca la consegna per la modifica")
        Me.pctSblocca.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(292, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 15)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Descrizione"
        '
        'txtCercaRis
        '
        Me.txtCercaRis.Location = New System.Drawing.Point(365, 19)
        Me.txtCercaRis.MaxLength = 50
        Me.txtCercaRis.Name = "txtCercaRis"
        Me.txtCercaRis.Size = New System.Drawing.Size(166, 20)
        Me.txtCercaRis.TabIndex = 120
        '
        'cmbRisorsa
        '
        Me.cmbRisorsa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRisorsa.DisplayMember = "Text"
        Me.cmbRisorsa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRisorsa.DropDownHeight = 500
        Me.cmbRisorsa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRisorsa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbRisorsa.FormattingEnabled = True
        Me.cmbRisorsa.HeightImg = 60
        Me.cmbRisorsa.IntegralHeight = False
        Me.cmbRisorsa.ItemHeight = 60
        Me.cmbRisorsa.Location = New System.Drawing.Point(70, 46)
        Me.cmbRisorsa.Name = "cmbRisorsa"
        Me.cmbRisorsa.Size = New System.Drawing.Size(565, 66)
        Me.cmbRisorsa.TabIndex = 119
        Me.cmbRisorsa.ValueMember = "Id"
        Me.cmbRisorsa.WidthImg = 80
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 15)
        Me.Label9.TabIndex = 118
        Me.Label9.Text = "Categoria"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(70, 19)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(197, 21)
        Me.cmbCategoria.TabIndex = 117
        '
        'pctRis
        '
        Me.pctRis.BackColor = System.Drawing.Color.White
        Me.pctRis.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctRis.Label = Nothing
        Me.pctRis.Location = New System.Drawing.Point(847, 46)
        Me.pctRis.Name = "pctRis"
        Me.pctRis.Size = New System.Drawing.Size(64, 64)
        Me.pctRis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctRis.TabIndex = 116
        Me.pctRis.TabStop = False
        '
        'btnDett
        '
        Me.btnDett.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDett.Location = New System.Drawing.Point(641, 45)
        Me.btnDett.Name = "btnDett"
        Me.btnDett.Size = New System.Drawing.Size(25, 23)
        Me.btnDett.TabIndex = 73
        Me.btnDett.Text = "..."
        Me.btnDett.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Risorsa:"
        '
        'lnkNew
        '
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._RisorsaAdd
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(681, 39)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(121, 35)
        Me.lnkNew.TabIndex = 1
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuova Risorsa..."
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpCerca
        '
        Me.grpCerca.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCerca.Controls.Add(Me.lblProdotti)
        Me.grpCerca.Controls.Add(Me.DgArticoliForn)
        Me.grpCerca.Controls.Add(Me.Label3)
        Me.grpCerca.Controls.Add(Me.txtCerca)
        Me.grpCerca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.grpCerca.Location = New System.Drawing.Point(53, 58)
        Me.grpCerca.Name = "grpCerca"
        Me.grpCerca.Size = New System.Drawing.Size(917, 286)
        Me.grpCerca.TabIndex = 0
        Me.grpCerca.TabStop = False
        Me.grpCerca.Text = "Seleziona un prodotto già caricato"
        '
        'lblProdotti
        '
        Me.lblProdotti.AutoSize = True
        Me.lblProdotti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblProdotti.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblProdotti.Location = New System.Drawing.Point(273, 29)
        Me.lblProdotti.Name = "lblProdotti"
        Me.lblProdotti.Size = New System.Drawing.Size(187, 15)
        Me.lblProdotti.TabIndex = 49
        Me.lblProdotti.Text = "Prodotti trovati per il testo inserito"
        Me.lblProdotti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblProdotti.Visible = False
        '
        'DgArticoliForn
        '
        Me.DgArticoliForn.AllowUserToAddRows = False
        Me.DgArticoliForn.AllowUserToDeleteRows = False
        Me.DgArticoliForn.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgArticoliForn.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgArticoliForn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgArticoliForn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgArticoliForn.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgArticoliForn.BackgroundColor = System.Drawing.Color.White
        Me.DgArticoliForn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgArticoliForn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgArticoliForn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgArticoliForn.ColumnHeadersHeight = 20
        Me.DgArticoliForn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgArticoliForn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgArticoliForn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgArticoliForn.EnableHeadersVisualStyles = False
        Me.DgArticoliForn.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgArticoliForn.Location = New System.Drawing.Point(9, 55)
        Me.DgArticoliForn.MultiSelect = False
        Me.DgArticoliForn.Name = "DgArticoliForn"
        Me.DgArticoliForn.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgArticoliForn.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgArticoliForn.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgArticoliForn.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgArticoliForn.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgArticoliForn.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgArticoliForn.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgArticoliForn.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgArticoliForn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgArticoliForn.Size = New System.Drawing.Size(902, 225)
        Me.DgArticoliForn.TabIndex = 1
        Me.DgArticoliForn.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Cerca:"
        '
        'txtCerca
        '
        Me.txtCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCerca.Location = New System.Drawing.Point(55, 26)
        Me.txtCerca.MaxLength = 50
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(212, 23)
        Me.txtCerca.TabIndex = 0
        '
        'cmbTipoMov
        '
        Me.cmbTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMov.FormattingEnabled = True
        Me.cmbTipoMov.Location = New System.Drawing.Point(318, 15)
        Me.cmbTipoMov.Name = "cmbTipoMov"
        Me.cmbTipoMov.Size = New System.Drawing.Size(186, 21)
        Me.cmbTipoMov.TabIndex = 0
        Me.cmbTipoMov.TabStop = False
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(156, 18)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(156, 22)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Movimento di magazzino"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Magazzino
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
        Me.lblTipo.Size = New System.Drawing.Size(94, 21)
        Me.lblTipo.TabIndex = 6
        Me.lblTipo.Text = "Magazzino"
        '
        'frmMagazzinoCarico
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(989, 715)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmMagazzinoCarico"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Magazzino"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctSblocca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctRis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCerca.ResumeLayout(False)
        Me.grpCerca.PerformLayout()
        CType(Me.DgArticoliForn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents cmbTipoMov As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrezzo As System.Windows.Forms.Label
    Friend WithEvents txtPrezzo As ucNumericTextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQta As ucNumericTextBox
    Friend WithEvents txtCerca As System.Windows.Forms.TextBox
    Friend WithEvents lblPrezzoUnit As System.Windows.Forms.Label
    Friend WithEvents txtPrezzoUnit As System.Windows.Forms.TextBox
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescrForn As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpCerca As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgArticoliForn As System.Windows.Forms.DataGridView
    Friend WithEvents txtCodiceForn As System.Windows.Forms.TextBox
    Friend WithEvents lblProdotti As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNota As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnDett As Button
    Friend WithEvents lblFatt As Label
    Friend WithEvents txtPesoKg As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPrezzoKg As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lnkRiapriDocFiscale As Button
    Friend WithEvents pctRis As ucPictureWithZoom
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbCategoria As ComboBox
    Friend WithEvents cmbRisorsa As ucComboWithImage
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCercaRis As TextBox
    Friend WithEvents pctSblocca As PictureBox
End Class
