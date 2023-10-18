Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class BloccoInEvidenza
        Private _L As ListinoBaseW

        Public Property L As ListinoBaseW
            Get
                Return _L
            End Get
            Set(value As ListinoBaseW)
                _L = value
            End Set
        End Property
    End Class

End Namespace