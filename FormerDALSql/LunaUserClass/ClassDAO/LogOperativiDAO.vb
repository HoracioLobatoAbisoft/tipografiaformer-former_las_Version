#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 12/06/2020 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Logoperativi
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class LogOperativiDAO
	Inherits _LogOperativiDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class