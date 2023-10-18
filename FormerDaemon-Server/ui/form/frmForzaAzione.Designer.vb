<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmForzaAzione
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
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmForzaAzione))
        Me.chkLogSito = New System.Windows.Forms.CheckBox()
        Me.chkConsegne = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkPromoAutomatici = New System.Windows.Forms.CheckBox()
        Me.chkAgganciaCostiMovimenti = New System.Windows.Forms.CheckBox()
        Me.chkMonitoraggioPec = New System.Windows.Forms.CheckBox()
        Me.chkArchiviazionePreventivi = New System.Windows.Forms.CheckBox()
        Me.chkInvioFatturePA = New System.Windows.Forms.CheckBox()
        Me.chkBackupDB = New System.Windows.Forms.CheckBox()
        Me.chkBackup = New System.Windows.Forms.CheckBox()
        Me.chkTemp = New System.Windows.Forms.CheckBox()
        Me.chkIndici = New System.Windows.Forms.CheckBox()
        Me.chkOrdiniAbbandonati = New System.Windows.Forms.CheckBox()
        Me.chkMarketing = New System.Windows.Forms.CheckBox()
        Me.chkGestioneNewsletter = New System.Windows.Forms.CheckBox()
        Me.btnForza = New System.Windows.Forms.Button()
        Me.dtDataRif = New System.Windows.Forms.DateTimePicker()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.chkReportGiornaliero = New System.Windows.Forms.CheckBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkLogSito
        '
        Me.chkLogSito.AutoSize = True
        Me.chkLogSito.Location = New System.Drawing.Point(24, 150)
        Me.chkLogSito.Name = "chkLogSito"
        Me.chkLogSito.Size = New System.Drawing.Size(164, 19)
        Me.chkLogSito.TabIndex = 0
        Me.chkLogSito.Text = "Download Log Sito (04:00)"
        Me.chkLogSito.UseVisualStyleBackColor = True
        '
        'chkConsegne
        '
        Me.chkConsegne.AutoSize = True
        Me.chkConsegne.Location = New System.Drawing.Point(24, 250)
        Me.chkConsegne.Name = "chkConsegne"
        Me.chkConsegne.Size = New System.Drawing.Size(174, 19)
        Me.chkConsegne.TabIndex = 1
        Me.chkConsegne.Text = "Procedura Consegne (21:00)"
        Me.chkConsegne.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkReportGiornaliero)
        Me.GroupBox2.Controls.Add(Me.chkPromoAutomatici)
        Me.GroupBox2.Controls.Add(Me.chkAgganciaCostiMovimenti)
        Me.GroupBox2.Controls.Add(Me.chkMonitoraggioPec)
        Me.GroupBox2.Controls.Add(Me.chkArchiviazionePreventivi)
        Me.GroupBox2.Controls.Add(Me.chkInvioFatturePA)
        Me.GroupBox2.Controls.Add(Me.chkBackupDB)
        Me.GroupBox2.Controls.Add(Me.chkBackup)
        Me.GroupBox2.Controls.Add(Me.chkTemp)
        Me.GroupBox2.Controls.Add(Me.chkConsegne)
        Me.GroupBox2.Controls.Add(Me.chkIndici)
        Me.GroupBox2.Controls.Add(Me.chkOrdiniAbbandonati)
        Me.GroupBox2.Controls.Add(Me.chkMarketing)
        Me.GroupBox2.Controls.Add(Me.chkGestioneNewsletter)
        Me.GroupBox2.Controls.Add(Me.chkLogSito)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(261, 402)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'chkPromoAutomatici
        '
        Me.chkPromoAutomatici.AutoSize = True
        Me.chkPromoAutomatici.Location = New System.Drawing.Point(24, 75)
        Me.chkPromoAutomatici.Name = "chkPromoAutomatici"
        Me.chkPromoAutomatici.Size = New System.Drawing.Size(162, 19)
        Me.chkPromoAutomatici.TabIndex = 10
        Me.chkPromoAutomatici.Text = "Promo Automatici (01:00)"
        Me.chkPromoAutomatici.UseVisualStyleBackColor = True
        '
        'chkAgganciaCostiMovimenti
        '
        Me.chkAgganciaCostiMovimenti.AutoSize = True
        Me.chkAgganciaCostiMovimenti.Location = New System.Drawing.Point(22, 375)
        Me.chkAgganciaCostiMovimenti.Name = "chkAgganciaCostiMovimenti"
        Me.chkAgganciaCostiMovimenti.Size = New System.Drawing.Size(176, 19)
        Me.chkAgganciaCostiMovimenti.TabIndex = 9
        Me.chkAgganciaCostiMovimenti.Text = "Aggancia Costi a Movimenti"
        Me.chkAgganciaCostiMovimenti.UseVisualStyleBackColor = True
        '
        'chkMonitoraggioPec
        '
        Me.chkMonitoraggioPec.AutoSize = True
        Me.chkMonitoraggioPec.Location = New System.Drawing.Point(24, 350)
        Me.chkMonitoraggioPec.Name = "chkMonitoraggioPec"
        Me.chkMonitoraggioPec.Size = New System.Drawing.Size(123, 19)
        Me.chkMonitoraggioPec.TabIndex = 8
        Me.chkMonitoraggioPec.Text = "Monitoraggio PEC"
        Me.chkMonitoraggioPec.UseVisualStyleBackColor = True
        '
        'chkArchiviazionePreventivi
        '
        Me.chkArchiviazionePreventivi.AutoSize = True
        Me.chkArchiviazionePreventivi.Location = New System.Drawing.Point(24, 325)
        Me.chkArchiviazionePreventivi.Name = "chkArchiviazionePreventivi"
        Me.chkArchiviazionePreventivi.Size = New System.Drawing.Size(190, 19)
        Me.chkArchiviazionePreventivi.TabIndex = 7
        Me.chkArchiviazionePreventivi.Text = "Archiviazione Preventivi (02:00)"
        Me.chkArchiviazionePreventivi.UseVisualStyleBackColor = True
        '
        'chkInvioFatturePA
        '
        Me.chkInvioFatturePA.AutoSize = True
        Me.chkInvioFatturePA.Location = New System.Drawing.Point(24, 275)
        Me.chkInvioFatturePA.Name = "chkInvioFatturePA"
        Me.chkInvioFatturePA.Size = New System.Drawing.Size(145, 19)
        Me.chkInvioFatturePA.TabIndex = 6
        Me.chkInvioFatturePA.Text = "Invio Fatture FE (22:00)"
        Me.chkInvioFatturePA.UseVisualStyleBackColor = True
        '
        'chkBackupDB
        '
        Me.chkBackupDB.AutoSize = True
        Me.chkBackupDB.Location = New System.Drawing.Point(24, 125)
        Me.chkBackupDB.Name = "chkBackupDB"
        Me.chkBackupDB.Size = New System.Drawing.Size(121, 19)
        Me.chkBackupDB.TabIndex = 5
        Me.chkBackupDB.Text = "Backup DB (03:00)"
        Me.chkBackupDB.UseVisualStyleBackColor = True
        '
        'chkBackup
        '
        Me.chkBackup.AutoSize = True
        Me.chkBackup.Location = New System.Drawing.Point(24, 300)
        Me.chkBackup.Name = "chkBackup"
        Me.chkBackup.Size = New System.Drawing.Size(196, 19)
        Me.chkBackup.TabIndex = 3
        Me.chkBackup.Text = "Backup Incrementale File (23:00)"
        Me.chkBackup.UseVisualStyleBackColor = True
        '
        'chkTemp
        '
        Me.chkTemp.AutoSize = True
        Me.chkTemp.Location = New System.Drawing.Point(24, 225)
        Me.chkTemp.Name = "chkTemp"
        Me.chkTemp.Size = New System.Drawing.Size(173, 19)
        Me.chkTemp.TabIndex = 4
        Me.chkTemp.Text = "Pulizia Cartella Temp (05:00)"
        Me.chkTemp.UseVisualStyleBackColor = True
        '
        'chkIndici
        '
        Me.chkIndici.AutoSize = True
        Me.chkIndici.Location = New System.Drawing.Point(24, 200)
        Me.chkIndici.Name = "chkIndici"
        Me.chkIndici.Size = New System.Drawing.Size(199, 19)
        Me.chkIndici.TabIndex = 3
        Me.chkIndici.Text = "Aggiorna Indici di Ricerca (04:00)"
        Me.chkIndici.UseVisualStyleBackColor = True
        '
        'chkOrdiniAbbandonati
        '
        Me.chkOrdiniAbbandonati.AutoSize = True
        Me.chkOrdiniAbbandonati.Location = New System.Drawing.Point(24, 100)
        Me.chkOrdiniAbbandonati.Name = "chkOrdiniAbbandonati"
        Me.chkOrdiniAbbandonati.Size = New System.Drawing.Size(218, 19)
        Me.chkOrdiniAbbandonati.TabIndex = 2
        Me.chkOrdiniAbbandonati.Text = "Gestione Ordini Abbandonati (03:00)"
        Me.chkOrdiniAbbandonati.UseVisualStyleBackColor = True
        '
        'chkMarketing
        '
        Me.chkMarketing.AutoSize = True
        Me.chkMarketing.Location = New System.Drawing.Point(24, 175)
        Me.chkMarketing.Name = "chkMarketing"
        Me.chkMarketing.Size = New System.Drawing.Size(173, 19)
        Me.chkMarketing.TabIndex = 2
        Me.chkMarketing.Text = "Marketing Bilanciato (04:00)"
        Me.chkMarketing.UseVisualStyleBackColor = True
        '
        'chkGestioneNewsletter
        '
        Me.chkGestioneNewsletter.AutoSize = True
        Me.chkGestioneNewsletter.Location = New System.Drawing.Point(24, 50)
        Me.chkGestioneNewsletter.Name = "chkGestioneNewsletter"
        Me.chkGestioneNewsletter.Size = New System.Drawing.Size(169, 19)
        Me.chkGestioneNewsletter.TabIndex = 0
        Me.chkGestioneNewsletter.Text = "Gestione Newsletter (01:00)"
        Me.chkGestioneNewsletter.UseVisualStyleBackColor = True
        '
        'btnForza
        '
        Me.btnForza.ForeColor = System.Drawing.Color.Black
        Me.btnForza.Location = New System.Drawing.Point(69, 447)
        Me.btnForza.Name = "btnForza"
        Me.btnForza.Size = New System.Drawing.Size(136, 23)
        Me.btnForza.TabIndex = 3
        Me.btnForza.Text = "Forza Operazione"
        Me.btnForza.UseVisualStyleBackColor = True
        '
        'dtDataRif
        '
        Me.dtDataRif.Location = New System.Drawing.Point(12, 12)
        Me.dtDataRif.Name = "dtDataRif"
        Me.dtDataRif.Size = New System.Drawing.Size(261, 23)
        Me.dtDataRif.TabIndex = 4
        '
        'lblLog
        '
        Me.lblLog.Location = New System.Drawing.Point(7, 477)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(263, 19)
        Me.lblLog.TabIndex = 5
        Me.lblLog.Text = "-"
        Me.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkReportGiornaliero
        '
        Me.chkReportGiornaliero.AutoSize = True
        Me.chkReportGiornaliero.Location = New System.Drawing.Point(24, 22)
        Me.chkReportGiornaliero.Name = "chkReportGiornaliero"
        Me.chkReportGiornaliero.Size = New System.Drawing.Size(160, 19)
        Me.chkReportGiornaliero.TabIndex = 11
        Me.chkReportGiornaliero.Text = "Report Giornaliero (01:00)"
        Me.chkReportGiornaliero.UseVisualStyleBackColor = True
        '
        'frmForzaAzione
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(287, 503)
        Me.Controls.Add(Me.lblLog)
        Me.Controls.Add(Me.dtDataRif)
        Me.Controls.Add(Me.btnForza)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmForzaAzione"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmForzaAzione"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkLogSito As System.Windows.Forms.CheckBox
    Friend WithEvents chkConsegne As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkGestioneNewsletter As System.Windows.Forms.CheckBox
    Friend WithEvents chkIndici As System.Windows.Forms.CheckBox
    Friend WithEvents chkOrdiniAbbandonati As System.Windows.Forms.CheckBox
    Friend WithEvents chkMarketing As System.Windows.Forms.CheckBox
    Friend WithEvents chkBackup As System.Windows.Forms.CheckBox
    Friend WithEvents chkTemp As System.Windows.Forms.CheckBox
    Friend WithEvents btnForza As System.Windows.Forms.Button
    Friend WithEvents dtDataRif As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLog As System.Windows.Forms.Label
    Friend WithEvents chkBackupDB As CheckBox
    Friend WithEvents chkInvioFatturePA As CheckBox
    Friend WithEvents chkArchiviazionePreventivi As CheckBox
    Friend WithEvents chkMonitoraggioPec As CheckBox
    Friend WithEvents chkAgganciaCostiMovimenti As CheckBox
    Friend WithEvents chkPromoAutomatici As CheckBox
    Friend WithEvents chkReportGiornaliero As CheckBox
End Class
