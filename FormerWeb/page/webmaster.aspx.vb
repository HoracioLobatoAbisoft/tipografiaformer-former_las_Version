Imports FormerDALWeb
Public Class pWebMaster
    Inherits FormerSecurePage
    Protected ReadOnly Property IsAdmin As Boolean
        Get
            Dim ris As Boolean = False

            If UtenteConnesso.IsAdmin Then
                ris = True
            End If

            Return ris
        End Get
    End Property

    Private Sub myFormer_Load(sender As Object, e As EventArgs) Handles Me.Load

        If UtenteConnesso.IsAdmin = False Then
            Response.Redirect("/")
        End If

    End Sub

End Class