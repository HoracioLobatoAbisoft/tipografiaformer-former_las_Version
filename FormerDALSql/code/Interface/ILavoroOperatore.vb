Imports System.Drawing
Imports FormerLib.FormerEnum
Public Interface ILavoroOperatore

    ReadOnly Property IdLavLog As Integer
    ReadOnly Property IdOrdine As Integer
    ReadOnly Property IdLavoro As Integer
    ReadOnly Property IdCommessa As Integer
    ReadOnly Property IdOrdineStr As String
    ReadOnly Property IdCommessaStr As String
    ReadOnly Property Priorita As String
    ReadOnly Property Stato As Integer
    ReadOnly Property StatoStr As String
    ReadOnly Property DataInserimentoStr As String
    ReadOnly Property DataRiferimentoStr As String
    ReadOnly Property Tipo As String
    ReadOnly Property Copie As String
    ReadOnly Property LavorazioneStr As String
    ReadOnly Property FronteRetro As String
    ReadOnly Property InCaricoA As String
    ReadOnly Property RisorsaStr As String
    ReadOnly Property QtaStr As String
    ReadOnly Property NLastreStr As String
    Function PrendibileInCarico(Optional IdUtenteConnesso As Integer = 0,
                                Optional RicaricaTuttiIDati As Boolean = False) As Boolean
    ReadOnly Property DataInserimento As Date
    ReadOnly Property RagSocNome As String

    ReadOnly Property IdMacchinario As Integer

    ReadOnly Property DataOraInizio As Date
    ReadOnly Property DataOraFine As Date
    ReadOnly Property IdUtInCarico As Integer
    ReadOnly Property IdUtForzato As Integer

    ReadOnly Property ImgAnteprima As Image
    ReadOnly Property ImgLavorazione As Image
    ReadOnly Property ImgMacchinario As Image
    ReadOnly Property IcoSegnalino As Image
    ReadOnly Property IcoMsg As Image
    ReadOnly Property TipoLavLog As enTipoVoceOrdineCommessa

    ReadOnly Property DataRifOrdinamento As Date

    ReadOnly Property AnnotazioniOperatore As String

End Interface
