#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.7 
'Author: Diego Lunadei
'Date: 22/07/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table Province
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Provincia
	Inherits _Provincia
    Implements IProvincia

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property ID() as integer
    Get
	    Return MyBase.ID
    End Get
    Set (byval value as integer)
        MyBase.ID= value
    End Set
End property 


Public Overrides Property Cod() as string
    Get
	    Return MyBase.Cod
    End Get
    Set (byval value as string)
        MyBase.Cod= value
    End Set
End property 


Public Overrides Property PROVINCIA() as string
    Get
	    Return MyBase.PROVINCIA
    End Get
    Set (byval value as string)
        MyBase.PROVINCIA= value
    End Set
End property 


Public Overrides Property IdRegione() as integer
    Get
	    Return MyBase.IdRegione
    End Get
    Set (byval value as integer)
        MyBase.IdRegione= value
    End Set
End property 


Public Overrides Property FLGVARIAZIONE() as integer
    Get
	    Return MyBase.FLGVARIAZIONE
    End Get
    Set (byval value as integer)
        MyBase.FLGVARIAZIONE= value
    End Set
End property 


Public Overrides Property DTVARIAZIONE() as string
    Get
	    Return MyBase.DTVARIAZIONE
    End Get
    Set (byval value as string)
        MyBase.DTVARIAZIONE= value
    End Set
End property 


Public Overrides Property ordine() as integer
    Get
	    Return MyBase.ordine
    End Get
    Set (byval value as integer)
        MyBase.ordine= value
    End Set
End property 


#End Region

#Region "Logic Field"

    Public ReadOnly Property Riassunto As String
        Get
            Return Cod & " - " & PROVINCIA
        End Get
    End Property

#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IProvincia.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IProvincia.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IProvincia.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Province
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IProvincia
        Inherits _IProvincia

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface