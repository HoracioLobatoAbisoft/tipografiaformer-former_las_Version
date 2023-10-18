<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCommesseRisorse
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
        Me.DgRisorseDisponibili = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DgRisorseSelezionate = New System.Windows.Forms.DataGridView()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblQtaScaric = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblQtaNeces = New System.Windows.Forms.Label()
        Me.lblRisPredef = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainerRisorse = New System.Windows.Forms.SplitContainer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.StrumentiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpostaGiacenzaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DettaglioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MostraAncheNonDisponibiliToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AggiungiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DgRisorseDisponibili, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgRisorseSelezionate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainerRisorse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerRisorse.Panel1.SuspendLayout()
        Me.SplitContainerRisorse.Panel2.SuspendLayout()
        Me.SplitContainerRisorse.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgRisorseDisponibili
        '
        Me.DgRisorseDisponibili.AllowUserToAddRows = False
        Me.DgRisorseDisponibili.AllowUserToDeleteRows = False
        Me.DgRisorseDisponibili.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRisorseDisponibili.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgRisorseDisponibili.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgRisorseDisponibili.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgRisorseDisponibili.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgRisorseDisponibili.BackgroundColor = System.Drawing.Color.White
        Me.DgRisorseDisponibili.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgRisorseDisponibili.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgRisorseDisponibili.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgRisorseDisponibili.ColumnHeadersHeight = 20
        Me.DgRisorseDisponibili.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRisorseDisponibili.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgRisorseDisponibili.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgRisorseDisponibili.EnableHeadersVisualStyles = False
        Me.DgRisorseDisponibili.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgRisorseDisponibili.Location = New System.Drawing.Point(2, 37)
        Me.DgRisorseDisponibili.MultiSelect = False
        Me.DgRisorseDisponibili.Name = "DgRisorseDisponibili"
        Me.DgRisorseDisponibili.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRisorseDisponibili.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgRisorseDisponibili.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRisorseDisponibili.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgRisorseDisponibili.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgRisorseDisponibili.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgRisorseDisponibili.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRisorseDisponibili.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRisorseDisponibili.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgRisorseDisponibili.Size = New System.Drawing.Size(380, 279)
        Me.DgRisorseDisponibili.TabIndex = 57
        Me.DgRisorseDisponibili.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 34)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Risorse Disponibili"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(0, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 15)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Risorse Selezionate"
        '
        'DgRisorseSelezionate
        '
        Me.DgRisorseSelezionate.AllowUserToAddRows = False
        Me.DgRisorseSelezionate.AllowUserToDeleteRows = False
        Me.DgRisorseSelezionate.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRisorseSelezionate.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgRisorseSelezionate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgRisorseSelezionate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgRisorseSelezionate.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgRisorseSelezionate.BackgroundColor = System.Drawing.Color.White
        Me.DgRisorseSelezionate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgRisorseSelezionate.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgRisorseSelezionate.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DgRisorseSelezionate.ColumnHeadersHeight = 20
        Me.DgRisorseSelezionate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRisorseSelezionate.DefaultCellStyle = DataGridViewCellStyle8
        Me.DgRisorseSelezionate.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgRisorseSelezionate.EnableHeadersVisualStyles = False
        Me.DgRisorseSelezionate.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgRisorseSelezionate.Location = New System.Drawing.Point(2, 29)
        Me.DgRisorseSelezionate.MultiSelect = False
        Me.DgRisorseSelezionate.Name = "DgRisorseSelezionate"
        Me.DgRisorseSelezionate.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRisorseSelezionate.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DgRisorseSelezionate.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRisorseSelezionate.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DgRisorseSelezionate.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgRisorseSelezionate.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgRisorseSelezionate.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRisorseSelezionate.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRisorseSelezionate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgRisorseSelezionate.Size = New System.Drawing.Size(380, 82)
        Me.DgRisorseSelezionate.TabIndex = 59
        Me.DgRisorseSelezionate.TabStop = False
        '
        'lnkDel
        '
        Me.lnkDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._remove
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(298, 1)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.lnkDel.Size = New System.Drawing.Size(86, 26)
        Me.lnkDel.TabIndex = 62
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Rimuovi"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(6, 62)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(153, 18)
        Me.Label17.TabIndex = 107
        Me.Label17.Text = "Quantità caricata:"
        '
        'lblQtaScaric
        '
        Me.lblQtaScaric.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQtaScaric.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaScaric.ForeColor = System.Drawing.Color.Black
        Me.lblQtaScaric.Location = New System.Drawing.Point(131, 59)
        Me.lblQtaScaric.Name = "lblQtaScaric"
        Me.lblQtaScaric.Size = New System.Drawing.Size(247, 21)
        Me.lblQtaScaric.TabIndex = 106
        Me.lblQtaScaric.Text = "0"
        Me.lblQtaScaric.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(6, 41)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(153, 18)
        Me.Label19.TabIndex = 105
        Me.Label19.Text = "Quantità necessaria:"
        '
        'lblQtaNeces
        '
        Me.lblQtaNeces.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQtaNeces.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaNeces.ForeColor = System.Drawing.Color.Black
        Me.lblQtaNeces.Location = New System.Drawing.Point(128, 38)
        Me.lblQtaNeces.Name = "lblQtaNeces"
        Me.lblQtaNeces.Size = New System.Drawing.Size(250, 21)
        Me.lblQtaNeces.TabIndex = 104
        Me.lblQtaNeces.Text = "1"
        Me.lblQtaNeces.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRisPredef
        '
        Me.lblRisPredef.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRisPredef.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRisPredef.ForeColor = System.Drawing.Color.Black
        Me.lblRisPredef.Location = New System.Drawing.Point(6, 17)
        Me.lblRisPredef.Name = "lblRisPredef"
        Me.lblRisPredef.Size = New System.Drawing.Size(372, 21)
        Me.lblRisPredef.TabIndex = 103
        Me.lblRisPredef.Text = " -"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblQtaScaric)
        Me.GroupBox1.Controls.Add(Me.lblRisPredef)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.lblQtaNeces)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 85)
        Me.GroupBox1.TabIndex = 106
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Risorsa Predefinita"
        '
        'SplitContainerRisorse
        '
        Me.SplitContainerRisorse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainerRisorse.Location = New System.Drawing.Point(3, 94)
        Me.SplitContainerRisorse.Name = "SplitContainerRisorse"
        Me.SplitContainerRisorse.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerRisorse.Panel1
        '
        Me.SplitContainerRisorse.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerRisorse.Panel1.Controls.Add(Me.DgRisorseDisponibili)
        Me.SplitContainerRisorse.Panel1.Controls.Add(Me.MenuStrip1)
        '
        'SplitContainerRisorse.Panel2
        '
        Me.SplitContainerRisorse.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainerRisorse.Panel2.Controls.Add(Me.lnkDel)
        Me.SplitContainerRisorse.Panel2.Controls.Add(Me.DgRisorseSelezionate)
        Me.SplitContainerRisorse.Size = New System.Drawing.Size(384, 462)
        Me.SplitContainerRisorse.SplitterDistance = 320
        Me.SplitContainerRisorse.SplitterWidth = 10
        Me.SplitContainerRisorse.TabIndex = 107
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StrumentiToolStripMenuItem, Me.AggiungiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(384, 34)
        Me.MenuStrip1.TabIndex = 63
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'StrumentiToolStripMenuItem
        '
        Me.StrumentiToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StrumentiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImpostaGiacenzaToolStripMenuItem, Me.DettaglioToolStripMenuItem, Me.ToolStripSeparator1, Me.MostraAncheNonDisponibiliToolStripMenuItem})
        Me.StrumentiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Strumenti
        Me.StrumentiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.StrumentiToolStripMenuItem.Name = "StrumentiToolStripMenuItem"
        Me.StrumentiToolStripMenuItem.Size = New System.Drawing.Size(97, 30)
        Me.StrumentiToolStripMenuItem.Text = "Strumenti"
        '
        'ImpostaGiacenzaToolStripMenuItem
        '
        Me.ImpostaGiacenzaToolStripMenuItem.Enabled = False
        Me.ImpostaGiacenzaToolStripMenuItem.Image = Global.Former.My.Resources.Resources.calendar2
        Me.ImpostaGiacenzaToolStripMenuItem.Name = "ImpostaGiacenzaToolStripMenuItem"
        Me.ImpostaGiacenzaToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ImpostaGiacenzaToolStripMenuItem.Text = "Imposta Giacenza"
        '
        'DettaglioToolStripMenuItem
        '
        Me.DettaglioToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Detail
        Me.DettaglioToolStripMenuItem.Name = "DettaglioToolStripMenuItem"
        Me.DettaglioToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.DettaglioToolStripMenuItem.Text = "Dettaglio"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(225, 6)
        '
        'MostraAncheNonDisponibiliToolStripMenuItem
        '
        Me.MostraAncheNonDisponibiliToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.MostraAncheNonDisponibiliToolStripMenuItem.CheckOnClick = True
        Me.MostraAncheNonDisponibiliToolStripMenuItem.Name = "MostraAncheNonDisponibiliToolStripMenuItem"
        Me.MostraAncheNonDisponibiliToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.MostraAncheNonDisponibiliToolStripMenuItem.Text = "Mostra anche non disponibili"
        '
        'AggiungiToolStripMenuItem
        '
        Me.AggiungiToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.AggiungiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.AggiungiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AggiungiToolStripMenuItem.Name = "AggiungiToolStripMenuItem"
        Me.AggiungiToolStripMenuItem.Size = New System.Drawing.Size(94, 30)
        Me.AggiungiToolStripMenuItem.Text = "Aggiungi"
        '
        'ucCommesseRisorse
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.SplitContainerRisorse)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ucCommesseRisorse"
        Me.Size = New System.Drawing.Size(390, 559)
        CType(Me.DgRisorseDisponibili, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgRisorseSelezionate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainerRisorse.Panel1.ResumeLayout(False)
        Me.SplitContainerRisorse.Panel1.PerformLayout()
        Me.SplitContainerRisorse.Panel2.ResumeLayout(False)
        Me.SplitContainerRisorse.Panel2.PerformLayout()
        CType(Me.SplitContainerRisorse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerRisorse.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgRisorseDisponibili As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DgRisorseSelezionate As System.Windows.Forms.DataGridView
    Friend WithEvents lnkDel As System.Windows.Forms.LinkLabel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblQtaScaric As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblQtaNeces As System.Windows.Forms.Label
    Friend WithEvents lblRisPredef As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainerRisorse As SplitContainer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents StrumentiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImpostaGiacenzaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents DettaglioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AggiungiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MostraAncheNonDisponibiliToolStripMenuItem As ToolStripMenuItem
End Class
