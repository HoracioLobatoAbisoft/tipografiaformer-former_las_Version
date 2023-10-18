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
'''DAO Class for table Td_formatocarta
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class FormatiCartaDAO
    Inherits _FormatiCartaDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function FindByOrdini(lst As List(Of OrdineInSoluzione)) As IEnumerable(Of FormatoCarta)
        Dim Ls As New List(Of FormatoCarta)
        Try
            Dim Sql As String = "SELECT DISTINCT * FROM TD_FORMATOCARTA "

            Sql &= "WHERE IDFORMCARTA IN (SELECT FP.IDFORMCARTA FROM TD_FORMATOPRODOTTO FP,T_PRODOTTI P" & _
                " WHERE FP.IDFORMPROD = P.IDFORMATO AND P.IDPROD IN ("

            For Each o As OrdineInSoluzione In lst
                Sql &= o.Ordine.Prodotto.IdProd & ","
            Next

            Sql = Sql.TrimEnd(",")

            Sql &= "))"

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim classe As New FormatoCarta(CType(myReader, IDataRecord))
                        'If Not myReader("IdFormCarta") Is DBNull.Value Then classe.IdFormCarta = myReader("IdFormCarta")
                        'If Not myReader("FormatoCarta") Is DBNull.Value Then classe.FormatoCarta = myReader("FormatoCarta")
                        'If Not myReader("Altezza") Is DBNull.Value Then classe.Altezza = myReader("Altezza")
                        'If Not myReader("Larghezza") Is DBNull.Value Then classe.Larghezza = myReader("Larghezza")
                        Ls.Add(classe)
                    End While
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Function TotFormatiCartaByFormatiProdotto(IdFormatiP As String) As Integer
        Dim Ris As Integer = 0
        Try
            Dim Sql As String = "SELECT Count(idformcarta) AS tot FROM (SELECT DISTINCT idformcarta FROM td_formatoprodotto where idformprod in (" & IdFormatiP & " ))"

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            If myReader.HasRows Then
                myReader.Read()
                If Not myReader("tot") Is DBNull.Value Then Ris = myReader("tot")
            End If

            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function
End Class