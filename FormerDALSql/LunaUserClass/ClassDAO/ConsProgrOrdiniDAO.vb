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


''' <summary>
'''DAO Class for table Tr_consord
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ConsProgrOrdiniDAO
    Inherits _ConsProgrOrdiniDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function CercaCons(ByVal IdCli As Integer, ByVal Quando As Date, ByVal Idcons As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT Idcons from t_cons where idrub =  " & IdCli
            sql &= " AND IDCONS <>" & Idcons

            sql &= " AND ((daY(Giorno) = " & Quando.Day & " AND month(giorno) = " & Quando.Month & " AND YEAR(GIORNO) = " & Quando.Year & ") "
            sql &= " OR (daY(Giorno) = " & Quando.AddDays(1).Day & " AND month(giorno) = " & Quando.AddDays(1).Month & " AND YEAR(GIORNO) = " & Quando.AddDays(1).Year & ") "

            Dim Domani As Date = Now.Date.AddDays(1)

            If Quando.Date <> Domani Then
                sql &= " OR (daY(Giorno) = " & Quando.AddDays(-1).Day & " AND month(giorno) = " & Quando.AddDays(-1).Month & " AND YEAR(GIORNO) = " & Quando.AddDays(-1).Year & ") "
            End If

            sql &= ")"
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                Ris = myReader("Idcons")
            End If

            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

    Public Function IdConsByIdOrd(ByVal IdOrd As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT Idcons from tr_consOrd where idord = " & IdOrd
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                Ris = myReader("Idcons")
            End If

            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

    Public Sub DeleteByIdCons(Id As Integer)
        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Tr_consord SET DELETED=True "
            Dim Sql As String = "DELETE FROM Tr_consord"
            Sql &= " Where IdCons = " & Id

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class