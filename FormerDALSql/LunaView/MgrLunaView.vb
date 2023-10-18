#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.8.1 
'Author: Diego Lunadei
'Date: 13/11/2018 
#End Region

Imports System.Data.Common
Imports FormerDALSql.LUNA

Public MustInherit Class MgrLunaView
    Inherits LunaBaseClass

    Private Shared _DbConnection As IDbConnection = Nothing

    Private Shared Sub InitializeDBConnection()
        If _DbConnection Is Nothing OrElse _DbConnection.State <> ConnectionState.Open Then
            If Not LunaContext.TransactionBox Is Nothing Then
                _DbConnection = LunaContext.TransactionBox.DbConnection
            Else
                _DbConnection = LUNA.LunaContext.GetDbConnection
            End If
        End If
    End Sub

    Protected Shared Property _Cn As IDbConnection
        Get
            InitializeDBConnection()
            Return _DbConnection
        End Get
        Set(value As IDbConnection)
            _DbConnection = value
        End Set
    End Property

    Protected Shared _ConnectionString As String = String.Empty
    Private Shared _ConnAdHoc As Boolean = False

    Protected Shared Sub ManageError(ByVal ex As Exception)
        Throw New ApplicationException("Luna Engine Exception: " & ex.Message, ex)
    End Sub

End Class

'***********************
'TEMPLATE CLASSE MGRVIEW
'***********************
'Imports System.Data.SqlClient
'Imports FormerLib.FormerEnum
'Imports FormerDALSql.LUNA
'Imports FormerLib

'Public Class MgrOrdiniView
'    Inherits MgrLunaView

'    Public Shared Function Lista() As List(Of OrdineView)
'        Dim Ris As List(Of OrdineView) = Nothing

'        Try
'            Dim sql As String = ""


'            Using myCommand As SqlCommand = _Cn.CreateCommand()
'                myCommand.CommandText = sql
'                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'                While myReader.Read
'                    Dim classe As New OrdineView
'                    If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrdine = myReader("IdOrd")

'                    Ris.Add(classe)
'                End While
'                myReader.Close()
'            End Using
'        Catch ex As Exception
'            ManageError(ex)
'        End Try

'        Return Ris
'    End Function

'End Class