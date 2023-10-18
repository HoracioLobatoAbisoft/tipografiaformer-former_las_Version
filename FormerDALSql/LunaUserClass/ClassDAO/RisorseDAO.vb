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
Imports System.Data.Common

''' <summary>
'''DAO Class for table T_risorse
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class RisorseDAO
    Inherits _RisorseDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una risorsa"

    Public Function GetSoggetti(F As Formato,
                                R As Risorsa) As Integer
        Dim TotSoggetti As Integer = 1
        Try
            Dim TotVerticale As Integer = 0
            Dim TotOrizzontale As Integer = 0

            Dim Colonne As Integer = 0
            Dim Righe As Integer = 0

            Colonne = Math.Floor(R.Larghezza / F.Larghezza)
            Righe = Math.Floor(R.Lunghezza / F.Altezza)

            If Colonne > 0 And Righe > 0 Then
                TotOrizzontale = Colonne * Righe
            End If

            Colonne = Math.Floor(R.Larghezza / F.Altezza)
            Righe = Math.Floor(R.Lunghezza / F.Larghezza)

            If Colonne > 0 And Righe > 0 Then
                TotVerticale = Colonne * Righe
            End If

            If TotOrizzontale > TotVerticale Then
                TotSoggetti = TotOrizzontale
            Else
                TotSoggetti = TotVerticale
            End If
        Catch ex As Exception

        End Try


        If TotSoggetti = 0 Then TotSoggetti = 1

        Return TotSoggetti
    End Function

    Public Function Lista(ByVal IdCom As Integer,
                          ByVal TipoRis As Integer,
                          ByVal MostraAncheNonDisponibili As Boolean) As List(Of Risorsa)

        Dim L As IEnumerable(Of Risorsa) = Nothing

        Dim sql As String = ""
        sql = "Select * "

        sql &= "from T_Risorse "

        sql &= " where tiporis = " & TipoRis

        sql &= " And IsLastra = " & enSiNo.No

        sql &= " And Stato = " & enStato.Attivo

        If MostraAncheNonDisponibili = False Then
            sql &= " And Giacenza > 0 "
        End If

        'TODO: RIATTIVARE QUANDO PRENDEREMO IN CONSIDERAZIONE LA GIACENZA
        'sql &= " And Giacenza <>0"

        sql &= " And IDRIS Not In (Select IDRIS FROM T_MAGAZ WHERE IDCOM = " & IdCom & " And idcom<>0 And idfat=0)"

        sql &= " ORDER BY Descrizione"

        L = GetData(sql)

        Return L

    End Function

    Public Function Cerca(Optional ByVal Testo As String = "",
                          Optional ByVal Categoria As String = "",
                          Optional ByVal Barcode As String = "",
                          Optional ByVal OnlyDisponibili As Boolean = False,
                          Optional TipoNonSpecificato As Boolean = False,
                          Optional AnnoDiAcquisto As Integer = 0,
                          Optional IdAziendaAcquisto As Integer = 0,
                          Optional IdTipoCartaListino As Integer = 0) As List(Of Risorsa)

        Dim L As IEnumerable(Of Risorsa) = Nothing

        Dim sql As String = ""
        sql = "Select * "

        sql &= "from T_Risorse "

        sql &= " where 1 = 1 "

        If Categoria.Length Then
            sql &= " And Categoria = " & Ap(Categoria)
        End If

        If Barcode.Length Then
            sql &= " And Barcode = " & Ap(Barcode)
        End If

        If Testo.Length Then
            sql &= " And ((Codice " & ApLike(Testo.Trim) & " OR Descrizione " & ApLike(Testo.Trim) & ")"
            sql &= " OR (IdRis IN (SELECT DISTINCT IdRis from T_Magaz WHERE CodiceForn " & ApLike(Testo.Trim) & " OR DescrForn " & ApLike(Testo.Trim) & "))"

            If IsNumeric(Testo) Then
                sql &= " OR IdRis = " & Testo
            End If

            sql &= ")"

        End If

        If OnlyDisponibili Then

            sql &= " And Stato = " & enStato.Attivo
            sql &= " And Giacenza > 0 "

        End If

        If IdTipoCartaListino Then
            sql &= " AND IdTipoCarta = " & IdTipoCartaListino
        End If

        If TipoNonSpecificato Then
            sql &= " And tipoRis =  " & enTipoProdCom.NonSpecificato
        End If

        If AnnoDiAcquisto Then
            If AnnoDiAcquisto = FormerLib.FormerConst.Fiscali.IdBiennio Then
                sql &= " AND IdRis in (select distinct idris from t_magaz where tipomov = " & enTipoMovMagaz.Carico & " AND year(datamov) in (" & Now.Year & "," & (Now.Year - 1) & "))"
            Else
                sql &= " AND IdRis in (select distinct idris from t_magaz where tipomov = " & enTipoMovMagaz.Carico & " AND year(datamov) =  " & AnnoDiAcquisto & ")"
            End If
        End If

        If IdAziendaAcquisto Then

            sql &= " AND IdRis IN (select distinct m.idris from t_magaz m inner join t_contabcosti c on m.idfat = c.idcosto where tipomov = " & enTipoMovMagaz.Carico & " and c.idazienda = " & IdAziendaAcquisto & ")"

        End If

        sql &= " ORDER BY Descrizione"

        L = GetData(sql)

        Return L

    End Function

    Public Function GetCategorie() As List(Of String)
        Dim ris As New List(Of String)
        ris.Add("")

        Try
            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.CommandText = "SELECT DISTINCT (Categoria) FROM T_Risorse where not categoria is null ORDER BY Categoria"
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As DbDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        If IsDBNull(myReader("Categoria")) = False Then
                            Dim Valore As String = StrConv(myReader("Categoria").ToString, VbStrConv.ProperCase)
                            If ris.FindAll(Function(x) x = Valore).Count = 0 Then

                                ris.Add(Valore)
                            End If

                        End If

                    End While
                    myReader.Close()
                End Using
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

        Return ris
    End Function

    Public Sub LeggiQta(R As Risorsa)
        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = "select Giacenza from T_Risorse where IdRis = " & R.IdRis
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            myReader.Read()
            If myReader.HasRows Then
                R.Giacenza = myReader("Giacenza")
            End If
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Function FindAllRicerca(IdTipoCarta As Integer, Testo As String) As List(Of RisorsaRicerca)
        Dim L As New List(Of RisorsaRicerca)
        Try

            Using myCommand As SqlCommand = _Cn.CreateCommand()
                Dim sql As String = ""
                sql = "select * from t_risorse "
                sql &= " where islastra = " & enTipoRisOffSet.MateriaPrima
                'sql &= " and tiporis = " & enTipoProdCom.StampaOffSet
                sql &= " and IdTipoCarta <> " & IdTipoCarta

                If Testo.Trim.Length Then
                    sql &= " and descrizione " & ApLike(Testo)
                End If

                'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
                sql &= " Order by Grammatura, descrizione"

                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim classe As New RisorsaRicerca(CType(myReader, IDataRecord))
                        L.Add(classe)
                    End While
                End Using
            End Using

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return L
    End Function

    Public Function GetLastraPerMacchinario(IdMacchinario As Integer) As Risorsa
        Dim ris As Risorsa = Nothing

        Using mgr As New RisorseDAO
            Dim l As List(Of Risorsa) = mgr.FindAll("Giacenza Desc",
                                                    New LUNA.LunaSearchParameter(LFM.Risorsa.IsLastra, enSiNo.Si),
                                                    New LUNA.LunaSearchParameter(LFM.Risorsa.Stato, enStato.Attivo),
                                                    New LUNA.LunaSearchParameter(LFM.Risorsa.Giacenza, "0", ">"))
            If l.Count = 0 Then
                l = mgr.FindAll("Giacenza Desc",
                                New LUNA.LunaSearchParameter(LFM.Risorsa.IsLastra, enSiNo.Si),
                                New LUNA.LunaSearchParameter(LFM.Risorsa.Stato, enStato.Attivo))
            End If
            For Each singRis As Risorsa In l
                If singRis.ListaMacchinari.FindAll(Function(x) x.IdMacchinario = IdMacchinario).Count Then
                    ris = singRis
                    Exit For
                End If
            Next
        End Using

        Return ris
    End Function

    Public Function CalcolaRisorseNecessarie(IdCom As Integer) As List(Of RisUtilizzoRisorsaOld)

        Dim lRis As New List(Of RisUtilizzoRisorsaOld)

        Using C As New Commessa
            C.Read(IdCom)

            Dim CopieDiStampa As Integer = C.Copie
            Dim IdRisPrincipale As Integer = 0

            Dim TipiCartaUsati As New Dictionary(Of Integer, Integer)

            For Each O As Ordine In C.ListaOrdini
                Dim Conteggio As Integer = 0
                If TipiCartaUsati.TryGetValue(O.ListinoBase.IdTipoCarta, Conteggio) Then
                    TipiCartaUsati(O.ListinoBase.IdTipoCarta) += 1
                Else
                    TipiCartaUsati.Add(O.ListinoBase.IdTipoCarta, 1)
                End If
            Next
            'qui devo ordinarlo in maniera da prendere il piu usato
            TipiCartaUsati.OrderByDescending(Function(x) x.Value)

            IdRisPrincipale = TipiCartaUsati.First.Key

            Using T As New TipoCarta
                T.Read(IdRisPrincipale)
            End Using

        End Using

        'qui devo calcolare anche le risorse per copertina e sottoblocco se presenti

        Return lRis

    End Function

End Class