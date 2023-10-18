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
'''DAO Class for table Tr_catprodtipocom
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class CatProdTipoComDAO
    Inherits _CatProdTipoComDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub DeleteByIdCat(ByVal IdCat As Integer)

        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _cn

            Dim Sql As String = "DELETE FROM Tr_catprodtipocom"
            Sql &= " Where IdCatProd = " & IdCat
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.CommandText = Sql
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

End Class