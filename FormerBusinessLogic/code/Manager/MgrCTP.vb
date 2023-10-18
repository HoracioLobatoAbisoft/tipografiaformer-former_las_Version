Imports System.IO
Imports FormerConfig
Imports FormerDALSql
Imports FormerIO
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrGanging

    Public Class MarcatoriPreps5
        Public Const RigaFile As String = "%SSiJobFileRef: {1} 'file:{2}' {1} {3} 0 0.00000 0.00000 0.00000 0.00000 0.00000 0.00000 1.00000 0 {3}"
        Public Const RigaPage As String = "%SSiJobPage: {1} 1 0.00000 0.00000 1.00000 1.00000 {2} 0.00000 0.00000 '' 1 -1 1"
        Public Const RigaDelivery As String = "%SSiJobDelivery: {1} {2} 1 1 0"
    End Class

    Public Class MarcatoriPreps8
        Public Const RigaFile As String = "%SSiJobFileRef: {1} 'file:{2}' {1} 0 0 0.00000 0.00000 0.00000 0.00000 0.00000 0.00000 1.00000 0 -1"
        Public Const SpazioDichiarazioneFile As String = "{{{FILE-LIST-HERE}}}"
    End Class

    Public Shared Function GetJobBufferFromOrders(L As List(Of Ordine)) As String

        Dim ris As String = String.Empty

        Dim BufferFile As String = String.Empty
        Dim Counter As Integer = 6

        For Each O As Ordine In L

            For Each S As FileSorgente In O.ListaSorgenti
                Dim Riga As String = MarcatoriPreps8.RigaFile
                Riga = Riga.Replace("{1}", Counter)

                Dim NuovoNomeFileRiga As String = S.FilePath

                NuovoNomeFileRiga = FormerHelper.File.TranslateRealDrivePath(NuovoNomeFileRiga)

                NuovoNomeFileRiga = NuovoNomeFileRiga.Replace("\", "/")

                Riga = Riga.Replace("{2}", NuovoNomeFileRiga)

                BufferFile &= Riga & ControlChars.NewLine

                Counter += 1
            Next

        Next

        Dim t As New My.Templates.FileJobVuotoGanging8

        ris = t.TransformText

        ris = ris.Replace(MarcatoriPreps8.SpazioDichiarazioneFile, BufferFile)

        Return ris

    End Function

End Class

Public Class MgrCTP

    Public Shared Function GetListaOrdiniCTP(C As Commessa) As OrdiniCTP

        Dim collOrd As New OrdiniCTP
        'carico la lista di ordini in base agli ordini presenti nella commessa

        collOrd.IdCom = C.IdCom
        collOrd.CopieDiStampa = C.Copie
        Using M As New ModelloCommessa
            M.Read(C.IdModelloCommessa)

            For Each o In C.ListaOrdini
                Dim Ord As New OrdineCTP
                Ord.IdOrd = o.IdOrd

                Dim NumFogli As Integer = o.QtaOrdine * o.NFogli

                Ord.Duplicati = Math.Ceiling(NumFogli / collOrd.CopieDiStampa) 'o.Prodotto.NumPezzi / collOrd.CopieDiStampa)'MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO

                If M.FRSuSeStessa = enSiNo.Si Then
                    Ord.Duplicati /= 2
                End If
                If Ord.Duplicati = 0 Then Ord.Duplicati = 1
                If o.IdListinoBase Then
                    Dim FormatoTrovato As ModComFormProd = M.FormatiProdotto.Find(Function(x) x.IdFormProd = o.ListinoBase.IdFormProd)

                    If FormatoTrovato Is Nothing Then
                        'prvo con il formato carta
                        FormatoTrovato = M.FormatiProdotto.Find(Function(x) x.FormatoProdotto.IdFormCarta = o.ListinoBase.FormatoProdotto.IdFormCarta)
                    End If
                    If Not FormatoTrovato Is Nothing Then
                        Ord.OrdinamentoDaFormato = FormatoTrovato.RangeMin
                    End If
                End If

                collOrd.ListaOrdini.Add(Ord)
            Next
        End Using

        OrdinaListaOrdini(collOrd)

        Return collOrd

    End Function

    Public Shared Sub OrdinaListaOrdini(ByRef L As OrdiniCTP)
        'L.ListaOrdini.Sort(Function(o, y) o.OrdinamentoDaFormato.CompareTo(y.OrdinamentoDaFormato))
        L.ListaOrdini.Sort(AddressOf Comparer)
    End Sub

    Private Shared Function Comparer(ByVal x As OrdineCTP,
                                     ByVal y As OrdineCTP) As Integer

        Dim Result As Integer = x.OrdinamentoDaFormato.CompareTo(y.OrdinamentoDaFormato)
        If Result = 0 Then Result = x.IdOrd.CompareTo(y.IdOrd)

        Return Result

    End Function

    Private Shared Function GetOrientamentoJOB(F As FileSorgente,
                                     M As ModelloCommessa,
                                     O As OrdineCTP) As Integer
        Dim ris As Integer = 3
        Dim OrientamentoPrevisto As enTipoOrientamento = enTipoOrientamento.Orizzontale
        Dim OrientamentoTrovato As enTipoOrientamento = enTipoOrientamento.NonSpecificato

        Dim FilePath As String = F.FilePath

        If FormerDebug.DebugAttivo Then
            FilePath = FilePath.Replace("Z:", "W:")
        End If

        OrientamentoTrovato = FormerLib.FormerHelper.PDF.GetOrientamentoPdf(FilePath)

        Dim ModComFP As ModComFormProd = M.FormatiProdotto.Find(Function(x) x.IdFormProd = O.Ordine.ListinoBase.IdFormProd)

        Dim AngoloRotazione As Integer = 0

        If ModComFP Is Nothing Then
            ModComFP = M.FormatiProdotto.Find(Function(x) x.FormatoProdotto.IdFormCarta = O.Ordine.ListinoBase.FormatoProdotto.IdFormCarta)
        End If
        OrientamentoPrevisto = ModComFP.Orientamento

        If F.NumPagina And Not ModComFP Is Nothing Then
            If OrientamentoPrevisto = enTipoOrientamento.Orizzontale Then
                If OrientamentoTrovato = enTipoOrientamento.Verticale Then
                    If F.NumPagina Mod 2 = 0 Then ' retro
                        '-270
                        AngoloRotazione = -270
                    Else 'fronte
                        '-90
                        AngoloRotazione = -90
                    End If
                End If
            ElseIf OrientamentoPrevisto = enTipoOrientamento.Verticale Then
                If OrientamentoTrovato = enTipoOrientamento.Orizzontale Then
                    If F.NumPagina Mod 2 = 0 Then ' retro
                        '-270
                        AngoloRotazione = -270
                    Else 'fronte
                        '-90
                        AngoloRotazione = -90
                    End If
                End If
            End If
        End If

        If AngoloRotazione = -270 Then
            ris = 2
        ElseIf AngoloRotazione = -90 Then
            ris = 0
        End If

        Return ris
    End Function

    Private Shared Sub RiempiTemplateJOB(NomeFileDest As String,
                                  collOrd As OrdiniCTP)

        Dim bufferFinale As String = String.Empty
        'Dim PathDir As String = FormerHelper.File.TranslateRealDrivePath(FormerPath.PathCommesse & collOrd.IdCom & "\")

        Dim ContNumFronte As Integer = 1
        Dim ContNumRetro As Integer = 2
        'qui vado a fare le varie sostituzioni all'interno del file JOB
        Dim Progressivi As New Dictionary(Of String, Integer)

        Dim CountSegnature As Integer = 1

        If collOrd.Commessa.Segnature Then
            CountSegnature = collOrd.Commessa.Segnature
        End If

        Using R As New StreamReader(NomeFileDest)
            Dim FileEncoding As String = String.Empty
            While Not R.EndOfStream
                Dim Riga As String = R.ReadLine

                If Riga.StartsWith("%%FileEncoding: ") Then
                    FileEncoding = Riga.Substring(15).Trim
                End If


                bufferFinale &= Riga & ControlChars.NewLine
                If Riga.StartsWith("%SSiPrepsVer:") Then
                    'qui ci devo inserire i file ref partendo non so perche da 6
                    '%SSiJobFileRef: 8 'file://hw20952-62/JobData/Pdf_Ok/39563/001-39563-81684_F_otticabigli_a.pdf' 8 1264748899 0 0.00000 0.00000 0.00000 0.00000 0.00000 0.00000 1.00000 0 1264748899
                    Dim Progressivo As Integer = 6
                    For Each O As OrdineCTP In collOrd.ListaOrdini
                        For Each s As FileSorgente In O.Ordine.ListaSorgenti
                            Dim NuovoNomeFileRiga As String = s.FilePath

                            NuovoNomeFileRiga = FormerHelper.File.TranslateRealDrivePath(NuovoNomeFileRiga)

                            NuovoNomeFileRiga = NuovoNomeFileRiga.Replace("\", "/")
                            Dim RigaToWrite As String = MgrGanging.MarcatoriPreps5.RigaFile.Replace("{2}", NuovoNomeFileRiga)
                            RigaToWrite = RigaToWrite.Replace("{1}", Progressivo)
                            'If FormerDebug.DebugAttivo = False Then
                            'Dim f As New FileInfo(NuovoNomeFile)
                            RigaToWrite = RigaToWrite.Replace("{3}", FileEncoding)
                            'End If
                            bufferFinale &= RigaToWrite & ControlChars.NewLine
                            Progressivi.Add(s.FilePath, Progressivo)
                            's.ProgressivoAssegnato = Progressivo
                            Progressivo += 1
                        Next

                    Next

                ElseIf Riga.StartsWith("%SSiJobFileRef: -4") Then
                    'qui ci dveo inserire i jobpage partendo sempre da 6

                    For Each O As OrdineCTP In collOrd.ListaOrdini
                        For i As Integer = 1 To O.Duplicati
                            Dim RigaToWrite As String = String.Empty
                            If O.Ordine.ListaSorgenti.Count = 1 Then
                                Dim s As FileSorgente = O.Ordine.ListaSorgenti(0)
                                RigaToWrite = MgrGanging.MarcatoriPreps5.RigaPage.Replace("{1}", Progressivi(s.FilePath))
                                RigaToWrite = RigaToWrite.Replace("{2}", GetOrientamentoJOB(O.Ordine.ListaSorgenti(0), collOrd.Commessa.ModelloCommessa, O))
                                bufferFinale &= RigaToWrite & ControlChars.NewLine
                                'se il modello e' fronte retro aggiungo il retro
                                If collOrd.Commessa.ModelloCommessa.FronteRetro = enSiNo.Si Then
                                    RigaToWrite = MgrGanging.MarcatoriPreps5.RigaPage.Replace("{1}", "-1")
                                    RigaToWrite = RigaToWrite.Replace("{2}", "3")
                                    bufferFinale &= RigaToWrite & ControlChars.NewLine
                                End If
                            Else 'If O.Ordine.ListaSorgenti.Count = 2 Then
                                For Each s As FileSorgente In O.Ordine.ListaSorgenti
                                    RigaToWrite = MgrGanging.MarcatoriPreps5.RigaPage.Replace("{1}", Progressivi(s.FilePath))
                                    RigaToWrite = RigaToWrite.Replace("{2}", GetOrientamentoJOB(s, collOrd.Commessa.ModelloCommessa, O))
                                    bufferFinale &= RigaToWrite & ControlChars.NewLine
                                Next
                                'Else
                                'qui è per multipagina

                            End If
                        Next
                    Next
                End If
                'End If
            End While
        End Using

        'qui lavoro sulle segnature 

        If CountSegnature > 1 Then
            'individuo il blocco segnature e lo duplico per ogni segnature che ci sarà portando avanti progressivo e counter iniziale 
            Dim BufferWithSegnature As String = String.Empty
            Dim RigaSegnatura As String = String.Empty

            For Each riga As String In bufferFinale.Split(vbLf)
                riga = riga.TrimEnd(vbCr)
                If riga.StartsWith("%SSiSigUsed:") Then
                    RigaSegnatura = riga
                    BufferWithSegnature &= FormerConst.CTP.MarcatoreRigaSegnatura
                ElseIf riga.StartsWith("%SSiJobDelivery:") Then
                    'niente
                Else
                    BufferWithSegnature &= riga & ControlChars.NewLine
                End If
            Next

            Dim BufferToReplace As String = String.Empty
            Dim ProgressivoIniziale As Integer = 1
            For i As Integer = 1 To CountSegnature
                BufferToReplace &= RigaSegnatura & ControlChars.NewLine
                Dim RigaToIns As String = MgrGanging.MarcatoriPreps5.RigaDelivery.Replace("{2}", i)
                RigaToIns = RigaToIns.Replace("{1}", ProgressivoIniziale)

                'aumento il progressivo iniziale del numero di spazi del modello
                ProgressivoIniziale += collOrd.Commessa.ModelloCommessa.NumSpazi

                BufferToReplace &= RigaToIns & ControlChars.NewLine
            Next

            BufferWithSegnature = BufferWithSegnature.Replace(FormerConst.CTP.MarcatoreRigaSegnatura, BufferToReplace)

            bufferFinale = BufferWithSegnature

        End If

        Using w As New StreamWriter(NomeFileDest) '.Replace(".j", ".a.j"))
            w.Write(bufferFinale)
        End Using

    End Sub

    Public Shared Function EsportaJOB(IdCom As Integer,
                                      CollOrd As OrdiniCTP,
                                      Optional ByRef Sender As Object = Nothing) As Integer
        Dim Ris As Integer = 0
        Try
            Using C As New Commessa
                C.Read(IdCom)
                If C.IdModelloCommessa Then
                    Using M As New ModelloCommessa
                        M.Read(C.IdModelloCommessa)

                        'Dim PathDir As String = FormerPath.PathJob & IdCom & "\"
                        Dim PathDir As String = FormerPath.PathCommesse & IdCom & "\"
                        FormerHelper.File.CreateLongPath(PathDir)

                        Dim NomeFileDest As String = PathDir & IdCom & ".job"
                        MgrFormerIO.FileCopy(M.Job, NomeFileDest, Sender)
                        'System.IO.File.Copy(M.Job, NomeFileDest, True)
                        RiempiTemplateJOB(NomeFileDest, CollOrd)

                        'Dim NomefileAnte As String = PathDir & IdCom & "F.jpg"
                        'Dim NomefileAnteR As String = PathDir & IdCom & "R.jpg"
                        'Dim NomefilePDF As String = PathDir & IdCom & ".pdf"

                        ''FileCopia(Me, M.Job, NomeFileDest)
                        'If M.Anteprima.Length Then
                        '    System.IO.File.Copy(M.Anteprima, NomefileAnte, True)
                        '    'FileCopia(Me, M.Anteprima, NomefileAnte)
                        'End If
                        'If M.AnteprimaR.Length Then
                        '    System.IO.File.Copy(M.AnteprimaR, NomefileAnteR, True)
                        '    'FileCopia(Me, M.AnteprimaR, NomefileAnteR)
                        'End If
                        'If M.PDF.Length Then
                        '    System.IO.File.Copy(M.PDF, NomefilePDF, True)
                        '    'FileCopia(Me, M.PDF, NomefilePDF)
                        'End If
                    End Using

                End If
            End Using
        Catch ex As Exception
            Ris = 1
        End Try
        Return Ris

    End Function

    'Public Shared Function EsportaCTP(ByRef CollOrd As OrdiniCTP) As Integer
    '    Dim ris As Integer = 0
    '    Exit Function 'esce qui nons erve che fa piu nulla

    '    Dim PathDir As String = FormerPath.PathCTP & CollOrd.IdCom & "\"

    '    If FormerDebug.DebugAttivo = False Then FormerHelper.File.CreateLongPath(PathDir)

    '    'creo la cartella della commessa

    '    'ora ciclo per tutti gli ordini contenuti nella collezione, mi carico i file di ogni ordine e lo copio n volte per quanti sono i duplicati 
    '    'mantenendo la numerazione in base a fronte retro 
    '    Dim ContNumFronte As Integer = 1
    '    Dim ContNumRetro As Integer = 2

    '    Dim Ord As OrdineCTP
    '    Dim buffer As String = ""
    '    Dim NumRiga As Integer = 1

    '    For Each Ord In CollOrd.ListaOrdini
    '        'Dim DT As DataTable, Dr As DataRow

    '        'Using collSorg As New cSorgentiColl
    '        '    DT = collSorg.Lista(Ord.IdOrd)
    '        'End Using

    '        Dim l As List(Of FileSorgente) = Ord.Ordine.ListaSorgenti ' Nothing

    '        NumRiga = 1

    '        For Each Dr As FileSorgente In l

    '            'la prima volta e' il fronte la seconda il retro

    '            Dim NuovoNomeFile As String = String.Empty
    '            Dim ContInterno As Integer = 0

    '            Dim NomeFileOriginale As String = Dr.FilePath
    '            Dim NomeFileOrientato As String = String.Empty

    '            Dim OrientamentoPrevisto As enTipoOrientamento = enTipoOrientamento.Orizzontale
    '            Dim OrientamentoTrovato As enTipoOrientamento = enTipoOrientamento.NonSpecificato

    '            'qui vedo l'orientamento trovato nel file sorgente
    '            OrientamentoTrovato = FormerLib.FormerHelper.PDF.GetOrientamentoPdf(NomeFileOriginale)

    '            'qui cerco l'orientamento previsto nel modello commessa
    '            Dim ModComFP As ModComFormProd = CollOrd.Commessa.ModelloCommessa.FormatiProdotto.Find(Function(x) x.IdFormProd = Ord.Ordine.ListinoBase.IdFormProd)

    '            Dim AngoloRotazione As Integer = 0

    '            If ModComFP Is Nothing Then
    '                ModComFP = CollOrd.Commessa.ModelloCommessa.FormatiProdotto.Find(Function(x) x.FormatoProdotto.IdFormCarta = Ord.Ordine.ListinoBase.FormatoProdotto.IdFormCarta)
    '            End If

    '            If ModComFP Is Nothing Then
    '                'MessageBox.Show("Nel modello commessa scelto non è presente un formato prodotto specifico o generico da cui poter capire l'orientamento")
    '                ris = 1
    '            Else
    '                OrientamentoPrevisto = ModComFP.Orientamento

    '                If Dr.NumPagina And Not ModComFP Is Nothing Then
    '                    If OrientamentoPrevisto = enTipoOrientamento.Orizzontale Then
    '                        If OrientamentoTrovato = enTipoOrientamento.Verticale Then
    '                            If Dr.NumPagina Mod 2 = 0 Then ' retro
    '                                '-270
    '                                AngoloRotazione = -270
    '                            Else 'fronte
    '                                '-90
    '                                AngoloRotazione = -90
    '                            End If
    '                        End If
    '                    ElseIf OrientamentoPrevisto = enTipoOrientamento.Verticale Then
    '                        If OrientamentoTrovato = enTipoOrientamento.Orizzontale Then
    '                            If Dr.NumPagina Mod 2 = 0 Then ' retro
    '                                '-270
    '                                AngoloRotazione = -270
    '                            Else 'fronte
    '                                '-90
    '                                AngoloRotazione = -90
    '                            End If
    '                        End If
    '                    End If
    '                End If

    '            End If

    '            For ContInterno = 1 To Ord.Duplicati
    '                Dim contatore As Integer = 0

    '                contatore += 1

    '                If CollOrd.Commessa.ModelloCommessa.FronteRetro = enSiNo.No Then
    '                    'qui sono tutti fronte quindi se ci sono piu di un sorgente nell'ordine in realta è un anomalia
    '                    contatore = ContNumFronte
    '                    ContNumFronte += 1
    '                Else
    '                    If Dr.NumPagina Mod 2 <> 0 Then
    '                        'qui fronte
    '                        contatore = ContNumFronte
    '                        ContNumFronte += 2
    '                    Else
    '                        'qui retro
    '                        contatore = ContNumRetro
    '                        ContNumRetro += 2
    '                    End If
    '                End If

    '                'If NumRiga = 1 Then
    '                '    contatore = ContNumFronte
    '                '    ContNumFronte += 2
    '                'Else
    '                '    contatore = ContNumRetro
    '                '    ContNumRetro += 2 'porto cmq avanti anche il retro 
    '                'End If

    '                NuovoNomeFile = FormerHelper.Stringhe.FormattaConZeri(contatore, 3) & "-" & FormerLib.FormerHelper.File.EstraiNomeFile(Dr.FilePath)
    '                Dim NomeCompletoFile As String = PathDir & NuovoNomeFile

    '                If AngoloRotazione Then
    '                    If FormerDebug.DebugAttivo = False Then FormerLib.FormerHelper.PDF.RuotaPdf(Dr.FilePath, NomeCompletoFile, AngoloRotazione)
    '                Else
    '                    'qui copio effettivamente il file
    '                    If FormerDebug.DebugAttivo = False Then System.IO.File.Copy(Dr.FilePath, NomeCompletoFile, True)
    '                    'FileCopia(Me, Dr.FilePath, NuovoNomeFile)
    '                End If
    '                'CollOrd.CollSorgenti.Add(NuovoNomeFile)

    '                'Buffer &= NuovoNomeFile & vbNewLine
    '            Next

    '            NumRiga += 1
    '        Next

    '        Dim FileVuoto As String = FormerPath.PathFileBianco

    '        If CollOrd.Commessa.ModelloCommessa.FronteRetro = enSiNo.Si Then
    '            If l.Count Mod 2 <> 0 Then

    '                'qui la modifica per il nuovo ragionamento con file vuoto

    '                Dim ContInterno As Integer = 0

    '                For ContInterno = 1 To Ord.Duplicati
    '                    Dim NuovoNomeFile As String = ""
    '                    NuovoNomeFile = FormerHelper.Stringhe.FormattaConZeri(ContNumRetro, 3) & "-" & FormerConst.CTP.MarcatoreBlankPage '  "BlankPage" 'PathDir & FormerHelper.Stringhe.FormattaConZeri(ContNumRetro, 3) & "-" & FormerLib.FormerHelper.File.EstraiNomeFile(FileVuoto)
    '                    'qui copio effettivamente il file
    '                    'If FormerDebug.DebugAttivo = False Then System.IO.File.Copy(FileVuoto, NuovoNomeFile)
    '                    'FileCopia(Me, FileVuoto, NuovoNomeFile)
    '                    ContNumRetro += 2
    '                    'CollOrd.CollSorgenti.Add(NuovoNomeFile)
    '                Next

    '            End If
    '        End If

    '    Next
    '    'CollOrd.CollSorgenti.Sort(Function(x, y) x.CompareTo(y))
    '    Return ris
    'End Function

End Class

Public Class OrdineCTP

    Public IdOrd As Integer = 0
    Public Duplicati As Integer = 0
    Public Ordinamento As Integer = 0
    Public OrdinamentoDaFormato As Integer = 0
    'Public CollSorgenti As cCTPSorgentiOrdine
    Private _Ordine As Ordine = Nothing
    Public ReadOnly Property Ordine As Ordine
        Get
            If _Ordine Is Nothing Then
                _Ordine = New Ordine
                _Ordine.Read(IdOrd)
            End If
            Return _Ordine
        End Get
    End Property

End Class

Public Class SorgenteCTP

    Public Property IdSorgente As Integer = 0
    Public Property Progressivo As Integer = 0
    Public Property Path As String = String.Empty
    Public Property TipoRetro As enTipoRetro = enTipoRetro.RetroDifferente
    Public Property Ordine As Ordine

End Class

Public Class OrdiniCTP
    'Inherits CollectionBase

    Public Property IdCom As Integer
    Public Property CopieDiStampa As Integer

    Private _ListaOrdini As New List(Of OrdineCTP)
    Public Property ListaOrdini() As List(Of OrdineCTP)
        Get
            Return _ListaOrdini
        End Get
        Set(value As List(Of OrdineCTP))
            _ListaOrdini = value
        End Set
    End Property

    Private _Commessa As Commessa = Nothing
    Public ReadOnly Property Commessa As Commessa
        Get
            If _Commessa Is Nothing Then
                _Commessa = New Commessa
                _Commessa.Read(IdCom)
            End If
            Return _Commessa
        End Get
    End Property

    'Private _CollSorgenti As New List(Of String)
    'Public Property CollSorgenti As List(Of String)
    '    Get
    '        Return _CollSorgenti
    '    End Get
    '    Set(value As List(Of String))
    '        _CollSorgenti = value
    '    End Set
    'End Property

End Class

'Public Class cCTPOrdini
'    'Inherits CollectionBase

'    Public Property IdCom As Integer

'    Public Property CopieDiStampa As Integer

'    Public Sub add(ByVal Ordine As cCTPOrdine)
'        InnerList.Add(Ordine)
'    End Sub

'    Public ReadOnly Property ListaOrdini() As ArrayList
'        Get
'            Return InnerList
'        End Get

'    End Property

'End Class

'Public Class cCTPSorgentiOrdine
'    Inherits CollectionBase

'    Public Sub add(ByVal Sorgente As cCTPSorgente)
'        InnerList.Add(Sorgente)

'    End Sub

'    Public ReadOnly Property ListaSorgenti() As ArrayList
'        Get
'            Return InnerList
'        End Get

'    End Property

'End Class