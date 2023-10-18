<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReleaseNote
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConferma = New System.Windows.Forms.Button()
        Me.txtBuffer = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(671, 450)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Annulla"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnConferma
        '
        Me.btnConferma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConferma.Location = New System.Drawing.Point(590, 450)
        Me.btnConferma.Name = "btnConferma"
        Me.btnConferma.Size = New System.Drawing.Size(75, 23)
        Me.btnConferma.TabIndex = 0
        Me.btnConferma.Text = "Conferma"
        Me.btnConferma.UseVisualStyleBackColor = True
        '
        'txtBuffer
        '
        Me.txtBuffer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuffer.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuffer.Location = New System.Drawing.Point(13, 13)
        Me.txtBuffer.Multiline = True
        Me.txtBuffer.Name = "txtBuffer"
        Me.txtBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBuffer.Size = New System.Drawing.Size(733, 431)
        Me.txtBuffer.TabIndex = 1
        '
        'frmReleaseNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 485)
        Me.Controls.Add(Me.txtBuffer)
        Me.Controls.Add(Me.btnConferma)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmReleaseNote"
        Me.Text = "frmReleaseNote"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnConferma As Button
    Friend WithEvents txtBuffer As TextBox
End Class
