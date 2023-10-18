Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports System.Data.SqlClient
Imports FormerPrinter
Imports FormerConfig
Imports FormerBusinessLogic

Public Class frmContabilitaNotaCredito
    'Inherits baseFormInternaRedim

    Private _Voce As Ricavo = Nothing
    Private _IdRub As Integer
    Private _ris As Integer = 0
    Private _IdVoce As Integer = 0
    'Private _TipoVoce As Integer = 0
    'Private _TipoDocDefault As enTipoDocumento
    'Private _Da As SqlDataAdapter
    'Private _Ds As DataSet
    'Private _bs As New BindingSource
    Private _ModificatiOrdini As Boolean = False
    'Private _IdRicavoRiferimento As Integer = 0

    Private _RicavoRiferimento As Ricavo = Nothing

    Friend Function Carica(Optional ByVal IdVoce As Integer = 0,
                           Optional IdRicavoRiferimento As Integer = 0) As Integer
        _IdVoce = IdVoce
        Dim _IdRicavoRiferimento As Integer = IdRicavoRiferimento

        '_TipoVoce = enTipoVoceContab.VoceVendita
        'Dim X As New cTipoVoceContab

        'cmbTipoVoce.DataSource = X
        'cmbTipoVoce.ValueMember = "Id"
        'cmbTipoVoce.DisplayMember = "Descrizione"

        CaricaCombo()

        'tbDett.TabPages.Remove(tbVociFat)
        'tbDett.TabPages.Remove(tpPagam)
        ''tbDett.TabPages.Remove(tpRisorse)
        ''tbDett.TabPages.Remove(tbImmagini)
        'tbDett.TabPages.Remove(tpVociFat)
        'tbDett.TabPages.Remove(tpStatoIncasso)

        If IdVoce Then

            lnkEliminaRiga.Visible = False
            Dim Ricavo As New Ricavo
            Ricavo.Read(IdVoce)
            _IdRicavoRiferimento = Ricavo.IdFatturaNotaDiCredito
            _RicavoRiferimento = New Ricavo
            _RicavoRiferimento.Read(_IdRicavoRiferimento)
            _Voce = Ricavo
            lblAzienda.Text = MgrAziende.GetAziendaStr(_Voce.IdAzienda)

            'If _Voce.piva.length <> 0 Then

            'qui è stata creata dal programma
            'tbDett.TabPages.Add(tbVociFat)
            'tbDett.TabPages.Add(tpPagam)
            'tbDett.TabPages.Add(tbImmagini)
            'tbDett.TabPages.Add(tpVociFat)
            'tbDett.TabPages.Add(tpStatoIncasso)

            'CaricaVociFat()

            CaricaDettagliFat()

            txtCostoSped.Text = _Voce.CostoCorr
            'lblTotOrdini.Text = FormerHelper.Stringhe.FormattaPrezzo(GetTotaleNettoOrdini())

            btnStampa.Visible = True

            'End If
            lblTotDettaglio.ReadOnly = True
            lblIva.ReadOnly = True


            'lblStatoIncasso.Text = FormerEnumHelper.GetStatoIncassoStr(Ricavo.StatoIncasso)
            'lblStatoIncasso.BackColor = FormerColori.GetColoreStatoIncasso(Ricavo.StatoIncasso)

            'End If

            'MostraControlli()

            'MgrControl.SelectIndexCombo(cmbCat, _Voce.IdCat)
            'MgrControl.SelectIndexCombo(cmbTipoVoce, _TipoVoce)
            MgrControl.SelectIndexCombo(cmbCliente, _Voce.IdRub)
            'MgrControl.SelectIndexCombo(cmbTipo, _Voce.Tipo)

            'cmbTipoVoce.Enabled = False

            txtDescrizione.Text = _Voce.Descrizione
            dataOp.Value = _Voce.DataRif
            lblTotDettaglio.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(GetTotaleNettoRighe, 2) '_Voce.Importo, 2)
            lblIva.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Voce.Iva, 2)
            txtNumero.Text = _Voce.Numero
            txtPercIva.Text = _Voce.PercIva
            'If _Voce.NaturaEsclIva.Length Then
            '    MgrControl.SelectIndexComboValore(cmbEsclIvaNat, _Voce.NaturaEsclIva)
            'End If

            'txtFile.Text = _Voce.Scansione
            'txtFile1.Text = _Voce.Scansione1
            'txtFile2.Text = _Voce.Scansione2
            'txtFile3.Text = _Voce.Scansione3
            'txtFile4.Text = _Voce.Scansione4
            CalcolaTot()


            Dim Intestazione As String = MgrDocumentiFiscali.GetIntestazione(_Voce)

            lblIntestazione.Text = Intestazione
            'Try
            'txtDataPrevPagam.Value = _Voce.Dataprevpagam
            'Catch ex As Exception
            'txtDataPrevPagam.Value = _Voce.datacosto
            'End Try

            'carico i pagamenti

            'UcPagamenti.IdDocRif = IdVoce
            'UcPagamenti.MostraDati(_TipoVoce)

            'txtDataPrevPagam.Enabled = False

            If _Voce.Tipo = enTipoDocumento.Preventivo OrElse _Voce.Tipo = enTipoDocumento.DDT Then
                TabRicavo.TabPages.Remove(tpFatturaXML)

            Else
                UcDocumentiFiscaliXMLRicavo.Carica(_Voce)
            End If
            Me.Text &= " - " & IdVoce
        Else

            _RicavoRiferimento = New Ricavo
            _RicavoRiferimento.Read(IdRicavoRiferimento)
            lblAzienda.Text = MgrAziende.GetAziendaStr(_RicavoRiferimento.IdAzienda)
            MgrControl.SelectIndexCombo(cmbCliente, _RicavoRiferimento.IdRub)

            txtDescrizione.Text = ""
            dataOp.Value = Now

            txtNumero.Text = "-"

            'If FRif.NaturaEsclIva.Length Then
            '    MgrControl.SelectIndexComboValore(cmbEsclIvaNat, FRif.NaturaEsclIva)
            'End If
            'txtIva.Text = FRif.Iva

            txtPercIva.Text = _RicavoRiferimento.PercIva
            txtCostoSped.Text = _RicavoRiferimento.CostoCorr
            'txtFile.Text = _Voce.Scansione
            'txtFile1.Text = _Voce.Scansione1
            'txtFile2.Text = _Voce.Scansione2
            'txtFile3.Text = _Voce.Scansione3
            'txtFile4.Text = _Voce.Scansione4
            CaricaDettagliFat()

            RicalcolaTotali()

            CalcolaTot()

            Dim Intestazione As String = MgrDocumentiFiscali.GetIntestazione(_RicavoRiferimento)

            lblIntestazione.Text = Intestazione
            'Try
            'txtDataPrevPagam.Value = _Voce.Dataprevpagam
            'Catch ex As Exception
            'txtDataPrevPagam.Value = _Voce.datacosto
            'End Try

            'carico i pagamenti

            'UcPagamenti.IdDocRif = IdVoce
            'UcPagamenti.MostraDati(_TipoVoce)

            'txtDataPrevPagam.Enabled = False

            TabRicavo.TabPages.Remove(tpFatturaXML)



            'MgrControl.SelectIndexComboEnum(cmbTipo, TipoDocDefault)

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

            'End If
            'btnStampaEmail.Visible = False
            'txtDataPrevPagam.Value = Now.Date
            'cmbTipoVoce.SelectedIndex = 0
            'cmbTipoVoce.Enabled = False
            btnStampa.Visible = False
            'btnRiapriPdf.Visible = False
            btnOk.Visible = True


        End If

        btnConferma.Visible = True

        txtDocRiferimento.Text = _RicavoRiferimento.Riassunto

        CaricaDettagliFatRif()

        ShowDialog()

        Return _ris

    End Function

    Private Sub CaricaDettagliFatRif()

        'carica le voci in fattura 
        Dim _DaRif As SqlDataAdapter
        Dim _DsRif As DataSet
        Dim _bsRif As New BindingSource

        Using VociFat As New cVociFatColl
            _DsRif = VociFat.ListaVociFat(_RicavoRiferimento.IdRicavo, _DaRif)
        End Using
        'Dim bs As New BindingSource
        'bs = New BindingSource()
        'bs.DataSource = Ds
        'bs.DataMember = "DettFatt"

        _bsRif.DataSource = _DsRif
        _bsRif.DataMember = "DettFatt"
        dgRigheOrig.DataSource = _bsRif
        dgRigheOrig.Columns(0).Visible = False

    End Sub

    Private Sub CaricaDettagliFat()

        'carica le voci in fattura 


        Dim l As New List(Of VoceFattura)
        If _IdVoce Then
            l.AddRange(_Voce.ListaRigheFat)
        Else
            'Using r As New Ricavo
            '    r.Read(_IdRicavoRiferimento)
            For Each singRiga In _RicavoRiferimento.ListaRigheFat
                Dim newRiga As VoceFattura = singRiga.Clone
                newRiga.IdVoceFat = 0
                newRiga.IdDoc = 0
                newRiga.IdRigaOriginale = singRiga.IdVoceFat
                l.Add(newRiga)
            Next

            'End Using

        End If


        'Using VociFat As New cVociFatColl
        '    _Ds = VociFat.ListaVociFat(IdToLoad, _Da)
        'End Using
        'Dim bs As New BindingSource
        'bs = New BindingSource()
        'bs.DataSource = Ds
        'bs.DataMember = "DettFatt"














        '_bs.DataSource = _Ds
        '_bs.DataMember = "DettFatt"

        dgVociFat.DataSource = l
        'DgVociFatEx.AutoGenerateColumns = True
        'DgVociFatEx.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        'DgVociFatEx.DataSource = l

        'DgVociFatEx.Columns(0).IsVisible = False
        'DgVociFatEx.Columns(2).IsVisible = False
        'DgVociFatEx.Columns(4).IsVisible = False
        'DgVociFatEx.Columns(5).IsVisible = False
        'DgVociFatEx.Columns(6).IsVisible = False
        'DgVociFatEx.Columns(8).IsVisible = False
        'DgVociFatEx.Columns(9).IsVisible = False
        'DgVociFatEx.Columns(11).IsVisible = False


        dgVociFat.Columns(0).Visible = False
        dgVociFat.Columns(2).Visible = False
        dgVociFat.Columns(4).Visible = False
        dgVociFat.Columns(5).Visible = False
        dgVociFat.Columns(6).Visible = False
        dgVociFat.Columns(8).Visible = False
        dgVociFat.Columns(9).Visible = False
        dgVociFat.Columns(11).Visible = False

        If _IdVoce = 0 Then

            For i = 0 To dgVociFat.Rows.Count - 1


                'dgVociFat.Rows(i).DefaultCellStyle.Font = New Drawing.Font(dgVociFat.Rows(i).DefaultCellStyle.Font, FontStyle.Strikeout)
                dgVociFat.Rows(i).DefaultCellStyle.BackColor = Color.Green


            Next
            'dgVociFat.Refresh()
        End If

    End Sub

    Private Sub CaricaCombo()

        CaricaCli()

        'Dim esclIva As New DictionaryEntry
        'Dim lesclIva As New List(Of DictionaryEntry)

        'esclIva = New DictionaryEntry("", "-")
        'lesclIva.Add(esclIva)

        'esclIva = New DictionaryEntry("N1", "escluse ex art. 15")
        'lesclIva.Add(esclIva)

        'esclIva = New DictionaryEntry("N2", "non soggette")
        'lesclIva.Add(esclIva)

        'esclIva = New DictionaryEntry("N3", "non imponibili")
        'lesclIva.Add(esclIva)

        'esclIva = New DictionaryEntry("N4", "esenti")
        'lesclIva.Add(esclIva)

        'esclIva = New DictionaryEntry("N5", "regime del margine / IVA non esposta in fattura")
        'lesclIva.Add(esclIva)

        'esclIva = New DictionaryEntry("N6", "inversione contabile")
        'lesclIva.Add(esclIva)

        'esclIva = New DictionaryEntry("N7", "IVA assolta in altro stato UE")
        'lesclIva.Add(esclIva)

        'cmbEsclIvaNat.ValueMember = "key"
        'cmbEsclIvaNat.DisplayMember = "value"
        'cmbEsclIvaNat.DataSource = lesclIva

    End Sub

    Private Function SalvaDatiFattura() As Integer
        Dim Ris As Integer = 0

        'Using Rif As New Ricavo
        '    Rif.Read(_IdRicavoRiferimento)
        If _Voce Is Nothing Then

            _Voce = New Ricavo
            'End If
        End If


        'salvo i dati
        _Voce.Tipo = enTipoDocumento.NotaDiCredito
        _Voce.IdAzienda = _RicavoRiferimento.IdAzienda

        _Voce.Descrizione = txtDescrizione.Text
        _Voce.DataRif = dataOp.Value
        'qui copio i file delle fatture nella dir fatture


        _Voce.IdRub = cmbCliente.SelectedValue
        Dim Cliente As New VoceRubrica
        Cliente.Read(_Voce.IdRub)
        _Voce.pRagSoc = Cliente.RagSoc
        _Voce.pIndirizzo = Cliente.Indirizzo
        _Voce.pCitta = Cliente.Citta
        _Voce.pCap = Cliente.CAP
        _Voce.pIva = Cliente.PivaEx
        _Voce.IdFatturaNotaDiCredito = _RicavoRiferimento.IdRicavo
        _Voce.CostoCorr = txtCostoSped.Text
        _Voce.Importo = CDec(lblImportoNetto.Text)
        '_Voce.iva = txtIva.Text
        _Voce.PercIva = CInt(txtPercIva.Text)
        _Voce.Dataprevpagam = _RicavoRiferimento.Dataprevpagam

        _Voce.NaturaEsclIva = _RicavoRiferimento.NaturaEsclIva

        If _Voce.PercIva Then
            _Voce.Iva = FormerHelper.Finanziarie.CalcolaIva(_Voce.Importo, _Voce.PercIva) '(_Voce.Importo + _Voce.CostoCorr) * _Voce.PercIva / 100
        Else
            _Voce.Iva = 0
        End If
        _Voce.Totale = (_Voce.Importo) + _Voce.Iva
            _ris = 1

        'QUI CONTROLLARE UNIVOCITA NUMERO
        'A PARITA DI NUMERO PER LO STESSO TIPO DI DOCUMENTO E QUESTO ANNO IN CUI E' EMESSO IL DOCUMENTO
        Dim InserisciPagamento As Boolean = False

        If _IdVoce = 0 Then
            _Voce.StatoFE = enStatoFatturaFE.InCodaInvio
            InserisciPagamento = True
            _Voce.Numero = MgrDocumentiFiscali.DocumentNumber.GetNextNumber(_Voce.IdAzienda, enTipoDocumento.NotaDiCredito) 'txtNumero.Text
            'End If
        Else
            If txtNumero.Text.Length Then _Voce.Numero = txtNumero.Text
        End If

        Ris = _Voce.Save()
        'End Using

        If InserisciPagamento Then
            'inserisco un pagamento automatico sul documento fiscale di partenza
            Using p As New Pagamento
                p.IdFat = _Voce.RicavoRiferimentoNotadiCredito.IdRicavo
                p.Tipo = enTipoVoceContab.VoceVendita
                p.IdTipoPagamento = enMetodoPagamento.StornoDaNotaDiCredito
                p.Importo = _Voce.Totale
                p.DataPag = _Voce.DataRicavo
                p.IdRub = _Voce.IdRub
                p.Descrizione = "Storno da Nota di Credito"
                p.Save()
                MgrDocumentiFiscali.AggiornaStatoRicavoDopoPagamento(p.IdFat) ', True)
            End Using

        End If

        Return Ris
    End Function

    Private Sub btnConferma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConferma.Click

        'If txtDescrizione.Text.Length = 0 Then
        '    MessageBox.Show("Inserire una descrizione!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If lblTotDettaglio.Text.Length = 0 Then
                MessageBox.Show("Inserire un importo!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If txtPercIva.Text.Length = 0 Then
                MessageBox.Show("Inserire una percentuale iva!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            If lblIva.Text.Length = 0 Then
                MessageBox.Show("Inserire l'iva!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'If txtPercIva.Text = 0 Then
            '    If cmbEsclIvaNat.SelectedItem Is Nothing OrElse cmbEsclIvaNat.SelectedValue = String.Empty Then
            '        MessageBox.Show("Selezionare una causale esclusione IVA!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    End If
            'End If

            If dgVociFat.Rows.Count = 0 Then
                MessageBox.Show("Deve essere presente almeno una riga nella nota di credito", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If MessageBox.Show("Confermi il salvataggio dei dati?", "Contabilità", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim IdVoceInserita As Integer = 0


                Using F As New RicaviDAO
                    Dim FattTrovata As Ricavo = Nothing

                    'If cmbTipoVoce.SelectedValue = enTipoVoceContab.VoceVendita Then

                    Dim Tipo As String = String.Empty
                    Dim TipoDoc As Integer = enTipoDocumento.NotaDiCredito

                    Tipo = "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.NotaDiCredito & ")"

                    Dim IdRicavoRif As Integer = 0

                    If Not _Voce Is Nothing Then
                        IdRicavoRif = _Voce.IdRicavo
                    End If

                    Dim AnnoRiferimento As Integer = Year(dataOp.Value)
                    FattTrovata = F.Find(New LUNA.LunaSearchParameter(LFM.Ricavo.Numero, txtNumero.Text),
                                                New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, Tipo, "IN"),
                                                New LUNA.LunaSearchParameter("year(DataRicavo)", AnnoRiferimento),
                                                New LUNA.LunaSearchParameter(LFM.Ricavo.IdRicavo, IdRicavoRif, "<>"),
                                                New LUNA.LunaSearchParameter(LFM.Ricavo.IdAzienda, _RicavoRiferimento.IdAzienda))
                    'End If

                    If Not FattTrovata Is Nothing Then
                        MessageBox.Show("Il numero di questo documento fiscale esiste già!", "Numero documento fiscale già presente", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        Dim OkSalvataggio As Boolean = True
                        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

                            Try
                                tb.TransactionBegin()

                                IdVoceInserita = SalvaDatiFattura()

                                For Each Riga As DataGridViewRow In dgVociFat.Rows
                                    If Riga.DefaultCellStyle.Font.Strikeout = False Then
                                        Dim Voce As VoceFattura = Riga.DataBoundItem

                                        Voce.IdDoc = IdVoceInserita
                                        Voce.Save()
                                    End If
                                Next

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
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile!", "Contabilità", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If


    End Sub

    Private Sub txtImporto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercIva.TextChanged, lblTotDettaglio.TextChanged
        'calcolo l'iva
        CalcolaTot()
        'CalcolaIva()

    End Sub

    Private Sub CalcolaTot()
        Try
            Dim Tot As Decimal = CDec(lblTotDettaglio.Text) + CDec(txtCostoSped.Text)
            lblImportoNetto.Text = Tot

            Dim Iva As Decimal = 0

            If Not _RicavoRiferimento Is Nothing AndAlso _RicavoRiferimento.PercIva <> 0 Then
                Iva = FormerHelper.Finanziarie.CalcolaIva(Tot, txtPercIva.Text)
            End If

            lblIva.Text = Iva

            Dim Ris As Decimal = Tot + Iva
            lblTotale.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Ris)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CalcolaIva()
        Dim ImportoIva As Decimal = 0
        Try
            'If _Voce.Tipo <> enTipoDocumento.Preventivo Then
            If CDec(lblTotDettaglio.Text) <> 0 Then
                If txtPercIva.Text <> 0 Then
                    ImportoIva = FormerHelper.Finanziarie.CalcolaIva(CDec(lblTotDettaglio.Text) + CDec(txtCostoSped.Text), txtPercIva.Text)
                End If
            End If
            'End If

        Catch ex As Exception

        End Try
        lblIva.Text = ImportoIva
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

            cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, False)
        End Using
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


                'qui chiedere se si vuole stampare la situazione contabile del cliente 
                'If _TipoVoce = enTipoVoceContab.VoceVendita Then
                'Using Rub As New VoceRubrica
                '        Rub.Read(_Voce.IdRub)

                '        'Dim lo As List(Of Ordine) = Nothing
                '        'Using mgr As New OrdiniDAO
                '        '    lo = mgr.FindAll(New LUNA.LunaSearchParameter("IdRub", _Voce.IdRub), New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Consegnato))
                '        'End Using

                '        'If lo.Count Then

                '        Dim lstIdDocRif As New List(Of Integer) From {_Voce.IdDocRif}

                '        If Rub.HaDocumentiInSospeso(lstIdDocRif) Then

                '            If MessageBox.Show("Vuoi stampare la situazione contabile del cliente?", "Situazione Contabile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                '                'prima di uscire mando in stampa il documento contabile
                '                Sottofondo()
                '                StampaBuffer(Rub.SituazioneContabile)
                '                Sottofondo()

                '            End If
                '        End If
                '    End Using
                'End If
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

    Private Sub lnkFattRiepilog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDocRettificato.LinkClicked

        'If _IdRicavoRiferimento Then
        'riapro la fattura

        'Using r As New Ricavo
        '    r.Read(_IdRicavoRiferimento)
        Sottofondo()
        If _RicavoRiferimento.Tipo = enTipoDocumento.Fattura Then
            Using x As New frmContabilitaRicavo
                x.Carica(_RicavoRiferimento.IdRicavo)
            End Using
        ElseIf _RicavoRiferimento.Tipo = enTipoDocumento.FatturaRiepilogativa Then
            Using x As New frmContabilitaFatturaRiepilogativaRicavo
                x.Carica(_RicavoRiferimento.IdRicavo)
            End Using
        End If
        Sottofondo()

        'End Using


        'End If

    End Sub


    Private Sub btnStampaEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgVociFat_CellContentDoubleClick(sender As Object,
                                                 e As DataGridViewCellEventArgs) Handles dgVociFat.CellContentDoubleClick

        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If dgVociFat.SelectedRows.Count Then
                Dim vf As VoceFattura = dgVociFat.SelectedRows(0).DataBoundItem
                Dim NuovaDescrizione As String = ""

                Select Case e.ColumnIndex

                        'Case 1 ' codice
                        '    Dim vf As New VoceFattura
                        '    vf.Read(IdVoceFat)
                        '    NuovaDescrizione = InputBox("Inserisci il nuovo codice della voce in fattura (non toccare niente per lasciarlo cosi)", "Voce in Fattura", vf.Codice)
                        '    If NuovaDescrizione.Length <> 0 AndAlso NuovaDescrizione <> vf.Codice Then
                        '        vf.Codice = NuovaDescrizione
                        '        vf.Save()
                        '        CaricaDettagliFat()
                        '    End If
                        '    vf = Nothing
                    Case 3 ' descrizione
                        'Dim vf As New VoceFattura
                        'vf.Read(IdVoceFat)
                        NuovaDescrizione = InputBox("Inserisci la nuova descrizione della voce in fattura (non toccare niente per lasciarla cosi)", "Voce in Fattura", vf.Descrizione)
                        If NuovaDescrizione.Length <> 0 AndAlso NuovaDescrizione <> vf.Descrizione Then
                            vf.Descrizione = NuovaDescrizione
                            vf.Custom = enSiNo.Si
                            If vf.IdVoceFat Then vf.Save()
                            dgVociFat.Refresh()
                        End If
                        vf = Nothing

                    Case 10 ' qta

                        NuovaDescrizione = InputBox("Inserisci la Quantita da inserire nella nota di credito (non toccare niente per lasciarla cosi)", "Voce in Fattura", vf.Qta)
                        If NuovaDescrizione.Length <> 0 AndAlso NuovaDescrizione <> vf.Qta.ToString AndAlso IsNumeric(NuovaDescrizione) AndAlso CSng(NuovaDescrizione) > 0 Then

                            Dim OkQta As Boolean = True
                            If vf.IdRigaOriginale Then
                                Using rOrig As New VoceFattura
                                    rOrig.Read(vf.IdRigaOriginale)
                                    If NuovaDescrizione > rOrig.Qta Then
                                        MessageBox.Show("Quantità massima inseribile in nota di credito: " & rOrig.Qta)
                                        OkQta = False
                                    End If
                                End Using
                            End If
                            If OkQta Then
                                vf.Qta = NuovaDescrizione
                                If vf.IdVoceFat Then vf.Save()

                                'CaricaDettagliFat()
                                dgVociFat.Refresh()
                                RicalcolaTotali()
                            End If

                        End If
                        vf = Nothing
                    Case 7 ' importo

                        NuovaDescrizione = InputBox("Inserisci l'importo singolo da inserire nella nota di credito (non toccare niente per lasciarlo cosi)", "Voce in Fattura", vf.Importo)
                        NuovaDescrizione = NuovaDescrizione.Replace(".", ",")
                        If NuovaDescrizione.Length <> 0 AndAlso NuovaDescrizione <> vf.Importo.ToString AndAlso IsNumeric(NuovaDescrizione) AndAlso CDec(NuovaDescrizione) > 0 Then
                            Dim OkQta As Boolean = True
                            If vf.IdRigaOriginale Then
                                Using rOrig As New VoceFattura
                                    rOrig.Read(vf.IdRigaOriginale)
                                    If NuovaDescrizione > rOrig.Importo Then
                                        MessageBox.Show("Importo massimo inseribile in nota di credito: " & rOrig.Importo)
                                        OkQta = False
                                    End If
                                End Using
                            End If
                            If OkQta Then
                                vf.Importo = NuovaDescrizione
                                If vf.IdVoceFat Then vf.Save()
                                'CaricaDettagliFat()
                                dgVociFat.Refresh()
                                RicalcolaTotali()
                            End If
                            vf = Nothing
                        End If

                End Select

            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile")
        End If

    End Sub

    Private Function GetTotaleNettoRighe() As Decimal
        Dim ris As Decimal = 0

        For Each dr As DataGridViewRow In dgVociFat.Rows

            If dr.DefaultCellStyle.Font.Strikeout = False Then
                Dim r As VoceFattura = dr.DataBoundItem

                ris += r.Importo
            End If

        Next
        Return ris
    End Function

    Private Sub RicalcolaTotali()

        Dim Tot As Decimal = GetTotaleNettoRighe()
        'Dim TotIva As Double = 0

        'Dim dr As DataGridViewRow

        'For Each dr In dgVociFat.Rows

        '    Tot += dr.Cells(4).Value
        '    ' TotIva += dr.Cells(5).Value

        'Next

        lblTotDettaglio.Text = FormerHelper.Stringhe.FormattaPrezzo(Tot)

        'txtIva.Text = FormattaPrezzo(TotIva)
        'CalcolaIva()

        CalcolaTot()

    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
        '_Voce.IdRub = cmbCliente.SelectedValue
        ' lblIntestazione.Text = _Voce.intestazione

    End Sub

    Private Sub pctSblocco_Click(sender As System.Object, e As System.EventArgs)

        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            tbDett.Enabled = False
            flowPanelPulsanti.Enabled = False
            btnConferma.Visible = True
            lblIntestazione.Enabled = False
        Else
            MessageBox.Show("Impossibile modificare una fattura in stato FE 'In coda per invio' o successivo")
        End If

    End Sub

    Private Sub btnAnnulla_Click(sender As Object, e As EventArgs) Handles btnAnnulla.Click

        Close()

    End Sub

    Private Sub lnkPrintBarcode_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

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

    Private Sub lnkApriCons_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

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

    Private Sub lblCostoSped_TextChanged(sender As Object, e As EventArgs)

        RicalcolaTotali()

    End Sub

    Private Sub lnkNoIva_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If MessageBox.Show("Vuoi trasformare questa fattura con IVA a 0?", "Fattura No IVA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                _Voce.Iva = 0
                _Voce.PercIva = 0
                _Voce.Totale = _Voce.Importo
                '_Voce.Save()

                txtPercIva.Text = 0
                'cmbEsclIvaNat.Enabled = True

                'ProxyStampa.StampaDocumentoFiscalePDF(_Voce)

            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile")
        End If


    End Sub

    Private Sub btnStampaEmail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

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

                        MessageBox.Show("Modifica effettuata! Ristampare il documento in PDF")
                    End If

                End Using

            End If
        Else
            MessageBox.Show("Impossibile modificare una fattura in stato FE 'In coda per invio' o successivo")
        End If


    End Sub

    Private Sub dgVociFat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgVociFat.CellContentClick

    End Sub

    Private Sub lnkIva4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If MessageBox.Show("Vuoi trasformare questa fattura con IVA al 4%?", "Fattura IVA 4%", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                txtPercIva.Text = 4

                Dim ToTIva As Decimal = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(((CDec(lblTotDettaglio.Text) / 100) * txtPercIva.Text), 2)

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

    Private Sub lnkEliminaRiga_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEliminaRiga.LinkClicked
        InserisciRiga()
    End Sub

    Private Sub InserisciRiga()
        If MgrFattureFE.FatturaEmessaModificabile(_IdVoce) Then
            If MessageBox.Show("Vuoi inserire la riga selezionata?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If dgVociFat.SelectedRows.Count Then
                    dgVociFat.SelectedRows(0).DefaultCellStyle.Font = New Drawing.Font(dgVociFat.SelectedRows(0).DefaultCellStyle.Font, FontStyle.Regular)
                    dgVociFat.Refresh()
                End If
                'dgVociFat.Rows.Remove(dgVociFat.SelectedRows(0))
                'CalcolaTot()
                RicalcolaTotali()
            End If
        Else
            MessageBox.Show("La fattura è in uno stato FE non modificabile")
        End If
    End Sub

    Private Sub lblCostoSped_TextChanged_1(sender As Object, e As EventArgs) Handles txtCostoSped.TextChanged
        'CalcolaIva()
        CalcolaTot()

    End Sub

    Private Sub btnStampaEmail_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnStampaEmail.LinkClicked
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
    End Sub

    Private Sub frmContabilitaNotaCredito_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'giro di peppe assurdo perche la form non visualizza lo stato modificato del controllo anceh se di fatto lo modifica

        If PrimoStrike = False Then
            PrimoStrike = True
            For i = 0 To dgVociFat.Rows.Count - 1

                dgVociFat.Rows(i).DefaultCellStyle.Font = New Drawing.Font(dgVociFat.Rows(i).DefaultCellStyle.Font, FontStyle.Strikeout)
                'dgVociFat.Rows(i).DefaultCellStyle.BackColor = Color.Green

            Next
            RicalcolaTotali()
        End If
    End Sub

    Private PrimoStrike As Boolean = False

End Class