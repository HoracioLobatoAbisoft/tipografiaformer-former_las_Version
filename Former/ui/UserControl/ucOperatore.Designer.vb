<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucOperatore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucOperatore))
        Me.tabOperatore = New System.Windows.Forms.TabControl()
        Me.tpLavoriTutti = New System.Windows.Forms.TabPage()
        Me.UcOperatoreCodaLavori = New Former.ucOperatoreCodaLavori()
        Me.tpProduzione = New System.Windows.Forms.TabPage()
        Me.UcOperatoreProduzione = New Former.ucOperatoreProduzione()
        Me.tpImballaggio = New System.Windows.Forms.TabPage()
        Me.UcOperatoreImballaggio = New Former.ucOperatoreImballaggio()
        Me.tpImballaggioCorriere = New System.Windows.Forms.TabPage()
        Me.UcOperatoreImballaggioCorriere = New Former.ucOperatoreImballaggioCorriere()
        Me.tpConsegna = New System.Windows.Forms.TabPage()
        Me.UcOperatoreConsegna = New Former.ucOperatoreConsegna()
        Me.tpConfermaConsegne = New System.Windows.Forms.TabPage()
        Me.UcOperatoreConfermaConsegne = New Former.ucOperatoreConfermaConsegne()
        Me.imlOp = New System.Windows.Forms.ImageList(Me.components)
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.UcCommesseAnteprimaOp = New Former.ucAnteprimaOperatore()
        Me.tmrAggiornaDati = New System.Windows.Forms.Timer(Me.components)
        Me.tabOperatore.SuspendLayout()
        Me.tpLavoriTutti.SuspendLayout()
        Me.tpProduzione.SuspendLayout()
        Me.tpImballaggio.SuspendLayout()
        Me.tpImballaggioCorriere.SuspendLayout()
        Me.tpConsegna.SuspendLayout()
        Me.tpConfermaConsegne.SuspendLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabOperatore
        '
        Me.tabOperatore.Controls.Add(Me.tpLavoriTutti)
        Me.tabOperatore.Controls.Add(Me.tpProduzione)
        Me.tabOperatore.Controls.Add(Me.tpImballaggio)
        Me.tabOperatore.Controls.Add(Me.tpImballaggioCorriere)
        Me.tabOperatore.Controls.Add(Me.tpConsegna)
        Me.tabOperatore.Controls.Add(Me.tpConfermaConsegne)
        Me.tabOperatore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabOperatore.ImageList = Me.imlOp
        Me.tabOperatore.Location = New System.Drawing.Point(0, 0)
        Me.tabOperatore.Name = "tabOperatore"
        Me.tabOperatore.SelectedIndex = 0
        Me.tabOperatore.Size = New System.Drawing.Size(724, 768)
        Me.tabOperatore.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.tabOperatore.TabIndex = 2
        Me.tabOperatore.TabStop = False
        '
        'tpLavoriTutti
        '
        Me.tpLavoriTutti.BackColor = System.Drawing.Color.White
        Me.tpLavoriTutti.Controls.Add(Me.UcOperatoreCodaLavori)
        Me.tpLavoriTutti.ImageKey = "_Fullstack.png"
        Me.tpLavoriTutti.Location = New System.Drawing.Point(4, 31)
        Me.tpLavoriTutti.Name = "tpLavoriTutti"
        Me.tpLavoriTutti.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLavoriTutti.Size = New System.Drawing.Size(716, 733)
        Me.tpLavoriTutti.TabIndex = 4
        Me.tpLavoriTutti.Text = "Tutti i lavori in coda"
        '
        'UcOperatoreCodaLavori
        '
        Me.UcOperatoreCodaLavori.BackColor = System.Drawing.Color.White
        Me.UcOperatoreCodaLavori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOperatoreCodaLavori.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOperatoreCodaLavori.Location = New System.Drawing.Point(3, 3)
        Me.UcOperatoreCodaLavori.Name = "UcOperatoreCodaLavori"
        Me.UcOperatoreCodaLavori.Size = New System.Drawing.Size(710, 727)
        Me.UcOperatoreCodaLavori.TabIndex = 0
        '
        'tpProduzione
        '
        Me.tpProduzione.Controls.Add(Me.UcOperatoreProduzione)
        Me.tpProduzione.ImageKey = "user.png"
        Me.tpProduzione.Location = New System.Drawing.Point(4, 31)
        Me.tpProduzione.Name = "tpProduzione"
        Me.tpProduzione.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProduzione.Size = New System.Drawing.Size(716, 733)
        Me.tpProduzione.TabIndex = 0
        Me.tpProduzione.Text = "-"
        Me.tpProduzione.UseVisualStyleBackColor = True
        '
        'UcOperatoreProduzione
        '
        Me.UcOperatoreProduzione.BackColor = System.Drawing.Color.White
        Me.UcOperatoreProduzione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOperatoreProduzione.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOperatoreProduzione.Location = New System.Drawing.Point(3, 3)
        Me.UcOperatoreProduzione.Name = "UcOperatoreProduzione"
        Me.UcOperatoreProduzione.Size = New System.Drawing.Size(710, 727)
        Me.UcOperatoreProduzione.TabIndex = 0
        '
        'tpImballaggio
        '
        Me.tpImballaggio.Controls.Add(Me.UcOperatoreImballaggio)
        Me.tpImballaggio.ImageKey = "_Consegna1.png"
        Me.tpImballaggio.Location = New System.Drawing.Point(4, 31)
        Me.tpImballaggio.Name = "tpImballaggio"
        Me.tpImballaggio.Padding = New System.Windows.Forms.Padding(3)
        Me.tpImballaggio.Size = New System.Drawing.Size(716, 733)
        Me.tpImballaggio.TabIndex = 1
        Me.tpImballaggio.Text = "Imballaggio"
        Me.tpImballaggio.UseVisualStyleBackColor = True
        '
        'UcOperatoreImballaggio
        '
        Me.UcOperatoreImballaggio.BackColor = System.Drawing.Color.White
        Me.UcOperatoreImballaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOperatoreImballaggio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOperatoreImballaggio.Location = New System.Drawing.Point(3, 3)
        Me.UcOperatoreImballaggio.Name = "UcOperatoreImballaggio"
        Me.UcOperatoreImballaggio.Size = New System.Drawing.Size(710, 727)
        Me.UcOperatoreImballaggio.TabIndex = 0
        '
        'tpImballaggioCorriere
        '
        Me.tpImballaggioCorriere.Controls.Add(Me.UcOperatoreImballaggioCorriere)
        Me.tpImballaggioCorriere.ImageKey = "_GLS.png"
        Me.tpImballaggioCorriere.Location = New System.Drawing.Point(4, 31)
        Me.tpImballaggioCorriere.Name = "tpImballaggioCorriere"
        Me.tpImballaggioCorriere.Padding = New System.Windows.Forms.Padding(3)
        Me.tpImballaggioCorriere.Size = New System.Drawing.Size(716, 733)
        Me.tpImballaggioCorriere.TabIndex = 2
        Me.tpImballaggioCorriere.Text = "ImballaggioCorriere"
        Me.tpImballaggioCorriere.UseVisualStyleBackColor = True
        '
        'UcOperatoreImballaggioCorriere
        '
        Me.UcOperatoreImballaggioCorriere.BackColor = System.Drawing.Color.White
        Me.UcOperatoreImballaggioCorriere.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOperatoreImballaggioCorriere.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOperatoreImballaggioCorriere.Location = New System.Drawing.Point(3, 3)
        Me.UcOperatoreImballaggioCorriere.Name = "UcOperatoreImballaggioCorriere"
        Me.UcOperatoreImballaggioCorriere.Size = New System.Drawing.Size(710, 727)
        Me.UcOperatoreImballaggioCorriere.TabIndex = 0
        '
        'tpConsegna
        '
        Me.tpConsegna.Controls.Add(Me.UcOperatoreConsegna)
        Me.tpConsegna.ImageKey = "_CaricoMagazzino.png"
        Me.tpConsegna.Location = New System.Drawing.Point(4, 31)
        Me.tpConsegna.Name = "tpConsegna"
        Me.tpConsegna.Padding = New System.Windows.Forms.Padding(3)
        Me.tpConsegna.Size = New System.Drawing.Size(716, 733)
        Me.tpConsegna.TabIndex = 3
        Me.tpConsegna.Text = "Consegna"
        Me.tpConsegna.UseVisualStyleBackColor = True
        '
        'UcOperatoreConsegna
        '
        Me.UcOperatoreConsegna.BackColor = System.Drawing.Color.White
        Me.UcOperatoreConsegna.Cursor = System.Windows.Forms.Cursors.Default
        Me.UcOperatoreConsegna.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOperatoreConsegna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOperatoreConsegna.Location = New System.Drawing.Point(3, 3)
        Me.UcOperatoreConsegna.Name = "UcOperatoreConsegna"
        Me.UcOperatoreConsegna.Size = New System.Drawing.Size(710, 727)
        Me.UcOperatoreConsegna.TabIndex = 0
        '
        'tpConfermaConsegne
        '
        Me.tpConfermaConsegne.Controls.Add(Me.UcOperatoreConfermaConsegne)
        Me.tpConfermaConsegne.ImageKey = "_CorriereConferma.png"
        Me.tpConfermaConsegne.Location = New System.Drawing.Point(4, 31)
        Me.tpConfermaConsegne.Name = "tpConfermaConsegne"
        Me.tpConfermaConsegne.Padding = New System.Windows.Forms.Padding(3)
        Me.tpConfermaConsegne.Size = New System.Drawing.Size(716, 733)
        Me.tpConfermaConsegne.TabIndex = 5
        Me.tpConfermaConsegne.Text = "Conferma Consegne TF"
        Me.tpConfermaConsegne.UseVisualStyleBackColor = True
        '
        'UcOperatoreConfermaConsegne
        '
        Me.UcOperatoreConfermaConsegne.BackColor = System.Drawing.Color.White
        Me.UcOperatoreConfermaConsegne.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOperatoreConfermaConsegne.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOperatoreConfermaConsegne.Location = New System.Drawing.Point(3, 3)
        Me.UcOperatoreConfermaConsegne.Name = "UcOperatoreConfermaConsegne"
        Me.UcOperatoreConfermaConsegne.Size = New System.Drawing.Size(710, 727)
        Me.UcOperatoreConfermaConsegne.TabIndex = 0
        '
        'imlOp
        '
        Me.imlOp.ImageStream = CType(resources.GetObject("imlOp.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlOp.TransparentColor = System.Drawing.Color.Transparent
        Me.imlOp.Images.SetKeyName(0, "_GLS.png")
        Me.imlOp.Images.SetKeyName(1, "_Fullstack.png")
        Me.imlOp.Images.SetKeyName(2, "user.png")
        Me.imlOp.Images.SetKeyName(3, "_Consegna1.png")
        Me.imlOp.Images.SetKeyName(4, "_CaricoMagazzino.png")
        Me.imlOp.Images.SetKeyName(5, "_CorriereConferma.png")
        '
        'splitMain
        '
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitMain.Location = New System.Drawing.Point(0, 0)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.Controls.Add(Me.tabOperatore)
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.UcCommesseAnteprimaOp)
        Me.splitMain.Size = New System.Drawing.Size(1024, 768)
        Me.splitMain.SplitterDistance = 724
        Me.splitMain.TabIndex = 3
        '
        'UcCommesseAnteprimaOp
        '
        Me.UcCommesseAnteprimaOp.BackColor = System.Drawing.Color.White
        Me.UcCommesseAnteprimaOp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcCommesseAnteprimaOp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcCommesseAnteprimaOp.Location = New System.Drawing.Point(0, 0)
        Me.UcCommesseAnteprimaOp.Name = "UcCommesseAnteprimaOp"
        Me.UcCommesseAnteprimaOp.Size = New System.Drawing.Size(296, 768)
        Me.UcCommesseAnteprimaOp.TabIndex = 1
        '
        'tmrAggiornaDati
        '
        Me.tmrAggiornaDati.Interval = 300000
        '
        'ucOperatore
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.splitMain)
        Me.Name = "ucOperatore"
        Me.Size = New System.Drawing.Size(1024, 768)
        Me.tabOperatore.ResumeLayout(False)
        Me.tpLavoriTutti.ResumeLayout(False)
        Me.tpProduzione.ResumeLayout(False)
        Me.tpImballaggio.ResumeLayout(False)
        Me.tpImballaggioCorriere.ResumeLayout(False)
        Me.tpConsegna.ResumeLayout(False)
        Me.tpConfermaConsegne.ResumeLayout(False)
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel2.ResumeLayout(False)
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcCommesseAnteprimaOp As ucAnteprimaOperatore
    Friend WithEvents tabOperatore As TabControl
    Friend WithEvents tpProduzione As TabPage
    Friend WithEvents tpImballaggio As TabPage
    Friend WithEvents splitMain As SplitContainer
    Friend WithEvents imlOp As ImageList
    Friend WithEvents tpImballaggioCorriere As TabPage
    Friend WithEvents tpConsegna As TabPage
    Friend WithEvents UcOperatoreProduzione As ucOperatoreProduzione
    Friend WithEvents UcOperatoreImballaggio As ucOperatoreImballaggio
    Friend WithEvents UcOperatoreImballaggioCorriere As ucOperatoreImballaggioCorriere
    Friend WithEvents UcOperatoreConsegna As ucOperatoreConsegna
    Friend WithEvents tmrAggiornaDati As Timer
    Friend WithEvents tpLavoriTutti As TabPage
    Friend WithEvents UcOperatoreCodaLavori As ucOperatoreCodaLavori
    Friend WithEvents tpConfermaConsegne As TabPage
    Friend WithEvents UcOperatoreConfermaConsegne As ucOperatoreConfermaConsegne
End Class
