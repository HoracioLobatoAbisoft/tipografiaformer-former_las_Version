#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 27/03/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table T_capcorr
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CapCorriere
	Inherits _CapCorriere
    Implements ICapCorriere

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdCapCorr() as integer
    Get
	    Return MyBase.IdCapCorr
    End Get
    Set (byval value as integer)
        MyBase.IdCapCorr= value
    End Set
End property 


Public Overrides Property IdCorriere() as integer
    Get
	    Return MyBase.IdCorriere
    End Get
    Set (byval value as integer)
        MyBase.IdCorriere= value
    End Set
End property 


Public Overrides Property Cap() as string
    Get
	    Return MyBase.Cap
    End Get
    Set (byval value as string)
        MyBase.Cap= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ICapCorriere.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ICapCorriere.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ICapCorriere.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_capcorr
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICapCorriere
        Inherits _ICapCorriere

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface