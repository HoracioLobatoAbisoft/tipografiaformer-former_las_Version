'Imports FormerLib.FormerEnum
'#Region "Author"
''Classe creata con DCFramework
''All rights reserved.
''Author: DC Consultilng srl
''Date: 13/10/2008
'#End Region


'Imports System
'Imports System.Data
'Imports System.Data.SqlClient

''Public Class cCommesse

''#Region "Property"

''    Private _IdCom As Integer
''    Public Property IdCom() As Integer
''        Get
''            Return _IdCom
''        End Get
''        Set(ByVal value As Integer)
''            _IdCom = value
''        End Set
''    End Property
''    Private _MovMagaz As Collection
''    Public Property MovMagaz() As Collection
''        Get
''            Return _MovMagaz
''        End Get
''        Set(ByVal value As Collection)
''            _MovMagaz = value
''        End Set
''    End Property

''    Private _IdTipoCom As Integer
''    Public Property IdTipoCom() As Integer
''        Get
''            Return _IdTipoCom
''        End Get
''        Set(ByVal value As Integer)
''            _IdTipoCom = value
''        End Set
''    End Property

''    Private _IdRis As Integer
''    Public Property IdRis() As Integer
''        Get
''            Return _IdRis
''        End Get
''        Set(ByVal value As Integer)
''            _IdRis = value
''        End Set
''    End Property

''    Private _IdLavorazione As Integer
''    Public Property IdLavorazione() As Integer
''        Get
''            Return _IdLavorazione
''        End Get
''        Set(ByVal value As Integer)
''            _IdLavorazione = value
''        End Set
''    End Property

''    Private _TipoCom As Integer
''    Public Property TipoCom() As Integer
''        Get
''            Return _TipoCom
''        End Get
''        Set(ByVal value As Integer)
''            _TipoCom = value
''        End Set
''    End Property

''    Private _DataCambioStato As Date = Date.Now
''    Public Property DataCambioStato() As Date
''        Get
''            Return _DataCambioStato
''        End Get
''        Set(ByVal value As Date)
''            _DataCambioStato = value
''        End Set
''    End Property

''    Private _DataIns As Date = Now
''    Public Property DataIns() As Date
''        Get
''            Return _DataIns
''        End Get
''        Set(ByVal value As Date)
''            _DataIns = value
''        End Set
''    End Property


''    Private _Stato As Integer = enStatoCommessa.Preinserito
''    Public Property Stato() As Integer
''        Get
''            Return _Stato
''        End Get
''        Set(ByVal value As Integer)
''            _Stato = value
''        End Set
''    End Property

''    Public ReadOnly Property StatoStringa() As String
''        Get
''            Select Case _Stato
''                Case enStatoCommessa.Preinserito
''                    Return "Preinserito"
''                Case enStatoCommessa.Pronto
''                    Return "Pronto"
''                Case enStatoCommessa.Stampa
''                    Return "Stampa"
''                Case enStatoCommessa.FinituraSuCommessa
''                    Return "Finitura su commessa"
''                Case enStatoCommessa.FinituraSuProdotti
''                    Return "Finitura su Prodotti"
''                Case enStatoCommessa.Completata
''                    Return "Completata"
''            End Select
''        End Get
''    End Property

''    Private _FronteRetro As Integer
''    Public Property FronteRetro() As Integer
''        Get
''            Return _FronteRetro
''        End Get
''        Set(ByVal value As Integer)
''            _FronteRetro = value
''        End Set
''    End Property

''    Private _Plastifica As Integer
''    Public Property Plastifica() As Integer
''        Get
''            Return _Plastifica
''        End Get
''        Set(ByVal value As Integer)
''            _Plastifica = value
''        End Set
''    End Property

''    Private _Numero As String = ""
''    Public ReadOnly Property Numero() As String
''        Get
''            Return _IdCom
''        End Get
''    End Property

''    Private _File As String
''    Public Property File() As String
''        Get
''            Return _File
''        End Get
''        Set(ByVal value As String)
''            _File = value
''        End Set
''    End Property

''    Private _Annotazioni As String = ""
''    Public Property Annotazioni() As String
''        Get
''            Return _Annotazioni
''        End Get
''        Set(ByVal value As String)
''            _Annotazioni = value
''        End Set
''    End Property
''    Private _MacchinaStampa As String = ""
''    Public Property MacchinaStampa() As String
''        Get
''            Return _MacchinaStampa
''        End Get
''        Set(ByVal value As String)
''            _MacchinaStampa = value
''        End Set
''    End Property


''    Private _Copie As Integer
''    Public Property Copie() As Integer
''        Get
''            Return _Copie
''        End Get
''        Set(ByVal value As Integer)
''            _Copie = value
''        End Set
''    End Property

''    Private _IdFormato As Integer
''    Public Property IdFormato() As Integer
''        Get
''            Return _IdFormato
''        End Get
''        Set(ByVal value As Integer)
''            _IdFormato = value
''        End Set
''    End Property

''    Private _Lungo As Integer
''    Public Property Lungo() As Integer
''        Get
''            Return _Lungo
''        End Get
''        Set(ByVal value As Integer)
''            _Lungo = value
''        End Set
''    End Property

''    Private _Largo As Integer
''    Public Property Largo() As Integer
''        Get
''            Return _Largo
''        End Get
''        Set(ByVal value As Integer)
''            _Largo = value
''        End Set
''    End Property

''    Private _CostoImpianti As Decimal
''    Public Property CostoImpianti() As Decimal
''        Get
''            Return _CostoImpianti
''        End Get
''        Set(ByVal value As Decimal)
''            _CostoImpianti = value
''        End Set
''    End Property

''    Private _CostoFoglioSteso As Decimal
''    Public Property CostoFoglioSteso() As Decimal
''        Get
''            Return _CostoFoglioSteso
''        End Get
''        Set(ByVal value As Decimal)
''            _CostoFoglioSteso = value
''        End Set
''    End Property

''    Private _CostoCarta As Decimal
''    Public Property CostoCarta() As Decimal
''        Get
''            Return _CostoCarta
''        End Get
''        Set(ByVal value As Decimal)
''            _CostoCarta = value
''        End Set
''    End Property

''    Private _CostoTotale As Decimal
''    Public Property CostoTotale() As Decimal
''        Get
''            Return _CostoTotale
''        End Get
''        Set(ByVal value As Decimal)
''            _CostoTotale = value
''        End Set
''    End Property
''#End Region

''    Private _ListaIdOrdini As Integer()
''    Public Property ListaIdOrdini() As Integer()
''        Get
''            Return _ListaIdOrdini
''        End Get
''        Set(ByVal value As Integer())
''            _ListaIdOrdini = value
''        End Set
''    End Property

''    Private _Priorita As Integer = 0
''    Public Property Priorita() As Integer
''        Get
''            Return _Priorita
''        End Get
''        Set(ByVal value As Integer)
''            _Priorita = value
''        End Set
''    End Property

''#Region "Method"

''    Public Function IsValid() As Boolean

''        Dim Ris As Boolean = True

''        'If _File.Length = 0 Then
''        '    Ris = False
''        'End If

''        If _Copie < 1 Then
''            Ris = False
''        End If

''        If ListaIdOrdini.Length < 1 Then
''            Ris = False
''        End If

''        If MovMagaz.Count < 1 Then
''            Ris = False
''        End If

''        Return Ris

''    End Function

''    Public Function Read(ByVal Id As Integer) As Integer
''        Dim Ris As Integer = 0

''        Try
''            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
''            myCommand.CommandText = "SELECT * FROM T_Commesse where IdCom = " & Id
''            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
''            myReader.Read()
''            If myReader.HasRows Then
''                _IdCom = myReader("IdCom")
''                _IdTipoCom = myReader("IdTipoCom")
''                _IdRis = myReader("IdRis")
''                If Not myReader("IdLavorazione") Is DBNull.Value Then
''                    _IdLavorazione = myReader("IdLavorazione").ToString
''                End If
''                _TipoCom = myReader("TipoCom")
''                _Stato = myReader("Stato")
''                _DataCambioStato = myReader("DataCambioStato")
''                _DataIns = myReader("DataIns")
''                If Not myReader("FronteRetro") Is DBNull.Value Then
''                    _FronteRetro = myReader("FronteRetro").ToString
''                End If
''                _Numero = myReader("Numero")
''                If Not myReader("Copie") Is DBNull.Value Then
''                    _Copie = myReader("Copie").ToString
''                End If
''                If Not myReader("File") Is DBNull.Value Then
''                    _File = myReader("File").ToString
''                End If
''                If Not myReader("IdFormato") Is DBNull.Value Then
''                    _IdFormato = myReader("IdFormato").ToString
''                End If
''                If Not myReader("Lungo") Is DBNull.Value Then
''                    _Lungo = myReader("Lungo").ToString
''                End If
''                If Not myReader("Largo") Is DBNull.Value Then
''                    _Largo = myReader("Largo").ToString
''                End If
''                If Not myReader("CostoImpianti") Is DBNull.Value Then
''                    _CostoImpianti = myReader("CostoImpianti").ToString
''                End If
''                If Not myReader("CostoFoglioSteso") Is DBNull.Value Then
''                    _CostoFoglioSteso = myReader("CostoFoglioSteso").ToString
''                End If
''                If Not myReader("CostoCarta") Is DBNull.Value Then
''                    _CostoCarta = myReader("CostoCarta").ToString
''                End If
''                If Not myReader("Annotazioni") Is DBNull.Value Then
''                    _Annotazioni = myReader("Annotazioni").ToString
''                End If

''                If Not myReader("Priorita") Is DBNull.Value Then
''                    _Priorita = myReader("Priorita").ToString
''                End If
''                _CostoTotale = myReader("CostoTotale")
''            Else
''                Ris = 1
''            End If
''            myReader.Close()
''            myCommand.Dispose()

''        Catch ex As Exception
''            ManageError(ex)
''            Ris = ex.GetHashCode
''        End Try
''        Return Ris
''    End Function

''    Public Function Save(Optional ByRef IdInserito As Integer = 0) As Integer

''        Dim Ris As Integer = 0

''        Try
''            Dim sql As String
''            Dim myCommand As SqlCommand = New SqlCommand()
''            myCommand.Connection = LUNA.LunaContext.Connection
''            If _IdCom = 0 Then
''                sql = "INSERT INTO T_Commesse("
''                sql &= "IdTipoCom,"
''                sql &= "IdRis,"
''                sql &= "IdLavorazione,"
''                sql &= "TipoCom,"
''                sql &= "DataIns,"
''                sql &= "DataCambioStato,"
''                sql &= "Stato,"
''                sql &= "FronteRetro,"
''                sql &= "Numero,"
''                sql &= "Copie,"
''                sql &= "IdFormato,"
''                sql &= "Lungo,"
''                sql &= "Largo,"
''                sql &= "MacchinaStampa,"
''                sql &= "CostoImpianti,"
''                sql &= "CostoFoglioSteso,"
''                sql &= "CostoCarta,"
''                sql &= "CostoTotale,"
''                sql &= "Annotazioni,"
''                sql &= "Priorita,"
''                sql &= "File"
''                sql &= ") VALUES ("
''                sql &= _IdTipoCom & ","
''                sql &= _IdRis & ","
''                sql &= _IdLavorazione & ","
''                sql &= _TipoCom & ","
''                sql &= Ap(_DataIns) & ","
''                sql &= Ap(_DataCambioStato) & ","
''                sql &= _Stato & ","
''                sql &= _FronteRetro & ","
''                sql &= Ap(_Numero) & ","
''                sql &= _Copie & ","
''                sql &= _IdFormato & ","
''                sql &= _Lungo & ","
''                sql &= _Largo & ","
''                sql &= Ap(_MacchinaStampa) & ","
''                sql &= Ap(_CostoImpianti) & ","
''                sql &= Ap(_CostoFoglioSteso) & ","
''                sql &= Ap(_CostoCarta) & ","
''                sql &= Ap(_CostoTotale) & ","
''                sql &= Ap(_Annotazioni) & ","
''                sql &= "0,"
''                sql &= Ap(_File)
''                sql &= ")"
''            Else
''                sql = "UPDATE T_Commesse SET "
''                sql &= "IdTipoCom = " & _IdTipoCom & ","
''                sql &= "IdRis = " & _IdRis & ","
''                sql &= "IdLavorazione = " & _IdLavorazione & ","
''                sql &= "TipoCom = " & _TipoCom & ","
''                'sql &= "DataIns = " & ap(_DataIns) & ","
''                'sql &= "DataCambioStato = " & ap(_DataCambioStato) & ","
''                'sql &= "Stato = " & _Stato & ","
''                sql &= "FronteRetro = " & _FronteRetro & ","
''                sql &= "Numero = " & Ap(_Numero) & ","
''                sql &= "Copie = " & _Copie & ","
''                sql &= "IdFormato = " & _IdFormato & ","
''                sql &= "Lungo = " & _Lungo & ","
''                sql &= "Largo = " & _Largo & ","
''                sql &= "MacchinaStampa = " & Ap(_MacchinaStampa) & ","
''                sql &= "CostoImpianti = " & Ap(_CostoImpianti) & ","
''                sql &= "CostoFoglioSteso = " & Ap(_CostoFoglioSteso) & ","
''                sql &= "CostoCarta = " & Ap(_CostoCarta) & ","
''                sql &= "CostoTotale = " & Ap(_CostoTotale) & ","
''                sql &= "Annotazioni = " & Ap(_Annotazioni) & ","
''                sql &= "File = " & Ap(_File)
''                sql &= " WHERE IdCom= " & _IdCom
''            End If
''            myCommand.CommandText = sql
''            myCommand.ExecuteNonQuery()

''            If _IdCom = 0 Then
''                sql = "select @@identity"
''                myCommand.CommandText = sql
''                IdInserito = myCommand.ExecuteScalar()
''                _IdCom = IdInserito

''                InserisciLog(enStatoOrdine.Preinserito)
''                InserisciLavorazioni()
''            Else
''                IdInserito = _IdCom
''            End If

''            myCommand.Dispose()

''        Catch ex As Exception
''            ManageError(ex)
''            Ris = ex.GetHashCode
''        End Try
''        Return Ris
''    End Function

''    Public ReadOnly Property RiepilogoBreve() As String
''        Get
''            Dim bufferHtml As String = ""

''            Dim _Comsel As Commessa = Me

''            bufferHtml = "<HTML><HEAD><TITLE>Riepilogo</TITLE></HEAD><BODY BGCOLOR=""WHITE""><FONT SIZE=1 face=Arial>" & ControlChars.NewLine

''            bufferHtml &= "Commessa N: <FONT SIZE=4>" & _Comsel.Numero & "</FONT><BR><BR>"

''            Dim p As New TipoCommessa
''            p.Read(_Comsel.IdTipoCom)

''            bufferHtml &= "Tipo: <FONT SIZE=4>" & p.Descrizione & "<BR><BR>"

''            p = Nothing


''            bufferHtml &= "<A HREF=""" & _Comsel.File & """ target=_new><IMG SRC=""" & _Comsel.File & """ WIDTH=280></A><bR>"

''            bufferHtml &= "<br><FONT Face=Arial>"

''            bufferHtml &= "<FONT SIZE=1 > Note: <b><FONT SIZE=2 COLOR=RED>" & _Comsel.Annotazioni & "</FONT></b></FONT><BR><BR>"

''            bufferHtml &= "<FONT SIZE=1> Data: <FONT SIZE=3><b>" & _Comsel.DataIns & "</b></FONT><BR><BR>"


''            'qui carico i dettagli delle lavorazioni per questo ordine
''            bufferHtml &= "Dettagli Carta:<BR> "

''            Dim Dt As DataTable, Dr As DataRow

''            Dim RisColl As New cRisorseColl

''            Dt = RisColl.ListaRisorseCom(_Comsel.IdCom)

''            For Each Dr In Dt.Rows

''                bufferHtml &= " - qta: <FONT SIZE=3><B>" & Dr("Qta") & "</B></FONT>  Risorsa: <FONT SIZE=3><B>" & Dr("Descrizione") & "</FONT></B><BR>"

''            Next

''            bufferHtml &= "<br>Copie di stampa: <FONT SIZE=3><B>" & _Comsel.Copie & "<br><BR>"

''            bufferHtml &= "<b>"

''            If _Comsel.FronteRetro Then
''                bufferHtml &= " Fronte retro"
''            Else
''                bufferHtml &= " Solo fronte"
''            End If

''            bufferHtml &= "</B></FONT><BR><BR>"

''            Dim x As New cLavoriColl

''            bufferHtml &= "Lavorazioni:<BR> <FONT SIZE=3>"

''            Dt = x.ListaLavoriCom(_Comsel.IdCom)

''            For Each Dr In Dt.Rows

''                bufferHtml &= " - <B>" & Dr("Descrizione") & "</B><BR>"

''            Next

''            bufferHtml &= "</FONT><BR>"

''            bufferHtml &= "<FONT Face=Arial size=1>"
''            bufferHtml &= "Lastre: <FONT SIZE=3><B><BR>"

''            Dim Ris As New Risorsa

''            Ris.Read(_Comsel.IdRis)

''            bufferHtml &= Ris.Descrizione & "</B></FONT><BR><BR>"

''            Ris = Nothing

''            bufferHtml &= "Clienti:"

''            Dt = ListaClientiCom()

''            bufferHtml &= "<TABLE>"

''            For Each Dr In Dt.Rows

''                bufferHtml &= "<TR><TD valign=top><FONT SIZE=1><B>" & Dr("Nominativo") & "</B><br><BR></TD>"
''                bufferHtml &= "<TD valign=top><B><FONT SIZE=1>" & Dr("Tel") & "</B></TD>"
''                bufferHtml &= "<TD valign=top><B><FONT SIZE=1>" & Dr("Cellulare") & "</B></TD>"
''                bufferHtml &= "<TD valign=top><B><FONT SIZE=1>" & Dr("DescProdotto") & "</B></TD>"
''                bufferHtml &= "<TD valign=top><B><FONT SIZE=1>" & Dr("idord") & "</B></TD>"
''                bufferHtml &= "<TD  valign=top align=right><B><FONT SIZE=1>" & Dr("prezzo") & "</B></TD>"

''            Next

''            bufferHtml &= "</TABLE>"

''            bufferHtml &= "</FONT>"
''            bufferHtml &= "</FONT>"

''            bufferHtml &= "</FONT>"

''            bufferHtml &= "</BODY></HTML>" & ControlChars.NewLine

''            Return bufferHtml
''        End Get
''    End Property

''    Public ReadOnly Property Riepilogo() As String
''        Get
''            'Cursor.Current = Cursors.WaitCursor

''            Dim _comSel As Commessa = Me

''            Dim buffer As String = ""
''            Dim bufferHtml As String = ""

''            Dim Dt As DataTable, Dr As DataRow

''            bufferHtml = "<HTML><HEAD><TITLE>Riepilogo</TITLE></HEAD><BODY BGCOLOR=""WHITE""><FONT SIZE=1 face=Arial>" & ControlChars.NewLine

''            bufferHtml &= "<FONT SIZE=4><CENTER>Riepilogo Commessa</CENTER></FONT><BR><BR>"

''            'qui carico se ha immagini e in caso faccio il box incorniciato
''            bufferHtml &= "Commessa <BR>"

''            Dim p As New TipoCommessa
''            p.Read(_comSel.IdTipoCom)

''            bufferHtml &= "<FONT SIZE=6>" & p.Descrizione & "<BR><BR>"

''            p = Nothing

''            bufferHtml &= "<TABLE WIDTH=100%>"
''            bufferHtml &= "<TR>"
''            bufferHtml &= "<TD VALIGN=Top width=50%>"
''            bufferHtml &= "<FONT Face=Arial>"

''            bufferHtml &= "<FONT SIZE=1> Data: <FONT SIZE=3><b>" & _comSel.DataIns & "</b></FONT><BR><BR>"
''            bufferHtml &= "Commessa N: <FONT SIZE=6>" & _comSel.Numero & "</FONT><BR><BR>"

''            'qui carico i dettagli delle lavorazioni per questo ordine
''            bufferHtml &= "Dettagli Carta:<BR> "


''            Dim RisColl As New cRisorseColl

''            Dt = RisColl.ListaRisorseCom(_comSel.IdCom)

''            For Each Dr In Dt.Rows

''                bufferHtml &= " - qta: <FONT SIZE=3><B>" & Dr("Qta") & "</B></FONT>  Risorsa: <FONT SIZE=3><B>" & Dr("Descrizione") & "</FONT></B><BR>"

''            Next

''            bufferHtml &= "</FONT><BR><BR>"

''            bufferHtml &= "Copie di stampa:<BR><FONT SIZE=6>" & _comSel.Copie & "</FONT><FONT SIZE=3>"

''            bufferHtml &= "</FONT><BR><BR>"

''            bufferHtml &= "<FONT SIZE=3><B>"

''            If _comSel.FronteRetro Then
''                bufferHtml &= " Fronte retro"
''            Else
''                bufferHtml &= " Solo fronte"
''            End If

''            bufferHtml &= "</B></FONT><BR><BR>"

''            Dim x As New cLavoriColl

''            bufferHtml &= "Lavorazioni:<BR> <FONT SIZE=3>"

''            Dt = x.ListaLavoriCom(_comSel.IdCom)

''            For Each Dr In Dt.Rows

''                bufferHtml &= " - <B>" & Dr("Descrizione") & "</B><BR>"

''            Next

''            bufferHtml &= "</FONT><BR><BR>"

''            bufferHtml &= "</TD>"
''            bufferHtml &= "<TD VALIGN=Top width=50%><IMG SRC=""" & _comSel.File & """ WIDTH=400>"
''            bufferHtml &= "</TD>"

''            bufferHtml &= "</TR>"

''            bufferHtml &= "<TR><TD COLSPAN=2 VALIGN=TOP>"
''            bufferHtml &= "<FONT Face=Arial size=1>"
''            bufferHtml &= "Lastre: <FONT SIZE=3><B><BR>"

''            Dim Ris As New Risorsa

''            Ris.Read(_comSel.IdRis)

''            bufferHtml &= Ris.Descrizione & "</B></FONT><BR><BR>"

''            Ris = Nothing

''            bufferHtml &= "Clienti:"

''            Dt = ListaClientiCom()

''            bufferHtml &= "<TABLE width=100%>"

''            For Each Dr In Dt.Rows

''                bufferHtml &= "<TR><TD valign=top><FONT SIZE=1><B>" & Dr("Nominativo") & "</B><br><BR></TD>"
''                bufferHtml &= "<TD valign=top><B><FONT SIZE=1>" & Dr("Tel") & "</B></TD>"
''                bufferHtml &= "<TD valign=top><B><FONT SIZE=1>" & Dr("Cellulare") & "</B></TD>"
''                bufferHtml &= "<TD valign=top><B><FONT SIZE=1>" & Dr("DescProdotto") & "</B></TD>"
''                bufferHtml &= "<TD valign=top><B><FONT SIZE=1>" & Dr("idord") & "</B></TD>"
''                bufferHtml &= "<TD  valign=top align=right><B><FONT SIZE=1>" & Dr("prezzo") & "</B></TD>"

''            Next

''            bufferHtml &= "</TABLE>"

''            bufferHtml &= "</FONT>"
''            bufferHtml &= "</FONT><BR><BR>"
''            bufferHtml &= "</TD>"
''            bufferHtml &= "</TR>"


''            bufferHtml &= "</TABLE>"

''            bufferHtml &= "</BODY></HTML>" & ControlChars.NewLine
''            'ciclo per le varie zone presenti nell'agenzia e creo una riga per ogni zona 
''            'carico le offerte di quella zona

''            Return bufferHtml

''        End Get
''    End Property

''    Public Function ListaClientiCom() As DataTable
''        Dim datatb As DataTable = New DataTable("T_Clienti")
''        Try

''            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
''            Dim sql As String = ""

''            sql = "Select distinct RagSoc & ' ' & Cognome & ', ' & Nome as Nominativo, Tel, Cellulare, p.Descrizione as DescProdotto,  idOrd, o.Prezzo"

''            sql &= " from T_Rubrica R , T_Ordini O, T_Prodotti P "
''            sql &= " where O.idcom = " & _IdCom
''            sql &= " and R.idrub = o.idrub and o.idprod = p.idprod"

''            myCommand.CommandText = sql
''            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
''            datatb.Load(myReader)
''            myReader.Close()
''            myCommand.Dispose()

''        Catch ex As Exception
''            ManageError(ex)
''        End Try
''        Return datatb


''    End Function

''    Public Sub SalvaOrdini()

''        If _Stato = enStatoCommessa.Preinserito Then

''            Dim sql As String
''            Dim myCommand As SqlCommand = New SqlCommand()
''            myCommand.Connection = LUNA.LunaContext.Connection

''            sql = "UPDATE T_Ordini set idcom=0, stato=" & enStatoOrdine.Registrato & " where idcom= " & _IdCom

''            myCommand.CommandText = sql
''            myCommand.ExecuteNonQuery()

''            Dim listaId As String = ""

''            Dim I As Integer = 0

''            For I = 0 To ListaIdOrdini.GetUpperBound(0)

''                listaId &= ListaIdOrdini(I) & ","

''            Next

''            listaId = listaId.TrimEnd(",")

''            sql = "UPDATE T_Ordini set idcom=" & _IdCom & ", stato = " & enStatoOrdine.InCodaDiStampa & "  where idord in(" & listaId & ")"

''            myCommand.CommandText = sql
''            myCommand.ExecuteNonQuery()

''            myCommand.Dispose()

''        End If

''    End Sub

''    Public Sub SalvaMovMagaz()

''        If _Stato = enStatoCommessa.Preinserito Then

''            Dim sql As String
''            Dim myCommand As SqlCommand = New SqlCommand()
''            myCommand.Connection = LUNA.LunaContext.Connection

''            sql = "DELETE FROM T_Magaz where idcom= " & _IdCom

''            myCommand.CommandText = sql
''            myCommand.ExecuteNonQuery()

''            myCommand.Dispose()

''            Dim x As MovimentoMagazzino

''            For Each x In MovMagaz

''                x.IdCom = _IdCom
''                x.Save()
''                'x.AggiornaQta(0, x.Qta)

''            Next

''            x = Nothing

''            'scarico le lastre 
''            x = New MovimentoMagazzino
''            Dim Ris As New Risorsa

''            Ris.Read(_IdRis)

''            x.IdRis = _IdRis
''            x.Qta = Ris.Nlastre
''            x.TipoMov = enTipoMovMagaz.Prenotazione
''            x.IdCom = _IdCom
''            x.DataMov = Date.Now
''            x.Save()
''            'x.AggiornaQta(0, x.Qta)

''            x = Nothing

''        End If

''    End Sub

''    Private Sub InserisciLavorazioni()

''        Dim sql As String
''        Dim myCommand As SqlCommand = New SqlCommand()
''        myCommand.Connection = LUNA.LunaContext.Connection

''        Dim Dt As DataTable, x As New cLavoriColl, Dr As DataRow


''        Dt = x.ListaCommessaSel(_IdTipoCom)

''        For Each Dr In Dt.Rows

''            sql = "INSERT INTO T_LavLog("
''            sql &= "idCom,"
''            sql &= "Descrizione,"
''            sql &= "Macchinario,"
''            sql &= "Premio,"
''            sql &= "Tempo,"
''            sql &= "Ordine"
''            sql &= ") VALUES ("
''            sql &= _IdCom & ","
''            sql &= Ap(Dr("Descrizione")) & ","
''            sql &= Ap(Dr("Macchinario")) & ","
''            sql &= Dr("Premio") & ","
''            sql &= Dr("TempoRif") & ","
''            sql &= Dr("ordine")
''            sql &= ")"

''            myCommand.CommandText = sql
''            myCommand.ExecuteNonQuery()


''        Next
''    End Sub

''    Public Function InserisciLog(ByVal stato As enStatoCommessa) As Integer

''        Dim Ris As Integer = 0

''        Dim sql As String
''        Dim myCommand As SqlCommand = New SqlCommand()
''        myCommand.Connection = LUNA.LunaContext.Connection


''        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand(), StatoAttuale As Integer

''        'sql = "SELECT * from T_CommesseCrono where idcom= " & _IdCom & " And idstato = " & stato

''        sql = "SELECT * from T_Commesse where idcom= " & _IdCom '& " And idstato = " & stato

''        myCommand.CommandText = sql

''        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

''        myReader.Read()

''        If myReader.HasRows Then

''            'qui ho qualche lavorazione aperta, controllo di che tipo si tratta e mi comporto di conseguenza
''            StatoAttuale = myReader("Stato")
''            'Ris = myReader("idcrono")

''        End If

''        myReader.Close()
''        myCommand.Dispose()

''        If StatoAttuale <> stato Then

''            sql = "UPDATE T_Commesse SET STATO = " & stato & ",DataCambioStato = " & Ap(_DataCambioStato) & " WHERE IDCom=" & _IdCom

''            myCommand.CommandText = sql
''            myCommand.ExecuteNonQuery()
''            _DataCambioStato = Now
''            _Stato = stato

''            sql = "INSERT INTO T_CommesseCrono("
''            sql &= "IdCom,"
''            sql &= "DataCronoInizio,"
''            If stato = enStatoCommessa.Completata Then sql &= "DataCronoFine,"
''            sql &= "IdStato,"
''            sql &= "IdOperatore"
''            sql &= ") VALUES ("
''            sql &= _IdCom & ","
''            sql &= Ap(Now) & ","
''            If stato = enStatoCommessa.Completata Then sql &= Ap(Date.Now) & ","
''            sql &= stato & ","
''            sql &= Postazione.UtenteConnesso.IdUt
''            sql &= ")"

''            myCommand.CommandText = sql
''            myCommand.ExecuteNonQuery()

''            sql = "select @@identity"
''            myCommand.CommandText = sql
''            Ris = myCommand.ExecuteScalar()

''            myCommand.Dispose()

''        Else
''            'qui cerco la lavorazione aperta se c'e'
''            sql = "SELECT * from T_CommesseCrono where idcom= " & _IdCom & " And idstato = " & stato & " And datacronofine is null"
''            myCommand.CommandText = sql
''            myReader = myCommand.ExecuteReader
''            If myReader.HasRows Then
''                myReader.Read()
''                Ris = myReader("Idcrono")

''                myReader.Close()
''            End If

''        End If
''        'Ris = stato

''        Return Ris

''    End Function

''    Public Function AvanzamentoLavori() As DataTable
''        Dim datatb As DataTable = New DataTable("T_CommesseCrono")
''        Try

''            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
''            Dim sql As String = ""
''            sql = "SELECT DataCronoInizio as [Iniziato il], DataCronoFine as [Finito il], "

''            sql &= "switch(idstato=" & enStatoCommessa.Preinserito & ",'Preinserito',"
''            sql &= "idstato=" & enStatoCommessa.Pronto & ",'Pronto',"
''            sql &= "idstato=" & enStatoCommessa.Stampa & ",'Stampa',"
''            sql &= "idstato=" & enStatoCommessa.FinituraSuCommessa & ",'Finitura su commessa',"
''            sql &= "idstato=" & enStatoCommessa.FinituraSuProdotti & ",'Finitura su prodotti',"
''            sql &= "idstato=" & enStatoCommessa.Completata & ",'Completata'"

''            sql &= ") as [Stato]"

''            sql &= ", Login as Operatore from T_CommesseCrono c inner join t_utenti U on c.idoperatore = u.idut"
''            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
''            sql &= " where idcom = " & _IdCom
''            sql &= " Order by datacronoInizio"
''            myCommand.CommandText = sql
''            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
''            datatb.Load(myReader)
''            myReader.Close()
''            myCommand.Dispose()

''        Catch ex As Exception
''            ManageError(ex)
''        End Try
''        Return datatb

''    End Function


''#End Region

''End Class

''Public Class cCommesseColl

''    'Public Function DEPRECATEDLista(Optional ByVal Codice As String = "", Optional ByVal IdCli As Integer = 0, Optional ByVal Stato As String = "") As DataTable
''    '    Dim datatb As DataTable = New DataTable("T_Commesse")
''    '    Try

''    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
''    '        Dim sql As String = ""
''    '        sql = "SELECT switch(Priorita=0,'',Priorita=1,'SI') as P ,IdCom, idCom as Numero, "
''    '        sql &= "switch(stato=" & enStatoCommessa.Preinserito & ",'Preinserita',"
''    '        sql &= "stato=" & enStatoCommessa.Pronto & ",'Pronta',"
''    '        sql &= "stato=" & enStatoCommessa.Stampa & ",'Stampa',"
''    '        sql &= "stato=" & enStatoCommessa.FinituraSuCommessa & ",'Finitura su commessa',"
''    '        sql &= "stato=" & enStatoCommessa.FinituraSuProdotti & ",'Finitura su prodotti',"
''    '        sql &= "stato=" & enStatoCommessa.Completata & ",'Completata',"
''    '        sql &= ") as [Stato],"
''    '        sql &= "DataCambioStato as Data, tc.Descrizione as Tipo, Copie, stato as StatoCom,Priorita "
''    '        sql &= " ,(select top 1 Descrizione from T_Risorse R,T_Magaz M where R.idris = M.IdRis and M.IdCom = C.idcom and m.idut<>0 ) as Risorsa"
''    '        sql &= " ,(select top 1 QTa from T_Risorse R,T_Magaz M where R.idris = M.IdRis and M.IdCom = C.idcom and m.idut<>0) as Quantita "
''    '        sql &= " from T_Commesse C,  TD_TipoCommessa TC "
''    '        sql &= " Where c.idtipocom=tc.idtipocom "

''    '        If Stato.Length Then
''    '            sql &= " and c.stato in (" & Stato & ")"
''    '        End If

''    '        If IdCli Then
''    '            sql &= " and c.idcom in (SELECT IDCOM FROM T_ORDINI WHERE IDRUB =" & IdCli & ")"
''    '        End If

''    '        Select Case Postazione.AnnoSelezionato
''    '            Case 1 '6 mesi
''    '                sql &= " and datediff('m',datains,now) <= 6" ' & Ap(Postazione.AnnoSelezionato)
''    '            Case 2 '1 anno
''    '                sql &= " and datediff('m',datains,now) <= 12" ' & Ap(Postazione.AnnoSelezionato)
''    '        End Select

''    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
''    '        sql &= " Order by c.IdCom desc"

''    '        myCommand.CommandText = sql

''    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
''    '        datatb.Load(myReader)
''    '        myReader.Close()
''    '        myCommand.Dispose()

''    '    Catch ex As Exception
''    '        ManageError(ex)
''    '    End Try
''    '    Return datatb
''    'End Function

''    'Public Function DEPRECATEDImpostaPriorita(ByVal IdCom As Integer, ByVal Priorita As Integer) As Integer

''    '    Dim Ris As Integer = 0
''    '    Try

''    '        Dim myCommand As SqlCommand = New SqlCommand()
''    '        myCommand.Connection = LUNA.LunaContext.Connection
''    '        Dim Sql As String = "Update T_Commesse set Priorita =" & Priorita
''    '        Sql &= " Where IdCom = " & IdCom
''    '        myCommand.CommandText = Sql
''    '        myCommand.ExecuteNonQuery()
''    '        myCommand.Dispose()
''    '    Catch ex As Exception
''    '        ManageError(ex)
''    '        Ris = ex.GetHashCode
''    '    End Try
''    '    Return Ris



''    'End Function

''    'Public Function DEPRECATEDListaCombo() As DataTable
''    '    Dim datatb As DataTable = New DataTable("T_Commesse")
''    '    Try

''    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
''    '        Dim sql As String = ""
''    '        sql = "SELECT 0 as IdCom, '- Tutte ' as Tipo from t_commesse union select IdCom,idcom & ' ' & tc.Descrizione as Tipo from T_Commesse C,  TD_TipoCommessa TC "
''    '        sql &= " Where c.idtipocom=tc.idtipocom "

''    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
''    '        sql &= " Order by IdCom asc"

''    '        myCommand.CommandText = sql

''    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
''    '        datatb.Load(myReader)
''    '        myReader.Close()
''    '        myCommand.Dispose()

''    '    Catch ex As Exception
''    '        ManageError(ex)
''    '    End Try
''    '    Return datatb
''    'End Function

''    'Public Function DEPRECATEDLista(ByVal Stato As Integer) As DataTable
''    '    'utilizzata dalla modalita operatore
''    '    Dim datatb As DataTable = New DataTable("T_Commesse")
''    '    Try


''    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
''    '        Dim sql As String = ""

''    '        Select Case Stato
''    '            Case enStatoCommessa.Stampa

''    '                sql = "SELECT T_Commesse.IdCom as Numero, Format (T_Commesse.DataCambioStato, ""Short Date"") as Data, TD_TipoCommessa.Descrizione, T_Commesse.Copie, " & _
''    '                    "T_Commesse.Priorita, T_Risorse_1.Descrizione as Lastra, iif(T_Commesse.FronteRetro= true,'F/R','F') as [F/R],  " & _
''    '                    "First(T_Risorse.Descrizione) AS Carta "
''    '                sql &= " FROM T_Risorse AS T_Risorse_1 INNER JOIN ((T_Risorse INNER JOIN (T_Commesse INNER JOIN T_Magaz ON T_Commesse.IdCom = T_Magaz.IdCom) " & _
''    '                    " ON T_Risorse.IdRis = T_Magaz.IdRis) INNER JOIN TD_TipoCommessa ON T_Commesse.IdTipoCom = TD_TipoCommessa.IdTipoCom)" & _
''    '                    " ON T_Risorse_1.IdRis = T_Commesse.IdRis"
''    '                sql &= " GROUP BY T_Commesse.IdCom, T_Commesse.DataCambioStato, T_Commesse.TipoCom, TD_TipoCommessa.Descrizione, " & _
''    '                    " T_Commesse.Copie, T_Commesse.Priorita, T_Risorse_1.Codice, T_Risorse_1.Descrizione, T_Commesse.FronteRetro, T_Commesse.Stato"
''    '                sql &= " HAVING (((T_Commesse.Stato)=" & enStatoCommessa.Pronto & "));"

''    '                sql = " SELECT DISTINCT T_Commesse.IdCom AS Numero, Format(T_Commesse.DataCambioStato,""Short Date"") AS Data, TD_TipoCommessa.Descrizione, T_Commesse.Copie, T_Commesse.Priorita, T_Risorse_1.Descrizione AS Lastra, IIf(T_Commesse.FronteRetro=True,'F/R','F') AS [F/R], First(T_Risorse.Descrizione) AS Carta"
''    '                sql &= " FROM (T_Risorse AS T_Risorse_1 INNER JOIN ((T_Risorse INNER JOIN (T_Commesse INNER JOIN T_Magaz ON T_Commesse.IdCom = T_Magaz.IdCom) ON T_Risorse.IdRis = T_Magaz.IdRis) INNER JOIN TD_TipoCommessa ON T_Commesse.IdTipoCom = TD_TipoCommessa.IdTipoCom) ON T_Risorse_1.IdRis = T_Commesse.IdRis) INNER JOIN T_CommesseCrono ON (T_CommesseCrono.IdStato = T_Commesse.Stato) AND (T_Commesse.IdCom = T_CommesseCrono.IdCom)"
''    '                sql &= " GROUP BY T_Commesse.IdCom, TD_TipoCommessa.Descrizione, T_Commesse.Copie, T_Commesse.Priorita, T_Risorse_1.Descrizione, T_CommesseCrono.DataCronoInizio, T_CommesseCrono.DataCronoFine, T_Commesse.DataCambioStato, T_Commesse.TipoCom, T_Risorse_1.Codice, T_Commesse.FronteRetro, T_Commesse.Stato"
''    '                sql &= " HAVING (T_CommesseCrono.DataCronoInizio Is Not Null AND T_CommesseCrono.DataCronoFine is null and T_Commesse.Stato=" & enStatoCommessa.Stampa & ") Or T_Commesse.Stato=" & enStatoCommessa.Pronto


''    '            Case enStatoCommessa.FinituraSuCommessa
''    '                sql = "SELECT l.idcom as [Numero Commessa], first(tc.Descrizione) as TipoCommessa, 'Finitura su Commessa' as Stato, first(l.Descrizione) as Lavorazione,first(l.ordine) as Ordine, first(priorita) as Priorita"
''    '                sql &= "   FROM T_Commesse C,T_CommesseCrono CC, T_LavLog L,  TD_TipoCommessa TC "
''    '                sql &= " WHERE C.IdCom = CC.idcom"
''    '                sql &= " and c.idtipocom=tc.idtipocom "
''    '                sql &= " AND C.stato in( " & enStatoCommessa.Stampa & "," & enStatoCommessa.FinituraSuCommessa & ")"
''    '                sql &= " and not CC.DataCronoFine is null "
''    '                sql &= " and L.IdCom = C.IdCom "
''    '                sql &= " and L.DataOraInizio is Null "
''    '                sql &= " and c.idcom not in (select idcom from t_lavlog where not dataorainizio is null and dataorafine is null)"
''    '                sql &= " group by l.idcom "
''    '                ' sql &= " order by first(l.ordine) "
''    '                sql &= " Order by l.IdCom asc, first(l.ordine)"


''    '        End Select

''    '        myCommand.CommandText = sql

''    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
''    '        datatb.Load(myReader)
''    '        myReader.Close()
''    '        myCommand.Dispose()

''    '    Catch ex As Exception
''    '        ManageError(ex)
''    '    End Try
''    '    Return datatb
''    'End Function

''    'Public Function Delete(ByVal Id As Integer) As Integer
''    '    Dim Ris As Integer = 0
''    '    Try

''    '        Dim myCommand As SqlCommand = New SqlCommand()
''    '        myCommand.Connection = LUNA.LunaContext.Connection
''    '        Dim Sql As String = "DELETE FROM T_Commesse"
''    '        Sql &= " Where IdCom = " & Id
''    '        myCommand.CommandText = Sql
''    '        myCommand.ExecuteNonQuery()
''    '        myCommand.Dispose()
''    '    Catch ex As Exception
''    '        ManageError(ex)
''    '        Ris = ex.GetHashCode
''    '    End Try
''    '    Return Ris
''    'End Function

''End Class


''Public Class cCommesseCrono

''#Region "Property"

''    Private _IdCrono As Integer
''    Public Property IdCrono() As Integer
''        Get
''            Return _IdCrono
''        End Get
''        Set(ByVal value As Integer)
''            _IdCrono = value
''        End Set
''    End Property
''    Private _IdCom As Integer
''    Public Property IdCom() As Integer
''        Get
''            Return _IdCom
''        End Get
''        Set(ByVal value As Integer)
''            _IdCom = value
''        End Set
''    End Property
''    Private _DataCronoInizio As DateTime
''    Public Property DataCronoInizio() As DateTime
''        Get
''            Return _DataCronoInizio
''        End Get
''        Set(ByVal value As DateTime)
''            _DataCronoInizio = value
''        End Set
''    End Property

''    Private _DataCronoFine As DateTime
''    Public Property DataCronoFine() As DateTime
''        Get
''            Return _DataCronoFine
''        End Get
''        Set(ByVal value As DateTime)
''            _DataCronoFine = value
''        End Set
''    End Property


''    Private _IdStato As Integer
''    Public Property IdStato() As Integer
''        Get
''            Return _IdStato
''        End Get
''        Set(ByVal value As Integer)
''            _IdStato = value
''        End Set
''    End Property

''    Private _IdOperatore As Integer
''    Public Property IdOperatore() As Integer
''        Get
''            Return _IdOperatore
''        End Get
''        Set(ByVal value As Integer)
''            _IdOperatore = value
''        End Set
''    End Property
''#End Region


''#Region "Method"

''    Public Function Read(ByVal Id As Integer) As Integer
''        Dim Ris As Integer = 0

''        Try
''            Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
''            myCommand.CommandText = "SELECT * FROM T_CommesseCrono where IdCrono = " & Id
''            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
''            myReader.Read()
''            If myReader.HasRows Then
''                _IdCrono = myReader("IdCrono")
''                If Not myReader("DataCronoInizio") Is DBNull.Value Then _DataCronoInizio = myReader("DataCronoInizio")
''                If Not myReader("DataCronoFine") Is DBNull.Value Then _DataCronoFine = myReader("DataCronoFine")
''                _IdCom = myReader("IdCom")
''                _IdStato = myReader("IdStato")
''                _IdOperatore = myReader("IdOperatore")
''            Else
''                Ris = 1
''            End If
''            myReader.Close()
''            myCommand.Dispose()

''        Catch ex As Exception
''            ManageError(ex)
''            Ris = ex.GetHashCode
''        End Try
''        Return Ris
''    End Function

''    Public Function Save() As Integer

''        Dim Ris As Integer = 0

''        Try
''            Dim sql As String
''            Dim myCommand As SqlCommand = New SqlCommand()
''            myCommand.Connection = LUNA.LunaContext.Connection
''            If _IdCrono = 0 Then
''                sql = "INSERT INTO T_CommesseCrono("
''                sql &= "DataCronoInizio,"
''                sql &= "DataCronoFine,"
''                sql &= "IdStato,"
''                sql &= "IdCom,"
''                sql &= "IdOperatore"
''                sql &= ") VALUES ("
''                sql &= Ap(_DataCronoInizio) & ","
''                sql &= Ap(_DataCronoFine) & ","
''                sql &= _IdStato & ","
''                sql &= _IdCom & ","
''                sql &= _IdOperatore
''                sql &= ")"
''            Else
''                sql = "UPDATE T_CommesseCrono SET "
''                sql &= "DataCronoInizio = " & Ap(_DataCronoInizio) & ","
''                sql &= "DataCronoFine = " & Ap(_DataCronoFine) & ","
''                sql &= "IdStato = " & _IdStato & ","
''                sql &= "IdCom = " & _IdCom & ","
''                sql &= "IdOperatore = " & _IdOperatore
''                sql &= " WHERE IdCrono= " & _IdCrono
''            End If
''            myCommand.CommandText = sql
''            myCommand.ExecuteNonQuery()
''            myCommand.Dispose()

''        Catch ex As Exception
''            ManageError(ex)
''            Ris = ex.GetHashCode
''        End Try
''        Return Ris
''    End Function

''#End Region

''End Class


'Public Class cCommesseCronoColl
'    Inherits _cOldDao
'    'Public Function Delete(ByVal Id As Integer) As Integer
'    '    Dim Ris As Integer = 0
'    '    Try

'    '        Dim myCommand As SqlCommand = New SqlCommand()
'    '        myCommand.Connection = LUNA.LunaContext.Connection
'    '        Dim Sql As String = "DELETE FROM T_CommesseCrono"
'    '        Sql &= " Where IdCrono = " & Id
'    '        myCommand.CommandText = Sql
'    '        myCommand.ExecuteNonQuery()
'    '        myCommand.Dispose()
'    '    Catch ex As Exception
'    '        ManageError(ex)
'    '        Ris = ex.GetHashCode
'    '    End Try
'    '    Return Ris
'    'End Function
'    'Public Function DEPRECATEDForzaChiusura(ByVal Id As Integer) As Integer
'    '    Dim Ris As Integer = 0
'    '    Try

'    '        Dim myCommand As SqlCommand = New SqlCommand()
'    '        myCommand.Connection = LUNA.LunaContext.Connection
'    '        Dim Sql As String = "UPDATE T_CommesseCrono set datacronofine = now "
'    '        Sql &= " Where IdCrono = " & Id
'    '        myCommand.CommandText = Sql
'    '        myCommand.ExecuteNonQuery()
'    '        myCommand.Dispose()
'    '    Catch ex As Exception
'    '        ManageError(ex)
'    '        Ris = ex.GetHashCode
'    '    End Try
'    '    Return Ris
'    'End Function
'    <Obsolete("Metodo Deprecato")> _
'    Public Function CommessaAperta(IdOperatore As Integer, IdCommessa As Integer, idstato As Integer, IdLavLog As Integer) As StatoLavorazione
'        'torna 0 se non cominciata
'        'torna 1 se cominciata dall'operatore passato e non chiusa
'        'torna 2 se cominciata dall'operatore passato e chiusa
'        'torna 3 se cominciata da un altro operatore
'        Dim Ris As New StatoLavorazione
'        Try

'            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
'            Dim sql As String = ""
'            If IdLavLog Then
'                If idstato = enStatoCommessa.FinituraSuProdotti Then
'                    sql = "SELECT IdCrono, null as DI, Idoperatore, null as DF "
'                    sql &= " from T_CommesseCrono where iDcom = " & _
'                        IdCommessa & " AND IDSTATO = " & idstato

'                Else
'                    sql = "SELECT c.IdCrono, l.DataOraInizio as DI, Idut as Idoperatore, DataOraFine as DF "
'                    sql &= " from T_CommesseCrono c inner join t_Lavlog L on c.idcom=l.idcom where c.IDcom = " & _
'                        IdCommessa & " AND c.IDSTATO=" & idstato
'                    sql &= " and l.idlavlog = " & IdLavLog
'                End If

'            Else
'                sql = "SELECT IdCrono, DataCronoInizio as DI, Idoperatore, DataCronoFine as DF "
'                sql &= " from T_CommesseCrono where IDcom = " & IdCommessa & " AND IDSTATO=" & idstato
'            End If

'            myCommand.CommandText = sql

'            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

'            myReader.Read()

'            If myReader.HasRows Then
'                Ris.IdCrono = myReader("IdCrono")
'                If IsDBNull(myReader("DI")) Then

'                    Ris.Stato = 0
'                Else
'                    Ris.IdOp = myReader("idoperatore")
'                    Ris.DataInizio = myReader("DI")

'                    If IsDBNull(myReader("DF")) Then

'                        If IsDBNull(myReader("idoperatore")) OrElse myReader("idoperatore") = IdOperatore Then
'                            Ris.Stato = 1

'                        Else
'                            Ris.Stato = 3

'                        End If
'                    Else
'                        Ris.Stato = 2
'                        Ris.DataFine = myReader("DI")
'                    End If

'                End If
'            End If

'            myReader.Close()
'            myCommand.Dispose()

'        Catch ex As Exception
'            OldManageError(ex)
'        End Try

'        Return Ris
'    End Function

'    'Public Function LavorazioneAperta(ByVal IdOp As Integer, Optional ByVal frmChiamante As Form = Nothing) As Integer
'    '    Dim Ris As Integer = 0
'    '    Try

'    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()
'    '        Dim sql As String = ""
'    '        sql = "SELECT idCrono, IdCom as Commessa,DatacronoInizio as [Data Inizio Lavorazione],"

'    '        sql &= "switch(idstato=" & enStatoCommessa.Preinserito & ",'Preinserito',"
'    '        sql &= "idstato=" & enStatoCommessa.Pronto & ",'Pronto',"
'    '        sql &= "idstato=" & enStatoCommessa.Stampa & ",'Stampa',"
'    '        sql &= "idstato=" & enStatoCommessa.FinituraSuCommessa & ",'Finitura su commessa',"
'    '        sql &= "idstato=" & enStatoCommessa.FinituraSuProdotti & ",'Finitura su prodotti',"
'    '        sql &= "idstato=" & enStatoCommessa.Completata & ",'Completata'"

'    '        sql &= ") as [Stato]"



'    '        sql &= " from T_CommesseCrono where idoperatore = " & IdOp

'    '        sql &= " and dataCronofine is null "

'    '        myCommand.CommandText = sql

'    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'    '        Dim Dt As New DataTable
'    '        'myReader.Read()

'    '        Dt.Load(myReader)

'    '        Select Case Dt.Rows.Count
'    '            Case 0
'    '                Ris = 0
'    '            Case 1
'    '                Ris = Dt.Rows(0)("IdCrono")
'    '            Case Is > 1

'    '                If Not frmChiamante Is Nothing Then Sottofondo(frmChiamante)
'    '                Dim FrmSess As New frmSessAperte
'    '                Ris = FrmSess.Carica()
'    '                FrmSess = Nothing
'    '                If Not frmChiamante Is Nothing Then Sottofondo(frmChiamante)

'    '        End Select

'    '        Dt.Dispose()
'    '        myReader.Close()
'    '        Dt = Nothing
'    '        myCommand.Dispose()

'    '    Catch ex As Exception
'    '        ManageError(ex)
'    '    End Try

'    '    Return Ris

'    'End Function

'    'Public Function LavorazioniApertes() As DataTable
'    '    Dim Dt As New DataTable
'    '    Try

'    '        'prima forzo la chiusura delle sessioni di lavoro che sono rimaste appese chiudendole alla data attuale

'    '        Dim myCommand As SqlCommand = New SqlCommand()
'    '        myCommand.Connection = LUNA.LunaContext.Connection
'    '        Dim Sql As String = "UPDATE T_CommesseCrono set datacronofine = now "
'    '        Sql &= " Where IdCrono  in ( select idcrono from t_commessecrono cc,t_commesse c where c.idcom= cc.idcom and cc.datacronofine is null and c.stato = 6 and cc.idstato>2 and idoperatore = " & Postazione.UtenteConnesso.IdUt & " )"
'    '        myCommand.CommandText = Sql
'    '        myCommand.ExecuteNonQuery()
'    '        myCommand.Dispose()

'    '        Dim myCommand As SqlCommand = LUNA.LunaContext.Connection.CreateCommand()

'    '        Sql = "SELECT idCrono, IdCom as Commessa,DatacronoInizio as [Data Inizio Lavorazione],"

'    '        Sql &= "switch(idstato=" & enStatoCommessa.Preinserito & ",'Preinserito',"
'    '        Sql &= "idstato=" & enStatoCommessa.Pronto & ",'Pronto',"
'    '        Sql &= "idstato=" & enStatoCommessa.Stampa & ",'Stampa',"
'    '        Sql &= "idstato=" & enStatoCommessa.FinituraSuCommessa & ",'Finitura su commessa',"
'    '        Sql &= "idstato=" & enStatoCommessa.FinituraSuProdotti & ",'Finitura su prodotti',"
'    '        Sql &= "idstato=" & enStatoCommessa.Completata & ",'Completata'"

'    '        Sql &= ") as [Stato]"

'    '        Sql &= " from T_CommesseCrono where idoperatore = " & Postazione.UtenteConnesso.IdUt

'    '        Sql &= " and dataCronofine is null "

'    '        myCommand.CommandText = Sql

'    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()

'    '        'myReader.Read()

'    '        Dt.Load(myReader)

'    '        myReader.Close()

'    '        myCommand.Dispose()

'    '    Catch ex As Exception
'    '        ManageError(ex)
'    '    End Try

'    '    Return Dt

'    'End Function

'End Class

