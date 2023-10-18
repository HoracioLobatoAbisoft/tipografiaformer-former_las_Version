Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerLib
Imports FormerConfig

Friend Class frmListinoTipoFustella
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Friend Function Carica(IdTf As Integer) As Integer

        Dim Cm As New TipoFustella
        Cm.Read(IdTf)

        Carica(Cm)

        Return _Ris

    End Function

    Private _Tf As TipoFustella = Nothing
    Friend Function Carica(Optional Tf As TipoFustella = Nothing) As Integer

        CaricaCombo()

        _Tf = Tf

        If _Tf Is Nothing Then
            _Tf = New TipoFustella
        Else
            txtBase.Text = _Tf.Base
            txtAltezza.Text = _Tf.Altezza
            txtProfondita.Text = _Tf.Profondita
            txtCodice.Text = _Tf.Codice
            txtTemplatePDF.Text = _Tf.TemplatePDF
            MgrControl.SelectIndexCombo(cmbPrev, _Tf.IdPrev)
            'MgrControl.SelectIndexCombo(cmbCat, _Tf.IdCatFustella)

            'seleziono le categorie scelte

            For Each cat As CategoriaFustella In _Tf.CategorieAssociate

                Dim I As Integer = 0
                For Each c As CategoriaFustella In lstCat.Items
                    If c.IdCatFustella = cat.IdCatFustella Then
                        lstCat.SetItemChecked(I, True)
                        Exit For
                    End If
                    I += 1
                Next

            Next

            If _Tf.Disponibile = enSiNo.Si Then
                chkDisponibile.Checked = True
            End If
            If _Tf.Orientabile = enSiNo.Si Then
                chkOrientabile.Checked = True
            End If

            txtImgRif.Text = _Tf.ImgRif

            If txtImgRif.Text.Length Then
                Try
                    pctImgLav.Image = Image.FromFile(txtImgRif.Text)
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

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


            _Tf.Altezza = txtAltezza.Text
            _Tf.Base = txtBase.Text
            _Tf.Profondita = txtProfondita.Text
            _Tf.Codice = txtCodice.Text
            'If cmbCat.SelectedValue Then
            '    _Tf.IdCatFustella = cmbCat.SelectedValue
            'Else
            '    _Tf.IdCatFustella = 0
            'End If

            _Tf.IdPrev = cmbPrev.SelectedValue

            If chkDisponibile.Checked Then _Tf.Disponibile = enSiNo.Si Else _Tf.Disponibile = enSiNo.No

            If chkOrientabile.Checked Then _Tf.Orientabile = enSiNo.Si Else _Tf.Orientabile = enSiNo.No

            If _Tf.IsValid Then

                If txtImgRif.Text.Length Then
                    If txtImgRif.Text <> _Tf.ImgRif Then
                        Dim nuovoNome As String = String.Empty
                        If txtImgRif.Text.StartsWith(FormerPath.PathListinoImg) Then
                            'non devo copiare
                            nuovoNome = txtImgRif.Text
                        Else
                            'devo copiare 
                            Dim F As New FileInfo(txtImgRif.Text)
                            nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgRif.Text))
                            MgrIO.FileCopia(Me, txtImgRif.Text, nuovoNome)
                        End If
                        _Tf.ImgRif = nuovoNome
                    End If

                End If

                If txtTemplatePDF.Text.Length Then
                    If txtTemplatePDF.Text <> _Tf.TemplatePDF Then
                        Dim nuovoNome As String = String.Empty
                        If txtTemplatePDF.Text.StartsWith(FormerPath.PathListinoTemplate) Then
                            'non devo copiare
                            nuovoNome = txtTemplatePDF.Text
                        Else
                            'devo copiare 
                            Dim F As New FileInfo(txtTemplatePDF.Text)
                            nuovoNome = FormerPath.PathListinoTemplate & FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf")
                            MgrIO.FileCopia(Me, txtTemplatePDF.Text, nuovoNome)
                        End If
                        _Tf.TemplatePDF = nuovoNome
                    End If

                End If

                _Tf.Save()

                'cancello e poi salvo le categorie scelte
                If _Tf.IdTipoFustella Then
                    Using mgr As New TipoFustellaSuCatDAO
                        mgr.DeleteByIdTipoFustella(_Tf.IdTipoFustella)
                    End Using
                End If

                For Each singItem As CategoriaFustella In lstCat.CheckedItems
                    Dim voce As New TipoFustellaSuCat
                    voce.IdTipo = _Tf.IdTipoFustella
                    voce.IdCat = singItem.IdCatFustella
                    voce.Save()
                Next

            End If

            _Ris = 1
            Close()
        End If
    End Sub

    Private Sub CaricaCombo()

        Using mgr As New PreventivazioniDAO
            Dim l As List(Of Preventivazione) = mgr.GetAll(LFM.Preventivazione.Descrizione)

            cmbPrev.DisplayMember = "Descrizione"
            cmbPrev.ValueMember = "IdPrev"
            cmbPrev.DataSource = l
        End Using

        Using mgr As New CategorieFustelleDAO
            Dim l As List(Of CategoriaFustella) = mgr.GetAll(LFM.CategoriaFustella.Categoria)

            lstCat.DisplayMember = "Categoria"
            lstCat.ValueMember = "IdCatFustella"
            lstCat.DataSource = l
        End Using

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgRif.Text = OpenFileImg.FileName

            Try
                pctImgLav.Image = Image.FromFile(txtImgRif.Text)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub btnSearchPdf_Click(sender As Object, e As EventArgs) Handles btnSearchPdf.Click
        OpenFilePDF.ShowDialog()

        If OpenFilePDF.FileName.Length Then
            txtTemplatePDF.Text = OpenFilePDF.FileName
        End If
    End Sub

    Private Sub btnWizard_Click(sender As Object, e As EventArgs) 
        Using f As New frmListinoImgTemporanea
            Sottofondo()
            Dim PathTemp As String = f.Carica()
            Sottofondo()
            If PathTemp.Length Then
                txtImgRif.Text = PathTemp
                pctImgLav.Image = Image.FromFile(PathTemp)
            End If

        End Using
    End Sub
End Class