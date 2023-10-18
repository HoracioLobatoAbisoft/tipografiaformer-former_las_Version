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
'''DAO Class for table T_lavori
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class LavorazioniDAO
    Inherits _LavorazioniDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Sub DeleteAllLbProduzione()
        Try

            Using UpdateCommand As SqlCommand = New SqlCommand()
                UpdateCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE Tr_prevlistino SET DELETED=True "
                Dim Sql As String = "delete from TR_LavPrev "
                Sql &= " Where IDLISTINOBASE IN (SELECT DISTINCT IDLISTINOBASE FROM T_LISTINOBASE WHERE IDLISTINOBASESOURCE<>0 And Disattivo = " & enSiNo.No & ")"

                UpdateCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                UpdateCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub


    Public Function ListaLavorazioniInCat() As List(Of LavorazioneInCat)

        Dim Ls As List(Of LavorazioneInCat) = New List(Of LavorazioneInCat)
        Try

            Dim L As List(Of LavorazioneEx) = Nothing
            Using Mgr As New LavorazioniDAO
                L = Mgr.ListaLavorazioni()
            End Using
            For Each lav As LavorazioneEx In L
                Dim lC As New LavorazioneInCat
                lC.LavorazioneStr = lav.Descrizione
                lC.Importo = lav.Prezzo
                Ls.Add(lC)

            Next

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ls

    End Function

    Public Function ListaLavorazioni(IdOrd As Integer) As List(Of Lavorazione)
        Dim ris As List(Of Lavorazione) = Nothing
        Try
            Dim sql As String = String.Empty
            sql = "SELECT * FROM T_Lavori l, T_lavlog ll WHERE ll.idord = " & IdOrd & " AND l.idlavoro = ll.idlav ORDER BY ll.ordine"

            ris = GetData(sql)
        Catch ex As Exception
            ManageError(ex)
        End Try
        Return ris


    End Function

    Public Function ListaIdLavorazioniSuOrdine(IdOrd As Integer,
                                               IdCom As Integer) As List(Of Integer)
        Dim Ls As List(Of Integer) = New List(Of Integer)
        Try

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT ll.IdLav FROM T_LAVLOG ll, t_lavori l WHERE ll.idlav = l.idlavoro and l.lavorazioneinterna = " & enSiNo.No & " and (ll.idord = " & IdOrd

            If IdCom Then
                sql &= " or ll.Idcom = " & IdCom
            End If
            sql &= ")"


            sql &= " Order by ll.Ordine "

            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read

                Ls.Add(myReader("IdLav"))

            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ls
    End Function

    Public Function ListaIdLavorazioniSuListinoBase(IdListinoBase As Integer) As List(Of Integer)
        Dim Ls As List(Of Integer) = New List(Of Integer)
        Try

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IdLavoro FROM tr_lavprev WHERE idlistinobase = " & IdListinoBase
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read

                Ls.Add(myReader("IdLavoro"))

            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ls
    End Function

    Public Function ListaIdLavorazioniSuProdotto(IdProd As Integer) As List(Of Integer)
        Dim Ls As List(Of Integer) = New List(Of Integer)
        Try

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT IdLavoro FROM T_Lavori L INNER JOIN tR_Lavori RL ON L.idlavoro=RL.idlav "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " WHERE RL.idprod = " & IdProd
            sql &= " AND RL.idtipocom = 0 "
            sql &= " order by RL.ordine"
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read

                Ls.Add(myReader("IdLavoro"))

            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ls
    End Function

    Public Sub UpdateFile(IdLavoro As Integer, PathFile As String)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_lavori SET DELETED=True "
                Dim Sql As String = "UPDATE T_lavori SET ImgRif = " & LUNA.LunaTools.StringTools.Ap(PathFile) & " WHERE IdLavoro = " & IdLavoro

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Sub UpdateStato(IdLavoro As Integer,
                           Stato As enStato)
        Try

            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_lavori SET DELETED=True "
                Dim Sql As String = "UPDATE T_lavori SET STATO = " & Stato & " WHERE IdLavoro = " & IdLavoro

                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Function ListaIdLavorazioniByFormatoProdotto(IdFormatoProd As Integer, IdCatLav As Integer) As List(Of Integer)
        Dim Ls As List(Of Integer) = New List(Of Integer)
        Try

            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            Dim sql As String = ""
            sql = "SELECT distinct IdLavoro from T_prezzilavoro "
            'AGGIUNGERE QUI EVENTUALI FILTRI DI RICERCA
            sql &= " WHERE idformprod = " & IdFormatoProd

            sql &= " and idlavoro in (select distinct idlavoro from t_lavori where idcatlav = " & IdCatLav & ") "
            myCommand.CommandText = sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()
            While myReader.Read

                Ls.Add(myReader("IdLavoro"))

            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ls
    End Function

    Public Function ListaLavorazioni(Optional IdMacchinario As Integer = 0,
                                     Optional IdCatLav As Integer = 0,
                                     Optional IdListinoBase As Integer = 0) As List(Of LavorazioneEx)
        Dim Ls As List(Of LavorazioneEx) = New List(Of LavorazioneEx)

        Dim Sql As String = "SELECT L.*,CL.DESCRIZIONE as CATLAV FROM T_LAVORI L LEFT JOIN TD_CATLAV CL ON L.IDCATLAV = CL.IDCATLAV WHERE 1 = 1 "

        If IdMacchinario Then
            Sql &= " and idmacchinario = " & IdMacchinario
        End If

        If IdCatLav Then
            Sql &= " and L.IdCatLav = " & IdCatLav
        Else
            Sql &= " and (L.IdCatLav = 0 or L.idcatLav is null) "
        End If

        If IdListinoBase Then
            Sql &= " AND L.IdLavoro in (Select IdLavoro from Tr_LavPrev where IdListinoBase = " & IdListinoBase & ")"
        End If

        Sql &= " and stato = " & enStato.Attivo

        Sql &= " order by L.Descrizione"
        Try
            Dim myCommand As SqlCommand = _Cn.CreateCommand()
            myCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            Dim myReader As SqlDataReader = myCommand.ExecuteReader()

            While myReader.Read
                Dim classe As New LavorazioneEx(CType(myReader, IDataRecord))
                'If Not myReader("ImgRif") Is DBNull.Value Then classe.ImgRif = myReader("ImgRif")
                'If Not myReader("IdLavoro") Is DBNull.Value Then classe.IdLavoro = myReader("IdLavoro")
                'If Not myReader("Descrizione") Is DBNull.Value Then classe.Descrizione = myReader("Descrizione")
                'If Not myReader("TempoRif") Is DBNull.Value Then classe.TempoRif = myReader("TempoRif")
                'If Not myReader("Premio") Is DBNull.Value Then classe.Premio = myReader("Premio")
                'If Not myReader("SuCommessa") Is DBNull.Value Then classe.SuCommessa = myReader("SuCommessa")
                'If Not myReader("SuProdotto") Is DBNull.Value Then classe.SuProdotto = myReader("SuProdotto")
                'If Not myReader("Stato") Is DBNull.Value Then classe.Stato = myReader("Stato")
                'If Not myReader("Macchinario") Is DBNull.Value Then classe.Macchinario = myReader("Macchinario")
                'If Not myReader("Pubblica") Is DBNull.Value Then classe.Pubblica = myReader("Pubblica")
                'If Not myReader("Prezzo") Is DBNull.Value Then classe.Prezzo = myReader("Prezzo")
                'If Not myReader("IdCatLav") Is DBNull.Value Then classe.IdCatLav = myReader("IdCatLav")

                'If Not myReader("Sigla") Is DBNull.Value Then classe.Sigla = myReader("Sigla")
                'If Not myReader("IdMacchinario") Is DBNull.Value Then classe.IdMacchinario = myReader("idMacchinario")
                'If Not myReader("CostoSingCopia") Is DBNull.Value Then classe.CostoSingCopia = myReader("CostoSingCopia")


                If Not myReader("CatLav") Is DBNull.Value Then classe.CatLav = myReader("CatLav")
                Ls.Add(classe)
            End While
            myReader.Close()
            myCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ls

    End Function

    Public Function RiordinaListaLav(listaDisordinata As List(Of Integer),
                                              IdListinoBase As Integer) As List(Of Integer)

        Dim Ris As New List(Of Integer)

        Dim l As New List(Of Lavorazione)
        Dim ListaId As String = String.Empty

        For Each singId In listaDisordinata
            ListaId &= singId & ","
        Next

        If ListaId.Length Then
            ListaId = "(" & ListaId.TrimEnd(",") & ")"

            Using mgr As New LavorazSuPreventivazDAO
                Dim lP As List(Of LavorazSuPreventivaz) = mgr.FindAll("Ordine",
                                                                        New LUNA.LunaSearchParameter("IdListinoBase", IdListinoBase),
                                                                        New LUNA.LunaSearchParameter("IdLavoro", ListaId, " IN "))

                If lP.Count = listaDisordinata.Count Then
                    For Each singlP As LavorazSuPreventivaz In lP
                        Ris.Add(singlP.IdLavoro)
                    Next
                Else
                    For Each singlP As Integer In listaDisordinata
                        Ris.Add(singlP)
                    Next
                End If
            End Using
        End If

        'Dim l As New List(Of F.Lavorazione)

        'For Each singId In listaDisordinata
        '    Dim o As New F.Lavorazione
        '    o.Read(singId)
        '    l.Add(o)
        'Next

        'l.Sort(Function(x, y) x.Categoria.OrdineEsecuzione.CompareTo(y.Categoria.OrdineEsecuzione))

        'For Each Lav As F.Lavorazione In l
        '    Ris.Add(Lav.IdLavoro)
        'Next

        Return Ris

    End Function

End Class