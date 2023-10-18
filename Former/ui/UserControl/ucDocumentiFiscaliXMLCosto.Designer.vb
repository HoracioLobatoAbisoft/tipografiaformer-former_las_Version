<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucDocumentiFiscaliXMLCosto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucDocumentiFiscaliXMLCosto))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblIdSDI = New System.Windows.Forms.Label()
        Me.lblInviatoIl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtXMLOut = New System.Windows.Forms.TextBox()
        Me.lnkImportXML = New System.Windows.Forms.LinkLabel()
        Me.lblAzienda = New System.Windows.Forms.Label()
        Me.lblStato = New System.Windows.Forms.Label()
        Me.dlgXML = New System.Windows.Forms.OpenFileDialog()
        Me.lblIdentificativo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabFattura = New System.Windows.Forms.TabControl()
        Me.tpFattura = New System.Windows.Forms.TabPage()
        Me.webFattura = New System.Windows.Forms.WebBrowser()
        Me.tpXML = New System.Windows.Forms.TabPage()
        Me.imlFattura = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblModalitaPagamento = New System.Windows.Forms.Label()
        Me.lblScadenza = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tabFattura.SuspendLayout()
        Me.tpFattura.SuspendLayout()
        Me.tpXML.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(469, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 28)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "ID Sdi"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Visible = False
        '
        'lblIdSDI
        '
        Me.lblIdSDI.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblIdSDI.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblIdSDI.ForeColor = System.Drawing.Color.White
        Me.lblIdSDI.Location = New System.Drawing.Point(564, 3)
        Me.lblIdSDI.Name = "lblIdSDI"
        Me.lblIdSDI.Size = New System.Drawing.Size(238, 28)
        Me.lblIdSDI.TabIndex = 137
        Me.lblIdSDI.Text = "-"
        Me.lblIdSDI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdSDI.Visible = False
        '
        'lblInviatoIl
        '
        Me.lblInviatoIl.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblInviatoIl.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblInviatoIl.ForeColor = System.Drawing.Color.White
        Me.lblInviatoIl.Location = New System.Drawing.Point(98, 32)
        Me.lblInviatoIl.Name = "lblInviatoIl"
        Me.lblInviatoIl.Size = New System.Drawing.Size(238, 28)
        Me.lblInviatoIl.TabIndex = 136
        Me.lblInviatoIl.Text = "-"
        Me.lblInviatoIl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(3, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 28)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "Ricevuto il"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtXMLOut.Size = New System.Drawing.Size(782, 468)
        Me.txtXMLOut.TabIndex = 134
        '
        'lnkImportXML
        '
        Me.lnkImportXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkImportXML.BackColor = System.Drawing.Color.White
        Me.lnkImportXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lnkImportXML.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkImportXML.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkImportXML.Image = Global.Former.My.Resources.Resources._CartellaAperta2
        Me.lnkImportXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkImportXML.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkImportXML.Location = New System.Drawing.Point(619, 91)
        Me.lnkImportXML.Name = "lnkImportXML"
        Me.lnkImportXML.Size = New System.Drawing.Size(100, 30)
        Me.lnkImportXML.TabIndex = 132
        Me.lnkImportXML.TabStop = True
        Me.lnkImportXML.Text = "Carica XML"
        Me.lnkImportXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAzienda
        '
        Me.lblAzienda.BackColor = System.Drawing.Color.White
        Me.lblAzienda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAzienda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblAzienda.Location = New System.Drawing.Point(3, 3)
        Me.lblAzienda.Name = "lblAzienda"
        Me.lblAzienda.Size = New System.Drawing.Size(89, 28)
        Me.lblAzienda.TabIndex = 131
        Me.lblAzienda.Text = "Stato"
        Me.lblAzienda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStato
        '
        Me.lblStato.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblStato.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblStato.ForeColor = System.Drawing.Color.White
        Me.lblStato.Location = New System.Drawing.Point(98, 3)
        Me.lblStato.Name = "lblStato"
        Me.lblStato.Size = New System.Drawing.Size(238, 28)
        Me.lblStato.TabIndex = 130
        Me.lblStato.Text = "-"
        Me.lblStato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dlgXML
        '
        Me.dlgXML.Filter = "File XML|*.xml"
        '
        'lblIdentificativo
        '
        Me.lblIdentificativo.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblIdentificativo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblIdentificativo.ForeColor = System.Drawing.Color.White
        Me.lblIdentificativo.Location = New System.Drawing.Point(564, 31)
        Me.lblIdentificativo.Name = "lblIdentificativo"
        Me.lblIdentificativo.Size = New System.Drawing.Size(500, 28)
        Me.lblIdentificativo.TabIndex = 140
        Me.lblIdentificativo.Text = "-"
        Me.lblIdentificativo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdentificativo.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(469, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 28)
        Me.Label5.TabIndex = 139
        Me.Label5.Text = "Identificativo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Visible = False
        '
        'tabFattura
        '
        Me.tabFattura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabFattura.Controls.Add(Me.tpFattura)
        Me.tabFattura.Controls.Add(Me.tpXML)
        Me.tabFattura.ImageList = Me.imlFattura
        Me.tabFattura.Location = New System.Drawing.Point(6, 122)
        Me.tabFattura.Name = "tabFattura"
        Me.tabFattura.SelectedIndex = 0
        Me.tabFattura.Size = New System.Drawing.Size(796, 479)
        Me.tabFattura.TabIndex = 141
        '
        'tpFattura
        '
        Me.tpFattura.Controls.Add(Me.webFattura)
        Me.tpFattura.ImageKey = "_DocumentoFiscale.png"
        Me.tpFattura.Location = New System.Drawing.Point(4, 33)
        Me.tpFattura.Name = "tpFattura"
        Me.tpFattura.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFattura.Size = New System.Drawing.Size(788, 442)
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
        Me.webFattura.Size = New System.Drawing.Size(782, 436)
        Me.webFattura.TabIndex = 0
        '
        'tpXML
        '
        Me.tpXML.Controls.Add(Me.txtXMLOut)
        Me.tpXML.ImageKey = "_xml.png"
        Me.tpXML.Location = New System.Drawing.Point(4, 33)
        Me.tpXML.Name = "tpXML"
        Me.tpXML.Padding = New System.Windows.Forms.Padding(3)
        Me.tpXML.Size = New System.Drawing.Size(788, 474)
        Me.tpXML.TabIndex = 1
        Me.tpXML.Text = "XML"
        Me.tpXML.UseVisualStyleBackColor = True
        '
        'imlFattura
        '
        Me.imlFattura.ImageStream = CType(resources.GetObject("imlFattura.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlFattura.TransparentColor = System.Drawing.Color.Transparent
        Me.imlFattura.Images.SetKeyName(0, "_DocumentoFiscale.png")
        Me.imlFattura.Images.SetKeyName(1, "_xml.png")
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
        Me.lnkStampa.Location = New System.Drawing.Point(725, 91)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(77, 30)
        Me.lnkStampa.TabIndex = 142
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 28)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "Pagamento"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModalitaPagamento
        '
        Me.lblModalitaPagamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblModalitaPagamento.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblModalitaPagamento.ForeColor = System.Drawing.Color.White
        Me.lblModalitaPagamento.Location = New System.Drawing.Point(98, 61)
        Me.lblModalitaPagamento.Name = "lblModalitaPagamento"
        Me.lblModalitaPagamento.Size = New System.Drawing.Size(238, 28)
        Me.lblModalitaPagamento.TabIndex = 144
        Me.lblModalitaPagamento.Text = "-"
        Me.lblModalitaPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScadenza
        '
        Me.lblScadenza.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblScadenza.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblScadenza.ForeColor = System.Drawing.Color.White
        Me.lblScadenza.Location = New System.Drawing.Point(98, 90)
        Me.lblScadenza.Name = "lblScadenza"
        Me.lblScadenza.Size = New System.Drawing.Size(238, 28)
        Me.lblScadenza.TabIndex = 146
        Me.lblScadenza.Text = "-"
        Me.lblScadenza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(3, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 28)
        Me.Label6.TabIndex = 145
        Me.Label6.Text = "Scadenza"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ucDocumentiFiscaliXMLCosto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lblScadenza)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblModalitaPagamento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblIdSDI)
        Me.Controls.Add(Me.lnkStampa)
        Me.Controls.Add(Me.tabFattura)
        Me.Controls.Add(Me.lblIdentificativo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblInviatoIl)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lnkImportXML)
        Me.Controls.Add(Me.lblAzienda)
        Me.Controls.Add(Me.lblStato)
        Me.Name = "ucDocumentiFiscaliXMLCosto"
        Me.Size = New System.Drawing.Size(805, 606)
        Me.tabFattura.ResumeLayout(False)
        Me.tpFattura.ResumeLayout(False)
        Me.tpXML.ResumeLayout(False)
        Me.tpXML.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents lblIdSDI As Label
    Friend WithEvents lblInviatoIl As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtXMLOut As TextBox
    Friend WithEvents lnkImportXML As LinkLabel
    Friend WithEvents lblAzienda As Label
    Friend WithEvents lblStato As Label
    Friend WithEvents dlgXML As OpenFileDialog
    Friend WithEvents lblIdentificativo As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tabFattura As TabControl
    Friend WithEvents tpFattura As TabPage
    Friend WithEvents tpXML As TabPage
    Friend WithEvents imlFattura As ImageList
    Friend WithEvents webFattura As WebBrowser
    Friend WithEvents lnkStampa As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblModalitaPagamento As Label
    Friend WithEvents lblScadenza As Label
    Friend WithEvents Label6 As Label
End Class
