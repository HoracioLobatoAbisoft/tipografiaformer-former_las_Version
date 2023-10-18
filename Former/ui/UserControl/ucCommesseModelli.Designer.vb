<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCommesseModelli
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.dgModelliCommessa = New Former.ucDataGridView()
        Me.Anteprima = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Job = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Categoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormatiProdotto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Attivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FrSeStessa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFormProd = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkShowFromGanging = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbMacchinario = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbFormMacchina = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuMain = New System.Windows.Forms.MenuStrip()
        Me.DuplicaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AggiungiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RimuoviToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttivaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisattivaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        CType(Me.dgModelliCommessa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.MenuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCerca
        '
        Me.txtCerca.Location = New System.Drawing.Point(53, 9)
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(139, 23)
        Me.txtCerca.TabIndex = 97
        '
        'dgModelliCommessa
        '
        Me.dgModelliCommessa.AllowUserToAddRows = False
        Me.dgModelliCommessa.AllowUserToDeleteRows = False
        Me.dgModelliCommessa.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgModelliCommessa.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgModelliCommessa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgModelliCommessa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgModelliCommessa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgModelliCommessa.BackgroundColor = System.Drawing.Color.White
        Me.dgModelliCommessa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgModelliCommessa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgModelliCommessa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgModelliCommessa.ColumnHeadersHeight = 20
        Me.dgModelliCommessa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgModelliCommessa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Anteprima, Me.Nome, Me.Job, Me.Categoria, Me.FormatiProdotto, Me.Attivo, Me.FR, Me.FrSeStessa})
        Me.dgModelliCommessa.CustomVirtualMode = False
        Me.dgModelliCommessa.DataSourceVirtual = Nothing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgModelliCommessa.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgModelliCommessa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgModelliCommessa.EnableHeadersVisualStyles = False
        Me.dgModelliCommessa.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgModelliCommessa.Location = New System.Drawing.Point(3, 105)
        Me.dgModelliCommessa.MultiSelect = False
        Me.dgModelliCommessa.Name = "dgModelliCommessa"
        Me.dgModelliCommessa.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgModelliCommessa.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgModelliCommessa.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgModelliCommessa.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgModelliCommessa.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgModelliCommessa.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgModelliCommessa.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgModelliCommessa.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgModelliCommessa.ScrollManuale = False
        Me.dgModelliCommessa.ScrollValue = 0
        Me.dgModelliCommessa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgModelliCommessa.Size = New System.Drawing.Size(1195, 566)
        Me.dgModelliCommessa.TabIndex = 92
        Me.dgModelliCommessa.TabStop = False
        '
        'Anteprima
        '
        Me.Anteprima.DataPropertyName = "ImageAnteprimaLista"
        Me.Anteprima.HeaderText = "Anteprima"
        Me.Anteprima.Name = "Anteprima"
        Me.Anteprima.ReadOnly = True
        Me.Anteprima.Width = 68
        '
        'Nome
        '
        Me.Nome.DataPropertyName = "Nome"
        Me.Nome.HeaderText = "Nome"
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 64
        '
        'Job
        '
        Me.Job.DataPropertyName = "Job"
        Me.Job.HeaderText = "Job"
        Me.Job.Name = "Job"
        Me.Job.ReadOnly = True
        Me.Job.Width = 49
        '
        'Categoria
        '
        Me.Categoria.DataPropertyName = "NomeCategoria"
        Me.Categoria.HeaderText = "Categoria"
        Me.Categoria.Name = "Categoria"
        Me.Categoria.ReadOnly = True
        Me.Categoria.Width = 82
        '
        'FormatiProdotto
        '
        Me.FormatiProdotto.DataPropertyName = "FormatiProdottoStr"
        Me.FormatiProdotto.HeaderText = "Formati Prodotto"
        Me.FormatiProdotto.Name = "FormatiProdotto"
        Me.FormatiProdotto.ReadOnly = True
        Me.FormatiProdotto.Width = 122
        '
        'Attivo
        '
        Me.Attivo.DataPropertyName = "AttivoStr"
        Me.Attivo.HeaderText = "Attivo"
        Me.Attivo.Name = "Attivo"
        Me.Attivo.ReadOnly = True
        Me.Attivo.Width = 63
        '
        'FR
        '
        Me.FR.DataPropertyName = "FronteRetroStr"
        Me.FR.HeaderText = "FR"
        Me.FR.Name = "FR"
        Me.FR.ReadOnly = True
        Me.FR.Width = 44
        '
        'FrSeStessa
        '
        Me.FrSeStessa.DataPropertyName = "FRSuSeStessaStr"
        Me.FrSeStessa.HeaderText = "Fr su se stessa"
        Me.FrSeStessa.Name = "FrSeStessa"
        Me.FrSeStessa.ReadOnly = True
        Me.FrSeStessa.Width = 104
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(6, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Cerca:"
        '
        'cmbFormProd
        '
        Me.cmbFormProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFormProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFormProd.FormattingEnabled = True
        Me.cmbFormProd.Location = New System.Drawing.Point(306, 9)
        Me.cmbFormProd.Name = "cmbFormProd"
        Me.cmbFormProd.Size = New System.Drawing.Size(180, 23)
        Me.cmbFormProd.TabIndex = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(198, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 15)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Formato Prodotto"
        '
        'chkShowFromGanging
        '
        Me.chkShowFromGanging.AutoSize = True
        Me.chkShowFromGanging.Location = New System.Drawing.Point(9, 38)
        Me.chkShowFromGanging.Name = "chkShowFromGanging"
        Me.chkShowFromGanging.Size = New System.Drawing.Size(173, 19)
        Me.chkShowFromGanging.TabIndex = 101
        Me.chkShowFromGanging.Text = "Mostra modelli dal Ganging"
        Me.chkShowFromGanging.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbMacchinario)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbFormMacchina)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.chkShowFromGanging)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbFormProd)
        Me.Panel1.Controls.Add(Me.txtCerca)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lnkCerca)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1201, 68)
        Me.Panel1.TabIndex = 102
        '
        'cmbMacchinario
        '
        Me.cmbMacchinario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMacchinario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMacchinario.FormattingEnabled = True
        Me.cmbMacchinario.Location = New System.Drawing.Point(870, 9)
        Me.cmbMacchinario.Name = "cmbMacchinario"
        Me.cmbMacchinario.Size = New System.Drawing.Size(180, 23)
        Me.cmbMacchinario.TabIndex = 105
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(791, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 15)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "Macchinario"
        '
        'cmbFormMacchina
        '
        Me.cmbFormMacchina.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFormMacchina.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFormMacchina.FormattingEnabled = True
        Me.cmbFormMacchina.Location = New System.Drawing.Point(605, 9)
        Me.cmbFormMacchina.Name = "cmbFormMacchina"
        Me.cmbFormMacchina.Size = New System.Drawing.Size(180, 23)
        Me.cmbFormMacchina.TabIndex = 103
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(492, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 15)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Formato Macchina"
        '
        'MenuMain
        '
        Me.MenuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DuplicaToolStripMenuItem, Me.AggiungiToolStripMenuItem, Me.ModificaToolStripMenuItem, Me.RimuoviToolStripMenuItem, Me.AttivaToolStripMenuItem1, Me.DisattivaToolStripMenuItem1})
        Me.MenuMain.Location = New System.Drawing.Point(0, 68)
        Me.MenuMain.Name = "MenuMain"
        Me.MenuMain.Size = New System.Drawing.Size(1201, 34)
        Me.MenuMain.TabIndex = 103
        Me.MenuMain.Text = "MenuStrip1"
        '
        'DuplicaToolStripMenuItem
        '
        Me.DuplicaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Duplica
        Me.DuplicaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DuplicaToolStripMenuItem.Name = "DuplicaToolStripMenuItem"
        Me.DuplicaToolStripMenuItem.Size = New System.Drawing.Size(85, 30)
        Me.DuplicaToolStripMenuItem.Text = "Duplica"
        '
        'AggiungiToolStripMenuItem
        '
        Me.AggiungiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.AggiungiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AggiungiToolStripMenuItem.Name = "AggiungiToolStripMenuItem"
        Me.AggiungiToolStripMenuItem.Size = New System.Drawing.Size(94, 30)
        Me.AggiungiToolStripMenuItem.Text = "Aggiungi"
        '
        'ModificaToolStripMenuItem
        '
        Me.ModificaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Modifica
        Me.ModificaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificaToolStripMenuItem.Name = "ModificaToolStripMenuItem"
        Me.ModificaToolStripMenuItem.Size = New System.Drawing.Size(92, 30)
        Me.ModificaToolStripMenuItem.Text = "Modifica"
        '
        'RimuoviToolStripMenuItem
        '
        Me.RimuoviToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Elimina
        Me.RimuoviToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RimuoviToolStripMenuItem.Name = "RimuoviToolStripMenuItem"
        Me.RimuoviToolStripMenuItem.Size = New System.Drawing.Size(89, 30)
        Me.RimuoviToolStripMenuItem.Text = "Rimuovi"
        '
        'AttivaToolStripMenuItem1
        '
        Me.AttivaToolStripMenuItem1.Image = Global.Former.My.Resources.Resources._StatoAttivo
        Me.AttivaToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AttivaToolStripMenuItem1.Name = "AttivaToolStripMenuItem1"
        Me.AttivaToolStripMenuItem1.Size = New System.Drawing.Size(76, 30)
        Me.AttivaToolStripMenuItem1.Text = "Attiva"
        '
        'DisattivaToolStripMenuItem1
        '
        Me.DisattivaToolStripMenuItem1.Image = Global.Former.My.Resources.Resources._StatoDisattivo
        Me.DisattivaToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DisattivaToolStripMenuItem1.Name = "DisattivaToolStripMenuItem1"
        Me.DisattivaToolStripMenuItem1.Size = New System.Drawing.Size(90, 30)
        Me.DisattivaToolStripMenuItem1.Text = "Disattiva"
        '
        'lnkCerca
        '
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(1068, 19)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(68, 30)
        Me.lnkCerca.TabIndex = 98
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Cerca"
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucCommesseModelli
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.dgModelliCommessa)
        Me.Controls.Add(Me.MenuMain)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucCommesseModelli"
        Me.Size = New System.Drawing.Size(1201, 675)
        CType(Me.dgModelliCommessa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuMain.ResumeLayout(False)
        Me.MenuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lnkCerca As LinkLabel
    Friend WithEvents txtCerca As TextBox
    Friend WithEvents dgModelliCommessa As ucDataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbFormProd As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Anteprima As DataGridViewImageColumn
    Friend WithEvents Nome As DataGridViewTextBoxColumn
    Friend WithEvents Job As DataGridViewTextBoxColumn
    Friend WithEvents Categoria As DataGridViewTextBoxColumn
    Friend WithEvents FormatiProdotto As DataGridViewTextBoxColumn
    Friend WithEvents Attivo As DataGridViewTextBoxColumn
    Friend WithEvents FR As DataGridViewTextBoxColumn
    Friend WithEvents FrSeStessa As DataGridViewTextBoxColumn
    Friend WithEvents chkShowFromGanging As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuMain As MenuStrip
    Friend WithEvents DuplicaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AggiungiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RimuoviToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AttivaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DisattivaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents cmbMacchinario As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbFormMacchina As ComboBox
    Friend WithEvents Label3 As Label
End Class
