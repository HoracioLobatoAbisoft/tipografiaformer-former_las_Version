Imports FormerDALSql
Public Class ucLavorazioni
    Inherits ucFormerUserControl
    Public Property SolaLettura As Boolean = False

    Public ReadOnly Property ListaIdSelezionati() As Integer()
        Get
            Dim x As Integer()

            Array.Resize(x, DGLavorazioniSel.Rows.Count)

            If DGLavorazioniSel.Rows.Count Then

                Dim dr As DataGridViewRow
                For Each dr In DGLavorazioniSel.Rows
                    x.SetValue(dr.Cells(0).Value, dr.Index)
                Next

            End If

            Return x

        End Get
    End Property

    Public Sub CaricaxCom(Optional ByVal IdTipoCom As Integer = 0)

        'carico la lista delle lavorazioni 
        'se mi viene passato l'id del prodotto carico dal db le check su quelle selezionate

        Dim x As New cLavoriColl
        Dim dtLista As DataTable
        Dim dtListaSel As DataTable

        Dim Dr As DataRow

        dtLista = x.ListaTipoCom(IdTipoCom)

        DgLavorazioni.Columns.Add("IdLavoro", "IdLavoro")
        DgLavorazioni.Columns.Add("Descrizione", "Descrizione")
        DgLavorazioni.Columns.Add("TempoRif", "Minuti")
        DgLavorazioni.Columns.Add("Premio", "Bonus")

        DgLavorazioni.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgLavorazioni.Columns(3).DefaultCellStyle.Format = "0.00"

        DGLavorazioniSel.Columns.Add("IdLavoro", "IdLavoro")
        DGLavorazioniSel.Columns.Add("Descrizione", "Descrizione")
        DGLavorazioniSel.Columns.Add("TempoRif", "Minuti")
        DGLavorazioniSel.Columns.Add("Premio", "Bonus")

        DGLavorazioniSel.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGLavorazioniSel.Columns(3).DefaultCellStyle.Format = "0.00"


        For Each Dr In dtLista.Rows

            Dim Riga As New DataGridViewRow

            Riga.CreateCells(DgLavorazioni)

            Riga.Cells(0).Value = Dr("IdLavoro")
            Riga.Cells(1).Value = Dr("Descrizione")
            Riga.Cells(2).Value = Dr("TempoRif")
            Riga.Cells(3).Value = Dr("Premio")

            DgLavorazioni.Rows.Add(Riga)

            Riga = Nothing

        Next

        DgLavorazioni.Columns(0).Visible = False

        dtListaSel = x.ListaTipoComSel(IdTipoCom)

        For Each Dr In dtListaSel.Rows

            Dim Riga As New DataGridViewRow
            Riga.CreateCells(DGLavorazioniSel)

            Riga.Cells(0).Value = Dr("IdLavoro")
            Riga.Cells(1).Value = Dr("Descrizione")
            Riga.Cells(2).Value = Dr("TempoRif")
            Riga.Cells(3).Value = Dr("Premio")

            DGLavorazioniSel.Rows.Add(Riga)

            Riga = Nothing

        Next

        DGLavorazioniSel.Columns(0).Visible = False
    End Sub

    Public Sub CaricaxProd(Optional ByVal IdProd As Integer = 0)

        'carico la lista delle lavorazioni 
        'se mi viene passato l'id del prodotto carico dal db le check su quelle selezionate

        Using x As New cLavoriColl
            Dim dtLista As DataTable
            Dim dtListaSel As DataTable

            Dim Dr As DataRow

            DgLavorazioni.Rows.Clear()
            DGLavorazioniSel.Rows.Clear()


            dtLista = x.ListaProdotto(IdProd)
            If DgLavorazioni.Columns.Count = 0 Then
                DgLavorazioni.Columns.Add("IdLavoro", "IdLavoro")
                DgLavorazioni.Columns.Add("Descrizione", "Descrizione")
                DgLavorazioni.Columns.Add("TempoRif", "Minuti")
                DgLavorazioni.Columns.Add("Premio", "Bonus")
                DgLavorazioni.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DgLavorazioni.Columns(3).DefaultCellStyle.Format = "0.00"
            End If


            If DGLavorazioniSel.Columns.Count = 0 Then
                DGLavorazioniSel.Columns.Add("IdLavoro", "IdLavoro")
                DGLavorazioniSel.Columns.Add("Descrizione", "Descrizione")
                DGLavorazioniSel.Columns.Add("TempoRif", "Minuti")
                DGLavorazioniSel.Columns.Add("Premio", "Bonus")
                DGLavorazioniSel.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGLavorazioniSel.Columns(3).DefaultCellStyle.Format = "0.00"
            End If

            For Each Dr In dtLista.Rows

                Dim Riga As New DataGridViewRow

                Riga.CreateCells(DgLavorazioni)

                Riga.Cells(0).Value = Dr("IdLavoro")
                Riga.Cells(1).Value = Dr("Descrizione")
                Riga.Cells(2).Value = Dr("TempoRif")
                Riga.Cells(3).Value = Dr("Premio")
                DgLavorazioni.Rows.Add(Riga)

                Riga = Nothing

            Next

            DgLavorazioni.Columns(0).Visible = False

            dtListaSel = x.ListaProdottoSel(IdProd)

            For Each Dr In dtListaSel.Rows

                Dim Riga As New DataGridViewRow
                Riga.CreateCells(DGLavorazioniSel)

                Riga.Cells(0).Value = Dr("IdLavoro")
                Riga.Cells(1).Value = Dr("Descrizione")
                Riga.Cells(2).Value = Dr("TempoRif")
                Riga.Cells(3).Value = Dr("Premio")

                DGLavorazioniSel.Rows.Add(Riga)

                Riga = Nothing

            Next

            DGLavorazioniSel.Columns(0).Visible = False
        End Using
    End Sub

    Private Sub lnkSu_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSu.LinkClicked
        If _SolaLettura = False Then
            SpostaLav("UP")
        Else
            MessageBox.Show("Le lavorazioni non sono modificabili in questo stato!", , MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub SpostaLav(ByVal Direzione As String)
        If DGLavorazioniSel.SelectedRows.Count Then
            Dim Dr As DataGridViewRow = DGLavorazioniSel.SelectedRows(0)
            If Dr.Selected Then

                Dim Riga As New DataGridViewRow
                Riga.CreateCells(DGLavorazioniSel)

                Riga.Cells(0).Value = Dr.Cells(0).Value
                Riga.Cells(1).Value = Dr.Cells(1).Value
                Riga.Cells(2).Value = Dr.Cells(2).Value
                Riga.Cells(3).Value = Dr.Cells(3).Value

                Select Case Direzione
                    Case "UP"

                        If Dr.Index - 1 >= 0 Then
                            DGLavorazioniSel.Rows.Insert(Dr.Index - 1, Riga)
                            DGLavorazioniSel.Rows.Remove(DGLavorazioniSel.SelectedRows(0))
                            Riga.Selected = True
                        End If


                    Case "DOWN"
                        If Dr.Index + 2 <= DGLavorazioniSel.Rows.Count Then
                            DGLavorazioniSel.Rows.Insert(Dr.Index + 2, Riga)
                            DGLavorazioniSel.Rows.Remove(DGLavorazioniSel.SelectedRows(0))
                            Riga.Selected = True
                        End If

                End Select


            End If
        End If


    End Sub

    Private Sub lnkGiu_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkGiu.LinkClicked
        If _SolaLettura = False Then
            SpostaLav("DOWN")
        Else
            MessageBox.Show("Le lavorazioni non sono modificabili in questo stato!", , MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub lnkAggiungi_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiungi.LinkClicked
        If _SolaLettura = False Then
            AggiungiLav()
        Else
            MessageBox.Show("Le lavorazioni non sono modificabili in questo stato!", , MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub AggiungiLav()
        If DgLavorazioni.SelectedRows.Count Then
            Dim Dr As DataGridViewRow = DgLavorazioni.SelectedRows(0)
            If Dr.Selected Then
                'sposto la lavorazione tra quelle selezionate

                Dim Riga As New DataGridViewRow
                Riga.CreateCells(DGLavorazioniSel)

                Riga.Cells(0).Value = Dr.Cells(0).Value
                Riga.Cells(1).Value = Dr.Cells(1).Value
                Riga.Cells(2).Value = Dr.Cells(2).Value
                Riga.Cells(3).Value = Dr.Cells(3).Value

                DGLavorazioniSel.Rows.Add(Riga)
                DgLavorazioni.Rows.Remove(DgLavorazioni.SelectedRows(0))

                Riga = Nothing

            End If
        End If
    End Sub

    Private Sub lnkDel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked
        If _SolaLettura = False Then
            RimuoviLav()
        Else
            MessageBox.Show("Le lavorazioni non sono modificabili in questo stato!", , MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub RimuoviLav()

        If DGLavorazioniSel.SelectedRows.Count Then
            Dim Dr As DataGridViewRow = DGLavorazioniSel.SelectedRows(0)
            If Dr.Selected Then
                'sposto la lavorazione tra quelle selezionate

                Dim Riga As New DataGridViewRow
                Riga.CreateCells(DgLavorazioni)

                Riga.Cells(0).Value = Dr.Cells(0).Value
                Riga.Cells(1).Value = Dr.Cells(1).Value
                Riga.Cells(2).Value = Dr.Cells(2).Value
                Riga.Cells(3).Value = Dr.Cells(3).Value

                DgLavorazioni.Rows.Add(Riga)
                DGLavorazioniSel.Rows.Remove(DGLavorazioniSel.SelectedRows(0))

                Riga = Nothing

            End If
        End If
    End Sub

    Private Sub DgLavorazioni_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLavorazioni.CellDoubleClick
        If _SolaLettura = False Then
            AggiungiLav()
        Else
            MessageBox.Show("Le lavorazioni non sono modificabili in questo stato!", , MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub DGLavorazioniSel_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGLavorazioniSel.CellDoubleClick
        If _SolaLettura = False Then
            RimuoviLav()
        Else
            MessageBox.Show("Le lavorazioni non sono modificabili in questo stato!", , MessageBoxButtons.OK)
        End If
    End Sub
End Class
