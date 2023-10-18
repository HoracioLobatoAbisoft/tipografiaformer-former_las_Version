#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.8.1.27156 
'Author: Diego Lunadei
'Date: 03/02/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient


''' <summary>
'''DAO Class for table Tr_prevlistino
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class PrevLinkListinoDAO
	Inherits _PrevLinkListinoDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub DeleteAllLbProduzione()
        Try

            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_prevlistino SET DELETED=True "
                Dim Sql As String = "delete from Tr_prevlistino"
                Sql &= " Where IDLISTINOBASE IN (SELECT DISTINCT IDLISTINOBASE FROM T_LISTINOBASE WHERE IDLISTINOBASESOURCE<>0)"

                UpdateCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                UpdateCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Sub DeleteByIdListinoBase(IdListinoBase As Integer)
        Try

            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_prevlistino SET DELETED=True "
                Dim Sql As String = "delete from Tr_prevlistino"
                Sql &= " Where IDLISTINOBASE = " & IdListinoBase

                UpdateCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                UpdateCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub


    Public Sub DeleteLink(IdListinoBase As Integer, IdPrev As Integer)
        Try

            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_prevlistino SET DELETED=True "
                Dim Sql As String = "delete from Tr_prevlistino"
                Sql &= " Where IdPreventivazione = " & IdPrev & " and IDLISTINOBASE = " & IdListinoBase

                UpdateCommand.CommandText = Sql
                If Not Luna.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = Luna.LunaContext.TransactionBox.Transaction
                UpdateCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub


End Class