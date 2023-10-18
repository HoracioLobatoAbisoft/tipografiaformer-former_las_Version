Imports FormerLib.FormerEnum
Imports FormerDALSql
Public Class ucMarketingProgrammato
    Inherits ucFormerUserControl
    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        ParentFormEx.Sottofondo()

        StampaGlobale("Marketing Programmato", DgMarketing)

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        MostraDati()
    End Sub

    Friend Sub MostraDati()

        Using x As New cMarketingColl
            Dim dt As DataTable

            dt = x.Lista

            DgMarketing.DataSource = dt

            DgMarketing.Columns(0).Visible = False
            DgMarketing.Columns(5).Visible = False
        End Using
    End Sub


    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        ParentFormEx.Sottofondo()

        Dim x As New frmMarketingProgrammato

        If x.Carica() Then MostraDati()

        x = Nothing

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub DgMarketing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMarketing.CellClick

        If DgMarketing.SelectedRows.Count Then

            lblGruppo.Text = "Gruppo: " & DgMarketing.SelectedRows(0).Cells(4).Value
            '    lblAzione.Text = "Azione: " & DgMarketing.SelectedRows(0).Cells(2).Value

            CaricaClienti()

        End If

    End Sub

    Private Sub DgMarketing_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMarketing.CellContentDoubleClick
        ModificaVoce()
    End Sub

    Private Sub ModificaVoce()

        If DgMarketing.SelectedRows.Count Then

            Dim IdVoce As Integer = 0

            IdVoce = DgMarketing.SelectedRows(0).Cells(0).Value

            Dim x As New frmMarketingProgrammato
            ParentFormEx.Sottofondo()

            If x.Carica(IdVoce) Then MostraDati()
            x = Nothing
            ParentFormEx.Sottofondo()


        End If
    End Sub

    Private Sub ModificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaToolStripMenuItem.Click

        ModificaVoce()

    End Sub

    Private Sub DgMarketing_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgMarketing.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim x As System.Drawing.Point = MousePosition
            ContextMenu.Show(x)
        End If
    End Sub

    Private Sub tvCont_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvCont.AfterSelect
        'If e.Node.Name.StartsWith("C") Then
        '    Dim IdCliente As Integer = e.Node.Name.Substring(1)
        '    CaricaAzioniCliente(IdCliente)
        'End If
    End Sub

    Private Sub lnkComple_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkComple.LinkClicked
        CompletataVoce()


    End Sub

    Private Sub CompletataVoce()


        If DgMarketing.SelectedRows.Count Then
            If MessageBox.Show("Vuoi contrassegnare l'attivita di marketing come completata?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim IdVoce As Integer = 0

                IdVoce = DgMarketing.SelectedRows(0).Cells(0).Value


                Using mk As New cMarketingColl
                    mk.Completata(IdVoce)
                End Using
                MostraDati()
            End If
        End If
    End Sub

    Private Sub DgMarketing_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DgMarketing.RowPostPaint
        Dim row As DataGridViewRow = DgMarketing.Rows(e.RowIndex)
        If row.Cells(5).Value = True Then
            row.Cells(1).Style.BackColor = Color.Green
            row.Cells(1).Style.ForeColor = Color.White
            row.Cells(1).Style.SelectionBackColor = Color.Green
            row.Cells(1).Style.SelectionForeColor = Color.White

        Else
            row.Cells(1).Style.BackColor = Color.Red
            row.Cells(1).Style.ForeColor = Color.Black
            row.Cells(1).Style.SelectionBackColor = Color.Red
            row.Cells(1).Style.SelectionForeColor = Color.Black
        End If
    End Sub

    Private Sub EseguiAzioneDiMarketingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EseguiAzioneDiMarketingToolStripMenuItem.Click

        CompletataVoce()

    End Sub

    Private Sub DgMarketing_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgMarketing.SelectionChanged



    End Sub

    Private Sub CaricaClienti()
        Cursor.Current = Cursors.WaitCursor

        Dim IdGruppoSel As Integer = 0
        Dim _IdGruppo As Integer = 0

        If DgMarketing.SelectedRows.Count Then
            tvCont.Nodes.Clear()
            IdGruppoSel = DgMarketing.SelectedRows(0).Cells(0).Value
            Dim Mark As New CampagnaMarketing
            Mark.Read(IdGruppoSel)
            _IdGruppo = Mark.IdGruppo

            Using G As New Gruppo
                Dim l As List(Of IVoceRubricaG)
                Using mgr As New VociRubGDAO
                    G.Read(_IdGruppo)

                    l = mgr.GetAllVoceRubG(G)

                    l = mgr.ApplicaFiltro(l, G)

                    For Each Sing In l
                        Dim chiave As String = "C" & Sing.IdRubG
                        Dim RagSoc As String = Sing.NominativoG
                        Dim nodo As TreeNode = tvCont.Nodes.Add(chiave, RagSoc, 0, 0)
                    Next

                End Using

            End Using

            'Dim dt As DataTable, dr As DataRow
            'Using mgr As New VociRubricaDAO
            '    dt = mgr.ListaGruppo(_IdGruppo)
            '    For Each dr In dt.Rows
            '        Dim chiave As String = "C" & dr(0).ToString
            '        Dim RagSoc As String = dr(1).ToString
            '        If RagSoc.Trim.Length = 0 Then
            '            RagSoc = dr(2).ToString & " " & dr(3).ToString
            '        End If
            '        Dim nodo As TreeNode = tvCont.Nodes.Add(chiave, RagSoc, 0, 0)

            '        'per ogni nodo carico i sotto nodi
            '    Next

            'End Using

            'Using x As New VociRubricaDAO
            '    Dim dr As DataRow
            '    Dim dt As DataTable = x.ListaDT(True, True, True, True, , , , IdGruppoSel, rdoNonComp.Checked)

            '    tvCont.Nodes.Clear()
            '    For Each dr In dt.Rows
            '        Dim chiave As String = "C" & dr(0).ToString
            '        Dim RagSoc As String = dr(1).ToString
            '        If RagSoc.Trim.Length = 0 Then
            '            RagSoc = dr(2).ToString & " " & dr(3).ToString
            '        End If
            '        Dim nodo As TreeNode = tvCont.Nodes.Add(chiave, RagSoc, 0, 0)

            '        'per ogni nodo carico i sotto nodi
            '    Next
            'End Using
            tvCont.ExpandAll()
        End If

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CaricaAzioniCliente(IdCliente As Integer)

        Dim DtMk As DataTable, drMk As DataRow
        Dim IdGruppoSel As Integer = 0
        IdGruppoSel = DgMarketing.SelectedRows(0).Cells(0).Value
        Using xMk As New cMarkAzColl
            DtMk = xMk.Lista(IdCliente, IdGruppoSel)
        End Using

        Dim Chiave As String = "C" & IdCliente

        tvCont.Nodes(Chiave).Nodes.Clear()

        For Each drMk In DtMk.Rows

            Dim chiavMk As String = "", Azione As String = "", ImageSel As Integer = 0

            Select Case drMk("Tipoazione")

                Case enTipoAzMarketing.InvioMail
                    chiavMk &= "M"
                    Azione = "Invio Mail"
                    ImageSel = 5

                Case enTipoAzMarketing.SpedMat
                    chiavMk &= "S"
                    Azione = "Spedizione materiale"
                    ImageSel = 7

                Case enTipoAzMarketing.Telefono
                    chiavMk &= "T"
                    Azione = "Telefono"
                    ImageSel = 6

                Case enTipoAzMarketing.Visita
                    chiavMk &= "V"
                    Azione = "Visita"
                    ImageSel = 4

            End Select

            chiavMk &= drMk(0).ToString

            tvCont.Nodes(Chiave).Nodes.Add(chiavMk, drMk("Quando").ToString & " - " & Azione & ": " & drMk("Annotazioni").ToString, ImageSel, ImageSel)
            tvCont.Nodes(Chiave).ExpandAll()
        Next


    End Sub

    Private Sub lnkEsegSing_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkEsegSing.LinkClicked

        If Not tvCont.SelectedNode Is Nothing Then

            If tvCont.SelectedNode.Name.StartsWith("C") Then

                'qui prendo il gruppo selezionato nella lista
                Dim IdMark As Integer = DgMarketing.SelectedRows(0).Cells(0).Value

                Dim IdRub As Integer = tvCont.SelectedNode.Name.Substring(1)
                ParentFormEx.Sottofondo()

                Dim x As New frmMarketingEffettivo, Ris As Integer = 0

                Ris = x.Carica(, IdRub, IdMark)

                If Ris Then CaricaClienti()

                x = Nothing

                ParentFormEx.Sottofondo()
            Else
                MessageBox.Show("Selezionare un cliente dall'albero in basso!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Selezionare un cliente dall'albero in basso!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub DgMarketing_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgMarketing.CellContentClick

    End Sub

    Private Sub rdoTutti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTutti.CheckedChanged, rdoNonComp.CheckedChanged
        If sender.focused Then CaricaClienti()
    End Sub

    Private Sub lnkEsegAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkEsegAll.LinkClicked

        If DgMarketing.SelectedRows.Count Then
            ParentFormEx.Sottofondo()
            Dim IdMark As Integer = 0

            IdMark = DgMarketing.SelectedRows(0).Cells(0).Value

            Using x As New frmMarketingEmail
                x.Carica(, , IdMark)
            End Using
            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub tvCont_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvCont.DoubleClick

        'If Not tvCont.SelectedNode Is Nothing Then

        '    Dim N As TreeNode = tvCont.SelectedNode
        '    Dim IdRel As Integer = N.Name.Substring(1)
        '    If N.Name.StartsWith("C") Then
        '        'cliente
        '        ParentFormEx.Sottofondo()
        '        Dim x As New frmVoceRubrica
        '        x.Carica(IdRel)
        '        x = Nothing
        '        ParentFormEx.Sottofondo()

        '    ElseIf N.Name.StartsWith("M") Then
        '        'mail
        '        ParentFormEx.Sottofondo()
        '        Dim x As New frmEmailMarketing
        '        x.Leggi(IdRel)
        '        x = Nothing
        '        ParentFormEx.Sottofondo()

        '    End If

        'End If

    End Sub

End Class
