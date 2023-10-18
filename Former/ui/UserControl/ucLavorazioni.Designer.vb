<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLavorazioni
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
        Me.lnkSu = New System.Windows.Forms.LinkLabel()
        Me.lnkGiu = New System.Windows.Forms.LinkLabel()
        Me.DgLavorazioni = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGLavorazioniSel = New System.Windows.Forms.DataGridView()
        Me.lnkAggiungi = New System.Windows.Forms.LinkLabel()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.SplitContainerLavoraz = New System.Windows.Forms.SplitContainer()
        CType(Me.DgLavorazioni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGLavorazioniSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerLavoraz, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerLavoraz.Panel1.SuspendLayout()
        Me.SplitContainerLavoraz.Panel2.SuspendLayout()
        Me.SplitContainerLavoraz.SuspendLayout()
        Me.SuspendLayout()
        '
        'lnkSu
        '
        Me.lnkSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkSu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkSu.Image = Global.Former.My.Resources.Resources._Su
        Me.lnkSu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSu.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSu.Location = New System.Drawing.Point(359, 18)
        Me.lnkSu.Name = "lnkSu"
        Me.lnkSu.Size = New System.Drawing.Size(51, 37)
        Me.lnkSu.TabIndex = 54
        Me.lnkSu.TabStop = True
        Me.lnkSu.Text = "Su"
        Me.lnkSu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkGiu
        '
        Me.lnkGiu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkGiu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkGiu.Image = Global.Former.My.Resources.Resources._Giu
        Me.lnkGiu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkGiu.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkGiu.Location = New System.Drawing.Point(359, 55)
        Me.lnkGiu.Name = "lnkGiu"
        Me.lnkGiu.Size = New System.Drawing.Size(54, 37)
        Me.lnkGiu.TabIndex = 55
        Me.lnkGiu.TabStop = True
        Me.lnkGiu.Text = "Giù"
        Me.lnkGiu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgLavorazioni
        '
        Me.DgLavorazioni.AllowUserToAddRows = False
        Me.DgLavorazioni.AllowUserToDeleteRows = False
        Me.DgLavorazioni.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLavorazioni.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLavorazioni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgLavorazioni.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgLavorazioni.BackgroundColor = System.Drawing.Color.White
        Me.DgLavorazioni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLavorazioni.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavorazioni.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLavorazioni.ColumnHeadersHeight = 20
        Me.DgLavorazioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavorazioni.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgLavorazioni.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavorazioni.EnableHeadersVisualStyles = False
        Me.DgLavorazioni.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavorazioni.Location = New System.Drawing.Point(3, 18)
        Me.DgLavorazioni.MultiSelect = False
        Me.DgLavorazioni.Name = "DgLavorazioni"
        Me.DgLavorazioni.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavorazioni.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgLavorazioni.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgLavorazioni.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgLavorazioni.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavorazioni.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavorazioni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavorazioni.Size = New System.Drawing.Size(350, 192)
        Me.DgLavorazioni.TabIndex = 57
        Me.DgLavorazioni.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 15)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Lavorazioni Disponibili"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 15)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Lavorazioni Selezionate"
        '
        'DGLavorazioniSel
        '
        Me.DGLavorazioniSel.AllowUserToAddRows = False
        Me.DGLavorazioniSel.AllowUserToDeleteRows = False
        Me.DGLavorazioniSel.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DGLavorazioniSel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DGLavorazioniSel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGLavorazioniSel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGLavorazioniSel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGLavorazioniSel.BackgroundColor = System.Drawing.Color.White
        Me.DGLavorazioniSel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGLavorazioniSel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGLavorazioniSel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGLavorazioniSel.ColumnHeadersHeight = 20
        Me.DGLavorazioniSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGLavorazioniSel.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGLavorazioniSel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGLavorazioniSel.EnableHeadersVisualStyles = False
        Me.DGLavorazioniSel.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DGLavorazioniSel.Location = New System.Drawing.Point(3, 18)
        Me.DGLavorazioniSel.MultiSelect = False
        Me.DGLavorazioniSel.Name = "DGLavorazioniSel"
        Me.DGLavorazioniSel.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGLavorazioniSel.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGLavorazioniSel.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DGLavorazioniSel.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DGLavorazioniSel.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DGLavorazioniSel.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DGLavorazioniSel.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DGLavorazioniSel.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGLavorazioniSel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGLavorazioniSel.Size = New System.Drawing.Size(350, 283)
        Me.DGLavorazioniSel.TabIndex = 59
        Me.DGLavorazioniSel.TabStop = False
        '
        'lnkAggiungi
        '
        Me.lnkAggiungi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiungi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiungi.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAggiungi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiungi.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiungi.Location = New System.Drawing.Point(359, 18)
        Me.lnkAggiungi.Name = "lnkAggiungi"
        Me.lnkAggiungi.Size = New System.Drawing.Size(86, 37)
        Me.lnkAggiungi.TabIndex = 61
        Me.lnkAggiungi.TabStop = True
        Me.lnkAggiungi.Text = "Aggiungi"
        Me.lnkAggiungi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDel
        '
        Me.lnkDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._remove
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(359, 100)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Size = New System.Drawing.Size(80, 37)
        Me.lnkDel.TabIndex = 62
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Rimuovi"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SplitContainerLavoraz
        '
        Me.SplitContainerLavoraz.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainerLavoraz.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainerLavoraz.Location = New System.Drawing.Point(6, 3)
        Me.SplitContainerLavoraz.Name = "SplitContainerLavoraz"
        Me.SplitContainerLavoraz.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerLavoraz.Panel1
        '
        Me.SplitContainerLavoraz.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerLavoraz.Panel1.Controls.Add(Me.DgLavorazioni)
        Me.SplitContainerLavoraz.Panel1.Controls.Add(Me.lnkAggiungi)
        '
        'SplitContainerLavoraz.Panel2
        '
        Me.SplitContainerLavoraz.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainerLavoraz.Panel2.Controls.Add(Me.lnkDel)
        Me.SplitContainerLavoraz.Panel2.Controls.Add(Me.lnkSu)
        Me.SplitContainerLavoraz.Panel2.Controls.Add(Me.lnkGiu)
        Me.SplitContainerLavoraz.Panel2.Controls.Add(Me.DGLavorazioniSel)
        Me.SplitContainerLavoraz.Size = New System.Drawing.Size(448, 536)
        Me.SplitContainerLavoraz.SplitterDistance = 213
        Me.SplitContainerLavoraz.SplitterWidth = 10
        Me.SplitContainerLavoraz.TabIndex = 63
        '
        'ucLavorazioni
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.SplitContainerLavoraz)
        Me.Name = "ucLavorazioni"
        Me.Size = New System.Drawing.Size(457, 542)
        CType(Me.DgLavorazioni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGLavorazioniSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerLavoraz.Panel1.ResumeLayout(False)
        Me.SplitContainerLavoraz.Panel1.PerformLayout()
        Me.SplitContainerLavoraz.Panel2.ResumeLayout(False)
        Me.SplitContainerLavoraz.Panel2.PerformLayout()
        CType(Me.SplitContainerLavoraz, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerLavoraz.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lnkSu As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkGiu As System.Windows.Forms.LinkLabel
    Friend WithEvents DgLavorazioni As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGLavorazioniSel As System.Windows.Forms.DataGridView
    Friend WithEvents lnkAggiungi As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDel As System.Windows.Forms.LinkLabel
    Friend WithEvents SplitContainerLavoraz As SplitContainer

End Class
