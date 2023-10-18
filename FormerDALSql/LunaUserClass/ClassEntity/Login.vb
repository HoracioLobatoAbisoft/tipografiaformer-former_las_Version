#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.11.2 
'Author: Diego Lunadei
'Date: 20/11/2017 
#End Region



''' <summary>
'''Entity Class for table T_login
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Login
	Inherits _Login
    Implements ILogin

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdLogin() as integer
    Get
	    Return MyBase.IdLogin
    End Get
    Set (byval value as integer)
        MyBase.IdLogin= value
    End Set
End property 


Public Overrides Property IdUt() as integer
    Get
	    Return MyBase.IdUt
    End Get
    Set (byval value as integer)
        MyBase.IdUt= value
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


Public Overrides Property Postazione() as string
    Get
	    Return MyBase.Postazione
    End Get
    Set (byval value as string)
        MyBase.Postazione= value
    End Set
End property 


Public Overrides Property Versione() as string
    Get
	    Return MyBase.Versione
    End Get
    Set (byval value as string)
        MyBase.Versione= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements ILogin.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ILogin.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ILogin.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_login
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ILogin
        Inherits _ILogin

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface