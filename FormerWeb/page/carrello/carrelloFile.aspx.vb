Imports FormerDALWeb
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

Public Class pCarrelloFile
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Carrello.Ordini.Count = 0 Then Response.Redirect("/carrello")

    End Sub

End Class