Public Class StatoLavorazione
    Private _Stato As Integer = 0
    Public Property Stato As Integer
        Get
            Return _Stato
        End Get
        Set(value As Integer)
            _Stato = value
        End Set
    End Property

    Private _IdCrono As Integer = 0
    Public Property IdCrono As Integer
        Get
            Return _IdCrono
        End Get
        Set(value As Integer)
            _IdCrono = value
        End Set
    End Property

    Private _IdOp As Integer = 0
    Public Property IdOp As Integer
        Get
            Return _IdOp
        End Get
        Set(value As Integer)
            _IdOp = value
        End Set
    End Property

    Private _dataInizio As Date = Date.MinValue
    Public Property DataInizio As Date
        Get
            Return _dataInizio
        End Get
        Set(value As Date)
            _dataInizio = value
        End Set
    End Property

    Private _dataFine As Date = Date.MinValue
    Public Property DataFine As Date
        Get
            Return _dataFine
        End Get
        Set(value As Date)
            _dataFine = value
        End Set
    End Property
End Class
