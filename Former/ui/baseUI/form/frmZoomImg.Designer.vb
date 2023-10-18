<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZoomImg
    Inherits BaseFormRad

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmZoomImg))
        Me.btnChiudi = New System.Windows.Forms.Button()
        Me.pctZoom = New System.Windows.Forms.PictureBox()
        Me.imlMain = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTipMsg = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.pctZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChiudi
        '
        Me.btnChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChiudi.BackColor = System.Drawing.Color.White
        Me.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnChiudi.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnChiudi.ForeColor = System.Drawing.Color.Black
        Me.btnChiudi.Location = New System.Drawing.Point(64, 3)
        Me.btnChiudi.Name = "btnChiudi"
        Me.btnChiudi.Size = New System.Drawing.Size(75, 23)
        Me.btnChiudi.TabIndex = 16
        Me.btnChiudi.Text = "Chiudi"
        Me.btnChiudi.UseVisualStyleBackColor = False
        '
        'pctZoom
        '
        Me.pctZoom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pctZoom.Location = New System.Drawing.Point(0, 0)
        Me.pctZoom.Name = "pctZoom"
        Me.pctZoom.Size = New System.Drawing.Size(142, 170)
        Me.pctZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pctZoom.TabIndex = 0
        Me.pctZoom.TabStop = False
        '
        'imlMain
        '
        Me.imlMain.ImageStream = CType(resources.GetObject("imlMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMain.Images.SetKeyName(0, "IcoLogo.jpg")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnChiudi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 141)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 29)
        Me.Panel1.TabIndex = 6
        '
        'frmZoomImg
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnChiudi
        Me.ClientSize = New System.Drawing.Size(142, 170)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pctZoom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmZoomImg"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Zoom"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        CType(Me.pctZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pctZoom As System.Windows.Forms.PictureBox
    Friend WithEvents btnChiudi As Windows.Forms.Button
    Friend WithEvents imlMain As Windows.Forms.ImageList
    Friend WithEvents ToolTipMsg As Windows.Forms.ToolTip
    Friend WithEvents Panel1 As Panel
End Class
