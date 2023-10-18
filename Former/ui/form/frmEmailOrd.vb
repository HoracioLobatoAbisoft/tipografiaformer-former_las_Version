Imports System.IO
Imports FormerDALSql
Imports FormerLib
Imports FormerConfig

Friend Class frmEmailOrd
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Dim _IdOrd As Integer = 0
    Dim _Anteprima As String = ""

    Friend Function Carica(ByVal IdOrd As Integer) As Integer
        _IdOrd = IdOrd
        txtOrdine.Text = IdOrd
        'qui carico dall'ordine la mail del destinatario 
        Dim Ord As New Ordine
        Ord.Read(IdOrd)
        Dim IdRub As Integer = Ord.IdRub
        _Anteprima = Ord.FilePath
        Ord = Nothing
        Dim Rub As New VoceRubrica
        Rub.Read(IdRub)
        Dim Email As String = Rub.Email
        Rub = Nothing
        txtEmail.Text = Email

        'carico la combo dei tipi di email
        Dim filetemp As FileInfo
        Dim dirtemp As New DirectoryInfo(FormerPath.PathTemplateMarketing)

        For Each filetemp In dirtemp.GetFiles

            cmbTipoProd.Items.Add(filetemp.Name)

        Next

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
        If cmbTipoProd.Text.Length = 0 Then
            MessageBox.Show("Non è stato selezionato nessun modello di email da inviare!", "Invio mail automatica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MessageBox.Show("Confermi l'invio della mail al cliente proprietario dell'ordine?", "Invio mail automatica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim BodyMail As String = ""

            Dim sw As New StreamReader(FormerPath.PathTemplateMarketing & cmbTipoProd.Text, System.Text.Encoding.ASCII)

            BodyMail = sw.ReadToEnd()

            sw.Close()
            sw = Nothing

            'SendMail(txtEmail.Text, "Riferimento ordine numero " & _IdOrd, BodyMail, _Anteprima, True)
            FormerHelper.Mail.InviaMail("Riferimento ordine numero " & _IdOrd, BodyMail, txtEmail.Text, , , _Anteprima)
            MessageBox.Show("Email inviata", "Invio automatico", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        End If
    End Sub
End Class