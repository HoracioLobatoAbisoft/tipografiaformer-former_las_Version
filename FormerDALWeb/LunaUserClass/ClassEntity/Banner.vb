#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.6.16 
'Author: Diego Lunadei
'Date: 06/07/2017 
#End Region



''' <summary>
'''Entity Class for table Banner
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Banner
	Inherits _Banner
    Implements IBanner

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdBanner() as integer
    Get
	    Return MyBase.IdBanner
    End Get
    Set (byval value as integer)
        MyBase.IdBanner= value
    End Set
End property 


Public Overrides Property Url() as string
    Get
	    Return MyBase.Url
    End Get
    Set (byval value as string)
        MyBase.Url= value
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


Public Overrides Property Alt() as string
    Get
	    Return MyBase.Alt
    End Get
    Set (byval value as string)
        MyBase.Alt= value
    End Set
End property 


Public Overrides Property Attivo() as Boolean
    Get
	    Return MyBase.Attivo
    End Get
    Set (byval value as Boolean)
        MyBase.Attivo= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IBanner.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IBanner.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IBanner.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Banner
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IBanner
        Inherits _IBanner

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface