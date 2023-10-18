#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum


''' <summary>
'''DAO Class for table T_contabricavi
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class RicaviDAO
    Inherits _RicaviDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Public Function GetListaStatiFEAttivi() As List(Of Integer)
        Dim ris As New List(Of Integer)

        Try
            Dim Sql As String = "SELECT DISTINCT statofe FROM t_contabricavi WHERE not statofe is null ORDER BY statofe"
            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        If Not myReader("statofe") Is DBNull.Value Then ris.Add(myReader("statofe"))

                    End While
                    myReader.Close()
                End Using
            End Using
        Catch ex As Exception

        End Try



        Return ris
    End Function

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function GetIntestazioniDocumento(IdRub As Integer) As List(Of IntestazioneDocumento)

        Dim ris As New List(Of IntestazioneDocumento)
        Try
            Dim sql As String = "SELECT DISTINCT pragsoc,pindirizzo, pcitta , pcap, piva FROM t_contabricavi WHERE IdRub = " & IdRub
            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim Int As New IntestazioneDocumento
                        'CAMPI EXTRA
                        'If Not myReader("ProdottoDescrizione") Is DBNull.Value Then classe.ProdottoDescrizione = myReader("ProdottoDescrizione")
                        If Not myReader("pragsoc") Is DBNull.Value Then Int.pRagSoc = myReader("pragsoc")
                        If Not myReader("pindirizzo") Is DBNull.Value Then Int.pIndirizzo = myReader("pindirizzo")
                        If Not myReader("pcitta") Is DBNull.Value Then Int.pCitta = myReader("pcitta")
                        If Not myReader("pcap") Is DBNull.Value Then Int.pCap = myReader("pcap")
                        If Not myReader("piva") Is DBNull.Value Then Int.pIva = myReader("piva")

                        ris.Add(Int)
                    End While
                    myReader.Close()
                End Using
            End Using
        Catch ex As Exception

        End Try

        Return ris

    End Function

    Public Function GetLista(ByVal AnnoRif As Integer,
                              ByVal MeseRif As Integer,
                              Optional ByVal IdRub As Integer = 0,
                              Optional ByVal TipoDocToShow As enFiltroTipoDocumento = 0,
                              Optional ByVal OnlyNotPaid As Boolean = False,
                              Optional ByVal OnlyNotElapsed As Boolean = False,
                              Optional ByVal OnlyInCons As Boolean = False,
                              Optional ByVal Descrizione As String = "",
                              Optional ByVal TipoPagamento As Integer = 0,
                              Optional ByVal SoloNonStampati As Boolean = False,
                              Optional ByVal StatoIncasso As enStatoIncasso = enStatoIncasso.Tutto,
                              Optional IdAzienda As Integer = 0,
                              Optional StatoFe As Integer = -1) As List(Of RicavoEx)

        Dim Ris As New List(Of RicavoEx)
        Try
            Dim TipoDocumenti As String = String.Empty

            Select Case TipoDocToShow
                Case enFiltroTipoDocumento.Fattura
                    TipoDocumenti = " and (tipo =  " & enTipoDocumento.Fattura & " or tipo =  " & enTipoDocumento.FatturaRiepilogativa & ")"
                Case enFiltroTipoDocumento.FatturaENotaDiCredito
                    TipoDocumenti = " and (tipo =  " & enTipoDocumento.Fattura & " or tipo =  " & enTipoDocumento.FatturaRiepilogativa & " or tipo =  " & enTipoDocumento.NotaDiCredito & ")"
                Case enFiltroTipoDocumento.FatturaRiepilogativa
                    TipoDocumenti = " and (tipo =  " & enTipoDocumento.FatturaRiepilogativa & ")"
                Case enFiltroTipoDocumento.Preventivo
                    TipoDocumenti = " and (tipo =  " & enTipoDocumento.Preventivo & ")"
                Case enFiltroTipoDocumento.DDT
                    TipoDocumenti = " and (tipo =  " & enTipoDocumento.DDT & ") And (iddocrif=0 Or iddocrif Is null)"
                Case enFiltroTipoDocumento.DDTInFattura
                    TipoDocumenti = " and (tipo =  " & enTipoDocumento.DDT & ") And iddocrif<>0"
                Case enFiltroTipoDocumento.NotaDiCredito
                    TipoDocumenti = " and (tipo =  " & enTipoDocumento.NotaDiCredito & ")"
                Case enFiltroTipoDocumento.NotaDiDebito
                    TipoDocumenti = " and (tipo =  " & enTipoDocumento.NotaDiDebito & ")"
                Case enFiltroTipoDocumento.AccontoAnticipoSuFattura
                    TipoDocumenti = " and (tipo =  " & enTipoDocumento.AccontoAnticipoSuFattura & ")"
            End Select

            Dim sql As String = "Select * FROM (Select *,isnull((Select sum(importo) from t_pagamenti where idfat= idricavo And tipo=" & enTipoVoceContab.VoceVendita &
                                "),0) As Incassati,round(Totale - isnull((Select sum(importo) from t_pagamenti where idfat= idricavo And tipo=" & enTipoVoceContab.VoceVendita & "),0),2) As Differenza FROM T_ContabRicavi "

            sql &= " WHERE 1 = 1 " ' lo metto per evitare mille controlli sull'and

            If IdRub Then sql &= " And idrub=  " & IdRub

            If TipoPagamento Then
                sql &= " And Idpagamento = " & TipoPagamento
            End If

            If TipoDocumenti <> String.Empty Then
                sql &= TipoDocumenti
            End If

            If AnnoRif Then

                If AnnoRif = FormerLib.FormerConst.Fiscali.IdBiennio Then
                    sql &= " AND year(dataricavo) IN (" & Now.Year & "," & (Now.Year - 1) & ")"
                Else
                    sql &= " AND year(dataricavo) =  " & Ap(AnnoRif)
                End If

            End If

            If MeseRif Then
                sql &= " And month(dataricavo) =  " & (MeseRif)
            End If

            If OnlyInCons Then
                sql &= " And idricavo In (Select distinct iddoc from t_ordini where stato=" & enStatoOrdine.InConsegna & ")"
            End If

            If Descrizione.Length Then
                sql &= " And (descrizione " & ApLike(Descrizione) & " Or Numero " & ApLike(Descrizione) & ")"
            End If

            If SoloNonStampati Then
                sql &= " And CounterStampe = 0 "
            End If

            If StatoIncasso <> enStatoIncasso.Tutto Then
                sql &= " And statoincasso = " & StatoIncasso
            End If

            If IdAzienda Then
                sql &= " And IdAzienda = " & IdAzienda
            End If

            If StatoFe <> -1 Then
                sql &= " And StatoFe = " & StatoFe

                sql &= " And Tipo In (" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.NotaDiCredito & "," & enTipoDocumento.NotaDiDebito & "," & enTipoDocumento.AccontoAnticipoSuFattura & ")"
            End If

            sql &= " ) As a "


            If OnlyNotPaid Then
                sql &= " where Differenza > 0 " '<>0 TOLTO PER FAR SPARIRE LE FATTURE PAGATE DI PIU
            End If

            sql &= " order by dataricavo desc ,Numero desc "


            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim classe As New RicavoEx(CType(myReader, IDataRecord))

                        'CAMPI EXTRA
                        'If Not myReader("ProdottoDescrizione") Is DBNull.Value Then classe.ProdottoDescrizione = myReader("ProdottoDescrizione")
                        If Not myReader("Incassati") Is DBNull.Value Then classe.Incassati = myReader("Incassati")
                        'If Not myReader("Differenza") Is DBNull.Value Then classe.Differenza = myReader("Differenza")

                        Ris.Add(classe)
                    End While
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris
    End Function

    'Public Function ListaSituaz(Optional ByVal IdRub As Integer = 0, _
    '                            Optional ByVal OnlyInCons As Boolean = False, _
    '                            Optional ByVal OnlyNotPayd As Boolean = False, _
    '                            Optional ByVal Scad As Boolean = False) As DataTable

    '    Dim datainizio As Date = Now
    '    Dim myReader As Data.Common.DbDataReader
    '    Dim datatb As DataTable = New DataTable("T_Contab")
    '    Try
    '        'Dim cn2 As SqlConnection
    '        'cn2 = New SqlConnection("server=" & Postazione.SqlServerName & ";uid=" & Postazione.SqlLogin & ";pwd=" & Postazione.SqlPwd & ";database=" & Postazione.SqlDbName)
    '        'cn2.Open()
    '        Dim myCommand As Data.Common.DbCommand = _cn.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "Select * from ("
    '        'sql &= "Select IdCosto As Idrif," & enTipoVoceContab.enTipoVoceFatturaAcquisto & " As TipoVoce,'Uscita - ' & "
    '        'sql &= "switch(c.tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
    '        'sql &= "c.tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
    '        'sql &= "c.tipo=" & enTipoDocumento.enTipoDocFatturaRiepilogativa & ",'Fattura Riepilogativa',"
    '        'sql &= "c.tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
    '        'sql &= ")"
    '        'sql &= " as TipoDoc , DataCosto as DataRif,Numero, RagSoc as Destinatario,Descrizione, Importo,Iva,Totale,0 + (Select sum(importo) from t_pagamenti where idfat= c.idcosto and tipo=" & enTipoVoceContab.enTipoVoceFatturaAcquisto & ") as Incassati,csng(Totale) - csng(0 & incassati) as Differenza,c.Tipo,'' as Fattura,0 as idDocRif  from T_ContabCosti c inner join t_rubrica r on c.idrub=r.idrub "

    '        'sql &= " where 1=1 "


    '        'If IdRub Then sql &= " and c.idrub=  " & IdRub

    '        'sql &= " union "
    '        sql &= "Select IdRicavo as Idrif," & enTipoVoceContab.enTipoVoceVendita & " as TipoVoce,'Vendita - ' & "
    '        'sql &= "switch(c.tipo=" & enTipoDocumento.enTipoDocFattura & ",'Acquisto',"
    '        sql &= "(select case c.tipo when " & enTipoDocumento.enTipoDocFattura & " then 'Fattura' "
    '        sql &= " when " & enTipoDocumento.enTipoDocPreventivo & " then 'Preventivo' "
    '        sql &= " when " & enTipoDocumento.enTipoDocFatturaRiepilogativa & " then 'Fattura Riepilogativa' "
    '        sql &= " when " & enTipoDocumento.enTipoDocDDT & " then 'DDT' "
    '        sql &= "end )"
    '        sql &= " as TipoDoc , DataRicavo as DataRif,Numero,dataprevpagam as DaPagareIl, RagSoc as Destinatario,Descrizione, Importo,Iva,Totale,0 + (Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=" & enTipoVoceContab.enTipoVoceVendita & ") as Incassati,csng(Totale) - csng(0 & incassati) as Differenza,c.tipo,'' as Fattura,IdDocRif   from T_ContabRicavi  c inner join t_rubrica r on c.idrub=r.idrub "
    '        sql &= " where 1=1 "

    '        sql &= " and c.tipo <>" & enTipoDocumento.enTipoDocDDT

    '        If IdRub Then sql &= " and c.idrub=  " & IdRub

    '        'Select Case Postazione.AnnoSelezionato
    '        '    Case 1 '6 mesi
    '        '        sql &= " and datediff('m',DataRicavo,now) <= 6" ' & Ap(Postazione.AnnoSelezionato)
    '        '    Case 2 '1 anno
    '        '        sql &= " and datediff('m',DataRicavo,now) <= 12" ' & Ap(Postazione.AnnoSelezionato)
    '        'End Select


    '        'filtro su scaduto o no

    '        If Scad Then
    '            sql &= " and datediff(d,dataprevpagam,getdate())>0"
    '        Else
    '            sql &= " and datediff(d,dataprevpagam,getdate())<=0"
    '        End If

    '        sql &= " order by dataprevpagam asc"
    '        sql &= ") "

    '        sql &= " where 1=1 "

    '        If OnlyNotPayd Then
    '            sql &= " and Differenza <>0 "
    '        End If

    '        If OnlyInCons Then
    '            sql &= " and idrif in (select distinct iddoc from t_ordini where stato=  " & enStatoOrdine.InConsegna & ")"
    '        End If

    '        'sql = "SELECT * from (Select IdRicavo as Idrif,1 as TipoVoce,'Entrata - ' as aaa, DataRicavo as DataRif,Numero,dataprevpagam as DaPagareIl,RagSoc as Destinatario,Descrizione, Importo,Iva,Totale,0 + (Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=1) as Incassati,Totale as Differenza,c.tipo,'' as Fattura,IdDocRif   from T_ContabRicavi  c inner join t_rubrica r on c.idrub=r.idrub   where 1=1  and c.tipo <>2 )as a  where Differenza <>0"

    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

    '        myCommand.CommandText = sql
    '        myReader = myCommand.ExecuteReader()

    '        datatb.BeginLoadData()
    '        datatb.Load(myReader)
    '        datatb.EndLoadData()
    '        myReader.Close()
    '        myCommand.Dispose()

    '        Dim dataFine As Date = Now

    '        Dim Tempoimpiegato As Long = 0

    '        Tempoimpiegato = DateDiff(DateInterval.Second, datainizio, dataFine)
    '        'Stop

    '    Catch ex As Exception
    '        ManageError(ex)
    '    End Try
    '    Return datatb

    'End Function

    Public Function Lista(IdRub As Integer,
                          Optional StatoIncasso As enStatoIncasso = enStatoIncasso.Tutto) As List(Of RicavoEx)

        Dim L As New List(Of RicavoEx)
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT * FROM (SELECT *,isnull((Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=" & enTipoVoceContab.VoceVendita & "),0) as Incassati,"
                sql &= " round(Totale - isnull((Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=" & enTipoVoceContab.VoceVendita & "),0),2) as Differenza "
                sql &= " FROM T_ContabRicavi c "
                sql &= " WHERE IdRub = " & IdRub
                sql &= " AND ((c.tipo = " & enTipoDocumento.DDT & " AND C.iddocrif=0 or c.iddocrif is null) or (c.tipo<> " & enTipoDocumento.DDT & "))"

                'If WithDDT = False Then
                '    sql &= " AND C.TIPO <> " & enTipoDocumento.DDT
                'End If

                If StatoIncasso <> enStatoIncasso.Tutto Then
                    sql &= " AND C.STATOINCASSO = " & StatoIncasso
                End If

                sql &= " ) B WHERE Differenza > 0 OR datediff(d,dataprevpagam,getdate())<=0" '<>0

                'Select Case AnnoSelezionato
                '    Case 1 '6 mesi
                '        sql &= " and datediff(m,datains,getdate()) <= 6" ' & Ap(Postazione.AnnoSelezionato)
                '    Case 2 '1 anno
                '        sql &= " and datediff(m,datains,getdate()) <= 12" ' & Ap(Postazione.AnnoSelezionato)
                'End Select

                'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
                'sql &= " ORDER BY c.IdCom DESC"

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim classe As New RicavoEx(CType(myReader, IDataRecord))

                        'DATI EXTRA 
                        'If Not myReader("MacchinaStampaStr") Is DBNull.Value Then classe.MacchinaStampaStr = myReader("MacchinaStampaStr")
                        'If Not myReader("Tipo") Is DBNull.Value Then classe.TipoCommessaStr = myReader("Tipo")
                        'If Not myReader("Riassunto") Is DBNull.Value Then classe.TipoCommessaStr = myReader("Riassunto")
                        'If Not myReader("Risorsa") Is DBNull.Value Then classe.RisorsaStr = myReader("risorsa")
                        'If Not myReader("Quantita") Is DBNull.Value Then classe.QtaStr = myReader("Quantita")
                        If Not myReader("Incassati") Is DBNull.Value Then classe.Incassati = myReader("Incassati")
                        'If Not myReader("Differenza") Is DBNull.Value Then classe.Differenza = myReader("Differenza")

                        L.Add(classe)
                    End While
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return L


    End Function


    Public Sub AumentaCounterStampe(ByRef R As Ricavo)

        Try
            Dim sql As String
            Using DbCommand As SqlCommand = New SqlCommand()
                DbCommand.Connection = _Cn

                sql = "UPDATE T_ContabRicavi SET CounterStampe = " & R.CounterStampe + 1
                sql &= " WHERE IdRicavo= " & R.IdRicavo

                DbCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then DbCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                DbCommand.ExecuteNonQuery()

                R.CounterStampe += 1
                'End If

            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

    Public Function GetNextNumeroDoc(IdAzienda As Integer,
                                     TipoDoc As enTipoDocumento,
                                     AnnoRif As Integer) As Integer

        If AnnoRif = 0 Then AnnoRif = Now.Year

        Dim ris As Integer = 0
        Dim TipoDocS As String = String.Empty

        Select Case TipoDoc
            Case enTipoDocumento.DDT,
                 enTipoDocumento.Preventivo,
                 enTipoDocumento.NotaDiDebito,
                 enTipoDocumento.AccontoAnticipoSuFattura
                TipoDocS = " = " & TipoDoc
            Case enTipoDocumento.Fattura,
                 enTipoDocumento.FatturaRiepilogativa,
                 enTipoDocumento.NotaDiCredito
                TipoDocS = " IN (" & enTipoDocumento.Fattura & "," & enTipoDocumento.FatturaRiepilogativa & "," & enTipoDocumento.NotaDiCredito & ")"
        End Select

        'Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
        Try
            '        tb.TransactionBegin()
            Using myCommand As Data.Common.DbCommand = _Cn.CreateCommand()
                Dim sql As String = "SELECT MAX(numero) AS prossimo FROM t_contabricavi WHERE Year(dataricavo) = " & AnnoRif & " AND tipo " & TipoDocS & " AND IdAzienda = " & IdAzienda

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    myReader.Read()
                    If myReader.HasRows AndAlso IsDBNull(myReader("prossimo")) = False Then
                        ris = myReader("prossimo")
                    End If
                    ris += 1
                End Using
            End Using
            '       tb.TransactionCommit()

        Catch ex As Exception
            '   tb.TransactionRollBack()
            ManageError(ex)
        End Try
        'End Using


        Return ris

    End Function

    Public Function GetIdConsegnaFromFattura(Anno As Integer,
                                             Numero As Integer,
                                             IdAzienda As Integer) As Integer

        Dim ris As Integer = 0

        Try
            Using myCommand As Data.Common.DbCommand = _Cn.CreateCommand()
                Dim sql As String = "select distinct r.idcons as IdConsegna from Tr_Consord R, T_Ordini O, T_ContabRicavi C "
                sql &= "where o.iddoc = c.idricavo and c.numero = " & Numero & " and c.idazienda = " & IdAzienda & " and year(c.dataricavo) = " & Anno & " and r.idord = o.idord and c.tipo = " & CInt(enTipoDocumento.Fattura)

                myCommand.CommandText = sql
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    myReader.Read()
                    If myReader.HasRows Then
                        ris = myReader("IdConsegna")
                    End If

                End Using
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

        If ris = 0 Then
            'qui vedo se si tratta di una fattura riepilogativa
            Using myCommand As Data.Common.DbCommand = _Cn.CreateCommand()
                Dim sql As String = "select distinct r.idcons as IdConsegna from Tr_Consord R, T_Ordini O, T_ContabRicavi C "
                sql &= " where o.iddoc = c.idricavo and r.idord = o.idord "
                sql &= " And c.iddocrif = (select idricavo from t_contabricavi where numero = " & Numero & " and idazienda = " & IdAzienda & " And year(dataricavo) = " & Anno & " And tipo = " & enTipoDocumento.FatturaRiepilogativa & ") "
                sql &= " order by r.idcons "

                myCommand.CommandText = sql
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    myReader.Read()
                    If myReader.HasRows Then
                        ris = myReader("IdConsegna")
                    End If

                End Using
            End Using

        End If

        Return ris

    End Function

    Public Function CalcolaScopertoMesi() As List(Of ScopertoMese)
        Dim Ris As List(Of ScopertoMese) = New List(Of ScopertoMese)
        'select sum(totale),format(dataprevpagam,"yyyyMM") as Periodo from t_contabricavi
        'where idstato <> 30
        'and tipo <>2
        'group by format(dataprevpagam,"yyyyMM")          
        Using mgr As New RicaviDAO

            Dim l As List(Of Ricavo) = mgr.FindAll(New LUNA.LunaSearchParameter("Tipo", enTipoDocumento.DDT, "<>"),
                                                   New LUNA.LunaSearchParameter("idstato", enStatoDocumentoFiscale.PagatoInteramente, "<>"))
            For Each R As Ricavo In l
                If R.PagatoInteramente = False Then
                    Dim MeseRif As String = R.Dataprevpagam.ToString("yyyyMM")

                    Dim s As ScopertoMese = Ris.Find(Function(x) x.MeseRif = MeseRif)
                    If s Is Nothing Then
                        s = New ScopertoMese
                        s.MeseRif = MeseRif
                        Ris.Add(s)
                    End If

                    s.Scoperto += R.TotaleAncoraDaPagare
                End If
            Next
        End Using

        'Try
        '    Dim myCommand As Data.Common.DbCommand = _Cn.CreateCommand()
        '    Dim sql As String = "Select sum(totale) As tot ,format(dataprevpagam,'yyyyMM') as Periodo from t_contabricavi "
        '    sql &= " where idstato <> " & enStatoDocumentoFiscale.PagatoInteramente
        '    sql &= " and tipo <> " & enTipoDocumento.enTipoDocDDT
        '    sql &= " group by format(dataprevpagam,'yyyyMM')"
        '    sql &= " order by format(dataprevpagam,'yyyyMM')"

        '    myCommand.CommandText = sql
        '    Dim myReader As SqlDataReader = myCommand.ExecuteReader()

        '    While myReader.Read

        '        Dim s As New ScopertoMese
        '        s.MeseRif = myReader("Periodo")
        '        s.Scoperto = myReader("tot")
        '        Ris.Add(s)

        '    End While

        '    myReader.Close()
        '    myCommand.Dispose()

        'Catch ex As Exception
        '    ManageError(ex)
        'End Try

        Return Ris

    End Function

End Class