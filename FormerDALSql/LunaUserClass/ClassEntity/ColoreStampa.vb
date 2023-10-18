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
Imports System.Drawing
Imports System.IO
Imports FormerBusinessLogicInterface

''' <summary>
'''Entity Class for table Td_coloristampa
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ColoreStampa
    Inherits _ColoreStampa
    Implements IColoreStampa
    Implements IColoreStampaB, ICloneable

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Overrides Property IdColoreStampa() As Integer Implements IColoreStampaB.IdColoreStampa
        Get
            Return MyBase.IdColoreStampa
        End Get
        Set(ByVal value As Integer)
            MyBase.IdColoreStampa = value
        End Set
    End Property


    Public Overrides Property Sigla() As String Implements IColoreStampaB.Sigla
        Get
            Return MyBase.Sigla
        End Get
        Set(ByVal value As String)
            MyBase.Sigla = value
        End Set
    End Property


    Public Overrides Property Descrizione() As String Implements IColoreStampaB.Descrizione
        Get
            Return MyBase.Descrizione
        End Get
        Set(ByVal value As String)
            MyBase.Descrizione = value
        End Set
    End Property


    Public Overrides Property FR() As Boolean Implements IColoreStampaB.FR
        Get
            Return MyBase.FR
        End Get
        Set(ByVal value As Boolean)
            MyBase.FR = value
        End Set
    End Property


    Public Overrides Property NLastre() As Integer Implements IColoreStampaB.NLastre
        Get
            Return MyBase.NLastre
        End Get
        Set(ByVal value As Integer)
            MyBase.NLastre = value
        End Set
    End Property


    Public Overrides Property imgrif() As String Implements IColoreStampaB.imgrif
        Get
            Return MyBase.imgrif
        End Get
        Set(ByVal value As String)
            MyBase.imgrif = value
        End Set
    End Property


#End Region

#Region "Logic Field"
    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = ""
            ris = _Descrizione
            Return ris
        End Get
    End Property

    Public ReadOnly Property Img As Image
        Get
            Dim ris As Image = Nothing
            If _imgrif.Length Then
                If File.Exists(_imgrif) Then
                    Try
                        ris = Image.FromFile(_imgrif)
                    Catch ex As Exception

                    End Try
                End If
            Else
                ris = My.Resources.no_image

            End If
            Return ris
        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IColoreStampa.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IColoreStampa.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IColoreStampa.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return Descrizione & " (Numero Lastre: " & NLastre & ")"
    End Function

#End Region

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class



''' <summary>
'''Interface for table Td_coloristampa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IColoreStampa
    Inherits _IColoreStampa

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface