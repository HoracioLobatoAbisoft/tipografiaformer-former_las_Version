Imports System.IO
Imports System.Threading
Imports FormerListiniLib
Imports FormerDALWeb

Public Class AreaRiservata
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If UtenteConnesso.IsBoss Then
            Response.Redirect("webmaster")
        Else
            Response.Redirect("genera-listino")
        End If

    End Sub
End Class