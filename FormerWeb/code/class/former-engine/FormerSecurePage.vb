Public Class FormerSecurePage
    Inherits FormerPage
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Session("LastSecurePage") = Request.Url.ToString
        If UtenteConnesso.IdUtente = 0 Then
            Response.Redirect(FormerRouting.GetLoginPage)
        End If

    End Sub

End Class
