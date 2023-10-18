<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsegnaModificaDati
    Inherits baseFormInternaFixed

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsegnaModificaDati))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.mcDataScelta = New System.Windows.Forms.MonthCalendar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.cmbCorriere = New System.Windows.Forms.ComboBox()
        Me.cmbIndirizzo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblDataSel = New System.Windows.Forms.Label()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 428)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(676, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(512, 13)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(152, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi senza salvare"
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
        Me.btnOk.Location = New System.Drawing.Point(377, 13)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(129, 32)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Salva modifiche"
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
        Me.TabMain.Size = New System.Drawing.Size(676, 428)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblDataSel)
        Me.tbProd.Controls.Add(Me.mcDataScelta)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.lblCliente)
        Me.tbProd.Controls.Add(Me.cmbCorriere)
        Me.tbProd.Controls.Add(Me.cmbIndirizzo)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.Label11)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(668, 402)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Modifica Dati Consegna"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'mcDataScelta
        '
        Me.mcDataScelta.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mcDataScelta.Location = New System.Drawing.Point(123, 88)
        Me.mcDataScelta.MaxSelectionCount = 1
        Me.mcDataScelta.Name = "mcDataScelta"
        Me.mcDataScelta.TabIndex = 82
        '
        'Label5
        '
        Me.Label5.AutoEllipsis = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(362, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(298, 79)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 15)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Data Consegna"
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.LightGray
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCliente.Location = New System.Drawing.Point(123, 259)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(537, 23)
        Me.lblCliente.TabIndex = 78
        Me.lblCliente.Text = "-"
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCorriere
        '
        Me.cmbCorriere.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCorriere.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCorriere.BackColor = System.Drawing.Color.Gray
        Me.cmbCorriere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorriere.ForeColor = System.Drawing.Color.White
        Me.cmbCorriere.FormattingEnabled = True
        Me.cmbCorriere.Location = New System.Drawing.Point(123, 315)
        Me.cmbCorriere.Name = "cmbCorriere"
        Me.cmbCorriere.Size = New System.Drawing.Size(227, 21)
        Me.cmbCorriere.TabIndex = 77
        '
        'cmbIndirizzo
        '
        Me.cmbIndirizzo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbIndirizzo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbIndirizzo.BackColor = System.Drawing.Color.Gray
        Me.cmbIndirizzo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIndirizzo.ForeColor = System.Drawing.Color.White
        Me.cmbIndirizzo.FormattingEnabled = True
        Me.cmbIndirizzo.Location = New System.Drawing.Point(123, 288)
        Me.cmbIndirizzo.Name = "cmbIndirizzo"
        Me.cmbIndirizzo.Size = New System.Drawing.Size(537, 21)
        Me.cmbIndirizzo.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 318)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Corriere"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Destinatario"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(8, 291)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 15)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Indirizzo consegna"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Consegna
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
        Me.lblTipo.Size = New System.Drawing.Size(193, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Modifica Dati Consegna"
        '
        'lblDataSel
        '
        Me.lblDataSel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblDataSel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.lblDataSel.Location = New System.Drawing.Point(123, 51)
        Me.lblDataSel.Name = "lblDataSel"
        Me.lblDataSel.Size = New System.Drawing.Size(227, 28)
        Me.lblDataSel.TabIndex = 83
        Me.lblDataSel.Text = "-"
        Me.lblDataSel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmConsegnaModificaDati
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(676, 476)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmConsegnaModificaDati"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Modifica Dati Consegna"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents cmbCorriere As System.Windows.Forms.ComboBox
    Friend WithEvents cmbIndirizzo As System.Windows.Forms.ComboBox
    Friend WithEvents mcDataScelta As MonthCalendar
    Friend WithEvents lblDataSel As Label
End Class
