#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.5.18.15665 
'Author: Diego Lunadei
'Date: 29/10/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient


''' <summary>
'''DAO Class for table T_indirizzi
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class IndirizziDAO
    Inherits _IndirizziDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Public Function RendiPredefinito(ByVal IdRub As Integer, Optional idIndirizzoPred As Integer = 0) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Indirizzi SET DELETED=True "

                Dim sql As String

                sql = "UPDATE T_Indirizzi SET "
                sql &= "Predefinito = 0"
                sql &= " WHERE IdRubrica = " & IdRub

                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()

                If idIndirizzoPred Then
                    sql = "UPDATE T_Indirizzi SET Predefinito = 1 "
                    sql &= " WHERE Idindirizzo = " & idIndirizzoPred
                    myCommand.CommandText = sql
                    myCommand.ExecuteNonQuery()
                End If

            End Using
        Catch ex As Exception
            ManageError(ex)
            Ris = 1
        End Try
        Return Ris
    End Function

    Public Function ResetPredefinito(ByVal IdRub As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Indirizzi SET DELETED=True "

                Dim sql As String

                sql = "UPDATE T_Indirizzi SET "
                sql &= "Predefinito = 0"
                sql &= " WHERE IdRubrica = " & IdRub

                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction

                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
            Ris = 1
        End Try
        Return Ris
    End Function

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class