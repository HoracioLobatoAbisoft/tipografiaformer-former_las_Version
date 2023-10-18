Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports Telerik.WinControls.UI

Public Class ucMagazzinoDecodificaVociCosto
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        MgrControl.InizializeGridview(DgDecodifiche)

    End Sub

    Public Sub Carica()
        CaricaCombo()
    End Sub

    Private Sub CaricaCombo()

    End Sub

    Private _IdRis As Integer = 0
    Public WriteOnly Property IdRis As Integer
        Set(value As Integer)
            _IdRis = value
            DgDecodifiche.Columns.Item("Risorsa").IsVisible = False
        End Set
    End Property

    Private _IdFornitore As Integer = 0
    Public WriteOnly Property IdFornitore As Integer
        Set(value As Integer)
            _IdFornitore = value
            DgDecodifiche.Columns.Item("Fornitore").IsVisible = False
        End Set
    End Property

    Private Sub lnkAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked

        MostraDati()

    End Sub

    Private Sub MostraDati()

        Using mgr As New DecodificaVociCostoDAO

            Dim p As LUNA.LunaSearchParameter = Nothing
            If _IdRis Then
                p = New LUNA.LunaSearchParameter(LFM.DecodificaVoceCosto.IdRis, _IdRis)
            End If

            Dim p1 As LUNA.LunaSearchParameter = Nothing
            If _IdFornitore Then
                p1 = New LUNA.LunaSearchParameter(LFM.DecodificaVoceCosto.IdFornitore, _IdFornitore)
            End If

            Dim l As List(Of DecodificaVoceCosto) = mgr.FindAll(p, p1)

            DgDecodifiche.DataSource = l


        End Using

    End Sub

    Private Sub DgDecodifiche_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles DgDecodifiche.ViewCellFormatting

        If TypeOf e.CellElement Is GridImageCellElement Then
            e.Row.Height = 64
        End If

    End Sub

    Private Sub lnkDel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked
        EliminaDecodifica()
    End Sub

    Private Sub EliminaDecodifica()
        If DgDecodifiche.SelectedRows.Count Then

            Dim M As DecodificaVoceCosto = DgDecodifiche.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi l'eliminazione della decodifica selezionata?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New DecodificaVociCostoDAO
                    mgr.Delete(M)
                    'mgr.AggiornaQta(M.IdRis)
                    DgDecodifiche.Rows.Remove(DgDecodifiche.SelectedRows(0))
                End Using
            End If

        End If
    End Sub

End Class
