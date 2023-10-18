<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBase
    Inherits baseFormInternaFixed

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
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.chkPlast = New System.Windows.Forms.CheckBox()
        Me.cmbTipoProd = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodice = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.tpHelp = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MainBar = New System.Windows.Forms.MenuStrip()
        Me.ChiudiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalvaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHelp.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainBar.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpHelp)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(955, 362)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.chkPlast)
        Me.tbProd.Controls.Add(Me.cmbTipoProd)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtCodice)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(947, 334)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Prodotto"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'chkPlast
        '
        Me.chkPlast.AutoSize = True
        Me.chkPlast.Location = New System.Drawing.Point(327, 56)
        Me.chkPlast.Name = "chkPlast"
        Me.chkPlast.Size = New System.Drawing.Size(84, 19)
        Me.chkPlast.TabIndex = 5
        Me.chkPlast.Text = "Plastificato"
        Me.chkPlast.UseVisualStyleBackColor = True
        '
        'cmbTipoProd
        '
        Me.cmbTipoProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoProd.FormattingEnabled = True
        Me.cmbTipoProd.Location = New System.Drawing.Point(154, 84)
        Me.cmbTipoProd.Name = "cmbTipoProd"
        Me.cmbTipoProd.Size = New System.Drawing.Size(157, 23)
        Me.cmbTipoProd.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(50, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Codice"
        '
        'txtCodice
        '
        Me.txtCodice.Location = New System.Drawing.Point(154, 57)
        Me.txtCodice.MaxLength = 50
        Me.txtCodice.Name = "txtCodice"
        Me.txtCodice.Size = New System.Drawing.Size(157, 23)
        Me.txtCodice.TabIndex = 0
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.icoProd
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(78, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Prodotto"
        '
        'tpHelp
        '
        Me.tpHelp.Controls.Add(Me.PictureBox1)
        Me.tpHelp.Location = New System.Drawing.Point(4, 24)
        Me.tpHelp.Name = "tpHelp"
        Me.tpHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHelp.Size = New System.Drawing.Size(947, 334)
        Me.tpHelp.TabIndex = 1
        Me.tpHelp.Text = "Help"
        Me.tpHelp.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._help
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'MainBar
        '
        Me.MainBar.AutoSize = False
        Me.MainBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MainBar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChiudiToolStripMenuItem, Me.SalvaToolStripMenuItem})
        Me.MainBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MainBar.Location = New System.Drawing.Point(0, 362)
        Me.MainBar.Name = "MainBar"
        Me.MainBar.Size = New System.Drawing.Size(955, 44)
        Me.MainBar.TabIndex = 7
        Me.MainBar.Text = "MenuStrip1"
        '
        'ChiudiToolStripMenuItem
        '
        Me.ChiudiToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ChiudiToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChiudiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Annulla
        Me.ChiudiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ChiudiToolStripMenuItem.Name = "ChiudiToolStripMenuItem"
        Me.ChiudiToolStripMenuItem.Size = New System.Drawing.Size(80, 40)
        Me.ChiudiToolStripMenuItem.Text = "Chiudi"
        '
        'SalvaToolStripMenuItem
        '
        Me.SalvaToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SalvaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SalvaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Ok
        Me.SalvaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalvaToolStripMenuItem.Name = "SalvaToolStripMenuItem"
        Me.SalvaToolStripMenuItem.Size = New System.Drawing.Size(72, 40)
        Me.SalvaToolStripMenuItem.Text = "Salva"
        '
        'frmBase
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(955, 406)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.MainBar)
        Me.Name = "frmBase"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - "
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHelp.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainBar.ResumeLayout(False)
        Me.MainBar.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents chkPlast As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTipoProd As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCodice As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents tpHelp As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MainBar As MenuStrip
    Friend WithEvents SalvaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChiudiToolStripMenuItem As ToolStripMenuItem
End Class
