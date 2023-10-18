Imports FormerDALSql
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerConfig

Friend Class frmListinoLavorazione
    'Inherits baseFormInternaFixed

    Private _Ris As Integer
    Private _Lav As New Lavorazione

    Private Function CheckCongruenzaPrezzi() As RisCongruenzaPrezziLavorazione

        Dim ris As New RisCongruenzaPrezziLavorazione

        ris.Esito = True

        If Not _Lav Is Nothing Then
            'qui sono ordinati per grandezza
            Dim pMin As PrezzoLavoro = _Lav.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Piccolo)
            Dim pMax As PrezzoLavoro = _Lav.Prezzi.Find(Function(x) x.TipoGrandezzaPrezzo = enTipoGrandezzaPrezzoLavorazione.Grande)

            'cerco il prezzo sul meno piu piccolo e il meno piu grande
            Dim Lp As New List(Of PrezzoLavoro)
            Lp.AddRange(_Lav.Prezzi.FindAll(Function(x) x.IdFormProd <> 0))
            'Lp.AddRange(L.Prezzi)
            If Lp.Count Then
                Lp.Sort(Function(x, y) x.FormatoCarta.Area.CompareTo(y.FormatoCarta.Area))
            End If

            If Not pMin Is Nothing Then Lp.Insert(0, pMin)
            If Not pMax Is Nothing Then Lp.Insert(Lp.Count, pMax)

            Dim ValorePrecedente As Decimal = 0

            For Each voce In Lp
                If voce.Prezzo >= ValorePrecedente Then
                    'tutto ok
                    ValorePrecedente = voce.Prezzo
                Else
                    'anomalia
                    ris.Esito = False
                    ris.BufferErrori &= "'" & voce.FormatoProdottoStr & "' non congruente; "
                    'Exit For
                End If
            Next
        End If
        Return ris
    End Function

    Private Sub CaricaCombo()

        'Dim TipoControllo As New cEnum
        'TipoControllo.Id = enTipoControllo.RadioButton
        'TipoControllo.Descrizione = FormerEnumHelper.TipoControlloString(enTipoControllo.RadioButton)
        'cmbControlloWeb.Items.Add(TipoControllo)

        'TipoControllo = New cEnum
        'TipoControllo.Id = enTipoControllo.ComboBox
        'TipoControllo.Descrizione = FormerEnumHelper.TipoControlloString(enTipoControllo.ComboBox)
        'cmbControlloWeb.Items.Add(TipoControllo)

        Dim TipoLav As cEnum

        TipoLav = New cEnum
        TipoLav.Id = enTipoLavorazione.suQuantita
        TipoLav.Descrizione = "Su Quantità"
        cmbTipoLav.Items.Add(TipoLav)

        TipoLav = New cEnum
        TipoLav.Id = enTipoLavorazione.suFoglio
        TipoLav.Descrizione = "Su Foglio"
        cmbTipoLav.Items.Add(TipoLav)

        TipoLav = New cEnum
        TipoLav.Id = enTipoLavorazione.suFacciata
        TipoLav.Descrizione = "Su Facciata"
        cmbTipoLav.Items.Add(TipoLav)

        TipoLav = New cEnum
        TipoLav.Id = enTipoLavorazione.UnaTantum
        TipoLav.Descrizione = "Una Tantum"
        cmbTipoLav.Items.Add(TipoLav)

        TipoLav = New cEnum
        TipoLav.Id = enTipoLavorazione.suMetriQuadri
        TipoLav.Descrizione = "Su Metri Quadri"
        cmbTipoLav.Items.Add(TipoLav)

        TipoLav = New cEnum
        TipoLav.Id = enTipoLavorazione.suMetriLineari
        TipoLav.Descrizione = "Su Metri Lineari"
        cmbTipoLav.Items.Add(TipoLav)

        TipoLav = New cEnum
        TipoLav.Id = enTipoLavorazione.suCmQuadri
        TipoLav.Descrizione = "Su Centimetri Quadri"
        cmbTipoLav.Items.Add(TipoLav)

        CaricaCatLav()

        CaricaMacchinari()

    End Sub

    Private Sub CaricaCatLav()

        Using mgr As New CatLavDAO
            Dim l As List(Of CatLav) = mgr.GetAll(LFM.CatLav.Descrizione, True)

            cmbCatLav.DataSource = l
            cmbCatLav.DisplayMember = "Descrizione"
            cmbCatLav.ValueMember = "IdCatLav"
        End Using

    End Sub

    Private Sub CaricaMacchinari()

        Dim lst As List(Of Macchinario) = Nothing

        Using mgr As New MacchinariDAO
            lst = mgr.FindAll(LFM.Macchinario.Descrizione)
        End Using

        cmbMacchinario.DataSource = lst
        cmbMacchinario.DisplayMember = "Riassunto"
        cmbMacchinario.ValueMember = "IdMacchinario"

        Dim lst2 As List(Of Macchinario) = Nothing

        Using mgr As New MacchinariDAO
            lst2 = mgr.FindAll(New LUNA.LSO With {.OrderBy = LFM.Macchinario.Descrizione.Name, .AddEmptyItem = True})
        End Using

        cmbMacchinario2.DataSource = lst2
        cmbMacchinario2.DisplayMember = "Riassunto"
        cmbMacchinario2.ValueMember = "IdMacchinario"

    End Sub

    Private _IdLav As Integer = 0

    Friend Function Carica(Optional ByVal IdLav As Integer = 0,
                           Optional Duplica As Boolean = False) As Integer
        _IdLav = IdLav
        CaricaCombo()

        If IdLav Then
            rdoAlfabetico.Checked = True
            _Lav.Read(IdLav)
            txtDescrizione.Text = _Lav.Descrizione
            'txtMacchinario.Text = _Lav.Macchinario
            txtPremio.Text = _Lav.Premio
            txtTempoRif.Text = _Lav.TempoRif
            'chkSuCom.Checked = _Lav.SuCommessa
            'chkSuProd.Checked = _Lav.SuProdotto
            txtSigla.Text = _Lav.Sigla
            txtMinGrammi.Text = _Lav.GrammiMin
            txtMaxGrammi.Text = _Lav.GrammiMax
            chkPubblica.Checked = _Lav.Pubblica
            txtImgLav.Text = _Lav.ImgRif
            txtImgLavZoom.Text = _Lav.ImgZoom
            chkEsclusiva.Checked = IIf(_Lav.Esclusiva = enSiNo.Si, True, False)
            chkSeDispSuSoggetti.Checked = IIf(_Lav.SePresenteCalcolaSuSoggetti = enSiNo.Si, True, False)
            rdoPreTaglio.Checked = IIf(_Lav.PreTaglio = enSiNo.Si, True, False)

            txtDimensMinW.Text = _Lav.DimensMinW
            txtDimensMinH.Text = _Lav.DimensMinH
            txtDimensMedieMinW.Text = _Lav.DimensMedieMinW
            txtDimensMedieMinH.Text = _Lav.DimensMedieMinH
            txtDimensMedieMaxW.Text = _Lav.DimensMedieMaxW
            txtDimensMedieMaxH.Text = _Lav.DimensMedieMaxH
            txtDimensMaxW.Text = _Lav.DimensMaxW
            txtDimensMaxH.Text = _Lav.DimensMaxH

            txtExtraData.Text = _Lav.ExtraData

            UcListinoImpatto.CalcolaSuLavorazione(IdLav)

            'txtPrezzoSingLav.Text = _Lav.CostoSingCopia
            txtDescEst.Text = _Lav.DescrizioneEstesa

            chkAccorpabile.Checked = IIf(_Lav.Accorpabile = enSiNo.Si, True, False)
            chkInterna.Checked = IIf(_Lav.LavorazioneInterna = enSiNo.Si, True, False)

            If txtImgLav.Text.Length Then
                Try
                    pctImgLav.Image = Image.FromFile(txtImgLav.Text)
                Catch ex As Exception

                End Try

            End If

            If txtImgLavZoom.Text.Length Then
                Try
                    pctImgLavZoom.Image = Image.FromFile(txtImgLavZoom.Text)
                Catch ex As Exception

                End Try

            End If

            MgrControl.SelectIndexCombo(cmbCatLav, _Lav.IdCatLav)
            MgrControl.SelectIndexCombo(cmbMacchinario, _Lav.IdMacchinario)
            MgrControl.SelectIndexCombo(cmbMacchinario2, _Lav.IdMacchinario2)
            MgrControl.SelectIndexComboEnum(cmbTipoLav, _Lav.IdTipoLav)
            'MgrControl.SelectIndexComboEnum(cmbControlloWeb, _Lav.TipoControlloWeb)

            CaricaPrezzi()
            lblAzione.Text = "Modifica"
            lblAzione.ForeColor = Color.Orange
            Text = "Former - " & IdLav & " - " & _Lav.Descrizione

            Try
                If Not _Lav.Categoria Is Nothing Then
                    lblTipo.BackColor = FormerColori.GetColoreReparto(_Lav.Categoria.RepartoAppartenenza)

                    Dim ColoreTesto As Color = Color.Black

                    If _Lav.Categoria.RepartoAppartenenza = enRepartoWeb.StampaOffset Or
                       _Lav.Categoria.RepartoAppartenenza = enRepartoWeb.Etichette Then
                        ColoreTesto = Color.White
                    End If

                    lblTipo.ForeColor = ColoreTesto
                End If

            Catch ex As Exception

            End Try

        Else
            Text = "Former - Lavorazione"
            lblAzione.Text = "Nuovo"
            lblAzione.ForeColor = Color.Green
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

    'Private Sub txtPremio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPremio.KeyPress
    '    MgrControl.ControlloNumerico(sender, e)
    'End Sub

    'Private Sub txtTempoRif_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTempoRif.KeyPress
    '    MgrControl.ControlloNumerico(sender, e, True)
    'End Sub


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim DimensioniCoerenti As Boolean = True

        If txtDimensMinH.Value >= txtDimensMaxH.Value OrElse txtDimensMinW.Value >= txtDimensMaxW.Value Then
            DimensioniCoerenti = False
        End If

        If DimensioniCoerenti Then
            Dim OkCheck As Boolean = True
            Dim VaiAvanti As Boolean = False

            Dim risultato As RisCongruenzaPrezziLavorazione = CheckCongruenzaPrezzi()

            If risultato.Esito = False Then
                If MessageBox.Show("I seguenti prezzi NON sono congruenti: " & ControlChars.NewLine & risultato.BufferErrori & ControlChars.NewLine & "Continuare?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    OkCheck = False
                Else
                    VaiAvanti = True
                End If
            End If

            If OkCheck Then
                If VaiAvanti = True OrElse MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim M As Macchinario = cmbMacchinario.SelectedItem
                    Dim M2 As Macchinario = cmbMacchinario2.SelectedItem

                    If Not M Is Nothing Then
                        Dim ErroreDoppione As Boolean = False

                        If Not M2 Is Nothing Then
                            If M.IdMacchinario = M2.IdMacchinario Then
                                ErroreDoppione = True
                            End If
                        End If

                        If ErroreDoppione = False Then
                            If cmbTipoLav.SelectedItem Is Nothing Then
                                MessageBox.Show("Selezionare il tipo di lavorazione")
                            Else
                                _Lav.Descrizione = txtDescrizione.Text
                                _Lav.Macchinario = M.Descrizione
                                _Lav.Premio = txtPremio.Text
                                _Lav.TempoRif = txtTempoRif.Text
                                '_Lav.SuCommessa = chkSuCom.Checked
                                '_Lav.SuProdotto = chkSuProd.Checked
                                _Lav.Esclusiva = IIf(chkEsclusiva.Checked, enSiNo.Si, enSiNo.No)
                                _Lav.SePresenteCalcolaSuSoggetti = IIf(chkSeDispSuSoggetti.Checked, enSiNo.Si, enSiNo.No)
                                _Lav.Pubblica = chkPubblica.Checked
                                _Lav.IdCatLav = cmbCatLav.SelectedValue
                                _Lav.Sigla = txtSigla.Text
                                _Lav.GrammiMin = txtMinGrammi.Text
                                _Lav.GrammiMax = txtMaxGrammi.Text
                                ' _Lav.CostoSingCopia = txtPrezzoSingLav.Text
                                _Lav.IdMacchinario = M.IdMacchinario

                                If M2 Is Nothing Then
                                    _Lav.IdMacchinario2 = 0
                                Else
                                    _Lav.IdMacchinario2 = M2.IdMacchinario
                                End If

                                _Lav.IdTipoLav = DirectCast(cmbTipoLav.SelectedItem, cEnum).Id
                                _Lav.DescrizioneEstesa = txtDescEst.Text
                                _Lav.Accorpabile = IIf(chkAccorpabile.Checked, enSiNo.Si, enSiNo.No)
                                _Lav.LavorazioneInterna = IIf(chkInterna.Checked, enSiNo.Si, enSiNo.No)
                                '_Lav.TipoControlloWeb = DirectCast(cmbControlloWeb.SelectedItem, cEnum).Id

                                _Lav.PreTaglio = IIf(rdoPreTaglio.Checked, enSiNo.Si, enSiNo.No)
                                _Lav.DimensMinW = txtDimensMinW.Text
                                _Lav.DimensMinH = txtDimensMinH.Text
                                _Lav.DimensMedieMinW = txtDimensMedieMinW.Text
                                _Lav.DimensMedieMinH = txtDimensMedieMinH.Text
                                _Lav.DimensMedieMaxW = txtDimensMedieMaxW.Text
                                _Lav.DimensMedieMaxH = txtDimensMedieMaxH.Text
                                _Lav.DimensMaxW = txtDimensMaxW.Text
                                _Lav.DimensMaxH = txtDimensMaxH.Text
                                _Lav.ExtraData = txtExtraData.Text

                                If _Lav.IsValid Then

                                    Dim lst As List(Of Lavorazione) = Nothing
                                    Using mgr As New LavorazioniDAO
                                        lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Lavorazione.Sigla, _Lav.Sigla),
                                                          New LUNA.LunaSearchParameter(LFM.Lavorazione.IdLavoro, _Lav.IdLavoro, "<>"))
                                    End Using
                                    If lst.Count Then
                                        'codice non univoco
                                        MessageBox.Show("La sigla inserita non è univoca! Cambiarla", "Former", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Else
                                        'copio l'immagine nella cartella centralizzata
                                        If txtImgLav.Text.Length Then
                                            If txtImgLav.Text <> _Lav.ImgRif Then
                                                Dim nuovoNome As String = String.Empty
                                                If txtImgLav.Text.StartsWith(FormerPath.PathListinoImg) Then
                                                    'non devo copiare
                                                    nuovoNome = txtImgLav.Text
                                                Else
                                                    'devo copiare 
                                                    Dim F As New FileInfo(txtImgLav.Text)
                                                    nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgLav.Text),, _Lav.Descrizione)
                                                    MgrIO.FileCopia(Me, txtImgLav.Text, nuovoNome)
                                                End If
                                                _Lav.ImgRif = nuovoNome
                                            End If
                                        End If

                                        If txtImgLavZoom.Text.Length Then
                                            If txtImgLavZoom.Text <> _Lav.ImgZoom Then
                                                Dim nuovoNome As String = String.Empty
                                                If txtImgLavZoom.Text.StartsWith(FormerPath.PathListinoImg) Then
                                                    'non devo copiare
                                                    nuovoNome = txtImgLavZoom.Text
                                                Else
                                                    'devo copiare 
                                                    Dim F As New FileInfo(txtImgLavZoom.Text)
                                                    nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgLavZoom.Text),, _Lav.Descrizione)
                                                    MgrIO.FileCopia(Me, txtImgLavZoom.Text, nuovoNome)
                                                End If
                                                _Lav.ImgZoom = nuovoNome
                                            End If
                                        End If

                                        _Lav.Save()
                                        _Ris = 1
                                        Close()
                                    End If
                                Else
                                    MessageBox.Show("Inserisci tutti i dati richiesti.", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        Else
                            MessageBox.Show("I macchinari di produzione selezionati sono uguali")
                        End If


                    Else
                        MessageBox.Show("Selezionare il macchinario!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If

        Else
            MessageBox.Show("Le dimensioni inserite non risultano coerenti!")
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgLav.Text = OpenFileImg.FileName
            pctImgLav.Image = Image.FromFile(txtImgLav.Text)
        End If
    End Sub

    Private Sub btnMacch_Click(sender As Object, e As EventArgs) Handles btnMacch.Click
        Sottofondo()
        Dim x As New frmListinoMacchinario

        Dim OldValue As Integer = cmbMacchinario.SelectedValue
        If x.Carica(OldValue) Then
            CaricaMacchinari()
            MgrControl.SelectIndexCombo(cmbMacchinario, OldValue)
        End If

        x = Nothing
        Sottofondo()

    End Sub

    Private Sub pctNewCatLav_Click(sender As Object, e As EventArgs) Handles pctNewCatLav.Click

        Sottofondo()
        Using x As New frmListinoCatLav

            If x.Carica() Then
                CaricaCatLav()
            End If

        End Using
        Sottofondo()

    End Sub

    Private Sub CaricaPrezzi()
        'lstPrezzi.Items.Clear()

        '_Lav.Prezzi.Sort(Function(x, y) x.Riassunto.CompareTo(y.Riassunto))
        'For Each P As PrezzoLavoro In _Lav.Prezzi
        '    Dim ris As Integer = lstPrezzi.Items.Add(P)
        'Next

        If rdoAlfabetico.Checked Then
            _Lav.Prezzi.Sort(AddressOf FormerListSorter.PrezziLavorazioneSorter.SortNomeFormato)
        Else


            _Lav.Prezzi.Sort(AddressOf FormerListSorter.PrezziLavorazioneSorter.SortAreaFormato)


        End If


        DgPrezzi.DataSource = Nothing
        DgPrezzi.Refresh()

        DgPrezzi.AutoGenerateColumns = False

        'Try
        '    Dim A As New Size(txtDimensMinW.Text, txtDimensMinH.Text)
        '    Dim B As New Size(txtDimensMedieMinW.Text, txtDimensMedieMinH.Text)
        '    Dim C As New Size(txtDimensMedieMaxW.Text, txtDimensMedieMaxH.Text)
        '    Dim D As New Size(txtDimensMaxW.Text, txtDimensMaxH.Text)
        '    _Lav.ApplicaMisureLavtoPrezzi(A, B, C, D)

        'Catch ex As Exception

        'End Try

        DgPrezzi.DataSource = _Lav.Prezzi

    End Sub

    Private Sub btnAddListBase_Click(sender As Object, e As EventArgs) Handles btnAddListBase.Click

        Sottofondo()

        Dim x As New frmListinoPrezzoLavorazione
        Dim ris As PrezzoLavoro = Nothing
        Dim risultato As Integer = x.Carica(_Lav, ris)
        If risultato Then
            'qui la devo aggiungere alla lista
            _Lav.Prezzi.Add(ris)
            CaricaPrezzi()
        End If

        Sottofondo()

    End Sub

    Private Sub btnDelListBase_Click(sender As Object, e As EventArgs) Handles btnDelListBase.Click

        If DgPrezzi.SelectedRows.Count Then
            If MessageBox.Show("Confermi la cancellazione del prezzo selezionato?", "Prezzi lavorazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'cancello la riga selezionata

                Dim p As PrezzoLavoro = DgPrezzi.SelectedRows(0).DataBoundItem
                _Lav.Prezzi.Remove(p)
                CaricaPrezzi()

            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub btnDuplica_Click(sender As Object, e As EventArgs) Handles btnDuplica.Click
        If DgPrezzi.SelectedRows.Count Then

            Dim P As PrezzoLavoro = DgPrezzi.SelectedRows(0).DataBoundItem

            Dim PNew As PrezzoLavoro = P.Clone
            PNew.IdLavPrezzo = 0
            PNew.IdFormProd = 0

            Sottofondo()

            Dim x As New frmListinoPrezzoLavorazione
            Dim ris As Integer = x.Carica(_Lav, PNew, True)
            If ris Then
                'qui la devo aggiungere alla lista
                _Lav.Prezzi.Add(PNew)
                CaricaPrezzi()
            End If

            Sottofondo()
        Else
            Beep()

        End If


    End Sub

    Private Sub btnModifica_Click(sender As Object, e As EventArgs) Handles btnModifica.Click
        ModificaVoce()
    End Sub

    Private Sub DgPrezzi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgPrezzi.CellContentClick

    End Sub

    Private Sub DgPrezzi_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgPrezzi.CellDoubleClick
        ModificaVoce()
    End Sub

    Private Sub ModificaVoce()

        'riapro la combinazione di prezzo
        If DgPrezzi.SelectedRows.Count Then
            Dim P As PrezzoLavoro = DgPrezzi.SelectedRows(0).DataBoundItem

            Sottofondo()

            Dim x As New frmListinoPrezzoLavorazione
            Dim ris As Integer = x.Carica(_Lav, P)
            If ris Then
                'qui la devo aggiungere alla lista
                '_Lav.Prezzi.Add(ris)
                Dim Ptrov As PrezzoLavoro = _Lav.Prezzi.Find(Function(xx) xx.IdFormProd = P.IdFormProd And xx.TipoGrandezza = P.TipoGrandezza)
                _Lav.Prezzi.Remove(Ptrov)
                _Lav.Prezzi.Add(P)
                CaricaPrezzi()
            End If

            Sottofondo()

        Else
            Beep()

        End If

    End Sub

    Private Sub txtSigla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSigla.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSigla_TextChanged(sender As Object, e As EventArgs) Handles txtSigla.TextChanged

    End Sub

    Private Sub chkEsclusiva_CheckedChanged(sender As Object, e As EventArgs) Handles chkEsclusiva.CheckedChanged

        If chkEsclusiva.Checked = True Then
            chkAccorpabile.Checked = True
        End If

    End Sub

    Private Sub btnEditCatLav_Click(sender As Object, e As EventArgs) Handles btnEditCatLav.Click

        Sottofondo()
        Using x As New frmListinoCatLav

            Dim OldValue As Integer = cmbCatLav.SelectedValue
            If x.Carica(OldValue) Then
                CaricaCatLav()
                MgrControl.SelectIndexCombo(cmbCatLav, OldValue)
            End If

        End Using
        Sottofondo()

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub
    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub btnSearchZoom_Click(sender As Object, e As EventArgs) Handles btnSearchZoom.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgLavZoom.Text = OpenFileImg.FileName
            pctImgLavZoom.Image = Image.FromFile(txtImgLavZoom.Text)
        End If
    End Sub

    Private Sub btnExtraData_Click(sender As Object, e As EventArgs) Handles btnExtraData.Click

        Sottofondo()
        Dim Ris As String = String.Empty

        Using f As New frmListinoManageExtraData
            Ris = f.Carica(txtExtraData.Text)
        End Using

        If Ris.Length Then
            txtExtraData.Text = Ris
        End If

        Sottofondo()
        'If txtExtraData.Text.Length Then
        '    MessageBox.Show("ExtraData: " & txtExtraData.Text)
        'Else
        '    MessageBox.Show("Non sono presenti ExtraData")
        'End If
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

    Private Sub btnMacch2_Click(sender As Object, e As EventArgs) Handles btnMacch2.Click
        Sottofondo()
        Dim x As New frmListinoMacchinario

        Dim OldValue As Integer = cmbMacchinario2.SelectedValue

        If OldValue Then
            If x.Carica(OldValue) Then
                CaricaMacchinari()
                MgrControl.SelectIndexCombo(cmbMacchinario2, OldValue)
            End If
        Else
            Beep()

        End If


        x = Nothing
        Sottofondo()
    End Sub

    Private Sub txtDimensMinW_TextChanged(sender As Object, e As EventArgs) Handles txtDimensMinW.TextChanged,
             txtDimensMinH.TextChanged,
              txtDimensMedieMinW.TextChanged,
               txtDimensMedieMinH.TextChanged,
              txtDimensMedieMaxW.TextChanged,
               txtDimensMedieMaxH.TextChanged,
                txtDimensMaxW.TextChanged,
                 txtDimensMaxW.TextChanged
        If sender.focused Then
            CaricaPrezzi()
        End If

    End Sub

    Private Sub btnCalcola_Click(sender As Object, e As EventArgs)
        Sottofondo()

        Using f As New frmCalcPrezzoLavorazioni
            f.Carica(_IdLav)
        End Using

        Sottofondo()

    End Sub

    Private Sub txtLarghezzaSim_TextChanged(sender As Object, e As EventArgs)
        SimulaPrezzo()
    End Sub

    Private Sub SimulaPrezzo()

    End Sub

    Private Sub txtAltezzaSim_TextChanged(sender As Object, e As EventArgs)
        SimulaPrezzo()
    End Sub

    Private Sub txtQtaSim_TextChanged(sender As Object, e As EventArgs)
        SimulaPrezzo()
    End Sub

    Private Sub btnCalcola_Click_1(sender As Object, e As EventArgs) Handles btnCalcola.Click

        If _IdLav Then

            Using f As New frmCalcPrezzoLavorazioni
                f.Carica(_IdLav)
            End Using

        Else
            MessageBox.Show("Per calcolare i prezzi la lavorazione deve essere salvata")

        End If

    End Sub

    Private Sub txtDescrizione_TextChanged(sender As Object, e As EventArgs) Handles txtDescrizione.TextChanged
        lblTipo.Text = txtDescrizione.Text
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click

        Dim risultato As RisCongruenzaPrezziLavorazione = CheckCongruenzaPrezzi()

        If risultato.Esito Then
            MessageBox.Show("I prezzi sono congruenti")
        Else
            MessageBox.Show("I prezzi NON sono congruenti: " & ControlChars.NewLine & risultato.BufferErrori)
        End If

    End Sub

    Private Sub rdoAlfabetico_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAlfabetico.CheckedChanged,
                                                                                       rdoGrandezza.CheckedChanged

        If sender.focused Then CaricaPrezzi()

    End Sub
End Class