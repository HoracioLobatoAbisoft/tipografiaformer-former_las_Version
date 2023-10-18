<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucProduzionePackaging
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucProduzionePackaging))
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tpCommesse = New System.Windows.Forms.TabPage()
        Me.UcCommesse = New Former.ucCommesse()
        Me.tabMain.SuspendLayout()
        Me.tpCommesse.SuspendLayout()
        Me.SuspendLayout()
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "RepEtichette.png")
        Me.imlTab.Images.SetKeyName(1, "RepRicamo.png")
        Me.imlTab.Images.SetKeyName(2, "RepPackaging.png")
        Me.imlTab.Images.SetKeyName(3, "RepDigitale.png")
        Me.imlTab.Images.SetKeyName(4, "RepOffset.png")
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tpCommesse)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.ImageList = Me.imlTab
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1225, 583)
        Me.tabMain.TabIndex = 1
        '
        'tpCommesse
        '
        Me.tpCommesse.Controls.Add(Me.UcCommesse)
        Me.tpCommesse.ImageKey = "RepPackaging.png"
        Me.tpCommesse.Location = New System.Drawing.Point(4, 27)
        Me.tpCommesse.Name = "tpCommesse"
        Me.tpCommesse.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCommesse.Size = New System.Drawing.Size(1217, 552)
        Me.tpCommesse.TabIndex = 0
        Me.tpCommesse.Tag = "Commesse Packaging"
        Me.tpCommesse.Text = "Commesse Packaging"
        Me.tpCommesse.UseVisualStyleBackColor = True
        '
        'UcCommesse
        '
        Me.UcCommesse.BackColor = System.Drawing.Color.White
        Me.UcCommesse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcCommesse.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.UcCommesse.IdRepartoRiferimento = FormerLib.FormerEnum.enRepartoWeb.Packaging
        Me.UcCommesse.Location = New System.Drawing.Point(3, 3)
        Me.UcCommesse.Name = "UcCommesse"
        Me.UcCommesse.Size = New System.Drawing.Size(1211, 546)
        Me.UcCommesse.TabIndex = 1
        '
        'ucProduzionePackaging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tabMain)
        Me.Name = "ucProduzionePackaging"
        Me.Size = New System.Drawing.Size(1225, 583)
        Me.tabMain.ResumeLayout(False)
        Me.tpCommesse.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents imlTab As ImageList
    Friend WithEvents tabMain As TabControl
    Friend WithEvents tpCommesse As TabPage
    Friend WithEvents UcCommesse As ucCommesse
End Class
