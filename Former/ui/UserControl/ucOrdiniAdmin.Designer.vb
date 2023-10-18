<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrdiniAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucOrdiniAdmin))
        Me.tvOrdini = New System.Windows.Forms.TreeView()
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.lblAnteprima = New System.Windows.Forms.Label()
        Me.pctPreviewO = New System.Windows.Forms.PictureBox()
        Me.Split = New System.Windows.Forms.SplitContainer()
        Me.pctPreviewC = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.pctPreviewO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Split, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split.Panel1.SuspendLayout()
        Me.Split.Panel2.SuspendLayout()
        Me.Split.SuspendLayout()
        CType(Me.pctPreviewC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvOrdini
        '
        Me.tvOrdini.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvOrdini.ImageIndex = 0
        Me.tvOrdini.ImageList = Me.imlCli
        Me.tvOrdini.Location = New System.Drawing.Point(3, 3)
        Me.tvOrdini.Name = "tvOrdini"
        Me.tvOrdini.SelectedImageIndex = 0
        Me.tvOrdini.Size = New System.Drawing.Size(267, 456)
        Me.tvOrdini.TabIndex = 1
        '
        'imlCli
        '
        Me.imlCli.ImageStream = CType(resources.GetObject("imlCli.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCli.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCli.Images.SetKeyName(0, "icoOrder.jpg")
        '
        'lblAnteprima
        '
        Me.lblAnteprima.AutoSize = True
        Me.lblAnteprima.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAnteprima.ForeColor = System.Drawing.Color.Black
        Me.lblAnteprima.Location = New System.Drawing.Point(3, 6)
        Me.lblAnteprima.Name = "lblAnteprima"
        Me.lblAnteprima.Size = New System.Drawing.Size(45, 15)
        Me.lblAnteprima.TabIndex = 99
        Me.lblAnteprima.Text = "Ordine"
        '
        'pctPreviewO
        '
        Me.pctPreviewO.Location = New System.Drawing.Point(6, 24)
        Me.pctPreviewO.Name = "pctPreviewO"
        Me.pctPreviewO.Size = New System.Drawing.Size(153, 198)
        Me.pctPreviewO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctPreviewO.TabIndex = 98
        Me.pctPreviewO.TabStop = False
        '
        'Split
        '
        Me.Split.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Split.Location = New System.Drawing.Point(276, 3)
        Me.Split.Name = "Split"
        '
        'Split.Panel1
        '
        Me.Split.Panel1.Controls.Add(Me.pctPreviewO)
        Me.Split.Panel1.Controls.Add(Me.lblAnteprima)
        '
        'Split.Panel2
        '
        Me.Split.Panel2.Controls.Add(Me.pctPreviewC)
        Me.Split.Panel2.Controls.Add(Me.Label1)
        Me.Split.Size = New System.Drawing.Size(702, 456)
        Me.Split.SplitterDistance = 369
        Me.Split.TabIndex = 100
        '
        'pctPreviewC
        '
        Me.pctPreviewC.Location = New System.Drawing.Point(6, 24)
        Me.pctPreviewC.Name = "pctPreviewC"
        Me.pctPreviewC.Size = New System.Drawing.Size(153, 198)
        Me.pctPreviewC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctPreviewC.TabIndex = 100
        Me.pctPreviewC.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Commessa"
        '
        'ucOrdiniAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.Split)
        Me.Controls.Add(Me.tvOrdini)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "ucOrdiniAdmin"
        Me.Size = New System.Drawing.Size(981, 462)
        CType(Me.pctPreviewO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split.Panel1.ResumeLayout(False)
        Me.Split.Panel1.PerformLayout()
        Me.Split.Panel2.ResumeLayout(False)
        Me.Split.Panel2.PerformLayout()
        CType(Me.Split, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split.ResumeLayout(False)
        CType(Me.pctPreviewC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

    End Sub
    Friend WithEvents tvOrdini As System.Windows.Forms.TreeView
    Friend WithEvents imlCli As System.Windows.Forms.ImageList
    Friend WithEvents lblAnteprima As System.Windows.Forms.Label
    Friend WithEvents pctPreviewO As System.Windows.Forms.PictureBox
    Friend WithEvents Split As System.Windows.Forms.SplitContainer
    Friend WithEvents pctPreviewC As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
