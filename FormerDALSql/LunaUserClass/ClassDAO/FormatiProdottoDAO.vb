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
Imports System.Data.Common

''' <summary>
'''DAO Class for table Td_formatoprodotto
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class FormatiProdottoDAO
    Inherits _FormatiProdottoDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub UpdateFile(IdRif As Integer, PathFile As String)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                Dim Sql As String = "UPDATE TD_FormatoProdotto SET ImgRif = " & LUNA.LunaTools.StringTools.Ap(PathFile) & " WHERE IdFormProd = " & IdRif

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Function ListaFormati(Optional Iniziale As String = "") As List(Of FormatoProdottoEx)
        Dim Ls As List(Of FormatoProdottoEx) = New List(Of FormatoProdottoEx)

        Dim Sql As String = "SELECT * from TD_FormatoProdotto "

        If Iniziale.Length Then

            If Iniziale = "123" Then
                Sql &= " WHERE Formato like '1%' or Formato like '2%' or Formato like '3%' or Formato like '4%' or Formato like '5%' or Formato like '6%' or  Formato like '7%'  or Formato like '8%'  or Formato like '9%' or Formato like '0%'"
            Else
                Sql &= " WHERE Formato like '" & Iniziale & "%' "
            End If

        End If


        Sql &= " ORDER BY Formato"

        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            While myReader.Read
                Dim classe As New FormatoProdottoEx(CType(myReader, IDataRecord))
                'If Not myReader("ImgRif") Is DBNull.Value Then classe.ImgRif = myReader("ImgRif")
                'If Not myReader("IdFormProd") Is DBNull.Value Then classe.IdFormProd = myReader("IdFormProd")
                'If Not myReader("Formato") Is DBNull.Value Then classe.Formato = myReader("Formato")
                'If Not myReader("Orientamento") Is DBNull.Value Then classe.Orientamento = myReader("Orientamento")
                'If Not myReader("Sigla") Is DBNull.Value Then classe.Sigla = myReader("Sigla")
                'If Not myReader("ProdottoFinito") Is DBNull.Value Then classe.ProdottoFinito = myReader("ProdottoFinito")

                Ls.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ls

    End Function

    Public Function ListaIdFormatoByIdCatLav(IdCatLav As Integer) As List(Of Integer)

        Dim ris As New List(Of Integer)

        Dim Sql As String = "SELECT distinct idformprod from T_PrezziLavoro WHERE IDLavoro in (Select idLavoro from t_lavori WHERE IDCATLAV =" & IdCatLav & ")"
        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            While myReader.Read
                Dim int As Integer = myReader("idformprod")
                ris.Add(int)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try


        Return ris

    End Function

End Class