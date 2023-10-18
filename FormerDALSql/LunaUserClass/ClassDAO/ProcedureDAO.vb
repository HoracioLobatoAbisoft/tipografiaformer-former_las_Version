#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.37 
'Author: Diego Lunadei
'Date: 20/12/2017 
#End Region


Imports System.Data.Common

''' <summary>
'''DAO Class for table T_procedure
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ProcedureDAO
	Inherits _ProcedureDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function GetNextOrdine(IdProcedura As Integer) As Integer
        Dim ris As Integer = 1

        Try
            Using myCommand As DbCommand = _Cn.CreateCommand

                myCommand.CommandText = "SELECT Count(*) as Tot FROM T_STep WHERE IdProcedura = " & IdProcedura
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As DbDataReader = myCommand.ExecuteReader

                    myReader.Read()
                    If myReader.HasRows Then
                        ris = myReader("Tot")
                    End If
                    myReader.Close()
                End Using
                If ris = 0 Then
                    ris = 1
                Else
                    ris += 1
                End If
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

        Return ris
    End Function

End Class