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
'''Entity Class for table T_pantone
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ColorePantone
	Inherits _ColorePantone
    Implements IColorePantone

    Public Sub New()
        MyBase.New()
    End Sub

       Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Database Field"


Public Overrides Property IDPantone() as integer
    Get
	    Return MyBase.IDPantone
    End Get
    Set (byval value as integer)
        MyBase.IDPantone= value
    End Set
End property 


Public Overrides Property Codice() as string
    Get
	    Return MyBase.Codice
    End Get
    Set (byval value as string)
        MyBase.Codice= value
    End Set
End property 


Public Overrides Property HtmlCode() as string
    Get
	    Return MyBase.HtmlCode
    End Get
    Set (byval value as string)
        MyBase.HtmlCode= value
    End Set
End property 


Public Overrides Property R() as integer
    Get
	    Return MyBase.R
    End Get
    Set (byval value as integer)
        MyBase.R= value
    End Set
End property 


Public Overrides Property G() as integer
    Get
	    Return MyBase.G
    End Get
    Set (byval value as integer)
        MyBase.G= value
    End Set
End property 


Public Overrides Property B() as integer
    Get
	    Return MyBase.B
    End Get
    Set (byval value as integer)
        MyBase.B= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IColorePantone.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IColorePantone.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IColorePantone.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_pantone
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IColorePantone
        Inherits _IColorePantone

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface