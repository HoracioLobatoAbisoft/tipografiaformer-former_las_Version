Imports FormerDALSql
Imports FW = FormerDALWeb
Imports So = System.IO
Imports System.Configuration
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerLib.FormerHelper
Imports FormerBusinessLogicInterface
Imports FormerBusinessLogic
Imports System.IO
Imports System.Xml
Imports System.Data.Common
Imports FormerConfig
Imports System.Text
Imports System.Text.RegularExpressions
Imports FI = FormerIO
Imports System.Data
Imports System.Data.SqlClient

Friend Class FormerService
    Inherits BaseService

#Region "Base Function"

    Private Shared Property _txtLog As TextBox = Nothing
    Private Shared Property _lblLastOp As Label = Nothing
    Private Shared Property _ModuleName As String = String.Empty
    Private Shared Property _ModuleSigla As String = String.Empty

    Public Shared ReadOnly Property ModuleSigla As String
        Get
            Return _ModuleSigla
        End Get
    End Property

    Public Shared Sub Initialize(ByRef txtLog As TextBox,
                                 ByRef lblLastOp As Label,
                                 ModuleName As String,
                                 ModuleSigla As String)
        _txtLog = txtLog
        _lblLastOp = lblLastOp
        _ModuleName = ModuleName
        _ModuleSigla = ModuleSigla

    End Sub

    Public Shared Sub LogMe(Testo As String,
             Optional DontStore As Boolean = False,
             Optional Errore As Exception = Nothing)
        _LogMe(_txtLog, _lblLastOp, Testo, _ModuleName, _ModuleSigla, DontStore, Errore)
    End Sub

#End Region

#Region "Property"

    Public Shared ReadOnly Property IntervalNewVerMinuti As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-Interval-NewVersion")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalOrarioMinuti As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-Interval-IntervalloOrario")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalTxtToHCCMinuti As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-Interval-TxtToHCC")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalTxtToHCC As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-Interval-TxtToHCC")
            If Ris Then Ris = Ris * 60 * 1000
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalNewVer As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-Interval-NewVersion")
            If Ris Then Ris = Ris * 60 * 1000
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property IntervalOrario As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-Interval-IntervalloOrario")
            If Ris Then Ris = Ris * 60 * 1000
            Return Ris
        End Get
    End Property

    Private Shared ReadOnly Property Colore1 As String
        Get
            Return ConfigurationManager.AppSettings("Service-Colore1")
        End Get
    End Property

    Private Shared ReadOnly Property Colore2 As String
        Get
            Return ConfigurationManager.AppSettings("Service-Colore2")
        End Get
    End Property

    Private Shared ReadOnly Property Colore3 As String
        Get
            Return ConfigurationManager.AppSettings("Service-Colore3")
        End Get
    End Property

    Private Shared ReadOnly Property Colore4 As String
        Get
            Return ConfigurationManager.AppSettings("Service-Colore4")
        End Get
    End Property

    Public Shared ReadOnly Property HBackup As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-H-Backup")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property HPromoAutomatici As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-H-PromoAutomatici")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property HSpostamentoConsegne As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-H-SpostamentoConsegne")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property HCleanTemp As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-H-CleanTemp")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property HMarketingBilanciato As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-H-MarketingBilanciato")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property HInvioFattureFE As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-H-InvioFattureFE")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property HDownloadLog As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-H-DownloadLog")
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property HBackupDB As Integer
        Get
            Dim Ris As Integer = ConfigurationManager.AppSettings("Service-H-BackupDB")
            Return Ris
        End Get
    End Property

    Private Shared Function NumeroColore(Colore As String) As Integer
        Dim Ris As Integer = 0
        Select Case Colore
            Case "Black"
                Ris = 1
            Case "Magenta"
                Ris = 2
            Case "Yellow"
                Ris = 3
            Case "Cyan"
                Ris = 4
        End Select
        Return Ris
    End Function

#End Region

    Public Class TxtToHCC
        'Inherits FormerService

        Public Shared Sub StartService()

            Stato = enStatoServizio.Attivo

            LogMe("***Conversione TxtToHCC***")

            Try
                If So.Directory.Exists(PathSorgentiHCC) Then
                    'sposto tutti i sorgenti in cip3
                    Dim dS As New So.DirectoryInfo(PathSorgentiHCC)
                    For Each fileSorg As So.FileInfo In dS.GetFiles("*.txt")
                        So.File.Copy(fileSorg.FullName, PathHCC & fileSorg.Name, True)
                        fileSorg.Delete()
                    Next

                    'sposto tutti i sorgenti in cip3
                    Dim dS2 As New So.DirectoryInfo(PathSorgentiHCC35x50)
                    For Each fileSorg As So.FileInfo In dS2.GetFiles("*.txt")
                        So.File.Copy(fileSorg.FullName, PathHCC & fileSorg.Name, True)
                        fileSorg.Delete()
                    Next

                    Dim x As New So.DirectoryInfo(PathHCC)
                    Dim buffColore1 As String = ""
                    Dim buffColore2 As String = ""
                    Dim buffColore3 As String = ""
                    Dim buffColore4 As String = ""

                    For Each fileS As So.FileInfo In x.GetFiles("*.txt")

                        Dim NuovoNomeFile As String = fileS.Name.Substring(0, fileS.Name.Length - 4) & ".hcc"

                        If So.File.Exists(PathHCC & NuovoNomeFile) = True Then

                            Dim FOld As New FileInfo(fileS.FullName)
                            Dim FNew As New FileInfo(PathHCC & NuovoNomeFile)

                            If FNew.LastWriteTime < FOld.LastWriteTime Then
                                So.File.Delete(PathHCC & NuovoNomeFile)
                            End If

                        End If

                        If So.File.Exists(PathHCC & NuovoNomeFile) = False Then
                            LogMe("***CONVERSIONE " & fileS.Name)
                            buffColore1 = String.Empty
                            buffColore2 = String.Empty
                            buffColore3 = String.Empty
                            buffColore4 = String.Empty
                            Dim NuovoFileCont As String = vbLf

                            NuovoFileCont &= NumeroColore(Colore1) & vbLf & NumeroColore(Colore2) & vbLf & NumeroColore(Colore3) & vbLf & NumeroColore(Colore4) & vbLf
                            For i As Integer = 1 To 5
                                NuovoFileCont &= vbLf
                            Next
                            NuovoFileCont &= "4" & vbLf & "14" & vbLf
                            For i As Integer = 1 To 22
                                NuovoFileCont &= vbLf
                            Next
                            Using w As New So.StreamWriter(PathHCC & NuovoNomeFile, False)
                                Using r As New So.StreamReader(fileS.FullName)

                                    Dim cont As Integer = 0
                                    While r.EndOfStream = False
                                        cont += 1
                                        Dim Riga As String = r.ReadLine
                                        If cont > 1 Then
                                            Dim valori() As String = Riga.Split(ControlChars.Tab)
                                            Select Case valori(5)
                                                Case Colore1
                                                    For i As Integer = 12 To 25
                                                        buffColore1 &= "" & valori(i) & "" & vbLf
                                                    Next
                                                    For i As Integer = 1 To 19
                                                        buffColore1 &= vbLf
                                                    Next
                                                Case Colore2
                                                    For i As Integer = 12 To 25
                                                        buffColore2 &= "" & valori(i) & "" & vbLf
                                                    Next
                                                    For i As Integer = 1 To 19
                                                        buffColore2 &= vbLf
                                                    Next
                                                Case Colore3
                                                    For i As Integer = 12 To 25
                                                        buffColore3 &= "" & valori(i) & "" & vbLf
                                                    Next
                                                    For i As Integer = 1 To 19
                                                        buffColore3 &= vbLf
                                                    Next
                                                Case Colore4
                                                    For i As Integer = 12 To 25
                                                        buffColore4 &= "" & valori(i) & "" & vbLf
                                                    Next
                                                    For i As Integer = 1 To 19
                                                        buffColore4 &= vbLf
                                                    Next
                                            End Select
                                        End If
                                    End While
                                    r.Close()
                                End Using
                                NuovoFileCont &= buffColore1 & buffColore2 & buffColore3 & buffColore4
                                w.Write(NuovoFileCont)
                                w.Close()
                            End Using

                        End If

                    Next
                End If


            Catch ex As Exception
                LogMe("SORGENTE: TxtToHCC(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

            End Try

            LogMe("***Conversione TxtToHCC TERMINATO***")

            Stato = enStatoServizio.NonAttivo

        End Sub

    End Class

    Friend Class IntervalloOrario
        'Inherits FormerService

        Public Shared Sub ArchiviazionePreventivi()

            LogMe("***ARCHIVIAZIONE PREVENTIVI***")

            Dim Ris As Integer = 0
            Dim CounterOrdini As Integer = 0

            Using mgr As New OrdiniDAO

                Dim AnnoRiferimento As Integer = 0
                Dim MeseRiferimento As Integer = 0
                Dim DataRiferimento As Date = Now.Date.AddDays(-7) ' Now.Date.AddMonths(-1) 'torna a un mese prima
                AnnoRiferimento = DataRiferimento.Year
                MeseRiferimento = DataRiferimento.Month


                Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdConsProgrammata desc"},
                                                   New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.PagatoInteramente),
                                                   New LUNA.LunaSearchParameter(LFM.Ordine.Preventivo, enSiNo.Si))

                Dim ListR As New List(Of Ricavo)

                Dim ListO As New List(Of Ordine)

                l = l.FindAll(Function(x) DateDiff(DateInterval.Day, x.DataIns, DataRiferimento) > 1)

                For Each O As Ordine In l
                    Dim LavorareSingolo As Boolean = False

                    If Not O.ConsegnaAssociata Is Nothing Then

                        Using C As ConsegnaProgrammata = O.ConsegnaAssociata

                            Dim R As Ricavo = C.ListaDocumenti.Find(Function(x) x.Tipo = enTipoDocumento.Preventivo)

                            If Not R Is Nothing Then

                                'qui ho il preventivo devo vedere se ha un pagamento associato 

                                If R.PagatoInteramente Then
                                    Dim IdCons As Integer = 0

                                    Dim OCont As Integer = R.ListaOrdini.Count
                                    Dim ODaArch As Integer = R.ListaOrdini.FindAll(Function(x) DateDiff(DateInterval.Day, x.DataIns, DataRiferimento) > 1).Count

                                    If OCont = ODaArch Then
                                        For Each Oric As Ordine In R.ListaOrdini
                                            If IdCons = 0 Then
                                                IdCons = Oric.IdCons
                                            Else
                                                If IdCons <> Oric.IdCons Then
                                                    IdCons = 0
                                                    Exit For
                                                End If
                                            End If
                                        Next

                                        If IdCons <> 0 Then
                                            'ok qui devo cancellare il pagamento , il preventivo e tutti gli ordini a preventivo contenuti nel preventivo

                                            If ListR.FindAll(Function(x) x.IdRicavo = R.IdRicavo).Count = 0 Then
                                                ListR.Add(R)

                                            End If
                                        End If
                                    End If

                                    Application.DoEvents()
                                End If
                            Else
                                LavorareSingolo = True
                            End If

                        End Using
                    Else
                        LavorareSingolo = True
                    End If

                    If LavorareSingolo Then
                        ListO.Add(O)
                    End If

                Next

                'ora qui in listR ho la lista dei documetni da cancellare
                Randomize()

                For Each R As Ricavo In ListR.ToList
                    LogMe("Archiviazione Ricavo " & R.IdRicavo)
                    Application.DoEvents()
                    Using t As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

                        Try
                            Dim IsCopyOk As Boolean = False

                            Dim PathF As String = FormerPath.PathArchivioOrdini & R.IdRub & "\"
                            'PathF = PathF.Replace("O:\", "N:\")

                            FormerHelper.File.CreateLongPath(PathF)
                            LogMe("-LAVORO I SORGENTI")
                            For Each o As Ordine In R.ListaOrdini.ToList
                                Application.DoEvents()
                                For Each S As FileSorgente In o.ListaSorgenti.ToList
                                    LogMe("--Lavoro Sorgente '" & S.FilePath & "'")
                                    Dim FileSorgente As String = S.FilePath

                                    'FileSorgente = FileSorgente.ToLower.Replace("z:\", "w:\")

                                    If System.IO.File.Exists(FileSorgente) Then
                                        Dim NomeFile As String = FormerHelper.File.EstraiNomeFile(FileSorgente)
                                        Dim NomeFileDest As String = NomeFile

                                        Dim risPulizia As Match = Regex.Match(NomeFileDest, "^[0-9]{4,6}-[0-9]{5,6}_")
                                        While risPulizia.Success
                                            NomeFileDest = NomeFileDest.Replace(risPulizia.Value, String.Empty)
                                            risPulizia = Regex.Match(NomeFileDest, "^[0-9]{4,6}-[0-9]{5,6}_")
                                        End While

                                        'NomeFileDest = NomeFileDest.Replace(o.IdCom & "-", String.Empty)
                                        'NomeFileDest = NomeFileDest.Replace(o.IdOrd & "_", String.Empty)

                                        risPulizia = Regex.Match(NomeFileDest, "^[0-9]{5,6}_")
                                        While risPulizia.Success
                                            NomeFileDest = NomeFileDest.Replace(risPulizia.Value, String.Empty)
                                            risPulizia = Regex.Match(NomeFileDest, "^[0-9]{5,6}_")
                                        End While

                                        Dim Estensione As String = FormerLib.FormerHelper.File.GetEstensione(NomeFileDest)
                                        NomeFileDest = NomeFileDest.Substring(0, NomeFileDest.Length - Estensione.Length)

                                        Dim Rnd As New Random
                                        NomeFileDest &= Rnd.Next(1000000, 9999999) & "." & Estensione

                                        NomeFileDest.Replace(" ", "_")

                                        Dim DestPath As String = PathF & NomeFileDest

                                        LogMe("---Copio '" & S.FilePath & "' al path '" & DestPath & "'")
                                        FileCopy(FileSorgente, DestPath)
                                    Else
                                        LogMe("---Sorgente '" & S.FilePath & "' non trovato")
                                    End If

                                Next
                            Next

                            IsCopyOk = True

                            If IsCopyOk Then
                                t.TransactionBegin()
                                LogMe("-ELIMINO I PAGAMENTI")
                                Using mgrP As New PagamentiDAO
                                    For Each P As Pagamento In R.ListaPagamenti.ToList
                                        mgrP.Delete(P)
                                    Next
                                End Using

                                Dim IdConsToDelete As Integer = 0

                                For Each o As Ordine In R.ListaOrdini.ToList
                                    LogMe("-LAVORO ORDINE " & o.IdOrd)
                                    Dim IdOrdToLav As Integer = o.IdOrd
                                    IdConsToDelete = o.IdCons
                                    LogMe("--Salvo Ordine Archiviato")
                                    Using OArch As New Archiviato(o)
                                        OArch.Save()
                                    End Using
                                    LogMe("--Cancello sorgenti")

                                    For Each S As FileSorgente In o.ListaSorgenti.ToList

                                        Dim PathToDelete As String = S.FilePath.ToLower '.Replace("z:\", "w:\")

                                        If System.IO.File.Exists(PathToDelete) Then
                                            Try
                                                FI.MgrFormerIO.FileDelete(PathToDelete)
                                            Catch ex As Exception
                                                LogMe("---Errore nella cancellazione del sorgente '" & S.FilePath & "'")
                                            End Try
                                        End If
                                    Next
                                    Using mgrS As New FileSorgentiDAO
                                        mgrS.DeleteByIdOrd(o.IdOrd)
                                    End Using
                                    LogMe("--Cancello ordine")
                                    Using mgrO As New OrdiniDAO
                                        mgrO.Delete(o)
                                    End Using
                                    LogMe("--Sgancio dalla consegna e cancello in caso la consegna")
                                    Using mgrC As New ConsegneProgrammateDAO
                                        mgrC.EliminaOrdineDaConsegna(IdConsToDelete, o.IdOrd)
                                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, IdConsToDelete, "Ordini Archiviati in questa consegna")
                                        mgrC.EliminaConsegnaSeVuota(IdConsToDelete)
                                    End Using

                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrdToLav, "Ordine Archiviato")
                                    CounterOrdini += 1

                                Next

                                LogMe("-ELIMINO LA VOCE DI RICAVO")
                                Using mgrr As New RicaviDAO
                                    mgrr.Delete(R)
                                End Using
                                Ris += 1
                                t.TransactionCommit()
                            End If

                        Catch ex As Exception
                            t.TransactionRollBack()
                            LogMe("Errore nell'archiviazione ordini",, ex)
                        End Try

                    End Using
                    'Exit For
                    LogMe("Archiviazione Ricavo " & R.IdRicavo & " TERMINATA")
                Next

                For Each O As Ordine In ListO.ToList

                    Using t As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

                        Try
                            Dim IsCopyOk As Boolean = False
                            Dim PathF As String = FormerPath.PathArchivioOrdini & O.IdRub & "\"
                            FormerHelper.File.CreateLongPath(PathF)
                            Application.DoEvents()
                            For Each S As FileSorgente In O.ListaSorgenti.ToList
                                LogMe("--Lavoro Sorgente '" & S.FilePath & "'")
                                Dim FileSorgente As String = S.FilePath

                                'FileSorgente = FileSorgente.ToLower.Replace("z:\", "w:\")

                                If System.IO.File.Exists(FileSorgente) Then
                                    Dim NomeFile As String = FormerHelper.File.EstraiNomeFile(FileSorgente)
                                    Dim NomeFileDest As String = NomeFile

                                    Dim risPulizia As Match = Regex.Match(NomeFileDest, "^[0-9]{4,6}-[0-9]{5,6}_")
                                    While risPulizia.Success
                                        NomeFileDest = NomeFileDest.Replace(risPulizia.Value, String.Empty)
                                        risPulizia = Regex.Match(NomeFileDest, "^[0-9]{4,6}-[0-9]{5,6}_")
                                    End While

                                    'NomeFileDest = NomeFileDest.Replace(o.IdCom & "-", String.Empty)
                                    'NomeFileDest = NomeFileDest.Replace(o.IdOrd & "_", String.Empty)

                                    risPulizia = Regex.Match(NomeFileDest, "^[0-9]{5,6}_")
                                    While risPulizia.Success
                                        NomeFileDest = NomeFileDest.Replace(risPulizia.Value, String.Empty)
                                        risPulizia = Regex.Match(NomeFileDest, "^[0-9]{5,6}_")
                                    End While

                                    Dim Estensione As String = FormerLib.FormerHelper.File.GetEstensione(NomeFileDest)
                                    NomeFileDest = NomeFileDest.Substring(0, NomeFileDest.Length - Estensione.Length)

                                    Dim Rnd As New Random
                                    NomeFileDest &= Rnd.Next(1000000, 9999999) & "." & Estensione

                                    NomeFileDest.Replace(" ", "_")

                                    Dim DestPath As String = PathF & NomeFileDest

                                    LogMe("---Copio '" & S.FilePath & "' al path '" & DestPath & "'")
                                    FileCopy(FileSorgente, DestPath)
                                Else
                                    LogMe("---Sorgente '" & S.FilePath & "' non trovato")
                                End If

                            Next
                            IsCopyOk = True

                            If IsCopyOk Then
                                t.TransactionBegin()
                                Dim IdOrdToLav As Integer = O.IdOrd
                                Dim IdConsToDelete As Integer = O.IdCons

                                LogMe("-LAVORO ORDINE " & IdOrdToLav)

                                LogMe("--Salvo Ordine Archiviato")
                                Using OArch As New Archiviato(O)
                                    OArch.Save()
                                End Using

                                LogMe("--Cancello sorgenti")

                                For Each S As FileSorgente In O.ListaSorgenti.ToList

                                    Dim PathToDelete As String = S.FilePath.ToLower '.Replace("z:\", "w:\")

                                    If System.IO.File.Exists(PathToDelete) Then
                                        Try
                                            FI.MgrFormerIO.FileDelete(PathToDelete)
                                        Catch ex As Exception
                                            LogMe("---Errore nella cancellazione del sorgente '" & S.FilePath & "'")
                                        End Try
                                    End If
                                Next

                                Using mgrS As New FileSorgentiDAO
                                    mgrS.DeleteByIdOrd(O.IdOrd)
                                End Using
                                LogMe("--Cancello ordine")
                                Using mgrO As New OrdiniDAO
                                    mgrO.Delete(O)
                                End Using

                                If IdConsToDelete Then

                                    LogMe("--Sgancio dalla consegna e cancello in caso la consegna")
                                    Using mgrC As New ConsegneProgrammateDAO
                                        mgrC.EliminaOrdineDaConsegna(IdConsToDelete, IdOrdToLav)
                                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, IdConsToDelete, "Ordini Archiviati in questa consegna")
                                        mgrC.EliminaConsegnaSeVuota(IdConsToDelete)
                                    End Using
                                End If
                                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrdToLav, "Ordine Archiviato")
                                CounterOrdini += 1

                                t.TransactionCommit()
                            End If

                        Catch ex As Exception
                            t.TransactionRollBack()
                            LogMe("Errore nell'archiviazione ordini",, ex)
                        End Try
                    End Using
                Next

            End Using

            LogMe("***ARCHIVIATI " & Ris & " PREVENTIVI***")
            LogMe("***ARCHIVIATI " & CounterOrdini & " ORDINI***")

            LogMe("***FINE ARCHIVIAZIONE PREVENTIVI***")
        End Sub

        Public Shared Sub PuliziaLogOperativi()
            LogMe("***PULIZIA LOG OPERATIVI***")

            'prendo tutti i log operativi della giornata e li vado a incastrare nei log di testo

            Using mgr As New LogOperativiDAO

                Dim l As List(Of LogOperativo) = mgr.FindAll(New LUNA.LSO With {.OrderBy = "Quando, IdLog"})

                For Each singVoce In l
                    Select Case singVoce.TipoLog
                        Case enTipoVoceLog.Consegna
                            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
                                Try
                                    tb.TransactionBegin()
                                    FormerLib.FormerLog.ScriviVoceConsegna(singVoce.IdRif, singVoce.Buffer, singVoce.Quando, singVoce.IdOperatore, singVoce.Chiamata1, singVoce.Chiamata2)
                                    Using mgrLO As New LogOperativiDAO
                                        mgrLO.Delete(singVoce.IdLog)
                                    End Using
                                    tb.TransactionCommit()
                                Catch ex As Exception
                                    LogMe("Errore nella eliminazione di un logoperativo",, ex)
                                    tb.TransactionRollBack()
                                End Try
                            End Using

                        Case enTipoVoceLog.Ordine
                            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
                                Try
                                    tb.TransactionBegin()
                                    FormerLib.FormerLog.ScriviVoceOrdine(singVoce.IdRif, singVoce.Buffer, singVoce.Quando, singVoce.Chiamata1, singVoce.Chiamata2)
                                    Using mgrLO As New LogOperativiDAO
                                        mgrLO.Delete(singVoce.IdLog)
                                    End Using
                                    tb.TransactionCommit()
                                Catch ex As Exception
                                    LogMe("Errore nella eliminazione di un logoperativo",, ex)
                                    tb.TransactionRollBack()
                                End Try
                            End Using

                    End Select
                Next

            End Using



            LogMe("***FINE PULIZIA LOG OPERATIVI***")
        End Sub

        Public Shared Sub EsportaCSV()

            Dim PathStart As String = "C:\temp\csv\"
            Dim QueryFile As String = "query.txt"
            Dim CsvFile As String = "ris.csv"

            Dim PathCompleto As String = String.Empty
            Dim PathCsv As String = String.Empty
            Dim PathRis As String = String.Empty

            PathCompleto = PathStart & QueryFile
            PathCsv = PathStart & CsvFile

            Dim BufferSQL As String = String.Empty
            Dim BufferRis As String = String.Empty

            Using F As New StreamReader(PathCompleto)
                BufferSQL = F.ReadToEnd
            End Using


            Dim Table As New DataTable
            Dim Adapter As New SqlDataAdapter(BufferSQL, LUNA.LunaContext.ConnectionString)
            Adapter.Fill(Table)
            Dim line As String = ""
            For Each column As DataColumn In Table.Columns

                'Add the Data rows.
                line &= ",""" & column.ColumnName.ToString() & """"
                'line += vbTab & row(column.ColumnName).ToString()
            Next
            BufferRis &= line.Substring(1) & vbCrLf

            For Each row As DataRow In Table.Rows
                line = ""
                For Each column As DataColumn In Table.Columns
                    'Add the Data rows.
                    line &= ",""" & row(column.ColumnName).ToString() & """"
                    'line += vbTab & row(column.ColumnName).ToString()
                Next
                'Add new line
                BufferRis &= line.Substring(1) & vbCrLf
            Next

            System.IO.File.WriteAllText(PathCsv, BufferRis)


        End Sub

        Public Shared Sub EliminaOrdiniEliminati()
            Dim lOrd As List(Of FW.OrdineWeb) = Nothing
            Using mgr As New FW.OrdiniWebDAO

                lOrd = mgr.FindAll(New FW.LUNA.LSP(FW.LFM.OrdineWeb.Stato, "(" &
                                                   enStatoOrdine.Eliminato & "," &
                                                   enStatoOrdine.InSospeso & "," &
                                                   enStatoOrdine.Rifiutato & ")", "IN"))

            End Using

            'Dim lRubReview As New List(Of Integer)

            For Each OWeb As FW.OrdineWeb In lOrd
                'lavoro ogni singolo ordine online 
                LogMe("Elimino Lavoro Online " & OWeb.IdOrdine)
                Try
                    Dim Eliminare As Boolean = False
                    Dim O As New Ordine

                    If OWeb.IdOrdineInt Then

                        O.Read(OWeb.IdOrdineInt)

                        If O.IdOrd = 0 Then
                            'qui elimino perche dentro nn c'è piu
                            Eliminare = True
                        End If

                        If OWeb.Stato = enStatoOrdine.Eliminato Then
                            If O.Stato = enStatoOrdine.Eliminato Then
                                Eliminare = True
                            End If
                        End If
                    Else
                        Eliminare = True
                    End If

                    If Eliminare Then
                        'qui devo eliminare quello online e anche quello interno
                        Using Mgr As New FW.OrdiniWebDAO
                            Mgr.Delete(OWeb.IdOrdine)
                        End Using
                        LogMe("Eliminato Lavoro Online " & OWeb.IdOrdine)

                        If O.IdOrd AndAlso O.Stato = enStatoOrdine.Eliminato Then
                            Using Mgr As New OrdiniDAO
                                Mgr.Delete(O.IdOrd)
                            End Using
                        End If

                    End If

                Catch ex As Exception
                    LogMe("SORGENTE: EliminaOrdiniEliminati(), Ordine Web: " & OWeb.IdOrdine & " - " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

                End Try
            Next

            lOrd = Nothing
        End Sub

        Public Shared Sub GestioneOrdiniAbbandonati(Optional DataRiferimento As Date = Nothing)

            If DataRiferimento = Date.MinValue Then DataRiferimento = Now.Date
            'FARE GESTIONE ORDINI IN ATTESA FILE

            LogMe("***GESTIONE ORDINI DA PAGARE ABBANDONATI***")
            Try

                'prima invio una mail a quelli con ordini abbandonati 
                'poi cancello quelli a cui ho gia inviato una mail per l'ordine abbandonato

                'PRIMO STEP DA FARE CON I LUNA PARAMETER
                'Sql = "select distinct u.* from utenti u inner join consegne c on u.IdUt = c.idut "
                'Sql &= "where ((c.IdStatoConsegna=" & CInt(enStatoConsegna.InAttesaDiPagamento) & " and c.AlertLevel = " & CInt(AlertLevel) & ") "
                'Sql &= " or (c.idstatoconsegna=" & CInt(enStatoConsegna.Inserito) & " and c.AlertLevel = " & CInt(AlertLevel)
                'Sql &= " and c.idconsegna not in(select idcons from ordini where idcons = c.idconsegna and stato>" & CInt(enStatoOrdine.InAttesaAllegati) & ")"
                'Sql &= " and c.idconsegna not in(select idconsegna from pagamentionline p where p.idconsegna = c.idconsegna))"
                'Sql &= ") and datediff(""d"",c.datainserimento,getdate())>" & ggToCheck

                Using mgr As New FW.ConsegneDAO
                    Dim CounterEmail As Integer = 0
                    Dim ListaUt As New List(Of FW.Utente)
                    Dim DataRif As Date = DataRiferimento.Date.AddDays(-7)
                    Dim l As List(Of FW.Consegna) = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.IdStatoConsegna, "(" & enStatoConsegna.InAttesaDiPagamento & "," & enStatoConsegna.Inserito & "," & enStatoConsegna.InLavorazione & ")", " IN "),
                                                                New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.AlertLevel, enAlertLevelOrdini.Normale),
                                                                New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.DataInserimento, DataRif, "<="),
                                                                New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.IdConsegnaInt, 0))
                    For Each singCons In l
                        If singCons.Modificabile Then
                            If singCons.ListaOrdini.Count Then
                                If ListaUt.FindAll(Function(x) x.IdUt = singCons.IdUt).Count = 0 Then
                                    ListaUt.Add(singCons.Utente)
                                End If
                                singCons.AlertLevel = enAlertLevelOrdini.InviataEmailAvviso
                                singCons.Save()
                            End If

                        End If
                    Next

                    LogMe("Trovati " & ListaUt.Count & " utenti con ordini in attesa livello 0")

                    For Each singUt In ListaUt

                        If singUt.IdRubricaInt <> FormerConst.UtentiSpecifici.IdRubricaInternaFormer Then InviaReminderAUtente(singUt)
                        CounterEmail += 1

                    Next

                    If CounterEmail Then
                        LogMe("Email Inviate:" & CounterEmail)
                    End If

                    'PROCEDURA SOSTITUITA
                    'Using mgr As New FW.UtentiDAO
                    '    Dim CounterEmail As Integer = 0
                    '    Dim l As List(Of FW.Utente) = mgr.ElencoUtentiConOrdiniDaPagare(enAlertLevelOrdini.Normale, 7)
                    '    LogMe("Trovati " & l.Count & " utenti con ordini in attesa livello 0")
                    '    'questi hanno degli ordini in stato ordini da pagare, gli mando una mail sola per utente 
                    '    For Each singUt In l
                    '        'qui gli mando la mail di remind e sposto tutte i suoi ordini in stato InviareMailAvviso
                    '        InviaReminderAUtente(singUt)
                    '        CounterEmail += 1
                    '        Using MgrC As New FW.ConsegneDAO
                    '            MgrC.SetAlertLevelOrdiniDaPagare(singUt.IdUt, enAlertLevelOrdini.Normale, enAlertLevelOrdini.InviataEmailAvviso, 7)
                    '        End Using
                    '    Next
                    '    l = Nothing
                    'End Using



                End Using

                Using mgr As New FW.ConsegneDAO

                    Dim CounterEmail As Integer = 0
                    Dim ListaUt As New List(Of FW.Utente)
                    Dim DataRif As Date = DataRiferimento.Date.AddDays(-15)
                    Dim l As List(Of FW.Consegna) = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.IdStatoConsegna, "(" & enStatoConsegna.InAttesaDiPagamento & "," & enStatoConsegna.Inserito & "," & enStatoConsegna.InLavorazione & ")", " IN "),
                                                                New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.AlertLevel, enAlertLevelOrdini.InviataEmailAvviso),
                                                                New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.DataInserimento, DataRif, "<="),
                                                                New FW.LUNA.LunaSearchParameter(FW.LFM.Consegna.IdConsegnaInt, 0))

                    For Each SingCons In l.ToList
                        Using tb As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox()
                            Try
                                tb.TransactionBegin()
                                If SingCons.Modificabile Then
                                    SingCons.IdStatoConsegna = enStatoConsegna.Eliminata
                                    SingCons.AlertLevel = enAlertLevelOrdini.EliminatoDopoAlert
                                    SingCons.Save()
                                    For Each Lav As FW.OrdineWeb In SingCons.ListaOrdini.ToList
                                        Lav.Stato = enStatoOrdine.Eliminato
                                        Lav.StatoWeb = enStato.NonAttivo
                                        Lav.Save()
                                    Next
                                End If
                                tb.TransactionCommit()
                            Catch ex As Exception
                                tb.TransactionRollBack()
                                LogMe("ERRORE DELETE ORDINI PAGATI ABBANDONATI CONSEGNA ONLINE " & SingCons.IdConsegna, , ex)
                            End Try
                        End Using

                    Next

                End Using

                'If 1 <> 0 Then

                '    l = mgr.ElencoUtentiConOrdiniDaPagare(enAlertLevelOrdini.InviataEmailAvviso, 15)
                '    LogMe("Trovati " & l.Count & " utenti con ordini in attesa livello 1")
                '    'questi sono gli ordini da eliminare
                '    For Each singUt In l
                '        Using tb As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox()
                '            Try
                '                Using mgrC As New FW.ConsegneDAO
                '                    LogMe("Elimino Ordini Abbandonati Utente Online " & singUt.IdUt)
                '                    tb.TransactionBegin()
                '                    mgrC.DeleteOrdiniDaPagare(singUt.IdUt)
                '                    tb.TransactionCommit()
                '                End Using
                '            Catch ex As Exception
                '                tb.TransactionRollBack()
                '                LogMe("ERRORE DELETE ORDINI PAGATI ABBANDONATI UTENTE ONLINE: " & singUt.IdUt, , ex)
                '            End Try
                '        End Using
                '    Next

                '    If CounterEmail Then
                '        LogMe("Email Inviate:" & CounterEmail)
                '    End If

                'End If

            Catch ex As Exception
                LogMe("ERRORE GESTIONE ORDINI DA PAGARE ABBANDONATI", , ex)
            End Try
        End Sub

        Private Shared Sub InviaReminderAUtente(U As FW.Utente)

            Dim M As New My.Templates.MailReminder
            M.U = U
            Dim TestoMail As String = M.TransformText
            FormerHelper.Mail.InviaMail("AVVISO: Alcuni dei tuoi ordini non sono completi e saranno cancellati a breve", TestoMail, U.Email)

        End Sub

        Public Shared Sub AggiornaIndiciRicerca()
            'quando arrivo qui gli indici di ricerca online corrispondono a quello che ho nel db sicuramente devo solo aggiornare i valori del totale
            'perche i prezzi non cambiano di certo
            'per ogni listinobase calcolo il tot venduto e aggiorno gli indici
            LogMe("***AGGIORNAMENTO INDICI RICERCA***")
            Using mgr As New ListinoBaseDAO
                Dim l As List(Of ListinoBase) = mgr.GetAll

                For Each Lb As ListinoBase In l
                    Try
                        Dim TotOrd As Integer = 0
                        Using mgrO As New OrdiniDAO
                            TotOrd = mgrO.NumeroTotaleOrdiniListinoBase(Lb.IdListinoBase)
                        End Using

                        Dim IndRic As FW.IndiceRicerca = Nothing
                        Using mgrIR As New FW.IndiciRicercaDAO
                            IndRic = mgrIR.Find(New FW.LUNA.LunaSearchParameter(FW.LFM.IndiceRicerca.IdListinoBase, Lb.IdListinoBase))
                        End Using
                        If Not IndRic Is Nothing Then
                            IndRic.TotOrdini = TotOrd
                            IndRic.Save()
                        End If
                    Catch ex As Exception
                        LogMe("Errore Aggiornamento Ricerca: " & ex.Message, , ex)
                    End Try
                Next
            End Using
            LogMe("***AGGIORNAMENTO INDICI RICERCA TERMINATO ***")
        End Sub

        'Private Shared Sub CaricaOnlinePdfFatture(IdAzienda As Integer)

        '    'Exit Sub

        '    LogMe("***UPLOAD FATTURE***")
        '    Dim DirFatture As New DirectoryInfo(PathFatture(IdAzienda))
        '    Dim LastUpload As Date = Date.MinValue

        '    If FileIO.FileSystem.FileExists(FileLastUploadFatture) Then
        '        Using r As New StreamReader(FileLastUploadFatture)
        '            LastUpload = r.ReadToEnd
        '        End Using
        '    End If
        '    Dim TotFileCaricati As Integer = 0
        '    For Each F As FileInfo In DirFatture.GetFiles()
        '        Try
        '            Dim IntervalloDallaCreazione As Long = DateDiff(DateInterval.Second, LastUpload, F.LastWriteTime) 'f.creationtime

        '            If IntervalloDallaCreazione > 0 Then
        '                LogMe(" - Lavoro " & F.Name)
        '                'qui va fatto l'upload
        '                Dim PosizionePunto As Integer = F.Name.IndexOf(".")
        '                Dim AnnoDocumento As Integer = F.Name.Substring(0, 4)
        '                Dim NumeroDocumento As Integer = F.Name.Substring(5, PosizionePunto - 4)

        '                LogMe(" - Documento " & NumeroDocumento & " Anno " & AnnoDocumento)
        '                'cerco il documento e da li arrivo alla consegna 
        '                Dim IdConsegna As Integer = 0
        '                Using Mgr As New F.RicaviDAO
        '                    IdConsegna = Mgr.GetIdConsegnaFromFattura(AnnoDocumento, NumeroDocumento, IdAzienda)
        '                End Using
        '                LogMe(" - IdConsegna " & IdConsegna)

        '                If IdConsegna Then
        '                    Dim IdConsOnline As Integer = 0
        '                    Using mgr As New FW.ConsegneDAO
        '                        IdConsOnline = mgr.GetIdConsFromIdInt(IdConsegna)
        '                    End Using
        '                    LogMe(" - IdConsegna Online " & IdConsOnline)

        '                    If IdConsOnline Then
        '                        'il path e' dentro Consegne/IdConsegna/
        '                        Dim PathRemoto As String = "/tipografiaformer.it/consegne/" & IdConsOnline & "/" & F.Name
        '                        Using Ftp As New FTPclient(FtpServer, FtpLogin, FtpPwd)
        '                            LogMe(" - Upload " & F.Name & " su Consegna " & IdConsOnline)

        '                            Try
        '                                Ftp.FtpCreateDirectory("tipografiaformer.it/consegne/" & IdConsOnline)
        '                            Catch ex As Exception

        '                            End Try

        '                            Ftp.Upload(F.FullName, PathRemoto)
        '                            TotFileCaricati += 1

        '                            'Qui mandare email al cliente dando link per scaricarlo direttamente
        '                            Using C As New FormerDALWeb.Consegna
        '                                C.Read(IdConsOnline)
        '                                If C.IdConsegna Then

        '                                    Dim DestEmail As String = String.Empty
        '                                    Using u As New F.VoceRubrica
        '                                        u.Read(C.Utente.IdRubricaInt)
        '                                        DestEmail = u.EmailAmministrativa
        '                                    End Using

        '                                    If DestEmail <> FormerConst.EmailNonDisponibile Then
        '                                        Dim M As New My.Templates.MailFatturaOnline
        '                                        M.C = C
        '                                        Dim TestoMail As String = M.TransformText

        '                                        Dim ccnAddress As String = String.Empty

        '                                        'If Now.Date.Year = 2016 And Now.Date.Month = 5 And Now.Date.Day <= 12 Then
        '                                        '    ccnAddress = "soft@tipografiaformer.it"
        '                                        'End If

        '                                        Try
        '                                            FormerHelper.Mail.InviaMail("Nuova fattura disponibile per il tuo ordine numero " & C.IdConsegna,
        '                                                                        TestoMail,
        '                                                                        DestEmail,,,
        '                                                                        F.FullName,,
        '                                                                        ccnAddress)
        '                                        Catch ex As Exception
        '                                            LogMe(" - Errore invio Mail nuova fattura ",, ex)
        '                                        End Try

        '                                    End If
        '                                End If
        '                            End Using
        '                        End Using
        '                    End If
        '                End If
        '            End If
        '        Catch ex As Exception
        '            LogMe("SORGENTE: UPLOAD FATTURE(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
        '        End Try
        '    Next

        '    Using w As New StreamWriter(FileLastUploadFatture)
        '        w.Write(Now)
        '    End Using
        '    LogMe(" - Caricate: " & TotFileCaricati & " Fatture")
        '    LogMe("***UPLOAD FATTURE TERMINATO***")

        'End Sub

        Public Shared Sub GestioneNewsletter()
            LogMe("***GESTIONE NEWSLETTER***")
            Try
                GestioneUnsubscribe()

                GestioneIscrizioni()

            Catch ex As Exception

            End Try
            LogMe("***GESTIONE NEWSLETTER TERMINATO***")
        End Sub

        Private Shared Sub GestioneIscrizioni()
            LogMe("***ISCRIZIONI NEWSLETTER***")
            Try
                Using mgr As New FW.NewsletterDAO
                    Dim l As List(Of FW.Newsletter) = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.Newsletter.Lavorato, enSiNo.Si, "<>"))
                    For Each singUS In l
                        Try
                            Dim lInt As List(Of VoceRubrica) = Nothing
                            Dim lIntMW As List(Of VoceRubricaMarketing) = Nothing
                            Dim TrovatoAlmenoUno As Boolean = False

                            Using mgrInt As New VociRubricaDAO
                                lInt = mgrInt.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Email, singUS.Email),
                                                      New LUNA.LunaSearchParameter(LFM.VoceRubrica.NoEmail, enSiNo.Si))
                            End Using

                            For Each singUt In lInt
                                singUt.NoEmail = enSiNo.No
                                singUt.Save()
                                TrovatoAlmenoUno = True
                            Next

                            Using mgrInt As New VoceRubricaMarketingDAO
                                lIntMW = mgrInt.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubricaMarketing.Email, singUS.Email),
                                                      New LUNA.LunaSearchParameter(LFM.VoceRubricaMarketing.NoEmail, enSiNo.Si))
                            End Using

                            For Each singUt In lIntMW
                                singUt.NoEmail = enSiNo.No
                                singUt.Save()
                                TrovatoAlmenoUno = True
                            Next

                            If TrovatoAlmenoUno = False Then
                                'qui va inserita una nuova voce in rubrica marketing 
                                Using vRub As New VoceRubricaMarketing
                                    vRub.Email = singUS.Email
                                    vRub.DataAcquisizione = singUS.Quando
                                    vRub.Tipo = enTipoRubrica.Cliente
                                    vRub.Annotazioni = "Iscrizione alla Newsletter dal sito da " & singUS.Ip
                                    vRub.IdUtente = 1
                                    vRub.NoEmail = enSiNo.No
                                    vRub.Save()
                                End Using
                            End If

                            singUS.Lavorato = enSiNo.Si
                            singUS.Save()

                        Catch ex As Exception
                            LogMe("SORGENTE: ISCRIZIONI NEWSLETTER(), Email: " & singUS.Email & " " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
                        End Try
                    Next
                End Using
            Catch ex As Exception
                LogMe("SORGENTE: NEWSLETTER TERMINATO(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try
            LogMe("***ISCRIZIONI NEWSLETTER TERMINATO***")
        End Sub

        Private Shared Sub GestioneUnsubscribe()
            LogMe("***UNSUBSCRIBE***")
            Try
                Using mgr As New FW.UnsubscribeDAO
                    Dim l As List(Of FW.Unsubscribe) = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.Unsubscribe.Lavorato, enSiNo.Si, "<>"))
                    For Each singUS In l
                        Try
                            Dim lInt As List(Of VoceRubrica) = Nothing
                            Dim lIntMW As List(Of VoceRubricaMarketing) = Nothing
                            Using mgrInt As New VociRubricaDAO
                                lInt = mgrInt.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubrica.Email, singUS.Email),
                                                      New LUNA.LunaSearchParameter(LFM.VoceRubrica.NoEmail, enSiNo.Si, "<>"))
                            End Using
                            For Each singUt In lInt
                                singUt.NoEmail = enSiNo.Si
                                singUt.Save()
                            Next
                            Using mgrInt As New VoceRubricaMarketingDAO
                                lIntMW = mgrInt.FindAll(New LUNA.LunaSearchParameter(LFM.VoceRubricaMarketing.Email, singUS.Email),
                                                      New LUNA.LunaSearchParameter(LFM.VoceRubricaMarketing.NoEmail, enSiNo.Si, "<>"))
                            End Using
                            For Each singUt In lIntMW
                                singUt.NoEmail = enSiNo.Si
                                singUt.Save()
                            Next

                            singUS.Lavorato = enSiNo.Si
                            singUS.Save()

                        Catch ex As Exception
                            LogMe("SORGENTE: UNSUBSCRIBE(), Email: " & singUS.Email & " " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
                        End Try
                    Next
                End Using
            Catch ex As Exception
                LogMe("SORGENTE: UNSUBSCRIBE(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try
            LogMe("***UNSUBSCRIBE TERMINATO***")
        End Sub

        Public Shared Sub ReportGiornaliero()
            If Directory.Exists(PathReport) = False Then MkDir(PathReport)

            Dim NomeFilePrevisto As String = PathReport & Now.ToString("yyyyMMdd") & ".htm"

            If System.IO.File.Exists(NomeFilePrevisto) = False Then

                LogMe("***REPORT***")
                Dim buffer As String = String.Empty
                Try
                    Dim DataRif As Date = Now.Date.AddDays(-1)
                    'creo il report e lo invio per email a me e antonio
                    Dim Titolo As String = "Report Tipografiaformer.it: " & StrConv(DataRif.ToString("dddd dd MMMM yyyy"), vbProperCase)
                    buffer &= "<font face=""Segoe UI""><h2>" & Titolo & "</h2>"

                    buffer &= "<h3>PRODUZIONE</h3>"
                    Dim ParamSearch As New FW.LUNA.LunaSearchParameter("CONVERT(varchar(10), DataIns, 112)", DataRif.ToString("yyyyMMdd"))

                    Using mgr As New FW.ReviewDAO
                        Dim l As List(Of FW.Review) = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.Review.Stato, enStatoReview.DaApprovare))

                        buffer &= "Sono presenti <b style=""color:red;"">" & l.Count & "</b> recensioni da approvare<br>"

                    End Using

                    Using mgr As New FW.OrdiniWebDAO
                        Dim L As List(Of FW.OrdineWeb) = mgr.FindAll(ParamSearch,
                                                                    New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.StatoWeb, CInt(enStato.Attivo)),
                                                                    New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.OrdineWeb, 1))

                        buffer &= "Sono stati inseriti <b style=""color:red;"">" & L.Count & "</b> ordini<br>"
                    End Using

                    Using mgr As New FW.UtentiDAO
                        Dim L As List(Of FW.Utente) = mgr.FindAll(ParamSearch)
                        buffer &= "Si sono registrati <b style=""color:red;"">" & L.Count & "</b> nuovi utenti<br>"
                    End Using

                    Using mgr As New FW.OrdiniWebDAO
                        Dim l As List(Of FW.OrdineWeb) = mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.StatoWeb, CInt(enStato.Attivo)),
                                                                     New FW.LUNA.LunaSearchParameter(FW.LFM.OrdineWeb.Stato, CInt(enStatoOrdine.InAttesaAllegati)))
                        l.Sort(Function(x, y) x.DataIns.CompareTo(y.DataIns))
                        buffer &= "Sono presenti <b style=""color:red;"">" & l.Count & "</b> ordini in <b>Attesa di Invio File</b>"
                        If l.Count Then
                            buffer &= " di cui il più vecchio è del <b style=""color:red;"">" & l(0).DataIns.ToString("dd/MM/yyyy") & "</b>"
                        End If
                        buffer &= "<br>"

                        Dim ContOrdConPag As Integer = 0
                        For Each SingOrd In l
                            If SingOrd.ConsegnaAssociata.HaUnPagamento Then
                                ContOrdConPag += 1
                            End If
                        Next

                        If ContOrdConPag Then
                            buffer = "Sono presenti <b style=""color:red;"">" & ContOrdConPag & "</b> ordini in <b>Attesa di Invio File GIA PAGATI</b> " & buffer
                        End If

                    End Using

                    Using mgr As New FW.UtentiDAO
                        Dim l As List(Of FW.Utente) = mgr.FindAll(New FW.LUNA.LunaSearchParameter("CONVERT(varchar(10), LastLogin, 112)", DataRif.ToString("yyyyMMdd")))

                        buffer &= "Oggi sono entrati nel sito <b style=""color:red;"">" & l.Count & "</b> nostri clienti diversi.<br>"
                    End Using


                    buffer &= "<h3>AMMINISTRAZIONE</h3>"

                    Dim CheckOk As Boolean = True

                    Dim r As RisCheckFinanziario = MgrCheckFinanziario.GetSituation

                    If r.NonInCodaPerInvio Then
                        buffer &= "Sono presenti <b style=""color:red;"">" & r.NonInCodaPerInvio & "</b> documenti fiscali <b>NON IN CODA PER L'INVIO</b><br>"
                        CheckOk = False
                    End If

                    If r.NonInCodaPerInvio9Giorni Then
                        buffer &= "Sono presenti <b style=""color:red;"">" & r.NonInCodaPerInvio9Giorni & "</b> documenti fiscali <b>NON IN CODA PER L'INVIO DA ALMENO 9 GIORNI</b><br>"
                        CheckOk = False
                    End If

                    If r.Scartati Then
                        buffer &= "Sono presenti <b style=""color:red;"">" & r.Scartati & "</b> documenti fiscali <b>SCARTATI DA SDI</b><br>"
                        CheckOk = False
                    End If

                    If r.InCodaInvioDaOltre3Giorni Then
                        buffer &= "Sono presenti <b style=""color:red;"">" & r.InCodaInvioDaOltre3Giorni & "</b> documenti fiscali <b>IN CODA PER INVIO DA + DI 3 GIORNI</b><br>"
                        CheckOk = False
                    End If

                    If r.InviatiSDIDaOltre5Giorni Then
                        buffer &= "Sono presenti <b style=""color:red;"">" & r.InviatiSDIDaOltre5Giorni & "</b> documenti fiscali <b>INOLTRATI A SDI DA + DI 5 GIORNI</b><br>"
                        CheckOk = False
                    End If

                    'Using mgr As New F.RicaviDAO
                    '    Dim l As List(Of F.Ricavo) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.StatoFE, enStatoFatturaFE.DaInviare),
                    '                                             New LUNA.LunaSearchParameter("year(DataRicavo)", 2019, ">="),
                    '                                             New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.DDT & "," & enTipoDocumento.NotaDiDebito & "," & enTipoDocumento.Preventivo & ")", "NOT IN"))

                    '    If l.Count Then
                    '        buffer &= "Sono presenti <b style=""color:red;"">" & l.Count & "</b> documenti fiscali <b>NON IN CODA PER L'INVIO</b><br>"
                    '        CheckOk = False
                    '    End If

                    '    l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.StatoFE, enStatoFatturaFE.ScartataSDI),
                    '                    New LUNA.LunaSearchParameter("year(DataRicavo)", 2019, ">="),
                    '                    New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.DDT & "," & enTipoDocumento.NotaDiDebito & ")", "NOT IN"))

                    '    If l.Count Then
                    '        buffer &= "Sono presenti <b style=""color:red;"">" & l.Count & "</b> documenti fiscali <b>SCARTATI DA SDI</b><br>"
                    '        CheckOk = False
                    '    End If

                    '    l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ricavo.StatoFE, enStatoFatturaFE.InoltrataDest),
                    '                    New LUNA.LunaSearchParameter("year(DataRicavo)", 2019, ">="),
                    '                    New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.DDT & "," & enTipoDocumento.NotaDiDebito & ")", "NOT IN"))

                    '    If l.Count Then
                    '        Dim TotaleSbagliati As Integer = 0
                    '        For Each doc In l
                    '            Dim DiffGiorni As Integer = DateDiff(DateInterval.Day, doc.DataOraInvio.Date, Now.Date)
                    '            If DiffGiorni > 4 Then
                    '                TotaleSbagliati += 1
                    '            End If
                    '        Next

                    '        If TotaleSbagliati Then
                    '            buffer &= "Sono presenti <b style=""color:red;"">" & TotaleSbagliati & "</b> documenti fiscali <b>INOLTRATI A SDI DA + DI 5 GIORNI</b><br>"
                    '            CheckOk = False
                    '        End If

                    '    End If


                    'End Using

                    If CheckOk Then
                        buffer &= "Nessun problema riscontrato<br>"
                    End If

                    buffer &= "</font>"

                    Using w As New StreamWriter(NomeFilePrevisto, False)

                        w.Write(buffer)

                    End Using

                    Dim Destinatari As String = FormerConst.EmailAssistenzaTecnica & ";tipografia.duca@gmail.com"

                    FormerHelper.Mail.InviaMail(Titolo, buffer, Destinatari)

                Catch ex As Exception
                    LogMe("SORGENTE: REPORT(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

                End Try

                LogMe("***REPORT TERMINATO***")

            End If
        End Sub

        Public Shared Sub LavoraPdfFattureGiaCreate()

            Dim d As New DirectoryInfo(FormerPath.PathFattureTemp)
            Try
                If d.GetFiles("*.pdf").Count Then
                    LogMe("Lavoro fatture già create in folder TEMP")
                End If
                For Each f As FileInfo In d.GetFiles("*.pdf")
                    LogMe(" - Lavoro File Fattura Temp " & f.Name)
                    LavoraPDFFatturaTemp(f.Name, f.FullName)
                Next
            Catch ex As Exception

            End Try
        End Sub

        Private Shared Sub LavoraPDFFatturaTemp(FileName As String, FullName As String)
            'l'evento si scatena al momento in cui un file viene creato nella cartella TEMP DELLA STAMPA FATTURE

            'vedo se compatibile con una  regular expression

            Dim PatternReg As String = "^[0-9]{1}_[0-9]{4}-[0-9]{1,10}.pdf$"

            Dim Re As New RegularExpressions.Regex(PatternReg) '.{0,7}

            If Re.IsMatch(FileName) Then
                'qui è una fattura da spostare 
                Dim IdAzienda As Integer = FileName.Substring(0, 1)
                Dim NuovoNome As String = FormerConfig.FormerPath.PathFatture(IdAzienda)
                Dim NuovoNomeFile As String = NuovoNome & FileName.Substring(2)

                Try
                    So.File.Copy(FullName, NuovoNomeFile, True)

                    'Try
                    '    File.Delete(e.FullPath)
                    'Catch ex As Exception

                    'End Try

                Catch ex As Exception

                End Try

                Try
                    So.File.Delete(FullName)

                    'Try
                    '    File.Delete(e.FullPath)
                    'Catch ex As Exception

                    'End Try

                Catch ex As Exception

                End Try


            End If
        End Sub

        Private Shared Function ComparerVR(ByVal x As IVoceRubricaG, ByVal y As IVoceRubricaG) As Integer
            Dim result As Integer = y.ProvenienzaVoce.CompareTo(x.ProvenienzaVoce)
            If result = 0 Then result = x.NominativoG.CompareTo(y.NominativoG)

            Return result
        End Function

        Public Shared Sub DownloadLog(Optional DataRiferimento As Date = Nothing)

            If DataRiferimento = Date.MinValue Then DataRiferimento = Now.Date

            LogMe("***DOWNLOAD LOG***")
            Try
                If Postazione.Network.ConnessioneInternetDisponibile Then
                    Using Ftp As New FTPclient(FtpServer, FtpLogin, FtpPwd)
                        Dim DataRif As Date = DataRiferimento.AddDays(-1)
                        Dim NomeFileLog As String = DataRif.ToString("yyyyMMdd") & ".txt"
                        Dim PathRemotoFile As String = "/tipografiaformer.it/public/log/" & NomeFileLog
                        Dim PathLocaleFile As String = PathLogWeb & NomeFileLog

                        If System.IO.File.Exists(PathLocaleFile) = False Then
                            Ftp.Download(PathRemotoFile, PathLocaleFile, True)
                        End If
                        LogMe("Scaricato file log: " & NomeFileLog)
                    End Using
                    'Else
                    '    Throw New Exception("Connessione Internet Non disponibile")
                End If
            Catch ex As Exception
                LogMe("ERRORE DOWNLOAD LOG " & ex.Message, , ex)
            End Try
            LogMe("***DOWNLOAD LOG TERMINATO***")

        End Sub

        Public Shared Sub PulisciDB()
            LogMe("***PULIZIA DB***")
            Try

                Dim Sql As String = "DELETE FROM T_VociFat WHERE IdDoc NOT IN (SELECT idricavo FROM t_contabricavi)"

                Using myCommand As DbCommand = LUNA.LunaContext.Connection.CreateCommand
                    myCommand.CommandText = Sql
                    If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                    myCommand.ExecuteNonQuery()

                    Sql = "DELETE FROM T_Commesse WHERE IdCom NOT IN (SELECT DISTINCT IdCom FROM t_Ordini)"
                    myCommand.CommandText = Sql
                    myCommand.ExecuteNonQuery()

                    Sql = "DELETE FROM T_CommesseCrono WHERE IdCom NOT IN (SELECT IdCom FROM T_Commesse)"
                    myCommand.CommandText = Sql
                    myCommand.ExecuteNonQuery()

                    Sql = "DELETE FROM T_OrdiniCrono WHERE IdOrd NOT IN (SELECT IdOrd FROM t_Ordini)"
                    myCommand.CommandText = Sql
                    myCommand.ExecuteNonQuery()

                    Sql = "DELETE FROM T_LavLog  WHERE IdOrd <>0 AND IdOrd NOT IN (SELECT IdOrd FROM t_Ordini)"
                    myCommand.CommandText = Sql
                    myCommand.ExecuteNonQuery()

                    Sql = "DELETE FROM T_LavLog  WHERE IdCom <>0 AND IdCom NOT IN (SELECT IdCom FROM T_Commesse)"
                    myCommand.CommandText = Sql
                    myCommand.ExecuteNonQuery()

                    Sql = "DELETE FROM T_Prodotti WHERE IdProd NOT IN (SELECT distinct IdProd FROM T_Ordini)"
                    myCommand.CommandText = Sql
                    myCommand.ExecuteNonQuery()

                    Sql = "DELETE FROM TR_ConsOrd WHERE IdOrd NOT IN (SELECT IdOrd FROM t_Ordini)"
                    myCommand.CommandText = Sql
                    myCommand.ExecuteNonQuery()

                    Sql = "DELETE FROM TR_ConsOrd WHERE IdCons NOT IN (SELECT IdCons FROM T_Cons)"
                    myCommand.CommandText = Sql
                    myCommand.ExecuteNonQuery()
                End Using

            Catch ex As Exception
                LogMe("ERRORE PULIZIA DB " & ex.Message, , ex)
            End Try
            LogMe("***PULIZIA DB TERMINATO***")
        End Sub

        Public Shared Sub CompletamentoConsegne(Optional DataRiferimento As Date = Nothing)

            If DataRiferimento = Date.MinValue Then DataRiferimento = Now.Date

            Try
                LogMe("***SPOSTAMENTO CONSEGNE REGISTRATE CON CORRIERE***")

                Using mgr As New ConsegneProgrammateDAO



                    Dim l As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.RegistrataCorriere),
                                                                        New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Giorno, DataRiferimento, "<="))

                    For Each singcons In l
                        If singcons.Diritti.PossoPosticipareGiorno.Esito Then '.Blocco = enSiNo.No Then'****COMMENTATO PER ESCLUSIONE BLOCCO DIRETTO
                            If singcons.ListaOrdini.FindAll(Function(x) x.Stato > enStatoOrdine.ProntoRitiro).Count = 0 Then
                                Dim DataNuova As Date = DataRiferimento
                                DataNuova = MgrDataConsegna.GetPrimaDataDisponibile(DataNuova, singcons.IdCorr)
                                singcons.Giorno = DataNuova
                                singcons.LastUpdate = enSiNo.Si
                                singcons.Save()
                            End If
                        End If
                    Next

                End Using

                LogMe("***SPOSTAMENTO CONSEGNE REGISTRATE CON CORRIERE TERMINATO***")

            Catch ex As Exception
                LogMe("SORGENTE: Spostamento Consegne() REGISTRATE CON CORRIERE , " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try

            Try
                LogMe("***SPOSTAMENTO CONSEGNE***")
                Using TB As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Using mgr As New OrdiniDAO

                        Dim lstOrdSganciare As List(Of Ordine) = mgr.ListaOrdiniConsegnaOggiDaSpostare()
                        LogMe("Trovati " & lstOrdSganciare.Count & " ordini da spostare")

                        For Each Ord As Ordine In lstOrdSganciare
                            LogMe("Lavoro Ordine " & Ord.IdOrd)

                            If MgrFormerException.SpostareOrdineSeConsegnaNonAncoraCompleta(Ord) Then
                                Dim OkSpostamento As Boolean = True

                                If Not Ord.ConsegnaAssociata Is Nothing Then

                                    If Ord.ConsegnaAssociata.Diritti.PossoPosticipareGiorno.Esito = False Then 'ModificabileEx(True, False, False, True, False, True).Modificabile = False Then
                                        OkSpostamento = False
                                        LogMe("L' Ordine " & Ord.IdOrd & " ha una consegna non modificabile")
                                    End If

                                End If

                                If OkSpostamento Then

                                    Dim DataNuova As Date = DataRiferimento
                                    Dim IdCorrAss As Integer = Ord.ConsegnaAssociata.IdCorr

                                    DataNuova = MgrDataConsegna.GetPrimaDataDisponibile(DataNuova, IdCorrAss)

                                    LogMe("Ordine " & Ord.IdOrd & " pronto per lo spostamento al " & DataNuova.ToString("dd/MM/yyyy"))

                                    Try
                                        'LogMe("Creazione Transazione")
                                        TB.TransactionBegin()
                                        'LogMe("Transazione Creata")
                                        Dim IdOldCons As Integer = Ord.IdCons
                                        'Dim IdPagamentoSel As Integer = Ord.ConsegnaAssociata.IdPagam
                                        ' LogMe("Elimino ordine da consegna vecchia")
                                        Dim c As ConsegnaProgrammata
                                        Using mgrC As New ConsegneProgrammateDAO
                                            'TOLTO IL 08/04/2015
                                            'mgrC.EliminaOrdineDaConsegna(IdOldCons, Ord.IdOrd)
                                            'LogMe("Registro ordine su consegna nuova")
                                            c = mgrC.RegistraConsegnaOrdineSuGiorno(Ord.IdOrd,
                                                                                    Ord.IdCorriere,
                                                                                    DataNuova,
                                                                                    Ord.IdRub,
                                                                                    enMomentoConsegna.Pomeriggio,
                                                                                    Ord.IdIndirizzo)
                                            'LogMe("Elimino consegna vecchia se vuota")
                                            'TOLTO IL 08/04/2015
                                            'mgrC.EliminaConsegnaSeVuota(IdOldCons)
                                        End Using
                                        'LogMe("Commit Transazione")
                                        TB.TransactionCommit()
                                        LogMe("Spostato Ordine " & Ord.IdOrd & " su Consegna " & c.IdCons)
                                    Catch ex As Exception
                                        TB.TransactionRollBack()
                                        LogMe("ERRORE SPOSTAMENTO CONSEGNA ORDINE " & ex.Message, , ex)
                                    End Try
                                End If
                            End If



                        Next

                    End Using
                End Using

                LogMe("***SPOSTAMENTO CONSEGNE TERMINATO***")

            Catch ex As Exception
                LogMe("SORGENTE: Spostamento Consegne(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

            End Try                    'qui prendo tutti gli ordini che erano inconsegna oggi e che sono ins tato minore di uscito da magazzino

            Try
                'UN GIORNO QUESTA FUNZIONE SPARISCE 
                LogMe("***COMPLETAMENTO CONSEGNE***")
                Dim IdConsChius As New List(Of Integer)

                'prendo tutti gli ordin iin stato in consegna prima di X giorni a seconda del corriere della consegna e 
                'li metto a consegnato spostando anche la relativa consegna
                Dim ggCorrFormer As Integer = 3
                Dim ggAltroCorriere As Integer = 7

                Using mgr As New OrdiniDAO
                    Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DataIns Desc"},
                                                       New LUNA.LunaSearchParameter("Stato", enStatoOrdine.InConsegna))

                    'l = l.FindAll(Function(x) Not x.ConsegnaAssociata Is Nothing AndAlso _
                    '                  (DateDiff(DateInterval.Day, x.ConsegnaAssociata.Giorno, DataRiferimento) > ggCorrFormer And x.ConsegnaAssociata.IdStatoConsegna < enStatoConsegna.Consegnata))
                    l = l.FindAll(Function(x) Not x.ConsegnaAssociata Is Nothing)

                    For Each O As Ordine In l

                        If IdConsChius.FindAll(Function(x) x = O.IdCons).Count = 0 Then
                            Dim Diff As Integer = DateDiff(DateInterval.Day, O.ConsegnaAssociata.Giorno, DataRiferimento)
                            'questa consegna non e' stata gia trattata
                            If O.ConsegnaAssociata.IdCorr = enCorriere.GLS Or
                           O.ConsegnaAssociata.IdCorr = enCorriere.GLSIsole Or
                           O.ConsegnaAssociata.IdCorr = enCorriere.PortoAssegnatoGLS Then

                                Dim CodTrack As String = O.ConsegnaAssociata.CodTrack.Trim(" ")

                                If CodTrack.Length Then
                                    'qui devo fare il tracking della consegna
                                    Dim StatoSped As String = MgrTraceCorriere.GetStatoConsegnaStrFromOnline(CodTrack)
                                    If StatoSped.ToLower.Trim(" ") = "consegnato" Then
                                        mgr.InserisciLog(O.IdOrd, enStatoOrdine.Consegnato)
                                        If IdConsChius.FindAll(Function(x) x = O.ConsegnaAssociata.IdCons).Count = 0 Then
                                            IdConsChius.Add(O.ConsegnaAssociata.IdCons)
                                        End If
                                    End If
                                Else
                                    'qui il codice track non c'e' aspetto cmq i giorni previsti per portarlo avanti 
                                    If Diff > ggAltroCorriere Then
                                        mgr.InserisciLog(O.IdOrd, enStatoOrdine.Consegnato)
                                        If IdConsChius.FindAll(Function(x) x = O.ConsegnaAssociata.IdCons).Count = 0 Then
                                            IdConsChius.Add(O.ConsegnaAssociata.IdCons)
                                        End If
                                    End If
                                End If
                            Else
                                'questo andra tolto nel momento in cui finisco la funzione del gestionale da cui loro possono segnalre cosa hanno consegnato
                                If O.ConsegnaAssociata.Corriere.IdCorriere = enCorriere.TipografiaFormer Or
                               O.ConsegnaAssociata.Corriere.IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then
                                    If Diff > ggCorrFormer Then
                                        mgr.InserisciLog(O.IdOrd, enStatoOrdine.Consegnato)
                                        If IdConsChius.FindAll(Function(x) x = O.ConsegnaAssociata.IdCons).Count = 0 Then
                                            IdConsChius.Add(O.ConsegnaAssociata.IdCons)
                                        End If
                                    End If
                                End If

                            End If
                        End If

                    Next
                End Using

                Using mgr As New ConsegneProgrammateDAO
                    Dim l As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.InConsegna),
                                                                    New LUNA.LunaSearchParameter("IdCorr", "(" & enCorriere.GLS & "," & enCorriere.GLSIsole & "," & enCorriere.PortoAssegnatoGLS & ")", "IN"))
                    For Each c As ConsegnaProgrammata In l

                        Dim CodTrack As String = c.CodTrack.Trim(" ")
                        If CodTrack.Length Then
                            Dim StatoSped As String = MgrTraceCorriere.GetStatoConsegnaStrFromOnline(CodTrack)
                            If StatoSped.ToLower.Trim(" ") = "consegnato" Then
                                mgr.AvanzaStatoConsegna(c, enStatoConsegna.Consegnata)
                                LogMe("- Consegna " & c.IdCons & " completata da XML Gls")
                                IdConsChius.Add(c.IdCons)
                            End If
                        Else
                            Dim Diff As Integer = DateDiff(DateInterval.Day, c.Giorno, DataRiferimento)
                            If Diff > ggAltroCorriere Then
                                mgr.AvanzaStatoConsegna(c, enStatoConsegna.Consegnata)
                                IdConsChius.Add(c.IdCons)
                            End If
                        End If
                    Next

                End Using

                LogMe(" - Completate " & IdConsChius.Count & " consegne")
                LogMe("***COMPLETAMENTO CONSEGNE TERMINATO***")
            Catch ex As Exception
                LogMe("SORGENTE: Completamento Consegne(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try

        End Sub

        Public Shared Sub InserimentoMarketingBilanciato(Optional DataRiferimento As Date = Nothing)

            If DataRiferimento = Date.MinValue Then DataRiferimento = Now.Date

            'Preparazione invio mail di marketing
            LogMe("***INSERIMENTO MARKETING BILANCIATO***")
            Try
                Using mgr As New FiltriMarketingDAO
                    Dim l As List(Of FiltroMarketing) = mgr.FindAll(New LUNA.LunaSearchParameter("Stato", enStato.Attivo))

                    Select Case DataRiferimento.Month
                        Case 1
                            l = l.FindAll(Function(x) x.chkGennaio)
                        Case 2
                            l = l.FindAll(Function(x) x.chkFebbraio)
                        Case 3
                            l = l.FindAll(Function(x) x.chkMarzo)
                        Case 4
                            l = l.FindAll(Function(x) x.chkAprile)
                        Case 5
                            l = l.FindAll(Function(x) x.chkMaggio)
                        Case 6
                            l = l.FindAll(Function(x) x.chkGiugno)
                        Case 7
                            l = l.FindAll(Function(x) x.chkLuglio)
                        Case 8
                            l = l.FindAll(Function(x) x.chkAgosto)
                        Case 9
                            l = l.FindAll(Function(x) x.chkSettembre)
                        Case 10
                            l = l.FindAll(Function(x) x.chkOttobre)
                        Case 11
                            l = l.FindAll(Function(x) x.chkNovembre)
                        Case 12
                            l = l.FindAll(Function(x) x.chkDicembre)
                    End Select

                    Dim lVR As List(Of IVoceRubricaG)
                    Using mgrV As New VociRubGDAO
                        lVR = mgrV.GetAllVoceRubG()
                    End Using

                    LogMe("***Filtri da eseguire trovati: " & l.Count)

                    For Each singF In l
                        'qui lavoro ogni singolo filtro che va fatto questo mese
                        Dim lVRSing As New List(Of IVoceRubricaG)
                        Dim PathFile As String = PathTemplate
                        Dim NomeFile As String = String.Empty

                        LogMe("***Filtro da eseguire: " & singF.Nome)

                        Dim IdTemplateMarketing As Integer = 0

                        If singF.TipoFiltro = enTipoFiltroMarketing.SuListiniBase Then
                            'cotruisco il template con i listini base
                            Dim Tm As New TMO

                            Select Case DataRiferimento.Month
                                Case 1
                                    Tm.Read(singF.chkGennaio)
                                Case 2
                                    Tm.Read(singF.chkFebbraio)
                                Case 3
                                    Tm.Read(singF.chkMarzo)
                                Case 4
                                    Tm.Read(singF.chkAprile)
                                Case 5
                                    Tm.Read(singF.chkMaggio)
                                Case 6
                                    Tm.Read(singF.chkGiugno)
                                Case 7
                                    Tm.Read(singF.chkLuglio)
                                Case 8
                                    Tm.Read(singF.chkAgosto)
                                Case 9
                                    Tm.Read(singF.chkSettembre)
                                Case 10
                                    Tm.Read(singF.chkOttobre)
                                Case 11
                                    Tm.Read(singF.chkNovembre)
                                Case 12
                                    Tm.Read(singF.chkDicembre)
                            End Select

                            NomeFile = "NL-" & singF.IdFiltroMarketing & "-" & Tm.IdTmOff & "-" & DataRiferimento.Year & ".htm"
                            PathFile &= NomeFile

                            '03/02/2017 - commento questa riga, il file per il template viene ricreato ogni giorno cosi e' sempre aggiornato 
                            '*************************************
                            'If So.File.Exists(PathFile) = False Then
                            'qui devo creare il file dell'effettivo invio
                            MgrMarketingWeb.PathTarget = PathTemplate
                            MgrMarketingWeb.NomeFile = NomeFile
                            PathFile = MgrMarketingWeb.CreaNewsletterSuListiniBase(Tm.ListaOfferte, Tm, True)
                            'End If
                            '*************************************

                            Using mgrT As New TemplateMarketingDAO
                                'qui cerco il template se e' stato inserito nel db 
                                Dim templ As TemplateMarketing = mgrT.Find(New LUNA.LunaSearchParameter("Path", PathFile))
                                If templ Is Nothing Then
                                    templ = New TemplateMarketing
                                    templ.Path = PathFile
                                    templ.Save()
                                    LogMe("***Template Salvato: " & templ.Path)
                                End If
                                IdTemplateMarketing = templ.IdTemplateMarketing
                            End Using

                        ElseIf singF.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                            'qui uso il template gia riadattato
                            Using t As New TemplateMarketing
                                Select Case DataRiferimento.Month
                                    Case 1
                                        t.Read(singF.chkGennaio)
                                    Case 2
                                        t.Read(singF.chkFebbraio)
                                    Case 3
                                        t.Read(singF.chkMarzo)
                                    Case 4
                                        t.Read(singF.chkAprile)
                                    Case 5
                                        t.Read(singF.chkMaggio)
                                    Case 6
                                        t.Read(singF.chkGiugno)
                                    Case 7
                                        t.Read(singF.chkLuglio)
                                    Case 8
                                        t.Read(singF.chkAgosto)
                                    Case 9
                                        t.Read(singF.chkSettembre)
                                    Case 10
                                        t.Read(singF.chkOttobre)
                                    Case 11
                                        t.Read(singF.chkNovembre)
                                    Case 12
                                        t.Read(singF.chkDicembre)
                                End Select
                                IdTemplateMarketing = t.IdTemplateMarketing
                                PathFile = t.Path
                            End Using

                        End If

                        lVRSing.AddRange(lVR)

                        Using mgrV As New VociRubGDAO

                            LogMe("***Applico filtro a : " & lVRSing.Count)
                            lVRSing = mgrV.ApplicaFiltro(lVRSing, singF, True)
                            lVRSing.Sort(AddressOf ComparerVR)
                            LogMe("***Filtro applicato : " & lVRSing.Count)

                            'qui devo andare a controllare queste voci risultati dal filtro applicato e vedere se 
                            'hanno gia avuto troppe spedizioni in questo mese 

                            Dim lVRSingNew As New List(Of IVoceRubricaG)

                            For Each singVR As IVoceRubricaG In lVRSing

                                Using mgrLM As New LogMarketingDAO

                                    Dim InviiGiaFatti As List(Of LogMarketing) = mgrLM.FindAll(New LUNA.LunaSearchParameter("IdRubG", singVR.IdRubG),
                                                                                               New LUNA.LunaSearchParameter("month(DataIns)", Now.Month),
                                                                                               New LUNA.LunaSearchParameter("year(DataIns)", Now.Year))

                                    If InviiGiaFatti.Count = 0 Then
                                        'qui non ci sono state altre spedizioni nel mese 
                                        lVRSingNew.Add(singVR)

                                        'qui dovrei prende la data di spedizione dell'ulòtima volta a prescinde dalla spedizione perche 
                                        'per questo mese questo non ne ha avuti ma magari l'ha avuti l'ultimo giorno del mese prima
                                        Dim InviiPrecedenti As List(Of LogMarketing) = mgrLM.FindAll("Datains desc", New LUNA.LunaSearchParameter("IdRubG", singVR.IdRubG))

                                        If InviiPrecedenti.Count Then
                                            singVR.DataUltimoInvioNewsletter = InviiPrecedenti(0).DataIns
                                        End If

                                    ElseIf InviiGiaFatti.Count = 1 Then
                                        'qui ci sono state e devo vedere se il filtro usato va o non va bene 
                                        Using llM As LogMarketing = InviiGiaFatti(0)

                                            Using f As New FiltroMarketing
                                                f.Read(llM.IdFm)
                                                If f.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                                                    If singF.TipoFiltro <> enTipoFiltroMarketing.SuFileHtml Then
                                                        singVR.DataUltimoInvioNewsletter = llM.DataSent
                                                        lVRSingNew.Add(singVR)
                                                    End If
                                                ElseIf f.TipoFiltro <> enTipoFiltroMarketing.SuFileHtml Then
                                                    If singF.TipoFiltro = enTipoFiltroMarketing.SuFileHtml Then
                                                        singVR.DataUltimoInvioNewsletter = llM.DataSent
                                                        lVRSingNew.Add(singVR)
                                                    End If
                                                End If
                                            End Using

                                        End Using
                                    ElseIf InviiGiaFatti.Count > 1 Then
                                        'se ci sta piu di un invio gia lo posso scartare 
                                    End If
                                End Using
                            Next

                            'se il filtro produce risultati me li schedulo 
                            If lVRSingNew.Count Then
                                lVRSingNew.Sort(Function(x, y) x.DataUltimoInvioNewsletter.CompareTo(y.DataUltimoInvioNewsletter))
                                If singF.Ricorsiva = enSiNo.Si Then
                                    Dim ggDisp As Integer = DateTime.DaysInMonth(DataRiferimento.Year, DataRiferimento.Month)
                                    Dim ggDiv As Integer = ggDisp - DataRiferimento.Day
                                    If ggDiv = 0 Then ggDiv = 1
                                    Dim CaricoGiorn As Integer = Math.Ceiling(lVRSingNew.Count / ggDiv)
                                    'ora so quanti ne dovrò spedire 
                                    'inserisco i primi tot nella tabella del log da spedire e fine , passo la palla al processo che le invia
                                    Dim VociLavorate As Integer = 0

                                    For Each singVR As IVoceRubricaG In lVRSingNew
                                        VociLavorate += 1

                                        'qui salvo il log di marketing 
                                        Using lm As New LogMarketing
                                            lm.DataIns = DataRiferimento
                                            lm.IdFm = singF.IdFiltroMarketing
                                            lm.IdRubG = singVR.IdRubG
                                            lm.NTent = 0
                                            lm.IdTemplateMarketing = IdTemplateMarketing
                                            lm.Stato = enStatoEmail.DaInviare
                                            lm.Save()
                                        End Using

                                        If VociLavorate = CaricoGiorn Then Exit For
                                    Next
                                Else
                                    'se il filtro non è ricorsivo li invio subito tutti 
                                    For Each singVR As IVoceRubricaG In lVRSingNew
                                        'qui salvo il log di marketing 
                                        Using lm As New LogMarketing
                                            lm.DataIns = DataRiferimento
                                            lm.IdFm = singF.IdFiltroMarketing
                                            lm.IdRubG = singVR.IdRubG
                                            lm.NTent = 0
                                            lm.IdTemplateMarketing = IdTemplateMarketing
                                            lm.Stato = enStatoEmail.DaInviare
                                            lm.Save()
                                        End Using
                                    Next
                                End If

                            End If

                        End Using

                        LogMe("***Filtro eseguito: " & singF.Nome)
                    Next
                End Using
            Catch ex As Exception
                LogMe("SORGENTE: Inserimento Marketing Bilanciato(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try
            LogMe("***INSERIMENTO MARKETING BILANCIATO TERMINATO***")

        End Sub

        Public Shared Sub StartService()

            'controllo che non ho gia eseguito l'operazione 
            Stato = enStatoServizio.Attivo

            LogMe("***Intervallo Orario***")

            Select Case Now.Hour
                Case 0 'REPORT GIORNALIERO


                Case 1 'GESTISCO LA NEWSLETTER
                    ReportGiornaliero()
                    GestioneNewsletter()
                    PromoAutomatici()

                Case 2 'ARCHIVIAZIONE PREVENTIVI
                    ArchiviazionePreventivi()

                Case 3 'MAIL A ORDINI ABBANDONATI
                    GestioneOrdiniAbbandonati()
                    PuliziaLogOperativi()
                    EliminaOrdiniEliminati()
                    BackupDB()

                Case 4 'AGGIORNO GLI INDICI DI RICERCA
                    AggiornaIndiciRicerca()
                    DownloadLog()
                Case 5
                    AgganciaDocumentiFiscalieCarichi()
                Case 6
                    CleanAndMove()
                    PulisciDB()
                Case 7
                Case 8
                Case 9
                Case 11
                    InserimentoMarketingBilanciato()
                Case 21
                    CompletamentoConsegne()
                Case 22
                    InvioFattureFE()
                Case 23
                    BackupIncrementale()
            End Select

            LogMe("***Intervallo Orario TERMINATO***")
            Stato = enStatoServizio.NonAttivo
        End Sub

        Public Shared Sub LegaCostoACarico(ByRef C As Costo,
                                       Optional CreaNuovoCaricoMagazzinoSeMancante As Boolean = False,
                                       Optional CreaNuoveRisorseSeMancanti As Boolean = False,
                                       Optional CreaNuoviMovimentiMagazzinoSeMancanti As Boolean = False)
            LogMe("Tentativo Collegamento COSTO " & C.IdCosto)
            MgrMagazzinoBusiness.LegaCostoACarico(C, , CreaNuovoCaricoMagazzinoSeMancante, CreaNuoveRisorseSeMancanti, CreaNuoviMovimentiMagazzinoSeMancanti)
            'Dim cm As CaricoDiMagazzino = MgrMagazzino.CaricoMagazzinoDaCosto(C, CreaNuoveVociMancanti)

            'If Not cm Is Nothing Then
            '    cm.IdStatoInterno = enStatoFEInterno.Collegato
            '    C.StatoFEInterno = enStatoFEInterno.Collegato

            '    For Each mov In cm.ListaMovimenti
            '        If mov.IdVoceCosto = 0 Then

            '            Dim vc As VoceCosto = C.ListaVociFattura.Find(Function(x) x.Codice = mov.CodiceForn And x.Qta = mov.Qta And cm.ListaMovimenti.FindAll(Function(z) z.IdVoceCosto = x.IdVoceCosto).Count = 0)

            '            If Not vc Is Nothing Then
            '                'qui va agganciata
            '                mov.IdVoceCosto = vc.IdVoceCosto
            '                vc.IdMovMagaz = mov.IdCarMag
            '                mov.IdFat = C.IdCosto
            '                mov.Save()
            '                vc.Save()

            '            Else
            '                'qui non c'e' una riga nella fattura a cui agganciare questo movimento di carico
            '                LogMe("Presenti movimenti di magazzino non trovati in fattura")
            '                cm.IdStatoInterno = enStatoFEInterno.Anomalia
            '                C.StatoFEInterno = enStatoFEInterno.Anomalia
            '            End If
            '        End If
            '    Next

            '    Dim CounterRigheDaValutare As Integer = 0
            '    Dim CounterRigheAgganciate As Integer = 0

            '    For Each riga In C.ListaVociFattura

            '        If FormerException.ValutareRigaFatturaComeRisorsa(riga) Then
            '            CounterRigheDaValutare += 1
            '            If cm.ListaMovimenti.FindAll(Function(x) x.IdVoceCosto = riga.IdVoceCosto).Count <> 0 Then
            '                CounterRigheAgganciate += 1
            '            Else
            '                If CreaNuoveVociMancanti Then
            '                    'questa riga va completamente creata e aggiunta al documento di carico
            '                    'devo prima cercarela risorsa 
            '                    'se non la trovo devo crearla e poi metterla nel carico di magazzino
            '                    LogMe("Riga fattura " & riga.IdVoceCosto & " NON TROVATA")

            '                    Using mgr As New MagazzinoDAO
            '                        Dim MovCampione As MovimentoMagazzino = Nothing
            '                        Dim lMov As List(Of MovimentoMagazzino) = Nothing

            '                        If riga.Codice.Trim.Length Then
            '                            lMov = mgr.FindAll(New LUNA.LunaSearchOption() With {.Top = 1, .OrderBy = ""},
            '                                                                                                          New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.CodiceForn, riga.Codice),
            '                                                                                                          New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdForn, C.IdRub))
            '                            If lMov.Count Then MovCampione = lMov(0)
            '                        End If

            '                        If MovCampione Is Nothing Then
            '                            'tento per descrizione
            '                            If riga.Descrizione.Trim.Length Then
            '                                lMov = mgr.FindAll(New LUNA.LunaSearchOption() With {.Top = 1, .OrderBy = ""},
            '                                                                                                          New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.DescrForn, riga.Descrizione),
            '                                                                                                          New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdForn, C.IdRub))
            '                                If lMov.Count Then MovCampione = lMov(0)
            '                            End If
            '                        End If

            '                        If Not MovCampione Is Nothing Then
            '                            'qui l'ho trovata 

            '                            Using v As New MovimentoMagazzino
            '                                v.IdRis = MovCampione.IdRis
            '                                v.DataMov = C.DataCosto
            '                                v.CodiceForn = MovCampione.CodiceForn
            '                                v.DescrForn = riga.Descrizione
            '                                v.TipoMov = enTipoMovMagaz.Carico
            '                                v.IdForn = MovCampione.IdForn
            '                                v.IdVoceCosto = riga.IdVoceCosto
            '                                v.IdFat = C.IdCosto
            '                                v.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
            '                                v.Qta = riga.Qta
            '                                v.Prezzo = riga.Totale
            '                                v.PrezzoUnit = riga.PrezzoUnit
            '                                v.IdCaricoMagazzino = cm.IdCaricoMagazzino

            '                                v.Save()
            '                            End Using

            '                        Else
            '                            'qui devo proprio creare la risorsa
            '                            Using r As New Risorsa
            '                                r.TipoRis = enTipoProdCom.NonSpecificato
            '                                r.Codice = riga.Codice
            '                                r.Descrizione = riga.Descrizione
            '                                r.Stato = enStato.Attivo
            '                                r.Save()

            '                                Using v As New MovimentoMagazzino
            '                                    v.IdRis = r.IdRis
            '                                    v.DataMov = C.DataCosto
            '                                    v.CodiceForn = riga.Codice
            '                                    v.DescrForn = riga.Descrizione
            '                                    v.TipoMov = enTipoMovMagaz.Carico
            '                                    v.IdForn = C.IdRub
            '                                    v.IdVoceCosto = riga.IdVoceCosto
            '                                    v.IdFat = C.IdCosto
            '                                    v.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
            '                                    v.Qta = riga.Qta
            '                                    v.Prezzo = riga.Totale
            '                                    v.PrezzoUnit = riga.PrezzoUnit
            '                                    v.IdCaricoMagazzino = cm.IdCaricoMagazzino

            '                                    v.Save()
            '                                End Using


            '                            End Using
            '                        End If

            '                    End Using
            '                End If
            '            End If
            '        End If
            '    Next

            '    If CounterRigheAgganciate <> CounterRigheDaValutare Then
            '        LogMe("Trovate anomalie")
            '        C.StatoFEInterno = enStatoFEInterno.Anomalia
            '        cm.IdStatoInterno = enStatoFEInterno.Anomalia
            '    End If

            '    If C.IsChanged Then C.Save()
            '    If cm.IsChanged Then cm.Save()
            'End If
            LogMe("FINE Tentativo Collegamento COSTO " & C.IdCosto)

        End Sub

        Public Shared Sub AgganciaDocumentiFiscalieCarichi()
            LogMe("***AGGANCIA DOCUMENTI FISCALI E CARICHI***")
            Using mgr As New CostiDAO
                Dim l As List(Of Costo) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdCosto"},
                                                  New LUNA.LunaSearchParameter("Year(DataCosto)", 2019, ">="),
                                                  New LUNA.LunaSearchParameter(LFM.Costo.StatoFEInterno, "(" & enStatoFEInterno.Inserito & "," & enStatoFEInterno.Anomalia & ")", "IN"),
                                                  New LUNA.LunaSearchParameter(LFM.Costo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & ")", "IN"))

                'l = l.FindAll(Function(x) x.IdCosto = 6795)
                For Each c In l

                    'If c.Tipo = enTipoDocumento.Fattura OrElse c.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                    If c.IdCat = FormerConst.CategorieContabili.MateriePrime Then
                        If c.ListaVociFattura.Count Then
                            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                                Try

                                    If c.Tipo = enTipoDocumento.FatturaRiepilogativa Then
                                        'qui vado a cercare o salvare il documento di carico dei ddt

                                        For Each DDT In c.ListaDocumenti
                                            tb.TransactionBegin()
                                            If DDT.ListaVociFattura.Count Then LegaCostoACarico(DDT,,, True) ', True)
                                            tb.TransactionCommit()
                                        Next
                                        tb.TransactionBegin()
                                        LegaCostoACarico(c,,, True) '? la lancio pure sulla fattura se ha delle righe 
                                        tb.TransactionCommit()

                                        Dim cTest As New Costo
                                        cTest.Read(c.IdCosto)

                                        Dim proxStato As enStatoFEInterno = cTest.StatoFEInterno
                                        If cTest.ListaDocumenti.FindAll(Function(x) x.StatoFEInterno <> enStatoFEInterno.Collegato).Count = 0 Then
                                            proxStato = enStatoFEInterno.Collegato
                                            For Each riga In c.ListaVociFatturaOnlyThis

                                                If MgrFormerException.ValutareRigaFatturaComeRisorsa(riga) = True AndAlso riga.IdMovMagaz = 0 Then
                                                    proxStato = enStatoFEInterno.Anomalia
                                                    Exit For
                                                End If
                                            Next
                                        End If
                                        cTest.StatoFEInterno = proxStato
                                        cTest.Save()



                                    ElseIf c.Tipo = enTipoDocumento.Fattura Then
                                        'qui vado a cercare o salvare il documento di carico della fattura
                                        tb.TransactionBegin()
                                        LegaCostoACarico(c,,, True) ', True)
                                        tb.TransactionCommit()
                                    End If

                                Catch ex As Exception
                                    tb.TransactionRollBack()
                                    LogMe("Errore collegamento COSTO " & c.IdCosto,, ex)
                                End Try

                            End Using
                        End If
                    End If

                    'End If

                Next
            End Using
            LogMe("***FINE AGGANCIA DOCUMENTI FISCALI E CARICHI***")

            LogMe("***ELIMINA CARICHI DDT/FATTURE IN ANTICIPO***")
            Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                Using mgr As New CarichiDiMagazzinoDAO
                    Dim l As List(Of CaricoDiMagazzino) = mgr.FindAll(New LUNA.LSP(LFM.CaricoDiMagazzino.IdStatoInterno, enStatoFEInterno.Collegato))

                    For Each voce In l
                        'qui lo scollego dal documento e lo elimino senza eliminare i carichi 
                        If Not voce.CostoRiferimento Is Nothing Then
                            LogMe("SCOLLEGO CARICO " & voce.IdCaricoMagazzino & " da COSTO " & voce.CostoRiferimento.IdCosto & ")")

                            Try
                                tb.TransactionBegin()
                                voce.CostoRiferimento.IdCaricoMagazzino = 0
                                voce.CostoRiferimento.Save()

                                For Each movimento In voce.ListaMovimenti
                                    movimento.IdCaricoMagazzino = 0
                                    movimento.Save()
                                Next
                                mgr.Delete(voce.IdCaricoMagazzino)
                                tb.TransactionCommit()
                            Catch ex As Exception
                                tb.TransactionRollBack()
                                LogMe("ERRORE SCOLLEGAMENTO CARICO " & voce.IdCaricoMagazzino & " da COSTO " & voce.CostoRiferimento.IdCosto & ")",, ex)
                            End Try

                        End If
                    Next

                End Using
            End Using

            LogMe("***FINE ELIMINA CARICHI DDT/FATTURE IN ANTICIPO***")
        End Sub

        Public Shared Sub BackupDB()
            LogMe("***Backup DB***")
            Try

                Using C As Data.IDbCommand = LUNA.LunaContext.Connection.CreateCommand
                    'IL C IN QUESTIONE E' QUELLO DEL SERVER
                    Dim Giorno As String = Now.Date.ToString("yyyy-MM-dd") & ".bak"

                    If IO.File.Exists("E:\bkp\" & Giorno) = False Then
                        Dim sql As String = "BACKUP DATABASE [FormerSql] TO DISK = N'C:\Lavoro\" & Giorno & "' WITH INIT , NOUNLOAD , NAME = N'FormerSqlBackup', NOSKIP , STATS = 10, NOFORMAT"
                        C.CommandText = sql
                        C.ExecuteNonQuery()
                        'IL B IN QUESTIONE E' LA CARTELLA LAVORO SUL SERVER CONDIVISA SUL DEMONE
                        IO.File.Copy("B:\" & Giorno, "E:\bkp\" & Giorno)
                        'cancello il file creato
                        IO.File.Delete("B:\" & Giorno)
                    End If

                End Using

            Catch ex As Exception
                LogMe("SORGENTE: BackupDB(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

            End Try
            LogMe("***Backup DB TERMINATO***")
        End Sub

        Public Shared Sub PromoAutomatici()

            'GESTIONE PROMO AUTOMATICI
            LogMe("***PROMO AUTOMATICI***")

            Try

                Dim TotalePromo As Integer = 10
                'Dim Primi As Integer = 5

                'Dim ListaIdLbAttiviSuPromo As New List(Of Integer)

                LogMe("Eliminazione promo esistenti ONLINE scaduti")

                Using Mgr As New FW.PromoWDAO
                    Dim l As List(Of FW.PromoW) = Mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.PromoW.Automatico, enSiNo.Si))
                    For Each p As FW.PromoW In l

                        Dim DiffGiorni As Integer = DateDiff(DateInterval.Minute, Now, p.DataFineValidita)

                        If DiffGiorni < 0 Then
                            'qui vanno eliminati
                            Mgr.Delete(p.IdPromo)
                        End If

                    Next
                End Using

                LogMe("Eliminazione promo esistenti")

                Using Mgr As New PromoDAO
                    Dim l As List(Of Promo) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Promo.Automatico, enSiNo.Si))
                    For Each p As Promo In l

                        'ListaIdLbAttiviSuPromo.Add(p.IdListinoBase)
                        Dim DiffGiorni As Integer = DateDiff(DateInterval.Minute, Now, p.DataFineValidita)

                        If DiffGiorni < 0 Then
                            'qui elimino i vecchi promo sia offline che online
                            LogMe("Eliminazione promo interno " & p.IdPromo & " (online " & p.IdPromoOnline & ")")
                            Using MgrW As New FW.PromoWDAO
                                MgrW.Delete(p.IdPromoOnline)
                            End Using
                            Mgr.Delete(p)
                        End If

                    Next
                End Using

                Dim ListaPromoAttivi As List(Of Promo) = Nothing
                Dim ListaPromoAttiviOnline As List(Of FW.PromoW) = Nothing

                Using Mgr As New PromoDAO
                    ListaPromoAttivi = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Promo.Automatico, enSiNo.Si))
                End Using

                Using Mgr As New FW.PromoWDAO
                    ListaPromoAttiviOnline = Mgr.FindAll(New FW.LUNA.LunaSearchParameter(FW.LFM.PromoW.Automatico, enSiNo.Si))
                End Using

                Dim ListaFinale As New List(Of RisPromoSuLB)
                Dim lPAttiviAlMomento As New List(Of RisPromoSuLB)

                Using Mgr As New ListinoBaseDAO

                    Dim l As List(Of ListinoBase) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ListinoBase.PercPromoAutomatico, 0, "<>"),
                                                                New LUNA.LSP(LFM.ListinoBase.AttivaPromoAutomatico, enSiNo.Si))

                    Dim lP As New List(Of RisPromoSuLB)

                    For Each singL As ListinoBase In l

                        Dim lbP As New RisPromoSuLB(singL)

                        lbP.FatturatoMensileTotale = Mgr.GetFatturatoNelMese(lbP.IdListinoBase)
                        lbP.FatturatoMensileConPromo = Mgr.GetFatturatoNelMese(lbP.IdListinoBase,,, True)
                        'MessageBox.Show(lbP.PercentualeSuFatturato)

                        lP.Add(lbP)

                    Next

                    lPAttiviAlMomento.AddRange(lP)

                    'prendo tutti quelli sotto fatturato
                    lP = lP.FindAll(Function(xx) xx.PercentualeSuFatturato < xx.ListinoBase.PercMaxPromoFatturato)

                    LogMe("Promo automatici validi per l'inserimento: " & lP.Count)

                    'qui ho la lista dei promo attivi con i conteggi. 
                    If lP.Count <= TotalePromo Then
                        'se sono meno di 10 qui li inserisco tutti 
                        ListaFinale.AddRange(lP)
                    Else
                        'qui devo andare a scegliere

                        'ordino in base a quelli con meno fatturatomensile
                        lP.Sort(AddressOf FormerListSorter.PromoSorter.ComparerSceltaProssimi)

                        'Dim Primi As Integer = 5

                        'If lP.Count < 5 Then Primi = lP.Count

                        'For i As Integer = 1 To Primi
                        '    'qui inserisco i primi x
                        '    ListaFinale.Add(lP(i))

                        '    '                    ListaIdLbAttiviSuPromo.Remove(lP(i).IdListinoBase)

                        'Next

                        'For i As Integer = 1 To Primi
                        '    lP.RemoveAt(0)
                        'Next

                        'metto gli altri 

                        For Each singRis In lP
                            If ListaFinale.Count = TotalePromo Then Exit For

                            If ListaFinale.FindAll(Function(x) x.IdListinoBase = singRis.IdListinoBase).Count = 0 Then
                                ListaFinale.Add(singRis)
                            End If

                        Next
                        'qui ho aggiunto quelli che non c'erano la volta prima 

                        'If ListaFinale.Count < TotalePromo Then
                        '    For Each singRis In lP
                        '        If ListaFinale.Count = TotalePromo Then Exit For

                        '        If ListaFinale.FindAll(Function(x) x.IdListinoBase = singRis.IdListinoBase).Count = 0 Then
                        '            ListaFinale.Add(singRis)
                        '        End If

                        '    Next

                        'End If

                    End If

                End Using

                If ListaPromoAttiviOnline.Count = 0 Then
                    'qui vanno ricreati tutti e parto dalla lista nuova
                    'dureranno fino a domenica prossima

                    Dim DataScadenza As Date = Now.Date '.AddDays(1)

                    Dim GiorniDiff As Integer = 7 - CInt(DataScadenza.DayOfWeek)
                    If GiorniDiff = 0 Then GiorniDiff = 7
                    If GiorniDiff Then DataScadenza = DataScadenza.AddDays(GiorniDiff)

                    Dim DataFine As New Date(DataScadenza.Year,
                                             DataScadenza.Month,
                                             DataScadenza.Day, 23, 59, 0)

                    LogMe("Nuova data di scadenza dei promo automatici: " & DataFine.ToString("dd/MM/yyyy "))

                    For Each SingPromo In ListaFinale
                        'qui vado a creare il promo online e offline 

                        Using C As New Promo

                            C.IdListinoBase = SingPromo.IdListinoBase
                            C.Percentuale = SingPromo.PercPromo
                            C.DataFineValidita = DataFine
                            C.Stato = enStato.Attivo
                            C.Automatico = enSiNo.Si

                            Dim i As Integer = 0

                            For i = 0 To 1

                                If i = 1 Then
                                    FormerDALWeb.LUNA.LunaContext.ConnectionString = FormerLib.FormerConst.Ambiente.ConnectionStringServerWebTwin
                                End If

                                Using tb As FormerDALWeb.LUNA.LunaTransactionBox = FormerDALWeb.LUNA.LunaContext.CreateTransactionBox()
                                    Try
                                        If i = 0 Then
                                            LogMe("Salvo il promo interno su idlistinobase " & C.IdListinoBase)
                                            C.Save()
                                            Using mgrL As New ListinoBaseDAO
                                                mgrL.UpdateCounterPromo(C.IdListinoBase)
                                            End Using
                                        End If
                                        Using mgr As New FormerDALWeb.PromoWDAO
                                            Dim Conl As FormerDALWeb.PromoW
                                            If C.IdPromoOnline Then
                                                Conl = mgr.Read(C.IdPromoOnline)
                                            Else
                                                Conl = New FormerDALWeb.PromoW
                                            End If
                                            Conl.IdListinoBase = C.IdListinoBase
                                            'quando lo porto online devo salvare l'id del cliente online non qui
                                            Conl.Percentuale = C.Percentuale
                                            Conl.QtaSpecifica = C.QtaSpecifica
                                            Conl.DataFineValidita = C.DataFineValidita
                                            Conl.IdPromoInt = C.IdPromo
                                            Conl.Automatico = enSiNo.Si
                                            tb.TransactionBegin()
                                            If i = 0 Then LogMe("Salvo il promo online su idlistinobase " & C.IdListinoBase)
                                            mgr.Save(Conl)
                                            If i = 0 Then

                                                C.IdPromoOnline = Conl.IdPromo
                                                C.Save()
                                            End If

                                            tb.TransactionCommit()

                                        End Using
                                    Catch ex As Exception
                                        tb.TransactionRollBack()
                                        LogMe("ERRORE nel salvataggio del PROMO online (Interno " & C.IdPromo & ")",, ex)
                                    End Try
                                End Using
                            Next
                            FormerDALWeb.LUNA.LunaContext.ConnectionString = String.Empty

                        End Using

                    Next
                Else
                    'qui vanno controllati e in caso disattivati

                    For Each singP In ListaPromoAttiviOnline

                        For i = 0 To 1

                            If i = 1 Then
                                FormerDALWeb.LUNA.LunaContext.ConnectionString = FormerLib.FormerConst.Ambiente.ConnectionStringServerWebTwin
                            End If

                            Dim RisLB As RisPromoSuLB = lPAttiviAlMomento.Find(Function(x) x.IdListinoBase = singP.IdListinoBase)

                            If Not RisLB Is Nothing Then

                                Dim NuovoStato As enStato = enStato.Attivo

                                If RisLB.PercentualeSuFatturato < RisLB.ListinoBase.PercMaxPromoFatturato Then
                                    'lo attivo
                                    NuovoStato = enStato.Attivo
                                Else
                                    'lo disattivo
                                    NuovoStato = enStato.NonAttivo
                                End If

                                singP.Stato = NuovoStato
                                singP.Save()


                            End If

                        Next

                        FormerDALWeb.LUNA.LunaContext.ConnectionString = String.Empty

                    Next

                End If



            Catch ex As Exception
                LogMe("SORGENTE: PROMO AUTOMATICI(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

            End Try

            LogMe("***PROMO AUTOMATICI TERMINATO***")

        End Sub

        Public Shared Sub InvioFattureFE(Optional CaricaOnlinePdf As Boolean = True)

            'eseguirlo solo un giorno si e un giorno no 

            LogMe("***Invio Fatture FE***")

            Try

                Dim ListaFattureDaInviare As New List(Of Ricavo)

                Using mgr As New RicaviDAO
                    Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdAzienda, IdRicavo"},
                                                           New LUNA.LunaSearchParameter(LFM.Ricavo.StatoFE, enStatoFatturaFE.InCodaInvio),
                                                           New LUNA.LunaSearchParameter(LFM.Ricavo.Tipo, "(" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.NotaDiCredito & ")", "IN"),
                                                           New LUNA.LunaSearchParameter("YEAR(DataRicavo)", "2019", ">="))

                    Dim Adesso As Date = Now.AddDays(-1)
                    Dim DataRiferimento As New Date(Adesso.Year, Adesso.Month, Adesso.Day, 23, 59, 59)

                    For Each R As Ricavo In l

                        If R.DataRicavo.Year >= 2019 Then
                            Dim DiffMinuti As Integer = DateDiff(DateInterval.Minute, R.DataRicavo, DataRiferimento)

                            If DiffMinuti >= 1 Then

                                Dim CheckOkNdC As Boolean = False
                                If R.Tipo = enTipoDocumento.NotaDiCredito Then
                                    If Not R.RicavoRiferimentoNotadiCredito Is Nothing AndAlso
                                        R.RicavoRiferimentoNotadiCredito.StatoFE >= enStatoFatturaFE.NonConsegnataDestinatario Then

                                        CheckOkNdC = True

                                    End If
                                Else
                                    CheckOkNdC = True
                                End If

                                If CheckOkNdC Then
                                    Threading.Thread.Sleep(2000) 'aspetto 2 secondi tra un invio e l'altro

                                    LogMe(R.TipoDocStr.ToUpper & " " & R.Numero & "/" & R.AnnoRiferimento & " " & R.AziendaStr & " (IdRicavo " & R.IdRicavo & ")")
                                    If R.VoceRubrica.Fatturabile.Length = 0 Then

                                        'qui genero l'xml e procedo all'invio della pec 

                                        Try

                                            Dim PathTemp As String = PathFattureFE & R.AnnoRiferimento & "\" & R.IdAzienda & "\IT" & MgrAziende.GetPartitaIva(R.IdAzienda) & "_" & MgrFattureFE.GetProgressivo(R) & ".xml"

                                            FormerHelper.File.CreateLongPath(PathTemp)

                                            If IO.File.Exists(PathTemp) Then
                                                Try
                                                    Kill(PathTemp)
                                                Catch ex As Exception

                                                End Try
                                            End If

                                            Dim bufferXML As String = MgrFattureFE.RicavoToXML(R, PathTemp)
                                            LogMe("Generato file XML: " & PathTemp)

                                            'invio il file XML 
                                            Dim ListaAllegati As New List(Of String)
                                            ListaAllegati.Add(PathTemp)

                                            Dim RisInvio As Integer = MgrFattureFE.InviaFatturaPEC(R, ListaAllegati)

                                            If RisInvio = 0 Then
                                                LogMe("Inviato file XML")
                                                'qui l'ho spedita
                                                R.StatoFE = enStatoFatturaFE.InviatoXML
                                                R.DataOraInvio = Now
                                                R.DocXML = bufferXML
                                                R.Save()
                                                LogMe("Salvati i dati della fattura e Terminato il processo di invio")

                                                'CREO IL PDF DELLA FATTURA IN OGGETTO
                                                If CaricaOnlinePdf Then
                                                    'SPEDISCO UNA COPIA DI CORTESIA AL CLIENTE
                                                    FormerPrinter.ProxyStampa.StampaDocumentoFiscalePDF(R, True)

                                                    ListaFattureDaInviare.Add(R)

                                                End If

                                            Else
                                                Throw New ApplicationException("ERRORE: Si è verificato un errore nell'invio della PEC, l'invio sarà tentato nuovamente")
                                                'LogMe("ERRORE: Si è verificato un errore nell'invio della PEC, l'invio sarà tentato nuovamente")
                                            End If

                                        Catch ex As Exception
                                            LogMe("ERRORE: " & ex.Source & "- " & ex.Message,, ex)
                                        End Try
                                    Else
                                        LogMe("-NON INVIATA: Non fatturabile")
                                    End If
                                End If

                            End If
                        End If
                    Next

                End Using

                'faccio passare 10 secondi 
                Threading.Thread.Sleep(10000)

                For Each Fattura In ListaFattureDaInviare
                    If Fattura.Tipo <> enTipoDocumento.NotaDiCredito Then
                        CaricaOnlineEInviaPdfFattura(Fattura)
                        Threading.Thread.Sleep(3000)
                    End If

                Next

            Catch ex As Exception
                LogMe("SORGENTE: InvioFattureFE(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try

            LogMe("***FINE Invio Fatture FE***")

            'If CaricaOnlinePdf Then
            '    'CaricaOnlinePdfFatture(MgrAziende.IdAziende.AziendaSnc)
            '    'CaricaOnlinePdfFatture(MgrAziende.IdAziende.AziendaSrl)
            'End If


        End Sub

        Private Shared Sub CaricaOnlineEInviaPdfFattura(R As Ricavo)

            LogMe("***UPLOAD FATTURA " & R.IdRicavo & "***")
            LogMe("Fattura " & R.NumeroCompleto & " del " & R.DataRicavoStr & " - " & R.VoceRubrica.RagSocNome)

            Try
                Dim Ris As RisCaricaOnlineFatturaPDF = MgrFattureFE.CaricaOnlineFatturaPDF(R)

                If Ris.ExitCode = RisCaricaOnlineFatturaPDF.enExitCode.FileLocaleNonPresente Then
                    LogMe("File PDF non presente")
                Else
                    If Ris.IdConsegnaInterna Then
                        LogMe(" - IdConsegna " & Ris.IdConsegnaInterna)
                    End If
                    If Ris.IdConsegnaOnline Then
                        LogMe(" - IdConsegna Online " & Ris.IdConsegnaOnline)
                    End If
                    If Ris.ExitCode = RisCaricaOnlineFatturaPDF.enExitCode.FileOnlineGiaPresente Then
                        LogMe(" - Il file era gia presente online")
                    Else
                        If Ris.ExitCode = RisCaricaOnlineFatturaPDF.enExitCode.ErroreNellaFaseDiUpload Then
                            LogMe(" - Si è verificato un errore nella fase di upload")
                        ElseIf Ris.ExitCode = RisCaricaOnlineFatturaPDF.enExitCode.Ok Then
                            LogMe(" - Il file è stato caricato correttamente")
                        End If
                    End If
                End If

            Catch ex As Exception
                LogMe("***ERRORE UPLOAD FATTURA " & R.IdRicavo & "***",, ex)
            End Try

            LogMe("***UPLOAD FATTURA TERMINATO***")

        End Sub

        'Private Shared Sub CaricaOnlinePdfFatture(IdAzienda As Integer)

        '    'Exit Sub

        '    LogMe("***UPLOAD FATTURE***")
        '    Dim DirFatture As New DirectoryInfo(PathFatture(IdAzienda))
        '    Dim LastUpload As Date = Now.AddDays(-1)

        '    Dim TotFileCaricati As Integer = 0
        '    For Each F As FileInfo In DirFatture.GetFiles()
        '        Try
        '            Dim IntervalloDallaCreazione As Long = DateDiff(DateInterval.Second, LastUpload, F.CreationTime) ', LastUpload, F.LastWriteTime) 'LastUpload, F.CreationTime) 'f.creationtime

        '            If IntervalloDallaCreazione > 0 Then
        '                LogMe(" - Lavoro " & F.Name)
        '                'qui va fatto l'upload
        '                Dim PosizionePunto As Integer = F.Name.IndexOf(".")
        '                Dim AnnoDocumento As Integer = F.Name.Substring(0, 4)
        '                Dim NumeroDocumento As Integer = F.Name.Substring(5, PosizionePunto - 4)

        '                LogMe(" - Documento " & NumeroDocumento & " Anno " & AnnoDocumento)
        '                'cerco il documento e da li arrivo alla consegna 
        '                Dim IdConsegna As Integer = 0
        '                Using Mgr As New RicaviDAO
        '                    IdConsegna = Mgr.GetIdConsegnaFromFattura(AnnoDocumento, NumeroDocumento, IdAzienda)
        '                End Using
        '                LogMe(" - IdConsegna " & IdConsegna)

        '                If IdConsegna Then
        '                    Dim IdConsOnline As Integer = 0
        '                    Using mgr As New FW.ConsegneDAO
        '                        IdConsOnline = mgr.GetIdConsFromIdInt(IdConsegna)
        '                    End Using
        '                    LogMe(" - IdConsegna Online " & IdConsOnline)

        '                    If IdConsOnline Then
        '                        'il path e' dentro Consegne/IdConsegna/
        '                        Dim PathRemoto As String = "/tipografiaformer.it/consegne/" & IdConsOnline & "/" & F.Name
        '                        Using Ftp As New FTPclient(FtpServer, FtpLogin, FtpPwd)
        '                            LogMe(" - Upload " & F.Name & " su Consegna " & IdConsOnline)

        '                            Try
        '                                Ftp.FtpCreateDirectory("tipografiaformer.it/consegne/" & IdConsOnline)
        '                            Catch ex As Exception

        '                            End Try

        '                            Dim EraGiaPresente As Boolean = False

        '                            Try
        '                                If Ftp.FtpFileExists(PathRemoto) Then
        '                                    EraGiaPresente = True
        '                                    LogMe(" - Il file era gia presente online, verrà sovrascritto")
        '                                End If
        '                            Catch ex As Exception

        '                            End Try

        '                            Ftp.Upload(F.FullName, PathRemoto)
        '                            TotFileCaricati += 1

        '                            'Qui mandare email al cliente dando link per scaricarlo direttamente
        '                            Using C As New FormerDALWeb.Consegna
        '                                C.Read(IdConsOnline)
        '                                If C.IdConsegna Then

        '                                    Dim DestEmail As String = String.Empty
        '                                    Using u As New VoceRubrica
        '                                        u.Read(C.Utente.IdRubricaInt)
        '                                        DestEmail = u.EmailAmministrativa
        '                                    End Using

        '                                    If DestEmail <> FormerConst.EmailNonDisponibile Then
        '                                        Dim M As New My.Templates.MailFatturaOnline
        '                                        M.C = C
        '                                        Dim TestoMail As String = M.TransformText

        '                                        Dim ccnAddress As String = String.Empty

        '                                        'If Now.Date.Year = 2016 And Now.Date.Month = 5 And Now.Date.Day <= 12 Then
        '                                        '    ccnAddress = "soft@tipografiaformer.it"
        '                                        'End If
        '                                        If EraGiaPresente = False Then
        '                                            Try
        '                                                FormerHelper.Mail.InviaMail("Nuova fattura disponibile per il tuo ordine numero " & C.IdConsegna,
        '                                                                            TestoMail,
        '                                                                            DestEmail,,,
        '                                                                            F.FullName,,
        '                                                                            ccnAddress)
        '                                            Catch ex As Exception
        '                                                LogMe(" - Errore invio Mail nuova fattura ",, ex)
        '                                            End Try

        '                                        End If

        '                                    End If
        '                                End If
        '                            End Using
        '                        End Using
        '                    End If
        '                End If
        '            End If
        '        Catch ex As Exception
        '            LogMe("SORGENTE: UPLOAD FATTURE(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
        '        End Try
        '    Next

        '    LogMe(" - Caricate: " & TotFileCaricati & " Fatture")
        '    LogMe("***UPLOAD FATTURE TERMINATO***")

        'End Sub

        Public Shared Sub BackupIncrementale()
            'BACKUP
            'Dim NomeFilePrevisto As String = Now.Year & Format(Now.Month, "0#") & Format(Now.Day, "0#") & ".mdb"
            'Dim NomeFile As String = PathBkpDB & NomeFilePrevisto
            'If Dir(NomeFile) = "" Then

            LogMe("***Backup***")

            Try
                'questo viene eseguito una volta al giorno
                'qui devo fare il backup anche dei file 
                '                    FileCopy(PathDB, NomeFile)
                'LogMe("Backup MDB EFFETTUATO: " & NomeFilePrevisto)

                Dim SB As New SmartBackupLib.SmartBackup

                SB.EffettuaBackup(PathCommesse, PathBkpFile)

                LogMe("Backup INCREMENTALE FILE EFFETTUATO")

            Catch ex As Exception
                LogMe("SORGENTE: Backup(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

            End Try

            LogMe("***Backup TERMINATO***")

            'End If
        End Sub

        Public Shared Sub CleanAndMove()
            Try
                SpostaOffsetDaTemp()
                SpostaDigitaleDaTemp()
                SpostaRifiutatiDaTemp()
                PulisciTemp()
            Catch ex As Exception
                LogMe("SORGENTE: CleanAndMove(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)
            End Try
        End Sub

        Private Shared Sub PulisciTemp()

            LogMe("***Pulizia Cartella Temporanea***")
            'controllo tutti i file nella cartella temp ed elimino quelli non piu necessari
            Dim x As So.FileInfo

            Dim dir As New So.DirectoryInfo(PathTemp)
            Dim Counter As Integer = 0
            Dim CounterErr As Integer = 0

            For Each x In dir.GetFiles
                'qui ho tutti i file nella cartella temp
                'li cerco nella tabella sorgenti e nel campo file della tabella ordini
                Dim Ris As Boolean = True

                Using ordFile As New OrdiniDAO
                    Ris = ordFile.TrovaFile(x.FullName)
                End Using

                Try
                    If Ris = False Then
                        So.File.Delete(x.FullName)
                        Counter += 1
                    End If

                Catch ex As Exception
                    CounterErr += 1
                End Try
            Next

            If Counter > 0 Or CounterErr > 0 Then
                LogMe(" - Cancellati " & Counter & " file")
                LogMe(" - Errore in Cancellazione " & CounterErr & " file")
            End If

            LogMe("***Pulizia Cartella Temporanea TERMINATA***")

        End Sub

        Private Shared Sub SpostaOffsetDaTemp()

            LogMe("***Sposta Offset da Cartella Temporanea***")

            Dim Counter As Integer = 0
            Dim CounterErr As Integer = 0

            Dim ListaIDOrd As List(Of Integer)
            Using x As New OrdiniDAO
                ListaIDOrd = x.ListaIdOrdOffsetDaSpostare(PathTemp)
            End Using

            For Each IdSing As Integer In ListaIDOrd
                Try
                    'su questo ordine devo spostare il file e aggiornare il db
                    Dim Ord As New Ordine
                    Ord.Read(IdSing)

                    Dim NuovoNomeFile As String = PathCommesse & Ord.IdCom & "\" & FormerHelper.File.EstraiNomeFile(Ord.FilePath)
                    Dim VecchioNomeFile As String = Ord.FilePath

                    If So.File.Exists(VecchioNomeFile) Then
                        FileCopy(Ord.FilePath, NuovoNomeFile)
                        Ord.FilePath = NuovoNomeFile
                        Counter += 1
                    Else
                        Ord.FilePath = String.Empty
                        CounterErr += 1
                    End If

                    Using mO As New OrdiniDAO
                        mO.SalvaFile(Ord)
                    End Using

                    'FileCopy(Ord.FilePath, NuovoNomeFile)

                    'qui copio i file dei sorgenti degli ordini
                    Try
                        If So.File.Exists(VecchioNomeFile) Then
                            FileIO.FileSystem.DeleteFile(VecchioNomeFile,
                                                         FileIO.UIOption.OnlyErrorDialogs,
                                                         FileIO.RecycleOption.DeletePermanently)

                        End If
                    Catch ex As Exception

                    End Try

                    For Each sorg As FileSorgente In Ord.ListaSorgenti

                        NuovoNomeFile = PathCommesse & Ord.IdCom & "\" & Ord.IdCom & "-" & FormerHelper.File.EstraiNomeFile(sorg.FilePath)
                        VecchioNomeFile = sorg.FilePath
                        'FileCopy(sorg.FilePath, NuovoNomeFile)
                        If So.File.Exists(VecchioNomeFile) Then
                            FileCopy(sorg.FilePath, NuovoNomeFile)
                            sorg.FilePath = NuovoNomeFile
                            Counter += 1
                            Try
                                FileIO.FileSystem.DeleteFile(VecchioNomeFile,
                                                             FileIO.UIOption.OnlyErrorDialogs,
                                                             FileIO.RecycleOption.DeletePermanently)
                            Catch ex As Exception

                            End Try

                        Else
                            sorg.FilePath = String.Empty
                            CounterErr += 1
                        End If
                        sorg.Save()
                    Next
                Catch ex As Exception
                    CounterErr += 1
                End Try

            Next

            If Counter > 0 Or CounterErr > 0 Then
                LogMe(" - Spostati " & Counter & " file")
                LogMe(" - Non trovati " & CounterErr & " file")
            End If

            LogMe("***Sposta Offset da Cartella Temporanea TERMINATO***")
        End Sub

        Private Shared Sub SpostaRifiutatiDaTemp()

            LogMe("***Sposta Rifiutati da Cartella Temporanea***")

            Dim Counter As Integer = 0
            Dim CounterErr As Integer = 0

            Dim ListaIDOrd As List(Of Integer)
            Using x As New OrdiniDAO
                ListaIDOrd = x.ListaIdOrdRifiutatiDaSpostare(PathTemp)
            End Using

            For Each IdSing As Integer In ListaIDOrd
                Try
                    'su questo ordine devo spostare il file e aggiornare il db
                    Dim Ord As New Ordine
                    Ord.Read(IdSing)

                    Dim NuovoNomeFile As String = PathFileRifiutati & FormerHelper.File.EstraiNomeFile(Ord.FilePath)
                    Dim VecchioNomeFile As String = Ord.FilePath

                    If So.File.Exists(VecchioNomeFile) Then
                        FileCopy(Ord.FilePath, NuovoNomeFile)
                        Ord.FilePath = NuovoNomeFile
                        Counter += 1
                    Else
                        Ord.FilePath = String.Empty
                        CounterErr += 1
                    End If

                    Using mO As New OrdiniDAO
                        mO.SalvaFile(Ord)
                    End Using

                    'FileCopy(Ord.FilePath, NuovoNomeFile)

                    'qui copio i file dei sorgenti degli ordini
                    Try
                        If So.File.Exists(VecchioNomeFile) Then
                            FileIO.FileSystem.DeleteFile(VecchioNomeFile,
                                                         FileIO.UIOption.OnlyErrorDialogs,
                                                         FileIO.RecycleOption.DeletePermanently)

                        End If
                    Catch ex As Exception

                    End Try

                    For Each sorg As FileSorgente In Ord.ListaSorgenti

                        NuovoNomeFile = PathFileRifiutati & FormerHelper.File.EstraiNomeFile(sorg.FilePath)
                        VecchioNomeFile = sorg.FilePath
                        'FileCopy(sorg.FilePath, NuovoNomeFile)
                        If So.File.Exists(VecchioNomeFile) Then
                            FileCopy(sorg.FilePath, NuovoNomeFile)
                            sorg.FilePath = NuovoNomeFile
                            Counter += 1
                            Try
                                FileIO.FileSystem.DeleteFile(VecchioNomeFile,
                                                             FileIO.UIOption.OnlyErrorDialogs,
                                                             FileIO.RecycleOption.DeletePermanently)
                            Catch ex As Exception

                            End Try

                        Else
                            sorg.FilePath = String.Empty
                            CounterErr += 1
                        End If
                        sorg.Save()
                    Next
                Catch ex As Exception
                    CounterErr += 1
                End Try

            Next

            If Counter > 0 Or CounterErr > 0 Then
                LogMe(" - Spostati " & Counter & " file")
                LogMe(" - Non trovati " & CounterErr & " file")
            End If

            LogMe("***Sposta Rifiutati da Cartella Temporanea TERMINATO***")
        End Sub

        Private Shared Sub SpostaDigitaleDaTemp()

            LogMe("***Sposta Digitale da Cartella Temporanea***")

            Dim Counter As Integer = 0
            Dim CounterErr As Integer = 0

            Dim ListaIDOrd As List(Of Integer)
            Using x As New OrdiniDAO
                ListaIDOrd = x.ListaIdOrdDigitaleDaSpostare(PathTemp)
            End Using

            For Each IdSing As Integer In ListaIDOrd
                Try
                    'su questo ordine devo spostare il file e aggiornare il db
                    Dim Ord As New Ordine
                    Ord.Read(IdSing)

                    Dim NuovoNomeFile As String = PathFileDigitale & FormerHelper.File.EstraiNomeFile(Ord.FilePath)
                    Dim VecchioNomeFile As String = Ord.FilePath

                    If So.File.Exists(VecchioNomeFile) Then
                        FileCopy(Ord.FilePath, NuovoNomeFile)
                        Ord.FilePath = NuovoNomeFile
                        Counter += 1
                    Else
                        Ord.FilePath = String.Empty
                        CounterErr += 1
                    End If

                    Using mO As New OrdiniDAO
                        mO.SalvaFile(Ord)
                    End Using

                    'FileCopy(Ord.FilePath, NuovoNomeFile)

                    'qui copio i file dei sorgenti degli ordini
                    Try
                        If So.File.Exists(VecchioNomeFile) Then
                            FileIO.FileSystem.DeleteFile(VecchioNomeFile,
                                                         FileIO.UIOption.OnlyErrorDialogs,
                                                         FileIO.RecycleOption.DeletePermanently)

                        End If
                    Catch ex As Exception

                    End Try

                    For Each sorg As FileSorgente In Ord.ListaSorgenti

                        NuovoNomeFile = PathFileDigitale & FormerHelper.File.EstraiNomeFile(sorg.FilePath)
                        VecchioNomeFile = sorg.FilePath
                        'FileCopy(sorg.FilePath, NuovoNomeFile)
                        If So.File.Exists(VecchioNomeFile) Then
                            FileCopy(sorg.FilePath, NuovoNomeFile)
                            sorg.FilePath = NuovoNomeFile
                            Counter += 1
                            Try
                                FileIO.FileSystem.DeleteFile(VecchioNomeFile,
                                                             FileIO.UIOption.OnlyErrorDialogs,
                                                             FileIO.RecycleOption.DeletePermanently)
                            Catch ex As Exception

                            End Try

                        Else
                            sorg.FilePath = String.Empty
                            CounterErr += 1
                        End If
                        sorg.Save()
                    Next
                Catch ex As Exception
                    CounterErr += 1
                End Try

            Next

            If Counter > 0 Or CounterErr > 0 Then
                LogMe(" - Spostati " & Counter & " file")
                LogMe(" - Non trovati " & CounterErr & " file")
            End If

            LogMe("***Sposta Digitale da Cartella Temporanea TERMINATO***")
        End Sub

    End Class

    Public Class NewVersionChecker
        'Inherits FormerService

        Public Shared Sub StartService()
            Stato = enStatoServizio.Attivo

            LogMe("***CheckNewVer***")

            Try

                Dim F As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathNewVer & "former.exe")
                FormerLib.FormerUDP.SendUDPCommand(FormerLib.FormerUDP.TipoUDP_Versioning, F.FileVersion)

            Catch ex As Exception
                LogMe("SORGENTE: CheckNewVer(), " & ex.Source & ControlChars.NewLine & "MESSAGE: " & ex.Message & ControlChars.NewLine & "STACK:" & ex.StackTrace, , ex)

            End Try

            LogMe("***CheckNewVer TERMINATO***")
            Stato = enStatoServizio.NonAttivo

        End Sub

    End Class

End Class