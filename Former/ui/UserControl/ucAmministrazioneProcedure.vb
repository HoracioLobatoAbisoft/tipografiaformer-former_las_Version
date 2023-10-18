Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucAmministrazioneProcedure
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        ParentFormEx.Sottofondo()

        Using f As New frmProcedura
            If f.Carica() Then CaricaDati()
        End Using

        ParentFormEx.Sottofondo()

    End Sub

    Private Shared Function Comparer(ByVal x As Procedura, ByVal y As Procedura) As Integer
        Dim result As Integer = x.Macchinario.Descrizione.CompareTo(y.Macchinario.Descrizione)
        If result = 0 Then result = x.Lavorazione.Descrizione.CompareTo(y.Lavorazione.Descrizione)
        If result = 0 Then result = x.Nome.CompareTo(y.Nome)

        Return result
    End Function

    Private Sub CaricaDati()
        Using mgr As New ProcedureDAO
            Dim l As List(Of Procedura) = mgr.GetAll()

            l.Sort(AddressOf Comparer)

            dgProcedure.AutoGenerateColumns = False
            dgProcedure.DataSource = l

        End Using
    End Sub

    Private Sub lnkRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked

        CaricaDati()

    End Sub

    Private Sub ModificaProcedura()
        If dgProcedure.SelectedRows.Count Then
            Dim row As DataGridViewRow = dgProcedure.SelectedRows(0)
            Dim P As Procedura = row.DataBoundItem
            ParentFormEx.Sottofondo()

            Using f As New frmProcedura
                If f.Carica(P.IdProcedura) Then CaricaDati()
            End Using

            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub dgProcedure_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProcedure.CellDoubleClick
        ModificaProcedura()
    End Sub

    Private Sub lnkModFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModFormato.LinkClicked
        ModificaProcedura()
    End Sub

    Private Sub EliminaProcedura()
        If dgProcedure.SelectedRows.Count Then
            Dim row As DataGridViewRow = dgProcedure.SelectedRows(0)
            Dim P As Procedura = row.DataBoundItem

            If MessageBox.Show("Confermi l'eliminazione della procedura selezionata?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New StepProcedureDAO
                    mgr.DeleteByIdProc(P.IdProcedura)
                End Using
                Using mgr As New ProcedureDAO
                    mgr.Delete(P.IdProcedura)
                End Using
                CaricaDati()
            End If

        End If
    End Sub

    Private Sub lnkDelFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelFormato.LinkClicked
        EliminaProcedura
    End Sub
End Class
