#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.11.31 
'Author: Diego Lunadei
'Date: 11/04/2016 
#End Region




Imports System.Drawing
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table T_omaggi
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class Omaggio
    Inherits _Omaggio
    Implements IOmaggio

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
    Private _ListinoBaseOmaggio As ListinoBase = Nothing
    Public ReadOnly Property ListinoBaseOmaggio As ListinoBase
        Get
            If _ListinoBaseOmaggio Is Nothing Then
                _ListinoBaseOmaggio = New ListinoBase
                _ListinoBaseOmaggio.Read(IdListinoOmaggio)
            End If
            Return _ListinoBaseOmaggio
        End Get
    End Property

    Private _P As Preventivazione = Nothing
    Public ReadOnly Property P As Preventivazione
        Get
            If _P Is Nothing AndAlso IdPreventivazione <> 0 Then
                _P = New Preventivazione
                _P.Read(IdPreventivazione)
            End If
            Return _P
        End Get
    End Property

    Public ReadOnly Property QtaStr As String
        Get
            Dim ris As String = QtaOmaggio

            Return ris
        End Get
    End Property

    Public ReadOnly Property RiservatoA As String
        Get
            Dim ris As String = String.Empty

            ris = FormerLib.FormerEnum.FormerEnumHelper.TipoRubricaStr(TipoCliente, enSiNo.No)

            Return ris
        End Get
    End Property

    Public ReadOnly Property NomeOmaggio As String
        Get
            Dim ris As String = String.Empty
            ris = ListinoBaseOmaggio.Nome
            Return ris
        End Get
    End Property

    Public ReadOnly Property ImgRif As Image
        Get
            Return ListinoBaseOmaggio.GetImgRif
        End Get
    End Property

    Public ReadOnly Property CondizioneStr As String
        Get
            Dim Ris As String = String.Empty

            If Tipologia = enTipologiaOmaggio.AlPrimoOrdine Then
                Ris = "Al Primo Ordine"
            ElseIf Tipologia = enTipologiaOmaggio.ConCriteri Then
                If IdPreventivazione Then
                    Ris = "All'acquisto di "

                    If ImportoMin Then
                        Ris &= "almeno " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoMin) & " di "
                    End If

                    Ris &= P.Descrizione
                Else
                    Ris = "Spendendo almeno " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoMin)
                End If
            End If

            Return Ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IOmaggio.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IOmaggio.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IOmaggio.Save
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

Public Interface IOmaggio
    Inherits _IOmaggio

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface