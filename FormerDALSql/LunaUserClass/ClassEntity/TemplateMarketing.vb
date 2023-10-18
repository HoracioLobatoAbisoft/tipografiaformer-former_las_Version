#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.8.1.27156 
'Author: Diego Lunadei
'Date: 31/01/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table T_templatemarketing
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class TemplateMarketing
	Inherits _TemplateMarketing
    Implements ITemplateMarketing

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdTemplateMarketing() as integer
    Get
	    Return MyBase.IdTemplateMarketing
    End Get
    Set (byval value as integer)
        MyBase.IdTemplateMarketing= value
    End Set
End property 


Public Overrides Property Path() as string
    Get
	    Return MyBase.Path
    End Get
    Set (byval value as string)
        MyBase.Path= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ITemplateMarketing.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ITemplateMarketing.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ITemplateMarketing.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_templatemarketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITemplateMarketing
        Inherits _ITemplateMarketing

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface