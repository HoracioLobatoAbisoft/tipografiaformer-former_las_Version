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


''' <summary>
''' 
'''Entity Class for table T_prodotti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Prodotto
    Inherits _Prodotto
    Implements IProdotto

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Public ReadOnly Property PrezzoLow As Decimal
        Get
            Dim ris As Decimal = 0
            ris = _Prezzo + (_Prezzo * _PercLow / 100)
            Return ris
        End Get
    End Property

    Public ReadOnly Property PrezzoFast As Decimal
        Get
            Dim ris As Decimal = 0
            ris = _Prezzo + (_Prezzo * _PercFast / 100)
            Return ris
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim Ris As String = String.Empty
            If Status = enSiNo.Si Then Ris = "#DELETED#"
            If IdListinoBase = 0 Then Ris = "#NON_USARE#"
            Ris &= Codice & " - " & Descrizione & " (" & FormerEnumHelper.RepartoStr(TipoProd) & ")"
            Return Ris
        End Get
    End Property

    Private _FormatoProdotto As FormatoProdottoEx
    Public ReadOnly Property FormatoProdotto As FormatoProdottoEx
        Get
            If _IdFormato Then
                If _FormatoProdotto Is Nothing Then
                    _FormatoProdotto = New FormatoProdottoEx
                    _FormatoProdotto.Read(_IdFormato)

                End If
            End If
            Return _FormatoProdotto
        End Get
    End Property

    Private _TipoCarta As TipoCartaEx
    Public ReadOnly Property TipoCarta As TipoCartaEx
        Get
            If _IdTipoCarta Then
                If _TipoCarta Is Nothing Then
                    _TipoCarta = New TipoCartaEx
                    _TipoCarta.Read(_IdTipoCarta)

                End If
            End If
            Return _TipoCarta
        End Get
    End Property

    'Private _ImageAnteprima As Image = Nothing
    Public ReadOnly Property FormatoAnteprima32 As Image
        Get

            Dim Img As Image = Nothing
            If _IdFormato Then
                Img = FormatoProdotto.ImageAnteprima32
            End If

            Return Img

        End Get
    End Property

    Private _ListinoBase As ListinoBase = Nothing
    Public ReadOnly Property ListinoBase As ListinoBase
        Get
            If _ListinoBase Is Nothing Then
                If IdListinoBase Then
                    _ListinoBase = New ListinoBase
                    _ListinoBase.Read(IdListinoBase)
                End If
            End If
            Return _ListinoBase
        End Get
    End Property

    Public ReadOnly Property TipoImballo As Integer
        Get
            Dim Ris As Integer = enTipoImballo.Fascette

            If Not ListinoBase Is Nothing Then
                Ris = ListinoBase.IdTipoImballo
            End If

            Return Ris
        End Get
    End Property

    Public ReadOnly Property QtaCollo As Integer
        Get
            Dim Ris As Integer = 1

            If Not ListinoBase Is Nothing Then
                Ris = ListinoBase.QtaCollo
            End If

            Return Ris
        End Get
    End Property

    Public ReadOnly Property TipoCartaAnteprima32 As Image
        Get

            Dim Img As Image = Nothing
            If _IdTipoCarta Then
                Img = TipoCarta.ImageAnteprima32
            End If

            Return Img

        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IProdotto.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        If _Codice.Trim.Length = 0 Then
            Ris = False
        End If

        If _Descrizione.Trim.Length = 0 Then
            Ris = False
        End If
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IProdotto.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IProdotto.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_prodotti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IProdotto
    Inherits _IProdotto

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface