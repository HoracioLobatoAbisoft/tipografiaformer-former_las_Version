#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: DC Consultilng srl
'Date: 29/10/2008
#End Region

Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

'Public Class cLavori

'#Region "Property"

'    Private _IdLavoro As Integer
'    Public Property IdLavoro() As Integer
'        Get
'            Return _IdLavoro
'        End Get
'        Set(ByVal value As Integer)
'            _IdLavoro = value
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

'    Private _TempoRif As Integer
'    Public Property TempoRif() As Integer
'        Get
'            Return _TempoRif
'        End Get
'        Set(ByVal value As Integer)
'            _TempoRif = value
'        End Set
'    End Property

'    Private _Premio As Single
'    Public Property Premio() As Single
'        Get
'            Return _Premio
'        End Get
'        Set(ByVal value As Single)
'            _Premio = value
'        End Set
'    End Property

'    Private _SuCommessa As Boolean
'    Public Property SuCommessa() As Boolean
'        Get
'            Return _SuCommessa
'        End Get
'        Set(ByVal value As Boolean)
'            _SuCommessa = value
'        End Set
'    End Property

'    Private _SuProdotto As Boolean
'    Public Property SuProdotto() As Boolean
'        Get
'            Return _SuProdotto
'        End Get
'        Set(ByVal value As Boolean)
'            _SuProdotto = value
'        End Set
'    End Property

'    Private _Stato As Integer
'    Public Property Stato() As Integer
'        Get
'            Return _Stato
'        End Get
'        Set(ByVal value As Integer)
'            _Stato = value
'        End Set
'    End Property
'#End Region


'#Region "Method"


'    Public Function IsValid() As Boolean

'        Dim Ris As Boolean = True

'        If _Descrizione.Length = 0 Then Ris = False
'        If _TempoRif = 0 Then Ris = False
'        If _SuCommessa = False And _SuProdotto = False Then Ris = False
'        Return Ris

'    End Function


'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_Lavori where IdLavoro = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdLavoro = myReader("IdLavoro")
'                If Not myReader("Descrizione") Is DBNull.Value Then
'                    _Descrizione = myReader("Descrizione").ToString
'                End If
'                If Not myReader("TempoRif") Is DBNull.Value Then
'                    _TempoRif = myReader("TempoRif").ToString
'                End If
'                If Not myReader("Premio") Is DBNull.Value Then
'                    _Premio = myReader("Premio").ToString
'                End If
'                If Not myReader("SuCommessa") Is DBNull.Value Then
'                    _SuCommessa = myReader("SuCommessa").ToString
'                End If
'                If Not myReader("SuProdotto") Is DBNull.Value Then
'                    _SuProdotto = myReader("SuProdotto").ToString
'                End If
'                If Not myReader("Stato") Is DBNull.Value Then
'                    _Stato = myReader("Stato").ToString
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

'    Public Function Save(Optional ByRef IdInserito As Integer = -1) As Integer

'        Dim Ris As Integer = 0

'        Try
'            Dim sql As String
'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = LUNA.LunaContext.Connection
'            If _IdLavoro = 0 Then
'                sql = "INSERT INTO T_Lavori("
'                sql &= "Descrizione,"
'                sql &= "TempoRif,"
'                sql &= "Premio,"
'                sql &= "SuCommessa,"
'                sql &= "SuProdotto,"
'                sql &= "Stato"
'                sql &= ") VALUES ("
'                sql &= Ap(_Descrizione) & ","
'                sql &= _TempoRif & ","
'                sql &= Ap(_Premio) & ","
'                sql &= IIf(_SuCommessa, -1, 0) & ","
'                sql &= IIf(_SuProdotto, -1, 0) & ","
'                sql &= _Stato
'                sql &= ")"
'            Else
'                sql = "UPDATE T_Lavori SET "
'                sql &= "Descrizione = " & Ap(_Descrizione) & ","
'                sql &= "TempoRif = " & _TempoRif & ","
'                sql &= "Premio = " & Ap(_Premio) & ","
'                sql &= "SuCommessa = " & IIf(_SuCommessa, -1, 0) & ","
'                sql &= "SuProdotto = " & IIf(_SuProdotto, -1, 0) & ","
'                sql &= "Stato = " & _Stato
'                sql &= " WHERE IdLavoro= " & _IdLavoro
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If IdInserito = 0 Then
'                sql = "select @@identity"
'                myCommand.CommandText = sql
'                IdInserito = myCommand.ExecuteScalar()
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

Public Class cLavoriColl
    Inherits _cOldDao
    Public Function ListaProdotto(Optional ByVal IdProd As Integer = 0) As DataTable
        Dim datatb As DataTable = New DataTable("T_Lavori")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IdLavoro,Descrizione,TempoRif,Premio FROM T_Lavori "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " WHERE SuProdotto= " & enSiNo.Si

            If IdProd Then
                sql &= " AND IdLavoro NOT IN (SELECT IDLav FROM Tr_Lavori WHERE idprod = " & IdProd & ") "
            End If

            sql &= " ORDER BY Descrizione"
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

    Public Function ListaTipoCom(Optional ByVal IdTipoCom As Integer = 0) As DataTable
        Dim datatb As DataTable = New DataTable("T_Lavori")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IdLavoro,Descrizione,TempoRif,Premio from T_Lavori "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " WHERE SuCommessa= " & enSiNo.Si

            If IdTipoCom Then
                sql &= " AND IdLavoro not in (SELECT IDLav from tR_lavori where idtipoCom = " & IdTipoCom & ") "
            End If

            sql &= " ORDER BY Descrizione"
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

    'Public Function DEPRECATEDListaLavorazioni() As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Lavori")
    '    Try

    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT IdLavoro,Descrizione,TempoRif,Premio,iif(Sucommessa= true,'Si','No') as [Su Commessa] ,iif(SuProdotto= true,'Si','No') as [Su Prodotto], iif(Pubblica= true,'Si','No') as [Pubblica], Prezzo,  from T_Lavori "
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

    '        sql &= " order by Descrizione"
    '        myCommand.CommandText = sql
    '        If Not  Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction =  Luna.LunaContext.Transaction 
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        datatb.Load(myReader)

    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    'Public Function ListaLavoriOrd(ByVal IdOrd As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Lavori")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT Descrizione,Tempo,Premio from T_LavLog "
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        sql &= " WHERE idord = " & IdOrd

    '        sql &= " order by ordine"
    '        myCommand.CommandText = sql
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        datatb.Load(myReader)
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    'Public Function ListaLavoriCom(ByVal IdCom As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Lavori")
    '    Try

    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT IdLav,Descrizione,Tempo,Premio from T_LavLog "
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        sql &= " WHERE idcom = " & IdCom

    '        sql &= " order by ordine"
    '        myCommand.CommandText = sql
    '        If Not  Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction =  Luna.LunaContext.Transaction 
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        datatb.Load(myReader)
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    Public Function ListaProdottoSel(ByVal IdProd As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_Lavori")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IdLavoro,Descrizione,Macchinario,TempoRif,Premio,RL.Ordine from T_Lavori L inner join tR_Lavori RL on L.idlavoro=RL.idlav "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " WHERE RL.idprod = " & IdProd
            sql &= " AND RL.idtipocom = 0 "
            sql &= " order by RL.ordine"
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

    'Public Function ListaCommessaSel(ByVal IdTipoCom As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Lavori")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT IdLavoro,Descrizione,Macchinario,TempoRif,Premio,RL.Ordine from T_Lavori L inner join tR_Lavori RL on L.idlavoro=RL.idlav "
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        sql &= " WHERE RL.idprod = 0 "
    '        sql &= " AND RL.idtipocom =  " & IdTipoCom
    '        sql &= " order by RL.ordine"
    '        myCommand.CommandText = sql
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        datatb.Load(myReader)
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    Public Function ListaTipoComSel(ByVal IdTipoCom As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_Lavori")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IdLavoro,Descrizione,TempoRif,Premio,RL.Ordine from T_Lavori L inner join tR_Lavori RL on L.idlavoro=RL.idlav "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " WHERE RL.idtipocom = " & IdTipoCom
            sql &= " AND RL.idprod = 0 "

            sql &= " order by RL.ordine"
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
    '        Dim Sql As String = "DELETE FROM T_Lavori"
    '        Sql &= " Where IdLavoro = " & Id
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

'Public Class cLavLog

'#Region "Property"

'    Private _IdLavLog As Integer
'    Public Property IdLavLog() As Integer
'        Get
'            Return _IdLavLog
'        End Get
'        Set(ByVal value As Integer)
'            _IdLavLog = value
'        End Set
'    End Property

'    Private _IdCom As Integer
'    Public Property IdCom() As Integer
'        Get
'            Return _IdCom
'        End Get
'        Set(ByVal value As Integer)
'            _IdCom = value
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

'    Private _Descrizione As String
'    Public Property Descrizione() As String
'        Get
'            Return _Descrizione
'        End Get
'        Set(ByVal value As String)
'            _Descrizione = value
'        End Set
'    End Property

'    Private _Premio As Single
'    Public Property Premio() As Single
'        Get
'            Return _Premio
'        End Get
'        Set(ByVal value As Single)
'            _Premio = value
'        End Set
'    End Property

'    Private _Tempo As Integer
'    Public Property Tempo() As Integer
'        Get
'            Return _Tempo
'        End Get
'        Set(ByVal value As Integer)
'            _Tempo = value
'        End Set
'    End Property

'    Private _Ordine As Integer
'    Public Property Ordine() As Integer
'        Get
'            Return _Ordine
'        End Get
'        Set(ByVal value As Integer)
'            _Ordine = value
'        End Set
'    End Property

'    Private _IdUt As Integer
'    Public Property IdUt() As Integer
'        Get
'            Return _IdUt
'        End Get
'        Set(ByVal value As Integer)
'            _IdUt = value
'        End Set
'    End Property

'    Private _DataOraInizio As DateTime
'    Public Property DataOraInizio() As DateTime
'        Get
'            Return _DataOraInizio
'        End Get
'        Set(ByVal value As DateTime)
'            _DataOraInizio = value
'        End Set
'    End Property

'    Private _DataOraFine As DateTime
'    Public Property DataOraFine() As DateTime
'        Get
'            Return _DataOraFine
'        End Get
'        Set(ByVal value As DateTime)
'            _DataOraFine = value
'        End Set
'    End Property
'#End Region


'#Region "Method"
'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_LavLog where IdLavLog = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdLavLog = myReader("IdLavLog")
'                If Not myReader("IdCom") Is DBNull.Value Then
'                    _IdCom = myReader("IdCom").toString
'                End If
'                If Not myReader("IdOrd") Is DBNull.Value Then
'                    _IdOrd = myReader("IdOrd").toString
'                End If
'                If Not myReader("Descrizione") Is DBNull.Value Then
'                    _Descrizione = myReader("Descrizione").toString
'                End If
'                If Not myReader("Premio") Is DBNull.Value Then
'                    _Premio = myReader("Premio").toString
'                End If
'                If Not myReader("Tempo") Is DBNull.Value Then
'                    _Tempo = myReader("Tempo").toString
'                End If
'                If Not myReader("Ordine") Is DBNull.Value Then
'                    _Ordine = myReader("Ordine").toString
'                End If
'                If Not myReader("IdUt") Is DBNull.Value Then
'                    _IdUt = myReader("IdUt").toString
'                End If
'                If Not myReader("DataOraInizio") Is DBNull.Value Then
'                    _DataOraInizio = myReader("DataOraInizio").toString
'                End If
'                If Not myReader("DataOraFine") Is DBNull.Value Then
'                    _DataOraFine = myReader("DataOraFine").toString
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

'    Public Function Save(Optional ByRef IdInserito As Integer = -1) As Integer

'        Dim Ris As Integer = 0

'        Try
'            Dim sql As String
'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = LUNA.LunaContext.Connection
'            If _IdLavLog = 0 Then
'                sql = "INSERT INTO T_LavLog("
'                sql &= "IdCom,"
'                sql &= "IdOrd,"
'                sql &= "Descrizione,"
'                sql &= "Premio,"
'                sql &= "Tempo,"
'                sql &= "Ordine,"
'                sql &= "IdUt,"
'                sql &= "DataOraInizio"
'                If Not _DataOraFine = Date.MinValue Then sql &= ",DataOraFine"
'                sql &= ") VALUES ("
'                sql &= _IdCom & ","
'                sql &= _IdOrd & ","
'                sql &= Ap(_Descrizione) & ","
'                sql &= Ap(_Premio) & ","
'                sql &= _Tempo & ","
'                sql &= _Ordine & ","
'                sql &= _IdUt & ","
'                sql &= Ap(_DataOraInizio)
'                If Not _DataOraFine = Date.MinValue Then sql &= "," & Ap(_DataOraFine)
'                sql &= ")"
'            Else
'                sql = "UPDATE T_LavLog SET "
'                sql &= "IdCom = " & _IdCom & ","
'                sql &= "IdOrd = " & _IdOrd & ","
'                sql &= "Descrizione = " & Ap(_Descrizione) & ","
'                sql &= "Premio = " & Ap(_Premio) & ","
'                sql &= "Tempo = " & _Tempo & ","
'                sql &= "Ordine = " & _Ordine & ","
'                sql &= "IdUt = " & _IdUt & ","
'                sql &= "DataOraInizio = " & Ap(_DataOraInizio)
'                If Not _DataOraFine = Date.MinValue Then sql &= ",DataOraFine = " & Ap(_DataOraFine)
'                sql &= " WHERE IdLavLog= " & _IdLavLog
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If IdInserito = 0 Then
'                sql = "select @@identity"
'                myCommand.CommandText = sql
'                IdInserito = myCommand.ExecuteScalar()
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

'Public Class cLavLogColl
'    Inherits _cOldDao

'    'Public Function Lista() As DataTable
'    '    Dim datatb As DataTable = New DataTable("T_LavLog")
'    '    Try

'    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
'    '        Dim sql As String = ""
'    '        sql = "SELECT IdLavLog,IdCom,IdOrd,Descrizione,Premio,Tempo,Ordine,IdUt,DataOraInizio,DataOraFine from T_LavLog"
'    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

'    '        myCommand.CommandText = sql
'    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'    '        datatb.Load(myReader)
'    '        myReader.Close()
'    '        myCommand.Dispose()

'    '    Catch ex As Exception
'    '        OldManageError(ex)
'    '    End Try
'    '    Return datatb
'    'End Function

'    'Public Function ListaLavoriCrono(ByVal IdOrd As Integer, ByVal IdCom As Integer) As DataTable
'    '    Dim datatb As DataTable = New DataTable("T_LavLog")
'    '    Try

'    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
'    '        Dim sql As String = ""

'    '        'sql = "SELECT IdLavLog,IdCom,IdOrd,Descrizione,Premio,Tempo,Ordine,IdUt,DataOraInizio,DataOraFine from T_LavLog "

'    '        sql = "SELECT * from ("


'    '        sql &= " Select IdCom, DataCronoInizio as Inizio,DataCronoFine as Fine, "
'    '        sql &= "(select case idstato when " & enStatoCommessa.Preinserito & " then 'Preinserito' "
'    '        sql &= " when " & enStatoCommessa.Pronto & " then 'Pronto' "
'    '        sql &= " when " & enStatoCommessa.Stampa & " then 'Stampa' "
'    '        sql &= " when " & enStatoCommessa.FinituraSuCommessa & " then 'Finitura su commessa' "
'    '        sql &= " when " & enStatoCommessa.FinituraSuProdotti & " then 'Finitura su prodotti' "
'    '        sql &= " when " & enStatoCommessa.Completata & "  then 'Completata' "

'    '        sql &= " end ) as Stato, 0 as Ordine, 0 as Tempo "

'    '        sql &= " from T_CommesseCrono "

'    '        sql &= " where idcom = " & IdCom & " and idstato =3 "


'    '        sql &= " UNION "

'    '        sql &= " Select IdCom,convert(date,iif(isnull(DataOraInizio,'')<>0,'01/01/2900',DataOraInizio),103)as Inizio, DataOraFine as Fine, '<i>Finitura su Commessa</i>: ' + Descrizione as Stato , Ordine, Tempo "

'    '        sql &= " FROM T_LAVLOG"

'    '        sql &= " where idcom = " & IdCom & " and idord=0"



'    '        sql &= " UNION "

'    '        sql &= " Select 0 as IdCom,DataOraInizio as Inizio, DataOraFine as Fine, '<i>Finitura su Prodotto</i>: ' + Descrizione as Stato , Ordine , Tempo "

'    '        sql &= " FROM T_LAVLOG"

'    '        sql &= " where IdOrd = " & IdOrd & " and idcom=0"



'    '        sql &= ") as a order by a.IdCom Desc, a.Ordine, a.Inizio"


'    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

'    '        myCommand.CommandText = sql
'    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'    '        datatb.Load(myReader)
'    '        myReader.Close()
'    '        myCommand.Dispose()

'    '    Catch ex As Exception
'    '        OldManageError(ex)
'    '    End Try
'    '    Return datatb
'    'End Function

'    'Public Function DEPRECATEDGetCurrentLavByCom(ByVal IdCom As Integer) As LavLog
'    '    Dim Lav As LavLog
'    '    Try

'    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'    '        Dim sql As String = ""
'    '        sql = "SELECT IdLavLog from T_LavLog where idcom = " & IdCom & " and idut = " & Postazione.UtenteConnesso.IdUt & " and dataorafine is null"

'    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA



'    '        myCommand.CommandText = sql
'    '        If Not  Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction =  Luna.LunaContext.Transaction 
'    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

'    '        myReader.Read()

'    '        If myReader.HasRows Then

'    '            Lav = New LavLog
'    '            Lav.Read(myReader("idlavlog"))

'    '        End If

'    '        myReader.Close()
'    '        myCommand.Dispose()

'    '    Catch ex As Exception
'    '        ManageError(ex)
'    '    End Try
'    '    Return Lav
'    'End Function

'    'Public Function GetNextLavByCom(ByVal IdCom As Integer) As LavLog
'    '    Dim Lav As LavLog = Nothing
'    '    Try

'    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
'    '        Dim sql As String = ""
'    '        sql = "SELECT IdLavLog from T_LavLog where idcom = " & IdCom & " and dataoraInizio is null and dataoraFine is null " ' MODIFICATO 25 LUGLIO 2014 PER EVITARE PROBLEMA ORDINI CHE RESTANO APPESI

'    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

'    '        myCommand.CommandText = sql
'    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

'    '        myReader.Read()

'    '        If myReader.HasRows Then

'    '            Lav = New LavLog
'    '            Lav.Read(myReader("idlavlog"))

'    '        End If

'    '        myReader.Close()
'    '        myCommand.Dispose()

'    '    Catch ex As Exception
'    '        OldManageError(ex)
'    '    End Try
'    '    Return Lav
'    'End Function

'    'Public Function DEPRECATEDGetCurrentLavOrdByCom(ByVal IdCom As Integer) As Integer

'    '    Try

'    '        'torna il numero di lavorazioni su ordini di questa commessa se presenti

'    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'    '        Dim sql As String = ""
'    '        Dim Ris As Integer = 0

'    '        sql = "SELECT IdLavLog from T_LavLog where idut = " & Postazione.UtenteConnesso.IdUt & " and idord in (select idord from t_ordini where idcom = " & IdCom & ") and dataorafine is null "

'    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

'    '        myCommand.CommandText = sql
'    '        If Not  Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction =  Luna.LunaContext.Transaction 
'    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

'    '        myReader.Read()

'    '        If myReader.HasRows Then

'    '            Ris = myReader("IdLavLog")

'    '        End If

'    '        myReader.Close()
'    '        myCommand.Dispose()

'    '        Return Ris

'    '    Catch ex As Exception
'    '        ManageError(ex)
'    '    End Try

'    'End Function

'    'Public Function GetNextLavOrdByCom(ByVal IdCom As Integer) As Integer

'    '    Try

'    '        'torna il numero di lavorazioni su ordini di questa commessa se presenti

'    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
'    '        Dim sql As String = ""
'    '        Dim Ris As Integer = 0

'    '        sql = "SELECT IdLavLog from T_LavLog where idord in (select idord from t_ordini where idcom = " & IdCom & ") and dataorafine is null "

'    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

'    '        myCommand.CommandText = sql
'    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

'    '        myReader.Read()

'    '        If myReader.HasRows Then

'    '            Ris = 1

'    '        End If

'    '        myReader.Close()
'    '        myCommand.Dispose()

'    '        Return Ris

'    '    Catch ex As Exception
'    '        OldManageError(ex)
'    '    End Try

'    'End Function

'    'Public Function DEPRECATEDGetNextLavByOrd(ByVal IdOrd As Integer) As LavLog
'    '    Dim Lav As LavLog
'    '    Try

'    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'    '        Dim sql As String = ""
'    '        sql = "SELECT IdLavLog from T_LavLog where idord = " & IdOrd & " and dataorafine is null "

'    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

'    '        myCommand.CommandText = sql
'    '        If Not  Luna.LunaContext.Transaction Is Nothing Then myCommand.Transaction =  Luna.LunaContext.Transaction 
'    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

'    '        myReader.Read()

'    '        If myReader.HasRows Then

'    '            Lav = New LavLog
'    '            Lav.Read(myReader("idlavlog"))

'    '        End If

'    '        myReader.Close()
'    '        myCommand.Dispose()

'    '    Catch ex As Exception
'    '        ManageError(ex)
'    '    End Try
'    '    Return Lav
'    'End Function

'    'Public Function Delete(ByVal Id As Integer) As Integer
'    '    Dim Ris As Integer = 0
'    '    Try

'    '        Dim myCommand As SqlCommand = New SqlCommand()
'    '        myCommand.Connection = LUNA.LunaContext.Connection
'    '        Dim Sql As String = "DELETE FROM T_LavLog"
'    '        Sql &= " Where IdLavLog = " & Id
'    '        myCommand.CommandText = Sql
'    '        myCommand.ExecuteNonQuery()
'    '        myCommand.Dispose()
'    '    Catch ex As Exception
'    '        ManageError(ex)
'    '        Ris = ex.GetHashCode
'    '    End Try
'    '    Return Ris
'    'End Function

'End Class




