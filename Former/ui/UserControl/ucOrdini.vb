Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerDALSql.LUNA
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class ucOrdini
    Inherits ucFormerUserControl

    Private _IdRub As Integer
    Private _IdOrd As Integer = 0

    Public IdOrdSel As Integer
    Public OrdineSel As Ordine = Nothing
    Dim _oAnteprima As Ordine
    Private Ordinamento As String = ""

    Public Property IdRub() As Integer
        Get
            Return _IdRub
        End Get
        Set(ByVal value As Integer)
            _IdRub = value
        End Set
    End Property

    Public Sub Carica(Optional WithFirstSearch As Boolean = True)
        'FormerDebug.Traccia("CARICAMENTO INIZIALE")
        CaricaCombo()

        If _IdRub Then
            'qui devo nascondere la combo clienti 
            UcComboRubrica.Enabled = False
            'MgrControl.SelectIndexCombo(cmbCliente, _IdRub)
            UcComboRubrica.IdRubSelezionato = _IdRub
            'lblClienti.Visible = False
            lnkCerca.Left = lblClienti.Left
            lnkCerca.Anchor = AnchorStyles.Left + AnchorStyles.Top

        End If

        UcStatoOrdiniAdvanced.Carica()
        'carico le commesse 

        'If WithFirstSearch Then AvviaRicerca(,, 100)

    End Sub

    Public Sub SelezionaClienteDaChiamata(IdCli As Integer)
        'MgrControl.SelectIndexCombo(cmbCliente, IdCli)
        UcComboRubrica.IdRubSelezionato = IdCli
        AvviaRicerca()
    End Sub

    Public Sub SelezionaOrdiniDaTipoFustella(IdTipoFustella As Integer)
        'MgrControl.SelectIndexCombo(cmbCliente, IdCli)
        'UcComboRubrica.IdRubSelezionato = IdCli
        UcStatoOrdiniAdvanced.AttivaTutti()
        AvviaRicerca(,,, IdTipoFustella)
    End Sub

    Private Sub CaricaCombo()

        'carico la combo dei clienti
        'Using cli As New VociRubricaDAO
        '    cmbCliente.ValueMember = "IdRub"
        '    cmbCliente.DisplayMember = "Nominativo"

        '    cmbCliente.DataSource = cli.ListaCombo(enTipoRubrica.Cliente, True)

        ''carico la combo dei clienti
        'cmbAgente.ValueMember = "IdRub"
        'cmbAgente.DisplayMember = "Nominativo"

        'cmbAgente.DataSource = cli.ListaCombo(enTipoRubrica.Agente, True)

        UcComboRubrica.Carica(enTipoRubrica.Cliente, True)

        'End Using

        Using mgr As New ListinoBaseDAO

            cmbProdotto.ValueMember = "IdListinoBase"
            cmbProdotto.DisplayMember = "Nome"

            'cmbProdotto.DataSource = mgr.GetAll(LFM.ListinoBase.Nome, True)
            cmbProdotto.DataSource = mgr.FindAll(New LUNA.LSO() With {.OrderBy = LFM.ListinoBase.Nome.Name, .AddEmptyItem = True},
                                New LUNA.LSP(LFM.ListinoBase.Disattivo, enSiNo.No),
                                New LUNA.LSP(LFM.ListinoBase.IdListinoBaseSource, 0, "<>"))
        End Using

        'carico la combo degli stati
        'Dim StatoOrd As New cStatoOrdini()
        'cmbStato.DataSource = StatoOrd
        'cmbStato.ValueMember = "Id"
        'cmbStato.DisplayMember = "Descrizione"
        Using mgr As New PreventivazioniDAO

            cmbCatProd.ValueMember = "IdPrev"
            cmbCatProd.DisplayMember = "Descrizione"

            cmbCatProd.DataSource = mgr.GetAll(LFM.Preventivazione.Descrizione,
                                               True)
        End Using

        'Using Gr As New GruppiDAO()
        '    Dim ls As List(Of Gruppo) = Gr.GetAll("Nome", True)
        '    cmbGruppo.ValueMember = "IdGruppo"
        '    cmbGruppo.DataSource = ls
        '    cmbGruppo.DisplayMember = "Nome"
        'End Using

        cmbPagato.Items.Clear()
        cmbPagato.ValueMember = "Id"
        cmbPagato.DisplayMember = "Descrizione"

        Dim c As New cEnum
        c.Id = enSiNo.NonDefinito
        c.Descrizione = "-"
        cmbPagato.Items.Add(c)

        c = New cEnum
        c.Id = enSiNo.No
        c.Descrizione = "No"
        cmbPagato.Items.Add(c)

        c = New cEnum
        c.Id = enSiNo.Si
        c.Descrizione = "Si"
        cmbPagato.Items.Add(c)

        cmbPagato.SelectedIndex = 0

        Dim Stati() As FormerLib.FormerEnum.enRepartoWeb = [Enum].GetValues(GetType(enRepartoWeb))
        Dim l As New List(Of cEnum)
        Dim P As cEnum = Nothing
        For Each reparto As enRepartoWeb In Stati

            'If reparto > enRepartoWeb.Tutto Then

            P = New FormerLib.cEnum
                P.Id = reparto
                P.Descrizione = FormerEnumHelper.RepartoStr(reparto)
                l.Add(P)

            'End If

        Next
        cmbRepartoWeb.DisplayMember = "Descrizione"
        cmbRepartoWeb.ValueMember = "Id"
        cmbRepartoWeb.DataSource = l


    End Sub

    Public Sub AvviaRicerca(Optional ByVal Showall As Boolean = False,
                            Optional IdProd As Integer = 0,
                            Optional Top As Integer = 0,
                            Optional IdTipoFustella As Integer = 0)

        'Dim x As New cOrdiniColl
        Using mgr As New OrdiniDAO
            Cursor.Current = Cursors.WaitCursor
            Dim _ListaRis As List(Of OrdineRicerca) = Nothing
            'If _IdRub Then x.IdRub = _IdRub
            If Showall Then

                _ListaRis = mgr.GetAll()
                'x.Lista()
            Else

                Dim Cod As String = txtCerca.Text
                Dim IdOnline As Integer = 0

                If txtIdOnline.Text.Trim.Length Then
                    IdOnline = txtIdOnline.Text
                End If

                Dim IdRubrica As Integer = _IdRub

                If IdRubrica = 0 Then

                    IdRubrica = UcComboRubrica.IdRubSelezionato

                    'If cmbCliente.SelectedValue Then IdRubrica = cmbCliente.SelectedValue
                End If

                Dim pagato As enSiNo = enSiNo.NonDefinito
                If Not cmbPagato.SelectedItem Is Nothing Then
                    pagato = DirectCast(cmbPagato.SelectedItem, cEnum).Id
                End If

                _ListaRis = mgr.Lista(Cod,
                                      UcStatoOrdiniAdvanced.StatiSelezionati,
                                      cmbCatProd.SelectedValue,,,,
                                      IdProd,,
                                      IIf(chkDataInsDal.Checked, dtDataInsDal.Value, Nothing),
                                      IIf(chkDataInsAl.Checked, dtDataInsAl.Value, Nothing),
                                      0,
                                      IdRubrica,
                                      ,,,
                                      0,,
                                      chkWithoutDocFisc.Checked, ,
                                      cmbProdotto.SelectedValue,
                                      txtQta.Text, ,
                                      pagato,
                                      IdOnline,
                                      Top,
                                      chkPromo.Checked,
                                      txtNumOrdProvvisorio.Text,
                                      txtNumOrdOnline.Text,,
                                      chkConDocFiscale.Checked,
                                      cmbRepartoWeb.SelectedValue,
                                      IdTipoFustella)

                RaiseEvent OrdineSelezionato()

            End If

            'DgOrdiniEx.DataSourceLate = lst
            'Application.DoEvents()

            'DgOrdini.AutoGenerateColumns = False

            '_PosizioneRaggiunta = 0
            '_ListaVis = New List(Of OrdineRicerca)

            'Dim i As Integer = 0
            'For Each singo In _ListaRis

            '    If i = _RowToLoad Then
            '        Exit For
            '    Else
            '        _ListaVis.Add(singo)
            '        i += 1
            '        _PosizioneRaggiunta += 1
            '    End If
            'Next

            '_bindingSource = New BindingSource()
            '_bindingSource.DataSource = _ListaVis

            Using b As New BindingSource
                b.DataSource = _ListaRis
                DgOrdiniEx.DataSource = b
                'DgOrdiniEx.DataSource = _ListaRis
            End Using



            'DgOrdini.DataSourceVirtual = _ListaRis

            lblNumRis.Text = _ListaRis.Count

            'DgOrdini.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgOrdini.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgOrdini.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgOrdini.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DgOrdini.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgOrdini.Columns(10).DefaultCellStyle.Format = "0.00"
            'DgOrdini.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DgOrdini.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            lblNumEuro.Text = CalcolaTotaleVisEx(_ListaRis)

            'DgOrdini.ClearSelection()
            DgOrdiniEx.ClearSelection()

            Cursor.Current = Cursors.Default
        End Using
    End Sub

    'Private Sub AggiungiRighe()
    '    If _PosizioneRaggiunta < _ListaRis.Count Then

    '        For i As Integer = 0 To _RowToLoad
    '            If i = _RowToLoad Or (_PosizioneRaggiunta + 1) = _ListaRis.Count Then
    '                Exit For
    '            Else
    '                'qui aggiungo una riga alla listavis da listaris 
    '                _PosizioneRaggiunta += 1
    '                Dim OtoAdd As OrdineRicerca = _ListaRis(_PosizioneRaggiunta)

    '                _bindingSource.Add(OtoAdd)
    '                'If _ListaVis.Find(Function(x) x.IdOrd = OtoAdd.IdOrd) Is Nothing Then _ListaVis.Add(OtoAdd)
    '            End If
    '        Next


    '    End If
    'End Sub

    'Private _PosizioneRaggiunta As Integer = 0
    'Private _RowToLoad As Integer = 50

    'Private _bindingSource As BindingSource = Nothing
    'Private _ListaRis As List(Of OrdineRicerca) = Nothing
    'Private _ListaVis As List(Of OrdineRicerca) = Nothing

    'Public Sub AvviaRicercaEXSQL(Optional ByVal Showall As Boolean = False, Optional ByVal Row As DataGridViewRow = Nothing)

    '    Cursor.Current = Cursors.WaitCursor
    '    'Dim x As New cOrdiniColl
    '    Dim cnstring As String = "Server=lunadixlab\sqlexpress;Database=Former;Trusted_Connection=True;"
    '    Dim mgr As New FormerDaoSql.OrdiniDAO(cnstring)

    '    Dim lst As List(Of FormerDaoSql.OrdineRicerca)
    '    'If _IdRub Then x.IdRub = _IdRub
    '    If Showall Then

    '        lst = mgr.GetAll()
    '        'x.Lista()
    '    Else

    '        Dim Cod As String = txtCerca.Text

    '        If Cod = "{inserire qui il codice}" Then

    '            Cod = ""

    '        End If
    '        Dim IdRubrica As Integer = _IdRub

    '        If _IdRub = 0 Then
    '            If cmbCliente.SelectedValue Then IdRubrica = cmbCliente.SelectedValue
    '        End If
    '        Dim AnnoSel As Integer = 0
    '        If Postazione.AnnoSelezionato.Length Then AnnoSel = Postazione.AnnoSelezionato

    '        lst = mgr.Lista(Cod, _
    '                        UcStatoOrdiniAdvanced.StatiSelezionati, _
    '                         cmbCatProd.SelectedValue, _
    '                        , _
    '                        , _
    '                        , _
    '                         cmbProdotto.SelectedValue, _
    '                         , IIf(chkDataInsDal.Checked, dtDataInsDal.Value, Nothing), _
    '                         IIf(chkDataInsAl.Checked, dtDataInsAl.Value, Nothing), _
    '                        cmbGruppo.SelectedValue, _
    '                         IdRubrica, _
    '                         AnnoSel)
    '        RaiseEvent OrdineSelezionato()

    '    End If

    '    'DgOrdiniEx.DataSourceLate = lst
    '    'Application.DoEvents()
    '    DgOrdini.AutoGenerateColumns = False
    '    DgOrdini.DataSource = lst



    '    lblNumRis.Text = lst.Count
    '    'lblNumEuro.Text = CalcolaTotaleVisEx(lst)

    '    DgOrdini.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgOrdini.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgOrdini.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgOrdini.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgOrdini.Columns(8).DefaultCellStyle.Format = "0.00"
    '    DgOrdini.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    DgOrdini.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '    Cursor.Current = Cursors.Default

    'End Sub

    'Public Sub AvviaRicerca(Optional ByVal Showall As Boolean = False, Optional ByVal Row As DataGridViewRow = Nothing)
    '    Cursor.Current = Cursors.WaitCursor
    '    Dim x As New cOrdiniColl

    '    If _IdRub Then x.IdRub = _IdRub

    '    If Showall Then

    '        DgOrdini.DataSource = x.Lista()

    '    Else

    '        Dim Cod As String = txtCerca.Text

    '        If Cod = "{inserire qui il codice}" Then

    '            Cod = ""

    '        End If

    '        If cmbCliente.SelectedValue Then x.IdRub = cmbCliente.SelectedValue

    '        DgOrdini.DataSource = x.Lista(Cod, UcStatoOrdiniAdvanced.StatiSelezionati, cmbCatProd.SelectedValue, , , , cmbProdotto.SelectedValue, , IIf(chkDataInsDal.Checked, dtDataInsDal.Value, Nothing), IIf(chkDataInsAl.Checked, dtDataInsAl.Value, Nothing), cmbGruppo.SelectedValue)

    '        RaiseEvent OrdineSelezionato()

    '    End If

    '    lblNumRis.Text = DgOrdini.RowCount

    '    lblNumEuro.Text = calcolatotaleVis()


    '    DgOrdini.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgOrdini.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgOrdini.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    DgOrdini.Columns(6).DefaultCellStyle.Format = "0.00"

    '    'DgOrdini.Columns(7).Visible = False
    '    'DgOrdini.Columns(9).Visible = False
    '    'DgOrdini.Columns(10).Visible = False
    '    'DgOrdini.Columns(11).Visible = False
    '    'DgOrdini.Columns(12).Visible = False
    '    'DgOrdini.Columns(13).Visible = False
    '    'DgOrdini.Columns(14).Visible = False
    '    'DgOrdini.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'DgOrdini.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '    If Not Row Is Nothing Then
    '        Try
    '            Dim dr As DataGridViewRow = Row

    '            DgOrdini.FirstDisplayedScrollingRowIndex = Row.Index
    '            dr.Selected = True


    '        Catch ex As Exception

    '        End Try

    '    End If


    '    Cursor.Current = Cursors.Default

    'End Sub

    Private Function CalcolaTotaleVisEx(lst As List(Of OrdineRicerca)) As String


        Dim Tot As Decimal = 0

        For Each O As Ordine In lst
            Try
                Tot += O.TotaleImponibile
            Catch ex As Exception

            End Try
        Next

        Return "€ " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Tot)


    End Function

    Private Sub lnkCerca_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked

        AvviaRicerca()

    End Sub

    Private Sub txtCerca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCerca.KeyPress

        If e.KeyChar = vbCr Then

            AvviaRicerca()

            'Else
            '    MgrControl.ControlloNumerico(sender, e, True)
        End If


    End Sub

    Private Sub txtCerca_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCerca.MouseClick

        If txtCerca.Text = "{inserire qui il codice}" Then

            txtCerca.Text = ""

        End If

    End Sub

    Public Event OrdineSelezionato()

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Using frmRif As New frmOrdine

            Dim Ris As Integer = 0

            ParentFormEx.Sottofondo()
            Ris = frmRif.Carica(0, _IdRub)
            ParentFormEx.Sottofondo()

            If Ris Then AvviaRicerca()
        End Using

    End Sub

    'Private Sub DgOrdini_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

    '    If e.Button = Windows.Forms.MouseButtons.Left Then

    '        'riapro l'ordine in modifica

    '        Dim RigaSel As Integer = e.RowIndex

    '        If RigaSel <> -1 Then
    '            Dim rig As DataGridViewRow = DgOrdini.Rows(RigaSel)
    '            rig.Selected = True
    '            DgOrdini.Select()
    '            OrdineSel = rig.DataBoundItem
    '            IdOrdSel = OrdineSel.IdOrd

    '            Using frmRif As New frmOrdine

    '                Dim Ris As Integer = 0

    '                ParentFormEx.Sottofondo()
    '                Ris = frmRif.Carica(IdOrdSel)
    '                ParentFormEx.Sottofondo()
    '                If Ris Then AvviaRicerca()

    '            End Using

    '        End If

    '    End If
    'End Sub

    'Private Sub lnkOrdMail_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOrdMail.LinkClicked

    '    If MessageBox.Show("ATTENZIONE!!! La funzione di scaricamento degli ordini non va utilizzata in quanto il DEMONE si occupa di scaricare gli ordini automaticamente. Scaricare gli ordini manualmente da qui POTREBBE CREARE GROSSI PROBLEMI e COMPROMETTERE L'INTEGRITA' DEL DATABASE. Sicuro di voler continuare?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '        ParentFormerForm.Sottofondo 
    '        Dim x As New frmCheckMail
    '        Dim Ris As Integer

    '        Ris = x.Carica()

    '        If Ris Then AvviaRicercaEX()

    '        x = Nothing
    '        ParentFormerForm.Sottofondo 
    '    End If

    'End Sub

    'Private Sub DgOrdini_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)

    '    Dim Riga As DataGridViewRow = DgOrdini.Rows.Item(e.RowIndex)
    '    Dim o As Ordine = Riga.DataBoundItem

    '    Dim ColoreSfondo As Color = o.StatoColore

    '    Riga.Cells(9).Style.BackColor = ColoreSfondo
    '    Riga.Cells(9).Style.SelectionBackColor = ColoreSfondo

    '    If o.OrdineInOmaggio = enSiNo.Si Then
    '        Riga.Cells(10).Style.BackColor = FormerColori.ColoreOmaggioSfondo
    '        Riga.Cells(10).Style.ForeColor = FormerColori.ColoreOmaggioPrimoPiano
    '        Riga.Cells(10).Style.SelectionBackColor = FormerColori.ColoreOmaggioSfondo
    '        Riga.Cells(10).Style.SelectionForeColor = FormerColori.ColoreOmaggioPrimoPiano
    '    End If

    'End Sub

    Private Sub SelezioneCambiataEx()
        'If sender.focused Then
        If DgOrdiniEx.SelectedRows.Count Then

            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem

            If O.IdOrd <> IdOrdSel Then
                rig.IsSelected = True
                DgOrdiniEx.Select()

                IdOrdSel = O.IdOrd

                RaiseEvent OrdineSelezionato()

            End If

        End If
        ' End If
    End Sub


    'Private Sub SelezioneCambiata()
    '    'If sender.focused Then
    '    If DgOrdini.SelectedRows.Count Then

    '        Dim rig As DataGridViewRow
    '        rig = DgOrdini.SelectedRows(0)
    '        Dim O As Ordine = rig.DataBoundItem

    '        If O.IdOrd <> IdOrdSel Then
    '            rig.Selected = True
    '            DgOrdini.Select()

    '            IdOrdSel = O.IdOrd

    '            RaiseEvent OrdineSelezionato()

    '        End If

    '    End If
    '    ' End If
    'End Sub

    'Private Sub DgOrdini_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    SelezioneCambiata()

    'End Sub

    Private Sub cmbCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbCr Then

            AvviaRicerca()

        End If
    End Sub


    'Private Sub DgOrdini_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

    '    If DgOrdini.SelectedRows.Count Then

    '        Dim Dr As DataGridViewRow

    '        Dr = DgOrdini.SelectedRows(0)

    '        If Not Dr Is Nothing Then
    '            Dim O As Ordine = Dr.DataBoundItem
    '            If e.Button = Windows.Forms.MouseButtons.Right Then
    '                Dim x As System.Drawing.Point = MousePosition
    '                'btnNuovoCliente.ContextMenu = menuNuovo.

    '                'x.X -= 200

    '                '                    DgOrdini.Select( )
    '                Dr.Selected = True
    '                If IdOrdSel <> O.IdOrd Then
    '                    IdOrdSel = O.IdOrd
    '                    RaiseEvent OrdineSelezionato()
    '                End If
    '                Try

    '                    If O.IdDoc Then
    '                        RiapriDocumentoFiscaleToolStripMenuItem.Enabled = True
    '                        EmettiDocumentoFiscaleToolStripMenuItem.Enabled = False
    '                    Else
    '                        RiapriDocumentoFiscaleToolStripMenuItem.Enabled = False
    '                        EmettiDocumentoFiscaleToolStripMenuItem.Enabled = True

    '                    End If

    '                Catch ex As Exception
    '                    RiapriDocumentoFiscaleToolStripMenuItem.Enabled = False
    '                    EmettiDocumentoFiscaleToolStripMenuItem.Enabled = False

    '                End Try
    '                If O.Priorita = enSiNo.Si Then
    '                    AltaPrioritàToolStripMenuItem.Enabled = False
    '                    PrioritàNormaleToolStripMenuItem.Enabled = True
    '                Else
    '                    AltaPrioritàToolStripMenuItem.Enabled = True
    '                    PrioritàNormaleToolStripMenuItem.Enabled = False
    '                End If

    '                'If O.Stato = enStatoOrdine.RefineAutomatico Then
    '                '    PassaPreinseritoToolstripMenu.Enabled = False
    '                'Else
    '                '    PassaPreinseritoToolstripMenu.Enabled = False
    '                'End If

    '                'If O.Stato = enStatoOrdine.Preinserito Then
    '                '    PassaRefineToolstripMenu.Enabled = True
    '                'Else
    '                '    PassaRefineToolstripMenu.Enabled = False
    '                'End If

    '                MenuOrd.Show(x)

    '            End If

    '        End If
    '    End If
    'End Sub

    Private Sub DuplicaOrdineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuplicaOrdineToolStripMenuItem.Click
        If IdOrdSel Then

            Dim O As New Ordine
            O.Read(IdOrdSel)
            If O.IdListinoBase Then
                If MessageBox.Show("Confermi la duplicazione dell'ordine selezionato?", "Duplica Ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim Ris As Integer = 0

                    Dim ForzaIndirizzoDefault As Boolean = False

                    If O.IdIndirizzo <> O.VoceRubrica.DefaultIndirizzo.IDIndirizzo Then

                        If MessageBox.Show("L'ordine selezionato ha un indirizzo di consegna differente da quello di Default. Mantenere questo indirizzo anche nell'ordine duplicato? (In caso si risponda NO verrà inserito nell'ordine l'indirizzo di Default del cliente)", "Duplica Ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            ForzaIndirizzoDefault = True
                        End If

                    End If

                    Using x As New OrdiniDAO
                        Ris = x.DuplicaOrdine(Me.ParentFormEx,
                                              O,
                                              ForzaIndirizzoDefault)
                    End Using
                    'TODO: qui devo andare a separare le pagine nei file sorgenti dell'ordine duplicato
                    Using ONew As New Ordine
                        ONew.Read(Ris)
                        'qui separo i sorgenti del nuovo ordine in file singoli per pagina
                        Dim NumPag As Integer = 1

                        Dim LSorg As New List(Of FileSorgente)
                        Dim CambiatoQualcosa As Boolean = False

                        For Each s As FileSorgente In ONew.ListaSorgenti

                            Dim NumPagTrovate As Integer = FormerHelper.PDF.GetNumeroPagine(s.FilePath)

                            If NumPagTrovate > 1 Then
                                CambiatoQualcosa = True
                                Try

                                    For i As Integer = 1 To NumPagTrovate

                                        Dim PathEnd As String = s.FilePath.ToLower.Replace(".pdf", ".p" & i.ToString("0000") & ".pdf")

                                        FormerHelper.PDF.EstraiPaginaFromPdf(s.FilePath, PathEnd, i)

                                        Dim Sorg As New FileSorgente

                                        Sorg.FilePath = PathEnd
                                        Sorg.IdOrd = ONew.IdOrd
                                        Sorg.NumPagina = NumPag
                                        Sorg.StatoRefine = enStatoRefineSorgente.NonDefinito
                                        Sorg.IdSorgente = 0

                                        LSorg.Add(Sorg)
                                        NumPag += 1
                                    Next
                                Catch ex As Exception

                                End Try

                            Else
                                Dim Sorg As New FileSorgente

                                Sorg.FilePath = s.FilePath
                                Sorg.IdOrd = ONew.IdOrd
                                Sorg.NumPagina = NumPag
                                Sorg.StatoRefine = enStatoRefineSorgente.NonDefinito
                                Sorg.IdSorgente = 0

                                LSorg.Add(Sorg)
                                NumPag += 1
                            End If

                        Next

                        If CambiatoQualcosa Then

                            'qui cancello la lista vecchia e salvo la nuova

                            Using so As New FileSorgentiDAO
                                so.DeleteByIdOrd(ONew.IdOrd)

                                For Each singSorg As FileSorgente In LSorg
                                    singSorg.Save()
                                Next

                            End Using


                        End If

                    End Using

                    If Ris = 0 Then
                        MessageBox.Show("Si è verificato un errore nella duplicazione dell'ordine. L'ordine potrebbe essere stato cmq duplicato ma potrebbe mancare l'anteprima")
                    Else
                        AvviaRicerca()
                    End If

                End If
            Else
                MessageBox.Show("Non è possibile duplicare questo ordine perchè si riferisce a un prodotto non più a listino")
            End If
        End If
    End Sub

    'Private Sub ForzaStatos(ByVal stato As enStatoOrdine)
    '    If DgOrdini.SelectedRows.Count Then

    '        Dim Dr As DataGridViewRow

    '        Dr = DgOrdini.SelectedRows(0)
    '        IdOrdSel = Dr.Cells(0).Value


    '        If MessageBox.Show("Confermi il cambiamento di stato dell'ordine?", Postazione.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '            Dim O As New Ordine
    '            O.Read(_IdOrdsel)
    '            Dim _Ord As New Ordine
    '            _Ord.Read(IdOrdSel)

    '            _Ord.InserisciLog(stato)
    '            _Ord = Nothing
    '            AvviaRicercaEX()
    '        End If

    '    End If
    'End Sub

    Private Sub UcStatoOrdini_CambiatoStato() Handles UcStatoOrdiniAdvanced.CambiatoStato

    End Sub

    'Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If sender.focused Then AvviaRicercaEX()
    'End Sub

    Private Sub ModificaDatiEconomiciToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaDatiEconomiciToolStripMenuItem.Click
        ModificaDatiEconomici()
    End Sub

    Private Sub ModificaDatiEconomici()
        If DgOrdiniEx.SelectedRows.Count Then
            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem

            MgrOrdini.ModificaDatiEconomici(O, ParentFormEx)

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

    Private Sub InviaMail()

        If DgOrdiniEx.SelectedRows.Count Then

            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem
            Dim IdOrd As Integer = O.IdOrd

            ParentFormEx.Sottofondo()
            Dim x As New frmEmailOrd
            x.Carica(IdOrd)
            x = Nothing
            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub ApplicaFiltri(ByVal TipoFiltro As String)

        If DgOrdiniEx.SelectedRows.Count Then

            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem
            Dim Prodotto As Integer = 0

            Select Case TipoFiltro

                Case "Cli"
                    Dim cliente As Integer = O.IdRub
                    'MgrControl.SelectIndexCombo(cmbCliente, cliente)
                    UcComboRubrica.IdRubSelezionato = cliente

                Case "Prod"
                    Prodotto = O.IdProd
            End Select

            AvviaRicerca(, Prodotto)

        End If
    End Sub

    Private Sub lnkModifEco_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        ModificaDatiEconomici()
    End Sub

    Private Sub mnuFiltraCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFiltraCliente.Click
        ApplicaFiltri("Cli")
    End Sub

    Private Sub mnuFiltraProdotto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFiltraProdotto.Click
        ApplicaFiltri("Prod")
    End Sub

    Private Sub mnuInviaMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInviaMail.Click
        InviaMail()
    End Sub

    Private Sub DgOrdini_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub RiapriDocumentoFiscaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub EmettiDocumentoFiscaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmettiDocumentoFiscaleToolStripMenuItem.Click
        Dim rig As GridViewRowInfo
        If DgOrdiniEx.SelectedRows.Count Then
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem
            If O.IdDoc Then
                ParentFormEx.Sottofondo()

                Using x As New frmContabilitaRicavo
                    x.Carica(O.IdDoc, enTipoVoceContab.VoceVendita)
                End Using

                ParentFormEx.Sottofondo()
            Else
                RiapriConsegnaProgrammata()
            End If
        End If
        ''riapro la consegna programmata se prevista
        '' Dim x As New cConsColl
        'Dim idCons As Integer = 0
        'Using mgr As New ConsProgrOrdiniDAO
        '    idCons = mgr.IdConsByIdOrd(IdOrdSel)
        'End Using
        'If idCons Then
        '    ParentFormEx.Sottofondo()
        '    Dim xc As New frmConsegnaProgrammata
        '    xc.Carica(idCons)
        '    xc = Nothing
        '    ParentFormEx.Sottofondo()
        'Else
        '    MessageBox.Show("L'ordine non è inserito in nessuna consegna", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

        'qui creo la lista degli ordini nella stessa consegna e gliela passo

        'ParentFormerForm.Sottofondo 

        'Dim Ord As New Ordine
        'Ord.Read(IdOrdSel)

        'Dim x As New frmEmissioneDocumenti

        'Dim ListaIdOrdini As String = Ord.ConsegnaAssociata.ListaIdOrdini

        'Dim ListaIdOrdiniAss As String = Ord.ConsegnaAssociata.ListaIdOrdiniAssociati
        'If ListaIdOrdiniAss.Length Then ListaIdOrdini &= "," & ListaIdOrdiniAss

        'x.Carica(Ord.ConsegnaAssociata.TipoDoc, , ListaIdOrdini, Ord.ConsegnaAssociata.NumColli, Ord.ConsegnaAssociata.Peso, Ord.ConsegnaAssociata.IdCorr)
        ''x.Carica( enTipoDocumento.enTipoDocFattura, IdOrdSel)

        'x = Nothing
        'ParentFormerForm.Sottofondo 

    End Sub

    Private Sub EliminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaToolStripMenuItem.Click

        If MessageBox.Show("Confermi l'eliminazione di " & DgOrdiniEx.SelectedRows.Count & " ordini selezionati? (si possono eliminare solo gli ordini in stato Preinserito, Sospeso o Rifiutato)", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            'si possono eliminare solo ordini instato rifiutato o preinserito
            Dim Counter As Integer = 0
            For Each rig In DgOrdiniEx.SelectedRows
                Dim O As Ordine = rig.DataBoundItem

                If O.Stato = enStatoOrdine.Rifiutato OrElse
                    O.Stato = enStatoOrdine.InSospeso OrElse
                    O.Stato = enStatoOrdine.Preinserito Then

                    Using SMgr As New FileSorgentiDAO

                        Dim l As List(Of FileSorgente) = SMgr.FindAll(New LunaSearchParameter(LFM.FileSorgente.IdOrd, O.IdOrd))

                        For Each s As FileSorgente In l
                            Try
                                FileIO.FileSystem.DeleteFile(s.FilePath)
                            Catch ex As Exception

                            End Try
                        Next
                        SMgr.DeleteByIdOrd(O.IdOrd)

                        Try
                            FileIO.FileSystem.DeleteFile(O.FilePath)
                        Catch ex As Exception

                        End Try

                    End Using

                    Using Mgr As New OrdiniDAO
                        Mgr.Delete(O.IdOrd)
                    End Using

                    Counter += 1
                End If
            Next

            MessageBox.Show(Counter & " Lavori eliminati!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)

            If Counter Then AvviaRicerca()

        End If
    End Sub

    Private Sub RiapriConsegnaProgrammata()
        Dim idCons As Integer = 0
        Using mgr As New ConsProgrOrdiniDAO
            idCons = mgr.IdConsByIdOrd(IdOrdSel)
        End Using
        If idCons Then
            ParentFormEx.Sottofondo()
            Dim xc As New frmConsegnaProgrammata
            xc.Carica(idCons)
            xc = Nothing
            ParentFormEx.Sottofondo()
        Else
            MessageBox.Show("Nessuna consegna programmata per questo ordine", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRiapriConsegna.Click
        RiapriConsegnaProgrammata()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim rig As GridViewRowInfo
        rig = DgOrdiniEx.SelectedRows(0)
        Dim O As Ordine = rig.DataBoundItem

        Dim IdRub As Integer = O.IdRub

        Dim idCons As Integer = Nothing
        Using mgr As New ConsProgrOrdiniDAO
            idCons = mgr.IdConsByIdOrd(IdOrdSel)
        End Using
        If idCons Then
            MessageBox.Show("C'è gia una consegna programmata per questo ordine, verrà riaperta", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ParentFormEx.Sottofondo()
        Using xc As New frmConsegnaProgrammata
            xc.Carica(idCons, IdRub)
        End Using
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub DgOrdini_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        If e.RowIndex <> -1 Then

            If e.ColumnIndex = 9 Then
                Dim rig As GridViewRowInfo
                rig = DgOrdiniEx.SelectedRows(0)
                Dim O As Ordine = rig.DataBoundItem

                If O.IdOrd <> ToolTipOrdini.Tag Then
                    ToolTipOrdini.ToolTipTitle = "Anteprima Ordine " & O.IdOrd

                    Dim TestoTooltip As String = "ORDINE: " & O.IdOrd & " (Com. " & IIf(O.IdCom, O.IdCom, "-") & ")" & ControlChars.NewLine
                    TestoTooltip &= "STATO: " & O.StatoStr & ControlChars.NewLine & ControlChars.NewLine
                    If Not O.ConsegnaAssociata Is Nothing Then
                        TestoTooltip &= "CONSEGNA: " & O.ConsegnaAssociata.Giorno.ToString("dd/MM/yyyy") & ControlChars.NewLine
                        TestoTooltip &= "CORRIERE: " & O.ConsegnaAssociata.Corriere.Descrizione & ControlChars.NewLine
                        TestoTooltip &= "PAGAMENTO: " & O.ConsegnaAssociata.MetodoPagamento.TipoPagam & ControlChars.NewLine & ControlChars.NewLine
                    End If

                    TestoTooltip &= "NOTE: " & O.Annotazioni

                    If O.OrdineInOmaggio = enSiNo.Si Then
                        TestoTooltip &= ControlChars.NewLine & ControlChars.NewLine & "*** OMAGGIO ***"
                    End If

                    ToolTipOrdini.Tag = O.IdOrd

                    'For Each c As DataGridViewCell In R.Cells
                    '    c.ToolTipText = TestoTooltip
                    'Next

                    ToolTipOrdini.SetToolTip(DgOrdiniEx, TestoTooltip)
                End If
            Else
                ToolTipOrdini.RemoveAll()
            End If


        End If

        'toolTipHelp.SetToolTip(R, "test")

        'AnteprimaLavoro.Nascondi()
        'If e.ColumnIndex = 4 Then
        '    If e.RowIndex <> -1 Then
        '        ' mi prendo il rowindex. prendo l'id nella cella e creo l'oggetto anteprima
        '        Dim row As DataGridViewRow = DgOrdini.Rows(e.RowIndex)
        '        _oAnteprima = row.DataBoundItem
        '        _IdOrd = _oAnteprima.IdOrd
        '        If AnteprimaLavoro.Visible = False Then AnteprimaCommessa(_oAnteprima)
        '        'tmrHover.Enabled = True
        '    End If
        '    'Else
        '    '    AnteprimaLavoro.Nascondi()
        'End If
    End Sub

    Private Sub AnteprimaCommessa(o As Ordine)

        If o.IdCom Then
            Using C As New Commessa
                C.Read(o.IdCom)

                AnteprimaLavoro.Mostra(Cursor.Position, , C)
            End Using
        End If

    End Sub

    Private Sub AllegaUnMessaggioAllordineToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AllegaUnMessaggioAllordineToolStripMenuItem.Click

        Dim IdOrdSel As Integer = 0
        If DgOrdiniEx.SelectedRows.Count Then
            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem

            IdOrdSel = O.IdOrd

            ParentFormEx.Sottofondo()
            Dim f As New frmPostit
            f.Carica(, , IdOrdSel)
            ParentFormEx.Sottofondo()
        End If


    End Sub

    Private Sub DgOrdini_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        OrdinatoreLista(Of OrdineRicerca).OrdinaLista(sender, e)

    End Sub

    'Private Sub OrdinaLista(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    '    Cursor.Current = Cursors.WaitCursor
    '    'ORDINAMENTO
    '    'qui devo ordinare per la colonna selezionata
    '    Dim c As DataGridViewColumn = DgOrdini.Columns(e.ColumnIndex)
    '    Dim lst As List(Of OrdineRicerca) = DgOrdini.DataSource

    '    Select Case c.DataPropertyName
    '        Case "Idord"
    '            If Ordinamento = "idord" Then
    '                lst.Sort(Function(o1 As OrdineRicerca, o2 As OrdineRicerca)
    '                             Return o1.IdOrd.CompareTo(o2.IdOrd)
    '                         End Function)
    '                Ordinamento = "idord desc"
    '            Else
    '                lst.Sort(Function(o1 As OrdineRicerca, o2 As OrdineRicerca)
    '                             Return o2.IdOrd.CompareTo(o1.IdOrd)
    '                         End Function)
    '                Ordinamento = "idord"
    '            End If
    '        Case "DataInsStr"
    '            If Ordinamento = "DataInsStr" Then
    '                lst.Sort(Function(o1 As OrdineRicerca, o2 As OrdineRicerca)
    '                             Return o1.DataIns.CompareTo(o2.DataIns)
    '                         End Function)
    '                Ordinamento = "DataInsStr desc"
    '            Else
    '                lst.Sort(Function(o1 As OrdineRicerca, o2 As OrdineRicerca)
    '                             Return o2.DataIns.CompareTo(o1.DataIns)
    '                         End Function)
    '                Ordinamento = "DataInsStr"
    '            End If
    '        Case "ProdottoDescrizione"
    '            If Ordinamento = "ProdottoDescrizione" Then
    '                lst.Sort(Function(o1 As OrdineRicerca, o2 As OrdineRicerca)
    '                             Return o1.ProdottoDescrizione.CompareTo(o2.ProdottoDescrizione)
    '                         End Function)
    '                Ordinamento = "ProdottoDescrizione desc"
    '            Else
    '                lst.Sort(Function(o1 As OrdineRicerca, o2 As OrdineRicerca)
    '                             Return o2.ProdottoDescrizione.CompareTo(o1.ProdottoDescrizione)
    '                         End Function)
    '                Ordinamento = "ProdottoDescrizione"
    '            End If
    '        Case "ClienteNominativo"
    '            If Ordinamento = "ClienteNominativo" Then
    '                lst.Sort(Function(o1 As OrdineRicerca, o2 As OrdineRicerca)
    '                             Return o1.ClienteNominativo.CompareTo(o2.ClienteNominativo)
    '                         End Function)
    '                Ordinamento = "ClienteNominativo desc"
    '            Else
    '                lst.Sort(Function(o1 As OrdineRicerca, o2 As OrdineRicerca)
    '                             Return o2.ClienteNominativo.CompareTo(o1.ClienteNominativo)
    '                         End Function)
    '                Ordinamento = "ClienteNominativo"
    '            End If
    '        Case "StatoStr"
    '            If Ordinamento = "StatoStr" Then
    '                lst.Sort(Function(o1 As OrdineRicerca, o2 As OrdineRicerca)
    '                             Return o1.Stato.CompareTo(o2.Stato)
    '                         End Function)
    '                Ordinamento = "StatoStr desc"
    '            Else
    '                lst.Sort(Function(o1 As OrdineRicerca, o2 As OrdineRicerca)
    '                             Return o2.Stato.CompareTo(o1.Stato)
    '                         End Function)
    '                Ordinamento = "StatoStr"
    '            End If


    '    End Select

    '    'DgOrdini.Refresh()
    '    Cursor.Current = Cursors.Default
    'End Sub

    'Private Sub cmbCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged

    '    If cmbCliente.SelectedValue = 0 Then
    '        chkOnlyLastSixMonth.Checked = True
    '    Else
    '        chkOnlyLastSixMonth.Checked = False
    '    End If

    'End Sub

    'Private Sub tmrHover_Tick(sender As System.Object, e As System.EventArgs) Handles tmrHover.Tick
    '    tmrHover.Enabled = False
    '    AnteprimaCommessa(_oAnteprima)
    'End Sub

    Private Sub toolStripPassaAUscito_Click(sender As Object, e As EventArgs)
        ForzaStatoUscitoMagazzino()
    End Sub

    Private Sub ForzaStatoUscitoMagazzino()
        Dim stato As enStatoOrdine = enStatoOrdine.UscitoMagazzino
        If DgOrdiniEx.SelectedRows.Count Then

            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem
            If O.Stato = enStatoOrdine.ProntoRitiro Then
                Dim OkConsegna As Boolean = True
                If O.ConsegnaAssociata.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito = False Then ' O.ConsegnaAssociata.ModificabileEx(True, False, True, True, False, True).Modificabile = False Then
                    If O.ConsegnaAssociata.ListaOrdini.FindAll(Function(x) x.Stato <> enStatoOrdine.ProntoRitiro).Count Then
                        OkConsegna = False
                    End If
                End If
                If OkConsegna Then
                    If MessageBox.Show("Confermi il cambiamento di stato dell'ordine?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Using mgr As New OrdiniDAO
                            mgr.InserisciLog(O, stato)
                            Dim CambiatoConsegna As Boolean = False

                            If O.ConsegnaAssociata.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then 'O.ConsegnaAssociata.ModificabileEx(True, False, True, True, False, False).Modificabile Then
                                'qui devo vedere se lo posso accorpare con un altra in caso ci sia
                                Using mgrC As New ConsegneProgrammateDAO
                                    Dim l As List(Of ConsegnaProgrammata) = mgrC.FindAll(New LUNA.LunaSearchParameter("IdCons", O.ConsegnaAssociata.IdCons, "<>"),
                                                                                         New LUNA.LunaSearchParameter("IdRub", O.ConsegnaAssociata.IdRub),
                                                                                         New LUNA.LunaSearchParameter("Giorno", O.ConsegnaAssociata.Giorno),
                                                                                         New LUNA.LunaSearchParameter("IdCorr", O.ConsegnaAssociata.IdCorr),
                                                                                         New LUNA.LunaSearchParameter("IdIndirizzo", O.ConsegnaAssociata.IdIndirizzo),
                                                                                         New LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.InLavorazione),
                                                                                         New LUNA.LunaSearchParameter("Eliminato", enSiNo.Si, "<>"))

                                    For Each singC As ConsegnaProgrammata In l
                                        If singC.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then 'singC.ModificabileEx(True, False, True, True, False, True).Modificabile Then
                                            'qui mi potrei agganciare con l'ordine
                                            'TOLTO IL 08/04/2015
                                            'mgrC.EliminaOrdineDaConsegna(0, O.IdOrd)
                                            mgrC.RegistraConsegnaOrdineSuGiorno(O.IdOrd, O.ConsegnaAssociata.IdCorr, O.ConsegnaAssociata.Giorno, O.ConsegnaAssociata.IdRub, enMomentoConsegna.Pomeriggio, O.ConsegnaAssociata.IdIndirizzo, singC)
                                            CambiatoConsegna = True
                                            Exit For
                                        End If
                                    Next
                                End Using

                            End If

                            If CambiatoConsegna = False Then
                                If O.ConsegnaAssociata.ListaIdDocumenti.Count Then
                                    Dim NuovoStato As enStatoOrdine = enStatoOrdine.InConsegna

                                    If O.ConsegnaAssociata.IdCorr = enCorriere.RitiroCliente Then
                                        NuovoStato = enStatoOrdine.Consegnato
                                    End If
                                    mgr.InserisciLog(O, NuovoStato)
                                End If
                            End If

                            If O.ConsegnaAssociata.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then ' O.ConsegnaAssociata.ModificabileEx(True, False, True, True, False, False).Modificabile Then
                                Dim lstOrdSganciare As List(Of Ordine) = mgr.ListaOrdiniConsegnaDaSganciare(O.ConsegnaAssociata.IdCons)

                                Dim DataNuova As Date = MgrDataConsegna.GetPrimaDataDisponibile(Now, O.ConsegnaAssociata.IdCorr)

                                'Dim DataNuova As Date = Now.Date

                                'Select Case Now.DayOfWeek
                                '    Case DayOfWeek.Saturday
                                '        DataNuova = DataNuova.AddDays(2)
                                '    Case DayOfWeek.Friday
                                '        If O.ConsegnaAssociata.IdCorr = enCorriere.RitiroCliente Then
                                '            DataNuova = DataNuova.AddDays(1)
                                '        Else
                                '            DataNuova = DataNuova.AddDays(3)
                                '        End If
                                '    Case Else
                                '        DataNuova = DataNuova.AddDays(1)
                                'End Select

                                Using mgrC As New ConsegneProgrammateDAO
                                    For Each ord As Ordine In lstOrdSganciare
                                        'TOLTO IL 08/04/2015
                                        'mgrC.EliminaOrdineDaConsegna(0, ord.IdOrd)
                                        mgrC.RegistraConsegnaOrdineSuGiorno(ord.IdOrd, ord.IdCorriere, DataNuova, ord.IdRub, enMomentoConsegna.Pomeriggio, ord.IdIndirizzo)
                                    Next
                                    'mgrC.EliminaConsegnaSeVuota(O.ConsegnaAssociata.IdCons)
                                End Using
                            End If

                        End Using
                        AvviaRicerca()
                    End If
                Else
                    MessageBox.Show("La consegna non è modificabile e non tutti gli ordini sono in pronto per il ritiro")
                End If

            Else
                MessageBox.Show("E' possibile passare allo stato Uscito da Magazzino solo gli ordini in stato Pronto per il ritiro")
            End If
        End If
    End Sub

    'Private Sub lnkNewOrdWiz_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    '    Dim frmRif As New frmWizOrd

    '    Dim Ris As Integer = 0

    '    ParentFormerForm.Sottofondo 
    '    Ris = frmRif.Carica()
    '    ParentFormerForm.Sottofondo 
    '    If Ris Then AvviaRicercaEX()
    '    frmRif.Dispose()

    'End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        MgrControl.InizializeGridview(DgOrdiniEx)

    End Sub

    Private Sub DgOrdini_Scroll(sender As Object, e As ScrollEventArgs)
        'If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
        '    If e.OldValue < e.NewValue Then
        '        'qui sto scorrendo verso il basso 
        '        'aggiungo righe 
        '        AggiungiRighe()



        '    End If
        'End If
    End Sub

    Private Sub lnkReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkReset.LinkClicked

        'cmbCliente.SelectedIndex = 0
        UcComboRubrica.IdRubSelezionato = 0
        txtQta.Text = 0
        txtCerca.Text = String.Empty
        cmbCatProd.SelectedIndex = 0
        'cmbAgente.SelectedIndex = 0
        cmbProdotto.SelectedIndex = 0
        chkDataInsAl.Checked = False
        chkDataInsDal.Checked = False
        'cmbGruppo.SelectedIndex = 0
        chkWithoutDocFisc.Checked = False
        txtIdOnline.Text = String.Empty
        chkPromo.Checked = False
        txtNumOrdOnline.Text = 0
        txtNumOrdProvvisorio.Text = 0
        UcStatoOrdiniAdvanced.ReimpostaVistaDefault()

        cmbRepartoWeb.SelectedIndex = 0

    End Sub

    Private Sub ucOrdini_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        If AnteprimaLavoro.Visible Then
            AnteprimaLavoro.Nascondi()
        End If

    End Sub

    Private Sub PrioritàNormaleToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AltaPrioritàToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PassaPreinseritoToolstripMenu_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PassaRefineToolstripMenu_Click(sender As Object, e As EventArgs)
        If PostazioneCorrente.ScaricamentoOrdiniInCorso Then
            MessageBox.Show("Il Demone sta scaricando i nuovi ordini, attendere il termine dell'operazione e riprovare")
        Else
            If MessageBox.Show("Confermi il passaggio manuale a Refine dell'ordine selezionato? Tutti i sorgenti effettueranno di nuovo il refine", "Refine automatico", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using mgr As New OrdiniDAO
                    Dim rig As GridViewRowInfo
                    rig = DgOrdiniEx.SelectedRows(0)
                    Dim O As Ordine = rig.DataBoundItem
                    O.Read(O.IdOrd) ' lo rileggo per sicurezza
                    If O.Stato = enStatoOrdine.Preinserito Then
                        mgr.InserisciLog(O, enStatoOrdine.RefineAutomatico, PostazioneCorrente.UtenteConnesso.IdUt)
                    End If

                    For Each sorg As FileSorgente In O.ListaSorgenti
                        sorg.StatoRefine = enStatoRefineSorgente.NonDefinito
                        sorg.Save()
                    Next

                End Using
                AvviaRicerca()
            End If
        End If
    End Sub

    Private Sub ForzaLordineAInSospesoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ForzaLordineARifiutatoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub lnkStampa_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs)
    '    ParentFormEx.Sottofondo()
    '    Dim Titolo As String = ""
    '    If _IdRub Then
    '        Titolo = "Ordini cliente"
    '    Else
    '        Titolo = "Lista Ordini"
    '    End If
    '    StampaGlobale(Titolo, DgOrdini, True)
    '    ParentFormEx.Sottofondo()
    'End Sub

    Private Sub DgOrdiniEx_MouseClick(sender As Object, e As MouseEventArgs) Handles DgOrdiniEx.MouseClick

        If DgOrdiniEx.SelectedRows.Count Then

            Dim Riga As GridViewRowInfo = DgOrdiniEx.SelectedRows(0)

            Dim O As Ordine = Riga.DataBoundItem
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Dim x As System.Drawing.Point = MousePosition
                'btnNuovoCliente.ContextMenu = menuNuovo.

                'x.X -= 200

                '                    DgOrdini.Select( )
                Riga.IsSelected = True
                If IdOrdSel <> O.IdOrd Then
                    IdOrdSel = O.IdOrd
                    RaiseEvent OrdineSelezionato()
                End If

                'Try

                '    If O.IdDoc Then
                '        RiapriDocumentoFiscaleToolStripMenuItem.Enabled = True
                '        EmettiDocumentoFiscaleToolStripMenuItem.Enabled = False
                '    Else
                '        RiapriDocumentoFiscaleToolStripMenuItem.Enabled = False
                '        EmettiDocumentoFiscaleToolStripMenuItem.Enabled = True

                '    End If

                'Catch ex As Exception
                '    RiapriDocumentoFiscaleToolStripMenuItem.Enabled = False
                '    EmettiDocumentoFiscaleToolStripMenuItem.Enabled = False

                'End Try

                If O.Priorita = enSiNo.Si Then
                    PrioritàNormaleToolStripMenuItem1.Enabled = True ' AltaPrioritàToolStripMenuItem.Enabled = False
                    AltaPrioritàToolStripMenuItem1.Enabled = False 'PrioritàNormaleToolStripMenuItem.Enabled = True
                Else
                    PrioritàNormaleToolStripMenuItem1.Enabled = False ' AltaPrioritàToolStripMenuItem.Enabled = False
                    AltaPrioritàToolStripMenuItem1.Enabled = True 'PrioritàNormaleToolStripMenuItem.Enabled = True
                End If

                'If O.Stato = enStatoOrdine.RefineAutomatico Then
                '    PassaPreinseritoToolstripMenu.Enabled = False
                'Else
                '    PassaPreinseritoToolstripMenu.Enabled = False
                'End If

                'If O.Stato = enStatoOrdine.Preinserito Then
                '    PassaRefineToolstripMenu.Enabled = True
                'Else
                '    PassaRefineToolstripMenu.Enabled = False
                'End If

                If DgOrdiniEx.SelectedRows.Count > 1 Then
                    For Each m As ToolStripItem In MenuOrd.Items
                        m.Enabled = False
                    Next
                    tsConsegneCompatibili.Enabled = True
                    EliminaToolStripMenuItem.Enabled = True
                Else
                    For Each m As ToolStripItem In MenuOrd.Items
                        m.Enabled = True
                    Next
                    tsConsegneCompatibili.Enabled = False
                End If
                x.X += 10
                MenuOrd.Show(x)

            End If

        End If
    End Sub

    Private Sub DgOrdiniEx_SelectionChanged(sender As Object, e As EventArgs) Handles DgOrdiniEx.SelectionChanged
        If sender.focused Then SelezioneCambiataEx()
    End Sub

    Private Sub DgOrdiniEx_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles DgOrdiniEx.CellFormatting
        If FormerDebug.LightMode = False Then
            If e.CellElement.ColumnInfo.Name = "Stato" Then
                Dim Riga As GridViewRowInfo = e.Row
                Using o As Ordine = Riga.DataBoundItem
                    Dim ColoreSfondo As Color = o.StatoColore
                    e.CellElement.BackColor = ColoreSfondo
                    If o.OrdineInOmaggio = enSiNo.Si Then
                        e.Row.Cells("Totale").Style.BackColor = FormerColori.ColoreOmaggioSfondo
                        e.Row.Cells("Totale").Style.ForeColor = FormerColori.ColoreOmaggioPrimoPiano
                    End If
                End Using
            Else
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
            End If
        End If

    End Sub

    Private Sub RiapriOrdine(e As MouseEventArgs)

        If e.Button = MouseButtons.Left Then
            If DgOrdiniEx.SelectedRows.Count Then
                Dim riga As GridViewRowInfo = DgOrdiniEx.SelectedRows(0)
                OrdineSel = riga.DataBoundItem
                IdOrdSel = OrdineSel.IdOrd

                Using frmRif As New frmOrdine

                    Dim Ris As Integer = 0

                    ParentFormEx.Sottofondo()
                    Ris = frmRif.Carica(IdOrdSel)
                    ParentFormEx.Sottofondo()
                    If Ris Then AvviaRicerca()

                End Using
            End If

        End If
    End Sub

    Private Sub DgOrdiniEx_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgOrdiniEx.MouseDoubleClick
        RiapriOrdine(e)

    End Sub

    Private Sub PanoramicaOrdiniToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lnkStampa_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        StampaGlobale("Ordini", DgOrdiniEx, True)

    End Sub

    Private Sub DgOrdiniEx_Click(sender As Object, e As EventArgs) Handles DgOrdiniEx.Click

    End Sub

    Private Sub ApriLaSchedaDelClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriLaSchedaDelClienteToolStripMenuItem.Click
        If IdOrdSel Then

            Dim O As New Ordine
            O.Read(IdOrdSel)
            ParentFormEx.Sottofondo()

            Using f As New frmVoceRubrica
                f.Carica(O.IdRub)
            End Using
            ParentFormEx.Sottofondo()

        End If
    End Sub

    Private Sub ChkWithoutDocFisc_CheckedChanged(sender As Object, e As EventArgs) Handles chkWithoutDocFisc.CheckedChanged

        If chkConDocFiscale.Checked Then
            If chkWithoutDocFisc.Checked Then chkConDocFiscale.Checked = False
        End If

    End Sub

    Private Sub ChkConDocFiscale_CheckedChanged(sender As Object, e As EventArgs) Handles chkConDocFiscale.CheckedChanged

        If chkWithoutDocFisc.Checked Then
            If chkConDocFiscale.Checked Then chkWithoutDocFisc.Checked = False
        End If
    End Sub

    Private Sub ToolStripModificaDataConsegna_Click(sender As Object, e As EventArgs) Handles ToolStripModificaDataConsegna.Click
        If DgOrdiniEx.SelectedRows.Count Then
            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem

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

    Private Sub ToolStripModificaOrdine_Click(sender As Object, e As EventArgs) Handles toolStripModificaOrdine.Click
        Dim x As New MouseEventArgs(MouseButtons.Left, 1, MousePosition.X, MousePosition.Y, 0)

        RiapriOrdine(x)
    End Sub

    Private Sub ToolstripRiapriCartellaSorgenti_Click(sender As Object, e As EventArgs) Handles toolstripRiapriCartellaSorgenti.Click

        If DgOrdiniEx.SelectedRows.Count Then
            Dim riga As GridViewRowInfo = DgOrdiniEx.SelectedRows(0)
            OrdineSel = riga.DataBoundItem
            MgrOrdini.RiapriCartellaSorgenti(OrdineSel)
        End If


    End Sub

    Private Sub TsForzaSospeso_Click(sender As Object, e As EventArgs) Handles tsForzaSospeso.Click
        If DgOrdiniEx.SelectedRows.Count Then
            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem
            'Using O As Ordine = DgOrdini.SelectedRows(0).DataBoundItem
            If MgrOrdini.ForzaStatoOrdineAInSospeso(O, Me.ParentForm) Then
                AvviaRicerca()
            End If
            'End Using
        End If
    End Sub

    Private Sub TsForzaPreinserito_Click(sender As Object, e As EventArgs) Handles tsForzaPreinserito.Click
        If DgOrdiniEx.SelectedRows.Count Then

            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem

            'Using O As Ordine = DgOrdini.SelectedRows(0).DataBoundItem
            If MgrOrdini.ForzaStatoOrdineAPreinserito(O) Then
                AvviaRicerca()
            End If
            'End Using
        End If
    End Sub

    Private Sub TsForzaRifiutato_Click(sender As Object, e As EventArgs) Handles tsForzaRifiutato.Click
        If DgOrdiniEx.SelectedRows.Count Then
            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem
            'Using O As Ordine = DgOrdini.SelectedRows(0).DataBoundItem
            If MgrOrdini.ForzaStatoOrdineARifiutato(O) Then
                AvviaRicerca()
            End If
            'End Using
        End If
    End Sub

    Private Sub AltaPrioritàToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AltaPrioritàToolStripMenuItem1.Click
        If MessageBox.Show("Vuoi impostare l'ordine selezionato ad Alta Priorità?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem
            O.Priorita = 1
            O.Save()
            AvviaRicerca()
        End If
    End Sub

    Private Sub PrioritàNormaleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrioritàNormaleToolStripMenuItem1.Click
        If MessageBox.Show("Vuoi impostare l'ordine selezionato a Priorità Normale?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim rig As GridViewRowInfo
            rig = DgOrdiniEx.SelectedRows(0)
            Dim O As Ordine = rig.DataBoundItem
            O.Priorita = 0
            O.Save()
            AvviaRicerca()
        End If
    End Sub

    Private Sub tsConsegneCompatibili_Click(sender As Object, e As EventArgs) Handles tsConsegneCompatibili.Click

        CheckCompatibili()

    End Sub

    Private Sub CheckCompatibili()

        If DgOrdiniEx.SelectedRows.Count > 1 Then

            'vado a controllare se le consegne sono compatibili 

            Dim msgErr As String = String.Empty

            Dim l As New List(Of Ordine)

            For Each O In DgOrdiniEx.SelectedRows
                l.Add(O.DataBoundItem)
            Next

            Dim AlertCliente As Boolean = False
            Dim AlertGiorno As Boolean = False
            Dim AlertCorriere As Boolean = False
            Dim AlertIndirizzo As Boolean = False
            Dim AlertPagamento As Boolean = False
            Dim AlertDocumenti As Boolean = False
            Dim AlertCartaceo As Boolean = False



            Dim IdRub As Integer = 0
            Dim GiornoConsegna As Date = Date.MinValue
            Dim IdCorr As Integer = 0
            Dim IdIndirizzo As Integer = 0
            Dim IdPagam As Integer = 0
            Dim StampaDocumenti As Integer = -1
            Dim NoCartaceo As Integer = -1


            'New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, IdCorr),
            'New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdRub, IdRub),
            'New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdIndirizzo, IdIndirizzo),
            'New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdPagam, IdPagamentoSel),
            'New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.Si, "<>"),


            For Each o As Ordine In l
                If IdRub = 0 Then
                    IdRub = o.IdRub
                Else
                    If o.IdRub <> IdRub Then
                        AlertCliente = True
                    End If
                End If
                If GiornoConsegna = Date.MinValue Then
                    GiornoConsegna = o.ConsegnaAssociata.Giorno
                Else
                    If GiornoConsegna.Date <> o.ConsegnaAssociata.Giorno.Date Then
                        AlertGiorno = True
                    End If
                End If

                If IdCorr = 0 Then
                    IdCorr = o.ConsegnaAssociata.IdCorr
                Else
                    If IdCorr <> o.ConsegnaAssociata.IdCorr Then
                        AlertCorriere = True
                    End If
                End If

                If IdIndirizzo = 0 Then
                    IdIndirizzo = o.ConsegnaAssociata.IdIndirizzo
                Else
                    If IdIndirizzo <> o.ConsegnaAssociata.IdIndirizzo Then
                        AlertIndirizzo = True
                    End If
                End If

                If IdPagam = 0 Then
                    IdPagam = o.ConsegnaAssociata.IdPagam
                Else
                    If IdPagam <> o.ConsegnaAssociata.IdPagam Then
                        AlertPagamento = True
                    End If
                End If
                If StampaDocumenti = -1 Then
                    StampaDocumenti = o.ConsegnaAssociata.StampaDocumenti
                Else
                    If StampaDocumenti <> o.ConsegnaAssociata.StampaDocumenti Then
                        AlertDocumenti = True
                    End If
                End If
                If NoCartaceo = -1 Then
                    NoCartaceo = o.ConsegnaAssociata.NoCartaceo
                Else
                    If NoCartaceo <> o.ConsegnaAssociata.NoCartaceo Then
                        AlertCartaceo = True
                    End If
                End If

                Dim Controllo As RisConsegnaModificabile = o.ConsegnaAssociata.Diritti.PossoModificareOrdiniContenutiOAccorparla
                If Controllo.Esito = False Then
                    msgErr &= " - L'ordine " & o.IdOrd & " ha i seguenti blocchi: " & Controllo.BufferErrori
                End If

            Next

            If AlertCliente Then
                msgErr &= " - Clienti differenti;" & ControlChars.NewLine
            End If

            If AlertGiorno Then
                msgErr &= " - Giorno della consegna differente;" & ControlChars.NewLine
            End If

            If AlertCorriere Then
                msgErr &= " - Corriere differente;" & ControlChars.NewLine
            End If

            If AlertIndirizzo Then
                msgErr &= " - Indirizzo di consegna differente;" & ControlChars.NewLine
            End If

            If AlertPagamento Then
                msgErr &= " - Metodo di pagamento differente;" & ControlChars.NewLine
            End If

            If AlertDocumenti Then
                msgErr &= " - Stampa dei documenti fiscali non congruente;" & ControlChars.NewLine
            End If

            If AlertCartaceo Then
                msgErr &= " - Inserimento Documento fiscale cartaceo non congruente;" & ControlChars.NewLine
            End If

            If msgErr.Length = 0 Then
                MessageBox.Show("Gli ordini sono compatibili e possono essere uniti in un unica consegna!")
            Else
                msgErr = "Le consegne non sono compatibili per i seguenti motivi:" & ControlChars.NewLine & msgErr
                MessageBox.Show(msgErr)
            End If

        Else
            MessageBox.Show("Selezionare almeno 2 ordini dalla lista!")
        End If
    End Sub
End Class
