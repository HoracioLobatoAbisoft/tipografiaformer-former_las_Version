Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class baseFormInterna
    Inherits System.Windows.Forms.Form

    'Inherits MaterialSkin.Controls.MaterialForm
    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(baseFormInterna))
        Me.toolTipHelp = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'toolTipHelp
        '
        Me.toolTipHelp.AutoPopDelay = 8000
        Me.toolTipHelp.BackColor = System.Drawing.Color.White
        Me.toolTipHelp.ForeColor = System.Drawing.Color.Black
        Me.toolTipHelp.InitialDelay = 500
        Me.toolTipHelp.ReshowDelay = 100
        Me.toolTipHelp.ShowAlways = True
        Me.toolTipHelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.toolTipHelp.ToolTipTitle = "Help"
        '
        'baseFormInterna
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(331, 301)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "baseFormInterna"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents toolTipHelp As ToolTip
End Class
