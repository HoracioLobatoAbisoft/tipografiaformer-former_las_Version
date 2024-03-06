Public Class ordineconfermato
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Ordine confermato"
        Session("PageTitle") = "Ordine Confermato"
    End Sub

End Class