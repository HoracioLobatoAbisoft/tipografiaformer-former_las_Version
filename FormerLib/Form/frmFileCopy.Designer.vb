<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFileCopy
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFileCopy))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.btnIgnore = New System.Windows.Forms.Button()
        Me.btnRetry = New System.Windows.Forms.Button()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ProgressBarCopy = New System.Windows.Forms.ProgressBar()
        Me.lblDestinazione = New System.Windows.Forms.Label()
        Me.lblOrigine = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.tmrStart = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTipFile = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.gbPulsanti.Controls.Add(Me.btnIgnore)
        Me.gbPulsanti.Controls.Add(Me.btnRetry)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 163)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(703, 58)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnIgnore
        '
        Me.btnIgnore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIgnore.Enabled = False
        Me.btnIgnore.Location = New System.Drawing.Point(616, 20)
        Me.btnIgnore.Name = "btnIgnore"
        Me.btnIgnore.Size = New System.Drawing.Size(75, 23)
        Me.btnIgnore.TabIndex = 0
        Me.btnIgnore.Text = "Ignora"
        Me.btnIgnore.UseVisualStyleBackColor = True
        '
        'btnRetry
        '
        Me.btnRetry.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRetry.Enabled = False
        Me.btnRetry.Location = New System.Drawing.Point(535, 20)
        Me.btnRetry.Name = "btnRetry"
        Me.btnRetry.Size = New System.Drawing.Size(75, 23)
        Me.btnRetry.TabIndex = 0
        Me.btnRetry.Text = "Riprova"
        Me.btnRetry.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ImageList = Me.imlTab
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(703, 163)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.ProgressBarCopy)
        Me.tbProd.Controls.Add(Me.lblDestinazione)
        Me.tbProd.Controls.Add(Me.lblOrigine)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.Label35)
        Me.tbProd.ImageKey = "IcoLogo.jpg"
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(695, 135)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Copia file in corso..."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.FormerLib.My.Resources.Resources._Duplica
        Me.PictureBox1.Location = New System.Drawing.Point(15, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'ProgressBarCopy
        '
        Me.ProgressBarCopy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBarCopy.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ProgressBarCopy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgressBarCopy.Location = New System.Drawing.Point(65, 82)
        Me.ProgressBarCopy.Name = "ProgressBarCopy"
        Me.ProgressBarCopy.Size = New System.Drawing.Size(563, 23)
        Me.ProgressBarCopy.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBarCopy.TabIndex = 17
        '
        'lblDestinazione
        '
        Me.lblDestinazione.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDestinazione.AutoEllipsis = True
        Me.lblDestinazione.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDestinazione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblDestinazione.Location = New System.Drawing.Point(150, 45)
        Me.lblDestinazione.Name = "lblDestinazione"
        Me.lblDestinazione.Size = New System.Drawing.Size(478, 15)
        Me.lblDestinazione.TabIndex = 16
        Me.lblDestinazione.Text = "-"
        '
        'lblOrigine
        '
        Me.lblOrigine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOrigine.AutoEllipsis = True
        Me.lblOrigine.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrigine.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblOrigine.Location = New System.Drawing.Point(150, 14)
        Me.lblOrigine.Name = "lblOrigine"
        Me.lblOrigine.Size = New System.Drawing.Size(478, 15)
        Me.lblOrigine.TabIndex = 16
        Me.lblOrigine.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(62, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Destinazione:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(62, 14)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(50, 15)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "Origine:"
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "IcoLogo.jpg")
        '
        'tmrStart
        '
        Me.tmrStart.Enabled = True
        Me.tmrStart.Interval = 500
        '
        'ToolTipFile
        '
        Me.ToolTipFile.ShowAlways = True
        Me.ToolTipFile.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipFile.ToolTipTitle = "Dettaglio"
        '
        'frmFileCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.ClientSize = New System.Drawing.Size(703, 221)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmFileCopy"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Copia file in corso..."
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents ProgressBarCopy As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDestinazione As System.Windows.Forms.Label
    Friend WithEvents lblOrigine As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tmrStart As System.Windows.Forms.Timer
    Friend WithEvents btnRetry As System.Windows.Forms.Button
    Friend WithEvents btnIgnore As System.Windows.Forms.Button
    Friend WithEvents imlTab As Windows.Forms.ImageList
    Friend WithEvents ToolTipFile As Windows.Forms.ToolTip
End Class
