Imports FormerDALSql
Imports System.IO
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerConfig

Friend Class frmListinoFormatoProdotto
    'Inherits baseFormInternaRedim

    Private _Ris As Integer
    Private _Formato As New FormatoProdotto

    Private Sub CaricaCombo()
        cmbOrientamento.SelectedIndex = 0

        Dim lst As List(Of FormatoCarta) = Nothing

        Using mgr As New FormatiCartaDAO
            lst = mgr.GetAll(LFM.FormatoCarta.FormatoCarta)
        End Using

        cmbFormatoCarta.DataSource = lst
        cmbFormatoCarta.ValueMember = "IdFormCarta"
        cmbFormatoCarta.DisplayMember = "FormatoCarta"

        Dim lstCat As List(Of CatFormatoProdotto) = Nothing

        Using mgr As New CatFormatoProdottoDAO
            lstCat = mgr.GetAll(LFM.CatFormatoProdotto.Nome, True)
        End Using

        cmbCatFormato.DataSource = lstCat
        cmbCatFormato.ValueMember = "IdCatFormatoProdotto"
        cmbCatFormato.DisplayMember = "Nome"

    End Sub

    Friend Function Carica(Optional ByVal IdFormato As Integer = 0) As Integer

        CaricaCombo()

        If IdFormato Then

            _Formato.Read(IdFormato)
            txtDescrizione.Text = _Formato.Formato
            cmbOrientamento.SelectedIndex = _Formato.Orientamento
            txtImgLav.Text = _Formato.ImgRif
            txtSigla.Text = _Formato.Sigla
            txtNomeAlbero.Text = _Formato.NomeAlbero
            'txtNumFacc.Text = _Formato.NumFacc
            MgrControl.SelectIndexCombo(cmbFormatoCarta, _Formato.IdFormCarta)
            txtDescEst.Text = _Formato.DescrizioneEstesa
            txtPdfTemplate.Text = _Formato.PdfTemplate
            txtPdfTemplate3D.Text = _Formato.PdfTemplate3D
            chkProdottoFinito.Checked = _Formato.ProdottoFinito
            chkOrientabile.Checked = IIf(_Formato.Orientabile = enSiNo.Si, True, False)
            txtLarghezza.Text = _Formato.Larghezza
            txtLunghezza.Text = _Formato.Lunghezza

            If _Formato.IsRotolo = enSiNo.Si Then
                chkIsRotolo.Checked = True
            Else
                chkIsRotolo.Checked = False
            End If

            If _Formato.IsLastra = enSiNo.Si Then
                chkIsLastra.Checked = True
            Else
                chkIsLastra.Checked = False
            End If

            MgrControl.SelectIndexCombo(cmbCatFormato, _Formato.IdCatFormatoProdotto)

            UcListinoImpatto.CalcolaSuFormatoProdotto(IdFormato)

            If txtImgLav.Text.Length Then
                Try
                    pctImgLav.Image = Image.FromFile(txtImgLav.Text)
                Catch ex As Exception

                End Try

            End If
            'CaricaResa()
            ' Else
            'txtNumFacc.Text = 1
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

            _Formato.Formato = txtDescrizione.Text
            _Formato.Orientamento = cmbOrientamento.SelectedIndex
            _Formato.Sigla = txtSigla.Text
            '_Formato.NumFacc = txtNumFacc.Text
            _Formato.IdFormCarta = DirectCast(cmbFormatoCarta.SelectedItem, FormatoCarta).IdFormCarta
            _Formato.DescrizioneEstesa = txtDescEst.Text
            _Formato.ProdottoFinito = chkProdottoFinito.Checked
            _Formato.Orientabile = IIf(chkOrientabile.Checked, enSiNo.Si, enSiNo.No)
            _Formato.NomeAlbero = txtNomeAlbero.Text
            _Formato.IdCatFormatoProdotto = cmbCatFormato.SelectedValue
            _Formato.Lunghezza = txtLunghezza.Text
            _Formato.Larghezza = txtLarghezza.Text
            _Formato.IsRotolo = IIf(chkIsRotolo.Checked, enSiNo.Si, enSiNo.No)
            _Formato.IsLastra = IIf(chkIsLastra.Checked, enSiNo.Si, enSiNo.No)
            If _Formato.IsValid Then

                Dim lst As List(Of FormatoProdotto) = Nothing
                Using mgr As New FormatiProdottoDAO
                    lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.FormatoProdotto.Sigla, _Formato.Sigla),
                                      New LUNA.LunaSearchParameter(LFM.FormatoProdotto.IdFormProd, _Formato.IdFormProd, "<>"))
                End Using
                If lst.Count Then
                    'codice non univoco
                    MessageBox.Show("La sigla inserita non è univoca! Cambiarla", "Former", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'copio l'immagine nella cartella centralizzata
                    If txtImgLav.Text.Length Then
                        If txtImgLav.Text <> _Formato.ImgRif Then
                            Dim nuovoNome As String = String.Empty
                            If txtImgLav.Text.StartsWith(FormerPath.PathListinoImg) Then
                                'non devo copiare
                                nuovoNome = txtImgLav.Text
                            Else
                                'devo copiare 
                                Dim F As New FileInfo(txtImgLav.Text)
                                nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgLav.Text),, _Formato.Formato)
                                MgrIO.FileCopia(Me, txtImgLav.Text, nuovoNome)
                            End If
                            _Formato.ImgRif = nuovoNome
                        End If
                    End If

                    If txtPdfTemplate.Text.Length Then
                        If txtPdfTemplate.Text <> _Formato.PdfTemplate Then
                            Dim F As New FileInfo(txtPdfTemplate.Text)
                            Dim nuovoNome As String = FormerPath.PathListinoTemplate & FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf",, _Formato.Formato)

                            MgrIO.FileCopia(Me, txtPdfTemplate.Text, nuovoNome)

                            _Formato.PdfTemplate = nuovoNome
                        End If
                    End If

                    If txtPdfTemplate3D.Text.Length Then
                        If txtPdfTemplate3D.Text <> _Formato.PdfTemplate3D Then
                            Dim F As New FileInfo(txtPdfTemplate3D.Text)
                            Dim nuovoNome As String = FormerPath.PathListinoTemplate & FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf",, _Formato.Formato)

                            MgrIO.FileCopia(Me, txtPdfTemplate3D.Text, nuovoNome)

                            _Formato.PdfTemplate3D = nuovoNome
                        End If
                    End If

                    _Formato.Save()
                    _Ris = 1
                    Close()
                End If
            Else
                MessageBox.Show("Inserisci tutti i dati richiesti.", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

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

    Private Sub txtSigla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSigla.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnSearchPdf_Click(sender As Object, e As EventArgs) Handles btnSearchPdf.Click
        OpenFileImg.Filter = "Template PDF|*.pdf"
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtPdfTemplate.Text = OpenFileImg.FileName
        End If
    End Sub

    Private Sub btnSearchPdf3d_Click(sender As Object, e As EventArgs) Handles btnSearchPdf3d.Click
        OpenFileImg.Filter = "Template PDF|*.pdf"
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtPdfTemplate3D.Text = OpenFileImg.FileName
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

    Private Sub lnkGeneraTemplate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGeneraTemplate.LinkClicked

        If MessageBox.Show("Vuoi generare automaticamente il template per questo formato prodotto?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim nomefiletmp As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf")

            FormerLib.FormerHelper.PDF.CreaPdfInFormato(nomefiletmp, txtLarghezza.Text, txtLunghezza.Text,,, 10)

            txtPdfTemplate.Text = nomefiletmp

        End If

    End Sub

    Private Sub chkIsRotolo_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsRotolo.CheckedChanged
        If chkIsRotolo.Checked Then
            chkIsLastra.Checked = False
        End If
    End Sub

    Private Sub chkIsLastra_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsLastra.CheckedChanged
        If chkIsLastra.Checked Then
            chkIsRotolo.Checked = False
        End If
    End Sub
End Class