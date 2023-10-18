Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucCommesseModelli
    Inherits ucFormerUserControl

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        CaricaCombo()

    End Sub

    Public Sub CaricaByIdFormatoProdotto(IdFormatoProdotto As Integer,
                                         Optional IdColoreStampa As Integer = 0)

        CaricaModelliCommessa(, IdFormatoProdotto, IdColoreStampa)

    End Sub

    Public Sub CaricaByIdFormatoCarta(IdFormatoCarta As Integer)

        CaricaModelliCommessa(IdFormatoCarta)

    End Sub

    Private Sub CaricaCombo()
        Try
            Using M As New MacchinariDAO
                cmbMacchinario.ValueMember = "IdMacchinario"
                cmbMacchinario.DisplayMember = "Descrizione"
                cmbMacchinario.DataSource = M.FindAll(New LUNA.LunaSearchOption With {.OrderBy = LFM.Macchinario.Descrizione.Name, .AddEmptyItem = True},
                                                      New LUNA.LunaSearchParameter(LFM.Macchinario.Tipo, enTipoMacchinario.Produzione))
            End Using

            Dim lstFM As List(Of Formato) = Nothing
            Using Mgr As New FormatiDAO
                lstFM = Mgr.GetAll(LFM.Formato.Formato, True)
            End Using

            cmbFormMacchina.ValueMember = "IdFormato"
            cmbFormMacchina.DisplayMember = "Formato"
            cmbFormMacchina.DataSource = lstFM
        Catch ex As Exception

        End Try

        CaricaFormatiProdotto()



    End Sub

    Private Sub CaricaFormatiProdotto()
        Try
            Using mgr As New FormatiProdottoDAO

                Dim l As List(Of FormatoProdotto) = Nothing

                l = mgr.GetAll(LFM.FormatoProdotto.Formato,
                               True)

                cmbFormProd.DataSource = l

            End Using
        Catch ex As Exception

        End Try


    End Sub

    Public Event ModelloCommessaSelezionato()

    Public Property IdModelloCommessa As Integer = 0

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked
        CaricaModelliCommessa()
    End Sub

    Private Sub lnkDuplicaModCommessa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        DuplicaModello()
    End Sub

    Private Sub lnkAggModello_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Aggiungi()

        ParentFormEx.Sottofondo()
        Dim M As New frmCommessaModello, Ris As Integer = 0
        Ris = M.Carica()
        M = Nothing
        If Ris Then CaricaModelliCommessa()
        ParentFormEx.Sottofondo()

    End Sub

    Public Sub Carica()

        CaricaModelliCommessa()

    End Sub

    Private Sub CaricaModelliCommessa(Optional IdFormatoCarta As Integer = 0,
                                      Optional IdFormatoProdotto As Integer = 0,
                                      Optional IdColoreStampa As Integer = 0)

        dgModelliCommessa.AutoGenerateColumns = False
        Using Mgr As New ModelliCommessaDAO
            Dim para As LUNA.LunaSearchParameter = Nothing
            Dim parGanging As LUNA.LunaSearchParameter = Nothing
            If txtCerca.Text.Trim.Length Then
                para = New LUNA.LunaSearchParameter(LFM.ModelloCommessa.Nome, "%" & txtCerca.Text & "%", " like ")
            End If

            If chkShowFromGanging.Checked = False Then
                parGanging = New LUNA.LunaSearchParameter(LFM.ModelloCommessa.FromGanging, enSiNo.No)
            Else
                parGanging = New LUNA.LunaSearchParameter(LFM.ModelloCommessa.FromGanging, enSiNo.Si)
            End If

            Dim parMacc As LUNA.LunaSearchParameter = Nothing
            Dim parFormatoMacchina As LUNA.LunaSearchParameter = Nothing

            If cmbMacchinario.SelectedValue Then
                parMacc = New LUNA.LunaSearchParameter(LFM.ModelloCommessa.IdMacchinarioDef, cmbMacchinario.SelectedValue)
            End If

            If cmbFormMacchina.SelectedValue Then
                parFormatoMacchina = New LUNA.LunaSearchParameter(LFM.ModelloCommessa.IdFormatoMacchina, cmbFormMacchina.SelectedValue)
            End If

            Dim l As List(Of ModelloCommessa) = Mgr.FindAll(LFM.ModelloCommessa.Nome, para, parGanging, parMacc, parFormatoMacchina)
            For Each m As ModelloCommessa In l
                m.CaricaFormatiProdotto()
            Next

            If IdFormatoCarta Then
                l = l.FindAll(Function(x) x.FormatiProdotto.FindAll(Function(y) y.FormatoProdotto.IdFormCarta = IdFormatoCarta).Count > 0)
            ElseIf IdFormatoProdotto Then
                l = l.FindAll(Function(x) x.FormatiProdotto.FindAll(Function(y) y.IdFormProd = IdFormatoProdotto).Count > 0)
            Else
                If Not cmbFormProd.SelectedItem Is Nothing Then
                    Dim fp As FormatoProdotto = cmbFormProd.SelectedItem

                    If fp.IdFormProd Then
                        l = l.FindAll(Function(x) x.FormatiProdotto.FindAll(Function(y) y.IdFormProd = fp.IdFormProd).Count > 0)
                    End If

                End If

            End If

            If IdColoreStampa Then
                Using C As New ColoreStampa
                    C.Read(IdColoreStampa)

                    If C.FR Then
                        'qui e' fronte retro
                        l = l.FindAll(Function(x) x.FronteRetro = enSiNo.Si)
                    Else
                        l = l.FindAll(Function(x) x.FronteRetro = enSiNo.No)
                    End If

                End Using
            End If

            dgModelliCommessa.DataSourceVirtual = l

        End Using
    End Sub

    Private Sub DuplicaModello()
        If dgModelliCommessa.SelectedRows.Count Then
            If MessageBox.Show("Confermi la duplicazione del modello comessa selezionato?", "Duplica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim M As ModelloCommessa = dgModelliCommessa.SelectedRows(0).DataBoundItem

                Dim MNew As ModelloCommessa = M.Clone
                MNew.IdModello = 0
                MNew.Nome &= " Copia"
                MNew.Save()

                ParentFormEx.Sottofondo()
                Using F As New frmCommessaModello
                    Dim Ris As Integer = F.Carica(MNew.IdModello)
                End Using
                ParentFormEx.Sottofondo()

            End If
        End If
    End Sub

    Private Sub lnkEditModello_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        ModificaModello()
    End Sub

    Private Sub lnkDelModello_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        EliminaModello()
    End Sub

    Private Sub EliminaModello()
        If MessageBox.Show("Confermi l'eliminazione del modello commessa selezionato?", "Eliminazione modello", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If dgModelliCommessa.SelectedRows.Count Then
                Dim m As ModelloCommessa = dgModelliCommessa.SelectedRows(0).DataBoundItem

                Using mgr As New ModelliCommessaDAO
                    'qui devo andare a prendere l'id del modello selezionato e e eliminarlo se non e' utilizzato da niente
                    Using mgrC As New CommesseDAO
                        Dim lC As List(Of Commessa) = mgrC.FindAll(New LUNA.LunaSearchParameter(LFM.Commessa.IdModelloCommessa, m.IdModello))
                        If lC.Count = 0 Then
                            mgr.Delete(m.IdModello)
                            CaricaModelliCommessa()
                        Else
                            MessageBox.Show("Il modello commessa non può essere eliminato perchè é utilizzato in una o piu commesse")
                        End If
                    End Using

                End Using

            End If
        End If
    End Sub

    Private Sub dgModelliCommessa_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgModelliCommessa.ColumnHeaderMouseClick
        OrdinatoreLista(Of ModelloCommessa).OrdinaLista(sender, e)
    End Sub

    Private Sub dgModelliCommessa_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgModelliCommessa.RowPostPaint
        Try
            '
            Dim M As ModelloCommessa = DirectCast(dgModelliCommessa.Rows(e.RowIndex).DataBoundItem, ModelloCommessa)

            If Not M Is Nothing Then
                Dim Err As Boolean = False
                If M.FormatiProdotto.Count = 0 Then Err = True
                If M.IdMacchinarioDef = 0 Then Err = True
                If M.IdFormatoMacchina = 0 Then Err = True
                If Err Then dgModelliCommessa.Rows(e.RowIndex).Cells(1).Style.BackColor = Color.Red
            End If
            'End If

            'Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgModelliCommessa_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgModelliCommessa.CellDoubleClick
        ModificaModello()
    End Sub

    Private Sub ModificaModello()
        If dgModelliCommessa.SelectedRows.Count Then
            Dim M As ModelloCommessa = dgModelliCommessa.SelectedRows(0).DataBoundItem
            ParentFormEx.Sottofondo()
            Dim F As New frmCommessaModello
            Dim Ris As Integer = F.Carica(M.IdModello)

            ParentFormEx.Sottofondo()
        End If
    End Sub

    Private Sub dgModelliCommessa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgModelliCommessa.CellClick
        If dgModelliCommessa.SelectedRows.Count Then

            Dim M As ModelloCommessa = dgModelliCommessa.SelectedRows(0).DataBoundItem

            IdModelloCommessa = M.IdModello

            RaiseEvent ModelloCommessaSelezionato()

        End If
    End Sub

    Private Sub txtCerca_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCerca.KeyDown

        If e.KeyCode = Keys.Enter Then
            CaricaModelliCommessa()
        End If

    End Sub

    Private Sub txtCerca_TextChanged(sender As Object, e As EventArgs) Handles txtCerca.TextChanged

    End Sub

    Private Sub cmbFormProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormProd.SelectedIndexChanged
        CaricaModelliCommessa()
    End Sub

    Private Sub DuplicaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicaToolStripMenuItem.Click
        DuplicaModello()
    End Sub

    Private Sub AggiungiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggiungiToolStripMenuItem.Click
        Aggiungi()
    End Sub

    Private Sub ModificaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaToolStripMenuItem.Click
        ModificaModello()
    End Sub

    Private Sub RimuoviToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RimuoviToolStripMenuItem.Click
        EliminaModello()
    End Sub

    Private Sub AttivaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AttivaToolStripMenuItem1.Click
        SetStatoAttivo
    End Sub

    Private Sub SetStatoAttivo()
        If dgModelliCommessa.SelectedRows.Count Then
            If MessageBox.Show("Confermi il cambiamento di stato del modello selezionato?", "Cambio stato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim M As ModelloCommessa = dgModelliCommessa.SelectedRows(0).DataBoundItem
                If M.Disattivo = enSiNo.Si Then
                    M.Disattivo = enSiNo.No
                    M.Save()
                    CaricaModelliCommessa()
                Else
                    MessageBox.Show("Il modello è già attivo")
                End If
            End If
        End If
    End Sub

    Private Sub DisattivaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DisattivaToolStripMenuItem1.Click
        SetStatoDisattivo
    End Sub

    Private Sub SetStatoDisattivo()
        If dgModelliCommessa.SelectedRows.Count Then
            If MessageBox.Show("Confermi il cambiamento di stato del modello selezionato?", "Cambio stato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim M As ModelloCommessa = dgModelliCommessa.SelectedRows(0).DataBoundItem
                If M.Disattivo = enSiNo.No Then
                    M.Disattivo = enSiNo.Si
                    M.Save()
                    CaricaModelliCommessa()
                Else
                    MessageBox.Show("Il modello è già non attivo")
                End If
            End If
        End If
    End Sub

End Class
