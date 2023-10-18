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
Imports FormerLib
Imports System.IO
Imports System.Drawing
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table Td_formatoprodotto
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class FormatoProdotto
    Inherits _FormatoProdotto
    Implements IFormatoProdotto
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

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = Formato

            If Not Categoria Is Nothing Then
                ris &= " (" & Categoria.Nome & ")"
            End If

            Return ris

        End Get
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

    Private _ListiniBaseCheLoUsano As List(Of ListinoBase) = Nothing
    Public ReadOnly Property ListiniBaseCheLoUsano() As List(Of ListinoBase)
        Get
            If _ListiniBaseCheLoUsano Is Nothing Then
                Using mgr As New ListinoBaseDAO
                    _ListiniBaseCheLoUsano = mgr.FindAll(LFM.ListinoBase.Nome, New LUNA.LSP(LFM.ListinoBase.IdFormProd, IdFormProd),
                                                            New LUNA.LSP(LFM.ListinoBase.NascondiOnline, enSiNo.No))
                End Using
            End If
            Return _ListiniBaseCheLoUsano

        End Get
    End Property

    Public ReadOnly Property RiassuntoConLB As String
        Get
            Dim ris As String = Formato & " ("

            Using mgr As New ListinoBaseDAO
                For Each lb In ListiniBaseCheLoUsano
                    ris &= lb.Nome & ","
                Next

                ris = ris.TrimEnd(",")
                ris &= ")"
            End Using

            Return ris
        End Get
    End Property

    Private _Categoria As CatFormatoProdotto = Nothing
    Public ReadOnly Property Categoria As CatFormatoProdotto
        Get
            If IdCatFormatoProdotto Then
                If _Categoria Is Nothing Then
                    _Categoria = New CatFormatoProdotto
                    _Categoria.Read(IdCatFormatoProdotto)
                End If
            End If
            Return _Categoria
        End Get
    End Property

    Public ReadOnly Property CategoriaStr As String
        Get
            Dim ris As String = String.Empty

            If Not Categoria Is Nothing Then
                ris = Categoria.Nome
            Else
                ris = "-"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property Img As Image
        Get
            Dim ris As Image = Nothing
            If _ImgRif.Length Then
                If File.Exists(_ImgRif) Then
                    Try
                        ris = Image.FromFile(_ImgRif)
                    Catch ex As Exception

                    End Try
                End If
            Else
                ris = My.Resources.no_image
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property OrientamentoStr As String
        Get
            Dim ris As String = String.Empty
            ris = FormerEnumHelper.OrientamentoStr(_Orientamento)
            Return ris
        End Get
    End Property

    Public ReadOnly Property AreaCmQuadrati As Single
        Get
            Dim Area As Single = 0
            If Not FormatoCarta Is Nothing Then
                Area = FormatoCarta.Larghezza * FormatoCarta.Altezza
            End If

            Return Area
        End Get
    End Property

    Private _FormatoCarta As FormatoCarta = Nothing
    Public ReadOnly Property FormatoCarta As FormatoCarta
        Get
            If _FormatoCarta Is Nothing Then
                If _IdFormCarta Then
                    _FormatoCarta = New FormatoCarta
                    _FormatoCarta.Read(_IdFormCarta)
                End If
            End If
            Return _FormatoCarta
        End Get
    End Property

    Public ReadOnly Property FormatoCartaStr As String
        Get
            Return FormatoCarta.FormatoCarta & " (" & (FormatoCarta.Larghezza * 10) & "mm x " & (FormatoCarta.Altezza * 10) & "mm)"
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IFormatoProdotto.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE

        If Sigla.Length = 0 Then Ris = False
        If IdFormCarta = 0 Then Ris = False
        If Formato.Length = 0 Then Ris = False
        If DescrizioneEstesa.Length = 0 Then Ris = False
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IFormatoProdotto.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IFormatoProdotto.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return _Formato
    End Function

#End Region

    Public Property TipoGrandezzaPrezzo As enTipoGrandezzaPrezzoLavorazione = enTipoGrandezzaPrezzoLavorazione.Medio

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
End Class

Public Class FormatoProdottoEx
    Inherits FormatoProdotto
    Implements IVoceComboConImmagine, ICloneable

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"
    Public ReadOnly Property Id As Integer Implements IVoceComboConImmagine.Id
        Get
            Return _IdFormProd
        End Get
    End Property

    Public ReadOnly Property Text As String Implements IVoceComboConImmagine.Text
        Get
            Return _Formato
        End Get
    End Property

    Public ReadOnly Property Description As String Implements IVoceComboConImmagine.Description
        Get
            Return _Formato & vbNewLine & "(Orientamento: " & OrientamentoStr & ")"
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = ""
            ris = _Formato
            Return ris
        End Get
    End Property


#End Region

    Private _ImageAnteprima As Image = Nothing
    Public ReadOnly Property ImageAnteprima64 As Image Implements IVoceComboConImmagine.Image
        Get
            Dim Img As Image = Nothing
            If _ImageAnteprima Is Nothing Then

                Try
                    If _ImgRif.Length Then
                        If File.Exists(_ImgRif) Then
                            Dim ImgInt As New Bitmap(_ImgRif)

                            Dim width As Integer = 0, height As Integer = 0

                            'If ImgInt.Width > ImgInt.Height Then
                            '    width = 80
                            '    height = 60
                            'ElseIf ImgInt.Width < ImgInt.Height Then
                            '    width = 60
                            '    height = 80
                            'Else
                            width = 64
                            height = 64
                            'End If

                            Dim ImgNew = New Bitmap(ImgInt, New Size(width, height))

                            Img = ImgNew
                            _ImageAnteprima = Img
                        End If

                    End If

                Catch ex As Exception
                    Dim str As String = ex.Message
                End Try
            Else
                Img = _ImageAnteprima
            End If

            Return Img
            'Dim Img As Image = Nothing
            'Try

            '    Img = Image.FromFile(_Anteprima)
            'Catch ex As Exception

            'End Try
            'Return Img
        End Get
    End Property

    Public ReadOnly Property ImageAnteprima32 As Image
        Get
            Dim Img As Image = Nothing
            If _ImageAnteprima Is Nothing Then

                Try
                    If _ImgRif.Length Then
                        If File.Exists(_ImgRif) Then
                            Dim ImgInt As New Bitmap(_ImgRif)

                            Dim width As Integer = 0, height As Integer = 0

                            width = 32
                            height = 32
                            'End If

                            Dim ImgNew = New Bitmap(ImgInt, New Size(width, height))

                            Img = ImgNew
                            _ImageAnteprima = Img
                        End If

                    End If

                Catch ex As Exception
                    Dim str As String = ex.Message
                End Try
            Else
                Img = _ImageAnteprima
            End If

            Return Img
            'Dim Img As Image = Nothing
            'Try

            '    Img = Image.FromFile(_Anteprima)
            'Catch ex As Exception

            'End Try
            'Return Img
        End Get
    End Property

    Public ReadOnly Property Img As Image
        Get
            Dim ris As Image = Nothing
            If _ImgRif.Length Then
                If File.Exists(_ImgRif) Then
                    Try
                        ris = Image.FromFile(_ImgRif)
                    Catch ex As Exception

                    End Try
                End If
            Else
                ris = My.Resources.no_image

            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property ProdottoFinitoStr As String
        Get
            Dim ris As String = String.Empty

            If ProdottoFinito Then
                ris = "Si"
            Else
                ris = "No"
            End If

            Return ris

        End Get
    End Property



    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class





''' <summary>
'''Interface for table Td_formatoprodotto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFormatoProdotto
    Inherits _IFormatoProdotto

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface