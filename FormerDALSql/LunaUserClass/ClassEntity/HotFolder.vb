#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 05/05/2017 
#End Region



''' <summary>
'''Entity Class for table T_hotfolder
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class HotFolder
	Inherits _HotFolder
    Implements IHotFolder

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdHotFolder() as integer
    Get
	    Return MyBase.IdHotFolder
    End Get
    Set (byval value as integer)
        MyBase.IdHotFolder= value
    End Set
End property 


Public Overrides Property Nome() as string
    Get
	    Return MyBase.Nome
    End Get
    Set (byval value as string)
        MyBase.Nome= value
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


Public Overrides Property Stato() as integer
    Get
	    Return MyBase.Stato
    End Get
    Set (byval value as integer)
        MyBase.Stato= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IHotFolder.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IHotFolder.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IHotFolder.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_hotfolder
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IHotFolder
        Inherits _IHotFolder

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface