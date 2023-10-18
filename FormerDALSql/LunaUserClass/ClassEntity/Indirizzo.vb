#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.5.18.15665 
'Author: Diego Lunadei
'Date: 29/10/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table T_indirizzi
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

    Public ReadOnly Property RiassuntoEx() As String
        Get
            Return Riassunto
        End Get
    End Property

    Private _Localita As ComuneInElenco = Nothing
    Public ReadOnly Property Localita As ComuneInElenco
        Get
            If _Localita Is Nothing Then
                _Localita = New ComuneInElenco
                If IdComune Then _Localita.Read(IdComune)
            End If
            Return _Localita
        End Get
    End Property

    Private _Comune As String = String.Empty
    Public Property Comune As String
        Get

            If IdComune Then
                _Comune = Localita.Comune
            End If
            Return _Comune
        End Get
        Set(value As String)
            _Comune = value
        End Set
    End Property

    Private _Provincia As String = String.Empty
    Public Property Provincia As String
        Get

            If IdComune Then
                _Provincia = Localita.Provincia
            End If
            Return _Provincia
        End Get
        Set(value As String)
            _Provincia = value
        End Set
    End Property

    Public ReadOnly Property PredefinitoStr As String
        Get
            Dim Ris As String = "No"
            If Predefinito Then
                Ris = "Sì"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property AttivoStr As String
        Get
            Dim Ris As String = "Sì"
            If Status Then
                Ris = "No"
            End If
            Return Ris
        End Get
    End Property

    Private _VoceRub As VoceRubrica = Nothing
    Public ReadOnly Property VoceRub As VoceRubrica
        Get
            If _VoceRub Is Nothing Then

                _VoceRub = New VoceRubrica
                _VoceRub.Read(IdRubrica)
            End If
            Return _VoceRub
        End Get
    End Property

    Public Overrides Property Destinatario As String
        Get
            Dim Ris As String = MyBase.Destinatario

            If Ris.Length = 0 Then Ris = VoceRub.RagSocNome

            Return Ris

        End Get
        Set(value As String)
            MyBase.Destinatario = value
        End Set
    End Property

    Public ReadOnly Property Riassunto(Optional WithNome As Boolean = True) As String
        Get
            Dim Ris As String = String.Empty
            Ris = Destinatario & ", " & Indirizzo & " - " & RiassuntoLocalita
            Ris &= IIf(WithNome, " [" & Nome & "]", String.Empty)
            Return Ris
        End Get
    End Property

    Public ReadOnly Property RiassuntoLocalita As String
        Get
            Dim ris As String = String.Empty

            If Cap <> FormerLib.FormerConst.Culture.CapEstero Then
                ris = Cap & " "
            End If

            ris &= Citta
            If Localita.IDCap Then
                ris &= " (" & Localita.ProvinciaSel.Cod & ") "
            Else
                ris &= " "
            End If

            ris &= Nazione.Code

            Return ris
        End Get
    End Property

    Private _nazione As Nazione = Nothing
    Public ReadOnly Property Nazione As Nazione
        Get
            _nazione = MgrNazioni.GetLista().Find(Function(x) x.IdNazione = IdNazione)
            Return _nazione
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
'''Interface for table T_indirizzi
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