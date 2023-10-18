#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.51 
'Author: Diego Lunadei
'Date: 05/01/2018 
#End Region




Imports System.Drawing
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table Daemonlog
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>
Public Class DaemonLog
    Inherits _DaemonLog
    Implements IDaemonLog

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Database Field"


    Public Overrides Property IdDaemonLog() As Integer
        Get
            Return MyBase.IdDaemonLog
        End Get
        Set(ByVal value As Integer)
            MyBase.IdDaemonLog = value
        End Set
    End Property


    Public Overrides Property Descrizione() As String
        Get
            Return MyBase.Descrizione
        End Get
        Set(ByVal value As String)
            MyBase.Descrizione = value
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


    Public Overrides Property Servizio() As Integer
        Get
            Return MyBase.Servizio
        End Get
        Set(ByVal value As Integer)
            MyBase.Servizio = value
        End Set
    End Property


#End Region

#Region "Logic Field"

    Public ReadOnly Property QuandoStr As String
        Get
            Return Quando.ToString("dd/MM/yyyy HH:mm.ss")
        End Get
    End Property

    Public ReadOnly Property ServizioStr As String
        Get
            Dim ris As String = String.Empty

            Select Case Servizio
                Case enDaemonService.Service
                    ris = "Service"
                Case enDaemonService.Syncronizer
                    ris = "Syncronizer"
                Case enDaemonService.UdpCommand
                    ris = "UDP Command"
                Case enDaemonService.Messenger
                    ris = "Messenger"
                Case enDaemonService.Caller
                    ris = "Caller"
            End Select

            Return ris
        End Get
    End Property

    Public ReadOnly Property IcoTipo As Image
        Get
            Dim Ris As Image = Nothing
            If Tipo = enDaemonLogType.Exception Then
                Ris = My.Resources._Attenzione16
            Else
                Ris = My.Resources._Info16
            End If
            Return Ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IDaemonLog.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IDaemonLog.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IDaemonLog.Save
        Dim Ris As Integer = MyBase.Save()
        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class

''' <summary>
'''Interface for table Daemonlog
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IDaemonLog
    Inherits _IDaemonLog

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface