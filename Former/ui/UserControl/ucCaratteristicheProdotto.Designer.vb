<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCaratteristicheProdotto
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
        Me.ToolTipBox = New System.Windows.Forms.ToolTip(Me.components)
        Me.flowPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'ToolTipBox
        '
        Me.ToolTipBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'flowPanel
        '
        Me.flowPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowPanel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flowPanel.Location = New System.Drawing.Point(0, 0)
        Me.flowPanel.Name = "flowPanel"
        Me.flowPanel.Size = New System.Drawing.Size(713, 70)
        Me.flowPanel.TabIndex = 2
        '
        'ucCaratteristicheProdotto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.Controls.Add(Me.flowPanel)
        Me.Name = "ucCaratteristicheProdotto"
        Me.Size = New System.Drawing.Size(713, 70)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTipBox As System.Windows.Forms.ToolTip
    Friend WithEvents flowPanel As System.Windows.Forms.FlowLayoutPanel

End Class
