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
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table T_prezzilavoro
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class PrezzoLavoro
    Inherits _PrezzoLavoro
    Implements IPrezzoLavoro
    Implements ICloneable
    Implements IPrezzoLavoroB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdLavPrezzo() As Integer Implements IPrezzoLavoroB.IdLavPrezzo
        Get
            Return MyBase.IdLavPrezzo
        End Get
        Set(ByVal value As Integer)
            MyBase.IdLavPrezzo = value
        End Set
    End Property


    Public Overrides Property IdLavoro() As Integer Implements IPrezzoLavoroB.IdLavoro
        Get
            Return MyBase.IdLavoro
        End Get
        Set(ByVal value As Integer)
            MyBase.IdLavoro = value
        End Set
    End Property


    Public Overrides Property IdFormProd() As Integer Implements IPrezzoLavoroB.IdFormProd
        Get
            Return MyBase.IdFormProd
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFormProd = value
        End Set
    End Property


    Public Overrides Property Prezzo() As Decimal Implements IPrezzoLavoroB.Prezzo
        Get
            Return MyBase.Prezzo
        End Get
        Set(ByVal value As Decimal)
            MyBase.Prezzo = value
        End Set
    End Property


    Public Overrides Property Prezzo2() As Decimal Implements IPrezzoLavoroB.Prezzo2
        Get
            Return MyBase.Prezzo2
        End Get
        Set(ByVal value As Decimal)
            MyBase.Prezzo2 = value
        End Set
    End Property

    Public Overrides Property QtaRif() As Integer Implements IPrezzoLavoroB.QtaRif
        Get
            Return MyBase.QtaRif
        End Get
        Set(ByVal value As Integer)
            MyBase.QtaRif = value
        End Set
    End Property


    Public Overrides Property PrezzoMin() As Decimal Implements IPrezzoLavoroB.PrezzoMin
        Get
            Return MyBase.PrezzoMin
        End Get
        Set(ByVal value As Decimal)
            MyBase.PrezzoMin = value
        End Set
    End Property


    Public Overrides Property PrezzoOltre() As Decimal Implements IPrezzoLavoroB.PrezzoOltre
        Get
            Return MyBase.PrezzoOltre
        End Get
        Set(ByVal value As Decimal)
            MyBase.PrezzoOltre = value
        End Set
    End Property

    Public Overrides Property PrezzoMin2() As Decimal Implements IPrezzoLavoroB.PrezzoMin2
        Get
            Return MyBase.PrezzoMin2
        End Get
        Set(ByVal value As Decimal)
            MyBase.PrezzoMin2 = value
        End Set
    End Property

    Public Overrides Property PrezzoOltre2() As Decimal Implements IPrezzoLavoroB.PrezzoOltre2
        Get
            Return MyBase.PrezzoOltre2
        End Get
        Set(ByVal value As Decimal)
            MyBase.PrezzoOltre2 = value
        End Set
    End Property

#End Region

#Region "Logic Field"

    Public Property EntraInStr As String = String.Empty


    Private _FormatoCarta As FormatoCarta
    Public ReadOnly Property FormatoCarta As FormatoCarta
        Get
            If IdFormCarta Then
                If _FormatoCarta Is Nothing Then
                    _FormatoCarta = New FormatoCarta
                    _FormatoCarta.Read(IdFormCarta)
                End If
            End If
            Return _FormatoCarta

        End Get
    End Property

    Private _FormatoProdotto As FormatoProdotto
    Public ReadOnly Property FormatoProdotto As FormatoProdotto
        Get
            If _IdFormProd Then
                If _FormatoProdotto Is Nothing Then
                    _FormatoProdotto = New FormatoProdotto
                    _FormatoProdotto.Read(_IdFormProd)
                    _FormatoProdottoStr = _FormatoProdotto.Formato
                End If
            End If
            Return _FormatoProdotto

        End Get
    End Property

    Public ReadOnly Property FormatoProdottoB As IFormatoProdottoB Implements IPrezzoLavoroB.FormatoProdotto
        Get
            Return FormatoProdotto
        End Get
    End Property

    Public ReadOnly Property FormatoCartaB As IFormatoCartaB Implements IPrezzoLavoroB.FormatoCarta
        Get
            Return FormatoCarta
        End Get
    End Property

    Private _FormatoProdottoStr As String = String.Empty
    Public ReadOnly Property FormatoProdottoStr As String
        Get
            If _FormatoProdottoStr.Length = 0 Then

                If FormatoProdotto Is Nothing Then
                    _FormatoProdottoStr = " * - Tutti i formati"

                    If TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Medio Then
                        _FormatoProdottoStr &= " (Dimensioni MEDIE)"
                    ElseIf TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Grande Then
                        _FormatoProdottoStr &= " (Dimensioni GRANDI)"
                    ElseIf TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Piccolo Then
                        _FormatoProdottoStr &= " (Dimensioni PICCOLE)"
                    End If

                Else
                    _FormatoProdottoStr = FormatoProdotto.Formato
                End If

            End If
            Return _FormatoProdottoStr
        End Get
    End Property
    Public Function ClonaPrezzo() As Object Implements IPrezzoLavoroB.ClonaPrezzo
        Return Clone()
    End Function

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty
            If _IdFormProd Then
                ris = FormatoProdottoStr
            Else
                ris = " * - Tutti i formati"
                If TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Medio Then
                    ris &= " (Dimensioni MEDIE)"
                ElseIf TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Grande Then
                    ris &= " (Dimensioni GRANDI)"
                ElseIf TipoGrandezza = enTipoGrandezzaPrezzoLavorazione.Piccolo Then
                    ris &= " (Dimensioni PICCOLE)"
                End If

            End If

            ris &= " - MIN € " & PrezzoMin & "/cad, SU " & QtaRif & " € " & Prezzo & "/cad, OLTRE " & " € " & PrezzoOltre & "/cad"

            Return ris

        End Get
    End Property

    Private _IdFormCarta As Integer = 0
    Public ReadOnly Property IdFormCarta As Integer Implements IPrezzoLavoroB.IdFormCarta
        Get
            If _IdFormCarta = 0 Then
                If IdFormProd Then
                    _IdFormCarta = FormatoProdotto.IdFormCarta
                End If
            End If
            Return _IdFormCarta
        End Get
    End Property

    Public ReadOnly Property PrezzoSuProdottoFinito As Boolean Implements IPrezzoLavoroB.PrezzoSuProdottoFinito
        Get
            Dim ris As Boolean = False
            If IdFormProd Then
                ris = FormatoProdotto.ProdottoFinito
            End If
            Return ris
        End Get
    End Property

    Public Property TipoGrandezzaPrezzo As Integer Implements IPrezzoLavoroB.TipoGrandezza
        Get
            Return TipoGrandezza
        End Get
        Set(value As Integer)
            TipoGrandezza = value
        End Set
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IPrezzoLavoro.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        If QtaRif = 0 Then Ris = False
        'If Prezzo = 0 Then Ris = False

        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IPrezzoLavoro.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IPrezzoLavoro.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return Riassunto
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_prezzilavoro
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPrezzoLavoro
    Inherits _IPrezzoLavoro

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface