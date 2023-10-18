<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucListinoBaseDatiWeb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucListinoBaseDatiWeb))
        Me.txtRicercaGoogle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSEO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblBordoSx = New System.Windows.Forms.Label()
        Me.lblBordo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearchSito = New System.Windows.Forms.Button()
        Me.txtImgSito = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblInfoDescr = New System.Windows.Forms.Label()
        Me.txtDescrSito = New System.Windows.Forms.TextBox()
        Me.lblNomeListinoBase = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pctIcoCs = New System.Windows.Forms.PictureBox()
        Me.pctIcoTc = New System.Windows.Forms.PictureBox()
        Me.pctIcoFp = New System.Windows.Forms.PictureBox()
        Me.pctIcoP = New System.Windows.Forms.PictureBox()
        Me.pctPrendiIco = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtImgAggiuntive = New System.Windows.Forms.TextBox()
        Me.pctShellImg = New System.Windows.Forms.PictureBox()
        Me.lvwHD = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.pctAnteprima = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lnkOpenFolder = New System.Windows.Forms.Button()
        Me.lnkApriCon = New System.Windows.Forms.Button()
        Me.UcPictureWizard = New Former.ucPictureWizard()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctIcoCs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctIcoTc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctIcoFp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctIcoP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctPrendiIco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctShellImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctAnteprima, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRicercaGoogle
        '
        Me.txtRicercaGoogle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRicercaGoogle.Location = New System.Drawing.Point(9, 54)
        Me.txtRicercaGoogle.MaxLength = 255
        Me.txtRicercaGoogle.Multiline = True
        Me.txtRicercaGoogle.Name = "txtRicercaGoogle"
        Me.txtRicercaGoogle.Size = New System.Drawing.Size(148, 144)
        Me.txtRicercaGoogle.TabIndex = 207
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(6, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 34)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "Descrizione Ricerca Google" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(max 255 char)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtSEO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtRicercaGoogle)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(931, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(163, 792)
        Me.GroupBox1.TabIndex = 246
        Me.GroupBox1.TabStop = False
        '
        'txtSEO
        '
        Me.txtSEO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSEO.Location = New System.Drawing.Point(9, 240)
        Me.txtSEO.MaxLength = 2000
        Me.txtSEO.Multiline = True
        Me.txtSEO.Name = "txtSEO"
        Me.txtSEO.Size = New System.Drawing.Size(148, 546)
        Me.txtSEO.TabIndex = 209
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(6, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(248, 36)
        Me.Label3.TabIndex = 208
        Me.Label3.Text = "Descrizione SEO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(max 2000 char)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBordoSx
        '
        Me.lblBordoSx.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBordoSx.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblBordoSx.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBordoSx.Location = New System.Drawing.Point(6, 22)
        Me.lblBordoSx.Name = "lblBordoSx"
        Me.lblBordoSx.Size = New System.Drawing.Size(17, 622)
        Me.lblBordoSx.TabIndex = 245
        '
        'lblBordo
        '
        Me.lblBordo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBordo.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblBordo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBordo.Location = New System.Drawing.Point(432, 22)
        Me.lblBordo.Name = "lblBordo"
        Me.lblBordo.Size = New System.Drawing.Size(11, 622)
        Me.lblBordo.TabIndex = 244
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(30, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 93)
        Me.Label1.TabIndex = 243
        Me.Label1.Text = "Descrizione sovra impressione immagini testata"
        '
        'btnSearchSito
        '
        Me.btnSearchSito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSearchSito.Location = New System.Drawing.Point(812, 152)
        Me.btnSearchSito.Name = "btnSearchSito"
        Me.btnSearchSito.Size = New System.Drawing.Size(26, 22)
        Me.btnSearchSito.TabIndex = 230
        Me.btnSearchSito.Text = "..."
        Me.btnSearchSito.UseVisualStyleBackColor = True
        '
        'txtImgSito
        '
        Me.txtImgSito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtImgSito.Location = New System.Drawing.Point(206, 153)
        Me.txtImgSito.MaxLength = 50
        Me.txtImgSito.Name = "txtImgSito"
        Me.txtImgSito.ReadOnly = True
        Me.txtImgSito.Size = New System.Drawing.Size(600, 23)
        Me.txtImgSito.TabIndex = 229
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(46, 9)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(100, 21)
        Me.Label35.TabIndex = 236
        Me.Label35.Text = "Listino Base"
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Orange
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label41.Location = New System.Drawing.Point(30, 154)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(170, 19)
        Me.Label41.TabIndex = 235
        Me.Label41.Text = "Immagine Principale (800x267)"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInfoDescr
        '
        Me.lblInfoDescr.BackColor = System.Drawing.Color.Orange
        Me.lblInfoDescr.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoDescr.ForeColor = System.Drawing.Color.White
        Me.lblInfoDescr.Location = New System.Drawing.Point(27, 158)
        Me.lblInfoDescr.Name = "lblInfoDescr"
        Me.lblInfoDescr.Size = New System.Drawing.Size(400, 28)
        Me.lblInfoDescr.TabIndex = 234
        Me.lblInfoDescr.Text = "Il Prodotto che hai scelto"
        Me.lblInfoDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescrSito
        '
        Me.txtDescrSito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescrSito.Location = New System.Drawing.Point(206, 53)
        Me.txtDescrSito.MaxLength = 255
        Me.txtDescrSito.Multiline = True
        Me.txtDescrSito.Name = "txtDescrSito"
        Me.txtDescrSito.Size = New System.Drawing.Size(600, 94)
        Me.txtDescrSito.TabIndex = 233
        '
        'lblNomeListinoBase
        '
        Me.lblNomeListinoBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblNomeListinoBase.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.lblNomeListinoBase.Location = New System.Drawing.Point(212, 9)
        Me.lblNomeListinoBase.Name = "lblNomeListinoBase"
        Me.lblNomeListinoBase.Size = New System.Drawing.Size(797, 31)
        Me.lblNomeListinoBase.TabIndex = 232
        Me.lblNomeListinoBase.Text = "-"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._googleLogo
        Me.PictureBox1.Location = New System.Drawing.Point(949, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(142, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 247
        Me.PictureBox1.TabStop = False
        '
        'pctIcoCs
        '
        Me.pctIcoCs.Location = New System.Drawing.Point(377, 245)
        Me.pctIcoCs.Name = "pctIcoCs"
        Me.pctIcoCs.Size = New System.Drawing.Size(50, 50)
        Me.pctIcoCs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctIcoCs.TabIndex = 242
        Me.pctIcoCs.TabStop = False
        '
        'pctIcoTc
        '
        Me.pctIcoTc.Location = New System.Drawing.Point(264, 245)
        Me.pctIcoTc.Name = "pctIcoTc"
        Me.pctIcoTc.Size = New System.Drawing.Size(50, 50)
        Me.pctIcoTc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctIcoTc.TabIndex = 241
        Me.pctIcoTc.TabStop = False
        '
        'pctIcoFp
        '
        Me.pctIcoFp.Location = New System.Drawing.Point(146, 245)
        Me.pctIcoFp.Name = "pctIcoFp"
        Me.pctIcoFp.Size = New System.Drawing.Size(50, 50)
        Me.pctIcoFp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctIcoFp.TabIndex = 240
        Me.pctIcoFp.TabStop = False
        '
        'pctIcoP
        '
        Me.pctIcoP.Location = New System.Drawing.Point(28, 245)
        Me.pctIcoP.Name = "pctIcoP"
        Me.pctIcoP.Size = New System.Drawing.Size(50, 50)
        Me.pctIcoP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctIcoP.TabIndex = 239
        Me.pctIcoP.TabStop = False
        '
        'pctPrendiIco
        '
        Me.pctPrendiIco.Location = New System.Drawing.Point(377, 189)
        Me.pctPrendiIco.Name = "pctPrendiIco"
        Me.pctPrendiIco.Size = New System.Drawing.Size(50, 50)
        Me.pctPrendiIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctPrendiIco.TabIndex = 238
        Me.pctPrendiIco.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Former.My.Resources.Resources._PubblicazioneWeb
        Me.PictureBox3.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 237
        Me.PictureBox3.TabStop = False
        '
        'txtImgAggiuntive
        '
        Me.txtImgAggiuntive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImgAggiuntive.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtImgAggiuntive.Location = New System.Drawing.Point(6, 22)
        Me.txtImgAggiuntive.MaxLength = 50
        Me.txtImgAggiuntive.Name = "txtImgAggiuntive"
        Me.txtImgAggiuntive.ReadOnly = True
        Me.txtImgAggiuntive.Size = New System.Drawing.Size(386, 23)
        Me.txtImgAggiuntive.TabIndex = 249
        '
        'pctShellImg
        '
        Me.pctShellImg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctShellImg.Image = CType(resources.GetObject("pctShellImg.Image"), System.Drawing.Image)
        Me.pctShellImg.Location = New System.Drawing.Point(398, 23)
        Me.pctShellImg.Name = "pctShellImg"
        Me.pctShellImg.Size = New System.Drawing.Size(20, 20)
        Me.pctShellImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctShellImg.TabIndex = 250
        Me.pctShellImg.TabStop = False
        '
        'lvwHD
        '
        Me.lvwHD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwHD.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvwHD.HideSelection = False
        Me.lvwHD.Location = New System.Drawing.Point(6, 54)
        Me.lvwHD.Name = "lvwHD"
        Me.lvwHD.Size = New System.Drawing.Size(412, 562)
        Me.lvwHD.TabIndex = 251
        Me.lvwHD.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.BackColor = System.Drawing.Color.White
        Me.btnDel.FlatAppearance.BorderSize = 0
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDel.Image = Global.Former.My.Resources.Resources._remove
        Me.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDel.Location = New System.Drawing.Point(332, 623)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(86, 24)
        Me.btnDel.TabIndex = 253
        Me.btnDel.Text = "Rimuovi"
        Me.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAdd.Image = Global.Former.My.Resources.Resources._Aggiungi
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(237, 623)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(89, 24)
        Me.btnAdd.TabIndex = 252
        Me.btnAdd.Text = "Aggiungi"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'pctAnteprima
        '
        Me.pctAnteprima.Location = New System.Drawing.Point(27, 22)
        Me.pctAnteprima.Name = "pctAnteprima"
        Me.pctAnteprima.Size = New System.Drawing.Size(400, 133)
        Me.pctAnteprima.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctAnteprima.TabIndex = 254
        Me.pctAnteprima.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lnkOpenFolder)
        Me.GroupBox2.Controls.Add(Me.lnkApriCon)
        Me.GroupBox2.Controls.Add(Me.lvwHD)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.pctShellImg)
        Me.GroupBox2.Controls.Add(Me.btnDel)
        Me.GroupBox2.Controls.Add(Me.txtImgAggiuntive)
        Me.GroupBox2.Location = New System.Drawing.Point(49, 181)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(424, 654)
        Me.GroupBox2.TabIndex = 255
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Immagini Aggiuntive"
        '
        'lnkOpenFolder
        '
        Me.lnkOpenFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkOpenFolder.BackColor = System.Drawing.Color.White
        Me.lnkOpenFolder.FlatAppearance.BorderSize = 0
        Me.lnkOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkOpenFolder.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkOpenFolder.Image = Global.Former.My.Resources.Resources._CartellaAperta
        Me.lnkOpenFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkOpenFolder.Location = New System.Drawing.Point(113, 623)
        Me.lnkOpenFolder.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lnkOpenFolder.Name = "lnkOpenFolder"
        Me.lnkOpenFolder.Size = New System.Drawing.Size(108, 24)
        Me.lnkOpenFolder.TabIndex = 255
        Me.lnkOpenFolder.Text = "Apri cartella"
        Me.lnkOpenFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkOpenFolder.UseVisualStyleBackColor = False
        '
        'lnkApriCon
        '
        Me.lnkApriCon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkApriCon.BackColor = System.Drawing.Color.White
        Me.lnkApriCon.FlatAppearance.BorderSize = 0
        Me.lnkApriCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkApriCon.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkApriCon.Image = Global.Former.My.Resources.Resources._CartellaAperta
        Me.lnkApriCon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkApriCon.Location = New System.Drawing.Point(6, 623)
        Me.lnkApriCon.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lnkApriCon.Name = "lnkApriCon"
        Me.lnkApriCon.Size = New System.Drawing.Size(98, 24)
        Me.lnkApriCon.TabIndex = 254
        Me.lnkApriCon.Text = "Apri con..."
        Me.lnkApriCon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkApriCon.UseVisualStyleBackColor = False
        '
        'UcPictureWizard
        '
        Me.UcPictureWizard.AutoSize = True
        Me.UcPictureWizard.ImgHeight = 128
        Me.UcPictureWizard.ImgWidth = 128
        Me.UcPictureWizard.Location = New System.Drawing.Point(844, 151)
        Me.UcPictureWizard.Name = "UcPictureWizard"
        Me.UcPictureWizard.PrefissoDaApplicare = ""
        Me.UcPictureWizard.RifPictureBox = Nothing
        Me.UcPictureWizard.RifTextBoxPath = Me.txtImgSito
        Me.UcPictureWizard.Size = New System.Drawing.Size(81, 25)
        Me.UcPictureWizard.TabIndex = 256
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.pctAnteprima)
        Me.GroupBox3.Controls.Add(Me.lblInfoDescr)
        Me.GroupBox3.Controls.Add(Me.pctPrendiIco)
        Me.GroupBox3.Controls.Add(Me.pctIcoP)
        Me.GroupBox3.Controls.Add(Me.pctIcoFp)
        Me.GroupBox3.Controls.Add(Me.pctIcoTc)
        Me.GroupBox3.Controls.Add(Me.lblBordoSx)
        Me.GroupBox3.Controls.Add(Me.pctIcoCs)
        Me.GroupBox3.Controls.Add(Me.lblBordo)
        Me.GroupBox3.Location = New System.Drawing.Point(479, 181)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(446, 654)
        Me.GroupBox3.TabIndex = 257
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Anteprima (50% size)"
        '
        'ucListinoBaseDatiWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.UcPictureWizard)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearchSito)
        Me.Controls.Add(Me.txtImgSito)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.txtDescrSito)
        Me.Controls.Add(Me.lblNomeListinoBase)
        Me.Name = "ucListinoBaseDatiWeb"
        Me.Size = New System.Drawing.Size(1095, 839)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctIcoCs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctIcoTc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctIcoFp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctIcoP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctPrendiIco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctShellImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctAnteprima, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRicercaGoogle As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileImg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSEO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblBordoSx As System.Windows.Forms.Label
    Friend WithEvents lblBordo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pctIcoCs As System.Windows.Forms.PictureBox
    Friend WithEvents pctIcoTc As System.Windows.Forms.PictureBox
    Friend WithEvents pctIcoFp As System.Windows.Forms.PictureBox
    Friend WithEvents pctIcoP As System.Windows.Forms.PictureBox
    Friend WithEvents pctPrendiIco As System.Windows.Forms.PictureBox
    Friend WithEvents btnSearchSito As System.Windows.Forms.Button
    Friend WithEvents txtImgSito As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lblInfoDescr As System.Windows.Forms.Label
    Friend WithEvents txtDescrSito As System.Windows.Forms.TextBox
    Friend WithEvents lblNomeListinoBase As System.Windows.Forms.Label
    Friend WithEvents txtImgAggiuntive As TextBox
    Friend WithEvents pctShellImg As PictureBox
    Friend WithEvents lvwHD As ListView
    Friend WithEvents btnDel As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents pctAnteprima As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lnkApriCon As Button
    Friend WithEvents lnkOpenFolder As Button
    Friend WithEvents UcPictureWizard As ucPictureWizard
    Friend WithEvents GroupBox3 As GroupBox
End Class
