<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAmministrazioneDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucAmministrazioneDashboard))
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.UcAmministrazioneDashboardCount = New Former.ucAmministrazioneDashboardCount()
        Me.tpContabilita = New System.Windows.Forms.TabPage()
        Me.tpCheckMassivo = New System.Windows.Forms.TabPage()
        Me.UcAmministrazioneCheckMassivoSnc = New Former.ucAmministrazioneCheckMassivo()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.UcAmministrazioneContabilita = New Former.ucAmministrazioneContabilita()
        Me.tabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tpContabilita.SuspendLayout()
        Me.tpCheckMassivo.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.TabPage1)
        Me.tabMain.Controls.Add(Me.tpContabilita)
        Me.tabMain.Controls.Add(Me.tpCheckMassivo)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.ImageList = Me.imlTab
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(840, 685)
        Me.tabMain.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.UcAmministrazioneDashboardCount)
        Me.TabPage1.ImageKey = "_Dashboard.png"
        Me.TabPage1.Location = New System.Drawing.Point(4, 33)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(832, 648)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Dashboard"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'UcAmministrazioneDashboardCount
        '
        Me.UcAmministrazioneDashboardCount.BackColor = System.Drawing.Color.White
        Me.UcAmministrazioneDashboardCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazioneDashboardCount.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazioneDashboardCount.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazioneDashboardCount.Name = "UcAmministrazioneDashboardCount"
        Me.UcAmministrazioneDashboardCount.Size = New System.Drawing.Size(826, 642)
        Me.UcAmministrazioneDashboardCount.TabIndex = 0
        '
        'tpContabilita
        '
        Me.tpContabilita.Controls.Add(Me.UcAmministrazioneContabilita)
        Me.tpContabilita.ImageKey = "_F24.png"
        Me.tpContabilita.Location = New System.Drawing.Point(4, 33)
        Me.tpContabilita.Name = "tpContabilita"
        Me.tpContabilita.Padding = New System.Windows.Forms.Padding(3)
        Me.tpContabilita.Size = New System.Drawing.Size(832, 648)
        Me.tpContabilita.TabIndex = 2
        Me.tpContabilita.Text = "Contabilità"
        Me.tpContabilita.UseVisualStyleBackColor = True
        '
        'tpCheckMassivo
        '
        Me.tpCheckMassivo.Controls.Add(Me.UcAmministrazioneCheckMassivoSnc)
        Me.tpCheckMassivo.ImageKey = "_CaricamentoMassivo.png"
        Me.tpCheckMassivo.Location = New System.Drawing.Point(4, 33)
        Me.tpCheckMassivo.Name = "tpCheckMassivo"
        Me.tpCheckMassivo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCheckMassivo.Size = New System.Drawing.Size(832, 648)
        Me.tpCheckMassivo.TabIndex = 1
        Me.tpCheckMassivo.Text = "Caricamenti Massivi"
        Me.tpCheckMassivo.UseVisualStyleBackColor = True
        '
        'UcAmministrazioneCheckMassivoSnc
        '
        Me.UcAmministrazioneCheckMassivoSnc.BackColor = System.Drawing.Color.White
        Me.UcAmministrazioneCheckMassivoSnc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazioneCheckMassivoSnc.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazioneCheckMassivoSnc.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazioneCheckMassivoSnc.Name = "UcAmministrazioneCheckMassivoSnc"
        Me.UcAmministrazioneCheckMassivoSnc.Size = New System.Drawing.Size(826, 642)
        Me.UcAmministrazioneCheckMassivoSnc.TabIndex = 2
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "_Dashboard.png")
        Me.imlTab.Images.SetKeyName(1, "_CaricamentoMassivo.png")
        Me.imlTab.Images.SetKeyName(2, "_F24.png")
        '
        'UcAmministrazioneContabilita
        '
        Me.UcAmministrazioneContabilita.BackColor = System.Drawing.Color.White
        Me.UcAmministrazioneContabilita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAmministrazioneContabilita.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcAmministrazioneContabilita.Location = New System.Drawing.Point(3, 3)
        Me.UcAmministrazioneContabilita.Name = "UcAmministrazioneContabilita"
        Me.UcAmministrazioneContabilita.Size = New System.Drawing.Size(826, 642)
        Me.UcAmministrazioneContabilita.TabIndex = 0
        '
        'ucAmministrazioneDashboard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tabMain)
        Me.Name = "ucAmministrazioneDashboard"
        Me.Size = New System.Drawing.Size(840, 685)
        Me.tabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.tpContabilita.ResumeLayout(False)
        Me.tpCheckMassivo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabMain As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents tpCheckMassivo As TabPage
    Friend WithEvents imlTab As ImageList
    Friend WithEvents UcAmministrazioneCheckMassivoSnc As ucAmministrazioneCheckMassivo
    Friend WithEvents UcAmministrazioneDashboardCount As ucAmministrazioneDashboardCount
    Friend WithEvents tpContabilita As TabPage
    Friend WithEvents UcAmministrazioneContabilita As ucAmministrazioneContabilita
End Class
