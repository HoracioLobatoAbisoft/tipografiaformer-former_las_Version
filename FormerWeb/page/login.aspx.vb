Imports FormerDALWeb
Imports FormerLib
Public Class login
    Inherits FormerFreePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Not Request.Cookies(FormerWebApp.NomeCookieIdUtente) Is Nothing Then
                txtLogin.Text = FormerHelper.Security.Decrypt3DES(Request.Cookies(FormerWebApp.NomeCookieIdUtente).Value)
            End If
        End If

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLoginImg.Click

        Try
            If IsValid Then
                lblEsito.Visible = False
                'qui devo vedere dove sto andando, se non sto andando da nessuna parte, rivado dove ero. Se ero nel login rivado in home page

                Dim NextUrl As String = UtenteConnesso.PreviousPageVisited

                If LastSecurePage.Length Then
                    NextUrl = LastSecurePage
                End If

                Dim UtenteLoggato As UtenteSito = MgrUtenti.Login(txtLogin.Text, txtPwd.Text)

                If UtenteLoggato.IdUtente Then
                    'Session.Abandon()
                    Session("UtenteConnesso") = UtenteLoggato

                    If NextUrl.Length = 0 Or NextUrl.EndsWith("/login") Then
                        NextUrl = "/"
                    End If

                    Dim HId As New HttpCookie(FormerWebApp.NomeCookieLogin)
                    HId.Value = FormerHelper.Security.Crypt3DES(txtLogin.Text)
                    HId.Expires = Date.Now.AddMonths(3)
                    Response.Cookies.Add(HId)

                    'il cookie di autenticazione lo salvo solo se viene registrato nei nostri sistemi
                    If chkRestaConnesso.Checked Then
                        Dim H As New HttpCookie(FormerWebApp.NomeCookieIdUtente)
                        Dim ValoreCookie As String = FormerHelper.Security.Crypt3DES(UtenteLoggato.IdUtente)
                        H.Value = ValoreCookie
                        H.Expires = Date.Now.AddHours(FormerWebApp.OreDurataCookie)
                        Response.Cookies.Add(H)
                    End If

                    Response.Redirect(NextUrl)
                Else
                    lblEsito.Text = "Email/password non valida o accesso non abilitato"
                    lblEsito.Visible = True
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnRigenera_Click(sender As Object, e As EventArgs) Handles btnRigenera.Click

        'qui mi arriva una richiesta di rigenerazione. Creo una email con il link gia fatto se trovo l'email e lo preparo per la rigenerazione
        Dim emailRif As String = txtNewPwd.Text
        If emailRif.Trim.Length Then
            Using u As New UtentiDAO
                Dim l As List(Of Utente) = u.FindAll(New LUNA.LunaSearchParameter(LFM.Utente.Email, emailRif))
                If l.Count = 1 Then
                    'qui devo generare il link di rigenerazione password

                    Dim Pt As New My.Templates.MailRigeneraPwd
                    Pt.Email = emailRif
                    Dim Buffer As String = Pt.TransformText

                    Try
                        FormerHelper.Mail.InviaMail("Richiesta di rigenerazione Password", Buffer, emailRif)
                    Catch ex As Exception

                    End Try

                    lblEsitoPwd.Text = "ATTENZIONE! Ti è stata inviata una email all'indirizzo indicato con le istruzioni per rigenerare la tua password"
                Else
                    lblEsitoPwd.Text = "ATTENZIONE! Non risultano utenti registrati al nostro sito con la email indicata"
                End If
            End Using
        Else
            lblEsitoPwd.Text = "ATTENZIONE! Inserire una email valida"
        End If
    End Sub
End Class