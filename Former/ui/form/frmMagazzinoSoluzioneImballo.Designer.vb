<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMagazzinoSoluzioneImballo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMagazzinoSoluzioneImballo))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.btnStampaEtich = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tvConsegne = New System.Windows.Forms.TreeView()
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.tvwSoluzioni = New System.Windows.Forms.TreeView()
        Me.imlScat = New System.Windows.Forms.ImageList(Me.components)
        Me.flowP = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblVerso = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(861, 703)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 36)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(955, 778)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.btnCancel)
        Me.tbProd.Controls.Add(Me.btnStampaEtich)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.tvConsegne)
        Me.tbProd.Controls.Add(Me.tvwSoluzioni)
        Me.tbProd.Controls.Add(Me.flowP)
        Me.tbProd.Controls.Add(Me.lblVerso)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(947, 752)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Soluzione di Imballo"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'btnStampaEtich
        '
        Me.btnStampaEtich.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStampaEtich.BackColor = System.Drawing.Color.White
        Me.btnStampaEtich.Image = Global.Former.My.Resources.Resources._Etichetta
        Me.btnStampaEtich.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampaEtich.Location = New System.Drawing.Point(719, 702)
        Me.btnStampaEtich.Name = "btnStampaEtich"
        Me.btnStampaEtich.Size = New System.Drawing.Size(136, 42)
        Me.btnStampaEtich.TabIndex = 108
        Me.btnStampaEtich.Text = "Etichette Ordine"
        Me.btnStampaEtich.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStampaEtich.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(8, 488)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 15)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Soluzioni di imballo possibili"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(285, 488)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 15)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Riepilogo Consegna:"
        '
        'tvConsegne
        '
        Me.tvConsegne.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvConsegne.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tvConsegne.ImageIndex = 0
        Me.tvConsegne.ImageList = Me.imlCli
        Me.tvConsegne.Indent = 20
        Me.tvConsegne.ItemHeight = 25
        Me.tvConsegne.Location = New System.Drawing.Point(288, 506)
        Me.tvConsegne.Name = "tvConsegne"
        Me.tvConsegne.SelectedImageIndex = 0
        Me.tvConsegne.Size = New System.Drawing.Size(651, 190)
        Me.tvConsegne.TabIndex = 105
        '
        'imlCli
        '
        Me.imlCli.ImageStream = CType(resources.GetObject("imlCli.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCli.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCli.Images.SetKeyName(0, "icoCli.jpg")
        Me.imlCli.Images.SetKeyName(1, "icoOrder.jpg")
        Me.imlCli.Images.SetKeyName(2, "icoPrint.jpg")
        Me.imlCli.Images.SetKeyName(3, "icoMoney.jpg")
        Me.imlCli.Images.SetKeyName(4, "icoRubRed.jpg")
        Me.imlCli.Images.SetKeyName(5, "icoParamRed.jpg")
        Me.imlCli.Images.SetKeyName(6, "Corriere.png")
        Me.imlCli.Images.SetKeyName(7, "icoCal.jpg")
        Me.imlCli.Images.SetKeyName(8, "IcoFast.png")
        Me.imlCli.Images.SetKeyName(9, "IcoLow.png")
        Me.imlCli.Images.SetKeyName(10, "Box.bmp")
        '
        'tvwSoluzioni
        '
        Me.tvwSoluzioni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvwSoluzioni.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tvwSoluzioni.ImageIndex = 0
        Me.tvwSoluzioni.ImageList = Me.imlScat
        Me.tvwSoluzioni.Location = New System.Drawing.Point(8, 506)
        Me.tvwSoluzioni.Name = "tvwSoluzioni"
        Me.tvwSoluzioni.SelectedImageIndex = 0
        Me.tvwSoluzioni.ShowRootLines = False
        Me.tvwSoluzioni.Size = New System.Drawing.Size(274, 190)
        Me.tvwSoluzioni.TabIndex = 21
        '
        'imlScat
        '
        Me.imlScat.ImageStream = CType(resources.GetObject("imlScat.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlScat.TransparentColor = System.Drawing.Color.Transparent
        Me.imlScat.Images.SetKeyName(0, "Business20-11.png")
        '
        'flowP
        '
        Me.flowP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flowP.AutoScroll = True
        Me.flowP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.flowP.Location = New System.Drawing.Point(8, 46)
        Me.flowP.Name = "flowP"
        Me.flowP.Size = New System.Drawing.Size(931, 439)
        Me.flowP.TabIndex = 20
        '
        'lblVerso
        '
        Me.lblVerso.AutoSize = True
        Me.lblVerso.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblVerso.Location = New System.Drawing.Point(269, 16)
        Me.lblVerso.Name = "lblVerso"
        Me.lblVerso.Size = New System.Drawing.Size(15, 20)
        Me.lblVerso.TabIndex = 19
        Me.lblVerso.Text = "-"
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Ordine
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
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(49, 12)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(62, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Ordine"
        '
        'frmMagazzinoSoluzioneImballo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(955, 778)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "frmMagazzinoSoluzioneImballo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Imballaggio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblVerso As System.Windows.Forms.Label
    Friend WithEvents flowP As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tvwSoluzioni As System.Windows.Forms.TreeView
    Friend WithEvents imlScat As System.Windows.Forms.ImageList
    Friend WithEvents imlCli As System.Windows.Forms.ImageList
    Friend WithEvents tvConsegne As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnStampaEtich As System.Windows.Forms.Button
End Class
