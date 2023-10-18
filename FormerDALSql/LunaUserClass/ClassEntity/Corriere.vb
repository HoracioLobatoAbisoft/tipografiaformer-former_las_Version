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

''' <summary>
'''Entity Class for table T_corriere
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Corriere
    Inherits _Corriere
    Implements ICorriere, ICorriereBusiness

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Public Overrides Property PrevedeAccorpamento As Boolean Implements ICorriereBusiness.PrevedeAccorpamento
        Get
            Return MyBase.PrevedeAccorpamento
        End Get
        Set(value As Boolean)
            MyBase.PrevedeAccorpamento = value
        End Set
    End Property

    Public Overrides Property IdCorriere As Integer Implements ICorriereBusiness.IdCorriere
        Get
            Return MyBase.IdCorriere
        End Get
        Set(value As Integer)
            MyBase.IdCorriere = value
        End Set
    End Property

    Public Overrides Property TipoCorriere As Integer Implements ICorriereBusiness.TipoCorriere
        Get
            Return MyBase.TipoCorriere
        End Get
        Set(value As Integer)
            MyBase.TipoCorriere = value
        End Set
    End Property

    Public Overrides Property NomeBreve As String Implements ICorriereBusiness.NomeBreve
        Get
            Return MyBase.NomeBreve
        End Get
        Set(value As String)
            MyBase.NomeBreve = value
        End Set
    End Property

    Public Overrides Property GGConsegna As Integer Implements ICorriereBusiness.GGConsegna
        Get
            Return MyBase.GGConsegna
        End Get
        Set(value As Integer)
            MyBase.GGConsegna = value
        End Set
    End Property

    Public Overrides Property DisponibileOnline As Boolean Implements ICorriereBusiness.DisponibileOnline
        Get
            Return MyBase.DisponibileOnline
        End Get
        Set(value As Boolean)
            MyBase.DisponibileOnline = value
        End Set
    End Property

    Public Overrides Property Label As String Implements ICorriereBusiness.Label
        Get
            Return MyBase.Label
        End Get
        Set(value As String)
            MyBase.Label = value
        End Set
    End Property


    Public Overrides Property PercPortoAssegnato As Integer Implements ICorriereBusiness.PercPortoAssegnato
        Get
            Return MyBase.PercPortoAssegnato
        End Get
        Set(value As Integer)
            MyBase.PercPortoAssegnato = value
        End Set
    End Property

    Public Overrides Property KgLimite1 As Integer Implements ICorriereBusiness.KgLimite1
        Get
            Return MyBase.KgLimite1
        End Get
        Set(value As Integer)
            MyBase.KgLimite1 = value
        End Set
    End Property

    Public Overrides Property TariffaLimite1 As Decimal Implements ICorriereBusiness.TariffaLimite1
        Get
            Return MyBase.TariffaLimite1
        End Get
        Set(value As Decimal)
            MyBase.TariffaLimite1 = value
        End Set
    End Property

    Public Overrides Property KgLimite2 As Integer Implements ICorriereBusiness.KgLimite2
        Get
            Return MyBase.KgLimite2
        End Get
        Set(value As Integer)
            MyBase.KgLimite2 = value
        End Set
    End Property

    Public Overrides Property TariffaLimite2 As Decimal Implements ICorriereBusiness.TariffaLimite2
        Get
            Return MyBase.TariffaLimite2
        End Get
        Set(value As Decimal)
            MyBase.TariffaLimite2 = value
        End Set
    End Property

    Public Overrides Property KgLimite3 As Integer Implements ICorriereBusiness.KgLimite3
        Get
            Return MyBase.KgLimite3
        End Get
        Set(value As Integer)
            MyBase.KgLimite3 = value
        End Set
    End Property

    Public Overrides Property TariffaLimite3 As Decimal Implements ICorriereBusiness.TariffaLimite3
        Get
            Return MyBase.TariffaLimite3
        End Get
        Set(value As Decimal)
            MyBase.TariffaLimite3 = value
        End Set
    End Property

    Public Overrides Property KgLimite4 As Integer Implements ICorriereBusiness.KgLimite4
        Get
            Return MyBase.KgLimite4
        End Get
        Set(value As Integer)
            MyBase.KgLimite4 = value
        End Set
    End Property

    Public Overrides Property TariffaLimite4 As Decimal Implements ICorriereBusiness.TariffaLimite4
        Get
            Return MyBase.TariffaLimite4
        End Get
        Set(value As Decimal)
            MyBase.TariffaLimite4 = value
        End Set
    End Property

    Public Overrides Property KgLimite5 As Integer Implements ICorriereBusiness.KgLimite5
        Get
            Return MyBase.KgLimite5
        End Get
        Set(value As Integer)
            MyBase.KgLimite5 = value
        End Set
    End Property

    Public Overrides Property TariffaLimite5 As Decimal Implements ICorriereBusiness.TariffaLimite5
        Get
            Return MyBase.TariffaLimite5
        End Get
        Set(value As Decimal)
            MyBase.TariffaLimite5 = value
        End Set
    End Property

    Public Overrides Property KgLimite6 As Integer Implements ICorriereBusiness.KgLimite6
        Get
            Return MyBase.KgLimite6
        End Get
        Set(value As Integer)
            MyBase.KgLimite6 = value
        End Set
    End Property

    Public Overrides Property TariffaLimite6 As Decimal Implements ICorriereBusiness.TariffaLimite6
        Get
            Return MyBase.TariffaLimite6
        End Get
        Set(value As Decimal)
            MyBase.TariffaLimite6 = value
        End Set
    End Property

    Public Overrides Property KgLimite7 As Integer Implements ICorriereBusiness.KgLimite7
        Get
            Return MyBase.KgLimite7
        End Get
        Set(value As Integer)
            MyBase.KgLimite7 = value
        End Set
    End Property

    Public Overrides Property TariffaLimite7 As Decimal Implements ICorriereBusiness.TariffaLimite7
        Get
            Return MyBase.TariffaLimite7
        End Get
        Set(value As Decimal)
            MyBase.TariffaLimite7 = value
        End Set
    End Property

    Public Overrides Property Descrizione As String Implements ICorriereBusiness.Descrizione
        Get
            Return MyBase.Descrizione
        End Get
        Set(value As String)
            MyBase.Descrizione = value
        End Set
    End Property

    Public Overrides Property TestoMail As String Implements ICorriereBusiness.TestoMail
        Get
            Return MyBase.TestoMail
        End Get
        Set(value As String)
            MyBase.TestoMail = value
        End Set
    End Property

    Public Function LavoraCap(Cap As String) As Boolean Implements ICorriereBusiness.LavoraCap
        Dim ris As Boolean = False

        Using mgr As New CapCorriereDAO
            Dim capF As CapCorriere = mgr.Find(New LUNA.LunaSearchParameter("IdCorriere", IdCorriere), _
                                              New LUNA.LunaSearchParameter("CAP", Cap))
            If Not capF Is Nothing Then
                ris = True
            End If
        End Using

        Return ris
    End Function

    Public ReadOnly Property LabelDataConsegna As String Implements ICorriereBusiness.LabelDataConsegna
        Get
            Return String.Empty
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICorriere.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICorriere.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICorriere.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_corriere
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICorriere
    Inherits _ICorriere

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface