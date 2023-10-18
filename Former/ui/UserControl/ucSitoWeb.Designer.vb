<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSitoWeb
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucSitoWeb))
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tpBannerSito = New System.Windows.Forms.TabPage()
        Me.UcSitoWebBannerSito = New Former.ucSitoWebBannerSito()
        Me.tpRecensioni = New System.Windows.Forms.TabPage()
        Me.tpBlog = New System.Windows.Forms.TabPage()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.UcRecensioniProdotti = New Former.ucSitoWebRecensioniProdotti()
        Me.TabMain.SuspendLayout()
        Me.tpBannerSito.SuspendLayout()
        Me.tpRecensioni.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tpBannerSito)
        Me.TabMain.Controls.Add(Me.tpRecensioni)
        Me.TabMain.Controls.Add(Me.tpBlog)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ImageList = Me.imlTab
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1137, 689)
        Me.TabMain.TabIndex = 0
        '
        'tpBannerSito
        '
        Me.tpBannerSito.Controls.Add(Me.UcSitoWebBannerSito)
        Me.tpBannerSito.ImageIndex = 0
        Me.tpBannerSito.Location = New System.Drawing.Point(4, 24)
        Me.tpBannerSito.Name = "tpBannerSito"
        Me.tpBannerSito.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBannerSito.Size = New System.Drawing.Size(1129, 661)
        Me.tpBannerSito.TabIndex = 0
        Me.tpBannerSito.Text = "Banner"
        Me.tpBannerSito.UseVisualStyleBackColor = True
        '
        'UcSitoWebBannerSito
        '
        Me.UcSitoWebBannerSito.BackColor = System.Drawing.Color.White
        Me.UcSitoWebBannerSito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSitoWebBannerSito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcSitoWebBannerSito.Location = New System.Drawing.Point(3, 3)
        Me.UcSitoWebBannerSito.Name = "UcSitoWebBannerSito"
        Me.UcSitoWebBannerSito.Size = New System.Drawing.Size(1123, 655)
        Me.UcSitoWebBannerSito.TabIndex = 0
        '
        'tpRecensioni
        '
        Me.tpRecensioni.Controls.Add(Me.UcRecensioniProdotti)
        Me.tpRecensioni.ImageIndex = 1
        Me.tpRecensioni.Location = New System.Drawing.Point(4, 24)
        Me.tpRecensioni.Name = "tpRecensioni"
        Me.tpRecensioni.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRecensioni.Size = New System.Drawing.Size(1129, 661)
        Me.tpRecensioni.TabIndex = 1
        Me.tpRecensioni.Text = "Recensioni Prodotti"
        Me.tpRecensioni.UseVisualStyleBackColor = True
        '
        'tpBlog
        '
        Me.tpBlog.ImageIndex = 2
        Me.tpBlog.Location = New System.Drawing.Point(4, 24)
        Me.tpBlog.Name = "tpBlog"
        Me.tpBlog.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBlog.Size = New System.Drawing.Size(1129, 661)
        Me.tpBlog.TabIndex = 2
        Me.tpBlog.Text = "Blog"
        Me.tpBlog.UseVisualStyleBackColor = True
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "_Banner.png")
        Me.imlTab.Images.SetKeyName(1, "_Recensione.png")
        Me.imlTab.Images.SetKeyName(2, "_blog.png")
        '
        'UcRecensioniProdotti
        '
        Me.UcRecensioniProdotti.BackColor = System.Drawing.Color.White
        Me.UcRecensioniProdotti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcRecensioniProdotti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcRecensioniProdotti.Location = New System.Drawing.Point(3, 3)
        Me.UcRecensioniProdotti.Name = "UcRecensioniProdotti"
        Me.UcRecensioniProdotti.Size = New System.Drawing.Size(1123, 655)
        Me.UcRecensioniProdotti.TabIndex = 0
        '
        'ucSitoWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TabMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucSitoWeb"
        Me.Size = New System.Drawing.Size(1137, 689)
        Me.TabMain.ResumeLayout(False)
        Me.tpBannerSito.ResumeLayout(False)
        Me.tpRecensioni.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpBannerSito As System.Windows.Forms.TabPage
    Friend WithEvents tpRecensioni As System.Windows.Forms.TabPage
    Friend WithEvents tpBlog As System.Windows.Forms.TabPage
    Friend WithEvents UcSitoWebBannerSito As Former.ucSitoWebBannerSito
    Friend WithEvents imlTab As System.Windows.Forms.ImageList
    Friend WithEvents UcRecensioniProdotti As Former.ucSitoWebRecensioniProdotti

End Class
