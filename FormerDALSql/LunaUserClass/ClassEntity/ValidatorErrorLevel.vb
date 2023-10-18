#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.4.1053 
'Author: Diego Lunadei
'Date: 07/07/2015 
#End Region



''' <summary>
'''Entity Class for table T_validatorerrorlevel
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ValidatorErrorLevel
	Inherits _ValidatorErrorLevel
    Implements IValidatorErrorLevel

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdVELevel() as integer
    Get
	    Return MyBase.IdVELevel
    End Get
    Set (byval value as integer)
        MyBase.IdVELevel= value
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


Public Overrides Property ValidatorErrorCode() as integer
    Get
	    Return MyBase.ValidatorErrorCode
    End Get
    Set (byval value as integer)
        MyBase.ValidatorErrorCode= value
    End Set
End property 


Public Overrides Property ValidatorErrorLevel() as integer
    Get
	    Return MyBase.ValidatorErrorLevel
    End Get
    Set (byval value as integer)
        MyBase.ValidatorErrorLevel= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IValidatorErrorLevel.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IValidatorErrorLevel.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IValidatorErrorLevel.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_validatorerrorlevel
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IValidatorErrorLevel
        Inherits _IValidatorErrorLevel

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface