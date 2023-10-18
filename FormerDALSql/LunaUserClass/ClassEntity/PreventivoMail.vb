#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 06/07/2016 
#End Region

Imports System.Drawing
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table Mailpreventivi
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class PreventivoMail
    Inherits _PreventivoMail
    Implements IPreventivoMail

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Overrides Property IdMailPreventivo() As Integer
        Get
            Return MyBase.IdMailPreventivo
        End Get
        Set(ByVal value As Integer)
            MyBase.IdMailPreventivo = value
        End Set
    End Property


    Public Overrides Property IdMailRif() As Integer
        Get
            Return MyBase.IdMailRif
        End Get
        Set(ByVal value As Integer)
            MyBase.IdMailRif = value
        End Set
    End Property


    Public Overrides Property DataRif() As DateTime
        Get
            Return MyBase.DataRif
        End Get
        Set(ByVal value As DateTime)
            MyBase.DataRif = value
        End Set
    End Property


    Public Overrides Property Mittente() As String
        Get
            Return MyBase.Mittente
        End Get
        Set(ByVal value As String)
            MyBase.Mittente = value
        End Set
    End Property


    Public Overrides Property Titolo() As String
        Get
            Return MyBase.Titolo
        End Get
        Set(ByVal value As String)
            MyBase.Titolo = value
        End Set
    End Property


    Public Overrides Property Testo() As String
        Get
            Return MyBase.Testo
        End Get
        Set(ByVal value As String)
            MyBase.Testo = value
        End Set
    End Property


    Public Overrides Property IdRub() As Integer
        Get
            Return MyBase.IdRub
        End Get
        Set(ByVal value As Integer)
            MyBase.IdRub = value
        End Set
    End Property


    Public Overrides Property IdUtFormer() As Integer
        Get
            Return MyBase.IdUtFormer
        End Get
        Set(ByVal value As Integer)
            MyBase.IdUtFormer = value
        End Set
    End Property


    Public Overrides Property Stato() As Integer
        Get
            Return MyBase.Stato
        End Get
        Set(ByVal value As Integer)
            MyBase.Stato = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Private _IcoStato As Image = Nothing
    Public ReadOnly Property IcoStato As Image
        Get
            If IdMailRif = 0 Then
                If _IcoStato Is Nothing Then
                    If Stato = enStatoPreventivoMail.DaLavorare AndAlso (IdUtFormer = 0 And ListaRisposte.FindAll(Function(x) x.IdUtFormer <> 0).Count = 0) Then
                        _IcoStato = My.Resources._Attenzione16
                    End If
                End If
            End If
            Return _IcoStato
        End Get
    End Property

    Private _IcoAttach As Image = Nothing
    Public ReadOnly Property IcoAttach As Image
        Get
            If _IcoAttach Is Nothing Then
                If Allegati.Count Then
                    _IcoAttach = My.Resources.attach
                End If
            End If
            Return _IcoAttach
        End Get
    End Property

    Private _IcoTipo As Image = Nothing
    Public ReadOnly Property IcoTipo As Image
        Get
            If _IcoTipo Is Nothing Then
                If IdMailRif = 0 Then

                    Select Case Stato
                        Case enStatoPreventivoMail.DaLavorare
                            _IcoTipo = My.Resources._Mail16
                        Case enStatoPreventivoMail.Lavorata
                            _IcoTipo = My.Resources._Cartella16
                        Case enStatoPreventivoMail.Eliminata
                            _IcoTipo = My.Resources._Elimina16
                    End Select

                End If
            End If
            Return _IcoTipo
        End Get
    End Property

    Public ReadOnly Property MailInizialeConversazione As PreventivoMail
        Get
            Dim ris As PreventivoMail = Nothing

            If IdMailRif Then
                'qui si tratta di una risposta 
                Using mgr As New PreventiviMailDAO
                    ris = mgr.Find(New LUNA.LunaSearchParameter(LFM.PreventivoMail.GuidMail, GuidMail),
                                   New LUNA.LunaSearchParameter(LFM.PreventivoMail.IdMailRif, 0))
                End Using
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property MailRif As PreventivoMail
        Get
            Dim ris As PreventivoMail = Nothing

            If IdMailRif Then
                ris = New PreventivoMail
                ris.Read(IdMailRif)
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property MittenteStr As String
        Get
            Dim ris As String = String.Empty

            If IdRub Then
                ris = VoceRubrica.RagSocNome
            ElseIf IdUtFormer Then
                Using U As New Utente
                    U.Read(IdUtFormer)
                    ris = U.Login.ToUpper
                End Using
            Else
                ris = "<" & Mittente & ">"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property TitoloStr As String
        Get
            Dim ris As String = String.Empty

            ris = Titolo

            Return ris
        End Get
    End Property

    Public ReadOnly Property NomeGruppo As Date
        Get
            Dim ris As Date

            If DataOrdinamento.Date = Now.Date Then
                ris = DataOrdinamento.Date
            Else
                ris = New Date(DataOrdinamento.Year, DataOrdinamento.Month, 1)
            End If

            Return ris

            'Return DataRif.Date.ToString("MMMM yyyy")
        End Get
    End Property

    Public ReadOnly Property DataStr As String
        Get
            Dim ris As String = String.Empty

            If Now.Date = DataRif.Date Then
                ris = DataRif.ToString("HH.mm")
            Else
                ris = DataRif.ToString("dd/MM/yyyy")
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property DataOrdinamento As Date
        Get
            Dim ris As Date = DataRif

            If IdMailRif = 0 Then
                Dim risp As List(Of PreventivoMail) = ListaRisposte

                If risp.Count Then
                    ris = risp.Last.DataRif
                End If

                'For Each singmail As PreventivoMail In ListaRisposte
                '    'If singmail.IdUtFormer Then
                '    ris = singmail.DataRif
                '    'End If
                'Next
            End If

            Return ris
        End Get
    End Property

    Private _VoceRubrica As VoceRubrica = Nothing
    Public ReadOnly Property VoceRubrica As VoceRubrica
        Get
            If _VoceRubrica Is Nothing Then
                If IdRub Then
                    _VoceRubrica = New VoceRubrica
                    _VoceRubrica.Read(IdRub)
                End If
            End If
            Return _VoceRubrica
        End Get
    End Property

    Private _ListaRisposte As List(Of PreventivoMail) = Nothing
    Public ReadOnly Property ListaRisposte As List(Of PreventivoMail)
        Get
            If _ListaRisposte Is Nothing Then
                If GuidMail.Length Then
                    Using mgr As New PreventiviMailDAO
                        _ListaRisposte = mgr.FindAll(LFM.PreventivoMail.IdMailPreventivo,
                                                      New LUNA.LunaSearchParameter(LFM.PreventivoMail.GuidMail, GuidMail),
                                                      New LUNA.LunaSearchParameter(LFM.PreventivoMail.IdMailPreventivo, IdMailPreventivo, "<>"),
                                                      New LUNA.LunaSearchParameter(LFM.PreventivoMail.Stato, enStatoPreventivoMail.Eliminata, "<>"))
                        '_ListaRisposte.Sort(Function(x, y) x.DataRif.CompareTo(y.DataRif))
                    End Using
                Else
                    _ListaRisposte = New List(Of PreventivoMail)
                End If

            End If
            Return _ListaRisposte
        End Get
    End Property

    Public ReadOnly Property Allegati(Optional SoloUtilizzabili As Boolean = False) As List(Of AttachPreventivoMail)
        Get
            Dim ris As List(Of AttachPreventivoMail) = Nothing

            Using mgr As New AttachPreventivoMailDAO
                ris = mgr.FindAll(LFM.AttachPreventivoMail.NomeFile,
                                  New LUNA.LunaSearchParameter(LFM.AttachPreventivoMail.IdMailPreventivo, IdMailPreventivo))
            End Using

            If SoloUtilizzabili Then
                ris = ris.FindAll(Function(x) x.NomeFile.ToLower.EndsWith("pdf"))
            End If

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IPreventivoMail.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IPreventivoMail.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IPreventivoMail.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''Interface for table Mailpreventivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPreventivoMail
    Inherits _IPreventivoMail

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface