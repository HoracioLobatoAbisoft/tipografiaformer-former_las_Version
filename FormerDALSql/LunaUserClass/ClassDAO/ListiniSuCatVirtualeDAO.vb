#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 23/02/2017 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Tr_catvlistini
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ListiniSuCatVirtualeDAO
	Inherits _ListiniSuCatVirtualeDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub DeleteByIdCat(IdCat As Integer)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_catvlistini SET DELETED=True "
                Dim Sql As String = "DELETE FROM Tr_catvlistini"
                Sql &= " WHERE IdCatVirtuale = " & IdCat

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Sub DeleteByIdListinoBase(IdListinoBase As Integer)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_catvlistini SET DELETED=True "
                Dim Sql As String = "DELETE FROM Tr_catvlistini"
                Sql &= " WHERE IdListinoBase = " & IdListinoBase

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Sub DeleteByIdCatIdListinoBase(IdCat As Integer, IdListinoBase As Integer)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_catvlistini SET DELETED=True "
                Dim Sql As String = "DELETE FROM Tr_catvlistini"
                Sql &= " WHERE IdCatVirtuale = " & IdCat
                Sql &= " AND IdListinoBase = " & IdListinoBase

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class