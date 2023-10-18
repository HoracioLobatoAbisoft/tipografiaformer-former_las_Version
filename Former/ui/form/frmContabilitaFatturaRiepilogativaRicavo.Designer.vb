<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContabilitaFatturaRiepilogativaRicavo
    Inherits baseFormInternaFixed

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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContabilitaFatturaRiepilogativaRicavo))
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.lblAzienda = New System.Windows.Forms.Label()
        Me.btnDetCli = New System.Windows.Forms.Button()
        Me.pnlInt = New System.Windows.Forms.Panel()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMese = New System.Windows.Forms.ComboBox()
        Me.cmbAnnoRif = New System.Windows.Forms.ComboBox()
        Me.cmbPagam = New System.Windows.Forms.ComboBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnStampa = New System.Windows.Forms.LinkLabel()
        Me.btnStampaEmail = New System.Windows.Forms.LinkLabel()
        Me.lnkPrintBarcode = New System.Windows.Forms.LinkLabel()
        Me.lnkExportXML = New System.Windows.Forms.LinkLabel()
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.btnConferma = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabDettaglio = New System.Windows.Forms.TabControl()
        Me.tpDoc = New System.Windows.Forms.TabPage()
        Me.btnRimuovi = New System.Windows.Forms.Button()
        Me.DgLavori = New System.Windows.Forms.DataGridView()
        Me.IdRicavo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpPagam = New System.Windows.Forms.TabPage()
        Me.UcPagamenti = New Former.ucAmministrazionePagamenti()
        Me.lblDataPrevPagam = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblNumDoc = New System.Windows.Forms.Label()
        Me.txtPagamento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbEsigiblitaIVA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbEsclIvaNat = New System.Windows.Forms.ComboBox()
        Me.lnkIva4 = New System.Windows.Forms.LinkLabel()
        Me.lnkNoIva = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPercIva = New Former.ucNumericTextBox()
        Me.lblTotDocum = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTotIva = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotImp = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblIntestazione = New System.Windows.Forms.TextBox()
        Me.tpFatturaXML = New System.Windows.Forms.TabPage()
        Me.UcDocumentiFiscaliXMLRicavo = New Former.ucDocumentiFiscaliXMLRicavo()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.pnlInt.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TabDettaglio.SuspendLayout()
        Me.tpDoc.SuspendLayout()
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPagam.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.tpFatturaXML.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpFatturaXML)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ImageList = Me.imlTab
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1061, 750)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblAzienda)
        Me.tbProd.Controls.Add(Me.btnDetCli)
        Me.tbProd.Controls.Add(Me.pnlInt)
        Me.tbProd.Controls.Add(Me.cmbPagam)
        Me.tbProd.Controls.Add(Me.FlowLayoutPanel1)
        Me.tbProd.Controls.Add(Me.btnAnnulla)
        Me.tbProd.Controls.Add(Me.cmbCliente)
        Me.tbProd.Controls.Add(Me.btnConferma)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.TabDettaglio)
        Me.tbProd.Controls.Add(Me.lblDataPrevPagam)
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.txtPagamento)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Controls.Add(Me.GroupBox2)
        Me.tbProd.Controls.Add(Me.lblIntestazione)
        Me.tbProd.ImageKey = "ico_V_R.png"
        Me.tbProd.Location = New System.Drawing.Point(4, 31)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1053, 715)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Fattura Riepilogativa"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lblAzienda
        '
        Me.lblAzienda.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblAzienda.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAzienda.ForeColor = System.Drawing.Color.White
        Me.lblAzienda.Location = New System.Drawing.Point(927, 6)
        Me.lblAzienda.Name = "lblAzienda"
        Me.lblAzienda.Size = New System.Drawing.Size(111, 34)
        Me.lblAzienda.TabIndex = 133
        Me.lblAzienda.Text = "-"
        Me.lblAzienda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDetCli
        '
        Me.btnDetCli.Location = New System.Drawing.Point(1008, 95)
        Me.btnDetCli.Name = "btnDetCli"
        Me.btnDetCli.Size = New System.Drawing.Size(24, 23)
        Me.btnDetCli.TabIndex = 1
        Me.btnDetCli.Text = "..."
        Me.btnDetCli.UseVisualStyleBackColor = True
        '
        'pnlInt
        '
        Me.pnlInt.Controls.Add(Me.Label36)
        Me.pnlInt.Controls.Add(Me.Label2)
        Me.pnlInt.Controls.Add(Me.cmbMese)
        Me.pnlInt.Controls.Add(Me.cmbAnnoRif)
        Me.pnlInt.Location = New System.Drawing.Point(53, 125)
        Me.pnlInt.Name = "pnlInt"
        Me.pnlInt.Size = New System.Drawing.Size(950, 28)
        Me.pnlInt.TabIndex = 119
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label36.Location = New System.Drawing.Point(3, 6)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(101, 15)
        Me.Label36.TabIndex = 112
        Me.Label36.Text = "Anno riferimento:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(249, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 15)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Mese riferimento:"
        '
        'cmbMese
        '
        Me.cmbMese.DisplayMember = "AnnoRif"
        Me.cmbMese.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMese.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbMese.FormattingEnabled = True
        Me.cmbMese.Location = New System.Drawing.Point(355, 3)
        Me.cmbMese.Name = "cmbMese"
        Me.cmbMese.Size = New System.Drawing.Size(265, 23)
        Me.cmbMese.TabIndex = 1
        '
        'cmbAnnoRif
        '
        Me.cmbAnnoRif.DisplayMember = "AnnoRif"
        Me.cmbAnnoRif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnnoRif.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbAnnoRif.FormattingEnabled = True
        Me.cmbAnnoRif.Location = New System.Drawing.Point(116, 3)
        Me.cmbAnnoRif.Name = "cmbAnnoRif"
        Me.cmbAnnoRif.Size = New System.Drawing.Size(121, 23)
        Me.cmbAnnoRif.TabIndex = 0
        '
        'cmbPagam
        '
        Me.cmbPagam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPagam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPagam.BackColor = System.Drawing.Color.White
        Me.cmbPagam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPagam.ForeColor = System.Drawing.Color.Black
        Me.cmbPagam.FormattingEnabled = True
        Me.cmbPagam.Location = New System.Drawing.Point(169, 159)
        Me.cmbPagam.Name = "cmbPagam"
        Me.cmbPagam.Size = New System.Drawing.Size(504, 21)
        Me.cmbPagam.TabIndex = 2
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnStampa)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnStampaEmail)
        Me.FlowLayoutPanel1.Controls.Add(Me.lnkPrintBarcode)
        Me.FlowLayoutPanel1.Controls.Add(Me.lnkExportXML)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(53, 680)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(803, 36)
        Me.FlowLayoutPanel1.TabIndex = 131
        '
        'btnStampa
        '
        Me.btnStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStampa.BackColor = System.Drawing.Color.White
        Me.btnStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStampa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStampa.Image = Global.Former.My.Resources.Resources.print
        Me.btnStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStampa.Location = New System.Drawing.Point(3, 0)
        Me.btnStampa.Name = "btnStampa"
        Me.btnStampa.Size = New System.Drawing.Size(79, 34)
        Me.btnStampa.TabIndex = 128
        Me.btnStampa.TabStop = True
        Me.btnStampa.Text = "Stampa"
        Me.btnStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStampa.Visible = False
        '
        'btnStampaEmail
        '
        Me.btnStampaEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStampaEmail.BackColor = System.Drawing.Color.White
        Me.btnStampaEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStampaEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStampaEmail.Image = Global.Former.My.Resources.Resources._pdf
        Me.btnStampaEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampaEmail.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnStampaEmail.Location = New System.Drawing.Point(88, 0)
        Me.btnStampaEmail.Name = "btnStampaEmail"
        Me.btnStampaEmail.Size = New System.Drawing.Size(104, 34)
        Me.btnStampaEmail.TabIndex = 126
        Me.btnStampaEmail.TabStop = True
        Me.btnStampaEmail.Text = "Stampa PDF"
        Me.btnStampaEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkPrintBarcode
        '
        Me.lnkPrintBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkPrintBarcode.BackColor = System.Drawing.Color.White
        Me.lnkPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkPrintBarcode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkPrintBarcode.Image = Global.Former.My.Resources.Resources._barcode
        Me.lnkPrintBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkPrintBarcode.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkPrintBarcode.Location = New System.Drawing.Point(198, 0)
        Me.lnkPrintBarcode.Name = "lnkPrintBarcode"
        Me.lnkPrintBarcode.Size = New System.Drawing.Size(123, 34)
        Me.lnkPrintBarcode.TabIndex = 127
        Me.lnkPrintBarcode.TabStop = True
        Me.lnkPrintBarcode.Text = "Stampa Barcode"
        Me.lnkPrintBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkExportXML
        '
        Me.lnkExportXML.BackColor = System.Drawing.Color.White
        Me.lnkExportXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkExportXML.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkExportXML.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkExportXML.Image = Global.Former.My.Resources.Resources._xml
        Me.lnkExportXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkExportXML.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkExportXML.Location = New System.Drawing.Point(327, 0)
        Me.lnkExportXML.Name = "lnkExportXML"
        Me.lnkExportXML.Size = New System.Drawing.Size(96, 34)
        Me.lnkExportXML.TabIndex = 129
        Me.lnkExportXML.TabStop = True
        Me.lnkExportXML.Text = "Export XML"
        Me.lnkExportXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkExportXML.Visible = False
        '
        'btnAnnulla
        '
        Me.btnAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnnulla.BackColor = System.Drawing.Color.White
        Me.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnulla.ForeColor = System.Drawing.Color.White
        Me.btnAnnulla.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnAnnulla.Location = New System.Drawing.Point(1008, 680)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Size = New System.Drawing.Size(34, 34)
        Me.btnAnnulla.TabIndex = 4
        Me.btnAnnulla.TabStop = False
        Me.btnAnnulla.UseVisualStyleBackColor = False
        '
        'cmbCliente
        '
        Me.cmbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.DisplayMember = "AnnoRif"
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(169, 96)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(834, 23)
        Me.cmbCliente.TabIndex = 0
        '
        'btnConferma
        '
        Me.btnConferma.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConferma.BackColor = System.Drawing.Color.White
        Me.btnConferma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConferma.ForeColor = System.Drawing.Color.White
        Me.btnConferma.Image = Global.Former.My.Resources.Resources.checkmark
        Me.btnConferma.Location = New System.Drawing.Point(964, 680)
        Me.btnConferma.Name = "btnConferma"
        Me.btnConferma.Size = New System.Drawing.Size(34, 34)
        Me.btnConferma.TabIndex = 3
        Me.btnConferma.UseVisualStyleBackColor = False
        Me.btnConferma.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(50, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "DESTINATARIO"
        '
        'TabDettaglio
        '
        Me.TabDettaglio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabDettaglio.Controls.Add(Me.tpDoc)
        Me.TabDettaglio.Controls.Add(Me.tpPagam)
        Me.TabDettaglio.Location = New System.Drawing.Point(53, 274)
        Me.TabDettaglio.Name = "TabDettaglio"
        Me.TabDettaglio.SelectedIndex = 0
        Me.TabDettaglio.Size = New System.Drawing.Size(989, 392)
        Me.TabDettaglio.TabIndex = 125
        '
        'tpDoc
        '
        Me.tpDoc.Controls.Add(Me.btnRimuovi)
        Me.tpDoc.Controls.Add(Me.DgLavori)
        Me.tpDoc.Location = New System.Drawing.Point(4, 22)
        Me.tpDoc.Name = "tpDoc"
        Me.tpDoc.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDoc.Size = New System.Drawing.Size(981, 366)
        Me.tpDoc.TabIndex = 0
        Me.tpDoc.Text = "Documenti"
        Me.tpDoc.UseVisualStyleBackColor = True
        '
        'btnRimuovi
        '
        Me.btnRimuovi.BackColor = System.Drawing.Color.White
        Me.btnRimuovi.Image = Global.Former.My.Resources.Resources._Rimuovi
        Me.btnRimuovi.Location = New System.Drawing.Point(6, 6)
        Me.btnRimuovi.Name = "btnRimuovi"
        Me.btnRimuovi.Size = New System.Drawing.Size(35, 35)
        Me.btnRimuovi.TabIndex = 0
        Me.btnRimuovi.UseVisualStyleBackColor = False
        '
        'DgLavori
        '
        Me.DgLavori.AllowUserToAddRows = False
        Me.DgLavori.AllowUserToDeleteRows = False
        Me.DgLavori.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLavori.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLavori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgLavori.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgLavori.BackgroundColor = System.Drawing.Color.White
        Me.DgLavori.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLavori.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavori.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLavori.ColumnHeadersHeight = 20
        Me.DgLavori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgLavori.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdRicavo, Me.Data, Me.Numero, Me.Descr, Me.Importo})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgLavori.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavori.EnableHeadersVisualStyles = False
        Me.DgLavori.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavori.Location = New System.Drawing.Point(47, 6)
        Me.DgLavori.MultiSelect = False
        Me.DgLavori.Name = "DgLavori"
        Me.DgLavori.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgLavori.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgLavori.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.DgLavori.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.Height = 150
        Me.DgLavori.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLavori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavori.Size = New System.Drawing.Size(928, 354)
        Me.DgLavori.TabIndex = 79
        Me.DgLavori.TabStop = False
        '
        'IdRicavo
        '
        Me.IdRicavo.HeaderText = "IdRicavo"
        Me.IdRicavo.Name = "IdRicavo"
        Me.IdRicavo.ReadOnly = True
        Me.IdRicavo.Visible = False
        '
        'Data
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Data.DefaultCellStyle = DataGridViewCellStyle3
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        '
        'Numero
        '
        Me.Numero.HeaderText = "Numero"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        '
        'Descr
        '
        Me.Descr.HeaderText = "Descrizione"
        Me.Descr.Name = "Descr"
        Me.Descr.ReadOnly = True
        '
        'Importo
        '
        Me.Importo.HeaderText = "Importo"
        Me.Importo.Name = "Importo"
        Me.Importo.ReadOnly = True
        '
        'tpPagam
        '
        Me.tpPagam.Controls.Add(Me.UcPagamenti)
        Me.tpPagam.Location = New System.Drawing.Point(4, 22)
        Me.tpPagam.Name = "tpPagam"
        Me.tpPagam.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPagam.Size = New System.Drawing.Size(981, 366)
        Me.tpPagam.TabIndex = 1
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
        Me.UcPagamenti.Size = New System.Drawing.Size(975, 360)
        Me.UcPagamenti.TabIndex = 1
        '
        'lblDataPrevPagam
        '
        Me.lblDataPrevPagam.Location = New System.Drawing.Point(679, 158)
        Me.lblDataPrevPagam.Name = "lblDataPrevPagam"
        Me.lblDataPrevPagam.Size = New System.Drawing.Size(338, 21)
        Me.lblDataPrevPagam.TabIndex = 121
        Me.lblDataPrevPagam.Text = "-"
        Me.lblDataPrevPagam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.lblNumDoc)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(985, 43)
        Me.GroupBox1.TabIndex = 110
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Numero"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(181, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Data"
        '
        'lblDate
        '
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDate.Location = New System.Drawing.Point(220, 17)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(120, 15)
        Me.lblDate.TabIndex = 109
        Me.lblDate.Text = "0"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumDoc
        '
        Me.lblNumDoc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumDoc.Location = New System.Drawing.Point(64, 17)
        Me.lblNumDoc.Name = "lblNumDoc"
        Me.lblNumDoc.Size = New System.Drawing.Size(111, 15)
        Me.lblNumDoc.TabIndex = 108
        Me.lblNumDoc.Text = "0"
        Me.lblNumDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPagamento
        '
        Me.txtPagamento.Location = New System.Drawing.Point(6, 788)
        Me.txtPagamento.Name = "txtPagamento"
        Me.txtPagamento.Size = New System.Drawing.Size(70, 20)
        Me.txtPagamento.TabIndex = 104
        Me.txtPagamento.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(50, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 15)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Pagamento"
        '
        'pctTipo
        '
        Me.pctTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._DocumentoFiscale
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.White
        Me.lblTipo.Location = New System.Drawing.Point(41, 6)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(880, 34)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Fattura Riepilogativa"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbEsigiblitaIVA)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cmbEsclIvaNat)
        Me.GroupBox2.Controls.Add(Me.lnkIva4)
        Me.GroupBox2.Controls.Add(Me.lnkNoIva)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtPercIva)
        Me.GroupBox2.Controls.Add(Me.lblTotDocum)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lblTotIva)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lblTotImp)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(485, 182)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(553, 86)
        Me.GroupBox2.TabIndex = 111
        Me.GroupBox2.TabStop = False
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
        Me.cmbEsigiblitaIVA.Location = New System.Drawing.Point(402, 59)
        Me.cmbEsigiblitaIVA.Name = "cmbEsigiblitaIVA"
        Me.cmbEsigiblitaIVA.Size = New System.Drawing.Size(145, 23)
        Me.cmbEsigiblitaIVA.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(319, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 143
        Me.Label8.Text = "Esigibilità IVA"
        '
        'cmbEsclIvaNat
        '
        Me.cmbEsclIvaNat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsclIvaNat.Enabled = False
        Me.cmbEsclIvaNat.FormattingEnabled = True
        Me.cmbEsclIvaNat.Location = New System.Drawing.Point(402, 32)
        Me.cmbEsclIvaNat.Name = "cmbEsclIvaNat"
        Me.cmbEsclIvaNat.Size = New System.Drawing.Size(145, 21)
        Me.cmbEsclIvaNat.TabIndex = 0
        '
        'lnkIva4
        '
        Me.lnkIva4.AutoSize = True
        Me.lnkIva4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkIva4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkIva4.Location = New System.Drawing.Point(292, 35)
        Me.lnkIva4.Name = "lnkIva4"
        Me.lnkIva4.Size = New System.Drawing.Size(48, 15)
        Me.lnkIva4.TabIndex = 117
        Me.lnkIva4.TabStop = True
        Me.lnkIva4.Text = "IVA 4%?"
        '
        'lnkNoIva
        '
        Me.lnkNoIva.AutoSize = True
        Me.lnkNoIva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNoIva.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNoIva.Location = New System.Drawing.Point(346, 35)
        Me.lnkNoIva.Name = "lnkNoIva"
        Me.lnkNoIva.Size = New System.Drawing.Size(50, 15)
        Me.lnkNoIva.TabIndex = 116
        Me.lnkNoIva.TabStop = True
        Me.lnkNoIva.Text = "NO IVA?"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(209, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "% IVA *"
        '
        'txtPercIva
        '
        Me.txtPercIva.My_AccettaNegativi = False
        Me.txtPercIva.My_DefaultValue = 0
        Me.txtPercIva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPercIva.Location = New System.Drawing.Point(258, 32)
        Me.txtPercIva.MaxLength = 2
        Me.txtPercIva.My_MaxValue = 99.0!
        Me.txtPercIva.My_MinValue = 0!
        Me.txtPercIva.Name = "txtPercIva"
        Me.txtPercIva.My_AllowOnlyInteger = True
        Me.txtPercIva.ReadOnly = True
        Me.txtPercIva.My_ReplaceWithDefaultValue = True
        Me.txtPercIva.Size = New System.Drawing.Size(28, 23)
        Me.txtPercIva.TabIndex = 114
        Me.txtPercIva.Text = "20"
        Me.txtPercIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotDocum
        '
        Me.lblTotDocum.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotDocum.Location = New System.Drawing.Point(103, 59)
        Me.lblTotDocum.Name = "lblTotDocum"
        Me.lblTotDocum.Size = New System.Drawing.Size(100, 15)
        Me.lblTotDocum.TabIndex = 113
        Me.lblTotDocum.Text = "0"
        Me.lblTotDocum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(6, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 15)
        Me.Label14.TabIndex = 112
        Me.Label14.Text = "Totale"
        '
        'lblTotIva
        '
        Me.lblTotIva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotIva.Location = New System.Drawing.Point(103, 35)
        Me.lblTotIva.Name = "lblTotIva"
        Me.lblTotIva.Size = New System.Drawing.Size(100, 15)
        Me.lblTotIva.TabIndex = 111
        Me.lblTotIva.Text = "0"
        Me.lblTotIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(6, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 15)
        Me.Label12.TabIndex = 110
        Me.Label12.Text = "IVA"
        '
        'lblTotImp
        '
        Me.lblTotImp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotImp.Location = New System.Drawing.Point(103, 17)
        Me.lblTotImp.Name = "lblTotImp"
        Me.lblTotImp.Size = New System.Drawing.Size(100, 15)
        Me.lblTotImp.TabIndex = 109
        Me.lblTotImp.Text = "0"
        Me.lblTotImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(6, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 15)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "Totale Netto"
        '
        'lblIntestazione
        '
        Me.lblIntestazione.Location = New System.Drawing.Point(53, 190)
        Me.lblIntestazione.Multiline = True
        Me.lblIntestazione.Name = "lblIntestazione"
        Me.lblIntestazione.ReadOnly = True
        Me.lblIntestazione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lblIntestazione.Size = New System.Drawing.Size(426, 78)
        Me.lblIntestazione.TabIndex = 124
        Me.lblIntestazione.Text = "Intestazione"
        '
        'tpFatturaXML
        '
        Me.tpFatturaXML.Controls.Add(Me.UcDocumentiFiscaliXMLRicavo)
        Me.tpFatturaXML.ImageKey = "_xml.png"
        Me.tpFatturaXML.Location = New System.Drawing.Point(4, 31)
        Me.tpFatturaXML.Name = "tpFatturaXML"
        Me.tpFatturaXML.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFatturaXML.Size = New System.Drawing.Size(1053, 715)
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
        Me.UcDocumentiFiscaliXMLRicavo.Size = New System.Drawing.Size(1047, 709)
        Me.UcDocumentiFiscaliXMLRicavo.TabIndex = 1
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
        'frmContabilitaFatturaRiepilogativaRicavo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnAnnulla
        Me.ClientSize = New System.Drawing.Size(1061, 750)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "frmContabilitaFatturaRiepilogativaRicavo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Emissione documenti"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.pnlInt.ResumeLayout(False)
        Me.pnlInt.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.TabDettaglio.ResumeLayout(False)
        Me.tpDoc.ResumeLayout(False)
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPagam.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tpFatturaXML.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents DgLavori As System.Windows.Forms.DataGridView
    Friend WithEvents btnRimuovi As System.Windows.Forms.Button
    Friend WithEvents txtPagamento As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblNumDoc As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotDocum As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTotIva As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTotImp As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAnnoRif As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMese As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents pnlInt As System.Windows.Forms.Panel
    Friend WithEvents btnDetCli As System.Windows.Forms.Button
    Friend WithEvents lblDataPrevPagam As System.Windows.Forms.Label
    Friend WithEvents lblIntestazione As System.Windows.Forms.TextBox
    Friend WithEvents TabDettaglio As System.Windows.Forms.TabControl
    Friend WithEvents tpDoc As System.Windows.Forms.TabPage
    Friend WithEvents tpPagam As System.Windows.Forms.TabPage
    Friend WithEvents UcPagamenti As Former.ucAmministrazionePagamenti
    Friend WithEvents lnkPrintBarcode As System.Windows.Forms.LinkLabel
    Friend WithEvents btnStampaEmail As System.Windows.Forms.LinkLabel
    Friend WithEvents btnStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents btnAnnulla As System.Windows.Forms.Button
    Friend WithEvents btnConferma As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmbPagam As ComboBox
    Friend WithEvents lblAzienda As Label
    Friend WithEvents lnkExportXML As LinkLabel
    Friend WithEvents tpFatturaXML As TabPage
    Friend WithEvents imlTab As ImageList
    Friend WithEvents UcDocumentiFiscaliXMLRicavo As ucDocumentiFiscaliXMLRicavo
    Friend WithEvents cmbEsclIvaNat As ComboBox
    Friend WithEvents lnkIva4 As LinkLabel
    Friend WithEvents lnkNoIva As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPercIva As ucNumericTextBox
    Friend WithEvents IdRicavo As DataGridViewTextBoxColumn
    Friend WithEvents Data As DataGridViewTextBoxColumn
    Friend WithEvents Numero As DataGridViewTextBoxColumn
    Friend WithEvents Descr As DataGridViewTextBoxColumn
    Friend WithEvents Importo As DataGridViewTextBoxColumn
    Friend WithEvents cmbEsigiblitaIVA As ComboBox
    Friend WithEvents Label8 As Label
End Class
