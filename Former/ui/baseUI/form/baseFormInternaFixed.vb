Public Class baseFormInternaFixed
    Inherits BaseFormRad

    Public Sub New()
        MyBase.New
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.ControlBox = False
        Me.ShowIcon = True
    End Sub

    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'baseFormInternaFixed
        '
        Me.ClientSize = New System.Drawing.Size(300, 275)
        Me.Name = "baseFormInternaFixed"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

End Class
