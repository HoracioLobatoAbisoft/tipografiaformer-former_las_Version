Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports System.IO
Imports FormerConfig

Public Class ucConsegneAlbero
    Inherits ucFormerUserControl

    'Private WithEvents _AnteOrd As ucAntepOrdine
    Private _IdOrdAnteprima As Integer
    Private _IdRub As Integer = 0
    Private _Iniziale As String = ""
    Private _TestoLibero As String = ""
    Private _IdRubFiltro As Integer = 0

    Public ReadOnly Property IdRubFiltro As Integer
        Get
            Return _IdRubFiltro
        End Get
    End Property

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White
        'ColoraSfondo(btnAggRub)
        'ColoraSfondo(btnApplica)
        'ColoraSfondo(btnCerca)
        'ColoraSfondo(btnStampa)

    End Sub

    Public Event CambiataDataSelezionata()

    Private _DataSelezionata As Date
    Public ReadOnly Property DataSelezionata As Date
        Get
            Return _DataSelezionata
        End Get
    End Property

    Private _previste As Boolean = False
    Public Sub Carica()
        Carica(_previste)
    End Sub
    Public Sub Carica(Previste As Boolean)

        _previste = Previste
        If Not _previste Then btnApplica.Visible = False
        CaricaDati()
    End Sub

    Private Sub CaricaDati(Optional ByVal Iniziale As String = "",
                          Optional ByVal IdRub As Integer = 0,
                          Optional ByVal TestoLibero As String = "")

        If Iniziale.Length Then _Iniziale = Iniziale
        If IdRub Then _IdRub = IdRub
        If TestoLibero.Length Then _TestoLibero = TestoLibero
        If _previste Then
            CaricaPrev()
        Else
            CaricaOrd()
        End If
    End Sub

    Private Sub CaricaPrev()

        Using mgr As New OrdiniDAO
            Dim LstM As New List(Of OrdineRicerca)

            LstM = mgr.OrdiniPrevistiNonInConsegna(_TestoLibero, _IdRub)

            LstM.Sort(AddressOf ComparerDataIns)
            tvClienti.Nodes.Clear()

            For Each c As OrdineRicerca In LstM
                Dim ChiaveData As String = "D" & c.DataConsPrevKey
                Dim ChiaveCorriere As String = ChiaveData & "C" & c.IdCorriere
                Dim ChiaveRubrica As String = ChiaveCorriere & "R" & c.IdRub
                Dim ChiaveOrdine As String = "P" & c.IdOrd

                Dim NodoData As TreeNode = tvClienti.Nodes(ChiaveData)
                If NodoData Is Nothing Then
                    NodoData = tvClienti.Nodes.Add(ChiaveData, c.DataConsPrevShort, 7, 7)
                    NodoData.Tag = c.DataPrevConsegna
                    'NodoData.Expand()
                End If

                Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
                If NodoCorr Is Nothing Then
                    Dim NomeCorriere As String = c.CorriereStr
                    Dim PosPar As Integer = NomeCorriere.IndexOf("(")

                    If PosPar <> -1 Then

                        NomeCorriere = NomeCorriere.Substring(0, PosPar - 1)

                    End If
                    NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, NomeCorriere, 6, 6)
                    'NodoCorr.Expand()
                End If
                Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
                If NodoRub Is Nothing Then
                    Dim NomeRub As String = Strings.Left(c.ClienteNominativo, 32)
                    NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, NomeRub, 0, 0)
                    ' NodoRub.EnsureVisible()
                End If
                'NodoCorr.Expand()
                Dim DescrOrd As String = Strings.Left("Ord. " & c.IdOrd & " - " & c.ProdottoDescrizione, 32)

                Dim nodoOrd As TreeNode = NodoRub.Nodes.Add(ChiaveOrdine, DescrOrd, 1, 1)
                nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.Stato)
                NodoData.Expand()
                nodoOrd.Tag = c

            Next
        End Using
    End Sub

    Private Sub tvClienti_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tvClienti.MouseDown
        SDragStart(sender, e)
    End Sub

    Private Sub SDragStart(sender As Object, e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim tree As TreeView = CType(sender, TreeView)

            Dim node As TreeNode
            node = tree.GetNodeAt(e.X, e.Y)

            tree.SelectedNode = node
            If Not node Is Nothing Then
                If node.Name.StartsWith("O") Or node.Name.StartsWith("P") Then
                    Dim x As New OggettoTrascinato
                    x.NodoTrascinato = node.Clone
                    x.Origine = Me

                    tree.DoDragDrop(x, DragDropEffects.Move)
                End If

            End If
        End If

    End Sub

    Private Sub CaricaOrd(Optional ByVal Iniziale As String = "",
                          Optional ByVal IdRub As Integer = 0,
                          Optional ByVal TestoLibero As String = "")

        Using mgr As New ConsegneRicercaDAO
            Dim LstM As New List(Of ConsegnaRicerca)
            Dim ListaStati As String = enStatoOrdine.Preinserito & "," &
                                enStatoOrdine.Registrato & "," &
                                enStatoOrdine.InSospeso & "," &
                                enStatoOrdine.InCodaDiStampa & "," &
                                enStatoOrdine.StampaInizio & "," &
                                enStatoOrdine.StampaFine & "," &
                                enStatoOrdine.FinituraCommessaInizio & "," &
                                enStatoOrdine.FinituraCommessaFine & "," &
                                enStatoOrdine.FinituraProdottoInizio & "," &
                                enStatoOrdine.FinituraProdottoFine & "," &
                                enStatoOrdine.Imballaggio & "," &
                                enStatoOrdine.ImballaggioCorriere & "," &
                                enStatoOrdine.ProntoRitiro
            LstM = mgr.Lista(-1, 0, , _IdRub, ListaStati, , , _Iniziale, _TestoLibero, , , , " r.ragsoc, c.giorno desc ")
            'LstM.Sort(AddressOf Comparer)
            tvClienti.Nodes.Clear()

            For Each c As ConsegnaRicerca In LstM

                Dim ChiaveCorriere As String = "C" & c.IdCorr
                Dim ChiaveRubrica As String = "C" & c.IdCorr & "R" & c.IdRub
                Dim ChiaveOrdine As String = "O" & c.IdOrd
                Dim ChiaveData As String = "D" & c.DataConsPrevKey

                Dim NodoCorr As TreeNode = tvClienti.Nodes(ChiaveCorriere)
                If NodoCorr Is Nothing Then

                    Dim NomeCorriere As String = c.CorriereNome
                    Dim PosPar As Integer = NomeCorriere.IndexOf("(")

                    If PosPar <> -1 Then

                        NomeCorriere = NomeCorriere.Substring(0, PosPar - 1)

                    End If

                    NodoCorr = tvClienti.Nodes.Add(ChiaveCorriere, NomeCorriere, 6, 6)
                    'NodoCorr.Expand()
                End If
                Dim NodoRub As TreeNode = NodoCorr.Nodes("R" & c.IdRub)
                If NodoRub Is Nothing Then
                    Dim NomeRub As String = Strings.Left(c.RagSoc, 32)
                    NodoRub = NodoCorr.Nodes.Add("R" & c.IdRub, NomeRub, 0, 0)
                    'NodoRub.Expand()
                    'NodoRub.EnsureVisible()
                End If

                Dim NodoData As TreeNode = NodoRub.Nodes(ChiaveData)
                If NodoData Is Nothing Then
                    NodoData = NodoRub.Nodes.Add(ChiaveData, c.DataConsPrevShort, 7, 7)
                    NodoData.Tag = c.Giorno
                    'NodoData.Expand()
                End If
                Dim DescrOrd As String = Strings.Left("Ord. " & c.IdOrd & " - " & c.ProdottoNome, 32)


                Dim nodoOrd As TreeNode = NodoData.Nodes.Add("O" & c.IdOrd, DescrOrd, 1, 1)
                nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                nodoOrd.Tag = c

                'NodoCorr.Expand()
            Next
        End Using
    End Sub

    Private Function Comparer(ByVal x As ConsegnaRicerca, ByVal y As ConsegnaRicerca) As Integer

        Dim result As Integer = x.RagSoc.CompareTo(y.RagSoc)

        Return result

    End Function

    Private Function ComparerDataIns(ByVal x As Ordine, ByVal y As Ordine) As Integer
        Dim result As Integer = x.DataPrevConsegna.CompareTo(y.DataPrevConsegna)

        Return result
    End Function

    Private Sub Cerca()
        If txtCerca.Text.Length = 0 Then _TestoLibero = ""
        _IdRub = 0
        CaricaDati(, , txtCerca.Text)
    End Sub

    Private Sub btnCerca_Click(sender As System.Object, e As System.EventArgs) Handles btnCerca.Click
        Cerca()
    End Sub

    Private Sub btnAggRub_Click(sender As System.Object, e As System.EventArgs) Handles btnAggRub.Click
        CaricaDati()
    End Sub

    Private Sub txtCerca_GotFocus(sender As Object, e As System.EventArgs) Handles txtCerca.GotFocus
        If txtCerca.Text = "{cerca cliente}" Then txtCerca.Clear()
    End Sub

    Private Sub txtCerca_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCerca.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cerca()
        End If
    End Sub

    Private Sub btnApplica_Click(sender As System.Object, e As System.EventArgs) Handles btnApplica.Click
        If MessageBox.Show("Vuoi creare automaticamente le consegne programmate in base alla data di consegna prevista?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'qui sto sicuramente tra le consegne previste
            For Each N As TreeNode In tvClienti.Nodes
                RegistraOrdineDaNodo(N)
            Next
            CaricaDati()
            RaiseEvent CreateAutomaticamenteConsegne()
            MessageBox.Show("Consegne programmate create", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub RegistraOrdineDaNodo(Node As TreeNode)
        For Each n As TreeNode In Node.Nodes
            If n.Name.StartsWith("P") Then
                Dim o As OrdineRicerca = n.Tag
                Using mgr As New ConsegneProgrammateDAO
                    mgr.RegistraConsegnaOrdineSuGiorno(o.IdOrd, o.IdCorriere, o.DataPrevConsegna, o.IdRub, o.PeriodoPrevConsegna, o.IdIndirizzo)
                End Using

            End If
            RegistraOrdineDaNodo(n)
        Next
    End Sub

    Public Event CreateAutomaticamenteConsegne()

    Private Sub AnteprimaOrdine(IdOrd As Integer)

        Dim Ord As New Ordine
        Ord.Read(IdOrd)

        ' Dim GiaCaricata As Boolean = False

        AnteprimaLavoro.Mostra(Cursor.Position, Ord)

    End Sub

    Public Event ClienteSelezionato(Sender As System.Object)
    Public Property TestoSelezionato() As String
    Public Event OrdineSelezionato(Sender As System.Object)

    Private Sub tvClienti_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvClienti.AfterSelect

        Dim pos As Integer = e.Node.Name.IndexOf("R")
        If pos <> -1 Then
            _TestoSelezionato = e.Node.Text
            RaiseEvent ClienteSelezionato(Me)
        ElseIf e.Node.Name.StartsWith("O") Then
            _TestoSelezionato = e.Node.Text
            RaiseEvent OrdineSelezionato(Me)
        End If

    End Sub

    Private Sub tmrHover_Tick(sender As System.Object, e As System.EventArgs) Handles tmrHover.Tick

        AnteprimaOrdine(_IdOrdAnteprima)
        tmrHover.Enabled = False

    End Sub

    Private Sub tvClienti_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tvClienti.MouseMove

        Dim Node As TreeNode = tvClienti.GetNodeAt(e.Location)

        If Not Node Is Nothing Then
            If Node.Name.StartsWith("O") Or Node.Name.StartsWith("P") Then
                _IdOrdAnteprima = Node.Tag.IdOrd
                tmrHover.Enabled = True
            Else
                NascondiAnteprima()
            End If
        Else
            NascondiAnteprima()
        End If

    End Sub

    Private Sub NascondiAnteprima()

        AnteprimaLavoro.Nascondi()

        tmrHover.Enabled = False

    End Sub

    Private Sub ucConsegneGiorno_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

        NascondiAnteprima()

    End Sub

    Private Sub ApplicaConsegnaPredefinitaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplicaConsegnaPredefinitaToolStripMenuItem.Click

        Dim N As TreeNode = tvClienti.SelectedNode
        If Not N Is Nothing Then
            Dim Richiesta As String = ""
            If N.Name.StartsWith("P") Then
                Richiesta = "Confermi l'inserimento automatico della consegna programmata per questo ordine?"
            ElseIf N.Name.IndexOf("R") <> -1 Then
                Richiesta = "Confermi l'inserimento automatico di tutti gli ordini di questo cliente?"
            ElseIf N.Name.IndexOf("C1") <> -1 Then
                Richiesta = "Confermi l'inserimento automatico di tutti gli ordini ""RITIRO CLIENTE""?"
            End If
            If Richiesta.Length Then
                If MessageBox.Show(Richiesta, "Consegna prevista", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If N.Name.StartsWith("P") Or N.Name.IndexOf("R") <> -1 Or N.Name.IndexOf("C1") <> -1 Then
                        If N.Name.StartsWith("P") Then
                            Dim o As OrdineRicerca = N.Tag
                            Using mgr As New ConsegneProgrammateDAO
                                mgr.RegistraConsegnaOrdineSuGiorno(o.IdOrd, o.IdCorriere, o.DataPrevConsegna, o.IdRub, o.PeriodoPrevConsegna, o.IdIndirizzo)
                            End Using

                        End If
                        RegistraOrdineDaNodo(N)
                        Carica(True)

                    End If
                End If
            Else
                MessageBox.Show("Non è possibile applicare automaticamente la consegna prevista per l'oggetto selezionato")
            End If

        End If

    End Sub

    Private Sub tvClienti_MouseClick(sender As Object, e As MouseEventArgs) Handles tvClienti.MouseClick
        tvClienti.SelectedNode = tvClienti.GetNodeAt(e.X, e.Y)
        'If e.Button = Windows.Forms.MouseButtons.Right Then
        '    '    tvwMatt.Nodes(0).
        '    'sender.GetNodeAt(e.X, e.Y).isselected = True
        '    '    If sender.GetNodeAt(e.X, e.Y).Name = "D0" Then
        '    '        EmettiDocumentoFiscaleToolStripMenuItem.Enabled = True
        '    '        ModificaToolStripMenuItem.Enabled = False
        '    '    Else
        '    '        EmettiDocumentoFiscaleToolStripMenuItem.Enabled = False
        '    '        ModificaToolStripMenuItem.Enabled = False
        '    '    End If

        '    tvClienti.SelectedNode = tvClienti.GetNodeAt(e.X, e.Y)

        '    mnuCons.Show(Location.X + Left + e.X, Location.Y + Top + e.Y)
        'End If
    End Sub

    Private Sub FiltraPerQuestoClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltraPerQuestoClienteToolStripMenuItem.Click
        Dim N As TreeNode = tvClienti.SelectedNode

        If Not N Is Nothing Then
            Dim Richiesta As String = ""
            If N.Name.StartsWith("P") Then
                Dim O As Ordine = N.Tag
                _IdRubFiltro = O.IdRub
            ElseIf N.Name.IndexOf("R") <> -1 Then
                Dim PosR As Integer = N.Name.IndexOf("R")
                _IdRubFiltro = N.Name.Substring(PosR + 1)
            End If
        End If

        If _IdRubFiltro Then
            AnnullaFiltroClienteToolStripMenuItem.Enabled = True
            _IdRub = _IdRubFiltro
            CaricaPrev()
            RaiseEvent FiltroApplicato()
        End If
    End Sub

    Public Event FiltroApplicato()
    Public Event FiltroCancellato()

    Private Sub AnnullaFiltroClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnullaFiltroClienteToolStripMenuItem.Click
        AnnullaFiltroClienteToolStripMenuItem.Enabled = False
        _IdRub = 0
        CaricaPrev()
        RaiseEvent FiltroCancellato()
    End Sub

    Public Sub StampaAlberoConsegne(tv As TreeView)

        If tv Is Nothing Then Exit Sub

        Dim Template As String = FormerPath.PathLocale & "lista.htm", TitoloStampa As String = "", Contenuto As String = String.Empty

        TitoloStampa = "Consegne"
        Contenuto &= "</CENTER>"
        For Each n As TreeNode In tv.Nodes
            'corrieri
            Contenuto &= "<H2>" & n.Text & "</H2>"
            For Each nR As TreeNode In n.Nodes
                'clienti
                Contenuto &= "<H3>" & nR.Text & "</H3><UL>"
                For Each nC As TreeNode In nR.Nodes
                    'ordini

                    Dim CR As ConsegnaRicerca = nC.Tag
                    Dim O As New Ordine
                    O.Read(CR.IdOrd)
                    Contenuto &= "<LI style=""background-color:" & O.StatoColoreHTML & ";"">" & nC.Text & IIf(O.Preventivo, " (Preventivo)", "")
                    Contenuto &= "<font size=1>, consegna prevista il <B>" & O.DataConsPrevStr & "</B> e programmata il <b>" & CR.Giorno.ToShortDateString & "</B></FONT>"
                Next
                Contenuto &= "</UL>"
            Next
            'If n.Name.StartsWith("P") Then
            '    Dim O As Ordine = n.Tag
            '    _IdRubFiltro = O.IdRub
            'ElseIf n.Name.IndexOf("R") <> -1 Then
            '    Dim PosR As Integer = n.Name.IndexOf("R")
            '    _IdRubFiltro = n.Name.Substring(PosR + 1)
            'End If
        Next

        'apro il template 
        'sostituisco il titolo
        'sostituisco il contenuto per le liste

        Dim sw As New StreamReader(Template, System.Text.Encoding.ASCII)

        Dim ContentFile As String = sw.ReadToEnd()

        sw.Close()
        sw = Nothing

        If TitoloStampa.Length Then ContentFile = ContentFile.Replace("$TITOLO$", TitoloStampa)
        ContentFile = ContentFile.Replace("$CONTENUTO$", Contenuto)

        Dim Sr As StreamWriter, PathFileStampa As String = FormerPath.PathStampaTemp & FormerHelper.File.GetNomeFileTemp(".htm")
        Sr = New StreamWriter(PathFileStampa, False)

        Sr.Write(ContentFile)

        Sr.Close()

        'FileCopy(Template, StampaTemp)

        'qui ho il file completato e lo mando alla form di preview
        Dim x As New frmStampa

        x.carica(PathFileStampa)

        x = Nothing

    End Sub

    Private Sub btnStampa_Click(sender As Object, e As EventArgs) Handles btnStampa.Click
        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""
        If _IdRub Then
            Titolo = "Ordini cliente"
        Else
            Titolo = "Lista Ordini"
        End If
        StampaAlberoConsegne(tvClienti)
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub tvClienti_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvClienti.NodeMouseDoubleClick

        Dim nodo As TreeNode = tvClienti.SelectedNode

        If Not nodo Is Nothing Then

            If nodo.Name.StartsWith("D") Then

                _DataSelezionata = nodo.Tag
                RaiseEvent CambiataDataSelezionata()

            End If

        End If

    End Sub
End Class
