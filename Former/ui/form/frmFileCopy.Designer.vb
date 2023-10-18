<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileCopy
    Inherits baseFormInterna

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
        Me.tmrStart = New System.Windows.Forms.Timer(Me.components)
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnIgnore)
        Me.gbPulsanti.Controls.Add(Me.btnRetry)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 171)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(881, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'btnIgnore
        '
        Me.btnIgnore.Enabled = False
        Me.btnIgnore.Location = New System.Drawing.Point(794, 19)
        Me.btnIgnore.Name = "btnIgnore"
        Me.btnIgnore.Size = New System.Drawing.Size(75, 23)
        Me.btnIgnore.TabIndex = 0
        Me.btnIgnore.Text = "Ignora"
        Me.btnIgnore.UseVisualStyleBackColor = True
        '
        'btnRetry
        '
        Me.btnRetry.Enabled = False
        Me.btnRetry.Location = New System.Drawing.Point(713, 19)
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
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(881, 171)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.PictureBox1)
        Me.tbProd.Controls.Add(Me.ProgressBarCopy)
        Me.tbProd.Controls.Add(Me.lblDestinazione)
        Me.tbProd.Controls.Add(Me.lblOrigine)
        Me.tbProd.Controls.Add(Me.Label1)
        Me.tbProd.Controls.Add(Me.Label35)
        Me.tbProd.Location = New System.Drawing.Point(4, 24)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(873, 143)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Copia file in corso..."
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources._Duplica
        Me.PictureBox1.Location = New System.Drawing.Point(15, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'ProgressBarCopy
        '
        Me.ProgressBarCopy.Location = New System.Drawing.Point(65, 82)
        Me.ProgressBarCopy.Name = "ProgressBarCopy"
        Me.ProgressBarCopy.Size = New System.Drawing.Size(800, 23)
        Me.ProgressBarCopy.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBarCopy.TabIndex = 17
        '
        'lblDestinazione
        '
        Me.lblDestinazione.AutoSize = True
        Me.lblDestinazione.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDestinazione.Location = New System.Drawing.Point(150, 45)
        Me.lblDestinazione.Name = "lblDestinazione"
        Me.lblDestinazione.Size = New System.Drawing.Size(11, 15)
        Me.lblDestinazione.TabIndex = 16
        Me.lblDestinazione.Text = "-"
        '
        'lblOrigine
        '
        Me.lblOrigine.AutoSize = True
        Me.lblOrigine.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrigine.Location = New System.Drawing.Point(150, 14)
        Me.lblOrigine.Name = "lblOrigine"
        Me.lblOrigine.Size = New System.Drawing.Size(11, 15)
        Me.lblOrigine.TabIndex = 16
        Me.lblOrigine.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Destinazione:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(62, 14)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(50, 15)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "Origine:"
        '
        'tmrStart
        '
        Me.tmrStart.Enabled = True
        Me.tmrStart.Interval = 500
        '
        'frmFileCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.ClientSize = New System.Drawing.Size(881, 219)
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
End Class
