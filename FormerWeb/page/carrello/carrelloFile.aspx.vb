Imports FormerDALWeb
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

Public Class pCarrelloFile
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If UtenteConnesso.UtenteAutorizato Then
            Dim UrlProdottoEnviroment As String = UtenteConnesso.UrlIframe & "/carrelloStp2"
            Dim Eviroment As Boolean = UtenteConnesso.Eviroment

            'If Eviroment Then
            '    UrlProdottoEnviroment = "https://react.tipografiaformertest.it:6060/#/carrelloStp2"
            'Else
            '    UrlProdottoEnviroment = "http://localhost:5173/#/carrelloStp2"
            'End If

            IframecarreloStp2.Text = "<iframe id='carrelloStp2' style='width:100%;height: 100vh;border: none;' src=" & UrlProdottoEnviroment & " ></iframe>"
        Else

            If Carrello.Ordini.Count = 0 Then Response.Redirect("/carrello")
        End If
    End Sub

End Class