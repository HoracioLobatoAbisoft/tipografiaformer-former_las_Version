Public Class ppEndOk
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim currentUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim uri As Uri = New Uri(currentUrl)
        Dim queryString As String = uri.Query
        Dim queryParameters As NameValueCollection = HttpUtility.ParseQueryString(queryString)
        Dim TokenPP As String = queryParameters("token")

        Dim Eviroment As Boolean = UtenteConnesso.Eviroment
        Dim UrlProdottoEnviroment As String = ""
        If Eviroment Then
            UrlProdottoEnviroment = "https://react.tipografiaformertest.it:6060/#/pagamento-confermato-paypal?tokenPP=" & TokenPP
        Else
            UrlProdottoEnviroment = "http://localhost:5173/#/pagamento-confermato-paypal?tokenPP=" & TokenPP
        End If

        IFramePayPalOk.Text = "<iframe id='IframePaypalOk' src=" & UrlProdottoEnviroment & " style='border:none; width:100%; height:250px'></iframe>"
    End Sub

End Class