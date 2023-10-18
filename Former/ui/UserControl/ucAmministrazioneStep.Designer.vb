<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAmministrazioneStep
    Inherits ucFormerUserControl

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents lnkSpostaSu As LinkLabel
    Friend WithEvents lnkSpostaGiu As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents RiferitaA As DataGridViewTextBoxColumn
    Friend WithEvents Img As DataGridViewImageColumn
    Friend WithEvents Nome As DataGridViewTextBoxColumn
    Friend WithEvents Descrizione As DataGridViewTextBoxColumn

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    '<System.Diagnostics.DebuggerStepThrough()>
    'Private Sub InitializeComponent()
    '    Me.SuspendLayout()
    '    '
    '    'ucBase
    '    '
    '    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
    '    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    '    Me.Name = "ucBase"
    '    Me.Size = New System.Drawing.Size(805, 540)
    '    Me.ResumeLayout(False)

    'End Sub

End Class
