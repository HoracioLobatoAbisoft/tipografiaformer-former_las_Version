<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProntoRitiroCliente
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProntoRitiroCliente))
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.tvConsCliente = New System.Windows.Forms.TreeView()
        Me.imlAlberoCons = New System.Windows.Forms.ImageList(Me.components)
        Me.UcCommesseAnteprimaOp = New Former.ucAnteprimaOperatore()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(800, 600)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.cmbCliente)
        Me.tbProd.Controls.Add(Me.tvConsCliente)
        Me.tbProd.Controls.Add(Me.UcCommesseAnteprimaOp)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(792, 572)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Pronto ritiro cliente"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'cmbCliente
        '
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(234, 12)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(552, 26)
        Me.cmbCliente.TabIndex = 114
        '
        'tvConsCliente
        '
        Me.tvConsCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvConsCliente.ImageIndex = 0
        Me.tvConsCliente.ImageList = Me.imlAlberoCons
        Me.tvConsCliente.Indent = 15
        Me.tvConsCliente.Location = New System.Drawing.Point(8, 51)
        Me.tvConsCliente.Name = "tvConsCliente"
        Me.tvConsCliente.SelectedImageIndex = 0
        Me.tvConsCliente.Size = New System.Drawing.Size(458, 515)
        Me.tvConsCliente.TabIndex = 113
        '
        'imlAlberoCons
        '
        Me.imlAlberoCons.ImageStream = CType(resources.GetObject("imlAlberoCons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlAlberoCons.TransparentColor = System.Drawing.Color.Transparent
        Me.imlAlberoCons.Images.SetKeyName(0, "icoCli.jpg")
        Me.imlAlberoCons.Images.SetKeyName(1, "icoOrder.jpg")
        Me.imlAlberoCons.Images.SetKeyName(2, "icoPrint.jpg")
        Me.imlAlberoCons.Images.SetKeyName(3, "icoMoney.jpg")
        Me.imlAlberoCons.Images.SetKeyName(4, "icoRubRed.jpg")
        Me.imlAlberoCons.Images.SetKeyName(5, "icoParamRed.jpg")
        Me.imlAlberoCons.Images.SetKeyName(6, "Corriere.png")
        Me.imlAlberoCons.Images.SetKeyName(7, "icoCal.jpg")
        '
        'UcCommesseAnteprimaOp
        '
        Me.UcCommesseAnteprimaOp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcCommesseAnteprimaOp.BackColor = System.Drawing.Color.White
        Me.UcCommesseAnteprimaOp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcCommesseAnteprimaOp.Location = New System.Drawing.Point(472, 50)
        Me.UcCommesseAnteprimaOp.Name = "UcCommesseAnteprimaOp"
        Me.UcCommesseAnteprimaOp.Size = New System.Drawing.Size(317, 516)
        Me.UcCommesseAnteprimaOp.TabIndex = 112
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.icoOrder
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
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(179, 22)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Pronto Ritiro Cliente"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Former.My.Resources.icoOk
        Me.btnOk.Location = New System.Drawing.Point(800, 20)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(69, 69)
        Me.btnOk.TabIndex = 92
        Me.btnOk.TabStop = False
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'frmProntoRitiroCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        
        Me.ClientSize = New System.Drawing.Size(870, 600)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.TabMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        
        Me.KeyPreview = True
        Me.Name = "frmProntoRitiroCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - "
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents tvConsCliente As System.Windows.Forms.TreeView
    Friend WithEvents imlAlberoCons As System.Windows.Forms.ImageList
    Friend WithEvents UcCommesseAnteprimaOp As Former.ucAnteprimaOperatore
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
