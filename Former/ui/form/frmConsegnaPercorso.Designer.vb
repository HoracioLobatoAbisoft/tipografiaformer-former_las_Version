<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsegnaPercorso
    Inherits baseFormInternaRedim

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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lnkChrome = New System.Windows.Forms.LinkLabel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.SplitPath = New System.Windows.Forms.SplitContainer()
        Me.lnkSu = New System.Windows.Forms.LinkLabel()
        Me.lnkGiu = New System.Windows.Forms.LinkLabel()
        Me.chkConsegne = New System.Windows.Forms.CheckedListBox()
        Me.webPercorso = New System.Windows.Forms.WebBrowser()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.SplitPath, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPath.Panel1.SuspendLayout()
        Me.SplitPath.Panel2.SuspendLayout()
        Me.SplitPath.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lnkChrome)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 713)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(955, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'lnkChrome
        '
        Me.lnkChrome.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkChrome.Image = Global.Former.My.Resources.Resources.appicns_Chrome_icon
        Me.lnkChrome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkChrome.LinkColor = System.Drawing.Color.Black
        Me.lnkChrome.Location = New System.Drawing.Point(12, 12)
        Me.lnkChrome.Name = "lnkChrome"
        Me.lnkChrome.Size = New System.Drawing.Size(163, 33)
        Me.lnkChrome.TabIndex = 17
        Me.lnkChrome.TabStop = True
        Me.lnkChrome.Text = "Apri in Google Chrome"
        Me.lnkChrome.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.Location = New System.Drawing.Point(913, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(36, 36)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(955, 713)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.SplitPath)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(947, 687)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Percorso Consegne"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'SplitPath
        '
        Me.SplitPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitPath.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitPath.Location = New System.Drawing.Point(3, 3)
        Me.SplitPath.Name = "SplitPath"
        '
        'SplitPath.Panel1
        '
        Me.SplitPath.Panel1.Controls.Add(Me.lnkSu)
        Me.SplitPath.Panel1.Controls.Add(Me.lnkGiu)
        Me.SplitPath.Panel1.Controls.Add(Me.chkConsegne)
        Me.SplitPath.Panel1MinSize = 0
        '
        'SplitPath.Panel2
        '
        Me.SplitPath.Panel2.Controls.Add(Me.webPercorso)
        Me.SplitPath.Size = New System.Drawing.Size(941, 681)
        Me.SplitPath.SplitterDistance = 200
        Me.SplitPath.TabIndex = 1
        '
        'lnkSu
        '
        Me.lnkSu.AutoSize = True
        Me.lnkSu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkSu.Image = Global.Former.My.Resources.Resources._Su
        Me.lnkSu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSu.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSu.Location = New System.Drawing.Point(3, 10)
        Me.lnkSu.Name = "lnkSu"
        Me.lnkSu.Padding = New System.Windows.Forms.Padding(28, 5, 0, 5)
        Me.lnkSu.Size = New System.Drawing.Size(48, 25)
        Me.lnkSu.TabIndex = 83
        Me.lnkSu.TabStop = True
        Me.lnkSu.Text = "Su"
        Me.lnkSu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkGiu
        '
        Me.lnkGiu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkGiu.AutoSize = True
        Me.lnkGiu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkGiu.Image = Global.Former.My.Resources.Resources._Giu
        Me.lnkGiu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkGiu.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkGiu.Location = New System.Drawing.Point(145, 10)
        Me.lnkGiu.Name = "lnkGiu"
        Me.lnkGiu.Padding = New System.Windows.Forms.Padding(28, 5, 0, 5)
        Me.lnkGiu.Size = New System.Drawing.Size(53, 25)
        Me.lnkGiu.TabIndex = 84
        Me.lnkGiu.TabStop = True
        Me.lnkGiu.Text = "Giù"
        Me.lnkGiu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkConsegne
        '
        Me.chkConsegne.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkConsegne.FormattingEnabled = True
        Me.chkConsegne.Location = New System.Drawing.Point(0, 38)
        Me.chkConsegne.Name = "chkConsegne"
        Me.chkConsegne.Size = New System.Drawing.Size(200, 616)
        Me.chkConsegne.TabIndex = 0
        '
        'webPercorso
        '
        Me.webPercorso.AllowWebBrowserDrop = False
        Me.webPercorso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webPercorso.IsWebBrowserContextMenuEnabled = False
        Me.webPercorso.Location = New System.Drawing.Point(0, 0)
        Me.webPercorso.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webPercorso.Name = "webPercorso"
        Me.webPercorso.ScriptErrorsSuppressed = True
        Me.webPercorso.ScrollBarsEnabled = False
        Me.webPercorso.Size = New System.Drawing.Size(737, 681)
        Me.webPercorso.TabIndex = 0
        Me.webPercorso.WebBrowserShortcutsEnabled = False
        '
        'frmConsegnaPercorso
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 761)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmConsegnaPercorso"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Percorso Consegne"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.SplitPath.Panel1.ResumeLayout(False)
        Me.SplitPath.Panel1.PerformLayout()
        Me.SplitPath.Panel2.ResumeLayout(False)
        CType(Me.SplitPath, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPath.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents webPercorso As System.Windows.Forms.WebBrowser
    Friend WithEvents lnkChrome As System.Windows.Forms.LinkLabel
    Friend WithEvents SplitPath As System.Windows.Forms.SplitContainer
    Friend WithEvents chkConsegne As System.Windows.Forms.CheckedListBox
    Friend WithEvents lnkSu As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkGiu As System.Windows.Forms.LinkLabel
End Class
