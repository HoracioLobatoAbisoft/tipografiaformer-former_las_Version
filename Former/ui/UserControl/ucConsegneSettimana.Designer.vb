<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConsegneSettimana
    Inherits ucFormerUserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucConsegneSettimana))
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.tabOrdini = New System.Windows.Forms.TabControl()
        Me.tpProgrammate = New System.Windows.Forms.TabPage()
        Me.UcAlberoConsegneProgrammate = New Former.ucConsegneAlbero()
        Me.tpPreviste = New System.Windows.Forms.TabPage()
        Me.UcAlberoConsegnePreviste = New Former.ucConsegneAlbero()
        Me.tbGestione = New System.Windows.Forms.TabControl()
        Me.tpQuadroConsegne = New System.Windows.Forms.TabPage()
        Me.TableMain = New System.Windows.Forms.TableLayoutPanel()
        Me.UcConsegneGiornoLunedi = New Former.ucConsegneGiorno()
        Me.UcConsegneGiornoMartedi = New Former.ucConsegneGiorno()
        Me.UcConsegneGiornoMercoledi = New Former.ucConsegneGiorno()
        Me.UcConsegneGiornoGiovedi = New Former.ucConsegneGiorno()
        Me.UcConsegneGiornoVenerdi = New Former.ucConsegneGiorno()
        Me.UcConsegneGiornoSabato = New Former.ucConsegneGiorno()
        Me.chkCorrRegistratiInConsegna = New System.Windows.Forms.CheckBox()
        Me.btnIndietro = New System.Windows.Forms.Button()
        Me.chkCorrRegistratiProntiConsegna = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbGiorni = New System.Windows.Forms.ComboBox()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.dtPickCons = New System.Windows.Forms.DateTimePicker()
        Me.cmbOperatore = New System.Windows.Forms.ComboBox()
        Me.UcStatoOrdiniAdvanced = New Former.ucOrdiniStatoAdvanced()
        Me.btnAvanti = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.cmbCorriere = New System.Windows.Forms.ComboBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnComprimi = New System.Windows.Forms.Button()
        Me.btnEspandi = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpConsegneGls = New System.Windows.Forms.TabPage()
        Me.UcConsegneGlsAdmin = New Former.ucConsegneGlsAdmin()
        Me.imlMain = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.tabOrdini.SuspendLayout()
        Me.tpProgrammate.SuspendLayout()
        Me.tpPreviste.SuspendLayout()
        Me.tbGestione.SuspendLayout()
        Me.tpQuadroConsegne.SuspendLayout()
        Me.TableMain.SuspendLayout()
        Me.tpConsegneGls.SuspendLayout()
        Me.SuspendLayout()
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
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.tabOrdini)
        Me.SplitContainer.Panel1MinSize = 100
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.tbGestione)
        Me.SplitContainer.Panel2MinSize = 100
        Me.SplitContainer.Size = New System.Drawing.Size(1265, 729)
        Me.SplitContainer.SplitterDistance = 194
        Me.SplitContainer.TabIndex = 80
        '
        'tabOrdini
        '
        Me.tabOrdini.Controls.Add(Me.tpProgrammate)
        Me.tabOrdini.Controls.Add(Me.tpPreviste)
        Me.tabOrdini.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabOrdini.ItemSize = New System.Drawing.Size(70, 20)
        Me.tabOrdini.Location = New System.Drawing.Point(0, 0)
        Me.tabOrdini.Name = "tabOrdini"
        Me.tabOrdini.SelectedIndex = 0
        Me.tabOrdini.Size = New System.Drawing.Size(194, 729)
        Me.tabOrdini.TabIndex = 79
        '
        'tpProgrammate
        '
        Me.tpProgrammate.Controls.Add(Me.UcAlberoConsegneProgrammate)
        Me.tpProgrammate.Location = New System.Drawing.Point(4, 24)
        Me.tpProgrammate.Name = "tpProgrammate"
        Me.tpProgrammate.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProgrammate.Size = New System.Drawing.Size(186, 701)
        Me.tpProgrammate.TabIndex = 0
        Me.tpProgrammate.Text = "Consegne"
        Me.tpProgrammate.UseVisualStyleBackColor = True
        '
        'UcAlberoConsegneProgrammate
        '
        Me.UcAlberoConsegneProgrammate.BackColor = System.Drawing.Color.White
        Me.UcAlberoConsegneProgrammate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAlberoConsegneProgrammate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAlberoConsegneProgrammate.Location = New System.Drawing.Point(3, 3)
        Me.UcAlberoConsegneProgrammate.Name = "UcAlberoConsegneProgrammate"
        Me.UcAlberoConsegneProgrammate.Size = New System.Drawing.Size(180, 695)
        Me.UcAlberoConsegneProgrammate.TabIndex = 0
        Me.UcAlberoConsegneProgrammate.TestoSelezionato = Nothing
        '
        'tpPreviste
        '
        Me.tpPreviste.Controls.Add(Me.UcAlberoConsegnePreviste)
        Me.tpPreviste.Location = New System.Drawing.Point(4, 24)
        Me.tpPreviste.Name = "tpPreviste"
        Me.tpPreviste.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPreviste.Size = New System.Drawing.Size(186, 701)
        Me.tpPreviste.TabIndex = 1
        Me.tpPreviste.Text = "Da programmare"
        Me.tpPreviste.UseVisualStyleBackColor = True
        '
        'UcAlberoConsegnePreviste
        '
        Me.UcAlberoConsegnePreviste.BackColor = System.Drawing.Color.White
        Me.UcAlberoConsegnePreviste.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAlberoConsegnePreviste.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAlberoConsegnePreviste.Location = New System.Drawing.Point(3, 3)
        Me.UcAlberoConsegnePreviste.Name = "UcAlberoConsegnePreviste"
        Me.UcAlberoConsegnePreviste.Size = New System.Drawing.Size(180, 695)
        Me.UcAlberoConsegnePreviste.TabIndex = 0
        Me.UcAlberoConsegnePreviste.TestoSelezionato = Nothing
        '
        'tbGestione
        '
        Me.tbGestione.Controls.Add(Me.tpQuadroConsegne)
        Me.tbGestione.Controls.Add(Me.tpConsegneGls)
        Me.tbGestione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbGestione.ImageList = Me.imlMain
        Me.tbGestione.ItemSize = New System.Drawing.Size(114, 20)
        Me.tbGestione.Location = New System.Drawing.Point(0, 0)
        Me.tbGestione.Name = "tbGestione"
        Me.tbGestione.SelectedIndex = 0
        Me.tbGestione.Size = New System.Drawing.Size(1067, 729)
        Me.tbGestione.TabIndex = 77
        '
        'tpQuadroConsegne
        '
        Me.tpQuadroConsegne.Controls.Add(Me.TableMain)
        Me.tpQuadroConsegne.Controls.Add(Me.chkCorrRegistratiInConsegna)
        Me.tpQuadroConsegne.Controls.Add(Me.btnIndietro)
        Me.tpQuadroConsegne.Controls.Add(Me.chkCorrRegistratiProntiConsegna)
        Me.tpQuadroConsegne.Controls.Add(Me.Label4)
        Me.tpQuadroConsegne.Controls.Add(Me.cmbGiorni)
        Me.tpQuadroConsegne.Controls.Add(Me.cmbZona)
        Me.tpQuadroConsegne.Controls.Add(Me.dtPickCons)
        Me.tpQuadroConsegne.Controls.Add(Me.cmbOperatore)
        Me.tpQuadroConsegne.Controls.Add(Me.UcStatoOrdiniAdvanced)
        Me.tpQuadroConsegne.Controls.Add(Me.btnAvanti)
        Me.tpQuadroConsegne.Controls.Add(Me.Label2)
        Me.tpQuadroConsegne.Controls.Add(Me.btnAggiorna)
        Me.tpQuadroConsegne.Controls.Add(Me.cmbCorriere)
        Me.tpQuadroConsegne.Controls.Add(Me.cmbCliente)
        Me.tpQuadroConsegne.Controls.Add(Me.Label3)
        Me.tpQuadroConsegne.Controls.Add(Me.btnComprimi)
        Me.tpQuadroConsegne.Controls.Add(Me.btnEspandi)
        Me.tpQuadroConsegne.Controls.Add(Me.Label1)
        Me.tpQuadroConsegne.ImageIndex = 2
        Me.tpQuadroConsegne.Location = New System.Drawing.Point(4, 24)
        Me.tpQuadroConsegne.Name = "tpQuadroConsegne"
        Me.tpQuadroConsegne.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQuadroConsegne.Size = New System.Drawing.Size(1059, 701)
        Me.tpQuadroConsegne.TabIndex = 0
        Me.tpQuadroConsegne.Text = "Quadro Consegne"
        Me.tpQuadroConsegne.UseVisualStyleBackColor = True
        '
        'TableMain
        '
        Me.TableMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableMain.ColumnCount = 6
        Me.TableMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.TableMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.TableMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.TableMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.TableMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0!))
        Me.TableMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableMain.Controls.Add(Me.UcConsegneGiornoLunedi, 0, 0)
        Me.TableMain.Controls.Add(Me.UcConsegneGiornoMartedi, 1, 0)
        Me.TableMain.Controls.Add(Me.UcConsegneGiornoMercoledi, 2, 0)
        Me.TableMain.Controls.Add(Me.UcConsegneGiornoGiovedi, 3, 0)
        Me.TableMain.Controls.Add(Me.UcConsegneGiornoVenerdi, 4, 0)
        Me.TableMain.Controls.Add(Me.UcConsegneGiornoSabato, 5, 0)
        Me.TableMain.Location = New System.Drawing.Point(6, 104)
        Me.TableMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableMain.Name = "TableMain"
        Me.TableMain.RowCount = 1
        Me.TableMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableMain.Size = New System.Drawing.Size(1047, 590)
        Me.TableMain.TabIndex = 8
        '
        'UcConsegneGiornoLunedi
        '
        Me.UcConsegneGiornoLunedi.BackColor = System.Drawing.Color.White
        Me.UcConsegneGiornoLunedi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcConsegneGiornoLunedi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConsegneGiornoLunedi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcConsegneGiornoLunedi.ForeColor = System.Drawing.Color.Black
        Me.UcConsegneGiornoLunedi.IdCorr = 0
        Me.UcConsegneGiornoLunedi.IdOrdSel = 0
        Me.UcConsegneGiornoLunedi.IsOperatore = False
        Me.UcConsegneGiornoLunedi.Location = New System.Drawing.Point(3, 4)
        Me.UcConsegneGiornoLunedi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcConsegneGiornoLunedi.Name = "UcConsegneGiornoLunedi"
        Me.UcConsegneGiornoLunedi.Operatore = False
        Me.UcConsegneGiornoLunedi.Size = New System.Drawing.Size(171, 582)
        Me.UcConsegneGiornoLunedi.TabIndex = 0
        Me.UcConsegneGiornoLunedi.TestoSelezionato = Nothing
        '
        'UcConsegneGiornoMartedi
        '
        Me.UcConsegneGiornoMartedi.BackColor = System.Drawing.Color.White
        Me.UcConsegneGiornoMartedi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcConsegneGiornoMartedi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConsegneGiornoMartedi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcConsegneGiornoMartedi.ForeColor = System.Drawing.Color.Black
        Me.UcConsegneGiornoMartedi.IdCorr = 0
        Me.UcConsegneGiornoMartedi.IdOrdSel = 0
        Me.UcConsegneGiornoMartedi.IsOperatore = False
        Me.UcConsegneGiornoMartedi.Location = New System.Drawing.Point(180, 4)
        Me.UcConsegneGiornoMartedi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcConsegneGiornoMartedi.Name = "UcConsegneGiornoMartedi"
        Me.UcConsegneGiornoMartedi.Operatore = False
        Me.UcConsegneGiornoMartedi.Size = New System.Drawing.Size(171, 582)
        Me.UcConsegneGiornoMartedi.TabIndex = 1
        Me.UcConsegneGiornoMartedi.TestoSelezionato = Nothing
        '
        'UcConsegneGiornoMercoledi
        '
        Me.UcConsegneGiornoMercoledi.BackColor = System.Drawing.Color.White
        Me.UcConsegneGiornoMercoledi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcConsegneGiornoMercoledi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConsegneGiornoMercoledi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcConsegneGiornoMercoledi.ForeColor = System.Drawing.Color.Black
        Me.UcConsegneGiornoMercoledi.IdCorr = 0
        Me.UcConsegneGiornoMercoledi.IdOrdSel = 0
        Me.UcConsegneGiornoMercoledi.IsOperatore = False
        Me.UcConsegneGiornoMercoledi.Location = New System.Drawing.Point(357, 4)
        Me.UcConsegneGiornoMercoledi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcConsegneGiornoMercoledi.Name = "UcConsegneGiornoMercoledi"
        Me.UcConsegneGiornoMercoledi.Operatore = False
        Me.UcConsegneGiornoMercoledi.Size = New System.Drawing.Size(171, 582)
        Me.UcConsegneGiornoMercoledi.TabIndex = 2
        Me.UcConsegneGiornoMercoledi.TestoSelezionato = Nothing
        '
        'UcConsegneGiornoGiovedi
        '
        Me.UcConsegneGiornoGiovedi.BackColor = System.Drawing.Color.White
        Me.UcConsegneGiornoGiovedi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcConsegneGiornoGiovedi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConsegneGiornoGiovedi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcConsegneGiornoGiovedi.ForeColor = System.Drawing.Color.Black
        Me.UcConsegneGiornoGiovedi.IdCorr = 0
        Me.UcConsegneGiornoGiovedi.IdOrdSel = 0
        Me.UcConsegneGiornoGiovedi.IsOperatore = False
        Me.UcConsegneGiornoGiovedi.Location = New System.Drawing.Point(534, 4)
        Me.UcConsegneGiornoGiovedi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcConsegneGiornoGiovedi.Name = "UcConsegneGiornoGiovedi"
        Me.UcConsegneGiornoGiovedi.Operatore = False
        Me.UcConsegneGiornoGiovedi.Size = New System.Drawing.Size(171, 582)
        Me.UcConsegneGiornoGiovedi.TabIndex = 3
        Me.UcConsegneGiornoGiovedi.TestoSelezionato = Nothing
        '
        'UcConsegneGiornoVenerdi
        '
        Me.UcConsegneGiornoVenerdi.BackColor = System.Drawing.Color.White
        Me.UcConsegneGiornoVenerdi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcConsegneGiornoVenerdi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConsegneGiornoVenerdi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcConsegneGiornoVenerdi.ForeColor = System.Drawing.Color.Black
        Me.UcConsegneGiornoVenerdi.IdCorr = 0
        Me.UcConsegneGiornoVenerdi.IdOrdSel = 0
        Me.UcConsegneGiornoVenerdi.IsOperatore = False
        Me.UcConsegneGiornoVenerdi.Location = New System.Drawing.Point(711, 4)
        Me.UcConsegneGiornoVenerdi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcConsegneGiornoVenerdi.Name = "UcConsegneGiornoVenerdi"
        Me.UcConsegneGiornoVenerdi.Operatore = False
        Me.UcConsegneGiornoVenerdi.Size = New System.Drawing.Size(171, 582)
        Me.UcConsegneGiornoVenerdi.TabIndex = 4
        Me.UcConsegneGiornoVenerdi.TestoSelezionato = Nothing
        '
        'UcConsegneGiornoSabato
        '
        Me.UcConsegneGiornoSabato.BackColor = System.Drawing.Color.White
        Me.UcConsegneGiornoSabato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcConsegneGiornoSabato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConsegneGiornoSabato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcConsegneGiornoSabato.ForeColor = System.Drawing.Color.Black
        Me.UcConsegneGiornoSabato.IdCorr = 0
        Me.UcConsegneGiornoSabato.IdOrdSel = 0
        Me.UcConsegneGiornoSabato.IsOperatore = False
        Me.UcConsegneGiornoSabato.Location = New System.Drawing.Point(888, 4)
        Me.UcConsegneGiornoSabato.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcConsegneGiornoSabato.Name = "UcConsegneGiornoSabato"
        Me.UcConsegneGiornoSabato.Operatore = False
        Me.UcConsegneGiornoSabato.Size = New System.Drawing.Size(156, 582)
        Me.UcConsegneGiornoSabato.TabIndex = 5
        Me.UcConsegneGiornoSabato.TestoSelezionato = Nothing
        '
        'chkCorrRegistratiInConsegna
        '
        Me.chkCorrRegistratiInConsegna.AutoSize = True
        Me.chkCorrRegistratiInConsegna.Location = New System.Drawing.Point(436, 48)
        Me.chkCorrRegistratiInConsegna.Name = "chkCorrRegistratiInConsegna"
        Me.chkCorrRegistratiInConsegna.Size = New System.Drawing.Size(189, 19)
        Me.chkCorrRegistratiInConsegna.TabIndex = 76
        Me.chkCorrRegistratiInConsegna.Text = "Registrati Corriere In Consegna"
        Me.chkCorrRegistratiInConsegna.UseVisualStyleBackColor = True
        Me.chkCorrRegistratiInConsegna.Visible = False
        '
        'btnIndietro
        '
        Me.btnIndietro.AutoSize = True
        Me.btnIndietro.BackColor = System.Drawing.Color.White
        Me.btnIndietro.FlatAppearance.BorderSize = 0
        Me.btnIndietro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnIndietro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnIndietro.Image = Global.Former.My.Resources.Resources._previous
        Me.btnIndietro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIndietro.Location = New System.Drawing.Point(3, 4)
        Me.btnIndietro.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnIndietro.Name = "btnIndietro"
        Me.btnIndietro.Size = New System.Drawing.Size(103, 33)
        Me.btnIndietro.TabIndex = 5
        Me.btnIndietro.Text = "Precedente"
        Me.btnIndietro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIndietro.UseVisualStyleBackColor = False
        '
        'chkCorrRegistratiProntiConsegna
        '
        Me.chkCorrRegistratiProntiConsegna.AutoSize = True
        Me.chkCorrRegistratiProntiConsegna.Location = New System.Drawing.Point(228, 48)
        Me.chkCorrRegistratiProntiConsegna.Name = "chkCorrRegistratiProntiConsegna"
        Me.chkCorrRegistratiProntiConsegna.Size = New System.Drawing.Size(188, 19)
        Me.chkCorrRegistratiProntiConsegna.TabIndex = 75
        Me.chkCorrRegistratiProntiConsegna.Text = "Registrati Corriere Pronti Cons."
        Me.chkCorrRegistratiProntiConsegna.UseVisualStyleBackColor = True
        Me.chkCorrRegistratiProntiConsegna.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(781, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 15)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Zona"
        '
        'cmbGiorni
        '
        Me.cmbGiorni.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbGiorni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGiorni.FormattingEnabled = True
        Me.cmbGiorni.Items.AddRange(New Object() {"1", "3", "7", "15", "30"})
        Me.cmbGiorni.Location = New System.Drawing.Point(1016, 44)
        Me.cmbGiorni.Name = "cmbGiorni"
        Me.cmbGiorni.Size = New System.Drawing.Size(40, 23)
        Me.cmbGiorni.TabIndex = 74
        '
        'cmbZona
        '
        Me.cmbZona.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbZona.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbZona.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(822, 44)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(127, 23)
        Me.cmbZona.TabIndex = 70
        '
        'dtPickCons
        '
        Me.dtPickCons.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPickCons.CustomFormat = "dd MMM"
        Me.dtPickCons.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickCons.Location = New System.Drawing.Point(955, 44)
        Me.dtPickCons.Name = "dtPickCons"
        Me.dtPickCons.Size = New System.Drawing.Size(55, 23)
        Me.dtPickCons.TabIndex = 73
        '
        'cmbOperatore
        '
        Me.cmbOperatore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbOperatore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOperatore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOperatore.FormattingEnabled = True
        Me.cmbOperatore.Location = New System.Drawing.Point(629, 44)
        Me.cmbOperatore.Name = "cmbOperatore"
        Me.cmbOperatore.Size = New System.Drawing.Size(151, 23)
        Me.cmbOperatore.TabIndex = 68
        '
        'UcStatoOrdiniAdvanced
        '
        Me.UcStatoOrdiniAdvanced.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcStatoOrdiniAdvanced.BackColor = System.Drawing.Color.White
        Me.UcStatoOrdiniAdvanced.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.UcStatoOrdiniAdvanced.Location = New System.Drawing.Point(3, 73)
        Me.UcStatoOrdiniAdvanced.Name = "UcStatoOrdiniAdvanced"
        Me.UcStatoOrdiniAdvanced.Size = New System.Drawing.Size(1053, 24)
        Me.UcStatoOrdiniAdvanced.TabIndex = 71
        '
        'btnAvanti
        '
        Me.btnAvanti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAvanti.AutoSize = True
        Me.btnAvanti.BackColor = System.Drawing.Color.White
        Me.btnAvanti.FlatAppearance.BorderSize = 0
        Me.btnAvanti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAvanti.Image = Global.Former.My.Resources.Resources._Next
        Me.btnAvanti.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAvanti.Location = New System.Drawing.Point(955, 4)
        Me.btnAvanti.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAvanti.Name = "btnAvanti"
        Me.btnAvanti.Size = New System.Drawing.Size(101, 33)
        Me.btnAvanti.TabIndex = 6
        Me.btnAvanti.Text = "Successiva"
        Me.btnAvanti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAvanti.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(561, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Operatore"
        '
        'btnAggiorna
        '
        Me.btnAggiorna.AutoSize = True
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiorna.Location = New System.Drawing.Point(112, 4)
        Me.btnAggiorna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(90, 33)
        Me.btnAggiorna.TabIndex = 7
        Me.btnAggiorna.Text = "Aggiorna"
        Me.btnAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'cmbCorriere
        '
        Me.cmbCorriere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorriere.FormattingEnabled = True
        Me.cmbCorriere.Location = New System.Drawing.Point(65, 44)
        Me.cmbCorriere.Name = "cmbCorriere"
        Me.cmbCorriere.Size = New System.Drawing.Size(157, 23)
        Me.cmbCorriere.TabIndex = 65
        '
        'cmbCliente
        '
        Me.cmbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(335, 10)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(614, 23)
        Me.cmbCliente.TabIndex = 62
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Corriere"
        '
        'btnComprimi
        '
        Me.btnComprimi.BackColor = System.Drawing.Color.White
        Me.btnComprimi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnComprimi.Image = Global.Former.My.Resources.Resources._remove
        Me.btnComprimi.Location = New System.Drawing.Point(245, 3)
        Me.btnComprimi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnComprimi.Name = "btnComprimi"
        Me.btnComprimi.Size = New System.Drawing.Size(32, 33)
        Me.btnComprimi.TabIndex = 7
        Me.btnComprimi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnComprimi.UseVisualStyleBackColor = False
        '
        'btnEspandi
        '
        Me.btnEspandi.BackColor = System.Drawing.Color.White
        Me.btnEspandi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEspandi.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnEspandi.Location = New System.Drawing.Point(207, 3)
        Me.btnEspandi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEspandi.Name = "btnEspandi"
        Me.btnEspandi.Size = New System.Drawing.Size(32, 33)
        Me.btnEspandi.TabIndex = 7
        Me.btnEspandi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEspandi.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(283, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Cliente"
        '
        'tpConsegneGls
        '
        Me.tpConsegneGls.Controls.Add(Me.UcConsegneGlsAdmin)
        Me.tpConsegneGls.ImageIndex = 1
        Me.tpConsegneGls.Location = New System.Drawing.Point(4, 24)
        Me.tpConsegneGls.Name = "tpConsegneGls"
        Me.tpConsegneGls.Padding = New System.Windows.Forms.Padding(3)
        Me.tpConsegneGls.Size = New System.Drawing.Size(1059, 701)
        Me.tpConsegneGls.TabIndex = 1
        Me.tpConsegneGls.Text = "Amministrazione Consegne GLS"
        Me.tpConsegneGls.UseVisualStyleBackColor = True
        '
        'UcConsegneGlsAdmin
        '
        Me.UcConsegneGlsAdmin.BackColor = System.Drawing.Color.White
        Me.UcConsegneGlsAdmin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConsegneGlsAdmin.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcConsegneGlsAdmin.Location = New System.Drawing.Point(3, 3)
        Me.UcConsegneGlsAdmin.Name = "UcConsegneGlsAdmin"
        Me.UcConsegneGlsAdmin.Size = New System.Drawing.Size(1053, 695)
        Me.UcConsegneGlsAdmin.TabIndex = 0
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
        'ucConsegneSettimana
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.SplitContainer)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ucConsegneSettimana"
        Me.Size = New System.Drawing.Size(1265, 729)
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.tabOrdini.ResumeLayout(False)
        Me.tpProgrammate.ResumeLayout(False)
        Me.tpPreviste.ResumeLayout(False)
        Me.tbGestione.ResumeLayout(False)
        Me.tpQuadroConsegne.ResumeLayout(False)
        Me.tpQuadroConsegne.PerformLayout()
        Me.TableMain.ResumeLayout(False)
        Me.tpConsegneGls.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAvanti As System.Windows.Forms.Button
    Friend WithEvents btnIndietro As System.Windows.Forms.Button
    Friend WithEvents TableMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UcConsegneGiornoLunedi As Former.ucConsegneGiorno
    Friend WithEvents UcConsegneGiornoMartedi As Former.ucConsegneGiorno
    Friend WithEvents UcConsegneGiornoMercoledi As Former.ucConsegneGiorno
    Friend WithEvents UcConsegneGiornoGiovedi As Former.ucConsegneGiorno
    Friend WithEvents UcConsegneGiornoVenerdi As Former.ucConsegneGiorno
    Friend WithEvents UcConsegneGiornoSabato As Former.ucConsegneGiorno
    Friend WithEvents btnAggiorna As System.Windows.Forms.Button
    Friend WithEvents btnEspandi As System.Windows.Forms.Button
    Friend WithEvents btnComprimi As System.Windows.Forms.Button
    Friend WithEvents cmbCorriere As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOperatore As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbZona As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UcStatoOrdiniAdvanced As Former.ucOrdiniStatoAdvanced
    Friend WithEvents imlCli As System.Windows.Forms.ImageList
    Friend WithEvents tabOrdini As System.Windows.Forms.TabControl
    Friend WithEvents tpProgrammate As System.Windows.Forms.TabPage
    Friend WithEvents tpPreviste As System.Windows.Forms.TabPage
    Friend WithEvents UcAlberoConsegneProgrammate As Former.ucConsegneAlbero
    Friend WithEvents UcAlberoConsegnePreviste As Former.ucConsegneAlbero
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents dtPickCons As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbGiorni As System.Windows.Forms.ComboBox
    Friend WithEvents chkCorrRegistratiInConsegna As System.Windows.Forms.CheckBox
    Friend WithEvents chkCorrRegistratiProntiConsegna As System.Windows.Forms.CheckBox
    Friend WithEvents tbGestione As System.Windows.Forms.TabControl
    Friend WithEvents tpQuadroConsegne As System.Windows.Forms.TabPage
    Friend WithEvents tpConsegneGls As System.Windows.Forms.TabPage
    Friend WithEvents UcConsegneGlsAdmin As Former.ucConsegneGlsAdmin
    Friend WithEvents imlMain As ImageList
End Class
