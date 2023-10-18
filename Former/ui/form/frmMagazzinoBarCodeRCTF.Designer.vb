<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMagazzinoBarCodeRCTF
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
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnChiudiRiapri = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnIncolla = New System.Windows.Forms.Button()
        Me.btnPulisci = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.rdoManuale = New System.Windows.Forms.RadioButton()
        Me.rdoBarCode = New System.Windows.Forms.RadioButton()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pctAnte = New System.Windows.Forms.PictureBox()
        Me.txtCodice = New System.Windows.Forms.TextBox()
        Me.tpHelp = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctAnte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHelp.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpHelp)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(893, 369)
        Me.TabMain.TabIndex = 6
        Me.TabMain.TabStop = False
        '
        'tbProd
        '
        Me.tbProd.BackColor = System.Drawing.Color.White
        Me.tbProd.Controls.Add(Me.btnChiudiRiapri)
        Me.tbProd.Controls.Add(Me.PictureBox3)
        Me.tbProd.Controls.Add(Me.btnIncolla)
        Me.tbProd.Controls.Add(Me.btnPulisci)
        Me.tbProd.Controls.Add(Me.btnHelp)
        Me.tbProd.Controls.Add(Me.lblMsg)
        Me.tbProd.Controls.Add(Me.rdoManuale)
        Me.tbProd.Controls.Add(Me.rdoBarCode)
        Me.tbProd.Controls.Add(Me.btnOk)
        Me.tbProd.Controls.Add(Me.btnCancel)
        Me.tbProd.Controls.Add(Me.pctAnte)
        Me.tbProd.Controls.Add(Me.txtCodice)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(885, 343)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Barcode"
        '
        'btnChiudiRiapri
        '
        Me.btnChiudiRiapri.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChiudiRiapri.BackColor = System.Drawing.Color.Lime
        Me.btnChiudiRiapri.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnChiudiRiapri.Enabled = False
        Me.btnChiudiRiapri.FlatAppearance.BorderSize = 0
        Me.btnChiudiRiapri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChiudiRiapri.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnChiudiRiapri.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnChiudiRiapri.Location = New System.Drawing.Point(647, 262)
        Me.btnChiudiRiapri.Name = "btnChiudiRiapri"
        Me.btnChiudiRiapri.Size = New System.Drawing.Size(181, 64)
        Me.btnChiudiRiapri.TabIndex = 99
        Me.btnChiudiRiapri.TabStop = False
        Me.btnChiudiRiapri.Text = "CHIUDI E CREA NUOVA SCATOLA"
        Me.btnChiudiRiapri.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.Former.My.Resources.Resources.logo
        Me.PictureBox3.Location = New System.Drawing.Point(549, 100)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(181, 56)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 98
        Me.PictureBox3.TabStop = False
        '
        'btnIncolla
        '
        Me.btnIncolla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnIncolla.Enabled = False
        Me.btnIncolla.Location = New System.Drawing.Point(672, 204)
        Me.btnIncolla.Name = "btnIncolla"
        Me.btnIncolla.Size = New System.Drawing.Size(58, 23)
        Me.btnIncolla.TabIndex = 96
        Me.btnIncolla.Text = "Incolla"
        Me.btnIncolla.UseVisualStyleBackColor = True
        Me.btnIncolla.Visible = False
        '
        'btnPulisci
        '
        Me.btnPulisci.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPulisci.Enabled = False
        Me.btnPulisci.Location = New System.Drawing.Point(549, 204)
        Me.btnPulisci.Name = "btnPulisci"
        Me.btnPulisci.Size = New System.Drawing.Size(58, 23)
        Me.btnPulisci.TabIndex = 95
        Me.btnPulisci.Text = "Pulisci"
        Me.btnPulisci.UseVisualStyleBackColor = True
        Me.btnPulisci.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = Global.Former.My.Resources.Resources._help
        Me.btnHelp.Location = New System.Drawing.Point(344, 166)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(42, 32)
        Me.btnHelp.TabIndex = 94
        Me.btnHelp.TabStop = False
        Me.btnHelp.UseVisualStyleBackColor = True
        Me.btnHelp.Visible = False
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(43, 3)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(799, 78)
        Me.lblMsg.TabIndex = 93
        Me.lblMsg.Text = "-"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdoManuale
        '
        Me.rdoManuale.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdoManuale.AutoSize = True
        Me.rdoManuale.Location = New System.Drawing.Point(392, 174)
        Me.rdoManuale.Name = "rdoManuale"
        Me.rdoManuale.Size = New System.Drawing.Size(137, 19)
        Me.rdoManuale.TabIndex = 92
        Me.rdoManuale.Text = "Inserimento Manuale"
        Me.rdoManuale.UseVisualStyleBackColor = True
        '
        'rdoBarCode
        '
        Me.rdoBarCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rdoBarCode.AutoSize = True
        Me.rdoBarCode.Checked = True
        Me.rdoBarCode.Location = New System.Drawing.Point(392, 129)
        Me.rdoBarCode.Name = "rdoBarCode"
        Me.rdoBarCode.Size = New System.Drawing.Size(101, 19)
        Me.rdoBarCode.TabIndex = 0
        Me.rdoBarCode.TabStop = True
        Me.rdoBarCode.Text = "Codice a barre"
        Me.rdoBarCode.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Image = Global.Former.My.Resources.Resources.barcode1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(736, 166)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(96, 32)
        Me.btnOk.TabIndex = 90
        Me.btnOk.TabStop = False
        Me.btnOk.Text = "Conferma"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = False
        Me.btnOk.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.Image = Global.Former.My.Resources.Resources.checkmark
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(445, 262)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(181, 64)
        Me.btnCancel.TabIndex = 89
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "CHIUDI"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pctAnte
        '
        Me.pctAnte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pctAnte.Image = Global.Former.My.Resources.Resources._BarcodeScanner
        Me.pctAnte.Location = New System.Drawing.Point(47, 100)
        Me.pctAnte.Name = "pctAnte"
        Me.pctAnte.Size = New System.Drawing.Size(250, 232)
        Me.pctAnte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctAnte.TabIndex = 18
        Me.pctAnte.TabStop = False
        '
        'txtCodice
        '
        Me.txtCodice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCodice.Enabled = False
        Me.txtCodice.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.txtCodice.Location = New System.Drawing.Point(549, 166)
        Me.txtCodice.MaxLength = 13
        Me.txtCodice.Name = "txtCodice"
        Me.txtCodice.Size = New System.Drawing.Size(181, 36)
        Me.txtCodice.TabIndex = 0
        Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tpHelp
        '
        Me.tpHelp.Controls.Add(Me.Label2)
        Me.tpHelp.Controls.Add(Me.PictureBox1)
        Me.tpHelp.Controls.Add(Me.PictureBox4)
        Me.tpHelp.Location = New System.Drawing.Point(4, 22)
        Me.tpHelp.Name = "tpHelp"
        Me.tpHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHelp.Size = New System.Drawing.Size(885, 343)
        Me.tpHelp.TabIndex = 1
        Me.tpHelp.Text = "HELP - Composizione manuale codice"
        Me.tpHelp.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(262, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 191)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Inserire i 13 caratteri nell'ordine evidenziato"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(262, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(181, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.Former.My.Resources.Resources.BarCodeOld
        Me.PictureBox4.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(250, 179)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 29
        Me.PictureBox4.TabStop = False
        '
        'frmMagazzinoBarCodeRCTF
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(893, 369)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "frmMagazzinoBarCodeRCTF"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Former - Caricamento Colli"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctAnte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHelp.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents txtCodice As System.Windows.Forms.TextBox
    Friend WithEvents pctAnte As System.Windows.Forms.PictureBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rdoBarCode As System.Windows.Forms.RadioButton
    Friend WithEvents rdoManuale As System.Windows.Forms.RadioButton
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnIncolla As System.Windows.Forms.Button
    Friend WithEvents btnPulisci As System.Windows.Forms.Button
    Friend WithEvents tpHelp As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents btnChiudiRiapri As Button
End Class
