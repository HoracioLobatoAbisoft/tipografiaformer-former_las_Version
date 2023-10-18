<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMain
    Inherits ucFormerUserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMain))
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbOrdini = New System.Windows.Forms.TabPage()
        Me.SplitContainerOrdini = New System.Windows.Forms.SplitContainer()
        Me.UcOrdini = New Former.ucOrdini()
        Me.UcOrdineAnteprima = New Former.ucOrdiniAnteprima()
        Me.tpProduzione = New System.Windows.Forms.TabPage()
        Me.UcProduzione = New Former.ucProduzione()
        Me.tpConsegneReali = New System.Windows.Forms.TabPage()
        Me.UcConsegneSettimana = New Former.ucConsegneSettimana()
        Me.tpOrdiniFatturare = New System.Windows.Forms.TabPage()
        Me.UcOrdiniFatt = New Former.ucOrdiniDaFatturare()
        Me.tbBilancio = New System.Windows.Forms.TabPage()
        Me.UcFatture = New Former.ucAmministrazione()
        Me.tpMagazzino = New System.Windows.Forms.TabPage()
        Me.UcMagazzinoMain = New Former.ucMagazzinoMain()
        Me.tpEmailInEntrata = New System.Windows.Forms.TabPage()
        Me.UcPreventiviMail = New Former.ucMail()
        Me.tpMessaggi = New System.Windows.Forms.TabPage()
        Me.UcMessaggi = New Former.ucMessaggiInterni()
        Me.tpMarketing = New System.Windows.Forms.TabPage()
        Me.UcMarketing = New Former.ucMarketing()
        Me.tpListino = New System.Windows.Forms.TabPage()
        Me.UcListino = New Former.ucListino()
        Me.tpSitoWeb = New System.Windows.Forms.TabPage()
        Me.UcSitoWeb = New Former.ucSitoWeb()
        Me.tbParametri = New System.Windows.Forms.TabPage()
        Me.UcParametri = New Former.ucAmministrazioneParametri()
        Me.tbOperatore = New System.Windows.Forms.TabPage()
        Me.UcOperatore = New Former.ucOperatore()
        Me.imlFunzNew = New System.Windows.Forms.ImageList(Me.components)
        Me.TabMain.SuspendLayout()
        Me.tbOrdini.SuspendLayout()
        CType(Me.SplitContainerOrdini, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerOrdini.Panel1.SuspendLayout()
        Me.SplitContainerOrdini.Panel2.SuspendLayout()
        Me.SplitContainerOrdini.SuspendLayout()
        Me.tpProduzione.SuspendLayout()
        Me.tpConsegneReali.SuspendLayout()
        Me.tpOrdiniFatturare.SuspendLayout()
        Me.tbBilancio.SuspendLayout()
        Me.tpMagazzino.SuspendLayout()
        Me.tpEmailInEntrata.SuspendLayout()
        Me.tpMessaggi.SuspendLayout()
        Me.tpMarketing.SuspendLayout()
        Me.tpListino.SuspendLayout()
        Me.tpSitoWeb.SuspendLayout()
        Me.tbParametri.SuspendLayout()
        Me.tbOperatore.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbOrdini)
        Me.TabMain.Controls.Add(Me.tpProduzione)
        Me.TabMain.Controls.Add(Me.tpConsegneReali)
        Me.TabMain.Controls.Add(Me.tpOrdiniFatturare)
        Me.TabMain.Controls.Add(Me.tbBilancio)
        Me.TabMain.Controls.Add(Me.tpMagazzino)
        Me.TabMain.Controls.Add(Me.tpEmailInEntrata)
        Me.TabMain.Controls.Add(Me.tpMessaggi)
        Me.TabMain.Controls.Add(Me.tpMarketing)
        Me.TabMain.Controls.Add(Me.tpListino)
        Me.TabMain.Controls.Add(Me.tpSitoWeb)
        Me.TabMain.Controls.Add(Me.tbParametri)
        Me.TabMain.Controls.Add(Me.tbOperatore)
        Me.TabMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TabMain.HotTrack = True
        Me.TabMain.ImageList = Me.imlFunzNew
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1458, 683)
        Me.TabMain.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabMain.TabIndex = 3
        '
        'tbOrdini
        '
        Me.tbOrdini.Controls.Add(Me.SplitContainerOrdini)
        Me.tbOrdini.ImageKey = "_Ordine.png"
        Me.tbOrdini.Location = New System.Drawing.Point(4, 31)
        Me.tbOrdini.Name = "tbOrdini"
        Me.tbOrdini.Size = New System.Drawing.Size(1450, 648)
        Me.tbOrdini.TabIndex = 5
        Me.tbOrdini.Text = "Lavori"
        Me.tbOrdini.UseVisualStyleBackColor = True
        '
        'SplitContainerOrdini
        '
        Me.SplitContainerOrdini.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerOrdini.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerOrdini.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerOrdini.Name = "SplitContainerOrdini"
        '
        'SplitContainerOrdini.Panel1
        '
        Me.SplitContainerOrdini.Panel1.Controls.Add(Me.UcOrdini)
        '
        'SplitContainerOrdini.Panel2
        '
        Me.SplitContainerOrdini.Panel2.Controls.Add(Me.UcOrdineAnteprima)
        Me.SplitContainerOrdini.Size = New System.Drawing.Size(1450, 648)
        Me.SplitContainerOrdini.SplitterDistance = 995
        Me.SplitContainerOrdini.SplitterWidth = 5
        Me.SplitContainerOrdini.TabIndex = 0
        '
        'UcOrdini
        '
        Me.UcOrdini.BackColor = System.Drawing.Color.White
        Me.UcOrdini.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOrdini.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdini.IdRub = 0
        Me.UcOrdini.Location = New System.Drawing.Point(0, 0)
        Me.UcOrdini.Name = "UcOrdini"
        Me.UcOrdini.Size = New System.Drawing.Size(995, 648)
        Me.UcOrdini.TabIndex = 52
        '
        'UcOrdineAnteprima
        '
        Me.UcOrdineAnteprima.BackColor = System.Drawing.Color.White
        Me.UcOrdineAnteprima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOrdineAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdineAnteprima.Location = New System.Drawing.Point(0, 0)
        Me.UcOrdineAnteprima.Name = "UcOrdineAnteprima"
        Me.UcOrdineAnteprima.NascondiResto = False
        Me.UcOrdineAnteprima.NoLavori = False
        Me.UcOrdineAnteprima.Size = New System.Drawing.Size(450, 648)
        Me.UcOrdineAnteprima.TabIndex = 1
        '
        'tpProduzione
        '
        Me.tpProduzione.Controls.Add(Me.UcProduzione)
        Me.tpProduzione.ImageKey = "_Commessa.png"
        Me.tpProduzione.Location = New System.Drawing.Point(4, 31)
        Me.tpProduzione.Name = "tpProduzione"
        Me.tpProduzione.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProduzione.Size = New System.Drawing.Size(1450, 648)
        Me.tpProduzione.TabIndex = 12
        Me.tpProduzione.Tag = "Produzione"
        Me.tpProduzione.Text = "Produzione"
        Me.tpProduzione.UseVisualStyleBackColor = True
        '
        'UcProduzione
        '
        Me.UcProduzione.BackColor = System.Drawing.Color.White
        Me.UcProduzione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcProduzione.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcProduzione.Location = New System.Drawing.Point(3, 3)
        Me.UcProduzione.Name = "UcProduzione"
        Me.UcProduzione.Size = New System.Drawing.Size(1444, 642)
        Me.UcProduzione.TabIndex = 0
        '
        'tpConsegneReali
        '
        Me.tpConsegneReali.Controls.Add(Me.UcConsegneSettimana)
        Me.tpConsegneReali.ImageKey = "_Consegna.png"
        Me.tpConsegneReali.Location = New System.Drawing.Point(4, 31)
        Me.tpConsegneReali.Name = "tpConsegneReali"
        Me.tpConsegneReali.Padding = New System.Windows.Forms.Padding(3)
        Me.tpConsegneReali.Size = New System.Drawing.Size(1450, 648)
        Me.tpConsegneReali.TabIndex = 17
        Me.tpConsegneReali.Text = "Consegne"
        Me.tpConsegneReali.UseVisualStyleBackColor = True
        '
        'UcConsegneSettimana
        '
        Me.UcConsegneSettimana.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UcConsegneSettimana.BackColor = System.Drawing.Color.White
        Me.UcConsegneSettimana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcConsegneSettimana.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcConsegneSettimana.Location = New System.Drawing.Point(3, 3)
        Me.UcConsegneSettimana.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcConsegneSettimana.Name = "UcConsegneSettimana"
        Me.UcConsegneSettimana.Size = New System.Drawing.Size(1444, 642)
        Me.UcConsegneSettimana.TabIndex = 0
        '
        'tpOrdiniFatturare
        '
        Me.tpOrdiniFatturare.Controls.Add(Me.UcOrdiniFatt)
        Me.tpOrdiniFatturare.ImageKey = "_Consegna.png"
        Me.tpOrdiniFatturare.Location = New System.Drawing.Point(4, 31)
        Me.tpOrdiniFatturare.Name = "tpOrdiniFatturare"
        Me.tpOrdiniFatturare.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrdiniFatturare.Size = New System.Drawing.Size(1450, 648)
        Me.tpOrdiniFatturare.TabIndex = 21
        Me.tpOrdiniFatturare.Text = "Consegne"
        Me.tpOrdiniFatturare.UseVisualStyleBackColor = True
        '
        'UcOrdiniFatt
        '
        Me.UcOrdiniFatt.BackColor = System.Drawing.Color.White
        Me.UcOrdiniFatt.Cursor = System.Windows.Forms.Cursors.Default
        Me.UcOrdiniFatt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOrdiniFatt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdiniFatt.Location = New System.Drawing.Point(3, 3)
        Me.UcOrdiniFatt.Name = "UcOrdiniFatt"
        Me.UcOrdiniFatt.Size = New System.Drawing.Size(1444, 642)
        Me.UcOrdiniFatt.TabIndex = 0
        '
        'tbBilancio
        '
        Me.tbBilancio.Controls.Add(Me.UcFatture)
        Me.tbBilancio.ImageKey = "_bank.png"
        Me.tbBilancio.Location = New System.Drawing.Point(4, 31)
        Me.tbBilancio.Name = "tbBilancio"
        Me.tbBilancio.Padding = New System.Windows.Forms.Padding(3)
        Me.tbBilancio.Size = New System.Drawing.Size(1450, 648)
        Me.tbBilancio.TabIndex = 1
        Me.tbBilancio.Text = "Amministrazione"
        Me.tbBilancio.UseVisualStyleBackColor = True
        '
        'UcFatture
        '
        Me.UcFatture.BackColor = System.Drawing.Color.Transparent
        Me.UcFatture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcFatture.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcFatture.IdRub = 0
        Me.UcFatture.Location = New System.Drawing.Point(3, 3)
        Me.UcFatture.Name = "UcFatture"
        Me.UcFatture.Size = New System.Drawing.Size(1444, 642)
        Me.UcFatture.TabIndex = 48
        '
        'tpMagazzino
        '
        Me.tpMagazzino.Controls.Add(Me.UcMagazzinoMain)
        Me.tpMagazzino.ImageKey = "_magazzino26.png"
        Me.tpMagazzino.Location = New System.Drawing.Point(4, 31)
        Me.tpMagazzino.Name = "tpMagazzino"
        Me.tpMagazzino.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMagazzino.Size = New System.Drawing.Size(1450, 648)
        Me.tpMagazzino.TabIndex = 25
        Me.tpMagazzino.Text = "Magazzino"
        Me.tpMagazzino.UseVisualStyleBackColor = True
        '
        'UcMagazzinoMain
        '
        Me.UcMagazzinoMain.BackColor = System.Drawing.Color.White
        Me.UcMagazzinoMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMagazzinoMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMagazzinoMain.Location = New System.Drawing.Point(3, 3)
        Me.UcMagazzinoMain.Name = "UcMagazzinoMain"
        Me.UcMagazzinoMain.Size = New System.Drawing.Size(1444, 642)
        Me.UcMagazzinoMain.TabIndex = 0
        '
        'tpEmailInEntrata
        '
        Me.tpEmailInEntrata.Controls.Add(Me.UcPreventiviMail)
        Me.tpEmailInEntrata.ImageKey = "_Mail.png"
        Me.tpEmailInEntrata.Location = New System.Drawing.Point(4, 31)
        Me.tpEmailInEntrata.Name = "tpEmailInEntrata"
        Me.tpEmailInEntrata.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEmailInEntrata.Size = New System.Drawing.Size(1450, 648)
        Me.tpEmailInEntrata.TabIndex = 24
        Me.tpEmailInEntrata.Text = "Email"
        Me.tpEmailInEntrata.UseVisualStyleBackColor = True
        '
        'UcPreventiviMail
        '
        Me.UcPreventiviMail.BackColor = System.Drawing.Color.White
        Me.UcPreventiviMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcPreventiviMail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcPreventiviMail.Location = New System.Drawing.Point(3, 3)
        Me.UcPreventiviMail.Name = "UcPreventiviMail"
        Me.UcPreventiviMail.Size = New System.Drawing.Size(1444, 642)
        Me.UcPreventiviMail.TabIndex = 0
        '
        'tpMessaggi
        '
        Me.tpMessaggi.Controls.Add(Me.UcMessaggi)
        Me.tpMessaggi.ImageKey = "_Messaggio.png"
        Me.tpMessaggi.Location = New System.Drawing.Point(4, 31)
        Me.tpMessaggi.Name = "tpMessaggi"
        Me.tpMessaggi.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMessaggi.Size = New System.Drawing.Size(1450, 648)
        Me.tpMessaggi.TabIndex = 20
        Me.tpMessaggi.Text = "Messaggi"
        Me.tpMessaggi.UseVisualStyleBackColor = True
        '
        'UcMessaggi
        '
        Me.UcMessaggi.BackColor = System.Drawing.Color.White
        Me.UcMessaggi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMessaggi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMessaggi.Location = New System.Drawing.Point(3, 3)
        Me.UcMessaggi.Name = "UcMessaggi"
        Me.UcMessaggi.Size = New System.Drawing.Size(1444, 642)
        Me.UcMessaggi.TabIndex = 0
        '
        'tpMarketing
        '
        Me.tpMarketing.Controls.Add(Me.UcMarketing)
        Me.tpMarketing.ImageKey = "_Marketing.png"
        Me.tpMarketing.Location = New System.Drawing.Point(4, 31)
        Me.tpMarketing.Name = "tpMarketing"
        Me.tpMarketing.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMarketing.Size = New System.Drawing.Size(1450, 648)
        Me.tpMarketing.TabIndex = 18
        Me.tpMarketing.Text = "Marketing"
        Me.tpMarketing.UseVisualStyleBackColor = True
        '
        'UcMarketing
        '
        Me.UcMarketing.BackColor = System.Drawing.Color.White
        Me.UcMarketing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMarketing.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcMarketing.IdRis = 0
        Me.UcMarketing.Location = New System.Drawing.Point(3, 3)
        Me.UcMarketing.Name = "UcMarketing"
        Me.UcMarketing.Size = New System.Drawing.Size(1444, 642)
        Me.UcMarketing.TabIndex = 0
        '
        'tpListino
        '
        Me.tpListino.Controls.Add(Me.UcListino)
        Me.tpListino.ImageKey = "_ListinoBase.png"
        Me.tpListino.Location = New System.Drawing.Point(4, 31)
        Me.tpListino.Name = "tpListino"
        Me.tpListino.Padding = New System.Windows.Forms.Padding(3)
        Me.tpListino.Size = New System.Drawing.Size(1450, 648)
        Me.tpListino.TabIndex = 22
        Me.tpListino.Text = "Listino"
        Me.tpListino.UseVisualStyleBackColor = True
        '
        'UcListino
        '
        Me.UcListino.BackColor = System.Drawing.Color.White
        Me.UcListino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcListino.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcListino.Location = New System.Drawing.Point(3, 3)
        Me.UcListino.Name = "UcListino"
        Me.UcListino.Size = New System.Drawing.Size(1444, 642)
        Me.UcListino.TabIndex = 0
        '
        'tpSitoWeb
        '
        Me.tpSitoWeb.Controls.Add(Me.UcSitoWeb)
        Me.tpSitoWeb.ImageKey = "_internet.png"
        Me.tpSitoWeb.Location = New System.Drawing.Point(4, 31)
        Me.tpSitoWeb.Name = "tpSitoWeb"
        Me.tpSitoWeb.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSitoWeb.Size = New System.Drawing.Size(1450, 648)
        Me.tpSitoWeb.TabIndex = 23
        Me.tpSitoWeb.Text = "Sito Web"
        Me.tpSitoWeb.UseVisualStyleBackColor = True
        '
        'UcSitoWeb
        '
        Me.UcSitoWeb.BackColor = System.Drawing.Color.White
        Me.UcSitoWeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSitoWeb.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcSitoWeb.Location = New System.Drawing.Point(3, 3)
        Me.UcSitoWeb.Name = "UcSitoWeb"
        Me.UcSitoWeb.Size = New System.Drawing.Size(1444, 642)
        Me.UcSitoWeb.TabIndex = 0
        '
        'tbParametri
        '
        Me.tbParametri.Controls.Add(Me.UcParametri)
        Me.tbParametri.ImageKey = "_Opzioni.png"
        Me.tbParametri.Location = New System.Drawing.Point(4, 31)
        Me.tbParametri.Name = "tbParametri"
        Me.tbParametri.Padding = New System.Windows.Forms.Padding(3)
        Me.tbParametri.Size = New System.Drawing.Size(1450, 648)
        Me.tbParametri.TabIndex = 10
        Me.tbParametri.Text = "Altro..."
        Me.tbParametri.UseVisualStyleBackColor = True
        '
        'UcParametri
        '
        Me.UcParametri.BackColor = System.Drawing.Color.White
        Me.UcParametri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcParametri.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcParametri.Location = New System.Drawing.Point(3, 3)
        Me.UcParametri.Name = "UcParametri"
        Me.UcParametri.Size = New System.Drawing.Size(1444, 642)
        Me.UcParametri.TabIndex = 0
        '
        'tbOperatore
        '
        Me.tbOperatore.Controls.Add(Me.UcOperatore)
        Me.tbOperatore.ImageKey = "user.png"
        Me.tbOperatore.Location = New System.Drawing.Point(4, 31)
        Me.tbOperatore.Name = "tbOperatore"
        Me.tbOperatore.Padding = New System.Windows.Forms.Padding(3)
        Me.tbOperatore.Size = New System.Drawing.Size(1450, 648)
        Me.tbOperatore.TabIndex = 13
        Me.tbOperatore.Text = "Operatore"
        Me.tbOperatore.UseVisualStyleBackColor = True
        '
        'UcOperatore
        '
        Me.UcOperatore.BackColor = System.Drawing.Color.White
        Me.UcOperatore.Cursor = System.Windows.Forms.Cursors.Default
        Me.UcOperatore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOperatore.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOperatore.Location = New System.Drawing.Point(3, 3)
        Me.UcOperatore.Name = "UcOperatore"
        Me.UcOperatore.Size = New System.Drawing.Size(1444, 642)
        Me.UcOperatore.TabIndex = 0
        '
        'imlFunzNew
        '
        Me.imlFunzNew.ImageStream = CType(resources.GetObject("imlFunzNew.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlFunzNew.TransparentColor = System.Drawing.Color.Transparent
        Me.imlFunzNew.Images.SetKeyName(0, "_Ordine.png")
        Me.imlFunzNew.Images.SetKeyName(1, "user.png")
        Me.imlFunzNew.Images.SetKeyName(2, "_Commessa.png")
        Me.imlFunzNew.Images.SetKeyName(3, "_internet.png")
        Me.imlFunzNew.Images.SetKeyName(4, "_ListinoBase.png")
        Me.imlFunzNew.Images.SetKeyName(5, "_Opzioni.png")
        Me.imlFunzNew.Images.SetKeyName(6, "_Messaggio.png")
        Me.imlFunzNew.Images.SetKeyName(7, "_Mail.png")
        Me.imlFunzNew.Images.SetKeyName(8, "_Consegna.png")
        Me.imlFunzNew.Images.SetKeyName(9, "_magazzino26.png")
        Me.imlFunzNew.Images.SetKeyName(10, "_bank.png")
        Me.imlFunzNew.Images.SetKeyName(11, "_Marketing.png")
        '
        'ucMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.TabMain)
        Me.Name = "ucMain"
        Me.Size = New System.Drawing.Size(1458, 683)
        Me.TabMain.ResumeLayout(False)
        Me.tbOrdini.ResumeLayout(False)
        Me.SplitContainerOrdini.Panel1.ResumeLayout(False)
        Me.SplitContainerOrdini.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerOrdini, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerOrdini.ResumeLayout(False)
        Me.tpProduzione.ResumeLayout(False)
        Me.tpConsegneReali.ResumeLayout(False)
        Me.tpOrdiniFatturare.ResumeLayout(False)
        Me.tbBilancio.ResumeLayout(False)
        Me.tpMagazzino.ResumeLayout(False)
        Me.tpEmailInEntrata.ResumeLayout(False)
        Me.tpMessaggi.ResumeLayout(False)
        Me.tpMarketing.ResumeLayout(False)
        Me.tpListino.ResumeLayout(False)
        Me.tpSitoWeb.ResumeLayout(False)
        Me.tbParametri.ResumeLayout(False)
        Me.tbOperatore.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbOrdini As System.Windows.Forms.TabPage
    Friend WithEvents tpProduzione As System.Windows.Forms.TabPage
    Friend WithEvents tbBilancio As System.Windows.Forms.TabPage
    Friend WithEvents tbParametri As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainerOrdini As System.Windows.Forms.SplitContainer
    Friend WithEvents tbOperatore As System.Windows.Forms.TabPage
    Friend WithEvents UcOperatore As Former.ucOperatore
    Friend WithEvents UcOrdini As Former.ucOrdini
    Friend WithEvents UcOrdineAnteprima As Former.ucOrdiniAnteprima
    Friend WithEvents UcFatture As Former.ucAmministrazione
    Friend WithEvents UcParametri As Former.ucAmministrazioneParametri
    Friend WithEvents tpConsegneReali As System.Windows.Forms.TabPage
    Friend WithEvents UcConsegneSettimana As Former.ucConsegneSettimana
    Friend WithEvents tpMarketing As System.Windows.Forms.TabPage
    Friend WithEvents UcMarketing As Former.ucMarketing
    Friend WithEvents tpMessaggi As System.Windows.Forms.TabPage
    Friend WithEvents UcMessaggi As Former.ucMessaggiInterni
    'Friend WithEvents UcPreventivi As Former.ucAmministrazionePreventivi
    Friend WithEvents imlFunzNew As System.Windows.Forms.ImageList
    Friend WithEvents tpOrdiniFatturare As System.Windows.Forms.TabPage
    Friend WithEvents UcOrdiniFatt As Former.ucOrdiniDaFatturare
    Friend WithEvents tpListino As System.Windows.Forms.TabPage
    Friend WithEvents UcListino As Former.ucListino
    Friend WithEvents tpSitoWeb As TabPage
    Friend WithEvents UcSitoWeb As ucSitoWeb
    Friend WithEvents UcProduzione As ucProduzione
    Friend WithEvents tpEmailInEntrata As TabPage
    Friend WithEvents UcPreventiviMail As ucMail
    Friend WithEvents tpMagazzino As TabPage
    Friend WithEvents UcMagazzinoMain As ucMagazzinoMain
End Class
