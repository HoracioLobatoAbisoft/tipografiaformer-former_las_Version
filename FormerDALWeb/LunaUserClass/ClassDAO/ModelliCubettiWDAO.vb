#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.4.1053 
'Author: Diego Lunadei
'Date: 21/09/2015 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Modellicubetti
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ModelliCubettiWDAO
	Inherits _ModelliCubettiWDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class