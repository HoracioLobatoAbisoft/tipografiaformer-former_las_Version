<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucBase
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
        Me.SuspendLayout()
        '
        'ucBase
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Name = "ucBase"
        Me.Size = New System.Drawing.Size(805, 540)
        Me.ResumeLayout(False)

    End Sub

End Class
