#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 24/10/2016 
#End Region



''' <summary>
'''Entity Class for table Listiniutente
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ListinoUtenteW
	Inherits _ListinoUtenteW
    Implements IListinoUtenteW

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdListino() as integer
    Get
	    Return MyBase.IdListino
    End Get
    Set (byval value as integer)
        MyBase.IdListino= value
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


Public Overrides Property UltimaGenerazione() as DateTime
    Get
	    Return MyBase.UltimaGenerazione
    End Get
    Set (byval value as DateTime)
        MyBase.UltimaGenerazione= value
    End Set
End property 


Public Overrides Property PercDefault() as integer
    Get
	    Return MyBase.PercDefault
    End Get
    Set (byval value as integer)
        MyBase.PercDefault= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IListinoUtenteW.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IListinoUtenteW.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IListinoUtenteW.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Listiniutente
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IListinoUtenteW
        Inherits _IListinoUtenteW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface