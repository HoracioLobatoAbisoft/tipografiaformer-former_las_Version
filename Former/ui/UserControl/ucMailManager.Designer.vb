<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMailManager
    Inherits ucFormerUserControl


    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridViewImageColumn1 As Telerik.WinControls.UI.GridViewImageColumn = New Telerik.WinControls.UI.GridViewImageColumn()
        Dim GridViewImageColumn2 As Telerik.WinControls.UI.GridViewImageColumn = New Telerik.WinControls.UI.GridViewImageColumn()
        Dim GridViewImageColumn3 As Telerik.WinControls.UI.GridViewImageColumn = New Telerik.WinControls.UI.GridViewImageColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMailManager))
        Me.DgMail = New Telerik.WinControls.UI.RadGridView()
        Me.UcMailPreview = New Former.ucMailPreview()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblClick = New System.Windows.Forms.Label()
        Me.menuMail = New System.Windows.Forms.MenuStrip()
        Me.MostraTuttoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CartelleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchivioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.CestinoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CercaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AzioniToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AggiornaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RispondiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreaOrdineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.FiltraConQuestoClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SpostaInInboxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchiviaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.StampaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuPrev = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AggiornaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.RiapriToolStripmenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.DividiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlCreaOrdine = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AssegnaAClienteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtCercaCli = New System.Windows.Forms.ToolStripTextBox()
        Me.FiltraConQuestoClienteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.SegnaComeLavorataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpostaInArchivioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.StampaToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DgMail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgMail.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.menuMail.SuspendLayout()
        Me.mnuPrev.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgMail
        '
        Me.DgMail.AutoScroll = True
        Me.DgMail.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.DgMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgMail.EnableGestures = False
        Me.DgMail.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.DgMail.Location = New System.Drawing.Point(0, 74)
        '
        '
        '
        Me.DgMail.MasterTemplate.AllowAddNewRow = False
        Me.DgMail.MasterTemplate.AllowCellContextMenu = False
        Me.DgMail.MasterTemplate.AllowColumnChooser = False
        Me.DgMail.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.DgMail.MasterTemplate.AllowColumnReorder = False
        Me.DgMail.MasterTemplate.AllowDeleteRow = False
        Me.DgMail.MasterTemplate.AllowDragToGroup = False
        Me.DgMail.MasterTemplate.AllowEditRow = False
        Me.DgMail.MasterTemplate.AllowRowHeaderContextMenu = False
        Me.DgMail.MasterTemplate.AllowRowResize = False
        Me.DgMail.MasterTemplate.AllowSearchRow = True
        Me.DgMail.MasterTemplate.AutoGenerateColumns = False
        Me.DgMail.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewImageColumn1.FieldName = "IcoTipo"
        GridViewImageColumn1.HeaderText = ""
        GridViewImageColumn1.MaxWidth = 18
        GridViewImageColumn1.MinWidth = 18
        GridViewImageColumn1.Name = "IcoTipo"
        GridViewImageColumn1.Width = 18
        GridViewImageColumn2.FieldName = "IcoStato"
        GridViewImageColumn2.HeaderText = ""
        GridViewImageColumn2.MaxWidth = 18
        GridViewImageColumn2.MinWidth = 18
        GridViewImageColumn2.Name = "IcoStato"
        GridViewImageColumn2.Width = 18
        GridViewImageColumn3.FieldName = "IcoAttach"
        GridViewImageColumn3.HeaderText = ""
        GridViewImageColumn3.MaxWidth = 18
        GridViewImageColumn3.MinWidth = 18
        GridViewImageColumn3.Name = "IcoAttach"
        GridViewImageColumn3.Width = 18
        GridViewTextBoxColumn1.FieldName = "MittenteStr"
        GridViewTextBoxColumn1.HeaderText = "Mittente"
        GridViewTextBoxColumn1.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewTextBoxColumn1.MinWidth = 200
        GridViewTextBoxColumn1.Name = "MittenteStr"
        GridViewTextBoxColumn1.Width = 246
        GridViewTextBoxColumn2.FieldName = "TitoloStr"
        GridViewTextBoxColumn2.HeaderText = "Titolo"
        GridViewTextBoxColumn2.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewTextBoxColumn2.Name = "TitoloStr"
        GridViewTextBoxColumn2.Width = 251
        GridViewTextBoxColumn3.FieldName = "DataStr"
        GridViewTextBoxColumn3.HeaderText = "Data"
        GridViewTextBoxColumn3.MaxWidth = 80
        GridViewTextBoxColumn3.MinWidth = 80
        GridViewTextBoxColumn3.Name = "DataStr"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        GridViewTextBoxColumn3.Width = 80
        GridViewTextBoxColumn4.FieldName = "NomeGruppo"
        GridViewTextBoxColumn4.HeaderText = "Quando"
        GridViewTextBoxColumn4.IsVisible = False
        GridViewTextBoxColumn4.Name = "Quando"
        GridViewTextBoxColumn4.Width = 34
        Me.DgMail.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewImageColumn1, GridViewImageColumn2, GridViewImageColumn3, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.DgMail.MasterTemplate.EnableAlternatingRowColor = True
        Me.DgMail.MasterTemplate.EnableHierarchyFiltering = True
        Me.DgMail.MasterTemplate.MultiSelect = True
        Me.DgMail.MasterTemplate.ShowGroupedColumns = True
        Me.DgMail.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgMail.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.DgMail.Name = "DgMail"
        Me.DgMail.ReadOnly = True
        Me.DgMail.ShowGroupPanel = False
        Me.DgMail.ShowNoDataText = False
        Me.DgMail.Size = New System.Drawing.Size(625, 612)
        Me.DgMail.TabIndex = 63
        Me.DgMail.ThemeName = "VisualStudio2012Light"
        '
        'UcMailPreview
        '
        Me.UcMailPreview.BackColor = System.Drawing.Color.White
        Me.UcMailPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMailPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMailPreview.Location = New System.Drawing.Point(0, 0)
        Me.UcMailPreview.Name = "UcMailPreview"
        Me.UcMailPreview.Size = New System.Drawing.Size(526, 686)
        Me.UcMailPreview.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgMail)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblClick)
        Me.SplitContainer1.Panel1.Controls.Add(Me.menuMail)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.UcMailPreview)
        Me.SplitContainer1.Size = New System.Drawing.Size(1155, 686)
        Me.SplitContainer1.SplitterDistance = 625
        Me.SplitContainer1.TabIndex = 1
        '
        'lblClick
        '
        Me.lblClick.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lblClick.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblClick.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClick.Location = New System.Drawing.Point(0, 34)
        Me.lblClick.Name = "lblClick"
        Me.lblClick.Size = New System.Drawing.Size(625, 40)
        Me.lblClick.TabIndex = 66
        Me.lblClick.Text = "Inbox"
        Me.lblClick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'menuMail
        '
        Me.menuMail.BackColor = System.Drawing.Color.White
        Me.menuMail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MostraTuttoToolStripMenuItem, Me.CartelleToolStripMenuItem, Me.CercaToolStripMenuItem, Me.AzioniToolStripMenuItem})
        Me.menuMail.Location = New System.Drawing.Point(0, 0)
        Me.menuMail.Name = "menuMail"
        Me.menuMail.Size = New System.Drawing.Size(625, 34)
        Me.menuMail.TabIndex = 65
        Me.menuMail.Text = "MenuStrip1"
        '
        'MostraTuttoToolStripMenuItem
        '
        Me.MostraTuttoToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.MostraTuttoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.MostraTuttoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.MostraTuttoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Mail
        Me.MostraTuttoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MostraTuttoToolStripMenuItem.Name = "MostraTuttoToolStripMenuItem"
        Me.MostraTuttoToolStripMenuItem.Size = New System.Drawing.Size(77, 30)
        Me.MostraTuttoToolStripMenuItem.Text = "Inbox"
        '
        'CartelleToolStripMenuItem
        '
        Me.CartelleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivioToolStripMenuItem, Me.ToolStripSeparator9, Me.CestinoToolStripMenuItem1})
        Me.CartelleToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Cartella
        Me.CartelleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CartelleToolStripMenuItem.Name = "CartelleToolStripMenuItem"
        Me.CartelleToolStripMenuItem.Size = New System.Drawing.Size(85, 30)
        Me.CartelleToolStripMenuItem.Text = "Cartelle"
        '
        'ArchivioToolStripMenuItem
        '
        Me.ArchivioToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Cartella
        Me.ArchivioToolStripMenuItem.Name = "ArchivioToolStripMenuItem"
        Me.ArchivioToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ArchivioToolStripMenuItem.Text = "Archivio"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(177, 6)
        '
        'CestinoToolStripMenuItem1
        '
        Me.CestinoToolStripMenuItem1.Image = Global.Former.My.Resources.Resources._Elimina
        Me.CestinoToolStripMenuItem1.Name = "CestinoToolStripMenuItem1"
        Me.CestinoToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.CestinoToolStripMenuItem1.Text = "Cestino"
        '
        'CercaToolStripMenuItem
        '
        Me.CercaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Cerca
        Me.CercaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CercaToolStripMenuItem.Name = "CercaToolStripMenuItem"
        Me.CercaToolStripMenuItem.Size = New System.Drawing.Size(84, 30)
        Me.CercaToolStripMenuItem.Text = "Cerca..."
        '
        'AzioniToolStripMenuItem
        '
        Me.AzioniToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AggiornaToolStripMenuItem, Me.ToolStripSeparator2, Me.RispondiToolStripMenuItem, Me.CreaOrdineToolStripMenuItem, Me.ToolStripSeparator3, Me.FiltraConQuestoClienteToolStripMenuItem, Me.ToolStripSeparator1, Me.SpostaInInboxToolStripMenuItem, Me.ArchiviaToolStripMenuItem, Me.EliminaToolStripMenuItem, Me.ToolStripSeparator5, Me.StampaToolStripMenuItem})
        Me.AzioniToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Strumenti
        Me.AzioniToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AzioniToolStripMenuItem.Name = "AzioniToolStripMenuItem"
        Me.AzioniToolStripMenuItem.Size = New System.Drawing.Size(78, 30)
        Me.AzioniToolStripMenuItem.Text = "Azioni"
        '
        'AggiornaToolStripMenuItem
        '
        Me.AggiornaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AggiornaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.AggiornaToolStripMenuItem.Name = "AggiornaToolStripMenuItem"
        Me.AggiornaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.AggiornaToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.AggiornaToolStripMenuItem.Text = "Aggiorna"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(199, 6)
        '
        'RispondiToolStripMenuItem
        '
        Me.RispondiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Risposta
        Me.RispondiToolStripMenuItem.Name = "RispondiToolStripMenuItem"
        Me.RispondiToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.RispondiToolStripMenuItem.Text = "Rispondi"
        '
        'CreaOrdineToolStripMenuItem
        '
        Me.CreaOrdineToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Ordine
        Me.CreaOrdineToolStripMenuItem.Name = "CreaOrdineToolStripMenuItem"
        Me.CreaOrdineToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.CreaOrdineToolStripMenuItem.Text = "Crea Ordine"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(199, 6)
        '
        'FiltraConQuestoClienteToolStripMenuItem
        '
        Me.FiltraConQuestoClienteToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Filtro
        Me.FiltraConQuestoClienteToolStripMenuItem.Name = "FiltraConQuestoClienteToolStripMenuItem"
        Me.FiltraConQuestoClienteToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.FiltraConQuestoClienteToolStripMenuItem.Text = "Filtra con questo Cliente"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(199, 6)
        '
        'SpostaInInboxToolStripMenuItem
        '
        Me.SpostaInInboxToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SpostaInInboxToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.SpostaInInboxToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Mail
        Me.SpostaInInboxToolStripMenuItem.Name = "SpostaInInboxToolStripMenuItem"
        Me.SpostaInInboxToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.SpostaInInboxToolStripMenuItem.Text = "Sposta in Inbox"
        '
        'ArchiviaToolStripMenuItem
        '
        Me.ArchiviaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Cartella
        Me.ArchiviaToolStripMenuItem.Name = "ArchiviaToolStripMenuItem"
        Me.ArchiviaToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ArchiviaToolStripMenuItem.Text = "Sposta in Archivio"
        '
        'EliminaToolStripMenuItem
        '
        Me.EliminaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.EliminaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Elimina
        Me.EliminaToolStripMenuItem.Name = "EliminaToolStripMenuItem"
        Me.EliminaToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.EliminaToolStripMenuItem.Text = "Elimina"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(199, 6)
        '
        'StampaToolStripMenuItem
        '
        Me.StampaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Stampa
        Me.StampaToolStripMenuItem.Name = "StampaToolStripMenuItem"
        Me.StampaToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.StampaToolStripMenuItem.Text = "Stampa"
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "_Attenzione.png")
        Me.imlTab.Images.SetKeyName(1, "_Cartella.png")
        '
        'mnuPrev
        '
        Me.mnuPrev.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AggiornaToolStripMenuItem1, Me.ToolStripSeparator7, Me.RiapriToolStripmenu, Me.DividiToolStripMenuItem, Me.tlCreaOrdine, Me.ToolStripSeparator4, Me.AssegnaAClienteToolStripMenuItem1, Me.FiltraConQuestoClienteToolStripMenuItem1, Me.ToolStripSeparator6, Me.SegnaComeLavorataToolStripMenuItem, Me.SpostaInArchivioToolStripMenuItem, Me.ToolStripMenuItem2, Me.ToolStripSeparator8, Me.StampaToolStripMenu})
        Me.mnuPrev.Name = "mnuPrev"
        Me.mnuPrev.Size = New System.Drawing.Size(203, 248)
        '
        'AggiornaToolStripMenuItem1
        '
        Me.AggiornaToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AggiornaToolStripMenuItem1.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.AggiornaToolStripMenuItem1.Name = "AggiornaToolStripMenuItem1"
        Me.AggiornaToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.AggiornaToolStripMenuItem1.Size = New System.Drawing.Size(202, 22)
        Me.AggiornaToolStripMenuItem1.Text = "Aggiorna"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(199, 6)
        '
        'RiapriToolStripmenu
        '
        Me.RiapriToolStripmenu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RiapriToolStripmenu.Image = Global.Former.My.Resources.Resources.reply
        Me.RiapriToolStripmenu.Name = "RiapriToolStripmenu"
        Me.RiapriToolStripmenu.Size = New System.Drawing.Size(202, 22)
        Me.RiapriToolStripmenu.Text = "Rispondi"
        '
        'DividiToolStripMenuItem
        '
        Me.DividiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Dividi
        Me.DividiToolStripMenuItem.Name = "DividiToolStripMenuItem"
        Me.DividiToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.DividiToolStripMenuItem.Text = "Dividi"
        '
        'tlCreaOrdine
        '
        Me.tlCreaOrdine.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tlCreaOrdine.Image = Global.Former.My.Resources.Resources._Ordine
        Me.tlCreaOrdine.Name = "tlCreaOrdine"
        Me.tlCreaOrdine.Size = New System.Drawing.Size(202, 22)
        Me.tlCreaOrdine.Text = "Crea Ordine"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(199, 6)
        '
        'AssegnaAClienteToolStripMenuItem1
        '
        Me.AssegnaAClienteToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtCercaCli})
        Me.AssegnaAClienteToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.AssegnaAClienteToolStripMenuItem1.Name = "AssegnaAClienteToolStripMenuItem1"
        Me.AssegnaAClienteToolStripMenuItem1.Size = New System.Drawing.Size(202, 22)
        Me.AssegnaAClienteToolStripMenuItem1.Text = "Assegna a Cliente"
        '
        'txtCercaCli
        '
        Me.txtCercaCli.Name = "txtCercaCli"
        Me.txtCercaCli.Size = New System.Drawing.Size(100, 23)
        Me.txtCercaCli.ToolTipText = "Cerca un cliente tra quelli in rubrica. Scrivi almeno 4 caratteri"
        '
        'FiltraConQuestoClienteToolStripMenuItem1
        '
        Me.FiltraConQuestoClienteToolStripMenuItem1.Image = Global.Former.My.Resources.Resources._Filtro
        Me.FiltraConQuestoClienteToolStripMenuItem1.Name = "FiltraConQuestoClienteToolStripMenuItem1"
        Me.FiltraConQuestoClienteToolStripMenuItem1.Size = New System.Drawing.Size(202, 22)
        Me.FiltraConQuestoClienteToolStripMenuItem1.Text = "Filtra con questo Cliente"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(199, 6)
        '
        'SegnaComeLavorataToolStripMenuItem
        '
        Me.SegnaComeLavorataToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SegnaComeLavorataToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.SegnaComeLavorataToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Mail
        Me.SegnaComeLavorataToolStripMenuItem.Name = "SegnaComeLavorataToolStripMenuItem"
        Me.SegnaComeLavorataToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.SegnaComeLavorataToolStripMenuItem.Text = "Sposta in Inbox"
        '
        'SpostaInArchivioToolStripMenuItem
        '
        Me.SpostaInArchivioToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Cartella
        Me.SpostaInArchivioToolStripMenuItem.Name = "SpostaInArchivioToolStripMenuItem"
        Me.SpostaInArchivioToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.SpostaInArchivioToolStripMenuItem.Text = "Sposta in Archivio"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripMenuItem2.Image = Global.Former.My.Resources.Resources._Elimina
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(202, 22)
        Me.ToolStripMenuItem2.Text = "Elimina"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(199, 6)
        '
        'StampaToolStripMenu
        '
        Me.StampaToolStripMenu.Image = Global.Former.My.Resources.Resources._Stampa
        Me.StampaToolStripMenu.Name = "StampaToolStripMenu"
        Me.StampaToolStripMenu.Size = New System.Drawing.Size(202, 22)
        Me.StampaToolStripMenu.Text = "Stampa"
        '
        'ucMailManager
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ucMailManager"
        Me.Size = New System.Drawing.Size(1155, 686)
        CType(Me.DgMail.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.menuMail.ResumeLayout(False)
        Me.menuMail.PerformLayout()
        Me.mnuPrev.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcMailPreview As ucMailPreview
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents imlTab As ImageList
    Friend WithEvents DgMail As Telerik.WinControls.UI.RadGridView
    Friend WithEvents menuMail As MenuStrip
    Friend WithEvents MostraTuttoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AzioniToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RispondiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArchiviaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents EliminaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblClick As Label
    Friend WithEvents AggiornaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents CreaOrdineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents FiltraConQuestoClienteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents StampaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuPrev As ContextMenuStrip
    Friend WithEvents RiapriToolStripmenu As ToolStripMenuItem
    Friend WithEvents tlCreaOrdine As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents AssegnaAClienteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents txtCercaCli As ToolStripTextBox
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents StampaToolStripMenu As ToolStripMenuItem
    Friend WithEvents SegnaComeLavorataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents SpostaInInboxToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AggiornaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents FiltraConQuestoClienteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SpostaInArchivioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CercaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CartelleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArchivioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents CestinoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DividiToolStripMenuItem As ToolStripMenuItem
End Class
