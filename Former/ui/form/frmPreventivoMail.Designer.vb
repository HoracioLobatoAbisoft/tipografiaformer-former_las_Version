<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPreventivoMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreventivoMail))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.pnlPrezzo = New System.Windows.Forms.Panel()
        Me.lblPrezzoSuggerito = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.webPreview = New System.Windows.Forms.WebBrowser()
        Me.btnAllega3 = New System.Windows.Forms.Button()
        Me.txtAllegato3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAllega2 = New System.Windows.Forms.Button()
        Me.txtAllegato2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAllega = New System.Windows.Forms.Button()
        Me.txtAllegato1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvwAllegati = New System.Windows.Forms.ListView()
        Me.imlMail = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitolo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInRisposta = New System.Windows.Forms.TextBox()
        Me.chkLavorata = New System.Windows.Forms.CheckBox()
        Me.txtRisp = New System.Windows.Forms.TextBox()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.dlgAllegato = New System.Windows.Forms.OpenFileDialog()
        Me.btnCalcPrezzoLav = New System.Windows.Forms.Button()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.pnlPrezzo.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnCalcPrezzoLav)
        Me.gbPulsanti.Controls.Add(Me.btnCancel)
        Me.gbPulsanti.Controls.Add(Me.btnOk)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 662)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1223, 48)
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
        Me.btnCancel.Location = New System.Drawing.Point(1145, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 32)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Chiudi"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.AutoSize = True
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(1025, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(114, 32)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "Invia Risposta"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1223, 662)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.pnlPrezzo)
        Me.tbProd.Controls.Add(Me.webPreview)
        Me.tbProd.Controls.Add(Me.btnAllega3)
        Me.tbProd.Controls.Add(Me.txtAllegato3)
        Me.tbProd.Controls.Add(Me.Label4)
        Me.tbProd.Controls.Add(Me.btnAllega2)
        Me.tbProd.Controls.Add(Me.txtAllegato2)
        Me.tbProd.Controls.Add(Me.Label3)
        Me.tbProd.Controls.Add(Me.btnAllega)
        Me.tbProd.Controls.Add(Me.txtAllegato1)
        Me.tbProd.Controls.Add(Me.Label2)
        Me.tbProd.Controls.Add(Me.lvwAllegati)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.lblTitolo)
        Me.tbProd.Controls.Add(Me.Label7)
        Me.tbProd.Controls.Add(Me.txtInRisposta)
        Me.tbProd.Controls.Add(Me.chkLavorata)
        Me.tbProd.Controls.Add(Me.txtRisp)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1215, 636)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Preventivo Mail"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'pnlPrezzo
        '
        Me.pnlPrezzo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPrezzo.Controls.Add(Me.lblPrezzoSuggerito)
        Me.pnlPrezzo.Controls.Add(Me.Label5)
        Me.pnlPrezzo.Location = New System.Drawing.Point(639, 16)
        Me.pnlPrezzo.Name = "pnlPrezzo"
        Me.pnlPrezzo.Size = New System.Drawing.Size(296, 27)
        Me.pnlPrezzo.TabIndex = 72
        Me.pnlPrezzo.Visible = False
        '
        'lblPrezzoSuggerito
        '
        Me.lblPrezzoSuggerito.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrezzoSuggerito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.lblPrezzoSuggerito.Location = New System.Drawing.Point(130, 0)
        Me.lblPrezzoSuggerito.Name = "lblPrezzoSuggerito"
        Me.lblPrezzoSuggerito.Size = New System.Drawing.Size(161, 27)
        Me.lblPrezzoSuggerito.TabIndex = 70
        Me.lblPrezzoSuggerito.Text = "-"
        Me.lblPrezzoSuggerito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Image = Global.Former.My.Resources.Resources.currency_exchange_24
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 27)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Prezzo suggerito"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'webPreview
        '
        Me.webPreview.AllowNavigation = False
        Me.webPreview.AllowWebBrowserDrop = False
        Me.webPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webPreview.IsWebBrowserContextMenuEnabled = False
        Me.webPreview.Location = New System.Drawing.Point(113, 367)
        Me.webPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webPreview.Name = "webPreview"
        Me.webPreview.Size = New System.Drawing.Size(1094, 202)
        Me.webPreview.TabIndex = 71
        Me.webPreview.Visible = False
        Me.webPreview.WebBrowserShortcutsEnabled = False
        '
        'btnAllega3
        '
        Me.btnAllega3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAllega3.Location = New System.Drawing.Point(1176, 311)
        Me.btnAllega3.Name = "btnAllega3"
        Me.btnAllega3.Size = New System.Drawing.Size(31, 23)
        Me.btnAllega3.TabIndex = 64
        Me.btnAllega3.Text = "..."
        Me.btnAllega3.UseVisualStyleBackColor = True
        '
        'txtAllegato3
        '
        Me.txtAllegato3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAllegato3.BackColor = System.Drawing.Color.White
        Me.txtAllegato3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAllegato3.Location = New System.Drawing.Point(113, 312)
        Me.txtAllegato3.Name = "txtAllegato3"
        Me.txtAllegato3.ReadOnly = True
        Me.txtAllegato3.Size = New System.Drawing.Size(1057, 23)
        Me.txtAllegato3.TabIndex = 63
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(29, 315)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Allega un file"
        '
        'btnAllega2
        '
        Me.btnAllega2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAllega2.Location = New System.Drawing.Point(1176, 284)
        Me.btnAllega2.Name = "btnAllega2"
        Me.btnAllega2.Size = New System.Drawing.Size(31, 23)
        Me.btnAllega2.TabIndex = 61
        Me.btnAllega2.Text = "..."
        Me.btnAllega2.UseVisualStyleBackColor = True
        '
        'txtAllegato2
        '
        Me.txtAllegato2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAllegato2.BackColor = System.Drawing.Color.White
        Me.txtAllegato2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAllegato2.Location = New System.Drawing.Point(113, 285)
        Me.txtAllegato2.Name = "txtAllegato2"
        Me.txtAllegato2.ReadOnly = True
        Me.txtAllegato2.Size = New System.Drawing.Size(1057, 23)
        Me.txtAllegato2.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(29, 288)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Allega un file"
        '
        'btnAllega
        '
        Me.btnAllega.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAllega.Location = New System.Drawing.Point(1176, 257)
        Me.btnAllega.Name = "btnAllega"
        Me.btnAllega.Size = New System.Drawing.Size(31, 23)
        Me.btnAllega.TabIndex = 58
        Me.btnAllega.Text = "..."
        Me.btnAllega.UseVisualStyleBackColor = True
        '
        'txtAllegato1
        '
        Me.txtAllegato1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAllegato1.BackColor = System.Drawing.Color.White
        Me.txtAllegato1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAllegato1.Location = New System.Drawing.Point(113, 258)
        Me.txtAllegato1.Name = "txtAllegato1"
        Me.txtAllegato1.ReadOnly = True
        Me.txtAllegato1.Size = New System.Drawing.Size(1057, 23)
        Me.txtAllegato1.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(29, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Allega un file"
        '
        'lvwAllegati
        '
        Me.lvwAllegati.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwAllegati.BackColor = System.Drawing.SystemColors.Control
        Me.lvwAllegati.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lvwAllegati.LabelWrap = False
        Me.lvwAllegati.LargeImageList = Me.imlMail
        Me.lvwAllegati.Location = New System.Drawing.Point(114, 575)
        Me.lvwAllegati.Name = "lvwAllegati"
        Me.lvwAllegati.Size = New System.Drawing.Size(1093, 53)
        Me.lvwAllegati.TabIndex = 54
        Me.toolTipHelp.SetToolTip(Me.lvwAllegati, "Elenco degli allegati della mail a cui si sta rispondendo")
        Me.lvwAllegati.UseCompatibleStateImageBehavior = False
        '
        'imlMail
        '
        Me.imlMail.ImageStream = CType(resources.GetObject("imlMail.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMail.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMail.Images.SetKeyName(0, "_MailIn.png")
        Me.imlMail.Images.SetKeyName(1, "_MailOut.png")
        Me.imlMail.Images.SetKeyName(2, "ico_DL_R.png")
        Me.imlMail.Images.SetKeyName(3, "ico_LV_R.png")
        Me.imlMail.Images.SetKeyName(4, "_Allega.png")
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(59, 575)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 15)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Allegati"
        '
        'lblTitolo
        '
        Me.lblTitolo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitolo.BackColor = System.Drawing.SystemColors.Control
        Me.lblTitolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitolo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTitolo.Location = New System.Drawing.Point(113, 340)
        Me.lblTitolo.Name = "lblTitolo"
        Me.lblTitolo.Size = New System.Drawing.Size(1094, 24)
        Me.lblTitolo.TabIndex = 20
        Me.lblTitolo.Text = "-"
        Me.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(29, 346)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 15)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "In risposta a:"
        '
        'txtInRisposta
        '
        Me.txtInRisposta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInRisposta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtInRisposta.Location = New System.Drawing.Point(113, 367)
        Me.txtInRisposta.MaxLength = 10000000
        Me.txtInRisposta.Multiline = True
        Me.txtInRisposta.Name = "txtInRisposta"
        Me.txtInRisposta.ReadOnly = True
        Me.txtInRisposta.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInRisposta.Size = New System.Drawing.Size(1094, 202)
        Me.txtInRisposta.TabIndex = 18
        '
        'chkLavorata
        '
        Me.chkLavorata.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkLavorata.AutoSize = True
        Me.chkLavorata.Location = New System.Drawing.Point(941, 24)
        Me.chkLavorata.Name = "chkLavorata"
        Me.chkLavorata.Size = New System.Drawing.Size(266, 19)
        Me.chkLavorata.TabIndex = 5
        Me.chkLavorata.Text = "Contrassegna la conversazione come lavorata"
        Me.chkLavorata.UseVisualStyleBackColor = True
        '
        'txtRisp
        '
        Me.txtRisp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRisp.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtRisp.Location = New System.Drawing.Point(113, 49)
        Me.txtRisp.MaxLength = 10000000
        Me.txtRisp.Multiline = True
        Me.txtRisp.Name = "txtRisp"
        Me.txtRisp.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRisp.Size = New System.Drawing.Size(1094, 203)
        Me.txtRisp.TabIndex = 0
        Me.txtRisp.Text = "Gentile cliente, in merito alla sua richiesta di quotazione la nostra migliore of" &
    "ferta è: "
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._MailOut
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
        Me.lblTipo.Size = New System.Drawing.Size(131, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Preventivo Mail"
        '
        'dlgAllegato
        '
        Me.dlgAllegato.Filter = "Tutti i file|*.*"
        '
        'btnCalcPrezzoLav
        '
        Me.btnCalcPrezzoLav.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnCalcPrezzoLav.AutoSize = True
        Me.btnCalcPrezzoLav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCalcPrezzoLav.FlatAppearance.BorderSize = 0
        Me.btnCalcPrezzoLav.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalcPrezzoLav.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCalcPrezzoLav.Image = Global.Former.My.Resources.Resources.currency_exchange_24
        Me.btnCalcPrezzoLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCalcPrezzoLav.Location = New System.Drawing.Point(6, 12)
        Me.btnCalcPrezzoLav.Name = "btnCalcPrezzoLav"
        Me.btnCalcPrezzoLav.Size = New System.Drawing.Size(178, 32)
        Me.btnCalcPrezzoLav.TabIndex = 17
        Me.btnCalcPrezzoLav.Text = "Calcola Prezzo lavorazione"
        Me.btnCalcPrezzoLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCalcPrezzoLav.UseVisualStyleBackColor = True
        '
        'frmPreventivoMail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1223, 710)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmPreventivoMail"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Preventivo Mail"
        Me.gbPulsanti.ResumeLayout(False)
        Me.gbPulsanti.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.pnlPrezzo.ResumeLayout(False)
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents chkLavorata As System.Windows.Forms.CheckBox
    Friend WithEvents txtRisp As System.Windows.Forms.TextBox
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtInRisposta As TextBox
    Friend WithEvents lblTitolo As Label
    Friend WithEvents lvwAllegati As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents imlMail As ImageList
    Friend WithEvents btnAllega As Button
    Friend WithEvents txtAllegato1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dlgAllegato As OpenFileDialog
    Friend WithEvents btnAllega3 As Button
    Friend WithEvents txtAllegato3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnAllega2 As Button
    Friend WithEvents txtAllegato2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlPrezzo As Panel
    Friend WithEvents lblPrezzoSuggerito As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents webPreview As WebBrowser
    Friend WithEvents btnCalcPrezzoLav As Button
End Class
