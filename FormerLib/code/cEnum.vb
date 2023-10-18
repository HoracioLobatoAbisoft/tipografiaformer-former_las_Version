Public Class cEnum
    Public Sub New()


    End Sub

    Public Sub New(NId As Integer, NDescrizione As String)
        _Id = NId
        _Descrizione = NDescrizione
    End Sub

    Private _Id As Integer = 0
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal Value As Integer)
            _Id = Value
        End Set
    End Property

    Private Property _Descrizione As String = String.Empty
    Public Property Descrizione() As String
        Get
            Return _Descrizione
        End Get
        Set(ByVal Value As String)
            _Descrizione = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Descrizione
    End Function

End Class
