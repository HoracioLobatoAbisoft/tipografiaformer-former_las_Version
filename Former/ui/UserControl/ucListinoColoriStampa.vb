Imports FormerDALSql
Public Class ucListinoColoriStampa
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Private Sub ucResa_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Public Sub CaricaDati()
        Try
            CaricaColoriStampa()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CaricaColoriStampa()

        Dim l As List(Of ColoreStampa) = Nothing
        Using mgr As New ColoriStampaDAO
            l = mgr.GetAll(LFM.ColoreStampa.Descrizione)
        End Using
        dgColori.AutoGenerateColumns = False
        dgColori.DataSource = l


    End Sub

    Private Sub lnkAddFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddFormato.LinkClicked

        ParentFormEx.Sottofondo()
        Dim ris As Integer = 0
        Using frm As New frmListinoColoreStampa
            ris = frm.Carica()
        End Using
        If ris Then CaricaColoriStampa()

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub lnkDelFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelFormato.LinkClicked
        EliminaColoreStampa()
        'If dgResa.SelectedRows.Count Then
        '    Dim R As Resa = dgResa.SelectedRows(0).DataBoundItem
        '    If MessageBox.Show("Confermi la cancellazione della combinazione di resa selezionata?", "Cancellazione Resa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '        Dim Rmg As New ResaDAO
        '        Rmg.Delete(R)
        '        CaricaColoriStampa()
        '    End If
        'Else
        '    MessageBox.Show("Selezionare una voce dalla lista!")
        'End If

    End Sub

    Private Sub dgResa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgColori.CellContentClick

    End Sub

    Private Sub lnkModFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModFormato.LinkClicked
        ModificaColoreStampa()
    End Sub

    Private Sub EliminaColoreStampa()
        If dgColori.SelectedRows.Count Then

            Dim v As ColoreStampa = dgColori.SelectedRows(0).DataBoundItem
            If MessageBox.Show("Confermi l'eliminazione del colore di stampa '" & v.Descrizione & "'?", "Eliminazione Colore di stampa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Using mgr As New ListinoBaseDAO
                    Dim l As List(Of ListinoBase) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.IdColoreStampa, v.IdColoreStampa))
                    If l.Count = 0 Then
                        Using mgrC As New ColoriStampaDAO
                            mgrC.Delete(v.IdColoreStampa)
                        End Using
                        CaricaColoriStampa()
                    Else
                        Dim buffer As String = String.Empty

                        For Each singl In l
                            buffer &= singl.NomeEx & ", "
                        Next

                        buffer = buffer.TrimEnd(" ", ",")

                        MessageBox.Show("Il colore di stampa non può essere utilizzato perchè in uso nei seguenti listini base: " & buffer)
                    End If
                End Using
            End If
        Else
            MessageBox.Show("Selezionare un Colore di Stampa")
        End If
    End Sub

    Private Sub DuplicaColoreStampa()
        If dgColori.SelectedRows.Count Then
            Dim v As ColoreStampa = dgColori.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi la duplicazione del colore di stampa '" & v.Descrizione & "'?", "Duplicazione Colore di stampa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then

                Dim c As ColoreStampa = v.Clone
                c.IdColoreStampa = 0
                c.Descrizione &= " Copia"
                c.Sigla &= "-Copia"
                If c.IsValid Then
                    c.Save()
                    CaricaColoriStampa()
                Else
                    MessageBox.Show("Duplicazione non effettuata! Ci sono dei dati nel oggetto selezionato per la duplicazione che non sono validi.")
                End If
            End If
        Else
            MessageBox.Show("Selezionare un Colore di Stampa")
        End If
    End Sub

    Private Sub ModificaColoreStampa()
        If dgColori.SelectedRows.Count Then

            Dim v As ColoreStampa = dgColori.SelectedRows(0).DataBoundItem

            Dim IdRif As Integer = 0
            IdRif = v.IdColoreStampa
            ParentFormEx.Sottofondo()

            Dim Ris As Integer = 0, x As New frmListinoColoreStampa
            Ris = x.Carica(IdRif)
            If Ris Then CaricaColoriStampa()
            x = Nothing
            ParentFormEx.Sottofondo()
        Else
            MessageBox.Show("Selezionare un Colore di Stampa")
        End If
    End Sub

    Private Sub dgColori_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgColori.CellDoubleClick
        ModificaColoreStampa()
    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs)
        CaricaColoriStampa()
    End Sub

    Private Sub lnkDuplica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDuplica.LinkClicked
        DuplicaColoreStampa()
    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        CaricaColoriStampa()
    End Sub
End Class
