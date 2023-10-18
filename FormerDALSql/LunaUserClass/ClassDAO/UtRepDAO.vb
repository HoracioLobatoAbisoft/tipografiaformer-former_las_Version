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
'''DAO Class for table Tr_utrep
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class UtRepDAO
    Inherits _UtRepDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function DeleteByIdOper(IdOper As Integer) As Integer
        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Tr_utmac SET DELETED=True "
            Dim Sql As String = "DELETE FROM Tr_utRep"
            Sql &= " Where IdUt = " & IdOper

            UpdateCommand.CommandText = Sql
            If Not Luna.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = Luna.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Function
End Class