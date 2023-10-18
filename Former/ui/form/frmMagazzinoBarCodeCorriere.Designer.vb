<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMagazzinoBarCodeCorriere
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
        Me.pctTipo = New System.Windows.Forms.PictureBox()
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
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctAnte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHelp.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabMain.Size = New System.Drawing.Size(901, 360)
        Me.TabMain.TabIndex = 6
        Me.TabMain.TabStop = False
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.pctTipo)
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
        Me.tbProd.Size = New System.Drawing.Size(893, 334)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Barcode"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.logo_gls
        Me.pctTipo.Location = New System.Drawing.Point(549, 55)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(181, 56)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctTipo.TabIndex = 97
        Me.pctTipo.TabStop = False
        Me.pctTipo.Visible = False
        '
        'btnIncolla
        '
        Me.btnIncolla.Enabled = False
        Me.btnIncolla.Location = New System.Drawing.Point(672, 159)
        Me.btnIncolla.Name = "btnIncolla"
        Me.btnIncolla.Size = New System.Drawing.Size(58, 23)
        Me.btnIncolla.TabIndex = 96
        Me.btnIncolla.Text = "Incolla"
        Me.btnIncolla.UseVisualStyleBackColor = True
        Me.btnIncolla.Visible = False
        '
        'btnPulisci
        '
        Me.btnPulisci.Enabled = False
        Me.btnPulisci.Location = New System.Drawing.Point(549, 159)
        Me.btnPulisci.Name = "btnPulisci"
        Me.btnPulisci.Size = New System.Drawing.Size(58, 23)
        Me.btnPulisci.TabIndex = 95
        Me.btnPulisci.Text = "Pulisci"
        Me.btnPulisci.UseVisualStyleBackColor = True
        Me.btnPulisci.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = Global.Former.My.Resources.Resources._help
        Me.btnHelp.Location = New System.Drawing.Point(344, 121)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(42, 32)
        Me.btnHelp.TabIndex = 94
        Me.btnHelp.TabStop = False
        Me.btnHelp.UseVisualStyleBackColor = True
        Me.btnHelp.Visible = False
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMsg.Location = New System.Drawing.Point(3, 3)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(882, 49)
        Me.lblMsg.TabIndex = 93
        Me.lblMsg.Text = "-"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdoManuale
        '
        Me.rdoManuale.AutoSize = True
        Me.rdoManuale.Location = New System.Drawing.Point(392, 129)
        Me.rdoManuale.Name = "rdoManuale"
        Me.rdoManuale.Size = New System.Drawing.Size(137, 19)
        Me.rdoManuale.TabIndex = 92
        Me.rdoManuale.Text = "Inserimento Manuale"
        Me.rdoManuale.UseVisualStyleBackColor = True
        '
        'rdoBarCode
        '
        Me.rdoBarCode.AutoSize = True
        Me.rdoBarCode.Checked = True
        Me.rdoBarCode.Location = New System.Drawing.Point(392, 84)
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
        Me.btnOk.Location = New System.Drawing.Point(736, 160)
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
        Me.btnCancel.Location = New System.Drawing.Point(549, 262)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(181, 64)
        Me.btnCancel.TabIndex = 89
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "CHIUDI"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pctAnte
        '
        Me.pctAnte.Image = Global.Former.My.Resources.Resources._BarcodeScanner
        Me.pctAnte.Location = New System.Drawing.Point(47, 55)
        Me.pctAnte.Name = "pctAnte"
        Me.pctAnte.Size = New System.Drawing.Size(250, 232)
        Me.pctAnte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctAnte.TabIndex = 18
        Me.pctAnte.TabStop = False
        '
        'txtCodice
        '
        Me.txtCodice.Enabled = False
        Me.txtCodice.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.txtCodice.Location = New System.Drawing.Point(549, 121)
        Me.txtCodice.MaxLength = 18
        Me.txtCodice.Name = "txtCodice"
        Me.txtCodice.Size = New System.Drawing.Size(181, 36)
        Me.txtCodice.TabIndex = 0
        Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tpHelp
        '
        Me.tpHelp.Controls.Add(Me.Label2)
        Me.tpHelp.Controls.Add(Me.PictureBox3)
        Me.tpHelp.Controls.Add(Me.PictureBox4)
        Me.tpHelp.Controls.Add(Me.Label1)
        Me.tpHelp.Controls.Add(Me.PictureBox2)
        Me.tpHelp.Controls.Add(Me.PictureBox1)
        Me.tpHelp.Location = New System.Drawing.Point(4, 22)
        Me.tpHelp.Name = "tpHelp"
        Me.tpHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHelp.Size = New System.Drawing.Size(893, 334)
        Me.tpHelp.TabIndex = 2
        Me.tpHelp.Text = "HELP - Composizione manuale codice"
        Me.tpHelp.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(262, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 227)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Inserire i 16 caratteri nell'ordine evidenziato"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Former.My.Resources.Resources.logo_gls
        Me.PictureBox3.Location = New System.Drawing.Point(262, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(181, 56)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 27
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.Former.My.Resources.Resources.glsEtichetta
        Me.PictureBox4.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(250, 250)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 26
        Me.PictureBox4.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(701, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 227)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Inserire i 15 caratteri nell'ordine evidenziato"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources.brt
        Me.PictureBox2.Location = New System.Drawing.Point(701, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(181, 56)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 24
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources.barcode2
        Me.PictureBox1.Location = New System.Drawing.Point(448, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(250, 250)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'frmMagazzinoBarCodeCorriere
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(901, 360)
        Me.Controls.Add(Me.TabMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMagazzinoBarCodeCorriere"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Former - Caricamento Colli"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctAnte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHelp.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents tpHelp As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
