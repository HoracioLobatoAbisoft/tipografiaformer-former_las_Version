#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.4.1053 
'Author: Diego Lunadei
'Date: 21/05/2015 
#End Region



''' <summary>
'''Entity Class for table Newsletter
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Newsletter
	Inherits _Newsletter
    Implements INewsletter

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdNewsletter() as integer
    Get
	    Return MyBase.IdNewsletter
    End Get
    Set (byval value as integer)
        MyBase.IdNewsletter= value
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


Public Overrides Property Ip() as string
    Get
	    Return MyBase.Ip
    End Get
    Set (byval value as string)
        MyBase.Ip= value
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


Public Overrides Property Lavorato() as integer
    Get
	    Return MyBase.Lavorato
    End Get
    Set (byval value as integer)
        MyBase.Lavorato= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements INewsletter.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements INewsletter.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements INewsletter.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Newsletter
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface INewsletter
        Inherits _INewsletter

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface