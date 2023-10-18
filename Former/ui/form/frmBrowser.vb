Imports FormerBusinessLogic

Friend Class frmBrowser
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Friend Function Carica(ByVal IndirizzoInternet As String) As Integer

        WebMain.Navigate(IndirizzoInternet)

        ShowDialog()

        Return _Ris

    End Function

    Private _ListFatture As List(Of FatturaElettronica) = Nothing
    Friend Function CaricaFromCheckMassivoFatture(ByVal IndirizzoInternet As String,
                                                  ListFatture As List(Of FatturaElettronica)) As Integer
        _ListFatture = ListFatture

        If _ListFatture.Count Then
            lnkImportaAutomaticamenteFattureMancanti.Visible = True
        End If

        WebMain.Navigate(IndirizzoInternet)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub lnkStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        Sottofondo()

        Using x As New frmStampa

            x.Carica(WebMain)

        End Using

        Sottofondo()
    End Sub

    Private Sub LnkImportaAutomaticamenteFattureMancanti_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkImportaAutomaticamenteFattureMancanti.LinkClicked
        ImportaFattureRicevuteMancanti()
    End Sub

    Private Sub ImportaFattureRicevuteMancanti()

        If _ListFatture.Count Then
            If MessageBox.Show("Confermi l'inserimento automatico delle fatture ricevute non trovate nel DATABASE INTERNO?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim Counter As Integer = 0
                Dim CounterKO As Integer = 0
                For Each SingFat As FatturaElettronica In _ListFatture

                    Dim PathTemp As String = String.Empty
                    PathTemp = FormerConfig.FormerPath.PathTempLocale
                    FormerLib.FormerHelper.File.CreateLongPath(PathTemp)

                    PathTemp &= FormerLib.FormerHelper.File.GetNomeFileTemp(".xml")

                    MgrFattureFE.FatturaElettronicaToXML(SingFat, PathTemp)

                    Dim RisSalvataggio As RisSalvaCostoDaFatturaElettronica = MgrFattureFE.SalvaCostoDaFatturaElettronica(SingFat, PathTemp)

                    If RisSalvataggio.DaScartare Then
                        CounterKO += 1
                    Else
                        Counter += 1
                    End If


                Next
                MessageBox.Show("Sono state importati " & Counter & " documenti contabili, NON importati " & CounterKO & " documenti contabili")
                Close()
            End If
        Else
            Beep()
        End If

    End Sub

End Class