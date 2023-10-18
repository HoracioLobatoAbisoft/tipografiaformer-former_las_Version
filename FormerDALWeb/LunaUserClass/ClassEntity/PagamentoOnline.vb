#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 03/04/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
                
''' <summary>
'''Entity Class for table Pagamentionline
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class PagamentoOnline
	Inherits _PagamentoOnline
    Implements IPagamentoOnline

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


Public Overrides Property IdPagamentoOnline() as integer
    Get
	    Return MyBase.IdPagamentoOnline
    End Get
    Set (byval value as integer)
        MyBase.IdPagamentoOnline= value
    End Set
End property 


Public Overrides Property IdPagInt() as integer
    Get
	    Return MyBase.IdPagInt
    End Get
    Set (byval value as integer)
        MyBase.IdPagInt= value
    End Set
End property 


Public Overrides Property IdUt() as integer
    Get
	    Return MyBase.IdUt
    End Get
    Set (byval value as integer)
        MyBase.IdUt= value
    End Set
End property 


Public Overrides Property Quando() as DateTime
    Get
	    Return MyBase.Quando
    End Get
    Set (byval value as DateTime)
        MyBase.Quando= value
    End Set
End property 


Public Overrides Property IdConsegna() as integer
    Get
	    Return MyBase.IdConsegna
    End Get
    Set (byval value as integer)
        MyBase.IdConsegna= value
    End Set
End property 


Public Overrides Property IdTipoPagamento() as integer
    Get
	    Return MyBase.IdTipoPagamento
    End Get
    Set (byval value as integer)
        MyBase.IdTipoPagamento= value
    End Set
End property 

    Public Overrides Property Importo() As Decimal
        Get
            Return MyBase.Importo
        End Get
        Set(ByVal value As Decimal)
            MyBase.Importo = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Private _TipoPagamento As TipoPagamentoW = Nothing
    Public ReadOnly Property TipoPagamento As TipoPagamentoW
        Get
            If _TipoPagamento Is Nothing Then
                _TipoPagamento = New TipoPagamentoW
                _TipoPagamento.Read(IdTipoPagamento)
            End If
            Return _TipoPagamento
        End Get
    End Property


#End Region

#Region "Method"

Public Overrides Function IsValid() As Boolean Implements IPagamentoOnline.IsValid
	'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
	'RETURN FALSE IF LOGIC CONTROL FAIL
	'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
	Dim Ris As Boolean = InternalIsValid
	'PUT YOUR LOGIC VALIDATION CODE HERE
	Return Ris
End Function

Public Overrides Function Read(Id As Integer) As Integer Implements IPagamentoOnline.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements IPagamentoOnline.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Pagamentionline
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IPagamentoOnline
        Inherits _IPagamentoOnline

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface