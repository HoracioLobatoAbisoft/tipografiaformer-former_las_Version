Public Interface IPreventivazioneB

    Property IdPrev() As Integer


    Property Prefisso() As String

    Property TipoProd() As Integer

    Property Descrizione() As String

    Property DescrizioneEstesa() As String

    Property ggFast() As Integer

    Property ggNorm() As Integer

    Property ggSlow() As Integer

    Property RicaricoPubblico() As Integer

    Property GraficaPerFacciata() As Decimal

    Property ImgRif() As String

    Property ImgSito() As String

    Property UrlVideo() As String

    Property IdReparto() As Integer

    Property DispOnline() As Boolean

    Property Linguetta As Integer

    Property IdFunzionePack As Integer

    Property PercFast As Integer

    Property PercSlow As Integer

    Property IdPluginToUse As Integer

    ReadOnly Property ListiniBase As List(Of IListinoBaseB)

End Interface
