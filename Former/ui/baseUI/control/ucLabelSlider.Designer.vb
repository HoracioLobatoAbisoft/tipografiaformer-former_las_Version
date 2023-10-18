<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLabelSlider
    Inherits System.Windows.Forms.UserControl

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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pctIco = New System.Windows.Forms.PictureBox()
        Me.lblSigla = New System.Windows.Forms.Label()
        Me.lblLongMessage = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.pctIco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pctIco
        '
        Me.pctIco.BackColor = System.Drawing.Color.Transparent
        Me.pctIco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pctIco.Location = New System.Drawing.Point(1, 1)
        Me.pctIco.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.pctIco.Name = "pctIco"
        Me.pctIco.Size = New System.Drawing.Size(26, 26)
        Me.pctIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctIco.TabIndex = 0
        Me.pctIco.TabStop = False
        '
        'lblSigla
        '
        Me.lblSigla.BackColor = System.Drawing.Color.Transparent
        Me.lblSigla.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSigla.Location = New System.Drawing.Point(27, 0)
        Me.lblSigla.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSigla.Name = "lblSigla"
        Me.lblSigla.Size = New System.Drawing.Size(50, 25)
        Me.lblSigla.TabIndex = 1
        Me.lblSigla.Text = "-"
        Me.lblSigla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLongMessage
        '
        Me.lblLongMessage.AutoSize = True
        Me.lblLongMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblLongMessage.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLongMessage.Location = New System.Drawing.Point(77, 0)
        Me.lblLongMessage.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLongMessage.Name = "lblLongMessage"
        Me.lblLongMessage.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.lblLongMessage.Size = New System.Drawing.Size(0, 24)
        Me.lblLongMessage.TabIndex = 2
        Me.lblLongMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLongMessage.Visible = False
        '
        'pnlMain
        '
        Me.pnlMain.AutoSize = True
        Me.pnlMain.Controls.Add(Me.pctIco)
        Me.pnlMain.Controls.Add(Me.lblSigla)
        Me.pnlMain.Controls.Add(Me.lblLongMessage)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(78, 28)
        Me.pnlMain.TabIndex = 3
        Me.pnlMain.WrapContents = False
        '
        'ucLabelSlider
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Margin = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.Name = "ucLabelSlider"
        Me.Size = New System.Drawing.Size(78, 28)
        CType(Me.pctIco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pctIco As PictureBox
    Friend WithEvents lblSigla As Label
    Friend WithEvents lblLongMessage As Label
    Friend WithEvents pnlMain As FlowLayoutPanel
End Class
