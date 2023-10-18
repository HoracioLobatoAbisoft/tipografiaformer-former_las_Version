#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.15.11.31 
'Author: Diego Lunadei
'Date: 05/05/2016 
#End Region

''' <summary>
'''Entity Class for table T_azionisottoscorta
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class AzioneSottoscorta
    Inherits _AzioneSottoscorta
    Implements IAzioneSottoscorta

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"

    Public Overrides Property IdRegola() As Integer
        Get
            Return MyBase.IdRegola
        End Get
        Set(ByVal value As Integer)
            MyBase.IdRegola = value
        End Set
    End Property

    Public Overrides Property IdRisorsa() As Integer
        Get
            Return MyBase.IdRisorsa
        End Get
        Set(ByVal value As Integer)
            MyBase.IdRisorsa = value
        End Set
    End Property

    Public Overrides Property Azione() As Integer
        Get
            Return MyBase.Azione
        End Get
        Set(ByVal value As Integer)
            MyBase.Azione = value
        End Set
    End Property

    Public Overrides Property IdDestMessaggio() As Integer
        Get
            Return MyBase.IdDestMessaggio
        End Get
        Set(ByVal value As Integer)
            MyBase.IdDestMessaggio = value
        End Set
    End Property

    Public Overrides Property StampareReminder() As Integer
        Get
            Return MyBase.StampareReminder
        End Get
        Set(ByVal value As Integer)
            MyBase.StampareReminder = value
        End Set
    End Property

    Public Overrides Property IdListinoBase() As Integer
        Get
            Return MyBase.IdListinoBase
        End Get
        Set(ByVal value As Integer)
            MyBase.IdListinoBase = value
        End Set
    End Property

    Public Overrides Property QtaOrdine() As Integer
        Get
            Return MyBase.QtaOrdine
        End Get
        Set(ByVal value As Integer)
            MyBase.QtaOrdine = value
        End Set
    End Property

    Public Overrides Property PathFile() As String
        Get
            Return MyBase.PathFile
        End Get
        Set(ByVal value As String)
            MyBase.PathFile = value
        End Set
    End Property

#End Region

#Region "Logic Field"

    Private _Risorsa As Risorsa = Nothing
    Public ReadOnly Property Risorsa As Risorsa
        Get
            If _Risorsa Is Nothing Then
                _Risorsa = New Risorsa
                _Risorsa.Read(IdRisorsa)
            End If
            Return _Risorsa
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IAzioneSottoscorta.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IAzioneSottoscorta.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IAzioneSottoscorta.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''Interface for table T_azionisottoscorta
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IAzioneSottoscorta
    Inherits _IAzioneSottoscorta

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface