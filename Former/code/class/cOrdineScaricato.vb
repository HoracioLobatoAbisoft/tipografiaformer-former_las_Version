Public Class cOrdineScaricato

    Private _IdCliente As Integer = 0
    Public Property IdCliente() As Integer
        Get
            Return _IdCliente
        End Get
        Set(ByVal value As Integer)
            _IdCliente = value
        End Set
    End Property

    Dim _NomeFileOrd As String
    Public Property NomeFileOrd() As String
        Get
            Return _NomeFileOrd
        End Get
        Set(ByVal value As String)
            _NomeFileOrd = value
        End Set
    End Property

    Private _NumOrd As String = ""
    Public Property NumOrd() As String
        Get
            Return _NumOrd
        End Get
        Set(ByVal value As String)
            _NumOrd = value
        End Set
    End Property

    Public Prodotto As String = ""
    Public IdCorriere As Integer = 0
    Public Email As String = ""

    Public Anteprima As String
    Public Sorgente1 As String
    Public Sorgente2 As String
    Public Sorgente3 As String
    Public Sorgente4 As String

    Public Preventivo As Integer = 0
    Public Note As String = ""

    Public TipoConsegna As Integer = 0

    Public Rilascio As Integer = 0


End Class

Public Class cPreventivoScaricato

    Public Sub New()




    End Sub
    Private _IdCliente As Integer = 0

    Public Property IdCliente() As Integer

        Get
            Return _IdCliente
        End Get
        Set(ByVal value As Integer)
            _IdCliente = value
        End Set
    End Property
    Private _NomeFilePrev As String = ""

    Public Property NomeFilePrev() As String
        Get
            Return _NomeFilePrev
        End Get

        Set(ByVal value As String)
            _NomeFilePrev = value
        End Set
    End Property

    Private _IdPrev As Integer = 0
    Public Property IdPrev() As Integer
        Get
            Return _IdPrev
        End Get
        Set(ByVal value As Integer)
            _IdPrev = value
        End Set
    End Property

    Private _Numero As String = ""
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property

    Private _TipoLavoro As String = ""
    Public Property TipoLavoro() As String
        Get
            Return _TipoLavoro
        End Get
        Set(ByVal value As String)
            _TipoLavoro = value
        End Set
    End Property

    Private _Qta As String = ""
    Public Property Qta() As String
        Get
            Return _Qta
        End Get
        Set(ByVal value As String)
            _Qta = value
        End Set
    End Property

    Private _Pagine As String = ""
    Public Property Pagine() As String
        Get
            Return _Pagine
        End Get
        Set(ByVal value As String)
            _Pagine = value
        End Set
    End Property

    Private _Stampa As String = ""
    Public Property Stampa() As String
        Get
            Return _Stampa
        End Get
        Set(ByVal value As String)
            _Stampa = value
        End Set
    End Property

    Private _FormatoAperto As String = ""
    Public Property FormatoAperto() As String
        Get
            Return _FormatoAperto
        End Get
        Set(ByVal value As String)
            _FormatoAperto = value
        End Set
    End Property

    Private _FormatoChiuso As String = ""
    Public Property FormatoChiuso() As String
        Get
            Return _FormatoChiuso
        End Get
        Set(ByVal value As String)
            _FormatoChiuso = value
        End Set
    End Property

    Private _Carta As String = ""
    Public Property Carta() As String
        Get
            Return _Carta
        End Get
        Set(ByVal value As String)
            _Carta = value
        End Set
    End Property

    Private _Lavorazioni As String = ""
    Public Property Lavorazioni() As String
        Get
            Return _Lavorazioni
        End Get
        Set(ByVal value As String)
            _Lavorazioni = value
        End Set
    End Property

    Private _IdCorr As Integer = 0
    Public Property IdCorr() As Integer
        Get
            Return _IdCorr
        End Get
        Set(ByVal value As Integer)
            _IdCorr = value
        End Set
    End Property

    Public NomeFileOriginale As String = ""
    Public NomeFileDestinazione As String = ""




End Class