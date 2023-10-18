Imports FormerDALSql
Imports FormerLib

Public Class frmForzaAzione

    Public Sub Carica()

        dtDataRif.Value = Now.Date

        ShowDialog()

    End Sub

    Private Sub btnForza_Click(sender As Object, e As EventArgs) Handles btnForza.Click

        'CHECK INTERNET; SERVER INTERNO; SERVER ESTERNO; DB ;

        If MessageBox.Show("Confermi la forzatura delle operazioni selezionate al giorno indicato?", "Forza Operazioni", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            btnForza.Enabled = False

            Cursor = Cursors.WaitCursor

            If chkReportGiornaliero.Checked Then
                lblLog.Text = "Report Giornaliero..."
                Application.DoEvents()
                FormerService.IntervalloOrario.ReportGiornaliero()
            End If


            If chkGestioneNewsletter.Checked Then
                lblLog.Text = "Gestione Newsletter..."
                Application.DoEvents()
                FormerService.IntervalloOrario.GestioneNewsletter()
            End If

            If chkPromoAutomatici.Checked Then
                lblLog.Text = "Promo Automatici..."
                Application.DoEvents()
                FormerService.IntervalloOrario.PromoAutomatici()
            End If

            If chkOrdiniAbbandonati.Checked Then
                lblLog.Text = "Gestione Ordini abbandonati..."
                Application.DoEvents()
                FormerService.IntervalloOrario.GestioneOrdiniAbbandonati(dtDataRif.Value)
            End If

            If chkBackupDB.Checked Then
                lblLog.Text = "Backup DB..."
                Application.DoEvents()
                FormerService.IntervalloOrario.BackupDB()
            End If

            If chkLogSito.Checked Then
                lblLog.Text = "Download Log Sito..."
                Application.DoEvents()
                FormerService.IntervalloOrario.DownloadLog(dtDataRif.Value)
            End If

            If chkMarketing.Checked Then
                lblLog.Text = "Marketing Bilanciato..."
                Application.DoEvents()
                FormerService.IntervalloOrario.InserimentoMarketingBilanciato(dtDataRif.Value)
            End If

            If chkIndici.Checked Then
                lblLog.Text = "Aggiorna Indici Ricerca..."
                Application.DoEvents()
                FormerService.IntervalloOrario.AggiornaIndiciRicerca()
            End If

            If chkTemp.Checked Then
                lblLog.Text = "Pulizia Cartella Temp..."
                Application.DoEvents()
                FormerService.IntervalloOrario.CleanAndMove()
            End If

            If chkConsegne.Checked Then
                lblLog.Text = "Procedura Consegne..."
                Application.DoEvents()
                FormerService.IntervalloOrario.CompletamentoConsegne(dtDataRif.Value)
            End If

            If chkInvioFatturePA.Checked Then
                lblLog.Text = "Invio Fatture FE..."
                Application.DoEvents()
                FormerService.IntervalloOrario.InvioFattureFE()
            End If

            If chkBackup.Checked Then
                lblLog.Text = "Backup File Incrementale..."
                Application.DoEvents()
                FormerService.IntervalloOrario.BackupIncrementale()
            End If

            If chkArchiviazionePreventivi.Checked Then
                lblLog.Text = "Archiviazione Preventivi..."
                Application.DoEvents()
                FormerService.IntervalloOrario.ArchiviazionePreventivi()
            End If

            If chkMonitoraggioPec.Checked Then
                lblLog.Text = "Monitoraggio Pec..."
                Application.DoEvents()
                FormerMessenger.MonitoraggioPECEx(MgrAziende.IdAziende.AziendaSnc)
                FormerMessenger.MonitoraggioPECEx(MgrAziende.IdAziende.AziendaSrl)
            End If

            If chkAgganciaCostiMovimenti.Checked Then
                lblLog.Text = "Aggancia costi a movimenti..."
                Application.DoEvents()
                FormerService.IntervalloOrario.AgganciaDocumentiFiscalieCarichi()
            End If

            Cursor = Cursors.Default

            btnForza.Enabled = True

            MessageBox.Show("Operazioni Eseguite")

            Close()

        End If

    End Sub
End Class