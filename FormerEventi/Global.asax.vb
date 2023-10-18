Imports System.Web.SessionState
Imports System.Web.Routing
Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato all'avvio dell'applicazione
        RegisterRoutes(RouteTable.Routes)
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato all'avvio della sessione

        'FORZATURA CONNESSIONE ACCESS
        Dim pathDb As String = HttpContext.Current.Server.MapPath("/mdb-database/contacts.mdb")
        FormerDALEventi.LUNA.LunaContext.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDb & ";Persist Security Info=False;"

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato all'inizio di ogni richiesta
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato al tentativo di autenticare l'utilizzo
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato quando si verifica un errore
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
        routes.MapPageRoute("Iscrizione", "", "~/registrati.aspx")
        'routes.MapPageRoute("Viscom2016", "Viscom-2016", "~/registrati.aspx")
        routes.MapPageRoute("Grazie", "grazie", "~/grazie.aspx")
        routes.MapPageRoute("errore", "opsss", "~/error.aspx")

    End Sub

End Class