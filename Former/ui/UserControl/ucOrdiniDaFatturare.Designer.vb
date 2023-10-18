<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrdiniDaFatturare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucOrdiniDaFatturare))
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tpOrdiniDaFatturare = New System.Windows.Forms.TabPage()
        Me.UcAmministrazioneConsegne = New Former.ucAmministrazioneConsegne()
        Me.tpOrdiniDaSpedire = New System.Windows.Forms.TabPage()
        Me.chkSoloRegistratiCorriere = New System.Windows.Forms.CheckBox()
        Me.btnRiapriCons = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoInConsegna = New System.Windows.Forms.RadioButton()
        Me.rdoGiaImballati = New System.Windows.Forms.RadioButton()
        Me.rdoDaImballare = New System.Windows.Forms.RadioButton()
        Me.btnEmettiDocMerceSpedire = New System.Windows.Forms.Button()
        Me.btnAggiornaMerceSpedire = New System.Windows.Forms.Button()
        Me.tvMerceDaSpedire = New System.Windows.Forms.TreeView()
        Me.imlMerceUscita = New System.Windows.Forms.ImageList(Me.components)
        Me.tpOrdiniUscitoMagazzino = New System.Windows.Forms.TabPage()
        Me.UcOrdiniAnteprimaFatt = New Former.ucOrdiniAnteprima()
        Me.chkLastWeek = New System.Windows.Forms.CheckBox()
        Me.btnDocFisc = New System.Windows.Forms.Button()
        Me.btnRefresh4 = New System.Windows.Forms.Button()
        Me.tvMerceUscita = New System.Windows.Forms.TreeView()
        Me.tpConsegne = New System.Windows.Forms.TabPage()
        Me.UcConsegneSettimana = New Former.ucConsegneSettimana()
        Me.imlMain = New System.Windows.Forms.ImageList(Me.components)
        Me.TabMain.SuspendLayout()
        Me.tpOrdiniDaFatturare.SuspendLayout()
        Me.tpOrdiniDaSpedire.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tpOrdiniUscitoMagazzino.SuspendLayout()
        Me.tpConsegne.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tpOrdiniDaFatturare)
        Me.TabMain.Controls.Add(Me.tpOrdiniDaSpedire)
        Me.TabMain.Controls.Add(Me.tpOrdiniUscitoMagazzino)
        Me.TabMain.Controls.Add(Me.tpConsegne)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ImageList = Me.imlMain
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1128, 674)
        Me.TabMain.TabIndex = 1
        '
        'tpOrdiniDaFatturare
        '
        Me.tpOrdiniDaFatturare.Controls.Add(Me.UcAmministrazioneConsegne)
        Me.tpOrdiniDaFatturare.ImageKey = "_DocumentoFiscale.png"
        Me.tpOrdiniDaFatturare.Location = New System.Drawing.Point(4, 31)
        Me.tpOrdiniDaFatturare.Name = "tpOrdiniDaFatturare"
        Me.tpOrdiniDaFatturare.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrdiniDaFatturare.Size = New System.Drawing.Size(1120, 639)
        Me.tpOrdiniDaFatturare.TabIndex = 0
        Me.tpOrdiniDaFatturare.Text = "Ordini da Fatturare"
        Me.tpOrdiniDaFatturare.UseVisualStyleBackColor = True
        '
        'UcAmministrazioneConsegne
        '
        Me.UcAmministrazioneConsegne.BackColor = System.Drawing.Color.White
        Me.UcAmministrazioneConsegne.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazioneConsegne.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazioneConsegne.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazioneConsegne.Name = "UcAmministrazioneConsegne"
        Me.UcAmministrazioneConsegne.Size = New System.Drawing.Size(1114, 633)
        Me.UcAmministrazioneConsegne.TabIndex = 0
        '
        'tpOrdiniDaSpedire
        '
        Me.tpOrdiniDaSpedire.Controls.Add(Me.chkSoloRegistratiCorriere)
        Me.tpOrdiniDaSpedire.Controls.Add(Me.btnRiapriCons)
        Me.tpOrdiniDaSpedire.Controls.Add(Me.Panel1)
        Me.tpOrdiniDaSpedire.Controls.Add(Me.btnEmettiDocMerceSpedire)
        Me.tpOrdiniDaSpedire.Controls.Add(Me.btnAggiornaMerceSpedire)
        Me.tpOrdiniDaSpedire.Controls.Add(Me.tvMerceDaSpedire)
        Me.tpOrdiniDaSpedire.ImageKey = "_GLS.png"
        Me.tpOrdiniDaSpedire.Location = New System.Drawing.Point(4, 31)
        Me.tpOrdiniDaSpedire.Name = "tpOrdiniDaSpedire"
        Me.tpOrdiniDaSpedire.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrdiniDaSpedire.Size = New System.Drawing.Size(1120, 639)
        Me.tpOrdiniDaSpedire.TabIndex = 2
        Me.tpOrdiniDaSpedire.Text = "Ordini da spedire con Corriere"
        Me.tpOrdiniDaSpedire.UseVisualStyleBackColor = True
        '
        'chkSoloRegistratiCorriere
        '
        Me.chkSoloRegistratiCorriere.AutoSize = True
        Me.chkSoloRegistratiCorriere.Checked = True
        Me.chkSoloRegistratiCorriere.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSoloRegistratiCorriere.Location = New System.Drawing.Point(413, 29)
        Me.chkSoloRegistratiCorriere.Name = "chkSoloRegistratiCorriere"
        Me.chkSoloRegistratiCorriere.Size = New System.Drawing.Size(146, 19)
        Me.chkSoloRegistratiCorriere.TabIndex = 134
        Me.chkSoloRegistratiCorriere.Text = "Solo Registrati Corriere"
        Me.chkSoloRegistratiCorriere.UseVisualStyleBackColor = True
        '
        'btnRiapriCons
        '
        Me.btnRiapriCons.BackColor = System.Drawing.Color.White
        Me.btnRiapriCons.Image = CType(resources.GetObject("btnRiapriCons.Image"), System.Drawing.Image)
        Me.btnRiapriCons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRiapriCons.Location = New System.Drawing.Point(163, 6)
        Me.btnRiapriCons.Name = "btnRiapriCons"
        Me.btnRiapriCons.Size = New System.Drawing.Size(196, 42)
        Me.btnRiapriCons.TabIndex = 122
        Me.btnRiapriCons.Text = "Riapri Cons. Programmata"
        Me.btnRiapriCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRiapriCons.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoInConsegna)
        Me.Panel1.Controls.Add(Me.rdoGiaImballati)
        Me.Panel1.Controls.Add(Me.rdoDaImballare)
        Me.Panel1.Location = New System.Drawing.Point(413, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(310, 21)
        Me.Panel1.TabIndex = 121
        '
        'rdoInConsegna
        '
        Me.rdoInConsegna.AutoSize = True
        Me.rdoInConsegna.Location = New System.Drawing.Point(202, 0)
        Me.rdoInConsegna.Name = "rdoInConsegna"
        Me.rdoInConsegna.Size = New System.Drawing.Size(91, 19)
        Me.rdoInConsegna.TabIndex = 116
        Me.rdoInConsegna.Text = "In Consegna"
        Me.rdoInConsegna.UseVisualStyleBackColor = True
        '
        'rdoGiaImballati
        '
        Me.rdoGiaImballati.AutoSize = True
        Me.rdoGiaImballati.Checked = True
        Me.rdoGiaImballati.Location = New System.Drawing.Point(102, 0)
        Me.rdoGiaImballati.Name = "rdoGiaImballati"
        Me.rdoGiaImballati.Size = New System.Drawing.Size(91, 19)
        Me.rdoGiaImballati.TabIndex = 115
        Me.rdoGiaImballati.TabStop = True
        Me.rdoGiaImballati.Text = "Già Imballati"
        Me.rdoGiaImballati.UseVisualStyleBackColor = True
        '
        'rdoDaImballare
        '
        Me.rdoDaImballare.AutoSize = True
        Me.rdoDaImballare.Location = New System.Drawing.Point(0, 0)
        Me.rdoDaImballare.Name = "rdoDaImballare"
        Me.rdoDaImballare.Size = New System.Drawing.Size(91, 19)
        Me.rdoDaImballare.TabIndex = 114
        Me.rdoDaImballare.Text = "Da imballare"
        Me.rdoDaImballare.UseVisualStyleBackColor = True
        '
        'btnEmettiDocMerceSpedire
        '
        Me.btnEmettiDocMerceSpedire.BackColor = System.Drawing.Color.White
        Me.btnEmettiDocMerceSpedire.Image = CType(resources.GetObject("btnEmettiDocMerceSpedire.Image"), System.Drawing.Image)
        Me.btnEmettiDocMerceSpedire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmettiDocMerceSpedire.Location = New System.Drawing.Point(6, 6)
        Me.btnEmettiDocMerceSpedire.Name = "btnEmettiDocMerceSpedire"
        Me.btnEmettiDocMerceSpedire.Size = New System.Drawing.Size(151, 42)
        Me.btnEmettiDocMerceSpedire.TabIndex = 120
        Me.btnEmettiDocMerceSpedire.Text = "Emetti Doc. Fiscale"
        Me.btnEmettiDocMerceSpedire.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEmettiDocMerceSpedire.UseVisualStyleBackColor = False
        '
        'btnAggiornaMerceSpedire
        '
        Me.btnAggiornaMerceSpedire.BackColor = System.Drawing.Color.White
        Me.btnAggiornaMerceSpedire.FlatAppearance.BorderSize = 0
        Me.btnAggiornaMerceSpedire.Image = CType(resources.GetObject("btnAggiornaMerceSpedire.Image"), System.Drawing.Image)
        Me.btnAggiornaMerceSpedire.Location = New System.Drawing.Point(365, 6)
        Me.btnAggiornaMerceSpedire.Name = "btnAggiornaMerceSpedire"
        Me.btnAggiornaMerceSpedire.Size = New System.Drawing.Size(42, 42)
        Me.btnAggiornaMerceSpedire.TabIndex = 119
        Me.btnAggiornaMerceSpedire.UseVisualStyleBackColor = False
        '
        'tvMerceDaSpedire
        '
        Me.tvMerceDaSpedire.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvMerceDaSpedire.ImageIndex = 0
        Me.tvMerceDaSpedire.ImageList = Me.imlMerceUscita
        Me.tvMerceDaSpedire.Indent = 15
        Me.tvMerceDaSpedire.Location = New System.Drawing.Point(3, 54)
        Me.tvMerceDaSpedire.Name = "tvMerceDaSpedire"
        Me.tvMerceDaSpedire.SelectedImageIndex = 0
        Me.tvMerceDaSpedire.Size = New System.Drawing.Size(1114, 582)
        Me.tvMerceDaSpedire.TabIndex = 118
        '
        'imlMerceUscita
        '
        Me.imlMerceUscita.ImageStream = CType(resources.GetObject("imlMerceUscita.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMerceUscita.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMerceUscita.Images.SetKeyName(0, "_user.png")
        Me.imlMerceUscita.Images.SetKeyName(1, "_Ordine.png")
        Me.imlMerceUscita.Images.SetKeyName(2, "icoPrint.jpg")
        Me.imlMerceUscita.Images.SetKeyName(3, "icoMoney.jpg")
        Me.imlMerceUscita.Images.SetKeyName(4, "icoRubRed.jpg")
        Me.imlMerceUscita.Images.SetKeyName(5, "icoParamRed.jpg")
        Me.imlMerceUscita.Images.SetKeyName(6, "_Corriere.png")
        Me.imlMerceUscita.Images.SetKeyName(7, "_Calendario.png")
        Me.imlMerceUscita.Images.SetKeyName(8, "IcoFast.png")
        Me.imlMerceUscita.Images.SetKeyName(9, "IcoLow.png")
        Me.imlMerceUscita.Images.SetKeyName(10, "_Consegna.png")
        '
        'tpOrdiniUscitoMagazzino
        '
        Me.tpOrdiniUscitoMagazzino.Controls.Add(Me.UcOrdiniAnteprimaFatt)
        Me.tpOrdiniUscitoMagazzino.Controls.Add(Me.chkLastWeek)
        Me.tpOrdiniUscitoMagazzino.Controls.Add(Me.btnDocFisc)
        Me.tpOrdiniUscitoMagazzino.Controls.Add(Me.btnRefresh4)
        Me.tpOrdiniUscitoMagazzino.Controls.Add(Me.tvMerceUscita)
        Me.tpOrdiniUscitoMagazzino.ImageKey = "icoStatoUscitoMagazzino.jpg"
        Me.tpOrdiniUscitoMagazzino.Location = New System.Drawing.Point(4, 31)
        Me.tpOrdiniUscitoMagazzino.Name = "tpOrdiniUscitoMagazzino"
        Me.tpOrdiniUscitoMagazzino.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrdiniUscitoMagazzino.Size = New System.Drawing.Size(1120, 639)
        Me.tpOrdiniUscitoMagazzino.TabIndex = 1
        Me.tpOrdiniUscitoMagazzino.Text = "Ordini ""Uscito da Magazzino"" da fatturare"
        Me.tpOrdiniUscitoMagazzino.UseVisualStyleBackColor = True
        '
        'UcOrdiniAnteprimaFatt
        '
        Me.UcOrdiniAnteprimaFatt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcOrdiniAnteprimaFatt.BackColor = System.Drawing.Color.White
        Me.UcOrdiniAnteprimaFatt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdiniAnteprimaFatt.Location = New System.Drawing.Point(727, 6)
        Me.UcOrdiniAnteprimaFatt.Name = "UcOrdiniAnteprimaFatt"
        Me.UcOrdiniAnteprimaFatt.NascondiResto = False
        Me.UcOrdiniAnteprimaFatt.NoLavori = False
        Me.UcOrdiniAnteprimaFatt.Size = New System.Drawing.Size(387, 627)
        Me.UcOrdiniAnteprimaFatt.TabIndex = 116
        '
        'chkLastWeek
        '
        Me.chkLastWeek.AutoSize = True
        Me.chkLastWeek.Location = New System.Drawing.Point(211, 19)
        Me.chkLastWeek.Name = "chkLastWeek"
        Me.chkLastWeek.Size = New System.Drawing.Size(180, 19)
        Me.chkLastWeek.TabIndex = 115
        Me.chkLastWeek.Text = "Mostra solo ultima settimana"
        Me.chkLastWeek.UseVisualStyleBackColor = True
        '
        'btnDocFisc
        '
        Me.btnDocFisc.BackColor = System.Drawing.Color.White
        Me.btnDocFisc.Image = CType(resources.GetObject("btnDocFisc.Image"), System.Drawing.Image)
        Me.btnDocFisc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDocFisc.Location = New System.Drawing.Point(6, 6)
        Me.btnDocFisc.Name = "btnDocFisc"
        Me.btnDocFisc.Size = New System.Drawing.Size(151, 42)
        Me.btnDocFisc.TabIndex = 114
        Me.btnDocFisc.Text = "Emetti Doc. Fiscale"
        Me.btnDocFisc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDocFisc.UseVisualStyleBackColor = False
        '
        'btnRefresh4
        '
        Me.btnRefresh4.BackColor = System.Drawing.Color.White
        Me.btnRefresh4.FlatAppearance.BorderSize = 0
        Me.btnRefresh4.Image = CType(resources.GetObject("btnRefresh4.Image"), System.Drawing.Image)
        Me.btnRefresh4.Location = New System.Drawing.Point(163, 6)
        Me.btnRefresh4.Name = "btnRefresh4"
        Me.btnRefresh4.Size = New System.Drawing.Size(42, 42)
        Me.btnRefresh4.TabIndex = 113
        Me.btnRefresh4.UseVisualStyleBackColor = False
        '
        'tvMerceUscita
        '
        Me.tvMerceUscita.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvMerceUscita.ImageIndex = 0
        Me.tvMerceUscita.ImageList = Me.imlMerceUscita
        Me.tvMerceUscita.Indent = 15
        Me.tvMerceUscita.Location = New System.Drawing.Point(3, 54)
        Me.tvMerceUscita.Name = "tvMerceUscita"
        Me.tvMerceUscita.SelectedImageIndex = 0
        Me.tvMerceUscita.Size = New System.Drawing.Size(718, 579)
        Me.tvMerceUscita.TabIndex = 112
        '
        'tpConsegne
        '
        Me.tpConsegne.Controls.Add(Me.UcConsegneSettimana)
        Me.tpConsegne.ImageKey = "_Consegna.png"
        Me.tpConsegne.Location = New System.Drawing.Point(4, 31)
        Me.tpConsegne.Name = "tpConsegne"
        Me.tpConsegne.Padding = New System.Windows.Forms.Padding(3)
        Me.tpConsegne.Size = New System.Drawing.Size(1120, 639)
        Me.tpConsegne.TabIndex = 3
        Me.tpConsegne.Text = "Amministrazione Consegne"
        Me.tpConsegne.UseVisualStyleBackColor = True
        '
        'UcConsegneSettimana
        '
        Me.UcConsegneSettimana.BackColor = System.Drawing.Color.White
        Me.UcConsegneSettimana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConsegneSettimana.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcConsegneSettimana.Location = New System.Drawing.Point(3, 3)
        Me.UcConsegneSettimana.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcConsegneSettimana.Name = "UcConsegneSettimana"
        Me.UcConsegneSettimana.Size = New System.Drawing.Size(1114, 633)
        Me.UcConsegneSettimana.TabIndex = 0
        '
        'imlMain
        '
        Me.imlMain.ImageStream = CType(resources.GetObject("imlMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMain.Images.SetKeyName(0, "_DocumentoFiscale.png")
        Me.imlMain.Images.SetKeyName(1, "_GLS.png")
        Me.imlMain.Images.SetKeyName(2, "_Consegna.png")
        Me.imlMain.Images.SetKeyName(3, "icoStatoUscitoMagazzino.jpg")
        '
        'ucOrdiniDaFatturare
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TabMain)
        Me.Name = "ucOrdiniDaFatturare"
        Me.Size = New System.Drawing.Size(1128, 674)
        Me.TabMain.ResumeLayout(False)
        Me.tpOrdiniDaFatturare.ResumeLayout(False)
        Me.tpOrdiniDaSpedire.ResumeLayout(False)
        Me.tpOrdiniDaSpedire.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tpOrdiniUscitoMagazzino.ResumeLayout(False)
        Me.tpOrdiniUscitoMagazzino.PerformLayout()
        Me.tpConsegne.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcAmministrazioneConsegne As Former.ucAmministrazioneConsegne
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tpOrdiniDaFatturare As System.Windows.Forms.TabPage
    Friend WithEvents tpOrdiniUscitoMagazzino As System.Windows.Forms.TabPage
    Friend WithEvents tpOrdiniDaSpedire As System.Windows.Forms.TabPage
    Friend WithEvents chkLastWeek As System.Windows.Forms.CheckBox
    Friend WithEvents btnDocFisc As System.Windows.Forms.Button
    Friend WithEvents btnRefresh4 As System.Windows.Forms.Button
    Friend WithEvents tvMerceUscita As System.Windows.Forms.TreeView
    Friend WithEvents imlMerceUscita As System.Windows.Forms.ImageList
    Friend WithEvents btnRiapriCons As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoGiaImballati As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDaImballare As System.Windows.Forms.RadioButton
    Friend WithEvents btnEmettiDocMerceSpedire As System.Windows.Forms.Button
    Friend WithEvents btnAggiornaMerceSpedire As System.Windows.Forms.Button
    Friend WithEvents tvMerceDaSpedire As System.Windows.Forms.TreeView
    Friend WithEvents chkSoloRegistratiCorriere As System.Windows.Forms.CheckBox
    Friend WithEvents rdoInConsegna As System.Windows.Forms.RadioButton
    Friend WithEvents tpConsegne As TabPage
    Friend WithEvents UcConsegneSettimana As ucConsegneSettimana
    Friend WithEvents imlMain As ImageList
    Friend WithEvents UcOrdiniAnteprimaFatt As ucOrdiniAnteprima
End Class
