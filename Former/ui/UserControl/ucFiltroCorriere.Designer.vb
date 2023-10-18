<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucFiltroCorriere
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
        Me.cmbCorriere = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmbCorriere
        '
        Me.cmbCorriere.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCorriere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorriere.FormattingEnabled = True
        Me.cmbCorriere.Location = New System.Drawing.Point(0, 0)
        Me.cmbCorriere.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbCorriere.Name = "cmbCorriere"
        Me.cmbCorriere.Size = New System.Drawing.Size(116, 23)
        Me.cmbCorriere.TabIndex = 0
        '
        'ucFiltroCorriere
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.cmbCorriere)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ucFiltroCorriere"
        Me.Size = New System.Drawing.Size(116, 21)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbCorriere As System.Windows.Forms.ComboBox

End Class
