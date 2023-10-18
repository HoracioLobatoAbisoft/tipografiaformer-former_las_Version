Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Friend Class frmCommessaTipo
    'Inherits baseFormInterna
    Private _Ris As Integer
    Private _TipoComSel As New TipoCommessa
    Private _IdTIpo As Integer

    Friend Function Carica(Optional ByVal IdTipoCom As Integer = 0) As Integer

        If IdTipoCom Then

            _TipoComSel.Read(IdTipoCom)

        End If

        CaricaCombo()

        If _TipoComSel.IdTipoCom Then
            'ricarico il tipo commessa

            txtDescrizione.Text = _TipoComSel.Descrizione
            SelectIndexCombo(cmbTipoCom, _TipoComSel.TipoCom)
            SelectIndexCombo(cmbRisorsa, _TipoComSel.IdRis)
            SelectIndexCombo(cmbImpianti, _TipoComSel.IdImpianto)
            SelectIndexCombo(cmbFormato, _TipoComSel.IdFormato)
            cmbMaccStampa.Text = _TipoComSel.MacchinaStampa
            chkFronteRetro.Checked = _TipoComSel.FronteRetro
            txtPremioStampa.Text = _TipoComSel.PremioStampa
            txtTempoRif.Text = _TipoComSel.TempoRif
            txtQuantita.Text = _TipoComSel.Quantita
            txtNumSpazi.Text = _TipoComSel.NumSpazi
            SelectIndexCombo(cmbCatMod, _TipoComSel.IdCatModelli)

        End If

        UcLavorazioni.CaricaxCom(_TipoComSel.IdTipoCom)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using MaccStampa As New cMaccStampa

            cmbMaccStampa.DataSource = MaccStampa.Lista
            cmbMaccStampa.ValueMember = "MacchinaStampa"
            cmbMaccStampa.DisplayMember = "MacchinaStampa"
        End Using

        Using FormatoCommessa As New cFormatoCommessa

            cmbFormato.DataSource = FormatoCommessa.Lista
            cmbFormato.ValueMember = "IdFormato"
            cmbFormato.DisplayMember = "Formato"
        End Using

        Using Risorse As New cRisorseColl
            cmbImpianti.DataSource = Risorse.ListaComboOffSet(True)
            cmbImpianti.ValueMember = "IdRis"
            cmbImpianti.DisplayMember = "Descrizione"
        End Using

        Dim TipoProd As New cTipoProdCom(False)
        cmbTipoCom.DataSource = TipoProd
        cmbTipoCom.ValueMember = "Id"
        cmbTipoCom.DisplayMember = "Descrizione"

        Using Mgr As New CatModelliDAO
            cmbCatMod.DataSource = Mgr.GetAll("CatModello")
            cmbCatMod.ValueMember = "IdCatModello"
            cmbCatMod.DisplayMember = "CatModello"
        End Using

        CaricaRis()

    End Sub

    Private Sub CaricaRis()
        If cmbTipoCom.SelectedIndex <> -1 Then
            Using Risorse As New cRisorseColl

                cmbRisorsa.DataSource = Risorse.ListaCombo(cmbTipoCom.SelectedItem.Id)
                cmbRisorsa.ValueMember = "IdRis"
                cmbRisorsa.DisplayMember = "Descrizione"
            End Using
        End If
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

    Private Sub cmbTipoCom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoCom.SelectedIndexChanged
        CaricaRis()
        MostraControlli(False)
        If cmbTipoCom.SelectedIndex <> -1 Then

            Dim x As cEnum = cmbTipoCom.SelectedItem
            If x.Id = enTipoProdCom.StampaOffSet Then
                MostraControlli(True)
            End If

        End If

    End Sub

    Private Sub MostraControlli(ByVal Val As Boolean)

        lblMaccStampa.Visible = Val
        cmbMaccStampa.Visible = Val
        lblFormato.Visible = Val
        cmbFormato.Visible = Val
        lblImpianti.Visible = Val
        cmbImpianti.Visible = Val
        chkFronteRetro.Visible = Val

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _TipoComSel.Descrizione = txtDescrizione.Text
            _TipoComSel.TipoCom = cmbTipoCom.SelectedItem.id
            _TipoComSel.IdRis = cmbRisorsa.SelectedValue
            _TipoComSel.IdImpianto = cmbImpianti.SelectedValue
            _TipoComSel.IdFormato = cmbFormato.SelectedValue
            _TipoComSel.MacchinaStampa = cmbMaccStampa.Text
            _TipoComSel.FronteRetro = chkFronteRetro.Checked
            _TipoComSel.PremioStampa = txtPremioStampa.Text
            _TipoComSel.TempoRif = txtTempoRif.Text
            _TipoComSel.Quantita = txtQuantita.Text
            _TipoComSel.NumSpazi = txtNumSpazi.Text
            _TipoComSel.IdCatModelli = cmbCatMod.SelectedValue

            If _TipoComSel.IsValid Then
                Dim IdIns As Integer
                IdIns = _TipoComSel.Save()
                Using tc As New TipoCommesseDAO
                    tc.SalvaLavorazioni(_TipoComSel, UcLavorazioni.ListaIdSelezionati)
                End Using
                _Ris = 1
                Close()
            Else
                MessageBox.Show("Il campo Descrizione è obbligatorio! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub

    Private Sub txtPremioStampa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPremioStampa.KeyPress
        ControlloNumerico(sender, e, False)
    End Sub

    Private Sub txtTempoRif_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTempoRif.KeyPress, txtNumSpazi.KeyPress, txtQuantita.KeyPress
        ControlloNumerico(sender, e, True)
    End Sub

End Class