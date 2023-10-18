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
'''Entity Class for table Td_formatorisorsa
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class FormatoRisorsa
	Inherits _FormatoRisorsa
    Implements IFormatoRisorsa

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdFormatoRisorsa() as integer
    Get
	    Return MyBase.IdFormatoRisorsa
    End Get
    Set (byval value as integer)
        MyBase.IdFormatoRisorsa= value
    End Set
End property 


Public Overrides Property Formato() as string
    Get
	    Return MyBase.Formato
    End Get
    Set (byval value as string)
        MyBase.Formato= value
    End Set
End property 


Public Overrides Property Altezza() as integer
    Get
	    Return MyBase.Altezza
    End Get
    Set (byval value as integer)
        MyBase.Altezza= value
    End Set
End property 


Public Overrides Property Larghezza() as integer
    Get
	    Return MyBase.Larghezza
    End Get
    Set (byval value as integer)
        MyBase.Larghezza= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region


#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IFormatoRisorsa.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IFormatoRisorsa.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IFormatoRisorsa.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_formatorisorsa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFormatoRisorsa
        Inherits _IFormatoRisorsa

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface