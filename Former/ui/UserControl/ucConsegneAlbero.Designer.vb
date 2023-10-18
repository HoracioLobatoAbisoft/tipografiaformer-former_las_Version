<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConsegneAlbero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucConsegneAlbero))
        Me.tvClienti = New System.Windows.Forms.TreeView()
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuCons = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ApplicaConsegnaPredefinitaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FiltraPerQuestoClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnnullaFiltroClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAggRub = New System.Windows.Forms.Button()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.btnCerca = New System.Windows.Forms.Button()
        Me.btnApplica = New System.Windows.Forms.Button()
        Me.tmrHover = New System.Windows.Forms.Timer(Me.components)
        Me.btnStampa = New System.Windows.Forms.Button()
        Me.mnuCons.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvClienti
        '
        Me.tvClienti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvClienti.ImageIndex = 0
        Me.tvClienti.ImageList = Me.imlCli
        Me.tvClienti.Indent = 15
        Me.tvClienti.Location = New System.Drawing.Point(3, 34)
        Me.tvClienti.Name = "tvClienti"
        Me.tvClienti.SelectedImageIndex = 0
        Me.tvClienti.Size = New System.Drawing.Size(294, 344)
        Me.tvClienti.TabIndex = 79
        '
        'imlCli
        '
        Me.imlCli.ImageStream = CType(resources.GetObject("imlCli.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCli.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCli.Images.SetKeyName(0, "user(1).png")
        Me.imlCli.Images.SetKeyName(1, "checkout.png")
        Me.imlCli.Images.SetKeyName(2, "icoPrint.jpg")
        Me.imlCli.Images.SetKeyName(3, "icoMoney.jpg")
        Me.imlCli.Images.SetKeyName(4, "icoRubRed.jpg")
        Me.imlCli.Images.SetKeyName(5, "icoParamRed.jpg")
        Me.imlCli.Images.SetKeyName(6, "truck.png")
        Me.imlCli.Images.SetKeyName(7, "Time-&-Weather20-0.png")
        '
        'mnuCons
        '
        Me.mnuCons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplicaConsegnaPredefinitaToolStripMenuItem, Me.ToolStripSeparator1, Me.FiltraPerQuestoClienteToolStripMenuItem, Me.AnnullaFiltroClienteToolStripMenuItem})
        Me.mnuCons.Name = "mnuCons"
        Me.mnuCons.Size = New System.Drawing.Size(229, 76)
        '
        'ApplicaConsegnaPredefinitaToolStripMenuItem
        '
        Me.ApplicaConsegnaPredefinitaToolStripMenuItem.Name = "ApplicaConsegnaPredefinitaToolStripMenuItem"
        Me.ApplicaConsegnaPredefinitaToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ApplicaConsegnaPredefinitaToolStripMenuItem.Text = "Applica consegna predefinita"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(225, 6)
        '
        'FiltraPerQuestoClienteToolStripMenuItem
        '
        Me.FiltraPerQuestoClienteToolStripMenuItem.Name = "FiltraPerQuestoClienteToolStripMenuItem"
        Me.FiltraPerQuestoClienteToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.FiltraPerQuestoClienteToolStripMenuItem.Text = "Filtra per questo cliente"
        '
        'AnnullaFiltroClienteToolStripMenuItem
        '
        Me.AnnullaFiltroClienteToolStripMenuItem.Enabled = False
        Me.AnnullaFiltroClienteToolStripMenuItem.Name = "AnnullaFiltroClienteToolStripMenuItem"
        Me.AnnullaFiltroClienteToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.AnnullaFiltroClienteToolStripMenuItem.Text = "Annulla Filtro Cliente"
        '
        'btnAggRub
        '
        Me.btnAggRub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAggRub.BackColor = System.Drawing.Color.White
        Me.btnAggRub.FlatAppearance.BorderSize = 0
        Me.btnAggRub.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggRub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggRub.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggRub.Location = New System.Drawing.Point(265, 0)
        Me.btnAggRub.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggRub.Name = "btnAggRub"
        Me.btnAggRub.Size = New System.Drawing.Size(32, 33)
        Me.btnAggRub.TabIndex = 82
        Me.btnAggRub.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAggRub.UseVisualStyleBackColor = False
        '
        'txtCerca
        '
        Me.txtCerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCerca.Location = New System.Drawing.Point(41, 7)
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(154, 23)
        Me.txtCerca.TabIndex = 80
        Me.txtCerca.Text = "{cerca cliente}"
        '
        'btnCerca
        '
        Me.btnCerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerca.BackColor = System.Drawing.Color.White
        Me.btnCerca.FlatAppearance.BorderSize = 0
        Me.btnCerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCerca.Image = Global.Former.My.Resources.Resources._Cerca
        Me.btnCerca.Location = New System.Drawing.Point(201, 0)
        Me.btnCerca.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCerca.Name = "btnCerca"
        Me.btnCerca.Size = New System.Drawing.Size(32, 33)
        Me.btnCerca.TabIndex = 81
        Me.btnCerca.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCerca.UseVisualStyleBackColor = False
        '
        'btnApplica
        '
        Me.btnApplica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApplica.BackColor = System.Drawing.Color.White
        Me.btnApplica.FlatAppearance.BorderSize = 0
        Me.btnApplica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApplica.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnApplica.Image = Global.Former.My.Resources.Resources.checkmark1
        Me.btnApplica.Location = New System.Drawing.Point(265, 344)
        Me.btnApplica.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnApplica.Name = "btnApplica"
        Me.btnApplica.Size = New System.Drawing.Size(32, 33)
        Me.btnApplica.TabIndex = 83
        Me.btnApplica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnApplica.UseVisualStyleBackColor = False
        Me.btnApplica.Visible = False
        '
        'tmrHover
        '
        Me.tmrHover.Interval = 1000
        '
        'btnStampa
        '
        Me.btnStampa.BackColor = System.Drawing.Color.White
        Me.btnStampa.FlatAppearance.BorderSize = 0
        Me.btnStampa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.btnStampa.Location = New System.Drawing.Point(3, 0)
        Me.btnStampa.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnStampa.Name = "btnStampa"
        Me.btnStampa.Size = New System.Drawing.Size(32, 33)
        Me.btnStampa.TabIndex = 83
        Me.btnStampa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStampa.UseVisualStyleBackColor = False
        '
        'ucConsegneAlbero
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tvClienti)
        Me.Controls.Add(Me.btnStampa)
        Me.Controls.Add(Me.btnApplica)
        Me.Controls.Add(Me.btnAggRub)
        Me.Controls.Add(Me.txtCerca)
        Me.Controls.Add(Me.btnCerca)
        Me.Name = "ucConsegneAlbero"
        Me.Size = New System.Drawing.Size(300, 381)
        Me.mnuCons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvClienti As System.Windows.Forms.TreeView
    Friend WithEvents btnAggRub As System.Windows.Forms.Button
    Friend WithEvents txtCerca As System.Windows.Forms.TextBox
    Friend WithEvents btnCerca As System.Windows.Forms.Button
    Friend WithEvents imlCli As System.Windows.Forms.ImageList
    Friend WithEvents btnApplica As System.Windows.Forms.Button
    Friend WithEvents tmrHover As System.Windows.Forms.Timer
    Friend WithEvents mnuCons As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ApplicaConsegnaPredefinitaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FiltraPerQuestoClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnnullaFiltroClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnStampa As System.Windows.Forms.Button

End Class
