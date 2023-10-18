Public Class frmSplashScreen

    Private Sub frmSplashScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'carico le variabili

        ApplicationTitle.Text = PostazioneCorrente.Titolo
        Version.Text = PostazioneCorrente.Versione

    End Sub
End Class