<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodTrackGls
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCodTrackGls))
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbIndirizzo = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnIncolla = New System.Windows.Forms.Button()
        Me.rdoManuale = New System.Windows.Forms.RadioButton()
        Me.rdoBarCode = New System.Windows.Forms.RadioButton()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtCodTrack = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.tpHelp = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pctAnte = New System.Windows.Forms.PictureBox()
        Me.TabMain.SuspendLayout()
        Me.tbIndirizzo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHelp.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctAnte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbIndirizzo)
        Me.TabMain.Controls.Add(Me.tpHelp)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(893, 323)
        Me.TabMain.TabIndex = 6
        '
        'tbIndirizzo
        '
        Me.tbIndirizzo.Controls.Add(Me.PictureBox1)
        Me.tbIndirizzo.Controls.Add(Me.lblMsg)
        Me.tbIndirizzo.Controls.Add(Me.btnCancel)
        Me.tbIndirizzo.Controls.Add(Me.btnOk)
        Me.tbIndirizzo.Controls.Add(Me.btnIncolla)
        Me.tbIndirizzo.Controls.Add(Me.rdoManuale)
        Me.tbIndirizzo.Controls.Add(Me.rdoBarCode)
        Me.tbIndirizzo.Controls.Add(Me.btnReset)
        Me.tbIndirizzo.Controls.Add(Me.txtCodTrack)
        Me.tbIndirizzo.Controls.Add(Me.pctTipo)
        Me.tbIndirizzo.Location = New System.Drawing.Point(4, 24)
        Me.tbIndirizzo.Name = "tbIndirizzo"
        Me.tbIndirizzo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbIndirizzo.Size = New System.Drawing.Size(885, 295)
        Me.tbIndirizzo.TabIndex = 0
        Me.tbIndirizzo.Text = "Former - Codice Tracking GLS"
        Me.tbIndirizzo.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources._BarcodeScanner
        Me.PictureBox1.Location = New System.Drawing.Point(47, 55)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(250, 232)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 101
        Me.PictureBox1.TabStop = False
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMsg.Location = New System.Drawing.Point(3, 3)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(882, 49)
        Me.lblMsg.TabIndex = 100
        Me.lblMsg.Text = "Inserisci Codice Tracking GLS"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.Image = Global.Former.My.Resources.checkmark
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(549, 223)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(181, 63)
        Me.btnCancel.TabIndex = 99
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "CHIUDI"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Image = Global.Former.My.Resources.barcode1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(736, 121)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(96, 32)
        Me.btnOk.TabIndex = 98
        Me.btnOk.TabStop = False
        Me.btnOk.Text = "Conferma"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = False
        Me.btnOk.Visible = False
        '
        'btnIncolla
        '
        Me.btnIncolla.Enabled = False
        Me.btnIncolla.Location = New System.Drawing.Point(672, 159)
        Me.btnIncolla.Name = "btnIncolla"
        Me.btnIncolla.Size = New System.Drawing.Size(58, 23)
        Me.btnIncolla.TabIndex = 97
        Me.btnIncolla.Text = "Incolla"
        Me.btnIncolla.UseVisualStyleBackColor = True
        Me.btnIncolla.Visible = False
        '
        'rdoManuale
        '
        Me.rdoManuale.AutoSize = True
        Me.rdoManuale.Location = New System.Drawing.Point(392, 129)
        Me.rdoManuale.Name = "rdoManuale"
        Me.rdoManuale.Size = New System.Drawing.Size(141, 19)
        Me.rdoManuale.TabIndex = 94
        Me.rdoManuale.Text = "Inserimento Manuale"
        Me.rdoManuale.UseVisualStyleBackColor = True
        '
        'rdoBarCode
        '
        Me.rdoBarCode.AutoSize = True
        Me.rdoBarCode.Checked = True
        Me.rdoBarCode.Location = New System.Drawing.Point(392, 84)
        Me.rdoBarCode.Name = "rdoBarCode"
        Me.rdoBarCode.Size = New System.Drawing.Size(106, 19)
        Me.rdoBarCode.TabIndex = 93
        Me.rdoBarCode.TabStop = True
        Me.rdoBarCode.Text = "Codice a barre"
        Me.rdoBarCode.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(549, 159)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(58, 23)
        Me.btnReset.TabIndex = 21
        Me.btnReset.Text = "Pulisci"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtCodTrack
        '
        Me.txtCodTrack.Enabled = False
        Me.txtCodTrack.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.txtCodTrack.Location = New System.Drawing.Point(549, 121)
        Me.txtCodTrack.MaxLength = 50
        Me.txtCodTrack.Name = "txtCodTrack"
        Me.txtCodTrack.Size = New System.Drawing.Size(181, 32)
        Me.txtCodTrack.TabIndex = 0
        Me.txtCodTrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.logo_gls
        Me.pctTipo.Location = New System.Drawing.Point(549, 55)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(181, 56)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'tpHelp
        '
        Me.tpHelp.Controls.Add(Me.Label1)
        Me.tpHelp.Controls.Add(Me.PictureBox2)
        Me.tpHelp.Controls.Add(Me.pctAnte)
        Me.tpHelp.Location = New System.Drawing.Point(4, 24)
        Me.tpHelp.Name = "tpHelp"
        Me.tpHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHelp.Size = New System.Drawing.Size(885, 295)
        Me.tpHelp.TabIndex = 1
        Me.tpHelp.Text = "HELP - Composizione manuale codice"
        Me.tpHelp.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(298, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 227)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Inserire i 16 caratteri evidenziati"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.logo_gls
        Me.PictureBox2.Location = New System.Drawing.Point(298, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(181, 56)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 24
        Me.PictureBox2.TabStop = False
        '
        'pctAnte
        '
        Me.pctAnte.Image = Global.Former.My.Resources.glsEtichetta
        Me.pctAnte.Location = New System.Drawing.Point(6, 6)
        Me.pctAnte.Name = "pctAnte"
        Me.pctAnte.Size = New System.Drawing.Size(286, 286)
        Me.pctAnte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctAnte.TabIndex = 23
        Me.pctAnte.TabStop = False
        '
        'frmCodTrackGls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        
        Me.ClientSize = New System.Drawing.Size(893, 323)
        Me.Controls.Add(Me.TabMain)
        
        Me.Name = "frmCodTrackGls"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabMain.ResumeLayout(False)
        Me.tbIndirizzo.ResumeLayout(False)
        Me.tbIndirizzo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHelp.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctAnte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbIndirizzo As System.Windows.Forms.TabPage
    Friend WithEvents txtCodTrack As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents rdoManuale As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBarCode As System.Windows.Forms.RadioButton
    Friend WithEvents btnIncolla As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tpHelp As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents pctAnte As System.Windows.Forms.PictureBox
End Class
