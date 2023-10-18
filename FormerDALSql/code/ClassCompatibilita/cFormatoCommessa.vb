Imports System.Data.SqlClient
Public Class cFormatoCommessa
    Inherits _cOldDao
    Private _IdFormato As Integer
    Public Property IdFormato() As Integer
        Get
            Return _IdFormato
        End Get
        Set(ByVal value As Integer)
            _IdFormato = value
        End Set
    End Property

    Private _Formato As String
    Public Property Formato() As String
        Get
            Return _Formato
        End Get
        Set(ByVal value As String)
            _Formato = value
        End Set
    End Property

    Private _DivisioneFoglio As Integer
    Public Property DivisioneFoglio() As Integer
        Get
            Return _DivisioneFoglio
        End Get
        Set(ByVal value As Integer)
            _DivisioneFoglio = value
        End Set
    End Property

    Public Function Lista() As DataTable
        Dim datatb As DataTable = New DataTable("T_FormatoCommessa")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IdFormato,Formato FROM TD_Formato ORDER BY Formato"

            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            datatb.Load(myReader)
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            OldManageError(ex)

        End Try

        Return datatb

    End Function

    Public Function Read(ByVal Id As Integer) As Integer
        Dim Ris As Integer = 0

        Try
            Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
                myCommand.CommandText = "SELECT * FROM TD_Formato where IdFormato = " & Id
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    myReader.Read()
                    If myReader.HasRows Then
                        If Not myReader("IdFormato") Is DBNull.Value Then
                            _IdFormato = myReader("IdFormato").ToString
                        End If
                        If Not myReader("Formato") Is DBNull.Value Then
                            _Formato = myReader("Formato").ToString
                        End If
                        If Not myReader("DivisioneFoglio") Is DBNull.Value Then
                            _DivisioneFoglio = myReader("DivisioneFoglio").ToString
                        End If
                    Else
                        Ris = 1
                    End If
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            OldManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function


End Class