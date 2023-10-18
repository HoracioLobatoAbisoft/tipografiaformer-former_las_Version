#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: DC Consultilng srl
'Date: 05/02/2009
#End Region

Imports System.Data.SqlClient

'Public Class FileSorgente

'#Region "Property"

'    Private _IdSorgente As Integer
'    Public Property IdSorgente() As Integer
'        Get
'            Return _IdSorgente
'        End Get
'        Set(ByVal value As Integer)
'            _IdSorgente = value
'        End Set
'    End Property

'    Private _IdOrd As Integer
'    Public Property IdOrd() As Integer
'        Get
'            Return _IdOrd
'        End Get
'        Set(ByVal value As Integer)
'            _IdOrd = value
'        End Set
'    End Property

'    Private _File As String
'    Public Property File() As String
'        Get
'            Return _File
'        End Get
'        Set(ByVal value As String)
'            _File = value
'        End Set
'    End Property
'#End Region


'#Region "Method"
'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_Sorgenti where IdSorgente = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdSorgente = myReader("IdSorgente")
'                If Not myReader("IdOrd") Is DBNull.Value Then
'                    _IdOrd = myReader("IdOrd").toString
'                End If
'                If Not myReader("File") Is DBNull.Value Then
'                    _File = myReader("File").toString
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
'            If _IdSorgente = 0 Then
'                sql = "INSERT INTO T_Sorgenti("
'                sql &= "IdOrd,"
'                sql &= "File"
'                sql &= ") VALUES ("
'                sql &= _IdOrd & ","
'                sql &= ap(_File)
'                sql &= ")"
'            Else
'                sql = "UPDATE T_Sorgenti SET "
'                sql &= "IdOrd = " & _IdOrd & ","
'                sql &= "File = " & ap(_File)
'                sql &= " WHERE IdSorgente= " & _IdSorgente
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IdSorgente = 0 Then
'                Sql = "select @@identity"
'                myCommand.CommandText = Sql
'                Idinserito = myCommand.ExecuteScalar()
'                _IdSorgente = Idinserito
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

Public Class cSorgentiCollezione
    Inherits _cOldCollections
    Private _IdOrd As Integer

    Public ReadOnly Property Lista() As ArrayList
        Get
            Return InnerList
        End Get

    End Property

    Public ReadOnly Property ListaIdAncoraPresenti() As String
        Get

            Dim Sorg As FileSorgente, BufferId As String = ""

            For Each Sorg In InnerList

                BufferId &= Sorg.IdSorgente & ","

            Next

            BufferId = BufferId.TrimEnd(",")

            Return BufferId


        End Get
    End Property

    Public Sub Add(ByVal Sorg As FileSorgente)

        InnerList.Add(Sorg)

    End Sub

    Public Sub Remove(ByVal FileName As String)

        Dim I As Integer

        For I = (InnerList.Count - 1) To 0 Step -1

            Dim Sorg As FileSorgente

            Sorg = InnerList(I)

            If Sorg.FilePath = FileName Then

                InnerList.Remove(Sorg)

            End If

        Next



    End Sub

    Public Sub New()

    End Sub

    Public Sub New(ByVal IdOrd As Integer)

        _IdOrd = IdOrd

    End Sub

    Public Sub RiempiLista()

        Try
            Using cn As IDbConnection = LUNA.LunaContext.OldDbConnection
                Using myCommand As SqlCommand = cn.CreateCommand()
                    Dim sql As String = ""
                    sql = "SELECT IdSorgente,IdOrd,FilePath,NumPagina from T_Sorgenti"
                    'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
                    sql &= " WHERE IDORD= " & _IdOrd

                    sql &= " Order by idsorgente asc"

                    myCommand.CommandText = sql
                    If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                    Using myReader As SqlDataReader = myCommand.ExecuteReader()

                        While myReader.Read

                            Dim x As New FileSorgente
                            x.Read(myReader("idsorgente"))
                            InnerList.Add(x)

                        End While

                        myReader.Close()
                    End Using
                End Using
                    cn.Close()
                End Using
        Catch ex As Exception
            OldManageError(ex)
        End Try

    End Sub

End Class

Public Class cSorgentiColl
    Inherits _cOldDao

    Public Function Lista(ByVal IdOrd As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_Sorgenti")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IdSorgente,IdOrd,FilePath from T_Sorgenti"
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " WHERE IDORD= " & IdOrd
            sql &= " ORDER BY NumPagina, IdSorgente"

            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            datatb.Load(myReader)
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            OldManageError(ex)
        End Try
        Return datatb
    End Function

    'Public Function Delete(ByVal Id As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = LUNA.LunaContext.Connection
    '        Dim Sql As String = "DELETE FROM T_Sorgenti"
    '        Sql &= " Where IdSorgente = " & Id
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()
    '        myCommand.Dispose()
    '    Catch ex As Exception
    '        ManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

    Public Function EliminaTutti(ByVal IdOrd As Integer, ByVal ListaIdAncoraPresenti As String) As Integer
        Dim Ris As Integer = 0
        Try

            Dim myCommand As SqlCommand = New SqlCommand()
            myCommand.Connection = OldDbConnection
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim Sql As String = "DELETE FROM T_Sorgenti"
            Sql &= " Where idOrd = " & IdOrd

            If ListaIdAncoraPresenti.Length Then Sql &= " and idsorgente not in (" & ListaIdAncoraPresenti & ")"

            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()
            myCommand.Dispose()
        Catch ex As Exception
            OldManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

End Class


