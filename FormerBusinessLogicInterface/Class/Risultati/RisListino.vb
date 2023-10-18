Public Class RisListinoBase

    Public Sub New(ByRef Listino As IListinoBaseB)
        _L = Listino
    End Sub

    Private _L As IListinoBaseB
    Public ReadOnly Property L As IListinoBaseB
        Get
            Return _L
        End Get
    End Property

    Public Property CostoImpianti As Decimal = 0

    Public Property PrezzoCarta1 As Decimal = 0
    Public Property PrezzoCarta2 As Decimal = 0
    Public Property PrezzoCarta3 As Decimal = 0
    Public Property PrezzoCarta4 As Decimal = 0
    Public Property PrezzoCarta5 As Decimal = 0
    Public Property PrezzoCarta6 As Decimal = 0

    Public Property PrezzoStampa1 As Decimal = 0
    Public Property PrezzoStampa2 As Decimal = 0
    Public Property PrezzoStampa3 As Decimal = 0
    Public Property PrezzoStampa4 As Decimal = 0
    Public Property PrezzoStampa5 As Decimal = 0
    Public Property PrezzoStampa6 As Decimal = 0

    Public Property PrezzoLavObbl1 As Decimal = 0
    Public Property PrezzoLavObbl2 As Decimal = 0
    Public Property PrezzoLavObbl3 As Decimal = 0
    Public Property PrezzoLavObbl4 As Decimal = 0
    Public Property PrezzoLavObbl5 As Decimal = 0
    Public Property PrezzoLavObbl6 As Decimal = 0

    Public Property PrezzoLavOpz1 As Decimal = 0
    Public Property PrezzoLavOpz2 As Decimal = 0
    Public Property PrezzoLavOpz3 As Decimal = 0
    Public Property PrezzoLavOpz4 As Decimal = 0
    Public Property PrezzoLavOpz5 As Decimal = 0
    Public Property PrezzoLavOpz6 As Decimal = 0

    Public Property PrezzoRivCalc1 As Decimal = 0
    Public Property PrezzoRivCalc2 As Decimal = 0
    Public Property PrezzoRivCalc3 As Decimal = 0
    Public Property PrezzoRivCalc4 As Decimal = 0
    Public Property PrezzoRivCalc5 As Decimal = 0
    Public Property PrezzoRivCalc6 As Decimal = 0

    Public Property PrezzoTotCartaImpianti1 As Decimal = 0
    Public Property PrezzoTotCartaImpianti2 As Decimal = 0
    Public Property PrezzoTotCartaImpianti3 As Decimal = 0
    Public Property PrezzoTotCartaImpianti4 As Decimal = 0
    Public Property PrezzoTotCartaImpianti5 As Decimal = 0
    Public Property PrezzoTotCartaImpianti6 As Decimal = 0

    Public Property PrezzoRivFinale1 As Decimal = 0
    Public Property PrezzoRivFinale2 As Decimal = 0
    Public Property PrezzoRivFinale3 As Decimal = 0
    Public Property PrezzoRivFinale4 As Decimal = 0
    Public Property PrezzoRivFinale5 As Decimal = 0
    Public Property PrezzoRivFinale6 As Decimal = 0

    Public Property PrezzoPubblFinale1 As Decimal = 0
    Public Property PrezzoPubblFinale2 As Decimal = 0
    Public Property PrezzoPubblFinale3 As Decimal = 0
    Public Property PrezzoPubblFinale4 As Decimal = 0
    Public Property PrezzoPubblFinale5 As Decimal = 0
    Public Property PrezzoPubblFinale6 As Decimal = 0

    Public Property PrezzoConsPubblFinale1 As Decimal = 0
    Public Property PrezzoConsPubblFinale2 As Decimal = 0
    Public Property PrezzoConsPubblFinale3 As Decimal = 0
    Public Property PrezzoConsPubblFinale4 As Decimal = 0
    Public Property PrezzoConsPubblFinale5 As Decimal = 0
    Public Property PrezzoConsPubblFinale6 As Decimal = 0

    Public Property PrezziLavorazioni() As New Dictionary(Of String, Decimal)

    Public Property P1 As Single = 0
    Public Property P2 As Single = 0
    Public Property P3 As Single = 0
    Public Property P4 As Single = 0
    Public Property P5 As Single = 0
    Public Property P6 As Single = 0



End Class

