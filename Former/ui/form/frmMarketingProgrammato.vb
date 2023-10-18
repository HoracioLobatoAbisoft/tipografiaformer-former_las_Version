Imports FormerDALSql

Friend Class frmMarketingProgrammato
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _IdMarkProgr As Integer = 0

    Friend Function Carica(Optional ByVal IdMarkProgr As Integer = 0) As Integer

        _IdMarkProgr = IdMarkProgr

        CaricaCombo()

        If _IdMarkProgr Then

            Dim x As New CampagnaMarketing
            x.Read(_IdMarkProgr)
            cmbAzione.SelectedIndex = x.TipoAzione - 1
            cmbFrequenza.SelectedIndex = x.Ripetizione
            MgrControl.SelectIndexCombo(cmbGruppo, x.IdGruppo)
            dtQuando.Value = x.Quando

        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using x As New cGruppiColl
            Dim dtListaScelti As DataTable

            dtListaScelti = x.Lista(False)

            cmbGruppo.DisplayMember = "Nome"
            cmbGruppo.ValueMember = "IdGruppo"
            cmbGruppo.DataSource = dtListaScelti

        End Using

        cmbAzione.SelectedIndex = 0
        cmbFrequenza.SelectedIndex = 0


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

            Dim x As New CampagnaMarketing
            x.Read(_IdMarkProgr)
            x.IdGruppo = cmbGruppo.SelectedValue
            x.Quando = dtQuando.Value
            x.Ripetizione = cmbFrequenza.SelectedIndex
            x.TipoAzione = cmbAzione.SelectedIndex + 1

            x.Save()

            _Ris = 1
            Close()

        End If

    End Sub
End Class