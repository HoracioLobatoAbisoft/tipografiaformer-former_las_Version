<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAnteprima
    Inherits ucFormerUserControl


    'UserControl overrides dispose to clean up the component list.
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
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabDett = New System.Windows.Forms.TabPage()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.WebPrint = New System.Windows.Forms.WebBrowser()
        Me.tabMain.SuspendLayout()
        Me.tabDett.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.Controls.Add(Me.tabDett)
        Me.tabMain.Location = New System.Drawing.Point(3, 3)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(672, 458)
        Me.tabMain.TabIndex = 0
        '
        'tabDett
        '
        Me.tabDett.BackColor = System.Drawing.Color.White
        Me.tabDett.Controls.Add(Me.lnkStampa)
        Me.tabDett.Controls.Add(Me.WebPrint)
        Me.tabDett.Location = New System.Drawing.Point(4, 24)
        Me.tabDett.Name = "tabDett"
        Me.tabDett.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDett.Size = New System.Drawing.Size(664, 430)
        Me.tabDett.TabIndex = 0
        Me.tabDett.Text = "Dettaglio"
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(578, 3)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 37)
        Me.lnkStampa.TabIndex = 54
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WebPrint
        '
        Me.WebPrint.AllowWebBrowserDrop = False
        Me.WebPrint.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebPrint.IsWebBrowserContextMenuEnabled = False
        Me.WebPrint.Location = New System.Drawing.Point(6, 43)
        Me.WebPrint.MinimumSize = New System.Drawing.Size(23, 23)
        Me.WebPrint.Name = "WebPrint"
        Me.WebPrint.ScriptErrorsSuppressed = True
        Me.WebPrint.Size = New System.Drawing.Size(652, 381)
        Me.WebPrint.TabIndex = 1
        Me.WebPrint.WebBrowserShortcutsEnabled = False
        '
        'ucAnteprima
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tabMain)
        Me.Name = "ucAnteprima"
        Me.Size = New System.Drawing.Size(679, 464)
        Me.tabMain.ResumeLayout(False)
        Me.tabDett.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabDett As System.Windows.Forms.TabPage
    Friend WithEvents WebPrint As System.Windows.Forms.WebBrowser
    Friend WithEvents lnkStampa As System.Windows.Forms.LinkLabel

End Class
