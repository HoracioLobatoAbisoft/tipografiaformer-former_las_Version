Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Public Class ucListinoFustelle
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        CaricaCombo()

    End Sub

    Public Sub CaricaCombo()
        Try
            Using mgr As New PreventivazioniDAO
                Dim l As List(Of Preventivazione) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Descrizione", .AddEmptyItem = True},
                                                                New LUNA.LunaSearchParameter(LFM.Preventivazione.IdPrev, "(Select distinct IdPrev from t_tipoFustella)", "IN"))

                cmbPrev.DataSource = l
                cmbPrev.DisplayMember = "Descrizione"
                cmbPrev.ValueMember = "IdPrev"

            End Using

            Using mgr As New CategorieFustelleDAO
                Dim l As List(Of CategoriaFustella) = mgr.GetAll(LFM.CategoriaFustella.Categoria,
                                                                 True)
                cmbCat.DataSource = l
                cmbCat.DisplayMember = "Categoria"
                cmbCat.ValueMember = "IdCatFustella"

            End Using
        Catch ex As Exception
            '  MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CaricaFustelle()

        Using mgr As New FustelleDAO
            Dim l As List(Of Fustella) = mgr.GetAll(LFM.Fustella.Codice)

            DgFustelle.AutoGenerateColumns = False
            DgFustelle.DataSource = l

        End Using
    End Sub

    Private Sub CaricaCat()

        Using mgr As New CategorieFustelleDAO
            Dim l As List(Of CategoriaFustella) = mgr.GetAll(LFM.CategoriaFustella.Categoria)

            dgCatFustelle.AutoGenerateColumns = False
            dgCatFustelle.DataSource = l

        End Using
    End Sub

    Private Sub CaricaTipoFustella()
        Try
            Using mgr As New TipoFustelleDAO

                Dim pBase As LUNA.LunaSearchParameter = Nothing
                If txtBase.Text.Length AndAlso txtBase.Text <> "0" Then
                    pBase = New LUNA.LunaSearchParameter(LFM.TipoFustella.Base, txtBase.Text)
                End If

                Dim pAlt As LUNA.LunaSearchParameter = Nothing
                If txtAltezza.Text.Length AndAlso txtAltezza.Text <> "0" Then
                    pAlt = New LUNA.LunaSearchParameter(LFM.TipoFustella.Altezza, txtAltezza.Text)
                End If

                Dim pProf As LUNA.LunaSearchParameter = Nothing
                If txtProfondita.Text.Length AndAlso txtProfondita.Text <> "0" Then
                    pProf = New LUNA.LunaSearchParameter(LFM.TipoFustella.Profondita, txtProfondita.Text)
                End If

                Dim pPrev As LUNA.LunaSearchParameter = Nothing
                If cmbPrev.SelectedValue Then
                    pPrev = New LUNA.LunaSearchParameter(LFM.TipoFustella.IdPrev, cmbPrev.SelectedValue)
                End If

                Dim l As List(Of TipoFustella) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdPrev,Base,Altezza,Profondita"},
                                                             pBase,
                                                             pAlt,
                                                             pProf,
                                                             pPrev)
                Dim lFinale As List(Of TipoFustella) = Nothing
                If cmbCat.SelectedValue Then
                    lFinale = New List(Of TipoFustella)
                    'qui ha selezionato una cat devo beccare solo quelle 
                    Using mgrTF As New TipoFustellaSuCatDAO
                        Dim lTF As List(Of TipoFustellaSuCat) = mgrTF.FindAll(New LUNA.LunaSearchParameter(LFM.TipoFustellaSuCat.IdCat, cmbCat.SelectedValue))
                        For Each singFust In l
                            If lTF.FindAll(Function(x) x.IdTipo = singFust.IdTipoFustella).Count <> 0 Then
                                lFinale.Add(singFust)
                            End If
                        Next
                    End Using
                Else
                    lFinale = l
                End If

                DgTipoFustelle.AutoGenerateColumns = False
                DgTipoFustelle.DataSource = lFinale

            End Using
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnAggTipo_Click(sender As Object, e As EventArgs) Handles btnAggTipo.Click

        CaricaTipoFustella()

    End Sub


    Private Sub btnAddTipo_Click(sender As Object, e As EventArgs) Handles btnAddTipo.Click

        ParentFormEx.Sottofondo()

        Dim f As New frmListinoTipoFustella
        Dim ris As Integer = f.Carica()

        If ris Then CaricaTipoFustella()

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub DgTipoFustelle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgTipoFustelle.CellContentClick

    End Sub

    Private Sub RiapriTipoFustella()
        If DgTipoFustelle.SelectedRows.Count Then

            Dim SelRow As DataGridViewRow = DgTipoFustelle.SelectedRows(0)
            Dim tf As TipoFustella = SelRow.DataBoundItem
            ParentFormEx.Sottofondo()

            Dim f As New frmListinoTipoFustella
            Dim ris As Integer = f.Carica(tf)

            If ris Then CaricaTipoFustella()

            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub RiapriCatFustella()
        If dgCatFustelle.SelectedRows.Count Then

            Dim SelRow As DataGridViewRow = dgCatFustelle.SelectedRows(0)
            Dim cf As CategoriaFustella = SelRow.DataBoundItem
            ParentFormEx.Sottofondo()

            Dim f As New frmListinoCategoriaFustella
            Dim ris As Integer = f.Carica(cf)

            If ris Then CaricaCat()

            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub DgTipoFustelle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgTipoFustelle.CellDoubleClick

        RiapriTipoFustella()

    End Sub


    Private Sub btnAggiornaCat_Click(sender As Object, e As EventArgs) Handles btnAggiornaCat.Click
        CaricaCat()
    End Sub

    Private Sub btnAggFustelle_Click(sender As Object, e As EventArgs) Handles btnAggFustelle.Click
        CaricaFustelle()
    End Sub

    Private Sub btnShowOrd_Click(sender As Object, e As EventArgs) Handles btnShowOrd.Click

        If DgTipoFustelle.SelectedRows.Count Then

            Dim SelRow As DataGridViewRow = DgTipoFustelle.SelectedRows(0)
            Dim tf As TipoFustella = SelRow.DataBoundItem

            FormPrincipale.SelezionaOrdiniDaTipoFustella(tf.IdTipoFustella)

        Else
            MessageBox.Show("Selezionare un tipo fustella dalla lista")
        End If

        'FormPrincipale.SelezionaClienteDaChiamata(_IdCli)


    End Sub

    Private Sub btnAddCat_Click(sender As Object, e As EventArgs) Handles btnAddCat.Click

        ParentFormEx.Sottofondo()

        Dim f As New frmListinoCategoriaFustella
        Dim ris As Integer = f.Carica()

        If ris Then CaricaCat()

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub btnEditTipo_Click(sender As Object, e As EventArgs) Handles btnEditTipo.Click
        RiapriTipoFustella()
    End Sub

    Private Sub btnEditCat_Click(sender As Object, e As EventArgs) Handles btnEditCat.Click
        RiapriCatFustella()
    End Sub

    Private Sub dgCatFustelle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCatFustelle.CellDoubleClick
        RiapriCatFustella()
    End Sub

    Private Sub DgTipoFustelle_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgTipoFustelle.ColumnHeaderMouseClick
        OrdinatoreLista(Of TipoFustella).OrdinaLista(sender, e)
    End Sub

    Private Sub dgCatFustelle_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgCatFustelle.ColumnHeaderMouseClick
        OrdinatoreLista(Of CategoriaFustella).OrdinaLista(sender, e)
    End Sub

    Private Sub DgFustelle_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgFustelle.ColumnHeaderMouseClick
        OrdinatoreLista(Of Fustella).OrdinaLista(sender, e)
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtBase.Text = String.Empty
        txtAltezza.Text = String.Empty
        txtProfondita.Text = String.Empty
        cmbPrev.SelectedIndex = 0
        cmbCat.SelectedIndex = 0

    End Sub

    Private Sub txtBase_TextChanged(sender As Object, e As EventArgs) Handles txtBase.TextChanged
        If sender.focused Then CaricaTipoFustella()
    End Sub

    Private Sub txtAltezza_TextChanged(sender As Object, e As EventArgs) Handles txtAltezza.TextChanged
        If sender.focused Then CaricaTipoFustella()
    End Sub

    Private Sub txtProfondita_TextChanged(sender As Object, e As EventArgs) Handles txtProfondita.TextChanged
        If sender.focused Then CaricaTipoFustella()
    End Sub

    Private Sub cmbPrev_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrev.SelectedIndexChanged
        If sender.focused Then CaricaTipoFustella()
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCat.SelectedIndexChanged
        If sender.focused Then CaricaTipoFustella()
    End Sub
End Class
