
Public Interface IOrdineBox

    ReadOnly Property IdProdotto As Integer
    ReadOnly Property IdRiferimentoOrdine As Integer
    ReadOnly Property IdOrdineWeb As Integer
    ReadOnly Property IdOrdineInt As Integer
    ReadOnly Property NOrdineStr As String
    Property StatoStr As String
    ReadOnly Property IconaStato As String
    ReadOnly Property ColoreStatoHTML As String
    ReadOnly Property QtaStr As String
    ReadOnly Property BoxTitolo As String
    ReadOnly Property DataConsegnaStr As String
    ReadOnly Property ImportoNettoStr As String
    ReadOnly Property ImportoNettoOrigStr As String
    ReadOnly Property BoxImgRif As String
    ReadOnly Property DimensioniStr As String
    ReadOnly Property AnteprimaWeb As String
    ReadOnly Property NomeProdotto As String
    ReadOnly Property SupportoStr As String
    ReadOnly Property BoxLavorazioni As List(Of String)
    ReadOnly Property CorriereStr As String
    ReadOnly Property ColliStr As String
    ReadOnly Property PesoStr As String
    ReadOnly Property ColoriStampaStr As String
    ReadOnly Property SchedaProdotto As String
    ReadOnly Property PathTemplate As String
    ReadOnly Property NFogliVisStr As String
    Property StatoOrdine As Integer
    ReadOnly Property NoteOrd As String
    ReadOnly Property NomeLavoro As String
    ReadOnly Property ListinoBase As ListinoBaseW
    ReadOnly Property OrientamentoSelezionato As Integer
    ReadOnly Property OrientamentoSelezionatoStr As String
    ReadOnly Property Omaggio As Integer
    ReadOnly Property Promo As Integer
    ReadOnly Property IdCoupon As Integer
    ReadOnly Property ImportoTotaleScontiStr As String

    ReadOnly Property IdTipoFustella As Integer
    ReadOnly Property Base As Integer
    ReadOnly Property Altezza As Integer
    ReadOnly Property Profondita As Integer
    ReadOnly Property IdConsegna As Integer?

End Interface
