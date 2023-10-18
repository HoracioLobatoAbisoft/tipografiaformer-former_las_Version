<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCaller
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
        Me.lblTel = New System.Windows.Forms.Label()
        Me.tmrClose = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRovescia = New System.Windows.Forms.Timer(Me.components)
        Me.lblCli = New System.Windows.Forms.Label()
        Me.lnkRub = New System.Windows.Forms.LinkLabel()
        Me.lblTimer = New System.Windows.Forms.Label()
        Me.lnkClose = New System.Windows.Forms.LinkLabel()
        Me.lnkPrendiCarico = New System.Windows.Forms.LinkLabel()
        Me.lnkOrdini = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTel
        '
        Me.lblTel.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTel.Location = New System.Drawing.Point(69, 30)
        Me.lblTel.Name = "lblTel"
        Me.lblTel.Size = New System.Drawing.Size(268, 48)
        Me.lblTel.TabIndex = 1
        Me.lblTel.Text = "-"
        Me.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrClose
        '
        Me.tmrClose.Interval = 10000
        '
        'tmrRovescia
        '
        Me.tmrRovescia.Interval = 1000
        '
        'lblCli
        '
        Me.lblCli.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblCli.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblCli.Location = New System.Drawing.Point(14, 97)
        Me.lblCli.Name = "lblCli"
        Me.lblCli.Size = New System.Drawing.Size(323, 72)
        Me.lblCli.TabIndex = 58
        Me.lblCli.Text = "-"
        '
        'lnkRub
        '
        Me.lnkRub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkRub.AutoSize = True
        Me.lnkRub.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lnkRub.Image = Global.Former.My.Resources.Resources._Cliente
        Me.lnkRub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRub.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRub.Location = New System.Drawing.Point(11, 186)
        Me.lnkRub.MinimumSize = New System.Drawing.Size(0, 28)
        Me.lnkRub.Name = "lnkRub"
        Me.lnkRub.Padding = New System.Windows.Forms.Padding(32, 0, 0, 0)
        Me.lnkRub.Size = New System.Drawing.Size(183, 28)
        Me.lnkRub.TabIndex = 59
        Me.lnkRub.TabStop = True
        Me.lnkRub.Text = "Apri la scheda cliente"
        Me.lnkRub.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTimer
        '
        Me.lblTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTimer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTimer.Image = Global.Former.My.Resources.Resources.loading
        Me.lblTimer.Location = New System.Drawing.Point(297, 318)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(37, 37)
        Me.lblTimer.TabIndex = 57
        Me.lblTimer.Text = "59"
        Me.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkClose
        '
        Me.lnkClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkClose.AutoSize = True
        Me.lnkClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lnkClose.Image = Global.Former.My.Resources.Resources._Annulla
        Me.lnkClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkClose.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkClose.Location = New System.Drawing.Point(11, 321)
        Me.lnkClose.MinimumSize = New System.Drawing.Size(0, 28)
        Me.lnkClose.Name = "lnkClose"
        Me.lnkClose.Padding = New System.Windows.Forms.Padding(32, 0, 0, 0)
        Me.lnkClose.Size = New System.Drawing.Size(185, 28)
        Me.lnkClose.TabIndex = 56
        Me.lnkClose.TabStop = True
        Me.lnkClose.Text = "Chiudi la chiamata"
        Me.lnkClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkPrendiCarico
        '
        Me.lnkPrendiCarico.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkPrendiCarico.AutoSize = True
        Me.lnkPrendiCarico.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lnkPrendiCarico.Image = Global.Former.My.Resources.Resources._PrendiInCarico
        Me.lnkPrendiCarico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkPrendiCarico.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkPrendiCarico.Location = New System.Drawing.Point(11, 275)
        Me.lnkPrendiCarico.MinimumSize = New System.Drawing.Size(0, 28)
        Me.lnkPrendiCarico.Name = "lnkPrendiCarico"
        Me.lnkPrendiCarico.Padding = New System.Windows.Forms.Padding(32, 0, 0, 0)
        Me.lnkPrendiCarico.Size = New System.Drawing.Size(224, 28)
        Me.lnkPrendiCarico.TabIndex = 56
        Me.lnkPrendiCarico.TabStop = True
        Me.lnkPrendiCarico.Text = "Prendi in carico la chiamata"
        Me.lnkPrendiCarico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkOrdini
        '
        Me.lnkOrdini.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkOrdini.AutoSize = True
        Me.lnkOrdini.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lnkOrdini.Image = Global.Former.My.Resources.Resources._Ordine
        Me.lnkOrdini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkOrdini.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkOrdini.Location = New System.Drawing.Point(11, 231)
        Me.lnkOrdini.MinimumSize = New System.Drawing.Size(0, 28)
        Me.lnkOrdini.Name = "lnkOrdini"
        Me.lnkOrdini.Padding = New System.Windows.Forms.Padding(32, 0, 0, 0)
        Me.lnkOrdini.Size = New System.Drawing.Size(199, 28)
        Me.lnkOrdini.TabIndex = 55
        Me.lnkOrdini.TabStop = True
        Me.lnkOrdini.Text = "Apri la situazione ordini"
        Me.lnkOrdini.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Telefono48
        Me.PictureBox1.Location = New System.Drawing.Point(15, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'frmCaller
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(349, 366)
        Me.Controls.Add(Me.lnkRub)
        Me.Controls.Add(Me.lblCli)
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.lnkClose)
        Me.Controls.Add(Me.lnkPrendiCarico)
        Me.Controls.Add(Me.lnkOrdini)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCaller"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Chiamata in arrivo..."
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTel As System.Windows.Forms.Label
    Friend WithEvents tmrClose As System.Windows.Forms.Timer
    Friend WithEvents lnkOrdini As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkPrendiCarico As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTimer As System.Windows.Forms.Label
    Friend WithEvents tmrRovescia As System.Windows.Forms.Timer
    Friend WithEvents lnkClose As System.Windows.Forms.LinkLabel
    Friend WithEvents lblCli As System.Windows.Forms.Label
    Friend WithEvents lnkRub As System.Windows.Forms.LinkLabel
End Class
