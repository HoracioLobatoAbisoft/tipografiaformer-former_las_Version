Imports FormerDALSql

Friend Class frmConsegnaOperatore
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _Giorno As Date

    Private Sub CaricaCombo()

        Using Corriere As New CorrieriDAO
            cmbCorriere.ValueMember = "IdCorriere"
            cmbCorriere.DisplayMember = "Descrizione"
            cmbCorriere.DataSource = Corriere.GetAll(LFM.Corriere.Descrizione, True)
        End Using

        If cmbOperatore.DataSource Is Nothing Then

            Using mgr As New UtentiDAO
                Dim Operatori As List(Of Utente) = mgr.GetAll(LFM.Utente.Login, True)
                cmbOperatore.ValueMember = "IdUt"
                cmbOperatore.DisplayMember = "Login"
                cmbOperatore.DataSource = Operatori
            End Using

        End If

        If cmbZona.DataSource Is Nothing Then
            Using mgr As New ZoneDAO
                Dim Zone As List(Of Zona) = mgr.GetAll(LFM.Zona.Descrizione, True)
                cmbZona.ValueMember = "Id"
                cmbZona.DisplayMember = "Descrizione"
                cmbZona.DataSource = Zone
            End Using
        End If

    End Sub

    Friend Function Carica(ByVal Giorno As Date) As Integer

        _Giorno = Giorno
        CaricaCombo()
        CaricaGiorno()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaGiorno()
        UcConsegneGiorno.IdCorr = cmbCorriere.SelectedValue
        UcConsegneGiorno.Carica(_Giorno, , , cmbZona.SelectedValue, cmbOperatore.SelectedValue)
        lblTipo.Text = _Giorno.ToLongDateString
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

    Private Sub UcConsegneGiorno_OrdineSelezionato() Handles UcConsegneGiorno.OrdineSelezionato
        'carico l'anteprima

        UcOrdineAnteprima.Carica(UcConsegneGiorno.IdOrdSel, True)
    End Sub

    Private Sub btnIndietro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIndietro.Click
        _Giorno = _Giorno.AddDays(-1)
        CaricaGiorno()
    End Sub

    Private Sub btnAvanti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvanti.Click
        _Giorno = _Giorno.AddDays(1)
        CaricaGiorno()
    End Sub

    Private Sub cmbCorriere_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCorriere.SelectedIndexChanged
        CaricaGiorno()
    End Sub

    Private Sub btnEspandi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEspandi.Click
        UcConsegneGiorno.EspandiTutto()
    End Sub

    Private Sub btnComprimi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComprimi.Click
        UcConsegneGiorno.CollassaTutto()
    End Sub

    Private Sub cmbOperatore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperatore.SelectedIndexChanged, cmbZona.SelectedIndexChanged
        CaricaGiorno()
    End Sub

End Class