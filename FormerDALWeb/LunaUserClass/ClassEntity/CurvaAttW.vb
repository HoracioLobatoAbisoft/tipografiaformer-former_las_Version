#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.3.46.21861 
'Author: Diego Lunadei
'Date: 13/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerBusinessLogicInterface
''' <summary>
'''Entity Class for table T_curvaatt
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CurvaAttW
    Inherits _CurvaAttW
    Implements ICurvaAttW
    Implements ICurvaAttB
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub
#Region "Database Field"


    Public Overrides Property IdCurvaAtt() As Integer Implements ICurvaAttB.IdCurvaAtt
        Get
            Return MyBase.IdCurvaAtt
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCurvaAtt = value
        End Set
    End Property


    Public Overrides Property NomeCurva() As String Implements ICurvaAttB.NomeCurva
        Get
            Return MyBase.NomeCurva
        End Get
        Set(ByVal value As String)
            MyBase.NomeCurva = value
        End Set
    End Property


    Public Overrides Property v1() As Single Implements ICurvaAttB.v1
        Get
            Return MyBase.v1
        End Get
        Set(ByVal value As Single)
            MyBase.v1 = value
        End Set
    End Property


    Public Overrides Property v2() As Single Implements ICurvaAttB.v2
        Get
            Return MyBase.v2
        End Get
        Set(ByVal value As Single)
            MyBase.v2 = value
        End Set
    End Property


    Public Overrides Property v3() As Single Implements ICurvaAttB.v3
        Get
            Return MyBase.v3
        End Get
        Set(ByVal value As Single)
            MyBase.v3 = value
        End Set
    End Property


    Public Overrides Property v4() As Single Implements ICurvaAttB.v4
        Get
            Return MyBase.v4
        End Get
        Set(ByVal value As Single)
            MyBase.v4 = value
        End Set
    End Property


    Public Overrides Property v5() As Single Implements ICurvaAttB.v5
        Get
            Return MyBase.v5
        End Get
        Set(ByVal value As Single)
            MyBase.v5 = value
        End Set
    End Property


    Public Overrides Property v6() As Single Implements ICurvaAttB.v6
        Get
            Return MyBase.v6
        End Get
        Set(ByVal value As Single)
            MyBase.v6 = value
        End Set
    End Property


#End Region


#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ICurvaAttW.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ICurvaAttW.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ICurvaAttW.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_curvaatt
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICurvaAttW
    Inherits _ICurvaAttW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface