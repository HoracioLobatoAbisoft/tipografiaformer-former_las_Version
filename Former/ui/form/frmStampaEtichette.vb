Imports FormerDALSql
Imports FormerLib

Friend Class frmStampaEtichette
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private Sub CaricaStampantiDisponibili()

        For Each Stamp In FormerHelper.Printer.ElencoInstallate

            'cmbStampanteFatture.Items.Add(Stamp)
            cmbStampanti.Items.Add(Stamp)
            'cmbPrinterLibera.Items.Add(Stamp)
            'cmbPrinterOrdini.Items.Add(Stamp)

        Next

        MgrControl.SelectIndexComboTesto(cmbStampanti, FormerConfig.FConfiguration.Printer.Etichette)

    End Sub

    Friend Function Carica() As Integer

        CaricaStampantiDisponibili()

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

    Private Sub btnStampa_Click(sender As Object, e As EventArgs) Handles btnStampa.Click
        '        If MessageBox.Show("Confermi la stampa dell'etichetta?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        If cmbStampanti.Text.Length Then

            If TabMain.SelectedIndex = 1 Then
                'creazione etichette pacchi
                Try
                    Dim DifferenzialeEtichette As Integer = txtFineNumerazione.Value - txtInizioNumerazione.Value + 1
                    Dim EtichetteInPacco As Integer = txtNumeroPacchi.Value
                    Dim NumeroPacchi As Integer = Math.Ceiling(DifferenzialeEtichette / EtichetteInPacco)

                    Dim CounterInizio As Integer = txtInizioNumerazione.Text
                    Dim CounterFine As Integer = 0
                    Dim LunghezzaMax As Integer = txtFineNumerazione.Text.Trim.Length

                    For i As Integer = 1 To NumeroPacchi
                        Dim Riga1 As String = "Collo" & FormerLib.FormerHelper.Stringhe.FormattaConCaratterePrefisso(i & " di " & NumeroPacchi, 10, "-")
                        Dim Riga2 As String = String.Empty
                        Dim Riga3 As String = String.Empty

                        CounterFine = CounterInizio + EtichetteInPacco - 1

                        Riga2 = "Da " & FormerLib.FormerHelper.Stringhe.FormattaConSpazi(FormerHelper.Stringhe.FormattaNumero(CounterInizio), LunghezzaMax)
                        Riga3 = "A  " & FormerLib.FormerHelper.Stringhe.FormattaConSpazi(FormerHelper.Stringhe.FormattaNumero(CounterFine), LunghezzaMax)

                        Dim Etichetta As New EtichettaCustom
                        Etichetta.Riga1 = Riga1
                        Etichetta.Riga2 = Riga2
                        Etichetta.Riga3 = Riga3

                        Etichetta.WidthMM = FormerConst.ProdottiCaratteristiche.EtichetteCustom.WidthMM
                        Etichetta.HeightMM = FormerConst.ProdottiCaratteristiche.EtichetteCustom.HeightMM

                        MgrEtichetteCustom.StampaEtichettaCustom(Etichetta, cmbStampanti.Text)

                        CounterInizio = CounterFine + 1

                    Next

                Catch ex As Exception

                End Try

            Else
                'creazione etichette singole
                'Dim P As New myPrinter
                Dim Etichetta As New EtichettaCustom
                Etichetta.Riga1 = txtRiga1.Text.Trim
                Etichetta.Riga2 = txtRiga2.Text.Trim
                Etichetta.Riga3 = txtRiga3.Text.Trim
                Etichetta.Qta = txtQta.Value

                Etichetta.WidthMM = FormerConst.ProdottiCaratteristiche.EtichetteCustom.WidthMM
                Etichetta.HeightMM = FormerConst.ProdottiCaratteristiche.EtichetteCustom.HeightMM

                MgrEtichetteCustom.StampaEtichettaCustom(Etichetta, cmbStampanti.Text)

            End If

        Else
            MessageBox.Show("Selezionare una stampante")
        End If





        'P.PrinterName = FormerConfig.FConfiguration.Printer.Etichette
        'P.StampaEtichettaCustom(Etichetta)

        'P = Nothing

        '  End If
    End Sub

    Private Sub txtInizioNumerazione_TextChanged(sender As Object, e As EventArgs) Handles txtInizioNumerazione.TextChanged
        calcolaEtichetteStampate
    End Sub

    Private Sub txtFineNumerazione_TextChanged(sender As Object, e As EventArgs) Handles txtFineNumerazione.TextChanged
        calcolaEtichetteStampate
    End Sub

    Private Sub txtNumeroPacchi_TextChanged(sender As Object, e As EventArgs) Handles txtNumeroPacchi.TextChanged
        calcolaEtichetteStampate
    End Sub

    Private Sub calcolaEtichetteStampate()

        Dim NumeroPacchi As Integer = 0

        Try
            Dim DifferenzialeEtichette As Integer = txtFineNumerazione.Value - txtInizioNumerazione.Value + 1
            Dim EtichetteInPacco As Integer = txtNumeroPacchi.Value
            NumeroPacchi = Math.Ceiling(DifferenzialeEtichette / EtichetteInPacco)
        Catch ex As Exception

        End Try

        lblEtichetteStampate.Text = "Verranno stampate " & NumeroPacchi & " etichette"

    End Sub

End Class