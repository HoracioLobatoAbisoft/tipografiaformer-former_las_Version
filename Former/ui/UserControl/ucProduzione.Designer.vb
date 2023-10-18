<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucProduzione
    Inherits ucFormerUserControl


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucProduzione))
        Me.tabProduzione = New System.Windows.Forms.TabControl()
        Me.tpVerify = New System.Windows.Forms.TabPage()
        Me.UcProduzioneVerify = New Former.ucProduzioneVerify()
        Me.tpOffSet = New System.Windows.Forms.TabPage()
        Me.UcProduzioneOffset = New Former.ucProduzioneOffset()
        Me.tpDigitale = New System.Windows.Forms.TabPage()
        Me.UcProduzioneDigitale = New Former.ucProduzioneDigitale()
        Me.tpPackaging = New System.Windows.Forms.TabPage()
        Me.UcProduzionePackaging = New Former.ucProduzionePackaging()
        Me.tpRicamo = New System.Windows.Forms.TabPage()
        Me.UcProduzioneRicamo = New Former.ucProduzioneRicamo()
        Me.tpEtichette = New System.Windows.Forms.TabPage()
        Me.UcProduzioneEtichette = New Former.ucProduzioneEtichette()
        Me.tpModelliCommessa = New System.Windows.Forms.TabPage()
        Me.UcCommesseModelli = New Former.ucCommesseModelli()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitterMain = New System.Windows.Forms.SplitContainer()
        Me.UcOrdiniAnteprima = New Former.ucOrdiniAnteprima()
        Me.tabProduzione.SuspendLayout()
        Me.tpVerify.SuspendLayout()
        Me.tpOffSet.SuspendLayout()
        Me.tpDigitale.SuspendLayout()
        Me.tpPackaging.SuspendLayout()
        Me.tpRicamo.SuspendLayout()
        Me.tpEtichette.SuspendLayout()
        Me.tpModelliCommessa.SuspendLayout()
        CType(Me.SplitterMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitterMain.Panel1.SuspendLayout()
        Me.SplitterMain.Panel2.SuspendLayout()
        Me.SplitterMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabProduzione
        '
        Me.tabProduzione.Controls.Add(Me.tpVerify)
        Me.tabProduzione.Controls.Add(Me.tpOffSet)
        Me.tabProduzione.Controls.Add(Me.tpDigitale)
        Me.tabProduzione.Controls.Add(Me.tpPackaging)
        Me.tabProduzione.Controls.Add(Me.tpRicamo)
        Me.tabProduzione.Controls.Add(Me.tpEtichette)
        Me.tabProduzione.Controls.Add(Me.tpModelliCommessa)
        Me.tabProduzione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabProduzione.ImageList = Me.imlTab
        Me.tabProduzione.Location = New System.Drawing.Point(0, 0)
        Me.tabProduzione.Name = "tabProduzione"
        Me.tabProduzione.SelectedIndex = 0
        Me.tabProduzione.Size = New System.Drawing.Size(836, 705)
        Me.tabProduzione.TabIndex = 0
        '
        'tpVerify
        '
        Me.tpVerify.Controls.Add(Me.UcProduzioneVerify)
        Me.tpVerify.ImageKey = "_Attenzione.png"
        Me.tpVerify.Location = New System.Drawing.Point(4, 27)
        Me.tpVerify.Name = "tpVerify"
        Me.tpVerify.Padding = New System.Windows.Forms.Padding(3)
        Me.tpVerify.Size = New System.Drawing.Size(828, 674)
        Me.tpVerify.TabIndex = 6
        Me.tpVerify.Text = "Da Verificare"
        Me.tpVerify.UseVisualStyleBackColor = True
        '
        'UcProduzioneVerify
        '
        Me.UcProduzioneVerify.BackColor = System.Drawing.Color.White
        Me.UcProduzioneVerify.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcProduzioneVerify.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcProduzioneVerify.IdOrdSel = Nothing
        Me.UcProduzioneVerify.Location = New System.Drawing.Point(3, 3)
        Me.UcProduzioneVerify.Name = "UcProduzioneVerify"
        Me.UcProduzioneVerify.Size = New System.Drawing.Size(822, 668)
        Me.UcProduzioneVerify.TabIndex = 0
        '
        'tpOffSet
        '
        Me.tpOffSet.Controls.Add(Me.UcProduzioneOffset)
        Me.tpOffSet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tpOffSet.ImageKey = "RepOffset.png"
        Me.tpOffSet.Location = New System.Drawing.Point(4, 27)
        Me.tpOffSet.Name = "tpOffSet"
        Me.tpOffSet.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOffSet.Size = New System.Drawing.Size(828, 674)
        Me.tpOffSet.TabIndex = 0
        Me.tpOffSet.Tag = "Stampa Offset"
        Me.tpOffSet.Text = "Stampa Offset"
        Me.tpOffSet.UseVisualStyleBackColor = True
        '
        'UcProduzioneOffset
        '
        Me.UcProduzioneOffset.BackColor = System.Drawing.Color.White
        Me.UcProduzioneOffset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcProduzioneOffset.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcProduzioneOffset.Location = New System.Drawing.Point(3, 3)
        Me.UcProduzioneOffset.Name = "UcProduzioneOffset"
        Me.UcProduzioneOffset.Size = New System.Drawing.Size(822, 668)
        Me.UcProduzioneOffset.TabIndex = 0
        '
        'tpDigitale
        '
        Me.tpDigitale.Controls.Add(Me.UcProduzioneDigitale)
        Me.tpDigitale.ImageKey = "RepDigitale.png"
        Me.tpDigitale.Location = New System.Drawing.Point(4, 27)
        Me.tpDigitale.Name = "tpDigitale"
        Me.tpDigitale.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDigitale.Size = New System.Drawing.Size(828, 674)
        Me.tpDigitale.TabIndex = 1
        Me.tpDigitale.Tag = "Stampa Digitale"
        Me.tpDigitale.Text = "Stampa Digitale"
        Me.tpDigitale.UseVisualStyleBackColor = True
        '
        'UcProduzioneDigitale
        '
        Me.UcProduzioneDigitale.BackColor = System.Drawing.Color.White
        Me.UcProduzioneDigitale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcProduzioneDigitale.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcProduzioneDigitale.Location = New System.Drawing.Point(3, 3)
        Me.UcProduzioneDigitale.Name = "UcProduzioneDigitale"
        Me.UcProduzioneDigitale.Size = New System.Drawing.Size(822, 668)
        Me.UcProduzioneDigitale.TabIndex = 0
        '
        'tpPackaging
        '
        Me.tpPackaging.Controls.Add(Me.UcProduzionePackaging)
        Me.tpPackaging.ImageKey = "RepPackaging.png"
        Me.tpPackaging.Location = New System.Drawing.Point(4, 27)
        Me.tpPackaging.Name = "tpPackaging"
        Me.tpPackaging.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPackaging.Size = New System.Drawing.Size(828, 674)
        Me.tpPackaging.TabIndex = 2
        Me.tpPackaging.Tag = "Packaging"
        Me.tpPackaging.Text = "Packaging"
        Me.tpPackaging.UseVisualStyleBackColor = True
        '
        'UcProduzionePackaging
        '
        Me.UcProduzionePackaging.BackColor = System.Drawing.Color.White
        Me.UcProduzionePackaging.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcProduzionePackaging.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcProduzionePackaging.Location = New System.Drawing.Point(3, 3)
        Me.UcProduzionePackaging.Name = "UcProduzionePackaging"
        Me.UcProduzionePackaging.Size = New System.Drawing.Size(822, 668)
        Me.UcProduzionePackaging.TabIndex = 0
        '
        'tpRicamo
        '
        Me.tpRicamo.Controls.Add(Me.UcProduzioneRicamo)
        Me.tpRicamo.ImageKey = "RepRicamo.png"
        Me.tpRicamo.Location = New System.Drawing.Point(4, 27)
        Me.tpRicamo.Name = "tpRicamo"
        Me.tpRicamo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRicamo.Size = New System.Drawing.Size(828, 674)
        Me.tpRicamo.TabIndex = 3
        Me.tpRicamo.Tag = "Ricamo"
        Me.tpRicamo.Text = "Ricamo"
        Me.tpRicamo.UseVisualStyleBackColor = True
        '
        'UcProduzioneRicamo
        '
        Me.UcProduzioneRicamo.BackColor = System.Drawing.Color.White
        Me.UcProduzioneRicamo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcProduzioneRicamo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcProduzioneRicamo.Location = New System.Drawing.Point(3, 3)
        Me.UcProduzioneRicamo.Name = "UcProduzioneRicamo"
        Me.UcProduzioneRicamo.Size = New System.Drawing.Size(822, 668)
        Me.UcProduzioneRicamo.TabIndex = 0
        '
        'tpEtichette
        '
        Me.tpEtichette.Controls.Add(Me.UcProduzioneEtichette)
        Me.tpEtichette.ImageKey = "RepEtichette.png"
        Me.tpEtichette.Location = New System.Drawing.Point(4, 22)
        Me.tpEtichette.Name = "tpEtichette"
        Me.tpEtichette.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEtichette.Size = New System.Drawing.Size(192, 74)
        Me.tpEtichette.TabIndex = 4
        Me.tpEtichette.Tag = "Etichette"
        Me.tpEtichette.Text = "Etichette"
        Me.tpEtichette.UseVisualStyleBackColor = True
        '
        'UcProduzioneEtichette
        '
        Me.UcProduzioneEtichette.BackColor = System.Drawing.Color.White
        Me.UcProduzioneEtichette.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcProduzioneEtichette.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcProduzioneEtichette.Location = New System.Drawing.Point(3, 3)
        Me.UcProduzioneEtichette.Name = "UcProduzioneEtichette"
        Me.UcProduzioneEtichette.Size = New System.Drawing.Size(186, 68)
        Me.UcProduzioneEtichette.TabIndex = 0
        '
        'tpModelliCommessa
        '
        Me.tpModelliCommessa.Controls.Add(Me.UcCommesseModelli)
        Me.tpModelliCommessa.ImageKey = "_ModelloCommessa.png"
        Me.tpModelliCommessa.Location = New System.Drawing.Point(4, 22)
        Me.tpModelliCommessa.Name = "tpModelliCommessa"
        Me.tpModelliCommessa.Padding = New System.Windows.Forms.Padding(3)
        Me.tpModelliCommessa.Size = New System.Drawing.Size(192, 74)
        Me.tpModelliCommessa.TabIndex = 5
        Me.tpModelliCommessa.Text = "Modelli Commessa"
        Me.tpModelliCommessa.UseVisualStyleBackColor = True
        '
        'UcCommesseModelli
        '
        Me.UcCommesseModelli.BackColor = System.Drawing.Color.White
        Me.UcCommesseModelli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcCommesseModelli.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcCommesseModelli.IdModelloCommessa = 0
        Me.UcCommesseModelli.Location = New System.Drawing.Point(3, 3)
        Me.UcCommesseModelli.Name = "UcCommesseModelli"
        Me.UcCommesseModelli.Size = New System.Drawing.Size(186, 68)
        Me.UcCommesseModelli.TabIndex = 0
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "RepEtichette.png")
        Me.imlTab.Images.SetKeyName(1, "RepRicamo.png")
        Me.imlTab.Images.SetKeyName(2, "RepPackaging.png")
        Me.imlTab.Images.SetKeyName(3, "RepDigitale.png")
        Me.imlTab.Images.SetKeyName(4, "RepOffset.png")
        Me.imlTab.Images.SetKeyName(5, "_ModelloCommessa.png")
        Me.imlTab.Images.SetKeyName(6, "_Attenzione.png")
        '
        'SplitterMain
        '
        Me.SplitterMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitterMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitterMain.Location = New System.Drawing.Point(0, 0)
        Me.SplitterMain.Name = "SplitterMain"
        '
        'SplitterMain.Panel1
        '
        Me.SplitterMain.Panel1.Controls.Add(Me.tabProduzione)
        '
        'SplitterMain.Panel2
        '
        Me.SplitterMain.Panel2.Controls.Add(Me.UcOrdiniAnteprima)
        Me.SplitterMain.Size = New System.Drawing.Size(1150, 705)
        Me.SplitterMain.SplitterDistance = 836
        Me.SplitterMain.TabIndex = 1
        '
        'UcOrdiniAnteprima
        '
        Me.UcOrdiniAnteprima.BackColor = System.Drawing.Color.White
        Me.UcOrdiniAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOrdiniAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdiniAnteprima.Location = New System.Drawing.Point(0, 0)
        Me.UcOrdiniAnteprima.Name = "UcOrdiniAnteprima"
        Me.UcOrdiniAnteprima.NascondiResto = True
        Me.UcOrdiniAnteprima.NoLavori = False
        Me.UcOrdiniAnteprima.Size = New System.Drawing.Size(310, 705)
        Me.UcOrdiniAnteprima.TabIndex = 0
        '
        'ucProduzione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.SplitterMain)
        Me.Name = "ucProduzione"
        Me.Size = New System.Drawing.Size(1150, 705)
        Me.tabProduzione.ResumeLayout(False)
        Me.tpVerify.ResumeLayout(False)
        Me.tpOffSet.ResumeLayout(False)
        Me.tpDigitale.ResumeLayout(False)
        Me.tpPackaging.ResumeLayout(False)
        Me.tpRicamo.ResumeLayout(False)
        Me.tpEtichette.ResumeLayout(False)
        Me.tpModelliCommessa.ResumeLayout(False)
        Me.SplitterMain.Panel1.ResumeLayout(False)
        Me.SplitterMain.Panel2.ResumeLayout(False)
        CType(Me.SplitterMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitterMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabProduzione As TabControl
    Friend WithEvents tpOffSet As TabPage
    Friend WithEvents tpDigitale As TabPage
    Friend WithEvents tpPackaging As TabPage
    Friend WithEvents tpRicamo As TabPage
    Friend WithEvents tpEtichette As TabPage
    Friend WithEvents UcProduzioneOffset As ucProduzioneOffset
    Friend WithEvents imlTab As ImageList
    Friend WithEvents UcProduzioneDigitale As ucProduzioneDigitale
    Friend WithEvents UcProduzionePackaging As ucProduzionePackaging
    Friend WithEvents UcProduzioneRicamo As ucProduzioneRicamo
    Friend WithEvents UcProduzioneEtichette As ucProduzioneEtichette
    Friend WithEvents tpModelliCommessa As TabPage
    Friend WithEvents UcCommesseModelli As ucCommesseModelli
    Friend WithEvents SplitterMain As SplitContainer
    Friend WithEvents UcOrdiniAnteprima As ucOrdiniAnteprima
    Friend WithEvents tpVerify As TabPage
    Friend WithEvents UcProduzioneVerify As ucProduzioneVerify
End Class
