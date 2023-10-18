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
'''Entity Class for table Td_formatocarta
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class FormatoCartaW
    Inherits _FormatoCartaW
    Implements IFormatoCartaW
    Implements IFormatoCartaB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdFormCarta() As Integer Implements IFormatoCartaB.IdFormCarta
        Get
            Return MyBase.IdFormCarta
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFormCarta = value
        End Set
    End Property


    Public Overrides Property FormatoCarta() As String Implements IFormatoCartaB.FormatoCarta
        Get
            Return MyBase.FormatoCarta
        End Get
        Set(ByVal value As String)
            MyBase.FormatoCarta = value
        End Set
    End Property


    Public Overrides Property Altezza() As Single Implements IFormatoCartaB.Altezza
        Get
            Return MyBase.Altezza
        End Get
        Set(ByVal value As Single)
            MyBase.Altezza = value
        End Set
    End Property

    Public ReadOnly Property LarghezzaMM() As Integer
        Get
            Return Larghezza * 10
        End Get
    End Property

    Public ReadOnly Property AltezzaMM() As Integer
        Get
            Return Altezza * 10
        End Get
    End Property


    Public Overrides Property Larghezza() As Single Implements IFormatoCartaB.Larghezza
        Get
            Return MyBase.Larghezza
        End Get
        Set(ByVal value As Single)
            MyBase.Larghezza = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public ReadOnly Property LatoLungoMM As Integer Implements IFormatoCartaB.LatoLungoMM
        Get
            Return LatoLungo * 10
        End Get
    End Property

    Public ReadOnly Property LatoCortoMM As Integer Implements IFormatoCartaB.LatoCortoMM
        Get
            Return LatoCorto * 10
        End Get
    End Property

    Public ReadOnly Property LatoLungo As Single
        Get
            Dim ris As Single = 0
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

    Public ReadOnly Property LatoCorto As Single
        Get
            Dim ris As Single = 0
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

    Public ReadOnly Property Area() As Single Implements IFormatoCartaB.Area
        Get
            Return Altezza * Larghezza
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IFormatoCartaW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IFormatoCartaW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IFormatoCartaW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_formatocarta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IFormatoCartaW
    Inherits _IFormatoCartaW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface