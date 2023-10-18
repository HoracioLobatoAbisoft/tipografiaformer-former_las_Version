Imports FormerDALSql
Public Class ucListinoResa
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Public Sub Carica()
        Try
            CaricaResa()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CaricaResa()

        Using mgr As New ResaDAO
            Dim l As List(Of Resa) = mgr.GetAll(LFM.Resa.IdFormCarta)

            dgResa.AutoGenerateColumns = False
            dgResa.DataSource = l
        End Using

    End Sub

    Private Sub AggiungiResa()
        ParentFormEx.Sottofondo()
        Dim ris As Integer = 0
        Using frm As New frmListinoResa
            ris = frm.Carica()
        End Using
        If ris Then CaricaResa()

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkAddFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddFormato.LinkClicked
        AggiungiResa()
    End Sub

    Private Sub ModificaResa()
        If dgResa.SelectedRows.Count Then
            Dim R As Resa = dgResa.SelectedRows(0).DataBoundItem
            Dim Ris As Integer = 0
            Using frm As New frmListinoResa
                ParentFormEx.Sottofondo()
                Ris = frm.Carica(R.IDFormatoResa)
                ParentFormEx.Sottofondo()
            End Using
            If Ris Then CaricaResa()
        Else
            MessageBox.Show("Selezionare una voce dalla lista!")
        End If
    End Sub

    Private Sub EliminaResa()
        If dgResa.SelectedRows.Count Then
            Dim R As Resa = dgResa.SelectedRows(0).DataBoundItem
            If MessageBox.Show("Confermi la cancellazione della combinazione di resa selezionata?", "Cancellazione Resa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using Rmg As New ResaDAO
                    Rmg.Delete(R)
                End Using
                CaricaResa()
            End If
        Else
            MessageBox.Show("Selezionare una voce dalla lista!")
        End If
    End Sub

    Private Sub lnkDelFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelFormato.LinkClicked
        EliminaResa()
    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click
        CaricaResa()
    End Sub

    Private Sub lnkMod_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMod.LinkClicked
        ModificaResa()
    End Sub
End Class
