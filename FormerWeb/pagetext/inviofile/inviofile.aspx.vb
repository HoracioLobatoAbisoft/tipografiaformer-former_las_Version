Public Class InvioFile
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Vuoi creare file perfetti?"
        Session("PageTitle") = "Come creare file perfetti"

    End Sub

End Class