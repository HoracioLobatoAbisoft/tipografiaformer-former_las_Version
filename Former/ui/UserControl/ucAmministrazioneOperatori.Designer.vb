<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAmministrazioneOperatori
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabOperatore = New System.Windows.Forms.TabControl()
        Me.tbRiepilogo = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblBonusRiep = New System.Windows.Forms.Label()
        Me.dgLogOperat = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbAnno = New System.Windows.Forms.ComboBox()
        Me.cmbMese = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.DGOperat = New System.Windows.Forms.DataGridView()
        Me.Login = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeReale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepartoDefault = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Attivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkReport = New System.Windows.Forms.LinkLabel()
        Me.lnkUser = New System.Windows.Forms.LinkLabel()
        Me.lnStampaLog = New System.Windows.Forms.LinkLabel()
        Me.lnkAggLog = New System.Windows.Forms.LinkLabel()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.lnkAll = New System.Windows.Forms.LinkLabel()
        Me.tabOperatore.SuspendLayout()
        Me.tbRiepilogo.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgLogOperat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGOperat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabOperatore
        '
        Me.tabOperatore.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabOperatore.Controls.Add(Me.tbRiepilogo)
        Me.tabOperatore.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabOperatore.Location = New System.Drawing.Point(320, 46)
        Me.tabOperatore.Name = "tabOperatore"
        Me.tabOperatore.SelectedIndex = 0
        Me.tabOperatore.Size = New System.Drawing.Size(438, 658)
        Me.tabOperatore.TabIndex = 62
        '
        'tbRiepilogo
        '
        Me.tbRiepilogo.Controls.Add(Me.GroupBox4)
        Me.tbRiepilogo.Controls.Add(Me.GroupBox3)
        Me.tbRiepilogo.Controls.Add(Me.Label21)
        Me.tbRiepilogo.Controls.Add(Me.PictureBox13)
        Me.tbRiepilogo.Location = New System.Drawing.Point(4, 24)
        Me.tbRiepilogo.Name = "tbRiepilogo"
        Me.tbRiepilogo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbRiepilogo.Size = New System.Drawing.Size(430, 630)
        Me.tbRiepilogo.TabIndex = 0
        Me.tbRiepilogo.Text = "Riepilogo"
        Me.tbRiepilogo.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.lblBonusRiep)
        Me.GroupBox4.Controls.Add(Me.dgLogOperat)
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(62, 193)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(360, 426)
        Me.GroupBox4.TabIndex = 60
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Lavorazioni e bonus"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(7, 27)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 15)
        Me.Label22.TabIndex = 51
        Me.Label22.Text = "Bonus"
        '
        'lblBonusRiep
        '
        Me.lblBonusRiep.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBonusRiep.ForeColor = System.Drawing.Color.Black
        Me.lblBonusRiep.Location = New System.Drawing.Point(196, 20)
        Me.lblBonusRiep.Name = "lblBonusRiep"
        Me.lblBonusRiep.Size = New System.Drawing.Size(156, 27)
        Me.lblBonusRiep.TabIndex = 52
        Me.lblBonusRiep.Text = "0"
        Me.lblBonusRiep.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgLogOperat
        '
        Me.dgLogOperat.AllowUserToAddRows = False
        Me.dgLogOperat.AllowUserToDeleteRows = False
        Me.dgLogOperat.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgLogOperat.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLogOperat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLogOperat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgLogOperat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgLogOperat.BackgroundColor = System.Drawing.Color.White
        Me.dgLogOperat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgLogOperat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLogOperat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgLogOperat.ColumnHeadersHeight = 20
        Me.dgLogOperat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLogOperat.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgLogOperat.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgLogOperat.EnableHeadersVisualStyles = False
        Me.dgLogOperat.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgLogOperat.Location = New System.Drawing.Point(10, 50)
        Me.dgLogOperat.MultiSelect = False
        Me.dgLogOperat.Name = "dgLogOperat"
        Me.dgLogOperat.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLogOperat.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgLogOperat.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgLogOperat.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgLogOperat.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgLogOperat.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgLogOperat.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgLogOperat.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLogOperat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLogOperat.Size = New System.Drawing.Size(343, 370)
        Me.dgLogOperat.TabIndex = 57
        Me.dgLogOperat.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lnStampaLog)
        Me.GroupBox3.Controls.Add(Me.lnkAggLog)
        Me.GroupBox3.Controls.Add(Me.cmbAnno)
        Me.GroupBox3.Controls.Add(Me.cmbMese)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(62, 68)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(360, 118)
        Me.GroupBox3.TabIndex = 59
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Periodo di riferimento"
        '
        'cmbAnno
        '
        Me.cmbAnno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnno.FormattingEnabled = True
        Me.cmbAnno.Location = New System.Drawing.Point(83, 52)
        Me.cmbAnno.Name = "cmbAnno"
        Me.cmbAnno.Size = New System.Drawing.Size(269, 23)
        Me.cmbAnno.TabIndex = 55
        '
        'cmbMese
        '
        Me.cmbMese.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMese.FormattingEnabled = True
        Me.cmbMese.Location = New System.Drawing.Point(83, 20)
        Me.cmbMese.Name = "cmbMese"
        Me.cmbMese.Size = New System.Drawing.Size(269, 23)
        Me.cmbMese.TabIndex = 54
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(7, 55)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(36, 15)
        Me.Label25.TabIndex = 53
        Me.Label25.Text = "Anno"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(7, 23)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(35, 15)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "Mese"
        '
        'Label21
        '
        Me.Label21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.Location = New System.Drawing.Point(58, 7)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(364, 43)
        Me.Label21.TabIndex = 48
        Me.Label21.Text = "In questa schermata vengono visualizzati il bonus e i lavori effettuati dall'oper" &
    "atore nel mese selezionato."
        '
        'DGOperat
        '
        Me.DGOperat.AllowUserToAddRows = False
        Me.DGOperat.AllowUserToDeleteRows = False
        Me.DGOperat.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOperat.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DGOperat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DGOperat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGOperat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGOperat.BackgroundColor = System.Drawing.Color.White
        Me.DGOperat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGOperat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGOperat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGOperat.ColumnHeadersHeight = 20
        Me.DGOperat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGOperat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Login, Me.NomeReale, Me.Tipo, Me.RepartoDefault, Me.Attivo})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOperat.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGOperat.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGOperat.EnableHeadersVisualStyles = False
        Me.DGOperat.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DGOperat.Location = New System.Drawing.Point(7, 46)
        Me.DGOperat.MultiSelect = False
        Me.DGOperat.Name = "DGOperat"
        Me.DGOperat.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOperat.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGOperat.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOperat.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DGOperat.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DGOperat.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DGOperat.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DGOperat.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOperat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGOperat.Size = New System.Drawing.Size(307, 654)
        Me.DGOperat.TabIndex = 63
        Me.DGOperat.TabStop = False
        '
        'Login
        '
        Me.Login.DataPropertyName = "Login"
        Me.Login.HeaderText = "Login"
        Me.Login.Name = "Login"
        Me.Login.ReadOnly = True
        '
        'NomeReale
        '
        Me.NomeReale.DataPropertyName = "NomeReale"
        Me.NomeReale.HeaderText = "Nome Reale"
        Me.NomeReale.Name = "NomeReale"
        Me.NomeReale.ReadOnly = True
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "TipoStr"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'RepartoDefault
        '
        Me.RepartoDefault.DataPropertyName = "RepartoDefaultStr"
        Me.RepartoDefault.HeaderText = "Reparto Default"
        Me.RepartoDefault.Name = "RepartoDefault"
        Me.RepartoDefault.ReadOnly = True
        '
        'Attivo
        '
        Me.Attivo.DataPropertyName = "AttivoStr"
        Me.Attivo.HeaderText = "Attivo"
        Me.Attivo.Name = "Attivo"
        Me.Attivo.ReadOnly = True
        '
        'lnkReport
        '
        Me.lnkReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkReport.AutoSize = True
        Me.lnkReport.Image = Global.Former.My.Resources.Resources.bar_chart24
        Me.lnkReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkReport.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkReport.Location = New System.Drawing.Point(621, 6)
        Me.lnkReport.Name = "lnkReport"
        Me.lnkReport.Padding = New System.Windows.Forms.Padding(30, 8, 0, 8)
        Me.lnkReport.Size = New System.Drawing.Size(133, 31)
        Me.lnkReport.TabIndex = 65
        Me.lnkReport.TabStop = True
        Me.lnkReport.Text = "Report Giornaliero"
        Me.lnkReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkUser
        '
        Me.lnkUser.AutoSize = True
        Me.lnkUser.Image = Global.Former.My.Resources.Resources._UsbKey
        Me.lnkUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkUser.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkUser.Location = New System.Drawing.Point(320, 6)
        Me.lnkUser.Name = "lnkUser"
        Me.lnkUser.Padding = New System.Windows.Forms.Padding(30, 8, 0, 8)
        Me.lnkUser.Size = New System.Drawing.Size(103, 31)
        Me.lnkUser.TabIndex = 64
        Me.lnkUser.TabStop = True
        Me.lnkUser.Text = "FormerKey..."
        Me.lnkUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnStampaLog
        '
        Me.lnStampaLog.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnStampaLog.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnStampaLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnStampaLog.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnStampaLog.Location = New System.Drawing.Point(188, 78)
        Me.lnStampaLog.Name = "lnStampaLog"
        Me.lnStampaLog.Size = New System.Drawing.Size(78, 30)
        Me.lnStampaLog.TabIndex = 59
        Me.lnStampaLog.TabStop = True
        Me.lnStampaLog.Text = "Stampa"
        Me.lnStampaLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAggLog
        '
        Me.lnkAggLog.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggLog.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggLog.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggLog.Location = New System.Drawing.Point(80, 78)
        Me.lnkAggLog.Name = "lnkAggLog"
        Me.lnkAggLog.Size = New System.Drawing.Size(84, 30)
        Me.lnkAggLog.TabIndex = 58
        Me.lnkAggLog.TabStop = True
        Me.lnkAggLog.Text = "Aggiorna"
        Me.lnkAggLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = Global.Former.My.Resources.Resources._Calendario
        Me.PictureBox13.Location = New System.Drawing.Point(7, 7)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(44, 46)
        Me.PictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox13.TabIndex = 6
        Me.PictureBox13.TabStop = False
        '
        'lnkNew
        '
        Me.lnkNew.AutoSize = True
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(10, 6)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Padding = New System.Windows.Forms.Padding(30, 8, 0, 8)
        Me.lnkNew.Size = New System.Drawing.Size(129, 31)
        Me.lnkNew.TabIndex = 61
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo Operatore"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkStampa
        '
        Me.lnkStampa.AutoSize = True
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(237, 6)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Padding = New System.Windows.Forms.Padding(30, 8, 0, 8)
        Me.lnkStampa.Size = New System.Drawing.Size(77, 31)
        Me.lnkStampa.TabIndex = 60
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAll
        '
        Me.lnkAll.AutoSize = True
        Me.lnkAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAll.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAll.Location = New System.Drawing.Point(145, 6)
        Me.lnkAll.Name = "lnkAll"
        Me.lnkAll.Padding = New System.Windows.Forms.Padding(30, 8, 0, 8)
        Me.lnkAll.Size = New System.Drawing.Size(86, 31)
        Me.lnkAll.TabIndex = 59
        Me.lnkAll.TabStop = True
        Me.lnkAll.Text = "Aggiorna"
        Me.lnkAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucAmministrazioneOperatori
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkReport)
        Me.Controls.Add(Me.lnkUser)
        Me.Controls.Add(Me.DGOperat)
        Me.Controls.Add(Me.tabOperatore)
        Me.Controls.Add(Me.lnkNew)
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.lnkAll)
        Me.Name = "ucAmministrazioneOperatori"
        Me.Size = New System.Drawing.Size(762, 707)
        Me.tabOperatore.ResumeLayout(False)
        Me.tbRiepilogo.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgLogOperat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DGOperat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAll As System.Windows.Forms.LinkLabel
    Friend WithEvents tabOperatore As System.Windows.Forms.TabControl
    Friend WithEvents tbRiepilogo As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblBonusRiep As System.Windows.Forms.Label
    Friend WithEvents dgLogOperat As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lnStampaLog As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAggLog As System.Windows.Forms.LinkLabel
    Friend WithEvents cmbAnno As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMese As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents DGOperat As System.Windows.Forms.DataGridView
    Friend WithEvents lnkUser As System.Windows.Forms.LinkLabel
    Friend WithEvents Login As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomeReale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepartoDefault As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Attivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkReport As LinkLabel
End Class
