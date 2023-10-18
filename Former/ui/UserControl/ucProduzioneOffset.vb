Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerBusinessLogic
Imports FormerDALSql.LUNA
Imports FormerConfig
Imports System.IO

Public Class ucProduzioneOffset

    Private grigliaSelezionata As DataGridView = Nothing

    Private Sub CaricaMacchinari()
        Cursor = Cursors.WaitCursor
        Dim SoloProntiDaLavorare As Boolean = False

        Using mgr As New MacchinariDAO

            Dim l As List(Of Macchinario) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Macchinario.Tipo, enTipoMacchinario.Produzione),
                                                        New LUNA.LunaSearchParameter(LFM.Macchinario.IdMacchinario, "(select distinct idmacchinario from T_Commesse where IdReparto = " & enRepartoWeb.StampaOffset & ")", "IN"))
            toolTipHelp.RemoveAll()
            flowMacchineStampa.Controls.Clear()
            'flowMacchineStampa.Controls.Add(btnAggiorna)
            Dim f As New Font("Segoe UI", 10, FontStyle.Bold)

            For Each singM As Macchinario In l

                Dim NumeroLavoriInCodaTot As Integer = 0
                Dim LavoriInCoda As List(Of LavLog) = singM.LavoriInCoda(SoloProntiDaLavorare)
                NumeroLavoriInCodaTot = LavoriInCoda.Count
                Dim NumLavoriIncoda As Integer = LavoriInCoda.FindAll(Function(x) x.DataOraInizio = Date.MinValue).Count
                Dim NumLavoroInCorso As Integer = LavoriInCoda.FindAll(Function(x) x.DataOraInizio <> Date.MinValue And x.DataOraFine = Date.MinValue).Count
                Dim OkInLista As Boolean = True
                If NumeroLavoriInCodaTot Then
                    Dim btn As New Button
                    btn.Name = "btn" & singM.IdMacchinario
                    btn.Tag = singM
                    'btn.Width = FlowMacchinari.Width - 3
                    btn.TextAlign = ContentAlignment.MiddleLeft
                    btn.Height = 48
                    btn.Width = 130
                    btn.Image = singM.Img
                    btn.ImageAlign = ContentAlignment.MiddleLeft
                    btn.TextAlign = ContentAlignment.MiddleRight
                    btn.Font = f
                    btn.BackColor = Color.White

                    btn.Text = NumLavoriIncoda & " + " & NumLavoroInCorso

                    Dim testoTool As String = singM.Riassunto(True) & " Lavori in coda: " & NumLavoriIncoda & " Lavori in corso: " & NumLavoroInCorso
                    toolTipHelp.SetToolTip(btn, testoTool)

                    'AddHandler btn.Click, AddressOf MacchinarioCliccato

                    flowMacchineStampa.Controls.Add(btn)
                End If
            Next

        End Using

        Cursor = Cursors.Default
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ColoraSfondo(lnkNewCom)
        ' ColoraSfondo(lnkStampa)
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent(). 
        PreinseritoToolStripMenuItem.BackColor = FormerColori.ColoreStatoOrdinePreinserito
        RegistratoToolStripMenuItem.BackColor = FormerColori.ColoreStatoOrdineRegistrato
        InSospesoToolStripMenuItem.BackColor = FormerColori.ColoreStatoOrdineInSospeso
        RifiutatoToolStripMenuItem.BackColor = FormerColori.ColoreStatoOrdineRifiutato
        'btnPassaRegistrato.BackColor = FormerColori.GetColoreStatoOrdine(enStatoOrdine.Registrato)

        'If FormerDebug.DebugAttivo Then
        ToolStripSeparator4.Visible = True
        MostraGliOrdiniADisposizioneToolStripMenuItem.Visible = True
        '    lnkSimulaCreazione.Visible = True
        'End If

    End Sub

    Public IdComSel As Integer = 0

    Public IdOrdSel As Integer = 0

    Public IdModelloCommessaSel As Integer = 0

    Public Function CommesseInCoda() As Integer
        Dim ris As Integer = 0

        Using mgr As New CommesseDAO

            Dim l As List(Of Commessa) = mgr.FindAll(New LunaSearchParameter(LFM.Commessa.IdReparto, enRepartoWeb.StampaOffset),
                                                     New LunaSearchParameter(LFM.Commessa.Stato, "(" & enStatoCommessa.Preinserito & "," & enStatoCommessa.Pronto & ")", "IN"))
            ris = l.Count
        End Using

        Return ris
    End Function

    Public Function Carica() As Integer
        Dim Ris As Integer = 0
        CaricaCombo()
        CaricaMacchinari()
        Ris = UcCommesse.Carica()

        Return Ris

    End Function

    Private Sub CaricaCombo()

        CaricaGruppi()

        'Dim TipoCom As New TipoCommesseDAO
        'cmbTipoCom.ValueMember = "IdTipoCom"
        'cmbTipoCom.DisplayMember = "Descrizione"

        'cmbTipoCom.DataSource = TipoCom.GetAll("Descrizione")

        'Dim TipoProd As New cTipoProdCom(False)
        'cmbTipoProd.DataSource = TipoProd
        'cmbTipoProd.ValueMember = "Id"
        'cmbTipoProd.DisplayMember = "Descrizione"

    End Sub

    Public Sub AvviaRicerca()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim Stato As Integer = 0

            If PreinseritoToolStripMenuItem.Checked Then
                Stato = enStatoOrdine.Preinserito
            ElseIf RegistratoToolStripMenuItem.Checked Then
                Stato = enStatoOrdine.Registrato
            ElseIf InSospesoToolStripMenuItem.Checked Then
                Stato = enStatoOrdine.InSospeso
            ElseIf RifiutatoToolStripMenuItem.Checked Then
                Stato = enStatoOrdine.Rifiutato
            End If

            Dim lst As List(Of OrdineRicerca)

            '  If Not cmbCatProd.SelectedValue Is Nothing Then
            Dim IdLB As Integer = 0
            Dim IdPrev As Integer = 0
            If Not tvwCat.SelectedNode Is Nothing Then

                If tvwCat.SelectedNode.Name.Substring(0, 1) = "L" Then
                    IdLB = tvwCat.SelectedNode.Name.Substring(1)
                ElseIf tvwCat.SelectedNode.Name.Substring(0, 1) = "C" Then
                    IdPrev = tvwCat.SelectedNode.Name.Substring(1)
                End If

            End If
            Using mgr As New OrdiniDAO
                lst = mgr.Lista(, Stato, , True, , True, , , , , , , , , True, , , , IdPrev, IdLB)
            End Using

            lst = lst.FindAll(Function(x) x.IdTipoProd = enRepartoWeb.StampaOffset Or x.IdTipoProd = enRepartoWeb.Packaging)

            DGOrdini.AutoGenerateColumns = False
            Try
                DGOrdini.DataSource = lst
            Catch ex As Exception

            End Try

            DGOrdini.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGOrdini.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGOrdini.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGOrdini.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DGOrdini.Columns(6).DefaultCellStyle.Format = "0.00"
            DGOrdini.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGOrdini.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGOrdini.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            lblNumRis.Text = lst.Count

            'DGOrdini.ClearSelection()
            'DgOrdiniNonUtilizzati.ClearSelection()

            RaiseEvent OrdineSelezionato()

            '   End If

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore nel caricamento della lista, riprovare. " & ex.Message)
        End Try
    End Sub

    Private Sub txtCerca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = vbCr Then

            AvviaRicerca()

        Else
            MgrControl.ControlloNumerico(sender, e, True)
        End If


    End Sub

    Public Event ModelloCommessaSelezionato()

    Public Event OrdineSelezionato()

    Public Event CommessaSelezionata(sender As Object)

    Private Sub dgOrdiniUtilizzati_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgOrdiniUtilizzati.CellClick
        'If e.RowIndex <> -1 Then
        '    Dim r As DataGridViewRow = dgOrdiniUtilizzati.Rows(e.RowIndex)
        '    If Not r Is Nothing Then
        '        If r.Selected Then r.Selected = False
        '    End If
        'End If
    End Sub

    Private Sub DGOrdini_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGOrdini.DataError

        'e.Cancel = True

    End Sub

    'Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
    '    ParentFormerForm.Sottofondo 
    '    Dim Titolo As String = ""

    '        Titolo = "Lista Ordini"

    '    StampaGlobale(Titolo, DgOrdini)
    '    ParentFormerForm.Sottofondo 
    'End Sub

    'Private Sub DgOrdini_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGOrdini.CellMouseDoubleClick, _
    '    dgOrdiniUtilizzati.CellMouseDoubleClick, _
    '    DgOrdiniNonUtilizzati.CellMouseDoubleClick

    'End Sub

    'Private Sub lnkOrdMail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    ParentFormerForm.Sottofondo 
    '    Dim x As New frmCheckMail
    '    Dim Ris As Integer

    '    Ris = x.Carica()

    '    If Ris Then AvviaRicerca()

    '    x = Nothing
    '    ParentFormerForm.Sottofondo 

    'End Sub

    Private Sub DgOrdini_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGOrdini.RowPostPaint, DgOrdiniNonUtilizzati.RowPostPaint, dgOrdiniUtilizzati.RowPostPaint
        Try
            Dim x As DataGridViewRow = sender.Rows.Item(e.RowIndex)
            Dim O As OrdineRicerca = x.DataBoundItem

            x.Cells(3).Style.BackColor = O.StatoColore
            x.Cells(3).Style.SelectionBackColor = O.StatoColore

            Dim DiffGiorni As Integer = DateDiff(DateInterval.Day, Now.Date, O.DataPrevConsegna)

            If DiffGiorni < 0 Then
                x.Cells(5).Style.BackColor = Color.Red
                x.Cells(5).Style.SelectionBackColor = Color.Red
                'ElseIf DiffGiorni > 0 And DiffGiorni < 2 Then
                '    x.Cells(5).Style.BackColor = Color.LightGray
                '    x.Cells(5).Style.SelectionBackColor = Color.LightGray
            Else
                x.Cells(5).Style.BackColor = Color.LightGreen
                x.Cells(5).Style.SelectionBackColor = Color.LightGreen
            End If
        Catch ex As Exception

        End Try

        ''controllo se ha superato il monte massimo di ore per quel prodotto
        'Try
        '    Dim NumOreMax As Integer = O.Prodotto.NumOreMax

        '    If NumOreMax Then
        '        'controllo che la data inserimento piu le ore max non superano la data attuale
        '        Dim DataRif As Date = CDate(x.Cells(1).Value)
        '        DataRif = DataRif.AddHours(NumOreMax)
        '        If DataRif < Now Then
        '            x.Cells(1).Style.BackColor = Color.Red
        '            x.Cells(1).Style.SelectionBackColor = Color.Red
        '        End If

        '    End If

        'Catch ex As Exception

        'End Try

    End Sub

    'Private Sub CalcolaSpaziUsati()
    '    Dim TotSpaziUsati As Integer = 0

    '    Dim rig As DataGridViewRow

    '    For Each rig In DGOrdini.SelectedRows
    '        Dim o As OrdineRicerca = rig.DataBoundItem
    '        TotSpaziUsati += o.NumSpazi
    '    Next

    '    lblNumSpaziUsati.Text = TotSpaziUsati
    'End Sub

    Private Sub DgOrdini_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGOrdini.SelectionChanged,
                                                                                                        dgOrdiniUtilizzati.SelectionChanged,
                                                                                                        DgOrdiniNonUtilizzati.SelectionChanged
        Try

            grigliaSelezionata = sender
            'If sender Is DGOrdini Then CalcolaSpaziUsati()

            Dim Rig As DataGridViewRow

            If sender.SelectedRows.Count Then
                Rig = sender.SelectedRows(0)

                Dim O As Ordine = Rig.DataBoundItem

                'If O.IdOrd <> IdOrdSel Then
                Rig.Selected = True
                sender.Select()

                IdOrdSel = O.IdOrd

                If MostraAnteprima Then RaiseEvent OrdineSelezionato()

                'End If

            End If


        Catch ex As Exception

        End Try

        If sender Is dgOrdiniUtilizzati Or sender Is DgOrdiniNonUtilizzati Then
            Dim l As New List(Of OrdineRicerca)
            For Each r As DataGridViewRow In dgOrdiniUtilizzati.SelectedRows
                l.Add(r.DataBoundItem)
            Next
            For Each r As DataGridViewRow In DgOrdiniNonUtilizzati.SelectedRows
                l.Add(r.DataBoundItem)
            Next

            UcProduzioneOrdiniSelezionati.Carica(l)

        ElseIf sender Is DGOrdini Then
            Dim l As New List(Of OrdineRicerca)
            For Each r As DataGridViewRow In DGOrdini.SelectedRows
                l.Add(r.DataBoundItem)
            Next
            UcProduzioneOrdiniSelezionatiManuale.Carica(l)
        End If

    End Sub

    Private MostraAnteprima As Boolean = True

    'Private Sub rdoPre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If sender.focused Then
    '        'CaricaGruppi()
    '        lnkNewCom.Enabled = rdoReg.Checked
    '        AvviaRicerca()
    '    End If
    'End Sub

    Private Sub cmbCatProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If sender.focused Then AvviaRicerca()
    End Sub

    Private Sub CreaCommessa()


        If PostazioneCorrente.ScaricamentoOrdiniInCorso Then
            MessageBox.Show("Il Demone sta scaricando i nuovi ordini, attendere il termine dell'operazione e riprovare")
        Else
            Dim ListaIdOrd As String = ""
            ListaIdOrd = CreaListaId()
            If ListaIdOrd.Length Then

                Dim Ris As Integer = 0
                Dim okLav As Boolean = True

                Dim L As New List(Of LavLog)

                For Each Id As String In ListaIdOrd.Split(",")
                    Using o As New Ordine
                        o.Read(Id)

                        For Each lav As Lavorazione In o.ListaLavori.FindAll(Function(x) x.Accorpabile = enSiNo.Si And x.Esclusiva = enSiNo.Si And x.LavorazioneInterna = enSiNo.No)
                            'la devo cercare in tutte le altre lavorazioni degli altri ordini
                            For Each IdOther As String In ListaIdOrd.Split(",")
                                If IdOther <> Id Then
                                    Using oInt As New Ordine
                                        oInt.Read(IdOther)
                                        If oInt.ListaLavori.FindAll(Function(x) x.IdLavoro = lav.IdLavoro).Count = 0 Then
                                            If L.FindAll(Function(x) x.Idlav = lav.IdLavoro).Count = 0 Then L.Add(o.ListLavLog.Find(Function(x) x.Idlav = lav.IdLavoro))
                                        End If
                                    End Using
                                End If
                            Next
                        Next

                    End Using
                Next

                If L.Count Then

                    Dim bufLav As String = String.Empty
                    For Each Lav As LavLog In L
                        bufLav &= Lav.Descrizione & ", "
                    Next

                    bufLav = bufLav.TrimEnd(" ", ",")

                    MessageBox.Show("Le seguenti lavorazioni ACCORPABILI e ESCLUSIVE non sono previsti su tutti gli ordini selezionati: " &
                                    ControlChars.NewLine & bufLav & ControlChars.NewLine &
                                    "Modificare gli ordini per renderli compatibili tra loro.", "Ordini non compatibili", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    okLav = False

                    '    If MessageBox.Show("Le seguenti lavorazioni ACCORPABILI e ESCLUSIVE non sono previsti su tutti gli ordini selezionati: " &
                    '                       ControlChars.NewLine & bufLav & ControlChars.NewLine & "Continuando le lavorazioni saranno inserite su tutti gli ordini dove non sono presenti. Continuare?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    '        For Each lav As LavLog In L

                    '            For Each Id As String In ListaIdOrd.Split(",")
                    '                Using o As New Ordine
                    '                    o.Read(Id)
                    '                    If o.ListLavLog.FindAll(Function(x) x.Idlav = lav.Idlav).Count = 0 Then
                    '                        o.ListLavLog.Sort(Function(x, y) x.Ordine.CompareTo(y.Ordine))

                    '                        Dim Ordine As Integer = 0

                    '                        If o.ListLavLog.Count Then
                    '                            Dim ll As LavLog = o.ListLavLog.Last
                    '                            Ordine = ll.Ordine + 1
                    '                        End If

                    '                        Using llNew As New LavLog

                    '                            llNew.Ordine = Ordine
                    '                            llNew.IdOrd = o.IdOrd
                    '                            llNew.IdMacchinario = lav.IdMacchinario
                    '                            llNew.Idlav = lav.Idlav
                    '                            llNew.Macchinario = lav.Macchinario
                    '                            llNew.Descrizione = lav.Descrizione
                    '                            llNew.Premio = lav.Premio
                    '                            llNew.Tempo = lav.Tempo
                    '                            llNew.Save()

                    '                        End Using

                    '                    End If
                    '                End Using
                    '            Next

                    '        Next

                    '    Else
                    '        okLav = False
                    '    End If
                End If

                If okLav Then
                    ParentFormEx.Sottofondo()
                    Using x As New frmCommessa
                        Ris = x.Carica(, ListaIdOrd)
                    End Using
                    ParentFormEx.Sottofondo()
                End If

                If Ris Then
                    CaricaGruppi()
                    AvviaRicerca()

                    'ParentFormEx.Sottofondo()
                    'Using c As New Commessa
                    '    c.Read(Ris)
                    '    Dim collOrd As OrdiniCTP = MgrCTP.GetListaOrdiniCTP(c)

                    '    Using X As New frmCTP
                    '        ParentFormEx.Sottofondo()
                    '        X.Carica(collOrd, c.IdCom)
                    '        ParentFormEx.Sottofondo()
                    '    End Using
                    'End Using
                    'ParentFormEx.Sottofondo()

                End If
            End If
        End If
    End Sub

    Private Function CreaListaId() As String

        Dim buffer As String = ""

        Dim Dr As DataGridViewRow
        For Each Dr In DGOrdini.SelectedRows
            Dim o As Ordine = Dr.DataBoundItem
            buffer &= o.IdOrd & ","
        Next

        buffer = buffer.TrimEnd(",")
        Return buffer


    End Function

    Private Sub mnuInviaMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInviaMail.Click
        InviaMail()
    End Sub

    Private Sub InviaMail()

        If grigliaSelezionata.SelectedRows.Count Then

            Dim Dr As DataGridViewRow = grigliaSelezionata.SelectedRows(0)
            Dim O As Ordine = Dr.DataBoundItem
            Dim IdOrd As Integer = O.IdOrd

            ParentFormEx.Sottofondo()
            Dim x As New frmEmailOrd
            x.Carica(IdOrd)
            x = Nothing
            ParentFormEx.Sottofondo()

        End If

    End Sub
    Private Sub ForzaStato(ByVal stato As enStatoOrdine)
        If grigliaSelezionata.SelectedRows.Count Then

            Dim Dr As DataGridViewRow

            Dr = grigliaSelezionata.SelectedRows(0)
            Dim O As Ordine = Dr.DataBoundItem
            Using mgr As New OrdiniDAO
                mgr.InserisciLog(O, stato)
            End Using

            AvviaRicerca()

        End If
    End Sub

    Private Sub mnuPassaImballaggio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPassaImballaggio.Click
        If grigliaSelezionata.SelectedRows.Count Then
            Dim Dr As DataGridViewRow
            Dr = grigliaSelezionata.SelectedRows(0)
            Dim L As New List(Of OrdineRicerca)
            Dim O As Ordine = Dr.DataBoundItem
            L.Add(O)
            Dim Check As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, L)

            If Check.ICan Then
                If MessageBox.Show("Confermi il cambiamento di stato dell'ordine " & O.IdOrd & "?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If O.Stato = enStatoOrdine.Registrato Then
                        ForzaStato(enStatoOrdine.Imballaggio)
                        CaricaGruppi()
                    Else
                        MessageBox.Show("Possono passare a imballaggio solo gli ordini in stato Registrato")
                    End If
                End If
            Else
                MessageBox.Show(MgrOrderLock.GetMessageLocked(Check))
            End If

        End If
    End Sub

    Private Sub ModificaDatiEconomici()

        If grigliaSelezionata.SelectedRows.Count Then

            Dim Dr As DataGridViewRow = grigliaSelezionata.SelectedRows(0)
            Dim o As Ordine = Dr.DataBoundItem

            MgrOrdini.ModificaDatiEconomici(o, ParentFormEx)



            'Dim stato As Integer = o.Stato
            'IdOrdSel = o.IdOrd

            'Dim frmMod As New frmOrdineModificaImporti
            'ParentFormEx.Sottofondo()

            'frmMod.Carica(IdOrdSel)

            'ParentFormEx.Sottofondo()
            'frmMod = Nothing

        End If
    End Sub

    Private Sub ModificaDatiEconomiciToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaDatiEconomiciToolStripMenuItem.Click
        ModificaDatiEconomici()
    End Sub

    Private Sub AllegaMessaggioAllordineToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AllegaMessaggioAllordineToolStripMenuItem.Click

        If grigliaSelezionata.SelectedRows.Count Then

            ParentFormEx.Sottofondo()
            Dim f As New frmPostit
            f.Carica(, , IdOrdSel)
            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub mnuPassaPreinserito_Click(sender As System.Object, e As System.EventArgs) Handles mnuPassaPreinserito.Click

        'qui devo SGANCIARLO DALLA CONSEGNA
        If grigliaSelezionata.SelectedRows.Count Then
            Dim Dr As DataGridViewRow
            Dr = grigliaSelezionata.SelectedRows(0)
            'Dim L As New List(Of OrdineRicerca)
            Dim O As Ordine = Dr.DataBoundItem
            'L.Add(O)
            'Dim Check As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, L)

            'If Check.ICan Then
            '    If MessageBox.Show("Confermi il cambiamento di stato dell'ordine " & O.IdOrd & "?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            '        If O.IdCons = 0 Then
            '            'qui devo rimetterlo in consegna
            '            Using mgr As New ConsegneProgrammateDAO
            '                mgr.RegistraConsegnaOrdineSuGiorno(O.IdOrd, O.IdCorriere, O.CalcolaDataConsegna, O.IdRub, enMomentoConsegna.Mattina, O.IdIndirizzo)
            '            End Using
            '        End If

            '        ForzaStato(enStatoOrdine.Preinserito)
            '        CaricaGruppi()
            '    End If
            'Else
            '    MessageBox.Show(MgrOrderLock.GetMessageLocked(Check))
            'End If

            If MgrOrdini.ForzaStatoOrdineAPreinserito(O) Then
                CaricaGruppi()
            End If



        End If

    End Sub

    Private Sub mnuPassaSospeso_Click(sender As System.Object, e As System.EventArgs) Handles mnuPassaSospeso.Click

        'qui devo SGANCIARLO DALLA CONSEGNA
        If grigliaSelezionata.SelectedRows.Count Then

            Dim O As Ordine = grigliaSelezionata.SelectedRows(0).DataBoundItem
            If MgrOrdini.ForzaStatoOrdineAInSospeso(O, Me.ParentForm) Then
                CaricaGruppi()
            End If

            'Dim Check As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, L)

            'If Check.ICan Then
            '    If MessageBox.Show("Confermi il cambiamento di stato dell'ordine " & O.IdOrd & "?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            '        Dim Modificabi As Boolean = False
            '        If Not O.ConsegnaAssociata Is Nothing Then
            '            Modificabi = O.ConsegnaAssociata.Modificabile(False)
            '        Else
            '            Modificabi = True
            '        End If
            '        If Modificabi Then
            '            Dim IdCons As Integer = O.IdCons
            '            If IdCons Then
            '                Using mgr As New ConsegneProgrammateDAO
            '                    'OK 
            '                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "Eliminato da Consegna " & IdCons)
            '                    mgr.EliminaOrdineDaConsegna(IdCons, O.IdOrd)
            '                    Dim C As New ConsegnaProgrammata
            '                    C.Read(IdCons)
            '                    C.AggiornaColliPeso()
            '                    C = Nothing
            '                    mgr.EliminaConsegnaSeVuota(IdCons)
            '                End Using
            '            End If
            '            ForzaStato(enStatoOrdine.InSospeso)
            '            CaricaGruppi()
            '        Else
            '            MessageBox.Show("Consegna non modificabile")
            '        End If
            '    End If
            'Else
            '    MessageBox.Show(MgrOrderLock.GetMessageLocked(Check))
            'End If

        End If

    End Sub

    Private Sub mnuPassaRegistrato_Click(sender As System.Object, e As System.EventArgs) Handles mnuPassaRegistrato.Click

        If grigliaSelezionata.SelectedRows.Count Then
            Dim O As Ordine = grigliaSelezionata.SelectedRows(0).DataBoundItem
            If MgrOrdini.ForzaStatoOrdineARegistrato(O) Then
                CaricaGruppi()
            End If

            'If MessageBox.Show("Confermi il cambiamento di stato dell'ordine?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    Dim Dr As DataGridViewRow

            '    Dr = grigliaSelezionata.SelectedRows(0)
            '    Dim O As Ordine = Dr.DataBoundItem

            '    If O.Stato = enStatoOrdine.Preinserito Then
            '        ForzaStato(enStatoOrdine.Registrato)
            '        CaricaGruppi()
            '    Else
            '        MessageBox.Show("Possono passare a registrato solo gli ordini in stato Preinserito")
            '    End If
            'End If

        End If

    End Sub

    Private Sub cmbTipoProd_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If sender.focused Then AvviaRicerca()

    End Sub

    Private Sub CaricaGruppi()

        Cursor.Current = Cursors.WaitCursor
        tvwCat.Nodes.Clear()

        Dim DescrNodoZero As String = "- Tutti "

        Dim NOrd As Integer = 0
        Using M As New CatProdDAO
            NOrd = M.GetNumOrd(0, 0, enStatoOrdine.Preinserito)

            DescrNodoZero &= "{"
            If NOrd Then DescrNodoZero &= NOrd & " Pre "
            Dim NOrdR As Integer = 0
            NOrdR = M.GetNumOrd(0, 0, enStatoOrdine.Registrato)

            If NOrdR Then
                DescrNodoZero &= NOrdR & " Reg"
            End If

            DescrNodoZero &= "}"

            tvwCat.Nodes.Add("N0", DescrNodoZero)

            Using Mgr As New PreventivazioniDAO
                Dim Lst As List(Of Preventivazione) = Mgr.GetAll("IdReparto,Descrizione")

                For Each CategProd As Preventivazione In Lst

                    Dim DescrP As String = CategProd.Descrizione
                    NOrd = M.GetNumOrd(CategProd.IdPrev, 0, enStatoOrdine.Preinserito)
                    DescrP &= " {"
                    If NOrd Then DescrP &= NOrd & " Pre "

                    NOrdR = M.GetNumOrd(CategProd.IdPrev, 0, enStatoOrdine.Registrato)
                    If NOrdR Then
                        DescrP &= NOrdR & " Reg"
                    End If
                    DescrP &= "}"

                    If NOrd <> 0 Or NOrdR <> 0 Then
                        tvwCat.Nodes.Add("C" & CategProd.IdPrev, DescrP, 0, 0)

                        CategProd.CaricaListinoBase(, enTipoListiniBase.Produzione)
                        'qui carico i listini base nell'albero
                        For Each L As ListinoBase In CategProd.ListiniBase

                            Dim DescrL As String = L.NomeEx
                            NOrd = M.GetNumOrd(0, L.IdListinoBase, enStatoOrdine.Preinserito)
                            DescrL &= " {"
                            If NOrd Then DescrL &= NOrd & " Pre "

                            NOrdR = M.GetNumOrd(0, L.IdListinoBase, enStatoOrdine.Registrato)
                            If NOrdR Then
                                DescrL &= NOrdR & " Reg"
                            End If
                            DescrL &= "}"
                            If NOrd <> 0 Or NOrdR <> 0 Then tvwCat.Nodes("C" & CategProd.IdPrev).Nodes.Add("L" & L.IdListinoBase, DescrL, 1, 1)

                        Next
                    End If
                    'tvwCat.Nodes("C" & CategProd.IdPrev).Expand()
                Next
            End Using
        End Using

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuPassaRifiutato_Click(sender As Object, e As EventArgs) Handles mnuPassaRifiutato.Click

        'qui devo SGANCIARLO DALLA CONSEGNA
        If grigliaSelezionata.SelectedRows.Count Then
            Dim Dr As DataGridViewRow
            Dr = grigliaSelezionata.SelectedRows(0)
            'Dim L As New List(Of OrdineRicerca)
            Dim O As Ordine = Dr.DataBoundItem
            'L.Add(O)
            If MgrOrdini.ForzaStatoOrdineARifiutato(O) Then
                AvviaRicerca()
            End If



            'Dim Check As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, L)

            'If Check.ICan Then
            '    If MessageBox.Show("Confermi il cambiamento di stato dell'ordine " & O.IdOrd & "?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '        Dim Modificabi As Boolean = False
            '        If Not O.ConsegnaAssociata Is Nothing Then
            '            Modificabi = O.ConsegnaAssociata.Modificabile(False)
            '        Else
            '            Modificabi = True
            '        End If
            '        If Modificabi Then

            '            Dim IdCons As Integer = O.IdCons
            '            If IdCons Then
            '                Using mgr As New ConsegneProgrammateDAO
            '                    'OK
            '                    mgr.EliminaOrdineDaConsegna(IdCons, O.IdOrd)
            '                    Using C As New ConsegnaProgrammata
            '                        C.Read(IdCons)
            '                        C.AggiornaColliPeso()
            '                    End Using
            '                    mgr.EliminaConsegnaSeVuota(IdCons)
            '                End Using
            '            End If
            '            ForzaStato(enStatoOrdine.Rifiutato)
            '            CaricaGruppi()
            '        Else
            '            MessageBox.Show("Consegna non modificabile")
            '        End If
            '    End If
            'Else
            '    MessageBox.Show(MgrOrderLock.GetMessageLocked(Check))
            'End If

        End If

    End Sub

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        AvviaRicerca()
    End Sub

    'Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
    '    CaricaGruppi()
    '    'tvwCat.ExpandAll()
    'End Sub

    Private Sub tvwCat_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwCat.AfterSelect
        If sender.focused Then
            'CaricaTipiCommessa()
            AvviaRicerca()
        End If


    End Sub

    'Private Sub CaricaTipiCommessa()
    '    Dim IdCatProd As Integer = 0
    '    If Not tvwCat.SelectedNode Is Nothing Then

    '        Dim IdChiave As Integer = tvwCat.SelectedNode.Name.Substring(1)
    '        If IdChiave Then IdCatProd = IdChiave
    '    End If
    '    Dim L As List(Of CatProdTipocom)
    '    cmbTipoCom.ValueMember = "IdTipoCom"
    '    cmbTipoCom.DisplayMember = "Descrizione"
    '    If cmbTipoCom.DataSource Is Nothing Then
    '        cmbTipoCom.Items.Clear()
    '        cmbTipoCom.Text = ""
    '    Else
    '        cmbTipoCom.DataSource = Nothing
    '    End If

    '    If IdCatProd = 0 Then
    '        Using TipoCom As New TipoCommesseDAO
    '            cmbTipoCom.DataSource = TipoCom.GetAll("Descrizione")
    '        End Using
    '    Else
    '        Using mgr As New CatProdTipoComDAO
    '            L = mgr.FindAll(New LUNA.LunaSearchParameter("IdCatProd", IdCatProd))
    '        End Using

    '        For Each c As CatProdTipoCom In L
    '            Dim t As New TipoCommessa
    '            t.Read(c.IdTipoCom)
    '            cmbTipoCom.Items.Add(t)
    '        Next
    '        If L.Count Then
    '            cmbTipoCom.SelectedIndex = 0
    '        Else
    '            cmbModelloCommessa.DataSource = Nothing
    '        End If

    '    End If


    'End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub pctAnteprimaModello_Click(sender As Object, e As EventArgs)
        'If Not pctAnteprimaModello.Image Is Nothing Then
        '    ParentFormerForm.Sottofondo 
        '    Dim f As New frmModelloCommessa
        '    f.Carica(cmbModelloCommessa.SelectedValue)
        '    ParentFormerForm.Sottofondo 
        'End If
    End Sub

    Private Sub DGOrdini_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGOrdini.CellContentClick

    End Sub

    Private Sub DGOrdini_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DGOrdini.RowsAdded
        'Try
        '    Dim TotSpazi As Integer = 0
        '    For Each r As DataGridViewRow In DGOrdini.Rows
        '        TotSpazi += r.Cells(8).Value
        '    Next
        '    lblNumSpazi.Text = TotSpazi
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub DGOrdini_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGOrdini.ColumnHeaderMouseClick,
        dgOrdiniUtilizzati.ColumnHeaderMouseClick,
        DgOrdiniNonUtilizzati.ColumnHeaderMouseClick
        grigliaSelezionata = sender
        OrdinatoreLista(Of OrdineRicerca).OrdinaLista(sender, e)
    End Sub

    Private ParametriImpostati As ParametriCreazioneSoluzione = Nothing

    Private Sub CalcolaSoluzioni(Optional ListaOrdini As String = "",
                                 Optional ForceAskParameter As Boolean = True,
                                 Optional AskParameter As Boolean = False)

        Dim CheckOkParam As Boolean = True

        Dim LstStati As String = enStatoOrdine.Preinserito & "," & enStatoOrdine.Registrato & "," & enStatoOrdine.RefineAutomatico
        Dim L As List(Of OrdineRicerca)

        Using OMgr As New OrdiniDAO
            L = OMgr.Lista(, LstStati, , True, , , , , , , , , , , True, , , , , , , ListaOrdini)
            'L = L.FindAll(Function(x) x.IdListinoBase <> 0)
        End Using

        L = L.FindAll(Function(x) x.IdTipoProd = enRepartoWeb.StampaOffset Or x.IdTipoProd = enRepartoWeb.Packaging)

        Dim OrdiniPre As Integer = L.FindAll(Function(x) x.Stato = enStatoOrdine.Preinserito).Count
        Dim OrdiniRA As Integer = L.FindAll(Function(x) x.Stato = enStatoOrdine.RefineAutomatico).Count

        If OrdiniPre Then
            MessageBox.Show("Nel calcolo soluzione non verranno presi in considerazione " & OrdiniPre & " ordini in stato Preinserito e " & OrdiniRA & " ordini in stato Refine Automatico")
        End If

        If ForceAskParameter = True OrElse ParametriImpostati Is Nothing Then

            If AskParameter Then
                Using frmPar As New frmCommessaParamSoluzione
                    ParentFormEx.Sottofondo()
                    ParametriImpostati = frmPar.Carica(L)
                    If ParametriImpostati Is Nothing Then
                        CheckOkParam = False
                    End If
                    ParentFormEx.Sottofondo()
                End Using
            Else
                ParametriImpostati = New ParametriCreazioneSoluzione
                'If FormerDebug.DebugAttivo Then
                ParametriImpostati.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreBeta
                'Else
                'ParametriImpostati.MotoreScelto = enMotoreCalcoloSoluzioni.MotoreStabile
                'End If
                ParametriImpostati.MaxDuplicazioneSingoloOrdine = 10

                If ListaOrdini.Length = 0 Then
                    ParametriImpostati.SoloSoluzioniOttimali = True
                    ParametriImpostati.UtilizzaSoloMacchinarioDefault = True
                    ParametriImpostati.PermettiQtaMinoreOrdini = False
                Else
                    ParametriImpostati.NonMostrareTutteleCombinazioni = False
                    ParametriImpostati.UtilizzaSoloMacchinarioDefault = False
                    ParametriImpostati.PermettiQtaMinoreOrdini = True
                    ParametriImpostati.UtilizzaAncheFormatiCarta = True
                End If

            End If
        End If

        If CheckOkParam Then
            Cursor = Cursors.WaitCursor


            'Dim L As List(Of OrdineRicerca) = OMgr.Find(New LUNA.LunaSearchParameter("Stato", CInt(enStatoOrdine.Preinserito)), _
            '                                     New LUNA.LunaSearchParameter("Stato", CInt(enStatoOrdine.Registrato), , LUNA.enLogicOperator.enOR))
            tvwSoluzioni.Nodes.Clear()

            Dim NSolOk As New TreeNode
            NSolOk.Text = "Soluzioni Trovate"
            NSolOk.Name = Guid.NewGuid().ToString()
            'NSolOk.BackColor = Color.Green
            'NSolOk.ForeColor = Color.White
            NSolOk.ImageIndex = 2
            NSolOk.SelectedImageIndex = 2
            tvwSoluzioni.Nodes.Add(NSolOk)

            Dim lComAuto As List(Of Commessa) = Nothing
            Using mgr As New CommesseDAO
                lComAuto = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Commessa.Stato, enStatoCommessa.Preinserito),
                                       New LUNA.LunaSearchParameter(LFM.Commessa.IdReparto, enRepartoWeb.StampaOffset),
                                       New LUNA.LunaSearchParameter(LFM.Commessa.CreataAutomaticamente, enSiNo.Si))
            End Using

            Dim NComAuto As New TreeNode("Commesse Automatiche (" & lComAuto.Count & ")")
            'NSolOk.Nodes.Add(NComAuto)
            NSolOk.Nodes.Add(NComAuto)

            For Each singCom As Commessa In lComAuto
                Dim N As New TreeNode
                N.Text = singCom.Riassunto & " Tiratura: " & singCom.Copie
                N.Tag = singCom

                For Each singOrd As Ordine In singCom.ListaOrdini
                    Dim NodoOrd As New TreeNode
                    'NodoOrd.Text = "(" & O.SpaziUsati & " pos.) " & IIf(O.Prioritario, "ORDINE " & O.Ordine.IdOrd & " PRIORITARIO, Consegna: " & O.Ordine.DataConsProgrStr, " Ordine " & O.Ordine.IdOrd) & " - " & O.Ordine.Prodotto.Descrizione
                    NodoOrd.Text = singOrd.IdOrd & " " & singOrd.Prodotto.Descrizione & " (" & singOrd.DataConsPrevStr & ") " & IIf(singOrd.Priorita, "PRIORITARIO", "")
                    NodoOrd.ImageIndex = 1
                    NodoOrd.SelectedImageIndex = 1
                    NodoOrd.Tag = singOrd
                    N.Nodes.Add(NodoOrd)
                Next

                NComAuto.Nodes.Add(N)
            Next



            Dim LUtil As New List(Of OrdineRicerca)

            'L = L.FindAll(Function(Item) Item.IdCom = 0)

            ''li ordino in modo che tratto sempre prima gli ordini piu urgenti
            'L.Sort(Function(x, y) y.DataPrevConsegna.CompareTo(x.DataPrevConsegna))

            'Dim Sol As MgrCommesseOne = New MgrCommesseOne

            Dim lSol As List(Of Soluzione) = Nothing

            Dim lToLav As New List(Of OrdineRicerca)

            lToLav.AddRange(L)

            'If FormerDebug.DebugAttivo Then
            '    If ListaOrdini.Length = 0 Then
            '        lToLav.Sort(Function(x, y) y.Qta.CompareTo(x.Qta))

            '        lToLav = lToLav.GetRange(0, 1)
            '    End If
            'End If

            Using f As New frmCommessaCalcoloSoluzioni
                ParentFormEx.Sottofondo()
                lSol = f.Carica(lToLav.FindAll(Function(x) x.Stato = enStatoOrdine.Registrato), ParametriImpostati)
                ParentFormEx.Sottofondo()
            End Using

            'DISABILITATO PER AVERE LA FORM
            'lSol = MotoreCalcoloSoluzioni.ProponiSoluzioni(lToLav.FindAll(Function(x) x.Stato = enStatoOrdine.Registrato), ParametriImpostati)

            'in lSol ho le soluzioni che lui pensa di aver trovato, ora le mostro sull'albero

            'Dim NSolKO As New TreeNode
            'NSolKO.Text = "Soluzioni plausibili"
            ''NSolKO.BackColor = Color.Orange
            ''NSolKO.ForeColor = Color.Black
            'NSolKO.ImageIndex = 3
            'NSolKO.SelectedImageIndex = 3
            'tvwSoluzioni.Nodes.Add(NSolKO)
            'Dim NodoRif As TreeNode = NSolOk
            Dim CountSol As Integer = 1

            For Each ss As Soluzione In lSol

                If ss.Commesse.FindAll(Function(x) x.PercentualeCompletamento > 50).Count Then
                    ss.Commesse = ss.Commesse.FindAll(Function(x) x.PercentualeCompletamento >= 50)
                End If

                'Dim NodoSol As TreeNode
                'NodoSol.Text = "Soluzione " & CountSol
                'Dim IndSing As Integer = 1
                'NodoRif.Nodes.Add(NodoSol)
                ss.Commesse.Sort(AddressOf SortCommessaPropostaEx)
                For Each C As CommessaProposta In ss.Commesse
                    'MessageBox.Show(C.PercentualeCompletamento)
                    'Dim PrefissoNodo As String = String.Empty
                    'If (C.PercentualeCompletamento = 100 And C.Rielaborata = False) Or (C.PercentualeCompletamento = 100 And C.ModelloCommessa.RitieniOkDuplicati = enSiNo.Si And C.Rielaborata = True) Then
                    '    NodoSol = NSolOk
                    '    ' PrefissoNodo = String.Empty
                    'Else
                    '    NodoSol = NSolKO
                    '    ' PrefissoNodo = "(" & C.PercentualeCompletamento & "%) - "
                    'End If
                    Dim NodoCom As New TreeNode
                    ' Dim NomeNodoCom As String = String.Empty

                    'For Each o As OrdineInSoluzione In C.Ordini
                    '    Dim Ord As New Ordine
                    '    Ord.Read(o.IdOrd)
                    '    'Dim NomePrev As String = Ord.ListinoBase.Preventivazione.Descrizione
                    '    'If NomeNodoCom.IndexOf(NomePrev) = -1 Then NomeNodoCom &= NomePrev & ", "
                    'Next

                    'NomeNodoCom = NomeNodoCom.Substring(0, NomeNodoCom.Length - 2)

                    ' NomeNodoCom &= " ("
                    ' For Each fc As FormatoCarta In C.ModelloCommessa.FormatiCarta
                    'NomeNodoCom &= C.SpaziDisponibili(fc.IdFormCarta) & " - " & fc.FormatoCarta & ", "
                    'Next
                    ' NomeNodoCom = NomeNodoCom.Substring(0, NomeNodoCom.Length - 2)
                    ' NomeNodoCom &= ")"

                    'NodoCom.Text = PrefissoNodo & NomeNodoCom & " " & " Tiratura: " & C.Tiratura & " Spz Disp: " & C.SpaziDisponibiliTot & _
                    '    " Spz Util: " & C.SpaziUsatiTot

                    Dim WithPerc As Boolean = False
                    If ListaOrdini.Length Then
                        WithPerc = True
                    End If

                    NodoCom.Text = C.Riassunto(WithPerc) & IIf(FormerDebug.DebugAttivo, " - IDMod " & C.ModelloCommessa.IdModello & " - N° Las. " & C.NLastreNecessarie, String.Empty)
                    NodoCom.Tag = C
                    NodoCom.ImageIndex = 0
                    NodoCom.SelectedImageIndex = 0

                    If ListaOrdini.Length = 0 Then
                        NodoCom.BackColor = Color.Green
                        NodoCom.ForeColor = Color.White
                        'If C.Creabile Then

                        '    If (C.PercentualeCompletamento = 100 And C.Rielaborata = False) Or
                        '       (C.PercentualeCompletamento = 100 And C.Rielaborata = True And C.ModelloCommessa.RitieniOkDuplicati = enSiNo.Si) Then
                        '        NodoCom.BackColor = Color.Green
                        '        NodoCom.ForeColor = Color.White
                        '    Else
                        '        NodoCom.BackColor = Color.White
                        '        NodoCom.ForeColor = Color.Black
                        '    End If
                        'Else
                        '    NodoCom.BackColor = Color.White
                        '    NodoCom.ForeColor = Color.Black
                        'End If
                    End If

                    NSolOk.Nodes.Add(NodoCom)

                    'C.Ordini.Sort(Function(x, y) y.SpaziUsati.CompareTo(x.SpaziUsati))
                    C.Ordini.Sort(AddressOf ComparerOiS)
                    For Each O As OrdineInSoluzione In C.Ordini
                        If (C.PercentualeCompletamento = 100 And C.Rielaborata = False) Or
                           (C.PercentualeCompletamento = 100 And C.Rielaborata = True And C.ModelloCommessa.RitieniOkDuplicati = enSiNo.Si) Then
                            'If LUtil.FindAll(Function(x) x.IdOrd = O.IdOrd).Count = 0 Then
                            Dim Outil As OrdineRicerca = O.Ordine.Clone
                            If LUtil.FindAll(Function(x) x.IdOrd = Outil.IdOrd).Count = 0 Then LUtil.Add(Outil)
                            'End If
                            'Else
                            '    Dim Outil As OrdineRicerca = O.Ordine
                            '    LNoUtil.Add(Outil)
                        End If
                        Dim NodoOrd As New TreeNode
                        'NodoOrd.Text = "(" & O.SpaziUsati & " pos.) " & IIf(O.Prioritario, "ORDINE " & O.Ordine.IdOrd & " PRIORITARIO, Consegna: " & O.Ordine.DataConsProgrStr, " Ordine " & O.Ordine.IdOrd) & " - " & O.Ordine.Prodotto.Descrizione
                        NodoOrd.Text = O.Ordine.IdOrd & " (" & O.SpaziUsati & " pos.) " & O.Ordine.Prodotto.Descrizione & " (" & O.Ordine.DataConsProgrStr & ") " & IIf(O.Prioritario, "PRIORITARIO", "")
                        NodoOrd.ImageIndex = 1
                        NodoOrd.SelectedImageIndex = 1
                        NodoOrd.Tag = O
                        If O.Ordine.ProgrammataConsegna = False Then
                            NodoOrd.BackColor = Color.Red
                            NodoOrd.ForeColor = Color.White
                            'Else
                            '   NodoOrd.BackColor = Color.Green
                        ElseIf O.TiratoA <> C.Tiratura Then
                            NodoOrd.BackColor = Color.Orange
                        End If
                        NodoCom.Nodes.Add(NodoOrd)

                    Next
                    'NodoCom.Tag.ToString.TrimEnd(",")
                Next
                CountSol += 1
            Next
            LUtil.Sort(AddressOf Comparer)

            dgOrdiniUtilizzati.AutoGenerateColumns = False
            dgOrdiniUtilizzati.DataSource = LUtil

            dgOrdiniUtilizzati.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdiniUtilizzati.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdiniUtilizzati.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdiniUtilizzati.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgOrdiniUtilizzati.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Dim LNoUtil As New List(Of OrdineRicerca)

            For Each Os As OrdineRicerca In L
                If LUtil.Find(Function(x) x.IdOrd = Os.IdOrd) Is Nothing Then
                    LNoUtil.Add(Os)
                End If
            Next

            LNoUtil.Sort(AddressOf Comparer)

            DgOrdiniNonUtilizzati.AutoGenerateColumns = False
            DgOrdiniNonUtilizzati.DataSource = LNoUtil

            DgOrdiniNonUtilizzati.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgOrdiniNonUtilizzati.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgOrdiniNonUtilizzati.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgOrdiniNonUtilizzati.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgOrdiniNonUtilizzati.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            MgrControl.AutoAdattaDimensioni(splitOrd, LUtil.Count, LNoUtil.Count)

            NSolOk.Expand()

            Cursor = Cursors.Default
        End If


        'tvwSoluzioni.ExpandAll()
    End Sub

    Private Function ComparerOiS(x As OrdineInSoluzione, y As OrdineInSoluzione) As Integer
        Dim ris As Integer = y.QtaOrdine.CompareTo(x.QtaOrdine)
        If ris = 0 Then
            ris = x.IdOrd.CompareTo(y.IdOrd)
        End If

        Return ris
    End Function

    Private Function Comparer(x As OrdineRicerca, y As OrdineRicerca) As Integer
        Dim ris As Integer = x.IdListinoBase.CompareTo(y.IdListinoBase)
        If ris = 0 Then
            ris = x.QtaRif.CompareTo(y.QtaRif)
            If ris = 0 Then
                ris = x.IdRub.CompareTo(y.IdRub)
                If ris = 0 Then
                    ris = x.DataPrevConsegna.CompareTo(y.DataPrevConsegna)
                End If
            End If
        End If

        Return ris
    End Function

    Private Sub CaricaOrdiniDisponibili()

        dgOrdiniUtilizzati.DataSource = Nothing

        Cursor.Current = Cursors.WaitCursor
        Using OMgr As New OrdiniDAO
            Dim LstStati As String = enStatoOrdine.Preinserito & "," & enStatoOrdine.Registrato & "," & enStatoOrdine.RefineAutomatico
            Dim LNoUtil As New List(Of OrdineRicerca)

            LNoUtil = OMgr.Lista(, LstStati, , True, , , , , , , , , , , True, )
            LNoUtil = LNoUtil.FindAll(Function(x) x.IdTipoProd = enRepartoWeb.StampaOffset Or x.IdTipoProd = enRepartoWeb.Packaging)

            LNoUtil.Sort(AddressOf Comparer)

            'L = L.FindAll(Function(x) x.IdListinoBase <> 0)
            DgOrdiniNonUtilizzati.AutoGenerateColumns = False
            DgOrdiniNonUtilizzati.DataSource = LNoUtil

            DgOrdiniNonUtilizzati.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgOrdiniNonUtilizzati.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgOrdiniNonUtilizzati.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgOrdiniNonUtilizzati.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgOrdiniNonUtilizzati.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            MgrControl.AutoAdattaDimensioni(splitOrd, 0, LNoUtil.Count)
        End Using
        Cursor.Current = Cursors.Default
    End Sub

    Private Function SortCommessaPropostaEx(ByVal x As CommessaProposta,
                                          ByVal y As CommessaProposta) As Integer
        Dim result As Integer = 0
        'result = x.ModelloCommessa.Nome.CompareTo(y.ModelloCommessa.Nome)
        If result = 0 Then
            result = y.Ordini.Count.CompareTo(x.Ordini.Count)
            If result = 0 Then
                result = y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento)
                If result = 0 Then
                    result = y.Tiratura.CompareTo(x.Tiratura)
                End If
            End If
        End If


        Return result
    End Function

    Private Function SortCommessaProposta(ByVal x As CommessaProposta,
                                          ByVal y As CommessaProposta) As Integer
        Dim result As Integer = 0
        result = y.PercentualeCompletamento.CompareTo(x.PercentualeCompletamento)
        If result = 0 Then
            result = x.Rielaborata.CompareTo(y.Rielaborata)
            If result = 0 Then
                result = y.ModelloCommessa.RitieniOkDuplicati.CompareTo(x.ModelloCommessa.RitieniOkDuplicati)
                If result = 0 Then
                    result = x.NomeCorto.CompareTo(y.NomeCorto)
                    If result = 0 Then
                        result = y.Tiratura.CompareTo(x.Tiratura)
                    End If
                End If
            End If
        End If
        Return result
    End Function

    'DEBUG:*****************************************************************************************
    Private Function SortModelli(ByVal x As ModelloCommessa,
                                 ByVal y As ModelloCommessa) As Integer
        Dim result As Integer = 0
        ' Try

        If Not y.FormatiCarta Is Nothing And Not x.FormatiCarta Is Nothing Then
            result = y.FormatiCarta.Count.CompareTo(x.FormatiCarta.Count)
        End If

        If result = 0 Then
            result = y.NumSpazi.CompareTo(x.NumSpazi)
        End If

        'Catch ex As Exception

        'End Try
        Return result
    End Function


    Private Sub dgOrdiniAuto_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgOrdiniUtilizzati.RowPostPaint, DgOrdiniNonUtilizzati.RowPostPaint
        Dim x As DataGridViewRow = sender.Rows.Item(e.RowIndex)
        Dim O As OrdineRicerca = x.DataBoundItem

        x.Cells(3).Style.BackColor = O.StatoColore
        x.Cells(3).Style.SelectionBackColor = O.StatoColore
    End Sub

    Private Sub ApriModelloCommessa()

        If Not tvwSoluzioni.SelectedNode Is Nothing Then
            If Not tvwSoluzioni.SelectedNode Is Nothing Then

                If TypeOf (tvwSoluzioni.SelectedNode.Tag) Is Commessa Then
                    Dim C As Commessa = tvwSoluzioni.SelectedNode.Tag
                    ParentFormEx.Sottofondo()
                    Using x As New frmCommessaModello
                        x.Carica(C.IdModelloCommessa)
                    End Using
                    ParentFormEx.Sottofondo()
                Else
                    Dim C As CommessaProposta = tvwSoluzioni.SelectedNode.Tag
                    ParentFormEx.Sottofondo()
                    Using x As New frmCommessaModello
                        x.Carica(C.ModelloCommessa.IdModello)
                    End Using
                    ParentFormEx.Sottofondo()
                End If

            Else
                MessageBox.Show("Selezionare una commessa nell'albero delle soluzioni!", , MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Selezionare una commessa nell'albero delle soluzioni!", , MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub CreaSelezionata()

        If PostazioneCorrente.ScaricamentoOrdiniInCorso Then
            MessageBox.Show("Il Demone sta scaricando i nuovi ordini, attendere il termine dell'operazione e riprovare")
        Else
            If Not tvwSoluzioni.SelectedNode Is Nothing Then
                If TypeOf (tvwSoluzioni.SelectedNode.Tag) Is CommessaProposta Then
                    Dim C As CommessaProposta = tvwSoluzioni.SelectedNode.Tag
                    Dim ListaIdOrd As String = ""
                    Dim Alert As String = ""
                    Dim ListaOrdini As New List(Of Ordine)
                    For Each O As OrdineInSoluzione In C.Ordini
                        ListaIdOrd &= O.IdOrd & ","
                        If O.Ordine.Stato = enStatoOrdine.Preinserito Then
                            Alert &= O.IdOrd & ","
                        End If
                        ListaOrdini.Add(O.Ordine)
                    Next
                    ListaIdOrd = ListaIdOrd.TrimEnd(",")
                    Alert = Alert.TrimEnd(", ")


                    If Alert.Length = 0 Then
                        'qui controllo se non ci sia il blocco
                        Dim RisCheck As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, ListaOrdini)

                        If RisCheck.ICan Then
                            MgrOrderLock.Lock(PostazioneCorrente.UtenteConnesso.IdUt,
                                            ListaOrdini,
                                            enFunctionLock.CreazioneCommesse)
                            'creo una commessa partendo dagli ordini selezionati
                            ParentFormEx.Sottofondo()
                            Dim Ris As Integer = 0
                            Using x As New frmCommessa

                                Ris = x.Carica(, ListaIdOrd, C, C.ModelloCommessa.IdReparto)
                            End Using

                            ParentFormEx.Sottofondo()

                            If Ris Then

                                'ParentFormEx.Sottofondo()
                                'Using com As New Commessa
                                '    com.Read(Ris)
                                '    Dim collOrd As OrdiniCTP = MgrCTP.GetListaOrdiniCTP(com)

                                '    Using X As New frmCTP
                                '        ParentFormEx.Sottofondo()
                                '        X.Carica(collOrd, com.IdCom)
                                '        ParentFormEx.Sottofondo()
                                '    End Using
                                'End Using
                                'ParentFormEx.Sottofondo()
                                ResetSituazione()
                                'CalcolaSoluzioni(, False)
                                'Else

                            End If
                            'qui devo cancellare il lock
                            'sia che sia stata creata sia che sia stata annullata
                            MgrOrderLock.UnLock(PostazioneCorrente.UtenteConnesso.IdUt, ListaOrdini)
                        Else
                            MessageBox.Show(MgrOrderLock.GetMessageLocked(RisCheck))
                        End If

                    Else
                        MessageBox.Show("Gli Ordini " & Alert & " sono ancora in stato preinserito, impossibile creare la commessa!", , MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf TypeOf (tvwSoluzioni.SelectedNode.Tag) Is Commessa Then
                    'qui e' stata selezionata una commessa creata in automatico
                    Dim ComSel As Commessa = DirectCast(tvwSoluzioni.SelectedNode.Tag, Commessa)

                    ParentFormEx.Sottofondo()

                    Dim Ricalcolare As Boolean = False

                    Using x As New frmCommessa
                        x.Carica(ComSel.IdCom)
                    End Using

                    ParentFormEx.Sottofondo()

                    '                    ParentFormEx.Sottofondo()
                    'qui devo controllare lo stato della commessa all'uscita, se ancora esiste

                    Using mgr As New CommesseDAO
                        Dim l As List(Of Commessa) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Commessa.IdCom, ComSel.IdCom))

                        If l.Count Then
                            ComSel = l(0)
                            If ComSel.Stato = enStatoCommessa.Pronto Then
                                Ricalcolare = True
                            End If
                        Else
                            Ricalcolare = True
                        End If

                    End Using

                    If Ricalcolare Then
                        Cursor = Cursors.WaitCursor
                        ResetSituazione()
                        'CalcolaSoluzioni(, False)
                        Cursor = Cursors.Default
                    End If

                Else
                    MessageBox.Show("Selezionare una commessa nell'albero delle soluzioni!", , MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Selezionare una commessa nell'albero delle soluzioni!", , MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

    End Sub

    Private Sub ResetSituazione()

        tvwSoluzioni.Nodes.Clear()
        DgOrdiniNonUtilizzati.DataSource = Nothing
        dgOrdiniUtilizzati.DataSource = Nothing

    End Sub

    Private Sub DGOrdini_MouseClick(sender As Object, e As MouseEventArgs) Handles DGOrdini.MouseClick,
        dgOrdiniUtilizzati.MouseClick,
        DgOrdiniNonUtilizzati.MouseClick
        grigliaSelezionata = sender
        If sender.SelectedRows.Count Then

            Dim Dr As DataGridViewRow

            Dr = sender.SelectedRows(0)

            If Not Dr Is Nothing Then
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Dim x As System.Drawing.Point = MousePosition
                    Dim O As Ordine = Dr.DataBoundItem

                    Dr.Selected = True
                    'If IdOrdSel <> O.IdOrd Then
                    IdOrdSel = O.IdOrd
                    RaiseEvent OrdineSelezionato()
                    'End If

                    MenuOrd.Show(x)

                End If

            End If
        End If
    End Sub

    Private Sub RiapriOrdine(e As MouseEventArgs)
        If grigliaSelezionata.SelectedRows.Count Then
            If e.Button = Windows.Forms.MouseButtons.Left Then

                If grigliaSelezionata.SelectedRows.Count Then
                    'riapro l'ordine in modifica
                    Dim rig As DataGridViewRow
                    Dim RigaSel As Integer = grigliaSelezionata.SelectedRows(0).Index

                    If RigaSel <> -1 Then
                        rig = grigliaSelezionata.Rows(RigaSel)
                        rig.Selected = True
                        grigliaSelezionata.Select()

                        Dim O As Ordine = grigliaSelezionata.SelectedRows(0).DataBoundItem
                        IdOrdSel = O.IdOrd

                        Using frmRif As New frmOrdine

                            Dim Ris As Integer = 0

                            ParentFormEx.Sottofondo()
                            Ris = frmRif.Carica(IdOrdSel)
                            ParentFormEx.Sottofondo()
                            If Ris Then AvviaRicerca()
                        End Using

                    End If
                End If


            End If
        End If
    End Sub

    Private Sub DGOrdini_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DGOrdini.MouseDoubleClick,
        dgOrdiniUtilizzati.MouseDoubleClick,
        DgOrdiniNonUtilizzati.MouseDoubleClick

        grigliaSelezionata = sender

        RiapriOrdine(e)


    End Sub

    Private Sub tvwSoluzioni_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwSoluzioni.NodeMouseClick

        If Not e.Node Is Nothing Then

            If TypeOf (e.Node.Tag) Is CommessaProposta Then

                MostraAnteprima = False

                'click su una commessa
                Dim C As CommessaProposta = DirectCast(e.Node.Tag, CommessaProposta)

                IdModelloCommessaSel = C.ModelloCommessa.IdModello

                For Each row As DataGridViewRow In dgOrdiniUtilizzati.SelectedRows
                    row.Selected = False
                Next
                For Each row As DataGridViewRow In DgOrdiniNonUtilizzati.SelectedRows
                    row.Selected = False
                Next

                'seleziono nelle liste 
                For Each o As OrdineInSoluzione In C.Ordini

                    Dim Trovato As Boolean = False
                    For Each riga As DataGridViewRow In dgOrdiniUtilizzati.Rows
                        Dim IdOrd As Integer = riga.Cells(3).Value ' DirectCast(riga.DataBoundItem, Ordine).IdOrd
                        If IdOrd = o.IdOrd Then
                            riga.Selected = True
                            Trovato = True
                            Exit For
                        End If
                    Next

                    If Trovato = False Then
                        For Each riga As DataGridViewRow In DgOrdiniNonUtilizzati.Rows
                            Dim IdOrd As Integer = riga.Cells(3).Value ' DirectCast(riga.DataBoundItem, Ordine).IdOrd
                            If IdOrd = o.IdOrd Then
                                riga.Selected = True

                                Exit For
                            End If
                        Next
                    End If
                Next
                MostraAnteprima = True
                RaiseEvent ModelloCommessaSelezionato()

            ElseIf TypeOf (e.Node.Tag) Is OrdineInSoluzione Then
                'click su un ordine
                IdOrdSel = DirectCast(e.Node.Tag, OrdineInSoluzione).IdOrd

                'Dim Trovato As Boolean = False
                'For Each riga As DataGridViewRow In dgOrdiniUtilizzati.Rows
                '    Dim IdOrd As Integer = riga.Cells(2).Value ' DirectCast(riga.DataBoundItem, Ordine).IdOrd
                '    If IdOrd = IdOrdSel Then
                '        riga.Selected = True
                '        Trovato = True
                '        Exit For
                '    End If
                'Next

                'If Trovato = False Then
                '    For Each riga As DataGridViewRow In DgOrdiniNonUtilizzati.Rows
                '        Dim IdOrd As Integer = riga.Cells(2).Value ' DirectCast(riga.DataBoundItem, Ordine).IdOrd
                '        If IdOrd = IdOrdSel Then
                '            riga.Selected = True

                '            Exit For
                '        End If
                '    Next
                'End If

                RaiseEvent OrdineSelezionato()
            ElseIf TypeOf (e.Node.Tag) Is Commessa Then
                Dim C As Commessa = DirectCast(e.Node.Tag, Commessa)
                IdModelloCommessaSel = C.ModelloCommessa.IdModello
                RaiseEvent ModelloCommessaSelezionato()
            ElseIf TypeOf (e.Node.Tag) Is Ordine Then
                IdOrdSel = DirectCast(e.Node.Tag, Ordine).IdOrd
                RaiseEvent OrdineSelezionato()
            End If

            'qui devo cercare il nodo nelle due grid e selezionarlo

        End If

    End Sub

    Private Sub btnAggAlb_Click(sender As Object, e As EventArgs)


    End Sub

    'Private Sub PassaTuttiRegistrato(Optional Ricalcola As Boolean = False)

    '    If MessageBox.Show("Confermi il passaggio di tutti gli ordini presenti nello stato PREINSERITO a REGISTRATO?", "CAMBIO STATO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '        Cursor = Cursors.WaitCursor
    '        Using mgr As New OrdiniDAO
    '            Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Preinserito))

    '            For Each o As Ordine In l
    '                mgr.AvanzaOrdiniAStatoByIdOrd(o.IdOrd, enStatoOrdine.Registrato)
    '            Next
    '        End Using

    '        CaricaGruppi()
    '        RegistratoToolStripMenuItem.Checked = True
    '        AvviaRicerca()

    '        If Ricalcola Then CalcolaSoluzioni(, False)

    '        Cursor = Cursors.Default
    '    End If

    'End Sub

    'Private Sub btnPassaRegistrato_Click(sender As Object, e As EventArgs)

    '    PassaTuttiRegistrato()

    'End Sub

    'Private Sub rdoRifiutato_CheckedChanged(sender As Object, e As EventArgs)
    '    If sender.focused Then
    '        'CaricaGruppi()
    '        lnkNewCom.Enabled = rdoReg.Checked
    '        AvviaRicerca()
    '    End If
    'End Sub

    Private Sub lnkCalcSelez_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    End Sub

    Private Sub CalcolaSuSelezionati(Optional ForceAsk As Boolean = False,
                                     Optional ConParametri As Boolean = False)

        Dim ListaId As String = String.Empty

        For Each dr As DataGridViewRow In dgOrdiniUtilizzati.SelectedRows
            Dim O As OrdineRicerca = dr.DataBoundItem

            ListaId &= O.IdOrd & ","

        Next

        For Each dr As DataGridViewRow In DgOrdiniNonUtilizzati.SelectedRows
            Dim O As OrdineRicerca = dr.DataBoundItem
            ListaId &= O.IdOrd & ","
        Next

        ListaId = ListaId.TrimEnd(",")

        If ListaId.Length Then
            CalcolaSoluzioni(ListaId, ForceAsk, ConParametri)
        Else
            MessageBox.Show("Selezionare almeno un ordine per calcolare una soluzione ad hoc")
        End If

    End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged
        If tabMain.SelectedIndex = 1 Then
            CaricaGruppi()
            'CaricaTipiCommessa()
            If PostazioneCorrente.CaricamentiAutomatici Then AvviaRicerca()
        ElseIf tabMain.SelectedIndex = 2 Then
            If PostazioneCorrente.CaricamentiAutomatici Then UcCommesse.AvviaRicerca()
        End If
    End Sub

    'Private Sub lnkTuttiRegistrato_Click(sender As Object, e As EventArgs)

    '    PassaTuttiRegistrato(True)

    'End Sub

    Private Sub UcCommesse_CommessaSelezionata() Handles UcCommesse.CommessaSelezionata

        IdComSel = UcCommesse.IdComSel

        RaiseEvent CommessaSelezionata(Me)

    End Sub

    Private Sub DGOrdini_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGOrdini.CellMouseEnter
        Try
            If e.RowIndex <> -1 Then

                If e.ColumnIndex = 3 Then
                    Dim R As DataGridViewRow

                    R = DGOrdini.Rows(e.RowIndex)

                    Dim O As Ordine = R.DataBoundItem

                    If O.IdOrd <> ToolTipOrdini.Tag Then
                        ToolTipOrdini.ToolTipTitle = "Anteprima Ordine " & O.IdOrd

                        Dim TestoTooltip As String = "ORDINE: " & O.IdOrd & " (Com. " & IIf(O.IdCom, O.IdCom, "-") & ")" & ControlChars.NewLine
                        TestoTooltip &= "STATO: " & O.StatoStr & ControlChars.NewLine & ControlChars.NewLine

                        For Each lav As LavLog In O.ListaLavLogCompleta
                            TestoTooltip &= " - " & lav.LavorazioneStr & ControlChars.NewLine
                        Next

                        TestoTooltip &= ControlChars.NewLine

                        'If Not O.ConsegnaAssociata Is Nothing Then
                        '    TestoTooltip &= "CONSEGNA: " & O.ConsegnaAssociata.Giorno.ToString("dd/MM/yyyy") & ControlChars.NewLine
                        '    TestoTooltip &= "CORRIERE: " & O.ConsegnaAssociata.Corriere.Descrizione & ControlChars.NewLine
                        '    TestoTooltip &= "PAGAMENTO: " & O.ConsegnaAssociata.MetodoPagamento.TipoPagam & ControlChars.NewLine & ControlChars.NewLine
                        'End If

                        TestoTooltip &= "NOTE: " & O.Annotazioni

                        ToolTipOrdini.Tag = O.IdOrd

                        'For Each c As DataGridViewCell In R.Cells
                        '    c.ToolTipText = TestoTooltip
                        'Next

                        ToolTipOrdini.SetToolTip(DGOrdini, TestoTooltip)
                    End If
                Else
                    ToolTipOrdini.RemoveAll()
                End If

            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub lnkSimulaCreazione_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        If FormerDebug.DebugAttivo Then
            If Not tvwSoluzioni.SelectedNode Is Nothing Then
                If TypeOf (tvwSoluzioni.SelectedNode.Tag) Is CommessaProposta Then
                    Dim C As CommessaProposta = tvwSoluzioni.SelectedNode.Tag

                    Using mgr As New CommesseDAO
                        mgr.CreaCommessaAutomaticaOffset(C)
                    End Using
                    MessageBox.Show("Fatto")
                End If
            End If
        End If

    End Sub


    Private Sub SoloSuSelezionatiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SoloSuSelezionatiToolStripMenuItem.Click
        CalcolaSoluzioniToolStripMenuItem.HideDropDown()
        Application.DoEvents()
        CalcolaSuSelezionati(True, False)
        CaricaMacchinari()
    End Sub

    Private Sub CalcolaSoluzioniSuSelezionatiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcolaSoluzioniSuSelezionatiToolStripMenuItem.Click
        CalcolaSoluzioniToolStripMenuItem.HideDropDown()
        Application.DoEvents()
        CalcolaSoluzioni(, True, False)
        CaricaMacchinari()
    End Sub

    Private Sub CreaSelezionataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreaSelezionataToolStripMenuItem.Click
        'Dim Ris As FunctionICanRis = FormerLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.CreazioneCommesse)
        'If Ris.ICan Then
        CreaSelezionata()
        'Else
        'If Ris.IsLockedByAnother Then
        '        MessageBox.Show("La funzione è già bloccata sulla postazione " & Ris.LockedBy.Postazione.ToUpper & " da '" & Ris.LockedBy.Utente.Login & "'")
        'Else
        'MessageBox.Show("La funzione non è stata bloccata. Utilizzare il FunctionLock nel menù principale")
        'End If
        'End If
    End Sub

    Private Sub PassaTuttiARegistratoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'PassaTuttiRegistrato(True)
    End Sub

    Private Sub ApriModelloCommessaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriModelloCommessaToolStripMenuItem.Click
        ApriModelloCommessa()
    End Sub

    Private Sub MostraModelliCommessaPerQuestoFormatoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostraModelliCommessaPerQuestoFormatoToolStripMenuItem.Click

        If grigliaSelezionata.SelectedRows.Count Then

            '            ParentFormEx.Sottofondo()
            '           Dim f As New frmPostit
            '          f.Carica(, , IdOrdSel)
            '         ParentFormEx.Sottofondo()

            Using O As New Ordine
                O.Read(IdOrdSel)
                Dim IdFormatoCarta As Integer = 0
                IdFormatoCarta = O.ListinoBase.FormatoProdotto.IdFormCarta
                RaiseEvent SelezionatoFormatoCarta(IdFormatoCarta)
            End Using

        End If

    End Sub

    Public Event SelezionatoOrdinePerModello(IdFormatoProdotto As Integer, IdColoreStampa As Integer)
    Public Event SelezionatoFormatoProdotto(IdFormatoProdotto As Integer)
    Public Event SelezionatoFormatoCarta(IdFormatoCarta As Integer)

    Private Sub AvanzataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AvanzataToolStripMenuItem.Click
        CalcolaSoluzioniToolStripMenuItem.HideDropDown()
        Application.DoEvents()
        CalcolaSoluzioni(, True, True)
    End Sub

    Private Sub ConParametriToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MostraOrdiniConLoStessoTipoDiCartaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostraOrdiniConLoStessoTipoDiCartaToolStripMenuItem.Click
        SelezionaOrdiniCompatibili()
    End Sub

    Private Sub SelezionaOrdiniCompatibili()
        MostraAnteprima = False
        If grigliaSelezionata.SelectedRows.Count Then
            Dim ListaSelezionati As New List(Of OrdineRicerca)
            Dim O As Ordine = grigliaSelezionata.SelectedRows(0).DataBoundItem
            ListaSelezionati.Add(O)
            Dim lLavEscl As List(Of Lavorazione) = O.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)

            If grigliaSelezionata Is DGOrdini Then
                For Each row As DataGridViewRow In DGOrdini.SelectedRows
                    row.Selected = False
                Next
                For Each riga As DataGridViewRow In DGOrdini.Rows
                    Dim OInRow As Ordine = riga.DataBoundItem
                    If OInRow.ListinoBase.IdTipoCarta = O.ListinoBase.IdTipoCarta Then
                        Dim OkLav As Boolean = True
                        For Each singLav In lLavEscl
                            If OInRow.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
                                OkLav = False
                                Exit For
                            End If
                        Next
                        If OkLav Then
                            Using mgr As New OrdiniDAO
                                OkLav = mgr.IsOrdineCompatibile(OInRow, ListaSelezionati)
                            End Using
                        End If
                        If OkLav Then
                            riga.Selected = True
                            ListaSelezionati.Add(OInRow)
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In dgOrdiniUtilizzati.SelectedRows
                    row.Selected = False
                Next
                For Each row As DataGridViewRow In DgOrdiniNonUtilizzati.SelectedRows
                    row.Selected = False
                Next

                'seleziono nelle liste 
                For Each riga As DataGridViewRow In dgOrdiniUtilizzati.Rows
                    Dim OInRow As Ordine = riga.DataBoundItem
                    If OInRow.ListinoBase.IdTipoCarta = O.ListinoBase.IdTipoCarta Then
                        Dim OkLav As Boolean = True
                        For Each singLav In lLavEscl
                            If OInRow.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
                                OkLav = False
                                Exit For
                            End If
                        Next

                        If OkLav Then
                            Using mgr As New OrdiniDAO
                                OkLav = mgr.IsOrdineCompatibile(OInRow, ListaSelezionati)
                            End Using
                        End If

                        If OkLav Then
                            riga.Selected = True
                            ListaSelezionati.Add(OInRow)
                        End If
                    End If
                Next

                For Each riga As DataGridViewRow In DgOrdiniNonUtilizzati.Rows
                    Dim OInRow As Ordine = riga.DataBoundItem
                    If OInRow.ListinoBase.IdTipoCarta = O.ListinoBase.IdTipoCarta Then
                        Dim OkLav As Boolean = True
                        For Each singLav In lLavEscl
                            If OInRow.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
                                OkLav = False
                                Exit For
                            End If
                        Next
                        If OkLav Then
                            Using mgr As New OrdiniDAO
                                OkLav = mgr.IsOrdineCompatibile(OInRow, ListaSelezionati)
                            End Using
                        End If

                        If OkLav Then
                            riga.Selected = True
                            ListaSelezionati.Add(OInRow)
                        End If
                    End If
                Next
            End If
        End If

        MostraAnteprima = True

    End Sub

    Private Sub MostraGliOrdiniADisposizioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostraGliOrdiniADisposizioneToolStripMenuItem.Click
        CaricaOrdiniDisponibili()
        CaricaMacchinari()
    End Sub

    Private Sub MostraModelliCommessaPerQuestoFormatoProdottoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostraModelliCommessaPerQuestoFormatoProdottoToolStripMenuItem.Click
        If grigliaSelezionata.SelectedRows.Count Then

            '            ParentFormEx.Sottofondo()
            '           Dim f As New frmPostit
            '          f.Carica(, , IdOrdSel)
            '         ParentFormEx.Sottofondo()

            Using O As New Ordine
                O.Read(IdOrdSel)
                Dim IdFormatoProdotto As Integer = 0
                IdFormatoProdotto = O.ListinoBase.IdFormProd
                RaiseEvent SelezionatoFormatoProdotto(IdFormatoProdotto)
            End Using

        End If
    End Sub

    Private Sub tsSoloSelezionatiConParametri_Click(sender As Object, e As EventArgs) Handles tsSoloSelezionatiConParametri.Click
        CalcolaSoluzioniToolStripMenuItem.HideDropDown()
        Application.DoEvents()
        CalcolaSuSelezionati(True, True)
        CaricaMacchinari()
    End Sub

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click
        CaricaMacchinari()
    End Sub

    Private Sub dgOrdiniUtilizzati_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgOrdiniUtilizzati.CellContentClick

    End Sub

    Private Sub AggiornaAlberoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggiornaAlberoToolStripMenuItem.Click
        CaricaGruppi()
    End Sub

    Private Sub InSospesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InSospesoToolStripMenuItem.Click
        SuSelezionatiToolStripMenuItem.Enabled = RegistratoToolStripMenuItem.Checked

        If InSospesoToolStripMenuItem.Checked = False AndAlso
                RifiutatoToolStripMenuItem.Checked = False AndAlso
                RegistratoToolStripMenuItem.Checked = False AndAlso
                PreinseritoToolStripMenuItem.Checked = False Then
            RegistratoToolStripMenuItem.Checked = True
        Else
            RifiutatoToolStripMenuItem.Checked = False
            RegistratoToolStripMenuItem.Checked = False
            PreinseritoToolStripMenuItem.Checked = False
        End If
        AvviaRicerca()
    End Sub

    Private Sub RifiutatoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RifiutatoToolStripMenuItem.Click
        SuSelezionatiToolStripMenuItem.Enabled = RegistratoToolStripMenuItem.Checked
        If InSospesoToolStripMenuItem.Checked = False AndAlso
                RifiutatoToolStripMenuItem.Checked = False AndAlso
                RegistratoToolStripMenuItem.Checked = False AndAlso
                PreinseritoToolStripMenuItem.Checked = False Then
            RegistratoToolStripMenuItem.Checked = True
        Else
            InSospesoToolStripMenuItem.Checked = False
            RegistratoToolStripMenuItem.Checked = False
            PreinseritoToolStripMenuItem.Checked = False
        End If
        AvviaRicerca()
    End Sub

    Private Sub RegistratoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistratoToolStripMenuItem.Click
        SuSelezionatiToolStripMenuItem.Enabled = RegistratoToolStripMenuItem.Checked
        If InSospesoToolStripMenuItem.Checked = False AndAlso
                RifiutatoToolStripMenuItem.Checked = False AndAlso
                RegistratoToolStripMenuItem.Checked = False AndAlso
                PreinseritoToolStripMenuItem.Checked = False Then
            RegistratoToolStripMenuItem.Checked = True
        Else
            RifiutatoToolStripMenuItem.Checked = False
            InSospesoToolStripMenuItem.Checked = False
            PreinseritoToolStripMenuItem.Checked = False
        End If
        AvviaRicerca()
    End Sub

    Private Sub PreinseritoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreinseritoToolStripMenuItem.Click
        SuSelezionatiToolStripMenuItem.Enabled = RegistratoToolStripMenuItem.Checked
        If InSospesoToolStripMenuItem.Checked = False AndAlso
                RifiutatoToolStripMenuItem.Checked = False AndAlso
                RegistratoToolStripMenuItem.Checked = False AndAlso
                PreinseritoToolStripMenuItem.Checked = False Then
            RegistratoToolStripMenuItem.Checked = True
        Else
            RifiutatoToolStripMenuItem.Checked = False
            RegistratoToolStripMenuItem.Checked = False
            InSospesoToolStripMenuItem.Checked = False
        End If
        AvviaRicerca()
    End Sub

    Private Sub ManualmenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuSelezionatiToolStripMenuItem.Click
        '        Dim Ris As FunctionICanRis = FormerLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.CreazioneCommesse)
        '       If Ris.ICan Then
        CreaCommessa()
        '      Else
        ''     If Ris.IsLockedByAnother Then
        '   MessageBox.Show("La funzione è già bloccata sulla postazione " & Ris.LockedBy.Postazione.ToUpper & " da '" & Ris.LockedBy.Utente.Login & "'")
        '  Else
        ' MessageBox.Show("La funzione non è stata bloccata. Utilizzare il FunctionLock nel menù principale")
        'End If
        'End If
    End Sub

    Private Sub EsportaSelezionati()

        If DGOrdini.SelectedRows.Count Then

            FormerLib.FormerHelper.File.CreateLongPath(FormerPath.PathGanging)
            Dim PathSel As String = FormerPath.PathGanging & FormerHelper.File.GetNomeFileTemp(".job")
            Dim L As New List(Of Ordine)
            'If dlgFolder.ShowDialog() = DialogResult.OK Then
            'Dim PathSel As String = dlgFolder.SelectedPath
            For Each r As DataGridViewRow In DGOrdini.SelectedRows
                Dim O As Ordine = r.DataBoundItem
                L.Add(O)
                'Dim PathTipoCarta As String = PathSel & "\" & O.ListinoBase.TipoCarta.Tipologia & "\"
                'FormerHelper.File.CreateLongPath(PathTipoCarta)

                'cancellare tutti i file che trovo ?

                'For Each Sorg As FileSorgente In O.ListaSorgenti
                'Dim PathDest As String = PathTipoCarta & FormerLib.FormerHelper.File.EstraiNomeFile(Sorg.FilePath)
                'MgrIO.FileCopia(Me.ParentFormEx, Sorg.FilePath, PathDest)
                'Next
            Next

            'qui controllo se i file sono locckati

            Dim check As RisFunctionICan = MgrOrderLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, L)

            If check.ICan Then
                'qui li devo loccare

                MgrOrderLock.Lock(PostazioneCorrente.UtenteConnesso.IdUt, L, enFunctionLock.CreazioneCommesseFromGanging)

                AnnullaEstrazioneToolStripMenuItem.Enabled = True

                Dim BufferJob As String = MgrGanging.GetJobBufferFromOrders(L)

                Using w As New StreamWriter(PathSel)
                    w.Write(BufferJob)
                End Using

                Dim PathPreps8 As String = FormerConfig.FormerPath.PathPreps8

                If PathPreps8 = "\" Then
                    'qui provo a farlo 
                    dlgFolder.SelectedPath = "C:\"
                    dlgFolder.Description = "Seleziona la cartella dove si trova il file eseguibile di Preps8 (Preps8.exe)"

                    If dlgFolder.ShowDialog() = DialogResult.OK Then
                        Dim Path As String = dlgFolder.SelectedPath & "\preps8.exe"

                        If File.Exists(Path) Then
                            PathPreps8 = Path
                            FormerConfig.FConfiguration.SaveValueToLocalSettings("Path.Preps8", Path)
                        Else
                            MessageBox.Show("Impossibile trovare il file eseguibile Preps8.exe nel path specificato")
                        End If

                    End If

                End If

                If PathPreps8 = "\" Then
                    FormerHelper.File.ShellExtended(FormerPath.PathGanging)
                Else
                    FormerHelper.File.ShellExtended(PathPreps8, PathSel)
                End If
            Else
                MessageBox.Show(MgrOrderLock.GetMessageLocked(check))
            End If

            'End If
        Else
            MessageBox.Show("Selezionare almeno un ordine")
        End If

    End Sub

    Private Sub CreaCommessaFromJob()

        ParentFormEx.Sottofondo()

        Using f As New frmCommessaFromJob
            f.Carica()
        End Using

        ParentFormEx.Sottofondo()

    End Sub

    Private Sub DaFileJOBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaFileJOBToolStripMenuItem.Click
        'Dim Ris As FunctionICanRis = FormerLock.ICan(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.CreazioneCommesse)
        'If Ris.ICan Then
        CreaCommessaFromJob()
        ' Else
        'If Ris.IsLockedByAnother Then
        'MessageBox.Show("La funzione è già bloccata sulla postazione " & Ris.LockedBy.Postazione.ToUpper & " da '" & Ris.LockedBy.Utente.Login & "'")
        'Else
        'MessageBox.Show("La funzione non è stata bloccata. Utilizzare il FunctionLock nel menù principale")
        'End If
        'End If
    End Sub

    Private Sub DaGangingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaGangingToolStripMenuItem.Click
        EsportaSelezionati()
    End Sub

    Private Sub AnnullaEstrazioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnullaEstrazioneToolStripMenuItem.Click

        If MgrOrderLock.HoOrdiniLocked(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.CreazioneCommesseFromGanging).Count Then
            If MessageBox.Show("Vuoi annullare l'estrazione degli ordini che avevi estratto?", "Estrazione ordini", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MgrOrderLock.UnlockAll(PostazioneCorrente.UtenteConnesso.IdUt, enFunctionLock.CreazioneCommesseFromGanging)
                AnnullaEstrazioneToolStripMenuItem.Enabled = False
            End If
        Else
            Beep() 'qui non dovrebbe mai entrare
        End If
    End Sub

    Private Sub MostraModelliCommessaCompatibiliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostraModelliCommessaCompatibiliToolStripMenuItem.Click

        'qui in base a tutti gli ordini selezionati faccio il calcolo dei modelli commessa compatibili
        If grigliaSelezionata.SelectedRows.Count Then

            '            ParentFormEx.Sottofondo()
            '           Dim f As New frmPostit
            '          f.Carica(, , IdOrdSel)
            '         ParentFormEx.Sottofondo()

            Using O As New Ordine
                O.Read(IdOrdSel)
                RaiseEvent SelezionatoOrdinePerModello(O.ListinoBase.IdFormProd, O.ListinoBase.IdColoreStampa)
            End Using

        End If


    End Sub

    Private Sub ToolStripModificaDataConsegna_Click(sender As Object, e As EventArgs) Handles ToolStripModificaDataConsegna.Click
        If grigliaSelezionata.SelectedRows.Count Then
            Dim Dr As DataGridViewRow = grigliaSelezionata.SelectedRows(0)
            Dim o As Ordine = Dr.DataBoundItem

            MgrOrdini.GarantisciDataConsegna(O, ParentFormEx)

            'Dim stato As Integer = o.Stato
            'IdOrdSel = o.IdOrd
            'If o.ConsegnaAssociata.HaUnPagamentoAnticipato = False Then
            '    If o.ConsegnaAssociata.HaDocumentiFiscali = False Then
            '        If stato <> enStatoOrdine.InConsegna Then
            '            Dim frmMod As New frmOrdineModificaImporti
            '            ParentFormEx.Sottofondo()

            '            frmMod.Carica(IdOrdSel)

            '            ParentFormEx.Sottofondo()
            '            frmMod = Nothing
            '        Else
            '            MessageBox.Show("L'ordine non può essere modificato perchè è gia stato messo in consegna!", "Modifica ordine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        End If
            '    Else
            '        MessageBox.Show("L'ordine non può essere modificato perchè associato a una consegna con un Documento Fiscale", "Modifica ordine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    End If
            'Else
            '    MessageBox.Show("L'ordine non può essere modificato perchè associato a una consegna con un pagamento", "Modifica ordine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
        End If
    End Sub

    Private Sub ToolStripModificaOrdine_Click(sender As Object, e As EventArgs) Handles ToolStripModificaOrdine.Click

        Dim x As New MouseEventArgs(MouseButtons.Left, 1, MousePosition.X, MousePosition.Y, 0)
        'x.Button = Button.Left

        RiapriOrdine(x)
    End Sub

    Private Sub ToolstripRiapriCartellaSorgenti_Click(sender As Object, e As EventArgs) Handles toolstripRiapriCartellaSorgenti.Click
        If grigliaSelezionata.SelectedRows.Count Then
            Dim riga As DataGridViewRow = grigliaSelezionata.SelectedRows(0)
            Dim OrdineSel As Ordine = riga.DataBoundItem
            MgrOrdini.RiapriCartellaSorgenti(OrdineSel)
        End If
    End Sub

    Private Sub ApriSituazioneClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriSituazioneClienteToolStripMenuItem.Click
        If grigliaSelezionata.SelectedRows.Count Then
            Dim riga As DataGridViewRow = grigliaSelezionata.SelectedRows(0)
            Dim OrdineSel As Ordine = riga.DataBoundItem
            FormPrincipale.SelezionaClienteDaChiamata(OrdineSel.IdRub)
        End If
    End Sub
End Class
