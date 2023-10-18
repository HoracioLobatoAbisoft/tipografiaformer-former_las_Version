#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 06/12/2019 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Extradata
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ExtraDataKeyDAO
	Inherits _ExtraDataKeyDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class