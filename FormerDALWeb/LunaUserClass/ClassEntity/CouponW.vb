#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 28/04/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table T_coupon
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CouponW
	Inherits _CouponW
    Implements ICouponW

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdCoupon() as integer
    Get
	    Return MyBase.IdCoupon
    End Get
    Set (byval value as integer)
        MyBase.IdCoupon= value
    End Set
End property 


Public Overrides Property Nome() as string
    Get
	    Return MyBase.Nome
    End Get
    Set (byval value as string)
        MyBase.Nome= value
    End Set
End property 


Public Overrides Property Codice() as string
    Get
	    Return MyBase.Codice
    End Get
    Set (byval value as string)
        MyBase.Codice= value
    End Set
End property 


Public Overrides Property Stato() as integer
    Get
	    Return MyBase.Stato
    End Get
    Set (byval value as integer)
        MyBase.Stato= value
    End Set
End property 


Public Overrides Property Percentuale() as integer
    Get
	    Return MyBase.Percentuale
    End Get
    Set (byval value as integer)
        MyBase.Percentuale= value
    End Set
End property 


Public Overrides Property IdListinoBase() as integer
    Get
	    Return MyBase.IdListinoBase
    End Get
    Set (byval value as integer)
        MyBase.IdListinoBase= value
    End Set
End property 


Public Overrides Property QtaSpecifica() as integer
    Get
	    Return MyBase.QtaSpecifica
    End Get
    Set (byval value as integer)
        MyBase.QtaSpecifica= value
    End Set
End property 


Public Overrides Property DataInizioValidita() as DateTime
    Get
	    Return MyBase.DataInizioValidita
    End Get
    Set (byval value as DateTime)
        MyBase.DataInizioValidita= value
    End Set
End property 


Public Overrides Property DataFineValidita() as DateTime
    Get
	    Return MyBase.DataFineValidita
    End Get
    Set (byval value as DateTime)
        MyBase.DataFineValidita= value
    End Set
End property 


Public Overrides Property MaxVolte() as integer
    Get
	    Return MyBase.MaxVolte
    End Get
    Set (byval value as integer)
        MyBase.MaxVolte= value
    End Set
End property 


Public Overrides Property RiservatoATipoUtente() as integer
    Get
	    Return MyBase.RiservatoATipoUtente
    End Get
    Set (byval value as integer)
        MyBase.RiservatoATipoUtente= value
    End Set
End property 


Public Overrides Property VisibileOnline() as integer
    Get
	    Return MyBase.VisibileOnline
    End Get
    Set (byval value as integer)
        MyBase.VisibileOnline= value
    End Set
End property 


Public Overrides Property ImgOnline() as string
    Get
	    Return MyBase.ImgOnline
    End Get
    Set (byval value as string)
        MyBase.ImgOnline= value
    End Set
End property 


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

    Public Property Utilizzati As Integer = 0

    Public ReadOnly Property Disponibili As Integer
        Get
            Return MaxVolte - Utilizzati
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty

            If QtaSpecifica Then
                ris &= QtaSpecifica & " "
            End If

            If IdListinoBase Then
                ris &= ListinoBase.Nome
            Else
                ris &= "Qualsiasi Prodotto del nostro listino"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property ScontoStr As String
        Get
            Dim ris As String = String.Empty
            If Percentuale Then
                ris = " del " & Percentuale & "%"
            Else
                ris = " di € " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(ImportoFisso)
            End If
            Return ris
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

Public Overrides Function IsValid() As Boolean Implements ICouponW.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ICouponW.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ICouponW.Save
	Dim Ris as integer = MyBase.Save()
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

Public Interface ICouponW
        Inherits _ICouponW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface