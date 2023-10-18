Imports FormerBusinessLogic
Imports FormerConfig
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports Telerik.WinControls.UI

Friend Class frmContabilitaFatturaRiepilogativaCosto
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        MgrControl.InizializeGridview(dgDocDDT)
        childTemplate = CreateChildTemplate()

        Dim relation As New GridViewRelation(dgDocDDT.MasterTemplate, childTemplate)
        relation.ChildColumnNames.Add("ListaDettaglio")
        dgDocDDT.Relations.Add(relation)

        RadPdfViewerNavigator.SaveButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        RadPdfViewerNavigator.OpenButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden

    End Sub

    Private Sub dgDocDDT_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgDocDDT.ViewCellFormatting

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
                Cell.RowInfo.Height = 35
            End If
            'ElseIf TypeOf e.CellElement Is GridDetailViewCellElement Then

            '    If Not Cell Is Nothing AndAlso Not m Is Nothing Then
            '        If m.IdUtFormer Then
            '            Cell.RowInfo.Cells(0).Style.BackColor = Color.Red
            '        End If
            '       
            '    End If
        End If
    End Sub

    Private _IdCosto As Integer = 0

    Private _Trasformazione As Boolean = False

    Friend Function Carica(Optional IdCosto As Integer = 0, Optional Trasformazione As Boolean = False) As Integer

        _IdCosto = IdCosto
        _Trasformazione = Trasformazione
        CaricaCombo()

        _Voce = New Costo

        If _IdCosto Then
            _Voce.Read(_IdCosto)
            pctSblocco.Visible = True

            lblAzienda.Text = MgrAziende.GetAziendaStr(_Voce.IdAzienda)
            MgrControl.SelectIndexCombo(cmbCliente, _Voce.IdRub)
            txtDescrizione.Text = _Voce.Descrizione
            dataOp.Value = _Voce.DataRif
            txtDataPrevPagam.Value = _Voce.DataPrevPagam
            txtImporto.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Voce.Importo, 2)
            txtSpeseIncasso.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Voce.SpeseIncasso, 2)
            txtAddebitiVari.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Voce.AddebitiVari, 2)
            txtCostoSped.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Voce.CostoCorr, 2)
            txtIva.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Voce.Iva, 2)
            txtNumero.Text = _Voce.Numero
            If _Voce.PercIva <> FormerConst.Fiscali.PercentualeMultiIva Then
                txtPercIva.Text = _Voce.PercIva
            Else
                txtPercIva.Text = String.Empty
            End If
            txtFile.Text = _Voce.Scansione
            txtMainFile.Text = _Voce.Scansione
            txtFile1.Text = _Voce.Scansione1
            txtFile2.Text = _Voce.Scansione2
            txtFile3.Text = _Voce.Scansione3
            txtFile4.Text = _Voce.Scansione4
            cmbCliente.Enabled = False

            UcPagamenti.IdDocRif = IdCosto
            UcPagamenti.MostraDati(enTipoVoceContab.VoceAcquisto)

            dgVociFat.AutoGenerateColumns = False
            dgVociFat.DataSource = _Voce.ListaVociFattura


            'lblCostoSped.Text = _Voce.
            CaricaDocumenti()
            If Trasformazione = False Then
                For Each R In dgDocDDT.Rows
                    R.Cells(0).Value = True
                Next
            End If

            CalcolaTotaleDaDDT()
            If dgDocDDT.Rows.Count = 0 Then
                CheckTotaleCongruente()
            End If
            CaricaAnteprima()
            If Trasformazione Then btnOk.Text = "Prosegui"
            UcDocumentiFiscaliXMLCosto.Carica(_Voce)

            If _Voce.StatoFE = enStatoFatturaFE.AllegatoXMLRicevuto Then
                ' qui blocco tutto
                btnOk.Visible = False
                dataOp.Enabled = False
                txtDataPrevPagam.Enabled = False
                cmbCliente.Enabled = False
                txtNumero.Enabled = False
                txtDescrizione.Enabled = False
                txtImporto.Enabled = False
                txtCostoSped.Enabled = False
                txtAddebitiVari.Enabled = False
                txtSpeseIncasso.Enabled = False
                btnMainFile.Enabled = False

            End If
            Me.Text &= " - " & IdCosto
            UcContabCostoAmmortamento.Carica(IdCosto)
        Else
            lblAzienda.Text = "-"
            btnOk.Text = "Prosegui"
            txtPercIva.Text = FormerHelper.Finanziarie.GetPercentualeIva
            CalcolaDataPagamento()
            TabMain.TabPages.Remove(tpAmmortamento)
        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using cli As New VociRubricaDAO
            cmbCliente.ValueMember = "IdRub"
            cmbCliente.DisplayMember = "Nominativo"

            Dim ListaSpecifica As String = String.Empty

            If _IdCosto = 0 Then
                ListaSpecifica = "ONLYWITHDDT"
            End If

            cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, False, ListaSpecifica,,,,, True)
        End Using



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

    Private Sub SalvaDatiFattura()
        Dim CheckOk As Boolean = True
        Dim bufferErrore As String = String.Empty

        If txtImporto.Text.Length = 0 OrElse txtImporto.Text = 0 Then
            bufferErrore &= "Inserire un importo!" & ControlChars.NewLine
            CheckOk = False
        End If

        If txtNumero.Text.Length = 0 OrElse txtNumero.Text = 0 Then
            bufferErrore &= "Inserire un numero di documento!" & ControlChars.NewLine
            CheckOk = False
        End If

        Dim IdAzienda As Integer = 0
        For Each R As GridViewRowInfo In dgDocDDT.Rows

            If R.Cells(0).Value = True Then
                'voce selezionata
                Dim C As Costo = R.DataBoundItem
                If IdAzienda = 0 Then
                    IdAzienda = C.IdAzienda
                Else
                    If IdAzienda <> C.IdAzienda Then
                        bufferErrore &= "Sono stati selezionati DDT intestati ad aziende diverse!" & ControlChars.NewLine
                        CheckOk = False
                    End If
                End If

            End If
        Next

        If CheckOk Then
            If MessageBox.Show("Confermi il salvataggio della fattura riepilogativa?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If _IdCosto Then
                    _Voce.DataPrevPagam = txtDataPrevPagam.Value
                    _Voce.Save()
                    Close()

                Else
                    Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

                        Try
                            tb.TransactionBegin()

                            'salvo la fattura riepilogativa e poi collego i ddt

                            If _Voce.IdCosto = 0 Then

                                _Voce.IdStato = enStatoDocumentoFiscale.Registrato

                            End If

                            _Voce.Tipo = enTipoDocumento.FatturaRiepilogativa
                            _Voce.DataCosto = dataOp.Value
                            _Voce.DataPrevPagam = txtDataPrevPagam.Value
                            _Voce.Numero = txtNumero.Text
                            _Voce.Descrizione = txtDescrizione.Text
                            _Voce.IdRub = cmbCliente.SelectedValue
                            _Voce.Importo = txtImporto.Text
                            _Voce.AddebitiVari = txtAddebitiVari.Text
                            _Voce.SpeseIncasso = txtSpeseIncasso.Text
                            _Voce.Iva = txtIva.Text
                            _Voce.PercIva = txtPercIva.Text
                            _Voce.Totale = txtTotaleDoc.Text
                            _Voce.CostoCorr = txtCostoSped.Text
                            _Voce.IdAzienda = IdAzienda

                            If txtFile.Text.Length And txtFile.Text <> _Voce.Scansione Then
                                Dim Est As String = "." & txtFile.Text.Substring(txtFile.Text.Length - 3)
                                Dim NomeFile1 As String = FormerPath.PathFattureAcquisto & "Fatt_" & FormerLib.FormerHelper.File.GetNomeFileTemp(Est)
                                MgrIO.FileCopia(Me, txtFile.Text, NomeFile1)
                                _Voce.Scansione = NomeFile1
                            End If

                            If txtFile1.Text.Length And txtFile1.Text <> _Voce.Scansione1 Then
                                Dim Est As String = "." & txtFile1.Text.Substring(txtFile1.Text.Length - 3)
                                Dim NomeFile2 As String = FormerPath.PathFattureAcquisto & "Fatt_" & FormerLib.FormerHelper.File.GetNomeFileTemp(Est)
                                MgrIO.FileCopia(Me, txtFile1.Text, NomeFile2)
                                _Voce.Scansione1 = NomeFile2
                            End If

                            If txtFile2.Text.Length And txtFile2.Text <> _Voce.Scansione2 Then
                                Dim Est As String = "." & txtFile2.Text.Substring(txtFile2.Text.Length - 3)
                                Dim NomeFile3 As String = FormerPath.PathFattureAcquisto & "Fatt_" & FormerLib.FormerHelper.File.GetNomeFileTemp(Est)
                                MgrIO.FileCopia(Me, txtFile2.Text, NomeFile3)
                                _Voce.Scansione2 = NomeFile3
                            End If

                            If txtFile3.Text.Length And txtFile3.Text <> _Voce.Scansione3 Then
                                Dim Est As String = "." & txtFile3.Text.Substring(txtFile3.Text.Length - 3)
                                Dim NomeFile4 As String = FormerPath.PathFattureAcquisto & "Fatt_" & FormerLib.FormerHelper.File.GetNomeFileTemp(Est)
                                MgrIO.FileCopia(Me, txtFile3.Text, NomeFile4)
                                _Voce.Scansione3 = NomeFile4
                            End If

                            If txtFile4.Text.Length And txtFile4.Text <> _Voce.Scansione4 Then
                                Dim Est As String = "." & txtFile4.Text.Substring(txtFile4.Text.Length - 3)
                                Dim NomeFile5 As String = FormerPath.PathFattureAcquisto & "Fatt_" & FormerLib.FormerHelper.File.GetNomeFileTemp(Est)
                                MgrIO.FileCopia(Me, txtFile4.Text, NomeFile5)
                                _Voce.Scansione4 = NomeFile5
                            End If

                            Dim IdInserito As Integer = _Voce.Save

                            If IdInserito Then

                                Dim Totale As Decimal = 0
                                For Each R As GridViewRowInfo In dgDocDDT.Rows

                                    If R.Cells(0).Value = True Then
                                        'voce selezionata
                                        Dim C As Costo = R.DataBoundItem
                                        C.IdDocRif = IdInserito
                                        C.Save()

                                    End If
                                Next

                                tb.TransactionCommit()

                                _Ris = _Voce.IdCosto
                                Close()

                            Else
                                tb.TransactionRollBack()
                                MessageBox.Show("Si è verificato un errore nel salvataggio riprovare")
                            End If

                        Catch ex As Exception
                            tb.TransactionRollBack()
                            MessageBox.Show("Si è verificato un errore nel salvataggio della fattura: " & ex.Message)
                        End Try

                    End Using
                End If



            End If
        Else
            MessageBox.Show(bufferErrore)
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        SalvaDatiFattura()

    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged

        CaricaDocumenti()

        CalcolaDataPagamento()

    End Sub

    Private Sub CalcolaDataPagamento()

        If Not _Voce Is Nothing Then
            'qui calcolo la data di previsto pagamento del fornitore selezionato

            Dim R As VoceRubrica = cmbCliente.SelectedItem

            Dim IdPagamento As Integer = R.IdPagamento

            Using P As New TipoPagamento
                P.Read(IdPagamento)
                Dim DataEnd As Date = dataOp.Value.AddDays(P.ggToAdd)
                txtDataPrevPagam.Value = DataEnd
            End Using

        End If

    End Sub

    Private Sub CaricaDocumenti()

        'carico i ddt non in fattura di questo fornitore
        Using mgr As New CostiDAO
            Dim l As List(Of Costo) = Nothing

            Dim IdRub As Integer = cmbCliente.SelectedValue
            Dim Tipo As enFiltroTipoDocumento = enFiltroTipoDocumento.DDT


            If (_IdCosto <> 0 And _Trasformazione = False) Then
                Tipo = enFiltroTipoDocumento.DDTInFattura
            Else
                Tipo = enFiltroTipoDocumento.DDT
            End If

            l = mgr.GetLista(,, IdRub, Tipo, False, False,, IIf(_Trasformazione, 0, _IdCosto))

            dgDocDDT.DataSource = l

        End Using

    End Sub

    Private childTemplate As GridViewTemplate = Nothing

    Private Function CreateChildTemplate() As GridViewTemplate
        Dim childTemplate As New GridViewTemplate()
        childTemplate.AutoGenerateColumns = False
        childTemplate.AllowColumnReorder = False
        childTemplate.ShowColumnHeaders = True
        childTemplate.AllowRowResize = False
        childTemplate.AllowColumnResize = True

        dgDocDDT.Templates.Add(childTemplate)

        Dim columnT As New GridViewTextBoxColumn("CodiceForn")
        columnT.HeaderText = "Codice"
        columnT.TextAlignment = ContentAlignment.MiddleLeft
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("DescrForn")
        columnT.HeaderText = "Descrizione"
        columnT.TextAlignment = ContentAlignment.MiddleLeft
        columnT.MinWidth = 200
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("Qta")
        columnT.HeaderText = "Qta"
        columnT.TextAlignment = ContentAlignment.MiddleRight
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("Prezzo")
        columnT.HeaderText = "Prezzo"
        columnT.FormatInfo = New Globalization.CultureInfo("it-IT")
        columnT.FormatString = "{0:C}"
        columnT.TextAlignment = ContentAlignment.MiddleRight
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)

        'childTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.
        Return childTemplate
    End Function

    Private Function GetPathFattureAcquisto() As String
        Dim ris As String = "Z:\FattureRicevute\"

        Dim Totale As Decimal = 0
        Dim meseScelto As Integer = 0
        Dim annoScelto As Integer = 0

        For Each R As GridViewRowInfo In dgDocDDT.Rows

            If R.Cells(0).Value = True Then
                'voce selezionata
                Dim C As Costo = R.DataBoundItem
                If meseScelto = 0 Then
                    meseScelto = C.DataCosto.Month
                    annoScelto = C.DataCosto.Year
                Else
                    If (annoScelto <> C.DataCosto.Year Or meseScelto <> C.DataCosto.Month) Then
                        annoScelto = 0
                        meseScelto = 0
                        Exit For
                    End If
                End If

            End If
        Next

        If annoScelto <> 0 Then
            ris &= annoScelto & "\" & annoScelto & meseScelto.ToString("00") & "\"
        End If

        Return ris
    End Function

    Private Sub CalcolaTotaleDaDDT()

        Dim Totale As Decimal = 0

        If dgDocDDT.Rows.Count Then
            For Each R As GridViewRowInfo In dgDocDDT.Rows

                If R.Cells(0).Value = True Then
                    'voce selezionata

                    For Each S In R.ChildRows
                        Dim Voce As MovimentoMagazzino = S.DataBoundItem
                        Totale += Voce.Prezzo
                    Next
                End If
            Next
        End If

        lblTotale.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Totale)

        CheckTotaleCongruente()

    End Sub

    Private Sub dgDocDDT_CellClick(sender As Object, e As GridViewCellEventArgs) Handles dgDocDDT.CellClick

        If e.RowIndex <> -1 Then
            If _Voce.IdCosto = 0 Or _Trasformazione = True Then
                If e.ColumnIndex >= 0 Then
                    e.Row.Cells(0).Value = Not e.Row.Cells(0).Value
                End If

                CalcolaTotaleDaDDT()
            End If

            'Dim c As GridViewch = r.Cells(0)

        End If

    End Sub

    Private Sub btnSfoglia_Click_1(sender As Object, e As EventArgs) Handles btnSfoglia.Click
        Dim path As String = ""

        Using f As New frmOpenPDF
            Sottofondo()
            f.Carica(GetPathFattureAcquisto, True)
            Sottofondo()

            If f.SelectedFile.Length Then
                path = f.SelectedFile
                txtMainFile.Text = path
                txtFile.Text = path

                CaricaAnteprima()
            End If

        End Using
    End Sub

    Private Sub btnSfoglia1_Click_1(sender As Object, e As EventArgs) Handles btnSfoglia1.Click
        Dim path As String = ""

        Using f As New frmOpenPDF
            Sottofondo()
            f.Carica(GetPathFattureAcquisto, True)
            Sottofondo()
            If f.SelectedFile.Length Then
                path = f.SelectedFile
                txtFile1.Text = path
            End If

        End Using
    End Sub

    Private _Voce As Costo = Nothing

    Private Sub CaricaAnteprima()

        Dim Val As String = String.Empty

        If _Voce.Scansione.Length Then
            Val = _Voce.Scansione
        Else
            Val = txtFile.Text
        End If

        If Val.Length Then
            RadPreview.ViewerMode = FixedDocumentViewerMode.TextSelection
            RadPreview.FitFullPage = True

            Try
                RadPreview.LoadDocument(Val)
            Catch ex As Exception
                MessageBox.Show("Errore nel caricamento dell'anteprima PDF")
            End Try
        End If
    End Sub

    Private Sub btnSfoglia2_Click_1(sender As Object, e As EventArgs) Handles btnSfoglia2.Click
        Dim path As String = ""

        Using f As New frmOpenPDF
            Sottofondo()
            f.Carica(GetPathFattureAcquisto, True)
            Sottofondo()
            If f.SelectedFile.Length Then
                path = f.SelectedFile
                txtFile2.Text = path
            End If

        End Using
    End Sub

    Private Sub btnSfoglia3_Click_1(sender As Object, e As EventArgs) Handles btnSfoglia3.Click
        Dim path As String = ""

        Using f As New frmOpenPDF
            Sottofondo()
            f.Carica(GetPathFattureAcquisto, True)
            Sottofondo()
            If f.SelectedFile.Length Then
                path = f.SelectedFile
                txtFile3.Text = path
            End If

        End Using
    End Sub

    Private Sub btnSfoglia4_Click_1(sender As Object, e As EventArgs) Handles btnSfoglia4.Click
        Dim path As String = ""

        Using f As New frmOpenPDF
            Sottofondo()
            f.Carica(GetPathFattureAcquisto, True)
            Sottofondo()
            If f.SelectedFile.Length Then
                path = f.SelectedFile
                txtFile4.Text = path
            End If

        End Using
    End Sub

    Private Sub dgDocDDT_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgDocDDT.CellDoubleClick

        If dgDocDDT.SelectedRows.Count Then
            Dim R As GridViewRowInfo = dgDocDDT.SelectedRows(0)

            Dim C As Costo = R.DataBoundItem
            Sottofondo()

            Using f As New frmContabilitaCosto
                f.Carica(C.IdCosto)
            End Using

            Sottofondo()

        End If


        'If dgDocDDT.SelectedRows.Count Then

        '    'Dim R As RadGridViewin = dgDocDDT.SelectedRows(0)

        '    If TypeOf (dgDocDDT.SelectedRows(0).DataBoundItem) Is MovimentoMagazzino Then

        '        If _Voce.IdCosto And _Trasformazione = False Then

        '            Dim OggRif As MovimentoMagazzino
        '            OggRif = dgDocDDT.SelectedRows(0).DataBoundItem
        '            Dim Ris As Integer = 0
        '            Sottofondo()
        '            Using x As New frmMagazzinoCarico
        '                x.IdRis = OggRif.IdRis
        '                Ris = x.Carica(OggRif.IdCarMag, , enTipoMovMagaz.Carico)
        '            End Using
        '            Sottofondo()

        '            If Ris Then
        '                'qui devo ricaricare la voce 
        '                OggRif.Read(OggRif.IdCarMag)
        '                e.Row.Cells("Qta").Value = OggRif.Qta
        '                e.Row.Cells("Prezzo").Value = OggRif.Prezzo
        '                e.Row.ViewTemplate.Refresh()
        '                'dgDocDDT.Refresh()
        '            End If

        '            CalcolaTotaleDaDDT()
        '        Else
        '            MessageBox.Show("Prima di inserire il dettaglio dei vari DDT, inserire i dati generali e cliccare su Prosegui")

        '        End If


        '    End If

        'End If

    End Sub

    Private Sub txtImporto_TextChanged(sender As Object, e As EventArgs) Handles txtImporto.TextChanged
        AggiornaTotaleCalcolato()
    End Sub

    Private Sub AggiornaTotaleCalcolato()
        Try
            Dim Totale As Decimal = txtImporto.Text
            Totale += txtCostoSped.Text
            Totale += txtAddebitiVari.Text
            Totale += txtSpeseIncasso.Text

            Dim PercIva As Integer = FormerConst.Fiscali.PercentualeIva ' txtPercIva.Text
            Dim Iva As Decimal = FormerHelper.Finanziarie.CalcolaIva(Totale) ' Math.Round(((Totale * PercIva) / 100), 2)

            Totale += Iva

            txtIva.Text = FormerHelper.Stringhe.FormattaPrezzo(Iva)
            txtTotaleDoc.Text = FormerHelper.Stringhe.FormattaPrezzo(Totale)

            CheckTotaleCongruente()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lblCostoSped_TextChanged(sender As Object, e As EventArgs) Handles txtCostoSped.TextChanged

        AggiornaTotaleCalcolato()

    End Sub

    Private Sub CheckTotaleCongruente()
        lblTotNonCongr.Visible = False
        Exit Sub
        Try
            Dim TotaleInserito As Decimal = txtImporto.Text

            If dgDocDDT.Rows.Count Then
                Dim TotaleCalcolato As Decimal = lblTotale.Text

                If TotaleInserito <> TotaleCalcolato Then
                    If TotaleCalcolato = 0 Then
                        lblTotNonCongr.Text = "TOTALE NON CALCOLABILE"
                        lblTotNonCongr.Visible = True
                    Else
                        lblTotNonCongr.Text = "TOTALE NON CONGRUENTE"
                        lblTotNonCongr.Visible = True
                    End If
                Else



                    lblTotNonCongr.Visible = False
                End If
            Else
                Dim IvaInserita As Decimal = txtIva.Text
                Dim PercIva As Integer = txtPercIva.Text
                Dim IvaCalcolata As Decimal = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotaleInserito * PercIva / 100)
                Dim TotaleDocumento As Decimal = txtTotaleDoc.Text

                If IvaInserita <> IvaCalcolata Then

                    lblTotNonCongr.Visible = True
                    lblTotNonCongr.Text = "IMPORTI ERRATI!"

                Else
                    If TotaleInserito + IvaInserita <> TotaleDocumento Then
                        lblTotNonCongr.Visible = True
                        lblTotNonCongr.Text = "IMPORTI ERRATI!"
                    Else
                        lblTotNonCongr.Visible = False
                    End If
                End If
            End If


        Catch ex As Exception

        End Try


    End Sub

    Private Sub txtSpeseIncasso_TextChanged(sender As Object, e As EventArgs) Handles txtSpeseIncasso.TextChanged
        AggiornaTotaleCalcolato()
    End Sub

    Private Sub txtAddebitiVari_TextChanged(sender As Object, e As EventArgs) Handles txtAddebitiVari.TextChanged
        AggiornaTotaleCalcolato()
    End Sub

    Private Sub btnDetCli_Click(sender As Object, e As EventArgs) Handles btnDetCli.Click

        If cmbCliente.SelectedIndex <> -1 Then
            ApriCli(cmbCliente.SelectedValue)
        End If
    End Sub

    Private Sub ApriCli(Optional ByVal IdRub As Integer = 0)

        Using frmRif As New frmVoceRubrica
            Dim ObjRif As New VoceRubrica
            Dim Ris As Integer = 0
            ObjRif.Tipo = enTipoRubrica.Cliente

            If IdRub Then
                ObjRif.Read(IdRub)
            End If

            Sottofondo()
            Ris = frmRif.Carica(ObjRif)
            Sottofondo()

        End Using

    End Sub

    Private Sub dataOp_ValueChanged(sender As Object, e As EventArgs) Handles dataOp.ValueChanged
        CalcolaDataPagamento()
    End Sub

    Private Sub dgDocDDT_SelectionChanged(sender As Object, e As EventArgs) Handles dgDocDDT.SelectionChanged
        If dgDocDDT.SelectedRows.Count Then
            If TypeOf (dgDocDDT.SelectedRows(0).DataBoundItem) Is MovimentoMagazzino Then
                MostraEdit(dgDocDDT.SelectedRows(0).DataBoundItem)
            Else
                HideEdit()
            End If
        Else
            HideEdit()
        End If
    End Sub

    Private Sub MostraEdit(ByRef M As MovimentoMagazzino)
        '        UcDocumentiFiscaliEditRow = New ucDocumentiFiscaliEditRow
        Exit Sub



        If _Voce.IdCosto And _Trasformazione = False Then
            Dim g As GridViewRowInfo = dgDocDDT.SelectedRows(0)

            UcDocumentiFiscaliEditRow.Left = 580 'dgDocDDT.Left + 300
            UcDocumentiFiscaliEditRow.Top = 20 'MousePosition.Y + dgDocDDT.Top

            UcDocumentiFiscaliEditRow.Visible = True
            UcDocumentiFiscaliEditRow.Focus()
            UcDocumentiFiscaliEditRow.Carica(M)


            'Else
            '    MessageBox.Show("Prima di inserire il dettaglio dei vari DDT, inserire i dati generali e cliccare su Prosegui")

        End If

    End Sub

    Private Sub HideEdit()

        Exit Sub
        UcDocumentiFiscaliEditRow.Visible = False
        dgDocDDT.Focus()
        '       UcDocumentiFiscaliEditRow.Dispose()
        '      UcDocumentiFiscaliEditRow = Nothing
    End Sub

    'Private WithEvents DettaglioRiga As ucDocumentiFiscaliEditRow = Nothing

    Private Sub ClickAnnulla() Handles UcDocumentiFiscaliEditRow.ClickAnnulla
        HideEdit()
    End Sub

    Private Sub ClickSalva(IdMovimento As Integer) Handles UcDocumentiFiscaliEditRow.ClickSalva
        'refresh la riga selezionata? 

        'If Ris Then
        'qui devo ricaricare la voce 
        Dim R As GridViewRowInfo = dgDocDDT.SelectedRows(0)

        Using M As New MovimentoMagazzino
            M.Read(IdMovimento)
            R.Cells("Qta").Value = M.Qta
            R.Cells("Prezzo").Value = M.Prezzo
            R.ViewTemplate.Refresh()
        End Using

        CalcolaTotaleDaDDT()

        HideEdit()
    End Sub

    Private Sub lnkApri_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkApri.LinkClicked

        If txtFile.TextLength Then
            Try

                Dim PathMOd As String = txtFile.Text

                Dim x As New Process

                x.StartInfo.FileName = PathMOd
                x.Start()
            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub

    Private Sub lnkApri1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkApri1.LinkClicked

        If txtFile1.TextLength Then
            Try

                Dim PathMOd As String = txtFile1.Text

                Dim x As New Process

                x.StartInfo.FileName = PathMOd
                x.Start()
            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub

    Private Sub lnkApri2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkApri2.LinkClicked

        If txtFile2.TextLength Then
            Try

                Dim PathMOd As String = txtFile2.Text

                Dim x As New Process

                x.StartInfo.FileName = PathMOd
                x.Start()
            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub

    Private Sub lnkApri3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkApri3.LinkClicked

        If txtFile3.TextLength Then
            Try

                Dim PathMOd As String = txtFile3.Text

                Dim x As New Process

                x.StartInfo.FileName = PathMOd
                x.Start()
            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub

    Private Sub lnkApri4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkApri4.LinkClicked

        If txtFile4.TextLength Then
            Try

                Dim PathMOd As String = txtFile4.Text

                Dim x As New Process

                x.StartInfo.FileName = PathMOd
                x.Start()
            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub

    Private Sub btnMainFile_Click(sender As Object, e As EventArgs) Handles btnMainFile.Click

        Dim path As String = ""

        Using f As New frmOpenPDF
            Sottofondo()
            f.Carica(GetPathFattureAcquisto, True)
            Sottofondo()
            If f.SelectedFile.Length Then
                path = f.SelectedFile
                txtMainFile.Text = path
                txtFile.Text = path

                CaricaAnteprima()
            End If

        End Using

        'OpenFileDialog.ShowDialog()
        'If OpenFileDialog.FileName.Length Then
        '    path = OpenFileDialog.FileName
        '    txtFile.Text = path

        '    CaricaAnteprima()

        'End If

    End Sub

    Private Sub dgDocDDT_Click(sender As Object, e As EventArgs) Handles dgDocDDT.Click

    End Sub

    Private Sub pctSblocco_Click(sender As Object, e As EventArgs) Handles pctSblocco.Click

        If _IdCosto Then
            txtDataPrevPagam.Enabled = True
            btnOk.Visible = True
        End If
    End Sub
End Class