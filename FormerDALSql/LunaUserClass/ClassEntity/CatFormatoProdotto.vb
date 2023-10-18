#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 03/11/2016 
#End Region

Imports System.Drawing
Imports System.IO
''' <summary>
'''Entity Class for table Td_catformatoprodotto
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class CatFormatoProdotto
    Inherits _CatFormatoProdotto
    Implements ICatFormatoProdotto

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdCatFormatoProdotto() As Integer
        Get
            Return MyBase.IdCatFormatoProdotto
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCatFormatoProdotto = value
        End Set
    End Property


    Public Overrides Property Nome() As String
        Get
            Return MyBase.Nome
        End Get
        Set(ByVal value As String)
            MyBase.Nome = value
        End Set
    End Property


    Public Overrides Property ImgRif() As String
        Get
            Return MyBase.ImgRif
        End Get
        Set(ByVal value As String)
            MyBase.ImgRif = value
        End Set
    End Property


    Public Overrides Property DescrizioneEstesa() As String
        Get
            Return MyBase.DescrizioneEstesa
        End Get
        Set(ByVal value As String)
            MyBase.DescrizioneEstesa = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Private _Formati As List(Of FormatoProdotto) = Nothing
    Public ReadOnly Property Formati(Optional ForceLoad As Boolean = False) As List(Of FormatoProdotto)
        Get
            If _Formati Is Nothing Or ForceLoad Then
                Using mgr As New FormatiProdottoDAO
                    _Formati = mgr.FindAll(New LUNA.LunaSearchParameter("IdCatFormatoProdotto", IdCatFormatoProdotto))
                End Using
            End If
            Return _Formati

        End Get
    End Property

    Private _DefaultPreventivazione As List(Of DefaultFormatoProdotto) = Nothing
    Public ReadOnly Property DefaultPreventivazione(Optional ForceLoad As Boolean = False) As List(Of DefaultFormatoProdotto)
        Get
            If _DefaultPreventivazione Is Nothing Or ForceLoad Then
                Using mgr As New DefaultFormatoProdottoDAO
                    _DefaultPreventivazione = mgr.FindAll(New LUNA.LunaSearchParameter("IdCatFormatoProdotto", IdCatFormatoProdotto))
                End Using
            End If
            Return _DefaultPreventivazione

        End Get
    End Property

    Public ReadOnly Property FormatiContenutiStr As String
        Get
            Dim ris As String = String.Empty

            For Each FP As FormatoProdotto In Formati
                ris &= FP.Formato & ControlChars.NewLine
            Next

            Return ris
        End Get
    End Property

    Public ReadOnly Property Img As Image
        Get
            Dim ris As Image = Nothing
            If _ImgRif.Length Then
                If File.Exists(_ImgRif) Then
                    Try
                        ris = Image.FromFile(_ImgRif)
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

    Public Overrides Function IsValid() As Boolean Implements ICatFormatoProdotto.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        If Ris Then
            If Nome.Length = 0 Then
                Ris = False
            End If

        End If

        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICatFormatoProdotto.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICatFormatoProdotto.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Td_catformatoprodotto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICatFormatoProdotto
    Inherits _ICatFormatoProdotto

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface