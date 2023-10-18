<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsegnaImballaggio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsegnaImballaggio))
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.SplitAlberi = New System.Windows.Forms.SplitContainer()
        Me.tvConsegne = New System.Windows.Forms.TreeView()
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.tvwScatole = New System.Windows.Forms.TreeView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCorr = New System.Windows.Forms.Label()
        Me.lblStampaAutomatica = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPesoConsegna = New Former.ucNumericTextBox()
        Me.UcOrdineAnteprima = New Former.ucOrdiniAnteprima()
        Me.lnkCalcPeso = New System.Windows.Forms.LinkLabel()
        Me.btnSballaTutte = New System.Windows.Forms.Button()
        Me.btnEtichettaGls = New System.Windows.Forms.Button()
        Me.btnSalvaScatole = New System.Windows.Forms.Button()
        Me.btnStampaEtichScat = New System.Windows.Forms.Button()
        Me.btnSballaScatola = New System.Windows.Forms.Button()
        Me.btnProponiSoluzione = New System.Windows.Forms.Button()
        Me.btnChiudi = New System.Windows.Forms.Button()
        Me.btnCreaScatola = New System.Windows.Forms.Button()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.SplitAlberi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitAlberi.Panel1.SuspendLayout()
        Me.SplitAlberi.Panel2.SuspendLayout()
        Me.SplitAlberi.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1235, 640)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.lnkCalcPeso)
        Me.tbProd.Controls.Add(Me.SplitAlberi)
        Me.tbProd.Controls.Add(Me.btnSballaTutte)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.lblCorr)
        Me.tbProd.Controls.Add(Me.lblStampaAutomatica)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtPesoConsegna)
        Me.tbProd.Controls.Add(Me.btnEtichettaGls)
        Me.tbProd.Controls.Add(Me.btnSalvaScatole)
        Me.tbProd.Controls.Add(Me.btnStampaEtichScat)
        Me.tbProd.Controls.Add(Me.btnSballaScatola)
        Me.tbProd.Controls.Add(Me.btnProponiSoluzione)
        Me.tbProd.Controls.Add(Me.UcOrdineAnteprima)
        Me.tbProd.Controls.Add(Me.btnChiudi)
        Me.tbProd.Controls.Add(Me.btnCreaScatola)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1227, 614)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Scatole Imballaggio"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'SplitAlberi
        '
        Me.SplitAlberi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitAlberi.Location = New System.Drawing.Point(44, 56)
        Me.SplitAlberi.Name = "SplitAlberi"
        '
        'SplitAlberi.Panel1
        '
        Me.SplitAlberi.Panel1.Controls.Add(Me.tvConsegne)
        '
        'SplitAlberi.Panel2
        '
        Me.SplitAlberi.Panel2.Controls.Add(Me.tvwScatole)
        Me.SplitAlberi.Size = New System.Drawing.Size(862, 436)
        Me.SplitAlberi.SplitterDistance = 425
        Me.SplitAlberi.TabIndex = 130
        '
        'tvConsegne
        '
        Me.tvConsegne.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvConsegne.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tvConsegne.ImageIndex = 0
        Me.tvConsegne.ImageList = Me.imlCli
        Me.tvConsegne.Indent = 30
        Me.tvConsegne.ItemHeight = 25
        Me.tvConsegne.Location = New System.Drawing.Point(0, 0)
        Me.tvConsegne.Name = "tvConsegne"
        Me.tvConsegne.SelectedImageIndex = 0
        Me.tvConsegne.ShowRootLines = False
        Me.tvConsegne.Size = New System.Drawing.Size(425, 436)
        Me.tvConsegne.TabIndex = 106
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
        Me.imlCli.Images.SetKeyName(11, "Business30-11.png")
        '
        'tvwScatole
        '
        Me.tvwScatole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwScatole.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.tvwScatole.ImageIndex = 0
        Me.tvwScatole.ImageList = Me.imlCli
        Me.tvwScatole.Indent = 30
        Me.tvwScatole.ItemHeight = 25
        Me.tvwScatole.Location = New System.Drawing.Point(0, 0)
        Me.tvwScatole.Name = "tvwScatole"
        Me.tvwScatole.SelectedImageIndex = 0
        Me.tvwScatole.ShowRootLines = False
        Me.tvwScatole.Size = New System.Drawing.Size(433, 436)
        Me.tvwScatole.TabIndex = 129
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(49, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 21)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "Riepilogo Consegna"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.Label2.Location = New System.Drawing.Point(49, 517)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(272, 25)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Stampa Automatica Documenti"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.Label1.Location = New System.Drawing.Point(49, 495)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 25)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Corriere"
        '
        'lblCorr
        '
        Me.lblCorr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCorr.AutoSize = True
        Me.lblCorr.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.lblCorr.ForeColor = System.Drawing.Color.Green
        Me.lblCorr.Location = New System.Drawing.Point(134, 495)
        Me.lblCorr.Name = "lblCorr"
        Me.lblCorr.Size = New System.Drawing.Size(20, 25)
        Me.lblCorr.TabIndex = 124
        Me.lblCorr.Text = "-"
        '
        'lblStampaAutomatica
        '
        Me.lblStampaAutomatica.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStampaAutomatica.AutoSize = True
        Me.lblStampaAutomatica.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.lblStampaAutomatica.ForeColor = System.Drawing.Color.Green
        Me.lblStampaAutomatica.Location = New System.Drawing.Point(324, 517)
        Me.lblStampaAutomatica.Name = "lblStampaAutomatica"
        Me.lblStampaAutomatica.Size = New System.Drawing.Size(20, 25)
        Me.lblStampaAutomatica.TabIndex = 123
        Me.lblStampaAutomatica.Text = "-"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(388, 520)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(240, 25)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "Peso Complessivo Consegna"
        '
        'txtPesoConsegna
        '
        Me.txtPesoConsegna.My_AccettaNegativi = False
        Me.txtPesoConsegna.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPesoConsegna.My_DefaultValue = 0
        Me.txtPesoConsegna.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesoConsegna.ForeColor = System.Drawing.Color.Green
        Me.txtPesoConsegna.Location = New System.Drawing.Point(639, 517)
        Me.txtPesoConsegna.MaxLength = 50
        Me.txtPesoConsegna.My_MaxValue = 1.0E+10!
        Me.txtPesoConsegna.My_MinValue = -1.0E+9!
        Me.txtPesoConsegna.Name = "txtPesoConsegna"
        Me.txtPesoConsegna.My_AllowOnlyInteger = False
        Me.txtPesoConsegna.My_ReplaceWithDefaultValue = True
        Me.txtPesoConsegna.Size = New System.Drawing.Size(56, 30)
        Me.txtPesoConsegna.TabIndex = 121
        Me.txtPesoConsegna.Text = "0"
        Me.txtPesoConsegna.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UcOrdineAnteprima
        '
        Me.UcOrdineAnteprima.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcOrdineAnteprima.BackColor = System.Drawing.Color.White
        Me.UcOrdineAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdineAnteprima.Location = New System.Drawing.Point(912, 5)
        Me.UcOrdineAnteprima.Name = "UcOrdineAnteprima"
        Me.UcOrdineAnteprima.NascondiResto = False
        Me.UcOrdineAnteprima.NoLavori = False
        Me.UcOrdineAnteprima.Size = New System.Drawing.Size(312, 541)
        Me.UcOrdineAnteprima.TabIndex = 109
        '
        'lnkCalcPeso
        '
        Me.lnkCalcPeso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkCalcPeso.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkCalcPeso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCalcPeso.Image = Global.Former.My.Resources.Resources.scale
        Me.lnkCalcPeso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCalcPeso.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCalcPeso.Location = New System.Drawing.Point(701, 516)
        Me.lnkCalcPeso.Name = "lnkCalcPeso"
        Me.lnkCalcPeso.Size = New System.Drawing.Size(104, 32)
        Me.lnkCalcPeso.TabIndex = 131
        Me.lnkCalcPeso.TabStop = True
        Me.lnkCalcPeso.Text = "Calcola Peso"
        Me.lnkCalcPeso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSballaTutte
        '
        Me.btnSballaTutte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSballaTutte.BackColor = System.Drawing.Color.White
        Me.btnSballaTutte.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSballaTutte.ForeColor = System.Drawing.Color.Red
        Me.btnSballaTutte.Image = Global.Former.My.Resources.Resources._DeleteAll
        Me.btnSballaTutte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSballaTutte.Location = New System.Drawing.Point(316, 564)
        Me.btnSballaTutte.Name = "btnSballaTutte"
        Me.btnSballaTutte.Size = New System.Drawing.Size(128, 42)
        Me.btnSballaTutte.TabIndex = 128
        Me.btnSballaTutte.Text = "Sballa Tutte"
        Me.btnSballaTutte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSballaTutte.UseVisualStyleBackColor = False
        '
        'btnEtichettaGls
        '
        Me.btnEtichettaGls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEtichettaGls.BackColor = System.Drawing.Color.White
        Me.btnEtichettaGls.Enabled = False
        Me.btnEtichettaGls.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEtichettaGls.ForeColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnEtichettaGls.Image = Global.Former.My.Resources.Resources._GLS
        Me.btnEtichettaGls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEtichettaGls.Location = New System.Drawing.Point(598, 564)
        Me.btnEtichettaGls.Name = "btnEtichettaGls"
        Me.btnEtichettaGls.Size = New System.Drawing.Size(74, 42)
        Me.btnEtichettaGls.TabIndex = 114
        Me.btnEtichettaGls.Text = "Gls"
        Me.btnEtichettaGls.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEtichettaGls.UseVisualStyleBackColor = False
        '
        'btnSalvaScatole
        '
        Me.btnSalvaScatole.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalvaScatole.BackColor = System.Drawing.Color.White
        Me.btnSalvaScatole.Enabled = False
        Me.btnSalvaScatole.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalvaScatole.ForeColor = System.Drawing.Color.Green
        Me.btnSalvaScatole.Image = Global.Former.My.Resources.Resources.checkmark
        Me.btnSalvaScatole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvaScatole.Location = New System.Drawing.Point(909, 564)
        Me.btnSalvaScatole.Name = "btnSalvaScatole"
        Me.btnSalvaScatole.Size = New System.Drawing.Size(154, 42)
        Me.btnSalvaScatole.TabIndex = 113
        Me.btnSalvaScatole.Text = "Salvataggio Scatole"
        Me.btnSalvaScatole.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvaScatole.UseVisualStyleBackColor = False
        '
        'btnStampaEtichScat
        '
        Me.btnStampaEtichScat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStampaEtichScat.BackColor = System.Drawing.Color.White
        Me.btnStampaEtichScat.Enabled = False
        Me.btnStampaEtichScat.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnStampaEtichScat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnStampaEtichScat.Image = Global.Former.My.Resources.Resources._Etichetta
        Me.btnStampaEtichScat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStampaEtichScat.Location = New System.Drawing.Point(450, 564)
        Me.btnStampaEtichScat.Name = "btnStampaEtichScat"
        Me.btnStampaEtichScat.Size = New System.Drawing.Size(142, 42)
        Me.btnStampaEtichScat.TabIndex = 112
        Me.btnStampaEtichScat.Text = "Etichetta Scatola"
        Me.btnStampaEtichScat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStampaEtichScat.UseVisualStyleBackColor = False
        '
        'btnSballaScatola
        '
        Me.btnSballaScatola.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSballaScatola.BackColor = System.Drawing.Color.White
        Me.btnSballaScatola.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSballaScatola.ForeColor = System.Drawing.Color.Red
        Me.btnSballaScatola.Image = Global.Former.My.Resources.Resources._Elimina
        Me.btnSballaScatola.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSballaScatola.Location = New System.Drawing.Point(182, 564)
        Me.btnSballaScatola.Name = "btnSballaScatola"
        Me.btnSballaScatola.Size = New System.Drawing.Size(128, 42)
        Me.btnSballaScatola.TabIndex = 111
        Me.btnSballaScatola.Text = "Sballa Scatola"
        Me.btnSballaScatola.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSballaScatola.UseVisualStyleBackColor = False
        '
        'btnProponiSoluzione
        '
        Me.btnProponiSoluzione.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnProponiSoluzione.BackColor = System.Drawing.Color.White
        Me.btnProponiSoluzione.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnProponiSoluzione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnProponiSoluzione.Image = Global.Former.My.Resources.Resources._Think
        Me.btnProponiSoluzione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProponiSoluzione.Location = New System.Drawing.Point(678, 564)
        Me.btnProponiSoluzione.Name = "btnProponiSoluzione"
        Me.btnProponiSoluzione.Size = New System.Drawing.Size(150, 42)
        Me.btnProponiSoluzione.TabIndex = 110
        Me.btnProponiSoluzione.Text = "Proponi Soluzione"
        Me.btnProponiSoluzione.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProponiSoluzione.UseVisualStyleBackColor = False
        Me.btnProponiSoluzione.Visible = False
        '
        'btnChiudi
        '
        Me.btnChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChiudi.BackColor = System.Drawing.Color.White
        Me.btnChiudi.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnChiudi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChiudi.Location = New System.Drawing.Point(1067, 564)
        Me.btnChiudi.Name = "btnChiudi"
        Me.btnChiudi.Size = New System.Drawing.Size(154, 42)
        Me.btnChiudi.TabIndex = 108
        Me.btnChiudi.Text = "Chiudi"
        Me.btnChiudi.UseVisualStyleBackColor = False
        '
        'btnCreaScatola
        '
        Me.btnCreaScatola.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCreaScatola.BackColor = System.Drawing.Color.White
        Me.btnCreaScatola.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreaScatola.ForeColor = System.Drawing.Color.Green
        Me.btnCreaScatola.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnCreaScatola.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreaScatola.Location = New System.Drawing.Point(53, 564)
        Me.btnCreaScatola.Name = "btnCreaScatola"
        Me.btnCreaScatola.Size = New System.Drawing.Size(123, 42)
        Me.btnCreaScatola.TabIndex = 107
        Me.btnCreaScatola.Text = "Crea Scatola"
        Me.btnCreaScatola.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreaScatola.UseVisualStyleBackColor = False
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._Consegna
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(37, 34)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'frmConsegnaImballaggio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1235, 640)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "frmConsegnaImballaggio"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Scatole Imballaggio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.SplitAlberi.Panel1.ResumeLayout(False)
        Me.SplitAlberi.Panel2.ResumeLayout(False)
        CType(Me.SplitAlberi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitAlberi.ResumeLayout(False)
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents tvConsegne As System.Windows.Forms.TreeView
    Friend WithEvents imlCli As System.Windows.Forms.ImageList
    Friend WithEvents btnCreaScatola As System.Windows.Forms.Button
    Friend WithEvents btnChiudi As System.Windows.Forms.Button
    Friend WithEvents UcOrdineAnteprima As Former.ucOrdiniAnteprima
    Friend WithEvents btnProponiSoluzione As System.Windows.Forms.Button
    Friend WithEvents btnSballaScatola As System.Windows.Forms.Button
    Friend WithEvents btnStampaEtichScat As System.Windows.Forms.Button
    Friend WithEvents btnSalvaScatole As System.Windows.Forms.Button
    Friend WithEvents btnEtichettaGls As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCorr As System.Windows.Forms.Label
    Friend WithEvents lblStampaAutomatica As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPesoConsegna As ucNumericTextBox
    Friend WithEvents btnSballaTutte As Button
    Friend WithEvents SplitAlberi As SplitContainer
    Friend WithEvents tvwScatole As TreeView
    Friend WithEvents lnkCalcPeso As LinkLabel
End Class
