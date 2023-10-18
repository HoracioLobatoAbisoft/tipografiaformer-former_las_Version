#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 28/03/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient



''' <summary>
'''DAO Class for table Elencocomuni
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ElencoComuniDAO
	Inherits _ElencoComuniDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una Località"

End Class