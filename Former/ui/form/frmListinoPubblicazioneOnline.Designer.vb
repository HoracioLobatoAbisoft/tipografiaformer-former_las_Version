<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListinoPubblicazioneOnline
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
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.tabPubbl = New System.Windows.Forms.TabControl()
        Me.tpListino = New System.Windows.Forms.TabPage()
        Me.chkNoIndici = New System.Windows.Forms.CheckBox()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.lblProdUltimaPubbl = New System.Windows.Forms.Label()
        Me.lblCollUltimaPubbl = New System.Windows.Forms.Label()
        Me.lblProdFTP = New System.Windows.Forms.Label()
        Me.lblProdSQL = New System.Windows.Forms.Label()
        Me.lblCollFTP = New System.Windows.Forms.Label()
        Me.lblCollSQL = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.rdoEsercizio = New System.Windows.Forms.RadioButton()
        Me.rdoCollaudo = New System.Windows.Forms.RadioButton()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.btnDelStop = New System.Windows.Forms.Button()
        Me.btnChiudi = New System.Windows.Forms.Button()
        Me.btnPubblica = New System.Windows.Forms.Button()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        Me.tabPubbl.SuspendLayout()
        Me.tpListino.SuspendLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.btnDelStop)
        Me.gbPulsanti.Controls.Add(Me.btnChiudi)
        Me.gbPulsanti.Controls.Add(Me.btnPubblica)
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 430)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(943, 48)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'TabMain
        '
        Me.TabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(943, 430)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.tabPubbl)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Location = New System.Drawing.Point(4, 22)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(935, 404)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Former - Gestione Tipografiaformer.it"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'tabPubbl
        '
        Me.tabPubbl.Controls.Add(Me.tpListino)
        Me.tabPubbl.Location = New System.Drawing.Point(6, 52)
        Me.tabPubbl.Name = "tabPubbl"
        Me.tabPubbl.SelectedIndex = 0
        Me.tabPubbl.Size = New System.Drawing.Size(923, 343)
        Me.tabPubbl.TabIndex = 16
        '
        'tpListino
        '
        Me.tpListino.Controls.Add(Me.chkNoIndici)
        Me.tpListino.Controls.Add(Me.lblLog)
        Me.tpListino.Controls.Add(Me.lblProdUltimaPubbl)
        Me.tpListino.Controls.Add(Me.lblCollUltimaPubbl)
        Me.tpListino.Controls.Add(Me.lblProdFTP)
        Me.tpListino.Controls.Add(Me.lblProdSQL)
        Me.tpListino.Controls.Add(Me.lblCollFTP)
        Me.tpListino.Controls.Add(Me.lblCollSQL)
        Me.tpListino.Controls.Add(Me.rdoEsercizio)
        Me.tpListino.Controls.Add(Me.rdoCollaudo)
        Me.tpListino.Location = New System.Drawing.Point(4, 22)
        Me.tpListino.Name = "tpListino"
        Me.tpListino.Padding = New System.Windows.Forms.Padding(3)
        Me.tpListino.Size = New System.Drawing.Size(915, 317)
        Me.tpListino.TabIndex = 0
        Me.tpListino.Text = "Pubblicazione Listino"
        Me.tpListino.UseVisualStyleBackColor = True
        '
        'chkNoIndici
        '
        Me.chkNoIndici.AutoSize = True
        Me.chkNoIndici.Checked = True
        Me.chkNoIndici.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoIndici.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkNoIndici.Location = New System.Drawing.Point(269, 113)
        Me.chkNoIndici.Name = "chkNoIndici"
        Me.chkNoIndici.Size = New System.Drawing.Size(207, 19)
        Me.chkNoIndici.TabIndex = 29
        Me.chkNoIndici.Text = "Non pubblicare gli indici di ricerca"
        Me.chkNoIndici.UseVisualStyleBackColor = True
        '
        'lblLog
        '
        Me.lblLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.lblLog.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblLog.ForeColor = System.Drawing.Color.Black
        Me.lblLog.Location = New System.Drawing.Point(7, 268)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(901, 46)
        Me.lblLog.TabIndex = 28
        Me.lblLog.Text = "-"
        Me.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProdUltimaPubbl
        '
        Me.lblProdUltimaPubbl.AccessibleDescription = ""
        Me.lblProdUltimaPubbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblProdUltimaPubbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblProdUltimaPubbl.Location = New System.Drawing.Point(266, 230)
        Me.lblProdUltimaPubbl.Name = "lblProdUltimaPubbl"
        Me.lblProdUltimaPubbl.Size = New System.Drawing.Size(642, 23)
        Me.lblProdUltimaPubbl.TabIndex = 27
        Me.lblProdUltimaPubbl.Text = "-"
        Me.lblProdUltimaPubbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCollUltimaPubbl
        '
        Me.lblCollUltimaPubbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCollUltimaPubbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCollUltimaPubbl.Location = New System.Drawing.Point(266, 87)
        Me.lblCollUltimaPubbl.Name = "lblCollUltimaPubbl"
        Me.lblCollUltimaPubbl.Size = New System.Drawing.Size(642, 23)
        Me.lblCollUltimaPubbl.TabIndex = 26
        Me.lblCollUltimaPubbl.Text = "-"
        Me.lblCollUltimaPubbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProdFTP
        '
        Me.lblProdFTP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblProdFTP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblProdFTP.Location = New System.Drawing.Point(266, 201)
        Me.lblProdFTP.Name = "lblProdFTP"
        Me.lblProdFTP.Size = New System.Drawing.Size(642, 23)
        Me.lblProdFTP.TabIndex = 25
        Me.lblProdFTP.Text = "-"
        Me.lblProdFTP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProdSQL
        '
        Me.lblProdSQL.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblProdSQL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.lblProdSQL.Location = New System.Drawing.Point(266, 172)
        Me.lblProdSQL.Name = "lblProdSQL"
        Me.lblProdSQL.Size = New System.Drawing.Size(642, 23)
        Me.lblProdSQL.TabIndex = 24
        Me.lblProdSQL.Text = "-"
        Me.lblProdSQL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCollFTP
        '
        Me.lblCollFTP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCollFTP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCollFTP.Location = New System.Drawing.Point(266, 58)
        Me.lblCollFTP.Name = "lblCollFTP"
        Me.lblCollFTP.Size = New System.Drawing.Size(642, 23)
        Me.lblCollFTP.TabIndex = 23
        Me.lblCollFTP.Text = "-"
        Me.lblCollFTP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCollSQL
        '
        Me.lblCollSQL.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCollSQL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCollSQL.Location = New System.Drawing.Point(266, 29)
        Me.lblCollSQL.Name = "lblCollSQL"
        Me.lblCollSQL.Size = New System.Drawing.Size(642, 23)
        Me.lblCollSQL.TabIndex = 22
        Me.lblCollSQL.Text = "-"
        Me.lblCollSQL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(52, 15)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(265, 21)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Gestione www.tipografiaformer.it"
        '
        'rdoEsercizio
        '
        Me.rdoEsercizio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rdoEsercizio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.rdoEsercizio.Image = Global.Former.My.Resources.Resources._Server48
        Me.rdoEsercizio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdoEsercizio.Location = New System.Drawing.Point(55, 172)
        Me.rdoEsercizio.Name = "rdoEsercizio"
        Me.rdoEsercizio.Size = New System.Drawing.Size(172, 81)
        Me.rdoEsercizio.TabIndex = 21
        Me.rdoEsercizio.Text = "Server di esercizio"
        Me.rdoEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoEsercizio.UseVisualStyleBackColor = True
        '
        'rdoCollaudo
        '
        Me.rdoCollaudo.Checked = True
        Me.rdoCollaudo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rdoCollaudo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdoCollaudo.Image = Global.Former.My.Resources.Resources._Server48Orange
        Me.rdoCollaudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdoCollaudo.Location = New System.Drawing.Point(55, 29)
        Me.rdoCollaudo.Name = "rdoCollaudo"
        Me.rdoCollaudo.Size = New System.Drawing.Size(172, 81)
        Me.rdoCollaudo.TabIndex = 20
        Me.rdoCollaudo.TabStop = True
        Me.rdoCollaudo.Text = "Server di collaudo"
        Me.rdoCollaudo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdoCollaudo.UseVisualStyleBackColor = True
        '
        'pctTipo
        '
        Me.pctTipo.Image = Global.Former.My.Resources.Resources._PubblicazioneWeb
        Me.pctTipo.Location = New System.Drawing.Point(6, 6)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(40, 40)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'btnDelStop
        '
        Me.btnDelStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDelStop.FlatAppearance.BorderSize = 0
        Me.btnDelStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelStop.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnDelStop.Image = Global.Former.My.Resources.Resources._stop
        Me.btnDelStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelStop.Location = New System.Drawing.Point(185, 13)
        Me.btnDelStop.Name = "btnDelStop"
        Me.btnDelStop.Size = New System.Drawing.Size(145, 30)
        Me.btnDelStop.TabIndex = 33
        Me.btnDelStop.Text = "Elimina File STOP"
        Me.btnDelStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelStop.UseVisualStyleBackColor = True
        '
        'btnChiudi
        '
        Me.btnChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChiudi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnChiudi.FlatAppearance.BorderSize = 0
        Me.btnChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChiudi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnChiudi.Image = Global.Former.My.Resources.Resources._Annulla
        Me.btnChiudi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChiudi.Location = New System.Drawing.Point(861, 13)
        Me.btnChiudi.Name = "btnChiudi"
        Me.btnChiudi.Size = New System.Drawing.Size(76, 30)
        Me.btnChiudi.TabIndex = 32
        Me.btnChiudi.Text = "Chiudi"
        Me.btnChiudi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnChiudi.UseVisualStyleBackColor = True
        '
        'btnPubblica
        '
        Me.btnPubblica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPubblica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPubblica.FlatAppearance.BorderSize = 0
        Me.btnPubblica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPubblica.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPubblica.Image = Global.Former.My.Resources.Resources._PubblicazioneWeb
        Me.btnPubblica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPubblica.Location = New System.Drawing.Point(14, 13)
        Me.btnPubblica.Name = "btnPubblica"
        Me.btnPubblica.Size = New System.Drawing.Size(133, 30)
        Me.btnPubblica.TabIndex = 31
        Me.btnPubblica.Text = "Pubblica Listino"
        Me.btnPubblica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPubblica.UseVisualStyleBackColor = True
        '
        'frmListinoPubblicazioneOnline
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(943, 478)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Name = "frmListinoPubblicazioneOnline"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Former - Pubblicazione Web"
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        Me.tabPubbl.ResumeLayout(False)
        Me.tpListino.ResumeLayout(False)
        Me.tpListino.PerformLayout()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents tabPubbl As System.Windows.Forms.TabControl
    Friend WithEvents tpListino As System.Windows.Forms.TabPage

    Friend WithEvents rdoCollaudo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoEsercizio As System.Windows.Forms.RadioButton
    Friend WithEvents lblCollFTP As System.Windows.Forms.Label
    Friend WithEvents lblCollSQL As System.Windows.Forms.Label
    Friend WithEvents lblProdFTP As System.Windows.Forms.Label
    Friend WithEvents lblProdSQL As System.Windows.Forms.Label
    Friend WithEvents lblProdUltimaPubbl As System.Windows.Forms.Label
    Friend WithEvents lblCollUltimaPubbl As System.Windows.Forms.Label
    Friend WithEvents lblLog As System.Windows.Forms.Label
    Friend WithEvents btnPubblica As Button
    Friend WithEvents btnChiudi As Button
    Friend WithEvents btnDelStop As Button
    Friend WithEvents chkNoIndici As CheckBox
End Class
