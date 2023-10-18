<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucCaller
    Inherits ucFormerUserControl


    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblTel = New System.Windows.Forms.Label()
        Me.lblCli = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lnkRub = New System.Windows.Forms.LinkLabel()
        Me.lnkOrdini = New System.Windows.Forms.LinkLabel()
        Me.lblTimer = New System.Windows.Forms.Label()
        Me.tmrRovescia = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTel
        '
        Me.lblTel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTel.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTel.Location = New System.Drawing.Point(22, 3)
        Me.lblTel.Name = "lblTel"
        Me.lblTel.Size = New System.Drawing.Size(225, 30)
        Me.lblTel.TabIndex = 2
        Me.lblTel.Text = "-"
        Me.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCli
        '
        Me.lblCli.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCli.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCli.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Italic)
        Me.lblCli.Location = New System.Drawing.Point(3, 42)
        Me.lblCli.Name = "lblCli"
        Me.lblCli.Size = New System.Drawing.Size(244, 62)
        Me.lblCli.TabIndex = 59
        Me.lblCli.Text = "-"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.telephone1
        Me.PictureBox1.Location = New System.Drawing.Point(3, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 60
        Me.PictureBox1.TabStop = False
        '
        'lnkRub
        '
        Me.lnkRub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkRub.Image = Global.Former.My.Resources.user1
        Me.lnkRub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRub.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRub.Location = New System.Drawing.Point(5, 111)
        Me.lnkRub.Name = "lnkRub"
        Me.lnkRub.Size = New System.Drawing.Size(155, 27)
        Me.lnkRub.TabIndex = 62
        Me.lnkRub.TabStop = True
        Me.lnkRub.Text = "Apri la scheda cliente"
        Me.lnkRub.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkOrdini
        '
        Me.lnkOrdini.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkOrdini.Image = Global.Former.My.Resources.checkout
        Me.lnkOrdini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkOrdini.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkOrdini.Location = New System.Drawing.Point(5, 147)
        Me.lnkOrdini.Name = "lnkOrdini"
        Me.lnkOrdini.Size = New System.Drawing.Size(165, 27)
        Me.lnkOrdini.TabIndex = 61
        Me.lnkOrdini.TabStop = True
        Me.lnkOrdini.Text = "Apri la situazione ordini"
        Me.lnkOrdini.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTimer
        '
        Me.lblTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTimer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTimer.Image = Global.Former.My.Resources.loading
        Me.lblTimer.Location = New System.Drawing.Point(215, 144)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(32, 32)
        Me.lblTimer.TabIndex = 63
        Me.lblTimer.Text = "59"
        Me.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTimer.Visible = False
        '
        'tmrRovescia
        '
        Me.tmrRovescia.Interval = 1000
        '
        'ucCaller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.lnkRub)
        Me.Controls.Add(Me.lnkOrdini)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblCli)
        Me.Controls.Add(Me.lblTel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucCaller"
        Me.Size = New System.Drawing.Size(250, 188)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTel As System.Windows.Forms.Label
    Friend WithEvents lblCli As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lnkRub As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkOrdini As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTimer As System.Windows.Forms.Label
    Friend WithEvents tmrRovescia As System.Windows.Forms.Timer

End Class
