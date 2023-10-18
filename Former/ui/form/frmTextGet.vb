Friend Class frmTextGet
    'Inherits baseFormInternaFixed

    Private _Ris As Integer = 0

    Friend Function Carica(ByVal Label As String,
                           ByRef TestoInserito As String) As String

        If Label.Length Then lblMessage.Text = Label

        txtBuffer.Text = String.Empty

        ShowDialog()

        If _Ris = 1 Then
            TestoInserito = txtBuffer.Text
        End If

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

    Private Sub btnConferma_Click(sender As Object, e As EventArgs) Handles btnConferma.Click

        If MessageBox.Show("Confermi il testo inserito?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            _Ris = 1
            Close()

        End If

    End Sub
End Class