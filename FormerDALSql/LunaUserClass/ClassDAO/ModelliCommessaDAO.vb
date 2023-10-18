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
Imports FormerLib.FormerEnum


''' <summary>
'''DAO Class for table T_modellicommessa
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ModelliCommessaDAO
    Inherits _ModelliCommessaDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function GetSpaziFormatoProdotto(IdModello As Integer, IdFormatoProdotto As Integer) As Integer
        Dim Ris As Integer = 0
        Try
            Dim sql As String = "select spazi from TR_Modcomformp where idformprod = " & IdFormatoProdotto & " AND IdModCom = " & IdModello

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            While myReader.Read
                Ris = myReader("spazi")
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris
    End Function

    Public Function GetSpaziFormatoCarta(IdModello As Integer, IdFormatoCarta As Integer) As Integer
        Dim Ris As Integer = 0
        Try
            Dim sql As String = "select spazi from TR_Modcomformp mc, td_formatoprodotto fp where fp.IdFormCarta=" & IdFormatoCarta
            sql &= " and mc.idformprod = FP.IdFormProd AND mc.IdModCom = " & IdModello

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            While myReader.Read
                Ris = myReader("spazi")
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris
    End Function

    Public Function FindByFormatoProdotto(Fp As FormatoProdotto, Optional IdMacchinario As Integer = 0) As List(Of ModelloCommessa)

        Dim Ls As New List(Of ModelloCommessa)

        Try
            Dim Sql As String = "select idmodello from t_modellicommessa where Disattivo <> " & enSiNo.Si & " and idreparto = " & enRepartoWeb.StampaOffset & " and idmodello in ("

            Sql &= "select distinct idmodcom from tr_modcomformp where idformprod = " & Fp.IdFormProd

            Sql &= ")"

            If IdMacchinario Then
                Sql &= " and IdMacchinarioDef = " & IdMacchinario
            End If

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim classe As New ModelloCommessa
                        classe.Read(myReader("IdModello"))
                        Ls.Add(classe)
                    End While
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ls
    End Function

    Public Function FindByFormatoProdotto(lst As List(Of FormatoProdotto), Optional IdMacchinario As Integer = 0) As List(Of ModelloCommessa)

        Dim Ls As New List(Of ModelloCommessa)

        If lst.Count Then
            Try
                Dim Sql As String = "select idmodello from t_modellicommessa where Disattivo <> " & enSiNo.Si & " and idmodello in ("

                Sql &= "select distinct idmodcom from tr_modcomformp where idformprod IN ("

                For Each F As FormatoProdotto In lst
                    Sql &= F.IdFormProd & ","
                Next
                Sql = Sql.TrimEnd(",")
                Sql &= "))"

                If IdMacchinario Then
                    Sql &= " and IdMacchinarioDef = " & IdMacchinario
                End If

                Dim myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()

                While myReader.Read
                    Dim classe As New ModelloCommessa
                    classe.Read(myReader("IdModello"))
                    Ls.Add(classe)
                End While
                myReader.Close()
                myCommand.Dispose()

            Catch ex As Exception
                ManageError(ex)
            End Try
        End If

        Return Ls
    End Function

    Public Function FindByFormatoCarta(Fp As FormatoProdotto, Optional IdMacchinario As Integer = 0) As List(Of ModelloCommessa)

        Dim Ls As New List(Of ModelloCommessa)

        Try
            Dim Sql As String = "select idmodello from t_modellicommessa where idmodello in ("

            Sql &= "select distinct idmodcom from tr_modcomformp where idformprod IN (SELECT IDFORMPROD FROM TD_FORMATOPRODOTTO WHERE IDFORMCARTA = "
            Sql &= Fp.IdFormCarta
            Sql &= "))"

            If IdMacchinario Then
                Sql &= " and IdMacchinarioDef = " & IdMacchinario
            End If

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim classe As New ModelloCommessa
                        classe.Read(myReader("IdModello"))
                        Ls.Add(classe)
                    End While
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ls
    End Function

    Public Function FindByFormatoCarta(Fc As FormatoCarta,
                                       Optional FronteRetro As Boolean = False,
                                       Optional IdMacchinario As Integer = 0,
                                       Optional ProdottoFinitoNo As Boolean = True) As List(Of ModelloCommessa)

        Dim Ls As New List(Of ModelloCommessa)

        Try
            Dim Sql As String = "select idmodello from t_modellicommessa where idreparto = " & enRepartoWeb.StampaOffset & " and idmodello in ("

            Sql &= "select distinct idmodcom from tr_modcomformp where idformprod IN (SELECT IDFORMPROD FROM TD_FORMATOPRODOTTO WHERE IDFORMCARTA = " & Fc.IdFormCarta

            If ProdottoFinitoNo Then
                Sql &= " and ProdottoFinito = " & enSiNo.No
            End If

            Sql &= "  ))"

            If IdMacchinario Then
                Sql &= " and IdMacchinarioDef = " & IdMacchinario
            End If

            If FronteRetro Then
                'Sql &= " and FronteRetro = 1"
            Else
                ' Sql &= " and FronteRetro <> 1"
            End If

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            While myReader.Read
                Dim classe As New ModelloCommessa
                classe.Read(myReader("IdModello"))
                Ls.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ls
    End Function

    Public Function FindByListFormatoCarta(lst As List(Of FormatoCarta),
                                       Optional FronteRetro As Boolean = False,
                                       Optional IdMacchinario As Integer = 0) As List(Of ModelloCommessa)

        Dim Ls As New List(Of ModelloCommessa)

        If lst.Count Then
            Try
                Dim Sql As String = "select idmodello from t_modellicommessa where idmodello in ("

                Sql &= "select distinct idmodcom from tr_modcomformp where idformprod IN (SELECT IDFORMPROD FROM TD_FORMATOPRODOTTO WHERE IDFORMCARTA IN("

                For Each F As FormatoCarta In lst
                    Sql &= F.IdFormCarta & ","
                Next
                Sql = Sql.TrimEnd(",")
                Sql &= ") and ProdottoFinito = " & enSiNo.No & "  ))"

                If IdMacchinario Then
                    Sql &= " and IdMacchinarioDef = " & IdMacchinario
                End If

                If FronteRetro Then
                    'Sql &= " and FronteRetro = 1"
                Else
                    ' Sql &= " and FronteRetro <> 1"
                End If

                Dim myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()

                While myReader.Read
                    Dim classe As New ModelloCommessa
                    classe.Read(myReader("IdModello"))
                    Ls.Add(classe)
                End While
                myReader.Close()
                myCommand.Dispose()

            Catch ex As Exception
                ManageError(ex)
            End Try
        End If

        Return Ls
    End Function
End Class