#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.11.31 
'Author: Diego Lunadei
'Date: 11/04/2016 
#End Region




Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table T_omaggi
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class OmaggioW
    Inherits _OmaggioW
    Implements IOmaggioW

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdOmaggio() As Integer
        Get
            Return MyBase.IdOmaggio
        End Get
        Set(ByVal value As Integer)
            MyBase.IdOmaggio = value
        End Set
    End Property


    Public Overrides Property Tipologia() As Integer
        Get
            Return MyBase.Tipologia
        End Get
        Set(ByVal value As Integer)
            MyBase.Tipologia = value
        End Set
    End Property


    Public Overrides Property IdListinoOmaggio() As Integer
        Get
            Return MyBase.IdListinoOmaggio
        End Get
        Set(ByVal value As Integer)
            MyBase.IdListinoOmaggio = value
        End Set
    End Property


    Public Overrides Property QtaOmaggio() As Integer
        Get
            Return MyBase.QtaOmaggio
        End Get
        Set(ByVal value As Integer)
            MyBase.QtaOmaggio = value
        End Set
    End Property


    Public Overrides Property IdPreventivazione() As Integer
        Get
            Return MyBase.IdPreventivazione
        End Get
        Set(ByVal value As Integer)
            MyBase.IdPreventivazione = value
        End Set
    End Property


    Public Overrides Property ImportoMin() As Decimal
        Get
            Return MyBase.ImportoMin
        End Get
        Set(ByVal value As Decimal)
            MyBase.ImportoMin = value
        End Set
    End Property


    Public Overrides Property TipoCliente() As Integer
        Get
            Return MyBase.TipoCliente
        End Get
        Set(ByVal value As Integer)
            MyBase.TipoCliente = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Private _ListinoBaseOmaggio As ListinoBaseW = Nothing
    Public ReadOnly Property ListinoBaseOmaggio As ListinoBaseW
        Get
            If _ListinoBaseOmaggio Is Nothing Then
                _ListinoBaseOmaggio = New ListinoBaseW
                _ListinoBaseOmaggio.Read(IdListinoOmaggio)
            End If
            Return _ListinoBaseOmaggio
        End Get
    End Property

    'REPLICO I CAMPI DI LISTINOBASE PER RENDERLI EVENTUALMENTE INTERCAMBIABILI IN CASO CAMBI QUALCOSA
    Public ReadOnly Property GetImgFormato As String
        Get
            Return ListinoBaseOmaggio.GetImgFormato
        End Get
    End Property

    Public ReadOnly Property IdListinoBase As Integer
        Get
            Return ListinoBaseOmaggio.IdListinoBase
        End Get
    End Property

    Public ReadOnly Property Nome As String
        Get
            Return ListinoBaseOmaggio.Nome
        End Get
    End Property

    Public ReadOnly Property DescrSito As String
        Get
            Return ListinoBaseOmaggio.DescrSito
        End Get
    End Property

    Public ReadOnly Property CondizioneStr As String
        Get
            Dim ris As String = String.Empty

            If Tipologia = enTipologiaOmaggio.AlPrimoOrdine Then
                ris = "Omaggio per il <b>primo ordine effettuato</b>"
            ElseIf Tipologia = enTipologiaOmaggio.ConCriteri Then
                If IdPreventivazione Then
                    ris = "Omaggio all'acquisto di "

                    If ImportoMin Then
                        ris &= "almeno <b>&euro; " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoMin) & "</b> di "
                    End If

                    ris &= "<b>" & P.Descrizione & "</b>"
                Else
                    ris = "Omaggio per una spesa minima di <b>&euro; " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoMin) & "</b>"
                End If
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property CondizioneStrHref As String
        Get
            Dim ris As String = CondizioneStr

            If IdPreventivazione Then
                ris = "<a href=""/" & P.IdPrev & "/" & P.NomeInUrl & """>" & ris & "</a>"
            End If

            Return ris
        End Get
    End Property

    Private _P As PreventivazioneW = Nothing
    Public ReadOnly Property P As PreventivazioneW
        Get
            If _P Is Nothing AndAlso IdPreventivazione <> 0 Then
                _P = New PreventivazioneW
                _P.Read(IdPreventivazione)
            End If
            Return _P
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IOmaggioW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IOmaggioW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IOmaggioW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_omaggi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IOmaggioW
    Inherits _IOmaggioW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface