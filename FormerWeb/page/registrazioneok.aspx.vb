Public Class RegistrazioneOk
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("PageTitle") = "Registrazione Effettuata"
    End Sub

End Class