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
'''DAO Class for table T_macchinari
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class MacchinariDAO
    Inherits _MacchinariDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare un macchinario"

    Public Function GetMacchinariByFormatoMacchina(IdFormatoMacchina As Integer) As IEnumerable(Of Macchinario)
        Dim Ls As New List(Of Macchinario)
        Try

            Dim sql As String = ""
            sql = "SELECT * FROM T_macchinari WHERE IdMacchinario IN (SELECT IdMacchinario FROM TR_FormatoMacchinario WHERE IdFormato = " & IdFormatoMacchina & ")"
            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Function GetIdMacchinariPerReparto(IdReparto As enRepartoWeb,
                                              Optional TipoMacchinario As enTipoMacchinario = enTipoMacchinario.Produzione,
                                              Optional AddEmpty As Boolean = False,
                                              Optional SoloInUso As Boolean = True) As List(Of Macchinario)
        Dim ris As List(Of Macchinario)

        Dim Sql As String = "SELECT DISTINCT m.* from t_macchinari m, T_Commesse c where c.tipocom = " & IdReparto & " and m.IdMacchinario = c.IdMacchinario and not (c.IdMacchinario is null or c.IdMacchinario = 0 )"

        If SoloInUso Then
            Sql &= " AND m.IdMacchinario in(select distinct idmacchinario from t_lavlog)"
        End If

        Sql &= " order by M.descrizione"

        ris = GetData(Sql, AddEmpty)

        Return ris
    End Function

    Public Function GetMacchinariInCodaLavoro(Optional IdOrdine As Integer = 0,
                                              Optional IdCommessa As Integer = 0) As List(Of Macchinario)

        Dim Ris As List(Of Macchinario) = Nothing
        Dim DataRif As Date = Now.Date

        Dim Sql As String = "SELECT * from T_macchinari where idmacchinario in (select distinct idmacchinario from t_lavlog where (dataOrainizio is null or dataOrafine is null) and Idlav in (select IdLavoro from t_lavori where IdCatLav in (select idcatlav from td_catlav where TipoCaratteristica=" & enSiNo.No & ") "

        If IdCommessa Then
            Sql &= " and IdCom = " & IdCommessa
        End If

        If IdOrdine Then
            Sql &= " and IdOrd = " & IdOrdine
        End If

        Sql &= "))"
        Sql &= " Order by Tipo, Ordinamento, Descrizione"

        Ris = GetData(Sql)

        Return Ris

    End Function


End Class