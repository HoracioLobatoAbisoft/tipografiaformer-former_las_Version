#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.11.2 
'Author: Diego Lunadei
'Date: 20/11/2017 
#End Region


Imports System.Data.Common
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table T_functionlock
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class FunctionLockDAO
    Inherits _FunctionLockDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub DeleteByIdUt(IdUt As Integer,
                            Optional IdOrd As Integer = 0,
                            Optional IdFunction As Integer = 0)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_functionlock SET DELETED=True "
                Dim Sql As String = "DELETE FROM T_functionlock"
                Sql &= " WHERE IdUt = " & IdUt
                If IdOrd Then Sql &= " AND IdOrd = " & IdOrd
                If IdFunction <> enFunctionLock.NonSpecificata Then Sql &= " AND IdFunction = " & IdFunction

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class