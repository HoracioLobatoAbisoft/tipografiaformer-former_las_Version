<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMagazzinoMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMagazzinoMain))
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tpRisorse = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoRisorse = New Former.ucMagazzinoRisorse()
        Me.tpMovimenti = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoMgrMovimenti = New Former.ucMagazzinoMgrMovimenti()
        Me.tpMagazzino = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoStat = New Former.ucMagazzinoStatistiche()
        Me.UcMagazzinoStatistiche = New Former.ucMagazzinoStatistiche()
        Me.tpOrdiniAcquisto = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoOrdini = New Former.ucMagazzinoOrdini()
        Me.tpCarichiMagazzino = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoCarichiDiMagazzino = New Former.ucMagazzinoCarichiDiMagazzino()
        Me.tpDecodificaVoci = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoDecodificaVociCosto = New Former.ucMagazzinoDecodificaVociCosto()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.tabMain.SuspendLayout()
        Me.tpRisorse.SuspendLayout()
        Me.tpMovimenti.SuspendLayout()
        Me.tpMagazzino.SuspendLayout()
        Me.tpOrdiniAcquisto.SuspendLayout()
        Me.tpCarichiMagazzino.SuspendLayout()
        Me.tpDecodificaVoci.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tpRisorse)
        Me.tabMain.Controls.Add(Me.tpMovimenti)
        Me.tabMain.Controls.Add(Me.tpMagazzino)
        Me.tabMain.Controls.Add(Me.tpOrdiniAcquisto)
        Me.tabMain.Controls.Add(Me.tpCarichiMagazzino)
        Me.tabMain.Controls.Add(Me.tpDecodificaVoci)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.ImageList = Me.imlTab
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1229, 540)
        Me.tabMain.TabIndex = 0
        '
        'tpRisorse
        '
        Me.tpRisorse.Controls.Add(Me.UcMagazzinoRisorse)
        Me.tpRisorse.ImageIndex = 1
        Me.tpRisorse.Location = New System.Drawing.Point(4, 31)
        Me.tpRisorse.Name = "tpRisorse"
        Me.tpRisorse.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRisorse.Size = New System.Drawing.Size(1221, 505)
        Me.tpRisorse.TabIndex = 1
        Me.tpRisorse.Text = "Risorse"
        Me.tpRisorse.UseVisualStyleBackColor = True
        '
        'UcMagazzinoRisorse
        '
        Me.UcMagazzinoRisorse.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoRisorse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoRisorse.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoRisorse.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoRisorse.Name = "UcMagazzinoRisorse"
        Me.UcMagazzinoRisorse.Size = New System.Drawing.Size(1215, 499)
        Me.UcMagazzinoRisorse.TabIndex = 1
        '
        'tpMovimenti
        '
        Me.tpMovimenti.Controls.Add(Me.UcMagazzinoMgrMovimenti)
        Me.tpMovimenti.ImageIndex = 2
        Me.tpMovimenti.Location = New System.Drawing.Point(4, 31)
        Me.tpMovimenti.Name = "tpMovimenti"
        Me.tpMovimenti.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMovimenti.Size = New System.Drawing.Size(1221, 505)
        Me.tpMovimenti.TabIndex = 2
        Me.tpMovimenti.Text = "Movimenti"
        Me.tpMovimenti.UseVisualStyleBackColor = True
        '
        'UcMagazzinoMgrMovimenti
        '
        Me.UcMagazzinoMgrMovimenti.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoMgrMovimenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoMgrMovimenti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoMgrMovimenti.IdRis = 0
        Me.UcMagazzinoMgrMovimenti.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoMgrMovimenti.Name = "UcMagazzinoMgrMovimenti"
        Me.UcMagazzinoMgrMovimenti.OnlyMaterialeDiConsumo = False
        Me.UcMagazzinoMgrMovimenti.OnlyRichiesteAcquistoInCoda = False
        Me.UcMagazzinoMgrMovimenti.Size = New System.Drawing.Size(1215, 499)
        Me.UcMagazzinoMgrMovimenti.TabIndex = 0
        '
        'tpMagazzino
        '
        Me.tpMagazzino.Controls.Add(Me.UcMagazzinoStat)
        Me.tpMagazzino.Controls.Add(Me.UcMagazzinoStatistiche)
        Me.tpMagazzino.ImageIndex = 3
        Me.tpMagazzino.Location = New System.Drawing.Point(4, 31)
        Me.tpMagazzino.Name = "tpMagazzino"
        Me.tpMagazzino.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMagazzino.Size = New System.Drawing.Size(1221, 505)
        Me.tpMagazzino.TabIndex = 0
        Me.tpMagazzino.Text = "Riepilogo"
        Me.tpMagazzino.UseVisualStyleBackColor = True
        '
        'UcMagazzinoStat
        '
        Me.UcMagazzinoStat.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoStat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoStat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoStat.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoStat.Name = "UcMagazzinoStat"
        Me.UcMagazzinoStat.Size = New System.Drawing.Size(1215, 499)
        Me.UcMagazzinoStat.TabIndex = 1
        '
        'UcMagazzinoStatistiche
        '
        Me.UcMagazzinoStatistiche.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoStatistiche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoStatistiche.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoStatistiche.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoStatistiche.Name = "UcMagazzinoStatistiche"
        Me.UcMagazzinoStatistiche.Size = New System.Drawing.Size(1215, 499)
        Me.UcMagazzinoStatistiche.TabIndex = 0
        '
        'tpOrdiniAcquisto
        '
        Me.tpOrdiniAcquisto.Controls.Add(Me.UcMagazzinoOrdini)
        Me.tpOrdiniAcquisto.ImageIndex = 4
        Me.tpOrdiniAcquisto.Location = New System.Drawing.Point(4, 31)
        Me.tpOrdiniAcquisto.Name = "tpOrdiniAcquisto"
        Me.tpOrdiniAcquisto.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrdiniAcquisto.Size = New System.Drawing.Size(1221, 505)
        Me.tpOrdiniAcquisto.TabIndex = 3
        Me.tpOrdiniAcquisto.Text = "Ordini di Acquisto"
        Me.tpOrdiniAcquisto.UseVisualStyleBackColor = True
        '
        'UcMagazzinoOrdini
        '
        Me.UcMagazzinoOrdini.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoOrdini.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoOrdini.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoOrdini.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoOrdini.Name = "UcMagazzinoOrdini"
        Me.UcMagazzinoOrdini.Size = New System.Drawing.Size(1215, 499)
        Me.UcMagazzinoOrdini.TabIndex = 0
        '
        'tpCarichiMagazzino
        '
        Me.tpCarichiMagazzino.Controls.Add(Me.UcMagazzinoCarichiDiMagazzino)
        Me.tpCarichiMagazzino.ImageIndex = 5
        Me.tpCarichiMagazzino.Location = New System.Drawing.Point(4, 31)
        Me.tpCarichiMagazzino.Name = "tpCarichiMagazzino"
        Me.tpCarichiMagazzino.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCarichiMagazzino.Size = New System.Drawing.Size(1221, 505)
        Me.tpCarichiMagazzino.TabIndex = 4
        Me.tpCarichiMagazzino.Text = "Carichi DDT/Fatture in anticipo"
        Me.tpCarichiMagazzino.UseVisualStyleBackColor = True
        '
        'UcMagazzinoCarichiDiMagazzino
        '
        Me.UcMagazzinoCarichiDiMagazzino.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoCarichiDiMagazzino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoCarichiDiMagazzino.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoCarichiDiMagazzino.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoCarichiDiMagazzino.Name = "UcMagazzinoCarichiDiMagazzino"
        Me.UcMagazzinoCarichiDiMagazzino.Size = New System.Drawing.Size(1215, 499)
        Me.UcMagazzinoCarichiDiMagazzino.TabIndex = 0
        '
        'tpDecodificaVoci
        '
        Me.tpDecodificaVoci.Controls.Add(Me.UcMagazzinoDecodificaVociCosto)
        Me.tpDecodificaVoci.ImageIndex = 6
        Me.tpDecodificaVoci.Location = New System.Drawing.Point(4, 31)
        Me.tpDecodificaVoci.Name = "tpDecodificaVoci"
        Me.tpDecodificaVoci.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDecodificaVoci.Size = New System.Drawing.Size(1221, 505)
        Me.tpDecodificaVoci.TabIndex = 5
        Me.tpDecodificaVoci.Text = "Decodifica Voci Costo"
        Me.tpDecodificaVoci.UseVisualStyleBackColor = True
        '
        'UcMagazzinoDecodificaVociCosto
        '
        Me.UcMagazzinoDecodificaVociCosto.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoDecodificaVociCosto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoDecodificaVociCosto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoDecodificaVociCosto.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoDecodificaVociCosto.Name = "UcMagazzinoDecodificaVociCosto"
        Me.UcMagazzinoDecodificaVociCosto.Size = New System.Drawing.Size(1215, 499)
        Me.UcMagazzinoDecodificaVociCosto.TabIndex = 0
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "_Magazzino.png")
        Me.imlTab.Images.SetKeyName(1, "_Risorsa.png")
        Me.imlTab.Images.SetKeyName(2, "_RisorsaAdd.png")
        Me.imlTab.Images.SetKeyName(3, "_Cerca.png")
        Me.imlTab.Images.SetKeyName(4, "_OrdineAcquisto.png")
        Me.imlTab.Images.SetKeyName(5, "_CaricoDiMagazzino.png")
        Me.imlTab.Images.SetKeyName(6, "_DecodificaVociCosto.png")
        '
        'ucMagazzinoMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tabMain)
        Me.Name = "ucMagazzinoMain"
        Me.Size = New System.Drawing.Size(1229, 540)
        Me.tabMain.ResumeLayout(False)
        Me.tpRisorse.ResumeLayout(False)
        Me.tpMovimenti.ResumeLayout(False)
        Me.tpMagazzino.ResumeLayout(False)
        Me.tpOrdiniAcquisto.ResumeLayout(False)
        Me.tpCarichiMagazzino.ResumeLayout(False)
        Me.tpDecodificaVoci.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabMain As TabControl
    Friend WithEvents tpMagazzino As TabPage
    Friend WithEvents tpRisorse As TabPage
    Friend WithEvents imlTab As ImageList
    Friend WithEvents UcMagazzinoRisorse As ucMagazzinoRisorse
    Friend WithEvents UcMagazzinoStatistiche As ucMagazzinoStatistiche
    Friend WithEvents UcMagazzinoStat As ucMagazzinoStatistiche
    Friend WithEvents tpMovimenti As TabPage
    Friend WithEvents UcMagazzinoMgrMovimenti As ucMagazzinoMgrMovimenti
    Friend WithEvents tpOrdiniAcquisto As TabPage
    Friend WithEvents UcMagazzinoOrdini As ucMagazzinoOrdini
    Friend WithEvents tpCarichiMagazzino As TabPage
    Friend WithEvents UcMagazzinoCarichiDiMagazzino As ucMagazzinoCarichiDiMagazzino
    Friend WithEvents tpDecodificaVoci As TabPage
    Friend WithEvents UcMagazzinoDecodificaVociCosto As ucMagazzinoDecodificaVociCosto
End Class
