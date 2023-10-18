<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAmministrazioneContabilita
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucAmministrazioneContabilita))
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tpStampe = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDescr = New System.Windows.Forms.Label()
        Me.tpF24 = New System.Windows.Forms.TabPage()
        Me.UcAmministrazioneF24 = New Former.ucAmministrazioneF24()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lnkPrimaNota = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnkInventarioMagazzino = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lnkStampaDocEmessiIncassati = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lnkStampaFlussi = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lnkStampaConteggi = New System.Windows.Forms.LinkLabel()
        Me.lblCarichiMagazzinoAnomalia = New System.Windows.Forms.Label()
        Me.lnkStampaBilancio = New System.Windows.Forms.LinkLabel()
        Me.cmbAnno = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbMese = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tabMain.SuspendLayout()
        Me.tpStampe.SuspendLayout()
        Me.tpF24.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tpStampe)
        Me.tabMain.Controls.Add(Me.tpF24)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.ImageList = Me.imlTab
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(805, 540)
        Me.tabMain.TabIndex = 0
        '
        'tpStampe
        '
        Me.tpStampe.Controls.Add(Me.cmbMese)
        Me.tpStampe.Controls.Add(Me.Label12)
        Me.tpStampe.Controls.Add(Me.cmbAnno)
        Me.tpStampe.Controls.Add(Me.Label11)
        Me.tpStampe.Controls.Add(Me.Label9)
        Me.tpStampe.Controls.Add(Me.Label10)
        Me.tpStampe.Controls.Add(Me.lnkPrimaNota)
        Me.tpStampe.Controls.Add(Me.Label1)
        Me.tpStampe.Controls.Add(Me.Label2)
        Me.tpStampe.Controls.Add(Me.lnkInventarioMagazzino)
        Me.tpStampe.Controls.Add(Me.Label7)
        Me.tpStampe.Controls.Add(Me.Label8)
        Me.tpStampe.Controls.Add(Me.lnkStampaDocEmessiIncassati)
        Me.tpStampe.Controls.Add(Me.Label5)
        Me.tpStampe.Controls.Add(Me.Label6)
        Me.tpStampe.Controls.Add(Me.lnkStampaFlussi)
        Me.tpStampe.Controls.Add(Me.Label3)
        Me.tpStampe.Controls.Add(Me.Label4)
        Me.tpStampe.Controls.Add(Me.lnkStampaConteggi)
        Me.tpStampe.Controls.Add(Me.lblCarichiMagazzinoAnomalia)
        Me.tpStampe.Controls.Add(Me.lblDescr)
        Me.tpStampe.Controls.Add(Me.lnkStampaBilancio)
        Me.tpStampe.ImageKey = "_Stampa.png"
        Me.tpStampe.Location = New System.Drawing.Point(4, 33)
        Me.tpStampe.Name = "tpStampe"
        Me.tpStampe.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStampe.Size = New System.Drawing.Size(797, 503)
        Me.tpStampe.TabIndex = 0
        Me.tpStampe.Text = "Stampe Fiscali"
        Me.tpStampe.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(81, 302)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(295, 35)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Report Inventario di Magazzino"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(81, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(295, 35)
        Me.Label8.TabIndex = 114
        Me.Label8.Text = "Report Documenti Emessi e Incassati Mensili"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(81, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(295, 35)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "Report Flussi Mensili"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(81, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(295, 35)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Report Conteggi Mensili IVA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescr
        '
        Me.lblDescr.BackColor = System.Drawing.Color.Transparent
        Me.lblDescr.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescr.Location = New System.Drawing.Point(81, 26)
        Me.lblDescr.Name = "lblDescr"
        Me.lblDescr.Size = New System.Drawing.Size(295, 35)
        Me.lblDescr.TabIndex = 102
        Me.lblDescr.Text = "Bilancio previsionale annuale"
        Me.lblDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpF24
        '
        Me.tpF24.Controls.Add(Me.UcAmministrazioneF24)
        Me.tpF24.ImageKey = "_F24.png"
        Me.tpF24.Location = New System.Drawing.Point(4, 33)
        Me.tpF24.Name = "tpF24"
        Me.tpF24.Padding = New System.Windows.Forms.Padding(3)
        Me.tpF24.Size = New System.Drawing.Size(797, 503)
        Me.tpF24.TabIndex = 1
        Me.tpF24.Text = "F24"
        Me.tpF24.UseVisualStyleBackColor = True
        '
        'UcAmministrazioneF24
        '
        Me.UcAmministrazioneF24.BackColor = System.Drawing.Color.White
        Me.UcAmministrazioneF24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazioneF24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazioneF24.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazioneF24.Name = "UcAmministrazioneF24"
        Me.UcAmministrazioneF24.Size = New System.Drawing.Size(791, 497)
        Me.UcAmministrazioneF24.TabIndex = 0
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "_F24.png")
        Me.imlTab.Images.SetKeyName(1, "_Stampa.png")
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(81, 373)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 35)
        Me.Label10.TabIndex = 120
        Me.Label10.Text = "Report Prima Nota SRL"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Image = Global.Former.My.Resources.Resources._PrimaNota
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Location = New System.Drawing.Point(23, 364)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 45)
        Me.Label9.TabIndex = 119
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkPrimaNota
        '
        Me.lnkPrimaNota.AutoSize = True
        Me.lnkPrimaNota.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkPrimaNota.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkPrimaNota.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkPrimaNota.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkPrimaNota.Location = New System.Drawing.Point(558, 378)
        Me.lnkPrimaNota.Name = "lnkPrimaNota"
        Me.lnkPrimaNota.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkPrimaNota.Size = New System.Drawing.Size(79, 27)
        Me.lnkPrimaNota.TabIndex = 121
        Me.lnkPrimaNota.TabStop = True
        Me.lnkPrimaNota.Text = "Stampa"
        Me.lnkPrimaNota.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Image = Global.Former.My.Resources.Resources._Magazzino48
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(23, 293)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 45)
        Me.Label1.TabIndex = 116
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkInventarioMagazzino
        '
        Me.lnkInventarioMagazzino.AutoSize = True
        Me.lnkInventarioMagazzino.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkInventarioMagazzino.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkInventarioMagazzino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkInventarioMagazzino.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkInventarioMagazzino.Location = New System.Drawing.Point(558, 307)
        Me.lnkInventarioMagazzino.Name = "lnkInventarioMagazzino"
        Me.lnkInventarioMagazzino.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkInventarioMagazzino.Size = New System.Drawing.Size(79, 27)
        Me.lnkInventarioMagazzino.TabIndex = 118
        Me.lnkInventarioMagazzino.TabStop = True
        Me.lnkInventarioMagazzino.Text = "Stampa"
        Me.lnkInventarioMagazzino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Image = Global.Former.My.Resources.Resources._documenti48
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(23, 220)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 45)
        Me.Label7.TabIndex = 113
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkStampaDocEmessiIncassati
        '
        Me.lnkStampaDocEmessiIncassati.AutoSize = True
        Me.lnkStampaDocEmessiIncassati.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkStampaDocEmessiIncassati.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampaDocEmessiIncassati.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampaDocEmessiIncassati.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampaDocEmessiIncassati.Location = New System.Drawing.Point(558, 234)
        Me.lnkStampaDocEmessiIncassati.Name = "lnkStampaDocEmessiIncassati"
        Me.lnkStampaDocEmessiIncassati.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkStampaDocEmessiIncassati.Size = New System.Drawing.Size(79, 27)
        Me.lnkStampaDocEmessiIncassati.TabIndex = 115
        Me.lnkStampaDocEmessiIncassati.TabStop = True
        Me.lnkStampaDocEmessiIncassati.Text = "Stampa"
        Me.lnkStampaDocEmessiIncassati.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Image = Global.Former.My.Resources.Resources._FlussiMensili48
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(23, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 45)
        Me.Label5.TabIndex = 110
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkStampaFlussi
        '
        Me.lnkStampaFlussi.AutoSize = True
        Me.lnkStampaFlussi.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkStampaFlussi.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampaFlussi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampaFlussi.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampaFlussi.Location = New System.Drawing.Point(558, 165)
        Me.lnkStampaFlussi.Name = "lnkStampaFlussi"
        Me.lnkStampaFlussi.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkStampaFlussi.Size = New System.Drawing.Size(79, 27)
        Me.lnkStampaFlussi.TabIndex = 112
        Me.lnkStampaFlussi.TabStop = True
        Me.lnkStampaFlussi.Text = "Stampa"
        Me.lnkStampaFlussi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Image = Global.Former.My.Resources.Resources._calendario48
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(23, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 45)
        Me.Label3.TabIndex = 107
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkStampaConteggi
        '
        Me.lnkStampaConteggi.AutoSize = True
        Me.lnkStampaConteggi.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkStampaConteggi.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampaConteggi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampaConteggi.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampaConteggi.Location = New System.Drawing.Point(558, 97)
        Me.lnkStampaConteggi.Name = "lnkStampaConteggi"
        Me.lnkStampaConteggi.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkStampaConteggi.Size = New System.Drawing.Size(79, 27)
        Me.lnkStampaConteggi.TabIndex = 109
        Me.lnkStampaConteggi.TabStop = True
        Me.lnkStampaConteggi.Text = "Stampa"
        Me.lnkStampaConteggi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCarichiMagazzinoAnomalia
        '
        Me.lblCarichiMagazzinoAnomalia.BackColor = System.Drawing.Color.Transparent
        Me.lblCarichiMagazzinoAnomalia.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarichiMagazzinoAnomalia.Image = Global.Former.My.Resources.Resources._Bilancio48
        Me.lblCarichiMagazzinoAnomalia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCarichiMagazzinoAnomalia.Location = New System.Drawing.Point(23, 17)
        Me.lblCarichiMagazzinoAnomalia.Name = "lblCarichiMagazzinoAnomalia"
        Me.lblCarichiMagazzinoAnomalia.Size = New System.Drawing.Size(52, 45)
        Me.lblCarichiMagazzinoAnomalia.TabIndex = 101
        Me.lblCarichiMagazzinoAnomalia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkStampaBilancio
        '
        Me.lnkStampaBilancio.AutoSize = True
        Me.lnkStampaBilancio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lnkStampaBilancio.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampaBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampaBilancio.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampaBilancio.Location = New System.Drawing.Point(558, 31)
        Me.lnkStampaBilancio.Name = "lnkStampaBilancio"
        Me.lnkStampaBilancio.Padding = New System.Windows.Forms.Padding(30, 6, 0, 6)
        Me.lnkStampaBilancio.Size = New System.Drawing.Size(79, 27)
        Me.lnkStampaBilancio.TabIndex = 103
        Me.lnkStampaBilancio.TabStop = True
        Me.lnkStampaBilancio.Text = "Stampa"
        Me.lnkStampaBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbAnno
        '
        Me.cmbAnno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnno.FormattingEnabled = True
        Me.cmbAnno.Location = New System.Drawing.Point(282, 381)
        Me.cmbAnno.Name = "cmbAnno"
        Me.cmbAnno.Size = New System.Drawing.Size(61, 23)
        Me.cmbAnno.TabIndex = 122
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(240, 384)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 15)
        Me.Label11.TabIndex = 123
        Me.Label11.Text = "Anno"
        '
        'cmbMese
        '
        Me.cmbMese.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMese.FormattingEnabled = True
        Me.cmbMese.Location = New System.Drawing.Point(390, 381)
        Me.cmbMese.Name = "cmbMese"
        Me.cmbMese.Size = New System.Drawing.Size(94, 23)
        Me.cmbMese.TabIndex = 124
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(349, 384)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 15)
        Me.Label12.TabIndex = 125
        Me.Label12.Text = "Mese"
        '
        'ucAmministrazioneContabilita
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tabMain)
        Me.Name = "ucAmministrazioneContabilita"
        Me.Size = New System.Drawing.Size(805, 540)
        Me.tabMain.ResumeLayout(False)
        Me.tpStampe.ResumeLayout(False)
        Me.tpStampe.PerformLayout()
        Me.tpF24.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabMain As TabControl
    Friend WithEvents tpStampe As TabPage
    Friend WithEvents tpF24 As TabPage
    Friend WithEvents imlTab As ImageList
    Friend WithEvents UcAmministrazioneF24 As ucAmministrazioneF24
    Friend WithEvents lblCarichiMagazzinoAnomalia As Label
    Friend WithEvents lblDescr As Label
    Friend WithEvents lnkStampaBilancio As LinkLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lnkStampaDocEmessiIncassati As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lnkStampaFlussi As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lnkStampaConteggi As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lnkInventarioMagazzino As LinkLabel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lnkPrimaNota As LinkLabel
    Friend WithEvents cmbMese As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbAnno As ComboBox
    Friend WithEvents Label11 As Label
End Class
