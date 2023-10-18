Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmOrdineCambiaDataConsegna
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _O As Ordine = Nothing

    Friend Function Carica(O As Ordine) As Integer
        _O = O
        _O.Refresh()

        'mcDataScelta.

        If Not O.ConsegnaAssociata Is Nothing Then
            If O.ConsegnaAssociata.Giorno < Now.Date Then
                mcDataScelta.MinDate = O.ConsegnaAssociata.Giorno
            Else
                mcDataScelta.MinDate = Now.Date
            End If
            mcDataScelta.SelectionStart = O.ConsegnaAssociata.Giorno
            If O.ConsegnaAssociata.MatPom = enMomentoConsegna.Mattina Then
                rdoMattino.Checked = True
            End If
            If O.ConsegnaAssociata.Diritti.PossoAnticipareGiorno.Esito Then
                'qui posso anticipare il giorno
                'controllo se lo posso posticipare
                If O.ConsegnaAssociata.Diritti.PossoPosticipareGiorno.Esito = False Then
                    mcDataScelta.MaxDate = O.ConsegnaAssociata.Giorno
                End If
            Else
                'se non posso anticiparlo di certo non posso posticiparlo
                mcDataScelta.MaxDate = O.ConsegnaAssociata.Giorno
                mcDataScelta.Enabled = False
            End If
        End If

        SetDataSel()

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        Dim DataSelezionata As Date = mcDataScelta.SelectionStart
        Dim MatPom As enMomentoConsegna = enMomentoConsegna.Pomeriggio


        If DataSelezionata < Now.Date OrElse
            DataSelezionata.DayOfWeek = DayOfWeek.Sunday OrElse
            (DataSelezionata.DayOfWeek = DayOfWeek.Saturday And
            (_O.ConsegnaAssociata.IdCorr = enCorriere.GLS Or
            _O.ConsegnaAssociata.IdCorr = enCorriere.GLSIsole Or
            _O.ConsegnaAssociata.IdCorr = enCorriere.PortoAssegnatoGLS)) Then
            MessageBox.Show("Non si può scegliere una data nel passato, una domenica o un sabato in caso di ritiro Corriere")
        Else
            If rdoMattino.Checked Then MatPom = enMomentoConsegna.Mattina

            If _O.ConsegnaAssociata.Giorno <> DataSelezionata OrElse
                _O.ConsegnaAssociata.MatPom <> MatPom Then

                Dim ris As RisConsegnaModificabile = Nothing '_O.ConsegnaAssociata.ModificabileEx(True, False, False, False, False, True)

                If _O.ConsegnaAssociata.Giorno < DataSelezionata Then
                    'posticipo la consegna
                    ris = _O.ConsegnaAssociata.Diritti.PossoPosticipareGiorno
                Else
                    'anticipo la consegna
                    ris = _O.ConsegnaAssociata.Diritti.PossoAnticipareGiorno
                End If

                If ris.Esito Then
                    If MessageBox.Show("Confermi il cambio di consegna per l'ordine selezionato?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        _O.ConsegnaGarantita = DataSelezionata
                        _O.ConsegnaGarantitaDa = PostazioneCorrente.UtenteConnesso.IdUt
                        _O.LastUpdate = enSiNo.Si
                        _O.Save()

                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, _O.IdOrd, "Impostata Data consegna garantita")

                        Using mgr As New ConsegneProgrammateDAO
                            mgr.RegistraConsegnaOrdineSuGiorno(_O.IdOrd,
                                                                _O.ConsegnaAssociata.IdCorr,
                                                                DataSelezionata,
                                                                _O.IdRub,
                                                                MatPom,
                                                                _O.ConsegnaAssociata.IdIndirizzo,,,,
                                                                _O.ConsegnaAssociata.IdCons)
                        End Using
                        'End If

                        _Ris = 1
                        Close()

                    End If
                Else
                    MessageBox.Show(ris.BufferErrori)
                End If

            Else
                Close()
            End If
        End If

    End Sub

    Private Sub SetDataSel()
        lblDataSel.Text = mcDataScelta.SelectionStart.ToString("dddd dd/MM/yyyy")
    End Sub

    Private Sub mcDataScelta_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mcDataScelta.DateChanged
        SetDataSel()
    End Sub
End Class