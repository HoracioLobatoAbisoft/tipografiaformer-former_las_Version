Imports System.Data.SqlClient
Imports FormerLib.FormerEnum
Public Class cReport
    Inherits _cOldDao
    Private _NomeReport As String
    Public Property NomeReport() As String
        Get
            Return _NomeReport
        End Get
        Set(ByVal value As String)
            _NomeReport = value
        End Set
    End Property

    Public IdTipo As cReportColl.enTipoReport

End Class

Public Class cReportColl
    Inherits _cOldCollections

    Public Enum enTipoReport As Integer
        'enTipRepFatturatoCliente = 1
        enTipRepFatturatoMensile = 1
        'enTipRepFatturatoMeseCategoria
        'enTipRepFatturatoClientiMeseCategoria
        'enTipRepProdottoMese
        enTipRepSituazGenerale
        enTipRepCostiRicaviMese
       
    End Enum

    Public Function EseguiReport(ByVal IdTipo As Integer, _
                                 Optional ByVal GiornoInizio As Integer = 1, _
                                 Optional ByVal GiornoFine As Integer = 31, _
                                 Optional ByVal IdRub As Integer = 0, _
                                 Optional ByVal CodiceProd As String = "") As DataTable

        Dim datatb As DataTable = New DataTable("T_Report")
        Try

            Dim myCommand As SqlCommand = LUNA.LunaContext.OldDbConnection.CreateCommand()
            Dim sql As String = ""


            Select Case IdTipo
                'Case enTipoReport.enTipRepFatturatoCliente
                '    sql = " SELECT T_Rubrica.RagSoc, (Format([DataIns],""mmm"""" '""""yy"")) AS Mese_Anno, Sum([TotaleForn]+[Ricarico]-[Sconto]) AS Somma, Count(T_Ordini.IdOrd) AS N°_Ordini, T_Ordini.IdRub"
                '    sql &= " FROM T_Ordini INNER JOIN T_Rubrica ON T_Ordini.IdRub = T_Rubrica.IdRub"
                '    sql &= " GROUP BY T_Rubrica.RagSoc, (Format([DataIns],""mmm"""" '""""yy"")), T_Ordini.IdRub, (Year([DataIns])*12+Month([DataIns])-1)"
                '    sql &= " ORDER BY T_Rubrica.RagSoc, (Year([DataIns])*12+Month([DataIns])-1);"

                Case enTipoReport.enTipRepFatturatoMensile
                    sql = "SELECT (Format([DataIns],""mmm"""" '""""yy"")) AS Mese, Sum([TotaleForn]+[Ricarico]-[Sconto]) AS Fatturato"
                    sql &= " FROM(T_Ordini)"
                    sql &= "where day(datains)>=" & GiornoInizio
                    sql &= "and day(datains)<=" & GiornoFine
                    sql &= " GROUP BY (Format([DataIns],""mmm"""" '""""yy"")), (Year([DataIns])*12+Month([DataIns])-1)"
                    sql &= " ORDER BY (Year([DataIns])*12+Month([DataIns])-1);"
                    'Case enTipoReport.enTipRepFatturatoMeseCategoria
                    '    sql = "SELECT TD_CatProd.Descrizione, (Format([DataIns],""mmm"""" '""""yy"")) AS Mese_Anno, Sum([TotaleForn]+[Ricarico]-[sconto]) AS SommaDiPrezzo, Count(T_Ordini.IdOrd) AS ConteggioDiIdOrd"
                    '    sql &= " FROM (TD_CatProd INNER JOIN (T_Prodotti INNER JOIN T_Ordini ON T_Prodotti.IdProd = T_Ordini.IdProd) ON TD_CatProd.IdCatProd = T_Prodotti.IdCatProd) INNER JOIN T_Rubrica ON T_Ordini.IdRub = T_Rubrica.IdRub"
                    '    sql &= " GROUP BY TD_CatProd.Descrizione, (Format([DataIns],""mmm"""" '""""yy"")), (Year([DataIns])*12+Month([DataIns])-1)"
                    '    sql &= " ORDER BY TD_CatProd.Descrizione, (Year([DataIns])*12+Month([DataIns])-1);"
                    'Case enTipoReport.enTipRepFatturatoClientiMeseCategoria

                    '    sql = "SELECT TD_CatProd.Descrizione, (Format([DataIns],""mmm"""" '""""yy"")) AS Mese_Anno, Sum([TotaleForn]+[Ricarico]-[sconto]) AS Somma, Count(T_Ordini.IdOrd) AS N°_Ordini, "

                    '    sql &= " T_Rubrica.RagSoc, T_Ordini.IdRub FROM (TD_CatProd INNER JOIN (T_Prodotti INNER JOIN T_Ordini ON T_Prodotti.IdProd = T_Ordini.IdProd) ON TD_CatProd.IdCatProd = T_Prodotti.IdCatProd) INNER JOIN T_Rubrica ON "
                    '    sql &= " T_Ordini.IdRub = T_Rubrica.IdRub GROUP BY TD_CatProd.Descrizione, (Format([DataIns],""mmm"""" '""""yy"")), (Year([DataIns])*12+Month([DataIns])-1), T_Rubrica.RagSoc, T_Ordini.IdRub"
                    '    sql &= " HAVING(((T_Ordini.IdRub) = " & IdRub & "))"
                    '    sql &= " ORDER BY TD_CatProd.Descrizione, (Year([DataIns])*12+Month([DataIns])-1);"

                    'Case enTipoReport.enTipRepProdottoMese
                    '    sql = "SELECT T_Prodotti.Descrizione, T_Prodotti.Codice, (Format([DataIns],""mmm"""" '""""yy"")) AS Mese_Anno, Avg([TotaleForn]+[Ricarico]-[sconto]) AS SommaDiPrezzo, "

                    '    sql &= " Count(T_Ordini.IdOrd) AS ConteggioDiIdOrd, TD_CatProd.IdCatProd"
                    '    sql &= " FROM (TD_CatProd INNER JOIN (T_Prodotti INNER JOIN T_Ordini ON T_Prodotti.IdProd = T_Ordini.IdProd) ON TD_CatProd.IdCatProd = T_Prodotti.IdCatProd) INNER JOIN T_Rubrica ON "
                    '    sql &= " T_Ordini.IdRub = T_Rubrica.IdRub"
                    '    sql &= " GROUP BY T_Prodotti.Descrizione, T_Prodotti.Codice, (Format([DataIns],""mmm"""" '""""yy"")), (Year([DataIns])*12+Month([DataIns])-1), TD_CatProd.IdCatProd"
                    '    sql &= " HAVING (((T_Prodotti.Codice)=""" & CodiceProd & """))"
                    '    sql &= " ORDER BY T_Prodotti.Descrizione, (Year([DataIns])*12+Month([DataIns])-1);"

                Case enTipoReport.enTipRepSituazGenerale
                    sql = "Select * from (SELECT f.Id,RagSoc as RagioneSociale,Conteggiodiidord as NumOrdini,iif(Espr1 is null,0,Espr1) as TotaleOrdini,MinDiDataIns as DataMinima,MaxDiDataIns as DataMassima,AncoraDaIncassare,g.DataUltimoPag,iif(Espr1 is null, 0,Espr1)+ iif(AncoraDaIncassare is null, 0, AncoraDaincassare) as TotaleScoperto from (SELECT first(T_rubrica.idrub) as id,T_Rubrica.RagSoc, Count(T_Ordini.IdOrd) AS ConteggioDiIdOrd, Sum([TotaleForn]+[Ricarico]-[Sconto]) AS Espr1, Min(T_Ordini.DataIns) AS MinDiDataIns, Max(T_Ordini.DataIns) AS MaxDiDataIns"
                    'sql &= " FROM T_Ordini INNER JOIN T_Rubrica ON T_Ordini.IdRub = T_Rubrica.IdRub"
                    sql &= " FROM T_Rubrica LEFT JOIN (SELECT * from T_Ordini WHERE STATO IN(" & enStatoOrdine.ProntoRitiro & "," & enStatoOrdine.UscitoMagazzino & ")) as ORdini ON T_Rubrica.IdRub =  Ordini.IdRub "

                    sql &= " GROUP BY T_Rubrica.RagSoc, ordini.Stato"
                    sql &= " ) as f"

                    sql &= " left join ("

                    sql &= " select a.idrub as id,round(dapagare,2)-round(pagati,2) as AncoraDaIncassare,DataUltimoPag from (select c.idrub,sum(totale) as dapagare from t_contabricavi c where (tipo =1) OR TIPO = 3 OR TIPO = 4 OR (TIPO= 2 AND IDDOCRIF IS NULL)  group by c.idrub) as a inner join (select p.idrub,sum(importo) as pagati,max(p.DataPag) as DataUltimoPag from t_pagamenti p group by p.idrub) as b on a.idrub=b.idrub) as g "
                    sql &= " on f.id= g.id) "
                    sql &= " where totaleordini<>0 or totalescoperto<>0"

                Case enTipoReport.enTipRepCostiRicaviMese
                    sql = " SELECT a.Mese, a.totale AS Ricavi, b.totale AS Costi, Format((((b.totale)*100)/a.totale),'0.#0') & '%' AS Percentuale ,Format((a.totale -b.totale),'#0,00') as Utile"
                    sql &= " FROM (SELECT (Format(DataPag,'yyyy/mm')) AS Mese, Format(Sum(T_Pagamenti.Importo),'#0,00') AS Totale, T_Pagamenti.Tipo"
                    sql &= " FROM T_Pagamenti"
                    sql &= " where tipo = 1"
                    sql &= " GROUP BY (Format(DataPag,'yyyy/mm')), (Year(DataPag)*12+Month(DataPag)-1), T_Pagamenti.Tipo"
                    sql &= " ORDER BY (Year(DataPag)*12+Month(DataPag)-1)) AS a LEFT JOIN (SELECT (Format(DataPag,'yyyy/mm')) AS Mese, Format(Sum(T_Pagamenti.Importo),'#0,00')  AS Totale, T_Pagamenti.Tipo"
                    sql &= " FROM T_Pagamenti"
                    sql &= " where tipo = 2"
                    sql &= " GROUP BY (Format(DataPag,'yyyy/mm')), (Year(DataPag)*12+Month(DataPag)-1), T_Pagamenti.Tipo"
                    sql &= " ORDER BY (Year(DataPag)*12+Month(DataPag)-1)) AS b ON a.mese  = b.mese"
                    sql &= " WHERE b.totale <>''"
                    sql &= " ORDER BY a.mese"



            End Select


            Try
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                datatb.Load(myReader)
                myReader.Close()
                myCommand.Dispose()
            Catch ex As Exception

            End Try


        Catch ex As Exception
            OldManageError(ex)
        End Try
        Return datatb

    End Function


    Public Sub New()

        Dim Voce As Object

        Voce = New cReport

        'Voce.IdTipo = enTipoReport.enTipRepFatturatoCliente
        'Voce.NomeReport = "Fatturato Cliente per mese"

        'InnerList.Add(Voce)

        'Voce = New cReport

        'Voce.IdTipo = enTipoReport.enTipRepFatturatoMensile
        'Voce.NomeReport = "Fatturato mensile"

        'InnerList.Add(Voce)

        'Voce = New cReport

        'Voce.IdTipo = enTipoReport.enTipRepFatturatoMeseCategoria
        'Voce.NomeReport = "Fatturato per mese e categoria"

        'InnerList.Add(Voce)

        'Voce = New cReport

        'Voce.IdTipo = enTipoReport.enTipRepFatturatoClientiMeseCategoria
        'Voce.NomeReport = "Fatturato Clienti per mese e categoria"

        'InnerList.Add(Voce)


        'Voce = New cReport

        'Voce.IdTipo = enTipoReport.enTipRepProdottoMese
        'Voce.NomeReport = "Media prodotto per mese"

        'InnerList.Add(Voce)

        Voce = New cReport

        Voce.IdTipo = enTipoReport.enTipRepSituazGenerale
        Voce.NomeReport = "Situazione economica clienti"

        InnerList.Add(Voce)

        Voce = New cReport

        Voce.IdTipo = enTipoReport.enTipRepCostiRicaviMese
        Voce.NomeReport = "Costi e Ricavi per Mese"

        InnerList.Add(Voce)


    End Sub

End Class
