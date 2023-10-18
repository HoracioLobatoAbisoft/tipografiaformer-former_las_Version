#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.11.2 
'Author: Diego Lunadei
'Date: 20/11/2017 
#End Region



''' <summary>
'''Entity Class for table T_functionlock
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class FunctionLock
	Inherits _FunctionLock
    Implements IFunctionLock

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdFunctionLock() as integer
    Get
	    Return MyBase.IdFunctionLock
    End Get
    Set (byval value as integer)
        MyBase.IdFunctionLock= value
    End Set
End property 


Public Overrides Property IdFunction() as integer
    Get
	    Return MyBase.IdFunction
    End Get
    Set (byval value as integer)
        MyBase.IdFunction= value
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


Public Overrides Property IdUt() as integer
    Get
	    Return MyBase.IdUt
    End Get
    Set (byval value as integer)
        MyBase.IdUt= value
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


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IFunctionLock.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IFunctionLock.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IFunctionLock.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_functionlock
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFunctionLock
        Inherits _IFunctionLock

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface