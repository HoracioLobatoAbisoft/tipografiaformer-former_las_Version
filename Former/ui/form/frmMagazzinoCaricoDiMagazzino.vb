Imports FormerBusinessLogic
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Friend Class frmMagazzinoCaricoDiMagazzino
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        MgrControl.InizializeGridview(DgMovimenti)

    End Sub

    Private _IdCaricoMagazzino As Integer = 0

    Private _ListaRichieste As List(Of MovimentoMagazzino) = Nothing

    Private Sub CaricaMovimenti()
        Using O As New CaricoDiMagazzino
            O.Read(_IdCaricoMagazzino)
            Dim l As List(Of MovimentoMagazzino) = O.ListaMovimenti
            DgMovimenti.DataSource = l
        End Using

    End Sub

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

    Private _IdDocumentoFiscale As Integer = 0

    Friend Function Carica(Optional IdCaricoMagazzino As Integer = 0) As Integer
        _IdCaricoMagazzino = IdCaricoMagazzino

        CaricaCombo()

        If IdCaricoMagazzino Then
            Using O As New CaricoDiMagazzino
                O.Read(IdCaricoMagazzino)
                MgrControl.SelectIndexCombo(cmbFornitore, O.IdRub)
                txtNumeroDoc.Text = O.NumeroDocRiferimento
                dtDataDoc.Value = O.DataCarico
                If O.TipoDocRiferimento = enTipoDocumento.DDT Then
                    rdoDDT.Checked = True
                ElseIf O.TipoDocRiferimento = enTipoDocumento.Fattura Then
                    rdoFattura.Checked = True
                End If
                If O.IdAzienda = MgrAziende.IdAziende.AziendaSnc Then
                    rdoSNC.Checked = True
                Else
                    rdoSRL.Checked = True
                End If
                _IdDocumentoFiscale = O.IdCosto

            End Using

            CaricaMovimenti()
            'btnAddRichiesta.Visible = False
            'btnDelRichiesta.Visible = False


            'controllo l'anomalia
            If _IdDocumentoFiscale Then
                If RigheCongruenti() = False Then
                    lblAnomalia.Visible = True
                End If
            End If


        Else
            dtDataDoc.Value = Now

        End If

        ShowDialog()

        Return _Ris

    End Function

    Private Function RigheCongruenti() As Boolean

        Dim ris As Boolean = True
        Return ris

        'ciclo in tutte le righe del caricodi magazzino e del documento fiscale
        Using O As New CaricoDiMagazzino
            O.Read(_IdCaricoMagazzino)
            For Each riga In O.ListaMovimenti
                If riga.IdVoceCosto = 0 Then
                    ris = False
                    Exit For
                End If

            Next

            If ris Then
                'qui ancora controllo
                Using c As New Costo
                    c.Read(_IdDocumentoFiscale)
                    For Each voce In c.ListaVociFattura
                        If MgrFormerException.ValutareRigaFatturaComeRisorsa(voce) Then
                            If O.ListaMovimenti.FindAll(Function(x) x.IdVoceCosto = voce.IdVoceCosto).Count = 0 Then
                                ris = False
                                Exit For
                            End If
                        End If
                    Next
                End Using

            End If
        End Using


        Return ris

    End Function
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

    Private Function SaveData() As Integer
        'Dim Ris As Integer = 0
        'If DgMovimenti.Rows.Count Then

        Using o As New CaricoDiMagazzino
            o.Read(_IdCaricoMagazzino)

            o.DataCarico = dtDataDoc.Value
            o.IdRub = cmbFornitore.SelectedValue
            o.NumeroDocRiferimento = txtNumeroDoc.Text
            o.TipoDocRiferimento = IIf(rdoDDT.Checked, enTipoDocumento.DDT, enTipoDocumento.Fattura)
            o.IdUtCarico = PostazioneCorrente.UtenteConnesso.IdUt
            o.IdAzienda = IIf(rdoSNC.Checked, MgrAziende.IdAziende.AziendaSnc, MgrAziende.IdAziende.AziendaSrl)
            o.IdStatoInterno = enStatoFEInterno.Inserito
            _IdCaricoMagazzino = o.Save()

            For Each m In o.ListaMovimenti
                m.IdCaricoMagazzino = 0
                m.Save()
            Next

            For Each r In DgMovimenti.Rows
                Dim M As MovimentoMagazzino = r.DataBoundItem
                M.IdCaricoMagazzino = 0
                M.IdCaricoMagazzino = o.IdCaricoMagazzino
                M.Save()
            Next

        End Using
        'Else
        'MessageBox.Show("Inserire almeno una richiesta di acquisto nell'ordine")
        'End If

        Return _IdCaricoMagazzino

    End Function

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtNumeroDoc.Text.Length = 0 Then
            MessageBox.Show("Inserire il numero del documento")
        Else
            If MessageBox.Show("Confermi il salvataggio del documento di carico magazzino?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If SaveData() Then
                    _Ris = 1
                    Close()
                End If

            End If
        End If


    End Sub

    Private Sub btnDelListBase_Click(sender As Object, e As EventArgs) Handles btnDelRichiesta.Click
        If DgMovimenti.SelectedRows.Count Then

            Dim M As MovimentoMagazzino = DgMovimenti.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi l'eliminazione del movimento selezionata dal documento?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                M.IdOrdineAcquisto = 0
                M.Save()

                '               Using mgr As New MagazzinoDAO
                'mgr.Delete(M)
                'mgr.AggiornaQta(M.IdRis)
                DgMovimenti.Rows.Remove(DgMovimenti.SelectedRows(0))
                '                End Using
            End If

        End If
    End Sub

    Private Sub btnAddRichiesta_Click(sender As Object, e As EventArgs) Handles btnAddRichiesta.Click

        Dim OKSalvataggio As Boolean = True

        If _IdCaricoMagazzino = 0 Then
            OKSalvataggio = False
            If txtNumeroDoc.Text.Length = 0 Then
                MessageBox.Show("Inserire il numero del documento")
            Else
                If MessageBox.Show("Prima di inserire il dettaglio si deve salvare il documento di carico. Confermi il salvataggio del documento di carico magazzino?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If SaveData() Then
                        OKSalvataggio = True
                    End If
                End If
            End If

        End If

        If OKSalvataggio Then
            Sottofondo()

            Using f As New frmMagazzinoCarico
                f.IDForn = cmbFornitore.SelectedValue
                Dim Ris As Integer = f.Carica(,, enTipoMovMagaz.Carico,, _IdCaricoMagazzino)
                If Ris Then
                    CaricaMovimenti()
                End If

            End Using

            Sottofondo()

        End If

    End Sub

    Private Sub DgMovimenti_Click(sender As Object, e As EventArgs) Handles DgMovimenti.Click

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
        If _IdDocumentoFiscale Then
            Sottofondo()

            Using f As New frmContabilitaCosto
                f.Carica(_IdDocumentoFiscale)
            End Using

            Sottofondo()

        Else
            MessageBox.Show("Il documento fiscale non è stato ancora collegato al documento di carico")
        End If
    End Sub

    Private Sub btnDetCli_Click(sender As Object, e As EventArgs) Handles btnDetCli.Click
        If cmbFornitore.SelectedValue Then
            Using f As New frmVoceRubrica
                f.Carica(cmbFornitore.SelectedValue)
            End Using
        End If
    End Sub
End Class