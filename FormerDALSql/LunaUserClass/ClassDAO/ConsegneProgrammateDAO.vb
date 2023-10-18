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

''' <summary>
'''DAO Class for table T_cons
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ConsegneProgrammateDAO
    Inherits _ConsegneProgrammateDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function CreaConsegnaOggiDaListaOrdini(IdOrdini As List(Of Integer),
                                                  Optional IdConsEsistente As Integer = 0) As ConsegnaProgrammata

        Dim ConsegnaProgrammataInCorso As ConsegnaProgrammata = Nothing
        For Each IdOrdine As Integer In IdOrdini
            Dim OrdineInCons As New Ordine
            OrdineInCons.Read(IdOrdine)

            OrdineInCons.IdConsRiferimento = 0
            OrdineInCons.Save()

            Using mgr As New ConsegneProgrammateDAO
                Dim momentoConsegna As Integer = enMomentoConsegna.Pomeriggio
                If Now.Hour < 14 Then
                    momentoConsegna = enMomentoConsegna.Mattina
                End If
                Dim CheckPrimaCons As Boolean = False
                Dim IdConsVecchia As Integer = 0 'OrdineInCons.ConsegnaAssociata.IdCons
                If IdConsEsistente = 0 Then
                    If Not OrdineInCons.ConsegnaAssociata Is Nothing Then
                        IdConsVecchia = OrdineInCons.ConsegnaAssociata.IdCons
                    End If
                Else
                    ConsegnaProgrammataInCorso = New ConsegnaProgrammata
                    ConsegnaProgrammataInCorso.Read(IdConsEsistente)

                    CheckPrimaCons = True
                End If

                If ConsegnaProgrammataInCorso Is Nothing Then
                    If IdConsVecchia Then
                        If OrdineInCons.ConsegnaAssociata.Giorno.Date = Now.Date Then
                            ConsegnaProgrammataInCorso = OrdineInCons.ConsegnaAssociata.Clone
                            CheckPrimaCons = True
                        End If
                    End If
                End If

                If CheckPrimaCons = False Then
                    Dim CheckStessa As Boolean = False

                    If Not ConsegnaProgrammataInCorso Is Nothing Then
                        If ConsegnaProgrammataInCorso.IdCons = IdConsVecchia Then
                            CheckStessa = True
                        End If
                    End If

                    If CheckStessa = False Then
                        mgr.EliminaOrdineDaConsegna(IdConsVecchia, OrdineInCons.IdOrd)

                        ConsegnaProgrammataInCorso = mgr.RegistraConsegnaOrdineSuGiorno(IdOrdine, OrdineInCons.IdCorriere, Now, OrdineInCons.IdRub, momentoConsegna, OrdineInCons.IdIndirizzo, ConsegnaProgrammataInCorso)

                        mgr.EliminaConsegnaSeVuota(IdConsVecchia)
                    End If

                End If


            End Using
        Next

        Return ConsegnaProgrammataInCorso

    End Function

    Public Function ListaConsegneCorriereConsegnabili(ListaIdCorriere As String) As List(Of ConsegnaProgrammata)
        Dim Ris As List(Of ConsegnaProgrammata) = Nothing

        Dim StrSql As String = String.Empty

        StrSql = "SELECT * FROM T_CONS WHERE (IdStatoConsegna =" & enStatoConsegna.RegistrataCorriere & " AND "
        StrSql &= " IdCorr  IN " & ListaIdCorriere & " AND "
        StrSql &= " CodTrack  <> '' AND "
        StrSql &= " Eliminato  = " & enSiNo.No & ")"
        StrSql &= " OR "
        StrSql &= "(IdStatoConsegna = " & enStatoConsegna.InLavorazione & " And "
        StrSql &= " IdCorr  IN " & ListaIdCorriere & " And "
        StrSql &= " NoRegistrazioneGLS = " & enSiNo.Si & " AND "
        StrSql &= " Eliminato  = " & enSiNo.No & ")"

        Ris = GetData(StrSql)

        'Ris = FindAll("CodTrack",
        '              New LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.RegistrataCorriere),
        '              New LUNA.LunaSearchParameter("IdCorr", _IdCorrString, "IN"),
        '              New LUNA.LunaSearchParameter("CodTrack", String.Empty, "<>"),
        '              New LUNA.LunaSearchParameter("Eliminato", enSiNo.No))

        Return Ris
    End Function

    Public Function ListaConsegneByLastUpdate() As List(Of ConsegnaProgrammata)
        Dim Ris As New List(Of ConsegnaProgrammata)
        Try
            'Dim sql As String = "SELECT o.* from T_Ordini O, T_Prodotti P where o.idprod = p.idprod and " & _
            '    "datediff('n',@DataCambioStato,o.datacambiostato)>0 and o.stato >= " & enStatoOrdine.Preinserito & " ORDER BY IDORD"

            'Dim sql As String = "SELECT * from T_CONS where LastUpdate = 1 and IdCorr <> " & enCorriere.RitiroCliente & " ORDER BY Eliminato desc, IDCons"
            Dim sql As String = "SELECT * FROM T_Cons WHERE LastUpdate = " & enSiNo.Si & " ORDER BY Eliminato desc, IDCons"

            Dim myCommand As SqlCommand = _cn.CreateCommand()

            'Dim DataPar As New SqlParameter("@DataCambioStato", OleDbType.Date)
            'DataPar.Value = DataUltimoAggiornamento
            'myCommand.Parameters.Add(DataPar)

            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read

                Dim classe As New ConsegnaProgrammata(CType(myReader, IDataRecord))

                Ris.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris

    End Function

    Public Function Totale(Optional ByVal Idzona As Integer = 0,
                          Optional ByVal IdRub As Integer = 0,
                          Optional ByVal Giorno As Date = Nothing,
                          Optional ByVal MatPom As Integer = 0,
                          Optional ByVal Idoperatore As Integer = 0) As Integer

        Dim Ris As Integer = 0
        Try

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            Dim sql As String = ""
            'IdCons,Giorno,IdRub,Annotazioni,MatPom,IdCorr,CodTrack,IdOperatore,IdStatoConsegna,NumColli,Peso from T_cons"
            sql = "SELECT Count(*) as TOT FROM  T_cons C, T_Rubrica R WHERE c.idrub = r.idrub "

            '            sql &= " and c.idrub = " & IdRub & " and R.Idzona = " & Idzona
            sql &= " AND R.Idzona = " & Idzona

            sql &= " AND (day(c.giorno) = " & Giorno.Day & " AND month(c.giorno) = " & Giorno.Month & " AND year(c.giorno) = " & Giorno.Year & ")"

            If Idoperatore Then
                sql &= " AND c.idoperatore = " & Idoperatore
            End If

            If MatPom Then
                sql &= " AND c.matpom= " & MatPom
            End If
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            If myReader.HasRows Then
                myReader.Read()
                Ris = myReader(0)
            End If
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

    Public Function EliminaConsegnaSeVuota(IdCons As Integer)

        Dim lst As List(Of ConsProgrOrdini) = Nothing

        Using mgr As New ConsProgrOrdiniDAO
            lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsProgrOrdini.IdCons, IdCons))
        End Using

        Using C As New ConsegnaProgrammata
            C.Read(IdCons)

            If lst.Count = 0 Then
                'qui devo cancellare la consegna programmata
                'x.Delete(C)

                C.LastUpdate = 1
                C.Eliminato = enSiNo.Si
                C.Save()
                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, IdCons, "Consegna schedulata per l'eliminazione")
                'MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.ConsegnaIdCons, "Consegna schedulata per l'eliminazione")
                'qui devo sganciare tutte gli ordini collegati a questa consegna
                Using mgr As New OrdiniDAO
                    mgr.SganciaOrdiniCollegatiAConsegna(C.IdCons)
                End Using

            Else
                C.AggiornaColliPeso()
            End If

        End Using
        Return 0
    End Function

    Private Function EliminaOrdineDaConsegna(C As ConsegnaRicerca) As Integer

        EliminaOrdineDaConsegna(C.IdCons, C.IdOrd)

    End Function

    Public Function EliminaOrdineDaConsegna(IdCons As Integer, IdOrd As Integer) As Integer
        Dim Ris As Integer = 0

        Try

            'IN CASO ELIMINARE L'IDCONS DALLA QUERY TANTO NON DOVREBBE SERVIRE

            'If IdCons Then
            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_cons SET DELETED=True "

                Dim Sql As String = "DELETE FROM TR_consOrd "
                Sql &= " WHERE IdOrd = " & IdOrd

                'DISATTIVATO IL 8/4/2015 per eliminarlo da qualsiasi consegna
                'If IdCons Then Sql &= " and IdCons = " & IdCons

                UpdateCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                UpdateCommand.ExecuteNonQuery()

                Sql = " UPDATE T_ordini set IdConsProgrammata = 0 WHERE IdOrd = " & IdOrd

                'DISATTIVATO IL 8/4/2015 per eliminarlo da qualsiasi consegna
                'If IdCons Then Sql &= " and IdCons = " & IdCons

                UpdateCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                UpdateCommand.ExecuteNonQuery()

            End Using

            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Eliminato da Consegna " & IdCons)
            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, IdCons, "Eliminato Ordine " & IdOrd & " dalla Consegna")

            'End If
        Catch ex As Exception
            ManageError(ex)
            Ris = 1
        End Try

        Return Ris
    End Function

    Public Function ListaMerceProntaSpedireCorriere() As List(Of ConsegnaProgrammata)
        Dim Sql As String = "SELECT C.*,CC.Descrizione as Corriere, R.RagSoc FROM T_Cons C, T_Corriere CC, T_Rubrica R WHERE C.idcorr = cc.idcorriere " &
            " AND R.idrub = c.idrub AND C.IdCorr NOT IN (1,2) AND c.idcons IN " &
            "(SELECT DISTINCT IDCONS FROM TR_CONSORD C, T_ORDINI O WHERE C.idord = o.idord AND O.stato = " & enStatoOrdine.ProntoRitiro & ")"

        Dim Ls As New List(Of ConsegnaProgrammata)
        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            While myReader.Read
                Dim classe As New ConsegnaProgrammata(CType(myReader, IDataRecord))
                'If Not myReader("IdCons") Is DBNull.Value Then classe.IdCons = myReader("IdCons")
                'If Not myReader("Giorno") Is DBNull.Value Then classe.Giorno = myReader("Giorno")
                'If Not myReader("IdRub") Is DBNull.Value Then classe.IdRub = myReader("IdRub")
                'If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
                'If Not myReader("MatPom") Is DBNull.Value Then classe.MatPom = myReader("MatPom")
                'If Not myReader("IdCorr") Is DBNull.Value Then classe.IdCorr = myReader("IdCorr")
                'If Not myReader("CodTrack") Is DBNull.Value Then classe.CodTrack = myReader("CodTrack")
                'If Not myReader("IdOperatore") Is DBNull.Value Then classe.IdOperatore = myReader("IdOperatore")
                'If Not myReader("IdStatoConsegna") Is DBNull.Value Then classe.IdStatoConsegna = myReader("IdStatoConsegna")
                'If Not myReader("NumColli") Is DBNull.Value Then classe.NumColli = myReader("NumColli")
                'If Not myReader("Peso") Is DBNull.Value Then classe.Peso = myReader("Peso")

                If Not myReader("RagSoc") Is DBNull.Value Then classe.RagSoc = myReader("RagSoc")
                If Not myReader("Corriere") Is DBNull.Value Then classe.CorriereNome = myReader("Corriere")
                Ls.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls

    End Function

    Public Function ReadByIdOrd(IdOrd As Integer) As ConsegnaProgrammata
        Dim Sql As String = "SELECT C.* FROM T_CONS C INNER JOIN TR_CONSORD CO ON C.idCons = CO.idcons WHERE CO.idord = " & IdOrd
        Dim classe As ConsegnaProgrammata = Nothing
        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            myReader.Read()

            If myReader.HasRows Then
                classe = New ConsegnaProgrammata(CType(myReader, IDataRecord))
                'If Not myReader("IdCons") Is DBNull.Value Then classe.IdCons = myReader("IdCons")
                'If Not myReader("Giorno") Is DBNull.Value Then classe.Giorno = myReader("Giorno")
                'If Not myReader("IdRub") Is DBNull.Value Then classe.IdRub = myReader("IdRub")
                'If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
                'If Not myReader("MatPom") Is DBNull.Value Then classe.MatPom = myReader("MatPom")
                'If Not myReader("IdCorr") Is DBNull.Value Then classe.IdCorr = myReader("IdCorr")
                'If Not myReader("CodTrack") Is DBNull.Value Then classe.CodTrack = myReader("CodTrack")
                'If Not myReader("IdOperatore") Is DBNull.Value Then classe.IdOperatore = myReader("IdOperatore")
                'If Not myReader("IdStatoConsegna") Is DBNull.Value Then classe.IdStatoConsegna = myReader("IdStatoConsegna")
                'If Not myReader("NumColli") Is DBNull.Value Then classe.NumColli = myReader("NumColli")
                'If Not myReader("Peso") Is DBNull.Value Then classe.Peso = myReader("Peso")
                'If Not myReader("IdPagam") Is DBNull.Value Then classe.IdPagam = myReader("IdPagam")
                'If Not myReader("TipoDoc") Is DBNull.Value Then classe.TipoDoc = myReader("TipoDoc")
                'If Not myReader("RagSoc") Is DBNull.Value Then classe.RagSoc = myReader("RagSoc")
                'If Not myReader("Corriere") Is DBNull.Value Then classe.CorriereNome = myReader("Corriere")

            End If


            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return classe
    End Function

    Public Function GetPrimaConsegnaCompatibileOrdine(O As Ordine,
                                                      IdCorr As Integer,
                                                      Giorno As Date,
                                                      IdRub As Integer,
                                                      MomentoConsegna As Integer,
                                                      IdIndirizzo As Integer,
                                                      Optional ControllaUscitiMagazzino As Boolean = True,
                                                      Optional SoloUscitiMagazzino As Boolean = False,
                                                      Optional IdConsDaNonConsiderare As Integer = 0,
                                                      Optional IdPagamentoSel As Integer = -1,
                                                      Optional IdAziendaForced As Integer = 0) As ConsegnaProgrammata
        Dim ris As ConsegnaProgrammata = Nothing
        Try
            Using R As New VoceRubrica
                R.Read(O.IdRub)
                If IdPagamentoSel = -1 Then
                    'qui prendo il default del cliente
                    If Not O.ConsegnaAssociata Is Nothing Then
                        IdPagamentoSel = O.ConsegnaAssociata.IdPagam
                    Else
                        IdPagamentoSel = R.IdPagamento
                    End If

                End If

                If SoloUscitiMagazzino = False Then
                    If O.Stato = enStatoOrdine.UscitoMagazzino Then
                        SoloUscitiMagazzino = True
                    End If
                End If

                Dim PAzienda As LUNA.LunaSearchParameter = Nothing

                If IdAziendaForced Then
                    PAzienda = New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdAziendaForzata, IdAziendaForced)
                End If

                Dim lst As List(Of ConsegnaProgrammata) = Nothing
                Using mgr As New ConsegneProgrammateDAO
                    lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Giorno, Giorno),
                                      New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, IdCorr),
                                      New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdRub, IdRub),
                                      New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdIndirizzo, IdIndirizzo),
                                      New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdPagam, IdPagamentoSel),
                                      New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.Si, "<>"),
                                      PAzienda)
                End Using

                'a differenza di prima non e' detto che ritorni una sola consegna perche ci potrebbero essere le consegne bloccate
                'bloccate per una serie di motivi 
                ' e in quel caso invece di crearne un altra passo a vedere tutte quelle di quel cliente se per qualche motivo quella dopo puo essere buona non ha senso che ne creo
                'un altra
                If lst.Count Then
                    For Each singC As ConsegnaProgrammata In lst
                        'ciclo per tutte le consegne agganciandomi alla prima disponibile
                        Dim OkStatoOrdini As Boolean = True
                        If SoloUscitiMagazzino Then
                            If singC.ListaOrdini.FindAll(Function(x) x.Stato <> enStatoOrdine.UscitoMagazzino).Count Then
                                OkStatoOrdini = False
                            End If
                        Else
                            If ControllaUscitiMagazzino Then
                                'qui non potra mai arrivare un uscito da magazzino
                                If singC.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.UscitoMagazzino).Count Then
                                    OkStatoOrdini = False
                                End If
                            End If
                        End If

                        If O.ConsegnaGarantita <> Date.MinValue Then
                            'se c sono ordini con data non garantia che nn sono in stato pronto abortisco
                            If singC.ListaOrdini.FindAll(Function(x) x.ConsegnaGarantita = Date.MinValue And x.Stato <> enStatoOrdine.ProntoRitiro).Count Then
                                OkStatoOrdini = False
                            End If
                        Else
                            'qui invece devo vedere se lo stato dell'ordine è prontoritiro
                            If singC.ListaOrdini.FindAll(Function(x) x.ConsegnaGarantita <> Date.MinValue).Count Then
                                If O.Stato <> enStatoOrdine.ProntoRitiro Then
                                    OkStatoOrdini = False
                                End If
                            End If
                        End If

                        If OkStatoOrdini Then

                            'If singC.Modificabile(ControllaUscitiMagazzino) AndAlso
                            If singC.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito AndAlso 'singC.ModificabileEx(False, False, True, True, False, ControllaUscitiMagazzino).Modificabile AndAlso
                               singC.IdCons <> IdConsDaNonConsiderare Then
                                If Not O.ConsegnaAssociata Is Nothing Then
                                    'qui faccio altri controlli accessori
                                    If singC.StampaDocumenti = O.ConsegnaAssociata.StampaDocumenti Then
                                        If singC.NoCartaceo = O.ConsegnaAssociata.NoCartaceo Then
                                            ris = singC
                                            Exit For
                                        End If
                                    End If
                                Else
                                    ris = singC
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                End If
            End Using
        Catch ex As Exception

        End Try

        Return ris
    End Function

    Public Function RegistraConsegnaOrdineSuGiorno(IdOrd As Integer,
                                                   IdCorr As Integer,
                                                   Giorno As Date,
                                                   IdRub As Integer,
                                                   MomentoConsegna As Integer,
                                                   IdIndirizzo As Integer,
                                                   Optional ConsegnaEsistente As ConsegnaProgrammata = Nothing,
                                                   Optional ControllaUscitiMagazzino As Boolean = True,
                                                   Optional SoloUscitiMagazzino As Boolean = False,
                                                   Optional IdConsDaNonConsiderare As Integer = 0,
                                                   Optional IdPagamentoSel As Integer = -1,
                                                   Optional StampaAutomaticaDocumenti As Boolean = False,
                                                   Optional EmailNotificaCorriere As String = "",
                                                   Optional ForzaCreazioneNuovaConsegna As Boolean = False) As ConsegnaProgrammata

        'prima cancello l'ordine dalle consegne programmate
        'cerco una consegna programmata per quel cliente quel giorno con quel corriere
        Dim C As ConsegnaProgrammata = Nothing

        Dim IdAziendaForced As Integer = 0

        'modifica fatta per non prendere in considerazione l'orario 
        Using R As New VoceRubrica
            R.Read(IdRub)

            Giorno = Giorno.Date

            Using OrdineRif As New Ordine
                OrdineRif.Read(IdOrd)

                If Not OrdineRif.ConsegnaAssociata Is Nothing AndAlso
                    OrdineRif.ConsegnaAssociata.HaUnPagamentoAnticipato Then
                    OrdineRif.ConsegnaAssociata.Giorno = Giorno
                    OrdineRif.ConsegnaAssociata.LastUpdate = enSiNo.Si
                    OrdineRif.ConsegnaAssociata.Save()
                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, OrdineRif.ConsegnaAssociata.IdCons, "Impostata Data consegna garantita a consegna con pagamento")

                    'If Not OrdineRif.ConsegnaAssociata Is Nothing AndAlso
                    '    (OrdineRif.ConsegnaAssociata.HaUnPagamentoAnticipato OrElse
                    '    OrdineRif.ConsegnaAssociata.HaDocumentiFiscali) Then
                    '    If OrdineRif.ConsegnaAssociata.Giorno <> Giorno Then
                    '        OrdineRif.ConsegnaAssociata.Giorno = Giorno
                    '        OrdineRif.ConsegnaAssociata.LastUpdate = enSiNo.Si
                    '        OrdineRif.ConsegnaAssociata.Save()
                    '        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, OrdineRif.ConsegnaAssociata.IdCons, "Impostata Data consegna garantita a consegna con pagamento")
                    '    End If
                Else
                    If IdPagamentoSel = -1 Then
                        'qui prendo il default del cliente
                        If Not OrdineRif.ConsegnaAssociata Is Nothing Then
                            IdPagamentoSel = OrdineRif.ConsegnaAssociata.IdPagam
                        Else
                            IdPagamentoSel = R.IdPagamento
                        End If
                    End If

                    Dim IdConsegnaVecchia As Integer = OrdineRif.IdCons

                    If Not OrdineRif.ConsegnaAssociata Is Nothing Then
                        IdAziendaForced = OrdineRif.ConsegnaAssociata.IdAziendaForzata
                    Else
                        IdAziendaForced = MgrAziende.IdAziende.AziendaSrl
                    End If

                    'If SoloUscitiMagazzino = False Then
                    '    If OrdineRif.Stato = enStatoOrdine.UscitoMagazzino Then
                    '        SoloUscitiMagazzino = True
                    '    End If
                    'End If

                    'Dim IdConsProgrammata As Integer = 0

                    'ConsegnaEsistente
                    If ConsegnaEsistente Is Nothing Then
                        If ForzaCreazioneNuovaConsegna = False Then

                            C = GetPrimaConsegnaCompatibileOrdine(OrdineRif,
                                                                  IdCorr,
                                                                  Giorno,
                                                                  IdRub,
                                                                  MomentoConsegna,
                                                                  IdIndirizzo,
                                                                  ControllaUscitiMagazzino,
                                                                  SoloUscitiMagazzino,
                                                                  IdConsDaNonConsiderare,
                                                                  IdPagamentoSel,
                                                                  IdAziendaForced)

                            'Dim lst As List(Of ConsegnaProgrammata) = Nothing
                            'Using mgr As New ConsegneProgrammateDAO
                            '    lst = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Giorno, Giorno),
                            '                      New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, IdCorr),
                            '                      New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdRub, IdRub),
                            '                      New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdIndirizzo, IdIndirizzo),
                            '                      New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdPagam, IdPagamentoSel),
                            '                      New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.Si, "<>"))
                            'End Using

                            ''a differenza di prima non e' detto che ritorni una sola consegna perche ci potrebbero essere le consegne bloccate
                            ''bloccate per una serie di motivi 
                            '' e in quel caso invece di crearne un altra passo a vedere tutte quelle di quel cliente se per qualche motivo quella dopo puo essere buona non ha senso che ne creo
                            ''un altra
                            'If lst.Count Then
                            '    For Each singC As ConsegnaProgrammata In lst
                            '        'ciclo per tutte le consegne agganciandomi alla prima disponibile
                            '        Dim OkStatoOrdini As Boolean = True
                            '        If SoloUscitiMagazzino Then
                            '            If singC.ListaOrdini.FindAll(Function(x) x.Stato <> enStatoOrdine.UscitoMagazzino).Count Then
                            '                OkStatoOrdini = False
                            '            End If
                            '        End If
                            '        If OkStatoOrdini Then
                            '            If singC.Modificabile(ControllaUscitiMagazzino) AndAlso singC.IdCons <> IdConsDaNonConsiderare Then
                            '                If Not OrdineRif.ConsegnaAssociata Is Nothing Then
                            '                    'qui faccio altri controlli accessori
                            '                    If singC.StampaDocumenti = OrdineRif.ConsegnaAssociata.StampaDocumenti Then
                            '                        If singC.NoCartaceo = OrdineRif.ConsegnaAssociata.NoCartaceo Then
                            '                            C = singC
                            '                            Exit For
                            '                        End If
                            '                    End If
                            '                Else
                            '                    C = singC
                            '                    Exit For
                            '                End If
                            '            End If
                            '        End If
                            '    Next
                            'End If
                        End If
                    Else
                        'se ti dico una consegna usi quella e basta
                        C = ConsegnaEsistente
                    End If

                    Dim SuConsegnaEsistente As Boolean = False

                    If C Is Nothing Then
                        'qui la devo creare

                        Dim IdPagamento As Integer = IdPagamentoSel 'r.idpagamento
                        Dim TipoDoc As Integer = R.TipoDoc
                        Dim StampaDoc As Integer = enStampaDocumenti.No 'per ora metto NO su stampa automatica documenti poi vediamo
                        Dim Annotazioni As String = String.Empty
                        Dim TraceEmail As String = String.Empty
                        Dim NoCartaceo As Integer = enSiNo.No
                        Dim NoRegistrazioneGLS As Integer = enSiNo.No
                        Dim AssRilIntMitt As Integer = enSiNo.No
                        Dim ImportoNetto As Decimal = 0
                        'qui devo controllare se c'era gia una consegna precedente e riprendere i default di quella

                        If IdConsegnaVecchia Then
                            IdPagamento = OrdineRif.ConsegnaAssociata.IdPagam
                            TipoDoc = OrdineRif.ConsegnaAssociata.TipoDoc
                            StampaDoc = OrdineRif.ConsegnaAssociata.StampaDocumenti
                            Annotazioni = OrdineRif.ConsegnaAssociata.Annotazioni
                            TraceEmail = OrdineRif.ConsegnaAssociata.EmailNotificheCorriere
                            NoCartaceo = OrdineRif.ConsegnaAssociata.NoCartaceo
                            NoRegistrazioneGLS = OrdineRif.ConsegnaAssociata.NoRegistrazioneGLS
                            AssRilIntMitt = OrdineRif.ConsegnaAssociata.AssRilIntMitt
                            ImportoNetto = OrdineRif.ConsegnaAssociata.ImportoNetto
                        Else
                            'qui non c'e' una consegna di provenienza
                            TraceEmail = EmailNotificaCorriere
                            If (OrdineRif.IdCorriere <> enCorriere.RitiroCliente And
                            OrdineRif.IdCorriere <> enCorriere.TipografiaFormer And
                            OrdineRif.IdCorriere <> enCorriere.TipografiaFormerFuoriRaccordo) OrElse
                            OrdineRif.VoceRubrica.StampaAutomaticaDocumenti = enSiNo.Si OrElse
                            StampaAutomaticaDocumenti = True Then
                                StampaDoc = enStampaDocumenti.Si
                            End If
                            AssRilIntMitt = OrdineRif.VoceRubrica.AssRilIntMitt

                            If IdPagamento <> enMetodoPagamento.ContrassegnoAlRitiro Then
                                If IdIndirizzo Then
                                    NoCartaceo = enSiNo.Si
                                End If
                            End If
                        End If

                        'messa per evitare le consegne di sabato pomeriggio a prescindere dal corriere 
                        If MomentoConsegna = enMomentoConsegna.Pomeriggio And Giorno.DayOfWeek = DayOfWeek.Saturday Then
                            MomentoConsegna = enMomentoConsegna.Mattina
                        End If

                        'Using mgrC As New ConsProgrOrdiniDAO
                        '    Dim l As List(Of ConsProgrOrdini) = mgrC.FindAll(New LUNA.LunaSearchParameter("IdOrd", IdOrd))
                        '    If l.Count Then
                        '        Dim CpVecchia As New ConsegnaProgrammata
                        '        CpVecchia.Read(l(0).IdCons)
                        '       IdPagamento = CpVecchia.IdPagam
                        '       TipoDoc = CpVecchia.TipoDoc
                        '       StampaDoc = CpVecchia.StampaDocumenti
                        '        CpVecchia = Nothing
                        '    End If
                        'End Using

                        'If IdPagamentoSel <> -1 Then
                        '    IdPagamento = IdPagamentoSel
                        'End If

                        C = New ConsegnaProgrammata
                        C.Giorno = Giorno
                        C.DataPrevistaOriginale = Giorno
                        C.IdCorr = IdCorr
                        C.MatPom = MomentoConsegna
                        C.IdIndirizzo = IdIndirizzo
                        C.IdRub = IdRub
                        C.NumColli = OrdineRif.NumeroRealeColli
                        C.Peso = OrdineRif.Prodotto.PesoComplessivo
                        C.IdPagam = IdPagamento
                        C.TipoDoc = TipoDoc
                        C.LastUpdate = enSiNo.Si
                        C.StampaDocumenti = StampaDoc
                        C.IdStatoConsegna = enStatoConsegna.InLavorazione
                        C.Annotazioni = Annotazioni
                        C.EmailNotificheCorriere = TraceEmail
                        C.NoCartaceo = NoCartaceo
                        C.NoRegistrazioneGLS = NoRegistrazioneGLS
                        C.AssRilIntMitt = AssRilIntMitt
                        C.IdAziendaForzata = IdAziendaForced
                        C.ImportoNetto = ImportoNetto
                        C.Save()

                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna,
                                                      C.IdCons,
                                                      "CREATA NUOVA CONSEGNA")
                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna,
                                                      C.IdCons,
                                                      "Giorno: " & C.Giorno.ToString("dd/MM/yyyy"))

                        'COMMENTATO CONTROLLO SU CORRIERE DI DEFAULT NON PIU NECESSARIO
                        'If R.IdCorriere <> IdCorr Then

                        '    Dim IdMitt As Integer = 1

                        '    Try
                        '        IdMitt = Postazione.UtenteConnesso.IdUt
                        '    Catch ex As Exception

                        '    End Try

                        '    Dim M As New Messaggio
                        '    M.IdMitt = IdMitt
                        '    M.IdDest = 0
                        '    M.IdOrd = IdOrd
                        '    M.Titolo = "Corriere diverso dal default Ordine: " & IdOrd
                        '    M.Testo = "ATTENZIONE! Il corriere previsto nell'ordine è diverso dal corriere che è stato inserito come default per il cliente!"
                        '    M.Save()
                        'End If
                    Else
                        SuConsegnaEsistente = True
                        C.LastUpdate = enSiNo.Si
                        'C.Save()
                    End If

                    'qui controllo che sia tutto ok e non ci siano doppioni
                    'Using mgrCO As New ConsProgrOrdiniDAO
                    '    Dim lCo As List(Of ConsProgrOrdini) = mgrCO.FindAll(New LUNA.LunaSearchParameter("IdOrd", IdOrd))
                    '    If lCo.Count Then
                    '        'qui si è verificato un errore
                    '        Dim buffer As String = System.Environment.StackTrace.Replace(" in ", "<br>")
                    '        FormerLib.FormerHelper.Mail.InviaMail("Errore Incongruenza IDORD " & IdOrd, buffer, "soft@tipografiaformer.it")
                    '    End If
                    'End Using

                    'qui lo elimino dalla consegna precedente 
                    If IdConsegnaVecchia Then
                        EliminaOrdineDaConsegna(IdConsegnaVecchia, OrdineRif.IdOrd)
                        EliminaConsegnaSeVuota(IdConsegnaVecchia)
                    End If

                    OrdineRif.IdConsProgrammata = C.IdCons
                    OrdineRif.Save()

                    Using cO As New ConsProgrOrdini
                        cO.IdCons = C.IdCons
                        cO.IdOrd = IdOrd
                        cO.Save()
                    End Using

                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "REGISTRATO su Consegna " & IIf(SuConsegnaEsistente, "ESISTENTE ", "NUOVA ") & C.IdCons)
                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, C.IdCons, "REGISTRATO Ordine " & IdOrd & " sulla CONSEGNA")
                    C.AggiornaColliPeso()
                End If


            End Using
        End Using

        Return C

    End Function

    Public Sub AvanzaStatoConsegna(Cons As ConsegnaProgrammata, Stato As enStatoConsegna)
        If Not Cons Is Nothing Then
            'TODO: MODIFICATA LINEA SEGUENTE PER FAR AVANZARE LO STATO DA REGISTRATACORRIERE (7) A INCONSEGNA (1)
            'If Cons.IdStatoConsegna <Stato Then
            If Cons.IdStatoConsegna <> Stato Then
                Cons.IdStatoConsegna = Stato
                Cons.LastUpdate = enSiNo.Si

                Select Case Stato
                    Case enStatoConsegna.InLavorazione

                    Case enStatoConsegna.InConsegna

                    Case enStatoConsegna.Consegnata
                        Cons.DataEffConsegna = Now

                        Using mgr As New OrdiniDAO
                            For Each o As Ordine In Cons.ListaOrdini
                                If o.Stato < enStatoOrdine.Consegnato Then
                                    mgr.InserisciLog(o.IdOrd, enStatoOrdine.Consegnato,, False)
                                End If
                            Next
                        End Using

                        'qui devo vedere se c'e' un pagamento anticipato per questo ordine e in caso portarlo a pagato interamente

                        If Cons.HaUnPagamentoAnticipato Then

                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, Cons.IdCons, "Consegna con Pagamento Anticipato, Spostati tutti gli ordini a PAGATO")
                            Using mgr As New OrdiniDAO
                                For Each o As Ordine In Cons.ListaOrdini
                                    mgr.InserisciLog(o.IdOrd, enStatoOrdine.PagatoInteramente,, False)
                                Next
                            End Using
                        Else
                            For Each D As Ricavo In Cons.ListaDocumenti
                                If D.TotaleAncoraDaPagare = 0 Then
                                    MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, Cons.IdCons, "Documento " & D.IdRicavo & " nella consegna risulta pagato, Spostati tutti gli ordini contenuti a PAGATO")
                                    Using mgr As New OrdiniDAO
                                        For Each o As Ordine In D.ListaOrdini
                                            mgr.InserisciLog(o.IdOrd, enStatoOrdine.PagatoInteramente,, False)
                                        Next
                                    End Using
                                End If
                            Next
                        End If

                End Select

                Cons.Save()

                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, Cons.IdCons, "CAMBIATO stato a " & FormerLib.FormerEnum.FormerEnumHelper.StatoConsegnaString(Stato))

                'FormerLog.RegistraVoce("CONSEGNA " & Cons.IdCons & " - CAMBIO STATO A " & Stato.ToString)

            End If
        End If

    End Sub

    Public Function SetLastUpdate(IdCons As Integer, LastUpdateValue As Integer) As Integer

        Dim Ris As Integer = 0

        Try
            Dim sql As String
            Using DbCommand As SqlCommand = New SqlCommand()
                DbCommand.Connection = _Cn

                sql = "UPDATE T_Cons SET "
                sql &= "LastUpdate = " & LastUpdateValue
                sql &= " WHERE IdCons = " & IdCons

                DbCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then DbCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                DbCommand.ExecuteNonQuery()
                'End If
                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, IdCons, "CAMBIATO LastUpdate a " & LastUpdateValue)

            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris

    End Function

    Public Function GetConsDaNumColloBartolini(ByVal NumCollo As Integer) As ConsegnaProgrammata
        Dim ris As ConsegnaProgrammata = Nothing
        Try
            Dim LS As New List(Of ConsegnaProgrammata)
            LS = FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCorr, "(" & enCorriere.Bartolini & ", " & enCorriere.PortoAssegnatoBartolini & ")", "IN"),
                         New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.RegistrataCorriere),
                         New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.CodTrack, String.Empty, "<>"))
            For Each C As ConsegnaProgrammata In LS
                Dim Trovato As Boolean = False
                Dim NumeroCollo As Integer = C.NumeroPrimoColloBartolini
                Dim NumColli As Integer = C.NumColli
                For i = 1 To NumColli
                    If NumeroCollo = NumCollo Then
                        ris = C
                        Trovato = True
                        Exit For
                    End If
                    NumeroCollo += 1
                Next
                If Trovato Then Exit For
            Next
        Catch ex As Exception

        End Try
        Return ris
    End Function

End Class

Public Class ConsegneRicercaDAO
    Inherits LUNA.LunaBaseClassDAO(Of ConsegnaRicerca)

    'CLASSE DI RICERCA PER LE CONSEGNE CHE INCLUDE LE CONSEGNE PREVISTE E PROGRAMMATE

    Public Overloads Overrides Sub Delete(ByRef obj As ConsegnaRicerca, Optional ByRef ListaObj As System.Collections.Generic.List(Of ConsegnaRicerca) = Nothing)

    End Sub

    Public Overloads Overrides Sub Delete(Id As Integer)

    End Sub

    Public Overrides Function FindAll(ParamArray Parameter() As LUNA.LunaSearchParameter) As System.Collections.Generic.IEnumerable(Of ConsegnaRicerca)

    End Function

    Public Overrides Function GetAll(Optional OrderByField As String = "", Optional AddEmptyItem As Boolean = False) As System.Collections.Generic.IEnumerable(Of ConsegnaRicerca)

    End Function

    Public Overrides Function Read(Id As Integer) As ConsegnaRicerca

    End Function

    Public Overrides Function Save(ByRef obj As ConsegnaRicerca) As Integer

    End Function

    Public Function ListaMerceUscitaMagazzino(ByVal MatPom As Integer, _
                          ByVal IdCorr As Integer, _
                          Optional ByVal Giorno As Date = Nothing, _
                          Optional ByVal IdRub As Integer = 0, _
                          Optional ByVal ListaStati As String = "", _
                          Optional ByVal IdZona As Integer = 0, _
                          Optional ByVal IdOperatore As Integer = 0, _
                          Optional ByVal Iniziale As String = "", _
                          Optional ByVal TestoLibero As String = "", _
                          Optional ByVal ListaCorrEsclusi As String = "", _
                          Optional ByVal LastWeek As Boolean = False) As List(Of ConsegnaRicerca)

        Dim Lst As New List(Of ConsegnaRicerca)

        Try

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT c.*,R.RagSoc,Cr.Descrizione" & _
                ",t.idord,p.descrizione as ProdottoNome ,o.stato as statoord, t.inserito " & _
                ", o.dataeffconsegna " & _
                " from T_Cons C,T_Rubrica R, T_Corriere CR, TR_CONsORD T, T_Prodotti P, t_Ordini o "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " WHERE c.idrub = r.idrub AND c.idcorr = cr.idcorriere"
            If Giorno <> Date.MinValue Then sql &= " AND (day(giorno) = " & Giorno.Day & " AND month(giorno) = " & Giorno.Month & " and year(giorno) = " & Giorno.Year & ")"

            If MatPom <> -1 Then sql &= " AND MatPom = " & MatPom
            sql &= " AND c.idcons = t.idcons AND o.idord = t.idord AND p.idprod = o.idprod"

            If IdCorr Then
                sql &= " AND c.idcorr = " & IdCorr
            End If

            If ListaCorrEsclusi.Length Then
                sql &= " AND c.idcorr NOT IN (" & ListaCorrEsclusi & ")"
            End If

            If IdRub Then
                sql &= " AND c.idrub = " & IdRub
            End If

            If IdOperatore Then
                sql &= " AND c.idoperatore = " & IdOperatore
            End If

            If IdZona Then
                sql &= " AND r.idzona = " & IdZona
            End If

            'If ListaStati.Length Then
            'sql &= " AND c.idcons IN (SELECT IDCONS FROM TR_CONSORD CO, T_ORDINI O WHERE CO.IDCONS = c.idcons and co.idord = o.idord and o.stato in (" & ListaStati & "))"
            'End If
            sql &= " AND o.stato IN (" & ListaStati & ") "

            If Iniziale.Length Then
                sql &= " AND R.Ragsoc LIKE '" & Iniziale & "%' "
            End If

            If TestoLibero.Trim.Length Then
                sql &= " AND r.ragsoc " & ApLike(TestoLibero)
            End If

            If LastWeek Then
                sql &= " AND datediff(d,o.datacambiostato ,getdate()) <= 7 "
            End If

            sql &= " ORDER BY o.DataEffConsegna desc, r.ragsoc"
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read
                Dim classe As New ConsegnaRicerca(CType(myReader, IDataRecord))
                'If Not myReader("IdCons") Is DBNull.Value Then classe.IdCons = myReader("IdCons")
                'If Not myReader("Giorno") Is DBNull.Value Then classe.Giorno = myReader("Giorno")
                'If Not myReader("IdRub") Is DBNull.Value Then classe.IdRub = myReader("IdRub")
                'If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
                'If Not myReader("MatPom") Is DBNull.Value Then classe.MatPom = myReader("MatPom")
                'If Not myReader("IdCorr") Is DBNull.Value Then classe.IdCorr = myReader("IdCorr")
                'If Not myReader("CodTrack") Is DBNull.Value Then classe.CodTrack = myReader("CodTrack")
                'If Not myReader("IdOperatore") Is DBNull.Value Then classe.IdOperatore = myReader("IdOperatore")
                'If Not myReader("IdStatoConsegna") Is DBNull.Value Then classe.IdStatoConsegna = myReader("IdStatoConsegna")
                'If Not myReader("NumColli") Is DBNull.Value Then classe.NumColli = myReader("NumColli")
                'If Not myReader("Peso") Is DBNull.Value Then classe.Peso = myReader("Peso")

                If Not myReader("RagSoc") Is DBNull.Value Then classe.RagSoc = myReader("RagSoc")
                If Not myReader("Descrizione") Is DBNull.Value Then classe.CorriereNome = myReader("Descrizione")
                If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrd = myReader("idord")
                If Not myReader("ProdottoNome") Is DBNull.Value Then classe.ProdottoNome = myReader("ProdottoNome")
                If Not myReader("StatoOrd") Is DBNull.Value Then classe.StatoOrdine = myReader("statoord")
                If Not myReader("Inserito") Is DBNull.Value Then classe.Inserito = myReader("Inserito")
                If Not myReader("DataEffConsegna") Is DBNull.Value Then classe.DataEffConsegna = myReader("DataEffConsegna")
                classe.Programmata = True
                Lst.Add(classe)
            End While

            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Lst

    End Function

    Public Function ListaConsegneConDocDaEmettere(GiornoEffConsegna As Date) As List(Of ConsegnaRicerca)

        Dim Lst As New List(Of ConsegnaRicerca)
        Try
            Dim sql As String = ""
            sql = "SELECT c.* ,R.RagSoc,Cr.Descrizione" & _
                ",t.idord,p.descrizione as ProdottoNome ,o.stato as statoord, t.inserito " & _
                ", o.dataeffconsegna " & _
                " from T_Cons C,T_Rubrica R, T_Corriere CR, TR_CONsORD T, T_Prodotti P, t_Ordini o "
            sql &= " WHERE c.idrub = r.idrub and c.idcorr = cr.idcorriere and c.Eliminato <> " & enSiNo.Si
            sql &= " And c.idcons = t.idcons and o.idord = t.idord and p.idprod = o.idprod"

            Dim ListaStatiD As String = enStatoOrdine.UscitoMagazzino & "," & _
               enStatoOrdine.InConsegna & "," & _
               enStatoOrdine.Consegnato & "," & _
               enStatoOrdine.PagatoAcconto & "," & _
               enStatoOrdine.PagatoInteramente

            sql &= " AND c.idcons IN (SELECT IDCONS FROM TR_CONSORD CO, T_ORDINI O WHERE CO.IDCONS = c.idcons and co.idord = o.idord and o.stato in (" & ListaStatiD & "))"

            sql &= " AND ("

            sql &= "(DAY(giorno) = " & GiornoEffConsegna.Day & " AND MONTH(giorno) = " & GiornoEffConsegna.Month & " and year(giorno) = " & GiornoEffConsegna.Year & ")"

            sql &= " or (DAY(o.dataeffconsegna) = " & GiornoEffConsegna.Day & " AND MONTH(o.dataeffconsegna) = " & GiornoEffConsegna.Month & " and year(o.dataeffconsegna) = " & GiornoEffConsegna.Year & ")"

            sql &= " )"

            sql &= " ORDER BY r.ragsoc"
            Dim myCommand As SqlCommand = _cn.CreateCommand()
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read
                Dim classe As New ConsegnaRicerca(CType(myReader, IDataRecord))
                'If Not myReader("IdCons") Is DBNull.Value Then classe.IdCons = myReader("IdCons")
                'If Not myReader("Giorno") Is DBNull.Value Then classe.Giorno = myReader("Giorno")
                'If Not myReader("IdRub") Is DBNull.Value Then classe.IdRub = myReader("IdRub")
                'If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
                'If Not myReader("MatPom") Is DBNull.Value Then classe.MatPom = myReader("MatPom")
                'If Not myReader("IdCorr") Is DBNull.Value Then classe.IdCorr = myReader("IdCorr")
                'If Not myReader("CodTrack") Is DBNull.Value Then classe.CodTrack = myReader("CodTrack")
                'If Not myReader("IdOperatore") Is DBNull.Value Then classe.IdOperatore = myReader("IdOperatore")
                'If Not myReader("IdStatoConsegna") Is DBNull.Value Then classe.IdStatoConsegna = myReader("IdStatoConsegna")
                'If Not myReader("NumColli") Is DBNull.Value Then classe.NumColli = myReader("NumColli")
                'If Not myReader("Peso") Is DBNull.Value Then classe.Peso = myReader("Peso")

                If Not myReader("RagSoc") Is DBNull.Value Then classe.RagSoc = myReader("RagSoc")
                If Not myReader("Descrizione") Is DBNull.Value Then classe.CorriereNome = myReader("Descrizione")

                If Not myReader("idord") Is DBNull.Value Then classe.IdOrd = myReader("idord")
                If Not myReader("ProdottoNome") Is DBNull.Value Then classe.ProdottoNome = myReader("ProdottoNome")
                If Not myReader("statoord") Is DBNull.Value Then classe.StatoOrdine = myReader("statoord")
                If Not myReader("Inserito") Is DBNull.Value Then classe.Inserito = myReader("Inserito")
                If Not myReader("DataEffConsegna") Is DBNull.Value Then classe.DataEffConsegna = myReader("DataEffConsegna")
                classe.Programmata = True
                Lst.Add(classe)
            End While

            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Lst

    End Function

    Public Function Lista(ByVal MatPom As Integer, _
                          Optional ByVal IdCorr As Integer = 0, _
                          Optional ByVal Giorno As Date = Nothing, _
                          Optional ByVal IdRub As Integer = 0, _
                          Optional ByVal ListaStati As String = "", _
                          Optional ByVal IdZona As Integer = 0, _
                          Optional ByVal IdOperatore As Integer = 0, _
                          Optional ByVal Iniziale As String = "", _
                          Optional ByVal TestoLibero As String = "", _
                          Optional ByVal ListaCorrEsclusi As String = "", _
                          Optional ByVal IdCons As Integer = 0, _
                          Optional ByVal Operatore As Boolean = False,
                          Optional ByVal OrderBy As String = "",
                          Optional ByVal GiornoEffConsegna As Date = Nothing, _
                          Optional ByVal GiornoMaggioreDi As Date = Nothing, _
                          Optional ByVal ListaIdCorrieri As String = "") As List(Of ConsegnaRicerca)

        Dim Lst As New List(Of ConsegnaRicerca)

        Try

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT c.* ,R.RagSoc,Cr.Descrizione" & _
                ",t.idord,p.descrizione as ProdottoNome ,o.stato as statoord, t.inserito " & _
                ", o.dataeffconsegna " & _
                " from T_Cons C,T_Rubrica R, T_Corriere CR, TR_CONsORD T, T_Prodotti P, t_Ordini o "

            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " where c.idrub = r.idrub and c.idcorr = cr.idcorriere and c.Eliminato <> " & enSiNo.Si
            If Giorno <> Date.MinValue Then sql &= " and (day(giorno) = " & Giorno.Day & " and month(giorno) = " & Giorno.Month & " and year(giorno) = " & Giorno.Year & ")"

            If GiornoEffConsegna <> Date.MinValue Then sql &= " and (day(dataeffconsegna) = " & GiornoEffConsegna.Day & " and month(dataeffconsegna) = " & GiornoEffConsegna.Month & " and year(dataeffconsegna) = " & GiornoEffConsegna.Year & ")"

            If GiornoMaggioreDi <> Date.MinValue Then

                sql &= " and  datediff(d,giorno,getdate()) > 0 "

            End If

            If MatPom <> -1 Then sql &= " And MatPom = " & MatPom

            sql &= " And c.idcons = t.idcons and o.idord = t.idord and p.idprod = o.idprod"

            If IdCorr Then
                If IdCorr = enCorriere.TipografiaFormer Then
                    sql &= " AND c.idcorr in (" & enCorriere.TipografiaFormer & "," & enCorriere.TipografiaFormerFuoriRaccordo & ")"
                Else
                    sql &= " AND c.idcorr = " & IdCorr
                End If
            End If

            If ListaCorrEsclusi.Length Then
                sql &= " AND c.idcorr not in (" & ListaCorrEsclusi & ")"
            End If

            If ListaIdCorrieri.Length Then
                sql &= " AND c.idcorr IN (" & ListaIdCorrieri & ")"
            End If

            If IdRub Then
                sql &= " AND c.idrub = " & IdRub
            End If

            If IdOperatore Then
                sql &= " AND c.idoperatore = " & IdOperatore
            End If

            If IdZona Then
                sql &= " AND r.idzona = " & IdZona
            End If

            If ListaStati.Length Then
                sql &= " AND c.idcons IN (SELECT IDCONS FROM TR_CONSORD CO, T_ORDINI O WHERE CO.IDCONS = c.idcons and co.idord = o.idord and o.stato in (" & ListaStati & "))"
            End If

            If Iniziale.Length Then
                sql &= " and R.Ragsoc like '" & Iniziale & "%' "
            End If

            If TestoLibero.Trim.Length Then
                sql &= " and r.ragsoc " & ApLike(TestoLibero)
            End If

            If IdCons Then
                sql &= " AND c.idcons = " & IdCons
            End If

            If Operatore Then
                Dim lstStat As String = enStatoOrdine.Registrato & "," & _
                       enStatoOrdine.InSospeso & "," & _
                       enStatoOrdine.InCodaDiStampa & "," & _
                       enStatoOrdine.StampaInizio & "," & _
                       enStatoOrdine.StampaFine & "," & _
                       enStatoOrdine.FinituraCommessaInizio & "," & _
                       enStatoOrdine.FinituraCommessaFine & "," & _
                       enStatoOrdine.FinituraProdottoInizio & "," & _
                       enStatoOrdine.FinituraProdottoFine & "," & _
                       enStatoOrdine.Imballaggio & "," & _
                       enStatoOrdine.ImballaggioCorriere & "," & _
                       enStatoOrdine.ProntoRitiro

                sql &= " AND ((c.idcorr in (" & enCorriere.RitiroCliente & "," & enCorriere.TipografiaFormer & ") AND c.idcons IN (SELECT IDCONS FROM TR_CONSORD CO, T_ORDINI O " &
                    "WHERE CO.IDCONS = c.idcons AND co.idord = o.idord AND o.stato in (" & lstStat & "))" &
                    ") or (c.idcorr not in (" & enCorriere.RitiroCliente & "," & enCorriere.TipografiaFormer & ") AND c.idcons IN (SELECT IDCONS FROM TR_CONSORD CO, T_ORDINI O " &
                    "WHERE CO.IDCONS = c.idcons AND co.idord = o.idord AND o.stato =" & enStatoOrdine.ProntoRitiro & " )))"

            End If

            If OrderBy.Length Then
                sql &= " ORDER BY " & OrderBy
            Else
                sql &= " ORDER BY o.DataEffConsegna desc, r.ragsoc"
            End If
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read
                Dim classe As New ConsegnaRicerca(CType(myReader, IDataRecord))
                'If Not myReader("IdCons") Is DBNull.Value Then classe.IdCons = myReader("IdCons")
                'If Not myReader("Giorno") Is DBNull.Value Then classe.Giorno = myReader("Giorno")
                'If Not myReader("IdRub") Is DBNull.Value Then classe.IdRub = myReader("IdRub")
                'If Not myReader("Annotazioni") Is DBNull.Value Then classe.Annotazioni = myReader("Annotazioni")
                'If Not myReader("MatPom") Is DBNull.Value Then classe.MatPom = myReader("MatPom")
                'If Not myReader("IdCorr") Is DBNull.Value Then classe.IdCorr = myReader("IdCorr")
                'If Not myReader("CodTrack") Is DBNull.Value Then classe.CodTrack = myReader("CodTrack")
                'If Not myReader("IdOperatore") Is DBNull.Value Then classe.IdOperatore = myReader("IdOperatore")
                'If Not myReader("IdStatoConsegna") Is DBNull.Value Then classe.IdStatoConsegna = myReader("IdStatoConsegna")
                'If Not myReader("NumColli") Is DBNull.Value Then classe.NumColli = myReader("NumColli")
                'If Not myReader("Peso") Is DBNull.Value Then classe.Peso = myReader("Peso")

                If Not myReader("RagSoc") Is DBNull.Value Then classe.RagSoc = myReader("RagSoc")
                If Not myReader("Descrizione") Is DBNull.Value Then classe.CorriereNome = myReader("Descrizione")

                If Not myReader("idord") Is DBNull.Value Then classe.IdOrd = myReader("idord")
                If Not myReader("ProdottoNome") Is DBNull.Value Then classe.ProdottoNome = myReader("ProdottoNome")
                If Not myReader("statoord") Is DBNull.Value Then classe.StatoOrdine = myReader("statoord")
                If Not myReader("Inserito") Is DBNull.Value Then classe.Inserito = myReader("Inserito")
                If Not myReader("DataEffConsegna") Is DBNull.Value Then classe.DataEffConsegna = myReader("DataEffConsegna")
                classe.Programmata = True
                Lst.Add(classe)
            End While

            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Lst

    End Function

    Public Function ListaPreviste(ByVal Giorno As Date, _
                               ByVal PeriodoPrevConsegna As Integer, _
                               ByVal IdRub As Integer, _
                               ByVal IdCom As Integer, _
                               ByVal IdCorr As Integer, _
                               ByVal ListaStati As String) As List(Of ConsegnaRicerca)
        Dim Lst As New List(Of ConsegnaRicerca)
        Try
            Dim sql As String = ""
            sql = "SELECT dataprevconsegna,o.IdOrd,"
            sql &= "o.idrub,o.stato,"
            sql &= "r.RagSoc,periodoprevconsegna as matpom,"
            sql &= "p.Codice as Prodotto,c.idcorr,"
            sql &= "C.Descrizione as Corriere"

            sql &= " from T_Ordini O, T_Prodotti P, T_Rubrica R , T_Corriere C "
            sql &= " where o.idrub = R.idrub and o.idprod = p.idprod and C.IdCorriere = O.IdCorriere"

            sql &= " and (day(dataprevconsegna) = " & Giorno.Day & " and month(dataprevconsegna) = " & Giorno.Month & " and year(dataprevconsegna) = " & Giorno.Year & ")" ' & ApCancelletto(Giorno.ToShortDateString)
            sql &= " and periodoprevconsegna = " & PeriodoPrevConsegna

            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " and o.stato <> " & enStatoOrdine.Rifiutato
            sql &= " and o.stato in (" & ListaStati & ")"

            If IdCorr Then
                sql &= " and o.IdCorriere = " & IdCorr
            End If
            If IdRub Then
                sql &= " and o.idrub = " & IdRub
            End If

            If IdCom Then
                sql &= " and o.idcom = " & IdCom
            End If
            sql &= " order by Oraconsegna asc,ragsoc asc"

            Dim myCommand As SqlCommand = _Cn.CreateCommand()

            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read
                Dim classe As New ConsegnaRicerca
                classe.IdCons = 0
                If Not myReader("idord") Is DBNull.Value Then classe.IdOrd = myReader("idord")
                If Not myReader("dataprevconsegna") Is DBNull.Value Then classe.Giorno = myReader("dataprevconsegna")
                If Not myReader("IdRub") Is DBNull.Value Then classe.IdRub = myReader("IdRub")
                If Not myReader("MatPom") Is DBNull.Value Then classe.MatPom = myReader("MatPom")
                If Not myReader("IdCorr") Is DBNull.Value Then classe.IdCorr = myReader("IdCorr")
                If Not myReader("RagSoc") Is DBNull.Value Then classe.RagSoc = myReader("RagSoc")
                If Not myReader("Corriere") Is DBNull.Value Then classe.CorriereNome = myReader("Corriere")
                Lst.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Lst
    End Function

    Public Overrides Function Find(ParamArray Parameter() As LUNA.LunaSearchParameter) As ConsegnaRicerca

    End Function

End Class