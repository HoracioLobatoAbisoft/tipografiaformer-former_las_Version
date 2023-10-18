#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.20392 
'Author: Diego Lunadei
'Date: 25/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table T_rubricamarketing
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class VoceRubricaMarketing
    Inherits _VoceRubricaMarketing
    Implements IVoceRubricaMarketing, IVoceRubricaG

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub


#Region "Logic Field"

    Public Property DataUltimoInvioNewsletter As Date Implements IVoceRubricaG.DataUltimoInvioNewsletter

    Public ReadOnly Property IdRubRif As Integer Implements IVoceRubricaG.IdRubRif
        Get
            Return IDRubMarketing
        End Get
    End Property

    Public ReadOnly Property IdRubG As Integer Implements IVoceRubricaG.IdRubG
        Get
            Dim Ris As Integer = 0

            Using mgr As New VociRubGDAO
                Dim voce As VoceRubG = mgr.Find(New LUNA.LunaSearchParameter("IdRubM", IDRubMarketing))
                If voce Is Nothing Then
                    voce = New VoceRubG
                    voce.IdRubM = IDRubMarketing
                    voce.Save()
                End If
                Ris = voce.IdRubG
            End Using

            Return Ris
        End Get
    End Property

    Public ReadOnly Property ProvenienzaVoce As String Implements IVoceRubricaG.ProvenienzaVoce
        Get
            Return "M"
        End Get
    End Property

    Public ReadOnly Property IdCorriereG As Integer Implements IVoceRubricaG.IdCorrierePredefinito
        Get
            Return FormerLib.FormerEnum.enCorriere.GLS
        End Get
    End Property

    Public ReadOnly Property ProvenienzaVoceExt As String Implements IVoceRubricaG.ProvenienzaVoceExt
        Get
            Return "Marketing"
        End Get
    End Property

    Public ReadOnly Property Sorgente As String Implements IVoceRubricaG.Sorgente
        Get
            Return "M"
        End Get
    End Property

    Public ReadOnly Property ListaOrdini As List(Of Ordine) Implements IVoceRubricaG.ListaOrdini
        Get
            Dim ris As New List(Of Ordine)
            Return ris
        End Get
    End Property

    Public ReadOnly Property NominativoG As String Implements IVoceRubricaG.NominativoG
        Get
            Return NomeAzienda
        End Get
    End Property

    Public ReadOnly Property NomeDiBattesimo As String Implements IVoceRubricaG.NomeDiBattesimo
        Get
            Return String.Empty
        End Get
    End Property

    Public ReadOnly Property DataInserimento As Date Implements IVoceRubricaG.DataInserimento
        Get
            Return DataAcquisizione
        End Get
    End Property


    Public ReadOnly Property IdCategoriaMarketing As Integer Implements IVoceRubricaG.IdCategoriaMarketing
        Get
            Return IdCategoria
        End Get
    End Property


    Public ReadOnly Property TipoG As Integer Implements IVoceRubricaG.Tipo
        Get
            Dim Ris As Integer = enTipoRubrica.Cliente

            If Tipo Then Ris = Tipo

            Return Ris
        End Get
    End Property

    Public ReadOnly Property IndirizzoG As String Implements IVoceRubricaG.Indirizzo
        Get
            Return Indirizzo
        End Get
    End Property

    Public ReadOnly Property CittaG As String Implements IVoceRubricaG.Citta
        Get
            Return Citta
        End Get
    End Property

    Public ReadOnly Property CAPG As String Implements IVoceRubricaG.Cap
        Get
            Return CAP
        End Get
    End Property

    Public ReadOnly Property EmailG As String Implements IVoceRubricaG.EmailG
        Get
            Return Email
        End Get
    End Property

    Public ReadOnly Property SpesaComplessivaNelPeriodo(Periodo As enPeriodoRiferimento) As Integer Implements IVoceRubricaG.SpesaComplessivaNelPeriodo
        Get
            Dim Ris As Integer = 0

            Return Ris
        End Get
    End Property

    Public ReadOnly Property HannoAcquistatoAlmenoUnaVoltaUn(IdPreventivazione As Integer) As Boolean Implements IVoceRubricaG.HannoAcquistatoAlmenoUnaVoltaUn
        Get
            Dim ris As Boolean = False
            Return ris
        End Get
    End Property

    Public ReadOnly Property NonHannoMaiAcquistatoUn(IdPreventivazione As Integer) As Boolean Implements IVoceRubricaG.NonHannoMaiAcquistatoUn
        Get
            Dim ris As Boolean = True
            Return ris
        End Get
    End Property


    Public ReadOnly Property NonHannoMaiSpeso As Boolean Implements IVoceRubricaG.NonHannoMaiSpeso
        Get
            Dim ris As Boolean = True

            Return ris
        End Get
    End Property

    Public ReadOnly Property TagG As String Implements IVoceRubricaG.Tag
        Get
            Return Tag
        End Get
    End Property

    Private _Categoria As CatRubrMarketing
    Public Property Categoria As CatRubrMarketing
        Get
            If _Categoria Is Nothing Then
                _Categoria = New CatRubrMarketing
                _Categoria.Read(IdCategoria)
            End If
            Return _Categoria
        End Get
        Set(value As CatRubrMarketing)
            _Categoria = value
        End Set
    End Property

    Public ReadOnly Property CategoriaStr As String
        Get
            Return Categoria.Descrizione
        End Get
    End Property

    Public ReadOnly Property DataAcqStr As String
        Get
            Return _DataAcquisizione.ToString("dd/MM/yyyy")
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IVoceRubricaMarketing.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IVoceRubricaMarketing.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IVoceRubricaMarketing.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_rubricamarketing
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IVoceRubricaMarketing
    Inherits _IVoceRubricaMarketing

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface