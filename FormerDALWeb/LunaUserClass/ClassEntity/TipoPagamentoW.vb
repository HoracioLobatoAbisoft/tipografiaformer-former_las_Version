#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 25/03/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerBusinessLogicInterface

''' <summary>
'''Entity Class for table Td_tipopagamenti
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class TipoPagamentoW
	Inherits _TipoPagamentoW
    Implements ITipoPagamentoW
    Implements ITipoPagamentoBusiness
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord as IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdTipoPagam() As Integer Implements ITipoPagamentoBusiness.IdTipoPagamento
        Get
            Return MyBase.IdTipoPagam
        End Get
        Set(ByVal value As Integer)
            MyBase.IdTipoPagam = value
        End Set
    End Property


Public Overrides Property TipoPagam() as string
    Get
	    Return MyBase.TipoPagam
    End Get
    Set (byval value as string)
        MyBase.TipoPagam= value
    End Set
End property 


Public Overrides Property ModoPagam() as string
    Get
	    Return MyBase.ModoPagam
    End Get
    Set (byval value as string)
        MyBase.ModoPagam= value
    End Set
End property 


Public Overrides Property ggToAdd() as integer
    Get
	    Return MyBase.ggToAdd
    End Get
    Set (byval value as integer)
        MyBase.ggToAdd= value
    End Set
End property 


    Public Overrides Property PeriodoPagam() As Integer Implements ITipoPagamentoBusiness.PeriodoPagamento
        Get
            Return MyBase.PeriodoPagam
        End Get
        Set(ByVal value As Integer)
            MyBase.PeriodoPagam = value
        End Set
    End Property


    Public Overrides Property ImportoMaggiorazione() As Decimal Implements ITipoPagamentoBusiness.ImportoMaggiorazione
        Get
            Return MyBase.ImportoMaggiorazione
        End Get
        Set(ByVal value As Decimal)
            MyBase.ImportoMaggiorazione = value
        End Set
    End Property


    Public Overrides Property ImportoMassimoPagabile() As Decimal
        Get
            Return MyBase.ImportoMassimoPagabile
        End Get
        Set(ByVal value As Decimal)
            MyBase.ImportoMassimoPagabile = value
        End Set
    End Property


#End Region

#Region "Logic Field"


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ITipoPagamentoW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

Public Overrides Function Read(Id As Integer) As Integer Implements ITipoPagamentoW.Read
	Dim Ris as integer = MyBase.Read(Id)
    Return Ris
End Function

Public Overrides Function Save() As Integer Implements ITipoPagamentoW.Save
	Dim Ris as integer = MyBase.Save()
    Return Ris
End Function

Public Overrides Function ToString() As String
	Return MyBase.ToString()
End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_tipopagamenti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ITipoPagamentoW
        Inherits _ITipoPagamentoW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface