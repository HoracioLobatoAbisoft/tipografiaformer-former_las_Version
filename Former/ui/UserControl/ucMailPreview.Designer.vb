<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMailPreview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMailPreview))
        Me.txtPreview = New System.Windows.Forms.TextBox()
        Me.lblTitolo = New System.Windows.Forms.Label()
        Me.lvwAllegati = New System.Windows.Forms.ListView()
        Me.imlFile = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuAllegato = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ApriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlStrApriCon = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiaPercorsoFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dlgFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.pnlTop = New Telerik.WinControls.UI.RadCollapsiblePanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblMitt = New System.Windows.Forms.LinkLabel()
        Me.lblData = New System.Windows.Forms.Label()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlPrezzo = New System.Windows.Forms.Panel()
        Me.lblPrezzoSuggerito = New System.Windows.Forms.Label()
        Me.webPreview = New System.Windows.Forms.WebBrowser()
        Me.OfficeShape1 = New Telerik.WinControls.UI.OfficeShape()
        Me.DonutShape1 = New Telerik.WinControls.Tests.DonutShape()
        Me.ChamferedRectShape1 = New Telerik.WinControls.ChamferedRectShape()
        Me.CircleShape1 = New Telerik.WinControls.CircleShape()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnkAllegati = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.mnuAllegato.SuspendLayout()
        CType(Me.pnlTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.PanelContainer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlPrezzo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPreview
        '
        Me.txtPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPreview.BackColor = System.Drawing.Color.White
        Me.txtPreview.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPreview.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreview.Location = New System.Drawing.Point(2, 6)
        Me.txtPreview.Multiline = True
        Me.txtPreview.Name = "txtPreview"
        Me.txtPreview.ReadOnly = True
        Me.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPreview.Size = New System.Drawing.Size(621, 400)
        Me.txtPreview.TabIndex = 64
        '
        'lblTitolo
        '
        Me.lblTitolo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitolo.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitolo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.lblTitolo.Location = New System.Drawing.Point(88, 61)
        Me.lblTitolo.Name = "lblTitolo"
        Me.lblTitolo.Size = New System.Drawing.Size(542, 24)
        Me.lblTitolo.TabIndex = 60
        Me.lblTitolo.Text = "-"
        Me.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvwAllegati
        '
        Me.lvwAllegati.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwAllegati.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lvwAllegati.LargeImageList = Me.imlFile
        Me.lvwAllegati.Location = New System.Drawing.Point(2, 449)
        Me.lvwAllegati.Name = "lvwAllegati"
        Me.lvwAllegati.Size = New System.Drawing.Size(621, 98)
        Me.lvwAllegati.SmallImageList = Me.imlFile
        Me.lvwAllegati.TabIndex = 61
        Me.toolTipHelp.SetToolTip(Me.lvwAllegati, "Elenco degli allegati della mail selezionata")
        Me.lvwAllegati.UseCompatibleStateImageBehavior = False
        Me.lvwAllegati.View = System.Windows.Forms.View.List
        '
        'imlFile
        '
        Me.imlFile.ImageStream = CType(resources.GetObject("imlFile.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlFile.TransparentColor = System.Drawing.Color.Transparent
        Me.imlFile.Images.SetKeyName(0, "_Zip.png")
        Me.imlFile.Images.SetKeyName(1, "_pdf.png")
        Me.imlFile.Images.SetKeyName(2, "_Foto.png")
        Me.imlFile.Images.SetKeyName(3, "_unknow.png")
        '
        'mnuAllegato
        '
        Me.mnuAllegato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuAllegato.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApriToolStripMenuItem, Me.tlStrApriCon, Me.ToolStripSeparator3, Me.CopiaToolStripMenuItem, Me.CopiaPercorsoFileToolStripMenuItem})
        Me.mnuAllegato.Name = "mnuAllegato"
        Me.mnuAllegato.Size = New System.Drawing.Size(174, 98)
        '
        'ApriToolStripMenuItem
        '
        Me.ApriToolStripMenuItem.Name = "ApriToolStripMenuItem"
        Me.ApriToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ApriToolStripMenuItem.Text = "Apri"
        '
        'tlStrApriCon
        '
        Me.tlStrApriCon.Name = "tlStrApriCon"
        Me.tlStrApriCon.Size = New System.Drawing.Size(173, 22)
        Me.tlStrApriCon.Text = "Apri con..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(170, 6)
        '
        'CopiaToolStripMenuItem
        '
        Me.CopiaToolStripMenuItem.Name = "CopiaToolStripMenuItem"
        Me.CopiaToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CopiaToolStripMenuItem.Text = "Copia file"
        '
        'CopiaPercorsoFileToolStripMenuItem
        '
        Me.CopiaPercorsoFileToolStripMenuItem.Name = "CopiaPercorsoFileToolStripMenuItem"
        Me.CopiaPercorsoFileToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CopiaPercorsoFileToolStripMenuItem.Text = "Copia percorso file"
        '
        'pnlTop
        '
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.EnableAnimation = False
        Me.pnlTop.EnableTheming = False
        Me.pnlTop.ExpandDirection = Telerik.WinControls.UI.RadDirection.Up
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.OwnerBoundsCache = New System.Drawing.Rectangle(0, 0, 626, 200)
        '
        'pnlTop.PanelContainer
        '
        Me.pnlTop.PanelContainer.Controls.Add(Me.Panel1)
        Me.pnlTop.PanelContainer.Size = New System.Drawing.Size(624, 88)
        '
        '
        '
        Me.pnlTop.RootElement.FocusBorderWidth = 0
        Me.pnlTop.RootElement.Shape = Nothing
        Me.pnlTop.Size = New System.Drawing.Size(626, 116)
        Me.pnlTop.TabIndex = 66
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).ExpandDirection = Telerik.WinControls.UI.RadDirection.Up
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).DrawImage = True
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).BorderWidth = 0!
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).BorderBottomWidth = 0!
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).BorderColor = System.Drawing.Color.White
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).BorderBottomColor = System.Drawing.Color.Empty
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).FocusBorderColor = System.Drawing.Color.White
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).Padding = New System.Windows.Forms.Padding(0)
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).Alignment = System.Drawing.ContentAlignment.TopLeft
        CType(Me.pnlTop.GetChildAt(0), Telerik.WinControls.UI.RadCollapsiblePanelElement).Shape = Me.RoundRectShape1
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1), Telerik.WinControls.UI.CollapsiblePanelHeaderElement).ShowHeaderLine = True
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1), Telerik.WinControls.UI.CollapsiblePanelHeaderElement).BorderWidth = 0!
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).DrawBorder = True
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).BorderWidth = 0!
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).BorderLeftWidth = 0!
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).BorderRightWidth = 0!
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).BorderBottomWidth = 1.0!
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).GradientStyle = Telerik.WinControls.GradientStyles.Solid
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).GradientAngle = 90.0!
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).CustomFontSize = 12.0!
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).AutoSize = True
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).Padding = New System.Windows.Forms.Padding(0)
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).Alignment = System.Drawing.ContentAlignment.TopLeft
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).RightToLeft = False
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.UI.CollapsiblePanelButtonElement).StretchHorizontally = False
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(2), Telerik.WinControls.Primitives.LinePrimitive).SweepAngle = 0
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(2), Telerik.WinControls.Primitives.LinePrimitive).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentPadding
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(2), Telerik.WinControls.Primitives.LinePrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        CType(Me.pnlTop.GetChildAt(0).GetChildAt(1).GetChildAt(2), Telerik.WinControls.Primitives.LinePrimitive).StretchVertically = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblMitt)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblData)
        Me.Panel1.Controls.Add(Me.lblTitolo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(624, 88)
        Me.Panel1.TabIndex = 0
        '
        'lblMitt
        '
        Me.lblMitt.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblMitt.LinkColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblMitt.Location = New System.Drawing.Point(91, 27)
        Me.lblMitt.Name = "lblMitt"
        Me.lblMitt.Size = New System.Drawing.Size(529, 34)
        Me.lblMitt.TabIndex = 65
        Me.lblMitt.TabStop = True
        Me.lblMitt.Text = "-"
        Me.lblMitt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblData
        '
        Me.lblData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblData.BackColor = System.Drawing.Color.White
        Me.lblData.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblData.Location = New System.Drawing.Point(88, 8)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(542, 19)
        Me.lblData.TabIndex = 64
        Me.lblData.Text = "-"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RoundRectShape1
        '
        Me.RoundRectShape1.IsRightToLeft = False
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlPrezzo)
        Me.pnlMain.Controls.Add(Me.webPreview)
        Me.pnlMain.Controls.Add(Me.txtPreview)
        Me.pnlMain.Controls.Add(Me.lvwAllegati)
        Me.pnlMain.Controls.Add(Me.lnkAllegati)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 116)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(626, 550)
        Me.pnlMain.TabIndex = 68
        '
        'pnlPrezzo
        '
        Me.pnlPrezzo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPrezzo.Controls.Add(Me.lblPrezzoSuggerito)
        Me.pnlPrezzo.Controls.Add(Me.Label1)
        Me.pnlPrezzo.Location = New System.Drawing.Point(327, 415)
        Me.pnlPrezzo.Name = "pnlPrezzo"
        Me.pnlPrezzo.Size = New System.Drawing.Size(296, 27)
        Me.pnlPrezzo.TabIndex = 70
        Me.pnlPrezzo.Visible = False
        '
        'lblPrezzoSuggerito
        '
        Me.lblPrezzoSuggerito.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrezzoSuggerito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.lblPrezzoSuggerito.Location = New System.Drawing.Point(130, 0)
        Me.lblPrezzoSuggerito.Name = "lblPrezzoSuggerito"
        Me.lblPrezzoSuggerito.Size = New System.Drawing.Size(161, 27)
        Me.lblPrezzoSuggerito.TabIndex = 70
        Me.lblPrezzoSuggerito.Text = "-"
        Me.lblPrezzoSuggerito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'webPreview
        '
        Me.webPreview.AllowNavigation = False
        Me.webPreview.AllowWebBrowserDrop = False
        Me.webPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webPreview.IsWebBrowserContextMenuEnabled = False
        Me.webPreview.Location = New System.Drawing.Point(2, 6)
        Me.webPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webPreview.Name = "webPreview"
        Me.webPreview.Size = New System.Drawing.Size(621, 400)
        Me.webPreview.TabIndex = 68
        Me.webPreview.Visible = False
        Me.webPreview.WebBrowserShortcutsEnabled = False
        '
        'OfficeShape1
        '
        Me.OfficeShape1.IsRightToLeft = False
        '
        'DonutShape1
        '
        Me.DonutShape1.IsRightToLeft = False
        '
        'ChamferedRectShape1
        '
        Me.ChamferedRectShape1.IsRightToLeft = False
        '
        'CircleShape1
        '
        Me.CircleShape1.IsRightToLeft = False
        '
        'Label1
        '
        Me.Label1.Image = Global.Former.My.Resources.Resources.currency_exchange_24
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 27)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Prezzo suggerito"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAllegati
        '
        Me.lnkAllegati.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkAllegati.AutoSize = True
        Me.lnkAllegati.Image = Global.Former.My.Resources.Resources._Save
        Me.lnkAllegati.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAllegati.LinkColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lnkAllegati.Location = New System.Drawing.Point(3, 415)
        Me.lnkAllegati.Name = "lnkAllegati"
        Me.lnkAllegati.Padding = New System.Windows.Forms.Padding(32, 6, 0, 6)
        Me.lnkAllegati.Size = New System.Drawing.Size(79, 27)
        Me.lnkAllegati.TabIndex = 67
        Me.lnkAllegati.TabStop = True
        Me.lnkAllegati.Text = "Allegati"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._UserBig
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ucMailPreview
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlTop)
        Me.Name = "ucMailPreview"
        Me.Size = New System.Drawing.Size(626, 666)
        Me.mnuAllegato.ResumeLayout(False)
        Me.pnlTop.PanelContainer.ResumeLayout(False)
        CType(Me.pnlTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlPrezzo.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPreview As TextBox
    Friend WithEvents lblTitolo As Label
    Friend WithEvents lvwAllegati As ListView
    Friend WithEvents mnuAllegato As ContextMenuStrip
    Friend WithEvents ApriToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents CopiaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopiaPercorsoFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dlgFolder As FolderBrowserDialog
    Friend WithEvents imlFile As ImageList
    Friend WithEvents tlStrApriCon As ToolStripMenuItem
    Friend WithEvents pnlTop As Telerik.WinControls.UI.RadCollapsiblePanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblData As Label
    Friend WithEvents lnkAllegati As LinkLabel
    Friend WithEvents pnlMain As Panel
    Friend WithEvents lblMitt As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents OfficeShape1 As Telerik.WinControls.UI.OfficeShape
    Friend WithEvents DonutShape1 As Telerik.WinControls.Tests.DonutShape
    Friend WithEvents ChamferedRectShape1 As Telerik.WinControls.ChamferedRectShape
    Friend WithEvents CircleShape1 As Telerik.WinControls.CircleShape
    Friend WithEvents webPreview As WebBrowser
    Friend WithEvents pnlPrezzo As Panel
    Friend WithEvents lblPrezzoSuggerito As Label
    Friend WithEvents Label1 As Label
End Class
