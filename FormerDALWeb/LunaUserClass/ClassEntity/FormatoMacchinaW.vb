#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.3.46.21861 
'Author: Diego Lunadei
'Date: 13/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerBusinessLogicInterface
''' <summary>
'''Entity Class for table Td_formato
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class FormatoMacchinaW
    Inherits _FormatoMacchinaW
    Implements IFormatoMacchinaW
    Implements IFormatoB
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdFormato() As Integer Implements IFormatoB.IdFormato
        Get
            Return MyBase.IdFormato
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFormato = value
        End Set
    End Property


    Public Overrides Property Formato() As String Implements IFormatoB.Formato
        Get
            Return MyBase.Formato
        End Get
        Set(ByVal value As String)
            MyBase.Formato = value
        End Set
    End Property


    Public Overrides Property DivisioneFoglio() As Integer Implements IFormatoB.DivisioneFoglio
        Get
            Return MyBase.DivisioneFoglio
        End Get
        Set(ByVal value As Integer)
            MyBase.DivisioneFoglio = value
        End Set
    End Property


    Public Overrides Property Altezza() As Integer Implements IFormatoB.Altezza
        Get
            Return MyBase.Altezza
        End Get
        Set(ByVal value As Integer)
            MyBase.Altezza = value
        End Set
    End Property


    Public Overrides Property Larghezza() As Integer Implements IFormatoB.Larghezza
        Get
            Return MyBase.Larghezza
        End Get
        Set(ByVal value As Integer)
            MyBase.Larghezza = value
        End Set
    End Property


    Public Overrides Property CostoLastra() As Decimal Implements IFormatoB.CostoLastra
        Get
            Return MyBase.CostoLastra
        End Get
        Set(ByVal value As Decimal)
            MyBase.CostoLastra = value
        End Set
    End Property


    Public Overrides Property IdMacchinario() As Integer Implements IFormatoB.IdMacchinario
        Get
            Return MyBase.IdMacchinario
        End Get
        Set(ByVal value As Integer)
            MyBase.IdMacchinario = value
        End Set
    End Property


    Public Overrides Property ImgRif() As String Implements IFormatoB.ImgRif
        Get
            Return MyBase.ImgRif
        End Get
        Set(ByVal value As String)
            MyBase.ImgRif = value
        End Set
    End Property

#End Region

#Region "Logic Field"

    Public ReadOnly Property LatoLungoMM As Integer Implements IFormatoB.LatoLungoMM
        Get
            Return LatoLungo * 10
        End Get
    End Property

    Public ReadOnly Property LatoCortoMM As Integer Implements IFormatoB.LatoCortoMM
        Get
            Return LatoCorto * 10
        End Get
    End Property

    Public ReadOnly Property LatoLungo As Integer
        Get
            Dim ris As Integer = 0
            If Larghezza > Altezza Then
                ris = Larghezza
            ElseIf Larghezza < Altezza Then
                ris = Altezza
            Else
                ris = Altezza
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property LatoCorto As Integer
        Get
            Dim ris As Integer = 0
            If Larghezza < Altezza Then
                ris = Larghezza
            ElseIf Larghezza > Altezza Then
                ris = Altezza
            Else
                ris = Altezza
            End If

            Return ris
        End Get
    End Property

    'Public ReadOnly Property MacchinarioB As IMacchinarioB Implements IFormatoB.Macchinario
    '    Get
    '        Return Macchinario
    '    End Get
    'End Property

    'Private _Macchinario As MacchinarioW = Nothing
    'Public ReadOnly Property Macchinario As MacchinarioW
    '    Get
    '        If _Macchinario Is Nothing Then
    '            _Macchinario = New MacchinarioW
    '            _Macchinario.Read(IdMacchinario)
    '        End If
    '        Return _Macchinario
    '    End Get
    'End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IFormatoMacchinaW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IFormatoMacchinaW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IFormatoMacchinaW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_formato
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFormatoMacchinaW
    Inherits _IFormatoMacchinaW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface