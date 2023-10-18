Imports FormerConfig

Public Class BancaSellaRequest

    Public ReadOnly Property ShopLogin As String
        Get
            Dim ris As String = String.Empty

            ris = FormerConfig.FConfiguration.BancaSella.ShopLogin

            Return ris
        End Get
    End Property

    'http://api.gestpay.it/#currency-codes
    Public ReadOnly Property uicCode As String '242 EURO
        Get
            Return "242"
        End Get
    End Property

    Public Property amount As Decimal = 0

    Public Property ShopTransactionId As String = String.Empty

    Public Property BuyerName As String = String.Empty
    Public Property BuyerEmail As String = String.Empty
    Public Property CustomInfo As String = String.Empty

End Class
