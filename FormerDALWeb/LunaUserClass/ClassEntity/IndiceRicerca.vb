#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.7 
'Author: Diego Lunadei
'Date: 15/07/2014 
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
'''Entity Class for table Indiciricerca
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class IndiceRicerca
    Inherits _IndiceRicerca
    Implements IIndiceRicerca, ICloneable

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Property KeywordTrovate As Integer = 0

    Public ReadOnly Property UnitaMisura As String
        Get
            Dim ris As String = "pezzi"

            ris = FormerLib.FormerHelper.Stringhe.GetEtichettaPerTipoPrezzo(ListinoBase.TipoPrezzo)

            'If ListinoBase.TipoPrezzo = enTipoPrezzo.SuMetriQuadri Then
            '    ris = "m^2"
            'ElseIf ListinoBase.TipoPrezzo = enTipoPrezzo.SuCmQuadri Then
            '    ris = "pz 10cm^2"
            'End If

            Return ris
        End Get
    End Property

    Public Overrides Property IdIndiceRicerca() As Integer
        Get
            Return MyBase.IdIndiceRicerca
        End Get
        Set(ByVal value As Integer)
            MyBase.IdIndiceRicerca = value
        End Set
    End Property


    Public Overrides Property IdPrev() As Integer
        Get
            Return MyBase.IdPrev
        End Get
        Set(ByVal value As Integer)
            MyBase.IdPrev = value
        End Set
    End Property


    Public Overrides Property IdListinoBase() As Integer
        Get
            Return MyBase.IdListinoBase
        End Get
        Set(ByVal value As Integer)
            MyBase.IdListinoBase = value
        End Set
    End Property


    Public Overrides Property PercCoupon() As Integer
        Get
            Return MyBase.PercCoupon
        End Get
        Set(ByVal value As Integer)
            MyBase.PercCoupon = value
        End Set
    End Property


    Public Overrides Property InEvidenza() As Integer
        Get
            Return MyBase.InEvidenza
        End Get
        Set(ByVal value As Integer)
            MyBase.InEvidenza = value
        End Set
    End Property


    Public Overrides Property ProdottoFinito() As Integer
        Get
            Return MyBase.ProdottoFinito
        End Get
        Set(ByVal value As Integer)
            MyBase.ProdottoFinito = value
        End Set
    End Property


    Public Overrides Property Qta1() As Integer
        Get
            Return MyBase.Qta1
        End Get
        Set(ByVal value As Integer)
            MyBase.Qta1 = value
        End Set
    End Property

    Public Overrides Property Prezzo1() As Decimal
        Get
            Return MyBase.Prezzo1
        End Get
        Set(ByVal value As Decimal)
            MyBase.Prezzo1 = value
        End Set
    End Property


    Public Overrides Property Prezzo1Riv() As Decimal
        Get
            Return MyBase.Prezzo1Riv
        End Get
        Set(ByVal value As Decimal)
            MyBase.Prezzo1Riv = value
        End Set
    End Property


    Public Overrides Property Qta2() As Integer
        Get
            Return MyBase.Qta2
        End Get
        Set(ByVal value As Integer)
            MyBase.Qta2 = value
        End Set
    End Property


    Public Overrides Property Prezzo2() As Decimal
        Get
            Return MyBase.Prezzo2
        End Get
        Set(ByVal value As Decimal)
            MyBase.Prezzo2 = value
        End Set
    End Property


    Public Overrides Property Prezzo2Riv() As Decimal
        Get
            Return MyBase.Prezzo2Riv
        End Get
        Set(ByVal value As Decimal)
            MyBase.Prezzo2Riv = value
        End Set
    End Property


    Public Overrides Property Qta3() As Integer
        Get
            Return MyBase.Qta3
        End Get
        Set(ByVal value As Integer)
            MyBase.Qta3 = value
        End Set
    End Property


    Public Overrides Property Prezzo3() As Decimal
        Get
            Return MyBase.Prezzo3
        End Get
        Set(ByVal value As Decimal)
            MyBase.Prezzo3 = value
        End Set
    End Property


    Public Overrides Property Prezzo3Riv() As Decimal
        Get
            Return MyBase.Prezzo3Riv
        End Get
        Set(ByVal value As Decimal)
            MyBase.Prezzo3Riv = value
        End Set
    End Property

    Public Overrides Property TotOrdini() As Integer
        Get
            Return MyBase.TotOrdini
        End Get
        Set(ByVal value As Integer)
            MyBase.TotOrdini = value
        End Set
    End Property

#End Region

#Region "Logic Field"

    Private _ListinoBase As ListinoBaseW = Nothing
    Public ReadOnly Property ListinoBase As ListinoBaseW
        Get
            If _ListinoBase Is Nothing Then
                _ListinoBase = New ListinoBaseW
                _ListinoBase.Read(IdListinoBase)
            End If
            Return _ListinoBase
        End Get
    End Property

    Public ReadOnly Property Prezzo1RivPStr As String
        Get
            Return GetPrezzoPromo(Prezzo1Riv)
        End Get
    End Property
    Public ReadOnly Property Prezzo2RivPStr As String
        Get
            Return GetPrezzoPromo(Prezzo2Riv)
        End Get
    End Property
    Public ReadOnly Property Prezzo3RivPStr As String
        Get
            Return GetPrezzoPromo(Prezzo3Riv)
        End Get
    End Property

    Public ReadOnly Property Prezzo1PStr As String
        Get
            Return GetPrezzoPromo(Prezzo1)
        End Get
    End Property
    Public ReadOnly Property Prezzo2PStr As String
        Get
            Return GetPrezzoPromo(Prezzo2)
        End Get
    End Property
    Public ReadOnly Property Prezzo3PStr As String
        Get
            Return GetPrezzoPromo(Prezzo3)
        End Get
    End Property

    Private Function GetPrezzoPromo(PrezzoRif As Decimal) As String
        Dim ris As String = String.Empty

        PrezzoRif = PrezzoRif * MgrPercentualiDay.PercentualeSlow(ListinoBase.Preventivazione)
        PrezzoRif = Math.Floor(PrezzoRif)
        'qui controllo se per caso c'è un promo
        Dim Pr As PromoW = ListinoBase.Promo

        If Not Pr Is Nothing Then
            PrezzoRif = Pr.GetPrezzoPromo(PrezzoRif)
        End If

        ris = FormerHelper.Stringhe.FormattaPrezzo(PrezzoRif)

        Return ris
    End Function

    Public ReadOnly Property Prezzo1Str As String
        Get
            Return FormerHelper.Stringhe.FormatNumberNonVirgola(Prezzo1)
        End Get
    End Property

    Public ReadOnly Property Prezzo1RivStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(Prezzo1Riv)
        End Get
    End Property

    Public ReadOnly Property Prezzo2Str As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(Prezzo2)
        End Get
    End Property

    Public ReadOnly Property Prezzo2RivStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(Prezzo2Riv)
        End Get
    End Property

    Public ReadOnly Property Prezzo3Str As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(Prezzo3)
        End Get
    End Property

    Public ReadOnly Property Prezzo3RivStr As String
        Get
            Return FormerHelper.Stringhe.FormattaPrezzo(Prezzo3Riv)
        End Get
    End Property

    Public Property EsattezzaRisultato As Integer = 0

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IIndiceRicerca.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IIndiceRicerca.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IIndiceRicerca.Save
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
'''Interface for table Indiciricerca
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IIndiceRicerca
    Inherits _IIndiceRicerca

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface