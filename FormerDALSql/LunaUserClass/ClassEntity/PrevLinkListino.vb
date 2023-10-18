#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.8.1.27156 
'Author: Diego Lunadei
'Date: 03/02/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table Tr_prevlistino
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class PrevLinkListino
	Inherits _PrevLinkListino
    Implements IPrevLinkListino

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdPrevListino() as integer
    Get
	    Return MyBase.IdPrevListino
    End Get
    Set (byval value as integer)
        MyBase.IdPrevListino= value
    End Set
End property 


Public Overrides Property IdPreventivazione() as integer
    Get
	    Return MyBase.IdPreventivazione
    End Get
    Set (byval value as integer)
        MyBase.IdPreventivazione= value
    End Set
End property 


Public Overrides Property IdListinoBase() as integer
    Get
	    Return MyBase.IdListinoBase
    End Get
    Set (byval value as integer)
        MyBase.IdListinoBase= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IPrevLinkListino.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IPrevLinkListino.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IPrevLinkListino.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Tr_prevlistino
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPrevLinkListino
        Inherits _IPrevLinkListino

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface