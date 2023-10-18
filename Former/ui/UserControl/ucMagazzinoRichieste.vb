Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports Telerik.WinControls.UI

Public Class ucMagazzinoRichieste
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        MgrControl.InizializeGridview(DgMovimenti)

    End Sub

    Public Sub Carica()

    End Sub

    Private Sub lnkDel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked
        If DgMovimenti.SelectedRows.Count Then

            Dim M As MovimentoMagazzino = DgMovimenti.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi l'eliminazione della richiesta selezionata?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New MagazzinoDAO
                    mgr.Delete(M)
                    'mgr.AggiornaQta(M.IdRis)
                    DgMovimenti.Rows.Remove(DgMovimenti.SelectedRows(0))
                End Using
            End If

        End If
    End Sub

    Private Sub lnkAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        Cerca()
    End Sub

    Private Sub Cerca()
        Cursor.Current = Cursors.WaitCursor
        Using mgr As New MagazzinoDAO

            Dim PTipo As LUNA.LunaSearchParameter = Nothing
            Dim POrdAcq As LUNA.LunaSearchParameter = Nothing

            PTipo = New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.RichiestaAcquisto)
            POrdAcq = New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdOrdineAcquisto, 0)

            Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(LFM.MovimentoMagazzino.DataMov.Name & " DESC",
                                                                PTipo,
                                                                POrdAcq)

            l.Sort(Function(x, y) x.Risorsa.Descrizione.CompareTo(y.Risorsa.Descrizione))

            DgMovimenti.DataSource = l

        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub DgMovimenti_Click(sender As Object, e As EventArgs) Handles DgMovimenti.Click

    End Sub

    Private Sub DgMovimenti_DoubleClick(sender As Object, e As EventArgs) Handles DgMovimenti.DoubleClick
        If DgMovimenti.SelectedRows.Count Then

            Dim M As MovimentoMagazzino = DgMovimenti.SelectedRows(0).DataBoundItem

            ParentFormEx.Sottofondo()

            Using f As New frmMagazzinoMovimento
                f.Carica(M.IdCarMag)
            End Using

            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub lnkStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""

        Titolo = "Movimenti magazzino"

        StampaGlobale(Titolo, DgMovimenti)
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkNuovo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNuovo.LinkClicked

        ParentFormEx.Sottofondo()

        Using f As New frmMagazzinoOrdineAcquisto

            f.Carica()

        End Using

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub dgMovimenti_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles DgMovimenti.ViewCellFormatting

        If TypeOf e.CellElement Is GridImageCellElement Then
            e.Row.Height = 64
        End If

    End Sub
End Class
