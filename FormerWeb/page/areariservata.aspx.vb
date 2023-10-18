Public Class pAreariservata
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If UtenteConnesso.IsBoss Then
            Response.Redirect("webmaster")
        Else
            Response.Redirect("i-tuoi-lavori")
        End If

    End Sub

End Class