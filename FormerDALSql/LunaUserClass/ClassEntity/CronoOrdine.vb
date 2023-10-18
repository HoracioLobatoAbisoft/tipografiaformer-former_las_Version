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
Imports System.Drawing

''' <summary>
'''Entity Class for table T_ordinicrono
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CronoOrdine
    Inherits _CronoOrdine
    Implements ICronoOrdine

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

    Private _OrdineRiferimento As Ordine = Nothing
    Public ReadOnly Property OrdineRiferimento As Ordine
        Get
            If _OrdineRiferimento Is Nothing Then
                _OrdineRiferimento = New Ordine
                _OrdineRiferimento.Read(IdOrd)
            End If
            Return _OrdineRiferimento
        End Get
    End Property

    Public ReadOnly Property ImgAnteprima As Image
        Get
            Return OrdineRiferimento.ImgAnteprima

        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICronoOrdine.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICronoOrdine.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICronoOrdine.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

Public Class CronoOrdineRicerca
    Inherits CronoOrdine


End Class


''' <summary>
'''Interface for table T_ordinicrono
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICronoOrdine
    Inherits _ICronoOrdine

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface