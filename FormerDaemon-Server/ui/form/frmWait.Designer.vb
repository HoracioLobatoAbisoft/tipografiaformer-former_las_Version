<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWait
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
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWait))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pShutDown = New System.Windows.Forms.ProgressBar()
        Me.tmrProgress = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(57, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Attendere 60 secondi la chiusura dei processi ancora in esecuzione..."
        '
        'pShutDown
        '
        Me.pShutDown.BackColor = System.Drawing.Color.White
        Me.pShutDown.ForeColor = System.Drawing.Color.Red
        Me.pShutDown.Location = New System.Drawing.Point(13, 60)
        Me.pShutDown.Maximum = 60
        Me.pShutDown.Name = "pShutDown"
        Me.pShutDown.Size = New System.Drawing.Size(471, 23)
        Me.pShutDown.Step = 1
        Me.pShutDown.TabIndex = 1
        '
        'tmrProgress
        '
        Me.tmrProgress.Enabled = True
        Me.tmrProgress.Interval = 1000
        '
        'frmWait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(496, 107)
        Me.ControlBox = False
        Me.Controls.Add(Me.pShutDown)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWait"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attendere  Prego..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pShutDown As System.Windows.Forms.ProgressBar
    Friend WithEvents tmrProgress As System.Windows.Forms.Timer
End Class
