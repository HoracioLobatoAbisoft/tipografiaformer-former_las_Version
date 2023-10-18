#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.3.46.21861 
'Author: Diego Lunadei
'Date: 13/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

''' <summary>
''' 
'''DAO Class for table Td_tipocarta
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class TipiCartaWDAO
    Inherits _TipiCartaWDAO

    Public Function GetTipiCarta(IdPrev As Integer, IdFormatoProdotto As Integer) As List(Of TipoCartaW)
        Dim ris As New List(Of TipoCartaW)

        Dim Sql As String = "SELECT * from TD_TIPOCARTA where idTipoCarta in (select distinct idTipoCarta from T_LISTINOBASE  where idprev = " & IdPrev & " and idformprod = " & IdFormatoProdotto & ") order by grammi"

        ris = GetData(Sql)

        Return ris
    End Function

    Public Function GetFiniture(Optional AddEmpty As Boolean = False,
                                Optional IdReparto As Integer = 0) As List(Of String)

        Dim ris As New List(Of String)

        If AddEmpty Then ris.Add(String.Empty)

        Dim Ls As New List(Of TipoCartaW)
        Try
            Using myCommand As SqlCommand = _Cn.CreateCommand()

                Dim Sql As String = "SELECT DISTINCT FINITURA FROM TD_TIPOCARTA "

                If IdReparto Then

                    Dim IdRepartoSel As String = String.Empty

                    If IdReparto = enRepartoWeb.StampaOffset Or IdReparto = enRepartoWeb.Packaging Then
                        IdRepartoSel = enRepartoWeb.StampaOffset & "," & enRepartoWeb.Packaging
                    Else
                        IdRepartoSel = IdReparto
                    End If

                    Sql &= " WHERE IDTipocarta IN (SELECT DISTINCT IDTipocarta from T_listinobase L, T_preventivazione P WHERE L.idprev = p.idprev and p.TipoProd IN (" & IdRepartoSel & "))"

                End If

                Sql &= " ORDER BY Finitura"

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()

                    While myReader.Read

                        If Not myReader("Finitura") Is DBNull.Value Then ris.Add(myReader("Finitura").ToString)

                    End While
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return ris
    End Function
End Class