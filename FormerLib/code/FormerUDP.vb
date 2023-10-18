Public Class FormerUDP

    Public Shared Property PortaUdp As Integer = 2456

    Public Shared Sub SendUDPCommand(TipoMessaggio As String,
                                     ByVal Testo As String,
                                     Optional Destinatario As String = DestUDP_All,
                                     Optional Mittente As String = "")

        Dim bufferInvio As String = Destinatario & "@" & TipoMessaggio & Testo

        If Mittente.Length Then
            bufferInvio &= "@" & Mittente
        End If

        SendUdpMessage(bufferInvio)

    End Sub

    Private Shared Sub SendUdpMessage(messaggio As String)

        Dim udp As New Net.Sockets.UdpClient()
        udp.EnableBroadcast = True
        udp.Ttl = 1

        Dim ep As New Net.IPEndPoint(Net.IPAddress.Broadcast, PortaUdp)
        Dim b() As Byte = System.Text.Encoding.UTF32.GetBytes(messaggio)
        udp.Send(b, b.Length, ep)
        udp.Close()

    End Sub

    Public Const TipoUDP_PrinterComanda As String = "A"
    Public Const TipoUDP_CreaAnteprimaCommessa As String = "B"
    Public Const TipoUDP_CallerID As String = "C"
    Public Const TipoUDP_PrinterPDF As String = "D"
    Public Const TipoUDP_MandaAlFlussoCommessa As String = "E"
    Public Const TipoUDP_Messaggio As String = "M"
    Public Const TipoUDP_Notifica As String = "N"
    Public Const TipoUDP_ForzaScaricamentoOrdini As String = "O"
    Public Const TipoUDP_Ping As String = "P"
    Public Const TipoUDP_RefineAutomatico As String = "R"
    Public Const TipoUDP_Service As String = "S"
    Public Const TipoUDP_Versioning As String = "V"
    Public Const TipoUDP_Printer As String = "W"
    Public Const TipoUDP_RigeneraAnteprimaModello As String = "X"
    Public Const TipoUDP_RigeneraAnteprimaOrdine As String = "Z"

    Public Const DestUDP_All As String = "ALL"
    Public Const DestUDP_Admin As String = "ALL-ADMIN"
    Public Const DestUDP_Operatore As String = "ALL-OPERATORI"

End Class
