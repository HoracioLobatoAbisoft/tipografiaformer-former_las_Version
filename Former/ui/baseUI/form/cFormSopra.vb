Public Class cFormSopra
    Inherits Windows.Forms.Form

    Private OggettoPadre As Windows.Forms.Form

    Public Sub New(ByVal Oggetto As Windows.Forms.Form)
        Me.BackColor = System.Drawing.Color.Black
        'Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        'Me.Name = "cFormSopra"
        Me.Opacity = 0.2
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.Text = ""
        Me.CausesValidation = False
        Me.Icon = Nothing

        Me.ControlBox = False

        Me.MaximizeBox = False
        Me.MinimizeBox = False
        'Me.TopMost = True
        Me.ResumeLayout(False)
        OggettoPadre = Oggetto

        'If OggettoPadre.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
        Left = OggettoPadre.Left '+ 8 'OggettoPadre.ClientRectangle.X
        Top = OggettoPadre.Top + (OggettoPadre.Height - OggettoPadre.ClientRectangle.Height) - 4 '- 4 'ClientRectangle.Top ' OggettoPadre.Top + 3
        Width = OggettoPadre.ClientRectangle.Width + 8
        Height = OggettoPadre.ClientRectangle.Height+4
        'Else

        '    Left = OggettoPadre.ClientRectangle.Left '+ 8 'OggettoPadre.ClientRectangle.X
        '    Top = OggettoPadre.ClientRectangle.Top + (OggettoPadre.Height) '- 4 'ClientRectangle.Top ' OggettoPadre.Top + 3

        '    'Left = OggettoPadre.Left + 8 'OggettoPadre.ClientRectangle.X
        '    'Top = OggettoPadre.Top + (OggettoPadre.Height - OggettoPadre.ClientRectangle.Height) - 8 'ClientRectangle.Top ' OggettoPadre.Top + 3
        '    Width = OggettoPadre.ClientRectangle.Width
        '    Height = OggettoPadre.ClientRectangle.Height
        'End If

        'Me.Parent = OggettoPadre.Region

        'Me.WindowState = FormWindowState.Maximized

        'Width = OggettoPadre.ClientRectangle.Width
        'Height = OggettoPadre.ClientRectangle.Height

    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'cFormSopra
        '
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.BackColor = System.Drawing.Color.Black
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "cFormSopra"
        Me.Opacity = 0.5R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)

    End Sub

End Class