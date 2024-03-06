Public Class mondoFormer3
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Stampa Digitale"
        Session("PageTitle") = "Stampa digitale grande formato"

    End Sub

End Class