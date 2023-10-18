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
Imports FormerLib.FormerEnum
Imports FormerConfig

''' <summary>
'''DAO Class for table T_email
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class EmailDAO
    Inherits _EmailDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function LeggiTestoEmail(Id As Integer) As String
        Dim Ris As String = String.Empty
        Try
            Dim NomeFile As String = FormerPath.PathEmail & Id & ".htm"
            If File.Exists(NomeFile) Then
                Using sr As New StreamReader(NomeFile)
                    Ris = sr.ReadToEnd
                End Using
            End If
        Catch ex As Exception

        End Try
        Return Ris
    End Function

    Public Function ScriviTestoEmail(Id As Integer, Testo As String) As Integer
        Dim Ris As Integer = Id
        Try
            Dim NomeFile As String = FormerPath.PathEmail & Id & ".htm"

            Using sr As New StreamWriter(NomeFile, False)
                sr.Write(Testo)
            End Using

        Catch ex As Exception

        End Try
        Return Ris
    End Function

    Public Function ListaEmail(Optional Livello As Integer = 0, Optional Stato As Integer = -1, Optional IdRub As Integer = 0) As IEnumerable(Of EmailRis)
        Dim Ls As New List(Of EmailRis)
        Try

            Dim sql As String = ""
            sql = "SELECT e.IdEmail," & _
                " e.Titolo," & _
                " e.Quando," & _
                " e.Testo," & _
                " e.IdRubDest," & _
                " e.IdMarketing," & _
                " e.DaInviare," & _
                " e.Livello, " & _
                " r.RagSoc"
            sql &= " from T_email e , T_rubrica R "

            sql &= " where e.idrubdest = r.idrub and idmarketing = 0 "

            If Livello Then
                sql &= " and livello = " & Livello
            End If

            If Stato <> -1 Then
                sql &= " and DaInviare = " & Stato
            End If

            If IdRub Then
                sql &= " and IdRubDest = " & IdRub
            End If
            sql &= " ORDER BY QUANDO DESC"


            Dim myCommand As SqlCommand = _cn.CreateCommand()
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            While myReader.Read
                Dim classe As New EmailRis
                If Not myReader("IdEmail") Is DBNull.Value Then classe.IdEmail = myReader("IdEmail")
                If Not myReader("Titolo") Is DBNull.Value Then classe.Titolo = myReader("Titolo")
                If Not myReader("Quando") Is DBNull.Value Then classe.Quando = myReader("Quando")
                classe.Testo = LeggiTestoEmail(myReader("IdEmail"))
                'If Not myReader("Testo") Is DBNull.Value Then classe.Testo = myReader("Testo")
                If Not myReader("IdRubDest") Is DBNull.Value Then classe.IdRubDest = myReader("IdRubDest")
                If Not myReader("IdMarketing") Is DBNull.Value Then classe.IdMarketing = myReader("IdMarketing")
                If Not myReader("DaInviare") Is DBNull.Value Then classe.DaInviare = myReader("DaInviare")
                If Not myReader("Livello") Is DBNull.Value Then classe.Livello = myReader("Livello")
                If Not myReader("RagSoc") Is DBNull.Value Then classe.Cliente = myReader("RagSoc")
                Ls.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Sub EsportaEmail()

        Try

            Dim sql As String = ""
            sql = "SELECT * from T_email"

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            While myReader.Read
                ScriviTestoEmail(myReader("IdEmail"), myReader("Testo"))

            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception

        End Try

    End Sub
End Class