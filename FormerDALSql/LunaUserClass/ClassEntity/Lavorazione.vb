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
Imports System.Drawing
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerConfig
Imports FormerLib

''' <summary>
'''Entity Class for table T_lavori
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Lavorazione
    Inherits _Lavorazione
    Implements ILavorazione
    Implements ICloneable
    Implements ILavorazioneB
    Implements IVoceComboConImmagine

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Overrides Property IdLavoro() As Integer Implements ILavorazioneB.IdLavoro, IVoceComboConImmagine.Id
        Get
            Return MyBase.IdLavoro
        End Get
        Set(ByVal value As Integer)
            MyBase.IdLavoro = value
        End Set
    End Property

    Public Overrides Property Descrizione() As String Implements ILavorazioneB.Descrizione, IVoceComboConImmagine.Text
        Get
            Return MyBase.Descrizione
        End Get
        Set(ByVal value As String)
            MyBase.Descrizione = value
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

    Public Overrides Property DescrizioneEstesa() As String Implements ILavorazioneB.DescrizioneEstesa, IVoceComboConImmagine.Description
        Get
            Return MyBase.DescrizioneEstesa
        End Get
        Set(ByVal value As String)
            MyBase.DescrizioneEstesa = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Private _Categoria As CatLav = Nothing
    Public ReadOnly Property Categoria As CatLav
        Get
            If _Categoria Is Nothing Then
                _Categoria = New CatLav
                If IdCatLav Then _Categoria.Read(IdCatLav)
            End If
            Return _Categoria
        End Get
    End Property

    Public ReadOnly Property CategoriaLavB As ICategoriaLavB Implements ILavorazioneB.Categoria
        Get
            Return Categoria
        End Get
    End Property

    Public ReadOnly Property ListExtraData As List(Of ExtraData) Implements ILavorazioneB.ListExtraData
        Get
            Return MgrExtraData.GetExtraData(ExtraData)
        End Get
    End Property

    Public ReadOnly Property ExtraDataB As String Implements ILavorazioneB.ExtraData
        Get
            Return ExtraData
        End Get
    End Property

    Public Property Esclusiva As Integer
        Get
            Dim ris As Integer = enSiNo.No
            If SuCommessa Then
                ris = enSiNo.Si
            End If
            Return ris
        End Get
        Set(value As Integer)
            If value = enSiNo.Si Then
                SuCommessa = True
            Else
                SuCommessa = False
            End If
        End Set
    End Property

    Public ReadOnly Property PrezziB As List(Of IPrezzoLavoroB) Implements ILavorazioneB.Prezzi
        Get
            Dim ris As New List(Of IPrezzoLavoroB)
            For Each p As PrezzoLavoro In Prezzi
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


    Private _MacchinarioRif As Macchinario = Nothing
    Public ReadOnly Property MacchinarioRif As Macchinario
        Get
            If _MacchinarioRif Is Nothing Then
                _MacchinarioRif = New Macchinario
                _MacchinarioRif.Read(IdMacchinario)
            End If
            Return _MacchinarioRif
        End Get
    End Property

    Public ReadOnly Property MacchinarioB2 As IMacchinarioB Implements ILavorazioneB.MacchinarioRif2
        Get
            Return MacchinarioRif2
        End Get
    End Property

    Private _MacchinarioRif2 As Macchinario = Nothing
    Public ReadOnly Property MacchinarioRif2 As Macchinario
        Get
            If _MacchinarioRif2 Is Nothing Then
                _MacchinarioRif2 = New Macchinario
                If IdMacchinario2 Then _MacchinarioRif2.Read(IdMacchinario2)
            End If
            Return _MacchinarioRif2
        End Get
    End Property

    Private _Prezzi As List(Of PrezzoLavoro)
    Public Property Prezzi As List(Of PrezzoLavoro)
        Get
            If _Prezzi Is Nothing Then _Prezzi = New List(Of PrezzoLavoro)
            Return _Prezzi
        End Get
        Set(value As List(Of PrezzoLavoro))
            _Prezzi = value
        End Set
    End Property

    Public ReadOnly Property TipoControlloWebStr As String
        Get
            Dim ris As String = String.Empty

            ris = FormerEnumHelper.TipoControlloString(TipoControlloWeb)

            Return ris
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = ""
            ris = _Descrizione
            Select Case _IdTipoLav
                Case enTipoLavorazione.suFacciata
                    ris &= " (Su Facciata)"
                Case enTipoLavorazione.suFoglio
                    ris &= " (Su Foglio)"
                Case enTipoLavorazione.suQuantita
                    ris &= " (Su Quantità)"
                Case enTipoLavorazione.suMetriLineari
                    ris &= " (Su Metri Lineari)"
                Case enTipoLavorazione.suMetriQuadri
                    ris &= " (Su Metri Quadri)"
            End Select

            Return ris
        End Get
    End Property

    Public Property OrdineInListino As Integer = 0

    Public ReadOnly Property ImgRifLocale As String
        Get
            Dim ris As String = String.Empty

            If _ImgRif.Length Then

                ris = FormerPath.PathTempImg & FormerLib.FormerHelper.File.EstraiNomeFile(_ImgRif)

            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property Img As Image Implements IVoceComboConImmagine.Image
        Get
            Dim ris As Image = Nothing
            Dim PathRiferimento As String = _ImgRif
            If PathRiferimento.Length Then

                Dim PathLocaleImg As String = ImgRifLocale

                If File.Exists(PathLocaleImg) Then
                    PathRiferimento = PathLocaleImg
                Else
                    Try
                        Dim imgPreview As Image = Image.FromFile(_ImgRif)

                        imgPreview = FormerThumbnail.GetForImgListino(imgPreview)

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

            If ris Is Nothing Then ris = New Bitmap(My.Resources.no_image, New Size(75, 50))


            Return ris
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


#End Region


#Region "Method"
    Public Sub ApplicaMisureLavtoPrezzi(MisureMin As Size,
                                        MisureMedieMin As Size,
                                        MisureMedieMax As Size,
                                        MisureMax As Size)

        For Each voce In Prezzi
            Dim ris As String = "-"
            If voce.IdFormProd Then
                If (MisureMin.Width <> 0 And MisureMin.Height <> 0) And (voce.FormatoProdotto.Larghezza < MisureMin.Width Or voce.FormatoProdotto.Lunghezza < MisureMin.Height) And
                                    (voce.FormatoProdotto.Larghezza < MisureMin.Height Or voce.FormatoProdotto.Lunghezza < MisureMin.Width) Then
                    ris = "!"
                Else
                    If (MisureMax.Width <> 0 And MisureMax.Height <> 0) And (voce.FormatoProdotto.Larghezza > MisureMax.Width Or voce.FormatoProdotto.Lunghezza > MisureMax.Height) And
                        (voce.FormatoProdotto.Larghezza > MisureMax.Height Or voce.FormatoProdotto.Lunghezza > MisureMax.Width) Then
                        ris = "!"
                    Else
                        'qui vedo in quale entra
                        If (MisureMedieMin.Width <> 0 And MisureMedieMin.Height <> 0) And (voce.FormatoProdotto.Larghezza < MisureMedieMin.Width Or voce.FormatoProdotto.Lunghezza < MisureMedieMin.Height) And
                        (voce.FormatoProdotto.Larghezza < MisureMedieMin.Height Or voce.FormatoProdotto.Lunghezza < MisureMedieMin.Width) Then
                            ris = "PICCOLO"
                        Else
                            If (MisureMedieMax.Width <> 0 And MisureMedieMax.Height <> 0) And (voce.FormatoProdotto.Larghezza < MisureMedieMax.Width Or voce.FormatoProdotto.Lunghezza < MisureMedieMax.Height) And
                       (voce.FormatoProdotto.Larghezza < MisureMedieMax.Height Or voce.FormatoProdotto.Lunghezza < MisureMedieMax.Width) Then
                                ris = "MEDIO"
                            Else
                                If (MisureMedieMax.Width <> 0 And MisureMedieMax.Height <> 0) Then
                                    ris = "GRANDE"
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            voce.EntraInStr = ris
        Next

    End Sub
    Public Function PrevistaSu(IdListinoBase As Integer) As Boolean Implements ILavorazioneB.PrevistaSu

        Dim ris As Boolean = False

        Using mgr As New LavorazSuPreventivazDAO
            Dim l As List(Of LavorazSuPreventivaz) = mgr.FindAll(New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase),
                                                                  New LUNA.LunaSearchParameter("IdLavoro", IdLavoro))
            If l.Count Then ris = True
        End Using

        Return ris

    End Function

    Public Overrides Function IsValid() As Boolean Implements ILavorazione.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        If _Descrizione.Length = 0 Then Ris = False
        If _Macchinario.Length = 0 Then Ris = False
        'If _TempoRif = 0 Then Ris = False
        ' If _SuCommessa = False And _SuProdotto = False Then Ris = False
        If _Sigla.Length = 0 Then Ris = False
        If Prezzi.Count = 0 Then Ris = False
        Return Ris
    End Function

    Public Sub CaricaPrezzi()

        Using mgr As New PrezziLavoroDAO
            Prezzi = mgr.FindAll(New LUNA.LunaSearchParameter("IdLavoro", IdLavoro))
        End Using

    End Sub

    Public Overrides Function Read(Id As Integer) As Integer Implements ILavorazione.Read
        Dim ris As Integer = MyBase.Read(Id)
        'carico i prezzi
        CaricaPrezzi()

        Return ris
    End Function

    Public Overrides Function Save() As Integer Implements ILavorazione.Save
        Dim ris As Integer = MyBase.Save()
        'salvo i prezzi
        'prima li cancello
        Using m As New PrezziLavoroDAO
            m.DeleteByIdLavoro(ris)
        End Using
        For Each P As PrezzoLavoro In Prezzi
            P.IdLavPrezzo = 0
            P.IdLavoro = ris
            P.Save()
        Next

        Return ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class
Public Class LavorazioneInCat

    Public Property LavorazioneStr
    Public Property Importo
    Public Property Indicazioni

End Class

Public Class LavorazioneEx
    Inherits Lavorazione

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub
    Public Property CatLav As String = ""



End Class


''' <summary>
'''Interface for table T_lavori
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ILavorazione
    Inherits _ILavorazione

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface