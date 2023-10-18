#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Imports FormerLib
Imports System.IO
Imports FormerBusinessLogicInterface
Imports FormerConfig
Imports FormerIO
''' <summary>
'''DAO Class for table T_ordini
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class OrdiniDAO
    Inherits _OrdiniDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function SganciaOrdineDaDoc(ByVal IdOrd As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "update T_Ordini set iddoc = 0"
                Sql &= " Where IdOrd = " & IdOrd
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using


        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function AssociaOrdiniADoc(ByVal IdOrd As Integer, ByVal IdDoc As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "UPDATE T_Ordini SET iddoc = " & IdDoc
                Sql &= " WHERE IdOrd = " & IdOrd
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using


        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Sub InserisciLavorazioni(O As Ordine)

        'If O.UsaLavorazioniDefault = False Then
        'qui devo salvare le lavorazioni custom vengono dalla form 
        Using lMgr As New LavLogDAO
            lMgr.DeleteByIdOrd(O.IdOrd)
        End Using
        Dim Ordine As Integer = 1

        Dim ListaLavorazioni As New List(Of Lavorazione)

        For Each Id As Integer In O.ListaLavorazioniCustom

            If Id Then
                Dim lav As New Lavorazione
                lav.Read(Id)

                ListaLavorazioni.Add(lav)
            End If

        Next

        'DISATTIVATO PER LASCIARE l'ORDINAMENTO IMPOSTATO NEL LISTINOBASE E NON DALL'ORDINE DELLE CATEGORIE
        'ListaLavorazioni.Sort(Function(x, y) x.Categoria.OrdineEsecuzione.CompareTo(y.Categoria.OrdineEsecuzione))

        For Each Lav As Lavorazione In ListaLavorazioni
            Using mgr As New LavLogDAO
                Dim lGia As List(Of LavLog) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", O.IdOrd),
                                                          New LUNA.LunaSearchParameter("IdLav", Lav.IdLavoro))
                If lGia.Count = 0 Then

                    'per ogni lavorazione inserita devo ricalcolare il macchinario

                    Dim AltezzaF As Integer = 0
                    Dim LarghezzaF As Integer = 0

                    If O.ListinoBase.TipoPrezzo = enTipoPrezzo.SuMetriQuadri AndAlso O.ListinoBase.ConSoggettiDuplicati = enSiNo.Si Then
                        'altezza e larghezza mi arrivano in cm , li devo convertire in mm
                        AltezzaF = O.Lungo * 10
                        LarghezzaF = O.Largo * 10
                    End If

                    Dim NomeMacchinario As String = Lav.Macchinario

                    Dim Ris As RisCalcoloPrezzoLavorazione = Nothing

                    If Lav.SePresenteCalcolaSuSoggetti = enSiNo.Si And O.ListinoBase.ConSoggettiDuplicati = enSiNo.Si Then
                        Ris = MgrPreventivazioneB.CalcolaPrezzoLavorazione(O.Qta,
                                                                            Lav,
                                                                            O.ListinoBase,
                                                                            O.ListinoBase.TipoCarta,,,
                                                                            True,
                                                                            LarghezzaF,
                                                                            AltezzaF)
                    Else
                        Ris = MgrPreventivazioneB.CalcolaPrezzoLavorazione(O.Qta,
                                                                            Lav,
                                                                            O.ListinoBase,
                                                                            O.ListinoBase.TipoCarta,,,
                                                                            True)
                    End If


                    If Ris.IdMacchinario <> Lav.IdMacchinario Then
                        Using m As New Macchinario
                            m.Read(Ris.IdMacchinario)
                            NomeMacchinario = m.Descrizione
                        End Using
                    End If
                    'in ris ho l'id del macchinario da utilizzare


                    Using L As New LavLog
                        L.IdOrd = O.IdOrd
                        L.Descrizione = Lav.Descrizione
                        L.Macchinario = NomeMacchinario
                        L.IdMacchinario = Ris.IdMacchinario 'Lav.IdMacchinario
                        L.Premio = Lav.Premio
                        L.Tempo = Lav.TempoRif
                        L.Ordine = Ordine
                        L.Idlav = Lav.IdLavoro
                        'QUI DEVO METTERE PER LE LAVORAZIONI DI TIPO CARATTERISTICA DATA E ORA DI INIZIO E FINE GIA FATTE
                        'IN MODO CHE NON CI SIA DA FARLE IN MODALITA OPERATORE
                        If Lav.Categoria.TipoCaratteristica = enSiNo.Si Then
                            L.DataOraInizio = O.DataIns
                            L.DataOraFine = O.DataIns.AddMinutes(1)
                            L.IdUt = FormerConst.UtentiSpecifici.IdUtenteAdmin
                        End If
                        L.Save()
                    End Using
                    Ordine += 1
                End If
            End Using
        Next

    End Sub

    Public Sub InserisciLog(IdOrd As Integer,
                            ByVal Nuovostato As enStatoOrdine,
                            Optional IdInseritoDa As Integer = 0,
                            Optional ModificaConsegna As Boolean = True)
        Using O As New Ordine
            O.Read(IdOrd)
            If O.IdOrd Then InserisciLog(O, Nuovostato, IdInseritoDa, ModificaConsegna)
        End Using
    End Sub

    Public Function ImportoTotaleOrdiniNelPeriodo(IdRub As Integer,
                                                  Periodo As enPeriodoRiferimento) As Integer
        Dim ris As Integer = 0

        Dim l As List(Of Ordine) = Nothing

        Dim Sql As String = "SELECT 0+Sum(TotaleForn+Ricarico-Sconto)as tot FROM t_ordini WHERE idrub=" & IdRub & " AND datediff(m,datains,getdate()) <= " & CInt(Periodo)

        'l = GetData(Sql)

        Using myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Using myReader As SqlDataReader = myCommand.ExecuteReader()
                If myReader.Read AndAlso IsDBNull(myReader("tot")) = False Then
                    ris = myReader("tot")
                End If
            End Using
        End Using

        'For Each O As Ordine In l
        '    ris += O.TotaleImponibile
        'Next

        Return ris
    End Function

    Public Sub QtaPiuVendutaListinoBase(ByRef Ris() As Integer,
                                        IdListinoBase As Integer,
                                        Optional NGiorni As Integer = 365)
        Dim Sql As String = "select top 3 o.qta, count(*) as totale from T_Ordini o, T_Prodotti p where o.IdProd = p.IdProd and p.IdListinoBase = " &
            IdListinoBase & "AND datediff(d,o.datains,getdate()) <= " & NGiorni & " group by o.qta ORDER by totale desc"

        Using myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Using myReader As SqlDataReader = myCommand.ExecuteReader()
                Dim indice As Integer = 0

                While myReader.Read
                    'Dim P As New Prodotto
                    'P.Read(myReader("IdProd"))
                    Dim QtaTrovata As Integer = myReader("qta")

                    Dim GiaPresente As Boolean = False
                    If Ris(0) = QtaTrovata Then
                        GiaPresente = True
                    End If
                    If Ris(1) = QtaTrovata Then
                        GiaPresente = True
                    End If
                    If Ris(2) = QtaTrovata Then
                        GiaPresente = True
                    End If

                    If GiaPresente = False Then
                        Ris(indice) = QtaTrovata
                        indice += 1
                    End If
                End While

            End Using
        End Using

    End Sub

    Public Function NumeroTotaleOrdiniListinoBase(IdListinoBase As Integer, Optional NGiorni As Integer = 365) As Integer
        Dim ris As Integer = 0

        Dim l As List(Of Ordine) = Nothing

        Dim Sql As String = "SELECT o.* FROM t_ordini o, t_prodotti p WHERE o.idprod = p.idprod AND p.idlistinobase = " & IdListinoBase & " and datediff(d,datains,getdate()) <= " & NGiorni

        l = GetData(Sql)

        ris = l.Count

        Return ris
    End Function

    Public Function ListaOrdiniConsegnaOggiDaSpostare() As List(Of Ordine)

        Dim Ris As List(Of Ordine) = Nothing
        Dim DataRif As Date = Now.Date

        Dim Sql As String = "Select o.* from t_ordini o, tr_Consord co, t_cons c where o.idord = co.idord and co.idcons = c.idcons and (o.stato < " &
            enStatoOrdine.UscitoMagazzino & " and o.stato <> " & enStatoOrdine.InSospeso & ") AND datediff(d," & FormerHelper.Stringhe.FormattaDataPerSQL(DataRif) & ",c.giorno) between -3 and 0 order by c.giorno desc,o.idord"
        'mODIFICATO DA <=0 a = 0 
        Ris = GetData(Sql)

        Return Ris

    End Function

    Public Function ListaOrdiniConsegnaDaSganciare(IdCons As Integer) As List(Of Ordine)

        Dim Ris As List(Of Ordine) = Nothing

        'CAMBIATO DA DIVERSO A MINORE USCITOMAGAZZINO 19/02/2014
        Dim Sql As String = "SELECT o.* FROM t_ordini o, tr_Consord co WHERE o.idord = co.idord and o.stato < " & enStatoOrdine.UscitoMagazzino & " AND co.idcons = " & IdCons

        Ris = GetData(Sql)

        Return Ris

    End Function

    Public Function TrovaFile(ByVal NomeFile As String) As Boolean
        Dim Ris As Boolean = True

        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""

                sql = "SELECT Filepath FROM t_ordini WHERE filePath = " & Ap(NomeFile)
                sql &= " UNION SELECT FilePath FROM t_sorgenti WHERE filePath =" & Ap(NomeFile)
                sql &= " UNION SELECT Anteprima as FilePath FROM t_preventivi WHERE Anteprima =" & Ap(NomeFile)
                sql &= " UNION SELECT BigliettoVisita as FilePath FROM T_Rubrica WHERE BigliettoVisita =" & Ap(NomeFile)
                sql &= " UNION SELECT FilePath FROM T_FileAllegati WHERE filePath =" & Ap(NomeFile)

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()

                    Ris = myReader.HasRows
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris
    End Function

    Public Function TotaleProntoStampa(ByVal IdRub As Integer) As Decimal

        Dim Ris As Decimal = 0

        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""

                sql = "SELECT SUM(TotaleForn+Ricarico-Sconto) as Tot FROM t_ordini "
                sql &= " WHERE stato IN (" & enStatoOrdine.ProntoRitiro & "," &
                                             enStatoOrdine.UscitoMagazzino & "," &
                                             enStatoOrdine.InConsegna & "," &
                                             enStatoOrdine.Consegnato & ")"

                If IdRub Then
                    sql &= " and IdRub = " & IdRub
                End If

                sql &= " and IdDoc = 0"

                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.CommandText = sql
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    myReader.Read()

                    If Not myReader("Tot").ToString = "" Then Ris = myReader("Tot")
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris
    End Function

    'Public Function TotaleProntoStampa(ByVal IdRub As Integer) As Decimal

    '    Dim Ris As Decimal = 0

    '    Try

    '        Using myCommand As SqlCommand = _Cn.CreateCommand()
    '            Dim sql As String = ""

    '            sql = "SELECT sum(TotaleForn+Ricarico-Sconto) as tot FROM t_ordini "
    '            sql &= " WHERE stato IN (" & enStatoOrdine.ProntoRitiro & "," & enStatoOrdine.UscitoMagazzino & ")"

    '            If IdRub Then
    '                sql &= " and idrub = " & IdRub
    '            End If
    '            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '            myCommand.CommandText = sql
    '            Using myReader As SqlDataReader = myCommand.ExecuteReader()
    '                myReader.Read()

    '                If Not myReader("Tot").ToString = "" Then Ris = myReader("Tot")
    '                myReader.Close()
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try

    '    Return Ris
    'End Function

    Public Function DuplicaOrdine(ByRef Sender As Object,
                                  ByVal OldOrd As Ordine,
                                  ForzaIndirizzoDefault As Boolean) As Integer
        'RITORNA l'ID DEL NUOVO ORDINE IN CASO E' ANDATO TUTTO OK 

        Dim Risu As Integer = 0

        Try

            Dim NewOrd As Ordine = OldOrd.Clone

            Dim P As New Preventivazione
            P.Read(OldOrd.ListinoBase.IdPrev)

            Dim C As New Corriere
            C.Read(OldOrd.IdCorriere)

            Dim ris As RisDataConsegna = MgrDataConsegna.CalcolaDateConsegna(P, C, Nothing)

            Dim DataPrevConsegna As Date = Date.MinValue
            Dim DataPrevProduzione As Date = Date.MinValue
            Select Case NewOrd.TipoConsegna
                Case enTipoConsegna.Fast
                    DataPrevConsegna = ris.DataFast
                    DataPrevProduzione = ris.DataFastProduzione
                Case enTipoConsegna.Normale
                    DataPrevConsegna = ris.DataNormale
                    DataPrevProduzione = ris.DataNormaleProduzione
                Case enTipoConsegna.Slow
                    DataPrevConsegna = ris.DataSlow
                    DataPrevProduzione = ris.DataSlowProduzione
            End Select

            If ForzaIndirizzoDefault Then
                NewOrd.IdIndirizzo = OldOrd.VoceRubrica.DefaultIndirizzo.IDIndirizzo
            Else
                NewOrd.IdIndirizzo = OldOrd.IdIndirizzo
            End If

            NewOrd.IdOrd = 0
            NewOrd.IdCom = 0
            NewOrd.IdTipoProd = OldOrd.IdTipoProd
            NewOrd.DataIns = Now
            NewOrd.DataCambioStato = Now
            NewOrd.DataPrevConsegna = DataPrevConsegna
            NewOrd.DataPrevProduzione = DataPrevProduzione
            NewOrd.DataEffConsegna = Date.MinValue
            NewOrd.UsaLavorazioniDefault = False
            NewOrd.Stato = enStatoOrdine.Preinserito
            NewOrd.IdDoc = 0
            NewOrd.NumeroRealeColli = 0
            NewOrd.LastUpdate = enSiNo.Si

            'NewOrd.OrdMail = False

            'qui devo prendere le lavorazion icondivise sulla commessa dove stava se ci stava

            Dim listLav As New List(Of Integer)

            If OldOrd.IdCom Then
                Using mgrL As New LavLogDAO
                    Dim lOld As List(Of LavLog) = mgrL.FindAll("Ordine", New LUNA.LunaSearchParameter("IdCom", OldOrd.IdCom))
                    For Each singlav As LavLog In lOld
                        Using singL As New Lavorazione
                            singL.Read(singlav.Idlav)
                            If singL.Accorpabile = enSiNo.Si Then
                                listLav.Add(singlav.Idlav)
                            End If
                        End Using
                    Next
                End Using
            End If

            OldOrd.ListinoBase.CaricaLavorazioni()
            'qui devo vedere se era prevista qualche lavorazione di stampa o di taglio nel listino base che non c'e' e devo aggiungerla
            If OldOrd.ListinoBase.LavorazioniBase.FindAll(Function(x) x.IdLavoro = FormerConst.Lavorazioni.StampaRealizzazione).Count Then
                'qui era prevista la stampa 
                If listLav.FindAll(Function(x) x = FormerConst.Lavorazioni.StampaRealizzazione).Count = 0 Then
                    listLav.Insert(0, FormerConst.Lavorazioni.StampaRealizzazione)
                End If
            End If

            If OldOrd.ListinoBase.LavorazioniBase.FindAll(Function(x) x.IdLavoro = FormerConst.Lavorazioni.Taglio).Count Then
                'qui era prevista la stampa 
                If listLav.FindAll(Function(x) x = FormerConst.Lavorazioni.Taglio).Count = 0 Then
                    listLav.Add(FormerConst.Lavorazioni.Taglio)
                End If
            End If

            Using mgrL As New LavLogDAO
                Dim lOld As List(Of LavLog) = mgrL.FindAll("Ordine", New LUNA.LunaSearchParameter("IdOrd", OldOrd.IdOrd))
                For Each singlav As LavLog In lOld
                    listLav.Add(singlav.Idlav)
                Next
            End Using

            NewOrd.ListaLavorazioniCustom = listLav.ToArray
            Risu = NewOrd.Save()

            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, NewOrd.IdOrd, "DUPLICATO ORDINE utilizzando come sorgente l'ordine " & OldOrd.IdOrd)
            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, NewOrd.IdOrd, "Prodotto: " & OldOrd.Prodotto.Descrizione)
            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, NewOrd.IdOrd, "Cliente: " & OldOrd.VoceRubrica.RagSocNome)
            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, NewOrd.IdOrd, "****************************************")

            NewOrd.SaveFirstTime()

            Dim NuovoNomeFile As String = String.Empty

            If NewOrd.ListinoBase.NoAttachFile <> enSiNo.Si Then
                NuovoNomeFile = FormerPath.PathTemp & FormerHelper.File.EstraiNomeFile(OldOrd.FilePath, NewOrd.IdOrd)
                'FileCopy(txtFile.Text, NuovoNomeFile)
                'ResizeImg(txtFile.Text, NuovoNomeFile)

                'Dim Frmattiva As Form

                'Frmattiva = AppDomain.CurrentDomain
                'Dim Postazione
                Try
                    'File.Copy(OldOrd.FilePath, NuovoNomeFile, True)
                    MgrFormerIO.FileCopy(OldOrd.FilePath, NuovoNomeFile, Sender)
                Catch ex As Exception
                    Risu = 0
                End Try
                '            Postazione.FileCopy(, OldOrd.FilePath, NuovoNomeFile, True)
                NewOrd.FilePath = NuovoNomeFile

                Dim mO As New OrdiniDAO
                mO.SalvaFile(NewOrd)
                mO.Dispose()
            End If

            Dim Sorg As DataRow, Sorgenti As New cSorgentiColl, CollSorgenti As DataTable

            CollSorgenti = Sorgenti.Lista(OldOrd.IdOrd)
            Dim NumPagina As Integer = 1

            For Each Sorg In CollSorgenti.Rows

                Dim Estensione As String = "", FileStr As String = ""
                FileStr = Sorg("FilePath").ToString

                Estensione = FileStr.Substring(FileStr.Length - 4)
                NuovoNomeFile = FormerPath.PathTemp & FormerHelper.File.EstraiNomeFile(FileStr, NewOrd.IdOrd) 'GetNomeFileTemp(Estensione)
                Try
                    'File.Copy(FileStr, NuovoNomeFile)
                    MgrFormerIO.FileCopy(FileStr, NuovoNomeFile, Sender)
                Catch ex As Exception
                    Risu = 0
                End Try

                'Postazione.FileCopy(, File, NuovoNomeFile)

                Using Sorgente As New FileSorgente
                    Sorgente.StatoRefine = enStatoRefineSorgente.NonDefinito
                    Sorgente.FilePath = NuovoNomeFile
                    Sorgente.IdOrd = NewOrd.IdOrd
                    Sorgente.NumPagina = NumPagina
                    Sorgente.Save()
                End Using
                NumPagina += 1

            Next

            For Each Fileallegato In OldOrd.ListaFileAllegati

                NuovoNomeFile = FormerPath.PathTemp & FormerHelper.File.EstraiNomeFile(Fileallegato.FilePath, NewOrd.IdOrd) 'GetNomeFileTemp(Estensione)
                Try
                    'File.Copy(FileStr, NuovoNomeFile)
                    MgrFormerIO.FileCopy(Fileallegato.FilePath, NuovoNomeFile, Sender)
                Catch ex As Exception
                    Risu = 0
                End Try

                'Postazione.FileCopy(, File, NuovoNomeFile)

                Using FA As New FileAllegato
                    FA.FilePath = NuovoNomeFile
                    FA.IdOrd = NewOrd.IdOrd
                    FA.IdProcedura = Fileallegato.IdProcedura
                    FA.Save()
                End Using

            Next

            'qui devo programmare la consegna per il nuovo ordine
            Using mgrC As New ConsegneProgrammateDAO
                Dim DataRifConsegna As Date = NewOrd.DataPrevProduzione
                If NewOrd.IdCorriere = enCorriere.TipografiaFormer Or NewOrd.IdCorriere = enCorriere.TipografiaFormerFuoriRaccordo Then DataRifConsegna = NewOrd.DataPrevConsegna
                mgrC.RegistraConsegnaOrdineSuGiorno(NewOrd.IdOrd, NewOrd.IdCorriere, DataRifConsegna, NewOrd.IdRub, enMomentoConsegna.Pomeriggio, NewOrd.IdIndirizzo)
            End Using

            Using mgr As New CommesseDAO
                mgr.CreaCommessaAutomaticaNonOffset(NewOrd)
            End Using

            OldOrd = Nothing
            NewOrd = Nothing

        Catch ex As Exception
            ManageError(ex)
            Risu = 0
        End Try
        Return Risu

    End Function

    Public Sub InserisciLog(ByRef O As Ordine,
                            ByVal NuovoStato As enStatoOrdine,
                            Optional IdInseritoDa As Integer = 0,
                            Optional ModificaConsegna As Boolean = True)

        Try

            If O.Stato = NuovoStato Then
                Using cO As New CronoOrdine
                    cO.IdOrd = O.IdOrd
                    cO.DataCrono = Date.Now
                    cO.IdStato = NuovoStato
                    cO.IdOperatore = IdInseritoDa
                    cO.Save()
                End Using
            Else
                O.Stato = NuovoStato
                O.LastUpdate = enSiNo.Si
                O.DataCambioStato = Date.Now

                If O.Stato = enStatoOrdine.ProntoRitiro Then
                    If O.DataEffConsegna <> Date.MinValue Then
                        O.DataEffConsegna = Date.MinValue
                    End If
                ElseIf O.Stato = enStatoOrdine.UscitoMagazzino Then
                    If O.DataEffConsegna = Date.MinValue Then
                        O.DataEffConsegna = Date.Now
                    End If
                End If

                O.Save()

                If IdInseritoDa = 0 Then
                    Try
                        IdInseritoDa = LUNA.LunaContext.UtenteConnesso.IdUt
                    Catch ex As Exception

                    End Try

                End If

                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "CAMBIO STATO A " & NuovoStato.ToString & " (Operatore " & IdInseritoDa & ")")

                Using cO As New CronoOrdine
                    cO.IdOrd = O.IdOrd
                    cO.DataCrono = Date.Now
                    cO.IdStato = O.Stato
                    cO.IdOperatore = IdInseritoDa
                    cO.Save()
                End Using

                If ModificaConsegna Then
                    'se il nuovo stato influenza la consegna porto avanti anche la consegna relativa 
                    If Not O.ConsegnaAssociata Is Nothing Then
                        If O.Stato = enStatoOrdine.InConsegna And (O.ConsegnaAssociata.IdStatoConsegna = enStatoConsegna.InLavorazione Or O.ConsegnaAssociata.IdStatoConsegna = enStatoConsegna.RegistrataCorriere) Then
                            Using mgr As New ConsegneProgrammateDAO
                                mgr.AvanzaStatoConsegna(O.ConsegnaAssociata, enStatoConsegna.InConsegna)
                            End Using
                        ElseIf O.Stato = enStatoOrdine.Consegnato And O.ConsegnaAssociata.IdStatoConsegna < enStatoConsegna.Consegnata Then
                            Using mgr As New ConsegneProgrammateDAO
                                mgr.AvanzaStatoConsegna(O.ConsegnaAssociata, enStatoConsegna.Consegnata)
                            End Using

                        End If
                    End If
                End If

                If O.Stato >= enStatoOrdine.UscitoMagazzino Then
                    'qui controllo che tutti i lavlog siano ok 
                    For Each l As LavLog In O.ListaLavLogCompleta

                        If l.IdOrd = O.IdOrd Then
                            If l.DataOraInizio = Date.MinValue Then
                                l.DataOraInizio = Now
                            End If
                            If l.DataOraFine = Date.MinValue Then
                                l.DataOraFine = Now
                            End If
                            If l.IsChanged Then
                                l.Save()
                            End If
                        End If

                    Next
                End If

                'qui se il nuovo stato ora e' consgnato controllo che non c'era un pagamento e lo porto a pagato

                If (O.Stato = enStatoOrdine.UscitoMagazzino AndAlso O.ConsegnaAssociata.IdCorr = enCorriere.RitiroCliente) OrElse
                    (O.Stato = enStatoOrdine.Consegnato AndAlso O.ConsegnaAssociata.IdCorr <> enCorriere.RitiroCliente) Then


                    'If Not O.DocumentoFiscale Is Nothing AndAlso
                    '    O.DocumentoFiscale.ListaPagamenti.Count AndAlso
                    '    O.DocumentoFiscale.TotaleAncoraDaPagare = 0 Then
                    '    O.Stato = enStatoDocumentoFiscale.PagatoInteramente Then

                    If Not O.DocumentoFiscale Is Nothing AndAlso
                        O.DocumentoFiscale.TotaleAncoraDaPagare = 0 Then
                        'qui devo mettere l'ordine a pagato 
                        For Each OInDoc As Ordine In O.DocumentoFiscale.ListaOrdini
                            InserisciLog(OInDoc.IdOrd, enStatoOrdine.PagatoInteramente, IdInseritoDa, False)
                        Next
                    End If

                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ListaIdOrdDigitaleDaSpostare(PathTemp As String) As List(Of Integer)

        Dim Ris As New List(Of Integer)

        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT IdOrd "
                sql &= " from T_Ordini "
                sql &= " where idtipoprod = " & enTipoProdCom.StampaDigitale
                'sql &= " and stato  in (" & enStatoOrdine.ProntoRitiro & "," & enStatoOrdine.InConsegna & "," & enStatoOrdine.Consegnato & "," & enStatoOrdine.PagatoInteramente & ")"
                sql &= " and stato  >= " & enStatoOrdine.Registrato
                sql &= " and filepath " & ApLikeRight(PathTemp)
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Ris.Add(CInt(myReader("IdOrd")))
                    End While
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris

    End Function

    Public Function ListaIdOrdRifiutatiDaSpostare(PathTemp As String) As List(Of Integer)

        Dim Ris As New List(Of Integer)

        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT IdOrd "
                sql &= " from T_Ordini "
                sql &= " where stato  = " & enStatoOrdine.Rifiutato
                sql &= " and idcom = 0 "
                sql &= " and filepath " & ApLikeRight(PathTemp)
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Ris.Add(CInt(myReader("IdOrd")))
                    End While
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris

    End Function

    Public Function ListaIdOrdOffsetDaSpostare(PathTemp As String) As List(Of Integer)

        Dim Ris As New List(Of Integer)

        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT IdOrd "
                sql &= " FROM T_Ordini "
                sql &= " WHERE idtipoprod = " & enTipoProdCom.StampaOffSet
                'sql &= " and stato  in (" & enStatoOrdine.ProntoRitiro & "," & enStatoOrdine.InConsegna & "," & enStatoOrdine.Consegnato & "," & enStatoOrdine.PagatoInteramente & ")"
                sql &= " AND stato  >= " & enStatoOrdine.Registrato
                sql &= " AND idcom <>0 "
                sql &= " AND filepath " & ApLikeRight(PathTemp)
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Ris.Add(CInt(myReader("IdOrd")))
                    End While
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris

    End Function

    Public Function AvanzaOrdiniAStatoByIdOrd(ByVal IdOrd As Integer,
                                              ByVal Stato As enStatoOrdine,
                                              Optional ModificaConsegna As Boolean = True) As Integer
        Dim Ris As Integer = 0
        Try
            Using mO As New OrdiniDAO
                mO.InserisciLog(IdOrd, Stato, , ModificaConsegna)
            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris

    End Function

    Public Function AvanzaOrdiniAStatoByIdCons(ByVal IdCons As Integer, ByVal Stato As enStatoOrdine, IdUt As Integer) As Integer
        Dim Ris As Integer = 0
        Try
            Dim mC As New ConsProgrOrdiniDAO
            Dim l As List(Of ConsProgrOrdini) = mC.FindAll(New LUNA.LunaSearchParameter("IdCons", IdCons))
            Using mO As New OrdiniDAO

                For Each c As ConsProgrOrdini In l
                    mO.InserisciLog(c.IdOrd, Stato, IdUt)
                Next
            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function AssociaOrdiniADoc(ByVal IdOrd As Integer, ByVal IdDoc As Integer, MettiPreventivo As enSiNo) As Integer
        Dim Ris As Integer = 0
        Try

            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "UPDATE T_Ordini SET IdDoc = " & IdDoc & ", Preventivo = " & CInt(MettiPreventivo)
                Sql &= " WHERE IdOrd = " & IdOrd
                UpdateCommand.CommandText = Sql
                UpdateCommand.ExecuteNonQuery()
            End Using


        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function GetNumColli(IdOrd As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT numcolli FROM T_Prodotti p, T_Ordini o WHERE o.idprod = p.idprod AND o.idord = " & IdOrd
                'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()

                    myReader.Read()

                    Ris = myReader("numcolli")
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris

    End Function

    'Public Function ListaTutti() As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Ordini")
    '    Try

    '        Dim myCommand As SqlCommand = _cn.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT distinct IdRub from T_Ordini"

    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

    '        myCommand.CommandText = sql
    '                    If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction 
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        datatb.Load(myReader)
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    Public Function ListaOrdiniByLastUpdate() As List(Of Ordine)
        Dim Ris As New List(Of Ordine)
        Try
            'Dim sql As String = "SELECT o.* from T_Ordini O, T_Prodotti P where o.idprod = p.idprod and " & _
            '    "datediff('n',@DataCambioStato,o.datacambiostato)>0 and o.stato >= " & enStatoOrdine.Preinserito & " ORDER BY IDORD"

            Dim sql As String = "SELECT o.* FROM T_Ordini O, T_Prodotti P WHERE o.idprod = p.idprod and LastUpdate = " & enSiNo.Si & " ORDER BY idord"

            Using myCommand As SqlCommand = _Cn.CreateCommand()

                'Dim DataPar As New SqlParameter("@DataCambioStato", OleDbType.Date)
                'DataPar.Value = DataUltimoAggiornamento
                'myCommand.Parameters.Add(DataPar)

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                While myReader.Read

                    Dim classe As New Ordine(CType(myReader, IDataRecord))
                    'classe.IdOrd = myReader("IdOrd")
                    'If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
                    'If Not myReader("IdTipoProd") Is DBNull.Value Then classe.IdTipoProd = myReader("IdTipoProd")
                    'If Not myReader("IdProd") Is DBNull.Value Then classe.IdProd = myReader("IdProd")
                    'If Not myReader("IdRub") Is DBNull.Value Then classe.IdRub = myReader("IdRub")
                    'If Not myReader("Lungo") Is DBNull.Value Then classe.Lungo = myReader("Lungo")
                    'If Not myReader("Largo") Is DBNull.Value Then classe.Largo = myReader("Largo")
                    'If Not myReader("DataIns") Is DBNull.Value Then classe.DataIns = myReader("DataIns")
                    'If Not myReader("DataCambioStato") Is DBNull.Value Then classe.DataCambioStato = myReader("DataCambioStato")
                    'If Not myReader("DataPrevConsegna") Is DBNull.Value Then classe.DataPrevConsegna = myReader("DataPrevConsegna")
                    'If Not myReader("DataEffConsegna") Is DBNull.Value Then classe.DataEffConsegna = myReader("DataEffConsegna")
                    'If Not myReader("PeriodoPrevConsegna") Is DBNull.Value Then classe.PeriodoPrevConsegna = myReader("PeriodoPrevConsegna")
                    'If Not myReader("TipoConsegna") Is DBNull.Value Then classe.TipoConsegna = myReader("TipoConsegna")
                    'If Not myReader("OraConsegna") Is DBNull.Value Then classe.OraConsegna = myReader("OraConsegna")
                    'If Not myReader("Stato") Is DBNull.Value Then classe.Stato = myReader("Stato")
                    'If Not myReader("PrezzoProd") Is DBNull.Value Then classe.PrezzoProd = myReader("PrezzoProd")
                    'If Not myReader("Qta") Is DBNull.Value Then classe.Qta = myReader("Qta")
                    'If Not myReader("TotaleForn") Is DBNull.Value Then classe.TotaleForn = myReader("TotaleForn")
                    'If Not myReader("Iva") Is DBNull.Value Then classe.Iva = myReader("Iva")
                    'If Not myReader("CostoSped") Is DBNull.Value Then classe.CostoSped = myReader("CostoSped")
                    'If Not myReader("Sconto") Is DBNull.Value Then classe.Sconto = myReader("Sconto")
                    'If Not myReader("Prezzo") Is DBNull.Value Then classe.Prezzo = myReader("Prezzo")
                    'If Not myReader("IdCorriere") Is DBNull.Value Then classe.IdCorriere = myReader("IdCorriere")
                    'If Not myReader("File") Is DBNull.Value Then classe.File = myReader("File")
                    'If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
                    'If Not myReader("FileSorgente") Is DBNull.Value Then classe.FileSorgente = myReader("FileSorgente")
                    'If Not myReader("NomeFileOriginale") Is DBNull.Value Then classe.NomeFileOriginale = myReader("NomeFileOriginale")
                    'If Not myReader("OrdMail") Is DBNull.Value Then classe.OrdMail = myReader("OrdMail")
                    'If Not myReader("Ricarico") Is DBNull.Value Then classe.Ricarico = myReader("Ricarico")
                    'If Not myReader("Preventivo") Is DBNull.Value Then classe.Preventivo = myReader("Preventivo")
                    'If Not myReader("IdDoc") Is DBNull.Value Then classe.IdDoc = myReader("IdDoc")
                    'If Not myReader("RilascioCli") Is DBNull.Value Then classe.RilascioCli = myReader("RilascioCli")
                    'If Not myReader("NumeroRealeColli") Is DBNull.Value Then classe.NumeroRealeColli = myReader("NumeroRealeColli")
                    'If Not myReader("Nfogli") Is DBNull.Value Then classe.Nfogli = myReader("Nfogli")
                    'If Not myReader("TipoRetro") Is DBNull.Value Then classe.TipoRetro = myReader("TipoRetro")
                    'If Not myReader("LastUpdate") Is DBNull.Value Then classe.LastUpdate = myReader("LastUpdate")

                    Ris.Add(classe)
                End While
                myReader.Close()
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris

    End Function

    'Public Function Lista(ByVal DataUltimoAggiornamento As Date) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Ordini")
    '    Try

    '        Dim myCommand As SqlCommand = _cn.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT distinct IdRub from T_Ordini where datediff('n','" & DataUltimoAggiornamento & "',datacambiostato)>0"

    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

    '        myCommand.CommandText = sql
    '                    If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction 
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        datatb.Load(myReader)
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    ''TODO: OBSOLETO RISCRIVERLO
    'Public Sub InviaMailOrdiniProntoStampa(ByVal DataUltimoAggiornamento As Date)
    '    Try

    '        Dim myCommand As SqlCommand = _cn.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT distinct idord from T_Ordini where datediff('n','" & DataUltimoAggiornamento & "',datacambiostato)>0 and stato = " & enStatoOrdine.ProntoRitiro

    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

    '        myCommand.CommandText = sql
    '                    If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction 
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        Dim Counter As Integer = 0
    '        While myReader.Read
    '            Counter += 1
    '            Dim Ord As New Ordine
    '            Ord.Read(myReader("idord"))
    '            InviaMailCambiostato(Ord)
    '            Ord = Nothing
    '        End While
    '        'TODO: AGGIORNALOG VA RIABILITATA
    '        'AggiornaLog("Inviate " & Counter & " email ")
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try

    'End Sub

    'Public Function SaveFile(O As Ordine) As Integer

    '    Dim Ris As Integer = 0

    '    Try
    '        Dim sql As String
    '        Dim DbCommand As SqlCommand = New SqlCommand()
    '        DbCommand.Connection = _cn

    '        sql = "UPDATE T_Ordini SET "
    '        sql &= "File = " & Ap(O.File)
    '        sql &= " WHERE IdOrd= " & O.IdOrd

    '        DbCommand.CommandText = sql
    '        DbCommand.ExecuteNonQuery()
    '        'End If

    '        DbCommand.Dispose()

    '    Catch ex As Exception
    '        ManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

    'Public Function OrdiniDaPubblicarse(IdRub As Integer) As List(Of Ordine)

    '    Dim Ris As New List(Of Ordine)
    '    Try
    '        Dim sql As String = ""

    '        sql = "SELECT o.*," & _
    '            "p.Descrizione as ProdottoDescrizione, " & _
    '            "r.RagSoc as ClienteNominativo, " & _
    '            " c.Descrizione as NomeBreve" & _
    '            " FROM T_ORDINI o," & _
    '            " T_Prodotti P, " & _
    '            " T_Rubrica R,  " & _
    '            " T_Corriere C "

    '        sql &= " WHERE o.idprod= p.Idprod "
    '        sql &= " AND o.idrub = r.idrub "
    '        sql &= " AND o.idcorriere = c.idcorriere "
    '        'sql &= " AND datediff('d',now(),o.dataprevconsegna)>=-120"
    '        'sql &= " AND  (o.dataeffconsegna is null or year(o.dataeffconsegna)<2011) "
    '        'sql &= " AND o.idord not in (SELECT DISTINCT IDORD FROM TR_CONSORD)"

    '        Dim ListaStati As String = enStatoOrdine.Preinserito & "," & _
    '                        enStatoOrdine.Registrato & "," & _
    '                        enStatoOrdine.InSospeso & "," & _
    '                        enStatoOrdine.InCodaDiStampa & "," & _
    '                        enStatoOrdine.StampaInizio & "," & _
    '                        enStatoOrdine.StampaFine & "," & _
    '                        enStatoOrdine.FinituraCommessaInizio & "," & _
    '                        enStatoOrdine.FinituraCommessaFine & "," & _
    '                        enStatoOrdine.FinituraProdottoInizio & "," & _
    '                        enStatoOrdine.FinituraProdottoFine & "," & _
    '                        enStatoOrdine.Imballaggio & "," & _
    '                        enStatoOrdine.ImballaggioCorriere & "," & _
    '                        enStatoOrdine.ProntoRitiro & "," & _
    '                        enStatoOrdine.UscitoMagazzino & "," & _
    '                        enStatoOrdine.InConsegna & "," & _
    '                        enStatoOrdine.Consegnato & "," & _
    '                        enStatoOrdine.PagatoAcconto
    '        sql &= " and (o.stato in(" & ListaStati & ") or (o.stato = " & enStatoOrdine.PagatoInteramente & " AND datediff('d',now(),o.DataCambioStato)>=-30 ))"

    '        If IdRub Then
    '            sql &= " and r.idrub = " & IdRub
    '        End If

    '        sql &= " ORDER  bY DataCambioStato DESC"

    '        Dim myCommand As SqlCommand = _cn.CreateCommand()
    '        myCommand.CommandText = sql
    '                    If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction 
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        While myReader.Read
    '            Dim classe As New Ordine
    '            If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrd = myReader("IdOrd")
    '            If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
    '            If Not myReader("IdTipoProd") Is DBNull.Value Then classe.IdTipoProd = myReader("IdTipoProd")
    '            If Not myReader("IdProd") Is DBNull.Value Then classe.IdProd = myReader("IdProd")
    '            If Not myReader("IdRub") Is DBNull.Value Then classe.IdRub = myReader("IdRub")
    '            If Not myReader("Lungo") Is DBNull.Value Then classe.Lungo = myReader("Lungo")
    '            If Not myReader("Largo") Is DBNull.Value Then classe.Largo = myReader("Largo")
    '            If Not myReader("DataIns") Is DBNull.Value Then classe.DataIns = myReader("DataIns")
    '            If Not myReader("DataCambioStato") Is DBNull.Value Then classe.DataCambioStato = myReader("DataCambioStato")
    '            If Not myReader("DataPrevConsegna") Is DBNull.Value Then classe.DataPrevConsegna = myReader("DataPrevConsegna")
    '            If Not myReader("DataEffConsegna") Is DBNull.Value Then classe.DataEffConsegna = myReader("DataEffConsegna")
    '            If Not myReader("PeriodoPrevConsegna") Is DBNull.Value Then classe.PeriodoPrevConsegna = myReader("PeriodoPrevConsegna")
    '            If Not myReader("TipoConsegna") Is DBNull.Value Then classe.TipoConsegna = myReader("TipoConsegna")
    '            If Not myReader("OraConsegna") Is DBNull.Value Then classe.OraConsegna = myReader("OraConsegna")
    '            If Not myReader("Stato") Is DBNull.Value Then classe.Stato = myReader("Stato")
    '            If Not myReader("PrezzoProd") Is DBNull.Value Then classe.PrezzoProd = myReader("PrezzoProd")
    '            If Not myReader("Qta") Is DBNull.Value Then classe.Qta = myReader("Qta")
    '            If Not myReader("TotaleForn") Is DBNull.Value Then classe.TotaleForn = myReader("TotaleForn")
    '            If Not myReader("Iva") Is DBNull.Value Then classe.Iva = myReader("Iva")
    '            If Not myReader("CostoSped") Is DBNull.Value Then classe.CostoSped = myReader("CostoSped")
    '            If Not myReader("Sconto") Is DBNull.Value Then classe.Sconto = myReader("Sconto")
    '            If Not myReader("Prezzo") Is DBNull.Value Then classe.Prezzo = myReader("Prezzo")
    '            If Not myReader("IdCorriere") Is DBNull.Value Then classe.IdCorriere = myReader("IdCorriere")
    '            If Not myReader("File") Is DBNull.Value Then classe.File = myReader("File")
    '            If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
    '            If Not myReader("FileSorgente") Is DBNull.Value Then classe.FileSorgente = myReader("FileSorgente")
    '            If Not myReader("NomeFileOriginale") Is DBNull.Value Then classe.NomeFileOriginale = myReader("NomeFileOriginale")
    '            If Not myReader("OrdMail") Is DBNull.Value Then classe.OrdMail = myReader("OrdMail")
    '            If Not myReader("Ricarico") Is DBNull.Value Then classe.Ricarico = myReader("Ricarico")
    '            If Not myReader("Preventivo") Is DBNull.Value Then classe.Preventivo = myReader("Preventivo")
    '            If Not myReader("IdDoc") Is DBNull.Value Then classe.IdDoc = myReader("IdDoc")
    '            If Not myReader("RilascioCli") Is DBNull.Value Then classe.RilascioCli = myReader("RilascioCli")
    '            If Not myReader("NumeroRealeColli") Is DBNull.Value Then classe.NumeroRealeColli = myReader("NumeroRealeColli")

    '            ''CAMPI EXTRA
    '            'If Not myReader("ProdottoDescrizione") Is DBNull.Value Then classe.ProdottoDescrizione = myReader("ProdottoDescrizione")
    '            'If Not myReader("ClienteNominativo") Is DBNull.Value Then classe.ClienteNominativo = myReader("ClienteNominativo")
    '            'If Not myReader("NomeBreve") Is DBNull.Value Then classe.CorriereStr = myReader("NomeBreve")

    '            Ris.Add(classe)
    '        End While
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try

    '    Return Ris

    'End Function

    Public Sub TornaAProntoRitiro(O As Ordine)

        InserisciLog(O, enStatoOrdine.ProntoRitiro)

    End Sub

    Public Function OrdiniPrevistiNonInConsegna(Optional TestoLibero As String = "", Optional IdRub As Integer = 0) As List(Of OrdineRicerca)

        Dim Ris As New List(Of OrdineRicerca)
        Try
            Dim sql As String = ""

            sql = "SELECT o.*," &
                "p.Descrizione as ProdottoDescrizione, " &
                "r.RagSoc as ClienteNominativo, " &
                " c.Descrizione as NomeBreve" &
                " FROM T_ORDINI o," &
                " T_Prodotti P, " &
                " T_Rubrica R,  " &
                " T_Corriere C "

            sql &= " WHERE o.idprod= p.Idprod "
            sql &= " AND o.idrub = r.idrub "
            sql &= " AND o.idcorriere = c.idcorriere "
            sql &= " AND datediff(d,getdate(),o.dataprevconsegna)>=-120"
            'sql &= " AND  (o.dataeffconsegna is null or year(o.dataeffconsegna)<2011) "
            sql &= " AND o.idord not in (SELECT DISTINCT IDORD FROM TR_CONSORD)"

            Dim ListaStati As String = enStatoOrdine.Preinserito & "," &
                            enStatoOrdine.Registrato & "," &
                            enStatoOrdine.InSospeso & "," &
                            enStatoOrdine.InCodaDiStampa & "," &
                            enStatoOrdine.StampaInizio & "," &
                            enStatoOrdine.StampaFine & "," &
                            enStatoOrdine.FinituraCommessaInizio & "," &
                            enStatoOrdine.FinituraCommessaFine & "," &
                            enStatoOrdine.FinituraProdottoInizio & "," &
                            enStatoOrdine.FinituraProdottoFine & "," &
                            enStatoOrdine.Imballaggio & "," &
                            enStatoOrdine.ProntoRitiro
            sql &= " AND o.stato in(" & ListaStati & ")"

            If TestoLibero.Trim.Length Then
                sql &= " AND r.ragsoc " & ApLike(TestoLibero)
            End If

            If IdRub Then
                sql &= " AND r.idrub = " & IdRub
            End If

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                While myReader.Read
                    Dim classe As New OrdineRicerca(CType(myReader, IDataRecord))
                    'If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrd = myReader("IdOrd")
                    'If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
                    'If Not myReader("IdTipoProd") Is DBNull.Value Then classe.IdTipoProd = myReader("IdTipoProd")
                    'If Not myReader("IdProd") Is DBNull.Value Then classe.IdProd = myReader("IdProd")
                    'If Not myReader("IdRub") Is DBNull.Value Then classe.IdRub = myReader("IdRub")
                    'If Not myReader("Lungo") Is DBNull.Value Then classe.Lungo = myReader("Lungo")
                    'If Not myReader("Largo") Is DBNull.Value Then classe.Largo = myReader("Largo")
                    'If Not myReader("DataIns") Is DBNull.Value Then classe.DataIns = myReader("DataIns")
                    'If Not myReader("DataCambioStato") Is DBNull.Value Then classe.DataCambioStato = myReader("DataCambioStato")
                    'If Not myReader("DataPrevConsegna") Is DBNull.Value Then classe.DataPrevConsegna = myReader("DataPrevConsegna")
                    'If Not myReader("DataEffConsegna") Is DBNull.Value Then classe.DataEffConsegna = myReader("DataEffConsegna")
                    'If Not myReader("PeriodoPrevConsegna") Is DBNull.Value Then classe.PeriodoPrevConsegna = myReader("PeriodoPrevConsegna")
                    'If Not myReader("TipoConsegna") Is DBNull.Value Then classe.TipoConsegna = myReader("TipoConsegna")
                    'If Not myReader("OraConsegna") Is DBNull.Value Then classe.OraConsegna = myReader("OraConsegna")
                    'If Not myReader("Stato") Is DBNull.Value Then classe.Stato = myReader("Stato")
                    'If Not myReader("PrezzoProd") Is DBNull.Value Then classe.PrezzoProd = myReader("PrezzoProd")
                    'If Not myReader("Qta") Is DBNull.Value Then classe.Qta = myReader("Qta")
                    'If Not myReader("TotaleForn") Is DBNull.Value Then classe.TotaleForn = myReader("TotaleForn")
                    'If Not myReader("Iva") Is DBNull.Value Then classe.Iva = myReader("Iva")
                    'If Not myReader("CostoSped") Is DBNull.Value Then classe.CostoSped = myReader("CostoSped")
                    'If Not myReader("Sconto") Is DBNull.Value Then classe.Sconto = myReader("Sconto")
                    'If Not myReader("Prezzo") Is DBNull.Value Then classe.Prezzo = myReader("Prezzo")
                    'If Not myReader("IdCorriere") Is DBNull.Value Then classe.IdCorriere = myReader("IdCorriere")
                    'If Not myReader("File") Is DBNull.Value Then classe.File = myReader("File")
                    'If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
                    'If Not myReader("FileSorgente") Is DBNull.Value Then classe.FileSorgente = myReader("FileSorgente")
                    'If Not myReader("NomeFileOriginale") Is DBNull.Value Then classe.NomeFileOriginale = myReader("NomeFileOriginale")
                    'If Not myReader("OrdMail") Is DBNull.Value Then classe.OrdMail = myReader("OrdMail")
                    'If Not myReader("Ricarico") Is DBNull.Value Then classe.Ricarico = myReader("Ricarico")
                    'If Not myReader("Preventivo") Is DBNull.Value Then classe.Preventivo = myReader("Preventivo")
                    'If Not myReader("IdDoc") Is DBNull.Value Then classe.IdDoc = myReader("IdDoc")
                    'If Not myReader("RilascioCli") Is DBNull.Value Then classe.RilascioCli = myReader("RilascioCli")
                    'If Not myReader("NumeroRealeColli") Is DBNull.Value Then classe.NumeroRealeColli = myReader("NumeroRealeColli")

                    'CAMPI EXTRA
                    'If Not myReader("ProdottoDescrizione") Is DBNull.Value Then classe.ProdottoDescrizione = myReader("ProdottoDescrizione")
                    If Not myReader("ClienteNominativo") Is DBNull.Value Then classe.ClienteNominativo = myReader("ClienteNominativo")
                    If Not myReader("NomeBreve") Is DBNull.Value Then classe.CorriereStr = myReader("NomeBreve")

                    Ris.Add(classe)
                End While
                myReader.Close()
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris

    End Function

    Public Function Lista(Optional ByVal Codice As String = "",
                          Optional ByVal Stato As String = "",
                          Optional ByVal IdCatProd As Integer = 0,
                          Optional ByVal OnlyWithoutCom As Boolean = False,
                          Optional ByVal ListaIdOrdEsclusi As String = "",
                          Optional ByVal NumSpazi As Boolean = False,
                          Optional ByVal IdProd As Integer = 0,
                          Optional ByVal OrderContrario As Boolean = False,
                          Optional ByVal DataDal As Date = Nothing,
                          Optional ByVal DataAl As Date = Nothing,
                          Optional ByVal IdGruppo As Integer = 0,
                          Optional ByVal IdRub As Integer = 0,
                          Optional OnlyLastSixMonth As Boolean = False,
                          Optional TipoProdotto As enTipoProdCom = 0,
                          Optional OrderbyDataConsegna As Boolean = False,
                          Optional IdAgente As Integer = 0,
                          Optional DalSito As Boolean = False,
                          Optional SenzaDocumentoFiscale As Boolean = False,
                          Optional IdPrev As Integer = 0,
                          Optional IdListinoBase As Integer = 0,
                          Optional QuantitaSpec As Integer = 0,
                          Optional ByVal ListaIdOrdInclusi As String = "",
                          Optional Pagato As enSiNo = enSiNo.NonDefinito,
                          Optional IdOrdOnline As Integer = 0,
                          Optional Top As Integer = 0,
                          Optional OnlyPromo As Boolean = False,
                          Optional IdOrdineProvvisorio As Integer = 0,
                          Optional IdConsegna As Integer = 0,
                          Optional SoloNonFatturabili As Boolean = False,
                          Optional ConDocumentoFiscale As Boolean = False,
                          Optional IdRepartoWeb As Integer = 0,
                          Optional IdTipoFustella As Integer = 0) As List(Of OrdineRicerca)

        'NUMSPAZI OBSOLETO USATO SOLO PER COMPATIBILITA

        Dim Ris As New List(Of OrdineRicerca)
        Dim UltimoId As Integer = 0
        Try

            Dim sql As String = ""

            sql = "SELECT "

            If Top Then
                sql &= " TOP " & Top
            End If

            'sql &= " o.*," &
            '    "p.Descrizione as ProdottoDescrizione, " &
            '    "p.NumSpazi, " &
            '    "p.NumDuplic, " &
            sql &= " o.*," &
                " case when r.RagSoc='' then r.cognome + ' ' + r.nome else r.ragsoc end as ClienteNominativo, " &
                " c.Nomebreve,   " &
                "(SELECT Count(Idpostit) FROM T_Postit Pos  WHERE Pos.IdOrd = o.IdOrd) as NMsg " &
                " FROM T_Ordini o," &
                " T_Rubrica R,  " &
                " T_Prodotti P, " &
                " T_Corriere C "
            sql &= " WHERE o.idprod = p.Idprod "
            sql &= " AND o.idrub = r.idrub "
            sql &= " AND o.idcorriere = c.idcorriere "
            '" (SELECT TOP 1 Giorno FROM T_CONS S, TR_CONSORD CR WHERE S.IdCons=CR.IdCons AND CR.IdOrd = o.IdOrd) as Programmata, " &
            If Codice.Length Then
                If IsNumeric(Codice) Then
                    sql &= " AND o.idord=" & Codice
                Else
                    'qui puodarsi sia stato inserito il nome di un lavoro 
                    sql &= " AND (o.nomelavoro " & ApLike(Codice) & " OR charindex(" & Ap(Codice) & ",o.filepath,0)<>0)"
                End If
            End If

            If TipoProdotto Then
                sql &= " AND o.idtipoprod = " & TipoProdotto
                'sql &= " AND p.tipoprod = " & TipoProdotto
            End If

            If Stato.Length Then
                sql &= " AND o.stato in(" & Stato & ")"
            End If

            If ListaIdOrdEsclusi.Length Then
                sql &= " AND o.idord not in(" & ListaIdOrdEsclusi & ")"
            End If

            If ListaIdOrdInclusi.Length Then
                sql &= " AND o.idord in(" & ListaIdOrdInclusi & ")"
            End If

            If IdRub Then
                sql &= " AND o.idrub =" & IdRub
            End If

            If OnlyWithoutCom Then
                sql &= " AND o.idcom = 0 "
            End If

            If IdOrdineProvvisorio Then
                sql &= " AND o.IdOrdineProvvisorio =  " & IdOrdineProvvisorio
            End If

            If IdTipoFustella Then
                sql &= " AND o.IdTipoFustella = " & IdTipoFustella
            End If

            If SenzaDocumentoFiscale Then
                sql &= " AND o.idDoc = 0 "
            End If

            If ConDocumentoFiscale Then
                sql &= " AND o.idDoc <> 0 "
            End If

            If IdProd Then
                sql &= " AND o.idprod =" & IdProd
            End If

            If IdCatProd Then
                sql &= " AND p.idlistinobase IN(Select IdListinobase from T_listinobase where idprev = " & IdCatProd & ")"
            End If

            If OnlyLastSixMonth = True Then
                sql &= " AND datediff(m,o.datains,getdate()) <= 6" ' & Ap(Postazione.AnnoSelezionato)
            End If

            If DataDal <> Date.MinValue Then
                sql &= " AND datediff(d," & FormerHelper.Stringhe.FormattaDataPerSQL(DataDal) & ",o.datains)>=0 "
            End If

            If DataAl <> Date.MinValue Then
                sql &= " AND datediff(d,o.datains," & FormerHelper.Stringhe.FormattaDataPerSQL(DataAl) & ")>=0 "
            End If

            If IdGruppo Then
                sql &= " AND o.idrub in (SELECT IdRub FROM Tr_GrupRubr WHERE IdGruppo = " & IdGruppo & ") "
            End If

            If IdAgente Then
                sql &= " AND r.idage = " & IdAgente
            End If

            If DalSito Then
                sql &= " AND RilascioCli = " & FormerConst.Web.IdRilascio
            End If

            If QuantitaSpec Then
                sql &= " AND o.qta = " & QuantitaSpec
            End If

            If IdPrev Then
                sql &= " AND o.idprod IN  (SELECT IdProd FROM T_PRODOTTI where IDListinoBase in (select IDLISTINOBASE from T_LISTINOBASE where IDPREV = " & IdPrev & "))"
            End If

            If IdListinoBase Then
                sql &= " AND p.idlistinobase = " & IdListinoBase
            End If

            If IdOrdOnline Then
                sql &= " AND o.idordonline = " & IdOrdOnline
            End If

            If OnlyPromo Then
                sql &= " AND o.idpromo <>0 "
            End If

            If IdConsegna Then
                sql &= " AND o.IdOrd IN (SELECT IdOrd FROM TR_ConsOrd WHERE IdCons = " & IdConsegna & ")"
            End If

            If IdRepartoWeb Then
                sql &= " AND IdTipoProd = " & IdRepartoWeb
            End If



            If SoloNonFatturabili Then
                sql &= " AND O.Preventivo = " & enSiNo.No
                sql &= " AND O.IDDoc = 0"
                sql &= " AND Year(o.DataIns) >=2019 "

            End If

            'qui devo escludere gli ordini che stanno in una fattura con statoincasso a impossibile

            sql &= " AND o.idord NOT IN (SELECT IdOrd FROM t_vocifat v INNER JOIN t_contabricavi c ON v.iddoc = c.idricavo AND v.idord = idord AND c.statoincasso=" & enStatoIncasso.Impossibile & ")"

            If OrderContrario Then
                sql &= " ORDER BY IdOrd ASC"
            Else
                sql &= " ORDER BY IdOrd DESC"
            End If

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                While myReader.Read
                    UltimoId = myReader("IdOrd")
                    Dim classe As New OrdineRicerca(CType(myReader, IDataRecord))
                    'If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrd = myReader("IdOrd")
                    'If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
                    'If Not myReader("IdTipoProd") Is DBNull.Value Then classe.IdTipoProd = myReader("IdTipoProd")
                    'If Not myReader("IdProd") Is DBNull.Value Then classe.IdProd = myReader("IdProd")
                    'If Not myReader("IdRub") Is DBNull.Value Then classe.IdRub = myReader("IdRub")
                    'If Not myReader("Lungo") Is DBNull.Value Then classe.Lungo = myReader("Lungo")
                    'If Not myReader("Largo") Is DBNull.Value Then classe.Largo = myReader("Largo")
                    'If Not myReader("DataIns") Is DBNull.Value Then classe.DataIns = myReader("DataIns")
                    'If Not myReader("DataCambioStato") Is DBNull.Value Then classe.DataCambioStato = myReader("DataCambioStato")
                    'If Not myReader("DataPrevConsegna") Is DBNull.Value Then classe.DataPrevConsegna = myReader("DataPrevConsegna")
                    'If Not myReader("DataEffConsegna") Is DBNull.Value Then classe.DataEffConsegna = myReader("DataEffConsegna")
                    'If Not myReader("PeriodoPrevConsegna") Is DBNull.Value Then classe.PeriodoPrevConsegna = myReader("PeriodoPrevConsegna")
                    'If Not myReader("TipoConsegna") Is DBNull.Value Then classe.TipoConsegna = myReader("TipoConsegna")
                    'If Not myReader("OraConsegna") Is DBNull.Value Then classe.OraConsegna = myReader("OraConsegna")
                    'If Not myReader("Stato") Is DBNull.Value Then classe.Stato = myReader("Stato")
                    'If Not myReader("PrezzoProd") Is DBNull.Value Then classe.PrezzoProd = myReader("PrezzoProd")
                    'If Not myReader("Qta") Is DBNull.Value Then classe.Qta = myReader("Qta")
                    'If Not myReader("TotaleForn") Is DBNull.Value Then classe.TotaleForn = myReader("TotaleForn")
                    'If Not myReader("Iva") Is DBNull.Value Then classe.Iva = myReader("Iva")
                    'If Not myReader("CostoSped") Is DBNull.Value Then classe.CostoSped = myReader("CostoSped")
                    'If Not myReader("Sconto") Is DBNull.Value Then classe.Sconto = myReader("Sconto")
                    'If Not myReader("Prezzo") Is DBNull.Value Then classe.Prezzo = myReader("Prezzo")
                    'If Not myReader("IdCorriere") Is DBNull.Value Then classe.IdCorriere = myReader("IdCorriere")
                    'If Not myReader("File") Is DBNull.Value Then classe.File = myReader("File")
                    'If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
                    'If Not myReader("FileSorgente") Is DBNull.Value Then classe.FileSorgente = myReader("FileSorgente")
                    'If Not myReader("NomeFileOriginale") Is DBNull.Value Then classe.NomeFileOriginale = myReader("NomeFileOriginale")
                    'If Not myReader("OrdMail") Is DBNull.Value Then classe.OrdMail = myReader("OrdMail")
                    'If Not myReader("Ricarico") Is DBNull.Value Then classe.Ricarico = myReader("Ricarico")
                    'If Not myReader("Preventivo") Is DBNull.Value Then classe.Preventivo = myReader("Preventivo")
                    'If Not myReader("IdDoc") Is DBNull.Value Then classe.IdDoc = myReader("IdDoc")
                    'If Not myReader("RilascioCli") Is DBNull.Value Then classe.RilascioCli = myReader("RilascioCli")
                    'If Not myReader("NumeroRealeColli") Is DBNull.Value Then classe.NumeroRealeColli = myReader("NumeroRealeColli")

                    'CAMPI EXTRA
                    'If Not myReader("ProdottoDescrizione") Is DBNull.Value Then classe.ProdottoDescrizione = myReader("ProdottoDescrizione")
                    If Not myReader("ClienteNominativo") Is DBNull.Value Then classe.ClienteNominativo = myReader("ClienteNominativo")
                    If Not myReader("NomeBreve") Is DBNull.Value Then classe.CorriereStr = myReader("NomeBreve")
                    'If Not myReader("NumSpazi") Is DBNull.Value Then classe.NumSpazi = myReader("NumSpazi")
                    'If Not myReader("NumDuplic") Is DBNull.Value Then classe.NumDuplicati = myReader("NumDuplic")
                    'If Not myReader("Programmata") Is DBNull.Value Then classe.DataConsProgr = myReader("Programmata")
                    If Not myReader("NMsg") Is DBNull.Value Then classe.NumeroMessaggi = myReader("NMsg")

                    Dim CheckPagato As Boolean = True
                    If Pagato = enSiNo.Si Then
                        'solo quelli con il pagamento
                        If Not classe.DocumentoFiscale Is Nothing AndAlso classe.DocumentoFiscale.PagatoInteramente = False Then
                            CheckPagato = False
                        ElseIf Not classe.ConsegnaAssociata Is Nothing AndAlso classe.ConsegnaAssociata.HaUnPagamentoAnticipato = False Then
                            CheckPagato = False
                        ElseIf classe.ConsegnaAssociata Is Nothing Then
                            CheckPagato = False
                        End If
                    ElseIf Pagato = enSiNo.No Then
                        'solo quelli senza il pagamento
                        If Not classe.DocumentoFiscale Is Nothing AndAlso classe.DocumentoFiscale.PagatoInteramente Then
                            CheckPagato = False
                        ElseIf Not classe.ConsegnaAssociata Is Nothing AndAlso classe.ConsegnaAssociata.HaUnPagamentoAnticipato Then
                            CheckPagato = False
                        ElseIf classe.ConsegnaAssociata Is Nothing Then
                            CheckPagato = False
                        End If
                    End If

                    If CheckPagato Then

                        If SoloNonFatturabili Then
                            If classe.Fatturabile = False Then Ris.Add(classe)
                        Else
                            Ris.Add(classe)
                        End If
                    End If

                End While
                myReader.Close()
            End Using

            If OrderbyDataConsegna Then
                'qui ordino la lista 
                Ris.Sort(AddressOf Comparer)
            End If

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

    Private Function Comparer(ByVal x As OrdineRicerca, ByVal y As OrdineRicerca) As Integer
        Dim result As Integer = x.DataConsProgr.CompareTo(y.DataConsProgr)
        If result = 0 Then result = x.IdOrd.CompareTo(y.IdOrd)
        Return result
    End Function

    Public Sub SganciaOrdiniCollegatiAConsegna(IdCons As Integer)

        Try
            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _Cn
                Dim Sql As String = ""
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

                Sql = "UPDATE T_Ordini SET IdConsRiferimento = 0 WHERE idConsRiferimento = " & IdCons
                UpdateCommand.CommandText = Sql
                UpdateCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Public Sub ResetIdDoc(IdDoc As Integer)

        Try
            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _Cn
                Dim Sql As String = ""
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

                Sql = "UPDATE T_Ordini SET IdDoc = 0 WHERE IdDoc = " & IdDoc
                UpdateCommand.CommandText = Sql
                UpdateCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Public Function DeleteEX(O As Ordine) As Integer
        Dim Ris As Integer = 0
        Try

            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _Cn
                Dim Sql As String = ""

                Sql = "DELETE FROM T_OrdiniCrono"
                Sql &= " WHERE IdOrd = " & O.IdOrd
                UpdateCommand.CommandText = Sql
                UpdateCommand.ExecuteNonQuery()

                Sql = "DELETE FROM T_Sorgenti"
                Sql &= " WHERE IdOrd = " & O.IdOrd
                UpdateCommand.CommandText = Sql
                UpdateCommand.ExecuteNonQuery()

                Sql = "DELETE FROM T_Ordini"
                Sql &= " WHERE IdOrd = " & O.IdOrd
                UpdateCommand.CommandText = Sql
                UpdateCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function AvanzamentoLavori(O As Ordine) As DataTable
        Dim datatb As DataTable = New DataTable("T_OrdiniCrono")
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT DataCrono as [Data], convert(varchar,idstato) As Stato, Login as Operatore FROM T_OrdiniCrono c inner join t_utenti U on c.idoperatore = u.idut"
                'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
                sql &= " WHERE idord = " & O.IdOrd
                sql &= " ORDER BY datacrono"
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

                'Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                'dA.FillSchema(datatb, SchemaType.Source)
                Dim dA As New SqlDataAdapter(myCommand)
                dA.Fill(datatb)

                'datatb.Load(myReader)
                'myReader.Close()
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return datatb

    End Function

    Public Function ListaOrdiniByIdCons(ByVal IdCons As Integer) As List(Of Ordine)

        Dim Ris As New List(Of Ordine)

        Try
            Dim sql As String = "SELECT * FROM T_ordini WHERE idord IN (SELECT DISTINCT idord FROM tr_consord WHERE idcons = " & IdCons & ")"

            Ris = GetData(sql)

        Catch ex As Exception

        End Try
        Return Ris
    End Function

    Public Function ListaOrdiniAssociatiByIdCons(ByVal IdCons As Integer) As List(Of Ordine)

        Dim Ris As New List(Of Ordine)

        Try
            Dim sql As String = "SELECT * FROM t_ordini WHERE idConsRiferimento = " & IdCons

            Ris = GetData(sql)

        Catch ex As Exception

        End Try
        Return Ris
    End Function

    'Public Function ListaOrdiniByIdConss(ByVal IdCons As Integer) As List(Of OrdineRicerca)

    '    Dim Ris As New List(Of OrdineRicerca)

    '    Try
    '        Dim sql As String = ""
    '        sql = "SELECT o.IdOrd,o.idcom,"

    '        sql &= "p.Descrizione as ProdottoDescrizione ,o.iddoc,o.stato "

    '        sql &= " from T_Ordini O, T_Prodotti P "
    '        sql &= " where o.idprod = p.idprod "
    '        sql &= " and idord  in (SELECT IDORD FROM tr_Consord where idcons = " & IdCons & ")"

    '        sql &= " order by DataPrevConsegna asc"
    '        Dim myCommand As SqlCommand = _cn.CreateCommand()
    '        myCommand.CommandText = sql
    '                    If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction 
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        While myReader.Read
    '            Dim classe As New OrdineRicerca
    '            If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrd = myReader("IdOrd")
    '            If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
    '            If Not myReader("Stato") Is DBNull.Value Then classe.Stato = myReader("Stato")
    '            If Not myReader("IdDoc") Is DBNull.Value Then classe.IdDoc = myReader("IdDoc")

    '            'CAMPI EXTRA
    '            If Not myReader("ProdottoDescrizione") Is DBNull.Value Then classe.ProdottoDescrizione = myReader("ProdottoDescrizione")
    '            Ris.Add(classe)
    '        End While

    '    Catch ex As Exception

    '    End Try
    '    Return Ris
    'End Function

    Public Function ReadOperatore(IdOrd As Integer) As OrdineOperatore
        Dim classe As OrdineOperatore = Nothing
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT o.*"
                sql &= ",(select Count(Idpostit) FROM T_Postit Pos WHERE Pos.idord = o.idord AND Pos.tipomsg <> " & enTipoMessaggio.Automatico & ") as NMsg "
                sql &= " FROM T_Ordini O "
                sql &= " WHERE o.idord = " & IdOrd

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    If myReader.HasRows Then

                        myReader.Read()
                        classe = New OrdineOperatore(CType(myReader, IDataRecord))

                        ''DATI EXTRA
                        If Not myReader("NmSg") Is DBNull.Value Then classe.NumeroMessaggi = myReader("NmSg")
                    End If

                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return classe
    End Function

    Public Function SetLastUpdate(IdOrd As Integer,
                                  LastUpdateValue As Integer) As Integer

        Dim Ris As Integer = 0

        Try
            Dim sql As String
            Using DbCommand As SqlCommand = New SqlCommand()
                DbCommand.Connection = _Cn

                sql = "UPDATE T_Ordini SET "
                sql &= "LastUpdate = " & LastUpdateValue
                sql &= " WHERE IdOrd= " & IdOrd

                DbCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then DbCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                DbCommand.ExecuteNonQuery()
                'End If

            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris

    End Function

    Public Function SalvaFile(O As Ordine) As Integer

        Dim Ris As Integer = 0

        Try
            Dim sql As String
            Using DbCommand As SqlCommand = New SqlCommand()
                DbCommand.Connection = _Cn

                sql = "UPDATE T_Ordini SET "
                sql &= "FilePath = " & Ap(O.FilePath)
                sql &= " WHERE IdOrd= " & O.IdOrd

                DbCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then DbCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                DbCommand.ExecuteNonQuery()
                'End If

            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function SalvaDatiConsegna(O As Ordine) As Integer

        Dim Ris As Integer = 0

        Try
            Dim sql As String
            Using DbCommand As SqlCommand = New SqlCommand()
                DbCommand.Connection = _Cn

                sql = "UPDATE T_Ordini SET "

                sql &= "DataPrevConsegna = " & Ap(O.DataPrevConsegna) & ","
                sql &= "PeriodoPrevConsegna = " & O.PeriodoPrevConsegna & ","
                sql &= "OraConsegna = " & Ap(O.OraConsegna)

                sql &= " WHERE IdOrd= " & O.IdOrd

                DbCommand.CommandText = sql
                DbCommand.ExecuteNonQuery()
                'End If

            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function SalvaCliente(O As Ordine) As Integer

        Dim Ris As Integer = 0

        Try
            Dim sql As String
            Using DbCommand As SqlCommand = New SqlCommand()
                DbCommand.Connection = _Cn

                sql = "UPDATE T_Ordini SET "

                sql &= "IdRub = " & O.IdRub

                sql &= " WHERE IdOrd= " & O.IdOrd

                DbCommand.CommandText = sql
                DbCommand.ExecuteNonQuery()
                'End If

            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function IsOrdineCompatibile(O As OrdineRicerca, L As List(Of OrdineRicerca)) As Boolean
        Dim ris As Boolean = True

        Dim lLavEscl As List(Of Lavorazione) = O.ListaLavori.FindAll(Function(x) x.Esclusiva = enSiNo.Si)
        For Each singO As OrdineRicerca In L
            For Each singLav In lLavEscl
                If singO.ListaLavori.FindAll(Function(xx) xx.IdLavoro = singLav.IdLavoro).Count = 0 Then
                    ris = False
                    Exit For
                End If
            Next
            If ris = False Then Exit For
        Next

        Return ris
    End Function

End Class