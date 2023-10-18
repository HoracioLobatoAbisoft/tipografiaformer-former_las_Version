#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.21984 
'Author: Diego Lunadei
'Date: 25/11/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table Consegne
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ConsegneDAO
    Inherits _ConsegneDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub ResetConsegnaIniziale(IdOrd As Integer)

        'resetta la consegna iniziale di un ordine e la cancella se resta vuota
        Using myCommand As SqlCommand = New SqlCommand()
            myCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Indirizzi SET DELETED=True "
            Dim Sql As String = "Update Ordini set IdCons = 0 where IdOrdineInt = " & IdOrd & " and idConsegnaInt = 0 "

            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.ExecuteNonQuery()

        End Using

    End Sub

    Public Sub ResetOrdiniByIdCons(IdConsegna As Integer)

        Using myCommand As SqlCommand = New SqlCommand()
            myCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Indirizzi SET DELETED=True "
            Dim Sql As String = "Update Ordini set IdCons = 0 where IdCons = " & IdConsegna

            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.ExecuteNonQuery()

        End Using

    End Sub

    Public Function GetIdConsFromIdInt(IdConsegnaInt As Integer) As Integer

        Dim ris As Integer = 0

        Try
            Dim myCommand As Data.Common.DbCommand = _Cn.CreateCommand()
            Dim sql As String = "select IdConsegna from Consegne where IdConsegnaInt=" & IdConsegnaInt

            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            myReader.Read()
            If myReader.HasRows Then
                ris = myReader("IdConsegna")
            End If

            myReader.Close()
            myCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try

        Return ris

    End Function

    Public Sub LegaOrdiniAConsegna(IdConsegna As Integer, ListaIdOrdini As String)

        Using myCommand As SqlCommand = New SqlCommand()
            myCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Indirizzi SET DELETED=True "
            Dim Sql As String = "Update Ordini set IdCons = " & IdConsegna & " where IdOrdineInt IN (" & ListaIdOrdini & ")"

            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.ExecuteNonQuery()

        End Using

    End Sub

    Public Sub EliminaConsegnaByIDInt(IdConsInt As Integer)

        'elimina una consegna dal sito passando per l'id interno della consegna

        Dim lst As List(Of Consegna) = FindAll(New LUNA.LunaSearchParameter("IdConsegnaInt", IdConsInt))

        If lst.Count Then

            Dim ConsegnaLavorata As Consegna = lst(0)

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Indirizzi SET DELETED=True "
                Dim Sql As String = "Update Ordini set IdCons = 0 where IdCons = (SELECT IdConsegna FROM Consegne WHERE IdConsegnaInt= " & IdConsInt & ")"

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                Sql = "Delete from Consegne where IdConsegnaInt = " & IdConsInt

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using

        End If

    End Sub

    Public Function CleanFromOnline() As Integer
        Dim Ris As Integer = 0
        Try
            Using myCommand As SqlCommand = _Cn.CreateCommand()

                Dim sql As String = "delete from Ordini where idcons in (select idconsegna from consegne where idStatoConsegna = " & CInt(enStatoConsegna.Pagato) & " and datediff(d,giorno,getdate())>180)"
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                sql = "delete from pagamentiOnline where idconsegna in (select idconsegna from consegne where idStatoConsegna = " & CInt(enStatoConsegna.Pagato) & " and datediff(d,giorno,getdate())>180)"
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                sql = "delete from consegne where idStatoConsegna = " & CInt(enStatoConsegna.Pagato) & " and datediff(d,giorno,getdate())>180"
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                'CONSEGNE ELIMINATE
                sql = "delete from ordini where idcons in (select distinct idconsegna from consegne where idstatoconsegna = " & enStatoConsegna.Eliminata & ")"
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                sql = "delete from consegne where idstatoconsegna = " & enStatoConsegna.Eliminata
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()
                'FINE

                'ORDINI ELIMINATI O RIFIUTATI E RELATIVE CONSEGNE
                sql = "delete from consegne where idconsegna in (select distinct idcons from ordini where stato IN (" & enStatoOrdine.Eliminato & "," & enStatoOrdine.Rifiutato & "))"
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                sql = "delete from ordini where stato IN (" & enStatoOrdine.Eliminato & "," & enStatoOrdine.Rifiutato & ")"
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()
                'FINE

                sql = "DELETE FROM Consegne WHERE idconsegna NOT IN (SELECT DISTINCT IdCons from ordini)"
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

    Public Sub SetAlertLevelOrdiniDaPagare(IdUt As Integer,
                                           AlertLevelFrom As enAlertLevelOrdini,
                                           AlertLevelTo As enAlertLevelOrdini,
                                           Optional ggToCheck As Integer = 7)

        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn

                Dim sql As String = ""
                sql = "Update c set c.AlertLevel = " & CInt(AlertLevelTo) & " from consegne c where c.idut=" & IdUt & " and ((c.IdStatoConsegna=" & CInt(enStatoConsegna.InAttesaDiPagamento)
                sql &= " and c.AlertLevel = " & CInt(AlertLevelFrom) & ") or (c.IdStatoConsegna=" & CInt(enStatoConsegna.InLavorazione) & " and c.AlertLevel= " & CInt(AlertLevelFrom)
                sql &= " and c.idconsegna not in(select idcons from ordini where idcons = c.idconsegna and stato>" & CInt(enStatoOrdine.InAttesaAllegati) & ")"
                sql &= " and c.idconsegna not in(select idconsegna from pagamentionline p where p.idconsegna = c.idconsegna))"
                sql &= ") and datediff(""d"",c.datainserimento,getdate())>" & ggToCheck

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Public Sub DeleteOrdiniDaPagare(IdUt As Integer, Optional ggToCheck As Integer = 15)

        Try
            Dim L As List(Of Consegna)

            Dim sql As String = ""
            sql = "Select * from consegne c where c.idut=" & IdUt & " and ((c.IdStatoConsegna=" & CInt(enStatoConsegna.InAttesaDiPagamento)
            sql &= " and c.AlertLevel = " & CInt(enAlertLevelOrdini.InviataEmailAvviso) & ") or (c.IdStatoConsegna=" & CInt(enStatoConsegna.InLavorazione) & " and c.AlertLevel= " & CInt(enAlertLevelOrdini.InviataEmailAvviso)
            sql &= " and c.idconsegna not in(select idcons from ordini where idcons = c.idconsegna and stato > " & CInt(enStatoOrdine.InAttesaAllegati) & ")"
            sql &= " and idconsegna not in(select idconsegna from pagamentionline p where p.idconsegna = c.idconsegna))"
            sql &= ") and datediff(""d"",c.datainserimento,getdate())>" & ggToCheck

            L = GetData(sql)

            For Each SingCons In L
                If SingCons.Modificabile Then
                    SingCons.IdStatoConsegna = enStatoConsegna.Eliminata
                    SingCons.AlertLevel = enAlertLevelOrdini.EliminatoDopoAlert
                    SingCons.Save()
                    For Each Lav As OrdineWeb In SingCons.ListaOrdini
                        Lav.Stato = enStatoOrdine.Eliminato
                        Lav.StatoWeb = enStato.NonAttivo
                        Lav.Save()
                    Next
                End If
            Next

        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class