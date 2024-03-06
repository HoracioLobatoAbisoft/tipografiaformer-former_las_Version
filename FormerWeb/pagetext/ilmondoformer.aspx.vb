Public Class ilmondoformer
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Il Mondo Former"
        Session("PageTitle") = "Il Mondo Former"

    End Sub

End Class