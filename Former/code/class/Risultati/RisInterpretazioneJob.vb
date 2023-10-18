Imports FormerDALSql
Imports FormerBusinessLogic

Public Class RisInterpretazioneJob

    Public Property Segnature As Integer = 0
    Public Property ListaFile As New List(Of RisFileTrovatoNelJob)
    Public Property ListaIdFormatiProdotto As New Dictionary(Of Integer, Integer)
    Public Property BufferErrori As String = String.Empty
    Public Property ErroriBloccanti As Boolean = False
    Public Property Alert As Boolean = False
    Public Property NoteGenerali As String = String.Empty
    Public Property ListaIdOrdSelezionati As Integer() = Nothing
    Public Property ListaOrdini As New List(Of Ordine)
    Public Property MacchinarioTrovato As Macchinario = Nothing

    Public Property FormatoMacchina As Formato = Nothing
    Public ReadOnly Property IdMacchinario As Integer
        Get
            Dim Ris As Integer = 0

            If Not MacchinarioTrovato Is Nothing Then
                Ris = MacchinarioTrovato.IdMacchinario
            End If

            Return Ris
        End Get
    End Property

    Public Property ListaIdPagine As New List(Of Integer)

    Public ReadOnly Property NumSpazi As Integer
        Get
            Dim tot As Integer = 0

            tot = ListaIdPagine.Count

            Return tot
        End Get
    End Property

End Class
