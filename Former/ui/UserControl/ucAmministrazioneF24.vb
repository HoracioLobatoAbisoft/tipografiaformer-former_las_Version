Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucAmministrazioneF24
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Carica()

    End Sub

    Private Sub lnkRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked

        MostraDati

    End Sub

    Private Sub MostraDati()
        Cursor.Current = Cursors.WaitCursor
        Using mgr As New F24DAO


            Dim l As List(Of F24) = mgr.FindAll(LFM.F24.InseritoIl.Name & " DESC")

            If txtTesto.Text.Length Then
                l = l.FindAll(Function(x) x.SezioneErario.FindAll(Function(y) y.CodiceTributo.ToLower = txtTesto.Text.ToLower).Count > 0 OrElse
                                 x.SezioneImu.FindAll(Function(y) y.CodiceTributo.ToLower = txtTesto.Text.ToLower).Count > 0 OrElse
                                 x.SezioneInps.FindAll(Function(y) y.CausaleContributo.ToLower = txtTesto.Text.ToLower).Count > 0 OrElse
                                 x.SezioneRegioni.FindAll(Function(y) y.CodiceTributo.ToLower = txtTesto.Text.ToLower).Count > 0)
            End If

            dgF24.AutoGenerateColumns = False
            dgF24.DataSource = l

        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lnkNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked
        ParentFormEx.Sottofondo()
        Using f As New frmContabilitaF24
            f.Carica()
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub EliminaF24()
        If dgF24.SelectedRows.Count Then
            Dim f24 As F24 = dgF24.SelectedRows(0).DataBoundItem
            If MessageBox.Show("Confermi l'eliminazione dell'F24 selezionato?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Try
                        tb.TransactionBegin()

                        Using mgr As New F24DettaglioDAO
                            mgr.DeleteByIdF24(f24.IdF24)
                        End Using
                        Using mgr As New F24DAO
                            mgr.Delete(f24.IdF24)
                        End Using

                        tb.TransactionCommit()
                        MostraDati()
                    Catch ex As Exception
                        tb.TransactionRollBack()
                        MessageBox.Show("Errore: " & ex.Message)
                    End Try
                End Using

            End If

        End If
    End Sub

    Private Sub ModificaF24()
        If dgF24.SelectedRows.Count Then
            Dim f24 As F24 = dgF24.SelectedRows(0).DataBoundItem
            Dim Ris As Integer = 0
            ParentFormEx.Sottofondo()
            Using f As New frmContabilitaF24
                Ris = f.Carica(f24.IdF24)
            End Using
            ParentFormEx.Sottofondo()
            If Ris Then MostraDati()
        End If

    End Sub

    Private Sub dgF24_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgF24.CellContentClick

    End Sub

    Private Sub dgF24_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgF24.CellDoubleClick
        ModificaF24()
    End Sub

    Private Sub lnkDelFormato_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelFormato.LinkClicked
        eliminaf24
    End Sub

    Private Sub dgF24_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgF24.ColumnHeaderMouseClick
        OrdinatoreLista(Of F24).OrdinaLista(sender, e)
    End Sub
End Class
