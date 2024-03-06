Public Class mondoFormer1
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Stampa Tipografica Offset"
        Session("PageTitle") = "Stampa Tipografica Offset"

    End Sub

End Class