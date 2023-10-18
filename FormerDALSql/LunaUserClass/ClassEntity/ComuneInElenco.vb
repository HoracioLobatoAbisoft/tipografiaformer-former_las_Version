#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.9.1.21131 
'Author: Diego Lunadei
'Date: 28/03/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient

''' <summary>
'''Entity Class for table Elencocomuni
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ComuneInElenco
    Inherits _ComuneInElenco
    Implements IComuneInElenco

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property Comune() As String
        Get
            Return MyBase.Comune
        End Get
        Set(ByVal value As String)
            MyBase.Comune = value
        End Set
    End Property


    Public Overrides Property CAP() As String
        Get
            Return MyBase.CAP
        End Get
        Set(ByVal value As String)
            MyBase.CAP = value
        End Set
    End Property

    Public Overrides Property Provincia() As String
        Get
            Return MyBase.Provincia
        End Get
        Set(ByVal value As String)
            MyBase.Provincia = value
        End Set
    End Property


    Public Overrides Property Regione() As String
        Get
            Return MyBase.Regione
        End Get
        Set(ByVal value As String)
            MyBase.Regione = value
        End Set
    End Property


#End Region

#Region "Logic Field"
    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty
            If IDCap Then
                ris = Comune & " (" & Provincia & ")"
            Else
                ris = "Selezionare una Località"
            End If
            Return ris
        End Get
    End Property

    Private _ProvinciaSel As Provincia = Nothing
    Public ReadOnly Property ProvinciaSel As Provincia
        Get
            If _ProvinciaSel Is Nothing Then
                Using mgr As New ProvinceDAO
                    _ProvinciaSel = mgr.Find(New LUNA.LunaSearchParameter("Cod", Provincia))
                    If _ProvinciaSel Is Nothing Then _ProvinciaSel = New Provincia
                End Using
            End If
            Return _ProvinciaSel
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IComuneInElenco.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IComuneInElenco.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IComuneInElenco.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Elencocomuni
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IComuneInElenco
    Inherits _IComuneInElenco

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface