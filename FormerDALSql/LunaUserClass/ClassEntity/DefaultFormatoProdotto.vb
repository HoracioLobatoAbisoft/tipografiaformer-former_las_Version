#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 13/01/2017 
#End Region



''' <summary>
'''Entity Class for table Tr_defaultformatoprev
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class DefaultFormatoProdotto
    Inherits _DefaultFormatoProdotto
    Implements IDefaultFormatoProdotto

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdDefaultFormatoPrev() As Integer
        Get
            Return MyBase.IdDefaultFormatoPrev
        End Get
        Set(ByVal value As Integer)
            MyBase.IdDefaultFormatoPrev = value
        End Set
    End Property


    Public Overrides Property IdFormatoProdotto() As Integer
        Get
            Return MyBase.IdFormatoProdotto
        End Get
        Set(ByVal value As Integer)
            MyBase.IdFormatoProdotto = value
        End Set
    End Property


    Public Overrides Property IdPreventivazione() As Integer
        Get
            Return MyBase.IdPreventivazione
        End Get
        Set(ByVal value As Integer)
            MyBase.IdPreventivazione = value
        End Set
    End Property


    Public Overrides Property IdCatFormatoProdotto() As Integer
        Get
            Return MyBase.IdCatFormatoProdotto
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCatFormatoProdotto = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty

            ris = P.Descrizione & " -> " & FP.Formato

            Return ris
        End Get
    End Property

    Private _Fp As FormatoProdotto = Nothing
    Public ReadOnly Property FP As FormatoProdotto
        Get
            If _Fp Is Nothing Then
                _Fp = New FormatoProdotto
                _Fp.Read(IdFormatoProdotto)
            End If

            Return _Fp
        End Get
    End Property

    Private _P As Preventivazione = Nothing
    Public ReadOnly Property P As Preventivazione
        Get
            If _P Is Nothing Then
                _P = New Preventivazione
                _P.Read(IdPreventivazione)
            End If

            Return _P
        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IDefaultFormatoProdotto.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IDefaultFormatoProdotto.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IDefaultFormatoProdotto.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return Riassunto
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Tr_defaultformatoprev
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IDefaultFormatoProdotto
    Inherits _IDefaultFormatoProdotto

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface