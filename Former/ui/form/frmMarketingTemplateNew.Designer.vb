<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewTemplMarketing
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAnteprima = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnCopia = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMesi = New System.Windows.Forms.ComboBox()
        Me.lnkDelListinoBase = New System.Windows.Forms.LinkLabel()
        Me.lnkNewTempl = New System.Windows.Forms.LinkLabel()
        Me.DgListinoBase = New System.Windows.Forms.DataGridView()
        Me.NomeListinoBase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.q6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.DgListinoBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnAnteprima)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 598)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(955, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(913, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 36)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAnteprima
        '
        Me.btnAnteprima.AutoSize = True
        Me.btnAnteprima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAnteprima.FlatAppearance.BorderSize = 0
        Me.btnAnteprima.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAnteprima.ForeColor = System.Drawing.Color.Black
        Me.btnAnteprima.Image = Global.Former.My.Resources.Resources._Anteprima
        Me.btnAnteprima.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnteprima.Location = New System.Drawing.Point(51, 13)
        Me.btnAnteprima.Name = "btnAnteprima"
        Me.btnAnteprima.Size = New System.Drawing.Size(152, 32)
        Me.btnAnteprima.TabIndex = 0
        Me.btnAnteprima.Text = "Anteprima Template"
        Me.btnAnteprima.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnteprima.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(955, 598)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnCopia)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbMesi)
        Me.tbProd.Controls.Add(Me.lnkDelListinoBase)
        Me.tbProd.Controls.Add(Me.lnkNewTempl)
        Me.tbProd.Controls.Add(Me.DgListinoBase)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(947, 572)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Template Marketing"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnCopia
        '
        Me.btnCopia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCopia.Location = New System.Drawing.Point(866, 50)
        Me.btnCopia.Name = "btnCopia"
        Me.btnCopia.Size = New System.Drawing.Size(75, 23)
        Me.btnCopia.TabIndex = 3
        Me.btnCopia.Text = "Copia"
        Me.btnCopia.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(670, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 15)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Copia da"
        '
        'cmbMesi
        '
        Me.cmbMesi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMesi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbMesi.FormattingEnabled = True
        Me.cmbMesi.Location = New System.Drawing.Point(733, 51)
        Me.cmbMesi.Name = "cmbMesi"
        Me.cmbMesi.Size = New System.Drawing.Size(127, 23)
        Me.cmbMesi.TabIndex = 2
        '
        'lnkDelListinoBase
        '
        Me.lnkDelListinoBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkDelListinoBase.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkDelListinoBase.Image = Global.Former.My.Resources.Resources._remove
        Me.lnkDelListinoBase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDelListinoBase.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkDelListinoBase.Location = New System.Drawing.Point(200, 48)
        Me.lnkDelListinoBase.Name = "lnkDelListinoBase"
        Me.lnkDelListinoBase.Size = New System.Drawing.Size(146, 27)
        Me.lnkDelListinoBase.TabIndex = 1
        Me.lnkDelListinoBase.TabStop = True
        Me.lnkDelListinoBase.Text = "Rimuovi Listino Base"
        Me.lnkDelListinoBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNewTempl
        '
        Me.lnkNewTempl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNewTempl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkNewTempl.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.lnkNewTempl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkNewTempl.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNewTempl.Location = New System.Drawing.Point(44, 48)
        Me.lnkNewTempl.Name = "lnkNewTempl"
        Me.lnkNewTempl.Size = New System.Drawing.Size(150, 27)
        Me.lnkNewTempl.TabIndex = 0
        Me.lnkNewTempl.TabStop = True
        Me.lnkNewTempl.Text = "Aggiungi Listino Base"
        Me.lnkNewTempl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgListinoBase
        '
        Me.DgListinoBase.AllowUserToAddRows = False
        Me.DgListinoBase.AllowUserToDeleteRows = False
        Me.DgListinoBase.AllowUserToOrderColumns = True
        Me.DgListinoBase.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgListinoBase.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgListinoBase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgListinoBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DgListinoBase.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgListinoBase.BackgroundColor = System.Drawing.Color.White
        Me.DgListinoBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgListinoBase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgListinoBase.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgListinoBase.ColumnHeadersHeight = 20
        Me.DgListinoBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgListinoBase.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomeListinoBase, Me.q6})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgListinoBase.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgListinoBase.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgListinoBase.EnableHeadersVisualStyles = False
        Me.DgListinoBase.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgListinoBase.Location = New System.Drawing.Point(47, 78)
        Me.DgListinoBase.MultiSelect = False
        Me.DgListinoBase.Name = "DgListinoBase"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgListinoBase.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgListinoBase.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgListinoBase.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgListinoBase.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgListinoBase.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgListinoBase.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgListinoBase.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgListinoBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgListinoBase.Size = New System.Drawing.Size(894, 486)
        Me.DgListinoBase.TabIndex = 4
        Me.DgListinoBase.TabStop = False
        '
        'NomeListinoBase
        '
        Me.NomeListinoBase.DataPropertyName = "Nome"
        Me.NomeListinoBase.FillWeight = 200.0!
        Me.NomeListinoBase.Frozen = True
        Me.NomeListinoBase.HeaderText = "Nome"
        Me.NomeListinoBase.MinimumWidth = 450
        Me.NomeListinoBase.Name = "NomeListinoBase"
        Me.NomeListinoBase.Width = 450
        '
        'q6
        '
        Me.q6.DataPropertyName = "Qta"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.q6.DefaultCellStyle = DataGridViewCellStyle3
        Me.q6.HeaderText = "Quantità"
        Me.q6.Name = "q6"
        Me.q6.Width = 77
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Template
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(274, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Template Marketing su Listini Base"
        '
        'frmNewTemplMarketing
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 646)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmNewTemplMarketing"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former -Template Marketing su Listini Base"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.DgListinoBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAnteprima As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents DgListinoBase As System.Windows.Forms.DataGridView
    Friend WithEvents lnkNewTempl As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDelListinoBase As System.Windows.Forms.LinkLabel
    Friend WithEvents NomeListinoBase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents q6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCopia As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMesi As System.Windows.Forms.ComboBox
End Class
