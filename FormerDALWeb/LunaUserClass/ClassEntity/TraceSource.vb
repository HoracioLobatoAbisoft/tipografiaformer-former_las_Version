#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.10.5.13 
'Author: Diego Lunadei
'Date: 13/05/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table Tracesource
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class TraceSource
	Inherits _TraceSource
    Implements ITraceSource

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdTraceSource() as integer
    Get
	    Return MyBase.IdTraceSource
    End Get
    Set (byval value as integer)
        MyBase.IdTraceSource= value
    End Set
End property 


Public Overrides Property Nome() as string
    Get
	    Return MyBase.Nome
    End Get
    Set (byval value as string)
        MyBase.Nome= value
    End Set
End property 


Public Overrides Property TargetUrl() as string
    Get
	    Return MyBase.TargetUrl
    End Get
    Set (byval value as string)
        MyBase.TargetUrl= value
    End Set
End property 


Public Overrides Property Counter() as integer
    Get
	    Return MyBase.Counter
    End Get
    Set (byval value as integer)
        MyBase.Counter= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ITraceSource.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ITraceSource.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ITraceSource.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Tracesource
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITraceSource
        Inherits _ITraceSource

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface