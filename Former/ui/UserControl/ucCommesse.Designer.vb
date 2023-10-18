<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucCommesse
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
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.UcCmbCliente = New Former.ucComboRubrica()
        Me.cmbMacchinari = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UcStatoCommesse = New Former.ucCommesseStato()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCerca = New Former.ucNumericTextBox()
        Me.lblNumRis = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumCopie = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuOrd = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificaCommessaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllegaUnMessaggioAllaCommessaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ApriCartellaSorgentiCommessaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.UnisciSelezionateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ApriJobCommessaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreaAnteprimaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApriAnteprimaPDFToolStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.MandaAlFlussoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dlgSaveCsv = New System.Windows.Forms.FolderBrowserDialog()
        Me.lnkExportFlora = New System.Windows.Forms.LinkLabel()
        Me.btnPrendiInCarico = New System.Windows.Forms.Button()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.dlgFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.DgCommesseEx = New Telerik.WinControls.UI.RadGridView()
        Me.rdExport = New Telerik.WinControls.UI.RadDropDownButton()
        Me.mnuFlora = New Telerik.WinControls.UI.RadMenuItem()
        Me.mnuExportEpson = New Telerik.WinControls.UI.RadMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.MenuOrd.SuspendLayout()
        CType(Me.DgCommesseEx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgCommesseEx.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lnkCerca)
        Me.GroupBox1.Controls.Add(Me.UcCmbCliente)
        Me.GroupBox1.Controls.Add(Me.cmbMacchinari)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.UcStatoCommesse)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCerca)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1087, 81)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cerca"
        '
        'lnkCerca
        '
        Me.lnkCerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(969, 18)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(112, 26)
        Me.lnkCerca.TabIndex = 54
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Avvia ricerca..."
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UcCmbCliente
        '
        Me.UcCmbCliente.BackColor = System.Drawing.Color.White
        Me.UcCmbCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcCmbCliente.IdRubSelezionato = 0
        Me.UcCmbCliente.Location = New System.Drawing.Point(247, 21)
        Me.UcCmbCliente.Name = "UcCmbCliente"
        Me.UcCmbCliente.Size = New System.Drawing.Size(716, 25)
        Me.UcCmbCliente.TabIndex = 146
        '
        'cmbMacchinari
        '
        Me.cmbMacchinari.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMacchinari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMacchinari.FormattingEnabled = True
        Me.cmbMacchinari.Location = New System.Drawing.Point(773, 52)
        Me.cmbMacchinari.Name = "cmbMacchinari"
        Me.cmbMacchinari.Size = New System.Drawing.Size(190, 23)
        Me.cmbMacchinari.TabIndex = 145
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(694, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 144
        Me.Label2.Text = "Macchinario"
        '
        'UcStatoCommesse
        '
        Me.UcStatoCommesse.BackColor = System.Drawing.Color.White
        Me.UcStatoCommesse.Completata = False
        Me.UcStatoCommesse.FinituraSuCommessa = False
        Me.UcStatoCommesse.FinituraSuProdotti = False
        Me.UcStatoCommesse.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.UcStatoCommesse.ForeColor = System.Drawing.Color.Black
        Me.UcStatoCommesse.Location = New System.Drawing.Point(9, 50)
        Me.UcStatoCommesse.Name = "UcStatoCommesse"
        Me.UcStatoCommesse.Preinserito = True
        Me.UcStatoCommesse.Pronto = True
        Me.UcStatoCommesse.Size = New System.Drawing.Size(679, 28)
        Me.UcStatoCommesse.Stampa = True
        Me.UcStatoCommesse.TabIndex = 57
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(195, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Cliente"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 15)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Numero"
        '
        'txtCerca
        '
        Me.txtCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCerca.Location = New System.Drawing.Point(64, 21)
        Me.txtCerca.MaxLength = 7
        Me.txtCerca.My_AccettaNegativi = False
        Me.txtCerca.My_AllowOnlyInteger = True
        Me.txtCerca.My_DefaultValue = 0
        Me.txtCerca.My_MaxValue = 9999999.0!
        Me.txtCerca.My_MinValue = 0!
        Me.txtCerca.My_ReplaceWithDefaultValue = False
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(124, 23)
        Me.txtCerca.TabIndex = 50
        Me.txtCerca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumRis
        '
        Me.lblNumRis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumRis.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.lblNumRis.Location = New System.Drawing.Point(984, 573)
        Me.lblNumRis.Name = "lblNumRis"
        Me.lblNumRis.Size = New System.Drawing.Size(106, 13)
        Me.lblNumRis.TabIndex = 59
        Me.lblNumRis.Text = "0"
        Me.lblNumRis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.Label3.Location = New System.Drawing.Point(887, 573)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 12)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Risultato ricerca:"
        '
        'lblNumCopie
        '
        Me.lblNumCopie.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNumCopie.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.lblNumCopie.Location = New System.Drawing.Point(85, 573)
        Me.lblNumCopie.Name = "lblNumCopie"
        Me.lblNumCopie.Size = New System.Drawing.Size(106, 13)
        Me.lblNumCopie.TabIndex = 61
        Me.lblNumCopie.Text = "0"
        Me.lblNumCopie.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.Label4.Location = New System.Drawing.Point(3, 573)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 12)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Numero copie:"
        '
        'MenuOrd
        '
        Me.MenuOrd.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificaCommessaToolStripMenuItem, Me.ToolStripMenuItem1, Me.AllegaUnMessaggioAllaCommessaToolStripMenuItem, Me.ToolStripSeparator1, Me.ApriCartellaSorgentiCommessaToolStripMenuItem, Me.ToolStripSeparator3, Me.UnisciSelezionateToolStripMenuItem, Me.ToolStripSeparator2, Me.ApriJobCommessaToolStripMenuItem, Me.CreaAnteprimaToolStripMenuItem, Me.ApriAnteprimaPDFToolStrip, Me.MandaAlFlussoToolStripMenuItem, Me.ToolStripSeparator4, Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem})
        Me.MenuOrd.Name = "MenuOrd"
        Me.MenuOrd.Size = New System.Drawing.Size(266, 248)
        '
        'ModificaCommessaToolStripMenuItem
        '
        Me.ModificaCommessaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ModificaCommessaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Modifica
        Me.ModificaCommessaToolStripMenuItem.Name = "ModificaCommessaToolStripMenuItem"
        Me.ModificaCommessaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ModificaCommessaToolStripMenuItem.Text = "Modifica Commessa"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NormaleToolStripMenuItem, Me.AltaToolStripMenuItem})
        Me.ToolStripMenuItem1.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(265, 22)
        Me.ToolStripMenuItem1.Text = "Priorità"
        '
        'NormaleToolStripMenuItem
        '
        Me.NormaleToolStripMenuItem.Name = "NormaleToolStripMenuItem"
        Me.NormaleToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.NormaleToolStripMenuItem.Text = "Normale"
        '
        'AltaToolStripMenuItem
        '
        Me.AltaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.AltaToolStripMenuItem.Name = "AltaToolStripMenuItem"
        Me.AltaToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.AltaToolStripMenuItem.Text = "Alta"
        '
        'AllegaUnMessaggioAllaCommessaToolStripMenuItem
        '
        Me.AllegaUnMessaggioAllaCommessaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Allega
        Me.AllegaUnMessaggioAllaCommessaToolStripMenuItem.Name = "AllegaUnMessaggioAllaCommessaToolStripMenuItem"
        Me.AllegaUnMessaggioAllaCommessaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.AllegaUnMessaggioAllaCommessaToolStripMenuItem.Text = "Allega un messaggio alla commessa"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(262, 6)
        '
        'ApriCartellaSorgentiCommessaToolStripMenuItem
        '
        Me.ApriCartellaSorgentiCommessaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._CartellaAperta
        Me.ApriCartellaSorgentiCommessaToolStripMenuItem.Name = "ApriCartellaSorgentiCommessaToolStripMenuItem"
        Me.ApriCartellaSorgentiCommessaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ApriCartellaSorgentiCommessaToolStripMenuItem.Text = "Apri cartella sorgenti"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(262, 6)
        '
        'UnisciSelezionateToolStripMenuItem
        '
        Me.UnisciSelezionateToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Merge
        Me.UnisciSelezionateToolStripMenuItem.Name = "UnisciSelezionateToolStripMenuItem"
        Me.UnisciSelezionateToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.UnisciSelezionateToolStripMenuItem.Text = "Unisci selezionate"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(262, 6)
        '
        'ApriJobCommessaToolStripMenuItem
        '
        Me.ApriJobCommessaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._FileJOB
        Me.ApriJobCommessaToolStripMenuItem.Name = "ApriJobCommessaToolStripMenuItem"
        Me.ApriJobCommessaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ApriJobCommessaToolStripMenuItem.Text = "Apri JOB"
        '
        'CreaAnteprimaToolStripMenuItem
        '
        Me.CreaAnteprimaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._pdf
        Me.CreaAnteprimaToolStripMenuItem.Name = "CreaAnteprimaToolStripMenuItem"
        Me.CreaAnteprimaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.CreaAnteprimaToolStripMenuItem.Text = "Crea Anteprima"
        Me.CreaAnteprimaToolStripMenuItem.Visible = False
        '
        'ApriAnteprimaPDFToolStrip
        '
        Me.ApriAnteprimaPDFToolStrip.Image = Global.Former.My.Resources.Resources._Shell
        Me.ApriAnteprimaPDFToolStrip.Name = "ApriAnteprimaPDFToolStrip"
        Me.ApriAnteprimaPDFToolStrip.Size = New System.Drawing.Size(265, 22)
        Me.ApriAnteprimaPDFToolStrip.Text = "Apri Anteprima"
        '
        'MandaAlFlussoToolStripMenuItem
        '
        Me.MandaAlFlussoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Export
        Me.MandaAlFlussoToolStripMenuItem.Name = "MandaAlFlussoToolStripMenuItem"
        Me.MandaAlFlussoToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.MandaAlFlussoToolStripMenuItem.Text = "Manda al flusso"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(262, 6)
        '
        'ForzaIlLavoroAlMacchinarioToolStripMenuItem
        '
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem.Name = "ForzaIlLavoroAlMacchinarioToolStripMenuItem"
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem.Text = "Forza il lavoro al macchinario"
        '
        'lnkExportFlora
        '
        Me.lnkExportFlora.AutoSize = True
        Me.lnkExportFlora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkExportFlora.Image = Global.Former.My.Resources.Resources._FloraLogo
        Me.lnkExportFlora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkExportFlora.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkExportFlora.Location = New System.Drawing.Point(112, 89)
        Me.lnkExportFlora.Name = "lnkExportFlora"
        Me.lnkExportFlora.Padding = New System.Windows.Forms.Padding(85, 6, 0, 6)
        Me.lnkExportFlora.Size = New System.Drawing.Size(206, 27)
        Me.lnkExportFlora.TabIndex = 143
        Me.lnkExportFlora.TabStop = True
        Me.lnkExportFlora.Text = "Export Flora Xtra 2000"
        Me.lnkExportFlora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkExportFlora.Visible = False
        '
        'btnPrendiInCarico
        '
        Me.btnPrendiInCarico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrendiInCarico.BackColor = System.Drawing.Color.White
        Me.btnPrendiInCarico.FlatAppearance.BorderSize = 0
        Me.btnPrendiInCarico.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrendiInCarico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.btnPrendiInCarico.Image = Global.Former.My.Resources.Resources._PrendiInCarico1
        Me.btnPrendiInCarico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrendiInCarico.Location = New System.Drawing.Point(902, 85)
        Me.btnPrendiInCarico.Name = "btnPrendiInCarico"
        Me.btnPrendiInCarico.Size = New System.Drawing.Size(188, 31)
        Me.btnPrendiInCarico.TabIndex = 142
        Me.btnPrendiInCarico.TabStop = False
        Me.btnPrendiInCarico.Text = "Prendi in Carico il Lavoro"
        Me.btnPrendiInCarico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrendiInCarico.UseVisualStyleBackColor = False
        Me.btnPrendiInCarico.Visible = False
        '
        'lnkNew
        '
        Me.lnkNew.AutoSize = True
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._CommessaNew
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(470, 89)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkNew.Size = New System.Drawing.Size(134, 27)
        Me.lnkNew.TabIndex = 56
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuova Commessa"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkNew.Visible = False
        '
        'lnkAll
        '
        Me.lnkAll.AutoSize = True
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(3, 89)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAll.Size = New System.Drawing.Size(103, 27)
        Me.lnkAll.TabIndex = 46
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Mostra tutto"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgCommesseEx
        '
        Me.DgCommesseEx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgCommesseEx.AutoScroll = True
        Me.DgCommesseEx.AutoSizeRows = True
        Me.DgCommesseEx.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.DgCommesseEx.EnableGestures = False
        Me.DgCommesseEx.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgCommesseEx.Location = New System.Drawing.Point(3, 122)
        '
        '
        '
        Me.DgCommesseEx.MasterTemplate.AllowAddNewRow = False
        Me.DgCommesseEx.MasterTemplate.AllowCellContextMenu = False
        Me.DgCommesseEx.MasterTemplate.AllowColumnChooser = False
        Me.DgCommesseEx.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.DgCommesseEx.MasterTemplate.AllowDeleteRow = False
        Me.DgCommesseEx.MasterTemplate.AllowDragToGroup = False
        Me.DgCommesseEx.MasterTemplate.AllowEditRow = False
        Me.DgCommesseEx.MasterTemplate.AllowRowHeaderContextMenu = False
        Me.DgCommesseEx.MasterTemplate.AllowRowResize = False
        Me.DgCommesseEx.MasterTemplate.AllowSearchRow = True
        Me.DgCommesseEx.MasterTemplate.AutoGenerateColumns = False
        Me.DgCommesseEx.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewImageColumn1.FieldName = "IcoMsg"
        GridViewImageColumn1.HeaderText = ""
        GridViewImageColumn1.Name = "IcoMsg"
        GridViewImageColumn1.Width = 17
        GridViewImageColumn2.FieldName = "ImgAnteprima"
        GridViewImageColumn2.HeaderText = ""
        GridViewImageColumn2.Name = "ImgAnteprima"
        GridViewImageColumn2.Width = 69
        GridViewImageColumn3.FieldName = "ImgMacchinario"
        GridViewImageColumn3.HeaderText = ""
        GridViewImageColumn3.Name = "ImgMacchinario"
        GridViewImageColumn3.Width = 69
        GridViewTextBoxColumn1.FieldName = "PrioritaStr"
        GridViewTextBoxColumn1.HeaderText = "P!"
        GridViewTextBoxColumn1.Name = "Priorita"
        GridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn1.Width = 21
        GridViewTextBoxColumn2.FieldName = "IdCom"
        GridViewTextBoxColumn2.HeaderText = "Commessa"
        GridViewTextBoxColumn2.Name = "IdCom"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn2.Width = 86
        GridViewTextBoxColumn3.FieldName = "StatoStr"
        GridViewTextBoxColumn3.HeaderText = "Stato"
        GridViewTextBoxColumn3.Name = "Stato"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn3.Width = 117
        GridViewTextBoxColumn4.FieldName = "DataStr"
        GridViewTextBoxColumn4.HeaderText = "Data"
        GridViewTextBoxColumn4.Name = "Data"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 65
        GridViewTextBoxColumn5.FieldName = "TipoCommessaStr"
        GridViewTextBoxColumn5.HeaderText = "Tipo"
        GridViewTextBoxColumn5.Name = "TipoCommessa"
        GridViewTextBoxColumn5.Width = 192
        GridViewTextBoxColumn6.FieldName = "CopieStr"
        GridViewTextBoxColumn6.HeaderText = "Copie"
        GridViewTextBoxColumn6.Name = "Copie"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 65
        GridViewTextBoxColumn7.FieldName = "RisorsaStr"
        GridViewTextBoxColumn7.HeaderText = "Risorsa"
        GridViewTextBoxColumn7.Name = "Risorsa"
        GridViewTextBoxColumn7.Width = 161
        GridViewTextBoxColumn8.FieldName = "GGMancanti"
        GridViewTextBoxColumn8.FormatInfo = New System.Globalization.CultureInfo("it-IT")
        GridViewTextBoxColumn8.FormatString = "{0:C}"
        GridViewTextBoxColumn8.HeaderText = "GG"
        GridViewTextBoxColumn8.Name = "GGMancanti"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn9.FieldName = "PrimaConsegnaStr"
        GridViewTextBoxColumn9.HeaderText = "1° Consegna"
        GridViewTextBoxColumn9.Name = "PrimaConsegna"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn9.Width = 105
        GridViewTextBoxColumn10.FieldName = "CreataDa"
        GridViewTextBoxColumn10.HeaderText = "Creata da"
        GridViewTextBoxColumn10.Name = "CreataDa"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn10.Width = 83
        Me.DgCommesseEx.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewImageColumn1, GridViewImageColumn2, GridViewImageColumn3, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10})
        Me.DgCommesseEx.MasterTemplate.EnableAlternatingRowColor = True
        Me.DgCommesseEx.MasterTemplate.EnableGrouping = False
        Me.DgCommesseEx.MasterTemplate.MultiSelect = True
        Me.DgCommesseEx.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgCommesseEx.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.DgCommesseEx.Name = "DgCommesseEx"
        Me.DgCommesseEx.ReadOnly = True
        Me.DgCommesseEx.ShowGroupPanel = False
        Me.DgCommesseEx.ShowGroupPanelScrollbars = False
        Me.DgCommesseEx.ShowNoDataText = False
        Me.DgCommesseEx.Size = New System.Drawing.Size(1087, 448)
        Me.DgCommesseEx.TabIndex = 144
        Me.DgCommesseEx.ThemeName = "VisualStudio2012Light"
        '
        'rdExport
        '
        Me.rdExport.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdExport.Image = Global.Former.My.Resources.Resources._Export
        Me.rdExport.Items.AddRange(New Telerik.WinControls.RadItem() {Me.mnuFlora, Me.mnuExportEpson})
        Me.rdExport.Location = New System.Drawing.Point(324, 89)
        Me.rdExport.Name = "rdExport"
        Me.rdExport.Size = New System.Drawing.Size(140, 27)
        Me.rdExport.TabIndex = 145
        Me.rdExport.Text = "Export"
        Me.rdExport.Visible = False
        '
        'mnuFlora
        '
        Me.mnuFlora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuFlora.Name = "mnuFlora"
        Me.mnuFlora.Text = "Flora Xtra 2000"
        '
        'mnuExportEpson
        '
        Me.mnuExportEpson.Name = "mnuExportEpson"
        Me.mnuExportEpson.Text = "Epson T7000"
        '
        'ucCommesse
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.rdExport)
        Me.Controls.Add(Me.DgCommesseEx)
        Me.Controls.Add(Me.lnkExportFlora)
        Me.Controls.Add(Me.btnPrendiInCarico)
        Me.Controls.Add(Me.lblNumCopie)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblNumRis)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lnkAll)
        Me.Name = "ucCommesse"
        Me.Size = New System.Drawing.Size(1093, 586)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuOrd.ResumeLayout(False)
        CType(Me.DgCommesseEx.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgCommesseEx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkAll As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCerca As ucNumericTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lnkCerca As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents lblNumRis As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UcStatoCommesse As Former.ucCommesseStato
    Friend WithEvents lblNumCopie As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuOrd As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AllegaUnMessaggioAllaCommessaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrendiInCarico As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbMacchinari As ComboBox
    Friend WithEvents lnkExportFlora As LinkLabel
    Friend WithEvents dlgSaveCsv As FolderBrowserDialog
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ApriJobCommessaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ApriAnteprimaPDFToolStrip As ToolStripMenuItem
    Friend WithEvents ApriCartellaSorgentiCommessaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents NormaleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AltaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreaAnteprimaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MandaAlFlussoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dlgFolder As FolderBrowserDialog
    Friend WithEvents DgCommesseEx As Telerik.WinControls.UI.RadGridView
    Friend WithEvents UcCmbCliente As ucComboRubrica
    Friend WithEvents UnisciSelezionateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents rdExport As Telerik.WinControls.UI.RadDropDownButton
    Friend WithEvents mnuFlora As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents mnuExportEpson As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents ModificaCommessaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ForzaIlLavoroAlMacchinarioToolStripMenuItem As ToolStripMenuItem
End Class
