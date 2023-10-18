#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 27/12/2019 
#End Region




Imports FormerLib
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table F24
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class F24
    Inherits _F24
    Implements IF24

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdF24() As Integer
        Get
            Return MyBase.IdF24
        End Get
        Set(ByVal value As Integer)
            MyBase.IdF24 = value
        End Set
    End Property


    Public Overrides Property Descrizione() As String
        Get
            Return MyBase.Descrizione
        End Get
        Set(ByVal value As String)
            MyBase.Descrizione = value
        End Set
    End Property


    Public Overrides Property IdAzienda() As Integer
        Get
            Return MyBase.IdAzienda
        End Get
        Set(ByVal value As Integer)
            MyBase.IdAzienda = value
        End Set
    End Property


    Public Overrides Property InseritoIl() As DateTime
        Get
            Return MyBase.InseritoIl
        End Get
        Set(ByVal value As DateTime)
            MyBase.InseritoIl = value
        End Set
    End Property


    Public Overrides Property NotePagamento() As String
        Get
            Return MyBase.NotePagamento
        End Get
        Set(ByVal value As String)
            MyBase.NotePagamento = value
        End Set
    End Property


    Public Overrides Property PagatoIl() As DateTime
        Get
            Return MyBase.PagatoIl
        End Get
        Set(ByVal value As DateTime)
            MyBase.PagatoIl = value
        End Set
    End Property


    Public Overrides Property Totale() As Decimal
        Get
            Return MyBase.Totale
        End Get
        Set(ByVal value As Decimal)
            MyBase.Totale = value
        End Set
    End Property


#End Region

#Region "Logic Field"
    Public ReadOnly Property SezioneErario As List(Of F24Dettaglio)
        Get
            Dim ris As List(Of F24Dettaglio) = Nothing

            Using mgr As New F24DettaglioDAO
                ris = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = LFM.F24Dettaglio.IdF24Dett.Name},
                                  New LUNA.LunaSearchParameter(LFM.F24Dettaglio.IdF24, IdF24),
                                  New LUNA.LunaSearchParameter(LFM.F24Dettaglio.IdSezione, enSezioneF24.Erario))
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property SezioneInps As List(Of F24Dettaglio)
        Get
            Dim ris As List(Of F24Dettaglio) = Nothing

            Using mgr As New F24DettaglioDAO
                ris = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = LFM.F24Dettaglio.IdF24Dett.Name},
                                  New LUNA.LunaSearchParameter(LFM.F24Dettaglio.IdF24, IdF24),
                                  New LUNA.LunaSearchParameter(LFM.F24Dettaglio.IdSezione, enSezioneF24.Inps))
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property SezioneAltriEnti As List(Of F24Dettaglio)
        Get
            Dim ris As List(Of F24Dettaglio) = Nothing

            Using mgr As New F24DettaglioDAO
                ris = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = LFM.F24Dettaglio.IdF24Dett.Name},
                                  New LUNA.LunaSearchParameter(LFM.F24Dettaglio.IdF24, IdF24),
                                  New LUNA.LunaSearchParameter(LFM.F24Dettaglio.IdSezione, enSezioneF24.AltriEnti))
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property SezioneRegioni As List(Of F24Dettaglio)
        Get
            Dim ris As List(Of F24Dettaglio) = Nothing

            Using mgr As New F24DettaglioDAO
                ris = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = LFM.F24Dettaglio.IdF24Dett.Name},
                                  New LUNA.LunaSearchParameter(LFM.F24Dettaglio.IdF24, IdF24),
                                  New LUNA.LunaSearchParameter(LFM.F24Dettaglio.IdSezione, enSezioneF24.Regioni))
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property SezioneImu As List(Of F24Dettaglio)
        Get
            Dim ris As List(Of F24Dettaglio) = Nothing

            Using mgr As New F24DettaglioDAO
                ris = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = LFM.F24Dettaglio.IdF24Dett.Name},
                                  New LUNA.LunaSearchParameter(LFM.F24Dettaglio.IdF24, IdF24),
                                  New LUNA.LunaSearchParameter(LFM.F24Dettaglio.IdSezione, enSezioneF24.Imu))
            End Using

            Return ris
        End Get
    End Property

    Public ReadOnly Property AziendaStr As String
        Get
            Return MgrAziende.GetSiglaStr(IdAzienda)
        End Get
    End Property

    Public ReadOnly Property InseritoIlStr As String
        Get
            Return InseritoIl.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property PagatoIlStr As String
        Get
            Dim ris As String = "-"
            If PagatoIl <> Date.MinValue Then
                ris = PagatoIl.ToString("dd/MM/yyyy")
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property ImportoStr As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Totale)
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IF24.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IF24.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IF24.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''Interface for table F24
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IF24
    Inherits _IF24

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface