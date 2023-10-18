Imports System.Data.SqlClient
Imports FormerDALSql.LUNA
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrOrdiniView
    Inherits MgrLunaView

    Public Shared Function Lista(Optional ByVal Codice As String = "",
                                  Optional ByVal Stato As String = "",
                                  Optional ByVal IdCatProd As Integer = 0,
                                  Optional ByVal OnlyWithoutCom As Boolean = False,
                                  Optional ByVal ListaIdOrdEsclusi As String = "",
                                  Optional ByVal NumSpazi As Boolean = False,
                                  Optional ByVal IdProd As Integer = 0,
                                  Optional ByVal OrderContrario As Boolean = False,
                                  Optional ByVal DataDal As Date = Nothing,
                                  Optional ByVal DataAl As Date = Nothing,
                                  Optional ByVal IdGruppo As Integer = 0,
                                  Optional ByVal IdRub As Integer = 0,
                                  Optional OnlyLastSixMonth As Boolean = False,
                                  Optional TipoProdotto As enTipoProdCom = 0,
                                  Optional OrderbyDataConsegna As Boolean = False,
                                  Optional IdAgente As Integer = 0,
                                  Optional DalSito As Boolean = False,
                                  Optional SenzaDocumentoFiscale As Boolean = False,
                                  Optional IdPrev As Integer = 0,
                                  Optional IdListinoBase As Integer = 0,
                                  Optional QuantitaSpec As Integer = 0,
                                  Optional ByVal ListaIdOrdInclusi As String = "",
                                  Optional Pagato As enSiNo = enSiNo.NonDefinito,
                                  Optional IdOrdOnline As Integer = 0,
                                  Optional Top As Integer = 0,
                                  Optional OnlyPromo As Boolean = False,
                                  Optional IdOrdineProvvisorio As Integer = 0,
                                  Optional IdConsegna As Integer = 0,
                                  Optional SoloNonFatturabili As Boolean = False,
                                  Optional ConDocumentoFiscale As Boolean = False) As List(Of OrdineView)
        Dim Ris As New List(Of OrdineView)

        Try
            Dim sql As String = ""

            sql = "SELECT "

            If Top Then
                sql &= " TOP " & Top
            End If

            'sql &= " o.*," &
            '    "p.Descrizione as ProdottoDescrizione, " &
            '    "p.NumSpazi, " &
            '    "p.NumDuplic, " &
            sql &= " o.*," &
                " case when r.RagSoc='' then r.cognome + ' ' + r.nome else r.ragsoc end as ClienteNominativo, " &
                " c.Nomebreve,   " &
                "(SELECT Count(Idpostit) FROM T_Postit Pos  WHERE Pos.IdOrd = o.IdOrd) as NMsg " &
                " FROM T_Ordini o," &
                " T_Rubrica R,  " &
                " T_Prodotti P, " &
                " T_Corriere C "
            sql &= " WHERE o.idprod = p.Idprod "
            sql &= " AND o.idrub = r.idrub "
            sql &= " AND o.idcorriere = c.idcorriere "
            '" (SELECT TOP 1 Giorno FROM T_CONS S, TR_CONSORD CR WHERE S.IdCons=CR.IdCons AND CR.IdOrd = o.IdOrd) as Programmata, " &
            If Codice.Length Then
                If IsNumeric(Codice) Then
                    sql &= " AND o.idord=" & Codice
                Else
                    'qui puodarsi sia stato inserito il nome di un lavoro 
                    sql &= " AND (o.nomelavoro " & LunaTools.StringTools.ApLike(Codice) & " OR charindex(" & LunaTools.StringTools.Ap(Codice) & ",o.filepath,0)<>0)"
                End If
            End If

            If TipoProdotto Then
                sql &= " AND o.idtipoprod = " & TipoProdotto
                'sql &= " AND p.tipoprod = " & TipoProdotto
            End If

            If Stato.Length Then
                sql &= " AND o.stato in(" & Stato & ")"
            End If

            If ListaIdOrdEsclusi.Length Then
                sql &= " AND o.idord not in(" & ListaIdOrdEsclusi & ")"
            End If

            If ListaIdOrdInclusi.Length Then
                sql &= " AND o.idord in(" & ListaIdOrdInclusi & ")"
            End If

            If IdRub Then
                sql &= " AND o.idrub =" & IdRub
            End If

            If OnlyWithoutCom Then
                sql &= " AND o.idcom = 0 "
            End If

            If IdOrdineProvvisorio Then
                sql &= " AND o.IdOrdineProvvisorio =  " & IdOrdineProvvisorio & " "
            End If

            If SenzaDocumentoFiscale Then
                sql &= " AND o.idDoc = 0 "
            End If

            If ConDocumentoFiscale Then
                sql &= " AND o.idDoc <> 0 "
            End If

            If IdProd Then
                sql &= " AND o.idprod =" & IdProd
            End If

            If IdCatProd Then
                sql &= " AND p.idlistinobase IN(Select IdListinobase from T_listinobase where idprev = " & IdCatProd & ")"
            End If

            If OnlyLastSixMonth = True Then
                sql &= " AND datediff(m,o.datains,getdate()) <= 6" ' & Ap(Postazione.AnnoSelezionato)
            End If

            If DataDal <> Date.MinValue Then
                sql &= " AND datediff(d," & FormerHelper.Stringhe.FormattaDataPerSQL(DataDal) & ",o.datains)>=0 "
            End If

            If DataAl <> Date.MinValue Then
                sql &= " AND datediff(d,o.datains," & FormerHelper.Stringhe.FormattaDataPerSQL(DataAl) & ")>=0 "
            End If

            If IdGruppo Then
                sql &= " AND o.idrub in (SELECT IdRub FROM Tr_GrupRubr WHERE IdGruppo = " & IdGruppo & ") "
            End If

            If IdAgente Then
                sql &= " AND r.idage = " & IdAgente
            End If

            If DalSito Then
                sql &= " AND RilascioCli = " & FormerConst.Web.IdRilascio
            End If

            If QuantitaSpec Then
                sql &= " AND o.qta = " & QuantitaSpec
            End If

            If IdPrev Then
                sql &= " AND o.idprod IN  (SELECT IdProd FROM T_PRODOTTI where IDListinoBase in (select IDLISTINOBASE from T_LISTINOBASE where IDPREV = " & IdPrev & "))"
            End If

            If IdListinoBase Then
                sql &= " AND p.idlistinobase = " & IdListinoBase
            End If

            If IdOrdOnline Then
                sql &= " AND o.idordonline = " & IdOrdOnline
            End If

            If OnlyPromo Then
                sql &= " AND o.idpromo <>0 "
            End If

            If IdConsegna Then
                sql &= " AND o.IdOrd IN (SELECT IdOrd FROM TR_ConsOrd WHERE IdCons = " & IdConsegna & ")"
            End If

            If SoloNonFatturabili Then
                sql &= " AND O.Preventivo = " & enSiNo.No
                sql &= " AND O.IDDoc = 0"
                sql &= " AND Year(o.DataIns) >=2019 "

            End If

            'qui devo escludere gli ordini che stanno in una fattura con statoincasso a impossibile

            sql &= " AND o.idord NOT IN (SELECT IdOrd FROM t_vocifat v INNER JOIN t_contabricavi c ON v.iddoc = c.idricavo AND v.idord = idord AND c.statoincasso=" & enStatoIncasso.Impossibile & ")"

            If OrderContrario Then
                sql &= " ORDER BY IdOrd ASC"
            Else
                sql &= " ORDER BY IdOrd DESC"
            End If

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()
                While myReader.Read
                    Dim classe As New OrdineView
                    If Not myReader("IdOrd") Is DBNull.Value Then classe.IdOrdine = myReader("IdOrd")

                    Ris.Add(classe)
                End While
                myReader.Close()
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris
    End Function

End Class
