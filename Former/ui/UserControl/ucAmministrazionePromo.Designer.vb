<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazionePromo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgPromo = New System.Windows.Forms.DataGridView()
        Me.IcoTipo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Prodotto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Percentuale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValidoAl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScadeTra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Automatico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.lnkRefresh = New System.Windows.Forms.LinkLabel()
        Me.lnkDel = New System.Windows.Forms.LinkLabel()
        Me.lnkEdit = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCountPromo = New System.Windows.Forms.Label()
        Me.TabPromo = New System.Windows.Forms.TabControl()
        Me.tpPromoAttivi = New System.Windows.Forms.TabPage()
        Me.lnkTrasforma = New System.Windows.Forms.LinkLabel()
        Me.lnkDeleteAll = New System.Windows.Forms.LinkLabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lnkNewPromoAuto = New System.Windows.Forms.LinkLabel()
        Me.dgPromoAuto = New System.Windows.Forms.DataGridView()
        Me.cmbMeseRif = New System.Windows.Forms.ComboBox()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LimiteSuFatturato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FatturatoMensile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FatturatoPromo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercFatturatoPromo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatoPromo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pubblicato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Views = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgPromo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabPromo.SuspendLayout()
        Me.tpPromoAttivi.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgPromoAuto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgPromo
        '
        Me.DgPromo.AllowUserToAddRows = False
        Me.DgPromo.AllowUserToDeleteRows = False
        Me.DgPromo.AllowUserToOrderColumns = True
        Me.DgPromo.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgPromo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgPromo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgPromo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.DgPromo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgPromo.BackgroundColor = System.Drawing.Color.White
        Me.DgPromo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgPromo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgPromo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgPromo.ColumnHeadersHeight = 20
        Me.DgPromo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgPromo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IcoTipo, Me.Prodotto, Me.Percentuale, Me.ValidoAl, Me.Stato, Me.ScadeTra, Me.Automatico})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgPromo.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgPromo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgPromo.EnableHeadersVisualStyles = False
        Me.DgPromo.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgPromo.Location = New System.Drawing.Point(3, 33)
        Me.DgPromo.MultiSelect = False
        Me.DgPromo.Name = "DgPromo"
        Me.DgPromo.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgPromo.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgPromo.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgPromo.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgPromo.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgPromo.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgPromo.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgPromo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgPromo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgPromo.Size = New System.Drawing.Size(1115, 502)
        Me.DgPromo.TabIndex = 49
        Me.DgPromo.TabStop = False
        '
        'IcoTipo
        '
        Me.IcoTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IcoTipo.DataPropertyName = "ImgRif"
        Me.IcoTipo.HeaderText = ""
        Me.IcoTipo.Name = "IcoTipo"
        Me.IcoTipo.ReadOnly = True
        Me.IcoTipo.Width = 48
        '
        'Prodotto
        '
        Me.Prodotto.DataPropertyName = "ListinoBaseStr"
        Me.Prodotto.HeaderText = "Listino Base"
        Me.Prodotto.MinimumWidth = 100
        Me.Prodotto.Name = "Prodotto"
        Me.Prodotto.ReadOnly = True
        '
        'Percentuale
        '
        Me.Percentuale.DataPropertyName = "Percentuale"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Percentuale.DefaultCellStyle = DataGridViewCellStyle3
        Me.Percentuale.HeaderText = "Percentuale"
        Me.Percentuale.MinimumWidth = 100
        Me.Percentuale.Name = "Percentuale"
        Me.Percentuale.ReadOnly = True
        '
        'ValidoAl
        '
        Me.ValidoAl.DataPropertyName = "DataFineValiditaStr"
        Me.ValidoAl.HeaderText = "Valido Fino"
        Me.ValidoAl.MinimumWidth = 100
        Me.ValidoAl.Name = "ValidoAl"
        Me.ValidoAl.ReadOnly = True
        '
        'Stato
        '
        Me.Stato.DataPropertyName = "StatoStr"
        Me.Stato.HeaderText = "Stato"
        Me.Stato.MinimumWidth = 100
        Me.Stato.Name = "Stato"
        Me.Stato.ReadOnly = True
        '
        'ScadeTra
        '
        Me.ScadeTra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ScadeTra.DataPropertyName = "ScadeTraStr"
        Me.ScadeTra.HeaderText = "Scade tra"
        Me.ScadeTra.Name = "ScadeTra"
        Me.ScadeTra.ReadOnly = True
        Me.ScadeTra.Width = 79
        '
        'Automatico
        '
        Me.Automatico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Automatico.DataPropertyName = "AutomaticoStr"
        Me.Automatico.HeaderText = "Automatico"
        Me.Automatico.Name = "Automatico"
        Me.Automatico.ReadOnly = True
        Me.Automatico.Width = 80
        '
        'lnkNew
        '
        Me.lnkNew.AutoSize = True
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(91, 3)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkNew.Size = New System.Drawing.Size(108, 27)
        Me.lnkNew.TabIndex = 55
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo Promo"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkRefresh
        '
        Me.lnkRefresh.AutoSize = True
        Me.lnkRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRefresh.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRefresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRefresh.Location = New System.Drawing.Point(3, 3)
        Me.lnkRefresh.Name = "lnkRefresh"
        Me.lnkRefresh.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkRefresh.Size = New System.Drawing.Size(82, 27)
        Me.lnkRefresh.TabIndex = 55
        Me.lnkRefresh.TabStop = True
        Me.lnkRefresh.Text = "Aggiorna"
        Me.lnkRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDel
        '
        Me.lnkDel.AutoSize = True
        Me.lnkDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDel.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDel.Location = New System.Drawing.Point(291, 3)
        Me.lnkDel.Name = "lnkDel"
        Me.lnkDel.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkDel.Size = New System.Drawing.Size(72, 27)
        Me.lnkDel.TabIndex = 79
        Me.lnkDel.TabStop = True
        Me.lnkDel.Text = "Elimina"
        Me.lnkDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkEdit
        '
        Me.lnkEdit.AutoSize = True
        Me.lnkEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkEdit.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkEdit.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkEdit.Location = New System.Drawing.Point(205, 3)
        Me.lnkEdit.Name = "lnkEdit"
        Me.lnkEdit.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkEdit.Size = New System.Drawing.Size(80, 27)
        Me.lnkEdit.TabIndex = 80
        Me.lnkEdit.TabStop = True
        Me.lnkEdit.Text = "Modifica"
        Me.lnkEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 15)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "PROMO attivi al momento"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lblCountPromo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(905, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(213, 27)
        Me.Panel1.TabIndex = 82
        '
        'lblCountPromo
        '
        Me.lblCountPromo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCountPromo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCountPromo.Location = New System.Drawing.Point(159, 0)
        Me.lblCountPromo.Name = "lblCountPromo"
        Me.lblCountPromo.Size = New System.Drawing.Size(51, 27)
        Me.lblCountPromo.TabIndex = 82
        Me.lblCountPromo.Text = "-"
        Me.lblCountPromo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPromo
        '
        Me.TabPromo.Controls.Add(Me.tpPromoAttivi)
        Me.TabPromo.Controls.Add(Me.TabPage2)
        Me.TabPromo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPromo.Location = New System.Drawing.Point(0, 0)
        Me.TabPromo.Name = "TabPromo"
        Me.TabPromo.SelectedIndex = 0
        Me.TabPromo.Size = New System.Drawing.Size(1129, 566)
        Me.TabPromo.TabIndex = 83
        '
        'tpPromoAttivi
        '
        Me.tpPromoAttivi.Controls.Add(Me.lnkTrasforma)
        Me.tpPromoAttivi.Controls.Add(Me.lnkDeleteAll)
        Me.tpPromoAttivi.Controls.Add(Me.lnkRefresh)
        Me.tpPromoAttivi.Controls.Add(Me.Panel1)
        Me.tpPromoAttivi.Controls.Add(Me.DgPromo)
        Me.tpPromoAttivi.Controls.Add(Me.lnkEdit)
        Me.tpPromoAttivi.Controls.Add(Me.lnkNew)
        Me.tpPromoAttivi.Controls.Add(Me.lnkDel)
        Me.tpPromoAttivi.Location = New System.Drawing.Point(4, 24)
        Me.tpPromoAttivi.Name = "tpPromoAttivi"
        Me.tpPromoAttivi.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPromoAttivi.Size = New System.Drawing.Size(1121, 538)
        Me.tpPromoAttivi.TabIndex = 0
        Me.tpPromoAttivi.Text = "Elenco PROMO"
        Me.tpPromoAttivi.UseVisualStyleBackColor = True
        '
        'lnkTrasforma
        '
        Me.lnkTrasforma.AutoSize = True
        Me.lnkTrasforma.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkTrasforma.Image = Global.Former.My.Resources.Resources._Modifica
        Me.lnkTrasforma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkTrasforma.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkTrasforma.Location = New System.Drawing.Point(519, 3)
        Me.lnkTrasforma.Name = "lnkTrasforma"
        Me.lnkTrasforma.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkTrasforma.Size = New System.Drawing.Size(175, 27)
        Me.lnkTrasforma.TabIndex = 84
        Me.lnkTrasforma.TabStop = True
        Me.lnkTrasforma.Text = "Trasforma in AUTOMATICO"
        Me.lnkTrasforma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDeleteAll
        '
        Me.lnkDeleteAll.AutoSize = True
        Me.lnkDeleteAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDeleteAll.Image = Global.Former.My.Resources.Resources._DeleteAll
        Me.lnkDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDeleteAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDeleteAll.Location = New System.Drawing.Point(369, 3)
        Me.lnkDeleteAll.Name = "lnkDeleteAll"
        Me.lnkDeleteAll.Padding = New System.Windows.Forms.Padding(26, 6, 0, 6)
        Me.lnkDeleteAll.Size = New System.Drawing.Size(144, 27)
        Me.lnkDeleteAll.TabIndex = 83
        Me.lnkDeleteAll.TabStop = True
        Me.lnkDeleteAll.Text = "Elimina tutti i scaduti"
        Me.lnkDeleteAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lnkNewPromoAuto)
        Me.TabPage2.Controls.Add(Me.dgPromoAuto)
        Me.TabPage2.Controls.Add(Me.cmbMeseRif)
        Me.TabPage2.Controls.Add(Me.lnkAggiorna)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1121, 538)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listini Base con PROMO Automatico"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lnkNewPromoAuto
        '
        Me.lnkNewPromoAuto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNewPromoAuto.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkNewPromoAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNewPromoAuto.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNewPromoAuto.Location = New System.Drawing.Point(312, 6)
        Me.lnkNewPromoAuto.Name = "lnkNewPromoAuto"
        Me.lnkNewPromoAuto.Size = New System.Drawing.Size(175, 28)
        Me.lnkNewPromoAuto.TabIndex = 61
        Me.lnkNewPromoAuto.TabStop = True
        Me.lnkNewPromoAuto.Text = "Nuovo Promo Automatico"
        Me.lnkNewPromoAuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgPromoAuto
        '
        Me.dgPromoAuto.AllowUserToAddRows = False
        Me.dgPromoAuto.AllowUserToDeleteRows = False
        Me.dgPromoAuto.AllowUserToOrderColumns = True
        Me.dgPromoAuto.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.dgPromoAuto.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgPromoAuto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPromoAuto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.dgPromoAuto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgPromoAuto.BackgroundColor = System.Drawing.Color.White
        Me.dgPromoAuto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgPromoAuto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPromoAuto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgPromoAuto.ColumnHeadersHeight = 20
        Me.dgPromoAuto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgPromoAuto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.LimiteSuFatturato, Me.FatturatoMensile, Me.FatturatoPromo, Me.PercFatturatoPromo, Me.StatoPromo, Me.Pubblicato, Me.Views})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPromoAuto.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgPromoAuto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgPromoAuto.EnableHeadersVisualStyles = False
        Me.dgPromoAuto.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgPromoAuto.Location = New System.Drawing.Point(7, 35)
        Me.dgPromoAuto.MultiSelect = False
        Me.dgPromoAuto.Name = "dgPromoAuto"
        Me.dgPromoAuto.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPromoAuto.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgPromoAuto.RowHeadersVisible = False
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        Me.dgPromoAuto.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dgPromoAuto.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgPromoAuto.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgPromoAuto.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgPromoAuto.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPromoAuto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPromoAuto.Size = New System.Drawing.Size(1108, 497)
        Me.dgPromoAuto.TabIndex = 60
        Me.dgPromoAuto.TabStop = False
        '
        'cmbMeseRif
        '
        Me.cmbMeseRif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMeseRif.FormattingEnabled = True
        Me.cmbMeseRif.Location = New System.Drawing.Point(6, 6)
        Me.cmbMeseRif.Name = "cmbMeseRif"
        Me.cmbMeseRif.Size = New System.Drawing.Size(210, 23)
        Me.cmbMeseRif.TabIndex = 56
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(222, 6)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(84, 29)
        Me.lnkAggiorna.TabIndex = 57
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewImageColumn1.DataPropertyName = "ImgRif"
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.MinimumWidth = 64
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 64
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ListinoBaseStr"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Listino Base"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PercPromo"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn2.HeaderText = "Percentuale"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'LimiteSuFatturato
        '
        Me.LimiteSuFatturato.DataPropertyName = "PercLimite"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.LimiteSuFatturato.DefaultCellStyle = DataGridViewCellStyle10
        Me.LimiteSuFatturato.HeaderText = "Limite % su Fatturato"
        Me.LimiteSuFatturato.MinimumWidth = 100
        Me.LimiteSuFatturato.Name = "LimiteSuFatturato"
        Me.LimiteSuFatturato.ReadOnly = True
        '
        'FatturatoMensile
        '
        Me.FatturatoMensile.DataPropertyName = "FatturatoMensileTotale"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.FatturatoMensile.DefaultCellStyle = DataGridViewCellStyle11
        Me.FatturatoMensile.HeaderText = "Fatturato Mensile"
        Me.FatturatoMensile.MinimumWidth = 100
        Me.FatturatoMensile.Name = "FatturatoMensile"
        Me.FatturatoMensile.ReadOnly = True
        '
        'FatturatoPromo
        '
        Me.FatturatoPromo.DataPropertyName = "FatturatoMensileConPromo"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.FatturatoPromo.DefaultCellStyle = DataGridViewCellStyle12
        Me.FatturatoPromo.HeaderText = "Fatturato Promo"
        Me.FatturatoPromo.MinimumWidth = 100
        Me.FatturatoPromo.Name = "FatturatoPromo"
        Me.FatturatoPromo.ReadOnly = True
        '
        'PercFatturatoPromo
        '
        Me.PercFatturatoPromo.DataPropertyName = "PercentualeSuFatturato"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PercFatturatoPromo.DefaultCellStyle = DataGridViewCellStyle13
        Me.PercFatturatoPromo.HeaderText = "% Fatturato Promo"
        Me.PercFatturatoPromo.MinimumWidth = 100
        Me.PercFatturatoPromo.Name = "PercFatturatoPromo"
        Me.PercFatturatoPromo.ReadOnly = True
        '
        'StatoPromo
        '
        Me.StatoPromo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.StatoPromo.DataPropertyName = "StatoPromoAutomaticoStr"
        Me.StatoPromo.HeaderText = "Stato"
        Me.StatoPromo.MinimumWidth = 100
        Me.StatoPromo.Name = "StatoPromo"
        Me.StatoPromo.ReadOnly = True
        '
        'Pubblicato
        '
        Me.Pubblicato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Pubblicato.DataPropertyName = "PubblicatoStr"
        Me.Pubblicato.HeaderText = "Pubblicato"
        Me.Pubblicato.MinimumWidth = 100
        Me.Pubblicato.Name = "Pubblicato"
        Me.Pubblicato.ReadOnly = True
        '
        'Views
        '
        Me.Views.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Views.DataPropertyName = "CounterDayPromo"
        Me.Views.HeaderText = "Views"
        Me.Views.MinimumWidth = 80
        Me.Views.Name = "Views"
        Me.Views.ReadOnly = True
        Me.Views.Width = 80
        '
        'ucAmministrazionePromo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TabPromo)
        Me.Name = "ucAmministrazionePromo"
        Me.Size = New System.Drawing.Size(1129, 566)
        CType(Me.DgPromo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPromo.ResumeLayout(False)
        Me.tpPromoAttivi.ResumeLayout(False)
        Me.tpPromoAttivi.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgPromoAuto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgPromo As System.Windows.Forms.DataGridView
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkRefresh As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDel As LinkLabel
    Friend WithEvents lnkEdit As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblCountPromo As Label
    Friend WithEvents IcoTipo As DataGridViewImageColumn
    Friend WithEvents Prodotto As DataGridViewTextBoxColumn
    Friend WithEvents Percentuale As DataGridViewTextBoxColumn
    Friend WithEvents ValidoAl As DataGridViewTextBoxColumn
    Friend WithEvents Stato As DataGridViewTextBoxColumn
    Friend WithEvents ScadeTra As DataGridViewTextBoxColumn
    Friend WithEvents Automatico As DataGridViewTextBoxColumn
    Friend WithEvents TabPromo As TabControl
    Friend WithEvents tpPromoAttivi As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmbMeseRif As ComboBox
    Friend WithEvents lnkAggiorna As LinkLabel
    Friend WithEvents lnkDeleteAll As LinkLabel
    Friend WithEvents lnkNewPromoAuto As LinkLabel
    Friend WithEvents dgPromoAuto As DataGridView
    Friend WithEvents lnkTrasforma As LinkLabel
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents LimiteSuFatturato As DataGridViewTextBoxColumn
    Friend WithEvents FatturatoMensile As DataGridViewTextBoxColumn
    Friend WithEvents FatturatoPromo As DataGridViewTextBoxColumn
    Friend WithEvents PercFatturatoPromo As DataGridViewTextBoxColumn
    Friend WithEvents StatoPromo As DataGridViewTextBoxColumn
    Friend WithEvents Pubblicato As DataGridViewTextBoxColumn
    Friend WithEvents Views As DataGridViewTextBoxColumn
End Class
