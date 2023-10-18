#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 06/07/2016 
#End Region



''' <summary>
'''Entity Class for table Mailprevattach
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class AttachPreventivoMail
	Inherits _AttachPreventivoMail
    Implements IAttachPreventivoMail

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdMailAttach() as integer
    Get
	    Return MyBase.IdMailAttach
    End Get
    Set (byval value as integer)
        MyBase.IdMailAttach= value
    End Set
End property 


Public Overrides Property IdMailPreventivo() as integer
    Get
	    Return MyBase.IdMailPreventivo
    End Get
    Set (byval value as integer)
        MyBase.IdMailPreventivo= value
    End Set
End property 


Public Overrides Property Path() as string
    Get
	    Return MyBase.Path
    End Get
    Set (byval value as string)
        MyBase.Path= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IAttachPreventivoMail.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IAttachPreventivoMail.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IAttachPreventivoMail.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Mailprevattach
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IAttachPreventivoMail
        Inherits _IAttachPreventivoMail

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface