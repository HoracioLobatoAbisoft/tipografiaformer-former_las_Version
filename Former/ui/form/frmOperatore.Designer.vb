<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperatore
    Inherits frmBaseForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperatore))
        Me.gbPulsanti = New System.Windows.Forms.GroupBox()
        Me.lblStatoLavorazione = New System.Windows.Forms.Label()
        Me.lnkChiudi = New System.Windows.Forms.LinkLabel()
        Me.lnkFinished = New System.Windows.Forms.LinkLabel()
        Me.lnkIniziaLav = New System.Windows.Forms.LinkLabel()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.tbProd = New System.Windows.Forms.TabPage()
        Me.pctMessaggi = New System.Windows.Forms.PictureBox()
        Me.lblMessaggi = New System.Windows.Forms.Label()
        Me.lblLavoraz = New System.Windows.Forms.Label()
        Me.pctTipo = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.WebPreview = New System.Windows.Forms.WebBrowser()
        Me.tpMessaggi = New System.Windows.Forms.TabPage()
        Me.lnkAggiorna = New System.Windows.Forms.LinkLabel()
        Me.lnkNew = New System.Windows.Forms.LinkLabel()
        Me.UcAllegati = New Former.ucAllegati()
        Me.gbPulsanti.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.tbProd.SuspendLayout()
        CType(Me.pctMessaggi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMessaggi.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPulsanti
        '
        Me.gbPulsanti.BackColor = System.Drawing.Color.White
        Me.gbPulsanti.Controls.Add(Me.lblStatoLavorazione)
        Me.gbPulsanti.Controls.Add(Me.lnkChiudi)
        Me.gbPulsanti.Controls.Add(Me.lnkFinished)
        Me.gbPulsanti.Controls.Add(Me.lnkIniziaLav)
        Me.gbPulsanti.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbPulsanti.Location = New System.Drawing.Point(0, 666)
        Me.gbPulsanti.Name = "gbPulsanti"
        Me.gbPulsanti.Size = New System.Drawing.Size(1024, 83)
        Me.gbPulsanti.TabIndex = 5
        Me.gbPulsanti.TabStop = False
        '
        'lblStatoLavorazione
        '
        Me.lblStatoLavorazione.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatoLavorazione.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatoLavorazione.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatoLavorazione.Location = New System.Drawing.Point(4, 46)
        Me.lblStatoLavorazione.Name = "lblStatoLavorazione"
        Me.lblStatoLavorazione.Size = New System.Drawing.Size(1016, 31)
        Me.lblStatoLavorazione.TabIndex = 85
        Me.lblStatoLavorazione.Text = "-"
        Me.lblStatoLavorazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkChiudi
        '
        Me.lnkChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkChiudi.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkChiudi.Image = Global.Former.My.Resources.Resources.cancel
        Me.lnkChiudi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkChiudi.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChiudi.Location = New System.Drawing.Point(936, 17)
        Me.lnkChiudi.Name = "lnkChiudi"
        Me.lnkChiudi.Size = New System.Drawing.Size(81, 24)
        Me.lnkChiudi.TabIndex = 84
        Me.lnkChiudi.TabStop = True
        Me.lnkChiudi.Text = "Chiudi"
        Me.lnkChiudi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkFinished
        '
        Me.lnkFinished.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lnkFinished.Enabled = False
        Me.lnkFinished.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkFinished.Image = Global.Former.My.Resources.Resources.checkmark2
        Me.lnkFinished.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkFinished.LinkColor = System.Drawing.Color.Green
        Me.lnkFinished.Location = New System.Drawing.Point(180, 17)
        Me.lnkFinished.Name = "lnkFinished"
        Me.lnkFinished.Size = New System.Drawing.Size(258, 24)
        Me.lnkFinished.TabIndex = 83
        Me.lnkFinished.TabStop = True
        Me.lnkFinished.Text = "Registra lavorazione Terminata"
        Me.lnkFinished.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkIniziaLav
        '
        Me.lnkIniziaLav.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lnkIniziaLav.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lnkIniziaLav.Image = Global.Former.My.Resources.Resources.pencil
        Me.lnkIniziaLav.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkIniziaLav.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkIniziaLav.Location = New System.Drawing.Point(12, 17)
        Me.lnkIniziaLav.Name = "lnkIniziaLav"
        Me.lnkIniziaLav.Size = New System.Drawing.Size(162, 24)
        Me.lnkIniziaLav.TabIndex = 82
        Me.lnkIniziaLav.TabStop = True
        Me.lnkIniziaLav.Text = "Inizia lavorazione"
        Me.lnkIniziaLav.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.tbProd)
        Me.TabMain.Controls.Add(Me.tpMessaggi)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TabMain.ItemSize = New System.Drawing.Size(125, 40)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(1024, 666)
        Me.TabMain.TabIndex = 6
        '
        'tbProd
        '
        Me.tbProd.Controls.Add(Me.pctMessaggi)
        Me.tbProd.Controls.Add(Me.lblMessaggi)
        Me.tbProd.Controls.Add(Me.lblLavoraz)
        Me.tbProd.Controls.Add(Me.pctTipo)
        Me.tbProd.Controls.Add(Me.lblTipo)
        Me.tbProd.Controls.Add(Me.WebPreview)
        Me.tbProd.Location = New System.Drawing.Point(4, 44)
        Me.tbProd.Name = "tbProd"
        Me.tbProd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProd.Size = New System.Drawing.Size(1016, 618)
        Me.tbProd.TabIndex = 0
        Me.tbProd.Text = "Lavorazione in corso"
        Me.tbProd.UseVisualStyleBackColor = True
        '
        'pctMessaggi
        '
        Me.pctMessaggi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pctMessaggi.Image = Global.Former.My.Resources.Resources.message
        Me.pctMessaggi.Location = New System.Drawing.Point(14, 589)
        Me.pctMessaggi.Name = "pctMessaggi"
        Me.pctMessaggi.Size = New System.Drawing.Size(26, 26)
        Me.pctMessaggi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctMessaggi.TabIndex = 87
        Me.pctMessaggi.TabStop = False
        '
        'lblMessaggi
        '
        Me.lblMessaggi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMessaggi.AutoSize = True
        Me.lblMessaggi.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblMessaggi.Location = New System.Drawing.Point(46, 590)
        Me.lblMessaggi.Name = "lblMessaggi"
        Me.lblMessaggi.Size = New System.Drawing.Size(172, 22)
        Me.lblMessaggi.TabIndex = 86
        Me.lblMessaggi.Text = "0 Messaggi allegati"
        '
        'lblLavoraz
        '
        Me.lblLavoraz.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLavoraz.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLavoraz.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblLavoraz.Location = New System.Drawing.Point(241, 557)
        Me.lblLavoraz.Name = "lblLavoraz"
        Me.lblLavoraz.Size = New System.Drawing.Size(769, 55)
        Me.lblLavoraz.TabIndex = 85
        Me.lblLavoraz.Text = "TEST"
        Me.lblLavoraz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctTipo
        '
        Me.pctTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pctTipo.Image = Global.Former.My.Resources.Resources.pencil
        Me.pctTipo.Location = New System.Drawing.Point(14, 553)
        Me.pctTipo.Name = "pctTipo"
        Me.pctTipo.Size = New System.Drawing.Size(26, 26)
        Me.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pctTipo.TabIndex = 14
        Me.pctTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblTipo.Location = New System.Drawing.Point(46, 557)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(189, 22)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Lavorazione in corso:"
        '
        'WebPreview
        '
        Me.WebPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebPreview.Location = New System.Drawing.Point(3, 2)
        Me.WebPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebPreview.Name = "WebPreview"
        Me.WebPreview.Size = New System.Drawing.Size(1010, 545)
        Me.WebPreview.TabIndex = 84
        '
        'tpMessaggi
        '
        Me.tpMessaggi.Controls.Add(Me.lnkAggiorna)
        Me.tpMessaggi.Controls.Add(Me.lnkNew)
        Me.tpMessaggi.Controls.Add(Me.UcAllegati)
        Me.tpMessaggi.Location = New System.Drawing.Point(4, 44)
        Me.tpMessaggi.Name = "tpMessaggi"
        Me.tpMessaggi.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMessaggi.Size = New System.Drawing.Size(1016, 618)
        Me.tpMessaggi.TabIndex = 1
        Me.tpMessaggi.Text = "Messaggi"
        Me.tpMessaggi.UseVisualStyleBackColor = True
        '
        'lnkAggiorna
        '
        Me.lnkAggiorna.Cursor = System.Windows.Forms.Cursors.Default
        Me.lnkAggiorna.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lnkAggiorna.Image = Global.Former.My.Resources.Resources.sinchronize2
        Me.lnkAggiorna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkAggiorna.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkAggiorna.Location = New System.Drawing.Point(8, 3)
        Me.lnkAggiorna.Name = "lnkAggiorna"
        Me.lnkAggiorna.Size = New System.Drawing.Size(83, 32)
        Me.lnkAggiorna.TabIndex = 51
        Me.lnkAggiorna.TabStop = True
        Me.lnkAggiorna.Text = "Aggiorna"
        Me.lnkAggiorna.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNew
        '
        Me.lnkNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkNew.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lnkNew.Image = Global.Former.My.Resources.Resources._Messaggio
        Me.lnkNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lnkNew.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkNew.Location = New System.Drawing.Point(939, 3)
        Me.lnkNew.Name = "lnkNew"
        Me.lnkNew.Size = New System.Drawing.Size(71, 32)
        Me.lnkNew.TabIndex = 50
        Me.lnkNew.TabStop = True
        Me.lnkNew.Text = "Nuovo"
        Me.lnkNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UcAllegati
        '
        Me.UcAllegati.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcAllegati.BackColor = System.Drawing.Color.White
        Me.UcAllegati.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.UcAllegati.FromOperatore = True
        Me.UcAllegati.Location = New System.Drawing.Point(3, 38)
        Me.UcAllegati.Name = "UcAllegati"
        Me.UcAllegati.Size = New System.Drawing.Size(1010, 577)
        Me.UcAllegati.TabIndex = 0
        '
        'frmOperatore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.CancelButton = Me.lnkChiudi
        Me.ClientSize = New System.Drawing.Size(1024, 749)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.gbPulsanti)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmOperatore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Former - Operatore"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbPulsanti.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.tbProd.ResumeLayout(False)
        Me.tbProd.PerformLayout()
        CType(Me.pctMessaggi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMessaggi.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPulsanti As System.Windows.Forms.GroupBox
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbProd As System.Windows.Forms.TabPage
    Friend WithEvents pctTipo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents WebPreview As System.Windows.Forms.WebBrowser
    Friend WithEvents lnkFinished As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkIniziaLav As System.Windows.Forms.LinkLabel
    Friend WithEvents lblLavoraz As System.Windows.Forms.Label
    Friend WithEvents lnkChiudi As System.Windows.Forms.LinkLabel
    Friend WithEvents lblStatoLavorazione As System.Windows.Forms.Label
    Friend WithEvents tpMessaggi As System.Windows.Forms.TabPage
    Friend WithEvents pctMessaggi As System.Windows.Forms.PictureBox
    Friend WithEvents lblMessaggi As System.Windows.Forms.Label
    Friend WithEvents UcAllegati As Former.ucAllegati
    Friend WithEvents lnkAggiorna As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNew As System.Windows.Forms.LinkLabel
End Class
