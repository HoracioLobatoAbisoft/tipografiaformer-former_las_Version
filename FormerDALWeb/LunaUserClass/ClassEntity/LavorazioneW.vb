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
Imports FormerBusinessLogicInterface
Imports FormerLib

''' <summary>
'''Entity Class for table T_lavori
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class LavorazioneW
    Inherits _LavorazioneW
    Implements ILavorazioneW
    Implements ICloneable
    Implements ILavorazioneB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"
    Public Overrides Property IdLavoro() As Integer Implements ILavorazioneB.IdLavoro
        Get
            Return MyBase.IdLavoro
        End Get
        Set(ByVal value As Integer)
            MyBase.IdLavoro = value
        End Set
    End Property

    Public Overrides Property Descrizione() As String Implements ILavorazioneB.Descrizione
        Get
            Return MyBase.Descrizione
        End Get
        Set(ByVal value As String)
            MyBase.Descrizione = value
        End Set
    End Property

    Public Overrides Property IdMacchinario2() As Integer Implements ILavorazioneB.IdMacchinario2
        Get
            Return MyBase.IdMacchinario2
        End Get
        Set(ByVal value As Integer)
            MyBase.IdMacchinario2 = value
        End Set
    End Property

    Public Overrides Property SePresenteCalcolaSuSoggetti() As Integer Implements ILavorazioneB.SePresenteCalcolaSuSoggetti
        Get
            Return MyBase.SePresenteCalcolaSuSoggetti
        End Get
        Set(ByVal value As Integer)
            MyBase.SePresenteCalcolaSuSoggetti = value
        End Set
    End Property

    Public Overrides Property TempoRif() As Integer Implements ILavorazioneB.TempoRif
        Get
            Return MyBase.TempoRif
        End Get
        Set(ByVal value As Integer)
            MyBase.TempoRif = value
        End Set
    End Property


    Public Overrides Property Premio() As Decimal Implements ILavorazioneB.Premio
        Get
            Return MyBase.Premio
        End Get
        Set(ByVal value As Decimal)
            MyBase.Premio = value
        End Set
    End Property


    Public Overrides Property SuCommessa() As Boolean Implements ILavorazioneB.SuCommessa
        Get
            Return MyBase.SuCommessa
        End Get
        Set(ByVal value As Boolean)
            MyBase.SuCommessa = value
        End Set
    End Property


    Public Overrides Property SuProdotto() As Boolean Implements ILavorazioneB.SuProdotto
        Get
            Return MyBase.SuProdotto
        End Get
        Set(ByVal value As Boolean)
            MyBase.SuProdotto = value
        End Set
    End Property


    Public Overrides Property Stato() As Integer Implements ILavorazioneB.Stato
        Get
            Return MyBase.Stato
        End Get
        Set(ByVal value As Integer)
            MyBase.Stato = value
        End Set
    End Property


    Public Overrides Property Macchinario() As String Implements ILavorazioneB.Macchinario
        Get
            Return MyBase.Macchinario
        End Get
        Set(ByVal value As String)
            MyBase.Macchinario = value
        End Set
    End Property


    Public Overrides Property Pubblica() As Boolean Implements ILavorazioneB.Pubblica
        Get
            Return MyBase.Pubblica
        End Get
        Set(ByVal value As Boolean)
            MyBase.Pubblica = value
        End Set
    End Property


    Public Overrides Property Prezzo() As Decimal Implements ILavorazioneB.Prezzo
        Get
            Return MyBase.Prezzo
        End Get
        Set(ByVal value As Decimal)
            MyBase.Prezzo = value
        End Set
    End Property


    Public Overrides Property IdCatLav() As Integer Implements ILavorazioneB.IdCatLav
        Get
            Return MyBase.IdCatLav
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCatLav = value
        End Set
    End Property


    Public Overrides Property ImgRif() As String Implements ILavorazioneB.ImgRif
        Get
            Return MyBase.ImgRif
        End Get
        Set(ByVal value As String)
            MyBase.ImgRif = value
        End Set
    End Property


    Public Overrides Property Sigla() As String Implements ILavorazioneB.Sigla
        Get
            Return MyBase.Sigla
        End Get
        Set(ByVal value As String)
            MyBase.Sigla = value
        End Set
    End Property


    Public Overrides Property FormatoRiferimento() As String Implements ILavorazioneB.FormatoRiferimento
        Get
            Return MyBase.FormatoRiferimento
        End Get
        Set(ByVal value As String)
            MyBase.FormatoRiferimento = value
        End Set
    End Property


    Public Overrides Property IdMacchinario() As Integer Implements ILavorazioneB.IdMacchinario
        Get
            Return MyBase.IdMacchinario
        End Get
        Set(ByVal value As Integer)
            MyBase.IdMacchinario = value
        End Set
    End Property


    Public Overrides Property CostoSingCopia() As Decimal Implements ILavorazioneB.CostoSingCopia
        Get
            Return MyBase.CostoSingCopia
        End Get
        Set(ByVal value As Decimal)
            MyBase.CostoSingCopia = value
        End Set
    End Property


    Public Overrides Property IdTipoLav() As Integer Implements ILavorazioneB.IdTipoLav
        Get
            Return MyBase.IdTipoLav
        End Get
        Set(ByVal value As Integer)
            MyBase.IdTipoLav = value
        End Set
    End Property


    Public Overrides Property GrammiMin() As Integer Implements ILavorazioneB.GrammiMin
        Get
            Return MyBase.GrammiMin
        End Get
        Set(ByVal value As Integer)
            MyBase.GrammiMin = value
        End Set
    End Property


    Public Overrides Property GrammiMax() As Integer Implements ILavorazioneB.GrammiMax
        Get
            Return MyBase.GrammiMax
        End Get
        Set(ByVal value As Integer)
            MyBase.GrammiMax = value
        End Set
    End Property

    Public Overrides Property ggRealiz() As Integer Implements ILavorazioneB.ggRealiz
        Get
            Return MyBase.ggRealiz
        End Get
        Set(ByVal value As Integer)
            MyBase.ggRealiz = value
        End Set
    End Property

    Public Overrides Property DescrizioneEstesa() As String Implements ILavorazioneB.DescrizioneEstesa
        Get
            Return MyBase.DescrizioneEstesa
        End Get
        Set(ByVal value As String)
            MyBase.DescrizioneEstesa = value
        End Set
    End Property

    Public ReadOnly Property PrezziB As List(Of IPrezzoLavoroB) Implements ILavorazioneB.Prezzi
        Get
            Dim ris As New List(Of IPrezzoLavoroB)
            For Each p As PrezzoLavoroW In Prezzi
                ris.Add(p)
            Next
            Return ris
        End Get
    End Property

    Public ReadOnly Property MacchinarioB As IMacchinarioB Implements ILavorazioneB.MacchinarioRif
        Get
            Return MacchinarioRif
        End Get
    End Property

    Public ReadOnly Property MacchinarioB2 As IMacchinarioB Implements ILavorazioneB.MacchinarioRif2
        Get
            Return MacchinarioRif2
        End Get
    End Property

    Private _MacchinarioRif2 As MacchinarioW = Nothing
    Public ReadOnly Property MacchinarioRif2 As MacchinarioW
        Get
            If _MacchinarioRif2 Is Nothing Then
                _MacchinarioRif2 = New MacchinarioW
                If IdMacchinario2 Then _MacchinarioRif2.Read(IdMacchinario2)
            End If
            Return _MacchinarioRif2
        End Get
    End Property


    Private Property ILavorazioneB_DimensMaxH As Integer Implements ILavorazioneB.DimensMaxH
        Get
            Return DimensMaxH
        End Get
        Set(value As Integer)
            DimensMaxH = value
        End Set
    End Property

    Private Property ILavorazioneB_DimensMaxW As Integer Implements ILavorazioneB.DimensMaxW
        Get
            Return DimensMaxW
        End Get
        Set(value As Integer)
            DimensMaxW = value
        End Set
    End Property

    Private Property ILavorazioneB_DimensMedieMaxH As Integer Implements ILavorazioneB.DimensMedieMaxH
        Get
            Return DimensMedieMaxH
        End Get
        Set(value As Integer)
            DimensMedieMaxH = value
        End Set
    End Property

    Private Property ILavorazioneB_DimensMedieMaxW As Integer Implements ILavorazioneB.DimensMedieMaxW
        Get
            Return DimensMedieMaxW
        End Get
        Set(value As Integer)
            DimensMedieMaxW = value
        End Set
    End Property

    Private Property ILavorazioneB_DimensMedieMinH As Integer Implements ILavorazioneB.DimensMedieMinH
        Get
            Return DimensMedieMinH
        End Get
        Set(value As Integer)
            DimensMedieMinH = value
        End Set
    End Property

    Private Property ILavorazioneB_DimensMedieMinW As Integer Implements ILavorazioneB.DimensMedieMinW
        Get
            Return DimensMedieMinW
        End Get
        Set(value As Integer)
            DimensMedieMinW = value
        End Set
    End Property

    Private Property ILavorazioneB_DimensMinH As Integer Implements ILavorazioneB.DimensMinH
        Get
            Return DimensMinH
        End Get
        Set(value As Integer)
            DimensMinH = value
        End Set
    End Property

    Private Property ILavorazioneB_DimensMinW As Integer Implements ILavorazioneB.DimensMinW
        Get
            Return DimensMinW
        End Get
        Set(value As Integer)
            DimensMinW = value
        End Set
    End Property

    Private _MacchinarioRif As MacchinarioW = Nothing
    Public ReadOnly Property MacchinarioRif As MacchinarioW
        Get
            If _MacchinarioRif Is Nothing Then
                _MacchinarioRif = New MacchinarioW
                _MacchinarioRif.Read(IdMacchinario)
            End If
            Return _MacchinarioRif
        End Get
    End Property

#End Region


#Region "Logic Field"

    Public ReadOnly Property ListExtraData As List(Of ExtraData) Implements ILavorazioneB.ListExtraData
        Get
            Return MgrExtraData.GetExtraData(ExtraData)
        End Get
    End Property

    Private _CatLav As CatLavW = Nothing
    Public ReadOnly Property CatLav As CatLavW
        Get
            If _CatLav Is Nothing Then
                _CatLav = New CatLavW
                If IdCatLav Then
                    _CatLav.Read(IdCatLav)
                Else
                    _CatLav.Descrizione = "Lavorazioni Opzionali"
                End If
            End If
            Return _CatLav
        End Get
    End Property

    Public ReadOnly Property CategoriaLavB As ICategoriaLavB Implements ILavorazioneB.Categoria
        Get
            Return CatLav
        End Get
    End Property

    Private _DescrizioneCat As String = String.Empty
    Public ReadOnly Property DescrizioneCat As String
        Get
            If _DescrizioneCat.Length Then
                _Descrizione = CatLav.Descrizione
            End If
            Return _DescrizioneCat
        End Get
    End Property

    Public ReadOnly Property DescrizioneEstesaEx As String
        Get
            Dim ris As String = "Nessuna ulteriore descrizione della lavorazione disponibile"
            If DescrizioneEstesa.Length Then ris = DescrizioneEstesa
            Return ris
        End Get
    End Property

    Private _Prezzi As List(Of PrezzoLavoroW)
    Public Property Prezzi As List(Of PrezzoLavoroW)
        Get
            If _Prezzi Is Nothing Then _Prezzi = New List(Of PrezzoLavoroW)
            Return _Prezzi
        End Get
        Set(value As List(Of PrezzoLavoroW))
            _Prezzi = value
        End Set
    End Property

    Public Property Selezionata As Boolean = False

    Public ReadOnly Property ExtraDataB As String Implements ILavorazioneB.ExtraData
        Get
            Return ExtraData
        End Get
    End Property

#End Region

#Region "Method"

    Public Function PrevistaSu(IdListinoBase As Integer) As Boolean Implements ILavorazioneB.PrevistaSu

        Dim ris As Boolean = False

        Using mgr As New LavorazSuPreventivazWDAO
            Dim l As List(Of LavorazSuPreventivazW) = mgr.FindAll(New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase),
                                                                  New LUNA.LunaSearchParameter("IdLavoro", IdLavoro))
            If l.Count Then ris = True
        End Using

        Return ris

    End Function

    Public Overrides Function IsValid() As Boolean Implements ILavorazioneW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Sub CaricaPrezzi()
        Using mgr As New PrezziLavoroWDAO
            Prezzi = mgr.FindAll(New LUNA.LunaSearchParameter("IdLavoro", IdLavoro))
        End Using
    End Sub

    Public Overrides Function Read(Id As Integer) As Integer Implements ILavorazioneW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        CaricaPrezzi()
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ILavorazioneW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class



''' <summary>
'''Interface for table T_lavori
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ILavorazioneW
    Inherits _ILavorazioneW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface