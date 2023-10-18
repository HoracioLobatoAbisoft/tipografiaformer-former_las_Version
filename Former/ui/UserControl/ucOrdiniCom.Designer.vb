<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrdiniCom
    Inherits ucFormerUserControl

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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainerExt1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerOrdini = New System.Windows.Forms.SplitContainer()
        Me.lnkOrd = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnkAggiungi = New System.Windows.Forms.LinkLabel()
        Me.DGOrdiniDisp = New System.Windows.Forms.DataGridView()
        Me.lnkDettLavSel = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGOrdiniSel = New System.Windows.Forms.DataGridView()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.UcOrdineAnteprima = New Former.ucOrdiniAnteprima()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainerExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerExt1.Panel1.SuspendLayout()
        Me.SplitContainerExt1.Panel2.SuspendLayout()
        Me.SplitContainerExt1.SuspendLayout()
        CType(Me.SplitContainerOrdini, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerOrdini.Panel1.SuspendLayout()
        Me.SplitContainerOrdini.Panel2.SuspendLayout()
        Me.SplitContainerOrdini.SuspendLayout()
        CType(Me.DGOrdiniDisp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGOrdiniSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(788, 544)
        Me.TabControl1.TabIndex = 63
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainerExt1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(780, 516)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ordini"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainerExt1
        '
        Me.SplitContainerExt1.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainerExt1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerExt1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerExt1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerExt1.Name = "SplitContainerExt1"
        '
        'SplitContainerExt1.Panel1
        '
        Me.SplitContainerExt1.Panel1.Controls.Add(Me.SplitContainerOrdini)
        '
        'SplitContainerExt1.Panel2
        '
        Me.SplitContainerExt1.Panel2.Controls.Add(Me.UcOrdineAnteprima)
        Me.SplitContainerExt1.Size = New System.Drawing.Size(774, 510)
        Me.SplitContainerExt1.SplitterDistance = 410
        Me.SplitContainerExt1.SplitterWidth = 10
        Me.SplitContainerExt1.TabIndex = 102
        '
        'SplitContainerOrdini
        '
        Me.SplitContainerOrdini.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainerOrdini.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainerOrdini.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerOrdini.Name = "SplitContainerOrdini"
        Me.SplitContainerOrdini.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerOrdini.Panel1
        '
        Me.SplitContainerOrdini.Panel1.Controls.Add(Me.lnkOrd)
        Me.SplitContainerOrdini.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerOrdini.Panel1.Controls.Add(Me.lnkAggiungi)
        Me.SplitContainerOrdini.Panel1.Controls.Add(Me.DGOrdiniDisp)
        '
        'SplitContainerOrdini.Panel2
        '
        Me.SplitContainerOrdini.Panel2.Controls.Add(Me.lnkDettLavSel)
        Me.SplitContainerOrdini.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainerOrdini.Panel2.Controls.Add(Me.DGOrdiniSel)
        Me.SplitContainerOrdini.Panel2.Controls.Add(Me.lnkDel)
        Me.SplitContainerOrdini.Size = New System.Drawing.Size(404, 504)
        Me.SplitContainerOrdini.SplitterDistance = 168
        Me.SplitContainerOrdini.SplitterWidth = 10
        Me.SplitContainerOrdini.TabIndex = 100
        '
        'lnkOrd
        '
        Me.lnkOrd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkOrd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkOrd.Image = Global.Former.My.Resources.Resources._Ordine
        Me.lnkOrd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkOrd.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkOrd.Location = New System.Drawing.Point(218, 7)
        Me.lnkOrd.Name = "lnkOrd"
        Me.lnkOrd.Size = New System.Drawing.Size(86, 29)
        Me.lnkOrd.TabIndex = 62
        Me.lnkOrd.TabStop = True
        Me.lnkOrd.Text = "Dettaglio"
        Me.lnkOrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Ordini Disponibili"
        '
        'lnkAggiungi
        '
        Me.lnkAggiungi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiungi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiungi.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAggiungi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiungi.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiungi.Location = New System.Drawing.Point(310, 7)
        Me.lnkAggiungi.Name = "lnkAggiungi"
        Me.lnkAggiungi.Size = New System.Drawing.Size(86, 29)
        Me.lnkAggiungi.TabIndex = 61
        Me.lnkAggiungi.TabStop = True
        Me.lnkAggiungi.Text = "Aggiungi"
        Me.lnkAggiungi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DGOrdiniDisp
        '
        Me.DGOrdiniDisp.AllowUserToAddRows = False
        Me.DGOrdiniDisp.AllowUserToDeleteRows = False
        Me.DGOrdiniDisp.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdiniDisp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGOrdiniDisp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGOrdiniDisp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGOrdiniDisp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGOrdiniDisp.BackgroundColor = System.Drawing.Color.White
        Me.DGOrdiniDisp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGOrdiniDisp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGOrdiniDisp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGOrdiniDisp.ColumnHeadersHeight = 20
        Me.DGOrdiniDisp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdiniDisp.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGOrdiniDisp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGOrdiniDisp.EnableHeadersVisualStyles = False
        Me.DGOrdiniDisp.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DGOrdiniDisp.Location = New System.Drawing.Point(6, 39)
        Me.DGOrdiniDisp.MultiSelect = False
        Me.DGOrdiniDisp.Name = "DGOrdiniDisp"
        Me.DGOrdiniDisp.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdiniDisp.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGOrdiniDisp.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdiniDisp.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGOrdiniDisp.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DGOrdiniDisp.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DGOrdiniDisp.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdiniDisp.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdiniDisp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGOrdiniDisp.Size = New System.Drawing.Size(390, 126)
        Me.DGOrdiniDisp.TabIndex = 57
        Me.DGOrdiniDisp.TabStop = False
        '
        'lnkDettLavSel
        '
        Me.lnkDettLavSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDettLavSel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDettLavSel.Image = Global.Former.My.Resources.Resources._Ordine
        Me.lnkDettLavSel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDettLavSel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDettLavSel.Location = New System.Drawing.Point(223, 10)
        Me.lnkDettLavSel.Name = "lnkDettLavSel"
        Me.lnkDettLavSel.Size = New System.Drawing.Size(86, 29)
        Me.lnkDettLavSel.TabIndex = 63
        Me.lnkDettLavSel.TabStop = True
        Me.lnkDettLavSel.Text = "Dettaglio"
        Me.lnkDettLavSel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(4, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 15)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Ordini Selezionati"
        '
        'DGOrdiniSel
        '
        Me.DGOrdiniSel.AllowUserToAddRows = False
        Me.DGOrdiniSel.AllowUserToDeleteRows = False
        Me.DGOrdiniSel.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdiniSel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DGOrdiniSel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGOrdiniSel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGOrdiniSel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGOrdiniSel.BackgroundColor = System.Drawing.Color.White
        Me.DGOrdiniSel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGOrdiniSel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGOrdiniSel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGOrdiniSel.ColumnHeadersHeight = 20
        Me.DGOrdiniSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdiniSel.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGOrdiniSel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGOrdiniSel.EnableHeadersVisualStyles = False
        Me.DGOrdiniSel.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DGOrdiniSel.Location = New System.Drawing.Point(6, 42)
        Me.DGOrdiniSel.MultiSelect = False
        Me.DGOrdiniSel.Name = "DGOrdiniSel"
        Me.DGOrdiniSel.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdiniSel.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGOrdiniSel.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdiniSel.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DGOrdiniSel.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DGOrdiniSel.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DGOrdiniSel.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOrdiniSel.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrdiniSel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGOrdiniSel.Size = New System.Drawing.Size(390, 275)
        Me.DGOrdiniSel.TabIndex = 59
        Me.DGOrdiniSel.TabStop = False
        '
        'lnkDel
        '
        Me.lnkDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._remove
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(315, 10)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Size = New System.Drawing.Size(80, 29)
        Me.lnkDel.TabIndex = 62
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Rimuovi"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UcOrdineAnteprima
        '
        Me.UcOrdineAnteprima.BackColor = System.Drawing.Color.White
        Me.UcOrdineAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOrdineAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdineAnteprima.Location = New System.Drawing.Point(0, 0)
        Me.UcOrdineAnteprima.Name = "UcOrdineAnteprima"
        Me.UcOrdineAnteprima.NascondiResto = False
        Me.UcOrdineAnteprima.NoLavori = False
        Me.UcOrdineAnteprima.Size = New System.Drawing.Size(354, 510)
        Me.UcOrdineAnteprima.TabIndex = 101
        '
        'ucOrdiniCom
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ucOrdiniCom"
        Me.Size = New System.Drawing.Size(788, 544)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainerExt1.Panel1.ResumeLayout(False)
        Me.SplitContainerExt1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerExt1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerExt1.ResumeLayout(False)
        Me.SplitContainerOrdini.Panel1.ResumeLayout(False)
        Me.SplitContainerOrdini.Panel1.PerformLayout()
        Me.SplitContainerOrdini.Panel2.ResumeLayout(False)
        Me.SplitContainerOrdini.Panel2.PerformLayout()
        CType(Me.SplitContainerOrdini, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerOrdini.ResumeLayout(False)
        CType(Me.DGOrdiniDisp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGOrdiniSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGOrdiniDisp As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGOrdiniSel As System.Windows.Forms.DataGridView
    Friend WithEvents lnkAggiungi As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDel As System.Windows.Forms.LinkLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainerOrdini As SplitContainer
    Friend WithEvents UcOrdineAnteprima As Former.ucOrdiniAnteprima
    Friend WithEvents SplitContainerExt1 As SplitContainer
    Friend WithEvents lnkOrd As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDettLavSel As LinkLabel
End Class
