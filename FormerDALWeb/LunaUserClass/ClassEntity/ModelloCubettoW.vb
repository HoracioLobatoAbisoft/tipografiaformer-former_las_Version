#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.4.1053 
'Author: Diego Lunadei
'Date: 21/09/2015 
#End Region



''' <summary>
'''Entity Class for table Modellicubetti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ModelloCubettoW
	Inherits _ModelloCubettoW
    Implements IModelloCubettoW

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IDModelloCubetto() as integer
    Get
	    Return MyBase.IDModelloCubetto
    End Get
    Set (byval value as integer)
        MyBase.IDModelloCubetto= value
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


Public Overrides Property Lunghezza() as integer
    Get
	    Return MyBase.Lunghezza
    End Get
    Set (byval value as integer)
        MyBase.Lunghezza= value
    End Set
End property 


Public Overrides Property Larghezza() as integer
    Get
	    Return MyBase.Larghezza
    End Get
    Set (byval value as integer)
        MyBase.Larghezza= value
    End Set
End property 


Public Overrides Property Profondita() as integer
    Get
	    Return MyBase.Profondita
    End Get
    Set (byval value as integer)
        MyBase.Profondita= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IModelloCubettoW.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IModelloCubettoW.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IModelloCubettoW.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Modellicubetti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IModelloCubettoW
        Inherits _IModelloCubettoW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface