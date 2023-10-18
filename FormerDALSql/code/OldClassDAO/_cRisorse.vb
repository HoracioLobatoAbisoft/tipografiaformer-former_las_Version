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

'Public Class Risorsa

'    Private _IdRis As Integer
'    Public Property IdRis() As Integer
'        Get
'            Return _IdRis
'        End Get
'        Set(ByVal value As Integer)
'            _IdRis = value
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

'    Private _TipoRis As Integer
'    Public Property TipoRis() As Integer
'        Get
'            Return _TipoRis
'        End Get
'        Set(ByVal value As Integer)
'            _TipoRis = value
'        End Set
'    End Property

'    Private _IsLastra As Integer
'    Public Property IsLastra() As Integer
'        Get
'            Return _IsLastra
'        End Get
'        Set(ByVal value As Integer)
'            _IsLastra = value
'        End Set
'    End Property

'    Private _Nlastre As Integer
'    Public Property Nlastre() As Integer
'        Get
'            Return _Nlastre
'        End Get
'        Set(ByVal value As Integer)
'            _Nlastre = value
'        End Set
'    End Property

'    Private _Lunghezza As Decimal
'    Public Property Lunghezza() As Decimal
'        Get
'            Return _Lunghezza
'        End Get
'        Set(ByVal value As Decimal)
'            _Lunghezza = value
'        End Set
'    End Property

'    Private _Larghezza As Decimal
'    Public Property Larghezza() As Decimal
'        Get
'            Return _Larghezza
'        End Get
'        Set(ByVal value As Decimal)
'            _Larghezza = value
'        End Set
'    End Property

'    Private _CostoTotale As Decimal
'    Public Property CostoTotale() As Decimal
'        Get
'            Return _CostoTotale
'        End Get
'        Set(ByVal value As Decimal)
'            _CostoTotale = value
'        End Set
'    End Property

'    Private _CostoFoglioSteso As Decimal
'    Public Property CostoFoglioSteso() As Decimal
'        Get
'            Return _CostoFoglioSteso
'        End Get
'        Set(ByVal value As Decimal)
'            _CostoFoglioSteso = value
'        End Set
'    End Property

'    Private _CostoFoglioFormato As Decimal
'    Public Property CostoFoglioFormato() As Decimal
'        Get
'            Return _CostoFoglioFormato
'        End Get
'        Set(ByVal value As Decimal)
'            _CostoFoglioFormato = value
'        End Set
'    End Property

'    Private _CostoVenduto As Decimal
'    Public Property CostoVenduto() As Decimal
'        Get
'            Return _CostoVenduto
'        End Get
'        Set(ByVal value As Decimal)
'            _CostoVenduto = value
'        End Set
'    End Property

'    Private _DataAggiornamento As DateTime
'    Public Property DataAggiornamento() As DateTime
'        Get
'            Return _DataAggiornamento
'        End Get
'        Set(ByVal value As DateTime)
'            _DataAggiornamento = value
'        End Set
'    End Property

'    Private _Giacenza As Integer
'    Public Property Giacenza() As Integer
'        Get
'            Return _Giacenza
'        End Get
'        Set(ByVal value As Integer)
'            _Giacenza = value
'        End Set
'    End Property

'    Private _GiacenzaMin As Integer
'    Public Property GiacenzaMin() As Integer
'        Get
'            Return _GiacenzaMin
'        End Get
'        Set(ByVal value As Integer)
'            _GiacenzaMin = value
'        End Set
'    End Property

'    Public Function IsValid() As Boolean
'        Dim Ris As Boolean = True
'        If _Codice.Length = 0 Or _Descrizione.Length = 0 Then
'            Ris = False
'        End If
'        Return Ris
'    End Function

'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_Risorse where IdRis = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdRis = myReader("IdRis")
'                If Not myReader("Codice") Is DBNull.Value Then
'                    _Codice = myReader("Codice").toString
'                End If
'                _Descrizione = myReader("Descrizione")
'                _TipoRis = myReader("TipoRis")
'                _IsLastra = myReader("IsLastra")
'                If Not IsDBNull(myReader("Nlastre")) Then
'                    _Nlastre = myReader("Nlastre").ToString
'                End If
'                If Not IsDBNull(myReader("Lunghezza")) Then
'                    _Lunghezza = myReader("Lunghezza").ToString
'                End If
'                If Not IsDBNull(myReader("Larghezza")) Then
'                    _Larghezza = myReader("Larghezza").ToString
'                End If
'                If Not IsDBNull(myReader("CostoTotale")) Then
'                    _CostoTotale = myReader("CostoTotale").ToString
'                End If
'                If Not IsDBNull(myReader("CostoFoglioSteso")) Then
'                    _CostoFoglioSteso = myReader("CostoFoglioSteso").ToString
'                End If
'                If Not IsDBNull(myReader("CostoFoglioFormato")) Then
'                    _CostoFoglioFormato = myReader("CostoFoglioFormato").ToString
'                End If
'                If Not IsDBNull(myReader("CostoVenduto")) Then
'                    _CostoVenduto = myReader("CostoVenduto").ToString
'                End If
'                If Not IsDBNull(myReader("DataAggiornamento")) Then
'                    _DataAggiornamento = myReader("DataAggiornamento").ToString
'                End If
'                _Giacenza = myReader("Giacenza")
'                _GiacenzaMin = myReader("GiacenzaMin")
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
'            If _IdRis = 0 Then
'                sql = "INSERT INTO T_Risorse("
'                sql &= "Codice,"
'                sql &= "Descrizione,"
'                sql &= "TipoRis,"
'                sql &= "IsLastra,"
'                sql &= "Nlastre,"
'                sql &= "Lunghezza,"
'                sql &= "Larghezza,"
'                sql &= "CostoTotale,"
'                sql &= "CostoFoglioSteso,"
'                sql &= "CostoFoglioFormato,"
'                sql &= "CostoVenduto,"
'                sql &= "DataAggiornamento,"
'                'sql &= "Giacenza,"
'                sql &= "GiacenzaMin"
'                sql &= ") VALUES ("
'                sql &= Ap(_Codice) & ","
'                sql &= Ap(_Descrizione) & ","
'                sql &= _TipoRis & ","
'                sql &= _IsLastra & ","
'                sql &= _Nlastre & ","
'                sql &= Ap(_Lunghezza) & ","
'                sql &= Ap(_Larghezza) & ","
'                sql &= Ap(_CostoTotale) & ","
'                sql &= Ap(_CostoFoglioSteso) & ","
'                sql &= Ap(_CostoFoglioFormato) & ","
'                sql &= Ap(_CostoVenduto) & ","
'                sql &= Ap(_DataAggiornamento) & ","
'                'sql &= _Giacenza & ","
'                sql &= _GiacenzaMin
'                sql &= ")"
'            Else
'                sql = "UPDATE T_Risorse SET "
'                sql &= "Codice = " & Ap(_Codice) & ","
'                sql &= "Descrizione = " & Ap(_Descrizione) & ","
'                sql &= "TipoRis = " & _TipoRis & ","
'                sql &= "IsLastra = " & _IsLastra & ","
'                sql &= "Nlastre = " & _Nlastre & ","
'                sql &= "Lunghezza = " & Ap(_Lunghezza) & ","
'                sql &= "Larghezza = " & Ap(_Larghezza) & ","
'                sql &= "CostoTotale = " & Ap(_CostoTotale) & ","
'                sql &= "CostoFoglioSteso = " & Ap(_CostoFoglioSteso) & ","
'                sql &= "CostoFoglioFormato = " & Ap(_CostoFoglioFormato) & ","
'                sql &= "CostoVenduto = " & Ap(_CostoVenduto) & ","
'                sql &= "DataAggiornamento = " & Ap(_DataAggiornamento) & ","
'                'sql &= "Giacenza = " & _Giacenza & ","
'                sql &= "GiacenzaMin = " & _GiacenzaMin
'                sql &= " WHERE IdRis= " & _IdRis
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If IdInserito = 0 Then
'                sql = "select @@identity"
'                myCommand.CommandText = sql
'                IdInserito = myCommand.ExecuteScalar()
'                If IdRis = 0 Then IdRis = IdInserito
'            End If


'            myCommand.Dispose()

'        Catch ex As Exception
'            ManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'End Class

Public Class cRisorseColl
    Inherits _cOldDao

    Public Function ListaRisorseCom(ByVal IdCom As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_Risorse")
        Try

            Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
                Dim sql As String = ""

                sql = "SELECT R.IdRis,QTA,Descrizione FROM T_Risorse R INNER JOIN T_MAGAZ M ON r.idris= m.idris "

                sql &= " WHERE m.idcom = " & IdCom

                sql &= " AND IsLastra = " & enSiNo.No

                sql &= " ORDER BY qta"
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.CommandText = sql
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                datatb.Load(myReader)
                myReader.Close()
            End Using

        Catch ex As Exception
            OldManageError(ex)
        End Try

        Return datatb

    End Function

    Public Function StoricoPrezzi(ByVal IdRis As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_Risorse")
        Try

            Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
                Dim sql As String = ""

                sql = "SELECT distinct m.DataMov,CodiceForn, DescrForn, m.QTA,m.PrezzoUnit,R.RagSoc as Fornitore from T_MAGAZ M,T_ContabCosti C, T_Rubrica R "

                sql &= " where m.idris = " & IdRis

                sql &= " and m.tipomov = " & enTipoMovMagaz.Carico

                sql &= " and m.idfat = c.idcosto and c.idrub=r.idrub "

                sql &= " order by m.Datamov desc"
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.CommandText = sql
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                datatb.Load(myReader)
                myReader.Close()
            End Using

        Catch ex As Exception
            OldManageError(ex)
        End Try
        Return datatb

    End Function

    Public Function Cerca(ByVal Ricerca As String,
                          Optional ByVal IdForn As Integer = 0) As DataTable
        Dim datatb As DataTable = New DataTable("T_Risorse")
        Try

            Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
                Dim sql As String = ""

                If IdForn Then

                    sql = "SELECT distinct m.IdRis,m.CodiceForn as CodiceFornitore,m.DescrForn as DescrizioneFornitore, m.idForn, r.ragsoc as Fornitore from T_Magaz M "
                    sql &= " inner join t_rubrica r On m.idforn = r.idrub "
                    sql &= " where (CodiceForn " & ApLike(Ricerca)
                    sql &= " Or descrForn " & ApLike(Ricerca) & ") "
                    sql &= " And idforn= " & IdForn

                    If Ricerca.Length = 0 Then
                        sql &= " And Idfat In (Select idcosto from t_contabcosti where idrub= " & IdForn & ")"
                    End If

                    sql &= " ORDER by CodiceForn"

                Else

                    sql = "Select IdRis,Codice + ' - ' + Descrizione as Descr from T_Risorse "
                    sql &= " where (Codice " & ApLike(Ricerca)
                    sql &= " or descrizione " & ApLike(Ricerca) & ")"
                    sql &= " order by Codice"

                End If

                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.CommandText = sql
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                datatb.Load(myReader)
                myReader.Close()
            End Using

        Catch ex As Exception
            OldManageError(ex)
        End Try
        Return datatb

    End Function

    'Public Function ListaCom(ByVal IdCom As Integer, ByVal TipoRis As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Risorse")
    '    Try

    '        Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '            Dim sql As String = ""
    '            sql = "Select IdRis,Descrizione, Giacenza "

    '            sql &= "from T_Risorse "

    '            sql &= " where tiporis = " & TipoRis

    '            sql &= " And IsLastra = " & enSiNo.No

    '            sql &= " And Stato = " & enStato.Attivo

    '            'TODO: RIATTIVARE QUANDO PRENDEREMO IN CONSIDERAZIONE LA GIACENZA
    '            'sql &= " And Giacenza <>0"

    '            sql &= " And IDRIS Not In (Select IDRIS FROM T_MAGAZ WHERE IDCOM = " & IdCom & " And idcom<>0 And idfat=0)"

    '            sql &= " ORDER BY Descrizione"
    '            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '            myCommand.CommandText = sql
    '            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '            datatb.Load(myReader)
    '            myReader.Close()
    '        End Using

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    Public Function ListaComSel(ByVal IdCom As Integer,
                                ByVal TipoCom As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_Risorse")
        Try

            Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
                Dim sql As String = ""
                sql = "Select r.IdRis,Descrizione, Giacenza,Qta As Utilizzata, IdTipoCarta "

                sql &= "from T_Risorse R, T_Magaz M  "

                sql &= " where tiporis = " & TipoCom

                sql &= " And r.idris =m.idris And m.idcom=  " & IdCom & " And idfat=0 "

                sql &= " And IsLastra = " & enSiNo.No

                'sql &= " And Stato = " & enStato.Attivo

                sql &= " And r.IDRIS In (Select IDRIS FROM T_MAGAZ WHERE IDCOM = " & IdCom & " And idcom<>0  And idfat=0)"

                sql &= " ORDER BY Codice,Descrizione"
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.CommandText = sql
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                datatb.Load(myReader)
                'myReader.Close()
            End Using

        Catch ex As Exception
            OldManageError(ex)
        End Try
        Return datatb
    End Function

    'Public Function ListaComboOffSet(Optional ByVal Lastra As Boolean = False) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Risorse")
    '    Try

    '        Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '            Dim sql As String = ""
    '            sql = "Select IdRis, Codice + ' - ' + Descrizione "

    '            If Lastra Then
    '                sql &= " + ' (' + cast(nlastre as varchar) + ')' "
    '            End If

    '            sql &= " as Descrizione "

    '            sql &= "from T_Risorse "

    '            sql &= " where tiporis = " & enTipoProdCom.StampaOffSet

    '            sql &= " and IsLastra = " & IIf(Lastra, enSiNo.Si, enSiNo.No)

    '            sql &= " ORDER BY Codice,Descrizione"
    '            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '            myCommand.CommandText = sql
    '            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '            datatb.Load(myReader)
    '            myReader.Close()
    '        End Using

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    'Public Function ListaCombo(ByVal TipoCom As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Risorse")
    '    Try

    '        Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '            Dim sql As String = ""
    '            sql = "SELECT IdRis, Codice + ' - ' + Descrizione "

    '            sql &= " as Descrizione "

    '            sql &= "from T_Risorse "

    '            sql &= " where tiporis = " & TipoCom

    '            sql &= " and IsLastra = " & enSiNo.No

    '            sql &= " ORDER BY Codice,Descrizione"
    '            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '            myCommand.CommandText = sql
    '            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '            datatb.Load(myReader)
    '            myReader.Close()
    '        End Using

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    'Public Function ListaCombo() As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Risorse")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT IdRis, Codice + ' - ' + Descrizione "

    '        sql &= " as Descrizione "

    '        sql &= "from T_Risorse "

    '        sql &= " ORDER BY tiporis,Codice"

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

    'Public Function Lista(ByVal Cerca As String, Optional ByVal SottoScorta As Boolean = False, Optional ByVal IdRub As Integer = 0) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Risorse")
    '    Try

    '        Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '            Dim sql As String = ""

    '            If IdRub Then
    '                sql = "SELECT IdListinoForn,DataAcc,Codice,Prezzo FROM T_LISTINOFORN where idrub = " & IdRub & " order by dataAcc desc"
    '            Else
    '                sql = "SELECT IdRis, Codice, Descrizione, Giacenza, GiacenzaMin as [Giacenza Minima], iif(IsLastra= " & enSiNo.Si & ",'Lastra','Carta') as [Tipo Risorsa] ,"

    '                'sql &= "switch(Tiporis=" & enTipoProdCom.OffSet & ",'Offset',Tiporis=" & enTipoProdCom.Digitale & ",'Digitale',Tiporis=" & enTipoProdCom.Consumo & ",'Prodotto di consumo') as [Prodotto di Riferimento]"
    '                sql &= "(select case Tiporis when " & enTipoProdCom.StampaOffSet & " then 'Offset' when " & enTipoProdCom.StampaDigitale & " then 'Digitale' when " &
    '                    enTipoProdCom.Consumo & " then 'Prodotto di consumo' end ) as [Prodotto di Riferimento]"
    '                sql &= "from T_Risorse "

    '                If Cerca.Length Then
    '                    sql &= " WHERE Descrizione " & ApLike(Cerca)
    '                End If


    '                If SottoScorta Then
    '                    If sql.IndexOf("WHERE") = -1 Then sql &= " WHERE " Else sql &= " AND "
    '                    sql &= " Giacenza<=GiacenzaMin "
    '                    sql &= " ORDER BY Giacenza desc,Codice,Descrizione"
    '                Else
    '                    sql &= " ORDER BY Codice,Descrizione"
    '                End If
    '            End If



    '            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '            myCommand.CommandText = sql
    '            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '            datatb.Load(myReader)
    '            myReader.Close()
    '        End Using

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return datatb
    'End Function

    'Public Function Elenco(ByVal TipoRisorse As enTipoProdCom) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_Risorse")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT IdRis, Descrizione,CostoFoglioSteso from T_Risorse"
    '        sql &= " where Tiporis = " & TipoRisorse
    '        sql &= " and Islastra = 0 "
    '        sql &= " order by Descrizione"
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
    '        Dim Sql As String = "DELETE FROM T_Risorse"
    '        Sql &= " Where IdRis = " & Id
    '        myCommand.CommandText = Sql
    '        myCommand.ExecuteNonQuery()
    '        myCommand.Dispose()
    '    Catch ex As Exception
    '        ManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

    Public Function Exists(ByVal Codice As String, ByVal IdRif As Integer) As Boolean
        Dim Ris As Boolean = False

        If Codice.Trim.Length Then

            Try

                Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
                    Dim sql As String = ""
                    sql = "SELECT IdRis from t_risorse "
                    sql &= " WHERE "
                    sql &= " Codice = " & Ap(Codice)
                    sql &= " AND IdRis <> " & IdRif
                    If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                    myCommand.CommandText = sql
                    Using myReader As SqlDataReader = myCommand.ExecuteReader()

                        myReader.Read()

                        Ris = myReader.HasRows

                        myReader.Close()
                    End Using
                End Using

            Catch ex As Exception
                OldManageError(ex)
            End Try

        End If

        Return Ris

    End Function

End Class
