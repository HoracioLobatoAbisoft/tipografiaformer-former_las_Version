#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.5.18.31939 
'Author: Diego Lunadei
'Date: 14/10/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum


''' <summary>
'''DAO Class for table Ordini
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class OrdiniWebDAO
    Inherits _OrdiniWebDAO

    Public Function SalvaAnteprima(O As OrdineWeb) As Integer

        Dim Ris As Integer = 0

        Try
            Dim sql As String
            Using myCommand As SqlCommand = _Cn.CreateCommand()
                sql = "UPDATE Ordini SET "
                sql &= "Anteprima = " & Ap(O.Anteprima)
                sql &= " WHERE IdOrdine= " & O.IdOrdine

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()
                'End If
            End Using

        Catch ex As Exception
            ManageError(ex)

        End Try
        Return Ris
    End Function

    Public Function GetStatoOrdine(IdOrd As Integer) As Integer


        Dim Ris As Integer = 0


        Try
            Using myCommand As SqlCommand = _cn.CreateCommand()
                myCommand.CommandText = "SELECT stato from ordini where idordine = " & IdOrd
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()

                    While myReader.Read

                        If Not myReader("stato") Is DBNull.Value Then
                            Ris = myReader("stato")
                        End If
                    End While
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return ris

    End Function

    Public Function CleanFromOnline() As Integer
        Dim Ris As Integer = 0
        Try

            'elimino tutti quelli di un agenzia gia pagati da oltre due mesi 
            Using myCommand As SqlCommand = _cn.CreateCommand()
                Dim sql As String = "DELETE o FROM ordini o INNER JOIN utenti u ON o.idut = u.idut WHERE u.tipoRub=" & enTipoRubrica.Rivenditore &
                                    " AND o.stato = " & enStatoOrdine.PagatoInteramente &
                                    " AND datediff(d,o.datacambiostato,getdate())>60 "

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteReader()
            End Using

            'elimino tutti i preventivi a pagato interamente
            Using myCommand As SqlCommand = _cn.CreateCommand()
                Dim sql As String = "DELETE FROM ordini WHERE preventivo = " & enSiNo.Si & " AND stato = " & enStatoOrdine.PagatoInteramente

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteReader()
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

End Class