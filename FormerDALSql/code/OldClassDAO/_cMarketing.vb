
Imports FormerLib.FormerEnum

#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: Diego Lunadei
'Date: 29/01/2011
#End Region


Imports System
Imports System.Data
Imports System.Data.SqlClient

'Public Class cMarketing

'#Region "Property"

'    Private _IDMark As Integer = 0
'    Public Property IDMark() As Integer
'        Get
'            Return _IDMark
'        End Get
'        Set(ByVal value As Integer)
'            _IDMark = value
'        End Set
'    End Property

'    Private _Quando As DateTime
'    Public Property Quando() As DateTime
'        Get
'            Return _Quando
'        End Get
'        Set(ByVal value As DateTime)
'            _Quando = value
'        End Set
'    End Property

'    Private _TipoAzione As Integer = 0
'    Public Property TipoAzione() As Integer
'        Get
'            Return _TipoAzione
'        End Get
'        Set(ByVal value As Integer)
'            _TipoAzione = value
'        End Set
'    End Property

'    Private _Ripetizione As Integer = 0
'    Public Property Ripetizione() As Integer
'        Get
'            Return _Ripetizione
'        End Get
'        Set(ByVal value As Integer)
'            _Ripetizione = value
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

'    Private _Annotazioni As String = ""
'    Public Property Annotazioni() As String
'        Get
'            Return _Annotazioni
'        End Get
'        Set(ByVal value As String)
'            _Annotazioni = value
'        End Set
'    End Property

'    Private _Completata As Boolean = False
'    Public Property Completata() As Boolean
'        Get
'            Return _Completata
'        End Get
'        Set(ByVal value As Boolean)
'            _Completata = value
'        End Set
'    End Property
'#End Region


'#Region "Method"
'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_Marketing where IDMark = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IDMark = myReader("IDMark")
'                If Not myReader("Quando") Is DBNull.Value Then
'                    _Quando = myReader("Quando").toString
'                End If
'                If Not myReader("TipoAzione") Is DBNull.Value Then
'                    _TipoAzione = myReader("TipoAzione").toString
'                End If
'                If Not myReader("IdGruppo") Is DBNull.Value Then
'                    _IdGruppo = myReader("IdGruppo").toString
'                End If
'                If Not myReader("Ripetizione") Is DBNull.Value Then
'                    _Ripetizione = myReader("Ripetizione").ToString
'                End If
'                If Not myReader("Annotazioni") Is DBNull.Value Then
'                    _Annotazioni = myReader("Annotazioni").toString
'                End If

'                If Not myReader("Completata") Is DBNull.Value Then
'                    _Completata = myReader("Completata").ToString
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
'            If _IDMark = 0 Then
'                sql = "INSERT INTO T_Marketing("
'                sql &= "Quando,"
'                sql &= "TipoAzione,"
'                sql &= "IdGruppo,"
'                sql &= "Ripetizione,"
'                sql &= "Annotazioni"
'                sql &= ") VALUES ("
'                sql &= Ap(_Quando.ToShortDateString) & ","
'                sql &= _TipoAzione & ","
'                sql &= _IdGruppo & ","
'                sql &= _Ripetizione & ","
'                sql &= ap(_Annotazioni)
'                sql &= ")"
'            Else
'                sql = "UPDATE T_Marketing SET "
'                sql &= "Quando = " & ap(_Quando) & ","
'                sql &= "TipoAzione = " & _TipoAzione & ","
'                sql &= "IdGruppo = " & _IdGruppo & ","
'                sql &= "Ripetizione = " & _Ripetizione & ","
'                sql &= "Annotazioni = " & ap(_Annotazioni)
'                sql &= " WHERE IDMark= " & _IDMark
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IDMark = 0 Then
'                Sql = "select @@identity"
'                myCommand.CommandText = Sql
'                Idinserito = myCommand.ExecuteScalar()
'                _IDMark = Idinserito
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

Public Class cMarketingColl
    Inherits _cOldDao

    'Public Function ListaNotifiche() As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Marketing")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT IDMark,Quando,"
    '        'sql &= "switch(TipoAzione=" & enTipoAzMarketing.InvioMail & ",'Inviare Mail',"
    '        'sql &= "TipoAzione=" & enTipoAzMarketing.Telefono & ",'Telefonare',"
    '        'sql &= "TipoAzione=" & enTipoAzMarketing.SpedMat & ",'Spedire materiale',"
    '        'sql &= "TipoAzione=" & enTipoAzMarketing.Visita & ",'Visitare') as Azione,"

    '        sql &= "(select case TipoAzione when " & enTipoAzMarketing.InvioMail & " then 'Inviare Mail' "
    '        sql &= " when " & enTipoAzMarketing.Telefono & " then 'Telefonare' "
    '        sql &= " when " & enTipoAzMarketing.SpedMat & " then 'Spedire materiale' "
    '        sql &= " when " & enTipoAzMarketing.Visita & " then 'Visitare' end ) as Azione"

    '        sql &= ",g.Nome as Gruppo from T_Marketing M, T_Gruppi G where m.idgruppo = g.idgruppo"
    '        sql &= " and quando >= getdate() and completata = " & enSiNo.No
    '        sql &= " order by quando desc"
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

    Public Function Lista() As DataTable
        Dim datatb As DataTable = New DataTable("T_Marketing")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IDMark,Quando,"

            sql &= "(select case TipoAzione when " & enTipoAzMarketing.InvioMail & " then 'Inviare Mail' "
            sql &= " when " & enTipoAzMarketing.Telefono & " then 'Telefonare' "
            sql &= " when " & enTipoAzMarketing.SpedMat & " then 'Spedire materiale' "
            sql &= " when " & enTipoAzMarketing.Visita & " then 'Visitare' end ) as Azione,"


            'sql &= "switch(TipoAzione=" & enTipoAzMarketing.InvioMail & ",'Inviare Mail',"
            'sql &= "TipoAzione=" & enTipoAzMarketing.Telefono & ",'Telefonare',"
            'sql &= "TipoAzione=" & enTipoAzMarketing.SpedMat & ",'Spedire materiale',"
            'sql &= "TipoAzione=" & enTipoAzMarketing.Visita & ",'Visitare') as Azione,"

            'sql &= "switch(Ripetizione=" & enRipetiMarketing.Mai & ",'Mai',"
            'sql &= "Ripetizione=" & enRipetiMarketing.Mensile & ",'Mensile',"
            'sql &= "Ripetizione=" & enRipetiMarketing.Trimestrale & ",'Trimestrale',"
            'sql &= "Ripetizione=" & enRipetiMarketing.Semestrale & ",'Semestrale',"
            'sql &= "Ripetizione=" & enRipetiMarketing.Annuale & ",'Annuale') as Ripetizione"


            sql &= "(select case Ripetizione when " & enRipetiMarketing.Mai & " then 'Mai' "
            sql &= " when " & enRipetiMarketing.Mensile & " then 'Mensile' "
            sql &= " when " & enRipetiMarketing.Trimestrale & " then 'Trimestrale' "
            sql &= " when " & enRipetiMarketing.Semestrale & " then 'Semestrale' "
            sql &= " when " & enRipetiMarketing.Annuale & " then 'Annuale' end ) as Ripetizione"



            sql &= ",g.Nome as Gruppo,completata from T_Marketing M, T_Gruppi G where m.idgruppo = g.idgruppo"

            sql &= " order by quando desc"
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

    'Public Function Delete(ByVal Id As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = LUNA.LunaContext.Connection
    '        Dim Sql As String = "DELETE FROM T_Marketing"
    '        Sql &= " Where IDMark = " & Id
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()
    '        myCommand.Dispose()
    '    Catch ex As Exception
    '        ManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

    Public Function Completata(ByVal Id As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = OldDbConnection
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "UPDATE  T_Marketing set Completata = true "
                Sql &= " Where IDMark = " & Id
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

'Public Class cMarkAz

'#Region "Property"

'    Private _IdMarkAz As Integer = 0
'    Public Property IdMarkAz() As Integer
'        Get
'            Return _IdMarkAz
'        End Get
'        Set(ByVal value As Integer)
'            _IdMarkAz = value
'        End Set
'    End Property

'    Private _IdMarketing As Integer = 0
'    Public Property IdMarketing() As Integer
'        Get
'            Return _IdMarketing
'        End Get
'        Set(ByVal value As Integer)
'            _IdMarketing = value
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

'    Private _TipoAzione As Integer = 0
'    Public Property TipoAzione() As Integer
'        Get
'            Return _TipoAzione
'        End Get
'        Set(ByVal value As Integer)
'            _TipoAzione = value
'        End Set
'    End Property

'    Private _Quando As DateTime
'    Public Property Quando() As DateTime
'        Get
'            Return _Quando
'        End Get
'        Set(ByVal value As DateTime)
'            _Quando = value
'        End Set
'    End Property

'    Private _Annotazioni As String = ""
'    Public Property Annotazioni() As String
'        Get
'            Return _Annotazioni
'        End Get
'        Set(ByVal value As String)
'            _Annotazioni = value
'        End Set
'    End Property
'#End Region


'#Region "Method"
'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_MarkAz where IdMarkAz = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdMarkAz = myReader("IdMarkAz")
'                If Not myReader("IdMarketing") Is DBNull.Value Then
'                    _IdMarketing = myReader("IdMarketing").ToString
'                End If
'                If Not myReader("IdRub") Is DBNull.Value Then
'                    _IdRub = myReader("IdRub").ToString
'                End If
'                If Not myReader("TipoAzione") Is DBNull.Value Then
'                    _TipoAzione = myReader("TipoAzione").ToString
'                End If
'                If Not myReader("Quando") Is DBNull.Value Then
'                    _Quando = myReader("Quando").ToString
'                End If
'                If Not myReader("Annotazioni") Is DBNull.Value Then
'                    _Annotazioni = myReader("Annotazioni").ToString
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
'            If _IdMarkAz = 0 Then
'                sql = "INSERT INTO T_MarkAz("
'                sql &= "IdMarketing,"
'                sql &= "IdRub,"
'                sql &= "TipoAzione,"
'                sql &= "Quando,"
'                sql &= "Annotazioni"
'                sql &= ") VALUES ("
'                sql &= _IdMarketing & ","
'                sql &= _IdRub & ","
'                sql &= _TipoAzione & ","
'                sql &= Ap(_Quando) & ","
'                sql &= Ap(_Annotazioni)
'                sql &= ")"
'            Else
'                sql = "UPDATE T_MarkAz SET "
'                sql &= "IdMarketing = " & _IdMarketing & ","
'                sql &= "IdRub = " & _IdRub & ","
'                sql &= "TipoAzione = " & _TipoAzione & ","
'                sql &= "Quando = " & Ap(_Quando) & ","
'                sql &= "Annotazioni = " & Ap(_Annotazioni)
'                sql &= " WHERE IdMarkAz= " & _IdMarkAz
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IdMarkAz = 0 Then
'                sql = "select @@identity"
'                myCommand.CommandText = sql
'                IdInserito = myCommand.ExecuteScalar()
'                _IdMarkAz = IdInserito
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

Public Class cMarkAzColl
    Inherits _cOldDao

    Public Function Lista(ByVal IdRub As Integer, ByVal IdMarketing As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_MarkAz")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IdMarkAz,IdMarketing,IdRub,TipoAzione,Quando,Annotazioni from T_MarkAz"


            sql &= " WHERE IDRUB = " & IdRub

            sql &= " and IdMarketing= " & IdMarketing
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

    'Public Function Delete(ByVal Id As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = LUNA.LunaContext.Connection
    '        Dim Sql As String = "DELETE FROM T_MarkAz"
    '        Sql &= " Where IdMarkAz = " & Id
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


