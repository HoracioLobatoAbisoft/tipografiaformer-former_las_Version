<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConsegneGlsAdmin
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgConsegne = New System.Windows.Forms.DataGridView()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodTrack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Corriere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Indirizzo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pagamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImportoContrassegno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.UcComboCliente = New Former.ucComboRubrica()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodInterno = New System.Windows.Forms.TextBox()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbStatoConsegna = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodTracking = New System.Windows.Forms.TextBox()
        Me.lblClienti = New System.Windows.Forms.Label()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.btnGestCons = New System.Windows.Forms.Button()
        Me.btnTracking = New System.Windows.Forms.Button()
        Me.btnStampaEtichCorr = New System.Windows.Forms.Button()
        Me.btnDelRegistraz = New System.Windows.Forms.Button()
        Me.btnResoconto = New System.Windows.Forms.Button()
        CType(Me.DgConsegne, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgConsegne
        '
        Me.DgConsegne.AllowUserToAddRows = False
        Me.DgConsegne.AllowUserToDeleteRows = False
        Me.DgConsegne.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgConsegne.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgConsegne.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgConsegne.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgConsegne.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgConsegne.BackgroundColor = System.Drawing.Color.White
        Me.DgConsegne.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgConsegne.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgConsegne.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgConsegne.ColumnHeadersHeight = 20
        Me.DgConsegne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgConsegne.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Data, Me.CodTrack, Me.Corriere, Me.Cliente, Me.Indirizzo, Me.Stato, Me.Colli, Me.Peso, Me.Pagamento, Me.ImportoContrassegno})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgConsegne.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgConsegne.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgConsegne.EnableHeadersVisualStyles = False
        Me.DgConsegne.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgConsegne.Location = New System.Drawing.Point(3, 132)
        Me.DgConsegne.MultiSelect = False
        Me.DgConsegne.Name = "DgConsegne"
        Me.DgConsegne.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgConsegne.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgConsegne.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgConsegne.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgConsegne.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgConsegne.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgConsegne.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgConsegne.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgConsegne.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgConsegne.Size = New System.Drawing.Size(1204, 533)
        Me.DgConsegne.TabIndex = 59
        Me.DgConsegne.TabStop = False
        '
        'Data
        '
        Me.Data.DataPropertyName = "Giorno"
        Me.Data.HeaderText = "Data Cons. al Corriere"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Width = 145
        '
        'CodTrack
        '
        Me.CodTrack.DataPropertyName = "CodTrack"
        Me.CodTrack.HeaderText = "Cod.Track"
        Me.CodTrack.Name = "CodTrack"
        Me.CodTrack.ReadOnly = True
        Me.CodTrack.Width = 84
        '
        'Corriere
        '
        Me.Corriere.DataPropertyName = "CorriereNome"
        Me.Corriere.HeaderText = "Corriere"
        Me.Corriere.Name = "Corriere"
        Me.Corriere.ReadOnly = True
        Me.Corriere.Width = 73
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "RagSoc"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 68
        '
        'Indirizzo
        '
        Me.Indirizzo.DataPropertyName = "IndirizzoRiassunto"
        Me.Indirizzo.HeaderText = "Indirizzo"
        Me.Indirizzo.Name = "Indirizzo"
        Me.Indirizzo.ReadOnly = True
        Me.Indirizzo.Width = 75
        '
        'Stato
        '
        Me.Stato.DataPropertyName = "StatoStr"
        Me.Stato.HeaderText = "Stato"
        Me.Stato.Name = "Stato"
        Me.Stato.ReadOnly = True
        Me.Stato.Width = 58
        '
        'Colli
        '
        Me.Colli.DataPropertyName = "NumColli"
        Me.Colli.HeaderText = "Colli"
        Me.Colli.Name = "Colli"
        Me.Colli.ReadOnly = True
        Me.Colli.Width = 55
        '
        'Peso
        '
        Me.Peso.DataPropertyName = "Peso"
        Me.Peso.HeaderText = "Peso"
        Me.Peso.Name = "Peso"
        Me.Peso.ReadOnly = True
        Me.Peso.Width = 56
        '
        'Pagamento
        '
        Me.Pagamento.DataPropertyName = "PagamentoStr"
        Me.Pagamento.HeaderText = "Pagamento"
        Me.Pagamento.Name = "Pagamento"
        Me.Pagamento.ReadOnly = True
        Me.Pagamento.Width = 92
        '
        'ImportoContrassegno
        '
        Me.ImportoContrassegno.DataPropertyName = "ImpContrassegnoStr"
        Me.ImportoContrassegno.HeaderText = "Importo Contrassegno"
        Me.ImportoContrassegno.Name = "ImportoContrassegno"
        Me.ImportoContrassegno.ReadOnly = True
        Me.ImportoContrassegno.Width = 150
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.UcComboCliente)
        Me.GroupBox1.Controls.Add(Me.pctTipo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCodInterno)
        Me.GroupBox1.Controls.Add(Me.cmbPeriodo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbStatoConsegna)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCodTracking)
        Me.GroupBox1.Controls.Add(Me.lblClienti)
        Me.GroupBox1.Controls.Add(Me.lnkCerca)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1204, 79)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        '
        'UcComboCliente
        '
        Me.UcComboCliente.BackColor = System.Drawing.Color.White
        Me.UcComboCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcComboCliente.IdRubSelezionato = 0
        Me.UcComboCliente.Location = New System.Drawing.Point(266, 14)
        Me.UcComboCliente.Name = "UcComboCliente"
        Me.UcComboCliente.Size = New System.Drawing.Size(501, 25)
        Me.UcComboCliente.TabIndex = 107
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.logo_gls
        Me.pctTipo.Location = New System.Drawing.Point(6, 15)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(181, 56)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctTipo.TabIndex = 106
        Me.pctTipo.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(513, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 15)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Id Interno Consegna"
        '
        'txtCodInterno
        '
        Me.txtCodInterno.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCodInterno.Location = New System.Drawing.Point(638, 45)
        Me.txtCodInterno.Name = "txtCodInterno"
        Me.txtCodInterno.Size = New System.Drawing.Size(129, 23)
        Me.txtCodInterno.TabIndex = 104
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Location = New System.Drawing.Point(266, 45)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(241, 23)
        Me.cmbPeriodo.TabIndex = 103
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(214, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Periodo"
        '
        'cmbStatoConsegna
        '
        Me.cmbStatoConsegna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatoConsegna.FormattingEnabled = True
        Me.cmbStatoConsegna.Location = New System.Drawing.Point(875, 45)
        Me.cmbStatoConsegna.Name = "cmbStatoConsegna"
        Me.cmbStatoConsegna.Size = New System.Drawing.Size(164, 23)
        Me.cmbStatoConsegna.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(773, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 15)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Stato Consegna"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(773, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 15)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Codice Tracking"
        '
        'txtCodTracking
        '
        Me.txtCodTracking.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCodTracking.Location = New System.Drawing.Point(875, 18)
        Me.txtCodTracking.Name = "txtCodTracking"
        Me.txtCodTracking.Size = New System.Drawing.Size(164, 23)
        Me.txtCodTracking.TabIndex = 98
        '
        'lblClienti
        '
        Me.lblClienti.AutoSize = True
        Me.lblClienti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblClienti.ForeColor = System.Drawing.Color.Black
        Me.lblClienti.Location = New System.Drawing.Point(214, 21)
        Me.lblClienti.Name = "lblClienti"
        Me.lblClienti.Size = New System.Drawing.Size(44, 15)
        Me.lblClienti.TabIndex = 96
        Me.lblClienti.Text = "Cliente"
        '
        'lnkCerca
        '
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(1080, 29)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(71, 27)
        Me.lnkCerca.TabIndex = 55
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Cerca"
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGestCons
        '
        Me.btnGestCons.BackColor = System.Drawing.Color.White
        Me.btnGestCons.Image = Global.Former.My.Resources.Resources._Consegna
        Me.btnGestCons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGestCons.Location = New System.Drawing.Point(9, 88)
        Me.btnGestCons.Name = "btnGestCons"
        Me.btnGestCons.Size = New System.Drawing.Size(166, 38)
        Me.btnGestCons.TabIndex = 116
        Me.btnGestCons.Text = "Gestisci Consegna"
        Me.btnGestCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGestCons.UseVisualStyleBackColor = False
        '
        'btnTracking
        '
        Me.btnTracking.BackColor = System.Drawing.Color.White
        Me.btnTracking.Image = Global.Former.My.Resources.Resources._Corriere
        Me.btnTracking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTracking.Location = New System.Drawing.Point(181, 88)
        Me.btnTracking.Name = "btnTracking"
        Me.btnTracking.Size = New System.Drawing.Size(166, 38)
        Me.btnTracking.TabIndex = 117
        Me.btnTracking.Text = "Tracking Consegna"
        Me.btnTracking.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTracking.UseVisualStyleBackColor = False
        '
        'btnStampaEtichCorr
        '
        Me.btnStampaEtichCorr.BackColor = System.Drawing.Color.White
        Me.btnStampaEtichCorr.Image = Global.Former.My.Resources.Resources._Etichetta
        Me.btnStampaEtichCorr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampaEtichCorr.Location = New System.Drawing.Point(353, 88)
        Me.btnStampaEtichCorr.Name = "btnStampaEtichCorr"
        Me.btnStampaEtichCorr.Size = New System.Drawing.Size(166, 38)
        Me.btnStampaEtichCorr.TabIndex = 118
        Me.btnStampaEtichCorr.Text = "Ristampa Etich. GLS"
        Me.btnStampaEtichCorr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStampaEtichCorr.UseVisualStyleBackColor = False
        '
        'btnDelRegistraz
        '
        Me.btnDelRegistraz.BackColor = System.Drawing.Color.White
        Me.btnDelRegistraz.Image = Global.Former.My.Resources.Resources._Elimina
        Me.btnDelRegistraz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelRegistraz.Location = New System.Drawing.Point(525, 88)
        Me.btnDelRegistraz.Name = "btnDelRegistraz"
        Me.btnDelRegistraz.Size = New System.Drawing.Size(166, 38)
        Me.btnDelRegistraz.TabIndex = 119
        Me.btnDelRegistraz.Text = "Elimina Registraz."
        Me.btnDelRegistraz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelRegistraz.UseVisualStyleBackColor = False
        '
        'btnResoconto
        '
        Me.btnResoconto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResoconto.BackColor = System.Drawing.Color.White
        Me.btnResoconto.Image = Global.Former.My.Resources.Resources._pdf
        Me.btnResoconto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResoconto.Location = New System.Drawing.Point(1041, 88)
        Me.btnResoconto.Name = "btnResoconto"
        Me.btnResoconto.Size = New System.Drawing.Size(166, 38)
        Me.btnResoconto.TabIndex = 120
        Me.btnResoconto.Text = "Resoconto Contrass."
        Me.btnResoconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnResoconto.UseVisualStyleBackColor = False
        '
        'ucConsegneGlsAdmin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btnResoconto)
        Me.Controls.Add(Me.btnDelRegistraz)
        Me.Controls.Add(Me.btnStampaEtichCorr)
        Me.Controls.Add(Me.btnTracking)
        Me.Controls.Add(Me.btnGestCons)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DgConsegne)
        Me.Name = "ucConsegneGlsAdmin"
        Me.Size = New System.Drawing.Size(1210, 668)
        CType(Me.DgConsegne, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgConsegne As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lnkCerca As System.Windows.Forms.LinkLabel
    Friend WithEvents lblClienti As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCodTracking As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodInterno As System.Windows.Forms.TextBox
    Friend WithEvents cmbPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbStatoConsegna As System.Windows.Forms.ComboBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents btnGestCons As System.Windows.Forms.Button
    Friend WithEvents btnTracking As System.Windows.Forms.Button
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodTrack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Corriere As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Indirizzo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Peso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pagamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImportoContrassegno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnStampaEtichCorr As System.Windows.Forms.Button
    Friend WithEvents btnDelRegistraz As Button
    Friend WithEvents UcComboCliente As ucComboRubrica
    Friend WithEvents btnResoconto As Button
End Class
