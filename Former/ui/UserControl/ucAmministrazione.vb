Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Public Class ucAmministrazione
    Inherits ucFormerUserControl

    Private _IdRub As Integer = 0
    Private _DaIncassare As Decimal = 0
    Private _Incassati As Decimal = 0
    Private _TotaleDoc As Decimal = 0
    Private _Scaduti As Decimal = 0
    Private _TotProntoStampa As Decimal = 0
    Private Rigasel As Integer = 0
    Private ControlloAttivo As Control

    'Private Sub CaricaMerceUscita()
    '    Cursor = Cursors.WaitCursor
    '    CaricaOrd(, , , chkLastWeek.Checked)

    '    Cursor = Cursors.Default
    'End Sub

    Public Property IdRub() As Integer
        Get
            Return _IdRub
        End Get
        Set(ByVal value As Integer)
            _IdRub = value
        End Set
    End Property

    Public Sub Carica()
        Try
            If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then
                UcContab.IdRub = _IdRub
                'UcRubrica1.Carica()

                CaricaClientiRiepilogo(, _IdRub)

                If _IdRub Then

                    TabMain.TabPages.Remove(tpRiepilogo)
                    TabMain.TabPages.Remove(tpRubrica)
                    TabMain.TabPages.Remove(tpDashboard)

                    'lnkEmailContab.Enabled = False
                    'lnkStampaSitCont.Enabled = False
                End If
            End If
        Catch ex As Exception

        End Try



        ' If LUNA.LunaContext.TotConnAttive Then

        ' End If
    End Sub

    'Private Sub lnkNewFatIn_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    ParentFormerForm.Sottofondo 

    '    Dim x As New frmFatturaAcq

    '    x.Carica()

    '    x = Nothing

    '    ParentFormerForm.Sottofondo 
    'End Sub

    'Public Sub EmettiDocumento()
    '    'Dim x As System.Drawing.Point = MousePosition
    '    Dim x As New System.Drawing.Point(lnkNewFatt.Left, lnkNewFatt.Top + 25)

    '    'btnNuovoCliente.ContextMenu = menuNuovo.
    '    mnuDoc.Show(PointToScreen(x))
    'End Sub
    'Private Sub EmettiDocumento(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    EmettiDocumento()

    'End Sub

    'Public Sub EmettiDocumentoEntrata()
    '    'Dim x As System.Drawing.Point = MousePosition
    '    Dim x As New System.Drawing.Point(lnkRegSpesa.Left, lnkRegSpesa.Top + 25)

    '    'btnNuovoCliente.ContextMenu = menuNuovo.
    '    mnuDocEntrata.Show(PointToScreen(x))
    'End Sub

    Private Sub UcPagamenti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lnkFatturaPagata_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)



    End Sub

    Private Sub UcContab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UcContab.Load

    End Sub

    'Private Sub lnkRegSpesa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    EmettiDocumentoEntrata()

    'End Sub

    Private Sub FatturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EmettiDoc(enTipoDocumento.Fattura)
    End Sub

    Private Sub FatturaRiepilogativaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'qui fattura riepilogativa
        EmettiDoc(enTipoDocumento.FatturaRiepilogativa)
    End Sub

    Private Sub RegistraDoc(ByVal TipoDoc As enTipoDocumento)
        ParentFormEx.Sottofondo()

        If TipoDoc <> enTipoDocumento.FatturaRiepilogativa Then
            Using f As New frmContabilitaCosto
                f.Carica(,, TipoDoc)
            End Using
        Else
            Using f As New frmContabilitaFatturaRiepilogativaCosto
                f.Carica()
            End Using
        End If

        ParentFormEx.Sottofondo()

        'If TipoDoc <> enTipoDocumento.FatturaRiepilogativa Then
        '    Dim x As New frmContabilitaEmissioneDocumenti
        '    If x.Carica(TipoDoc) Then
        '        'ParentFormerForm.Sottofondo 
        '        'UcContab.MostraDati(UcContab.rdoEntrata.Checked)
        '        'Else
        '        '   ParentFormerForm.Sottofondo 
        '    End If
        '    x = Nothing
        'Else
        '    Dim x As New frmContabilitaFatturaRiepilogativaRicavo
        '    If x.Carica() Then

        '        'UcContab.MostraDati(UcContab.rdoEntrata.Checked)
        '        'Else
        '        'ParentFormerForm.Sottofondo 
        '    End If

        '    x = Nothing
        'End If
        'ParentFormEx.Sottofondo()
    End Sub


    Private Sub EmettiDoc(ByVal TipoDoc As enTipoDocumento)
        'ParentFormEx.Sottofondo()
        'If TipoDoc <> enTipoDocumento.FatturaRiepilogativa Then
        '    Dim x As New frmContabilitaEmissioneDocumenti
        '    If x.Carica(TipoDoc) Then
        '        'ParentFormerForm.Sottofondo 
        '        'UcContab.MostraDati(UcContab.rdoEntrata.Checked)
        '        'Else
        '        '   ParentFormerForm.Sottofondo 
        '    End If
        '    x = Nothing

        'Else
        '    Dim x As New frmContabilitaFatturaRiepilogativaRicavo
        '    If x.Carica() Then

        '        'UcContab.MostraDati(UcContab.rdoEntrata.Checked)
        '        'Else
        '        'ParentFormerForm.Sottofondo 
        '    End If

        '    x = Nothing
        'End If
        'ParentFormEx.Sottofondo()

    End Sub

    Private Sub DDTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EmettiDoc(enTipoDocumento.DDT)
    End Sub

    Private Sub PreventivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EmettiDoc(enTipoDocumento.Preventivo)
    End Sub

    Private Sub menuVoce_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

    End Sub

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        'chkOnlyInCons.BackColor = ColoreStatoOrdineInConsegna

        'If LUNA.LunaContext.TotConnAttive Then
        '    TabMain.TabPages.Remove(tpDocumentiFiscali)
        '    '  TabMain.TabPages.Remove(tpMerceUscita)
        '    ' TabMain.TabPages.Remove(tpMerceDaSpedire)
        'End If

        UcAmministrazioneDashboard.Carica()
        UcAmministrazionePagamenti.TipoVoceContabile = enTipoVoceContab.VoceVendita

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        CaricaClientiRiepilogo()
    End Sub

    Private Sub CaricaClientiRiepilogo(Optional ByVal Iniziale As String = "", Optional ByVal IdRub As Integer = 0, Optional ByVal TestoLibero As String = "")

        Using x As New VociRubricaDAO

            Dim lst As List(Of VoceRubrica) = x.ListaCombo(enTipoRubrica.Tutto, False, , Iniziale, IdRub, TestoLibero)

            Dim nd As TreeNode

            tvClienti.Nodes.Clear()

            For Each R As VoceRubrica In lst
                nd = tvClienti.Nodes.Add("C" & R.IdRub, R.Nominativo, 0, 0)
                nd.Nodes.Add("A" & R.IdRub, "Anagrafica " & " ID: " & R.IdRub, 4, 4)
                nd.Nodes.Add("O" & R.IdRub, "Ordini", 1, 1)
                'nd.Nodes.Add("I" & R.IdRub, "Riepilogo Ordini", 1, 1)
                nd.Nodes.Add("D" & R.IdRub, "Documenti", 2, 2)
                nd.Nodes.Add("S" & R.IdRub, "Situazione Contabile", 5, 5)
                nd.Nodes.Add("P" & R.IdRub, "Pagamenti", 3, 3)
                'nd.Nodes("P" & dr("idrub").ToString).EnsureVisible()
            Next

        End Using

    End Sub

    Private Sub tvClienti_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvClienti.NodeMouseClick
        'qui ho il nuovo nodo selezionato, in base alla chiave capisco di cosa si tratta e carico i dati nel lato destro

        Cursor.Current = Cursors.WaitCursor

        If Not ControlloAttivo Is Nothing Then
            ControlloAttivo.Dispose()
            ControlloAttivo = Nothing
        End If
        'ControlloAttivo.Dispose()

        Dim TipoNodo As String = e.Node.Name.Substring(0, 1)
        Dim IdCliente As Integer = e.Node.Name.Substring(1)
        Select Case TipoNodo
            Case "C" ' Cliente
                'se è tasto destro lancio l'anagrafica 
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Dim OggRif As New VoceRubrica, Ris As Integer = 0

                    OggRif.Read(IdCliente)

                    Dim frmRif As New frmVoceRubrica
                    ParentFormEx.Sottofondo()
                    Ris = frmRif.Carica(OggRif)
                    ParentFormEx.Sottofondo()
                    OggRif = Nothing
                End If
            Case "A" 'ANAGRAFICA
                Dim OggRif As New VoceRubrica, Ris As Integer = 0

                OggRif.Read(IdCliente)

                Dim frmRif As New frmVoceRubrica
                ParentFormEx.Sottofondo()
                Ris = frmRif.Carica(OggRif)
                ParentFormEx.Sottofondo()
                OggRif = Nothing

            Case "D" 'Documenti
                Dim Contab As New ucDocumentiFiscali
                Contab.Parent = SplitContainerRiepilogo.Panel2
                Contab.Dock = DockStyle.Fill
                Contab.IdRub = IdCliente
                'Contab.MostraDati(False)
                Contab.Show()
                ControlloAttivo = Contab


            Case "S" ' Situazione contabile
                Dim Situaz As New ucSituazPagam
                Situaz.Parent = SplitContainerRiepilogo.Panel2
                Situaz.Dock = DockStyle.Fill
                Situaz.IdRub = IdCliente
                'Situaz.MostraSituaz()
                Situaz.Show()
                ControlloAttivo = Situaz
            Case "O" 'Ordini
                Dim Ordini As New ucOrdini
                Ordini.Parent = SplitContainerRiepilogo.Panel2
                Ordini.Dock = DockStyle.Fill
                Ordini.IdRub = IdCliente
                Ordini.Carica()
                Ordini.Show()
                ControlloAttivo = Ordini

            Case "I" 'Ordini ADMIN
                Dim Ordini As New ucOrdiniAdmin
                Ordini.Parent = SplitContainerRiepilogo.Panel2
                Ordini.Dock = DockStyle.Fill
                Ordini.IdRub = IdCliente
                Ordini.Carica()
                Ordini.Show()
                ControlloAttivo = Ordini

            Case "P" 'Pagamenti
                Dim pagam As New ucAmministrazionePagamenti
                pagam.Parent = SplitContainerRiepilogo.Panel2
                pagam.Dock = DockStyle.Fill
                pagam.IdRub = IdCliente
                pagam.Show()
                pagam.MostraDati(0)
                ControlloAttivo = pagam
        End Select

        Cursor.Current = Cursors.Default

    End Sub
    Public Sub MostraSituaz()

    End Sub

    Private Sub tvClienti_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvClienti.AfterSelect

    End Sub

    Private Sub TB_123_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_123.Click, TB_A.Click, TB_B.Click, TB_C.Click, TB_D.Click, TB_E.Click, TB_F.Click, TB_G.Click, TB_H.Click, TB_I.Click, TB_J.Click, TB_K.Click, TB_L.Click, TB_M.Click, TB_N.Click, TB_O.Click, TB_P.Click, TB_Q.Click, TB_R.Click, TB_S.Click, TB_T.Click, TB_U.Click, TB_V.Click, TB_W.Click, TB_X.Click, TB_Y.Click, TB_Z.Click
        CaricaClientiRiepilogo(sender.text)
    End Sub
    'Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ParentFormEx.Sottofondo()

    '    Dim Contab As New frmContabilitaRicavo
    '    Contab.Carica(, , _IdRub, enTipoDocumento.Fattura)

    '    ParentFormEx.Sottofondo()

    'End Sub

    'Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ParentFormEx.Sottofondo()

    '    Dim Contab As New frmContabilitaRicavo
    '    Contab.Carica(, , _IdRub, enTipoDocumento.DDT)

    '    ParentFormEx.Sottofondo()
    'End Sub

    Private Sub txtCerca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCerca.KeyPress

        If e.KeyChar = vbCr Then

            CaricaClientiRiepilogo(, , txtCerca.Text)
        End If
    End Sub

    Private Sub txtCerca_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCerca.MouseClick
        If txtCerca.Text = "{cerca cliente}" Then txtCerca.Text = ""
    End Sub

    Private Sub txtCerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCerca.TextChanged

    End Sub

    Private Sub lnkCerca_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked
        CaricaClientiRiepilogo(, , txtCerca.Text)
    End Sub

    'Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    Dim x As System.Drawing.Point = MousePosition
    '    mnuNuovo.Show(x)

    'End Sub

    Private Sub ClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NewCliente()
    End Sub

    Private Sub NewCliente()

        Using frmRif As New frmVoceRubrica
            Using ObjRif As New VoceRubrica
                Dim Ris As Integer = 0
                ObjRif.Tipo = enTipoRubrica.Cliente

                ParentFormEx.Sottofondo()
                Ris = frmRif.Carica(ObjRif)
                ParentFormEx.Sottofondo()
            End Using
        End Using
    End Sub
    Private Sub NewRivenditore()

        Using frmRif As New frmVoceRubrica
            Using ObjRif As New VoceRubrica
                Dim Ris As Integer = 0
                ObjRif.Tipo = enTipoRubrica.Rivenditore
                ParentFormEx.Sottofondo()
                Ris = frmRif.Carica(ObjRif)
                ParentFormEx.Sottofondo()
                'If Ris Then MostraDati()
            End Using
        End Using
    End Sub

    'Private Sub NewAgente()

    '    Using frmRif As New frmVoceRubrica
    '        Using ObjRif As New VoceRubrica
    '            Dim Ris As Integer = 0
    '            ObjRif.Tipo = enTipoRubrica.Agente
    '            ParentFormEx.Sottofondo()
    '            Ris = frmRif.Carica(ObjRif)
    '            ParentFormEx.Sottofondo()
    '            ' If Ris Then MostraDati()
    '        End Using
    '    End Using

    'End Sub

    'Private Sub FornitoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    NewFornitore()
    'End Sub

    'Private Sub NewFornitore()
    '    Using frmRif As New frmVoceRubrica
    '        Using ObjRif As New VoceRubrica
    '            Dim Ris As Integer = 0
    '            ObjRif.Tipo = enTipoRubrica.Fornitore
    '            ParentFormEx.Sottofondo()
    '            Ris = frmRif.Carica(ObjRif)
    '            ParentFormEx.Sottofondo()
    '        End Using
    '    End Using
    'End Sub

    Private Sub EmailSituazioneContabile()

        If MessageBox.Show("Confermi l'invio delle email con la situazione contabile ai clienti?", "Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Cursor.Current = Cursors.WaitCursor
            'qui invio le mail 
            Dim I As Integer = 0

            EffettuaCalcoloPagam(True, I)

            Cursor.Current = Cursors.Default

            MessageBox.Show("Email inviate correttamente: " & I, "Former", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub lnkEmailContab_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)


    End Sub

    Private Function EffettuaCalcoloPagam(ByVal InviaMail As Boolean,
                                          ByRef I As Integer) As String
        Dim BufferTotale As String = ""
        Using RubDAO As New VociRubricaDAO
            Dim Dr As DataRow

            Dim dt As DataTable = RubDAO.ListaContabEmail()

            For Each Dr In dt.Rows

                Dim Rub As New VoceRubrica
                Rub.Read(Dr(0))
                Dim Titolo As String = "Situazione contabile aggiornata " & Rub.RagSocNome
                Dim Testo As String = "Gentile Cliente, <br><br>al fine di agevolare le operazioni amministrative Le inviamo la sua situazione contabile aggiornata. <br><br> Cordiali saluti, <br><br> <b>Amministrazione Former</b><br>06.30884518<br><A HREF=""mailto:amministrazione@tipografiaformer.com"">amministrazione@tipografiaformer.com</a><br><br>"
                Dim IndDest As String = Rub.Email
                'IndDest = "soft@tipografiaformer.it"

                Testo &= Rub.SituazioneContabile(IIf(InviaMail, False, True))

                If IndDest.Length Then
                    If InviaMail Then
                        FormerHelper.Mail.InviaMail(Titolo, Testo, IndDest)
                    End If

                    Dim em As New Email
                    em.IdMarketing = 0
                    em.IdRubDest = Rub.IdRub
                    em.Quando = Now
                    em.Testo = Testo
                    em.Titolo = Titolo
                    em.Save()
                Else
                    'avvisare quelli senza email
                End If

                BufferTotale &= Rub.SituazioneContabile & "<hr>"

                I += 1
            Next
        End Using
        Return BufferTotale

    End Function

    Private Sub StampaSituazioneContabile()

        If MessageBox.Show("Vuoi visualizzare la situazione contabile globale?", "Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Cursor.Current = Cursors.WaitCursor
            'qui invio le mail 
            Dim I As Integer = 0

            Dim Buffertot As String = EffettuaCalcoloPagam(False, I)

            Cursor.Current = Cursors.Default
            ParentFormEx.Sottofondo()
            StampaBuffer(Buffertot)
            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub lnkStampaSitCont_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)


    End Sub

    Private Sub RivenditoreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        NewRivenditore()
    End Sub

    Private Sub AgenteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        'NewAgente()

    End Sub

    'Private Sub btnRefresh4_Click(sender As Object, e As EventArgs)
    '    CaricaMerceUscita()
    'End Sub

    'Private Sub CaricaOrd(Optional ByVal Iniziale As String = "", _
    '                      Optional ByVal IdRub As Integer = 0, _
    '                      Optional ByVal TestoLibero As String = "", _
    '                      Optional ByVal LastWeek As Boolean = True)

    '    Using mgr As New ConsegneRicercaDAO
    '        Dim LstM As New List(Of ConsegnaRicerca)
    '        Dim ListaStati As String = enStatoOrdine.UscitoMagazzino
    '        'If chkImballaggio.Checked Then ListaStati &= "," & enStatoOrdine.ImballaggioCorriere
    '        LstM = mgr.ListaMerceUscitaMagazzino(-1, 0, , , ListaStati, , , , , , LastWeek)
    '        LstM.Sort(AddressOf Comparer)
    '        tvMerceUscita.Nodes.Clear()

    '        For Each c As ConsegnaRicerca In LstM

    '            Dim ChiaveData As String = "D" & c.DataEffConsegna.ToString("ddMMyyyy")
    '            Dim NodoData As TreeNode = tvMerceUscita.Nodes(ChiaveData)
    '            If NodoData Is Nothing Then
    '                NodoData = tvMerceUscita.Nodes.Add(ChiaveData, c.DataEffConsegna.ToString("dd MMMM yyyy"), 7, 7)
    '                'NodoCorr.Expand()
    '            End If
    '            Dim ChiaveCorriere As String = "C" & c.IdCorr
    '            Dim ChiaveRubrica As String
    '            If c.IdCorr <> 1 And c.IdCorr <> 2 Then
    '                ChiaveRubrica = "S" & c.IdCons
    '            Else
    '                ChiaveRubrica = "R" & c.IdRub
    '            End If

    '            Dim ChiaveOrdine As String = "O" & c.IdOrd

    '            Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
    '            If NodoCorr Is Nothing Then
    '                NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, c.CorriereNome, 6, 6)
    '                'NodoCorr.Expand()
    '            End If
    '            Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
    '            If NodoRub Is Nothing Then
    '                Dim DescrNodo As String = c.RagSoc
    '                If c.IdCorr <> 1 And c.IdCorr <> 2 Then
    '                    DescrNodo &= " - Peso: " & c.Peso & ", Colli: " & c.NumColli
    '                End If
    '                NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, DescrNodo, 10, 10)
    '                'NodoRub.Expand()
    '                'NodoRub.EnsureVisible()
    '            End If
    '            Dim Icona As Integer = 9

    '            If c.Inserito Then Icona = 8

    '            Dim nodoOrd As TreeNode = NodoRub.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
    '            nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
    '            nodoOrd.Tag = c
    '            If c.Giorno.Date = Now.Date Then NodoData.Expand()
    '            NodoCorr.Expand()
    '            'NodoRub.Expand()
    '        Next
    '    End Using
    'End Sub
    Private Function Comparer(ByVal x As ConsegnaRicerca, ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = y.DataEffConsegna.CompareTo(x.DataEffConsegna)
        If result = 0 Then result = x.RagSoc.CompareTo(y.RagSoc)

        Return result
    End Function

    'Private Sub btnDocFisc_Click(sender As Object, e As EventArgs)

    '    If Not tvMerceUscita.SelectedNode Is Nothing Then
    '        Dim Node As TreeNode = tvMerceUscita.SelectedNode
    '        Dim Peso As Single = 0
    '        Dim IdCorr As Integer = 0
    '        Dim NumColli As Integer = 0
    '        Dim ListaId As String = ""
    '        If Node.Name.StartsWith("S") Then
    '            Dim IdCons As Integer = Node.Name.Substring(1)
    '            Dim c As New ConsegnaProgrammata
    '            c.Read(IdCons)
    '            Peso = c.Peso
    '            IdCorr = c.IdCorr
    '            NumColli = c.NumColli
    '            Dim Nd As TreeNode
    '            ' Dim NodoPadre As TreeNode
    '            For Each Nd In Node.Nodes

    '                ListaId &= Nd.Name.Substring(1) & ","
    '                'NodoPadre = Nd.Parent
    '            Next
    '        ElseIf Node.Name.StartsWith("R") Then
    '            IdCorr = Node.Parent.Name.Substring(1)
    '            For Each n As TreeNode In Node.Nodes
    '                Dim O As New Ordine
    '                O.Read(n.Name.Substring(1))
    '                NumColli += O.NumeroRealeColli
    '                Dim P As New Prodotto
    '                P.Read(O.IdProd)
    '                Peso += P.PesoComplessivo
    '                ListaId &= n.Name.Substring(1) & ","
    '            Next
    '        End If
    '        If ListaId.Length Then
    '            ParentFormerForm.Sottofondo 

    '            Dim x As New frmEmissioneDocumenti

    '            x.Carica(, , ListaId, NumColli, Peso, IdCorr)

    '            x = Nothing

    '            ParentFormerForm.Sottofondo 
    '        End If
    '    End If

    'End Sub

    'Private Sub btnAggiornaMerceSpedire_Click(sender As Object, e As EventArgs)
    '    CaricaMerceSpedire(rdoGiaImballati.Checked)
    'End Sub

    'Private Sub CaricaMerceSpedire(Optional SoloCompletati As Boolean = False)
    '    Cursor = Cursors.WaitCursor

    '    Using mgr As New ConsegneRicercaDAO
    '        Dim LstM As New List(Of ConsegnaRicerca)
    '        Dim ListaStati As String = ""
    '        If SoloCompletati Then
    '            ListaStati = enStatoOrdine.ProntoRitiro
    '        Else
    '            ListaStati = enStatoOrdine.Registrato & "," & _
    '                            enStatoOrdine.InSospeso & "," & _
    '                            enStatoOrdine.InCodaDiStampa & "," & _
    '                            enStatoOrdine.StampaInizio & "," & _
    '                            enStatoOrdine.StampaFine & "," & _
    '                            enStatoOrdine.FinituraCommessaInizio & "," & _
    '                            enStatoOrdine.FinituraCommessaFine & "," & _
    '                            enStatoOrdine.FinituraProdottoInizio & "," & _
    '                            enStatoOrdine.FinituraProdottoFine & "," & _
    '                            enStatoOrdine.Imballaggio & "," & _
    '                            enStatoOrdine.ImballaggioCorriere
    '        End If
    '        LstM = mgr.Lista(-1, 0, , , ListaStati, , , , , CInt(enCorriere.RitiroCliente) & "," & CInt(enCorriere.TipografiaFormer))
    '        LstM.Sort(AddressOf Comparer)
    '        tvMerceDaSpedire.Nodes.Clear()

    '        For Each c As ConsegnaRicerca In LstM

    '            'Dim ChiaveData As String = "D" & c.Giorno.ToString("ddMMyyyy")
    '            'Dim NodoData As TreeNode = tvClienti.Nodes(ChiaveData)
    '            'If NodoData Is Nothing Then
    '            '    NodoData = tvClienti.Nodes.Add(ChiaveData, c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
    '            '    'NodoCorr.Expand()
    '            'End If
    '            Dim ChiaveCorriere As String = "C" & c.IdCorr
    '            Dim ChiaveRubrica As String = "R" & c.IdRub
    '            Dim ChiaveConsegna As String = "S" & c.IdCons
    '            Dim ChiaveOrdine As String = "O" & c.IdOrd

    '            Dim NodoCorr As TreeNode = tvMerceDaSpedire.Nodes(ChiaveCorriere)
    '            If NodoCorr Is Nothing Then
    '                NodoCorr = tvMerceDaSpedire.Nodes.Add(ChiaveCorriere, c.CorriereNome, 6, 6)
    '                'NodoCorr.Expand()
    '            End If
    '            Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
    '            If NodoRub Is Nothing Then
    '                NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, c.RagSoc, 0, 0)
    '                'NodoRub.Expand()
    '                'NodoRub.EnsureVisible()
    '            End If

    '            Dim NodoCons As TreeNode = NodoRub.Nodes(ChiaveConsegna)
    '            If NodoCons Is Nothing Then
    '                NodoCons = NodoRub.Nodes.Add(ChiaveConsegna, "Consegna programmata del " & c.Giorno & " - Colli: " & c.NumColli & ", Peso: " & c.Peso, 10, 10)
    '                'NodoRub.Expand()
    '                'NodoRub.EnsureVisible()
    '            End If
    '            Dim Icona As Integer = 9
    '            If SoloCompletati Then
    '                Icona = 1
    '            Else
    '                If c.Inserito Then Icona = 8
    '            End If
    '            Dim nodoOrd As TreeNode = NodoCons.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
    '            nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
    '            nodoOrd.Tag = c
    '            'If c.Giorno.Date = Now.Date Then NodoData.Expand()
    '            NodoCorr.Expand()
    '            NodoRub.Expand()
    '        Next
    '    End Using
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub rdoGiaImballati_CheckedChanged(sender As Object, e As EventArgs)
    '    If sender.focused Then CaricaMerceSpedire(rdoGiaImballati.Checked)
    'End Sub

    Private Sub tvMerceDaSpedire_NodeMouseHover(sender As Object, e As TreeNodeMouseHoverEventArgs)
        Dim Node As TreeNode = e.Node
        If Not Node Is Nothing Then
            If Node.Name.StartsWith("O") Then
                Dim IdOrd As Integer = Node.Name.Substring(1)
                Dim Ord As New Ordine
                Ord.Read(IdOrd)

                AnteprimaLavoro.Mostra(Cursor.Position, Ord)
            Else
                AnteprimaLavoro.Nascondi()
            End If
        Else
            AnteprimaLavoro.Nascondi()
        End If
    End Sub

    'Private Sub btnRiapriCons_Click(sender As Object, e As EventArgs)
    '    Dim Node As TreeNode = tvMerceDaSpedire.SelectedNode
    '    If Not Node Is Nothing Then
    '        If Node.Name.StartsWith("S") Then
    '            Dim IdCons As Integer = Node.Name.Substring(1)
    '            ParentFormerForm.Sottofondo 

    '            Dim frm As New frmConsProgrNuova
    '            frm.Carica(IdCons)
    '            frm = Nothing

    '            ParentFormerForm.Sottofondo 
    '        Else
    '            MessageBox.Show("Selezionare una consegna programmata dall'albero!")
    '        End If
    '    Else
    '        MessageBox.Show("Selezionare una consegna programmata dall'albero!")
    '    End If
    'End Sub

    'Private Sub rdoDaImballare_CheckedChanged(sender As Object, e As EventArgs)
    '    If sender.focused Then CaricaMerceSpedire(rdoGiaImballati.Checked)
    'End Sub

    Private Sub btnEmettiDocMerceSpedire_Click(sender As Object, e As EventArgs)

        Beep()

        Exit Sub


        'Dim Node As TreeNode = tvMerceDaSpedire.SelectedNode
        'Dim ListaId As String = ""
        'Dim IdCons As Integer = 0
        'Dim Peso As Single = 0
        'Dim IdCorr As Integer = 0
        'Dim NumColli As Integer = 0
        'Dim IdTipoDoc As Integer = 0

        'If Node.Name.StartsWith("S") Then
        '    IdCons = Node.Name.Substring(1)
        '    Dim c As New ConsegnaProgrammata
        '    c.Read(IdCons)
        '    Peso = c.Peso
        '    IdCorr = c.IdCorr
        '    NumColli = c.NumColli
        '    IdTipoDoc = c.TipoDoc

        '    Dim Nd As TreeNode
        '    'Dim NodoPadre As TreeNode
        '    For Each Nd In Node.Nodes

        '        ListaId &= Nd.Name.Substring(1) & ","
        '        'NodoPadre = Nd.Parent
        '    Next
        'ElseIf Node.Name.StartsWith("R") Then
        '    'qui devo concatenare tutte le consegne e i pacchi 
        '    IdCorr = Node.Parent.Name.Substring(1)
        '    For Each n As TreeNode In Node.Nodes
        '        IdCons = n.Name.Substring(1)
        '        Dim c As New ConsegnaProgrammata
        '        c.Read(IdCons)
        '        Peso += c.Peso
        '        NumColli += c.NumColli

        '        Dim Nd As TreeNode
        '        ' Dim NodoPadre As TreeNode
        '        For Each Nd In n.Nodes

        '            ListaId &= Nd.Name.Substring(1) & ","
        '            'NodoPadre = Nd.Parent
        '        Next
        '    Next
        'End If
        'If ListaId.Length Then
        '    ParentFormerForm.Sottofondo 

        '    Dim x As New frmEmissioneDocumenti

        '    x.Carica(IdTipoDoc, , ListaId, NumColli, Peso, IdCorr, False)

        '    x = Nothing

        '    ParentFormerForm.Sottofondo 
        'End If

    End Sub

    'Private Sub ClienteToolStripMenuItem1_Click(sender As Object, e As EventArgs)
    '    NewCliente()
    'End Sub

    'Private Sub RivenditoreToolStripMenuItem1_Click(sender As Object, e As EventArgs)
    '    NewRivenditore()
    'End Sub

    'Private Sub FornitoreToolStripMenuItem1_Click(sender As Object, e As EventArgs)
    '    NewFornitore()
    'End Sub

    Private Sub AgenteToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        'NewAgente()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub StampaSituazioneContabileToolStripMenuItem_Click(sender As Object, e As EventArgs)

        StampaSituazioneContabile()

    End Sub

    Private Sub StampaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        StampaSituazioneContabile()
    End Sub

    Private Sub InviaTramiteMailToolStripMenuItem_Click(sender As Object, e As EventArgs)
        EmailSituazioneContabile()
    End Sub

    Private Sub EmettiFatturaRiepilogativaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EmettiPreventivoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        RegistraDoc(enTipoDocumento.Preventivo)
    End Sub

    Private Sub EmettiDDTToolStripMenuItem_Click(sender As Object, e As EventArgs)
        RegistraDoc(enTipoDocumento.DDT)
    End Sub

    Private Sub EmettiFatturaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        RegistraDoc(enTipoDocumento.Fattura)
    End Sub

    Private Sub RegistraFatturaRiepilogativaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        RegistraDoc(enTipoDocumento.FatturaRiepilogativa)
    End Sub

    Private Sub DocumentiInEntrataToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs)
        sender.ForeColor = Color.Black
    End Sub

    Private Sub DocumentiInEntrataToolStripMenuItem_DropDownClosed(sender As Object, e As EventArgs)
        sender.ForeColor = Color.White
    End Sub


End Class
