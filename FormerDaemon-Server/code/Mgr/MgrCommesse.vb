Imports System.ComponentModel
Imports System.IO
Imports FormerConfig
Imports FormerDALSql
Imports FormerIO
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrCommesse

    Public Shared Sub CreaAnteprima(IdCom As Integer,
                                    Mittente As String,
                                    ForzaMandaAlFlusso As Boolean)

        Using c As New Commessa
            c.Read(IdCom)

            Dim Path As String = FormerPath.PathCommesse & c.IdCom & "\" & c.IdCom & ".jdf" '(c.ModelloCommessa.Job)

            Dim risPath As String = FormerPath.HotFolder.CreazioneAnteprimaPDFfromJOB & c.IdCom & ".jdf"
            MgrFormerIO.FileCopy(Path, risPath)
            'FileCopia(FormRif, Path, risPath)

            'qui devo lanciare il background-worker
            'che monitora la creazione del pdf in alta risoluzione della commessa
            Dim L As New List(Of String)
            Dim FileToCopy As String = FormerPath.HotFolder.CreazioneAnteprimaPDFfromJOB & "Output\"

            For I As Integer = 1 To c.Segnature
                L.Add(FileToCopy & c.IdCom & "." & I & "A.pdf")
                'se c'e' la cancello
                Dim PathEsistente As String = FormerPath.PathCommesse & c.IdCom & "\" & c.IdCom & "." & I & "A.pdf"
                Try
                    If File.Exists(PathEsistente) Then MgrFormerIO.FileDelete(PathEsistente)
                Catch ex As Exception
                    FormerUDP.LogMe("COMMESSA " & IdCom & " Non sono riuscito a cancellare l'anteprima PDF " & PathEsistente,, ex)
                    'MessageBox.Show("Non sono riuscito a cancellare l'anteprima " & PathEsistente)
                End Try
                PathEsistente = PathEsistente.Replace(".pdf", ".jpg")
                Try
                    If File.Exists(PathEsistente) Then MgrFormerIO.FileDelete(PathEsistente)
                Catch ex As Exception
                    FormerUDP.LogMe("COMMESSA " & IdCom & " Non sono riuscito a cancellare l'anteprima " & PathEsistente,, ex)
                    'MessageBox.Show("Non sono riuscito a cancellare l'anteprima " & PathEsistente)
                End Try

                If c.ModelloCommessa.FronteRetro = enSiNo.Si AndAlso c.ModelloCommessa.FRSuSeStessa = enSiNo.No Then
                    L.Add(FileToCopy & c.IdCom & "." & I & "B.pdf")
                    PathEsistente = FormerPath.PathCommesse & c.IdCom & "\" & c.IdCom & "." & I & "B.pdf"
                    Try
                        If File.Exists(PathEsistente) Then MgrFormerIO.FileDelete(PathEsistente)
                    Catch ex As Exception
                        FormerUDP.LogMe("COMMESSA " & IdCom & " Non sono riuscito a cancellare l'anteprima PDF " & PathEsistente,, ex)
                        'MessageBox.Show("Non sono riuscito a cancellare l'anteprima PDF " & PathEsistente)
                    End Try
                    PathEsistente = PathEsistente.Replace(".pdf", ".jpg")
                    Try
                        If File.Exists(PathEsistente) Then MgrFormerIO.FileDelete(PathEsistente)
                    Catch ex As Exception
                        FormerUDP.LogMe("COMMESSA " & IdCom & " Non sono riuscito a cancellare l'anteprima " & PathEsistente,, ex)
                        'MessageBox.Show("Non sono riuscito a cancellare l'anteprima " & PathEsistente)
                    End Try

                End If
            Next

            Dim bw As BackgroundWorker = New BackgroundWorker
            bw.WorkerSupportsCancellation = False
            bw.WorkerReportsProgress = False
            AddHandler bw.DoWork, AddressOf bw_DoWork
            AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

            Dim LPar As New List(Of Object)
            LPar.Add(c.IdCom)
            LPar.Add(L)
            'LPar.Add(FormRif.Handle)
            LPar.Add(ForzaMandaAlFlusso)
            LPar.Add(Mittente)

            bw.RunWorkerAsync(LPar)
        End Using

    End Sub

    Private Shared Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)

        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim Argument As List(Of Object) = e.Argument
        Dim IdCom As Integer = Argument(0)
        Dim L As List(Of String) = Argument(1)
        'Dim HandleFinestra As IntPtr = Argument(2)
        Dim ForzaMandaAlFlusso As Boolean = Argument(2)
        Dim Mittente As String = Argument(3)

        e.Result = "C" & IdCom & "§" & Mittente

        Dim OperazioneCompletata As Boolean = False
        Dim IntervalloStart As Integer = 30000
        Dim IntervalloCiclo As Integer = 30000

        If FormerDebug.DebugAttivo Then
            IntervalloStart /= 10
            IntervalloCiclo /= 10
        End If

        Try
            Threading.Thread.Sleep(IntervalloStart) 'intanto aspetto 30 secondi 
            Dim lTrovati As List(Of String) = Nothing
            For i As Integer = 1 To 10
                lTrovati = New List(Of String)
                'testo se trovo i fileche mi servono e li copio 
                For Each sing In L
                    If File.Exists(sing) Then
                        If FormerHelper.File.IsFileLocked(sing) = False Then
                            lTrovati.Add(sing)
                        Else
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                Next

                If lTrovati.Count = L.Count Then
                    CopiaListaTrovati(IdCom, lTrovati)
                    OperazioneCompletata = True
                End If
                If OperazioneCompletata Then
                    Exit For
                Else
                    Threading.Thread.Sleep(IntervalloCiclo) 'poi aspetto 1 minuto ogni volta 
                End If

            Next

            If OperazioneCompletata = False Then
                'qui controllo che ci siano almeno tutti i fronte 
                Dim TrovatiTuttiFronte As Boolean = True
                For Each sing As String In L.FindAll(Function(x) x.ToLower.EndsWith("a.pdf"))
                    If lTrovati.FindAll(Function(x) x = sing).Count = 0 Then
                        TrovatiTuttiFronte = False
                        Exit For
                    End If
                Next

                If TrovatiTuttiFronte Then
                    CopiaListaTrovati(IdCom, lTrovati)
                    OperazioneCompletata = True
                End If
            End If

        Catch ex As Exception

        End Try

        If OperazioneCompletata = True Then
            Using C As New Commessa
                C.Read(IdCom)
                If C.FromJob = enSiNo.No OrElse ForzaMandaAlFlusso = True Then

                    'Dim f As frmBaseForm
                    'f = Control.FromHandle(HandleFinestra)

                    MgrCommesse.MandaAlFlusso(IdCom, Mittente)
                End If
            End Using
            e.Result = "O" & IdCom & "§" & Mittente
        End If

    End Sub

    Public Shared Sub MandaAlFlusso(IdCom As Integer, Mittente As String)
        'If DgCommesse.SelectedRows.Count Then
        Using c As New Commessa
            c.Read(IdCom)

            If c.Stato <= enStatoCommessa.Pronto Then
                Dim Path As String = FormerPath.PathCommesse & c.IdCom & "\" & c.IdCom & ".jdf" '(c.ModelloCommessa.Job)

                Using M As New Macchinario
                    'qui devo prendere il macchinario forzato se presente senno quello di creazione

                    Dim IdMacchinario As Integer = c.IdMacchinario

                    If Not c.LavLogRealizzazione Is Nothing Then
                        If c.LavLogRealizzazione.IdMacchinario <> 0 Then
                            IdMacchinario = c.LavLogRealizzazione.IdMacchinario
                        End If
                    End If

                    M.Read(IdMacchinario)

                    If M.HotFolderFlusso.Length Then
                        Dim risPath As String = M.HotFolderFlusso & "\" & c.IdCom & ".jdf"
                        MgrFormerIO.FileCopy(Path, risPath)
                        'FileCopia(FormRif, Path, risPath)
                        'MessageBox.Show("Invio al flusso " & M.Descrizione.ToUpper & " su " & M.HotFolderFlusso & " Completato")
                        Using mgr As New CommesseDAO
                            mgr.InserisciLog(c, enStatoCommessa.Pronto, FormerConst.UtentiSpecifici.IdUtenteAdmin)
                        End Using
                        'c.Stato = enStatoCommessa.Pronto
                        'Else
                        '    MessageBox.Show("Non è stato configurato un Hotfolder per il flusso per il macchinario " & M.Descrizione.ToUpper)
                    End If

                End Using
            End If

        End Using '= DgCommesse.SelectedRows(0).DataBoundItem

        'End If
    End Sub

    Private Shared Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)

        Dim Risultato As String = e.Result

        Dim Tipo As String = Risultato.Substring(0, 1)
        Dim Posiz As Integer = Risultato.IndexOf("§")

        Dim IdCom As Integer = Risultato.Substring(1, Posiz - 1)
        Dim Mittente As String = Risultato.Substring(Posiz + 1)

        If Tipo = "C" Then
            FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Notifica, "Errore creazione anteprima Commessa " & IdCom, Mittente, FormerLib.FormerUDP.DestUDP_Admin)
            'FormPrincipale.UcToolbarMain.AddNotifica("Errore creazione anteprima Commessa " & IdCom)
        ElseIf Tipo = "O" Then
            FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Notifica, "Creazione anteprima Commessa " & IdCom & " terminata correttamente!", Mittente, FormerLib.FormerUDP.DestUDP_Admin)
            'FormPrincipale.UcToolbarMain.AddNotifica("Creazione anteprima Commessa " & IdCom & " terminata correttamente!")
        End If
    End Sub

    Private Shared Sub CopiaListaTrovati(IdCom As Integer,
                                         lTrovati As List(Of String))
        For Each s In lTrovati
            Dim DestFileName As String = FormerPath.PathCommesse & IdCom & "\" & FormerHelper.File.EstraiNomeFile(s)
            MgrFormerIO.FileCopy(s, DestFileName)
            'IO.File.Copy(s, DestFileName, True)
            Dim NomeAnteprima As String = DestFileName.ToLower.Replace(".pdf", ".jpg")
            FormerHelper.PDF.GetPdfThumbnail(DestFileName, NomeAnteprima)
        Next
    End Sub

End Class
