#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 16/01/2017 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Tr_defaultformatoprev
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class DefaultFormatoProdottoDAO
	Inherits _DefaultFormatoProdottoDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class