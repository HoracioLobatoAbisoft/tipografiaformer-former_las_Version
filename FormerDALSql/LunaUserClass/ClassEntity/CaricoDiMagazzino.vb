#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 26/02/2019 
#End Region




Imports FormerLib
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table T_carichimagazzino
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class CaricoDiMagazzino
    Inherits _CaricoDiMagazzino
    Implements ICaricoDiMagazzino

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdCaricoMagazzino() As Integer
        Get
            Return MyBase.IdCaricoMagazzino
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCaricoMagazzino = value
        End Set
    End Property


    Public Overrides Property DataCarico() As DateTime
        Get
            Return MyBase.DataCarico
        End Get
        Set(ByVal value As DateTime)
            MyBase.DataCarico = value
        End Set
    End Property


    Public Overrides Property IdRub() As Integer
        Get
            Return MyBase.IdRub
        End Get
        Set(ByVal value As Integer)
            MyBase.IdRub = value
        End Set
    End Property


    Public Overrides Property IdUtCarico() As Integer
        Get
            Return MyBase.IdUtCarico
        End Get
        Set(ByVal value As Integer)
            MyBase.IdUtCarico = value
        End Set
    End Property


    Public Overrides Property NumeroDocRiferimento() As String
        Get
            Return MyBase.NumeroDocRiferimento
        End Get
        Set(ByVal value As String)
            MyBase.NumeroDocRiferimento = value
        End Set
    End Property


    Public Overrides Property TipoDocRiferimento() As Integer
        Get
            Return MyBase.TipoDocRiferimento
        End Get
        Set(ByVal value As Integer)
            MyBase.TipoDocRiferimento = value
        End Set
    End Property


#End Region

#Region "Logic Field"
    Private _ListaMovimenti As List(Of MovimentoMagazzino) = Nothing
    Public ReadOnly Property ListaMovimenti As List(Of MovimentoMagazzino)
        Get
            Using mgr As New MagazzinoDAO
                _ListaMovimenti = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdCaricoMagazzino, IdCaricoMagazzino))
            End Using
            Return _ListaMovimenti
        End Get
    End Property

    Public ReadOnly Property StatoFEInternoStr As String
        Get
            Dim ris As String = String.Empty

            Select Case IdStatoInterno
                Case enStatoFEInterno.Inserito
                    ris = "Inserito"
                Case enStatoFEInterno.Collegato
                    ris = "Collegato"
                Case enStatoFEInterno.Anomalia
                    ris = "Anomalia"
            End Select

            Return ris
        End Get
    End Property

    Public ReadOnly Property Datamov As String
        Get
            Return DataCarico.ToString("dd/MM/yyyy")
        End Get
    End Property

    Private _Fornitore As VoceRubrica
    Public ReadOnly Property Fornitore As VoceRubrica
        Get
            If _Fornitore Is Nothing Then
                _Fornitore = New VoceRubrica
                _Fornitore.Read(IdRub)
            End If
            Return _Fornitore
        End Get
    End Property

    Public ReadOnly Property FornitoreStr As String
        Get
            Return Fornitore.RagSocNome
        End Get
    End Property

    Public ReadOnly Property TipoDocStr As String
        Get
            Return FormerLib.FormerEnum.FormerEnumHelper.TipoDocumentoFiscaleStr(TipoDocRiferimento)
        End Get
    End Property

    Public ReadOnly Property AziendaStr As String
        Get
            Dim ris As String = MgrAziende.GetRagioneSociale(IdAzienda)
            Return ris
        End Get
    End Property

    Private _Utente As Utente
    Public ReadOnly Property Utente As Utente
        Get
            If _Utente Is Nothing Then
                _Utente = New Utente
                _Utente.Read(IdUtCarico)
            End If
            Return _Utente
        End Get
    End Property

    Public ReadOnly Property OperatoreStr As String
        Get
            Dim Ris As String = String.Empty

            If IdUtCarico = FormerLib.FormerConst.UtentiSpecifici.IdUtenteAdmin Then
                Ris = "-Automatico-"
            Else
                Ris = Utente.Login
            End If

            Return Ris

        End Get
    End Property

    Public ReadOnly Property NumeroDocStr As String
        Get
            Return NumeroDocRiferimento
        End Get
    End Property
    Private _CostoRiferimento As Costo = Nothing
    Public ReadOnly Property CostoRiferimento As Costo
        Get
            If _CostoRiferimento Is Nothing Then
                If IdCosto Then
                    _CostoRiferimento = New Costo
                    _CostoRiferimento.Read(IdCosto)
                End If
            End If
            Return _CostoRiferimento
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICaricoDiMagazzino.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICaricoDiMagazzino.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICaricoDiMagazzino.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''Interface for table T_carichimagazzino
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICaricoDiMagazzino
    Inherits _ICaricoDiMagazzino

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface