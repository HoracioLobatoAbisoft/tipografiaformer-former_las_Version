Imports FormerDALWeb

Public Class manutenzione
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If FormerWebApp.SitoInManutenzione = False And FormerWebApp.PresenteFileDiBlocco = False Then

                'qui devo controllare se il db è raggiungibile 

                If LUNA.LunaContext.IsOkDbConnection Then
                    Response.Redirect("/")
                End If


            End If

        Catch ex As Exception

        End Try


    End Sub

End Class