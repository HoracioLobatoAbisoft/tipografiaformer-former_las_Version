Public Class PPResponse

    Private _ChiaveTotale As String = "mc_gross"
    Private _ChiaveIdTransazione As String = "custom"
    Private _ChiaveStatoPagamento As String = "payment_status"
    Private _ChiaveBeneficiario As String = "receiver_email"
    Private _ChiaveValuta As String = "mc_currency"

    Public Sub New(ChiamataIniziale As String)

        _ChiamataIniziale = ChiamataIniziale
        Dim ValoriChiamata() As String = _ChiamataIniziale.Split("&")

        For Each S As String In ValoriChiamata
            Dim SingVal() As String = S.Split("=")
            _Valori.Add(SingVal(0), SingVal(1))
        Next

    End Sub

    Private _Valori As New Dictionary(Of String, String)

    Private _ChiamataIniziale As String = String.Empty

    Public ReadOnly Property TransazioneDalSito As Boolean
        Get
            Dim ris As Boolean = False
            If IdTransazione.Length Then
                ris = True
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property RispostaFormattataHTML() As String
        Get
            Dim ris As String = String.Empty

            If EsitoPayPal.Length Then
                ris = "<h1>" & EsitoPayPal & "</h1>"
            End If

            ris &= _ChiamataIniziale.Replace("&", "<br>")

            Return ris
        End Get
    End Property

    Public Property EsitoPayPal As String = String.Empty

    Public ReadOnly Property IdTransazione As String
        Get
            Dim ris As String = String.Empty
            Try
                ris = _Valori(_ChiaveIdTransazione)
            Catch ex As Exception

            End Try
            Return ris
        End Get
    End Property

    Public ReadOnly Property StatoPagamento As String
        Get
            Return _Valori(_ChiaveStatoPagamento)
        End Get
    End Property

    Public ReadOnly Property Beneficiario As String
        Get
            Return _Valori(_ChiaveBeneficiario).Replace("%40", "@")
        End Get
    End Property

    Public ReadOnly Property Valuta As String
        Get
            Return _Valori(_ChiaveValuta)
        End Get
    End Property

    Public ReadOnly Property ImportoPagamento As Decimal
        Get
            Dim ris As Decimal = 0

            ris = Convert.ToDecimal(_Valori(_ChiaveTotale).Replace(".", ","))

            Return ris
        End Get
    End Property

    Public ReadOnly Property ImportoPagamentoConfrontoPP As String
        Get
            Dim ris As String = String.Empty

            ris = _Valori(_ChiaveTotale).Replace(".", "")
            ris = ris.Replace(",", "")

            Return ris
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty

            ris &= ImportoPagamento.ToString() & "<br>"
            ris &= Beneficiario & "<br>"
            ris &= Valuta & "<br>"
            ris &= IdTransazione & "<br>"
            ris &= StatoPagamento & "<br>"

            Return ris
        End Get
    End Property

End Class
