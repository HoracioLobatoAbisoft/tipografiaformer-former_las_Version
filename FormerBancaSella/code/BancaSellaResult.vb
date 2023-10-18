Public Class BancaSellaResult

    Public Property Tipo As String = String.Empty
    Public Property Risultato As String = String.Empty
    Public Property CryptDecryptString As String = String.Empty

    Public Property ErrorCode As String = String.Empty
    Public Property ErrorDescription As String = String.Empty

    Public Property ShopTransactionID As String = String.Empty
    Public Property BankTransactionID As String = String.Empty
    Public Property CustomInfo As String = String.Empty

    Public Property CurrencyCode As String = String.Empty
    Public Property ImportoStr As String = String.Empty

    Public ReadOnly Property Importo As Decimal
        Get
            Dim ris As Decimal = 0

            'qui devo convertire una stringa di tipo 104.50 in decimal 
            ris = ImportoStr.Replace(".", ",")

            Return ris
        End Get
    End Property

    'Public ReadOnly Property GuidStr As String
    '    Get
    '        Dim ris As String = String.Empty

    '        Try
    '            ris = CustomInfo.Substring(CustomInfo.IndexOf("=") + 1)
    '        Catch ex As Exception

    '        End Try

    '        Return ris
    '    End Get
    'End Property

    Public Sub New(risXml As Xml.XmlNode)

        'qui riempio le property con i vari nodi

        For Each singNode As Xml.XmlNode In risXml.ChildNodes

            If singNode.Name = "TransactionType" Then
                Tipo = singNode.InnerText
            End If

            If singNode.Name = "TransactionResult" Then
                Risultato = singNode.InnerText
            End If

            If singNode.Name = "CryptDecryptString" Then
                CryptDecryptString = singNode.InnerText
            End If

            If singNode.Name = "ShopTransactionID" Then
                ShopTransactionID = singNode.InnerText
            End If

            If singNode.Name = "BankTransactionID" Then
                BankTransactionID = singNode.InnerText
            End If

            If singNode.Name = "ErrorCode" Then
                ErrorCode = singNode.InnerText
            End If

            If singNode.Name = "ErrorDescription" Then
                ErrorDescription = singNode.InnerText
            End If

            If singNode.Name = "CustomInfo" Then
                CustomInfo = singNode.InnerText
            End If

            If singNode.Name = "Currency" Then
                CurrencyCode = singNode.InnerText
            End If

            If singNode.Name = "Amount" Then
                ImportoStr = singNode.InnerText
            End If

        Next

    End Sub

End Class
