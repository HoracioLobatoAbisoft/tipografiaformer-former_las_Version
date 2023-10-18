Public Interface ITipoCartaB

    Property IdTipoCarta() As Integer


    Property Tipologia() As String


    Property Finitura() As String


    Property Grammi() As Integer


    Property ImgRif() As String


    Property Sigla() As String


    Property CostoCartaKg() As Decimal


    Property Spessore() As Single


    Property TipoCarta() As Integer


    Property DescrizioneEstesa() As String


    Property TipoCosto() As Integer

    Property CostoRiferimento() As Decimal

    ReadOnly Property ComposizioniCarta As IEnumerable(Of IComposizioneCartaB)

End Interface
