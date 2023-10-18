Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucOrdiniDaFatturare
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.BackColor = Color.White

        TabMain.ItemSize = New Size(100, 40)

    End Sub

    Public Sub Carica()
        Try
            UcConsegneSettimana.Carica(Now.Date)
            UcAmministrazioneConsegne.Carica()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ucOrdiniFatt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnRefresh4_Click(sender As Object, e As EventArgs) Handles btnRefresh4.Click

        CaricaMerceUscita()

    End Sub

    Private Sub EmettiDocFiscale(tvw As TreeView)

        If Not tvw.SelectedNode Is Nothing Then
            Dim Node As TreeNode = tvw.SelectedNode

            If Node.Name.StartsWith("O") Then
                Node = Node.Parent
            End If

            If Node.Name.StartsWith("S") Then
                Dim IdCons As Integer = Node.Name.Substring(1)

                ParentFormEx.Sottofondo()
                Using x As New frmConsegnaProgrammata

                    x.Carica(IdCons)

                End Using
                ParentFormEx.Sottofondo()

            End If
        End If

    End Sub

    Private Sub btnDocFisc_Click(sender As Object, e As EventArgs) Handles btnDocFisc.Click

        EmettiDocFiscale(tvMerceUscita)

    End Sub

    Private Sub CaricaMerceUscita()
        Cursor = Cursors.WaitCursor
        CaricaOrd(, , , chkLastWeek.Checked)

        Cursor = Cursors.Default
    End Sub

    Private Function Comparer(ByVal x As ConsegnaRicerca, ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = y.DataEffConsegna.CompareTo(x.DataEffConsegna)
        If result = 0 Then result = x.RagSoc.CompareTo(y.RagSoc)

        Return result
    End Function

    Private Sub CaricaOrd(Optional ByVal Iniziale As String = "",
                       Optional ByVal IdRub As Integer = 0,
                       Optional ByVal TestoLibero As String = "",
                       Optional ByVal LastWeek As Boolean = True)

        Using mgr As New ConsegneRicercaDAO
            Dim LstM As New List(Of ConsegnaRicerca)
            Dim ListaStati As String = enStatoOrdine.UscitoMagazzino
            'If chkImballaggio.Checked Then ListaStati &= "," & enStatoOrdine.ImballaggioCorriere
            LstM = mgr.ListaMerceUscitaMagazzino(-1, 0, , , ListaStati, , , , , , LastWeek)
            LstM.Sort(AddressOf Comparer)
            tvMerceUscita.Nodes.Clear()

            For Each c As ConsegnaRicerca In LstM

                Dim ChiaveData As String = "D" & c.DataEffConsegna.ToString("ddMMyyyy")
                Dim NodoData As TreeNode = tvMerceUscita.Nodes(ChiaveData)
                If NodoData Is Nothing Then
                    NodoData = tvMerceUscita.Nodes.Add(ChiaveData, c.DataEffConsegna.ToString("dd MMMM yyyy"), 7, 7)
                    'NodoCorr.Expand()
                End If
                Dim ChiaveCorriere As String = "C" & c.IdCorr
                Dim ChiaveConsegna As String = "S" & c.IdCons

                Dim ChiaveOrdine As String = "O" & c.IdOrd

                Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
                If NodoCorr Is Nothing Then
                    NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, c.CorriereNome, 6, 6)
                    'NodoCorr.Expand()
                End If
                Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveConsegna)
                If NodoRub Is Nothing Then
                    Dim DescrNodo As String = c.RagSoc

                    DescrNodo &= " - Peso: " & c.Peso & ", Colli: " & c.NumColli

                    NodoRub = NodoCorr.Nodes.Add(ChiaveConsegna, DescrNodo, 10, 10)
                    'NodoRub.Expand()
                    'NodoRub.EnsureVisible()
                End If
                Dim Icona As Integer = 9

                If c.Inserito Then Icona = 8

                Dim nodoOrd As TreeNode = NodoRub.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                nodoOrd.Tag = c
                If c.Giorno.Date = Now.Date Then NodoData.Expand()
                NodoCorr.Expand()
                'NodoRub.Expand()
            Next
        End Using
    End Sub

    Private Sub CaricaMerceSpedire()
        Cursor = Cursors.WaitCursor

        Try

            Using mgr As New ConsegneRicercaDAO
                Dim LstM As New List(Of ConsegnaRicerca)
                Dim ListaStati As String = ""

                Select Case True
                    Case rdoDaImballare.Checked
                        ListaStati = enStatoOrdine.Registrato & "," &
                                    enStatoOrdine.InSospeso & "," &
                                    enStatoOrdine.InCodaDiStampa & "," &
                                    enStatoOrdine.StampaInizio & "," &
                                    enStatoOrdine.StampaFine & "," &
                                    enStatoOrdine.FinituraCommessaInizio & "," &
                                    enStatoOrdine.FinituraCommessaFine & "," &
                                    enStatoOrdine.FinituraProdottoInizio & "," &
                                    enStatoOrdine.FinituraProdottoFine & "," &
                                    enStatoOrdine.Imballaggio & "," &
                                    enStatoOrdine.ImballaggioCorriere
                    Case rdoGiaImballati.Checked
                        ListaStati = enStatoOrdine.ProntoRitiro
                    Case rdoInConsegna.Checked
                        ListaStati = enStatoOrdine.InConsegna & "," &
                                    enStatoOrdine.UscitoMagazzino
                End Select

                LstM = mgr.Lista(-1, 0, , , ListaStati, , , , , CInt(enCorriere.RitiroCliente) & "," & CInt(enCorriere.TipografiaFormer))
                If chkSoloRegistratiCorriere.Checked Then
                    LstM = LstM.FindAll(Function(singC) singC.IdStatoConsegna = enStatoConsegna.RegistrataCorriere)
                End If
                LstM.Sort(AddressOf Comparer)
                tvMerceDaSpedire.Nodes.Clear()

                For Each c As ConsegnaRicerca In LstM

                    If rdoInConsegna.Checked Then

                        Dim ChiaveData As String = "D" & c.Giorno.ToString("ddMMyyyy")
                        Dim NodoData As TreeNode = tvMerceDaSpedire.Nodes(ChiaveData)
                        If NodoData Is Nothing Then
                            NodoData = tvMerceDaSpedire.Nodes.Add(ChiaveData, c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                            'NodoCorr.Expand()
                        End If
                        Dim ChiaveCorriere As String = "C" & c.IdCorr
                        Dim ChiaveRubrica As String = "R" & c.IdRub
                        Dim ChiaveConsegna As String = "S" & c.IdCons
                        Dim ChiaveOrdine As String = "O" & c.IdOrd

                        Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
                        If NodoCorr Is Nothing Then
                            NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, c.CorriereNome, 6, 6)
                            'NodoCorr.Expand()
                        End If

                        Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
                        If NodoRub Is Nothing Then
                            NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, c.RagSoc, 0, 0)
                            'NodoRub.Expand()
                            'NodoRub.EnsureVisible()
                        End If

                        Dim NodoCons As TreeNode = NodoRub.Nodes(ChiaveConsegna)
                        If NodoCons Is Nothing Then
                            NodoCons = NodoRub.Nodes.Add(ChiaveConsegna, "Consegna programmata del " & c.Giorno & " - Colli: " & c.NumColli & ", Peso: " & c.Peso, 10, 10)
                            'NodoRub.Expand()
                            'NodoRub.EnsureVisible()
                        End If
                        Dim Icona As Integer = 9
                        If rdoGiaImballati.Checked Then
                            Icona = 1
                        Else
                            If c.Inserito Then Icona = 8
                        End If
                        Dim nodoOrd As TreeNode = NodoCons.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                        nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                        nodoOrd.Tag = c
                        If c.Giorno.Date = Now.Date Then NodoData.Expand()
                        NodoCorr.Expand()
                        'NodoRub.Expand()

                    Else

                        'Dim ChiaveData As String = "D" & c.Giorno.ToString("ddMMyyyy")
                        'Dim NodoData As TreeNode = tvClienti.Nodes(ChiaveData)
                        'If NodoData Is Nothing Then
                        '    NodoData = tvClienti.Nodes.Add(ChiaveData, c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                        '    'NodoCorr.Expand()
                        'End If
                        Dim ChiaveCorriere As String = "C" & c.IdCorr
                        Dim ChiaveRubrica As String = "R" & c.IdRub
                        Dim ChiaveConsegna As String = "S" & c.IdCons
                        Dim ChiaveOrdine As String = "O" & c.IdOrd

                        Dim NodoCorr As TreeNode = tvMerceDaSpedire.Nodes(ChiaveCorriere)
                        If NodoCorr Is Nothing Then
                            NodoCorr = tvMerceDaSpedire.Nodes.Add(ChiaveCorriere, c.CorriereNome, 6, 6)
                            'NodoCorr.Expand()
                        End If
                        Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
                        If NodoRub Is Nothing Then
                            NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, c.RagSoc, 0, 0)
                            'NodoRub.Expand()
                            'NodoRub.EnsureVisible()
                        End If

                        Dim NodoCons As TreeNode = NodoRub.Nodes(ChiaveConsegna)
                        If NodoCons Is Nothing Then
                            NodoCons = NodoRub.Nodes.Add(ChiaveConsegna, "Consegna programmata del " & c.Giorno & " - Colli: " & c.NumColli & ", Peso: " & c.Peso, 10, 10)
                            'NodoRub.Expand()
                            'NodoRub.EnsureVisible()
                        End If
                        Dim Icona As Integer = 9
                        If rdoGiaImballati.Checked Then
                            Icona = 1
                        Else
                            If c.Inserito Then Icona = 8
                        End If
                        Dim nodoOrd As TreeNode = NodoCons.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                        nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                        nodoOrd.Tag = c
                        'If c.Giorno.Date = Now.Date Then NodoData.Expand()
                        NodoCorr.Expand()
                        'NodoRub.Expand()

                    End If
                Next
            End Using

        Catch ex As Exception

        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub rdoDaImballare_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDaImballare.CheckedChanged
        If sender.focused Then CaricaMerceSpedire()
    End Sub

    Private Sub rdoGiaImballati_CheckedChanged(sender As Object, e As EventArgs) Handles rdoGiaImballati.CheckedChanged
        If sender.focused Then CaricaMerceSpedire()
    End Sub

    Private Sub rdoInConsegna_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInConsegna.CheckedChanged
        If sender.focused Then CaricaMerceSpedire()
    End Sub

    Private Sub btnAggiornaMerceSpedire_Click(sender As Object, e As EventArgs) Handles btnAggiornaMerceSpedire.Click
        CaricaMerceSpedire()
    End Sub

    Private Sub btnRiapriCons_Click(sender As Object, e As EventArgs) Handles btnRiapriCons.Click
        Dim Node As TreeNode = tvMerceDaSpedire.SelectedNode
        If Not Node Is Nothing Then
            If Node.Name.StartsWith("O") Then
                Node = Node.Parent
            End If
            If Node.Name.StartsWith("S") Then
                Dim IdCons As Integer = Node.Name.Substring(1)
                ParentFormEx.Sottofondo()

                Using frm As New frmConsegnaProgrammata
                    frm.Carica(IdCons)
                End Using

                ParentFormEx.Sottofondo()
            Else
                MessageBox.Show("Selezionare una consegna programmata dall'albero!")
            End If
        Else
            MessageBox.Show("Selezionare una consegna programmata dall'albero!")
        End If
    End Sub

    Private Sub btnEmettiDocMerceSpedire_Click(sender As Object, e As EventArgs) Handles btnEmettiDocMerceSpedire.Click
        EmettiDocFiscale(tvMerceDaSpedire)
    End Sub

    Private Sub chkSoloRegistratiCorriere_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloRegistratiCorriere.CheckedChanged
        CaricaMerceSpedire()
    End Sub

    Private Sub TvMerceUscita_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvMerceUscita.AfterSelect
        If Not e.Node Is Nothing Then
            If e.Node.Name.StartsWith("O") Then
                Dim IdOrd As Integer = e.Node.Name.Substring(1)

                UcOrdiniAnteprimaFatt.Carica(IdOrd)

            End If
        End If
    End Sub

    Private Sub tvMerceUscita_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tvMerceUscita.MouseDoubleClick

    End Sub

    Private Sub tvMerceUscita_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvMerceUscita.NodeMouseDoubleClick
        If Not e.Node Is Nothing Then
            If e.Node.Name.StartsWith("O") Then
                Dim IdOrd As Integer = e.Node.Name.Substring(1)
                ParentFormEx.Sottofondo()
                Using f As New frmOrdine
                    f.Carica(IdOrd)
                End Using
                ParentFormEx.Sottofondo()

            End If
        End If
    End Sub
End Class
