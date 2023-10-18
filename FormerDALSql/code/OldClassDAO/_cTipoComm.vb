#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: DC Consultilng srl
'Date: 03/11/2008
#End Region

Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

'Public Class cTipoCommessa

'#Region "Property"

'    Private _IdTipoCom As Integer
'    Public Property IdTipoCom() As Integer
'        Get
'            Return _IdTipoCom
'        End Get
'        Set(ByVal value As Integer)
'            _IdTipoCom = value
'        End Set
'    End Property

'    Private _TipoCom As enTipoProdCom
'    Public Property TipoCom() As enTipoProdCom
'        Get
'            Return _TipoCom
'        End Get
'        Set(ByVal value As enTipoProdCom)
'            _TipoCom = value
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

'    Private _MacchinaStampa As String
'    Public Property MacchinaStampa() As String
'        Get
'            Return _MacchinaStampa
'        End Get
'        Set(ByVal value As String)
'            _MacchinaStampa = value
'        End Set
'    End Property

'    Private _IdRis As Integer
'    Public Property IdRis() As Integer
'        Get
'            Return _IdRis
'        End Get
'        Set(ByVal value As Integer)
'            _IdRis = value
'        End Set
'    End Property

'    Private _FronteRetro As Boolean
'    Public Property FronteRetro() As Boolean
'        Get
'            Return _FronteRetro
'        End Get
'        Set(ByVal value As Boolean)
'            _FronteRetro = value
'        End Set
'    End Property

'    Private _IdFormato As Integer
'    Public Property IdFormato() As Integer
'        Get
'            Return _IdFormato
'        End Get
'        Set(ByVal value As Integer)
'            _IdFormato = value
'        End Set
'    End Property

'    Private _IdImpianto As Integer
'    Public Property IdImpianto() As Integer
'        Get
'            Return _IdImpianto
'        End Get
'        Set(ByVal value As Integer)
'            _IdImpianto = value
'        End Set
'    End Property

'    Private _PremioStampa As Double
'    Public Property PremioStampa() As Double
'        Get
'            Return _PremioStampa
'        End Get
'        Set(ByVal value As Double)
'            _PremioStampa = value
'        End Set
'    End Property

'    Private _TempoRif As Integer = 0
'    Public Property TempoRif() As Integer
'        Get
'            Return _TempoRif
'        End Get
'        Set(ByVal value As Integer)
'            _TempoRif = value
'        End Set
'    End Property

'    Private _Quantita As Integer = 1
'    Public Property Quantita() As Integer
'        Get
'            Return _Quantita
'        End Get
'        Set(ByVal value As Integer)
'            _Quantita = value
'        End Set
'    End Property

'    Private _NumSpazi As Integer = 1
'    Public Property NumSpazi() As Integer
'        Get
'            Return _NumSpazi
'        End Get
'        Set(ByVal value As Integer)
'            _NumSpazi = value
'        End Set
'    End Property

'#End Region
'#Region "Method"
'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM TD_TipoCommessa where IdTipoCom = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdTipoCom = myReader("IdTipoCom")
'                _TipoCom = myReader("TipoCom")
'                If Not myReader("Descrizione") Is DBNull.Value Then
'                    _Descrizione = myReader("Descrizione").toString
'                End If
'                If Not myReader("MacchinaStampa") Is DBNull.Value Then
'                    _MacchinaStampa = myReader("MacchinaStampa").toString
'                End If
'                If Not myReader("IdRis") Is DBNull.Value Then
'                    _IdRis = myReader("IdRis").toString
'                End If
'                If Not myReader("FronteRetro") Is DBNull.Value Then
'                    _FronteRetro = myReader("FronteRetro").toString
'                End If
'                If Not myReader("IdFormato") Is DBNull.Value Then
'                    _IdFormato = myReader("IdFormato").toString
'                End If
'                If Not myReader("IdImpianto") Is DBNull.Value Then
'                    _IdImpianto = myReader("IdImpianto").toString
'                End If
'                If Not myReader("PremioStampa") Is DBNull.Value Then
'                    _PremioStampa = myReader("PremioStampa").ToString
'                End If
'                If Not myReader("TempoRif") Is DBNull.Value Then
'                    _TempoRif = myReader("TempoRif").ToString
'                End If
'                If Not myReader("Quantita") Is DBNull.Value Then
'                    _Quantita = myReader("Quantita").ToString
'                End If
'                If Not myReader("NumSpazi") Is DBNull.Value Then
'                    _NumSpazi = myReader("NumSpazi").ToString
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
'            If _IdTipoCom = 0 Then
'                sql = "INSERT INTO TD_TipoCommessa("
'                sql &= "Descrizione,"
'                sql &= "MacchinaStampa,"
'                sql &= "TipoCom,"
'                sql &= "IdRis,"
'                sql &= "FronteRetro,"
'                sql &= "IdFormato,"
'                sql &= "IdImpianto,"
'                sql &= "PremioStampa,"
'                sql &= "TempoRif,"
'                sql &= "Quantita,"
'                sql &= "NumSpazi"
'                sql &= ") VALUES ("
'                sql &= Ap(_Descrizione) & ","
'                sql &= Ap(_MacchinaStampa) & ","
'                sql &= _TipoCom & ","
'                sql &= _IdRis & ","
'                sql &= IIf(_FronteRetro, -1, 0) & ","
'                sql &= _IdFormato & ","
'                sql &= _IdImpianto & ","
'                sql &= Ap(_PremioStampa) & ","
'                sql &= _TempoRif & ","
'                sql &= _Quantita & ","
'                sql &= _NumSpazi
'                sql &= ")"
'            Else
'                sql = "UPDATE TD_TipoCommessa SET "
'                sql &= "Descrizione = " & Ap(_Descrizione) & ","
'                sql &= "MacchinaStampa = " & Ap(_MacchinaStampa) & ","
'                sql &= "TipoCom = " & _TipoCom & ","
'                sql &= "IdRis = " & _IdRis & ","
'                sql &= "FronteRetro = " & IIf(_FronteRetro, -1, 0) & ","
'                sql &= "IdFormato = " & _IdFormato & ","
'                sql &= "IdImpianto = " & _IdImpianto & ","
'                sql &= "PremioStampa = " & _PremioStampa & ","
'                sql &= "TempoRif = " & _TempoRif & ","
'                sql &= "Quantita = " & _Quantita & ","
'                sql &= "NumSpazi = " & _NumSpazi
'                sql &= " WHERE IdTipoCom= " & _IdTipoCom
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IdTipoCom = 0 Then
'                sql = "select @@identity"
'                myCommand.CommandText = sql
'                IdInserito = myCommand.ExecuteScalar()
'                _IdTipoCom = IdInserito
'            End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'    Public Function IsValid() As Boolean
'        Dim Ris As Boolean = True

'        If _Descrizione.Length = 0 Then
'            Ris = False
'        End If

'        Return Ris
'    End Function

'#End Region
'End Class

Public Class cTipoCommessaColl
    Inherits _cOldDao

    Public Function Lista() As DataTable
        Dim datatb As DataTable = New DataTable("TD_TipoCommessa")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "select * from (SELECT C.IdTipoCom,'Offset' as [Tipologia],C.Descrizione as Descrizione,C.MacchinaStampa,R.Descrizione as Risorsa,F.Formato,L.Descrizione as Impianti from TD_TipoCommessa C,T_risorse R, TD_Formato F, T_Risorse L "

            sql &= " where C.iDris = R.idris and C.IdFormato = F.idformato and c.IdImpianto = L.IdRis "

            sql &= " and TipoCom = " & enTipoProdCom.StampaOffSet & ") as a "

            sql &= " UNION (SELECT C.IdTipoCom,'Digitale' as [Tipologia],C.Descrizione as Descrizione,' - ' as MacchinaStampa,R.Descrizione as Risorsa,' - ' as Formato,' - ' as  Impianti from TD_TipoCommessa C,T_risorse R, TD_Formato F, T_Risorse L "

            sql &= " where C.iDris = R.idris and C.IdFormato = F.idformato and c.IdImpianto = L.IdRis "

            sql &= " and TipoCom = " & enTipoProdCom.StampaDigitale & ") "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

            sql &= " order by Descrizione"
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

    'Public Function ListaCombo(Optional ByVal TipoProd As Integer = 0) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_TipoCom")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""

    '        sql &= "SELECT IdTipoCom,Descrizione from TD_TipoCommessa "
    '        If TipoProd Then sql &= " WHERE Tipocom = " & TipoProd
    '        sql &= " ORDER BY Descrizione"
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

    'Public Function Delete(ByVal Id As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = LUNA.LunaContext.Connection
    '        Dim Sql As String = "DELETE FROM TD_TipoCommessa"
    '        Sql &= " Where IdTipoCom = " & Id
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


