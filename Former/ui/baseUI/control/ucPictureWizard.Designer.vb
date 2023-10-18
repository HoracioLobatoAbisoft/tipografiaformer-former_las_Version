<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPictureWizard
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
        Me.lnkImporta = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lnkImporta
        '
        Me.lnkImporta.AutoSize = True
        Me.lnkImporta.Image = Global.Former.My.Resources.Resources._Wizard20
        Me.lnkImporta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkImporta.LinkColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lnkImporta.Location = New System.Drawing.Point(0, 0)
        Me.lnkImporta.Name = "lnkImporta"
        Me.lnkImporta.Padding = New System.Windows.Forms.Padding(22, 4, 0, 4)
        Me.lnkImporta.Size = New System.Drawing.Size(71, 21)
        Me.lnkImporta.TabIndex = 114
        Me.lnkImporta.TabStop = True
        Me.lnkImporta.Text = "Wizard..."
        '
        'ucPictureWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.lnkImporta)
        Me.Name = "ucPictureWizard"
        Me.Size = New System.Drawing.Size(74, 21)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lnkImporta As LinkLabel
End Class
