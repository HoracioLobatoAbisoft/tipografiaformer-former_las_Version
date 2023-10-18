#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 24/04/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Imports System.Drawing

''' <summary>
'''Entity Class for table T_coupon
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Coupon
    Inherits _Coupon
    Implements ICoupon

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdCoupon() As Integer
        Get
            Return MyBase.IdCoupon
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCoupon = value
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


    Public Overrides Property Codice() As String
        Get
            Return MyBase.Codice
        End Get
        Set(ByVal value As String)
            MyBase.Codice = value
        End Set
    End Property


    Public Overrides Property Stato() As Integer
        Get
            Return MyBase.Stato
        End Get
        Set(ByVal value As Integer)
            MyBase.Stato = value
        End Set
    End Property


    Public Overrides Property Percentuale() As Integer
        Get
            Return MyBase.Percentuale
        End Get
        Set(ByVal value As Integer)
            MyBase.Percentuale = value
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


    Public Overrides Property QtaSpecifica() As Integer
        Get
            Return MyBase.QtaSpecifica
        End Get
        Set(ByVal value As Integer)
            MyBase.QtaSpecifica = value
        End Set
    End Property


    Public Overrides Property DataInizioValidita() As DateTime
        Get
            Return MyBase.DataInizioValidita
        End Get
        Set(ByVal value As DateTime)
            MyBase.DataInizioValidita = value
        End Set
    End Property


    Public Overrides Property DataFineValidita() As DateTime
        Get
            Return MyBase.DataFineValidita
        End Get
        Set(ByVal value As DateTime)
            MyBase.DataFineValidita = value
        End Set
    End Property


    Public Overrides Property MaxVolte() As Integer
        Get
            Return MyBase.MaxVolte
        End Get
        Set(ByVal value As Integer)
            MyBase.MaxVolte = value
        End Set
    End Property


    Public Overrides Property RiservatoATipoUtente() As Integer
        Get
            Return MyBase.RiservatoATipoUtente
        End Get
        Set(ByVal value As Integer)
            MyBase.RiservatoATipoUtente = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public ReadOnly Property Pubblicato As String
        Get
            Dim Ris As String = "No"

            If IdCouponOnline Then
                Ris = "Si"
            End If

            Return Ris
        End Get
    End Property

    Public ReadOnly Property SoloPer As String
        Get
            Dim Ris As String = "Tutti"

            Select Case RiservatoATipoUtente
                Case enTipoRubrica.Rivenditore
                    Ris = "Rivenditori"
                Case enTipoRubrica.Cliente
                    Ris = "Clienti"
            End Select

            Return Ris
        End Get
    End Property

    Private _ClienteRif As String = String.Empty
    Public ReadOnly Property ClienteRif As String
        Get
            If _ClienteRif.Length = 0 Then
                If Riservato Then
                    Dim V As New VoceRubrica
                    V.Read(Riservato)
                    _ClienteRif = V.RagSocNome

                Else
                    _ClienteRif = "Per tutti"
                End If
            End If

            Return _ClienteRif
        End Get
    End Property

    Private _ProdottoRif As String = String.Empty
    Public ReadOnly Property ProdottoRif As String
        Get
            If _ProdottoRif.Length = 0 Then
                If IdListinoBase Then
                    _ProdottoRif = QtaSpecifica & " " & L.Riassunto
                Else
                    _ProdottoRif = "Su tutti i prodotti"
                End If
            End If
            Return _ProdottoRif
        End Get
    End Property

    Public ReadOnly Property ImgRif As Image
        Get
            Dim Ris As Image = Nothing
            If IdListinoBase Then

                Select Case L.PrendiIcoDa
                    Case enPrendiIcoDa.Preventivazione
                        Ris = L.Preventivazione.Img
                    Case enPrendiIcoDa.FormatoProdotto
                        Ris = L.ImgFp48
                    Case enPrendiIcoDa.ColoreDiStampa
                        Ris = L.ImgCs48
                    Case enPrendiIcoDa.TipoCarta
                        Ris = L.ImgTc48
                End Select
            End If

            If Ris Is Nothing Then Ris = New Bitmap(My.Resources.no_image, 75, 50)

            Return Ris
        End Get
    End Property

    Private _L As ListinoBase = Nothing
    Public ReadOnly Property L As ListinoBase
        Get
            If IdListinoBase Then
                If _L Is Nothing Then
                    _L = New ListinoBase
                    _L.Read(IdListinoBase)
                End If
            End If
            Return _L

        End Get
    End Property

    Public ReadOnly Property DataInizioValiditaStr As String
        Get
            Return DataInizioValidita.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property DataFineValiditaStr As String
        Get
            Return DataFineValidita.ToString("dd/MM/yyyy")
        End Get
    End Property
#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICoupon.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        If Codice.Length = 0 Then Ris = False

        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICoupon.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICoupon.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_coupon
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICoupon
    Inherits _ICoupon

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface