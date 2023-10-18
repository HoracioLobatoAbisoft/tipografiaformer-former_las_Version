Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib

Friend Class frmOrdineModificaImporti

    Private _Ris As Integer = 0
    Private _Ord As Ordine
    Private _ByPassControlli As Boolean = False

    Friend Function Carica(ByVal IdOrd As Integer,
                           Optional ByPassControlli As Boolean = False) As Integer

        _ByPassControlli = ByPassControlli

        Using Corriere As New CorrieriDAO

            cmbCorriere.DataSource = Corriere.GetAll(LFM.Corriere.Descrizione)
            cmbCorriere.ValueMember = "IdCorriere"
            cmbCorriere.DisplayMember = "Descrizione"
        End Using
        _Ord = New Ordine
        _Ord.Read(IdOrd)

        txtNumOrd.Text = _Ord.IdOrd

        Try
            If FileIO.FileSystem.FileExists(_Ord.FilePath) Then pctPreview.Image = Image.FromFile(_Ord.FilePath)
        Catch ex As Exception

        End Try

        chkPreventivo.Checked = IIf(_Ord.Preventivo = enSiNo.Si, True, False)
        chkUsaNomeLavoro.Checked = IIf(_Ord.UsaNomeLavoroInFattura = enSiNo.Si, True, False)

        chkMantieniCampione.Checked = IIf(_Ord.MantieniCampione = enSiNo.Si, True, False)

        lblTotForn.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_Ord.TotaleForn)
        txtSconto.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_Ord.Sconto)
        txtRicarico.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_Ord.Ricarico)
        lblTotImp.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_Ord.TotaleImponibile)
        lblIva.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_Ord.Iva)
        MgrControl.SelectIndexCombo(cmbCorriere, _Ord.IdCorriere)
        txtNote.Text = _Ord.Annotazioni
        txtTotDaRicavare.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_Ord.TotaleImponibile)

        txtNomeLavoro.Text = _Ord.NomeLavoro

        'carico la combo degli stati
        Dim StatoOrd As New cStatoOrdini(False)
        cmbStato.DataSource = StatoOrd
        cmbStato.ValueMember = "Id"
        cmbStato.DisplayMember = "Descrizione"

        MgrControl.SelectIndexComboEnum(cmbStato, _Ord.Stato)
        'If _Ord.ConsegnaAssociata.Modificabile(False) = False Then
        'If _Ord.ConsegnaAssociata.Diritti.'_Ord.ConsegnaAssociata.ModificabileEx(True, True, True, True, True, False).Modificabile = False Then
        cmbStato.Enabled = False
        'End If

        If FormerDebug.DebugAttivo = False Then
            cmbStato.Enabled = False
        End If

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

    Private Sub CalcolaTotali()
        '' calcolo iva e totale
        If Not _Ord Is Nothing Then

            Dim TotaleFornitura As Decimal = _Ord.TotaleForn

            Dim Sconto As Decimal = 0
            Try
                Sconto = CDec(txtSconto.Text)
            Catch ex As Exception

            End Try
            Dim Ricarico As Decimal = 0
            Try
                Ricarico = CDec(txtRicarico.Text)
            Catch ex As Exception

            End Try

            Dim TotImponibile As Decimal = TotaleFornitura - Sconto + Ricarico
            Dim Iva As Decimal = FormerHelper.Finanziarie.CalcolaIva(TotImponibile)

            lblTotImp.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotImponibile)
            lblIva.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Iva)
        End If
    End Sub

    Private Sub txtSconto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSconto.TextChanged, txtRicarico.TextChanged
        CalcolaTotali()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If chkUsaNomeLavoro.Checked And txtNomeLavoro.Text.Trim.Length = 0 Then
            MessageBox.Show("Per forzare il nome lavoro in fattura il campo deve essere valorizzato")
        Else
            If _Ord.ConsegnaAssociata.HaUnPagamentoAnticipato = False Then
                If _Ord.DocumentoFiscale Is Nothing Or _ByPassControlli = True Then ' .ConsegnaAssociata.HaDocumentiFiscali = False Or _ByPassControlli = True Then
                    If MessageBox.Show("Confermi la modifica degli importi di questo ordine?", "Modifica importi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Dim ModificareConsegna As Boolean = False
                        Dim OkCorr As Boolean = True
                        If _Ord.IdCorriere <> cmbCorriere.SelectedValue Then
                            ModificareConsegna = True
                            If MessageBox.Show("ATTENZIONE! Hai modificato il corriere di questo ordine, verrà modificata/spostata anche la sua consegna. Confermi la modifica?", "Modifica importi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                OkCorr = False
                            End If
                        End If

                        If OkCorr Then
                            _Ord.Ricarico = txtRicarico.Text
                            _Ord.Sconto = txtSconto.Text
                            _Ord.Iva = lblIva.Text
                            _Ord.Prezzo = _Ord.TotaleForn + _Ord.Ricarico - _Ord.Sconto + _Ord.Iva
                            _Ord.IdCorriere = cmbCorriere.SelectedValue
                            _Ord.Preventivo = IIf(chkPreventivo.Checked, enSiNo.Si, enSiNo.No)
                            _Ord.Annotazioni = txtNote.Text
                            _Ord.LastUpdate = enSiNo.Si
                            _Ord.Stato = cmbStato.SelectedValue
                            _Ord.UsaNomeLavoroInFattura = IIf(chkUsaNomeLavoro.Checked, enSiNo.Si, enSiNo.No)
                            _Ord.MantieniCampione = IIf(chkMantieniCampione.Checked, enSiNo.Si, enSiNo.No)
                            _Ord.NomeLavoro = txtNomeLavoro.Text

                            Using Tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
                                Try
                                    'qui per ogni ordine contenuto nelal consegna faccio il giro che li sposta e li aggancia o ricrea la consegna
                                    Dim NuovaConsegna As ConsegnaProgrammata = Nothing
                                    Using mgr As New ConsegneProgrammateDAO

                                        Tb.TransactionBegin()
                                        Dim IdOldCons As Integer = 0

                                        Dim OldCons As ConsegnaProgrammata = Nothing

                                        If Not _Ord.ConsegnaAssociata Is Nothing Then
                                            OldCons = _Ord.ConsegnaAssociata.Clone
                                            IdOldCons = OldCons.IdCons

                                        End If

                                        _Ord.Save()

                                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, _Ord.IdOrd, "UTILIZZATA LA FUNZIONE MODIFICA IMPORTI (Operatore " & PostazioneCorrente.UtenteConnesso.IdUt & ")")

                                        _Ris = enSiNo.Si
                                        If IdOldCons Then
                                            If ModificareConsegna Then
                                                'TOLTO IL 08/04/2015
                                                'mgr.EliminaOrdineDaConsegna(IdOldCons, _Ord.IdOrd)
                                                NuovaConsegna = mgr.RegistraConsegnaOrdineSuGiorno(_Ord.IdOrd,
                                                                                                   cmbCorriere.SelectedValue,
                                                                                                   OldCons.Giorno,
                                                                                                   _Ord.IdRub,
                                                                                                   OldCons.MatPom,
                                                                                                   OldCons.IdIndirizzo)
                                                'TOLTO IL 08/04/2015
                                                'mgr.EliminaConsegnaSeVuota(IdOldCons)
                                            End If
                                        End If
                                        Tb.TransactionCommit()

                                    End Using
                                    Close()
                                Catch ex As Exception
                                    Tb.TransactionRollBack()
                                    MessageBox.Show("Si è verificato un errore nella modifica della consegna: " & ex.Message)
                                End Try

                            End Using
                        End If
                    End If
                Else
                    MessageBox.Show("L' ordine è inserito in un documento fiscale")
                End If
            Else
                MessageBox.Show("L' ordine è associato a una consegna con pagamento")
            End If
        End If

    End Sub

    Private Sub txtTotDaRicavare_TextChanged(sender As Object, e As EventArgs) Handles txtTotDaRicavare.TextChanged

        Dim ValoreScelto As Decimal = txtTotDaRicavare.Value
        Try
            If ValoreScelto >= 0 Then
                If ValoreScelto > _Ord.TotaleForn Then
                    txtRicarico.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((ValoreScelto - _Ord.TotaleForn), 2)
                    txtSconto.Text = 0
                ElseIf ValoreScelto < _Ord.TotaleForn Then
                    txtSconto.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((_Ord.TotaleForn - ValoreScelto), 2)
                    txtRicarico.Text = 0
                ElseIf ValoreScelto = _Ord.TotaleForn Then
                    txtSconto.Text = 0
                    txtRicarico.Text = 0
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lnkReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkReset.LinkClicked
        ResetTxtTotDaRicavare()
        txtSconto.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(0)
        txtRicarico.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(0)
    End Sub

    Private Sub txtTotDaRicavare_LostFocus(sender As Object, e As EventArgs) Handles txtTotDaRicavare.LostFocus
        'If txtTotDaRicavare.Value = 0 Then ResetTxtTotDaRicavare()
    End Sub

    Private Sub ResetTxtTotDaRicavare()
        'MARCO: IL RESET DEVE RIPORTARE IL CAMPO AL VALORE DELL'IMPONIBILE (INCLUSI QUINDI EVENTUALI RICARICHI O SCONTI GIA' PRESENTI)
        'O A QUELLO DELLA FORNITURA, AZZERANDO SCONTO E RICARICO? CHIEDERE AD ANTONIO
        txtTotDaRicavare.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_Ord.TotaleImponibile)
    End Sub

    Private Sub txtNomeLavoro_TextChanged(sender As Object, e As EventArgs) Handles txtNomeLavoro.TextChanged
        If sender.focused Then
            If txtNomeLavoro.Text.Trim.Length Then
                chkUsaNomeLavoro.Checked = True
            Else
                chkUsaNomeLavoro.Checked = False
            End If
        End If

    End Sub
End Class