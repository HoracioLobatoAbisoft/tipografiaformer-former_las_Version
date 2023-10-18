Imports FormerDALSql
Imports System.IO
Imports FormerLib
Imports FormerConfig

Friend Class frmListinoColoreStampa
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _ColoreStampa As New ColoreStampa

    Friend Function Carica(Optional ByVal IdColoreStampa As Integer = 0) As Integer

        If IdColoreStampa Then

            _ColoreStampa.Read(IdColoreStampa)
            txtDescrizione.Text = _ColoreStampa.Descrizione
            txtNLastre.Text = _ColoreStampa.NLastre
            txtImgLav.Text = _ColoreStampa.ImgRif
            chkFR.Checked = _ColoreStampa.FR
            txtSigla.Text = _ColoreStampa.Sigla

            UcListinoImpatto.CalcolaSuColoreDiStampa(IdColoreStampa)

            If txtImgLav.Text.Length Then
                Try
                    pctImgLav.Image = Image.FromFile(txtImgLav.Text)
                Catch ex As Exception

                End Try

            End If

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

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _ColoreStampa.Descrizione = txtDescrizione.Text
            _ColoreStampa.Sigla = txtSigla.Text
            _ColoreStampa.FR = chkFR.Checked
            _ColoreStampa.NLastre = txtNLastre.Text

            If _ColoreStampa.IsValid Then

                Dim lst As List(Of ColoreStampa) = Nothing

                Using mgr As New ColoriStampaDAO
                    lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ColoreStampa.Sigla, _ColoreStampa.Sigla),
                                      New LUNA.LunaSearchParameter(LFM.ColoreStampa.IdColoreStampa, _ColoreStampa.IdColoreStampa, "<>"))
                End Using

                If lst.Count Then
                    'codice non univoco
                    MessageBox.Show("La sigla inserita non è univoca! Cambiarla", "Former", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'copio l'immagine nella cartella centralizzata
                    If txtImgLav.Text.Length Then
                        If txtImgLav.Text <> _ColoreStampa.ImgRif Then
                            Dim nuovoNome As String = String.Empty
                            If txtImgLav.Text.StartsWith(FormerPath.PathListinoImg) Then
                                'non devo copiare
                                nuovoNome = txtImgLav.Text
                            Else
                                'devo copiare 
                                Dim F As New FileInfo(txtImgLav.Text)
                                nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgLav.Text),, _ColoreStampa.Descrizione)
                                MgrIO.FileCopia(Me, txtImgLav.Text, nuovoNome)
                            End If
                            _ColoreStampa.ImgRif = nuovoNome
                        End If

                    End If

                    _ColoreStampa.Save()
                    _Ris = 1
                    Close()
                End If

            Else
                MessageBox.Show("Inserisci tutti i dati richiesti.", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgLav.Text = OpenFileImg.FileName
            pctImgLav.Image = Image.FromFile(txtImgLav.Text)
        End If
    End Sub

    Private Sub txtSigla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSigla.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnWizard_Click(sender As Object, e As EventArgs)
        Using f As New frmListinoImgTemporanea
            Sottofondo()
            Dim PathTemp As String = f.Carica()
            Sottofondo()
            If PathTemp.Length Then
                txtImgLav.Text = PathTemp
                pctImgLav.Image = Image.FromFile(PathTemp)
            End If

        End Using
    End Sub

End Class