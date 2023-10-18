Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

Public Class SituazioneCliente

    Public Property IdRub As Integer = 0
    Public Property RagSoc As String = ""
    Public Property Tel As String = ""
    Public Property Cel As String = ""
    Public Property Mail As String = ""
    Public Property NumOrd As Integer = 0
    Public Property TotOrd As Decimal = 0
    Public Property DataMinOrd As Date = Date.MinValue
    Public Property DataMaxOrd As Date = Date.MinValue
    Public Property EuroDaIncassare As Decimal = 0
    Public Property DataUltPag As Date = Date.MinValue
    Public Property EuroScoperto As Decimal = 0

    Public ReadOnly Property TotOrdStr() As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_TotOrd)
        End Get
    End Property

    Public ReadOnly Property EuroDaIncassareStr() As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_EuroDaIncassare)
        End Get
    End Property

    Public ReadOnly Property EuroScopertoStr() As String
        Get
            Return FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_EuroScoperto)
        End Get
    End Property

End Class

Public Class SituazioneClienteDAO
    Inherits _cOldDao

    Public Function Lista(Optional IdRub As Integer = 0) As List(Of SituazioneCliente)
        Dim Ris As New List(Of SituazioneCliente)
        Try
            Dim sql As String = ""
            sql = "Select * from (SELECT f.Id,RagSoc as RagioneSociale,Tel,Cellulare,Email,Conteggiodiidord as NumOrdini,iif(Espr1 is null,0,Espr1) " & _
                " as TotaleOrdini,MinDiDataIns as DataMinima,MaxDiDataIns as DataMassima,AncoraDaIncassare,g.DataUltimoPag," & _
                " iif(Espr1 is null, 0,Espr1)+ iif(AncoraDaIncassare is null, 0, AncoraDaincassare) as TotaleScoperto " & _
                " from (SELECT TOP 1 T_rubrica.idrub as id,T_Rubrica.RagSoc,T_rubrica.Tel,T_Rubrica.Cellulare,T_rubrica.Email, Count(T_Ordini.IdOrd) AS ConteggioDiIdOrd," & _
                " Sum([TotaleForn]+[Ricarico]-[Sconto]) AS Espr1, Min(T_Ordini.DataIns) AS MinDiDataIns, Max(T_Ordini.DataIns) AS MaxDiDataIns"

            sql &= " FROM T_Rubrica LEFT JOIN (SELECT * from T_Ordini WHERE STATO IN(" & enStatoOrdine.ProntoRitiro & "," & enStatoOrdine.UscitoMagazzino & ")) as ORdini ON T_Rubrica.IdRub =  Ordini.IdRub "
            'sql &= " FROM T_Rubrica LEFT JOIN (SELECT * from T_Ordini WHERE (STATO >=" & enStatoOrdine.ProntoRitiro & " AND STATO < " & enStatoOrdine.PagatoInteramente & ")) as ORdini ON T_Rubrica.IdRub =  Ordini.IdRub "
            sql &= " GROUP BY T_Rubrica.RagSoc, T_Rubrica.Tel, T_rubrica.Cellulare, T_Rubrica.Email " ', ordini.Stato"
            sql &= " ) as f"

            sql &= " left join ("
            sql &= " select a.idrub as id,round(dapagare,2)-round(pagati,2) as AncoraDaIncassare,DataUltimoPag from (select c.idrub,sum(totale) as dapagare from t_contabricavi c where (tipo =" & enTipoDocumento.Fattura & ") OR TIPO = " & enTipoDocumento.Preventivo & " OR TIPO = " & enTipoDocumento.FatturaRiepilogativa & " OR (TIPO= " & enTipoDocumento.DDT & " AND IDDOCRIF IS NULL)  group by c.idrub) as a inner join (select p.idrub,sum(importo) as pagati,max(p.DataPag) as DataUltimoPag from t_pagamenti p group by p.idrub) as b on a.idrub=b.idrub) as g "
            sql &= " on f.id= g.id) "
            sql &= " where (totaleordini<>0 or totalescoperto<>0) "

            If IdRub Then
                sql &= " and id = " & IdRub
            End If


            Dim myCommand As SqlCommand = OldDbConnection.CreateCommand()
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read
                Dim classe As New SituazioneCliente
                If Not myReader("Id") Is DBNull.Value Then classe.IdRub = myReader("Id")
                If Not myReader("RagioneSociale") Is DBNull.Value Then classe.RagSoc = myReader("RagioneSociale")
                If Not myReader("Tel") Is DBNull.Value Then classe.Tel = myReader("Tel")
                If Not myReader("Cellulare") Is DBNull.Value Then classe.Cel = myReader("Cellulare")
                If Not myReader("Email") Is DBNull.Value Then classe.Mail = myReader("Email")
                If Not myReader("NumOrdini") Is DBNull.Value Then classe.NumOrd = myReader("NumOrdini")
                If Not myReader("TotaleOrdini") Is DBNull.Value Then classe.TotOrd = myReader("TotaleOrdini")
                If Not myReader("DataMinima") Is DBNull.Value Then classe.DataMinOrd = myReader("DataMinima")
                If Not myReader("DataMassima") Is DBNull.Value Then classe.DataMaxOrd = myReader("DataMassima")
                If Not myReader("AncoraDaIncassare") Is DBNull.Value Then classe.EuroDaIncassare = myReader("AncoraDaIncassare")
                If Not myReader("DataUltimoPag") Is DBNull.Value Then classe.DataUltPag = myReader("DataUltimoPag")
                If Not myReader("TotaleScoperto") Is DBNull.Value Then classe.EuroScoperto = myReader("TotaleScoperto")
                Ris.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            OldManageError(ex)
        End Try

        Return Ris
    End Function

End Class