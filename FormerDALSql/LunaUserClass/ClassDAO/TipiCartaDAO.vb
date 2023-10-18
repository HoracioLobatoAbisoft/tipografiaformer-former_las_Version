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
Imports System.Data.Common

''' <summary>
'''DAO Class for table Td_tipocarta
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class TipiCartaDAO
    Inherits _TipiCartaDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function ListaFiniture(Optional withBlank As Boolean = False) As List(Of String)
        Dim Ris As New List(Of String)
        Dim Sql As String = "SELECT DISTINCT FINITURA FROM TD_TIPOCARTA ORDER BY FINITURA"
        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            If withBlank Then Ris.Add("")

            While myReader.Read
                Ris.Add(myReader("Finitura"))
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ris
    End Function
    Public Sub UpdateFile(IdRif As Integer, PathFile As String)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                Dim Sql As String = "UPDATE Td_TipoCarta SET ImgRif = " & LUNA.LunaTools.StringTools.Ap(PathFile) & " WHERE IDTIPOCARTA = " & IdRif

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Function ListaTipi(Optional Finitura As String = "",
                              Optional SoloConOrdiniInCoda As Boolean = False,
                              Optional SoloSenzaRisorseAssociate As Boolean = False) As List(Of TipoCartaEx)
        Dim Sql As String = "SELECT * FROM Td_TipoCarta "
        Sql &= " WHERE 1=1 "
        If Finitura.Length Then Sql &= " AND FINITURA = " & Ap(Finitura)
        If SoloConOrdiniInCoda Then Sql &= " AND IDTIPOCARTA IN (select distinct l.idtipocarta  from t_ordini o,t_prodotti p, t_listinobase l where o.stato in(" & enStatoOrdine.RefineAutomatico & "," & enStatoOrdine.Registrato & "," & enStatoOrdine.Preinserito & ") and o.idprod = p.idprod and p.idlistinobase = l.idlistinobase)"
        If SoloSenzaRisorseAssociate Then Sql &= " AND IDTIPOCARTA NOT IN (SELECT DISTINCT IDTIPOCARTA FROM T_RISORSE) AND TIPOCARTA = 0"

        Sql &= "ORDER BY TIPOLOGIA"
        Dim Ls As New List(Of TipoCartaEx)
        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            While myReader.Read
                Dim classe As New TipoCartaEx(CType(myReader, IDataRecord))
                'If Not myReader("IdTipoCarta") Is DBNull.Value Then classe.IdTipoCarta = myReader("IdTipoCarta")
                'If Not myReader("Tipologia") Is DBNull.Value Then classe.Tipologia = myReader("Tipologia")
                'If Not myReader("Finitura") Is DBNull.Value Then classe.Finitura = myReader("Finitura")
                'If Not myReader("Grammi") Is DBNull.Value Then classe.Grammi = myReader("Grammi")
                'If Not myReader("ImgRif") Is DBNull.Value Then classe.ImgRif = myReader("ImgRif")
                'If Not myReader("Sigla") Is DBNull.Value Then classe.Sigla = myReader("Sigla")
                'If Not myReader("CostoCartaKG") Is DBNull.Value Then classe.CostoCartaKg = myReader("CostoCartaKG")
                'If Not myReader("TipoCarta") Is DBNull.Value Then classe.TipoCarta = myReader("TipoCarta")
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