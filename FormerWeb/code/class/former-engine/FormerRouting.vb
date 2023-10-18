Public Class FormerRouting

    Public Shared Function GetLoginPage() As String
        Dim ris As String = "/login"

        If FormerConfig.FConfiguration.Environment.EnableMobile = True AndAlso
           HttpContext.Current.Request.Browser.IsMobileDevice = True Then
            ris = "m" & ris
        End If

        Return ris
    End Function

End Class
