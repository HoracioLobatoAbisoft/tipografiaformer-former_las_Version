<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucOperatoreProduzione
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.FlowMacchinari = New System.Windows.Forms.FlowLayoutPanel()
        Me.lnkReset = New System.Windows.Forms.LinkLabel()
        Me.txtNumCom = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumOrd = New Former.ucNumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkSoloProntiDaLavorare = New System.Windows.Forms.CheckBox()
        Me.lblMacchinarioIs = New System.Windows.Forms.Label()
        Me.lblMacchinario = New System.Windows.Forms.Label()
        Me.DgLavori = New System.Windows.Forms.DataGridView()
        Me.icoSegnalino = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn5 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.imgLavorazione = New System.Windows.Forms.DataGridViewImageColumn()
        Me.msg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.P = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ordine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Copie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RagSoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lavorazione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NLastre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Risorsa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InCarico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuLavoro = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ForzaIlLavoroAlloperatoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblNomeUt = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pctHelpFlag = New System.Windows.Forms.PictureBox()
        Me.pctAggiornaPrev = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbCatProd = New System.Windows.Forms.ComboBox()
        Me.btnPrendiInCarico = New System.Windows.Forms.Button()
        Me.lnkLastWork = New System.Windows.Forms.LinkLabel()
        Me.pctOperatore = New System.Windows.Forms.PictureBox()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuLavoro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pctHelpFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctAggiornaPrev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctOperatore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlowMacchinari
        '
        Me.FlowMacchinari.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowMacchinari.AutoScroll = True
        Me.FlowMacchinari.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.FlowMacchinari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowMacchinari.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowMacchinari.Location = New System.Drawing.Point(2, 179)
        Me.FlowMacchinari.Name = "FlowMacchinari"
        Me.FlowMacchinari.Size = New System.Drawing.Size(128, 519)
        Me.FlowMacchinari.TabIndex = 0
        Me.FlowMacchinari.WrapContents = False
        '
        'lnkReset
        '
        Me.lnkReset.AutoSize = True
        Me.lnkReset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkReset.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkReset.Location = New System.Drawing.Point(371, 19)
        Me.lnkReset.Name = "lnkReset"
        Me.lnkReset.Size = New System.Drawing.Size(35, 15)
        Me.lnkReset.TabIndex = 147
        Me.lnkReset.TabStop = True
        Me.lnkReset.Text = "Reset"
        '
        'txtNumCom
        '
        Me.txtNumCom.My_AccettaNegativi = False
        Me.txtNumCom.My_DefaultValue = 0
        Me.txtNumCom.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.txtNumCom.Location = New System.Drawing.Point(198, 14)
        Me.txtNumCom.MaxLength = 6
        Me.txtNumCom.My_MaxValue = 999999.0!
        Me.txtNumCom.My_MinValue = 0!
        Me.txtNumCom.Name = "txtNumCom"
        Me.txtNumCom.My_AllowOnlyInteger = True
        Me.txtNumCom.My_ReplaceWithDefaultValue = False
        Me.txtNumCom.Size = New System.Drawing.Size(48, 23)
        Me.txtNumCom.TabIndex = 146
        Me.txtNumCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.toolTipHelp.SetToolTip(Me.txtNumCom, "Inserire qui il numero di Commessa per vedere solo i lavori riguardanti quella Co" &
        "mmessa")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(130, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Commessa"
        Me.toolTipHelp.SetToolTip(Me.Label2, "Inserire qui il numero di Commessa per vedere solo i lavori riguardanti quella Co" &
        "mmessa")
        '
        'txtNumOrd
        '
        Me.txtNumOrd.My_AccettaNegativi = False
        Me.txtNumOrd.My_DefaultValue = 0
        Me.txtNumOrd.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.txtNumOrd.Location = New System.Drawing.Point(74, 14)
        Me.txtNumOrd.MaxLength = 6
        Me.txtNumOrd.My_MaxValue = 999999.0!
        Me.txtNumOrd.My_MinValue = 0!
        Me.txtNumOrd.Name = "txtNumOrd"
        Me.txtNumOrd.My_AllowOnlyInteger = True
        Me.txtNumOrd.My_ReplaceWithDefaultValue = False
        Me.txtNumOrd.Size = New System.Drawing.Size(48, 23)
        Me.txtNumOrd.TabIndex = 144
        Me.txtNumOrd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.toolTipHelp.SetToolTip(Me.txtNumOrd, "Inserire qui il numero di Ordine per vedere solo i lavori riguardanti quell'ordin" &
        "e")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "Ordine"
        Me.toolTipHelp.SetToolTip(Me.Label1, "Inserire qui il numero di Ordine per vedere solo i lavori riguardanti quell'ordin" &
        "e")
        '
        'chkSoloProntiDaLavorare
        '
        Me.chkSoloProntiDaLavorare.AutoSize = True
        Me.chkSoloProntiDaLavorare.Checked = True
        Me.chkSoloProntiDaLavorare.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSoloProntiDaLavorare.Location = New System.Drawing.Point(9, 78)
        Me.chkSoloProntiDaLavorare.Name = "chkSoloProntiDaLavorare"
        Me.chkSoloProntiDaLavorare.Size = New System.Drawing.Size(132, 19)
        Me.chkSoloProntiDaLavorare.TabIndex = 142
        Me.chkSoloProntiDaLavorare.Text = "Solo da lavorare Ora"
        Me.toolTipHelp.SetToolTip(Me.chkSoloProntiDaLavorare, "Mostra solo i macchinari e i lavori che possono essere effettivamente presi in ca" &
        "rico")
        Me.chkSoloProntiDaLavorare.UseVisualStyleBackColor = True
        '
        'lblMacchinarioIs
        '
        Me.lblMacchinarioIs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMacchinarioIs.BackColor = System.Drawing.Color.White
        Me.lblMacchinarioIs.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblMacchinarioIs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMacchinarioIs.Location = New System.Drawing.Point(133, 102)
        Me.lblMacchinarioIs.Name = "lblMacchinarioIs"
        Me.lblMacchinarioIs.Size = New System.Drawing.Size(205, 25)
        Me.lblMacchinarioIs.TabIndex = 2
        Me.lblMacchinarioIs.Text = "Macchinario selezionato:"
        Me.lblMacchinarioIs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMacchinario
        '
        Me.lblMacchinario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMacchinario.BackColor = System.Drawing.Color.White
        Me.lblMacchinario.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblMacchinario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMacchinario.Location = New System.Drawing.Point(344, 104)
        Me.lblMacchinario.Name = "lblMacchinario"
        Me.lblMacchinario.Size = New System.Drawing.Size(430, 23)
        Me.lblMacchinario.TabIndex = 3
        Me.lblMacchinario.Text = "-"
        '
        'DgLavori
        '
        Me.DgLavori.AllowUserToAddRows = False
        Me.DgLavori.AllowUserToDeleteRows = False
        Me.DgLavori.AllowUserToOrderColumns = True
        Me.DgLavori.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLavori.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLavori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
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
        Me.DgLavori.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.icoSegnalino, Me.DataGridViewImageColumn5, Me.imgLavorazione, Me.msg, Me.P, Me.Ordine, Me.num, Me.Data, Me.Copie, Me.Tipo, Me.RagSoc, Me.Lavorazione, Me.NLastre, Me.FR, Me.Risorsa, Me.InCarico})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.DefaultCellStyle = DataGridViewCellStyle14
        Me.DgLavori.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLavori.EnableHeadersVisualStyles = False
        Me.DgLavori.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLavori.Location = New System.Drawing.Point(133, 132)
        Me.DgLavori.MultiSelect = False
        Me.DgLavori.Name = "DgLavori"
        Me.DgLavori.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DgLavori.RowHeadersVisible = False
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.DgLavori.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgLavori.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLavori.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLavori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLavori.Size = New System.Drawing.Size(641, 566)
        Me.DgLavori.TabIndex = 105
        Me.DgLavori.TabStop = False
        '
        'icoSegnalino
        '
        Me.icoSegnalino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.icoSegnalino.DataPropertyName = "IcoSegnalino"
        Me.icoSegnalino.Frozen = True
        Me.icoSegnalino.HeaderText = ""
        Me.icoSegnalino.MinimumWidth = 24
        Me.icoSegnalino.Name = "icoSegnalino"
        Me.icoSegnalino.ReadOnly = True
        Me.icoSegnalino.Width = 24
        '
        'DataGridViewImageColumn5
        '
        Me.DataGridViewImageColumn5.DataPropertyName = "imgAnteprima"
        Me.DataGridViewImageColumn5.Frozen = True
        Me.DataGridViewImageColumn5.HeaderText = ""
        Me.DataGridViewImageColumn5.Name = "DataGridViewImageColumn5"
        Me.DataGridViewImageColumn5.ReadOnly = True
        Me.DataGridViewImageColumn5.Width = 5
        '
        'imgLavorazione
        '
        Me.imgLavorazione.DataPropertyName = "imgLavorazione"
        Me.imgLavorazione.Frozen = True
        Me.imgLavorazione.HeaderText = ""
        Me.imgLavorazione.Name = "imgLavorazione"
        Me.imgLavorazione.ReadOnly = True
        Me.imgLavorazione.Width = 5
        '
        'msg
        '
        Me.msg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.msg.DataPropertyName = "Icomsg"
        Me.msg.Frozen = True
        Me.msg.HeaderText = ""
        Me.msg.Name = "msg"
        Me.msg.ReadOnly = True
        Me.msg.Width = 16
        '
        'P
        '
        Me.P.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.P.DataPropertyName = "Priorita"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.P.DefaultCellStyle = DataGridViewCellStyle3
        Me.P.Frozen = True
        Me.P.HeaderText = "P!"
        Me.P.Name = "P"
        Me.P.ReadOnly = True
        Me.P.Width = 20
        '
        'Ordine
        '
        Me.Ordine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Ordine.DataPropertyName = "IdOrdineStr"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Ordine.DefaultCellStyle = DataGridViewCellStyle4
        Me.Ordine.Frozen = True
        Me.Ordine.HeaderText = "Ordine"
        Me.Ordine.Name = "Ordine"
        Me.Ordine.ReadOnly = True
        Me.Ordine.Width = 55
        '
        'num
        '
        Me.num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.num.DataPropertyName = "IdCommessaStr"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.num.DefaultCellStyle = DataGridViewCellStyle5
        Me.num.Frozen = True
        Me.num.HeaderText = "Commessa"
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        Me.num.Width = 85
        '
        'Data
        '
        Me.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Data.DataPropertyName = "DataRiferimentoStr"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Data.DefaultCellStyle = DataGridViewCellStyle6
        Me.Data.HeaderText = "Consegna"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Width = 84
        '
        'Copie
        '
        Me.Copie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Copie.DataPropertyName = "Copie"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Copie.DefaultCellStyle = DataGridViewCellStyle7
        Me.Copie.HeaderText = "Copie"
        Me.Copie.Name = "Copie"
        Me.Copie.ReadOnly = True
        Me.Copie.Width = 62
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Tipo.DataPropertyName = "Tipo"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle8
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 180
        '
        'RagSoc
        '
        Me.RagSoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.RagSoc.DataPropertyName = "RagSocNome"
        Me.RagSoc.HeaderText = "Cliente"
        Me.RagSoc.Name = "RagSoc"
        Me.RagSoc.ReadOnly = True
        Me.RagSoc.Width = 180
        '
        'Lavorazione
        '
        Me.Lavorazione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Lavorazione.DataPropertyName = "LavorazioneStr"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Lavorazione.DefaultCellStyle = DataGridViewCellStyle9
        Me.Lavorazione.HeaderText = "Lavorazione"
        Me.Lavorazione.Name = "Lavorazione"
        Me.Lavorazione.ReadOnly = True
        Me.Lavorazione.Width = 180
        '
        'NLastre
        '
        Me.NLastre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.NLastre.DataPropertyName = "NLastreStr"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NLastre.DefaultCellStyle = DataGridViewCellStyle10
        Me.NLastre.HeaderText = "N° Lastre"
        Me.NLastre.Name = "NLastre"
        Me.NLastre.ReadOnly = True
        Me.NLastre.Width = 5
        '
        'FR
        '
        Me.FR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FR.DataPropertyName = "FronteRetro"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FR.DefaultCellStyle = DataGridViewCellStyle11
        Me.FR.HeaderText = "F/R"
        Me.FR.Name = "FR"
        Me.FR.ReadOnly = True
        Me.FR.Width = 49
        '
        'Risorsa
        '
        Me.Risorsa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Risorsa.DataPropertyName = "RisorsaStr"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Risorsa.DefaultCellStyle = DataGridViewCellStyle12
        Me.Risorsa.HeaderText = "Risorsa"
        Me.Risorsa.Name = "Risorsa"
        Me.Risorsa.ReadOnly = True
        Me.Risorsa.Width = 150
        '
        'InCarico
        '
        Me.InCarico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.InCarico.DataPropertyName = "InCaricoA"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.InCarico.DefaultCellStyle = DataGridViewCellStyle13
        Me.InCarico.HeaderText = "In Carico a "
        Me.InCarico.Name = "InCarico"
        Me.InCarico.ReadOnly = True
        Me.InCarico.Width = 80
        '
        'mnuLavoro
        '
        Me.mnuLavoro.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ForzaIlLavoroAlloperatoreToolStripMenuItem, Me.ToolStripSeparator1, Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem})
        Me.mnuLavoro.Name = "ContextMenuStrip1"
        Me.mnuLavoro.Size = New System.Drawing.Size(280, 54)
        '
        'ForzaIlLavoroAlloperatoreToolStripMenuItem
        '
        Me.ForzaIlLavoroAlloperatoreToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForzaIlLavoroAlloperatoreToolStripMenuItem.Name = "ForzaIlLavoroAlloperatoreToolStripMenuItem"
        Me.ForzaIlLavoroAlloperatoreToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.ForzaIlLavoroAlloperatoreToolStripMenuItem.Text = "Rendi disponibile il lavoro all'operatore"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(276, 6)
        '
        'ForzaIlLavoroAlMacchinarioToolStripMenuItem
        '
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem.Name = "ForzaIlLavoroAlMacchinarioToolStripMenuItem"
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.ForzaIlLavoroAlMacchinarioToolStripMenuItem.Text = "Forza il lavoro al macchinario"
        '
        'lblNomeUt
        '
        Me.lblNomeUt.BackColor = System.Drawing.Color.Transparent
        Me.lblNomeUt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNomeUt.ForeColor = System.Drawing.Color.Red
        Me.lblNomeUt.Location = New System.Drawing.Point(5, 158)
        Me.lblNomeUt.Name = "lblNomeUt"
        Me.lblNomeUt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNomeUt.Size = New System.Drawing.Size(122, 15)
        Me.lblNomeUt.TabIndex = 107
        Me.lblNomeUt.Text = "-"
        Me.lblNomeUt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.pctHelpFlag)
        Me.GroupBox1.Controls.Add(Me.pctAggiornaPrev)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmbCatProd)
        Me.GroupBox1.Controls.Add(Me.btnPrendiInCarico)
        Me.GroupBox1.Controls.Add(Me.lnkLastWork)
        Me.GroupBox1.Controls.Add(Me.lnkReset)
        Me.GroupBox1.Controls.Add(Me.txtNumOrd)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkSoloProntiDaLavorare)
        Me.GroupBox1.Controls.Add(Me.txtNumCom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(137, -4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 105)
        Me.GroupBox1.TabIndex = 141
        Me.GroupBox1.TabStop = False
        '
        'pctHelpFlag
        '
        Me.pctHelpFlag.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctHelpFlag.Image = Global.Former.My.Resources.Resources.icoLeggenda
        Me.pctHelpFlag.Location = New System.Drawing.Point(605, 14)
        Me.pctHelpFlag.Name = "pctHelpFlag"
        Me.pctHelpFlag.Size = New System.Drawing.Size(26, 26)
        Me.pctHelpFlag.TabIndex = 152
        Me.pctHelpFlag.TabStop = False
        Me.toolTipHelp.SetToolTip(Me.pctHelpFlag, "Legenda Bandierine taglio")
        '
        'pctAggiornaPrev
        '
        Me.pctAggiornaPrev.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.pctAggiornaPrev.Location = New System.Drawing.Point(342, 46)
        Me.pctAggiornaPrev.Name = "pctAggiornaPrev"
        Me.pctAggiornaPrev.Size = New System.Drawing.Size(26, 26)
        Me.pctAggiornaPrev.TabIndex = 151
        Me.pctAggiornaPrev.TabStop = False
        Me.pctAggiornaPrev.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(6, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 15)
        Me.Label11.TabIndex = 149
        Me.Label11.Text = "Preventivazione"
        Me.Label11.Visible = False
        '
        'cmbCatProd
        '
        Me.cmbCatProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCatProd.FormattingEnabled = True
        Me.cmbCatProd.Location = New System.Drawing.Point(102, 49)
        Me.cmbCatProd.Name = "cmbCatProd"
        Me.cmbCatProd.Size = New System.Drawing.Size(234, 23)
        Me.cmbCatProd.TabIndex = 150
        Me.cmbCatProd.Visible = False
        '
        'btnPrendiInCarico
        '
        Me.btnPrendiInCarico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrendiInCarico.BackColor = System.Drawing.Color.White
        Me.btnPrendiInCarico.FlatAppearance.BorderSize = 0
        Me.btnPrendiInCarico.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrendiInCarico.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.btnPrendiInCarico.Image = Global.Former.My.Resources.Resources._PrendiInCarico
        Me.btnPrendiInCarico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrendiInCarico.Location = New System.Drawing.Point(417, 57)
        Me.btnPrendiInCarico.Name = "btnPrendiInCarico"
        Me.btnPrendiInCarico.Size = New System.Drawing.Size(214, 42)
        Me.btnPrendiInCarico.TabIndex = 141
        Me.btnPrendiInCarico.TabStop = False
        Me.btnPrendiInCarico.Text = "PRENDI IN CARICO IL LAVORO"
        Me.btnPrendiInCarico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrendiInCarico.UseVisualStyleBackColor = False
        '
        'lnkLastWork
        '
        Me.lnkLastWork.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkLastWork.Image = Global.Former.My.Resources.Resources._Next
        Me.lnkLastWork.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkLastWork.LinkColor = System.Drawing.Color.Green
        Me.lnkLastWork.Location = New System.Drawing.Point(252, 17)
        Me.lnkLastWork.Name = "lnkLastWork"
        Me.lnkLastWork.Padding = New System.Windows.Forms.Padding(30, 0, 0, 0)
        Me.lnkLastWork.Size = New System.Drawing.Size(116, 19)
        Me.lnkLastWork.TabIndex = 148
        Me.lnkLastWork.TabStop = True
        Me.lnkLastWork.Text = "-"
        '
        'pctOperatore
        '
        Me.pctOperatore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctOperatore.Location = New System.Drawing.Point(2, 48)
        Me.pctOperatore.Name = "pctOperatore"
        Me.pctOperatore.Size = New System.Drawing.Size(128, 128)
        Me.pctOperatore.TabIndex = 106
        Me.pctOperatore.TabStop = False
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiorna.Location = New System.Drawing.Point(3, 3)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(128, 42)
        Me.btnAggiorna.TabIndex = 140
        Me.btnAggiorna.Text = "Aggiorna"
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'ucOperatoreProduzione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblNomeUt)
        Me.Controls.Add(Me.pctOperatore)
        Me.Controls.Add(Me.DgLavori)
        Me.Controls.Add(Me.lblMacchinario)
        Me.Controls.Add(Me.lblMacchinarioIs)
        Me.Controls.Add(Me.FlowMacchinari)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Name = "ucOperatoreProduzione"
        Me.Size = New System.Drawing.Size(777, 700)
        CType(Me.DgLavori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuLavoro.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctHelpFlag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctAggiornaPrev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctOperatore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FlowMacchinari As FlowLayoutPanel
    Friend WithEvents lblMacchinarioIs As Label
    Friend WithEvents btnAggiorna As Button
    Friend WithEvents btnPrendiInCarico As Button
    Friend WithEvents lblMacchinario As Label
    Friend WithEvents chkSoloProntiDaLavorare As CheckBox
    Friend WithEvents DgLavori As DataGridView
    Friend WithEvents mnuLavoro As ContextMenuStrip
    Friend WithEvents ForzaIlLavoroAlloperatoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ForzaIlLavoroAlMacchinarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtNumOrd As ucNumericTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNumCom As ucNumericTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lnkReset As LinkLabel
    Friend WithEvents pctOperatore As PictureBox
    Friend WithEvents lblNomeUt As Label
    Friend WithEvents lnkLastWork As LinkLabel
    Friend WithEvents icoSegnalino As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn5 As DataGridViewImageColumn
    Friend WithEvents imgLavorazione As DataGridViewImageColumn
    Friend WithEvents msg As DataGridViewImageColumn
    Friend WithEvents P As DataGridViewTextBoxColumn
    Friend WithEvents Ordine As DataGridViewTextBoxColumn
    Friend WithEvents num As DataGridViewTextBoxColumn
    Friend WithEvents Data As DataGridViewTextBoxColumn
    Friend WithEvents Copie As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
    Friend WithEvents RagSoc As DataGridViewTextBoxColumn
    Friend WithEvents Lavorazione As DataGridViewTextBoxColumn
    Friend WithEvents NLastre As DataGridViewTextBoxColumn
    Friend WithEvents FR As DataGridViewTextBoxColumn
    Friend WithEvents Risorsa As DataGridViewTextBoxColumn
    Friend WithEvents InCarico As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbCatProd As ComboBox
    Friend WithEvents pctAggiornaPrev As PictureBox
    Friend WithEvents pctHelpFlag As PictureBox
End Class
