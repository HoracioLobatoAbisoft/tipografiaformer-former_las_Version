Imports FormerLib

Public Interface ILavorazioneB

    Property IdLavoro() As Integer


    Property Descrizione() As String


    Property TempoRif() As Integer


    Property Premio() As Decimal


    Property SuCommessa() As Boolean


    Property SuProdotto() As Boolean


    Property Stato() As Integer


    Property Macchinario() As String


    Property Pubblica() As Boolean


    Property Prezzo() As Decimal


    Property IdCatLav() As Integer


    Property ImgRif() As String


    Property Sigla() As String


    Property FormatoRiferimento() As String


    Property IdMacchinario() As Integer


    Property CostoSingCopia() As Decimal


    Property IdTipoLav() As Integer


    Property GrammiMin() As Integer


    Property GrammiMax() As Integer

    Property ggRealiz() As Integer

    Property DescrizioneEstesa() As String

    ReadOnly Property Prezzi As List(Of IPrezzoLavoroB)

    ReadOnly Property MacchinarioRif As IMacchinarioB

    ReadOnly Property MacchinarioRif2 As IMacchinarioB

    ReadOnly Property Categoria As ICategoriaLavB
    ReadOnly Property ExtraData() As String

    ReadOnly Property ListExtraData As List(Of ExtraData)

    Function PrevistaSu(IdListinoBase As Integer) As Boolean

    Property DimensMaxH() As Integer
    Property DimensMaxW() As Integer
    Property DimensMedieMaxH() As Integer
    Property DimensMedieMaxW() As Integer
    Property DimensMedieMinH() As Integer
    Property DimensMedieMinW() As Integer
    Property DimensMinH() As Integer
    Property DimensMinW() As Integer

    Property IdMacchinario2() As Integer
    Property SePresenteCalcolaSuSoggetti() As Integer

End Interface
