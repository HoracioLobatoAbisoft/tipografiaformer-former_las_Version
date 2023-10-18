#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 20/02/2020 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table T_decodificavocicosto
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class DecodificaVociCostoDAO
	Inherits _DecodificaVociCostoDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class