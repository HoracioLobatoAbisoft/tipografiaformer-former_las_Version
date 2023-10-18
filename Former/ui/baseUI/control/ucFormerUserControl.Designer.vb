Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucFormerUserControl
    Inherits System.Windows.Forms.UserControl

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.toolTipHelp = New System.Windows.Forms.ToolTip(Me.components)
        Me.VisualStudio2012DarkTheme = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        Me.VisualStudio2012LightTheme = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.SuspendLayout()
        '
        'toolTipHelp
        '
        Me.toolTipHelp.BackColor = System.Drawing.Color.White
        Me.toolTipHelp.ForeColor = System.Drawing.Color.Black
        Me.toolTipHelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.toolTipHelp.ToolTipTitle = "Help"
        '
        'ucFormerUserControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucFormerUserControl"
        Me.Size = New System.Drawing.Size(531, 240)
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents toolTipHelp As ToolTip
    Public WithEvents VisualStudio2012DarkTheme As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
    Public WithEvents VisualStudio2012LightTheme As Telerik.WinControls.Themes.VisualStudio2012LightTheme
End Class
