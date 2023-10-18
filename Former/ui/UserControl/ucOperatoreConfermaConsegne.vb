Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class ucOperatoreConfermaConsegne
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
    End Sub

    Public Sub Carica()

    End Sub

    Private Sub CaricaConsegne()
        Cursor.Current = Cursors.WaitCursor
        tvwConsegne.Nodes.Clear()

        Using mgr As New ConsegneProgrammateDAO

            Dim l As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, "(" & enCorriere.TipografiaFormer & "," & enCorriere.TipografiaFormerFuoriRaccordo & ")", "IN"),
                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.InConsegna),
                                                                New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.No))

            l = l.FindAll(Function(x) x.ListaOrdini.FindAll(Function(y) y.Stato = enStatoOrdine.InConsegna).Count <> 0)

            l.Sort(Function(x, y) y.DataUltimaUscitaDaMagazzino.CompareTo(x.DataUltimaUscitaDaMagazzino))

            For Each c As ConsegnaProgrammata In l

                Dim ChiaveData As String = "D" & c.DataUltimaUscitaDaMagazzino.Year & c.DataUltimaUscitaDaMagazzino.Month.ToString("00") & c.DataUltimaUscitaDaMagazzino.Day.ToString("00")
                Dim NodeData As TreeNode = Nothing

                If tvwConsegne.Nodes.Find(ChiaveData, False).Count Then
                    NodeData = tvwConsegne.Nodes.Find(ChiaveData, False)(0)
                End If

                If NodeData Is Nothing Then
                    NodeData = tvwConsegne.Nodes.Add(ChiaveData, "Consegne effettuate il " & c.DataUltimaUscitaDaMagazzino.ToString("dd/MM/yyyy"), 0, 0)
                End If

                Dim ChiaveCons As String = "C" & c.IdCons
                Dim NodeCons As TreeNode = NodeData.Nodes.Add(ChiaveCons, c.Cliente.RagSocNome, 1, 1)

                For Each o As Ordine In c.ListaOrdini
                    Dim nodoOrd As TreeNode = NodeCons.Nodes.Add("O" & o.IdOrd, "Ord." & o.IdOrd & " - " & o.Prodotto.Riassunto, 2, 2)
                    nodoOrd.BackColor = o.StatoColore
                Next
                NodeData.Expand()
            Next

        End Using

        'tvwConsegne.ExpandAll()
        Cursor.Current = Cursors.Default
    End Sub

    Public Event OrdineSelezionato(ByVal IdOrdine As Integer)

    Private Sub btnConsegnaEffettuata_Click(sender As Object, e As EventArgs) Handles btnConsegnaEffettuata.Click
        Dim IdCons As Integer = 0
        If Not tvwConsegne.SelectedNode Is Nothing Then
            Dim selNode As TreeNode = tvwConsegne.SelectedNode
            If selNode.Name.StartsWith("D") Then
                MessageBox.Show("Selezionare una consegna dalla lista")
            ElseIf selNode.Name.StartsWith("C") Then
                IdCons = selNode.Name.Substring(1)
            ElseIf selNode.Name.StartsWith("O") Then
                IdCons = selNode.Parent.Name.Substring(1)
            End If
        Else
            MessageBox.Show("Selezionare una consegna dalla lista")
        End If

        If IdCons Then
            Using mgr As New ConsegneProgrammateDAO
                Using c As New ConsegnaProgrammata
                    c.Read(IdCons)
                    If MessageBox.Show("Confermi il completamento della consegna a " & c.Cliente.RagSocNome & " del " & c.Giorno.ToString("dd/MM/yyyy") & "?", "Conferma consegna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        mgr.AvanzaStatoConsegna(c, enStatoConsegna.Consegnata)
                        CaricaConsegne()
                    End If
                End Using
            End Using
        End If

    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click

        CaricaConsegne()

    End Sub

    Private Sub tvwConsegne_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwConsegne.AfterSelect

        If e.Node.Name.StartsWith("O") Then
            Dim IdOrd As Integer = e.Node.Name.Substring(1)
            Cursor.Current = Cursors.WaitCursor

            RaiseEvent OrdineSelezionato(IdOrd)

            Cursor.Current = Cursors.Default

        End If
    End Sub
End Class
