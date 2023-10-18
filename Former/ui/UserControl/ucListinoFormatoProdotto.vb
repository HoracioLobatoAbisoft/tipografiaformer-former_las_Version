Imports FormerDALSql

Public Class ucListinoFormatiProdotto
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Private Sub toolRubrica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolIniziale.Click
        Dim But As ToolStripButton
        For Each But In toolIniziale.Items
            If But.Checked And Not But Is sender Then
                But.Checked = False
            End If
        Next
    End Sub

    Private Sub CaricaFormati(Optional Iniziale As String = "")

        Using mgr As New FormatiProdottoDAO

            Dim l As List(Of FormatoProdottoEx) = mgr.ListaFormati(Iniziale)

            If rdoFPStandard.Checked Then
                l = l.FindAll(Function(x) x.ProdottoFinito = False)
            ElseIf rdoFPOnlyProd.Checked Then
                l = l.FindAll(Function(x) x.ProdottoFinito = True)
            End If

            dgFormati.AutoGenerateColumns = False
            dgFormati.DataSource = l
        End Using
    End Sub

    Private Sub lnkAddFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddFormato.LinkClicked
        ParentFormEx.Sottofondo()

        Dim f As New frmListinoFormatoProdotto

        Dim ris As Integer = f.Carica()
        f = Nothing

        If ris Then
            CaricaFormati()
        End If

        ParentFormEx.Sottofondo()
    End Sub
    Private Sub ModificaFormatoProdotto(Optional IdFormatoProdotto As Integer = 0)
        Dim IdRif As Integer = 0

        If IdFormatoProdotto Then
            IdRif = IdFormatoProdotto
        Else
            If dgFormati.SelectedRows.Count Then

                Dim v As FormatoProdottoEx = dgFormati.SelectedRows(0).DataBoundItem

                IdRif = v.IdFormProd

            End If

        End If

        If IdRif Then
            ParentFormEx.Sottofondo()

            Dim Ris As Integer = 0
            Using x As New frmListinoFormatoProdotto
                Ris = x.Carica(IdRif)
            End Using

            If Ris Then CaricaFormati()

            ParentFormEx.Sottofondo()

        End If

    End Sub

    Public Sub CaricaDati()
        Try
            CaricaFormati()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lnkModFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModFormato.LinkClicked
        ModificaFormatoProdotto()
    End Sub

    Private Sub dgFormati_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFormati.CellContentClick

    End Sub

    Private Sub dgCatFormati_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCatFormato.CellDoubleClick
        ModificaCat()
    End Sub

    Private Sub dgFormati_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFormati.CellDoubleClick
        ModificaFormatoProdotto()
    End Sub

    Private Sub rdoFPTutti_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFPTutti.CheckedChanged
        If sender.focused Then CaricaFormati()
    End Sub

    Private Sub rdoFPStandard_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFPStandard.CheckedChanged
        If sender.focused Then CaricaFormati()
    End Sub

    Private Sub rdoFPOnlyProd_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFPOnlyProd.CheckedChanged
        If sender.focused Then CaricaFormati()
    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click
        CaricaFormati()
    End Sub

    Private Sub toolRubrica_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles toolIniziale.ItemClicked
        CaricaFormati(e.ClickedItem.Text)
    End Sub

    Private Sub lnkDuplica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDuplica.LinkClicked

        If dgFormati.SelectedRows.Count Then
            Dim v As FormatoProdottoEx = dgFormati.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi la duplicazione del formato '" & v.Formato & "'?", "Duplicazione Formato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using formProd As FormatoProdottoEx = v.Clone

                    formProd.Formato &= " Copia"
                    formProd.Sigla &= "-Copia"

                    formProd.IdFormProd = 0
                    If formProd.IsValid Then
                        formProd.Save()
                        'CaricaFormati()
                        ModificaFormatoProdotto(formProd.IdFormProd)
                    Else
                        MessageBox.Show("Duplicazione non effettuata! Ci sono dei dati nel oggetto selezionato per la duplicazione che non sono validi.")
                    End If


                End Using
            End If
        Else
            MessageBox.Show("Selezionare un formato prodotto!")
        End If
    End Sub

    Private Sub lnkDelFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelFormato.LinkClicked
        If dgFormati.SelectedRows.Count Then
            Dim v As FormatoProdottoEx = dgFormati.SelectedRows(0).DataBoundItem

            If MessageBox.Show("Confermi l'eliminazione del formato '" & v.Formato & "'?", "Eliminazione Formato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Using mgrL As New ListinoBaseDAO
                    Dim L As List(Of ListinoBase) = mgrL.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.IdFormProd, v.IdFormProd))
                    If L.Count = 0 Then

                        Using mgr As New FormatiProdottoDAO
                            mgr.Delete(v.IdFormProd)
                            CaricaFormati()
                        End Using
                    Else
                        Dim buffer As String = String.Empty
                        For Each singL In L
                            buffer &= singL.NomeEx & ", "
                        Next

                        buffer = buffer.TrimEnd(" ", ",")

                        MessageBox.Show("Il fomato prodotto non e' eliminabile perche utilizzato nei seguenti listini base: " & buffer)
                    End If
                End Using

            End If
        Else
            MessageBox.Show("Selezionare un formato prodotto!")
        End If
    End Sub

    Private Sub btnCaricaCat_Click(sender As Object, e As EventArgs) Handles btnCaricaCat.Click
        CaricaCat()
    End Sub

    Private Sub CaricaCat()

        Using mgr As New CatFormatoProdottoDAO

            Dim l As List(Of CatFormatoProdotto) = mgr.GetAll

            dgCatFormato.AutoGenerateColumns = False
            dgCatFormato.DataSource = l
        End Using
    End Sub

    Private Sub lnkAddCat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddCat.LinkClicked

        Using f As New frmListinoCatFormato
            ParentFormEx.Sottofondo()
            Dim Ris As Integer = f.Carica()
            ParentFormEx.Sottofondo()
            If Ris Then
                CaricaCat()
            End If

        End Using

    End Sub

    Private Sub ModificaCat()
        If dgCatFormato.SelectedRows.Count Then

            Dim v As CatFormatoProdotto = dgCatFormato.SelectedRows(0).DataBoundItem

            Dim IdRif As Integer = 0
            IdRif = v.IdCatFormatoProdotto
            ParentFormEx.Sottofondo()

            Dim Ris As Integer = 0, x As New frmListinoCatFormato
            Ris = x.Carica(IdRif)
            If Ris Then CaricaCat()
            x = Nothing
            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub lnkModCat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModCat.LinkClicked

        ModificaCat()

    End Sub
End Class
