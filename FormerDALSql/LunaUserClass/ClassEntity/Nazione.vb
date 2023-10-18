#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 21/02/2019 
#End Region

Imports FormerBusinessLogicInterface
''' <summary>
'''Entity Class for table Nazioni
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class Nazione
    Inherits _Nazione
    Implements INazione, INazioneBusiness

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdNazione() As Integer
        Get
            Return MyBase.IdNazione
        End Get
        Set(ByVal value As Integer)
            MyBase.IdNazione = value
        End Set
    End Property


    Public Overrides Property Code() As String
        Get
            Return MyBase.Code
        End Get
        Set(ByVal value As String)
            MyBase.Code = value
        End Set
    End Property


    Public Overrides Property IdGruppo() As Integer
        Get
            Return MyBase.IdGruppo
        End Get
        Set(ByVal value As Integer)
            MyBase.IdGruppo = value
        End Set
    End Property


    Public Overrides Property Nazione() As String
        Get
            Return MyBase.Nazione
        End Get
        Set(ByVal value As String)
            MyBase.Nazione = value
        End Set
    End Property


#End Region

#Region "Logic Field"
    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = Nazione & " - " & Code
            Return ris
        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements INazione.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements INazione.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements INazione.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

    Private ReadOnly Property INazioneBusiness_IdNazione As Integer Implements INazioneBusiness.IdNazione
        Get
            Return IdNazione
        End Get
    End Property

    Private ReadOnly Property INazioneBusiness_Code As String Implements INazioneBusiness.Code
        Get
            Return Code
        End Get
    End Property

    Private ReadOnly Property INazioneBusiness_IdGruppo As Integer Implements INazioneBusiness.IdGruppo
        Get
            Return IdGruppo
        End Get
    End Property

    Private ReadOnly Property INazioneBusiness_Nazione As String Implements INazioneBusiness.Nazione
        Get
            Return Nazione
        End Get
    End Property

End Class

''' <summary>
'''Interface for table Nazioni
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface INazione
    Inherits _INazione

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface