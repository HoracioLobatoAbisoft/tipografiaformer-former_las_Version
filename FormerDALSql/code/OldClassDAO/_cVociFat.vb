#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: DC Consultilng srl
'Date: 10/09/2009
#End Region

Imports System.Data.SqlClient

'Public Class cVociFat

'#Region "Property"

'    Private _IdVoceFat As Integer = 0
'    Public Property IdVoceFat() As Integer
'        Get
'            Return _IdVoceFat
'        End Get
'        Set(ByVal value As Integer)
'            _IdVoceFat = value
'        End Set
'    End Property

'    Private _IdDoc As Integer = 0
'    Public Property IdDoc() As Integer
'        Get
'            Return _IdDoc
'        End Get
'        Set(ByVal value As Integer)
'            _IdDoc = value
'        End Set
'    End Property

'    Private _IdOrd As Integer = 0
'    Public Property IdOrd() As Integer
'        Get
'            Return _IdOrd
'        End Get
'        Set(ByVal value As Integer)
'            _IdOrd = value
'        End Set
'    End Property

'    Private _Codice As String = ""
'    Public Property Codice() As String
'        Get
'            Return _Codice
'        End Get
'        Set(ByVal value As String)
'            _Codice = value
'        End Set
'    End Property

'    Private _Descrizione As String = ""
'    Public Property Descrizione() As String
'        Get
'            Return _Descrizione
'        End Get
'        Set(ByVal value As String)
'            _Descrizione = value
'        End Set
'    End Property

'    Private _Qta As Single
'    Public Property Qta() As Single
'        Get
'            Return _Qta
'        End Get
'        Set(ByVal value As Single)
'            _Qta = value
'        End Set
'    End Property

'    Private _Importo As Single
'    Public Property Importo() As Single
'        Get
'            Return _Importo
'        End Get
'        Set(ByVal value As Single)
'            _Importo = value
'        End Set
'    End Property

'    Private _ImportoSing As Single
'    Public Property ImportoSing() As Single
'        Get
'            Return _ImportoSing
'        End Get
'        Set(ByVal value As Single)
'            _ImportoSing = value
'        End Set
'    End Property

'    Private _Iva As Single
'    Public Property Iva() As Single
'        Get
'            Return _Iva
'        End Get
'        Set(ByVal value As Single)
'            _Iva = value
'        End Set
'    End Property
'#End Region


'#Region "Method"
'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_VociFat where IdVoceFat = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdVoceFat = myReader("IdVoceFat")
'                If Not myReader("IdDoc") Is DBNull.Value Then
'                    _IdDoc = myReader("IdDoc").ToString
'                End If
'                If Not myReader("Codice") Is DBNull.Value Then
'                    _Codice = myReader("Codice").toString
'                End If
'                If Not myReader("Descrizione") Is DBNull.Value Then
'                    _Descrizione = myReader("Descrizione").toString
'                End If
'                If Not myReader("Qta") Is DBNull.Value Then
'                    _Qta = myReader("Qta").toString
'                End If
'                If Not myReader("ImportoSing") Is DBNull.Value Then
'                    _ImportoSing = myReader("ImportoSing").ToString
'                End If
'                If Not myReader("Importo") Is DBNull.Value Then
'                    _Importo = myReader("Importo").toString
'                End If
'                If Not myReader("Iva") Is DBNull.Value Then
'                    _Iva = myReader("Iva").toString
'                End If
'                If Not myReader("IdOrd") Is DBNull.Value Then
'                    _Iva = myReader("IdOrd").ToString
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
'        Dim sql As String = ""
'        Try

'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = LUNA.LunaContext.Connection
'            If _IdVoceFat = 0 Then
'                sql = "INSERT INTO T_VociFat("
'                sql &= "IdDoc,"
'                sql &= "Codice,"
'                sql &= "Descrizione,"
'                sql &= "Qta,"
'                sql &= "Importo,"
'                sql &= "ImportoSing,"
'                sql &= "IdOrd,"
'                sql &= "Iva"
'                sql &= ") VALUES ("
'                sql &= _IdDoc & ","
'                sql &= ap(_Codice) & ","
'                sql &= ap(_Descrizione) & ","
'                sql &= ap(_Qta) & ","
'                sql &= Ap(_Importo) & ","
'                sql &= Ap(_ImportoSing) & ","
'                sql &= _IdOrd & ","
'                sql &= Ap(_Iva)
'                sql &= ")"
'            Else
'                sql = "UPDATE T_VociFat SET "
'                sql &= "IdDoc = " & _IdDoc & ","
'                sql &= "Codice = " & ap(_Codice) & ","
'                sql &= "Descrizione = " & ap(_Descrizione) & ","
'                sql &= "Qta = " & ap(_Qta) & ","
'                sql &= "Importo = " & Ap(_Importo) & ","
'                sql &= "ImportoSing = " & Ap(_ImportoSing) & ","
'                sql &= "IdOrd = " & _IdOrd & ","
'                sql &= "Iva = " & ap(_Iva)
'                sql &= " WHERE IdVoceFat= " & _IdVoceFat
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IdVoceFat = 0 Then
'                Sql = "select @@identity"
'                myCommand.CommandText = Sql
'                Idinserito = myCommand.ExecuteScalar()
'                _IdVoceFat = Idinserito
'            End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex, Sql)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'#End Region

'End Class

Public Class cVociFatColl
    Inherits _cOldDao

    Public Function Lista(ByVal IdDoc As Integer, Optional ByVal FattRiepilog As Boolean = False) As DataTable
        Dim datatb As DataTable = New DataTable("T_VociFat")
        Dim sql As String = ""
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()

            sql = "SELECT v.IdVoceFat,v.IdDoc,v.Codice,v.Descrizione,v.Qta,v.Importo,v.Iva,v.IdOrd,v.custom,o.filepath from T_VociFat v, t_ordini o "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " where o.idord = v.idord "

            If FattRiepilog Then
                Sql &= "and v.iddoc IN (SELECT IDRICAVO FROM T_CONTABRICAVI WHERE IDDOCRIF=" & IdDoc & ")"
            Else
                Sql &= "and v.iddoc = " & IdDoc
            End If

            If FattRiepilog Then
                Sql &= " order by v.iddoc,o.idord desc"
            Else
                Sql &= " order by o.idord desc"
            End If

            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = Sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            datatb.Load(myReader)
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            OldManageError(ex, Sql)
        End Try
        Return datatb
    End Function

    Public Function ListaVociFat(ByVal IdDoc As Integer, ByRef DA As SqlDataAdapter) As DataSet

        Dim mydataset As DataSet

        'Dim datatb As DataTable = New DataTable("T_VociFat")
        Dim sql As String = ""
        Try

            'Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()

            sql = "SELECT v.IdVoceFat,v.Codice,v.Descrizione,v.Qta,v.Importo,v.Iva from T_VociFat v, t_ordini o "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " where o.idord = v.idord "

            sql &= "and v.iddoc = " & IdDoc
            sql &= " order by o.idord desc"
            Dim cmd As SqlCommand = New SqlCommand(sql, OldDbConnection)
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then cmd.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim MyDataAdapter As SqlDataAdapter = New SqlDataAdapter(cmd)

            Dim cb As SqlCommandBuilder = New SqlCommandBuilder(MyDataAdapter)

            mydataset = New DataSet()
            MyDataAdapter.Fill(mydataset, "DettFatt")
            DA = MyDataAdapter
            'myCommand.CommandText = sql
            'Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            'datatb.Load(myReader)
            'myReader.Close()
            'myCommand.Dispose()

        Catch ex As Exception
            OldManageError(ex, sql)
        End Try
        Return mydataset
    End Function

    'Public Function Delete(ByVal Id As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = LUNA.LunaContext.Connection
    '        Dim Sql As String = "DELETE FROM T_VociFat"
    '        Sql &= " Where IdVoceFat = " & Id
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()
    '        myCommand.Dispose()
    '    Catch ex As Exception
    '        ManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

    Public Function EliminaByIdOrd(ByVal IdOrd As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = OldDbConnection
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "DELETE FROM T_VociFat"
                Sql &= " Where Idord = " & IdOrd
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            OldManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

End Class


