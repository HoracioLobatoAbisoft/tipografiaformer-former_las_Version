<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMarketing
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
        Me.TabMarketing = New System.Windows.Forms.TabControl()
        Me.tpGruppi = New System.Windows.Forms.TabPage()
        Me.UcGruppi1 = New Former.ucAmministrazioneRubricaGruppi()
        Me.tpMarkWeb = New System.Windows.Forms.TabPage()
        Me.UcMarketingWeb = New Former.ucMarketingWeb()
        Me.tpMarkProgr = New System.Windows.Forms.TabPage()
        Me.UcMarkProgr = New Former.ucMarketingProgrammato()
        Me.tpEmail = New System.Windows.Forms.TabPage()
        Me.UcEmail = New Former.ucAmministrazioneEmailAvviso()
        Me.TabMarketing.SuspendLayout()
        Me.tpGruppi.SuspendLayout()
        Me.tpMarkWeb.SuspendLayout()
        Me.tpMarkProgr.SuspendLayout()
        Me.tpEmail.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMarketing
        '
        Me.TabMarketing.Controls.Add(Me.tpGruppi)
        Me.TabMarketing.Controls.Add(Me.tpMarkProgr)
        Me.TabMarketing.Controls.Add(Me.tpMarkWeb)
        Me.TabMarketing.Controls.Add(Me.tpEmail)
        Me.TabMarketing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMarketing.Location = New System.Drawing.Point(0, 0)
        Me.TabMarketing.Name = "TabMarketing"
        Me.TabMarketing.SelectedIndex = 0
        Me.TabMarketing.Size = New System.Drawing.Size(911, 428)
        Me.TabMarketing.TabIndex = 63
        '
        'tpGruppi
        '
        Me.tpGruppi.Controls.Add(Me.UcGruppi1)
        Me.tpGruppi.Location = New System.Drawing.Point(4, 24)
        Me.tpGruppi.Name = "tpGruppi"
        Me.tpGruppi.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGruppi.Size = New System.Drawing.Size(903, 400)
        Me.tpGruppi.TabIndex = 1
        Me.tpGruppi.Text = "Gruppi di Marketing"
        Me.tpGruppi.UseVisualStyleBackColor = True
        '
        'UcGruppi1
        '
        Me.UcGruppi1.BackColor = System.Drawing.Color.White
        Me.UcGruppi1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcGruppi1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcGruppi1.Location = New System.Drawing.Point(3, 3)
        Me.UcGruppi1.Name = "UcGruppi1"
        Me.UcGruppi1.Size = New System.Drawing.Size(897, 394)
        Me.UcGruppi1.TabIndex = 0
        '
        'tpMarkWeb
        '
        Me.tpMarkWeb.Controls.Add(Me.UcMarketingWeb)
        Me.tpMarkWeb.Location = New System.Drawing.Point(4, 24)
        Me.tpMarkWeb.Name = "tpMarkWeb"
        Me.tpMarkWeb.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMarkWeb.Size = New System.Drawing.Size(903, 400)
        Me.tpMarkWeb.TabIndex = 3
        Me.tpMarkWeb.Text = "Campagna Marketing"
        Me.tpMarkWeb.UseVisualStyleBackColor = True
        '
        'UcMarketingWeb
        '
        Me.UcMarketingWeb.BackColor = System.Drawing.Color.White
        Me.UcMarketingWeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMarketingWeb.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcMarketingWeb.Location = New System.Drawing.Point(3, 3)
        Me.UcMarketingWeb.Name = "UcMarketingWeb"
        Me.UcMarketingWeb.Size = New System.Drawing.Size(897, 394)
        Me.UcMarketingWeb.TabIndex = 0
        '
        'tpMarkProgr
        '
        Me.tpMarkProgr.Controls.Add(Me.UcMarkProgr)
        Me.tpMarkProgr.Location = New System.Drawing.Point(4, 24)
        Me.tpMarkProgr.Name = "tpMarkProgr"
        Me.tpMarkProgr.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMarkProgr.Size = New System.Drawing.Size(903, 400)
        Me.tpMarkProgr.TabIndex = 0
        Me.tpMarkProgr.Text = "Marketing"
        Me.tpMarkProgr.UseVisualStyleBackColor = True
        '
        'UcMarkProgr
        '
        Me.UcMarkProgr.BackColor = System.Drawing.Color.White
        Me.UcMarkProgr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcMarkProgr.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcMarkProgr.Location = New System.Drawing.Point(3, 3)
        Me.UcMarkProgr.Name = "UcMarkProgr"
        Me.UcMarkProgr.Size = New System.Drawing.Size(897, 394)
        Me.UcMarkProgr.TabIndex = 0
        '
        'tpEmail
        '
        Me.tpEmail.Controls.Add(Me.UcEmail)
        Me.tpEmail.Location = New System.Drawing.Point(4, 24)
        Me.tpEmail.Name = "tpEmail"
        Me.tpEmail.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEmail.Size = New System.Drawing.Size(903, 400)
        Me.tpEmail.TabIndex = 2
        Me.tpEmail.Text = "Email di Avviso"
        Me.tpEmail.UseVisualStyleBackColor = True
        '
        'UcEmail
        '
        Me.UcEmail.BackColor = System.Drawing.Color.White
        Me.UcEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcEmail.Location = New System.Drawing.Point(3, 3)
        Me.UcEmail.Name = "UcEmail"
        Me.UcEmail.Size = New System.Drawing.Size(897, 394)
        Me.UcEmail.TabIndex = 0
        '
        'ucMarketing
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TabMarketing)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucMarketing"
        Me.Size = New System.Drawing.Size(911, 428)
        Me.TabMarketing.ResumeLayout(False)
        Me.tpGruppi.ResumeLayout(False)
        Me.tpMarkWeb.ResumeLayout(False)
        Me.tpMarkProgr.ResumeLayout(False)
        Me.tpEmail.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMarketing As System.Windows.Forms.TabControl
    Friend WithEvents tpMarkProgr As System.Windows.Forms.TabPage
    Friend WithEvents tpGruppi As System.Windows.Forms.TabPage
    Friend WithEvents UcGruppi1 As Former.ucAmministrazioneRubricaGruppi
    Friend WithEvents UcMarkProgr As Former.ucMarketingProgrammato
    Friend WithEvents tpEmail As System.Windows.Forms.TabPage
    Friend WithEvents UcEmail As Former.ucAmministrazioneEmailAvviso
    Friend WithEvents tpMarkWeb As System.Windows.Forms.TabPage
    Friend WithEvents UcMarketingWeb As Former.ucMarketingWeb

End Class
