#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.2.0.18 
'Author: Diego Lunadei
'Date: 12/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum
Imports System.Data.Common

''' <summary>
'''Entity Class for table Utenti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Utente
    Inherits _Utente
    Implements IUtente

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"

    Public Overrides Property IdCorriereDef As Integer
        Get
            Dim Ris As Integer = MyBase.IdCorriereDef

            If IdUt = 0 Then
                Ris = enTipoCorriere.ConTariffa
            End If

            Return Ris
        End Get
        Set(value As Integer)
            MyBase.IdCorriereDef = value
        End Set
    End Property

    Private _Corriere As MetodoConsegna = Nothing
    Public ReadOnly Property Corriere As MetodoConsegna
        Get
            Dim _Corriere As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(IdCorriereDef)

            Return _Corriere
        End Get
    End Property

    Public ReadOnly Property Nominativo As String
        Get
            Dim ris As String = ""
            If RagSoc.Length Then
                ris = RagSoc
            ElseIf Nome.Length Then
                ris = Nome & " " & Cognome
            End If
            Return ris
        End Get

    End Property

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

    'Private _ProvinciaSel As Provincia = Nothing
    'Public ReadOnly Property ProvinciaSel As Provincia
    '    Get
    '        If _ProvinciaSel Is Nothing Then
    '            _ProvinciaSel = New Provincia
    '            If IdProvincia Then _ProvinciaSel.Read(IdProvincia)
    '        End If
    '        Return _ProvinciaSel
    '    End Get
    'End Property
    Public ReadOnly Property NewsletterStr As String
        Get
            Dim ris As String = "SI"
            If NoMail = enSiNo.Si Then
                ris = "NO"
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoUtStr As String
        Get
            Dim ris As String = "Cliente"
            If TipoRub = enTipoRubrica.Rivenditore Then
                ris = "Rivenditore"
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property LastLoginStr As String
        Get
            Dim ris As String = "-"
            If LastLogin <> Date.MinValue Then

                ris = LastLogin.ToString("dd/MM/yyyy HH:mm")

            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property PIvaStr As String
        Get
            Dim ris As String = String.Empty

            If Piva.Length Then
                ris = PrefissoPIva & Piva
            End If

            Return ris
        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IUtente.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        ' Return True
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function


    Public Overrides Function Read(Id As Integer) As Integer Implements IUtente.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IUtente.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Sub AggiornaLogin(LastLogin As Date,
                             LastIp As String)

        Using mgr As New UtentiDAO
            mgr.AggiornaLogin(IdUt, LastLogin, LastIp)
        End Using

    End Sub

#End Region

End Class



''' <summary>
'''Interface for table Utenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IUtente
    Inherits _IUtente

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface