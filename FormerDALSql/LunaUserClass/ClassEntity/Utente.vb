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
Imports FormerLib.FormerEnum
Imports System.Drawing
Imports System.IO
Imports FormerConfig

''' <summary>
'''Entity Class for table T_utenti
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

    Public ReadOnly Property TipoStr As String
        Get
            Dim ris As String = String.Empty
            If _Tipo = enTipoUtente.Admin Then
                ris = "Amministrazione"
            ElseIf _Tipo = enTipoUtente.Operatore Then
                ris = "Operatore"
            ElseIf _Tipo = enTipoUtente.SuperOperatore Then
                ris = "SuperOperatore"
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = TipoStr & " - " & Login
            Return ris
        End Get
    End Property

    Public ReadOnly Property LoginEx As String
        Get
            Return StrConv(Login, VbStrConv.ProperCase)
        End Get
    End Property

    'Public ReadOnly Property RepartoDefaultStr As String
    '    Get
    '        Select Case _RepDefault
    '            Case enRepartoOperatore.StampaOffset
    '                Return "Stampa"
    '            Case enRepartoOperatore.ImballaggioCorriere
    '                Return "Imballaggio Corriere"
    '            Case enRepartoOperatore.Imballaggio
    '                Return "Imballaggio"
    '            Case enRepartoOperatore.FinituraSuProdotto
    '                Return "Finitura su Prodotto"
    '            Case enRepartoOperatore.FinituraSuCommessa
    '                Return "Finitura su Commessa"
    '            Case enRepartoOperatore.Consegne
    '                Return "Consegne"
    '        End Select
    '    End Get
    'End Property

    Public ReadOnly Property MacchinariAbilitati As List(Of Macchinario)
        Get
            Dim _Macchinari As New List(Of Macchinario)

            Using mgr As New UtMacDAO
                Dim l As List(Of UtMac) = mgr.FindAll(New LUNA.LunaSearchParameter("IdUt", IdUt))

                For Each singUtMac As UtMac In l
                    Using m As New Macchinario
                        m.Read(singUtMac.IdMac)
                        _Macchinari.Add(m)
                    End Using
                Next
            End Using

            Return _Macchinari

        End Get
    End Property

    Public ReadOnly Property AttivoStr As String
        Get
            If Attivo Then
                Return "Si"
            Else
                Return "No"
            End If
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IUtente.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
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

    Public ReadOnly Property ImgRifLocale As String
        Get
            Dim ris As String = String.Empty

            If PathFoto.Length Then

                ris = FormerPath.PathTempImg & FormerLib.FormerHelper.File.EstraiNomeFile(PathFoto)

            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property FotoOperatore As Image
        Get
            Dim ris As Image = Nothing
            Dim PathRiferimento As String = PathFoto
            If PathRiferimento.Length Then

                Dim PathLocaleImg As String = ImgRifLocale

                If File.Exists(PathLocaleImg) Then
                    PathRiferimento = PathLocaleImg
                Else
                    Try
                        Dim imgPreview As Image = Image.FromFile(PathFoto)

                        imgPreview = FormerThumbnail.GetForUtente(imgPreview)

                        imgPreview.Save(PathLocaleImg)

                    Catch ex As Exception

                    End Try
                End If

                Try
                    If File.Exists(PathRiferimento) Then
                        ris = Image.FromFile(PathRiferimento)
                    End If

                Catch ex As Exception

                End Try

            End If

            If ris Is Nothing Then ris = My.Resources.operatore

            Return ris
        End Get
    End Property

#End Region

End Class



''' <summary>
'''Interface for table T_utenti
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