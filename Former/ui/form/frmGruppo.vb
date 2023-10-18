Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmGruppo
    'Inherits baseFormInternaRedim

    Private _Ris As Integer
    Dim _IdGruppo As Integer = 0

    Friend Function Carica(Optional ByVal IdGruppo As Integer = 0) As Integer

        _IdGruppo = IdGruppo

        CaricaCombo()

        If _IdGruppo Then

            Dim c As New Gruppo
            c.Read(_IdGruppo)

            txtGruppo.Text = c.Nome

            If c.InseritiDa Then
                chkInseritiDa.Checked = True
                MgrControl.SelectIndexCombo(cmbInseritiDa, c.InseritiDa)
            End If

            chkOrigine.Checked = True
            MgrControl.SelectIndexCombo(cmbOrigine, c.TipoOrigine)

            If c.CategoriaMarketing Then
                chkCatMark.Checked = True
                MgrControl.SelectIndexCombo(cmbCatMark, c.CategoriaMarketing)
            End If

            If c.NonHannoMaiSpeso Then
                chkNonHannoMaiSpeso.Checked = True
            End If

            If c.SoloRegistratiDalSito Then
                chkSoloDalSito.Checked = True
            End If

            If c.RagSoc.Length Then
                chkRagSoc.Checked = True
                txtRagSoc.Text = c.RagSoc
            End If

            If c.Citta.Length Then
                txtCitta.Text = c.Citta
                chkCitta.Checked = True
            End If

            If c.Cap.Length Then
                txtCAP.Text = c.Cap
                chkCap.Checked = True
            End If

            If c.Tipo Then
                chkTipo.Checked = True
                MgrControl.SelectIndexComboEnum(cmbTipo, c.Tipo)
            End If

            If c.HannoAcqAlmenoUn Then
                MgrControl.SelectIndexCombo(cmbCatProdAcq, c.HannoAcqAlmenoUn)
                chkHannoAcquistatoUn.Checked = True
            End If

            If c.NonHannoMaiAcqUn Then
                MgrControl.SelectIndexCombo(cmbCatProdNonAcq, c.NonHannoMaiAcqUn)
                chkNonHannoAcquistatoUn.Checked = True
            End If

            If c.SpesaNelPeriodoMinoreDi Then
                MgrControl.SelectIndexComboEnum(cmbPeriodoSpesa, c.SpesaNelPeriodo)
                chkSpesaMinDi.Checked = True
                txtSpesaMinDi.Text = c.SpesaNelPeriodoMinoreDi
            End If

            If c.SpesaNelPeriodoMaggioreDi Then
                MgrControl.SelectIndexComboEnum(cmbPeriodoSpesa, c.SpesaNelPeriodo)
                chkSpesaMaxDi.Checked = True
                txtSpesaMaxDi.Text = c.SpesaNelPeriodoMaggioreDi
            End If

            If c.NonHannoSpesoDal <> Date.MinValue Then
                chkNonHannoSpesoDal.Checked = True
                dtNonHannoDal.Value = c.NonHannoSpesoDal
            End If

            If c.NonHannoSpesoAl <> Date.MinValue Then
                chkNonHannoSpesoDal.Checked = True
                dtNonHannoAl.Value = c.NonHannoSpesoAl
            End If

            If c.HannoSpesoDal <> Date.MinValue Then
                chkHannoSpesoDal.Checked = True
                dtHannoDal.Value = c.HannoSpesoDal
            End If

            If c.HannoSpesoAl <> Date.MinValue Then
                chkHannoSpesoDal.Checked = True
                dtHannoAl.Value = c.HannoSpesoAl
            End If

            If c.LimiteMassimoSuperato = enSiNo.Si Then chkLimiteMassimo.Checked = True

            If c.IdCorrierePredefinito Then
                chkCorrierePred.Checked = True
                MgrControl.SelectIndexCombo(cmbCorriere, c.IdCorrierePredefinito)
            End If

            If c.SoloRegistratiDalSito = enSiNo.Si Then chkSoloDalSito.Checked = True

            If c.RegistratiDal <> Date.MinValue Then
                chkRegistratiDal.Checked = True
                dtRegistratiDal.Value = c.RegistratiDal
            End If

            If c.DocumentiInScadenzaDal <> Date.MinValue Then
                chkPagamSosp.Checked = True
                dtScadDal.Value = c.DocumentiInScadenzaDal
            End If

            If c.DocumentiInScadenzaAl <> Date.MinValue Then
                chkPagamSosp.Checked = True
                dtScadAl.Value = c.DocumentiInScadenzaAl
            End If

            If c.tag.Trim.Length Then
                chkTag.Checked = True
                txtTag.Text = c.tag.Trim
            End If

            c = Nothing

        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using Corriere As New CorrieriDAO

            cmbCorriere.DataSource = Corriere.GetAll(LFM.Corriere.Descrizione, False)
            cmbCorriere.ValueMember = "IdCorriere"
            cmbCorriere.DisplayMember = "Descrizione"

        End Using

        Dim LTipi As New List(Of cEnum)
        Dim vTipo As New cEnum
        vTipo.Id = enTipoRubrica.Tutto
        vTipo.Descrizione = "Tutti"
        LTipi.Add(vTipo)

        vTipo = New cEnum
        vTipo.Id = enTipoRubrica.Cliente
        vTipo.Descrizione = "Cliente"
        LTipi.Add(vTipo)

        'vTipo = New cEnum
        'vTipo.Id = enTipoRubrica.Fornitore
        'vTipo.Descrizione = "Fornitore"
        'LTipi.Add(vTipo)

        vTipo = New cEnum
        vTipo.Id = enTipoRubrica.Rivenditore
        vTipo.Descrizione = "Rivenditore"
        LTipi.Add(vTipo)

        'vTipo = New cEnum
        'vTipo.Id = enTipoRubrica.Agente
        'vTipo.Descrizione = "Agente"
        'LTipi.Add(vTipo)

        cmbTipo.DataSource = LTipi
        cmbTipo.DisplayMember = "Descrizione"
        cmbTipo.ValueMember = "Id"

        Dim L As New List(Of cEnum)

        Dim voce As New cEnum
        voce.Id = enPeriodoRiferimento.UnMese
        voce.Descrizione = FormerEnumHelper.PeriodoRiferimentoStr(enPeriodoRiferimento.UnMese)
        L.Add(voce)

        voce = New cEnum
        voce.Id = enPeriodoRiferimento.TreMesi
        voce.Descrizione = FormerEnumHelper.PeriodoRiferimentoStr(enPeriodoRiferimento.TreMesi)
        L.Add(voce)

        voce = New cEnum
        voce.Id = enPeriodoRiferimento.SeiMesi
        voce.Descrizione = FormerEnumHelper.PeriodoRiferimentoStr(enPeriodoRiferimento.SeiMesi)
        L.Add(voce)

        voce = New cEnum
        voce.Id = enPeriodoRiferimento.UnAnno
        voce.Descrizione = FormerEnumHelper.PeriodoRiferimentoStr(enPeriodoRiferimento.UnAnno)
        L.Add(voce)

        cmbPeriodoSpesa.DataSource = L
        cmbPeriodoSpesa.DisplayMember = "Descrizione"
        cmbPeriodoSpesa.ValueMember = "Id"
        cmbPeriodoSpesa.SelectedIndex = 0

        'Using prodcol As New CatProdDAO
        '    Dim dt1 As List(Of CatProd), dt2 As List(Of CatProd)
        '    dt1 = prodcol.GetAll("Descrizione", True)
        '    dt2 = dt1.ToList

        '    cmbCatProdAcq.ValueMember = "IdCatProd"
        '    cmbCatProdAcq.DisplayMember = "DescrizioneConPadre"

        '    cmbCatProdAcq.DataSource = dt1

        '    cmbCatProdNonAcq.ValueMember = "IdCatProd"
        '    cmbCatProdNonAcq.DisplayMember = "DescrizioneConPadre"

        '    cmbCatProdNonAcq.DataSource = dt2


        'End Using

        Using mgr As New PreventivazioniDAO
            Dim lP As List(Of Preventivazione) = mgr.GetAll(LFM.Preventivazione.Descrizione)
            cmbCatProdAcq.ValueMember = "IdPrev"
            cmbCatProdAcq.DisplayMember = "Descrizione"
            cmbCatProdAcq.DataSource = lP

            Dim lP2 As New List(Of Preventivazione)
            lP2.AddRange(lP)
            cmbCatProdNonAcq.ValueMember = "IdPrev"
            cmbCatProdNonAcq.DisplayMember = "Descrizione"
            cmbCatProdNonAcq.DataSource = lP2
        End Using

        dtScadAl.Value = Now.Date.AddDays(30)
        dtScadDal.Value = Now.Date

        Dim L2 As New List(Of cEnum)

        L2.AddRange(L)

        cmbInseritiDa.DataSource = L2
        cmbInseritiDa.DisplayMember = "Descrizione"
        cmbInseritiDa.ValueMember = "Id"

        Dim LOrig As New List(Of cEnum)
        voce = New cEnum
        voce.Id = enOrigineContatto.Tutto
        voce.Descrizione = "Tutto"
        LOrig.Add(voce)

        voce = New cEnum
        voce.Id = enOrigineContatto.Rubrica
        voce.Descrizione = "Rubrica"
        LOrig.Add(voce)

        voce = New cEnum
        voce.Id = enOrigineContatto.Marketing
        voce.Descrizione = "Marketing"
        LOrig.Add(voce)

        cmbOrigine.DataSource = LOrig
        cmbOrigine.DisplayMember = "Descrizione"
        cmbOrigine.ValueMember = "Id"

        Dim lC As List(Of CatRubrMarketing)
        Using mgr As New CatRubrMarketingDAO
            lC = mgr.GetAll(LFM.CatRubrMarketing.Descrizione, True)
        End Using

        cmbCatMark.DataSource = lC
        cmbCatMark.DisplayMember = "Descrizione"
        cmbCatMark.ValueMember = "IdCatRubr"

    End Sub

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

    Private Sub RiempiGruppoDaForm(ByRef G As Gruppo)
        G.Nome = txtGruppo.Text

        'PRINCIPALE

        If chkRagSoc.Checked Then
            G.RagSoc = txtRagSoc.Text
        Else
            G.RagSoc = String.Empty
        End If

        If chkCatMark.Checked Then
            G.CategoriaMarketing = cmbCatMark.SelectedValue
        Else
            G.CategoriaMarketing = 0
        End If

        If chkTipo.Checked Then
            G.Tipo = cmbTipo.SelectedValue
        Else
            G.Tipo = 0
        End If

        If chkCorrierePred.Checked Then
            G.IdCorrierePredefinito = cmbCorriere.SelectedValue
        Else
            G.IdCorrierePredefinito = 0
        End If

        'If chkInseritiDa.Checked Then
        '    G.InseritiDa = cmbInseritiDa.SelectedValue
        'End If

        If chkOrigine.Checked Then
            G.TipoOrigine = cmbOrigine.SelectedValue
        Else
            G.TipoOrigine = enOrigineContatto.Tutto
        End If

        If chkSoloDalSito.Checked Then
            G.SoloRegistratiDalSito = enSiNo.Si
        Else
            G.SoloRegistratiDalSito = enSiNo.No
        End If

        If chkCitta.Checked Then
            G.Citta = txtCitta.Text
        Else
            G.Citta = String.Empty
        End If

        If chkCap.Checked Then
            G.Cap = txtCAP.Text
        Else
            G.Cap = String.Empty
        End If

        If chkInseritiDa.Checked Then
            G.InseritiDa = cmbInseritiDa.SelectedValue
        Else
            G.InseritiDa = 0
        End If

        'PRODOTTI
        If chkHannoAcquistatoUn.Checked Then
            G.HannoAcqAlmenoUn = cmbCatProdAcq.SelectedValue
        Else
            G.HannoAcqAlmenoUn = 0
        End If
        If chkNonHannoAcquistatoUn.Checked Then
            G.NonHannoMaiAcqUn = cmbCatProdNonAcq.SelectedValue
        Else
            G.NonHannoMaiAcqUn = 0
        End If

        'SPESA COMPLESSIVA
        If chkSpesaMinDi.Checked Or chkSpesaMaxDi.Checked Then G.SpesaNelPeriodo = cmbPeriodoSpesa.SelectedValue

        If chkSpesaMinDi.Checked Then
            G.SpesaNelPeriodoMinoreDi = txtSpesaMinDi.Text
        Else
            G.SpesaNelPeriodoMinoreDi = 0
        End If

        If chkSpesaMaxDi.Checked Then
            G.SpesaNelPeriodoMaggioreDi = txtSpesaMaxDi.Text
        Else
            G.SpesaNelPeriodoMaggioreDi = 0
        End If

        If chkNonHannoSpesoDal.Checked Then
            G.NonHannoSpesoDal = dtNonHannoDal.Value
            G.NonHannoSpesoAl = dtNonHannoAl.Value
        Else
            G.NonHannoSpesoDal = Date.MinValue
            G.NonHannoSpesoAl = Date.MinValue
        End If

        If chkHannoSpesoDal.Checked Then
            G.HannoSpesoDal = dtHannoDal.Value
            G.HannoSpesoAl = dtHannoAl.Value
        Else
            G.HannoSpesoDal = Date.MinValue
            G.HannoSpesoAl = Date.MinValue
        End If

        If chkRegistratiDal.Checked Then
            G.RegistratiDal = dtRegistratiDal.Value
        Else
            G.RegistratiDal = Date.MinValue
        End If

        If chkNonHannoMaiSpeso.Checked Then
            G.NonHannoMaiSpeso = enSiNo.Si
        Else
            G.NonHannoMaiSpeso = enSiNo.No
        End If

        If chkTag.Checked Then
            G.tag = txtTag.Text
        Else
            G.tag = String.Empty
        End If

    End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked

        Cursor.Current = Cursors.WaitCursor
        'qui effettuo la ricerca in base ai parametri selezionati

        Dim G As New Gruppo

        Dim l As List(Of IVoceRubricaG)
        Using mgr As New VociRubGDAO

            l = mgr.GetAllVoceRubG(G)

            RiempiGruppoDaForm(G)

            l = mgr.ApplicaFiltro(l, G)

        End Using

        'Using x As New VociRubricaDAO
        '    Dim dt As DataTable = Nothing
        '    Try

        '        If FormerDebug.DebugAttivo Then
        '            dt = x.ListaGruppo(IIf(chkRagSoc.Checked, txtRagSoc.Text, ""),
        '                           IIf(chkCitta.Checked, txtCitta.Text, ""),
        '                            IIf(chkCap.Checked, txtCAP.Text, ""), 0,
        '                            IIf(chkHannoAcquistatoUn.Checked, cmbCatProdAcq.SelectedValue, 0),
        '                            IIf(chkNonHannoAcquistatoUn.Checked, cmbCatProdNonAcq.SelectedValue, 0),
        '                            IIf(chkCorrierePred.Checked, cmbCorriere.SelectedValue, 0),
        '                            chkLimiteMassimo.Checked,
        '                            chkPagamSosp.Checked,
        '                            dtScadDal.Value,
        '                            dtScadAl.Value,
        '                            IIf(chkSpesaMinDi.Checked, txtSpesaMinDi.Text, 0),
        '                            IIf(chkSpesaMaxDi.Checked, txtSpesaMaxDi.Text, 0),
        '                            cmbPeriodoSpesa.SelectedIndex,
        '                            IIf(chkHannoSpesoDal.Checked, dtHannoDal.Value, Nothing),
        '                            dtHannoAl.Value,
        '                            IIf(chkNonHannoSpesoDal.Checked, dtNonHannoDal.Value, Nothing),
        '                            dtNonHannoAl.Value,
        '                            IIf(chkTipo.Checked, cmbTipo.SelectedValue, 0),
        '                            IIf(chkRegistratiDal.Checked, dtRegistratiDal.Value, Nothing),
        '                            chkSoloDalSito.Checked,
        '                            IIf(chkTag.Checked, txtTag.Text, ""))
        '            If dt.Rows.Count <> l.Count Then
        '                MessageBox.Show("Attenzione diversita nel risultato: Vecchio " & dt.Rows.Count & " Nuovo " & l.Count)
        '            End If

        '        Else
        '            dt = New DataTable
        '        End If

        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '    End Try


        'End Using
        lblRis.Text = "Risultati: " & l.Count
        DgDisp.AutoGenerateColumns = False
        DgDisp.DataSource = l
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub txtCAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCAP.KeyPress, txtSpesaMaxDi.KeyPress, txtSpesaMinDi.KeyPress
        MgrControl.ControlloNumerico(sender, e, True, False)
    End Sub

    Private Sub chkRagSoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRagSoc.CheckedChanged, chkCap.CheckedChanged, chkCitta.CheckedChanged, chkCorrierePred.CheckedChanged, chkHannoAcquistatoUn.CheckedChanged, chkHannoSpesoDal.CheckedChanged, chkLimiteMassimo.CheckedChanged, chkNonHannoAcquistatoUn.CheckedChanged, chkNonHannoSpesoDal.CheckedChanged, chkPagamSosp.CheckedChanged, chkRagSoc.CheckedChanged, chkSpesaMaxDi.CheckedChanged, chkSpesaMinDi.CheckedChanged, chkRegistratiDal.CheckedChanged, chkSoloDalSito.CheckedChanged, chkTipo.CheckedChanged, chkTag.CheckedChanged, chkOrigine.CheckedChanged, chkCatMark.CheckedChanged, chkInseritiDa.CheckedChanged, chkNonHannoMaiSpeso.CheckedChanged
        If sender.checked Then
            sender.backcolor = Color.Green
            sender.forecolor = Color.White
        Else
            sender.backcolor = Color.White
            sender.forecolor = Color.Black
        End If
        conteggiaFiltri
    End Sub

    Private Sub ConteggiaFiltri()
        Dim Counter As Integer = 0
        For Each SingTab In tabCerca.TabPages
            For Each C As Control In SingTab.Controls
                If TypeOf (C) Is CheckBox Then
                    Dim Chk As CheckBox = DirectCast(C, CheckBox)
                    If Chk.Checked Then
                        Counter += 1
                    End If
                End If
            Next
        Next

        lblFiltriImpostati.Text = "Filtri impostati: " & Counter
    End Sub

    Private Function SalvaGruppo() As Integer

        Dim Ris As Integer = 0

        If txtGruppo.Text.Length = 0 Then

            Ris = 1
        Else
            Using X As New Gruppo
                If _IdGruppo Then X.Read(_IdGruppo)
                RiempiGruppoDaForm(X)
                X.Save()
            End Using

            'Dim x As New Gruppo


            'x.Nome = txtGruppo.Text
            'x.RagSoc = IIf(chkRagSoc.Checked, txtRagSoc.Text, String.Empty)
            'x.Citta = IIf(chkCitta.Checked, txtCitta.Text, String.Empty)
            'x.Cap = IIf(chkCap.Checked, txtCAP.Text, String.Empty)
            'x.Tipo = IIf(chkTipo.Checked, cmbTipo.SelectedValue, 0)
            'x.HannoAcqAlmenoUn = IIf(chkHannoAcquistatoUn.Checked, cmbCatProdAcq.SelectedValue, 0)
            'x.NonHannoMaiAcqUn = IIf(chkNonHannoAcquistatoUn.Checked, cmbCatProdNonAcq.SelectedValue, 0)
            'x.SpesaNelPeriodo = cmbPeriodoSpesa.SelectedValue
            'x.SpesaNelPeriodoMinoreDi = IIf(txtSpesaMinDi.Text.Length, txtSpesaMinDi.Text, 0)
            'x.SpesaNelPeriodoMaggioreDi = IIf(txtSpesaMaxDi.Text.Length, txtSpesaMaxDi.Text, 0)
            'x.NonHannoSpesoDal = IIf(chkNonHannoSpesoDal.Checked, dtNonHannoDal.Value, Date.MinValue)
            'x.NonHannoSpesoAl = IIf(chkNonHannoSpesoDal.Checked, dtNonHannoAl.Value, Date.MinValue)
            'x.HannoSpesoDal = IIf(chkHannoSpesoDal.Checked, dtHannoDal.Value, Date.MinValue)
            'x.HannoSpesoAl = IIf(chkHannoSpesoDal.Checked, dtHannoAl.Value, Date.MinValue)
            'x.LimiteMassimoSuperato = IIf(chkLimiteMassimo.Checked, enSiNo.Si, enSiNo.No)
            'x.IdCorrierePredefinito = IIf(chkCorrierePred.Checked, cmbCorriere.SelectedValue, 0)
            'x.SoloRegistratiDalSito = IIf(chkSoloDalSito.Checked, enSiNo.Si, enSiNo.No)
            'x.RegistratiDal = IIf(chkRegistratiDal.Checked, dtRegistratiDal.Value, Date.MinValue)
            'x.DocumentiInScadenzaDal = IIf(chkPagamSosp.Checked, dtScadDal.Value, Date.MinValue)
            'x.DocumentiInScadenzaAl = IIf(chkPagamSosp.Checked, dtScadAl.Value, Date.MinValue)
            'x.tag = txtTag.Text.ToLower

            '_IdGruppo = x.Save()

        End If

        Return Ris

    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If chkOrigine.Checked = False Then
            MessageBox.Show("E' obbligatorio specificare il tipo di origine per questo gruppo: Tutto, Rubrica interna o rubrica di marketing")
        Else
            If MessageBox.Show("Confermi il salvataggio del gruppo?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If SalvaGruppo() = 0 Then
                    _Ris = 1
                    Close()
                Else
                    MessageBox.Show("Errore nel salvataggio del gruppo")
                End If

            End If
        End If

    End Sub

    Private Sub DgDisp_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDisp.CellContentDoubleClick
        'If DgDisp.SelectedRows.Count Then
        '    Dim dr As DataGridViewRow = DgDisp.SelectedRows(0)
        '    Dim idRub As Integer = dr.Cells(0).Value

        '    Sottofondo()
        '    Dim x As New frmVoceRubrica

        '    x.Carica(idRub)
        '    x = Nothing

        '    Sottofondo()

        'End If
    End Sub

    Private Sub btnElencoTag_Click(sender As Object, e As EventArgs) Handles btnElencoTag.Click
        'qui carico tutti i tag disponibili distinti e mostro una form di riepilogo
        Dim Buffer As String = String.Empty

        Using mgr As New VociRubricaDAO
            Dim l As List(Of String) = mgr.GetAllTag

            For Each s As String In l
                Buffer &= s & ControlChars.NewLine
            Next

        End Using

        Sottofondo()
        Using f As New frmTextShow
            f.Carica(Buffer)
        End Using
        Sottofondo()

    End Sub
End Class