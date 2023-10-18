Imports FormerDALSql
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

Friend Class frmCalcLavoraz
    'Inherits baseFormInternaRedim
    Private _Ris As Integer
    Private _L As ListinoBase

    Private Sub CalcolaLavorazioni()
        If Not _L Is Nothing Then
            Dim listaOpz As New List(Of ILavorazioneB)
            For Each N As TreeNode In tvwListLavOpz.Nodes
                For Each N2 As TreeNode In N.Nodes
                    'qui ho le lavorazioni effettive
                    If N2.Checked Then
                        Dim IdLav As Integer = N2.Name.Substring(1)
                        Dim L As New Lavorazione
                        L.Read(IdLav)
                        listaOpz.Add(L)

                    End If
                Next
            Next

            _L.NumFacciate = Int(txtMinFogli.Text) * 2

            Dim r As RisListinoBase = MgrPreventivazioneB.CalcolaListinoBase(_L, _L.LavorazioniBaseB, listaOpz)

            If r Is Nothing Then r = New RisListinoBase((New ListinoBase))
            txtV1.Text = r.PrezzoLavOpz1
            txtV2.Text = r.PrezzoLavOpz2
            txtV3.Text = r.PrezzoLavOpz3
            txtV4.Text = r.PrezzoLavOpz4
            txtV5.Text = r.PrezzoLavOpz5
            txtV6.Text = r.PrezzoLavOpz6
        End If

    End Sub

    Friend Function Carica(ByVal L As ListinoBase) As Integer

        _L = L.Clone
        txtMinFogli.Text = _L.faccmin / 2
        txtQ1.Text = _L.qta1
        txtQ2.Text = _L.qta2
        txtQ3.Text = _L.qta3
        txtQ4.Text = _L.qta4
        txtQ5.Text = _L.qta5
        txtQ6.Text = _L.qta6

        CaricaListe()

        For Each lis As Lavorazione In _L.LavorazioniOpz
            Dim Chiave As String = "L" & lis.IdLavoro
            For Each N As TreeNode In tvwListLavOpz.Nodes
                If CheckNode(N, Chiave) Then Exit For
            Next
        Next

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaListeLav()

        _L.LavorazioniOpz.Clear()
        For Each N As TreeNode In tvwListLavOpz.Nodes
            For Each Nc As TreeNode In N.Nodes
                If Nc.Checked Then

                    Dim L As New Lavorazione
                    Dim IdLav As Integer = Nc.Name.Substring(1)
                    L.Read(IdLav)
                    _L.LavorazioniOpz.Add(L)
                End If

            Next

        Next

    End Sub

    Private Sub CaricaListe()

        Dim lstC As List(Of CatLav) = Nothing

        Using mgr As New CatLavDAO
            lstC = mgr.GetAll(LFM.CatLav.Descrizione)
        End Using

        Dim baseC As New CatLav With {.IdCatLav = 0, .Descrizione = " - Senza categoria"}

        lstC.Add(baseC)
        lstC.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))

        tvwListLavOpz.Nodes.Clear()

        For Each c As CatLav In lstC
            Dim N As New TreeNode
            N.Name = "C" & c.IdCatLav
            N.Text = c.Descrizione

            tvwListLavOpz.Nodes.Add(N)
        Next


        Dim lstL As List(Of Lavorazione) = Nothing

        Using mgr As New LavorazioniDAO
            lstL = mgr.FindAll(LFM.Lavorazione.Descrizione,
                               New LUNA.LunaSearchParameter(LFM.Lavorazione.Stato, enStato.NonAttivo, "<>"))
        End Using

        Dim strIdL As String = ""
        For Each f As Lavorazione In lstL
            ' If strIdL.IndexOf(f.IdLavoro & ",") = -1 Then
            'strIdL &= f.IdLavoro & ","

            Dim N As New TreeNode
            N.Name = "L" & f.IdLavoro
            N.Text = f.Riassunto

            Dim ChiavePadre As String = "C" & f.IdCatLav

            tvwListLavOpz.Nodes(ChiavePadre).Nodes.Add(N)
            'End If
        Next

        tvwListLavOpz.ExpandAll()

    End Sub

    Private Function CheckNode(Node As TreeNode, Chiave As String) As Integer
        Dim Ris As Integer = 0
        If Node.Name = Chiave Then
            Node.Checked = True
            Ris = 1
        Else
            For Each N As TreeNode In Node.Nodes
                Ris = CheckNode(N, Chiave)
                If Ris Then Exit For
            Next
        End If
        Return Ris
    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub txtQta_TextChanged(sender As Object, e As EventArgs)
        CalcolaLavorazioni()
    End Sub

    Private Sub tvwListLavOpz_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwListLavOpz.NodeMouseClick
        If e.Node.Name.StartsWith("L") Then
            Dim Chiave As String = e.Node.Name
            Dim ChiavePadre As String = e.Node.Parent.Name

            'ora deseleziono tutti gli altri nodi della stessa categoria tranne questo
            For Each N As TreeNode In tvwListLavOpz.Nodes(ChiavePadre).Nodes
                If N.Name <> Chiave Then
                    N.Checked = False
                Else
                    N.Checked = Not N.Checked
                End If
            Next
            CaricaListeLav()
            CalcolaLavorazioni()
        End If
    End Sub

    Private Sub tvwListLavOpz_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwListLavOpz.NodeMouseDoubleClick
        Dim IdLav As Integer = e.Node.Name.Substring(1)

        If IdLav Then
            Sottofondo()
            Dim f As New frmListinoLavorazione
            If f.Carica(IdLav) Then
                Dim L As New Lavorazione
                L.Read(IdLav)
                'qui devo aggiornare la voc
                e.Node.Text = L.Riassunto
                CalcolaLavorazioni()
                L = Nothing
            End If
            f = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub txtMinFogli_TextChanged(sender As Object, e As EventArgs) Handles txtMinFogli.TextChanged
        CalcolaLavorazioni()
    End Sub
End Class