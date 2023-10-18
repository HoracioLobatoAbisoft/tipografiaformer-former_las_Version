Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucMagazzinoCarichiDiMagazzino
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        MgrControl.InizializeGridview(DgOrdini)

        CaricaCombo()

    End Sub

    Public Sub MostraNonCollegati()
        cmbFornitore.SelectedIndex = 0
        cmbRisorsa.SelectedIndex = 0
        MgrControl.SelectIndexCombo(cmbStatoFEInterno, enStatoFEInterno.Inserito)
        Cerca()
    End Sub

    Public Sub MostraAnomalia()
        cmbFornitore.SelectedIndex = 0
        cmbRisorsa.SelectedIndex = 0
        MgrControl.SelectIndexCombo(cmbStatoFEInterno, enStatoFEInterno.Anomalia)
        Cerca()
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

            Dim LStati As New List(Of cEnum)
            Dim val1 As New cEnum(enStatoFEInternoSearch.Tutto, "Tutto")
            Dim val2 As New cEnum(enStatoFEInternoSearch.NonCollegato, "Non Collegato")
            Dim val3 As New cEnum(enStatoFEInternoSearch.Collegato, "Collegato")

            LStati.Add(val1)
            LStati.Add(val2)
            LStati.Add(val3)

            cmbStatoFEInterno.DisplayMember = "Descrizione"
            cmbStatoFEInterno.ValueMember = "Id"
            cmbStatoFEInterno.DataSource = LStati

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

        'controllare che non sia stato associato a nessun documento fiscale reale

        If DgOrdini.SelectedRows.Count Then
            If MessageBox.Show("Confermi l'eliminazione del documento di carico di magazzino? (saranno eliminati anche i movimenti di carico contenuti se non collegati a documenti contabili)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Try
                        Dim M As CaricoDiMagazzino = DgOrdini.SelectedRows(0).DataBoundItem

                        'If EliminaRichieste Then

                        tb.TransactionBegin()

                        Dim ListaIdRis As New List(Of Integer)

                        Using mgr As New MagazzinoDAO
                            For Each R As MovimentoMagazzino In M.ListaMovimenti
                                If R.IdVoceCosto = 0 Then
                                    If ListaIdRis.FindAll(Function(x) x = R.IdRis).Count = 0 Then ListaIdRis.Add(R.IdRis)
                                    mgr.Delete(R)
                                Else
                                    R.IdCaricoMagazzino = 0
                                    R.Save()
                                End If

                            Next
                        End Using
                        'Else

                        'End If
                        If M.IdCosto Then
                            Using c As New Costo
                                c.Read(M.IdCosto)
                                c.IdCaricoMagazzino = 0
                                c.StatoFEInterno = enStatoFEInterno.Inserito
                                'For Each voce In c.ListaVociFattura
                                '    voce.IdMovMagaz = 0
                                '    voce.Save()
                                'Next
                                c.Save()
                            End Using
                        End If

                        Using mgr As New CarichiDiMagazzinoDAO
                            mgr.Delete(M)
                            'mgr.AggiornaQta(M.IdRis)
                            DgOrdini.Rows.Remove(DgOrdini.SelectedRows(0))
                        End Using
                        tb.TransactionCommit()

                        For Each Id In ListaIdRis
                            MgrMagazzino.RicalcolaGiacenza(Id)
                        Next

                    Catch ex As Exception
                        tb.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore nell'eliminazione del documento di carico: " & ex.Message)
                    End Try
                End Using



            End If
        End If

    End Sub

    Private Sub lnkNuovo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNuovo.LinkClicked

        ParentFormEx.Sottofondo()

        Using f As New frmMagazzinoCaricoDiMagazzino

            f.Carica()

        End Using

        ParentFormEx.Sottofondo()
    End Sub

    Private Sub lnkAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        Cerca()
    End Sub


    Private Sub Cerca()
        Cursor.Current = Cursors.WaitCursor
        Using mgr As New CarichiDiMagazzinoDAO
            Dim pforn As LUNA.LunaSearchParameter = Nothing
            'Dim pRis As LUNA.LunaSearchParameter = Nothing
            Dim pStato As LUNA.LunaSearchParameter = Nothing

            If cmbFornitore.SelectedValue Then
                pforn = New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdRub, cmbFornitore.SelectedValue)
            End If

            If cmbStatoFEInterno.SelectedValue Then

                Dim InParam As String = String.Empty

                If cmbStatoFEInterno.SelectedValue = enStatoFEInternoSearch.NonCollegato Then
                    InParam = "(" & enStatoFEInterno.Inserito & "," & enStatoFEInterno.Anomalia & ")"
                ElseIf cmbStatoFEInterno.SelectedValue = enStatoFEInternoSearch.collegato Then
                    InParam = "(" & enStatoFEInterno.Collegato & ")"
                End If

                pStato = New LUNA.LunaSearchParameter(LFM.CaricoDiMagazzino.IdStatoInterno, InParam, "IN")
            End If

            Dim l As List(Of CaricoDiMagazzino) = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "DataCarico Desc"},
                                                                pforn,
                                                                pStato)

            If cmbRisorsa.SelectedValue Then
                l = l.FindAll(Function(x) x.ListaMovimenti.FindAll(Function(z) z.IdRis = cmbRisorsa.SelectedValue).Count)
            End If

            DgOrdini.DataSource = l

        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub DgOrdini_Click(sender As Object, e As EventArgs) Handles DgOrdini.Click

    End Sub

    Private Sub DgOrdini_DoubleClick(sender As Object, e As EventArgs) Handles DgOrdini.DoubleClick
        If DgOrdini.SelectedRows.Count Then

            Dim O As CaricoDiMagazzino = DgOrdini.SelectedRows(0).DataBoundItem

            ParentFormEx.Sottofondo()

            Using f As New frmMagazzinoCaricoDiMagazzino
                f.Carica(O.IdCaricoMagazzino)
            End Using

            ParentFormEx.Sottofondo()

        End If
    End Sub
End Class
