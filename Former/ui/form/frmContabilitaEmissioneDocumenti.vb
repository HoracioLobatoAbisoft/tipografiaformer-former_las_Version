Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerBusinessLogic
Imports FormerBusinessLogicInterface
Imports FormerLib
Imports FormerPrinter

Friend Class frmContabilitaEmissioneDocumenti
    ' Inherits baseFormInternaRedim

    Private _Ris As Integer

    Private _ClienteSel As Integer = 0
    Private _SwPrev As Boolean = False
    Private _SwFatt As Boolean = False

    Private _AvanzaStatoOrdini As Boolean = True

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

    End Sub

    Friend Function CaricaX(Optional ByVal IdTipoDoc As enTipoDocumento = enTipoDocumento.Fattura,
                           Optional ByVal IdOrd As Integer = 0,
                           Optional ByVal ListaOrdini As String = "",
                           Optional ByVal NumColli As Integer = 0,
                           Optional ByVal Peso As Single = 0,
                           Optional ByVal IdCorriere As Integer = 0,
                           Optional AvanzaStatoOrdini As Boolean = True) As Integer

        _AvanzaStatoOrdini = AvanzaStatoOrdini

        CaricaCombo()

        lblDate.Text = Now.Date

        'DA RIATTIVARE SE SI VUOLE TOGLIERE IL PULSANTE ALL'OPERATORE
        'If Postazione.UtenteConnesso.Tipo = enTipoUtente.Operatore Then btnAddOrder.Visible = False

        If IdTipoDoc Then MgrControl.SelectIndexCombo(cmbTipo, IdTipoDoc)

        If IdOrd Then
            'qui devo caricare tutti i colli
            InserisciOrdineDaCodice(IdOrd, True)
        ElseIf ListaOrdini.Length Then
            ListaOrdini = ListaOrdini.TrimEnd(",")
            Dim SingIdOrd() As String = Split(ListaOrdini, ",")
            Dim IdRub As Integer = 0
            For Each singNum As Integer In SingIdOrd
                If IdRub = 0 Then
                    Dim O As New Ordine
                    O.Read(singNum)
                    IdRub = O.IdRub
                    _ClienteSel = IdRub
                    O = Nothing
                End If
                InserisciOrdineDaCodice(singNum, True)
            Next

            'qui devo controllare se ci sono altre cose da fatturare e apro la maschera di inserimento
            Dim AltriOrdini As Integer = 0
            Using mgr As New OrdiniDAO
                AltriOrdini = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.Stato, CInt(enStatoOrdine.UscitoMagazzino)),
                                          New LUNA.LunaSearchParameter(LFM.Ordine.IdRub, IdRub),
                                          New LUNA.LunaSearchParameter(LFM.Ordine.IdOrd, "(" & ListaOrdini & ")", "NOT IN")).Count
            End Using
            If AltriOrdini Then AggiungiAltriOrdini()

        End If

        If NumColli <> 0 Then txtNumColli.Text = NumColli
        If Peso <> 0 Then txtPeso.Text = Peso
        If IdCorriere Then MgrControl.SelectIndexCombo(cmbCorriere, IdCorriere)

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Dim x As New cTipoDoc(False)
        cmbTipo.DisplayMember = "Descrizione"
        cmbTipo.ValueMember = "Id"
        cmbTipo.DataSource = x

        Using Corriere As New CorrieriDAO

            cmbCorriere.DataSource = Corriere.FindAll(LFM.Corriere.Descrizione,
                                                      New LUNA.LunaSearchParameter(LFM.Corriere.DisponibileOnline, enSiNo.Si))
            cmbCorriere.ValueMember = "IdCorriere"
            cmbCorriere.DisplayMember = "Descrizione"
        End Using
        Using PM As New TipoPagamentiDAO
            cmbPagam.DataSource = PM.GetAll(LFM.TipoPagamento.IdTipoPagam, False)
            cmbPagam.ValueMember = "IdTipoPagam"
            cmbPagam.DisplayMember = "TipoPagam"
        End Using
        CaricaCli()

    End Sub

    Private Sub CaricaCli()

        'Using cli As New VociRubricaDAO
        '    cmbCliente.ValueMember = "IdRub"
        '    cmbCliente.DisplayMember = "Nominativo"
        '    cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, False, "ORDSTAMPA")
        'End Using

        UcComboCliente.Carica(enTipoRubrica.Cliente, False, "ORDSTAMPA")

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Sottofondo()

        Dim x As New frmMagazzinoBarCodeRCTF, Ris As String = ""

        Ris = x.Carica

        Sottofondo()

        'se ris e' pieno ho il codice in formato testo di ordine e numero collo caricato

        If chkRiapri.Checked Then

            While Ris.Length = 13

                Dim CodiceOrd As Integer = Ris.Substring(0, 8)

                'qui devo vedere se l'ordine e' gia in griglia, se gia ci sta lo aggiorno altrimenti lo aggiungo e aggiorno la quantita dei colli

                InserisciOrdineDaCodice(CodiceOrd, , True)

                Sottofondo()
                Ris = x.Carica
                Sottofondo()

            End While

        ElseIf Ris.Length = 13 Then

            'mi prendo le prime 9 cifre ed estraggo il codice del numero ordine
            Dim CodiceOrd As Integer = Ris.Substring(0, 8)

            'qui devo vedere se l'ordine e' gia in griglia, se gia ci sta lo aggiorno altrimenti lo aggiungo e aggiorno la quantita dei colli

            InserisciOrdineDaCodice(CodiceOrd, , True)

        Else

            If Ris.Length <> 0 Then MessageBox.Show("Codice inserito formalmente non valido!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If

        x = Nothing

    End Sub

    Private Sub InserisciOrdineDaCodice(ByVal CodiceOrdString As String,
                                        Optional ByVal ForzaColli As Boolean = False,
                                        Optional ByVal ModalitaInterattiva As Boolean = False)

        Dim CodiciOrdini As String()

        CodiciOrdini = Split(CodiceOrdString, ",")

        Dim CodiceOrd As String

        For Each CodiceOrd In CodiciOrdini
            Dim drEsist As DataGridViewRow = Nothing
            Dim SwTrovato = False
            For Each drEsist In DgLavori.Rows

                If drEsist.Cells(1).Value = CodiceOrd Then
                    SwTrovato = True
                    Exit For
                End If

            Next

            If SwTrovato Then

                If drEsist.Cells(4).Value < drEsist.Cells(5).Value Then
                    drEsist.Cells(4).Value += 1
                End If

            Else

                Dim ordine As New Ordine
                ordine.Read(CodiceOrd)

                If ordine.Preventivo Then
                    _SwPrev = True
                Else
                    _SwFatt = True
                End If

                If ordine.IdOrd Then
                    If ordine.Stato = enStatoOrdine.UscitoMagazzino Then

                        Dim Rub As New VoceRubrica, NomeCli As String = ""

                        Rub.Read(ordine.IdRub)
                        NomeCli = Rub.RagSocNome

                        If _ClienteSel = 0 Then
                            _ClienteSel = Rub.IdRub
                            'MgrControl.SelectIndexCombo(cmbCliente, _ClienteSel)
                            UcComboCliente.IdRubSelezionato = _ClienteSel

                        End If

                        If _ClienteSel = Rub.IdRub Then

                            Dim Prod As New Prodotto, NumColli As Integer = 0, DescrProd As String = ""
                            Prod.Read(ordine.IdProd)
                            DescrProd = Prod.Descrizione
                            NumColli = ordine.NumeroRealeColli

                            Prod = Nothing

                            Dim Dr As New DataGridViewRow

                            Dim ImgPreview As Image
                            Dim ImgNew As Image
                            Try
                                ImgPreview = Image.FromFile(ordine.FilePath)
                                ImgNew = New Bitmap(ImgPreview, New Size(50, 75))
                            Catch ex As Exception

                            End Try

                            Dr.CreateCells(DgLavori)

                            Dr.Cells(0).Value = ImgNew
                            Dr.Cells(1).Value = CodiceOrd
                            Dr.Cells(2).Value = DescrProd
                            Dr.Cells(3).Value = NomeCli
                            Dr.Cells(4).Value = IIf(ForzaColli, NumColli, "1")
                            Dr.Cells(5).Value = NumColli
                            Dr.Cells(6).Value = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ordine.TotaleImponibile)
                            Dr.Cells(7).Value = ordine.PreventivoStr

                            DgLavori.Rows.Add(Dr)

                            txtIndCons.Text = Rub.IndCons
                            'txtPagamento.Text = Rub.Pagamento
                            cmbPagam.SelectedIndex = Rub.IdPagamento

                            'qui controllo se si tratta di un preventivo e in caso lo blocco
                            If ordine.Preventivo = enSiNo.Si Then
                                MgrControl.SelectIndexCombo(cmbTipo, enTipoDocumento.Preventivo)
                                cmbTipo.Enabled = False
                                txtPagamento.Text = "Alla consegna"
                                cmbPagam.SelectedIndex = 0
                            Else
                                cmbTipo.Enabled = True

                            End If

                        Else
                            MessageBox.Show("Non si possono inserire ordini di clienti diversi!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        End If

                        Rub = Nothing

                    Else
                        If ModalitaInterattiva Then MessageBox.Show("Si possono inserire solo ordini in stato USCITO DA MAGAZZINO!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else

                    MessageBox.Show("Codice inserito non valido!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

                ordine = Nothing

            End If
        Next

        If _SwFatt And _SwPrev Then MessageBox.Show("Sono stati inseriti ordini di tipo preventivo insieme a ordini normali!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End Sub

    Private Sub btnRimuovi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRimuovi.Click

        If DgLavori.SelectedRows.Count Then
            Dim Dr As DataGridViewRow = DgLavori.SelectedRows(0)
            If Dr.Selected Then
                'sposto la lavorazione tra quelle selezionate

                DgLavori.Rows.Remove(DgLavori.SelectedRows(0))

                If DgLavori.Rows.Count = 0 Then _ClienteSel = 0

            End If
        End If
    End Sub

    Private Sub btnSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        'qui controllo prima che per tutti gli ordini inseriti sono stati caricati tutti i colli previsti
        Dim Dr As DataGridViewRow

        Dim ErrTrov As Boolean = False
        For Each Dr In DgLavori.Rows
            If CInt(Dr.Cells(4).Value) <> Dr.Cells(5).Value Then
                ErrTrov = True
            End If
        Next

        If DgLavori.Rows.Count = 0 Then ErrTrov = True

        If ErrTrov Then
            MessageBox.Show("Non sono stati caricati tutti i colli previsti per gli ordini selezionati o non è stato selezionato nessun ordine!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else

            Dim TxtMsg As String = "Vuoi emettere il documento scelto per gli ordini selezionati"

            If _AvanzaStatoOrdini Then
                TxtMsg &= " e passarli allo stato successivo"
            End If
            TxtMsg &= "?"

            If MessageBox.Show(TxtMsg, "Consegna Colli", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Using TB As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Dim x As Ricavo = Nothing
                    Try
                        TB.TransactionBegin()
                        'passo gli ordini allo stato successivo
                        'Dim Ord As New cOrdiniColl
                        Dim IdRel As Integer = 0
                        Dim ProxStato As enStatoOrdine = enStatoOrdine.Consegnato
                        Dim Totale As Decimal = 0
                        'Dim TotaleIva As Double = 0
                        Dim Descrizione As String = ""

                        Using Ord As New OrdiniDAO

                            If cmbCorriere.SelectedValue <> 1 Then
                                ProxStato = enStatoOrdine.InConsegna
                            End If

                            Dim CollOrd As New List(Of Ordine)

                            For Each Dr In DgLavori.Rows

                                IdRel = Dr.Cells(1).Value
                                Descrizione &= " " & IdRel & " "
                                If _AvanzaStatoOrdini Then Ord.AvanzaOrdiniAStatoByIdOrd(IdRel, ProxStato)
                                Dim Ordin As New Ordine
                                Ordin.Read(IdRel)
                                Totale += Ordin.TotaleImponibile

                                'If cmbTipo.SelectedValue <> enTipoDocumento.enTipoDocPreventivo Then TotaleIva += Ordin.Iva

                                CollOrd.Add(Ordin)
                                'DgLavori.Rows.Remove(Dr)

                            Next
                            If Descrizione.Length > 235 Then
                                Descrizione = Descrizione.Substring(0, 234)
                            End If
                            Descrizione = "Documento ordini:" & Descrizione

                            'mi prendo il costo del corriere

                            Dim CostoCorriere As Decimal = 0
                            'Dim CostoCorriereIva As Single = 0

                            Try
                                CostoCorriere = CDec(txtCostoCorr.Text)
                                'If cmbTipo.SelectedValue = enTipoDocumento.enTipoDocPreventivo Then
                                '    CostoCorriere = CostoCorriere + (CostoCorriere * 20 / 100)
                                'End If

                            Catch ex As Exception

                            End Try

                            'If CostoCorriere Then
                            '    If cmbTipo.SelectedValue <> enTipoDocumento.enTipoDocPreventivo Then CostoCorriereIva = Math.Round((CostoCorriere * cPercIVA / 100), 2)
                            'End If

                            'qui mi prendo il numero da assegnare al documento 
                            'Dim NumeroDoc As Integer = 0

                            'Dim num As New ProgressiviFiscali
                            'num.Read(LUNA.LunaContext.IdNumerazioneDocumenti)

                            'Select Case cmbTipo.SelectedValue
                            '    Case enTipoDocumento.enTipoDocDDT
                            '        NumeroDoc = num.NextDDT
                            '        num.NextDDT += 1
                            '    Case enTipoDocumento.enTipoDocFattura
                            '        NumeroDoc = num.NextFat
                            '        num.NextFat += 1
                            '    Case enTipoDocumento.enTipoDocFatturaRiepilogativa
                            '        NumeroDoc = num.NextFat
                            '        num.NextFat += 1
                            '    Case enTipoDocumento.enTipoDocPreventivo
                            '        NumeroDoc = num.NextPrev
                            '        num.NextPrev += 1
                            'End Select

                            'num.Save()

                            'qui salvo il reale documento e poi lo associo agli ordini
                            Dim Cliente As New VoceRubrica
                            Cliente.Read(_ClienteSel)

                            'Dim x As New cContabRicavi, IdInserito As Integer = 0
                            x = New Ricavo
                            Dim IdInserito As Integer
                            x.pRagSoc = Cliente.RagSocNome
                            x.pIndirizzo = Cliente.Indirizzo
                            x.pCitta = Cliente.Citta
                            x.pCap = Cliente.CAP
                            x.pIva = Cliente.PivaEx

                            x.Descrizione = Descrizione
                            x.Tipo = cmbTipo.SelectedValue
                            x.IdCorr = cmbCorriere.SelectedValue
                            x.CostoCorr = CostoCorriere
                            x.DataRicavo = Now.Date
                            x.IdRub = _ClienteSel
                            x.pIndCons = txtIndCons.Text
                            x.pPagamento = cmbPagam.Text
                            x.Idpagamento = cmbPagam.SelectedValue
                            x.PercIva = FormerHelper.Finanziarie.GetPercentualeIva

                            x.Importo = Totale + CostoCorriere
                            If cmbTipo.SelectedValue <> enTipoDocumento.Preventivo Then x.Iva = Math.Round((x.Importo * FormerHelper.Finanziarie.GetPercentualeIva / 100), 2)
                            x.Totale = x.Importo + x.Iva

                            x.NumColli = txtNumColli.Text
                            x.Peso = txtPeso.Text
                            x.Dataprevpagam = x.CalcolaDataPrevPagam
                            x.Numero = MgrDocumentNumber.GetNextNumber(cmbTipo.SelectedValue)
                            IdInserito = x.Save()

                            Dim IdOrdini As New List(Of Integer)

                            For Each OrdineInColl As Ordine In CollOrd
                                'qui inserisco le voci in fattura partendo dagli ordini
                                Dim VoceFat As New VoceFattura
                                Dim Prod As New Prodotto
                                Prod.Read(OrdineInColl.IdProd)

                                VoceFat.IdDoc = IdInserito
                                VoceFat.Codice = Prod.Codice
                                Dim DescrOrdine As String = Prod.Descrizione ' lo inizializzo comunque alla descrizione del prodotto perche per qualche motivo il nome del lavoro potrebbe cmq saltare anceh se impostato
                                If OrdineInColl.UsaNomeLavoroInFattura = enSiNo.Si Then
                                    If OrdineInColl.NomeLavoro.Length Then
                                        DescrOrdine = OrdineInColl.NomeLavoro
                                    End If
                                End If
                                VoceFat.Descrizione = DescrOrdine 'Prod.Descrizione
                                VoceFat.ImportoSing = OrdineInColl.PrezzoProd / OrdineInColl.QtaOrdine 'Prod.NumPezzi ''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                                VoceFat.Importo = OrdineInColl.TotaleImponibile
                                'VoceFat.Iva = OrdineInColl.Iva
                                VoceFat.Qta = OrdineInColl.QtaOrdine ' Prod.NumPezzi * OrdineInColl.Qta''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                                VoceFat.IdOrd = OrdineInColl.IdOrd
                                VoceFat.Save()

                                IdRel = OrdineInColl.IdOrd

                                Dim MettiAPrev As enSiNo = enSiNo.No
                                If x.Tipo = enTipoDocumento.Preventivo Then
                                    MettiAPrev = enSiNo.Si
                                End If
                                Ord.AssociaOrdiniADoc(IdRel, IdInserito, MettiAPrev)
                                IdOrdini.Add(OrdineInColl.IdOrd)
                                'DgLavori.Rows.Remove(Dr)

                            Next

                            Using mgr As New ConsegneProgrammateDAO

                                mgr.CreaConsegnaOggiDaListaOrdini(IdOrdini)

                            End Using

                            TB.TransactionCommit()

                            If MessageBox.Show("Vuoi stampare il documento emesso?", "Consegna Colli", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                'prima di uscire mando in stampa il documento contabile
                                Dim NumCopie As Integer = 0
                                Try
                                    NumCopie = InputBox("Inserisci il numero di copie che vuoi stampare", "Numero Copie", FormerLib.FormerConst.Fiscali.NumCopieDocFiscali)
                                Catch ex As Exception

                                End Try

                                If NumCopie > 0 Then
                                    Try
                                        ProxyStampa.StampaDocumentoFiscale(x, True, NumCopie, False, PostazioneCorrente.UtenteConnesso.IdUt)
                                    Catch ex As Exception
                                        MessageBox.Show("Si è verificato un errore nella stampa del documento fiscale, riprovare")
                                    End Try
                                Else
                                    MessageBox.Show("Inserire un numero di copie valido")
                                End If

                                'Dim Prn As New myPrinter, PrinterName As String
                                'PrinterName = Postazione.StampanteFatture

                                'If x.Tipo = enTipoDocumento.enTipoDocPreventivo Then
                                '    Dim prin As New System.Windows.Forms.PrintDialog
                                '    prin.ShowDialog()
                                '    If prin.PrinterSettings.PrinterName.Length Then PrinterName = prin.PrinterSettings.PrinterName
                                'End If

                                'Prn.PrinterName = PrinterName

                                ''Dim RicavoCompatibilita As New cContabRicavi

                                ''RicavoCompatibilita.CostoCorr = x.CostoCorr
                                ''RicavoCompatibilita.DataPrevPagam = x.Dataprevpagam
                                ''RicavoCompatibilita.DataRicavo = x.DataRicavo
                                ' ''RicavoCompatibilita.DataRif = x.DataRif
                                ''RicavoCompatibilita.Descrizione = x.Descrizione
                                ''RicavoCompatibilita.IdCat = x.IdCat
                                ''RicavoCompatibilita.IdCorr = x.IdCorr
                                ''RicavoCompatibilita.IdDocRif = x.IdDocRif
                                ''RicavoCompatibilita.IdPagamento = x.Idpagamento
                                ''RicavoCompatibilita.IdRicavo = x.IdRicavo
                                ''RicavoCompatibilita.IdRub = x.IdRub
                                ''RicavoCompatibilita.Importo = x.Importo
                                ''RicavoCompatibilita.Iva = x.Iva
                                ''RicavoCompatibilita.NumColli = x.NumColli
                                ''RicavoCompatibilita.Numero = x.Numero
                                ''RicavoCompatibilita.pCap = x.pCap
                                ''RicavoCompatibilita.pCitta = x.pCitta
                                ''RicavoCompatibilita.PercIva = x.PercIva
                                ''RicavoCompatibilita.Peso = x.Peso
                                ''RicavoCompatibilita.pIndCons = x.pIndCons
                                ''RicavoCompatibilita.pIndirizzo = x.pIndirizzo
                                ''RicavoCompatibilita.pIva = x.pIva
                                ''RicavoCompatibilita.pPagamento = x.pPagamento
                                ''RicavoCompatibilita.pRagSoc = x.pRagSoc
                                ''RicavoCompatibilita.Scansione = x.Scansione
                                ''RicavoCompatibilita.Scansione1 = x.Scansione1
                                ''RicavoCompatibilita.Scansione2 = x.Scansione2
                                ''RicavoCompatibilita.Scansione3 = x.Scansione3
                                ''RicavoCompatibilita.Scansione4 = x.Scansione4
                                ''RicavoCompatibilita.Tipo = x.Tipo
                                ''RicavoCompatibilita.Totale = x.Totale
                                'Prn.StampaDocumento(x)
                                'Prn = Nothing

                            End If

                            Dim Rub As New VoceRubrica
                            Rub.Read(x.IdRub)

                            'Dim lo As List(Of Ordine) = Nothing
                            'Using mgr As New OrdiniDAO
                            '    Dim StatoConsegna As String = "(" & enStatoOrdine.InConsegna & "," & enStatoOrdine.Consegnato & ")"
                            '    lo = mgr.FindAll(New LUNA.LunaSearchParameter("IdRub", x.IdRub), New LUNA.LunaSearchParameter("Stato", StatoConsegna, "IN"))
                            'End Using

                            'If lo.Count Then

                            Dim lstIdDocRif As New List(Of Integer) From {x.IdDocRif}

                            If Rub.HaDocumentiInSospeso(lstIdDocRif) Then
                                If MessageBox.Show("Vuoi stampare la situazione contabile del cliente?", "Situazione Contabile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                    'prima di uscire mando in stampa il documento contabile
                                    Sottofondo()
                                    StampaBuffer(Rub.SituazioneContabile)
                                    Sottofondo()

                                End If
                            End If
                            Rub = Nothing

                            If chkEmettiPagam.Checked Then
                                Dim frm As New frmContabilitaPagamento
                                Sottofondo()

                                frm.Carica(, , x.IdRicavo, enTipoVoceContab.VoceVendita)
                                frm = Nothing
                                Sottofondo()
                            End If
                        End Using
                    Catch ex As Exception
                        TB.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore " & ex.Message)
                    End Try

                    _Ris = 1
                    Close()
                End Using


            End If
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub DgLavori_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DgLavori.RowPostPaint

        Dim x As DataGridViewRow = DgLavori.Rows.Item(e.RowIndex)

        If x.Cells(4).Value <> x.Cells(5).Value Then
            x.Cells(4).Style.BackColor = Color.Red
            x.Cells(4).Style.SelectionBackColor = Color.Red
        Else
            x.Cells(4).Style.BackColor = Color.Green
            x.Cells(4).Style.SelectionBackColor = Color.Green
        End If

    End Sub

    Private Sub AggiornaPagine()

        lblRighe.Text = DgLavori.RowCount

        Dim Pagine As Integer = Int((DgLavori.RowCount / 39)) + 1
        lblPagine.Text = Pagine

        If Pagine > 1 Then
            lblPagine.ForeColor = Color.Red
        Else
            lblPagine.ForeColor = Color.Black

        End If

    End Sub

    Private Sub AggiornaTotali()

        AggiornaPagine()

        Dim x As DataGridViewRow
        Dim TotColli As Integer = 0
        Dim TotPeso As Single = 0
        Dim TotForn As Decimal = 0
        Dim TotIva As Decimal = 0

        For Each x In DgLavori.Rows

            TotColli += x.Cells(5).Value
            Dim ord As New Ordine
            ord.Read(x.Cells(1).Value)
            Dim Prod As New Prodotto
            Prod.Read(ord.IdProd)
            TotPeso += Prod.PesoComplessivo
            TotForn += ord.TotaleImponibile
            'If cmbTipo.SelectedValue <> enTipoDocumento.enTipoDocPreventivo Then TotIva += ord.Iva

            Prod = Nothing
            ord = Nothing

        Next

        txtNumColli.Text = TotColli
        txtPeso.Text = TotPeso

        'mi prendo il costo del corriere

        Dim CostoCorriere As Decimal = 0
        Dim CostoCorriereIva As Decimal = 0

        Try
            CostoCorriere = txtCostoCorr.Text
            'If cmbTipo.SelectedValue = enTipoDocumento.enTipoDocPreventivo Then
            '    CostoCorriere = CostoCorriere + (CostoCorriere * FormerHelper.Finanziarie.GetPercentualeIva / 100)
            'End If

        Catch ex As Exception

        End Try

        'If CostoCorriere Then
        '    If cmbTipo.SelectedValue <> enTipoDocumento.enTipoDocPreventivo Then
        '        CostoCorriereIva = CostoCorriere * FormerHelper.Finanziarie.GetPercentualeIva / 100
        '    End If
        'End If

        If cmbTipo.SelectedValue <> enTipoDocumento.Preventivo Then TotIva = (TotForn + CostoCorriere) * FormerHelper.Finanziarie.GetPercentualeIva / 100
        lblTotIva.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(((TotIva)))
        lblTotImp.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo((TotForn + CostoCorriere))
        lblTotDocum.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo((TotForn + TotIva + CostoCorriere))

    End Sub

    Private Function RiempiListaIdOrd() As String
        Dim x As DataGridViewRow
        Dim buffer As String = ""

        For Each x In DgLavori.Rows

            buffer &= x.Cells(1).Value & ","

        Next
        buffer = buffer.TrimEnd(",")
        Return buffer
    End Function

    Private Sub txtCostoCorr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostoCorr.KeyPress
        MgrControl.ControlloNumerico(sender, e, False)
    End Sub

    Private Sub txtCostoCorr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostoCorr.TextChanged
        AggiornaTotali()
    End Sub

    Private Sub CalcolaSpeseCorriere()
        Dim Tariffa As Decimal = 0

        If cmbCorriere.SelectedIndex <> -1 Then
            Dim voce As Corriere = Nothing
            voce = cmbCorriere.SelectedItem

            Dim TotaleImportiOrd As Decimal = 0

            'ciclo tra tutti gli ordini dentro il documento
            Dim x As DataGridViewRow
            Dim KgPeso As Single = 0
            Dim PesiVolumetrici As Single = 0
            For Each x In DgLavori.Rows

                'TotColli += x.Cells(5).Value
                Dim ord As New Ordine
                ord.Read(x.Cells(1).Value)
                Dim Prod As New Prodotto
                Prod.Read(ord.IdProd)
                KgPeso += Prod.PesoComplessivo
                TotaleImportiOrd += ord.TotaleImponibile

                If Prod.IdListinoBase Then

                    Dim L As New ListinoBase
                    L.Read(Prod.IdListinoBase)

                    Dim Altezza As Single = L.FormatoProdotto.FormatoCarta.Altezza + 3
                    Dim Larghezza As Single = L.FormatoProdotto.FormatoCarta.Larghezza + 3
                    Dim Profondita As Single = L.TipoCarta.CalcolaSpessoreCM(ord.QtaOrdine) 'Prod.NumPezzi)

                    Dim SingPesoVolum As Single = 0
                    If L.Preventivazione.IdReparto <> enRepartoWeb.StampaOffset Then
                        If L.IdModelloCubetto Then
                            Using M As New ModelloCubetto
                                M.Read(L.IdModelloCubetto)
                                Altezza = M.Lunghezza / 10
                                Larghezza = M.Larghezza / 10
                                Profondita = M.Profondita / 10
                            End Using

                            SingPesoVolum = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)
                            SingPesoVolum = SingPesoVolum * ord.NumeroRealeColli
                        End If
                    End If

                    If SingPesoVolum = 0 Then SingPesoVolum = MgrCorriere.CalcolaPesoVolumetrico(Altezza, Larghezza, Profondita)

                    PesiVolumetrici += SingPesoVolum

                End If

                'If cmbTipo.SelectedValue <> enTipoDocumento.enTipoDocPreventivo Then TotIva += ord.Iva

                Prod = Nothing
                ord = Nothing

            Next

            Dim P As New TipoPagamento
            P.Read(cmbPagam.SelectedValue)

            Tariffa = MgrCorriere.CalcolaTariffa(voce, PesiVolumetrici, KgPeso, TotaleImportiOrd, P)
        End If

        txtCostoCorr.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Tariffa)

    End Sub

    Private Sub cmbCorriere_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCorriere.SelectedIndexChanged
        CalcolaSpeseCorriere()
    End Sub

    Private Sub AggiungiAltriOrdini()
        Sottofondo()

        Dim x As New frmMagazzinoCaricaColli, Ris As String = "", ListaIdOrd As String = ""

        ListaIdOrd = RiempiListaIdOrd()
        Dim IdCli As Integer = 0
        If _ClienteSel Then
            IdCli = _ClienteSel
        Else
            'IdCli = cmbCliente.SelectedValue
            IdCli = UcComboCliente.IdRubSelezionato
        End If
        Ris = x.Carica(IdCli, ListaIdOrd)

        x = Nothing

        Sottofondo()

        'se ris e' pieno ho il codice in formato testo di ordine e numero collo caricato

        If Ris.Length Then

            'mi prendo le prime 9 cifre ed estraggo il codice del numero ordine
            'Dim CodiceOrd As Integer = Ris

            'qui devo vedere se l'ordine e' gia in griglia, se gia ci sta lo aggiorno altrimenti lo aggiungo e aggiorno la quantita dei colli

            InserisciOrdineDaCodice(Ris, True)

        End If
    End Sub

    Private Sub btnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOrder.Click

        AggiungiAltriOrdini()

    End Sub

    Private Sub DgLavori_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgLavori.RowsAdded
        AggiornaTotali()
    End Sub

    Private Sub DgLavori_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgLavori.RowsRemoved
        AggiornaTotali()
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        'Dim num As New ProgressiviFiscali

        'num.Read(LUNA.LunaContext.IdNumerazioneDocumenti)

        'Select Case cmbTipo.SelectedValue
        '    Case enTipoDocumento.enTipoDocDDT
        '        lblNumDoc.Text = num.NextDDT

        '    Case enTipoDocumento.enTipoDocFattura
        '        lblNumDoc.Text = num.NextFat

        '    Case enTipoDocumento.enTipoDocFatturaRiepilogativa
        '        lblNumDoc.Text = num.NextFat

        '    Case enTipoDocumento.enTipoDocPreventivo
        '        lblNumDoc.Text = num.NextPrev

        'End Select

        'num = Nothing
        lblNumDoc.Text = MgrDocumentNumber.GetNextNumber(cmbTipo.SelectedValue)
        AggiornaTotali()

    End Sub

    Private Sub cmbPagam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPagam.SelectedIndexChanged

        CalcolaSpeseCorriere()

        Dim Ris As Date = Now.Date

        Dim tp As TipoPagamento = cmbPagam.SelectedItem
        If tp.ggToAdd Then
            Ris = Now.Date.AddDays(tp.ggToAdd)
        End If

        lblDataPrevPagam.Text = Ris

    End Sub

End Class