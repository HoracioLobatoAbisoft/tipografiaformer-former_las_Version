Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerWebLabeling
Imports FormerConfig

Public Class ucConsegneGiorno
    Inherits ucFormerUserControl

    Private _IdOrdAnteprima As Integer
    Private _Giorno As Date
    Private _IdOrdSel As Integer = 0
    Private _IdConsSel As Integer = 0
    Private _ListaStati As String = ""
    Private _IdZona As Integer = 0
    Private _IdOperatore As Integer = 0
    Private selectedTreeview As TreeView
    Private _IsOperatore As Boolean = False
    Private _SoloRegistratiCorriere As Boolean = False

    Public Property Operatore As Boolean = False

    Public Property IsOperatore As Boolean
        Get
            Return _IsOperatore
        End Get
        Set(value As Boolean)
            _IsOperatore = value
            If _IsOperatore Then
                tvwMatt.Indent = 20
                tvwMatt.ItemHeight = 25
                tvwPom.Indent = 20
                tvwPom.ItemHeight = 25

            End If
        End Set
    End Property

    Public ReadOnly Property Giorno As Date
        Get
            Return _Giorno
        End Get
    End Property
    Public ReadOnly Property SelectedNode As TreeNode
        Get
            Dim n As TreeNode = Nothing

            If selectedTreeview Is Nothing Then
                Try
                    selectedTreeview = GetChildAtPoint(Cursor.Position, GetChildAtPointSkip.None)
                Catch ex As Exception

                End Try
            End If

            If Not selectedTreeview Is Nothing Then
                n = selectedTreeview.GetNodeAt(Cursor.Position)
            End If
            Return n
        End Get
    End Property
    Public Property IdOrdSel As Integer
        Get
            Return _IdOrdSel
        End Get
        Set(ByVal value As Integer)
            _IdOrdSel = value
        End Set
    End Property

    Public ReadOnly Property IdConsegnaSel As Integer
        Get
            Return _IdConsSel
        End Get
    End Property

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()
        BackColor = Color.White
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

    End Sub
    Private _IdRub As Integer = 0
    Private _IdCorr As Integer = 0
    Public Property IdCorr As Integer
        Get
            Return _IdCorr
        End Get
        Set(ByVal value As Integer)
            _IdCorr = value
        End Set
    End Property

    Public Sub Carica(Optional ByVal Giorno As Date = Nothing, _
                      Optional ByVal IdRub As Integer = 0, _
                      Optional ByVal ListaStati As String = "", _
                      Optional ByVal IdZona As Integer = 0, _
                      Optional ByVal IdOperatore As Integer = 0, _
                      Optional ByVal SoloRegistratiCorriere As Boolean = False)

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Or
            PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.SuperOperatore Then

            tvwMatt.ContextMenuStrip = ContextMenu
            tvwPom.ContextMenuStrip = ContextMenu

        End If

        If Giorno = Date.MinValue Then
            If _Giorno = Date.MinValue Then _Giorno = Now.Date
            Giorno = _Giorno
        Else
            _Giorno = Giorno
        End If

        _IdRub = IdRub
        If ListaStati.Length Then _ListaStati = ListaStati
        _IdZona = IdZona
        _IdOperatore = IdOperatore

        lblGiorno.Text = Giorno.ToString("ddd dd MMMM")

        If DateDiff(DateInterval.Day, Giorno, Now.Date) = 0 Then
            lblGiorno.BackColor = Color.Red
            lblGiorno.ForeColor = Color.White
        Else
            lblGiorno.BackColor = Color.White
            lblGiorno.ForeColor = Color.Red
        End If

        _SoloRegistratiCorriere = SoloRegistratiCorriere

        'carico le consegne del giorno
        CaricaConsegne(_Operatore)

        'End If

    End Sub

    Private _ListaUnica As New List(Of ConsegnaRicerca)

    Private Sub CaricaConsegne(Optional ByVal Operatore As Boolean = False)
        _ListaUnica.Clear()
        Using Mgr As New ConsegneRicercaDAO
            Dim LstM As New List(Of ConsegnaRicerca)

            LstM = Mgr.Lista(enMomentoConsegna.Mattina, _IdCorr, _Giorno, _IdRub, _ListaStati, _IdZona, _IdOperatore, , , , , Operatore)
            If _SoloRegistratiCorriere Then
                LstM = LstM.FindAll(Function(singC) singC.IdStatoConsegna = enStatoConsegna.RegistrataCorriere)
            End If

            _ListaUnica.AddRange(LstM)

            CaricaVoci(LstM, tvwMatt)
            Dim LstP As New List(Of ConsegnaRicerca)

            LstP = Mgr.Lista(enMomentoConsegna.Pomeriggio, _IdCorr, _Giorno, _IdRub, _ListaStati, _IdZona, _IdOperatore, , , , , Operatore)
            If _SoloRegistratiCorriere Then
                LstP = LstP.FindAll(Function(singC) singC.IdStatoConsegna = enStatoConsegna.RegistrataCorriere)
            End If

            CaricaVoci(LstP, tvwPom)
            _ListaUnica.AddRange(LstP)

            MgrControl.AutoAdattaDimensioni(SplitGiorno, LstM.Count, LstP.Count)

        End Using

    End Sub

    Private Sub CaricaVoci(ByVal Lst As List(Of ConsegnaRicerca), ByVal tvw As TreeView)
        Dim ContCons As Integer = 0
        tvw.Nodes.Clear()
        For Each c As ConsegnaRicerca In Lst
            '_cnOld Corriere con id
            'Rn Rubrica con Id
            'Pn 
            'cerco se c'e' il nodo del corriere senno lo creo
            'cerco se c'e' il nodo del cliente come figlio senno lo creo
            'creo il nodo per la consegna dell'ordine 
            'in tag metto l'id della consegna programmata
            Dim ChiaveCorriere As String = "C" & c.IdCorr
            'Dim ChiaveRubrica As String = "C" & c.IdCorr & "R" & c.IdRub
            Dim ChiaveRubrica As String = "S" & c.IdCons
            Dim ChiaveIndirizzo As String = "I" & c.IdCons
            Dim ChiaveOrdine As String = "O" & c.IdOrd
            Dim DescrNodoPadre As String = Strings.Left(c.RagSoc, 32)

            'If c.IdCorr = 2 Then
            '    If c.IdOperatore Then
            '        Dim Utente As New Utente
            '        Utente.Read(c.IdOperatore)
            '        DescrNodoPadre &= " (" & Utente.Login & ")"
            '        Utente = Nothing
            '    End If
            'End If
            Dim NodoCorr As TreeNode = tvw.Nodes(ChiaveCorriere)
            If NodoCorr Is Nothing Then
                Dim NomeCorriere As String = c.CorriereNome
                Dim PosPar As Integer = NomeCorriere.IndexOf("(")

                If PosPar <> -1 Then

                    NomeCorriere = NomeCorriere.Substring(0, PosPar - 1)

                End If
                NodoCorr = tvw.Nodes.Add(ChiaveCorriere, NomeCorriere, 3, 3)
            End If
            'qui ho il nodo del corriere
            Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
            If NodoRub Is Nothing Then
                Dim HaUnPag As Boolean = c.HaUnPagamentoAnticipato
                Dim IcoPag As Integer = 7

                If HaUnPag Then
                    If c.PagamentoAnticipato.IdTipoPagamento <> enMetodoPagamento.PayPal Then
                        IcoPag = 8
                    End If
                End If


                NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, DescrNodoPadre, IIf(HaUnPag, IcoPag, 0), IIf(HaUnPag, IcoPag, 0))
                NodoRub.Tag = c.IdCons
                ContCons += 1
            End If
            'qui ho il cliente  e inserisco l'ordine 
            NodoCorr.Expand()
            Dim NodoInd As TreeNode = NodoRub.Nodes(ChiaveIndirizzo)
            If NodoInd Is Nothing Then

                Dim DescrInd As String = "Indirizzo: " & c.IndirizzoStr

                NodoInd = NodoRub.Nodes.Add(ChiaveIndirizzo, DescrInd, 6, 6)
            End If


            Dim NodoOrdine As TreeNode
            Dim DescrOrd As String = Strings.Left("Ord. " & c.IdOrd & " - " & c.ProdottoNome, 32)

            If c.Ordine.TipoConsegna = enTipoConsegna.Fast Then
                NodoRub.ForeColor = Color.Red
            End If

            Dim IcoOrd As Integer = 1
            If c.Ordine.ConsegnaGarantita <> Date.MinValue Then
                IcoOrd = 9
            End If


            NodoOrdine = NodoRub.Nodes.Add("O" & c.IdOrd, DescrOrd, IcoOrd, IcoOrd)
            NodoOrdine.Tag = c
            NodoOrdine.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
            'Nd = tvw.Nodes.Add("C" & c.IdCons.ToString, DescrNodoPadre, 0, 0)
            'If c.IdCorr = 3 Then
            '    Nd.Tag = c.CodTrack
            'Else
            '    Nd.Tag = ""
            'End If

            'Dim NodoInserito As TreeNode
            'NodoInserito = Nd.Nodes("D" & IIf(o.IdDoc, o.IdDoc, "0")).nodes.Add("O" & o.IdOrd, "Ord." & o.IdOrd & " - " & o.ProdottoDescrizione, 1, 1)
            'Dim coloreSfondo As Color = o.StatoColore
            'NodoInserito.BackColor = coloreSfondo


            'Dim vf As New cContabRicaviColl
            'Dim DtVF As DataTable, drvf As DataRow
            'DtVF = vf.ListaDocByIdCons(c.IdCons)

            ''carico i documenti
            'For Each drvf In DtVF.Rows

            '    Dim TipoDocFisc As String = ""

            '    Select Case drvf("Tipo")
            '        Case enTipoDocumento.enTipoDocDDT
            '            TipoDocFisc = "D.D.T. "
            '        Case enTipoDocumento.enTipoDocFattura
            '            TipoDocFisc = "Fattura "
            '        Case enTipoDocumento.enTipoDocPreventivo
            '            TipoDocFisc = "Preventivo "

            '    End Select

            '    Nd.Nodes.Add("D" & drvf("IdRicavo").ToString, TipoDocFisc & drvf("Numero").ToString & " del " & drvf("DataRicavo").ToString, 2, 2)
            'Next
            'vf = Nothing

            'carico gli ordini
            ' Nd.Nodes.Add("D0", "Doc.Fiscale da emettere", 2, 2)

            'Dim Mgr As New OrdiniDAO
            'Dim LstO As List(Of OrdineRicerca) = Mgr.ListaOrdiniByIdCons(c.IdCons)

            'For Each o As OrdineRicerca In LstO

            '    Dim NodoInserito As TreeNode
            '    NodoInserito = Nd.Nodes("D" & IIf(o.IdDoc, o.IdDoc, "0")).nodes.Add("O" & o.IdOrd, "Ord." & o.IdOrd & " - " & o.ProdottoDescrizione, 1, 1)
            '    Dim coloreSfondo As Color = o.StatoColore
            '    NodoInserito.BackColor = coloreSfondo
            'Next

            'Dim IdStatoCons As Integer = IIf(IsDBNull(c.IdStatoConsegna), 1, c.IdStatoConsegna)
            'Dim MgrS As New StatoConsegneDAO()
            'Dim Cons As StatoConsegna = MgrS.Read(IdStatoCons)
            'Nd.Nodes.Add("S" & c.IdCons, Cons.Descrizione, 3, 3)
            'Dim NodoColli As TreeNode = Nd.Nodes.Add("N" & c.IdCons, "N°Colli: " & c.NumColli & ", Peso: " & c.Peso, 4, 4)
            'NodoColli.Tag = c.NumColli

            ''Dim NodoPeso As TreeNode = Nd.Nodes.Add("C" & Dr("idcons").ToString, "Peso: " & Dr("Peso").ToString, 5, 5)
            ''NodoPeso.Tag = Dr("Peso")
            ''Mgr = Nothing
            'Cons = Nothing
        Next
        Lst = Nothing
        tvw.Sort()
        If tvw.Name = "tvwMatt" Then
            lblMatt.Text = "Mattino (" & ContCons & ")"
        Else
            lblPom.Text = "Pomeriggio (" & ContCons & ")"
        End If


    End Sub

    Private Sub lblGiorno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGiorno.Click
        If IsOperatore = False Then
            ParentFormEx.Sottofondo()
            Using x As New frmConsegnaOperatore
                x.Carica(_Giorno)
            End Using
            ParentFormEx.Sottofondo()
        End If

    End Sub

    Public Event OrdineSelezionato()

    Public Sub CollassaTutto()
        tvwMatt.CollapseAll()
        tvwPom.CollapseAll()

    End Sub

    Public Sub EspandiTutto()
        tvwMatt.ExpandAll()
        tvwPom.ExpandAll()

    End Sub

    Private Sub tvwMatt_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvwMatt.NodeMouseClick, tvwPom.NodeMouseClick
        selectedTreeview = sender
        sender.selectednode = e.Node
        If sender.name = "tvwPom" Then
            mnuSpostaConsegna.Text = "Sposta Intera Consegna al Mattino"
        Else
            mnuSpostaConsegna.Text = "Sposta Intera Consegna al Pomeriggio"
        End If
        If e.Node.Name.StartsWith("S") Then
            mnuSpostaConsegna.Enabled = True
            EmettiDocumentoFiscaleToolStripMenuItem.Enabled = True
            mnuSpedisciGls.Enabled = True
            mnuEliminaSpedizioneGls.Enabled = True

        Else
            mnuSpostaConsegna.Enabled = False
            EmettiDocumentoFiscaleToolStripMenuItem.Enabled = False
            mnuSpedisciGls.Enabled = False
            mnuEliminaSpedizioneGls.Enabled = False
        End If
        If e.Node.Name.StartsWith("O") Then
            Dim idordselez As Integer = e.Node.Name.Substring(1)
            _IdOrdSel = idordselez
            'EliminaToolStripMenu.Enabled = False
            'TracciaSpedToolStripMenu.Enabled = False
            RaiseEvent OrdineSelezionato()
        Else
            If e.Node.Name.StartsWith("S") Then
                _IdConsSel = e.Node.Name.Substring(1)
            Else
                _IdConsSel = 0
            End If
            'EliminaToolStripMenu.Enabled = True
            'TracciaSpedToolStripMenu.Enabled = True
        End If
    End Sub

    Private Sub EmettiDocumentoFiscaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmettiDocumentoFiscaleToolStripMenuItem.Click
        Dim Node As TreeNode = selectedTreeview.SelectedNode
        Dim IdCons As Integer = Node.Name.Substring(1)

        If Node.Name.StartsWith("S") Then
            Dim ListaId As String = ""
            Dim Nd As TreeNode
            Dim NodoPadre As TreeNode
            For Each Nd In selectedTreeview.SelectedNode.Nodes
                ListaId &= Nd.Name.Substring(1) & ","
                NodoPadre = Nd.Parent
            Next

            If ListaId.Length Then
                ParentFormEx.Sottofondo()
                Dim x As New frmConsegnaProgrammata
                'Dim c As New ConsegnaProgrammata
                'c.Read(IdCons)
                'x.Carica(, , ListaId, c.NumColli, c.Peso, c.IdCorr)
                x.Carica(IdCons)
                x = Nothing
                ParentFormEx.Sottofondo()
            End If
        Else
            Beep()
        End If


    End Sub

    Private Sub tvwPom_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwPom.AfterSelect

    End Sub

    Public Event ClienteSelezionato(Sender As System.Object)
    Public Property TestoSelezionato() As String

    Private Sub tvwMatt_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwMatt.AfterSelect, tvwPom.AfterSelect
        If sender.focused Then
            Dim pos As Integer = e.Node.Name.IndexOf("S")
            If pos <> -1 Then
                _TestoSelezionato = e.Node.Text
                RaiseEvent ClienteSelezionato(Me)
            End If
        End If

    End Sub

    Private Sub tvwMatt_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvwMatt.NodeMouseDoubleClick, tvwPom.NodeMouseDoubleClick
        If IsOperatore = False Then

            sender.selectednode = sender.getnodeat(e.X, e.Y)
            If sender.SelectedNode.Name.StartsWith("O") Then
                Dim IdOrd As Integer = sender.SelectedNode.Name.Substring(1)
                ParentFormEx.Sottofondo()
                Dim x As New frmOrdine
                x.Carica(IdOrd)
                x = Nothing
                ParentFormEx.Sottofondo()
            Else
                Dim PosR As Integer = sender.selectednode.name.indexof("R")
                If PosR > 0 Then
                    Dim IdCons As Integer = sender.SelectedNode.Name.Substring(PosR + 1)
                    ParentFormEx.Sottofondo()
                    Dim f As New frmVoceRubrica
                    f.Carica(IdCons)
                    f = Nothing
                    ParentFormEx.Sottofondo()
                    'Dim x As New frmOpConsProgram
                    'If x.Carica(IdCons) Then
                    '    Dim Dt As List(Of ConsegnaRicerca)

                    '    Dim xL As New ConsegneRicercaDAO

                    '    Dt = xL.Lista(IIf(sender.name = "tvwMatt", enPeriodoConsegna.Mattina, enPeriodoConsegna.Pomeriggio), _IdCorr, _Giorno, _IdRub, _ListaStati)
                    '    CaricaVoci(Dt, sender)
                    'End If
                    'x = Nothing
                End If
            End If

        End If
    End Sub

    Private Sub ModificaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModificaToolStripMenuItem.Click

        Dim IdCons As Integer = 0

        If selectedTreeview.SelectedNode.Name.StartsWith("S") Then
            IdCons = selectedTreeview.SelectedNode.Name.Substring(1)
        ElseIf selectedTreeview.SelectedNode.Name.StartsWith("O") Then
            IdCons = selectedTreeview.SelectedNode.Parent.Name.Substring(1)
        End If

        'If selectedTreeview.SelectedNode.Name.StartsWith("O") Then
        '    Dim IdOrd As Integer = selectedTreeview.SelectedNode.Name.Substring(1)
        '    ParentFormEx.Sottofondo()
        '    Dim x As New frmOrdine
        '    x.Carica(IdOrd)
        '    x = Nothing
        '    ParentFormEx.Sottofondo()
        'ElseIf selectedTreeview.SelectedNode.Name.StartsWith("S") Then
        'Dim IdCons As Integer = selectedTreeview.SelectedNode.Name.Substring(1)

        If IdCons Then
            Dim Ris As Integer = 0
            ParentFormEx.Sottofondo()
            Dim x As New frmConsegnaProgrammata
            Ris = x.Carica(IdCons)
            x = Nothing
            ParentFormEx.Sottofondo()
            'End If
            If Ris Then CaricaConsegne()
        End If

    End Sub

    Private Sub EliminaToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If selectedTreeview.SelectedNode.Name.StartsWith("C") Then
            If MessageBox.Show("Confermi l'eliminazione della consegna programmata?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim IdCons As Integer = selectedTreeview.SelectedNode.Name.Substring(1)

                Using mC As New ConsProgrOrdiniDAO
                    mC.DeleteByIdCons(IdCons)
                End Using

                Using c As New ConsegnaProgrammata
                    c.Read(IdCons)
                    c.LastUpdate = 1
                    c.Eliminato = enSiNo.Si
                    c.Save()
                End Using

                'Dim xc As New ConsegneProgrammateDAO
                'xc.Delete(IdCons)
                'xc.Dispose()

                CaricaConsegne()
                MessageBox.Show("Consegna programmata eliminata!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If
    End Sub

    Private Sub TracciaSpedToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If selectedTreeview.SelectedNode.Name.StartsWith("C") Then

            Dim CodTrack As String = selectedTreeview.SelectedNode.Tag.ToString
            If CodTrack.Length Then
                'qui costruisco la stringa di connessione basandomi sull'id cliente e sul codice di tgrack 
                Dim IndirizzoInternet As String = "http://as777.bartolini.it/vas/sped_ricdocmit_load.hsm?docmit=" & CodTrack & "&ksu=" & PostazioneCorrente.CodCliBart & "&referer=http://www.bartolini.it/home.asp"
                ParentFormEx.Sottofondo()

                Using x As New frmBrowser
                    x.Carica(IndirizzoInternet)
                End Using

                ParentFormEx.Sottofondo()
            Else
                MessageBox.Show("Il tracking delle spedizioni è disponibile solo quando è stato inserito il codice di rintracciamento e solo per il corriere BARTOLINI!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If



        End If

    End Sub

    Private Sub ModificaImportiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaImportiToolStripMenuItem.Click
        ModificaDatiEconomici()
    End Sub


    Private Sub ModificaDatiEconomici()

        If selectedTreeview.SelectedNode.Name.StartsWith("O") Then
            Dim IdOrdSel As Integer = selectedTreeview.SelectedNode.Name.Substring(1)

            Using O As New Ordine
                O.Read(IdOrdSel)
                MgrOrdini.ModificaDatiEconomici(O, ParentFormEx)
            End Using



            ''If stato <> enStatoOrdine.InConsegna Then
            'Dim frmMod As New frmOrdineModificaImporti
            'ParentFormEx.Sottofondo()

            'frmMod.Carica(IdOrdSel)

            'ParentFormEx.Sottofondo()
            'frmMod = Nothing
        Else
            Beep()
            'Else
            '    MessageBox.Show("L'ordine non può essere modificato perchè è gia stato messo in consegna!", "Modifica ordine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If

        End If
    End Sub

    Private Sub tvwMatt_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tvwMatt.MouseDown, tvwPom.MouseDown
        If AnteprimaLavoro.Visible Then
            AnteprimaLavoro.Nascondi()
        End If
        If IsOperatore = False Then
            SDragStart(sender, e)
        End If
    End Sub

    Private Sub tvwMatt_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvwMatt.DragOver, tvwPom.DragOver
        If IsOperatore = False Then
            SDragOver(sender, e)
        End If

    End Sub
    Private Sub tvwMatt_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles tvwMatt.DragDrop, tvwPom.DragDrop
        If IsOperatore = False Then
            SDragDrop(sender, e)
        End If
    End Sub

    Private Sub SDragStart(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Or
            PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.SuperOperatore Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Dim tree As TreeView = CType(sender, TreeView)

                Dim node As TreeNode
                node = tree.GetNodeAt(e.X, e.Y)

                tree.SelectedNode = node
                If Not node Is Nothing Then
                    If node.Name.StartsWith("O") Then
                        'Dim NdClone As TreeNode = node.Clone()
                        Dim O As New OggettoTrascinato
                        O.Origine = Me
                        O.NodoTrascinato = node
                        tree.DoDragDrop(O, DragDropEffects.Move)
                    ElseIf node.Name.StartsWith("S") Then
                        Dim O As New OggettoTrascinato
                        O.Origine = Me
                        O.NodoTrascinato = node
                        tree.DoDragDrop(O, DragDropEffects.Move)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub SDragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim tree As TreeView = CType(sender, TreeView)
        e.Effect = DragDropEffects.None

        If Not e.Data.GetData(GetType(OggettoTrascinato)) Is Nothing Then

            'Dim pt As New Point(e.X, e.Y)

            'pt = tree.PointToClient(pt)

            'Dim node As TreeNode = tree.GetNodeAt(pt)

            'If Not node Is Nothing Then

            e.Effect = DragDropEffects.Move

            'tree.SelectedNode = node

            'End If

        End If

    End Sub

    Private Sub SDragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs)
        'evento effettivo di drag drop o dall'albero della rubrica o da un altro giorno programmato
        Dim RicaricaSorgente As Boolean = False
        Dim tree As TreeView = CType(sender, TreeView)
        'Dim pt As New Point(e.X, e.Y)
        'pt = tree.PointToClient(pt)
        Dim O As OggettoTrascinato
        O = e.Data.GetData(GetType(OggettoTrascinato))
        Dim Node As TreeNode = O.NodoTrascinato
        Dim MomentoConsegna As enMomentoConsegna
        Dim MomentoConsegnaStr As String = ""

        If tree.Name = "tvwMatt" Then
            MomentoConsegna = enMomentoConsegna.Mattina
            MomentoConsegnaStr = "Mattina"
        Else
            MomentoConsegna = enMomentoConsegna.Pomeriggio
            MomentoConsegnaStr = "Pomeriggio"
        End If

        If Node.Name.StartsWith("O") Then
            'qui sono sicuro che si tratta di un ordine
            'proveniente da un ordine gia in consegna programmata
            Dim Messaggio As String = "Confermi"
            Dim C As ConsegnaRicerca = Node.Tag
            Dim singO As New Ordine
            singO.Read(C.IdOrd)

            If singO.ContenutoInQualcheScatolaConAltri = False Then
                If C.StatoOrdine < enStatoOrdine.UscitoMagazzino Then

                    If (C.Giorno <> _Giorno Or MomentoConsegna <> C.MatPom) And _Giorno >= Now.Date Then

                        Dim Ris As RisConsegnaModificabile = Nothing

                        If C.Giorno < _Giorno Then
                            'posticipo
                            Ris = C.Diritti.PossoPosticipareGiorno
                        Else
                            'anticipo
                            Ris = C.Diritti.PossoAnticipareGiorno
                        End If

                        If Ris.Esito Then 'C.ModificabileEx(True, True, True, True, False, True).Modificabile Then
                            If C.CodTrack.Length = 0 Then
                                Messaggio = "Confermi la consegna programmata per l'ordine " & C.IdOrd & " al " & _Giorno.ToShortDateString & " " & MomentoConsegnaStr & "?"
                                If MessageBox.Show(Messaggio, "Consegna programmata", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                    'qui primca controllo se la consegna programmata e' di un solo ordine in quel caso la cancello. 
                                    'se invece e' di piu ordini levo solo l'ordine da quella consegna e poi ne inserisco una per quel giorno
                                    'REGISTRO L'ORDINE NEL NUOVO POSTO. Controllo se la consegna ora contiene ancora ordini altrimenti la cancello
                                    Using x As New ConsegneProgrammateDAO
                                        'TOLTO IL 08/04/2015
                                        'x.EliminaOrdineDaConsegna(C)
                                        x.RegistraConsegnaOrdineSuGiorno(C.IdOrd, C.IdCorr, _Giorno, C.IdRub, MomentoConsegna, C.Ordine.IdIndirizzo)
                                        'TOLTO IL 08/04/2015
                                        'x.EliminaConsegnaSeVuota(C.IdCons)
                                    End Using
                                    RicaricaSorgente = True
                                    RaiseEvent OrdineTrascinato(sender, Me)
                                End If
                            Else
                                MessageBox.Show("Non è possibile spostare la consegna perchè è registrata con il corriere. Annullare prima la registrazione con il corriere", , MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            MessageBox.Show("Non è possibile spostare la consegna: " & Ris.BufferErrori, , MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If
                Else
                    If _Giorno <> C.Giorno Or MomentoConsegna <> C.MatPom Then
                        Beep()
                        'MessageBox.Show("Non è possibile spostare la consegna programmata dell'ordine perchè è già uscito dal magazzino", , MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                Beep()
                MessageBox.Show("Non è possibile spostare la consegna programmata dell'ordine perchè è già stato inserito in delle scatole", , MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        ElseIf Node.Name.StartsWith("P") Then
            ''qui vengo da una consegna prevista
            ''ma non programmata
            'Dim Messaggio As String = "Confermi"
            'Dim C As OrdineRicerca = Node.Tag
            'Messaggio = "Confermi la consegna programmata per l'ordine " & C.IdOrd & " al " & _Giorno.ToShortDateString & " " & MomentoConsegnaStr & "?"
            'If MessageBox.Show(Messaggio, "Consegna programmata", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    Using mgr As New ConsegneProgrammateDAO
            '        mgr.RegistraConsegnaOrdineSuGiorno(C.IdOrd, C.IdCorriere, _Giorno, C.IdRub, MomentoConsegna, C.IdIndirizzo)
            '    End Using

            '    RicaricaSorgente = True
            '    RaiseEvent OrdineTrascinato(sender, Me)
            'End If

        ElseIf Node.Name.StartsWith("S") Then
            'Dim Messaggio As String = "Confermi"
            'Dim IdCons As Integer = Node.Tag
            'Dim C As New ConsegnaProgrammata
            'C.Read(IdCons)
            'Dim SpostamentoOk As Boolean = True
            'For Each Ord As OrdineRicerca In C.ListaOrdini
            '    If Ord.Stato >= enStatoOrdine.UscitoMagazzino Then
            '        SpostamentoOk = False
            '    End If
            'Next
            'If SpostamentoOk Then
            '    If _Giorno <> C.Giorno Or MomentoConsegna <> C.MatPom Then
            '        Messaggio = "Confermi lo spostamento dell'intera consegna al " & _Giorno.ToShortDateString & " " & MomentoConsegnaStr & "?"
            '        If MessageBox.Show(Messaggio, "Consegna programmata", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '            '*****************************************
            '            'qui bisogna prendere in considerazione il fatto che ci potrebbe essere gia una consegna. andrebbe
            '            'invalidata e ricalcolati peso e colli 
            '            'TODO: CALCOLARE UNA CONSEGNA DA ACCORPARE
            '            '*****************************************
            '            C.Giorno = _Giorno
            '            C.MatPom = MomentoConsegna
            '            C.Save()
            '            RicaricaSorgente = True
            '            RaiseEvent OrdineTrascinato(sender, Me)
            '        End If
            '    End If
            'Else
            '    If _Giorno <> C.Giorno Or MomentoConsegna <> C.MatPom Then
            '        MessageBox.Show("Non è possibile spostare la consegna programmata perchè contiene degli ordini che sono già usciti dal magazzino", , MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'End If
        End If

        If RicaricaSorgente Then
            O.Origine.Carica(Date.MinValue,
                             _IdRub,
                             _ListaStati,
                             _IdZona,
                             _IdOperatore,
                             _SoloRegistratiCorriere)
        End If

    End Sub

    Public Event OrdineTrascinato(senderOrig As Object, senderDest As ucConsegneGiorno)

    Private Sub tmrHover_Tick(sender As System.Object, e As System.EventArgs) Handles tmrHover.Tick
        AnteprimaOrdine(_IdOrdAnteprima)
        tmrHover.Enabled = False
    End Sub

    Private Sub AnteprimaOrdine(IdOrd As Integer)

        Using Ord As New Ordine
            Ord.Read(IdOrd)

            AnteprimaLavoro.Mostra(Cursor.Position, Ord)
        End Using
    End Sub

    Private Sub tvwMatt_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tvwMatt.MouseMove,
                                                                                                        tvwPom.MouseMove

        If AnteprimaLavoro.Visible Then
            AnteprimaLavoro.Nascondi()
        End If

    End Sub

    Private Sub NascondiAnteprima()
        _IdOrdAnteprima = 0
        AnteprimaLavoro.Nascondi()

        tmrHover.Enabled = False
    End Sub

    Private Sub ucConsegneGiorno_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        NascondiAnteprima()
    End Sub

    Private Sub tvwMatt_NodeMouseHover(sender As Object, e As TreeNodeMouseHoverEventArgs) Handles tvwMatt.NodeMouseHover, tvwPom.NodeMouseHover
        Dim Node As TreeNode = e.Node

        If Not Node Is Nothing Then
            'If e.Location.X <> Cursor.Position.X Then
            '    Exit Sub
            'End If
            If Node.Name.StartsWith("O") Or Node.Name.StartsWith("P") Then
                _IdOrdAnteprima = Node.Tag.IdOrd
                If _IdOrdAnteprima Then tmrHover.Enabled = True
            Else
                NascondiAnteprima()
            End If

        Else
            NascondiAnteprima()
        End If
    End Sub

    Private Sub CalcolaScopertoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcolaScopertoToolStripMenuItem.Click

        Dim Node As TreeNode = selectedTreeview.SelectedNode
        If Node.Name.StartsWith("S") Then
            Dim IdCons As Integer = Node.Name.Substring(1)

            Dim c As New ConsegnaProgrammata
            c.Read(IdCons)
            Dim R As New VoceRubrica
            R.Read(c.IdRub)
            Using M As New VociRubricaDAO
                MessageBox.Show("Lo scoperto attuale ammonta a € " & M.CalcolaScopertoOld(R))
            End Using
        End If

    End Sub

    Private Sub Evidenzia(N As TreeNode, testo As String)

        If N.Text = testo Then
            N.BackColor = Color.Cyan
            N.EnsureVisible()
        Else
            If N.Name.StartsWith("O") Then
                Dim C As ConsegnaRicerca = N.Tag
                N.BackColor = FormerColori.GetColoreStatoOrdine(C.StatoOrdine)
            Else
                N.BackColor = Color.Transparent
            End If
        End If

        For Each Nodo As TreeNode In N.Nodes
            Evidenzia(Nodo, testo)
        Next

    End Sub

    Private Sub Evid(tv As TreeView, testo As String)
        If testo.Length Then
            For Each n As TreeNode In tv.Nodes
                Evidenzia(n, testo)
            Next
        End If
    End Sub

    Public Sub Evidenzia(Testo As String)
        Evid(tvwMatt, Testo)
        Evid(tvwPom, Testo)
    End Sub

    Private Sub mnuSpostaConsegna_Click(sender As Object, e As EventArgs) Handles mnuSpostaConsegna.Click

        Dim Node As TreeNode = selectedTreeview.SelectedNode
        If Node.Name.StartsWith("S") Then
            Dim IdCons As Integer = Node.Name.Substring(1)
            Dim c As New ConsegnaProgrammata
            c.Read(IdCons)

            Dim Periodo As String = String.Empty
            Dim PeriodoRis As enMomentoConsegna = 0
            If c.MatPom = enMomentoConsegna.Mattina Then
                Periodo = "Pomeriggio"
                PeriodoRis = enMomentoConsegna.Pomeriggio
            Else
                Periodo = "Mattino"
                PeriodoRis = enMomentoConsegna.Mattina
            End If

            If MessageBox.Show("Confermi lo spostamento dell' INTERA CONSEGNA al " & Periodo, "Spostamento Consegna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                c.MatPom = PeriodoRis
                c.Save()
                CaricaConsegne()
            End If

        End If

    End Sub

    Private Sub mnuTornaProntoRitiro_Click(sender As Object, e As EventArgs) Handles mnuTornaProntoRitiro.Click

        Dim N As TreeNode = selectedTreeview.SelectedNode
        If N.Name.StartsWith("O") Then
            If MessageBox.Show("Confermi lo spostamento dell' ordine selezionato a PRONTO PER IL RITIRO?", "Spostamento Stato Ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim O As New Ordine
                Dim IdOrd As Integer = N.Name.Substring(1)
                O.Read(IdOrd)
                If O.Stato = enStatoOrdine.UscitoMagazzino Then
                    If O.ConsegnaAssociata.Diritti.PossoCambiareDocumentoFiscaleOrdini.Esito Then ' O.ConsegnaAssociata.ModificabileEx(True, False, True, True, False, False).Modificabile Then
                        Using mgr As New OrdiniDAO
                            mgr.TornaAProntoRitiro(O)
                        End Using
                        CaricaConsegne()
                    Else
                        MessageBox.Show("Per la consegna di questo ordine sono stati gia emessi documenti fiscali, o registrati pagamenti")
                    End If
                Else
                    MessageBox.Show("Possono tornare a PRONTO PER IL RITIRO solo gli ordini in stato USCITO DA MAGAZZINO")
                End If
            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub pctMappa_Click(sender As Object, e As EventArgs) Handles pctMappa.Click

        ParentFormEx.Sottofondo()
        Dim f As New frmConsegnaPercorso
        f.Carica(_ListaUnica)
        f = Nothing
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub mnuSpedisciGls_Click(sender As Object, e As EventArgs) Handles mnuSpedisciGls.Click

        Dim Node As TreeNode = selectedTreeview.SelectedNode
        If Node.Name.StartsWith("S") Then
            Dim IdCons As Integer = Node.Name.Substring(1)
            Dim c As New ConsegnaProgrammata
            c.Read(IdCons)

            If c.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
                If MessageBox.Show("Vuoi ristampare l'etichetta di GLS?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim Path As String = FormerPath.PathTempLocale()
                    'Dim PdfSalvato As String = c.CodTrack & ".pdf"
                    'Dim Pdf As String = Path & PdfSalvato
                    Dim ZplSalvato As String = c.CodTrack & ".zpl"
                    Dim Zpl As String = Path & ZplSalvato
                    Cursor.Current = Cursors.WaitCursor
                    If Not System.IO.File.Exists(Zpl) Then
                        'If Not System.IO.File.Exists(Pdf) Then
                        'Dim lstPdfStreams As New List(Of System.IO.MemoryStream)
                        Dim lstZpl As String = String.Empty
                        Dim Ok As Boolean = True
                        For i = 1 To c.NumColli
                            Dim ContatoreProgressivo As Integer = IdCons & i
                            Try
                                'lstPdfStreams.Add(MgrGls.GetEtichettaPdf(ContatoreProgressivo))
                                lstZpl &= MgrWebLabelingGls.GetEtichettaZpl(ContatoreProgressivo) & vbCrLf
                            Catch ex As Exception
                                Ok = False
                                MessageBox.Show(ex.Message)
                            End Try
                        Next
                        If Ok Then
                            Try
                                'FormerLib.FormerHelper.PDF.CreaPdfMultiPagina(Pdf, lstPdfStreams)
                                'QUI SALVO LA STRINGA ZPL IN UN FILE FISICO
                                Using objWriter As New System.IO.StreamWriter(Zpl)
                                    objWriter.Write(lstZpl)
                                End Using
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                    'TODO: E' IL CASO DI METTERE ANCHE LE DIMENSIONI DELLA PAGINA IN CONFIGURAZIONE?
                    'FormerHelper.PDF.StampaPdf(Pdf, StampanteEtichetteGls, 297, 288)
                    'FormerHelper.File.ShellExtended(Pdf)
                    Dim buffer As String = String.Empty
                    Using objReader As New System.IO.StreamReader(Zpl)
                        buffer = objReader.ReadToEnd()
                    End Using
                    'QUI STAMPO LA STRINGA ZPL
                    'TODO: SE DEBUG DISABILITARE LA STAMPA
                    If FormerDebug.DebugAttivo = False Then
                        RawPrinterHelper.SendStringToPrinter(PostazioneCorrente.StampanteEtichetteGLS, buffer)
                    End If
                    Cursor.Current = Cursors.Default
                End If
            Else
                If MessageBox.Show("Confermi la registrazione della spedizione con GLS?", "Registrazione Spedizione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    'SAREBBE MEGLIO POTER VERIFICARE PRIMA SE ABILITARE O MENO LA VOCE DI MENU?
                    If c.SpedibileConGls = True Then
                        Cursor.Current = Cursors.WaitCursor
                        'Dim lstPdfStreams As New List(Of System.IO.MemoryStream)
                        Dim lstZpl As String = String.Empty
                        Dim CodTrack As String = String.Empty
                        Dim Ok As Boolean = True
                        For i = 1 To c.NumColli
                            If Ok Then
                                Try
                                    Dim ContatoreProgressivo As Integer = i
                                    Dim SegnaCollo As SegnaCollo = MgrWebLabelingGls.GetSegnaCollo(c, ContatoreProgressivo)
                                    'lstPdfStreams.Add(SegnaCollo.PdfLabel)
                                    lstZpl &= SegnaCollo.Zpl & vbCrLf
                                    CodTrack = SegnaCollo.NumeroSpedizione
                                Catch ex As Exception
                                    Ok = False
                                    MessageBox.Show(ex.Message)
                                End Try
                            End If
                        Next

                        If Ok Then
                            c.CodTrack = CodTrack
                            '                            c.Blocco = enSiNo.Si
                            c.DataTrasmissioneCorriere = Now.Date()
                            c.Save()
                            Using mgr As New ConsegneProgrammateDAO()
                                mgr.AvanzaStatoConsegna(c, enStatoConsegna.RegistrataCorriere)
                            End Using

                            Dim Path As String = FormerPath.PathTempLocale()
                            'Dim PdfSalvato As String = FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf")
                            'Dim PdfSalvato As String = CodTrack & ".pdf"
                            'Dim Pdf As String = Path & PdfSalvato
                            Dim ZplSalvato As String = c.CodTrack & ".zpl"
                            Dim Zpl As String = Path & ZplSalvato

                            Try
                                'FormerLib.FormerHelper.PDF.CreaPdfMultiPagina(Pdf, lstPdfStreams)
                                'QUI SALVO LA STRINGA ZPL IN UN FILE FISICO
                                Using objWriter As New System.IO.StreamWriter(Zpl)
                                    objWriter.Write(lstZpl)
                                End Using
                            Catch ex As Exception

                            End Try

                            'TODO: E' IL CASO DI METTERE ANCHE LE DIMENSIONI DELLA PAGINA IN CONFIGURAZIONE?
                            'FormerHelper.PDF.StampaPdf(Pdf, StampanteEtichetteGls, 297, 288)
                            'FormerHelper.File.ShellExtended(Pdf)
                            'QUI STAMPO LA STRINGA ZPL
                            'TODO: SE DEBUG DISABILITARE LA STAMPA
                            If FormerDebug.DebugAttivo = False Then
                                RawPrinterHelper.SendStringToPrinter(PostazioneCorrente.StampanteEtichetteGLS, lstZpl)
                            End If
                            Cursor.Current = Cursors.Default
                        End If
                        Cursor.Current = Cursors.Default
                    Else
                        MessageBox.Show("La spedizione non può essere spedita con GLS!")
                    End If
                End If
            End If
        Else
            Beep()
        End If

    End Sub

    Private Sub mnuEliminaSpedizioneGls_Click(sender As Object, e As EventArgs) Handles mnuEliminaSpedizioneGls.Click

        If MessageBox.Show("Confermi di voler eliminare la registrazione della spedizione?", "Eliminazione Spedizione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim Node As TreeNode = selectedTreeview.SelectedNode
            If Node.Name.StartsWith("S") Then
                Dim IdCons As Integer = Node.Name.Substring(1)
                Dim c As New ConsegnaProgrammata
                c.Read(IdCons)

                MgrConsegneCorriere.GLS.EliminaRegistrazioneConsegna(c)
                'If c.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
                '    Dim ris As String = String.Empty
                '    Dim CodTrack As String = c.CodTrack
                '    If c.IdCorr = enCorriere.GLS Or c.IdCorr = enCorriere.GLSIsole Or c.IdCorr = enCorriere.PortoAssegnatoGLS Then
                '        Try
                '            ris = MgrGls.EliminaSpedizione(c.CodTrack) & vbCrLf & "Ricorda di togliere le etichette di GLS vecchie dai pacchi," &
                '                                " di reimmettere la spedizione su GLS e di rietichettare i pacchi prima che venga fatta l'uscita da magazzino!"
                '        Catch ex As Exception
                '            ris = "C'è stato un problema con il Web Service di GLS durante l'eliminazione: " & ex.Message & vbCrLf & " Il codice di tracking della consegna" &
                '                " è stato comunque azzerato e lo stato della consegna è stato riportato a ""In Lavorazione"""
                '            FormerHelper.Mail.InviaMail("Errore durante l'eliminazione della spedizione su GLS", "Errore durante l'eliminazione della registrazione su GLS della consegna" &
                '                                         " numero " & c.IdCons & " con codice tracking " & c.CodTrack & "!", "web@tipografiaformer.it", , , , , "soft@tipografiaformer.it")
                '        End Try
                '    Else
                '        ris = "Eliminazione spedizione Bartolini effettuata. Ricorda di togliere le vecchie etichette dai pacchi, di reimmettere la spedizione su Easy Sped e di" &
                '            " rietichettare i pacchi prima che venga fatta l'uscita da magazzino!"
                '    End If

                '    c.CodTrack = String.Empty
                '    c.NumeroPrimoColloBartolini = String.Empty
                '    c.DataTrasmissioneCorriere = Date.MinValue
                '    c.Save()
                '    Using mgr As New ConsegneProgrammateDAO()
                '        mgr.AvanzaStatoConsegna(c, enStatoConsegna.InLavorazione)
                '    End Using

                '    MessageBox.Show(ris)
                '    If CodTrack.Length Then
                '        Using mgr As New ConsegneProgrammateDAO
                '            Dim lstConsegne As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter("CodTrack", CodTrack))
                '            For Each Consegna As ConsegnaProgrammata In lstConsegne
                '                Consegna.CodTrack = String.Empty
                '                Consegna.Save()
                '                Using mgr2 As New ConsegneProgrammateDAO()
                '                    mgr2.AvanzaStatoConsegna(Consegna, enStatoConsegna.InLavorazione)
                '                End Using
                '                MessageBox.Show("Eliminata registrazione anche dalla consegna numero " & Consegna.IdCons & " con Codice Tracking associato!")
                '            Next
                '        End Using
                '    End If

                'Else
                '    MessageBox.Show("La spedizione non è registrata con nessun corriere!")
                'End If
            End If
        End If
    End Sub

End Class
