<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecensione
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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.lblProdotto = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblVoto = New System.Windows.Forms.Label()
        Me.lblCounter = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblContro = New System.Windows.Forms.Label()
        Me.lblPro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pctStarFull5 = New System.Windows.Forms.PictureBox()
        Me.pctStarFull4 = New System.Windows.Forms.PictureBox()
        Me.pctStarFull3 = New System.Windows.Forms.PictureBox()
        Me.pctStarFull2 = New System.Windows.Forms.PictureBox()
        Me.pctStarFull1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRisposta = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.tpHelp = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctStarFull5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctStarFull4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctStarFull3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctStarFull2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctStarFull1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHelp.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 670)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(821, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(779, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 36)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.Location = New System.Drawing.Point(745, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(34, 34)
        Me.btnOk.TabIndex = 15
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpHelp)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(821, 670)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lblProdotto)
        Me.tbProd.Controls.Add(Me.Label8)
        Me.tbProd.Controls.Add(Me.lblVoto)
        Me.tbProd.Controls.Add(Me.lblCounter)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.lblContro)
        Me.tbProd.Controls.Add(Me.lblPro)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.pctStarFull5)
        Me.tbProd.Controls.Add(Me.pctStarFull4)
        Me.tbProd.Controls.Add(Me.pctStarFull3)
        Me.tbProd.Controls.Add(Me.pctStarFull2)
        Me.tbProd.Controls.Add(Me.pctStarFull1)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.lblCliente)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtRisposta)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Controls.Add(Me.PictureBox5)
        Me.tbProd.Controls.Add(Me.PictureBox4)
        Me.tbProd.Controls.Add(Me.PictureBox3)
        Me.tbProd.Controls.Add(Me.PictureBox2)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(813, 644)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Recensione"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'lblProdotto
        '
        Me.lblProdotto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProdotto.Location = New System.Drawing.Point(137, 103)
        Me.lblProdotto.Name = "lblProdotto"
        Me.lblProdotto.Size = New System.Drawing.Size(662, 21)
        Me.lblProdotto.TabIndex = 38
        Me.lblProdotto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(50, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 15)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Prodotto"
        '
        'lblVoto
        '
        Me.lblVoto.AutoSize = True
        Me.lblVoto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblVoto.ForeColor = System.Drawing.Color.Black
        Me.lblVoto.Location = New System.Drawing.Point(363, 151)
        Me.lblVoto.Name = "lblVoto"
        Me.lblVoto.Size = New System.Drawing.Size(12, 15)
        Me.lblVoto.TabIndex = 32
        Me.lblVoto.Text = "-"
        '
        'lblCounter
        '
        Me.lblCounter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCounter.ForeColor = System.Drawing.Color.Black
        Me.lblCounter.Location = New System.Drawing.Point(627, 621)
        Me.lblCounter.Name = "lblCounter"
        Me.lblCounter.Size = New System.Drawing.Size(172, 15)
        Me.lblCounter.TabIndex = 31
        Me.lblCounter.Text = "(0/500)"
        Me.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(27, 425)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "(non obbligatoria)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(50, 410)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "RISPOSTA"
        '
        'lblContro
        '
        Me.lblContro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContro.Location = New System.Drawing.Point(137, 303)
        Me.lblContro.Name = "lblContro"
        Me.lblContro.Size = New System.Drawing.Size(662, 94)
        Me.lblContro.TabIndex = 28
        '
        'lblPro
        '
        Me.lblPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPro.Location = New System.Drawing.Point(137, 196)
        Me.lblPro.Name = "lblPro"
        Me.lblPro.Size = New System.Drawing.Size(662, 94)
        Me.lblPro.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Red
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(52, 303)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Contro"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(52, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 15)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Pro"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctStarFull5
        '
        Me.pctStarFull5.Image = Global.Former.My.Resources.Resources._Recensione
        Me.pctStarFull5.Location = New System.Drawing.Point(309, 141)
        Me.pctStarFull5.Name = "pctStarFull5"
        Me.pctStarFull5.Size = New System.Drawing.Size(37, 34)
        Me.pctStarFull5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctStarFull5.TabIndex = 24
        Me.pctStarFull5.TabStop = False
        Me.pctStarFull5.Visible = False
        '
        'pctStarFull4
        '
        Me.pctStarFull4.Image = Global.Former.My.Resources.Resources._Recensione
        Me.pctStarFull4.Location = New System.Drawing.Point(266, 141)
        Me.pctStarFull4.Name = "pctStarFull4"
        Me.pctStarFull4.Size = New System.Drawing.Size(37, 34)
        Me.pctStarFull4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctStarFull4.TabIndex = 23
        Me.pctStarFull4.TabStop = False
        Me.pctStarFull4.Visible = False
        '
        'pctStarFull3
        '
        Me.pctStarFull3.Image = Global.Former.My.Resources.Resources._Recensione
        Me.pctStarFull3.Location = New System.Drawing.Point(223, 141)
        Me.pctStarFull3.Name = "pctStarFull3"
        Me.pctStarFull3.Size = New System.Drawing.Size(37, 34)
        Me.pctStarFull3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctStarFull3.TabIndex = 22
        Me.pctStarFull3.TabStop = False
        Me.pctStarFull3.Visible = False
        '
        'pctStarFull2
        '
        Me.pctStarFull2.Image = Global.Former.My.Resources.Resources._Recensione
        Me.pctStarFull2.Location = New System.Drawing.Point(180, 141)
        Me.pctStarFull2.Name = "pctStarFull2"
        Me.pctStarFull2.Size = New System.Drawing.Size(37, 34)
        Me.pctStarFull2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctStarFull2.TabIndex = 21
        Me.pctStarFull2.TabStop = False
        Me.pctStarFull2.Visible = False
        '
        'pctStarFull1
        '
        Me.pctStarFull1.Image = Global.Former.My.Resources.Resources._Recensione
        Me.pctStarFull1.Location = New System.Drawing.Point(137, 141)
        Me.pctStarFull1.Name = "pctStarFull1"
        Me.pctStarFull1.Size = New System.Drawing.Size(37, 34)
        Me.pctStarFull1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctStarFull1.TabIndex = 20
        Me.pctStarFull1.TabStop = False
        Me.pctStarFull1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Voto"
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCliente.Location = New System.Drawing.Point(137, 65)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(662, 21)
        Me.lblCliente.TabIndex = 18
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Cliente"
        '
        'txtRisposta
        '
        Me.txtRisposta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.txtRisposta.Location = New System.Drawing.Point(137, 410)
        Me.txtRisposta.MaxLength = 500
        Me.txtRisposta.Multiline = True
        Me.txtRisposta.Name = "txtRisposta"
        Me.txtRisposta.Size = New System.Drawing.Size(662, 204)
        Me.txtRisposta.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Recensione
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
        Me.lblTipo.Size = New System.Drawing.Size(190, 25)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Approva Recensione"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.Former.My.Resources.Resources._RecensioneVuota
        Me.PictureBox5.Location = New System.Drawing.Point(309, 141)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox5.TabIndex = 36
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.Former.My.Resources.Resources._RecensioneVuota
        Me.PictureBox4.Location = New System.Drawing.Point(266, 141)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox4.TabIndex = 35
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Former.My.Resources.Resources._RecensioneVuota
        Me.PictureBox3.Location = New System.Drawing.Point(223, 141)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 34
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources._RecensioneVuota
        Me.PictureBox2.Location = New System.Drawing.Point(180, 141)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 33
        Me.PictureBox2.TabStop = False
        '
        'tpHelp
        '
        Me.tpHelp.Controls.Add(Me.PictureBox1)
        Me.tpHelp.Location = New System.Drawing.Point(4, 22)
        Me.tpHelp.Name = "tpHelp"
        Me.tpHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHelp.Size = New System.Drawing.Size(813, 644)
        Me.tpHelp.TabIndex = 1
        Me.tpHelp.Text = "Help"
        Me.tpHelp.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._help
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'frmSitoWebReview
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(821, 718)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmSitoWebReview"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Recensione"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctStarFull5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctStarFull4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctStarFull3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctStarFull2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctStarFull1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHelp.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRisposta As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents tpHelp As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblContro As System.Windows.Forms.Label
    Friend WithEvents lblPro As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pctStarFull5 As System.Windows.Forms.PictureBox
    Friend WithEvents pctStarFull4 As System.Windows.Forms.PictureBox
    Friend WithEvents pctStarFull3 As System.Windows.Forms.PictureBox
    Friend WithEvents pctStarFull2 As System.Windows.Forms.PictureBox
    Friend WithEvents pctStarFull1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCounter As System.Windows.Forms.Label
    Friend WithEvents lblVoto As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblProdotto As Label
    Friend WithEvents Label8 As Label
End Class
