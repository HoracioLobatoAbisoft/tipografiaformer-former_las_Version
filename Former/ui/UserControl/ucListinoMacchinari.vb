Imports FormerDALSql

Public Class ucListinoMacchinari
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Public Sub Carica()
        Try
            CaricaMacchinari()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CaricaMacchinari()

        Using mgr As New MacchinariDAO
            Dim l As List(Of Macchinario) = mgr.GetAll(LFM.Macchinario.Descrizione)

            dgMacchinari.AutoGenerateColumns = False
            dgMacchinari.DataSource = l
        End Using

    End Sub

    Private Sub lnkAddFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddFormato.LinkClicked
        ParentFormEx.Sottofondo()

        Dim m As New frmListinoMacchinario

        If m.Carica() Then
            CaricaMacchinari()
        End If

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub ModificaMacchinario()

        If dgMacchinari.SelectedRows.Count Then
            Dim v As Macchinario = dgMacchinari.SelectedRows(0).DataBoundItem

            Dim IdRif As Integer = 0
            IdRif = v.IdMacchinario
            ParentFormEx.Sottofondo()

            Dim Ris As Integer = 0, x As New frmListinoMacchinario
            Ris = x.Carica(IdRif)
            If Ris Then CaricaMacchinari()
            x = Nothing
            ParentFormEx.Sottofondo()
        End If

    End Sub

    Private Sub lnkModFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModFormato.LinkClicked
        ModificaMacchinario()
    End Sub

    Private Sub dgMacchinari_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMacchinari.CellDoubleClick
        ModificaMacchinario()
    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click
        CaricaMacchinari()
    End Sub

    Private Sub btnOrdineMacchinari_Click(sender As Object, e As EventArgs) Handles btnOrdineMacchinari.Click

        ParentFormEx.Sottofondo()

        Using frm As New frmListinoOrdineMacchinari
            frm.Carica()
        End Using

        ParentFormEx.Sottofondo()

    End Sub

End Class
