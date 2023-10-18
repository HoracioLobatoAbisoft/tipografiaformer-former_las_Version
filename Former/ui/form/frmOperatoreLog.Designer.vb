<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperatoreLog
    Inherits baseFormInternaRedim

    'Form overrides dispose to clean up the component list.
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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.rdoOrdine = New System.Windows.Forms.RadioButton()
        Me.rdoOperatore = New System.Windows.Forms.RadioButton()
        Me.txtOrdine = New Former.ucNumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtGiornoScelto = New System.Windows.Forms.DateTimePicker()
        Me.cmbUtente = New System.Windows.Forms.ComboBox()
        Me.DgLog = New System.Windows.Forms.DataGridView()
        Me.Anteprima = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Utente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quando = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Attivita = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 656)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1096, 48)
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
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1012, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1096, 656)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.GroupBox1)
        Me.tbProd.Controls.Add(Me.DgLog)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1088, 630)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Log Operatori"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lnkCerca)
        Me.GroupBox1.Controls.Add(Me.rdoOrdine)
        Me.GroupBox1.Controls.Add(Me.rdoOperatore)
        Me.GroupBox1.Controls.Add(Me.txtOrdine)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtGiornoScelto)
        Me.GroupBox1.Controls.Add(Me.cmbUtente)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1027, 109)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parametri"
        '
        'lnkCerca
        '
        Me.lnkCerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(952, 22)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(62, 27)
        Me.lnkCerca.TabIndex = 85
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Cerca"
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rdoOrdine
        '
        Me.rdoOrdine.AutoSize = True
        Me.rdoOrdine.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rdoOrdine.Location = New System.Drawing.Point(23, 61)
        Me.rdoOrdine.Name = "rdoOrdine"
        Me.rdoOrdine.Size = New System.Drawing.Size(80, 25)
        Me.rdoOrdine.TabIndex = 84
        Me.rdoOrdine.Text = "Ordine"
        Me.rdoOrdine.UseVisualStyleBackColor = True
        '
        'rdoOperatore
        '
        Me.rdoOperatore.AutoSize = True
        Me.rdoOperatore.Checked = True
        Me.rdoOperatore.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rdoOperatore.Location = New System.Drawing.Point(23, 25)
        Me.rdoOperatore.Name = "rdoOperatore"
        Me.rdoOperatore.Size = New System.Drawing.Size(105, 25)
        Me.rdoOperatore.TabIndex = 83
        Me.rdoOperatore.TabStop = True
        Me.rdoOperatore.Text = "Operatore"
        Me.rdoOperatore.UseVisualStyleBackColor = True
        '
        'txtOrdine
        '
        Me.txtOrdine.My_AccettaNegativi = False
        Me.txtOrdine.My_DefaultValue = 0
        Me.txtOrdine.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtOrdine.Location = New System.Drawing.Point(142, 60)
        Me.txtOrdine.MaxLength = 6
        Me.txtOrdine.My_MaxValue = 999999.0!
        Me.txtOrdine.My_MinValue = 0!
        Me.txtOrdine.Name = "txtOrdine"
        Me.txtOrdine.My_AllowOnlyInteger = True
        Me.txtOrdine.My_ReplaceWithDefaultValue = True
        Me.txtOrdine.Size = New System.Drawing.Size(97, 29)
        Me.txtOrdine.TabIndex = 82
        Me.txtOrdine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(349, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 21)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Giorno"
        '
        'dtGiornoScelto
        '
        Me.dtGiornoScelto.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.dtGiornoScelto.Location = New System.Drawing.Point(422, 22)
        Me.dtGiornoScelto.Name = "dtGiornoScelto"
        Me.dtGiornoScelto.Size = New System.Drawing.Size(296, 29)
        Me.dtGiornoScelto.TabIndex = 79
        '
        'cmbUtente
        '
        Me.cmbUtente.BackColor = System.Drawing.Color.Green
        Me.cmbUtente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUtente.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbUtente.ForeColor = System.Drawing.Color.White
        Me.cmbUtente.FormattingEnabled = True
        Me.cmbUtente.Location = New System.Drawing.Point(142, 24)
        Me.cmbUtente.Name = "cmbUtente"
        Me.cmbUtente.Size = New System.Drawing.Size(201, 29)
        Me.cmbUtente.TabIndex = 77
        '
        'DgLog
        '
        Me.DgLog.AllowUserToAddRows = False
        Me.DgLog.AllowUserToDeleteRows = False
        Me.DgLog.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgLog.BackgroundColor = System.Drawing.Color.White
        Me.DgLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgLog.ColumnHeadersHeight = 20
        Me.DgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Anteprima, Me.Utente, Me.Quando, Me.Attivita})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLog.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgLog.EnableHeadersVisualStyles = False
        Me.DgLog.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgLog.Location = New System.Drawing.Point(53, 121)
        Me.DgLog.MultiSelect = False
        Me.DgLog.Name = "DgLog"
        Me.DgLog.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLog.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgLog.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLog.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgLog.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgLog.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgLog.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgLog.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgLog.Size = New System.Drawing.Size(1027, 501)
        Me.DgLog.TabIndex = 80
        Me.DgLog.TabStop = False
        '
        'Anteprima
        '
        Me.Anteprima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Anteprima.DataPropertyName = "ImgRif"
        Me.Anteprima.HeaderText = "Anteprima"
        Me.Anteprima.Name = "Anteprima"
        Me.Anteprima.ReadOnly = True
        '
        'Utente
        '
        Me.Utente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Utente.DataPropertyName = "Operatore"
        Me.Utente.HeaderText = "Operatore"
        Me.Utente.Name = "Utente"
        Me.Utente.ReadOnly = True
        '
        'Quando
        '
        Me.Quando.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Quando.DataPropertyName = "Quando"
        Me.Quando.FillWeight = 150.0!
        Me.Quando.HeaderText = "Quando"
        Me.Quando.Name = "Quando"
        Me.Quando.ReadOnly = True
        Me.Quando.Width = 150
        '
        'Attivita
        '
        Me.Attivita.DataPropertyName = "Attivita"
        Me.Attivita.FillWeight = 600.0!
        Me.Attivita.HeaderText = "Attività"
        Me.Attivita.Name = "Attivita"
        Me.Attivita.ReadOnly = True
        Me.Attivita.Width = 600
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Cerca
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'frmOperatoreLog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1096, 704)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmOperatoreLog"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Log Operatori"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents dtGiornoScelto As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbUtente As ComboBox
    Friend WithEvents DgLog As DataGridView
    Friend WithEvents txtOrdine As ucNumericTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdoOrdine As RadioButton
    Friend WithEvents rdoOperatore As RadioButton
    Friend WithEvents lnkCerca As LinkLabel
    Friend WithEvents Anteprima As DataGridViewImageColumn
    Friend WithEvents Utente As DataGridViewTextBoxColumn
    Friend WithEvents Quando As DataGridViewTextBoxColumn
    Friend WithEvents Attivita As DataGridViewTextBoxColumn
End Class
