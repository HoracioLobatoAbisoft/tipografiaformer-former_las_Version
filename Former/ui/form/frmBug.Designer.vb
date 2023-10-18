<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBug
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtAnomalia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnChiudi = New System.Windows.Forms.Button()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.pctScreenshot = New Former.ucPictureWithZoom()
        Me.txtTitolo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctScreenshot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAnomalia
        '
        Me.txtAnomalia.Location = New System.Drawing.Point(12, 132)
        Me.txtAnomalia.Multiline = True
        Me.txtAnomalia.Name = "txtAnomalia"
        Me.txtAnomalia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAnomalia.Size = New System.Drawing.Size(338, 180)
        Me.txtAnomalia.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(418, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inserisci indicazioni precise sull'anomalia riscontrata o sulla modifica richiest" &
    "a:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Former.My.Resources.Resources._002_27
        Me.PictureBox2.Location = New System.Drawing.Point(12, 67)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 27)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
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
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'pctScreenshot
        '
        Me.pctScreenshot.BackColor = System.Drawing.Color.White
        Me.pctScreenshot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctScreenshot.Label = Nothing
        Me.pctScreenshot.Location = New System.Drawing.Point(356, 132)
        Me.pctScreenshot.Name = "pctScreenshot"
        Me.pctScreenshot.Size = New System.Drawing.Size(320, 180)
        Me.pctScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctScreenshot.TabIndex = 6
        Me.pctScreenshot.TabStop = False
        '
        'txtTitolo
        '
        Me.txtTitolo.Location = New System.Drawing.Point(150, 70)
        Me.txtTitolo.Name = "txtTitolo"
        Me.txtTitolo.Size = New System.Drawing.Size(526, 23)
        Me.txtTitolo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Inserisci un titolo"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(664, 51)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "SEGNALAZIONE ANOMALIA (F10)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmBug
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnChiudi
        Me.ClientSize = New System.Drawing.Size(688, 353)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTitolo)
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
        Me.Name = "frmBug"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Former - Segnalazione anomalia o richiesta modifica"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctScreenshot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAnomalia As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnChiudi As Button
    Friend WithEvents btnSalva As Button
    Friend WithEvents pctScreenshot As ucPictureWithZoom
    Friend WithEvents txtTitolo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
