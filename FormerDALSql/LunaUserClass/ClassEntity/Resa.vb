#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerBusinessLogicInterface

''' <summary>
'''Entity Class for table Tr_resa
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Resa
    Inherits _Resa
    Implements IResa
    Implements IResaB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IDFormatoResa() As Integer Implements IResaB.IDFormatoResa
        Get
            Return MyBase.IDFormatoResa
        End Get
        Set(ByVal value As Integer)
            MyBase.IDFormatoResa = value
        End Set
    End Property


    Public Overrides Property IdFormCarta() As Integer Implements IResaB.IdFormCarta
        Get
            Return MyBase.IdFormCarta
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFormCarta = value
        End Set
    End Property


    Public Overrides Property IdFormato() As Integer Implements IResaB.IdFormato
        Get
            Return MyBase.IdFormato
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFormato = value
        End Set
    End Property


    Public Overrides Property Resa() As Integer Implements IResaB.Resa
        Get
            Return MyBase.Resa
        End Get
        Set(ByVal value As Integer)
            MyBase.Resa = value
        End Set
    End Property


    Public Overrides Property PercScarto() As Integer Implements IResaB.PercScarto
        Get
            Return MyBase.PercScarto
        End Get
        Set(ByVal value As Integer)
            MyBase.PercScarto = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public ReadOnly Property FormatoCartaB As IFormatoCartaB Implements IResaB.FormatoCarta
        Get
            Return FormatoCarta
        End Get
    End Property

    Private _FmStr As String = ""
    Public ReadOnly Property FmStr As String
        Get
            Dim Ris As String = String.Empty
            If _FmStr.Length = 0 Then
                Dim Fc As New Formato
                Fc.Read(_IdFormato)
                _FmStr = Fc.Formato
            End If
            Ris = _FmStr
            Return Ris
        End Get
    End Property

    Private _FcStr As String = ""
    Public ReadOnly Property FcStr As String
        Get
            Dim Ris As String = String.Empty
            If _FcStr.Length = 0 Then
                _FcStr = FormatoCarta.FormatoCarta
            End If
            Ris = _FcStr
            Return Ris
        End Get
    End Property

    Private _FormatoCarta As FormatoCarta = Nothing
    Public ReadOnly Property FormatoCarta As FormatoCarta
        Get
            If _FormatoCarta Is Nothing Then
                _FormatoCarta = New FormatoCarta
                _FormatoCarta.Read(IdFormCarta)
            End If
            Return _FormatoCarta
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IResa.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        If Resa = 0 Then Ris = False
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IResa.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IResa.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Tr_resa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IResa
    Inherits _IResa

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface