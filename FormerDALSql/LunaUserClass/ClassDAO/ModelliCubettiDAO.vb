#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.21984 
'Author: Diego Lunadei
'Date: 29/11/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient


''' <summary>
'''DAO Class for table Modellicubetti
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ModelliCubettiDAO
	Inherits _ModelliCubettiDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare un modello di cubetto"

End Class