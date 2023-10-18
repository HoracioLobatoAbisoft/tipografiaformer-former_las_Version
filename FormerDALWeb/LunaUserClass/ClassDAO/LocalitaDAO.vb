#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19869 
'Author: Diego Lunadei
'Date: 09/10/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                

''' <summary>
'''DAO Class for table Localita
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class LocalitaDAO
	Inherits _LocalitaDAO

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una Città"

End Class