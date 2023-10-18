<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPostit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPostit))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoAutomatico = New System.Windows.Forms.RadioButton()
        Me.rdoMessaggio = New System.Windows.Forms.RadioButton()
        Me.rdoChiamataPersa = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblNumeroTel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblVoceRub = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lnkSalva = New System.Windows.Forms.LinkLabel()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.lblData = New System.Windows.Forms.Label()
        Me.txtTitolo = New System.Windows.Forms.TextBox()
        Me.cmbDest = New System.Windows.Forms.ComboBox()
        Me.cmbMitt = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContenuto = New System.Windows.Forms.TextBox()
        Me.pctAnteprima = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pctAnteprima, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.rdoAutomatico)
        Me.GroupBox1.Controls.Add(Me.rdoMessaggio)
        Me.GroupBox1.Controls.Add(Me.rdoChiamataPersa)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lnkSalva)
        Me.GroupBox1.Controls.Add(Me.lnkAggiorna)
        Me.GroupBox1.Controls.Add(Me.lblData)
        Me.GroupBox1.Controls.Add(Me.txtTitolo)
        Me.GroupBox1.Controls.Add(Me.cmbDest)
        Me.GroupBox1.Controls.Add(Me.cmbMitt)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtContenuto)
        Me.GroupBox1.Controls.Add(Me.pctAnteprima)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(773, 473)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Messaggio"
        '
        'rdoAutomatico
        '
        Me.rdoAutomatico.Enabled = False
        Me.rdoAutomatico.Image = Global.FormerDaemon_Server.My.Resources.Resources._Attenzione
        Me.rdoAutomatico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdoAutomatico.Location = New System.Drawing.Point(363, 43)
        Me.rdoAutomatico.Name = "rdoAutomatico"
        Me.rdoAutomatico.Size = New System.Drawing.Size(145, 31)
        Me.rdoAutomatico.TabIndex = 36
        Me.rdoAutomatico.Text = "Alert Automatico"
        Me.rdoAutomatico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoAutomatico.UseVisualStyleBackColor = True
        '
        'rdoMessaggio
        '
        Me.rdoMessaggio.Enabled = False
        Me.rdoMessaggio.Image = Global.FormerDaemon_Server.My.Resources.Resources._Messaggio
        Me.rdoMessaggio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdoMessaggio.Location = New System.Drawing.Point(91, 43)
        Me.rdoMessaggio.Name = "rdoMessaggio"
        Me.rdoMessaggio.Size = New System.Drawing.Size(117, 31)
        Me.rdoMessaggio.TabIndex = 35
        Me.rdoMessaggio.Text = "Messaggio"
        Me.rdoMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoMessaggio.UseVisualStyleBackColor = True
        '
        'rdoChiamataPersa
        '
        Me.rdoChiamataPersa.Checked = True
        Me.rdoChiamataPersa.Image = Global.FormerDaemon_Server.My.Resources.Resources._ChiamataPersa
        Me.rdoChiamataPersa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdoChiamataPersa.Location = New System.Drawing.Point(214, 43)
        Me.rdoChiamataPersa.Name = "rdoChiamataPersa"
        Me.rdoChiamataPersa.Size = New System.Drawing.Size(143, 31)
        Me.rdoChiamataPersa.TabIndex = 34
        Me.rdoChiamataPersa.TabStop = True
        Me.rdoChiamataPersa.Text = "Chiamata Persa"
        Me.rdoChiamataPersa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoChiamataPersa.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(13, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 15)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Quando"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(13, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Tipologia"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblNumeroTel)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblVoceRub)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(732, 50)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Riferito a"
        '
        'lblNumeroTel
        '
        Me.lblNumeroTel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroTel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNumeroTel.Location = New System.Drawing.Point(631, 18)
        Me.lblNumeroTel.Name = "lblNumeroTel"
        Me.lblNumeroTel.Size = New System.Drawing.Size(96, 21)
        Me.lblNumeroTel.TabIndex = 32
        Me.lblNumeroTel.Text = "-"
        Me.lblNumeroTel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(554, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 15)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Numero Tel"
        '
        'lblVoceRub
        '
        Me.lblVoceRub.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVoceRub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblVoceRub.Location = New System.Drawing.Point(91, 18)
        Me.lblVoceRub.Name = "lblVoceRub"
        Me.lblVoceRub.Size = New System.Drawing.Size(457, 21)
        Me.lblVoceRub.TabIndex = 30
        Me.lblVoceRub.Text = "-"
        Me.lblVoceRub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(6, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 15)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Voce Rubrica"
        '
        'lnkSalva
        '
        Me.lnkSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkSalva.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkSalva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkSalva.Image = Global.FormerDaemon_Server.My.Resources.Resources.checkmark
        Me.lnkSalva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkSalva.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkSalva.Location = New System.Drawing.Point(622, 438)
        Me.lnkSalva.Name = "lnkSalva"
        Me.lnkSalva.Size = New System.Drawing.Size(60, 28)
        Me.lnkSalva.TabIndex = 4
        Me.lnkSalva.TabStop = True
        Me.lnkSalva.Text = "Salva"
        Me.lnkSalva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkSalva.Visible = False
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAggiorna.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkAggiorna.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkAggiorna.Image = Global.FormerDaemon_Server.My.Resources.Resources._Annulla
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(696, 438)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(68, 28)
        Me.lnkAggiorna.TabIndex = 5
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Chiudi"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblData
        '
        Me.lblData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblData.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblData.Location = New System.Drawing.Point(106, 17)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(173, 20)
        Me.lblData.TabIndex = 26
        Me.lblData.Text = "-"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTitolo
        '
        Me.txtTitolo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitolo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTitolo.Location = New System.Drawing.Point(91, 189)
        Me.txtTitolo.Name = "txtTitolo"
        Me.txtTitolo.Size = New System.Drawing.Size(670, 23)
        Me.txtTitolo.TabIndex = 2
        '
        'cmbDest
        '
        Me.cmbDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDest.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbDest.FormattingEnabled = True
        Me.cmbDest.Location = New System.Drawing.Point(91, 105)
        Me.cmbDest.Name = "cmbDest"
        Me.cmbDest.Size = New System.Drawing.Size(170, 23)
        Me.cmbDest.TabIndex = 1
        '
        'cmbMitt
        '
        Me.cmbMitt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMitt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbMitt.FormattingEnabled = True
        Me.cmbMitt.Location = New System.Drawing.Point(91, 80)
        Me.cmbMitt.Name = "cmbMitt"
        Me.cmbMitt.Size = New System.Drawing.Size(170, 23)
        Me.cmbMitt.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(10, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Destinatario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(10, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Mittente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(13, 215)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 15)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Testo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(10, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Titolo"
        '
        'txtContenuto
        '
        Me.txtContenuto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContenuto.BackColor = System.Drawing.Color.White
        Me.txtContenuto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtContenuto.Location = New System.Drawing.Point(91, 212)
        Me.txtContenuto.MaxLength = 255
        Me.txtContenuto.Multiline = True
        Me.txtContenuto.Name = "txtContenuto"
        Me.txtContenuto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtContenuto.Size = New System.Drawing.Size(670, 217)
        Me.txtContenuto.TabIndex = 3
        '
        'pctAnteprima
        '
        Me.pctAnteprima.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctAnteprima.Location = New System.Drawing.Point(603, 17)
        Me.pctAnteprima.Name = "pctAnteprima"
        Me.pctAnteprima.Size = New System.Drawing.Size(157, 111)
        Me.pctAnteprima.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctAnteprima.TabIndex = 30
        Me.pctAnteprima.TabStop = False
        '
        'frmPostit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.lnkAggiorna
        Me.ClientSize = New System.Drawing.Size(797, 496)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPostit"
        Me.Text = "Former - Post-it"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pctAnteprima, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtContenuto As System.Windows.Forms.TextBox
    Friend WithEvents txtTitolo As System.Windows.Forms.TextBox
    Friend WithEvents cmbDest As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMitt As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents lnkAggiorna As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSalva As System.Windows.Forms.LinkLabel
    Friend WithEvents pctAnteprima As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rdoChiamataPersa As RadioButton
    Friend WithEvents rdoAutomatico As RadioButton
    Friend WithEvents rdoMessaggio As RadioButton
    Friend WithEvents lblNumeroTel As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblVoceRub As Label
    Friend WithEvents Label9 As Label
End Class
