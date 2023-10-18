#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 23/02/2017 
#End Region



''' <summary>
'''Entity Class for table T_catvirtuali
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class CatVirtuale
    Inherits _CatVirtuale
    Implements ICatVirtuale

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

    Public ReadOnly Property ListiniBase As List(Of ListinoBase)
        Get

            Dim l As List(Of ListinoBase) = Nothing
            Using mgr As New ListinoBaseDAO
                l = mgr.ListiniByCatVirtuale(IdCatVirtuale, False)
            End Using
            Return l

        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements ICatVirtuale.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements ICatVirtuale.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements ICatVirtuale.Save
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

Public Interface ICatVirtuale
    Inherits _ICatVirtuale

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface