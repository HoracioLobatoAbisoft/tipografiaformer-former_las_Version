Imports FormerDALSql
Friend Class frmInsertUsb
    'Inherits frmUsbResponsiveForm

    Private _U As Utente = Nothing

    Friend Function Carica() As Utente

        ShowDialog()
        Return _U

    End Function

    'Private Sub frmInsertUsb_ChiaveUSBConnessa() Handles Me.ChiaveUSBConnessa

    '    pnlCollegata.Visible = True
    '    Application.DoEvents()
    '    _U = MgrUsbLogin.TryLogin

    '    If Not _U Is Nothing Then
    '        Close()
    '    Else
    '        pnlCollegata.Visible = False
    '    End If

    'End Sub

    Private Sub btnEsci_Click(sender As Object, e As EventArgs) Handles btnEsci.Click
        If MessageBox.Show("Confermi la chiusura del programma?", "Chiusura Programma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            End

        End If
    End Sub
End Class