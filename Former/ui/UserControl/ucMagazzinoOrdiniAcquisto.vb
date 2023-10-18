Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucMagazzinoOrdiniAcquisto
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        MgrControl.InizializeGridview(DgOrdini)

        CaricaCombo()

    End Sub

    Private Sub CaricaCombo()

        Try

            'carico la combo dei fornitori
            Using cli As New VociRubricaDAO
                cmbFornitore.ValueMember = "IdRub"
                cmbFornitore.DisplayMember = "RagSocNome"

                cmbFornitore.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, True,,,,,, True)

                ''carico la combo dei clienti
                'cmbAgente.ValueMember = "IdRub"
                'cmbAgente.DisplayMember = "Nominativo"

                'cmbAgente.DataSource = cli.ListaCombo(enTipoRubrica.Agente, True)
            End Using

            'carico la combo dei fornitori
            Using cli As New RisorseDAO
                cmbRisorsa.ValueMember = LFM.Risorsa.IdRis.Name
                cmbRisorsa.DisplayMember = LFM.Risorsa.Descrizione.Name

                cmbRisorsa.DataSource = cli.GetAll(LFM.Risorsa.Descrizione, True)

                ''carico la combo dei clienti
                'cmbAgente.ValueMember = "IdRub"
                'cmbAgente.DisplayMember = "Nominativo"

                'cmbAgente.DataSource = cli.ListaCombo(enTipoRubrica.Agente, True)
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Carica()

    End Sub

    Private Sub lnkStampa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        If DgOrdini.SelectedRows.Count Then

            Dim O As OrdineAcquisto = DgOrdini.SelectedRows(0).DataBoundItem

            MgrOrdiniAcquisto.Stampa(O)

        End If

    End Sub

    Private Sub lnkDel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked

        If DgOrdini.SelectedRows.Count Then
            If MessageBox.Show("Confermi l'eliminazione dell'ordine di acquisto?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim EliminaRichieste As Boolean = False

                If MessageBox.Show("Vuoi eliminare anche le richieste di acquisto contenute nell'ordine?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    EliminaRichieste = True
                End If

                Dim M As OrdineAcquisto = DgOrdini.SelectedRows(0).DataBoundItem

                If EliminaRichieste Then
                    Using mgr As New MagazzinoDAO
                        For Each R As MovimentoMagazzino In M.Richieste
                            mgr.Delete(R)
                        Next
                    End Using
                Else
                    For Each R As MovimentoMagazzino In M.Richieste
                        R.IdOrdineAcquisto = 0
                        R.Save()
                    Next
                End If

                Using mgr As New OrdiniAcquistoDAO
                    mgr.Delete(M)
                    'mgr.AggiornaQta(M.IdRis)
                    DgOrdini.Rows.Remove(DgOrdini.SelectedRows(0))
                End Using

            End If
        End If

    End Sub

    Private Sub lnkNuovo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNuovo.LinkClicked

        ParentFormEx.Sottofondo()

        Using f As New frmMagazzinoOrdineAcquisto

            f.Carica()

        End Using

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        Cerca()
    End Sub


    Private Sub Cerca()
        Cursor.Current = Cursors.WaitCursor
        Using mgr As New OrdiniAcquistoDAO

            Dim l As List(Of OrdineAcquisto) = mgr.Cerca(cmbFornitore.SelectedValue,
                                                         cmbRisorsa.SelectedValue)

            DgOrdini.DataSource = l

        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub DgOrdini_Click(sender As Object, e As EventArgs) Handles DgOrdini.Click

    End Sub

    Private Sub DgOrdini_DoubleClick(sender As Object, e As EventArgs) Handles DgOrdini.DoubleClick
        If DgOrdini.SelectedRows.Count Then

            Dim O As OrdineAcquisto = DgOrdini.SelectedRows(0).DataBoundItem

            ParentFormEx.Sottofondo()

            Using f As New frmMagazzinoOrdineAcquisto
                f.Carica(O.IdOrdineAcquisto)
            End Using

            ParentFormEx.Sottofondo()

        End If
    End Sub
End Class
