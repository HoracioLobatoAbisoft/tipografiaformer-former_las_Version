Imports FormerDALWeb
Public Class FormerUserControl
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property UtenteConnesso As UtenteSito
        Get
            Dim P As FormerPage = DirectCast(Me.Page, FormerPage)
            Return P.UtenteConnesso
        End Get
    End Property

    Public ReadOnly Property Carrello As Carrello
        Get
            Dim F As FormerPage = DirectCast(Page, FormerPage)

            Return F.Carrello
        End Get
    End Property

    Protected Overrides Sub OnLoad(e As EventArgs)
        CaricamentoUserControl()
        MyBase.OnLoad(e)
    End Sub

    Private Sub CaricamentoUserControl()

    End Sub

End Class

