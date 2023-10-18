Public Interface IFormatoB

    Property IdFormato() As Integer


    Property Formato() As String


    Property DivisioneFoglio() As Integer


    Property Altezza() As Integer

    Property Larghezza() As Integer

    ReadOnly Property LatoLungoMM As Integer

    ReadOnly Property LatoCortoMM As Integer

    Property CostoLastra() As Decimal

    'ReadOnly Property Macchinario As IMacchinarioB

    Property IdMacchinario() As Integer

    Property ImgRif() As String

    'ReadOnly Property Macchinario As IMacchinarioB

End Interface
