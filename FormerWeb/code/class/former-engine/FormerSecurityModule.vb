Imports FormerDALWeb

Public Class FormerSecurityModule
    Implements IHttpModule

    Private Const AcceptEncodingHeader As String = "Accept-Encoding"
    Private Const ContentEncodingHeader As String = "Content-Encoding"
    Private Const GZipContentEncoding As String = "gzip"
    Private Const DeflateContentEncoding As String = "deflate"

    Public Sub New()
    End Sub

    Public Sub Init(context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.BeginRequest, AddressOf Application_BeginRequest
    End Sub

    Private Sub Application_BeginRequest(source As Object, e As EventArgs)
        Dim context As HttpContext = DirectCast(source, HttpApplication).Context
        Dim ipAddress As String = String.Empty 'context.Request.UserHostAddress
        ipAddress = context.Request.ServerVariables("REMOTE_ADDR")

        'context.Response.Write(ipAddress)

        If Not IsValidIpAddress(ipAddress) Then
            '   context.Response.Write("CHIUSA")
            context.Response.StatusCode = 403
            context.Response.SuppressContent = True
            context.Response.End()
            'Else
            '    Dim application As HttpApplication = CType(source, HttpApplication)
            '    'If TypeOf HttpContext.Current.Handler Is DefaultHttpHandler Then
            '    '    Return
            '    'End If

            '    Dim acceptEncoding As String = HttpContext.Current.Request.Headers(AcceptEncodingHeader).ToLowerInvariant()
            '    If Not String.IsNullOrEmpty(acceptEncoding) AndAlso acceptEncoding.Contains(GZipContentEncoding) Then

            '        context.Response.Filter = New GZipStream(context.Response.Filter, CompressionMode.Compress)
            '        context.Response.AppendHeader(ContentEncodingHeader, "gzip")
            '        context.Response.Cache.VaryByHeaders(AcceptEncodingHeader) = True

            '    End If
            'Else

            'Dim application As HttpApplication = CType(source, HttpApplication)
            'If Not TypeOf HttpContext.Current.Handler Is DefaultHttpHandler Then
            '    Dim acceptEncoding As String = HttpContext.Current.Request.Headers(AcceptEncodingHeader).ToLowerInvariant()
            '    If Not String.IsNullOrEmpty(acceptEncoding) AndAlso acceptEncoding.Contains(GZipContentEncoding) Then

            '        context.Response.Filter = New GZipStream(context.Response.Filter, CompressionMode.Compress)
            '        context.Response.AppendHeader(ContentEncodingHeader, "gzip")
            '        context.Response.Cache.VaryByHeaders(AcceptEncodingHeader) = True

            '    End If

            'End If

            'If context.Request.CurrentExecutionFilePathExtension.ToLower = ".jpg" Or
            '   context.Request.CurrentExecutionFilePathExtension.ToLower = ".png" Then
            '    HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddMonths(1))
            '    HttpContext.Current.Response.Cache.SetValidUntilExpires(True)
            '    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private)

            'End If
        End If
    End Sub

    Private Function IsValidIpAddress(ipAddress As String) As Boolean

        Dim ris As Boolean = True

        If FormerConfig.FConfiguration.Debug.CheckBanIp Then
            If LUNA.LunaContext.IsOkDbConnection Then
                Try
                    Using mgr As New IpBanDAO

                        Dim l As List(Of IpBan) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.IpBan.IpToBan, ipAddress))

                        If l.Count Then
                            ris = False
                        End If
                    End Using
                Catch ex As Exception

                End Try
            End If
        End If

        Return ris

    End Function

    Private Sub IHttpModule_Dispose() Implements IHttpModule.Dispose

        '    Throw New NotImplementedException()

    End Sub

End Class
