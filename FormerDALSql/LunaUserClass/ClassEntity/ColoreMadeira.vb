#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.8.1.27156 
'Author: Diego Lunadei
'Date: 10/02/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table T_madeira
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ColoreMadeira
	Inherits _ColoreMadeira
    Implements IColoreMadeira

    Public Sub New()
        MyBase.New()
    End Sub

      Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Database Field"


Public Overrides Property IdMadeira() as integer
    Get
	    Return MyBase.IdMadeira
    End Get
    Set (byval value as integer)
        MyBase.IdMadeira= value
    End Set
End property 


Public Overrides Property CodiceMadeira() as string
    Get
	    Return MyBase.CodiceMadeira
    End Get
    Set (byval value as string)
        MyBase.CodiceMadeira= value
    End Set
End property 


Public Overrides Property IdPantone() as integer
    Get
	    Return MyBase.IdPantone
    End Get
    Set (byval value as integer)
        MyBase.IdPantone= value
    End Set
End property 


Public Overrides Property IdTavolozza() as integer
    Get
	    Return MyBase.IdTavolozza
    End Get
    Set (byval value as integer)
        MyBase.IdTavolozza= value
    End Set
End property 


Public Overrides Property CostoMillePunti() as Single
    Get
	    Return MyBase.CostoMillePunti
    End Get
    Set (byval value as Single)
        MyBase.CostoMillePunti= value
    End Set
End property 


Public Overrides Property Attivo() as integer
    Get
	    Return MyBase.Attivo
    End Get
    Set (byval value as integer)
        MyBase.Attivo= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IColoreMadeira.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IColoreMadeira.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IColoreMadeira.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_madeira
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IColoreMadeira
        Inherits _IColoreMadeira

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface