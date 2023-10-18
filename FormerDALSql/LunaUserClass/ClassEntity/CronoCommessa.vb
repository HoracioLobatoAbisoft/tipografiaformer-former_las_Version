#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table T_commessecrono
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CronoCommessa
    Inherits _CronoCommessa
    Implements ICronoCommessa

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"
    Private _Utente As Utente = Nothing
    Public ReadOnly Property Utente As Utente
        Get
            If _Utente Is Nothing Then
                _Utente = New Utente
                If IdOperatore Then
                    _Utente.Read(IdOperatore)
                End If
            End If
            Return _Utente
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICronoCommessa.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICronoCommessa.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICronoCommessa.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_commessecrono
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICronoCommessa
    Inherits _ICronoCommessa

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface