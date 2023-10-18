#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.8.1.27156 
'Author: Diego Lunadei
'Date: 27/01/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table T_filtromarketing
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class FiltroMarketing
    Inherits _FiltroMarketing
    Implements IFiltroMarketing

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Database Field"


    Public Overrides Property IdFiltroMarketing() As Integer
        Get
            Return MyBase.IdFiltroMarketing
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFiltroMarketing = value
        End Set
    End Property


    Public Overrides Property Nome() As String
        Get
            Return MyBase.Nome
        End Get
        Set(ByVal value As String)
            MyBase.Nome = value
        End Set
    End Property


    Public Overrides Property Citta() As String
        Get
            Return MyBase.Citta
        End Get
        Set(ByVal value As String)
            MyBase.Citta = value
        End Set
    End Property


    Public Overrides Property Cap() As String
        Get
            Return MyBase.Cap
        End Get
        Set(ByVal value As String)
            MyBase.Cap = value
        End Set
    End Property


    Public Overrides Property Tipo() As Integer
        Get
            Return MyBase.Tipo
        End Get
        Set(ByVal value As Integer)
            MyBase.Tipo = value
        End Set
    End Property


    Public Overrides Property CategoriaMarketing() As Integer
        Get
            Return MyBase.CategoriaMarketing
        End Get
        Set(ByVal value As Integer)
            MyBase.CategoriaMarketing = value
        End Set
    End Property


    Public Overrides Property InseritiDa() As Integer
        Get
            Return MyBase.InseritiDa
        End Get
        Set(ByVal value As Integer)
            MyBase.InseritiDa = value
        End Set
    End Property


    Public Overrides Property HannoAcqAlmenoUn() As Integer
        Get
            Return MyBase.HannoAcqAlmenoUn
        End Get
        Set(ByVal value As Integer)
            MyBase.HannoAcqAlmenoUn = value
        End Set
    End Property


    Public Overrides Property NonHannoMaiAcqUn() As Integer
        Get
            Return MyBase.NonHannoMaiAcqUn
        End Get
        Set(ByVal value As Integer)
            MyBase.NonHannoMaiAcqUn = value
        End Set
    End Property


    Public Overrides Property NonHannoMaiSpeso() As Integer
        Get
            Return MyBase.NonHannoMaiSpeso
        End Get
        Set(ByVal value As Integer)
            MyBase.NonHannoMaiSpeso = value
        End Set
    End Property


    Public Overrides Property SpesaNelPeriodo() As Integer
        Get
            Return MyBase.SpesaNelPeriodo
        End Get
        Set(ByVal value As Integer)
            MyBase.SpesaNelPeriodo = value
        End Set
    End Property


    Public Overrides Property SpesaNelPeriodoMinoreDi() As Integer
        Get
            Return MyBase.SpesaNelPeriodoMinoreDi
        End Get
        Set(ByVal value As Integer)
            MyBase.SpesaNelPeriodoMinoreDi = value
        End Set
    End Property


    Public Overrides Property SpesaNelPeriodoMaggioreDi() As Integer
        Get
            Return MyBase.SpesaNelPeriodoMaggioreDi
        End Get
        Set(ByVal value As Integer)
            MyBase.SpesaNelPeriodoMaggioreDi = value
        End Set
    End Property


    Public Overrides Property chkGennaio() As Integer
        Get
            Return MyBase.chkGennaio
        End Get
        Set(ByVal value As Integer)
            MyBase.chkGennaio = value
        End Set
    End Property


    Public Overrides Property chkFebbraio() As Integer
        Get
            Return MyBase.chkFebbraio
        End Get
        Set(ByVal value As Integer)
            MyBase.chkFebbraio = value
        End Set
    End Property


    Public Overrides Property chkMarzo() As Integer
        Get
            Return MyBase.chkMarzo
        End Get
        Set(ByVal value As Integer)
            MyBase.chkMarzo = value
        End Set
    End Property


    Public Overrides Property chkAprile() As Integer
        Get
            Return MyBase.chkAprile
        End Get
        Set(ByVal value As Integer)
            MyBase.chkAprile = value
        End Set
    End Property


    Public Overrides Property chkMaggio() As Integer
        Get
            Return MyBase.chkMaggio
        End Get
        Set(ByVal value As Integer)
            MyBase.chkMaggio = value
        End Set
    End Property


    Public Overrides Property chkGiugno() As Integer
        Get
            Return MyBase.chkGiugno
        End Get
        Set(ByVal value As Integer)
            MyBase.chkGiugno = value
        End Set
    End Property


    Public Overrides Property chkLuglio() As Integer
        Get
            Return MyBase.chkLuglio
        End Get
        Set(ByVal value As Integer)
            MyBase.chkLuglio = value
        End Set
    End Property


    Public Overrides Property chkAgosto() As Integer
        Get
            Return MyBase.chkAgosto
        End Get
        Set(ByVal value As Integer)
            MyBase.chkAgosto = value
        End Set
    End Property


    Public Overrides Property chkSettembre() As Integer
        Get
            Return MyBase.chkSettembre
        End Get
        Set(ByVal value As Integer)
            MyBase.chkSettembre = value
        End Set
    End Property


    Public Overrides Property chkOttobre() As Integer
        Get
            Return MyBase.chkOttobre
        End Get
        Set(ByVal value As Integer)
            MyBase.chkOttobre = value
        End Set
    End Property


    Public Overrides Property chkNovembre() As Integer
        Get
            Return MyBase.chkNovembre
        End Get
        Set(ByVal value As Integer)
            MyBase.chkNovembre = value
        End Set
    End Property


    Public Overrides Property chkDicembre() As Integer
        Get
            Return MyBase.chkDicembre
        End Get
        Set(ByVal value As Integer)
            MyBase.chkDicembre = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Private _GruppoContatti As Gruppo = Nothing
    Public ReadOnly Property GruppoContatti As Gruppo
        Get
            If _GruppoContatti Is Nothing Then
                _GruppoContatti = New Gruppo
                If IdGruppo Then _GruppoContatti.Read(IdGruppo)
            End If
            Return _GruppoContatti
        End Get
    End Property

    Public ReadOnly Property NomeGruppoStr As String
        Get
            Return GruppoContatti.Nome
        End Get
    End Property

    Public ReadOnly Property SpuntaGen As String
        Get
            Dim Ris As String = String.Empty
            If chkGennaio Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpuntaFeb As String
        Get
            Dim Ris As String = String.Empty
            If chkFebbraio Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpuntaMar As String
        Get
            Dim Ris As String = String.Empty
            If chkMarzo Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpuntaApr As String
        Get
            Dim Ris As String = String.Empty
            If chkAprile Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpuntaMag As String
        Get
            Dim Ris As String = String.Empty
            If chkMaggio Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpuntaGiu As String
        Get
            Dim Ris As String = String.Empty
            If chkGiugno Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpuntaLug As String
        Get
            Dim Ris As String = String.Empty
            If chkLuglio Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpuntaAgo As String
        Get
            Dim Ris As String = String.Empty
            If chkAgosto Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpuntaSet As String
        Get
            Dim Ris As String = String.Empty
            If chkSettembre Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpuntaOtt As String
        Get
            Dim Ris As String = String.Empty
            If chkOttobre Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property


    Public ReadOnly Property SpuntaNov As String
        Get
            Dim Ris As String = String.Empty
            If chkNovembre Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property SpuntaDic As String
        Get
            Dim Ris As String = String.Empty
            If chkDicembre Then
                Ris = "SI"
            End If
            Return Ris
        End Get
    End Property

    Public ReadOnly Property TipoRub As enTipoRubrica
        Get
            Dim ris As enTipoRubrica = enTipoRubrica.Cliente

            If Tipo = enTipoRubrica.Rivenditore Then
                ris = enTipoRubrica.Rivenditore
            End If

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IFiltroMarketing.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IFiltroMarketing.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IFiltroMarketing.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_filtromarketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFiltroMarketing
    Inherits _IFiltroMarketing

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface