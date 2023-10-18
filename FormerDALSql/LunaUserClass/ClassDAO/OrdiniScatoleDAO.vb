#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.6.46.21984 
'Author: Diego Lunadei
'Date: 04/12/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient


''' <summary>
'''DAO Class for table Tr_scatord
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class OrdiniScatoleDAO
    Inherits _OrdiniScatoleDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function OrdiniInScatolaByCons(C As ConsegnaProgrammata) As List(Of OrdineScatola)

        Dim ris As New List(Of OrdineScatola)

        Dim ListaOrdini As String = String.Empty
        For Each o As Ordine In C.ListaOrdini
            ListaOrdini &= o.IdOrd & ","
        Next
        ListaOrdini = ListaOrdini.TrimEnd(",")

        If ListaOrdini.Length Then
            Dim sql As String = "select * from TR_SCATORD where IDORDINE in (" & ListaOrdini & ")"

            ris = GetData(sql)

            ris.Sort(Function(x, y) x.IdScatola.CompareTo(y.IdScatola))
        End If

        Return ris

    End Function

    Public Function GetDistinctIdScatole(lstIdOrdini As String) As List(Of Integer)
        Dim Ls As New List(Of Integer)
        Try
            Dim Sql As String = "SELECT DISTINCT IdScatola FROM TR_ScatOrd where IdOrdine in (" & lstIdOrdini & ")"

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Ls.Add(myReader("IdScatola"))
                    End While
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Sub DeleteByIdScatola(IdScatola As Integer)

        Try

            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_scatord SET DELETED=True "
                Dim sql As String = "DELETE FROM TR_SCATORD WHERE IDSCATOLA = " & IdScatola


                UpdateCommand.CommandText = sql
                If Not Luna.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = Luna.LunaContext.TransactionBox.Transaction
                UpdateCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub


End Class