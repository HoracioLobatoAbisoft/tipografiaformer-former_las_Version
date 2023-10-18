Public Interface IPrezzoLavoroB

    Property IdLavPrezzo() As Integer

    Property IdLavoro() As Integer

    Property IdFormProd() As Integer

    ReadOnly Property IdFormCarta() As Integer

    ReadOnly Property PrezzoSuProdottoFinito() As Boolean

    Property Prezzo() As Decimal

    Property QtaRif() As Integer

    Property PrezzoMin() As Decimal

    Property PrezzoOltre() As Decimal

    Property TipoGrandezza() As Integer

    Property Prezzo2() As Decimal

    Property PrezzoMin2() As Decimal

    Property PrezzoOltre2() As Decimal

    ReadOnly Property FormatoProdotto As IFormatoProdottoB

    ReadOnly Property FormatoCarta As IFormatoCartaB

    Function ClonaPrezzo() As Object

End Interface