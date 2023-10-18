#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.2.11 
'Author: Diego Lunadei
'Date: 13/05/2020 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table T_gruppilbconsigliati
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class GruppiLBConsigliatiWDAO
	Inherits _GruppiLBConsigliatiWDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class