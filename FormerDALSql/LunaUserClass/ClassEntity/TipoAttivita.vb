#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.20769 
'Author: Diego Lunadei
'Date: 04/03/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table Tipoattivita
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class TipoAttivita
	Inherits _TipoAttivita
    Implements ITipoAttivita

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdTipoAttivita() as integer
    Get
	    Return MyBase.IdTipoAttivita
    End Get
    Set (byval value as integer)
        MyBase.IdTipoAttivita= value
    End Set
End property 


Public Overrides Property Descrizione() as string
    Get
	    Return MyBase.Descrizione
    End Get
    Set (byval value as string)
        MyBase.Descrizione= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ITipoAttivita.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ITipoAttivita.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ITipoAttivita.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Tipoattivita
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITipoAttivita
        Inherits _ITipoAttivita

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface