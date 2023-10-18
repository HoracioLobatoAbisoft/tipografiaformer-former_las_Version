<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAmministrazioneReport
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
        Me.cmbMeseRif = New System.Windows.Forms.ComboBox()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.webReport = New System.Windows.Forms.WebBrowser()
        Me.TabReport = New System.Windows.Forms.TabControl()
        Me.tpStatistiche = New System.Windows.Forms.TabPage()
        Me.lnkStampa = New System.Windows.Forms.LinkLabel()
        Me.tpCompetitor = New System.Windows.Forms.TabPage()
        Me.TabReport.SuspendLayout()
        Me.tpStatistiche.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbMeseRif
        '
        Me.cmbMeseRif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMeseRif.FormattingEnabled = True
        Me.cmbMeseRif.Location = New System.Drawing.Point(6, 6)
        Me.cmbMeseRif.Name = "cmbMeseRif"
        Me.cmbMeseRif.Size = New System.Drawing.Size(210, 23)
        Me.cmbMeseRif.TabIndex = 1
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources._Aggiorna
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(222, 6)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(84, 23)
        Me.lnkAggiorna.TabIndex = 46
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'webReport
        '
        Me.webReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webReport.Location = New System.Drawing.Point(6, 35)
        Me.webReport.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webReport.Name = "webReport"
        Me.webReport.Size = New System.Drawing.Size(785, 471)
        Me.webReport.TabIndex = 47
        '
        'TabReport
        '
        Me.TabReport.Controls.Add(Me.tpStatistiche)
        Me.TabReport.Controls.Add(Me.tpCompetitor)
        Me.TabReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabReport.Location = New System.Drawing.Point(0, 0)
        Me.TabReport.Name = "TabReport"
        Me.TabReport.SelectedIndex = 0
        Me.TabReport.Size = New System.Drawing.Size(805, 540)
        Me.TabReport.TabIndex = 48
        '
        'tpStatistiche
        '
        Me.tpStatistiche.Controls.Add(Me.lnkStampa)
        Me.tpStatistiche.Controls.Add(Me.cmbMeseRif)
        Me.tpStatistiche.Controls.Add(Me.webReport)
        Me.tpStatistiche.Controls.Add(Me.lnkAggiorna)
        Me.tpStatistiche.Location = New System.Drawing.Point(4, 24)
        Me.tpStatistiche.Name = "tpStatistiche"
        Me.tpStatistiche.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStatistiche.Size = New System.Drawing.Size(797, 512)
        Me.tpStatistiche.TabIndex = 0
        Me.tpStatistiche.Text = "Statistiche"
        Me.tpStatistiche.UseVisualStyleBackColor = True
        '
        'lnkStampa
        '
        Me.lnkStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkStampa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkStampa.Image = Global.Former.My.Resources.Resources._Stampa
        Me.lnkStampa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkStampa.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkStampa.Location = New System.Drawing.Point(714, 6)
        Me.lnkStampa.Name = "lnkStampa"
        Me.lnkStampa.Size = New System.Drawing.Size(80, 23)
        Me.lnkStampa.TabIndex = 55
        Me.lnkStampa.TabStop = True
        Me.lnkStampa.Text = "Stampa"
        Me.lnkStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpCompetitor
        '
        Me.tpCompetitor.Location = New System.Drawing.Point(4, 24)
        Me.tpCompetitor.Name = "tpCompetitor"
        Me.tpCompetitor.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCompetitor.Size = New System.Drawing.Size(797, 512)
        Me.tpCompetitor.TabIndex = 1
        Me.tpCompetitor.Text = "Competitor"
        Me.tpCompetitor.UseVisualStyleBackColor = True
        '
        'ucAmministrazioneReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TabReport)
        Me.Name = "ucAmministrazioneReport"
        Me.Size = New System.Drawing.Size(805, 540)
        Me.TabReport.ResumeLayout(False)
        Me.tpStatistiche.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbMeseRif As ComboBox
    Friend WithEvents lnkAggiorna As LinkLabel
    Friend WithEvents webReport As WebBrowser
    Friend WithEvents TabReport As TabControl
    Friend WithEvents tpStatistiche As TabPage
    Friend WithEvents tpCompetitor As TabPage
    Friend WithEvents lnkStampa As LinkLabel
End Class
