
Imports FormerLib.FormerEnum

Public Class FormerCacheHandler
    Implements IHttpHandler

    Public ReadOnly Property IsReusable As Boolean Implements IHttpHandler.IsReusable
        Get
            'Throw New NotImplementedException()
            Return True
        End Get
    End Property

    Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest

        Dim Path As String = context.Request.FilePath
        Dim file As String = context.Server.MapPath(Path)
        If System.IO.File.Exists(file) Then
            Dim filename As String = FormerLib.FormerHelper.File.EstraiNomeFile(file)
            context.Response.Cache.SetCacheability(HttpCacheability.Public)
            If FormerWebApp.UseStaticCollection = enSiNo.Si Then
                context.Response.Cache.SetExpires(Now.AddDays(1)) 'Cache.NoAbsoluteExpiration) 'Now.AddMinutes(1)) 'Cache.NoAbsoluteExpiration)
            Else
                context.Response.Cache.SetExpires(Cache.NoAbsoluteExpiration) 'Now.AddMinutes(1)) 'Cache.NoAbsoluteExpiration)
            End If

            context.Response.AddHeader("content-disposition", "inline; filename=" + filename)
            context.Response.WriteFile(file)
            'Else

        End If


        'response.Cache.SetCacheability(HttpCacheability.Public)
        'response.Cache.SetExpires(Cache.NoAbsoluteExpiration)
        '  context.Response.Cache.SetExpires()
        '        (DateTime.Now.Add(config.CachingTimeSpan));
        'context.Response.Cache.SetCacheability(HttpCacheability.Public);
        'context.Response.Cache.SetValidUntilExpires(False)

        'String file = context.Server.MapPath
        '(context.Request.FilePath


        ''Throw New NotImplementedException()
        'Dim file As String = context.Server.MapPath(context.Request.FilePath.Replace(".ashx", ""))
        'Dim filename As String = file.Substring(file.LastIndexOf("\"c) + 1)
        'Dim extension As String = file.Substring(file.LastIndexOf("."c) + 1)
        'Dim config As CachingSection = CType(context.GetSection("SoftwareArchitects/Caching"), CachingSection)

        'If config IsNot Nothing Then
        '    context.Response.Cache.SetExpires(DateTime.Now.Add(config.CachingTimeSpan))
        '    context.Response.Cache.SetCacheability(HttpCacheability.[Public])
        '    context.Response.Cache.SetValidUntilExpires(False)
        '    Dim fileExtension As FileExtension = config.FileExtensions(extension)

        '    If fileExtension IsNot Nothing Then
        '        context.Response.ContentType = fileExtension.ContentType
        '    End If
        'End If

        'context.Response.AddHeader("content-disposition", "inline; filename=" & filename)
        'context.Response.WriteFile(file)

    End Sub
End Class
