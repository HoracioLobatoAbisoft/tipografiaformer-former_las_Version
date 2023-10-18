#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.3.46.21861 
'Author: Diego Lunadei
'Date: 13/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface

''' <summary>
'''Entity Class for table Td_catlav
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CatLavW
    Inherits _CatLavW
    Implements ICatLavW, ICategoriaLavB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"
    Private _NumeroLavorazioni As Integer = 0
    Public ReadOnly Property NumeroLavorazioni(IdListinoBase As Integer) As Integer
        Get

            If _NumeroLavorazioni = 0 Then
                Using mgr As New CatLavWDAO
                    _NumeroLavorazioni = mgr.GetNumeroLavorazioni(IdListinoBase, IdCatLav)
                End Using
            End If

            Return _NumeroLavorazioni
        End Get
    End Property

    Public ReadOnly Property TipoCaratteristicaB As Integer Implements ICategoriaLavB.TipoCaratteristica
        Get
            Return TipoCaratteristica
        End Get
    End Property

    Public ReadOnly Property TipoControlloB As Integer Implements ICategoriaLavB.TipoControllo
        Get
            Return TipoControllo
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICatLavW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICatLavW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICatLavW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Function GetLavorazioni(Optional WithBlank As Boolean = False) As List(Of LavorazioneW)
        Dim ris As New List(Of LavorazioneW)
        If WithBlank Then
            ris.Add(New LavorazioneW With {.IdLavoro = 0, .Descrizione = "-"})
        End If
        Using mgr As New LavorazioniWDAO

            For Each lav In mgr.FindAll("Descrizione",
                               New LUNA.LunaSearchParameter("IdCatLav", IdCatLav),
                               New LUNA.LunaSearchParameter("Stato", enStato.NonAttivo, "<>"))
                ris.Add(lav)
            Next

        End Using
        Return ris
    End Function

    Public Function GetLavorazioniOpzionaliByListinoBase(L As ListinoBaseW) As List(Of LavorazioneW)
        Dim ris As New List(Of LavorazioneW)
        L.LavorazioniOpz.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))
        ris.Add(New LavorazioneW With {.IdLavoro = 0, .Descrizione = "-"})
        For Each lav As LavorazioneW In L.LavorazioniOpz
            If lav.IdCatLav = IdCatLav Then
                ris.Add(lav)
            End If
        Next

        Return ris
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_catlav
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICatLavW
    Inherits _ICatLavW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface