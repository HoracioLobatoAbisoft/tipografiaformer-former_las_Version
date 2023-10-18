<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommessaCalcoloSoluzioni
    Inherits baseFormInternaFixed

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.progress = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmrStart = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Think48
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'progress
        '
        Me.progress.Location = New System.Drawing.Point(70, 12)
        Me.progress.Name = "progress"
        Me.progress.Size = New System.Drawing.Size(791, 30)
        Me.progress.Step = 1
        Me.progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progress.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.txtLog)
        Me.Panel1.Controls.Add(Me.lblCount)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.progress)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 631)
        Me.Panel1.TabIndex = 4
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(406, 605)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(60, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Chiudi"
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.Visible = False
        '
        'txtLog
        '
        Me.txtLog.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.Location = New System.Drawing.Point(70, 99)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(791, 504)
        Me.txtLog.TabIndex = 6
        '
        'lblCount
        '
        Me.lblCount.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.lblCount.Location = New System.Drawing.Point(300, 51)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(57, 44)
        Me.lblCount.TabIndex = 5
        Me.lblCount.Text = "-"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(67, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(221, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Ordini disponibili per il calcolo soluzioni:"
        '
        'tmrStart
        '
        Me.tmrStart.Enabled = True
        Me.tmrStart.Interval = 1000
        '
        'frmCommessaCalcoloSoluzioni
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(873, 631)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCommessaCalcoloSoluzioni"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Calcolo soluzioni in corso..."
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents progress As ProgressBar
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tmrStart As Timer
    Friend WithEvents lblCount As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLog As TextBox
    Friend WithEvents btnClose As Button
End Class
