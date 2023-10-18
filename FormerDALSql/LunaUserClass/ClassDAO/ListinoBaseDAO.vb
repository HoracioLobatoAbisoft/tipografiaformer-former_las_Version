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
'''DAO Class for table T_listinobase
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ListinoBaseDAO
    Inherits _ListinoBaseDAO
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = " - Tutti"

    Public Sub SetFormerChoice(IdListinoBase As Integer,
                               IdPrev As Integer)

        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Tr_lavprev SET DELETED=True "

            Dim Sql As String = "UPDATE T_ListinoBase SET IsFormerChoice=" & enSiNo.No & " where idprev =  " & IdPrev
            ' Sql &= " Where IdPrev = " & Id

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()

            Sql = "UPDATE T_ListinoBase SET IsFormerChoice=" & enSiNo.Si & " where idprev =  " & IdPrev & " AND IdListinoBase = " & IdListinoBase

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub
    Public Sub ResetCounterDayPromo()

        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Tr_lavprev SET DELETED=True "

            Dim Sql As String = "UPDATE T_ListinoBase SET CounterDayPromo=0 WHERE AttivaPromoAutomatico =  " & enSiNo.Si
            ' Sql &= " Where IdPrev = " & Id

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()

        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub
    Public Sub DeleteOrDeactivate(Id As Integer,
                                  Optional ForceDeactivate As Boolean = False)
        Try

            Dim HaOrdini As Boolean = False

            If ForceDeactivate Then
                HaOrdini = True
            Else
                Using Mgr As New OrdiniDAO
                    Dim l As List(Of Ordine) = Mgr.GetBySQL("select distinct o.* from t_listinobase l inner join t_prodotti p on l.idlistinobase = p.idlistinobase inner join t_ordini o on o.idprod = p.idprod where l.idlistinobase = " & Id)
                    If l.Count Then
                        HaOrdini = True
                    End If
                End Using
            End If


            'elimino ste due in ogni caso
            Using mgr As New ListiniSuCatVirtualeDAO
                mgr.DeleteByIdListinoBase(Id)
            End Using

            Using mgr As New PrevLinkListinoDAO
                mgr.DeleteByIdListinoBase(Id)
            End Using

            If HaOrdini Then
                'disattivo
                Using L As New ListinoBase
                    L.Read(Id)
                    L.Disattivo = enSiNo.Si
                    L.Save()
                End Using
            Else

                Using mgr As New LavorazSuPreventivazDAO
                    mgr.DeleteByIdListinoBase(Id)
                End Using

                Delete(Id)
            End If

        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Sub DeleteByIdPrev(Id As Integer)
        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Tr_lavprev SET DELETED=True "

            Dim Sql As String = "DELETE FROM TR_LavPrev where idlistinobase in (select idlistinobase from t_listinobase where idprev =  " & Id & ")"
            ' Sql &= " Where IdPrev = " & Id

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()

            Sql = "DELETE FROM T_ListinoBase "
            Sql &= " Where IdPrev = " & Id

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()
            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Function GetNotInPromo(TipoListini As enTipoListiniBase) As IEnumerable(Of ListinoBase)
        Dim ris As IEnumerable(Of ListinoBase)

        Dim Sql As String = "SELECT * FROM T_ListinoBase WHERE (PercPromoAutomatico=0 OR PercPromoAutomatico IS NULL) AND NascondiOnline = " & enSiNo.No & " AND Disattivo =" & enSiNo.No

        If TipoListini = enTipoListiniBase.Sorgente Then
            Sql &= " AND IdListinoBaseSource=0"
        ElseIf TipoListini = enTipoListiniBase.Produzione Then
            Sql &= " AND IdListinoBaseSource<>0"
        End If

        ris = GetData(Sql)

        Return ris
    End Function

    Public Function GetFatturatoNelMese(IdListinoBase As Integer,
                                        Optional Mese As Integer = 0,
                                        Optional Anno As Integer = 0,
                                        Optional OnlyPromo As Boolean = False) As Decimal

        Dim ris As Decimal = 0

        If Mese = 0 And Anno = 0 Then
            Dim DataRif As Date = Now
            Mese = DataRif.Month
            Anno = DataRif.Year

        End If

        Dim sql As String = ""

        sql = "SELECT sum(TotaleForn - sconto + ricarico) as TotFatturato  FROM t_ordini o, T_Prodotti p, t_listinobase lb WHERE o.idprod = p.idprod AND p.idlistinobase = lb.idlistinobase "
        sql &= " AND lb.idlistinobase = " & IdListinoBase
        sql &= " AND Month(DataIns) = " & Mese
        sql &= " AND Year(DataIns) = " & Anno
        If OnlyPromo Then sql &= " AND O.IdPromo <> 0"

        Try
            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As DbDataReader = myCommand.ExecuteReader
                    myReader.Read()
                    If myReader.HasRows Then
                        Dim Valore As String = myReader("TotFatturato").ToString
                        If Valore.Length Then ris = Valore
                    End If
                    myReader.Close()
                End Using
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

        Return ris

    End Function

    Public Sub ResetLastUpdate(TipoListini As enTipoListiniBase)
        Try

            Dim UpdateCommand As SqlCommand = New SqlCommand()
            UpdateCommand.Connection = _Cn

            '******IMPORTANT: You can use this commented instruction to make a logical delete .
            '******Replace DELETED Field with your logic deleted field name.
            'Dim Sql As String = "UPDATE Tr_lavprev SET DELETED=True "

            Dim Sql As String = "UPDATE T_LISTINOBASE SET LASTUPDATE= 0 "
            ' Sql &= " Where IdPrev = " & Id

            UpdateCommand.CommandText = Sql
            If Not LUNA.LunaContext.TransactionBox Is Nothing Then UpdateCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
            UpdateCommand.ExecuteNonQuery()

            UpdateCommand.Dispose()
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

    Public Function GetListiniBaseSource() As List(Of ListinoBase)
        Dim ris As List(Of ListinoBase) = Nothing
        ris = GetData("SELECT * FROM T_LISTINOBASE WHERE IdListinoBaseSource = 0 AND Disattivo = " & enSiNo.No & " Order by Nome")
        Return ris
    End Function

    Public Function GetListiniBaseProduzione() As List(Of ListinoBase)
        Dim ris As List(Of ListinoBase) = Nothing
        ris = GetData("SELECT * FROM T_LISTINOBASE WHERE IdListinoBaseSource <> 0 AND Disattivo = " & enSiNo.No & " Order by Nome")
        Return ris
    End Function

    Public Sub UpdateDatiWeb(Id As Integer, ImgSito As String, DescrSito As String, DescrGoogle As String, DescrSeo As String)


        Using DbCommand As SqlCommand = New SqlCommand()
            Try
                Dim Sql As String = "UPDATE T_listinobase SET "
                Sql &= "ImgSito = @ImgSito,"
                Sql &= "DescrSito = @DescrSito, "
                Sql &= "GoogleDescr = @DescrGoogle, "
                Sql &= "GoogleSeo = @DescrSEO "
                Sql &= " WHERE IdListinoBase = " & Id
                DbCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then DbCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                DbCommand.Parameters.Add(New SqlParameter("@ImgSito", ImgSito))
                DbCommand.Parameters.Add(New SqlParameter("@DescrSito", DescrSito))
                DbCommand.Parameters.Add(New SqlParameter("@DescrGoogle", DescrGoogle))
                DbCommand.Parameters.Add(New SqlParameter("@DescrSEO", DescrSeo))
                DbCommand.CommandType = CommandType.Text
                DbCommand.CommandText = Sql
                DbCommand.ExecuteNonQuery()

            Catch ex As Exception
                ManageError(ex)
            End Try

        End Using


        ' Sql &= " Where IdPrev = " & Id

    End Sub

    Public Sub UpdateCounterPromo(Id As Integer)


        Using DbCommand As SqlCommand = New SqlCommand()
            Try
                Dim Sql As String = "UPDATE T_listinobase SET counterdaypromo = counterdaypromo + 1"
                Sql &= " WHERE IdListinoBase = " & Id

                DbCommand.Connection = _Cn
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then DbCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                DbCommand.CommandType = CommandType.Text
                DbCommand.CommandText = Sql
                DbCommand.ExecuteNonQuery()

            Catch ex As Exception
                ManageError(ex)
            End Try

        End Using


        ' Sql &= " Where IdPrev = " & Id

    End Sub

    Public Function ListiniByCatVirtuale(IdCatVirtuale As Integer, TipoListini As enTipoListiniBase) As List(Of ListinoBase)

        Dim Ls As New List(Of ListinoBase)
        Try

            Dim sql As String = ""
            sql = "SELECT * from T_listinobase"

            sql &= " WHERE IdListinoBase in (SELECT IdListinoBase FROM TR_CatVListini where IdCatVirtuale= " & IdCatVirtuale & ")"

            If TipoListini = enTipoListiniBase.Sorgente Then
                sql &= " AND IdListinoBaseSource=0"
            ElseIf TipoListini = enTipoListiniBase.Produzione Then
                sql &= " AND IdListinoBaseSource<>0"
            End If

            sql &= " AND Disattivo = " & enSiNo.No

            sql &= " ORDER BY Nome"

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls

    End Function


    Public Function ListiniUtilizzabili(TipoListini As enTipoListiniBase) As List(Of ListinoBase)
        Dim Ls As New List(Of ListinoBase)
        Try

            Dim sql As String = ""
            sql = "SELECT * from T_listinobase L, T_Preventivazione P where l.idprev<>0 and P.DispOnline = " & enSiNo.Si & " and p.idprev = l.idprev and l.NascondiOnline <> " & enSiNo.Si & " and l.disattivo <> " & enSiNo.Si

            If TipoListini = enTipoListiniBase.Sorgente Then
                sql &= " AND l.IdListinoBaseSource=0"
            ElseIf TipoListini = enTipoListiniBase.Produzione Then
                sql &= " AND l.IdListinoBaseSource<>0"
            End If

            sql &= " ORDER BY Nome"

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Function ListiniValidiPerPromo(TipoListini As enTipoListiniBase, Optional IdListinoBaseForzato As Integer = 0) As List(Of ListinoBase)
        Dim Ls As New List(Of ListinoBase)
        Try

            Dim sql As String = ""
            sql = "SELECT L.* FROM T_listinobase L, T_Preventivazione P WHERE l.idprev <> 0 and P.DispOnline = " & enSiNo.Si &
                " and p.idprev = l.idprev and l.NascondiOnline <> " & enSiNo.Si & " and l.disattivo <> " & enSiNo.Si
            sql &= " and p.ggslow <>0 "
            sql &= " and L.IdListinobase not in (SELECT IDLISTINOBASE FROM T_Promo WHERE datediff(d,getdate(),DataFineValidita)>=0)"

            If TipoListini = enTipoListiniBase.Sorgente Then
                sql &= " AND l.IdListinoBaseSource=0"
            ElseIf TipoListini = enTipoListiniBase.Produzione Then
                sql &= " AND l.IdListinoBaseSource<>0"
            End If


            If IdListinoBaseForzato Then
                sql &= " UNION SELECT * FROM t_listinobase WHERE idlistinobase = " & IdListinoBaseForzato
            End If



            sql &= " ORDER BY L.IdPrev,L.Nome"

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

End Class