#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.21984 
'Author: Diego Lunadei
'Date: 04/12/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table T_scatole
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Scatola
	Inherits _Scatola
    Implements IScatola

    Public Sub New()
        MyBase.New()
        _Guid = System.Guid.NewGuid().ToString

    End Sub

    Private _Guid As String = String.Empty
    Public ReadOnly Property GUID As String
        Get
            Return _Guid
        End Get
    End Property

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub



#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IScatola.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IScatola.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IScatola.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

    Public Property OrdiniInScatola As New List(Of OrdineScatola)

End Class



''' <summary>
'''Interface for table T_scatole
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IScatola
        Inherits _IScatola

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface