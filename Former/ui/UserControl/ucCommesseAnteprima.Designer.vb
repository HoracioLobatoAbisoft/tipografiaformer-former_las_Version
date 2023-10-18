<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCommesseAnteprima
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucCommesseAnteprima))
        Me.tbAnteprima = New System.Windows.Forms.TabPage()
        Me.lvwAllegati = New System.Windows.Forms.ListView()
        Me.imlFile = New System.Windows.Forms.ImageList(Me.components)
        Me.WebPreview = New System.Windows.Forms.WebBrowser()
        Me.tbMain = New System.Windows.Forms.TabControl()
        Me.mnuAllegato = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ApriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlStrApriCon = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiaPercorsoFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbAnteprima.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.mnuAllegato.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbAnteprima
        '
        Me.tbAnteprima.Controls.Add(Me.lvwAllegati)
        Me.tbAnteprima.Controls.Add(Me.WebPreview)
        Me.tbAnteprima.Location = New System.Drawing.Point(4, 24)
        Me.tbAnteprima.Name = "tbAnteprima"
        Me.tbAnteprima.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAnteprima.Size = New System.Drawing.Size(330, 585)
        Me.tbAnteprima.TabIndex = 0
        Me.tbAnteprima.Text = "Anteprima"
        Me.tbAnteprima.UseVisualStyleBackColor = True
        '
        'lvwAllegati
        '
        Me.lvwAllegati.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.lvwAllegati.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lvwAllegati.LargeImageList = Me.imlFile
        Me.lvwAllegati.Location = New System.Drawing.Point(3, 434)
        Me.lvwAllegati.Name = "lvwAllegati"
        Me.lvwAllegati.Size = New System.Drawing.Size(324, 148)
        Me.lvwAllegati.SmallImageList = Me.imlFile
        Me.lvwAllegati.TabIndex = 64
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
        Me.imlFile.Images.SetKeyName(2, "_Anteprima.png")
        Me.imlFile.Images.SetKeyName(3, "_Question.png")
        '
        'WebPreview
        '
        Me.WebPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebPreview.Location = New System.Drawing.Point(3, 3)
        Me.WebPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebPreview.Name = "WebPreview"
        Me.WebPreview.Size = New System.Drawing.Size(324, 432)
        Me.WebPreview.TabIndex = 0
        '
        'tbMain
        '
        Me.tbMain.Controls.Add(Me.tbAnteprima)
        Me.tbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbMain.Location = New System.Drawing.Point(0, 0)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.SelectedIndex = 0
        Me.tbMain.Size = New System.Drawing.Size(338, 613)
        Me.tbMain.TabIndex = 0
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
        'ucCommesseAnteprima
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tbMain)
        Me.Name = "ucCommesseAnteprima"
        Me.Size = New System.Drawing.Size(338, 613)
        Me.tbAnteprima.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.mnuAllegato.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbAnteprima As System.Windows.Forms.TabPage
    Friend WithEvents tbMain As System.Windows.Forms.TabControl
    Friend WithEvents WebPreview As System.Windows.Forms.WebBrowser
    Friend WithEvents imlFile As ImageList
    Friend WithEvents mnuAllegato As ContextMenuStrip
    Friend WithEvents ApriToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tlStrApriCon As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents CopiaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopiaPercorsoFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lvwAllegati As ListView
End Class
