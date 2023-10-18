Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports FormerConfig
Imports FormerPrinter

Public Class ucOperatoreConsegna
    Inherits ucFormerUserControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White
        btnCodTrack.Top = btnConsegne.Top

        lblLegRC.BackColor = FormerColori.ColoreCorriereRitiroCliente
        lblLegTF.BackColor = FormerColori.ColoreCorriereTipografiaFormer
        lblLegAC.BackColor = FormerColori.ColoreCorriereAltro
        lblLegACCodTrack.BackColor = FormerColori.ColoreCorriereAltro

        CaricaCombo()
        UcFiltroCorriereConsegne.SelezionaCorriere(enCorriere.GLS)

    End Sub
    Private _CorrSelConsegnaMerci As Integer = enCorriere.RitiroCliente

    Public Sub Carica()

        CaricaConsegnaMerci()

    End Sub

    Private Sub CaricaCombo()
        Try
            Using mgr As New ZoneDAO
                Dim lst As List(Of Zona) = mgr.GetAll(LFM.Zona.Descrizione, True)
                cmbZona.DisplayMember = "Descrizione"
                cmbZona.ValueMember = "Id"
                cmbZona.DataSource = lst
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Property _AltroCorrCodTrack As Boolean = False

    Private Sub CaricaConsegnaMerci()

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try

            Select Case _CorrSelConsegnaMerci
                Case enCorriere.RitiroCliente
                    'lblCorrConsScelto.Text = "Ritiro Cliente"
                    lblLegRC.Font = New Font(lblLegRC.Font, FontStyle.Bold)
                    lblLegTF.Font = New Font(lblLegTF.Font, FontStyle.Regular)
                    lblLegAC.Font = New Font(lblLegAC.Font, FontStyle.Regular)
                    lblLegACCodTrack.Font = New Font(lblLegACCodTrack.Font, FontStyle.Regular)
                    lblCorrConsScelto.BackColor = FormerColori.ColoreCorriereRitiroCliente
                    CaricaConsegnaMerciRitCli()
                Case enCorriere.TipografiaFormer
                    'lblCorrConsScelto.Text = "Tipografia Former"
                    lblLegRC.Font = New Font(lblLegRC.Font, FontStyle.Regular)
                    lblLegTF.Font = New Font(lblLegTF.Font, FontStyle.Bold)
                    lblLegAC.Font = New Font(lblLegAC.Font, FontStyle.Regular)
                    lblLegACCodTrack.Font = New Font(lblLegACCodTrack.Font, FontStyle.Regular)
                    lblCorrConsScelto.BackColor = FormerColori.ColoreCorriereTipografiaFormer
                    CaricaConsegnaMerciTipFormer()
                Case enCorriere.AltroCorriere
                    'lblCorrConsScelto.Text = "Altro Corriere"
                    lblLegRC.Font = New Font(lblLegRC.Font, FontStyle.Regular)
                    lblLegTF.Font = New Font(lblLegTF.Font, FontStyle.Regular)
                    If _AltroCorrCodTrack = False Then
                        lblLegAC.Font = New Font(lblLegAC.Font, FontStyle.Bold)
                        lblLegACCodTrack.Font = New Font(lblLegACCodTrack.Font, FontStyle.Regular)
                    Else
                        lblLegAC.Font = New Font(lblLegAC.Font, FontStyle.Regular)
                        lblLegACCodTrack.Font = New Font(lblLegACCodTrack.Font, FontStyle.Bold)
                    End If
                    lblCorrConsScelto.BackColor = FormerColori.ColoreCorriereAltro
                    CaricaConsMerciAltroCorr()
            End Select

        Catch ex As Exception
            'MessageBox.Show("Si è verificato un errore nel caricamento dei dati: " & ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub CaricaConsMerciAltroCorr(Optional ByVal Iniziale As String = "",
                          Optional ByVal IdRub As Integer = 0,
                          Optional ByVal TestoLibero As String = "")

        'btnBordero.Visible = False

        ' Dim IdCorrString As String = "(" & UcFiltroCorriereImballoCorriere.CorriereSelezionato & ")"
        _IdCorr = UcFiltroCorriereConsegne.CorriereSelezionatoEnum

        Using mgr As New ConsegneProgrammateDAO
            _lstConsegne = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.InConsegna),
                                       New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.No),
                                       New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, String.Empty, "<>"),
                                       New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.DataTrasmissioneCorriere, Now.Date))
        End Using

        'If _lstConsegne.Count Then
        ' btnBordero.Visible = True
        'End If

        Dim Corriere As String = String.Empty

        'Dim SoloGls As Boolean = chkSoloGlsImballoCorr.Checked

        Dim FiltroCorriere As String = UcFiltroCorriereConsegne.CorriereSelezionato

        Using mgr As New ConsegneRicercaDAO
            Dim LstM As New List(Of ConsegnaRicerca)
            Dim ListaStati As String = enStatoOrdine.Preinserito & "," &
                                        enStatoOrdine.RefineAutomatico & "," &
                                        enStatoOrdine.Registrato & "," &
                                        enStatoOrdine.InCodaDiStampa & "," &
                                        enStatoOrdine.StampaInizio & "," &
                                        enStatoOrdine.StampaFine & "," &
                                        enStatoOrdine.FinituraCommessaInizio & "," &
                                        enStatoOrdine.FinituraCommessaFine & "," &
                                        enStatoOrdine.FinituraProdottoInizio & "," &
                                        enStatoOrdine.FinituraProdottoFine & "," &
                                        enStatoOrdine.Imballaggio & "," &
                                        enStatoOrdine.ImballaggioCorriere & "," &
                                        enStatoOrdine.ProntoRitiro & "," & '& "," & _'& "," & _
                                        enStatoOrdine.UscitoMagazzino & "," &
                                        enStatoOrdine.InConsegna

            'enStatoOrdine.ProntoRitiro()
            LstM = mgr.Lista(-1, 0, , , ListaStati, , , Iniziale, TestoLibero, CInt(enCorriere.RitiroCliente) & "," & CInt(enCorriere.TipografiaFormer) & "," & CInt(enCorriere.TipografiaFormerFuoriRaccordo), , , , , , FiltroCorriere)
            LstM.Sort(AddressOf Comparer)
            tvwConsegnaMerci.Nodes.Clear()
            tvwConsegnaMerciNP.Nodes.Clear()

            For Each c As ConsegnaRicerca In LstM
                Dim checkOk As Boolean = True
                Dim tvwDest As TreeView = Nothing
                'If chkSoloConsegnabili.Checked Then
                '    If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
                '        checkOk = False
                '    End If
                '    If _AltroCorrCodTrack = False Then
                '        If c.CodTrack = String.Empty Then
                '            checkOk = False
                '        End If
                '    Else
                '        If c.CodTrack <> String.Empty Then
                '            checkOk = False
                '        End If
                '    End If
                'Else
                If _AltroCorrCodTrack Then
                    If c.CodTrack <> String.Empty Then
                        checkOk = False
                    End If
                End If
                'End If

                If chkAncheInConsegna.Checked = False Then
                    If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.UscitoMagazzino Or x.Stato = enStatoOrdine.InConsegna).Count <> 0 Then
                        checkOk = False
                    End If
                End If

                If checkOk Then
                    If cmbZona.SelectedValue Then
                        If c.Cliente.IdZona <> cmbZona.SelectedValue Then
                            checkOk = False
                        End If
                    End If
                End If

                If checkOk Then

                    If c.ListaOrdini.FindAll(Function(x) x.Stato < enStatoOrdine.ProntoRitiro).Count = 0 Then
                        tvwDest = tvwConsegnaMerci
                    Else
                        tvwDest = tvwConsegnaMerciNP
                    End If

                    Dim ChiaveData As String = "D" & c.Giorno.ToString("ddMMyyyy")
                    Dim NodoData As TreeNode = tvwDest.Nodes(ChiaveData)
                    If NodoData Is Nothing Then
                        NodoData = tvwDest.Nodes.Add(ChiaveData, c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                        'NodoCorr.Expand()
                        If c.HaOrdiniConDataGarantita Then
                            NodoData.BackColor = Color.Red
                            NodoData.ExpandAll()
                            NodoData.EnsureVisible()
                        End If
                    End If
                    Dim ChiaveCorriere As String = "C" & c.IdCorr
                    Dim ChiaveRubrica As String = "S" & c.IdCons
                    Dim ChiaveOrdine As String = "O" & c.IdOrd

                    Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
                    If NodoCorr Is Nothing Then
                        NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, c.CorriereNome, 6, 6)
                        'NodoCorr.Expand()
                    End If
                    Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
                    If NodoRub Is Nothing Then

                        Dim DescrRub As String = c.RagSoc

                        Dim Prioritaria As Boolean = False

                        If c.ListaOrdini.FindAll(Function(x) x.Priorita = enSiNo.Si).Count Then
                            Prioritaria = True
                        End If

                        If Prioritaria Then DescrRub &= " (PRIORITARIA)"

                        Dim DescrInd As String = " (" & c.Cliente.IndirizzoRegistrazione & ")"

                        If c.IdIndirizzo Then
                            'qui devo calcolare l'indirizzo
                            Dim I As New Indirizzo
                            I.Read(c.IdIndirizzo)
                            DescrInd = " (" & I.Riassunto & ")"
                            I = Nothing
                        End If

                        DescrRub &= DescrInd

                        NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, DescrRub, 0, 0)

                        If Prioritaria Then DescrRub &= NodoRub.BackColor = Color.Red

                        'NodoRub.Expand()
                        'NodoRub.EnsureVisible()
                    End If
                    Dim Icona As Integer = 9

                    If c.Inserito Then Icona = 8



                    If c.Ordine.ConsegnaGarantita <> Date.MinValue Then
                        Icona = 13
                    End If

                    Dim nodoOrd As TreeNode = NodoRub.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                    nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                    nodoOrd.Tag = c
                    If c.Giorno.Date = Now.Date Then NodoData.Expand()
                    If c.HaOrdiniConDataGarantita Then nodoOrd.EnsureVisible()
                    NodoCorr.Expand()

                    If tvwDest Is tvwConsegnaMerciNP Then
                        If c.StatoOrdine = enStatoOrdine.ProntoRitiro Then
                            nodoOrd.EnsureVisible()
                        End If
                    End If
                    'NodoRub.Expand()
                End If

            Next
        End Using
    End Sub

    Private Sub NodoSelezionato(e As TreeViewEventArgs)
        Dim IdRub As Integer = 0


        If e.Node.Name.StartsWith("O") Then
            Dim IdOrd As Integer = e.Node.Name.Substring(1)
            Cursor.Current = Cursors.WaitCursor

            If UcOrdiniListaPreview.Visible Then IdRub = e.Node.Parent.Parent.Name.Substring(1)

            RaiseEvent OrdineSelezionato(IdOrd)

            Cursor.Current = Cursors.Default
        ElseIf e.Node.Name.StartsWith("S") Then
            If UcOrdiniListaPreview.Visible Then IdRub = e.Node.Parent.Name.Substring(1)
        ElseIf e.Node.Name.StartsWith("R") Then
            If UcOrdiniListaPreview.Visible Then IdRub = e.Node.Name.Substring(1)
        End If

        If IdRub Then
            UcOrdiniListaPreview.Carica(IdRub, enCorriere.RitiroCliente)
        End If

    End Sub

    Private Function GetNodoRubrica(ByRef N As TreeNode) As TreeNode
        If Not N Is Nothing Then
            If N.Name.StartsWith("R") Then
                Return N
            Else
                Return GetNodoRubrica(N.Parent)
            End If
        End If

    End Function

    Private Function GetFirstNode(ByRef N As TreeNode) As TreeNode
        If N.Parent Is Nothing Then
            Return N
        Else
            Return GetFirstNode(N.Parent)
        End If
    End Function

    Private Sub SelezionaNodoParitario(sender As TreeView, e As TreeViewEventArgs)
        Dim tvwDest As TreeView = Nothing
        If Not sender.SelectedNode Is Nothing Then
            If sender Is tvwConsegnaMerci Then
                tvwDest = tvwConsegnaMerciNP
            Else
                tvwDest = tvwConsegnaMerci
            End If

            Dim node As TreeNode = sender.SelectedNode
            Dim NodeFirst As TreeNode = GetFirstNode(node)

            node = GetNodoRubrica(NodeFirst)

            If Not node Is Nothing AndAlso node.Name.StartsWith("R") Then


                Dim nodi As TreeNode() = tvwDest.Nodes.Find(node.Name, True)
                If nodi.Count Then
                    Dim nodoDest As TreeNode = nodi(0)
                    If Not nodoDest Is Nothing Then
                        If nodoDest.IsExpanded = False Then
                            tvwDest.SelectedNode = nodoDest
                            tvwDest.CollapseAll()

                            nodoDest.ExpandAll()
                        End If

                        If nodoDest.IsVisible = False Then
                            nodoDest.EnsureVisible()
                        End If


                    End If
                End If


            End If
        End If

    End Sub

    Private Sub tvClienti_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwConsegnaMerci.AfterSelect, tvwConsegnaMerciNP.AfterSelect



        If sender.focused Then
            UltimaTreeViewClicked = sender
            SelezionaNodoParitario(sender, e)
            NodoSelezionato(e)
        End If



    End Sub

    Public Event OrdineSelezionato(ByVal IdOrdine As Integer)

    Private Sub lblLegRC_Click(sender As Object, e As EventArgs) Handles lblLegRC.Click
        Cursor.Current = Cursors.WaitCursor
        'SplitContainerTvw.SplitterDistance = SplitContainerTvw.Width





        UcOrdiniListaPreview.Visible = True
        UcOrdiniListaPreview.Reset
        tvwConsegnaMerci.Height = UcOrdiniListaPreview.Top - tvwConsegnaMerci.Top - 6


        lblTipoAlbero.Visible = False
        rdoAlberoCliente.Visible = False
        rdoAlberoData.Visible = False
        'chkSoloGlsConsegne.Visible = False
        UcFiltroCorriereConsegne.Visible = False
        'btnBordero.Visible = False
        BorderoGLSToolStripMenuItem.Enabled = False
        EtichetteGLSToolStripMenuItem.Enabled = False
        btnConsegne.Visible = True
        btnCodTrack.Visible = False
        _CorrSelConsegnaMerci = enCorriere.RitiroCliente
        CaricaConsegnaMerci()

        Cursor.Current = Cursors.Default


    End Sub

    Private Sub lblLegTF_Click(sender As Object, e As EventArgs) Handles lblLegTF.Click
        Cursor.Current = Cursors.WaitCursor
        'SplitContainerTvw.SplitterDistance = SplitContainerTvw.Width / 2

        UcOrdiniListaPreview.Visible = False
        UcOrdiniListaPreview.Reset()
        tvwConsegnaMerci.Height = UcOrdiniListaPreview.Top + UcOrdiniListaPreview.Height - tvwConsegnaMerci.Top


        lblTipoAlbero.Visible = True
        rdoAlberoCliente.Visible = True
        rdoAlberoData.Visible = True
        'chkSoloGlsConsegne.Visible = False
        UcFiltroCorriereConsegne.Visible = False
        BorderoGLSToolStripMenuItem.Enabled = False
        EtichetteGLSToolStripMenuItem.Enabled = False
        'btnBordero.Visible = False
        btnConsegne.Visible = True
        btnCodTrack.Visible = False
        _CorrSelConsegnaMerci = enCorriere.TipografiaFormer
        CaricaConsegnaMerci()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lblLegAC_Click(sender As Object, e As EventArgs) Handles lblLegAC.Click
        Cursor.Current = Cursors.WaitCursor
        UcOrdiniListaPreview.Visible = False
        UcOrdiniListaPreview.Reset()
        tvwConsegnaMerci.Height = UcOrdiniListaPreview.Top + UcOrdiniListaPreview.Height - tvwConsegnaMerci.Top

        lblTipoAlbero.Visible = False
        rdoAlberoCliente.Visible = False
        rdoAlberoData.Visible = False
        'chkSoloGlsConsegne.Visible = True
        UcFiltroCorriereConsegne.Visible = True
        BorderoGLSToolStripMenuItem.Enabled = True
        EtichetteGLSToolStripMenuItem.Enabled = True
        'btnBordero.Visible = False
        btnConsegne.Visible = True
        btnCodTrack.Visible = False
        _CorrSelConsegnaMerci = enCorriere.AltroCorriere
        _AltroCorrCodTrack = False
        CaricaConsegnaMerci()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lblLegACCodTrack_Click(sender As Object, e As EventArgs) Handles lblLegACCodTrack.Click
        Cursor.Current = Cursors.WaitCursor
        UcOrdiniListaPreview.Visible = False
        UcOrdiniListaPreview.Reset()
        tvwConsegnaMerci.Height = UcOrdiniListaPreview.Top + UcOrdiniListaPreview.Height - tvwConsegnaMerci.Top

        lblTipoAlbero.Visible = False
        rdoAlberoCliente.Visible = False
        rdoAlberoData.Visible = False
        'chkSoloGlsConsegne.Visible = True
        UcFiltroCorriereConsegne.Visible = True
        BorderoGLSToolStripMenuItem.Enabled = False
        'btnBordero.Visible = False
        btnConsegne.Visible = False
        btnCodTrack.Visible = True
        _CorrSelConsegnaMerci = enCorriere.AltroCorriere
        _AltroCorrCodTrack = True
        CaricaConsegnaMerci()
        Cursor.Current = Cursors.Default
    End Sub

    Private Function GetIdCons(Nodo As TreeNode) As Integer
        Dim ris As Integer = 0

        If Not Nodo Is Nothing Then

            If Nodo.Name.StartsWith("R") Then
                If Nodo.Nodes.Count = 1 Then
                    ris = GetIdCons(Nodo.Nodes(0))
                End If
            ElseIf Nodo.Name.StartsWith("S") Then
                ris = Nodo.Name.Substring(1)
            Else
                ris = GetIdCons(Nodo.Parent)
            End If
        End If

        Return ris
    End Function

    Private Sub btnCodTrack_Click(sender As Object, e As EventArgs) Handles btnCodTrack.Click

        'qui vedo se ho l'id della consegna o se lo posso recuperare

        'If Not _UltimaTreeViewClicked Is Nothing AndAlso Not _UltimaTreeViewClicked.SelectedNode Is Nothing Then
        Dim Nodo As TreeNode = UltimaTreeViewClicked.SelectedNode
        Dim IdCons As Integer = GetIdCons(Nodo)

            If IdCons Then
                'avanti da consegna

                Dim C As New ConsegnaProgrammata
                C.Read(IdCons)

                Dim ris As String = "0"

                ParentFormEx.Sottofondo()

                If C.IdCorr = enCorriere.Bartolini Or C.IdCorr = enCorriere.PortoAssegnatoBartolini Then
                    Using x As New frmCodTrackBrt
                        ris = x.Carica(IdCons)
                    End Using
                ElseIf C.IdCorr = enCorriere.GLS Or C.IdCorr = enCorriere.PortoAssegnatoGLS Or C.IdCorr = enCorriere.GLSIsole Then
                    If Not C.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
                        Using x As New frmCodTrackGls
                            ris = x.Carica(IdCons)
                        End Using
                    Else
                        MessageBox.Show("Per poter editare manualmente il codice di tracking, devi prima eliminare la registrazione di gls!")
                    End If
                End If

                ParentFormEx.Sottofondo()

                If ris <> "0" Then
                    CaricaConsegnaMerci()
                End If

            Else
                MessageBox.Show("Selezionare una consegna dall'albero")
            End If
        'Else
        'MessageBox.Show("Selezionare una consegna dall'albero")
        'End If


    End Sub
    Private _UltimaTreeViewClicked As TreeView = Nothing
    Private Property UltimaTreeViewClicked As TreeView
        Get
            If _UltimaTreeViewClicked Is Nothing Then
                _UltimaTreeViewClicked = tvwConsegnaMerci
            End If
            Return _UltimaTreeViewClicked
        End Get
        Set(value As TreeView)
            _UltimaTreeViewClicked = value
        End Set
    End Property

    Private Sub btnConsegne_Click(sender As Object, e As EventArgs) Handles btnConsegne.Click
        'qui vedo se ho l'id della consegna o se lo posso recuperare

        'If Not _UltimaTreeViewClicked Is Nothing AndAlso Not _UltimaTreeViewClicked.SelectedNode Is Nothing Then
        Dim Nodo As TreeNode = UltimaTreeViewClicked.SelectedNode
        Dim IdCons As Integer = GetIdCons(Nodo)

        If IdCons And _CorrSelConsegnaMerci <> enCorriere.AltroCorriere Then
            'avanti da consegna

            Dim C As New ConsegnaProgrammata
            C.Read(IdCons)

            Dim ErroreStatoOrdini As Boolean = False

            If C.ListaOrdini.FindAll(Function(x) x.Stato <> enStatoOrdine.ProntoRitiro And x.Stato <> enStatoOrdine.UscitoMagazzino).Count Then
                If C.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito = False Then 'C.ModificabileEx(True, False, True, True, False, True).Modificabile = False Then
                    ErroreStatoOrdini = True
                End If
            Else
                If C.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.UscitoMagazzino).Count = C.ListaOrdini.Count Then
                    ErroreStatoOrdini = True
                End If
            End If

            If ErroreStatoOrdini = False Then

                Dim OkScoperto As Boolean = True

                If PostazioneCorrente.UtenteConnesso.Tipo <> enTipoUtente.Admin Then
                    If C.Cliente.ScopertoMax > 0 AndAlso C.Cliente.ScopertoComplessivo > C.Cliente.ScopertoMax Then
                        OkScoperto = False
                    End If
                End If

                If OkScoperto Then
                    If C.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count Then

                        Dim Ris As Integer = 0

                        ParentFormEx.Sottofondo()
                        Using frm As New frmConsegnaOrdiniRCTF
                            Ris = frm.Carica(IdCons)
                        End Using
                        ParentFormEx.Sottofondo()

                        If Ris Then CaricaConsegnaMerci()
                    Else
                        MessageBox.Show("La consegna non contiene ordini in stato pronto per il ritiro")
                    End If
                Else
                    MessageBox.Show("NON CONSEGNABILE PER PROBLEMI AMMINISTRATIVI, passare in amministrazione!")
                End If
            Else
                MessageBox.Show("La consegna non è modificabile e contiene ordini non pronti per il ritiro")
            End If
        Else
            If _CorrSelConsegnaMerci = enCorriere.AltroCorriere Then

                    Dim Ris As Integer = 0

                    ParentFormEx.Sottofondo()
                    Using frm As New frmConsegnaOrdiniCorriere
                        Ris = frm.Carica()
                    End Using
                    ParentFormEx.Sottofondo()

                    If Ris Then CaricaConsegnaMerci()
                Else
                    MessageBox.Show("Selezionare una consegna dall'albero")
                End If
            End If

        'Else
        'MessageBox.Show("Selezionare una consegna dall'albero")
        'End If

    End Sub

    Private Sub chkSoloConsegnabili_CheckedChanged(sender As Object, e As EventArgs)
        'If chkSoloConsegnabili.Checked Then chkAncheInConsegna.Checked = False
        If sender.focused Then
            CaricaConsegnaMerci()
        End If
    End Sub

    Private Sub cmbZona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbZona.SelectedIndexChanged
        If sender.focused Then CaricaConsegnaMerci()
    End Sub

    Private Sub UcFiltroCorriereConsegne_SelezionatoCorriere(sender As Object) Handles UcFiltroCorriereConsegne.SelezionatoCorriere
        If sender.focused Then CaricaConsegnaMerci()
    End Sub

    Private Function ComparerConsM(ByVal x As ConsegnaRicerca,
                                   ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = x.Cliente.RagSocNome.CompareTo(y.Cliente.RagSocNome)
        If result = 0 Then result = x.Giorno.CompareTo(y.Giorno)

        Return result
    End Function

    Private Sub CaricaConsegnaMerciRitCli()

        Using mgr As New ConsegneRicercaDAO
            Dim LstM As New List(Of ConsegnaRicerca)
            Dim ListaStati As String = enStatoOrdine.Preinserito & "," &
                                        enStatoOrdine.RefineAutomatico & "," &
                                        enStatoOrdine.Registrato & "," &
                                        enStatoOrdine.InCodaDiStampa & "," &
                                        enStatoOrdine.StampaInizio & "," &
                                        enStatoOrdine.StampaFine & "," &
                                        enStatoOrdine.FinituraCommessaInizio & "," &
                                        enStatoOrdine.FinituraCommessaFine & "," &
                                        enStatoOrdine.FinituraProdottoInizio & "," &
                                        enStatoOrdine.FinituraProdottoFine & "," &
                                        enStatoOrdine.Imballaggio & "," &
                                        enStatoOrdine.ImballaggioCorriere & "," &
                                        enStatoOrdine.ProntoRitiro  '& "," & _'& "," & _


            If chkAncheInConsegna.Checked Then
                ListaStati &= "," & enStatoOrdine.UscitoMagazzino & "," & enStatoOrdine.InConsegna
            End If


            'enStatoOrdine.ProntoRitiro()
            LstM = mgr.Lista(-1, _CorrSelConsegnaMerci, , , ListaStati, , , , , )
            LstM.Sort(AddressOf ComparerConsM)
            tvwConsegnaMerci.Nodes.Clear()
            tvwConsegnaMerciNP.Nodes.Clear()
            For Each c As ConsegnaRicerca In LstM

                Dim checkOk As Boolean = True
                Dim tvwDest As TreeView = Nothing
                'If chkSoloConsegnabili.Checked Then
                '    If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
                '        checkOk = False
                '    End If
                'End If

                If checkOk Then
                    If cmbZona.SelectedValue Then
                        If c.Cliente.IdZona <> cmbZona.SelectedValue Then
                            checkOk = False
                        End If
                    End If
                End If

                If checkOk Then

                    If c.ListaOrdini.FindAll(Function(x) x.Stato < enStatoOrdine.ProntoRitiro).Count = 0 Then
                        tvwDest = tvwConsegnaMerci
                    Else
                        tvwDest = tvwConsegnaMerciNP
                    End If


                    Dim ChiaveRubrica As String = "R" & c.IdRub
                    Dim NodoRub As TreeNode = tvwDest.Nodes(ChiaveRubrica)
                    If NodoRub Is Nothing Then

                        Dim DescrRub As String = c.RagSoc

                        NodoRub = tvwDest.Nodes.Add(ChiaveRubrica, DescrRub, 0, 0)
                        'NodoRub.Expand()
                        'NodoRub.EnsureVisible()
                    End If

                    Dim ChiaveData As String = "S" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                    Dim NodoData As TreeNode = NodoRub.Nodes(ChiaveData)
                    If NodoData Is Nothing Then
                        NodoData = NodoRub.Nodes.Add(ChiaveData, "Consegna del " & c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                        If c.HaOrdiniConDataGarantita Then
                            NodoData.BackColor = Color.Red
                            NodoData.Expandall()
                            NodoData.EnsureVisible()
                        End If
                    End If
                    'Dim DescrInd As String = c.Cliente.IndirizzoPredefinito

                    'If c.IdIndirizzo Then
                    '    'qui devo calcolare l'indirizzo
                    '    Dim I As New Indirizzo
                    '    I.Read(c.IdIndirizzo)
                    '    DescrInd = I.Riassunto
                    '    I = Nothing
                    'End If

                    'Dim ChiaveInd As String = "I" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                    'Dim nodoInd As TreeNode = NodoData.Nodes(ChiaveInd)
                    'If nodoInd Is Nothing Then
                    '    nodoInd = NodoData.Nodes.Add("I" & c.IdCons, DescrInd, 12, 12)
                    'End If

                    Dim ChiaveOrdine As String = "O" & c.IdOrd

                    Dim Icona As Integer = 1

                    If c.Ordine.ConsegnaGarantita <> Date.MinValue Then
                        Icona = 13
                    End If

                    Dim nodoOrd As TreeNode = NodoData.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                    nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                    nodoOrd.Tag = c
                    If c.Giorno.Date = Now.Date Then NodoData.Expand()
                    If c.HaOrdiniConDataGarantita Then nodoOrd.EnsureVisible()
                    If tvwDest Is tvwConsegnaMerci Then
                        NodoData.Expand()
                    ElseIf tvwDest Is tvwConsegnaMerciNP Then
                        If c.StatoOrdine = enStatoOrdine.ProntoRitiro Then
                            NodoData.Expand()
                            nodoOrd.EnsureVisible()
                        End If
                    End If

                    'NodoRub.Expand()
                End If


            Next
        End Using
    End Sub

    Private Function Comparer(ByVal x As ConsegnaRicerca, ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = x.DataPrevistaConsegna.CompareTo(y.DataPrevistaConsegna)
        If result = 0 Then
            result = x.Cliente.RagSocNome.CompareTo(y.Cliente.RagSocNome)
            If result = 0 Then result = x.Inserito.CompareTo(y.Inserito)
        End If
        Return result
    End Function

    Private Function ComparerCli(ByVal x As ConsegnaRicerca,
                                 ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = x.Cliente.RagSocNome.CompareTo(y.Cliente.RagSocNome)
        If result = 0 Then result = x.Inserito.CompareTo(y.Inserito)
        Return result
    End Function

    Private Sub CaricaConsegnaMerciTipFormer()

        Using mgr As New ConsegneRicercaDAO

            Dim LstM As New List(Of ConsegnaRicerca)
            Dim ListaStati As String = enStatoOrdine.Preinserito & "," &
                                        enStatoOrdine.RefineAutomatico & "," &
                                        enStatoOrdine.Registrato & "," &
                                        enStatoOrdine.InCodaDiStampa & "," &
                                        enStatoOrdine.StampaInizio & "," &
                                        enStatoOrdine.StampaFine & "," &
                                        enStatoOrdine.FinituraCommessaInizio & "," &
                                        enStatoOrdine.FinituraCommessaFine & "," &
                                        enStatoOrdine.FinituraProdottoInizio & "," &
                                        enStatoOrdine.FinituraProdottoFine & "," &
                                        enStatoOrdine.Imballaggio & "," &
                                        enStatoOrdine.ImballaggioCorriere & "," &
                                        enStatoOrdine.ProntoRitiro  '& "," & _'& "," & _

            If chkAncheInConsegna.Checked Then
                ListaStati &= "," & enStatoOrdine.UscitoMagazzino & "," & enStatoOrdine.InConsegna
            End If

            'enStatoOrdine.ProntoRitiro()
            LstM = mgr.Lista(-1, _CorrSelConsegnaMerci, , , ListaStati)

            Dim VisualizzaPerCliente As Boolean = False
            If rdoAlberoCliente.Checked Then
                VisualizzaPerCliente = True
            End If

            If VisualizzaPerCliente = False Then
                LstM.Sort(AddressOf Comparer)
            Else
                LstM.Sort(AddressOf ComparerCli)
            End If

            tvwConsegnaMerci.Nodes.Clear()
            tvwConsegnaMerciNP.Nodes.Clear()

            For Each c As ConsegnaRicerca In LstM
                Dim checkOk As Boolean = True
                Dim tvwDest As TreeView = Nothing
                'If chkSoloConsegnabili.Checked Then
                '    If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
                '        checkOk = False
                '    End If
                'End If

                If checkOk Then
                    If cmbZona.SelectedValue Then
                        If c.Cliente.IdZona <> cmbZona.SelectedValue Then
                            checkOk = False
                        End If
                    End If
                End If

                If checkOk Then

                    If c.ListaOrdini.FindAll(Function(x) x.Stato < enStatoOrdine.ProntoRitiro).Count = 0 Then
                        tvwDest = tvwConsegnaMerci
                    Else
                        tvwDest = tvwConsegnaMerciNP
                    End If

                    If VisualizzaPerCliente Then

                        Dim ChiaveRubrica As String = "R" & c.IdRub
                        Dim NodoRub As TreeNode = tvwDest.Nodes(ChiaveRubrica)
                        If NodoRub Is Nothing Then

                            Dim DescrRub As String = c.RagSoc

                            NodoRub = tvwDest.Nodes.Add(ChiaveRubrica, DescrRub, 0, 0)
                            'NodoRub.Expand()
                            'NodoRub.EnsureVisible()
                        End If

                        Dim ChiaveData As String = "S" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                        Dim NodoData As TreeNode = NodoRub.Nodes(ChiaveData)
                        Dim DescrNodo As String = "Consegna del " & c.DataPrevistaConsegna.ToString("dd MMMM yyyy")

                        Dim Prioritaria As Boolean = False

                        If c.ListaOrdini.FindAll(Function(x) x.Priorita = enSiNo.Si).Count Then
                            Prioritaria = True
                        End If

                        If Prioritaria Then
                            DescrNodo &= " (PRIORITARIA)"
                        End If

                        If NodoData Is Nothing Then
                            NodoData = NodoRub.Nodes.Add(ChiaveData, DescrNodo, 7, 7)
                            If Prioritaria Then
                                NodoData.BackColor = Color.Red
                                NodoData.Expand()
                                NodoData.EnsureVisible()
                            ElseIf c.HaOrdiniConDataGarantita Then
                                NodoData.BackColor = Color.Red
                                NodoData.ExpandAll()
                                NodoData.EnsureVisible()
                            End If
                            'NodoCorr.Expand()

                        End If

                        'Dim DescrInd As String = c.Cliente.IndirizzoPredefinito

                        'If c.IdIndirizzo Then
                        '    'qui devo calcolare l'indirizzo
                        '    Dim I As New Indirizzo
                        '    I.Read(c.IdIndirizzo)
                        '    DescrInd = I.Riassunto
                        '    I = Nothing
                        'End If

                        'Dim ChiaveInd As String = "I" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                        'Dim nodoInd As TreeNode = NodoData.Nodes(ChiaveInd)
                        'If nodoInd Is Nothing Then
                        '    nodoInd = NodoData.Nodes.Add("I" & c.IdCons, DescrInd, 12, 12)
                        'End If

                        Dim ChiaveOrdine As String = "O" & c.IdOrd

                        Dim Icona As Integer = 1

                        If c.Ordine.ConsegnaGarantita <> Date.MinValue Then
                            Icona = 13
                        End If

                        Dim nodoOrd As TreeNode = NodoData.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                        nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                        nodoOrd.Tag = c
                        If c.Giorno.Date = Now.Date Then NodoData.Expand()
                        If c.HaOrdiniConDataGarantita Then nodoOrd.EnsureVisible()
                        If tvwDest Is tvwConsegnaMerci Then
                            NodoData.Expand()
                        ElseIf tvwDest Is tvwConsegnaMerciNP Then
                            If c.StatoOrdine = enStatoOrdine.ProntoRitiro Then
                                NodoData.Expand()
                                nodoOrd.EnsureVisible()
                            End If
                        End If

                        If Prioritaria Then
                            nodoOrd.EnsureVisible()
                        End If

                        'NodoRub.Expand()

                        'If tvwDest Is tvwConsegnaMerciNP Then
                        '    If c.StatoOrdine = enStatoOrdine.ProntoRitiro Then
                        '        nodoOrd.EnsureVisible()
                        '    End If
                        'End If
                    Else

                        Dim ChiaveData As String = "D" & c.DataPrevistaConsegna.ToString("ddMMyyyy")
                        Dim NodoData As TreeNode = tvwDest.Nodes(ChiaveData)
                        If NodoData Is Nothing Then
                            NodoData = tvwDest.Nodes.Add(ChiaveData, c.DataPrevistaConsegna.ToString("dd MMMM yyyy"), 7, 7)
                            'NodoCorr.Expand()
                        End If

                        Dim ChiaveDataMat As String = "D" & c.DataPrevistaConsegna.ToString("ddMMyyyy") & "M"
                        Dim ChiaveDataPom As String = "D" & c.DataPrevistaConsegna.ToString("ddMMyyyy") & "P"

                        Dim NodoMomRif As TreeNode = Nothing
                        Dim ChiaveRubrica As String = "S" & c.IdCons
                        Dim ChiaveOrdine As String = "O" & c.IdOrd
                        Dim ChiaveMomRif As String = String.Empty
                        Dim DescrNodoMomRif As String = String.Empty

                        If c.MatPom = enMomentoConsegna.Mattina Then
                            NodoMomRif = NodoData.Nodes(ChiaveDataMat)
                            DescrNodoMomRif = "Mattina"
                            ChiaveMomRif = ChiaveDataMat
                        Else
                            NodoMomRif = NodoData.Nodes(ChiaveDataPom)
                            DescrNodoMomRif = "Pomeriggio"
                            ChiaveMomRif = ChiaveDataPom
                        End If
                        If NodoMomRif Is Nothing Then
                            NodoMomRif = NodoData.Nodes.Add(ChiaveMomRif, DescrNodoMomRif.ToUpper, 11, 11)
                        End If

                        Dim NodoRub As TreeNode = NodoMomRif.Nodes(ChiaveRubrica)

                        Dim DescrInd As String = c.Cliente.IndirizzoRegistrazione

                        If c.IdIndirizzo Then
                            'qui devo calcolare l'indirizzo
                            Dim I As New Indirizzo
                            I.Read(c.IdIndirizzo)
                            DescrInd = I.Riassunto
                            I = Nothing
                        End If

                        If NodoRub Is Nothing Then

                            Dim DescrRub As String = c.RagSoc & " (" & DescrInd & ")"

                            NodoRub = NodoMomRif.Nodes.Add(ChiaveRubrica, DescrRub, 0, 0)
                            'NodoRub.Expand()
                            'NodoRub.EnsureVisible()
                        End If

                        'Dim ChiaveInd As String = "I" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                        'Dim nodoInd As TreeNode = NodoRub.Nodes(ChiaveInd)
                        'If nodoInd Is Nothing Then
                        '    nodoInd = NodoRub.Nodes.Add("I" & c.IdCons, DescrInd, 12, 12)
                        'End If

                        Dim Icona As Integer = 1

                        Dim nodoOrd As TreeNode = NodoRub.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                        nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                        nodoOrd.Tag = c
                        If c.Giorno.Date = Now.Date Then NodoData.Expand()
                        NodoMomRif.Expand()
                        'NodoRub.Expand()

                        If tvwDest Is tvwConsegnaMerciNP Then
                            If c.StatoOrdine = enStatoOrdine.ProntoRitiro Then
                                nodoOrd.EnsureVisible()
                            End If
                        End If

                    End If

                End If

            Next
        End Using
    End Sub

    Private _IdCorr As Integer = 0
    Private _lstConsegne As List(Of ConsegnaProgrammata) = Nothing

    Private Sub btnBordero_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RistampaBordero()
        'TODO: QUI DEVO VERIFICARE IL O I CORRIERI SELEZIONATI, FACCIO UN CICLO E, SE IL CASO (GLS) (RI)TRASMETTO LE SPEDIZIONI;
        'POI SIA PER GLS CHE BARTOLINI STAMPO IL BORDERO'

        Dim Corriere As String = String.Empty

        Select Case _IdCorr
            Case enCorriere.GLS
                Corriere = "GLS"
            Case enCorriere.Bartolini
                Corriere = "Bartolini"
        End Select

        If _IdCorr = enCorriere.GLS Then
            If MessageBox.Show("Confermi la ristampa del borderò di " & Corriere & "?", "Trasmissione Spedizione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'MessageBox.Show("Controlla che nella stampante non ci sia carta per fatture!")

                Dim lstConsegneColliGls As List(Of ConsegnaProgrammata) = New List(Of ConsegnaProgrammata)

                If _lstConsegne.Count Then
                    Dim Pt As New FormerWebLabeling.My.Templates.DistintaTemplate
                    Pt.Consegne = _lstConsegne
                    Dim Path As String = FormerPath.PathTempLocale()
                    'Dim NomeFile As String = FormerHelper.File.GetNomeFileTemp(".pdf")
                    'FormerHelper.PDF.ConvertHTMLToPDF(Pt.TransformText, Path & NomeFile)
                    'Dim StampanteDistintaSpedizione As String = Configuration.ConfigurationManager.AppSettings("StampantePDF")
                    'FormerHelper.PDF.StampaPdf(Path & NomeFile, StampanteDistintaSpedizione, 842, 595)
                    Dim NomeFile As String = FormerHelper.File.GetNomeFileTemp(".html")
                    Using objWriter As New System.IO.StreamWriter(Path & NomeFile)
                        objWriter.Write(Pt.TransformText)
                    End Using
                    'FormerHelper.File.ShellExtended(Path & NomeFile)

                    'STAMPO LA DISTINTA IN MODO DIRETTO SULLA STAMPANTE PREDEFINITA CON ORIENTAMENTO PREDEFINITO?
                    'Dim myWebBrowser As New WebBrowser
                    'AddHandler myWebBrowser.DocumentCompleted, AddressOf DocumentCompleted
                    'myWebBrowser.Navigate(Path & NomeFile)

                    'STAMPO LA DISTINTA PASSANDO PER FORM DI ANTEPRIMA
                    'qui ho il file completato e lo mando alla form di preview
                    ParentFormEx.Sottofondo()
                    Using x As New frmStampa
                        x.Carica(Path & NomeFile)
                    End Using
                    ParentFormEx.Sottofondo()
                    If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then
                        If MessageBox.Show("Vuoi anche ri-effettuare la trasmissione delle spedizioni etichettate a " & Corriere & "?", , MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Cursor.Current = Cursors.WaitCursor
                            For Each C In _lstConsegne
                                For i = 1 To C.NumColli
                                    lstConsegneColliGls.Add(C)
                                Next
                            Next

                            Dim ris As String = String.Empty
                            Try
                                ris = FormerWebLabeling.MgrWebLabelingGls.TrasmettiSpedizioniGls(lstConsegneColliGls)
                            Catch ex As Exception
                                ris = ex.Message
                            End Try
                            MessageBox.Show("Risultato trasmissione spedizioni: " & ris)
                            Cursor.Current = Cursors.Default
                        End If
                    End If
                Else
                    MessageBox.Show("Nessuna spedizione per cui stampare il borderò!")
                End If
            End If
        Else
            MessageBox.Show("Al momento la stampa della distinta e la trasmissione automatica delle spedizioni è disponibile solo per GLS!")
        End If
    End Sub

    Private Sub btnEtichOrdCons_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RistampaEtichetteOrdine()

        Dim Nodo As TreeNode = _UltimaTreeViewClicked.SelectedNode

        If Not Nodo Is Nothing AndAlso Nodo.Name.StartsWith("O") Then

            Dim IdOrd As Integer = Nodo.Name.Substring(1)
            If MessageBox.Show("Vuoi ristampare le etichette per l'ordine selezionato?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim O As New Ordine
                O.Read(IdOrd)

                If O.NumeroRealeColli = 0 Then

                    Dim P As New Prodotto
                    P.Read(O.IdProd)

                    Dim NumColli As Integer = P.NumColli
                    Dim NumColliUtente As String = InputBox("Inserisci il numero di pacchi reali dell'ordine", "Stampa etichette", NumColli)

                    If IsNumeric(NumColliUtente) AndAlso NumColliUtente <> 0 Then
                        O.NumeroRealeColli = NumColliUtente
                        O.Save()
                    End If
                End If

                If O.NumeroRealeColli Then
                    Dim x As New myPrinter

                    x.PrinterName = PostazioneCorrente.StampanteEtichette
                    x.IdOrd = IdOrd
                    x.NumColli = O.NumeroRealeColli
                    x.StampaEtichetteOrdine()
                    x = Nothing
                    MessageBox.Show("Etichette stampate correttamente")
                End If

            End If
        Else
            MessageBox.Show("Selezionare un ordine dall'albero delle consegne")
        End If
    End Sub

    Private Sub rdoAlberoData_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAlberoData.CheckedChanged
        If sender.focused Then CaricaConsegnaMerci()
    End Sub

    Private Sub rdoAlberoCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAlberoCliente.CheckedChanged
        If sender.focused Then CaricaConsegnaMerci()
    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click
        CaricaConsegnaMerci()
    End Sub

    Private Sub UcOrdiniListaPreview_OrdineSelezionato(IdOrdine As Integer) Handles UcOrdiniListaPreview.OrdineSelezionato
        RaiseEvent OrdineSelezionato(IdOrdine)
    End Sub

    Private Sub UcFiltroCorriereConsegne_Load(sender As Object, e As EventArgs) Handles UcFiltroCorriereConsegne.Load

    End Sub

    Private Sub EtichetteOrdineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EtichetteOrdineToolStripMenuItem.Click
        RistampaEtichetteOrdine()
    End Sub

    Private Sub BorderòGLSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorderoGLSToolStripMenuItem.Click
        RistampaBordero()
    End Sub

    Private Sub EtichetteGLSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EtichetteGLSToolStripMenuItem.Click
        RistampaEtichetteGLS
    End Sub

    Private Sub DocumentiFiscaliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentiFiscaliToolStripMenuItem.Click
        RistampaDocumentiFiscali
    End Sub

    Private Sub RistampaEtichetteGLS()
        Dim Nodo As TreeNode = _UltimaTreeViewClicked.SelectedNode
        If Not Nodo Is Nothing Then
            Dim IdCons As Integer = GetIdCons(Nodo)
            If IdCons Then
                If MessageBox.Show("Vuoi ristampare le etichette di GLS?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Using C As New ConsegnaProgrammata
                        C.Read(IdCons)
                        Cursor.Current = Cursors.WaitCursor
                        Try
                            MgrConsegneCorriere.GLS.EtichettaGls(C)
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try
                        Cursor.Current = Cursors.Default

                    End Using
                End If
            Else
                MessageBox.Show("Seleziona una consegna")
            End If
        End If
    End Sub

    Private Sub RistampaDocumentiFiscali()

        Dim Nodo As TreeNode = _UltimaTreeViewClicked.SelectedNode
        If Not Nodo Is Nothing Then
            Dim IdCons As Integer = GetIdCons(Nodo)
            If IdCons Then
                If MessageBox.Show("Confermi la ristampa dei documenti fiscali?", "Documenti Fiscali", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Using C As New ConsegnaProgrammata
                        C.Read(IdCons)
                        For Each R As Ricavo In C.ListaDocumenti
                            Try
                                MgrDocumentiFiscali.MessaggioModuloFattura(R, FormerConst.Fiscali.NumCopieDocFiscali)
                                'ProxyStampa.StampanteLibera = PostazioneCorrente.StampanteLiberaOperatore
                                'ProxyStampa.StampanteFatture = PostazioneCorrente.StampanteFattureOperatore
                                ProxyStampa.StampaDocumentoFiscale(R,
                                                                   False,
                                                                   FormerConst.Fiscali.NumCopieDocFiscali,
                                                                   PostazioneCorrente.UtenteConnesso.IdUt) 'modificato a true per stampare diretto
                                'ProxyStampa.StampanteLibera = PostazioneCorrente.StampanteLibera
                                'ProxyStampa.StampanteFatture = PostazioneCorrente.StampanteFatture
                                'STAMPA DOCUMENTO FISCALE OPERATORE una sola copia in caso di operatore per corriere
                            Catch ex As Exception
                                MessageBox.Show("Si è verificato un errore nella stampa dei documenti fiscali, ristamparli")
                            End Try

                        Next
                    End Using

                End If
            Else
                MessageBox.Show("Seleziona una consegna")
            End If

        End If

    End Sub

    Private Sub chkAncheInConsegna_CheckedChanged(sender As Object, e As EventArgs) Handles chkAncheInConsegna.CheckedChanged
        'If chkAncheInConsegna.Checked Then chkSoloConsegnabili.Checked = False
        If sender.focused Then
            CaricaConsegnaMerci()
        End If
    End Sub

    Private Sub BtnPronteApri_Click(sender As Object, e As EventArgs) Handles btnPronteApri.Click
        tvwConsegnaMerci.ExpandAll()
    End Sub

    Private Sub BtnPronteChiudi_Click(sender As Object, e As EventArgs) Handles btnPronteChiudi.Click
        tvwConsegnaMerci.CollapseAll()
    End Sub

    Private Sub BtnNPronteApri_Click(sender As Object, e As EventArgs) Handles btnNPronteApri.Click
        tvwConsegnaMerciNP.ExpandAll()
    End Sub

    Private Sub BtnNPronteChiudi_Click(sender As Object, e As EventArgs) Handles btnNPronteChiudi.Click
        tvwConsegnaMerciNP.CollapseAll()
    End Sub

End Class
