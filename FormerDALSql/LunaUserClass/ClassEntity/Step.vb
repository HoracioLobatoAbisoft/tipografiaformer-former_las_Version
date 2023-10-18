#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.37 
'Author: Diego Lunadei
'Date: 20/12/2017 
#End Region



''' <summary>
'''Entity Class for table T_step
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Step
	Inherits _Step
    Implements IStep

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdStep() as integer
    Get
	    Return MyBase.IdStep
    End Get
    Set (byval value as integer)
        MyBase.IdStep= value
    End Set
End property 


Public Overrides Property IdProcedura() as integer
    Get
	    Return MyBase.IdProcedura
    End Get
    Set (byval value as integer)
        MyBase.IdProcedura= value
    End Set
End property 


Public Overrides Property Titolo() as string
    Get
	    Return MyBase.Titolo
    End Get
    Set (byval value as string)
        MyBase.Titolo= value
    End Set
End property 


Public Overrides Property Testo() as string
    Get
	    Return MyBase.Testo
    End Get
    Set (byval value as string)
        MyBase.Testo= value
    End Set
End property 


Public Overrides Property FilePath() as string
    Get
	    Return MyBase.FilePath
    End Get
    Set (byval value as string)
        MyBase.FilePath= value
    End Set
End property 


Public Overrides Property Ordine() as integer
    Get
	    Return MyBase.Ordine
    End Get
    Set (byval value as integer)
        MyBase.Ordine= value
    End Set
End property 


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IStep.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IStep.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IStep.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_step
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IStep
        Inherits _IStep

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface