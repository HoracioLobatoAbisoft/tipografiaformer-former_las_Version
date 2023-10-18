'Imports System.Data
'Imports System.Data.OleDb
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerPrinter
Imports FormerConfig
Imports FormerBusinessLogic

Friend Class frmContabilitaFatturaRiepilogativaRicavo
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Private _ClienteSel As Integer = 0
    Private _SwPrev As Boolean = False
    Private _SwFatt As Boolean = False
    Private _IdFatt As Integer = 0
    Private _TotIva As Decimal = 0
    Private _TotImp As Decimal = 0
    Private _Voce As Ricavo

    Friend Function Carica(Optional ByVal IdFatt As Integer = 0,
                           Optional ByVal IdDDT As Integer = 0) As Integer

        _IdFatt = IdFatt
        txtPercIva.Text = FormerHelper.Finanziarie.GetPercentualeIva
        CaricaCombo()

        If IdFatt Then
            'ricarica la fattura

            _Voce = New Ricavo
            _Voce.Read(IdFatt)
            lblAzienda.Text = MgrAziende.GetAziendaStr(_Voce.IdAzienda)
            lblIntestazione.Text = MgrDocumentiFiscali.GetIntestazione(_Voce)
            txtPagamento.Text = _Voce.pPagamento
            MgrControl.SelectIndexCombo(cmbPagam, _Voce.Idpagamento)
            MgrControl.SelectIndexCombo(cmbCliente, _Voce.IdRub)
            'cmbPagam.SelectedIndex = _Voce.Idpagamento
            lblNumDoc.Text = _Voce.Numero
            lblDate.Text = _Voce.DataRicavo
            UcPagamenti.IdDocRif = _Voce.IdRicavo
            UcPagamenti.MostraDati(enTipoVoceContab.VoceVendita)
            txtPercIva.Text = _Voce.PercIva

            CaricaDDT(, , , IdFatt)

            btnRimuovi.Visible = False
            pnlInt.Visible = False
            cmbCliente.Enabled = False

            'DgLavori.Top = pnlInt.Top
            TabDettaglio.Top = pnlInt.Top
            btnConferma.Visible = False
            txtPagamento.ReadOnly = True
            cmbPagam.Enabled = False
            btnStampa.Visible = True

            If _Voce.NaturaEsclIva.Length Then
                MgrControl.SelectIndexComboValore(cmbEsclIvaNat, _Voce.NaturaEsclIva)
                cmbEsclIvaNat.Enabled = False
            End If
            cmbEsigiblitaIVA.Enabled = False
            UcDocumentiFiscaliXMLRicavo.Carica(_Voce)
            Me.Text &= " - " & IdFatt
        Else
            lblAzienda.Text = "-"
            TabDettaglio.TabPages.Remove(tpPagam)
            btnStampa.Visible = False

            lblIntestazione.Visible = False
            'nuova
            lblDate.Text = Now.Date
            'Dim x As New ProgressiviFiscali
            'x.Read(LUNA.LunaContext.IdNumerazioneDocumenti)

            'RIMOSSO PER LA DOPPIA FATTURAZIONE
            lblNumDoc.Text = "-"
            'lblNumDoc.Text = MgrDocumentNumber.GetNextNumber(enTipoDocumento.Fattura)
            lblNumDoc.Text = "-" 'MgrDocumentNumber.GetNextNumber(enTipoDocumento.Fattura)
            'x = Nothing
            btnConferma.Visible = True

            If IdDDT Then
                Using R As New Ricavo
                    R.Read(IdDDT)
                    MgrControl.SelectIndexCombo(cmbAnnoRif, R.AnnoRiferimento)
                    MgrControl.SelectIndexCombo(cmbMese, R.DataRicavo.Month)
                    MgrControl.SelectIndexCombo(cmbCliente, R.IdRub)
                End Using

            End If

        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        'carico l'anno
        'If Not _cnOld Is Nothing Then

        Dim AR As New cAnnoRif
        cmbAnnoRif.DataSource = AR
        cmbAnnoRif.DisplayMember = "Descrizione"
        cmbAnnoRif.ValueMember = "Id"

        'cmbAnnoRif.DataSource = dt

        'carico i mesi


        Dim lIVA As New List(Of cEnum)
        lIVA.Add(New cEnum(enEsigibilitaIVA.Immediata, "Immediata"))
        lIVA.Add(New cEnum(enEsigibilitaIVA.Differita, "Differita"))
        lIVA.Add(New cEnum(enEsigibilitaIVA.SplitPayment, "SplitPayment"))

        cmbEsigiblitaIVA.DisplayMember = "Descrizione"
        cmbEsigiblitaIVA.ValueMember = "Id"
        cmbEsigiblitaIVA.DataSource = lIVA

        Dim x As New cMeseRif
        cmbMese.DataSource = x
        cmbMese.DisplayMember = "Descrizione"
        cmbMese.ValueMember = "Id"

        Dim cli As New VociRubricaDAO
        cmbCliente.ValueMember = "IdRub"
        cmbCliente.DisplayMember = "Nominativo"

        Dim Filtro As String = ""
        If _IdFatt = 0 Then
            Filtro = "DDT"
        End If

        cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, False, Filtro)

        ' End If

        Using PM As New TipoPagamentiDAO
            cmbPagam.DataSource = PM.GetAll(LFM.TipoPagamento.IdTipoPagam, False)
            cmbPagam.ValueMember = "IdTipoPagam"
            cmbPagam.DisplayMember = "TipoPagam"
        End Using

        Dim esclIva As New DictionaryEntry
        Dim lesclIva As New List(Of DictionaryEntry)

        esclIva = New DictionaryEntry("", "-")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N1", "N1 - escluse ex art. 15")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N2", "N2 - non soggette (CODICE NON VALIDO)")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N2.1", "N2.1 - non soggette ad IVA ai sensi degli artt. da 7 a 7-septies del DPR 633/72")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N2.2", "N2.2 - non soggette - altri casi")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N3", "N3 - non imponibili (CODICE NON VALIDO)")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N3.1", "N3.1 - non imponibili - esportazioni")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N3.2", "N3.2 - cessioni intracomunitarie")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N3.3", "N3.3 - cessioni verso San Marino")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N3.4", "N3.4 - operazioni assimilate alle cessioni all'esportazione")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N3.5", "N3.5 - a seguito di dichiarazioni d'intento")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N3.6", "N3.6 - altre operazioni che non concorrono alla formazione del plafond")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N4", "N4 - esenti")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N5", "N5 - regime del margine / IVA non esposta in fattura")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N6", "N6 - inversione contabile (CODICE NON VALIDO)")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N6.1", "N6.1 - inversione contabile - cessione di rottami e altri materiali di recupero")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N6.2", "N6.2 - inversione contabile - cessione di oro e argento puro")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N6.3", "N6.3 - inversione contabile - subappalto nel settore edile")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N6.4", "N6.4 - inversione contabile - cessione di fabbricati")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N6.5", "N6.5 - inversione contabile - cessione di telefoni cellulari")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N6.6", "N6.6 - inversione contabile - cessione di prodotti elettronici")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N6.7", "N6.7 - inversione contabile - prestazioni comparto edile e settori connessi")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N6.8", "N6.8 - inversione contabile - operazioni settore energetico")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N6.9", "N6.9 - inversione contabile - altri casi")
        lesclIva.Add(esclIva)

        esclIva = New DictionaryEntry("N7", "N7 - IVA assolta in altro stato UE")
        lesclIva.Add(esclIva)

        cmbEsclIvaNat.ValueMember = "key"
        cmbEsclIvaNat.DisplayMember = "value"
        cmbEsclIvaNat.DataSource = lesclIva

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub CaricaDDT(Optional ByVal IdCliente As Integer = 0,
                          Optional ByVal Anno As Integer = 0,
                          Optional ByVal Mese As Integer = 0,
                          Optional ByVal IdDocRif As Integer = 0)

        'qui carico i ddt del cliente selezionato per il periodo selezionato che non sono stati gia associati a una fattura riepilogativa
        Dim Rub As New VoceRubrica, NomeCli As String = ""

        Rub.Read(IdCliente)

        Dim Drg As DataGridViewRow, dt As DataTable, dr As DataRow

        Dim x As New cContabRicaviColl
        dt = x.ListaDDT(IdCliente, Anno, Mese, IdDocRif)
        DgLavori.Rows.Clear()

        For Each dr In dt.Rows
            Drg = New DataGridViewRow
            Drg.CreateCells(DgLavori)

            Drg.Cells(0).Value = dr("IdRicavo")
            Drg.Cells(1).Value = CDate(dr("DataRicavo")).ToShortDateString
            Drg.Cells(2).Value = dr("Numero")
            Drg.Cells(3).Value = dr("Descrizione")
            Drg.Cells(4).Value = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(dr("Importo"))
            'Drg.Cells(5).Value = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(dr("Iva"))
            'pDrg.Cells(6).Value = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(dr("Totale"))

            DgLavori.Rows.Add(Drg)
        Next

        'txtIndCons.Text = Rub.IndCons
        txtPagamento.Text = Rub.Pagamento
        If _IdFatt = 0 Then MgrControl.SelectIndexCombo(cmbPagam, Rub.IdPagamento)
        'cmbPagam.SelectedIndex = Rub.IdPagamento

        Rub = Nothing

    End Sub

    Private Sub btnRimuovi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRimuovi.Click
        If _IdFatt = 0 Then
            If DgLavori.SelectedRows.Count Then
                Dim Dr As DataGridViewRow = DgLavori.SelectedRows(0)
                If Dr.Selected Then
                    'sposto la lavorazione tra quelle selezionate

                    DgLavori.Rows.Remove(DgLavori.SelectedRows(0))

                    If DgLavori.Rows.Count = 0 Then _ClienteSel = 0

                End If
            End If
        End If

    End Sub

    Private Sub StampaDoc(ByVal x As Ricavo)
        'prima di uscire mando in stampa il documento contabile
        Dim NumCopie As Integer = 0
        Try
            NumCopie = InputBox("Inserisci il numero di copie che vuoi stampare", "Numero Copie", FormerLib.FormerConst.Fiscali.NumCopieDocFiscali)
        Catch ex As Exception

        End Try

        If NumCopie > 0 Then
            Try
                MgrDocumentiFiscali.MessaggioModuloFattura(x, NumCopie)
                ProxyStampa.StampaDocumentoFiscale(x,
                                                   True,
                                                   NumCopie,
                                                   PostazioneCorrente.UtenteConnesso.IdUt)
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
        'Prn.StampaDocumento(x)
        'Prn = Nothing

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub DgLavori_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLavori.CellDoubleClick
        Dim dr As DataGridViewRow = DgLavori.SelectedRows(0)

        If Not dr Is Nothing Then
            Sottofondo()
            Using x As New frmContabilitaRicavo
                x.Carica(dr.Cells(0).Value, enTipoVoceContab.VoceVendita)
            End Using
            Sottofondo()
        End If

    End Sub

    Private Sub AggiornaTotali()
        Dim x As DataGridViewRow

        _TotImp = 0
        _TotIva = 0

        For Each x In DgLavori.Rows

            _TotImp += x.Cells(4).Value
            '_TotIva += x.Cells(5).Value

        Next
        Dim PercIva As Integer = txtPercIva.Text
        If PercIva Then
            _TotIva = FormerHelper.Finanziarie.CalcolaIva(_TotImp, PercIva)
        End If

        lblTotIva.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo((_TotIva).ToString)
        lblTotImp.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo((_TotImp).ToString)
        lblTotDocum.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo((_TotImp + _TotIva).ToString)

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

    Private Sub DgLavori_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgLavori.RowsAdded
        AggiornaTotali()
    End Sub

    Private Sub DgLavori_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgLavori.RowsRemoved
        AggiornaTotali()
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
        CaricaDocumenti()
    End Sub

    Private Sub cmbMese_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMese.SelectedIndexChanged
        CaricaDocumenti()
    End Sub

    Private Sub CaricaDocumenti()
        Try
            Dim Mese As Integer = 0, AnnoRif As Integer = 0
            If cmbMese.SelectedValue Then Mese = cmbMese.SelectedValue
            If cmbAnnoRif.Text <> "- Tutti" Then AnnoRif = cmbAnnoRif.SelectedValue
            CaricaDDT(cmbCliente.SelectedValue, AnnoRif, Mese)

            MgrControl.SelectIndexComboEnum(cmbEsigiblitaIVA, DirectCast(cmbCliente.SelectedItem, VoceRubrica).EsigibilitaIva)
            _Voce.EsigibilitaIva = DirectCast(cmbEsigiblitaIVA.SelectedItem, cEnum).Id
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDetCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetCli.Click

        If cmbCliente.SelectedIndex <> -1 Then
            ApriCli(cmbCliente.SelectedValue)
        End If
    End Sub

    Private Sub ApriCli(Optional ByVal IdRub As Integer = 0)

        Dim frmRif As New frmVoceRubrica
        Dim ObjRif As New VoceRubrica
        Dim Ris As Integer = 0
        ObjRif.Tipo = enTipoRubrica.Cliente

        If IdRub Then
            ObjRif.Read(IdRub)
        End If

        Sottofondo()
        Ris = frmRif.Carica(ObjRif)
        Sottofondo()

        frmRif.Dispose()
        ObjRif = Nothing

    End Sub

    Private Sub cmbPagam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPagam.SelectedIndexChanged

        Dim Ris As Date = Now.Date

        Dim tp As TipoPagamento = cmbPagam.SelectedItem

        If Not tp Is Nothing Then
            Ris = Ris.AddDays(tp.ggToAdd)
        End If

        lblDataPrevPagam.Text = Ris

    End Sub

    Private Sub btnStampaEmail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnStampaEmail.LinkClicked
        If _IdFatt Then
            If MessageBox.Show("Confermi la stampa del documento in PDF?", "Stampa documento contabile in PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                ProxyStampa.StampaDocumentoFiscalePDF(_Voce)

                FormerHelper.File.ShellExtended(FormerPath.PathFatture(_Voce.IdAzienda))
            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub btnStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnStampa.LinkClicked

        If _IdFatt Then
            If MessageBox.Show("Vuoi stampare il documento emesso?", "Fattura Riepilogativa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                StampaDoc(_Voce)

            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub lnkPrintBarcode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrintBarcode.LinkClicked

        If _IdFatt Then
            If MessageBox.Show("Confermi la stampa del barcode della fattura?", "Stampa Barcode Fattura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim P As New myPrinter
                Dim PrinterName As String = PostazioneCorrente.StampanteConsegnaOrdini

                ''TEMPORANEO PER SCEGLIERE PDFCREATOR
                'Dim prin As New System.Windows.Forms.PrintDialog
                'prin.ShowDialog()
                'If prin.PrinterSettings.PrinterName.Length Then PrinterName = prin.PrinterSettings.PrinterName

                P.PrinterName = PrinterName

                P.StampaBarcodeFattura(_Voce)

                P = Nothing

            End If
        Else
            Beep()

        End If

    End Sub

    Private Sub btnAnnulla_Click(sender As Object, e As EventArgs) Handles btnAnnulla.Click

        Close()

    End Sub

    Private Sub btnConferma_Click(sender As Object, e As EventArgs) Handles btnConferma.Click

        If _IdFatt = 0 Then

            Dim IdAzienda As Integer = 0
            Dim ErroreAzienda As Boolean = False

            If DgLavori.Rows.Count Then

                Dim IdRel As Integer = 0

                For Each Dr In DgLavori.Rows

                    IdRel = Dr.Cells(0).Value
                    Using R As New Ricavo
                        R.Read(IdRel)
                        If IdAzienda = 0 Then
                            IdAzienda = R.IdAzienda
                        Else
                            If IdAzienda <> R.IdAzienda Then
                                ErroreAzienda = True
                            End If
                        End If
                    End Using

                Next

            Else
                MessageBox.Show("Non sono disponibili dei DDT")
            End If

            If ErroreAzienda Then
                MessageBox.Show("I DDT sono riferiti ad aziende diverse")
            Else
                Dim PercIva As Integer = 0
                PercIva = CInt(txtPercIva.Text)


                If PercIva = 0 And cmbEsclIvaNat.SelectedIndex = 0 Then
                    MessageBox.Show("Selezionare la natura dell'esclusione IVA")
                Else
                    If MessageBox.Show("Vuoi emettere il documento fiscale per i DDT selezionati?", "Emissione Fattura Riepilogativa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        'qui mi prendo il numero da assegnare al documento 
                        'Dim num As New ProgressiviFiscali, NumeroDoc As Integer = 0
                        'num.Read(LUNA.LunaContext.IdNumerazioneDocumenti)

                        'NumeroDoc = num.NextFat
                        'num.NextFat += 1

                        'num.Save()
                        'num = Nothing

                        'qui salvo il reale documento e poi lo associo agli ordini
                        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                            Try


                                Using Contab As New cContabRicaviColl
                                    If DgLavori.Rows.Count Then
                                        Dim IdRel As Integer = DgLavori.Rows(0).Cells(0).Value

                                        Using R As New Ricavo
                                            R.Read(IdRel)
                                            IdAzienda = R.IdAzienda
                                        End Using

                                    End If

                                End Using
                                Dim Cliente As New VoceRubrica
                                Cliente.Read(cmbCliente.SelectedValue)

                                Using x As New Ricavo
                                    Dim IdInserito As Integer = 0
                                    x.pRagSoc = Cliente.RagSocNome
                                    x.pIndirizzo = Cliente.Indirizzo
                                    x.pCitta = Cliente.Citta
                                    x.pCap = Cliente.CAP
                                    x.pIva = Cliente.PivaEx

                                    Dim P As TipoPagamento
                                    P = cmbPagam.SelectedItem

                                    x.Descrizione = "Fattura Riepilogativa"
                                    x.Tipo = enTipoDocumento.FatturaRiepilogativa
                                    x.IdCorr = 0
                                    x.CostoCorr = 0
                                    x.DataRicavo = Now.Date
                                    x.IdRub = cmbCliente.SelectedValue
                                    x.pIndCons = ""
                                    x.pPagamento = P.TipoPagam
                                    x.Idpagamento = P.IdTipoPagam
                                    x.PercIva = PercIva
                                    'x.PercIva = FormerHelper.Finanziarie.GetPercentualeIva
                                    x.Iva = _TotIva
                                    x.Importo = _TotImp
                                    x.Totale = _TotImp + _TotIva
                                    x.Dataprevpagam = x.CalcolaDataPrevPagam
                                    x.IdAzienda = IdAzienda
                                    x.StatoFE = enStatoFatturaFE.InCodaInvio
                                    x.EsigibilitaIva = DirectCast(cmbEsigiblitaIVA.SelectedItem, cEnum).Id
                                    If cmbEsclIvaNat.Enabled Then
                                        x.NaturaEsclIva = cmbEsclIvaNat.SelectedValue
                                    Else
                                        x.NaturaEsclIva = String.Empty
                                    End If
                                    tb.TransactionBegin()
                                    x.Numero = MgrDocumentiFiscali.DocumentNumber.GetNextNumber(IdAzienda, enTipoDocumento.Fattura) 'NumeroDoc
                                    IdInserito = x.Save()

                                    Dim IdRel As Integer = 0

                                    Dim Totale As Decimal = 0
                                    Dim TotaleIva As Decimal = 0
                                    Dim Descrizione As String = ""

                                    Dim Dr As DataGridViewRow
                                    Using Contab As New cContabRicaviColl

                                        For Each Dr In DgLavori.Rows

                                            IdRel = Dr.Cells(0).Value
                                            'allego il ddt alla fattura appena inserita
                                            Contab.AllegaDDTaFattura(IdRel, IdInserito)

                                        Next
                                    End Using
                                    tb.TransactionCommit()

                                    MgrDocumentiFiscali.CheckNumeroDocumentiFiscali(Now.Year)

                                    If MessageBox.Show("Vuoi stampare il documento emesso?", "Fattura Riepilogativa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                        StampaDoc(x)

                                    End If
                                End Using
                                _Ris = 1
                                Close()

                            Catch ex As Exception
                                ManageError(ex)
                                tb.TransactionRollBack()
                            End Try
                        End Using

                    End If
                End If

            End If

        Else
            Beep()
        End If
    End Sub

    Private Sub cmbAnnoRif_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnnoRif.SelectedIndexChanged

    End Sub

    Private Sub lnkExportXML_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkExportXML.LinkClicked
        '  If _Voce.Tipo = enTipoDocumento.Fattura Or _Voce.Tipo = enTipoDocumento.FatturaRiepilogativa Then
        If MessageBox.Show("Confermi l'export del documento in XML?", "Export in XML", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim PathTemp As String = FormerPath.PathTempLocale & _Voce.AnnoRiferimento & "\" & _Voce.Numero & "\IT" & MgrAziende.GetPartitaIva(_Voce.IdAzienda) & "_00001.xml"

            FormerHelper.File.CreateLongPath(PathTemp)

            MgrFattureFE.RicavoToXML(_Voce, PathTemp)

            FormerHelper.File.ShellExtended(PathTemp)

            'Dim x As New myPrinter, PrinterName As String
            'PrinterName = Postazione.StampantePDF

            'If _Voce.tipo = enTipoDocumento.enTipoDocPreventivo Then
            '    Dim prin As New System.Windows.Forms.PrintDialog
            '    prin.ShowDialog()
            '    If prin.PrinterSettings.PrinterName.Length Then PrinterName = prin.PrinterSettings.PrinterName
            'End If

            'x.PrinterName = PrinterName

            'x.StampaDocumento(_Voce, True)

            'x = Nothing

        End If
        ' Else
        ' MessageBox.Show("Si possono esportare in XML solo le Fatture e le Fatture riepilogative")
        ' End If
    End Sub

    Private Sub lblIntestazione_TextChanged(sender As Object, e As EventArgs) Handles lblIntestazione.TextChanged

    End Sub

    Private Sub UcDocumentiFiscaliXMLRicavo_Load(sender As Object, e As EventArgs) Handles UcDocumentiFiscaliXMLRicavo.Load

    End Sub

    Private Sub lnkIva4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkIva4.LinkClicked
        If MgrFattureFE.FatturaEmessaModificabile(_IdFatt) Then
            If MessageBox.Show("Vuoi trasformare questa fattura con IVA al 4%?", "Fattura IVA 4%", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                txtPercIva.Text = 4
                CaricaDocumenti()


            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile")
        End If
    End Sub

    Private Sub lnkNoIva_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNoIva.LinkClicked
        If MgrFattureFE.FatturaEmessaModificabile(_IdFatt) Then
            If MessageBox.Show("Vuoi trasformare questa fattura con IVA al 0%?", "Fattura IVA 0%", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                txtPercIva.Text = 0
                cmbEsclIvaNat.Enabled = True
                CaricaDocumenti()
            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile")
        End If
    End Sub
End Class