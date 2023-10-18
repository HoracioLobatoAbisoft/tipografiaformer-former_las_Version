<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMagazzinoMovimento
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
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.pnlRisorsa = New Telerik.WinControls.UI.RadCollapsiblePanel()
        Me.btnSostituisci = New System.Windows.Forms.Button()
        Me.btnDettRis = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbRis = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDataMov = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblPrezzoKg = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpFornitore = New System.Windows.Forms.GroupBox()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbFornitore = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescrForn = New System.Windows.Forms.TextBox()
        Me.txtCodiceForn = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQta = New Former.ucNumericTextBox()
        Me.cmbTipoMov = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPrezzo = New System.Windows.Forms.Label()
        Me.txtPrezzo = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ChiudiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalvaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiapriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CaricoDiMagazzinoAnticipatoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommessaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RisorsaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pnlRisorsa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRisorsa.PanelContainer.SuspendLayout()
        Me.grpFornitore.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(596, 453)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.pnlRisorsa)
        Me.tbProd.Controls.Add(Me.lblDataMov)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.lblPrezzoKg)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.grpFornitore)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtQta)
        Me.tbProd.Controls.Add(Me.cmbTipoMov)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.lblPrezzo)
        Me.tbProd.Controls.Add(Me.txtPrezzo)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(588, 427)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Magazzino"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'pnlRisorsa
        '
        Me.pnlRisorsa.AnimationType = Telerik.WinControls.UI.CollapsiblePanelAnimationType.Slide
        Me.pnlRisorsa.BackColor = System.Drawing.Color.White
        Me.pnlRisorsa.EnableAnimation = False
        Me.pnlRisorsa.EnableTheming = False
        Me.pnlRisorsa.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.pnlRisorsa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.pnlRisorsa.HeaderText = "-"
        Me.pnlRisorsa.IsExpanded = False
        Me.pnlRisorsa.Location = New System.Drawing.Point(42, 46)
        Me.pnlRisorsa.Name = "pnlRisorsa"
        Me.pnlRisorsa.OwnerBoundsCache = New System.Drawing.Rectangle(42, 46, 509, 154)
        '
        'pnlRisorsa.PanelContainer
        '
        Me.pnlRisorsa.PanelContainer.Controls.Add(Me.btnSostituisci)
        Me.pnlRisorsa.PanelContainer.Controls.Add(Me.btnDettRis)
        Me.pnlRisorsa.PanelContainer.Controls.Add(Me.Label11)
        Me.pnlRisorsa.PanelContainer.Controls.Add(Me.cmbRis)
        Me.pnlRisorsa.PanelContainer.Controls.Add(Me.Label4)
        Me.pnlRisorsa.PanelContainer.Controls.Add(Me.txtCerca)
        Me.pnlRisorsa.PanelContainer.Controls.Add(Me.Label3)
        Me.pnlRisorsa.PanelContainer.Size = New System.Drawing.Size(0, 0)
        Me.pnlRisorsa.ShowHeaderLine = False
        Me.pnlRisorsa.Size = New System.Drawing.Size(509, 23)
        Me.pnlRisorsa.TabIndex = 40
        CType(Me.pnlRisorsa.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).IsExpanded = False
        CType(Me.pnlRisorsa.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).AnimationType = Telerik.WinControls.UI.CollapsiblePanelAnimationType.Slide
        '
        'btnSostituisci
        '
        Me.btnSostituisci.Location = New System.Drawing.Point(218, 96)
        Me.btnSostituisci.Name = "btnSostituisci"
        Me.btnSostituisci.Size = New System.Drawing.Size(75, 23)
        Me.btnSostituisci.TabIndex = 74
        Me.btnSostituisci.Text = "Sostituisci"
        Me.btnSostituisci.UseVisualStyleBackColor = True
        '
        'btnDettRis
        '
        Me.btnDettRis.Location = New System.Drawing.Point(479, 69)
        Me.btnDettRis.Name = "btnDettRis"
        Me.btnDettRis.Size = New System.Drawing.Size(25, 23)
        Me.btnDettRis.TabIndex = 73
        Me.btnDettRis.Text = "..."
        Me.btnDettRis.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(7, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 15)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Sostituisci con ..."
        '
        'cmbRis
        '
        Me.cmbRis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRis.FormattingEnabled = True
        Me.cmbRis.Location = New System.Drawing.Point(86, 69)
        Me.cmbRis.Name = "cmbRis"
        Me.cmbRis.Size = New System.Drawing.Size(387, 21)
        Me.cmbRis.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(2, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Seleziona:"
        '
        'txtCerca
        '
        Me.txtCerca.Location = New System.Drawing.Point(86, 43)
        Me.txtCerca.MaxLength = 50
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(137, 20)
        Me.txtCerca.TabIndex = 0
        Me.txtCerca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(2, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Cerca:"
        '
        'lblDataMov
        '
        Me.lblDataMov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDataMov.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDataMov.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDataMov.Location = New System.Drawing.Point(406, 112)
        Me.lblDataMov.Name = "lblDataMov"
        Me.lblDataMov.Size = New System.Drawing.Size(145, 21)
        Me.lblDataMov.TabIndex = 39
        Me.lblDataMov.Text = "-"
        Me.lblDataMov.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(328, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 15)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Data"
        '
        'lblPrezzoKg
        '
        Me.lblPrezzoKg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrezzoKg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblPrezzoKg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPrezzoKg.ForeColor = System.Drawing.Color.Black
        Me.lblPrezzoKg.Location = New System.Drawing.Point(410, 185)
        Me.lblPrezzoKg.Name = "lblPrezzoKg"
        Me.lblPrezzoKg.Size = New System.Drawing.Size(141, 21)
        Me.lblPrezzoKg.TabIndex = 37
        Me.lblPrezzoKg.Text = "-"
        Me.lblPrezzoKg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(328, 188)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 15)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Prezzo al KG"
        '
        'grpFornitore
        '
        Me.grpFornitore.Controls.Add(Me.txtNota)
        Me.grpFornitore.Controls.Add(Me.Label8)
        Me.grpFornitore.Controls.Add(Me.cmbFornitore)
        Me.grpFornitore.Controls.Add(Me.Label6)
        Me.grpFornitore.Controls.Add(Me.Label5)
        Me.grpFornitore.Controls.Add(Me.Label7)
        Me.grpFornitore.Controls.Add(Me.txtDescrForn)
        Me.grpFornitore.Controls.Add(Me.txtCodiceForn)
        Me.grpFornitore.Location = New System.Drawing.Point(42, 249)
        Me.grpFornitore.Name = "grpFornitore"
        Me.grpFornitore.Size = New System.Drawing.Size(515, 168)
        Me.grpFornitore.TabIndex = 35
        Me.grpFornitore.TabStop = False
        Me.grpFornitore.Text = "Fornitore"
        Me.grpFornitore.Visible = False
        '
        'txtNota
        '
        Me.txtNota.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtNota.Location = New System.Drawing.Point(87, 103)
        Me.txtNota.MaxLength = 250
        Me.txtNota.Multiline = True
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(422, 56)
        Me.txtNota.TabIndex = 37
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(9, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Annotazioni"
        '
        'cmbFornitore
        '
        Me.cmbFornitore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFornitore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFornitore.FormattingEnabled = True
        Me.cmbFornitore.Location = New System.Drawing.Point(87, 20)
        Me.cmbFornitore.Name = "cmbFornitore"
        Me.cmbFornitore.Size = New System.Drawing.Size(422, 21)
        Me.cmbFornitore.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 15)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Seleziona:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Codice"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Descrizione"
        '
        'txtDescrForn
        '
        Me.txtDescrForn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtDescrForn.Location = New System.Drawing.Point(87, 76)
        Me.txtDescrForn.MaxLength = 150
        Me.txtDescrForn.Name = "txtDescrForn"
        Me.txtDescrForn.Size = New System.Drawing.Size(422, 23)
        Me.txtDescrForn.TabIndex = 32
        Me.toolTipHelp.SetToolTip(Me.txtDescrForn, "Inserire la descrizione di questo prodotto da questo fornitore")
        '
        'txtCodiceForn
        '
        Me.txtCodiceForn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodiceForn.Location = New System.Drawing.Point(87, 49)
        Me.txtCodiceForn.MaxLength = 50
        Me.txtCodiceForn.Name = "txtCodiceForn"
        Me.txtCodiceForn.Size = New System.Drawing.Size(137, 23)
        Me.txtCodiceForn.TabIndex = 31
        Me.toolTipHelp.SetToolTip(Me.txtCodiceForn, "Inserire il codice di questo prodotto da questo fornitore")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(49, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 21)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Quantità"
        '
        'txtQta
        '
        Me.txtQta.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtQta.Location = New System.Drawing.Point(129, 146)
        Me.txtQta.MaxLength = 50
        Me.txtQta.My_AccettaNegativi = False
        Me.txtQta.My_AllowOnlyInteger = False
        Me.txtQta.My_DefaultValue = 0
        Me.txtQta.My_MaxValue = 1.0E+10!
        Me.txtQta.My_MinValue = -1.0E+9!
        Me.txtQta.My_ReplaceWithDefaultValue = True
        Me.txtQta.Name = "txtQta"
        Me.txtQta.Size = New System.Drawing.Size(137, 32)
        Me.txtQta.TabIndex = 1
        Me.txtQta.Text = "0"
        Me.txtQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoMov
        '
        Me.cmbTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMov.FormattingEnabled = True
        Me.cmbTipoMov.Location = New System.Drawing.Point(129, 114)
        Me.cmbTipoMov.Name = "cmbTipoMov"
        Me.cmbTipoMov.Size = New System.Drawing.Size(137, 21)
        Me.cmbTipoMov.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(51, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo"
        '
        'lblPrezzo
        '
        Me.lblPrezzo.AutoSize = True
        Me.lblPrezzo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPrezzo.ForeColor = System.Drawing.Color.Black
        Me.lblPrezzo.Location = New System.Drawing.Point(50, 188)
        Me.lblPrezzo.Name = "lblPrezzo"
        Me.lblPrezzo.Size = New System.Drawing.Size(41, 15)
        Me.lblPrezzo.TabIndex = 17
        Me.lblPrezzo.Text = "Prezzo"
        '
        'txtPrezzo
        '
        Me.txtPrezzo.Location = New System.Drawing.Point(129, 185)
        Me.txtPrezzo.MaxLength = 50
        Me.txtPrezzo.Name = "txtPrezzo"
        Me.txtPrezzo.Size = New System.Drawing.Size(137, 20)
        Me.txtPrezzo.TabIndex = 2
        Me.txtPrezzo.Text = "0"
        Me.txtPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Magazzino"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChiudiToolStripMenuItem, Me.SalvaToolStripMenuItem, Me.PesoToolStripMenuItem, Me.RiapriToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 453)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(596, 44)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ChiudiToolStripMenuItem
        '
        Me.ChiudiToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ChiudiToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChiudiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Annulla
        Me.ChiudiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ChiudiToolStripMenuItem.Name = "ChiudiToolStripMenuItem"
        Me.ChiudiToolStripMenuItem.Size = New System.Drawing.Size(80, 40)
        Me.ChiudiToolStripMenuItem.Text = "Chiudi"
        '
        'SalvaToolStripMenuItem
        '
        Me.SalvaToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SalvaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SalvaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Ok
        Me.SalvaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalvaToolStripMenuItem.Name = "SalvaToolStripMenuItem"
        Me.SalvaToolStripMenuItem.Size = New System.Drawing.Size(72, 40)
        Me.SalvaToolStripMenuItem.Text = "Salva"
        '
        'PesoToolStripMenuItem
        '
        Me.PesoToolStripMenuItem.Image = Global.Former.My.Resources.Resources.scale
        Me.PesoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PesoToolStripMenuItem.Name = "PesoToolStripMenuItem"
        Me.PesoToolStripMenuItem.Size = New System.Drawing.Size(70, 40)
        Me.PesoToolStripMenuItem.Text = "Peso"
        '
        'RiapriToolStripMenuItem
        '
        Me.RiapriToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CaricoDiMagazzinoAnticipatoToolStripMenuItem, Me.CommessaToolStripMenuItem, Me.RisorsaToolStripMenuItem})
        Me.RiapriToolStripMenuItem.Image = Global.Former.My.Resources.Resources._CartellaAperta
        Me.RiapriToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RiapriToolStripMenuItem.Name = "RiapriToolStripMenuItem"
        Me.RiapriToolStripMenuItem.Size = New System.Drawing.Size(76, 40)
        Me.RiapriToolStripMenuItem.Text = "Apri..."
        '
        'CaricoDiMagazzinoAnticipatoToolStripMenuItem
        '
        Me.CaricoDiMagazzinoAnticipatoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._CaricoMagazzino
        Me.CaricoDiMagazzinoAnticipatoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CaricoDiMagazzinoAnticipatoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CaricoDiMagazzinoAnticipatoToolStripMenuItem.Name = "CaricoDiMagazzinoAnticipatoToolStripMenuItem"
        Me.CaricoDiMagazzinoAnticipatoToolStripMenuItem.Size = New System.Drawing.Size(247, 32)
        Me.CaricoDiMagazzinoAnticipatoToolStripMenuItem.Text = "Carico di Magazzino anticipato"
        '
        'CommessaToolStripMenuItem
        '
        Me.CommessaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Commessa
        Me.CommessaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CommessaToolStripMenuItem.Name = "CommessaToolStripMenuItem"
        Me.CommessaToolStripMenuItem.Size = New System.Drawing.Size(247, 32)
        Me.CommessaToolStripMenuItem.Text = "Commessa"
        '
        'RisorsaToolStripMenuItem
        '
        Me.RisorsaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Risorsa
        Me.RisorsaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RisorsaToolStripMenuItem.Name = "RisorsaToolStripMenuItem"
        Me.RisorsaToolStripMenuItem.Size = New System.Drawing.Size(247, 32)
        Me.RisorsaToolStripMenuItem.Text = "Risorsa"
        '
        'frmMagazzinoMovimento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(596, 497)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmMagazzinoMovimento"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Magazzino"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.pnlRisorsa.PanelContainer.ResumeLayout(False)
        Me.pnlRisorsa.PanelContainer.PerformLayout()
        CType(Me.pnlRisorsa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFornitore.ResumeLayout(False)
        Me.grpFornitore.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents cmbTipoMov As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPrezzo As System.Windows.Forms.Label
    Friend WithEvents txtPrezzo As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQta As ucNumericTextBox
    Friend WithEvents cmbRis As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCerca As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDescrForn As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCodiceForn As TextBox
    Friend WithEvents grpFornitore As GroupBox
    Friend WithEvents cmbFornitore As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNota As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblPrezzoKg As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblDataMov As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents pnlRisorsa As Telerik.WinControls.UI.RadCollapsiblePanel
    Friend WithEvents Label11 As Label
    Friend WithEvents btnDettRis As Button
    Friend WithEvents btnSostituisci As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ChiudiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalvaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PesoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RiapriToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CaricoDiMagazzinoAnticipatoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CommessaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RisorsaToolStripMenuItem As ToolStripMenuItem
End Class
