Imports FormerLib.FormerEnum
Imports FormerDALSql
Imports FormerLib

Public Class ucDocumentiStato
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
        If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then ColoraStati()
    End Sub
    Private Sub ColoraStati()
        chkRegistrato.BackColor = FormerColori.GetColoreStatoDocFiscale(enStatoDocumentoFiscale.Registrato)
        chkPagatoInParte.BackColor = FormerColori.GetColoreStatoDocFiscale(enStatoDocumentoFiscale.PagatoAcconto)
        chkPagatoTutto.BackColor = FormerColori.GetColoreStatoDocFiscale(enStatoDocumentoFiscale.PagatoInteramente)
    End Sub
    Public Event CambiatoStato()

End Class
