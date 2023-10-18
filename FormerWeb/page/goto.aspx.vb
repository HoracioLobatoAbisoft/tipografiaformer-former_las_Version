Imports FormerDALWeb
Public Class _goto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim PaginaPrec As String = String.Empty

        If Not Request.UrlReferrer Is Nothing Then
            PaginaPrec = Request.UrlReferrer.ToString
            FormerWebApp.LogMe(PaginaPrec, "EXTERNAL-LINK")
        End If

        FormerWebApp.LogMe(Request.Url.ToString, "GO-TO")

        Dim TargetUrl As String = "/"

        Try
            Dim id As Integer = Convert.ToInt32(Page.RouteData.Values("id"))

            If id Then
                'qui riapro il goto , aggiorno il contatore e lo ridireziono
                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
                    Try
                        Dim s As New TraceSource
                        s.Read(id)
                        If s.IdTraceSource Then
                            tb.TransactionBegin()
                            s.Counter += 1
                            s.Save()
                            TargetUrl = s.TargetUrl
                            tb.TransactionCommit()
                        End If
                        s.Dispose()
                        s = Nothing
                    Catch ex As Exception
                        tb.TransactionRollBack()
                    End Try
                End Using

            End If

        Catch ex As Exception

        End Try

        Response.Redirect(TargetUrl)

    End Sub

End Class