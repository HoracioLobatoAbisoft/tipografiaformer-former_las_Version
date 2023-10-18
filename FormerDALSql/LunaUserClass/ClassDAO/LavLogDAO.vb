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

''' <summary>
'''DAO Class for table T_lavlog
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class LavLogDAO
    Inherits _LavLogDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function GetReportGiornaliero(GiornoRif As Date) As IEnumerable(Of LavLog)

        Dim ris As List(Of LavLog) = Nothing

        Dim Sql As String = String.Empty

        Sql = "SELECT * FROM t_lavlog "

        Sql &= "WHERE (NOT dataorainizio IS NULL OR NOT dataorafine IS NULL) "

        Sql &= "AND idut <>0 "

        Sql &= "AND day(dataorainizio) = " & GiornoRif.Day & " AND month(dataorainizio) = " & GiornoRif.Month & " AND year(dataorainizio) = " & GiornoRif.Year

        Sql &= "ORDER BY idut,dataorainizio"

        ris = GetData(Sql)

        Return ris

    End Function

    Public Function LavoriAncoraAperti(Optional IdCom As Integer = 0,
                                       Optional IdOrd As Integer = 0) As List(Of LavLog)

        Dim ris As New List(Of LavLog)

        Using mgr As New LavLogDAO

            Dim sql As String = "SELECT * FROM T_Lavlog WHERE "

            If IdCom Then
                sql &= " IdCom = " & IdCom
            ElseIf IdOrd Then
                sql &= " IdOrd = " & IdOrd
            End If

            sql &= " AND (DataOraInizio IS Null OR DataOraFine IS Null)"

            Dim l As List(Of LavLog) = mgr.GetBySQL(sql)

            For Each lav In l
                If lav.Lavorazione.Categoria.TipoCaratteristica = enSiNo.No Then
                    ris.Add(lav)
                End If
            Next

        End Using
        'ris.Sort(AddressOf Comparer)
        Return ris

    End Function

    Public Function ElencoLavoriAperti() As List(Of LavLog)
        Dim Ls As New List(Of LavLog)
        Try

            Dim sql As String = ""
            sql = "SELECT IdLavLog," &
                "IdCom," &
                "IdOrd," &
                "Idlav," &
                "Descrizione," &
                "Premio," &
                "Tempo," &
                "Ordine," &
                "IdUt," &
                "DataOraInizio," &
                "DataOraFine," &
                "Macchinario, Custom "
            sql &= " from T_lavlog"

            sql &= " WHERE NOT DATAORAINIZIO IS NULL AND DATAORAFINE IS NULL"

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls


    End Function

    Public Function ElencoFinituraCommessa() As List(Of LavLog)

        Dim Ls As New List(Of LavLog)
        Try

            Dim sql As String = ""
            sql = "SELECT * "
            sql &= " FROM T_lavlog"
            sql &= " WHERE idcom IN (SELECT DISTINCT c.idcom FROM t_commesse c INNER JOIN t_commessecrono cc ON c.idcom = cc.idcom"
            sql &= " WHERE (c.stato = " & enStatoCommessa.Stampa & " AND cc.datacronofine IS NOT NULL) "
            sql &= " OR (c.stato = " & enStatoCommessa.FinituraSuCommessa & " AND cc.datacronofine IS NULL)) "
            '  sql &= " order by idcom, ordine"

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            Dim OldIdCom As Integer = 0
            While myReader.Read
                If myReader("DataOraFine") Is DBNull.Value Then
                    If myReader("Idcom") <> OldIdCom Then
                        OldIdCom = myReader("Idcom")
                        Dim classe As New LavLog(CType(myReader, IDataRecord))
                        'If Not myReader("IdLavLog") Is DBNull.Value Then classe.IdLavLog = myReader("IdLavLog")
                        'If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
                        'If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrd = myReader("IdOrd")
                        'If Not myReader("Descrizione") Is DBNull.Value Then classe.Descrizione = myReader("Descrizione")
                        'If Not myReader("Premio") Is DBNull.Value Then classe.Premio = myReader("Premio")
                        'If Not myReader("Tempo") Is DBNull.Value Then classe.Tempo = myReader("Tempo")
                        'If Not myReader("Ordine") Is DBNull.Value Then classe.Ordine = myReader("Ordine")
                        'If Not myReader("IdUt") Is DBNull.Value Then classe.IdUt = myReader("IdUt")
                        'If Not myReader("DataOraInizio") Is DBNull.Value Then classe.DataOraInizio = myReader("DataOraInizio")
                        'If Not myReader("DataOraFine") Is DBNull.Value Then classe.DataOraFine = myReader("DataOraFine")
                        'If Not myReader("Macchinario") Is DBNull.Value Then classe.MacchinaStampaStr = myReader("Macchinario")
                        'classe.Commessa.Read(classe.IdCom)
                        Ls.Add(classe)
                    End If
                End If


            End While

            'qui devo riordinare la lista stavolta per priorita e idcom crescente
            'Ls.Sort(AddressOf ComparerCommessa)
            SortCommesse(Ls)

            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls



    End Function

    Private Function ComparerCommessa(ByVal x As LavLog, ByVal y As LavLog) As Integer
        Dim result As Integer = y.PrioritaStr.CompareTo(x.PrioritaStr)
        If result = 0 Then
            result = x.IdCom.CompareTo(y.IdCom)
        End If
        Return result
    End Function

    Public Function ElencoFinituraOrdine() As List(Of LavLog)

        Dim Ls As New List(Of LavLog)
        Try

            Dim sql As String = ""
            sql = "SELECT * "
            sql &= " FROM T_lavlog"
            sql &= " WHERE idord IN (SELECT distinct o.idord FROM t_ordini o INNER JOIN t_ordinicrono oc ON o.idord = oc.idord"
            sql &= " WHERE (o.stato = " & enStatoOrdine.FinituraCommessaFine & ")" '& " and oc.datacronofine is null) "
            sql &= " OR (o.stato = " & enStatoOrdine.FinituraProdottoInizio & "))" ' and cc.datacronofine is null)) "

            'sql &= " order by idord, ordine"

            'sql = "SELECT l.idord as [Numero Ordine],first(o.idcom) as [Commessa],first(C.RagSoc) as Cliente, 'Finitura su Prodotti' as Stato," & _
            '    " first(l.Descrizione) as Lavorazione,first(l.ordine) as Ordine "
            'sql &= "from T_Ordini O, T_CommesseCrono CC , T_LavLog L, T_Rubrica C "
            'sql &= " Where o.idcom=cc.idcom "
            'sql &= " and l.idord = o.idord "
            'sql &= " and c.idrub = o.idrub "
            'sql &= " and cc.idstato in( " & enStatoCommessa.Stampa & "," & enStatoCommessa.FinituraSuCommessa & ")"
            'sql &= " and l.dataorafine is null and  not cc.datacronofine is null"
            'sql &= " and cc.idcom not in (SELECT IDCOM FROM T_LAVLOG WHERE dataorafine is null)"
            'sql &= "  group by l.idord order by first(l.ordine)"

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            Dim OldIdOrd As Integer = 0
            While myReader.Read
                If myReader("DataOraFine") Is DBNull.Value Then
                    If myReader("Idord") <> OldIdOrd Then
                        OldIdOrd = myReader("IdOrd")
                        Dim classe As New LavLog(CType(myReader, IDataRecord))

                        classe.IdOrd = OldIdOrd
                        classe.IdCom = classe.OrdineRiferimento.IdCom
                        'If Not myReader("IdLavLog") Is DBNull.Value Then classe.IdLavLog = myReader("IdLavLog")
                        ''If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
                        'If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrd = myReader("IdOrd")
                        'If Not myReader("Descrizione") Is DBNull.Value Then classe.Descrizione = myReader("Descrizione")
                        'If Not myReader("Premio") Is DBNull.Value Then classe.Premio = myReader("Premio")
                        'If Not myReader("Tempo") Is DBNull.Value Then classe.Tempo = myReader("Tempo")
                        'If Not myReader("Ordine") Is DBNull.Value Then classe.Ordine = myReader("Ordine")
                        'If Not myReader("IdUt") Is DBNull.Value Then classe.IdUt = myReader("IdUt")
                        'If Not myReader("DataOraInizio") Is DBNull.Value Then classe.DataOraInizio = myReader("DataOraInizio")
                        'If Not myReader("DataOraFine") Is DBNull.Value Then classe.DataOraFine = myReader("DataOraFine")
                        'If Not myReader("Macchinario") Is DBNull.Value Then classe.Macchinario = myReader("Macchinario")
                        'classe.Commessa.Read(classe.IdCom)
                        'COMMENTATO PERCHE RESTAVANO APPESI I LAVORI
                        'If classe.Lavorazione.SuProdotto = True Then
                        Ls.Add(classe)
                        'End If
                    End If
                End If

            End While
            SortOrdini(Ls)
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls

    End Function

    Private Sub SortOrdini(ByRef lst As List(Of LavLog))

        lst.Sort(AddressOf ComparerOrdine)

    End Sub

    Public Sub DeleteByIdOrd(IdOrd As Integer)
        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE T_lavori SET DELETED=True "
            Dim Sql As String = "DELETE FROM t_lavlog"
            Sql &= " WHERE Idord = " & IdOrd

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Private Sub SortCommesse(ByRef lst As List(Of LavLog))

        lst.Sort(AddressOf Comparer)

    End Sub

    Private Function ComparerOrdine(ByVal x As LavLog, ByVal y As LavLog) As Integer
        Dim result As Integer = x.OrdineRiferimento.ConsegnaAssociata.Giorno.CompareTo(y.OrdineRiferimento.ConsegnaAssociata.Giorno)
        If result = 0 Then result = y.OrdinamentoOperatoreTipoConsegna.CompareTo(x.OrdinamentoOperatoreTipoConsegna)
        If result = 0 Then result = x.IdOrd.CompareTo(y.IdOrd)
        If result = 0 Then result = x.Ordine.CompareTo(y.Ordine)
        Return result
    End Function

    Private Function Comparer(ByVal x As LavLog, ByVal y As LavLog) As Integer
        Dim result As Integer = y.CommessaRiferimento.Priorita.CompareTo(x.CommessaRiferimento.Priorita)
        If result = 0 Then result = x.CommessaRiferimento.DataMinoreConsegna.CompareTo(y.CommessaRiferimento.DataMinoreConsegna)
        If result = 0 Then result = y.CommessaRiferimento.HaAlmenoUnOrdineFast.CompareTo(x.CommessaRiferimento.HaAlmenoUnOrdineFast)
        If result = 0 Then result = x.IdCom.CompareTo(y.IdCom)
        Return result
    End Function

    Public Sub DeleteByIdLav(IdLav As Integer, IdOrd As Integer)
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_lavori SET DELETED=True "
                Dim Sql As String = "DELETE FROM T_LavLog"
                Sql &= " WHERE Idord = " & IdOrd & " AND IdLav = " & IdLav

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Sub DeleteByIdLavLogList(IdLavLogList As String,
                                    IdOrd As Integer)
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_lavori SET DELETED=True "
                Dim Sql As String = "DELETE FROM T_LavLog"
                Sql &= " WHERE IdOrd = " & IdOrd

                If IdLavLogList.Length Then
                    Sql &= " AND IdLavLog NOT in (" & IdLavLogList & ") "
                End If

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Sub DeleteByIdCom(IdCom As Integer,
                             Optional SoloAccorpabile As Boolean = True)
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_lavori SET DELETED=True "
                Dim Sql As String = "DELETE FROM T_LavLog"
                Sql &= " WHERE IdCom = " & IdCom

                If SoloAccorpabile Then Sql &= " AND Idlav IN (SELECT Idlavoro FROM T_Lavori WHERE Accorpabile = " & enSiNo.Si & ")"

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class