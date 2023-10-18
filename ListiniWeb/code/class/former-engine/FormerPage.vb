Imports FormerDALWeb
Imports FormerLib
Imports System.IO

Public Class FormerPage
    Inherits System.Web.UI.Page

    Public UtenteConnesso As UtenteSito

    Public Sub New()

        MaintainScrollPositionOnPostBack = True

    End Sub

    Public Property SpecificKeywordBuffer As String = String.Empty
    Public Property SpecificTitleBuffer As String = String.Empty
    Public Property SpecificDescriptionBuffer As String = String.Empty


    'Protected Function IsFromUserControl()

    '    Dim ris As Boolean = False

    '    Dim stacktrace As New StackTrace(True)

    '    Try
    '        Dim stackFrame As StackFrame = stacktrace.GetFrame(3)
    '        Dim m As System.Reflection.MethodBase = stackFrame.GetMethod
    '        Dim nomeM As String = m.ReflectedType.FullName
    '        If nomeM.IndexOf(".Control") <> -1 Then ris = True

    '    Catch ex As Exception

    '    End Try

    '    Return ris

    'End Function

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Session("UtenteConnesso") Is Nothing Then
            If Not Request.Cookies(FormerWebApp.NomeCookieIdUtente) Is Nothing _
                AndAlso Request.Cookies(FormerWebApp.NomeCookieIdUtente).Value <> "0" _
                AndAlso Request.Url.AbsolutePath.IndexOf("manutenzione") = -1 Then
                UtenteConnesso = MgrUtenti.Login(FormerHelper.Security.Decrypt3DES(Request.Cookies(FormerWebApp.NomeCookieIdUtente).Value))

                If UtenteConnesso.IdUtente Then
                    MgrUtenti.Listini.RegistraAccesso(UtenteConnesso.IdUtente, FormerWebApp.PercDefaultRicarico)
                End If

            Else
                UtenteConnesso = New UtenteSito
            End If
            UtenteConnesso.UserAgent = Request.UserAgent.ToLower()
            If Not Request.Browser Is Nothing Then
                UtenteConnesso.BrowserInUso = Request.Browser.Browser
            End If
            Session("UtenteConnesso") = UtenteConnesso
        Else
            UtenteConnesso = Session("UtenteConnesso")
        End If

        'If Request.Url.AbsolutePath.EndsWith("/") = False Then
        UtenteConnesso.LastPageVisited = Request.Url.AbsolutePath
        UtenteConnesso.LastPageVisitedWhen = Now

        Try
            Dim ListaUtenti As Dictionary(Of String, UtenteSito)

            If Application("ListaUtenti") Is Nothing Then
                ListaUtenti = New Dictionary(Of String, UtenteSito)
                Application.Lock()
                Application("ListaUtenti") = ListaUtenti
                Application.UnLock()
            End If

            Application.Lock()

            DirectCast(Application("ListaUtenti"), Dictionary(Of String, UtenteSito))(UtenteConnesso.IpUtente) = UtenteConnesso

            Application.UnLock()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub TerminaSessioneLavoro()
        Try

            Dim H As New HttpCookie(FormerWebApp.NomeCookieIdUtente)
            H.Value = "0"
            H.Expires = Date.Now.AddHours(1)
            Response.Cookies.Add(H)

            Try
                If Not UtenteConnesso Is Nothing Then
                    Application.Lock()
                    DirectCast(Application("ListaUtenti"), Dictionary(Of String, UtenteSito)).Remove(UtenteConnesso.IpUtente)
                    Application.UnLock()
                End If
            Catch ex As Exception

            End Try

            Session("UtenteConnesso") = Nothing
            Session.Abandon()
            Response.Redirect("/")
        Catch ex As Exception

        End Try
    End Sub

    Public ReadOnly Property LastSecurePage As String
        Get
            Dim ris As String = String.Empty

            If Not Session("LastSecurePage") Is Nothing Then
                ris = Session("LastSecurePage")
            End If

            Return ris
        End Get
    End Property

End Class
