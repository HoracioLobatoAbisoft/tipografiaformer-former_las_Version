Imports FormerDALSql
Imports System.IO
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerConfig

Friend Class frmListinoTipoCarta
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _TipoCarta As New TipoCarta

    Private Sub CaricaCombo()

        Using mgr As New TipiCartaDAO
            cmbFinitura.DataSource = mgr.ListaFiniture()
        End Using
        Dim Tipo = New cEnum

        Tipo.Id = enTipoCarta.Semplice
        Tipo.Descrizione = "Semplice"
        cmbTipo.Items.Add(Tipo)

        Tipo = New cEnum
        Tipo.Id = enTipoCarta.Composta
        Tipo.Descrizione = "Composta"
        cmbTipo.Items.Add(Tipo)

        CaricaTipoPrezzo()

    End Sub

    Private Sub CaricaRisorseCollegate()
        Dim l As List(Of Risorsa) = Nothing

        Using mgr As New RisorseDAO
            l = mgr.FindAll("Stato,Descrizione",
                            New LUNA.LunaSearchParameter(LFM.Risorsa.IsLastra, enSiNo.No),
                            New LUNA.LunaSearchParameter(LFM.Risorsa.IdTipoCarta, _TipoCarta.IdTipoCarta))

            '                New LUNA.LunaSearchParameter("TipoRis", enTipoProdCom.StampaOffSet), _
        End Using

        DgRiso.AutoGenerateColumns = False
        DgRiso.DataSource = l

    End Sub

    Friend Function Carica(Optional ByVal IdTipoCarta As Integer = 0) As Integer

        CaricaCombo()

        If IdTipoCarta Then

            _TipoCarta.Read(IdTipoCarta)
            txtDescrizione.Text = _TipoCarta.Tipologia
            cmbFinitura.Text = _TipoCarta.Finitura
            txtImgLav.Text = _TipoCarta.ImgRif
            txtGrammi.Text = _TipoCarta.Grammi
            txtSigla.Text = _TipoCarta.Sigla
            txtAltezza.Text = _TipoCarta.Altezza
            txtLarghezza.Text = _TipoCarta.Larghezza
            txtPrezzoKg.Text = _TipoCarta.CostoCartaKg
            txtMicron.Text = _TipoCarta.Spessore
            MgrControl.SelectIndexComboEnum(cmbTipo, _TipoCarta.TipoCarta)
            txtDescEst.Text = _TipoCarta.DescrizioneEstesa
            txtCostoRif.Text = _TipoCarta.CostoRiferimento
            txtPath.Text = _TipoCarta.HotFolder

            UcListinoImpatto.CalcolaSuTipoCarta(IdTipoCarta)

            If txtImgLav.Text.Length Then
                Try
                    pctImgLav.Image = Image.FromFile(txtImgLav.Text)
                Catch ex As Exception

                End Try

            End If

            MgrControl.SelectIndexComboEnum(cmbTipoPrezzo, _TipoCarta.TipoCosto)

            CaricaComposizioni()
            CaricaRisorseCollegate()
        Else
            cmbTipoPrezzo.SelectedIndex = 0
            cmbTipo.SelectedIndex = 0
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaTipoPrezzo()

        Dim N As New cEnum
        N.Id = enTipoPrezzo.SuQuantita
        N.Descrizione = "Su Kg"
        cmbTipoPrezzo.Items.Add(N)

        'N = New cEnum'TODO:MODIFICATOTIPOPREZZO
        'N.Id = enTipoPrezzo.SuCopie
        'N.Descrizione = "Al pezzo"
        'cmbTipoPrezzo.Items.Add(N)

        N = New cEnum
        N.Id = enTipoPrezzo.SuFoglio
        N.Descrizione = "Al pezzo"
        cmbTipoPrezzo.Items.Add(N)

        N = New cEnum
        N.Id = enTipoPrezzo.SuMetriQuadri
        N.Descrizione = "Su Metri Quadri"
        cmbTipoPrezzo.Items.Add(N)

    End Sub

    Private Sub CaricaComposizioni()
        lstTipiCarta.Items.Clear()
        For Each cs As ComposizioneCarta In _TipoCarta.ComposizioniCarta
            Dim ris As Integer = lstTipiCarta.Items.Add(cs)
        Next

        If lstTipiCarta.Items.Count Then cmbTipo.SelectedIndex = 1
    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Function Salva() As Integer
        Dim ris As Integer = 0

        _TipoCarta.Tipologia = txtDescrizione.Text
        _TipoCarta.Finitura = cmbFinitura.Text
        _TipoCarta.Grammi = txtGrammi.Text
        _TipoCarta.Sigla = txtSigla.Text
        _TipoCarta.CostoCartaKg = txtPrezzoKg.Text
        _TipoCarta.Spessore = txtMicron.Text
        _TipoCarta.TipoCarta = DirectCast(cmbTipo.SelectedItem, cEnum).Id
        _TipoCarta.DescrizioneEstesa = txtDescEst.Text
        _TipoCarta.CostoRiferimento = txtCostoRif.Text
        _TipoCarta.Altezza = txtAltezza.Text
        _TipoCarta.Larghezza = txtLarghezza.Text
        _TipoCarta.TipoCosto = cmbTipoPrezzo.SelectedItem.id
        _TipoCarta.HotFolder = txtPath.Text

        If _TipoCarta.IsValid Then

            Dim lst As List(Of TipoCarta) = Nothing

            Using mgr As New TipiCartaDAO
                lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.TipoCarta.Sigla, _TipoCarta.Sigla),
                                  New LUNA.LunaSearchParameter(LFM.TipoCarta.IdTipoCarta, _TipoCarta.IdTipoCarta, "<>"))
            End Using

            If lst.Count Then
                'codice non univoco
                MessageBox.Show("La sigla inserita non è univoca! Cambiarla", "Former", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                'copio l'immagine nella cartella centralizzata
                If txtImgLav.Text.Length Then
                    If txtImgLav.Text <> _TipoCarta.ImgRif Then
                        Dim nuovoNome As String = String.Empty
                        If txtImgLav.Text.StartsWith(FormerPath.PathListinoImg) Then
                            'non devo copiare
                            nuovoNome = txtImgLav.Text
                        Else
                            'devo copiare 
                            Dim F As New FileInfo(txtImgLav.Text)
                            nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgLav.Text),, _TipoCarta.Tipologia)
                            MgrIO.FileCopia(Me, txtImgLav.Text, nuovoNome)
                        End If
                        _TipoCarta.ImgRif = nuovoNome
                    End If

                End If

                '_TipoCarta.Save()
                ris = _TipoCarta.Save()
                'Close()
            End If
        Else
            MessageBox.Show("Inserisci tutti i dati richiesti. Un tipo di carta semplice non può contenere tipi di Carta all'interno.", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Return ris
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Ris = Salva()
            If _Ris Then Close()

        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgLav.Text = OpenFileImg.FileName
            pctImgLav.Image = Image.FromFile(txtImgLav.Text)
        End If
    End Sub

    Private Sub txtGrammi_TextChanged(sender As Object, e As EventArgs) Handles txtGrammi.TextChanged
        CalcolaValori()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Sottofondo()

        Dim x As New frmListinoComposizioneCarta
        Dim ris As ComposizioneCarta = x.Carica(_TipoCarta)
        If Not ris Is Nothing Then
            'qui la devo aggiungere alla lista
            _TipoCarta.ComposizioniCarta.Add(ris)
            CaricaComposizioni()

        End If

        Sottofondo()
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If lstTipiCarta.SelectedIndex <> -1 Then
            If MessageBox.Show("Confermi la cancellazione della voce selezionata?", "Tipologia di Carta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'cancello la riga selezionata

                Dim p As ComposizioneCarta = DirectCast(lstTipiCarta.SelectedItem, ComposizioneCarta)

                _TipoCarta.ComposizioniCarta.Remove(p)

                lstTipiCarta.Items.RemoveAt(lstTipiCarta.SelectedIndex)

                If lstTipiCarta.Items.Count = 0 Then cmbTipo.SelectedIndex = 0

            End If
        End If
    End Sub

    Private Sub txtSigla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSigla.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSigla_TextChanged(sender As Object, e As EventArgs) Handles txtSigla.TextChanged

    End Sub

    Private Sub CalcolaValori()
        Try
            Dim PesoKg As Single = txtCostoRif.Text
            Dim TipoCosto As cEnum = DirectCast(cmbTipoPrezzo.SelectedItem, cEnum)

            If TipoCosto.Id = enTipoPrezzo.SuFoglio Then 'TODO:MODIFICATOTIPOPREZZO
                PesoKg = txtCostoRif.Text / (txtGrammi.Text / 1000)
            ElseIf TipoCosto.Id = enTipoPrezzo.SuMetriQuadri Then
                PesoKg = txtCostoRif.Text / (txtGrammi.Text / 1000)
            End If

            PesoKg = Math.Round(PesoKg, 2)

            txtPrezzoKg.Text = PesoKg
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbTipoPrezzo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPrezzo.SelectedIndexChanged

        CalcolaValori()

    End Sub

    Private Sub lnkAddRis_Click(sender As Object, e As EventArgs) Handles lnkAddRis.Click

        If DirectCast(cmbTipo.SelectedItem, cEnum).Id = enTipoCarta.Semplice Then
            Dim OkId As Boolean = False
            If _TipoCarta.IdTipoCarta = 0 Then
                If MessageBox.Show("Per aggiungere le risorse correlate è necessario salvare il TipoCarta. Continuare con il salvataggio?", "Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim Ris As Integer = 0

                    Ris = Salva()
                    If Ris Then
                        OkId = True
                    End If
                End If
            Else
                OkId = True
            End If

            If OkId Then
                'aggiungo 
                Sottofondo()
                Dim f As New frmListinoTipoCartaAddRes

                Dim ris As Integer = f.Carica(_TipoCarta.IdTipoCarta)

                If ris Then CaricaRisorseCollegate()

                Sottofondo()
            End If
        Else
            MessageBox.Show("Non è possibile collegare risorse a una carta composta")
        End If

    End Sub

    Private Sub txtCostoRif_TextChanged(sender As Object, e As EventArgs) Handles txtCostoRif.TextChanged
        CalcolaValori()
    End Sub

    Private Sub lnkSuggerisci_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSuggerisci.LinkClicked

        Dim listaPrezzi As New List(Of Decimal)

        Using mgr As New RisorseDAO
            Dim l As List(Of Risorsa) = mgr.FindAll(LFM.Risorsa.Descrizione,
                                                    New LUNA.LunaSearchParameter(LFM.Risorsa.IsLastra, enTipoRisOffSet.MateriaPrima),
                                                    New LUNA.LunaSearchParameter(LFM.Risorsa.IdTipoCarta, _TipoCarta.IdTipoCarta))

            For Each singRis As Risorsa In l

                Dim PrezzoMedio As Decimal = singRis.GetPrezzoMedioKgUltimoAnno
                If PrezzoMedio Then listaPrezzi.Add(PrezzoMedio)
            Next
            '                New LUNA.LunaSearchParameter("TipoRis", enTipoProdCom.StampaOffSet), _
        End Using

        If listaPrezzi.Count Then

            Dim PrezzoMedio As Decimal = 0

            For Each Prezzo As Decimal In listaPrezzi
                PrezzoMedio += Prezzo
            Next

            PrezzoMedio = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(PrezzoMedio / listaPrezzi.Count, 2)

            MessageBox.Show("Il prezzo medio delle risorse collegate a questo tipo carta è di € " & FormerHelper.Stringhe.FormattaPrezzo(PrezzoMedio) & "/kg")

        Else
            MessageBox.Show("Non ci sono prezzi di riferimento per le risorse collegate a questa tipologia di carta")
        End If

    End Sub

    Private Sub DgRiso_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgRiso.CellContentClick

    End Sub

    Private Sub DgRiso_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgRiso.CellDoubleClick

        If DgRiso.SelectedRows.Count Then

            Dim RisorsaSel As Risorsa = DgRiso.SelectedRows(0).DataBoundItem
            Dim Ris As Integer = 0
            Sottofondo()

            Using f As New frmMagazzinoRisorsa
                Ris = f.Carica(RisorsaSel)
            End Using

            Sottofondo()

            If Ris Then
                CaricaRisorseCollegate()
            End If


        End If

    End Sub

    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

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

    Private Sub btnRimuovi_Click(sender As Object, e As EventArgs) Handles btnRimuovi.Click

        If DgRiso.SelectedRows.Count Then

            If MessageBox.Show("Vuoi eliminare l'associazione con la risorsa selezionata?", "Elimina associazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Using Risorsa As Risorsa = DgRiso.SelectedRows(0).DataBoundItem
                    Risorsa.IdTipoCarta = 0
                    Risorsa.Save()
                End Using

                CaricaRisorseCollegate()

            End If

        Else
            MessageBox.Show("Selezionare una risorsa dalla lista")
        End If

    End Sub

    Private Sub OpenFileImg_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileImg.FileOk

    End Sub

    Private Sub btnHotFolder_Click(sender As Object, e As EventArgs) Handles btnHotFolder.Click

        Dim Ris As String = String.Empty
        If txtPath.Text.Trim.Length Then dlgFolder.SelectedPath = txtPath.Text
        If dlgFolder.ShowDialog = DialogResult.OK Then

            Ris = dlgFolder.SelectedPath
            txtPath.Text = Ris
        End If
    End Sub

End Class