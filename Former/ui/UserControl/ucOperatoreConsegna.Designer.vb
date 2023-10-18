<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucOperatoreConsegna
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucOperatoreConsegna))
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.lblCorrConsScelto = New System.Windows.Forms.Label()
        Me.pnlVediPer = New System.Windows.Forms.Panel()
        Me.rdoAlberoCliente = New System.Windows.Forms.RadioButton()
        Me.rdoAlberoData = New System.Windows.Forms.RadioButton()
        Me.lblTipoAlbero = New System.Windows.Forms.Label()
        Me.lblLegACCodTrack = New System.Windows.Forms.Label()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.lblLegAC = New System.Windows.Forms.Label()
        Me.lblLegTF = New System.Windows.Forms.Label()
        Me.lblLegRC = New System.Windows.Forms.Label()
        Me.tvwConsegnaMerci = New System.Windows.Forms.TreeView()
        Me.UcOrdiniListaPreview = New Former.ucOrdiniListaPreview()
        Me.UcFiltroCorriereConsegne = New Former.ucFiltroCorriere()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.RistampaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EtichetteOrdineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BorderoGLSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EtichetteGLSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DocumentiFiscaliToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCodTrack = New System.Windows.Forms.Button()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.btnConsegne = New System.Windows.Forms.Button()
        Me.chkAncheInConsegna = New System.Windows.Forms.CheckBox()
        Me.tvwConsegnaMerciNP = New System.Windows.Forms.TreeView()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerTvw = New System.Windows.Forms.SplitContainer()
        Me.btnPronteChiudi = New System.Windows.Forms.Button()
        Me.btnPronteApri = New System.Windows.Forms.Button()
        Me.lblCompletePronte = New System.Windows.Forms.Label()
        Me.btnNPronteChiudi = New System.Windows.Forms.Button()
        Me.btnNPronteApri = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlVediPer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.SplitContainerTvw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerTvw.Panel1.SuspendLayout()
        Me.SplitContainerTvw.Panel2.SuspendLayout()
        Me.SplitContainerTvw.SuspendLayout()
        Me.SuspendLayout()
        '
        'imlCli
        '
        Me.imlCli.ImageStream = CType(resources.GetObject("imlCli.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCli.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCli.Images.SetKeyName(0, "_user.png")
        Me.imlCli.Images.SetKeyName(1, "_Ordine.png")
        Me.imlCli.Images.SetKeyName(2, "_Stampa.png")
        Me.imlCli.Images.SetKeyName(3, "_Pagamento.png")
        Me.imlCli.Images.SetKeyName(4, "_Spesa.png")
        Me.imlCli.Images.SetKeyName(5, "icoParamRed.jpg")
        Me.imlCli.Images.SetKeyName(6, "_Corriere.png")
        Me.imlCli.Images.SetKeyName(7, "_Calendario.png")
        Me.imlCli.Images.SetKeyName(8, "IcoFast.png")
        Me.imlCli.Images.SetKeyName(9, "IcoLow.png")
        Me.imlCli.Images.SetKeyName(10, "_Consegna.png")
        Me.imlCli.Images.SetKeyName(11, "_Orologio.png")
        Me.imlCli.Images.SetKeyName(12, "_home.png")
        Me.imlCli.Images.SetKeyName(13, "_DataGarantita26.png")
        '
        'lblCorrConsScelto
        '
        Me.lblCorrConsScelto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCorrConsScelto.BackColor = System.Drawing.Color.White
        Me.lblCorrConsScelto.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCorrConsScelto.Location = New System.Drawing.Point(623, 51)
        Me.lblCorrConsScelto.Name = "lblCorrConsScelto"
        Me.lblCorrConsScelto.Size = New System.Drawing.Size(503, 24)
        Me.lblCorrConsScelto.TabIndex = 155
        Me.lblCorrConsScelto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlVediPer
        '
        Me.pnlVediPer.Controls.Add(Me.rdoAlberoCliente)
        Me.pnlVediPer.Controls.Add(Me.rdoAlberoData)
        Me.pnlVediPer.Controls.Add(Me.lblTipoAlbero)
        Me.pnlVediPer.Location = New System.Drawing.Point(516, 22)
        Me.pnlVediPer.Name = "pnlVediPer"
        Me.pnlVediPer.Size = New System.Drawing.Size(181, 26)
        Me.pnlVediPer.TabIndex = 154
        '
        'rdoAlberoCliente
        '
        Me.rdoAlberoCliente.AutoSize = True
        Me.rdoAlberoCliente.Checked = True
        Me.rdoAlberoCliente.Location = New System.Drawing.Point(118, 3)
        Me.rdoAlberoCliente.Name = "rdoAlberoCliente"
        Me.rdoAlberoCliente.Size = New System.Drawing.Size(62, 19)
        Me.rdoAlberoCliente.TabIndex = 147
        Me.rdoAlberoCliente.TabStop = True
        Me.rdoAlberoCliente.Text = "Cliente"
        Me.rdoAlberoCliente.UseVisualStyleBackColor = True
        Me.rdoAlberoCliente.Visible = False
        '
        'rdoAlberoData
        '
        Me.rdoAlberoData.AutoSize = True
        Me.rdoAlberoData.Location = New System.Drawing.Point(61, 3)
        Me.rdoAlberoData.Name = "rdoAlberoData"
        Me.rdoAlberoData.Size = New System.Drawing.Size(49, 19)
        Me.rdoAlberoData.TabIndex = 148
        Me.rdoAlberoData.Text = "Data"
        Me.rdoAlberoData.UseVisualStyleBackColor = True
        Me.rdoAlberoData.Visible = False
        '
        'lblTipoAlbero
        '
        Me.lblTipoAlbero.AutoSize = True
        Me.lblTipoAlbero.Location = New System.Drawing.Point(4, 5)
        Me.lblTipoAlbero.Name = "lblTipoAlbero"
        Me.lblTipoAlbero.Size = New System.Drawing.Size(49, 15)
        Me.lblTipoAlbero.TabIndex = 149
        Me.lblTipoAlbero.Text = "Vedi per"
        Me.lblTipoAlbero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTipoAlbero.Visible = False
        '
        'lblLegACCodTrack
        '
        Me.lblLegACCodTrack.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLegACCodTrack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLegACCodTrack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLegACCodTrack.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblLegACCodTrack.Location = New System.Drawing.Point(468, 51)
        Me.lblLegACCodTrack.Name = "lblLegACCodTrack"
        Me.lblLegACCodTrack.Size = New System.Drawing.Size(149, 24)
        Me.lblLegACCodTrack.TabIndex = 152
        Me.lblLegACCodTrack.Text = "CodTrack"
        Me.lblLegACCodTrack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbZona
        '
        Me.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(216, 22)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(148, 23)
        Me.cmbZona.TabIndex = 146
        '
        'lblLegAC
        '
        Me.lblLegAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLegAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLegAC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLegAC.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblLegAC.Location = New System.Drawing.Point(313, 51)
        Me.lblLegAC.Name = "lblLegAC"
        Me.lblLegAC.Size = New System.Drawing.Size(149, 24)
        Me.lblLegAC.TabIndex = 144
        Me.lblLegAC.Text = "Altro Corriere"
        Me.lblLegAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLegTF
        '
        Me.lblLegTF.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLegTF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLegTF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLegTF.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblLegTF.Location = New System.Drawing.Point(158, 51)
        Me.lblLegTF.Name = "lblLegTF"
        Me.lblLegTF.Size = New System.Drawing.Size(149, 24)
        Me.lblLegTF.TabIndex = 143
        Me.lblLegTF.Text = "Tipografia Former"
        Me.lblLegTF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLegRC
        '
        Me.lblLegRC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLegRC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLegRC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLegRC.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblLegRC.Location = New System.Drawing.Point(3, 51)
        Me.lblLegRC.Name = "lblLegRC"
        Me.lblLegRC.Size = New System.Drawing.Size(149, 24)
        Me.lblLegRC.TabIndex = 142
        Me.lblLegRC.Text = "Ritiro Cliente"
        Me.lblLegRC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tvwConsegnaMerci
        '
        Me.tvwConsegnaMerci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwConsegnaMerci.FullRowSelect = True
        Me.tvwConsegnaMerci.ImageIndex = 0
        Me.tvwConsegnaMerci.ImageList = Me.imlCli
        Me.tvwConsegnaMerci.Indent = 20
        Me.tvwConsegnaMerci.ItemHeight = 25
        Me.tvwConsegnaMerci.Location = New System.Drawing.Point(0, 20)
        Me.tvwConsegnaMerci.Name = "tvwConsegnaMerci"
        Me.tvwConsegnaMerci.SelectedImageIndex = 0
        Me.tvwConsegnaMerci.Size = New System.Drawing.Size(559, 594)
        Me.tvwConsegnaMerci.TabIndex = 141
        '
        'UcOrdiniListaPreview
        '
        Me.UcOrdiniListaPreview.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UcOrdiniListaPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcOrdiniListaPreview.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UcOrdiniListaPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdiniListaPreview.ForeColor = System.Drawing.Color.Silver
        Me.UcOrdiniListaPreview.Location = New System.Drawing.Point(0, 698)
        Me.UcOrdiniListaPreview.Name = "UcOrdiniListaPreview"
        Me.UcOrdiniListaPreview.Size = New System.Drawing.Size(1129, 100)
        Me.UcOrdiniListaPreview.TabIndex = 156
        '
        'UcFiltroCorriereConsegne
        '
        Me.UcFiltroCorriereConsegne.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UcFiltroCorriereConsegne.BackColor = System.Drawing.Color.White
        Me.UcFiltroCorriereConsegne.CorriereSelezionatoEnum = 0
        Me.UcFiltroCorriereConsegne.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcFiltroCorriereConsegne.Location = New System.Drawing.Point(367, 22)
        Me.UcFiltroCorriereConsegne.Margin = New System.Windows.Forms.Padding(0)
        Me.UcFiltroCorriereConsegne.Name = "UcFiltroCorriereConsegne"
        Me.UcFiltroCorriereConsegne.Size = New System.Drawing.Size(146, 23)
        Me.UcFiltroCorriereConsegne.TabIndex = 151
        Me.UcFiltroCorriereConsegne.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Location = New System.Drawing.Point(1027, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(100, 34)
        Me.Panel1.TabIndex = 157
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RistampaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(100, 34)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'RistampaToolStripMenuItem
        '
        Me.RistampaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EtichetteOrdineToolStripMenuItem, Me.ToolStripSeparator2, Me.BorderoGLSToolStripMenuItem, Me.EtichetteGLSToolStripMenuItem, Me.ToolStripSeparator1, Me.DocumentiFiscaliToolStripMenuItem})
        Me.RistampaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Stampa
        Me.RistampaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RistampaToolStripMenuItem.Name = "RistampaToolStripMenuItem"
        Me.RistampaToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RistampaToolStripMenuItem.Size = New System.Drawing.Size(94, 30)
        Me.RistampaToolStripMenuItem.Text = "Ristampa"
        '
        'EtichetteOrdineToolStripMenuItem
        '
        Me.EtichetteOrdineToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Etichetta
        Me.EtichetteOrdineToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EtichetteOrdineToolStripMenuItem.Name = "EtichetteOrdineToolStripMenuItem"
        Me.EtichetteOrdineToolStripMenuItem.Size = New System.Drawing.Size(182, 38)
        Me.EtichetteOrdineToolStripMenuItem.Text = "Etichette Ordine"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(179, 6)
        '
        'BorderoGLSToolStripMenuItem
        '
        Me.BorderoGLSToolStripMenuItem.Enabled = False
        Me.BorderoGLSToolStripMenuItem.Image = Global.Former.My.Resources.Resources._GLS
        Me.BorderoGLSToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BorderoGLSToolStripMenuItem.Name = "BorderoGLSToolStripMenuItem"
        Me.BorderoGLSToolStripMenuItem.Size = New System.Drawing.Size(182, 38)
        Me.BorderoGLSToolStripMenuItem.Text = "Borderò GLS"
        '
        'EtichetteGLSToolStripMenuItem
        '
        Me.EtichetteGLSToolStripMenuItem.Enabled = False
        Me.EtichetteGLSToolStripMenuItem.Name = "EtichetteGLSToolStripMenuItem"
        Me.EtichetteGLSToolStripMenuItem.Size = New System.Drawing.Size(182, 38)
        Me.EtichetteGLSToolStripMenuItem.Text = "Etichette GLS"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(179, 6)
        '
        'DocumentiFiscaliToolStripMenuItem
        '
        Me.DocumentiFiscaliToolStripMenuItem.Image = Global.Former.My.Resources.Resources._DocumentoFiscale
        Me.DocumentiFiscaliToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DocumentiFiscaliToolStripMenuItem.Name = "DocumentiFiscaliToolStripMenuItem"
        Me.DocumentiFiscaliToolStripMenuItem.Size = New System.Drawing.Size(182, 38)
        Me.DocumentiFiscaliToolStripMenuItem.Text = "Documenti fiscali"
        '
        'btnCodTrack
        '
        Me.btnCodTrack.BackColor = System.Drawing.Color.White
        Me.btnCodTrack.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCodTrack.Image = Global.Former.My.Resources.Resources._barcode
        Me.btnCodTrack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCodTrack.Location = New System.Drawing.Point(51, 22)
        Me.btnCodTrack.Name = "btnCodTrack"
        Me.btnCodTrack.Size = New System.Drawing.Size(161, 42)
        Me.btnCodTrack.TabIndex = 153
        Me.btnCodTrack.Text = "Inser. CodTrack"
        Me.btnCodTrack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCodTrack.UseVisualStyleBackColor = False
        Me.btnCodTrack.Visible = False
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.Location = New System.Drawing.Point(3, 3)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(42, 42)
        Me.btnAggiorna.TabIndex = 139
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'btnConsegne
        '
        Me.btnConsegne.BackColor = System.Drawing.Color.White
        Me.btnConsegne.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnConsegne.Image = Global.Former.My.Resources.Resources._PrendiInCarico
        Me.btnConsegne.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsegne.Location = New System.Drawing.Point(51, 3)
        Me.btnConsegne.Name = "btnConsegne"
        Me.btnConsegne.Size = New System.Drawing.Size(161, 42)
        Me.btnConsegne.TabIndex = 138
        Me.btnConsegne.Text = "Consegna Merce"
        Me.btnConsegne.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsegne.UseVisualStyleBackColor = False
        '
        'chkAncheInConsegna
        '
        Me.chkAncheInConsegna.AutoSize = True
        Me.chkAncheInConsegna.Location = New System.Drawing.Point(216, 3)
        Me.chkAncheInConsegna.Name = "chkAncheInConsegna"
        Me.chkAncheInConsegna.Size = New System.Drawing.Size(249, 19)
        Me.chkAncheInConsegna.TabIndex = 158
        Me.chkAncheInConsegna.Text = "Anche Usciti da Magazzino e in Consegna "
        Me.chkAncheInConsegna.UseVisualStyleBackColor = True
        '
        'tvwConsegnaMerciNP
        '
        Me.tvwConsegnaMerciNP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwConsegnaMerciNP.FullRowSelect = True
        Me.tvwConsegnaMerciNP.ImageIndex = 0
        Me.tvwConsegnaMerciNP.ImageList = Me.imlCli
        Me.tvwConsegnaMerciNP.Indent = 20
        Me.tvwConsegnaMerciNP.ItemHeight = 25
        Me.tvwConsegnaMerciNP.Location = New System.Drawing.Point(0, 20)
        Me.tvwConsegnaMerciNP.Name = "tvwConsegnaMerciNP"
        Me.tvwConsegnaMerciNP.SelectedImageIndex = 0
        Me.tvwConsegnaMerciNP.Size = New System.Drawing.Size(566, 594)
        Me.tvwConsegnaMerciNP.TabIndex = 159
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer.Panel1.Controls.Add(Me.btnAggiorna)
        Me.SplitContainer.Panel1.Controls.Add(Me.chkAncheInConsegna)
        Me.SplitContainer.Panel1.Controls.Add(Me.UcFiltroCorriereConsegne)
        Me.SplitContainer.Panel1.Controls.Add(Me.btnConsegne)
        Me.SplitContainer.Panel1.Controls.Add(Me.lblCorrConsScelto)
        Me.SplitContainer.Panel1.Controls.Add(Me.lblLegRC)
        Me.SplitContainer.Panel1.Controls.Add(Me.pnlVediPer)
        Me.SplitContainer.Panel1.Controls.Add(Me.lblLegTF)
        Me.SplitContainer.Panel1.Controls.Add(Me.btnCodTrack)
        Me.SplitContainer.Panel1.Controls.Add(Me.lblLegAC)
        Me.SplitContainer.Panel1.Controls.Add(Me.lblLegACCodTrack)
        Me.SplitContainer.Panel1.Controls.Add(Me.cmbZona)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.SplitContainerTvw)
        Me.SplitContainer.Size = New System.Drawing.Size(1129, 698)
        Me.SplitContainer.SplitterDistance = 80
        Me.SplitContainer.TabIndex = 160
        '
        'SplitContainerTvw
        '
        Me.SplitContainerTvw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerTvw.IsSplitterFixed = True
        Me.SplitContainerTvw.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerTvw.Name = "SplitContainerTvw"
        '
        'SplitContainerTvw.Panel1
        '
        Me.SplitContainerTvw.Panel1.Controls.Add(Me.btnPronteChiudi)
        Me.SplitContainerTvw.Panel1.Controls.Add(Me.btnPronteApri)
        Me.SplitContainerTvw.Panel1.Controls.Add(Me.tvwConsegnaMerci)
        Me.SplitContainerTvw.Panel1.Controls.Add(Me.lblCompletePronte)
        Me.SplitContainerTvw.Panel1MinSize = 0
        '
        'SplitContainerTvw.Panel2
        '
        Me.SplitContainerTvw.Panel2.Controls.Add(Me.btnNPronteChiudi)
        Me.SplitContainerTvw.Panel2.Controls.Add(Me.btnNPronteApri)
        Me.SplitContainerTvw.Panel2.Controls.Add(Me.tvwConsegnaMerciNP)
        Me.SplitContainerTvw.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainerTvw.Panel2MinSize = 0
        Me.SplitContainerTvw.Size = New System.Drawing.Size(1129, 614)
        Me.SplitContainerTvw.SplitterDistance = 559
        Me.SplitContainerTvw.TabIndex = 160
        '
        'btnPronteChiudi
        '
        Me.btnPronteChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPronteChiudi.Location = New System.Drawing.Point(538, 0)
        Me.btnPronteChiudi.Name = "btnPronteChiudi"
        Me.btnPronteChiudi.Size = New System.Drawing.Size(20, 20)
        Me.btnPronteChiudi.TabIndex = 144
        Me.btnPronteChiudi.Text = "-"
        Me.btnPronteChiudi.UseVisualStyleBackColor = True
        '
        'btnPronteApri
        '
        Me.btnPronteApri.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPronteApri.Location = New System.Drawing.Point(518, 0)
        Me.btnPronteApri.Name = "btnPronteApri"
        Me.btnPronteApri.Size = New System.Drawing.Size(20, 20)
        Me.btnPronteApri.TabIndex = 143
        Me.btnPronteApri.Text = "+"
        Me.btnPronteApri.UseVisualStyleBackColor = True
        '
        'lblCompletePronte
        '
        Me.lblCompletePronte.BackColor = System.Drawing.Color.Green
        Me.lblCompletePronte.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCompletePronte.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompletePronte.ForeColor = System.Drawing.Color.White
        Me.lblCompletePronte.Location = New System.Drawing.Point(0, 0)
        Me.lblCompletePronte.Name = "lblCompletePronte"
        Me.lblCompletePronte.Size = New System.Drawing.Size(559, 20)
        Me.lblCompletePronte.TabIndex = 142
        Me.lblCompletePronte.Text = "PRONTE PER LA CONSEGNA"
        Me.lblCompletePronte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNPronteChiudi
        '
        Me.btnNPronteChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNPronteChiudi.Location = New System.Drawing.Point(545, 0)
        Me.btnNPronteChiudi.Name = "btnNPronteChiudi"
        Me.btnNPronteChiudi.Size = New System.Drawing.Size(20, 20)
        Me.btnNPronteChiudi.TabIndex = 162
        Me.btnNPronteChiudi.Text = "-"
        Me.btnNPronteChiudi.UseVisualStyleBackColor = True
        '
        'btnNPronteApri
        '
        Me.btnNPronteApri.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNPronteApri.Location = New System.Drawing.Point(525, 0)
        Me.btnNPronteApri.Name = "btnNPronteApri"
        Me.btnNPronteApri.Size = New System.Drawing.Size(20, 20)
        Me.btnNPronteApri.TabIndex = 161
        Me.btnNPronteApri.Text = "+"
        Me.btnNPronteApri.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(566, 20)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "NON PRONTE PER LA CONSEGNA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ucOperatoreConsegna
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.UcOrdiniListaPreview)
        Me.Name = "ucOperatoreConsegna"
        Me.Size = New System.Drawing.Size(1129, 798)
        Me.pnlVediPer.ResumeLayout(False)
        Me.pnlVediPer.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.SplitContainerTvw.Panel1.ResumeLayout(False)
        Me.SplitContainerTvw.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerTvw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerTvw.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCodTrack As Button
    Friend WithEvents lblLegACCodTrack As Label
    Friend WithEvents lblTipoAlbero As Label
    Friend WithEvents rdoAlberoData As RadioButton
    Friend WithEvents rdoAlberoCliente As RadioButton
    Friend WithEvents cmbZona As ComboBox
    Friend WithEvents lblLegAC As Label
    Friend WithEvents lblLegTF As Label
    Friend WithEvents lblLegRC As Label
    Friend WithEvents tvwConsegnaMerci As TreeView
    Friend WithEvents btnAggiorna As Button
    Friend WithEvents btnConsegne As Button
    Friend WithEvents UcFiltroCorriereConsegne As ucFiltroCorriere
    Friend WithEvents pnlVediPer As Panel
    Friend WithEvents imlCli As ImageList
    Friend WithEvents lblCorrConsScelto As Label
    Friend WithEvents UcOrdiniListaPreview As ucOrdiniListaPreview
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents RistampaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EtichetteOrdineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BorderoGLSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EtichetteGLSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents DocumentiFiscaliToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents chkAncheInConsegna As CheckBox
    Friend WithEvents tvwConsegnaMerciNP As TreeView
    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents SplitContainerTvw As SplitContainer
    Friend WithEvents lblCompletePronte As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnPronteChiudi As Button
    Friend WithEvents btnPronteApri As Button
    Friend WithEvents btnNPronteChiudi As Button
    Friend WithEvents btnNPronteApri As Button
End Class
