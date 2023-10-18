Imports System.Text.RegularExpressions
Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerPrinter
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class ucMailManager
    Inherits ucFormerUserControl

    Private childTemplate As GridViewTemplate = Nothing

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        MgrControl.InizializeGridview(DgMail, True, False)
        DgMail.TableElement.RowHeight = 50
        DgMail.TableElement.GroupHeaderHeight = 30

        childTemplate = CreateChildTemplate()
        Dim relation As New GridViewRelation(DgMail.MasterTemplate, childTemplate)
        relation.ChildColumnNames.Add("ListaRisposte")
        DgMail.Relations.Add(relation)

    End Sub

    Public Sub Carica()

    End Sub

    Public Property TipoMailDaCaricare As enTipoMail = enTipoMail.Preventivo

    Private _StatoCaricamento As enStatoPreventivoMail = enStatoPreventivoMail.DaLavorare

    Private Function CreateChildTemplate() As GridViewTemplate
        Dim childTemplate As New GridViewTemplate()
        childTemplate.AutoGenerateColumns = False
        childTemplate.AllowColumnReorder = False
        childTemplate.ShowColumnHeaders = False
        childTemplate.AllowRowResize = False

        DgMail.Templates.Add(childTemplate)
        Dim column As New GridViewImageColumn("IcoStato")
        column.HeaderText = String.Empty
        column.MaxWidth = 18
        column.MinWidth = 18
        column.ImageAlignment = ContentAlignment.MiddleCenter
        childTemplate.Columns.Add(column)
        column = New GridViewImageColumn("IcoAttach")
        column.HeaderText = String.Empty
        column.MaxWidth = 18
        column.MinWidth = 18
        column.ImageAlignment = ContentAlignment.MiddleCenter
        childTemplate.Columns.Add(column)
        Dim columnT As New GridViewTextBoxColumn("MittenteStr")
        columnT.HeaderText = "Mittente"
        columnT.TextAlignment = ContentAlignment.MiddleLeft
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("TitoloStr")
        columnT.HeaderText = "Titolo"
        columnT.TextAlignment = ContentAlignment.MiddleLeft
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        columnT = New GridViewTextBoxColumn("DataStr")
        columnT.HeaderText = "Data"
        columnT.TextAlignment = ContentAlignment.BottomRight
        columnT.MaxWidth = 80
        columnT.MinWidth = 80
        columnT.AutoSizeMode = BestFitColumnMode.AllCells
        childTemplate.Columns.Add(columnT)
        childTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
        Return childTemplate

    End Function

    Private Function CaricaDati(Optional IdRubRif As Integer = 0,
                                Optional MailMittente As String = "",
                                Optional CercaText As String = "") As Integer

        Dim ris As Integer = 0

        If IdRubRif = 0 And MailMittente = "" Then
            FiltraConQuestoClienteToolStripMenuItem.Text = "Filtra con questo Cliente"
            FiltraConQuestoClienteToolStripMenuItem1.Text = "Filtra con questo Cliente"
            FiltraConQuestoClienteToolStripMenuItem.Tag = Nothing
        End If

        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Dim CountDaLavorare As Integer = 0
        Dim CountLavorate As Integer = 0

        Using mgr As New PreventiviMailDAO

            'Dim l As List(Of PreventivoMail) = mgr.FindAll("DataRif", New LUNA.LunaSearchParameter("Stato", enStatoPreventivoMail.Eliminata, "<>"),
            '                                                        New LUNA.LunaSearchParameter("IdMailRif", 0))
            Dim l As List(Of PreventivoMail) = mgr.ElencoMail(CercaText,
                                                              ,
                                                              ,
                                                              IdRubRif,
                                                              TipoMailDaCaricare,
                                                              _StatoCaricamento,
                                                              MailMittente)

            l.Sort(Function(x, y) y.DataOrdinamento.CompareTo(x.DataOrdinamento))

            DgMail.GroupDescriptors.Expression = "Quando DESC"
            DgMail.DataSource = l

            'Dim childTemplate As GridViewTemplate = New GridViewTemplate
            'Dim column As New GridViewTextBoxColumn("TitoloStr")
            'childTemplate.Columns.Add(column)
            'DgMail.Templates.Add(childTemplate)
            'Dim relation As New GridViewRelation(DgMail.MasterTemplate, childTemplate)
            'relation.ChildColumnNames.Add("ListaRisposte")
            'If DgMail.Relations.Count = 0 Then DgMail.Relations.Add(relation)

            'DgMail.GroupDescriptors.Expression = "Quando DESC"

            'DgMail.DataSource = l

            'DgDaLavorare.AutoGenerateHierarchy = True
            'Dim descriptor As New GroupDescriptor()

            'descriptor.GroupNames.Add("DataStr", ListSortDirection.Ascending)
            '



            'caricare cestino

            If IdRubRif <> 0 Or MailMittente <> "" Or CercaText <> "" Then
                DgMail.AutoExpandGroups = True
            Else
                DgMail.AutoExpandGroups = False
                For i As Integer = 0 To DgMail.Groups.Count - 1
                    If DgMail.Groups(i).Header = Now.Date.ToString("dd/MM/yyyy 00:00:00") Then
                        DgMail.Groups(i).Expand()
                    ElseIf DgMail.Groups(i).Header = Now.Date.ToString("01/MM/yyyy 00:00:00") Then
                        DgMail.Groups(i).Expand()
                    End If
                Next
            End If

            If l.Count Then
                DgMail.Rows(0).IsSelected = True
            End If

        End Using
        Cursor = Cursors.Default

        Return ris

    End Function

    Private Sub DgDaLavorare_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles DgMail.CellFormatting

        e.CellElement.DrawBorder = False
        Dim P As PreventivoMail = e.Row.DataBoundItem
        If e.CellElement.ColumnInfo.Name = "DataStr" Then
            Dim f As New Font("Segoe UI", 8)
            If Now.Date = P.DataRif.Date Then
                f = New Font("Segoe UI", 8, FontStyle.Bold)
            End If
            e.Row.Cells("DataStr").Style.Font = f
            e.Row.Cells("DataStr").Style.ForeColor = Color.FromArgb(14, 151, 221)
        ElseIf e.CellElement.ColumnInfo.Name = "TitoloStr" Then

        ElseIf e.CellElement.ColumnInfo.Name = "MittenteStr" Then
            Dim f As New Font("Segoe UI", 10, FontStyle.Bold)
            e.Row.Cells("MittenteStr").Style.Font = f
            e.Row.Cells("MittenteStr").Style.ForeColor = Color.FromArgb(64, 64, 64)
        Else

            e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)

        End If

        If e.CellElement.RowInfo.Height <> 50 Then e.CellElement.RowInfo.Height = 50

        If e.CellElement.IsCurrent Then
            e.CellElement.BackColor = Color.FromArgb(214, 224, 61)
        Else
            If e.CellElement.ColumnIndex = 0 Then
                e.CellElement.BackColor = Color.FromArgb(231, 232, 236)
            ElseIf e.CellElement.ColumnIndex = 1 AndAlso P.IdUtFormer Then
                e.CellElement.BackColor = Color.FromArgb(255, 128, 0)
            Else
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
            End If
        End If

    End Sub

    Private Sub DgDaLavorare_Click(sender As Object, e As EventArgs) Handles DgMail.Click
        Try
            If DgMail.SelectedRows.Count Then
                Dim P As PreventivoMail = DgMail.SelectedRows(0).DataBoundItem
                UcMailPreview.Carica(P)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgDaLavorare_CellPaint(sender As Object, e As GridViewCellPaintEventArgs) Handles DgMail.CellPaint

    End Sub

    Private Sub DgDaLavorare_CellValueNeeded(sender As Object, e As GridViewCellValueEventArgs) Handles DgMail.CellValueNeeded

    End Sub

    Private Sub DgDaLavorare_GroupSummaryEvaluate(sender As Object, e As GroupSummaryEvaluationEventArgs) Handles DgMail.GroupSummaryEvaluate
        If e.SummaryItem.Name = "Quando" Then

            Dim DataRif As Date = CDate(e.Value)
            Dim Etichetta As String = String.Empty

            If DataRif = Now.Date Then
                Etichetta = "Oggi"
            Else
                Etichetta = StrConv(DataRif.ToString("MMMM yyyy"), VbStrConv.ProperCase) '[String].Format("Group by country: {0}", e.Value)
            End If

            Etichetta &= " (" & e.Group.ItemCount & ")"

            e.FormatString = Etichetta

            'e.FormatString = StrConv(CDate(e.Value).ToString("MMMM yyyy"), VbStrConv.ProperCase) '[String].Format("Group by country: {0}", e.Value)
        End If
    End Sub

    Private Sub DgDaLavorare_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles DgMail.ViewCellFormatting

        If TypeOf e.CellElement Is GridGroupContentCellElement Then

            Dim f As New Font("Segoe UI", 9, FontStyle.Bold)
            e.CellElement.RowElement.BackColor = Color.FromArgb(64, 64, 64)
            e.CellElement.Font = f
            e.CellElement.ForeColor = Color.White

            If e.CellElement.Text = "Oggi" Then
                e.CellElement.ForeColor = Color.FromArgb(255, 128, 0) '255; 128; 0
            Else
                e.CellElement.ForeColor = Color.White
            End If

            'e.CellElement.Padding = New Padding(20)
            'Else
            '    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
        ElseIf TypeOf e.CellElement Is GridGroupExpanderCellElement Then
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
            'ElseIf TypeOf e.CellElement Is GridDetailViewCellElement Then

            '    If Not Cell Is Nothing AndAlso Not m Is Nothing Then
            '        If m.IdUtFormer Then
            '            Cell.RowInfo.Cells(0).Style.BackColor = Color.Red
            '        End If
            '        Cell.RowInfo.Height = 50
            '    End If
        End If
    End Sub

    Private Sub MostraTuttoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostraTuttoToolStripMenuItem.Click
        _StatoCaricamento = enStatoPreventivoMail.DaLavorare
        lblClick.Text = "Inbox"
        CaricaDati()
    End Sub

    Private Sub RispondiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RispondiToolStripMenuItem.Click
        Rispondi()
    End Sub

    Private Sub ArchiviaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchiviaToolStripMenuItem.Click
        SpostaInArchivio()
    End Sub

    Private Sub EliminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminaToolStripMenuItem.Click
        Elimina()
    End Sub

    Private Sub Rispondi()

        Dim selRow = DgMail.SelectedRows

        If DgMail.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleziona un email per rispondere")
        Else
            Dim g As GridViewRowInfo = DgMail.SelectedRows(0)
            Dim mailMsg As PreventivoMail = g.DataBoundItem

            If mailMsg.IdUtFormer Then
                MessageBox.Show("Non si può rispondere a un email inviata da noi")
            Else

                Dim F As New frmPreventivoMail
                F.CaricaEx(mailMsg)

                AddHandler F.FormClosed, AddressOf ChiusaFormDettaglioMail

            End If
        End If

    End Sub

    Private Sub ChiusaFormDettaglioMail(sender As Object, e As EventArgs)

        If sender.RicaricaDati Then
            CaricaDati()
        End If

    End Sub

    Private Sub Elimina()
        Dim selRow = DgMail.SelectedRows

        If DgMail.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleziona un email da eliminare")
        Else
            Dim g As GridViewRowInfo = DgMail.SelectedRows(0)
            Dim mailMsg As PreventivoMail = g.DataBoundItem

            If mailMsg.IdMailRif <> 0 Then
                mailMsg = mailMsg.MailRif
            End If

            If MessageBox.Show("Confermi l'eliminazione della mail selezionata (e di tutte le risposte collegate)?", "Elimina Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                mailMsg.Stato = enStatoPreventivoMail.Eliminata
                mailMsg.Save()

                CaricaDati()
            End If

        End If
    End Sub

    Private Sub SpostaInArchivio()
        Dim selRow = DgMail.SelectedRows

        If DgMail.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleziona un email da archiviare")
        Else
            Dim g As GridViewRowInfo = DgMail.SelectedRows(0)
            Dim mailMsg As PreventivoMail = g.DataBoundItem

            If mailMsg.IdMailRif <> 0 Then
                mailMsg = mailMsg.MailRif
            End If

            If MessageBox.Show("Confermi l'archiviazione della conversazione selezionata?", "Archivia Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                mailMsg.Stato = enStatoPreventivoMail.Lavorata
                mailMsg.Save()
                CaricaDati()
            End If

        End If
    End Sub

    Private Sub ArchiviatiToolStripMenuItem_Click(sender As Object, e As EventArgs)
        lblClick.Text = "Archivio"
        _StatoCaricamento = enStatoPreventivoMail.Lavorata
        CaricaDati()
    End Sub

    Private Sub AggiornaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AggiornaToolStripMenuItem.Click
        CaricaDati()
    End Sub

    Private Sub FiltraConQuestoClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltraConQuestoClienteToolStripMenuItem.Click
        If Not FiltraConQuestoClienteToolStripMenuItem.Tag Is Nothing Then
            FiltraConCliente(True)
        Else
            FiltraConCliente()
        End If
    End Sub

    Private Sub FiltraConCliente(Optional Annulla As Boolean = False)

        If Annulla Then
            CaricaDati()
        Else
            Dim selRow = DgMail.SelectedRows

            If DgMail.SelectedRows.Count = 0 Then
                MessageBox.Show("Seleziona un email per filtrare")
            Else
                Dim g As GridViewRowInfo = DgMail.SelectedRows(0)
                Dim mailMsg As PreventivoMail = g.DataBoundItem

                Dim IdRubRif As Integer = 0
                Dim Nominativo As String = String.Empty

                If mailMsg.IdUtFormer Then
                    mailMsg = mailMsg.MailRif
                End If

                IdRubRif = mailMsg.IdRub
                Nominativo = mailMsg.MittenteStr

                If IdRubRif Then
                    FiltraConQuestoClienteToolStripMenuItem.Text = "Annulla filtro con '" & Nominativo & "'"
                    FiltraConQuestoClienteToolStripMenuItem1.Text = "Annulla filtro con '" & Nominativo & "'"
                    FiltraConQuestoClienteToolStripMenuItem.Tag = IdRubRif
                    CaricaDati(IdRubRif)
                ElseIf Nominativo.Length Then
                    FiltraConQuestoClienteToolStripMenuItem.Text = "Annulla filtro con '" & Nominativo & "'"
                    FiltraConQuestoClienteToolStripMenuItem1.Text = "Annulla filtro con '" & Nominativo & "'"
                    FiltraConQuestoClienteToolStripMenuItem.Tag = IdRubRif
                    CaricaDati(, mailMsg.Mittente)
                End If

            End If
        End If

    End Sub

    Private Sub DgMail_MouseUp(sender As Object, e As MouseEventArgs) Handles DgMail.MouseUp

        If DgMail.SelectedRows.Count Then
            If e.Button = MouseButtons.Right Then
                Dim P As New Point(e.X + 30, e.Y)
                'qui provo a dare suggerimenti se possibile
                For i As Integer = (AssegnaAClienteToolStripMenuItem1.DropDownItems.Count - 1) To 0 Step -1
                    Dim mts As ToolStripItem = AssegnaAClienteToolStripMenuItem1.DropDownItems(i)
                    If Not mts.Tag Is Nothing Then
                        If mts.Tag.ToString.StartsWith("R") Then
                            'AssegnaAClienteToolStripMenuItem.DropDownItems.RemoveAt(i)
                            AssegnaAClienteToolStripMenuItem1.DropDownItems.RemoveAt(i)
                        End If
                    End If
                Next

                Dim Dominio As String = String.Empty

                Dim g As GridViewRowInfo = DgMail.SelectedRows(0)

                If Not g.DataBoundItem Is Nothing Then
                    Dim M As PreventivoMail = g.DataBoundItem

                    Dominio = M.Mittente.Substring(M.Mittente.IndexOf("@"))

                    Using mgr As New VociRubricaDAO
                        Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "RagSoc, Cognome"},
                                                                    New LUNA.LunaSearchParameter(LFM.VoceRubrica.Email, "%" & Dominio, " like "))

                        If l.Count = 1 Then
                            Dim singV As VoceRubrica = l(0)
                            Dim t As New ToolStripMenuItem
                            t.Text = singV.RagSocNome
                            t.Tag = "R" & singV.IdRub

                            AddHandler t.Click, AddressOf CliccaAssegna
                            'AssegnaAClienteToolStripMenuItem.DropDownItems.Add(t)
                            AssegnaAClienteToolStripMenuItem1.DropDownItems.Add(t)
                        End If

                    End Using
                    mnuPrev.Show(P)
                End If
            End If
        End If

    End Sub

    Private Sub CliccaAssegna(sender As Object,
                              e As EventArgs)

        If Not DgMail.SelectedRows.Count = 0 Then

            Dim m As ToolStripItem = sender
            Dim Mittente As String = String.Empty

            Dim g As GridViewRowInfo = DgMail.SelectedRows(0)

            Dim mail As PreventivoMail = g.DataBoundItem
            Mittente = mail.Mittente

            If mail.IdRub = 0 AndAlso mail.IdUtFormer = 0 Then
                Using R As New VoceRubrica
                    Dim IdRub As Integer = 0
                    IdRub = m.Tag.ToString.Substring(1)

                    R.Read(IdRub)

                    If MessageBox.Show("Confermi l'assegnazione di questa mail a '" & R.RagSocNome & "'?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'assegno tutte le conversazioni a questa email 

                        Dim risInoltro As Match = Regex.Match(Mittente, "@tipografiaformer.")

                        'Dim risInoltro As Match = Regex.Match(Mittente, "tipografia.duca@gmail.")

                        If risInoltro.Success = True Or Mittente = "tipografia.duca@gmail.com" Then
                            mail.IdRub = IdRub
                            mail.Mittente = R.Email
                            mail.Save()
                        Else
                            If mail.Mittente <> R.Email Then
                                If MessageBox.Show("Vuoi sostituire la mail originale della conversazione '" & mail.Mittente & "' con la mail di default del cliente scelto '" & R.Email & "'?", "Sostituzione email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                    mail.Mittente = R.Email
                                End If
                                mail.IdRub = IdRub
                                mail.Save()
                            End If
                        End If

                        'qui devo assegnare tutte le mail di questo indirizzo al cliente selezionato
                        Using mgr As New PreventiviMailDAO
                            mgr.AssegnaEmailaIdRub(mail.Mittente, IdRub)
                        End Using

                        For i As Integer = (AssegnaAClienteToolStripMenuItem1.DropDownItems.Count - 1) To 0 Step -1
                            Dim mts As ToolStripItem = AssegnaAClienteToolStripMenuItem1.DropDownItems(i)
                            If Not mts.Tag Is Nothing Then
                                If mts.Tag.ToString.StartsWith("R") Then
                                    AssegnaAClienteToolStripMenuItem1.DropDownItems.RemoveAt(i)
                                End If
                            End If
                        Next

                        txtCercaCli.Text = String.Empty

                        CaricaDati()
                    End If

                End Using
            Else
                MessageBox.Show("Impossibile assegnare questa email")
            End If


        End If

    End Sub

    Private Sub StampaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StampaToolStripMenuItem.Click
        StampaMail()
    End Sub

    Private Sub StampaMail()
        If Not DgMail.SelectedRows.Count = 0 Then

            If MessageBox.Show("Confermi la stampa della mail selezionata?", "Stampa Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim g As GridViewRowInfo = DgMail.SelectedRows(0)

                Dim m As PreventivoMail = g.DataBoundItem

                Dim Prn As New myFPrinter

                Dim prin As New System.Windows.Forms.PrintDialog
                prin.ShowDialog()
                If prin.PrinterSettings.PrinterName.Length Then
                    Prn.PrinterName = prin.PrinterSettings.PrinterName
                    Prn.StampaPreventivoMail(m)
                End If

            End If

        End If
    End Sub

    Private Sub StampaToolStripMenu_Click(sender As Object, e As EventArgs) Handles StampaToolStripMenu.Click
        StampaMail()
    End Sub

    Private Sub AggiornaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AggiornaToolStripMenuItem1.Click
        CaricaDati()
    End Sub

    Private Sub RiapriToolStripmenu_Click(sender As Object, e As EventArgs) Handles RiapriToolStripmenu.Click
        Rispondi()
    End Sub

    Private Sub CreaOrdineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreaOrdineToolStripMenuItem.Click
        CreaOrdine()
    End Sub

    Private Sub tlCreaOrdine_Click(sender As Object, e As EventArgs) Handles tlCreaOrdine.Click
        CreaOrdine()
    End Sub

    Private Sub CreaOrdine()

        If DgMail.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleziona un email")
        Else
            Dim g As GridViewRowInfo = DgMail.SelectedRows(0)
            Dim m As PreventivoMail = g.DataBoundItem

            If m.IdRub And m.IdUtFormer = 0 Then
                ParentFormEx.Sottofondo()
                Dim Ris As Integer = 0
                Using f As New frmOrdineCreaOnline
                    Ris = f.Carica(m.IdMailPreventivo)
                    If Ris Then
                        CaricaDati()
                    End If
                End Using

                ParentFormEx.Sottofondo()
            Else
                MessageBox.Show("Si possono creare ordini solo su mail già assegnate a un cliente. Assegnare la mail a un cliente e riprovare")
            End If
        End If

    End Sub

    Private Sub FiltraConQuestoClienteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FiltraConQuestoClienteToolStripMenuItem1.Click
        If Not FiltraConQuestoClienteToolStripMenuItem.Tag Is Nothing Then
            FiltraConCliente(True)
        Else
            FiltraConCliente()
        End If
    End Sub

    Private Sub SegnaComeLavorataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SegnaComeLavorataToolStripMenuItem.Click
        SpostaInInbox()
    End Sub

    Private Sub SpostaInArchivioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpostaInArchivioToolStripMenuItem.Click
        SpostaInArchivio()
    End Sub

    Private Sub SpostaInInboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpostaInInboxToolStripMenuItem.Click
        SpostaInInbox()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Elimina()
    End Sub

    Private Sub SpostaInInbox()
        Dim selRow = DgMail.SelectedRows

        If DgMail.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleziona un email da spostare in Inbox")
        Else
            Dim g As GridViewRowInfo = DgMail.SelectedRows(0)
            Dim mailMsg As PreventivoMail = g.DataBoundItem

            If mailMsg.IdMailRif <> 0 Then
                mailMsg = mailMsg.MailRif
            End If

            If MessageBox.Show("Confermi lo spostamento della conversazione selezionata in Inbox?", "Archivia Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                mailMsg.Stato = enStatoPreventivoMail.DaLavorare
                mailMsg.Save()
                CaricaDati()
            End If

        End If
    End Sub

    Private Sub txtCercaCli_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCercaCli.KeyDown
        If e.KeyCode = Keys.Enter Then
            CercaCliMenu()
        End If
    End Sub

    Private Sub txtCercaCliMain_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            CercaCliMenu()
        End If
    End Sub

    Private Sub CercaCliMenu()
        If txtCercaCli.Text.Trim.Length > 3 Then
            Try
                For i As Integer = (AssegnaAClienteToolStripMenuItem1.DropDownItems.Count - 1) To 0 Step -1
                    Dim m As ToolStripItem = AssegnaAClienteToolStripMenuItem1.DropDownItems(i)
                    If Not m.Tag Is Nothing Then
                        If m.Tag.ToString.StartsWith("R") Then
                            AssegnaAClienteToolStripMenuItem1.DropDownItems.RemoveAt(i)
                        End If
                    End If
                Next

                'For Each singMenu As ToolStripItem In AssegnaAClienteToolStripMenuItem.DropDownItems
                '    If Not singMenu.Tag Is Nothing Then
                '        If singMenu.Tag.ToString.StartsWith("R") Then
                '            AssegnaAClienteToolStripMenuItem.DropDownItems.RemoveByKey(singMenu.Name)
                '        End If
                '    End If
                'Next

                Using mgr As New VociRubricaDAO
                    Dim l As List(Of VoceRubrica) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "RagSoc, Cognome"},
                                                                New LUNA.LunaSearchParameter(LFM.VoceRubrica.RagSoc, "%" & txtCercaCli.Text.Trim & "%", " like "),
                                                                New LUNA.LunaSearchParameter(LFM.VoceRubrica.Cognome, "%" & txtCercaCli.Text.Trim & "%", " like ", LUNA.enLogicOperator.enOR))

                    For Each singV As VoceRubrica In l
                        Dim t As New ToolStripMenuItem
                        t.Text = singV.RagSocNome
                        t.Tag = "R" & singV.IdRub

                        AddHandler t.Click, AddressOf CliccaAssegna
                        AssegnaAClienteToolStripMenuItem1.DropDownItems.Add(t)
                    Next

                End Using
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub CestinoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        lblClick.Text = "Cestino"
        _StatoCaricamento = enStatoPreventivoMail.Eliminata
        CaricaDati()
    End Sub

    Private Sub DgMail_CellClick(sender As Object, e As GridViewCellEventArgs) Handles DgMail.CellClick

        If TypeOf e.Row Is GridViewGroupRowInfo Then
            e.Row.IsExpanded = Not e.Row.IsExpanded
        End If

    End Sub

    Private Sub ArchivioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchivioToolStripMenuItem.Click
        lblClick.Text = "Archivio"
        _StatoCaricamento = enStatoPreventivoMail.Lavorata
        CaricaDati()
    End Sub

    Private Sub CestinoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CestinoToolStripMenuItem1.Click
        lblClick.Text = "Cestino"
        _StatoCaricamento = enStatoPreventivoMail.Eliminata
        CaricaDati()
    End Sub

    Private Sub CercaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CercaToolStripMenuItem.Click
        Cerca()
    End Sub

    Private Sub Cerca()

        'qui faccio il cerca
        Dim TestoLibero As String = String.Empty
        TestoLibero = InputBox("Cerca nel mittente, nel titolo, nel testo e nel nome degli allegati", "Cerca...")
        TestoLibero = TestoLibero.Trim
        If TestoLibero.Length Then CaricaDati(,, TestoLibero)

    End Sub

    Private Sub DividiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DividiToolStripMenuItem.Click
        Dividi()
    End Sub

    Private Sub Dividi()

        Dim selRow = DgMail.SelectedRows

        If DgMail.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleziona un email")
        Else
            Dim OkDividi As Boolean = True

            Dim g As GridViewRowInfo = DgMail.SelectedRows(0)
            Dim mailMsg As PreventivoMail = g.DataBoundItem

            If mailMsg.IdMailRif = 0 Then
                OkDividi = False
            Else
                If mailMsg.IdUtFormer Then
                    OkDividi = False
                Else
                    'qui devo controllare se e' l'ultima 
                    Using Mgr As New PreventiviMailDAO
                        Dim lRef As List(Of PreventivoMail) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.PreventivoMail.IdMailRif, mailMsg.IdMailPreventivo))

                        If lRef.Count Then
                            OkDividi = False
                        End If

                    End Using
                End If
            End If

            If OkDividi Then
                If MessageBox.Show("Confermi la divisione della conversazione selezionata?", "Divisione Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim x As Guid = Guid.NewGuid
                    Dim GuidTrovato As String = x.ToString

                    Dim TitoloOrig As String = mailMsg.TitoloStr

                    Dim Titolo As String = InputBox("Inserisci un nuovo titolo per la nuova conversazione creata", "Nuovo titolo per conversazione divisa", TitoloOrig)

                    Titolo = Titolo.Trim

                    If Titolo.Length Then
                        TitoloOrig = Titolo
                    End If

                    mailMsg.Titolo = TitoloOrig
                    mailMsg.Testo = mailMsg.Testo.Replace(mailMsg.GuidMail, GuidTrovato)
                    mailMsg.GuidMail = GuidTrovato
                    mailMsg.IdMailRif = 0
                    mailMsg.Save()

                    CaricaDati()
                End If
            Else
                MessageBox.Show("Si può dividere una mail dalla conversazione, solo se non ha risposte successive!")
            End If

        End If

    End Sub

    'Private Sub DgMail_RowFormatting(sender As Object, e As RowFormattingEventArgs) Handles DgMail.RowFormatting
    '    Dim P As PreventivoMail = e.RowElement.Data.DataBoundItem
    '    If P.IdUtFormer Then
    '        e.RowElement.HighlightColor = Color.FromArgb(255, 128, 0)
    '        e.RowElement.BackColor = Color.FromArgb(255, 128, 0)
    '    Else
    '        e.RowElement.HighlightColor = Color.FromArgb(214, 224, 61)
    '        e.RowElement.BackColor = Color.White
    '    End If
    'End Sub
End Class
