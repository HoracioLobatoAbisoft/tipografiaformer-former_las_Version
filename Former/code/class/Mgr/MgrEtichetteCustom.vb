Imports FormerDALSql

Public Class MgrEtichetteCustom

    Public Shared Sub StampaEtichettaCustom(E As EtichettaCustom, PercorsoStampante As String)

        Dim P As New myPrinter
        'P.PrinterName = FormerConfig.FConfiguration.Printer.Etichette
        P.PrinterName = PercorsoStampante
        P.StampaEtichettaCustom(E)
        P = Nothing

    End Sub

End Class
