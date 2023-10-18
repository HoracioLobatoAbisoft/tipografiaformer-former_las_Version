Public Class baseFormInternaRedim
    Inherits BaseFormRad

    Public Sub New()
        MyBase.New
    End Sub

    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'baseFormInternaRedim
        '
        Me.ClientSize = New System.Drawing.Size(300, 275)
        Me.Name = "baseFormInternaRedim"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
