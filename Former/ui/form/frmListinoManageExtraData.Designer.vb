<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmListinoManageExtraData
    Inherits baseFormInternaFixed

    'Form overrides dispose to clean up the component list.
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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnModifica = New System.Windows.Forms.Button()
        Me.btnRimuovi = New System.Windows.Forms.Button()
        Me.btnAggiungi = New System.Windows.Forms.Button()
        Me.DgExtraSel = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgExtraDisp = New System.Windows.Forms.DataGridView()
        Me.Chiave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.DgExtraSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgExtraDisp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 501)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(918, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(834, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(752, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(76, 32)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
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
        Me.TabMain.Size = New System.Drawing.Size(918, 501)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnModifica)
        Me.tbProd.Controls.Add(Me.btnRimuovi)
        Me.tbProd.Controls.Add(Me.btnAggiungi)
        Me.tbProd.Controls.Add(Me.DgExtraSel)
        Me.tbProd.Controls.Add(Me.DgExtraDisp)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(910, 475)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Manage ExtraData"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnModifica
        '
        Me.btnModifica.AutoSize = True
        Me.btnModifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnModifica.FlatAppearance.BorderSize = 0
        Me.btnModifica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModifica.ForeColor = System.Drawing.Color.Black
        Me.btnModifica.Image = Global.Former.My.Resources.Resources._Modifica
        Me.btnModifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModifica.Location = New System.Drawing.Point(805, 60)
        Me.btnModifica.Name = "btnModifica"
        Me.btnModifica.Size = New System.Drawing.Size(90, 32)
        Me.btnModifica.TabIndex = 46
        Me.btnModifica.Text = "Modifica"
        Me.btnModifica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModifica.UseVisualStyleBackColor = True
        '
        'btnRimuovi
        '
        Me.btnRimuovi.AutoSize = True
        Me.btnRimuovi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRimuovi.FlatAppearance.BorderSize = 0
        Me.btnRimuovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRimuovi.ForeColor = System.Drawing.Color.Black
        Me.btnRimuovi.Image = Global.Former.My.Resources.Resources._Elimina
        Me.btnRimuovi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRimuovi.Location = New System.Drawing.Point(381, 101)
        Me.btnRimuovi.Name = "btnRimuovi"
        Me.btnRimuovi.Size = New System.Drawing.Size(90, 32)
        Me.btnRimuovi.TabIndex = 45
        Me.btnRimuovi.Text = "Rimuovi"
        Me.btnRimuovi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRimuovi.UseVisualStyleBackColor = True
        '
        'btnAggiungi
        '
        Me.btnAggiungi.AutoSize = True
        Me.btnAggiungi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAggiungi.FlatAppearance.BorderSize = 0
        Me.btnAggiungi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiungi.ForeColor = System.Drawing.Color.Black
        Me.btnAggiungi.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnAggiungi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiungi.Location = New System.Drawing.Point(381, 60)
        Me.btnAggiungi.Name = "btnAggiungi"
        Me.btnAggiungi.Size = New System.Drawing.Size(90, 32)
        Me.btnAggiungi.TabIndex = 44
        Me.btnAggiungi.Text = "Aggiungi"
        Me.btnAggiungi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggiungi.UseVisualStyleBackColor = True
        '
        'DgExtraSel
        '
        Me.DgExtraSel.AllowUserToAddRows = False
        Me.DgExtraSel.AllowUserToDeleteRows = False
        Me.DgExtraSel.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgExtraSel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgExtraSel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgExtraSel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgExtraSel.BackgroundColor = System.Drawing.Color.White
        Me.DgExtraSel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgExtraSel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgExtraSel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgExtraSel.ColumnHeadersHeight = 20
        Me.DgExtraSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgExtraSel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgExtraSel.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgExtraSel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgExtraSel.EnableHeadersVisualStyles = False
        Me.DgExtraSel.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgExtraSel.Location = New System.Drawing.Point(488, 40)
        Me.DgExtraSel.MultiSelect = False
        Me.DgExtraSel.Name = "DgExtraSel"
        Me.DgExtraSel.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgExtraSel.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgExtraSel.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgExtraSel.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgExtraSel.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgExtraSel.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgExtraSel.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgExtraSel.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgExtraSel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgExtraSel.Size = New System.Drawing.Size(311, 429)
        Me.DgExtraSel.TabIndex = 43
        Me.DgExtraSel.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Chiave"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Chiave"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Valore"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Valore"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DgExtraDisp
        '
        Me.DgExtraDisp.AllowUserToAddRows = False
        Me.DgExtraDisp.AllowUserToDeleteRows = False
        Me.DgExtraDisp.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgExtraDisp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgExtraDisp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgExtraDisp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgExtraDisp.BackgroundColor = System.Drawing.Color.White
        Me.DgExtraDisp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgExtraDisp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgExtraDisp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DgExtraDisp.ColumnHeadersHeight = 20
        Me.DgExtraDisp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgExtraDisp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chiave, Me.Tipo})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgExtraDisp.DefaultCellStyle = DataGridViewCellStyle8
        Me.DgExtraDisp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgExtraDisp.EnableHeadersVisualStyles = False
        Me.DgExtraDisp.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgExtraDisp.Location = New System.Drawing.Point(52, 40)
        Me.DgExtraDisp.MultiSelect = False
        Me.DgExtraDisp.Name = "DgExtraDisp"
        Me.DgExtraDisp.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgExtraDisp.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DgExtraDisp.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DgExtraDisp.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DgExtraDisp.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgExtraDisp.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgExtraDisp.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgExtraDisp.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgExtraDisp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgExtraDisp.Size = New System.Drawing.Size(311, 429)
        Me.DgExtraDisp.TabIndex = 42
        Me.DgExtraDisp.TabStop = False
        '
        'Chiave
        '
        Me.Chiave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Chiave.DataPropertyName = "Chiave"
        Me.Chiave.HeaderText = "Chiave"
        Me.Chiave.Name = "Chiave"
        Me.Chiave.ReadOnly = True
        '
        'Tipo
        '
        Me.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Tipo.DataPropertyName = "TipoStr"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(485, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "ExtraData SELEZIONATI"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(49, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 15)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "ExtraData DISPONIBILI"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._extraData
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'frmListinoManageExtraData
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(918, 549)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmListinoManageExtraData"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Manage ExtraData"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.DgExtraSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgExtraDisp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DgExtraDisp As DataGridView
    Friend WithEvents DgExtraSel As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Chiave As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
    Friend WithEvents btnRimuovi As Button
    Friend WithEvents btnAggiungi As Button
    Friend WithEvents btnModifica As Button
End Class
