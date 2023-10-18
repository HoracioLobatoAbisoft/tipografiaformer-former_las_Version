Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Friend Class ucMagazzinoRisorse
    Inherits ucFormerUserControl
    Private _IdRub As Integer = 0

    Friend Property IdRub() As Integer
        Get
            Return _IdRub
        End Get
        Set(ByVal value As Integer)
            _IdRub = value
        End Set
    End Property

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()
        Try
            ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
            Dim Voce As New cEnum
            Voce.Id = -1000
            Voce.Descrizione = "- Tutto"

            cmbTipoRisorsa.Items.Add(Voce)

            Voce = New cEnum
            Voce.Id = enTipoRisOffSet.MateriaPrima
            Voce.Descrizione = "Risorsa"
            cmbTipoRisorsa.Items.Add(Voce)

            Voce = New cEnum
            Voce.Id = enTipoRisOffSet.Lastra
            Voce.Descrizione = "Lastra"
            cmbTipoRisorsa.Items.Add(Voce)

            Voce = New cEnum
            Voce.Id = enTipoRisOffSet.ProdottoDiConsumo
            Voce.Descrizione = "Materiale di Consumo"
            cmbTipoRisorsa.Items.Add(Voce)

            cmbTipoRisorsa.SelectedIndex = 0

            CaricaCombo()

            MgrControl.InizializeGridview(dgRisorseEx)

            dgRisorseEx.TableElement.RowHeight = 64

            childTemplate = CreateChildTemplate()
            Dim relation As New GridViewRelation(dgRisorseEx.MasterTemplate, childTemplate)
            relation.ChildColumnNames.Add("ListaCarichi")
            dgRisorseEx.Relations.Add(relation)
        Catch ex As Exception

        End Try


    End Sub

    Private WithEvents childTemplate As GridViewTemplate = Nothing

    Private Function CreateChildTemplate() As GridViewTemplate
        Dim childTemplate As New GridViewTemplate()
        childTemplate.AutoGenerateColumns = False
        childTemplate.AllowColumnReorder = False
        childTemplate.ShowColumnHeaders = True
        childTemplate.AllowRowResize = False
        childTemplate.AllowColumnResize = True

        dgRisorseEx.Templates.Add(childTemplate)

        Dim columnT As New GridViewTextBoxColumn("DataMov")
        columnT.HeaderText = "Data"
        columnT.TextAlignment = ContentAlignment.MiddleRight
        columnT.MinWidth = 80
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("CodiceForn")
        columnT.HeaderText = "Codice"
        columnT.TextAlignment = ContentAlignment.MiddleLeft
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("DescrForn")
        columnT.HeaderText = "Descrizione"
        columnT.TextAlignment = ContentAlignment.MiddleLeft
        columnT.MinWidth = 200
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("Qta")
        columnT.HeaderText = "Qta"
        columnT.TextAlignment = ContentAlignment.MiddleRight
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("PrezzoUnit")
        columnT.HeaderText = "Prezzo Unit."
        columnT.FormatInfo = New Globalization.CultureInfo("it-IT")
        columnT.FormatString = "{0:C}"
        columnT.TextAlignment = ContentAlignment.MiddleRight
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("Prezzo")
        columnT.HeaderText = "Prezzo"
        columnT.FormatInfo = New Globalization.CultureInfo("it-IT")
        columnT.FormatString = "{0:C}"
        columnT.TextAlignment = ContentAlignment.MiddleRight
        columnT.MinWidth = 100
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)

        'childTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.
        Return childTemplate
    End Function

    Private Sub dgDocAcquisto_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgRisorseEx.ViewCellFormatting

        If TypeOf e.CellElement Is GridGroupExpanderCellElement Then
            Dim Cell As GridGroupExpanderCellElement = e.CellElement
            If Not Cell Is Nothing Then
                If Not e.CellElement.RowInfo.ChildRows Is Nothing AndAlso e.CellElement.RowInfo.ChildRows.Count Then
                    Cell.Expander.Visibility = Telerik.WinControls.ElementVisibility.Visible
                    If Not e.Row.DataBoundItem Is Nothing Then
                        Cell.TextAlignment = ContentAlignment.TopRight
                        Dim f As New Font("Segoe UI", 7, FontStyle.Bold)
                        Cell.Font = f
                        Cell.ForeColor = Color.FromArgb(14, 151, 221)
                        Cell.Text = e.CellElement.RowInfo.ChildRows.Count
                    End If
                Else
                    Cell.Expander.Visibility = Telerik.WinControls.ElementVisibility.Hidden
                End If
            End If
        ElseIf TypeOf e.CellElement Is GridImageCellElement Then
            e.Row.Height = 64
        End If
    End Sub

    Private Sub CaricaCombo()

        Try
            'carico la combo dei fornitori
            Using cli As New VociRubricaDAO
                cmbFornitore.ValueMember = "IdRub"
                cmbFornitore.DisplayMember = "RagSocNome"

                cmbFornitore.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, True,,,,,, True)

                ''carico la combo dei clienti
                'cmbAgente.ValueMember = "IdRub"
                'cmbAgente.DisplayMember = "Nominativo"

                'cmbAgente.DataSource = cli.ListaCombo(enTipoRubrica.Agente, True)
            End Using

            Using M As New MacchinariDAO
                cmbMacchinario.ValueMember = "IdMacchinario"
                cmbMacchinario.DisplayMember = "Riassunto"
                cmbMacchinario.DataSource = M.GetAll(LFM.Macchinario.Tipo.Name & "," & LFM.Macchinario.Descrizione.Name, True)


            End Using

        Catch ex As Exception

        End Try

        Using mgr As New RisorseDAO
            Dim l As List(Of String) = mgr.GetCategorie()

            cmbCategoria.DataSource = l

        End Using

        Dim lstT As List(Of TipoCarta) = Nothing
        Using mgr As New TipiCartaDAO
            lstT = mgr.GetAll(LFM.TipoCarta.Tipologia, True)
        End Using

        cmbTipoCartaListino.ValueMember = "IdTipoCarta"
        cmbTipoCartaListino.DisplayMember = "Tipologia"
        cmbTipoCartaListino.DataSource = lstT

        Try
            Using t As New TipiCartaDAO
                cmbFinitura.DataSource = t.ListaFiniture(True)
            End Using

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

        Dim AR As New cAnnoRif
        cmbAnnoRif.DataSource = AR
        cmbAnnoRif.DisplayMember = "Descrizione"
        cmbAnnoRif.ValueMember = "Id"


        Dim laz As New List(Of cEnum)
        Dim az0 As New cEnum(0, "Tutto")
        laz.Add(az0)
        Dim az1 As New cEnum(MgrAziende.IdAziende.AziendaSnc, MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSnc))
        laz.Add(az1)
        Dim az2 As New cEnum(MgrAziende.IdAziende.AziendaSrl, MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSrl))
        laz.Add(az2)

        cmbAzienda.ValueMember = "Id"
        cmbAzienda.DisplayMember = "Descrizione"
        cmbAzienda.DataSource = laz

    End Sub

    Public Sub Carica()

        MostraDati()

    End Sub

    Public Sub MostraTipoNonSpecificato()

        txtCodDescr.Text = String.Empty
        txtBarCode.Text = String.Empty

        chkOnlyDisponibili.Checked = False
        chkNonAssociate.Checked = False
        chkOnlyRegoleSottoscorta.Checked = False
        chkSoloAttivo.Checked = False
        chkSottoScorta.Checked = False
        chkTipoNonSpecificato.Checked = True

        Cerca()

    End Sub

    Private Sub MostraDati(Optional ByVal Cerca As String = "")

        Cursor.Current = Cursors.WaitCursor

        If Cerca = "{inserire qui la descrizione da cercare}" Then Cerca = ""

        Using mgr As New RisorseDAO

            'Dim p As LUNA.LunaSearchParameter = Nothing
            'Dim pTit As LUNA.LunaSearchParameter = Nothing
            'Dim PStato As LUNA.LunaSearchParameter = Nothing
            Dim pForn As LUNA.LunaSearchParameter = Nothing
            'Dim pCat As LUNA.LunaSearchParameter = Nothing
            'Dim pBarCode As LUNA.LunaSearchParameter = Nothing
            'Dim pOnlyDisp As LUNA.LunaSearchParameter = Nothing

            'If txtBarCode.Text.Trim.Length Then
            '    pBarCode = New LUNA.LunaSearchParameter(LFM.Risorsa.BarCode, txtBarCode.Text.Trim)
            'End If

            'If cmbCategoria.Text.Length Then
            '    pCat = New LUNA.LunaSearchParameter(LFM.Risorsa.Categoria, cmbCategoria.Text)
            'End If

            'If chkOnlyDisponibili.Checked Then
            '    pOnlyDisp = New LUNA.LunaSearchParameter(LFM.Risorsa.Giacenza, 0, ">")
            'End If

            Dim l As List(Of Risorsa) = mgr.Cerca(Cerca.Trim,
                                                  cmbCategoria.Text,
                                                  txtBarCode.Text,
                                                  chkOnlyDisponibili.Checked,
                                                  chkTipoNonSpecificato.Checked,
                                                  cmbAnnoRif.SelectedValue,
                                                  cmbAzienda.SelectedValue,
                                                  cmbTipoCartaListino.SelectedValue)

            If cmbFornitore.SelectedValue Then
                l = l.FindAll(Function(x) Not x.UltimoCaricoMagazzino Is Nothing AndAlso x.UltimoCaricoMagazzino.IdForn = cmbFornitore.SelectedValue)
            End If

            If chkSoloAttivo.Checked Then
                l = l.FindAll(Function(x) x.Stato = enStato.Attivo)
            End If

            If chkNonAssociate.Checked Then
                l = l.FindAll(Function(x) x.IdTipoCarta = 0)
            End If

            If cmbFinitura.Text.Length Then
                'qui cerco solo quelli con quella finitura 
                l = l.FindAll(Function(x) Not x.TipoCarta Is Nothing AndAlso x.TipoCarta.Finitura = cmbFinitura.Text)

            End If

            'If Cerca.Trim.Length Then

            '    l = l.FindAll(Function(x) x.Descrizione.ToLower.IndexOf(Cerca) <> -1 Or x.Codice.ToLower.IndexOf(Cerca) <> -1)

            '    'p = New LUNA.LunaSearchParameter(LFM.Risorsa.Descrizione, "%" & Cerca & "%", "LIKE")
            '    'pTit = New LUNA.LunaSearchParameter(LFM.Risorsa.Codice, "%" & Cerca & "%", "LIKE", LUNA.enLogicOperator.enOR)
            'End If

            Dim TipoRis As cEnum = cmbTipoRisorsa.SelectedItem

            If TipoRis.Id = enTipoRisOffSet.MateriaPrima Then
                l = l.FindAll(Function(x) x.IsLastra = False And x.TipoRis = enTipoProdCom.StampaOffSet)
            ElseIf TipoRis.Id = enTipoRisOffSet.Lastra Then
                l = l.FindAll(Function(x) x.IsLastra = True)
            ElseIf TipoRis.Id = enTipoRisOffSet.ProdottoDiConsumo Then
                l = l.FindAll(Function(x) x.TipoRis = enTipoRisOffSet.ProdottoDiConsumo)
            End If

            If chkSottoScorta.Checked Then
                l = l.FindAll(Function(x) x.Giacenza <= x.GiacenzaMin)
            End If

            If chkOnlyRegoleSottoscorta.Checked Then
                l = l.FindAll(Function(x) Not x.RegolaSottoScorta Is Nothing)
            End If

            'DgRisorse.AutoGenerateColumns = False
            'DgRisorse.DataSource = l
            Dim lfin As New List(Of Risorsa)
            If cmbMacchinario.SelectedValue Then
                Using mgrR As New RisorseSuMacchinaDAO
                    Dim lR As List(Of RisorsaSuMacchina) = mgrR.FindAll(New LUNA.LunaSearchParameter(LFM.RisorsaSuMacchina.IdMacchinario, cmbMacchinario.SelectedValue))

                    For Each singR As Risorsa In l
                        If lR.FindAll(Function(x) x.IdRisorsa = singR.IdRis).Count Then
                            lfin.Add(singR)
                        End If
                    Next

                End Using
            Else
                lfin.AddRange(l)
            End If

            lblRiassunto.Text = lfin.Count

            lfin.Sort(AddressOf FormerListSorter.RisorseSorter.SortDefault)

            Using b As New BindingSource
                b.DataSource = lfin
                dgRisorseEx.DataSource = b
                'DgOrdiniEx.DataSource = _ListaRis
            End Using


            'dgRisorseEx.DataSource = lfin

            'DgRisorse.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DgRisorse.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End Using

        'Using Prod As New cRisorseColl

        '    Dim dt As DataTable

        '    dt = Prod.Lista(Cerca, chkSottoScorta.Checked, _IdRub)

        '    DgRisorse.DataSource = dt
        '    DgRisorse.Columns(0).Visible = False
        '    DgRisorse.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        '    Try
        '        DgRisorse.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    Catch ex As Exception

        '    End Try

        '    If chkSottoScorta.Checked Then

        '    End If

        '    'DgListino.Columns(3).DefaultCellStyle.Format = "0.00"

        '    DgRisorse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        '    DgRisorse.AutoResizeColumns()

        'End Using


        Cursor.Current = Cursors.Default

    End Sub

    Private Sub lnkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        MostraDati()
    End Sub

    'Private Sub lnkAllarga_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    If DgRisorse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells Then
    '        DgRisorse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    '        'lnkAllarga.Text = "Espandi"
    '    Else
    '        DgRisorse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '        'lnkAllarga.Text = "Adatta"
    '    End If
    '    DgRisorse.AutoResizeColumns()
    'End Sub

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub


    Private Sub Cerca()

        MostraDati(txtCodDescr.Text)

    End Sub

    Private Sub txtCercaCli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodDescr.KeyPress
        Dim c As Char = vbCr
        If e.KeyChar = c Then Cerca()
    End Sub

    Private Sub NewVoce()

        If IdRub Then
            Dim frmRif As New frmAccordoForn

            Dim Ris As Integer = 0

            ParentFormEx.Sottofondo()
            Ris = frmRif.Carica(, IdRub)
            ParentFormEx.Sottofondo()
            If Ris Then MostraDati(txtCodDescr.Text)
            frmRif.Dispose()

        Else
            Dim frmRif As New frmMagazzinoRisorsa
            Dim ObjRif As New Risorsa
            Dim Ris As Integer = 0

            ParentFormEx.Sottofondo()
            Ris = frmRif.Carica(ObjRif)
            ParentFormEx.Sottofondo()
            If Ris Then MostraDati(txtCodDescr.Text)
            frmRif.Dispose()
            ObjRif = Nothing
        End If

    End Sub

    Private Sub RiapriVoce()

        If dgRisorseEx.SelectedRows.Count Then

            Dim IdVoce As Integer = 0

            If TypeOf dgRisorseEx.SelectedRows(0).DataBoundItem Is Risorsa Then
                Dim OggRif As Risorsa, Ris As Integer = 0

                OggRif = dgRisorseEx.SelectedRows(0).DataBoundItem
                IdVoce = OggRif.IdRis

                If IdRub Then
                    Using frmRif As New frmAccordoForn
                        ParentFormEx.Sottofondo()
                        Ris = frmRif.Carica(IdVoce, IdRub)
                        ParentFormEx.Sottofondo()
                    End Using
                Else
                    Using frmRif As New frmMagazzinoRisorsa
                        ParentFormEx.Sottofondo()
                        Ris = frmRif.Carica(OggRif)
                        ParentFormEx.Sottofondo()
                    End Using
                End If

                'If Ris Then MostraDati(txtCodDescr.Text)
                If Ris Then
                    OggRif.Refresh()
                    DirectCast(dgRisorseEx.DataSource, BindingSource).ResetBindings(False)
                End If


                'OggRif = Nothing

            Else
                'qui devo riaprire la fattura del movimento di magazzino
                Dim OggRif As MovimentoMagazzino
                Dim Ris As Integer = 0
                OggRif = dgRisorseEx.SelectedRows(0).DataBoundItem

                IdVoce = OggRif.IdCarMag

                ParentFormEx.Sottofondo()

                Using c As New frmMagazzinoCarico
                    c.IdRis = OggRif.IdRis
                    'c.IDFat = OggRif.IdFat
                    Ris = c.Carica(IdVoce,, enTipoMovMagaz.Carico, OggRif.IdFat)
                End Using

                ParentFormEx.Sottofondo()

                If Ris Then MostraDati(txtCodDescr.Text)

                'Using C As New Costo
                '    C.Read(IdVoce)
                '    ParentFormEx.Sottofondo()
                '    If C.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                '        Using appForm As New frmContabilitaFatturaRiepilogativaCosto
                '            appForm.Carica(C.IdCosto)
                '        End Using
                '    Else
                '        Using appForm As New frmContabilitaCosto
                '            appForm.Carica(C.IdCosto)
                '        End Using
                '    End If
                '    ParentFormEx.Sottofondo()
                'End Using

            End If
        End If
    End Sub

    Private Sub EliminaVoce()
        If dgRisorseEx.SelectedRows.Count Then
            Dim IdVoce As Integer
            Dim RisSel As Risorsa = dgRisorseEx.SelectedRows(0).DataBoundItem
            IdVoce = RisSel.IdRis

            If RisSel.UltimoMovimentoMagazzino Is Nothing Then
                If MessageBox.Show("Confermi l'eliminazione della voce selezionata?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Using OggRif As New RisorseDAO
                        OggRif.Delete(IdVoce)
                    End Using

                    Cerca()
                    'MostraDati(txtCodDescr.Text)
                    '.ResetBindings(False)

                End If
            Else
                MessageBox.Show("Non si possono eliminare risorse che hanno movimenti di magazzino")
            End If


        End If


    End Sub

    Private Sub lnkNew_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        NewVoce()

    End Sub

    Private Sub DgRisorse_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RiapriVoce()
    End Sub

    'Private Sub DgListino_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    '    If e.Button = Windows.Forms.MouseButtons.Right Then

    '        Dim x As System.Drawing.Point = MousePosition
    '        'btnNuovoCliente.ContextMenu = menuNuovo.
    '        x = MousePosition
    '        'x = lnkNew.PointToClient(x)

    '        Dim rig As DataGridViewRow
    '        Dim RigaSel As Integer = e.RowIndex

    '        If RigaSel <> -1 Then
    '            rig = DgRisorse.Rows(RigaSel)
    '            rig.Selected = True
    '            DgRisorse.Select()
    '            mnuVoce.Show(x)
    '        End If

    '    End If
    'End Sub

    Private Sub ModificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaToolStripMenuItem.Click
        RiapriVoce()
    End Sub

    Private Sub EliminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaToolStripMenuItem.Click
        EliminaVoce()
    End Sub

    Private Sub lnkCaricamentoMassivo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        MessageBox.Show("Caricamento Massivo non ancora abilitato")
    End Sub

    Private Sub DgRisorse_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)

        OrdinatoreLista(Of Risorsa).OrdinaLista(sender, e)

    End Sub

    Private Sub DgRisorse_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgRisorseEx_Click(sender As Object, e As EventArgs) Handles dgRisorseEx.Click

    End Sub

    Private Sub dgRisorseEx_DoubleClick(sender As Object, e As EventArgs) Handles dgRisorseEx.DoubleClick
        RiapriVoce()
    End Sub

    Private Sub dgRisorseEx_MouseClick(sender As Object, e As MouseEventArgs) Handles dgRisorseEx.MouseClick

        If dgRisorseEx.SelectedRows.Count Then
            Dim rig As GridViewRowInfo = dgRisorseEx.SelectedRows(0)

            If e.Button = Windows.Forms.MouseButtons.Right Then

                Dim x As System.Drawing.Point = MousePosition
                'btnNuovoCliente.ContextMenu = menuNuovo.
                x = MousePosition
                'x = lnkNew.PointToClient(x)

                rig.IsSelected = True
                dgRisorseEx.Select()
                mnuVoce.Show(x)

            End If
        End If


    End Sub

    Private Sub lnkSetGiacenza_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)



    End Sub

    Private Sub ImpostaGiacenza()

        If dgRisorseEx.SelectedRows.Count Then

            Dim IdVoce As Integer = 0

            If TypeOf dgRisorseEx.SelectedRows(0).DataBoundItem Is Risorsa Then
                Dim R As Risorsa

                R = dgRisorseEx.SelectedRows(0).DataBoundItem

                If MessageBox.Show("Vuoi impostare manualmente la giacenza della risorsa '" & R.Descrizione & "'", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim NuovaGiacenza As String = InputBox("Inserisci la giacenza corretta della risorsa '" & R.Descrizione & "'", "Imposta giacenza", R.Giacenza)

                    If NuovaGiacenza.Length Then
                        If IsNumeric(NuovaGiacenza) Then

                            Dim Mov As New MovimentoMagazzino

                            If CInt(NuovaGiacenza) > R.Giacenza Then
                                Mov.TipoMov = enTipoMovMagaz.Carico

                            Else
                                Mov.TipoMov = enTipoMovMagaz.Scarico
                            End If

                            Mov.Qta = Math.Abs(NuovaGiacenza - R.Giacenza)
                            Mov.IdRis = R.IdRis
                            Mov.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
                            Mov.DataMov = Now
                            Mov.Nota = "Giacenza impostata manualmente"
                            Mov.Save()

                            'Using m As New MagazzinoDAO
                            '    m.AggiornaQta(Mov)
                            'End Using

                            R.Read(R.IdRis)
                            dgRisorseEx.Refresh()


                        End If
                    End If

                End If

            Else
                MessageBox.Show("Selezionare una risorsa")
            End If

        End If

    End Sub

    Private Sub UnisciSelezionate()

        If dgRisorseEx.SelectedRows.Count > 1 Then

            Dim lRis As New List(Of Risorsa)

            For Each r In dgRisorseEx.SelectedRows
                lRis.Add(r.DataBoundItem)
            Next

            Dim Compatibili As Boolean = True
            Dim FirstH As Integer = 0
            Dim FirstW As Integer = 0
            Dim FirstG As Integer = 0
            Dim FirstTC As Integer = 0

            FirstH = lRis(0).Lunghezza
            FirstW = lRis(0).Larghezza
            FirstG = lRis(0).Grammatura
            FirstTC = lRis(0).IdTipoCarta

            For Each R As Risorsa In lRis

                If R.Lunghezza <> FirstH OrElse
                   R.Larghezza <> FirstW OrElse
                   R.Grammatura <> FirstG OrElse
                   R.IdTipoCarta <> FirstTC Then
                    Compatibili = False
                    Exit For
                End If

            Next

            If Compatibili Then
                If MessageBox.Show("Vuoi unificare tutte le risorse nell'unica risorsa '" & lRis(0).Descrizione & "'", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim IdRisMain As Integer = lRis(0).IdRis

                    For Each R As Risorsa In lRis

                        If R.IdRis <> IdRisMain Then
                            'qui devo sostituire

                            Using mgr As New MagazzinoDAO

                                mgr.ReplaceRisorsa(R.IdRis, IdRisMain)

                            End Using

                            Using mgr As New RisorseDAO
                                mgr.Delete(R.IdRis)
                            End Using

                        End If

                    Next

                    MgrMagazzino.RicalcolaGiacenza(IdRisMain)

                    Cerca()

                End If



            Else
                MessageBox.Show("Le risorse selezionate non sono compatibili (altezza, larghezza, grammatura, tipo carta a listino)")
            End If


        Else
            MessageBox.Show("Selezionare almeno due risorse")
        End If

    End Sub

    Private Sub lnkUnisciSel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        UnisciSelezionate()
    End Sub

    Private Sub ucMagazzinoRisorse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NuovaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuovaToolStripMenuItem.Click
        NewVoce()
    End Sub

    Private Sub StampaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StampaToolStripMenuItem.Click
        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""
        If _IdRub Then
            Titolo = "Listino Fornitore"
        Else
            Titolo = "Magazzino"
        End If
        StampaGlobale(Titolo, dgRisorseEx)
        ParentFormEx.Sottofondo()
    End Sub

    Private Sub UnisciSelezionateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnisciSelezionateToolStripMenuItem.Click
        UnisciSelezionate()
    End Sub

    Private Sub RicalcolaGiacenzeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RicalcolaGiacenzeToolStripMenuItem.Click
        'ImpostaGiacenza()
        If MessageBox.Show("Vuoi ricalcolare la giacenza di tutte le risorse?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Cursor.Current = Cursors.WaitCursor
            Using mgr As New RisorseDAO
                Dim l As List(Of Risorsa) = mgr.GetAll
                For Each voce In l
                    MgrMagazzino.RicalcolaGiacenza(voce.IdRis)
                Next
            End Using
            Cursor.Current = Cursors.Default
            MessageBox.Show("Giacenze ricalcolate")

        End If
    End Sub

    Private Sub UnisciSelezionateToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UnisciSelezionateToolStripMenuItem1.Click
        UnisciSelezionate()
    End Sub

    Private Sub CercaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CercaToolStripMenuItem.Click
        Cerca()
    End Sub

    Private Sub childTemplate_CreateRowInfo(sender As Object, e As GridViewCreateRowInfoEventArgs) Handles childTemplate.CreateRowInfo
        For Each c In childTemplate.Columns
            c.BestFit()
        Next
    End Sub
End Class
