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
'''DAO Class for table T_rubrica
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class VociRubricaDAO
    Inherits _VociRubricaDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Public Function Merge(IdRubricaDaTenere As Integer,
                     IdRubricaDaEliminare As Integer) As Integer

        Dim ris As Integer = 0
        Try
            Using myCommand As SqlCommand = _Cn.CreateCommand

                'OFFLINE
                myCommand.CommandText = "UPDATE MailPreventivi set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_CarichiMagazzino set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_Cons set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_ContabCosti set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_ContabRicavi set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_Coupon set Riservato = " & IdRubricaDaTenere & " WHERE Riservato = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_Email set IdRubDest = " & IdRubricaDaTenere & " WHERE IdRubDest = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_Indirizzi set IdRubrica = " & IdRubricaDaTenere & " WHERE IdRubrica = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_MarkAz set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_ordini set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_Magaz set IdForn = " & IdRubricaDaTenere & " WHERE IdForn = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_Pagamenti set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_Preventivi set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE T_RubricaG set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "UPDATE TR_GrupRubr set IDRub = " & IdRubricaDaTenere & " WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                myCommand.CommandText = "DELETE FROM T_Rubrica WHERE IDRUB = " & IdRubricaDaEliminare
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                FormerLib.FormerLog.ScriviVoceRubrica(IdRubricaDaEliminare, "ELIMINATO perchè unito a IDRUB " & IdRubricaDaTenere)
                FormerLib.FormerLog.ScriviVoceRubrica(IdRubricaDaTenere, "UNITO con IDRUB " & IdRubricaDaEliminare)

            End Using
        Catch ex As Exception
            ris = 1
        End Try

        Return ris

    End Function

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function ListaIdClientiConPendenza() As List(Of Integer)

        Dim Ris As New List(Of Integer)

        Using myCommand As SqlCommand = _Cn.CreateCommand
            Dim Sql As String = "SELECT DISTINCT idrub FROM (SELECT DISTINCT IdRub FROM t_ordini WHERE stato IN (" & enStatoOrdine.ProntoRitiro & "," & enStatoOrdine.UscitoMagazzino & "," & enStatoOrdine.InConsegna & "," & enStatoOrdine.Consegnato & ") AND IdDoc = 0 "

            Sql &= " UNION "

            Sql &= " SELECT IdRub FROM T_ContabRicavi C WHERE round(Totale - isnull((SELECT sum(importo) FROM t_pagamenti WHERE idfat= c.idricavo AND tipo=" & enTipoVoceContab.VoceVendita & "),0),2) <>0 "
            Sql &= " AND (c.iddocrif=0 OR c.iddocrif IS NULL) "
            Sql &= ") A"

            myCommand.CommandText = Sql
            Using myReader As SqlDataReader = myCommand.ExecuteReader()

                While myReader.Read

                    Ris.Add(myReader("IdRub"))

                End While

            End Using

        End Using

        Return Ris

    End Function

    Public Function GetAllTag() As List(Of String)
        Dim Ris As New List(Of String)

        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""

                sql = "SELECT DISTINCT tag FROM T_Rubrica WHERE len(tag) <>0 order by tag"

                myCommand.CommandText = sql
                Using myReader As SqlDataReader = myCommand.ExecuteReader()

                    While myReader.Read

                        Dim TagSing() As String = myReader("Tag").ToString.Split(" ")

                        For Each singString As String In TagSing
                            If singString.Trim.Length Then
                                If Ris.FindAll(Function(x) x = singString.Trim).Count = 0 Then Ris.Add(singString)
                            End If
                        Next

                    End While

                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try

        Ris.Sort(Function(x, y) x.CompareTo(y))

        Return Ris
    End Function

    Public Function ListaContabEmail() As DataTable
        Dim datatb As DataTable = New DataTable("T_Rubrica")
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""

                sql = "select distinct idrub,RagSoc from (Select r.IdRub,r.RagSoc,Totale,0 + " &
                    "(Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=" &
                    enTipoVoceContab.VoceVendita & ") as Incassati,Totale - (Select sum(importo) from t_pagamenti where idfat= c.idricavo and tipo=" &
                    enTipoVoceContab.VoceVendita & ") as Differenza " &
                    " from t_contabricavi c inner join  T_Rubrica  r on c.idrub=r.idrub "
                sql &= " where 1=1 "

                sql &= " and c.tipo <>" & enTipoDocumento.DDT & " ) a where differenza <>0 order by RagSoc"

                myCommand.CommandText = sql
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    datatb.Load(myReader)
                    myReader.Close()
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return datatb

    End Function

    Public Function OltreScopertoMax(R As VoceRubrica) As Boolean

        Dim Ris As Boolean = False

        If R.ScopertoMax <> 0 Then

            Dim ScopertoAttuale As Decimal = 0

            Dim situaz As RisSituazioneCliente = MgrSituazioneCliente.GetSituazioneCliente(R.IdRub)
            If Not situaz Is Nothing Then
                ScopertoAttuale = situaz.TotaleScopertoComplessivo
            End If

            If ScopertoAttuale > R.ScopertoMax Then
                Ris = True
            End If

        End If

        Return Ris

    End Function

    Public Function GetDuplicati(Optional ByVal ShowOnlyForn As Boolean = False,
                                 Optional ByVal ShowOnlyCli As Boolean = False,
                                 Optional ByVal ShowOnlyRiv As Boolean = False,
                                 Optional ByVal ShowAge As Boolean = False,
                                 Optional ByVal IdRubPartenza As Integer = 0) As List(Of VoceRubrica)
        Dim lstF As New List(Of VoceRubrica)
        Try

            Dim ClausolaIdRub As String = String.Empty
            If IdRubPartenza Then

                Using r As New VoceRubrica
                    r.Read(IdRubPartenza)
                    If r.Piva.Length Then
                        ClausolaIdRub = " AND Piva = " & Ap(r.Piva) & " "
                    End If

                End Using

            End If
            Dim sql As String = "SELECT DISTINCT * FROM T_RUBRICA WHERE PIVA IN(select piva from (select Count(*) as quanti ,piva from t_rubrica where  piva <>'' " & ClausolaIdRub & " group by piva)a where a.quanti >1)"

            If ShowOnlyCli Or ShowOnlyRiv Then

                sql &= " AND TIPO IN ("

                If ShowOnlyCli Then
                    sql &= enTipoRubrica.Cliente & ","
                End If

                'If ShowAge Then
                '    sql &= enTipoRubrica.Agente & ","
                'End If

                If ShowOnlyRiv Then
                    sql &= enTipoRubrica.Rivenditore & ","
                End If

                sql &= "0)"

            End If

            If ShowOnlyForn Then
                sql &= " AND IsFornitore = " & enSiNo.Si
            End If

            sql &= " order by Piva"

            Dim lst As List(Of VoceRubrica) = GetData(sql)

            If ClausolaIdRub.Length Then
                lst = lst.FindAll(Function(x) x.IdRub <> IdRubPartenza)
            End If

            lstF.AddRange(lst)

            If IdRubPartenza Then

                Using r As New VoceRubrica
                    r.Read(IdRubPartenza)
                    If r.CodFisc.Length Then
                        ClausolaIdRub = " AND Codfisc = " & Ap(r.CodFisc) & " "
                    End If

                End Using
            End If

            sql = "SELECT DISTINCT * FROM T_RUBRICA WHERE codfisc IN(select codfisc from (select Count(*) as quanti ,codfisc from t_rubrica where codfisc <>'' " & ClausolaIdRub & "  group by codfisc)a where a.quanti >1) "

            If ShowOnlyCli Or ShowOnlyRiv Then

                sql &= " AND TIPO IN ("

                If ShowOnlyCli Then
                    sql &= enTipoRubrica.Cliente & ","
                End If

                'If ShowAge Then
                '    sql &= enTipoRubrica.Agente & ","
                'End If

                If ShowOnlyRiv Then
                    sql &= enTipoRubrica.Rivenditore & ","
                End If

                sql &= "0)"

            End If

            If ShowOnlyForn Then
                sql &= " AND IsFornitore = " & enSiNo.Si
            End If

            sql &= " order by CodFisc"
            lst = GetData(sql)

            If ClausolaIdRub.Length Then
                lst = lst.FindAll(Function(x) x.IdRub <> IdRubPartenza)
            End If

            For Each voce In lst
                If lstF.FindAll(Function(x) x.IdRub = voce.IdRub).Count = 0 Then lstF.Add(voce)
            Next

            'lstF.AddRange(lst)
        Catch ex As Exception

        End Try
        Return lstF
    End Function

    Public Function Lista(ByVal ShowOnlyForn As Boolean,
                          ByVal ShowOnlyCli As Boolean,
                          ByVal ShowOnlyRiv As Boolean,
                          ByVal ShowOnlyAge As Boolean,
                          Optional ByVal Cerca As String = "", Optional ByVal OnlyOrder As Boolean = False,
                          Optional ByVal IdGruppo As Integer = 0, Optional ByVal IdMark As Integer = 0,
                          Optional ByVal OnlyNonComp As Boolean = False,
                          Optional ByVal TipoCorriere As Integer = 0,
                          Optional ByVal Sorgente As String = "",
                          Optional ByVal SorgenteStorico As String = "",
                          Optional IdCatContab As Integer = 0) As List(Of VoceRubrica)

        Dim lst As New List(Of VoceRubrica)
        Try

            Dim sql As String = ""
            sql = "SELECT * from T_rubrica "

            sql &= " WHERE status= " & enStato.Attivo

            If Cerca.Length Then

                sql &= " AND (Ragsoc " & IIf(Cerca.Length = 1, ApLikeRight(Cerca), ApLike(Cerca))
                sql &= " OR Cognome " & IIf(Cerca.Length = 1, ApLikeRight(Cerca), ApLike(Cerca))
                sql &= " OR Nome " & IIf(Cerca.Length = 1, ApLikeRight(Cerca), ApLike(Cerca))
                sql &= " OR PIVA = " & Ap(Cerca)
                sql &= " OR CODFISC = " & Ap(Cerca)

                If Cerca.StartsWith("#") Then

                    sql &= " OR TAG " & ApLike(Cerca)

                End If

                sql &= " )"

            End If

            If Sorgente <> String.Empty Then
                sql &= " AND Sorgente = " & Ap(Sorgente)
            End If

            If SorgenteStorico <> String.Empty Then
                sql &= " AND SorgenteStorico = " & Ap(SorgenteStorico)
            End If

            If IdCatContab Then
                sql &= " AND IdCatContab = " & IdCatContab
            End If

            If ShowOnlyCli Or ShowOnlyRiv Then

                sql &= " AND TIPO IN ("

                If ShowOnlyCli Then
                    sql &= enTipoRubrica.Cliente & ","
                End If

                'If ShowAge Then
                '    sql &= enTipoRubrica.Agente & ","
                'End If

                If ShowOnlyRiv Then
                    sql &= enTipoRubrica.Rivenditore & ","
                End If

                sql &= "0)"

            End If

            If ShowOnlyForn Then
                sql &= " AND IsFornitore = " & enSiNo.Si
            End If


            If OnlyOrder Then
                sql &= " AND IDRUB IN (SELECT DISTINCT IDRUB FROM T_ORDINI) "
            End If

            If TipoCorriere Then
                If TipoCorriere = enCorriere.RitiroCliente Then
                    sql &= " AND IDCORRIERE = " & enTipoCorriere.Gratis
                End If

                If TipoCorriere = enCorriere.PortoAssegnatoGLS Then
                    sql &= " AND IDCORRIERE = " & enTipoCorriere.PortoAssegnato
                End If

                If TipoCorriere = enCorriere.TipografiaFormer Then

                    sql &= " AND IDCORRIERE = " & enTipoCorriere.ConTariffa & " AND CAP IN (SELECT Cap FROM T_CapCorr WHERE IdCorriere IN (" & enCorriere.TipografiaFormer & "," & enCorriere.TipografiaFormerFuoriRaccordo & "))"

                End If

                If TipoCorriere = enCorriere.GLS Then

                    sql &= " And IDCORRIERE = " & enTipoCorriere.ConTariffa & " And CAP Not In (Select Cap FROM T_CapCorr IdCorriere IN (" & enCorriere.TipografiaFormer & "," & enCorriere.TipografiaFormerFuoriRaccordo & "))"

                End If

            End If

            If IdGruppo Then
                sql &= " And IDRUB In (Select DISTINCT IDRUB FROM TR_GRUPRUBR WHERE IDGRUPPO= " & IdGruppo & ")"
            End If

            If IdMark Then
                'se c'e' il marketing devo anche tenere conto del parametro OnlyNonComp
                sql &= " And (IDRUB In (Select DISTINCT IDRUB FROM TR_GRUPRUBR WHERE IDGRUPPO= (Select idgruppo from t_marketing where idmark= " & IdMark & "))"

                'qui
                If OnlyNonComp Then

                    sql &= " And IDRUB Not In (Select DISTINCT IDRUB FROM T_MarkAz where idmarketing= " & IdMark & ") "

                End If
                sql &= ")"
            End If
            sql &= " order by RagSoc"

            lst = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return lst
    End Function

    Public Function ListaGruppoNew(Optional ByVal RagSoc As String = "", Optional ByVal Citta As String = "", _
                                Optional ByVal CAP As String = "", Optional ByVal IdGruppo As Integer = 0, _
                                Optional ByVal IdProdAcq As Integer = 0, Optional ByVal IdProdNonAcq As Integer = 0, _
                                Optional ByVal IdCorrPred As Integer = 0, Optional ByVal LimiteSuperato As Boolean = False, _
                                Optional ByVal PagamSospesi As Boolean = False, Optional ByVal PSospDal As Date = Nothing, Optional ByVal PSospAl As Date = Nothing, _
                                Optional ByVal SpesoMinDi As Decimal = 0, Optional ByVal SpesoMaxDi As Decimal = 0, _
                                Optional ByVal SpesoPeriodo As Integer = 0, Optional ByVal SpendonoDal As Date = Nothing, Optional ByVal SpendonoAl As Date = Nothing, _
                                Optional ByVal NonSpendonoDal As Date = Nothing, Optional ByVal NonSpendonoAl As Date = Nothing, _
                                Optional ByVal IdTipo As Integer = 0) As List(Of VoceRubrica)

        Dim Lst As New List(Of VoceRubrica)
        Try

            'Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim sql As String = ""
            sql = "Select IdRub As Id,RagSoc As [Ragione Sociale] from T_Rubrica "
            sql &= " WHERE status= " & enStato.Attivo

            If RagSoc.Length Then

                sql &= " And Ragsoc " & IIf(RagSoc.Length = 1, ApLikeRight(RagSoc), ApLike(RagSoc))
                'sql &= " Or Cognome " & IIf(RagSoc.Length = 1, ApLikeRight(RagSoc), ApLike(RagSoc))
                'sql &= " Or Nome " & IIf(RagSoc.Length = 1, ApLikeRight(RagSoc), ApLike(RagSoc)) & ")"

            End If

            If IdTipo Then
                sql &= " And tipo = " & IdTipo
            End If

            If Citta.Length Then
                sql &= " And citta = " & Ap(Citta)
            End If

            If CAP.Length Then
                sql &= " And cap = " & Ap(CAP)
            End If

            If IdProdAcq Then

                sql &= " And IDRUB In (Select DISTINCT IDRUB FROM T_ORDINI WHERE IDPROD In (Select IDPROD FROM T_PRODOTTI WHERE IDCATPROD= " & IdProdAcq & ")) "

            End If

            If IdProdNonAcq Then

                sql &= " And IDRUB Not In (Select DISTINCT IDRUB FROM T_ORDINI WHERE IDPROD In (Select IDPROD FROM T_PRODOTTI WHERE IDCATPROD= " & IdProdNonAcq & ")) "

            End If

            If IdCorrPred Then

                sql &= " And idcorriere = " & IdCorrPred

            End If

            If LimiteSuperato Then

                'SELECT sum(prezzo) as totale FROM T_Ordini where IdRub = " & _IdRub & " AND stato >= " & enStatoOrdine.Registrato & " and stato <= " & enStatoOrdine.InConsegna
                sql &= " AND IDRUB IN (select idrub from (select o.idrub,first( scopertomax) as scop,sum(prezzo) as tot from t_rubrica r, t_ordini o where r.idrub= o.idrub group by o.idrub) where scop<>0 and scop<tot)"

            End If

            If PagamSospesi Then

                sql &= " AND IDRUB IN ("
                sql &= "select distinct idrub from t_contabricavi where  datediff(d,'" & PSospDal.Day & "/" & PSospDal.Month & "/" & PSospDal.Year & "',dataprevpagam)>=0 and datediff(d,dataprevpagam,'" & PSospAl.Day & "/" & PSospAl.Month & "/" & PSospAl.Year & "')>=0 )"


            End If

            'qui devo controllare il massimale di spesa fatta
            If SpesoMinDi Then
                Dim dataRif As String = ""
                Select Case SpesoPeriodo
                    Case 0 ' trimestre
                        dataRif = " datediff(m,datains,getdate()) <= 3 "
                    Case 1 ' semestre
                        dataRif = " datediff(m,datains,getdate()) <= 6 "
                    Case 2 'anno
                        dataRif = " datediff(m,datains,getdate()) <= 12 "
                End Select

                sql &= "and idrub in (select distinct idrub from (select idrub, sum(prezzo) as totale from t_ordini where " & dataRif & " group by idrub) where  totale <" & SpesoMinDi & ")"

            End If

            If SpesoMaxDi Then
                Dim dataRif As String = ""
                Select Case SpesoPeriodo
                    Case 0 ' trimestre
                        dataRif = " datediff(m,datains,getdate()) <= 3 "
                    Case 1 ' semestre
                        dataRif = " datediff(m,datains,getdate()) <= 6 "
                    Case 2 'anno
                        dataRif = " datediff(m,datains,getdate()) <= 12 "
                End Select

                sql &= " and idrub in (select distinct idrub from (select idrub, sum(prezzo) as totale from t_ordini where " & dataRif & " group by idrub) where  totale >" & SpesoMaxDi & ")"

            End If

            If Not SpendonoDal = Date.MinValue Then
                'sql &= " and idrub in (select distinct idrub from t_ordini where  datediff('d',datains,'" & SpendonoDal.day & "/" & SpendonoDal.Month & "/" & SpendonoDal.Year  & "')>=0 and datediff('d',datains,#" & SpendonoAl.ToShortDateString & "#)<=0 )"
                sql &= " and idrub in (select distinct idrub from t_ordini where  datediff(d,'" & SpendonoDal.Day & "/" & SpendonoDal.Month & "/" & SpendonoDal.Year & "',datains)>=0 and datediff(d,datains,'" & SpendonoAl.Day & "/" & SpendonoAl.Month & "/" & SpendonoAl.Year & "')>=0 )"

            End If

            If Not NonSpendonoDal = Date.MinValue Then
                'sql &= " and idrub not in (select distinct idrub from t_ordini where  datediff('d',datains,#" & NonSpendonoDal.ToShortDateString & "#)>=0 and datediff('d',datains,#" & NonSpendonoAl.ToShortDateString & "#)<=0)"
                sql &= " and idrub not in (select distinct idrub from t_ordini where  datediff(d,'" & NonSpendonoDal.Day & "/" & NonSpendonoDal.Month & "/" & NonSpendonoDal.Year & "',datains)>=0 and datediff(d,datains,'" & NonSpendonoAl.Day & "/" & NonSpendonoAl.Month & "/" & NonSpendonoAl.Year & "')>=0)"

            End If

            'If OnlyOrder Then
            '    sql &= " AND IDRUB IN (SELECT IDRUB FROM T_ORDINI) "
            'End If

            If IdGruppo Then
                sql &= " AND IDRUB IN (SELECT IDRUB FROM TR_GRUPRUBR WHERE IDGRUPPO= " & IdGruppo & ")"
            End If

            'sql &= " AND Tipo =" & enTipoRubrica.Cliente

            sql &= " order by RagSoc"

            Lst = GetData(sql)

            'select  Switch([IdAgente]=1, "IBM",[IdAgente]=2, "HP", [IdAgente]=3, "Nvidia") as ag  from t_acquisizione

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Lst
    End Function

    Public Function ListaGruppo(IdGruppo As Integer) As DataTable

        Dim dt As DataTable = Nothing

        Using g As New Gruppo
            g.Read(IdGruppo)
            dt = ListaGruppo(IIf(g.RagSoc.Length, g.RagSoc, ""),
                            IIf(g.Citta.Length, g.Citta, ""),
                            IIf(g.Cap.Length, g.Cap, ""), 0,
                            g.HannoAcqAlmenoUn,
                            g.NonHannoMaiAcqUn,
                            g.IdCorrierePredefinito,
                            IIf(g.LimiteMassimoSuperato = enSiNo.Si, True, False), ,
                            g.DocumentiInScadenzaDal,
                            g.DocumentiInScadenzaAl,
                            g.SpesaNelPeriodoMinoreDi,
                            g.SpesaNelPeriodoMaggioreDi,
                            g.SpesaNelPeriodo,
                            g.HannoSpesoDal,
                            g.HannoSpesoAl,
                            g.NonHannoSpesoDal,
                            g.NonHannoSpesoAl,
                            g.Tipo,
                            g.RegistratiDal,
                            IIf(g.SoloRegistratiDalSito = enSiNo.Si, True, False),
                             g.tag)
        End Using

        Return dt

    End Function

    Public Function ListaGruppo(Optional ByVal RagSoc As String = "",
                                Optional ByVal Citta As String = "",
                                Optional ByVal CAP As String = "",
                                Optional ByVal IdGruppo As Integer = 0,
                                Optional ByVal IdProdAcq As Integer = 0,
                                Optional ByVal IdProdNonAcq As Integer = 0,
                                Optional ByVal IdCorrPred As Integer = 0,
                                Optional ByVal LimiteSuperato As Boolean = False,
                                Optional ByVal PagamSospesi As Boolean = False,
                                Optional ByVal PSospDal As Date = Nothing,
                                Optional ByVal PSospAl As Date = Nothing,
                                Optional ByVal SpesoMinDi As Decimal = 0,
                                Optional ByVal SpesoMaxDi As Decimal = 0,
                                Optional ByVal SpesoPeriodo As Integer = 0,
                                Optional ByVal SpendonoDal As Date = Nothing,
                                Optional ByVal SpendonoAl As Date = Nothing,
                                Optional ByVal NonSpendonoDal As Date = Nothing,
                                Optional ByVal NonSpendonoAl As Date = Nothing,
                                Optional ByVal IdTipo As Integer = 0,
                                Optional ByVal RegistratiDal As Date = Nothing,
                                Optional SoloDalSito As Boolean = False,
                                Optional Tag As String = "") As DataTable

        Dim datatb As DataTable = New DataTable("TabellaRis")
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT IdRub as Id, CASE WHEN Ragsoc = '' THEN Cognome + ' ' + Nome ELSE Ragsoc END as [Ragione Sociale], Email, Indirizzo, Citta, Cap from T_Rubrica "
                sql &= " WHERE status= " & enStato.Attivo

                If RagSoc.Length Then

                    sql &= " AND Ragsoc " & IIf(RagSoc.Length = 1, ApLikeRight(RagSoc), ApLike(RagSoc))
                    'sql &= " OR Cognome " & IIf(RagSoc.Length = 1, ApLikeRight(RagSoc), ApLike(RagSoc))
                    'sql &= " OR Nome " & IIf(RagSoc.Length = 1, ApLikeRight(RagSoc), ApLike(RagSoc)) & ")"

                End If

                If IdTipo Then
                    sql &= " AND tipo = " & IdTipo
                End If

                If Citta.Length Then
                    sql &= " AND citta = " & Ap(Citta)
                End If

                If CAP.Length Then
                    sql &= " AND cap = " & Ap(CAP)
                End If

                If IdProdAcq Then

                    sql &= " AND IDRUB IN (SELECT DISTINCT IdRub FROM T_Ordini WHERE IDPROD IN (SELECT IDPROD FROM T_PRODOTTI WHERE IDCATPROD= " & IdProdAcq & ")) "

                End If

                If IdProdNonAcq Then

                    sql &= " AND IDRUB NOT IN (SELECT DISTINCT IdRub FROM T_Ordini WHERE IDPROD IN (SELECT IDPROD FROM T_PRODOTTI WHERE IDCATPROD= " & IdProdNonAcq & ")) "

                End If

                If IdCorrPred Then

                    sql &= " AND idcorriere = " & IdCorrPred

                End If

                If LimiteSuperato Then

                    'SELECT sum(prezzo) as totale FROM T_Ordini where IdRub = " & _IdRub & " AND stato >= " & enStatoOrdine.Registrato & " and stato <= " & enStatoOrdine.InConsegna
                    sql &= " AND IDRUB IN (select idrub from (select o.idrub,max( scopertomax) as scop,sum(prezzo) as tot from t_rubrica r, t_ordini o where r.idrub= o.idrub group by o.idrub)a where a.scop<>0 and a.scop<tot)"

                End If

                If PagamSospesi Then

                    sql &= " AND IDRUB IN ("
                    sql &= "select distinct idrub from t_contabricavi where  datediff(d,CONVERT(datetime,'" & PSospDal.Day & "/" & PSospDal.Month & "/" & PSospDal.Year & "',103)',dataprevpagam)>=0 and datediff(d,dataprevpagam,'" & PSospAl.Day & "/" & PSospAl.Month & "/" & PSospAl.Year & "')>=0 )"

                End If

                'qui devo controllare il massimale di spesa fatta
                If SpesoMinDi Then
                    Dim dataRif As String = ""
                    Select Case SpesoPeriodo
                        Case enPeriodoRiferimento.UnMese ' trimestre
                            dataRif = " datediff(m,datains,getdate()) <= 1 "
                        Case enPeriodoRiferimento.TreMesi  ' trimestre
                            dataRif = " datediff(m,datains,getdate()) <= 3 "
                        Case enPeriodoRiferimento.SeiMesi ' semestre
                            dataRif = " datediff(m,datains,getdate()) <= 6 "
                        Case enPeriodoRiferimento.UnAnno 'anno
                            dataRif = " datediff(m,datains,getdate()) <= 12 "
                    End Select

                    sql &= "and idrub in (select distinct idrub from (select idrub, sum(prezzo) as totale from t_ordini where " & dataRif & " group by idrub) a where  a.totale <" & SpesoMinDi & ")"

                End If

                If SpesoMaxDi Then
                    Dim dataRif As String = ""
                    Select Case SpesoPeriodo
                        Case enPeriodoRiferimento.UnMese ' trimestre
                            dataRif = " datediff(m,datains,getdate()) <= 1 "
                        Case enPeriodoRiferimento.TreMesi ' trimestre
                            dataRif = " datediff(m,datains,getdate()) <= 3 "
                        Case enPeriodoRiferimento.SeiMesi ' semestre
                            dataRif = " datediff(m,datains,getdate()) <= 6 "
                        Case enPeriodoRiferimento.UnAnno  'anno
                            dataRif = " datediff(m,datains,getdate()) <= 12 "
                    End Select

                    sql &= " and idrub in (select distinct idrub from (select idrub, sum(prezzo) as totale from t_ordini where " & dataRif & " group by idrub) a where  a.totale >" & SpesoMaxDi & ")"

                End If

                If Not SpendonoDal = Date.MinValue Then
                    'sql &= " and idrub in (select distinct idrub from t_ordini where  datediff('d',datains,'" & SpendonoDal.day & "/" & SpendonoDal.Month & "/" & SpendonoDal.Year  & "')>=0 and datediff('d',datains,#" & SpendonoAl.ToShortDateString & "#)<=0 )"
                    sql &= " and idrub in (select distinct idrub from t_ordini where  datediff(d,CONVERT(datetime,'" & SpendonoDal.Day & "/" & SpendonoDal.Month & "/" & SpendonoDal.Year & "',103),datains)>=0 and datediff(d,datains,CONVERT(datetime,'" & SpendonoAl.Day & "/" & SpendonoAl.Month & "/" & SpendonoAl.Year & "',103))>=0 )"

                End If

                If Not RegistratiDal = Date.MinValue Then
                    sql &= " and datediff(d,'" & RegistratiDal.Day & "/" & RegistratiDal.Month & "/" & RegistratiDal.Year & "',datains)>=0 "
                End If

                If Not NonSpendonoDal = Date.MinValue Then
                    'sql &= " and idrub not in (select distinct idrub from t_ordini where  datediff('d',datains,#" & NonSpendonoDal.ToShortDateString & "#)>=0 and datediff('d',datains,#" & NonSpendonoAl.ToShortDateString & "#)<=0)"
                    sql &= " and idrub not in (select distinct idrub from t_ordini where  datediff(d,CONVERT(datetime,'" & NonSpendonoDal.Day & "/" & NonSpendonoDal.Month & "/" & NonSpendonoDal.Year & "',103),datains)>=0 and datediff(d,datains,CONVERT(datetime,'" & NonSpendonoAl.Day & "/" & NonSpendonoAl.Month & "/" & NonSpendonoAl.Year & "',103))>=0)"

                End If

                'If OnlyOrder Then
                '    sql &= " AND IDRUB IN (SELECT IDRUB FROM T_ORDINI) "
                'End If

                If IdGruppo Then
                    sql &= " AND IDRUB IN (SELECT IDRUB FROM TR_GRUPRUBR WHERE IDGRUPPO= " & IdGruppo & ")"
                End If

                If SoloDalSito Then
                    sql &= " AND Sorgente = 'W'"
                End If

                If Tag.Trim.Length Then
                    sql &= " AND tag like '%" & Tag.Trim & "%'"
                End If

                'sql &= " AND Tipo =" & enTipoRubrica.Cliente

                'AGGIUNGO SOLO QUELLI CHE HANNO LA MAIL 
                sql &= " and (len(email) <>0 and email<>'" & FormerLib.FormerConst.EmailNonDisponibile & "')"

                sql &= " order by RagSoc"

                myCommand.CommandText = sql
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    datatb.Load(myReader)
                    myReader.Close()
                End Using
            End Using

            'select  Switch([IdAgente]=1, "IBM",[IdAgente]=2, "HP", [IdAgente]=3, "Nvidia") as ag  from t_acquisizione

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return datatb
    End Function

    Public Function ListaDT(ByVal ShowForn As Boolean, ByVal ShowCli As Boolean, ByVal ShowRiv As Boolean, ByVal ShowAge As Boolean, Optional ByVal Cerca As String = "", Optional ByVal OnlyOrder As Boolean = False, Optional ByVal IdGruppo As Integer = 0, Optional ByVal IdMark As Integer = 0, Optional ByVal OnlyNonComp As Boolean = False) As DataTable
        Dim datatb As DataTable = New DataTable("T_Rubrica")
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT IdRub as Codice,RagSoc as [Ragione Sociale],Cognome, Nome, Piva as [Partita Iva], CodFisc as [Codice Fiscale],Email, Tel, Fax, Cellulare,Indirizzo, Citta, Cap,"
                sql &= " (SELECT CASE Tipo when " & enTipoRubrica.Cliente &
                    "then 'Cliente' when " & enTipoRubrica.Rivenditore &
                    "then 'Rivenditore' end) as [Tipo Voce]"

                'sql &= " Switch([Tipo]=" & enTipoRubrica.Cliente & _
                '    ", ""Cliente"",[Tipo]=" & enTipoRubrica.Agente & _
                '    ", ""Agente"", [Tipo]=" & enTipoRubrica.Fornitore & _
                '    ", ""Fornitore"", [Tipo]=" & enTipoRubrica.Rivenditore & _
                '    ",""Rivenditore"") as [Tipo Voce]"
                'sql &= " iif(Tipo= " & enTipoRubrica.Cliente & ",'Cliente','Fornitore') as [Tipo Voce] from T_Rubrica "
                sql &= " from T_Rubrica "
                sql &= " WHERE status= " & enStato.Attivo

                If Cerca.Length Then

                    sql &= " AND (Ragsoc " & IIf(Cerca.Length = 1, ApLikeRight(Cerca), ApLike(Cerca))
                    sql &= " OR Cognome " & IIf(Cerca.Length = 1, ApLikeRight(Cerca), ApLike(Cerca))
                    sql &= " OR Nome " & IIf(Cerca.Length = 1, ApLikeRight(Cerca), ApLike(Cerca))
                    sql &= " OR PIVA = " & Ap(Cerca)
                    sql &= " OR CODFISC = " & Ap(Cerca) & ")"

                End If

                sql &= " AND TIPO IN ("

                If ShowCli Then
                    sql &= enTipoRubrica.Cliente & ","
                End If

                'If ShowAge Then
                '    sql &= enTipoRubrica.Agente & ","
                'End If

                If ShowRiv Then
                    sql &= enTipoRubrica.Rivenditore & ","
                End If

                sql &= "0)"


                If ShowForn Then
                    sql &= " AND IsFornitore = " & enSiNo.Si
                End If

                If OnlyOrder Then
                    sql &= " AND IDRUB IN (SELECT IDRUB FROM T_ORDINI) "
                End If

                If IdGruppo Then
                    sql &= " AND IDRUB IN (SELECT IDRUB FROM TR_GRUPRUBR WHERE IDGRUPPO= " & IdGruppo & ")"
                End If

                If IdMark Then
                    'se c'e' il marketing devo anche tenere conto del parametro OnlyNonComp
                    sql &= " AND (IDRUB IN (SELECT IDRUB FROM TR_GRUPRUBR WHERE IDGRUPPO= (select idgruppo from t_marketing where idmark= " & IdMark & "))"

                    'qui
                    If OnlyNonComp Then

                        sql &= " AND IDRUB not in (SELECT IDRUB FROM T_MarkAz where idmarketing= " & IdMark & ") "

                    End If
                    sql &= ")"
                End If


                sql &= " order by RagSoc"

                myCommand.CommandText = sql
                Using myReader As SqlDataReader = myCommand.ExecuteReader()

                    'metodo 1 tornare una datatable.

                    'Dim date1 As String = Now.Minute & "." & Now.Second & "." & Now.Millisecond

                    datatb.Load(myReader)

                    'Dim date2 As String = Now.Minute & "." & Now.Second & "." & Now.Millisecond
                    'Stop

                    myReader.Close()
                End Using
            End Using

            'select  Switch([IdAgente]=1, "IBM",[IdAgente]=2, "HP", [IdAgente]=3, "Nvidia") as ag  from t_acquisizione

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return datatb
    End Function

    Public Function ListaCombo(ByVal TipoRub As enTipoRubrica,
                               ByVal ShowAll As Boolean,
                               Optional ByVal ListaSpecifica As String = "",
                               Optional ByVal Iniziale As String = "",
                               Optional ByVal IdRub As Integer = 0,
                               Optional ByVal TestoLibero As String = "",
                               Optional SoloDisponibiliOnline As Boolean = False,
                               Optional IsFornitore As Boolean = False) As List(Of VoceRubrica)

        Dim lst As New List(Of VoceRubrica)
        Try


            Dim sql As String = ""

            sql = "SELECT * from T_Rubrica "
            sql &= " WHERE status= " & enStato.Attivo

            If TipoRub Then
                If TipoRub = enTipoRubrica.Cliente Then
                    sql &= " AND TIPO IN (" & enTipoRubrica.Cliente & "," & enTipoRubrica.Rivenditore & ")"
                Else
                    sql &= " AND TIPO = " & TipoRub
                End If
            End If

            If IsFornitore Then
                sql &= " AND IsFornitore = " & enSiNo.Si
            End If


            If Not ListaSpecifica Is Nothing AndAlso ListaSpecifica.Length Then
                Select Case ListaSpecifica
                    Case "DDT"
                        'carico la lista solo di clienti che hanno ddt aperti 
                        sql &= " AND IDRUB IN (SELECT DISTINCT IDRUB FROM T_CONTABRICAVI WHERE TIPO= " & enTipoDocumento.DDT & " AND (IDDOCRIF=0 or IDDOCRIF IS NULL))"

                    Case "ORD"
                        'carico la lista solo di clienti che hanno ordini
                        sql &= " AND IDRUB IN (SELECT DISTINCT IDRUB FROM T_ORDINI)"

                    Case "ORDSTAMPA"
                        'carico la lista solo di clienti che hanno ordini
                        sql &= " AND IDRUB IN (SELECT DISTINCT IDRUB FROM T_ORDINI WHERE STATO= " & enStatoOrdine.UscitoMagazzino & ")"

                    Case "ORDOPERATORE"
                        'carico la lista solo di clienti che hanno ordini
                        sql &= " AND IDRUB IN (SELECT DISTINCT IDRUB FROM T_ORDINI WHERE STATO IN (" & enStatoOrdine.ProntoRitiro & "," & enStatoOrdine.Imballaggio & "," & enStatoOrdine.StampaInizio & "," & enStatoOrdine.Registrato & ") AND IDCOM<>0 )"

                    Case "CONSEGNE"
                        'carico la lista solo di clienti che hanno ordini
                        sql &= " AND IDRUB IN (SELECT DISTINCT IDRUB FROM T_ORDINI WHERE STATO NOT IN (" & enStatoOrdine.InConsegna & "," & enStatoOrdine.Consegnato & "," & enStatoOrdine.PagatoInteramente & ") and idord not in (SELECT IDORD FROM TR_CONSORD))"

                    Case "CONSPROGR"
                        sql &= " AND IDRUB IN (SELECT DISTINCT IDRUB FROM T_CONS)"

                    Case "AdminOnlyOrd"
                        'carico solo i clienti che hanno almeno un ordine dallo stato preinserito allo stato prontoper il ritiro
                        sql &= " AND IDRUB IN (SELECT DISTINCT IDRUB FROM T_ORDINI WHERE STATO IN(" &
                            enStatoOrdine.Registrato & "," &
                            enStatoOrdine.InSospeso & "," &
                            enStatoOrdine.InCodaDiStampa & "," &
                            enStatoOrdine.StampaInizio & "," &
                            enStatoOrdine.StampaFine & "," &
                            enStatoOrdine.FinituraCommessaInizio & "," &
                            enStatoOrdine.FinituraCommessaFine & "," &
                            enStatoOrdine.FinituraProdottoInizio & "," &
                            enStatoOrdine.FinituraProdottoFine & "," &
                            enStatoOrdine.Imballaggio & "," &
                            enStatoOrdine.ImballaggioCorriere & "," &
                            enStatoOrdine.ProntoRitiro & "))"
                    Case "AlberoOperatoreConsegna"
                        'carico solo i clienti che hanno almeno un ordine dallo stato preinserito allo stato prontoper il ritiro
                        sql &= " AND IDRUB IN (SELECT DISTINCT IDRUB FROM T_ORDINI WHERE STATO IN(" &
                            enStatoOrdine.Registrato & "," &
                            enStatoOrdine.InSospeso & "," &
                            enStatoOrdine.InCodaDiStampa & "," &
                            enStatoOrdine.StampaInizio & "," &
                            enStatoOrdine.StampaFine & "," &
                            enStatoOrdine.FinituraCommessaInizio & "," &
                            enStatoOrdine.FinituraCommessaFine & "," &
                            enStatoOrdine.FinituraProdottoInizio & "," &
                            enStatoOrdine.FinituraProdottoFine & "," &
                            enStatoOrdine.Imballaggio & "," &
                            enStatoOrdine.ImballaggioCorriere & "," &
                            enStatoOrdine.ProntoRitiro & "))"

                    Case "SituazioneContabileGenerale"
                        sql &= " AND IDRUB IN (Select ID from (SELECT f.Id,RagSoc as RagioneSociale,Conteggiodiidord as NumOrdini,iif(Espr1 is null,0,Espr1) " &
                " as TotaleOrdini,MinDiDataIns as DataMinima,MaxDiDataIns as DataMassima,AncoraDaIncassare,g.DataUltimoPag," &
                " iif(Espr1 is null, 0,Espr1)+ iif(AncoraDaIncassare is null, 0, AncoraDaincassare) as TotaleScoperto " &
                " from (SELECT top 1 T_rubrica.idrub as id,T_Rubrica.RagSoc, Count(T_Ordini.IdOrd) AS ConteggioDiIdOrd," &
                " Sum([TotaleForn]+[Ricarico]-[Sconto]) AS Espr1, Min(T_Ordini.DataIns) AS MinDiDataIns, Max(T_Ordini.DataIns) AS MaxDiDataIns"

                        sql &= " FROM T_Rubrica LEFT JOIN (SELECT * from T_Ordini WHERE STATO IN(" & enStatoOrdine.ProntoRitiro & "," & enStatoOrdine.UscitoMagazzino & ")) as ORdini ON T_Rubrica.IdRub =  Ordini.IdRub "
                        sql &= " GROUP BY T_Rubrica.RagSoc, ordini.Stato"
                        sql &= " ) as f"

                        sql &= " left join ("
                        sql &= " select a.idrub as id,round(dapagare,2)-round(pagati,2) as AncoraDaIncassare,DataUltimoPag from (select c.idrub,sum(totale) as dapagare from t_contabricavi c where tipo =1 OR TIPO = 3 OR TIPO = 4 OR (TIPO= 2 AND IDDOCRIF IS NULL)  group by c.idrub) as a inner join (select p.idrub,sum(importo) as pagati,max(p.DataPag) as DataUltimoPag from t_pagamenti p group by p.idrub) as b on a.idrub=b.idrub) as g "
                        sql &= " on f.id= g.id) "
                        sql &= " where (totaleordini<>0 or totalescoperto<>0)) "


                    Case "OnlineOnly"
                        sql &= " and (IdUtOnline <> 0 and not idUtOnline is null)"
                    Case "ONLYWITHDDT"
                        sql &= " and IdRub IN (SELECT DISTINCT IdRub FROM T_ContabCosti WHERE IdDocRif = 0 AND Tipo = " & enTipoDocumento.DDT & ")"

                End Select
            End If

            If Iniziale.Length And Iniziale <> "*" Then

                sql &= " AND RagSoc like '" & Iniziale & "%' "

            End If

            If TestoLibero.Length Then

                sql &= " AND ((RagSoc  " & ApLike(TestoLibero) & ") or (Cognome  " & ApLike(TestoLibero) & ") or (Nome " & ApLike(TestoLibero) & ") or (Email " & ApLike(TestoLibero) & ")"

                If IsNumeric(TestoLibero) Then

                    sql &= " or (idrub = " & TestoLibero & ")  or (Tel " & ApLike(TestoLibero) & ") or (Fax  " & ApLike(TestoLibero) & ") or (Cellulare  " & ApLike(TestoLibero) & ") or (Piva  " & ApLike(TestoLibero) & ")"

                End If

                If TestoLibero.StartsWith("#") Then

                    sql &= " OR TAG " & ApLike(TestoLibero)

                End If

                sql &= ")"

            End If

            If IdRub Then
                sql &= " AND idrub = " & IdRub
            End If

            If SoloDisponibiliOnline Then
                sql &= " AND idUtOnline <> 0 "
            End If

            sql &= " order by iif(RagSoc<>'',RagSoc + ' - ','') + ' - ' + Cognome + ' ' +  Nome "

            lst = GetData(sql, ShowAll)
            lst.Sort(Function(x, y) x.RagSocNome.CompareTo(y.RagSocNome))
        Catch ex As Exception
            ManageError(ex)
        End Try
        Return lst
    End Function

    Public Function Exists(ByVal Valore As String, ByVal TipoRicerca As enTipoRicercaRub, ByVal IdRif As Integer) As Boolean
        Dim Ris As Boolean = False

        If Valore.Trim.Length Then

            Try

                Dim myCommand As SqlCommand = _cn.CreateCommand()
                Dim sql As String = ""
                sql = "SELECT IdRub FROM T_Rubrica "
                sql &= " WHERE status= " & enStato.Attivo
                Select Case TipoRicerca
                    Case enTipoRicercaRub.RagioneSociale
                        sql &= " AND Ragsoc = " & Ap(Valore)
                    Case enTipoRicercaRub.Cognome
                        sql &= " AND Cognome = " & Ap(Valore)
                    Case enTipoRicercaRub.PartitaIva
                        sql &= " AND Piva = " & Ap(Valore)
                    Case enTipoRicercaRub.CodiceFiscale
                        sql &= " AND Codfisc = " & Ap(Valore)
                End Select

                sql &= " AND IDRUB <>" & IdRif

                myCommand.CommandText = sql
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()

                myReader.Read()

                Ris = myReader.HasRows

                myReader.Close()
                myCommand.Dispose()

            Catch ex As Exception
                ManageError(ex)
            End Try
        End If
        Return Ris
    End Function

    Public Function CalcolaScopertoOld(R As VoceRubrica) As Decimal

        Dim Ris As Decimal = 0

        Ris = MgrSituazioneCliente.GetSituazioneCliente(R.IdRub).TotaleScopertoComplessivo

        'Dim myCommand As SqlCommand = _Cn.CreateCommand()
        'Dim sql As String = "SELECT sum(Importo) as tot FROM T_Pagamenti where IdRub = " & R.IdRub
        'Dim TotalePagato As Decimal = 0
        'myCommand.CommandText = sql
        'Dim myReader As SqlDataReader = myCommand.ExecuteReader()
        'myReader.Read()
        'If Not IsDBNull(myReader("tot")) Then TotalePagato = Math.Round(myReader("Tot"), 2)

        'Dim TotaleDaPagare As Decimal = 0

        'sql = "SELECT SUM(Totale) as Tot from t_CONTABRICAVI WHERE IDRUB= " & R.IdRub
        'sql &= " AND (tipo <> " & enTipoDocumento.DDT & " Or (tipo = " & enTipoDocumento.DDT & " AND IDDOCRIF =0 or IDDOCRIF = null))"
        'myReader.Close()
        'myCommand.Dispose()
        'myCommand = _Cn.CreateCommand()
        'myCommand.CommandText = sql
        'myReader = myCommand.ExecuteReader()
        'myReader.Read()
        'If Not IsDBNull(myReader("tot")) Then TotaleDaPagare = Math.Round(myReader("Tot"), 2)

        'sql = "select sum((TotaleForn +ricarico -sconto)) as tot  from t_ordini where (iddoc =0 or iddoc = null) and stato IN (" & enStatoOrdine.UscitoMagazzino & "," & enStatoOrdine.ProntoRitiro & ") and idrub = " & R.IdRub
        'myReader.Close()
        'myCommand.Dispose()
        'myCommand = _Cn.CreateCommand()
        'myCommand.CommandText = sql
        'myReader = myCommand.ExecuteReader()
        'myReader.Read()
        'If Not IsDBNull(myReader("tot")) Then TotaleDaPagare += Math.Round(myReader("Tot"), 2)


        'Ris = TotaleDaPagare - TotalePagato

        'Ris = Math.Round(Ris, 2)

        Return Ris

    End Function

    Public Function ListaClientiByCambioStato() As List(Of VoceRubrica)

        Dim sql As String = "SELECT * from T_Rubrica where status = " & enStato.Attivo & " and not LastUpdate is null"
        'Dim sql As String = "SELECT * from T_Rubrica where status = " & enStato.Attivo & " and datediff('n','" & DataUltimoAggiornamento & "',LastUpdate)>0"
        Dim ris As List(Of VoceRubrica) = GetData(sql)
        Return ris

    End Function

End Class