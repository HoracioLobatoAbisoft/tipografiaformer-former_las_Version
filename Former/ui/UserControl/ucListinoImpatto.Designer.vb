<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListinoImpatto
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
        Me.UcAnteprima = New Former.ucAnteprima()
        Me.SuspendLayout()
        '
        'UcAnteprima
        '
        Me.UcAnteprima.BackColor = System.Drawing.Color.White
        Me.UcAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAnteprima.Location = New System.Drawing.Point(0, 0)
        Me.UcAnteprima.Name = "UcAnteprima"
        Me.UcAnteprima.Size = New System.Drawing.Size(936, 742)
        Me.UcAnteprima.TabIndex = 0
        '
        'ucListinoImpatto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.UcAnteprima)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucListinoImpatto"
        Me.Size = New System.Drawing.Size(936, 742)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcAnteprima As Former.ucAnteprima

End Class
