#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.51 
'Author: Diego Lunadei
'Date: 05/01/2018 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Daemonlog
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class DaemonLogDAO
	Inherits _DaemonLogDAO

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class