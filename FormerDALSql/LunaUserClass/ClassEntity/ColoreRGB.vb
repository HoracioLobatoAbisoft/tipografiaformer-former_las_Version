#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.8.1.27156 
'Author: Diego Lunadei
'Date: 10/02/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table T_colori
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ColoreRGB
	Inherits _ColoreRGB
    Implements IColoreRGB

    Public Sub New()
        MyBase.New()
    End Sub


    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Overrides Property IdColore() As Integer
        Get
            Return MyBase.IdColore
        End Get
        Set(ByVal value As Integer)
            MyBase.IdColore = value
        End Set
    End Property


    Public Overrides Property Nome() As String
        Get
            Return MyBase.Nome
        End Get
        Set(ByVal value As String)
            MyBase.Nome = value
        End Set
    End Property


    Public Overrides Property R() As Integer
        Get
            Return MyBase.R
        End Get
        Set(ByVal value As Integer)
            MyBase.R = value
        End Set
    End Property


    Public Overrides Property G() As Integer
        Get
            Return MyBase.G
        End Get
        Set(ByVal value As Integer)
            MyBase.G = value
        End Set
    End Property


    Public Overrides Property B() As Integer
        Get
            Return MyBase.B
        End Get
        Set(ByVal value As Integer)
            MyBase.B = value
        End Set
    End Property


    Public Overrides Property Alpha() As Integer
        Get
            Return MyBase.Alpha
        End Get
        Set(ByVal value As Integer)
            MyBase.Alpha = value
        End Set
    End Property

#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IColoreRGB.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IColoreRGB.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IColoreRGB.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_colori
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IColoreRGB
        Inherits _IColoreRGB

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface