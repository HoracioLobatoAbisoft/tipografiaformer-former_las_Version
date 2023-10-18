<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnCarica = New System.Windows.Forms.Button()
        Me.tvwSessioni = New System.Windows.Forms.TreeView()
        Me.dgTrace = New System.Windows.Forms.DataGridView()
        Me.Quando = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Url = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblInfoSess = New System.Windows.Forms.Label()
        Me.grpFind = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.rdoTutto = New System.Windows.Forms.RadioButton()
        Me.rdoPeriodo = New System.Windows.Forms.RadioButton()
        Me.rdoData = New System.Windows.Forms.RadioButton()
        Me.dtGiorno = New System.Windows.Forms.DateTimePicker()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tpLog = New System.Windows.Forms.TabPage()
        Me.tpGoto = New System.Windows.Forms.TabPage()
        Me.btnApriUrl = New System.Windows.Forms.Button()
        Me.btnAggiornaGoto = New System.Windows.Forms.Button()
        Me.dgGoto = New System.Windows.Forms.DataGridView()
        Me.IdGoto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetUrl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Counter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkSoloSenzaRis = New System.Windows.Forms.CheckBox()
        Me.lblFileCorrente = New System.Windows.Forms.Label()
        Me.dgKeyword = New System.Windows.Forms.DataGridView()
        Me.Keyword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Risultati = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEstraiKeywords = New System.Windows.Forms.Button()
        Me.tpStat = New System.Windows.Forms.TabPage()
        Me.btnElaboraStat = New System.Windows.Forms.Button()
        Me.txtElabora = New System.Windows.Forms.TextBox()
        CType(Me.dgTrace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFind.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tpLog.SuspendLayout()
        Me.tpGoto.SuspendLayout()
        CType(Me.dgGoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgKeyword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStat.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCarica
        '
        Me.btnCarica.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCarica.Location = New System.Drawing.Point(1024, 124)
        Me.btnCarica.Name = "btnCarica"
        Me.btnCarica.Size = New System.Drawing.Size(87, 21)
        Me.btnCarica.TabIndex = 0
        Me.btnCarica.Text = "Go"
        Me.btnCarica.UseVisualStyleBackColor = True
        '
        'tvwSessioni
        '
        Me.tvwSessioni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvwSessioni.Location = New System.Drawing.Point(6, 163)
        Me.tvwSessioni.Name = "tvwSessioni"
        Me.tvwSessioni.Size = New System.Drawing.Size(326, 399)
        Me.tvwSessioni.TabIndex = 1
        '
        'dgTrace
        '
        Me.dgTrace.AllowUserToAddRows = False
        Me.dgTrace.AllowUserToDeleteRows = False
        Me.dgTrace.AllowUserToResizeRows = False
        Me.dgTrace.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTrace.BackgroundColor = System.Drawing.Color.White
        Me.dgTrace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTrace.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Quando, Me.Url, Me.Tipo})
        Me.dgTrace.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgTrace.Location = New System.Drawing.Point(338, 163)
        Me.dgTrace.Name = "dgTrace"
        Me.dgTrace.RowHeadersVisible = False
        Me.dgTrace.Size = New System.Drawing.Size(785, 399)
        Me.dgTrace.TabIndex = 2
        '
        'Quando
        '
        Me.Quando.DataPropertyName = "Quando"
        Me.Quando.HeaderText = "Quando"
        Me.Quando.Name = "Quando"
        Me.Quando.Width = 150
        '
        'Url
        '
        Me.Url.DataPropertyName = "UrlWeb"
        Me.Url.HeaderText = "Url"
        Me.Url.Name = "Url"
        Me.Url.Width = 500
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "TipoPagina"
        Me.Tipo.HeaderText = "Tipo Pagina"
        Me.Tipo.Name = "Tipo"
        '
        'lblInfoSess
        '
        Me.lblInfoSess.AutoSize = True
        Me.lblInfoSess.Location = New System.Drawing.Point(6, 127)
        Me.lblInfoSess.Name = "lblInfoSess"
        Me.lblInfoSess.Size = New System.Drawing.Size(11, 15)
        Me.lblInfoSess.TabIndex = 3
        Me.lblInfoSess.Text = "-"
        '
        'grpFind
        '
        Me.grpFind.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFind.Controls.Add(Me.ComboBox1)
        Me.grpFind.Controls.Add(Me.rdoTutto)
        Me.grpFind.Controls.Add(Me.rdoPeriodo)
        Me.grpFind.Controls.Add(Me.rdoData)
        Me.grpFind.Controls.Add(Me.dtGiorno)
        Me.grpFind.Controls.Add(Me.btnCarica)
        Me.grpFind.Controls.Add(Me.lblInfoSess)
        Me.grpFind.Location = New System.Drawing.Point(6, 6)
        Me.grpFind.Name = "grpFind"
        Me.grpFind.Size = New System.Drawing.Size(1117, 151)
        Me.grpFind.TabIndex = 4
        Me.grpFind.TabStop = False
        Me.grpFind.Text = "Parametri di ricerca"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(407, 20)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(236, 23)
        Me.ComboBox1.TabIndex = 8
        '
        'rdoTutto
        '
        Me.rdoTutto.AutoSize = True
        Me.rdoTutto.Location = New System.Drawing.Point(659, 21)
        Me.rdoTutto.Name = "rdoTutto"
        Me.rdoTutto.Size = New System.Drawing.Size(52, 19)
        Me.rdoTutto.TabIndex = 7
        Me.rdoTutto.Text = "Tutto"
        Me.rdoTutto.UseVisualStyleBackColor = True
        '
        'rdoPeriodo
        '
        Me.rdoPeriodo.AutoSize = True
        Me.rdoPeriodo.Location = New System.Drawing.Point(333, 21)
        Me.rdoPeriodo.Name = "rdoPeriodo"
        Me.rdoPeriodo.Size = New System.Drawing.Size(68, 19)
        Me.rdoPeriodo.TabIndex = 6
        Me.rdoPeriodo.Text = "Periodo"
        Me.rdoPeriodo.UseVisualStyleBackColor = True
        '
        'rdoData
        '
        Me.rdoData.AutoSize = True
        Me.rdoData.Checked = True
        Me.rdoData.Location = New System.Drawing.Point(6, 21)
        Me.rdoData.Name = "rdoData"
        Me.rdoData.Size = New System.Drawing.Size(51, 19)
        Me.rdoData.TabIndex = 5
        Me.rdoData.TabStop = True
        Me.rdoData.Text = "Data"
        Me.rdoData.UseVisualStyleBackColor = True
        '
        'dtGiorno
        '
        Me.dtGiorno.Location = New System.Drawing.Point(80, 20)
        Me.dtGiorno.Name = "dtGiorno"
        Me.dtGiorno.Size = New System.Drawing.Size(236, 21)
        Me.dtGiorno.TabIndex = 4
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tpLog)
        Me.tabMain.Controls.Add(Me.tpGoto)
        Me.tabMain.Controls.Add(Me.TabPage1)
        Me.tabMain.Controls.Add(Me.tpStat)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1137, 596)
        Me.tabMain.TabIndex = 9
        '
        'tpLog
        '
        Me.tpLog.Controls.Add(Me.grpFind)
        Me.tpLog.Controls.Add(Me.dgTrace)
        Me.tpLog.Controls.Add(Me.tvwSessioni)
        Me.tpLog.Location = New System.Drawing.Point(4, 24)
        Me.tpLog.Name = "tpLog"
        Me.tpLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLog.Size = New System.Drawing.Size(1129, 568)
        Me.tpLog.TabIndex = 0
        Me.tpLog.Text = "Log"
        Me.tpLog.UseVisualStyleBackColor = True
        '
        'tpGoto
        '
        Me.tpGoto.Controls.Add(Me.btnApriUrl)
        Me.tpGoto.Controls.Add(Me.btnAggiornaGoto)
        Me.tpGoto.Controls.Add(Me.dgGoto)
        Me.tpGoto.Location = New System.Drawing.Point(4, 24)
        Me.tpGoto.Name = "tpGoto"
        Me.tpGoto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGoto.Size = New System.Drawing.Size(1129, 568)
        Me.tpGoto.TabIndex = 1
        Me.tpGoto.Text = "Go To"
        Me.tpGoto.UseVisualStyleBackColor = True
        '
        'btnApriUrl
        '
        Me.btnApriUrl.Location = New System.Drawing.Point(90, 7)
        Me.btnApriUrl.Name = "btnApriUrl"
        Me.btnApriUrl.Size = New System.Drawing.Size(75, 23)
        Me.btnApriUrl.TabIndex = 66
        Me.btnApriUrl.Text = "Apri URL"
        Me.btnApriUrl.UseVisualStyleBackColor = True
        '
        'btnAggiornaGoto
        '
        Me.btnAggiornaGoto.Location = New System.Drawing.Point(9, 7)
        Me.btnAggiornaGoto.Name = "btnAggiornaGoto"
        Me.btnAggiornaGoto.Size = New System.Drawing.Size(75, 23)
        Me.btnAggiornaGoto.TabIndex = 65
        Me.btnAggiornaGoto.Text = "Aggiorna"
        Me.btnAggiornaGoto.UseVisualStyleBackColor = True
        '
        'dgGoto
        '
        Me.dgGoto.AllowUserToAddRows = False
        Me.dgGoto.AllowUserToDeleteRows = False
        Me.dgGoto.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgGoto.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgGoto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgGoto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgGoto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgGoto.BackgroundColor = System.Drawing.Color.White
        Me.dgGoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgGoto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgGoto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgGoto.ColumnHeadersHeight = 20
        Me.dgGoto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgGoto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdGoto, Me.Nome, Me.TargetUrl, Me.Counter})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgGoto.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgGoto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgGoto.EnableHeadersVisualStyles = False
        Me.dgGoto.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgGoto.Location = New System.Drawing.Point(8, 36)
        Me.dgGoto.MultiSelect = False
        Me.dgGoto.Name = "dgGoto"
        Me.dgGoto.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgGoto.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgGoto.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgGoto.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgGoto.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dgGoto.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgGoto.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgGoto.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgGoto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgGoto.Size = New System.Drawing.Size(1113, 526)
        Me.dgGoto.TabIndex = 64
        Me.dgGoto.TabStop = False
        '
        'IdGoto
        '
        Me.IdGoto.DataPropertyName = "IdTraceSource"
        Me.IdGoto.HeaderText = "IdGoto"
        Me.IdGoto.Name = "IdGoto"
        Me.IdGoto.ReadOnly = True
        Me.IdGoto.Width = 67
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "Nome"
        Me.Nome.HeaderText = "Nome"
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 65
        '
        'TargetUrl
        '
        Me.TargetUrl.DataPropertyName = "TargetUrl"
        Me.TargetUrl.HeaderText = "TargetUrl"
        Me.TargetUrl.Name = "TargetUrl"
        Me.TargetUrl.ReadOnly = True
        Me.TargetUrl.Width = 81
        '
        'Counter
        '
        Me.Counter.DataPropertyName = "Counter"
        Me.Counter.HeaderText = "Counter"
        Me.Counter.Name = "Counter"
        Me.Counter.ReadOnly = True
        Me.Counter.Width = 75
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkSoloSenzaRis)
        Me.TabPage1.Controls.Add(Me.lblFileCorrente)
        Me.TabPage1.Controls.Add(Me.dgKeyword)
        Me.TabPage1.Controls.Add(Me.btnEstraiKeywords)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1129, 568)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Ricerche dal sito"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkSoloSenzaRis
        '
        Me.chkSoloSenzaRis.AutoSize = True
        Me.chkSoloSenzaRis.Location = New System.Drawing.Point(89, 9)
        Me.chkSoloSenzaRis.Name = "chkSoloSenzaRis"
        Me.chkSoloSenzaRis.Size = New System.Drawing.Size(130, 19)
        Me.chkSoloSenzaRis.TabIndex = 69
        Me.chkSoloSenzaRis.Text = "Solo senza risultati"
        Me.chkSoloSenzaRis.UseVisualStyleBackColor = True
        '
        'lblFileCorrente
        '
        Me.lblFileCorrente.AutoSize = True
        Me.lblFileCorrente.Location = New System.Drawing.Point(237, 10)
        Me.lblFileCorrente.Name = "lblFileCorrente"
        Me.lblFileCorrente.Size = New System.Drawing.Size(11, 15)
        Me.lblFileCorrente.TabIndex = 68
        Me.lblFileCorrente.Text = "-"
        '
        'dgKeyword
        '
        Me.dgKeyword.AllowUserToAddRows = False
        Me.dgKeyword.AllowUserToDeleteRows = False
        Me.dgKeyword.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.dgKeyword.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgKeyword.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgKeyword.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgKeyword.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgKeyword.BackgroundColor = System.Drawing.Color.White
        Me.dgKeyword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgKeyword.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgKeyword.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgKeyword.ColumnHeadersHeight = 20
        Me.dgKeyword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgKeyword.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Keyword, Me.Hit, Me.Risultati})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgKeyword.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgKeyword.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgKeyword.EnableHeadersVisualStyles = False
        Me.dgKeyword.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgKeyword.Location = New System.Drawing.Point(8, 34)
        Me.dgKeyword.MultiSelect = False
        Me.dgKeyword.Name = "dgKeyword"
        Me.dgKeyword.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgKeyword.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgKeyword.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.dgKeyword.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgKeyword.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dgKeyword.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgKeyword.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgKeyword.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgKeyword.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgKeyword.Size = New System.Drawing.Size(1113, 526)
        Me.dgKeyword.TabIndex = 67
        Me.dgKeyword.TabStop = False
        '
        'Keyword
        '
        Me.Keyword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Keyword.DataPropertyName = "Keyword"
        Me.Keyword.HeaderText = "Keyword"
        Me.Keyword.Name = "Keyword"
        Me.Keyword.ReadOnly = True
        Me.Keyword.Width = 78
        '
        'Hit
        '
        Me.Hit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Hit.DataPropertyName = "Hit"
        Me.Hit.HeaderText = "Hit"
        Me.Hit.Name = "Hit"
        Me.Hit.ReadOnly = True
        Me.Hit.Width = 46
        '
        'Risultati
        '
        Me.Risultati.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Risultati.DataPropertyName = "Risultati"
        Me.Risultati.HeaderText = "Risultati"
        Me.Risultati.Name = "Risultati"
        Me.Risultati.ReadOnly = True
        Me.Risultati.Width = 76
        '
        'btnEstraiKeywords
        '
        Me.btnEstraiKeywords.Location = New System.Drawing.Point(8, 6)
        Me.btnEstraiKeywords.Name = "btnEstraiKeywords"
        Me.btnEstraiKeywords.Size = New System.Drawing.Size(75, 23)
        Me.btnEstraiKeywords.TabIndex = 66
        Me.btnEstraiKeywords.Text = "Estrai"
        Me.btnEstraiKeywords.UseVisualStyleBackColor = True
        '
        'tpStat
        '
        Me.tpStat.Controls.Add(Me.txtElabora)
        Me.tpStat.Controls.Add(Me.btnElaboraStat)
        Me.tpStat.Location = New System.Drawing.Point(4, 24)
        Me.tpStat.Name = "tpStat"
        Me.tpStat.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStat.Size = New System.Drawing.Size(1129, 568)
        Me.tpStat.TabIndex = 3
        Me.tpStat.Text = "Statische Navigazione"
        Me.tpStat.UseVisualStyleBackColor = True
        '
        'btnElaboraStat
        '
        Me.btnElaboraStat.Location = New System.Drawing.Point(8, 6)
        Me.btnElaboraStat.Name = "btnElaboraStat"
        Me.btnElaboraStat.Size = New System.Drawing.Size(75, 23)
        Me.btnElaboraStat.TabIndex = 0
        Me.btnElaboraStat.Text = "Elabora"
        Me.btnElaboraStat.UseVisualStyleBackColor = True
        '
        'txtElabora
        '
        Me.txtElabora.Location = New System.Drawing.Point(8, 35)
        Me.txtElabora.Multiline = True
        Me.txtElabora.Name = "txtElabora"
        Me.txtElabora.ReadOnly = True
        Me.txtElabora.Size = New System.Drawing.Size(1113, 525)
        Me.txtElabora.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1137, 596)
        Me.Controls.Add(Me.tabMain)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Former Analytics"
        CType(Me.dgTrace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFind.ResumeLayout(False)
        Me.grpFind.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tpLog.ResumeLayout(False)
        Me.tpGoto.ResumeLayout(False)
        CType(Me.dgGoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgKeyword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStat.ResumeLayout(False)
        Me.tpStat.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCarica As System.Windows.Forms.Button
    Friend WithEvents tvwSessioni As System.Windows.Forms.TreeView
    Friend WithEvents dgTrace As System.Windows.Forms.DataGridView
    Friend WithEvents lblInfoSess As System.Windows.Forms.Label
    Friend WithEvents grpFind As System.Windows.Forms.GroupBox
    Friend WithEvents dtGiorno As System.Windows.Forms.DateTimePicker
    Friend WithEvents Quando As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Url As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rdoTutto As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPeriodo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoData As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpLog As System.Windows.Forms.TabPage
    Friend WithEvents tpGoto As System.Windows.Forms.TabPage
    Friend WithEvents btnAggiornaGoto As System.Windows.Forms.Button
    Friend WithEvents dgGoto As System.Windows.Forms.DataGridView
    Friend WithEvents btnApriUrl As System.Windows.Forms.Button
    Friend WithEvents IdGoto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TargetUrl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Counter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgKeyword As DataGridView
    Friend WithEvents btnEstraiKeywords As Button
    Friend WithEvents lblFileCorrente As Label
    Friend WithEvents Keyword As DataGridViewTextBoxColumn
    Friend WithEvents Hit As DataGridViewTextBoxColumn
    Friend WithEvents Risultati As DataGridViewTextBoxColumn
    Friend WithEvents chkSoloSenzaRis As CheckBox
    Friend WithEvents tpStat As TabPage
    Friend WithEvents btnElaboraStat As Button
    Friend WithEvents txtElabora As TextBox
End Class
