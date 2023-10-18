#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 30/08/2018 
#End Region



''' <summary>
'''Entity Class for table T_ordiniacquisto
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class OrdineAcquisto
    Inherits _OrdineAcquisto
    Implements IOrdineAcquisto

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdOrdineAcquisto() As Integer
        Get
            Return MyBase.IdOrdineAcquisto
        End Get
        Set(ByVal value As Integer)
            MyBase.IdOrdineAcquisto = value
        End Set
    End Property


    Public Overrides Property Annotazioni() As String
        Get
            Return MyBase.Annotazioni
        End Get
        Set(ByVal value As String)
            MyBase.Annotazioni = value
        End Set
    End Property


    Public Overrides Property IdUt() As Integer
        Get
            Return MyBase.IdUt
        End Get
        Set(ByVal value As Integer)
            MyBase.IdUt = value
        End Set
    End Property


    Public Overrides Property Quando() As DateTime
        Get
            Return MyBase.Quando
        End Get
        Set(ByVal value As DateTime)
            MyBase.Quando = value
        End Set
    End Property


    Public Overrides Property Stato() As Integer
        Get
            Return MyBase.Stato
        End Get
        Set(ByVal value As Integer)
            MyBase.Stato = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public ReadOnly Property DataMov As String
        Get
            Return Quando.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property OperatoreStr As String
        Get
            Dim ris As String = String.Empty

            If IdUt Then
                Using o As New Utente
                    o.Read(IdUt)
                    ris = o.Login
                End Using
            End If
            Return ris
        End Get
    End Property
    
    Public ReadOnly Property Richieste As List(Of MovimentoMagazzino)
        Get
            Dim ris As List(Of MovimentoMagazzino)

            Using mgr As New MagazzinoDAO
                ris = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "IdForn,DataMov DESC"},
                                    New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdOrdineAcquisto, IdOrdineAcquisto))
            End Using

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IOrdineAcquisto.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IOrdineAcquisto.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IOrdineAcquisto.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''Interface for table T_ordiniacquisto
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IOrdineAcquisto
    Inherits _IOrdineAcquisto

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface