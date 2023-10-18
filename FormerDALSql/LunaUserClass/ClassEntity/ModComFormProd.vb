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
Imports System.IO
Imports System.Drawing

''' <summary>
'''Entity Class for table Tr_modcomformp
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ModComFormProd
    Inherits _ModComFormProd
    Implements IModComFormProd

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Private _ImgFormProd As Image = Nothing
    Public ReadOnly Property ImgFormProd As Image
        Get
            If _ImgFormProd Is Nothing Then
                Dim Fp As New FormatoProdottoEx
                Fp.Read(_IdFormProd)
                Dim imgRif As Image = Fp.Img
                If Not imgRif Is Nothing Then

                    Dim ImgInt As New Bitmap(imgRif)

                    Dim width As Integer = 0, height As Integer = 0
                    width = 64
                    height = 64
                    Dim ImgNew = New Bitmap(ImgInt, New Size(width, height))
                    _ImgFormProd = ImgNew

                End If

            End If
            Return _ImgFormProd
        End Get
    End Property

    Private _FormatoProdotto As FormatoProdotto = Nothing
    Public ReadOnly Property FormatoProdotto As FormatoProdotto
        Get
            If _FormatoProdotto Is Nothing Then
                Dim Fp As New FormatoProdotto
                Fp.Read(_IdFormProd)
                _FormatoProdotto = Fp
            End If
            Return _FormatoProdotto
        End Get
    End Property

    Private _FPStr As String = String.Empty
    Public ReadOnly Property FPStr As String
        Get
            If _FPStr.Length = 0 Then
                Dim Fp As New FormatoProdotto
                Fp.Read(_IdFormProd)
                _FPStr = Fp.Formato
            End If
            Return _FPStr
        End Get
    End Property

    Public ReadOnly Property RangeStr As String
        Get
            Return _RangeMin & " - " & _RangeMax
        End Get
    End Property

    Public ReadOnly Property OrientamentoStr As String
        Get
            Dim ris As String = String.Empty

            ris = FormerLib.FormerEnum.FormerEnumHelper.OrientamentoStr(Orientamento)

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IModComFormProd.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        If Spazi = 0 Then Ris = False
        If RangeMax < RangeMin Then Ris = False
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IModComFormProd.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IModComFormProd.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''Interface for table Tr_modcomformp
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IModComFormProd
    Inherits _IModComFormProd

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface