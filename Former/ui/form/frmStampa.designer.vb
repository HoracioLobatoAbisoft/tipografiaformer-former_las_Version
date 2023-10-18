<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStampa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStampa))
        Me.PrintPreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.WebPrint = New System.Windows.Forms.WebBrowser()
        Me.btnAnteprima = New Former.ucButton()
        Me.btnImposta = New Former.ucButton()
        Me.tabStampa = New System.Windows.Forms.TabControl()
        Me.tabPstampa = New System.Windows.Forms.TabPage()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabPHelp = New System.Windows.Forms.TabPage()
        Me.webHelp = New System.Windows.Forms.WebBrowser()
        Me.tabStampa.SuspendLayout()
        Me.tabPstampa.SuspendLayout()
        Me.TabPHelp.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintPreview
        '
        Me.PrintPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreview.Enabled = True
        Me.PrintPreview.Icon = CType(resources.GetObject("PrintPreview.Icon"), System.Drawing.Icon)
        Me.PrintPreview.Name = "PrintPreview"
        Me.PrintPreview.Visible = False
        '
        'WebPrint
        '
        Me.WebPrint.AllowWebBrowserDrop = False
        Me.WebPrint.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebPrint.IsWebBrowserContextMenuEnabled = False
        Me.WebPrint.Location = New System.Drawing.Point(3, 6)
        Me.WebPrint.MinimumSize = New System.Drawing.Size(23, 23)
        Me.WebPrint.Name = "WebPrint"
        Me.WebPrint.Size = New System.Drawing.Size(682, 431)
        Me.WebPrint.TabIndex = 0
        Me.WebPrint.WebBrowserShortcutsEnabled = False
        '
        'btnAnteprima
        '
        Me.btnAnteprima.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnteprima.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnAnteprima.Enabled = False
        Me.btnAnteprima.FlatAppearance.BorderSize = 0
        Me.btnAnteprima.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnAnteprima.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAnteprima.Location = New System.Drawing.Point(691, 40)
        Me.btnAnteprima.Name = "btnAnteprima"
        Me.btnAnteprima.Radius = 5
        Me.btnAnteprima.RoundedButton = True
        Me.btnAnteprima.Size = New System.Drawing.Size(110, 30)
        Me.btnAnteprima.TabIndex = 1
        Me.btnAnteprima.Text = "STAMPA"
        Me.btnAnteprima.UseVisualStyleBackColor = False
        '
        'btnImposta
        '
        Me.btnImposta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImposta.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.btnImposta.FlatAppearance.BorderSize = 0
        Me.btnImposta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnImposta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImposta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnImposta.Location = New System.Drawing.Point(691, 4)
        Me.btnImposta.Name = "btnImposta"
        Me.btnImposta.Radius = 5
        Me.btnImposta.RoundedButton = True
        Me.btnImposta.Size = New System.Drawing.Size(110, 30)
        Me.btnImposta.TabIndex = 1
        Me.btnImposta.Text = "IMPOSTA PAGINA"
        Me.btnImposta.UseVisualStyleBackColor = False
        '
        'tabStampa
        '
        Me.tabStampa.Controls.Add(Me.tabPstampa)
        Me.tabStampa.Controls.Add(Me.TabPHelp)
        Me.tabStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabStampa.Location = New System.Drawing.Point(0, 0)
        Me.tabStampa.Name = "tabStampa"
        Me.tabStampa.SelectedIndex = 0
        Me.tabStampa.Size = New System.Drawing.Size(815, 469)
        Me.tabStampa.TabIndex = 2
        '
        'tabPstampa
        '
        Me.tabPstampa.Controls.Add(Me.btnOk)
        Me.tabPstampa.Controls.Add(Me.WebPrint)
        Me.tabPstampa.Controls.Add(Me.btnImposta)
        Me.tabPstampa.Controls.Add(Me.btnAnteprima)
        Me.tabPstampa.Location = New System.Drawing.Point(4, 22)
        Me.tabPstampa.Name = "tabPstampa"
        Me.tabPstampa.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPstampa.Size = New System.Drawing.Size(807, 443)
        Me.tabPstampa.TabIndex = 0
        Me.tabPstampa.Text = "Stampa"
        Me.tabPstampa.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark2
        Me.btnOk.Location = New System.Drawing.Point(730, 407)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 30)
        Me.btnOk.TabIndex = 16
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabPHelp
        '
        Me.TabPHelp.Controls.Add(Me.webHelp)
        Me.TabPHelp.Location = New System.Drawing.Point(4, 22)
        Me.TabPHelp.Name = "TabPHelp"
        Me.TabPHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPHelp.Size = New System.Drawing.Size(807, 443)
        Me.TabPHelp.TabIndex = 1
        Me.TabPHelp.Text = "Help"
        Me.TabPHelp.UseVisualStyleBackColor = True
        '
        'webHelp
        '
        Me.webHelp.AllowWebBrowserDrop = False
        Me.webHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webHelp.IsWebBrowserContextMenuEnabled = False
        Me.webHelp.Location = New System.Drawing.Point(3, 3)
        Me.webHelp.MinimumSize = New System.Drawing.Size(23, 23)
        Me.webHelp.Name = "webHelp"
        Me.webHelp.Size = New System.Drawing.Size(801, 437)
        Me.webHelp.TabIndex = 1
        Me.webHelp.WebBrowserShortcutsEnabled = False
        '
        'frmStampa
        '
        Me.AcceptButton = Me.btnAnteprima
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnOk
        Me.ClientSize = New System.Drawing.Size(815, 469)
        Me.Controls.Add(Me.tabStampa)
        Me.Name = "frmStampa"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Stampa "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tabStampa.ResumeLayout(False)
        Me.tabPstampa.ResumeLayout(False)
        Me.TabPHelp.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintPreview As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents WebPrint As System.Windows.Forms.WebBrowser
    Friend WithEvents btnAnteprima As ucButton
    Friend WithEvents btnImposta As ucButton
    Friend WithEvents tabStampa As System.Windows.Forms.TabControl
    Friend WithEvents tabPstampa As System.Windows.Forms.TabPage
    Friend WithEvents TabPHelp As System.Windows.Forms.TabPage
    Friend WithEvents webHelp As System.Windows.Forms.WebBrowser
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
