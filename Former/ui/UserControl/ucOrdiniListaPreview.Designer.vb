<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucOrdiniListaPreview
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
        Me.flowPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolTipBox = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'flowPanel
        '
        Me.flowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowPanel.Location = New System.Drawing.Point(0, 0)
        Me.flowPanel.Name = "flowPanel"
        Me.flowPanel.Size = New System.Drawing.Size(838, 100)
        Me.flowPanel.TabIndex = 3
        '
        'ToolTipBox
        '
        Me.ToolTipBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'ucOrdiniListaPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.flowPanel)
        Me.Name = "ucOrdiniListaPreview"
        Me.Size = New System.Drawing.Size(838, 100)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flowPanel As FlowLayoutPanel
    Friend WithEvents ToolTipBox As ToolTip
End Class
