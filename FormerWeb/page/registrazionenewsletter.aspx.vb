Public Class RegistrazioneNewsletterOk
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("PageTitle") = "Registrazione Newsletter Effettuata"
    End Sub

End Class