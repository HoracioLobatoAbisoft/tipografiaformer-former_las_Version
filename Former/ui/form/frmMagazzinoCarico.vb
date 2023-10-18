Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogicInterface

Friend Class frmMagazzinoCarico
    'Inherits baseFormInternaRedim

    Private _Ris As Integer
    Private _IdMov As Integer
    Private _Mov As New MovimentoMagazzino

    Private _QtaDisp As Integer
    Private _OldQta As Integer = 0

    Private _IdRis As Integer
    Public Property IdRis() As Integer
        Get
            Return _IdRis
        End Get
        Set(ByVal value As Integer)
            _IdRis = value
        End Set
    End Property

    'Private _IdFat As Integer = 0
    'Public Property IDFat() As Integer
    '    Get
    '        Return _IdFat
    '    End Get
    '    Set(ByVal value As Integer)
    '        _IdFat = value
    '    End Set
    'End Property

    Private _IdForn As Integer
    Public Property IDForn() As Integer
        Get
            Return _IdForn
        End Get
        Set(ByVal value As Integer)
            _IdForn = value
        End Set
    End Property

    Private _OnlyManual As Boolean = True
    Public Property OnlyManual() As Boolean
        Get
            Return _OnlyManual
        End Get
        Set(ByVal value As Boolean)
            _OnlyManual = value
        End Set
    End Property

    Private _IdCom As Integer
    Public Property IdCom() As Integer
        Get
            Return _IdCom
        End Get
        Set(ByVal value As Integer)
            _IdCom = value
        End Set
    End Property
    Private _TipoMov As enTipoMovMagaz = enTipoMovMagaz.Carico
    Public Property TipoMov() As enTipoMovMagaz
        Get
            Return _TipoMov
        End Get
        Set(ByVal value As enTipoMovMagaz)
            _TipoMov = value
        End Set
    End Property

    Private _MaxQta As Integer
    Public Property MaxQta() As Integer
        Get
            Return _MaxQta
        End Get
        Set(ByVal value As Integer)
            _MaxQta = value
        End Set
    End Property

    Private Sub CaricaCombo()

        Dim TipoProd As New cTipoMovMagaz(_OnlyManual)
        cmbTipoMov.DataSource = TipoProd
        cmbTipoMov.ValueMember = "Id"
        cmbTipoMov.DisplayMember = "Descrizione"

        Using mgr As New RisorseDAO
            Dim l As List(Of String) = mgr.GetCategorie()

            cmbCategoria.DataSource = l

        End Using

        CaricaRisorse()

    End Sub

    Private Sub CaricaRisorse(Optional IdRis As Integer = 0)

        Using mgr As New RisorseDAO
            Dim p As LUNA.LSP = Nothing
            Dim pDescr As LUNA.LSP = Nothing

            Dim AddEmpty As Boolean = True

            If cmbCategoria.Text.Trim.Length Then
                p = New LUNA.LSP(LFM.Risorsa.Categoria, cmbCategoria.Text)
                AddEmpty = False
            End If

            If txtCercaRis.Text.Trim.Length Then
                pDescr = New LUNA.LSP(LFM.Risorsa.Descrizione, "%" & txtCercaRis.Text.Trim & "%", "LIKE")
                AddEmpty = False
            End If

            Dim l As List(Of Risorsa) = mgr.FindAll(New LUNA.LSO With {.OrderBy = LFM.Risorsa.Descrizione.Name, .AddEmptyItem = AddEmpty}, p, pDescr)
            'cmbRis.DataSource = l
            'cmbRis.ValueMember = "IdRis"
            'cmbRis.DisplayMember = "Descrizione"
            cmbRisorsa.DisplayMember = "VoceComboText"
            cmbRisorsa.ValueMember = "VoceComboIdRis"
            cmbRisorsa.DataSource = l
        End Using

        If IdRis Then
            'MgrControl.SelectIndexCombo(cmbRis, IdRis)
            MgrControl.SelectIndexCombo(cmbRisorsa, IdRis)
        End If

    End Sub

    Private _IdCaricoDiMagazzino As Integer = 0
    Private _IdVoceCosto As Integer = 0

    Friend Function Carica(Optional ByVal IdMov As Integer = 0,
                           Optional ByRef Mag As MovimentoMagazzino = Nothing,
                           Optional ByVal ForzaTipo As enTipoMovMagaz = 0,
                           Optional ByVal IdFat As Integer = 0,
                           Optional ByVal IdCaricoDiMagazzino As Integer = 0,
                           Optional IdVoceCosto As Integer = 0) As Integer

        _IdCaricoDiMagazzino = IdCaricoDiMagazzino
        _IdVoceCosto = IdVoceCosto
        _IdFat = IdFat
        _IdMov = IdMov

        CaricaCombo()

        If _IdRis Then

            'qui mi passa l'id risorsa e quindi la blocco a quella impostata
            Dim ris As New Risorsa

            ris.Read(_IdRis)
            'cmbRis.ValueMember = "IdRis"
            'cmbRis.DisplayMember = "Descrizione"

            _QtaDisp = ris.Giacenza

            'cmbRis.Items.Add(ris)

            ris = Nothing
            MgrControl.SelectIndexCombo(cmbRisorsa, _IdRis)
            'grpRisorsa.Enabled = False
            lnkNew.Enabled = False
            grpCerca.Visible = False
            cmbRisorsa.Enabled = False
            txtCercaRis.Enabled = False
            cmbCategoria.Enabled = False
            pctSblocca.Visible = True

        Else
            CercaRisorsa()
        End If

        If _IdFat Then
            ' se carico una fattura faccio di sicuro un carico e quindi disattivo la combo 
            cmbTipoMov.Enabled = False
            cmbTipoMov.BackColor = Color.White
            MgrControl.SelectIndexCombo(cmbTipoMov, enTipoMovMagaz.Carico)

            Using r As New Costo
                r.Read(_IdFat)

                lblFatt.Text = r.TipoDocStr & " " & r.Numero & "/" & r.AnnoStr & " del " & r.DataCosto.ToString("dd/MM/yyyy") & " - " & r.Fornitore.RagSocNome

            End Using

        End If

        If _IdVoceCosto Then
            Using vc As New VoceCosto
                vc.Read(_IdVoceCosto)
                txtQta.Text = vc.Qta
                txtDescrForn.Text = vc.Descrizione
                txtPrezzo.Text = vc.Totale
                txtCodiceForn.Text = vc.Codice

                CalcolaPrezzoUnit()
                CalcolaPesoEPrezzoKg()
            End Using
        End If

        If _IdMov Then

            _Mov.Read(_IdMov)
            MgrControl.SelectIndexCombo(cmbTipoMov, _Mov.TipoMov)
            txtQta.Text = _Mov.Qta
            txtPrezzo.Text = _Mov.Prezzo
            txtPrezzoUnit.Text = _Mov.PrezzoUnit
            txtCodiceForn.Text = _Mov.CodiceForn
            txtDescrForn.Text = _Mov.DescrForn
            _OldQta = _Mov.Qta

            'If _Mov.IdFat Then
            '    lnkRiapriDoc.Visible = True
            'End If
        Else
            If ForzaTipo Then
                MgrControl.SelectIndexCombo(cmbTipoMov, ForzaTipo)
                cmbTipoMov.Enabled = False
            Else
                MgrControl.SelectIndexCombo(cmbTipoMov, _TipoMov)
            End If

        End If

        If _TipoMov = enTipoMovMagaz.Prenotazione Then
            cmbTipoMov.Enabled = False
        End If

        SendKeys.Send(vbTab)

        ShowDialog()

        Mag = _Mov

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

    Private Sub txtPrezzo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrezzo.TextChanged, txtQta.TextChanged
        If sender.focus Then
            If sender.text.length = 0 Then
                sender.text = "0"
            End If
            CalcolaPrezzoUnit()
        End If

        CalcolaPesoEPrezzoKg()

    End Sub

    Private Sub CalcolaPesoEPrezzoKg()
        Try
            Dim IdRis As Integer = cmbRisorsa.SelectedValue
            If IdRis Then
                Dim Peso As Single = 0
                Dim PrezzoAlKg As Decimal = 0
                Dim PrezzoTot As Decimal = txtPrezzo.Text
                Dim Qta As Integer = txtQta.Text

                Using R As New Risorsa
                    R.Read(IdRis)

                    Peso = MgrPreventivazioneB.CalcolaKgCarta(R.Lunghezza, R.Larghezza, R.Grammatura, Qta)

                End Using

                PrezzoAlKg = PrezzoTot / Peso

                txtPesoKg.Text = Math.Round(Peso, 2)
                txtPrezzoKg.Text = FormerHelper.Stringhe.FormattaPrezzo(PrezzoAlKg)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalcolaPrezzoUnit()
        Dim PrezzoUnit As Decimal = 0

        Try

            Dim prezzo As Decimal = CDec(txtPrezzo.Text)
            Dim qta As Single = txtQta.Text

            PrezzoUnit = prezzo / qta

        Catch ex As Exception
            PrezzoUnit = 0
        End Try

        txtPrezzoUnit.Text = PrezzoUnit
    End Sub

    Private Sub ResetCampi()
        cmbRisorsa.SelectedIndex = 0
        txtCodiceForn.Text = String.Empty
        txtDescrForn.Text = String.Empty
        txtQta.Text = 1
        txtPrezzo.Text = 0
        txtPrezzoUnit.Text = 0
    End Sub

    Private Sub CercaRisorsa()
        'una risorsa la cerco solo dal carico di magazzino
        'che avviene sempre dopo che ho gia scelto il fornitore
        'e un fornitore ha un solo prodotto con quel codice

        If _IdVoceCosto = 0 Then ResetCampi()

        Dim TestoDaCercare As String = txtCerca.Text

        Dim RisorseColl As New cRisorseColl, DT As DataTable
        DT = RisorseColl.Cerca(TestoDaCercare, _IdForn)

        If DT.Rows.Count = 0 Then
            'DT = RisorseColl.Cerca("", _IdForn)
            txtCodiceForn.Text = TestoDaCercare
            lblProdotti.Text = "Nessun prodotto trovato"
            lblProdotti.ForeColor = Color.Red
            lblProdotti.Visible = True
            ' pctAlertProdotto.Visible = True
        Else
            lblProdotti.Text = "Prodotti trovati per il testo inserito"
            lblProdotti.ForeColor = Color.Green
            lblProdotti.Visible = True
            '  If txtCerca.TextLength Then pctAlertProdotto.Visible = False
        End If

        DgArticoliForn.DataSource = DT
        DgArticoliForn.Columns(0).Visible = False
        Try
            DgArticoliForn.Columns(3).Visible = False
        Catch ex As Exception

        End Try

        'If DT.Rows.Count Then
        '    MgrControl.SelectIndexCombo(cmbRis, DT.Rows(0).Item("IdRis"))
        '    UcStoricoPrezziRis.mostradati()
        '    txtCodiceForn.Text = DT.Rows(0).Item("CodiceForn")
        '    txtDescrForn.Text = DT.Rows(0).Item("descrForn")
        'Else
        '    UcStoricoPrezziRis.DgRisorse.DataSource = Nothing
        '    txtCodiceForn.Text = ""
        '    txtDescrForn.Text = ""
        '    MessageBox.Show("Non è stato trovato alcun prodotto per il codice inserito! Selezionare manualmente tutti i dati riguardanti il carico di magazzino.", "Carico Magazzino", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If


    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim errObbl As Boolean = False
        If txtCodiceForn.Text.Trim.Length = 0 Then
            errObbl = True
        End If

        If txtDescrForn.Text.Trim.Length = 0 Then
            errObbl = True
        End If

        If cmbRisorsa.SelectedValue = 0 Then
            errObbl = True
        End If

        If errObbl = True Then
            MessageBox.Show("Il codice fornitore, la descrizione e l'effettiva risorsa da movimentare sono obbligatori! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Try
                        _Mov.TipoMov = cmbTipoMov.SelectedItem.Id

                        If _IdFat Then
                            _Mov.IdFat = _IdFat

                            Using c As New Costo
                                c.Read(_IdFat)
                                _Mov.IdForn = c.IdRub
                            End Using

                        End If

                        If _IdCom Then _Mov.IdCom = _IdCom

                        'If _IdRis = 0 Then _IdRis = cmbRisorsa.SelectedValue
                        _IdRis = cmbRisorsa.SelectedValue


                        If _IdCaricoDiMagazzino Then
                            _Mov.IdCaricoMagazzino = _IdCaricoDiMagazzino
                            _Mov.IdForn = _IdForn
                        End If

                        If _IdVoceCosto Then
                            _Mov.IdVoceCosto = _IdVoceCosto
                        End If

                        _Mov.IdRis = _IdRis
                        _Mov.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
                        _Mov.Prezzo = txtPrezzo.Text
                        _Mov.PrezzoUnit = txtPrezzoUnit.Text
                        _Mov.Qta = txtQta.Text

                        If _Mov.IdFat <> 0 And _Mov.IdRis <> 0 Then
                            Using r As New Risorsa
                                r.Read(_Mov.IdRis)
                                If r.Stato <> enStato.Attivo Then
                                    r.Stato = enStato.Attivo
                                    r.Save()
                                End If
                            End Using
                        End If

                        If _IdFat Then
                            Using fatPadre As New Costo
                                fatPadre.Read(_IdFat)
                                _Mov.DataMov = fatPadre.DataCosto
                            End Using
                        ElseIf _IdCaricoDiMagazzino Then
                            Using carmag As New CaricoDiMagazzino
                                carmag.Read(_IdCaricoDiMagazzino)
                                _Mov.DataMov = carmag.DataCarico
                            End Using
                        Else
                            _Mov.DataMov = Date.Now
                        End If

                        If _Mov.CodiceForn <> String.Empty AndAlso _Mov.CodiceForn <> txtCodiceForn.Text Then
                            'qui devo andare ad aggiornare le vecchie voci con questo codice

                            Dim OldVal As String = _Mov.CodiceForn
                            Dim NewVal As String = txtCodiceForn.Text

                            Using mgr As New MagazzinoDAO
                                mgr.TrasformaCodiceOldMovimenti(_Mov.IdRis, OldVal, NewVal)
                            End Using

                        End If

                        If _Mov.DescrForn <> String.Empty AndAlso _Mov.DescrForn <> txtDescrForn.Text Then
                            'qui devo andare ad aggiornare le vecchie voci con questo codice

                            Dim OldVal As String = _Mov.DescrForn
                            Dim NewVal As String = txtDescrForn.Text

                            Using mgr As New MagazzinoDAO
                                mgr.TrasformaDescrOldMovimenti(_Mov.IdRis, OldVal, NewVal)
                            End Using

                        End If

                        _Mov.CodiceForn = txtCodiceForn.Text
                        _Mov.DescrForn = txtDescrForn.Text
                        _Mov.Nota = txtNota.Text

                        Dim Err As Boolean = False

                        If _MaxQta Then

                            If _Mov.Qta > _MaxQta Then

                                MessageBox.Show("La quantità impostata è superiore al necessario! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Err = True

                            End If

                        End If

                        If _QtaDisp <> 0 And (_TipoMov = enTipoMovMagaz.Prenotazione Or _TipoMov = enTipoMovMagaz.Scarico) Then
                            If _Mov.Qta > _QtaDisp And Err = False Then
                                MessageBox.Show("La quantità impostata è superiore alla giacenza della risorsa! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Err = True

                            End If
                        End If
                        If Err = False Then
                            If _Mov.IsValid Then
                                If _Mov.TipoMov <> enTipoMovMagaz.Prenotazione Then

                                    Dim IdIns As Integer

                                    Dim IdIniziale As Integer = _Mov.IdCarMag

                                    tb.TransactionBegin()

                                    IdIns = _Mov.Save()

                                    If _IdVoceCosto Then
                                        Using V As New VoceCosto
                                            V.Read(_IdVoceCosto)
                                            V.IdMovMagaz = _Mov.IdCarMag
                                            V.Save()
                                        End Using
                                    End If


                                    'qui controllo se cambiare lo stato interno del documento fiscale
                                    If _IdFat Then
                                        Using f As New Costo
                                            f.Read(_IdFat)

                                            Dim NuovoStatoFe As enStatoFEInterno = enStatoFEInterno.Inserito

                                            Dim RigheAssociabili As Integer = 0
                                            Dim RigheAssociate As Integer = 0
                                            For Each riga In f.ListaVociFattura
                                                Using mgr As New VociCostoDAO
                                                    If mgr.ValutareRigaFatturaComeRisorsa(riga) Then
                                                        RigheAssociabili += 1
                                                        If riga.IdMovMagaz Then
                                                            RigheAssociate += 1
                                                        End If
                                                    End If
                                                End Using
                                            Next

                                            If RigheAssociabili Then
                                                NuovoStatoFe = enStatoFEInterno.Anomalia

                                                If RigheAssociabili = RigheAssociate Then
                                                    NuovoStatoFe = enStatoFEInterno.Collegato
                                                End If

                                            End If

                                            f.StatoFEInterno = NuovoStatoFe
                                            f.Save()

                                        End Using

                                    End If


                                    'qui vado a controllare se devo annullare una richiesta di acquisto esistente
                                    Using r As New Risorsa
                                        r.Read(_IdRis)
                                        r.Stato = enStato.Attivo
                                        r.Save()

                                        If Not r.UltimaRichiestaAcquistoInevasa Is Nothing Then
                                            Using m As MovimentoMagazzino = r.UltimaRichiestaAcquistoInevasa
                                                If m.Qta > _Mov.Qta Then
                                                    m.Qta = m.Qta - _Mov.Qta
                                                    m.Save()
                                                Else
                                                    'qui devo eliminare la richiesta perche la quantita di carico e' maggiore della richiesta esistente
                                                    Using mgr As New MagazzinoDAO
                                                        mgr.Delete(m.IdCarMag)
                                                    End Using
                                                End If
                                            End Using
                                        End If

                                    End Using

                                    tb.TransactionCommit()

                                    'If IdIniziale <> 0 Then
                                    '    Using M As New MagazzinoDAO
                                    '        M.AggiornaQta(_Mov, _OldQta, _Mov.Qta)
                                    '    End Using

                                    'End If
                                End If
                                _Ris = 1
                                Close()
                            Else
                                MessageBox.Show("La quantità è obbligatoria! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    Catch ex As Exception
                        tb.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore nel salvataggio del movimento di magazzino, riprovare: " & ex.Message)
                    End Try
                End Using


            End If
        End If
    End Sub

    Private Sub cmbTipoMov_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoMov.SelectedIndexChanged
        If cmbTipoMov.SelectedIndex <> -1 Then

            Dim x As cEnum = cmbTipoMov.SelectedItem
            If x.Id = enTipoMovMagaz.Carico Or x.Id = enTipoMovMagaz.RichiestaAcquisto Then

                lblPrezzo.Visible = True
                lblPrezzoUnit.Visible = True
                txtPrezzo.Visible = True
                txtPrezzoUnit.Visible = True
            Else
                lblPrezzo.Visible = False
                lblPrezzoUnit.Visible = False
                txtPrezzo.Visible = False
                txtPrezzoUnit.Visible = False
            End If

        End If
    End Sub

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        Using frmRif As New frmMagazzinoRisorsa
            Using ObjRif As New Risorsa
                Dim Ris As Integer = 0

                ObjRif.Codice = txtCodiceForn.Text
                ObjRif.Descrizione = txtDescrForn.Text

                Sottofondo()
                Ris = frmRif.Carica(ObjRif)
                Sottofondo()
                If Ris Then
                    'qui e' stato inserita la nuova risorsa e devo riselezionarla
                    CaricaRisorse(Ris)
                    Using r As New Risorsa
                        r.Read(Ris)
                        If txtCodiceForn.Text.Length = 0 Then
                            txtCodiceForn.Text = r.Codice
                        End If
                        If txtDescrForn.Text.Length = 0 Then
                            txtDescrForn.Text = r.Descrizione
                        End If
                    End Using
                End If
            End Using
        End Using

    End Sub

    Private Sub lnkRiapriDoc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        'qui riapro il documento fiscale relativo al movimento di magazzino

        If _Mov.IdFat Then

            Using appForm As New frmContabilitaRicavo
                Sottofondo()
                appForm.Carica(_Mov.IdFat, enTipoVoceContab.VoceAcquisto)
                Sottofondo()
            End Using

        End If

    End Sub

    Private Sub cmbRis_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If cmbRisorsa.SelectedValue Then
                'lblRisorsa.Text = cmbRis.Text
                'UcStoricoPrezziRis.IdRis = cmbRis.SelectedValue
                'UcStoricoPrezziRis.MostraDati()

                Dim RisSel As New Risorsa

                RisSel.Read(cmbRisorsa.SelectedValue)

                pctRis.Image = RisSel.ImageRif

                If sender.focused And _IdVoceCosto = 0 Then

                    txtCodiceForn.Text = ""
                    txtDescrForn.Text = ""

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub lnkCerca_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        CercaRisorsa()
    End Sub

    Private Sub DgArticoliForn_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgArticoliForn.CellClick
        If sender.focused Then SelezionaRiga()
    End Sub

    Private Sub SelezionaRiga()
        Try
            If DgArticoliForn.SelectedRows.Count Then

                If DgArticoliForn.ColumnCount = 2 Then
                    'qui solo idris e descirzione
                    txtDescrForn.Text = DgArticoliForn.SelectedRows(0).Cells(1).Value '0
                Else
                    txtCodiceForn.Text = DgArticoliForn.SelectedRows(0).Cells(1).Value
                    txtDescrForn.Text = DgArticoliForn.SelectedRows(0).Cells(2).Value '0

                End If

                'If _IdForn = DgArticoliForn.SelectedRows(0).Cells(3).Value Then
                'txtCodiceForn.Text = DgArticoliForn.SelectedRows(0).Cells(1).Value
                'End If

                Dim IdRis As Integer = DgArticoliForn.SelectedRows(0).Cells(0).Value

                'Using r As New Risorsa
                '    r.Read(IdRis)
                '    Dim Cat As String = r.Categoria
                '    MgrControl.SelectIndexComboTesto(cmbCategoria, Cat)
                '    'CaricaRisorse()
                '    'Threading.Thread.Sleep(500)
                'End Using

                MgrControl.SelectIndexCombo(cmbRisorsa, IdRis)
                'cmbRisorsa.SelectedValue = IdRis
                txtQta.Focus()
            Else
                txtCodiceForn.Text = ""
                txtDescrForn.Text = ""
                MgrControl.SelectIndexCombo(cmbRisorsa, -1)
            End If
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub txtCodiceForn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodiceForn.TextChanged
    '    ControllaPrezzo()
    'End Sub

    'Private Sub txtPrezzoUnit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrezzoUnit.TextChanged
    '    ControllaPrezzo()
    'End Sub

    'Private Sub ControllaPrezzo()
    '    'qui controllo se il prezzo e' congruente
    '    Dim x As New cListinoFornColl
    '    Dim prezzoTrovato As Double = x.CercaPrezzoProdByCodice(txtCodiceForn.Text, _IdForn)
    '    If prezzoTrovato Then
    '        If prezzoTrovato = CDbl(txtPrezzoUnit.Text) Then
    '            lblCheckPrezzo.Text = "Il prezzo trovato è congruente con l'accordo stabilito"
    '            lblCheckPrezzo.ForeColor = Color.Green
    '            lblCheckPrezzo.Visible = True
    '            pctAlertCheckPrezzo.Visible = False
    '        Else
    '            lblCheckPrezzo.Text = "Il prezzo trovato NON è congruente con l'accordo stabilito. Il prezzo corretto è " & prezzoTrovato
    '            lblCheckPrezzo.ForeColor = Color.Red
    '            lblCheckPrezzo.Visible = True
    '            pctAlertCheckPrezzo.Visible = True

    '        End If

    '    End If
    'End Sub

    Private Sub frmCaricoMagaz_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        txtCerca.Focus()
    End Sub

    Private Sub txtCerca_TextChanged(sender As Object, e As EventArgs) Handles txtCerca.TextChanged
        CercaRisorsa()
        txtCerca.Focus()
    End Sub


    Private Sub DgArticoliForn_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgArticoliForn.CellContentClick

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub lblProdotti_Click(sender As Object, e As EventArgs) Handles lblProdotti.Click

    End Sub

    Private Sub btnDett_Click(sender As Object, e As EventArgs) Handles btnDett.Click

        'MgrControl.SelectIndexCombo(cmbRisorsa, 10)
        'Exit Sub

        If cmbRisorsa.SelectedValue Then
            Sottofondo()

            Dim ris As Integer = 0

            Using f As New frmMagazzinoRisorsa
                ris = f.Carica(cmbRisorsa.SelectedValue)
            End Using

            If ris Then
                CaricaRisorse(ris)
            End If

            Sottofondo()
        Else
            MessageBox.Show("Selezionare una risorsa")
        End If
    End Sub

    Private _IdFat As Integer = 0

    Private Sub lnkRiapriDocFiscale_Click(sender As Object, e As EventArgs) Handles lnkRiapriDocFiscale.Click

        If _IDFat Then
            Sottofondo()
            Using c As New frmContabilitaCosto
                c.Carica(_IDFat)
            End Using
            Sottofondo()
        Else
            Beep()
        End If

    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged
        CaricaRisorse()
    End Sub

    Private Sub txtCercaRis_TextChanged(sender As Object, e As EventArgs) Handles txtCercaRis.TextChanged
        CaricaRisorse()
    End Sub

    Private Sub pctSblocca_Click(sender As Object, e As EventArgs) Handles pctSblocca.Click
        cmbRisorsa.Enabled = True
        txtCercaRis.Enabled = True
        cmbCategoria.Enabled = True
    End Sub
End Class