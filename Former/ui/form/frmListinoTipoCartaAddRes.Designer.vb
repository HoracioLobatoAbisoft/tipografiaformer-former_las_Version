<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoTipoCartaAddRes
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
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.rdoUltimoCarico = New System.Windows.Forms.RadioButton()
        Me.rdoAlfabeto = New System.Windows.Forms.RadioButton()
        Me.btnNuovaRis = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.DgRiso = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Seleziona = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Risorsa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoCartaCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grammatura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataUltimoCarico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.DgRiso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 530)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(875, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(790, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(73, 36)
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
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(715, 11)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(68, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Salva"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(875, 530)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.rdoUltimoCarico)
        Me.tbProd.Controls.Add(Me.rdoAlfabeto)
        Me.tbProd.Controls.Add(Me.btnNuovaRis)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.txtCerca)
        Me.tbProd.Controls.Add(Me.DgRiso)
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.Label15)
        Me.tbProd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(867, 504)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Aggiungi Risorse a Tipo Carta"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'rdoUltimoCarico
        '
        Me.rdoUltimoCarico.AutoSize = True
        Me.rdoUltimoCarico.Location = New System.Drawing.Point(273, 88)
        Me.rdoUltimoCarico.Name = "rdoUltimoCarico"
        Me.rdoUltimoCarico.Size = New System.Drawing.Size(291, 19)
        Me.rdoUltimoCarico.TabIndex = 109
        Me.rdoUltimoCarico.Text = "Ordina i risultati in base alla data dell'ultimo carico"
        Me.rdoUltimoCarico.UseVisualStyleBackColor = True
        '
        'rdoAlfabeto
        '
        Me.rdoAlfabeto.AutoSize = True
        Me.rdoAlfabeto.Checked = True
        Me.rdoAlfabeto.Location = New System.Drawing.Point(59, 88)
        Me.rdoAlfabeto.Name = "rdoAlfabeto"
        Me.rdoAlfabeto.Size = New System.Drawing.Size(197, 19)
        Me.rdoAlfabeto.TabIndex = 108
        Me.rdoAlfabeto.TabStop = True
        Me.rdoAlfabeto.Text = "Ordina i risultati alfabeticamente"
        Me.rdoAlfabeto.UseVisualStyleBackColor = True
        '
        'btnNuovaRis
        '
        Me.btnNuovaRis.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuovaRis.AutoSize = True
        Me.btnNuovaRis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnNuovaRis.FlatAppearance.BorderSize = 0
        Me.btnNuovaRis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuovaRis.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnNuovaRis.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnNuovaRis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuovaRis.Location = New System.Drawing.Point(777, 48)
        Me.btnNuovaRis.Name = "btnNuovaRis"
        Me.btnNuovaRis.Size = New System.Drawing.Size(82, 34)
        Me.btnNuovaRis.TabIndex = 107
        Me.btnNuovaRis.Text = "Nuova"
        Me.btnNuovaRis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuovaRis.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(10, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Cerca:"
        '
        'txtCerca
        '
        Me.txtCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCerca.Location = New System.Drawing.Point(59, 49)
        Me.txtCerca.MaxLength = 50
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(204, 23)
        Me.txtCerca.TabIndex = 104
        Me.txtCerca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DgRiso
        '
        Me.DgRiso.AllowUserToAddRows = False
        Me.DgRiso.AllowUserToDeleteRows = False
        Me.DgRiso.AllowUserToOrderColumns = True
        Me.DgRiso.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRiso.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgRiso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgRiso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DgRiso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgRiso.BackgroundColor = System.Drawing.Color.White
        Me.DgRiso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgRiso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgRiso.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgRiso.ColumnHeadersHeight = 20
        Me.DgRiso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgRiso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleziona, Me.Risorsa, Me.TipoCartaCol, Me.Grammatura, Me.DataUltimoCarico})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRiso.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgRiso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgRiso.EnableHeadersVisualStyles = False
        Me.DgRiso.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgRiso.Location = New System.Drawing.Point(3, 126)
        Me.DgRiso.MultiSelect = False
        Me.DgRiso.Name = "DgRiso"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRiso.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgRiso.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRiso.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DgRiso.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgRiso.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgRiso.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgRiso.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgRiso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgRiso.Size = New System.Drawing.Size(858, 370)
        Me.DgRiso.TabIndex = 103
        Me.DgRiso.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Risorsa
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 102
        Me.PictureBox1.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(46, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(233, 21)
        Me.Label15.TabIndex = 101
        Me.Label15.Text = "Risorse associate a Tipo Carta"
        '
        'Seleziona
        '
        Me.Seleziona.DataPropertyName = "Selezionata"
        Me.Seleziona.HeaderText = "Seleziona"
        Me.Seleziona.Name = "Seleziona"
        Me.Seleziona.Width = 61
        '
        'Risorsa
        '
        Me.Risorsa.DataPropertyName = "Riassunto"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Format = "0.00"
        Me.Risorsa.DefaultCellStyle = DataGridViewCellStyle3
        Me.Risorsa.FillWeight = 500.0!
        Me.Risorsa.HeaderText = "Riassunto"
        Me.Risorsa.MinimumWidth = 300
        Me.Risorsa.Name = "Risorsa"
        Me.Risorsa.Width = 300
        '
        'TipoCartaCol
        '
        Me.TipoCartaCol.DataPropertyName = "RiassuntoTipoCarta"
        Me.TipoCartaCol.HeaderText = "Tipo Carta"
        Me.TipoCartaCol.MinimumWidth = 250
        Me.TipoCartaCol.Name = "TipoCartaCol"
        Me.TipoCartaCol.Width = 250
        '
        'Grammatura
        '
        Me.Grammatura.DataPropertyName = "Grammatura"
        Me.Grammatura.HeaderText = "Grammatura"
        Me.Grammatura.Name = "Grammatura"
        Me.Grammatura.Width = 98
        '
        'DataUltimoCarico
        '
        Me.DataUltimoCarico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataUltimoCarico.DataPropertyName = "UltimoCaricoMagazzinoStr"
        Me.DataUltimoCarico.HeaderText = "Data Ultimo Carico"
        Me.DataUltimoCarico.MinimumWidth = 100
        Me.DataUltimoCarico.Name = "DataUltimoCarico"
        '
        'frmListinoTipoCartaAddRes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(875, 578)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoTipoCartaAddRes"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Aggiungi Risorse a Tipo Carta"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.DgRiso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents DgRiso As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCerca As TextBox
    Friend WithEvents btnNuovaRis As Button
    Friend WithEvents rdoUltimoCarico As RadioButton
    Friend WithEvents rdoAlfabeto As RadioButton
    Friend WithEvents Seleziona As DataGridViewCheckBoxColumn
    Friend WithEvents Risorsa As DataGridViewTextBoxColumn
    Friend WithEvents TipoCartaCol As DataGridViewTextBoxColumn
    Friend WithEvents Grammatura As DataGridViewTextBoxColumn
    Friend WithEvents DataUltimoCarico As DataGridViewTextBoxColumn
End Class
