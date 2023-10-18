Imports FormerDALWeb

Public Class appIframe
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("PageTitle") = "AppIframe"
        'Session("loginIsTrue") = Session("UtenteConnesso")
        Dim currentUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        ' Analizar la URL en busca de parámetros
        Dim uri As Uri = New Uri(currentUrl)
        Dim queryString As String = uri.Query
        ' Crear una colección de parámetros
        Dim queryParameters As NameValueCollection = HttpUtility.ParseQueryString(queryString)
        ' Obtener el valor del parámetro "token"
        Dim TokenPP As String = queryParameters("token")
        Dim UtenteLoggato As UtenteSito = TryCast(Session("UtenteConnesso"), UtenteSito)
        Dim url As String = "http://localhost:5173/#/AreaPersonale/iTuoiOrdini/?id=" & UtenteLoggato.IdUtente & "&tokenPP=" & TokenPP
        'Dim url As String = "https://react.tipografiaformertest.it:6060/#/AreaPersonale/iTuoiOrdini/?id=" & UtenteLoggato.IdUtente & "&tokenPP=" & TokenPP
        'Dim url As String = "http://95.110.133.251:6061/#/AreaPersonale/iTuoiOrdini/?id=" & UtenteLoggato.IdUtente & "&tokenPP=" & TokenPP
        'Dim url As String = "http://localhost:5173/#/AreaPersonale/iTuoiOrdini/"

        iframeApp.Text = "<iframe src='" & url & "' width='100%' height='100%' style='border:none;overflow:hidden;box-sizing:border-box'/>"


        'Dim token As String = Session("TokenJwt")
        'If UtenteLoggato IsNot Nothing Then
        '    ' Hacer algo con el objeto UtenteLoggato
        '    If RowCount = 0 And Not String.IsNullOrEmpty(UtenteLoggato.Utente.Email) And Not String.IsNullOrEmpty(UtenteLoggato.Utente.PasswordHash) Then
        '        pnlAppIframe.Visible = True
        '        If Not String.IsNullOrEmpty(token) Then
        '            ' Generar la URL del iframe con el token
        '            'Dim url As String = "http://localhost:3000/?token=" & token
        '            Dim url As String = "http://95.110.133.251:6060/#/ordiniTabella?id=" & UtenteLoggato.IdUtente & "&token=" & token
        '            'Dim url As String = "http://localhost:4200/?token=" & token
        '            ' Asignar la URL al control iframeApp
        '            iframeApp.Text = "<iframe src='" & url & "' width='100%' height='100%' style='border:none;overflow:hidden;box-sizing:border-box'/>"
        '        Else
        '            ' No se encontró un token en la sesión
        '            iframeApp.Text = "<h1>Nessuna sessione attiva trovata</h1><h3>Accedete, per favore</h3>"
        '        End If
        '    Else
        '        pnlAppIframe.Visible = True
        '        iframeApp.Text = "<h1>Nessuna sessione attiva trovata</h1><h3>Accedete, per favore</h3>"
        '    End If
        'Else
        '    'El objeto UtenteLoggato no existe en la variable de sesión
        '    pnlAppIframe.Visible = True
        'End If
    End Sub

End Class