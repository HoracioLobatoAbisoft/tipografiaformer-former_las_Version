Friend Class frmMonitor

    Private _Ris As Integer

    Friend Function Carica() As Integer

        UcAllegati.Carica(,,, True)

        Show()

        'Return _Ris

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

    Private Sub lnkAggiorna_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked

        Close()

    End Sub

    Private Sub frmMonitor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub tmrMess_Tick(sender As System.Object, e As System.EventArgs) Handles tmrMess.Tick
        UcAllegati.Carica(,,, True)
    End Sub

    Private Sub lnkCaricaLastYear_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCaricaLastYear.LinkClicked
        UcAllegati.Carica(,,, True)
    End Sub

    Private Sub lnkCaricaTutto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCaricaTutto.LinkClicked
        UcAllegati.Carica()
    End Sub
End Class