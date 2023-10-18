Imports FormerDALSql
Imports FormerLib.FormerEnum
Friend Class frmMarketingEffettivo
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _IdMarkProgr As Integer = 0
    Private _IdRub As Integer = 0
    Private _IdMarketing As Integer = 0

    Friend Function Carica(Optional ByVal IdMarkProgr As Integer = 0, Optional ByVal IdRub As Integer = 0, Optional ByVal IdMarketing As Integer = 0) As Integer

        _IdMarkProgr = IdMarkProgr
        _IdRub = IdRub
        _IdMarketing = IdMarketing
        CaricaCombo()

        If _IdMarkProgr Then

            Dim x As New CampagnaMarketing
            x.Read(_IdMarkProgr)
            cmbAzione.SelectedIndex = x.TipoAzione - 1
            MgrControl.SelectIndexCombo(cmbGruppo, x.IdGruppo)
            dtQuando.Value = x.Quando
            txtNote.Text = x.Annotazioni

        Else
            MgrControl.SelectIndexCombo(cmbGruppo, IdRub)
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using x As New VociRubricaDAO

            cmbGruppo.DisplayMember = "Nominativo"
            cmbGruppo.ValueMember = "IdRub"
            cmbGruppo.DataSource = x.ListaCombo(enTipoRubrica.Cliente, False)
        End Using
        cmbAzione.SelectedIndex = 0

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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio dell'azione di marketing?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim x As New AzioneMarketing

            x.Read(_IdMarkProgr)
            x.IdRub = cmbGruppo.SelectedValue
            x.Quando = dtQuando.Value
            x.TipoAzione = cmbAzione.SelectedIndex + 1
            x.Annotazioni = txtNote.Text
            x.IdMarketing = _IdMarketing
            x.Save()

            _Ris = 1
            Close()

            If cmbAzione.SelectedIndex + 1 = enTipoAzMarketing.InvioMail Then

                'qui devo inviargli direttamente alla form mail
                Dim xMk As New frmMarketingEmail
                xMk.Carica(, cmbGruppo.SelectedValue, _IdMarketing)

            End If

        End If

    End Sub
End Class