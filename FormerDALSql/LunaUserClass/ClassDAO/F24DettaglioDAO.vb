#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 27/12/2019 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table F24dettaglio
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class F24DettaglioDAO
	Inherits _F24DettaglioDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Public Sub DeleteByIdF24(IdF24 As Integer)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.Connection = _Cn

				'******IMPORTANT: You can use this commented instruction to make a logical delete .
				'******Replace DELETED Field with your logic deleted field name.
				'Dim Sql As String = "UPDATE F24dettaglio SET DELETED=True "
				Dim Sql As String = "DELETE FROM F24dettaglio"
				Sql &= " WHERE IdF24 = " & IdF24
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
			End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class