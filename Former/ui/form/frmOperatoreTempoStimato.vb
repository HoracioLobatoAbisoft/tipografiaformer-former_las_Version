Friend Class frmOperatoreTempoStimato
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtTempoStimato.Value > 0 Then
            If MessageBox.Show("Confermi il tempo stimato di " & txtTempoStimato.Text & " minuti?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                _Ris = txtTempoStimato.Text
                Close()
            End If
        Else
            MessageBox.Show("Inserire un valore maggiore di 0")
        End If

    End Sub

    Private Sub lnkTempo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTempo.LinkClicked,
            lnkTempo2.LinkClicked,
            lnkTempo3.LinkClicked,
            lnkTempo4.LinkClicked,
            lnkTempo5.LinkClicked,
            lnkTempo6.LinkClicked,
            lnkTempo7.LinkClicked,
            lnkTempo8.LinkClicked,
            lnkTempo9.LinkClicked,
            lnkTempo10.LinkClicked

        txtTempoStimato.Text = sender.text
    End Sub
End Class