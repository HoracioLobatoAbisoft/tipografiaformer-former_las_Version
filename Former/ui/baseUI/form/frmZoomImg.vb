Public Class frmZoomImg

    'Public formSopra As cFormSopra = Nothing

    Private _Ris As Integer

    Public Function Carica(pct As Image,
                           Label As String) As Integer

        pctZoom.Image = pct
        If Label Is Nothing Then Label = String.Empty
        If Label.Length Then ToolTipMsg.SetToolTip(pctZoom, Label)

        If pct.Width > 128 Or pct.Height > 128 Then

            Dim NewHeight As Integer = pct.Height + 82
            Dim NewWidth As Integer = pct.Width + 14

            If NewHeight > Screen.PrimaryScreen.WorkingArea.Height Then NewHeight = Screen.PrimaryScreen.WorkingArea.Height
            If NewWidth > Screen.PrimaryScreen.WorkingArea.Width Then NewWidth = Screen.PrimaryScreen.WorkingArea.Width

            Height = NewHeight
            Width = NewWidth
        Else
            'qui nessuno dei due e' piu grande di 128 percio stretcho l'immagine
            pctZoom.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub btnChiudi_Click(sender As Object, e As EventArgs) Handles btnChiudi.Click
        Close()
    End Sub
End Class