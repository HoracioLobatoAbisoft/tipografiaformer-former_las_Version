#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 26/02/2019 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table T_carichimagazzino
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class CarichiDiMagazzinoDAO
	Inherits _CarichiDiMagazzinoDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class