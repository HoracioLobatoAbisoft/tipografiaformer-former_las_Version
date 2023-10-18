<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoOrdineMacchinari
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.DgMacchinari = New System.Windows.Forms.DataGridView()
        Me.imgLavorazione = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Lavorazione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Note = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.DgMacchinari, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 515)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(593, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(551, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 31)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.Location = New System.Drawing.Point(517, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 31)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(593, 515)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.DgMacchinari)
        Me.tbProd.Controls.Add(Me.btnDown)
        Me.tbProd.Controls.Add(Me.btnUp)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(585, 489)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Ordine Esecuzione Macchinari"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'DgMacchinari
        '
        Me.DgMacchinari.AllowUserToAddRows = False
        Me.DgMacchinari.AllowUserToDeleteRows = False
        Me.DgMacchinari.AllowUserToOrderColumns = True
        Me.DgMacchinari.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.DgMacchinari.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DgMacchinari.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgMacchinari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgMacchinari.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgMacchinari.BackgroundColor = System.Drawing.Color.White
        Me.DgMacchinari.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgMacchinari.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMacchinari.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DgMacchinari.ColumnHeadersHeight = 20
        Me.DgMacchinari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgMacchinari.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.imgLavorazione, Me.Lavorazione, Me.Note})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMacchinari.DefaultCellStyle = DataGridViewCellStyle10
        Me.DgMacchinari.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgMacchinari.EnableHeadersVisualStyles = False
        Me.DgMacchinari.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgMacchinari.Location = New System.Drawing.Point(53, 62)
        Me.DgMacchinari.MultiSelect = False
        Me.DgMacchinari.Name = "DgMacchinari"
        Me.DgMacchinari.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMacchinari.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DgMacchinari.RowHeadersVisible = False
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.DgMacchinari.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DgMacchinari.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgMacchinari.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgMacchinari.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgMacchinari.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMacchinari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgMacchinari.Size = New System.Drawing.Size(489, 411)
        Me.DgMacchinari.TabIndex = 106
        Me.DgMacchinari.TabStop = False
        '
        'imgLavorazione
        '
        Me.imgLavorazione.DataPropertyName = "img"
        Me.imgLavorazione.Frozen = True
        Me.imgLavorazione.HeaderText = ""
        Me.imgLavorazione.Name = "imgLavorazione"
        Me.imgLavorazione.ReadOnly = True
        Me.imgLavorazione.Width = 5
        '
        'Lavorazione
        '
        Me.Lavorazione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Lavorazione.DataPropertyName = "Descrizione"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Lavorazione.DefaultCellStyle = DataGridViewCellStyle9
        Me.Lavorazione.HeaderText = "Macchinario"
        Me.Lavorazione.Name = "Lavorazione"
        Me.Lavorazione.ReadOnly = True
        Me.Lavorazione.Width = 180
        '
        'Note
        '
        Me.Note.HeaderText = "Note"
        Me.Note.Name = "Note"
        Me.Note.ReadOnly = True
        Me.Note.Width = 57
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDown.AutoSize = True
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDown.ForeColor = System.Drawing.Color.White
        Me.btnDown.Image = Global.Former.My.Resources.Resources._Giu
        Me.btnDown.Location = New System.Drawing.Point(543, 439)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(34, 34)
        Me.btnDown.TabIndex = 17
        Me.toolTipHelp.SetToolTip(Me.btnDown, "Sposta in basso la lavorazione selezionata")
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUp.AutoSize = True
        Me.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUp.ForeColor = System.Drawing.Color.White
        Me.btnUp.Image = Global.Former.My.Resources.Resources._Su
        Me.btnUp.Location = New System.Drawing.Point(543, 62)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(34, 34)
        Me.btnUp.TabIndex = 16
        Me.toolTipHelp.SetToolTip(Me.btnUp, "Sposta in alto la lavorazione selezionata")
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Macchinari
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
        Me.lblTipo.Size = New System.Drawing.Size(298, 25)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Ordine di Esecuzione Macchinari"
        '
        'frmListinoOrdineMacchinari
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(593, 563)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoOrdineMacchinari"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Ordine di Esecuzione Macchinari"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.DgMacchinari, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents btnDown As Button
    Friend WithEvents btnUp As Button
    Friend WithEvents DgMacchinari As DataGridView
    Friend WithEvents Note As DataGridViewTextBoxColumn
    Friend WithEvents Lavorazione As DataGridViewTextBoxColumn
    Friend WithEvents imgLavorazione As DataGridViewImageColumn
End Class
