Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class FormatoProdottoWizard
        Private _F As FormatoProdottoW

        Public Property F As FormatoProdottoW
            Get
                Return _F
            End Get
            Set(value As FormatoProdottoW)
                _F = value
            End Set
        End Property

        Public Property IdPrev As Integer = 0

        Public Property UrlPrecedente As String = String.Empty

        Public Property IsConsigliato As Boolean = False

    End Class

End Namespace