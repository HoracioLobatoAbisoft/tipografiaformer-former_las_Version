<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAnteprimaLavoro
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
        Me.pct = New System.Windows.Forms.PictureBox()
        Me.lblRiga3 = New System.Windows.Forms.Label()
        Me.lblRiga1 = New System.Windows.Forms.Label()
        Me.tmrClose = New System.Windows.Forms.Timer(Me.components)
        Me.lblRiga2 = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.lblNoteTit = New System.Windows.Forms.Label()
        Me.lnkTit = New System.Windows.Forms.LinkLabel()
        Me.pctClose = New System.Windows.Forms.PictureBox()
        CType(Me.pct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pct
        '
        Me.pct.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pct.Location = New System.Drawing.Point(3, 18)
        Me.pct.Name = "pct"
        Me.pct.Size = New System.Drawing.Size(280, 206)
        Me.pct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pct.TabIndex = 0
        Me.pct.TabStop = False
        '
        'lblRiga3
        '
        Me.lblRiga3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRiga3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblRiga3.Location = New System.Drawing.Point(0, 266)
        Me.lblRiga3.Name = "lblRiga3"
        Me.lblRiga3.Size = New System.Drawing.Size(283, 15)
        Me.lblRiga3.TabIndex = 2
        Me.lblRiga3.Text = "-"
        Me.lblRiga3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRiga1
        '
        Me.lblRiga1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRiga1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblRiga1.Location = New System.Drawing.Point(0, 227)
        Me.lblRiga1.Name = "lblRiga1"
        Me.lblRiga1.Size = New System.Drawing.Size(283, 15)
        Me.lblRiga1.TabIndex = 3
        Me.lblRiga1.Text = "-"
        Me.lblRiga1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrClose
        '
        Me.tmrClose.Interval = 5000
        '
        'lblRiga2
        '
        Me.lblRiga2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRiga2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblRiga2.Location = New System.Drawing.Point(0, 246)
        Me.lblRiga2.Name = "lblRiga2"
        Me.lblRiga2.Size = New System.Drawing.Size(283, 15)
        Me.lblRiga2.TabIndex = 2
        Me.lblRiga2.Text = "-"
        Me.lblRiga2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNote
        '
        Me.lblNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNote.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblNote.Location = New System.Drawing.Point(0, 296)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(283, 48)
        Me.lblNote.TabIndex = 4
        Me.lblNote.Text = "-"
        '
        'lblNoteTit
        '
        Me.lblNoteTit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoteTit.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblNoteTit.Location = New System.Drawing.Point(0, 281)
        Me.lblNoteTit.Name = "lblNoteTit"
        Me.lblNoteTit.Size = New System.Drawing.Size(283, 15)
        Me.lblNoteTit.TabIndex = 5
        Me.lblNoteTit.Text = "Note"
        Me.lblNoteTit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkTit
        '
        Me.lnkTit.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkTit.Location = New System.Drawing.Point(3, -1)
        Me.lnkTit.Name = "lnkTit"
        Me.lnkTit.Size = New System.Drawing.Size(265, 16)
        Me.lnkTit.TabIndex = 6
        Me.lnkTit.TabStop = True
        Me.lnkTit.Text = "-"
        Me.lnkTit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctClose
        '
        Me.pctClose.Image = Global.Former.My.Resources._Annulla
        Me.pctClose.Location = New System.Drawing.Point(268, 1)
        Me.pctClose.Name = "pctClose"
        Me.pctClose.Size = New System.Drawing.Size(16, 16)
        Me.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctClose.TabIndex = 7
        Me.pctClose.TabStop = False
        '
        'ucCTRAnteprimaLavoro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.pctClose)
        Me.Controls.Add(Me.lnkTit)
        Me.Controls.Add(Me.lblNoteTit)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.lblRiga1)
        Me.Controls.Add(Me.lblRiga2)
        Me.Controls.Add(Me.lblRiga3)
        Me.Controls.Add(Me.pct)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Name = "ucCTRAnteprimaLavoro"
        Me.Size = New System.Drawing.Size(286, 344)
        CType(Me.pct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pct As System.Windows.Forms.PictureBox
    Friend WithEvents lblRiga3 As System.Windows.Forms.Label
    Friend WithEvents lblRiga1 As System.Windows.Forms.Label
    Friend WithEvents tmrClose As System.Windows.Forms.Timer
    Friend WithEvents lblRiga2 As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblNoteTit As System.Windows.Forms.Label
    Friend WithEvents lnkTit As System.Windows.Forms.LinkLabel
    Friend WithEvents pctClose As System.Windows.Forms.PictureBox

End Class
