#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.7 
'Author: Diego Lunadei
'Date: 06/10/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common


''' <summary>
'''DAO Class for table T_tmlb
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ListinoBaseSuTemplateDAO
    Inherits _ListinoBaseSuTemplateDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub DeleteByIdTMOff(Id As Integer)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_tmlb SET DELETED=True "
                Dim Sql As String = "DELETE FROM T_tmlb"
                Sql &= " Where idTmOff = " & Id

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Sub InsertByIdTMOff(IdNew As Integer, IdFrom As Integer)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_tmlb SET DELETED=True "
                Dim Sql As String = "INSERT INTO T_tmlb(IdTmOff,IdListinoBase,Qta,Fogli) Select " & IdNew & ",IdListinoBase,Qta,Fogli from  T_tmlb where idTmOff = " & IdFrom

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class