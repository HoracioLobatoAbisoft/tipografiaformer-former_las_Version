#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: DC Consultilng srl
'Date: 01/07/2009
#End Region

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

'Public Class cPagamenti

'#Region "Property"

'    Private _IdPag As Integer
'    Public Property IdPag() As Integer
'        Get
'            Return _IdPag
'        End Get
'        Set(ByVal value As Integer)
'            _IdPag = value
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

'    Private _IdFat As Integer
'    Public Property IdFat() As Integer
'        Get
'            Return _IdFat
'        End Get
'        Set(ByVal value As Integer)
'            _IdFat = value
'        End Set
'    End Property

'    Private _DataPag As DateTime
'    Public Property DataPag() As DateTime
'        Get
'            Return _DataPag
'        End Get
'        Set(ByVal value As DateTime)
'            _DataPag = value
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

'    Private _Importo As Decimal
'    Public Property Importo() As Decimal
'        Get
'            Return _Importo
'        End Get
'        Set(ByVal value As Decimal)
'            _Importo = value
'        End Set
'    End Property

'    Private _NotePag As String = ""
'    Public Property NotePag() As String
'        Get
'            Return _NotePag
'        End Get
'        Set(ByVal value As String)
'            _NotePag = value
'        End Set
'    End Property

'    Private _Tipo As Integer
'    Public Property Tipo() As Integer
'        Get
'            Return _Tipo
'        End Get
'        Set(ByVal value As Integer)
'            _Tipo = value
'        End Set
'    End Property
'#End Region


'#Region "Method"
'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_Pagamenti where IdPag = " & Id
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdPag = myReader("IdPag")
'                If Not myReader("IdRub") Is DBNull.Value Then
'                    _IdRub = myReader("IdRub").toString
'                End If
'                If Not myReader("IdFat") Is DBNull.Value Then
'                    _IdFat = myReader("IdFat").ToString
'                End If
'                If Not myReader("DataPag") Is DBNull.Value Then
'                    _DataPag = myReader("DataPag").toString
'                End If
'                If Not myReader("Descrizione") Is DBNull.Value Then
'                    _Descrizione = myReader("Descrizione").toString
'                End If
'                If Not myReader("Importo") Is DBNull.Value Then
'                    _Importo = myReader("Importo").toString
'                End If
'                If Not myReader("NotePag") Is DBNull.Value Then
'                    _NotePag = myReader("NotePag").toString
'                End If
'                If Not myReader("Tipo") Is DBNull.Value Then
'                    _Tipo = myReader("Tipo").ToString
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
'            If _IdPag = 0 Then
'                sql = "INSERT INTO T_Pagamenti("
'                sql &= "IdRub,"
'                sql &= "IdFat,"
'                sql &= "DataPag,"
'                sql &= "Descrizione,"
'                sql &= "Importo,"
'                sql &= "Tipo,"
'                sql &= "NotePag"
'                sql &= ") VALUES ("
'                sql &= _IdRub & ","
'                sql &= _IdFat & ","
'                sql &= ap(_DataPag) & ","
'                sql &= ap(_Descrizione) & ","
'                sql &= Ap(_Importo) & ","
'                sql &= _Tipo & ","
'                sql &= ap(_NotePag)
'                sql &= ")"
'            Else
'                sql = "UPDATE T_Pagamenti SET "
'                sql &= "IdRub = " & _IdRub & ","
'                sql &= "IdFat = " & _IdFat & ","
'                sql &= "DataPag = " & ap(_DataPag) & ","
'                sql &= "Descrizione = " & ap(_Descrizione) & ","
'                sql &= "Importo = " & Ap(_Importo) & ","
'                sql &= "Tipo = " & _Tipo & ","
'                sql &= "NotePag = " & Ap(_NotePag)
'                sql &= " WHERE IdPag= " & _IdPag
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IdPag = 0 Then
'                Sql = "select @@identity"
'                myCommand.CommandText = Sql
'                Idinserito = myCommand.ExecuteScalar()
'                _IdPag = Idinserito
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


Public Class cPagamentiColl
    Inherits _cOldDao

    Public Function Lista(Optional ByVal IdRub As Integer = 0, Optional ByVal IdDocRif As Integer = 0, Optional ByVal tipoDoc As enTipoVoceContab = enTipoVoceContab.VoceVendita) As DataTable
        Dim datatb As DataTable = New DataTable("T_Pagamenti")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "select * from ("

            If IdDocRif = 0 Or (IdDocRif <> 0 And tipoDoc = 0) Or (IdDocRif <> 0 And tipoDoc = enTipoVoceContab.VoceVendita) Then

                sql &= "SELECT IdPag," 'RagSoc as Cliente,"

                sql &= "(select case c.tipo when  " & enTipoDocumento.Fattura & " then 'Fattura' "
                sql &= "when " & enTipoDocumento.Preventivo & " then 'Preventivo' "
                sql &= "when " & enTipoDocumento.DDT & " then 'DDT'"
                sql &= "end ) as [Relativo a:]"

                'sql &= "switch(c.tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
                'sql &= "c.tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
                'sql &= "c.tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
                'sql &= ") as [Relativo a:]"


                sql &= ",c.Numero,c.Descrizione as [Descrizione Documento],DataPag as [Data Pagamento],p.Descrizione as [Descrizione Pagamento],p.Importo,NotePag as [Note] from T_Pagamenti P,T_Rubrica R, T_ContabRicavi C"
                sql &= " where p.idrub=r.idrub and c.idricavo=p.idfat and c.idrub=p.idrub and p.tipo = " & enTipoVoceContab.VoceVendita
                'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

                If IdRub Then sql &= " and p.idrub =  " & IdRub
                If IdDocRif Then sql &= " and p.idfat =  " & IdDocRif

            End If



            If IdDocRif = 0 Or (IdDocRif <> 0 And tipoDoc = 0) Or (IdDocRif <> 0 And tipoDoc = enTipoVoceContab.VoceAcquisto) Then
                If IdDocRif = 0 Then sql &= " UNION "
                sql &= "SELECT IdPag," ',RagSoc as Cliente,"

                sql &= "(select case c.tipo when  " & enTipoDocumento.Fattura & " then 'Fattura' "
                sql &= "when " & enTipoDocumento.Preventivo & " then 'Preventivo' "
                sql &= "when " & enTipoDocumento.DDT & " then 'DDT'"
                sql &= "end ) as [Relativo a:]"

                'sql &= "switch(c.tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
                'sql &= "c.tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
                'sql &= "c.tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
                'sql &= ") as [Relativo a:]"


                sql &= ",c.Numero,c.Descrizione as [Descrizione Documento],DataPag as [Data Pagamento],p.Descrizione as [Descrizione Pagamento],p.Importo,NotePag as [Note] from T_Pagamenti P,T_Rubrica R, T_ContabCosti C"
                sql &= " where p.idrub=r.idrub and c.idcosto=p.idfat  and c.idrub=p.idrub  and p.tipo = " & enTipoVoceContab.VoceAcquisto
                'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

                If IdRub Then sql &= " and p.idrub =  " & IdRub
                If IdDocRif Then sql &= " and p.idfat =  " & IdDocRif

            End If
            sql &= ") as a "
            sql &= " Order by a.[Data Pagamento] Desc"
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
    '        Dim Sql As String = "DELETE FROM T_Pagamenti"
    '        Sql &= " Where IdPag = " & Id
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


