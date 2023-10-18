<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContabilitaRicavo
    Inherits baseFormInternaRedim

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContabilitaRicavo))
        Me.TabRicavo = New System.Windows.Forms.TabControl()
        Me.tbAlarm = New System.Windows.Forms.TabPage()
        Me.lblAzienda = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.pctIntEdit = New System.Windows.Forms.PictureBox()
        Me.pctIntRefresh = New System.Windows.Forms.PictureBox()
        Me.lblTotOrdini = New System.Windows.Forms.Label()
        Me.lblTotOrdini2 = New System.Windows.Forms.Label()
        Me.lblPrintCounter = New System.Windows.Forms.Label()
        Me.pnlImporti = New System.Windows.Forms.Panel()
        Me.cmbEsigiblitaIVA = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbEsclIvaNat = New System.Windows.Forms.ComboBox()
        Me.lnkIva4 = New System.Windows.Forms.LinkLabel()
        Me.lnkNoIva = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtImporto = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIva = New Former.ucNumericTextBox()
        Me.txtPercIva = New Former.ucNumericTextBox()
        Me.pctSblocco = New System.Windows.Forms.PictureBox()
        Me.cmbCat = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblAlert = New System.Windows.Forms.Label()
        Me.txtDataPrevPagam = New System.Windows.Forms.DateTimePicker()
        Me.lblCorr2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblCostoSped = New Former.ucNumericTextBox()
        Me.btnDetCli = New System.Windows.Forms.Button()
        Me.lblIntestazione = New System.Windows.Forms.Label()
        Me.tbDett = New System.Windows.Forms.TabControl()
        Me.tbVociFat = New System.Windows.Forms.TabPage()
        Me.btnModificaImp = New System.Windows.Forms.Button()
        Me.btnRimuovi = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnAddOrder = New System.Windows.Forms.Button()
        Me.DgDoc = New System.Windows.Forms.DataGridView()
        Me.Anteprima = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Ordine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prezzo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpPagam = New System.Windows.Forms.TabPage()
        Me.UcPagamenti = New Former.ucAmministrazionePagamenti()
        Me.tpVociFat = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgVociFat = New System.Windows.Forms.DataGridView()
        Me.tpStatoIncasso = New System.Windows.Forms.TabPage()
        Me.lnkSetIncassoImpossibile = New System.Windows.Forms.LinkLabel()
        Me.lnkSetIncassoDifficile = New System.Windows.Forms.LinkLabel()
        Me.lnkSetIncassoProblematico = New System.Windows.Forms.LinkLabel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lnkSetIncassoNormale = New System.Windows.Forms.LinkLabel()
        Me.lblStatoIncasso = New System.Windows.Forms.Label()
        Me.imlMain = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTotale = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbCorriere = New System.Windows.Forms.ComboBox()
        Me.lblCorr1 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNumero = New Former.ucNumericTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.lblTipoCli = New System.Windows.Forms.Label()
        Me.dataOp = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCognome = New System.Windows.Forms.Label()
        Me.txtDescrizione = New System.Windows.Forms.TextBox()
        Me.tpFatturaXML = New System.Windows.Forms.TabPage()
        Me.UcDocumentiFiscaliXMLRicavo = New Former.ucDocumentiFiscaliXMLRicavo()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.grpBtn = New System.Windows.Forms.GroupBox()
        Me.flowPanelPulsanti = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnStampa = New Former.ucLinkLabel()
        Me.lnkFattRiepilog = New System.Windows.Forms.LinkLabel()
        Me.btnStampaEmail = New System.Windows.Forms.LinkLabel()
        Me.btnRiapriPdf = New System.Windows.Forms.LinkLabel()
        Me.lnkPrintBarcode = New System.Windows.Forms.LinkLabel()
        Me.lnkApriCons = New System.Windows.Forms.LinkLabel()
        Me.lnkRegPagamento = New System.Windows.Forms.LinkLabel()
        Me.lnkNotaCredito = New System.Windows.Forms.LinkLabel()
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.btnConferma = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.mnuOrdini = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificaImportiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UsaNomeLavoroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabRicavo.SuspendLayout()
        Me.tbAlarm.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctIntEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctIntRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlImporti.SuspendLayout()
        CType(Me.pctSblocco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDett.SuspendLayout()
        Me.tbVociFat.SuspendLayout()
        CType(Me.DgDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPagam.SuspendLayout()
        Me.tpVociFat.SuspendLayout()
        CType(Me.dgVociFat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStatoIncasso.SuspendLayout()
        Me.tpFatturaXML.SuspendLayout()
        Me.grpBtn.SuspendLayout()
        Me.flowPanelPulsanti.SuspendLayout()
        Me.mnuOrdini.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabRicavo
        '
        Me.TabRicavo.Controls.Add(Me.tbAlarm)
        Me.TabRicavo.Controls.Add(Me.tpFatturaXML)
        Me.TabRicavo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabRicavo.ImageList = Me.imlTab
        Me.TabRicavo.Location = New System.Drawing.Point(0, 0)
        Me.TabRicavo.Name = "TabRicavo"
        Me.TabRicavo.SelectedIndex = 0
        Me.TabRicavo.Size = New System.Drawing.Size(1135, 766)
        Me.TabRicavo.TabIndex = 11
        '
        'tbAlarm
        '
        Me.tbAlarm.Controls.Add(Me.lblAzienda)
        Me.tbAlarm.Controls.Add(Me.pctTipo)
        Me.tbAlarm.Controls.Add(Me.lblTipo)
        Me.tbAlarm.Controls.Add(Me.pctIntEdit)
        Me.tbAlarm.Controls.Add(Me.pctIntRefresh)
        Me.tbAlarm.Controls.Add(Me.lblTotOrdini)
        Me.tbAlarm.Controls.Add(Me.lblTotOrdini2)
        Me.tbAlarm.Controls.Add(Me.lblPrintCounter)
        Me.tbAlarm.Controls.Add(Me.pnlImporti)
        Me.tbAlarm.Controls.Add(Me.pctSblocco)
        Me.tbAlarm.Controls.Add(Me.cmbCat)
        Me.tbAlarm.Controls.Add(Me.Label16)
        Me.tbAlarm.Controls.Add(Me.lblAlert)
        Me.tbAlarm.Controls.Add(Me.txtDataPrevPagam)
        Me.tbAlarm.Controls.Add(Me.lblCorr2)
        Me.tbAlarm.Controls.Add(Me.Label13)
        Me.tbAlarm.Controls.Add(Me.lblCostoSped)
        Me.tbAlarm.Controls.Add(Me.btnDetCli)
        Me.tbAlarm.Controls.Add(Me.lblIntestazione)
        Me.tbAlarm.Controls.Add(Me.tbDett)
        Me.tbAlarm.Controls.Add(Me.lblTotale)
        Me.tbAlarm.Controls.Add(Me.Label15)
        Me.tbAlarm.Controls.Add(Me.cmbCorriere)
        Me.tbAlarm.Controls.Add(Me.lblCorr1)
        Me.tbAlarm.Controls.Add(Me.cmbTipo)
        Me.tbAlarm.Controls.Add(Me.Label11)
        Me.tbAlarm.Controls.Add(Me.txtNumero)
        Me.tbAlarm.Controls.Add(Me.Label10)
        Me.tbAlarm.Controls.Add(Me.cmbCliente)
        Me.tbAlarm.Controls.Add(Me.lblTipoCli)
        Me.tbAlarm.Controls.Add(Me.dataOp)
        Me.tbAlarm.Controls.Add(Me.Label1)
        Me.tbAlarm.Controls.Add(Me.lblCognome)
        Me.tbAlarm.Controls.Add(Me.txtDescrizione)
        Me.tbAlarm.ImageKey = "ico_V_R.png"
        Me.tbAlarm.Location = New System.Drawing.Point(4, 31)
        Me.tbAlarm.Name = "tbAlarm"
        Me.tbAlarm.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAlarm.Size = New System.Drawing.Size(1127, 731)
        Me.tbAlarm.TabIndex = 0
        Me.tbAlarm.Text = "Documento Contabile"
        Me.tbAlarm.UseVisualStyleBackColor = True
        '
        'lblAzienda
        '
        Me.lblAzienda.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblAzienda.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAzienda.ForeColor = System.Drawing.Color.White
        Me.lblAzienda.Location = New System.Drawing.Point(141, 6)
        Me.lblAzienda.Name = "lblAzienda"
        Me.lblAzienda.Size = New System.Drawing.Size(111, 34)
        Me.lblAzienda.TabIndex = 119
        Me.lblAzienda.Text = "-"
        Me.lblAzienda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctTipo
        '
        Me.pctTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._DocumentoFiscale
        Me.pctTipo.Location = New System.Drawing.Point(21, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 118
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.White
        Me.lblTipo.Location = New System.Drawing.Point(56, 6)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(79, 34)
        Me.lblTipo.TabIndex = 117
        Me.lblTipo.Text = "Vendita"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pctIntEdit
        '
        Me.pctIntEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctIntEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctIntEdit.Enabled = False
        Me.pctIntEdit.Image = Global.Former.My.Resources.Resources._Modifica
        Me.pctIntEdit.Location = New System.Drawing.Point(669, 208)
        Me.pctIntEdit.Name = "pctIntEdit"
        Me.pctIntEdit.Size = New System.Drawing.Size(26, 26)
        Me.pctIntEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctIntEdit.TabIndex = 116
        Me.pctIntEdit.TabStop = False
        Me.toolTipHelp.SetToolTip(Me.pctIntEdit, "Modifica manualmente l'intestazione della fattura")
        Me.pctIntEdit.Visible = False
        '
        'pctIntRefresh
        '
        Me.pctIntRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctIntRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctIntRefresh.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.pctIntRefresh.Location = New System.Drawing.Point(637, 208)
        Me.pctIntRefresh.Name = "pctIntRefresh"
        Me.pctIntRefresh.Size = New System.Drawing.Size(26, 26)
        Me.pctIntRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctIntRefresh.TabIndex = 115
        Me.pctIntRefresh.TabStop = False
        Me.toolTipHelp.SetToolTip(Me.pctIntRefresh, "Ricarica i dati dell'intestazione del documento dalla scheda del cliente")
        '
        'lblTotOrdini
        '
        Me.lblTotOrdini.BackColor = System.Drawing.Color.LightGray
        Me.lblTotOrdini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotOrdini.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotOrdini.Location = New System.Drawing.Point(122, 203)
        Me.lblTotOrdini.Name = "lblTotOrdini"
        Me.lblTotOrdini.Size = New System.Drawing.Size(200, 21)
        Me.lblTotOrdini.TabIndex = 10
        Me.lblTotOrdini.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotOrdini2
        '
        Me.lblTotOrdini2.AutoSize = True
        Me.lblTotOrdini2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotOrdini2.ForeColor = System.Drawing.Color.Black
        Me.lblTotOrdini2.Location = New System.Drawing.Point(18, 207)
        Me.lblTotOrdini2.Name = "lblTotOrdini2"
        Me.lblTotOrdini2.Size = New System.Drawing.Size(74, 15)
        Me.lblTotOrdini2.TabIndex = 87
        Me.lblTotOrdini2.Text = "Totale Ordini"
        '
        'lblPrintCounter
        '
        Me.lblPrintCounter.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblPrintCounter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrintCounter.ForeColor = System.Drawing.Color.Black
        Me.lblPrintCounter.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lblPrintCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPrintCounter.Location = New System.Drawing.Point(416, 12)
        Me.lblPrintCounter.Name = "lblPrintCounter"
        Me.lblPrintCounter.Size = New System.Drawing.Size(200, 26)
        Me.lblPrintCounter.TabIndex = 114
        Me.lblPrintCounter.Tag = "          Counter Stampe: "
        Me.lblPrintCounter.Text = "          Counter Stampe: "
        Me.lblPrintCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPrintCounter.Visible = False
        '
        'pnlImporti
        '
        Me.pnlImporti.Controls.Add(Me.cmbEsigiblitaIVA)
        Me.pnlImporti.Controls.Add(Me.Label5)
        Me.pnlImporti.Controls.Add(Me.cmbEsclIvaNat)
        Me.pnlImporti.Controls.Add(Me.lnkIva4)
        Me.pnlImporti.Controls.Add(Me.lnkNoIva)
        Me.pnlImporti.Controls.Add(Me.Label2)
        Me.pnlImporti.Controls.Add(Me.txtImporto)
        Me.pnlImporti.Controls.Add(Me.Label3)
        Me.pnlImporti.Controls.Add(Me.Label4)
        Me.pnlImporti.Controls.Add(Me.txtIva)
        Me.pnlImporti.Controls.Add(Me.txtPercIva)
        Me.pnlImporti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnlImporti.Location = New System.Drawing.Point(10, 255)
        Me.pnlImporti.Name = "pnlImporti"
        Me.pnlImporti.Size = New System.Drawing.Size(1105, 55)
        Me.pnlImporti.TabIndex = 9
        '
        'cmbEsigiblitaIVA
        '
        Me.cmbEsigiblitaIVA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEsigiblitaIVA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEsigiblitaIVA.BackColor = System.Drawing.Color.White
        Me.cmbEsigiblitaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsigiblitaIVA.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbEsigiblitaIVA.ForeColor = System.Drawing.Color.Black
        Me.cmbEsigiblitaIVA.FormattingEnabled = True
        Me.cmbEsigiblitaIVA.Location = New System.Drawing.Point(994, 30)
        Me.cmbEsigiblitaIVA.Name = "cmbEsigiblitaIVA"
        Me.cmbEsigiblitaIVA.Size = New System.Drawing.Size(108, 23)
        Me.cmbEsigiblitaIVA.TabIndex = 140
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(911, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 15)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Esigibilità IVA"
        '
        'cmbEsclIvaNat
        '
        Me.cmbEsclIvaNat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsclIvaNat.Enabled = False
        Me.cmbEsclIvaNat.FormattingEnabled = True
        Me.cmbEsclIvaNat.Location = New System.Drawing.Point(516, 30)
        Me.cmbEsclIvaNat.Name = "cmbEsclIvaNat"
        Me.cmbEsclIvaNat.Size = New System.Drawing.Size(389, 23)
        Me.cmbEsclIvaNat.TabIndex = 90
        '
        'lnkIva4
        '
        Me.lnkIva4.AutoSize = True
        Me.lnkIva4.Enabled = False
        Me.lnkIva4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkIva4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkIva4.Location = New System.Drawing.Point(406, 33)
        Me.lnkIva4.Name = "lnkIva4"
        Me.lnkIva4.Size = New System.Drawing.Size(48, 15)
        Me.lnkIva4.TabIndex = 89
        Me.lnkIva4.TabStop = True
        Me.lnkIva4.Text = "IVA 4%?"
        '
        'lnkNoIva
        '
        Me.lnkNoIva.AutoSize = True
        Me.lnkNoIva.Enabled = False
        Me.lnkNoIva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNoIva.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNoIva.Location = New System.Drawing.Point(460, 33)
        Me.lnkNoIva.Name = "lnkNoIva"
        Me.lnkNoIva.Size = New System.Drawing.Size(50, 15)
        Me.lnkNoIva.TabIndex = 88
        Me.lnkNoIva.TabStop = True
        Me.lnkNoIva.Text = "NO IVA?"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 15)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Totale Netto *"
        '
        'txtImporto
        '
        Me.txtImporto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtImporto.Location = New System.Drawing.Point(112, 3)
        Me.txtImporto.My_AccettaNegativi = False
        Me.txtImporto.My_AllowOnlyInteger = False
        Me.txtImporto.My_DefaultValue = 0
        Me.txtImporto.My_MaxValue = 1.0E+10!
        Me.txtImporto.My_MinValue = 0!
        Me.txtImporto.My_ReplaceWithDefaultValue = True
        Me.txtImporto.Name = "txtImporto"
        Me.txtImporto.ReadOnly = True
        Me.txtImporto.Size = New System.Drawing.Size(200, 23)
        Me.txtImporto.TabIndex = 12
        Me.txtImporto.Text = "0"
        Me.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(318, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "% IVA *"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 15)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "IVA"
        '
        'txtIva
        '
        Me.txtIva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIva.Location = New System.Drawing.Point(112, 30)
        Me.txtIva.My_AccettaNegativi = False
        Me.txtIva.My_AllowOnlyInteger = False
        Me.txtIva.My_DefaultValue = 0
        Me.txtIva.My_MaxValue = 1.0E+10!
        Me.txtIva.My_MinValue = 0!
        Me.txtIva.My_ReplaceWithDefaultValue = True
        Me.txtIva.Name = "txtIva"
        Me.txtIva.ReadOnly = True
        Me.txtIva.Size = New System.Drawing.Size(200, 23)
        Me.txtIva.TabIndex = 13
        Me.txtIva.Text = "0"
        Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPercIva
        '
        Me.txtPercIva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPercIva.Location = New System.Drawing.Point(367, 30)
        Me.txtPercIva.MaxLength = 2
        Me.txtPercIva.My_AccettaNegativi = False
        Me.txtPercIva.My_AllowOnlyInteger = True
        Me.txtPercIva.My_DefaultValue = 0
        Me.txtPercIva.My_MaxValue = 99.0!
        Me.txtPercIva.My_MinValue = 0!
        Me.txtPercIva.My_ReplaceWithDefaultValue = True
        Me.txtPercIva.Name = "txtPercIva"
        Me.txtPercIva.ReadOnly = True
        Me.txtPercIva.Size = New System.Drawing.Size(28, 23)
        Me.txtPercIva.TabIndex = 14
        Me.txtPercIva.Text = "20"
        Me.txtPercIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pctSblocco
        '
        Me.pctSblocco.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctSblocco.Image = Global.Former.My.Resources.Resources._LucchettoAperto
        Me.pctSblocco.Location = New System.Drawing.Point(258, 10)
        Me.pctSblocco.Name = "pctSblocco"
        Me.pctSblocco.Size = New System.Drawing.Size(26, 26)
        Me.pctSblocco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctSblocco.TabIndex = 113
        Me.pctSblocco.TabStop = False
        Me.pctSblocco.Visible = False
        '
        'cmbCat
        '
        Me.cmbCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(419, 64)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(200, 23)
        Me.cmbCat.TabIndex = 2
        Me.cmbCat.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(328, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 15)
        Me.Label16.TabIndex = 96
        Me.Label16.Text = "Categoria"
        Me.Label16.Visible = False
        '
        'lblAlert
        '
        Me.lblAlert.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAlert.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblAlert.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.lblAlert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAlert.Location = New System.Drawing.Point(363, 340)
        Me.lblAlert.Name = "lblAlert"
        Me.lblAlert.Size = New System.Drawing.Size(572, 26)
        Me.lblAlert.TabIndex = 94
        Me.lblAlert.Text = "Per inserire il dettaglio del documento effettuare prima il salvataggio!"
        Me.lblAlert.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblAlert.Visible = False
        '
        'txtDataPrevPagam
        '
        Me.txtDataPrevPagam.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDataPrevPagam.Location = New System.Drawing.Point(419, 93)
        Me.txtDataPrevPagam.Name = "txtDataPrevPagam"
        Me.txtDataPrevPagam.Size = New System.Drawing.Size(200, 23)
        Me.txtDataPrevPagam.TabIndex = 4
        '
        'lblCorr2
        '
        Me.lblCorr2.AutoSize = True
        Me.lblCorr2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCorr2.ForeColor = System.Drawing.Color.Black
        Me.lblCorr2.Location = New System.Drawing.Point(18, 233)
        Me.lblCorr2.Name = "lblCorr2"
        Me.lblCorr2.Size = New System.Drawing.Size(94, 15)
        Me.lblCorr2.TabIndex = 82
        Me.lblCorr2.Text = "Costo spedizioni"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(328, 96)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 15)
        Me.Label13.TabIndex = 91
        Me.Label13.Text = "Da pagare il "
        '
        'lblCostoSped
        '
        Me.lblCostoSped.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCostoSped.Location = New System.Drawing.Point(122, 230)
        Me.lblCostoSped.MaxLength = 5
        Me.lblCostoSped.My_AccettaNegativi = False
        Me.lblCostoSped.My_AllowOnlyInteger = False
        Me.lblCostoSped.My_DefaultValue = 0
        Me.lblCostoSped.My_MaxValue = 9999.0!
        Me.lblCostoSped.My_MinValue = 0!
        Me.lblCostoSped.My_ReplaceWithDefaultValue = True
        Me.lblCostoSped.Name = "lblCostoSped"
        Me.lblCostoSped.Size = New System.Drawing.Size(200, 23)
        Me.lblCostoSped.TabIndex = 11
        Me.lblCostoSped.Text = "0"
        Me.lblCostoSped.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDetCli
        '
        Me.btnDetCli.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDetCli.Location = New System.Drawing.Point(595, 120)
        Me.btnDetCli.Name = "btnDetCli"
        Me.btnDetCli.Size = New System.Drawing.Size(24, 23)
        Me.btnDetCli.TabIndex = 6
        Me.btnDetCli.Text = "..."
        Me.btnDetCli.UseVisualStyleBackColor = True
        '
        'lblIntestazione
        '
        Me.lblIntestazione.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIntestazione.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIntestazione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblIntestazione.Location = New System.Drawing.Point(634, 6)
        Me.lblIntestazione.Name = "lblIntestazione"
        Me.lblIntestazione.Size = New System.Drawing.Size(481, 199)
        Me.lblIntestazione.TabIndex = 89
        Me.lblIntestazione.Text = "Intestazione"
        '
        'tbDett
        '
        Me.tbDett.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDett.Controls.Add(Me.tbVociFat)
        Me.tbDett.Controls.Add(Me.tpPagam)
        Me.tbDett.Controls.Add(Me.tpVociFat)
        Me.tbDett.Controls.Add(Me.tpStatoIncasso)
        Me.tbDett.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbDett.ImageList = Me.imlMain
        Me.tbDett.Location = New System.Drawing.Point(6, 374)
        Me.tbDett.Name = "tbDett"
        Me.tbDett.SelectedIndex = 0
        Me.tbDett.Size = New System.Drawing.Size(1113, 351)
        Me.tbDett.TabIndex = 28
        '
        'tbVociFat
        '
        Me.tbVociFat.Controls.Add(Me.btnModificaImp)
        Me.tbVociFat.Controls.Add(Me.btnRimuovi)
        Me.tbVociFat.Controls.Add(Me.btnAdd)
        Me.tbVociFat.Controls.Add(Me.btnAddOrder)
        Me.tbVociFat.Controls.Add(Me.DgDoc)
        Me.tbVociFat.ImageKey = "_Ordine.png"
        Me.tbVociFat.Location = New System.Drawing.Point(4, 24)
        Me.tbVociFat.Name = "tbVociFat"
        Me.tbVociFat.Padding = New System.Windows.Forms.Padding(3)
        Me.tbVociFat.Size = New System.Drawing.Size(1105, 323)
        Me.tbVociFat.TabIndex = 0
        Me.tbVociFat.Text = "Dettaglio Ordini"
        Me.tbVociFat.UseVisualStyleBackColor = True
        '
        'btnModificaImp
        '
        Me.btnModificaImp.BackColor = System.Drawing.Color.White
        Me.btnModificaImp.Image = Global.Former.My.Resources.Resources._Prezzo
        Me.btnModificaImp.Location = New System.Drawing.Point(4, 153)
        Me.btnModificaImp.Name = "btnModificaImp"
        Me.btnModificaImp.Size = New System.Drawing.Size(69, 69)
        Me.btnModificaImp.TabIndex = 21
        Me.btnModificaImp.UseVisualStyleBackColor = False
        '
        'btnRimuovi
        '
        Me.btnRimuovi.BackColor = System.Drawing.Color.White
        Me.btnRimuovi.Image = Global.Former.My.Resources.Resources._remove
        Me.btnRimuovi.Location = New System.Drawing.Point(4, 228)
        Me.btnRimuovi.Name = "btnRimuovi"
        Me.btnRimuovi.Size = New System.Drawing.Size(69, 69)
        Me.btnRimuovi.TabIndex = 20
        Me.btnRimuovi.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnAdd.Location = New System.Drawing.Point(4, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(69, 69)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnAddOrder
        '
        Me.btnAddOrder.BackColor = System.Drawing.Color.White
        Me.btnAddOrder.Image = Global.Former.My.Resources.Resources._Ordine
        Me.btnAddOrder.Location = New System.Drawing.Point(4, 78)
        Me.btnAddOrder.Name = "btnAddOrder"
        Me.btnAddOrder.Size = New System.Drawing.Size(69, 69)
        Me.btnAddOrder.TabIndex = 19
        Me.btnAddOrder.UseVisualStyleBackColor = False
        '
        'DgDoc
        '
        Me.DgDoc.AllowUserToAddRows = False
        Me.DgDoc.AllowUserToDeleteRows = False
        Me.DgDoc.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgDoc.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgDoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgDoc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgDoc.BackgroundColor = System.Drawing.Color.White
        Me.DgDoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgDoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgDoc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgDoc.ColumnHeadersHeight = 20
        Me.DgDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgDoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Anteprima, Me.Ordine, Me.Codice, Me.Descrizione, Me.Qta, Me.Prezzo})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgDoc.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgDoc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgDoc.EnableHeadersVisualStyles = False
        Me.DgDoc.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgDoc.Location = New System.Drawing.Point(79, 3)
        Me.DgDoc.MultiSelect = False
        Me.DgDoc.Name = "DgDoc"
        Me.DgDoc.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgDoc.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgDoc.RowHeadersVisible = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.DgDoc.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DgDoc.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.DgDoc.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgDoc.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgDoc.RowTemplate.Height = 150
        Me.DgDoc.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgDoc.Size = New System.Drawing.Size(1023, 314)
        Me.DgDoc.TabIndex = 17
        Me.DgDoc.TabStop = False
        '
        'Anteprima
        '
        Me.Anteprima.HeaderText = "Anteprima"
        Me.Anteprima.Name = "Anteprima"
        Me.Anteprima.ReadOnly = True
        '
        'Ordine
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Ordine.DefaultCellStyle = DataGridViewCellStyle3
        Me.Ordine.HeaderText = "Ordine"
        Me.Ordine.Name = "Ordine"
        Me.Ordine.ReadOnly = True
        '
        'Codice
        '
        Me.Codice.HeaderText = "Codice"
        Me.Codice.Name = "Codice"
        Me.Codice.ReadOnly = True
        '
        'Descrizione
        '
        Me.Descrizione.HeaderText = "Descrizione"
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.ReadOnly = True
        '
        'Qta
        '
        Me.Qta.HeaderText = "Qta"
        Me.Qta.Name = "Qta"
        Me.Qta.ReadOnly = True
        '
        'Prezzo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Prezzo.DefaultCellStyle = DataGridViewCellStyle4
        Me.Prezzo.HeaderText = "Prezzo"
        Me.Prezzo.Name = "Prezzo"
        Me.Prezzo.ReadOnly = True
        '
        'tpPagam
        '
        Me.tpPagam.Controls.Add(Me.UcPagamenti)
        Me.tpPagam.ImageKey = "_Pagamento.png"
        Me.tpPagam.Location = New System.Drawing.Point(4, 24)
        Me.tpPagam.Name = "tpPagam"
        Me.tpPagam.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPagam.Size = New System.Drawing.Size(1105, 323)
        Me.tpPagam.TabIndex = 2
        Me.tpPagam.Text = "Pagamenti"
        Me.tpPagam.UseVisualStyleBackColor = True
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
        Me.UcPagamenti.Size = New System.Drawing.Size(1099, 317)
        Me.UcPagamenti.TabIndex = 0
        Me.UcPagamenti.TipoVoceContabile = FormerLib.FormerEnum.enTipoVoceContab.NonSpecificata
        '
        'tpVociFat
        '
        Me.tpVociFat.Controls.Add(Me.Label14)
        Me.tpVociFat.Controls.Add(Me.dgVociFat)
        Me.tpVociFat.ImageKey = "_Dividi.png"
        Me.tpVociFat.Location = New System.Drawing.Point(4, 24)
        Me.tpVociFat.Name = "tpVociFat"
        Me.tpVociFat.Padding = New System.Windows.Forms.Padding(3)
        Me.tpVociFat.Size = New System.Drawing.Size(1105, 323)
        Me.tpVociFat.TabIndex = 4
        Me.tpVociFat.Text = "Righe fattura"
        Me.tpVociFat.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.Location = New System.Drawing.Point(6, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(457, 24)
        Me.Label14.TabIndex = 95
        Me.Label14.Text = "       Attenzione!!! Da questa schermata si modificano direttamente le righe in f" &
    "attura."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgVociFat
        '
        Me.dgVociFat.AllowUserToAddRows = False
        Me.dgVociFat.AllowUserToDeleteRows = False
        Me.dgVociFat.AllowUserToResizeRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.dgVociFat.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgVociFat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgVociFat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgVociFat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgVociFat.BackgroundColor = System.Drawing.Color.White
        Me.dgVociFat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgVociFat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVociFat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgVociFat.ColumnHeadersHeight = 20
        Me.dgVociFat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgVociFat.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgVociFat.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgVociFat.EnableHeadersVisualStyles = False
        Me.dgVociFat.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgVociFat.Location = New System.Drawing.Point(3, 30)
        Me.dgVociFat.MultiSelect = False
        Me.dgVociFat.Name = "dgVociFat"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgVociFat.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgVociFat.RowHeadersVisible = False
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.dgVociFat.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgVociFat.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.dgVociFat.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgVociFat.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgVociFat.RowTemplate.Height = 150
        Me.dgVociFat.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVociFat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgVociFat.Size = New System.Drawing.Size(1096, 287)
        Me.dgVociFat.TabIndex = 81
        Me.dgVociFat.TabStop = False
        '
        'tpStatoIncasso
        '
        Me.tpStatoIncasso.Controls.Add(Me.lnkSetIncassoImpossibile)
        Me.tpStatoIncasso.Controls.Add(Me.lnkSetIncassoDifficile)
        Me.tpStatoIncasso.Controls.Add(Me.lnkSetIncassoProblematico)
        Me.tpStatoIncasso.Controls.Add(Me.Label12)
        Me.tpStatoIncasso.Controls.Add(Me.lnkSetIncassoNormale)
        Me.tpStatoIncasso.Controls.Add(Me.lblStatoIncasso)
        Me.tpStatoIncasso.ImageKey = "_StatoIncasso.png"
        Me.tpStatoIncasso.Location = New System.Drawing.Point(4, 24)
        Me.tpStatoIncasso.Name = "tpStatoIncasso"
        Me.tpStatoIncasso.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStatoIncasso.Size = New System.Drawing.Size(1105, 323)
        Me.tpStatoIncasso.TabIndex = 5
        Me.tpStatoIncasso.Text = "Stato Incasso"
        Me.tpStatoIncasso.UseVisualStyleBackColor = True
        '
        'lnkSetIncassoImpossibile
        '
        Me.lnkSetIncassoImpossibile.BackColor = System.Drawing.Color.White
        Me.lnkSetIncassoImpossibile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkSetIncassoImpossibile.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkSetIncassoImpossibile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSetIncassoImpossibile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSetIncassoImpossibile.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSetIncassoImpossibile.Location = New System.Drawing.Point(530, 48)
        Me.lnkSetIncassoImpossibile.Name = "lnkSetIncassoImpossibile"
        Me.lnkSetIncassoImpossibile.Size = New System.Drawing.Size(126, 34)
        Me.lnkSetIncassoImpossibile.TabIndex = 28
        Me.lnkSetIncassoImpossibile.TabStop = True
        Me.lnkSetIncassoImpossibile.Text = "Impossibile"
        Me.lnkSetIncassoImpossibile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkSetIncassoDifficile
        '
        Me.lnkSetIncassoDifficile.BackColor = System.Drawing.Color.White
        Me.lnkSetIncassoDifficile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkSetIncassoDifficile.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkSetIncassoDifficile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSetIncassoDifficile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSetIncassoDifficile.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSetIncassoDifficile.Location = New System.Drawing.Point(398, 48)
        Me.lnkSetIncassoDifficile.Name = "lnkSetIncassoDifficile"
        Me.lnkSetIncassoDifficile.Size = New System.Drawing.Size(126, 34)
        Me.lnkSetIncassoDifficile.TabIndex = 27
        Me.lnkSetIncassoDifficile.TabStop = True
        Me.lnkSetIncassoDifficile.Text = "Difficile"
        Me.lnkSetIncassoDifficile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkSetIncassoProblematico
        '
        Me.lnkSetIncassoProblematico.BackColor = System.Drawing.Color.White
        Me.lnkSetIncassoProblematico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkSetIncassoProblematico.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkSetIncassoProblematico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSetIncassoProblematico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSetIncassoProblematico.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSetIncassoProblematico.Location = New System.Drawing.Point(266, 48)
        Me.lnkSetIncassoProblematico.Name = "lnkSetIncassoProblematico"
        Me.lnkSetIncassoProblematico.Size = New System.Drawing.Size(126, 34)
        Me.lnkSetIncassoProblematico.TabIndex = 26
        Me.lnkSetIncassoProblematico.TabStop = True
        Me.lnkSetIncassoProblematico.Text = "Problematico"
        Me.lnkSetIncassoProblematico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label12.Location = New System.Drawing.Point(6, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 15)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Imposta Stato Incasso"
        '
        'lnkSetIncassoNormale
        '
        Me.lnkSetIncassoNormale.BackColor = System.Drawing.Color.White
        Me.lnkSetIncassoNormale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkSetIncassoNormale.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkSetIncassoNormale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSetIncassoNormale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSetIncassoNormale.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSetIncassoNormale.Location = New System.Drawing.Point(134, 48)
        Me.lnkSetIncassoNormale.Name = "lnkSetIncassoNormale"
        Me.lnkSetIncassoNormale.Size = New System.Drawing.Size(126, 34)
        Me.lnkSetIncassoNormale.TabIndex = 24
        Me.lnkSetIncassoNormale.TabStop = True
        Me.lnkSetIncassoNormale.Text = "Normale"
        Me.lnkSetIncassoNormale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatoIncasso
        '
        Me.lblStatoIncasso.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStatoIncasso.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatoIncasso.Location = New System.Drawing.Point(3, 3)
        Me.lblStatoIncasso.Name = "lblStatoIncasso"
        Me.lblStatoIncasso.Size = New System.Drawing.Size(1099, 45)
        Me.lblStatoIncasso.TabIndex = 0
        Me.lblStatoIncasso.Text = "-"
        Me.lblStatoIncasso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imlMain
        '
        Me.imlMain.ImageStream = CType(resources.GetObject("imlMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMain.Images.SetKeyName(0, "_Ordine.png")
        Me.imlMain.Images.SetKeyName(1, "_Pagamento.png")
        Me.imlMain.Images.SetKeyName(2, "_Anteprima.png")
        Me.imlMain.Images.SetKeyName(3, "_StatoIncasso.png")
        Me.imlMain.Images.SetKeyName(4, "_Dividi.png")
        '
        'lblTotale
        '
        Me.lblTotale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotale.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotale.ForeColor = System.Drawing.Color.Black
        Me.lblTotale.Location = New System.Drawing.Point(122, 340)
        Me.lblTotale.Name = "lblTotale"
        Me.lblTotale.Size = New System.Drawing.Size(200, 26)
        Me.lblTotale.TabIndex = 16
        Me.lblTotale.Text = "0"
        Me.lblTotale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(18, 344)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 15)
        Me.Label15.TabIndex = 84
        Me.Label15.Text = "Totale"
        '
        'cmbCorriere
        '
        Me.cmbCorriere.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCorriere.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCorriere.BackColor = System.Drawing.Color.White
        Me.cmbCorriere.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCorriere.ForeColor = System.Drawing.Color.Black
        Me.cmbCorriere.FormattingEnabled = True
        Me.cmbCorriere.Location = New System.Drawing.Point(122, 314)
        Me.cmbCorriere.Name = "cmbCorriere"
        Me.cmbCorriere.Size = New System.Drawing.Size(200, 23)
        Me.cmbCorriere.TabIndex = 15
        '
        'lblCorr1
        '
        Me.lblCorr1.AutoSize = True
        Me.lblCorr1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCorr1.ForeColor = System.Drawing.Color.Black
        Me.lblCorr1.Location = New System.Drawing.Point(18, 317)
        Me.lblCorr1.Name = "lblCorr1"
        Me.lblCorr1.Size = New System.Drawing.Size(49, 15)
        Me.lblCorr1.TabIndex = 81
        Me.lblCorr1.Text = "Corriere"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(122, 64)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(200, 23)
        Me.cmbTipo.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(18, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 15)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Tipo"
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNumero.Location = New System.Drawing.Point(122, 177)
        Me.txtNumero.My_AccettaNegativi = False
        Me.txtNumero.My_AllowOnlyInteger = True
        Me.txtNumero.My_DefaultValue = 0
        Me.txtNumero.My_MaxValue = 1.0E+10!
        Me.txtNumero.My_MinValue = 0!
        Me.txtNumero.My_ReplaceWithDefaultValue = True
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(61, 23)
        Me.txtNumero.TabIndex = 8
        Me.txtNumero.Text = "0"
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(18, 180)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 15)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Numero"
        '
        'cmbCliente
        '
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(122, 121)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(467, 23)
        Me.cmbCliente.TabIndex = 5
        '
        'lblTipoCli
        '
        Me.lblTipoCli.AutoSize = True
        Me.lblTipoCli.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipoCli.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTipoCli.Location = New System.Drawing.Point(18, 124)
        Me.lblTipoCli.Name = "lblTipoCli"
        Me.lblTipoCli.Size = New System.Drawing.Size(83, 15)
        Me.lblTipoCli.TabIndex = 52
        Me.lblTipoCli.Text = "Destinatario *"
        '
        'dataOp
        '
        Me.dataOp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dataOp.Location = New System.Drawing.Point(122, 93)
        Me.dataOp.Name = "dataOp"
        Me.dataOp.Size = New System.Drawing.Size(200, 23)
        Me.dataOp.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(18, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Data *"
        '
        'lblCognome
        '
        Me.lblCognome.AutoSize = True
        Me.lblCognome.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCognome.ForeColor = System.Drawing.Color.Black
        Me.lblCognome.Location = New System.Drawing.Point(18, 153)
        Me.lblCognome.Name = "lblCognome"
        Me.lblCognome.Size = New System.Drawing.Size(67, 15)
        Me.lblCognome.TabIndex = 40
        Me.lblCognome.Text = "Descrizione"
        '
        'txtDescrizione
        '
        Me.txtDescrizione.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescrizione.Location = New System.Drawing.Point(122, 150)
        Me.txtDescrizione.Name = "txtDescrizione"
        Me.txtDescrizione.Size = New System.Drawing.Size(497, 23)
        Me.txtDescrizione.TabIndex = 7
        '
        'tpFatturaXML
        '
        Me.tpFatturaXML.Controls.Add(Me.UcDocumentiFiscaliXMLRicavo)
        Me.tpFatturaXML.ImageKey = "_xml.png"
        Me.tpFatturaXML.Location = New System.Drawing.Point(4, 31)
        Me.tpFatturaXML.Name = "tpFatturaXML"
        Me.tpFatturaXML.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFatturaXML.Size = New System.Drawing.Size(1127, 731)
        Me.tpFatturaXML.TabIndex = 1
        Me.tpFatturaXML.Text = "Fattura XML"
        Me.tpFatturaXML.UseVisualStyleBackColor = True
        '
        'UcDocumentiFiscaliXMLRicavo
        '
        Me.UcDocumentiFiscaliXMLRicavo.BackColor = System.Drawing.Color.White
        Me.UcDocumentiFiscaliXMLRicavo.CaricamentoCompletato = False
        Me.UcDocumentiFiscaliXMLRicavo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcDocumentiFiscaliXMLRicavo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcDocumentiFiscaliXMLRicavo.Location = New System.Drawing.Point(3, 3)
        Me.UcDocumentiFiscaliXMLRicavo.Name = "UcDocumentiFiscaliXMLRicavo"
        Me.UcDocumentiFiscaliXMLRicavo.Size = New System.Drawing.Size(1121, 725)
        Me.UcDocumentiFiscaliXMLRicavo.TabIndex = 0
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "ico_A_R.png")
        Me.imlTab.Images.SetKeyName(1, "_pdf.png")
        Me.imlTab.Images.SetKeyName(2, "ico_V_R.png")
        Me.imlTab.Images.SetKeyName(3, "_xml.png")
        '
        'grpBtn
        '
        Me.grpBtn.BackColor = System.Drawing.Color.White
        Me.grpBtn.Controls.Add(Me.flowPanelPulsanti)
        Me.grpBtn.Controls.Add(Me.btnAnnulla)
        Me.grpBtn.Controls.Add(Me.btnConferma)
        Me.grpBtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpBtn.ForeColor = System.Drawing.Color.White
        Me.grpBtn.Location = New System.Drawing.Point(0, 766)
        Me.grpBtn.Name = "grpBtn"
        Me.grpBtn.Padding = New System.Windows.Forms.Padding(20)
        Me.grpBtn.Size = New System.Drawing.Size(1135, 51)
        Me.grpBtn.TabIndex = 12
        Me.grpBtn.TabStop = False
        '
        'flowPanelPulsanti
        '
        Me.flowPanelPulsanti.Controls.Add(Me.btnStampa)
        Me.flowPanelPulsanti.Controls.Add(Me.lnkFattRiepilog)
        Me.flowPanelPulsanti.Controls.Add(Me.btnStampaEmail)
        Me.flowPanelPulsanti.Controls.Add(Me.btnRiapriPdf)
        Me.flowPanelPulsanti.Controls.Add(Me.lnkPrintBarcode)
        Me.flowPanelPulsanti.Controls.Add(Me.lnkApriCons)
        Me.flowPanelPulsanti.Controls.Add(Me.lnkRegPagamento)
        Me.flowPanelPulsanti.Controls.Add(Me.lnkNotaCredito)
        Me.flowPanelPulsanti.Location = New System.Drawing.Point(10, 13)
        Me.flowPanelPulsanti.Name = "flowPanelPulsanti"
        Me.flowPanelPulsanti.Size = New System.Drawing.Size(1037, 33)
        Me.flowPanelPulsanti.TabIndex = 30
        '
        'btnStampa
        '
        Me.btnStampa.AutoSize = True
        Me.btnStampa.BackColor = System.Drawing.Color.White
        Me.btnStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnStampa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.btnStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStampa.Location = New System.Drawing.Point(3, 0)
        Me.btnStampa.Name = "btnStampa"
        Me.btnStampa.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.btnStampa.RoundedBorder = False
        Me.btnStampa.Size = New System.Drawing.Size(75, 27)
        Me.btnStampa.TabIndex = 21
        Me.btnStampa.TabStop = True
        Me.btnStampa.Text = "Stampa"
        Me.btnStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStampa.Visible = False
        '
        'lnkFattRiepilog
        '
        Me.lnkFattRiepilog.AutoSize = True
        Me.lnkFattRiepilog.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkFattRiepilog.Image = Global.Former.My.Resources.Resources._DocumentoFiscale
        Me.lnkFattRiepilog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkFattRiepilog.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkFattRiepilog.Location = New System.Drawing.Point(84, 0)
        Me.lnkFattRiepilog.Name = "lnkFattRiepilog"
        Me.lnkFattRiepilog.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkFattRiepilog.Size = New System.Drawing.Size(174, 27)
        Me.lnkFattRiepilog.TabIndex = 24
        Me.lnkFattRiepilog.TabStop = True
        Me.lnkFattRiepilog.Text = "Apri Fattura Riepilogativa"
        Me.lnkFattRiepilog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkFattRiepilog.Visible = False
        '
        'btnStampaEmail
        '
        Me.btnStampaEmail.AutoSize = True
        Me.btnStampaEmail.BackColor = System.Drawing.Color.White
        Me.btnStampaEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStampaEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnStampaEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStampaEmail.Image = Global.Former.My.Resources.Resources._pdf
        Me.btnStampaEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampaEmail.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStampaEmail.Location = New System.Drawing.Point(264, 0)
        Me.btnStampaEmail.Name = "btnStampaEmail"
        Me.btnStampaEmail.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.btnStampaEmail.Size = New System.Drawing.Size(100, 27)
        Me.btnStampaEmail.TabIndex = 22
        Me.btnStampaEmail.TabStop = True
        Me.btnStampaEmail.Text = "Stampa PDF"
        Me.btnStampaEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRiapriPdf
        '
        Me.btnRiapriPdf.AutoSize = True
        Me.btnRiapriPdf.BackColor = System.Drawing.Color.White
        Me.btnRiapriPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRiapriPdf.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRiapriPdf.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnRiapriPdf.Image = Global.Former.My.Resources.Resources._pdf
        Me.btnRiapriPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRiapriPdf.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnRiapriPdf.Location = New System.Drawing.Point(370, 0)
        Me.btnRiapriPdf.Name = "btnRiapriPdf"
        Me.btnRiapriPdf.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.btnRiapriPdf.Size = New System.Drawing.Size(90, 27)
        Me.btnRiapriPdf.TabIndex = 23
        Me.btnRiapriPdf.TabStop = True
        Me.btnRiapriPdf.Text = "Riapri PDF"
        Me.btnRiapriPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkPrintBarcode
        '
        Me.lnkPrintBarcode.AutoSize = True
        Me.lnkPrintBarcode.BackColor = System.Drawing.Color.White
        Me.lnkPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkPrintBarcode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkPrintBarcode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkPrintBarcode.Image = Global.Former.My.Resources.Resources._barcode
        Me.lnkPrintBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkPrintBarcode.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkPrintBarcode.Location = New System.Drawing.Point(466, 0)
        Me.lnkPrintBarcode.Name = "lnkPrintBarcode"
        Me.lnkPrintBarcode.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkPrintBarcode.Size = New System.Drawing.Size(124, 27)
        Me.lnkPrintBarcode.TabIndex = 27
        Me.lnkPrintBarcode.TabStop = True
        Me.lnkPrintBarcode.Text = "Stampa Barcode"
        Me.lnkPrintBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkApriCons
        '
        Me.lnkApriCons.AutoSize = True
        Me.lnkApriCons.BackColor = System.Drawing.Color.White
        Me.lnkApriCons.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkApriCons.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkApriCons.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApriCons.Image = Global.Former.My.Resources.Resources._Consegna1
        Me.lnkApriCons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkApriCons.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApriCons.Location = New System.Drawing.Point(596, 0)
        Me.lnkApriCons.Name = "lnkApriCons"
        Me.lnkApriCons.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkApriCons.Size = New System.Drawing.Size(112, 27)
        Me.lnkApriCons.TabIndex = 28
        Me.lnkApriCons.TabStop = True
        Me.lnkApriCons.Text = "Apri Consegna"
        Me.lnkApriCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkRegPagamento
        '
        Me.lnkRegPagamento.AutoSize = True
        Me.lnkRegPagamento.BackColor = System.Drawing.Color.White
        Me.lnkRegPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkRegPagamento.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkRegPagamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRegPagamento.Image = Global.Former.My.Resources.Resources._Pagamento
        Me.lnkRegPagamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRegPagamento.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRegPagamento.Location = New System.Drawing.Point(714, 0)
        Me.lnkRegPagamento.Name = "lnkRegPagamento"
        Me.lnkRegPagamento.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkRegPagamento.Size = New System.Drawing.Size(145, 27)
        Me.lnkRegPagamento.TabIndex = 29
        Me.lnkRegPagamento.TabStop = True
        Me.lnkRegPagamento.Text = "Registra Pagamento"
        Me.lnkRegPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNotaCredito
        '
        Me.lnkNotaCredito.AutoSize = True
        Me.lnkNotaCredito.BackColor = System.Drawing.Color.White
        Me.lnkNotaCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkNotaCredito.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkNotaCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNotaCredito.Image = Global.Former.My.Resources.Resources._NotaCredito
        Me.lnkNotaCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNotaCredito.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNotaCredito.Location = New System.Drawing.Point(865, 0)
        Me.lnkNotaCredito.Name = "lnkNotaCredito"
        Me.lnkNotaCredito.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkNotaCredito.Size = New System.Drawing.Size(117, 27)
        Me.lnkNotaCredito.TabIndex = 30
        Me.lnkNotaCredito.TabStop = True
        Me.lnkNotaCredito.Text = "Nota di Credito"
        Me.lnkNotaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkNotaCredito.Visible = False
        '
        'btnAnnulla
        '
        Me.btnAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnnulla.BackColor = System.Drawing.Color.White
        Me.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnulla.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnAnnulla.Location = New System.Drawing.Point(1097, 12)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Size = New System.Drawing.Size(34, 34)
        Me.btnAnnulla.TabIndex = 26
        Me.btnAnnulla.TabStop = False
        Me.btnAnnulla.UseVisualStyleBackColor = False
        '
        'btnConferma
        '
        Me.btnConferma.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConferma.BackColor = System.Drawing.Color.White
        Me.btnConferma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConferma.Image = Global.Former.My.Resources.Resources.checkmark
        Me.btnConferma.Location = New System.Drawing.Point(1053, 12)
        Me.btnConferma.Name = "btnConferma"
        Me.btnConferma.Size = New System.Drawing.Size(34, 34)
        Me.btnConferma.TabIndex = 25
        Me.btnConferma.UseVisualStyleBackColor = False
        Me.btnConferma.Visible = False
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = "File PDF|*.pdf|File immagine|*.jpg"
        '
        'mnuOrdini
        '
        Me.mnuOrdini.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificaImportiToolStripMenuItem, Me.ToolStripSeparator1, Me.UsaNomeLavoroToolStripMenuItem})
        Me.mnuOrdini.Name = "mnuOrdini"
        Me.mnuOrdini.Size = New System.Drawing.Size(276, 54)
        '
        'ModificaImportiToolStripMenuItem
        '
        Me.ModificaImportiToolStripMenuItem.Name = "ModificaImportiToolStripMenuItem"
        Me.ModificaImportiToolStripMenuItem.Size = New System.Drawing.Size(275, 22)
        Me.ModificaImportiToolStripMenuItem.Text = "Modifica Importi"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(272, 6)
        '
        'UsaNomeLavoroToolStripMenuItem
        '
        Me.UsaNomeLavoroToolStripMenuItem.Name = "UsaNomeLavoroToolStripMenuItem"
        Me.UsaNomeLavoroToolStripMenuItem.Size = New System.Drawing.Size(275, 22)
        Me.UsaNomeLavoroToolStripMenuItem.Text = "Usa Nome Lavoro nella Riga in Fattura"
        '
        'btnOk
        '
        Me.btnOk.Image = Global.Former.My.Resources.Resources.Conferma
        Me.btnOk.Location = New System.Drawing.Point(4, 20)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.Former.My.Resources.Resources.Annulla
        Me.btnCancel.Location = New System.Drawing.Point(4, 60)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(34, 34)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.TabStop = False
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmContabilitaRicavo
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnAnnulla
        Me.ClientSize = New System.Drawing.Size(1135, 817)
        Me.Controls.Add(Me.TabRicavo)
        Me.Controls.Add(Me.grpBtn)
        Me.Name = "frmContabilitaRicavo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Contabilità"
        Me.TabRicavo.ResumeLayout(False)
        Me.tbAlarm.ResumeLayout(False)
        Me.tbAlarm.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctIntEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctIntRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlImporti.ResumeLayout(False)
        Me.pnlImporti.PerformLayout()
        CType(Me.pctSblocco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDett.ResumeLayout(False)
        Me.tbVociFat.ResumeLayout(False)
        CType(Me.DgDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPagam.ResumeLayout(False)
        Me.tpVociFat.ResumeLayout(False)
        CType(Me.dgVociFat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStatoIncasso.ResumeLayout(False)
        Me.tpStatoIncasso.PerformLayout()
        Me.tpFatturaXML.ResumeLayout(False)
        Me.grpBtn.ResumeLayout(False)
        Me.flowPanelPulsanti.ResumeLayout(False)
        Me.flowPanelPulsanti.PerformLayout()
        Me.mnuOrdini.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabRicavo As System.Windows.Forms.TabControl
    Friend WithEvents tbAlarm As System.Windows.Forms.TabPage
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents grpBtn As System.Windows.Forms.GroupBox
    Friend WithEvents btnAnnulla As System.Windows.Forms.Button
    Friend WithEvents btnConferma As System.Windows.Forms.Button
    Friend WithEvents lblCognome As System.Windows.Forms.Label
    Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtImporto As ucNumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dataOp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIva As ucNumericTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPercIva As ucNumericTextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblTipoCli As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumero As ucNumericTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblCorr2 As System.Windows.Forms.Label
    Friend WithEvents cmbCorriere As System.Windows.Forms.ComboBox
    Friend WithEvents lblCorr1 As System.Windows.Forms.Label
    Friend WithEvents lblTotale As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnStampa As ucLinkLabel
    Friend WithEvents lblCostoSped As ucNumericTextBox
    Friend WithEvents tbDett As System.Windows.Forms.TabControl
    Friend WithEvents tbVociFat As System.Windows.Forms.TabPage
    Friend WithEvents DgDoc As System.Windows.Forms.DataGridView
    Friend WithEvents Anteprima As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Ordine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prezzo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblIntestazione As System.Windows.Forms.Label
    Friend WithEvents btnDetCli As System.Windows.Forms.Button
    Friend WithEvents lnkFattRiepilog As System.Windows.Forms.LinkLabel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tpPagam As System.Windows.Forms.TabPage
    Friend WithEvents UcPagamenti As Former.ucAmministrazionePagamenti
    Friend WithEvents txtDataPrevPagam As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAlert As System.Windows.Forms.Label
    Friend WithEvents btnStampaEmail As System.Windows.Forms.LinkLabel
    Friend WithEvents btnAddOrder As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRimuovi As System.Windows.Forms.Button
    Friend WithEvents tpVociFat As System.Windows.Forms.TabPage
    Friend WithEvents dgVociFat As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pctSblocco As System.Windows.Forms.PictureBox
    Friend WithEvents pnlImporti As System.Windows.Forms.Panel
    Friend WithEvents lblTotOrdini As System.Windows.Forms.Label
    Friend WithEvents lblTotOrdini2 As System.Windows.Forms.Label
    Friend WithEvents btnRiapriPdf As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkPrintBarcode As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkApriCons As System.Windows.Forms.LinkLabel
    Friend WithEvents flowPanelPulsanti As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lnkRegPagamento As System.Windows.Forms.LinkLabel
    Friend WithEvents btnModificaImp As System.Windows.Forms.Button
    Friend WithEvents mnuOrdini As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificaImportiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UsaNomeLavoroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lnkNoIva As LinkLabel
    Friend WithEvents lblPrintCounter As Label
    Friend WithEvents pctIntEdit As PictureBox
    Friend WithEvents pctIntRefresh As PictureBox
    Friend WithEvents lnkIva4 As LinkLabel
    Friend WithEvents tpStatoIncasso As TabPage
    Friend WithEvents imlMain As ImageList
    Friend WithEvents lblStatoIncasso As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lnkSetIncassoNormale As LinkLabel
    Friend WithEvents lnkSetIncassoImpossibile As LinkLabel
    Friend WithEvents lnkSetIncassoDifficile As LinkLabel
    Friend WithEvents lnkSetIncassoProblematico As LinkLabel
    Friend WithEvents pctTipo As PictureBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents lblAzienda As Label
    Friend WithEvents tpFatturaXML As TabPage
    Friend WithEvents UcDocumentiFiscaliXMLRicavo As ucDocumentiFiscaliXMLRicavo
    Friend WithEvents imlTab As ImageList
    Friend WithEvents cmbEsclIvaNat As ComboBox
    Friend WithEvents lnkNotaCredito As LinkLabel
    Friend WithEvents cmbEsigiblitaIVA As ComboBox
    Friend WithEvents Label5 As Label
End Class
