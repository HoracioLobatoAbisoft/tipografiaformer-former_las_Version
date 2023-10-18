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
'''Entity Class for table T_macchinari
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class MacchinarioW
    Inherits _MacchinarioW
    Implements IMacchinarioW
    Implements IMacchinarioB

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdMacchinario() As Integer Implements IMacchinarioB.IdMacchinario
        Get
            Return MyBase.IdMacchinario
        End Get
        Set(ByVal value As Integer)
            MyBase.IdMacchinario = value
        End Set
    End Property

    Public Overrides Property IdRepartoDefault() As Integer Implements IMacchinarioB.IdRepartoDefault
        Get
            Return MyBase.IdRepartoDefault
        End Get
        Set(ByVal value As Integer)
            MyBase.IdRepartoDefault = value
        End Set
    End Property
    Public Overrides Property Descrizione() As String Implements IMacchinarioB.Descrizione
        Get
            Return MyBase.Descrizione
        End Get
        Set(ByVal value As String)
            MyBase.Descrizione = value
        End Set
    End Property


    Public Overrides Property Tipo() As Integer Implements IMacchinarioB.Tipo
        Get
            Return MyBase.Tipo
        End Get
        Set(ByVal value As Integer)
            MyBase.Tipo = value
        End Set
    End Property


    Public Overrides Property CostoMinAvv() As Decimal Implements IMacchinarioB.CostoMinAvv
        Get
            Return MyBase.CostoMinAvv
        End Get
        Set(ByVal value As Decimal)
            MyBase.CostoMinAvv = value
        End Set
    End Property


    Public Overrides Property CostoSingCopia() As Decimal Implements IMacchinarioB.CostoSingCopia
        Get
            Return MyBase.CostoSingCopia
        End Get
        Set(ByVal value As Decimal)
            MyBase.CostoSingCopia = value
        End Set
    End Property


    Public Overrides Property CostoMensile() As Integer Implements IMacchinarioB.CostoMensile
        Get
            Return MyBase.CostoMensile
        End Get
        Set(ByVal value As Integer)
            MyBase.CostoMensile = value
        End Set
    End Property


    Public Overrides Property CaricoPrevistoMensile() As Integer Implements IMacchinarioB.CaricoPrevistoMensile
        Get
            Return MyBase.CaricoPrevistoMensile
        End Get
        Set(ByVal value As Integer)
            MyBase.CaricoPrevistoMensile = value
        End Set
    End Property


    Public Overrides Property MinutiAvv() As Integer Implements IMacchinarioB.MinutiAvv
        Get
            Return MyBase.MinutiAvv
        End Get
        Set(ByVal value As Integer)
            MyBase.MinutiAvv = value
        End Set
    End Property


    Public Overrides Property CopieOra() As Integer Implements IMacchinarioB.CopieOra
        Get
            Return MyBase.CopieOra
        End Get
        Set(ByVal value As Integer)
            MyBase.CopieOra = value
        End Set
    End Property


    Public Overrides Property ImgRif() As String Implements IMacchinarioB.ImgRif
        Get
            Return MyBase.ImgRif
        End Get
        Set(ByVal value As String)
            MyBase.ImgRif = value
        End Set
    End Property


    Public Overrides Property AltezzaCaricoCm() As Integer Implements IMacchinarioB.AltezzaCaricoCm
        Get
            Return MyBase.AltezzaCaricoCm
        End Get
        Set(ByVal value As Integer)
            MyBase.AltezzaCaricoCm = value
        End Set
    End Property


#End Region

#Region "Logic Field"
    Public ReadOnly Property DescrizioneEx As String
        Get
            Dim ris As String = String.Empty
            If DescrizioneOnline.Length Then
                ris = DescrizioneOnline
            Else
                ris = Descrizione
            End If

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IMacchinarioW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IMacchinarioW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IMacchinarioW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_macchinari
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IMacchinarioW
    Inherits _IMacchinarioW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface