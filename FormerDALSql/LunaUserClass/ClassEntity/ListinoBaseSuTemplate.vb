#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.7 
'Author: Diego Lunadei
'Date: 06/10/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table T_tmlb
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ListinoBaseSuTemplate
	Inherits _ListinoBaseSuTemplate
    Implements IListinoBaseSuTemplate

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdTMLB() as integer
    Get
	    Return MyBase.IdTMLB
    End Get
    Set (byval value as integer)
        MyBase.IdTMLB= value
    End Set
End property 


Public Overrides Property IdTmOff() as integer
    Get
	    Return MyBase.IdTmOff
    End Get
    Set (byval value as integer)
        MyBase.IdTmOff= value
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

    Private _Tm As TemplateMarketingOfferte
    Public ReadOnly Property Tm As TemplateMarketingOfferte
        Get
            If _Tm Is Nothing Then
                _Tm = New TemplateMarketingOfferte
                _Tm.Read(IdTmOff)
            End If
            Return _Tm
        End Get
    End Property

    Private _ListinoBase As ListinoBase = Nothing
    Public ReadOnly Property ListinoBase As ListinoBase
        Get
            If _ListinoBase Is Nothing Then
                _ListinoBase = New ListinoBase
                _ListinoBase.Read(IdListinoBase)
            End If
            Return _ListinoBase
        End Get
    End Property

#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IListinoBaseSuTemplate.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IListinoBaseSuTemplate.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IListinoBaseSuTemplate.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_tmlb
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IListinoBaseSuTemplate
        Inherits _IListinoBaseSuTemplate

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface