Public Class richiestapreventivoOk
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("PageTitle") = "Richiesta di preventivo presa in carico"
    End Sub

End Class