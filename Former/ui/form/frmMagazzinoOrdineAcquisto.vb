Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmMagazzinoOrdineAcquisto
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        MgrControl.InizializeGridview(DgMovimenti)

    End Sub

    Private _IdOrdineAcquisto As Integer = 0

    Private _ListaRichieste As List(Of MovimentoMagazzino) = Nothing

    Private Sub CaricaRichieste()
        Using O As New OrdineAcquisto
            O.Read(_IdOrdineAcquisto)
            Dim l As List(Of MovimentoMagazzino) = O.Richieste
            DgMovimenti.DataSource = l
        End Using

    End Sub

    Private Sub CaricaRichiesteAppese()

        Using mgr As New MagazzinoDAO
            Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdOrdineAcquisto, 0),
                                                               New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.RichiestaAcquisto))

            l.Sort(AddressOf Comparer)

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

    Friend Function Carica(Optional IdOrdineAcquisto As Integer = 0) As Integer
        _IdOrdineAcquisto = IdOrdineAcquisto
        If IdOrdineAcquisto Then
            Using O As New OrdineAcquisto
                O.Read(IdOrdineAcquisto)
                dtQuando.Value = O.Quando
                txtAnnotazioni.Text = O.Annotazioni
            End Using

            CaricaRichieste()
            btnAddRichiesta.Visible = False
            btnDelRichiesta.Visible = False

        Else
            dtQuando.Value = Now

            CaricaRichiesteAppese()

        End If

        ShowDialog()

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

        If MessageBox.Show("Confermi il salvataggio dell' ordine di acquisto?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If DgMovimenti.Rows.Count Then

                Using o As New OrdineAcquisto
                    o.Read(_IdOrdineAcquisto)

                    o.Quando = dtQuando.Value
                    o.Annotazioni = txtAnnotazioni.Text
                    o.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
                    o.Save()

                    For Each m In o.Richieste
                        m.IdOrdineAcquisto = 0
                        m.Save()
                    Next

                    For Each r In DgMovimenti.Rows
                        Dim M As MovimentoMagazzino = r.DataBoundItem
                        M.IdOrdineAcquisto = o.IdOrdineAcquisto
                        M.Save()
                    Next

                End Using

                _Ris = 1
                Close()

            Else
                MessageBox.Show("Inserire almeno una richiesta di acquisto nell'ordine")
            End If
        End If
    End Sub

    Private Sub btnStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnStampa.LinkClicked
        If _IdOrdineAcquisto Then
            Using O As New OrdineAcquisto
                O.Read(_IdOrdineAcquisto)
                MgrOrdiniAcquisto.Stampa(O)
            End Using
        Else
            Beep()
        End If
    End Sub

    Private Sub btnDelListBase_Click(sender As Object, e As EventArgs) Handles btnDelRichiesta.Click
        If DgMovimenti.SelectedRows.Count Then

            Dim M As MovimentoMagazzino = DgMovimenti.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi l'eliminazione della richiesta selezionata dall'ordine?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

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

        Sottofondo()

        Dim ListaId As String = String.Empty
        For Each r In DgMovimenti.Rows
            Dim m As MovimentoMagazzino = r.DataBoundItem
            ListaId &= m.IdCarMag & ","
        Next

        'ListaId = ListaId.TrimEnd(",")

        Using f As New frmMagazzinoAddRichiesta

            Dim Ris As Integer = f.Carica(_IdOrdineAcquisto,, ListaId)
            If Ris Then
                CaricaRichiesteAppese()
            End If

        End Using

        Sottofondo()

    End Sub

    Private Sub DgMovimenti_Click(sender As Object, e As EventArgs) Handles DgMovimenti.Click

    End Sub

    Private Sub DgMovimenti_DoubleClick(sender As Object, e As EventArgs) Handles DgMovimenti.DoubleClick

        'qui devo riaprire la voce 
        If DgMovimenti.SelectedRows.Count Then
            Dim m As MovimentoMagazzino = DgMovimenti.SelectedRows(0).DataBoundItem

            Sottofondo()

            Using f As New frmMagazzinoAddRichiesta
                If f.Carica(_IdOrdineAcquisto, m.IdCarMag) Then
                    If _IdOrdineAcquisto Then
                        CaricaRichieste()
                    Else
                        CaricaRichiesteAppese 
                    End If
                End If
            End Using

            Sottofondo()

        End If

    End Sub

End Class