<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarketingEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarketingEmail))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpHtml = New System.Windows.Forms.TabPage()
        Me.txtTestoMail = New System.Windows.Forms.TextBox()
        Me.tpAnteprima = New System.Windows.Forms.TabPage()
        Me.webAnteprima = New System.Windows.Forms.WebBrowser()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblDestinatario = New System.Windows.Forms.Label()
        Me.cmbTipoProd = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTitolo = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.UcInfoBoxModelli = New Former.ucInfoBox()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpHtml.SuspendLayout()
        Me.tpAnteprima.SuspendLayout()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(1, 575)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(671, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(635, 12)
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
        Me.btnOk.Location = New System.Drawing.Point(599, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(1, 1)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(671, 574)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.UcInfoBoxModelli)
        Me.tbProd.Controls.Add(Me.TabControl1)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.lblStatus)
        Me.tbProd.Controls.Add(Me.lblDestinatario)
        Me.tbProd.Controls.Add(Me.cmbTipoProd)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtTitolo)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(663, 548)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Email"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpHtml)
        Me.TabControl1.Controls.Add(Me.tpAnteprima)
        Me.TabControl1.Location = New System.Drawing.Point(93, 191)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(564, 322)
        Me.TabControl1.TabIndex = 27
        '
        'tpHtml
        '
        Me.tpHtml.Controls.Add(Me.txtTestoMail)
        Me.tpHtml.Location = New System.Drawing.Point(4, 22)
        Me.tpHtml.Name = "tpHtml"
        Me.tpHtml.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHtml.Size = New System.Drawing.Size(556, 296)
        Me.tpHtml.TabIndex = 0
        Me.tpHtml.Text = "HTML"
        Me.tpHtml.UseVisualStyleBackColor = True
        '
        'txtTestoMail
        '
        Me.txtTestoMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTestoMail.Location = New System.Drawing.Point(3, 3)
        Me.txtTestoMail.Multiline = True
        Me.txtTestoMail.Name = "txtTestoMail"
        Me.txtTestoMail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTestoMail.Size = New System.Drawing.Size(550, 290)
        Me.txtTestoMail.TabIndex = 21
        '
        'tpAnteprima
        '
        Me.tpAnteprima.Controls.Add(Me.webAnteprima)
        Me.tpAnteprima.Location = New System.Drawing.Point(4, 22)
        Me.tpAnteprima.Name = "tpAnteprima"
        Me.tpAnteprima.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAnteprima.Size = New System.Drawing.Size(556, 237)
        Me.tpAnteprima.TabIndex = 1
        Me.tpAnteprima.Text = "Anteprima"
        Me.tpAnteprima.UseVisualStyleBackColor = True
        '
        'webAnteprima
        '
        Me.webAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webAnteprima.Location = New System.Drawing.Point(3, 3)
        Me.webAnteprima.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webAnteprima.Name = "webAnteprima"
        Me.webAnteprima.Size = New System.Drawing.Size(550, 231)
        Me.webAnteprima.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(7, 521)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "In corso:"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(93, 516)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(564, 24)
        Me.lblStatus.TabIndex = 25
        Me.lblStatus.Text = "-"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDestinatario
        '
        Me.lblDestinatario.AutoSize = True
        Me.lblDestinatario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDestinatario.ForeColor = System.Drawing.Color.Red
        Me.lblDestinatario.Location = New System.Drawing.Point(90, 49)
        Me.lblDestinatario.Name = "lblDestinatario"
        Me.lblDestinatario.Size = New System.Drawing.Size(12, 15)
        Me.lblDestinatario.TabIndex = 24
        Me.lblDestinatario.Text = "-"
        '
        'cmbTipoProd
        '
        Me.cmbTipoProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoProd.FormattingEnabled = True
        Me.cmbTipoProd.Location = New System.Drawing.Point(93, 101)
        Me.cmbTipoProd.Name = "cmbTipoProd"
        Me.cmbTipoProd.Size = New System.Drawing.Size(560, 21)
        Me.cmbTipoProd.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Modello"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Testo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Destinatario"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(7, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Titolo"
        '
        'txtTitolo
        '
        Me.txtTitolo.Location = New System.Drawing.Point(93, 74)
        Me.txtTitolo.MaxLength = 50
        Me.txtTitolo.Name = "txtTitolo"
        Me.txtTitolo.Size = New System.Drawing.Size(560, 20)
        Me.txtTitolo.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Marketing
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
        Me.lblTipo.Size = New System.Drawing.Size(136, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Email Marketing"
        '
        'UcInfoBoxModelli
        '
        Me.UcInfoBoxModelli.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.UcInfoBoxModelli.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcInfoBoxModelli.HelpText = resources.GetString("UcInfoBoxModelli.HelpText")
        Me.UcInfoBoxModelli.Location = New System.Drawing.Point(93, 129)
        Me.UcInfoBoxModelli.Name = "UcInfoBoxModelli"
        Me.UcInfoBoxModelli.Size = New System.Drawing.Size(560, 56)
        Me.UcInfoBoxModelli.TabIndex = 28
        '
        'frmMarketingEmail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(674, 624)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmMarketingEmail"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Email automatica"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpHtml.ResumeLayout(False)
        Me.tpHtml.PerformLayout()
        Me.tpAnteprima.ResumeLayout(False)
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTitolo As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtTestoMail As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoProd As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDestinatario As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpHtml As System.Windows.Forms.TabPage
    Friend WithEvents tpAnteprima As System.Windows.Forms.TabPage
    Friend WithEvents webAnteprima As System.Windows.Forms.WebBrowser
    Friend WithEvents UcInfoBoxModelli As ucInfoBox
End Class
