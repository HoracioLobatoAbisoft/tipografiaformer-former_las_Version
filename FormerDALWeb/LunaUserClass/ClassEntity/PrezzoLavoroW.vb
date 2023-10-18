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

''' <summary>
'''Entity Class for table T_prezzilavoro
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class PrezzoLavoroW
    Inherits _PrezzoLavoroW
    Implements IPrezzoLavoroW
    Implements IPrezzoLavoroB
    Implements ICloneable

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



    Public Overrides Property Prezzo2() As Decimal Implements IPrezzoLavoroB.Prezzo2
        Get
            Return MyBase.Prezzo2
        End Get
        Set(ByVal value As Decimal)
            MyBase.Prezzo2 = value
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

    Private _IdFormCarta As Integer = 0
    Public ReadOnly Property IdFormCarta As Integer Implements IPrezzoLavoroB.IdFormCarta
        Get
            If _IdFormCarta = 0 Then
                If IdFormProd Then
                    Using fp As New FormatoProdottoW
                        fp.Read(IdFormProd)
                        _IdFormCarta = fp.IdFormCarta
                    End Using
                End If
            End If
            Return _IdFormCarta
        End Get
    End Property

    Public ReadOnly Property PrezzoSuProdottoFinito As Boolean Implements IPrezzoLavoroB.PrezzoSuProdottoFinito
        Get
            Dim ris As Boolean = False
            If IdFormProd Then
                Using fp As New FormatoProdottoW
                    fp.Read(IdFormProd)
                    ris = fp.ProdottoFinito
                End Using
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

    Private _FormatoCarta As FormatoCartaW = Nothing
    Public ReadOnly Property FormatoCarta As IFormatoCartaB Implements IPrezzoLavoroB.FormatoCarta
        Get
            If IdFormCarta Then
                If _FormatoCarta Is Nothing Then
                    _FormatoCarta = New FormatoCartaW
                    _FormatoCarta.Read(IdFormCarta)
                End If
            End If
            Return _FormatoCarta
        End Get
    End Property

    Private _FormatoProdotto As FormatoProdottoW = Nothing
    Public ReadOnly Property FormatoProdotto As IFormatoProdottoB Implements IPrezzoLavoroB.FormatoProdotto
        Get
            If IdFormProd Then
                If _FormatoProdotto Is Nothing Then
                    _FormatoProdotto = New FormatoProdottoW
                    _FormatoProdotto.Read(IdFormProd)
                End If
            End If
            Return _FormatoProdotto
        End Get
    End Property

#End Region

    Public Function ClonaPrezzo() As Object Implements IPrezzoLavoroB.ClonaPrezzo
        Return Clone()
    End Function

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IPrezzoLavoroW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IPrezzoLavoroW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IPrezzoLavoroW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_prezzilavoro
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPrezzoLavoroW
    Inherits _IPrezzoLavoroW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface