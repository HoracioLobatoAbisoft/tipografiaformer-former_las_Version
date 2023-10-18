<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScreenShoot
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtAnomalia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnChiudi = New System.Windows.Forms.Button()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pctScreenshot = New Former.ucPictureWithZoom()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.rdoAmministrazione = New System.Windows.Forms.RadioButton()
        Me.rdoSupporto = New System.Windows.Forms.RadioButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctScreenshot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAnomalia
        '
        Me.txtAnomalia.Location = New System.Drawing.Point(12, 100)
        Me.txtAnomalia.Multiline = True
        Me.txtAnomalia.Name = "txtAnomalia"
        Me.txtAnomalia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAnomalia.Size = New System.Drawing.Size(338, 180)
        Me.txtAnomalia.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inserisci delle note se lo ritieni necessario"
        '
        'btnChiudi
        '
        Me.btnChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnChiudi.Location = New System.Drawing.Point(601, 318)
        Me.btnChiudi.Name = "btnChiudi"
        Me.btnChiudi.Size = New System.Drawing.Size(75, 23)
        Me.btnChiudi.TabIndex = 3
        Me.btnChiudi.Text = "Chiudi"
        Me.btnChiudi.UseVisualStyleBackColor = True
        '
        'btnSalva
        '
        Me.btnSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalva.Location = New System.Drawing.Point(520, 318)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(75, 23)
        Me.btnSalva.TabIndex = 2
        Me.btnSalva.Text = "Invia"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(664, 51)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "INVIO SCHERMATA CORRENTE (F12)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 292)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Destinatario"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Former.My.Resources.Resources.advance24
        Me.PictureBox1.Location = New System.Drawing.Point(12, 286)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 27)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'pctScreenshot
        '
        Me.pctScreenshot.BackColor = System.Drawing.Color.White
        Me.pctScreenshot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctScreenshot.Label = Nothing
        Me.pctScreenshot.Location = New System.Drawing.Point(356, 100)
        Me.pctScreenshot.Name = "pctScreenshot"
        Me.pctScreenshot.Size = New System.Drawing.Size(320, 180)
        Me.pctScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctScreenshot.TabIndex = 6
        Me.pctScreenshot.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources.switch_camera24
        Me.PictureBox2.Location = New System.Drawing.Point(12, 67)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 27)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'rdoAmministrazione
        '
        Me.rdoAmministrazione.AutoSize = True
        Me.rdoAmministrazione.Checked = True
        Me.rdoAmministrazione.Location = New System.Drawing.Point(147, 290)
        Me.rdoAmministrazione.Name = "rdoAmministrazione"
        Me.rdoAmministrazione.Size = New System.Drawing.Size(115, 19)
        Me.rdoAmministrazione.TabIndex = 12
        Me.rdoAmministrazione.TabStop = True
        Me.rdoAmministrazione.Text = "Amministrazione"
        Me.rdoAmministrazione.UseVisualStyleBackColor = True
        '
        'rdoSupporto
        '
        Me.rdoSupporto.AutoSize = True
        Me.rdoSupporto.Location = New System.Drawing.Point(286, 290)
        Me.rdoSupporto.Name = "rdoSupporto"
        Me.rdoSupporto.Size = New System.Drawing.Size(118, 19)
        Me.rdoSupporto.TabIndex = 13
        Me.rdoSupporto.Text = "Supporto Tecnico"
        Me.rdoSupporto.UseVisualStyleBackColor = True
        '
        'frmScreenShoot
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnChiudi
        Me.ClientSize = New System.Drawing.Size(688, 353)
        Me.Controls.Add(Me.rdoSupporto)
        Me.Controls.Add(Me.rdoAmministrazione)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pctScreenshot)
        Me.Controls.Add(Me.btnSalva)
        Me.Controls.Add(Me.btnChiudi)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAnomalia)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScreenShoot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Former - Invio Schermata Corrente"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctScreenshot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAnomalia As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnChiudi As Button
    Friend WithEvents btnSalva As Button
    Friend WithEvents pctScreenshot As ucPictureWithZoom
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents rdoAmministrazione As RadioButton
    Friend WithEvents rdoSupporto As RadioButton
End Class
