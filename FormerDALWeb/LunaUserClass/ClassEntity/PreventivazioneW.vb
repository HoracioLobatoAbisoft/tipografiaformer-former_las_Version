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
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table T_preventivazione
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class PreventivazioneW
    Inherits _PreventivazioneW
    Implements IPreventivazioneW
    Implements IPreventivazioneB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Overrides Property IdPrev As Integer Implements IPreventivazioneB.IdPrev
        Get
            Return MyBase.IdPrev
        End Get
        Set(value As Integer)
            MyBase.IdPrev = value
        End Set
    End Property

    Public Overrides Property Prefisso As String Implements IPreventivazioneB.Prefisso
        Get
            Return MyBase.Prefisso
        End Get
        Set(value As String)
            MyBase.Prefisso = value
        End Set
    End Property

    Public Overrides Property TipoProd As Integer Implements IPreventivazioneB.TipoProd
        Get
            Return MyBase.TipoProd
        End Get
        Set(value As Integer)
            MyBase.TipoProd = value
        End Set
    End Property

    Public Overrides Property Descrizione As String Implements IPreventivazioneB.Descrizione
        Get
            Return MyBase.Descrizione
        End Get
        Set(value As String)
            MyBase.Descrizione = value
        End Set
    End Property

    Public Overrides Property DescrizioneEstesa As String Implements IPreventivazioneB.DescrizioneEstesa
        Get
            Return MyBase.DescrizioneEstesa
        End Get
        Set(value As String)
            MyBase.DescrizioneEstesa = value
        End Set
    End Property

    Public Overrides Property ggFast As Integer Implements IPreventivazioneB.ggFast
        Get
            Return MyBase.ggFast
        End Get
        Set(value As Integer)
            MyBase.ggFast = value
        End Set
    End Property

    Public Overrides Property ggNorm As Integer Implements IPreventivazioneB.ggNorm
        Get
            Return MyBase.ggNorm
        End Get
        Set(value As Integer)
            MyBase.ggNorm = value
        End Set
    End Property

    Public Overrides Property ggSlow As Integer Implements IPreventivazioneB.ggSlow
        Get
            Return MyBase.ggSlow
        End Get
        Set(value As Integer)
            MyBase.ggSlow = value
        End Set
    End Property

    Public Overrides Property RicaricoPubblico As Integer Implements IPreventivazioneB.RicaricoPubblico
        Get
            Return MyBase.RicaricoPubblico
        End Get
        Set(value As Integer)
            MyBase.RicaricoPubblico = value
        End Set
    End Property

    Public Overrides Property GraficaPerFacciata As Decimal Implements IPreventivazioneB.GraficaPerFacciata
        Get
            Return MyBase.GraficaPerFacciata
        End Get
        Set(value As Decimal)
            MyBase.GraficaPerFacciata = value
        End Set
    End Property

    Public Overrides Property ImgRif As String Implements IPreventivazioneB.ImgRif
        Get
            Return MyBase.ImgRif
        End Get
        Set(value As String)
            MyBase.ImgRif = value
        End Set
    End Property

    Public Overrides Property ImgSito As String Implements IPreventivazioneB.ImgSito
        Get
            Return MyBase.ImgSito
        End Get
        Set(value As String)
            MyBase.ImgSito = value
        End Set
    End Property

    Public Overrides Property UrlVideo As String Implements IPreventivazioneB.UrlVideo
        Get
            Return MyBase.UrlVideo
        End Get
        Set(value As String)
            MyBase.UrlVideo = value
        End Set
    End Property

    Public Overrides Property IdReparto As Integer Implements IPreventivazioneB.IdReparto
        Get
            Return MyBase.IdReparto
        End Get
        Set(value As Integer)
            MyBase.IdReparto = value
        End Set
    End Property

    Public Overrides Property DispOnline As Boolean Implements IPreventivazioneB.DispOnline
        Get
            Return MyBase.DispOnline
        End Get
        Set(value As Boolean)
            MyBase.DispOnline = value
        End Set
    End Property


    Public Overrides Property IdFunzionePack() As Integer Implements IPreventivazioneB.IdFunzionePack
        Get
            Return MyBase.IdFunzionePack
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFunzionePack = value
        End Set
    End Property

    Public Overrides Property Linguetta() As Integer Implements IPreventivazioneB.Linguetta
        Get
            Return MyBase.Linguetta
        End Get
        Set(ByVal value As Integer)
            MyBase.Linguetta = value
        End Set
    End Property

    Public Overrides Property PercFast As Integer Implements IPreventivazioneB.PercFast
        Get
            Return MyBase.PercFast
        End Get
        Set(value As Integer)
            MyBase.PercFast = value
        End Set
    End Property

    Public Overrides Property PercSlow As Integer Implements IPreventivazioneB.PercSlow
        Get
            Return MyBase.PercSlow
        End Get
        Set(value As Integer)
            MyBase.PercSlow = value
        End Set
    End Property

#End Region


#Region "Logic Field"

    Public Function GetImgMisure() As String
        Dim ris As String = "/img/packagingmisure.png"

        If IdFunzionePack = enFunzionePackaging.FunzioneECMA3 Then
            ris = "/img/packagingmisureCuscino.png"
        End If

        Return ris
    End Function

    Public Overrides Property IdPluginToUse() As Integer Implements IPreventivazioneB.IdPluginToUse
        Get
            Return MyBase.IdPluginToUse
        End Get
        Set(ByVal value As Integer)
            MyBase.IdPluginToUse = value
        End Set
    End Property

    Private _FirstLB As ListinoBaseW = Nothing
    Public Function GetFirstLb() As ListinoBaseW

        If _FirstLB Is Nothing Then
            Dim LInt As List(Of ListinoBaseW) = GetListiniBase()

            If LInt.Count Then
                _FirstLB = LInt(0)

            End If
        End If

        Return _FirstLB

    End Function

    Private _FormerChoice As ListinoBaseW = Nothing
    Public ReadOnly Property FormerChoice As ListinoBaseW
        Get
            If _FormerChoice Is Nothing Then
                _FormerChoice = GetListiniBase.Find(Function(x) x.IsFormerChoice = enSiNo.Si)
            End If

            Return _FormerChoice
        End Get
    End Property

    Public ReadOnly Property NomeInUrl() As String
        Get
            Dim Prefisso As String = "Stampa-"

            If IdReparto = enRepartoWeb.Ricamo Then
                Prefisso = "Ricamo-"
            End If

            Dim _NomeInUrl As String = Prefisso & (FormerHelper.Web.NormalizzaUrl(_Descrizione))
            Return _NomeInUrl
        End Get
    End Property
    Public ReadOnly Property DescrizioneHTML As String
        Get
            Return DescrizioneEstesa.Replace(vbNewLine, "<br />")
        End Get
    End Property

    Public ReadOnly Property Aggiornata As Boolean
        Get
            Dim ris As Boolean = False

            For Each L As ListinoBaseW In GetListiniBase()

                If L.LastUpdate = 1 Then
                    ris = True
                    Exit For
                End If

            Next

            Return ris
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Return RepartoStr & " - " & Descrizione
        End Get
    End Property

    Public ReadOnly Property RiassuntoInvertito As String
        Get
            Return Descrizione & " - " & RepartoStr
        End Get
    End Property

    Public ReadOnly Property RepartoStr As String
        Get

            Return FormerEnum.FormerEnumHelper.RepartoStr(IdReparto)

        End Get
    End Property

#End Region

#Region "Method"

    Public ReadOnly Property ListiniBaseB As List(Of IListinoBaseB) Implements IPreventivazioneB.ListiniBase
        Get

            Dim l As New List(Of IListinoBaseB)

            For Each singLB As ListinoBaseW In GetListiniBase()
                l.Add(singLB)
            Next
            Return l
        End Get
    End Property


    Public Overrides Function IsValid() As Boolean Implements IPreventivazioneW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IPreventivazioneW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IPreventivazioneW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Private _ListiniBase As List(Of ListinoBaseW) = Nothing
    Public Function GetListiniBase() As List(Of ListinoBaseW)
        If _ListiniBase Is Nothing Then
            Using mgr As New ListinoBaseWDAO
                _ListiniBase = mgr.ListiniInPreventivazioneOrdinati(_IdPrev)
            End Using
        End If

        Return _ListiniBase

        'Dim ris As List(Of ListinoBaseW)

        ''Dim lp As New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _IdPrev)

        ''Using mgr As New ListinoBaseWDAO
        ''    ris = mgr.FindAll(LFM.ListinoBaseW.Nome,
        ''                      lp,
        ''                      New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.No))

        ''End Using

        '''li ordino per grandezza
        ''Using P As New PreventivazioniWDAO
        ''    P.OrdinaListinoPerFormatoProd(ris)
        ''End Using

        'Using mgr As New ListinoBaseWDAO
        '    ris = mgr.ListiniInPreventivazioneOrdinati(_IdPrev)
        'End Using

        'Return ris
    End Function

    Private _ListiniBaseLinkati As List(Of ListinoBaseW) = Nothing
    Public Function GetListiniBaseLinkati() As List(Of ListinoBaseW)

        If _ListiniBaseLinkati Is Nothing Then
            Using mgr As New ListinoBaseWDAO

                _ListiniBaseLinkati = mgr.ListiniLinkatiAPreventivazione(IdPrev)

            End Using
        End If

        Return _ListiniBaseLinkati

    End Function



    'Public Function GetFormatiProddotto() As List(Of FormatoProdottoW)
    '    Dim ris As List(Of FormatoProdottoW)

    '    Dim lp As New LUNA.LunaSearchParameter("IdPrev", _IdPrev)

    '    Dim ls As New LUNA.LunaSearchOption
    '    ls.OrderBy = "Nome"
    '    Using mgr As New ListinoBaseWDAO
    '        ris = mgr.FindAll(ls, lp)
    '    End Using



    '    Return ris
    'End Function
#End Region


End Class



''' <summary>
'''Interface for table T_preventivazione
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPreventivazioneW
    Inherits _IPreventivazioneW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface