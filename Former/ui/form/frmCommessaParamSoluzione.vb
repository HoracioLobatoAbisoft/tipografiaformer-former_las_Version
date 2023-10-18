Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports Telerik.WinControls.UI

Friend Class frmCommessaParamSoluzione
    'Inherits baseFormInternaFixed
    Private _Ris As ParametriCreazioneSoluzione = Nothing

    Private Sub CaricaCombo()

        Using M As New MacchinariDAO
            cmbMacchinari.ValueMember = "IdMacchinario"
            cmbMacchinari.DisplayMember = "Descrizione"
            Dim so As New LUNA.LunaSearchOption With {.AddEmptyItem = True, .OrderBy = "Descrizione"}
            cmbMacchinari.DataSource = M.FindAll(so, New LUNA.LunaSearchParameter(LFM.Macchinario.Tipo, enTipoMacchinario.Produzione))
        End Using

    End Sub

    Private _L As List(Of OrdineRicerca) = Nothing
    Private _LFormatiProd As List(Of FormatoProdotto) = Nothing

    Friend Function Carica(L As List(Of OrdineRicerca)) As ParametriCreazioneSoluzione
        _L = L

        _LFormatiProd = New List(Of FormatoProdotto)

        For Each O In _L
            If _LFormatiProd.FindAll(Function(x) x.IdFormProd = O.ListinoBase.IdFormProd).Count = 0 Then
                _LFormatiProd.Add(O.ListinoBase.FormatoProdotto)
            End If
        Next

        If FormerDebug.DebugAttivo Then

            grpDebug.Visible = True

        End If

        CaricaCombo()

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

    Private Sub btnCalcola_Click(sender As Object, e As EventArgs) Handles btnCalcola.Click

        _Ris = New ParametriCreazioneSoluzione

        If chkCreazioneAutomatica.Checked Then
            _Ris.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreBeta
            _Ris.CreazioneAutomaticaCommesse = True
            _Ris.MaxDuplicazioneSingoloOrdine = 10
            _Ris.SoloSoluzioniOttimali = True
            _Ris.UtilizzaSoloMacchinarioDefault = True
            _Ris.PermettiQtaMinoreOrdini = False
        Else
            If rdoMacchinarioSpecifico.Checked Then
                _Ris.IdMacchinario = cmbMacchinari.SelectedValue
                _Ris.IdModelloCommessa = cmbModello.SelectedValue
            End If
            '_Ris.TieniContoRating = True '.Checked
            '_Ris.TieniContoLavorazioniEsclusive = True 'chkLavEscl.Checked
            _Ris.MaxDuplicazioneSingoloOrdine = txtMaxDuplicaz.Value
            'SVILUPPO
            _Ris.NonMostrareTutteleCombinazioni = Not chkEscludiDoppioni.Checked
            '_Ris.MixaIDueMotori = False 'chkMixaIDueMotori.Checked 'DEPRECATO
            '_Ris.ProvaEscludereOrdiniPerRaddoppiareSpazi = True
            '_Ris.RielaboraSolitariInCommesseSimili = True

            _Ris.PermettiQtaMinoreOrdini = False

            If rdoMotoreStabile.Checked Then
                _Ris.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreStabile
            ElseIf rdoMotoreBeta.Checked Then
                _Ris.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreBeta
            End If

            _Ris.UtilizzaSoloFormatiCarta = chkSoloFormatoCarta.Checked
            _Ris.UtilizzaSoloMacchinarioDefault = rdoMacchDefault.Checked

            _Ris.SoloSoluzioniOttimali = rdoOnlyOptimal.Checked
            '_Ris.ProvaAChiudereTutteLeCommesse = rdoCloseAll.Checked
            _Ris.AccorpaCommesse = chkAccorpaCommesse.Checked

            _Ris.SelezionaMacchinarioInBaseACostoDiProduzione = chkScegliMacchinarioInBaseAcosti.Checked
            _Ris.UtilizzaAncheFormatiCarta = chkFormatiCarta.Checked
        End If

        Close()

    End Sub

    Private Sub CaricaModelliCommessa()

        Dim IdMacchinario As Integer = cmbMacchinari.SelectedValue

        cmbModello.Items.Clear()

        Dim descriptionItem As New DescriptionTextListDataItem
        descriptionItem.Text = "Selezionare un modello commessa"
        descriptionItem.Image = New Bitmap(My.Resources.no_image, 80, 80)
        descriptionItem.DescriptionText = ""
        descriptionItem.Value = 0
        cmbModello.Items.Add(descriptionItem)
        Dim I As Integer = 0
        If IdMacchinario Then
            Cursor.Current = Cursors.WaitCursor
            Using Mgr As New ModelliCommessaDAO
                Dim l As List(Of ModelloCommessa) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ModelloCommessa.IdMacchinarioDef, IdMacchinario),
                                                                New LUNA.LunaSearchParameter(LFM.ModelloCommessa.FromGanging, enSiNo.No))

                For Each M As ModelloCommessa In l

                    Dim Aggiungi As Boolean = True

                    If M.FormatiProdotto.Count = _LFormatiProd.Count Then
                        For Each Fp As FormatoProdotto In _LFormatiProd
                            If M.FormatiProdotto.FindAll(Function(x) x.IdFormProd = Fp.IdFormProd).Count = 0 Then
                                Aggiungi = False
                                Exit For
                            End If
                        Next
                    Else
                        Aggiungi = False
                    End If

                    If Aggiungi Then
                        descriptionItem = New DescriptionTextListDataItem
                        descriptionItem.Text = M.Nome
                        descriptionItem.Image = M.ImageAnteprimaLista
                        descriptionItem.DescriptionText = M.Description
                        descriptionItem.Value = M.IdModello
                        cmbModello.Items.Add(descriptionItem)
                    End If

                Next

            End Using
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub cmbMacchinari_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMacchinari.SelectedIndexChanged
        CaricaModelliCommessa()
    End Sub

    Private Sub cmbMacchinari_Click(sender As Object, e As EventArgs) Handles cmbMacchinari.Click
        rdoMacchinarioSpecifico.Checked = True
    End Sub

    Private Sub rdoCloseAll_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCloseAll.CheckedChanged
        If rdoCloseAll.Checked Then chkEscludiDoppioni.Checked = True
    End Sub

    Private Sub rdoOnlyOptimal_CheckedChanged(sender As Object, e As EventArgs) Handles rdoOnlyOptimal.CheckedChanged
        If rdoOnlyOptimal.Checked Then chkEscludiDoppioni.Checked = False
    End Sub
End Class