<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBrowser
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
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnAvanti = New System.Windows.Forms.Button()
        Me.btnIndietro = New System.Windows.Forms.Button()
        Me.webMain = New System.Windows.Forms.WebBrowser()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnAvanti
        '
        Me.btnAvanti.BackColor = System.Drawing.Color.White
        Me.btnAvanti.FlatAppearance.BorderSize = 0
        Me.btnAvanti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAvanti.Image = Global.FormerBrowser.My.Resources.Resources.arrow_right_thick
        Me.btnAvanti.Location = New System.Drawing.Point(30, 1)
        Me.btnAvanti.Name = "btnAvanti"
        Me.btnAvanti.Size = New System.Drawing.Size(28, 28)
        Me.btnAvanti.TabIndex = 2
        Me.btnAvanti.UseVisualStyleBackColor = False
        '
        'btnIndietro
        '
        Me.btnIndietro.BackColor = System.Drawing.Color.White
        Me.btnIndietro.FlatAppearance.BorderSize = 0
        Me.btnIndietro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIndietro.Image = Global.FormerBrowser.My.Resources.Resources.arrow_left_thick
        Me.btnIndietro.Location = New System.Drawing.Point(1, 1)
        Me.btnIndietro.Name = "btnIndietro"
        Me.btnIndietro.Size = New System.Drawing.Size(28, 28)
        Me.btnIndietro.TabIndex = 1
        Me.btnIndietro.UseVisualStyleBackColor = False
        '
        'webMain
        '
        Me.webMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webMain.Location = New System.Drawing.Point(1, 30)
        Me.webMain.MinimumSize = New System.Drawing.Size(23, 23)
        Me.webMain.Name = "webMain"
        Me.webMain.ScriptErrorsSuppressed = True
        Me.webMain.Size = New System.Drawing.Size(818, 313)
        Me.webMain.TabIndex = 4
        '
        'btnReload
        '
        Me.btnReload.BackColor = System.Drawing.Color.White
        Me.btnReload.FlatAppearance.BorderSize = 0
        Me.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReload.Image = Global.FormerBrowser.My.Resources.Resources.arrow_sync_outline
        Me.btnReload.Location = New System.Drawing.Point(59, 1)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(28, 28)
        Me.btnReload.TabIndex = 3
        Me.btnReload.UseVisualStyleBackColor = False
        '
        'txtUrl
        '
        Me.txtUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUrl.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.txtUrl.Location = New System.Drawing.Point(88, 2)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(731, 26)
        Me.txtUrl.TabIndex = 0
        '
        'ucBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Controls.Add(Me.btnAvanti)
        Me.Controls.Add(Me.btnIndietro)
        Me.Controls.Add(Me.webMain)
        Me.Controls.Add(Me.btnReload)
        Me.Controls.Add(Me.txtUrl)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Name = "ucBrowser"
        Me.Size = New System.Drawing.Size(820, 344)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAvanti As System.Windows.Forms.Button
    Friend WithEvents btnIndietro As System.Windows.Forms.Button
    Friend WithEvents webMain As System.Windows.Forms.WebBrowser
    Friend WithEvents btnReload As System.Windows.Forms.Button
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox

End Class
