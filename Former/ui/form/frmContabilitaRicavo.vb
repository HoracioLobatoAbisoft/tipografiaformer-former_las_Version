Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports System.Data.SqlClient
Imports FormerPrinter
Imports FormerConfig
Imports FormerBusinessLogic

Public Class frmContabilitaRicavo
    'Inherits baseFormInternaRedim

    Private _Voce As Ricavo = Nothing
    Private _IdRub As Integer
    Private _ris As Integer = 0
    Private _IdVoce As Integer = 0
    Private _TipoVoce As Integer = 0
    Private _TipoDocDefault As enTipoDocumento
    Private _Da As SqlDataAdapter
    Private _Ds As DataSet
    Private _bs As New BindingSource
    Private _ModificatiOrdini As Boolean = False

    Private Sub BloccaFattura(Interruttore As Boolean)

        'cmbTipoVoce.Enabled = Interruttore
        cmbTipo.Enabled = Interruttore
        cmbCat.Enabled = Interruttore

        dataOp.Enabled = Interruttore
        cmbCliente.Enabled = Interruttore

        txtImporto.Enabled = Interruttore
        txtNumero.Enabled = Interruttore
        txtDescrizione.Enabled = Interruttore
        txtPercIva.Enabled = Interruttore
        txtIva.Enabled = Interruttore
        cmbCorriere.Enabled = Interruttore

        lblCostoSped.Enabled = Interruttore

        lnkIva4.Enabled = Interruttore
        lnkNoIva.Enabled = Interruttore
        cmbEsigiblitaIVA.Enabled = Interruttore
        'cmbEsclIvaNat.Enabled = Interruttore
        'btnOk.Visible = Interruttore

    End Sub

    Private Sub AggiornaContatoreStampe()

        lblPrintCounter.Visible = True
        lblPrintCounter.Text = lblPrintCounter.Tag & _Voce.CounterStampe

    End Sub

    Friend Function Carica(Optional ByVal IdVoce As Integer = 0,
                           Optional ByVal _IdRub As Integer = 0,
                           Optional ByVal TipoDocDefault As enTipoDocumento = enTipoDocumento.Fattura) As Integer
        _IdVoce = IdVoce
        _TipoVoce = enTipoVoceContab.VoceVendita
        _TipoDocDefault = TipoDocDefault



        'Dim X As New cTipoVoceContab

        'cmbTipoVoce.DataSource = X
        'cmbTipoVoce.ValueMember = "Id"
        'cmbTipoVoce.DisplayMember = "Descrizione"

        CaricaCombo()

        tbDett.TabPages.Remove(tbVociFat)
        tbDett.TabPages.Remove(tpPagam)
        'tbDett.TabPages.Remove(tpRisorse)
        'tbDett.TabPages.Remove(tbImmagini)
        tbDett.TabPages.Remove(tpVociFat)
        tbDett.TabPages.Remove(tpStatoIncasso)

        lnkSetIncassoNormale.BackColor = FormerColori.ColoreStatoIncassoNormale
        lnkSetIncassoProblematico.BackColor = FormerColori.ColoreStatoIncassoProblematico
        lnkSetIncassoDifficile.BackColor = FormerColori.ColoreStatoIncassoDifficile
        lnkSetIncassoImpossibile.BackColor = FormerColori.ColoreStatoIncassoImpossibile

        If IdVoce Then
            BloccaFattura(False)
            pctSblocco.Visible = True
            'If TipoVoce = enTipoVoceContab.VoceAcquisto Then

            '    cmbCorriere.Visible = False
            '    lblCorr1.Visible = False
            '    lblCorr2.Visible = False
            '    lblCorr2.Visible = False
            '    lblCostoSped.Visible = False
            '    lblTotOrdini.Visible = False
            '    lblTotOrdini2.Visible = False
            '    'lblCorr3.Visible = False

            '    Using Costo As New Costo
            '        Costo.Read(IdVoce)
            '        _Voce = Costo
            '    End Using
            '    UcAcquistoRisorse.IdFat = IdVoce
            '    UcAcquistoRisorse.IdForn = _Voce.idrub
            '    UcAcquistoRisorse.Carica()

            '    tbDett.TabPages.Add(tpRisorse)
            '    tbDett.TabPages.Add(tbImmagini)
            '    tbDett.TabPages.Add(tpPagam)
            '    tbDett.TabPages.Add(tpStatoIncasso)
            '    tbDett.Enabled = True

            '    lblIntestazione.Visible = False
            '    lblTipoCli.Text = "Mittente *"

            '    btnStampaEmail.Visible = False
            '    btnRiapriPdf.Visible = False
            '    lnkPrintBarcode.Visible = False
            '    lnkApriCons.Visible = False
            '    txtImporto.ReadOnly = False
            '    'txtIva.ReadOnly = False

            '    lblStatoIncasso.Text = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Normale)
            '    lblStatoIncasso.BackColor = FormerColori.ColoreStatoIncassoNormale

            'Else
            Dim Ricavo As New Ricavo
            Ricavo.Read(IdVoce)
            _Voce = Ricavo
            lblAzienda.Text = MgrAziende.GetAziendaStr(_Voce.IdAzienda)

            If _Voce.IdCorr Then
                MgrControl.SelectIndexCombo(cmbCorriere, _Voce.IdCorr)
                lblCostoSped.Text = FormerHelper.Stringhe.FormattaPrezzo(_Voce.CostoCorr)

            End If

            AggiornaContatoreStampe()
            'If _Voce.piva.length <> 0 Then

            'qui è stata creata dal programma
            tbDett.TabPages.Add(tbVociFat)
            tbDett.TabPages.Add(tpPagam)
            'tbDett.TabPages.Add(tbImmagini)
            tbDett.TabPages.Add(tpVociFat)
            tbDett.TabPages.Add(tpStatoIncasso)

            CaricaVociFat()

            CaricaDettagliFat()

            lblTotOrdini.Text = FormerHelper.Stringhe.FormattaPrezzo(GetTotaleNettoOrdini())

            btnStampa.Visible = True

            'End If
            txtImporto.ReadOnly = True
            txtIva.ReadOnly = True

            If _Voce.Tipo <> enTipoDocumento.Fattura And _Voce.Tipo <> enTipoDocumento.FatturaRiepilogativa Then
                lnkNoIva.Enabled = False
            End If

            lblStatoIncasso.Text = FormerEnumHelper.GetStatoIncassoStr(Ricavo.StatoIncasso)
            lblStatoIncasso.BackColor = FormerColori.GetColoreStatoIncasso(Ricavo.StatoIncasso)

            'End If

            MostraControlli()

            MgrControl.SelectIndexCombo(cmbCat, _Voce.IdCat)
            'MgrControl.SelectIndexCombo(cmbTipoVoce, _TipoVoce)
            MgrControl.SelectIndexCombo(cmbCliente, _Voce.IdRub)
            MgrControl.SelectIndexCombo(cmbTipo, _Voce.Tipo)

            MgrControl.SelectIndexComboEnum(cmbEsigiblitaIVA, _Voce.EsigibilitaIva)
            'cmbTipoVoce.Enabled = False

            txtDescrizione.Text = _Voce.Descrizione
            dataOp.Value = _Voce.DataRif
            txtImporto.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Voce.Importo, 2)
            txtIva.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Voce.Iva, 2)
            txtNumero.Text = _Voce.Numero
            txtPercIva.Text = _Voce.PercIva
            If _Voce.NaturaEsclIva.Length Then
                MgrControl.SelectIndexComboValore(cmbEsclIvaNat, _Voce.NaturaEsclIva)
            End If

            'txtFile.Text = _Voce.Scansione
            'txtFile1.Text = _Voce.Scansione1
            'txtFile2.Text = _Voce.Scansione2
            'txtFile3.Text = _Voce.Scansione3
            'txtFile4.Text = _Voce.Scansione4
            CalcolaTot()

            If _Voce.Tipo = enTipoDocumento.DDT Then

                lnkRegPagamento.Visible = False
                lnkApriCons.Visible = False
                btnRiapriPdf.Visible = False
                pnlImporti.Visible = False

                Try
                    'DA SISTEMARE QUANDO RIFACCIAMO LA PARTE CONTABILE
                    If _Voce.IdDocRif <> 0 Then lnkFattRiepilog.Visible = True
                Catch ex As Exception

                End Try

            Else
                pnlImporti.Visible = True
            End If

            Dim Intestazione As String = MgrDocumentiFiscali.GetIntestazione(_Voce)

            lblIntestazione.Text = Intestazione
            'Try
            txtDataPrevPagam.Value = _Voce.Dataprevpagam
            'Catch ex As Exception
            'txtDataPrevPagam.Value = _Voce.datacosto
            'End Try

            'carico i pagamenti

            UcPagamenti.IdDocRif = IdVoce
            UcPagamenti.MostraDati(_TipoVoce)

            txtDataPrevPagam.Enabled = False

            If _Voce.Tipo = enTipoDocumento.Preventivo OrElse _Voce.Tipo = enTipoDocumento.DDT Then
                TabRicavo.TabPages.Remove(tpFatturaXML)

            Else
                UcDocumentiFiscaliXMLRicavo.Carica(_Voce)
            End If

            If Not _Voce.NotaDiCreditoRelativa Is Nothing Then
                lnkNotaCredito.Visible = True
            Else
                lnkNotaCredito.Visible = False
            End If
            Me.Text &= " - " & IdVoce

        Else
            txtPercIva.Text = FormerHelper.Finanziarie.GetPercentualeIva

            MgrControl.SelectIndexComboEnum(cmbTipo, TipoDocDefault)

            'If TipoVoce = enTipoVoceContab.VoceAcquisto Then
            '    Dim Costo As New Costo
            '    _Voce = Costo
            '    tbDett.TabPages.Add(tpRisorse)
            '    tbDett.TabPages.Add(tbImmagini)
            '    tbDett.Enabled = False

            '    lblIntestazione.Visible = False
            '    lblTipoCli.Text = "Mittente *"

            '    cmbCorriere.Visible = False
            '    lblCorr1.Visible = False
            '    lblCorr2.Visible = False
            '    lblCorr2.Visible = False
            '    lblCostoSped.Visible = False
            '    lblAlert.Visible = True
            '    lblTotOrdini.Visible = False
            '    lblTotOrdini2.Visible = False
            '    'btnStampaEmail.Visible = False
            '    txtImporto.ReadOnly = False
            MgrControl.SelectIndexComboEnum(cmbEsigiblitaIVA, enEsigibilitaIVA.Immediata)
            'End If
            btnStampaEmail.Visible = False
            txtDataPrevPagam.Value = Now.Date
            'cmbTipoVoce.SelectedIndex = 0
            'cmbTipoVoce.Enabled = False
            btnStampa.Visible = False
            btnRiapriPdf.Visible = False
            btnOk.Visible = True
            btnConferma.Visible = True
        End If

        If _IdVoce = 0 And _IdRub <> 0 Then
            MgrControl.SelectIndexCombo(cmbCliente, _IdRub)
            cmbCliente.Enabled = False
        End If

        ShowDialog()

        Return _ris

    End Function

    Private Sub CaricaDettagliFat()

        'carica le voci in fattura 

        Using VociFat As New cVociFatColl
            _Ds = VociFat.ListaVociFat(_Voce.IdRicavo, _Da)
        End Using
        'Dim bs As New BindingSource
        'bs = New BindingSource()
        'bs.DataSource = Ds
        'bs.DataMember = "DettFatt"

        _bs.DataSource = _Ds
        _bs.DataMember = "DettFatt"
        dgVociFat.DataSource = _bs
        dgVociFat.Columns(0).Visible = False

    End Sub

    Private Sub CaricaVociFat()

        Dim Dt As DataTable
        'carica le voci in fattura 
        Using VociFat As New cVociFatColl
            Dt = VociFat.Lista(_Voce.IdRicavo)
        End Using

        Dim Dr As DataRow, Buffer As String = ""
        DgDoc.Rows.Clear()
        For Each Dr In Dt.Rows

            Dim Drg As New DataGridViewRow

            Dim ImgPreview As Image
            Dim ImgNew As Image
            Try
                ImgPreview = Image.FromFile(Dr("FilePath").ToString)
                ImgNew = New Bitmap(ImgPreview, New Size(50, 75))
            Catch ex As Exception
                ImgNew = Nothing
            End Try

            Drg.CreateCells(DgDoc)

            Drg.Cells(0).Value = ImgNew
            Drg.Cells(1).Value = Dr("IdOrd").ToString
            Drg.Cells(2).Value = Dr("Codice").ToString
            Drg.Cells(3).Value = Dr("Descrizione").ToString
            Drg.Cells(4).Value = Dr("Qta").ToString
            Drg.Cells(5).Value = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Dr("importo").ToString)

            DgDoc.Rows.Add(Drg)

        Next

    End Sub

    Private Sub CaricaCombo()

        CaricaCli()

        Dim x As New cTipoDoc(, True)
        cmbTipo.DisplayMember = "Descrizione"
        cmbTipo.ValueMember = "Id"
        cmbTipo.DataSource = x

        Using Corriere As New CorrieriDAO

            cmbCorriere.DataSource = Corriere.GetAll(LFM.Corriere.Descrizione, False)
            cmbCorriere.ValueMember = "IdCorriere"
            cmbCorriere.DisplayMember = "Descrizione"
        End Using


        Dim lIVA As New List(Of cEnum)
        lIVA.Add(New cEnum(enEsigibilitaIVA.Immediata, "Immediata"))
        lIVA.Add(New cEnum(enEsigibilitaIVA.Differita, "Differita"))
        lIVA.Add(New cEnum(enEsigibilitaIVA.SplitPayment, "SplitPayment"))

        cmbEsigiblitaIVA.DisplayMember = "Descrizione"
        cmbEsigiblitaIVA.ValueMember = "Id"
        cmbEsigiblitaIVA.DataSource = lIVA

        Using CatContab As New CategContabiliDAO()
            Dim Lista As List(Of CategContabile) = CatContab.FindAll(LFM.CategContabile.NomeCat,
                                                                     New LUNA.LunaSearchParameter(LFM.CategContabile.TipoCat, _TipoVoce))

            cmbCat.DataSource = Lista
            cmbCat.ValueMember = "IdCatContab"
            cmbCat.DisplayMember = "NomeCat"
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

    Private Sub MostraControlli()
        Try
            'If CInt(cmbTipoVoce.SelectedValue) = CInt(enTipoVoceContab.VoceAcquisto) Then

            '    lblCorr1.Visible = False
            '    lblCorr2.Visible = False
            '    cmbCorriere.Visible = False
            '    lblCostoSped.Visible = False

            'Else
            lblCorr1.Visible = True
            lblCorr2.Visible = True
            cmbCorriere.Visible = True
            lblCostoSped.Visible = True

            'End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function SalvaDatiFattura() As Integer
        Dim Ris As Integer = 0

        If _Voce Is Nothing Then

            'If cmbTipoVoce.SelectedValue = enTipoVoceContab.VoceAcquisto Then
            '    _Voce = New Costo

            'Else
            _Voce = New Ricavo
            'End If
        End If


        'salvo i dati
        _Voce.Tipo = cmbTipo.SelectedValue
        _Voce.IdCat = cmbCat.SelectedValue
        _Voce.Descrizione = txtDescrizione.Text
        _Voce.DataRif = dataOp.Value

        If _IdVoce = 0 Then _Voce.Dataprevpagam = txtDataPrevPagam.Value
        'qui copio i file delle fatture nella dir fatture

        'If txtFile.Text.Length And txtFile.Text <> _Voce.Scansione Then
        '    Dim Est As String = "." & txtFile.Text.Substring(txtFile.Text.Length - 3)
        '    Dim NomeFile1 As String = FormerPath.PathFattureAcquisto & "Fatt_" & FormerLib.FormerHelper.File.GetNomeFileTemp(Est)
        '    MgrIO.FileCopia(Me, txtFile.Text, NomeFile1)
        '    _Voce.Scansione = NomeFile1
        'End If

        'If txtFile1.Text.Length And txtFile1.Text <> _Voce.Scansione1 Then
        '    Dim Est As String = "." & txtFile1.Text.Substring(txtFile1.Text.Length - 3)
        '    Dim NomeFile2 As String = FormerPath.PathFattureAcquisto & "Fatt_" & FormerLib.FormerHelper.File.GetNomeFileTemp(Est)
        '    MgrIO.FileCopia(Me, txtFile1.Text, NomeFile2)
        '    _Voce.Scansione1 = NomeFile2
        'End If

        'If txtFile2.Text.Length And txtFile2.Text <> _Voce.Scansione2 Then
        '    Dim Est As String = "." & txtFile2.Text.Substring(txtFile2.Text.Length - 3)
        '    Dim NomeFile3 As String = FormerPath.PathFattureAcquisto & "Fatt_" & FormerLib.FormerHelper.File.GetNomeFileTemp(Est)
        '    MgrIO.FileCopia(Me, txtFile2.Text, NomeFile3)
        '    _Voce.Scansione2 = NomeFile3
        'End If

        'If txtFile3.Text.Length And txtFile3.Text <> _Voce.Scansione3 Then
        '    Dim Est As String = "." & txtFile3.Text.Substring(txtFile3.Text.Length - 3)
        '    Dim NomeFile4 As String = FormerPath.PathFattureAcquisto & "Fatt_" & FormerLib.FormerHelper.File.GetNomeFileTemp(Est)
        '    MgrIO.FileCopia(Me, txtFile3.Text, NomeFile4)
        '    _Voce.Scansione3 = NomeFile4
        'End If

        'If txtFile4.Text.Length And txtFile4.Text <> _Voce.Scansione4 Then
        '    Dim Est As String = "." & txtFile4.Text.Substring(txtFile4.Text.Length - 3)
        '    Dim NomeFile5 As String = FormerPath.PathFattureAcquisto & "Fatt_" & FormerLib.FormerHelper.File.GetNomeFileTemp(Est)
        '    MgrIO.FileCopia(Me, txtFile4.Text, NomeFile5)
        '    _Voce.Scansione4 = NomeFile5
        'End If
        If _Voce.IdRub <> cmbCliente.SelectedValue Then
            Dim Cliente As New VoceRubrica
            Cliente.Read(cmbCliente.SelectedValue)
            _Voce.pRagSoc = Cliente.RagSoc
            _Voce.pIndirizzo = Cliente.Indirizzo
            _Voce.pCitta = Cliente.Citta
            _Voce.pCap = Cliente.CAP
            _Voce.pIva = Cliente.PivaEx
        End If
        _Voce.IdRub = cmbCliente.SelectedValue

        If cmbCorriere.SelectedIndex <> -1 Then
            _Voce.IdCorr = cmbCorriere.SelectedValue
            _Voce.CostoCorr = lblCostoSped.Text
        End If
        _Voce.Importo = CDec(txtImporto.Text) '+ _Voce.costocorr
        '_Voce.iva = txtIva.Text
        _Voce.PercIva = CInt(txtPercIva.Text)

        If cmbEsclIvaNat.Enabled Then
            _Voce.NaturaEsclIva = cmbEsclIvaNat.SelectedValue
        Else
            _Voce.NaturaEsclIva = String.Empty
        End If

        If cmbTipo.SelectedValue <> enTipoDocumento.Preventivo Then _Voce.Iva = _Voce.Importo * _Voce.PercIva / 100
        _Voce.Totale = _Voce.Importo + _Voce.Iva
        _Voce.EsigibilitaIva = DirectCast(cmbEsigiblitaIVA.SelectedItem, cEnum).Id
        _ris = 1

        'QUI CONTROLLARE UNIVOCITA NUMERO
        'A PARITA DI NUMERO PER LO STESSO TIPO DI DOCUMENTO E QUESTO ANNO IN CUI E' EMESSO IL DOCUMENTO
        If _IdVoce = 0 Then
            'If cmbTipoVoce.SelectedValue = enTipoVoceContab.VoceAcquisto Then
            '    _Voce.Numero = txtNumero.Text
            'Else
            'qui devo richiedere il numero al proxy dei numeri 
            _Voce.Numero = MgrDocumentiFiscali.DocumentNumber.GetNextNumber(MgrAziende.IdAziende.AziendaSrl, cmbTipo.SelectedValue) 'txtNumero.Text
            'End If
        Else
            If txtNumero.Text.Length Then _Voce.Numero = txtNumero.Text
        End If
        Ris = _Voce.Save()

        Return Ris
    End Function

    Private Sub btnConferma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConferma.Click

        'If txtDescrizione.Text.Length = 0 Then
        '    MessageBox.Show("Inserire una descrizione!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If cmbTipo.SelectedValue <> enTipoDocumento.DDT And txtImporto.Text.Length = 0 Then
                MessageBox.Show("Inserire un importo!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            If cmbTipo.SelectedValue <> enTipoDocumento.DDT And txtPercIva.Text.Length = 0 Then
                MessageBox.Show("Inserire una percentuale iva!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            If cmbTipo.SelectedValue <> enTipoDocumento.DDT And txtIva.Text.Length = 0 Then
                MessageBox.Show("Inserire l'iva!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If DgDoc.Rows.Count = 0 Then
                If _TipoVoce = enTipoVoceContab.VoceVendita Then
                    MessageBox.Show("Inserire almeno un ordine in fattura!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

            End If

            If txtPercIva.Text = 0 Then
                If cmbEsclIvaNat.SelectedItem Is Nothing OrElse cmbEsclIvaNat.SelectedValue = String.Empty Then
                    MessageBox.Show("Selezionare una causale esclusione IVA!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            If _TipoVoce = enTipoVoceContab.VoceVendita Then
                If DgDoc.SelectedRows.Count Then
                    Dim Dr As DataGridViewRow = DgDoc.SelectedRows(0)
                    If Dr.Selected Then
                        Dim IdOrd As Integer = 0
                        IdOrd = Dr.Cells(1).Value
                        Dim O As New Ordine
                        O.Read(IdOrd)
                        Dim CostoSpedInserito As Single = lblCostoSped.Value
                        Dim CostoCalcolato As Decimal = O.ConsegnaAssociata.CalcolaImportoSpedizioni
                        If CostoSpedInserito <> CostoCalcolato Then
                            If MessageBox.Show("Il costo di spedizione inserito di euro " & CostoSpedInserito & " non corrisponde a quello calcolato di euro " & Convert.ToSingle(CostoCalcolato) & "." & vbCrLf & "Confermi il salvataggio?", "Contabilità", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If

            If MessageBox.Show("Confermi il salvataggio dei dati?", "Contabilità", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim IdVoceInserita As Integer = 0


                Using F As New RicaviDAO
                    Dim FattTrovata As Ricavo = Nothing

                    'If cmbTipoVoce.SelectedValue = enTipoVoceContab.VoceVendita Then

                    Dim Tipo As String = String.Empty
                    Dim TipoDoc As Integer = cmbTipo.SelectedValue

                    Select Case TipoDoc
                        Case enTipoDocumento.DDT, enTipoDocumento.Preventivo, enTipoDocumento.NotaDiCredito, enTipoDocumento.NotaDiDebito, enTipoDocumento.AccontoAnticipoSuFattura
                            Tipo = "(" & TipoDoc & ")"
                        Case enTipoDocumento.Fattura, enTipoDocumento.FatturaRiepilogativa
                            Tipo = "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & ")"
                    End Select

                    Dim AnnoRiferimento As Integer = Year(dataOp.Value)
                    FattTrovata = F.Find(New LUNA.LunaSearchParameter(LFM.Ricavo.Numero, txtNumero.Text),
                                                New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, Tipo, "IN"),
                                                New LUNA.LunaSearchParameter("year(DataRicavo)", AnnoRiferimento),
                                                New LUNA.LunaSearchParameter(LFM.Ricavo.IdRicavo, _Voce.IdRicavo, "<>"),
                                                New LUNA.LunaSearchParameter(LFM.Ricavo.IdAzienda, _Voce.IdAzienda))
                    'End If

                    If Not FattTrovata Is Nothing Then
                        MessageBox.Show("Il numero di questo documento fiscale esiste già!", "Numero documento fiscale già presente", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        Dim OkSalvataggio As Boolean = True
                        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

                            Try
                                tb.TransactionBegin()
                                'If cmbTipoVoce.SelectedValue = enTipoVoceContab.VoceVendita Then

                                'qui devo controllare se cambia il cliente della fattura devo cambiare sia la consegna che gli ordini a nome suo
                                If _Voce.IdRub <> cmbCliente.SelectedValue Then

                                    'metto gli ordini sempre alla persona 
                                    For Each Riga As DataGridViewRow In DgDoc.Rows

                                        Dim IdOrd As Integer = Riga.Cells(1).Value

                                        Using o As New Ordine
                                            o.Read(IdOrd)

                                            o.IdRub = cmbCliente.SelectedValue
                                            o.LastUpdate = enSiNo.Si
                                            o.Save()
                                            o.ConsegnaAssociata.IdRub = cmbCliente.SelectedValue
                                            o.ConsegnaAssociata.LastUpdate = enSiNo.Si
                                            o.ConsegnaAssociata.Save()
                                            'TODO:SISTEMARE PERCHE QUI SI GENERA L'INCONSISTENZA DELLA CONSEGNA
                                        End Using

                                    Next

                                    'qui devo spostare anche i pagamenti a questa persona

                                    Using mgr As New PagamentiDAO
                                        Dim ParDocRif As LUNA.LunaSearchParameter = Nothing

                                        ParDocRif = New LUNA.LunaSearchParameter(LFM.Pagamento.IdFat, _Voce.IdRicavo)

                                        Dim ParTipoVoce As LUNA.LunaSearchParameter = New LUNA.LunaSearchParameter(LFM.Pagamento.Tipo, enTipoVoceContab.VoceVendita)

                                        Dim l As List(Of Pagamento) = mgr.FindAll("DataPag Desc", ParDocRif, ParTipoVoce)

                                        For Each SingPag As Pagamento In l
                                            SingPag.IdRub = cmbCliente.SelectedValue
                                            SingPag.Save()
                                        Next

                                    End Using

                                End If

                                If _Voce.Tipo <> cmbTipo.SelectedValue Then
                                    'qui è stato cambiato il tipo di documento devo rendere coerenti tutti gli ordini contenuti all'interno
                                    For Each Riga As DataGridViewRow In DgDoc.Rows

                                        Dim IdOrd As Integer = Riga.Cells(1).Value

                                        Using o As New Ordine
                                            o.Read(IdOrd)
                                            If _Voce.Tipo = enTipoDocumento.Preventivo Then
                                                o.Preventivo = enSiNo.Si
                                            Else
                                                o.Preventivo = enSiNo.No
                                            End If
                                            o.LastUpdate = enSiNo.Si
                                            o.Save()

                                        End Using

                                    Next
                                End If

                                'End If

                                IdVoceInserita = SalvaDatiFattura()

                                tb.TransactionCommit()
                            Catch ex As Exception
                                tb.TransactionRollBack()
                                OkSalvataggio = False
                                ManageError(ex)
                            End Try

                        End Using

                        'If OkSalvataggio Then
                        '    'If cmbTipoVoce.SelectedValue = enTipoVoceContab.VoceVendita Then

                        '    ProxyStampa.StampaDocumentoFiscalePDF(_Voce)

                        '    'End If

                        '    'in _idvoce ho l'id voce appena inserito, ora abilito il caricamento del dettaglio 
                        '    Close()
                        'Else
                        '    Close()
                        'End If
                        Close()

                    End If
                End Using

            End If
        End If


    End Sub

    Private Sub txtImporto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporto.TextChanged, txtPercIva.TextChanged
        'calcolo l'iva

        CalcolaIva()
        CalcolaTot()
    End Sub

    Private Sub CalcolaTot()
        Try
            Dim Ris As Decimal = CDec(txtImporto.Text) + CDec(txtIva.Text) '+ CDbl(lblCostoSped.Text)
            lblTotale.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Ris)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CalcolaIva()
        Dim ImportoIva As Decimal = 0
        Try
            If _Voce.Tipo <> enTipoDocumento.Preventivo Then
                If CDec(txtImporto.Text) <> 0 Then
                    If txtPercIva.Text <> 0 Then
                        ImportoIva = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(((CDec(txtImporto.Text) / 100) * txtPercIva.Text), 2)
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
        txtIva.Text = ImportoIva
    End Sub

    'Private Sub btnSfoglia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim path As String = ""

    '    OpenFileDialog.ShowDialog()
    '    If OpenFileDialog.FileName.Length Then
    '        path = OpenFileDialog.FileName
    '        txtFile.Text = path
    '    End If
    'End Sub

    'Private Sub lnkApri_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    If txtFile.TextLength Then
    '        Try

    '            Dim PathMOd As String = txtFile.Text

    '            Dim x As New Process

    '            x.StartInfo.FileName = PathMOd
    '            x.Start()
    '        Catch ex As Exception

    '            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        End Try
    '    End If
    'End Sub

    'Private Sub btnSfoglia1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim path As String = ""

    '    OpenFileDialog.ShowDialog()
    '    If OpenFileDialog.FileName.Length Then
    '        path = OpenFileDialog.FileName
    '        txtFile1.Text = path
    '    End If
    'End Sub

    'Private Sub btnSfoglia2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim path As String = ""

    '    OpenFileDialog.ShowDialog()
    '    If OpenFileDialog.FileName.Length Then
    '        path = OpenFileDialog.FileName
    '        txtFile2.Text = path
    '    End If
    'End Sub

    'Private Sub btnSfoglia3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim path As String = ""

    '    OpenFileDialog.ShowDialog()
    '    If OpenFileDialog.FileName.Length Then
    '        path = OpenFileDialog.FileName
    '        txtFile3.Text = path
    '    End If
    'End Sub

    'Private Sub btnSfoglia4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim path As String = ""

    '    OpenFileDialog.ShowDialog()
    '    If OpenFileDialog.FileName.Length Then
    '        path = OpenFileDialog.FileName
    '        txtFile4.Text = path
    '    End If
    'End Sub

    'Private Sub lnkApri1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    If txtFile1.TextLength Then
    '        Try

    '            Dim PathMOd As String = txtFile1.Text

    '            Dim x As New Process

    '            x.StartInfo.FileName = PathMOd
    '            x.Start()
    '        Catch ex As Exception

    '            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        End Try
    '    End If
    'End Sub

    'Private Sub lnkApri2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    If txtFile2.TextLength Then
    '        Try

    '            Dim PathMOd As String = txtFile2.Text

    '            Dim x As New Process

    '            x.StartInfo.FileName = PathMOd
    '            x.Start()
    '        Catch ex As Exception

    '            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        End Try
    '    End If
    'End Sub

    'Private Sub lnkApri3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    If txtFile3.TextLength Then
    '        Try

    '            Dim PathMOd As String = txtFile3.Text

    '            Dim x As New Process

    '            x.StartInfo.FileName = PathMOd
    '            x.Start()
    '        Catch ex As Exception

    '            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        End Try
    '    End If
    'End Sub

    'Private Sub lnkApri4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    If txtFile4.TextLength Then
    '        Try

    '            Dim PathMOd As String = txtFile4.Text

    '            Dim x As New Process

    '            x.StartInfo.FileName = PathMOd
    '            x.Start()
    '        Catch ex As Exception

    '            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        End Try
    '    End If
    'End Sub

    Private Sub CaricaCli()

        Using cli As New VociRubricaDAO
            cmbCliente.ValueMember = "IdRub"
            cmbCliente.DisplayMember = "Nominativo"

            cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, False,,,,,, IIf(_TipoVoce = enTipoVoceContab.VoceAcquisto, True, False))
        End Using
    End Sub

    Private Sub cmbTipoVoce_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        MostraControlli()

    End Sub

    Private Sub cmbCorriere_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCorriere.SelectedIndexChanged
        Try

            Dim costo As String = "0,00"

            If cmbCorriere.SelectedIndex <> -1 Then

                Dim voce As Integer = 0
                voce = cmbCorriere.SelectedItem(0)

                Using corr As New Corriere
                    corr.Read(voce)
                    costo = FormerHelper.Stringhe.FormattaPrezzo(corr.Costo) 'Corr.LeggiPrezzo(voce)
                End Using

            End If

            lblCostoSped.Text = costo
            RicalcolaTotali()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnStampa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStampa.Click

        If MessageBox.Show("Confermi la stampa del documento?", "Stampa documento contabile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim NumCopie As Integer = 0
            Try
                NumCopie = InputBox("Inserisci il numero di copie che vuoi stampare", "Numero Copie", FormerLib.FormerConst.Fiscali.NumCopieDocFiscali)
            Catch ex As Exception

            End Try

            If NumCopie > 0 Then
                Try
                    MgrDocumentiFiscali.MessaggioModuloFattura(_Voce, NumCopie)
                    ProxyStampa.StampaDocumentoFiscale(_Voce, True, NumCopie, PostazioneCorrente.UtenteConnesso.IdUt)
                Catch ex As Exception
                    MessageBox.Show("Si è verificato un errore nella stampa del documento fiscale, riprovare")
                End Try

                AggiornaContatoreStampe()
                'qui chiedere se si vuole stampare la situazione contabile del cliente 
                If _TipoVoce = enTipoVoceContab.VoceVendita Then
                    Using Rub As New VoceRubrica
                        Rub.Read(_Voce.IdRub)

                        'Dim lo As List(Of Ordine) = Nothing
                        'Using mgr As New OrdiniDAO
                        '    lo = mgr.FindAll(New LUNA.LunaSearchParameter("IdRub", _Voce.IdRub), New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Consegnato))
                        'End Using

                        'If lo.Count Then

                        Dim lstIdDocRif As New List(Of Integer) From {_Voce.IdDocRif}

                        If Rub.HaDocumentiInSospeso(lstIdDocRif) Then

                            If MessageBox.Show("Vuoi stampare la situazione contabile del cliente?", "Situazione Contabile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                'prima di uscire mando in stampa il documento contabile
                                Sottofondo()
                                StampaBuffer(Rub.SituazioneContabile)
                                Sottofondo()

                            End If
                        End If
                    End Using
                End If
            Else
                MessageBox.Show("Inserire un numero di copie valido")
            End If

            'Dim x As New myPrinter, PrinterName As String
            'PrinterName = Postazione.StampanteFatture

            'If _Voce.tipo = enTipoDocumento.enTipoDocPreventivo Then
            '    Dim prin As New System.Windows.Forms.PrintDialog
            '    prin.ShowDialog()
            '    If prin.PrinterSettings.PrinterName.Length Then PrinterName = prin.PrinterSettings.PrinterName
            'End If

            'x.PrinterName = PrinterName

            'x.StampaDocumento(_Voce)

            'x = Nothing

        End If

    End Sub

    'Private Sub lblCostoSped_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lblCostoSped.KeyPress
    '    MgrControl.ControlloNumerico(sender, e, False)
    'End Sub

    'Private Sub lblCostoSped_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCostoSped.TextChanged
    '    CalcolaIva()
    '    CalcolaTot()
    'End Sub

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

    Private Sub lnkFattRiepilog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFattRiepilog.LinkClicked

        If _Voce.IdDocRif Then
            'riapro la fattura riepilogativa
            Dim numdoc As Integer = _Voce.IdDocRif

            Dim x As New frmContabilitaFatturaRiepilogativaRicavo
            Sottofondo()
            x.Carica(numdoc)
            Sottofondo()
            x = Nothing

        End If

    End Sub

    Private Sub DgDoc_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDoc.CellContentDoubleClick
        Dim IdORdSel As Integer = DgDoc.SelectedRows(0).Cells(1).Value

        Sottofondo()

        Dim X As New frmOrdine
        X.Carica(IdORdSel)
        X = Nothing

        Sottofondo()

    End Sub

    Private Sub btnStampaEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStampaEmail.Click

        If _Voce.Tipo = enTipoDocumento.Fattura Or
           _Voce.Tipo = enTipoDocumento.FatturaRiepilogativa Or
           _Voce.Tipo = enTipoDocumento.DDT Then

            If MessageBox.Show("Confermi la stampa del documento in PDF?", "Stampa documento contabile in PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                ProxyStampa.StampaDocumentoFiscalePDF(_Voce)

                FormerHelper.File.ShellExtended(FormerPath.PathFatture(_Voce.IdAzienda))

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
        Else
            MessageBox.Show("Si possono stampare in PDF solo le Fatture e le Fatture riepilogative")
        End If

    End Sub

    Private Sub btnRimuovi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRimuovi.Click
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If MessageBox.Show("Attenzione! Stai modificando un documento contabile, l'operazione non è reversibile. Confermi l'eliminazione dell'ordine dal documento?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                'devo controllare se la consegna e' modificabile

                _ModificatiOrdini = True

                If DgDoc.SelectedRows.Count And DgDoc.Rows.Count > 1 Then
                    Dim Dr As DataGridViewRow = DgDoc.SelectedRows(0)
                    If Dr.Selected Then
                        Dim IdOrd As Integer = 0
                        IdOrd = Dr.Cells(1).Value
                        Dim O As New Ordine
                        O.Read(IdOrd)

                        If O.ConsegnaAssociata.HaUnPagamentoAnticipato = False Then

                            Using mO As New OrdiniDAO

                                mO.InserisciLog(IdOrd, enStatoOrdine.UscitoMagazzino)

                            End Using

                            Using mo As New OrdiniDAO
                                mo.SganciaOrdineDaDoc(O.IdOrd)
                            End Using

                            Using VociFat As New cVociFatColl
                                VociFat.EliminaByIdOrd(IdOrd)
                            End Using

                            'sgancio l'ordine dal documento e dalla consegna
                            Dim IdConsVecchia As Integer = O.IdCons
                            Using mgr As New ConsegneProgrammateDAO

                                'TOLTO IL 08/04/2015
                                'mgr.EliminaOrdineDaConsegna(IdConsVecchia, IdOrd)

                                mgr.RegistraConsegnaOrdineSuGiorno(O.IdOrd, O.IdCorriere, O.DataEffConsegna, O.IdRub, enMomentoConsegna.Pomeriggio, O.IdIndirizzo, , False, True)

                                'TOLTO IL 08/04/2015
                                'mgr.EliminaConsegnaSeVuota(IdConsVecchia)

                            End Using

                            DgDoc.Rows.Remove(DgDoc.SelectedRows(0))

                            CaricaDettagliFat()

                            MessageBox.Show("Ordine eliminato correttamente dal documento contabile!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Dim c As New ConsegnaProgrammata
                            c.Read(IdConsVecchia)
                            _Voce.NumColli = c.NumColli
                            _Voce.Peso = c.Peso

                            'If MessageBox.Show("Vuoi ricalcolare in automatico il totale del documento?", Postazione.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            'End If
                            RicalcolaTotali()
                            SalvaDatiFattura()

                        Else
                            MessageBox.Show("L'ordine è inserito in una consegna con un pagamento anticipato!")
                        End If

                    End If
                Else
                    MessageBox.Show("Selezionare una voce! ", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile o è presente un pagamento")
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            Dim OkPagamento As Boolean = True

            Try
                Dim IdCons As Integer = _Voce.IdConsegnaRif

                If IdCons Then
                    Using c As New ConsegnaProgrammata
                        c.Read(IdCons)
                        If c.HaUnPagamentoAnticipato Then
                            OkPagamento = False
                        End If
                    End Using
                End If
            Catch ex As Exception

            End Try

            If OkPagamento Then
                If MessageBox.Show("Attenzione! Stai modificando un documento contabile. Vuoi continuare?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    _ModificatiOrdini = True

                    Sottofondo()

                    Dim x As New frmMagazzinoBarCodeRCTF, Ris As String = ""

                    Ris = x.Carica

                    Sottofondo()

                    If Ris.Length = 13 Then

                        'mi prendo le prime 9 cifre ed estraggo il codice del numero ordine
                        Dim CodiceOrd As Integer = Ris.Substring(0, 8)

                        'qui devo vedere se l'ordine e' gia in griglia, se gia ci sta lo aggiorno altrimenti lo aggiungo e aggiorno la quantita dei colli

                        InserisciOrdineDaCodice(CodiceOrd)

                    End If

                End If
            Else
                MessageBox.Show("Il documento fiscale non è modificabile perché è presente un pagamento anticipato")
            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile o è presente un pagamento")
        End If

    End Sub

    Private Sub dgVociFat_CellContentDoubleClick(sender As Object,
                                                 e As DataGridViewCellEventArgs) Handles dgVociFat.CellContentDoubleClick

        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If dgVociFat.SelectedRows.Count Then
                Dim NuovaDescrizione As String = ""
                Dim IdVoceFat As Integer = dgVociFat.SelectedRows(0).Cells(0).Value
                If IdVoceFat Then
                    Select Case e.ColumnIndex

                        Case 1 ' codice
                            Dim vf As New VoceFattura
                            vf.Read(IdVoceFat)
                            NuovaDescrizione = InputBox("Inserisci il nuovo codice della voce in fattura (non toccare niente per lasciarlo cosi)", "Voce in Fattura", vf.Codice)
                            If NuovaDescrizione.Length <> 0 AndAlso NuovaDescrizione <> vf.Codice Then
                                vf.Codice = NuovaDescrizione
                                vf.Save()
                                CaricaDettagliFat()
                            End If
                            vf = Nothing
                        Case 2 ' descrizione
                            Dim vf As New VoceFattura
                            vf.Read(IdVoceFat)
                            NuovaDescrizione = InputBox("Inserisci la nuova descrizione della voce in fattura (non toccare niente per lasciarla cosi)", "Voce in Fattura", vf.Descrizione)
                            If NuovaDescrizione.Length <> 0 AndAlso NuovaDescrizione <> vf.Descrizione Then
                                vf.Descrizione = NuovaDescrizione
                                vf.Custom = enSiNo.Si
                                vf.Save()
                                CaricaDettagliFat()
                            End If
                            vf = Nothing

                        Case 3 ' qta
                            Dim vf As New VoceFattura
                            vf.Read(IdVoceFat)
                            NuovaDescrizione = InputBox("Inserisci la nuova Quantita della voce in fattura (non toccare niente per lasciarla cosi)", "Voce in Fattura", vf.Qta)
                            If NuovaDescrizione.Length <> 0 AndAlso NuovaDescrizione <> vf.Qta.ToString And IsNumeric(NuovaDescrizione) Then
                                vf.Qta = NuovaDescrizione
                                vf.Save()
                                CaricaDettagliFat()
                            End If
                            vf = Nothing
                    End Select

                End If

            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile o è presente un pagamento")
        End If

    End Sub

    Private Function RiempiListaIdOrd() As String

        Dim x As DataGridViewRow
        Dim buffer As String = ""

        For Each x In DgDoc.Rows

            buffer &= x.Cells(1).Value & ","

        Next
        buffer = buffer.TrimEnd(",")
        Return buffer

    End Function

    Private Sub btnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOrder.Click
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            Dim OkPagamento As Boolean = True

            Try
                Dim IdCons As Integer = _Voce.IdConsegnaRif

                If IdCons Then
                    Using c As New ConsegnaProgrammata
                        c.Read(IdCons)
                        If c.HaUnPagamentoAnticipato Then
                            OkPagamento = False
                        End If
                    End Using
                End If
            Catch ex As Exception

            End Try

            If OkPagamento Then
                If MessageBox.Show("Attenzione! Stai modificando un documento contabile. Vuoi continuare?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    _ModificatiOrdini = True
                    Sottofondo()

                    Dim Ris As String = "", ListaIdOrd As String = ""

                    Using x As New frmMagazzinoCaricaColli

                        ListaIdOrd = RiempiListaIdOrd()
                        Dim IdCli As Integer = 0

                        IdCli = cmbCliente.SelectedValue

                        Ris = x.Carica(IdCli, ListaIdOrd)

                    End Using

                    Sottofondo()

                    'se ris e' pieno ho il codice in formato testo di ordine e numero collo caricato

                    If Ris.Length Then

                        'mi prendo le prime 9 cifre ed estraggo il codice del numero ordine

                        Dim IdOrdiniScelti As String() = Ris.Split(",")
                        Dim risIns As Boolean = False
                        For Each singOrd In IdOrdiniScelti
                            Dim CodiceOrd As Integer = singOrd

                            'qui devo vedere se l'ordine e' gia in griglia, se gia ci sta lo aggiorno altrimenti lo aggiungo e aggiorno la quantita dei colli
                            risIns = InserisciOrdineDaCodice(CodiceOrd, True, False)

                        Next

                        If risIns Then MessageBox.Show("Ordini inseriti correttamente nel documento contabile!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If
            Else

                MessageBox.Show("Il documento fiscale non è modificabile perchè è presente un pagamento anticipato")

            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile o è presente un pagamento")
        End If


    End Sub

    Private Function InserisciOrdineDaCodice(ByVal CodiceOrd As Integer,
                                        Optional ByVal ForzaColli As Boolean = False,
                                        Optional ShowMsg As Boolean = True) As Boolean
        Dim ris As Boolean = False

        Dim drEsist As DataGridViewRow
        Dim SwTrovato = False

        For Each drEsist In DgDoc.Rows

            If drEsist.Cells(1).Value = CodiceOrd Then
                SwTrovato = True
                Exit For
            End If

        Next

        If SwTrovato = False Then

            Dim ordine As New Ordine
            ordine.Read(CodiceOrd)

            If ordine.IdOrd Then
                If (ordine.Stato = enStatoOrdine.ProntoRitiro Or
                    ordine.Stato = enStatoOrdine.UscitoMagazzino Or
                    ordine.Stato = enStatoOrdine.InConsegna Or
                    ordine.Stato = enStatoOrdine.Consegnato Or
                    ordine.Stato = enStatoOrdine.PagatoAcconto Or
                    ordine.Stato = enStatoOrdine.PagatoInteramente) AndAlso ordine.DocumentoFiscale Is Nothing Then

                    Dim Rub As New VoceRubrica, NomeCli As String = ""

                    Rub.Read(ordine.IdRub)
                    NomeCli = Rub.RagSocNome

                    If cmbCliente.SelectedValue = Rub.IdRub Then

                        If (cmbTipo.SelectedValue = enTipoDocumento.Fattura And ordine.Preventivo = enSiNo.Si) Or (cmbTipo.SelectedValue = enTipoDocumento.Preventivo And ordine.Preventivo = enSiNo.No) Then
                            MessageBox.Show("Non si possono inserire ordini di tipo preventivo insieme a ordini normali!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            'qui lo posso effettivamente associare
                            'qui devo controllare la consegna
                            'If ordine.ConsegnaAssociata.Modificabile(False) Then
                            If ordine.ConsegnaAssociata.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then 'ordine.ConsegnaAssociata.ModificabileEx(True, False, True, True, False, False).Modificabile Then

                                Dim IdConsOther As Integer = 0
                                Dim ConsToAttach As ConsegnaProgrammata = Nothing
                                Dim ErrCons As Boolean = False
                                For Each dr As DataGridViewRow In DgDoc.Rows
                                    Dim IdOrd As Integer = dr.Cells(1).Value
                                    Dim o As New Ordine
                                    o.Read(IdOrd)
                                    If IdConsOther = 0 Then
                                        IdConsOther = o.ConsegnaAssociata.IdCons
                                    Else
                                        If IdConsOther <> o.ConsegnaAssociata.IdCons Then
                                            ErrCons = True
                                        End If
                                    End If
                                Next

                                If ErrCons = False Then
                                    If IdConsOther Then
                                        ConsToAttach = New ConsegnaProgrammata
                                        ConsToAttach.Read(IdConsOther)
                                    End If

                                    Dim ProxStato As enStatoOrdine = enStatoOrdine.Consegnato
                                    If cmbCorriere.SelectedValue <> 1 Then
                                        ProxStato = enStatoOrdine.InConsegna
                                    End If

                                    'avanzo l'ordine al prossimo stato
                                    Using ordinec As New OrdiniDAO
                                        ordinec.AvanzaOrdiniAStatoByIdOrd(ordine.IdOrd, ProxStato, False)
                                        'lo associo a questo documento
                                        ordinec.AssociaOrdiniADoc(ordine.IdOrd, _IdVoce)
                                    End Using

                                    'inserisco le voci in fattura per questo ordine
                                    Dim VoceFat As New VoceFattura
                                    Dim Prod As New Prodotto
                                    Prod.Read(ordine.IdProd)

                                    VoceFat.IdDoc = _IdVoce
                                    VoceFat.Codice = Prod.Codice

                                    Dim DescrOrdine As String = Prod.Descrizione ' lo inizializzo comunque alla descrizione del prodotto perche per qualche motivo il nome del lavoro potrebbe cmq saltare anceh se impostato
                                    If ordine.UsaNomeLavoroInFattura = enSiNo.Si Then
                                        If ordine.NomeLavoro.Length Then
                                            DescrOrdine = ordine.NomeLavoro
                                        End If
                                    End If
                                    VoceFat.Descrizione = DescrOrdine 'Prod.Descrizione
                                    VoceFat.ImportoSing = ordine.PrezzoProd / ordine.QtaOrdine  'Prod.NumPezzi ''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                                    VoceFat.Importo = ordine.TotaleImponibile
                                    VoceFat.Iva = ordine.Iva
                                    VoceFat.Qta = ordine.QtaOrdine  'Prod.NumPezzi * ordine.Qta ''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                                    VoceFat.IdOrd = ordine.IdOrd
                                    VoceFat.Save()

                                    Using mgr As New ConsegneProgrammateDAO
                                        Dim IdConsVecchia As Integer = ordine.ConsegnaAssociata.IdCons
                                        'TOLTO IL 08/04/2015
                                        'mgr.EliminaOrdineDaConsegna(IdConsVecchia, ordine.IdOrd)

                                        ConsToAttach = mgr.RegistraConsegnaOrdineSuGiorno(ordine.IdOrd, ordine.IdCorriere, ordine.DataEffConsegna, ordine.IdRub, enMomentoConsegna.Pomeriggio, ordine.IdIndirizzo, ConsToAttach)

                                        'TOLTO IL 08/04/2015
                                        'mgr.EliminaConsegnaSeVuota(IdConsVecchia)
                                    End Using

                                    If ShowMsg Then MessageBox.Show("Ordine " & CodiceOrd & " inserito correttamente nel documento contabile!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    ris = True
                                    CaricaVociFat()
                                    CaricaDettagliFat()

                                    _Voce.NumColli = ConsToAttach.NumColli
                                    _Voce.Peso = ConsToAttach.Peso

                                    'If MessageBox.Show("Vuoi ricalcolare in automatico il totale del documento?", Postazione.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                    'End If
                                    RicalcolaTotali()
                                    SalvaDatiFattura()

                                Else
                                    MessageBox.Show("Non è possibile aggiungere ordini a questo documento per incongruenze con le consegne")
                                End If
                            Else
                                MessageBox.Show("L'ordine " & CodiceOrd & " che si tenta di aggiungere è legato a una consegna non modificabile")
                            End If
                        End If
                    Else
                        MessageBox.Show("Non si possono inserire ordini di clienti diversi!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    Rub = Nothing
                Else
                    MessageBox.Show("Si possono inserire solo ordini in stato PRONTO PER LA CONSEGNA, USCITO DA MAGAZZINO, IN CONSEGNA, CONSEGNATO, PAGATO ACCONTO, PAGATO INTERAMENTE che non sono gia in un documento fiscale!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Codice inserito non valido!", "Consegna pacchi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            ordine = Nothing

        End If
        Return ris

    End Function

    Private Function GetTotaleNettoOrdini() As Decimal
        Dim ris As Decimal = 0

        For Each dr As DataGridViewRow In dgVociFat.Rows
            ris += dr.Cells(4).Value
        Next
        Return ris
    End Function

    Private Sub RicalcolaTotali()

        Dim Tot As Decimal = GetTotaleNettoOrdini()
        'Dim TotIva As Double = 0

        'Dim dr As DataGridViewRow

        'For Each dr In dgVociFat.Rows

        '    Tot += dr.Cells(4).Value
        '    ' TotIva += dr.Cells(5).Value

        'Next

        Dim CostoSped As Decimal = 0

        Try
            CostoSped = lblCostoSped.Text
        Catch ex As Exception

        End Try

        lblTotOrdini.Text = FormerHelper.Stringhe.FormattaPrezzo(Tot)

        txtImporto.Text = FormerHelper.Stringhe.FormattaPrezzo(Tot + CostoSped)

        'txtIva.Text = FormattaPrezzo(TotIva)
        CalcolaIva()

        CalcolaTot()

    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
        '_Voce.IdRub = cmbCliente.SelectedValue
        ' lblIntestazione.Text = _Voce.intestazione

    End Sub

    Private Sub pctSblocco_Click(sender As System.Object, e As System.EventArgs) Handles pctSblocco.Click

        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            BloccaFattura(True)
            tbDett.Enabled = False
            flowPanelPulsanti.Enabled = False
            btnConferma.Visible = True
            lblIntestazione.Enabled = False
        Else
            MessageBox.Show("Impossibile modificare una fattura in stato FE 'In coda per invio' o successivo, oppure con un pagamento")
        End If

    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        If Not _Voce Is Nothing Then
            _Voce.Tipo = cmbTipo.SelectedValue
            If _Voce.Tipo = enTipoDocumento.Preventivo Then
                txtPercIva.Text = 0
                txtIva.Text = 0
            Else
                txtPercIva.Text = FormerHelper.Finanziarie.GetPercentualeIva
                CalcolaIva()
            End If
            CalcolaTot()
        Else
            If cmbTipo.SelectedValue = enTipoDocumento.DDT Then
                pnlImporti.Visible = False
            Else
                pnlImporti.Visible = True
            End If
        End If
    End Sub

    Private Sub btnAnnulla_Click(sender As Object, e As EventArgs) Handles btnAnnulla.Click

        Close()

    End Sub

    Private Sub btnRiapriPdf_Click(sender As Object, e As EventArgs) Handles btnRiapriPdf.LinkClicked

        If _Voce.Tipo = enTipoDocumento.Fattura Or _Voce.Tipo = enTipoDocumento.FatturaRiepilogativa Then
            Dim PathPDF As String = FormerPath.PathFatture(_Voce.IdAzienda) & _Voce.AnnoRiferimento & "-"
            Dim Numero As Integer = _Voce.Numero
            PathPDF &= Numero.ToString("0000") & ".pdf"

            If System.IO.File.Exists(PathPDF) Then
                FormerHelper.File.ShellExtended(PathPDF)
            Else
                MessageBox.Show("La fattura non è stata ancora generata!", "Fattura non presente", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            MessageBox.Show("La versione PDF è disponibile solo per le fatture")
        End If


    End Sub

    Private Sub lnkPrintBarcode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrintBarcode.LinkClicked

        If _Voce.IdRicavo Then
            If MessageBox.Show("Confermi la stampa del barcode della fattura?", "Stampa Barcode Fattura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim P As New myPrinter
                Dim PrinterName As String = PostazioneCorrente.StampanteConsegnaOrdini

                'TEMPORANEO PER SCEGLIERE PDFCREATOR
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

    Private Sub lnkApriCons_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkApriCons.LinkClicked

        Dim IdCons As Integer = _Voce.IdConsegnaRif

        If IdCons Then
            Using f As New frmConsegnaProgrammata
                Sottofondo()
                f.Carica(IdCons)
                Sottofondo()
            End Using
        Else
            MessageBox.Show("Non è presente la consegna collegata a questo documento")
        End If

    End Sub

    Private Sub lnkRegPagamento_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRegPagamento.LinkClicked

        'If _TipoVoce = enTipoVoceContab.VoceAcquisto Then
        '    If _Voce.idcosto Then

        '        Dim Differenza As Decimal = 0
        '        Using mgr As New PagamentiDAO
        '            Differenza = mgr.ImportoAncoraDaPagareDocumento(_Voce.idcosto, _TipoVoce)
        '        End Using

        '        If Differenza Then
        '            Sottofondo()

        '            Using frmP As New frmPagam
        '                frmP.Carica(, , _Voce.idcosto, _TipoVoce)
        '            End Using

        '            'Using frmC As New frmDocumentoContabile
        '            '    frmC.Carica(CodiceRif, enTipoVoceContab.enTipoVoceVendita)
        '            'End Using

        '            Sottofondo()
        '        Else
        '            MessageBox.Show("Il documento risultà gia pagato")
        '        End If

        '    Else
        '        Beep()

        '    End If
        'Else
        If _Voce.IdRicavo Then

            Dim Differenza As Decimal = 0
            Using mgr As New PagamentiDAO
                Differenza = mgr.ImportoAncoraDaPagareDocumento(_Voce.IdRicavo, _TipoVoce)
            End Using

            If Differenza Then
                Sottofondo()

                Using frmP As New frmContabilitaPagamento
                    frmP.Carica(, , _Voce.IdRicavo, _TipoVoce)
                End Using

                'Using frmC As New frmDocumentoContabile
                '    frmC.Carica(CodiceRif, enTipoVoceContab.enTipoVoceVendita)
                'End Using

                Sottofondo()
            Else
                MessageBox.Show("Il documento risultà gia pagato")
            End If

        Else
            Beep()

        End If
        ' End If

    End Sub

    Private Sub ModificaImportiOrdine()

        If MessageBox.Show("Attenzione! Stai modificando un documento contabile. Vuoi modificare gli importi dell'ordine?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _ModificatiOrdini = True

            'dopo aver attivato la maschera modifica importi devo andare a modifricare le righe in dettaglio voci fattura
            'ricalcolare il totale del documento e salvare 

            If DgDoc.SelectedRows.Count Then
                Dim Dr As DataGridViewRow = DgDoc.SelectedRows(0)
                If Dr.Selected Then
                    Dim IdOrd As Integer = 0
                    IdOrd = Dr.Cells(1).Value
                    Dim O As New Ordine
                    O.Read(IdOrd)

                    If O.ConsegnaAssociata.HaUnPagamentoAnticipato = False Then
                        Dim frmMod As New frmOrdineModificaImporti
                        Dim Ris As Integer = 0

                        Sottofondo()

                        Ris = frmMod.Carica(IdOrd, True)

                        Sottofondo()
                        frmMod = Nothing

                        If Ris Then
                            'qui devo ricaricare l'ordine e modificare la riga in fattura
                            O.Dispose()
                            O = New Ordine
                            O.Read(IdOrd)

                            Using mgr As New VociFatturaDAO
                                Dim l As List(Of VoceFattura) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceFattura.IdOrd, IdOrd),
                                                                            New LUNA.LunaSearchParameter(LFM.VoceFattura.IdDoc, _IdVoce))

                                'qui devo per forza trovare una sola voce 

                                If l.Count = 1 Then
                                    Using v As VoceFattura = l(0)
                                        v.ImportoSing = O.TotaleImponibile / O.QtaOrdine ' O.Prodotto.NumPezzi''MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                                        v.Importo = O.TotaleImponibile
                                        v.Save()
                                    End Using
                                Else
                                    MessageBox.Show("Il Numero di voci fattura per questo ordine e' errato")
                                End If

                            End Using
                            CaricaVociFat()
                            CaricaDettagliFat()
                            RicalcolaTotali()
                            SalvaDatiFattura()
                        End If

                    Else
                        MessageBox.Show("L'ordine non può essere modificato perchè associato a una consegna con un pagamento", "Modifica ordine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("Selezionare un ordine!")
                End If
            Else
                MessageBox.Show("Selezionare un ordine!")
            End If

        End If

    End Sub

    Private Sub btnModificaImp_Click(sender As Object, e As EventArgs) Handles btnModificaImp.Click
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            ModificaImportiOrdine()
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile")
        End If


    End Sub

    Private Sub ModificaImportiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaImportiToolStripMenuItem.Click
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            ModificaImportiOrdine()
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile")
        End If


    End Sub

    Private Sub UsaNomeLavoroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsaNomeLavoroToolStripMenuItem.Click
        UsaNomeLavoroOrdine()
    End Sub

    Private Sub UsaNomeLavoroOrdine()
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If MessageBox.Show("Attenzione! Stai modificando un documento contabile. Vuoi utilizzare il nome del lavoro per la riga in fattura?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                _ModificatiOrdini = True

                'dopo aver attivato la maschera modifica importi devo andare a modifricare le righe in dettaglio voci fattura
                'ricalcolare il totale del documento e salvare 

                If DgDoc.SelectedRows.Count Then
                    Dim Dr As DataGridViewRow = DgDoc.SelectedRows(0)
                    If Dr.Selected Then
                        Dim IdOrd As Integer = 0
                        IdOrd = Dr.Cells(1).Value
                        Dim O As New Ordine
                        O.Read(IdOrd)

                        If O.NomeLavoro.Length Then
                            Using mgr As New VociFatturaDAO
                                Dim l As List(Of VoceFattura) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.VoceFattura.IdOrd, IdOrd),
                                                                            New LUNA.LunaSearchParameter(LFM.VoceFattura.IdDoc, _IdVoce))

                                'qui devo per forza trovare una sola voce 

                                If l.Count = 1 Then
                                    Using v As VoceFattura = l(0)
                                        v.Descrizione = O.NomeLavoro
                                        v.Save()
                                    End Using
                                    MessageBox.Show("Modifica effettuata!")
                                    CaricaDettagliFat()
                                Else
                                    MessageBox.Show("Il Numero di voci fattura per questo ordine e' errato")
                                End If

                            End Using

                        Else
                            MessageBox.Show("L'ordine selezionato non ha un nome lavoro impostato")
                        End If

                    Else
                        MessageBox.Show("Selezionare un ordine!")
                    End If
                Else
                    MessageBox.Show("Selezionare un ordine!")
                End If
            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile")
        End If


    End Sub

    Private Sub DgDoc_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgDoc.CellMouseClick
        If DgDoc.SelectedRows.Count Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                mnuOrdini.Show(MousePosition)

            End If
        End If
    End Sub

    Private Sub lblCostoSped_TextChanged(sender As Object, e As EventArgs) Handles lblCostoSped.TextChanged

        RicalcolaTotali()

    End Sub

    Private Sub lnkNoIva_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNoIva.LinkClicked
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If MessageBox.Show("Vuoi trasformare questa fattura con IVA a 0?", "Fattura No IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                _Voce.Iva = 0
                _Voce.PercIva = 0
                _Voce.Totale = _Voce.Importo
                '_Voce.Save()

                txtPercIva.Text = 0
                cmbEsclIvaNat.Enabled = True

                'ProxyStampa.StampaDocumentoFiscalePDF(_Voce)

            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile")
        End If


    End Sub

    Private Sub btnStampaEmail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnStampaEmail.LinkClicked

    End Sub

    Private Sub btnStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnStampa.LinkClicked

    End Sub

    Private Sub pctIntRefresh_Click(sender As Object, e As EventArgs) Handles pctIntRefresh.Click

        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If MessageBox.Show("Vuoi ricaricare i dati anagrafici del destinatario dalla rubrica e aggiornarli nel documento fiscale?", "Dati Fattura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Using r As New VoceRubrica
                    r.Read(_Voce.IdRub)

                    Dim Messaggio As String = "Vuoi applicare questi dati anagrafici al documento? " & ControlChars.NewLine & ControlChars.NewLine

                    Messaggio &= r.RagSocNome & ControlChars.NewLine
                    Messaggio &= r.Indirizzo & " " & r.Citta & "(" & r.CAP & ")" & ControlChars.NewLine
                    Messaggio &= "P.iva " & r.PivaEx

                    If MessageBox.Show(Messaggio, "Dati Fattura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        _Voce.pRagSoc = r.RagSocNome
                        _Voce.pIndirizzo = r.Indirizzo
                        _Voce.pCitta = r.Citta
                        _Voce.pCap = r.CAP
                        _Voce.pIva = r.PivaEx
                        SalvaDatiFattura()
                        lblIntestazione.Text = r.Intestazione

                        MessageBox.Show("Modifica effettuata!")
                    End If

                End Using

            End If
        Else
            MessageBox.Show("Impossibile modificare una fattura in stato FE 'In coda per invio' o successivo")
        End If


    End Sub

    Private Sub pctIntEdit_Click(sender As Object, e As EventArgs) Handles pctIntEdit.Click
        If _TipoVoce = enTipoVoceContab.VoceVendita Then

            MessageBox.Show("Funzione disattivata")
            Exit Sub

            'Dim Ris As Integer = 0
            'Sottofondo()
            'Using f As New frmContabilitaEditIntestazioneDocumento
            '    Ris = f.Carica(_Voce)
            'End Using
            'Sottofondo()

            'If Ris Then
            '    Dim Intestazione As String = MgrDocumentiFiscali.GetIntestazione(_Voce)
            '    lblIntestazione.Text = Intestazione
            '    btnConferma.Visible = True
            'End If
        Else
            Beep()
        End If

    End Sub

    Private Sub dgVociFat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgVociFat.CellContentClick

    End Sub

    Private Sub lnkIva4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkIva4.LinkClicked
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If MessageBox.Show("Vuoi trasformare questa fattura con IVA al 4%?", "Fattura IVA 4%", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                txtPercIva.Text = 4

                Dim ToTIva As Decimal = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(((CDec(txtImporto.Text) / 100) * txtPercIva.Text), 2)

                _Voce.PercIva = txtPercIva.Text
                _Voce.Iva = ToTIva
                _Voce.Totale = _Voce.Importo + ToTIva
                '_Voce.Save()

                'ProxyStampa.StampaDocumentoFiscalePDF(_Voce)

            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile")
        End If

    End Sub

    Private Sub lnkSetIncassoNormale_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSetIncassoNormale.LinkClicked

        Dim Ris As Integer = MgrDocumentiFiscali.SetStatoIncasso(_IdVoce, enStatoIncasso.Normale)
        If Ris Then
            lblStatoIncasso.Text = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Normale)
            lblStatoIncasso.BackColor = FormerColori.GetColoreStatoIncasso(enStatoIncasso.Normale)
        End If

    End Sub

    Private Sub lnkSetIncassoProblematico_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSetIncassoProblematico.LinkClicked
        Dim Ris As Integer = MgrDocumentiFiscali.SetStatoIncasso(_IdVoce, enStatoIncasso.Problematico)
        If Ris Then
            lblStatoIncasso.Text = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Problematico)
            lblStatoIncasso.BackColor = FormerColori.GetColoreStatoIncasso(enStatoIncasso.Problematico)
        End If
    End Sub

    Private Sub lnkSetIncassoDifficile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSetIncassoDifficile.LinkClicked
        Dim Ris As Integer = MgrDocumentiFiscali.SetStatoIncasso(_IdVoce, enStatoIncasso.Difficile)
        If Ris Then
            lblStatoIncasso.Text = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Difficile)
            lblStatoIncasso.BackColor = FormerColori.GetColoreStatoIncasso(enStatoIncasso.Difficile)
        End If
    End Sub

    Private Sub lnkSetIncassoImpossibile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSetIncassoImpossibile.LinkClicked
        Dim Ris As Integer = MgrDocumentiFiscali.SetStatoIncasso(_IdVoce, enStatoIncasso.Impossibile)
        If Ris Then
            lblStatoIncasso.Text = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Impossibile)
            lblStatoIncasso.BackColor = FormerColori.GetColoreStatoIncasso(enStatoIncasso.Impossibile)
        End If
    End Sub

    Private Sub btnRiapriPdf_Click(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnRiapriPdf.LinkClicked

    End Sub

    Private Sub lnkNotaCredito_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNotaCredito.LinkClicked

        If Not _Voce.NotaDiCreditoRelativa Is Nothing Then
            Sottofondo()
            Using f As New frmContabilitaNotaCredito
                f.Carica(_Voce.NotaDiCreditoRelativa.IdRicavo)
            End Using
            Sottofondo()
        End If

    End Sub

    Private Sub lblIntestazione_Click(sender As Object, e As EventArgs) Handles lblIntestazione.Click

    End Sub

End Class