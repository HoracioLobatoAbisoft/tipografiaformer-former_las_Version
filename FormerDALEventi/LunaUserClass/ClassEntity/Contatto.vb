#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 11/10/2016 
#End Region



''' <summary>
'''Entity Class for table Contatti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Contatto
	Inherits _Contatto
    Implements IContatto

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdContatto() as integer
    Get
	    Return MyBase.IdContatto
    End Get
    Set (byval value as integer)
        MyBase.IdContatto= value
    End Set
End property 


Public Overrides Property RagSoc() as string
    Get
	    Return MyBase.RagSoc
    End Get
    Set (byval value as string)
        MyBase.RagSoc= value
    End Set
End property 


Public Overrides Property Nominativo() as string
    Get
	    Return MyBase.Nominativo
    End Get
    Set (byval value as string)
        MyBase.Nominativo= value
    End Set
End property 


Public Overrides Property Email() as string
    Get
	    Return MyBase.Email
    End Get
    Set (byval value as string)
        MyBase.Email= value
    End Set
End property 


Public Overrides Property Cellulare() as string
    Get
	    Return MyBase.Cellulare
    End Get
    Set (byval value as string)
        MyBase.Cellulare= value
    End Set
End Property


    Public Overrides Property DataIns() As String
        Get
            Return MyBase.DataIns
        End Get
        Set(ByVal value As String)
            MyBase.DataIns = value
        End Set
    End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IContatto.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IContatto.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IContatto.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Contatti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IContatto
        Inherits _IContatto

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface