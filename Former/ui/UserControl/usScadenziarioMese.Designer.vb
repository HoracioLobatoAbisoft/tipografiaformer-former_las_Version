<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucScadenziarioSettimana
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucScadenziarioSettimana))
        Me.lblSettimana = New System.Windows.Forms.Label()
        Me.tvwScadenze = New System.Windows.Forms.TreeView()
        Me.imlScadenz = New System.Windows.Forms.ImageList(Me.components)
        Me.lblRiassunto = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblSettimana
        '
        Me.lblSettimana.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSettimana.BackColor = System.Drawing.Color.Silver
        Me.lblSettimana.ForeColor = System.Drawing.Color.Black
        Me.lblSettimana.Location = New System.Drawing.Point(0, 0)
        Me.lblSettimana.Name = "lblSettimana"
        Me.lblSettimana.Size = New System.Drawing.Size(300, 15)
        Me.lblSettimana.TabIndex = 0
        Me.lblSettimana.Text = "Settimana"
        Me.lblSettimana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tvwScadenze
        '
        Me.tvwScadenze.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwScadenze.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvwScadenze.ImageIndex = 0
        Me.tvwScadenze.ImageList = Me.imlScadenz
        Me.tvwScadenze.Location = New System.Drawing.Point(0, 16)
        Me.tvwScadenze.Name = "tvwScadenze"
        Me.tvwScadenze.SelectedImageIndex = 0
        Me.tvwScadenze.Size = New System.Drawing.Size(300, 420)
        Me.tvwScadenze.TabIndex = 1
        '
        'imlScadenz
        '
        Me.imlScadenz.ImageStream = CType(resources.GetObject("imlScadenz.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlScadenz.TransparentColor = System.Drawing.Color.Transparent
        Me.imlScadenz.Images.SetKeyName(0, "plus.png")
        Me.imlScadenz.Images.SetKeyName(1, "check_book.png")
        Me.imlScadenz.Images.SetKeyName(2, "bank_cards.png")
        Me.imlScadenz.Images.SetKeyName(3, "banknotes.png")
        '
        'lblRiassunto
        '
        Me.lblRiassunto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRiassunto.AutoEllipsis = True
        Me.lblRiassunto.BackColor = System.Drawing.Color.White
        Me.lblRiassunto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblRiassunto.Location = New System.Drawing.Point(0, 437)
        Me.lblRiassunto.Name = "lblRiassunto"
        Me.lblRiassunto.Size = New System.Drawing.Size(300, 15)
        Me.lblRiassunto.TabIndex = 2
        Me.lblRiassunto.Text = "-"
        Me.lblRiassunto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucScadenziarioSettimana
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lblRiassunto)
        Me.Controls.Add(Me.tvwScadenze)
        Me.Controls.Add(Me.lblSettimana)
        Me.Name = "ucScadenziarioSettimana"
        Me.Size = New System.Drawing.Size(300, 452)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSettimana As System.Windows.Forms.Label
    Friend WithEvents tvwScadenze As System.Windows.Forms.TreeView
    Friend WithEvents imlScadenz As System.Windows.Forms.ImageList
    Friend WithEvents lblRiassunto As System.Windows.Forms.Label

End Class
