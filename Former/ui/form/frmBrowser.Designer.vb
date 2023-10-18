<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrowser
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.WebMain = New System.Windows.Forms.WebBrowser()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lnkImportaAutomaticamenteFattureMancanti = New System.Windows.Forms.LinkLabel()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.gbPulsanti.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1001, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(74, 26)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1076, 670)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.WebMain)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1068, 642)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former Browser"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'WebMain
        '
        Me.WebMain.AllowWebBrowserDrop = False
        Me.WebMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebMain.IsWebBrowserContextMenuEnabled = False
        Me.WebMain.Location = New System.Drawing.Point(3, 3)
        Me.WebMain.MinimumSize = New System.Drawing.Size(17, 17)
        Me.WebMain.Name = "WebMain"
        Me.WebMain.ScriptErrorsSuppressed = True
        Me.WebMain.Size = New System.Drawing.Size(1062, 636)
        Me.WebMain.TabIndex = 0
        Me.WebMain.WebBrowserShortcutsEnabled = False
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lnkImportaAutomaticamenteFattureMancanti)
        Me.gbPulsanti.Controls.Add(Me.lnkStampa)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 670)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1076, 42)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'lnkImportaAutomaticamenteFattureMancanti
        '
        Me.lnkImportaAutomaticamenteFattureMancanti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkImportaAutomaticamenteFattureMancanti.Image = Global.Former.My.Resources.Resources._Importa
        Me.lnkImportaAutomaticamenteFattureMancanti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkImportaAutomaticamenteFattureMancanti.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkImportaAutomaticamenteFattureMancanti.Location = New System.Drawing.Point(106, 10)
        Me.lnkImportaAutomaticamenteFattureMancanti.Name = "lnkImportaAutomaticamenteFattureMancanti"
        Me.lnkImportaAutomaticamenteFattureMancanti.Size = New System.Drawing.Size(219, 26)
        Me.lnkImportaAutomaticamenteFattureMancanti.TabIndex = 56
        Me.lnkImportaAutomaticamenteFattureMancanti.TabStop = True
        Me.lnkImportaAutomaticamenteFattureMancanti.Text = "Importa Fatture Ricevute mancanti"
        Me.lnkImportaAutomaticamenteFattureMancanti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkImportaAutomaticamenteFattureMancanti.Visible = False
        '
        'lnkStampa
        '
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(6, 10)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 26)
        Me.lnkStampa.TabIndex = 55
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmBrowser
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1076, 712)
        Me.CloseOnEsc = True
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmBrowser"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Browser"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.gbPulsanti.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents WebMain As System.Windows.Forms.WebBrowser
    Friend WithEvents lnkStampa As LinkLabel
    Friend WithEvents lnkImportaAutomaticamenteFattureMancanti As LinkLabel
End Class
