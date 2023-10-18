#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.4.1129 
'Author: Diego Lunadei
'Date: 29/10/2015 
#End Region



''' <summary>
'''Entity Class for table Review
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Review
	Inherits _Review
    Implements IReview

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdReview() as integer
    Get
	    Return MyBase.IdReview
    End Get
    Set (byval value as integer)
        MyBase.IdReview= value
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


Public Overrides Property IdLavoro() as integer
    Get
	    Return MyBase.IdLavoro
    End Get
    Set (byval value as integer)
        MyBase.IdLavoro= value
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


Public Overrides Property Quando() as DateTime
    Get
	    Return MyBase.Quando
    End Get
    Set (byval value as DateTime)
        MyBase.Quando= value
    End Set
End Property

    Public Overrides Property Pregi() as string
        Get
            Dim ris As String = MyBase.Pregi

            If ris.Length = 0 Then ris = "Nessuno"

            Return ris
        End Get
    Set (byval value as string)
        MyBase.Pregi= value
    End Set
End Property

    Public Overrides Property Difetti() as string
    Get
            Dim ris As String = MyBase.Difetti

            If ris.Length = 0 Then ris = "Nessuno"

            Return ris
    End Get
    Set (byval value as string)
        MyBase.Difetti= value
    End Set
End Property

    Public Overrides Property Voto() as integer
    Get
	    Return MyBase.Voto
    End Get
    Set (byval value as integer)
        MyBase.Voto= value
    End Set
End property 


Public Overrides Property Stato() as integer
    Get
	    Return MyBase.Stato
    End Get
    Set (byval value as integer)
        MyBase.Stato= value
    End Set
End Property

#End Region

#Region "Logic Field"
    Private _Utente As Utente = Nothing
    Public ReadOnly Property Utente As Utente
        Get
            If _Utente Is Nothing Then
                _Utente = New Utente
                _Utente.Read(IdUt)
            End If
            Return _Utente
        End Get
    End Property

    Public ReadOnly Property UtenteStr As String
        Get
            Return Utente.Nominativo & " (" & Utente.Email & ")"
        End Get
    End Property

    Private _ListinoBase As ListinoBaseW = Nothing
    Public ReadOnly Property ListinoBase As ListinoBaseW
        Get
            If _ListinoBase Is Nothing Then
                _ListinoBase = New ListinoBaseW
                _ListinoBase.Read(IdListinoBase)

            End If
            Return _ListinoBase
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IReview.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IReview.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

    Public Overrides Function Save() As Integer Implements IReview.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Review
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IReview
        Inherits _IReview

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface