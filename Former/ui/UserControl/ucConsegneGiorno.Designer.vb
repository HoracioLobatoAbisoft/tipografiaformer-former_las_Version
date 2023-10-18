<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConsegneGiorno
    Inherits ucFormerUserControl


    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucConsegneGiorno))
        Me.lblGiorno = New System.Windows.Forms.Label()
        Me.SplitGiorno = New System.Windows.Forms.SplitContainer()
        Me.tvwMatt = New System.Windows.Forms.TreeView()
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.lblMatt = New System.Windows.Forms.Label()
        Me.tvwPom = New System.Windows.Forms.TreeView()
        Me.lblPom = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EmettiDocumentoFiscaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSpostaConsegna = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ModificaImportiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalcolaScopertoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTornaProntoRitiro = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSpedisciGls = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEliminaSpedizioneGls = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrHover = New System.Windows.Forms.Timer(Me.components)
        Me.pctMappa = New System.Windows.Forms.PictureBox()
        CType(Me.SplitGiorno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitGiorno.Panel1.SuspendLayout()
        Me.SplitGiorno.Panel2.SuspendLayout()
        Me.SplitGiorno.SuspendLayout()
        Me.ContextMenu.SuspendLayout()
        CType(Me.pctMappa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGiorno
        '
        Me.lblGiorno.BackColor = System.Drawing.Color.White
        Me.lblGiorno.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGiorno.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblGiorno.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblGiorno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblGiorno.Location = New System.Drawing.Point(0, 0)
        Me.lblGiorno.Name = "lblGiorno"
        Me.lblGiorno.Size = New System.Drawing.Size(322, 25)
        Me.lblGiorno.TabIndex = 2
        Me.lblGiorno.Text = "Giorno"
        Me.lblGiorno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitGiorno
        '
        Me.SplitGiorno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitGiorno.Location = New System.Drawing.Point(0, 25)
        Me.SplitGiorno.Name = "SplitGiorno"
        Me.SplitGiorno.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitGiorno.Panel1
        '
        Me.SplitGiorno.Panel1.Controls.Add(Me.tvwMatt)
        Me.SplitGiorno.Panel1.Controls.Add(Me.lblMatt)
        '
        'SplitGiorno.Panel2
        '
        Me.SplitGiorno.Panel2.Controls.Add(Me.tvwPom)
        Me.SplitGiorno.Panel2.Controls.Add(Me.lblPom)
        Me.SplitGiorno.Panel2.Controls.Add(Me.Label1)
        Me.SplitGiorno.Size = New System.Drawing.Size(322, 626)
        Me.SplitGiorno.SplitterDistance = 310
        Me.SplitGiorno.TabIndex = 3
        '
        'tvwMatt
        '
        Me.tvwMatt.AllowDrop = True
        Me.tvwMatt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvwMatt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwMatt.ImageIndex = 0
        Me.tvwMatt.ImageList = Me.imlCli
        Me.tvwMatt.Indent = 10
        Me.tvwMatt.Location = New System.Drawing.Point(0, 17)
        Me.tvwMatt.Name = "tvwMatt"
        Me.tvwMatt.SelectedImageIndex = 0
        Me.tvwMatt.ShowNodeToolTips = True
        Me.tvwMatt.Size = New System.Drawing.Size(322, 293)
        Me.tvwMatt.TabIndex = 55
        '
        'imlCli
        '
        Me.imlCli.ImageStream = CType(resources.GetObject("imlCli.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCli.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCli.Images.SetKeyName(0, "guest.png")
        Me.imlCli.Images.SetKeyName(1, "checkout.png")
        Me.imlCli.Images.SetKeyName(2, "billing.png")
        Me.imlCli.Images.SetKeyName(3, "truck.png")
        Me.imlCli.Images.SetKeyName(4, "icoFolder.jpg")
        Me.imlCli.Images.SetKeyName(5, "icoImg.jpg")
        Me.imlCli.Images.SetKeyName(6, "Home.png")
        Me.imlCli.Images.SetKeyName(7, "icoPP.png")
        Me.imlCli.Images.SetKeyName(8, "coins.png")
        Me.imlCli.Images.SetKeyName(9, "_DataGarantita26.png")
        '
        'lblMatt
        '
        Me.lblMatt.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblMatt.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMatt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMatt.Location = New System.Drawing.Point(0, 0)
        Me.lblMatt.Name = "lblMatt"
        Me.lblMatt.Size = New System.Drawing.Size(322, 17)
        Me.lblMatt.TabIndex = 54
        Me.lblMatt.Text = "Mattino (0)"
        Me.lblMatt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tvwPom
        '
        Me.tvwPom.AllowDrop = True
        Me.tvwPom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvwPom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwPom.ImageIndex = 0
        Me.tvwPom.ImageList = Me.imlCli
        Me.tvwPom.Indent = 10
        Me.tvwPom.Location = New System.Drawing.Point(0, 17)
        Me.tvwPom.Name = "tvwPom"
        Me.tvwPom.SelectedImageIndex = 0
        Me.tvwPom.ShowNodeToolTips = True
        Me.tvwPom.Size = New System.Drawing.Size(322, 295)
        Me.tvwPom.TabIndex = 55
        '
        'lblPom
        '
        Me.lblPom.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblPom.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPom.Location = New System.Drawing.Point(0, 0)
        Me.lblPom.Name = "lblPom"
        Me.lblPom.Size = New System.Drawing.Size(322, 17)
        Me.lblPom.TabIndex = 53
        Me.lblPom.Text = "Pomeriggio (0)"
        Me.lblPom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(322, 17)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Mattino"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ContextMenu
        '
        Me.ContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificaToolStripMenuItem, Me.ToolStripSeparator2, Me.EmettiDocumentoFiscaleToolStripMenuItem, Me.mnuSpostaConsegna, Me.ToolStripSeparator1, Me.ModificaImportiToolStripMenuItem, Me.CalcolaScopertoToolStripMenuItem, Me.mnuTornaProntoRitiro, Me.mnuSpedisciGls, Me.ToolStripSeparator3, Me.mnuEliminaSpedizioneGls})
        Me.ContextMenu.Name = "ContextMenu"
        Me.ContextMenu.Size = New System.Drawing.Size(232, 198)
        '
        'ModificaToolStripMenuItem
        '
        Me.ModificaToolStripMenuItem.Name = "ModificaToolStripMenuItem"
        Me.ModificaToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ModificaToolStripMenuItem.Text = "Modifica"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(228, 6)
        '
        'EmettiDocumentoFiscaleToolStripMenuItem
        '
        Me.EmettiDocumentoFiscaleToolStripMenuItem.Name = "EmettiDocumentoFiscaleToolStripMenuItem"
        Me.EmettiDocumentoFiscaleToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.EmettiDocumentoFiscaleToolStripMenuItem.Text = "Emetti Documento Fiscale"
        '
        'mnuSpostaConsegna
        '
        Me.mnuSpostaConsegna.Name = "mnuSpostaConsegna"
        Me.mnuSpostaConsegna.Size = New System.Drawing.Size(231, 22)
        Me.mnuSpostaConsegna.Text = "Sposta consegna"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(228, 6)
        '
        'ModificaImportiToolStripMenuItem
        '
        Me.ModificaImportiToolStripMenuItem.Name = "ModificaImportiToolStripMenuItem"
        Me.ModificaImportiToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.ModificaImportiToolStripMenuItem.Text = "Modifica Importi"
        '
        'CalcolaScopertoToolStripMenuItem
        '
        Me.CalcolaScopertoToolStripMenuItem.Name = "CalcolaScopertoToolStripMenuItem"
        Me.CalcolaScopertoToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.CalcolaScopertoToolStripMenuItem.Text = "Calcola scoperto"
        '
        'mnuTornaProntoRitiro
        '
        Me.mnuTornaProntoRitiro.Name = "mnuTornaProntoRitiro"
        Me.mnuTornaProntoRitiro.Size = New System.Drawing.Size(231, 22)
        Me.mnuTornaProntoRitiro.Text = "Torna a Pronto per Ritiro"
        '
        'mnuSpedisciGls
        '
        Me.mnuSpedisciGls.Name = "mnuSpedisciGls"
        Me.mnuSpedisciGls.Size = New System.Drawing.Size(231, 22)
        Me.mnuSpedisciGls.Text = "Stampa Etichette GLS"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(228, 6)
        '
        'mnuEliminaSpedizioneGls
        '
        Me.mnuEliminaSpedizioneGls.Name = "mnuEliminaSpedizioneGls"
        Me.mnuEliminaSpedizioneGls.Size = New System.Drawing.Size(231, 22)
        Me.mnuEliminaSpedizioneGls.Text = "Elimina Registrazione Corriere"
        '
        'tmrHover
        '
        Me.tmrHover.Interval = 1000
        '
        'pctMappa
        '
        Me.pctMappa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctMappa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctMappa.Image = Global.Former.My.Resources.Resources._Indirizzo
        Me.pctMappa.Location = New System.Drawing.Point(295, -1)
        Me.pctMappa.Name = "pctMappa"
        Me.pctMappa.Size = New System.Drawing.Size(26, 26)
        Me.pctMappa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pctMappa.TabIndex = 4
        Me.pctMappa.TabStop = False
        '
        'ucConsegneGiorno
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.pctMappa)
        Me.Controls.Add(Me.SplitGiorno)
        Me.Controls.Add(Me.lblGiorno)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "ucConsegneGiorno"
        Me.Size = New System.Drawing.Size(322, 651)
        Me.SplitGiorno.Panel1.ResumeLayout(False)
        Me.SplitGiorno.Panel2.ResumeLayout(False)
        CType(Me.SplitGiorno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitGiorno.ResumeLayout(False)
        Me.ContextMenu.ResumeLayout(False)
        CType(Me.pctMappa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGiorno As System.Windows.Forms.Label
    Friend WithEvents SplitGiorno As System.Windows.Forms.SplitContainer
    Friend WithEvents lblMatt As System.Windows.Forms.Label
    Friend WithEvents lblPom As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tvwMatt As System.Windows.Forms.TreeView
    Friend WithEvents tvwPom As System.Windows.Forms.TreeView
    Friend WithEvents imlCli As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EmettiDocumentoFiscaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ModificaImportiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrHover As System.Windows.Forms.Timer
    Friend WithEvents CalcolaScopertoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSpostaConsegna As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTornaProntoRitiro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pctMappa As System.Windows.Forms.PictureBox
    Friend WithEvents mnuSpedisciGls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminaSpedizioneGls As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
End Class
