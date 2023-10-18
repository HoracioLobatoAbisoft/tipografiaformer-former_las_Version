#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.4.1053 
'Author: Diego Lunadei
'Date: 21/05/2015 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table Newsletter
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class NewsletterDAO
	Inherits _NewsletterDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class