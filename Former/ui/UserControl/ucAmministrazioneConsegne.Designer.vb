<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazioneConsegne
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucAmministrazioneConsegne))
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.tvPrima = New System.Windows.Forms.TreeView()
        Me.tvDopo = New System.Windows.Forms.TreeView()
        Me.dtPickCons = New System.Windows.Forms.DateTimePicker()
        Me.lblLegRC = New System.Windows.Forms.Label()
        Me.lblLegTF = New System.Windows.Forms.Label()
        Me.lblLegAC = New System.Windows.Forms.Label()
        Me.tvwConsegnaMerci = New System.Windows.Forms.TreeView()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblOrdiniUscitiMagaz = New System.Windows.Forms.Label()
        Me.lblConsegneDaFare = New System.Windows.Forms.Label()
        Me.UcOrdineAnteprima = New Former.ucOrdiniAnteprima()
        Me.mnuIncludiOrd = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GestisciConsegnaToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ModificaDatiConsegnaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblCarica = New System.Windows.Forms.Label()
        Me.btnGestCons = New System.Windows.Forms.Button()
        Me.btnEmettiDocMerceSpedire = New System.Windows.Forms.Button()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.btnIndietro = New System.Windows.Forms.Button()
        Me.btnAvanti = New System.Windows.Forms.Button()
        Me.TableLayoutPanel.SuspendLayout()
        Me.mnuIncludiOrd.SuspendLayout()
        Me.SuspendLayout()
        '
        'imlCli
        '
        Me.imlCli.ImageStream = CType(resources.GetObject("imlCli.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCli.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCli.Images.SetKeyName(0, "user(1).png")
        Me.imlCli.Images.SetKeyName(1, "checkout.png")
        Me.imlCli.Images.SetKeyName(2, "icoPrint.jpg")
        Me.imlCli.Images.SetKeyName(3, "icoMoney.jpg")
        Me.imlCli.Images.SetKeyName(4, "icoRubRed.jpg")
        Me.imlCli.Images.SetKeyName(5, "icoParamRed.jpg")
        Me.imlCli.Images.SetKeyName(6, "truck.png")
        Me.imlCli.Images.SetKeyName(7, "Time-&-Weather20-0.png")
        '
        'tvPrima
        '
        Me.tvPrima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvPrima.Indent = 15
        Me.tvPrima.Location = New System.Drawing.Point(3, 33)
        Me.tvPrima.Name = "tvPrima"
        Me.tvPrima.Size = New System.Drawing.Size(346, 679)
        Me.tvPrima.TabIndex = 80
        '
        'tvDopo
        '
        Me.tvDopo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvDopo.Indent = 15
        Me.tvDopo.Location = New System.Drawing.Point(355, 33)
        Me.tvDopo.Name = "tvDopo"
        Me.tvDopo.Size = New System.Drawing.Size(346, 679)
        Me.tvDopo.TabIndex = 81
        '
        'dtPickCons
        '
        Me.dtPickCons.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPickCons.CalendarForeColor = System.Drawing.Color.Black
        Me.dtPickCons.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.dtPickCons.CustomFormat = " dddd dd MMMM"
        Me.dtPickCons.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.dtPickCons.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickCons.Location = New System.Drawing.Point(1097, 11)
        Me.dtPickCons.Name = "dtPickCons"
        Me.dtPickCons.Size = New System.Drawing.Size(214, 27)
        Me.dtPickCons.TabIndex = 117
        '
        'lblLegRC
        '
        Me.lblLegRC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLegRC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLegRC.Location = New System.Drawing.Point(547, 14)
        Me.lblLegRC.Name = "lblLegRC"
        Me.lblLegRC.Size = New System.Drawing.Size(120, 19)
        Me.lblLegRC.TabIndex = 118
        Me.lblLegRC.Text = "Ritiro Cliente"
        Me.lblLegRC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLegTF
        '
        Me.lblLegTF.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLegTF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLegTF.Location = New System.Drawing.Point(673, 14)
        Me.lblLegTF.Name = "lblLegTF"
        Me.lblLegTF.Size = New System.Drawing.Size(120, 19)
        Me.lblLegTF.TabIndex = 119
        Me.lblLegTF.Text = "Tipografia Former"
        Me.lblLegTF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLegAC
        '
        Me.lblLegAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLegAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLegAC.Location = New System.Drawing.Point(799, 14)
        Me.lblLegAC.Name = "lblLegAC"
        Me.lblLegAC.Size = New System.Drawing.Size(120, 19)
        Me.lblLegAC.TabIndex = 120
        Me.lblLegAC.Text = "Altro Corriere"
        Me.lblLegAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tvwConsegnaMerci
        '
        Me.tvwConsegnaMerci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwConsegnaMerci.FullRowSelect = True
        Me.tvwConsegnaMerci.ImageIndex = 0
        Me.tvwConsegnaMerci.ImageList = Me.imlCli
        Me.tvwConsegnaMerci.Indent = 20
        Me.tvwConsegnaMerci.ItemHeight = 25
        Me.tvwConsegnaMerci.Location = New System.Drawing.Point(707, 33)
        Me.tvwConsegnaMerci.Name = "tvwConsegnaMerci"
        Me.tvwConsegnaMerci.SelectedImageIndex = 0
        Me.tvwConsegnaMerci.Size = New System.Drawing.Size(346, 679)
        Me.tvwConsegnaMerci.TabIndex = 121
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel.ColumnCount = 4
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.Controls.Add(Me.tvDopo, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.tvwConsegnaMerci, 2, 1)
        Me.TableLayoutPanel.Controls.Add(Me.lblOrdiniUscitiMagaz, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.lblConsegneDaFare, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.tvPrima, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.UcOrdineAnteprima, 3, 1)
        Me.TableLayoutPanel.Controls.Add(Me.lblCarica, 2, 0)
        Me.TableLayoutPanel.Location = New System.Drawing.Point(3, 48)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 2
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(1410, 715)
        Me.TableLayoutPanel.TabIndex = 123
        '
        'lblOrdiniUscitiMagaz
        '
        Me.lblOrdiniUscitiMagaz.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblOrdiniUscitiMagaz.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrdiniUscitiMagaz.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblOrdiniUscitiMagaz.Location = New System.Drawing.Point(355, 0)
        Me.lblOrdiniUscitiMagaz.Name = "lblOrdiniUscitiMagaz"
        Me.lblOrdiniUscitiMagaz.Size = New System.Drawing.Size(346, 30)
        Me.lblOrdiniUscitiMagaz.TabIndex = 85
        Me.lblOrdiniUscitiMagaz.Text = "Ordini Usciti da magazzino"
        Me.lblOrdiniUscitiMagaz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblConsegneDaFare
        '
        Me.lblConsegneDaFare.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblConsegneDaFare.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsegneDaFare.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblConsegneDaFare.Location = New System.Drawing.Point(3, 0)
        Me.lblConsegneDaFare.Name = "lblConsegneDaFare"
        Me.lblConsegneDaFare.Size = New System.Drawing.Size(346, 30)
        Me.lblConsegneDaFare.TabIndex = 84
        Me.lblConsegneDaFare.Text = "Consegne da Fare"
        Me.lblConsegneDaFare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UcOrdineAnteprima
        '
        Me.UcOrdineAnteprima.BackColor = System.Drawing.Color.White
        Me.UcOrdineAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOrdineAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdineAnteprima.Location = New System.Drawing.Point(1059, 33)
        Me.UcOrdineAnteprima.Name = "UcOrdineAnteprima"
        Me.UcOrdineAnteprima.NascondiResto = False
        Me.UcOrdineAnteprima.NoLavori = False
        Me.UcOrdineAnteprima.Size = New System.Drawing.Size(348, 679)
        Me.UcOrdineAnteprima.TabIndex = 116
        '
        'mnuIncludiOrd
        '
        Me.mnuIncludiOrd.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestisciConsegnaToolStripMenu, Me.ToolStripSeparator1, Me.ModificaDatiConsegnaToolStripMenuItem})
        Me.mnuIncludiOrd.Name = "mnuIncludiOrd"
        Me.mnuIncludiOrd.Size = New System.Drawing.Size(202, 54)
        '
        'GestisciConsegnaToolStripMenu
        '
        Me.GestisciConsegnaToolStripMenu.Name = "GestisciConsegnaToolStripMenu"
        Me.GestisciConsegnaToolStripMenu.Size = New System.Drawing.Size(201, 22)
        Me.GestisciConsegnaToolStripMenu.Text = "Gestisci Consegna"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(198, 6)
        '
        'ModificaDatiConsegnaToolStripMenuItem
        '
        Me.ModificaDatiConsegnaToolStripMenuItem.Name = "ModificaDatiConsegnaToolStripMenuItem"
        Me.ModificaDatiConsegnaToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ModificaDatiConsegnaToolStripMenuItem.Text = "Modifica Dati Consegna"
        '
        'lblCarica
        '
        Me.lblCarica.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCarica.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCarica.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCarica.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lblCarica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCarica.Location = New System.Drawing.Point(707, 0)
        Me.lblCarica.Name = "lblCarica"
        Me.lblCarica.Size = New System.Drawing.Size(221, 30)
        Me.lblCarica.TabIndex = 122
        Me.lblCarica.Text = "Carica Ordini da Ritirare e Ritirati"
        Me.lblCarica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGestCons
        '
        Me.btnGestCons.BackColor = System.Drawing.Color.White
        Me.btnGestCons.Image = Global.Former.My.Resources.Resources._Consegna
        Me.btnGestCons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGestCons.Location = New System.Drawing.Point(204, 4)
        Me.btnGestCons.Name = "btnGestCons"
        Me.btnGestCons.Size = New System.Drawing.Size(148, 38)
        Me.btnGestCons.TabIndex = 115
        Me.btnGestCons.Text = "Gestisci Consegna"
        Me.btnGestCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGestCons.UseVisualStyleBackColor = False
        '
        'btnEmettiDocMerceSpedire
        '
        Me.btnEmettiDocMerceSpedire.BackColor = System.Drawing.Color.White
        Me.btnEmettiDocMerceSpedire.Enabled = False
        Me.btnEmettiDocMerceSpedire.Image = Global.Former.My.Resources.Resources._DocumentoFiscale
        Me.btnEmettiDocMerceSpedire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmettiDocMerceSpedire.Location = New System.Drawing.Point(358, 4)
        Me.btnEmettiDocMerceSpedire.Name = "btnEmettiDocMerceSpedire"
        Me.btnEmettiDocMerceSpedire.Size = New System.Drawing.Size(149, 38)
        Me.btnEmettiDocMerceSpedire.TabIndex = 114
        Me.btnEmettiDocMerceSpedire.Text = "Emetti Doc. Fiscale"
        Me.btnEmettiDocMerceSpedire.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEmettiDocMerceSpedire.UseVisualStyleBackColor = False
        Me.btnEmettiDocMerceSpedire.Visible = False
        '
        'btnAggiorna
        '
        Me.btnAggiorna.AutoSize = True
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiorna.Location = New System.Drawing.Point(109, 4)
        Me.btnAggiorna.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(90, 38)
        Me.btnAggiorna.TabIndex = 86
        Me.btnAggiorna.Text = "Aggiorna"
        Me.btnAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'btnIndietro
        '
        Me.btnIndietro.AutoSize = True
        Me.btnIndietro.BackColor = System.Drawing.Color.White
        Me.btnIndietro.FlatAppearance.BorderSize = 0
        Me.btnIndietro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnIndietro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnIndietro.Image = Global.Former.My.Resources.Resources._previous
        Me.btnIndietro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIndietro.Location = New System.Drawing.Point(3, 4)
        Me.btnIndietro.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnIndietro.Name = "btnIndietro"
        Me.btnIndietro.Size = New System.Drawing.Size(100, 38)
        Me.btnIndietro.TabIndex = 84
        Me.btnIndietro.Text = "Precedente"
        Me.btnIndietro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIndietro.UseVisualStyleBackColor = False
        '
        'btnAvanti
        '
        Me.btnAvanti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAvanti.AutoSize = True
        Me.btnAvanti.BackColor = System.Drawing.Color.White
        Me.btnAvanti.FlatAppearance.BorderSize = 0
        Me.btnAvanti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAvanti.Image = Global.Former.My.Resources.Resources._Next
        Me.btnAvanti.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAvanti.Location = New System.Drawing.Point(1313, 4)
        Me.btnAvanti.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnAvanti.Name = "btnAvanti"
        Me.btnAvanti.Size = New System.Drawing.Size(100, 38)
        Me.btnAvanti.TabIndex = 85
        Me.btnAvanti.Text = "Successiva"
        Me.btnAvanti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAvanti.UseVisualStyleBackColor = False
        '
        'ucAmministrazioneConsegne
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.dtPickCons)
        Me.Controls.Add(Me.btnGestCons)
        Me.Controls.Add(Me.btnEmettiDocMerceSpedire)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.btnIndietro)
        Me.Controls.Add(Me.btnAvanti)
        Me.Controls.Add(Me.lblLegAC)
        Me.Controls.Add(Me.lblLegTF)
        Me.Controls.Add(Me.lblLegRC)
        Me.Name = "ucAmministrazioneConsegne"
        Me.Size = New System.Drawing.Size(1417, 771)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.mnuIncludiOrd.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imlCli As System.Windows.Forms.ImageList
    Friend WithEvents tvPrima As System.Windows.Forms.TreeView
    Friend WithEvents tvDopo As System.Windows.Forms.TreeView
    Friend WithEvents btnIndietro As System.Windows.Forms.Button
    Friend WithEvents btnAvanti As System.Windows.Forms.Button
    Friend WithEvents btnAggiorna As System.Windows.Forms.Button
    Friend WithEvents btnEmettiDocMerceSpedire As System.Windows.Forms.Button
    Friend WithEvents btnGestCons As System.Windows.Forms.Button
    Friend WithEvents UcOrdineAnteprima As Former.ucOrdiniAnteprima
    Friend WithEvents dtPickCons As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLegRC As System.Windows.Forms.Label
    Friend WithEvents lblLegTF As System.Windows.Forms.Label
    Friend WithEvents lblLegAC As System.Windows.Forms.Label
    Friend WithEvents tvwConsegnaMerci As System.Windows.Forms.TreeView
    Friend WithEvents lblCarica As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblOrdiniUscitiMagaz As System.Windows.Forms.Label
    Friend WithEvents lblConsegneDaFare As System.Windows.Forms.Label
    Friend WithEvents mnuIncludiOrd As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GestisciConsegnaToolStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ModificaDatiConsegnaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
