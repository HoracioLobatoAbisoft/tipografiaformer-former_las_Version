#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.22086 
'Author: Diego Lunadei
'Date: 04/03/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                

''' <summary>
'''DAO Class for table Tipoattivita
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class TipoAttivitaDAO
	Inherits _TipoAttivitaDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class