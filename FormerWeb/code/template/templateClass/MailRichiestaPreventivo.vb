Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class MailRichiestaPreventivo
        Private _R As RichiestaPreventivo

        Public Property R As RichiestaPreventivo
            Get
                Return _R
            End Get
            Set(value As RichiestaPreventivo)
                _R = value
            End Set
        End Property
    End Class

End Namespace