Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class ColoreStampaWizard
        Private _CS As ColoreStampaW

        Public Property CS As ColoreStampaW
            Get
                Return _CS
            End Get
            Set(value As ColoreStampaW)
                _CS = value
            End Set
        End Property

        Public Property IdPrev As Integer = 0

        Public Property IdFormatoProdotto As Integer = 0

        Public Property IdTipoCarta As Integer = 0

        Public Property UrlPrecedente As String = String.Empty

        Public Property IsConsigliato As Boolean = False

    End Class

End Namespace