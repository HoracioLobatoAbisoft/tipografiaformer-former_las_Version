<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProcedura
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescrizione = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMacchinario = New Former.ucComboWithImage()
        Me.cmbLavorazione = New Former.ucComboWithImage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpStep = New System.Windows.Forms.TabPage()
        Me.UcAmministrazioneStep = New Former.ucAmministrazioneStep()
        Me.tpFileAllegati = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lnkAggiungiAltri = New System.Windows.Forms.LinkLabel()
        Me.lnkRimuoviAltri = New System.Windows.Forms.LinkLabel()
        Me.dgAltriFile = New System.Windows.Forms.DataGridView()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lnkApriAltri = New System.Windows.Forms.LinkLabel()
        Me.OpenFileSorg = New System.Windows.Forms.OpenFileDialog()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStep.SuspendLayout()
        Me.tpFileAllegati.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAltriFile, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 463)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(605, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(521, 12)
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
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(439, 12)
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
        Me.TabMain.Controls.Add(Me.tpStep)
        Me.TabMain.Controls.Add(Me.tpFileAllegati)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(605, 463)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.txtDescrizione)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.cmbMacchinario)
        Me.tbProd.Controls.Add(Me.cmbLavorazione)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtNome)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.ImageKey = "_Procedura"
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(597, 437)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Procedura"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(50, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Descrizione"
        '
        'txtDescrizione
        '
        Me.txtDescrizione.Location = New System.Drawing.Point(140, 228)
        Me.txtDescrizione.MaxLength = 255
        Me.txtDescrizione.Multiline = True
        Me.txtDescrizione.Name = "txtDescrizione"
        Me.txtDescrizione.Size = New System.Drawing.Size(426, 182)
        Me.txtDescrizione.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Macchinario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Lavorazione"
        '
        'cmbMacchinario
        '
        Me.cmbMacchinario.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbMacchinario.DropDownHeight = 500
        Me.cmbMacchinario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMacchinario.FormattingEnabled = True
        Me.cmbMacchinario.HeightImg = 60
        Me.cmbMacchinario.IntegralHeight = False
        Me.cmbMacchinario.ItemHeight = 60
        Me.cmbMacchinario.Location = New System.Drawing.Point(140, 156)
        Me.cmbMacchinario.Name = "cmbMacchinario"
        Me.cmbMacchinario.Size = New System.Drawing.Size(426, 66)
        Me.cmbMacchinario.TabIndex = 19
        Me.cmbMacchinario.WidthImg = 80
        '
        'cmbLavorazione
        '
        Me.cmbLavorazione.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbLavorazione.DropDownHeight = 500
        Me.cmbLavorazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLavorazione.FormattingEnabled = True
        Me.cmbLavorazione.HeightImg = 60
        Me.cmbLavorazione.IntegralHeight = False
        Me.cmbLavorazione.ItemHeight = 60
        Me.cmbLavorazione.Location = New System.Drawing.Point(140, 84)
        Me.cmbLavorazione.Name = "cmbLavorazione"
        Me.cmbLavorazione.Size = New System.Drawing.Size(426, 66)
        Me.cmbLavorazione.TabIndex = 18
        Me.cmbLavorazione.WidthImg = 80
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Nome"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(140, 57)
        Me.txtNome.MaxLength = 255
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(426, 20)
        Me.txtNome.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Procedura
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
        Me.lblTipo.Size = New System.Drawing.Size(103, 25)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Procedura"
        '
        'tpStep
        '
        Me.tpStep.Controls.Add(Me.UcAmministrazioneStep)
        Me.tpStep.ImageKey = "_Step"
        Me.tpStep.Location = New System.Drawing.Point(4, 22)
        Me.tpStep.Name = "tpStep"
        Me.tpStep.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStep.Size = New System.Drawing.Size(597, 437)
        Me.tpStep.TabIndex = 1
        Me.tpStep.Text = "Step della procedura"
        Me.tpStep.UseVisualStyleBackColor = True
        '
        'UcAmministrazioneStep
        '
        Me.UcAmministrazioneStep.BackColor = System.Drawing.Color.White
        Me.UcAmministrazioneStep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazioneStep.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazioneStep.IdProcedura = 0
        Me.UcAmministrazioneStep.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazioneStep.Name = "UcAmministrazioneStep"
        Me.UcAmministrazioneStep.Size = New System.Drawing.Size(591, 431)
        Me.UcAmministrazioneStep.TabIndex = 0
        '
        'tpFileAllegati
        '
        Me.tpFileAllegati.Controls.Add(Me.Label5)
        Me.tpFileAllegati.Controls.Add(Me.PictureBox5)
        Me.tpFileAllegati.Controls.Add(Me.lnkAggiungiAltri)
        Me.tpFileAllegati.Controls.Add(Me.lnkRimuoviAltri)
        Me.tpFileAllegati.Controls.Add(Me.dgAltriFile)
        Me.tpFileAllegati.Controls.Add(Me.lnkApriAltri)
        Me.tpFileAllegati.ImageKey = "_Allega"
        Me.tpFileAllegati.Location = New System.Drawing.Point(4, 22)
        Me.tpFileAllegati.Name = "tpFileAllegati"
        Me.tpFileAllegati.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFileAllegati.Size = New System.Drawing.Size(597, 437)
        Me.tpFileAllegati.TabIndex = 2
        Me.tpFileAllegati.Text = "File Allegati"
        Me.tpFileAllegati.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(52, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(537, 35)
        Me.Label5.TabIndex = 75
        Me.Label5.Tag = "In questa schermata sono elencati i file sorgenti associati all'ordine."
        Me.Label5.Text = "In questa schermata sono elencati gli altri file allegati all'ordine. Si possono " &
    "allegare file di qualsiasi tipo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.Former.My.Resources.Resources._Allega
        Me.PictureBox5.Location = New System.Drawing.Point(8, 6)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox5.TabIndex = 74
        Me.PictureBox5.TabStop = False
        '
        'lnkAggiungiAltri
        '
        Me.lnkAggiungiAltri.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiungiAltri.Image = Global.Former.My.Resources.Resources.plus
        Me.lnkAggiungiAltri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiungiAltri.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiungiAltri.Location = New System.Drawing.Point(3, 100)
        Me.lnkAggiungiAltri.Name = "lnkAggiungiAltri"
        Me.lnkAggiungiAltri.Size = New System.Drawing.Size(86, 37)
        Me.lnkAggiungiAltri.TabIndex = 72
        Me.lnkAggiungiAltri.TabStop = True
        Me.lnkAggiungiAltri.Text = "Aggiungi"
        Me.lnkAggiungiAltri.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkRimuoviAltri
        '
        Me.lnkRimuoviAltri.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRimuoviAltri.Image = Global.Former.My.Resources.Resources.minus
        Me.lnkRimuoviAltri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRimuoviAltri.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRimuoviAltri.Location = New System.Drawing.Point(3, 137)
        Me.lnkRimuoviAltri.Name = "lnkRimuoviAltri"
        Me.lnkRimuoviAltri.Size = New System.Drawing.Size(80, 37)
        Me.lnkRimuoviAltri.TabIndex = 73
        Me.lnkRimuoviAltri.TabStop = True
        Me.lnkRimuoviAltri.Text = "Rimuovi"
        Me.lnkRimuoviAltri.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgAltriFile
        '
        Me.dgAltriFile.AllowUserToAddRows = False
        Me.dgAltriFile.AllowUserToDeleteRows = False
        Me.dgAltriFile.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgAltriFile.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgAltriFile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAltriFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgAltriFile.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgAltriFile.BackgroundColor = System.Drawing.Color.White
        Me.dgAltriFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgAltriFile.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAltriFile.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgAltriFile.ColumnHeadersHeight = 20
        Me.dgAltriFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgAltriFile.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FilePath})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAltriFile.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgAltriFile.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgAltriFile.EnableHeadersVisualStyles = False
        Me.dgAltriFile.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgAltriFile.Location = New System.Drawing.Point(152, 66)
        Me.dgAltriFile.MultiSelect = False
        Me.dgAltriFile.Name = "dgAltriFile"
        Me.dgAltriFile.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAltriFile.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgAltriFile.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgAltriFile.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgAltriFile.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgAltriFile.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgAltriFile.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgAltriFile.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAltriFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAltriFile.Size = New System.Drawing.Size(439, 354)
        Me.dgAltriFile.TabIndex = 71
        Me.dgAltriFile.TabStop = False
        '
        'FilePath
        '
        Me.FilePath.DataPropertyName = "FileAllegato"
        Me.FilePath.HeaderText = "File Allegato"
        Me.FilePath.Name = "FilePath"
        Me.FilePath.ReadOnly = True
        '
        'lnkApriAltri
        '
        Me.lnkApriAltri.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkApriAltri.Image = Global.Former.My.Resources.Resources._Shell
        Me.lnkApriAltri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkApriAltri.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApriAltri.Location = New System.Drawing.Point(3, 66)
        Me.lnkApriAltri.Name = "lnkApriAltri"
        Me.lnkApriAltri.Size = New System.Drawing.Size(143, 26)
        Me.lnkApriAltri.TabIndex = 70
        Me.lnkApriAltri.TabStop = True
        Me.lnkApriAltri.Text = "Apri file selezionato"
        Me.lnkApriAltri.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OpenFileSorg
        '
        Me.OpenFileSorg.Filter = "File PDF|*.PDF"
        Me.OpenFileSorg.Title = "Seleziona sorgente..."
        '
        'frmProcedura
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(605, 511)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmProcedura"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Procedura"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStep.ResumeLayout(False)
        Me.tpFileAllegati.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAltriFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbMacchinario As ucComboWithImage
    Friend WithEvents cmbLavorazione As ucComboWithImage
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDescrizione As TextBox
    Friend WithEvents tpStep As TabPage
    Friend WithEvents UcAmministrazioneStep As ucAmministrazioneStep
    Friend WithEvents tpFileAllegati As TabPage
    Friend WithEvents lnkAggiungiAltri As LinkLabel
    Friend WithEvents lnkRimuoviAltri As LinkLabel
    Friend WithEvents dgAltriFile As DataGridView
    Friend WithEvents FilePath As DataGridViewTextBoxColumn
    Friend WithEvents lnkApriAltri As LinkLabel
    Friend WithEvents OpenFileSorg As OpenFileDialog
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox5 As PictureBox
End Class
