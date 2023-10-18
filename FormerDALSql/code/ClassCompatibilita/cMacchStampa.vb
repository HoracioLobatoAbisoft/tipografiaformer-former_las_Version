Imports System.Data.SqlClient
Public Class cMaccStampa
    Inherits _cOldDao
    Public Function Lista() As DataTable
        Dim datatb As DataTable = New DataTable("T_MaccStampa")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT DISTINCT MacchinaStampa from TD_TipoCommessa order by MacchinaStampa"

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

End Class