<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAmministrazione
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucAmministrazione))
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tpDashboard = New System.Windows.Forms.TabPage()
        Me.UcAmministrazioneDashboard = New Former.ucAmministrazioneDashboard()
        Me.TbDocOut = New System.Windows.Forms.TabPage()
        Me.UcContab = New Former.ucDocumentiFiscali()
        Me.tpRiepilogo = New System.Windows.Forms.TabPage()
        Me.SplitContainerRiepilogo = New System.Windows.Forms.SplitContainer()
        Me.lnkCerca = New System.Windows.Forms.LinkLabel()
        Me.toolRubrica = New System.Windows.Forms.ToolStrip()
        Me.TB_123 = New System.Windows.Forms.ToolStripButton()
        Me.TB_A = New System.Windows.Forms.ToolStripButton()
        Me.TB_B = New System.Windows.Forms.ToolStripButton()
        Me.TB_C = New System.Windows.Forms.ToolStripButton()
        Me.TB_D = New System.Windows.Forms.ToolStripButton()
        Me.TB_E = New System.Windows.Forms.ToolStripButton()
        Me.TB_F = New System.Windows.Forms.ToolStripButton()
        Me.TB_G = New System.Windows.Forms.ToolStripButton()
        Me.TB_H = New System.Windows.Forms.ToolStripButton()
        Me.TB_I = New System.Windows.Forms.ToolStripButton()
        Me.TB_J = New System.Windows.Forms.ToolStripButton()
        Me.TB_K = New System.Windows.Forms.ToolStripButton()
        Me.TB_L = New System.Windows.Forms.ToolStripButton()
        Me.TB_M = New System.Windows.Forms.ToolStripButton()
        Me.TB_N = New System.Windows.Forms.ToolStripButton()
        Me.TB_O = New System.Windows.Forms.ToolStripButton()
        Me.TB_P = New System.Windows.Forms.ToolStripButton()
        Me.TB_Q = New System.Windows.Forms.ToolStripButton()
        Me.TB_R = New System.Windows.Forms.ToolStripButton()
        Me.TB_S = New System.Windows.Forms.ToolStripButton()
        Me.TB_T = New System.Windows.Forms.ToolStripButton()
        Me.TB_U = New System.Windows.Forms.ToolStripButton()
        Me.TB_V = New System.Windows.Forms.ToolStripButton()
        Me.TB_W = New System.Windows.Forms.ToolStripButton()
        Me.TB_X = New System.Windows.Forms.ToolStripButton()
        Me.TB_Y = New System.Windows.Forms.ToolStripButton()
        Me.TB_Z = New System.Windows.Forms.ToolStripButton()
        Me.txtCerca = New System.Windows.Forms.TextBox()
        Me.tvClienti = New System.Windows.Forms.TreeView()
        Me.imlCli = New System.Windows.Forms.ImageList(Me.components)
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.tpRubrica = New System.Windows.Forms.TabPage()
        Me.UcRubrica1 = New Former.ucAmministrazioneRubrica()
        Me.tpSituazClienti = New System.Windows.Forms.TabPage()
        Me.UcAmministrazioneSituazioneClienti = New Former.ucAmministrazioneSituazioneClienti()
        Me.tpScadenzario = New System.Windows.Forms.TabPage()
        Me.UcScadenzario = New Former.ucScadenzarioMese()
        Me.tpOrdiniBonifico = New System.Windows.Forms.TabPage()
        Me.UcOrdiniBonifico = New Former.ucAmministrazioneOrdiniBonifico()
        Me.tpCoupon = New System.Windows.Forms.TabPage()
        Me.UcCoupon1 = New Former.ucAmministrazioneCoupon()
        Me.tpPromo = New System.Windows.Forms.TabPage()
        Me.UcAmministrazionePromo = New Former.ucAmministrazionePromo()
        Me.tpReport = New System.Windows.Forms.TabPage()
        Me.UcAmministrazioneReport = New Former.ucAmministrazioneReport()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.imlMerceUscita = New System.Windows.Forms.ImageList(Me.components)
        Me.tpPagamenti = New System.Windows.Forms.TabPage()
        Me.UcAmministrazionePagamenti = New Former.ucAmministrazionePagamenti()
        Me.TabMain.SuspendLayout()
        Me.tpDashboard.SuspendLayout()
        Me.TbDocOut.SuspendLayout()
        Me.tpRiepilogo.SuspendLayout()
        CType(Me.SplitContainerRiepilogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerRiepilogo.Panel1.SuspendLayout()
        Me.SplitContainerRiepilogo.SuspendLayout()
        Me.toolRubrica.SuspendLayout()
        Me.tpRubrica.SuspendLayout()
        Me.tpSituazClienti.SuspendLayout()
        Me.tpScadenzario.SuspendLayout()
        Me.tpOrdiniBonifico.SuspendLayout()
        Me.tpCoupon.SuspendLayout()
        Me.tpPromo.SuspendLayout()
        Me.tpReport.SuspendLayout()
        Me.tpPagamenti.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tpDashboard)
        Me.TabMain.Controls.Add(Me.TbDocOut)
        Me.TabMain.Controls.Add(Me.tpRiepilogo)
        Me.TabMain.Controls.Add(Me.tpPagamenti)
        Me.TabMain.Controls.Add(Me.tpRubrica)
        Me.TabMain.Controls.Add(Me.tpSituazClienti)
        Me.TabMain.Controls.Add(Me.tpScadenzario)
        Me.TabMain.Controls.Add(Me.tpOrdiniBonifico)
        Me.TabMain.Controls.Add(Me.tpCoupon)
        Me.TabMain.Controls.Add(Me.tpPromo)
        Me.TabMain.Controls.Add(Me.tpReport)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ImageList = Me.imlTab
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1239, 552)
        Me.TabMain.TabIndex = 54
        '
        'tpDashboard
        '
        Me.tpDashboard.Controls.Add(Me.UcAmministrazioneDashboard)
        Me.tpDashboard.ImageKey = "_Dashboard.png"
        Me.tpDashboard.Location = New System.Drawing.Point(4, 31)
        Me.tpDashboard.Name = "tpDashboard"
        Me.tpDashboard.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDashboard.Size = New System.Drawing.Size(1231, 517)
        Me.tpDashboard.TabIndex = 15
        Me.tpDashboard.Text = "Dashboard"
        Me.tpDashboard.UseVisualStyleBackColor = True
        '
        'UcAmministrazioneDashboard
        '
        Me.UcAmministrazioneDashboard.BackColor = System.Drawing.Color.White
        Me.UcAmministrazioneDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazioneDashboard.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazioneDashboard.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazioneDashboard.Name = "UcAmministrazioneDashboard"
        Me.UcAmministrazioneDashboard.Size = New System.Drawing.Size(1225, 511)
        Me.UcAmministrazioneDashboard.TabIndex = 0
        '
        'TbDocOut
        '
        Me.TbDocOut.Controls.Add(Me.UcContab)
        Me.TbDocOut.ImageKey = "ico_DO.png"
        Me.TbDocOut.Location = New System.Drawing.Point(4, 31)
        Me.TbDocOut.Name = "TbDocOut"
        Me.TbDocOut.Padding = New System.Windows.Forms.Padding(3)
        Me.TbDocOut.Size = New System.Drawing.Size(1231, 517)
        Me.TbDocOut.TabIndex = 1
        Me.TbDocOut.Text = "Documenti"
        Me.TbDocOut.UseVisualStyleBackColor = True
        '
        'UcContab
        '
        Me.UcContab.BackColor = System.Drawing.Color.White
        Me.UcContab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcContab.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcContab.IdRub = 0
        Me.UcContab.Location = New System.Drawing.Point(3, 3)
        Me.UcContab.Name = "UcContab"
        Me.UcContab.Size = New System.Drawing.Size(1225, 511)
        Me.UcContab.TabIndex = 62
        '
        'tpRiepilogo
        '
        Me.tpRiepilogo.Controls.Add(Me.SplitContainerRiepilogo)
        Me.tpRiepilogo.ImageKey = "ico_AM.png"
        Me.tpRiepilogo.Location = New System.Drawing.Point(4, 31)
        Me.tpRiepilogo.Name = "tpRiepilogo"
        Me.tpRiepilogo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRiepilogo.Size = New System.Drawing.Size(1231, 517)
        Me.tpRiepilogo.TabIndex = 4
        Me.tpRiepilogo.Text = "Amministrazione"
        Me.tpRiepilogo.UseVisualStyleBackColor = True
        '
        'SplitContainerRiepilogo
        '
        Me.SplitContainerRiepilogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerRiepilogo.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerRiepilogo.Name = "SplitContainerRiepilogo"
        '
        'SplitContainerRiepilogo.Panel1
        '
        Me.SplitContainerRiepilogo.Panel1.Controls.Add(Me.lnkCerca)
        Me.SplitContainerRiepilogo.Panel1.Controls.Add(Me.toolRubrica)
        Me.SplitContainerRiepilogo.Panel1.Controls.Add(Me.txtCerca)
        Me.SplitContainerRiepilogo.Panel1.Controls.Add(Me.tvClienti)
        Me.SplitContainerRiepilogo.Panel1.Controls.Add(Me.lnkAggiorna)
        Me.SplitContainerRiepilogo.Size = New System.Drawing.Size(1225, 511)
        Me.SplitContainerRiepilogo.SplitterDistance = 444
        Me.SplitContainerRiepilogo.TabIndex = 68
        '
        'lnkCerca
        '
        Me.lnkCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkCerca.Image = Global.Former.My.Resources.Resources._Cerca
        Me.lnkCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCerca.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkCerca.Location = New System.Drawing.Point(141, 1)
        Me.lnkCerca.Name = "lnkCerca"
        Me.lnkCerca.Size = New System.Drawing.Size(80, 27)
        Me.lnkCerca.TabIndex = 69
        Me.lnkCerca.TabStop = True
        Me.lnkCerca.Text = "Cerca..."
        Me.lnkCerca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'toolRubrica
        '
        Me.toolRubrica.AllowMerge = False
        Me.toolRubrica.Dock = System.Windows.Forms.DockStyle.None
        Me.toolRubrica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolRubrica.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolRubrica.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TB_123, Me.TB_A, Me.TB_B, Me.TB_C, Me.TB_D, Me.TB_E, Me.TB_F, Me.TB_G, Me.TB_H, Me.TB_I, Me.TB_J, Me.TB_K, Me.TB_L, Me.TB_M, Me.TB_N, Me.TB_O, Me.TB_P, Me.TB_Q, Me.TB_R, Me.TB_S, Me.TB_T, Me.TB_U, Me.TB_V, Me.TB_W, Me.TB_X, Me.TB_Y, Me.TB_Z})
        Me.toolRubrica.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.toolRubrica.Location = New System.Drawing.Point(6, 31)
        Me.toolRubrica.Name = "toolRubrica"
        Me.toolRubrica.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.toolRubrica.ShowItemToolTips = False
        Me.toolRubrica.Size = New System.Drawing.Size(24, 596)
        Me.toolRubrica.TabIndex = 67
        '
        'TB_123
        '
        Me.TB_123.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_123.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_123.ForeColor = System.Drawing.Color.Black
        Me.TB_123.Image = CType(resources.GetObject("TB_123.Image"), System.Drawing.Image)
        Me.TB_123.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_123.Name = "TB_123"
        Me.TB_123.Size = New System.Drawing.Size(22, 19)
        Me.TB_123.Text = "*"
        '
        'TB_A
        '
        Me.TB_A.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_A.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_A.ForeColor = System.Drawing.Color.Black
        Me.TB_A.Image = CType(resources.GetObject("TB_A.Image"), System.Drawing.Image)
        Me.TB_A.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_A.Name = "TB_A"
        Me.TB_A.Size = New System.Drawing.Size(22, 19)
        Me.TB_A.Text = "A"
        '
        'TB_B
        '
        Me.TB_B.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_B.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_B.ForeColor = System.Drawing.Color.Black
        Me.TB_B.Image = CType(resources.GetObject("TB_B.Image"), System.Drawing.Image)
        Me.TB_B.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_B.Name = "TB_B"
        Me.TB_B.Size = New System.Drawing.Size(22, 19)
        Me.TB_B.Text = "B"
        '
        'TB_C
        '
        Me.TB_C.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_C.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_C.ForeColor = System.Drawing.Color.Black
        Me.TB_C.Image = CType(resources.GetObject("TB_C.Image"), System.Drawing.Image)
        Me.TB_C.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_C.Name = "TB_C"
        Me.TB_C.Size = New System.Drawing.Size(22, 19)
        Me.TB_C.Text = "C"
        '
        'TB_D
        '
        Me.TB_D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_D.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_D.ForeColor = System.Drawing.Color.Black
        Me.TB_D.Image = CType(resources.GetObject("TB_D.Image"), System.Drawing.Image)
        Me.TB_D.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_D.Name = "TB_D"
        Me.TB_D.Size = New System.Drawing.Size(22, 19)
        Me.TB_D.Text = "D"
        '
        'TB_E
        '
        Me.TB_E.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_E.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_E.ForeColor = System.Drawing.Color.Black
        Me.TB_E.Image = CType(resources.GetObject("TB_E.Image"), System.Drawing.Image)
        Me.TB_E.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_E.Name = "TB_E"
        Me.TB_E.Size = New System.Drawing.Size(22, 19)
        Me.TB_E.Text = "E"
        '
        'TB_F
        '
        Me.TB_F.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_F.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_F.ForeColor = System.Drawing.Color.Black
        Me.TB_F.Image = CType(resources.GetObject("TB_F.Image"), System.Drawing.Image)
        Me.TB_F.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_F.Name = "TB_F"
        Me.TB_F.Size = New System.Drawing.Size(22, 19)
        Me.TB_F.Text = "F"
        '
        'TB_G
        '
        Me.TB_G.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_G.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_G.ForeColor = System.Drawing.Color.Black
        Me.TB_G.Image = CType(resources.GetObject("TB_G.Image"), System.Drawing.Image)
        Me.TB_G.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_G.Name = "TB_G"
        Me.TB_G.Size = New System.Drawing.Size(22, 19)
        Me.TB_G.Text = "G"
        '
        'TB_H
        '
        Me.TB_H.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_H.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_H.ForeColor = System.Drawing.Color.Black
        Me.TB_H.Image = CType(resources.GetObject("TB_H.Image"), System.Drawing.Image)
        Me.TB_H.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_H.Name = "TB_H"
        Me.TB_H.Size = New System.Drawing.Size(22, 19)
        Me.TB_H.Text = "H"
        '
        'TB_I
        '
        Me.TB_I.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_I.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_I.ForeColor = System.Drawing.Color.Black
        Me.TB_I.Image = CType(resources.GetObject("TB_I.Image"), System.Drawing.Image)
        Me.TB_I.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_I.Name = "TB_I"
        Me.TB_I.Size = New System.Drawing.Size(22, 19)
        Me.TB_I.Text = "I"
        '
        'TB_J
        '
        Me.TB_J.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_J.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_J.ForeColor = System.Drawing.Color.Black
        Me.TB_J.Image = CType(resources.GetObject("TB_J.Image"), System.Drawing.Image)
        Me.TB_J.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_J.Name = "TB_J"
        Me.TB_J.Size = New System.Drawing.Size(22, 19)
        Me.TB_J.Text = "J"
        '
        'TB_K
        '
        Me.TB_K.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_K.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_K.ForeColor = System.Drawing.Color.Black
        Me.TB_K.Image = CType(resources.GetObject("TB_K.Image"), System.Drawing.Image)
        Me.TB_K.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_K.Name = "TB_K"
        Me.TB_K.Size = New System.Drawing.Size(22, 19)
        Me.TB_K.Text = "K"
        '
        'TB_L
        '
        Me.TB_L.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_L.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_L.ForeColor = System.Drawing.Color.Black
        Me.TB_L.Image = CType(resources.GetObject("TB_L.Image"), System.Drawing.Image)
        Me.TB_L.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_L.Name = "TB_L"
        Me.TB_L.Size = New System.Drawing.Size(22, 19)
        Me.TB_L.Text = "L"
        '
        'TB_M
        '
        Me.TB_M.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_M.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_M.ForeColor = System.Drawing.Color.Black
        Me.TB_M.Image = CType(resources.GetObject("TB_M.Image"), System.Drawing.Image)
        Me.TB_M.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_M.Name = "TB_M"
        Me.TB_M.Size = New System.Drawing.Size(22, 19)
        Me.TB_M.Text = "M"
        '
        'TB_N
        '
        Me.TB_N.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_N.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_N.ForeColor = System.Drawing.Color.Black
        Me.TB_N.Image = CType(resources.GetObject("TB_N.Image"), System.Drawing.Image)
        Me.TB_N.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_N.Name = "TB_N"
        Me.TB_N.Size = New System.Drawing.Size(22, 19)
        Me.TB_N.Text = "N"
        '
        'TB_O
        '
        Me.TB_O.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_O.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_O.ForeColor = System.Drawing.Color.Black
        Me.TB_O.Image = CType(resources.GetObject("TB_O.Image"), System.Drawing.Image)
        Me.TB_O.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_O.Name = "TB_O"
        Me.TB_O.Size = New System.Drawing.Size(22, 19)
        Me.TB_O.Text = "O"
        '
        'TB_P
        '
        Me.TB_P.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_P.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_P.ForeColor = System.Drawing.Color.Black
        Me.TB_P.Image = CType(resources.GetObject("TB_P.Image"), System.Drawing.Image)
        Me.TB_P.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_P.Name = "TB_P"
        Me.TB_P.Size = New System.Drawing.Size(22, 19)
        Me.TB_P.Text = "P"
        '
        'TB_Q
        '
        Me.TB_Q.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_Q.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_Q.ForeColor = System.Drawing.Color.Black
        Me.TB_Q.Image = CType(resources.GetObject("TB_Q.Image"), System.Drawing.Image)
        Me.TB_Q.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_Q.Name = "TB_Q"
        Me.TB_Q.Size = New System.Drawing.Size(22, 19)
        Me.TB_Q.Text = "Q"
        '
        'TB_R
        '
        Me.TB_R.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_R.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_R.ForeColor = System.Drawing.Color.Black
        Me.TB_R.Image = CType(resources.GetObject("TB_R.Image"), System.Drawing.Image)
        Me.TB_R.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_R.Name = "TB_R"
        Me.TB_R.Size = New System.Drawing.Size(22, 19)
        Me.TB_R.Text = "R"
        '
        'TB_S
        '
        Me.TB_S.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_S.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_S.ForeColor = System.Drawing.Color.Black
        Me.TB_S.Image = CType(resources.GetObject("TB_S.Image"), System.Drawing.Image)
        Me.TB_S.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_S.Name = "TB_S"
        Me.TB_S.Size = New System.Drawing.Size(22, 19)
        Me.TB_S.Text = "S"
        '
        'TB_T
        '
        Me.TB_T.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_T.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_T.ForeColor = System.Drawing.Color.Black
        Me.TB_T.Image = CType(resources.GetObject("TB_T.Image"), System.Drawing.Image)
        Me.TB_T.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_T.Name = "TB_T"
        Me.TB_T.Size = New System.Drawing.Size(22, 19)
        Me.TB_T.Text = "T"
        '
        'TB_U
        '
        Me.TB_U.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_U.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_U.ForeColor = System.Drawing.Color.Black
        Me.TB_U.Image = CType(resources.GetObject("TB_U.Image"), System.Drawing.Image)
        Me.TB_U.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_U.Name = "TB_U"
        Me.TB_U.Size = New System.Drawing.Size(22, 19)
        Me.TB_U.Text = "U"
        '
        'TB_V
        '
        Me.TB_V.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_V.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_V.ForeColor = System.Drawing.Color.Black
        Me.TB_V.Image = CType(resources.GetObject("TB_V.Image"), System.Drawing.Image)
        Me.TB_V.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_V.Name = "TB_V"
        Me.TB_V.Size = New System.Drawing.Size(22, 19)
        Me.TB_V.Text = "V"
        '
        'TB_W
        '
        Me.TB_W.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_W.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_W.ForeColor = System.Drawing.Color.Black
        Me.TB_W.Image = CType(resources.GetObject("TB_W.Image"), System.Drawing.Image)
        Me.TB_W.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_W.Name = "TB_W"
        Me.TB_W.Size = New System.Drawing.Size(22, 19)
        Me.TB_W.Text = "W"
        '
        'TB_X
        '
        Me.TB_X.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_X.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_X.ForeColor = System.Drawing.Color.Black
        Me.TB_X.Image = CType(resources.GetObject("TB_X.Image"), System.Drawing.Image)
        Me.TB_X.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_X.Name = "TB_X"
        Me.TB_X.Size = New System.Drawing.Size(22, 19)
        Me.TB_X.Text = "X"
        '
        'TB_Y
        '
        Me.TB_Y.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_Y.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_Y.ForeColor = System.Drawing.Color.Black
        Me.TB_Y.Image = CType(resources.GetObject("TB_Y.Image"), System.Drawing.Image)
        Me.TB_Y.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_Y.Name = "TB_Y"
        Me.TB_Y.Size = New System.Drawing.Size(22, 19)
        Me.TB_Y.Text = "Y"
        '
        'TB_Z
        '
        Me.TB_Z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TB_Z.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TB_Z.ForeColor = System.Drawing.Color.Black
        Me.TB_Z.Image = CType(resources.GetObject("TB_Z.Image"), System.Drawing.Image)
        Me.TB_Z.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TB_Z.Name = "TB_Z"
        Me.TB_Z.Size = New System.Drawing.Size(22, 19)
        Me.TB_Z.Text = "Z"
        '
        'txtCerca
        '
        Me.txtCerca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCerca.Location = New System.Drawing.Point(6, 4)
        Me.txtCerca.Name = "txtCerca"
        Me.txtCerca.Size = New System.Drawing.Size(129, 23)
        Me.txtCerca.TabIndex = 68
        '
        'tvClienti
        '
        Me.tvClienti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvClienti.ImageIndex = 0
        Me.tvClienti.ImageList = Me.imlCli
        Me.tvClienti.Location = New System.Drawing.Point(33, 31)
        Me.tvClienti.Name = "tvClienti"
        Me.tvClienti.SelectedImageIndex = 0
        Me.tvClienti.Size = New System.Drawing.Size(408, 477)
        Me.tvClienti.TabIndex = 0
        '
        'imlCli
        '
        Me.imlCli.ImageStream = CType(resources.GetObject("imlCli.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCli.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCli.Images.SetKeyName(0, "_user.png")
        Me.imlCli.Images.SetKeyName(1, "_Ordine.png")
        Me.imlCli.Images.SetKeyName(2, "_Stampa.png")
        Me.imlCli.Images.SetKeyName(3, "_Billing.png")
        Me.imlCli.Images.SetKeyName(4, "_Spesa.png")
        Me.imlCli.Images.SetKeyName(5, "_bank.png")
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(357, 3)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(84, 23)
        Me.lnkAggiorna.TabIndex = 66
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpRubrica
        '
        Me.tpRubrica.Controls.Add(Me.UcRubrica1)
        Me.tpRubrica.ImageKey = "ico_RU.png"
        Me.tpRubrica.Location = New System.Drawing.Point(4, 31)
        Me.tpRubrica.Name = "tpRubrica"
        Me.tpRubrica.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRubrica.Size = New System.Drawing.Size(1231, 517)
        Me.tpRubrica.TabIndex = 5
        Me.tpRubrica.Text = "Rubrica"
        Me.tpRubrica.UseVisualStyleBackColor = True
        '
        'UcRubrica1
        '
        Me.UcRubrica1.BackColor = System.Drawing.Color.White
        Me.UcRubrica1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcRubrica1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcRubrica1.Location = New System.Drawing.Point(3, 3)
        Me.UcRubrica1.Name = "UcRubrica1"
        Me.UcRubrica1.Size = New System.Drawing.Size(1225, 511)
        Me.UcRubrica1.TabIndex = 0
        '
        'tpSituazClienti
        '
        Me.tpSituazClienti.Controls.Add(Me.UcAmministrazioneSituazioneClienti)
        Me.tpSituazClienti.ImageKey = "ico_S.png"
        Me.tpSituazClienti.Location = New System.Drawing.Point(4, 31)
        Me.tpSituazClienti.Name = "tpSituazClienti"
        Me.tpSituazClienti.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSituazClienti.Size = New System.Drawing.Size(1231, 517)
        Me.tpSituazClienti.TabIndex = 9
        Me.tpSituazClienti.Text = "Situazione Clienti"
        Me.tpSituazClienti.UseVisualStyleBackColor = True
        '
        'UcAmministrazioneSituazioneClienti
        '
        Me.UcAmministrazioneSituazioneClienti.BackColor = System.Drawing.Color.White
        Me.UcAmministrazioneSituazioneClienti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazioneSituazioneClienti.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazioneSituazioneClienti.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazioneSituazioneClienti.Name = "UcAmministrazioneSituazioneClienti"
        Me.UcAmministrazioneSituazioneClienti.Size = New System.Drawing.Size(1225, 511)
        Me.UcAmministrazioneSituazioneClienti.TabIndex = 0
        '
        'tpScadenzario
        '
        Me.tpScadenzario.Controls.Add(Me.UcScadenzario)
        Me.tpScadenzario.ImageKey = "ico_SC.png"
        Me.tpScadenzario.Location = New System.Drawing.Point(4, 31)
        Me.tpScadenzario.Name = "tpScadenzario"
        Me.tpScadenzario.Padding = New System.Windows.Forms.Padding(3)
        Me.tpScadenzario.Size = New System.Drawing.Size(1231, 517)
        Me.tpScadenzario.TabIndex = 10
        Me.tpScadenzario.Text = "Scadenzario"
        Me.tpScadenzario.UseVisualStyleBackColor = True
        '
        'UcScadenzario
        '
        Me.UcScadenzario.BackColor = System.Drawing.Color.White
        Me.UcScadenzario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcScadenzario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcScadenzario.Location = New System.Drawing.Point(3, 3)
        Me.UcScadenzario.Name = "UcScadenzario"
        Me.UcScadenzario.Size = New System.Drawing.Size(1225, 511)
        Me.UcScadenzario.TabIndex = 0
        '
        'tpOrdiniBonifico
        '
        Me.tpOrdiniBonifico.Controls.Add(Me.UcOrdiniBonifico)
        Me.tpOrdiniBonifico.ImageKey = "ico_OB.png"
        Me.tpOrdiniBonifico.Location = New System.Drawing.Point(4, 31)
        Me.tpOrdiniBonifico.Name = "tpOrdiniBonifico"
        Me.tpOrdiniBonifico.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOrdiniBonifico.Size = New System.Drawing.Size(1231, 517)
        Me.tpOrdiniBonifico.TabIndex = 12
        Me.tpOrdiniBonifico.Text = "Ordini con Bonifico Anticipato"
        Me.tpOrdiniBonifico.UseVisualStyleBackColor = True
        '
        'UcOrdiniBonifico
        '
        Me.UcOrdiniBonifico.BackColor = System.Drawing.Color.White
        Me.UcOrdiniBonifico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcOrdiniBonifico.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcOrdiniBonifico.Location = New System.Drawing.Point(3, 3)
        Me.UcOrdiniBonifico.Name = "UcOrdiniBonifico"
        Me.UcOrdiniBonifico.Size = New System.Drawing.Size(1225, 511)
        Me.UcOrdiniBonifico.TabIndex = 0
        '
        'tpCoupon
        '
        Me.tpCoupon.Controls.Add(Me.UcCoupon1)
        Me.tpCoupon.ImageKey = "ico_CS.png"
        Me.tpCoupon.Location = New System.Drawing.Point(4, 31)
        Me.tpCoupon.Name = "tpCoupon"
        Me.tpCoupon.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCoupon.Size = New System.Drawing.Size(1231, 517)
        Me.tpCoupon.TabIndex = 11
        Me.tpCoupon.Text = "Coupon di Sconto"
        Me.tpCoupon.UseVisualStyleBackColor = True
        '
        'UcCoupon1
        '
        Me.UcCoupon1.BackColor = System.Drawing.Color.White
        Me.UcCoupon1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcCoupon1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcCoupon1.IdRub = 0
        Me.UcCoupon1.Location = New System.Drawing.Point(3, 3)
        Me.UcCoupon1.Name = "UcCoupon1"
        Me.UcCoupon1.Size = New System.Drawing.Size(1225, 511)
        Me.UcCoupon1.TabIndex = 0
        '
        'tpPromo
        '
        Me.tpPromo.Controls.Add(Me.UcAmministrazionePromo)
        Me.tpPromo.ImageKey = "ico_PR_R.png"
        Me.tpPromo.Location = New System.Drawing.Point(4, 31)
        Me.tpPromo.Name = "tpPromo"
        Me.tpPromo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPromo.Size = New System.Drawing.Size(1231, 517)
        Me.tpPromo.TabIndex = 13
        Me.tpPromo.Text = "Promo"
        Me.tpPromo.UseVisualStyleBackColor = True
        '
        'UcAmministrazionePromo
        '
        Me.UcAmministrazionePromo.BackColor = System.Drawing.Color.White
        Me.UcAmministrazionePromo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazionePromo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazionePromo.IdRub = 0
        Me.UcAmministrazionePromo.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazionePromo.Name = "UcAmministrazionePromo"
        Me.UcAmministrazionePromo.Size = New System.Drawing.Size(1225, 511)
        Me.UcAmministrazionePromo.TabIndex = 0
        '
        'tpReport
        '
        Me.tpReport.Controls.Add(Me.UcAmministrazioneReport)
        Me.tpReport.ImageKey = "ico_RP_R.png"
        Me.tpReport.Location = New System.Drawing.Point(4, 31)
        Me.tpReport.Name = "tpReport"
        Me.tpReport.Padding = New System.Windows.Forms.Padding(3)
        Me.tpReport.Size = New System.Drawing.Size(1231, 517)
        Me.tpReport.TabIndex = 14
        Me.tpReport.Text = "Report"
        Me.tpReport.UseVisualStyleBackColor = True
        '
        'UcAmministrazioneReport
        '
        Me.UcAmministrazioneReport.BackColor = System.Drawing.Color.White
        Me.UcAmministrazioneReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazioneReport.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazioneReport.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazioneReport.Name = "UcAmministrazioneReport"
        Me.UcAmministrazioneReport.Size = New System.Drawing.Size(1225, 511)
        Me.UcAmministrazioneReport.TabIndex = 0
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "ico_AM.png")
        Me.imlTab.Images.SetKeyName(1, "ico_DO.png")
        Me.imlTab.Images.SetKeyName(2, "ico_RU.png")
        Me.imlTab.Images.SetKeyName(3, "ico_OB.png")
        Me.imlTab.Images.SetKeyName(4, "ico_CS.png")
        Me.imlTab.Images.SetKeyName(5, "ico_SC.png")
        Me.imlTab.Images.SetKeyName(6, "ico_S.png")
        Me.imlTab.Images.SetKeyName(7, "ico_PR_R.png")
        Me.imlTab.Images.SetKeyName(8, "ico_RP_R.png")
        Me.imlTab.Images.SetKeyName(9, "_Dashboard.png")
        Me.imlTab.Images.SetKeyName(10, "_Money26.png")
        '
        'imlMerceUscita
        '
        Me.imlMerceUscita.ImageStream = CType(resources.GetObject("imlMerceUscita.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMerceUscita.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMerceUscita.Images.SetKeyName(0, "icoCli.jpg")
        Me.imlMerceUscita.Images.SetKeyName(1, "icoOrder.jpg")
        Me.imlMerceUscita.Images.SetKeyName(2, "icoPrint.jpg")
        Me.imlMerceUscita.Images.SetKeyName(3, "icoMoney.jpg")
        Me.imlMerceUscita.Images.SetKeyName(4, "icoRubRed.jpg")
        Me.imlMerceUscita.Images.SetKeyName(5, "icoParamRed.jpg")
        Me.imlMerceUscita.Images.SetKeyName(6, "Corriere.png")
        Me.imlMerceUscita.Images.SetKeyName(7, "icoCal.jpg")
        Me.imlMerceUscita.Images.SetKeyName(8, "IcoFast.png")
        Me.imlMerceUscita.Images.SetKeyName(9, "IcoLow.png")
        Me.imlMerceUscita.Images.SetKeyName(10, "Box.bmp")
        '
        'tpPagamenti
        '
        Me.tpPagamenti.Controls.Add(Me.UcAmministrazionePagamenti)
        Me.tpPagamenti.ImageKey = "_Money26.png"
        Me.tpPagamenti.Location = New System.Drawing.Point(4, 31)
        Me.tpPagamenti.Name = "tpPagamenti"
        Me.tpPagamenti.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPagamenti.Size = New System.Drawing.Size(1231, 517)
        Me.tpPagamenti.TabIndex = 16
        Me.tpPagamenti.Text = "Pagamenti"
        Me.tpPagamenti.UseVisualStyleBackColor = True
        '
        'UcAmministrazionePagamenti
        '
        Me.UcAmministrazionePagamenti.BackColor = System.Drawing.Color.White
        Me.UcAmministrazionePagamenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazionePagamenti.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcAmministrazionePagamenti.IdDocRif = 0
        Me.UcAmministrazionePagamenti.IdRub = 0
        Me.UcAmministrazionePagamenti.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazionePagamenti.Name = "UcAmministrazionePagamenti"
        Me.UcAmministrazionePagamenti.Size = New System.Drawing.Size(1225, 511)
        Me.UcAmministrazionePagamenti.TabIndex = 0
        '
        'ucAmministrazione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TabMain)
        Me.Name = "ucAmministrazione"
        Me.Size = New System.Drawing.Size(1239, 552)
        Me.TabMain.ResumeLayout(False)
        Me.tpDashboard.ResumeLayout(False)
        Me.TbDocOut.ResumeLayout(False)
        Me.tpRiepilogo.ResumeLayout(False)
        Me.SplitContainerRiepilogo.Panel1.ResumeLayout(False)
        Me.SplitContainerRiepilogo.Panel1.PerformLayout()
        CType(Me.SplitContainerRiepilogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerRiepilogo.ResumeLayout(False)
        Me.toolRubrica.ResumeLayout(False)
        Me.toolRubrica.PerformLayout()
        Me.tpRubrica.ResumeLayout(False)
        Me.tpSituazClienti.ResumeLayout(False)
        Me.tpScadenzario.ResumeLayout(False)
        Me.tpOrdiniBonifico.ResumeLayout(False)
        Me.tpCoupon.ResumeLayout(False)
        Me.tpPromo.ResumeLayout(False)
        Me.tpReport.ResumeLayout(False)
        Me.tpPagamenti.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TbDocOut As System.Windows.Forms.TabPage
    Friend WithEvents UcContab As Former.ucDocumentiFiscali
    Friend WithEvents tpRiepilogo As System.Windows.Forms.TabPage
    Friend WithEvents tvClienti As System.Windows.Forms.TreeView
    Friend WithEvents lnkAggiorna As System.Windows.Forms.LinkLabel
    Friend WithEvents imlCli As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainerRiepilogo As System.Windows.Forms.SplitContainer

    Private Sub ucFatture_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Not ControlloAttivo Is Nothing Then
            ControlloAttivo.Dispose()
            ControlloAttivo = Nothing
        End If
    End Sub
    Friend WithEvents toolRubrica As System.Windows.Forms.ToolStrip
    Friend WithEvents TB_123 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_A As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_B As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_C As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_D As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_E As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_F As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_G As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_H As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_I As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_J As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_K As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_L As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_M As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_N As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_O As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_P As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_Q As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_R As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_S As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_T As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_U As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_V As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_W As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_X As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_Y As System.Windows.Forms.ToolStripButton
    Friend WithEvents TB_Z As System.Windows.Forms.ToolStripButton
    Friend WithEvents lnkCerca As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCerca As System.Windows.Forms.TextBox
    Friend WithEvents tpRubrica As System.Windows.Forms.TabPage
    Friend WithEvents UcRubrica1 As Former.ucAmministrazioneRubrica
    Friend WithEvents imlMerceUscita As System.Windows.Forms.ImageList
    'Friend WithEvents UcDocumentiFiscaliEx As Former.ucDocumentiFiscaliEx
    Friend WithEvents tpSituazClienti As System.Windows.Forms.TabPage
    Friend WithEvents tpScadenzario As System.Windows.Forms.TabPage
    Friend WithEvents UcScadenzario As Former.ucScadenzarioMese
    Friend WithEvents tpCoupon As System.Windows.Forms.TabPage
    Friend WithEvents UcCoupon1 As Former.ucAmministrazioneCoupon
    Friend WithEvents tpOrdiniBonifico As System.Windows.Forms.TabPage
    Friend WithEvents UcOrdiniBonifico As Former.ucAmministrazioneOrdiniBonifico
    Friend WithEvents imlTab As ImageList
    Friend WithEvents tpPromo As TabPage
    Friend WithEvents UcAmministrazionePromo As ucAmministrazionePromo
    Friend WithEvents tpReport As TabPage
    Friend WithEvents UcAmministrazioneReport As ucAmministrazioneReport
    Friend WithEvents UcAmministrazioneSituazioneClienti As ucAmministrazioneSituazioneClienti
    Friend WithEvents tpDashboard As TabPage
    Friend WithEvents UcAmministrazioneDashboard As ucAmministrazioneDashboard
    Friend WithEvents tpPagamenti As TabPage
    Friend WithEvents UcAmministrazionePagamenti As ucAmministrazionePagamenti
End Class
