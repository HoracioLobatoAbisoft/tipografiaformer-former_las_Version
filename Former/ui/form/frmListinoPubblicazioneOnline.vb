Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerConfig
Imports FormerBusinessLogic
Imports FormerDALSql

Friend Class frmListinoPubblicazioneOnline
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Private ServerInUso As ServerSito

    Private MailFacebook As String = "amp169nth@m.facebook.com"

    Friend Function Carica() As Integer

        ServerInUso = ServerCollaudo

        lblCollSQL.Text = ServerCollaudo.SQLConnectionString
        lblProdSQL.Text = ServerProduzione.SQLConnectionString
        lblCollUltimaPubbl.Text = "Ultima pubblicazione: " & ServerCollaudo.DataUltimaPubbl.ToString("dddd dd MMMM HH:mm")
        lblProdUltimaPubbl.Text = "Ultima pubblicazione: " & ServerProduzione.DataUltimaPubbl.ToString("dddd dd MMMM HH:mm")
        lblCollFTP.Text = "Host: " & ServerCollaudo.FTPHost & ", Uid: " & ServerCollaudo.FTPLogin & " Pwd: " & ServerCollaudo.FTPPwd
        lblProdFTP.Text = "Host: " & ServerProduzione.FTPHost & ", Uid: " & ServerProduzione.FTPLogin & " Pwd: " & ServerProduzione.FTPPwd

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Function CheckCongruenzaFormati() As String
        Dim buffer As String = String.Empty
        Using mgr As New ListinoBaseDAO
            Dim soloSource As New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBaseSource, 0)
            Dim soloAtt As New LUNA.LunaSearchParameter(LFM.ListinoBase.Disattivo, enSiNo.No)
            Dim pNascondi As New LUNA.LunaSearchParameter(LFM.ListinoBase.NascondiOnline, enSiNo.No)

            Dim l As List(Of ListinoBase) = mgr.FindAll(soloSource,
                                                        soloAtt,
                                                        pNascondi) 'FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.VMotoreCalcolo, MgrPreventivazioneB.VMotoreCalcolo, "<>"),            p)

            'qui ho tutti i listinibase non compatibili
            For Each lb As ListinoBase In l

                If (lb.Formato.LarghezzaMM < lb.FormatoProdotto.FormatoCarta.LarghezzaMM OrElse
                    lb.Formato.AltezzaMM < lb.FormatoProdotto.FormatoCarta.AltezzaMM) And
                    (lb.Formato.AltezzaMM < lb.FormatoProdotto.FormatoCarta.LarghezzaMM OrElse
                    lb.Formato.LarghezzaMM < lb.FormatoProdotto.FormatoCarta.AltezzaMM) Then
                    'errore di incongruenza
                    buffer &= lb.IdListinoBase & " - " & lb.Nome & " (FM " & lb.Formato.LarghezzaMM & "x" & lb.Formato.AltezzaMM & ") (FP " & lb.FormatoProdotto.Larghezza & "x" & lb.FormatoProdotto.Lunghezza & ");" & ControlChars.NewLine
                End If

            Next

        End Using

        Return buffer

    End Function

    Private Sub PubblicaListino()

        'qui se si pubblica sul server di produzione devo controllare che non ci siano file temporanei 
        Dim CountFileImgTemporaneiInUso As Integer = 0

        If ServerInUso.IsProduzione Then
            CountFileImgTemporaneiInUso = MgrPubblicazioneWeb.ListaImgTemporaneeInUso.Count
        End If

        Dim FormatiOk As String = String.Empty

        FormatiOk = CheckCongruenzaFormati()

        If FormatiOk.Length Then
            MessageBox.Show("Il listino non può essere pubblicato. Incongruenza FormatoProdotto-FormatoMacchina:" & ControlChars.NewLine & FormatiOk)
        Else
            If CountFileImgTemporaneiInUso = 0 Then
                If MessageBox.Show("Confermi la pubblicazione su Web?", "Pubblicazione Web", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim Ok As Boolean = False
                    If ServerInUso.IsProduzione Then
                        If MessageBox.Show("ATTENZIONE Stai pubblicando sul server di produzione Confermi?", "Pubblicazione WEB", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Ok = True
                        End If
                    Else
                        Ok = True
                    End If

                    Dim ris As Integer = 0

                    If Ok Then

                        Cursor = Cursors.WaitCursor
                        btnPubblica.Enabled = False

                        'qui creo il file di blocco
                        If CreaFileDiBlocco() = 0 Then

                            Try
                                lblLog.Text = "Apertura connessione remota"
                                Application.DoEvents()
                                MgrPubblicazioneWeb.ApriConnessioneRemota(ServerInUso)

                                lblLog.Text = "Check Motore Calcolo Prezzi"
                                Application.DoEvents()
                                ris = MgrPubblicazioneWeb.RiControllaListiniBase

                                If ris Then
                                    lblLog.Text = "Ricalcolati " & ris & " listini base"
                                    Application.DoEvents()
                                    ris = 0
                                End If

                                lblLog.Text = "Pubblicazione Listino e tabelle correlate"
                                Application.DoEvents()
                                ris = MgrPubblicazioneWeb.Pubblica(ServerInUso.IsProduzione, True)

                                If ServerInUso.NomeServer <> "Collaudo" Then MgrPubblicazioneWeb.ResettaLastUpdate()

                                'qui devo pubblicare gli indici di ricerca 
                                If ris = 0 Then
                                    Dim PubblicaIndici As Boolean = True
                                    If ServerInUso.NomeServer = "Collaudo" Then
                                        If chkNoIndici.Checked Then PubblicaIndici = False
                                    End If

                                    If PubblicaIndici Then
                                        lblLog.Text = "Pubblicazione Indici di Ricerca"
                                        Application.DoEvents()
                                        ris = MgrPubblicazioneWeb.PubblicaIndiciRicerca()
                                    End If

                                End If

                                If ris = 0 Then
                                    lblLog.Text = "Pubblicazione Parametri Listino"
                                    Application.DoEvents()
                                    ris = MgrPubblicazioneWeb.AggiornaParametriListinoPDF()
                                End If

                                'controllare se diverso da 0 vuoldire errore 
                                lblLog.Text = "Chiusura connessione remota"
                                Application.DoEvents()
                                MgrPubblicazioneWeb.ChiudiConnessioneRemota()

                                If ServerInUso.IsProduzione Then
                                    'qui pubblico sul server gemello interno
                                    lblLog.Text = "Apertura connessione remota"
                                    Application.DoEvents()
                                    MgrPubblicazioneWeb.ApriConnessioneRemota(ServerTwin)

                                    'lblLog.Text = "Check Motore Calcolo Prezzi"
                                    'Application.DoEvents()
                                    'ris = MgrPubblicazioneWeb.RiControllaListiniBase

                                    'If ris Then
                                    'lblLog.Text = "Ricalcolati " & ris & " listini base"
                                    'Application.DoEvents()
                                    'ris = 0
                                    'End If

                                    lblLog.Text = "Pubblicazione Listino e tabelle correlate"
                                    Application.DoEvents()
                                    ris = MgrPubblicazioneWeb.Pubblica(ServerInUso.IsProduzione, False)

                                    lblLog.Text = "Chiusura connessione remota"
                                    Application.DoEvents()
                                    MgrPubblicazioneWeb.ChiudiConnessioneRemota()
                                End If

                                lblLog.Text = "Pubblicazione Listino terminata"
                                Application.DoEvents()
                                If ris = 0 Then

                                    lblLog.Text = "Pubblicazione File"
                                    Application.DoEvents()
                                    ris = MgrPubblicazioneWeb.PubblicaFile(Me, ServerInUso)

                                    If ris = 0 Then
                                        ServerInUso.SetUltimaPubblicazione()
                                        lblCollUltimaPubbl.Text = "Ultima pubblicazione: " & ServerCollaudo.DataUltimaPubbl.ToString("dddd MMMM HH:mm")
                                        lblProdUltimaPubbl.Text = "Ultima pubblicazione: " & ServerProduzione.DataUltimaPubbl.ToString("dddd MMMM HH:mm")
                                    Else
                                        MessageBox.Show("ATTENZIONE! Il listino è stato aggiornato ma non è riuscita la pubblicazione delle immagini")
                                    End If
                                    If ServerInUso.NomeServer = "Collaudo" Then
                                        FormerHelper.File.ShellExtended("http://former-server")
                                    Else

                                        'qui pubblico su Facebook che c'è stato un aggiornamento del listino
                                        'amp169nth@m.facebook.com
                                        FormerHelper.Mail.InviaMail("Il nostro listino è stato arricchito di nuovi prodotti! Visita il nostro sito https://www.tipografiaformer.it", "", MailFacebook)
                                        FormerHelper.File.ShellExtended("https://www.tipografiaformer.it")
                                    End If
                                Else
                                    MessageBox.Show("ATTENZIONE! Si è verificato un errore nella pubblicazione del listino, codice: " & ris)
                                End If


                            Catch ex As Exception
                                ManageError(ex)
                            End Try

                            btnPubblica.Enabled = True
                            Cursor = Cursors.Default

                            EliminaFileDiBlocco()

                            If ris = 0 Then

                                CreaTimeStampPubblicazioneListino()

                                MessageBox.Show("Pubblicazione listino terminata correttamente")
                            End If

                        Else
                            MessageBox.Show("ATTENZIONE! Si è verificato un errore nella creazione del file di blocco! Riprovare")
                        End If

                        'elimino il file di blocco


                        'qui chiedo se rieliminare il file di blocco 

                    End If

                End If
            Else
                MessageBox.Show("Ci sono " & CountFileImgTemporaneiInUso & " oggetti del listino che utilizzano immagini temporanee. Il listino non può essere pubblicato in produzione")
                Sottofondo()
                Using f As New frmListinoListaImgTemporanee
                    f.Carica()
                End Using
                Sottofondo()
            End If
        End If



    End Sub

    Private NomeFileSblocco As String = "stop.listino"
    Private Function CreaFileDiBlocco() As Integer
        Dim Ris As Integer = 0
        Try
            Dim PathLocale As String = FormerPath.PathTempLocale & NomeFileSblocco
            Using W As New StreamWriter(PathLocale, False)
                W.Write("STOP")
            End Using

            Dim Ftp As New FTPclient(ServerInUso.FTPHost, ServerInUso.FTPLogin, ServerInUso.FTPPwd)
            Dim PathRemotoFile As String = "tipografiaformer.it/" & NomeFileSblocco
            MgrIO.FtpTransfer(Me, Ftp, PathLocale, PathRemotoFile, enTipoOpFTP.Upload)
            Ftp = Nothing
        Catch ex As Exception
            Ris = 1
        End Try

        Return Ris
    End Function

    Private Function CreaTimeStampPubblicazioneListino() As Integer
        Dim Ris As Integer = 0
        Try
            Dim PathLocale As String = FormerPath.PathTempLocale & "lastpublish.txt"
            Using W As New StreamWriter(PathLocale, False)
                W.Write(Now.ToString)
            End Using

            Dim Ftp As New FTPclient(ServerInUso.FTPHost, ServerInUso.FTPLogin, ServerInUso.FTPPwd)
            Dim PathRemotoFile As String = "tipografiaformer.it/lastpublish.txt"
            MgrIO.FtpTransfer(Me, Ftp, PathLocale, PathRemotoFile, enTipoOpFTP.Upload)
            Ftp = Nothing
        Catch ex As Exception
            Ris = 1
        End Try

        Return Ris
    End Function


    Private Function EliminaFileDiBlocco() As Integer
        Dim Ris As Integer = 0
        Try
            Dim PathRemotoFile As String = "/tipografiaformer.it/" & NomeFileSblocco
            Dim Ftp As New FTPclient(ServerInUso.FTPHost, ServerInUso.FTPLogin, ServerInUso.FTPPwd)
            Ftp.FtpDelete(PathRemotoFile)
            Ftp = Nothing
        Catch ex As Exception
            Ris = 1
        End Try
        Return Ris
    End Function

    Private Sub rdoCollaudo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCollaudo.CheckedChanged,
        rdoEsercizio.CheckedChanged
        If rdoCollaudo.Checked Then
            ServerInUso = ServerCollaudo
        Else
            ServerInUso = ServerProduzione
        End If

    End Sub

    Private Sub btnPubblicaStanotte_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pctTipo_Click(sender As Object, e As EventArgs) Handles pctTipo.Click
    End Sub

    Private Sub btnChiudi_Click(sender As Object, e As EventArgs) Handles btnChiudi.Click
        MgrPubblicazioneWeb.ChiudiConnessioneRemota()
        Close()
    End Sub

    Private Sub btnPubblica_Click(sender As Object, e As EventArgs) Handles btnPubblica.Click
        PubblicaListino()
    End Sub

    Private Sub btnDelStop_Click(sender As Object, e As EventArgs) Handles btnDelStop.Click
        If MessageBox.Show("Confermi l'eliminazione del file di STOP?", "Pubblicazione Web", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If EliminaFileDiBlocco() = 0 Then
                MessageBox.Show("Operazione completata")
            Else
                MessageBox.Show("Si è verificato un errore nell'eliminazione del file di blocco")
            End If

        End If
    End Sub
End Class