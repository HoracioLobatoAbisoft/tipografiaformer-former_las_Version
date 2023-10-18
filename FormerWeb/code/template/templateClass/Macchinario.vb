Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class Macchinario
        Private _M As MacchinarioW

        Public Property M As MacchinarioW
            Get
                Return _M
            End Get
            Set(value As MacchinarioW)
                _M = value
            End Set
        End Property
    End Class

End Namespace