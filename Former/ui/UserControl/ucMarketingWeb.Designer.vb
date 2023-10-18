<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMarketingWeb
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.dgMarkWeb = New System.Windows.Forms.DataGridView()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gruppo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Feb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Giu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sett = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ott = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkRefresh = New System.Windows.Forms.LinkLabel()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmbTipoFiltro = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lnkLog = New System.Windows.Forms.LinkLabel()
        Me.lnkDisattiva = New System.Windows.Forms.LinkLabel()
        Me.lnkAttiva = New System.Windows.Forms.LinkLabel()
        Me.lnkDelFiltro = New System.Windows.Forms.LinkLabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.webAnte = New System.Windows.Forms.WebBrowser()
        Me.lnkAggRiepilogo = New System.Windows.Forms.LinkLabel()
        CType(Me.dgMarkWeb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lnkNew
        '
        Me.lnkNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(96, 3)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(73, 27)
        Me.lnkNew.TabIndex = 62
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuova"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgMarkWeb
        '
        Me.dgMarkWeb.AllowUserToAddRows = False
        Me.dgMarkWeb.AllowUserToDeleteRows = False
        Me.dgMarkWeb.AllowUserToOrderColumns = True
        Me.dgMarkWeb.AllowUserToResizeRows = False
        Me.dgMarkWeb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgMarkWeb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgMarkWeb.BackgroundColor = System.Drawing.Color.White
        Me.dgMarkWeb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgMarkWeb.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgMarkWeb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMarkWeb.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nome, Me.Gruppo, Me.Gen, Me.Feb, Me.Mar, Me.Apr, Me.Mag, Me.Giu, Me.Lug, Me.Ago, Me.Sett, Me.Ott, Me.Nov, Me.Dic})
        Me.dgMarkWeb.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgMarkWeb.Location = New System.Drawing.Point(3, 35)
        Me.dgMarkWeb.MultiSelect = False
        Me.dgMarkWeb.Name = "dgMarkWeb"
        Me.dgMarkWeb.RowHeadersVisible = False
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White
        Me.dgMarkWeb.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgMarkWeb.RowTemplate.Height = 30
        Me.dgMarkWeb.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMarkWeb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMarkWeb.ShowEditingIcon = False
        Me.dgMarkWeb.Size = New System.Drawing.Size(1079, 531)
        Me.dgMarkWeb.TabIndex = 63
        '
        'Nome
        '
        Me.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Nome.DataPropertyName = "Nome"
        Me.Nome.HeaderText = "Nome"
        Me.Nome.Name = "Nome"
        Me.Nome.Width = 160
        '
        'Gruppo
        '
        Me.Gruppo.DataPropertyName = "NomeGruppoStr"
        Me.Gruppo.HeaderText = "Gruppo"
        Me.Gruppo.Name = "Gruppo"
        Me.Gruppo.Width = 72
        '
        'Gen
        '
        Me.Gen.DataPropertyName = "SpuntaGen"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Gen.DefaultCellStyle = DataGridViewCellStyle1
        Me.Gen.HeaderText = "Gen"
        Me.Gen.Name = "Gen"
        Me.Gen.Width = 53
        '
        'Feb
        '
        Me.Feb.DataPropertyName = "SpuntaFeb"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Feb.DefaultCellStyle = DataGridViewCellStyle2
        Me.Feb.HeaderText = "Feb"
        Me.Feb.Name = "Feb"
        Me.Feb.Width = 51
        '
        'Mar
        '
        Me.Mar.DataPropertyName = "SpuntaMar"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Mar.DefaultCellStyle = DataGridViewCellStyle3
        Me.Mar.HeaderText = "Mar"
        Me.Mar.Name = "Mar"
        Me.Mar.Width = 53
        '
        'Apr
        '
        Me.Apr.DataPropertyName = "SpuntaApr"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Apr.DefaultCellStyle = DataGridViewCellStyle4
        Me.Apr.HeaderText = "Apr"
        Me.Apr.Name = "Apr"
        Me.Apr.Width = 51
        '
        'Mag
        '
        Me.Mag.DataPropertyName = "SpuntaMag"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Mag.DefaultCellStyle = DataGridViewCellStyle5
        Me.Mag.HeaderText = "Mag"
        Me.Mag.Name = "Mag"
        Me.Mag.Width = 56
        '
        'Giu
        '
        Me.Giu.DataPropertyName = "SpuntaGiu"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Giu.DefaultCellStyle = DataGridViewCellStyle6
        Me.Giu.HeaderText = "Giu"
        Me.Giu.Name = "Giu"
        Me.Giu.Width = 50
        '
        'Lug
        '
        Me.Lug.DataPropertyName = "SpuntaLug"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Lug.DefaultCellStyle = DataGridViewCellStyle7
        Me.Lug.HeaderText = "Lug"
        Me.Lug.Name = "Lug"
        Me.Lug.Width = 52
        '
        'Ago
        '
        Me.Ago.DataPropertyName = "SpuntaAgo"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Ago.DefaultCellStyle = DataGridViewCellStyle8
        Me.Ago.HeaderText = "Ago"
        Me.Ago.Name = "Ago"
        Me.Ago.Width = 54
        '
        'Sett
        '
        Me.Sett.DataPropertyName = "SpuntaSet"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Sett.DefaultCellStyle = DataGridViewCellStyle9
        Me.Sett.HeaderText = "Set"
        Me.Sett.Name = "Sett"
        Me.Sett.Width = 48
        '
        'Ott
        '
        Me.Ott.DataPropertyName = "SpuntaOtt"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Ott.DefaultCellStyle = DataGridViewCellStyle10
        Me.Ott.HeaderText = "Ott"
        Me.Ott.Name = "Ott"
        Me.Ott.Width = 49
        '
        'Nov
        '
        Me.Nov.DataPropertyName = "SpuntaNov"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Nov.DefaultCellStyle = DataGridViewCellStyle11
        Me.Nov.HeaderText = "Nov"
        Me.Nov.Name = "Nov"
        Me.Nov.Width = 54
        '
        'Dic
        '
        Me.Dic.DataPropertyName = "SpuntaDic"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Dic.DefaultCellStyle = DataGridViewCellStyle12
        Me.Dic.HeaderText = "Dic"
        Me.Dic.Name = "Dic"
        Me.Dic.Width = 49
        '
        'lnkRefresh
        '
        Me.lnkRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRefresh.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRefresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRefresh.Location = New System.Drawing.Point(6, 3)
        Me.lnkRefresh.Name = "lnkRefresh"
        Me.lnkRefresh.Size = New System.Drawing.Size(84, 27)
        Me.lnkRefresh.TabIndex = 64
        Me.lnkRefresh.TabStop = True
        Me.lnkRefresh.Text = "Aggiorna"
        Me.lnkRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabPage1)
        Me.TabMain.Controls.Add(Me.TabPage2)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1096, 600)
        Me.TabMain.TabIndex = 65
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmbTipoFiltro)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.lnkLog)
        Me.TabPage1.Controls.Add(Me.lnkDisattiva)
        Me.TabPage1.Controls.Add(Me.lnkAttiva)
        Me.TabPage1.Controls.Add(Me.lnkDelFiltro)
        Me.TabPage1.Controls.Add(Me.dgMarkWeb)
        Me.TabPage1.Controls.Add(Me.lnkRefresh)
        Me.TabPage1.Controls.Add(Me.lnkNew)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1088, 572)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Campagne Marketing"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmbTipoFiltro
        '
        Me.cmbTipoFiltro.DisplayMember = "0"
        Me.cmbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoFiltro.FormattingEnabled = True
        Me.cmbTipoFiltro.Location = New System.Drawing.Point(757, 6)
        Me.cmbTipoFiltro.Name = "cmbTipoFiltro"
        Me.cmbTipoFiltro.Size = New System.Drawing.Size(214, 23)
        Me.cmbTipoFiltro.TabIndex = 155
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(654, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 15)
        Me.Label15.TabIndex = 154
        Me.Label15.Text = "Tipo campagna:"
        '
        'lnkLog
        '
        Me.lnkLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkLog.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkLog.Image = Global.Former.My.Resources.Resources._Log
        Me.lnkLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkLog.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkLog.Location = New System.Drawing.Point(1016, 3)
        Me.lnkLog.Name = "lnkLog"
        Me.lnkLog.Size = New System.Drawing.Size(66, 27)
        Me.lnkLog.TabIndex = 68
        Me.lnkLog.TabStop = True
        Me.lnkLog.Text = "Log"
        Me.lnkLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDisattiva
        '
        Me.lnkDisattiva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDisattiva.Image = Global.Former.My.Resources.Resources._PreventivoOff
        Me.lnkDisattiva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDisattiva.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDisattiva.Location = New System.Drawing.Point(460, 3)
        Me.lnkDisattiva.Name = "lnkDisattiva"
        Me.lnkDisattiva.Size = New System.Drawing.Size(147, 27)
        Me.lnkDisattiva.TabIndex = 67
        Me.lnkDisattiva.TabStop = True
        Me.lnkDisattiva.Text = "Disattiva Campagna"
        Me.lnkDisattiva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkAttiva
        '
        Me.lnkAttiva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAttiva.Image = Global.Former.My.Resources.Resources._PreventivoOn
        Me.lnkAttiva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAttiva.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAttiva.Location = New System.Drawing.Point(328, 3)
        Me.lnkAttiva.Name = "lnkAttiva"
        Me.lnkAttiva.Size = New System.Drawing.Size(126, 27)
        Me.lnkAttiva.TabIndex = 66
        Me.lnkAttiva.TabStop = True
        Me.lnkAttiva.Text = "Attiva Campagna"
        Me.lnkAttiva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkDelFiltro
        '
        Me.lnkDelFiltro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelFiltro.Image = Global.Former.My.Resources.Resources._Elimina
        Me.lnkDelFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelFiltro.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelFiltro.Location = New System.Drawing.Point(175, 3)
        Me.lnkDelFiltro.Name = "lnkDelFiltro"
        Me.lnkDelFiltro.Size = New System.Drawing.Size(77, 27)
        Me.lnkDelFiltro.TabIndex = 65
        Me.lnkDelFiltro.TabStop = True
        Me.lnkDelFiltro.Text = "Elimina"
        Me.lnkDelFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.webAnte)
        Me.TabPage2.Controls.Add(Me.lnkAggRiepilogo)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1088, 572)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Riassunto"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'webAnte
        '
        Me.webAnte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webAnte.Location = New System.Drawing.Point(6, 33)
        Me.webAnte.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webAnte.Name = "webAnte"
        Me.webAnte.Size = New System.Drawing.Size(787, 533)
        Me.webAnte.TabIndex = 66
        '
        'lnkAggRiepilogo
        '
        Me.lnkAggRiepilogo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggRiepilogo.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggRiepilogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggRiepilogo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggRiepilogo.Location = New System.Drawing.Point(6, 3)
        Me.lnkAggRiepilogo.Name = "lnkAggRiepilogo"
        Me.lnkAggRiepilogo.Size = New System.Drawing.Size(84, 27)
        Me.lnkAggRiepilogo.TabIndex = 65
        Me.lnkAggRiepilogo.TabStop = True
        Me.lnkAggRiepilogo.Text = "Aggiorna"
        Me.lnkAggRiepilogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucMarketingWeb
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TabMain)
        Me.Name = "ucMarketingWeb"
        Me.Size = New System.Drawing.Size(1096, 600)
        CType(Me.dgMarkWeb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
    Friend WithEvents dgMarkWeb As System.Windows.Forms.DataGridView
    Friend WithEvents lnkRefresh As System.Windows.Forms.LinkLabel
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lnkDelFiltro As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDisattiva As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAttiva As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkLog As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAggRiepilogo As System.Windows.Forms.LinkLabel
    Friend WithEvents webAnte As System.Windows.Forms.WebBrowser
    Friend WithEvents cmbTipoFiltro As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Nome As DataGridViewTextBoxColumn
    Friend WithEvents Gruppo As DataGridViewTextBoxColumn
    Friend WithEvents Gen As DataGridViewTextBoxColumn
    Friend WithEvents Feb As DataGridViewTextBoxColumn
    Friend WithEvents Mar As DataGridViewTextBoxColumn
    Friend WithEvents Apr As DataGridViewTextBoxColumn
    Friend WithEvents Mag As DataGridViewTextBoxColumn
    Friend WithEvents Giu As DataGridViewTextBoxColumn
    Friend WithEvents Lug As DataGridViewTextBoxColumn
    Friend WithEvents Ago As DataGridViewTextBoxColumn
    Friend WithEvents Sett As DataGridViewTextBoxColumn
    Friend WithEvents Ott As DataGridViewTextBoxColumn
    Friend WithEvents Nov As DataGridViewTextBoxColumn
    Friend WithEvents Dic As DataGridViewTextBoxColumn
End Class
