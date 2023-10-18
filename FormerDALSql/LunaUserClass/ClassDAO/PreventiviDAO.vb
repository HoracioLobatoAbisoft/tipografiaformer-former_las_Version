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


''' <summary>
'''DAO Class for table T_preventivi
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class PreventiviDAO
    Inherits _PreventiviDAO
    Public IdRub As Integer = 0
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function Lista(Optional ByVal Codice As String = "", Optional ByVal DataInizio As Date = Nothing, Optional ByVal DataFine As Date = Nothing, Optional ByVal IdRub As Integer = 0, Optional ByVal Risposto As Integer = -1) As DataTable
        Dim datatb As DataTable = New DataTable("T_Preventivi")
        Try

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            Dim sql As String = ""
            sql = "select P.IdPrev,P.Numero,p.DataIns,R.RagSoc as Cliente,P.TipoLavoro,P.Qta,P.Pagine,P.Stampa,P.FormatoAperto,P.FormatoChiuso,P.Carta,P.Lavorazioni from T_Preventivi P"
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " , T_Rubrica R where R.idrub= p.idrub"


            'qui filtri di ricerca
            If Codice.Length Then
                sql &= " and Numero = " & Ap(Codice)
            End If

            If IdRub Then
                sql &= " AND idrub = " & IdRub
            End If

            If DataInizio <> Date.MinValue Then
                sql &= " and datediff(d,'" & DataInizio.ToShortDateString & "',datains)>=0 "
            End If

            If DataFine <> Date.MinValue Then
                sql &= " and datediff(d,datains,'" & DataFine.ToShortDateString & "')>=0 "
            End If

            If (Risposto - 1) <> -1 Then
                sql &= " and Risposto = " & (Risposto - 1)
            End If




            sql &= " order by Datains desc"

            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            datatb.Load(myReader)
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return datatb
    End Function

    Public Function SalvaRisposta(ByVal IdPrev As Integer, ByVal Risposto As Integer, ByVal TestoRisp As String) As Integer

        Dim Ris As Integer = 0

        Try
            Dim sql As String
            Dim DbCommand As SqlCommand = New SqlCommand()
            DbCommand.Connection = _cn

            sql = "UPDATE T_Preventivi SET "
            sql &= "Risposto  = " & Risposto
            sql &= ",TestoRisp = " & Ap(TestoRisp)
            sql &= " WHERE IdPrev= " & IdPrev

            DbCommand.CommandText = sql
            DbCommand.ExecuteNonQuery()
            'End If

            DbCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    Public Function SaveFile(Prev As Preventivo) As Integer

        Dim Ris As Integer = 0

        Try
            Dim sql As String
            Dim DbCommand As SqlCommand = New SqlCommand()
            DbCommand.Connection = _cn

            sql = "UPDATE T_Preventivi SET "
            sql &= "Anteprima = " & Ap(Prev.Anteprima)
            sql &= " WHERE IdPrev= " & Prev.IdPrev

            DbCommand.CommandText = sql
            DbCommand.ExecuteNonQuery()
            'End If

            DbCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function
End Class