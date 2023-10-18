Imports FormerConfig
Imports FormerDALSql
Imports FormerIO
Imports FormerLib

Friend Class frmProcedura
    'Inherits baseFormInternaFixed

    Private _Ris As Integer
    Private _IdProcedura As Integer = 0

    Friend Function Carica(Optional IdProcedura As Integer = 0) As Integer

        _IdProcedura = IdProcedura

        CaricaCombo()

        If IdProcedura Then
            UcAmministrazioneStep.IdProcedura = _IdProcedura
            UcAmministrazioneStep.CaricaDati()
            Using P As New Procedura
                P.Read(IdProcedura)
                txtNome.Text = P.Nome
                txtDescrizione.Text = P.Descrizione
                If P.IdMacchinario Then MgrControl.SelectIndexCombo(cmbMacchinario, P.IdMacchinario)
                If P.IdLavorazione Then MgrControl.SelectIndexCombo(cmbLavorazione, P.IdLavorazione)
            End Using
            CaricaFileAllegati()
        Else
            TabMain.TabPages.Remove(tpStep)
            TabMain.TabPages.Remove(tpFileAllegati)
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using mgr As New LavorazioniDAO
            Dim l As List(Of Lavorazione) = mgr.GetAll(LFM.Lavorazione.Descrizione, True)
            cmbLavorazione.ValueMember = LFM.Lavorazione.IdLavoro.Name
            cmbLavorazione.DataSource = l
        End Using

        Using mgr As New MacchinariDAO
            Dim l As List(Of Macchinario) = mgr.GetAll(LFM.Macchinario.Tipo.Name & "," & LFM.Macchinario.Descrizione.Name, True)
            cmbMacchinario.ValueMember = LFM.Macchinario.IdMacchinario.Name
            cmbMacchinario.DataSource = l
        End Using

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If _IdProcedura Then
            'qui genero il file htm nella cartella delle procedure
            Using P As New Procedura
                P.Read(_IdProcedura)
                MgrProcedure.CreaHtmlProcedura(P)
            End Using
        End If

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio della Procedura?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim L As Lavorazione = cmbLavorazione.SelectedItem
            Dim M As Macchinario = cmbMacchinario.SelectedItem

            If (L.IdLavoro = 0 And M.IdMacchinario = 0) Then
                MessageBox.Show("Si deve selezionare almeno una Lavorazione o un Macchinario")
            Else

                Using P As New Procedura

                    If _IdProcedura Then P.Read(_IdProcedura)

                    P.Nome = txtNome.Text
                    P.Descrizione = txtDescrizione.Text
                    P.IdMacchinario = cmbMacchinario.SelectedValue
                    P.IdLavorazione = cmbLavorazione.SelectedValue
                    P.Save()

                    If _IdProcedura Then
                        'qui genero il file htm nella cartella delle procedure
                        MgrProcedure.CreaHtmlProcedura(P)
                    End If

                    _Ris = 1
                    Close()

                End Using
            End If

        End If
    End Sub

    Private Sub lnkApriAltri_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkApriAltri.LinkClicked
        ApriFileSelezionato()

    End Sub


    Private Sub ApriFileSelezionato()

        If dgAltriFile.SelectedRows.Count Then

            Using Riga As DataGridViewRow = dgAltriFile.SelectedRows(0)
                Using F As FileAllegato = Riga.DataBoundItem
                    Dim Path As String = F.FilePath

                    FormerLib.FormerHelper.File.ShellExtended(Path)

                End Using

            End Using

        End If

    End Sub

    Private Sub dgAltriFile_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAltriFile.CellContentClick

    End Sub

    Private Sub dgAltriFile_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAltriFile.CellDoubleClick

        ApriFileSelezionato()

    End Sub

    Private Sub lnkAggiungiAltri_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiungiAltri.LinkClicked

        OpenFileSorg.Filter = "Tutti i file|*.*"
        OpenFileSorg.ShowDialog()
        Dim OldName As String = OpenFileSorg.FileName

        If OldName.Length Then

            'qui copio il file nella cartella di destinazione. se già c'è chiedo se lo vuole sovrascrivere 
            Dim NewName As String = FormerHelper.File.EstraiNomeFile(OldName)
            NewName = _IdProcedura & "-" & NewName
            NewName = FormerPath.PathProcedure & NewName

            Try
                MgrIO.FileCopia(Me, OldName, NewName)

                Using A As New FileAllegato
                    A.IdProcedura = _IdProcedura
                    A.FilePath = NewName
                    A.Save()
                End Using

                CaricaFileAllegati()
            Catch ex As Exception
                MessageBox.Show("Si è verificato un errore nel salvataggio del file. " & ex.Message)
            End Try

        End If
    End Sub

    Private Sub CaricaFileAllegati()

        Using mgr As New FileAllegatiDAO
            Dim l As List(Of FileAllegato) = mgr.FindAll(LFM.FileAllegato.FilePath,
                                                         New LUNA.LunaSearchParameter(LFM.FileAllegato.IdProcedura, _IdProcedura))

            dgAltriFile.AutoGenerateColumns = False
            dgAltriFile.DataSource = l

        End Using

    End Sub

    Private Sub lnkRimuoviAltri_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRimuoviAltri.LinkClicked

        If dgAltriFile.SelectedRows.Count Then

            Using Riga As DataGridViewRow = dgAltriFile.SelectedRows(0)
                Using F As FileAllegato = Riga.DataBoundItem
                    Dim Path As String = F.FilePath

                    If MessageBox.Show("Confermi la cancellazione del file '" & Path & "'?", "Eliminazione file allegato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        Using mgr As New FileAllegatiDAO
                            mgr.Delete(F.IdFileAllegato)
                        End Using

                        Try
                            MgrFormerIO.FileDelete(Path)
                        Catch ex As Exception
                            MessageBox.Show("Si è verificato un errore nella cancellazione fisica del file. Il file allegato è stato correttamente eliminato dal database. " & ex.Message)
                        End Try

                        CaricaFileAllegati()

                    End If

                End Using

            End Using
        Else
            Beep()
        End If
    End Sub
End Class