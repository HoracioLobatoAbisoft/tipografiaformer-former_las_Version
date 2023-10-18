#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 23/02/2017 
#End Region



''' <summary>
'''Entity Class for table Tr_catvlistini
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ListinoWSuCatV
	Inherits _ListinoWSuCatV
    Implements IListinoWSuCatV

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdCatListino() as integer
    Get
	    Return MyBase.IdCatListino
    End Get
    Set (byval value as integer)
        MyBase.IdCatListino= value
    End Set
End property 


Public Overrides Property IdCatVirtuale() as integer
    Get
	    Return MyBase.IdCatVirtuale
    End Get
    Set (byval value as integer)
        MyBase.IdCatVirtuale= value
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


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IListinoWSuCatV.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IListinoWSuCatV.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IListinoWSuCatV.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Tr_catvlistini
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IListinoWSuCatV
        Inherits _IListinoWSuCatV

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface