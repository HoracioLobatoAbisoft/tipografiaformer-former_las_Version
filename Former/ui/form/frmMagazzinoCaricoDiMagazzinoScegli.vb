Imports FormerBusinessLogic
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmMagazzinoCaricoDiMagazzinoScegli
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        MgrControl.InizializeGridview(DgMovimenti)

    End Sub
    Private _ListaRichieste As List(Of MovimentoMagazzino) = Nothing

    Private Function Comparer(ByVal x As MovimentoMagazzino, ByVal y As MovimentoMagazzino) As Integer

        'Dim Result As Integer = y.TutteScatolePiene.CompareTo(x.TutteScatolePiene)
        'If Result = 0 Then Result = x.NumeroScatole.CompareTo(y.NumeroScatole)
        'If result = 0 Then result = x.SpazioSprecato.CompareTo(y.SpazioSprecato)

        Dim Result As Integer = x.UltimoFornStr.CompareTo(y.UltimoFornStr)
        If Result = 0 Then Result = x.RisorsaStr.CompareTo(y.RisorsaStr)
        'Dim Result As Integer = x.Selezionatore.CompareTo(y.Selezionatore)
        ''If Result = 0 Then Result = x.SpazioSprecato.CompareTo(y.SpazioSprecato)

        Return Result

    End Function

    Private Sub CaricaCombo()
        Using cli As New VociRubricaDAO
            cmbFornitore.ValueMember = "IdRub"
            cmbFornitore.DisplayMember = "Nominativo"

            cmbFornitore.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, False,,,,,, True)
        End Using
    End Sub

    Private Sub CaricaDatiCaricoMagazzino(C As CaricoDiMagazzino)

        MgrControl.SelectIndexCombo(cmbFornitore, C.IdRub)
        txtNumeroDoc.Text = C.NumeroDocRiferimento
        dtDataDoc.Value = C.DataCarico
        If C.TipoDocRiferimento = enTipoDocumento.DDT Then
            rdoDDT.Checked = True
        ElseIf C.TipoDocRiferimento = enTipoDocumento.Fattura Then
            rdoFattura.Checked = True
        End If
        If C.IdAzienda = MgrAziende.IdAziende.AziendaSnc Then
            rdoSNC.Checked = True
        Else
            rdoSRL.Checked = True
        End If

        Dim l As List(Of MovimentoMagazzino) = C.ListaMovimenti
        DgMovimenti.DataSource = l
    End Sub

    Private Sub ResetForm()
        MgrControl.SelectIndexCombo(cmbFornitore, _Costo.IdRub)
        txtNumeroDoc.Text = String.Empty
        dtDataDoc.Value = Now
        If _Costo.Tipo = enTipoDocumento.DDT Then
            rdoDDT.Checked = True
        ElseIf _Costo.Tipo = enTipoDocumento.Fattura Then
            rdoFattura.Checked = True
        End If
        If _Costo.IdAzienda = MgrAziende.IdAziende.AziendaSnc Then
            rdoSNC.Checked = True
        Else
            rdoSRL.Checked = True
        End If

        DgMovimenti.DataSource = Nothing

    End Sub

    Private _IdCosto As Integer = 0

    Private _Costo As Costo = Nothing

    'Private _IdCaricoMagazzinoDefault As Integer = 0
    Friend Function Carica(IdCosto As Integer) As Integer
        _IdCosto = IdCosto

        CaricaCombo()

        _Costo = New Costo
        _Costo.Read(IdCosto)
        lblDocRiferimento.Text = _Costo.TipoDocStr & " " & _Costo.Numero & " del " & _Costo.DataCosto.ToString("dd/MM/yyyy") & " - " & _Costo.AziendaStr.ToUpper
        '_IdCaricoMagazzinoDefault = _Costo.IdCaricoMagazzino
        CaricaCarichiMagazzino()

        ShowDialog()

        Return _Ris

    End Function

    Private _ListaCarichiMagazzino As New List(Of CaricoDiMagazzino)

    Private _IndiceCorrente As Integer = 0

    Private Sub CaricaCarichiMagazzino()

        _ListaCarichiMagazzino = New List(Of CaricoDiMagazzino)

        Using mgr As New CarichiDiMagazzinoDAO

            Dim ListaIn As String = String.Empty

            ListaIn = "(0"

            If _Costo.IdCosto Then
                ListaIn &= "," & _Costo.IdCosto
            End If
            ListaIn &= ")"

            _ListaCarichiMagazzino = mgr.FindAll("DataCarico DESC",
                                                 New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdRub, _Costo.IdRub),
                                                 New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdCosto, ListaIn, "IN"))

            If _ListaCarichiMagazzino.Count Then
                _IndiceCorrente = 0
                Dim movToLoad As CaricoDiMagazzino = _ListaCarichiMagazzino(_IndiceCorrente)

                If _ListaCarichiMagazzino.FindAll(Function(x) x.IdCosto = _Costo.IdCosto).Count Then
                    Dim I As Integer = 0
                    For Each c In _ListaCarichiMagazzino
                        If c.IdCosto = _Costo.IdCosto Then
                            _IndiceCorrente = I
                            Exit For
                        End If
                        I += 1
                    Next

                    movToLoad = _ListaCarichiMagazzino(_IndiceCorrente)
                End If
                CaricaDatiCaricoMagazzino(movToLoad)
                lblCurrent.Text = _IndiceCorrente + 1 & " di " & _ListaCarichiMagazzino.Count & " disponibili"

                If _Costo.IdCosto = _ListaCarichiMagazzino(_IndiceCorrente).IdCosto Then
                    lblAttualmenteCollegato.Visible = True
                Else
                    lblAttualmenteCollegato.Visible = False
                End If

            Else
                lblCurrent.Text = "NESSUN DOCUMENTO DI CARICO DISPONIBILE PER QUESTO FORNITORE"
                ResetForm()
            End If
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

        'If _FirstTime Or DgMovimenti.Rows.Count = 0 Then
        '    'qui cancello l'ordine di acquisto
        '    Using mgr As New MagazzinoDAO
        '        Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdOrdineAcquisto, _IdOrdineAcquisto))

        '        For Each m As MovimentoMagazzino In l
        '            m.IdOrdineAcquisto = 0
        '            m.Save()
        '        Next

        '    End Using

        '    Using mgr As New OrdiniAcquistoDAO
        '        mgr.Delete(_IdOrdineAcquisto)
        '    End Using
        'End If

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If _ListaCarichiMagazzino.Count AndAlso _Costo.IdCosto = _ListaCarichiMagazzino(_IndiceCorrente).IdCosto Then
            MessageBox.Show("Il documento fiscale è già collegato al documento di carico selezionato")
        Else
            If _ListaCarichiMagazzino.Count Then
                If MessageBox.Show("Confermi il collegamento del documento fiscale con il documento di carico selezionato? (i dati del documento di carico saranno sovrascritti (TIPO, DATA, NUMERO)", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    'creo una transactionbox per scollegare il precedente se c'e' e poi collegare il nuovo
                    Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                        Try
                            Dim CaricoAttuale As CaricoDiMagazzino = _ListaCarichiMagazzino.Find(Function(x) x.IdCosto = _Costo.IdCosto)

                            tb.TransactionBegin()

                            If Not CaricoAttuale Is Nothing Then
                                'qui sgancio quello vecchio 
                                CaricoAttuale.IdCosto = 0
                                CaricoAttuale.IdStatoInterno = enStatoFEInterno.Inserito
                                For Each mov In CaricoAttuale.ListaMovimenti
                                    mov.IdVoceCosto = 0
                                    mov.Save()
                                Next
                                CaricoAttuale.Save()
                                _Costo.IdCaricoMagazzino = 0
                                _Costo.StatoFEInterno = enStatoFEInterno.Inserito
                                For Each voce In _Costo.ListaVociFattura
                                    voce.IdMovMagaz = 0
                                    voce.Save()
                                Next
                                _Costo.Save()

                            End If

                            CaricoAttuale = Nothing
                            CaricoAttuale = _ListaCarichiMagazzino(_IndiceCorrente)

                            MgrMagazzinoBusiness.LegaCostoACarico(_Costo, CaricoAttuale)

                            tb.TransactionCommit()
                        Catch ex As Exception
                            tb.TransactionRollBack()
                            MessageBox.Show("Si è verificato un errore nella procedura di collegamento: " & ex.Message)

                        End Try
                    End Using

                    _Ris = 1
                    Close()

                End If
            Else
                MessageBox.Show("Nessun carico di magazzino selezionato, caricarne uno manualmente o crearlo in automatico")
            End If

        End If

    End Sub



    Private Sub DgMovimenti_DoubleClick(sender As Object, e As EventArgs) Handles DgMovimenti.DoubleClick

        'qui devo riaprire la voce 
        If DgMovimenti.SelectedRows.Count Then
            Dim m As MovimentoMagazzino = DgMovimenti.SelectedRows(0).DataBoundItem

            Sottofondo()

            Using f As New frmMagazzinoRisorsa
                f.Carica(m.IdRis)
            End Using

            Sottofondo()

        End If

    End Sub

    Private Sub txtAnnotazioni_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblTipo_Click(sender As Object, e As EventArgs) Handles lblTipo.Click

    End Sub

    Private Sub tbProd_Click(sender As Object, e As EventArgs) Handles tbProd.Click

    End Sub

    Private Sub lnkDocContabile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDocContabile.LinkClicked
        Sottofondo()

        If _Costo.Tipo = enTipoDocumento.Fattura OrElse _Costo.Tipo = enTipoDocumento.DDT Then
            Using f As New frmContabilitaCosto
                f.Carica(_Costo.IdCosto)
            End Using
        Else
            Using f As New frmContabilitaFatturaRiepilogativaCosto
                f.Carica(_Costo.IdCosto)
            End Using
        End If


        Sottofondo()

    End Sub

    Private Sub btnDetCli_Click(sender As Object, e As EventArgs) Handles btnDetCli.Click
        If cmbFornitore.SelectedValue Then
            Using f As New frmVoceRubrica
                f.Carica(cmbFornitore.SelectedValue)
            End Using
        End If
    End Sub

    Private Sub NextCurrent()

        If _IndiceCorrente < (_ListaCarichiMagazzino.Count - 1) Then
            _IndiceCorrente += 1
            lblCurrent.Text = _IndiceCorrente + 1 & " di " & _ListaCarichiMagazzino.Count & " disponibili"
            CaricaDatiCaricoMagazzino(_ListaCarichiMagazzino(_IndiceCorrente))

            If _Costo.IdCosto = _ListaCarichiMagazzino(_IndiceCorrente).IdCosto Then
                lblAttualmenteCollegato.Visible = True
            Else
                lblAttualmenteCollegato.Visible = False
            End If

        End If

    End Sub

    Private Sub PreviousCurrent()

        If _IndiceCorrente > 0 Then
            _IndiceCorrente -= 1
            lblCurrent.Text = _IndiceCorrente + 1 & " di " & _ListaCarichiMagazzino.Count & " disponibili"
            CaricaDatiCaricoMagazzino(_ListaCarichiMagazzino(_IndiceCorrente))

            If _Costo.IdCosto = _ListaCarichiMagazzino(_IndiceCorrente).IdCosto Then
                lblAttualmenteCollegato.Visible = True
            Else
                lblAttualmenteCollegato.Visible = False
            End If

        End If

    End Sub

    Private Sub lnkNext_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNext.LinkClicked

        NextCurrent

    End Sub

    Private Sub lnkPrev_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrev.LinkClicked
        PreviousCurrent()
    End Sub

    Private Sub btnCreaAutomatico_Click(sender As Object, e As EventArgs) Handles btnCreaAutomatico.Click
        If MessageBox.Show("Confermi la creazione automatica del documento di carico magazzino? (Il documento di carico sarà collegato in automatico)", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                Try

                    Dim CaricoAttuale As CaricoDiMagazzino = _ListaCarichiMagazzino.Find(Function(x) x.IdCosto = _Costo.IdCosto)

                    tb.TransactionBegin()

                    If Not CaricoAttuale Is Nothing Then
                        'qui sgancio quello vecchio 
                        CaricoAttuale.IdCosto = 0
                        CaricoAttuale.IdStatoInterno = enStatoFEInterno.Inserito
                        For Each mov In CaricoAttuale.ListaMovimenti
                            mov.IdVoceCosto = 0
                            mov.Save()
                        Next
                        CaricoAttuale.Save()
                        _Costo.IdCaricoMagazzino = 0
                        _Costo.StatoFEInterno = enStatoFEInterno.Inserito
                        For Each voce In _Costo.ListaVociFattura
                            voce.IdMovMagaz = 0
                            voce.Save()
                        Next
                        _Costo.Save()

                    End If

                    Dim ris As CaricoDiMagazzino = MgrMagazzinoBusiness.LegaCostoACarico(_Costo,, True,, True)
                    tb.TransactionCommit()

                    If Not ris Is Nothing Then
                        _Ris = 1
                        CaricaCarichiMagazzino()
                        'Close()
                    Else
                        MessageBox.Show("Si è verificato un errore nella creazione automatica di un carico di magazzino per questo documento fiscale")
                    End If
                Catch ex As Exception
                    tb.TransactionRollBack()
                    MessageBox.Show("Si è verificato un errore nella creazione automatica di un carico di magazzino per questo documento fiscale: " & ex.Message)

                End Try
            End Using


        End If

    End Sub

    Private Sub lnkNewCaricoMagazzino_Click(sender As Object, e As EventArgs) Handles lnkNewCaricoMagazzino.Click

        Sottofondo()

        Using f As New frmMagazzinoCaricoDiMagazzino
            Dim Ris As Integer = f.Carica()

            If Ris Then
                CaricaCarichiMagazzino()
            End If
        End Using

        Sottofondo()
    End Sub

    Private Sub lnkScollega_Click(sender As Object, e As EventArgs) Handles lnkScollega.Click

        If _Costo.IdCaricoMagazzino OrElse (_ListaCarichiMagazzino.Count AndAlso _ListaCarichiMagazzino.FindAll(Function(x) x.IdCosto = _Costo.IdCosto).Count <> 0) Then
            If MessageBox.Show("Confermi lo scollegamento del documento di carico magazzino?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Try
                        Dim CaricoAttuale As CaricoDiMagazzino = _ListaCarichiMagazzino.Find(Function(x) x.IdCosto = _Costo.IdCosto)

                        tb.TransactionBegin()

                        If Not CaricoAttuale Is Nothing Then
                            'qui sgancio quello vecchio 
                            CaricoAttuale.IdCosto = 0
                            CaricoAttuale.IdStatoInterno = enStatoFEInterno.Inserito
                            For Each mov In CaricoAttuale.ListaMovimenti
                                mov.IdVoceCosto = 0
                                mov.Save()
                            Next
                            CaricoAttuale.Save()

                        End If

                        _Costo.IdCaricoMagazzino = 0
                        _Costo.StatoFEInterno = enStatoFEInterno.Inserito
                        For Each voce In _Costo.ListaVociFattura
                            voce.IdMovMagaz = 0
                            voce.Save()
                        Next
                        _Costo.Save()

                        tb.TransactionCommit()
                        _Ris = 1
                        CaricaCarichiMagazzino()

                    Catch ex As Exception
                        tb.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore nella procedura di collegamento: " & ex.Message)

                    End Try
                End Using

            End If

        Else
            MessageBox.Show("Il documento fiscale non è collegato a nessun documento di carico")
        End If
    End Sub

    Private Sub lnkDocCarico_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDocCarico.LinkClicked


        If _ListaCarichiMagazzino.Count Then
            Sottofondo()
            Using f As New frmMagazzinoCaricoDiMagazzino
                Dim ris As Integer = f.Carica(_ListaCarichiMagazzino(_IndiceCorrente).IdCaricoMagazzino)
                If ris Then
                    CaricaCarichiMagazzino()
                End If
            End Using
            Sottofondo()
        End If


    End Sub
End Class