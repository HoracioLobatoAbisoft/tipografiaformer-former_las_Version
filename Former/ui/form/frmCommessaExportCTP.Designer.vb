<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommessaExportCTP
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.lnkModModelloCommessa = New System.Windows.Forms.LinkLabel()
        Me.chkPosDispari = New System.Windows.Forms.CheckBox()
        Me.pctAnteR = New System.Windows.Forms.PictureBox()
        Me.pctAnteF = New System.Windows.Forms.PictureBox()
        Me.btnFileVuoto = New System.Windows.Forms.Button()
        Me.txtFileVuoto = New System.Windows.Forms.TextBox()
        Me.chkFileVuoto = New System.Windows.Forms.CheckBox()
        Me.lnkSu = New System.Windows.Forms.LinkLabel()
        Me.lnkGiu = New System.Windows.Forms.LinkLabel()
        Me.DgOrdini = New System.Windows.Forms.DataGridView()
        Me.Anteprima = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Ordine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prodotto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duplicati = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Posizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.OpenFileSorg = New System.Windows.Forms.OpenFileDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctAnteR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctAnteF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgOrdini, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 701)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1398, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(1362, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(30, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources._Ok
        Me.btnOk.Location = New System.Drawing.Point(1326, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
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
        Me.TabMain.Size = New System.Drawing.Size(1398, 701)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lnkModModelloCommessa)
        Me.tbProd.Controls.Add(Me.chkPosDispari)
        Me.tbProd.Controls.Add(Me.pctAnteR)
        Me.tbProd.Controls.Add(Me.pctAnteF)
        Me.tbProd.Controls.Add(Me.btnFileVuoto)
        Me.tbProd.Controls.Add(Me.txtFileVuoto)
        Me.tbProd.Controls.Add(Me.chkFileVuoto)
        Me.tbProd.Controls.Add(Me.lnkSu)
        Me.tbProd.Controls.Add(Me.lnkGiu)
        Me.tbProd.Controls.Add(Me.DgOrdini)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1390, 675)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Export CTP"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lnkModModelloCommessa
        '
        Me.lnkModModelloCommessa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkModModelloCommessa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkModModelloCommessa.Image = Global.Former.My.Resources.Resources._ModelloCommessa
        Me.lnkModModelloCommessa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkModModelloCommessa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkModModelloCommessa.Location = New System.Drawing.Point(1135, 7)
        Me.lnkModModelloCommessa.Name = "lnkModModelloCommessa"
        Me.lnkModModelloCommessa.Size = New System.Drawing.Size(198, 37)
        Me.lnkModModelloCommessa.TabIndex = 105
        Me.lnkModModelloCommessa.TabStop = True
        Me.lnkModModelloCommessa.Text = "Modifica Modello Commessa"
        Me.lnkModModelloCommessa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkPosDispari
        '
        Me.chkPosDispari.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPosDispari.AutoSize = True
        Me.chkPosDispari.Checked = True
        Me.chkPosDispari.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPosDispari.Location = New System.Drawing.Point(1006, 17)
        Me.chkPosDispari.Name = "chkPosDispari"
        Me.chkPosDispari.Size = New System.Drawing.Size(111, 19)
        Me.chkPosDispari.TabIndex = 104
        Me.chkPosDispari.Text = "posizioni dispari"
        Me.chkPosDispari.UseVisualStyleBackColor = True
        '
        'pctAnteR
        '
        Me.pctAnteR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctAnteR.Location = New System.Drawing.Point(1138, 223)
        Me.pctAnteR.Name = "pctAnteR"
        Me.pctAnteR.Size = New System.Drawing.Size(230, 171)
        Me.pctAnteR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctAnteR.TabIndex = 103
        Me.pctAnteR.TabStop = False
        '
        'pctAnteF
        '
        Me.pctAnteF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctAnteF.Location = New System.Drawing.Point(1138, 46)
        Me.pctAnteF.Name = "pctAnteF"
        Me.pctAnteF.Size = New System.Drawing.Size(230, 171)
        Me.pctAnteF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctAnteF.TabIndex = 102
        Me.pctAnteF.TabStop = False
        '
        'btnFileVuoto
        '
        Me.btnFileVuoto.Location = New System.Drawing.Point(730, 15)
        Me.btnFileVuoto.Name = "btnFileVuoto"
        Me.btnFileVuoto.Size = New System.Drawing.Size(25, 21)
        Me.btnFileVuoto.TabIndex = 85
        Me.btnFileVuoto.Text = "..."
        Me.btnFileVuoto.UseVisualStyleBackColor = True
        Me.btnFileVuoto.Visible = False
        '
        'txtFileVuoto
        '
        Me.txtFileVuoto.Location = New System.Drawing.Point(336, 15)
        Me.txtFileVuoto.Name = "txtFileVuoto"
        Me.txtFileVuoto.ReadOnly = True
        Me.txtFileVuoto.Size = New System.Drawing.Size(388, 20)
        Me.txtFileVuoto.TabIndex = 84
        Me.txtFileVuoto.Visible = False
        '
        'chkFileVuoto
        '
        Me.chkFileVuoto.AutoSize = True
        Me.chkFileVuoto.Location = New System.Drawing.Point(233, 17)
        Me.chkFileVuoto.Name = "chkFileVuoto"
        Me.chkFileVuoto.Size = New System.Drawing.Size(99, 19)
        Me.chkFileVuoto.TabIndex = 83
        Me.chkFileVuoto.Text = "con file vuoto"
        Me.chkFileVuoto.UseVisualStyleBackColor = True
        Me.chkFileVuoto.Visible = False
        '
        'lnkSu
        '
        Me.lnkSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkSu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkSu.Image = Global.Former.My.Resources.Resources._Su
        Me.lnkSu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSu.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSu.Location = New System.Drawing.Point(1123, 593)
        Me.lnkSu.Name = "lnkSu"
        Me.lnkSu.Size = New System.Drawing.Size(51, 37)
        Me.lnkSu.TabIndex = 81
        Me.lnkSu.TabStop = True
        Me.lnkSu.Text = "Su"
        Me.lnkSu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkGiu
        '
        Me.lnkGiu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkGiu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkGiu.Image = Global.Former.My.Resources.Resources._Giu
        Me.lnkGiu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkGiu.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkGiu.Location = New System.Drawing.Point(1123, 630)
        Me.lnkGiu.Name = "lnkGiu"
        Me.lnkGiu.Size = New System.Drawing.Size(54, 37)
        Me.lnkGiu.TabIndex = 82
        Me.lnkGiu.TabStop = True
        Me.lnkGiu.Text = "Giù"
        Me.lnkGiu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgOrdini
        '
        Me.DgOrdini.AllowUserToAddRows = False
        Me.DgOrdini.AllowUserToDeleteRows = False
        Me.DgOrdini.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgOrdini.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgOrdini.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgOrdini.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgOrdini.BackgroundColor = System.Drawing.Color.White
        Me.DgOrdini.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgOrdini.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgOrdini.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgOrdini.ColumnHeadersHeight = 20
        Me.DgOrdini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgOrdini.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Anteprima, Me.Ordine, Me.Prodotto, Me.Qta, Me.Cliente, Me.Duplicati, Me.Posizione})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgOrdini.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgOrdini.EnableHeadersVisualStyles = False
        Me.DgOrdini.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DgOrdini.Location = New System.Drawing.Point(6, 46)
        Me.DgOrdini.MultiSelect = False
        Me.DgOrdini.Name = "DgOrdini"
        Me.DgOrdini.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgOrdini.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DgOrdini.RowHeadersVisible = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DgOrdini.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.DgOrdini.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DgOrdini.RowTemplate.Height = 150
        Me.DgOrdini.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgOrdini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgOrdini.Size = New System.Drawing.Size(1111, 621)
        Me.DgOrdini.TabIndex = 80
        Me.DgOrdini.TabStop = False
        '
        'Anteprima
        '
        Me.Anteprima.HeaderText = "Anteprima"
        Me.Anteprima.Name = "Anteprima"
        Me.Anteprima.ReadOnly = True
        Me.Anteprima.Width = 68
        '
        'Ordine
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Ordine.DefaultCellStyle = DataGridViewCellStyle3
        Me.Ordine.HeaderText = "Ordine"
        Me.Ordine.Name = "Ordine"
        Me.Ordine.ReadOnly = True
        Me.Ordine.Width = 67
        '
        'Prodotto
        '
        Me.Prodotto.HeaderText = "Prodotto"
        Me.Prodotto.Name = "Prodotto"
        Me.Prodotto.ReadOnly = True
        Me.Prodotto.Width = 78
        '
        'Qta
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Qta.DefaultCellStyle = DataGridViewCellStyle4
        Me.Qta.HeaderText = "Q.ta"
        Me.Qta.Name = "Qta"
        Me.Qta.ReadOnly = True
        Me.Qta.Width = 53
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 68
        '
        'Duplicati
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Duplicati.DefaultCellStyle = DataGridViewCellStyle5
        Me.Duplicati.HeaderText = "Duplicati"
        Me.Duplicati.Name = "Duplicati"
        Me.Duplicati.ReadOnly = True
        Me.Duplicati.Width = 78
        '
        'Posizione
        '
        Me.Posizione.HeaderText = "Posizione"
        Me.Posizione.Name = "Posizione"
        Me.Posizione.ReadOnly = True
        Me.Posizione.Width = 81
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Export
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
        Me.lblTipo.Size = New System.Drawing.Size(93, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Export CTP"
        '
        'OpenFileSorg
        '
        Me.OpenFileSorg.FileName = "Immagine"
        Me.OpenFileSorg.Filter = "Tutti i file|*.*"
        Me.OpenFileSorg.Title = "Seleziona sorgente..."
        '
        'frmCTP
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1398, 749)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmCTP"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Export CTP"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctAnteR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctAnteF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgOrdini, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DgOrdini As System.Windows.Forms.DataGridView
    Friend WithEvents lnkSu As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkGiu As System.Windows.Forms.LinkLabel
    Friend WithEvents btnFileVuoto As System.Windows.Forms.Button
    Friend WithEvents txtFileVuoto As System.Windows.Forms.TextBox
    Friend WithEvents chkFileVuoto As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileSorg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pctAnteR As System.Windows.Forms.PictureBox
    Friend WithEvents pctAnteF As System.Windows.Forms.PictureBox
    Friend WithEvents chkPosDispari As System.Windows.Forms.CheckBox
    Friend WithEvents lnkModModelloCommessa As System.Windows.Forms.LinkLabel
    Friend WithEvents Anteprima As DataGridViewImageColumn
    Friend WithEvents Ordine As DataGridViewTextBoxColumn
    Friend WithEvents Prodotto As DataGridViewTextBoxColumn
    Friend WithEvents Qta As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents Duplicati As DataGridViewTextBoxColumn
    Friend WithEvents Posizione As DataGridViewTextBoxColumn
End Class
