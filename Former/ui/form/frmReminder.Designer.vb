<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReminder
    Inherits baseFormInternaFixed

    'Form overrides dispose to clean up the component list.
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
        Me.lnkClose = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lnkRisolvi = New System.Windows.Forms.LinkLabel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblContError = New System.Windows.Forms.Label()
        Me.lblContWarning = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnkClose
        '
        Me.lnkClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkClose.AutoSize = True
        Me.lnkClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lnkClose.Image = Global.Former.My.Resources.Resources._Annulla
        Me.lnkClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkClose.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkClose.Location = New System.Drawing.Point(239, 202)
        Me.lnkClose.MinimumSize = New System.Drawing.Size(0, 28)
        Me.lnkClose.Name = "lnkClose"
        Me.lnkClose.Padding = New System.Windows.Forms.Padding(32, 0, 0, 0)
        Me.lnkClose.Size = New System.Drawing.Size(92, 28)
        Me.lnkClose.TabIndex = 56
        Me.lnkClose.TabStop = True
        Me.lnkClose.Text = "Chiudi"
        Me.lnkClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 57
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(-5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(358, 26)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "ATTENZIONE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(12, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(322, 45)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Sono necessari degli interventi per delle anomalie nella sezione finanziaria"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkRisolvi
        '
        Me.lnkRisolvi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkRisolvi.AutoSize = True
        Me.lnkRisolvi.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lnkRisolvi.Image = Global.Former.My.Resources.Resources._PrendiInCarico
        Me.lnkRisolvi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkRisolvi.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkRisolvi.Location = New System.Drawing.Point(12, 202)
        Me.lnkRisolvi.MinimumSize = New System.Drawing.Size(0, 28)
        Me.lnkRisolvi.Name = "lnkRisolvi"
        Me.lnkRisolvi.Padding = New System.Windows.Forms.Padding(32, 0, 0, 0)
        Me.lnkRisolvi.Size = New System.Drawing.Size(93, 28)
        Me.lnkRisolvi.TabIndex = 64
        Me.lnkRisolvi.TabStop = True
        Me.lnkRisolvi.Text = "Risolvi"
        Me.lnkRisolvi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Former.My.Resources.Resources._Errore
        Me.PictureBox3.Location = New System.Drawing.Point(15, 103)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 110
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources._Attenzione
        Me.PictureBox2.Location = New System.Drawing.Point(15, 147)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 111
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(111, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 15)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "problemi da risolvere"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(111, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 15)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "anomalie da controllare"
        '
        'lblContError
        '
        Me.lblContError.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblContError.Location = New System.Drawing.Point(49, 92)
        Me.lblContError.Name = "lblContError"
        Me.lblContError.Size = New System.Drawing.Size(60, 40)
        Me.lblContError.TabIndex = 114
        Me.lblContError.Text = "0"
        Me.lblContError.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblContWarning
        '
        Me.lblContWarning.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblContWarning.Location = New System.Drawing.Point(49, 137)
        Me.lblContWarning.Name = "lblContWarning"
        Me.lblContWarning.Size = New System.Drawing.Size(60, 40)
        Me.lblContWarning.TabIndex = 115
        Me.lblContWarning.Text = "0"
        Me.lblContWarning.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'frmReminder
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(349, 239)
        Me.Controls.Add(Me.lblContWarning)
        Me.Controls.Add(Me.lblContError)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.lnkRisolvi)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lnkClose)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmReminder"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reminder giornaliero"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkClose As System.Windows.Forms.LinkLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lnkRisolvi As LinkLabel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblContError As Label
    Friend WithEvents lblContWarning As Label
End Class
