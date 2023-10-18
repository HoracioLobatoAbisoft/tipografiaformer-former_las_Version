#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 20/02/2020 
#End Region




Imports System.Drawing
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table T_decodificavocicosto
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class DecodificaVoceCosto
    Inherits _DecodificaVoceCosto
    Implements IDecodificaVoceCosto

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdDecodificaVociCosto() As Integer
        Get
            Return MyBase.IdDecodificaVociCosto
        End Get
        Set(ByVal value As Integer)
            MyBase.IdDecodificaVociCosto = value
        End Set
    End Property


    Public Overrides Property IdFornitore() As Integer
        Get
            Return MyBase.IdFornitore
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFornitore = value
        End Set
    End Property


    Public Overrides Property IdRis() As Integer
        Get
            Return MyBase.IdRis
        End Get
        Set(ByVal value As Integer)
            MyBase.IdRis = value
        End Set
    End Property


    Public Overrides Property QtaMoltiplicatore() As Single
        Get
            Return MyBase.QtaMoltiplicatore
        End Get
        Set(ByVal value As Single)
            MyBase.QtaMoltiplicatore = value
        End Set
    End Property


    Public Overrides Property TextToSearch() As String
        Get
            Return MyBase.TextToSearch
        End Get
        Set(ByVal value As String)
            MyBase.TextToSearch = value
        End Set
    End Property


    Public Overrides Property TipoDecodifica() As Integer
        Get
            Return MyBase.TipoDecodifica
        End Get
        Set(ByVal value As Integer)
            MyBase.TipoDecodifica = value
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

    Public ReadOnly Property ImageRif As Image
        Get
            Dim ris As Image = Nothing
            If Not Risorsa Is Nothing Then
                ris = Risorsa.ImageRif
            Else
                ris = My.Resources.no_image
            End If

            Return ris
        End Get
    End Property
    Public ReadOnly Property TipoRegolaIMG As Image
        Get
            Dim ris As Image = Nothing
            If TipoDecodifica = enTipoDecodificaVoceCosto.Interpretazione Then
                ris = My.Resources._Aggiungi
            ElseIf TipoDecodifica = enTipoDecodificaVoceCosto.Esclusione Then
                ris = My.Resources._DeleteAll
            End If

            Return ris
        End Get
    End Property
    Private _Fornitore As VoceRubrica = Nothing
    Public ReadOnly Property Fornitore As VoceRubrica
        Get
            If _Fornitore Is Nothing Then
                If IdFornitore Then
                    _Fornitore = New VoceRubrica
                    _Fornitore.Read(IdFornitore)
                End If
            End If
            Return _Fornitore
        End Get
    End Property

    Public ReadOnly Property FornitoreStr As String
        Get
            Dim ris As String = "-"
            If Not Fornitore Is Nothing Then
                ris = Fornitore.RagSocNome
            End If
            Return ris
        End Get
    End Property

    Private _Risorsa As Risorsa = Nothing
    Public ReadOnly Property Risorsa As Risorsa
        Get
            If _Risorsa Is Nothing Then
                If IdRis Then
                    _Risorsa = New Risorsa
                    _Risorsa.Read(IdRis)
                End If
            End If
            Return _Risorsa
        End Get
    End Property

    Public ReadOnly Property RisorsaStr As String
        Get
            Dim ris As String = "-"
            If TipoDecodifica = enTipoDecodificaVoceCosto.Interpretazione Then
                If Not Risorsa Is Nothing Then
                    ris = Risorsa.Descrizione
                End If
            ElseIf TipoDecodifica = enTipoDecodificaVoceCosto.Esclusione Then
                ris = TextToSearch
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoDecodificaStr As String
        Get
            Return FormerLib.FormerEnum.FormerEnumHelper.TipoDecodificaVoceCostoStr(TipoDecodifica)
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IDecodificaVoceCosto.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IDecodificaVoceCosto.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IDecodificaVoceCosto.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''Interface for table T_decodificavocicosto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IDecodificaVoceCosto
    Inherits _IDecodificaVoceCosto

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface