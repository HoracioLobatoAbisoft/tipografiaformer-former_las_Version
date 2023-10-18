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
'''DAO Class for table T_postit
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class MessaggiDAO
    Inherits _MessaggiDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function MessaggiInEntrata(IdUt As Integer, Optional OnlyNotRead As Boolean = False) As IEnumerable(Of Messaggio)
        Dim Ls As New List(Of Messaggio)
        Try

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT * from T_postit"
            sql &= " where ((iddest =0 and idmitt <>0) or iddest = " & IdUt & ") "

            If OnlyNotRead Then sql &= " AND letto= " & enSiNo.No
            sql &= " and status = 0 and datediff(m,datains,getdate()) <= 1  ORDER BY DATAINS DESC"

            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read
                Dim classe As New Messaggio(CType(myReader, IDataRecord))
                'If Not myReader("IdPostit") Is DBNull.Value Then classe.IdPostit = myReader("IdPostit")
                'If Not myReader("IdMitt") Is DBNull.Value Then classe.IdMitt = myReader("IdMitt")
                'If Not myReader("IdDest") Is DBNull.Value Then classe.IdDest = myReader("IdDest")
                'If Not myReader("DataIns") Is DBNull.Value Then classe.DataIns = myReader("DataIns")
                'If Not myReader("Letto") Is DBNull.Value Then classe.Letto = myReader("Letto")
                'If Not myReader("Titolo") Is DBNull.Value Then classe.Titolo = myReader("Titolo")
                'If Not myReader("Testo") Is DBNull.Value Then classe.Testo = myReader("Testo")
                'If Not myReader("Status") Is DBNull.Value Then classe.Status = myReader("Status")
                'If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
                'If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrd = myReader("IdOrd")
                Ls.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Function MessaggiInUscita(IdUt As Integer, Optional OnlyNotRead As Boolean = False) As IEnumerable(Of Messaggio)
        Dim Ls As New List(Of Messaggio)
        Try

            Dim myCommand As SqlCommand = _cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT * from T_postit"
            sql &= " where IdMitt =" & IdUt
            If OnlyNotRead Then sql &= " AND letto =" & enSiNo.No
            sql &= " and status= 0 and datediff(m,datains,getdate()) <= 1  ORDER BY DATAINS DESC"

            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read
                Dim classe As New Messaggio(CType(myReader, IDataRecord))
                'If Not myReader("IdPostit") Is DBNull.Value Then classe.IdPostit = myReader("IdPostit")
                'If Not myReader("IdMitt") Is DBNull.Value Then classe.IdMitt = myReader("IdMitt")
                'If Not myReader("IdDest") Is DBNull.Value Then classe.IdDest = myReader("IdDest")
                'If Not myReader("DataIns") Is DBNull.Value Then classe.DataIns = myReader("DataIns")
                'If Not myReader("Letto") Is DBNull.Value Then classe.Letto = myReader("Letto")
                'If Not myReader("Titolo") Is DBNull.Value Then classe.Titolo = myReader("Titolo")
                'If Not myReader("Testo") Is DBNull.Value Then classe.Testo = myReader("Testo")
                'If Not myReader("Status") Is DBNull.Value Then classe.Status = myReader("Status")
                'If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
                'If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrd = myReader("IdOrd")
                Ls.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Function MessaggiCommessa(IdCom As Integer, FromOperatore As Boolean) As IEnumerable(Of Messaggio)
        Dim Ls As New List(Of Messaggio)
        Try

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim sql As String = ""

            sql = "SELECT DISTINCT * FROM T_postit"
            sql &= " WHERE Idcom =" & IdCom
            sql &= " OR idord IN (SELECT idord FROM t_ordini WHERE idcom = " & IdCom & ")"
            'If OnlyNotRead Then sql &= " AND letto=false "
            sql &= " AND status= 0 AND datediff(m,datains,getdate()) <= 1  "

            If FromOperatore Then
                'sql &= " AND titolo <> 'Validazione Sorgenti' "
                sql &= " AND tipoMsg <> " & enTipoMessaggio.Automatico
            End If

            sql &= " ORDER BY DataIns DESC"

            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read
                Dim classe As New Messaggio(CType(myReader, IDataRecord))
                'If Not myReader("IdPostit") Is DBNull.Value Then classe.IdPostit = myReader("IdPostit")
                'If Not myReader("IdMitt") Is DBNull.Value Then classe.IdMitt = myReader("IdMitt")
                'If Not myReader("IdDest") Is DBNull.Value Then classe.IdDest = myReader("IdDest")
                'If Not myReader("DataIns") Is DBNull.Value Then classe.DataIns = myReader("DataIns")
                'If Not myReader("Letto") Is DBNull.Value Then classe.Letto = myReader("Letto")
                'If Not myReader("Titolo") Is DBNull.Value Then classe.Titolo = myReader("Titolo")
                'If Not myReader("Testo") Is DBNull.Value Then classe.Testo = myReader("Testo")
                'If Not myReader("Status") Is DBNull.Value Then classe.Status = myReader("Status")
                'If Not myReader("IdCom") Is DBNull.Value Then classe.IdCom = myReader("IdCom")
                'If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrd = myReader("IdOrd")
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