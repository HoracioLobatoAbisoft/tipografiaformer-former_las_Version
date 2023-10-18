#Region "Author"

'All rights reserved.

'Author: Diego Lunadei
'Date: Marzo 2008

#End Region
Imports System.IO
Imports FormerBusinessLogic
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class ucDocumentiFiscali
    Inherits ucFormerUserControl
    Private RigaSel As Integer

    'Public ReadOnly Property IdDocSel() As Integer
    '    Get
    '        Dim idRich As Integer
    '        If DgDocumenti.Rows.Count Then
    '            If RigaSel <> -1 Then
    '                idRich = CType(DgDocumenti.Rows(RigaSel).Cells(0).FormattedValue, Integer)
    '            Else
    '                idRich = 0
    '            End If

    '        End If

    '        Return idRich

    '    End Get
    'End Property

    'Public ReadOnly Property Differenza() As Decimal

    '    Get

    '        Dim diff As Decimal = 0
    '        If DgDocumenti.SelectedRows.Count Then

    '            Try
    '                diff = DgDocumenti.Rows(RigaSel).Cells(11).Value
    '            Catch ex As Exception

    '            End Try

    '        End If

    '        Return diff

    '    End Get

    Public Sub MostraNonInCoda()

        ResetFiltri()
        MgrControl.SelectIndexCombo(cmbTipoDocumento, enTipoDocumento.Fattura)
        MgrControl.SelectIndexCombo(cmbStatoFE, enStatoFatturaFE.DaInviare)
        MgrControl.SelectIndexCombo(cmbAnnoRif, Now.Year)
        cmbStatoIncasso.SelectedIndex = 0
        cmbCategoria.SelectedIndex = 0
        cmbTipoPagamento.SelectedIndex = 0
        chkOnlyNot.Checked = False
        txtDescrizione.Text = String.Empty
        chkOnlyInCons.Checked = False
        chkSoloNonStampati.Checked = False

        FiltriAggiornati()

    End Sub

    Public Sub MostraScartati()

        ResetFiltri()
        MgrControl.SelectIndexCombo(cmbTipoDocumento, enTipoDocumento.Fattura)
        MgrControl.SelectIndexCombo(cmbStatoFE, enStatoFatturaFE.ScartataSDI)
        MgrControl.SelectIndexCombo(cmbAnnoRif, Now.Year)
        cmbStatoIncasso.SelectedIndex = 0
        cmbTipoPagamento.SelectedIndex = 0
        cmbCategoria.SelectedIndex = 0
        chkOnlyNot.Checked = False
        txtDescrizione.Text = String.Empty
        chkOnlyInCons.Checked = False
        chkSoloNonStampati.Checked = False

        FiltriAggiornati()

    End Sub

    Public Sub MostraInCodaInvio()

        ResetFiltri()
        MgrControl.SelectIndexCombo(cmbTipoDocumento, enTipoDocumento.Fattura)
        MgrControl.SelectIndexCombo(cmbStatoFE, enStatoFatturaFE.InCodaInvio)
        MgrControl.SelectIndexCombo(cmbAnnoRif, Now.Year)
        cmbStatoIncasso.SelectedIndex = 0
        cmbTipoPagamento.SelectedIndex = 0
        cmbCategoria.SelectedIndex = 0
        chkOnlyNot.Checked = False
        txtDescrizione.Text = String.Empty
        chkOnlyInCons.Checked = False
        chkSoloNonStampati.Checked = False

        FiltriAggiornati()

    End Sub

    Public Sub MostraInoltrati()

        ResetFiltri()
        MgrControl.SelectIndexCombo(cmbTipoDocumento, enTipoDocumento.Fattura)
        MgrControl.SelectIndexCombo(cmbStatoFE, enStatoFatturaFE.ConsegnataPEC)
        MgrControl.SelectIndexCombo(cmbAnnoRif, Now.Year)
        cmbStatoIncasso.SelectedIndex = 0
        cmbTipoPagamento.SelectedIndex = 0
        cmbCategoria.SelectedIndex = 0
        chkOnlyNot.Checked = False
        txtDescrizione.Text = String.Empty
        chkOnlyInCons.Checked = False
        chkSoloNonStampati.Checked = False

        FiltriAggiornati()

    End Sub

    'End Property
    Public Sub RegistraPagamentoAcquisto()
        If tabCosti.SelectedIndex = 0 Then
            If dgDocAcquisto.SelectedRows.Count Then
                Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
                If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                    If TypeOf riga.DataBoundItem Is Costo Then
                        Using R As Costo = riga.DataBoundItem
                            'If R.Differenza Then
                            If R.Tipo = enTipoDocumento.DDT Or R.Tipo = enTipoDocumento.NotaDiCredito Then
                                MessageBox.Show("Non è possibile registrare un pagamento su un DDT o una Nota di Credito!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                ParentFormEx.Sottofondo()

                                Using x As New frmContabilitaPagamento
                                    If x.Carica(0, R.IdRub, R.IdCosto, enTipoVoceContab.VoceAcquisto) Then MostraDocAcquisto()
                                End Using

                                ParentFormEx.Sottofondo()
                            End If
                            'Else
                            'MessageBox.Show("Il documento selezionato risulta interamente pagato!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            'End If
                        End Using
                    End If


                End If
            End If
        Else
            If Not tvwFattureAcquisto.SelectedNode Is Nothing AndAlso
                tvwFattureAcquisto.SelectedNode.Name.StartsWith("C") Then

                Using R As Costo = tvwFattureAcquisto.SelectedNode.Tag
                    'If R.Differenza Then
                    If R.Tipo = enTipoDocumento.DDT Or R.Tipo = enTipoDocumento.NotaDiCredito Then
                        MessageBox.Show("Non è possibile registrare un pagamento su un DDT o una Nota di Credito!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        ParentFormEx.Sottofondo()

                        Using x As New frmContabilitaPagamento
                            If x.Carica(0, R.IdRub, R.IdCosto, enTipoVoceContab.VoceAcquisto) Then MostraDocAcquisto()
                        End Using

                        ParentFormEx.Sottofondo()
                    End If
                    'Else
                    'MessageBox.Show("Il documento selezionato risulta interamente pagato!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'End If
                End Using

            End If
        End If

    End Sub

    Public Sub EmettiNotaDiCredito()

        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As RicavoEx = riga.DataBoundItem
                    'If R.Differenza Then
                    If R.Tipo = enTipoDocumento.Fattura OrElse
                        R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                        If R.StatoFE >= enStatoFatturaFE.NonConsegnataDestinatario Then
                            If R.NotaDiCreditoRelativa Is Nothing Then
                                ParentFormEx.Sottofondo()
                                Using x As New frmContabilitaNotaCredito
                                    If x.Carica(, R.IdRicavo) Then MostraDocVendita()
                                End Using
                                ParentFormEx.Sottofondo()
                            Else
                                MessageBox.Show("Esiste già una nota di credito per questo documento fiscale!")
                            End If
                        Else
                            MessageBox.Show("Si possono emettere note di credito solo su fatture inviate a SDI!")
                        End If
                    Else
                        MessageBox.Show("Si può emettere una nota di credito solo su una fattura emessa!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    'Else
                    'MessageBox.Show("Il documento selezionato risulta interamente pagato!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'End If
                End Using
            End If
        End If

    End Sub

    Public Sub RegistraPagamentoVendita()

        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As RicavoEx = riga.DataBoundItem
                    If R.TotaleAncoraDaPagare > 0 Then
                        If R.Tipo = enTipoDocumento.DDT Then
                            MessageBox.Show("Non è possibile registrare un pagamento su un DDT!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            ParentFormEx.Sottofondo()

                            Using x As New frmContabilitaPagamento
                                If x.Carica(0, R.IdRub, R.IdRicavo, enTipoVoceContab.VoceVendita) Then MostraDocVendita()
                            End Using

                            ParentFormEx.Sottofondo()
                        End If
                    Else
                        MessageBox.Show("Il documento selezionato risulta interamente pagato!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End Using
            End If
        End If

        'If IdDocSel Then

        '    If Differenza = 0 Then
        '        MessageBox.Show("Il documento selezionato risulta interamente pagato!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Else
        '        Dim TipoDocumento As enTipoDocumento
        '        If IdTipoDocSel = enTipoVoceContab.VoceVendita Then
        '            Using R As New Ricavo
        '                R.Read(IdDocSel)
        '                TipoDocumento = R.Tipo
        '            End Using
        '        Else
        '            Using C As New Costo
        '                C.Read(IdDocSel)
        '                TipoDocumento = C.Tipo
        '            End Using
        '        End If

        '        If TipoDocumento = enTipoDocumento.DDT Then
        '            MessageBox.Show("Non è possibile registrare un pagamento su un DDT!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Else
        '            ParentFormEx.Sottofondo()

        '            Using x As New frmContabilitaPagamento
        '                If x.Carica(0, _IdRub, IdDocSel, IdTipoDocSel) Then MostraDatiOld(rdoVendita.Checked)
        '            End Using

        '            ParentFormEx.Sottofondo()
        '        End If

        '    End If
        'Else
        '    MessageBox.Show("Selezionare un documento dalla lista!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If

    End Sub

    'Public ReadOnly Property IdTipoDocSel() As Integer
    '    Get

    '        Dim idRich As Integer
    '        If DgDocumenti.Rows.Count Then
    '            If RigaSel > -1 Then
    '                idRich = CType(DgDocumenti.Rows(RigaSel).Cells(1).FormattedValue, Integer)
    '            Else
    '                idRich = 0
    '            End If
    '        End If
    '        Return idRich

    '    End Get
    'End Property

    Private _IdRub As Integer = 0
    Public Property IdRub() As Integer
        Get
            Return _IdRub
        End Get
        Set(ByVal value As Integer)
            _IdRub = value
            If _IdRub Then
                'MgrControl.SelectIndexCombo(cmbCliente, _IdRub)
                UcComboCliente.IdRubSelezionato = _IdRub
                MgrControl.SelectIndexCombo(cmbAnnoRif, 0)
                UcComboCliente.Enabled = False
                MgrControl.SelectIndexComboEnum(cmbTipoDocumento, enTipoDocumento.Fattura)

                Using r As New VoceRubrica
                    r.Read(_IdRub)
                    If r.IsFornitore Then
                        tabDoc.SelectedIndex = 1
                    Else
                        tabDoc.SelectedIndex = 0
                    End If
                End Using

                FiltriAggiornati()
            End If
        End Set
    End Property

    'Public ReadOnly Property DescRichSel() As String
    '    Get
    '        Dim Desc As String
    '        If RigaSel > -1 Then
    '            Desc = "Codice: " & DgDocumenti.Rows(RigaSel).Cells(1).FormattedValue & " - " & DgDocumenti.Rows(RigaSel).Cells(3).FormattedValue & " - " & DgDocumenti.Rows(RigaSel).Cells(4).FormattedValue
    '        Else
    '            Desc = ""
    '        End If
    '        Return Desc

    '    End Get
    'End Property

    'Public Sub MostraDatiEx(ByVal Entrata As Boolean)

    '    Cursor.Current = Cursors.WaitCursor
    '    Application.DoEvents()

    '    lnkAll.Enabled = False
    '    pnlRdo.Enabled = False

    '    Try

    '        If cmbAnnoRif.Items.Count = 0 Then CaricaCombo()

    '        If cmbAnnoRif.SelectedValue.ToString.Length Then

    '            Dim ls As New List(Of cContabRicaviEx)
    '            Dim contab As New cContabRicaviMgr

    '            ls = contab.Cerca()
    '            DGRichieste.DataSource = ls

    '            ''mostro i dati
    '            'Dim dttable As DataTable
    '            'Dim Contab As cContab = New cContab

    '            ''dttable = Contab.Lista(cmbAnnoRif.Text.ToString, cmbMese.SelectedValue, _IdRub)
    '            'Dim IdRif As Integer = 0
    '            'If _IdRub Then
    '            '    IdRif = _IdRub
    '            'Else
    '            '    IdRif = cmbCliente.SelectedValue
    '            'End If

    '            'Dim TipoDoc As Integer = 0
    '            'If rdoDDt.Checked Then TipoDoc = enTipoDocumento.enTipoDocDDT
    '            'If rdoPrev.Checked Then TipoDoc = enTipoDocumento.enTipoDocPreventivo
    '            'If rdoFatt.Checked Then TipoDoc = enTipoDocumento.enTipoDocFattura

    '            'dttable = Contab.Lista(cmbAnnoRif.Text.ToString, cmbMese.SelectedValue, IdRif, TipoDoc, chkOnlyNot.Checked, chkOnlyElapsed.Checked, chkOnlyInCons.Checked, Entrata)
    '            'DGRichieste.DataSource = dttable
    '            'DGRichieste.Columns(0).Visible = False
    '            'DGRichieste.Columns(1).Visible = False
    '            'DGRichieste.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '            'DGRichieste.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '            'DGRichieste.Columns(7).DefaultCellStyle.Format = "0.00"
    '            'DGRichieste.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '            'DGRichieste.Columns(8).DefaultCellStyle.Format = "0.00"
    '            'DGRichieste.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '            'DGRichieste.Columns(9).DefaultCellStyle.Format = "0.00"
    '            'DGRichieste.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '            'DGRichieste.Columns(10).DefaultCellStyle.Format = "0.00"

    '            'DGRichieste.Columns(11).Visible = False
    '            'DGRichieste.Columns(12).Visible = False
    '            'DGRichieste.Columns(14).Visible = False

    '            'DGRichieste.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    '        End If
    '    Catch ex As Exception

    '    End Try
    '    pnlRdo.Enabled = True

    '    Cursor.Current = Cursors.Default
    '    lnkAll.Enabled = True


    'End Sub

    'Public Sub SelectAllYear()

    '    MgrControl.SelectIndexCombo(cmbAnnoRif, 0)

    'End Sub

    Public Sub MostraDocAcquisto(Optional StatoDocumento As enStatoDocumentoFiscale = enStatoDocumentoFiscale.NonDefinito)
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Dim IdAzienda As Integer = 0

        If FormerSrlToolStripMenuItem1.Checked Then
            IdAzienda = MgrAziende.IdAziende.AziendaSrl
        ElseIf FormerSncToolStripMenuItem1.Checked Then
            IdAzienda = MgrAziende.IdAziende.AziendaSnc
        End If
        Using mgr As New CostiDAO

            Dim IdRif As Integer = 0

            If _IdRub Then
                IdRif = _IdRub
            Else
                IdRif = UcComboCliente.IdRubSelezionato 'cmbCliente.SelectedValue
            End If

            Dim TipoDoc As enFiltroTipoDocumento = cmbTipoDocumento.SelectedValue
            'If cmbTipoDocumento.SelectedValue = enTipoDocumento.DDTInFattura Then TipoDoc = enTipoDocumento.DDT

            Dim l As List(Of Costo) = mgr.GetLista(cmbAnnoRif.SelectedValue,
                                                   cmbMese.SelectedValue,
                                                   IdRif,
                                                   TipoDoc,
                                                   chkOnlyNot.Checked,
                                                   chkOnlyElapsed.Checked,
                                                   txtDescrizione.Text,,
                                                   IdAzienda,
                                                   StatoDocumento,
                                                   cmbCategoria.SelectedValue)

            If tabCosti.SelectedIndex = 0 Then
                Using s As New BindingSource
                    s.DataSource = l
                    dgDocAcquisto.DataSource = s
                End Using
            Else
                CaricaAlberoFattureAcquisto(l)
            End If

            'dgDocAcquisto.DataSource = l

            'qui carico pure la treeview 




            Dim TotEuro As Decimal = 0
            Dim TotPagato As Decimal = 0

            lblNumRis.Text = "Righe: " & l.Count

            Dim lTot As List(Of Costo) = l.FindAll(Function(z) z.Tipo <> enTipoDocumento.DDT) ' Or (z.Tipo = enTipoDocumento.DDT And z.IdDocRif = 0))

            TotEuro = lTot.Sum(Function(x) x.TotaleMatematico)
            TotPagato = lTot.Sum(Function(x) x.TotaleGiaPagato)

            lblNumEuro.Text = "Fatturato € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotEuro)
            lblNumDiff.Text = "Differenza € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotEuro - TotPagato)

        End Using

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub CaricaAlberoFattureAcquisto(l As List(Of Costo))

        tvwFattureAcquisto.Nodes.Clear()
        'l.Sort(Function(x, y) y.DataOraRicezione.CompareTo(x.DataOraRicezione))
        For Each C In l
            Dim Risultati As TreeNode() = Nothing
            'Dim ChiaveMese As String = "M" & C.DataCosto.ToString("MMyyyy")
            'Risultati = tvwFattureAcquisto.Nodes.Find(ChiaveMese, False)
            'Dim NodoMese As TreeNode = Nothing

            'If Risultati.Count Then
            'NodoMese = Risultati(0)
            'Else
            'NodoMese = tvwFattureAcquisto.Nodes.Add(ChiaveMese, StrConv(C.DataCosto.ToString("MMMM yyyy"), VbStrConv.Uppercase), 0, 0)
            'End If

            Dim NodoFornitore As TreeNode = Nothing
            Dim ChiaveFornitore As String = "F" & C.IdRub

            Risultati = tvwFattureAcquisto.Nodes.Find(ChiaveFornitore, False)

            If Risultati.Count Then
                NodoFornitore = Risultati(0)
            Else
                Dim LabelForn As String = C.Fornitore.RagSocNome & " (Data Ult. Doc. " & C.DataCosto.ToString("dd/MM/yyyy") & ")"
                NodoFornitore = tvwFattureAcquisto.Nodes.Add(ChiaveFornitore, LabelForn, 1, 1)
            End If

            'Dim ChiaveAzienda As String = "A" & C.IdAzienda
            'Dim NodoAzienda As TreeNode = Nothing
            'Risultati = NodoFornitore.Nodes.Find(ChiaveAzienda, False)

            'If Risultati.Count Then
            '    NodoAzienda = Risultati(0)
            'Else
            '    NodoAzienda = NodoFornitore.Nodes.Add(ChiaveAzienda, MgrAziende.GetSiglaStr(C.IdAzienda), 2, 2)
            '    'NodoAzienda.BackColor = MgrAziende.getcolorebackground(C.IdAzienda)
            'End If

            Dim ChiaveCosto As String = "C" & C.IdCosto
            Dim LabelCosto As String = MgrAziende.GetSiglaStr(C.IdAzienda) & " - " & C.TipoDocStr & " " & C.Numero & " del " & C.DataCosto.ToString("dd/MM/yyyy") & " - € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(C.Totale)

            Dim IconaFattura As Integer = 5

            If C.PagatoInteramente Then IconaFattura = 4

            Dim NodoCosto As TreeNode = NodoFornitore.Nodes.Add(ChiaveCosto, LabelCosto, IconaFattura, IconaFattura)
            NodoCosto.Tag = C
            'NodoAzienda.Expand()
            'NodoMese.Expand()
        Next
        If tvwFattureAcquisto.Nodes.Count Then
            tvwFattureAcquisto.SelectedNode = tvwFattureAcquisto.Nodes(0)
            tvwFattureAcquisto.SelectedNode.EnsureVisible()
        End If


    End Sub

    Public Sub MostraDocVendita()
        Dim StatoFe As Integer = -1
        Try
            StatoFe = DirectCast(cmbStatoFE.SelectedItem, cEnum).Id
        Catch ex As Exception

        End Try

        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Dim IdAzienda As Integer = 0

        If FormerSrlToolStripMenuItem.Checked Then
            IdAzienda = MgrAziende.IdAziende.AziendaSrl
        ElseIf FormerSncToolStripMenuItem.Checked Then
            IdAzienda = MgrAziende.IdAziende.AziendaSnc
        End If

        Using mgr As New RicaviDAO

            Dim IdRif As Integer = 0
            If _IdRub Then
                IdRif = _IdRub
            Else
                IdRif = UcComboCliente.IdRubSelezionato 'cmbCliente.SelectedValue
            End If

            Dim TipoDoc As enFiltroTipoDocumento = cmbTipoDocumento.SelectedValue
            'If cmbTipoDocumento.SelectedValue = enTipoDocumento.DDTInFattura Then TipoDoc = enTipoDocumento.DDT

            Dim l As List(Of RicavoEx) = Nothing
            If StatoFe = -1 Then
                l = mgr.GetLista(cmbAnnoRif.SelectedValue,
                                            cmbMese.SelectedValue,
                                            IdRif,
                                            TipoDoc,
                                            chkOnlyNot.Checked,
                                            chkOnlyElapsed.Checked,
                                            chkOnlyInCons.Checked,
                                            txtDescrizione.Text,
                                            cmbTipoPagamento.SelectedValue,
                                            chkSoloNonStampati.Checked,
                                            cmbStatoIncasso.SelectedValue,
                                            IdAzienda)
            Else
                l = mgr.GetLista(cmbAnnoRif.SelectedValue,
                            cmbMese.SelectedValue,
                            ,
                            ,
                            ,
                            ,
                            ,
                            ,
                            ,
                            ,
                            ,
                            IdAzienda,
                            StatoFe)
            End If

            dgDocVendita.DataSource = l

            Dim TotEuro As Decimal = 0
            Dim TotPagato As Decimal = 0

            lblNumRis.Text = "Righe: " & l.Count

            Dim lTot As List(Of RicavoEx) = l.FindAll(Function(z) z.Tipo <> enTipoDocumento.DDT Or (z.Tipo = enTipoDocumento.DDT And z.IdDocRif = 0))

            TotEuro = lTot.Sum(Function(x) x.TotaleMatematico)
            TotPagato = lTot.Sum(Function(x) x.TotaleGiaPagato)

            lblNumEuro.Text = "Fatturato € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotEuro)
            lblNumDiff.Text = "Differenza € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotEuro - TotPagato)

        End Using

        Cursor.Current = Cursors.Default
    End Sub

    'Public Sub MostraDatiOld(ByVal Entrata As Boolean)
    '    'MostraDatiEx(Entrata)
    '    'Exit Sub

    '    Cursor.Current = Cursors.WaitCursor
    '    Application.DoEvents()

    '    'lnkAll.Enabled = False
    '    cmbTipoDocumento.Enabled = False

    '    Try
    '        'DgDocumenti.DataSource = Nothing
    '        Refresh()

    '        If cmbAnnoRif.Items.Count = 0 Then CaricaCombo()
    '        'If IdRub Then MgrControl.SelectIndexCombo(cmbAnnoRif, 0)
    '        If Not cmbAnnoRif.SelectedValue Is Nothing Then

    '            'mostro i dati
    '            Dim dttable As DataTable
    '            Using Contab As cContab = New cContab

    '                'dttable = Contab.Lista(cmbAnnoRif.Text.ToString, cmbMese.SelectedValue, _IdRub)
    '                Dim IdRif As Integer = 0
    '                If _IdRub Then
    '                    IdRif = _IdRub
    '                Else
    '                    IdRif = UcComboCliente.IdRubSelezionato ' cmbCliente.SelectedValue
    '                End If

    '                Dim TipoDoc As Integer = cmbTipoDocumento.SelectedValue

    '                dttable = Contab.Lista(cmbAnnoRif.Text.ToString,
    '                                       cmbMese.SelectedValue,
    '                                       IdRif,
    '                                       TipoDoc,
    '                                       chkOnlyNot.Checked,
    '                                       chkOnlyElapsed.Checked,
    '                                       chkOnlyInCons.Checked,
    '                                       Entrata,
    '                                       txtDescrizione.Text,
    '                                       cmbTipoPagamento.SelectedValue,
    '                                       chkSoloNonStampati.Checked,
    '                                       cmbStatoIncasso.SelectedValue)

    '                'DgDocumenti.DataSource = dttable
    '                'DgDocumenti.Columns(0).Visible = False
    '                'DgDocumenti.Columns(1).Visible = False
    '                'DgDocumenti.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '                'DgDocumenti.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                'DgDocumenti.Columns(7).DefaultCellStyle.Format = "0.00"
    '                'DgDocumenti.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                'DgDocumenti.Columns(8).DefaultCellStyle.Format = "0.00"
    '                'DgDocumenti.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                'DgDocumenti.Columns(9).DefaultCellStyle.Format = "0.00"
    '                'DgDocumenti.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                'DgDocumenti.Columns(10).DefaultCellStyle.Format = "0.00"

    '                'DgDocumenti.Columns(11).Visible = False
    '                'DgDocumenti.Columns(12).Visible = False
    '                'DgDocumenti.Columns(14).Visible = False

    '                'DgDocumenti.Columns(18).Visible = False
    '                'DgDocumenti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    '                'calcolo i totali
    '                'lblTotRicavi.Text = FormattaPrezzo(Contab.ToTRicavi(cmbAnnoRif.Text.ToString, cmbMese.SelectedValue, _IdRub))
    '                'lblTotCosti.Text = FormattaPrezzo(Contab.ToTCosti(cmbAnnoRif.Text.ToString, cmbMese.SelectedValue, _IdRub))

    '                'lblBilancio.Text = FormattaPrezzo(lblTotRicavi.Text - lblTotCosti.Text)

    '                'lblTotIvaCredito.Text = FormattaPrezzo(Contab.ToTIvaCredito(cmbAnnoRif.Text.ToString, cmbMese.SelectedValue, _IdRub))
    '                'lblTotIvaDebito.Text = FormattaPrezzo(Contab.ToTIvaDebito(cmbAnnoRif.Text.ToString, cmbMese.SelectedValue, _IdRub))

    '                'lblBilancioIva.Text = FormattaPrezzo(lblTotIvaCredito.Text - lblTotIvaDebito.Text)
    '            End Using

    '            'RigaInserita()
    '        End If
    '    Catch ex As Exception

    '        'Stop

    '    End Try
    '    cmbTipoDocumento.Enabled = True

    '    Cursor.Current = Cursors.Default
    '    'lnkAll.Enabled = True
    'End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub DGOfferte_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        RigaSel = e.RowIndex

        'Cursor.Current = Cursors.WaitCursor

        'UcAnteprima.Carica("about:blank")

        'If RigaSel >= 0 Then

        '    Dim IdVoce As Integer, TipoVoce As Integer

        '    IdVoce = DGRichieste.SelectedRows(0).Cells(0).Value
        '    TipoVoce = DGRichieste.SelectedRows(0).Cells(1).Value

        '    UcAnteprima.Carica(CreaRiepilogoContabHTML(IdVoce, TipoVoce))

        'End If

        'Cursor.Current = Cursors.Default

        RaiseEvent VoceSelezionata()

    End Sub

    Public Event VoceSelezionata()

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)


    End Sub

    Private childTemplate As GridViewTemplate = Nothing

    Private Function CreateChildTemplate() As GridViewTemplate
        Dim childTemplate As New GridViewTemplate()
        childTemplate.AutoGenerateColumns = False
        childTemplate.AllowColumnReorder = False
        childTemplate.ShowColumnHeaders = True
        childTemplate.AllowRowResize = False
        childTemplate.AllowColumnResize = True
        childTemplate.AllowCellContextMenu = False

        dgDocAcquisto.Templates.Add(childTemplate)

        Dim columnT As New GridViewTextBoxColumn("CodiceEx")
        columnT.HeaderText = "Codice"
        columnT.TextAlignment = ContentAlignment.MiddleLeft
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("Descrizione")
        columnT.HeaderText = "Descrizione"
        columnT.TextAlignment = ContentAlignment.MiddleLeft
        columnT.MinWidth = 200
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("QtaEx")
        columnT.HeaderText = "Qta"
        columnT.TextAlignment = ContentAlignment.MiddleRight
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("Um")
        columnT.HeaderText = "UM"
        columnT.TextAlignment = ContentAlignment.MiddleCenter
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("PrezzoUnit")
        columnT.HeaderText = "Prezzo Unit."
        columnT.TextAlignment = ContentAlignment.MiddleRight
        columnT.FormatString = "{0:C}"
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("Totale")
        columnT.HeaderText = "Totale"
        columnT.FormatInfo = New Globalization.CultureInfo("it-IT")
        columnT.FormatString = "{0:C}"
        columnT.TextAlignment = ContentAlignment.MiddleRight
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("AliquotaIva")
        columnT.HeaderText = "AliquotaIva"
        columnT.TextAlignment = ContentAlignment.MiddleRight
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("TipoCessionePrestazione")
        columnT.HeaderText = "Tipo"
        columnT.TextAlignment = ContentAlignment.MiddleCenter
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        Dim columnI As New GridViewImageColumn("ImgRigaCollegata")
        columnI.HeaderText = ""
        columnI.ImageAlignment = ContentAlignment.MiddleCenter
        columnI.ImageLayout = ImageLayout.Stretch
        columnI.MinWidth = 30
        columnI.Width = 30
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnI)
        'childTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.
        Return childTemplate
    End Function

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()
        Try
            BackColor = Color.White
            If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then
                chkOnlyInCons.BackColor = FormerColori.ColoreStatoOrdineInConsegna

                ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
                CaricaCombo()
            End If

            MgrControl.InizializeGridview(dgDocVendita)
            MgrControl.InizializeGridview(dgDocAcquisto)

            childTemplate = CreateChildTemplate()
            Dim relation As New GridViewRelation(dgDocAcquisto.MasterTemplate, childTemplate)
            relation.ChildColumnNames.Add("ListaVociFattura")
            dgDocAcquisto.Relations.Add(relation)



        Catch ex As Exception

        End Try

    End Sub

    Private Sub CaricaCli()

        Cursor.Current = Cursors.WaitCursor

        Dim TipoRubrica As enTipoRubrica = enTipoRubrica.Tutto

        'qui a seconda della tab selezionata lancio il mostra dati adeguato
        'If tabDoc.SelectedIndex = 1 Then

        '    TipoRubrica = enTipoRubrica.Fornitore

        'End If

        'Using cli As New VociRubricaDAO
        '    cmbCliente.ValueMember = "IdRub"
        '    cmbCliente.DisplayMember = "Nominativo"

        '    cmbCliente.DataSource = cli.ListaCombo(TipoRubrica, True)
        'End Using

        UcComboCliente.Carica(TipoRubrica, True)

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CaricaComboStatoFE()

        Cursor.Current = Cursors.WaitCursor

        Dim lStatoFE As New List(Of cEnum)
        lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.Tutti, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})

        For Each SingStatoAttivo As Integer In MgrDocumentiFiscali.GetListaStatiFiscali
            lStatoFE.Add(New cEnum With {.Id = SingStatoAttivo, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        Next

        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.DaInviare, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.InCodaInvio, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.InviataXML, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.ScartataSDI, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.AccettataSDI, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.InoltrataDest, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.NonConsegnataDest, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.RicevutaDiConsegna, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.RicevutoEsito, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.DecorsiTerminiEsito, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.TrasmessaSenzaRecapito, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.Archiviata, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})
        'lStatoFE.Add(New cEnum With {.Id = enStatoFatturaFE.AllegatoXMLRicevuto, .Descrizione = FormerEnumHelper.GetStatoFEStr(.Id)})

        cmbStatoFE.ValueMember = "Id"
        cmbStatoFE.DisplayMember = "Descrizione"
        cmbStatoFE.DataSource = lStatoFE
        cmbStatoFE.SelectedIndex = 0

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub CaricaCombo()

        'carico l'anno
        ' If Not _cnOld Is Nothing Then


        'Dim myCommand As OleDbCommand = _cnOld.CreateCommand(), dt As New DataTable
        'myCommand.CommandText = "select Annorif from (SELECT distinct(dataRif) as AnnoRif FROM (Select year(datacosto) as datarif from t_ContabCosti union select year(dataricavo) as datarif from t_contabricavi)) order by Annorif desc"

        'Dim myReader As OleDbDataReader = myCommand.ExecuteReader()

        'dt.Load(myReader)

        'myReader.Close()

        'If LUNA.LunaContext.TotConnAttive Then
        'If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then

        Dim AR As New cAnnoRif
        cmbAnnoRif.DataSource = AR
        cmbAnnoRif.DisplayMember = "Descrizione"
        cmbAnnoRif.ValueMember = "Id"
        'cmbAnnoRif.SelectedIndex = 0
        'carico i mesi

        'If IdRub = 0 Then
        MgrControl.SelectIndexCombo(cmbAnnoRif, FormerConst.Fiscali.IdBiennio) ' Now.Date.Year)
        'Else
        'cmbAnnoRif.SelectedIndex = 0
        'End If

        Dim x As New cMeseRif
        cmbMese.DataSource = x
        cmbMese.DisplayMember = "Descrizione"
        cmbMese.ValueMember = "Id"

        CaricaCli()

        Using mgr As New TipoPagamentiDAO
            Dim l As List(Of TipoPagamento) = mgr.GetAll(LFM.TipoPagamento.TipoPagam, True)

            cmbTipoPagamento.ValueMember = "IdTipoPagam"
            cmbTipoPagamento.DisplayMember = "TipoPagam"
            cmbTipoPagamento.DataSource = l

        End Using

        Dim lStatoI As New List(Of cEnum)
        lStatoI.Add(New cEnum With {.Id = enStatoIncasso.Tutto, .Descrizione = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Tutto)})
        lStatoI.Add(New cEnum With {.Id = enStatoIncasso.Normale, .Descrizione = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Normale)})
        lStatoI.Add(New cEnum With {.Id = enStatoIncasso.Problematico, .Descrizione = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Problematico)})
        lStatoI.Add(New cEnum With {.Id = enStatoIncasso.Difficile, .Descrizione = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Difficile)})
        lStatoI.Add(New cEnum With {.Id = enStatoIncasso.Impossibile, .Descrizione = FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Impossibile)})

        cmbStatoIncasso.ValueMember = "Id"
        cmbStatoIncasso.DisplayMember = "Descrizione"
        cmbStatoIncasso.DataSource = lStatoI

        CaricaComboStatoFE()
        'End If
        'End If
        '

        '  End If


        Dim lTipoDoc As New List(Of cEnum)

        lTipoDoc.Add(New cEnum With {.Id = enFiltroTipoDocumento.Tutto, .Descrizione = "Tutto"})
        lTipoDoc.Add(New cEnum With {.Id = enFiltroTipoDocumento.FatturaENotaDiCredito, .Descrizione = "Fatture e Note di Credito"})
        lTipoDoc.Add(New cEnum With {.Id = enFiltroTipoDocumento.Fattura, .Descrizione = "Fatture"})
        lTipoDoc.Add(New cEnum With {.Id = enFiltroTipoDocumento.NotaDiCredito, .Descrizione = "Note di Credito"})
        lTipoDoc.Add(New cEnum With {.Id = enFiltroTipoDocumento.Preventivo, .Descrizione = "Preventivi"})
        lTipoDoc.Add(New cEnum With {.Id = enFiltroTipoDocumento.DDT, .Descrizione = "D.D.T. NON in Fattura"})
        lTipoDoc.Add(New cEnum With {.Id = enFiltroTipoDocumento.DDTInFattura, .Descrizione = "D.D.T. in Fattura"})
        'lTipoDoc.Add(New cEnum With {.Id = enTipoDocumento.NotaDiDebito, .Descrizione = "Nota di Debito"})
        'lTipoDoc.Add(New cEnum With {.Id = enTipoDocumento.AccontoAnticipoSuFattura, .Descrizione = "Acconto/Anticipo su Fattura"})

        cmbTipoDocumento.ValueMember = "Id"
        cmbTipoDocumento.DisplayMember = "Descrizione"
        cmbTipoDocumento.DataSource = lTipoDoc
        cmbTipoDocumento.SelectedIndex = 1

        Using mgr As New CategContabiliDAO
            Dim lC As List(Of CategContabile) = mgr.FindAll(New LUNA.LunaSearchOption With {.AddEmptyItem = True, .OrderBy = "Tipocat,NomeCat"},
                                                            New LUNA.LSP(LFM.CategContabile.TipoCat, enTipoVoceContab.VoceAcquisto))
            cmbCategoria.DisplayMember = "Riassunto"
            cmbCategoria.ValueMember = LFM.CategContabile.IdCatContab.Name
            cmbCategoria.DataSource = lC
        End Using

    End Sub

    'Private Sub DGRichieste_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    '    Dim RigaSel As Integer = e.RowIndex

    '    If RigaSel <> -1 Then
    '        Dim IdVoce As Integer = CType(DgDocumenti.Rows(RigaSel).Cells(0).FormattedValue, Integer)
    '        Dim TipoVoce As Integer = CType(DgDocumenti.Rows(RigaSel).Cells(1).FormattedValue, Integer)
    '        Dim TipoDoc As Integer = CType(DgDocumenti.Rows(RigaSel).Cells(12).FormattedValue, Integer)
    '        'riapertura appuntamento
    '        ParentFormEx.Sottofondo()
    '        If TipoDoc = enTipoDocumento.FatturaRiepilogativa Then
    '            Dim appForm As New frmContabilitaFatturaRiepilogativaRicavo
    '            If appForm.Carica(IdVoce) Then MostraDatiOld(rdoVendita.Checked)
    '        Else
    '            Dim appForm As New frmContabilitaRicavo
    '            If appForm.Carica(IdVoce, TipoVoce, _IdRub) Then MostraDatiOld(rdoVendita.Checked)
    '        End If
    '        ParentFormEx.Sottofondo()
    '    End If

    'End Sub

    'Private Sub DGRichieste_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

    '    DgDocumenti.Select()

    '    RigaSel = e.RowIndex

    '    If RigaSel <> -1 Then

    '        If e.Button = Windows.Forms.MouseButtons.Right Then

    '            Dim x As System.Drawing.Point = MousePosition
    '            'btnNuovoCliente.ContextMenu = menuNuovo.
    '            x = MousePosition
    '            'x = lnkNew.PointToClient(x)

    '            Dim rig As DataGridViewRow
    '            rig = DgDocumenti.Rows(RigaSel)
    '            rig.Selected = True
    '            DgDocumenti.Select()
    '            menuVoce.Show(x)

    '        End If
    '    End If
    'End Sub
    Private Sub ModificaVoceVendita()
        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As RicavoEx = riga.DataBoundItem
                    ParentFormEx.Sottofondo()
                    If R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                        Using appForm As New frmContabilitaFatturaRiepilogativaRicavo
                            If appForm.Carica(R.IdRicavo) Then MostraDocVendita() '(rdoVendita.Checked)
                        End Using
                    ElseIf R.Tipo = enTipoDocumento.NotaDiCredito Then
                        Using appForm As New frmContabilitaNotaCredito
                            If appForm.Carica(R.IdRicavo) Then MostraDocVendita() '(rdoVendita.Checked)
                        End Using
                    Else
                        Using appForm As New frmContabilitaRicavo
                            If appForm.Carica(R.IdRicavo) Then MostraDocVendita() '(rdoVendita.Checked)
                        End Using
                    End If
                    ParentFormEx.Sottofondo()
                End Using
            End If
        End If
    End Sub

    Private Sub FiltraConQuestoCliente()
        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As RicavoEx = riga.DataBoundItem
                    UcComboCliente.IdRubSelezionato = R.IdRub
                End Using
            End If
        End If
    End Sub

    Private Sub FiltraConQuestoRivenditore()
        If tabCosti.SelectedIndex = 0 Then
            If dgDocAcquisto.SelectedRows.Count Then
                Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
                If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                    Using R As Costo = riga.DataBoundItem
                        UcComboCliente.IdRubSelezionato = R.IdRub
                    End Using
                End If
            End If
        Else
            If Not tvwFattureAcquisto.SelectedNode Is Nothing AndAlso
                tvwFattureAcquisto.SelectedNode.Name.StartsWith("C") Then

                Using R As Costo = tvwFattureAcquisto.SelectedNode.Tag
                    UcComboCliente.IdRubSelezionato = R.IdRub
                End Using

            End If
        End If

    End Sub

    Private Sub ModificaVoceAcquisto()

        If tabCosti.SelectedIndex = 0 Then
            'classic
            If dgDocAcquisto.SelectedRows.Count Then
                Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
                If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                    If TypeOf (riga.DataBoundItem) Is Costo Then
                        Using R As Costo = riga.DataBoundItem
                            ParentFormEx.Sottofondo()
                            If R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                                Using appForm As New frmContabilitaFatturaRiepilogativaCosto
                                    If appForm.Carica(R.IdCosto) Then MostraDocAcquisto() '(rdoVendita.Checked)
                                End Using
                            Else
                                Using appForm As New frmContabilitaCosto
                                    If appForm.Carica(R.IdCosto) Then MostraDocAcquisto()
                                End Using
                            End If
                            ParentFormEx.Sottofondo()
                        End Using
                    ElseIf TypeOf (riga.DataBoundItem) Is VoceCosto Then
                        Using VC As VoceCosto = riga.DataBoundItem
                            Using mgr As New MagazzinoDAO
                                Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdVoceCosto, VC.IdVoceCosto))
                                If l.Count Then
                                    Using mov As MovimentoMagazzino = l(0)
                                        ParentFormEx.Sottofondo()
                                        Using f As New frmMagazzinoRisorsa
                                            f.Carica(mov.IdRis)
                                        End Using
                                        ParentFormEx.Sottofondo()
                                    End Using
                                Else
                                    Beep()
                                End If
                            End Using
                        End Using

                    End If

                End If
            End If
        Else
            'fornitori
            If Not tvwFattureAcquisto.SelectedNode Is Nothing AndAlso
                tvwFattureAcquisto.SelectedNode.Name.StartsWith("C") Then

                Using R As Costo = tvwFattureAcquisto.SelectedNode.Tag
                    ParentFormEx.Sottofondo()
                    If R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                        Using appForm As New frmContabilitaFatturaRiepilogativaCosto
                            If appForm.Carica(R.IdCosto) Then MostraDocAcquisto() '(rdoVendita.Checked)
                        End Using
                    Else
                        Using appForm As New frmContabilitaCosto
                            If appForm.Carica(R.IdCosto) Then MostraDocAcquisto()
                        End Using
                    End If
                    ParentFormEx.Sottofondo()
                End Using

            End If
        End If


    End Sub

    Private Sub EliminaVoceVendita()

        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As RicavoEx = riga.DataBoundItem

                    If MgrFattureFE.FatturaEmessaModificabile(R.IdRicavo) Then
                        If MessageBox.Show("ATTENZIONE! Si sta eliminando una voce di contabilità, confermi la cancellazione della voce selezionata? L'operazione non e' reversibile!", "Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                            'If IdTipoVoce = enTipoVoceContab.VoceAcquisto Then
                            '    Using c As cContabCostiColl = New cContabCostiColl
                            '        c.Delete(IdVoce)
                            '    End Using
                            'Else

                            'qui devo prendere tutti gli ordini di quella fattura e riportarli in uscito da magazzino 
                            'e la consegna rimetterla in lavorazione


                            'End If

                            'MostraDatiOld(rdoVendita.Checked)
                            MgrDocumentiFiscali.EliminaDocumentoFiscaleVendita(R)

                            MostraDocVendita()
                        End If
                    Else
                        MessageBox.Show("La fattura è in uno stato FE non modificabile oppure ha dei pagamenti")
                    End If

                End Using
            End If
        End If

    End Sub

    Private Sub EliminaVoceAcquisto()
        Dim IdVoce As Integer = 0
        Dim R As Costo = Nothing
        If tabCosti.SelectedIndex = 0 Then
            If dgDocAcquisto.SelectedRows.Count Then
                Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
                If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                    R = riga.DataBoundItem
                    If MgrFattureFE.FatturaRicevutaModificabile(R.IdCosto) Then
                        If MessageBox.Show("ATTENZIONE! Si sta eliminando una voce di contabilità, confermi la cancellazione della voce selezionata? L'operazione non e' reversibile!", "Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                            IdVoce = R.IdCosto


                        End If
                    Else
                        MessageBox.Show("La fattura è in uno stato FE non modificabile")
                    End If

                    'End Using
                End If
            End If
        Else

        End If

        If IdVoce Then
            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                'If IdTipoVoce = enTipoVoceContab.VoceAcquisto Then
                '    Using c As cContabCostiColl = New cContabCostiColl
                '        c.Delete(IdVoce)
                '    End Using
                'Else

                'qui devo prendere tutti gli ordini di quella fattura e riportarli in uscito da magazzino 
                'e la consegna rimetterla in lavorazione
                '


                'End If

                Try
                    tb.TransactionBegin()

                    Using mgr As New CostiDAO
                        mgr.Delete(IdVoce)
                        If R.Tipo = enTipoDocumento.FatturaRiepilogativa Then mgr.DeleteRifDDT(IdVoce)
                    End Using

                    Using mgr As New MagazzinoDAO
                        mgr.DeleteByIdFat(IdVoce)
                    End Using

                    Using Mgr As New VociCostoDAO
                        Mgr.DeleteByIdCosto(IdVoce)
                    End Using

                    tb.TransactionCommit()

                Catch ex As Exception
                    tb.TransactionRollBack()
                    ManageError(ex)
                End Try

                'MostraDatiOld(rdoVendita.Checked)
                MostraDocAcquisto()
            End Using
        End If


    End Sub

    Private Sub FiltriAggiornati()

        'qui a seconda della tab selezionata lancio il mostra dati adeguato
        If tabDoc.SelectedIndex = 0 Then
            'vendita
            MostraDocVendita()
        Else
            'acquisto
            MostraDocAcquisto()
        End If

    End Sub

    Private Sub ModificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaToolStripMenuItem.Click

        ModificaVoceVendita()

        'If RigaSel <> -1 Then
        '    Dim IdVoce As Integer = CType(DgDocumenti.Rows(RigaSel).Cells(0).FormattedValue, Integer)
        '    Dim TipoVoce As Integer = CType(DgDocumenti.Rows(RigaSel).Cells(1).FormattedValue, Integer)
        '    Dim TipoDoc As Integer = CType(DgDocumenti.Rows(RigaSel).Cells(12).FormattedValue, Integer)
        '    'riapertura appuntamento
        '    ParentFormEx.Sottofondo()
        '    If TipoDoc = enTipoDocumento.FatturaRiepilogativa Then
        '        Dim appForm As New frmContabilitaFatturaRiepilogativaRicavo
        '        If appForm.Carica(IdVoce) Then MostraDocVendita(rdoVendita.Checked)
        '        ParentFormEx.Sottofondo()

        '    Else
        '        Dim appForm As New frmContabilitaRicavo
        '        If appForm.Carica(IdVoce, TipoVoce) Then MostraDocVendita(rdoVendita.Checked)
        '        ParentFormEx.Sottofondo()

        '    End If

        'End If
    End Sub

    Private Sub EliminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaToolStripMenuItem.Click

        EliminaVoceVendita()

    End Sub

    'Private Sub RigaInserita() '(ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)

    '    'Exit Sub
    '    Dim Row As DataGridViewRow '= DGRichieste.Rows(e.RowIndex)
    '    'qui il conteggio lo devo fare solo se lo stato dell'ordine non e' pagato. se cel'ho 
    '    Dim TotEuro As Decimal = 0
    '    Dim TotEuroDiff As Decimal = 0

    '    For Each Row In DgDocumenti.Rows

    '        Dim x As DataGridViewRow = Row 'DGRichieste.Rows.Item(Row.Index)
    '        Dim Incassati As Decimal = 0
    '        Dim Importi As Decimal = 0
    '        Try
    '            Dim TipoVoce As Integer = CType(x.Cells(1).FormattedValue, Integer)

    '            If x.Cells(9).Value.ToString.Length Then Importi = Math.Round(x.Cells(9).Value, 2) Else Importi = 0

    '            If x.Cells(10).Value.ToString.Length Then Incassati = Math.Round(x.Cells(10).Value, 2) Else Incassati = 0

    '            If rdoTutti.Checked Then
    '                If x.Cells(12).Value = enTipoDocumento.DDT Then
    '                    If x.Cells(14).Value.ToString.Length = 0 Then
    '                        TotEuro += Importi
    '                        TotEuroDiff += (Importi - Incassati)
    '                    End If
    '                Else
    '                    TotEuro += Importi
    '                    TotEuroDiff += (Importi - Incassati)
    '                End If
    '            Else
    '                TotEuro += Importi
    '                TotEuroDiff += (Importi - Incassati)
    '            End If

    '            'controllo se sta in fattura
    '            'Try
    '            '    If DirectCast(x.Cells(14).Value, Integer) Then

    '            '        If x.Cells(14).Value Then
    '            '            If x.Cells(14).Value Then
    '            '                'qui c'e' l'id del documento
    '            '                Dim NumFat As String
    '            '                Dim fat As New cContabRicavi
    '            '                fat.Read(x.Cells(14).Value)
    '            '                NumFat = fat.Numero

    '            '                'qui c'ho se sta in fattura, e quindi si tratta di un ddt, devo controllare se la fattura e' pagata e metterlo a verde

    '            '                If fat.PagataCompletamente Then
    '            '                    x.Cells(10).Style.BackColor = Color.Green
    '            '                    x.Cells(10).Style.SelectionBackColor = Color.Green
    '            '                End If

    '            '                fat = Nothing
    '            '                Try
    '            '                    x.Cells(13).ReadOnly = False

    '            '                    x.Cells(13).Value = NumFat
    '            '                Catch ex As Exception

    '            '                End Try

    '            '            End If
    '            '        Else
    '            '            x.Cells(13).ReadOnly = False

    '            '            x.Cells(13).Value = ""
    '            '        End If
    '            '    End If
    '            'Catch ex As Exception

    '            'End Try
    '        Catch ex As Exception

    '        End Try

    '    Next

    '    lblNumRis.Text = "Righe: " & DgDocumenti.Rows.Count
    '    lblNumEuro.Text = "Fatturato € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotEuro)
    '    lblNumDiff.Text = "Differenza € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(TotEuroDiff)

    'End Sub

    Private Sub RegistraPagamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistraPagamentoToolStripMenuItem.Click

        RegistraPagamentoVendita()

    End Sub

    Private Sub PassaAlloStatoDiConsegnatoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PassaAlloStatoDiConsegnatoToolStripMenuItem.Click

        ContrassegnaConsegnato()

    End Sub

    Private Sub ContrassegnaConsegnato()
        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As RicavoEx = riga.DataBoundItem
                    If R.Tipo = enTipoDocumento.DDT Then
                        MessageBox.Show("Non è possibile eseguire questa operazione su un DDT!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        If MessageBox.Show("Confermi il passaggio a consegnato di tutti gli ordini di questo documento?", "Consegna ordini", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                            Using doc As New cContabRicaviColl
                                doc.PassaA(R.IdRicavo, enStatoOrdine.Consegnato)
                            End Using

                            MessageBox.Show("Gli ordini sono passati allo stato di consegnato!", "Consegna ordini", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If
                    End If
                End Using
            End If
        End If



        'If DgDocumenti.SelectedRows.Count Then

        '    If IdTipoDocSel = enTipoDocumento.DDT Then
        '        MessageBox.Show("Non è possibile eseguire questa operazione su un DDT!", "Registra pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Else
        '        Dim IdDoc As Integer = DgDocumenti.SelectedRows(0).Cells(0).Value
        '        If MessageBox.Show("Confermi il passaggio a consegnato di tutti gli ordini di questo documento?", "Consegna ordini", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

        '            Dim doc As New cContabRicaviColl
        '            doc.PassaA(IdDoc, enStatoOrdine.Consegnato)
        '            MessageBox.Show("Gli ordini sono passati allo stato di consegnato!", "Consegna ordini", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '        End If
        '    End If


        'End If
    End Sub

    Private Sub SegnaComePagatoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SegnaComePagatoToolStripMenuItem.Click

        RegistraPagamentoVendita()

    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If sender.focused Then MostraDatiOld(rdoVendita.Checked)
        If sender.focused Then FiltriAggiornati()
    End Sub

    Private Sub rdoTutti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If sender.focused Then MostraDatiOld(rdoVendita.Checked)
        If sender.focused Then FiltriAggiornati()
    End Sub

    Private Sub chkOnlyNot_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOnlyNot.CheckedChanged
        'If sender.focused Then MostraDatiOld(rdoVendita.Checked)
        'If sender.focused Then FiltriAggiornati()
    End Sub
    'Private newRowNeeded As Boolean = False
    Private Sub DGRichieste_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        '  If newRowNeeded Then
        'newRowNeeded = False
        'RigaInserita(e)
        'End If

    End Sub



    Private Sub chkOnlyInCons_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOnlyInCons.CheckedChanged
        'If sender.focused Then MostraDatiOld(rdoVendita.Checked)
        'If sender.focused Then FiltriAggiornati()
    End Sub

    'Private Sub ToolStripMenuModificaDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If RigaSel <> -1 Then
    '        Dim IdVoce As Integer = CType(DgDocumenti.Rows(RigaSel).Cells(0).FormattedValue, Integer)
    '        Dim TipoVoce As Integer = CType(DgDocumenti.Rows(RigaSel).Cells(1).FormattedValue, Integer)
    '        Dim TipoDoc As Integer = CType(DgDocumenti.Rows(RigaSel).Cells(12).FormattedValue, Integer)
    '        'riapertura appuntamento
    '        ParentFormEx.Sottofondo()
    '        If TipoDoc = enTipoDocumento.FatturaRiepilogativa Then
    '            Dim appForm As New frmContabilitaFatturaRiepilogativaRicavo
    '            If appForm.Carica(IdVoce) Then MostraDatiOld(rdoVendita.Checked)
    '        Else
    '            Dim appForm As New frmContabilitaRicavo
    '            If appForm.Carica(IdVoce, TipoVoce) Then MostraDatiOld(rdoVendita.Checked)
    '        End If
    '        ParentFormEx.Sottofondo()
    '    End If
    'End Sub

    'Private Sub DGRichieste_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
    '    Dim x As DataGridViewRow = DgDocumenti.Rows.Item(e.RowIndex)
    '    Dim Incassati As Decimal = 0
    '    Dim Importi As Decimal = 0
    '    Try
    '        Dim IdVoce As Integer = CType(x.Cells(0).FormattedValue, Integer)
    '        Dim TipoVoce As Integer = CType(x.Cells(1).FormattedValue, Integer)

    '        Dim Pagato As Boolean = False

    '        x.Cells(2).Style.ForeColor = Color.White
    '        x.Cells(2).Style.SelectionForeColor = Color.White

    '        If TipoVoce = enTipoVoceContab.VoceAcquisto Then
    '            x.Cells(2).Style.BackColor = Color.Red
    '            x.Cells(2).Style.SelectionBackColor = Color.Red
    '        ElseIf TipoVoce = enTipoVoceContab.VoceVendita Then

    '            Using R As New Ricavo
    '                R.Read(IdVoce)
    '                If R.Tipo = enTipoDocumento.DDT Then
    '                    'controllo se e' stata pagata la fattura riepilogativa
    '                    If R.IdDocRif Then
    '                        Using RFat As New Ricavo
    '                            RFat.Read(R.IdDocRif)
    '                            If RFat.Stato = enStatoDocumentoFiscale.PagatoInteramente Then
    '                                Pagato = True
    '                            End If
    '                        End Using
    '                    End If
    '                End If
    '            End Using

    '            x.Cells(2).Style.BackColor = Color.Green
    '            x.Cells(2).Style.SelectionBackColor = Color.Green
    '        End If

    '        If x.Cells(9).Value.ToString.Length = 0 Then
    '            If x.Cells(7).Value Then
    '                x.Cells(9).Value = x.Cells(7).Value + x.Cells(8).Value
    '            End If
    '        End If

    '        If x.Cells(9).Value.ToString.Length Then Importi = Math.Round(x.Cells(9).Value, 2) Else Importi = 0

    '        If x.Cells(10).Value.ToString.Length Then Incassati = Math.Round(x.Cells(10).Value, 2) Else Incassati = 0

    '        If Pagato Then
    '            x.Cells(10).Style.BackColor = Color.Green
    '            x.Cells(10).Style.SelectionBackColor = Color.Green
    '        Else
    '            If Importi Then
    '                If Importi > Incassati Then
    '                    x.Cells(10).Style.BackColor = Color.Red
    '                    x.Cells(10).Style.SelectionBackColor = Color.Red
    '                ElseIf Importi <= Incassati Then
    '                    x.Cells(10).Style.BackColor = Color.Green
    '                    x.Cells(10).Style.SelectionBackColor = Color.Green
    '                End If
    '            End If
    '        End If

    '        Dim StatoIncasso As Integer = x.Cells(18).Value

    '        x.Cells(17).Style.BackColor = FormerColori.GetColoreStatoIncasso(StatoIncasso)
    '        x.Cells(17).Style.SelectionBackColor = FormerColori.GetColoreStatoIncasso(StatoIncasso)

    '        'controllo se sta in fattura
    '        'Try
    '        '    If DirectCast(x.Cells(14).Value, Integer) Then

    '        '        If x.Cells(14).Value Then
    '        '            If x.Cells(14).Value Then
    '        '                'qui c'e' l'id del documento
    '        '                Dim NumFat As String
    '        '                Dim fat As New cContabRicavi
    '        '                fat.Read(x.Cells(14).Value)
    '        '                NumFat = fat.Numero

    '        '                'qui c'ho se sta in fattura, e quindi si tratta di un ddt, devo controllare se la fattura e' pagata e metterlo a verde

    '        '                If fat.PagataCompletamente Then
    '        '                    x.Cells(10).Style.BackColor = Color.Green
    '        '                    x.Cells(10).Style.SelectionBackColor = Color.Green
    '        '                End If

    '        '                fat = Nothing
    '        '                Try
    '        '                    x.Cells(13).ReadOnly = False

    '        '                    x.Cells(13).Value = NumFat
    '        '                Catch ex As Exception

    '        '                End Try

    '        '            End If
    '        '        Else
    '        '            x.Cells(13).ReadOnly = False

    '        '            x.Cells(13).Value = ""
    '        '        End If
    '        '    End If
    '        'Catch ex As Exception

    '        'End Try
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub DgDocumenti_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub NormaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormaleToolStripMenuItem.Click

        SetStatoIncasso(enStatoIncasso.Normale)

    End Sub

    Private Sub SetStatoIncasso(Stato As enStatoIncasso)

        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As RicavoEx = riga.DataBoundItem
                    Dim Ris As Integer = MgrDocumentiFiscali.SetStatoIncasso(R.IdRicavo, Stato)
                    If Ris Then MostraDocVendita()
                End Using
            End If
        End If

        'If IdDocSel Then

        '    Dim Ris As Integer = MgrDocumentiFiscali.SetStatoIncasso(IdDocSel, Stato)
        '    If Ris Then MostraDatiOld(rdoVendita.Checked)

        '    'If IdTipoDocSel = enTipoVoceContab.VoceVendita Then
        '    '    If MessageBox.Show("Confermi il cambio stato di incasso a " & FormerEnumHelper.GetStatoIncassoStr(Stato).ToUpper & " per il documento selezionato?", "Stato Incasso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '    '        'qui devo salvare il passaggio di stato con delle eventuali note 
        '    '        Using R As New Ricavo
        '    '            R.Read(IdDocSel)

        '    '            If R.Stato <> enStatoDocumentoFiscale.PagatoInteramente Then
        '    '                If R.StatoIncasso <> Stato Then

        '    '                    Dim Ris As Integer = 0
        '    '                    Dim Buffer As String = String.Empty
        '    '                    ParentFormEx.Sottofondo()
        '    '                    Using f As New frmTextGet
        '    '                        Ris = f.Carica("Inserisci se vuoi una annotazione riguardante il cambio di stato di incasso di questo documento", Buffer)
        '    '                    End Using
        '    '                    ParentFormEx.Sottofondo()

        '    '                    If Ris Then

        '    '                        R.StatoIncasso = Stato
        '    '                        R.Save()

        '    '                        Using lR As New LogRicavo
        '    '                            lR.IdRicavo = IdDocSel
        '    '                            lR.IdOperatore = PostazioneCorrente.UtenteConnesso.IdUt
        '    '                            lR.Quando = Now
        '    '                            lR.Annotazioni = Buffer
        '    '                            lR.StatoIncasso = Stato
        '    '                            lR.Save()
        '    '                        End Using

        '    '                        For Each O As Ordine In R.ListaOrdini

        '    '                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "Il documento fiscale in cui l'ordine è contenuto ha cambiato stato di incasso a " & FormerEnumHelper.GetStatoIncassoStr(Stato).ToUpper)

        '    '                        Next

        '    '                        MostraDati(rdoEntrata.Checked)

        '    '                    End If
        '    '                Else
        '    '                    MessageBox.Show("Il documento fiscale risulta interamente pagato")
        '    '                End If

        '    '            Else
        '    '                MessageBox.Show("Il documento selezionato è gia nello stato di incasso " & FormerEnumHelper.GetStatoIncassoStr(Stato).ToUpper)
        '    '            End If

        '    '        End Using

        '    '    End If
        '    'Else
        '    '    MessageBox.Show("Lo stato di incasso si può impostare solo per i documenti di vendita")
        '    'End If
        'End If
    End Sub

    Private Sub ProblematicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProblematicoToolStripMenuItem.Click
        SetStatoIncasso(enStatoIncasso.Problematico)
    End Sub

    Private Sub DifficileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DifficileToolStripMenuItem.Click
        SetStatoIncasso(enStatoIncasso.Difficile)
    End Sub

    Private Sub ImpossibileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpossibileToolStripMenuItem.Click
        SetStatoIncasso(enStatoIncasso.Impossibile)
    End Sub

    Private Sub EmettiFatturaRiepilogativaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmettiFatturaRiepilogativaToolStripMenuItem.Click

        EmettiFatturaRiepilogativaByDoc()

    End Sub

    Private Sub EmettiFatturaRiepilogativaByDoc()


        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As RicavoEx = riga.DataBoundItem
                    If R.Tipo = enTipoDocumento.DDT Then
                        ParentFormEx.Sottofondo()
                        Using x As New frmContabilitaFatturaRiepilogativaRicavo
                            x.Carica(, R.IdRicavo)
                        End Using
                        ParentFormEx.Sottofondo()
                    Else
                        MessageBox.Show("Selezionare un DDT")
                    End If
                End Using
            End If
        End If

    End Sub

    Private Sub RiapriConsegnaProgrammata()
        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As RicavoEx = riga.DataBoundItem

                    ParentFormEx.Sottofondo()
                    Using x As New frmConsegnaProgrammata
                        x.Carica(R.IdConsegnaRif)
                    End Using
                    ParentFormEx.Sottofondo()

                End Using
            End If
        End If
    End Sub

    Private Sub MostraDocumentiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostraDocumentiToolStripMenuItem.Click

        'MostraDatiOld(rdoVendita.Checked)


    End Sub

    Private Sub StampaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StampaToolStripMenuItem.Click



    End Sub

    Private Sub ControllaErroriNumerazioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControllaErroriNumerazioneToolStripMenuItem.Click

        If MgrDocumentiFiscali.CheckNumeroDocumentiFiscali.Errori = False Then
            MessageBox.Show("Nessun errore rilevato nella numerazione dei documenti fiscali")
        End If

    End Sub

    Private Sub dgDocVendita_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgDocVendita.CellFormatting

        If FormerDebug.LightMode = False Then
            Dim Riga As GridViewRowInfo = e.Row

            If Not Riga Is Nothing AndAlso Not Riga.DataBoundItem Is Nothing Then
                Using o As RicavoEx = Riga.DataBoundItem
                    If e.CellElement.ColumnInfo.Name = "Tipo" Then
                        e.CellElement.BackColor = Color.FromArgb(0, 192, 0)
                        e.CellElement.ForeColor = Color.White
                    ElseIf e.CellElement.ColumnInfo.Name = "Incassati" Then
                        If o.PagatoInteramente Then
                            e.CellElement.BackColor = Color.FromArgb(0, 192, 0)
                        Else
                            e.CellElement.BackColor = Color.FromArgb(234, 2, 24)
                        End If
                        'If o.TotaleAncoraDaPagare > 0 Then
                        '    e.CellElement.BackColor = Color.FromArgb(234, 2, 24)
                        'Else
                        '    e.CellElement.BackColor = Color.FromArgb(0, 192, 0)
                        'End If
                        e.CellElement.ForeColor = Color.White
                    ElseIf e.CellElement.ColumnInfo.Name = "StatoIncasso" Then
                        e.CellElement.BackColor = FormerColori.GetColoreStatoIncasso(o.StatoIncasso)

                    Else
                        e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                        e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                    End If
                End Using
            End If
        End If



    End Sub

    Private Sub dgDocVendita_Click(sender As Object, e As EventArgs) Handles dgDocVendita.Click

    End Sub

    Private Sub dgDocVendita_MouseClick(sender As Object, e As MouseEventArgs) Handles dgDocVendita.MouseClick

        dgDocVendita.Select()

        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If e.Button = Windows.Forms.MouseButtons.Right Then

                Dim x As System.Drawing.Point = MousePosition
                'btnNuovoCliente.ContextMenu = menuNuovo.
                x = MousePosition
                'x = lnkNew.PointToClient(x)

                menuVoceVendita.Show(x)

            End If

        End If

    End Sub

    Private Sub EmettiFatturaRiepilogativaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EmettiFatturaRiepilogativaToolStripMenuItem1.Click
        EmettiFatturaRiepilogativa()
    End Sub

    Private Sub EmettiFatturaRiepilogativa()
        ParentFormEx.Sottofondo()
        Using x As New frmContabilitaFatturaRiepilogativaRicavo
            If x.Carica() Then
                MostraDocVendita()
            End If
        End Using
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub StrumentiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StrumentiToolStripMenuItem.Click

    End Sub

    Private Sub StrumentiToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles StrumentiToolStripMenuItem.DropDownOpened, AcquistoToolStripMenuItem.DropDownOpened
        'sender.ForeColor = Color.Black
    End Sub

    Private Sub StrumentiToolStripMenuItem_DropDownClosed(sender As Object, e As EventArgs) Handles StrumentiToolStripMenuItem.DropDownClosed, AcquistoToolStripMenuItem.DropDownClosed
        'sender.ForeColor = Color.White
    End Sub

    Private Sub RiapriVoceAcquisto()

        If dgDocAcquisto.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then

                If TypeOf riga.DataBoundItem Is Costo Then
                    Using R As Costo = riga.DataBoundItem
                        ParentFormEx.Sottofondo()
                        If R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                            Using appForm As New frmContabilitaFatturaRiepilogativaCosto
                                If appForm.Carica(R.IdCosto) Then
                                    R.Refresh()
                                    DirectCast(dgDocAcquisto.DataSource, BindingSource).ResetBindings(False)
                                    'MostraDocAcquisto()
                                End If
                            End Using
                        Else
                            Using appForm As New frmContabilitaCosto
                                If appForm.Carica(R.IdCosto, _IdRub) Then
                                    R.Refresh()
                                    DirectCast(dgDocAcquisto.DataSource, BindingSource).ResetBindings(False)
                                    'MostraDocAcquisto()
                                End If
                            End Using
                        End If
                        ParentFormEx.Sottofondo()
                    End Using

                End If
            End If
        End If

    End Sub

    Private Sub RiapriVoceVendita()

        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As RicavoEx = riga.DataBoundItem
                    ParentFormEx.Sottofondo()
                    If R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                        Using appForm As New frmContabilitaFatturaRiepilogativaRicavo
                            If appForm.Carica(R.IdRicavo) Then
                                R.Refresh()
                                DirectCast(dgDocVendita.DataSource, BindingSource).ResetBindings(False)
                                'MostraDocVendita()
                            End If
                        End Using
                    ElseIf R.Tipo = enTipoDocumento.NotaDiCredito Then
                        Using appForm As New frmContabilitaNotaCredito
                            If appForm.Carica(R.IdRicavo) Then
                                R.Refresh()
                                DirectCast(dgDocVendita.DataSource, BindingSource).ResetBindings(False)
                                'MostraDocVendita()
                            End If
                        End Using
                    Else
                        Using appForm As New frmContabilitaRicavo
                            If appForm.Carica(R.IdRicavo, _IdRub) Then MostraDocVendita()
                        End Using
                    End If
                    ParentFormEx.Sottofondo()
                End Using
            End If
        End If

    End Sub

    Private Sub dgDocAcquisto_DoubleClick(sender As Object, e As EventArgs) Handles dgDocAcquisto.DoubleClick
        'ModificaVoceAcquisto()


    End Sub

    Private Sub dgDocVendita_DoubleClick(sender As Object, e As EventArgs) Handles dgDocVendita.DoubleClick
        'ModificaVoceVendita()


    End Sub

    Private Sub chkSoloNonStampati_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloNonStampati.CheckedChanged

    End Sub

    Private Sub AcquistoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcquistoToolStripMenuItem.Click

    End Sub

    Private Sub EmettiPreventivoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        RegistraDoc(enTipoDocumento.Preventivo)
    End Sub

    Private Sub EmettiDDTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmettiDDTToolStripMenuItem.Click
        RegistraDoc(enTipoDocumento.DDT)
    End Sub

    Private Sub EmettiFatturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmettiFatturaToolStripMenuItem.Click
        RegistraDoc(enTipoDocumento.Fattura)
    End Sub

    Private Sub RegistraFatturaRiepilogativaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistraFatturaRiepilogativaToolStripMenuItem.Click
        RegistraDoc(enTipoDocumento.FatturaRiepilogativa)
    End Sub

    Private Sub StampaDocAcquistoToolStripItem_Click(sender As Object, e As EventArgs) Handles StampaDocAcquistoToolStripItem.Click

        ParentFormEx.Sottofondo()
        StampaGlobale("Movimenti contabili", dgDocAcquisto)
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub RegistraDoc(ByVal TipoDoc As enTipoDocumento)

        Dim Continuare As Boolean = True

        If MessageBox.Show("L'inserimento di documenti fiscali di acquisto avviene in automatico tramite fattura elettronica. Si vuole comunque proseguire con un inserimento manuale?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Continuare = False
        End If

        If Continuare Then
            ParentFormEx.Sottofondo()

            If TipoDoc <> enTipoDocumento.FatturaRiepilogativa Then
                Using f As New frmContabilitaCosto
                    f.Carica(,, TipoDoc)
                End Using
            Else
                Dim f As New frmContabilitaFatturaRiepilogativaCosto
                Dim IdCosto As Integer = f.Carica()

                If IdCosto Then
                    f.Dispose()
                    f = New frmContabilitaFatturaRiepilogativaCosto
                    f.Carica(IdCosto)
                    f.Dispose()
                End If

            End If

            ParentFormEx.Sottofondo()
        End If


        'If TipoDoc <> enTipoDocumento.FatturaRiepilogativa Then
        '    Dim x As New frmContabilitaEmissioneDocumenti
        '    If x.Carica(TipoDoc) Then
        '        'ParentFormerForm.Sottofondo 
        '        'UcContab.MostraDati(UcContab.rdoEntrata.Checked)
        '        'Else
        '        '   ParentFormerForm.Sottofondo 
        '    End If
        '    x = Nothing
        'Else
        '    Dim x As New frmContabilitaFatturaRiepilogativaRicavo
        '    If x.Carica() Then

        '        'UcContab.MostraDati(UcContab.rdoEntrata.Checked)
        '        'Else
        '        'ParentFormerForm.Sottofondo 
        '    End If

        '    x = Nothing
        'End If
        'ParentFormEx.Sottofondo()
    End Sub

    Private Sub MostraDocAcquistoToolStripitem_Click(sender As Object, e As EventArgs) Handles MostraDocAcquistoToolStripitem.Click



    End Sub

    Private Sub dgDocAcquisto_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgDocAcquisto.CellFormatting

        If FormerDebug.LightMode = False Then
            Dim Riga As GridViewRowInfo = e.Row

            If Not Riga Is Nothing AndAlso Not Riga.DataBoundItem Is Nothing Then

                If e.CellElement.ColumnInfo.Name = "Tipo" Then
                    e.CellElement.BackColor = Color.FromArgb(234, 2, 24)
                    e.CellElement.ForeColor = Color.White
                ElseIf e.CellElement.ColumnInfo.Name = "Pagato" Then
                    Dim Voce As Costo = e.Row.DataBoundItem
                    If Voce.PagatoStr = "SI" Then
                        e.CellElement.BackColor = Color.Green
                        e.CellElement.ForeColor = Color.White
                    ElseIf Voce.PagatoStr <> "-" Then
                        e.CellElement.BackColor = Color.FromArgb(234, 2, 24)
                        e.CellElement.ForeColor = Color.White
                    Else
                        e.CellElement.BackColor = Color.White
                        e.CellElement.ForeColor = Color.Black
                    End If
                Else
                    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                End If
            End If
        End If

    End Sub

    Private Sub mnuAcquistoElimina_Click(sender As Object, e As EventArgs) Handles mnuAcquistoElimina.Click
        EliminaVoceAcquisto()
    End Sub

    Private Sub mnuAcquistoModifica_Click(sender As Object, e As EventArgs) Handles mnuAcquistoModifica.Click
        ModificaVoceAcquisto()
    End Sub

    Private Sub mnuAcquistoRegistraPagamento_Click(sender As Object, e As EventArgs) Handles mnuAcquistoRegistraPagamento.Click
        RegistraPagamentoAcquisto()
    End Sub

    Private Sub dgDocAcquisto_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgDocAcquisto.ViewCellFormatting

        If TypeOf e.CellElement Is GridGroupExpanderCellElement Then
            Dim Cell As GridGroupExpanderCellElement = e.CellElement
            If Not Cell Is Nothing Then
                If Not e.CellElement.RowInfo.ChildRows Is Nothing AndAlso e.CellElement.RowInfo.ChildRows.Count Then
                    Cell.Expander.Visibility = Telerik.WinControls.ElementVisibility.Visible
                    If Not e.Row.DataBoundItem Is Nothing Then
                        Cell.TextAlignment = ContentAlignment.TopRight
                        Dim f As New Font("Segoe UI", 7, FontStyle.Bold)
                        Cell.Font = f
                        Cell.ForeColor = Color.FromArgb(14, 151, 221)
                        Cell.Text = e.CellElement.RowInfo.ChildRows.Count

                    End If

                Else
                    Cell.Expander.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                End If
            End If
            Cell.RowInfo.Height = 35
        End If
    End Sub

    Private Sub dgDocVendita_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgDocVendita.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            RiapriVoceVendita()
        End If
    End Sub

    Private Sub dgDocAcquisto_MouseClick(sender As Object, e As MouseEventArgs) Handles dgDocAcquisto.MouseClick

        dgDocAcquisto.Select()

        If dgDocAcquisto.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
            If e.Button = Windows.Forms.MouseButtons.Right Then

                Dim x As System.Drawing.Point = MousePosition
                'btnNuovoCliente.ContextMenu = menuNuovo.
                x = MousePosition
                'x = lnkNew.PointToClient(x)

                menuVoceAcquisto.Show(x)

            End If

        End If
    End Sub

    Private Sub dgDocAcquisto_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgDocAcquisto.MouseDoubleClick
        ModificaVoceAcquisto()
    End Sub

    Private Sub cmbAnnoRif_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnnoRif.SelectedIndexChanged
        'If sender.focused Then FiltriAggiornati()
    End Sub

    Private Sub cmbMese_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMese.SelectedIndexChanged
        'If sender.focused Then FiltriAggiornati()
    End Sub

    Private Sub tabDoc_TabIndexChanged(sender As Object, e As EventArgs) Handles tabDoc.TabIndexChanged

    End Sub

    Private Sub tabDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabDoc.SelectedIndexChanged
        'CaricaCli()
    End Sub

    Private Sub TrasformaInFatturaRiepilogativaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        TrasformaInRiepilogativa()
    End Sub

    Private Sub TrasformaInRiepilogativa()
        Exit Sub
        If dgDocAcquisto.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                Using R As Costo = riga.DataBoundItem
                    'ParentFormEx.Sottofondo()
                    If MgrFattureFE.FatturaRicevutaModificabile(R.IdCosto) Then
                        If R.Tipo = enTipoDocumento.Fattura Then
                            If R.ListaDettaglio.Count Then
                                MessageBox.Show("Solo le fatture che non hanno dettagli di movimentazione magazzino si possono trasformare")
                            Else
                                If MessageBox.Show("Confermi la trasformazione della fattura in fattura riepilogativa?", "Trasformazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                    Dim appForm As New frmContabilitaFatturaRiepilogativaCosto

                                    If appForm.Carica(R.IdCosto, True) Then
                                        appForm.Dispose()
                                        appForm = New frmContabilitaFatturaRiepilogativaCosto
                                        appForm.Carica(R.IdCosto)
                                        MostraDocAcquisto()
                                    End If
                                    appForm.Dispose()

                                End If
                            End If
                            'If R.vocifat Then
                            'End If
                        ElseIf R.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                            If MessageBox.Show("Confermi la ricreazione della fattura riepilogativa?", "Trasformazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                                'qui sgancio i ddt 
                                Using mgr As New CostiDAO
                                    mgr.DeleteRifDDT(R.IdCosto)
                                End Using

                                'e riapro la fattura
                                Dim appForm As New frmContabilitaFatturaRiepilogativaCosto

                                If appForm.Carica(R.IdCosto, True) Then
                                    appForm.Dispose()
                                    appForm = New frmContabilitaFatturaRiepilogativaCosto
                                    appForm.Carica(R.IdCosto)
                                    MostraDocAcquisto()
                                End If
                                appForm.Dispose()

                            End If
                        Else
                            MessageBox.Show("Solo le fatture si possono trasformare in fatture riepilogative!")
                        End If
                    Else
                        MessageBox.Show("La fattura è in uno stato FE non modificabile")
                    End If

                    'ParentFormEx.Sottofondo()
                End Using
            End If
        End If

    End Sub

    Private Sub dgDocVendita_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgDocVendita.ViewCellFormatting
        If TypeOf e.CellElement Is GridDataCellElement Then
            Dim Cell As GridDataCellElement = e.CellElement
            Cell.RowInfo.Height = 35
        End If
    End Sub

    Private Sub FiltraConQuestoClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltraConQuestoClienteToolStripMenuItem.Click

        FiltraConQuestoCliente()
        MostraDocVendita()

    End Sub

    Private Sub FiltraConQuestoRivenditoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltraConQuestoRivenditoreToolStripMenuItem.Click
        FiltraConQuestoRivenditore()
        MostraDocAcquisto()
    End Sub

    Private Sub FormerSncToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormerSncToolStripMenuItem.Click
        FormerSrlToolStripMenuItem.Checked = False
        FormerSncToolStripMenuItem.Checked = True
        MostraDocVendita()
    End Sub

    Private Sub FormerSrlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormerSrlToolStripMenuItem.Click
        FormerSncToolStripMenuItem.Checked = False
        FormerSrlToolStripMenuItem.Checked = True
        MostraDocVendita()
    End Sub

    Private Sub TuttoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TuttoToolStripMenuItem.Click
        FormerSrlToolStripMenuItem.Checked = False
        FormerSncToolStripMenuItem.Checked = False
        MostraDocVendita()
    End Sub

    Private Sub TuttoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TuttoToolStripMenuItem1.Click
        FormerSrlToolStripMenuItem1.Checked = False
        FormerSncToolStripMenuItem1.Checked = False
        MostraDocAcquisto()
    End Sub

    Private Sub FormerSncToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FormerSncToolStripMenuItem1.Click
        FormerSrlToolStripMenuItem1.Checked = False
        FormerSncToolStripMenuItem1.Checked = True
        MostraDocAcquisto()
    End Sub

    Private Sub FormerSrlToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FormerSrlToolStripMenuItem1.Click
        FormerSncToolStripMenuItem1.Checked = False
        FormerSrlToolStripMenuItem1.Checked = True
        MostraDocAcquisto()
    End Sub

    Private Sub DaInviareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaInviareToolStripMenuItem.Click
        'MostraDocVendita(enStatoFatturaFE.DaInviare)
    End Sub

    Private Sub InCodaPerInvioXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InCodaPerInvioXMLToolStripMenuItem.Click
        'MostraDocVendita(enStatoFatturaFE.InCodaInvio)
    End Sub

    Private Sub ScartatiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScartatiToolStripMenuItem.Click
        'MostraDocVendita(enStatoFatturaFE.ScartataSDI)
    End Sub

    Private Sub RegistratiAutomaticamenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistratiAutomaticamenteToolStripMenuItem.Click
        MostraDocAcquisto(enStatoDocumentoFiscale.RegistratoAutomaticamente)
    End Sub

    Private Sub cmbTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDocumento.SelectedIndexChanged
        'If sender.focused Then FiltriAggiornati()
    End Sub

    Private Sub cmbStatoFE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatoFE.SelectedIndexChanged
        'If sender.focused Then FiltriAggiornati()
    End Sub

    Private Sub cmbStatoIncasso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatoIncasso.SelectedIndexChanged
        'If sender.focused Then FiltriAggiornati()
    End Sub

    Private Sub cmbTipoPagamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPagamento.SelectedIndexChanged
        'If sender.focused Then FiltriAggiornati()
    End Sub

    Private Sub UcComboCliente_Load(sender As Object, e As EventArgs) Handles UcComboCliente.Load

    End Sub

    Private Sub UcComboCliente_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles UcComboCliente.SelectedIndexChanged

    End Sub

    Public Sub ResetFiltri()
        cmbAnnoRif.SelectedIndex = 0
        cmbMese.SelectedIndex = 0
        cmbCategoria.SelectedIndex = 0
        UcComboCliente.Reset()
    End Sub

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked
        FiltriAggiornati()
    End Sub

    Private Sub lnkReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkReset.LinkClicked
        ResetFiltri()
    End Sub

    Private Sub dgDocAcquisto_Click(sender As Object, e As EventArgs) Handles dgDocAcquisto.Click

    End Sub

    Private Sub CollecaConDocumentoDiCaricoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CollegaConDocumentoDiCaricoToolStripMenuItem.Click
        CollegaConDocumento()
    End Sub

    Private Sub AssociaRigaAMovimento()
        If tabCosti.SelectedIndex = 0 Then
            If dgDocAcquisto.SelectedRows.Count Then
                Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
                If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                    If TypeOf (riga.DataBoundItem) Is VoceCosto Then
                        Dim rigafattura As VoceCosto = riga.DataBoundItem
                        If rigafattura.IdMovMagaz = 0 Then
                            Using mgr As New VociCostoDAO
                                If mgr.ValutareRigaFatturaComeRisorsa(rigafattura) Then
                                    'qui posso associare la riga con un movimento di magazzino nuovo ovviamente 
                                    ParentFormEx.Sottofondo()
                                    Dim RisAss As Integer = 0
                                    Using f As New frmMagazzinoCarico
                                        f.IDForn = rigafattura.CostoRiferimento.IdRub
                                        RisAss = f.Carica(,, enTipoMovMagaz.Carico, rigafattura.IdCosto,, rigafattura.IdVoceCosto)
                                    End Using
                                    ParentFormEx.Sottofondo()

                                    If RisAss Then
                                        rigafattura.Read(rigafattura.IdVoceCosto)
                                        DirectCast(dgDocAcquisto.DataSource, BindingSource).ResetBindings(False)

                                        dgDocAcquisto.Refresh()
                                    End If
                                Else
                                    MessageBox.Show("La riga selezionata non è associabile a un movimento di magazzino")
                                End If
                            End Using

                        Else
                            ParentFormEx.Sottofondo()
                            Dim RisAss As Integer = 0
                            Using f As New frmMagazzinoCarico
                                f.IDForn = rigafattura.CostoRiferimento.IdRub
                                If Not rigafattura.MovMagazzino Is Nothing Then
                                    f.IdRis = rigafattura.MovMagazzino.IdRis
                                End If
                                RisAss = f.Carica(rigafattura.IdMovMagaz,, enTipoMovMagaz.Carico, rigafattura.IdCosto,, rigafattura.IdVoceCosto)
                            End Using
                            ParentFormEx.Sottofondo()

                            If RisAss Then
                                rigafattura.Read(rigafattura.IdVoceCosto)
                                DirectCast(dgDocAcquisto.DataSource, BindingSource).ResetBindings(False)

                                dgDocAcquisto.Refresh()
                            End If

                            'MessageBox.Show("Selezionare una riga fattura da associare a un movimento di magazzino")
                        End If
                    Else
                        MessageBox.Show("Selezionare una riga fattura da associare a un movimento di magazzino")
                    End If

                End If

            Else
                MessageBox.Show("Selezionare una riga fattura da associare a un movimento di magazzino")
            End If
        Else
            MessageBox.Show("Funzionalità non disponibile in questo tipo di visualizzazione")
        End If


    End Sub

    Private Sub CollegaConDocumento()
        Dim Ris As Integer = 0
        Dim IdCosto As Integer = 0
        If tabCosti.SelectedIndex = 0 Then
            If dgDocAcquisto.SelectedRows.Count Then
                Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
                If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                    If TypeOf (riga.DataBoundItem) Is Costo Then
                        Using R As Costo = riga.DataBoundItem
                            If R.IdCat = FormerConst.CategorieContabili.MateriePrime AndAlso
                                (R.Tipo = enTipoDocumento.DDT OrElse R.Tipo = enTipoDocumento.Fattura) Then
                                IdCosto = R.IdCosto
                            End If
                        End Using
                    ElseIf TypeOf (riga.DataBoundItem) Is VoceCosto Then
                        Using VC As VoceCosto = riga.DataBoundItem

                            If VC.CostoRiferimento.IdCat = FormerConst.CategorieContabili.MateriePrime AndAlso
                                (VC.CostoRiferimento.Tipo = enTipoDocumento.DDT OrElse VC.CostoRiferimento.Tipo = enTipoDocumento.Fattura) Then
                                IdCosto = VC.IdCosto
                            End If

                        End Using

                    End If

                End If
            End If
        Else
            If Not tvwFattureAcquisto.SelectedNode Is Nothing AndAlso
                            tvwFattureAcquisto.SelectedNode.Name.StartsWith("C") Then

                Using R As Costo = tvwFattureAcquisto.SelectedNode.Tag
                    If R.IdCat = FormerConst.CategorieContabili.MateriePrime AndAlso
                                (R.Tipo = enTipoDocumento.DDT OrElse R.Tipo = enTipoDocumento.Fattura) Then
                        IdCosto = R.IdCosto
                    End If
                End Using

            End If
        End If

        If IdCosto Then

            ParentFormEx.Sottofondo()

            Using f As New frmMagazzinoCaricoDiMagazzinoScegli
                Ris = f.Carica(IdCosto)
            End Using

            ParentFormEx.Sottofondo()

        Else
            MessageBox.Show("Si possono collegare solo FATTURE NON RIEPILOGATIVE o DDT relativi all'acquisto di MATERIE PRIME, modificare la categoria del fornitore.")
        End If

        If Ris Then
            FiltriAggiornati()
        End If
    End Sub

    Private Sub ApriLaSchedaDelFornitoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriLaSchedaDelFornitoreToolStripMenuItem.Click

        If tabCosti.SelectedIndex = 0 Then
            If dgDocAcquisto.SelectedRows.Count Then
                Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
                If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                    ParentFormEx.Sottofondo()
                    Using R As Costo = riga.DataBoundItem
                        Using f As New frmVoceRubrica
                            f.Carica(R.IdRub)
                        End Using
                    End Using
                    ParentFormEx.Sottofondo()

                End If
            End If
        Else
            If Not tvwFattureAcquisto.SelectedNode Is Nothing AndAlso
                tvwFattureAcquisto.SelectedNode.Name.StartsWith("C") Then

                Using R As Costo = tvwFattureAcquisto.SelectedNode.Tag
                    ParentFormEx.Sottofondo()
                    'Using R As Costo = riga.DataBoundItem
                    Using f As New frmVoceRubrica
                        f.Carica(R.IdRub)
                    End Using
                    'End Using
                    ParentFormEx.Sottofondo()
                End Using

            End If
        End If


    End Sub

    Private Sub ApriLaSchedaDelClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriLaSchedaDelClienteToolStripMenuItem.Click
        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                ParentFormEx.Sottofondo()
                Using R As Ricavo = riga.DataBoundItem
                    Using f As New frmVoceRubrica
                        f.Carica(R.IdRub)
                    End Using
                End Using
                ParentFormEx.Sottofondo()

            End If
        End If
    End Sub

    Private Sub RiapriConsegnaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RiapriConsegnaToolStripMenuItem.Click
        RiapriConsegnaProgrammata()
    End Sub

    Private Sub StampaMassivaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StampaMassivaToolStripMenuItem.Click

        StampaMassivaRicevuti()

    End Sub

    Private Sub StampaMassivaRicevuti()
        Dim ListaCosti As New List(Of Costo)
        For Each row In dgDocAcquisto.Rows
            Dim C As Costo = row.DataBoundItem
            If C.Tipo <> enTipoDocumento.DDT AndAlso C.DocXML.Length Then
                ListaCosti.Add(C)
            End If
        Next

        If ListaCosti.Count Then
            ListaCosti.Sort(AddressOf FormerListSorter.CostiSorter.SortDefault)

            ParentFormEx.Sottofondo()
            Using f As New frmStampaMassivaCosti
                f.Carica(ListaCosti)
            End Using
            ParentFormEx.Sottofondo()
        Else
            MessageBox.Show("Selezionare dei documenti ricevuti")
        End If

    End Sub

    Private Sub StampaMassivaEmessi()
        Dim ListaRicavi As New List(Of Ricavo)
        For Each row In dgDocVendita.Rows
            Dim R As Ricavo = row.DataBoundItem
            If R.Tipo <> enTipoDocumento.DDT AndAlso R.DocXML.Length Then
                ListaRicavi.Add(R)
            End If
        Next

        If ListaRicavi.Count Then
            ListaRicavi.Sort(AddressOf FormerListSorter.RicaviSorter.SortDefault)

            ParentFormEx.Sottofondo()
            Using f As New frmStampaMassivaRicavi
                f.Carica(ListaRicavi)
            End Using
            ParentFormEx.Sottofondo()
        Else
            MessageBox.Show("Selezionare dei documenti emessi")
        End If

    End Sub

    Private Sub EmettiNotaDiCreditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmettiNotaDiCreditoToolStripMenuItem.Click
        EmettiNotaDiCredito()
    End Sub

    Private Sub PctRefreshStatoFE_Click(sender As Object, e As EventArgs) Handles pctRefreshStatoFE.Click
        CaricaComboStatoFE()
    End Sub

    Private Sub SelezioneCorrenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelezioneCorrenteToolStripMenuItem.Click
        ParentFormEx.Sottofondo()
        StampaGlobale("Movimenti contabili", dgDocVendita)
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub RiepilogoConteggiMensiliToolStripMenuItem_Click_1(sender As Object, e As EventArgs)


    End Sub

    Private Sub FlussiMensiliToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ReportDocumentiEmessiEIncassatiMensiliToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AssociaAMovimentoDiMagazzinoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssociaAMovimentoDiMagazzinoToolStripMenuItem.Click
        AssociaRigaAMovimento()
    End Sub

    Private Sub ToolstripStampaMassivaEmessi_Click(sender As Object, e As EventArgs) Handles toolstripStampaMassivaEmessi.Click
        StampaMassivaEmessi()
    End Sub

    Private Sub tvwFattureAcquisto_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwFattureAcquisto.NodeMouseClick

        If e.Node.Name.StartsWith("C") Then
            UcDocumentiFiscaliXMLCosto.Carica(e.Node.Tag)
        End If

    End Sub

    Private Sub tvwFattureAcquisto_MouseClick(sender As Object, e As MouseEventArgs) Handles tvwFattureAcquisto.MouseClick

        If Not tvwFattureAcquisto.SelectedNode Is Nothing Then
            'Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
            If e.Button = Windows.Forms.MouseButtons.Right Then

                Dim x As System.Drawing.Point = MousePosition
                'btnNuovoCliente.ContextMenu = menuNuovo.
                x = MousePosition
                'x = lnkNew.PointToClient(x)

                menuVoceAcquisto.Show(x)

            End If

        End If
    End Sub

    Private Sub AggiornaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggiornaToolStripMenuItem.Click
        MostraDocAcquisto()
    End Sub

    Private Sub BilancioAziendaleToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged

    End Sub

    Private Sub EscludiDalleVociDaPrendereInConsiderazioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EscludiDalleVociDaPrendereInConsiderazioneToolStripMenuItem.Click
        EscludiDaVoceCosto()
    End Sub

    Private Sub EscludiDaVoceCosto()

        If tabCosti.SelectedIndex = 0 Then
            If dgDocAcquisto.SelectedRows.Count Then
                Dim riga As GridViewRowInfo = dgDocAcquisto.SelectedRows(0)
                If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then
                    If TypeOf (riga.DataBoundItem) Is VoceCosto Then
                        Dim rigafattura As VoceCosto = riga.DataBoundItem

                        If MessageBox.Show("Confermi di voler escludere '" & rigafattura.Descrizione & "' per questo fornitore dalle righe da valutare come risorsa?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                            Using mgr As New DecodificaVociCostoDAO
                                Dim l As List(Of DecodificaVoceCosto) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.DecodificaVoceCosto.TextToSearch, rigafattura.Descrizione),
                                                                                    New LUNA.LunaSearchParameter(LFM.DecodificaVoceCosto.IdFornitore, rigafattura.CostoRiferimento.IdRub))
                                If l.Count = 0 Then
                                    Using nD As New DecodificaVoceCosto
                                        nD.IdFornitore = rigafattura.CostoRiferimento.IdRub
                                        nD.TextToSearch = rigafattura.Descrizione
                                        nD.TipoDecodifica = enTipoDecodificaVoceCosto.Esclusione
                                        nD.Save()
                                    End Using
                                End If
                                MessageBox.Show("Esclusione '" & rigafattura.Descrizione & "' effettuata!")
                            End Using

                        End If

                    Else
                        MessageBox.Show("Selezionare una riga fattura!")
                    End If

                End If

            Else
                MessageBox.Show("Selezionare una riga fattura!")
            End If
        Else
            MessageBox.Show("Funzionalità non disponibile in questo tipo di visualizzazione")
        End If

    End Sub

    Private Sub InserisciRegolaDiDecodificaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserisciRegolaDiDecodificaToolStripMenuItem.Click
        InserisciRegolaDecodifica()
    End Sub

    Private Sub InserisciRegolaDecodifica()

    End Sub

    Private Sub CopiaRiassuntoInClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiaRiassuntoInClipboardToolStripMenuItem.Click
        'creo un riassunto e lo copio in clipboard

        If dgDocVendita.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = dgDocVendita.SelectedRows(0)
            If Not riga Is Nothing AndAlso Not riga.DataBoundItem Is Nothing Then

                'ParentFormEx.Sottofondo()
                Using R As Ricavo = riga.DataBoundItem

                    Dim Testo As String = R.AziendaStr & " " & R.Riassunto & ControlChars.NewLine
                    Testo &= "Importo Totale " & R.TotaleStr

                    Clipboard.SetText(Testo)

                    MessageBox.Show("Riassunto copiato in clipboard! Utilizza CTRL + V (Incolla) per utilizzarlo in un testo")
                End Using
                'ParentFormEx.Sottofondo()

            End If
        Else
            Beep()
        End If

    End Sub
    Private Sub CheckCongruenzaStatoRicavi()
        Dim Buffer As String = String.Empty

        PostazioneCorrente.MostraAttesa()

        Dim CheckCosti As Boolean = True
        Dim CheckRicavi As Boolean = True

        If CheckCosti Then
            Using mgr As New CostiDAO

                Dim countCosti As Integer = 0

                'Buffer &= "<h2>Costi</h2>"

                Dim l As List(Of Costo) = Nothing

                'SISTEMO I FALSI NEGATIVI

                l = mgr.FindAll(New LUNA.LSP(LFM.Costo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.AccontoAnticipoSuFattura & "," & enTipoDocumento.AccontoAnticipoSuParcella & ")", "IN"),
                                     New LUNA.LSP(LFM.Costo.IdStato, enStatoDocumentoFiscale.PagatoInteramente, "<>"))

                For Each singvoce In l
                    'voceattuale += 1
                    Dim TotalePagamenti As Decimal = singvoce.ListaPagamenti.Sum(Function(x) x.Importo)

                    If TotalePagamenti = singvoce.Totale Then
                        'NonCombaciano.Add(singvoce.IdRicavo)
                        'If singvoce.idstato = 0 Then
                        countCosti += 1
                        singvoce.IdStato = enStatoDocumentoFiscale.PagatoInteramente
                        singvoce.Save()
                        'End If
                    End If
                    Application.DoEvents()
                Next

                l = mgr.FindAll(New LUNA.LSP(LFM.Costo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.AccontoAnticipoSuFattura & "," & enTipoDocumento.AccontoAnticipoSuParcella & ")", "IN"),
                                    New LUNA.LSP(LFM.Costo.IdStato, enStatoDocumentoFiscale.PagatoInteramente, "="))

                For Each singvoce In l
                    MgrDocumentiFiscali.AggiornaStatoCostoDopoPagamento(singvoce.IdCosto)
                Next

                'MessageBox.Show("Costi totali " & l.Count & " FALSI NEGATIVI " & countCosti)

                'MOSTRO I FALSI POSITIVI



            End Using
        End If

        If CheckRicavi Then
            Using mgr As New RicaviDAO

                Dim l As List(Of Ricavo) = Nothing

                'SISTEMO I FALSI NEGATIVI

                l = mgr.FindAll(New LUNA.LSP(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.AccontoAnticipoSuFattura & "," & enTipoDocumento.AccontoAnticipoSuParcella & ")", "IN"),
                                New LUNA.LSP(LFM.Ricavo.idstato, enStatoDocumentoFiscale.PagatoInteramente, "<>"))

                For Each singvoce In l
                    'voceattuale += 1
                    Dim TotalePagamenti As Decimal = singvoce.ListaPagamenti.Sum(Function(x) x.Importo)

                    If TotalePagamenti = singvoce.Totale Then
                        'NonCombaciano.Add(singvoce.IdRicavo)
                        'If singvoce.idstato = 0 Then
                        singvoce.idstato = enStatoDocumentoFiscale.PagatoInteramente
                        singvoce.Save()
                        'End If
                    End If
                    Application.DoEvents()
                Next

                l = mgr.FindAll(New LUNA.LSP(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.AccontoAnticipoSuFattura & "," & enTipoDocumento.AccontoAnticipoSuParcella & ")", "IN"),
                                                           New LUNA.LSP(LFM.Ricavo.idstato, enStatoDocumentoFiscale.PagatoInteramente))


                'MOSTRO I FALSI POSITIVI

                Dim totalevoci As Integer = l.Count
                Dim NonCombaciano As New List(Of Integer)
                Dim voceattuale As Integer = 0

                For Each singvoce In l
                    voceattuale += 1
                    Dim TotalePagamenti As Decimal = singvoce.ListaPagamenti.Sum(Function(x) x.Importo)

                    If TotalePagamenti <> singvoce.Totale Then
                        Buffer &= singvoce.Riassunto & "<br>"

                        NonCombaciano.Add(singvoce.IdRicavo)
                    End If
                    Application.DoEvents()
                Next

                PostazioneCorrente.NascondiAttesa()

                If Buffer.Length Then
                    Buffer = "<h2>Voci non congruenti che necessitano intervento</h2>" & Buffer

                    Dim PathTemp As String = FormerConfig.FormerPath.PathTempLocale & "vocinoncongruenti.htm"

                    Using w As New StreamWriter(PathTemp)
                        w.Write(Buffer)
                    End Using
                    ParentFormEx.Sottofondo()
                    Using f As New frmBrowser
                        f.Carica(PathTemp)
                    End Using
                    ParentFormEx.Sottofondo()
                Else
                    MessageBox.Show("Operazione completata, le incongruenze presenti sono state risolte. Non ci sono incongruenze da risolvere manualmente")
                End If


            End Using




        End If

    End Sub
    Private Sub CheckResetStatoPagamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckResetStatoPagamentoToolStripMenuItem.Click
        If MessageBox.Show("Confermi il check/reset dello stato di pagamento dei documenti?",, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then CheckCongruenzaStatoRicavi()
    End Sub

End Class
