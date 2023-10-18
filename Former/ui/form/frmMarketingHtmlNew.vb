Imports FormerDALSql
Imports FormerBusinessLogic
Imports FormerLib
Imports FormerConfig

Friend Class frmMarketingHtmlNew
    'Inherits baseFormInternaRedim

    Private _Ris As Integer

    Private _IdTemplateMarketing As Integer = 0

    Friend Function Carica(Optional IdTemplateMarketing As Integer = 0) As Integer

        _IdTemplateMarketing = IdTemplateMarketing

        If _IdTemplateMarketing Then

            Using t As New TemplateMarketing
                t.Read(_IdTemplateMarketing)
                txtSoggetto.Text = t.Titolo
                txtSorgente.Text = t.Path
            End Using

            btnOk.Enabled = False
            btnSfoglia.Enabled = False
            btnDelTemplate.Enabled = True
            _Ris = _IdTemplateMarketing
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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio del template selezionato?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If txtSorgente.Text.Trim.Length Then
                Cursor.Current = Cursors.WaitCursor

                SalvaTemplate()

                Cursor.Current = Cursors.Default

                Close()

            Else
                MessageBox.Show("Selezionare un template di newsletter!")

            End If

        End If

    End Sub

    Private Sub SalvaTemplate()

        Using t As New TemplateMarketing

            If _IdTemplateMarketing = 0 Then
                t.Titolo = txtSoggetto.Text
                _IdTemplateMarketing = t.Save

                Dim NomeNuovoFile As String = "NL-H-" & _IdTemplateMarketing & "-" & Now.Year & ".htm"

                'MgrIO.FileCopia(Me, txtSorgente.Text, NomeNuovoFile)

                MgrMarketingWeb.PathTarget = FormerPath.PathTemplate
                MgrMarketingWeb.NomeFile = NomeNuovoFile
                Dim PathFile As String = MgrMarketingWeb.CreaNewsletterSuFileHtml(txtSorgente.Text)

                t.Path = PathFile
                _IdTemplateMarketing = t.Save()
                _Ris = _IdTemplateMarketing
            End If

        End Using

    End Sub

    Private Sub btnSfoglia_Click(sender As Object, e As EventArgs) Handles btnSfoglia.Click

        If dlgScegliTemplate.ShowDialog() = DialogResult.OK Then
            dlgScegliTemplate.InitialDirectory = FormerPath.PathTemplateEmailMarketingSorgenti
            Dim path As String = dlgScegliTemplate.FileName

            txtSorgente.Text = path

        End If

    End Sub

    Private Sub btnAnteprima_Click(sender As Object, e As EventArgs) Handles btnAnteprima.Click

        If txtSorgente.Text.Length Then

            FormerHelper.File.ShellExtended(txtSorgente.Text)

        End If

    End Sub

    Private Sub btnDelTemplate_Click(sender As Object, e As EventArgs) Handles btnDelTemplate.Click

        'qui lo posso eliminare solo se.... 
        If MessageBox.Show("Confermi l'eliminazione del template?", "Eliminazione Template HTML", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            'qui devo controllare che puoi eliminare il template
            Using mgr As New LogMarketingDAO
                Dim l As List(Of LogMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.LogMarketing.IdTemplateMarketing, _IdTemplateMarketing))

                If l.Count = 0 Then
                    'qui devo eliminare, il file, i file online, il record nel db
                    Using t As New TemplateMarketing
                        t.Read(_IdTemplateMarketing)

                        Try
                            FileIO.FileSystem.DeleteFile(t.Path)
                        Catch ex As Exception

                        End Try

                        Using mgrT As New TemplateMarketingDAO
                            mgrT.Delete(_IdTemplateMarketing)
                        End Using

                    End Using
                    'tornando questo azzero anche il link logico al filtro 
                    Close()

                    _Ris = 0

                Else
                    'qui non posso eliminare
                    MessageBox.Show("Il template non può essere utilizzato in quanto già schedulato/inviato dalla funzione di invio marketing!")
                End If

            End Using

        End If

    End Sub

End Class