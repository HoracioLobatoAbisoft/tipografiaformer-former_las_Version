Public Class RisSituazioneCliente

    Public Property IdRub As Integer = 0
    Public Property RagSocNome As String = String.Empty
    Public Property TotaleDocumenti As Decimal = 0
    Public Property TotaleIncassati As Decimal = 0
    Public Property TotaleDaIncassareScaduto As Decimal = 0
    Public Property TotaleProntoStampa As Decimal = 0

    Public Property UltimoPagamento As Pagamento = Nothing
    Public Property UltimoLavoro As Ordine = Nothing

    Public Property ListaAnniDocumenti As New List(Of Integer)

    Public ReadOnly Property DataUltimoPagamento As Date
        Get
            Dim ris As Date = Date.MinValue
            If Not UltimoPagamento Is Nothing Then
                ris = UltimoPagamento.DataPag
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property DataUltimoLavoro As Date
        Get
            Dim ris As Date = Date.MinValue
            If Not UltimoLavoro Is Nothing Then
                ris = UltimoLavoro.DataIns
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property TotaleDaIncassare As Decimal
        Get
            Return TotaleDocumenti - TotaleIncassati
        End Get
    End Property

    Public ReadOnly Property TotaleScopertoComplessivo As Decimal
        Get
            Return TotaleProntoStampa + TotaleDaIncassare 'TotaleDaIncassareScaduto
        End Get
    End Property

End Class
