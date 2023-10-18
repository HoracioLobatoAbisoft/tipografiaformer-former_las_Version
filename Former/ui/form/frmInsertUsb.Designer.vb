<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsertUsb
    Inherits baseFormInternaFixed

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsertUsb))
        Me.pnlCollegata = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pctLoading = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.pnlCollegata.SuspendLayout()
        CType(Me.pctLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCollegata
        '
        Me.pnlCollegata.Controls.Add(Me.Label1)
        Me.pnlCollegata.Controls.Add(Me.pctLoading)
        Me.pnlCollegata.Location = New System.Drawing.Point(55, 157)
        Me.pnlCollegata.Name = "pnlCollegata"
        Me.pnlCollegata.Size = New System.Drawing.Size(302, 39)
        Me.pnlCollegata.TabIndex = 24
        Me.pnlCollegata.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(41, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(258, 19)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Chiave USB Collegata, attendere prego..."
        '
        'pctLoading
        '
        Me.pctLoading.Image = Global.Former.My.Resources.loading
        Me.pctLoading.Location = New System.Drawing.Point(3, 3)
        Me.pctLoading.Name = "pctLoading"
        Me.pctLoading.Size = New System.Drawing.Size(32, 32)
        Me.pctLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pctLoading.TabIndex = 21
        Me.pctLoading.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Formerkey
        Me.PictureBox2.Location = New System.Drawing.Point(124, 79)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(158, 62)
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(397, 52)
        Me.Panel1.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(87, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(291, 19)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Collega la FormerKey per essere autenticato..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources._Attenzione
        Me.PictureBox1.Location = New System.Drawing.Point(53, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'btnEsci
        '
        Me.btnEsci.Location = New System.Drawing.Point(373, 185)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(46, 23)
        Me.btnEsci.TabIndex = 26
        Me.btnEsci.Text = "Esci"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'frmInsertUsb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(421, 210)
        Me.Controls.Add(Me.btnEsci)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlCollegata)
        Me.Controls.Add(Me.PictureBox2)
        
        Me.KeyPreview = True
        Me.Name = "frmInsertUsb"
        Me.Text = "Former - Inserire FormerKey"
        Me.pnlCollegata.ResumeLayout(False)
        Me.pnlCollegata.PerformLayout()
        CType(Me.pctLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCollegata As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pctLoading As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnEsci As Button
End Class
