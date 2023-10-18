#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.2 
'Author: Diego Lunadei
'Date: 10/06/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table Unsubscribe
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Unsubscribe
	Inherits _Unsubscribe
    Implements IUnsubscribe

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdUnsubscribe() as integer
    Get
	    Return MyBase.IdUnsubscribe
    End Get
    Set (byval value as integer)
        MyBase.IdUnsubscribe= value
    End Set
End property 


Public Overrides Property Quando() as DateTime
    Get
	    Return MyBase.Quando
    End Get
    Set (byval value as DateTime)
        MyBase.Quando= value
    End Set
End property 


Public Overrides Property Ip() as string
    Get
	    Return MyBase.Ip
    End Get
    Set (byval value as string)
        MyBase.Ip= value
    End Set
End property 


Public Overrides Property Email() as string
    Get
	    Return MyBase.Email
    End Get
    Set (byval value as string)
        MyBase.Email= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IUnsubscribe.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IUnsubscribe.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IUnsubscribe.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Unsubscribe
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IUnsubscribe
        Inherits _IUnsubscribe

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface