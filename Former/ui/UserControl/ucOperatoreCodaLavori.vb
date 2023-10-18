Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucOperatoreCodaLavori
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        rdoStampa.BackColor = FormerLib.FormerColori.ColoreStatoCommessaStampa
        rdoFinituraCommessa.BackColor = FormerLib.FormerColori.ColoreStatoCommessaFinituraSuCommessa
        rdoFinituraProdotto.BackColor = FormerLib.FormerColori.ColoreStatoCommessaFinituraSuProdotti

    End Sub

    Public Event CommessaSelezionata(ByVal IdCommessa As Integer)

    Public Event OrdineSelezionato(ByVal IdOrdine As Integer)

    Public Sub Carica()

        Cursor.Current = Cursors.WaitCursor

        Dim l As New List(Of ILavoroOperatore)

        Dim lInt As List(Of LavLog) = Nothing
        Dim ParamFiltro As LUNA.LunaSearchParameter = Nothing

        If rdoStampa.Checked Then
            ParamFiltro = New LUNA.LunaSearchParameter(LFM.LavLog.IdCom, "(SELECT DISTINCT IdCom FROM T_Commesse WHERE stato IN (" & enStatoCommessa.Stampa & "," & enStatoCommessa.Pronto & "))", " IN ")
        ElseIf rdoFinituraCommessa.Checked Then
            ParamFiltro = New LUNA.LunaSearchParameter(LFM.LavLog.IdCom, "(SELECT DISTINCT IdCom FROM T_Commesse WHERE stato IN (" & enStatoCommessa.Stampa & "," & enStatoCommessa.FinituraSuCommessa & "))", " IN ")
        ElseIf rdoFinituraProdotto.Checked Then
            ParamFiltro = New LUNA.LunaSearchParameter(LFM.LavLog.IdOrd, "(SELECT DISTINCT o.IdOrd FROM T_Ordini o, T_Commesse C WHERE o.idcom = c.idcom AND o.stato = " & enStatoOrdine.FinituraProdottoInizio & " OR (o.stato = " & enStatoOrdine.FinituraCommessaFine & " AND c.stato = " & enStatoCommessa.Completata & " ))", " IN ")
        End If

        Using mgr As New LavLogDAO
            lInt = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdMacchinario,IdLav,IdCom, IdOrd, Ordine"},
                               New LUNA.LunaSearchParameter(LFM.LavLog.DataOraFine, Nothing, " IS "),
                               ParamFiltro)
        End Using

        Dim lFin As New List(Of LavLog)

        For Each singLav In lInt
            Using M As New Macchinario
                M.Read(singLav.IdMacchinario)
                If singLav.IdCom Then
                    If rdoStampa.Checked Then
                        If M.Tipo = enTipoMacchinario.Produzione Then
                            lFin.Add(singLav)
                        End If
                    ElseIf rdoFinituraCommessa.Checked Then
                        If M.Tipo = enTipoMacchinario.Allestimento Then
                            lFin.Add(singLav)
                        End If
                    End If
                Else
                    If M.Tipo = enTipoMacchinario.Allestimento Then
                        lFin.Add(singLav)
                    End If
                End If
            End Using
        Next

        For Each singLav In lFin
            If singLav.IdCom Then
                If l.FindAll(Function(X) X.IdCommessa = singLav.IdCom).Count = 0 Then
                    l.Add(singLav)
                End If
            Else
                If l.FindAll(Function(x) x.IdOrdine = singLav.IdOrdine).Count = 0 Then
                    l.Add(singLav)
                End If
            End If
        Next

        DgLavori.AutoGenerateColumns = False

        If rdoFinituraProdotto.Checked Then
            DgLavori.Columns("RagSoc").Visible = True
        Else
            DgLavori.Columns("RagSoc").Visible = False
        End If

        If rdoStampa.Checked = False Then
            DgLavori.Columns("Qta").Visible = False
            DgLavori.Columns("Risorsa").Visible = False
            DgLavori.Columns("NLastre").Visible = False
        Else
            DgLavori.Columns("Qta").Visible = True
            DgLavori.Columns("Risorsa").Visible = True
            DgLavori.Columns("NLastre").Visible = True
        End If

        'qui ordino la lista
        'l.Sort(Function(x, y) x.DataRifOrdinamento.CompareTo(y.DataRifOrdinamento))

        DgLavori.DataSource = l

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub rdoStampa_CheckedChanged(sender As Object, e As EventArgs) Handles rdoStampa.CheckedChanged,
                                                                                    rdoFinituraCommessa.CheckedChanged,
                                                                                    rdoFinituraProdotto.CheckedChanged
        If sender.focused Then
            Carica()
        End If

    End Sub

    Private Sub DgLavori_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgLavori.CellClick
        If e.RowIndex >= 0 Then
            Dim L As ILavoroOperatore = DirectCast(DgLavori.SelectedRows(0).DataBoundItem, ILavoroOperatore)
            If L.IdCommessa Then
                RaiseEvent CommessaSelezionata(L.IdCommessa)
            Else
                RaiseEvent OrdineSelezionato(L.IdOrdine)
            End If
            Try
                If sender.focused Then
                    FormPrincipale.UcToolbarMain.ShowNote(L.AnnotazioniOperatore)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnPrendiInCarico_Click(sender As Object, e As EventArgs) Handles btnPrendiInCarico.Click

        If DgLavori.SelectedRows.Count Then
            If MessageBox.Show("Confermi di voler effettuare il lavoro selezionato?", "Lo faccio io", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim l As ILavoroOperatore = DirectCast(DgLavori.SelectedRows(0).DataBoundItem, ILavoroOperatore)

                If l.PrendibileInCarico(PostazioneCorrente.UtenteConnesso.IdUt, True) Then

                    Using ll As New LavLog
                        ll.Read(l.IdLavLog)
                        ll.IdUtenteForzato = PostazioneCorrente.UtenteConnesso.IdUt
                        ll.Save()
                    End Using

                    MessageBox.Show("Il lavoro selezionato ti è stato assegnato e lo troverai nella sezione 'Lavori in coda per " & PostazioneCorrente.UtenteConnesso.Login & "'")

                Else
                    MessageBox.Show("Il lavoro non è prendibile in carico")
                End If
            End If
        Else
            MessageBox.Show("Selezionare un lavoro dalla lista")
        End If

    End Sub

    Private Sub DgLavori_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgLavori.RowPostPaint
        Try
            Dim r As DataGridViewRow = DgLavori.Rows(e.RowIndex)
            Dim lav As ILavoroOperatore = r.DataBoundItem

            If lav.PrendibileInCarico(PostazioneCorrente.UtenteConnesso.IdUt) = False Then
                If lav.IdUtInCarico Then
                    r.DefaultCellStyle.BackColor = Color.FromArgb(214, 224, 61)
                    r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 224, 61)
                Else
                    r.DefaultCellStyle.BackColor = Color.LightGray
                    r.DefaultCellStyle.SelectionBackColor = Color.LightGray
                End If

                Dim f As New Font(r.DefaultCellStyle.Font, FontStyle.Italic)
                r.DefaultCellStyle.Font = f
            Else
                If lav.IdUtInCarico = PostazioneCorrente.UtenteConnesso.IdUt Then
                    r.DefaultCellStyle.BackColor = Color.FromArgb(214, 224, 61)
                    r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 224, 61)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgLavori_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgLavori.CellContentClick

    End Sub
End Class
