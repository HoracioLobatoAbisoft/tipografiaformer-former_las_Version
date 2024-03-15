Imports FormerDALWeb
Imports FormerLib
Imports System.IO
Imports System.Web.Compilation

Public Class FormerPage
    Inherits System.Web.UI.Page

    Public UtenteConnesso As UtenteSito
    Public Carrello As Carrello

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
        EnableViewStateMac = False

        If Session("UtenteConnesso") Is Nothing Then
            If Not Request.Cookies(FormerWebApp.NomeCookieIdUtente) Is Nothing _
                AndAlso Request.Cookies(FormerWebApp.NomeCookieIdUtente).Value <> "0" _
                AndAlso Request.Url.AbsolutePath.IndexOf("manutenzione") = -1 Then
                UtenteConnesso = MgrUtenti.Login(FormerHelper.Security.Decrypt3DES(Request.Cookies(FormerWebApp.NomeCookieIdUtente).Value))
            Else
                UtenteConnesso = New UtenteSito
            End If
            If Not Request.UserAgent Is Nothing Then
                UtenteConnesso.UserAgent = Request.UserAgent.ToLower()
            End If

            If Not Request.Browser Is Nothing Then
                UtenteConnesso.BrowserInUso = Request.Browser.Browser
            End If
            Session("UtenteConnesso") = UtenteConnesso
        Else
            UtenteConnesso = Session("UtenteConnesso")
        End If

        Dim CreaNuovoCarrello As Boolean = True

        If Not Session("Carrello") Is Nothing Then
            If Session("Carrello").IdUtenteConnesso = UtenteConnesso.IdUtente Then
                CreaNuovoCarrello = False
            End If
        End If

        If CreaNuovoCarrello Then
            Carrello = New Carrello
            Session("Carrello") = Carrello
            Carrello.IdUtenteConnesso = UtenteConnesso.IdUtente
            Carrello.IdMetodoPagamentoDefault = UtenteConnesso.DefaultTipoPagamento
            Carrello.IdIndirizzoScelto = UtenteConnesso.DefaultIdIndirizzoPredefinito
        Else
            Carrello = Session("Carrello")
        End If

        Title = FormerWebApp.MetaTitle

        'If Request.Url.AbsolutePath.EndsWith("/") = False Then
        UtenteConnesso.LastPageVisited = Request.Url.AbsolutePath
        UtenteConnesso.LastPageVisitedWhen = Now
        UtenteConnesso.TotNelCarrello = Carrello.TotaleNettoStr

        If Not IsPostBack Then
            FormerWebApp.LogMe(UtenteConnesso)
        End If
        'End If

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

        AbilitaTrace()
        AbilitaCaching()

    End Sub

    Private Sub AbilitaTrace()

        If Not UtenteConnesso Is Nothing AndAlso UtenteConnesso.IsBoss Then
            Trace.IsEnabled = FormerConfig.FConfiguration.Debug.TracciamentoAttivo
        End If

    End Sub

    Private Sub AbilitaCaching()

        If FormerConfig.FConfiguration.Debug.AbilitaCaching Then
            Response.Cache.SetCacheability(HttpCacheability.Public)
            Response.Cache.SetExpires(Cache.NoAbsoluteExpiration)

            'Response.Cache.SetExpires(DateTime.Now.AddSeconds(FormerConfig.FConfiguration.Debug.IntervalloCaching))
            'Response.Cache.SetCacheability(HttpCacheability.Server)
        Else
            Response.Cache.SetNoServerCaching()
        End If

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

    Private Sub FormerRouting()
        If FormerConfig.FConfiguration.Environment.EnableMobile Then
            Dim MobileRequest As Boolean = False
            If Me.MasterPageFile.ToLower.IndexOf(".m.") <> -1 Then
                MobileRequest = True
            End If

            Dim NewUrl As String = String.Empty

            Try
                If MobileRequest = True And Request.Browser.IsMobileDevice = False Then
                    Dim PosNextSlash As Integer = Request.Path.IndexOf("/", 1)
                    NewUrl = Request.Path.Substring(PosNextSlash) '"/"
                ElseIf MobileRequest = False And Request.Browser.IsMobileDevice = True Then

                    'qui devo vedere se la rotta mobile esiste
                    Dim OkSalto As Boolean = False
                    Dim SaltoPrevisto As String = "/m" & Request.Path

                    For Each entry In FormerWebApp.MobileRouteRegeX
                        'Dim RottaConfrontata As String = "/" & entry

                        Dim RegExpres As String = entry ' "^\/m\/[0-9]{1,6}\/[A-Za-z0-9\-]{1,100}"

                        'RegExpres = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        'RegExpres = "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"
                        'RegExpres = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.[A-Za-z][A-Za-z\.]*[A-Za-z]$"
                        'RegExpres = "^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[A-Za-z0-9]([\w\.-]*[A-Za-z0-9])?\.[A-Za-z][A-Za-z\.]*[A-Za-z]$"
                        'Dim r As New Regex(RegExpres)

                        If Regex.IsMatch(SaltoPrevisto, RegExpres, RegexOptions.IgnoreCase) Then
                            OkSalto = True
                            Exit For
                        End If

                    Next

                    If OkSalto Then
                        NewUrl = SaltoPrevisto
                    End If

                End If
            Catch ex As Exception

            End Try

            If NewUrl.Length Then
                Response.Redirect(NewUrl)
            End If
        End If
    End Sub

    Private Sub FormerPage_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit

        FormerRouting()

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