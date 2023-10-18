Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Public Class ucOrdiniGest
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ColoraSfondo(lnkNewCom)
        ' ColoraSfondo(lnkStampa)
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        rdoPre.BackColor = FormerColori.ColoreStatoOrdinePreinserito
        rdoReg.BackColor = FormerColori.ColoreStatoOrdineRegistrato
        rdoSospeso.BackColor = FormerColori.ColoreStatoOrdineInSospeso
    End Sub
    Public IdOrdSel As Integer

    Public Sub Carica()

        CaricaCombo()

    End Sub

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

        Cursor.Current = Cursors.WaitCursor

        Dim Stato As Integer = 0

        If rdoPre.Checked Then
            Stato = enStatoOrdine.Preinserito
        ElseIf rdoReg.Checked Then
            Stato = enStatoOrdine.Registrato
        ElseIf rdoSospeso.Checked Then
            Stato = enStatoOrdine.InSospeso
        ElseIf rdoRifiutato.Checked Then
            Stato = enStatoOrdine.Rifiutato
        End If

        Dim lst As List(Of OrdineRicerca)

        '  If Not cmbCatProd.SelectedValue Is Nothing Then
        Dim Cat As Integer = 0
        If Not tvwCat.SelectedNode Is Nothing Then
            Cat = tvwCat.SelectedNode.Name.Substring(1)
        End If
        Using mgr As New OrdiniDAO
            lst = mgr.Lista(, Stato, _
                      Cat, _
                      True, _
                       , _
                         True, , , , , , , , , True)
        End Using

        DGOrdini.AutoGenerateColumns = False
        DGOrdini.DataSource = lst

        DGOrdini.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGOrdini.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGOrdini.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGOrdini.Columns(6).DefaultCellStyle.Format = "0.00"
        DGOrdini.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGOrdini.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGOrdini.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        lblNumRis.Text = lst.Count

        RaiseEvent OrdineSelezionato()

        '   End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub txtCerca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = vbCr Then

            AvviaRicerca()

        Else
            ControlloNumerico(sender, e, True)
        End If


    End Sub

    Public Event OrdineSelezionato()

    'Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
    '    Sottofondo(Me.ParentForm)
    '    Dim Titolo As String = ""

    '        Titolo = "Lista Ordini"

    '    StampaGlobale(Titolo, DgOrdini)
    '    Sottofondo(Me.ParentForm)
    'End Sub

    Private Sub DgOrdini_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGOrdini.CellMouseDoubleClick

        If e.Button = Windows.Forms.MouseButtons.Left Then


            'riapro l'ordine in modifica
            Dim rig As DataGridViewRow
            Dim RigaSel As Integer = e.RowIndex

            If RigaSel <> -1 Then
                rig = DGOrdini.Rows(RigaSel)
                rig.Selected = True
                DGOrdini.Select()

                Dim O As Ordine = DGOrdini.SelectedRows(0).DataBoundItem
                IdOrdSel = O.IdOrd

                Dim frmRif As New frmOrdine

                Dim Ris As Integer = 0

                Sottofondo(Me.ParentForm)
                Ris = frmRif.Carica(IdOrdSel)
                Sottofondo(Me.ParentForm)
                If Ris Then AvviaRicerca()
                frmRif.Dispose()

            End If

        End If
    End Sub

    'Private Sub lnkOrdMail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    '    Sottofondo(Me.ParentForm)
    '    Dim x As New frmCheckMail
    '    Dim Ris As Integer

    '    Ris = x.Carica()

    '    If Ris Then AvviaRicerca()

    '    x = Nothing
    '    Sottofondo(Me.ParentForm)

    'End Sub

    Private Sub DgOrdini_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGOrdini.RowPostPaint

        Dim x As DataGridViewRow = DGOrdini.Rows.Item(e.RowIndex)
        Dim O As OrdineRicerca = x.DataBoundItem

        x.Cells(2).Style.BackColor = O.StatoColore
        x.Cells(2).Style.SelectionBackColor = O.StatoColore

        Dim DiffGiorni As Integer = DateDiff(DateInterval.Day, Now.Date, O.DataConsProgr)

        If DiffGiorni < 3 Then
            x.Cells(3).Style.BackColor = Color.Red
            x.Cells(3).Style.SelectionBackColor = Color.Red
        ElseIf DiffGiorni >= 3 And DiffGiorni < 6 Then
            x.Cells(3).Style.BackColor = Color.LightGray
            x.Cells(3).Style.SelectionBackColor = Color.LightGray
        Else
            x.Cells(3).Style.BackColor = Color.LightGreen
            x.Cells(3).Style.SelectionBackColor = Color.LightGreen
        End If

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

    Private Sub CalcolaSpaziUsati()
        Dim TotSpaziUsati As Integer = 0

        Dim rig As DataGridViewRow

        For Each rig In DGOrdini.SelectedRows
            Dim o As OrdineRicerca = rig.DataBoundItem
            TotSpaziUsati += o.NumSpazi
        Next

        lblNumSpaziUsati.Text = TotSpaziUsati

        If lblNumSpaziUsati.Text = lblNumSpaziDisp.Text Then
            lblNumSpaziUsati.BackColor = Color.Green
        Else
            lblNumSpaziUsati.BackColor = Color.Red
        End If
    End Sub

    Private Sub DgOrdini_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGOrdini.SelectionChanged

        CalcolaSpaziUsati()
        Dim Rig As DataGridViewRow

        If DGOrdini.SelectedRows.Count Then

            Rig = DGOrdini.SelectedRows(0)

            Dim O As Ordine = Rig.DataBoundItem

            If O.IdOrd <> IdOrdSel Then
                Rig.Selected = True
                DGOrdini.Select()

                IdOrdSel = O.IdOrd

                RaiseEvent OrdineSelezionato()

            End If

        End If

    End Sub


    Private Sub rdoPre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPre.CheckedChanged, rdoReg.CheckedChanged, rdoSospeso.CheckedChanged
        If sender.focused Then
            'CaricaGruppi()
            lnkNewCom.Enabled = rdoReg.Checked
            AvviaRicerca()
        End If
    End Sub

    Private Sub cmbCatProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If sender.focused Then AvviaRicerca()
    End Sub

    Private Sub lnkNewCom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNewCom.LinkClicked

        Dim ListaIdOrd As String = ""
        ListaIdOrd = CreaListaId()

        If ListaIdOrd.Length Then


            Dim Alert As String = "", Dr As DataGridViewRow
            For Each Dr In DGOrdini.SelectedRows
                Dim o As Ordine = Dr.DataBoundItem
                Dim cp As ConsegnaProgrammata = Nothing
                Using mgr As New ConsegneProgrammateDAO
                    cp = mgr.ReadByIdOrd(o.IdOrd)
                End Using
                If cp Is Nothing Then
                    Alert &= o.IdOrd & ", "
                End If
            Next
            Alert = Alert.TrimEnd(", ")

            If Alert.Length = 0 Then
                'creo una commessa partendo dagli ordini selezionati
                Sottofondo(Me.ParentForm)

                Dim x As New frmCommessa, Ris As Integer = 0
                Ris = x.Carica(, ListaIdOrd, cmbTipoCom.SelectedItem.idtipocom, cmbModelloCommessa.SelectedValue)
                x = Nothing

                Sottofondo(Me.ParentForm)

                If Ris Then
                    CaricaGruppi()
                    AvviaRicerca()
                End If
            Else
                MessageBox.Show("Per gli ordini " & Alert & " non è ancora stata programmata la consegna, impossibile creare la commessa!", , MessageBoxButtons.OK, MessageBoxIcon.Warning)

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

    Private Sub cmbTipoCom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoCom.SelectedIndexChanged

        'mi prendo il numero di spazi disponibili

        Dim c As TipoCommessa

        c = cmbTipoCom.SelectedItem
        'Dim com As New TipoCommessa

        ' lblNumSpaziDisp.Text = c.NumSpazi
        If Not c Is Nothing Then CaricaModelliCommessa(c.IdCatModelli)

        'com = Nothing
    End Sub

    Private Sub CaricaModelliCommessa(IdCatModelli As Integer)
        Using mgr As New ModelliCommessaDAO
            cmbModelloCommessa.DataSource = mgr.FindAll("Nome", New LUNA.LunaSearchParameter("IdCatModello", IdCatModelli))
            cmbModelloCommessa.DisplayMember = "Text"
            cmbModelloCommessa.ValueMember = "Id"
        End Using

    End Sub

    Private Sub DgOrdini_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGOrdini.CellMouseClick
        If DGOrdini.SelectedRows.Count Then

            Dim Dr As DataGridViewRow

            Dr = DGOrdini.SelectedRows(0)

            If Not Dr Is Nothing Then
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Dim x As System.Drawing.Point = MousePosition
                    Dim O As Ordine = Dr.DataBoundItem

                    Dr.Selected = True
                    If IdOrdSel <> O.IdOrd Then
                        IdOrdSel = O.IdOrd
                        RaiseEvent OrdineSelezionato()
                    End If

                    MenuOrd.Show(x)

                End If

            End If
        End If
    End Sub

    Private Sub mnuInviaMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInviaMail.Click
        InviaMail()
    End Sub

    Private Sub InviaMail()

        If DgOrdini.SelectedRows.Count Then

            Dim Dr As DataGridViewRow = DgOrdini.SelectedRows(0)
            Dim O As Ordine = Dr.DataBoundItem
            Dim IdOrd As Integer = O.IdOrd

            Sottofondo(Me.ParentForm)
            Dim x As New frmEmailOrd
            x.Carica(IdOrd)
            x = Nothing
            Sottofondo(Me.ParentForm)

        End If

    End Sub
    Private Sub ForzaStato(ByVal stato As enStatoOrdine)
        If DgOrdini.SelectedRows.Count Then

            Dim Dr As DataGridViewRow

            Dr = DGOrdini.SelectedRows(0)
            Dim O As Ordine = Dr.DataBoundItem

            If MessageBox.Show("Confermi il cambiamento di stato dell'ordine?", Postazione.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New OrdiniDAO
                    mgr.InserisciLog(O, stato)
                End Using
                AvviaRicerca()
            End If

        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        ForzaStato(enStatoOrdine.Imballaggio)
        'AvviaRicerca()
        CaricaGruppi()
    End Sub
    Private Sub ModificaDatiEconomici()

        If DgOrdini.SelectedRows.Count Then

            Dim Dr As DataGridViewRow = DgOrdini.SelectedRows(0)
            Dim o As Ordine = Dr.DataBoundItem
            Dim stato As Integer = o.Stato
            IdOrdSel = o.IdOrd

            Dim frmMod As New frmModificaImporti
            Sottofondo(Me.ParentForm)

            frmMod.Carica(IdOrdSel)

            Sottofondo(Me.ParentForm)
            frmMod = Nothing

        End If
    End Sub

    Private Sub ModificaDatiEconomiciToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaDatiEconomiciToolStripMenuItem.Click
        ModificaDatiEconomici()
    End Sub

    Private Sub AllegaMessaggioAllordineToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AllegaMessaggioAllordineToolStripMenuItem.Click
        If DgOrdini.SelectedRows.Count Then

            Sottofondo(Me.ParentForm)
            Dim f As New frmPostit
            f.Carica(, , IdOrdSel)
            Sottofondo(Me.ParentForm)

        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click
        ForzaStato(enStatoOrdine.Preinserito)
        CaricaGruppi()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem4.Click
        ForzaStato(enStatoOrdine.InSospeso)
        CaricaGruppi()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        ForzaStato(enStatoOrdine.Registrato)
        CaricaGruppi()
    End Sub

    Private Sub cmbTipoProd_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If sender.focused Then AvviaRicerca()

    End Sub

    Private Sub rdoSospeso_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPre.CheckedChanged
        'If sender.focused Then
        'AvviaRicerca()
        'CaricaComboGruppi()
        'lnkNewCom.Enabled = rdoReg.Checked
        'End If
    End Sub
    Private Sub CaricaGruppi()
        Cursor.Current = Cursors.WaitCursor
        tvwCat.Nodes.Clear()

        Dim DescrNodoZero As String = "- Tutti "
        Using M As New CatProdDAO


            Dim NOrd As Integer = 0
            NOrd = M.GetNumOrd(0, 0, enStatoOrdine.Preinserito)
            DescrNodoZero &= "{"
            If NOrd Then DescrNodoZero &= NOrd & " Pre "
            Dim NOrdR As Integer = 0
            NOrdR = M.GetNumOrd(0, 0, enStatoOrdine.Registrato)
            If NOrdR Then
                DescrNodoZero &= NOrdR & " Reg"
            End If
            DescrNodoZero &= "}"
        End Using
        tvwCat.Nodes.Add("N0", DescrNodoZero)
        CaricaNodi(0)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CaricaNodi(ByVal IdPadre As Integer)

        Using mgr As New CatProdDAO()
            Dim par1 As New LUNA.LunaSearchParameter("IdCatPadre", IdPadre)
            Dim Lst As List(Of CatProd) = mgr.FindAll("Descrizione", par1)

            For Each CategProd As CatProd In Lst

                Dim NOrd As Integer = 0
                Dim NOrdR As Integer = 0
                Using M As New CatProdDAO
                    NOrd = M.GetNumOrd(CategProd.IdCatProd, CategProd.IdCatPadre, enStatoOrdine.Preinserito)

                    NOrdR = M.GetNumOrd(CategProd.IdCatProd, CategProd.IdCatPadre, enStatoOrdine.Registrato)
                End Using
                If NOrd Or NOrdR Then
                    Dim Descr As String = CategProd.Descrizione & " {"
                    If NOrd Then
                        Descr &= NOrd & " Pre "
                    End If

                    If NOrdR Then
                        Descr &= NOrdR & " Reg"
                    End If
                    Descr &= "}"

                    If IdPadre Then
                        tvwCat.Nodes("C" & IdPadre).Nodes.Add("C" & CategProd.IdCatProd, Descr, 0, 1)
                    Else
                        tvwCat.Nodes.Add("C" & CategProd.IdCatProd, Descr, 0, 1)
                    End If
                    CaricaNodi(CategProd.IdCatProd)

                End If
                'tvwCat.Nodes.Add("C" & CategProd.IdCatProd, CategProd.Descrizione)


            Next
        End Using
    End Sub

    Private Sub ucOrdiniGest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        ForzaStato(enStatoOrdine.Rifiutato)
        CaricaGruppi()
    End Sub

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        AvviaRicerca()
    End Sub

    Private Sub cmbModelloCommessa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbModelloCommessa.SelectedIndexChanged
        If cmbModelloCommessa.SelectedIndex <> -1 Then
            Dim M As ModelloCommessa = cmbModelloCommessa.SelectedItem
            If Not M Is Nothing Then
                lblNumSpaziDisp.Text = M.NumSpazi
                CalcolaSpaziUsati()
                Try
                    pctAnteprimaModello.Image = Image.FromFile(M.Anteprima)
                Catch ex As Exception

                End Try

            End If

        End If

    End Sub

    'Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
    '    CaricaGruppi()
    '    'tvwCat.ExpandAll()
    'End Sub

    Private Sub tvwCat_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwCat.AfterSelect
        If sender.focused Then
            CaricaTipiCommessa()
            AvviaRicerca()
        End If


    End Sub

    Private Sub CaricaTipiCommessa()
        Dim IdCatProd As Integer = 0
        If Not tvwCat.SelectedNode Is Nothing Then

            Dim IdChiave As Integer = tvwCat.SelectedNode.Name.Substring(1)
            If IdChiave Then IdCatProd = IdChiave
        End If
        Dim L As List(Of CatProdTipocom)
        cmbTipoCom.ValueMember = "IdTipoCom"
        cmbTipoCom.DisplayMember = "Descrizione"
        If cmbTipoCom.DataSource Is Nothing Then
            cmbTipoCom.Items.Clear()
            cmbTipoCom.Text = ""
        Else
            cmbTipoCom.DataSource = Nothing
        End If

        If IdCatProd = 0 Then
            Using TipoCom As New TipoCommesseDAO
                cmbTipoCom.DataSource = TipoCom.GetAll("Descrizione")
            End Using
        Else
            Using mgr As New CatProdTipoComDAO
                L = mgr.FindAll(New LUNA.LunaSearchParameter("IdCatProd", IdCatProd))
            End Using

            For Each c As CatProdTipoCom In L
                Dim t As New TipoCommessa
                t.Read(c.IdTipoCom)
                cmbTipoCom.Items.Add(t)
            Next
            If L.Count Then
                cmbTipoCom.SelectedIndex = 0
            Else
                cmbModelloCommessa.DataSource = Nothing
            End If

        End If


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub pctAnteprimaModello_Click(sender As Object, e As EventArgs) Handles pctAnteprimaModello.Click
        If Not pctAnteprimaModello.Image Is Nothing Then
            Sottofondo(Me.ParentForm)
            Dim f As New frmCommessaModello
            f.Carica(cmbModelloCommessa.SelectedValue)
            Sottofondo(Me.ParentForm)
        End If
    End Sub

    Private Sub DGOrdini_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGOrdini.CellContentClick

    End Sub

    Private Sub DGOrdini_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DGOrdini.RowsAdded
        Dim TotSpazi As Integer = 0
        For Each r As DataGridViewRow In DGOrdini.Rows
            TotSpazi += r.Cells(7).Value
        Next
        lblNumSpazi.Text = TotSpazi
    End Sub

    Private Sub DGOrdini_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGOrdini.ColumnHeaderMouseClick
        OrdinatoreLista(Of OrdineRicerca).OrdinaLista(sender, e)
    End Sub
End Class
