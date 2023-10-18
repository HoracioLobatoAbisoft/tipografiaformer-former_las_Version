Imports System.IO
Imports FormerConfig
Imports FormerDALSql
Friend Class frmListinoCatFormato

    'Inherits baseFormInternaFixed

    Private _Ris As Integer
    Private _CatFormato As New CatFormatoProdotto
    Private _ModificatiFormatiCorrelati As Boolean = False

    Private Sub CaricaFormatiProdotto()

        lstFormatiProdotto.Items.Clear()
        For Each fp As FormatoProdotto In _CatFormato.Formati(True)
            Dim ris As Integer = lstFormatiProdotto.Items.Add(fp)
        Next

    End Sub

    Private Sub CaricaDefaultPreventivazione()

        lstDefaultInseriti.Items.Clear()
        For Each fp As DefaultFormatoProdotto In _CatFormato.DefaultPreventivazione(True)
            Dim ris As Integer = lstDefaultInseriti.Items.Add(fp)
        Next

    End Sub

    Friend Function Carica(Optional ByVal IdCatFormato As Integer = 0) As Integer

        If IdCatFormato Then

            _CatFormato.Read(IdCatFormato)
            txtNome.Text = _CatFormato.Nome
            txtDescEst.Text = _CatFormato.DescrizioneEstesa
            txtImgLav.Text = _CatFormato.ImgRif
            If txtImgLav.Text.Length Then
                Try
                    pctImgLav.Image = Image.FromFile(txtImgLav.Text)
                Catch ex As Exception

                End Try

            End If

            CaricaFormatiProdotto()
            CaricaDefaultPreventivazione


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

        If txtImgLav.Text.Length Then
            If MessageBox.Show("Confermi il salvataggio della categoria di formato prodotto?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                _CatFormato.Nome = txtNome.Text
                _CatFormato.DescrizioneEstesa = txtDescEst.Text

                If _CatFormato.IsValid Then

                    If txtImgLav.Text.Length Then
                        If txtImgLav.Text <> _CatFormato.ImgRif Then
                            Dim nuovoNome As String = String.Empty
                            If txtImgLav.Text.StartsWith(FormerPath.PathListinoImg) Then
                                'non devo copiare
                                nuovoNome = txtImgLav.Text
                            Else
                                'devo copiare 
                                Dim F As New FileInfo(txtImgLav.Text)

                                nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgLav.Text),, _CatFormato.Nome)
                                MgrIO.FileCopia(Me, txtImgLav.Text, nuovoNome)
                            End If
                            _CatFormato.ImgRif = nuovoNome
                        End If
                    End If
                    _CatFormato.Save()

                    'qui devo andare a salvare i formati prodotto correlati

                    _Ris = 1
                    Close()
                Else
                    MessageBox.Show("Inserisci tutti i dati richiesti.", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If
        Else
            MessageBox.Show("Inserisci l'immagine della categoria.", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgLav.Text = OpenFileImg.FileName
            pctImgLav.Image = Image.FromFile(txtImgLav.Text)
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

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If lstFormatiProdotto.SelectedIndex <> -1 Then
            If MessageBox.Show("Confermi la cancellazione della voce selezionata?", "Tipologia di Carta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'cancello la riga selezionata

                Dim p As FormatoProdotto = DirectCast(lstFormatiProdotto.SelectedItem, FormatoProdotto)
                p.IdCatFormatoProdotto = 0
                p.Save()
                _CatFormato.Formati.Remove(p)
                _Ris = 1

                Using mgr As New DefaultFormatoProdottoDAO
                    mgr.DeleteByIdFormProd(p.IdFormProd)
                End Using

                lstFormatiProdotto.Items.RemoveAt(lstFormatiProdotto.SelectedIndex)
                _ModificatiFormatiCorrelati = True
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If _CatFormato.IdCatFormatoProdotto Then

            Dim Ris As Integer = 0
            Sottofondo()

            Using f As New frmSelectFormatoProdotto
                Ris = f.Carica(_CatFormato.IdCatFormatoProdotto)
            End Using

            If Ris Then
                CaricaFormatiProdotto()
                _ModificatiFormatiCorrelati = True

            End If
            Sottofondo()
        Else
            MessageBox.Show("Per inserire i formati prodotto contenuti salvare prima la categoria")
        End If

    End Sub

    Private Sub lnkDelDefault_Click(sender As Object, e As EventArgs) Handles lnkDelDefault.Click
        If lstDefaultInseriti.SelectedIndex <> -1 Then
            If MessageBox.Show("Confermi la cancellazione del default selezionato?", "Tipologia di Carta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'cancello la riga selezionata

                Dim p As DefaultFormatoProdotto = DirectCast(lstDefaultInseriti.SelectedItem, DefaultFormatoProdotto)

                Using mgr As New DefaultFormatoProdottoDAO
                    mgr.Delete(p.IdDefaultFormatoPrev)
                End Using

                _CatFormato.DefaultPreventivazione.Remove(p)
                _Ris = 1

                lstDefaultInseriti.Items.RemoveAt(lstDefaultInseriti.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub lnkAddDefault_Click(sender As Object, e As EventArgs) Handles lnkAddDefault.Click

        If _CatFormato.IdCatFormatoProdotto Then

            Dim Ris As Integer = 0
            Sottofondo()

            Using f As New frmSelectDefaultFP
                Ris = f.Carica(_CatFormato.IdCatFormatoProdotto)
            End Using

            If Ris Then
                CaricaDefaultPreventivazione()

            End If
            Sottofondo()
        Else
            MessageBox.Show("Per inserire i formati prodotto contenuti salvare prima la categoria")
        End If
    End Sub

End Class