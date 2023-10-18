#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: DC Consultilng srl
'Date: 31/12/2010
#End Region

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum


'Public Class cGruppi

'#Region "Property"

'    Private _IdGruppo As Integer = 0
'    Public Property IdGruppo() As Integer
'        Get
'            Return _IdGruppo
'        End Get
'        Set(ByVal value As Integer)
'            _IdGruppo = value
'        End Set
'    End Property

'    Private _Nome As String = ""
'    Public Property Nome() As String
'        Get
'            Return _Nome
'        End Get
'        Set(ByVal value As String)
'            _Nome = value
'        End Set
'    End Property
'#End Region


'#Region "Method"
'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_Gruppi where IdGruppo = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdGruppo = myReader("IdGruppo")
'                If Not myReader("Nome") Is DBNull.Value Then
'                    _Nome = myReader("Nome").toString
'                End If
'            Else
'                Ris = 1
'            End If
'            myReader.Close()
'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'    Public Function Save(Optional ByRef IdInserito As Integer = 0) As Integer

'        Dim Ris As Integer = 0

'        Try
'            Dim sql As String
'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = LUNA.LunaContext.Connection
'            If _IdGruppo = 0 Then
'                sql = "INSERT INTO T_Gruppi("
'                sql &= "Nome"
'                sql &= ") VALUES ("
'                sql &= ap(_Nome)
'                sql &= ")"
'            Else
'                sql = "UPDATE T_Gruppi SET "
'                sql &= "Nome = " & ap(_Nome)
'                sql &= " WHERE IdGruppo= " & _IdGruppo
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IdGruppo = 0 Then
'                Sql = "select @@identity"
'                myCommand.CommandText = Sql
'                Idinserito = myCommand.ExecuteScalar()
'                _IdGruppo = Idinserito
'            End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'#End Region

'End Class


Public Class cGruppiColl
    Inherits _cOldDao

    Public Function Lista(Optional ByVal Tutti As Boolean = False) As DataTable
        Dim datatb As DataTable = New DataTable("T_Gruppi")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""

            If Tutti Then sql = "Select 0 as idgruppo, ' - Tutti ' as Nome from t_gruppi union "
            sql &= " select IdGruppo,Nome from T_Gruppi WHERE STATO <> " & enStato.NonAttivo & " order by Nome "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            datatb.Load(myReader)
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            OldManageError(ex)
        End Try
        Return datatb
    End Function

    'Public Function AssociaRubGruppo(ByVal IdRub As Integer, ByVal IdGruppo As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = OldDbConnection
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        myCommand.CommandText = "SELECT * FROM TR_GRUPRUBR WHERE IDRUB = " & IdRub & " AND IDGRUPPO = " & IdGruppo
    '        Dim x As SqlDataReader = myCommand.ExecuteReader

    '        If x.HasRows = False Then

    '            x.Close()

    '            Dim Sql As String = "INSERT INTO TR_GrupRubr (IdRub,IdGruppo) VALUES (" & IdRub & "," & IdGruppo & ")"
    '            'Sql &= " Where IdGruppo = " & Id
    '            myCommand.CommandText = Sql
    '            myCommand.ExecuteNonQuery()

    '        End If

    '        myCommand.Dispose()
    '    Catch ex As Exception
    '        OldManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

    Public Function DuplicaGruppo(ByVal IdGruppo As Integer) As Integer
        Dim Ris As Integer = 0

        Try
            Dim Nome As String = String.Empty
            Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
                myCommand.CommandText = "SELECT * FROM T_Gruppi WHERE IdGruppo = " & IdGruppo
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                myReader.Read()
                If myReader.HasRows Then
                    If Not myReader("Nome") Is DBNull.Value Then
                        Nome = myReader("Nome").ToString
                    End If
                Else
                    Ris = 1
                End If
                myReader.Close()
            End Using

            If Nome.Length Then
                Nome &= " Copia"

                Dim myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = OldDbConnection
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.CommandText = "Insert INTO T_GRUPPI(Nome)Values(" & Ap(Nome) & ")"
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "select @@identity"
                Dim Idinserito As Integer = myCommand.ExecuteScalar()
                'qui ho l'id del gruppo appena inserito

                Dim Sql As String = "INSERT INTO TR_GrupRubr SELECT " & Idinserito & " as idgruppo,idrub from tr_gruprubr where idgruppo=" & IdGruppo
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()

            End If

        Catch ex As Exception
            OldManageError(ex)
            Ris = ex.GetHashCode
        End Try

        Return Ris
    End Function

    'Public Function TogliRubGruppo(ByVal IdRub As Integer, ByVal IdGruppo As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = OldDbConnection
    '        Dim Sql As String = "DELETE FROM TR_GrupRubr where Idrub = " & IdRub & " and idgruppo = " & IdGruppo
    '        'Sql &= " Where IdGruppo = " & Id
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()
    '        myCommand.Dispose()
    '    Catch ex As Exception
    '        OldManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

    'Public Function ListaGruppiScelti(ByVal IdRub As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Gruppi")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT g.IdGruppo,Nome from T_Gruppi G inner join (select * from TR_GrupRubr where idrub= " & IdRub & ") GR on g.idgruppo = gr.idgruppo "
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        myCommand.CommandText = sql
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        datatb.Load(myReader)
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    'Public Function ListaGruppiDisp(ByVal IdRub As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Gruppi")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT g.IdGruppo,Nome from T_Gruppi G where idgruppo not in  (select idgruppo from TR_GrupRubr where idrub= " & IdRub & ")"
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        myCommand.CommandText = sql
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        datatb.Load(myReader)
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    'Public Function Delete(ByVal Id As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = LUNA.LunaContext.Connection
    '        Dim Sql As String = "DELETE FROM T_Gruppi"
    '        Sql &= " Where IdGruppo = " & Id
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()
    '        myCommand.Dispose()
    '    Catch ex As Exception
    '        ManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

End Class


'Public Class cGrupRubr
'    Inherits _cOldDao
'#Region "Property"

'    Private _IDGrupRubr As Integer = 0
'    Public Property IDGrupRubr() As Integer
'        Get
'            Return _IDGrupRubr
'        End Get
'        Set(ByVal value As Integer)
'            _IDGrupRubr = value
'        End Set
'    End Property

'    Private _IdGruppo As Integer = 0
'    Public Property IdGruppo() As Integer
'        Get
'            Return _IdGruppo
'        End Get
'        Set(ByVal value As Integer)
'            _IdGruppo = value
'        End Set
'    End Property

'    Private _IdRub As Integer = 0
'    Public Property IdRub() As Integer
'        Get
'            Return _IdRub
'        End Get
'        Set(ByVal value As Integer)
'            _IdRub = value
'        End Set
'    End Property
'#End Region

'End Class

