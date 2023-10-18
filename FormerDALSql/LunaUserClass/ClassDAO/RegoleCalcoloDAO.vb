#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.11.8 
'Author: Diego Lunadei
'Date: 06/12/2017 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table T_regolecalcolo
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class RegoleCalcoloDAO
	Inherits _RegoleCalcoloDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class