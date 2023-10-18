Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class ucAmministrazioneRubrica
    Inherits ucFormerUserControl

    Private Sub CaricaGruppi()

        'carico la lista delle lavorazioni 
        ' If Not _cnOld Is Nothing Then

        'Dim x As New cGruppiColl
        'Dim dtListaScelti As DataTable

        'dtListaScelti = x.Lista(True)

        'x = Nothing

        'cmbGruppo.DisplayMember = "Nome"
        'cmbGruppo.ValueMember = "IdGruppo"
        'cmbGruppo.DataSource = dtListaScelti
        Try
            Dim Gr As New GruppiDAO()
            Dim ls As List(Of Gruppo) = Gr.GetAll(LFM.Gruppo.Nome, True)
            cmbGruppo.ValueMember = "IdGruppo"
            cmbGruppo.DisplayMember = "Nome"
            cmbGruppo.DataSource = ls
        Catch ex As Exception

        End Try

        '   End If

    End Sub

    Private Sub CaricaCorriere()

        Dim l As New List(Of cEnum)

        Dim val As New cEnum
        val.Id = 0
        val.Descrizione = "Tutto"
        l.Add(val)

        val = New cEnum
        val.Id = enCorriere.RitiroCliente
        val.Descrizione = "Ritiro Cliente"
        l.Add(val)

        val = New cEnum
        val.Id = enCorriere.TipografiaFormer
        val.Descrizione = "Tipografia Former"
        l.Add(val)

        val = New cEnum
        val.Id = enCorriere.GLS
        val.Descrizione = "GLS"
        l.Add(val)

        val = New cEnum
        val.Id = enCorriere.PortoAssegnatoGLS
        val.Descrizione = "Porto assegnato"
        l.Add(val)

        cmbTipoCorriere.DataSource = l
        cmbTipoCorriere.DisplayMember = "Descrizione"
        cmbTipoCorriere.ValueMember = "Id"

    End Sub

    Public Sub MostraDati(Optional ByVal CercaSpec As String = "",
                          Optional SenzaCategoria As Boolean = False)

        Cursor.Current = Cursors.WaitCursor
        ' If Not _cnOld Is Nothing Then
        Dim Cerca As String = ""

        If CercaSpec.Length Then
            Cerca = CercaSpec
        Else
            Cerca = txtCercaCli.Text
        End If

        Dim ShowForn As Boolean = chkFornitori.Checked
        Dim ShowCli As Boolean = chkClienti.Checked
        Dim ShowAge As Boolean = False 'chkAge.Checked
        Dim ShowRiv As Boolean = chkRivend.Checked

        If Cerca = "{inserire qui il testo o il #tag da cercare}" Then Cerca = ""

        Using Mgr As New VociRubricaDAO


            Dim TipoSorgenteRubrica As String = String.Empty
            Dim TipoSorgenteRubricaStorico As String = String.Empty

            If chkInseritiAutomaticamente.Checked Then
                TipoSorgenteRubricaStorico = "F"
            End If

            If chkFornitoriDaValidare.Checked Then
                TipoSorgenteRubrica = "F"
            End If


            Dim lst As List(Of VoceRubrica)

            Dim IdCategoria As Integer = 0

            IdCategoria = cmbCategoriaFornitore.SelectedValue

            If _SearchDuplicati Then
                lst = Mgr.GetDuplicati(ShowForn,
                                        ShowCli,
                                        ShowRiv,
                                        ShowAge)

            Else
                lst = Mgr.Lista(ShowForn,
                                ShowCli,
                                ShowRiv,
                                ShowAge,
                                Cerca,
                                chkOnlyOrder.Checked,
                                cmbGruppo.SelectedValue,
                                ,, cmbTipoCorriere.SelectedValue,
                                TipoSorgenteRubrica,
                                TipoSorgenteRubricaStorico,
                                IdCategoria)

                If SenzaCategoria Then
                    lst = lst.FindAll(Function(x) x.IdCatContab = 0)
                    lst.Sort(Function(x, y) x.RagSocNome.CompareTo(y.RagSocNome))
                End If
            End If

            If chkSoloConScoperto.Checked Then
                lst = lst.FindAll(Function(x) x.ScopertoComplessivo > 0)
            End If


            'Dim dr As Collections.Generic.List(Of cRubrica)
            'dr = Rub.ListaRub(ShowForn, ShowCli, Cerca, chkOnlyOrder.Checked, cmbGruppo.SelectedValue)
            'DgRubrica.AutoGenerateColumns = False
            'DgRubrica.DataSourceVirtual = lst
            ' End If
            DgRubricaEx.DataSource = lst

            lblNumRis.Text = lst.Count
        End Using
        Cursor.Current = Cursors.Default


    End Sub

    Private Sub toolRubrica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolRubrica.Click
        Dim But As ToolStripButton
        For Each But In toolRubrica.Items
            If But.Checked And Not But Is sender Then
                But.Checked = False
            End If
        Next
    End Sub

    Private Sub toolRubrica_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles toolRubrica.ItemClicked
        _SearchDuplicati = False
        MostraDati(e.ClickedItem.Text)
    End Sub

    Private Sub txtCercaCli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCercaCli.KeyPress
        Dim c As Char = vbCr
        If e.KeyChar = c Then Cerca()

    End Sub

    Private Sub txtCercaCli_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCercaCli.MouseClick
        If txtCercaCli.Text = "{inserire qui il testo o il #tag da cercare}" Then

            txtCercaCli.Text = ""

        End If
    End Sub

    Private Sub Carica()

        Try
            Using mgr As New CategContabiliDAO
                Dim lC As List(Of CategContabile) = mgr.FindAll(New LUNA.LunaSearchOption With {.AddEmptyItem = True, .OrderBy = "Tipocat,NomeCat"})
                cmbCategoriaFornitore.DisplayMember = "Riassunto"
                cmbCategoriaFornitore.ValueMember = LFM.CategContabile.IdCatContab.Name
                cmbCategoriaFornitore.DataSource = lC
            End Using

            CaricaCorriere()
            CaricaVociMenuPagamento()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CaricaVociMenuPagamento()

        Using PM As New TipoPagamentiDAO
            Dim l As List(Of TipoPagamento) = PM.GetAll(LFM.TipoPagamento.IdTipoPagam, False)

            For Each p As TipoPagamento In l

                Dim item As ToolStripItem = CambiaIlMetodoDiPagamentoAToolStripMenuItem.DropDownItems.Add(p.TipoPagam)
                item.Tag = p.IdTipoPagam
                AddHandler item.Click, AddressOf CambiaMetodoPagamento

            Next

        End Using

    End Sub

    Private Sub lnkCerca_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked
        Cerca()

    End Sub
    Private Sub Cerca()
        _SearchDuplicati = False
        If txtCercaCli.Text = "{inserire qui il testo o il #tag da cercare}" Then
            MessageBox.Show("Inserire il testo per effettuare la ricerca", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MostraDati()
        End If
    End Sub
    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAll.LinkClicked
        _SearchDuplicati = False
        txtCercaCli.Text = ""
        MostraDati()
    End Sub

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        ParentFormEx.Sottofondo()
        StampaGlobale("Rubrica", DgRubricaEx)
        ParentFormEx.Sottofondo()
    End Sub

    'Private Sub lnkAllarga_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAllarga.LinkClicked
    '    If DgRubrica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells Then
    '        DgRubrica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    '        lnkAllarga.Text = "Espandi"
    '    Else
    '        DgRubrica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '        lnkAllarga.Text = "Adatta"
    '    End If
    '    DgRubrica.AutoResizeColumns()
    'End Sub

    Private Sub DgRubrica_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DgRubrica_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)



    End Sub

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        Dim x As System.Drawing.Point = MousePosition
        mnuNuovo.Show(x)

    End Sub

    Private Sub ClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClienteToolStripMenuItem.Click

        NewCliente()

    End Sub

    Private Sub NewCliente()

        Dim frmRif As New frmVoceRubrica
        Dim ObjRif As New VoceRubrica
        Dim Ris As Integer = 0
        ObjRif.Tipo = enTipoRubrica.Cliente
        ParentFormEx.Sottofondo()
        Ris = frmRif.Carica(ObjRif)
        ParentFormEx.Sottofondo()
        If Ris Then
            _SearchDuplicati = False
            MostraDati()
        End If
        frmRif.Dispose()
        ObjRif = Nothing

    End Sub

    'Private Sub NewFornitore()
    '    Dim frmRif As New frmVoceRubrica
    '    Dim ObjRif As New VoceRubrica
    '    Dim Ris As Integer = 0
    '    ObjRif.Tipo = enTipoRubrica.Fornitore
    '    ParentFormEx.Sottofondo()
    '    Ris = frmRif.Carica(ObjRif)
    '    ParentFormEx.Sottofondo()
    '    If Ris Then
    '        _SearchDuplicati = False
    '        MostraDati()
    '    End If

    '    frmRif.Dispose()
    '    ObjRif = Nothing
    'End Sub

    Private Sub NewRivenditore()

        Dim frmRif As New frmVoceRubrica
        Dim ObjRif As New VoceRubrica
        Dim Ris As Integer = 0
        ObjRif.Tipo = enTipoRubrica.Rivenditore
        ParentFormEx.Sottofondo()
        Ris = frmRif.Carica(ObjRif)
        ParentFormEx.Sottofondo()
        If Ris Then
            _SearchDuplicati = False
            MostraDati()
        End If
        frmRif.Dispose()
        ObjRif = Nothing

    End Sub

    'Private Sub NewAgente()

    '    Dim frmRif As New frmVoceRubrica
    '    Dim ObjRif As New VoceRubrica
    '    Dim Ris As Integer = 0
    '    ObjRif.Tipo = enTipoRubrica.Agente
    '    ParentFormEx.Sottofondo()
    '    Ris = frmRif.Carica(ObjRif)
    '    ParentFormEx.Sottofondo()
    '    If Ris Then
    '        _SearchDuplicati = False
    '        MostraDati()
    '    End If
    '    frmRif.Dispose()
    '    ObjRif = Nothing

    'End Sub

    Private Sub RiapriVoce(Optional InSostituzione As Boolean = False)
        'Dim IdVoce As Integer
        'IdVoce = DgRubrica.SelectedRows(0).Cells(0).Value

        If DgRubricaEx.SelectedRows.Count Then
            Dim OggRif As VoceRubrica = DgRubricaEx.SelectedRows(0).DataBoundItem
            Dim Ris As Integer = 0

            Using frmRif As New frmVoceRubrica
                ParentFormEx.Sottofondo()

                If InSostituzione Then
                    Dim NuovaVoce As VoceRubrica
                    NuovaVoce = OggRif.Clone
                    Ris = frmRif.Carica(NuovaVoce, OggRif.IdRub)
                Else
                    Ris = frmRif.Carica(OggRif)
                End If


                ParentFormEx.Sottofondo()

                If Ris Then MostraDati()
            End Using

        End If

    End Sub

    'Private Sub FornitoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    NewFornitore()
    'End Sub

    Private Sub DgRubrica_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RiapriVoce()
    End Sub

    Private Sub MenuVoce(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then

            If DgRubricaEx.SelectedRows.Count Then
                Dim x As System.Drawing.Point = MousePosition
                'btnNuovoCliente.ContextMenu = menuNuovo.
                x = MousePosition
                'x = lnkNew.PointToClient(x)

                Dim rig As GridViewRowInfo = DgRubricaEx.SelectedRows(0)
                Dim voceRub As VoceRubrica = rig.DataBoundItem

                rig.IsSelected = True
                DgRubricaEx.Select()

                'prima di far vedere il menu coloro la voce giusta di pagamento e corriere 
                For Each v As ToolStripItem In CambiaIlCorrierePredefinitoAToolStripMenuItem.DropDownItems
                    If v.Tag = voceRub.IdCorriere Then
                        v.BackColor = Color.Green
                        v.ForeColor = Color.White
                    Else
                        v.BackColor = Color.White
                        v.ForeColor = Color.Black
                    End If
                Next

                For Each v As ToolStripItem In CambiaIlMetodoDiPagamentoAToolStripMenuItem.DropDownItems
                    If v.Tag = voceRub.IdPagamento Then
                        v.BackColor = Color.Green
                        v.ForeColor = Color.White
                    Else
                        v.BackColor = Color.White
                        v.ForeColor = Color.Black
                    End If
                Next

                mnuVoce.Show(x)

            End If

        End If
    End Sub

    Private Sub DgRubrica_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        MenuVoce(e)
    End Sub

    Private Sub EliminaVoce()
        MessageBox.Show("Funzione non implementata")
        'Dim IdVoce As Integer
        'IdVoce = DgRubricaEx.SelectedRows(0).Cells(0).Value



        'If MessageBox.Show("Confermi l'eliminazione della voce selezionata?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

        '    'TODO: IMPLEMENTARE CANCELLAZIONE DI TUTTO 
        '    Using r As New VoceRubrica
        '        r.Read(IdVoce)

        '        If r.IntestazioneBloccataLogicamente Then

        '        End If
        '    End Using
        '    Using OggRif As New VociRubricaDAO

        '        OggRif.Delete(IdVoce)

        '    End Using

        '    MostraDati()

        'End If

    End Sub
    Private Sub SituazioneOrdini()
        Dim IdVoce As Integer
        IdVoce = DgRubricaEx.SelectedRows(0).Cells(0).Value

        Dim PathOrd As String = "http://www.tipografiaformer.com/ordini/stato/" & IdVoce & ".html"

        Dim x As New Process

        x.StartInfo.FileName = PathOrd
        x.Start()

    End Sub


    Private Sub ModificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaToolStripMenuItem.Click
        RiapriVoce()
    End Sub

    Private Sub EliminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaToolStripMenuItem.Click
        EliminaVoce()
    End Sub

    Private Sub txtCercaCli_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCercaCli.TextChanged

    End Sub

    Private Sub chkFornitori_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOnlyOrder.CheckedChanged
        _SearchDuplicati = False
        MostraDati()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SituazioneOrdini()
    End Sub

    Private Sub DgRubrica_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        OrdinatoreLista(Of VoceRubrica).OrdinaLista(sender, e)
    End Sub

    'Private Sub DgRubrica_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
    '    'controlla che i dati importanti siano validi
    '    Dim x As DataGridViewRow = DgRubricaEx.Rows.Item(e.RowIndex)

    '    If x.Cells(1).Value.ToString.Length = 0 Then
    '        x.Cells(1).Style.BackColor = Color.Red
    '        x.Cells(1).Style.SelectionBackColor = Color.Red
    '    End If
    '    If x.Cells(4).Value.ToString.Length = 0 Then
    '        x.Cells(4).Style.BackColor = Color.Red
    '        x.Cells(4).Style.SelectionBackColor = Color.Red
    '    End If
    '    If x.Cells(6).Value.ToString.Length = 0 Then
    '        x.Cells(6).Style.BackColor = Color.Red
    '        x.Cells(6).Style.SelectionBackColor = Color.Red
    '    End If
    'End Sub

    Private Sub cmbGruppo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGruppo.SelectedIndexChanged
        If sender.focused Then
            _SearchDuplicati = False
            MostraDati()
        End If

    End Sub

    Private Sub RivenditoreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RivenditoreToolStripMenuItem.Click

        NewRivenditore()

    End Sub

    Private Sub AgenteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

        'NewAgente()

    End Sub

    Private Sub chkFornitori_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles chkFornitori.CheckedChanged, chkClienti.CheckedChanged, chkRivend.CheckedChanged
        'MostraDati()
    End Sub

    Private Sub DgRubricaEx_Click(sender As Object, e As EventArgs) Handles DgRubricaEx.Click

    End Sub

    Private Sub DgRubricaEx_DoubleClick(sender As Object, e As EventArgs) Handles DgRubricaEx.DoubleClick
        RiapriVoce()

    End Sub

    Private Sub DgRubricaEx_MouseClick(sender As Object, e As MouseEventArgs) Handles DgRubricaEx.MouseClick
        MenuVoce(e)
    End Sub

    Private Sub RitiroClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RitiroClienteToolStripMenuItem.Click
        CambiaCorriere(enTipoCorriere.Gratis)
    End Sub

    Private Sub CambiaCorriere(TipoCorriere As enTipoCorriere)



        If DgRubricaEx.SelectedRows.Count Then
            Dim OggRif As VoceRubrica = DgRubricaEx.SelectedRows(0).DataBoundItem
            Dim Ris As Integer = 0

            Dim TipoCorriereStr As String = String.Empty
            If TipoCorriere = enTipoCorriere.Gratis Then
                TipoCorriereStr = "Compra e Ritira"
            ElseIf TipoCorriere = enTipoCorriere.ConTariffa Then
                TipoCorriereStr = "Con Corriere"
            ElseIf TipoCorriere = enTipoCorriere.PortoAssegnato Then
                TipoCorriereStr = "Porto Assegnato"
            End If

            If MessageBox.Show("Confermi di voler cambiare il corriere predefinito di '" & OggRif.RagSocNome & "' a '" & TipoCorriereStr & "'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                OggRif.IdCorriere = TipoCorriere
                OggRif.LastUpdate = Now
                OggRif.Save()
                MostraDati()
            End If

        End If

    End Sub

    Private Sub CorriereToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorriereToolStripMenuItem.Click
        CambiaCorriere(enTipoCorriere.ConTariffa)
    End Sub

    Private Sub PortoAssegnatoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PortoAssegnatoToolStripMenuItem.Click
        CambiaCorriere(enTipoCorriere.PortoAssegnato)
    End Sub

    Private Sub CambiaMetodoPagamento(sender As Object, e As EventArgs)

        If DgRubricaEx.SelectedRows.Count Then
            Dim OggRif As VoceRubrica = DgRubricaEx.SelectedRows(0).DataBoundItem
            Dim Ris As Integer = 0

            If MessageBox.Show("Confermi di voler cambiare il metodo di pagamento predefinito di '" & OggRif.RagSocNome & "' a '" & sender.text & "'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                OggRif.IdPagamento = sender.tag
                OggRif.LastUpdate = Now
                OggRif.Save()
                MostraDati()
            End If
        End If

    End Sub

    Private Sub FiltraConQuestoValoreInQuestaColonnaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltraConQuestoValoreInQuestaColonnaToolStripMenuItem.Click
        FiltroCustom(sender, e)
    End Sub

    Private Sub FiltroCustom(sender As Object, e As EventArgs)

    End Sub

    Private Sub lnkMerge_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMerge.LinkClicked
        Dim IdRub As Integer = 0
        If DgRubricaEx.SelectedRows.Count Then
            Dim vocerub As VoceRubrica = DgRubricaEx.SelectedRows(0).DataBoundItem
            IdRub = vocerub.IdRub
        End If

        Using f As New frmVoceRubricaUnione
            Dim Ris As Integer = 0
            ParentFormEx.Sottofondo()
            Ris = f.Carica(IdRub)
            ParentFormEx.Sottofondo()

            If Ris Then MostraDati()
        End Using
    End Sub

    Dim _SearchDuplicati As Boolean = False

    Private Sub lnkTrovaDuplicati_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTrovaDuplicati.LinkClicked
        _SearchDuplicati = True
        chkOnlyOrder.Checked = False
        chkFornitoriDaValidare.Checked = False
        chkInseritiAutomaticamente.Checked = False
        MostraDati()
    End Sub

    Public Sub MostraDuplicati()

        _SearchDuplicati = True
        txtCercaCli.Text = String.Empty
        chkOnlyOrder.Checked = False
        'chkAge.Checked = True
        chkClienti.Checked = False
        chkRivend.Checked = False
        chkFornitori.Checked = False
        'cmbGruppo.SelectedIndex = 0
        cmbTipoCorriere.SelectedIndex = 0
        chkInseritiAutomaticamente.Checked = False
        chkFornitoriDaValidare.Checked = False
        cmbCategoriaFornitore.SelectedIndex = 0
        MostraDati()

    End Sub

    Public Sub MostraSenzaCategoria()
        _SearchDuplicati = False
        txtCercaCli.Text = String.Empty
        chkOnlyOrder.Checked = False
        'chkAge.Checked = False
        chkClienti.Checked = False
        chkRivend.Checked = False
        chkFornitori.Checked = True
        'cmbGruppo.SelectedIndex = 0
        cmbTipoCorriere.SelectedIndex = 0
        chkInseritiAutomaticamente.Checked = False
        chkFornitoriDaValidare.Checked = False
        cmbCategoriaFornitore.SelectedIndex = 0
        MostraDati(, True)

    End Sub

    Public Sub MostraInseritiAutomaticamenteDaValidare()
        _SearchDuplicati = False
        txtCercaCli.Text = String.Empty
        chkOnlyOrder.Checked = False
        'chkAge.Checked = False
        chkClienti.Checked = False
        chkRivend.Checked = False
        chkFornitori.Checked = True
        'cmbGruppo.SelectedIndex = 0
        cmbTipoCorriere.SelectedIndex = 0
        chkInseritiAutomaticamente.Checked = False
        chkFornitoriDaValidare.Checked = True
        cmbCategoriaFornitore.SelectedIndex = 0
        MostraDati()

    End Sub

    Private Sub DgRubricaEx_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles DgRubricaEx.CellFormatting
        If e.CellElement.ColumnInfo.Name = "ScopertoAttuale" Then
            If e.CellElement.Text <> "-" Then
                Dim Riga As GridViewRowInfo = e.Row
                Using R As VoceRubrica = Riga.DataBoundItem
                    Dim ColoreSfondo As Color = Color.Green
                    Dim ColorePrimoPiano As Color = Color.White
                    If R.ScopertoMax Then
                        Dim MetaScopertoMax As Decimal = R.ScopertoMax / 2

                        If R.ScopertoComplessivo < MetaScopertoMax Then
                            ColoreSfondo = Color.Green
                            ColorePrimoPiano = Color.White
                        ElseIf R.ScopertoComplessivo >= MetaScopertoMax And R.ScopertoComplessivo <= R.ScopertoMax Then
                            ColoreSfondo = Color.Orange
                            ColorePrimoPiano = Color.Black
                        Else
                            ColoreSfondo = Color.Red
                            ColorePrimoPiano = Color.White
                        End If
                    Else
                        ColoreSfondo = Color.Red
                        ColorePrimoPiano = Color.White
                    End If

                    e.CellElement.BackColor = ColoreSfondo
                    e.CellElement.ForeColor = ColorePrimoPiano

                End Using
            Else
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
            End If

        Else
            e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
            e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
        End If
    End Sub

    Private Sub ChkSoloConScoperto_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloConScoperto.CheckedChanged
        If chkSoloConScoperto.Checked Then chkOnlyOrder.Checked = True
    End Sub

    Private Sub NuovaVoceInSostituzioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuovaVoceInSostituzioneToolStripMenuItem.Click

        RiapriVoce(True)

    End Sub
End Class
