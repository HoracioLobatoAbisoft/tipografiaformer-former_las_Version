Imports FormerDALWeb

Public Class FormerMasterPage
    Inherits System.Web.UI.MasterPage

    Protected UtenteConnesso As UtenteSito

    Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Dim _antiXsrfTokenValue As String

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        ' Il codice seguente facilita la protezione da attacchi XSRF
        Dim requestCookie As HttpCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If ((Not requestCookie Is Nothing) AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue)) Then
            ' Utilizzare il token Anti-XSRF dal cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generare un nuovo token Anti-XSRF e salvarlo nel cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie As HttpCookie = New HttpCookie(AntiXsrfTokenKey) With {.HttpOnly = True, .Value = _antiXsrfTokenValue}
            If (FormsAuthentication.RequireSSL And Request.IsSecureConnection) Then
                responseCookie.Secure = True
            End If
            Response.Cookies.Set(responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Private Sub master_Page_PreLoad(sender As Object, e As System.EventArgs)
        If (Not IsPostBack) Then
            ' Impostare il token Anti-XSRF
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, String.Empty)
        Else
            ' Convalidare il token Anti-XSRF
            If (Not DirectCast(ViewState(AntiXsrfTokenKey), String) = _antiXsrfTokenValue _
                Or Not DirectCast(ViewState(AntiXsrfUserNameKey), String) = If(Context.User.Identity.Name, String.Empty)) Then
                Throw New InvalidOperationException("Convalida del token Anti-XSRF non riuscita.")
            End If
        End If
    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.EnableViewStateMac = False
        If Session("UtenteConnesso") Is Nothing Then
            UtenteConnesso = New UtenteSito
        Else
            UtenteConnesso = Session("UtenteConnesso")
        End If

        If (FormerWebApp.SitoInManutenzione Or FormerWebApp.PresenteFileDiBlocco) And Request.Url.ToString().EndsWith("/manutenzione") = False Then
            Response.Redirect("/manutenzione", True)
        End If


    End Sub

    'Private Sub CheckSitoChiuso()
    '    Dim TrovatoFileBlocco As Boolean = False

    '    Try
    '        Dim PathFileBlocco As String = AppDomain.CurrentDomain.BaseDirectory & "stop.listino"
    '        TrovatoFileBlocco = File.Exists(PathFileBlocco)

    '    Catch ex As Exception

    '    End Try

    '    Dim SitoInManutenzione As Boolean = False

    '    If FormerWebApp.SitoInManutenzione Then
    '        SitoInManutenzione = True
    '    ElseIf TrovatoFileBlocco Then
    '        SitoInManutenzione = True
    '    End If

    '    If SitoInManutenzione And Request.Url.ToString().EndsWith("/manutenzione") = False Then
    '        Response.Redirect("/manutenzione", True)
    '    End If

    'End Sub

End Class
