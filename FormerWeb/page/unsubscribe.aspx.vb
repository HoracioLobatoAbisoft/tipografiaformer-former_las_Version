Imports FormerLib
Imports FormerDALWeb

Public Class pUnsubscribe
    Inherits FormerFreePage
    Private _EmailRif As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("PageTitle") = "Registrazione Effettuata"
        Dim emailCrypt As String = Convert.ToString(Page.RouteData.Values("email"))

        If emailCrypt.Length Then
            Dim email As String = FormerHelper.Security.DecriptaURL(emailCrypt)
            _EmailRif = email

            If _EmailRif.Length = 0 Then
                Response.Redirect("/")
            End If

        End If

    End Sub

    'qui controllo che la richiesta non sia stata gia registrata

    Public ReadOnly Property EmailRif As String
        Get
            Return _EmailRif
        End Get
    End Property

    Private Sub btnCancellati_Click(sender As Object, e As ImageClickEventArgs) Handles btnCancellati.Click

        Dim redirectUrl As String = "/"
        If _EmailRif.Length Then


            Using mgr As New UnsubscribeDAO
                Dim richiesta As Unsubscribe = mgr.Find(New LUNA.LunaSearchParameter(LFM.Unsubscribe.Email, _EmailRif))
                If richiesta Is Nothing Then
                    richiesta = New Unsubscribe
                    richiesta.Ip = UtenteConnesso.IpUtente
                    richiesta.Quando = Now
                    richiesta.Email = _EmailRif
                    richiesta.Save()
                    redirectUrl = "/unsubscribe-registrato"
                End If
            End Using
        End If
        Response.Redirect(redirectUrl)

    End Sub

End Class