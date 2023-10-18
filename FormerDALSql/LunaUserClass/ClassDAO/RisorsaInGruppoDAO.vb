#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.3.1 
'Author: Diego Lunadei
'Date: 12/03/2019 
#End Region


Imports System.Data.Common
Imports System.Data.SqlClient

''' <summary>
'''DAO Class for table Tr_risorsagruppo
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class RisorsaInGruppoDAO
    Inherits _RisorsaInGruppoDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub DeleteForRisorsa(IdRis As Integer)
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_rismacchina SET DELETED=True "
                Dim Sql As String = "DELETE FROM Tr_RisorsaGruppo"
                Sql &= " Where IdRisorsa = " & IdRis

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class