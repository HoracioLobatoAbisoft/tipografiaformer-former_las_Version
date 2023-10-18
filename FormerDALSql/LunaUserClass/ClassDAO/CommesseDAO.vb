#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region

Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerConfig
Imports FormerIO

''' <summary>
'''DAO Class for table T_commesse
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
''' 
Public Class CommesseDAO
    Inherits _CommesseDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    'Public Function CommessaAperta(IdOperatore As Integer, IdCommessa As Integer, idstato As Integer, IdLavLog As Integer) As StatoLavorazione
    '    'torna 0 se non cominciata
    '    'torna 1 se cominciata dall'operatore passato e non chiusa
    '    'torna 2 se cominciata dall'operatore passato e chiusa
    '    'torna 3 se cominciata da un altro operatore
    '    Dim Ris As New StatoLavorazione
    '    Try

    '        Using myCommand As SqlCommand = _Cn.CreateCommand()
    '            Dim sql As String = ""
    '            If IdLavLog Then
    '                If idstato = enStatoCommessa.FinituraSuProdotti Then
    '                    sql = "SELECT IdCrono, null as DI, Idoperatore, null as DF "
    '                    sql &= " from T_CommesseCrono where iDcom = " & _
    '                        IdCommessa & " AND IDSTATO = " & idstato

    '                Else
    '                    sql = "SELECT c.IdCrono, l.DataOraInizio as DI, Idut as Idoperatore, DataOraFine as DF "
    '                    sql &= " from T_CommesseCrono c inner join t_Lavlog L on c.idcom=l.idcom where c.IDcom = " & _
    '                        IdCommessa & " AND c.IDSTATO=" & idstato
    '                    sql &= " and l.idlavlog = " & IdLavLog
    '                End If

    '            Else
    '                sql = "SELECT IdCrono, DataCronoInizio as DI, Idoperatore, DataCronoFine as DF "
    '                sql &= " from T_CommesseCrono where IDcom = " & IdCommessa & " AND IDSTATO=" & idstato
    '            End If

    '            myCommand.CommandText = sql

    '            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '            Using myReader As SqlDataReader = myCommand.ExecuteReader()

    '                myReader.Read()

    '                If myReader.HasRows Then
    '                    Ris.IdCrono = myReader("IdCrono")
    '                    If IsDBNull(myReader("DI")) Then

    '                        Ris.Stato = 0
    '                    Else
    '                        Ris.IdOp = myReader("idoperatore")
    '                        Ris.DataInizio = myReader("DI")

    '                        If IsDBNull(myReader("DF")) Then

    '                            If IsDBNull(myReader("idoperatore")) OrElse myReader("idoperatore") = IdOperatore Then
    '                                Ris.Stato = 1

    '                            Else
    '                                Ris.Stato = 3

    '                            End If
    '                        Else
    '                            Ris.Stato = 2
    '                            Ris.DataFine = myReader("DI")
    '                        End If

    '                    End If
    '                End If

    '                myReader.Close()
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try

    '    Return Ris
    'End Function

    Public Function ReadOperatore(IdCom As Integer) As CommessaOperatore
        Dim classe As CommessaOperatore = Nothing
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT c.*"
                sql &= ",(select top 1 Descrizione from T_Risorse R,T_Magaz M where R.idris = M.IdRis and M.IdCom = C.idcom and m.idut<>0 ) as Risorsa"
                sql &= ",(select top 1 QTa from T_Risorse R,T_Magaz M where R.idris = M.IdRis and M.IdCom = C.idcom and m.idut<>0) as Quantita "
                sql &= ",(select Count(Idpostit) from T_Postit Pos where Pos.idcom = c.idcom and Pos.tipomsg <> " & enTipoMessaggio.Automatico & ") as NMsg "
                sql &= " from T_Commesse C"
                sql &= " Where c.idcom = " & IdCom

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    If myReader.HasRows Then

                        myReader.Read()
                        classe = New CommessaOperatore(CType(myReader, IDataRecord))

                        'DATI EXTRA
                        'If Not myReader("Riassunto") Is DBNull.Value Then classe.TipoCommessaStr = myReader("Riassunto")
                        'If Not myReader("Risorsa") Is DBNull.Value Then classe.RisorsaStr = myReader("risorsa")
                        'If Not myReader("Quantita") Is DBNull.Value Then classe.QtaStr = myReader("Quantita")

                        If Not myReader("NmSg") Is DBNull.Value Then classe.NumeroMessaggi = myReader("NmSg")
                    End If

                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return classe
    End Function

    Public Function Lista(Optional ByVal Codice As String = "",
                          Optional ByVal IdCli As Integer = 0,
                          Optional ByVal Stato As String = "",
                          Optional ByVal RepartoSelezionato As enRepartoWeb = enRepartoWeb.StampaOffset,
                          Optional ByVal UltimoMese As Boolean = False,
                          Optional IdMacchinario As Integer = 0) As List(Of CommessaRicerca)

        Dim L As New List(Of CommessaRicerca)
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT c.*"
                sql &= ",(SELECT TOP 1 Descrizione FROM T_Risorse R,T_Magaz M WHERE R.idris = M.IdRis AND M.IdCom = C.idcom AND m.idut<>0 ) as Risorsa"
                sql &= ",(SELECT TOP 1 QTa FROM T_Risorse R,T_Magaz M WHERE R.idris = M.IdRis AND M.IdCom = C.idcom and m.idut<>0) as Quantita "
                sql &= ",(SELECT Count(Idpostit) FROM T_Postit Pos  WHERE Pos.idcom = c.idcom) as NMsg "
                sql &= " FROM T_Commesse C "
                sql &= " WHERE 1=1 "

                If Stato.Length Then
                    sql &= " AND c.stato IN (" & Stato & ")"
                End If

                If Codice.Length Then
                    sql &= " AND c.idcom = " & Codice
                End If

                If RepartoSelezionato <> 0 Then
                    sql &= " AND c.idReparto = " & RepartoSelezionato
                End If

                If IdCli Then
                    sql &= " AND c.idcom IN (SELECT idcom FROM t_ordini WHERE idrub =" & IdCli & ")"
                End If

                If UltimoMese Then
                    sql &= " AND datediff(""d"",c.DataIns,GetDate())<= 30 "
                End If

                'If IdMacchinario Then
                '    sql &= " AND c.IdMacchinario = " & IdMacchinario
                'End If

                'Select Case AnnoSelezionato
                '    Case 1 '6 mesi
                '        sql &= " and datediff(m,datains,getdate()) <= 6" ' & Ap(Postazione.AnnoSelezionato)
                '    Case 2 '1 anno
                '        sql &= " and datediff(m,datains,getdate()) <= 12" ' & Ap(Postazione.AnnoSelezionato)
                'End Select

                'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

                sql &= " ORDER BY c.IdCom DESC"

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim classe As New CommessaRicerca(CType(myReader, IDataRecord))

                        'DATI EXTRA 
                        'If Not myReader("MacchinaStampaStr") Is DBNull.Value Then classe.MacchinaStampaStr = myReader("MacchinaStampaStr")
                        'If Not myReader("Tipo") Is DBNull.Value Then classe.TipoCommessaStr = myReader("Tipo")
                        'If Not myReader("Riassunto") Is DBNull.Value Then classe.TipoCommessaStr = myReader("Riassunto")
                        'If Not myReader("Risorsa") Is DBNull.Value Then classe.RisorsaStr = myReader("risorsa")
                        'If Not myReader("Quantita") Is DBNull.Value Then classe.QtaStr = myReader("Quantita")
                        If Not myReader("NmSg") Is DBNull.Value Then classe.NumeroMessaggi = myReader("NmSg")

                        L.Add(classe)
                    End While
                End Using


                If IdMacchinario Then

                    L = L.FindAll(Function(x) x.IdMacchinario = IdMacchinario Or (Not x.LavLogRealizzazione Is Nothing AndAlso x.LavLogRealizzazione.IdMacchinario = IdMacchinario))

                    'ParMacchinario = New LUNA.LunaSearchParameter(LFM.Commessa.IdMacchinario, cmbMacchinari.SelectedValue)
                End If

            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return L

    End Function

    Public Function GetRisorsaDefaultOld(ListaIdOrdini As Integer()) As Risorsa

        Dim Ris As Risorsa = Nothing

        Dim ListaIdOrdStr As String = String.Empty

        For Each SingId In ListaIdOrdini
            ListaIdOrdStr &= SingId & ","
        Next

        ListaIdOrdStr = ListaIdOrdStr.TrimEnd(",")

        Dim TipoCartaTrovata As New List(Of TipoCarta)

        If ListaIdOrdStr.Length Then
            Dim LDisp As List(Of Ordine) = Nothing

            Using mgr As New OrdiniDAO
                LDisp = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdOrd, "(" & ListaIdOrdStr & ")", " IN "),
                                    New LUNA.LunaSearchParameter(LFM.Ordine.IdCom, 0)) ',
                'New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Registrato))

            End Using

            For Each singO As Ordine In LDisp
                If TipoCartaTrovata.FindAll(Function(x) x.IdTipoCarta = singO.Prodotto.ListinoBase.IdTipoCarta).Count = 0 Then
                    TipoCartaTrovata.Add(singO.Prodotto.ListinoBase.TipoCarta)
                End If
            Next
        End If

        If TipoCartaTrovata.Count Then
            'qui posso tirare fuori la risorsa predefinita 
            If TipoCartaTrovata.Count = 1 Then
                'TODO:QUI VA AGGIUNTO IL CONTROLLO SULLA GIACENZA
                Dim tc As TipoCarta = TipoCartaTrovata(0)
                Using mgr As New RisorseDAO
                    Dim l As List(Of Risorsa) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Risorsa.IdTipoCarta, tc.IdTipoCarta))
                    If l.Count Then
                        Ris = l(0)
                    End If
                End Using
            Else
                'QUI IN TEORIA NON DEVE MAI ENTRARE POI VEDIAMO PER ORA NON FACCIO NIENTE

            End If

        End If

        Return Ris

    End Function

    Public Function GetRisorsaDefault(ListaIdOrdini As Integer(),
                                      M As ModelloCommessa,
                                      Optional ControllaSottoScorta As Boolean = True) As List(Of Risorsa)

        Dim Ris As New List(Of Risorsa)

        Dim ListaIdOrdStr As String = String.Empty

        For Each SingId In ListaIdOrdini
            ListaIdOrdStr &= SingId & ","
        Next

        ListaIdOrdStr = ListaIdOrdStr.TrimEnd(",")

        Dim IdTcPrincipale As Integer = 0

        If ListaIdOrdStr.Length Then
            Dim LDisp As List(Of Ordine) = Nothing

            Using mgr As New OrdiniDAO
                LDisp = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdOrd, "(" & ListaIdOrdStr & ")", " IN ")) ',
                'New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Registrato))

            End Using

            Dim TipiCartaUsati As New Dictionary(Of Integer, Integer)

            For Each O As Ordine In LDisp
                Dim Conteggio As Integer = 0
                If Not O.ListinoBase Is Nothing Then
                    If TipiCartaUsati.TryGetValue(O.ListinoBase.IdTipoCarta, Conteggio) Then
                        TipiCartaUsati(O.ListinoBase.IdTipoCarta) += 1
                    Else
                        TipiCartaUsati.Add(O.ListinoBase.IdTipoCarta, 1)
                    End If
                End If

            Next
            'qui devo ordinarlo in maniera da prendere il piu usato
            TipiCartaUsati.OrderByDescending(Function(x) x.Value)

            If TipiCartaUsati.Count Then IdTcPrincipale = TipiCartaUsati.First.Key

        End If

        If IdTcPrincipale Then
            'PRENDO LA PIU USATA 
            Using Tc As New TipoCarta
                Tc.Read(IdTcPrincipale)
                Using mgr As New RisorseDAO
                    If Tc.TipoCarta = enTipoCarta.Composta Then
                        For Each tcInC In Tc.ComposizioniCarta
                            Dim l As List(Of Risorsa) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Risorsa.IdTipoCarta, tcInC.IdCartaSingola),
                                                                    New LUNA.LunaSearchParameter(LFM.Risorsa.Stato, enStato.Attivo))
                            l.Sort(Function(x, y) x.GetScartoCM2RispettoModelloCommessa(M).CompareTo(y.GetScartoCM2RispettoModelloCommessa(M)))
                            If l.Count Then
                                Ris.Add(l(0))
                            End If

                        Next
                    Else
                        Dim l As List(Of Risorsa) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Risorsa.IdTipoCarta, IdTcPrincipale),
                                                                New LUNA.LunaSearchParameter(LFM.Risorsa.Stato, enStato.Attivo))

                        l.Sort(Function(x, y) x.GetScartoCM2RispettoModelloCommessa(M).CompareTo(y.GetScartoCM2RispettoModelloCommessa(M)))

                        'TODO:QUI VA CONTROLLATA LA GIACENZA PER VEDERE SE QUESTA RISORSA LA POSSO UTILIZZARE
                        For Each sing In l
                            If ControllaSottoScorta Then
                                If sing.Giacenza > 0 Then
                                    Ris.Add(sing)
                                    Exit For
                                End If
                            Else
                                Ris.Add(sing)
                                Exit For
                            End If

                        Next

                    End If
                End Using
            End Using

        End If

        Return Ris

    End Function

    Public Function GetLastreNecessarie(NumSpazi As Integer,
                                        FrSuSeStessa As Integer,
                                        ListaIdOrdini As Integer()) As Integer

        Dim NumLastre As Integer = 1

        Dim ListaIdOrdStr As String = String.Empty

        For Each SingId In ListaIdOrdini
            ListaIdOrdStr &= SingId & ","
        Next

        ListaIdOrdStr = ListaIdOrdStr.TrimEnd(",")

        Dim NumFacciate As Integer = 2
        Dim NoImpiantiSuFacc As enSiNo = enSiNo.No

        Dim AlmenoUnOrdineFR As Boolean = False

        If ListaIdOrdStr.Length Then
            Dim LDisp As List(Of Ordine) = Nothing

            Using mgr As New OrdiniDAO

                LDisp = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdOrd, "(" & ListaIdOrdStr & ")", " IN "),
                                    New LUNA.LunaSearchParameter(LFM.Ordine.IdCom, 0),
                                    New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.Registrato))

            End Using

            For Each singO As Ordine In LDisp
                If singO.Prodotto.ListinoBase.ColoreStampa.NLastre > NumLastre Then
                    NumLastre = singO.Prodotto.ListinoBase.ColoreStampa.NLastre
                End If

                If singO.Prodotto.NumFacciate > NumFacciate Then
                    NumFacciate = singO.Prodotto.NumFacciate
                End If

                If singO.Prodotto.NoImpiantiSuFacciate = enSiNo.Si Then
                    NoImpiantiSuFacc = enSiNo.Si
                End If

                If singO.ListinoBase.ColoreStampa.FR Then
                    AlmenoUnOrdineFR = True
                End If

            Next
        End If

        If NumFacciate <> 2 And NoImpiantiSuFacc = enSiNo.No Then
            'qui devo andare a fare il calcolo giusto delle facciate su impianti 

            Dim NumFogli As Integer = NumFacciate '/ 2 ' 31/07/2017 modificata per i calendari 

            If AlmenoUnOrdineFR = True Then NumFogli /= 2

            Dim RisTemp As Integer = (NumFogli * NumLastre) / NumSpazi

            NumLastre = RisTemp

        End If

        If AlmenoUnOrdineFR = True AndAlso FrSuSeStessa = enSiNo.Si Then
            NumLastre /= 2
        End If

        Return NumLastre

    End Function

    Public Function GetLastreNecessarie(m As ModelloCommessa,
                                             ListaIdOrdini As Integer()) As Integer

        Return GetLastreNecessarie(m.NumSpazi, m.FRSuSeStessa, ListaIdOrdini)

        'Dim NumLastre As Integer = 1

        'Dim ListaIdOrdStr As String = String.Empty

        'For Each SingId In ListaIdOrdini
        '    ListaIdOrdStr &= SingId & ","
        'Next

        'ListaIdOrdStr = ListaIdOrdStr.TrimEnd(",")

        'Dim NumFacciate As Integer = 2
        'Dim NoImpiantiSuFacc As enSiNo = enSiNo.No

        'Dim AlmenoUnOrdineFR As Boolean = False

        'If ListaIdOrdStr.Length Then
        '    Dim LDisp As List(Of Ordine) = Nothing

        '    Using mgr As New OrdiniDAO

        '        LDisp = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Ordine.IdOrd, "(" & ListaIdOrdStr & ")", " IN "),
        '                            New LUNA.LunaSearchParameter(LFM.Ordine.IdCom, 0),
        '                            New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.Registrato))

        '    End Using

        '    For Each singO As Ordine In LDisp
        '        If singO.Prodotto.ListinoBase.ColoreStampa.NLastre > NumLastre Then
        '            NumLastre = singO.Prodotto.ListinoBase.ColoreStampa.NLastre
        '        End If

        '        If singO.Prodotto.NumFacciate > NumFacciate Then
        '            NumFacciate = singO.Prodotto.NumFacciate
        '        End If

        '        If singO.Prodotto.NoImpiantiSuFacciate = enSiNo.Si Then
        '            NoImpiantiSuFacc = enSiNo.Si
        '        End If

        '        If singO.ListinoBase.ColoreStampa.FR Then
        '            AlmenoUnOrdineFR = True
        '        End If

        '    Next
        'End If

        'If NumFacciate <> 2 And NoImpiantiSuFacc = enSiNo.No Then
        '    'qui devo andare a fare il calcolo giusto delle facciate su impianti 

        '    Dim NumFogli As Integer = NumFacciate '/ 2 ' 31/07/2017 modificata per i calendari 

        '    If AlmenoUnOrdineFR = True Then NumFogli /= 2

        '    Dim RisTemp As Integer = (NumFogli * NumLastre) / m.NumSpazi

        '    NumLastre = RisTemp

        'End If

        'If AlmenoUnOrdineFR = True AndAlso m.FRSuSeStessa = enSiNo.Si Then
        '    NumLastre /= 2
        'End If

        'Return NumLastre

    End Function

    Public Function GetNomeRiassuntivo(ListaIDOrdini As Integer()) As String
        Dim ris As String = String.Empty
        Dim ListaIdLB As New Dictionary(Of Integer, Integer)
        Dim ListaIdPrev As New Dictionary(Of Integer, Integer)

        For Each IdOrd As Integer In ListaIDOrdini

            Dim O As New Ordine
            O.Read(IdOrd)
            If ListaIdLB.ContainsKey(O.Prodotto.IdListinoBase) Then
                ListaIdLB(O.Prodotto.IdListinoBase) += 1
            Else
                ListaIdLB.Add(O.Prodotto.IdListinoBase, 1)
            End If

            'qui controllo se c'e' la preventivazione e aumento il contatore altrimenti la creo

            If ListaIdPrev.ContainsKey(O.Prodotto.ListinoBase.Preventivazione.IdPrev) Then
                ListaIdPrev(O.Prodotto.ListinoBase.Preventivazione.IdPrev) += 1
            Else
                ListaIdPrev.Add(O.Prodotto.ListinoBase.Preventivazione.IdPrev, 1)
            End If
        Next

        If ListaIdLB.Count = 1 Then
            'qui prendo il nome del listinobase
            Dim Lb As New ListinoBase
            Lb.Read(ListaIdLB.First.Key)
            ris = Lb.NomeEx
        ElseIf ListaIdLB.Count > 0 Then
            'qui devo prendere quella con piu ordini dentro. se sono pare invece 
            Dim sorted = From pair In ListaIdPrev Order By pair.Value Descending
            Dim sortedDictionary = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)
            Dim IdPrev As Integer = sortedDictionary.First.Key

            Dim Prev As New Preventivazione
            Prev.Read(IdPrev)
            ris = Prev.Descrizione

        End If

        Return ris
    End Function

    Public Function SalvaFile(ByRef Com As Commessa) As Integer

        'devo salvare il file della commessa e i file di tutti gli ordini

        Dim Ris As Integer = 0

        Try
            'salvo le immagini degli ordini

            Dim NuovoNomeFile As String = ""
            Dim PathCom As String = FormerPath.PathCommesse & Com.IdCom & "\"
            FormerHelper.File.CreateLongPath(PathCom) 'creo la cartella della commessa
            '            Dim I As Integer

            'For I = 0 To Com.ListaIdOrdini.GetUpperBound(0)
            'Using Ord As New Ordine
            For Each Ord As Ordine In Com.ListaOrdini

                If Ord.ListinoBase.NoAttachFile <> enSiNo.Si Then
                    If Ord.FilePath.Length AndAlso Ord.FilePath.StartsWith(PathCom) = False Then 'copia solo i file che gia non sono li 
                        'NuovoNomeFile = PathCom & Com.IdCom & "-" & I + 1 & ".jpg"
                        'MODIFICA EFFETTUATA IL 29 SETTEMBRE 2011 PER EVITARE IL PROBLEMA DI NON VISUALIZZAZIONE ANTEPRIMA
                        NuovoNomeFile = PathCom & FormerLib.FormerHelper.File.EstraiNomeFile(Ord.FilePath)
                        'FileCopy(Ord.FilePath, NuovoNomeFile)
                        'System.IO.File.Move(Ord.FilePath, NuovoNomeFile)
                        MgrFormerIO.FileMove(Ord.FilePath, NuovoNomeFile)
                        Ord.FilePath = NuovoNomeFile
                        Using mO As New OrdiniDAO
                            mO.SalvaFile(Ord)
                        End Using
                        'qui copio i file dei sorgenti degli ordini

                        For Each sorg As FileSorgente In Ord.ListaSorgenti

                            'Dim Estensione As String = ""
                            'Estensione = sorg.FilePath.Substring(sorg.FilePath.Length - 4)
                            Dim NomeFileOriginale As String = FormerLib.FormerHelper.File.EstraiNomeFile(sorg.FilePath)

                            Dim Posizione As Integer = NomeFileOriginale.IndexOf("-")

                            If Posizione <> -1 AndAlso Posizione < 7 Then
                                NomeFileOriginale = NomeFileOriginale.Substring(Posizione + 1)
                            End If

                            NuovoNomeFile = PathCom & Com.IdCom & "-" & NomeFileOriginale
                            'FileCopy(sorg.FilePath, NuovoNomeFile)
                            'System.IO.File.Move(sorg.FilePath, NuovoNomeFile)
                            MgrFormerIO.FileMove(sorg.FilePath, NuovoNomeFile)
                            sorg.FilePath = NuovoNomeFile
                            sorg.Save()

                        Next

                        For Each F As FileAllegato In Ord.ListaFileAllegati
                            Dim NomeFileOriginale As String = FormerLib.FormerHelper.File.EstraiNomeFile(F.FilePath)

                            NuovoNomeFile = PathCom & NomeFileOriginale
                            'FileCopy(sorg.FilePath, NuovoNomeFile)
                            'FileIO.FileSystem.MoveFile(F.FilePath, NuovoNomeFile)
                            MgrFormerIO.FileMove(F.FilePath, NuovoNomeFile)
                            F.FilePath = NuovoNomeFile
                            F.Save()
                        Next

                    End If
                End If
            Next

        Catch ex As Exception

            Ris = ex.GetHashCode
            ManageError(ex)

        End Try

        Return Ris

    End Function

    'Public Function CalcolaRisorseNecessarie(IdReparto As Integer,
    '                                        IdFormato As Integer,
    '                                        QtaPartenza As Integer) As List(Of RisorsaUtilizzataRis)

    '    Dim ris As New List(Of RisorsaUtilizzataRis)



    '    Return ris

    'End Function

    Public Function CalcolaQtaRisorsaNecessaria(IdReparto As Integer,
                                                IdFormato As Integer,
                                                QtaPartenza As Integer,
                                                IdRis As Integer) As Single

        Dim QtaNeces As Single = 0

        If IdReparto = enRepartoWeb.StampaOffset Then

            Using R As New Risorsa
                R.Read(IdRis)
                If R.ProdottoFinito = enSiNo.Si OrElse IdFormato = 0 Then
                    QtaNeces = QtaPartenza 'qui e' uno a uno, scarico tutto
                Else
                    'qui devo calcolare quanto ce ne entra di questo formatomacchina su quella risorsa
                    Using fm As New Formato
                        fm.Read(IdFormato)

                        If fm.LatoLungo <= R.LatoLungo AndAlso fm.LatoCorto <= R.LatoCorto Then

                            Dim QtaCalcolata As Integer = 0
                            QtaCalcolata = R.QuantiNeEntranoInFormatoMacchina(fm)

                            Dim QtaStampa As Single = 1
                            If QtaPartenza <> 0 Then
                                QtaStampa = QtaPartenza
                            End If

                            ''qui ho x fogli da stampare di quel formato macchina
                            ''devo vedere quanti ne servono di quel formato risorsa 

                            ''li monto in entrambi i versi e vedo in quale ce ne entrano di piu


                            'Dim QtaOrizzontale As Integer = 0
                            'Dim QtaVerticale As Integer = 0

                            'If fm.LatoCorto = fm.LatoLungo Then
                            '    QtaOrizzontale = Math.Floor(R.LatoLungo / fm.LatoLungo)
                            '    QtaVerticale = Math.Floor(R.LatoCorto / fm.LatoCorto)

                            '    QtaCalcolata = QtaOrizzontale * QtaVerticale
                            'Else

                            '    Dim QtaCalcolataV As Integer = 0
                            '    Dim QtaCalcolataO As Integer = 0

                            '    QtaOrizzontale = Math.Floor(R.LatoLungo / fm.LatoLungo)
                            '    QtaVerticale = Math.Floor(R.LatoCorto / fm.LatoCorto)

                            '    If QtaOrizzontale >= 1 And QtaVerticale >= 1 Then QtaCalcolataO = QtaOrizzontale * QtaVerticale

                            '    QtaOrizzontale = Math.Floor(R.LatoLungo / fm.LatoCorto)
                            '    QtaVerticale = Math.Floor(R.LatoCorto / fm.LatoLungo)

                            '    If QtaOrizzontale >= 1 And QtaVerticale >= 1 Then QtaCalcolataV = QtaOrizzontale * QtaVerticale

                            '    If QtaCalcolataO > QtaCalcolataV Then
                            '        QtaCalcolata = QtaCalcolataO
                            '    Else
                            '        QtaCalcolata = QtaCalcolataV
                            '    End If

                            'End If

                            QtaNeces = QtaStampa / QtaCalcolata
                        Else
                            QtaNeces = QtaPartenza
                        End If

                    End Using

                End If
            End Using

        Else

            QtaNeces = QtaPartenza

        End If

        Return Math.Ceiling(QtaNeces)

    End Function

    Public Function CalcolaSegnature(L As List(Of Ordine),
                                     M As ModelloCommessa) As Integer
        Dim ris As Integer = 1

        If L.Count = 1 Then
            'qui devo vedere quanti sorgenti ha. se sono piu di due allora devo calcolare le segnature
            Dim O As Ordine = L(0)
            If O.ListaSorgenti.Count > 2 Then
                'qui devo calcolare le segnature 
                Dim NumSpazi As Integer = M.NumSpazi
                Dim MoltiplicatoreSpazi As Integer = 2
                If M.FronteRetro = enSiNo.No Then
                    MoltiplicatoreSpazi = 1
                End If
                Try
                    ris = Math.Ceiling(O.ListaSorgenti.Count / (M.NumSpazi * MoltiplicatoreSpazi))
                Catch ex As Exception
                    ris = 1
                End Try

            End If
        End If

        Return ris
    End Function

    'Public Function ListaOPStampaNoImg() As List(Of CommessaOperatoreNoImg)
    '    Dim L As New List(Of CommessaOperatoreNoImg)
    '    Try

    '        Using myCommand As SqlCommand = _Cn.CreateCommand()
    '            Dim sql As String = ""

    '            'sql = " SELECT DISTINCT T_Commesse.IdCom AS Numero, Format(T_Commesse.DataCambioStato,""Short Date"") AS Data, "
    '            'TD_TipoCommessa.Descrizione, T_Commesse.Copie, T_Commesse.Priorita, T_Risorse_1.Descrizione AS Lastra, 
    '            'IIf(T_Commesse.FronteRetro=True,'F/R','F') AS [F/R], First(T_Risorse.Descrizione) AS Carta"
    '            'sql &= " FROM (T_Risorse AS T_Risorse_1 INNER JOIN ((T_Risorse INNER JOIN (T_Commesse INNER JOIN T_Magaz "
    '            'ON T_Commesse.IdCom = T_Magaz.IdCom) ON T_Risorse.IdRis = T_Magaz.IdRis) INNER JOIN TD_TipoCommessa 
    '            'ON T_Commesse.IdTipoCom = TD_TipoCommessa.IdTipoCom) ON T_Risorse_1.IdRis = T_Commesse.IdRis) INNER JOIN T_CommesseCrono 
    '            'ON (T_CommesseCrono.IdStato = T_Commesse.Stato) AND (T_Commesse.IdCom = T_CommesseCrono.IdCom)"
    '            'sql &= " GROUP BY T_Commesse.IdCom, TD_TipoCommessa.Descrizione, T_Commesse.Copie, T_Commesse.Priorita, T_Risorse_1.Descrizione, "
    '            'T_CommesseCrono.DataCronoInizio, T_CommesseCrono.DataCronoFine, T_Commesse.DataCambioStato, T_Commesse.TipoCom, T_Risorse_1.Codice,
    '            ' T_Commesse.FronteRetro, T_Commesse.Stato"
    '            'sql &= " HAVING (T_CommesseCrono.DataCronoInizio Is Not Null AND T_CommesseCrono.DataCronoFine is null "
    '            'and T_Commesse.Stato=" & enStatoCommessa.Stampa & ") Or T_Commesse.Stato=" & enStatoCommessa.Pronto

    '            sql = "select distinct a.*,cc.idoperatore FROM ("
    '            sql &= "select c.idcom, c.idtipocom, c.idris, c.idlavorazione, c.tipocom, c.datains, c.datacambiostato, c.stato, c.fronteretro, c.numero, c.copie, c.idformato, c.lungo, c.largo, c.macchinastampa, c.costoimpianti, c.costofogliosteso, c.costocarta, c.costototale, c.filepath, Cast(c.annotazioni as NVarchar(Max)) as annotazioni ,c.priorita, c.idModelloCommessa, c.nLastreNecessarie, c.idMacchinario, c.Riassunto "
    '            sql &= ",(select top 1 Descrizione from T_Risorse R,T_Magaz M where R.idris = M.IdRis and M.IdCom = C.idcom and m.idut<>0 ) as Risorsa"
    '            sql &= ",(select top 1 Descrizione from T_Risorse R where R.idris = C.idris) as Lastra"
    '            sql &= ",(select top 1 QTa from T_Risorse R,T_Magaz M where R.idris = M.IdRis and M.IdCom = C.idcom and m.idut<>0) as Quantita "
    '            sql &= ",(select Count(Idpostit) FROM T_Postit Pos  WHERE Pos.idcom = c.idcom and Pos.tipomsg <> " & enTipoMessaggio.Automatico & ") as NMsg "
    '            sql &= " from T_Commesse C "
    '            sql &= " Where c.stato IN (" & enStatoCommessa.Pronto & "," & enStatoCommessa.Stampa & ")"

    '            sql &= " and c.idReparto = " & enRepartoWeb.StampaOffset
    '            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

    '            sql &= ") a left join T_CommesseCrono CC "
    '            sql &= " on (CC.IdStato = a.Stato) AND (a.IdCom = cc.IdCom)"
    '            sql &= " WHERE cc.datacronofine is null "
    '            'sql &= " Order by Priorita desc,a.IdCom asc "

    '            myCommand.CommandText = sql
    '            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '            Using myReader As SqlDataReader = myCommand.ExecuteReader()
    '                While myReader.Read
    '                    Dim classe As New CommessaOperatoreNoImg(CType(myReader, IDataRecord))
    '                    'If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
    '                    'If Not myReader("IdTipoCom") Is DBNull.Value Then classe.IdTipoCom = myReader("IdTipoCom")
    '                    'If Not myReader("IdRis") Is DBNull.Value Then classe.IdRis = myReader("IdRis")
    '                    'If Not myReader("IdLavorazione") Is DBNull.Value Then classe.IdLavorazione = myReader("IdLavorazione")
    '                    'If Not myReader("TipoCom") Is DBNull.Value Then classe.TipoCom = myReader("TipoCom")
    '                    'If Not myReader("DataIns") Is DBNull.Value Then classe.DataIns = myReader("DataIns")
    '                    'If Not myReader("DataCambioStato") Is DBNull.Value Then classe.DataCambioStato = myReader("DataCambioStato")
    '                    'If Not myReader("Stato") Is DBNull.Value Then classe.Stato = myReader("Stato")
    '                    'If Not myReader("FronteRetro") Is DBNull.Value Then classe.FronteRetro = myReader("FronteRetro")
    '                    'If Not myReader("Numero") Is DBNull.Value Then classe.Numero = myReader("Numero")
    '                    'If Not myReader("Copie") Is DBNull.Value Then classe.Copie = myReader("Copie")
    '                    'If Not myReader("IdFormato") Is DBNull.Value Then classe.IdFormato = myReader("IdFormato")
    '                    'If Not myReader("Lungo") Is DBNull.Value Then classe.Lungo = myReader("Lungo")
    '                    'If Not myReader("Largo") Is DBNull.Value Then classe.Largo = myReader("Largo")
    '                    'If Not myReader("MacchinaStampa") Is DBNull.Value Then classe.MacchinaStampa = myReader("MacchinaStampa")
    '                    'If Not myReader("CostoImpianti") Is DBNull.Value Then classe.CostoImpianti = myReader("CostoImpianti")
    '                    'If Not myReader("CostoFoglioSteso") Is DBNull.Value Then classe.CostoFoglioSteso = myReader("CostoFoglioSteso")
    '                    'If Not myReader("CostoCarta") Is DBNull.Value Then classe.CostoCarta = myReader("CostoCarta")
    '                    'If Not myReader("CostoTotale") Is DBNull.Value Then classe.CostoTotale = myReader("CostoTotale")
    '                    'If Not myReader("File") Is DBNull.Value Then classe.File = myReader("File")
    '                    'If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
    '                    'If Not myReader("Priorita") Is DBNull.Value Then classe.Priorita = myReader("Priorita")

    '                    'DATI EXTRA
    '                    If Not myReader("Riassunto") Is DBNull.Value Then classe.TipoCommessaStr = myReader("Riassunto")
    '                    If Not myReader("Risorsa") Is DBNull.Value Then classe.RisorsaStr = myReader("risorsa")
    '                    If Not myReader("Quantita") Is DBNull.Value Then classe.QtaStr = myReader("Quantita")
    '                    If Not myReader("NmSg") Is DBNull.Value Then classe.NumeroMessaggi = myReader("NmSg")
    '                    If Not myReader("Lastra") Is DBNull.Value Then classe.LastraStr = myReader("Lastra")
    '                    If Not myReader("IdOperatore") Is DBNull.Value Then classe.IdOperatore = myReader("IdOperatore")

    '                    L.Add(classe)
    '                End While
    '            End Using
    '        End Using

    '        L.Sort(AddressOf Comparer)

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try
    '    Return L
    'End Function

    'Public Function ListaOPStampa() As List(Of CommessaOperatore)
    '    Dim L As New List(Of CommessaOperatore)
    '    Try

    '        Using myCommand As SqlCommand = _Cn.CreateCommand()
    '            Dim sql As String = ""

    '            'sql = " SELECT DISTINCT T_Commesse.IdCom AS Numero, Format(T_Commesse.DataCambioStato,""Short Date"") AS Data, "
    '            'TD_TipoCommessa.Descrizione, T_Commesse.Copie, T_Commesse.Priorita, T_Risorse_1.Descrizione AS Lastra, 
    '            'IIf(T_Commesse.FronteRetro=True,'F/R','F') AS [F/R], First(T_Risorse.Descrizione) AS Carta"
    '            'sql &= " FROM (T_Risorse AS T_Risorse_1 INNER JOIN ((T_Risorse INNER JOIN (T_Commesse INNER JOIN T_Magaz "
    '            'ON T_Commesse.IdCom = T_Magaz.IdCom) ON T_Risorse.IdRis = T_Magaz.IdRis) INNER JOIN TD_TipoCommessa 
    '            'ON T_Commesse.IdTipoCom = TD_TipoCommessa.IdTipoCom) ON T_Risorse_1.IdRis = T_Commesse.IdRis) INNER JOIN T_CommesseCrono 
    '            'ON (T_CommesseCrono.IdStato = T_Commesse.Stato) AND (T_Commesse.IdCom = T_CommesseCrono.IdCom)"
    '            'sql &= " GROUP BY T_Commesse.IdCom, TD_TipoCommessa.Descrizione, T_Commesse.Copie, T_Commesse.Priorita, T_Risorse_1.Descrizione, "
    '            'T_CommesseCrono.DataCronoInizio, T_CommesseCrono.DataCronoFine, T_Commesse.DataCambioStato, T_Commesse.TipoCom, T_Risorse_1.Codice,
    '            ' T_Commesse.FronteRetro, T_Commesse.Stato"
    '            'sql &= " HAVING (T_CommesseCrono.DataCronoInizio Is Not Null AND T_CommesseCrono.DataCronoFine is null "
    '            'and T_Commesse.Stato=" & enStatoCommessa.Stampa & ") Or T_Commesse.Stato=" & enStatoCommessa.Pronto

    '            sql = "select distinct a.*,cc.idoperatore FROM ("
    '            sql &= "select c.idcom, c.idtipocom, c.idris, c.idlavorazione, c.tipocom, c.datains, c.datacambiostato, c.stato, c.fronteretro, c.numero, c.copie, c.idformato, c.lungo, c.largo, c.macchinastampa, c.costoimpianti, c.costofogliosteso, c.costocarta, c.costototale, c.filepath, Cast(c.annotazioni as NVarchar(Max)) as annotazioni ,c.priorita, c.idModelloCommessa, c.nLastreNecessarie, c.idMacchinario, c.Riassunto, c.IdReparto "
    '            sql &= ",(select top 1 Descrizione from T_Risorse R,T_Magaz M where R.idris = M.IdRis and M.IdCom = C.idcom and m.idut<>0 ) as Risorsa"
    '            sql &= ",(select top 1 Descrizione from T_Risorse R where R.idris = C.idris) as Lastra"
    '            sql &= ",(select top 1 QTa from T_Risorse R,T_Magaz M where R.idris = M.IdRis and M.IdCom = C.idcom and m.idut<>0) as Quantita "
    '            sql &= ",(select Count(Idpostit) FROM T_Postit Pos  WHERE Pos.idcom = c.idcom and Pos.tipomsg <> " & enTipoMessaggio.Automatico & ") as NMsg "
    '            sql &= " from T_Commesse C "
    '            sql &= " Where c.stato IN (" & enStatoCommessa.Pronto & "," & enStatoCommessa.Stampa & ")"

    '            sql &= " and c.idReparto = " & enRepartoWeb.StampaOffset
    '            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

    '            sql &= ") a left join T_CommesseCrono CC "
    '            sql &= " on (CC.IdStato = a.Stato) AND (a.IdCom = cc.IdCom)"
    '            sql &= " WHERE cc.datacronofine is null "
    '            'sql &= " Order by Priorita desc,a.IdCom asc "

    '            myCommand.CommandText = sql
    '            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '            Using myReader As SqlDataReader = myCommand.ExecuteReader()
    '                While myReader.Read
    '                    Dim classe As New CommessaOperatore(CType(myReader, IDataRecord))
    '                    'If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
    '                    'If Not myReader("IdTipoCom") Is DBNull.Value Then classe.IdTipoCom = myReader("IdTipoCom")
    '                    'If Not myReader("IdRis") Is DBNull.Value Then classe.IdRis = myReader("IdRis")
    '                    'If Not myReader("IdLavorazione") Is DBNull.Value Then classe.IdLavorazione = myReader("IdLavorazione")
    '                    'If Not myReader("TipoCom") Is DBNull.Value Then classe.TipoCom = myReader("TipoCom")
    '                    'If Not myReader("DataIns") Is DBNull.Value Then classe.DataIns = myReader("DataIns")
    '                    'If Not myReader("DataCambioStato") Is DBNull.Value Then classe.DataCambioStato = myReader("DataCambioStato")
    '                    'If Not myReader("Stato") Is DBNull.Value Then classe.Stato = myReader("Stato")
    '                    'If Not myReader("FronteRetro") Is DBNull.Value Then classe.FronteRetro = myReader("FronteRetro")
    '                    'If Not myReader("Numero") Is DBNull.Value Then classe.Numero = myReader("Numero")
    '                    'If Not myReader("Copie") Is DBNull.Value Then classe.Copie = myReader("Copie")
    '                    'If Not myReader("IdFormato") Is DBNull.Value Then classe.IdFormato = myReader("IdFormato")
    '                    'If Not myReader("Lungo") Is DBNull.Value Then classe.Lungo = myReader("Lungo")
    '                    'If Not myReader("Largo") Is DBNull.Value Then classe.Largo = myReader("Largo")
    '                    'If Not myReader("MacchinaStampa") Is DBNull.Value Then classe.MacchinaStampa = myReader("MacchinaStampa")
    '                    'If Not myReader("CostoImpianti") Is DBNull.Value Then classe.CostoImpianti = myReader("CostoImpianti")
    '                    'If Not myReader("CostoFoglioSteso") Is DBNull.Value Then classe.CostoFoglioSteso = myReader("CostoFoglioSteso")
    '                    'If Not myReader("CostoCarta") Is DBNull.Value Then classe.CostoCarta = myReader("CostoCarta")
    '                    'If Not myReader("CostoTotale") Is DBNull.Value Then classe.CostoTotale = myReader("CostoTotale")
    '                    'If Not myReader("File") Is DBNull.Value Then classe.File = myReader("File")
    '                    'If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
    '                    'If Not myReader("Priorita") Is DBNull.Value Then classe.Priorita = myReader("Priorita")

    '                    'DATI EXTRA
    '                    If Not myReader("Riassunto") Is DBNull.Value Then classe.TipoCommessaStr = myReader("Riassunto")
    '                    If Not myReader("Risorsa") Is DBNull.Value Then classe.RisorsaStr = myReader("risorsa")
    '                    If Not myReader("Quantita") Is DBNull.Value Then classe.QtaStr = myReader("Quantita")
    '                    If Not myReader("NmSg") Is DBNull.Value Then classe.NumeroMessaggi = myReader("NmSg")
    '                    If Not myReader("Lastra") Is DBNull.Value Then classe.LastraStr = myReader("Lastra")
    '                    If Not myReader("IdOperatore") Is DBNull.Value Then classe.IdOperatore = myReader("IdOperatore")

    '                    L.Add(classe)
    '                End While
    '            End Using
    '        End Using

    '        SortCommesse(L)

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try
    '    Return L
    'End Function

    'Public Function ListaOPFinitCom() As List(Of CommessaOperatore)
    '    Dim L As New List(Of CommessaOperatore)
    '    Try

    '        Using myCommand As SqlCommand = _Cn.CreateCommand()
    '            Dim sql As String = ""

    '            sql = "SELECT l.idcom , first(tc.Descrizione) as TipoCommessa,first(cc.idoperatore) as IdOperatore,"
    '            sql &= " first(l.Descrizione) as Lavorazione,first(l.ordine) as Ordine, first(priorita) as Priorita"
    '            sql &= ",first(select top 1 QTa from T_Risorse R,T_Magaz M where R.idris = M.IdRis and M.IdCom = l.idcom and m.idut<>0) as Quantita, "
    '            sql &= " first(select top 1 Descrizione from T_Risorse R,T_Magaz M where R.idris = M.IdRis and M.IdCom = l.idcom and m.idut<>0 ) as Risorsa"
    '            sql &= "   FROM T_Commesse C,T_CommesseCrono CC, T_LavLog L,  TD_TipoCommessa TC "
    '            sql &= " WHERE C.IdCom = CC.idcom"
    '            sql &= " and c.idtipocom=tc.idtipocom "
    '            sql &= " AND C.stato in( " & enStatoCommessa.Stampa & "," & enStatoCommessa.FinituraSuCommessa & ")"
    '            'sql &= " and not CC.DataCronoFine is null "
    '            sql &= " and L.IdCom = C.IdCom "
    '            'sql &= " and L.DataOraInizio is Null "
    '            sql &= " and c.idcom not in (select idcom from t_lavlog where not dataorainizio is null and dataorafine is null)"
    '            sql &= " group by l.idcom "
    '            ' sql &= " order by first(l.ordine) "
    '            sql &= " Order by l.IdCom asc, first(l.ordine)"

    '            sql = "SELECT l.Idcom,first(l.ordine) FROM T_Commesse C,T_CommesseCrono CC, T_LavLog L,  TD_TipoCommessa TC "
    '            sql &= " WHERE C.IdCom = CC.idcom"
    '            sql &= " and c.idtipocom=tc.idtipocom "
    '            sql &= " AND C.stato in( " & enStatoCommessa.Stampa & "," & enStatoCommessa.FinituraSuCommessa & ")"
    '            'sql &= " and not CC.DataCronoFine is null "
    '            sql &= " and L.IdCom = C.IdCom "
    '            'sql &= " and L.DataOraInizio is Null "
    '            sql &= " and c.idcom not in (select idcom from t_lavlog where not dataorainizio is null and dataorafine is null)"
    '            sql &= " group by l.idcom "
    '            ' sql &= " order by first(l.ordine) "
    '            sql &= " Order by l.IdCom asc, first(l.ordine)"



    '            myCommand.CommandText = sql
    '            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '            Using myReader As SqlDataReader = myCommand.ExecuteReader()
    '                While myReader.Read
    '                    Dim classe As New CommessaOperatore
    '                    'DA RIVEDERE
    '                    classe.Read(myReader("IdCom"))
    '                    'DATI EXTRA
    '                    'If Not myReader("TipoCommessa") Is DBNull.Value Then classe.TipoCommessaStr = myReader("TipoCommessa")
    '                    'If Not myReader("Risorsa") Is DBNull.Value Then classe.RisorsaStr = myReader("risorsa")
    '                    'If Not myReader("Quantita") Is DBNull.Value Then classe.QtaStr = myReader("Quantita")
    '                    'If Not myReader("Macchinario") Is DBNull.Value Then classe.MacchinaStampaStr = myReader("Macchinario")
    '                    'If Not myReader("Lavorazione") Is DBNull.Value Then classe.LavorazioneStr = myReader("Lavorazione")
    '                    'If Not myReader("IdOperatore") Is DBNull.Value Then classe.IdOperatore = myReader("IdOperatore")

    '                    L.Add(classe)
    '                End While
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try
    '    Return L
    'End Function

    Public Function InserisciLog(C As Commessa,
                                 stato As enStatoCommessa,
                                 IdUtenteConnesso As Integer) As Integer

        Dim Ris As Integer = 0

        If C.Stato <> stato Then

            C.Stato = stato
            C.DataCambioStato = Now
            C.Save()

            Using cc As New CronoCommessa
                cc.IdCom = C.IdCom
                cc.DataCronoInizio = Now
                Try
                    cc.IdOperatore = IdUtenteConnesso 'LUNA.LunaContext.IdUtenteConnesso
                Catch ex As Exception

                End Try
                cc.IdStato = stato
                If stato = enStatoCommessa.Completata Then cc.DataCronoFine = Now
                Ris = cc.Save()
            End Using

            'FormerLog.RegistraVoce("COMMESSA " & C.IdCom & " - CAMBIO STATO A " & stato.ToString)
            'Else

            '    Using M As New CronoCommesseDAO
            '        Dim L As List(Of CronoCommessa) = M.FindAll(New LUNA.LunaSearchParameter("idcom", C.IdCom),
            '                                                   New LUNA.LunaSearchParameter("idstato", CInt(stato)))
            '        If L.Count Then
            '            Ris = L(0).IdCrono
            '        End If
            '    End Using

        End If
        'Ris = stato

        Return Ris

    End Function

    Public Sub InserisciLavorazioni(C As Commessa,
                                    Optional CP As CommessaProposta = Nothing)

        Dim Ordine As Integer = 0

        Dim IdLavStampa As Integer = FormerConst.Lavorazioni.StampaRealizzazione
        Dim IdLavTaglio As Integer = FormerConst.Lavorazioni.Taglio

        Dim IdLavAccorpate As New List(Of Integer)
        Dim IdLavGiaControllate As New List(Of Integer)
        For Each O In C.ListaOrdini(True)
            Dim lLav As List(Of Lavorazione) = O.ListaLavori.FindAll(Function(lavoro) lavoro.Accorpabile = enSiNo.Si)

            Dim Listlav As New List(Of Integer)
            For Each l In lLav
                Listlav.Add(l.IdLavoro)
            Next
            Using MgrL As New LavorazioniDAO
                Listlav = MgrL.RiordinaListaLav(Listlav, O.IdListinoBase)
            End Using

            lLav = New List(Of Lavorazione)

            For Each Id In Listlav
                Dim L As New Lavorazione
                L.Read(Id)
                lLav.Add(L)
            Next

            For Each Lav In lLav
                If IdLavGiaControllate.FindAll(Function(x) x = Lav.IdLavoro).Count = 0 Then
                    IdLavGiaControllate.Add(Lav.IdLavoro)
                    If IdLavAccorpate.FindAll(Function(x) x = Lav.IdLavoro).Count = 0 Then
                        'qui devo vedere se sta in tutte le lavorazioni di tutti gli ordini
                        Dim Accorpabile As Boolean = True
                        For Each Ord In C.ListaOrdini.FindAll(Function(x) x.IdOrd <> O.IdOrd)
                            If Ord.ListaLavori.FindAll(Function(x) x.IdLavoro = Lav.IdLavoro).Count = 0 AndAlso C.ListaLavorazioni.FindAll(Function(x) x.IdLavoro = Lav.IdLavoro).Count = 0 Then
                                Accorpabile = False
                                Exit For
                            End If
                        Next
                        If Accorpabile Then
                            IdLavAccorpate.Add(Lav.IdLavoro)
                            'qui prima di salvare devo vedere se sono gia presenti sulla commessa cosi
                            'posso fare lo stesso lavoro a ogni salvataggio
                            Dim lEsist As List(Of LavLog) = Nothing
                            Using mgr As New LavLogDAO
                                lEsist = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.LavLog.IdCom, C.IdCom),
                                                     New LUNA.LunaSearchParameter(LFM.LavLog.Idlav, Lav.IdLavoro))
                            End Using
                            If lEsist.Count = 0 Then
                                Using ll As New LavLog
                                    ll.IdCom = C.IdCom
                                    ll.Descrizione = Lav.Descrizione
                                    ll.Premio = Lav.Premio
                                    ll.Tempo = Lav.TempoRif
                                    ll.Ordine = Ordine
                                    ll.Idlav = Lav.IdLavoro

                                    If Lav.Categoria.TipoCaratteristica = enSiNo.Si Then
                                        ll.DataOraInizio = O.DataIns
                                        ll.DataOraFine = O.DataIns.AddMinutes(1)
                                        ll.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
                                    End If

                                    Dim IdMacchinarioDaUsare As Integer = Lav.IdMacchinario
                                    Dim DescrMacchinarioDaUsare As String = Lav.Macchinario
                                    Dim TrovatoMacchinario As Boolean = False
                                    If Lav.IdLavoro = FormerConst.Lavorazioni.StampaRealizzazione Then
                                        If O.ListinoBase.IdMacchinarioProduzione Then
                                            Using m As New Macchinario
                                                m.Read(O.ListinoBase.IdMacchinarioProduzione)
                                                IdMacchinarioDaUsare = m.IdMacchinario
                                                DescrMacchinarioDaUsare = m.Descrizione
                                                TrovatoMacchinario = True
                                            End Using
                                        End If
                                    ElseIf Lav.IdLavoro = FormerConst.Lavorazioni.Taglio Then
                                        If O.ListinoBase.IdMacchinarioTaglio Then
                                            Using m As New Macchinario
                                                m.Read(O.ListinoBase.IdMacchinarioTaglio)
                                                IdMacchinarioDaUsare = m.IdMacchinario
                                                DescrMacchinarioDaUsare = m.Descrizione
                                            End Using
                                        End If
                                    End If
                                    'If C.IdReparto = enRepartoWeb.StampaOffset Or C.IdReparto = enRepartoWeb.Packaging Then
                                    If C.IdModelloCommessa Then
                                        Using m As New Macchinario
                                            If Lav.IdLavoro = FormerConst.Lavorazioni.Taglio Then
                                                If C.ModelloCommessa.IdMacchinarioTaglioDef Then
                                                    m.Read(C.ModelloCommessa.IdMacchinarioTaglioDef)
                                                    IdMacchinarioDaUsare = m.IdMacchinario
                                                    DescrMacchinarioDaUsare = m.Descrizione
                                                End If
                                            ElseIf Lav.IdLavoro = FormerConst.Lavorazioni.StampaRealizzazione Then
                                                If (C.IdReparto = enRepartoWeb.StampaOffset Or C.IdReparto = enRepartoWeb.Packaging) OrElse
                                                    TrovatoMacchinario = False Then
                                                    If C.ModelloCommessa.IdMacchinarioDef Then
                                                        m.Read(C.ModelloCommessa.IdMacchinarioDef)
                                                        IdMacchinarioDaUsare = m.IdMacchinario
                                                        DescrMacchinarioDaUsare = m.Descrizione
                                                    End If
                                                End If
                                            End If
                                        End Using
                                    End If
                                    'End If

                                    If Not CP Is Nothing AndAlso
                                        CP.Ordini.Count AndAlso
                                        CP.ModelloCommessa.IdReparto <> CP.Ordini(0).Ordine.IdTipoProd Then

                                        If Lav.IdLavoro = FormerConst.Lavorazioni.StampaRealizzazione Then
                                            IdMacchinarioDaUsare = CP.ModelloCommessa.IdMacchinarioDef
                                            DescrMacchinarioDaUsare = CP.ModelloCommessa.MacchinarioNome
                                        End If

                                    End If

                                    ll.Macchinario = DescrMacchinarioDaUsare
                                    ll.IdMacchinario = IdMacchinarioDaUsare
                                    ll.Save()
                                End Using
                            End If

                            Ordine += 1
                        End If
                    End If
                End If
            Next
        Next

        'qui ciclo di nuovo dentro tutti gli ordini per ogni lavorazione accorpata e le cancello dalla lavlog
        For Each SingLav In IdLavAccorpate
            For Each SingO In C.ListaOrdini
                Using mgr As New LavLogDAO
                    mgr.DeleteByIdLav(SingLav, SingO.IdOrd)
                End Using
            Next
        Next

        'anche qui il taglio devo vedere prima se c'e' 

        'Dim lEsistTaglio As List(Of LavLog) = Nothing
        'Using mgr As New LavLogDAO
        '    lEsistTaglio = mgr.FindAll(New LUNA.LunaSearchParameter("IdCom", C.IdCom), _
        '                         New LUNA.LunaSearchParameter("IdLav", IdLavTaglio))
        'End Using

        ''GESTISCO IL TAGLIO
        'If lEsistTaglio.Count = 0 Then
        '    Using lavTaglio As New Lavorazione
        '        lavTaglio.Read(IdLavTaglio)
        '        Using llTaglio As New LavLog
        '            llTaglio.Macchinario = lavTaglio.Macchinario
        '            llTaglio.IdCom = C.IdCom
        '            llTaglio.Descrizione = lavTaglio.Descrizione
        '            llTaglio.Premio = lavTaglio.Premio
        '            llTaglio.Tempo = lavTaglio.TempoRif
        '            llTaglio.Ordine = Ordine
        '            llTaglio.Idlav = lavTaglio.IdLavoro
        '            llTaglio.Save()
        '        End Using
        '    End Using
        'End If
        'Dim Dt As DataTable, Dr As DataRow

        'Using x As New cLavoriColl
        '    Dt = x.ListaCommessaSel(C.IdTipoCom)
        'End Using
        'For Each Dr In Dt.Rows
        '    Dim ll As New LavLog
        '    ll.Macchinario = Dr("Macchinario").ToString
        '    ll.IdCom = C.IdCom
        '    ll.Descrizione = Dr("Descrizione").ToString
        '    ll.Premio = Dr("Premio")
        '    ll.Tempo = Dr("TempoRif")
        '    ll.Ordine = Dr("Ordine")
        '    ll.Idlav = Dr("IdLavoro")
        '    ll.Save()
        'Next
    End Sub

    Public Function AvanzamentoLavori(C As Commessa) As DataTable
        Dim datatb As DataTable = New DataTable("T_CommesseCrono")
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "select DataCronoInizio as [Iniziato il], DataCronoFine as [Finito il], "

                sql &= "(select case idstato when " & enStatoCommessa.Preinserito & " then 'Preinserito' "
                sql &= " when " & enStatoCommessa.Pronto & " then 'Pronto' "
                sql &= " when " & enStatoCommessa.Stampa & " then 'Stampa' "
                sql &= " when " & enStatoCommessa.FinituraSuCommessa & " then 'Finitura su commessa' "
                sql &= " when " & enStatoCommessa.FinituraSuProdotti & " then 'Finitura su prodotti' "
                sql &= " when " & enStatoCommessa.Completata & " then 'Completata'"

                sql &= " end ) as [Stato]"

                sql &= ", Login as Operatore from T_CommesseCrono c inner join t_utenti U on c.idoperatore = u.idut"
                'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
                sql &= " where idcom = " & C.IdCom
                sql &= " order by datacronoInizio"
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    datatb.Load(myReader)
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return datatb

    End Function

    Public Function SalvaOrdiniTornaEsclusi(C As Commessa) As List(Of Integer)

        Dim ListaIdEsclusi As New List(Of Integer)

        If C.Stato = enStatoCommessa.Preinserito Then

            Dim listaId As String = ""

            Dim I As Integer = 0

            For I = 0 To C.ListaIdOrdini.GetUpperBound(0)

                listaId &= C.ListaIdOrdini(I) & ","

            Next

            listaId = listaId.TrimEnd(",")

            Dim ListaNuoviId As List(Of Integer) = C.ListaIdOrdini.ToList

            Dim OrdEliminati As Integer = 0
            For Each o As Ordine In C.ListaOrdini

                If ListaNuoviId.FindAll(Function(x) x = o.IdOrd).Count = 0 Then

                    ListaIdEsclusi.Add(o.IdOrd)

                    OrdEliminati += 1
                    Dim listLav As New List(Of Integer)
                    'qui l'ordine che c'era non ce sta piu lo devo resettare e rimettergli le lavorazioni accorpate
                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, o.IdOrd, "ELIMINATO DA COMMESSA " & C.IdCom)
                    o.IdCom = 0
                    o.Stato = enStatoOrdine.Registrato
                    o.Save()

                    Using mgr As New OrdiniDAO
                        mgr.AvanzaOrdiniAStatoByIdOrd(o.IdOrd, enStatoOrdine.Registrato)
                    End Using

                    Using mgrL As New LavLogDAO

                        Dim lOld As List(Of LavLog) = mgrL.FindAll(LFM.LavLog.Ordine,
                                                                   New LUNA.LunaSearchParameter(LFM.LavLog.IdCom, C.IdCom))
                        For Each singlav As LavLog In lOld
                            Using singL As New Lavorazione
                                singL.Read(singlav.Idlav)
                                If singL.Accorpabile = enSiNo.Si Then
                                    listLav.Add(singlav.Idlav)
                                End If
                            End Using
                        Next
                    End Using

                    If listLav.Count Then
                        o.ListaLavorazioniCustom = listLav.ToArray
                        o.SaveFirstTime() 'chiamo la saveex per far reinserire le lavorazioni
                    End If
                End If
            Next

            If OrdEliminati <> 0 And (OrdEliminati = C.ListaOrdini.Count) Then
                'qui devo cancellare tutte le lavorazioni su commessa perche evidentemente tutti gli ordini che c'erano dentro sono stati rimossi 

                Using mgrL As New LavLogDAO
                    mgrL.DeleteByIdCom(C.IdCom)
                End Using

            End If

            For Each SingId In ListaNuoviId
                If C.ListaOrdini.FindAll(Function(xxx) xxx.IdOrd = SingId).Count = 0 Then

                    'questo e' un ordine che prima non c'era 
                    Using o As New Ordine
                        o.Read(SingId)
                        o.IdCom = C.IdCom

                        'o.Stato = enStatoOrdine.InCodaDiStampa
                        o.Save()

                        Using mgr As New OrdiniDAO
                            mgr.AvanzaOrdiniAStatoByIdOrd(o.IdOrd, enStatoOrdine.InCodaDiStampa)
                        End Using

                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, o.IdOrd, "REGISTRATO SU COMMESSA " & C.IdCom)
                    End Using

                End If
            Next

            'Dim sql As String = String.Empty
            'Using DbCommand As SqlCommand = New SqlCommand()
            '    DbCommand.Connection = _Cn

            '    sql = "update T_Ordini set idcom=0, stato=" & enStatoOrdine.Registrato & " where idcom= " & C.IdCom

            '    DbCommand.CommandText = sql
            '    If Not LUNA.LunaContext.TransactionBox Is Nothing Then DbCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            '    DbCommand.ExecuteNonQuery()

            '    sql = "update T_Ordini set idcom=" & C.IdCom & ", stato = " & enStatoOrdine.InCodaDiStampa & "  where idord in(" & listaId & ")"

            '    DbCommand.CommandText = sql
            '    If Not LUNA.LunaContext.TransactionBox Is Nothing Then DbCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            '    DbCommand.ExecuteNonQuery()

            'End Using

        End If

        Return ListaIdEsclusi

    End Function

    Public Sub SalvaMovMagaz(C As Commessa)

        If C.Stato = enStatoCommessa.Preinserito Then

            Dim sql As String = String.Empty

            If C.IdCom Then
                Using Mgr As New MagazzinoDAO
                    Dim lOldMov As List(Of MovimentoMagazzino) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdCom, C.IdCom))

                    For Each m As MovimentoMagazzino In lOldMov
                        Dim IdRis As Integer = m.IdRis
                        Mgr.Delete(m.IdCarMag)

                        Using mgrMag As New MagazzinoDAO

                            Mgr.AggiornaQta(IdRis)

                        End Using
                    Next

                End Using
            End If


            Using DbCommand As SqlCommand = New SqlCommand()
                DbCommand.Connection = _Cn

                sql = "DELETE FROM T_Magaz WHERE idcom = " & C.IdCom

                DbCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then DbCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                DbCommand.ExecuteNonQuery()

            End Using

            For Each x In C.MovMagaz

                x.IdCom = C.IdCom
                x.Save()
                'x.AggiornaQta(0, x.Qta)

            Next

            'scarico le lastre 
            If C.IdRis Then
                Using mov As New MovimentoMagazzino
                    Dim Ris As New Risorsa

                    Ris.Read(C.IdRis)

                    mov.IdRis = C.IdRis
                    mov.Qta = C.NLastreNecessarie
                    mov.TipoMov = enTipoMovMagaz.Prenotazione
                    mov.IdCom = C.IdCom
                    mov.DataMov = Date.Now
                    mov.Save()
                    'x.AggiornaQta(0, x.Qta)

                End Using
            End If

        End If

    End Sub

    Private Sub SortCommesse(ByRef lst As List(Of CommessaOperatore))

        lst.Sort(AddressOf Comparer)

    End Sub

    Public Function CreaCommessaAutomaticaOffset(CP As CommessaProposta) As Integer

        Dim ris As Integer = 0

        'creo in automatico la commessa perfetta 
        Dim ListaIdOrdini(CP.Ordini.Count - 1) As Integer
        Dim Posizione As Integer = 0

        Dim NoteGenerali As String = String.Empty
        Dim ListaOrdini As New List(Of Ordine)

        For Each ord As OrdineInSoluzione In CP.Ordini

            ListaIdOrdini(Posizione) = ord.IdOrd
            Posizione += 1

            If ord.Ordine.Annotazioni.Length Then
                NoteGenerali &= "Ordine: " & ord.IdOrd & " - " & ord.Ordine.Annotazioni & ";" & ControlChars.NewLine
            End If
            ListaOrdini.Add(ord.Ordine)
        Next

        Dim IdRisorsaLastre As Integer = 0
        Using mgr As New RisorseDAO
            Dim risorsaLastra As Risorsa = mgr.GetLastraPerMacchinario(CP.ModelloCommessa.IdMacchinarioDef)

            If Not risorsaLastra Is Nothing Then
                IdRisorsaLastre = risorsaLastra.IdRis
            End If

        End Using

        Dim NLastreNecessarie As Integer = 0

        NLastreNecessarie = GetLastreNecessarie(CP.ModelloCommessa, ListaIdOrdini)

        Dim Tiratura As Integer = CP.TiraturaEffettiva
        'CALCOLARE LA TIRATURA

        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox()
            Try

                Using C As New Commessa
                    C.Riassunto = GetNomeRiassuntivo(ListaIdOrdini)
                    C.ListaIdOrdini = ListaIdOrdini
                    C.NLastreNecessarie = NLastreNecessarie
                    C.IdRis = IdRisorsaLastre
                    C.IdFormato = CP.ModelloCommessa.IdFormatoMacchina
                    C.FronteRetro = CP.ModelloCommessa.FronteRetro
                    C.IdLavorazione = 0 'non necessario
                    C.IdTipoCom = 0 'non necessario
                    C.TipoCom = CP.ModelloCommessa.IdReparto
                    C.DataIns = Now
                    C.Stato = enStatoCommessa.Preinserito
                    C.Copie = Tiratura 'O.Qta
                    C.Annotazioni = NoteGenerali
                    C.IdReparto = CP.ModelloCommessa.IdReparto
                    C.IdMacchinario = CP.ModelloCommessa.IdMacchinarioDef
                    C.MacchinaStampa = CP.ModelloCommessa.MacchinarioNome
                    C.Lungo = 0 'O.Lungo  'non necessario
                    C.Largo = 0 'O.Largo  'non necessario
                    C.IdModelloCommessa = CP.ModelloCommessa.IdModello
                    C.Segnature = CalcolaSegnature(ListaOrdini, CP.ModelloCommessa)
                    C.CreataAutomaticamente = enSiNo.Si

                    Dim lMov As New List(Of MovimentoMagazzino)

                    Dim RisorsaPredef As List(Of Risorsa) = GetRisorsaDefault(ListaIdOrdini, CP.ModelloCommessa)

                    If RisorsaPredef.Count Then
                        Using PrimaRisorsa As Risorsa = RisorsaPredef(0)
                            Using fm As New Formato
                                fm.Read(C.IdFormato)
                                Dim QuantiEntrano As Integer = PrimaRisorsa.QuantiNeEntranoInFormatoMacchina(fm)
                                If QuantiEntrano = 0 Then QuantiEntrano = 1
                                C.SoggettiFoglio = QuantiEntrano
                            End Using
                        End Using
                    End If

                    For Each R In RisorsaPredef
                        Dim mov As New MovimentoMagazzino
                        mov.IdRis = R.IdRis
                        mov.Qta = CalcolaQtaRisorsaNecessaria(C.IdReparto,
                                                                      C.IdFormato,
                                                                      Tiratura,
                                                                      R.IdRis)
                        mov.TipoMov = enTipoMovMagaz.Prenotazione
                        mov.DataMov = Date.Now
                        mov.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin

                        lMov.Add(mov)
                    Next

                    C.MovMagaz = lMov

                    tb.TransactionBegin()
                    ris = C.Save()

                    InserisciLog(C, enStatoCommessa.Preinserito, 0)

                    'QUI DEVO SALVARE GLI ORDINI NELLA COMMESSA E SPOSTARE I FILE 
                    SalvaOrdiniTornaEsclusi(C)

                    SalvaMovMagaz(C)

                    For Each r In RisorsaPredef

                        If r.Giacenza <= r.GiacenzaMin Then
                            If Not r.RegolaSottoScorta Is Nothing Then
                                Using mgr As New AzioniSottoscortaDAO
                                    mgr.ApplicaRegolaSottoscorta(r.RegolaSottoScorta)
                                End Using
                            End If
                        End If
                    Next

                    InserisciLavorazioni(C, CP)

                    tb.TransactionCommit()

                    Try
                        SalvaFile(C)
                    Catch ex As Exception
                        'qui si e' verificato un errore nello spostamento dei file 
                        'non potendo fare il rollback 
                        'mando una mail automatica a me e andrea dicendo per quali ordini c'e' stato un problema
                        FormerHelper.Mail.InviaMail("Errore creazione automatica Commessa",
                                                        "Per la commessa " & ris & " si è verificato un errore nella copia dei file sorgente. Spostarli manualmente ", "soft@tipografiaformer.it;stampa@tipografiaformer.it")

                    End Try

                End Using

            Catch ex As Exception
                tb.TransactionRollBack()

                FormerHelper.Mail.InviaMail("Errore creazione automatica Commessa",
                                                "Per la commessa " & ris & " si è verificato un errore: " & ex.Message,
                                                "soft@tipografiaformer.it")
            End Try
        End Using

        Return ris
    End Function

    Public Function CreaCommessaAutomaticaNonOffset(O As Ordine) As Integer

        Dim Ris As Integer = 0

        If O.Stato = enStatoOrdine.Registrato Then 'AGGIUNTO PER CREARLE SOLO PER GLI ORDINI CHE HANNO PASSATO LA PRIMA VALIDAZIONE
            If O.IdTipoProd <> enRepartoWeb.StampaOffset And O.IdTipoProd <> enRepartoWeb.Packaging Then

                Dim Mc As ModelloCommessa = Nothing

                'CERCO IL MODELLO DI COMMESSA ADEGUATO. CHE IN TEORIA E' SEMPRE UNO SOLO 
                Dim IdMacchinarioDaUsare As Integer = 0
                Dim MacchinarioDaUsare As String = String.Empty

                Dim L As List(Of ModelloCommessa) = Nothing
                Using mgr As New ModelliCommessaDAO
                    L = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ModelloCommessa.IdReparto, O.IdTipoProd))
                    If L.Count Then
                        Mc = L(0)
                        IdMacchinarioDaUsare = Mc.IdMacchinarioDef
                        MacchinarioDaUsare = Mc.MacchinarioNome
                    End If
                End Using

                If O.ListinoBase.IdMacchinarioProduzione Then
                    Using m As New Macchinario
                        m.Read(O.ListinoBase.IdMacchinarioProduzione)
                        IdMacchinarioDaUsare = m.IdMacchinario
                        MacchinarioDaUsare = m.Descrizione

                    End Using
                End If

                Dim QtaComm As Integer = O.Qta
                Dim NumeroSoggettiCalcolati As Integer = 1

                'MODIFICATA PER SPOSTAMENTO QTA SU ORDINE E NON PRODOTTO
                'If O.ListinoBase.Preventivazione.IdReparto = enRepartoWeb.Ricamo Or
                '    O.ListinoBase.Preventivazione.IdReparto = enRepartoWeb.Etichette Then
                '    QtaComm = O.Prodotto.NumPezzi
                'End If
                If Not Mc Is Nothing Then 'AndAlso Not RisorsaPredef Is Nothing Then
                    Dim tc As TipoCarta = O.Prodotto.ListinoBase.TipoCarta
                    Dim RisorsaPredef As Risorsa = Nothing

                    Using mgr As New RisorseDAO
                        Dim lR As List(Of Risorsa) = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = LFM.Risorsa.Giacenza.Name},
                                                             New LUNA.LunaSearchParameter(LFM.Risorsa.IdTipoCarta, tc.IdTipoCarta),
                                                             New LUNA.LunaSearchParameter(LFM.Risorsa.Stato, enStato.Attivo))
                        For Each voce In lR
                            Dim NumeroSoggettiNecessari As Integer = voce.QuantiNeEntranoInFormatoMacchina(Mc.FormatoMacchina)

                            If NumeroSoggettiNecessari < 1 Then NumeroSoggettiNecessari = 1
                            Dim QtaNecessaria As Integer = 0

                            Try
                                QtaNecessaria = Math.Ceiling(QtaComm / NumeroSoggettiNecessari)
                            Catch ex As Exception

                            End Try

                            If voce.Giacenza - QtaNecessaria >= 0 Then
                                RisorsaPredef = voce
                                Exit For
                            End If
                        Next
                    End Using

                    If Not RisorsaPredef Is Nothing Then
                        If O.ListinoBase.TipoPrezzo = enTipoPrezzo.SuQuantita Then
                            'ORA QUI DEVO RIADATTARE NUMEROSOGGETTICALCOLATI E QUANTITA COMMESSA 

                            NumeroSoggettiCalcolati = RisorsaPredef.QuantiNeEntranoInFormatoMacchina(Mc.FormatoMacchina)
                            If NumeroSoggettiCalcolati > 1 Then
                                Try
                                    QtaComm = Math.Ceiling(QtaComm / NumeroSoggettiCalcolati)
                                Catch ex As Exception

                                End Try

                            End If
                        End If
                    End If

                    Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox

                        Try
                            '**********************************
                            '*****CREAZIONE AUTOMATICA COMMESSA
                            '**********************************
                            Using C As New Commessa
                                C.Riassunto = O.ListinoBase.NomeEx
                                C.NLastreNecessarie = 0 'non necessario
                                C.IdRis = 0 'id risorsa delle lastre non necessaria
                                C.IdFormato = Mc.IdFormatoMacchina
                                C.FronteRetro = Mc.FronteRetro
                                C.IdLavorazione = 0 'non necessario
                                C.IdTipoCom = 0 'non necessario
                                C.TipoCom = O.IdTipoProd
                                C.DataIns = Now
                                C.Stato = enStatoCommessa.Preinserito
                                C.Copie = QtaComm
                                C.Annotazioni = O.Annotazioni
                                C.IdReparto = O.IdTipoProd
                                C.IdMacchinario = IdMacchinarioDaUsare
                                C.MacchinaStampa = MacchinarioDaUsare
                                C.Lungo = O.Lungo
                                C.Largo = O.Largo
                                C.IdModelloCommessa = Mc.IdModello
                                C.CreataAutomaticamente = enSiNo.Si
                                C.SoggettiFoglio = NumeroSoggettiCalcolati
                                C.Segnature = 1

                                tb.TransactionBegin()

                                C.Save()

                                O.IdCom = C.IdCom
                                O.Save()

                                Ris = C.IdCom

                                'Using M As New F.CommesseDAO

                                'If swFirst Then 'questo lo devo fare per forza prima il salvataggio degli ordini
                                InserisciLog(C, enStatoCommessa.Preinserito, 0)

                                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "REGISTRATO SU COMMESSA " & C.IdCom)

                                'ListaOrdEsclusi = M.SalvaOrdiniTornaEsclusi(com)
                                'M.SalvaMovMagaz(C)

                                'If swFirst Then 'questo lo devo fare per forza dopo il salvataggio degli ordini
                                InserisciLavorazioni(C)
                                'End If

                                'End Using

                                If Not RisorsaPredef Is Nothing Then

                                    '? QUESTO NON SO SICURO
                                    'C.IdRis = RisorsaPredef.IdRis
                                    'C.Save()

                                    'qui devo calcolare la qta necessaria
                                    Dim qtaNeces As Single = QtaComm

                                    If O.IdTipoProd = enRepartoWeb.StampaDigitale Then

                                        If O.ListinoBase.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
                                            'qui invece devo sviluppare i metri quadri 
                                            qtaNeces = MgrCalcoliTecnici.CalcolaMq(O.ListinoBase.FormatoProdotto.FormatoCarta.Larghezza,
                                                                                   O.Qta,
                                                                                   O.Lungo,
                                                                                   O.Largo).AreaCalcolata


                                            qtaNeces = MgrMagazzino.GetQtaScarico(C, RisorsaPredef)
                                        End If

                                    End If

                                    '

                                    If qtaNeces Then
                                        'qu ho la risorsa predefinita, devo vedere la giacenza e se ci sono regole per il sottoscorta
                                        Using mov As New MovimentoMagazzino
                                            mov.IdRis = RisorsaPredef.IdRis
                                            mov.Qta = qtaNeces
                                            mov.TipoMov = enTipoMovMagaz.Prenotazione
                                            mov.IdCom = C.IdCom
                                            mov.DataMov = Date.Now
                                            mov.Save()
                                        End Using

                                        If RisorsaPredef.Giacenza <= RisorsaPredef.GiacenzaMin Then
                                            If Not RisorsaPredef.RegolaSottoScorta Is Nothing Then
                                                Using mgr As New AzioniSottoscortaDAO
                                                    mgr.ApplicaRegolaSottoscorta(RisorsaPredef.RegolaSottoScorta)
                                                End Using
                                            End If
                                        End If
                                    End If


                                End If

                                tb.TransactionCommit()

                                Try
                                    SalvaFile(C)
                                Catch ex As Exception
                                    'qui si e' verificato un errore nello spostamento dei file 
                                    'non potendo fare il rollback 
                                    'mando una mail automatica a me e andrea dicendo per quali ordini c'e' stato un problema
                                    FormerHelper.Mail.InviaMail("Errore creazione automatica Commessa NON OFFSET",
                                                            "Per la commessa " & Ris & " si è verificato un errore nella copia dei file sorgente: " & ex.Message & ". Spostarli manualmente ", "soft@tipografiaformer.it;stampa@tipografiaformer.it")

                                End Try

                            End Using

                        Catch ex As Exception
                            tb.TransactionRollBack()

                            FormerHelper.Mail.InviaMail("Errore creazione automatica Commessa NON OFFSET",
                                                    "Per la commessa " & Ris & " si è verificato un errore: " & ex.Message,
                                                    "soft@tipografiaformer.it")

                        End Try
                    End Using

                End If

            End If
        End If

        Return Ris

    End Function

    Private Function Comparer(ByVal x As CommessaOperatore, ByVal y As CommessaOperatore) As Integer
        Dim result As Integer = y.Priorita.CompareTo(x.Priorita)
        If result = 0 Then result = x.DataMinoreConsegna.CompareTo(y.DataMinoreConsegna)
        If result = 0 Then result = y.HaAlmenoUnOrdineFast.CompareTo(x.HaAlmenoUnOrdineFast)
        If result = 0 Then result = x.IdCom.CompareTo(y.IdCom)
        Return result
    End Function

    Private Function Comparer(ByVal x As CommessaOperatoreNoImg, ByVal y As CommessaOperatoreNoImg) As Integer
        Dim result As Integer = y.Priorita.CompareTo(x.Priorita)
        If result = 0 Then result = x.DataMinoreConsegna.CompareTo(y.DataMinoreConsegna)
        If result = 0 Then result = y.HaAlmenoUnOrdineFast.CompareTo(x.HaAlmenoUnOrdineFast)
        If result = 0 Then result = x.IdCom.CompareTo(y.IdCom)
        Return result
    End Function

End Class