<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ntfIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.chkMantieniAttivo = New System.Windows.Forms.CheckBox()
        Me.lblCountProc = New System.Windows.Forms.Label()
        Me.tmrProc = New System.Windows.Forms.Timer(Me.components)
        Me.icoDemone = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        CType(Me.icoDemone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ntfIcon
        '
        Me.ntfIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ntfIcon.BalloonTipText = "FormerDaemon-Launcher"
        Me.ntfIcon.Icon = CType(resources.GetObject("ntfIcon.Icon"), System.Drawing.Icon)
        Me.ntfIcon.Text = "FormerDaemon-Launcher"
        Me.ntfIcon.Visible = True
        '
        'chkMantieniAttivo
        '
        Me.chkMantieniAttivo.AutoSize = True
        Me.chkMantieniAttivo.Checked = True
        Me.chkMantieniAttivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMantieniAttivo.Location = New System.Drawing.Point(11, 54)
        Me.chkMantieniAttivo.Name = "chkMantieniAttivo"
        Me.chkMantieniAttivo.Size = New System.Drawing.Size(330, 19)
        Me.chkMantieniAttivo.TabIndex = 0
        Me.chkMantieniAttivo.Text = "Riattiva automaticamente il demone in caso di chiusura"
        Me.chkMantieniAttivo.UseVisualStyleBackColor = True
        '
        'lblCountProc
        '
        Me.lblCountProc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCountProc.Location = New System.Drawing.Point(52, 88)
        Me.lblCountProc.Name = "lblCountProc"
        Me.lblCountProc.Size = New System.Drawing.Size(289, 26)
        Me.lblCountProc.TabIndex = 3
        Me.lblCountProc.Text = "-"
        Me.lblCountProc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrProc
        '
        Me.tmrProc.Enabled = True
        Me.tmrProc.Interval = 500
        '
        'icoDemone
        '
        Me.icoDemone.Image = Global.FormerDaemon_Launcher.My.Resources.Resources.heart_monitor
        Me.icoDemone.Location = New System.Drawing.Point(162, 12)
        Me.icoDemone.Name = "icoDemone"
        Me.icoDemone.Size = New System.Drawing.Size(26, 26)
        Me.icoDemone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.icoDemone.TabIndex = 5
        Me.icoDemone.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.FormerDaemon_Launcher.My.Resources.Resources._Opzioni
        Me.PictureBox1.Location = New System.Drawing.Point(11, 88)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btnStop
        '
        Me.btnStop.Image = Global.FormerDaemon_Launcher.My.Resources.Resources._stop
        Me.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStop.Location = New System.Drawing.Point(233, 12)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(112, 23)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Enabled = False
        Me.btnStart.Image = Global.FormerDaemon_Launcher.My.Resources.Resources._Test
        Me.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStart.Location = New System.Drawing.Point(12, 12)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(112, 23)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 124)
        Me.Controls.Add(Me.icoDemone)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblCountProc)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.chkMantieniAttivo)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormerDaemon-Launcher"
        CType(Me.icoDemone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ntfIcon As NotifyIcon
    Friend WithEvents chkMantieniAttivo As CheckBox
    Friend WithEvents btnStart As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents lblCountProc As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents tmrProc As Timer
    Friend WithEvents icoDemone As PictureBox
End Class
