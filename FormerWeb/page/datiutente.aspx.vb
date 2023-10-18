Imports FormerDALWeb
Imports FormerLib
Public Class pDatiUtente
    Inherits FormerSecurePage

    Private Sub myFormer_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If UtenteConnesso.Utente.IdRubricaInt Then
                lblIdCli.Text = UtenteConnesso.Utente.IdRubricaInt
            Else
                lblIdCli.Text = "-"
            End If

            lblEmail.Text = Server.HtmlEncode(UtenteConnesso.Utente.Email)
            lblRagSoc.Text = Server.HtmlEncode(UtenteConnesso.Utente.RagSoc)
            lblNominativo.Text = Server.HtmlEncode(UtenteConnesso.Utente.Nome & " " & UtenteConnesso.Utente.Cognome)
            lblInd.Text = Server.HtmlEncode(UtenteConnesso.Utente.Indirizzo & ", " & UtenteConnesso.Utente.Citta & " (" & UtenteConnesso.Utente.Provincia & ") - " & UtenteConnesso.Utente.Cap)
            lblPiva.Text = Server.HtmlEncode(UtenteConnesso.Utente.Piva)
            lblCodFisc.Text = Server.HtmlEncode(UtenteConnesso.Utente.CodFisc)
            lblRecap.Text = Server.HtmlEncode("tel. " & UtenteConnesso.Utente.Tel & " fax " & UtenteConnesso.Utente.Fax & " cel. " & UtenteConnesso.Utente.Cellulare)
            lblPec.Text = Server.HtmlEncode(UtenteConnesso.Utente.Pec)
            lblSDI.Text = Server.HtmlEncode(UtenteConnesso.Utente.CodiceSDI)

        End If

    End Sub

    Private Sub CambiaPwd()
        Dim Ris As String = ""

        If txtPwd.Text.Trim.Length = 0 Then
            Ris = "Inserire la nuova password"
        ElseIf txtPwdRip.Text.Trim.Length = 0 Then
            Ris = "Riscrivere la nuova password"
        ElseIf txtPwd.Text.Trim.Length < 8 Or txtPwdRip.Text.Trim.Length < 8 Then
            Ris = "Le Password devono essere di almeno 8 caratteri"
        ElseIf txtPwd.Text.Trim <> txtPwdRip.Text.Trim Then
            Ris = "Le Password inserite sono diverse"
        Else
            'qui cambio la password calcolando l'hash md5 
            Dim NewPwd As String = FormerHelper.Security.GetMd5Hash(txtPwd.Text)
            UtenteConnesso.Utente.PasswordHash = NewPwd
            UtenteConnesso.Utente.Save()
            Ris = "Nuova Password salvata correttamente!"
        End If
        lblEsitoPwd.Text = Ris
        lblEsitoPwd.Visible = True
    End Sub

    Private Sub lnkShutdown_Click(sender As Object, e As EventArgs) Handles lnkShutdown.Click
        Try

            TerminaSessioneLavoro()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnkModPwd_Click(sender As Object, e As EventArgs) Handles lnkModPwd.Click
        CambiaPwd()
    End Sub
End Class