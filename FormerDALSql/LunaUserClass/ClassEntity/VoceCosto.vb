#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 15/02/2019 
#End Region
Imports System.Drawing
Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table T_vocicosto
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class VoceCosto
    Inherits _VoceCosto
    Implements IVoceCosto

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdVoceCosto() As Integer
        Get
            Return MyBase.IdVoceCosto
        End Get
        Set(ByVal value As Integer)
            MyBase.IdVoceCosto = value
        End Set
    End Property


    Public Overrides Property AliquotaIva() As Integer
        Get
            Return MyBase.AliquotaIva
        End Get
        Set(ByVal value As Integer)
            MyBase.AliquotaIva = value
        End Set
    End Property


    Public Overrides Property Codice() As String
        Get
            Return MyBase.Codice
        End Get
        Set(ByVal value As String)
            MyBase.Codice = value
        End Set
    End Property


    Public Overrides Property Descrizione() As String
        Get
            Return MyBase.Descrizione
        End Get
        Set(ByVal value As String)
            MyBase.Descrizione = value
        End Set
    End Property


    Public Overrides Property IdCosto() As Integer
        Get
            Return MyBase.IdCosto
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCosto = value
        End Set
    End Property


    Public Overrides Property PrezzoUnit() As Decimal
        Get
            Return MyBase.PrezzoUnit
        End Get
        Set(ByVal value As Decimal)
            MyBase.PrezzoUnit = value
        End Set
    End Property


    Public Overrides Property Qta() As Decimal
        Get
            Return MyBase.Qta
        End Get
        Set(ByVal value As Decimal)
            MyBase.Qta = value
        End Set
    End Property


    Public Overrides Property Totale() As Decimal
        Get
            Return MyBase.Totale
        End Get
        Set(ByVal value As Decimal)
            MyBase.Totale = value
        End Set
    End Property


    Public Overrides Property Um() As String
        Get
            Return MyBase.Um
        End Get
        Set(ByVal value As String)
            MyBase.Um = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public ReadOnly Property ImgRigaCollegata As Image
        Get
            Dim ris As Image = Nothing

            Using mgr As New VociCostoDAO
                If mgr.ValutareRigaFatturaComeRisorsa(Me) Then
                    If idCat = FormerLib.FormerConst.CategorieContabili.MateriePrime Then
                        If IdMovMagaz Then
                            ris = My.Resources._LinkOk
                        Else
                            ris = My.Resources._NoLink
                        End If
                    Else
                        ris = New Bitmap(26, 26)
                    End If
                Else
                    ris = New Bitmap(26, 26)
                End If
            End Using

            Return ris
        End Get
    End Property

    Private _CostoRiferimento As Costo = Nothing
    Public ReadOnly Property CostoRiferimento As Costo
        Get
            If _CostoRiferimento Is Nothing Then
                _CostoRiferimento = New Costo
                _CostoRiferimento.Read(IdCosto)
            End If
            Return _CostoRiferimento
        End Get
    End Property

    Private _MovMagazzino As MovimentoMagazzino = Nothing
    Public ReadOnly Property MovMagazzino As MovimentoMagazzino
        Get
            If _MovMagazzino Is Nothing Then
                If IdMovMagaz Then
                    _MovMagazzino = New MovimentoMagazzino
                    _MovMagazzino.Read(IdMovMagaz)
                End If

            End If
            Return _MovMagazzino
        End Get
    End Property

    Public ReadOnly Property QtaEx As Decimal
        Get
            Dim ris As Decimal = Qta
            If Not MovMagazzino Is Nothing Then
                ris = MovMagazzino.Qta
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property CodiceEx As String
        Get
            Dim ris As String = Codice
            If Not MovMagazzino Is Nothing Then
                ris = MovMagazzino.CodiceForn
            End If
            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IVoceCosto.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IVoceCosto.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IVoceCosto.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''Interface for table T_vocicosto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IVoceCosto
    Inherits _IVoceCosto

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface