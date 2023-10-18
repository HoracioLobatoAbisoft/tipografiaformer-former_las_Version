#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.7.9 
'Author: Diego Lunadei
'Date: 31/07/2019 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Richiestepreventivo
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class RichiestePreventivoDAO
	Inherits _RichiestePreventivoDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class