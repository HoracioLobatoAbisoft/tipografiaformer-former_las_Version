#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: DC Consultilng srl
'Date: 06/11/2008
#End Region

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

'Public Class cMagaz

'#Region "Property"

'    Private _IdCarMag As Integer = 0
'    Public Property IdCarMag() As Integer
'        Get
'            Return _IdCarMag
'        End Get
'        Set(ByVal value As Integer)
'            _IdCarMag = value
'        End Set
'    End Property

'    Private _IdRis As Integer = 0
'    Public Property IdRis() As Integer
'        Get
'            Return _IdRis
'        End Get
'        Set(ByVal value As Integer)
'            _IdRis = value
'        End Set
'    End Property

'    Private _IdFat As Integer = 0
'    Public Property IdFat() As Integer
'        Get
'            Return _IdFat
'        End Get
'        Set(ByVal value As Integer)
'            _IdFat = value
'        End Set
'    End Property

'    Private _IdCom As Integer = 0
'    Public Property IdCom() As Integer
'        Get
'            Return _IdCom
'        End Get
'        Set(ByVal value As Integer)
'            _IdCom = value
'        End Set
'    End Property

'    Private _Qta As Double = 0
'    Public Property Qta() As Double
'        Get
'            Return _Qta
'        End Get
'        Set(ByVal value As Double)
'            _Qta = value
'        End Set
'    End Property

'    Private _OldQta As Single = 0

'    Private _Prezzo As Single = 0
'    Public Property Prezzo() As Single
'        Get
'            Return _Prezzo
'        End Get
'        Set(ByVal value As Single)
'            _Prezzo = value
'        End Set
'    End Property

'    Private _PrezzoUnit As Double = 0
'    Public Property PrezzoUnit() As Double
'        Get
'            Return _PrezzoUnit
'        End Get
'        Set(ByVal value As Double)
'            _PrezzoUnit = value
'        End Set
'    End Property

'    Private _DataMov As DateTime
'    Public Property DataMov() As DateTime
'        Get
'            Return _DataMov
'        End Get
'        Set(ByVal value As DateTime)
'            _DataMov = value
'        End Set
'    End Property

'    Private _IdUt As Integer = 0
'    Public Property IdUt() As Integer
'        Get
'            Return _IdUt
'        End Get
'        Set(ByVal value As Integer)
'            _IdUt = value
'        End Set
'    End Property

'    Private _TipoMov As enTipoMovMagaz
'    Public Property TipoMov() As enTipoMovMagaz
'        Get
'            Return _TipoMov
'        End Get
'        Set(ByVal value As enTipoMovMagaz)
'            _TipoMov = value
'        End Set
'    End Property

'    Private _CodiceForn As String = ""
'    Public Property CodiceForn() As String
'        Get
'            Return _CodiceForn
'        End Get
'        Set(ByVal value As String)
'            _CodiceForn = value
'        End Set
'    End Property

'    Private _DescrForn As String = ""
'    Public Property DescrForn() As String
'        Get
'            Return _DescrForn
'        End Get
'        Set(ByVal value As String)
'            _DescrForn = value
'        End Set
'    End Property

'    Private _Nota As String = ""
'    Public Property Nota() As String
'        Get
'            Return _Nota
'        End Get
'        Set(ByVal value As String)
'            _Nota = value
'        End Set
'    End Property
'#End Region

'#Region "Method"
'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_Magaz where IdCarMag = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdCarMag = myReader("IdCarMag")
'                If Not myReader("IdRis") Is DBNull.Value Then
'                    _IdRis = myReader("IdRis").ToString
'                End If
'                If Not myReader("IdFat") Is DBNull.Value Then
'                    _IdFat = myReader("IdFat").ToString
'                End If
'                If Not myReader("IdCom") Is DBNull.Value Then
'                    _IdCom = myReader("IdCom").ToString
'                End If
'                If Not myReader("Qta") Is DBNull.Value Then
'                    _Qta = myReader("Qta").ToString
'                    _OldQta = myReader("Qta").ToString 'la uso in caso di modifica
'                End If
'                If Not myReader("Prezzo") Is DBNull.Value Then
'                    _Prezzo = myReader("Prezzo").ToString
'                End If
'                If Not myReader("PrezzoUnit") Is DBNull.Value Then
'                    _PrezzoUnit = myReader("PrezzoUnit").ToString
'                End If
'                If Not myReader("DataMov") Is DBNull.Value Then
'                    _DataMov = myReader("DataMov").ToString
'                End If
'                If Not myReader("IdUt") Is DBNull.Value Then
'                    _IdUt = myReader("IdUt").ToString
'                End If
'                If Not myReader("TipoMov") Is DBNull.Value Then
'                    _TipoMov = myReader("TipoMov").ToString
'                End If
'                If Not myReader("Nota") Is DBNull.Value Then
'                    _Nota = myReader("Nota").ToString
'                End If
'                If Not myReader("CodiceForn") Is DBNull.Value Then
'                    _CodiceForn = myReader("CodiceForn").ToString
'                End If
'                If Not myReader("DescrForn") Is DBNull.Value Then
'                    _DescrForn = myReader("DescrForn").ToString
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
'            If _IdCarMag = 0 Then
'                sql = "INSERT INTO T_Magaz("
'                sql &= "IdRis,"
'                sql &= "IdFat,"
'                sql &= "IdCom,"
'                sql &= "Qta,"
'                sql &= "Prezzo,"
'                sql &= "PrezzoUnit,"
'                sql &= "DataMov,"
'                sql &= "IdUt,"
'                sql &= "TipoMov,"
'                sql &= "CodiceForn,"
'                sql &= "DescrForn,"
'                sql &= "Nota"
'                sql &= ") VALUES ("
'                sql &= _IdRis & ","
'                sql &= _IdFat & ","
'                sql &= _IdCom & ","
'                sql &= Ap(_Qta) & ","
'                sql &= Ap(_Prezzo) & ","
'                sql &= Ap(_PrezzoUnit) & ","
'                sql &= Ap(_DataMov) & ","
'                sql &= _IdUt & ","
'                sql &= _TipoMov & ","
'                sql &= Ap(_CodiceForn) & ","
'                sql &= Ap(_DescrForn) & ","
'                sql &= Ap(_Nota)
'                sql &= ")"
'            Else
'                sql = "UPDATE T_Magaz SET "
'                sql &= "IdRis = " & _IdRis & ","
'                sql &= "IdFat = " & _IdFat & ","
'                sql &= "IdCom = " & _IdCom & ","
'                sql &= "Qta = " & Ap(_Qta) & ","
'                sql &= "Prezzo = " & Ap(_Prezzo) & ","
'                sql &= "PrezzoUnit = " & Ap(_PrezzoUnit) & ","
'                'sql &= "DataMov = " & ap(_DataMov) & ","
'                'sql &= "IdUt = " & _IdUt & ","
'                sql &= "TipoMov = " & _TipoMov & ","
'                sql &= "CodiceForn = " & Ap(_CodiceForn) & ","
'                sql &= "DescrForn = " & Ap(_DescrForn) & ","
'                sql &= "Nota = " & Ap(_Nota)
'                sql &= " WHERE IdCarMag= " & _IdCarMag
'            End If

'            AggiornaQta(_OldQta, _Qta)

'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IdCarMag = 0 Then
'                sql = "select @@identity"
'                myCommand.CommandText = sql
'                IdInserito = myCommand.ExecuteScalar()
'                _IdCarMag = IdInserito
'            End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'    Public Function AggiornaQta(ByVal Old As Double, ByVal NewQta As Double) As Integer

'        Dim Ris As Integer = 0
'        Try

'            If _TipoMov = enTipoMovMagaz.Carico Or _TipoMov = enTipoMovMagaz.Prenotazione Or _TipoMov = enTipoMovMagaz.Storno Then



'                Dim myCommand As SqlCommand = New SqlCommand()
'                myCommand.Connection = LUNA.LunaContext.Connection
'                Dim Sql As String = "UPDATE T_RISORSE SET Giacenza = (Giacenza "

'                Select Case _TipoMov

'                    Case enTipoMovMagaz.Carico
'                        Sql &= " - " & (Old) & " + " & (NewQta) & ")"

'                    Case enTipoMovMagaz.Prenotazione, enTipoMovMagaz.Storno
'                        Sql &= " + " & (Old) & " - " & (NewQta) & ")"
'                        'Case enTipoMovMagaz.Carico
'                        '    Sql &= "( - " & Ap(Old) & " + " & Ap(NewQta) & ")"

'                        'Case enTipoMovMagaz.Prenotazione, enTipoMovMagaz.Storno
'                        '    Sql &= "( + " & Ap(Old) & " - " & Ap(NewQta) & ")"

'                End Select


'                Sql &= " Where IdRis = " & _IdRis
'                myCommand.CommandText = Sql
'                myCommand.ExecuteNonQuery()
'                myCommand.Dispose()
'            End If
'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris

'    End Function

'    Public Function IsValid() As Boolean
'        Dim Ris As Boolean = True

'        If _Qta <= 0 Then
'            Ris = False
'        End If


'        Return Ris
'    End Function

'#End Region

'End Class

Public Class cMagazColl
    Inherits _cOldDao

    'Public Function Lista(ByVal IdRis As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Magaz")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT M.IdCarMag,M.DataMov,"

    '        sql &= "(select case tipomov when " & enTipoMovMagaz.Carico & " then 'Carico' "
    '        sql &= " when " & enTipoMovMagaz.Scarico & "  then 'Scarico' "
    '        sql &= " when " & enTipoMovMagaz.Inserimento & "  then 'Registrazione' "
    '        sql &= " when " & enTipoMovMagaz.Storno & " then 'Storno' "
    '        sql &= " when " & enTipoMovMagaz.Prenotazione & " then 'Prenotazione' "
    '        sql &= " when " & enTipoMovMagaz.RichiestaAcquisto & " then 'Richiesta di acquisto'"
    '        sql &= " end ) as [Tipo]"
    '        sql &= " ,M.Qta, M.PrezzoUnit as PrezzoUnitario, M.Prezzo as Totale,M.Numero as Fattura,M.IdCom as Commessa,U.Login as Operatore"

    '        sql &= " FROM (SELECT * from T_Magaz M left Join T_ContabCosti F on M.IdFat = F.idcosto) M Left join T_Utenti U "
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        sql &= "  on M.IdUt = U.IdUt "
    '        If IdRis Then sql &= " WHERE M.IdRis = " & IdRis

    '        sql &= " ORDER BY DataMov desc"

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

    Public Function ListaRisFattura(ByVal IdFat As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_Magaz")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT M.IdCarMag,M.CodiceForn,M.DescrForn, M.Prezzo as PrezzoTot,M.Prezzounit as PrezzoUnitario, M.Qta, M.IdRis "
            sql &= " from T_Magaz M, T_Risorse R WHERE M.IdRIS = R.IdRis"

            sql &= " AND M.IdFat = " & IdFat
            sql &= " Order by M.IdCarMag "
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

    Public Function ListaRisFornitore(ByVal IdForn As Integer) As DataTable

        Dim datatb As DataTable = New DataTable("T_Magaz")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT M.idFat,CC.Numero,DataMov,R.Codice,R.Descrizione, M.Prezzo as PrezzoTot,M.Prezzounit as PrezzoUnitario, M.Qta"
            sql &= " from T_Magaz M, T_Risorse R, T_ContabCosti CC WHERE M.IdRIS = R.IdRis and M.idfat = CC.idcosto "

            sql &= " AND CC.IdRub = " & IdForn
            sql &= " Order by DataMov desc"
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
    '        Dim Sql As String = "DELETE FROM T_Magaz"
    '        Sql &= " Where IdCarMag = " & Id
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()
    '        myCommand.Dispose()
    '    Catch ex As Exception
    '        ManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

    'Public Function TrasformaPrenotazioneInScarico(ByVal IdCom As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = OldDbConnection
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        Dim Sql As String = "UPDATE T_Magaz set tipomov =" & enTipoMovMagaz.Scarico & " WHERE tipomov= " & enTipoMovMagaz.Prenotazione & " and idcom = " & IdCom
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()
    '        myCommand.Dispose()
    '    Catch ex As Exception
    '        OldManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

End Class



