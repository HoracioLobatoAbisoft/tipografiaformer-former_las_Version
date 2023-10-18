#Region "Author"
'Classe creata con DCFramework
'All rights reserved.
'Author: DC Consultilng srl
'Date: 31/03/2009
#End Region

Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

Public Class cAnnoRif
    Inherits CollectionBase

    Private Sub Add(ByVal Tipo As FormerLib.cEnum)
        InnerList.Add(Tipo)
    End Sub

    Default Public Property item(ByVal index As Integer) As FormerLib.cEnum

        Get
            Return (CType(InnerList.Item(index), FormerLib.cEnum))
        End Get

        Set(ByVal Value As FormerLib.cEnum)
            InnerList.Item(index) = Value
        End Set

    End Property

    Public Sub New()

        Dim mese As FormerLib.cEnum
        Using cn As IDbConnection = LUNA.LunaContext.OldDbConnection
            Using myCommand As SqlCommand = cn.CreateCommand(), dt As New DataTable
                myCommand.CommandText = "SELECT distinct(Year(datacosto))as AnnoRif FROM t_contabcosti UNION SELECT distinct(year(dataricavo)) as AnnoRif FROM t_contabricavi ORDER BY AnnoRif desc"
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()

                    mese = New FormerLib.cEnum
                    mese.Id = 0
                    mese.Descrizione = " - Tutti"
                    Add(mese)

                    mese = New FormerLib.cEnum
                    mese.Id = FormerLib.FormerConst.Fiscali.IdBiennio
                    mese.Descrizione = Now.Year & "-" & (Now.Year - 1)
                    Add(mese)

                    While myReader.Read
                        If Not IsDBNull(myReader("Annorif")) Then
                            mese = New FormerLib.cEnum
                            mese.Id = myReader("Annorif")
                            mese.Descrizione = myReader("Annorif")
                            Add(mese)
                        End If

                    End While
                    'dt.Load(myReader)

                    myReader.Close()
                End Using
            End Using
            cn.Close()
        End Using

    End Sub

End Class

Public Class cMeseRif
    Inherits CollectionBase

    Private Sub Add(ByVal Tipo As FormerLib.cEnum)
        InnerList.Add(Tipo)
    End Sub

    Public Sub New(Optional WithTutti As Boolean = True)

        Dim mese As FormerLib.cEnum

        If WithTutti Then
            mese = New FormerLib.cEnum
            mese.Id = 0
            mese.Descrizione = "Tutti"
            Add(mese)
        End If

        mese = New FormerLib.cEnum
        mese.Id = 1
        mese.Descrizione = "Gennaio"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 2
        mese.Descrizione = "Febbraio"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 3
        mese.Descrizione = "Marzo"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 4
        mese.Descrizione = "Aprile"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 5
        mese.Descrizione = "Maggio"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 6
        mese.Descrizione = "Giugno"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 7
        mese.Descrizione = "Luglio"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 8
        mese.Descrizione = "Agosto"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 9
        mese.Descrizione = "Settembre"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 10
        mese.Descrizione = "Ottobre"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 11
        mese.Descrizione = "Novembre"
        Add(mese)
        mese = New FormerLib.cEnum
        mese.Id = 12
        mese.Descrizione = "Dicembre"
        Add(mese)



    End Sub

    Default Public Property item(ByVal index As Integer) As FormerLib.cEnum

        Get
            Return (CType(InnerList.Item(index), FormerLib.cEnum))
        End Get

        Set(ByVal Value As FormerLib.cEnum)
            InnerList.Item(index) = Value
        End Set

    End Property

End Class

Public Class cTipoVoceContab
    Inherits CollectionBase

    Private Sub Add(ByVal Tipo As FormerLib.cEnum)
        InnerList.Add(Tipo)
    End Sub

    Public Sub New()

        Dim Voce As FormerLib.cEnum

        Voce = New FormerLib.cEnum
        Voce.Id = enTipoVoceContab.VoceAcquisto
        Voce.Descrizione = "Acquisto"
        Add(Voce)

        Voce = New FormerLib.cEnum
        Voce.Id = enTipoVoceContab.VoceVendita
        Voce.Descrizione = "Vendita"
        Add(Voce)

    End Sub

    Default Public Property item(ByVal index As Integer) As FormerLib.cEnum

        Get
            Return (CType(InnerList.Item(index), FormerLib.cEnum))
        End Get

        Set(ByVal Value As FormerLib.cEnum)
            InnerList.Item(index) = Value
        End Set

    End Property

End Class

Public Class cContab
    Inherits _cOldDao

    Public Function ListaSituaz(Optional ByVal IdRub As Integer = 0,
                                Optional ByVal OnlyInCons As Boolean = False,
                                Optional ByVal OnlyNotPayd As Boolean = False,
                                Optional ByVal Scad As Boolean = False,
                                Optional WithDDT As Boolean = False) As DataTable

        Dim datainizio As Date = Now
        Dim myReader As Data.Common.DbDataReader
        Dim datatb As DataTable = New DataTable("T_Contab")
        Try
            'Dim cn2 As SqlConnection
            'cn2 = New SqlConnection("server=" & Postazione.SqlServerName & ";uid=" & Postazione.SqlLogin & ";pwd=" & Postazione.SqlPwd & ";database=" & Postazione.SqlDbName)
            'cn2.Open()
            Dim myCommand As Data.Common.DbCommand = OldDbConnection.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT * from ("
            'sql &= "Select IdCosto as Idrif," & enTipoVoceContab.enTipoVoceFatturaAcquisto & " as TipoVoce,'Uscita - ' & "
            'sql &= "switch(c.tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
            'sql &= "c.tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
            'sql &= "c.tipo=" & enTipoDocumento.enTipoDocFatturaRiepilogativa & ",'Fattura Riepilogativa',"
            'sql &= "c.tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
            'sql &= ")"
            'sql &= " as TipoDoc , DataCosto as DataRif,Numero, RagSoc as Destinatario,Descrizione, Importo,Iva,Totale,0 + (Select sum(importo) from t_pagamenti where idfat= c.idcosto and tipo=" & enTipoVoceContab.enTipoVoceFatturaAcquisto & ") as Incassati,csng(Totale) - csng(0 & incassati) as Differenza,c.Tipo,'' as Fattura,0 as idDocRif  from T_ContabCosti c inner join t_rubrica r on c.idrub=r.idrub "

            'sql &= " where 1=1 "


            'If IdRub Then sql &= " and c.idrub=  " & IdRub

            'sql &= " union "
            sql &= "Select IdRicavo as Idrif," & enTipoVoceContab.VoceVendita & " as TipoVoce,'Vendita - ' + "
            'sql &= "switch(c.tipo=" & enTipoDocumento.enTipoDocFattura & ",'Acquisto',"
            sql &= "(select case c.tipo when " & enTipoDocumento.Fattura & " then 'Fattura' "
            sql &= " when " & enTipoDocumento.Preventivo & " then 'Preventivo'"
            sql &= " when " & enTipoDocumento.NotaDiCredito & " then 'Nota di Credito' "
            sql &= " when " & enTipoDocumento.NotaDiDebito & " then 'Nota di Debito' "
            sql &= " when " & enTipoDocumento.AccontoAnticipoSuFattura & " then 'Acconto/Anticipo su Fattura' "
            sql &= " when " & enTipoDocumento.FatturaRiepilogativa & " then 'Fattura Riepilogativa' "
            sql &= " when " & enTipoDocumento.DDT & " then 'DDT'"
            sql &= " end)"

            'sql &= "switch(c.tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
            'sql &= "c.tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
            'sql &= "c.tipo=" & enTipoDocumento.enTipoDocFatturaRiepilogativa & ",'Fattura Riepilogativa',"
            'sql &= "c.tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
            'sql &= ")"
            'sql &= " as TipoDoc , DataRicavo as DataRif,Numero,dataprevpagam as DaPagareIl, RagSoc as Destinatario,Descrizione, Importo,Iva,Totale,0 + (Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=" & enTipoVoceContab.enTipoVoceFatturaVendita & ") as Incassati,csng(Totale) - csng(0 & incassati) as Differenza,c.tipo,'' as Fattura,IdDocRif   from T_ContabRicavi  c inner join t_rubrica r on c.idrub=r.idrub "
            sql &= " as TipoDoc , DataRicavo as DataRif,Numero,dataprevpagam as DaPagareIl, Totale,isnull((Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=" & enTipoVoceContab.VoceVendita & "),0) as Incassati,round(Totale - Isnull((Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=" & enTipoVoceContab.VoceVendita & "),0),2) as Differenza,c.tipo,'' as Fattura,IdDocRif, c.idazienda   from T_ContabRicavi  c inner join t_rubrica r on c.idrub=r.idrub "
            sql &= " where 1=1 "

            If WithDDT = False Then
                sql &= " and c.tipo <>" & enTipoDocumento.DDT
            Else
                sql &= " and (c.iddocrif = 0 or c.iddocrif is null)"
            End If

            If IdRub Then sql &= " and c.idrub=  " & IdRub

            'Select Case Postazione.AnnoSelezionato
            '    Case 1 '6 mesi
            '        sql &= " and datediff('m',DataRicavo,now) <= 6" ' & Ap(Postazione.AnnoSelezionato)
            '    Case 2 '1 anno
            '        sql &= " and datediff('m',DataRicavo,now) <= 12" ' & Ap(Postazione.AnnoSelezionato)
            'End Select


            'filtro su scaduto o no

            If Scad Then
                sql &= " and datediff(d,dataprevpagam,getdate())>0"
            Else
                sql &= " and datediff(d,dataprevpagam,getdate())<=0"
            End If

            sql &= " "
            sql &= ") as a "

            sql &= " where 1=1 "

            If OnlyNotPayd Then
                sql &= " and Differenza <>0 "

            End If

            If OnlyInCons Then
                sql &= " and idrif in (select distinct iddoc from t_ordini where stato=  " & enStatoOrdine.InConsegna & ")"
            End If

            sql &= " order by idazienda, Datarif " 'desc"
            'sql = "SELECT * from (Select IdRicavo as Idrif,1 as TipoVoce,'Entrata - ' as aaa, DataRicavo as DataRif,Numero,dataprevpagam as DaPagareIl,RagSoc as Destinatario,Descrizione, Importo,Iva,Totale,0 + (Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=1) as Incassati,Totale as Differenza,c.tipo,'' as Fattura,IdDocRif   from T_ContabRicavi  c inner join t_rubrica r on c.idrub=r.idrub   where 1=1  and c.tipo <>2 )as a  where Differenza <>0"

            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = sql
            myReader = myCommand.ExecuteReader()

            datatb.BeginLoadData()
            datatb.Load(myReader)
            datatb.EndLoadData()
            myReader.Close()
            myCommand.Dispose()

            Dim dataFine As Date = Now

            Dim Tempoimpiegato As Long = 0

            Tempoimpiegato = DateDiff(DateInterval.Second, datainizio, dataFine)
            'Stop

        Catch ex As Exception
            OldManageError(ex)
        End Try
        Return datatb

    End Function

    'Public Function Lista(ByVal AnnoRif As String,
    '                      ByVal MeseRif As Integer,
    '                      Optional ByVal IdRub As Integer = 0,
    '                      Optional ByVal TipoDocToShow As enTipoDocumento = 0,
    '                      Optional ByVal OnlyNotPaid As Boolean = False,
    '                      Optional ByVal OnlyNotElapsed As Boolean = False,
    '                      Optional ByVal OnlyInCons As Boolean = False,
    '                      Optional ByVal Entrata As Boolean = True,
    '                      Optional ByVal OnlyDDtInFatt As Boolean = False,
    '                      Optional ByVal Descrizione As String = "",
    '                      Optional ByVal TipoPagamento As Integer = 0,
    '                      Optional ByVal SoloNonStampati As Boolean = False,
    '                      Optional ByVal StatoIncasso As enStatoIncasso = enStatoIncasso.Tutto) As DataTable

    '    Dim datatb As DataTable = New DataTable("T_Contab")
    '    Try

    '        Dim sql As String = "SELECT * FROM ("

    '        sql &= "SELECT IdCosto AS Idrif," & enTipoVoceContab.VoceAcquisto & " AS TipoVoce,"

    '        sql &= "(select case c.tipo when " & enTipoDocumento.Fattura & " then 'Fattura' "
    '        sql &= " when " & enTipoDocumento.Preventivo & " then 'Preventivo' "
    '        sql &= " when " & enTipoDocumento.NotaDiCredito & " then 'Nota di Credito' "
    '        sql &= " when " & enTipoDocumento.NotaDiDebito & " then 'Nota di Debito' "
    '        sql &= " when " & enTipoDocumento.AccontoAnticipoSuFattura & " then 'Acconto/Anticipo su Fattura' "
    '        sql &= " when " & enTipoDocumento.FatturaRiepilogativa & " then 'Fattura Riepilogativa' "
    '        sql &= " when " & enTipoDocumento.DDT & " then 'DDT'"
    '        sql &= " end )"


    '        'sql &= "switch(c.tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
    '        'sql &= "c.tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
    '        'sql &= "c.tipo=" & enTipoDocumento.enTipoDocFatturaRiepilogativa & ",'Fattura Riepilogativa',"
    '        'sql &= "c.tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
    '        'sql &= ")"

    '        sql &= " as TipoDoc , DataCosto as DataRif,Numero, RagSoc as Destinatario,Descrizione, Importo,Iva,Totale,isnull((Select sum(importo) from t_pagamenti where idfat= c.idcosto and tipo=" & enTipoVoceContab.VoceAcquisto & "),0) as Incassati,round(Totale - isnull((Select sum(importo) from t_pagamenti where idfat= c.idcosto and tipo=" & enTipoVoceContab.VoceAcquisto & "),0),2) as Differenza,c.Tipo,'-' as Fattura,0 as idDocRif,DataPrevPagam as DataPagamento, 1 as CounterStampe, 'Normale' as StatoIncasso, 0 as StatoIncassoVal from T_ContabCosti c inner join t_rubrica r on c.idrub=r.idrub "

    '        If Entrata Then
    '            sql &= " where 1=0 "
    '        Else
    '            sql &= " where 1=1 "
    '        End If

    '        If IdRub Then sql &= " and c.idrub=  " & IdRub

    '        If TipoDocToShow Then
    '            sql &= " and  (c.tipo =  " & (TipoDocToShow)
    '            If TipoDocToShow = enTipoDocumento.Fattura Then sql &= " or  c.tipo =  " & (enTipoDocumento.FatturaRiepilogativa) & " or  c.tipo =  " & (enTipoDocumento.AccontoAnticipoSuFattura)
    '            sql &= " ) "
    '        End If

    '        sql &= " union "

    '        sql &= "Select IdRicavo as Idrif," & enTipoVoceContab.VoceVendita & " as TipoVoce,"
    '        sql &= "(select case c.tipo when " & enTipoDocumento.Fattura & " then 'Fattura' "
    '        sql &= " when " & enTipoDocumento.Preventivo & " then 'Preventivo' "
    '        sql &= " when " & enTipoDocumento.NotaDiCredito & " then 'Nota di Credito' "
    '        sql &= " when " & enTipoDocumento.NotaDiDebito & " then 'Nota di Debito' "
    '        sql &= " when " & enTipoDocumento.AccontoAnticipoSuFattura & " then 'Acconto/Anticipo su Fattura' "
    '        sql &= "  when " & enTipoDocumento.FatturaRiepilogativa & " then 'Fattura Riepilogativa' "
    '        sql &= " when " & enTipoDocumento.DDT & " then 'DDT'"
    '        sql &= " end )"
    '        'sql &= "switch(c.tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
    '        'sql &= "c.tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
    '        'sql &= "c.tipo=" & enTipoDocumento.enTipoDocFatturaRiepilogativa & ",'Fattura Riepilogativa',"
    '        'sql &= "c.tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
    '        'sql &= ")"
    '        sql &= " as TipoDoc , DataRicavo as DataRif, Numero, RagSoc as Destinatario,Descrizione, Importo,Iva,Totale,isnull((Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=" & enTipoVoceContab.VoceVendita & "),0) as Incassati,round(Totale - isnull((Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=" & enTipoVoceContab.VoceVendita & "),0),2) as Differenza,c.tipo,'-' as Fattura,IdDocRif,DataPrevPagam as DataPagamento, CounterStampe, "

    '        sql &= "(select case c.statoincasso when " & enStatoIncasso.Normale & " then '" & FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Normale) & "' "
    '        sql &= " when " & enStatoIncasso.Problematico & " then '" & FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Problematico) & "' "
    '        sql &= "  when " & enStatoIncasso.Difficile & " then '" & FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Difficile) & "' "
    '        sql &= " when " & enStatoIncasso.Impossibile & " then '" & FormerEnumHelper.GetStatoIncassoStr(enStatoIncasso.Impossibile) & "'"
    '        sql &= " end ) as StatoIncasso, c.statoincasso as StatoIncassoVal "

    '        sql &= "from T_ContabRicavi  c inner join t_rubrica r on c.idrub=r.idrub "

    '        If Entrata Then
    '            sql &= " where 1=1 "
    '        Else
    '            sql &= " where 1=0 "
    '        End If
    '        If IdRub Then sql &= " and c.idrub=  " & IdRub

    '        If TipoPagamento Then
    '            sql &= " and c.Idpagamento = " & TipoPagamento
    '        End If

    '        If TipoDocToShow Then
    '            sql &= " and  (c.tipo =  " & (TipoDocToShow)
    '            If TipoDocToShow = enTipoDocumento.Fattura Then sql &= " or c.tipo =  " & (enTipoDocumento.FatturaRiepilogativa)
    '            sql &= " ) "
    '            If TipoDocToShow = enTipoDocumento.DDT Then
    '                If OnlyDDtInFatt Then
    '                    sql &= " and c.iddocrif<>0"
    '                Else
    '                    sql &= " and (c.iddocrif=0 or c.iddocrif is null) "
    '                End If
    '            End If
    '        End If

    '        sql &= ") as a "

    '        sql &= " where 1=1 "

    '        If AnnoRif.TrimStart(" ") <> "- Tutti" Then
    '            sql &= "and year(datarif) =  " & Ap(AnnoRif)
    '        End If

    '        If MeseRif Then
    '            sql &= " and  month(datarif) =  " & (MeseRif)
    '        End If

    '        If OnlyNotPaid Then
    '            sql &= " and Differenza <> 0 "
    '        End If

    '        If OnlyInCons Then
    '            sql &= " and idrif in (select distinct iddoc from t_ordini where stato=" & enStatoOrdine.InConsegna & ")"
    '        End If

    '        If Descrizione.Length Then
    '            sql &= " and (descrizione " & ApLike(Descrizione) & " OR Numero " & ApLike(Descrizione) & ")"
    '        End If

    '        If SoloNonStampati Then
    '            sql &= " and CounterStampe = 0 "
    '        End If

    '        If StatoIncasso <> enStatoIncasso.Tutto Then
    '            sql &= " and StatoIncassoVal = " & StatoIncasso
    '        End If

    '        sql &= " order by Datarif desc ,Numero desc "
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '            myCommand.CommandText = sql
    '            Using myReader As SqlDataReader = myCommand.ExecuteReader()
    '                datatb.Load(myReader)
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return datatb

    'End Function

    'Public Function ToTRicavi(ByVal AnnoRif As String, ByVal MeseRif As Integer, Optional ByVal IdRub As Integer = 0) As Double

    '    ' Dim datatb As DataTable = New DataTable("T_Contab")
    '    Dim Ris As Double = 0
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "Select sum(Importo) as totale from T_ContabRicavi "

    '        sql &= "where year(dataricavo) =  " & Ap(AnnoRif)

    '        If MeseRif Then
    '            sql &= " and  month(dataricavo) =  " & (MeseRif)
    '        End If

    '        If IdRub Then sql &= " and idrub=  " & IdRub


    '        'sql &= " order by DataRif desc"
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        myCommand.CommandText = sql
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        myReader.Read()

    '        If myReader.HasRows Then
    '            If myReader("totale").ToString.Length Then Ris = myReader("Totale").ToString
    '        End If

    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return Ris

    'End Function

    'Public Function ToTCosti(ByVal AnnoRif As String, ByVal MeseRif As Integer, Optional ByVal IdRub As Integer = 0) As Double

    '    ' Dim datatb As DataTable = New DataTable("T_Contab")
    '    Dim Ris As Double = 0
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "Select sum(Importo) as totale from T_ContabCosti "

    '        sql &= "where year(datacosto) = " & Ap(AnnoRif)

    '        If MeseRif Then
    '            sql &= " and  month(datacosto) = " & (MeseRif)
    '        End If

    '        If IdRub Then sql &= " and idrub=  " & IdRub

    '        'sql &= " order by DataRif desc"
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        myCommand.CommandText = sql
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        myReader.Read()
    '        If myReader.HasRows Then
    '            If myReader("totale").ToString.Length Then Ris = myReader("Totale").ToString
    '        End If
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return Ris

    'End Function

    'Public Function ToTIvaCredito(ByVal AnnoRif As String, ByVal MeseRif As Integer, Optional ByVal IdRub As Integer = 0) As Double

    '    ' Dim datatb As DataTable = New DataTable("T_Contab")
    '    Dim Ris As Double = 0
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "Select sum(Iva) as totale from T_ContabCosti "

    '        sql &= "where year(datacosto) =  " & Ap(AnnoRif)

    '        If MeseRif Then
    '            sql &= " and  month(datacosto) =  " & (MeseRif)
    '        End If

    '        If IdRub Then sql &= " and idrub=  " & IdRub

    '        'sql &= " order by DataRif desc"
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        myCommand.CommandText = sql
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        myReader.Read()
    '        If myReader.HasRows Then
    '            If myReader("totale").ToString.Length Then Ris = myReader("Totale").ToString
    '        End If
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return Ris

    'End Function

    'Public Function ToTIvaDebito(ByVal AnnoRif As String, ByVal MeseRif As Integer, Optional ByVal IdRub As Integer = 0) As Double

    '    ' Dim datatb As DataTable = New DataTable("T_Contab")
    '    Dim Ris As Double = 0
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "Select sum(Iva) as totale from T_ContabRicavi "

    '        sql &= "where year(dataricavo) =  " & Ap(AnnoRif)

    '        If MeseRif Then
    '            sql &= " and  month(dataricavo) =  " & (MeseRif)
    '        End If

    '        If IdRub Then sql &= " and idrub=  " & IdRub

    '        'sql &= " order by DataRif desc"
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        myCommand.CommandText = sql
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        myReader.Read()
    '        If myReader.HasRows Then
    '            If myReader("totale").ToString.Length Then Ris = myReader("Totale").ToString
    '        End If
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex)
    '    End Try
    '    Return Ris

    'End Function

End Class

'Public Class cContabCosti
'    Inherits _cOldDao
'#Region "Property"

'    Private _IdCosto As Integer
'    Public Property IdCosto() As Integer
'        Get
'            Return _IdCosto
'        End Get
'        Set(ByVal value As Integer)
'            _IdCosto = value
'        End Set
'    End Property

'    Private _IdDocRif As Integer
'    Public Property IdDocRif() As Integer
'        Get
'            Return _IdDocRif
'        End Get
'        Set(ByVal value As Integer)
'            _IdDocRif = value
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

'    Private _IdCat As Integer
'    Public Property IdCat() As Integer
'        Get
'            Return _IdCat
'        End Get
'        Set(ByVal value As Integer)
'            _IdCat = value
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

'    Private _Numero As String
'    Public Property Numero() As String
'        Get
'            Return _Numero
'        End Get
'        Set(ByVal value As String)
'            _Numero = value
'        End Set
'    End Property

'    Private _DataCosto As DateTime
'    Public Property DataCosto() As DateTime
'        Get
'            Return _DataCosto
'        End Get
'        Set(ByVal value As DateTime)
'            _DataCosto = value
'        End Set
'    End Property
'    Private _DataPrevPagam As DateTime
'    Public Property DataPrevPagam() As DateTime
'        Get
'            Return _DataPrevPagam
'        End Get
'        Set(ByVal value As DateTime)
'            _DataPrevPagam = value
'        End Set
'    End Property


'    'Public Function Intestazione() As String

'    '    'Dim Intest As String = _pRagSoc & " (" & _IdRub & ")" & vbNewLine
'    '    'Intest &= _pIndirizzo & vbNewLine
'    '    'Intest &= _pCitta & vbNewLine
'    '    'Intest &= _pCap & vbNewLine
'    '    'Intest &= "P.IVA " & _pIva & vbNewLine
'    '    'Intest &= "Ind.Cons. " & _pIndCons & vbNewLine
'    '    'Intest &= "Pagamento " & _pPagamento & vbNewLine

'    '    Dim Intest As String = ""
'    '    Return Intest
'    'End Function

'    Public Property DataRif() As DateTime
'        Get
'            Return _DataCosto
'        End Get
'        Set(ByVal value As DateTime)
'            _DataCosto = value
'        End Set
'    End Property


'    Public ReadOnly Property TipoVoce() As String
'        Get
'            Return "Uscita"
'        End Get
'    End Property

'    Public ReadOnly Property IdTipoVoce() As enTipoVoceContab
'        Get
'            Return enTipoVoceContab.VoceAcquisto
'        End Get
'    End Property

'    Private _Scansione As String = ""
'    Public Property Scansione() As String
'        Get
'            Return _Scansione
'        End Get
'        Set(ByVal value As String)
'            _Scansione = value
'        End Set
'    End Property

'    Private _Tipo As enTipoDocumento = enTipoDocumento.Fattura
'    Public Property Tipo() As enTipoDocumento
'        Get
'            Return _Tipo
'        End Get
'        Set(ByVal value As enTipoDocumento)
'            _Tipo = value
'        End Set
'    End Property

'    Private _Scansione1 As String = ""
'    Public Property Scansione1() As String
'        Get
'            Return _Scansione1
'        End Get
'        Set(ByVal value As String)
'            _Scansione1 = value
'        End Set
'    End Property


'    Private _Scansione2 As String = ""
'    Public Property Scansione2() As String
'        Get
'            Return _Scansione2
'        End Get
'        Set(ByVal value As String)
'            _Scansione2 = value
'        End Set
'    End Property


'    Private _Scansione3 As String = ""
'    Public Property Scansione3() As String
'        Get
'            Return _Scansione3
'        End Get
'        Set(ByVal value As String)
'            _Scansione3 = value
'        End Set
'    End Property


'    Private _Scansione4 As String = ""
'    Public Property Scansione4() As String
'        Get
'            Return _Scansione4
'        End Get
'        Set(ByVal value As String)
'            _Scansione4 = value
'        End Set
'    End Property



'    Private _PercIva As Integer
'    Public Property PercIva() As Integer
'        Get
'            Return _PercIva
'        End Get
'        Set(ByVal value As Integer)
'            _PercIva = value
'        End Set
'    End Property

'    Private _Iva As Single
'    Public Property Iva() As Single
'        Get
'            Return _Iva
'        End Get
'        Set(ByVal value As Single)
'            _Iva = value
'        End Set
'    End Property

'    Private _Totale As Double
'    Public Property Totale() As Double
'        Get
'            Return _Totale
'        End Get
'        Set(ByVal value As Double)
'            _Totale = value
'        End Set
'    End Property

'    Private _pRagSoc As String = ""
'    Public Property pRagSoc() As String
'        Get
'            Return _pRagSoc
'        End Get
'        Set(ByVal value As String)
'            _pRagSoc = value
'        End Set
'    End Property

'    Private _pIndirizzo As String = ""
'    Public Property pIndirizzo() As String
'        Get
'            Return _pIndirizzo
'        End Get
'        Set(ByVal value As String)
'            _pIndirizzo = value
'        End Set
'    End Property

'    Private _pIndCons As String = ""
'    Public Property pIndCons() As String
'        Get
'            Return _pIndCons
'        End Get
'        Set(ByVal value As String)
'            _pIndCons = value
'        End Set
'    End Property
'    Private _pPagamento As String = ""
'    Public Property pPagamento() As String
'        Get
'            Return _pPagamento
'        End Get
'        Set(ByVal value As String)
'            _pPagamento = value
'        End Set
'    End Property

'    Private _pCitta As String = ""
'    Public Property pCitta() As String
'        Get
'            Return _pCitta
'        End Get
'        Set(ByVal value As String)
'            _pCitta = value
'        End Set
'    End Property

'    Private _pCap As String = ""
'    Public Property pCap() As String
'        Get
'            Return _pCap
'        End Get
'        Set(ByVal value As String)
'            _pCap = value
'        End Set
'    End Property

'    Private _pIva As String = ""
'    Public Property pIva() As String
'        Get
'            Return _pIva
'        End Get
'        Set(ByVal value As String)
'            _pIva = value
'        End Set
'    End Property

'#End Region


'#Region "Method"
'    Public Function Read(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0

'        Try
'            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM T_ContabCosti where IdCosto = " & Id
'            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdCosto = myReader("IdCosto")
'                If Not myReader("Descrizione") Is DBNull.Value Then
'                    _Descrizione = myReader("Descrizione").ToString
'                End If
'                If Not myReader("Importo") Is DBNull.Value Then
'                    _Importo = myReader("Importo").ToString
'                End If
'                If Not myReader("IdCat") Is DBNull.Value Then
'                    _IdCat = myReader("IdCat").ToString
'                End If
'                If Not myReader("IdRub") Is DBNull.Value Then
'                    _IdRub = myReader("IdRub").ToString
'                End If
'                If Not myReader("Tipo") Is DBNull.Value Then
'                    _Tipo = myReader("Tipo").ToString
'                End If
'                If Not myReader("Numero") Is DBNull.Value Then
'                    _Numero = myReader("Numero").ToString
'                End If
'                If Not myReader("DataCosto") Is DBNull.Value Then
'                    _DataCosto = myReader("DataCosto").ToString
'                End If
'                If Not myReader("DataPrevpagam") Is DBNull.Value Then
'                    _DataPrevPagam = myReader("DataPrevpagam").ToString
'                End If
'                If Not myReader("Scansione") Is DBNull.Value Then
'                    _Scansione = myReader("Scansione").ToString
'                End If
'                If Not myReader("Scansione1") Is DBNull.Value Then
'                    _Scansione1 = myReader("Scansione1").ToString
'                End If
'                If Not myReader("Scansione2") Is DBNull.Value Then
'                    _Scansione2 = myReader("Scansione2").ToString
'                End If
'                If Not myReader("Scansione3") Is DBNull.Value Then
'                    _Scansione3 = myReader("Scansione3").ToString
'                End If
'                If Not myReader("Scansione4") Is DBNull.Value Then
'                    _Scansione4 = myReader("Scansione4").ToString
'                End If

'                If Not myReader("PercIva") Is DBNull.Value Then
'                    _PercIva = myReader("PercIva").ToString
'                End If
'                If Not myReader("Iva") Is DBNull.Value Then
'                    _Iva = myReader("Iva").ToString
'                End If
'                If Not myReader("Totale") Is DBNull.Value Then
'                    _Totale = myReader("Totale").ToString
'                End If
'            Else
'                Ris = 1
'            End If
'            myReader.Close()
'            myCommand.Dispose()

'        Catch ex As Exception
'            OldManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'    Public Function Save(Optional ByRef IdInserito As Integer = 0) As Integer

'        Dim Ris As Integer = 0

'        Try
'            Dim sql As String
'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = OldDbConnection
'            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'            If _IdCosto = 0 Then
'                sql = "INSERT INTO T_ContabCosti("
'                sql &= "Descrizione,"
'                sql &= "Importo,"
'                sql &= "IdCat,"
'                sql &= "IdRub,"
'                sql &= "Tipo,"
'                sql &= "Numero,"
'                sql &= "DataCosto,"
'                sql &= "DataPrevPagam,"
'                sql &= "Scansione,"
'                sql &= "Scansione1,"
'                sql &= "Scansione2,"
'                sql &= "Scansione3,"
'                sql &= "Scansione4,"
'                sql &= "PercIva,"
'                sql &= "Iva,"
'                sql &= "Totale"
'                sql &= ") VALUES ("
'                sql &= Ap(_Descrizione) & ","
'                sql &= Ap(_Importo) & ","
'                sql &= _IdCat & ","
'                sql &= _IdRub & ","
'                sql &= _Tipo & ","
'                sql &= _Numero & ","
'                sql &= Ap(_DataCosto) & ","
'                sql &= Ap(_DataPrevPagam) & ","
'                sql &= Ap(_Scansione) & ","
'                sql &= Ap(_Scansione1) & ","
'                sql &= Ap(_Scansione2) & ","
'                sql &= Ap(_Scansione3) & ","
'                sql &= Ap(_Scansione4) & ","
'                sql &= _PercIva & ","
'                sql &= Ap(_Iva) & ","
'                sql &= Ap(_Totale)
'                sql &= ")"
'            Else
'                sql = "UPDATE T_ContabCosti SET "
'                sql &= "Descrizione = " & Ap(_Descrizione) & ","
'                sql &= "Importo = " & Ap(_Importo) & ","
'                sql &= "IdCat = " & _IdCat & ","
'                sql &= "IdRub = " & _IdRub & ","
'                sql &= "Tipo= " & _Tipo & ","
'                sql &= "Numero = " & _Numero & ","
'                sql &= "DataCosto = " & Ap(_DataCosto) & ","
'                sql &= "DataPrevPagam = " & Ap(_DataPrevPagam) & ","
'                sql &= "Scansione = " & Ap(_Scansione) & ","
'                sql &= "Scansione1 = " & Ap(_Scansione1) & ","
'                sql &= "Scansione2 = " & Ap(_Scansione2) & ","
'                sql &= "Scansione3 = " & Ap(_Scansione3) & ","
'                sql &= "Scansione4 = " & Ap(_Scansione4) & ","
'                sql &= "PercIva = " & _PercIva & ","
'                sql &= "Iva = " & Ap(_Iva) & ","
'                sql &= "Totale = " & Ap(_Totale)
'                sql &= " WHERE IdCosto= " & _IdCosto
'            End If
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IdCosto = 0 Then
'                sql = "select @@identity"
'                myCommand.CommandText = sql
'                IdInserito = myCommand.ExecuteScalar()
'                _IdCosto = IdInserito
'            End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            OldManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'#End Region

'End Class

Public Class cContabCostiColl
    Inherits _cOldDao
    'Public Function Lista() As DataTable
    '    Dim datatb As DataTable = New DataTable("T_ContabCosti")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT IdCosto,Descrizione,Importo,IdCat,DataCosto,Scansione,PercIva,Iva from T_ContabCosti"
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

    'Public Function ListaCombo(ByVal IdRub As Integer) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_ContabCosti")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        Dim sql As String = ""
    '        sql = "SELECT IdRicavo as IdFat,DataRicavo as DataRif,"

    '        sql &= "(select case tipo when " & enTipoDocumento.enTipoDocFattura & " then 'Fattura' "
    '        sql &= " when " & enTipoDocumento.enTipoDocPreventivo & " then 'Preventivo' "
    '        sql &= " when " & enTipoDocumento.enTipoDocDDT & " then 'DDT' "
    '        sql &= ") + ' ' +"
    '        sql &= " DataRicavo + ' - ' + Descrizione + ' -  €' + Totale as Descr from T_ContabCosti "

    '        'sql &= "switch(tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
    '        'sql &= "tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
    '        'sql &= "tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
    '        'sql &= ") & ' ' &"
    '        'sql &= "DataRicavo & ' - ' & Descrizione & ' -  €' & Totale as Descr from T_ContabCosti "

    '        sql &= " where idrub = " & IdRub


    '        'sql &= " union SELECT IdCosto as IdFat,DataCosto as DataRif,"

    '        'sql &= "switch(tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
    '        'sql &= "tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
    '        'sql &= "tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
    '        'sql &= ") & ' ' &"

    '        'sql &= " DataCosto & ' - ' & Descrizione & ' -  €' & Totale as Descr from T_ContabCosti "

    '        'sql &= " where idrub = " & IdRub


    '        'sql &= ")"

    '        sql &= " order by DataRicavo desc"
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

    Public Function ListaComboSpese(ByVal IdRub As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_ContabCosti")
        Try

            Dim sql As String = ""
            'sql = "SELECT IdRicavo as IdFat,DataRicavo as DataRif,"

            'sql &= "switch(tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
            'sql &= "tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
            'sql &= "tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
            'sql &= ") & ' ' &"

            'sql &= "DataRicavo & ' - ' & Descrizione & ' -  €' & Totale as Descr from T_ContabCosti "


            'sql &= " where idrub = " & IdRub


            sql &= "SELECT IdCosto as IdFat,DataCosto as DataRif,"


            sql &= "(select case tipo when " & enTipoDocumento.Fattura & " then 'Fattura' "
            sql &= " when " & enTipoDocumento.Preventivo & " then 'Preventivo' "
            sql &= " when " & enTipoDocumento.NotaDiCredito & " then 'Nota di Credito' "
            sql &= " when " & enTipoDocumento.NotaDiDebito & " then 'Nota di Debito' "
            sql &= " when " & enTipoDocumento.AccontoAnticipoSuFattura & " then 'Acconto/Anticipo su Fattura' "
            sql &= " when " & enTipoDocumento.DDT & " then 'DDT' "
            sql &= "end ) + ' ' +"
            sql &= " convert(varchar,DataCosto,103) + ' - ' + Descrizione + ' -  €' + convert(varchar,Totale) as Descr from T_ContabCosti "

            'sql &= "switch(tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
            'sql &= "tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
            'sql &= "tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
            'sql &= ") & ' ' &"

            'sql &= " DataCosto & ' - ' & Descrizione & ' -  €' & Totale as Descr from T_ContabCosti "

            sql &= " where idrub = " & IdRub


            'sql &= ")"

            sql &= " order by DataCosto desc"

            Using myCommand As SqlCommand = OldDbConnection.CreateCommand()

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

    Public Function Delete(ByVal Id As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = OldDbConnection
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "DELETE FROM T_ContabCosti"
                Sql &= " WHERE IdCosto = " & Id
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

Public Class cContabRicavi
    Inherits _cOldDao

#Region "Property"

    Private _IdRicavo As Integer
    Public Property IdRicavo() As Integer
        Get
            Return _IdRicavo
        End Get
        Set(ByVal value As Integer)
            _IdRicavo = value
        End Set
    End Property

    Private _Descrizione As String = ""
    Public Property Descrizione() As String
        Get
            Return _Descrizione
        End Get
        Set(ByVal value As String)
            _Descrizione = value
        End Set
    End Property

    Private _Importo As Decimal
    Public Property Importo() As Decimal
        Get
            Return _Importo
        End Get
        Set(ByVal value As Decimal)
            _Importo = value
        End Set
    End Property

    Private _Numero As Integer
    Public Property Numero() As Integer
        Get
            Return _Numero
        End Get
        Set(ByVal value As Integer)
            _Numero = value
        End Set
    End Property

    Private _Tipo As enTipoDocumento = enTipoDocumento.Fattura
    Public Property Tipo() As enTipoDocumento
        Get
            Return _Tipo
        End Get
        Set(ByVal value As enTipoDocumento)
            _Tipo = value
        End Set
    End Property

    Public ReadOnly Property TipoStringa() As String
        Get
            Dim Ris As String = String.Empty
            Select Case _Tipo
                Case enTipoDocumento.DDT
                    Ris = "D.D.T."
                Case enTipoDocumento.Fattura
                    Ris = "Fattura"
                Case enTipoDocumento.FatturaRiepilogativa
                    Ris = "Fattura"
                Case enTipoDocumento.Preventivo
                    Ris = "Preventivo"
                Case enTipoDocumento.NotaDiCredito
                    Ris = "Nota di Credito"
                Case enTipoDocumento.NotaDiDebito
                    Ris = "Nota di Debito"
                Case enTipoDocumento.AccontoAnticipoSuFattura
                    Ris = "Acconto/Anticipo su Fattura"
            End Select
            Return Ris
        End Get
    End Property

    Private _IdCat As Integer
    Public Property IdCat() As Integer
        Get
            Return _IdCat
        End Get
        Set(ByVal value As Integer)
            _IdCat = value
        End Set
    End Property

    Private _DataRicavo As DateTime
    Public Property DataRicavo() As DateTime
        Get
            Return _DataRicavo
        End Get
        Set(ByVal value As DateTime)
            _DataRicavo = value
        End Set
    End Property
    Public Property DataRif() As DateTime
        Get
            Return _DataRicavo
        End Get
        Set(ByVal value As DateTime)
            _DataRicavo = value
        End Set
    End Property
    Private _DataPrevPagam As DateTime
    Public Property DataPrevPagam() As DateTime
        Get
            Return _DataPrevPagam
        End Get
        Set(ByVal value As DateTime)
            _DataPrevPagam = value
        End Set
    End Property

    Public ReadOnly Property TipoVoce() As String
        Get
            Return "Entrata"
        End Get
    End Property

    Public ReadOnly Property PagataCompletamente() As Boolean
        Get
            'qui calcolo se e' stata pagata completamente
            Dim Ris As Boolean = False

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            myCommand.CommandText = "SELECT sum(importo) as ris FROM T_Pagamenti where IdFat = " & _IdRicavo
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            myReader.Read()
            Dim TotalePagato As Decimal = 0
            Try
                TotalePagato = myReader("ris")
            Catch ex As Exception

            End Try


            If FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotalePagato, 2) = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(_Totale, 2) Then Ris = True

            Return Ris

        End Get
    End Property

    Public ReadOnly Property IdTipoVoce() As enTipoVoceContab
        Get
            Return enTipoVoceContab.VoceVendita
        End Get
    End Property

    Private _IdRub As Integer
    Public Property IdRub() As Integer
        Get
            Return _IdRub
        End Get
        Set(ByVal value As Integer)
            _IdRub = value
        End Set
    End Property
    Private _IdDocRif As Integer
    Public Property IdDocRif() As Integer
        Get
            Return _IdDocRif
        End Get
        Set(ByVal value As Integer)
            _IdDocRif = value
        End Set
    End Property

    Private _Scansione As String = ""
    Public Property Scansione() As String
        Get
            Return _Scansione
        End Get
        Set(ByVal value As String)
            _Scansione = value
        End Set
    End Property


    Private _Scansione1 As String = ""
    Public Property Scansione1() As String
        Get
            Return _Scansione1
        End Get
        Set(ByVal value As String)
            _Scansione1 = value
        End Set
    End Property


    Private _Scansione2 As String = ""
    Public Property Scansione2() As String
        Get
            Return _Scansione2
        End Get
        Set(ByVal value As String)
            _Scansione2 = value
        End Set
    End Property


    Private _Scansione3 As String = ""
    Public Property Scansione3() As String
        Get
            Return _Scansione3
        End Get
        Set(ByVal value As String)
            _Scansione3 = value
        End Set
    End Property


    Private _Scansione4 As String = ""
    Public Property Scansione4() As String
        Get
            Return _Scansione4
        End Get
        Set(ByVal value As String)
            _Scansione4 = value
        End Set
    End Property


    Private _PercIva As Integer
    Public Property PercIva() As Integer
        Get
            Return _PercIva
        End Get
        Set(ByVal value As Integer)
            _PercIva = value
        End Set
    End Property

    Private _Iva As Single
    Public Property Iva() As Single
        Get

            Return _Iva
        End Get
        Set(ByVal value As Single)
            _Iva = value
        End Set
    End Property

    Private _IdCorr As Integer = 0
    Public Property IdCorr() As Integer
        Get
            Return _IdCorr
        End Get
        Set(ByVal value As Integer)
            _IdCorr = value
        End Set
    End Property

    Private _CostoCorr As Single
    Public Property CostoCorr() As Single
        Get
            Return _CostoCorr
        End Get
        Set(ByVal value As Single)
            _CostoCorr = value
        End Set
    End Property

    Private _Totale As Double
    Public Property Totale() As Double
        Get
            Return _Totale
        End Get
        Set(ByVal value As Double)
            _Totale = value
        End Set
    End Property

    Private _pRagSoc As String = ""
    Public Property pRagSoc() As String
        Get
            Return _pRagSoc
        End Get
        Set(ByVal value As String)
            _pRagSoc = value
        End Set
    End Property

    Private _pIndirizzo As String = ""
    Public Property pIndirizzo() As String
        Get
            Return _pIndirizzo
        End Get
        Set(ByVal value As String)
            _pIndirizzo = value
        End Set
    End Property

    Private _pIndCons As String = ""
    Public Property pIndCons() As String
        Get
            Return _pIndCons
        End Get
        Set(ByVal value As String)
            _pIndCons = value
        End Set
    End Property
    Private _pPagamento As String = ""
    Public Property pPagamento() As String
        Get
            Return _pPagamento
        End Get
        Set(ByVal value As String)
            _pPagamento = value
        End Set
    End Property

    Private _pCitta As String = ""
    Public Property pCitta() As String
        Get
            Return _pCitta
        End Get
        Set(ByVal value As String)
            _pCitta = value
        End Set
    End Property

    Private _pCap As String = ""
    Public Property pCap() As String
        Get
            Return _pCap
        End Get
        Set(ByVal value As String)
            _pCap = value
        End Set
    End Property

    Private _pIva As String = ""
    Public Property pIva() As String
        Get
            Return _pIva
        End Get
        Set(ByVal value As String)
            _pIva = value
        End Set
    End Property

    Private _NumColli As Integer = 0
    Public Property NumColli() As Integer
        Get
            Return _NumColli
        End Get
        Set(ByVal value As Integer)
            _NumColli = value
        End Set
    End Property

    Private _Peso As Single
    Public Property Peso() As Single
        Get
            Return _Peso
        End Get
        Set(ByVal value As Single)
            _Peso = value
        End Set
    End Property

    Private _IdPagamento As Integer = 0
    Public Property IdPagamento() As Integer
        Get
            Return _IdPagamento
        End Get
        Set(ByVal value As Integer)
            _IdPagamento = value
        End Set
    End Property

#End Region

#Region "Method"
    Public Function Read(ByVal Id As Integer) As Integer
        Dim Ris As Integer = 0

        Try
            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            myCommand.CommandText = "SELECT * FROM T_ContabRicavi WHERE IdRicavo = " & Id
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            myReader.Read()
            If myReader.HasRows Then
                _IdRicavo = myReader("IdRicavo")
                If Not myReader("Descrizione") Is DBNull.Value Then
                    _Descrizione = myReader("Descrizione").ToString
                End If
                If Not myReader("Importo") Is DBNull.Value Then
                    _Importo = myReader("Importo").ToString
                End If
                If Not myReader("IdCat") Is DBNull.Value Then
                    _IdCat = myReader("IdCat").ToString
                End If
                If Not myReader("IdRub") Is DBNull.Value Then
                    _IdRub = myReader("IdRub").ToString
                End If
                If Not myReader("Tipo") Is DBNull.Value Then
                    _Tipo = myReader("Tipo").ToString
                End If
                If Not myReader("Numero") Is DBNull.Value Then
                    _Numero = myReader("Numero").ToString
                End If
                If Not myReader("DataRicavo") Is DBNull.Value Then
                    _DataRicavo = myReader("DataRicavo").ToString
                End If
                If Not myReader("DataPrevPagam") Is DBNull.Value Then
                    _DataPrevPagam = myReader("DataPrevPagam").ToString
                End If
                If Not myReader("Scansione") Is DBNull.Value Then
                    _Scansione = myReader("Scansione").ToString
                End If
                If Not myReader("Scansione1") Is DBNull.Value Then
                    _Scansione1 = myReader("Scansione1").ToString
                End If
                If Not myReader("Scansione2") Is DBNull.Value Then
                    _Scansione2 = myReader("Scansione2").ToString
                End If
                If Not myReader("Scansione3") Is DBNull.Value Then
                    _Scansione3 = myReader("Scansione3").ToString
                End If
                If Not myReader("Scansione4") Is DBNull.Value Then
                    _Scansione4 = myReader("Scansione4").ToString
                End If
                If Not myReader("PercIva") Is DBNull.Value Then
                    _PercIva = myReader("PercIva").ToString
                End If
                If Not myReader("Iva") Is DBNull.Value Then
                    _Iva = myReader("Iva").ToString
                End If
                If Not myReader("IdCorr") Is DBNull.Value Then
                    _IdCorr = myReader("IdCorr").ToString
                End If
                If Not myReader("CostoCorr") Is DBNull.Value Then
                    _CostoCorr = myReader("CostoCorr").ToString
                End If
                If Not myReader("Totale") Is DBNull.Value Then
                    _Totale = myReader("Totale").ToString
                End If
                If Not myReader("pRagSoc") Is DBNull.Value Then
                    _pRagSoc = myReader("pRagSoc").ToString
                End If
                If Not myReader("pIndirizzo") Is DBNull.Value Then
                    _pIndirizzo = myReader("pIndirizzo").ToString
                End If
                If Not myReader("pIndCons") Is DBNull.Value Then
                    _pIndCons = myReader("pIndCons").ToString
                End If
                If Not myReader("pCitta") Is DBNull.Value Then
                    _pCitta = myReader("pCitta").ToString
                End If
                If Not myReader("pCap") Is DBNull.Value Then
                    _pCap = myReader("pCap").ToString
                End If
                If Not myReader("pPagamento") Is DBNull.Value Then
                    _pPagamento = myReader("pPagamento").ToString
                End If
                If Not myReader("pIva") Is DBNull.Value Then
                    _pIva = myReader("pIva").ToString
                End If
                If Not myReader("NumColli") Is DBNull.Value Then
                    _NumColli = myReader("NumColli").ToString
                End If
                If Not myReader("Peso") Is DBNull.Value Then
                    _Peso = myReader("Peso").ToString
                End If
                If Not myReader("IdDocRif") Is DBNull.Value Then
                    _IdDocRif = myReader("IdDocRif").ToString
                End If

                If Not myReader("IdPagamento") Is DBNull.Value Then
                    _IdPagamento = myReader("IdPagamento").ToString
                End If
            Else
                Ris = 1
            End If
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            OldManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    'Public Function Intestazione() As String

    '    Dim Intest As String = _pRagSoc & " (" & _IdRub & ")" & vbNewLine
    '    Intest &= _pIndirizzo & vbNewLine
    '    Intest &= _pCitta & vbNewLine
    '    Intest &= _pCap & vbNewLine
    '    Intest &= "P.IVA " & _pIva & vbNewLine
    '    Intest &= "Ind.Cons. " & _pIndCons & vbNewLine
    '    Intest &= "Pagamento " & _pPagamento & vbNewLine
    '    Return Intest
    'End Function

    'Public Function Save(Optional ByRef IdInserito As Integer = 0) As Integer

    '    Dim Ris As Integer = 0

    '    Try
    '        Dim sql As String
    '        Dim myCommand As SqlCommand = New SqlCommand()
    '        myCommand.Connection = OldDbConnection
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        If _IdRicavo = 0 Then
    '            sql = "INSERT INTO T_ContabRicavi("
    '            sql &= "Descrizione,"
    '            sql &= "Importo,"
    '            sql &= "IdCat,"
    '            sql &= "IdRub,"
    '            sql &= "Tipo,"
    '            sql &= "Numero,"
    '            sql &= "DataRicavo,"
    '            sql &= "DataPrevPagam,"
    '            sql &= "Scansione,"
    '            sql &= "Scansione1,"
    '            sql &= "Scansione2,"
    '            sql &= "Scansione3,"
    '            sql &= "Scansione4,"
    '            sql &= "PercIva,"
    '            sql &= "Iva,"
    '            sql &= "IdCorr,"
    '            sql &= "CostoCorr,"
    '            sql &= "Totale,"
    '            sql &= "pRagSoc,"
    '            sql &= "pIndirizzo,"
    '            sql &= "pIndCons,"
    '            sql &= "pCitta,"
    '            sql &= "pCap,"
    '            sql &= "pIva,"
    '            sql &= "pPagamento,"
    '            sql &= "NumColli,"
    '            sql &= "IdPagamento,"
    '            sql &= "Peso"
    '            sql &= ") VALUES ("
    '            sql &= Ap(_Descrizione) & ","
    '            sql &= Ap(_Importo) & ","
    '            sql &= _IdCat & ","
    '            sql &= _IdRub & ","
    '            sql &= _Tipo & ","
    '            sql &= _Numero & ","
    '            sql &= Ap(_DataRicavo) & ","
    '            sql &= Ap(_DataPrevPagam) & ","
    '            sql &= Ap(_Scansione) & ","
    '            sql &= Ap(_Scansione1) & ","
    '            sql &= Ap(_Scansione2) & ","
    '            sql &= Ap(_Scansione3) & ","
    '            sql &= Ap(_Scansione4) & ","
    '            sql &= _PercIva & ","
    '            sql &= Ap(_Iva) & ","
    '            sql &= _IdCorr & ","
    '            sql &= Ap(_CostoCorr) & ","
    '            sql &= Ap(_Totale) & ","
    '            sql &= Ap(_pRagSoc) & ","
    '            sql &= Ap(_pIndirizzo) & ","
    '            sql &= Ap(_pIndCons) & ","
    '            sql &= Ap(_pCitta) & ","
    '            sql &= Ap(_pCap) & ","
    '            sql &= Ap(_pIva) & ","
    '            sql &= Ap(_pPagamento) & ","
    '            sql &= _NumColli & ","
    '            sql &= _IdPagamento & ","
    '            sql &= Ap(_Peso)

    '            sql &= ")"
    '        Else
    '            sql = "UPDATE T_ContabRicavi SET "
    '            sql &= "Descrizione = " & Ap(_Descrizione) & ","
    '            sql &= "Importo = " & Ap(_Importo) & ","
    '            sql &= "IdCat = " & _IdCat & ","
    '            sql &= "IdRub = " & _IdRub & ","
    '            sql &= "Tipo = " & _Tipo & ","
    '            sql &= "Numero = " & _Numero & ","
    '            sql &= "DataRicavo = " & Ap(_DataRicavo) & ","
    '            sql &= "DataPrevPagam = " & Ap(_DataPrevPagam) & ","
    '            sql &= "Scansione = " & Ap(_Scansione) & ","
    '            sql &= "Scansione1 = " & Ap(_Scansione1) & ","
    '            sql &= "Scansione2 = " & Ap(_Scansione2) & ","
    '            sql &= "Scansione3 = " & Ap(_Scansione3) & ","
    '            sql &= "Scansione4 = " & Ap(_Scansione4) & ","
    '            sql &= "PercIva = " & _PercIva & ","
    '            sql &= "Iva = " & Ap(_Iva) & ","
    '            sql &= "IdCorr = " & _IdCorr & ","
    '            sql &= "CostoCorr = " & Ap(_CostoCorr) & ","
    '            sql &= "Totale = " & Ap(_Totale) & ","
    '            sql &= "pRagSoc = " & Ap(_pRagSoc) & ","
    '            sql &= "pIndirizzo = " & Ap(_pIndirizzo) & ","
    '            sql &= "pIndCons = " & Ap(_pIndCons) & ","
    '            sql &= "pCitta = " & Ap(_pCitta) & ","
    '            sql &= "pCap = " & Ap(_pCap) & ","
    '            sql &= "pIva = " & Ap(_pIva) & ","
    '            sql &= "pPagamento = " & Ap(_pPagamento) & ","
    '            sql &= "NumColli = " & _NumColli & ","
    '            sql &= "IdPagamento = " & _IdPagamento & ","
    '            sql &= "Peso = " & Ap(_Peso)
    '            sql &= " WHERE IdRicavo= " & _IdRicavo
    '        End If
    '        myCommand.CommandText = sql
    '        myCommand.ExecuteNonQuery()

    '        If _IdRicavo = 0 Then
    '            sql = "select @@identity"
    '            myCommand.CommandText = sql
    '            IdInserito = myCommand.ExecuteScalar()
    '            _IdRicavo = IdInserito
    '        End If

    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex)
    '        Ris = ex.GetHashCode
    '    End Try
    '    Return Ris
    'End Function

    'Public Function CalcolaDataPrevPagam() As Date
    '    Dim Ris As Date
    '    Select Case _IdPagamento

    '        Case 0
    '            Ris = _DataRicavo
    '        Case 1 '7 giorni bonifico
    '            Ris = _DataRicavo.AddDays(7)
    '        Case 2 '30
    '            Ris = _DataRicavo.AddDays(30)
    '        Case 3 '45
    '            Ris = _DataRicavo.AddDays(45)
    '        Case 4 '60
    '            Ris = _DataRicavo.AddDays(60)
    '        Case 5 '90
    '            Ris = _DataRicavo.AddDays(90)

    '    End Select

    '    Return Ris
    'End Function

#End Region

End Class

Public Class cContabRicaviColl
    Inherits _cOldDao
    'Public Function ListaDocByIdCons(ByVal IdCons) As DataTable
    '    Dim datatb As DataTable = New DataTable("T_VociFat")
    '    Dim sql As String = ""
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        sql = "SELECT Distinct c.IdRicavo,c.tipo,c.numero,c.DataRicavo from T_ContabRicavi c,T_ordini O "
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
    '        sql &= " where o.iddoc = c.idricavo "

    '        sql &= " AND O.idord IN (Select Idord from tr_consord where idcons= " & IdCons & ")"

    '        myCommand.CommandText = sql
    '        Dim myReader As SqlDataReader = myCommand.ExecuteReader()
    '        datatb.Load(myReader)
    '        myReader.Close()
    '        myCommand.Dispose()

    '    Catch ex As Exception
    '        OldManageError(ex, sql)
    '    End Try
    '    Return datatb
    'End Function

    'Public Function Lista() As DataTable
    '    Dim datatb As DataTable = New DataTable("T_ContabRicavi")
    '    Try

    '        Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
    '        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
    '        Dim sql As String = ""
    '        sql = "SELECT IdRicavo,Descrizione,Importo,IdCat,DataRicavo,Scansione,PercIva,Iva from T_ContabRicavi"
    '        'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

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

    Public Sub AllegaDDTaFattura(ByVal IdDDt As Integer, ByVal IdFatt As Integer)

        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = OldDbConnection
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "UPDATE T_ContabRicavi SET IDDOCRIF = " & IdFatt
                Sql &= " WHERE IdRicavo = " & IdDDt
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            OldManageError(ex)

        End Try

    End Sub

    Public Sub ResetIdDocRifByIdDoc(ByVal IdDoc As Integer)

        Try

            Using myCommand As SqlCommand = New SqlCommand()
                myCommand.Connection = OldDbConnection
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim Sql As String = "UPDATE T_ContabRicavi SET IdDocRif = 0 " & " WHERE IdDocRif = " & IdDoc
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            OldManageError(ex)

        End Try

    End Sub

    Public Function ListaDDT(Optional ByVal IdCli As Integer = 0, Optional ByVal Anno As Integer = 0, Optional ByVal Mese As Integer = 0, Optional ByVal IdDocRif As Integer = 0) As DataTable
        Dim datatb As DataTable = New DataTable("T_ContabRicavi")
        Try

            Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim sql As String = ""
                sql = "SELECT * FROM T_ContabRicavi"
                'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
                sql &= " WHERE Tipo = " & enTipoDocumento.DDT
                If IdDocRif Then
                    sql &= " AND IdDocRif = " & IdDocRif
                Else
                    sql &= " AND (IdDocRif = 0 or iddocrif is null)"
                    sql &= " AND idrub = " & IdCli
                    If Mese Then sql &= " AND month(dataricavo) = " & Mese
                    If Anno Then sql &= " AND year(dataricavo) = " & Anno
                End If

                sql &= " ORDER BY Numero desc"
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

    Public Sub PassaA(ByVal IdDoc As Integer,
                      ByVal Stato As enStatoOrdine,
                      Optional SoloUscitiMagazzino As Boolean = False)

        Try

            Using myCommand As SqlCommand = OldDbConnection.CreateCommand()
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim sql As String = ""
                sql = "SELECT IdOrd FROM T_vocifat WHERE iddoc = " & IdDoc & " OR iddoc IN (SELECT idricavo FROM t_contabricavi WHERE iddocrif= " & IdDoc & ")"
                'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

                myCommand.CommandText = sql
                Using myReader As SqlDataReader = myCommand.ExecuteReader()

                    While myReader.Read
                        Dim IdOrd As Integer = myReader("idord")

                        Dim OkStato As Boolean = True

                        If SoloUscitiMagazzino Then
                            Using O As New Ordine
                                O.Read(IdOrd)

                                If O.Stato < enStatoOrdine.UscitoMagazzino Then
                                    OkStato = False
                                End If
                            End Using
                        End If

                        If OkStato Then
                            Using Ord As New OrdiniDAO
                                Ord.AvanzaOrdiniAStatoByIdOrd(IdOrd, Stato)
                            End Using
                        End If

                    End While

                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            OldManageError(ex)
        End Try

    End Sub

    Public Function ListaCombo(ByVal IdRub As Integer) As DataTable
        Dim datatb As DataTable = New DataTable("T_ContabRicavi")
        Try

            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim sql As String = ""
            sql = "SELECT IdRicavo as IdFat,DataRicavo as DataRif,"

            'sql &= "switch(tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
            'sql &= "tipo=" & enTipoDocumento.enTipoDocFatturaRiepilogativa & ",'Fattura riepilogativa',"
            'sql &= "tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
            'sql &= "tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
            'sql &= ") & ' ' & "
            'sql &= "DataRicavo & ' - ' & Descrizione & ' -  €' & Totale as Descr from T_ContabRicavi "

            sql &= "(select case tipo when " & enTipoDocumento.Fattura & " then 'Fattura'"
            sql &= " when " & enTipoDocumento.FatturaRiepilogativa & " then 'Fattura riepilogativa'"
            sql &= " when " & enTipoDocumento.Preventivo & " then 'Preventivo'"
            sql &= " when " & enTipoDocumento.NotaDiCredito & " then 'Nota di Credito' "
            sql &= " when " & enTipoDocumento.NotaDiDebito & " then 'Nota di Debito' "
            sql &= " when " & enTipoDocumento.AccontoAnticipoSuFattura & " then 'Acconto/Anticipo su Fattura' "
            sql &= " when " & enTipoDocumento.DDT & " then 'DDT'"
            sql &= " end ) + ' ' + "
            sql &= " Convert(varchar,DataRicavo) + ' - ' + Descrizione + ' -  €' + Convert(varchar,Totale) as Descr from T_ContabRicavi "

            sql &= " where idrub = " & IdRub


            'sql &= " union SELECT IdCosto as IdFat,DataCosto as DataRif,"

            'sql &= "switch(tipo=" & enTipoDocumento.enTipoDocFattura & ",'Fattura',"
            'sql &= "tipo=" & enTipoDocumento.enTipoDocPreventivo & ",'Preventivo',"
            'sql &= "tipo=" & enTipoDocumento.enTipoDocDDT & ",'DDT'"
            'sql &= ") & ' ' &"

            'sql &= " DataCosto & ' - ' & Descrizione & ' -  €' & Totale as Descr from T_ContabCosti "

            'sql &= " where idrub = " & IdRub


            'sql &= ")"

            sql &= " order by DataRicavo desc"

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

    Public Function Delete(ByVal Id As Integer) As Integer
        Dim Ris As Integer = 0
        Try

            Dim myCommand As SqlCommand = New SqlCommand()
            myCommand.Connection = OldDbConnection
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim Sql As String = "DELETE FROM T_ContabRicavi"
            Sql &= " Where IdRicavo = " & Id
            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()
            myCommand.Dispose()
        Catch ex As Exception
            OldManageError(ex)
            Ris = ex.GetHashCode
        End Try
        Return Ris
    End Function

    'Public Function PassaAPagatoDDT(ByVal IdDocRif As Integer) As Integer
    '    'Dim Ris As Integer = 0
    '    'Try

    '    '    Dim myCommand As SqlCommand = New SqlCommand()
    '    '    myCommand.Connection = LUNA.LunaContext.Connection
    '    '    Dim Sql As String = "UPDATE T_ContabRicavi set "
    '    '    Sql &= " Where IdRicavo = " & IdDocRif
    '    '    myCommand.CommandText = Sql
    '    '    myCommand.ExecuteNonQuery()
    '    '    myCommand.Dispose()
    '    'Catch ex As Exception
    '    '    ManageError(ex)
    '    '    Ris = ex.GetHashCode
    '    'End Try
    '    'Return Ris
    'End Function

End Class

'Public Class cContabCat
'    Inherits _cOldDao
'#Region "Property"

'    Private _IdCat As Integer
'    Public Property IdCat() As Integer
'        Get
'            Return _IdCat
'        End Get
'        Set(ByVal value As Integer)
'            _IdCat = value
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
'            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
'            myCommand.CommandText = "SELECT * FROM TD_ContabCat where IdCat = " & Id
'            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            myReader.Read()
'            If myReader.HasRows Then
'                _IdCat = myReader("IdCat")
'                If Not myReader("Descrizione") Is DBNull.Value Then
'                    _Descrizione = myReader("Descrizione").ToString
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
'            OldManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'    Public Function Save(Optional ByRef IdInserito As Integer = 0) As Integer

'        Dim Ris As Integer = 0

'        Try
'            Dim sql As String
'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = OldDbConnection
'            If _IdCat = 0 Then
'                sql = "INSERT INTO TD_ContabCat("
'                sql &= "Descrizione,"
'                sql &= "Tipo"
'                sql &= ") VALUES ("
'                sql &= Ap(_Descrizione) & ","
'                sql &= _Tipo
'                sql &= ")"
'            Else
'                sql = "UPDATE TD_ContabCat SET "
'                sql &= "Descrizione = " & Ap(_Descrizione) & ","
'                sql &= "Tipo = " & _Tipo
'                sql &= " WHERE IdCat= " & _IdCat
'            End If
'            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'            myCommand.CommandText = sql
'            myCommand.ExecuteNonQuery()

'            If _IdCat = 0 Then
'                sql = "select @@identity"
'                myCommand.CommandText = sql
'                IdInserito = myCommand.ExecuteScalar()
'                _IdCat = IdInserito
'            End If

'            myCommand.Dispose()

'        Catch ex As Exception
'            OldManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'#End Region

'End Class


'Public Class cContabCatColl
'    Inherits _cOldDao
'    Public Function Lista() As DataTable
'        Dim datatb As DataTable = New DataTable("TD_ContabCat")
'        Try

'            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
'            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'            Dim sql As String = ""
'            sql = "SELECT IdCat,Descrizione,Tipo from TD_ContabCat"
'            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA

'            myCommand.CommandText = sql
'            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
'            datatb.Load(myReader)
'            myReader.Close()
'            myCommand.Dispose()

'        Catch ex As Exception
'            OldManageError(ex)
'        End Try
'        Return datatb
'    End Function
'    Public Function Delete(ByVal Id As Integer) As Integer
'        Dim Ris As Integer = 0
'        Try

'            Dim myCommand As SqlCommand = New SqlCommand()
'            myCommand.Connection = OldDbConnection
'            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
'            Dim Sql As String = "DELETE FROM TD_ContabCat"
'            Sql &= " Where IdCat = " & Id
'            myCommand.CommandText = Sql
'            myCommand.ExecuteNonQuery()
'            myCommand.Dispose()
'        Catch ex As Exception
'            OldManageError(ex)
'            Ris = ex.GetHashCode
'        End Try
'        Return Ris
'    End Function

'End Class

Public Class cTipoDoc
    Inherits CollectionBase

    Public Sub New(Optional ByVal FatturaRiepilogativa As Boolean = True, Optional ByVal DocumentoUscita As Boolean = False)

        Dim TipoDoc As FormerLib.cEnum

        TipoDoc = New FormerLib.cEnum
        TipoDoc.Id = enTipoDocumento.Fattura
        TipoDoc.Descrizione = "Fattura"
        InnerList.Add(TipoDoc)

        TipoDoc = New FormerLib.cEnum
        TipoDoc.Id = enTipoDocumento.DDT
        TipoDoc.Descrizione = "DDT"
        InnerList.Add(TipoDoc)

        TipoDoc = New FormerLib.cEnum
        TipoDoc.Id = enTipoDocumento.NotaDiCredito
        TipoDoc.Descrizione = "Nota di Credito"
        InnerList.Add(TipoDoc)

        TipoDoc = New FormerLib.cEnum
        TipoDoc.Id = enTipoDocumento.NotaDiDebito
        TipoDoc.Descrizione = "Nota di Debito"
        InnerList.Add(TipoDoc)

        TipoDoc = New FormerLib.cEnum
        TipoDoc.Id = enTipoDocumento.AccontoAnticipoSuFattura
        TipoDoc.Descrizione = "Acconto/Anticipo su Fattura"
        InnerList.Add(TipoDoc)

        If DocumentoUscita Then
            TipoDoc = New FormerLib.cEnum
            TipoDoc.Id = enTipoDocumento.Preventivo
            TipoDoc.Descrizione = "Preventivo"
            InnerList.Add(TipoDoc)

            'If LUNA.LunaContext.UtenteConnesso.Tipo = enTipoUtente.Admin Then
            '    If FatturaRiepilogativa Then
            '        TipoDoc = New FormerLib.cEnum
            '        TipoDoc.Id = enTipoDocumento.Fattura
            '        TipoDoc.Descrizione = "Fattura Riepilogativa"
            '        InnerList.Add(TipoDoc)
            '    End If
            'End If

        End If

    End Sub

End Class