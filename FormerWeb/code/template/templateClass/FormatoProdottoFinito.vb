Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class FormatoProdottoFinito
        Private _F As FormatoProdottoW

        Public Property F As FormatoProdottoW
            Get
                Return _F
            End Get
            Set(value As FormatoProdottoW)
                _F = value
            End Set
        End Property

        Public Property P As PreventivazioneW

        'Public Property IdPrev As Integer = 0

        'Public Property UrlPrecedente As String = String.Empty

    End Class

End Namespace