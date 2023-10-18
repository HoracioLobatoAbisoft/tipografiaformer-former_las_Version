Friend Class frmTextShow
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica(testo As String) As Integer

        txtBuffer.Text = testo

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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub txtBuffer_TextChanged(sender As Object, e As EventArgs) Handles txtBuffer.TextChanged

    End Sub

    Private Sub txtBuffer_DoubleClick(sender As Object, e As EventArgs) Handles txtBuffer.DoubleClick

        If txtBuffer.SelectionLength Then
            Clipboard.SetText(txtBuffer.SelectedText)
        End If

    End Sub
End Class