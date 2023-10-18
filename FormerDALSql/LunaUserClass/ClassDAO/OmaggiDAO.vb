#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.11.31 
'Author: Diego Lunadei
'Date: 11/04/2016 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table T_omaggi
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class OmaggiDAO
	Inherits _OmaggiDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class