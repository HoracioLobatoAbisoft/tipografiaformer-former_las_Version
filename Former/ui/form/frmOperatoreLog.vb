Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmOperatoreLog
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        Using mgr As New UtentiDAO

            Dim l As List(Of Utente) = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "Login", .AddEmptyItem = True},
                                                   New LUNA.LunaSearchParameter(LFM.Utente.Attivo, enSiNo.Si),
                                                   New LUNA.LunaSearchParameter(LFM.Utente.Tipo, enTipoUtente.Operatore))
            cmbUtente.DisplayMember = "Login"
            cmbUtente.ValueMember = "IdUt"
            cmbUtente.DataSource = l

        End Using

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs)

        If MessageBox.Show("Confermi qualcosa?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub CaricaDati()
        Cursor.Current = Cursors.WaitCursor

        Dim l As New List(Of LogOperatore)

        If rdoOperatore.Checked Then
            Dim ParamOperatore As LUNA.LunaSearchParameter = Nothing

            If cmbUtente.SelectedIndex <> 0 Then
                ParamOperatore = New LUNA.LunaSearchParameter(LFM.LavLog.IdUt, cmbUtente.SelectedValue)
            End If

            Using mgr As New LavLogDAO

                Dim ll As List(Of LavLog) = mgr.FindAll(ParamOperatore,
                                                        New LUNA.LunaSearchParameter("day(DataoraInizio)", dtGiornoScelto.Value.Day),
                                                        New LUNA.LunaSearchParameter("month(DataoraInizio)", dtGiornoScelto.Value.Month),
                                                        New LUNA.LunaSearchParameter("year(DataoraInizio)", dtGiornoScelto.Value.Year))

                For Each singLav As LavLog In ll
                    Dim singLog As New LogOperatore
                    singLog.Operatore = singLav.Utente.Login
                    singLog.Attivita = singLav.LavorazioneDescrizione & " iniziata su " & IIf(singLav.IdOrd, "Ordine " & singLav.IdOrd, "Commessa " & singLav.IdCom) & IIf(singLav.DataOraFine <> Date.MinValue, " e terminata alle " & singLav.DataOraFine.ToString("dd/MM/yyyy HH:mm.ss"), "")
                    singLog.QuandoD = singLav.DataOraInizio
                    singLog.ImgRif = singLav.ImgAnteprima
                    l.Add(singLog)
                Next

            End Using

            If cmbUtente.SelectedIndex <> 0 Then
                ParamOperatore = New LUNA.LunaSearchParameter(LFM.CronoOrdine.IdOperatore, cmbUtente.SelectedValue)
            End If

            Using mgr As New CronoOrdiniDAO

                Dim ll As List(Of CronoOrdine) = mgr.FindAll(ParamOperatore,
                                                        New LUNA.LunaSearchParameter("day(DataCrono)", dtGiornoScelto.Value.Day),
                                                        New LUNA.LunaSearchParameter("month(DataCrono)", dtGiornoScelto.Value.Month),
                                                        New LUNA.LunaSearchParameter("year(DataCrono)", dtGiornoScelto.Value.Year),
                                                        New LUNA.LunaSearchParameter(LFM.CronoOrdine.IdStato, enStatoOrdine.Imballaggio, ">="))

                For Each singLav As CronoOrdine In ll
                    Dim singLog As New LogOperatore
                    singLog.Operatore = singLav.Utente.Login
                    singLog.Attivita = "Ordine " & singLav.IdOrd & " passato a " & FormerLib.FormerEnum.FormerEnumHelper.StatoOrdineString(singLav.IdStato)
                    singLog.QuandoD = singLav.DataCrono
                    singLog.ImgRif = singLav.ImgAnteprima
                    l.Add(singLog)
                Next

            End Using

            'Using mgr As New CronoCommesseDAO

            '    Dim ll As List(Of CronoCommessa) = mgr.FindAll(ParamOperatore,
            '                                            New LUNA.LunaSearchParameter("day(DataCronoInizio)", dtGiornoScelto.Value.Day),
            '                                            New LUNA.LunaSearchParameter("month(DataCronoInizio)", dtGiornoScelto.Value.Month),
            '                                            New LUNA.LunaSearchParameter("year(DataCronoInizio)", dtGiornoScelto.Value.Year))

            '    For Each singLav As CronoCommessa In ll
            '        Dim singLog As New LogOperatore
            '        singLog.Operatore = singLav.Utente.Login

            '        If singLav.DataCronoFine = Date.MinValue Then
            '            singLog.Attivita = "Commessa " & singLav.IdCom & " passata a " & FormerLib.FormerEnum.FormerEnumHelper.StatoCommessaString(singLav.IdStato)
            '        Else
            '            singLog.Attivita = "Commessa " & singLav.IdCom & " terminato lo stato " & FormerLib.FormerEnum.FormerEnumHelper.StatoCommessaString(singLav.IdStato) & " alle " & singLav.DataCronoFine.ToString("dd/MM/yyyy HH:mm.ss")
            '        End If
            '        singLog.QuandoD = singLav.DataCronoInizio
            '        l.Add(singLog)
            '    Next

            'End Using
        ElseIf rdoOrdine.Checked Then
            Using mgr As New LavLogDAO

                Dim ll As List(Of LavLog) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.LavLog.IdOrd, txtOrdine.Text))

                For Each singLav As LavLog In ll
                    Dim singLog As New LogOperatore
                    singLog.Operatore = singLav.Utente.Login
                    singLog.Attivita = singLav.LavorazioneDescrizione & " iniziata su " & IIf(singLav.IdOrd, "Ordine " & singLav.IdOrd, "Commessa " & singLav.IdCom) & IIf(singLav.DataOraFine <> Date.MinValue, " e terminata alle " & singLav.DataOraFine.ToString("dd/MM/yyyy HH:mm.ss"), "")
                    singLog.QuandoD = singLav.DataOraInizio
                    singLog.ImgRif = singLav.ImgAnteprima
                    l.Add(singLog)
                Next

            End Using

            Using mgr As New CronoOrdiniDAO

                Dim ll As List(Of CronoOrdine) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CronoOrdine.IdOrd, txtOrdine.Text),
                                                             New LUNA.LunaSearchParameter(LFM.CronoOrdine.IdStato, enStatoOrdine.Imballaggio, ">="))

                For Each singLav As CronoOrdine In ll
                    Dim singLog As New LogOperatore
                    singLog.Operatore = singLav.Utente.Login
                    singLog.Attivita = "Ordine " & singLav.IdOrd & " passato a " & FormerLib.FormerEnum.FormerEnumHelper.StatoOrdineString(singLav.IdStato)
                    singLog.QuandoD = singLav.DataCrono
                    singLog.ImgRif = singLav.ImgAnteprima
                    l.Add(singLog)
                Next

            End Using

        End If

        l.Sort(Function(x, y) x.QuandoD.CompareTo(y.QuandoD))

        DgLog.AutoGenerateColumns = False
        DgLog.DataSource = l

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub txtOrdine_GotFocus(sender As Object, e As EventArgs) Handles txtOrdine.GotFocus
        rdoOrdine.Checked = True
    End Sub

    Private Sub txtOrdine_Click(sender As Object, e As EventArgs) Handles txtOrdine.Click
        rdoOrdine.Checked = True
    End Sub

    Private Sub dtGiornoScelto_Click(sender As Object, e As EventArgs) Handles dtGiornoScelto.Click
        rdoOperatore.Checked = True
    End Sub

    Private Sub cmbUtente_Click(sender As Object, e As EventArgs) Handles cmbUtente.Click
        rdoOperatore.Checked = True
    End Sub

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked

        If rdoOrdine.Checked And txtOrdine.Text.Length = 0 Then
            MessageBox.Show("Inserire un numero di ordine")
        Else
            CaricaDati()
        End If

    End Sub

    Private Sub txtOrdine_TextChanged(sender As Object, e As EventArgs) Handles txtOrdine.TextChanged

    End Sub

    Private Sub txtOrdine_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrdine.KeyDown
        If e.KeyCode = Keys.Enter Then
            CaricaDati()
        End If
    End Sub
End Class