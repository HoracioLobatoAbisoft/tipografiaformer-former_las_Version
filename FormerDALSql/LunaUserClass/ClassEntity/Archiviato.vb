#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.6.16 
'Author: Diego Lunadei
'Date: 26/06/2017 
#End Region




Imports FormerDALSql
''' <summary>
'''Entity Class for table Archivi
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class Archiviato
    Inherits _Archiviato
    Implements IArchiviato

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

    Public Sub New(O As Ordine)

        'qui creo l'oggetto a partire da un ordine riempiendo solo le proprieta necessarie
        IdProd = O.IdProd
        DataIns = O.DataIns
        Qta = O.Qta
        TotaleForn = O.TotaleForn
        Sconto = O.Sconto
        Ricarico = O.Ricarico
        IdCorriere = O.IdCorriere
        IdListinoBase = O.IdListinoBase
        Sorgente = O.SorgenteCliente

    End Sub

#Region "Database Field"


    Public Overrides Property IdArchivio() As Integer
        Get
            Return MyBase.IdArchivio
        End Get
        Set(ByVal value As Integer)
            MyBase.IdArchivio = value
        End Set
    End Property


    Public Overrides Property IdProd() As Integer
        Get
            Return MyBase.IdProd
        End Get
        Set(ByVal value As Integer)
            MyBase.IdProd = value
        End Set
    End Property


    Public Overrides Property DataIns() As DateTime
        Get
            Return MyBase.DataIns
        End Get
        Set(ByVal value As DateTime)
            MyBase.DataIns = value
        End Set
    End Property


    Public Overrides Property Qta() As Integer
        Get
            Return MyBase.Qta
        End Get
        Set(ByVal value As Integer)
            MyBase.Qta = value
        End Set
    End Property


    Public Overrides Property TotaleForn() As Decimal
        Get
            Return MyBase.TotaleForn
        End Get
        Set(ByVal value As Decimal)
            MyBase.TotaleForn = value
        End Set
    End Property


    Public Overrides Property Sconto() As Decimal
        Get
            Return MyBase.Sconto
        End Get
        Set(ByVal value As Decimal)
            MyBase.Sconto = value
        End Set
    End Property


    Public Overrides Property Ricarico() As Decimal
        Get
            Return MyBase.Ricarico
        End Get
        Set(ByVal value As Decimal)
            MyBase.Ricarico = value
        End Set
    End Property


    Public Overrides Property IdCorriere() As Integer
        Get
            Return MyBase.IdCorriere
        End Get
        Set(ByVal value As Integer)
            MyBase.IdCorriere = value
        End Set
    End Property

#End Region

#Region "Logic Field"


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IArchiviato.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IArchiviato.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IArchiviato.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table Archivi
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IArchiviato
    Inherits _IArchiviato

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface