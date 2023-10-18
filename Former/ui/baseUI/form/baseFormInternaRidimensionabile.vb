Imports System.Drawing
Imports System.Windows.Forms

Public Class baseFormInternaRidimensionabile
    ' Inherits frmBaseForm

    'Private MousePos As New System.Drawing.Point(0, 0)

    'Private Sub frmNeutra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    Dim x As Char = vbCr
    '    If e.KeyChar = x Then
    '        e.Handled = True
    '        SendKeys.Send(vbTab)
    '    End If
    'End Sub

    Private Sub pctMaximize_Click(sender As System.Object, e As System.EventArgs) Handles pctMaximize.Click

        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub pctMinimize_Click(sender As System.Object, e As System.EventArgs) Handles pctMinimize.Click

        WindowState = FormWindowState.Normal

    End Sub

    Private Sub pctMove_MouseDown(sender As Object, e As MouseEventArgs) Handles pctMove.MouseDown,
                                                                                pctMainBar.MouseDown

        If e.Button = MouseButtons.Left Then

            MousePos = e.Location

            'DoDragDrop(Me, DragDropEffects.Move)
        End If

    End Sub

    Private Sub pctMove_MouseUp(sender As Object, e As MouseEventArgs) Handles pctMove.MouseUp,
                                                                                pctMainBar.MouseUp

        If e.Button = MouseButtons.Left Then

            Dim temp As Point = New Point(Me.Location + (e.Location - MousePos))

            Me.Location = temp

            temp = Nothing

        End If

    End Sub

    Public Sub New()

        MyBase.New

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        'lblMove.Text = Me.Text

        'lblMove.Width = lblMove.Text.Length * 20

    End Sub

End Class