<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoCli
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListinoCli))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lnkApplica = New System.Windows.Forms.LinkLabel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnCaricaFasce = New System.Windows.Forms.Button()
        Me.DgFasce = New System.Windows.Forms.DataGridView()
        Me.Min = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Max = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Percentuale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.tvwCat = New System.Windows.Forms.TreeView()
        Me.imlTvw = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkModifica = New System.Windows.Forms.LinkLabel()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.DgFasce, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lnkApplica)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 390)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(650, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'lnkApplica
        '
        Me.lnkApplica.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkApplica.Image = Global.Former.My.Resources.icoOrder
        Me.lnkApplica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkApplica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkApplica.Location = New System.Drawing.Point(6, 14)
        Me.lnkApplica.Name = "lnkApplica"
        Me.lnkApplica.Size = New System.Drawing.Size(74, 27)
        Me.lnkApplica.TabIndex = 54
        Me.lnkApplica.TabStop = True
        Me.lnkApplica.Text = "Applica"
        Me.lnkApplica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.icoCancel
        Me.btnCancel.Location = New System.Drawing.Point(614, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(0, 26)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(650, 364)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnCaricaFasce)
        Me.tbProd.Controls.Add(Me.DgFasce)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.btnRefresh)
        Me.tbProd.Controls.Add(Me.tvwCat)
        Me.tbProd.Controls.Add(Me.lnkModifica)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(642, 336)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Creazione Listino Pubblico"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnCaricaFasce
        '
        Me.btnCaricaFasce.FlatAppearance.BorderSize = 0
        Me.btnCaricaFasce.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCaricaFasce.Image = Global.Former.My.Resources.icoRefresh
        Me.btnCaricaFasce.Location = New System.Drawing.Point(6, 28)
        Me.btnCaricaFasce.Name = "btnCaricaFasce"
        Me.btnCaricaFasce.Size = New System.Drawing.Size(24, 27)
        Me.btnCaricaFasce.TabIndex = 62
        Me.btnCaricaFasce.UseVisualStyleBackColor = True
        '
        'DgFasce
        '
        Me.DgFasce.AllowUserToAddRows = False
        Me.DgFasce.AllowUserToDeleteRows = False
        Me.DgFasce.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgFasce.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgFasce.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DgFasce.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgFasce.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgFasce.BackgroundColor = System.Drawing.Color.White
        Me.DgFasce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgFasce.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgFasce.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgFasce.ColumnHeadersHeight = 20
        Me.DgFasce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgFasce.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Min, Me.Max, Me.Percentuale})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgFasce.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgFasce.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgFasce.EnableHeadersVisualStyles = False
        Me.DgFasce.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgFasce.Location = New System.Drawing.Point(3, 61)
        Me.DgFasce.MultiSelect = False
        Me.DgFasce.Name = "DgFasce"
        Me.DgFasce.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgFasce.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgFasce.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DgFasce.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgFasce.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgFasce.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgFasce.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgFasce.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgFasce.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgFasce.Size = New System.Drawing.Size(309, 272)
        Me.DgFasce.TabIndex = 61
        Me.DgFasce.TabStop = False
        '
        'Min
        '
        Me.Min.DataPropertyName = "Min"
        Me.Min.HeaderText = "Min"
        Me.Min.Name = "Min"
        Me.Min.ReadOnly = True
        Me.Min.Width = 50
        '
        'Max
        '
        Me.Max.DataPropertyName = "Max"
        Me.Max.HeaderText = "Max"
        Me.Max.Name = "Max"
        Me.Max.ReadOnly = True
        Me.Max.Width = 52
        '
        'Percentuale
        '
        Me.Percentuale.DataPropertyName = "Perc"
        Me.Percentuale.HeaderText = "Percentuale"
        Me.Percentuale.Name = "Percentuale"
        Me.Percentuale.ReadOnly = True
        Me.Percentuale.Width = 97
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.Label1.Location = New System.Drawing.Point(314, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 22)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Step 2 - Categorie"
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = Global.Former.My.Resources.icoRefresh
        Me.btnRefresh.Location = New System.Drawing.Point(329, 28)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(24, 27)
        Me.btnRefresh.TabIndex = 54
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'tvwCat
        '
        Me.tvwCat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwCat.ImageIndex = 0
        Me.tvwCat.ImageList = Me.imlTvw
        Me.tvwCat.Location = New System.Drawing.Point(318, 61)
        Me.tvwCat.Name = "tvwCat"
        Me.tvwCat.SelectedImageIndex = 0
        Me.tvwCat.ShowRootLines = False
        Me.tvwCat.Size = New System.Drawing.Size(319, 272)
        Me.tvwCat.TabIndex = 52
        '
        'imlTvw
        '
        Me.imlTvw.ImageStream = CType(resources.GetObject("imlTvw.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTvw.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTvw.Images.SetKeyName(0, "icoProd.jpg")
        '
        'lnkModifica
        '
        Me.lnkModifica.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModifica.Image = Global.Former.My.Resources.icoProd
        Me.lnkModifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModifica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkModifica.Location = New System.Drawing.Point(359, 28)
        Me.lnkModifica.Name = "lnkModifica"
        Me.lnkModifica.Size = New System.Drawing.Size(81, 27)
        Me.lnkModifica.TabIndex = 53
        Me.lnkModifica.TabStop = True
        Me.lnkModifica.Text = "Modifica"
        Me.lnkModifica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(8, 3)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(141, 22)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Step 1 - Prezzo"
        '
        'frmListinoCli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(650, 438)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        
        Me.Name = "frmListinoCli"
        Me.Text = "Former - Creazione Listino Pubblico"
        Me.Controls.SetChildIndex(Me.gbPulsanti, 0)
        Me.Controls.SetChildIndex(Me.TabMain, 0)
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.DgFasce, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents imlTvw As System.Windows.Forms.ImageList
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents tvwCat As System.Windows.Forms.TreeView
    Friend WithEvents lnkModifica As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgFasce As System.Windows.Forms.DataGridView
    Friend WithEvents btnCaricaFasce As System.Windows.Forms.Button
    Friend WithEvents Min As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Max As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Percentuale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkApplica As System.Windows.Forms.LinkLabel
End Class
