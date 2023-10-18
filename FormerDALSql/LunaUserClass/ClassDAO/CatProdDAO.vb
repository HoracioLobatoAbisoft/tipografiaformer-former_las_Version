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
'''DAO Class for table Td_catprod
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class CatProdDAO
    Inherits _CatProdDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function ElencoExport() As DataTable
        Dim Dt As New DataTable("CATEGORIE")
        Try

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IdCatProd,Descrizione,IdCatPadre,ImgCat FROM Td_catprod ORDER BY idcatpadre"
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            Dt.Load(myReader)

            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Dt
    End Function

    Public Function GetNumOrd(IdPrev As Integer,
                              IdListinoBase As Integer,
                              Stato As enStatoOrdine) As Integer
        Dim Ris As Integer = 0
        Try

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT Count(IdOrd) AS tot FROM T_Ordini WHERE (idcom=0 OR idcom IS NULL) AND stato = " & Stato

            If IdPrev Then
                sql &= " AND IdProd IN (SELECT DISTINCT IdProd FROM T_Prodotti WHERE IdListinoBase IN (SELECT IdListinoBase FROM T_listinobase WHERE IdPrev = " & IdPrev & "))"
            End If

            If IdListinoBase Then
                sql &= " AND IdProd IN (SELECT DISTINCT IdProd FROM T_Prodotti WHERE IdListinoBase  = " & IdListinoBase & ")"
            End If

            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            myReader.Read()
            Ris = myReader("Tot")
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

    Public Function GetNumSpazi(IdCatProd As Integer, IdCatPadre As Integer, Stato As enStatoOrdine) As Integer
        Dim Ris As Integer = 0
        Try

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT Sum(NumSpazi) as tot FROM T_Prod WHERE stato = " & Stato

            If IdCatProd Then
                sql &= " AND IdProd IN (SELECT DISTINCT IdProd FROM T_Prodotti WHERE IdCatProd = " & IdCatProd
                If IdCatPadre = 0 Then
                    sql &= " OR IdCatProd IN (SELECT IdCatProd FROM Td_CatProd WHERE IdCatPadre = " & IdCatProd & ")"
                End If
                sql &= ")"
            End If


            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            myReader.Read()
            Ris = myReader("Tot")
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function

    Public Function GetAllCombo(Optional ByVal IdCat As Integer = 0, Optional IdStatoOrdine As enStatoOrdine = 0) As IEnumerable(Of CatProd)
        Dim Ls As New List(Of CatProd)
        Try

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT * FROM Td_catprod"
            sql &= " WHERE idcatpadre =  0 "
            If IdCat Then sql &= " AND idcatprod<>" & IdCat
            If IdStatoOrdine Then
                'sql &= " and idcatprod IN (SELECT DISTINCT IDCATPADRE FROM TD_CATPROD WHERE IDCAT T_PRODOTTI WHERE IDPROD IN (SELECT DISTINCT IDPROD FROM T_ORDINI WHERE STATO=" & IdStatoOrdine & "))"
                'sql &= " and o.idprod IN  (SELECT IDPROD from T_PRODOTTI WHERE IDCATPROD = " & IdCatProd & " OR idcatprod IN(Select idcatProd from TD_CatProd where idcatpadre = " & IdCatProd & "))"
            End If

            sql &= " ORDER BY Descrizione"
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            Ls.Add(New CatProd() With {.IdCatProd = 0, .Descrizione = " - Seleziona una categoria"})
            While myReader.Read
                Dim classe As New CatProd(CType(myReader, IDataRecord))
                Ls.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function
End Class