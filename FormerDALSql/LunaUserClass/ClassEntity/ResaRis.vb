#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.7 
'Author: Diego Lunadei
'Date: 25/06/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table Tr_resaris
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ResaRis
	Inherits _ResaRis
    Implements IResaRis

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdResaRis() as integer
    Get
	    Return MyBase.IdResaRis
    End Get
    Set (byval value as integer)
        MyBase.IdResaRis= value
    End Set
End property 


Public Overrides Property IdFormMacchina() as integer
    Get
	    Return MyBase.IdFormMacchina
    End Get
    Set (byval value as integer)
        MyBase.IdFormMacchina= value
    End Set
End property 


Public Overrides Property IdFormRisorsa() as integer
    Get
	    Return MyBase.IdFormRisorsa
    End Get
    Set (byval value as integer)
        MyBase.IdFormRisorsa= value
    End Set
End property 


Public Overrides Property Resa() as integer
    Get
	    Return MyBase.Resa
    End Get
    Set (byval value as integer)
        MyBase.Resa= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IResaRis.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IResaRis.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IResaRis.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Tr_resaris
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IResaRis
        Inherits _IResaRis

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface