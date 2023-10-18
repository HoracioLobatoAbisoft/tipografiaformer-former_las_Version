#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: DC Consultilng srl
'Date: 29/07/2008
#End Region

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

'Public Class Prodotto

'    Private _IdProd As Integer
'    Public Property IdProd() As Integer
'        Get
'            Return _IdProd
'        End Get
'        Set(ByVal value As Integer)
'            _IdProd = value
'        End Set
'    End Property

'    Private _TipoProd As Integer
'    Public Property TipoProd() As Integer
'        Get
'            Return _TipoProd
'        End Get
'        Set(ByVal value As Integer)
'            _TipoProd = value
'        End Set
'    End Property

'    Private _IdCatProd As Integer
'    Public Property IdCatProd() As Integer
'        Get
'            Return _IdCatProd
'        End Get
'        Set(ByVal value As Integer)
'            _IdCatProd = value
'        End Set
'    End Property

'    Private _Codice As String
'    Public Property Codice() As String
'        Get
'            Return _Codice
'        End Get
'        Set(ByVal value As String)
'            _Codice = value
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

'    Private _DescrizioneEstesa As String
'    Public Property DescrizioneEstesa() As String
'        Get
'            Return _DescrizioneEstesa
'        End Get
'        Set(ByVal value As String)
'            _DescrizioneEstesa = value
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

'    Private _Plastifica As Boolean
'    Public Property Plastifica() As Boolean
'        Get
'            Return _Plastifica
'        End Get
'        Set(ByVal value As Boolean)
'            _Plastifica = value
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

'    Private _PrezzoPubbl As Decimal
'    Public Property PrezzoPubbl() As Decimal
'        Get
'            Return _PrezzoPubbl
'        End Get
'        Set(ByVal value As Decimal)
'            _PrezzoPubbl = value
'        End Set
'    End Property

'    Public ReadOnly Property PrezzoFast() As Decimal
'        Get
'            If _PercFast Then
'                Dim PrezzoRif As Decimal = (_Prezzo * _PercFast / 100) + _Prezzo
'                Return PrezzoRif

'            Else
'                Return _Prezzo
'            End If
'        End Get
'    End Property

'    Public ReadOnly Property PrezzoLow() As Decimal
'        Get
'            If _PercLow Then
'                Dim PrezzoRif As Decimal = _Prezzo - (_Prezzo * _PercFast / 100)
'                Return PrezzoRif

'            Else
'                Return _Prezzo
'            End If
'        End Get
'    End Property


'    Private _Scarto As Single
'    Public Property Scarto() As Single
'        Get
'            Return _Scarto
'        End Get
'        Set(ByVal value As Single)
'            _Scarto = value
'        End Set
'    End Property

'    Private _NumColli As Integer
'    Public Property NumColli() As Integer
'        Get
'            Return _NumColli
'        End Get
'        Set(ByVal value As Integer)
'            _NumColli = value
'        End Set
'    End Property

'    Private _NumPezzi As Integer
'    Public Property NumPezzi() As Integer
'        Get
'            Return _NumPezzi
'        End Get
'        Set(ByVal value As Integer)
'            _NumPezzi = value
'        End Set
'    End Property

'    Private _PesoComplessivo As Integer
'    Public Property PesoComplessivo() As Integer
'        Get
'            Return _PesoComplessivo
'        End Get
'        Set(ByVal value As Integer)
'            _PesoComplessivo = value
'        End Set
'    End Property

'    Private _NumOreMax As Integer
'    Public Property NumOreMax() As Integer
'        Get
'            Return _NumOreMax
'        End Get
'        Set(ByVal value As Integer)
'            _NumOreMax = value
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

'    Private _NumDuplic As Integer = 1
'    Public Property NumDuplic() As Integer
'        Get
'            Return _NumDuplic
'        End Get
'        Set(ByVal value As Integer)
'            _NumDuplic = value
'        End Set
'    End Property
'    Private _ggNormale As Integer = 0
'    Public Property ggNormale() As Integer
'        Get
'            Return _ggNormale
'        End Get
'        Set(ByVal value As Integer)
'            _ggNormale = value
'        End Set
'    End Property

'    Private _ggFast As Integer = 0
'    Public Property ggFast() As Integer
'        Get
'            Return _ggFast
'        End Get
'        Set(ByVal value As Integer)
'            _ggFast = value
'        End Set
'    End Property

'    Private _ggLow As Integer = 0
'    Public Property ggLow() As Integer
'        Get
'            Return _ggLow
'        End Get
'        Set(ByVal value As Integer)
'            _ggLow = value
'        End Set
'    End Property

'    Private _PercNormale As Integer = 0
'    Public Property PercNormale() As Integer
'        Get
'            Return _PercNormale
'        End Get
'        Set(ByVal value As Integer)
'            _PercNormale = value
'        End Set
'    End Property

'    Private _PercFast As Integer = 0
'    Public Property PercFast() As Integer
'        Get
'            Return _PercFast
'        End Get
'        Set(ByVal value As Integer)
'            _PercFast = value
'        End Set
'    End Property

'    Private _PercLow As Integer = 0
'    Public Property PercLow() As Integer
'        Get
'            Return _PercLow
'        End Get
'        Set(ByVal value As Integer)
'            _PercLow = value
'        End Set
'    End Property

'    Private _Status As Integer = 0
'    Public Property Status() As Integer
'        Get
'            Return _Status
'        End Get
'        Set(ByVal value As Integer)
'            _Status = value
'        End Set
'    End Property

'    Public Function IsValid() As Boolean
'        Dim Ris As Boolean = True

'        If _Codice.Trim.Length = 0 Then
'            Ris = False
'        End If

'        If _Descrizione.Trim.Length = 0 Then
'            Ris = False
'        End If

'        If _IdCatProd = 0 Then
'            Ris = False
'        End If

'        If _ggNormale = 0 Then
'            Ris = False
'        End If

'        Return Ris
'    End Function

'    Public Function Read(Optional ByVal Id As Integer = 0, Optional ByVal CodiceProd As String = "", Optional ByVal IdRub As Integer = 0) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand(), sql As String = ""

'            sql = "SELECT * FROM T_Prodotti where "

'            If Id Then
'                sql &= " IdProd = " & Id
'            ElseIf CodiceProd.Length Then
'                sql &= " Codice = " & Ap(CodiceProd)
'            End If

'            myCommand.CommandText = sql

'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdProd = myReader("IdProd")
'                _TipoProd = myReader("TipoProd")
'                _Codice = myReader("Codice")
'                _Descrizione = myReader("Descrizione")
'                _DescrizioneEstesa = myReader("DescrizioneEstesa").ToString
'                _FronteRetro = myReader("FronteRetro").ToString
'                '_Plastifica = myReader("Plastifica").ToString
'                _Scarto = IIf(IsDBNull(myReader("Scarto")), 0, myReader("Scarto"))
'                _NumPezzi = IIf(IsDBNull(myReader("NumPezzi")), 0, myReader("NumPezzi"))
'                _PesoComplessivo = IIf(IsDBNull(myReader("PesoComplessivo")), 0, myReader("PesoComplessivo"))
'                _NumOreMax = IIf(IsDBNull(myReader("NumOreMax")), 0, myReader("NumOreMax"))
'                _NumColli = IIf(IsDBNull(myReader("NumColli")), 0, myReader("NumColli"))
'                _Prezzo = myReader("Prezzo")
'                _IdCatProd = IIf(IsDBNull(myReader("IdCatProd")), 0, myReader("IdCatProd"))
'                _NumSpazi = IIf(IsDBNull(myReader("NumSpazi")), 1, myReader("NumSpazi"))
'                _NumDuplic = IIf(IsDBNull(myReader("NumDuplic")), 1, myReader("NumDuplic"))
'                If Not myReader("ggNormale") Is DBNull.Value Then
'                    _ggNormale = myReader("ggNormale").ToString
'                End If
'                If Not myReader("ggFast") Is DBNull.Value Then
'                    _ggFast = myReader("ggFast").ToString
'                End If
'                If Not myReader("ggLow") Is DBNull.Value Then
'                    _ggLow = myReader("ggLow").ToString
'                End If
'                If Not myReader("PercNormale") Is DBNull.Value Then
'                    _PercNormale = myReader("PercNormale").ToString
'                End If
'                If Not myReader("PercFast") Is DBNull.Value Then
'                    _PercFast = myReader("PercFast").ToString
'                End If
'                If Not myReader("PercLow") Is DBNull.Value Then
'                    _PercLow = myReader("PercLow").ToString
'                End If
'                If Not myReader("status") Is DBNull.Value Then
'                    _Status = myReader("status").ToString
'                End If
'                If Not myReader("prezzoPubbl") Is DBNull.Value Then
'                    _PrezzoPubbl = myReader("prezzoPubbl").ToString
'                End If
'            Else
'                Ris = 1
'            End If

'            'qui se mi e' stato passato l'idrub carico il prezzo riservato se esiste

'            If IdRub Then
'                Dim ListPer As New cListinoCliColl, PrezzoRiservato As Decimal
'                PrezzoRiservato = ListPer.CercaPrezzo(IdRub, _IdProd)
'                If PrezzoRiservato Then _Prezzo = PrezzoRiservato

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
'            If _IdProd = 0 Then
'                sql = "INSERT INTO T_Prodotti("
'                sql &= "TipoProd,"
'                sql &= "Codice,"
'                sql &= "Descrizione,"
'                sql &= "DescrizioneEstesa,"
'                sql &= "FronteRetro,"
'                sql &= "Scarto,"
'                sql &= "NumPezzi,"
'                sql &= "PesoComplessivo,"
'                sql &= "NumColli,"
'                sql &= "NumOreMax,"
'                sql &= "IdCatProd,"
'                sql &= "NumSpazi,"
'                sql &= "NumDuplic,"
'                sql &= "ggNormale,"
'                sql &= "ggFast,"
'                sql &= "ggLow,"
'                sql &= "PercNormale,"
'                sql &= "PercFast,"
'                sql &= "PercLow,"
'                sql &= "status,"
'                sql &= "PrezzoPubbl,"
'                sql &= "Prezzo"
'                sql &= ") VALUES ("
'                sql &= _TipoProd & ","
'                sql &= Ap(_Codice) & ","
'                sql &= Ap(_Descrizione) & ","
'                sql &= Ap(_DescrizioneEstesa) & ","
'                sql &= IIf(_FronteRetro, -1, 0) & ","
'                sql &= Ap(_Scarto) & ","
'                sql &= _NumPezzi & ","
'                sql &= _PesoComplessivo & ","
'                sql &= _NumColli & ","
'                sql &= _NumOreMax & ","
'                sql &= _IdCatProd & ","
'                sql &= _NumSpazi & ","
'                sql &= _NumDuplic & ","
'                sql &= _ggNormale & ","
'                sql &= _ggFast & ","
'                sql &= _ggLow & ","
'                sql &= _PercNormale & ","
'                sql &= _PercFast & ","
'                sql &= _PercLow & ","
'                sql &= _Status & ","
'                sql &= Ap(_PrezzoPubbl) & ","
'                sql &= Ap(_Prezzo)
'                sql &= ")"
'            Else
'                sql = "UPDATE T_Prodotti SET "
'                sql &= "TipoProd = " & _TipoProd & ","
'                sql &= "Codice = " & Ap(_Codice) & ","
'                sql &= "Descrizione = " & Ap(_Descrizione) & ","
'                sql &= "DescrizioneEstesa = " & Ap(_DescrizioneEstesa) & ","
'                sql &= "FronteRetro = " & IIf(_FronteRetro, -1, 0) & ","
'                sql &= "Scarto = " & Ap(_Scarto) & ","
'                sql &= "NumPezzi = " & _NumPezzi & ","
'                sql &= "PesoComplessivo= " & _PesoComplessivo & ","
'                sql &= "NumColli = " & _NumColli & ","
'                sql &= "NumOreMax = " & _NumOreMax & ","
'                sql &= "IdCatProd = " & _IdCatProd & ","
'                sql &= "NumSpazi = " & _NumSpazi & ","
'                sql &= "NumDuplic = " & _NumDuplic & ","
'                sql &= "ggNormale = " & _ggNormale & ","
'                sql &= "ggFast = " & _ggFast & ","
'                sql &= "ggLow = " & _ggLow & ","
'                sql &= "PercNormale = " & _PercNormale & ","
'                sql &= "PercFast = " & _PercFast & ","
'                sql &= "PercLow = " & _PercLow & ","
'                sql &= "status = " & _Status & ","
'                sql &= "PrezzoPubbl = " & Ap(_PrezzoPubbl) & ","
'                sql &= "Prezzo = " & Ap(_Prezzo)
'                sql &= " WHERE IdProd= " & _IdProd
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IdProd = 0 Then
'                sql = "select @@identity"
'                myCommand.CommandText = sql
'                IdInserito = myCommand.ExecuteScalar()
'                _IdProd = IdInserito
'            End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function


'    Public Function SalvaLavorazioni(ByVal ListaIdSelezionati As Integer()) As Integer

'        Dim Ris As Integer = 0
'        Try

'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = LUNA.LunaContext.Connection
'            Dim Sql As String = "DELETE FROM TR_Lavori where idprod = " & _IdProd

'            myCommand.CommandText = Sql
'            myCommand.ExecuteNonQuery()

'            Dim I As Integer = 0

'            For I = 0 To ListaIdSelezionati.GetUpperBound(0)

'                Sql = "INSERT INTO TR_LAVORI (IdLav,IdProd,Ordine) VALUES(" & ListaIdSelezionati(I) & "," & _IdProd & "," & I & ")"

'                myCommand.CommandText = Sql
'                myCommand.ExecuteNonQuery()


'            Next

'            myCommand.Dispose()
'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try

'        Return Ris

'    End Function

'End Class

Public Class cProdottiColl
    Inherits _cOldDao

    Public Function Lista(ByVal Cerca As String, ByVal IdCatProd As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_Prodotti")
        Try

            Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT IdProd, Codice, Descrizione, Prezzo,iif(TipoProd= " & enTipoProdCom.StampaOffSet & ",'OffSet','Digitale') as [Tipo Prodotto],NumSpazi as Spazi, NumDuplic As Duplicati,ggnormale as [GG Normale],ggfast as [GG Fast], gglow as [GG Low], percfast as [% Fast], perclow as [% Low]  from T_Prodotti "

                sql &= " where status <> 1 "

                If Cerca.Length Then
                    sql &= " and (Codice " & ApLike(Cerca) & " Or Descrizione " & ApLike(Cerca) & ")"
                End If

                If IdCatProd Then
                    sql &= " and idcatprod =" & IdCatProd
                End If

                sql &= " ORDER BY Codice"
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.CommandText = sql
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    datatb.Load(myReader)
                End Using
            End Using

        Catch ex As Exception
            OldManageError(ex)
        End Try
        Return datatb
    End Function

    Public Function LeggiPrezzo(ByVal IdProd As Integer, ByVal IdRub As Integer) As Single

        Try
            Dim Ris As Single = 0
            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""

            sql = "SELECT PREZZORis from T_ListinoCli where idprod = " & IdProd & " and idrub= " & IdRub
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            If myReader.HasRows Then

                'controllo se ha un prezzo particolare per quel prodotto
                myReader.Read()
                Ris = myReader("PrezzoRis")

            Else
                'qui a seconda del tipo di rubrica leggo prezzo normale o prezzo al pubbl
                myReader.Close()
                Dim NomeCampo As String = ""
                Dim R As New VoceRubrica
                R.Read(IdRub)
                If R.Tipo = enTipoRubrica.Cliente Then
                    NomeCampo = "PrezzoPubbl"
                Else
                    NomeCampo = "Prezzo"
                End If

                sql = "SELECT " & NomeCampo & " from T_Prodotti where idprod = " & IdProd
                myCommand.CommandText = sql
                myReader = myCommand.ExecuteReader

                myReader.Read()
                If Not IsDBNull(myReader(NomeCampo)) Then
                    Ris = myReader(NomeCampo)
                End If


            End If

            myReader.Close()
            myCommand.Dispose()

            Return Ris
        Catch ex As Exception
            OldManageError(ex)
        End Try

    End Function

    Public Function ListaPerCombo(ByVal TipoProd As Integer, Optional ByVal Tutti As Boolean = True, Optional ByVal NuovoOrdine As Boolean = False) As DataTable
        Dim datatb As DataTable = New DataTable("T_Prodotti")

        'se mi viene passato 0 aggiungo tutti e carico tutto

        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""

            If TipoProd = 0 And Tutti = True Then
                sql = " SELECT 0 as IdProd, '- Tutti ' as Descr from t_Prodotti union "
            End If
            sql &= " SELECT "
            sql &= "IdProd, iif(status = 1 ,'#DELETED# - ','') + Codice + ' - '  + Descrizione as [Descr]  from T_Prodotti"
            sql &= " WHERE 1=1 "
            If TipoProd <> 0 Then sql &= "  and tipoprod = " & TipoProd
            If NuovoOrdine Then sql &= "  and status <> 1 and idlistinobase <> 0 "
            sql &= " ORDER BY "
            If TipoProd <> 0 Then
                sql &= "tipoprod, Descrizione"
            Else
                sql &= "Descr"
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

End Class



