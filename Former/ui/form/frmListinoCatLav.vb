Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerConfig

Friend Class frmListinoCatLav
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Private _IdCatLav As Integer = 0

    Friend Function Carica(Optional IdCatLav As Integer = 0) As Integer

        _IdCatLav = IdCatLav

        CaricaCombo()

        If IdCatLav Then
            Using C As New CatLav
                C.Read(IdCatLav)
                txtDescrizione.Text = C.Descrizione
                MgrControl.SelectIndexComboEnum(cmbTipoControllo, C.TipoControllo)
                MgrControl.SelectIndexComboEnum(cmbReparto, C.RepartoAppartenenza)
                txtOrdEsec.Text = C.OrdineEsecuzione
                If C.TipoCaratteristica = enSiNo.Si Then
                    chkCaratteristica.Checked = True
                End If
                If C.SovrascriviImgScheda = enSiNo.Si Then
                    chkSovrascriviImg.Checked = True
                End If
                If C.FileLavNonSelezionata.Length Then
                    txtImgLav.Text = C.FileLavNonSelezionata
                    Try
                        pctImgLav.Image = Image.FromFile(C.FileLavNonSelezionata)
                    Catch ex As Exception
                        MessageBox.Show("Non sono riuscito a caricare l'immagine associata")
                    End Try
                End If
            End Using

            UcListinoImpatto.CalcolaSuCategoriaLavorazione(IdCatLav)
        Else
            MgrControl.SelectIndexComboEnum(cmbTipoControllo, enTipoControllo.RadioButton)
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Dim TipoControllo As cEnum

        TipoControllo = New cEnum
        TipoControllo.Id = enTipoControllo.RadioButton
        TipoControllo.Descrizione = "Radio Button"
        cmbTipoControllo.Items.Add(TipoControllo)

        TipoControllo = New cEnum
        TipoControllo.Id = enTipoControllo.ComboBox
        TipoControllo.Descrizione = "Combo Box"
        cmbTipoControllo.Items.Add(TipoControllo)

        TipoControllo = New cEnum
        TipoControllo.Id = enTipoControllo.CheckBox
        TipoControllo.Descrizione = "Check Box"
        cmbTipoControllo.Items.Add(TipoControllo)

        'CARICO I REPARTI
        Dim Campo As FormerLib.cEnum

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Tutto)
        Campo.Descrizione = "Tutti"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.StampaOffset)
        Campo.Descrizione = "Stampa OffSet"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.StampaDigitale)
        Campo.Descrizione = "Stampa Digitale"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Packaging)
        Campo.Descrizione = "Packaging"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Ricamo)
        Campo.Descrizione = "Ricamo"
        cmbReparto.Items.Add(Campo)

        Campo = New FormerLib.cEnum
        Campo.Id = CInt(enRepartoWeb.Etichette)
        Campo.Descrizione = "Etichette"
        cmbReparto.Items.Add(Campo)

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim GiaEsistente As Boolean = False

        If _IdCatLav = 0 Then
            Using mgr As New CatLavDAO
                Dim l As List(Of CatLav) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.CatLav.Descrizione, txtDescrizione.Text))
                If l.Count Then
                    GiaEsistente = True
                End If
            End Using
        End If
        If GiaEsistente = False Then
            If MessageBox.Show("Confermi il salvataggio della Categoria?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Using C As New CatLav
                    If _IdCatLav Then
                        C.Read(_IdCatLav)
                    End If

                    C.Descrizione = txtDescrizione.Text.Trim
                    C.TipoControllo = DirectCast(cmbTipoControllo.SelectedItem, cEnum).Id
                    C.RepartoAppartenenza = DirectCast(cmbReparto.SelectedItem, cEnum).Id
                    C.TipoCaratteristica = IIf(chkCaratteristica.Checked, enSiNo.Si, enSiNo.No)
                    C.SovrascriviImgScheda = IIf(chkSovrascriviImg.Checked, enSiNo.Si, enSiNo.No)
                    C.OrdineEsecuzione = txtOrdEsec.Text
                    If C.IsValid Then
                        'copio l'immagine nella cartella centralizzata
                        If txtImgLav.Text.Length Then
                            If txtImgLav.Text <> C.FileLavNonSelezionata Then
                                Dim nuovoNome As String = String.Empty
                                If txtImgLav.Text.StartsWith(FormerPath.PathListinoImg) Then
                                    'non devo copiare
                                    nuovoNome = txtImgLav.Text
                                Else
                                    'devo copiare 
                                    Dim F As New FileInfo(txtImgLav.Text)
                                    nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgLav.Text),, C.Descrizione)
                                    MgrIO.FileCopia(Me, txtImgLav.Text, nuovoNome)
                                End If
                                C.FileLavNonSelezionata = nuovoNome
                            End If
                        End If

                        C.Save()
                        _Ris = 1
                        Close()
                    Else
                        MessageBox.Show("Inserisci tutti i dati richiesti.", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End If
        Else
            MessageBox.Show("La categoria che si tenta di inserire esiste già")
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgLav.Text = OpenFileImg.FileName
            Try
                pctImgLav.Image = Image.FromFile(txtImgLav.Text)
            Catch ex As Exception
                MessageBox.Show("Non sono riuscito a caricare l'immagine associata")
            End Try

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
End Class