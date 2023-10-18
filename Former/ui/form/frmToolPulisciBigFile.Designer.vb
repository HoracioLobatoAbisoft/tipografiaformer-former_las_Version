<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmToolPulisciBigFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmToolPulisciBigFile))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.cmbReparto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkDataInsAl = New System.Windows.Forms.CheckBox()
        Me.chkDataInsDal = New System.Windows.Forms.CheckBox()
        Me.dtDataInsAl = New System.Windows.Forms.DateTimePicker()
        Me.dtDataInsDal = New System.Windows.Forms.DateTimePicker()
        Me.lnkOpenFoldSorg = New System.Windows.Forms.LinkLabel()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.lnkApriCon = New System.Windows.Forms.LinkLabel()
        Me.lnkApriFile = New System.Windows.Forms.LinkLabel()
        Me.btnCerca = New System.Windows.Forms.Button()
        Me.dgRis = New Former.ucDataGridView()
        Me.Titolo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Testo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMinSize = New Former.ucNumericTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.dgRis, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 635)
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
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(871, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
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
        Me.TabMain.Size = New System.Drawing.Size(955, 635)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.cmbReparto)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.chkDataInsAl)
        Me.tbProd.Controls.Add(Me.chkDataInsDal)
        Me.tbProd.Controls.Add(Me.dtDataInsAl)
        Me.tbProd.Controls.Add(Me.dtDataInsDal)
        Me.tbProd.Controls.Add(Me.lnkOpenFoldSorg)
        Me.tbProd.Controls.Add(Me.btnStop)
        Me.tbProd.Controls.Add(Me.lnkApriCon)
        Me.tbProd.Controls.Add(Me.lnkApriFile)
        Me.tbProd.Controls.Add(Me.btnCerca)
        Me.tbProd.Controls.Add(Me.dgRis)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtMinSize)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblPath)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(947, 609)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Trova file sorgenti di grandi dimensioni"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'cmbReparto
        '
        Me.cmbReparto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReparto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbReparto.FormattingEnabled = True
        Me.cmbReparto.Location = New System.Drawing.Point(142, 107)
        Me.cmbReparto.Name = "cmbReparto"
        Me.cmbReparto.Size = New System.Drawing.Size(168, 23)
        Me.cmbReparto.TabIndex = 127
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 15)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Reparto Online"
        '
        'chkDataInsAl
        '
        Me.chkDataInsAl.AutoSize = True
        Me.chkDataInsAl.ForeColor = System.Drawing.Color.Black
        Me.chkDataInsAl.Location = New System.Drawing.Point(321, 79)
        Me.chkDataInsAl.Name = "chkDataInsAl"
        Me.chkDataInsAl.Size = New System.Drawing.Size(37, 19)
        Me.chkDataInsAl.TabIndex = 104
        Me.chkDataInsAl.Text = "Al"
        Me.chkDataInsAl.UseVisualStyleBackColor = True
        '
        'chkDataInsDal
        '
        Me.chkDataInsDal.AutoSize = True
        Me.chkDataInsDal.ForeColor = System.Drawing.Color.Black
        Me.chkDataInsDal.Location = New System.Drawing.Point(53, 79)
        Me.chkDataInsDal.Name = "chkDataInsDal"
        Me.chkDataInsDal.Size = New System.Drawing.Size(43, 19)
        Me.chkDataInsDal.TabIndex = 102
        Me.chkDataInsDal.Text = "Dal"
        Me.chkDataInsDal.UseVisualStyleBackColor = True
        '
        'dtDataInsAl
        '
        Me.dtDataInsAl.Location = New System.Drawing.Point(370, 78)
        Me.dtDataInsAl.Name = "dtDataInsAl"
        Me.dtDataInsAl.Size = New System.Drawing.Size(208, 20)
        Me.dtDataInsAl.TabIndex = 103
        '
        'dtDataInsDal
        '
        Me.dtDataInsDal.Location = New System.Drawing.Point(102, 78)
        Me.dtDataInsDal.Name = "dtDataInsDal"
        Me.dtDataInsDal.Size = New System.Drawing.Size(208, 20)
        Me.dtDataInsDal.TabIndex = 101
        '
        'lnkOpenFoldSorg
        '
        Me.lnkOpenFoldSorg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkOpenFoldSorg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkOpenFoldSorg.Image = Global.Former.My.Resources.Resources._CartellaAperta
        Me.lnkOpenFoldSorg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkOpenFoldSorg.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkOpenFoldSorg.Location = New System.Drawing.Point(601, 580)
        Me.lnkOpenFoldSorg.Name = "lnkOpenFoldSorg"
        Me.lnkOpenFoldSorg.Size = New System.Drawing.Size(100, 26)
        Me.lnkOpenFoldSorg.TabIndex = 85
        Me.lnkOpenFoldSorg.TabStop = True
        Me.lnkOpenFoldSorg.Text = "Apri cartella"
        Me.lnkOpenFoldSorg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(864, 52)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 84
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'lnkApriCon
        '
        Me.lnkApriCon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkApriCon.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkApriCon.Image = CType(resources.GetObject("lnkApriCon.Image"), System.Drawing.Image)
        Me.lnkApriCon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkApriCon.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApriCon.Location = New System.Drawing.Point(850, 580)
        Me.lnkApriCon.Name = "lnkApriCon"
        Me.lnkApriCon.Size = New System.Drawing.Size(89, 26)
        Me.lnkApriCon.TabIndex = 83
        Me.lnkApriCon.TabStop = True
        Me.lnkApriCon.Text = "Apri con..."
        Me.lnkApriCon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkApriFile
        '
        Me.lnkApriFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkApriFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkApriFile.Image = CType(resources.GetObject("lnkApriFile.Image"), System.Drawing.Image)
        Me.lnkApriFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkApriFile.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkApriFile.Location = New System.Drawing.Point(707, 580)
        Me.lnkApriFile.Name = "lnkApriFile"
        Me.lnkApriFile.Size = New System.Drawing.Size(137, 26)
        Me.lnkApriFile.TabIndex = 59
        Me.lnkApriFile.TabStop = True
        Me.lnkApriFile.Text = "Apri file selezionato"
        Me.lnkApriFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCerca
        '
        Me.btnCerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerca.Location = New System.Drawing.Point(783, 52)
        Me.btnCerca.Name = "btnCerca"
        Me.btnCerca.Size = New System.Drawing.Size(75, 23)
        Me.btnCerca.TabIndex = 29
        Me.btnCerca.Text = "Cerca"
        Me.btnCerca.UseVisualStyleBackColor = True
        '
        'dgRis
        '
        Me.dgRis.AllowUserToAddRows = False
        Me.dgRis.AllowUserToDeleteRows = False
        Me.dgRis.AllowUserToOrderColumns = True
        Me.dgRis.AllowUserToResizeRows = False
        Me.dgRis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgRis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgRis.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgRis.BackgroundColor = System.Drawing.Color.White
        Me.dgRis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgRis.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgRis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Titolo, Me.Testo})
        Me.dgRis.CustomVirtualMode = False
        Me.dgRis.DataSourceVirtual = Nothing
        Me.dgRis.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgRis.Location = New System.Drawing.Point(53, 142)
        Me.dgRis.Name = "dgRis"
        Me.dgRis.RowHeadersVisible = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgRis.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgRis.RowTemplate.Height = 30
        Me.dgRis.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRis.ScrollManuale = False
        Me.dgRis.ScrollValue = 0
        Me.dgRis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRis.ShowEditingIcon = False
        Me.dgRis.Size = New System.Drawing.Size(886, 435)
        Me.dgRis.TabIndex = 28
        '
        'Titolo
        '
        Me.Titolo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Titolo.DataPropertyName = "Id"
        Me.Titolo.HeaderText = "Dimensioni (Mb)"
        Me.Titolo.Name = "Titolo"
        Me.Titolo.Width = 120
        '
        'Testo
        '
        Me.Testo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Testo.DataPropertyName = "Descrizione"
        Me.Testo.HeaderText = "Path"
        Me.Testo.Name = "Testo"
        Me.Testo.Width = 700
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(264, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "(1000 megabyte = 1 gigabyte)"
        '
        'txtMinSize
        '
        Me.txtMinSize.My_AccettaNegativi = False
        Me.txtMinSize.My_DefaultValue = 0
        Me.txtMinSize.Location = New System.Drawing.Point(198, 52)
        Me.txtMinSize.MaxLength = 5
        Me.txtMinSize.My_MaxValue = 99999.0!
        Me.txtMinSize.My_MinValue = 1.0!
        Me.txtMinSize.Name = "txtMinSize"
        Me.txtMinSize.My_AllowOnlyInteger = True
        Me.txtMinSize.My_ReplaceWithDefaultValue = True
        Me.txtMinSize.Size = New System.Drawing.Size(60, 20)
        Me.txtMinSize.TabIndex = 18
        Me.txtMinSize.Text = "500"
        Me.txtMinSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(52, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Dimensioni Minime (mb)"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.folder_open
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblPath.Location = New System.Drawing.Point(49, 12)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(16, 21)
        Me.lblPath.TabIndex = 13
        Me.lblPath.Text = "-"
        '
        'frmToolPulisciBigFile
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 683)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmToolPulisciBigFile"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Trova file sorgenti di grandi dimensioni"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.dgRis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMinSize As ucNumericTextBox
    Friend WithEvents dgRis As ucDataGridView
    Friend WithEvents Titolo As DataGridViewTextBoxColumn
    Friend WithEvents Testo As DataGridViewTextBoxColumn
    Friend WithEvents btnCerca As Button
    Friend WithEvents lnkApriFile As LinkLabel
    Friend WithEvents lnkApriCon As LinkLabel
    Friend WithEvents btnStop As Button
    Friend WithEvents lnkOpenFoldSorg As LinkLabel
    Friend WithEvents chkDataInsAl As CheckBox
    Friend WithEvents chkDataInsDal As CheckBox
    Friend WithEvents dtDataInsAl As DateTimePicker
    Friend WithEvents dtDataInsDal As DateTimePicker
    Friend WithEvents cmbReparto As ComboBox
    Friend WithEvents Label2 As Label
End Class
