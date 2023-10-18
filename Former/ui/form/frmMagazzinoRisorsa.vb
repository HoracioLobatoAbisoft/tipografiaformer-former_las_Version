Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerConfig
Imports System.IO
Imports Telerik.WinControls.UI
Imports FormerBusinessLogicInterface

Friend Class frmMagazzinoRisorsa
    'Inherits baseFormInterna
    Private _Ris As Integer

    Private _Risorsa As Risorsa

    Public Function Carica(Optional IdRis As Integer = 0) As Integer
        Dim R As New Risorsa
        If IdRis Then
            R.Read(IdRis)

            Me.Text = "Former - Risorsa " & R.IdRis

        End If
        Return Carica(R)
    End Function

    Private Sub SelezionaGruppi()
        For Each g As RisorsaInGruppo In _Risorsa.Gruppi
            Dim item As RadCheckedListDataItem = cmbGruppo.FindItemExact(g.NomeGruppo, False)

            item.Checked = True
        Next
    End Sub

    Public Function Carica(ByRef objRis As Risorsa) As Integer

        _Risorsa = objRis


        CaricaCombo()

        'TabMain.TabPages.Remove(tbFornitori)

        If _Risorsa.IdRis Then
            Me.Text = "Former - Risorsa " & _Risorsa.IdRis
            txtCodice.Text = _Risorsa.Codice
            txtDescr.Text = _Risorsa.Descrizione
            MgrControl.SelectIndexCombo(cmbTipoRis, _Risorsa.TipoRis)
            MgrControl.SelectIndexCombo(cmbTipoOff, CInt(_Risorsa.IsLastra))

            MgrControl.SelectIndexCombo(cmbTipoCarta, _Risorsa.IdTipoCarta)
            MgrControl.SelectIndexComboEnum(cmbUnitaMisura, _Risorsa.IdUnitaMisura)

            'txtCostoFoglioFormato.Text = _Risorsa.CostoFoglioFormato
            txtCostoFoglioSteso.Text = _Risorsa.CostoFoglioSteso
            txtCostoVenduto.Text = _Risorsa.CostoVenduto
            txtCostoTotale.Text = _Risorsa.CostoTotale
            txtNumLastre.Text = _Risorsa.Nlastre
            txtLarghezza.Text = _Risorsa.Larghezza
            txtLunghezza.Text = _Risorsa.Lunghezza
            txtGrammatura.Text = _Risorsa.Grammatura

            txtGiacenza.Text = _Risorsa.Giacenza
            txtGiacenzaMin.Text = _Risorsa.GiacenzaMin

            cmbCategoria.Text = _Risorsa.Categoria

            UcMagazzinoMgrMovimenti.IdRis = _Risorsa.IdRis

            txtBarCode.Text = _Risorsa.BarCode
            txtFoto.Text = _Risorsa.imgPath

            UcMagazzinoDecodificaVociCosto.IdRis = _Risorsa.IdRis

            If txtFoto.Text.Length Then
                Try
                    pctFoto.Image = Image.FromFile(txtFoto.Text)
                Catch ex As Exception

                End Try

            End If

            If _Risorsa.ProdottoFinito = enSiNo.Si Then
                chkProdottoFinito.Checked = True
            End If

            'UcMagaz.CaricaMov()

            For Each Rs As RisorsaSuMacchina In _Risorsa.ListaMacchinari
                Dim IdPos As Integer = 0
                For Each item As Macchinario In chkLstMacchinari.Items
                    If item.IdMacchinario = Rs.IdMacchinario Then
                        chkLstMacchinari.SetItemChecked(IdPos, True)
                        Exit For
                    End If
                    IdPos += 1
                Next
            Next

            'cmbDest.SelectedIndex = 0
            cmbListini.SelectedIndex = 0
            chkStatoAttivo.Checked = IIf(_Risorsa.Stato = enStato.Attivo, True, False)

            If Not _Risorsa.RegolaSottoScorta Is Nothing Then
                If _Risorsa.RegolaSottoScorta.Azione = enAzioneSottoScorta.RichiestaDiAcquisto Then
                    rdoSSInviaMessaggio.Checked = True
                    '       MgrControl.SelectIndexCombo(cmbDest, _Risorsa.RegolaSottoScorta.IdDestMessaggio)
                    '      chkStampaPromemoria.Checked = IIf(_Risorsa.RegolaSottoScorta.StampareReminder = enSiNo.Si, True, False)
                ElseIf _Risorsa.RegolaSottoScorta.Azione = enAzioneSottoScorta.RiOrdina Then
                    rdoSSRiordina.Checked = True
                    MgrControl.SelectIndexCombo(cmbListini, _Risorsa.RegolaSottoScorta.IdListinoBase)
                    txtQta.Text = _Risorsa.RegolaSottoScorta.QtaOrdine
                    txtFilePDF.Text = _Risorsa.RegolaSottoScorta.PathFile
                End If
            End If
            SelezionaGruppi()
        Else
            MgrControl.SelectIndexCombo(cmbTipoRis, enTipoProdCom.StampaOffSet)
            TabMain.TabPages.Remove(tbMovimenti)
            TabMain.TabPages.Remove(tpSottoScorta)
            TabMain.TabPages.Remove(tpDecodificaVociCosto)

            txtCodice.Text = _Risorsa.Codice
            txtDescr.Text = _Risorsa.Descrizione

            lblCostoTotale.Visible = False
            lblCostoFoglioEsteso.Visible = False
            txtCostoTotale.Visible = False
            txtCostoFoglioSteso.Visible = False

            chkStatoAttivo.Checked = True
            lnkRicalcola.Visible = False

            MgrControl.SelectIndexComboEnum(cmbUnitaMisura, enUnitaDiMisura.Pezzi)

        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Dim TipoProd As New cTipoProdCom(True)
        cmbTipoRis.DataSource = TipoProd
        cmbTipoRis.ValueMember = "Id"
        cmbTipoRis.DisplayMember = "Descrizione"

        Dim TipoOffSet As New cTipoRisOffSet
        cmbTipoOff.DataSource = TipoOffSet
        cmbTipoOff.ValueMember = "Id"
        cmbTipoOff.DisplayMember = "Descrizione"

        CaricaTipoCarta()

        Using M As New MacchinariDAO
            chkLstMacchinari.ValueMember = "IdMacchinario"
            chkLstMacchinari.DisplayMember = "Descrizione"
            chkLstMacchinari.DataSource = M.GetAll(LFM.Macchinario.Tipo.Name & "," & LFM.Macchinario.Descrizione.Name)
        End Using

        Dim lUM As New List(Of cEnum)
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.Pezzi, .Descrizione = "Pezzi"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.kg, .Descrizione = "Kg"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.l, .Descrizione = "litri"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.m, .Descrizione = "m"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.m2, .Descrizione = "m2"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.m3, .Descrizione = "m3"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.cm, .Descrizione = "cm"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.cm2, .Descrizione = "cm2"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.cm3, .Descrizione = "cm3"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.mm, .Descrizione = "mm"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.bobina, .Descrizione = "Bobina"})
        lUM.Add(New cEnum With {.Id = enUnitaDiMisura.lastra, .Descrizione = "Lastra"})

        cmbUnitaMisura.DisplayMember = "Descrizione"
        cmbUnitaMisura.ValueMember = "Id"
        cmbUnitaMisura.DataSource = lUM


        'Using mgr As New UtentiDAO
        '    Dim l2 As List(Of Utente) = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "Login", .AddEmptyItem = False})
        '    cmbDest.ValueMember = "IdUt"
        '    cmbDest.DisplayMember = "Login"
        '    cmbDest.DataSource = l2
        'End Using

        Using mgr As New ListinoBaseDAO
            Dim lLb As List(Of ListinoBase) = mgr.FindAll(LFM.ListinoBase.Nome)
            cmbListini.DisplayMember = "Nome"
            cmbListini.ValueMember = "IdListinoBase"
            cmbListini.DataSource = lLb
        End Using

        Using mgr As New RisorseDAO
            Dim l As List(Of String) = mgr.GetCategorie()

            cmbCategoria.DataSource = l

        End Using

        CaricaGruppi()

    End Sub

    Private Sub CaricaGruppi()

        Using mgr As New GruppoRisorsaDAO
            Dim l As List(Of GruppoRisorsa) = mgr.GetAll(LFM.GruppoRisorsa.Nome)
            cmbGruppo.DisplayMember = LFM.GruppoRisorsa.Nome.Name
            cmbGruppo.ValueMember = LFM.GruppoRisorsa.IdGruppoRisorsa.Name

            cmbGruppo.DataSource = l

        End Using

    End Sub

    Private Sub CaricaTipoCarta(Optional IdDaSelezionare As Integer = 0)
        Using mgr As New TipiCartaDAO
            cmbTipoCarta.DataSource = mgr.GetAll(LFM.TipoCarta.Tipologia, True)
            cmbTipoCarta.ValueMember = "IdTipoCarta"
            cmbTipoCarta.DisplayMember = "Riassunto"
        End Using

        If IdDaSelezionare Then
            MgrControl.SelectIndexCombo(cmbTipoCarta, IdDaSelezionare)
        End If

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub cmbTipoProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoRis.SelectedIndexChanged

        Try
            NascondiControlli()

            If cmbTipoRis.SelectedIndex <> -1 Then

                Dim x As cEnum = cmbTipoRis.SelectedItem
                Select Case x.Id
                    Case enTipoProdCom.StampaOffSet
                        txtLunghezza.Visible = True
                        txtLarghezza.Visible = True
                        lblLarghezza.Visible = True
                        lblLunghezza.Visible = True
                        cmbTipoOff.Visible = True
                        lblTipoOffset.Visible = True
                        lblGrammatura.Visible = True
                        txtGrammatura.Visible = True
                        ClickTipoOffset()
                        lblReparto.Text = "Stampa Offset"
                        lblReparto.BackColor = FormerColori.GetColoreReparto(x.Id)
                        lblCategoria.Visible = False
                        cmbCategoria.Visible = False

                    Case enTipoProdCom.StampaDigitale
                        'abilito larghezza e lunghezza
                        txtLunghezza.Visible = True
                        txtLarghezza.Visible = True
                        lblLarghezza.Visible = True
                        lblLunghezza.Visible = True
                        btnNewTipo.Visible = True
                        btnDettTipo.Visible = True
                        cmbTipoOff.Visible = True
                        lblTipoOffset.Visible = True
                        txtCostoFoglioSteso.Visible = True
                        txtCostoVenduto.Visible = True
                        lblCostoFoglioEsteso.Visible = True
                        lblCostoVenduto.Visible = True
                        lblGrammatura.Visible = True
                        txtGrammatura.Visible = True

                        lblReparto.Text = "Stampa Digitale"
                        lblReparto.BackColor = FormerColori.GetColoreReparto(x.Id)
                        pctRep.Image = My.Resources._RepDigitale
                        lblCategoria.Visible = True
                        cmbCategoria.Visible = True

                        lblTipoCarta.Visible = True
                        cmbTipoCarta.Visible = True
                        btnNewTipo.Visible = True
                        btnDettTipo.Visible = True

                    Case enTipoProdCom.Etichette
                        txtLunghezza.Visible = True
                        txtLarghezza.Visible = True
                        lblLarghezza.Visible = True
                        lblLunghezza.Visible = True
                        btnNewTipo.Visible = True
                        btnDettTipo.Visible = True
                        cmbTipoOff.Visible = True
                        lblTipoOffset.Visible = True
                        lblReparto.Text = "Etichette"
                        lblGrammatura.Visible = True
                        txtGrammatura.Visible = True

                        lblReparto.BackColor = FormerColori.GetColoreReparto(x.Id)
                        pctRep.Image = My.Resources._RepEtichette
                        lblCategoria.Visible = True
                        cmbCategoria.Visible = True

                        lblTipoCarta.Visible = True
                        cmbTipoCarta.Visible = True
                        btnNewTipo.Visible = True
                        btnDettTipo.Visible = True

                    Case enTipoProdCom.Ricamo
                        txtLunghezza.Visible = True
                        txtLarghezza.Visible = True
                        lblLarghezza.Visible = True
                        lblLunghezza.Visible = True
                        btnNewTipo.Visible = True
                        btnDettTipo.Visible = True
                        cmbTipoOff.Visible = True
                        lblTipoOffset.Visible = True
                        lblReparto.Text = "Ricamo"
                        lblGrammatura.Visible = True
                        txtGrammatura.Visible = True

                        lblReparto.BackColor = FormerColori.GetColoreReparto(x.Id)
                        pctRep.Image = My.Resources._RepRicamo
                        lblCategoria.Visible = True
                        cmbCategoria.Visible = True

                        lblTipoCarta.Visible = True
                        cmbTipoCarta.Visible = True
                        btnNewTipo.Visible = True
                        btnDettTipo.Visible = True

                    Case enTipoProdCom.Packaging
                        txtLunghezza.Visible = True
                        txtLarghezza.Visible = True
                        lblLarghezza.Visible = True
                        lblLunghezza.Visible = True
                        btnNewTipo.Visible = True
                        btnDettTipo.Visible = True
                        cmbTipoOff.Visible = True
                        lblTipoOffset.Visible = True
                        lblReparto.Text = "Packaging"
                        lblReparto.BackColor = FormerColori.GetColoreReparto(x.Id)
                        pctRep.Image = My.Resources._RepPackaging
                        lblGrammatura.Visible = True
                        txtGrammatura.Visible = True
                        lblCategoria.Visible = True
                        cmbCategoria.Visible = True

                        lblTipoCarta.Visible = True
                        cmbTipoCarta.Visible = True
                        btnNewTipo.Visible = True
                        btnDettTipo.Visible = True

                    Case enTipoProdCom.Consumo
                        lblReparto.Text = "Consumo"
                        lblReparto.BackColor = Color.Gray
                        pctRep.Image = My.Resources._RepConsumo
                        lblCategoria.Visible = True
                        cmbCategoria.Visible = True

                        lblTipoCarta.Visible = False
                        cmbTipoCarta.Visible = False
                        btnNewTipo.Visible = False
                        btnDettTipo.Visible = False

                        'pnlLastre.Visible = True
                End Select

            End If
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub
    Private Sub NascondiControlli()

        cmbTipoOff.Visible = False
        'txtCostoFoglioFormato.Visible = False
        txtCostoFoglioSteso.Visible = False
        txtCostoVenduto.Visible = False
        txtNumLastre.Visible = False
        txtLarghezza.Visible = False
        txtLunghezza.Visible = False

        lblTipoOffset.Visible = False
        'lblCostoFoglioFormato.Visible = False
        lblCostoFoglioEsteso.Visible = False
        lblCostoVenduto.Visible = False
        lblNumLastre.Visible = False
        lblLarghezza.Visible = False
        lblLunghezza.Visible = False

        lblTipoCarta.Visible = False
        cmbTipoCarta.Visible = False
        btnNewTipo.Visible = False
        btnDettTipo.Visible = False

        lblGrammatura.Visible = False
        txtGrammatura.Visible = False

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Salvataggio()

    End Sub

    Private Sub Salvataggio()


        Dim x As New cRisorseColl

        If x.Exists(txtCodice.Text, _Risorsa.IdRis) Then

            MessageBox.Show("Il codice inserito è già utilizzato per un altra risorsa!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else
            Dim OkSalvataggio As Boolean = True
            Dim BufferGiaEsistenti As String = String.Empty

            If cmbTipoRis.SelectedItem.id = enTipoRisOffSet.Lastra Then
                If chkLstMacchinari.CheckedItems.Count = 0 Then
                    OkSalvataggio = False
                End If
            Else
                'qui non è una lastra
                'se non è un prodotto di consumo devo obbligare il tipo carta a listino 
                'e controllare che a parita di misure e grammatura non ne esista un altra gia in magazzino 

                If cmbTipoRis.SelectedItem.id <> enTipoProdCom.NonSpecificato AndAlso
                   cmbTipoRis.SelectedItem.id <> enTipoProdCom.Consumo Then
                    If cmbTipoCarta.SelectedValue = 0 Then
                        OkSalvataggio = False
                    Else
                        'vado a fare il check
                        Using mgr As New RisorseDAO
                            Dim lCheck As List(Of Risorsa) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Risorsa.IdTipoCarta, cmbTipoCarta.SelectedValue),
                                                                         New LUNA.LunaSearchParameter(LFM.Risorsa.Grammatura, txtGrammatura.Text),
                                                                         New LUNA.LSP(LFM.Risorsa.Lunghezza, txtLunghezza.Text.Replace(",", ".")),
                                                                         New LUNA.LSP(LFM.Risorsa.Larghezza, txtLarghezza.Text.Replace(",", ".")),
                                                                         New LUNA.LSP(LFM.Risorsa.IdRis, _Risorsa.IdRis, "<>"))
                            If lCheck.Count Then
                                For Each voce In lCheck
                                    BufferGiaEsistenti &= "(" & voce.IdRis & ") " & voce.Descrizione & ControlChars.NewLine
                                Next
                                If _Risorsa.IdRis Then
                                    If MessageBox.Show("Sono già presenti in magazzino una o più risorsa/e con le stesse dimensioni e grammatura e lo stesso tipocarta a listino: " & ControlChars.NewLine & BufferGiaEsistenti & ControlChars.NewLine & "Vuoi salvare comunque la risorsa?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then

                                        OkSalvataggio = False
                                        'BufferGiaEsistenti = String.Empty

                                    End If
                                Else
                                    OkSalvataggio = False
                                End If

                            End If
                        End Using

                    End If
                End If

            End If

            If OkSalvataggio Then
                If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    _Risorsa.Codice = txtCodice.Text
                    _Risorsa.Descrizione = txtDescr.Text
                    ' _Risorsa.CostoFoglioFormato = txtCostoFoglioFormato.Text
                    _Risorsa.CostoFoglioSteso = txtCostoFoglioSteso.Text
                    _Risorsa.CostoTotale = txtCostoTotale.Text
                    _Risorsa.CostoVenduto = txtCostoVenduto.Text
                    _Risorsa.IsLastra = cmbTipoOff.SelectedItem.id
                    _Risorsa.Larghezza = txtLarghezza.Text
                    _Risorsa.Lunghezza = txtLunghezza.Text
                    _Risorsa.Nlastre = txtNumLastre.Text
                    _Risorsa.TipoRis = cmbTipoRis.SelectedItem.id
                    _Risorsa.IdTipoCarta = cmbTipoCarta.SelectedValue
                    _Risorsa.GiacenzaMin = txtGiacenzaMin.Text
                    _Risorsa.Grammatura = txtGrammatura.Text
                    _Risorsa.ProdottoFinito = IIf(chkProdottoFinito.Checked, enSiNo.Si, enSiNo.No)
                    _Risorsa.Stato = IIf(chkStatoAttivo.Checked, enStato.Attivo, enStato.NonAttivo)
                    _Risorsa.Categoria = cmbCategoria.Text
                    _Risorsa.BarCode = txtBarCode.Text.Trim
                    _Risorsa.IdUnitaMisura = cmbUnitaMisura.SelectedValue

                    If _Risorsa.IsValid Then

                        'copio l'immagine nella cartella centralizzata
                        If txtFoto.Text.Length Then
                            If txtFoto.Text <> _Risorsa.imgPath Then
                                Dim nuovoNome As String = String.Empty
                                If txtFoto.Text.StartsWith(FormerPath.PathImgRisorse) Then
                                    'non devo copiare
                                    nuovoNome = txtFoto.Text
                                Else
                                    'devo copiare 
                                    Dim F As New FileInfo(txtFoto.Text)
                                    nuovoNome = FormerPath.PathImgRisorse & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtFoto.Text))
                                    MgrIO.FileCopia(Me, txtFoto.Text, nuovoNome)
                                End If
                                _Risorsa.imgPath = nuovoNome
                            End If

                        End If

                        Dim IdIns As Integer
                        Dim IdPrec As Integer = _Risorsa.IdRis

                        IdIns = _Risorsa.Save()

                        Using mgr As New RisorseSuMacchinaDAO
                            mgr.DeleteForRisorsa(_Risorsa.IdRis)
                        End Using

                        'If _Risorsa.IsLastra Then
                        For Each Item As Macchinario In chkLstMacchinari.CheckedItems
                            Dim RsM As New RisorsaSuMacchina
                            RsM.IdMacchinario = Item.IdMacchinario
                            RsM.IdRisorsa = _Risorsa.IdRis
                            RsM.Save()
                        Next
                        'End If

                        Using mgr As New RisorsaInGruppoDAO
                            mgr.DeleteForRisorsa(_Risorsa.IdRis)
                        End Using

                        For Each selecteditem In cmbGruppo.CheckedItems
                            Using RiG As New RisorsaInGruppo
                                RiG.IdRisorsa = _Risorsa.IdRis
                                RiG.IdGruppo = selecteditem.Value
                                RiG.Save()
                            End Using
                        Next

                        If rdoSSNoAzioni.Checked Then
                            If Not _Risorsa.RegolaSottoScorta Is Nothing Then
                                Using mgr As New AzioniSottoscortaDAO
                                    mgr.Delete(_Risorsa.RegolaSottoScorta.IdRegola)
                                End Using
                            End If
                        ElseIf rdoSSInviaMessaggio.Checked Then
                            Dim r As AzioneSottoscorta = _Risorsa.RegolaSottoScorta
                            If r Is Nothing Then
                                r = New AzioneSottoscorta
                            End If
                            r.IdRisorsa = _Risorsa.IdRis
                            r.Azione = enAzioneSottoScorta.RichiestaDiAcquisto
                            'r.IdDestMessaggio = cmbDest.SelectedValue
                            'r.StampareReminder = IIf(chkStampaPromemoria.Checked, enSiNo.Si, enSiNo.No)
                            r.Save()

                        ElseIf rdoSSRiordina.Checked Then
                            Dim r As AzioneSottoscorta = _Risorsa.RegolaSottoScorta
                            If r Is Nothing Then
                                r = New AzioneSottoscorta
                            End If
                            r.IdRisorsa = _Risorsa.IdRis
                            r.Azione = enAzioneSottoScorta.RiOrdina
                            r.IdListinoBase = cmbListini.SelectedValue
                            r.QtaOrdine = txtQta.Text
                            If txtFilePDF.Text.Length Then
                                If txtFilePDF.Text <> r.PathFile Then
                                    Dim nuovoNome As String = String.Empty
                                    If txtFilePDF.Text.StartsWith(FormerPath.PathSorgentiRiOrdinoRisorse) Then
                                        'non devo copiare
                                        nuovoNome = txtFilePDF.Text
                                    Else
                                        'devo copiare 
                                        Dim F As New FileInfo(txtFilePDF.Text)
                                        nuovoNome = FormerPath.PathSorgentiRiOrdinoRisorse & FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf")
                                        MgrIO.FileCopia(Me, txtFilePDF.Text, nuovoNome)
                                    End If
                                    r.PathFile = nuovoNome
                                End If

                            End If
                            r.Save()

                        End If


                        'If IdPrec = 0 Then
                        '    If MessageBox.Show("Vuoi inserire il primo movimento di registrazione per questa risorsa?", "Primo Inserimento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        '        TabMain.TabPages.Add(tbMovimenti)
                        '        TabMain.SelectedTab = tbMovimenti
                        '        UcMagaz.IdRis = IdIns
                        '        UcMagaz.CallPrimoInserimento()
                        '    End If
                        'End If

                        _Ris = IdIns
                        Close()
                    Else
                        MessageBox.Show("I campi Codice e Descrizione sono obbligatori! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                If BufferGiaEsistenti.Length = 0 Then
                    MessageBox.Show("Per la CARTA selezionare il tipo carta a listino a cui va associata; Per le LASTRE è obbligatorio scegliere almeno un macchinario a cui vanno associate!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    If _Risorsa.IdRis = 0 Then
                        MessageBox.Show("Sono già presenti in magazzino una o più risorsa/e con le stesse dimensioni e grammatura e lo stesso tipocarta a listino: " & ControlChars.NewLine & BufferGiaEsistenti, PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                End If
            End If


        End If

    End Sub

    Private Sub cmbTipoOff_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoOff.SelectedIndexChanged
        ClickTipoOffset()
    End Sub

    Private Sub ClickTipoOffset()

        Try
            If cmbTipoOff.SelectedIndex <> -1 Then
                Dim x As cEnum = cmbTipoOff.SelectedItem
                Select Case x.Id
                    Case enTipoRisOffSet.MateriaPrima
                        lblTipoCarta.Visible = True
                        cmbTipoCarta.Visible = True
                        btnNewTipo.Visible = True
                        btnDettTipo.Visible = True
                        txtCostoFoglioSteso.Visible = True
                        'txtCostoFoglioFormato.Visible = True
                        ' lblCostoFoglioFormato.Visible = True
                        lblCostoFoglioEsteso.Visible = True
                        txtNumLastre.Visible = False
                        lblNumLastre.Visible = False
                        'pnlLastre.Visible = False
                        pctRep.Image = My.Resources._RepStampaOffset

                    Case enTipoRisOffSet.Lastra
                        lblTipoCarta.Visible = False
                        cmbTipoCarta.Visible = False
                        btnNewTipo.Visible = False
                        btnDettTipo.Visible = False
                        txtCostoFoglioSteso.Visible = False
                        ' txtCostoFoglioFormato.Visible = False
                        ' lblCostoFoglioFormato.Visible = False
                        lblCostoFoglioEsteso.Visible = False
                        txtNumLastre.Visible = True
                        lblNumLastre.Visible = True
                        'pnlLastre.Visible = True
                        pctRep.Image = My.Resources._RepLastre
                End Select
            End If
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Private Sub UcMagaz_AggiornataQta()

        _Ris = 1
        Using R As New RisorseDAO
            R.LeggiQta(_Risorsa)
        End Using
        txtGiacenza.Text = _Risorsa.Giacenza

    End Sub

    Private Sub txtCodice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodice.KeyPress

        ControlloCodice(sender, e)

    End Sub

    Private Sub btnNewTipo_Click(sender As Object, e As EventArgs) Handles btnNewTipo.Click

        Sottofondo()

        Dim ris As Integer = 0

        Using f As New frmListinoTipoCarta
            ris = f.Carica()
        End Using

        If ris Then
            CaricaTipoCarta(ris)
        End If

        Sottofondo()

    End Sub

    Private Sub btnDettTipo_Click(sender As Object, e As EventArgs) Handles btnDettTipo.Click

        If cmbTipoCarta.SelectedValue Then
            Sottofondo()

            Dim ris As Integer = 0

            Using f As New frmListinoTipoCarta
                ris = f.Carica(cmbTipoCarta.SelectedValue)
            End Using

            If ris Then
                CaricaTipoCarta(ris)
            End If

            Sottofondo()
        Else
            MessageBox.Show("Selezionare un Tipo Carta")
        End If

    End Sub

    Private Sub lnkPeso_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPeso.LinkClicked
        Sottofondo()
        Using x As New frmCalcPeso
            x.Carica()
        End Using
        Sottofondo()

    End Sub

    Private Sub btnSearchPdf_Click(sender As Object, e As EventArgs) Handles btnSearchPdf.Click
        OpenFilePDF.ShowDialog()

        If OpenFilePDF.FileName.Length Then
            txtFilePDF.Text = OpenFilePDF.FileName
        End If
    End Sub

    Private Sub UcMagaz_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub UcMagaz_RicalcolataGiacenza(NuovaGiacenza As Integer)

        _Risorsa.Giacenza = NuovaGiacenza
        txtGiacenza.Text = _Risorsa.Giacenza

    End Sub

    Private Sub lnkRicalcola_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRicalcola.LinkClicked

        RicalcolaGiacenza()

    End Sub

    Private Sub RicalcolaGiacenza()

        'ricalcolo la giacenza della risorsa selezionata

        If MessageBox.Show("Confermi il ricalcolo della giacenza della risorsa in base ai movimenti di magazzino presenti?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim NewGiacenza As Single = 0

            NewGiacenza = MgrMagazzino.RicalcolaGiacenza(_Risorsa.IdRis)

            'RaiseEvent RicalcolataGiacenza(NewGiacenza)
            txtGiacenza.Text = NewGiacenza

            MessageBox.Show("Giacenza ricalcolata. Nuova giacenza: " & NewGiacenza)

        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        OpenFileImg.ShowDialog()

        Try
            If OpenFileImg.FileName.Length Then
                txtFoto.Text = OpenFileImg.FileName
                pctFoto.Image = Image.FromFile(txtFoto.Text)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lnkImporta_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        Dim Ris As String = String.Empty

        Sottofondo()
        Using f As New frmOpenIMG
            Ris = f.Carica()
        End Using
        Sottofondo()

        If Ris.Length Then
            txtFoto.Text = Ris
            pctFoto.Image = Image.FromFile(Ris)
        End If

    End Sub

    Private Sub UcMagazzinoMgrMovimenti_Load(sender As Object, e As EventArgs) Handles UcMagazzinoMgrMovimenti.Load


    End Sub

    Private Sub UcMagazzinoMgrMovimenti_CambiatoQualcosa() Handles UcMagazzinoMgrMovimenti.CambiatoQualcosa

        Dim NewGiacenza As Integer = 0

        NewGiacenza = MgrMagazzino.RicalcolaGiacenza(_Risorsa.IdRis)

        'RaiseEvent RicalcolataGiacenza(NewGiacenza)
        txtGiacenza.Text = NewGiacenza
        _Ris = _Risorsa.IdRis

    End Sub

    Private Sub txtGiacenzaMin_TextChanged(sender As Object, e As EventArgs) Handles txtGiacenzaMin.TextChanged
        If txtGiacenzaMin.Value > 0 Then
            rdoSSInviaMessaggio.Checked = True
        Else
            rdoSSInviaMessaggio.Checked = False
        End If

    End Sub

    Private Sub btnNewGruppo_Click(sender As Object, e As EventArgs) Handles btnNewGruppo.Click
        Dim Ris As String = InputBox("Inserisci il nome del gruppo che vuoi creare", "Nuovo Gruppo Risorsa")

        If Ris.Length Then
            Using Mgr As New GruppoRisorsaDAO
                Dim l As List(Of GruppoRisorsa) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.GruppoRisorsa.Nome, Ris))
                If l.Count = 0 Then
                    Using g As New GruppoRisorsa
                        g.Nome = Ris
                        g.Save()
                    End Using
                    CaricaGruppi()
                    SelezionaGruppi()
                End If
            End Using
        End If

    End Sub

    Private Sub txtLarghezza_TextChanged(sender As Object, e As EventArgs) Handles txtLarghezza.TextChanged, txtLunghezza.TextChanged
        Try
            Dim cm2 As Integer = MgrCalcoliTecnici.CalcolaCmQuadri(txtLarghezza.Text, txtLunghezza.Text)
            lblM2.Text = "(" & MgrCalcoliTecnici.DaCmQuadriAMetriQuadri(cm2) & " m^2)"
        Catch ex As Exception
            lblM2.Text = "-"
        End Try

    End Sub
End Class