#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.11.2 
'Author: Diego Lunadei
'Date: 24/12/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table Tr_cattipofustella
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class TipoFustellaSuCatW
	Inherits _TipoFustellaSuCatW
    Implements ITipoFustellaSuCatW

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdCatTipo() as integer
    Get
	    Return MyBase.IdCatTipo
    End Get
    Set (byval value as integer)
        MyBase.IdCatTipo= value
    End Set
End property 


Public Overrides Property IdCat() as integer
    Get
	    Return MyBase.IdCat
    End Get
    Set (byval value as integer)
        MyBase.IdCat= value
    End Set
End property 


Public Overrides Property IdTipo() as integer
    Get
	    Return MyBase.IdTipo
    End Get
    Set (byval value as integer)
        MyBase.IdTipo= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ITipoFustellaSuCatW.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ITipoFustellaSuCatW.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ITipoFustellaSuCatW.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Tr_cattipofustella
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITipoFustellaSuCatW
        Inherits _ITipoFustellaSuCatW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface