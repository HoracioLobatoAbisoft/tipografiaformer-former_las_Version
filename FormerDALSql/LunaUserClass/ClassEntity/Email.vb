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
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table T_email
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class Email
    Inherits _Email
    Implements IEmail

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Private _Destinatario As IVoceRubricaG = Nothing
    Public ReadOnly Property Destinatario As IVoceRubricaG
        Get
            If _Destinatario Is Nothing Then

                If IdRubDest Then
                    Dim Dest As New VoceRubrica
                    Dest.Read(IdRubDest)
                    _Destinatario = Dest
                Else
                    Dim Dest As New VoceRubricaMarketing
                    Dest.Read(IdRubMarketing)
                    _Destinatario = Dest
                End If

            End If
            Return _Destinatario
        End Get
    End Property


#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IEmail.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IEmail.Read
        Dim ris As Integer = MyBase.Read(Id)
        'qui devo rileggere il testo dall'email 
        Using mgr As New EmailDAO
            _Testo = mgr.LeggiTestoEmail(Id)
        End Using

        Return ris
    End Function

    Public Overrides Function Save() As Integer Implements IEmail.Save

        Dim TestoAlt As String = _Testo
        _Testo = ""
        Dim ris As Integer = MyBase.Save()

        If ris Then
            Using mgr As New EmailDAO
                mgr.ScriviTestoEmail(IdEmail, TestoAlt)
            End Using
        End If

        Return ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Function LeggiByMarkAz(ByVal Id As Integer) As Integer
        Dim Ris As Integer = 0

        Try
            Using myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
                myCommand.CommandText = "SELECT * FROM T_Email where IdMarketing = " & Id
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    myReader.Read()
                    If myReader.HasRows Then
                        _IdEmail = myReader("IdEmail")
                        If Not myReader("Titolo") Is DBNull.Value Then
                            _Titolo = myReader("Titolo").ToString
                        End If
                        If Not myReader("Quando") Is DBNull.Value Then
                            _Quando = myReader("Quando").ToString
                        End If

                        Using mgr As New EmailDAO
                            _Testo = mgr.LeggiTestoEmail(Id)
                        End Using

                        'If Not myReader("Testo") Is DBNull.Value Then
                        '    _Testo = myReader("Testo").ToString
                        'End If

                        If Not myReader("IdRubDest") Is DBNull.Value Then
                            _IdRubDest = myReader("IdRubDest").ToString
                        End If
                        If Not myReader("IdMarketing") Is DBNull.Value Then
                            _IdMarketing = myReader("IdMarketing").ToString
                        End If
                    Else
                        Ris = 1
                    End If
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Overrides Property Testo() As String
        Get
            If _Testo.Length = 0 Then
                Using mgr As New EmailDAO
                    Testo = mgr.LeggiTestoEmail(IdEmail)
                End Using
            Else
                Testo = _Testo
            End If
        End Get
        Set(value As String)
            _Testo = value
        End Set
    End Property

#End Region

End Class

Public Class EmailRis
    Inherits Email

    Public Property Cliente As String

    Public ReadOnly Property StatoStr
        Get
            Dim Ris As String = ""
            Select Case _DaInviare
                Case enEmailStato.Inviata
                    Ris = "Inviata"
                Case enEmailStato.DaInviare
                    Ris = "Da inviare"
                Case enEmailStato.InCoda
                    Ris = "In coda di invio"
                Case enEmailStato.DaNonInviare
                    Ris = "Da non inviare"
            End Select
            Return Ris
        End Get
    End Property

End Class



''' <summary>
'''Interface for table T_email
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IEmail
    Inherits _IEmail

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface