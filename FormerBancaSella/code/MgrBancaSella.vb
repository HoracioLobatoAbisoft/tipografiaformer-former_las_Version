
Imports System.Net

Public Class MgrBancaSella

    Private Shared Function ConvertiImportoToBs(Importo As Decimal) As String
        Dim ris As String = String.Empty

        ris = FormerLib.FormerHelper.Stringhe.FormattaPrezzoBancaSella(Importo)

        Return ris
    End Function

    Public Shared Function Encript(R As BancaSellaRequest) As BancaSellaResult
        Dim ris As BancaSellaResult = Nothing

        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = 3072
        ServicePointManager.DefaultConnectionLimit = 9999

        Dim ws As New BancaSellaService.WSCryptDecryptSoapClient

        Dim risXML As Xml.XmlNode = ws.Encrypt(R.ShopLogin,
                                               R.uicCode,
                                               ConvertiImportoToBs(R.amount),
                                               R.ShopTransactionId,
                                               "",
                                               "",
                                               "",
                                               R.BuyerName,
                                               R.BuyerEmail,
                                               "",
                                               "",
                                               R.CustomInfo,
                                               "",
                                               "",
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               "",
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               Nothing,
                                               "",
                                               Nothing,
                                               "",
                                               Nothing)

        ris = New BancaSellaResult(risXML)

        Return ris
    End Function

    Public Shared Function UrlPageCreator(R As BancaSellaResult) As String
        Dim ris As String = String.Empty

        ris = FormerConfig.FConfiguration.BancaSella.EntryPoint

        ris &= "a=" & FormerConfig.FConfiguration.BancaSella.ShopLogin & "&b=" & R.CryptDecryptString

        Return ris
    End Function

    Public Shared Function Decript(ShopLogin As String,
                                   Buffer As String) As BancaSellaResult
        Dim ris As BancaSellaResult = Nothing

        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = 3072
        ServicePointManager.DefaultConnectionLimit = 9999

        Dim ws As New BancaSellaService.WSCryptDecryptSoapClient

        Dim risXML As Xml.XmlNode = ws.Decrypt(ShopLogin, Buffer)

        ris = New BancaSellaResult(risXML)
        Return ris
    End Function

End Class
