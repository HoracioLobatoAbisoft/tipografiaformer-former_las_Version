<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListinoFustelle
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbMain = New System.Windows.Forms.TabControl()
        Me.tpTipoFustella = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCat = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPrev = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnAggTipo = New System.Windows.Forms.Button()
        Me.txtProfondita = New Former.ucNumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBase = New Former.ucNumericTextBox()
        Me.txtAltezza = New Former.ucNumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnShowOrd = New System.Windows.Forms.Button()
        Me.btnEditTipo = New System.Windows.Forms.Button()
        Me.btnAddTipo = New System.Windows.Forms.Button()
        Me.DgTipoFustelle = New System.Windows.Forms.DataGridView()
        Me.ImgRiferimento128 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Preventivazione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodiceD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Base = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Altezza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Profondita = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Orientabile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Disponibile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Categorie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpCatFustelle = New System.Windows.Forms.TabPage()
        Me.btnDelCat = New System.Windows.Forms.Button()
        Me.btnEditCat = New System.Windows.Forms.Button()
        Me.btnAddCat = New System.Windows.Forms.Button()
        Me.btnAggiornaCat = New System.Windows.Forms.Button()
        Me.dgCatFustelle = New System.Windows.Forms.DataGridView()
        Me.CategoriaDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Anima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LarghezzaMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpFustelle = New System.Windows.Forms.TabPage()
        Me.btnDelFustella = New System.Windows.Forms.Button()
        Me.btnEditFustella = New System.Windows.Forms.Button()
        Me.btnAddFustella = New System.Windows.Forms.Button()
        Me.btnAggFustelle = New System.Windows.Forms.Button()
        Me.DgFustelle = New System.Windows.Forms.DataGridView()
        Me.Codice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoFustella = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ripetizioni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Annotazioni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbMain.SuspendLayout()
        Me.tpTipoFustella.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgTipoFustelle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCatFustelle.SuspendLayout()
        CType(Me.dgCatFustelle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpFustelle.SuspendLayout()
        CType(Me.DgFustelle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbMain
        '
        Me.tbMain.Controls.Add(Me.tpTipoFustella)
        Me.tbMain.Controls.Add(Me.tpCatFustelle)
        Me.tbMain.Controls.Add(Me.tpFustelle)
        Me.tbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbMain.Location = New System.Drawing.Point(0, 0)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.SelectedIndex = 0
        Me.tbMain.Size = New System.Drawing.Size(1297, 747)
        Me.tbMain.TabIndex = 0
        '
        'tpTipoFustella
        '
        Me.tpTipoFustella.Controls.Add(Me.GroupBox1)
        Me.tpTipoFustella.Controls.Add(Me.btnShowOrd)
        Me.tpTipoFustella.Controls.Add(Me.btnEditTipo)
        Me.tpTipoFustella.Controls.Add(Me.btnAddTipo)
        Me.tpTipoFustella.Controls.Add(Me.DgTipoFustelle)
        Me.tpTipoFustella.Location = New System.Drawing.Point(4, 24)
        Me.tpTipoFustella.Name = "tpTipoFustella"
        Me.tpTipoFustella.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTipoFustella.Size = New System.Drawing.Size(1289, 719)
        Me.tpTipoFustella.TabIndex = 0
        Me.tpTipoFustella.Text = "Tipologie di Fustelle"
        Me.tpTipoFustella.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbCat)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbPrev)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnReset)
        Me.GroupBox1.Controls.Add(Me.btnAggTipo)
        Me.GroupBox1.Controls.Add(Me.txtProfondita)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtBase)
        Me.GroupBox1.Controls.Add(Me.txtAltezza)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(930, 45)
        Me.GroupBox1.TabIndex = 109
        Me.GroupBox1.TabStop = False
        '
        'cmbCat
        '
        Me.cmbCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(731, 16)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(138, 23)
        Me.cmbCat.TabIndex = 113
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(667, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Categoria"
        '
        'cmbPrev
        '
        Me.cmbPrev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrev.FormattingEnabled = True
        Me.cmbPrev.Location = New System.Drawing.Point(509, 17)
        Me.cmbPrev.Name = "cmbPrev"
        Me.cmbPrev.Size = New System.Drawing.Size(152, 23)
        Me.cmbPrev.TabIndex = 111
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(413, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "Preventivazione"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(875, 16)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(48, 23)
        Me.btnReset.TabIndex = 109
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnAggTipo
        '
        Me.btnAggTipo.BackColor = System.Drawing.Color.White
        Me.btnAggTipo.FlatAppearance.BorderSize = 0
        Me.btnAggTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggTipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggTipo.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggTipo.Location = New System.Drawing.Point(6, 11)
        Me.btnAggTipo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggTipo.Name = "btnAggTipo"
        Me.btnAggTipo.Size = New System.Drawing.Size(95, 32)
        Me.btnAggTipo.TabIndex = 99
        Me.btnAggTipo.Text = "Aggiorna"
        Me.btnAggTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggTipo.UseVisualStyleBackColor = False
        '
        'txtProfondita
        '
        Me.txtProfondita.Location = New System.Drawing.Point(363, 17)
        Me.txtProfondita.My_AccettaNegativi = False
        Me.txtProfondita.My_AllowOnlyInteger = True
        Me.txtProfondita.My_DefaultValue = 0
        Me.txtProfondita.My_MaxValue = 1.0E+10!
        Me.txtProfondita.My_MinValue = 0!
        Me.txtProfondita.My_ReplaceWithDefaultValue = True
        Me.txtProfondita.Name = "txtProfondita"
        Me.txtProfondita.Size = New System.Drawing.Size(44, 23)
        Me.txtProfondita.TabIndex = 108
        Me.txtProfondita.Text = "0"
        Me.txtProfondita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(107, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 15)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Base"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(294, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Profondita"
        '
        'txtBase
        '
        Me.txtBase.Location = New System.Drawing.Point(144, 17)
        Me.txtBase.My_AccettaNegativi = False
        Me.txtBase.My_AllowOnlyInteger = True
        Me.txtBase.My_DefaultValue = 0
        Me.txtBase.My_MaxValue = 1.0E+10!
        Me.txtBase.My_MinValue = 0!
        Me.txtBase.My_ReplaceWithDefaultValue = True
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(44, 23)
        Me.txtBase.TabIndex = 104
        Me.txtBase.Text = "0"
        Me.txtBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAltezza
        '
        Me.txtAltezza.Location = New System.Drawing.Point(244, 17)
        Me.txtAltezza.My_AccettaNegativi = False
        Me.txtAltezza.My_AllowOnlyInteger = True
        Me.txtAltezza.My_DefaultValue = 0
        Me.txtAltezza.My_MaxValue = 1.0E+10!
        Me.txtAltezza.My_MinValue = 0!
        Me.txtAltezza.My_ReplaceWithDefaultValue = True
        Me.txtAltezza.Name = "txtAltezza"
        Me.txtAltezza.Size = New System.Drawing.Size(44, 23)
        Me.txtAltezza.TabIndex = 106
        Me.txtAltezza.Text = "0"
        Me.txtAltezza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(194, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Altezza"
        '
        'btnShowOrd
        '
        Me.btnShowOrd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowOrd.BackColor = System.Drawing.Color.White
        Me.btnShowOrd.FlatAppearance.BorderSize = 0
        Me.btnShowOrd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowOrd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnShowOrd.Image = Global.Former.My.Resources.Resources._Ordine
        Me.btnShowOrd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowOrd.Location = New System.Drawing.Point(1137, 17)
        Me.btnShowOrd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnShowOrd.Name = "btnShowOrd"
        Me.btnShowOrd.Size = New System.Drawing.Size(115, 32)
        Me.btnShowOrd.TabIndex = 102
        Me.btnShowOrd.Text = "Mostra Ordini"
        Me.btnShowOrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShowOrd.UseVisualStyleBackColor = False
        '
        'btnEditTipo
        '
        Me.btnEditTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditTipo.BackColor = System.Drawing.Color.White
        Me.btnEditTipo.FlatAppearance.BorderSize = 0
        Me.btnEditTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditTipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEditTipo.Image = Global.Former.My.Resources.Resources._Modifica
        Me.btnEditTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditTipo.Location = New System.Drawing.Point(1037, 17)
        Me.btnEditTipo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEditTipo.Name = "btnEditTipo"
        Me.btnEditTipo.Size = New System.Drawing.Size(94, 32)
        Me.btnEditTipo.TabIndex = 101
        Me.btnEditTipo.Text = "Modifica"
        Me.btnEditTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditTipo.UseVisualStyleBackColor = False
        '
        'btnAddTipo
        '
        Me.btnAddTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddTipo.BackColor = System.Drawing.Color.White
        Me.btnAddTipo.FlatAppearance.BorderSize = 0
        Me.btnAddTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddTipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAddTipo.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnAddTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddTipo.Location = New System.Drawing.Point(942, 17)
        Me.btnAddTipo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAddTipo.Name = "btnAddTipo"
        Me.btnAddTipo.Size = New System.Drawing.Size(89, 32)
        Me.btnAddTipo.TabIndex = 100
        Me.btnAddTipo.Text = "Aggiungi"
        Me.btnAddTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddTipo.UseVisualStyleBackColor = False
        '
        'DgTipoFustelle
        '
        Me.DgTipoFustelle.AllowUserToAddRows = False
        Me.DgTipoFustelle.AllowUserToDeleteRows = False
        Me.DgTipoFustelle.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgTipoFustelle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgTipoFustelle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgTipoFustelle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgTipoFustelle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgTipoFustelle.BackgroundColor = System.Drawing.Color.White
        Me.DgTipoFustelle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgTipoFustelle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgTipoFustelle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgTipoFustelle.ColumnHeadersHeight = 20
        Me.DgTipoFustelle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgTipoFustelle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ImgRiferimento128, Me.Preventivazione, Me.CodiceD, Me.Base, Me.Altezza, Me.Profondita, Me.Orientabile, Me.Disponibile, Me.Categorie})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgTipoFustelle.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgTipoFustelle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgTipoFustelle.EnableHeadersVisualStyles = False
        Me.DgTipoFustelle.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgTipoFustelle.Location = New System.Drawing.Point(6, 57)
        Me.DgTipoFustelle.MultiSelect = False
        Me.DgTipoFustelle.Name = "DgTipoFustelle"
        Me.DgTipoFustelle.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgTipoFustelle.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgTipoFustelle.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgTipoFustelle.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgTipoFustelle.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgTipoFustelle.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgTipoFustelle.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgTipoFustelle.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgTipoFustelle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgTipoFustelle.Size = New System.Drawing.Size(1277, 650)
        Me.DgTipoFustelle.TabIndex = 58
        Me.DgTipoFustelle.TabStop = False
        '
        'ImgRiferimento128
        '
        Me.ImgRiferimento128.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ImgRiferimento128.DataPropertyName = "ImgRiferimento128"
        Me.ImgRiferimento128.HeaderText = "Img"
        Me.ImgRiferimento128.MinimumWidth = 128
        Me.ImgRiferimento128.Name = "ImgRiferimento128"
        Me.ImgRiferimento128.ReadOnly = True
        Me.ImgRiferimento128.Width = 128
        '
        'Preventivazione
        '
        Me.Preventivazione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Preventivazione.DataPropertyName = "PreventivazioneStr"
        Me.Preventivazione.HeaderText = "PreventivazioneStr"
        Me.Preventivazione.Name = "Preventivazione"
        Me.Preventivazione.ReadOnly = True
        Me.Preventivazione.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Preventivazione.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Preventivazione.Width = 109
        '
        'CodiceD
        '
        Me.CodiceD.DataPropertyName = "Codice"
        Me.CodiceD.HeaderText = "Codice"
        Me.CodiceD.Name = "CodiceD"
        Me.CodiceD.ReadOnly = True
        Me.CodiceD.Width = 68
        '
        'Base
        '
        Me.Base.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Base.DataPropertyName = "Base"
        Me.Base.HeaderText = "Base"
        Me.Base.Name = "Base"
        Me.Base.ReadOnly = True
        Me.Base.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Base.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Base.Width = 36
        '
        'Altezza
        '
        Me.Altezza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Altezza.DataPropertyName = "Altezza"
        Me.Altezza.HeaderText = "Altezza"
        Me.Altezza.Name = "Altezza"
        Me.Altezza.ReadOnly = True
        Me.Altezza.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Altezza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Altezza.Width = 49
        '
        'Profondita
        '
        Me.Profondita.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Profondita.DataPropertyName = "Profondita"
        Me.Profondita.HeaderText = "Profondita"
        Me.Profondita.Name = "Profondita"
        Me.Profondita.ReadOnly = True
        Me.Profondita.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Profondita.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Profondita.Width = 68
        '
        'Orientabile
        '
        Me.Orientabile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Orientabile.DataPropertyName = "OrientabileStr"
        Me.Orientabile.HeaderText = "Orientabile"
        Me.Orientabile.Name = "Orientabile"
        Me.Orientabile.ReadOnly = True
        Me.Orientabile.Width = 89
        '
        'Disponibile
        '
        Me.Disponibile.DataPropertyName = "DisponibileStr"
        Me.Disponibile.HeaderText = "Effettivamente Disponibile"
        Me.Disponibile.Name = "Disponibile"
        Me.Disponibile.ReadOnly = True
        Me.Disponibile.Width = 170
        '
        'Categorie
        '
        Me.Categorie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Categorie.DataPropertyName = "CategorieStr"
        Me.Categorie.HeaderText = "Categorie"
        Me.Categorie.MinimumWidth = 200
        Me.Categorie.Name = "Categorie"
        Me.Categorie.ReadOnly = True
        Me.Categorie.Width = 200
        '
        'tpCatFustelle
        '
        Me.tpCatFustelle.Controls.Add(Me.btnDelCat)
        Me.tpCatFustelle.Controls.Add(Me.btnEditCat)
        Me.tpCatFustelle.Controls.Add(Me.btnAddCat)
        Me.tpCatFustelle.Controls.Add(Me.btnAggiornaCat)
        Me.tpCatFustelle.Controls.Add(Me.dgCatFustelle)
        Me.tpCatFustelle.Location = New System.Drawing.Point(4, 24)
        Me.tpCatFustelle.Name = "tpCatFustelle"
        Me.tpCatFustelle.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCatFustelle.Size = New System.Drawing.Size(1289, 719)
        Me.tpCatFustelle.TabIndex = 1
        Me.tpCatFustelle.Text = "Categorie di Fustelle"
        Me.tpCatFustelle.UseVisualStyleBackColor = True
        '
        'btnDelCat
        '
        Me.btnDelCat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelCat.BackColor = System.Drawing.Color.White
        Me.btnDelCat.FlatAppearance.BorderSize = 0
        Me.btnDelCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelCat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDelCat.Image = Global.Former.My.Resources.Resources._remove
        Me.btnDelCat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelCat.Location = New System.Drawing.Point(1197, 7)
        Me.btnDelCat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDelCat.Name = "btnDelCat"
        Me.btnDelCat.Size = New System.Drawing.Size(86, 32)
        Me.btnDelCat.TabIndex = 106
        Me.btnDelCat.Text = "Rimuovi"
        Me.btnDelCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelCat.UseVisualStyleBackColor = False
        '
        'btnEditCat
        '
        Me.btnEditCat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditCat.BackColor = System.Drawing.Color.White
        Me.btnEditCat.FlatAppearance.BorderSize = 0
        Me.btnEditCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditCat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEditCat.Image = Global.Former.My.Resources.Resources._Modifica
        Me.btnEditCat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditCat.Location = New System.Drawing.Point(1097, 7)
        Me.btnEditCat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEditCat.Name = "btnEditCat"
        Me.btnEditCat.Size = New System.Drawing.Size(94, 32)
        Me.btnEditCat.TabIndex = 105
        Me.btnEditCat.Text = "Modifica"
        Me.btnEditCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditCat.UseVisualStyleBackColor = False
        '
        'btnAddCat
        '
        Me.btnAddCat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCat.BackColor = System.Drawing.Color.White
        Me.btnAddCat.FlatAppearance.BorderSize = 0
        Me.btnAddCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddCat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAddCat.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnAddCat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddCat.Location = New System.Drawing.Point(1002, 7)
        Me.btnAddCat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAddCat.Name = "btnAddCat"
        Me.btnAddCat.Size = New System.Drawing.Size(89, 32)
        Me.btnAddCat.TabIndex = 104
        Me.btnAddCat.Text = "Aggiungi"
        Me.btnAddCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddCat.UseVisualStyleBackColor = False
        '
        'btnAggiornaCat
        '
        Me.btnAggiornaCat.BackColor = System.Drawing.Color.White
        Me.btnAggiornaCat.FlatAppearance.BorderSize = 0
        Me.btnAggiornaCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiornaCat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggiornaCat.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiornaCat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiornaCat.Location = New System.Drawing.Point(6, 7)
        Me.btnAggiornaCat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggiornaCat.Name = "btnAggiornaCat"
        Me.btnAggiornaCat.Size = New System.Drawing.Size(95, 32)
        Me.btnAggiornaCat.TabIndex = 103
        Me.btnAggiornaCat.Text = "Aggiorna"
        Me.btnAggiornaCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggiornaCat.UseVisualStyleBackColor = False
        '
        'dgCatFustelle
        '
        Me.dgCatFustelle.AllowUserToAddRows = False
        Me.dgCatFustelle.AllowUserToDeleteRows = False
        Me.dgCatFustelle.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.dgCatFustelle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgCatFustelle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCatFustelle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgCatFustelle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgCatFustelle.BackgroundColor = System.Drawing.Color.White
        Me.dgCatFustelle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgCatFustelle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCatFustelle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgCatFustelle.ColumnHeadersHeight = 20
        Me.dgCatFustelle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgCatFustelle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CategoriaDescr, Me.Descrizione, Me.Anima, Me.LarghezzaMax})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCatFustelle.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgCatFustelle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCatFustelle.EnableHeadersVisualStyles = False
        Me.dgCatFustelle.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgCatFustelle.Location = New System.Drawing.Point(6, 48)
        Me.dgCatFustelle.MultiSelect = False
        Me.dgCatFustelle.Name = "dgCatFustelle"
        Me.dgCatFustelle.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCatFustelle.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgCatFustelle.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.dgCatFustelle.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgCatFustelle.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgCatFustelle.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgCatFustelle.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgCatFustelle.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCatFustelle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCatFustelle.Size = New System.Drawing.Size(1277, 665)
        Me.dgCatFustelle.TabIndex = 59
        Me.dgCatFustelle.TabStop = False
        '
        'CategoriaDescr
        '
        Me.CategoriaDescr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CategoriaDescr.DataPropertyName = "Categoria"
        Me.CategoriaDescr.HeaderText = "Categoria"
        Me.CategoriaDescr.Name = "CategoriaDescr"
        Me.CategoriaDescr.ReadOnly = True
        Me.CategoriaDescr.Width = 82
        '
        'Descrizione
        '
        Me.Descrizione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Descrizione.DataPropertyName = "Descrizione"
        Me.Descrizione.HeaderText = "Descrizione"
        Me.Descrizione.Name = "Descrizione"
        Me.Descrizione.ReadOnly = True
        Me.Descrizione.Width = 91
        '
        'Anima
        '
        Me.Anima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Anima.DataPropertyName = "AnimaStr"
        Me.Anima.HeaderText = "Anima"
        Me.Anima.Name = "Anima"
        Me.Anima.ReadOnly = True
        Me.Anima.Width = 66
        '
        'LarghezzaMax
        '
        Me.LarghezzaMax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LarghezzaMax.DataPropertyName = "LarghezzaMaxStr"
        Me.LarghezzaMax.HeaderText = "Diametro Massimo"
        Me.LarghezzaMax.Name = "LarghezzaMax"
        Me.LarghezzaMax.ReadOnly = True
        Me.LarghezzaMax.Width = 131
        '
        'tpFustelle
        '
        Me.tpFustelle.Controls.Add(Me.btnDelFustella)
        Me.tpFustelle.Controls.Add(Me.btnEditFustella)
        Me.tpFustelle.Controls.Add(Me.btnAddFustella)
        Me.tpFustelle.Controls.Add(Me.btnAggFustelle)
        Me.tpFustelle.Controls.Add(Me.DgFustelle)
        Me.tpFustelle.Location = New System.Drawing.Point(4, 24)
        Me.tpFustelle.Name = "tpFustelle"
        Me.tpFustelle.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFustelle.Size = New System.Drawing.Size(1289, 719)
        Me.tpFustelle.TabIndex = 2
        Me.tpFustelle.Text = "Fustelle"
        Me.tpFustelle.UseVisualStyleBackColor = True
        '
        'btnDelFustella
        '
        Me.btnDelFustella.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelFustella.BackColor = System.Drawing.Color.White
        Me.btnDelFustella.FlatAppearance.BorderSize = 0
        Me.btnDelFustella.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelFustella.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDelFustella.Image = Global.Former.My.Resources.Resources._remove
        Me.btnDelFustella.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelFustella.Location = New System.Drawing.Point(1197, 7)
        Me.btnDelFustella.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDelFustella.Name = "btnDelFustella"
        Me.btnDelFustella.Size = New System.Drawing.Size(86, 32)
        Me.btnDelFustella.TabIndex = 106
        Me.btnDelFustella.Text = "Rimuovi"
        Me.btnDelFustella.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelFustella.UseVisualStyleBackColor = False
        '
        'btnEditFustella
        '
        Me.btnEditFustella.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditFustella.BackColor = System.Drawing.Color.White
        Me.btnEditFustella.FlatAppearance.BorderSize = 0
        Me.btnEditFustella.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditFustella.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEditFustella.Image = Global.Former.My.Resources.Resources._Modifica
        Me.btnEditFustella.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditFustella.Location = New System.Drawing.Point(1097, 7)
        Me.btnEditFustella.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEditFustella.Name = "btnEditFustella"
        Me.btnEditFustella.Size = New System.Drawing.Size(94, 32)
        Me.btnEditFustella.TabIndex = 105
        Me.btnEditFustella.Text = "Modifica"
        Me.btnEditFustella.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditFustella.UseVisualStyleBackColor = False
        '
        'btnAddFustella
        '
        Me.btnAddFustella.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddFustella.BackColor = System.Drawing.Color.White
        Me.btnAddFustella.FlatAppearance.BorderSize = 0
        Me.btnAddFustella.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddFustella.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAddFustella.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnAddFustella.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddFustella.Location = New System.Drawing.Point(1002, 7)
        Me.btnAddFustella.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAddFustella.Name = "btnAddFustella"
        Me.btnAddFustella.Size = New System.Drawing.Size(89, 32)
        Me.btnAddFustella.TabIndex = 104
        Me.btnAddFustella.Text = "Aggiungi"
        Me.btnAddFustella.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddFustella.UseVisualStyleBackColor = False
        '
        'btnAggFustelle
        '
        Me.btnAggFustelle.BackColor = System.Drawing.Color.White
        Me.btnAggFustelle.FlatAppearance.BorderSize = 0
        Me.btnAggFustelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggFustelle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggFustelle.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggFustelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggFustelle.Location = New System.Drawing.Point(6, 7)
        Me.btnAggFustelle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggFustelle.Name = "btnAggFustelle"
        Me.btnAggFustelle.Size = New System.Drawing.Size(95, 32)
        Me.btnAggFustelle.TabIndex = 103
        Me.btnAggFustelle.Text = "Aggiorna"
        Me.btnAggFustelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggFustelle.UseVisualStyleBackColor = False
        '
        'DgFustelle
        '
        Me.DgFustelle.AllowUserToAddRows = False
        Me.DgFustelle.AllowUserToDeleteRows = False
        Me.DgFustelle.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        Me.DgFustelle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.DgFustelle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgFustelle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgFustelle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgFustelle.BackgroundColor = System.Drawing.Color.White
        Me.DgFustelle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgFustelle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgFustelle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DgFustelle.ColumnHeadersHeight = 20
        Me.DgFustelle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgFustelle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codice, Me.TipoFustella, Me.Ripetizioni, Me.Annotazioni})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgFustelle.DefaultCellStyle = DataGridViewCellStyle13
        Me.DgFustelle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgFustelle.EnableHeadersVisualStyles = False
        Me.DgFustelle.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgFustelle.Location = New System.Drawing.Point(6, 48)
        Me.DgFustelle.MultiSelect = False
        Me.DgFustelle.Name = "DgFustelle"
        Me.DgFustelle.ReadOnly = True
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgFustelle.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.DgFustelle.RowHeadersVisible = False
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black
        Me.DgFustelle.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.DgFustelle.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgFustelle.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgFustelle.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgFustelle.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgFustelle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgFustelle.Size = New System.Drawing.Size(1277, 665)
        Me.DgFustelle.TabIndex = 59
        Me.DgFustelle.TabStop = False
        '
        'Codice
        '
        Me.Codice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Codice.DataPropertyName = "Codice"
        Me.Codice.HeaderText = "Codice"
        Me.Codice.Name = "Codice"
        Me.Codice.ReadOnly = True
        Me.Codice.Width = 68
        '
        'TipoFustella
        '
        Me.TipoFustella.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TipoFustella.DataPropertyName = "TipologiaFustella"
        Me.TipoFustella.HeaderText = "Tipologia Fustella"
        Me.TipoFustella.Name = "TipoFustella"
        Me.TipoFustella.ReadOnly = True
        Me.TipoFustella.Width = 123
        '
        'Ripetizioni
        '
        Me.Ripetizioni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Ripetizioni.DataPropertyName = "Ripetizioni"
        Me.Ripetizioni.HeaderText = "Ripetizioni"
        Me.Ripetizioni.Name = "Ripetizioni"
        Me.Ripetizioni.ReadOnly = True
        Me.Ripetizioni.Width = 86
        '
        'Annotazioni
        '
        Me.Annotazioni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Annotazioni.DataPropertyName = "Annotazioni"
        Me.Annotazioni.HeaderText = "Annotazioni"
        Me.Annotazioni.Name = "Annotazioni"
        Me.Annotazioni.ReadOnly = True
        Me.Annotazioni.Width = 95
        '
        'ucListinoFustelle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tbMain)
        Me.Name = "ucListinoFustelle"
        Me.Size = New System.Drawing.Size(1297, 747)
        Me.tbMain.ResumeLayout(False)
        Me.tpTipoFustella.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgTipoFustelle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCatFustelle.ResumeLayout(False)
        CType(Me.dgCatFustelle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpFustelle.ResumeLayout(False)
        CType(Me.DgFustelle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbMain As System.Windows.Forms.TabControl
    Friend WithEvents tpTipoFustella As System.Windows.Forms.TabPage
    Friend WithEvents tpCatFustelle As System.Windows.Forms.TabPage
    Friend WithEvents tpFustelle As System.Windows.Forms.TabPage
    Friend WithEvents DgTipoFustelle As System.Windows.Forms.DataGridView
    Friend WithEvents dgCatFustelle As System.Windows.Forms.DataGridView
    Friend WithEvents DgFustelle As System.Windows.Forms.DataGridView
    Friend WithEvents btnAggTipo As System.Windows.Forms.Button
    Friend WithEvents btnShowOrd As System.Windows.Forms.Button
    Friend WithEvents btnEditTipo As System.Windows.Forms.Button
    Friend WithEvents btnAddTipo As System.Windows.Forms.Button
    Friend WithEvents btnDelCat As System.Windows.Forms.Button
    Friend WithEvents btnEditCat As System.Windows.Forms.Button
    Friend WithEvents btnAddCat As System.Windows.Forms.Button
    Friend WithEvents btnAggiornaCat As System.Windows.Forms.Button
    Friend WithEvents btnDelFustella As System.Windows.Forms.Button
    Friend WithEvents btnEditFustella As System.Windows.Forms.Button
    Friend WithEvents btnAddFustella As System.Windows.Forms.Button
    Friend WithEvents btnAggFustelle As System.Windows.Forms.Button
    Friend WithEvents Codice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoFustella As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ripetizioni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Annotazioni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategoriaDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Anima As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LarghezzaMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtProfondita As ucNumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAltezza As ucNumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBase As ucNumericTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbPrev As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ImgRiferimento128 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Preventivazione As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodiceD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Altezza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Profondita As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Orientabile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Disponibile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Categorie As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
