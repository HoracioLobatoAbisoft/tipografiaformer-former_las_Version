Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerConfig

Friend Class frmListinoMacchinario
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _M As New Macchinario

    Private Sub CaricaUtentiAbilitati()

        Dim L As List(Of UtMac) = Nothing

        Using mgr As New UtMacDAO

            L = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.UtMac.IdMac, _M.IdMacchinario))

        End Using

    End Sub

    Friend Function Carica(Optional Id As Integer = 0) As Integer
        CaricaCombo()

        If Id Then

            _M.Read(Id)

            'ricarico i valori

            txtDescrizione.Text = _M.Descrizione
            MgrControl.SelectIndexCombo(cmbTipoMacc, _M.Tipo)
            txtCostoMinAvv.Text = _M.CostoMinAvv
            txtCostoSingCopia.Text = _M.CostoSingCopia
            txtMinutiAvv.Text = _M.MinutiAvv
            txtCostoMensile.Text = _M.CostoMensile
            txtCaricoPrevMensile.Text = _M.CaricoPrevistoMensile
            txtCopieOra.Text = _M.CopieOra
            txtImgLav.Text = _M.ImgRif
            txtAltCaricoCm.Text = _M.AltezzaCaricoCm
            txtOrdinamento.Text = _M.Ordinamento
            txtAlertCommesse.Text = _M.AlertCommesse
            txtPath.Text = _M.HotFolderFlusso

            txtDescrizioneOnline.Text = _M.DescrizioneOnline

            txtDescrizioneEstesa.Text = _M.DescrizioneEstesa
            txtImgGrande.Text = _M.ImgBig

            chkVisibileOnline.Checked = IIf(_M.VisibileOnline = enSiNo.Si, True, False)

            If _M.IdRepartoDefault Then
                MgrControl.SelectIndexComboEnum(cmbReparto, _M.IdRepartoDefault)
            Else
                cmbReparto.SelectedIndex = 0
            End If

            If txtImgLav.Text.Length Then
                Try
                    pctImgLav.Image = Image.FromFile(txtImgLav.Text)
                Catch ex As Exception

                End Try

            End If

            If txtImgGrande.Text.Length Then
                Try
                    pctImgBig.Image = Image.FromFile(txtImgGrande.Text)
                Catch ex As Exception

                End Try

            End If
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Dim M As New cEnum

        M.Id = enTipoMacchinario.Produzione
        M.Descrizione = "Produzione"

        Dim L As New List(Of cEnum)

        L.Add(M)

        Dim M2 As New cEnum
        M2.Id = enTipoMacchinario.Allestimento
        M2.Descrizione = "Allestimento"

        L.Add(M2)

        cmbTipoMacc.DataSource = L
        cmbTipoMacc.DisplayMember = "Descrizione"
        cmbTipoMacc.ValueMember = "Id"

        Dim LRep As New List(Of cEnum)
        Dim Rep As New cEnum
        Rep.Id = enRepartoWeb.Tutto
        Rep.Descrizione = "Nessuno"
        LRep.Add(Rep)

        Rep = New cEnum
        Rep.Id = enRepartoWeb.StampaOffset
        Rep.Descrizione = FormerEnumHelper.RepartoStr(Rep.Id)
        LRep.Add(Rep)

        Rep = New cEnum
        Rep.Id = enRepartoWeb.StampaDigitale
        Rep.Descrizione = FormerEnumHelper.RepartoStr(Rep.Id)
        LRep.Add(Rep)

        Rep = New cEnum
        Rep.Id = enRepartoWeb.Ricamo
        Rep.Descrizione = FormerEnumHelper.RepartoStr(Rep.Id)
        LRep.Add(Rep)

        Rep = New cEnum
        Rep.Id = enRepartoWeb.Packaging
        Rep.Descrizione = FormerEnumHelper.RepartoStr(Rep.Id)
        LRep.Add(Rep)

        Rep = New cEnum
        Rep.Id = enRepartoWeb.Etichette
        Rep.Descrizione = FormerEnumHelper.RepartoStr(Rep.Id)
        LRep.Add(Rep)

        cmbReparto.ValueMember = "Id"
        cmbReparto.DisplayMember = "Descrizione"
        cmbReparto.DataSource = LRep

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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgLav.Text = OpenFileImg.FileName
            pctImgLav.Image = Image.FromFile(txtImgLav.Text)
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _M.Descrizione = txtDescrizione.Text
            _M.Tipo = cmbTipoMacc.SelectedValue
            _M.CostoMinAvv = txtCostoMinAvv.Text
            _M.CostoSingCopia = txtCostoSingCopia.Text
            _M.MinutiAvv = txtMinutiAvv.Text
            _M.CostoMensile = txtCostoMensile.Text
            _M.CaricoPrevistoMensile = txtCaricoPrevMensile.Text
            _M.CopieOra = txtCopieOra.Text
            _M.AltezzaCaricoCm = txtAltCaricoCm.Text
            _M.Ordinamento = txtOrdinamento.Text
            _M.AlertCommesse = txtAlertCommesse.Text
            _M.HotFolderFlusso = txtPath.Text
            _M.DescrizioneOnline = txtDescrizioneOnline.Text
            _M.VisibileOnline = IIf(chkVisibileOnline.Checked, enSiNo.Si, enSiNo.No)

            _M.DescrizioneEstesa = txtDescrizioneEstesa.Text

            If _M.Tipo = enTipoMacchinario.Produzione Then
                _M.IdRepartoDefault = cmbReparto.SelectedValue
            Else
                _M.IdRepartoDefault = 0
            End If

            If _M.IsValid Then
                'copio l'immagine nella cartella centralizzata
                If txtImgLav.Text.Length Then
                    If txtImgLav.Text <> _M.ImgRif Then
                        Dim nuovoNome As String = String.Empty
                        If txtImgLav.Text.StartsWith(FormerPath.PathListinoImg) Then
                            'non devo copiare
                            nuovoNome = txtImgLav.Text
                        Else
                            'devo copiare 
                            Dim F As New FileInfo(txtImgLav.Text)
                            nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgLav.Text))
                            MgrIO.FileCopia(Me, txtImgLav.Text, nuovoNome)
                        End If
                        _M.ImgRif = nuovoNome
                    End If
                End If

                If txtImgGrande.Text.Length Then
                    If txtImgGrande.Text <> _M.ImgBig Then
                        Dim nuovoNome As String = String.Empty
                        If txtImgGrande.Text.StartsWith(FormerPath.PathListinoImg) Then
                            'non devo copiare
                            nuovoNome = txtImgGrande.Text
                        Else
                            'devo copiare 
                            Dim F As New FileInfo(txtImgGrande.Text)
                            nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgGrande.Text))
                            MgrIO.FileCopia(Me, txtImgGrande.Text, nuovoNome)
                        End If
                        _M.ImgBig = nuovoNome
                    End If
                End If

                _M.Save()
                _Ris = 1
                Close()

            Else
                MessageBox.Show("Inserisci tutti i dati richiesti.", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

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

    Private Sub btnHotFolder_Click(sender As Object, e As EventArgs) Handles btnHotFolder.Click

        Dim Ris As String = String.Empty
        If txtPath.Text.Trim.Length Then dlgFolder.SelectedPath = txtPath.Text
        If dlgFolder.ShowDialog = DialogResult.OK Then

            Ris = dlgFolder.SelectedPath
            txtPath.Text = Ris
        End If

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub txtImgLav_TextChanged(sender As Object, e As EventArgs) Handles txtImgLav.TextChanged

    End Sub

    Private Sub pctImgLav_Click(sender As Object, e As EventArgs) Handles pctImgLav.Click

    End Sub

    Private Sub OpenFileImg_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileImg.FileOk

    End Sub

    Private Sub cmbTipoMacc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMacc.SelectedIndexChanged

        'Dim Valore As cEnum = cmbTipoMacc.SelectedItem

        'If Valore.Id = enTipoMacchinario.Produzione Then
        '    cmbReparto.Enabled = True
        'Else
        '    cmbReparto.Enabled = False
        'End If
    End Sub

    Private Sub lnkImporta_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) 

        Dim Ris As String = String.Empty

        Sottofondo()
        Using f As New frmOpenIMG
            Ris = f.Carica()
        End Using
        Sottofondo()

        If Ris.Length Then
            txtImgLav.Text = Ris
            pctImgLav.Image = Image.FromFile(txtImgLav.Text)
        End If
    End Sub

    Private Sub btnSearchImgGrande_Click(sender As Object, e As EventArgs) Handles btnSearchImgGrande.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgGrande.Text = OpenFileImg.FileName
            pctImgBig.Image = Image.FromFile(txtImgGrande.Text)
        End If
    End Sub

    Private Sub UcPictureWizard_Load(sender As Object, e As EventArgs) Handles UcPictureWizard.Load

    End Sub

    Private Sub cmbReparto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReparto.SelectedIndexChanged
        Try
            lblTipo.BackColor = FormerColori.GetColoreReparto(cmbReparto.SelectedValue)

            Dim ColoreTesto As Color = Color.Black

            If cmbReparto.SelectedValue = enRepartoWeb.StampaOffset Or cmbReparto.SelectedValue = enRepartoWeb.Etichette Then
                ColoreTesto = Color.White
            End If

            lblTipo.ForeColor = ColoreTesto
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtDescrizione_TextChanged(sender As Object, e As EventArgs) Handles txtDescrizione.TextChanged
        lblTipo.Text = txtDescrizione.Text
    End Sub
End Class