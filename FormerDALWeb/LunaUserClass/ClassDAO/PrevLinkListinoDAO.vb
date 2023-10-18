#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.8.1.27156 
'Author: Diego Lunadei
'Date: 03/02/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                

''' <summary>
'''DAO Class for table Tr_prevlistino
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class PrevLinkListinoDAO
	Inherits _PrevLinkListinoDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

End Class