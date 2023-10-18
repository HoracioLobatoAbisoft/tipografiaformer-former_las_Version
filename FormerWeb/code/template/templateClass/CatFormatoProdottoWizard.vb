Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class CatFormatoProdottoWizard
        Private _C As CatFormatoProdottoW

        Public Property C As CatFormatoProdottoW
            Get
                Return _C
            End Get
            Set(value As CatFormatoProdottoW)
                _C = value
            End Set
        End Property

        Public Property IdPrev As Integer = 0
        Public Property IdCat As Integer = 0

        Public Property UrlPrecedente As String = String.Empty

    End Class

End Namespace