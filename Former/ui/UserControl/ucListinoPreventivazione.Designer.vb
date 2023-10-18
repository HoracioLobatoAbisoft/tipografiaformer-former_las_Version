<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucListinoPreventivazione
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucListinoPreventivazione))
        Me.mnuVoce = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpostaFormerChoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminaListinoBaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AggiungiPreventivazioneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AggiungiListinoBaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripAggiungiCat = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripElimina = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ApriCartellaAppuntiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SpostaListinoBaseInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpostaOrdineLavorazioniToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.StampaRiassuntoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tvwCat = New System.Windows.Forms.TreeView()
        Me.imlTvw = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.imlPuls = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnPronteChiudi = New System.Windows.Forms.Button()
        Me.btnPronteApri = New System.Windows.Forms.Button()
        Me.UcAnteprima = New Former.ucAnteprima()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CaricaListinoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckCongruenzaDatiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckDifferenzeListinoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImgTemporaneeInUsoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FotoHDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AggiungiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestisciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificaDatiWebToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostraSoloNascostiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVoce.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuVoce
        '
        Me.mnuVoce.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificaToolStripMenuItem, Me.ImpostaFormerChoiceToolStripMenuItem, Me.EliminaListinoBaseToolStripMenuItem, Me.ToolStripSeparator1, Me.AggiungiPreventivazioneToolStripMenuItem, Me.AggiungiListinoBaseToolStripMenuItem, Me.ToolStripSeparator4, Me.toolStripAggiungiCat, Me.toolStripElimina, Me.ToolStripSeparator2, Me.ApriCartellaAppuntiToolStripMenuItem, Me.ToolStripSeparator3, Me.SpostaListinoBaseInToolStripMenuItem, Me.ImpostaOrdineLavorazioniToolStripMenuItem, Me.ToolStripSeparator5, Me.StampaRiassuntoToolStripMenuItem})
        Me.mnuVoce.Name = "mnuVoce"
        Me.mnuVoce.Size = New System.Drawing.Size(268, 276)
        '
        'ModificaToolStripMenuItem
        '
        Me.ModificaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ModificaToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Modifica
        Me.ModificaToolStripMenuItem.Name = "ModificaToolStripMenuItem"
        Me.ModificaToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.ModificaToolStripMenuItem.Text = "Modifica"
        '
        'ImpostaFormerChoiceToolStripMenuItem
        '
        Me.ImpostaFormerChoiceToolStripMenuItem.Image = Global.Former.My.Resources.Resources.icoConsigliatoEx
        Me.ImpostaFormerChoiceToolStripMenuItem.Name = "ImpostaFormerChoiceToolStripMenuItem"
        Me.ImpostaFormerChoiceToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.ImpostaFormerChoiceToolStripMenuItem.Text = "Imposta Former Choice"
        '
        'EliminaListinoBaseToolStripMenuItem
        '
        Me.EliminaListinoBaseToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Elimina
        Me.EliminaListinoBaseToolStripMenuItem.Name = "EliminaListinoBaseToolStripMenuItem"
        Me.EliminaListinoBaseToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.EliminaListinoBaseToolStripMenuItem.Text = "Elimina ListinoBase"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(264, 6)
        '
        'AggiungiPreventivazioneToolStripMenuItem
        '
        Me.AggiungiPreventivazioneToolStripMenuItem.Name = "AggiungiPreventivazioneToolStripMenuItem"
        Me.AggiungiPreventivazioneToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.AggiungiPreventivazioneToolStripMenuItem.Text = "Aggiungi Preventivazione"
        '
        'AggiungiListinoBaseToolStripMenuItem
        '
        Me.AggiungiListinoBaseToolStripMenuItem.Name = "AggiungiListinoBaseToolStripMenuItem"
        Me.AggiungiListinoBaseToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.AggiungiListinoBaseToolStripMenuItem.Text = "Aggiungi Listino Base"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(264, 6)
        '
        'toolStripAggiungiCat
        '
        Me.toolStripAggiungiCat.Name = "toolStripAggiungiCat"
        Me.toolStripAggiungiCat.Size = New System.Drawing.Size(267, 22)
        Me.toolStripAggiungiCat.Text = "Aggiungi Categoria Virtuale"
        '
        'toolStripElimina
        '
        Me.toolStripElimina.Image = Global.Former.My.Resources.Resources._Elimina
        Me.toolStripElimina.Name = "toolStripElimina"
        Me.toolStripElimina.Size = New System.Drawing.Size(267, 22)
        Me.toolStripElimina.Text = "Elimina Categoria Virtuale"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(264, 6)
        '
        'ApriCartellaAppuntiToolStripMenuItem
        '
        Me.ApriCartellaAppuntiToolStripMenuItem.Name = "ApriCartellaAppuntiToolStripMenuItem"
        Me.ApriCartellaAppuntiToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.ApriCartellaAppuntiToolStripMenuItem.Text = "Apri Cartella Appunti"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(264, 6)
        '
        'SpostaListinoBaseInToolStripMenuItem
        '
        Me.SpostaListinoBaseInToolStripMenuItem.Name = "SpostaListinoBaseInToolStripMenuItem"
        Me.SpostaListinoBaseInToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.SpostaListinoBaseInToolStripMenuItem.Text = "Sposta Listino Base in "
        '
        'ImpostaOrdineLavorazioniToolStripMenuItem
        '
        Me.ImpostaOrdineLavorazioniToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Ordinamento
        Me.ImpostaOrdineLavorazioniToolStripMenuItem.Name = "ImpostaOrdineLavorazioniToolStripMenuItem"
        Me.ImpostaOrdineLavorazioniToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.ImpostaOrdineLavorazioniToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.ImpostaOrdineLavorazioniToolStripMenuItem.Text = "Imposta Ordine Lavorazioni"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(264, 6)
        '
        'StampaRiassuntoToolStripMenuItem
        '
        Me.StampaRiassuntoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Stampa
        Me.StampaRiassuntoToolStripMenuItem.Name = "StampaRiassuntoToolStripMenuItem"
        Me.StampaRiassuntoToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.StampaRiassuntoToolStripMenuItem.Text = "Stampa riassunto"
        '
        'tvwCat
        '
        Me.tvwCat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwCat.ImageIndex = 0
        Me.tvwCat.ImageList = Me.imlTvw
        Me.tvwCat.Location = New System.Drawing.Point(3, 31)
        Me.tvwCat.Name = "tvwCat"
        Me.tvwCat.SelectedImageIndex = 0
        Me.tvwCat.Size = New System.Drawing.Size(386, 320)
        Me.tvwCat.TabIndex = 48
        '
        'imlTvw
        '
        Me.imlTvw.ImageStream = CType(resources.GetObject("imlTvw.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTvw.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTvw.Images.SetKeyName(0, "_Preventivazione.png")
        Me.imlTvw.Images.SetKeyName(1, "_ListinoBase.png")
        Me.imlTvw.Images.SetKeyName(2, "_Cartella.png")
        Me.imlTvw.Images.SetKeyName(3, "_Filtro.png")
        Me.imlTvw.Images.SetKeyName(4, "icoConsigliatoEx.png")
        Me.imlTvw.Images.SetKeyName(5, "_CartellaAperta2.png")
        Me.imlTvw.Images.SetKeyName(6, "_GruppiVarianti.png")
        Me.imlTvw.Images.SetKeyName(7, "_ColoreStampa.png")
        Me.imlTvw.Images.SetKeyName(8, "_TipoCarta.png")
        Me.imlTvw.Images.SetKeyName(9, "_CategoriaLavorazioni.png")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(3, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 21)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Listino"
        '
        'imlPuls
        '
        Me.imlPuls.ImageStream = CType(resources.GetObject("imlPuls.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlPuls.TransparentColor = System.Drawing.Color.Transparent
        Me.imlPuls.Images.SetKeyName(0, "Button Delete.png")
        Me.imlPuls.Images.SetKeyName(1, "Button Add.png")
        Me.imlPuls.Images.SetKeyName(2, "Edit.png")
        Me.imlPuls.Images.SetKeyName(3, "Image.png")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 34)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnPronteChiudi)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnPronteApri)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvwCat)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.UcAnteprima)
        Me.SplitContainer1.Size = New System.Drawing.Size(997, 354)
        Me.SplitContainer1.SplitterDistance = 392
        Me.SplitContainer1.TabIndex = 95
        '
        'btnPronteChiudi
        '
        Me.btnPronteChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPronteChiudi.Location = New System.Drawing.Point(369, 9)
        Me.btnPronteChiudi.Name = "btnPronteChiudi"
        Me.btnPronteChiudi.Size = New System.Drawing.Size(20, 20)
        Me.btnPronteChiudi.TabIndex = 146
        Me.btnPronteChiudi.Text = "-"
        Me.btnPronteChiudi.UseVisualStyleBackColor = True
        '
        'btnPronteApri
        '
        Me.btnPronteApri.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPronteApri.Location = New System.Drawing.Point(349, 9)
        Me.btnPronteApri.Name = "btnPronteApri"
        Me.btnPronteApri.Size = New System.Drawing.Size(20, 20)
        Me.btnPronteApri.TabIndex = 145
        Me.btnPronteApri.Text = "+"
        Me.btnPronteApri.UseVisualStyleBackColor = True
        '
        'UcAnteprima
        '
        Me.UcAnteprima.BackColor = System.Drawing.Color.White
        Me.UcAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAnteprima.Location = New System.Drawing.Point(0, 0)
        Me.UcAnteprima.Name = "UcAnteprima"
        Me.UcAnteprima.Size = New System.Drawing.Size(601, 354)
        Me.UcAnteprima.TabIndex = 54
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CaricaListinoToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.FotoHDToolStripMenuItem, Me.ModificaDatiWebToolStripMenuItem, Me.MostraSoloNascostiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(997, 34)
        Me.MenuStrip1.TabIndex = 96
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CaricaListinoToolStripMenuItem
        '
        Me.CaricaListinoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.CaricaListinoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CaricaListinoToolStripMenuItem.Name = "CaricaListinoToolStripMenuItem"
        Me.CaricaListinoToolStripMenuItem.Size = New System.Drawing.Size(116, 30)
        Me.CaricaListinoToolStripMenuItem.Text = "Carica Listino"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckCongruenzaDatiToolStripMenuItem, Me.CheckDifferenzeListinoToolStripMenuItem, Me.ToolStripSeparator7, Me.ImgTemporaneeInUsoToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Strumenti
        Me.ToolsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(72, 30)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'CheckCongruenzaDatiToolStripMenuItem
        '
        Me.CheckCongruenzaDatiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Ok
        Me.CheckCongruenzaDatiToolStripMenuItem.Name = "CheckCongruenzaDatiToolStripMenuItem"
        Me.CheckCongruenzaDatiToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.CheckCongruenzaDatiToolStripMenuItem.Text = "Check congruenza dati"
        '
        'CheckDifferenzeListinoToolStripMenuItem
        '
        Me.CheckDifferenzeListinoToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.CheckDifferenzeListinoToolStripMenuItem.Name = "CheckDifferenzeListinoToolStripMenuItem"
        Me.CheckDifferenzeListinoToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.CheckDifferenzeListinoToolStripMenuItem.Text = "Check Differenze Listino"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(198, 6)
        '
        'ImgTemporaneeInUsoToolStripMenuItem
        '
        Me.ImgTemporaneeInUsoToolStripMenuItem.Image = Global.Former.My.Resources.Resources.ico_W_R1
        Me.ImgTemporaneeInUsoToolStripMenuItem.Name = "ImgTemporaneeInUsoToolStripMenuItem"
        Me.ImgTemporaneeInUsoToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ImgTemporaneeInUsoToolStripMenuItem.Text = "Img temporanee in uso"
        '
        'FotoHDToolStripMenuItem
        '
        Me.FotoHDToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.FotoHDToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AggiungiToolStripMenuItem, Me.GestisciToolStripMenuItem})
        Me.FotoHDToolStripMenuItem.Image = Global.Former.My.Resources.Resources._FotoHd
        Me.FotoHDToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FotoHDToolStripMenuItem.Name = "FotoHDToolStripMenuItem"
        Me.FotoHDToolStripMenuItem.Size = New System.Drawing.Size(89, 30)
        Me.FotoHDToolStripMenuItem.Text = "Foto HD"
        Me.FotoHDToolStripMenuItem.Visible = False
        '
        'AggiungiToolStripMenuItem
        '
        Me.AggiungiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.AggiungiToolStripMenuItem.Name = "AggiungiToolStripMenuItem"
        Me.AggiungiToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AggiungiToolStripMenuItem.Text = "Aggiungi..."
        '
        'GestisciToolStripMenuItem
        '
        Me.GestisciToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Strumenti
        Me.GestisciToolStripMenuItem.Name = "GestisciToolStripMenuItem"
        Me.GestisciToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GestisciToolStripMenuItem.Text = "Gestisci..."
        '
        'ModificaDatiWebToolStripMenuItem
        '
        Me.ModificaDatiWebToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ModificaDatiWebToolStripMenuItem.Image = Global.Former.My.Resources.Resources._internet
        Me.ModificaDatiWebToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificaDatiWebToolStripMenuItem.Name = "ModificaDatiWebToolStripMenuItem"
        Me.ModificaDatiWebToolStripMenuItem.Size = New System.Drawing.Size(143, 30)
        Me.ModificaDatiWebToolStripMenuItem.Text = "Modifica Dati Web"
        '
        'MostraSoloNascostiToolStripMenuItem
        '
        Me.MostraSoloNascostiToolStripMenuItem.Image = Global.Former.My.Resources.Resources._Ghost26
        Me.MostraSoloNascostiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MostraSoloNascostiToolStripMenuItem.Name = "MostraSoloNascostiToolStripMenuItem"
        Me.MostraSoloNascostiToolStripMenuItem.Size = New System.Drawing.Size(153, 30)
        Me.MostraSoloNascostiToolStripMenuItem.Text = "Mostra solo nascosti"
        '
        'ucListinoPreventivazione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "ucListinoPreventivazione"
        Me.Size = New System.Drawing.Size(997, 388)
        Me.mnuVoce.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuVoce As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tvwCat As System.Windows.Forms.TreeView
    Friend WithEvents imlTvw As System.Windows.Forms.ImageList
    Friend WithEvents UcAnteprima As Former.ucAnteprima
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents imlPuls As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents AggiungiListinoBaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AggiungiPreventivazioneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ApriCartellaAppuntiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SpostaListinoBaseInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImpostaOrdineLavorazioniToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripElimina As ToolStripMenuItem
    Friend WithEvents toolStripAggiungiCat As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents StampaRiassuntoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImpostaFormerChoiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CaricaListinoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FotoHDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AggiungiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GestisciToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificaDatiWebToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckCongruenzaDatiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ImgTemporaneeInUsoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminaListinoBaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MostraSoloNascostiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnPronteChiudi As Button
    Friend WithEvents btnPronteApri As Button
    Friend WithEvents CheckDifferenzeListinoToolStripMenuItem As ToolStripMenuItem
End Class
