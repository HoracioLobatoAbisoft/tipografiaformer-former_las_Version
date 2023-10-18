Public Class frmReleaseNote

    Private Ris As String = String.Empty

    Public Function Carica() As String

        ShowDialog()

        Return Ris

    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub btnConferma_Click(sender As Object, e As EventArgs) Handles btnConferma.Click

        If MessageBox.Show("Confermi le release note?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Ris = txtBuffer.Text
            Close()

        End If

    End Sub
End Class