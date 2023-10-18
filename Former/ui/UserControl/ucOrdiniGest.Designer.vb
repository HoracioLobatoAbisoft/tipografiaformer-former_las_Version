<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrdiniGest
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucOrdiniGest))
        Me.rdoSospeso = New System.Windows.Forms.RadioButton()
        Me.rdoReg = New System.Windows.Forms.RadioButton()
        Me.rdoPre = New System.Windows.Forms.RadioButton()
        Me.lblNumRis = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnkNewCom = New System.Windows.Forms.LinkLabel()
        Me.cmbTipoCom = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNumSpaziDisp = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNumSpaziUsati = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuOrd = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuInviaMail = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ModificaDatiEconomiciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AllegaMessaggioAllordineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGOrdini = New System.Windows.Forms.DataGridView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoRifiutato = New System.Windows.Forms.RadioButton()
        Me.pctAnteprimaModello = New System.Windows.Forms.PictureBox()
        Me.cmbModelloCommessa = New Former.ucCTRComboWithImage()
        Me.lblNumSpazi = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tvwCat = New Former.ucCTRTreeViewExtended()
        Me.IcoMsg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.IcoTipo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.IdOrdLista = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataCons = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProdottoDescrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClienteRagSoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Totale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Spz = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duplic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Corriere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.MenuOrd.SuspendLayout()
        CType(Me.DGOrdini, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pctAnteprimaModello, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdoSospeso
        '
        Me.rdoSospeso.BackColor = System.Drawing.Color.Red
        Me.rdoSospeso.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.rdoSospeso.ForeColor = System.Drawing.Color.White
        Me.rdoSospeso.Location = New System.Drawing.Point(306, 127)
        Me.rdoSospeso.Name = "rdoSospeso"
        Me.rdoSospeso.Size = New System.Drawing.Size(90, 20)
        Me.rdoSospeso.TabIndex = 95
        Me.rdoSospeso.Text = "In Sospeso"
        Me.rdoSospeso.UseVisualStyleBackColor = False
        '
        'rdoReg
        '
        Me.rdoReg.Checked = True
        Me.rdoReg.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.rdoReg.ForeColor = System.Drawing.Color.Black
        Me.rdoReg.Location = New System.Drawing.Point(306, 102)
        Me.rdoReg.Name = "rdoReg"
        Me.rdoReg.Size = New System.Drawing.Size(90, 20)
        Me.rdoReg.TabIndex = 0
        Me.rdoReg.TabStop = True
        Me.rdoReg.Text = "Registrato"
        Me.rdoReg.UseVisualStyleBackColor = True
        '
        'rdoPre
        '
        Me.rdoPre.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.rdoPre.ForeColor = System.Drawing.Color.Black
        Me.rdoPre.Location = New System.Drawing.Point(306, 79)
        Me.rdoPre.Name = "rdoPre"
        Me.rdoPre.Size = New System.Drawing.Size(90, 19)
        Me.rdoPre.TabIndex = 0
        Me.rdoPre.Text = "Preinserito"
        Me.rdoPre.UseVisualStyleBackColor = True
        '
        'lblNumRis
        '
        Me.lblNumRis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumRis.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblNumRis.Location = New System.Drawing.Point(814, 402)
        Me.lblNumRis.Name = "lblNumRis"
        Me.lblNumRis.Size = New System.Drawing.Size(33, 13)
        Me.lblNumRis.TabIndex = 59
        Me.lblNumRis.Text = "0"
        Me.lblNumRis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label1.Location = New System.Drawing.Point(723, 402)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Risultato ricerca:"
        '
        'lnkNewCom
        '
        Me.lnkNewCom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNewCom.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lnkNewCom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNewCom.Image = Global.Former.My.Resources.Resources.grid
        Me.lnkNewCom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNewCom.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNewCom.Location = New System.Drawing.Point(770, 97)
        Me.lnkNewCom.Name = "lnkNewCom"
        Me.lnkNewCom.Size = New System.Drawing.Size(65, 32)
        Me.lnkNewCom.TabIndex = 93
        Me.lnkNewCom.TabStop = True
        Me.lnkNewCom.Text = "Crea"
        Me.lnkNewCom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipoCom
        '
        Me.cmbTipoCom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoCom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipoCom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoCom.FormattingEnabled = True
        Me.cmbTipoCom.Location = New System.Drawing.Point(409, 33)
        Me.cmbTipoCom.Name = "cmbTipoCom"
        Me.cmbTipoCom.Size = New System.Drawing.Size(426, 23)
        Me.cmbTipoCom.TabIndex = 94
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(303, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 15)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Tipo Commessa"
        '
        'lblNumSpaziDisp
        '
        Me.lblNumSpaziDisp.BackColor = System.Drawing.Color.Green
        Me.lblNumSpaziDisp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumSpaziDisp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumSpaziDisp.ForeColor = System.Drawing.Color.White
        Me.lblNumSpaziDisp.Location = New System.Drawing.Point(79, 36)
        Me.lblNumSpaziDisp.Name = "lblNumSpaziDisp"
        Me.lblNumSpaziDisp.Size = New System.Drawing.Size(39, 23)
        Me.lblNumSpaziDisp.TabIndex = 96
        Me.lblNumSpaziDisp.Text = "0"
        Me.lblNumSpaziDisp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(13, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Spazi Disp."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(13, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "Spazi Usati"
        '
        'lblNumSpaziUsati
        '
        Me.lblNumSpaziUsati.BackColor = System.Drawing.Color.Red
        Me.lblNumSpaziUsati.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumSpaziUsati.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumSpaziUsati.ForeColor = System.Drawing.Color.White
        Me.lblNumSpaziUsati.Location = New System.Drawing.Point(79, 7)
        Me.lblNumSpaziUsati.Name = "lblNumSpaziUsati"
        Me.lblNumSpaziUsati.Size = New System.Drawing.Size(39, 23)
        Me.lblNumSpaziUsati.TabIndex = 98
        Me.lblNumSpaziUsati.Text = "0"
        Me.lblNumSpaziUsati.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblNumSpaziDisp)
        Me.Panel1.Controls.Add(Me.lblNumSpaziUsati)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(633, 79)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(131, 66)
        Me.Panel1.TabIndex = 100
        '
        'MenuOrd
        '
        Me.MenuOrd.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInviaMail, Me.ToolStripSeparator1, Me.ToolStripMenuItem3, Me.ToolStripMenuItem1, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem2, Me.ToolStripSeparator2, Me.ModificaDatiEconomiciToolStripMenuItem, Me.ToolStripSeparator4, Me.AllegaMessaggioAllordineToolStripMenuItem})
        Me.MenuOrd.Name = "MenuOrd"
        Me.MenuOrd.Size = New System.Drawing.Size(222, 198)
        '
        'mnuInviaMail
        '
        Me.mnuInviaMail.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mnuInviaMail.Name = "mnuInviaMail"
        Me.mnuInviaMail.Size = New System.Drawing.Size(221, 22)
        Me.mnuInviaMail.Text = "Invia mail al cliente..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(218, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem3.Text = "Passa l'ordine a Preinserito"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem1.Text = "Passa l'ordine a Registrato"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem4.Text = "Passa l'ordine a In sospeso"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem5.Text = "Passa l'ordine a Rifiutato"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem2.Text = "Passa l'ordine a Imballaggio"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(218, 6)
        '
        'ModificaDatiEconomiciToolStripMenuItem
        '
        Me.ModificaDatiEconomiciToolStripMenuItem.Name = "ModificaDatiEconomiciToolStripMenuItem"
        Me.ModificaDatiEconomiciToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ModificaDatiEconomiciToolStripMenuItem.Text = "Modifica importi"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(218, 6)
        '
        'AllegaMessaggioAllordineToolStripMenuItem
        '
        Me.AllegaMessaggioAllordineToolStripMenuItem.Name = "AllegaMessaggioAllordineToolStripMenuItem"
        Me.AllegaMessaggioAllordineToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.AllegaMessaggioAllordineToolStripMenuItem.Text = "Allega messaggio all'ordine"
        '
        'DGOrdini
        '
        Me.DGOrdini.AllowUserToAddRows = False
        Me.DGOrdini.AllowUserToDeleteRows = False
        Me.DGOrdini.AllowUserToOrderColumns = True
        Me.DGOrdini.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdini.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGOrdini.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGOrdini.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGOrdini.BackgroundColor = System.Drawing.Color.White
        Me.DGOrdini.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGOrdini.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGOrdini.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGOrdini.ColumnHeadersHeight = 20
        Me.DGOrdini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGOrdini.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IcoMsg, Me.IcoTipo, Me.IdOrdLista, Me.DataCons, Me.ProdottoDescrizione, Me.ClienteRagSoc, Me.Totale, Me.Spz, Me.Duplic, Me.Corriere})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdini.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGOrdini.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGOrdini.EnableHeadersVisualStyles = False
        Me.DGOrdini.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DGOrdini.Location = New System.Drawing.Point(309, 244)
        Me.DGOrdini.Name = "DGOrdini"
        Me.DGOrdini.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdini.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGOrdini.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdini.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGOrdini.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.DGOrdini.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DGOrdini.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdini.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGOrdini.Size = New System.Drawing.Size(535, 155)
        Me.DGOrdini.TabIndex = 101
        Me.DGOrdini.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder.png")
        Me.ImageList1.Images.SetKeyName(1, "folder(1).png")
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rdoRifiutato)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.pctAnteprimaModello)
        Me.GroupBox1.Controls.Add(Me.lnkNewCom)
        Me.GroupBox1.Controls.Add(Me.rdoSospeso)
        Me.GroupBox1.Controls.Add(Me.cmbTipoCom)
        Me.GroupBox1.Controls.Add(Me.rdoReg)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.rdoPre)
        Me.GroupBox1.Controls.Add(Me.cmbModelloCommessa)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(841, 235)
        Me.GroupBox1.TabIndex = 107
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Creazione Commessa"
        '
        'rdoRifiutato
        '
        Me.rdoRifiutato.BackColor = System.Drawing.Color.White
        Me.rdoRifiutato.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.rdoRifiutato.ForeColor = System.Drawing.Color.Black
        Me.rdoRifiutato.Location = New System.Drawing.Point(306, 153)
        Me.rdoRifiutato.Name = "rdoRifiutato"
        Me.rdoRifiutato.Size = New System.Drawing.Size(90, 20)
        Me.rdoRifiutato.TabIndex = 109
        Me.rdoRifiutato.Text = "Rifiutato"
        Me.rdoRifiutato.UseVisualStyleBackColor = False
        '
        'pctAnteprimaModello
        '
        Me.pctAnteprimaModello.Location = New System.Drawing.Point(6, 20)
        Me.pctAnteprimaModello.Name = "pctAnteprimaModello"
        Me.pctAnteprimaModello.Size = New System.Drawing.Size(294, 208)
        Me.pctAnteprimaModello.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctAnteprimaModello.TabIndex = 108
        Me.pctAnteprimaModello.TabStop = False
        '
        'cmbModelloCommessa
        '
        Me.cmbModelloCommessa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbModelloCommessa.DisplayMember = "Text"
        Me.cmbModelloCommessa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbModelloCommessa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModelloCommessa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbModelloCommessa.FormattingEnabled = True
        Me.cmbModelloCommessa.HeightImg = 60
        Me.cmbModelloCommessa.ItemHeight = 60
        Me.cmbModelloCommessa.Location = New System.Drawing.Point(409, 79)
        Me.cmbModelloCommessa.Name = "cmbModelloCommessa"
        Me.cmbModelloCommessa.Size = New System.Drawing.Size(218, 66)
        Me.cmbModelloCommessa.TabIndex = 104
        Me.cmbModelloCommessa.ValueMember = "Id"
        Me.cmbModelloCommessa.WidthImg = 80
        '
        'lblNumSpazi
        '
        Me.lblNumSpazi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumSpazi.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.lblNumSpazi.Location = New System.Drawing.Point(394, 402)
        Me.lblNumSpazi.Name = "lblNumSpazi"
        Me.lblNumSpazi.Size = New System.Drawing.Size(32, 13)
        Me.lblNumSpazi.TabIndex = 109
        Me.lblNumSpazi.Text = "0"
        Me.lblNumSpazi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label6.Location = New System.Drawing.Point(306, 402)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "N° Spazi ricerca"
        '
        'tvwCat
        '
        Me.tvwCat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvwCat.HideSelection = False
        Me.tvwCat.ImageIndex = 0
        Me.tvwCat.ImageList = Me.ImageList1
        Me.tvwCat.ItemHeight = 24
        Me.tvwCat.Location = New System.Drawing.Point(3, 244)
        Me.tvwCat.Name = "tvwCat"
        Me.tvwCat.SelectedImageIndex = 0
        Me.tvwCat.Size = New System.Drawing.Size(300, 155)
        Me.tvwCat.TabIndex = 105
        '
        'IcoMsg
        '
        Me.IcoMsg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IcoMsg.DataPropertyName = "IcoMsg"
        Me.IcoMsg.HeaderText = ""
        Me.IcoMsg.Name = "IcoMsg"
        Me.IcoMsg.ReadOnly = True
        Me.IcoMsg.Width = 16
        '
        'IcoTipo
        '
        Me.IcoTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IcoTipo.DataPropertyName = "IcoTipo"
        Me.IcoTipo.HeaderText = ""
        Me.IcoTipo.Name = "IcoTipo"
        Me.IcoTipo.ReadOnly = True
        Me.IcoTipo.Width = 16
        '
        'IdOrdLista
        '
        Me.IdOrdLista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IdOrdLista.DataPropertyName = "IdOrd"
        Me.IdOrdLista.HeaderText = "Ordine"
        Me.IdOrdLista.Name = "IdOrdLista"
        Me.IdOrdLista.ReadOnly = True
        Me.IdOrdLista.Width = 45
        '
        'DataCons
        '
        Me.DataCons.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataCons.DataPropertyName = "DataConsProgrStr"
        Me.DataCons.HeaderText = "Data"
        Me.DataCons.Name = "DataCons"
        Me.DataCons.ReadOnly = True
        Me.DataCons.Width = 110
        '
        'ProdottoDescrizione
        '
        Me.ProdottoDescrizione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ProdottoDescrizione.DataPropertyName = "ProdottoDescrizione"
        Me.ProdottoDescrizione.HeaderText = "Prodotto"
        Me.ProdottoDescrizione.Name = "ProdottoDescrizione"
        Me.ProdottoDescrizione.ReadOnly = True
        Me.ProdottoDescrizione.Width = 150
        '
        'ClienteRagSoc
        '
        Me.ClienteRagSoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ClienteRagSoc.DataPropertyName = "RagSocNome"
        Me.ClienteRagSoc.HeaderText = "Cliente"
        Me.ClienteRagSoc.Name = "ClienteRagSoc"
        Me.ClienteRagSoc.ReadOnly = True
        Me.ClienteRagSoc.Width = 150
        '
        'Totale
        '
        Me.Totale.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Totale.DataPropertyName = "TotaleStr"
        Me.Totale.HeaderText = "Totale"
        Me.Totale.Name = "Totale"
        Me.Totale.ReadOnly = True
        Me.Totale.Width = 80
        '
        'Spz
        '
        Me.Spz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Spz.DataPropertyName = "NumSpazi"
        Me.Spz.FillWeight = 30.0!
        Me.Spz.HeaderText = "Spz"
        Me.Spz.Name = "Spz"
        Me.Spz.ReadOnly = True
        Me.Spz.Width = 50
        '
        'Duplic
        '
        Me.Duplic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Duplic.DataPropertyName = "NumDuplicati"
        Me.Duplic.FillWeight = 30.0!
        Me.Duplic.HeaderText = "Duplic"
        Me.Duplic.Name = "Duplic"
        Me.Duplic.ReadOnly = True
        Me.Duplic.Width = 50
        '
        'Corriere
        '
        Me.Corriere.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Corriere.DataPropertyName = "CorriereStr"
        Me.Corriere.HeaderText = "Corriere"
        Me.Corriere.Name = "Corriere"
        Me.Corriere.ReadOnly = True
        Me.Corriere.Width = 50
        '
        'ucOrdiniGest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblNumSpazi)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tvwCat)
        Me.Controls.Add(Me.DGOrdini)
        Me.Controls.Add(Me.lblNumRis)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Name = "ucOrdiniGest"
        Me.Size = New System.Drawing.Size(847, 415)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuOrd.ResumeLayout(False)
        CType(Me.DGOrdini, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctAnteprimaModello, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdoReg As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPre As System.Windows.Forms.RadioButton
    Friend WithEvents lblNumRis As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lnkNewCom As System.Windows.Forms.LinkLabel
    Friend WithEvents cmbTipoCom As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNumSpaziDisp As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNumSpaziUsati As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuOrd As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuInviaMail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ModificaDatiEconomiciToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AllegaMessaggioAllordineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem


    Friend WithEvents DGOrdini As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rdoSospeso As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbModelloCommessa As Former.ucCTRComboWithImage
    Friend WithEvents tvwCat As ucCTRTreeViewExtended
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents pctAnteprimaModello As System.Windows.Forms.PictureBox
    Friend WithEvents lblNumSpazi As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rdoRifiutato As System.Windows.Forms.RadioButton
    Friend WithEvents IcoMsg As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents IcoTipo As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents IdOrdLista As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataCons As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdottoDescrizione As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClienteRagSoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Totale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Spz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Duplic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Corriere As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
