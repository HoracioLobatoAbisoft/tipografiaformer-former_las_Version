<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucListinoGruppoVariante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucListinoGruppoVariante))
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
        Me.imlPuls = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnkDelFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkAddFormato = New System.Windows.Forms.LinkLabel()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.grpColoreStampa = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtVarPercCS = New Former.ucNumericTextBox()
        Me.lblVar = New System.Windows.Forms.Label()
        Me.lblSecondoColore = New System.Windows.Forms.Label()
        Me.chkSecondoColore = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.dgTipologie = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipologia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostoCarta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AltezzaMicron = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoCarta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RisorseAssociate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercVar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstLav = New System.Windows.Forms.ListBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lnkAggiornaLav = New System.Windows.Forms.LinkLabel()
        Me.lnkAddLav = New System.Windows.Forms.LinkLabel()
        Me.lnkDelLav = New System.Windows.Forms.LinkLabel()
        Me.lnkModifPerc = New System.Windows.Forms.LinkLabel()
        Me.grpColoreStampa.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTipologie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imlPuls
        '
        Me.imlPuls.ImageStream = CType(resources.GetObject("imlPuls.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlPuls.TransparentColor = System.Drawing.Color.Transparent
        Me.imlPuls.Images.SetKeyName(0, "_Aggiungi.png")
        Me.imlPuls.Images.SetKeyName(1, "_Modifica.png")
        Me.imlPuls.Images.SetKeyName(2, "_Elimina.png")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(2)
        Me.Label4.Size = New System.Drawing.Size(74, 25)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Varianti"
        '
        'lnkDelFormato
        '
        Me.lnkDelFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDelFormato.AutoSize = True
        Me.lnkDelFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelFormato.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDelFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelFormato.Location = New System.Drawing.Point(818, 19)
        Me.lnkDelFormato.Name = "lnkDelFormato"
        Me.lnkDelFormato.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDelFormato.Size = New System.Drawing.Size(81, 27)
        Me.lnkDelFormato.TabIndex = 87
        Me.lnkDelFormato.TabStop = True
        Me.lnkDelFormato.Text = "Rimuovi"
        Me.lnkDelFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAddFormato
        '
        Me.lnkAddFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAddFormato.AutoSize = True
        Me.lnkAddFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAddFormato.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAddFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAddFormato.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAddFormato.Location = New System.Drawing.Point(623, 19)
        Me.lnkAddFormato.Name = "lnkAddFormato"
        Me.lnkAddFormato.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAddFormato.Size = New System.Drawing.Size(86, 27)
        Me.lnkAddFormato.TabIndex = 86
        Me.lnkAddFormato.TabStop = True
        Me.lnkAddFormato.Text = "Aggiungi"
        Me.lnkAddFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiorna.AutoSize = True
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(905, 19)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAggiorna.Size = New System.Drawing.Size(86, 27)
        Me.lnkAggiorna.TabIndex = 107
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpColoreStampa
        '
        Me.grpColoreStampa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpColoreStampa.Controls.Add(Me.PictureBox1)
        Me.grpColoreStampa.Controls.Add(Me.txtVarPercCS)
        Me.grpColoreStampa.Controls.Add(Me.lblVar)
        Me.grpColoreStampa.Controls.Add(Me.lblSecondoColore)
        Me.grpColoreStampa.Controls.Add(Me.chkSecondoColore)
        Me.grpColoreStampa.Location = New System.Drawing.Point(4, 34)
        Me.grpColoreStampa.Name = "grpColoreStampa"
        Me.grpColoreStampa.Size = New System.Drawing.Size(997, 52)
        Me.grpColoreStampa.TabIndex = 108
        Me.grpColoreStampa.TabStop = False
        Me.grpColoreStampa.Text = "Colori di stampa"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._ColoreStampa
        Me.PictureBox1.Location = New System.Drawing.Point(6, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'txtVarPercCS
        '
        Me.txtVarPercCS.Location = New System.Drawing.Point(630, 20)
        Me.txtVarPercCS.MaxLength = 3
        Me.txtVarPercCS.My_AccettaNegativi = False
        Me.txtVarPercCS.My_AllowOnlyInteger = True
        Me.txtVarPercCS.My_DefaultValue = 0
        Me.txtVarPercCS.My_MaxValue = 100.0!
        Me.txtVarPercCS.My_MinValue = 0!
        Me.txtVarPercCS.My_ReplaceWithDefaultValue = True
        Me.txtVarPercCS.Name = "txtVarPercCS"
        Me.txtVarPercCS.Size = New System.Drawing.Size(82, 23)
        Me.txtVarPercCS.TabIndex = 4
        Me.txtVarPercCS.Text = "0"
        Me.txtVarPercCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVar
        '
        Me.lblVar.AutoSize = True
        Me.lblVar.Location = New System.Drawing.Point(520, 24)
        Me.lblVar.Name = "lblVar"
        Me.lblVar.Size = New System.Drawing.Size(104, 15)
        Me.lblVar.TabIndex = 3
        Me.lblVar.Text = "Diminuzione % CS"
        '
        'lblSecondoColore
        '
        Me.lblSecondoColore.AutoSize = True
        Me.lblSecondoColore.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSecondoColore.Location = New System.Drawing.Point(241, 23)
        Me.lblSecondoColore.Name = "lblSecondoColore"
        Me.lblSecondoColore.Size = New System.Drawing.Size(108, 15)
        Me.lblSecondoColore.TabIndex = 1
        Me.lblSecondoColore.Text = "SECONDOCOLORE"
        '
        'chkSecondoColore
        '
        Me.chkSecondoColore.AutoSize = True
        Me.chkSecondoColore.Location = New System.Drawing.Point(36, 22)
        Me.chkSecondoColore.Name = "chkSecondoColore"
        Me.chkSecondoColore.Size = New System.Drawing.Size(199, 19)
        Me.chkSecondoColore.TabIndex = 0
        Me.chkSecondoColore.Text = "Abilita secondo colore di stampa"
        Me.chkSecondoColore.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lnkModifPerc)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.dgTipologie)
        Me.GroupBox1.Controls.Add(Me.lnkAggiorna)
        Me.GroupBox1.Controls.Add(Me.lnkAddFormato)
        Me.GroupBox1.Controls.Add(Me.lnkDelFormato)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(997, 284)
        Me.GroupBox1.TabIndex = 109
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Carta"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources._TipoCarta
        Me.PictureBox2.Location = New System.Drawing.Point(6, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox2.TabIndex = 109
        Me.PictureBox2.TabStop = False
        '
        'dgTipologie
        '
        Me.dgTipologie.AllowUserToAddRows = False
        Me.dgTipologie.AllowUserToDeleteRows = False
        Me.dgTipologie.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgTipologie.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTipologie.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTipologie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgTipologie.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgTipologie.BackgroundColor = System.Drawing.Color.White
        Me.dgTipologie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgTipologie.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTipologie.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgTipologie.ColumnHeadersHeight = 20
        Me.dgTipologie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgTipologie.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn2, Me.DataGridViewTextBoxColumn1, Me.Tipologia, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.CostoCarta, Me.AltezzaMicron, Me.TipoCarta, Me.RisorseAssociate, Me.PercVar})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTipologie.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgTipologie.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgTipologie.EnableHeadersVisualStyles = False
        Me.dgTipologie.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgTipologie.Location = New System.Drawing.Point(6, 49)
        Me.dgTipologie.MultiSelect = False
        Me.dgTipologie.Name = "dgTipologie"
        Me.dgTipologie.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTipologie.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgTipologie.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.dgTipologie.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgTipologie.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgTipologie.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgTipologie.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgTipologie.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTipologie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTipologie.Size = New System.Drawing.Size(985, 229)
        Me.dgTipologie.TabIndex = 108
        Me.dgTipologie.TabStop = False
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.DataPropertyName = "Img"
        Me.DataGridViewImageColumn2.HeaderText = "Img"
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.Width = 33
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Sigla"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Sigla"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 56
        '
        'Tipologia
        '
        Me.Tipologia.DataPropertyName = "Tipologia"
        Me.Tipologia.HeaderText = "Tipologia"
        Me.Tipologia.Name = "Tipologia"
        Me.Tipologia.ReadOnly = True
        Me.Tipologia.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Finitura"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Finitura"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 71
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Grammi"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn4.HeaderText = "Grammi"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 74
        '
        'CostoCarta
        '
        Me.CostoCarta.DataPropertyName = "CostoCartaKg"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CostoCarta.DefaultCellStyle = DataGridViewCellStyle4
        Me.CostoCarta.HeaderText = "Prezzo/kg"
        Me.CostoCarta.Name = "CostoCarta"
        Me.CostoCarta.ReadOnly = True
        Me.CostoCarta.Width = 83
        '
        'AltezzaMicron
        '
        Me.AltezzaMicron.DataPropertyName = "Spessore"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.AltezzaMicron.DefaultCellStyle = DataGridViewCellStyle5
        Me.AltezzaMicron.HeaderText = "Altezza Micron"
        Me.AltezzaMicron.Name = "AltezzaMicron"
        Me.AltezzaMicron.ReadOnly = True
        Me.AltezzaMicron.Width = 109
        '
        'TipoCarta
        '
        Me.TipoCarta.DataPropertyName = "TipoCartaStr"
        Me.TipoCarta.HeaderText = "Tipo Carta"
        Me.TipoCarta.Name = "TipoCarta"
        Me.TipoCarta.ReadOnly = True
        Me.TipoCarta.Width = 85
        '
        'RisorseAssociate
        '
        Me.RisorseAssociate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.RisorseAssociate.DataPropertyName = "RisorseAssociateStr"
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RisorseAssociate.DefaultCellStyle = DataGridViewCellStyle6
        Me.RisorseAssociate.HeaderText = "Risorse Associate"
        Me.RisorseAssociate.Name = "RisorseAssociate"
        Me.RisorseAssociate.ReadOnly = True
        Me.RisorseAssociate.Width = 300
        '
        'PercVar
        '
        Me.PercVar.DataPropertyName = "PercVariazioneSuVariante"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PercVar.DefaultCellStyle = DataGridViewCellStyle7
        Me.PercVar.HeaderText = "% Variazione"
        Me.PercVar.Name = "PercVar"
        Me.PercVar.ReadOnly = True
        Me.PercVar.Width = 97
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lstLav)
        Me.GroupBox2.Controls.Add(Me.PictureBox3)
        Me.GroupBox2.Controls.Add(Me.lnkAggiornaLav)
        Me.GroupBox2.Controls.Add(Me.lnkAddLav)
        Me.GroupBox2.Controls.Add(Me.lnkDelLav)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 383)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(997, 352)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Categoria Lavorazioni"
        '
        'lstLav
        '
        Me.lstLav.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstLav.FormattingEnabled = True
        Me.lstLav.ItemHeight = 15
        Me.lstLav.Location = New System.Drawing.Point(6, 52)
        Me.lstLav.Name = "lstLav"
        Me.lstLav.Size = New System.Drawing.Size(985, 289)
        Me.lstLav.TabIndex = 115
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Former.My.Resources.Resources._CategoriaLavorazioni
        Me.PictureBox3.Location = New System.Drawing.Point(6, 22)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.TabIndex = 114
        Me.PictureBox3.TabStop = False
        '
        'lnkAggiornaLav
        '
        Me.lnkAggiornaLav.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiornaLav.AutoSize = True
        Me.lnkAggiornaLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiornaLav.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiornaLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiornaLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiornaLav.Location = New System.Drawing.Point(905, 22)
        Me.lnkAggiornaLav.Name = "lnkAggiornaLav"
        Me.lnkAggiornaLav.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAggiornaLav.Size = New System.Drawing.Size(86, 27)
        Me.lnkAggiornaLav.TabIndex = 113
        Me.lnkAggiornaLav.TabStop = True
        Me.lnkAggiornaLav.Text = "Aggiorna"
        Me.lnkAggiornaLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAddLav
        '
        Me.lnkAddLav.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAddLav.AutoSize = True
        Me.lnkAddLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAddLav.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkAddLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAddLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAddLav.Location = New System.Drawing.Point(726, 22)
        Me.lnkAddLav.Name = "lnkAddLav"
        Me.lnkAddLav.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkAddLav.Size = New System.Drawing.Size(86, 27)
        Me.lnkAddLav.TabIndex = 110
        Me.lnkAddLav.TabStop = True
        Me.lnkAddLav.Text = "Aggiungi"
        Me.lnkAddLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDelLav
        '
        Me.lnkDelLav.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDelLav.AutoSize = True
        Me.lnkDelLav.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelLav.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDelLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelLav.Location = New System.Drawing.Point(818, 22)
        Me.lnkDelLav.Name = "lnkDelLav"
        Me.lnkDelLav.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkDelLav.Size = New System.Drawing.Size(81, 27)
        Me.lnkDelLav.TabIndex = 111
        Me.lnkDelLav.TabStop = True
        Me.lnkDelLav.Text = "Rimuovi"
        Me.lnkDelLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkModifPerc
        '
        Me.lnkModifPerc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkModifPerc.AutoSize = True
        Me.lnkModifPerc.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModifPerc.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkModifPerc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModifPerc.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModifPerc.Location = New System.Drawing.Point(715, 19)
        Me.lnkModifPerc.Name = "lnkModifPerc"
        Me.lnkModifPerc.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkModifPerc.Size = New System.Drawing.Size(97, 27)
        Me.lnkModifPerc.TabIndex = 110
        Me.lnkModifPerc.TabStop = True
        Me.lnkModifPerc.Text = "Modifica %"
        Me.lnkModifPerc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucListinoGruppoVariante
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpColoreStampa)
        Me.Controls.Add(Me.Label4)
        Me.Name = "ucListinoGruppoVariante"
        Me.Size = New System.Drawing.Size(1004, 738)
        Me.grpColoreStampa.ResumeLayout(False)
        Me.grpColoreStampa.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTipologie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imlPuls As System.Windows.Forms.ImageList
    Friend WithEvents lnkDelFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAddFormato As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lnkAggiorna As LinkLabel
    Friend WithEvents grpColoreStampa As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtVarPercCS As ucNumericTextBox
    Friend WithEvents lblVar As Label
    Friend WithEvents lblSecondoColore As Label
    Friend WithEvents chkSecondoColore As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents dgTipologie As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lnkAggiornaLav As LinkLabel
    Friend WithEvents lnkAddLav As LinkLabel
    Friend WithEvents lnkDelLav As LinkLabel
    Friend WithEvents lstLav As ListBox
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Tipologia As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents CostoCarta As DataGridViewTextBoxColumn
    Friend WithEvents AltezzaMicron As DataGridViewTextBoxColumn
    Friend WithEvents TipoCarta As DataGridViewTextBoxColumn
    Friend WithEvents RisorseAssociate As DataGridViewTextBoxColumn
    Friend WithEvents PercVar As DataGridViewTextBoxColumn
    Friend WithEvents lnkModifPerc As LinkLabel
End Class
