<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrdiniAnteprima
    Inherits ucFormerUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucOrdiniAnteprima))
        Me.tbAnteprima = New System.Windows.Forms.TabPage()
        Me.UcCaratProdotto = New Former.ucCaratteristicheProdotto()
        Me.lvwAllegati = New System.Windows.Forms.ListView()
        Me.WebPreview = New System.Windows.Forms.WebBrowser()
        Me.tbMain = New System.Windows.Forms.TabControl()
        Me.tpMailRiferimento = New System.Windows.Forms.TabPage()
        Me.UcMailPreview = New Former.ucMailPreview()
        Me.tpCliente = New System.Windows.Forms.TabPage()
        Me.UcSituazPagam = New Former.ucSituazPagam()
        Me.tpDocumenti = New System.Windows.Forms.TabPage()
        Me.UcContab = New Former.ucDocumentiFiscali()
        Me.tpPagamenti = New System.Windows.Forms.TabPage()
        Me.UcPagamenti = New Former.ucAmministrazionePagamenti()
        Me.tpAnteprimaCommessa = New System.Windows.Forms.TabPage()
        Me.WebPreviewCommessa = New System.Windows.Forms.WebBrowser()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuAllegato = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ApriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlStrApriCon = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiaPercorsoFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imlFile = New System.Windows.Forms.ImageList(Me.components)
        Me.tbAnteprima.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.tpMailRiferimento.SuspendLayout()
        Me.tpCliente.SuspendLayout()
        Me.tpDocumenti.SuspendLayout()
        Me.tpPagamenti.SuspendLayout()
        Me.tpAnteprimaCommessa.SuspendLayout()
        Me.mnuAllegato.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbAnteprima
        '
        Me.tbAnteprima.Controls.Add(Me.UcCaratProdotto)
        Me.tbAnteprima.Controls.Add(Me.lvwAllegati)
        Me.tbAnteprima.Controls.Add(Me.WebPreview)
        Me.tbAnteprima.ImageKey = "_Anteprima.png"
        Me.tbAnteprima.Location = New System.Drawing.Point(4, 31)
        Me.tbAnteprima.Name = "tbAnteprima"
        Me.tbAnteprima.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAnteprima.Size = New System.Drawing.Size(550, 441)
        Me.tbAnteprima.TabIndex = 0
        Me.tbAnteprima.Text = "Anteprima"
        Me.tbAnteprima.UseVisualStyleBackColor = True
        '
        'UcCaratProdotto
        '
        Me.UcCaratProdotto.BackColor = System.Drawing.Color.White
        Me.UcCaratProdotto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UcCaratProdotto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcCaratProdotto.Location = New System.Drawing.Point(3, 220)
        Me.UcCaratProdotto.Name = "UcCaratProdotto"
        Me.UcCaratProdotto.Size = New System.Drawing.Size(544, 70)
        Me.UcCaratProdotto.TabIndex = 1
        '
        'lvwAllegati
        '
        Me.lvwAllegati.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lvwAllegati.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lvwAllegati.LargeImageList = Me.imlFile
        Me.lvwAllegati.Location = New System.Drawing.Point(3, 290)
        Me.lvwAllegati.Name = "lvwAllegati"
        Me.lvwAllegati.Size = New System.Drawing.Size(544, 148)
        Me.lvwAllegati.SmallImageList = Me.imlFile
        Me.lvwAllegati.TabIndex = 62
        Me.toolTipHelp.SetToolTip(Me.lvwAllegati, "Elenco degli allegati della mail selezionata")
        Me.lvwAllegati.UseCompatibleStateImageBehavior = False
        Me.lvwAllegati.View = System.Windows.Forms.View.List
        '
        'WebPreview
        '
        Me.WebPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebPreview.Location = New System.Drawing.Point(3, 3)
        Me.WebPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebPreview.Name = "WebPreview"
        Me.WebPreview.Size = New System.Drawing.Size(544, 214)
        Me.WebPreview.TabIndex = 0
        '
        'tbMain
        '
        Me.tbMain.Controls.Add(Me.tbAnteprima)
        Me.tbMain.Controls.Add(Me.tpMailRiferimento)
        Me.tbMain.Controls.Add(Me.tpCliente)
        Me.tbMain.Controls.Add(Me.tpDocumenti)
        Me.tbMain.Controls.Add(Me.tpPagamenti)
        Me.tbMain.Controls.Add(Me.tpAnteprimaCommessa)
        Me.tbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbMain.ImageList = Me.imlTab
        Me.tbMain.Location = New System.Drawing.Point(0, 0)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.SelectedIndex = 0
        Me.tbMain.Size = New System.Drawing.Size(558, 476)
        Me.tbMain.TabIndex = 0
        '
        'tpMailRiferimento
        '
        Me.tpMailRiferimento.Controls.Add(Me.UcMailPreview)
        Me.tpMailRiferimento.ImageKey = "_Mail.png"
        Me.tpMailRiferimento.Location = New System.Drawing.Point(4, 31)
        Me.tpMailRiferimento.Name = "tpMailRiferimento"
        Me.tpMailRiferimento.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMailRiferimento.Size = New System.Drawing.Size(550, 441)
        Me.tpMailRiferimento.TabIndex = 4
        Me.tpMailRiferimento.Text = "Mail di Riferimento"
        Me.tpMailRiferimento.UseVisualStyleBackColor = True
        '
        'UcMailPreview
        '
        Me.UcMailPreview.BackColor = System.Drawing.Color.White
        Me.UcMailPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMailPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMailPreview.Location = New System.Drawing.Point(3, 3)
        Me.UcMailPreview.Name = "UcMailPreview"
        Me.UcMailPreview.Size = New System.Drawing.Size(544, 435)
        Me.UcMailPreview.TabIndex = 0
        '
        'tpCliente
        '
        Me.tpCliente.Controls.Add(Me.UcSituazPagam)
        Me.tpCliente.ImageKey = "_bank.png"
        Me.tpCliente.Location = New System.Drawing.Point(4, 31)
        Me.tpCliente.Name = "tpCliente"
        Me.tpCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCliente.Size = New System.Drawing.Size(550, 441)
        Me.tpCliente.TabIndex = 1
        Me.tpCliente.Text = "Contabile"
        Me.tpCliente.UseVisualStyleBackColor = True
        '
        'UcSituazPagam
        '
        Me.UcSituazPagam.BackColor = System.Drawing.Color.White
        Me.UcSituazPagam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSituazPagam.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcSituazPagam.IdRub = 0
        Me.UcSituazPagam.Location = New System.Drawing.Point(3, 3)
        Me.UcSituazPagam.Name = "UcSituazPagam"
        Me.UcSituazPagam.Size = New System.Drawing.Size(544, 435)
        Me.UcSituazPagam.TabIndex = 0
        '
        'tpDocumenti
        '
        Me.tpDocumenti.Controls.Add(Me.UcContab)
        Me.tpDocumenti.ImageKey = "_DocumentoFiscale.png"
        Me.tpDocumenti.Location = New System.Drawing.Point(4, 31)
        Me.tpDocumenti.Name = "tpDocumenti"
        Me.tpDocumenti.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDocumenti.Size = New System.Drawing.Size(550, 441)
        Me.tpDocumenti.TabIndex = 2
        Me.tpDocumenti.Text = "Documenti"
        Me.tpDocumenti.UseVisualStyleBackColor = True
        '
        'UcContab
        '
        Me.UcContab.BackColor = System.Drawing.Color.White
        Me.UcContab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcContab.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcContab.IdRub = 0
        Me.UcContab.Location = New System.Drawing.Point(3, 3)
        Me.UcContab.Name = "UcContab"
        Me.UcContab.Size = New System.Drawing.Size(544, 435)
        Me.UcContab.TabIndex = 0
        '
        'tpPagamenti
        '
        Me.tpPagamenti.Controls.Add(Me.UcPagamenti)
        Me.tpPagamenti.ImageKey = "_Pagamento.png"
        Me.tpPagamenti.Location = New System.Drawing.Point(4, 31)
        Me.tpPagamenti.Name = "tpPagamenti"
        Me.tpPagamenti.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPagamenti.Size = New System.Drawing.Size(550, 441)
        Me.tpPagamenti.TabIndex = 3
        Me.tpPagamenti.Text = "Pagamenti"
        Me.tpPagamenti.UseVisualStyleBackColor = True
        '
        'UcPagamenti
        '
        Me.UcPagamenti.BackColor = System.Drawing.Color.White
        Me.UcPagamenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcPagamenti.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcPagamenti.IdDocRif = 0
        Me.UcPagamenti.IdRub = 0
        Me.UcPagamenti.Location = New System.Drawing.Point(3, 3)
        Me.UcPagamenti.Name = "UcPagamenti"
        Me.UcPagamenti.Size = New System.Drawing.Size(544, 435)
        Me.UcPagamenti.TabIndex = 1
        '
        'tpAnteprimaCommessa
        '
        Me.tpAnteprimaCommessa.Controls.Add(Me.WebPreviewCommessa)
        Me.tpAnteprimaCommessa.ImageKey = "_Commessa.png"
        Me.tpAnteprimaCommessa.Location = New System.Drawing.Point(4, 31)
        Me.tpAnteprimaCommessa.Name = "tpAnteprimaCommessa"
        Me.tpAnteprimaCommessa.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAnteprimaCommessa.Size = New System.Drawing.Size(550, 441)
        Me.tpAnteprimaCommessa.TabIndex = 5
        Me.tpAnteprimaCommessa.Text = "Anteprima Commessa"
        Me.tpAnteprimaCommessa.UseVisualStyleBackColor = True
        '
        'WebPreviewCommessa
        '
        Me.WebPreviewCommessa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebPreviewCommessa.Location = New System.Drawing.Point(3, 3)
        Me.WebPreviewCommessa.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebPreviewCommessa.Name = "WebPreviewCommessa"
        Me.WebPreviewCommessa.Size = New System.Drawing.Size(544, 435)
        Me.WebPreviewCommessa.TabIndex = 1
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "_Anteprima.png")
        Me.imlTab.Images.SetKeyName(1, "_Mail.png")
        Me.imlTab.Images.SetKeyName(2, "_bank.png")
        Me.imlTab.Images.SetKeyName(3, "_DocumentoFiscale.png")
        Me.imlTab.Images.SetKeyName(4, "_Pagamento.png")
        Me.imlTab.Images.SetKeyName(5, "_Commessa.png")
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
        'imlFile
        '
        Me.imlFile.ImageStream = CType(resources.GetObject("imlFile.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlFile.TransparentColor = System.Drawing.Color.Transparent
        Me.imlFile.Images.SetKeyName(0, "_Zip.png")
        Me.imlFile.Images.SetKeyName(1, "_pdf.png")
        Me.imlFile.Images.SetKeyName(2, "_Foto.png")
        Me.imlFile.Images.SetKeyName(3, "_unknow.png")
        '
        'ucOrdiniAnteprima
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tbMain)
        Me.Name = "ucOrdiniAnteprima"
        Me.Size = New System.Drawing.Size(558, 476)
        Me.tbAnteprima.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.tpMailRiferimento.ResumeLayout(False)
        Me.tpCliente.ResumeLayout(False)
        Me.tpDocumenti.ResumeLayout(False)
        Me.tpPagamenti.ResumeLayout(False)
        Me.tpAnteprimaCommessa.ResumeLayout(False)
        Me.mnuAllegato.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbAnteprima As System.Windows.Forms.TabPage
    Friend WithEvents tbMain As System.Windows.Forms.TabControl
    Friend WithEvents WebPreview As System.Windows.Forms.WebBrowser
    Friend WithEvents tpCliente As System.Windows.Forms.TabPage
    Friend WithEvents tpDocumenti As System.Windows.Forms.TabPage
    Friend WithEvents tpPagamenti As System.Windows.Forms.TabPage
    Friend WithEvents UcPagamenti As Former.ucAmministrazionePagamenti
    Friend WithEvents UcContab As Former.ucDocumentiFiscali
    Friend WithEvents UcSituazPagam As Former.ucSituazPagam
    Friend WithEvents UcCaratProdotto As Former.ucCaratteristicheProdotto
    Friend WithEvents lvwAllegati As ListView
    Friend WithEvents mnuAllegato As ContextMenuStrip
    Friend WithEvents ApriToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tlStrApriCon As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents CopiaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopiaPercorsoFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tpMailRiferimento As TabPage
    Friend WithEvents UcMailPreview As ucMailPreview
    Friend WithEvents tpAnteprimaCommessa As TabPage
    Friend WithEvents imlTab As ImageList
    Friend WithEvents WebPreviewCommessa As WebBrowser
    Friend WithEvents imlFile As ImageList
End Class
