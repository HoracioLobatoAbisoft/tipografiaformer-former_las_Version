Imports System.Web.Routing
Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato all'avvio dell'applicazione
        RegisterRoutes(RouteTable.Routes)
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato all'avvio della sessione
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato all'inizio di ogni richiesta
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato al tentativo di autenticare l'utilizzo
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato quando si verifica un errore

        'Stop
        Response.Redirect("/opsss")

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato al termine della sessione
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato al termine dell'applicazione
    End Sub

    Shared Sub RegisterRoutes(routes As RouteCollection)

        routes.Ignore("{*allaspx}", New With {Key .allaspx = ".*\.aspx(/.*)?"})

        'GENERICS
        routes.MapPageRoute("Default", "", "~/default.aspx")
        routes.MapPageRoute("accedi", "login", "~/page/login.aspx")
        routes.MapPageRoute("area-riservata", "area-riservata", "~/page/areariservata.aspx")
        routes.MapPageRoute("errore", "opsss", "~/page/error.aspx")
        routes.MapPageRoute("imposta-parametri", "imposta-parametri", "~/page/parametri.aspx")
        routes.MapPageRoute("solo-rivenditori", "solo-rivenditori", "~/page/soloRivenditori.aspx")
        routes.MapPageRoute("manutenzione", "manutenzione", "~/page/manutenzione.aspx")
        routes.MapPageRoute("webmaster", "webmaster", "~/page/admin.aspx")
        routes.MapPageRoute("genera-listino", "genera-listino", "~/page/generalistino.aspx")

    End Sub

End Class