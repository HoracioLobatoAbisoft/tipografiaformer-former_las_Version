<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmContabilitaFatturaRiepilogativaCosto
    Inherits baseFormInternaRedim

    'Form overrides dispose to clean up the component list.
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
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContabilitaFatturaRiepilogativaCosto))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.pctSblocco = New System.Windows.Forms.PictureBox()
        Me.lblAzienda = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnMainFile = New System.Windows.Forms.Button()
        Me.txtMainFile = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtAddebitiVari = New Former.ucNumericTextBox()
        Me.TabDettaglio = New System.Windows.Forms.TabControl()
        Me.tpDoc = New System.Windows.Forms.TabPage()
        Me.dgDocDDT = New Telerik.WinControls.UI.RadGridView()
        Me.UcDocumentiFiscaliEditRow = New Former.ucDocumentiFiscaliEditRow()
        Me.tpRighe = New System.Windows.Forms.TabPage()
        Me.dgVociFat = New System.Windows.Forms.DataGridView()
        Me.Codice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrezzoUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Totale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpPagam = New System.Windows.Forms.TabPage()
        Me.UcPagamenti = New Former.ucAmministrazionePagamenti()
        Me.tbImmagini = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lnkApri4 = New System.Windows.Forms.LinkLabel()
        Me.btnSfoglia4 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFile4 = New System.Windows.Forms.TextBox()
        Me.lnkApri3 = New System.Windows.Forms.LinkLabel()
        Me.btnSfoglia3 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFile3 = New System.Windows.Forms.TextBox()
        Me.lnkApri2 = New System.Windows.Forms.LinkLabel()
        Me.btnSfoglia2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFile2 = New System.Windows.Forms.TextBox()
        Me.lnkApri1 = New System.Windows.Forms.LinkLabel()
        Me.btnSfoglia1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFile1 = New System.Windows.Forms.TextBox()
        Me.lnkApri = New System.Windows.Forms.LinkLabel()
        Me.btnSfoglia = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDescrizione = New System.Windows.Forms.TextBox()
        Me.txtSpeseIncasso = New Former.ucNumericTextBox()
        Me.lblCognome = New System.Windows.Forms.Label()
        Me.lblTotNonCongr = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotaleDoc = New Former.ucNumericTextBox()
        Me.dataOp = New System.Windows.Forms.DateTimePicker()
        Me.lblCorr2 = New System.Windows.Forms.Label()
        Me.lblTipoCli = New System.Windows.Forms.Label()
        Me.txtCostoSped = New Former.ucNumericTextBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnDetCli = New System.Windows.Forms.Button()
        Me.txtNumero = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtImporto = New Former.ucNumericTextBox()
        Me.txtDataPrevPagam = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPercIva = New Former.ucNumericTextBox()
        Me.txtIva = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotale = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.UcDocumentiFiscaliXMLCosto = New Former.ucDocumentiFiscaliXMLCosto()
        Me.tpPDF = New System.Windows.Forms.TabPage()
        Me.RadPreview = New Telerik.WinControls.UI.RadPdfViewer()
        Me.RadPdfViewerNavigator = New Telerik.WinControls.UI.RadPdfViewerNavigator()
        Me.tpAmmortamento = New System.Windows.Forms.TabPage()
        Me.UcContabCostoAmmortamento = New Former.ucContabCostoAmmortamento()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        CType(Me.pctSblocco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDettaglio.SuspendLayout()
        Me.tpDoc.SuspendLayout()
        CType(Me.dgDocDDT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDocDDT.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dgDocDDT.SuspendLayout()
        Me.tpRighe.SuspendLayout()
        CType(Me.dgVociFat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPagam.SuspendLayout()
        Me.tbImmagini.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpPDF.SuspendLayout()
        CType(Me.RadPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPdfViewerNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAmmortamento.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 769)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1209, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1125, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(1046, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(73, 32)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpPDF)
        Me.TabMain.Controls.Add(Me.tpAmmortamento)
        Me.TabMain.ImageList = Me.imlTab
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1209, 769)
        Me.TabMain.TabIndex = 0
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.SplitContainerMain)
        Me.tbProd.ImageKey = "ico_A_R.png"
        Me.tbProd.Location = New System.Drawing.Point(4, 31)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1201, 734)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Fattura Riepilogativa"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.pctSblocco)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.lblAzienda)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.pctTipo)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.lblTipo)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.txtAddebitiVari)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.TabDettaglio)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.txtDescrizione)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.txtSpeseIncasso)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.lblCognome)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.lblTotNonCongr)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.txtTotaleDoc)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.dataOp)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.lblCorr2)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.lblTipoCli)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.txtCostoSped)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.cmbCliente)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.btnDetCli)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.txtNumero)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.txtImporto)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.txtDataPrevPagam)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.txtPercIva)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.txtIva)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.lblTotale)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.Label15)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.Controls.Add(Me.UcDocumentiFiscaliXMLCosto)
        Me.SplitContainerMain.Size = New System.Drawing.Size(1195, 728)
        Me.SplitContainerMain.SplitterDistance = 621
        Me.SplitContainerMain.TabIndex = 156
        '
        'pctSblocco
        '
        Me.pctSblocco.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctSblocco.Image = Global.Former.My.Resources.Resources._LucchettoAperto
        Me.pctSblocco.Location = New System.Drawing.Point(367, 8)
        Me.pctSblocco.Name = "pctSblocco"
        Me.pctSblocco.Size = New System.Drawing.Size(26, 26)
        Me.pctSblocco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctSblocco.TabIndex = 158
        Me.pctSblocco.TabStop = False
        Me.pctSblocco.Visible = False
        '
        'lblAzienda
        '
        Me.lblAzienda.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblAzienda.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAzienda.ForeColor = System.Drawing.Color.White
        Me.lblAzienda.Location = New System.Drawing.Point(500, 3)
        Me.lblAzienda.Name = "lblAzienda"
        Me.lblAzienda.Size = New System.Drawing.Size(111, 34)
        Me.lblAzienda.TabIndex = 157
        Me.lblAzienda.Text = "-"
        Me.lblAzienda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnMainFile)
        Me.GroupBox2.Controls.Add(Me.txtMainFile)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(50, 309)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(561, 60)
        Me.GroupBox2.TabIndex = 156
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documento PDF allegato principale"
        '
        'btnMainFile
        '
        Me.btnMainFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMainFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMainFile.Location = New System.Drawing.Point(527, 22)
        Me.btnMainFile.Name = "btnMainFile"
        Me.btnMainFile.Size = New System.Drawing.Size(27, 23)
        Me.btnMainFile.TabIndex = 130
        Me.btnMainFile.Text = "..."
        Me.btnMainFile.UseVisualStyleBackColor = True
        '
        'txtMainFile
        '
        Me.txtMainFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMainFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMainFile.Location = New System.Drawing.Point(53, 23)
        Me.txtMainFile.Name = "txtMainFile"
        Me.txtMainFile.ReadOnly = True
        Me.txtMainFile.Size = New System.Drawing.Size(468, 23)
        Me.txtMainFile.TabIndex = 129
        Me.txtMainFile.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._pdf1
        Me.PictureBox1.Location = New System.Drawing.Point(10, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 128
        Me.PictureBox1.TabStop = False
        '
        'pctTipo
        '
        Me.pctTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._DocumentoFiscale
        Me.pctTipo.Location = New System.Drawing.Point(3, 3)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 127
        Me.pctTipo.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(57, 225)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 15)
        Me.Label14.TabIndex = 155
        Me.Label14.Text = "Addebiti vari"
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.White
        Me.lblTipo.Location = New System.Drawing.Point(38, 3)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(323, 34)
        Me.lblTipo.TabIndex = 126
        Me.lblTipo.Text = "Fattura Riepilogativa"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddebitiVari
        '
        Me.txtAddebitiVari.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAddebitiVari.Location = New System.Drawing.Point(161, 222)
        Me.txtAddebitiVari.MaxLength = 5
        Me.txtAddebitiVari.My_AccettaNegativi = False
        Me.txtAddebitiVari.My_AllowOnlyInteger = False
        Me.txtAddebitiVari.My_DefaultValue = 0
        Me.txtAddebitiVari.My_MaxValue = 1000.0!
        Me.txtAddebitiVari.My_MinValue = 0!
        Me.txtAddebitiVari.My_ReplaceWithDefaultValue = True
        Me.txtAddebitiVari.Name = "txtAddebitiVari"
        Me.txtAddebitiVari.Size = New System.Drawing.Size(200, 23)
        Me.txtAddebitiVari.TabIndex = 8
        Me.txtAddebitiVari.Text = "0"
        Me.txtAddebitiVari.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabDettaglio
        '
        Me.TabDettaglio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabDettaglio.Controls.Add(Me.tpDoc)
        Me.TabDettaglio.Controls.Add(Me.tpRighe)
        Me.TabDettaglio.Controls.Add(Me.tpPagam)
        Me.TabDettaglio.Controls.Add(Me.tbImmagini)
        Me.TabDettaglio.Location = New System.Drawing.Point(50, 375)
        Me.TabDettaglio.Name = "TabDettaglio"
        Me.TabDettaglio.SelectedIndex = 0
        Me.TabDettaglio.Size = New System.Drawing.Size(565, 350)
        Me.TabDettaglio.TabIndex = 128
        '
        'tpDoc
        '
        Me.tpDoc.Controls.Add(Me.dgDocDDT)
        Me.tpDoc.Location = New System.Drawing.Point(4, 22)
        Me.tpDoc.Name = "tpDoc"
        Me.tpDoc.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDoc.Size = New System.Drawing.Size(557, 324)
        Me.tpDoc.TabIndex = 0
        Me.tpDoc.Text = "Documenti"
        Me.tpDoc.UseVisualStyleBackColor = True
        '
        'dgDocDDT
        '
        Me.dgDocDDT.AutoScroll = True
        Me.dgDocDDT.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.dgDocDDT.Controls.Add(Me.UcDocumentiFiscaliEditRow)
        Me.dgDocDDT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDocDDT.EnableGestures = False
        Me.dgDocDDT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgDocDDT.Location = New System.Drawing.Point(3, 3)
        '
        '
        '
        Me.dgDocDDT.MasterTemplate.AllowAddNewRow = False
        Me.dgDocDDT.MasterTemplate.AllowCellContextMenu = False
        Me.dgDocDDT.MasterTemplate.AllowColumnChooser = False
        Me.dgDocDDT.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.dgDocDDT.MasterTemplate.AllowDeleteRow = False
        Me.dgDocDDT.MasterTemplate.AllowDragToGroup = False
        Me.dgDocDDT.MasterTemplate.AllowEditRow = False
        Me.dgDocDDT.MasterTemplate.AllowRowHeaderContextMenu = False
        Me.dgDocDDT.MasterTemplate.AllowRowResize = False
        Me.dgDocDDT.MasterTemplate.AllowSearchRow = True
        Me.dgDocDDT.MasterTemplate.AutoGenerateColumns = False
        GridViewCheckBoxColumn1.EnableHeaderCheckBox = True
        GridViewCheckBoxColumn1.HeaderCheckBoxAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewCheckBoxColumn1.HeaderText = ""
        GridViewCheckBoxColumn1.MaxWidth = 30
        GridViewCheckBoxColumn1.MinWidth = 30
        GridViewCheckBoxColumn1.Name = "column1"
        GridViewCheckBoxColumn1.Width = 30
        GridViewTextBoxColumn1.FieldName = "AziendaStr"
        GridViewTextBoxColumn1.HeaderText = "Azienda"
        GridViewTextBoxColumn1.MaxWidth = 90
        GridViewTextBoxColumn1.MinWidth = 90
        GridViewTextBoxColumn1.Name = "Azienda"
        GridViewTextBoxColumn1.Width = 90
        GridViewTextBoxColumn2.FieldName = "DataCosto"
        GridViewTextBoxColumn2.FormatInfo = New System.Globalization.CultureInfo("it-IT")
        GridViewTextBoxColumn2.FormatString = "{0: dd/MM/yyyy}"
        GridViewTextBoxColumn2.HeaderText = "Data"
        GridViewTextBoxColumn2.MinWidth = 100
        GridViewTextBoxColumn2.Name = "Data"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn2.Width = 100
        GridViewTextBoxColumn3.FieldName = "Numero"
        GridViewTextBoxColumn3.HeaderText = "Numero"
        GridViewTextBoxColumn3.Name = "Numero"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 80
        GridViewTextBoxColumn4.FieldName = "TipoDocStr"
        GridViewTextBoxColumn4.HeaderText = "Tipo"
        GridViewTextBoxColumn4.MinWidth = 130
        GridViewTextBoxColumn4.Name = "Tipo"
        GridViewTextBoxColumn4.Width = 130
        GridViewTextBoxColumn5.FieldName = "Descrizione"
        GridViewTextBoxColumn5.HeaderText = "Descrizione"
        GridViewTextBoxColumn5.Name = "Descrizione"
        GridViewTextBoxColumn5.Width = 200
        Me.dgDocDDT.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5})
        Me.dgDocDDT.MasterTemplate.EnableAlternatingRowColor = True
        Me.dgDocDDT.MasterTemplate.EnableGrouping = False
        Me.dgDocDDT.MasterTemplate.MultiSelect = True
        Me.dgDocDDT.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgDocDDT.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgDocDDT.Name = "dgDocDDT"
        Me.dgDocDDT.ReadOnly = True
        Me.dgDocDDT.ShowGroupPanel = False
        Me.dgDocDDT.ShowGroupPanelScrollbars = False
        Me.dgDocDDT.ShowNoDataText = False
        Me.dgDocDDT.Size = New System.Drawing.Size(551, 318)
        Me.dgDocDDT.TabIndex = 80
        Me.dgDocDDT.ThemeName = "VisualStudio2012Light"
        '
        'UcDocumentiFiscaliEditRow
        '
        Me.UcDocumentiFiscaliEditRow.BackColor = System.Drawing.Color.White
        Me.UcDocumentiFiscaliEditRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcDocumentiFiscaliEditRow.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcDocumentiFiscaliEditRow.Location = New System.Drawing.Point(3, 131)
        Me.UcDocumentiFiscaliEditRow.Name = "UcDocumentiFiscaliEditRow"
        Me.UcDocumentiFiscaliEditRow.Size = New System.Drawing.Size(172, 184)
        Me.UcDocumentiFiscaliEditRow.TabIndex = 2
        Me.UcDocumentiFiscaliEditRow.Visible = False
        '
        'tpRighe
        '
        Me.tpRighe.Controls.Add(Me.dgVociFat)
        Me.tpRighe.Location = New System.Drawing.Point(4, 22)
        Me.tpRighe.Name = "tpRighe"
        Me.tpRighe.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRighe.Size = New System.Drawing.Size(557, 324)
        Me.tpRighe.TabIndex = 4
        Me.tpRighe.Text = "Righe Fattura"
        Me.tpRighe.UseVisualStyleBackColor = True
        '
        'dgVociFat
        '
        Me.dgVociFat.AllowUserToAddRows = False
        Me.dgVociFat.AllowUserToDeleteRows = False
        Me.dgVociFat.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgVociFat.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgVociFat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgVociFat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgVociFat.BackgroundColor = System.Drawing.Color.White
        Me.dgVociFat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgVociFat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVociFat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgVociFat.ColumnHeadersHeight = 20
        Me.dgVociFat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgVociFat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codice, Me.Descrizione, Me.PrezzoUnit, Me.Qta, Me.Totale})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgVociFat.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgVociFat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgVociFat.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgVociFat.EnableHeadersVisualStyles = False
        Me.dgVociFat.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgVociFat.Location = New System.Drawing.Point(3, 3)
        Me.dgVociFat.MultiSelect = False
        Me.dgVociFat.Name = "dgVociFat"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgVociFat.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgVociFat.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.dgVociFat.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgVociFat.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgVociFat.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgVociFat.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgVociFat.RowTemplate.Height = 150
        Me.dgVociFat.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVociFat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgVociFat.Size = New System.Drawing.Size(551, 318)
        Me.dgVociFat.TabIndex = 83
        Me.dgVociFat.TabStop = False
        '
        'Codice
        '
        Me.Codice.DataPropertyName = "Codice"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Codice.DefaultCellStyle = DataGridViewCellStyle3
        Me.Codice.HeaderText = "Codice"
        Me.Codice.MinimumWidth = 100
        Me.Codice.Name = "Codice"
        '
        'Descrizione
        '
        Me.Descrizione.DataPropertyName = "Descrizione"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Descrizione.DefaultCellStyle = DataGridViewCellStyle4
        Me.Descrizione.HeaderText = "Descrizione"
        Me.Descrizione.MinimumWidth = 250
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.Width = 250
        '
        'PrezzoUnit
        '
        Me.PrezzoUnit.DataPropertyName = "PrezzoUnit"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PrezzoUnit.DefaultCellStyle = DataGridViewCellStyle5
        Me.PrezzoUnit.HeaderText = "P.zo Unit"
        Me.PrezzoUnit.MinimumWidth = 100
        Me.PrezzoUnit.Name = "PrezzoUnit"
        '
        'Qta
        '
        Me.Qta.DataPropertyName = "Qta"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Qta.DefaultCellStyle = DataGridViewCellStyle6
        Me.Qta.HeaderText = "Qta"
        Me.Qta.MinimumWidth = 100
        Me.Qta.Name = "Qta"
        '
        'Totale
        '
        Me.Totale.DataPropertyName = "Totale"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Totale.DefaultCellStyle = DataGridViewCellStyle7
        Me.Totale.HeaderText = "Totale"
        Me.Totale.MinimumWidth = 100
        Me.Totale.Name = "Totale"
        '
        'tpPagam
        '
        Me.tpPagam.Controls.Add(Me.UcPagamenti)
        Me.tpPagam.Location = New System.Drawing.Point(4, 22)
        Me.tpPagam.Name = "tpPagam"
        Me.tpPagam.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPagam.Size = New System.Drawing.Size(557, 324)
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
        Me.UcPagamenti.Size = New System.Drawing.Size(551, 318)
        Me.UcPagamenti.TabIndex = 1
        Me.UcPagamenti.TipoVoceContabile = FormerLib.FormerEnum.enTipoVoceContab.NonSpecificata
        '
        'tbImmagini
        '
        Me.tbImmagini.Controls.Add(Me.GroupBox1)
        Me.tbImmagini.ImageKey = "_Anteprima.png"
        Me.tbImmagini.Location = New System.Drawing.Point(4, 22)
        Me.tbImmagini.Name = "tbImmagini"
        Me.tbImmagini.Padding = New System.Windows.Forms.Padding(3)
        Me.tbImmagini.Size = New System.Drawing.Size(557, 324)
        Me.tbImmagini.TabIndex = 3
        Me.tbImmagini.Text = "Immagini/Documenti allegati"
        Me.tbImmagini.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lnkApri4)
        Me.GroupBox1.Controls.Add(Me.btnSfoglia4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtFile4)
        Me.GroupBox1.Controls.Add(Me.lnkApri3)
        Me.GroupBox1.Controls.Add(Me.btnSfoglia3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtFile3)
        Me.GroupBox1.Controls.Add(Me.lnkApri2)
        Me.GroupBox1.Controls.Add(Me.btnSfoglia2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtFile2)
        Me.GroupBox1.Controls.Add(Me.lnkApri1)
        Me.GroupBox1.Controls.Add(Me.btnSfoglia1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFile1)
        Me.GroupBox1.Controls.Add(Me.lnkApri)
        Me.GroupBox1.Controls.Add(Me.btnSfoglia)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFile)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(551, 318)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Immagini/Documenti allegati"
        '
        'lnkApri4
        '
        Me.lnkApri4.AutoSize = True
        Me.lnkApri4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkApri4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApri4.Location = New System.Drawing.Point(40, 212)
        Me.lnkApri4.Name = "lnkApri4"
        Me.lnkApri4.Size = New System.Drawing.Size(30, 15)
        Me.lnkApri4.TabIndex = 68
        Me.lnkApri4.TabStop = True
        Me.lnkApri4.Text = "Apri"
        '
        'btnSfoglia4
        '
        Me.btnSfoglia4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSfoglia4.Location = New System.Drawing.Point(543, 188)
        Me.btnSfoglia4.Name = "btnSfoglia4"
        Me.btnSfoglia4.Size = New System.Drawing.Size(27, 23)
        Me.btnSfoglia4.TabIndex = 12
        Me.btnSfoglia4.Text = "..."
        Me.btnSfoglia4.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(10, 191)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 15)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "File"
        '
        'txtFile4
        '
        Me.txtFile4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFile4.Location = New System.Drawing.Point(43, 188)
        Me.txtFile4.Name = "txtFile4"
        Me.txtFile4.ReadOnly = True
        Me.txtFile4.Size = New System.Drawing.Size(494, 23)
        Me.txtFile4.TabIndex = 65
        Me.txtFile4.TabStop = False
        '
        'lnkApri3
        '
        Me.lnkApri3.AutoSize = True
        Me.lnkApri3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkApri3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApri3.Location = New System.Drawing.Point(40, 170)
        Me.lnkApri3.Name = "lnkApri3"
        Me.lnkApri3.Size = New System.Drawing.Size(30, 15)
        Me.lnkApri3.TabIndex = 64
        Me.lnkApri3.TabStop = True
        Me.lnkApri3.Text = "Apri"
        '
        'btnSfoglia3
        '
        Me.btnSfoglia3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSfoglia3.Location = New System.Drawing.Point(543, 146)
        Me.btnSfoglia3.Name = "btnSfoglia3"
        Me.btnSfoglia3.Size = New System.Drawing.Size(27, 23)
        Me.btnSfoglia3.TabIndex = 11
        Me.btnSfoglia3.Text = "..."
        Me.btnSfoglia3.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(10, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 15)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "File"
        '
        'txtFile3
        '
        Me.txtFile3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFile3.Location = New System.Drawing.Point(43, 146)
        Me.txtFile3.Name = "txtFile3"
        Me.txtFile3.ReadOnly = True
        Me.txtFile3.Size = New System.Drawing.Size(494, 23)
        Me.txtFile3.TabIndex = 61
        Me.txtFile3.TabStop = False
        '
        'lnkApri2
        '
        Me.lnkApri2.AutoSize = True
        Me.lnkApri2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkApri2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApri2.Location = New System.Drawing.Point(40, 128)
        Me.lnkApri2.Name = "lnkApri2"
        Me.lnkApri2.Size = New System.Drawing.Size(30, 15)
        Me.lnkApri2.TabIndex = 60
        Me.lnkApri2.TabStop = True
        Me.lnkApri2.Text = "Apri"
        '
        'btnSfoglia2
        '
        Me.btnSfoglia2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSfoglia2.Location = New System.Drawing.Point(543, 104)
        Me.btnSfoglia2.Name = "btnSfoglia2"
        Me.btnSfoglia2.Size = New System.Drawing.Size(27, 23)
        Me.btnSfoglia2.TabIndex = 10
        Me.btnSfoglia2.Text = "..."
        Me.btnSfoglia2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(10, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 15)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "File"
        '
        'txtFile2
        '
        Me.txtFile2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFile2.Location = New System.Drawing.Point(43, 104)
        Me.txtFile2.Name = "txtFile2"
        Me.txtFile2.ReadOnly = True
        Me.txtFile2.Size = New System.Drawing.Size(494, 23)
        Me.txtFile2.TabIndex = 57
        Me.txtFile2.TabStop = False
        '
        'lnkApri1
        '
        Me.lnkApri1.AutoSize = True
        Me.lnkApri1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkApri1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApri1.Location = New System.Drawing.Point(40, 86)
        Me.lnkApri1.Name = "lnkApri1"
        Me.lnkApri1.Size = New System.Drawing.Size(30, 15)
        Me.lnkApri1.TabIndex = 56
        Me.lnkApri1.TabStop = True
        Me.lnkApri1.Text = "Apri"
        '
        'btnSfoglia1
        '
        Me.btnSfoglia1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSfoglia1.Location = New System.Drawing.Point(543, 62)
        Me.btnSfoglia1.Name = "btnSfoglia1"
        Me.btnSfoglia1.Size = New System.Drawing.Size(27, 23)
        Me.btnSfoglia1.TabIndex = 9
        Me.btnSfoglia1.Text = "..."
        Me.btnSfoglia1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(10, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 15)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "File"
        '
        'txtFile1
        '
        Me.txtFile1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFile1.Location = New System.Drawing.Point(43, 62)
        Me.txtFile1.Name = "txtFile1"
        Me.txtFile1.ReadOnly = True
        Me.txtFile1.Size = New System.Drawing.Size(494, 23)
        Me.txtFile1.TabIndex = 53
        Me.txtFile1.TabStop = False
        '
        'lnkApri
        '
        Me.lnkApri.AutoSize = True
        Me.lnkApri.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkApri.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApri.Location = New System.Drawing.Point(40, 44)
        Me.lnkApri.Name = "lnkApri"
        Me.lnkApri.Size = New System.Drawing.Size(30, 15)
        Me.lnkApri.TabIndex = 52
        Me.lnkApri.TabStop = True
        Me.lnkApri.Text = "Apri"
        '
        'btnSfoglia
        '
        Me.btnSfoglia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSfoglia.Location = New System.Drawing.Point(543, 20)
        Me.btnSfoglia.Name = "btnSfoglia"
        Me.btnSfoglia.Size = New System.Drawing.Size(27, 23)
        Me.btnSfoglia.TabIndex = 8
        Me.btnSfoglia.Text = "..."
        Me.btnSfoglia.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 15)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "File"
        '
        'txtFile
        '
        Me.txtFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFile.Location = New System.Drawing.Point(43, 20)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.ReadOnly = True
        Me.txtFile.Size = New System.Drawing.Size(494, 23)
        Me.txtFile.TabIndex = 6
        Me.txtFile.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(57, 196)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 15)
        Me.Label12.TabIndex = 153
        Me.Label12.Text = "Spese Incasso"
        '
        'txtDescrizione
        '
        Me.txtDescrizione.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescrizione.Location = New System.Drawing.Point(301, 106)
        Me.txtDescrizione.Name = "txtDescrizione"
        Me.txtDescrizione.Size = New System.Drawing.Size(310, 23)
        Me.txtDescrizione.TabIndex = 4
        '
        'txtSpeseIncasso
        '
        Me.txtSpeseIncasso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSpeseIncasso.Location = New System.Drawing.Point(161, 193)
        Me.txtSpeseIncasso.MaxLength = 5
        Me.txtSpeseIncasso.My_AccettaNegativi = False
        Me.txtSpeseIncasso.My_AllowOnlyInteger = False
        Me.txtSpeseIncasso.My_DefaultValue = 0
        Me.txtSpeseIncasso.My_MaxValue = 1000.0!
        Me.txtSpeseIncasso.My_MinValue = 0!
        Me.txtSpeseIncasso.My_ReplaceWithDefaultValue = True
        Me.txtSpeseIncasso.Name = "txtSpeseIncasso"
        Me.txtSpeseIncasso.Size = New System.Drawing.Size(200, 23)
        Me.txtSpeseIncasso.TabIndex = 7
        Me.txtSpeseIncasso.Text = "0"
        Me.txtSpeseIncasso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCognome
        '
        Me.lblCognome.AutoSize = True
        Me.lblCognome.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCognome.ForeColor = System.Drawing.Color.Black
        Me.lblCognome.Location = New System.Drawing.Point(228, 109)
        Me.lblCognome.Name = "lblCognome"
        Me.lblCognome.Size = New System.Drawing.Size(67, 15)
        Me.lblCognome.TabIndex = 134
        Me.lblCognome.Text = "Descrizione"
        '
        'lblTotNonCongr
        '
        Me.lblTotNonCongr.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotNonCongr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblTotNonCongr.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.lblTotNonCongr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTotNonCongr.Location = New System.Drawing.Point(421, 159)
        Me.lblTotNonCongr.Name = "lblTotNonCongr"
        Me.lblTotNonCongr.Size = New System.Drawing.Size(190, 31)
        Me.lblTotNonCongr.TabIndex = 151
        Me.lblTotNonCongr.Text = "TOTALE NON CONGRUENTE"
        Me.lblTotNonCongr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTotNonCongr.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(57, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "Data *"
        '
        'txtTotaleDoc
        '
        Me.txtTotaleDoc.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotaleDoc.Location = New System.Drawing.Point(161, 280)
        Me.txtTotaleDoc.MaxLength = 5
        Me.txtTotaleDoc.My_AccettaNegativi = False
        Me.txtTotaleDoc.My_AllowOnlyInteger = False
        Me.txtTotaleDoc.My_DefaultValue = 0
        Me.txtTotaleDoc.My_MaxValue = 1000.0!
        Me.txtTotaleDoc.My_MinValue = 0!
        Me.txtTotaleDoc.My_ReplaceWithDefaultValue = True
        Me.txtTotaleDoc.Name = "txtTotaleDoc"
        Me.txtTotaleDoc.ReadOnly = True
        Me.txtTotaleDoc.Size = New System.Drawing.Size(200, 23)
        Me.txtTotaleDoc.TabIndex = 8
        Me.txtTotaleDoc.TabStop = False
        Me.txtTotaleDoc.Text = "0"
        Me.txtTotaleDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dataOp
        '
        Me.dataOp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dataOp.Location = New System.Drawing.Point(161, 50)
        Me.dataOp.Name = "dataOp"
        Me.dataOp.Size = New System.Drawing.Size(180, 23)
        Me.dataOp.TabIndex = 0
        '
        'lblCorr2
        '
        Me.lblCorr2.AutoSize = True
        Me.lblCorr2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCorr2.ForeColor = System.Drawing.Color.Black
        Me.lblCorr2.Location = New System.Drawing.Point(57, 167)
        Me.lblCorr2.Name = "lblCorr2"
        Me.lblCorr2.Size = New System.Drawing.Size(94, 15)
        Me.lblCorr2.TabIndex = 150
        Me.lblCorr2.Text = "Costo spedizioni"
        '
        'lblTipoCli
        '
        Me.lblTipoCli.AutoSize = True
        Me.lblTipoCli.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipoCli.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblTipoCli.Location = New System.Drawing.Point(57, 81)
        Me.lblTipoCli.Name = "lblTipoCli"
        Me.lblTipoCli.Size = New System.Drawing.Size(67, 15)
        Me.lblTipoCli.TabIndex = 136
        Me.lblTipoCli.Text = "Fornitore *"
        '
        'txtCostoSped
        '
        Me.txtCostoSped.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCostoSped.Location = New System.Drawing.Point(161, 164)
        Me.txtCostoSped.MaxLength = 5
        Me.txtCostoSped.My_AccettaNegativi = False
        Me.txtCostoSped.My_AllowOnlyInteger = False
        Me.txtCostoSped.My_DefaultValue = 0
        Me.txtCostoSped.My_MaxValue = 9999.0!
        Me.txtCostoSped.My_MinValue = 0!
        Me.txtCostoSped.My_ReplaceWithDefaultValue = True
        Me.txtCostoSped.Name = "txtCostoSped"
        Me.txtCostoSped.Size = New System.Drawing.Size(200, 23)
        Me.txtCostoSped.TabIndex = 6
        Me.txtCostoSped.Text = "0"
        Me.txtCostoSped.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCliente
        '
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(161, 78)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(420, 23)
        Me.cmbCliente.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(384, 139)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 15)
        Me.Label11.TabIndex = 148
        Me.Label11.Text = "Totale Calcolato"
        Me.toolTipHelp.SetToolTip(Me.Label11, "Totale calcolato dagli importi contenuti nei DDT selezionati")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(57, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 15)
        Me.Label10.TabIndex = 137
        Me.Label10.Text = "Numero"
        '
        'btnDetCli
        '
        Me.btnDetCli.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDetCli.Location = New System.Drawing.Point(587, 78)
        Me.btnDetCli.Name = "btnDetCli"
        Me.btnDetCli.Size = New System.Drawing.Size(24, 23)
        Me.btnDetCli.TabIndex = 147
        Me.btnDetCli.Text = "..."
        Me.btnDetCli.UseVisualStyleBackColor = True
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNumero.Location = New System.Drawing.Point(161, 106)
        Me.txtNumero.My_AccettaNegativi = False
        Me.txtNumero.My_AllowOnlyInteger = True
        Me.txtNumero.My_DefaultValue = 0
        Me.txtNumero.My_MaxValue = 1.0E+10!
        Me.txtNumero.My_MinValue = 0!
        Me.txtNumero.My_ReplaceWithDefaultValue = True
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(61, 23)
        Me.txtNumero.TabIndex = 3
        Me.txtNumero.Text = "0"
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(57, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 15)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "Totale Netto *"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(353, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 15)
        Me.Label13.TabIndex = 138
        Me.Label13.Text = "Da pagare il "
        '
        'txtImporto
        '
        Me.txtImporto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtImporto.Location = New System.Drawing.Point(161, 135)
        Me.txtImporto.My_AccettaNegativi = False
        Me.txtImporto.My_AllowOnlyInteger = False
        Me.txtImporto.My_DefaultValue = 0
        Me.txtImporto.My_MaxValue = 1.0E+10!
        Me.txtImporto.My_MinValue = 0!
        Me.txtImporto.My_ReplaceWithDefaultValue = True
        Me.txtImporto.Name = "txtImporto"
        Me.txtImporto.Size = New System.Drawing.Size(200, 23)
        Me.txtImporto.TabIndex = 5
        Me.txtImporto.Text = "0"
        Me.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDataPrevPagam
        '
        Me.txtDataPrevPagam.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDataPrevPagam.Location = New System.Drawing.Point(431, 49)
        Me.txtDataPrevPagam.Name = "txtDataPrevPagam"
        Me.txtDataPrevPagam.Size = New System.Drawing.Size(180, 23)
        Me.txtDataPrevPagam.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(57, 254)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 15)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "IVA"
        '
        'txtPercIva
        '
        Me.txtPercIva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPercIva.Location = New System.Drawing.Point(416, 251)
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
        Me.txtPercIva.TabIndex = 141
        Me.txtPercIva.TabStop = False
        Me.txtPercIva.Text = "20"
        Me.txtPercIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIva
        '
        Me.txtIva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIva.Location = New System.Drawing.Point(161, 251)
        Me.txtIva.My_AccettaNegativi = False
        Me.txtIva.My_AllowOnlyInteger = False
        Me.txtIva.My_DefaultValue = 0
        Me.txtIva.My_MaxValue = 1.0E+10!
        Me.txtIva.My_MinValue = 0!
        Me.txtIva.My_ReplaceWithDefaultValue = True
        Me.txtIva.Name = "txtIva"
        Me.txtIva.ReadOnly = True
        Me.txtIva.Size = New System.Drawing.Size(200, 23)
        Me.txtIva.TabIndex = 7
        Me.txtIva.TabStop = False
        Me.txtIva.Text = "0"
        Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(373, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "% IVA"
        '
        'lblTotale
        '
        Me.lblTotale.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotale.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotale.ForeColor = System.Drawing.Color.Black
        Me.lblTotale.Location = New System.Drawing.Point(491, 135)
        Me.lblTotale.Name = "lblTotale"
        Me.lblTotale.Size = New System.Drawing.Size(120, 23)
        Me.lblTotale.TabIndex = 142
        Me.lblTotale.Text = "0"
        Me.lblTotale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(57, 283)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 15)
        Me.Label15.TabIndex = 146
        Me.Label15.Text = "TOTALE"
        '
        'UcDocumentiFiscaliXMLCosto
        '
        Me.UcDocumentiFiscaliXMLCosto.BackColor = System.Drawing.Color.White
        Me.UcDocumentiFiscaliXMLCosto.CaricamentoCompletato = False
        Me.UcDocumentiFiscaliXMLCosto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcDocumentiFiscaliXMLCosto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcDocumentiFiscaliXMLCosto.Location = New System.Drawing.Point(0, 0)
        Me.UcDocumentiFiscaliXMLCosto.Name = "UcDocumentiFiscaliXMLCosto"
        Me.UcDocumentiFiscaliXMLCosto.Size = New System.Drawing.Size(570, 728)
        Me.UcDocumentiFiscaliXMLCosto.TabIndex = 0
        '
        'tpPDF
        '
        Me.tpPDF.Controls.Add(Me.RadPreview)
        Me.tpPDF.Controls.Add(Me.RadPdfViewerNavigator)
        Me.tpPDF.ImageKey = "_pdf.png"
        Me.tpPDF.Location = New System.Drawing.Point(4, 31)
        Me.tpPDF.Name = "tpPDF"
        Me.tpPDF.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPDF.Size = New System.Drawing.Size(1201, 734)
        Me.tpPDF.TabIndex = 2
        Me.tpPDF.Text = "Fattura PDF"
        Me.tpPDF.UseVisualStyleBackColor = True
        '
        'RadPreview
        '
        Me.RadPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPreview.Location = New System.Drawing.Point(3, 39)
        Me.RadPreview.Name = "RadPreview"
        Me.RadPreview.Size = New System.Drawing.Size(1195, 692)
        Me.RadPreview.TabIndex = 3
        Me.RadPreview.ThemeName = "VisualStudio2012Dark"
        Me.RadPreview.ThumbnailsScaleFactor = 0.15!
        '
        'RadPdfViewerNavigator
        '
        Me.RadPdfViewerNavigator.AssociatedViewer = Me.RadPreview
        Me.RadPdfViewerNavigator.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPdfViewerNavigator.Location = New System.Drawing.Point(3, 3)
        Me.RadPdfViewerNavigator.Name = "RadPdfViewerNavigator"
        Me.RadPdfViewerNavigator.Size = New System.Drawing.Size(1195, 36)
        Me.RadPdfViewerNavigator.TabIndex = 2
        Me.RadPdfViewerNavigator.ThemeName = "VisualStudio2012Dark"
        '
        'tpAmmortamento
        '
        Me.tpAmmortamento.Controls.Add(Me.UcContabCostoAmmortamento)
        Me.tpAmmortamento.ImageKey = "_ammortamento26.png"
        Me.tpAmmortamento.Location = New System.Drawing.Point(4, 31)
        Me.tpAmmortamento.Name = "tpAmmortamento"
        Me.tpAmmortamento.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAmmortamento.Size = New System.Drawing.Size(1201, 734)
        Me.tpAmmortamento.TabIndex = 3
        Me.tpAmmortamento.Text = "Ammortamento"
        Me.tpAmmortamento.UseVisualStyleBackColor = True
        '
        'UcContabCostoAmmortamento
        '
        Me.UcContabCostoAmmortamento.BackColor = System.Drawing.Color.White
        Me.UcContabCostoAmmortamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcContabCostoAmmortamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcContabCostoAmmortamento.Location = New System.Drawing.Point(3, 3)
        Me.UcContabCostoAmmortamento.Name = "UcContabCostoAmmortamento"
        Me.UcContabCostoAmmortamento.Size = New System.Drawing.Size(1195, 728)
        Me.UcContabCostoAmmortamento.TabIndex = 1
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "ico_A_R.png")
        Me.imlTab.Images.SetKeyName(1, "_pdf.png")
        Me.imlTab.Images.SetKeyName(2, "_xml.png")
        Me.imlTab.Images.SetKeyName(3, "_ammortamento26.png")
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = "File PDF|*.pdf|File immagine|*.jpg"
        '
        'frmContabilitaFatturaRiepilogativaCosto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1209, 817)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmContabilitaFatturaRiepilogativaCosto"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Fattura Riepilogativa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel1.PerformLayout()
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        CType(Me.pctSblocco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDettaglio.ResumeLayout(False)
        Me.tpDoc.ResumeLayout(False)
        CType(Me.dgDocDDT.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDocDDT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dgDocDDT.ResumeLayout(False)
        Me.dgDocDDT.PerformLayout()
        Me.tpRighe.ResumeLayout(False)
        CType(Me.dgVociFat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPagam.ResumeLayout(False)
        Me.tbImmagini.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpPDF.ResumeLayout(False)
        Me.tpPDF.PerformLayout()
        CType(Me.RadPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPdfViewerNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAmmortamento.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents TabDettaglio As TabControl
    Friend WithEvents tpDoc As TabPage
    Friend WithEvents tpPagam As TabPage
    Friend WithEvents UcPagamenti As ucAmministrazionePagamenti
    Friend WithEvents pctTipo As PictureBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents txtDataPrevPagam As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents txtNumero As ucNumericTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents lblTipoCli As Label
    Friend WithEvents dataOp As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCognome As Label
    Friend WithEvents txtDescrizione As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtImporto As ucNumericTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtIva As ucNumericTextBox
    Friend WithEvents lblTotale As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPercIva As ucNumericTextBox
    Friend WithEvents btnDetCli As Button
    Friend WithEvents dgDocDDT As Telerik.WinControls.UI.RadGridView
    Friend WithEvents tbImmagini As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lnkApri4 As LinkLabel
    Friend WithEvents btnSfoglia4 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents txtFile4 As TextBox
    Friend WithEvents lnkApri3 As LinkLabel
    Friend WithEvents btnSfoglia3 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFile3 As TextBox
    Friend WithEvents lnkApri2 As LinkLabel
    Friend WithEvents btnSfoglia2 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFile2 As TextBox
    Friend WithEvents lnkApri1 As LinkLabel
    Friend WithEvents btnSfoglia1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFile1 As TextBox
    Friend WithEvents lnkApri As LinkLabel
    Friend WithEvents btnSfoglia As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFile As TextBox
    Friend WithEvents imlTab As ImageList
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTotaleDoc As ucNumericTextBox
    Friend WithEvents lblCorr2 As Label
    Friend WithEvents txtCostoSped As ucNumericTextBox
    Friend WithEvents lblTotNonCongr As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtAddebitiVari As ucNumericTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSpeseIncasso As ucNumericTextBox
    Friend WithEvents SplitContainerMain As SplitContainer
    Friend WithEvents RadPreview As Telerik.WinControls.UI.RadPdfViewer
    Friend WithEvents RadPdfViewerNavigator As Telerik.WinControls.UI.RadPdfViewerNavigator
    Friend WithEvents UcDocumentiFiscaliEditRow As ucDocumentiFiscaliEditRow
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnMainFile As Button
    Friend WithEvents txtMainFile As TextBox
    Friend WithEvents lblAzienda As Label
    Friend WithEvents UcDocumentiFiscaliXMLCosto As ucDocumentiFiscaliXMLCosto
    Friend WithEvents tpRighe As TabPage
    Friend WithEvents dgVociFat As DataGridView
    Friend WithEvents Codice As DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As DataGridViewTextBoxColumn
    Friend WithEvents PrezzoUnit As DataGridViewTextBoxColumn
    Friend WithEvents Qta As DataGridViewTextBoxColumn
    Friend WithEvents Totale As DataGridViewTextBoxColumn
    Friend WithEvents tpPDF As TabPage
    Friend WithEvents pctSblocco As PictureBox
    Friend WithEvents tpAmmortamento As TabPage
    Friend WithEvents UcContabCostoAmmortamento As ucContabCostoAmmortamento
End Class
