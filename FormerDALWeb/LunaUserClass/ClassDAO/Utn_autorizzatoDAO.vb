#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.5.25 
'Author: Diego Lunadei
'Date: 26/10/2023 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Utn_autorizzato
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class Utn_autorizzatoDAO
	Inherits _Utn_autorizzatoDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class