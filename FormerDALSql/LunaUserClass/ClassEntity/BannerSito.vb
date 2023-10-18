#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.11.2 
'Author: Diego Lunadei
'Date: 28/11/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Imports System.Drawing
Imports System.IO

''' <summary>
'''Entity Class for table Bannersito
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class BannerSito
    Inherits _BannerSito
    Implements IBannerSito

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdBannerSito() As Integer
        Get
            Return MyBase.IdBannerSito
        End Get
        Set(ByVal value As Integer)
            MyBase.IdBannerSito = value
        End Set
    End Property


    Public Overrides Property imgRif() As String
        Get
            Return MyBase.imgRif
        End Get
        Set(ByVal value As String)
            MyBase.imgRif = value
        End Set
    End Property


    Public Overrides Property Url() As String
        Get
            Return MyBase.Url
        End Get
        Set(ByVal value As String)
            MyBase.Url = value
        End Set
    End Property


    Public Overrides Property Alternate() As String
        Get
            Return MyBase.Alternate
        End Get
        Set(ByVal value As String)
            MyBase.Alternate = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public ReadOnly Property StatoStr As String
        Get
            Dim ris As String = "Non Attivo"

            If Stato = enStato.Attivo Then
                ris = "Attivo"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property Img400 As Image
        Get
            Dim ris As Image = Nothing
            If File.Exists(imgRif) Then
                Dim ImgInt As New Bitmap(imgRif)
                Dim ImgNew = New Bitmap(ImgInt, New Size(400, 100))
                Return ImgNew
            End If
            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IBannerSito.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IBannerSito.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IBannerSito.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Bannersito
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IBannerSito
    Inherits _IBannerSito

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface