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
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
''' <summary>
'''Entity Class for table Td_formatoprodotto
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class FormatoProdottoW
    Inherits _FormatoProdottoW
    Implements IFormatoProdottoW
    Implements IFormatoProdottoB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdFormProd() As Integer Implements IFormatoProdottoB.IdFormProd
        Get
            Return MyBase.IdFormProd
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFormProd = value
        End Set
    End Property


    Public Overrides Property Formato() As String Implements IFormatoProdottoB.Formato
        Get
            Return MyBase.Formato
        End Get
        Set(ByVal value As String)
            MyBase.Formato = value
        End Set
    End Property


    Public Overrides Property ImgRif() As String Implements IFormatoProdottoB.ImgRif
        Get
            Return MyBase.ImgRif
        End Get
        Set(ByVal value As String)
            MyBase.ImgRif = value
        End Set
    End Property


    Public Overrides Property Orientamento() As Integer Implements IFormatoProdottoB.Orientamento
        Get
            Return MyBase.Orientamento
        End Get
        Set(ByVal value As Integer)
            MyBase.Orientamento = value
        End Set
    End Property


    Public Overrides Property Sigla() As String Implements IFormatoProdottoB.Sigla
        Get
            Return MyBase.Sigla
        End Get
        Set(ByVal value As String)
            MyBase.Sigla = value
        End Set
    End Property


    Public Overrides Property IdFormCarta() As Integer Implements IFormatoProdottoB.IdFormCarta
        Get
            Return MyBase.IdFormCarta
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFormCarta = value
        End Set
    End Property


    Public Overrides Property numfacc() As Integer Implements IFormatoProdottoB.numfacc
        Get
            Return MyBase.numfacc
        End Get
        Set(ByVal value As Integer)
            MyBase.numfacc = value
        End Set
    End Property


    Public Overrides Property DescrizioneEstesa() As String Implements IFormatoProdottoB.DescrizioneEstesa
        Get
            Return MyBase.DescrizioneEstesa
        End Get
        Set(ByVal value As String)
            MyBase.DescrizioneEstesa = value
        End Set
    End Property


    Public Overrides Property PdfTemplate() As String Implements IFormatoProdottoB.PdfTemplate
        Get
            Return MyBase.PdfTemplate
        End Get
        Set(ByVal value As String)
            MyBase.PdfTemplate = value
        End Set
    End Property


    Public Overrides Property ProdottoFinito() As Boolean Implements IFormatoProdottoB.ProdottoFinito
        Get
            Return MyBase.ProdottoFinito
        End Get
        Set(ByVal value As Boolean)
            MyBase.ProdottoFinito = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public ReadOnly Property LarghezzaCm As Single
        Get
            Dim Ris As Single = 1
            Ris = Larghezza / 10
            Return Ris
        End Get
    End Property

    Public ReadOnly Property LunghezzaCm As Single
        Get
            Dim Ris As Single = 1
            Ris = Lunghezza / 10
            Return Ris
        End Get
    End Property

    Public ReadOnly Property OrientamentoStr As String
        Get
            Dim ris As String = String.Empty
            If _Orientamento = enTipoOrientamento.Orizzontale Then
                ris = "Orizzontale"
            Else
                ris = "Verticale"
            End If
            Return ris
        End Get
    End Property

    Private _Fc As FormatoCartaW = Nothing
    Public ReadOnly Property Fc As FormatoCartaW
        Get
            If _Fc Is Nothing Then
                _Fc = New FormatoCartaW
                If IdFormCarta Then
                    _Fc.Read(IdFormCarta)
                End If
            End If
            Return _Fc
        End Get
    End Property

    Public ReadOnly Property AreaCmQuadrati As Single
        Get
            Dim Area As Single = 0
            Area = Fc.Larghezza * Fc.Altezza
            Return Area
        End Get
    End Property

    Private _FormatoCartaStr As String = String.Empty
    Public ReadOnly Property FormatoCartaStr As String
        Get
            If _FormatoCartaStr.Length = 0 Then
                _FormatoCartaStr = Fc.FormatoCarta
            End If
            Return _FormatoCartaStr
        End Get
    End Property

    Private _DimensioniCartaStr As String = String.Empty
    Public ReadOnly Property DimensioniCartaStr As String
        Get
            If _DimensioniCartaStr.Length = 0 Then
                _FormatoCartaStr = Fc.FormatoCarta
                _DimensioniCartaStr = "Alt.: " & Fc.Altezza & "mm; Larg.: " & Fc.Larghezza & "mm"
            End If
            Return _DimensioniCartaStr
        End Get
    End Property

    Public ReadOnly Property NomeInUrl() As String
        Get
            Dim _NomeInUrl As String = (FormerHelper.Web.NormalizzaUrl(FormatoCartaStr))
            Return _NomeInUrl
        End Get
    End Property

    Public ReadOnly Property DescrizioneHTML As String
        Get
            Return DescrizioneEstesa.Replace(vbNewLine, "<br />")
        End Get
    End Property

    Public ReadOnly Property NomeAlberoRif As String
        Get
            Dim ris As String = NomeAlbero
            If ris.Length = 0 Then
                ris = Formato
            End If
            Return ris
        End Get
    End Property

    'PROPRIETA CHE MI SERVE PER ORDINARLO IN BASE AL LISTINO BASE IN CUI è CONTENUTO PER UNA DETERMINATA PREVENTIVAZIONE
    Public Property OrdinamentoByListinoBase As Integer

#End Region

    Private Property LarghezzaB As Integer Implements IFormatoProdottoB.Larghezza
        Get
            Return Larghezza
        End Get
        Set(value As Integer)
            Larghezza = value
        End Set
    End Property

    Private Property LunghezzaB As Integer Implements IFormatoProdottoB.Lunghezza
        Get
            Return Lunghezza
        End Get
        Set(value As Integer)
            Lunghezza = value
        End Set
    End Property

    Private Property IsLastraB As Integer Implements IFormatoProdottoB.IsLastra
        Get
            Return IsLastra
        End Get
        Set(value As Integer)
            IsLastra = value
        End Set
    End Property

    Private Property IsRotoloB As Integer Implements IFormatoProdottoB.IsRotolo
        Get
            Return IsRotolo
        End Get
        Set(value As Integer)
            IsRotolo = value
        End Set
    End Property

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IFormatoProdottoW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IFormatoProdottoW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IFormatoProdottoW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_formatoprodotto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFormatoProdottoW
    Inherits _IFormatoProdottoW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface