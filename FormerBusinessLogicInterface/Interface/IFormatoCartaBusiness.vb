Public Interface IFormatoCartaB

    Property IdFormCarta() As Integer

    Property FormatoCarta() As String

    Property Altezza() As Single

    Property Larghezza() As Single

    ReadOnly Property Area() As Single

    ReadOnly Property LatoLungoMM As Integer

    ReadOnly Property LatoCortoMM As Integer

End Interface
