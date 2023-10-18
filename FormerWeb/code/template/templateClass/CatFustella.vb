Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class CatFustella
        Private _C As CatFustellaW

        Public Property C As CatFustellaW
            Get
                Return _C
            End Get
            Set(value As CatFustellaW)
                _C = value
            End Set
        End Property

        Public Property IdPreventivazione As Integer

    End Class

End Namespace