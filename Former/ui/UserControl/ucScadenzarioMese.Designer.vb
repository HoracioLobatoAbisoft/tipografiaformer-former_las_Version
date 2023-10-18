<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucScadenzarioMese
    Inherits ucFormerUserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucScadenzarioMese))
        Me.lblMese = New System.Windows.Forms.Label()
        Me.btnIndietro = New System.Windows.Forms.Button()
        Me.btnAvanti = New System.Windows.Forms.Button()
        Me.pnlFiltri = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdoUscite = New System.Windows.Forms.RadioButton()
        Me.rdoEntrate = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoPagCon = New System.Windows.Forms.RadioButton()
        Me.rdoPagBon = New System.Windows.Forms.RadioButton()
        Me.rdoPagAss = New System.Windows.Forms.RadioButton()
        Me.rdoPagTutti = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.UcScadenziarioSettimana1 = New Former.ucScadenziarioSettimana()
        Me.UcScadenziarioSettimana2 = New Former.ucScadenziarioSettimana()
        Me.UcScadenziarioSettimana3 = New Former.ucScadenziarioSettimana()
        Me.UcScadenziarioSettimana4 = New Former.ucScadenziarioSettimana()
        Me.UcScadenziarioSettimana5 = New Former.ucScadenziarioSettimana()
        Me.tvwScadenzeMese = New System.Windows.Forms.TreeView()
        Me.imlScadenz = New System.Windows.Forms.ImageList(Me.components)
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.tabLaterale = New System.Windows.Forms.TabControl()
        Me.tpMesi = New System.Windows.Forms.TabPage()
        Me.tpCliente = New System.Windows.Forms.TabPage()
        Me.UcSituazCliente = New Former.ucSituazPagam()
        Me.lblClienteSel = New System.Windows.Forms.Label()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.pnlFiltri.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel.SuspendLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.tabLaterale.SuspendLayout()
        Me.tpMesi.SuspendLayout()
        Me.tpCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMese
        '
        Me.lblMese.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.lblMese.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMese.Location = New System.Drawing.Point(60, 4)
        Me.lblMese.Name = "lblMese"
        Me.lblMese.Size = New System.Drawing.Size(173, 50)
        Me.lblMese.TabIndex = 0
        Me.lblMese.Text = "Mese"
        Me.lblMese.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnIndietro
        '
        Me.btnIndietro.AutoSize = True
        Me.btnIndietro.BackColor = System.Drawing.Color.White
        Me.btnIndietro.FlatAppearance.BorderSize = 0
        Me.btnIndietro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnIndietro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIndietro.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnIndietro.Image = Global.Former.My.Resources.Resources._previous
        Me.btnIndietro.Location = New System.Drawing.Point(3, 4)
        Me.btnIndietro.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnIndietro.Name = "btnIndietro"
        Me.btnIndietro.Size = New System.Drawing.Size(59, 50)
        Me.btnIndietro.TabIndex = 7
        Me.btnIndietro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIndietro.UseVisualStyleBackColor = False
        '
        'btnAvanti
        '
        Me.btnAvanti.AutoSize = True
        Me.btnAvanti.BackColor = System.Drawing.Color.White
        Me.btnAvanti.FlatAppearance.BorderSize = 0
        Me.btnAvanti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAvanti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAvanti.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnAvanti.Image = Global.Former.My.Resources.Resources._Next
        Me.btnAvanti.Location = New System.Drawing.Point(239, 4)
        Me.btnAvanti.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAvanti.Name = "btnAvanti"
        Me.btnAvanti.Size = New System.Drawing.Size(59, 50)
        Me.btnAvanti.TabIndex = 8
        Me.btnAvanti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAvanti.UseVisualStyleBackColor = False
        '
        'pnlFiltri
        '
        Me.pnlFiltri.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFiltri.Controls.Add(Me.GroupBox1)
        Me.pnlFiltri.Location = New System.Drawing.Point(12, 404)
        Me.pnlFiltri.Name = "pnlFiltri"
        Me.pnlFiltri.Size = New System.Drawing.Size(718, 49)
        Me.pnlFiltri.TabIndex = 9
        Me.pnlFiltri.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoUscite)
        Me.GroupBox2.Controls.Add(Me.rdoEntrate)
        Me.GroupBox2.Location = New System.Drawing.Point(352, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(142, 43)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo"
        '
        'rdoUscite
        '
        Me.rdoUscite.AutoSize = True
        Me.rdoUscite.BackColor = System.Drawing.Color.Red
        Me.rdoUscite.Location = New System.Drawing.Point(76, 18)
        Me.rdoUscite.Name = "rdoUscite"
        Me.rdoUscite.Size = New System.Drawing.Size(57, 19)
        Me.rdoUscite.TabIndex = 1
        Me.rdoUscite.TabStop = True
        Me.rdoUscite.Text = "Uscite"
        Me.rdoUscite.UseVisualStyleBackColor = False
        '
        'rdoEntrate
        '
        Me.rdoEntrate.AutoSize = True
        Me.rdoEntrate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdoEntrate.Checked = True
        Me.rdoEntrate.Location = New System.Drawing.Point(6, 18)
        Me.rdoEntrate.Name = "rdoEntrate"
        Me.rdoEntrate.Size = New System.Drawing.Size(62, 19)
        Me.rdoEntrate.TabIndex = 0
        Me.rdoEntrate.TabStop = True
        Me.rdoEntrate.Text = "Entrate"
        Me.rdoEntrate.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoPagCon)
        Me.GroupBox1.Controls.Add(Me.rdoPagBon)
        Me.GroupBox1.Controls.Add(Me.rdoPagAss)
        Me.GroupBox1.Controls.Add(Me.rdoPagTutti)
        Me.GroupBox1.Location = New System.Drawing.Point(151, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(385, 43)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo di Pagamento"
        '
        'rdoPagCon
        '
        Me.rdoPagCon.Image = Global.Former.My.Resources.Resources.banknotes
        Me.rdoPagCon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdoPagCon.Location = New System.Drawing.Point(278, 13)
        Me.rdoPagCon.Name = "rdoPagCon"
        Me.rdoPagCon.Size = New System.Drawing.Size(103, 28)
        Me.rdoPagCon.TabIndex = 3
        Me.rdoPagCon.TabStop = True
        Me.rdoPagCon.Text = "Contanti"
        Me.rdoPagCon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoPagCon.UseVisualStyleBackColor = True
        '
        'rdoPagBon
        '
        Me.rdoPagBon.Image = Global.Former.My.Resources.Resources.bank_cards
        Me.rdoPagBon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdoPagBon.Location = New System.Drawing.Point(169, 13)
        Me.rdoPagBon.Name = "rdoPagBon"
        Me.rdoPagBon.Size = New System.Drawing.Size(103, 28)
        Me.rdoPagBon.TabIndex = 2
        Me.rdoPagBon.TabStop = True
        Me.rdoPagBon.Text = "Bonifico"
        Me.rdoPagBon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoPagBon.UseVisualStyleBackColor = True
        '
        'rdoPagAss
        '
        Me.rdoPagAss.Image = Global.Former.My.Resources.Resources.check_book
        Me.rdoPagAss.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdoPagAss.Location = New System.Drawing.Point(60, 13)
        Me.rdoPagAss.Name = "rdoPagAss"
        Me.rdoPagAss.Size = New System.Drawing.Size(103, 28)
        Me.rdoPagAss.TabIndex = 1
        Me.rdoPagAss.TabStop = True
        Me.rdoPagAss.Text = "Assegno"
        Me.rdoPagAss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoPagAss.UseVisualStyleBackColor = True
        '
        'rdoPagTutti
        '
        Me.rdoPagTutti.Checked = True
        Me.rdoPagTutti.Location = New System.Drawing.Point(6, 13)
        Me.rdoPagTutti.Name = "rdoPagTutti"
        Me.rdoPagTutti.Size = New System.Drawing.Size(48, 28)
        Me.rdoPagTutti.TabIndex = 0
        Me.rdoPagTutti.TabStop = True
        Me.rdoPagTutti.Text = "Tutti"
        Me.rdoPagTutti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoPagTutti.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 5
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel.Controls.Add(Me.UcScadenziarioSettimana1, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.UcScadenziarioSettimana2, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.UcScadenziarioSettimana3, 2, 0)
        Me.TableLayoutPanel.Controls.Add(Me.UcScadenziarioSettimana4, 3, 0)
        Me.TableLayoutPanel.Controls.Add(Me.UcScadenziarioSettimana5, 4, 0)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 1
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(766, 423)
        Me.TableLayoutPanel.TabIndex = 10
        '
        'UcScadenziarioSettimana1
        '
        Me.UcScadenziarioSettimana1.BackColor = System.Drawing.Color.White
        Me.UcScadenziarioSettimana1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcScadenziarioSettimana1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcScadenziarioSettimana1.Location = New System.Drawing.Point(3, 3)
        Me.UcScadenziarioSettimana1.Name = "UcScadenziarioSettimana1"
        Me.UcScadenziarioSettimana1.Size = New System.Drawing.Size(147, 417)
        Me.UcScadenziarioSettimana1.TabIndex = 4
        '
        'UcScadenziarioSettimana2
        '
        Me.UcScadenziarioSettimana2.BackColor = System.Drawing.Color.White
        Me.UcScadenziarioSettimana2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcScadenziarioSettimana2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcScadenziarioSettimana2.Location = New System.Drawing.Point(156, 3)
        Me.UcScadenziarioSettimana2.Name = "UcScadenziarioSettimana2"
        Me.UcScadenziarioSettimana2.Size = New System.Drawing.Size(147, 417)
        Me.UcScadenziarioSettimana2.TabIndex = 3
        '
        'UcScadenziarioSettimana3
        '
        Me.UcScadenziarioSettimana3.BackColor = System.Drawing.Color.White
        Me.UcScadenziarioSettimana3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcScadenziarioSettimana3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcScadenziarioSettimana3.Location = New System.Drawing.Point(309, 3)
        Me.UcScadenziarioSettimana3.Name = "UcScadenziarioSettimana3"
        Me.UcScadenziarioSettimana3.Size = New System.Drawing.Size(147, 417)
        Me.UcScadenziarioSettimana3.TabIndex = 2
        '
        'UcScadenziarioSettimana4
        '
        Me.UcScadenziarioSettimana4.BackColor = System.Drawing.Color.White
        Me.UcScadenziarioSettimana4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcScadenziarioSettimana4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcScadenziarioSettimana4.Location = New System.Drawing.Point(462, 3)
        Me.UcScadenziarioSettimana4.Name = "UcScadenziarioSettimana4"
        Me.UcScadenziarioSettimana4.Size = New System.Drawing.Size(147, 417)
        Me.UcScadenziarioSettimana4.TabIndex = 1
        '
        'UcScadenziarioSettimana5
        '
        Me.UcScadenziarioSettimana5.BackColor = System.Drawing.Color.White
        Me.UcScadenziarioSettimana5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcScadenziarioSettimana5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcScadenziarioSettimana5.Location = New System.Drawing.Point(615, 3)
        Me.UcScadenziarioSettimana5.Name = "UcScadenziarioSettimana5"
        Me.UcScadenziarioSettimana5.Size = New System.Drawing.Size(148, 417)
        Me.UcScadenziarioSettimana5.TabIndex = 0
        '
        'tvwScadenzeMese
        '
        Me.tvwScadenzeMese.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwScadenzeMese.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvwScadenzeMese.Location = New System.Drawing.Point(3, 3)
        Me.tvwScadenzeMese.Name = "tvwScadenzeMese"
        Me.tvwScadenzeMese.ShowRootLines = False
        Me.tvwScadenzeMese.Size = New System.Drawing.Size(227, 389)
        Me.tvwScadenzeMese.TabIndex = 11
        '
        'imlScadenz
        '
        Me.imlScadenz.ImageStream = CType(resources.GetObject("imlScadenz.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlScadenz.TransparentColor = System.Drawing.Color.Transparent
        Me.imlScadenz.Images.SetKeyName(0, "calendar.png")
        '
        'splitMain
        '
        Me.splitMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitMain.Location = New System.Drawing.Point(3, 61)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.Controls.Add(Me.TableLayoutPanel)
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.tabLaterale)
        Me.splitMain.Size = New System.Drawing.Size(1011, 423)
        Me.splitMain.SplitterDistance = 766
        Me.splitMain.TabIndex = 12
        '
        'tabLaterale
        '
        Me.tabLaterale.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabLaterale.Controls.Add(Me.tpMesi)
        Me.tabLaterale.Controls.Add(Me.tpCliente)
        Me.tabLaterale.Location = New System.Drawing.Point(0, 0)
        Me.tabLaterale.Name = "tabLaterale"
        Me.tabLaterale.SelectedIndex = 0
        Me.tabLaterale.Size = New System.Drawing.Size(241, 423)
        Me.tabLaterale.TabIndex = 12
        '
        'tpMesi
        '
        Me.tpMesi.Controls.Add(Me.tvwScadenzeMese)
        Me.tpMesi.Location = New System.Drawing.Point(4, 24)
        Me.tpMesi.Name = "tpMesi"
        Me.tpMesi.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMesi.Size = New System.Drawing.Size(233, 395)
        Me.tpMesi.TabIndex = 0
        Me.tpMesi.Text = "Mesi"
        Me.tpMesi.UseVisualStyleBackColor = True
        '
        'tpCliente
        '
        Me.tpCliente.Controls.Add(Me.UcSituazCliente)
        Me.tpCliente.Controls.Add(Me.lblClienteSel)
        Me.tpCliente.Location = New System.Drawing.Point(4, 24)
        Me.tpCliente.Name = "tpCliente"
        Me.tpCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCliente.Size = New System.Drawing.Size(233, 395)
        Me.tpCliente.TabIndex = 1
        Me.tpCliente.Text = "Situazione Cliente"
        Me.tpCliente.UseVisualStyleBackColor = True
        '
        'UcSituazCliente
        '
        Me.UcSituazCliente.BackColor = System.Drawing.Color.White
        Me.UcSituazCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSituazCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcSituazCliente.IdRub = 0
        Me.UcSituazCliente.Location = New System.Drawing.Point(3, 22)
        Me.UcSituazCliente.Name = "UcSituazCliente"
        Me.UcSituazCliente.Size = New System.Drawing.Size(227, 370)
        Me.UcSituazCliente.TabIndex = 0
        '
        'lblClienteSel
        '
        Me.lblClienteSel.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblClienteSel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblClienteSel.Location = New System.Drawing.Point(3, 3)
        Me.lblClienteSel.Name = "lblClienteSel"
        Me.lblClienteSel.Size = New System.Drawing.Size(227, 19)
        Me.lblClienteSel.TabIndex = 2
        Me.lblClienteSel.Text = "-"
        Me.lblClienteSel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAggiorna
        '
        Me.btnAggiorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAggiorna.BackColor = System.Drawing.Color.White
        Me.btnAggiorna.FlatAppearance.BorderSize = 0
        Me.btnAggiorna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.btnAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAggiorna.Location = New System.Drawing.Point(919, 4)
        Me.btnAggiorna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(95, 32)
        Me.btnAggiorna.TabIndex = 108
        Me.btnAggiorna.Text = "Aggiorna"
        Me.btnAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'ucScadenzarioMese
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pnlFiltri)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.splitMain)
        Me.Controls.Add(Me.btnIndietro)
        Me.Controls.Add(Me.btnAvanti)
        Me.Controls.Add(Me.lblMese)
        Me.Name = "ucScadenzarioMese"
        Me.Size = New System.Drawing.Size(1017, 484)
        Me.pnlFiltri.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel2.ResumeLayout(False)
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.tabLaterale.ResumeLayout(False)
        Me.tpMesi.ResumeLayout(False)
        Me.tpCliente.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMese As System.Windows.Forms.Label
    Friend WithEvents btnIndietro As System.Windows.Forms.Button
    Friend WithEvents btnAvanti As System.Windows.Forms.Button
    Friend WithEvents pnlFiltri As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UcScadenziarioSettimana5 As Former.ucScadenziarioSettimana
    Friend WithEvents UcScadenziarioSettimana1 As Former.ucScadenziarioSettimana
    Friend WithEvents UcScadenziarioSettimana2 As Former.ucScadenziarioSettimana
    Friend WithEvents UcScadenziarioSettimana3 As Former.ucScadenziarioSettimana
    Friend WithEvents UcScadenziarioSettimana4 As Former.ucScadenziarioSettimana
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPagAss As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPagTutti As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPagCon As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPagBon As System.Windows.Forms.RadioButton
    Friend WithEvents tvwScadenzeMese As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoUscite As System.Windows.Forms.RadioButton
    Friend WithEvents rdoEntrate As System.Windows.Forms.RadioButton
    Friend WithEvents imlScadenz As System.Windows.Forms.ImageList
    Friend WithEvents splitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents tabLaterale As System.Windows.Forms.TabControl
    Friend WithEvents tpMesi As System.Windows.Forms.TabPage
    Friend WithEvents tpCliente As System.Windows.Forms.TabPage
    Friend WithEvents UcSituazCliente As Former.ucSituazPagam
    Friend WithEvents lblClienteSel As Label
    Friend WithEvents btnAggiorna As Button
End Class
