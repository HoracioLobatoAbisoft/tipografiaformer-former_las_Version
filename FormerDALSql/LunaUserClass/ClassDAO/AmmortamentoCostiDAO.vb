#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 19/12/2019 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Ammortamentocosti
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class AmmortamentoCostiDAO
	Inherits _AmmortamentoCostiDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class