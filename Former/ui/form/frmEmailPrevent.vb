Imports System.IO
Imports FormerDALSql
Friend Class frmEmailPrev
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Dim _IdPrev As Integer = 0
    Dim _Anteprima As String = ""

    Friend Function Carica(ByVal IdPrev As Integer) As Integer
        _IdPrev = IdPrev

        'qui carico dall'ordine la mail del destinatario 
        Dim Prev As New Preventivo
        Prev.Read(IdPrev)

        txtOrdine.Text = Prev.Numero
        Dim IdRub As Integer = Prev.IdRub
        _Anteprima = Prev.Anteprima

        Dim Riepilogo As String = Prev.CreaRiepilogoMail

        Dim Email As String = ""
        If Prev.EmailRif.Length Then
            Email = Prev.EmailRif
        Else
            Dim Rub As New VoceRubrica
            Rub.Read(IdRub)
            Email = Rub.Email
            Rub = Nothing
        End If
        Prev = Nothing

        txtEmail.Text = Email
        txtTestoMail.Text = Riepilogo
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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If txtEmail.Text.Length = 0 Then
            MessageBox.Show("Il cliente selezionato non ha una mail inserita nel suo profilo, inserire manualmente un indirizzo email per continuare!", "Invio mail automatica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'If cmbTipoProd.Text.Length = 0 Then
        '    MessageBox.Show("Non è stato selezionato nessun modello di email da inviare!", "Invio mail automatica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        If MessageBox.Show("Confermi l'invio della mail al cliente proprietario del preventivo?", "Invio mail automatica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim BodyMail As String = txtTestoMail.Text

            'Dim sw As New StreamReader(Postazione.PathTemplate & cmbTipoProd.Text, System.Text.Encoding.ASCII)

            'BodyMail = sw.ReadToEnd()

            'sw.Close()
            'sw = Nothing
            btnOk.Enabled = False
            'SendMail(txtEmail.Text, "Riferimento preventivo numero " & txtOrdine.Text, BodyMail, _Anteprima, False)

            Using x As New PreventiviDAO
                x.SalvaRisposta(_IdPrev, 1, txtTestoMail.Text)
            End Using
            MessageBox.Show("Email inviata", "Invio automatico", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        End If
    End Sub
End Class