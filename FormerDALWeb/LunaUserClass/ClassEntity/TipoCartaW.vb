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

''' <summary>
'''Entity Class for table Td_tipocarta
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class TipoCartaW
    Inherits _TipoCartaW
    Implements ITipoCartaW
    Implements ITipoCartaB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdTipoCarta() As Integer Implements ITipoCartaB.IdTipoCarta
        Get
            Return MyBase.IdTipoCarta
        End Get
        Set(ByVal value As Integer)
            MyBase.IdTipoCarta = value
        End Set
    End Property


    Public Overrides Property Tipologia() As String Implements ITipoCartaB.Tipologia
        Get
            Return MyBase.Tipologia
        End Get
        Set(ByVal value As String)
            MyBase.Tipologia = value
        End Set
    End Property


    Public Overrides Property Finitura() As String Implements ITipoCartaB.Finitura
        Get
            Return MyBase.Finitura
        End Get
        Set(ByVal value As String)
            MyBase.Finitura = value
        End Set
    End Property


    Public Overrides Property Grammi() As Integer Implements ITipoCartaB.Grammi
        Get
            Return MyBase.Grammi
        End Get
        Set(ByVal value As Integer)
            MyBase.Grammi = value
        End Set
    End Property


    Public Overrides Property ImgRif() As String Implements ITipoCartaB.ImgRif
        Get
            Return MyBase.ImgRif
        End Get
        Set(ByVal value As String)
            MyBase.ImgRif = value
        End Set
    End Property


    Public Overrides Property Sigla() As String Implements ITipoCartaB.Sigla
        Get
            Return MyBase.Sigla
        End Get
        Set(ByVal value As String)
            MyBase.Sigla = value
        End Set
    End Property


    Public Overrides Property CostoCartaKg() As Decimal Implements ITipoCartaB.CostoCartaKg
        Get
            Return MyBase.CostoCartaKg
        End Get
        Set(ByVal value As Decimal)
            MyBase.CostoCartaKg = value
        End Set
    End Property


    Public Overrides Property Spessore() As Single Implements ITipoCartaB.Spessore
        Get
            Return MyBase.Spessore
        End Get
        Set(ByVal value As Single)
            MyBase.Spessore = value
        End Set
    End Property


    Public Overrides Property TipoCarta() As Integer Implements ITipoCartaB.TipoCarta
        Get
            Return MyBase.TipoCarta
        End Get
        Set(ByVal value As Integer)
            MyBase.TipoCarta = value
        End Set
    End Property


    Public Overrides Property DescrizioneEstesa() As String Implements ITipoCartaB.DescrizioneEstesa
        Get
            Return MyBase.DescrizioneEstesa
        End Get
        Set(ByVal value As String)
            MyBase.DescrizioneEstesa = value
        End Set
    End Property


    Public Overrides Property TipoCosto() As Integer Implements ITipoCartaB.TipoCosto
        Get
            Return MyBase.TipoCosto
        End Get
        Set(ByVal value As Integer)
            MyBase.TipoCosto = value
        End Set
    End Property


    Public Overrides Property CostoRiferimento() As Decimal Implements ITipoCartaB.CostoRiferimento
        Get
            Return MyBase.CostoRiferimento
        End Get
        Set(ByVal value As Decimal)
            MyBase.CostoRiferimento = value
        End Set
    End Property


#End Region


#Region "Logic Field"

    Public ReadOnly Property ComposizioniCartaB As IEnumerable(Of IComposizioneCartaB) Implements ITipoCartaB.ComposizioniCarta
        Get
            Return ComposizioniCarta
        End Get
    End Property


    Public ReadOnly Property RiassuntoCarrello As String
        Get
            Dim ris As String = Tipologia

            If ris.Length > 27 Then ris = ris.Substring(0, 27) & "..."

            'ris &= Grammi
            Return ris
        End Get
    End Property

    Public ReadOnly Property NomeInUrl() As String
        Get
            Dim descr As String = _Finitura & "+" & _Grammi & "gr"
            Dim _NomeInUrl As String = FormerHelper.Web.NormalizzaUrl(descr)
            Return _NomeInUrl
        End Get
    End Property

    Public ReadOnly Property DescrizioneEstesaEx As String
        Get
            Dim ris As String = "Nessuna ulteriore descrizione della carta disponibile"
            If DescrizioneEstesa.Length Then ris = DescrizioneEstesa
            Return ris
        End Get
    End Property
    Public ReadOnly Property DescrizioneHTML As String
        Get
            Return DescrizioneEstesaEx.Replace(vbNewLine, "<br />")
        End Get
    End Property
#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ITipoCartaW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ITipoCartaW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        CaricaComposizioni()
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ITipoCartaW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Private Sub CaricaComposizioni()
        Using Mgr As New ComposizioneCartaWDAO
            _ComposizioniCarta = Mgr.FindAll("NumFogli Desc", New LUNA.LunaSearchParameter("IdCartaPadre", IdTipoCarta))
        End Using

    End Sub

    Public Sub CaricaComposizioniCarta()
        CaricaComposizioni()
    End Sub


    Private _ComposizioniCarta As List(Of ComposizioneCartaW)
    Public Property ComposizioniCarta As List(Of ComposizioneCartaW)
        Get
            If _ComposizioniCarta Is Nothing Then
                'la carico
                CaricaComposizioni()
            End If
            Return _ComposizioniCarta
        End Get
        Set(value As List(Of ComposizioneCartaW))
            _ComposizioniCarta = value
        End Set
    End Property

    Public Function CalcolaSpessoreCM(Qta As Integer) As Single

        Dim ris As Single = 1

        If Spessore Then
            'formula = MICRON * QTA / 1000
            ris = Spessore * Qta / 10000
        End If

        Return ris

    End Function
#End Region

End Class



''' <summary>
'''Interface for table Td_tipocarta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITipoCartaW
    Inherits _ITipoCartaW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface