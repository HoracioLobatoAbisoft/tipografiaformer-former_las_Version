<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseFormRad
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseFormRad))
        Me.toolTipHelp = New System.Windows.Forms.ToolTip(Me.components)
        Me.VisualStudio2012LightTheme = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.VisualStudio2012DarkTheme = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'BaseFormRad
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(292, 270)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BaseFormRad"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Former"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents toolTipHelp As ToolTip
    Public WithEvents VisualStudio2012LightTheme As Telerik.WinControls.Themes.VisualStudio2012LightTheme
    Public WithEvents VisualStudio2012DarkTheme As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
End Class

