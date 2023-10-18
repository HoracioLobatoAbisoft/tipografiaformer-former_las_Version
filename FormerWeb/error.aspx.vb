Imports FormerLib
Public Class _error
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Title = "Oppsss c'è stato un errore - Tipografiaformer.it"

        'qui devo vedere se la pagina viene chiamata da me ok  altrimenti non va bene e torno in home 

        If Request.UrlReferrer Is Nothing Then
            Response.Redirect("/")
        End If

    End Sub

End Class