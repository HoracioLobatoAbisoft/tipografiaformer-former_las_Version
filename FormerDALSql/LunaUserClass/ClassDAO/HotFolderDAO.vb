#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 05/05/2017 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table T_hotfolder
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class HotFolderDAO
	Inherits _HotFolderDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub ResetListiniBaseByIdHotFolder(Id As Integer)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_hotfolder SET DELETED=True "
                Dim Sql As String = "Update T_ListinoBase set IdHotFolderPostRefine = 0 where IdHotFolderPostRefine = " & Id

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class