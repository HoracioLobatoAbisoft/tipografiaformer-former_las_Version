#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.27766 
'Author: Diego Lunadei
'Date: 09/10/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table Indirizzi
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Indirizzo
    Inherits _Indirizzo
    Implements IIndirizzo

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"

    'Private _Provincia As Provincia = Nothing
    'Public Property Provincia As Provincia
    '    Get
    '        If _Provincia Is Nothing Then
    '            _Provincia = New Provincia
    '            _Provincia.Read(IdProvincia)

    '        End If
    '        Return _Provincia
    '    End Get
    '    Set(value As Provincia)
    '        _Provincia = value
    '    End Set
    'End Property


    'Private _Comune As Comune = Nothing
    'Public Property Comune As Comune
    '    Get
    '        If _Comune Is Nothing Then
    '            _Comune = New Comune
    '            _Comune.Read(IdComune)

    '        End If
    '        Return _Comune
    '    End Get
    '    Set(value As Comune)
    '        _Comune = value
    '    End Set
    'End Property

    Private _Localita As ComuneInElenco = Nothing
    Public ReadOnly Property Localita As ComuneInElenco
        Get
            If _Localita Is Nothing Then
                _Localita = New ComuneInElenco
                _Localita.Read(IdComune)
            End If
            Return _Localita
        End Get
    End Property

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

    Public Overrides Property Destinatario As String
        Get
            Dim Ris As String = MyBase.Destinatario

            If Ris.Length = 0 Then Ris = Utente.Nominativo

            Return Ris

        End Get
        Set(value As String)
            MyBase.Destinatario = value
        End Set
    End Property

    Public ReadOnly Property LocalitaStr As String
        Get
            Dim Ris As String = String.Empty

            If IdNazione = FormerLib.FormerConst.Culture.IdItalia Then
                Ris &= Cap & " " & Citta & " (" & Localita.Provincia & ")"
            Else
                Ris &= Citta
            End If

            Return Ris
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim Ris As String = String.Empty

            Ris = Destinatario & ", " & Indirizzo & " - "

            Ris &= LocalitaStr

            Return Ris
        End Get
    End Property

    Public ReadOnly Property NazioneStr As String
        Get
            Dim Ris As String = String.Empty

            Ris = MgrNazioni.GetLista.Find(Function(x) x.IdNazione = IdNazione).Nazione

            'Ris &= LocalitaStr

            Return Ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IIndirizzo.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IIndirizzo.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IIndirizzo.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Indirizzi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IIndirizzo
    Inherits _IIndirizzo

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface