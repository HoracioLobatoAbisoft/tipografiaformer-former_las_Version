#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: DC Consultilng srl
'Date: 14/10/2008
#End Region

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports FormerLib.FormerEnum
Imports System.Drawing
Imports FormerBusinessLogicInterface
Imports FormerLib

'Public Class cOrdiniCrono

'#Region "Property"

'    Private _IdCronoOrd As Integer
'    Public Property IdCronoOrd() As Integer
'        Get
'            Return _IdCronoOrd
'        End Get
'        Set(ByVal value As Integer)
'            _IdCronoOrd = value
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

'    Private _DataCrono As DateTime
'    Public Property DataCrono() As DateTime
'        Get
'            Return _DataCrono
'        End Get
'        Set(ByVal value As DateTime)
'            _DataCrono = value
'        End Set
'    End Property

'    Private _IdStato As Integer
'    Public Property IdStato() As Integer
'        Get
'            Return _IdStato
'        End Get
'        Set(ByVal value As Integer)
'            _IdStato = value
'        End Set
'    End Property

'    Private _IdOperatore As Integer
'    Public Property IdOperatore() As Integer
'        Get
'            Return _IdOperatore
'        End Get
'        Set(ByVal value As Integer)
'            _IdOperatore = value
'        End Set
'    End Property
'#End Region

'#Region "Method"
'    Public Function IsValid() As Boolean
'        Dim Ris As Boolean = True

'        Return Ris
'    End Function

'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_OrdiniCrono where IdCronoOrd = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdCronoOrd = myReader("IdCronoOrd")
'                If Not myReader("IdOrd") Is DBNull.Value Then
'                    _IdOrd = myReader("IdOrd").toString
'                End If
'                _DataCrono = myReader("DataCrono")
'                _IdStato = myReader("IdStato")
'                _IdOperatore = myReader("IdOperatore")
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

'    Public Function Save() As Integer

'        Dim Ris As Integer = 0

'        Try
'            Dim sql As String
'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = LUNA.LunaContext.Connection
'            If _IdCronoOrd = 0 Then
'                sql = "INSERT INTO T_OrdiniCrono("
'                sql &= "IdOrd,"
'                sql &= "DataCrono,"
'                sql &= "IdStato,"
'                sql &= "IdOperatore"
'                sql &= ") VALUES ("
'                sql &= _IdOrd & ","
'                sql &= ap(_DataCrono) & ","
'                sql &= _IdStato & ","
'                sql &= _IdOperatore
'                sql &= ")"
'            Else
'                sql = "UPDATE T_OrdiniCrono SET "
'                sql &= "IdOrd = " & _IdOrd & ","
'                sql &= "DataCrono = " & ap(_DataCrono) & ","
'                sql &= "IdStato = " & _IdStato & ","
'                sql &= "IdOperatore = " & _IdOperatore
'                sql &= " WHERE IdCronoOrd= " & _IdCronoOrd
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()
'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'#End Region

'End Class

'Public Class cOrdiniCronoColl

'    Public Function Lista() As DataTable
'        Dim datatb As DataTable = New DataTable("T_OrdiniCrono")
'        Try

'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            Dim sql As String = ""
'            sql = "SELECT IdCronoOrd, IdOrd, DataCrono, IdStato, IdOperatore from T_OrdiniCrono"
'            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

'            myCommand.CommandText = sql
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            datatb.Load(myReader)
'            myReader.Close()
'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'        End Try
'        Return datatb
'    End Function

'    'Public Function Delete(ByVal Id As Integer) As Integer
'    '    Dim Ris As Integer = 0
'    '    Try

'    '        Dim myCommand As SqlCommand = New SqlCommand()
'    '        myCommand.Connection = LUNA.LunaContext.Connection
'    '        Dim Sql As String = "DELETE FROM T_OrdiniCrono"
'    '        Sql &= " Where IdCronoOrd = " & Id
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

'Public Class cOrdini

'#Region "Property"

'    Private _IdOrd As Integer
'    Public Property IdOrd() As Integer
'        Get
'            Return _IdOrd
'        End Get
'        Set(ByVal value As Integer)
'            _IdOrd = value
'        End Set
'    End Property

'    Public ReadOnly Property Numero() As Integer
'        Get
'            Return _IdOrd
'        End Get
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

'    Private _PeriodoPrevConsegna As Integer = 0
'    Public Property PeriodoPrevConsegna() As Integer
'        Get
'            Return _PeriodoPrevConsegna
'        End Get
'        Set(ByVal value As Integer)
'            _PeriodoPrevConsegna = value
'        End Set
'    End Property

'    Private _IdTipoProd As Integer
'    Public Property IdTipoProd() As Integer
'        Get
'            Return _IdTipoProd
'        End Get
'        Set(ByVal value As Integer)
'            _IdTipoProd = value
'        End Set
'    End Property

'    Private _IdProd As Integer
'    Public Property IdProd() As Integer
'        Get
'            Return _IdProd
'        End Get
'        Set(ByVal value As Integer)
'            _IdProd = value
'        End Set
'    End Property

'    Private _IdRub As Integer
'    Public Property IdRub() As Integer
'        Get
'            Return _IdRub
'        End Get
'        Set(ByVal value As Integer)
'            _IdRub = value
'        End Set
'    End Property

'    Private _Qta As Integer
'    Public Property Qta() As Integer
'        Get
'            Return _Qta
'        End Get
'        Set(ByVal value As Integer)
'            _Qta = value
'        End Set
'    End Property

'    Private _Lungo As Single
'    Public Property Lungo() As Single
'        Get
'            Return _Lungo
'        End Get
'        Set(ByVal value As Single)
'            _Lungo = value
'        End Set
'    End Property

'    Private _Largo As Single
'    Public Property Largo() As Single
'        Get
'            Return _Largo
'        End Get
'        Set(ByVal value As Single)
'            _Largo = value
'        End Set
'    End Property

'    Private _DataIns As Date = Date.Now
'    Public Property DataIns() As Date
'        Get
'            Return _DataIns
'        End Get
'        Set(ByVal value As Date)
'            _DataIns = value
'        End Set
'    End Property

'    Private _DataCambioStato As Date = Date.Now
'    Public Property DataCambioStato() As Date
'        Get
'            Return _DataCambioStato
'        End Get
'        Set(ByVal value As Date)
'            _DataCambioStato = value
'        End Set
'    End Property

'    Private _DataPrevConsegna As DateTime
'    Public Property DataPrevConsegna() As DateTime
'        Get
'            Return _DataPrevConsegna
'        End Get
'        Set(ByVal value As DateTime)
'            _DataPrevConsegna = value
'        End Set
'    End Property

'    Private _DataEffConsegna As DateTime
'    Public Property DataEffConsegna() As DateTime
'        Get
'            Return _DataEffConsegna
'        End Get
'        Set(ByVal value As DateTime)
'            _DataEffConsegna = value
'        End Set
'    End Property

'    Private _OrdMail As Boolean = False
'    Public Property OrdMail() As Boolean
'        Get
'            Return _OrdMail
'        End Get
'        Set(ByVal value As Boolean)
'            _OrdMail = value
'        End Set
'    End Property

'    Private _Stato As Integer = enStatoOrdine.Preinserito
'    Public Property Stato() As Integer
'        Get
'            Return _Stato
'        End Get
'        Set(ByVal value As Integer)
'            _Stato = value
'        End Set
'    End Property

'    Private _StatoStringa As String
'    Public ReadOnly Property StatoStringa() As String
'        Get
'            Select Case _Stato
'                Case enStatoOrdine.Preinserito
'                    Return "Preinserito"
'                Case enStatoOrdine.Registrato
'                    Return "Registrato"
'                Case enStatoOrdine.ProntoRitiro
'                    Return "Pronto per la consegna"
'                Case enStatoOrdine.StampaInizio
'                    Return "In Lavorazione"
'                Case enStatoOrdine.Imballaggio
'                    Return "Imballaggio"
'                Case enStatoOrdine.InConsegna
'                    Return "In Consegna"
'                Case enStatoOrdine.PagatoInteramente
'                    Return "Pagato"
'                Case enStatoOrdine.Consegnato
'                    Return "Consegnato"
'                Case enStatoOrdine.Rifiutato
'                    Return "Rifiutato"

'            End Select
'        End Get
'    End Property

'    Private _PrezzoProd As Decimal
'    Public Property PrezzoProd() As Decimal
'        Get
'            Return _PrezzoProd
'        End Get
'        Set(ByVal value As Decimal)
'            _PrezzoProd = value
'        End Set
'    End Property

'    Private _TotaleForn As Decimal
'    Public Property TotaleForn() As Decimal
'        Get
'            Return _TotaleForn
'        End Get
'        Set(ByVal value As Decimal)
'            _TotaleForn = value
'        End Set
'    End Property

'    Public ReadOnly Property TotaleImponibile() As Decimal
'        Get
'            Return _TotaleForn + _Ricarico - _Sconto
'        End Get
'    End Property

'    Private _Iva As Decimal
'    Public Property Iva() As Decimal
'        Get
'            Return _Iva
'        End Get
'        Set(ByVal value As Decimal)
'            _Iva = value
'        End Set
'    End Property

'    Private _CostoSped As Decimal
'    Public Property CostoSped() As Decimal
'        Get
'            Return _CostoSped
'        End Get
'        Set(ByVal value As Decimal)
'            _CostoSped = value
'        End Set
'    End Property

'    Private _Sconto As Decimal
'    Public Property Sconto() As Decimal
'        Get
'            Return _Sconto
'        End Get
'        Set(ByVal value As Decimal)
'            _Sconto = value
'        End Set
'    End Property

'    Private _Ricarico As Decimal = 0
'    Public Property Ricarico() As Decimal
'        Get
'            Return _Ricarico
'        End Get
'        Set(ByVal value As Decimal)
'            _Ricarico = value
'        End Set
'    End Property

'    Private _Prezzo As Decimal
'    Public Property Prezzo() As Decimal
'        Get
'            Return _Prezzo
'        End Get
'        Set(ByVal value As Decimal)
'            _Prezzo = value
'        End Set
'    End Property

'    Private _IdCorriere As Integer = 0
'    Public Property IdCorriere() As Integer
'        Get
'            Return _IdCorriere
'        End Get
'        Set(ByVal value As Integer)
'            _IdCorriere = value
'        End Set
'    End Property

'    Private _Preventivo As Integer = 0
'    Public Property Preventivo() As Integer
'        Get
'            Return _Preventivo
'        End Get
'        Set(ByVal value As Integer)
'            _Preventivo = value
'        End Set
'    End Property

'    Private _File As String = ""
'    Public Property File() As String
'        Get
'            Return _File
'        End Get
'        Set(ByVal value As String)
'            _File = value
'        End Set
'    End Property

'    Private _OraConsegna As String = ""
'    Public Property OraConsegna() As String
'        Get
'            Return _OraConsegna
'        End Get
'        Set(ByVal value As String)
'            _OraConsegna = value
'        End Set
'    End Property


'    Private _FileSorgente As String = ""
'    Public Property FileSorgente() As String
'        Get
'            Return _FileSorgente
'        End Get
'        Set(ByVal value As String)
'            _FileSorgente = value
'        End Set
'    End Property

'    Private _NomeFileOriginale As String = ""
'    Public Property NomeFileOriginale() As String
'        Get
'            Return _NomeFileOriginale
'        End Get
'        Set(ByVal value As String)
'            _NomeFileOriginale = value
'        End Set
'    End Property

'    Private _Annotazioni As String
'    Public Property Annotazioni() As String
'        Get
'            Return _Annotazioni
'        End Get
'        Set(ByVal value As String)
'            _Annotazioni = value
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

'    Private _RilascioCli As Integer = 0
'    Public Property RilascioCli() As Integer
'        Get
'            Return _RilascioCli
'        End Get
'        Set(ByVal value As Integer)
'            _RilascioCli = value
'        End Set
'    End Property

'    Private _TipoConsegna As Integer = 0
'    Public Property TipoConsegna() As Integer
'        Get
'            Return _TipoConsegna
'        End Get
'        Set(ByVal value As Integer)
'            _TipoConsegna = value
'        End Set
'    End Property
'#End Region

'#Region "Method"

'    Public Function CalcolaDataConsegna(Optional ByVal TipoConsegnaForzata As Integer = -1, Optional ByVal IdProdotto As Integer = -1, Optional ByVal IdCorr As Integer = -1) As Date

'        'qui devo calcolare la data di consegna prevista in base ai parametri presenti nell'ordine
'        'questa funzione viene chiamata solo in fase di inserimento e scaricamento automatico dell'ordine
'        Dim DataPrevistaConsegna As Date = Now.Date.AddDays(3)
'        Dim VarProd As Integer = _IdProd
'        Dim VarCorr As Integer = _IdCorriere
'        If IdProdotto <> -1 Then VarProd = IdProdotto
'        If IdCorr <> -1 Then VarCorr = IdCorr

'        If VarProd <> 0 And VarCorr <> 0 Then

'            Dim Prod As New Prodotto
'            Prod.Read(VarProd)

'            If Prod.GGNormale Then

'                Dim Corr As New Corriere

'                Corr.Read(VarCorr)
'                Dim GGCorr As Integer = Corr.GGConsegna
'                Corr = Nothing

'                DataPrevistaConsegna = Now.Date.AddDays(GGCorr)
'                Dim VarTipo As Integer = _TipoConsegna
'                If TipoConsegnaForzata <> -1 Then VarTipo = TipoConsegnaForzata

'                Select Case VarTipo
'                    Case enTipoConsegna.Normale
'                        DataPrevistaConsegna = DataPrevistaConsegna.AddDays(Prod.GGNormale - 1)
'                    Case enTipoConsegna.Fast
'                        DataPrevistaConsegna = DataPrevistaConsegna.AddDays(Prod.GGFast - 1)
'                    Case enTipoConsegna.Slow
'                        DataPrevistaConsegna = DataPrevistaConsegna.AddDays(Prod.GGLow - 1)

'                End Select
'                'qui devo anche calcolare che se c'e' una domenica di mezzo devo aggiungere un altro giorno

'                If Now.Hour >= 13 Then DataPrevistaConsegna = DataPrevistaConsegna.AddDays(1)

'                Dim DomenicheTrovate As Integer = TrovaDomeniche(DataPrevistaConsegna)
'                DataPrevistaConsegna = DataPrevistaConsegna.AddDays(DomenicheTrovate)

'                If DataPrevistaConsegna.DayOfWeek = DayOfWeek.Sunday Then DataPrevistaConsegna = DataPrevistaConsegna.AddDays(1)

'            End If
'        End If
'        Return DataPrevistaConsegna

'    End Function

'    Private Function TrovaDomeniche(ByVal DataFinale As Date) As Integer

'        Dim Ris As Integer = 0
'        Dim dataIn As Date = Now
'        While DataFinale >= dataIn

'            If dataIn.DayOfWeek = DayOfWeek.Sunday Then Ris += 1
'            dataIn = dataIn.AddDays(1)
'        End While

'        Return Ris

'    End Function

'    Public Function CalcolaPrezzo(ByVal Prezzo As Single, ByVal PercFast As Integer, ByVal PercLow As Integer) As Single
'        Dim PrezzoRif As Double
'        PrezzoRif = Prezzo

'        If _TipoConsegna = enTipoConsegna.Fast Then
'            PrezzoRif += PrezzoRif * PercFast / 100
'        End If
'        If _TipoConsegna = enTipoConsegna.Slow Then
'            PrezzoRif -= PrezzoRif * PercLow / 100
'        End If
'        Return PrezzoRif
'    End Function

'    Public ReadOnly Property CollSorgenti() As CollectionBase
'        Get

'            Dim sorgenti As New cSorgentiCollezione(_IdOrd)
'            sorgenti.RiempiLista()

'            CollSorgenti = sorgenti

'        End Get
'    End Property

'    Public Function IsValid() As Boolean
'        Dim Ris As Boolean = True

'        If _Qta < 1 Then

'            Ris = False

'        End If

'        If _Prezzo < 0 Then

'            Ris = False

'        End If

'        If _File.Length = 0 Then

'            Ris = False

'        End If

'        Return Ris
'    End Function

'    Private _NumColli As Integer = 0

'    Public Function GetNumColli() As Integer
'        Dim Ris As Integer = 0
'        Try

'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            Dim sql As String = ""
'            sql = "SELECT numcolli from t_prodotti where idprod = " & _IdProd
'            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA


'            myCommand.CommandText = sql
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

'            myReader.Read()


'            Ris = myReader("numcolli")
'            _NumColli = Ris


'            myReader.Close()

'            myCommand.Dispose()


'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris

'    End Function

'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_Ordini where IdOrd = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdOrd = myReader("IdOrd")
'                If Not myReader("IdCom") Is DBNull.Value Then
'                    _IdCom = myReader("IdCom").ToString
'                End If
'                If Not myReader("IdTipoProd") Is DBNull.Value Then
'                    _IdTipoProd = myReader("IdTipoProd").ToString
'                End If
'                If Not myReader("IdProd") Is DBNull.Value Then
'                    _IdProd = myReader("IdProd").ToString
'                End If
'                If Not myReader("OrdMail") Is DBNull.Value Then
'                    _OrdMail = myReader("OrdMail")
'                End If
'                If Not myReader("IdRub") Is DBNull.Value Then
'                    _IdRub = myReader("IdRub").ToString
'                End If
'                If Not myReader("PeriodoPrevConsegna") Is DBNull.Value Then
'                    _PeriodoPrevConsegna = myReader("PeriodoPrevConsegna").ToString
'                End If
'                If Not myReader("OraConsegna") Is DBNull.Value Then
'                    _OraConsegna = myReader("OraConsegna").ToString
'                End If
'                If Not myReader("Lungo") Is DBNull.Value Then
'                    _Lungo = myReader("Lungo").ToString
'                End If
'                If Not myReader("Largo") Is DBNull.Value Then
'                    _Largo = myReader("Largo").ToString
'                End If
'                If Not myReader("DataIns") Is DBNull.Value Then
'                    _DataIns = myReader("DataIns").ToString
'                End If
'                If Not myReader("DataCambioStato") Is DBNull.Value Then
'                    _DataCambioStato = myReader("DataCambioStato").ToString
'                End If
'                If Not myReader("DataPrevConsegna") Is DBNull.Value Then
'                    _DataPrevConsegna = myReader("DataPrevConsegna").ToString
'                End If
'                If Not myReader("DataEffConsegna") Is DBNull.Value Then
'                    _DataEffConsegna = myReader("DataEffConsegna").ToString
'                End If

'                If Not myReader("Stato") Is DBNull.Value Then
'                    _Stato = myReader("Stato").ToString
'                End If
'                If Not myReader("PrezzoProd") Is DBNull.Value Then
'                    _PrezzoProd = myReader("PrezzoProd").ToString
'                End If
'                If Not myReader("Qta") Is DBNull.Value Then
'                    _Qta = myReader("Qta").ToString
'                End If
'                If Not myReader("TotaleForn") Is DBNull.Value Then
'                    _TotaleForn = myReader("TotaleForn").ToString
'                End If
'                If Not myReader("Iva") Is DBNull.Value Then
'                    _Iva = myReader("Iva").ToString
'                End If
'                If Not myReader("CostoSped") Is DBNull.Value Then
'                    _CostoSped = myReader("CostoSped").ToString
'                End If
'                If Not myReader("Sconto") Is DBNull.Value Then
'                    _Sconto = myReader("Sconto").ToString
'                End If
'                If Not myReader("Ricarico") Is DBNull.Value Then
'                    _Ricarico = myReader("Ricarico").ToString
'                End If
'                If Not myReader("Preventivo") Is DBNull.Value Then
'                    _Preventivo = myReader("Preventivo").ToString
'                End If
'                If Not myReader("Prezzo") Is DBNull.Value Then
'                    _Prezzo = myReader("Prezzo").ToString
'                End If
'                If Not myReader("IdCorriere") Is DBNull.Value Then
'                    _IdCorriere = myReader("IdCorriere").ToString
'                End If
'                If Not myReader("File") Is DBNull.Value Then
'                    _File = myReader("File").ToString
'                End If
'                If Not myReader("FileSorgente") Is DBNull.Value Then
'                    _FileSorgente = myReader("FileSorgente").ToString
'                End If
'                If Not myReader("NomeFileOriginale") Is DBNull.Value Then
'                    _NomeFileOriginale = myReader("NomeFileOriginale").ToString
'                End If
'                If Not myReader("Annotazioni") Is DBNull.Value Then
'                    _Annotazioni = myReader("Annotazioni").ToString
'                End If
'                If Not myReader("IdDoc") Is DBNull.Value Then
'                    _IdDoc = myReader("IdDoc").ToString
'                End If
'                If Not myReader("TipoConsegna") Is DBNull.Value Then
'                    _TipoConsegna = myReader("TipoConsegna").ToString
'                End If
'                If Not myReader("RilascioCli") Is DBNull.Value Then
'                    _RilascioCli = myReader("RilascioCli").ToString
'                End If
'            Else
'                Ris = 1
'            End If
'            myReader.Close()
'            myCommand.Dispose()

'            'qui devo leggere la collezione dei sorgenti

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
'            If _IdOrd = 0 Then
'                sql = "INSERT INTO T_Ordini("
'                sql &= "IdCom,"
'                sql &= "IdTipoProd,"
'                sql &= "IdProd,"
'                sql &= "IdRub,"
'                sql &= "Lungo,"
'                sql &= "Largo,"
'                sql &= "DataIns,"
'                sql &= "DataCambioStato,"
'                sql &= "DataPrevConsegna,"
'                sql &= "DataEffConsegna,"
'                sql &= "PeriodoPrevConsegna,"
'                sql &= "OraConsegna,"
'                sql &= "Stato,"
'                sql &= "PrezzoProd,"
'                sql &= "Qta,"
'                sql &= "TotaleForn,"
'                sql &= "Iva,"
'                sql &= "CostoSped,"
'                sql &= "Sconto,"
'                sql &= "Ricarico,"
'                sql &= "Preventivo,"
'                sql &= "Prezzo,"
'                sql &= "IdCorriere,"
'                sql &= "File,"
'                sql &= "FileSorgente,"
'                sql &= "NomeFileOriginale,"
'                sql &= "ordMail,"
'                sql &= "Annotazioni,"
'                sql &= "TipoConsegna,"
'                sql &= "RilascioCli,"
'                sql &= "IdDoc"
'                sql &= ") VALUES ("
'                sql &= _IdCom & ","
'                sql &= _IdTipoProd & ","
'                sql &= _IdProd & ","
'                sql &= _IdRub & ","
'                sql &= Ap(_Lungo) & ","
'                sql &= Ap(_Largo) & ","
'                sql &= Ap(_DataIns) & ","
'                sql &= Ap(_DataCambioStato) & ","
'                sql &= Ap(_DataPrevConsegna) & ","
'                sql &= Ap(_DataEffConsegna) & ","
'                sql &= _PeriodoPrevConsegna & ","
'                sql &= Ap(_OraConsegna) & ","
'                sql &= _Stato & ","
'                sql &= Ap(_PrezzoProd) & ","
'                sql &= _Qta & ","
'                sql &= Ap(_TotaleForn) & ","
'                sql &= Ap(_Iva) & ","
'                sql &= Ap(_CostoSped) & ","
'                sql &= Ap(_Sconto) & ","
'                sql &= Ap(_Ricarico) & ","
'                sql &= _Preventivo & ","
'                sql &= Ap(_Prezzo) & ","
'                sql &= _IdCorriere & ","
'                sql &= Ap(_File) & ","
'                sql &= Ap(_FileSorgente.ToString) & ","
'                sql &= Ap(_NomeFileOriginale.ToString) & ","
'                sql &= _OrdMail & ","
'                sql &= Ap(_Annotazioni) & ","
'                sql &= _TipoConsegna & ","
'                sql &= _RilascioCli & ","
'                sql &= _IdDoc
'                sql &= ")"
'            Else
'                sql = "UPDATE T_Ordini SET "
'                sql &= "IdCom = " & _IdCom & ","
'                sql &= "IdTipoProd = " & _IdTipoProd & ","
'                sql &= "IdProd = " & _IdProd & ","
'                sql &= "IdRub = " & _IdRub & ","
'                sql &= "Lungo = " & Ap(_Lungo) & ","
'                sql &= "Largo = " & Ap(_Largo) & ","
'                'sql &= "DataIns = " & ap(_DataIns) & ","
'                sql &= "DataCambioStato = " & Ap(_DataCambioStato) & ","
'                sql &= "DataPrevConsegna = " & Ap(_DataPrevConsegna) & ","
'                sql &= "DataEffConsegna = " & Ap(_DataEffConsegna) & ","
'                sql &= "PeriodoPrevConsegna = " & _PeriodoPrevConsegna & ","
'                sql &= "OraConsegna = " & Ap(_OraConsegna) & ","
'                sql &= "Stato = " & _Stato & ","
'                sql &= "PrezzoProd = " & Ap(_PrezzoProd) & ","
'                sql &= "Qta = " & _Qta & ","
'                sql &= "TotaleForn = " & Ap(_TotaleForn) & ","
'                sql &= "Iva = " & Ap(_Iva) & ","
'                sql &= "CostoSped = " & Ap(_CostoSped) & ","
'                sql &= "Sconto = " & Ap(_Sconto) & ","
'                sql &= "Ricarico = " & Ap(_Ricarico) & ","
'                sql &= "Preventivo = " & _Preventivo & ","
'                sql &= "Prezzo = " & Ap(_Prezzo) & ","
'                sql &= "IdCorriere = " & _IdCorriere & ","
'                sql &= "File = " & Ap(_File) & ","
'                sql &= "FileSorgente = " & Ap(_FileSorgente.ToString) & ","
'                sql &= "NomeFileOriginale = " & Ap(_NomeFileOriginale.ToString) & ","
'                sql &= "OrdMail = " & _OrdMail & ","
'                sql &= "Annotazioni = " & Ap(_Annotazioni) & ","
'                sql &= "TipoConsegna = " & _TipoConsegna & ","
'                sql &= "RilascioCli = " & _RilascioCli & ","
'                sql &= "IdDoc = " & _IdDoc
'                sql &= " WHERE IdOrd= " & _IdOrd
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            'If idinserito = 0 Then
'            sql = "select @@identity"
'            myCommand.CommandText = sql
'            IdInserito = myCommand.ExecuteScalar()

'            If _IdOrd = 0 Then
'                _IdOrd = IdInserito
'                If _OrdMail Then
'                    InserisciLog(enStatoOrdine.Preinserito)
'                Else
'                    InserisciLog(enStatoOrdine.Registrato)
'                End If
'                InserisciLavorazioni()

'            End If


'            'End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'    Public Function SalvaFile() As Integer

'        Dim Ris As Integer = 0

'        Try
'            Dim sql As String
'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = LUNA.LunaContext.Connection

'            sql = "UPDATE T_Ordini SET "
'            sql &= "File = " & Ap(_File)
'            sql &= " WHERE IdOrd= " & _IdOrd

'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()
'            'End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'    Public Function SalvaIdDocumento() As Integer

'        Dim Ris As Integer = 0

'        Try
'            Dim sql As String
'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = LUNA.LunaContext.Connection

'            sql = "UPDATE T_Ordini SET "
'            sql &= "iddoc = " & Ap(_IdDoc)
'            sql &= " WHERE IdOrd= " & _IdOrd

'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()
'            'End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'    Public Function SalvaDatiConsegna() As Integer

'        Dim Ris As Integer = 0

'        Try
'            Dim sql As String
'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = LUNA.LunaContext.Connection

'            sql = "UPDATE T_Ordini SET "

'            sql &= "DataPrevConsegna = " & Ap(_DataPrevConsegna) & ","
'            sql &= "PeriodoPrevConsegna = " & _PeriodoPrevConsegna & ","
'            sql &= "OraConsegna = " & Ap(_OraConsegna)

'            sql &= " WHERE IdOrd= " & _IdOrd

'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()
'            'End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'    Public Function SalvaCliente() As Integer

'        Dim Ris As Integer = 0

'        Try
'            Dim sql As String
'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = LUNA.LunaContext.Connection

'            sql = "UPDATE T_Ordini SET "

'            sql &= "idRub = " & _IdRub

'            sql &= " WHERE IdOrd= " & _IdOrd

'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()
'            'End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'    Public ReadOnly Property CreaRiepilogo()
'        Get
'            Dim bufferHtml As String = ""

'            Dim _ordsel As cOrdini = Me

'            bufferHtml = "<HTML><HEAD><TITLE>Riepilogo</TITLE></HEAD><BODY BGCOLOR=""WHITE""><FONT SIZE=1 face=Arial>" & ControlChars.NewLine

'            'qui carico se ha immagini e in caso faccio il box incorniciato

'            bufferHtml &= "<FONT SIZE=4><CENTER>Riepilogo Ordine</CENTER></FONT><BR><BR>"

'            bufferHtml &= "Prodotto <BR>"

'            Dim p As New Prodotto
'            p.Read(_ordsel.IdProd)

'            bufferHtml &= "<FONT SIZE=6>" & p.Descrizione & "<BR><BR>"

'            p = Nothing

'            bufferHtml &= "<TABLE WIDTH=100%>"
'            bufferHtml &= "<TR>"
'            bufferHtml &= "<TD VALIGN=Top width=50%>"
'            bufferHtml &= "<FONT Face=Arial>"

'            bufferHtml &= "<FONT SIZE=1> Data: <FONT SIZE=3><b>" & _ordsel.DataIns & "</b></FONT><BR><BR>"
'            bufferHtml &= "Ordine N: <FONT SIZE=6>" & _ordsel.Numero & "</FONT><BR><BR>"
'            bufferHtml &= "Nome file originale: <FONT SIZE=3><b>" & _ordsel.NomeFileOriginale.ToString & "</b></FONT><BR><BR>"
'            bufferHtml &= "Ordine Email: <FONT SIZE=3><b>" & IIf(_ordsel.OrdMail, "SI", "NO") & "</b></FONT><BR><BR>"


'            Dim cli As New VoceRubrica
'            cli.Read(_ordsel.IdRub)

'            bufferHtml &= "Cliente:<BR> <FONT SIZE=3><B>" & IIf(cli.RagSoc.Length, cli.RagSoc & "<BR>", "") & IIf(cli.Cognome.Length, cli.Cognome & " " & cli.Nome & "<BR>", "") & cli.Indirizzo & "<BR>" & cli.Tel & "</B></FONT><BR><BR>"

'            'qui carico i dettagli delle lavorazioni per questo ordine

'            Dim x As New cLavoriColl
'            Dim Dt As DataTable, Dr As DataRow
'            bufferHtml &= "Lavorazioni:<BR> <FONT SIZE=3>"

'            Dt = x.ListaLavoriOrd(_ordsel.IdOrd)

'            For Each Dr In Dt.Rows

'                bufferHtml &= " - <B>" & Dr("Descrizione") & "</B><BR>"

'            Next

'            bufferHtml &= "</FONT><BR><BR>"

'            bufferHtml &= "Condizioni economiche:<BR><TABLE width=200>"

'            bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Prezzo </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormattaPrezzo(_ordsel.PrezzoProd) & "</B></FONT><BR></TD></TR>"
'            bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Qta </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & _ordsel.Qta & "</B></FONT><BR></TD></TR>"
'            bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Totale Fornitura </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormattaPrezzo(_ordsel.TotaleForn) & "</B></FONT><BR></TD></TR>"
'            bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Iva </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormattaPrezzo(_ordsel.Iva) & "</B></FONT><BR></TD></TR>"
'            bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Corriere </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormattaPrezzo(_ordsel.CostoSped) & "</B></FONT><BR></TD></TR>"
'            bufferHtml &= "<TR><TD><FONT FACE=Arial size=1>Sconto </TD><TD align=right><FONT FACE=Arial><FONT SIZE=3><B>" & FormattaPrezzo(_ordsel.Sconto) & "</B></FONT><BR></TD></TR>"
'            bufferHtml &= "<TR><TD><FONT FACE=Arial><FONT SIZE=3>TOT. ORDINE </TD><TD align=right><FONT FACE=Arial><FONT SIZE=5><B>" & FormattaPrezzo(_ordsel.Prezzo) & "</B></FONT><BR></TD></TR>"

'            bufferHtml &= "</TABLE>"
'            bufferHtml &= "</FONT>"
'            bufferHtml &= "</TD>"
'            bufferHtml &= "<TD VALIGN=Top width=50%><IMG SRC=""" & _ordsel.File & """ WIDTH=400>"
'            bufferHtml &= "</TD>"

'            bufferHtml &= "</TR>"
'            bufferHtml &= "</TABLE>"

'            bufferHtml &= "</BODY></HTML>" & ControlChars.NewLine

'            Return bufferHtml
'        End Get
'    End Property

'    Public ReadOnly Property CreaRiepilogoStatoLavori() As String
'        Get

'            Dim bufferHtml As String = ""

'            Dim _ordsel As cOrdini = Me
'            'bufferHtml = "<HTML><HEAD><TITLE>Stato Lavorazioni</TITLE></HEAD><BODY BGCOLOR=""WHITE"">"
'            bufferHtml = "<BR><FONT SIZE=1 face=Arial>" & ControlChars.NewLine

'            Dim x As New cLavLogColl, Dt As DataTable, DR As DataRow

'            Dt = x.ListaLavoriCrono(_ordsel.IdOrd, _ordsel.IdCom)


'            bufferHtml &= "<TABLE WIDtH=100% border=1>"
'            bufferHtml &= "<TR><TD>&nbsp;</TD><TD><Font Face=arial size=1><B>Quando</TD><TD><Font Face=arial size=1><B>Lavorazione</TD><TD><Font Face=arial size=1><B>Min</B></TD></TR>"
'            For Each DR In Dt.Rows

'                bufferHtml &= "<TR><TD width=25 align=center valign=center>"

'                If DR("Fine").ToString.Length Then
'                    bufferHtml &= "<img width=25 src=""" & Postazione.IconaOk & """>"

'                Else
'                    bufferHtml &= "<img width=25 src=""" & Postazione.IconaCancel & """>"
'                End If

'                bufferHtml &= "</TD>"
'                bufferHtml &= "<TD align=left valign=center><Font Face=arial size=1>"
'                Dim Posizione2900 As Integer = DR("inizio").ToString.IndexOf("2900")
'                If Posizione2900 = -1 Then bufferHtml &= DR("Inizio").ToString Else bufferHtml &= " - "

'                bufferHtml &= "&nbsp;"

'                bufferHtml &= "</TD><TD align=left valign=center><Font Face=arial size=1>"

'                bufferHtml &= DR("Stato").ToString


'                bufferHtml &= "</TD><TD align=left valign=center><Font Face=arial size=1>"

'                bufferHtml &= DR("Tempo").ToString

'                bufferHtml &= "</TD>"

'                bufferHtml &= "</TR>"

'            Next

'            bufferHtml &= "</TABLE>"

'            bufferHtml &= "</BODY></HTML>" & ControlChars.NewLine

'            Return bufferHtml

'        End Get
'    End Property

'    Public ReadOnly Property CreaRiepilogoBreve()
'        Get
'            Dim bufferHtml As String = ""

'            Dim _ordsel As cOrdini = Me

'            bufferHtml = "<HTML><HEAD><TITLE>Riepilogo</TITLE></HEAD><BODY BGCOLOR=""WHITE""><FONT SIZE=1 face=Arial>" & ControlChars.NewLine

'            'qui carico se ha immagini e in caso faccio il box incorniciato

'            '            bufferHtml &= "<FONT SIZE=4><CENTER>Riepilogo Ordine</CENTER></FONT><BR><BR>"

'            Dim cli As New VoceRubrica
'            cli.Read(_ordsel.IdRub)
'            Dim Corr As New Corriere
'            Corr.Read(cli.IdCorriere)

'            bufferHtml &= "<FONT SIZE=2><B>" & cli.IdRub & " - " & _
'                IIf(cli.RagSoc.Length, cli.RagSoc & "<BR>", "") & "</b>" & _
'                IIf(cli.Cognome.Length, cli.Cognome & " " & cli.Nome & "<BR>", "") & _
'                "<font size=1>" & cli.Indirizzo & " " & cli.CAP & " " & cli.Citta & "</font><BR>" & _
'                "<font size=1>Tel. </Font><FONT SIZE=2><B>" & cli.Tel & IIf(cli.Cellulare.Length, "</B><BR></FONT><font size=1> Cel.</FONT> <FONT SIZE=2><B>" & cli.Cellulare, "") & "</B></FONT> <br><A HREF=""mailto:" & cli.Email & """>" & cli.Email & "</A><br>" & _
'                "<font size=1>P.Iva</font> " & cli.Piva & " <br><font size=1>Chiave </FONT>" & cli.CalcolaChiave & "<br>" & _
'                "<font size=1>Pagamento </FONT>" & cli.Pagamento & "<bR><font size=1>Corriere </FONT>" & Corr.Descrizione & "</FONT><BR><BR>"

'            Corr = New Corriere

'            cli = Nothing
'            Dim strWidth As String = ""
'            Try
'                Dim x As Image = Image.FromFile(_ordsel.File)

'                If x.Width > x.Height Then
'                    strWidth = " width=200 "
'                Else
'                    strWidth = " height=200 "
'                End If

'            Catch ex As Exception

'            End Try


'            bufferHtml &= "<A HREF=""" & _ordsel.File & """ target=""_new""><IMG SRC=""" & _ordsel.File & """ " & strWidth & " border=0></A><BR>"
'            bufferHtml &= "Note: <BR>"
'            bufferHtml &= "<FONT SIZE=1>" & _ordsel.Annotazioni & "</FONT><BR><br>"
'            bufferHtml &= "Prodotto <BR>"

'            Dim p As New Prodotto
'            p.Read(_ordsel.IdProd)

'            bufferHtml &= "<FONT SIZE=3><B>" & p.Descrizione & "</B><BR><BR>"
'            bufferHtml &= "<FONT Face=Arial>"

'            bufferHtml &= "<FONT SIZE=1>Ordine N: <FONT SIZE=2><b>" & _ordsel.Numero & "</B> del <FONT SIZE=2><b>" & _ordsel.DataIns.Date & "</b><BR>"

'            bufferHtml &= "<br><B><FONT SIZE=2>Condizioni economiche</FONT></B>:<BR>"

'            Corr.Read(_ordsel.IdCorriere)

'            '            bufferHtml &= "<br><B>Trasporto:</B>: "
'            bufferHtml &= "<FONT FACE=Arial size=1>Trasporto <FONT FACE=Arial><FONT SIZE=2><B>" & Corr.Descrizione & " </B></FONT><BR>"
'            Corr = Nothing
'            bufferHtml &= "<FONT FACE=Arial size=1>Preventivo <FONT FACE=Arial><FONT SIZE=2><B>" & IIf(_ordsel.Preventivo = enPreventivoSiNo.No, "No", "Si") & "</B></FONT><BR>"
'            ' bufferHtml &= "<FONT FACE=Arial size=1>Prezzo <FONT FACE=Arial><FONT SIZE=2><B>" & FormattaPrezzo(_ordsel.PrezzoProd) & "</B></FONT><BR>"
'            bufferHtml &= "<FONT FACE=Arial size=1>Qta <FONT FACE=Arial><FONT SIZE=2><B>" & p.NumPezzi & "</B></FONT><BR>"
'            bufferHtml &= "<FONT FACE=Arial size=1>Totale Imponibile <FONT FACE=Arial><FONT SIZE=2><B>" & FormattaPrezzo(_ordsel.TotaleImponibile) & "</B></FONT><BR>"
'            '            bufferHtml &= "<FONT FACE=Arial size=1>Iva <FONT FACE=Arial><FONT SIZE=2><B>" & FormattaPrezzo(_ordsel.Iva) & "</B></FONT><BR>"
'            '            bufferHtml &= "<FONT FACE=Arial size=1>Corriere <FONT FACE=Arial><FONT SIZE=2><B>" & FormattaPrezzo(_ordsel.CostoSped) & "</B></FONT><BR>"
'            '            bufferHtml &= "<FONT FACE=Arial size=1>Sconto <FONT FACE=Arial><FONT SIZE=2><B>" & FormattaPrezzo(_ordsel.Sconto) & "</B></FONT><BR>"
'            '            bufferHtml &= "<FONT FACE=Arial><FONT SIZE=2>TOT. ORDINE <FONT FACE=Arial><FONT SIZE=3><B>" & FormattaPrezzo(_ordsel.Prezzo) & "</B></FONT><BR>"
'            p = Nothing
'            If _ordsel.IdDoc Then
'                bufferHtml &= "<br><B><FONT SIZE=2>Documento Fiscale </FONT></B>:<BR>"
'                Dim doc As New cContabRicavi, DescrDoc As String = ""

'                doc.Read(_ordsel.IdDoc)
'                If doc.IdDocRif Then
'                    doc.Read(doc.IdDocRif)
'                End If
'                DescrDoc = doc.TipoStringa & " numero " & doc.Numero & " del " & doc.DataRicavo.Date
'                bufferHtml &= "<FONT FACE=Arial><FONT SIZE=1>" & DescrDoc & "</FONT><BR>"
'                doc = Nothing


'            End If
'            bufferHtml &= "</FONT><BR>"
'            If _ordsel.File.ToString.Length Then

'                bufferHtml &= "<FONT SIZE=2><B>File</B>:<BR>"
'                bufferHtml &= "<FONT SIZE=1>Anteprima: <FONT SIZE=1 face=Arial><b><A HREF=""" & _ordsel.File.ToString & """ target=""_new"">" & _ordsel.File & "</A></b><BR>"

'            End If

'            Dim Sorgente As FileSorgente
'            For Each Sorgente In _ordsel.CollSorgenti
'                bufferHtml &= "<FONT SIZE=1>Sorgente: <FONT SIZE=1 face=Arial><b><A HREF=""" & Sorgente.File.ToString & """ target=""_new"">" & Sorgente.File & "</A></b><BR>"
'            Next



'            'bufferHtml &= "</BODY></HTML>" & ControlChars.NewLine

'            Return bufferHtml
'        End Get
'    End Property

'    Private Sub InserisciLavorazioni()

'        Dim sql As String
'        Dim myCommand As SqlCommand = New SqlCommand()
'        myCommand.Connection = LUNA.LunaContext.Connection

'        Dim Dt As DataTable, x As New cLavoriColl, Dr As DataRow


'        Dt = x.ListaProdottoSel(_IdProd)

'        For Each Dr In Dt.Rows

'            sql = "INSERT INTO T_LavLog("
'            sql &= "IdOrd,"
'            sql &= "Descrizione,"
'            sql &= "Macchinario,"
'            sql &= "Premio,"
'            sql &= "Tempo,"
'            sql &= "Ordine"
'            sql &= ") VALUES ("
'            sql &= _IdOrd & ","
'            sql &= Ap(Dr("Descrizione")) & ","
'            sql &= Ap(Dr("Macchinario")) & ","
'            sql &= Dr("Premio") & ","
'            sql &= Dr("TempoRif") & ","
'            sql &= Dr("ordine")
'            sql &= ")"

'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()


'        Next

'        myCommand.Dispose()

'    End Sub

'    Public Sub InserisciLog(ByVal stato As enStatoOrdine)

'        Dim sql As String
'        Dim myCommand As SqlCommand = New SqlCommand()
'        myCommand.Connection = LUNA.LunaContext.Connection


'        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand(), StatoAttuale As Integer

'        sql = "SELECT * from T_ORDINI where idord=  " & _IdOrd

'        myCommand.CommandText = sql

'        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

'        myReader.Read()

'        If myReader.HasRows Then

'            'qui ho qualche lavorazione aperta, controllo di che tipo si tratta e mi comporto di conseguenza
'            StatoAttuale = myReader("Stato")

'        End If

'        myReader.Close()
'        myCommand.Dispose()

'        If StatoAttuale <> CInt(stato) Then
'            sql = "UPDATE T_ORDINI SET STATO = " & stato & ",DataCambioStato = now WHERE IDORD=" & _IdOrd

'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()
'            _DataCambioStato = Date.Now
'            _Stato = stato

'            sql = "INSERT INTO T_OrdiniCrono("
'            sql &= "IdOrd,"
'            sql &= "DataCrono,"
'            sql &= "IdStato,"
'            sql &= "IdOperatore"
'            sql &= ") VALUES ("
'            sql &= _IdOrd & ","
'            'sql &= Ap(Date.Now) & ","
'            sql &= "now,"
'            sql &= stato & ","
'            sql &= Postazione.UtenteConnesso.IdUt
'            sql &= ")"

'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            'If stato = enStatoOrdine.ProntoRitiro Then
'            'If Postazione.InviaMail Then InviaMailCambiostato(Me)
'            'End If

'            'If Postazione.InviaMail Then InviaMailCambiostato(Me)
'            If stato = enStatoOrdine.Consegnato Then
'                'se lo stato e' consegnato aggiorno la data di effettiva consegna
'                sql = "UPDATE T_ORDINI SET DATAEffConsegna= now where idord = " & _IdOrd
'                myCommand.CommandText = sql
'                myCommand.ExecuteNonQuery()

'            End If

'            myCommand.Dispose()

'            RaiseEvent CambioStato()

'        End If


'    End Sub

'    Public Event CambioStato()

'    Public Function AvanzamentoLavori() As DataTable
'        Dim datatb As DataTable = New DataTable("T_OrdiniCrono")
'        Try

'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            Dim sql As String = ""
'            sql = "SELECT DataCrono as [Data], "

'            sql &= "switch(idstato=" & enStatoOrdine.Preinserito & ",'Preinserito',"
'            sql &= "idstato=" & enStatoOrdine.Registrato & ",iif((select idcom from t_ordini where idord = c.idord)=0,'Registrato','In coda di Stampa'),"
'            'sql &= "stato=" & enStatoOrdine.StampaInizio & ",'In lavorazione',"
'            sql &= "idstato=" & enStatoOrdine.StampaInizio & ",(select top 1 switch(idstato=3,iif(datacronofine is null,'In Stampa','Stampa Finita'),idstato=4,iif(datacronofine is null,'In Finitura su commessa','Finitura su commessa finita'),idstato=5,iif(datacronofine is null,'In Finitura su prodotti','Finitura su prodotti Finita')) from t_commesseCrono where idcom=(select idcom from t_ordini where idord = c.idord) order by datacronoinizio desc),"

'            sql &= "idstato=" & enStatoOrdine.Imballaggio & ",'Imballaggio',"
'            sql &= "idstato=" & enStatoOrdine.ProntoRitiro & ",'Pronto per la Consegna',"
'            sql &= "idstato=" & enStatoOrdine.InConsegna & ",'In Consegna',"
'            sql &= "idstato=" & enStatoOrdine.Consegnato & ",'Consegnato',"
'            sql &= "idstato=" & enStatoOrdine.PagatoInteramente & ",'Pagato',"
'            sql &= "idstato=" & enStatoOrdine.Rifiutato & ",'Rifiutato'"

'            sql &= ") as [Stato]"

'            sql &= ", Login as Operatore from T_OrdiniCrono c inner join t_utenti U on c.idoperatore = u.idut"
'            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
'            sql &= " where idord = " & _IdOrd
'            sql &= " Order by datacrono"
'            myCommand.CommandText = sql
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            datatb.Load(myReader)
'            myReader.Close()
'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'        End Try
'        Return datatb

'    End Function

'#End Region

'End Class

Public Class cOrdiniColl
    Inherits _cOldDao
    Private _IdRub As Integer

    Public Property IdRub() As Integer
        Get
            Return _IdRub
        End Get
        Set(ByVal value As Integer)
            _IdRub = value
        End Set
    End Property

    Public Function Lista(Optional ByVal Codice As String = "", Optional ByVal Stato As String = "", Optional ByVal IdCatProd As Integer = 0, _
                          Optional ByVal OnlyWithoutCom As Boolean = False, Optional ByVal ListaIdOrd As String = "", Optional ByVal NumSpazi As Boolean = False, _
                          Optional ByVal IdProd As Integer = 0, Optional ByVal OrderContrario As Boolean = False, Optional ByVal DataDal As Date = Nothing, _
                          Optional ByVal DataAl As Date = Nothing, _
                          Optional ByVal IdGruppo As Integer = 0, _
                          Optional ByVal IdCons As Integer = 0, _
                          Optional ByVal IdIndirizzo As Integer = -1, _
                          Optional OnlyLastSixMonth As Boolean = False) As DataTable

        Dim datatb As DataTable = New DataTable("T_Ordini")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT o.IdOrd as [Ord], o.datains as Data,"

            If NumSpazi = False Then
                sql &= "(select case when o.IdCom <>0 then o.idcom when o.idcom=0"
                sql &= " then ' - ' end) as Com,"
            End If

            sql &= "p.Descrizione as Prodotto,"
            'sql &= "r.RagSoc & ' - ' & r.Cognome & ' ' &  r.Nome as Cliente,"
            sql &= "r.RagSoc as Cliente,"
            'sql &= "switch(stato=" & enStatoOrdine.Preinserito & ",'Preinserito',"
            'sql &= "stato=" & enStatoOrdine.Registrato & ",iif(o.idcom=0,'Registrato','In coda di Stampa'),"
            ''sql &= "stato=" & enStatoOrdine.StampaInizio & ",'In lavorazione',"
            'sql &= "stato=" & enStatoOrdine.StampaInizio & ",(select top 1 switch(idstato=3,iif(datacronofine is null,'In Stampa','Stampa Finita'),idstato=4,iif(datacronofine is null,'In Finitura su commessa','Finitura su commessa finita'),idstato=5,iif(datacronofine is null,'In Finitura su prodotti','Finitura su prodotti Finita')) from t_commesseCrono where idcom=o.idcom order by datacronoinizio desc),"
            'sql &= "stato=" & enStatoOrdine.Imballaggio & ",'Imballaggio',"
            'sql &= "stato=" & enStatoOrdine.ProntoRitiro & ",'Pronto per la Consegna',"
            'sql &= "stato=" & enStatoOrdine.InConsegna & ",'In Consegna',"
            'sql &= "stato=" & enStatoOrdine.Consegnato & ",'Consegnato',"
            'sql &= "stato=" & enStatoOrdine.PagatoInteramente & ",'Pagato',"
            'sql &= "stato=" & enStatoOrdine.Rifiutato & ",'Rifiutato'"
            'sql &= ") as [Stato],"
            sql &= "'' as Stato,"
            sql &= "(o.TotaleForn + (0 + o.Ricarico) - (0 + o.sconto)) as TotaleImp, stato as StatoOrd,"

            sql &= "(select case Tipoconsegna when " & enTipoConsegna.Normale & " then 'Normale'"
            sql &= " when " & enTipoConsegna.Fast & " then 'Fast24'"
            sql &= " when " & enTipoConsegna.Slow & " then 'Low'"
            sql &= " end ) as [Tipo]"
            sql &= ",p.NumOreMax,o.filepath, o.preventivo "

            If NumSpazi Then
                sql &= ",iif((0 & p.NumSpazi)=0,1,p.NumSpazi) as [Spz]"
                sql &= ",iif((0 & p.NumDuplic)=0,1,p.NumDuplic) as Duplic"
            End If

            sql &= " ,o.idprod, o.idrub , o.iddoc, o.NumeroRealeColli, p.numcolli as NumeroPrevistoColli,  "


            sql &= "C.Descrizione as Corriere,DataPrevConsegna as Prevista, (SELECT Giorno FROM T_CONS S, TR_CONSORD CR WHERE S.IDCONS=CR.IDCONS AND CR.iDORD = o.idord) as Programmata"

            sql &= " from T_Ordini O, T_Prodotti P, T_Rubrica R , T_Corriere C "
            sql &= " where o.idrub = R.idrub and o.idprod = p.idprod and C.IdCorriere = O.IdCorriere"

            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

            If Codice.Length Then
                sql &= " and o.idord=" & Codice
            End If

            If Stato.Length Then
                sql &= " and o.stato in(" & Stato & ")"
            End If

            If ListaIdOrd.Length Then
                sql &= " and o.idord not in(" & ListaIdOrd & ")"
            End If

            If _IdRub Then
                sql &= " and o.idrub =" & _IdRub
            End If

            If OnlyWithoutCom Then
                sql &= " and o.idcom = 0 "
            End If

            If IdCatProd Then
                '                sql &= " and p.idcatprod =" & IdCatProd
                sql &= " and (p.idcatprod = " & IdCatProd & " OR p.idcatprod IN(Select idcatProd from TD_CatProd where idcatpadre = " & IdCatProd & "))"

            End If

            If IdProd Then
                sql &= " and o.idprod =" & IdProd
            End If

            If OnlyLastSixMonth Then
                sql &= " and datediff(m,datains,getdate()) <= 6" ' & Ap(Postazione.AnnoSelezionato)
            End If

            If DataDal <> Date.MinValue Then
                sql &= " and datediff(d,'" & DataDal.ToShortDateString & "',datains)>=0 "
            End If

            If DataAl <> Date.MinValue Then
                sql &= " and datediff(d,datains,'" & DataAl.ToShortDateString & "')>=0 "
            End If

            If IdGruppo Then
                sql &= " and O.IDRUB IN (SELECT IDRUB FROM TR_GrupRubr WHERE IDGRUPPO= " & IdGruppo & ") "
            End If

            If IdCons Then
                sql &= " and O.IDORD IN (SELECT DISTINCT IDORD FROM TR_ConsOrd WHERE IdCons= " & IdCons & ") "
            End If

            If IdIndirizzo <> -1 Then
                sql &= " and o.IdIndirizzo = " & IdIndirizzo
            End If

            If OrderContrario Then
                sql &= " order by idord asc"
            Else
                sql &= " order by idord desc"
            End If
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

    'Public Function checkNumOrd(ByVal IdOrd As Integer) As Integer
    '    Dim Ris As Integer = 0

    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""

    '        sql = "SELECT IdOrd from t_ordini where idord = " & IdOrd
    '        myCommand.CommandText = sql
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

    '        If myReader.HasRows Then Ris = 1
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try

    '    Return Ris
    'End Function



    'Public Function ListaCombo(ByVal IdRub As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Ordini")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""


    '        sql = "SELECT 0 as IdOrd,'-' as Descr from T_Ordini union "


    '        sql &= "(SELECT o.IdOrd, o.datains & ' - ' & p.Descrizione as Descr"
    '        sql &= " from T_Ordini O, T_Prodotti P"
    '        sql &= " where o.idprod = p.idprod "
    '        sql &= " and o.idrub = " & IdRub
    '        sql &= " order by o.datains desc)"
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

    'Public Function ListaOrdiniConsegnaDEPRECATA(ByVal IdCli As Integer, Optional ByVal IdCons As Integer = 0) As DataTable

    '    Dim datatb As DataTable = New DataTable("T_Ordini")

    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT o.IdOrd as Numero, "

    '        sql &= "p.Descrizione as Prodotto,"
    '        sql &= " C.Descrizione as Corriere,DataPrevConsegna as ConsegnaPrevista,c.IdCorriere ,(Select Idcons from tr_consord where idord = o.idord),"
    '        'sql &= "switch(stato=" & enStatoOrdine.Preinserito & ",'Preinserito',"
    '        'sql &= "stato=" & enStatoOrdine.Registrato & ",iif(o.idcom=0,'Registrato','In coda di Stampa'),"
    '        'sql &= "stato=" & enStatoOrdine.StampaInizio & ",'In lavorazione',"
    '        'sql &= "stato=" & enStatoOrdine.StampaInizio & ",(select top 1 switch(idstato=3,iif(datacronofine is null,'In Stampa','Stampa Finita'),idstato=4,iif(datacronofine is null,'In Finitura su commessa','Finitura su commessa finita'),idstato=5,iif(datacronofine is null,'In Finitura su prodotti','Finitura su prodotti Finita')) from t_commesseCrono where idcom=o.idcom order by datacronoinizio desc),"
    '        'sql &= "stato=" & enStatoOrdine.Imballaggio & ",'Imballaggio',"
    '        'sql &= "stato=" & enStatoOrdine.ProntoRitiro & ",'Pronto per la Consegna',"
    '        'sql &= "stato=" & enStatoOrdine.InConsegna & ",'In Consegna',"
    '        'sql &= "stato=" & enStatoOrdine.Consegnato & ",'Consegnato',"
    '        'sql &= "stato=" & enStatoOrdine.PagatoInteramente & ",'Pagato',"
    '        'sql &= "stato=" & enStatoOrdine.Rifiutato & ",'Rifiutato'"
    '        'sql &= ") as [Stato] , o.stato as idstato"
    '        sql &= "'' as [Stato] , o.stato as idstato, o.filepath, o.preventivo,'No' as Preventivo"
    '        sql &= " from T_Ordini O, T_Prodotti P, T_Rubrica R , T_Corriere C "
    '        sql &= " where o.idrub = R.idrub and o.idprod = p.idprod and C.IdCorriere = O.IdCorriere"

    '        sql &= " and r.idrub=" & IdCli


    '        'disabilitato per caricare ordini in tutti gli stati

    '        'sql &= " and o.stato not in(" & enStatoOrdine.InConsegna & "," & _
    '        '    enStatoOrdine.Consegnato & "," & _
    '        '        enStatoOrdine.PagatoAcconto & "," & _
    '        '    enStatoOrdine.PagatoInteramente & "," & _
    '        '    enStatoOrdine.Rifiutato & ")"



    '        sql &= " and idord not in (SELECT IDORD FROM tr_Consord"

    '        If IdCons Then
    '            sql &= " where idcons <> " & IdCons
    '        End If

    '        sql &= ")"

    '        sql &= " order by DataPrevConsegna asc"
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        myCommand.CommandText = sql
    '        'Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        'dA.FillSchema(datatb, SchemaType.Source)
    '        Dim dA As New SqlDataAdapter(myCommand)
    '        dA.Fill(datatb)
    '        ' myReader.Close()
    '        myCommand.Dispose()


    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try

    '    Return datatb

    'End Function


    'Public Function ListaOrdiniByIdConsDEPRECATA(ByVal IdCons As Integer) As DataTable

    '    Dim datatb As DataTable = New DataTable("T_Ordini")

    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT o.IdOrd as Numero,"

    '        sql &= "p.Descrizione as Prodotto ,o.iddoc,o.stato "

    '        sql &= " from T_Ordini O, T_Prodotti P "
    '        sql &= " where o.idprod = p.idprod "
    '        sql &= " and idord  in (SELECT IDORD FROM tr_Consord where idcons = " & IdCons & ")"

    '        sql &= " order by DataPrevConsegna asc"
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
    'Public Function ListaAgendaDEPRECATA(ByVal Giorno As Date, _
    '                            ByVal PeriodoPrevConsegna As Integer, _
    '                            ByVal IdRub As Integer, _
    '                            ByVal IdCom As Integer, _
    '                            ByVal IdCorr As Integer, _
    '                            ByVal ListaStati As String) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Ordini")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT Oraconsegna,o.IdOrd as [Ord],"

    '        sql &= "stato as StatoOrd,"

    '        'sql &= "r.RagSoc & ' - ' & r.Cognome & ' ' &  r.Nome as Cliente,"
    '        sql &= "r.RagSoc as Cliente,"
    '        sql &= "p.Codice as Prodotto,"
    '        'sql &= "switch(stato=" & enStatoOrdine.Preinserito & ",'Preinserito',"
    '        'sql &= "stato=" & enStatoOrdine.Registrato & ",'Registrato',"
    '        'sql &= "stato=" & enStatoOrdine.StampaInizio & ",'In lavorazione',"
    '        'sql &= "stato=" & enStatoOrdine.Imballaggio & ",'Imballaggio',"
    '        'sql &= "stato=" & enStatoOrdine.ProntoRitiro & ",'Pronto Stampa',"
    '        'sql &= "stato=" & enStatoOrdine.InConsegna & ",'In Consegna',"
    '        'sql &= "stato=" & enStatoOrdine.Consegnato & ",'Consegnato',"
    '        'sql &= "stato=" & enStatoOrdine.PagatoInteramente & ",'Pagato',"
    '        'sql &= "stato=" & enStatoOrdine.Rifiutato & ",'Rifiutato'"
    '        'sql &= ") as [Stato],"
    '        sql &= "C.Descrizione as Corriere"

    '        sql &= " from T_Ordini O, T_Prodotti P, T_Rubrica R , T_Corriere C "
    '        sql &= " where o.idrub = R.idrub and o.idprod = p.idprod and C.IdCorriere = O.IdCorriere"

    '        sql &= " and (day(dataprevconsegna) = " & Giorno.Day & " and month(dataprevconsegna) = " & Giorno.Month & " and year(dataprevconsegna) = " & Giorno.Year & ")" ' & ApCancelletto(Giorno.ToShortDateString)
    '        sql &= " and periodoprevconsegna = " & PeriodoPrevConsegna

    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        sql &= " and o.stato <> " & enStatoOrdine.Rifiutato

    '        sql &= " and o.stato in (" & ListaStati & ")"

    '        If IdCorr Then
    '            sql &= " and o.IdCorriere = " & IdCorr
    '        End If



    '        If IdRub Then
    '            sql &= " and o.idrub = " & IdRub
    '        End If

    '        If IdCom Then
    '            sql &= " and o.idcom = " & IdCom
    '        End If


    '        sql &= " order by Oraconsegna asc,ragsoc asc"
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

    'Public Function ListaDaLav(ByVal RegistratoSuCom As Boolean, ByVal InLavorazione As Boolean, ByVal Imballaggio As Boolean, ByVal ProntoStampa As Boolean, ByVal IdCli As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Ordini")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim Sql As String = ""

    '        Sql = "SELECT o.idord as [Numero Ordine],o.idcom as [Commessa],P.Descrizione as Prodotto, RagSoc as Cliente,"
    '        Sql &= "switch(stato=" & enStatoOrdine.Preinserito & ",'Preinserito',"
    '        Sql &= "stato=" & enStatoOrdine.Registrato & ",iif(o.idcom=0,'Registrato','In coda di Stampa'),"
    '        'sql &= "stato=" & enStatoOrdine.StampaInizio & ",'In lavorazione',"
    '        Sql &= "stato=" & enStatoOrdine.StampaInizio & ",(select top 1 switch(idstato=3,iif(datacronofine is null,'In Stampa','Stampa Finita'),idstato=4,iif(datacronofine is null,'In Finitura su commessa','Finitura su commessa finita'),idstato=5,iif(datacronofine is null,'In Finitura su prodotti','Finitura su prodotti Finita')) from t_commesseCrono where idcom=o.idcom order by datacronoinizio desc),"

    '        Sql &= "stato=" & enStatoOrdine.Imballaggio & ",'Imballaggio',"
    '        Sql &= "stato=" & enStatoOrdine.ProntoRitiro & ",'Pronto per la Consegna',"
    '        Sql &= "stato=" & enStatoOrdine.InConsegna & ",'In Consegna',"
    '        Sql &= "stato=" & enStatoOrdine.Consegnato & ",'Consegnato',"
    '        Sql &= "stato=" & enStatoOrdine.PagatoInteramente & ",'Pagato',"
    '        Sql &= "stato=" & enStatoOrdine.Rifiutato & ",'Rifiutato'"
    '        Sql &= ") as [Stato Ordine],"
    '        Sql &= "P.NumColli as [Numero Colli],"
    '        Sql &= "C.Descrizione as [Tipo Spedizione]"
    '        Sql &= "   FROM T_Ordini O,T_Prodotti P, T_Rubrica R , T_Corriere C "
    '        Sql &= " WHERE (O.stato in ("

    '        If InLavorazione Then Sql &= enStatoOrdine.StampaInizio & ","
    '        If Imballaggio Then Sql &= enStatoOrdine.Imballaggio & ","

    '        Sql &= enStatoOrdine.ProntoRitiro & ")"

    '        If RegistratoSuCom Then Sql &= " or (o.stato = " & enStatoOrdine.Registrato & " and o.idcom<>0 )"
    '        Sql &= " ) and o.idprod = p.idprod and r.idrub= o.idrub "

    '        If IdCli Then
    '            Sql &= " and o.idrub = " & IdCli

    '        End If

    '        Sql &= " and o.idcorriere  = c.idcorriere "

    '        myCommand.CommandText = Sql
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

    'Public Function ListaDaLav(ByVal Stato As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Ordini")
    '    Try


    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""

    '        Select Case Stato
    '            Case enStatoOrdine.StampaInizio
    '                'qui carico quelli che devono fare la finitura
    '                sql = "SELECT l.idord as [Numero Ordine],first(o.idcom) as [Commessa],first(C.RagSoc) as Cliente, 'Finitura su Prodotti' as Stato, first(l.Descrizione) as Lavorazione,first(l.ordine) as Ordine "
    '                sql &= "from T_Ordini O, T_CommesseCrono CC , T_LavLog L, T_Rubrica C "
    '                sql &= " Where o.idcom=cc.idcom "
    '                sql &= " and l.idord = o.idord "
    '                sql &= " and c.idrub = o.idrub "
    '                sql &= " and cc.idstato in( " & enStatoCommessa.Stampa & "," & enStatoCommessa.FinituraSuCommessa & ")"
    '                sql &= " and l.dataorafine is null and  not cc.datacronofine is null"
    '                sql &= " and cc.idcom not in (SELECT IDCOM FROM T_LAVLOG WHERE dataorafine is null)"
    '                sql &= "  group by l.idord order by first(l.ordine)"

    '            Case enStatoOrdine.Imballaggio
    '                'qui carico quelli che sono passati a imballaggio
    '                sql = "SELECT o.idord as [Numero Ordine],o.idcom as [Commessa],P.Descrizione as Prodotto,C.RagSoc as Cliente, 'Imballaggio' as Stato,P.NumColli as [Numero Colli]"
    '                sql &= ", Co.Descrizione as [Tipo Spedizione]"
    '                sql &= "   FROM T_Ordini O,T_Prodotti P,T_Rubrica C, T_Corriere Co "
    '                sql &= " WHERE O.stato = " & enStatoOrdine.Imballaggio
    '                sql &= " and o.idprod = p.idprod "
    '                sql &= " and c.idrub = o.idrub "
    '                sql &= " and o.idcorriere = co.idcorriere "
    '                sql &= " order by c.ragsoc,o.idord "

    '            Case enStatoOrdine.ImballaggioCorriere
    '                'qui carico quelli che sono passati a imballaggio
    '                sql = "SELECT o.idord as [Numero Ordine],o.idcom as [Commessa],P.Descrizione as Prodotto,C.RagSoc as Cliente, 'Imballaggio' as Stato,P.NumColli as [Numero Colli]"
    '                sql &= ", Co.Descrizione as [Tipo Spedizione]"
    '                sql &= "   FROM T_Ordini O,T_Prodotti P,T_Rubrica C, T_Corriere Co "
    '                sql &= " WHERE O.stato = " & enStatoOrdine.ImballaggioCorriere
    '                sql &= " and o.idprod = p.idprod "
    '                sql &= " and c.idrub = o.idrub "
    '                sql &= " and o.idcorriere = co.idcorriere "

    '                ' sql &= " order by L.Ordine"
    '            Case enStatoOrdine.ProntoRitiro
    '                'qui carico quelli che sono in consegna
    '                'qui carico quelli che sono passati a imballaggio
    '                sql = "SELECT o.idord as [Numero Ordine],o.idcom as [Commessa],C.RagSoc as Cliente,P.Descrizione as Prodotto, RagSoc as Cliente,'Pronto per la Consegna' as Stato,P.NumColli as [Numero Colli]"
    '                sql &= "   FROM T_Ordini O,T_Prodotti P, T_Rubrica R "
    '                sql &= " WHERE O.stato = " & enStatoOrdine.ProntoRitiro
    '                sql &= " and o.idprod = p.idprod and r.idrub= o.idrub "

    '        End Select
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

    'Public Function ListaOrdDisp(ByVal Tipo As enTipoProdCom, Optional ByVal ListaIdOrdNotShow As String = "") As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Ordini")
    '    Try
    '        'TODO: 15/05/2014 togliere switch su stati ordine
    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT o.IdOrd as Numero, o.datacambiostato as Data,"

    '        sql &= "switch(o.IdCom<>0,o.idcom,"
    '        sql &= "o.idcom=0,' - ') as Commessa,"
    '        sql &= "p.Descrizione as Prodotto,"
    '        sql &= "r.RagSoc & ' - ' & r.Cognome & ' ' &  r.Nome as Cliente,"
    '        sql &= "switch(stato=" & enStatoOrdine.Preinserito & ",'Preinserito'," & FormerLib.FormerEnum.FormerEnumHelper.StatoOrdineString(enStatoOrdine.Preinserito)
    '        sql &= "stato=" & enStatoOrdine.Registrato & ",iif(o.idcom=0,'Registrato','In coda di Stampa'),"
    '        'sql &= "stato=" & enStatoOrdine.StampaInizio & ",'In lavorazione',"
    '        sql &= "stato=" & enStatoOrdine.StampaInizio & ",(select top 1 switch(idstato=3,iif(datacronofine is null,'In Stampa','Stampa Finita'),idstato=4,iif(datacronofine is null,'In Finitura su commessa','Finitura su commessa finita'),idstato=5,iif(datacronofine is null,'In Finitura su prodotti','Finitura su prodotti Finita')) from t_commesseCrono where idcom=o.idcom order by datacronoinizio desc),"

    '        sql &= "stato=" & enStatoOrdine.Imballaggio & ",'Imballaggio',"
    '        sql &= "stato=" & enStatoOrdine.ProntoRitiro & ",'Pronto per la Consegna',"
    '        sql &= "stato=" & enStatoOrdine.InConsegna & ",'In Consegna',"
    '        sql &= "stato=" & enStatoOrdine.Consegnato & ",'Consegnato',"
    '        sql &= "stato=" & enStatoOrdine.PagatoInteramente & ",'Pagato',"
    '        sql &= "stato=" & enStatoOrdine.Rifiutato & ",'Rifiutato'"
    '        sql &= ") as [Stato],"
    '        sql &= "o.prezzo as Prezzo"
    '        sql &= " from T_Ordini O, T_Prodotti P, T_Rubrica R "
    '        sql &= " where o.idrub = R.idrub and o.idprod = p.idprod "

    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

    '        sql &= " and o.stato=" & enStatoOrdine.Registrato

    '        sql &= " and o.idcom =0"

    '        '********** COMMENTATO 7/2/2014 commentato per far comparrire tutti gli ordini e non solo i compatibili inquanto obsoleto
    '        'sql &= " And o.idtipoprod= " & Tipo

    '        If ListaIdOrdNotShow.Length Then
    '            sql &= " And o.idord not in(" & ListaIdOrdNotShow & ")"
    '        End If
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

    'Public Function ListaOrdSel(ByVal IdCom As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Ordini")
    '    Try
    '        'TODO: 15/05/2014 togliere switch su stati ordine
    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT o.IdOrd as Numero, o.datacambiostato as Data,"

    '        sql &= "switch(o.IdCom<>0,o.idcom,"
    '        sql &= "o.idcom=0,' - ') as Commessa,"
    '        sql &= "p.Descrizione as Prodotto,"
    '        sql &= "r.RagSoc & ' - ' & r.Cognome & ' ' &  r.Nome as Cliente,"
    '        sql &= "switch(stato=" & enStatoOrdine.Preinserito & ",'Preinserito',"
    '        sql &= "stato=" & enStatoOrdine.Registrato & ",iif(o.idcom=0,'Registrato','In coda di Stampa'),"
    '        'sql &= "stato=" & enStatoOrdine.StampaInizio & ",'In lavorazione',"
    '        sql &= "stato=" & enStatoOrdine.StampaInizio & ",(select top 1 switch(idstato=3,iif(datacronofine is null,'In Stampa','Stampa Finita'),idstato=4,iif(datacronofine is null,'In Finitura su commessa','Finitura su commessa finita'),idstato=5,iif(datacronofine is null,'In Finitura su prodotti','Finitura su prodotti Finita')) from t_commesseCrono where idcom=o.idcom order by datacronoinizio desc),"

    '        sql &= "stato=" & enStatoOrdine.Imballaggio & ",'Imballaggio',"
    '        sql &= "stato=" & enStatoOrdine.ProntoRitiro & ",'Pronto per la Consegna',"
    '        sql &= "stato=" & enStatoOrdine.InConsegna & ",'In Consegna',"
    '        sql &= "stato=" & enStatoOrdine.Consegnato & ",'Consegnato',"
    '        sql &= "stato=" & enStatoOrdine.PagatoInteramente & ",'Pagato',"
    '        sql &= "stato=" & enStatoOrdine.Rifiutato & ",'Rifiutato'"
    '        sql &= ") as [Stato],"
    '        sql &= "o.prezzo as Prezzo"
    '        sql &= " from T_Ordini O, T_Prodotti P, T_Rubrica R "
    '        sql &= " where o.idrub = R.idrub and o.idprod = p.idprod "

    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

    '        'sql &= " and o.stato=" & enStatoOrdine.Registrato

    '        sql &= " and o.idcom = " & IdCom & " and o.idcom <>0"
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

    'Public Function ListaOrdSelByGest(ByVal ListaIdOrd As String) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Ordini")
    '    Try
    '        'TODO: 15/05/2014 togliere switch su stati ordine
    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT o.IdOrd as Numero, o.datacambiostato as Data,"

    '        sql &= "switch(o.IdCom<>0,o.idcom,"
    '        sql &= "o.idcom=0,' - ') as Commessa,"
    '        sql &= "p.Descrizione as Prodotto,"
    '        sql &= "r.RagSoc & ' - ' & r.Cognome & ' ' &  r.Nome as Cliente,"
    '        sql &= "switch(stato=" & enStatoOrdine.Preinserito & ",'Preinserito',"
    '        sql &= "stato=" & enStatoOrdine.Registrato & ",iif(o.idcom=0,'Registrato','In coda di Stampa'),"
    '        'sql &= "stato=" & enStatoOrdine.StampaInizio & ",'In lavorazione',"
    '        sql &= "stato=" & enStatoOrdine.StampaInizio & ",(select top 1 switch(idstato=3,iif(datacronofine is null,'In Stampa','Stampa Finita'),idstato=4,iif(datacronofine is null,'In Finitura su commessa','Finitura su commessa finita'),idstato=5,iif(datacronofine is null,'In Finitura su prodotti','Finitura su prodotti Finita')) from t_commesseCrono where idcom=o.idcom order by datacronoinizio desc),"

    '        sql &= "stato=" & enStatoOrdine.Imballaggio & ",'Imballaggio',"
    '        sql &= "stato=" & enStatoOrdine.ProntoRitiro & ",'Pronto per la Consegna',"
    '        sql &= "stato=" & enStatoOrdine.InConsegna & ",'In Consegna',"
    '        sql &= "stato=" & enStatoOrdine.Consegnato & ",'Consegnato',"
    '        sql &= "stato=" & enStatoOrdine.PagatoInteramente & ",'Pagato',"
    '        sql &= "stato=" & enStatoOrdine.Rifiutato & ",'Rifiutato'"
    '        sql &= ") as [Stato],"
    '        sql &= "o.prezzo as Prezzo"
    '        sql &= " from T_Ordini O, T_Prodotti P, T_Rubrica R "
    '        sql &= " where o.idrub = R.idrub and o.idprod = p.idprod "

    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

    '        'sql &= " and o.stato=" & enStatoOrdine.Registrato


    '        sql &= " and o.idord in (" & ListaIdOrd & ")"

    '        'sql &= " and o.idcom <>0"
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

    'Public Function AvanzaOrdiniAStatoByCom(ByVal IdCom As Integer, ByVal Stato As enStatoOrdine) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT * from t_ordini where idcom = " & IdCom
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA


    '        myCommand.CommandText = sql
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

    '        While myReader.Read()

    '            Dim mO As New OrdiniDAO
    '            mO.InserisciLog(myReader("Idord"), Stato)

    '        End While

    '        myReader.Close()

    '        myCommand.Dispose()


    '    Catch ex As Exception
    '        OldManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

    'Public Function CambiaCorrierebyIdCons(ByVal IdCons As Integer, ByVal IdCorr As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = OldDbConnection
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        Dim Sql As String = "update T_Ordini set idcorriere = " & IdCorr
    '        Sql &= " Where IdOrd IN(Select idord from tr_consord where idcons=  " & IdCons & ")"
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()
    '        myCommand.Dispose()


    '    Catch ex As Exception
    '        OldManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function



    '<Obsolete("This method is deprecated")> _
    'Public Function AvanzaOrdiniAStatoByIdOrd(ByVal IdOrd As Integer, ByVal Stato As enStatoOrdine, Optional ModificaConsegna As Boolean = True) As Integer
    '    Dim Ris As Integer = 0

    '    Try

    '        'Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
    '        'Dim sql As String = ""
    '        'sql = "SELECT * from t_ordini where idord = " & IdOrd
    '        ''AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA


    '        'myCommand.CommandText = sql
    '        'Dim myReader As SqlDataReader = myCommand.ExecuteReader()

    '        'While myReader.Read()

    '        Using mO As New OrdiniDAO

    '            mO.InserisciLog(IdOrd, Stato, , ModificaConsegna)

    '        End Using
    '        'End While

    '        'myReader.Close()

    '        'myCommand.Dispose()


    '    Catch ex As Exception
    '        OldManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try

    '    Return Ris
    'End Function

    'Public Function Delete(ByVal Id As Integer) As Integer
    '    Dim Ris As Integer = 0
    '    Try

    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = LUNA.LunaContext.Connection
    '        Dim Sql As String = ""

    '        Sql = "DELETE FROM T_OrdiniCrono"
    '        Sql &= " Where IdOrd = " & Id
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()

    '        Sql = "DELETE FROM T_Sorgenti"
    '        Sql &= " Where IdOrd = " & Id
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()

    '        Sql = "DELETE FROM T_Ordini"
    '        Sql &= " Where IdOrd = " & Id
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

Public Class cStatoOrdini
    Inherits CollectionBase

    Public Sub New(Optional ByVal TuttiGliStati As Boolean = True)
        Dim StatoOrd As FormerLib.cEnum

        If TuttiGliStati Then

            StatoOrd = New FormerLib.cEnum
            StatoOrd.Id = 0
            StatoOrd.Descrizione = " - Tutti gli stati - "
            InnerList.Add(StatoOrd)

        End If

        Dim Stati() As FormerLib.FormerEnum.enStatoOrdine = [Enum].GetValues(GetType(enStatoOrdine))

        For Each stato As enStatoOrdine In Stati
            StatoOrd = New FormerLib.cEnum
            StatoOrd.Id = stato
            StatoOrd.Descrizione = FormerEnumHelper.StatoOrdineString(stato)
            InnerList.Add(StatoOrd)
        Next

    End Sub

End Class


