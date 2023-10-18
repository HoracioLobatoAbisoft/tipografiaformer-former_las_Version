<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommessaDigitalePannelli
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnChiudi = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnFolder = New System.Windows.Forms.Button()
        Me.chkStampaNumPag = New System.Windows.Forms.CheckBox()
        Me.lnkOpenFileSorg = New System.Windows.Forms.LinkLabel()
        Me.dgSorgenti = New System.Windows.Forms.DataGridView()
        Me.NPagina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnStampa = New System.Windows.Forms.Button()
        Me.btnGeneraPDF = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSormonto = New Former.ucNumericTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNPannelli = New Former.ucNumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAltezzaTotale = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLarghezzaTotale = New Former.ucNumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLarghezzaRotolo = New Former.ucNumericTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.dgSorgenti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnChiudi)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 645)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(643, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnChiudi
        '
        Me.btnChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChiudi.AutoSize = True
        Me.btnChiudi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnChiudi.FlatAppearance.BorderSize = 0
        Me.btnChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChiudi.ForeColor = System.Drawing.Color.Black
        Me.btnChiudi.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnChiudi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChiudi.Location = New System.Drawing.Point(559, 12)
        Me.btnChiudi.Name = "btnChiudi"
        Me.btnChiudi.Size = New System.Drawing.Size(78, 32)
        Me.btnChiudi.TabIndex = 16
        Me.btnChiudi.Text = "Chiudi"
        Me.btnChiudi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnChiudi.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(643, 645)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnFolder)
        Me.tbProd.Controls.Add(Me.chkStampaNumPag)
        Me.tbProd.Controls.Add(Me.lnkOpenFileSorg)
        Me.tbProd.Controls.Add(Me.dgSorgenti)
        Me.tbProd.Controls.Add(Me.btnStampa)
        Me.tbProd.Controls.Add(Me.btnGeneraPDF)
        Me.tbProd.Controls.Add(Me.Label10)
        Me.tbProd.Controls.Add(Me.Label9)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtSormonto)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtNPannelli)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtAltezzaTotale)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.txtLarghezzaTotale)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtLarghezzaRotolo)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(635, 619)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Pannelli Digitale"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnFolder
        '
        Me.btnFolder.Enabled = False
        Me.btnFolder.Image = Global.Former.My.Resources.Resources._CartellaAperta
        Me.btnFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFolder.Location = New System.Drawing.Point(409, 549)
        Me.btnFolder.Name = "btnFolder"
        Me.btnFolder.Size = New System.Drawing.Size(170, 49)
        Me.btnFolder.TabIndex = 60
        Me.btnFolder.Text = "Apri Cartella"
        Me.toolTipHelp.SetToolTip(Me.btnFolder, "Apre la cartella dove sono stati generati i PDF")
        Me.btnFolder.UseVisualStyleBackColor = True
        '
        'chkStampaNumPag
        '
        Me.chkStampaNumPag.AutoSize = True
        Me.chkStampaNumPag.Checked = True
        Me.chkStampaNumPag.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStampaNumPag.Location = New System.Drawing.Point(185, 446)
        Me.chkStampaNumPag.Name = "chkStampaNumPag"
        Me.chkStampaNumPag.Size = New System.Drawing.Size(161, 19)
        Me.chkStampaNumPag.TabIndex = 59
        Me.chkStampaNumPag.Text = "Stampa Numeri di Pagina"
        Me.chkStampaNumPag.UseVisualStyleBackColor = True
        '
        'lnkOpenFileSorg
        '
        Me.lnkOpenFileSorg.AutoSize = True
        Me.lnkOpenFileSorg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkOpenFileSorg.Image = Global.Former.My.Resources.Resources._Shell
        Me.lnkOpenFileSorg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkOpenFileSorg.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkOpenFileSorg.Location = New System.Drawing.Point(484, 260)
        Me.lnkOpenFileSorg.Name = "lnkOpenFileSorg"
        Me.lnkOpenFileSorg.Padding = New System.Windows.Forms.Padding(24, 0, 0, 0)
        Me.lnkOpenFileSorg.Size = New System.Drawing.Size(134, 15)
        Me.lnkOpenFileSorg.TabIndex = 58
        Me.lnkOpenFileSorg.TabStop = True
        Me.lnkOpenFileSorg.Text = "Apri file selezionato"
        Me.lnkOpenFileSorg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgSorgenti
        '
        Me.dgSorgenti.AllowUserToAddRows = False
        Me.dgSorgenti.AllowUserToDeleteRows = False
        Me.dgSorgenti.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgSorgenti.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSorgenti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSorgenti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgSorgenti.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgSorgenti.BackgroundColor = System.Drawing.Color.White
        Me.dgSorgenti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgSorgenti.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSorgenti.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgSorgenti.ColumnHeadersHeight = 20
        Me.dgSorgenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSorgenti.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NPagina, Me.FilePath})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSorgenti.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgSorgenti.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgSorgenti.EnableHeadersVisualStyles = False
        Me.dgSorgenti.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgSorgenti.Location = New System.Drawing.Point(19, 64)
        Me.dgSorgenti.MultiSelect = False
        Me.dgSorgenti.Name = "dgSorgenti"
        Me.dgSorgenti.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSorgenti.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgSorgenti.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgSorgenti.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgSorgenti.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgSorgenti.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgSorgenti.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgSorgenti.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSorgenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSorgenti.Size = New System.Drawing.Size(599, 193)
        Me.dgSorgenti.TabIndex = 57
        Me.dgSorgenti.TabStop = False
        '
        'NPagina
        '
        Me.NPagina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NPagina.DataPropertyName = "NumPagina"
        Me.NPagina.HeaderText = "Num Pagina"
        Me.NPagina.Name = "NPagina"
        Me.NPagina.ReadOnly = True
        '
        'FilePath
        '
        Me.FilePath.DataPropertyName = "FilePath"
        Me.FilePath.HeaderText = "FilePath"
        Me.FilePath.Name = "FilePath"
        Me.FilePath.ReadOnly = True
        '
        'btnStampa
        '
        Me.btnStampa.Enabled = False
        Me.btnStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.btnStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampa.Location = New System.Drawing.Point(233, 549)
        Me.btnStampa.Name = "btnStampa"
        Me.btnStampa.Size = New System.Drawing.Size(170, 49)
        Me.btnStampa.TabIndex = 35
        Me.btnStampa.Text = "Stampa PDF"
        Me.toolTipHelp.SetToolTip(Me.btnStampa, "Propone una soluzione in base ai parametri inseriti sopra")
        Me.btnStampa.UseVisualStyleBackColor = True
        '
        'btnGeneraPDF
        '
        Me.btnGeneraPDF.Image = Global.Former.My.Resources.Resources._pdf
        Me.btnGeneraPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGeneraPDF.Location = New System.Drawing.Point(57, 549)
        Me.btnGeneraPDF.Name = "btnGeneraPDF"
        Me.btnGeneraPDF.Size = New System.Drawing.Size(170, 49)
        Me.btnGeneraPDF.TabIndex = 34
        Me.btnGeneraPDF.Text = "Genera PDF"
        Me.toolTipHelp.SetToolTip(Me.btnGeneraPDF, "Genera i pannelli in formato PDF")
        Me.btnGeneraPDF.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(401, 411)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 15)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "(mm)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(401, 379)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 15)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "(pezzi)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(401, 347)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 15)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "(mm)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(401, 315)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 15)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "(mm)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(401, 283)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "(mm)"
        '
        'txtSormonto
        '
        Me.txtSormonto.My_AccettaNegativi = False
        Me.txtSormonto.My_DefaultValue = 0
        Me.txtSormonto.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSormonto.Location = New System.Drawing.Point(313, 405)
        Me.txtSormonto.MaxLength = 6
        Me.txtSormonto.My_MaxValue = 999999.0!
        Me.txtSormonto.My_MinValue = 0!
        Me.txtSormonto.Name = "txtSormonto"
        Me.txtSormonto.My_AllowOnlyInteger = True
        Me.txtSormonto.My_ReplaceWithDefaultValue = True
        Me.txtSormonto.Size = New System.Drawing.Size(82, 29)
        Me.txtSormonto.TabIndex = 28
        Me.txtSormonto.Text = "15"
        Me.txtSormonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(182, 411)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Sormonto"
        '
        'txtNPannelli
        '
        Me.txtNPannelli.My_AccettaNegativi = False
        Me.txtNPannelli.My_DefaultValue = 0
        Me.txtNPannelli.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNPannelli.Location = New System.Drawing.Point(313, 373)
        Me.txtNPannelli.MaxLength = 6
        Me.txtNPannelli.My_MaxValue = 999999.0!
        Me.txtNPannelli.My_MinValue = 0!
        Me.txtNPannelli.Name = "txtNPannelli"
        Me.txtNPannelli.My_AllowOnlyInteger = True
        Me.txtNPannelli.My_ReplaceWithDefaultValue = True
        Me.txtNPannelli.Size = New System.Drawing.Size(82, 29)
        Me.txtNPannelli.TabIndex = 26
        Me.txtNPannelli.Text = "6"
        Me.txtNPannelli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(182, 379)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "N° Pannelli"
        '
        'txtAltezzaTotale
        '
        Me.txtAltezzaTotale.My_AccettaNegativi = False
        Me.txtAltezzaTotale.My_DefaultValue = 0
        Me.txtAltezzaTotale.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAltezzaTotale.Location = New System.Drawing.Point(313, 341)
        Me.txtAltezzaTotale.MaxLength = 6
        Me.txtAltezzaTotale.My_MaxValue = 999999.0!
        Me.txtAltezzaTotale.My_MinValue = 0!
        Me.txtAltezzaTotale.Name = "txtAltezzaTotale"
        Me.txtAltezzaTotale.My_AllowOnlyInteger = True
        Me.txtAltezzaTotale.My_ReplaceWithDefaultValue = True
        Me.txtAltezzaTotale.Size = New System.Drawing.Size(82, 29)
        Me.txtAltezzaTotale.TabIndex = 24
        Me.txtAltezzaTotale.Text = "0"
        Me.txtAltezzaTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(182, 347)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Altezza Totale"
        '
        'txtLarghezzaTotale
        '
        Me.txtLarghezzaTotale.My_AccettaNegativi = False
        Me.txtLarghezzaTotale.My_DefaultValue = 0
        Me.txtLarghezzaTotale.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLarghezzaTotale.Location = New System.Drawing.Point(313, 309)
        Me.txtLarghezzaTotale.MaxLength = 6
        Me.txtLarghezzaTotale.My_MaxValue = 999999.0!
        Me.txtLarghezzaTotale.My_MinValue = 0!
        Me.txtLarghezzaTotale.Name = "txtLarghezzaTotale"
        Me.txtLarghezzaTotale.My_AllowOnlyInteger = True
        Me.txtLarghezzaTotale.My_ReplaceWithDefaultValue = True
        Me.txtLarghezzaTotale.Size = New System.Drawing.Size(82, 29)
        Me.txtLarghezzaTotale.TabIndex = 22
        Me.txtLarghezzaTotale.Text = "0"
        Me.txtLarghezzaTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(182, 315)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Larghezza Totale"
        '
        'txtLarghezzaRotolo
        '
        Me.txtLarghezzaRotolo.My_AccettaNegativi = False
        Me.txtLarghezzaRotolo.My_DefaultValue = 0
        Me.txtLarghezzaRotolo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLarghezzaRotolo.Location = New System.Drawing.Point(313, 277)
        Me.txtLarghezzaRotolo.MaxLength = 6
        Me.txtLarghezzaRotolo.My_MaxValue = 999999.0!
        Me.txtLarghezzaRotolo.My_MinValue = 0!
        Me.txtLarghezzaRotolo.Name = "txtLarghezzaRotolo"
        Me.txtLarghezzaRotolo.My_AllowOnlyInteger = True
        Me.txtLarghezzaRotolo.My_ReplaceWithDefaultValue = True
        Me.txtLarghezzaRotolo.Size = New System.Drawing.Size(82, 29)
        Me.txtLarghezzaRotolo.TabIndex = 20
        Me.txtLarghezzaRotolo.Text = "1000"
        Me.txtLarghezzaRotolo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(182, 283)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 15)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Larghezza Rotolo"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Panels
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(138, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Pannelli Digitale"
        '
        'frmCommessaDigitalePannelli
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnChiudi
        Me.ClientSize = New System.Drawing.Size(643, 693)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCommessaDigitalePannelli"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - "
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.dgSorgenti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnChiudi As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSormonto As ucNumericTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNPannelli As ucNumericTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAltezzaTotale As ucNumericTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLarghezzaTotale As ucNumericTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLarghezzaRotolo As ucNumericTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnGeneraPDF As Button
    Friend WithEvents btnStampa As Button
    Friend WithEvents dgSorgenti As DataGridView
    Friend WithEvents NPagina As DataGridViewTextBoxColumn
    Friend WithEvents FilePath As DataGridViewTextBoxColumn
    Friend WithEvents lnkOpenFileSorg As LinkLabel
    Friend WithEvents chkStampaNumPag As CheckBox
    Friend WithEvents btnFolder As Button
End Class
