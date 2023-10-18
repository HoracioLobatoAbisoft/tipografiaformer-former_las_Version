#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.11.4 
'Author: Diego Lunadei
'Date: 24/11/2017 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Tr_formatomacchinario
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class FormatiSuMacchinariDAO
	Inherits _FormatiSuMacchinariDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub DeleteByIdFormato(IdFormato As Integer)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_formatomacchinario SET DELETED=True "
                Dim Sql As String = "DELETE FROM Tr_formatomacchinario"
                Sql &= " WHERE IdFormato = " & IdFormato

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class