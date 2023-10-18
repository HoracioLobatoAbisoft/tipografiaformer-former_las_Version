#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.2.0.18 
'Author: Diego Lunadei
'Date: 12/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Imports System.Data.Common

''' <summary>
'''DAO Class for table Utenti
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class UtentiDAO
    Inherits _UtentiDAO

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    '''New() create an istance of this class and specify an OPENED DB connection
    ''' </summary>
    ''' <returns>
    '''
    ''' </returns>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Public Sub AggiornaLogin(IdUt As Integer,
                             LastLogin As Date,
                             LastIp As String)


        Using myCommand As DbCommand = _Cn.CreateCommand()
            Try
                Dim sql As String = String.Empty
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

                sql = "UPDATE Utenti SET LastIp = @LastIp, LastLogin = @LastLogin"
                sql &= " WHERE IdUt= " & IdUt


                Dim p As DbParameter = Nothing

                p = myCommand.CreateParameter
                p.ParameterName = "@LastIp"
                p.Value = LastIp
                myCommand.Parameters.Add(p)

                p = myCommand.CreateParameter
                p.ParameterName = "@LastLogin"
                p.DbType = DbType.DateTime
                If LastLogin <> Date.MinValue Then
                    p.Value = LastLogin
                Else
                    p.Value = DBNull.Value
                End If
                myCommand.Parameters.Add(p)


                myCommand.CommandType = CommandType.Text
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()

            Catch ex As Exception
                ManageError(ex)
            End Try
        End Using

    End Sub

    Public Function ElencoUtentiConOrdiniDaPagare(Optional AlertLevel As enAlertLevelOrdini = enAlertLevelOrdini.Normale,
                                                  Optional ggToCheck As Integer = 7) As List(Of Utente)

        Dim Ls As New List(Of Utente)
        Try

            Dim sql As String = ""
            sql = "select distinct u.* from utenti u inner join consegne c on u.IdUt = c.idut "
            sql &= "where ((c.IdStatoConsegna=" & CInt(enStatoConsegna.InAttesaDiPagamento) & " and c.AlertLevel = " & CInt(AlertLevel) & ") "
            sql &= " or (c.idstatoconsegna=" & CInt(enStatoConsegna.Inserito) & " and c.AlertLevel = " & CInt(AlertLevel)
            sql &= " and c.idconsegna not in(select idcons from ordini where idcons = c.idconsegna and stato>" & CInt(enStatoOrdine.InAttesaAllegati) & ")"
            sql &= " and c.idconsegna not in(select idconsegna from pagamentionline p where p.idconsegna = c.idconsegna))"
            sql &= ") and datediff(""d"",c.datainserimento,getdate())>" & ggToCheck

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls

    End Function

    Public Function Merge(IdUtDaTenere As Integer,
                     IdUtDaEliminare As Integer) As Integer

        Dim ris As Integer = 0


        Try
            Using myCommand As SqlCommand = _Cn.CreateCommand


                myCommand.CommandText = "UPDATE Consegne set IdUt = " & IdUtDaTenere & " WHERE IdUt = " & IdUtDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE CouponLog set IdUt = " & IdUtDaTenere & " WHERE IdUt = " & IdUtDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE Indirizzi set IdUt = " & IdUtDaTenere & " WHERE IdUt = " & IdUtDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE ListiniUtente set IdUt = " & IdUtDaTenere & " WHERE IdUt = " & IdUtDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE Ordini set IdUt = " & IdUtDaTenere & " WHERE IdUt = " & IdUtDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE PagamentiOnline set IdUt = " & IdUtDaTenere & " WHERE IdUt = " & IdUtDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE ParamListini set IdUt = " & IdUtDaTenere & " WHERE IdUt = " & IdUtDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE Review set IdUt = " & IdUtDaTenere & " WHERE IdUt = " & IdUtDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_Coupon set Riservato = " & IdUtDaTenere & " WHERE Riservato = " & IdUtDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "DELETE FROM Utenti WHERE IdUt = " & IdUtDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception

            ris = 1
        End Try


        Return ris

    End Function



End Class