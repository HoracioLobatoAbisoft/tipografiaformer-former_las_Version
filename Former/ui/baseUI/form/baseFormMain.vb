Public Class baseFormMain
    Inherits baseFormInterna

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(baseFormMain))
        Me.SuspendLayout()
        '
        'baseFormMain
        '
        Me.ClientSize = New System.Drawing.Size(878, 356)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "baseFormMain"
        Me.ResumeLayout(False)

    End Sub

    'Private Sub baseFormInterna_SegnalazioneBugRichiesta() Handles Me.SegnalazioneBugRichiesta
    '    'SendKeys.Send("{PRTSC}")
    '    'Sottofondo()
    '    Using f As New frmBug
    '        f.Carica(Me)
    '    End Using
    '    'Sottofondo()
    'End Sub
End Class
