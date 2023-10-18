Imports System.ComponentModel
Imports System.IO
Imports FormerConfig
Imports FormerDALSql
Imports FormerIO
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrCommesse

    Public Shared Function RimuoviOrdineDaCommessa(Sender As Object,
                                                   IdOrd As Integer)

        Dim ris As Integer = 0

        'Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()

        Try

                Using O As New Ordine
                    O.Read(IdOrd)

                    Dim PathOld As String = O.FilePath
                    Dim PathDest As String = FormerPath.PathTemp & FormerHelper.File.EstraiNomeFile(O.FilePath)

                    If PathOld.StartsWith(FormerPath.PathTemp) = False Then
                        MgrIO.FileCopia(Sender, PathOld, PathDest)
                        O.FilePath = PathDest
                    End If

                    For Each S As FileSorgente In O.ListaSorgenti
                        PathOld = S.FilePath

                        If PathOld.StartsWith(FormerPath.PathTemp) = False Then
                            Dim NomeFile As String = FormerHelper.File.EstraiNomeFile(S.FilePath)

                            If NomeFile.IndexOf(O.IdOrd) <> -1 Then
                                NomeFile = NomeFile.Substring(NomeFile.IndexOf(O.IdOrd))
                            End If

                            PathDest = FormerPath.PathTemp & NomeFile

                            MgrIO.FileCopia(Sender, PathOld, PathDest)

                            S.FilePath = PathDest
                            S.Save()
                        End If

                    Next

                    For Each F As FileAllegato In O.ListaFileAllegati
                        PathOld = F.FilePath

                        If PathOld.StartsWith(FormerPath.PathTemp) = False Then
                            Dim NomeFile As String = FormerHelper.File.EstraiNomeFile(F.FilePath)

                            PathDest = FormerPath.PathTemp & NomeFile

                            MgrIO.FileCopia(Sender, PathOld, PathDest)

                            F.FilePath = PathDest
                            F.Save()
                        End If
                    Next

                    For Each ll As LavLog In O.Commessa.ListaLavLog
                        'qui devo aggiungere la lavorazione 
                        Using nn As LavLog = ll.Clone
                            nn.IdLavLog = 0
                            nn.IdCom = 0
                            nn.IdOrd = O.IdOrd
                            nn.Save()
                        End Using
                    Next

                    O.LastUpdate = enSiNo.Si
                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "ELIMINATO DA COMMESSA " & O.IdCom)
                Dim IdComOrdine As Integer = O.IdCom
                O.IdCom = 0
                If O.Stato <> enStatoOrdine.Rifiutato And
                       O.Stato <> enStatoOrdine.InSospeso And
                       O.Stato <> enStatoOrdine.Eliminato Then
                    O.Stato = enStatoOrdine.Registrato
                End If
                O.Save()

                Using C As New Commessa
                    C.Read(IdComOrdine)
                    If C.ListaOrdini.FindAll(Function(x) x.IdOrd <> O.IdOrd).Count = 0 Then
                        'QUI NON CI SONO ALTRI ORDINI 
                        'elimino le lavorazioni su commessa da lavlog 
                        Using mgr As New LavLogDAO
                            mgr.DeleteByIdCom(IdComOrdine)
                        End Using

                        'annullo le prenotazioni di magazzino 
                        C.CaricaMovimentiMagazzino()

                        For Each Mov In O.Commessa.MovMagaz
                            Using mgr As New MagazzinoDAO
                                mgr.AnnullaMovimento(Mov)
                            End Using
                        Next

                        'elimino la commessa
                        Using mgr As New CommesseDAO
                            mgr.Delete(IdComOrdine)
                        End Using
                    End If
                End Using

            End Using

            Catch ex As Exception
                ris = 1
            'tb.TransactionRollBack()
            MessageBox.Show("Si è verificato il seguente errore nella rimozione dell'ordine dalla commessa: " & ex.Message)
        End Try

        'End Using
        Return ris

    End Function

    Public Shared Function AnnullaCommessa(Sender As Object,
                                           _ComSel As Commessa) As Integer
        Dim ris As Integer = 0

        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()

            Try
                'ATTENZIONE STA COSA NON VA BENE. TRANSAZIONE CON DENTRO COPIA FILE NO NO 
                'TROVARE SOLUZIONE A REGIME
                tb.TransactionBegin()

                For Each O As Ordine In _ComSel.ListaOrdini
                    'qui devo spostare i file 

                    Dim PathOld As String = O.FilePath
                    Dim PathDest As String = FormerPath.PathTemp & FormerHelper.File.EstraiNomeFile(O.FilePath)

                    If PathOld.StartsWith(FormerPath.PathTemp) = False Then
                        MgrIO.FileCopia(Sender, PathOld, PathDest)
                        O.FilePath = PathDest
                    End If

                    For Each S As FileSorgente In O.ListaSorgenti
                        PathOld = S.FilePath

                        If PathOld.StartsWith(FormerPath.PathTemp) = False Then
                            Dim NomeFile As String = FormerHelper.File.EstraiNomeFile(S.FilePath)

                            If NomeFile.IndexOf(O.IdOrd) <> -1 Then
                                NomeFile = NomeFile.Substring(NomeFile.IndexOf(O.IdOrd))
                            End If

                            PathDest = FormerPath.PathTemp & NomeFile

                            MgrIO.FileCopia(Sender, PathOld, PathDest)

                            S.FilePath = PathDest
                            S.Save()
                        End If

                    Next

                    For Each F As FileAllegato In O.ListaFileAllegati
                        PathOld = F.FilePath

                        If PathOld.StartsWith(FormerPath.PathTemp) = False Then
                            Dim NomeFile As String = FormerHelper.File.EstraiNomeFile(F.FilePath)

                            PathDest = FormerPath.PathTemp & NomeFile

                            MgrIO.FileCopia(Sender, PathOld, PathDest)

                            F.FilePath = PathDest
                            F.Save()
                        End If
                    Next

                    For Each ll As LavLog In _ComSel.ListaLavLog
                        'qui devo aggiungere la lavorazione 
                        Using nn As LavLog = ll.Clone
                            nn.IdLavLog = 0
                            nn.IdCom = 0
                            nn.IdOrd = O.IdOrd
                            nn.Save()
                        End Using
                    Next

                    O.LastUpdate = enSiNo.Si
                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "ELIMINATO DA COMMESSA " & O.IdCom)
                    O.IdCom = 0
                    If O.Stato <> enStatoOrdine.Rifiutato OrElse
                       O.Stato <> enStatoOrdine.InSospeso OrElse
                       O.Stato <> enStatoOrdine.Eliminato Then
                        O.Stato = enStatoOrdine.Registrato
                    End If
                    O.Save()

                Next

                'elimino le lavorazioni su commessa da lavlog 
                Using mgr As New LavLogDAO
                    mgr.DeleteByIdCom(_ComSel.IdCom)
                End Using

                'annullo le prenotazioni di magazzino 
                _ComSel.CaricaMovimentiMagazzino()

                For Each Mov In _ComSel.MovMagaz
                    Using mgr As New MagazzinoDAO
                        mgr.AnnullaMovimento(Mov)
                    End Using
                Next

                'elimino la commessa
                Using mgr As New CommesseDAO
                    mgr.Delete(_ComSel.IdCom)
                End Using

                tb.TransactionCommit()

                'richiedo la chiusura della form
                'RaiseEvent CommessaCancellata()

            Catch ex As Exception
                ris = 1
                tb.TransactionRollBack()
                MessageBox.Show("Si è verificato il seguente errore nell'annullamento della commessa: " & ex.Message)
            End Try

        End Using
        Return ris
    End Function

    Public Shared Function UnisciCommesse(ListaCommesse As List(Of Commessa)) As Integer
        Dim Ris As Integer = 0

        If ListaCommesse.FindAll(Function(x) x.IdReparto <> enRepartoWeb.StampaDigitale).Count Then
            MessageBox.Show("L'unione delle commesse è disponibile solo per il reparto DIGITALE")
        Else
            If ListaCommesse.Count > 1 Then

                Dim CheckOk As Boolean = True

                'qui controllo che tutte le commesse hanno lo stesso tipo di carta, e lo stesso macchinario 

                Dim IdMacchinario As Integer = 0
                Dim IdTipoCarta As Integer = 0

                For Each C As Commessa In ListaCommesse
                    If IdMacchinario = 0 Then
                        IdMacchinario = C.IdMacchinario
                        IdTipoCarta = C.ListaOrdini()(0).ListinoBase.IdTipoCarta
                    Else
                        If IdMacchinario <> C.IdMacchinario OrElse
                        IdTipoCarta <> C.ListaOrdini()(0).ListinoBase.IdTipoCarta Then
                            CheckOk = False
                            Exit For
                        End If
                    End If
                Next

                If CheckOk Then

                    'controllo lo stato
                    Dim OkStato As Boolean = True

                    For Each C As Commessa In ListaCommesse
                        If C.Stato <> enStatoCommessa.Preinserito Then
                            OkStato = False
                            Exit For
                        End If
                    Next

                    If OkStato Then
                        'qui posso fare il merge dopo aver controllato i file

                        Dim OkFile As Boolean = True
                        Dim BufferLocked As String = String.Empty

                        For Each C As Commessa In ListaCommesse
                            For Each o As Ordine In C.ListaOrdini

                                For Each S As FileSorgente In o.ListaSorgenti
                                    If FormerHelper.File.IsFileLocked(S.FilePath) Then
                                        BufferLocked &= " - " & S.FilePath & ControlChars.NewLine
                                        OkFile = False
                                    End If
                                Next
                            Next
                        Next

                        If OkFile Then
                            If MessageBox.Show("Confermi l'unione delle commesse selezionate?",, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Dim CommessaRif As Commessa = ListaCommesse(0)

                                Dim x As Integer() = Nothing

                                For Each C As Commessa In ListaCommesse
                                    Dim Posizione As Integer = 0 'C.ListaOrdini.Count
                                    Dim Tot As Integer = C.ListaOrdini.Count
                                    If Not x Is Nothing Then
                                        Tot += x.Count
                                        Posizione = x.Count
                                    End If
                                    Array.Resize(x, Tot)

                                    For Each o As Ordine In C.ListaOrdini
                                        x.SetValue(o.IdOrd, Posizione)
                                        Posizione += 1
                                    Next

                                Next

                                Dim OperazioneOk As Boolean = True

                                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                                    Try
                                        CommessaRif.ListaIdOrdini = x
                                        CommessaRif.Copie = 1

                                        tb.TransactionBegin()
                                        Using M As New CommesseDAO

                                            M.SalvaOrdiniTornaEsclusi(CommessaRif)
                                            M.SalvaMovMagaz(CommessaRif)

                                            'If swFirst Then 'questo lo devo fare per forza dopo il salvataggio degli ordini
                                            M.InserisciLavorazioni(CommessaRif)
                                            'End If
                                            For Each C As Commessa In ListaCommesse
                                                If C.IdCom <> CommessaRif.IdCom Then
                                                    M.Delete(C.IdCom)
                                                End If
                                            Next
                                        End Using

                                        tb.TransactionCommit()
                                    Catch ex As Exception
                                        tb.TransactionRollBack()
                                        OperazioneOk = False
                                    End Try

                                End Using

                                If OperazioneOk Then
                                    MgrCommesse.SalvaFile(CommessaRif)

                                    Ris = 1
                                Else
                                    MessageBox.Show("Si è verificato un errore nell'unione delle commesse")
                                End If
                            End If

                        Else
                            MessageBox.Show("Impossibile continuare, i seguenti file risultano locked:" & ControlChars.NewLine & BufferLocked & ControlChars.NewLine & "Controllare che non siano aperti in altri programmi e riprovare")

                        End If
                    Else
                        MessageBox.Show("Si possono unire solo commesse in stato Preinserito")
                    End If

                Else
                    MessageBox.Show("Le commesse selezionate non sono compatibili per macchinario o tipocarta")
                End If

            Else
                MessageBox.Show("Selezionare almeno 2 commesse DIGITALI!")
            End If
        End If

        Return Ris

    End Function

    Public Shared Sub CreaAnteprima(ByRef Sender As Object,
                                    IdCom As Integer,
                                    Optional ForzaMandaAlFlusso As Boolean = False,
                                    Optional FromUI As Boolean = False)

        Dim IdCr As enTipoComandoRemoto = enTipoComandoRemoto.CreaAnteprimaCommessa

        If ForzaMandaAlFlusso Then
            IdCr = enTipoComandoRemoto.CreaAnteprimaCommessaEMandaAlFlusso
        End If

        Dim Ris As RisCreazioneComandoRemoto = MgrComandiRemoti.Crea(IdCom, , PostazioneCorrente.UtenteConnesso.IdUt, IdCr)

        Using CR As New ComandoRemoto
            CR.IdCom = IdCom
            CR.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
            CR.TipoOperazione = IdCr
            CR.Stato = enStatoComandoRemoto.Inserito
            CR.Save()

            Using crL As New ComandoRemotoLog
                crL.IdCM = CR.IdCM
                crL.Quando = Now
                crL.IdOperazioneRemota = enStatoComandoRemoto.Inserito
                crL.Save()
            End Using
        End Using

        Dim Testo As String = IdCom & "§" & ForzaMandaAlFlusso.ToString

        FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_CreaAnteprimaCommessa,
                                 Testo,
                                 ,
                                 PostazioneCorrente.UtenteConnesso.Login)

        If FromUI Then
            If ForzaMandaAlFlusso Then
                MessageBox.Show("Comando 'Invio al Flusso' inviato al demone per la Commessa " & IdCom)
            Else
                MessageBox.Show("Comando 'Creazione Anteprima' inviato al demone per la Commessa " & IdCom)
            End If
        End If


        'Using c As New Commessa
        '    c.Read(IdCom)

        '    Dim Path As String = FormerPath.PathCommesse & c.IdCom & "\" & c.IdCom & ".jdf" '(c.ModelloCommessa.Job)

        '    Dim risPath As String = FormerPath.HotFolder.CreazioneAnteprimaPDFfromJOB & c.IdCom & ".jdf"
        '    MgrIO.FileCopia(Sender, Path, risPath)
        '    'MgrIO.FileCopia(FormRif, Path, risPath)

        '    'qui devo lanciare il background-worker
        '    'che monitora la creazione del pdf in alta risoluzione della commessa
        '    Dim L As New List(Of String)
        '    Dim FileToCopy As String = FormerPath.HotFolder.CreazioneAnteprimaPDFfromJOB & "Output\"

        '    For I As Integer = 1 To c.Segnature
        '        L.Add(FileToCopy & c.IdCom & "." & I & "A.pdf")
        '        'se c'e' la cancello
        '        Dim PathEsistente As String = FormerPath.PathCommesse & c.IdCom & "\" & c.IdCom & "." & I & "A.pdf"
        '        Try
        '            If File.Exists(PathEsistente) Then MgrFormerIO.FileDelete(PathEsistente)
        '        Catch ex As Exception
        '            MessageBox.Show("Non sono riuscito a cancellare l'anteprima " & PathEsistente)
        '        End Try
        '        PathEsistente = PathEsistente.Replace(".pdf", ".jpg")
        '        Try
        '            If File.Exists(PathEsistente) Then MgrFormerIO.FileDelete(PathEsistente)
        '        Catch ex As Exception
        '            MessageBox.Show("Non sono riuscito a cancellare l'anteprima " & PathEsistente)
        '        End Try

        '        If c.ModelloCommessa.FronteRetro = enSiNo.Si AndAlso c.ModelloCommessa.FRSuSeStessa = enSiNo.No Then
        '            L.Add(FileToCopy & c.IdCom & "." & I & "B.pdf")
        '            PathEsistente = FormerPath.PathCommesse & c.IdCom & "\" & c.IdCom & "." & I & "B.pdf"
        '            Try
        '                If File.Exists(PathEsistente) Then MgrFormerIO.FileDelete(PathEsistente)
        '            Catch ex As Exception
        '                MessageBox.Show("Non sono riuscito a cancellare l'anteprima PDF " & PathEsistente)
        '            End Try
        '            PathEsistente = PathEsistente.Replace(".pdf", ".jpg")
        '            Try
        '                If File.Exists(PathEsistente) Then MgrFormerIO.FileDelete(PathEsistente)
        '            Catch ex As Exception
        '                MessageBox.Show("Non sono riuscito a cancellare l'anteprima " & PathEsistente)
        '            End Try

        '        End If
        '    Next

        '    Dim bw As BackgroundWorker = New BackgroundWorker
        '    bw.WorkerSupportsCancellation = False
        '    bw.WorkerReportsProgress = False
        '    AddHandler bw.DoWork, AddressOf bw_DoWork
        '    AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

        '    Dim LPar As New List(Of Object)
        '    LPar.Add(c.IdCom)
        '    LPar.Add(L)
        '    'LPar.Add(FormRif.Handle)
        '    LPar.Add(ForzaMandaAlFlusso)

        '    bw.RunWorkerAsync(LPar)
        'End Using
    End Sub

    'Private Shared Sub CopiaListaTrovati(IdCom As Integer,
    '                                     lTrovati As List(Of String))
    '    For Each s In lTrovati
    '        Dim DestFileName As String = FormerPath.PathCommesse & IdCom & "\" & FormerHelper.File.EstraiNomeFile(s)
    '        MgrIO.FileCopia(Nothing, s, DestFileName)
    '        'IO.File.Copy(s, DestFileName, True)
    '        Dim NomeAnteprima As String = DestFileName.ToLower.Replace(".pdf", ".jpg")
    '        FormerHelper.PDF.GetPdfThumbnail(DestFileName, NomeAnteprima)
    '    Next
    'End Sub

    'Private Shared Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)

    '    Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
    '    Dim Argument As List(Of Object) = e.Argument
    '    Dim IdCom As Integer = Argument(0)
    '    Dim L As List(Of String) = Argument(1)
    '    'Dim HandleFinestra As IntPtr = Argument(2)
    '    Dim ForzaMandaAlFlusso As Boolean = Argument(2)

    '    e.Result = "C" & IdCom
    '    Dim OperazioneCompletata As Boolean = False
    '    Dim IntervalloStart As Integer = 30000
    '    Dim IntervalloCiclo As Integer = 60000

    '    If FormerDebug.DebugAttivo Then
    '        IntervalloStart /= 10
    '        IntervalloCiclo /= 10
    '    End If

    '    Try
    '        Threading.Thread.Sleep(IntervalloStart) 'intanto aspetto 30 secondi 
    '        Dim lTrovati As List(Of String) = Nothing
    '        For i As Integer = 1 To 10
    '            lTrovati = New List(Of String)
    '            'testo se trovo i fileche mi servono e li copio 
    '            For Each sing In L
    '                If File.Exists(sing) Then
    '                    If FormerHelper.File.IsFileLocked(sing) = False Then
    '                        lTrovati.Add(sing)
    '                    Else
    '                        Exit For
    '                    End If
    '                Else
    '                    Exit For
    '                End If
    '            Next

    '            If lTrovati.Count = L.Count Then
    '                CopiaListaTrovati(IdCom, lTrovati)
    '                OperazioneCompletata = True
    '            End If
    '            If OperazioneCompletata Then
    '                Exit For
    '            Else
    '                Threading.Thread.Sleep(IntervalloCiclo) 'poi aspetto 1 minuto ogni volta 
    '            End If

    '        Next

    '        If OperazioneCompletata = False Then
    '            'qui controllo che ci siano almeno tutti i fronte 
    '            Dim TrovatiTuttiFronte As Boolean = True
    '            For Each sing As String In L.FindAll(Function(x) x.ToLower.EndsWith("a.pdf"))
    '                If lTrovati.FindAll(Function(x) x = sing).Count = 0 Then
    '                    TrovatiTuttiFronte = False
    '                    Exit For
    '                End If
    '            Next

    '            If TrovatiTuttiFronte Then
    '                CopiaListaTrovati(IdCom, lTrovati)
    '                OperazioneCompletata = True
    '            End If
    '        End If

    '    Catch ex As Exception

    '    End Try

    '    If OperazioneCompletata = True Then
    '        Using C As New Commessa
    '            C.Read(IdCom)
    '            If C.FromJob = enSiNo.No OrElse ForzaMandaAlFlusso = True Then

    '                'Dim f As frmBaseForm
    '                'f = Control.FromHandle(HandleFinestra)

    '                MgrCommesse.MandaAlFlusso(Nothing, IdCom)
    '            End If
    '        End Using
    '        e.Result = "O" & IdCom
    '    End If

    'End Sub

    'Private Shared Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)

    '    Dim Risultato As String = e.Result

    '    Dim Tipo As String = Risultato.Substring(0, 1)
    '    Dim IdCom As Integer = Risultato.Substring(1)

    '    If Tipo = "C" Then
    '        FormPrincipale.UcToolbarMain.AddNotifica("Errore creazione anteprima Commessa " & IdCom)
    '    ElseIf Tipo = "O" Then
    '        FormPrincipale.UcToolbarMain.AddNotifica("Creazione anteprima Commessa " & IdCom & " terminata correttamente!")
    '    End If
    'End Sub
    'Private Shared Sub MandaAlFlusso(ByRef Sender As Object,
    '                                IdCom As Integer)
    '    Dim Testo As String = IdCom

    '    FormerUDP.SendUDPCommand(FormerUDP.TipoUDP_MandaAlFlussoCommessa,
    '                             Testo,
    '                             ,
    '                             PostazioneCorrente.UtenteConnesso.Login)
    '    ''If DgCommesse.SelectedRows.Count Then
    '    'Using c As New Commessa
    '    '    c.Read(IdCom)
    '    '    Dim Path As String = FormerPath.PathCommesse & c.IdCom & "\" & c.IdCom & ".jdf" '(c.ModelloCommessa.Job)

    '    '    Using M As New Macchinario
    '    '        M.Read(c.IdMacchinario)

    '    '        If M.HotFolderFlusso.Length Then
    '    '            Dim risPath As String = M.HotFolderFlusso & "\" & c.IdCom & ".jdf"
    '    '            MgrIO.FileCopia(Sender, Path, risPath)
    '    '            'MgrIO.FileCopia(FormRif, Path, risPath)
    '    '            'MessageBox.Show("Invio al flusso " & M.Descrizione.ToUpper & " su " & M.HotFolderFlusso & " Completato")
    '    '            Using mgr As New CommesseDAO
    '    '                mgr.InserisciLog(c, enStatoCommessa.Pronto, PostazioneCorrente.UtenteConnesso.IdUt)
    '    '            End Using
    '    '            'c.Stato = enStatoCommessa.Pronto
    '    '        Else
    '    '            MessageBox.Show("Non è stato configurato un Hotfolder per il flusso per il macchinario " & M.Descrizione.ToUpper)
    '    '        End If

    '    '    End Using
    '    'End Using '= DgCommesse.SelectedRows(0).DataBoundItem


    '    'End If
    'End Sub

    Public Shared Function SalvaFile(ByRef Com As Commessa) As Integer

        'devo salvare il file della commessa e i file di tutti gli ordini

        Dim Ris As Integer = 0

        Using Mgr As New CommesseDAO
            Ris = Mgr.SalvaFile(Com)
        End Using

        Return Ris

    End Function

End Class
