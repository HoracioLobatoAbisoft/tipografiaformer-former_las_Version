#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.14.6.7 
'Author: Diego Lunadei
'Date: 15/07/2014 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table Indiciricerca
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class IndiciRicercaDAO
    Inherits _IndiciRicercaDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function DeleteAll() As Integer

        Dim Ris As Integer = 0

        Try
            Dim sql As String
            Using myCommand As SqlCommand = _Cn.CreateCommand()
                sql = "DELETE FROM indiciricerca"

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

    Public Function DeleteByIdListinoBase(IdListinoBase As Integer) As Integer

        Dim Ris As Integer = 0

        Try
            Dim sql As String
            Using myCommand As SqlCommand = _Cn.CreateCommand()
                sql = "DELETE FROM indiciricerca WHERE IdListinoBase = " & IdListinoBase

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

    Public Function GetPromo(Optional SoloAttivi As Boolean = True) As IEnumerable(Of IndiceRicerca)

        Dim sql As String = String.Empty

        sql = "SELECT * FROM IndiciRicerca WHERE IdListinoBase IN"
        'sql &= "(SELECT DISTINCT IdListinoBase FROM Promo WHERE Stato = " & enStato.Attivo
        'sql &= " AND datediff(n,getdate(),DataFineValidita)>0 )"

        sql &= "(Select DISTINCT P.IdListinoBase From Promo P, T_Listinobase L, T_preventivazione PR"
        sql &= " WHERE P.IdListinoBase = l.IdListinoBase"
        If SoloAttivi Then
            sql &= " AND P.Stato = " & enStato.Attivo
        End If
        sql &= " And L.Idprev = Pr.Idprev"
        sql &= " And pr.ggSlow<>0"
        sql &= " And DateDiff(n, getdate(), P.DataFineValidita) > 0) order by IdListinoBase"

        Return GetData(sql)

    End Function

End Class