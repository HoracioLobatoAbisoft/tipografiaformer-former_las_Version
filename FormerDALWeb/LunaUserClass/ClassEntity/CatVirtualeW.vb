#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 23/02/2017 
#End Region




Imports FormerLib
''' <summary>
'''Entity Class for table T_catvirtuali
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class CatVirtualeW
    Inherits _CatVirtualeW
    Implements ICatVirtualeW

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdCatVirtuale() As Integer
        Get
            Return MyBase.IdCatVirtuale
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCatVirtuale = value
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


#End Region

#Region "Logic Field"
    Public ReadOnly Property NomeInUrl() As String
        Get
            Dim _NomeInUrl As String = FormerHelper.Web.NormalizzaUrl(Nome)
            Return _NomeInUrl
        End Get
    End Property

    Public ReadOnly Property ListiniBase As List(Of ListinoBaseW)
        Get
            Dim ris As List(Of ListinoBaseW) = Nothing

            Using mgr As New ListinoBaseWDAO

                ris = mgr.ListiniByCatVirtuale(IdCatVirtuale)

            End Using

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICatVirtualeW.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICatVirtualeW.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICatVirtualeW.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_catvirtuali
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface ICatVirtualeW
    Inherits _ICatVirtualeW

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface