Public Class pDiventaRiv
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Diventa Rivenditore"
        Session("PageTitle") = "Diventa Rivenditore"

    End Sub

End Class