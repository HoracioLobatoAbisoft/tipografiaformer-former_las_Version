<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOpenIMG
    Inherits baseFormInternaRedim

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpenIMG))
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileImg = New System.Windows.Forms.OpenFileDialog()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lnkColoreCustom = New System.Windows.Forms.LinkLabel()
        Me.lnkColoreWhite = New System.Windows.Forms.LinkLabel()
        Me.lnkColoreBlack = New System.Windows.Forms.LinkLabel()
        Me.lnkColoreDef = New System.Windows.Forms.LinkLabel()
        Me.lblColore = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTesto = New System.Windows.Forms.TextBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnkIncolla = New System.Windows.Forms.LinkLabel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlImg = New System.Windows.Forms.Panel()
        Me.lblCrop = New System.Windows.Forms.Label()
        Me.pctMain = New System.Windows.Forms.PictureBox()
        Me.HScrollBar = New System.Windows.Forms.HScrollBar()
        Me.VScrollBar = New System.Windows.Forms.VScrollBar()
        Me.lnkScarica = New System.Windows.Forms.LinkLabel()
        Me.lnkApri = New System.Windows.Forms.LinkLabel()
        Me.txtWeb = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtImgPath = New System.Windows.Forms.TextBox()
        Me.tpInternet = New System.Windows.Forms.TabPage()
        Me.webSearch = New System.Windows.Forms.WebBrowser()
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlImg.SuspendLayout()
        CType(Me.pctMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpInternet.SuspendLayout()
        Me.gbPulsanti.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "_pdf.png")
        Me.imlTab.Images.SetKeyName(1, "_Foto.png")
        Me.imlTab.Images.SetKeyName(2, "_help.png")
        Me.imlTab.Images.SetKeyName(3, "_google.jpg")
        '
        'OpenFileImg
        '
        Me.OpenFileImg.Filter = "Immagini supportate (png, jpg)|*.png;*.jpg"
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpInternet)
        Me.TabMain.ImageList = Me.imlTab
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(757, 754)
        Me.TabMain.TabIndex = 0
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.Label6)
        Me.tbProd.Controls.Add(Me.lnkColoreCustom)
        Me.tbProd.Controls.Add(Me.lnkColoreWhite)
        Me.tbProd.Controls.Add(Me.lnkColoreBlack)
        Me.tbProd.Controls.Add(Me.lnkColoreDef)
        Me.tbProd.Controls.Add(Me.lblColore)
        Me.tbProd.Controls.Add(Me.Label5)
        Me.tbProd.Controls.Add(Me.txtTesto)
        Me.tbProd.Controls.Add(Me.PictureBox4)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.lnkIncolla)
        Me.tbProd.Controls.Add(Me.PictureBox3)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.pnlImg)
        Me.tbProd.Controls.Add(Me.HScrollBar)
        Me.tbProd.Controls.Add(Me.VScrollBar)
        Me.tbProd.Controls.Add(Me.lnkScarica)
        Me.tbProd.Controls.Add(Me.lnkApri)
        Me.tbProd.Controls.Add(Me.txtWeb)
        Me.tbProd.Controls.Add(Me.PictureBox2)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.txtImgPath)
        Me.tbProd.ImageKey = "_Foto.png"
        Me.tbProd.Location = New System.Drawing.Point(4, 31)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(749, 719)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Seleziona immagine..."
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Orange
        Me.Label6.Location = New System.Drawing.Point(4, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 25)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "BETA"
        '
        'lnkColoreCustom
        '
        Me.lnkColoreCustom.AutoSize = True
        Me.lnkColoreCustom.LinkColor = System.Drawing.Color.Green
        Me.lnkColoreCustom.Location = New System.Drawing.Point(631, 164)
        Me.lnkColoreCustom.Name = "lnkColoreCustom"
        Me.lnkColoreCustom.Size = New System.Drawing.Size(49, 15)
        Me.lnkColoreCustom.TabIndex = 86
        Me.lnkColoreCustom.TabStop = True
        Me.lnkColoreCustom.Text = "Custom"
        '
        'lnkColoreWhite
        '
        Me.lnkColoreWhite.AutoSize = True
        Me.lnkColoreWhite.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkColoreWhite.LinkColor = System.Drawing.Color.White
        Me.lnkColoreWhite.Location = New System.Drawing.Point(587, 164)
        Me.lnkColoreWhite.Name = "lnkColoreWhite"
        Me.lnkColoreWhite.Size = New System.Drawing.Size(38, 15)
        Me.lnkColoreWhite.TabIndex = 85
        Me.lnkColoreWhite.TabStop = True
        Me.lnkColoreWhite.Text = "White"
        '
        'lnkColoreBlack
        '
        Me.lnkColoreBlack.AutoSize = True
        Me.lnkColoreBlack.LinkColor = System.Drawing.Color.Black
        Me.lnkColoreBlack.Location = New System.Drawing.Point(546, 164)
        Me.lnkColoreBlack.Name = "lnkColoreBlack"
        Me.lnkColoreBlack.Size = New System.Drawing.Size(35, 15)
        Me.lnkColoreBlack.TabIndex = 84
        Me.lnkColoreBlack.TabStop = True
        Me.lnkColoreBlack.Text = "Black"
        '
        'lnkColoreDef
        '
        Me.lnkColoreDef.AutoSize = True
        Me.lnkColoreDef.LinkColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.lnkColoreDef.Location = New System.Drawing.Point(495, 164)
        Me.lnkColoreDef.Name = "lnkColoreDef"
        Me.lnkColoreDef.Size = New System.Drawing.Size(45, 15)
        Me.lnkColoreDef.TabIndex = 83
        Me.lnkColoreDef.TabStop = True
        Me.lnkColoreDef.Text = "Default"
        '
        'lblColore
        '
        Me.lblColore.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.lblColore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblColore.Location = New System.Drawing.Point(465, 158)
        Me.lblColore.Name = "lblColore"
        Me.lblColore.Size = New System.Drawing.Size(24, 24)
        Me.lblColore.TabIndex = 82
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(388, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Colore testo"
        '
        'txtTesto
        '
        Me.txtTesto.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTesto.Location = New System.Drawing.Point(215, 155)
        Me.txtTesto.Multiline = True
        Me.txtTesto.Name = "txtTesto"
        Me.txtTesto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTesto.Size = New System.Drawing.Size(153, 128)
        Me.txtTesto.TabIndex = 80
        Me.txtTesto.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.Former.My.Resources.Resources._Text
        Me.PictureBox4.Location = New System.Drawing.Point(63, 156)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 79
        Me.PictureBox4.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(95, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 15)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Testo sovraimpresso"
        '
        'lnkIncolla
        '
        Me.lnkIncolla.AutoSize = True
        Me.lnkIncolla.LinkColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lnkIncolla.Location = New System.Drawing.Point(178, 110)
        Me.lnkIncolla.Name = "lnkIncolla"
        Me.lnkIncolla.Size = New System.Drawing.Size(101, 15)
        Me.lnkIncolla.TabIndex = 77
        Me.lnkIncolla.TabStop = True
        Me.lnkIncolla.Text = "Incolla (CTRL + V)"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Former.My.Resources.Resources._Incolla
        Me.PictureBox3.Location = New System.Drawing.Point(8, 102)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 76
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 15)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Incolla dalla Clipboard..."
        '
        'pnlImg
        '
        Me.pnlImg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlImg.Controls.Add(Me.lblCrop)
        Me.pnlImg.Controls.Add(Me.pctMain)
        Me.pnlImg.Location = New System.Drawing.Point(6, 300)
        Me.pnlImg.Name = "pnlImg"
        Me.pnlImg.Size = New System.Drawing.Size(716, 392)
        Me.pnlImg.TabIndex = 74
        '
        'lblCrop
        '
        Me.lblCrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCrop.Cursor = System.Windows.Forms.Cursors.NoMove2D
        Me.lblCrop.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblCrop.Location = New System.Drawing.Point(3, 3)
        Me.lblCrop.Name = "lblCrop"
        Me.lblCrop.Size = New System.Drawing.Size(128, 128)
        Me.lblCrop.TabIndex = 71
        Me.lblCrop.Text = "(128x128)"
        Me.lblCrop.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pctMain
        '
        Me.pctMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctMain.Cursor = System.Windows.Forms.Cursors.NoMove2D
        Me.pctMain.Location = New System.Drawing.Point(3, 3)
        Me.pctMain.Name = "pctMain"
        Me.pctMain.Size = New System.Drawing.Size(710, 386)
        Me.pctMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctMain.TabIndex = 70
        Me.pctMain.TabStop = False
        '
        'HScrollBar
        '
        Me.HScrollBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScrollBar.Enabled = False
        Me.HScrollBar.Location = New System.Drawing.Point(6, 695)
        Me.HScrollBar.Name = "HScrollBar"
        Me.HScrollBar.Size = New System.Drawing.Size(716, 19)
        Me.HScrollBar.TabIndex = 73
        '
        'VScrollBar
        '
        Me.VScrollBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBar.Enabled = False
        Me.VScrollBar.Location = New System.Drawing.Point(725, 300)
        Me.VScrollBar.Name = "VScrollBar"
        Me.VScrollBar.Size = New System.Drawing.Size(19, 389)
        Me.VScrollBar.TabIndex = 72
        '
        'lnkScarica
        '
        Me.lnkScarica.AutoSize = True
        Me.lnkScarica.LinkColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lnkScarica.Location = New System.Drawing.Point(688, 67)
        Me.lnkScarica.Name = "lnkScarica"
        Me.lnkScarica.Size = New System.Drawing.Size(44, 15)
        Me.lnkScarica.TabIndex = 69
        Me.lnkScarica.TabStop = True
        Me.lnkScarica.Text = "Scarica"
        '
        'lnkApri
        '
        Me.lnkApri.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkApri.AutoSize = True
        Me.lnkApri.LinkColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lnkApri.Location = New System.Drawing.Point(688, 21)
        Me.lnkApri.Name = "lnkApri"
        Me.lnkApri.Size = New System.Drawing.Size(38, 15)
        Me.lnkApri.TabIndex = 68
        Me.lnkApri.TabStop = True
        Me.lnkApri.Text = "Apri..."
        '
        'txtWeb
        '
        Me.txtWeb.Location = New System.Drawing.Point(181, 64)
        Me.txtWeb.Name = "txtWeb"
        Me.txtWeb.Size = New System.Drawing.Size(501, 20)
        Me.txtWeb.TabIndex = 67
        Me.txtWeb.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources._internet
        Me.PictureBox2.Location = New System.Drawing.Point(8, 59)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 66
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 15)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Scarica da internet..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._CartellaAperta
        Me.PictureBox1.Location = New System.Drawing.Point(8, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 15)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Seleziona dal disco..."
        '
        'txtImgPath
        '
        Me.txtImgPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImgPath.Location = New System.Drawing.Point(181, 18)
        Me.txtImgPath.Name = "txtImgPath"
        Me.txtImgPath.ReadOnly = True
        Me.txtImgPath.Size = New System.Drawing.Size(501, 20)
        Me.txtImgPath.TabIndex = 2
        Me.txtImgPath.TabStop = False
        '
        'tpInternet
        '
        Me.tpInternet.Controls.Add(Me.webSearch)
        Me.tpInternet.ImageKey = "_google.jpg"
        Me.tpInternet.Location = New System.Drawing.Point(4, 31)
        Me.tpInternet.Name = "tpInternet"
        Me.tpInternet.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInternet.Size = New System.Drawing.Size(749, 719)
        Me.tpInternet.TabIndex = 1
        Me.tpInternet.Text = "Cerca su Internet"
        Me.tpInternet.UseVisualStyleBackColor = True
        '
        'webSearch
        '
        Me.webSearch.AllowWebBrowserDrop = False
        Me.webSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webSearch.Location = New System.Drawing.Point(3, 3)
        Me.webSearch.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webSearch.Name = "webSearch"
        Me.webSearch.ScriptErrorsSuppressed = True
        Me.webSearch.Size = New System.Drawing.Size(743, 713)
        Me.webSearch.TabIndex = 0
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 754)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(757, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(673, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Annulla"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(577, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(93, 32)
        Me.btnOk.TabIndex = 15
        Me.btnOk.TabStop = False
        Me.btnOk.Text = "Conferma"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmOpenIMG
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(757, 802)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmOpenIMG"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Seleziona immagine"
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlImg.ResumeLayout(False)
        CType(Me.pctMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpInternet.ResumeLayout(False)
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents imlTab As ImageList
    Friend WithEvents txtImgPath As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileImg As OpenFileDialog
    Friend WithEvents lnkScarica As LinkLabel
    Friend WithEvents lnkApri As LinkLabel
    Friend WithEvents txtWeb As TextBox
    Friend WithEvents pctMain As PictureBox
    Friend WithEvents lblCrop As Label
    Friend WithEvents pnlImg As Panel
    Friend WithEvents HScrollBar As HScrollBar
    Friend WithEvents VScrollBar As VScrollBar
    Friend WithEvents lnkIncolla As LinkLabel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tpInternet As TabPage
    Friend WithEvents webSearch As WebBrowser
    Friend WithEvents txtTesto As TextBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lnkColoreCustom As LinkLabel
    Friend WithEvents lnkColoreWhite As LinkLabel
    Friend WithEvents lnkColoreBlack As LinkLabel
    Friend WithEvents lnkColoreDef As LinkLabel
    Friend WithEvents lblColore As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dlgColor As ColorDialog
    Friend WithEvents Label6 As Label
End Class
