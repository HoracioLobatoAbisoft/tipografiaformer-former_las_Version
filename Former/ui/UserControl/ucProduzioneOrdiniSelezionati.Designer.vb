<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucProduzioneOrdiniSelezionati
    Inherits ucFormerUserControl


    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucProduzioneOrdiniSelezionati))
        Me.tvwOrdini = New System.Windows.Forms.TreeView()
        Me.imlOrd = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'tvwOrdini
        '
        Me.tvwOrdini.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwOrdini.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.tvwOrdini.ImageIndex = 0
        Me.tvwOrdini.ImageList = Me.imlOrd
        Me.tvwOrdini.Location = New System.Drawing.Point(0, 0)
        Me.tvwOrdini.Name = "tvwOrdini"
        Me.tvwOrdini.SelectedImageIndex = 0
        Me.tvwOrdini.Size = New System.Drawing.Size(259, 305)
        Me.tvwOrdini.TabIndex = 0
        '
        'imlOrd
        '
        Me.imlOrd.ImageStream = CType(resources.GetObject("imlOrd.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlOrd.TransparentColor = System.Drawing.Color.Transparent
        Me.imlOrd.Images.SetKeyName(0, "_FormatoProdotto.png")
        Me.imlOrd.Images.SetKeyName(1, "_CartaComposta.png")
        Me.imlOrd.Images.SetKeyName(2, "_Attenzione.png")
        '
        'ucProduzioneOrdiniSelezionati
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Controls.Add(Me.tvwOrdini)
        Me.Name = "ucProduzioneOrdiniSelezionati"
        Me.Size = New System.Drawing.Size(259, 305)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tvwOrdini As TreeView
    Friend WithEvents imlOrd As ImageList
End Class
