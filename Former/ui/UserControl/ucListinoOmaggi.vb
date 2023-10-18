Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucListinoOmaggi
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Carica()

    End Sub

    Private Sub lnkRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        CaricaDati
    End Sub

    Private Sub CaricaDati()

        Cursor.Current = Cursors.WaitCursor
        Using mgr As New OmaggiDAO

            Dim l As List(Of Omaggio) = mgr.GetAll(LFM.Omaggio.IdOmaggio)

            l.Sort(Function(x, y) x.NomeOmaggio.CompareTo(y.NomeOmaggio))

            DgOmaggi.AutoGenerateColumns = False
            DgOmaggi.DataSource = l

        End Using
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        Dim Ris As Integer = 0
        Using f As New frmListinoRegolaOmaggio
            ParentFormEx.Sottofondo()
            Ris = f.Carica()
            ParentFormEx.Sottofondo()
        End Using

        If Ris Then CaricaDati()

    End Sub

    Private Sub DgOmaggi_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgOmaggi.CellDoubleClick

        ModificaVoce()

    End Sub

    Private Sub ModificaVoce()

        If DgOmaggi.SelectedRows.Count Then
            Dim O As Omaggio = DgOmaggi.SelectedRows(0).DataBoundItem

            Dim Ris As Integer = 0
            Using f As New frmListinoRegolaOmaggio
                ParentFormEx.Sottofondo()
                Ris = f.Carica(O.IdOmaggio)
                ParentFormEx.Sottofondo()
            End Using

            If Ris Then CaricaDati()

        End If

    End Sub

    Private Sub lnkModifica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModifica.LinkClicked

        ModificaVoce()

    End Sub

    Private Sub lnkDel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked

        If DgOmaggi.SelectedRows.Count Then
            If MessageBox.Show("Confermi l'eliminazione della regola omaggio selezionata?", "Eliminazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim O As Omaggio = DgOmaggi.SelectedRows(0).DataBoundItem

                Using mgr As New OmaggiDAO

                    mgr.Delete(O.IdOmaggio)

                End Using

                CaricaDati()

            End If
        End If

    End Sub
End Class

