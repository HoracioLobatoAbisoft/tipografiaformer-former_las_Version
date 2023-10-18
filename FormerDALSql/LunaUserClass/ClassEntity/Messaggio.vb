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
Imports System.IO
Imports System.Drawing
Imports FormerLib.FormerEnum


''' <summary>
'''Entity Class for table T_postit
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Messaggio
    Inherits _Messaggio
    Implements IMessaggio

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"

    Public ReadOnly Property IcoTipo As Image
        Get
            Dim ris As Image = Nothing
            Select Case TipoMsg
                Case enTipoMessaggio.Automatico
                    ris = My.Resources._Attenzione
                Case enTipoMessaggio.Chiamata
                    ris = My.Resources._Telefono
                Case enTipoMessaggio.Messaggio
                    ris = My.Resources._Messaggio
            End Select
            Return ris
        End Get
    End Property

    Public ReadOnly Property Anteprima As Image
        Get
            Dim Ris As Image = Nothing

            If IdCom Then
                Using c As New Commessa
                    c.Read(IdCom)
                    Ris = c.ImgAnteprima
                End Using

            ElseIf IdOrd Then
                Using o As New Ordine
                    o.Read(IdOrd)
                    Ris = o.ImgAnteprima
                End Using
            End If

            If Ris Is Nothing Then Ris = New Bitmap(My.Resources.no_image, 75, 50)

            Return Ris
        End Get
    End Property

    Public ReadOnly Property DataInsFormat As String
        Get
            Dim Ris As String = _DataIns.ToString("dd MMM HH:mm")
            Return Ris
        End Get
    End Property

    Public ReadOnly Property Commessa As String
        Get
            Dim Ris As String = IIf(_IdCom, _IdCom, "-")
            Return Ris
        End Get
    End Property

    Public ReadOnly Property Ordine As String
        Get
            Dim Ris As String = IIf(_IdOrd, _IdOrd, "-")
            Return Ris
        End Get
    End Property

    Private _NomeMitt As String = ""
    Public ReadOnly Property NomeMitt As String
        Get

            Dim Ris As String = ""
            If _NomeMitt.Length Then
                Ris = _NomeMitt
            Else
                Dim u As New Utente
                u.Read(_IdMitt)
                Ris = u.Login
                _NomeMitt = Ris
            End If
            Return Ris
        End Get
    End Property

    Private _NomeDest As String = ""
    Public ReadOnly Property NomeDest As String
        Get

            Dim Ris As String = ""
            If _NomeDest.Length Then
                Ris = _NomeDest
            Else
                If _IdDest Then
                    Dim u As New Utente
                    u.Read(_IdDest)
                    Ris = u.Login
                    _NomeDest = Ris
                Else
                    Ris = "Tutti"
                End If

            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get

            Dim Ris As String = Strings.Left(_Testo, 50)
            Return Ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IMessaggio.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IMessaggio.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IMessaggio.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_postit
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IMessaggio
    Inherits _IMessaggio

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface