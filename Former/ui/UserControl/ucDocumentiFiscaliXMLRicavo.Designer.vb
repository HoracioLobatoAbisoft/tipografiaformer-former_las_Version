<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucDocumentiFiscaliXMLRicavo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucDocumentiFiscaliXMLRicavo))
        Me.lblStato = New System.Windows.Forms.Label()
        Me.lblAzienda = New System.Windows.Forms.Label()
        Me.txtXMLOut = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblInviatoIl = New System.Windows.Forms.Label()
        Me.txtXMLIn = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lnkGeneraXML = New System.Windows.Forms.LinkLabel()
        Me.lnkSendXML = New System.Windows.Forms.LinkLabel()
        Me.lnkExportXML = New System.Windows.Forms.LinkLabel()
        Me.lnkOutCoda = New System.Windows.Forms.LinkLabel()
        Me.imlFattura = New System.Windows.Forms.ImageList(Me.components)
        Me.tabFattura = New System.Windows.Forms.TabControl()
        Me.tpFattura = New System.Windows.Forms.TabPage()
        Me.webFattura = New System.Windows.Forms.WebBrowser()
        Me.tpXML = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.tabFattura.SuspendLayout()
        Me.tpFattura.SuspendLayout()
        Me.tpXML.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStato
        '
        Me.lblStato.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.lblStato.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStato.ForeColor = System.Drawing.Color.White
        Me.lblStato.Location = New System.Drawing.Point(98, 3)
        Me.lblStato.Name = "lblStato"
        Me.lblStato.Size = New System.Drawing.Size(238, 28)
        Me.lblStato.TabIndex = 118
        Me.lblStato.Text = "-"
        Me.lblStato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAzienda
        '
        Me.lblAzienda.BackColor = System.Drawing.Color.White
        Me.lblAzienda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAzienda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblAzienda.Location = New System.Drawing.Point(3, 3)
        Me.lblAzienda.Name = "lblAzienda"
        Me.lblAzienda.Size = New System.Drawing.Size(89, 28)
        Me.lblAzienda.TabIndex = 120
        Me.lblAzienda.Text = "Stato"
        Me.lblAzienda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtXMLOut
        '
        Me.txtXMLOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtXMLOut.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtXMLOut.Location = New System.Drawing.Point(3, 3)
        Me.txtXMLOut.Multiline = True
        Me.txtXMLOut.Name = "txtXMLOut"
        Me.txtXMLOut.ReadOnly = True
        Me.txtXMLOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtXMLOut.Size = New System.Drawing.Size(782, 402)
        Me.txtXMLOut.TabIndex = 123
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(3, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 28)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Inviato il"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInviatoIl
        '
        Me.lblInviatoIl.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(93, Byte), Integer))
        Me.lblInviatoIl.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblInviatoIl.ForeColor = System.Drawing.Color.White
        Me.lblInviatoIl.Location = New System.Drawing.Point(98, 33)
        Me.lblInviatoIl.Name = "lblInviatoIl"
        Me.lblInviatoIl.Size = New System.Drawing.Size(238, 28)
        Me.lblInviatoIl.TabIndex = 125
        Me.lblInviatoIl.Text = "-"
        Me.lblInviatoIl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtXMLIn
        '
        Me.txtXMLIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtXMLIn.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtXMLIn.Location = New System.Drawing.Point(3, 3)
        Me.txtXMLIn.Multiline = True
        Me.txtXMLIn.Name = "txtXMLIn"
        Me.txtXMLIn.ReadOnly = True
        Me.txtXMLIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtXMLIn.Size = New System.Drawing.Size(782, 402)
        Me.txtXMLIn.TabIndex = 127
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(3, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 28)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Info"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkGeneraXML
        '
        Me.lnkGeneraXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkGeneraXML.BackColor = System.Drawing.Color.White
        Me.lnkGeneraXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkGeneraXML.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkGeneraXML.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkGeneraXML.Image = Global.Former.My.Resources.Resources._xml
        Me.lnkGeneraXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkGeneraXML.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkGeneraXML.Location = New System.Drawing.Point(402, 3)
        Me.lnkGeneraXML.Name = "lnkGeneraXML"
        Me.lnkGeneraXML.Size = New System.Drawing.Size(101, 34)
        Me.lnkGeneraXML.TabIndex = 131
        Me.lnkGeneraXML.TabStop = True
        Me.lnkGeneraXML.Text = "Genera XML"
        Me.lnkGeneraXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkGeneraXML.Visible = False
        '
        'lnkSendXML
        '
        Me.lnkSendXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkSendXML.BackColor = System.Drawing.Color.White
        Me.lnkSendXML.Enabled = False
        Me.lnkSendXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkSendXML.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkSendXML.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSendXML.Image = Global.Former.My.Resources.Resources._CodaMetti
        Me.lnkSendXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSendXML.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSendXML.Location = New System.Drawing.Point(660, 4)
        Me.lnkSendXML.Name = "lnkSendXML"
        Me.lnkSendXML.Size = New System.Drawing.Size(135, 27)
        Me.lnkSendXML.TabIndex = 130
        Me.lnkSendXML.TabStop = True
        Me.lnkSendXML.Text = "In coda per INVIO"
        Me.lnkSendXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkExportXML
        '
        Me.lnkExportXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkExportXML.BackColor = System.Drawing.Color.White
        Me.lnkExportXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkExportXML.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkExportXML.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkExportXML.Image = Global.Former.My.Resources.Resources._Export
        Me.lnkExportXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkExportXML.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkExportXML.Location = New System.Drawing.Point(509, 3)
        Me.lnkExportXML.Name = "lnkExportXML"
        Me.lnkExportXML.Size = New System.Drawing.Size(100, 34)
        Me.lnkExportXML.TabIndex = 121
        Me.lnkExportXML.TabStop = True
        Me.lnkExportXML.Text = "Export XML"
        Me.lnkExportXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkExportXML.Visible = False
        '
        'lnkOutCoda
        '
        Me.lnkOutCoda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkOutCoda.BackColor = System.Drawing.Color.White
        Me.lnkOutCoda.Enabled = False
        Me.lnkOutCoda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkOutCoda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkOutCoda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkOutCoda.Image = Global.Former.My.Resources.Resources._CodaTogli
        Me.lnkOutCoda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkOutCoda.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkOutCoda.Location = New System.Drawing.Point(660, 31)
        Me.lnkOutCoda.Name = "lnkOutCoda"
        Me.lnkOutCoda.Size = New System.Drawing.Size(142, 27)
        Me.lnkOutCoda.TabIndex = 143
        Me.lnkOutCoda.TabStop = True
        Me.lnkOutCoda.Text = "Togli da coda INVIO"
        Me.lnkOutCoda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imlFattura
        '
        Me.imlFattura.ImageStream = CType(resources.GetObject("imlFattura.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlFattura.TransparentColor = System.Drawing.Color.Transparent
        Me.imlFattura.Images.SetKeyName(0, "_DocumentoFiscale.png")
        Me.imlFattura.Images.SetKeyName(1, "_xml.png")
        Me.imlFattura.Images.SetKeyName(2, "_Download.png")
        '
        'tabFattura
        '
        Me.tabFattura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabFattura.Controls.Add(Me.tpFattura)
        Me.tabFattura.Controls.Add(Me.tpXML)
        Me.tabFattura.Controls.Add(Me.TabPage1)
        Me.tabFattura.ImageList = Me.imlFattura
        Me.tabFattura.Location = New System.Drawing.Point(3, 125)
        Me.tabFattura.Name = "tabFattura"
        Me.tabFattura.SelectedIndex = 0
        Me.tabFattura.Size = New System.Drawing.Size(796, 445)
        Me.tabFattura.TabIndex = 144
        '
        'tpFattura
        '
        Me.tpFattura.Controls.Add(Me.webFattura)
        Me.tpFattura.ImageKey = "_DocumentoFiscale.png"
        Me.tpFattura.Location = New System.Drawing.Point(4, 33)
        Me.tpFattura.Name = "tpFattura"
        Me.tpFattura.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFattura.Size = New System.Drawing.Size(788, 408)
        Me.tpFattura.TabIndex = 0
        Me.tpFattura.Text = "Fattura Elettronica"
        Me.tpFattura.UseVisualStyleBackColor = True
        '
        'webFattura
        '
        Me.webFattura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webFattura.Location = New System.Drawing.Point(3, 3)
        Me.webFattura.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webFattura.Name = "webFattura"
        Me.webFattura.ScriptErrorsSuppressed = True
        Me.webFattura.Size = New System.Drawing.Size(782, 402)
        Me.webFattura.TabIndex = 0
        '
        'tpXML
        '
        Me.tpXML.Controls.Add(Me.txtXMLOut)
        Me.tpXML.ImageKey = "_xml.png"
        Me.tpXML.Location = New System.Drawing.Point(4, 33)
        Me.tpXML.Name = "tpXML"
        Me.tpXML.Padding = New System.Windows.Forms.Padding(3)
        Me.tpXML.Size = New System.Drawing.Size(788, 408)
        Me.tpXML.TabIndex = 1
        Me.tpXML.Text = "XML Inviato"
        Me.tpXML.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtXMLIn)
        Me.TabPage1.ImageKey = "_Download.png"
        Me.TabPage1.Location = New System.Drawing.Point(4, 33)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(788, 408)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "XML Ricevuto"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtInfo
        '
        Me.txtInfo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic)
        Me.txtInfo.Location = New System.Drawing.Point(99, 63)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInfo.Size = New System.Drawing.Size(510, 56)
        Me.txtInfo.TabIndex = 145
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.BackColor = System.Drawing.Color.White
        Me.lnkStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkStampa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(660, 63)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(77, 30)
        Me.lnkStampa.TabIndex = 146
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucDocumentiFiscaliXMLRicavo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.tabFattura)
        Me.Controls.Add(Me.lnkOutCoda)
        Me.Controls.Add(Me.lnkGeneraXML)
        Me.Controls.Add(Me.lnkSendXML)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblInviatoIl)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lnkExportXML)
        Me.Controls.Add(Me.lblAzienda)
        Me.Controls.Add(Me.lblStato)
        Me.Name = "ucDocumentiFiscaliXMLRicavo"
        Me.Size = New System.Drawing.Size(805, 573)
        Me.tabFattura.ResumeLayout(False)
        Me.tpFattura.ResumeLayout(False)
        Me.tpXML.ResumeLayout(False)
        Me.tpXML.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblStato As Label
    Friend WithEvents lblAzienda As Label
    Friend WithEvents lnkExportXML As LinkLabel
    Friend WithEvents txtXMLOut As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblInviatoIl As Label
    Friend WithEvents txtXMLIn As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lnkSendXML As LinkLabel
    Friend WithEvents lnkGeneraXML As LinkLabel
    Friend WithEvents lnkOutCoda As LinkLabel
    Friend WithEvents imlFattura As ImageList
    Friend WithEvents tabFattura As TabControl
    Friend WithEvents tpFattura As TabPage
    Friend WithEvents webFattura As WebBrowser
    Friend WithEvents tpXML As TabPage
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtInfo As TextBox
    Friend WithEvents lnkStampa As LinkLabel
End Class
