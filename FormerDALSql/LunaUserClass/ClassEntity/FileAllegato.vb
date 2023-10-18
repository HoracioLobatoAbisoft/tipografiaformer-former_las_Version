#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.3 
'Author: Diego Lunadei
'Date: 12/12/2017 
#End Region



''' <summary>
'''Entity Class for table T_fileallegati
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class FileAllegato
	Inherits _FileAllegato
    Implements IFileAllegato

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdFileAllegato() as integer
    Get
	    Return MyBase.IdFileAllegato
    End Get
    Set (byval value as integer)
        MyBase.IdFileAllegato= value
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


Public Overrides Property IdOrd() as integer
    Get
	    Return MyBase.IdOrd
    End Get
    Set (byval value as integer)
        MyBase.IdOrd= value
    End Set
End property


#End Region

#Region "Logic Field"
    Public ReadOnly Property FileAllegato As String
        Get
            Return FormerLib.FormerHelper.File.EstraiNomeFile(FilePath)
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IFileAllegato.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IFileAllegato.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IFileAllegato.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table T_fileallegati
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFileAllegato
        Inherits _IFileAllegato

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface