Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class TipoCartaWizard
        Private _TC As TipoCartaW

        Public Property TC As TipoCartaW
            Get
                Return _TC
            End Get
            Set(value As TipoCartaW)
                _TC = value
            End Set
        End Property

        Public Property IdPrev As Integer = 0

        Public Property IdFormatoProdotto As Integer = 0

        Public Property UrlPrecedente As String = String.Empty

        Public Property IsConsigliato As Boolean = False

    End Class

End Namespace