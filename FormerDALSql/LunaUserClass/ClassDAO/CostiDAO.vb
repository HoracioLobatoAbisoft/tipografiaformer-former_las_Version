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
'''DAO Class for table T_contabcosti
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class CostiDAO
    Inherits _CostiDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function AggiornaCategoriaFromRubrica(IdRub As Integer,
                                                IdCatNew As Integer,
                                                IdCatOld As Integer)

        Try
            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_contabcosti SET DELETED=True "
                Dim Sql As String = "UPDATE T_contabcosti "
                Sql &= " SET IdCat = " & IdCatNew
                Sql &= " WHERE IdRub = " & IdRub & " AND IdCat = " & IdCatOld
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

                Sql &= "UPDATE T_VociCosto "
                Sql &= " SET IdCat = " & IdCatNew
                Sql &= " WHERE IdCat = " & IdCatOld & " AND IdCosto in (SELECT IdCosto FROM T_ContabCosti WHERE IdRub = " & IdRub & ")"
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try


    End Function

    Public Function CalcolaScopertoMesi() As List(Of ScopertoMese)

        Dim Ris As List(Of ScopertoMese) = New List(Of ScopertoMese)

        'Using mgr As New RicaviDAO

        Dim l As List(Of Costo) = FindAll(New LUNA.LunaSearchParameter("Tipo", enTipoDocumento.DDT, "<>"),
                                          New LUNA.LunaSearchParameter("idstato", enStatoDocumentoFiscale.PagatoInteramente, "<>"))
        For Each R As Costo In l
            If R.PagatoInteramente = False Then
                Dim MeseRif As String = R.DataPrevPagam.ToString("yyyyMM")

                Dim s As ScopertoMese = Ris.Find(Function(x) x.MeseRif = MeseRif)
                If s Is Nothing Then
                    s = New ScopertoMese
                    s.MeseRif = MeseRif
                    Ris.Add(s)
                End If

                s.Scoperto += R.TotaleAncoraDaPagare
            End If
        Next
        'End Using





        'select sum(totale),format(dataprevpagam,"yyyyMM") as Periodo from t_contabricavi
        'where idstato <> 30
        'and tipo <>2
        'group by format(dataprevpagam,"yyyyMM")
        'Try

        '    Dim myCommand As Data.Common.DbCommand = _Cn.CreateCommand()
        '    Dim sql As String = "SELECT SUM(totale) as tot ,format(dataprevpagam,""yyyyMM"") as Periodo FROM t_contabcosti"
        '    sql &= " WHERE idstato <> " & enStatoDocumentoFiscale.PagatoInteramente
        '    sql &= " AND tipo <> " & enTipoDocumento.DDT
        '    sql &= " GROUP by format(dataprevpagam,""yyyyMM"")"
        '    sql &= " ORDER by format(dataprevpagam,""yyyyMM"")"

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

    Public Function GetLista(Optional ByVal AnnoRif As Integer = 0,
                             Optional ByVal MeseRif As Integer = 0,
                             Optional ByVal IdRub As Integer = 0,
                             Optional ByVal TipoDocToShow As enFiltroTipoDocumento = 0,
                             Optional ByVal OnlyNotPaid As Boolean = False,
                             Optional ByVal OnlyNotElapsed As Boolean = False,
                             Optional ByVal Descrizione As String = "",
                             Optional ByVal IdDocRif As Integer = -1,
                             Optional IdAzienda As Integer = 0,
                             Optional StatoDocumento As enStatoDocumentoFiscale = enStatoDocumentoFiscale.NonDefinito,
                             Optional CategoriaContabile As Integer = 0) As List(Of Costo)

        Dim Ris As New List(Of Costo)
        Try
            Dim TipoDocumenti As String = String.Empty

            Select Case TipoDocToShow
                Case enFiltroTipoDocumento.Fattura
                    TipoDocumenti = " and (C.tipo =  " & enTipoDocumento.Fattura & " or C.tipo =  " & enTipoDocumento.FatturaRiepilogativa & " or C.tipo =  " & enTipoDocumento.AccontoAnticipoSuFattura & ")"
                Case enFiltroTipoDocumento.FatturaENotaDiCredito
                    TipoDocumenti = " and (C.tipo =  " & enTipoDocumento.Fattura & " or C.tipo =  " & enTipoDocumento.FatturaRiepilogativa & " or C.tipo =  " & enTipoDocumento.AccontoAnticipoSuFattura & " or C.tipo =  " & enTipoDocumento.NotaDiCredito & " or C.tipo =  " & enTipoDocumento.NotaDiDebito & ")"
                Case enFiltroTipoDocumento.FatturaRiepilogativa
                    TipoDocumenti = " and (C.tipo =  " & enTipoDocumento.FatturaRiepilogativa & ")"
                Case enFiltroTipoDocumento.Preventivo
                    TipoDocumenti = " and (C.tipo =  " & enTipoDocumento.Preventivo & ")"
                Case enFiltroTipoDocumento.DDT
                    TipoDocumenti = " and (C.tipo =  " & enTipoDocumento.DDT & ") And (iddocrif=0 Or iddocrif Is null)"
                Case enFiltroTipoDocumento.DDTInFattura
                    TipoDocumenti = " and (C.tipo =  " & enTipoDocumento.DDT & ") And iddocrif<>0"
                Case enFiltroTipoDocumento.NotaDiCredito
                    TipoDocumenti = " and (C.tipo =  " & enTipoDocumento.NotaDiCredito & ")"
                Case enFiltroTipoDocumento.NotaDiDebito
                    TipoDocumenti = " and (C.tipo =  " & enTipoDocumento.NotaDiDebito & ")"
                Case enFiltroTipoDocumento.AccontoAnticipoSuFattura
                    TipoDocumenti = " and (C.tipo =  " & enTipoDocumento.AccontoAnticipoSuFattura & ")"
            End Select

            Dim sql As String = "SELECT C.*,R.RagSoc FROM T_ContabCosti C, T_Rubrica R "

            sql &= " WHERE C.IdRub = R.IdRub " ' lo metto per evitare mille controlli sull'and

            If IdRub Then sql &= " AND R.idrub=  " & IdRub

            If TipoDocumenti <> String.Empty Then
                sql &= TipoDocumenti
            End If

            If AnnoRif Then

                If AnnoRif = FormerLib.FormerConst.Fiscali.IdBiennio Then
                    sql &= " AND year(datacosto) IN (" & Now.Year & "," & (Now.Year - 1) & ")"
                Else
                    sql &= " AND year(datacosto) =  " & Ap(AnnoRif)
                End If

            End If

            If MeseRif Then
                sql &= " AND month(datacosto) =  " & (MeseRif)
            End If

            If Descrizione.Length Then
                sql &= " AND ( (descrizione " & ApLike(Descrizione) & " OR Numero " & ApLike(Descrizione) & ")"

                'sql &= " OR IdCosto in (SELECT DISTINCT IDCOSTO FROM T_VOCICOSTO WHERE descrizione " & ApLike(Descrizione) & " OR CODICE " & ApLike(Descrizione) & ") )"
                sql &= " OR IdCosto IN (select distinct idcosto from "

                sql &= " (SELECT DISTINCT IDCOSTO FROM T_VOCICOSTO WHERE descrizione " & ApLike(Descrizione) & " OR CODICE " & ApLike(Descrizione) & ") a "
                sql &= " UNION "
                sql &= "select distinct cc.iddocrif from t_vocicosto vc,t_contabcosti cc "
                sql &= " WHERE (vc.descrizione " & ApLike(Descrizione) & " OR vc.CODICE " & ApLike(Descrizione) & ")"
                sql &= " and cc.idcosto = vc.idcosto and cc.tipo = " & enTipoDocumento.DDT & " and cc.iddocrif<>0"
                sql &= ")"
                sql &= ")"

            End If

            If IdDocRif <> -1 Then
                sql &= " AND IDDOCRIF = " & IdDocRif
            End If

            If IdAzienda Then
                sql &= " AND IdAzienda = " & IdAzienda
            End If

            If StatoDocumento <> enStatoDocumentoFiscale.NonDefinito Then
                sql &= " AND IdStato = " & StatoDocumento
            End If

            If CategoriaContabile Then
                sql &= " AND IdCat = " & CategoriaContabile
            End If


            sql &= " ORDER BY datacosto desc ,Numero desc "


            Using myCommand As SqlCommand = _Cn.CreateCommand()
                myCommand.CommandText = sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                Using myReader As SqlDataReader = myCommand.ExecuteReader()
                    While myReader.Read
                        Dim classe As New Costo(CType(myReader, IDataRecord))

                        'CAMPI EXTRA
                        'If Not myReader("ProdottoDescrizione") Is DBNull.Value Then classe.ProdottoDescrizione = myReader("ProdottoDescrizione")
                        'If Not myReader("RagSoc") Is DBNull.Value Then classe.pRagSoc = myReader("RagSoc")

                        Ris.Add(classe)
                    End While
                    myReader.Close()
                End Using
            End Using

            If OnlyNotPaid Then
                Ris = Ris.FindAll(Function(x) x.PagatoInteramente = False)
            End If

        Catch ex As Exception
            ManageError(ex)
        End Try

        Return Ris
    End Function

    Public Sub DeleteRifDDT(IdDoc As Integer)
        Try
            Using myCommand As DbCommand = _Cn.CreateCommand
                myCommand.Connection = _Cn

                '******IMPORTANT: You can use this commented instruction to make a logical delete .
                '******Replace DELETED Field with your logic deleted field name.
                'Dim Sql As String = "UPDATE T_contabcosti SET DELETED=True "
                Dim Sql As String = "UPDATE T_contabcosti"
                Sql &= " SET IdDocRif = 0 "
                Sql &= " WHERE IdDocRif = " & IdDoc
                myCommand.CommandText = Sql
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try
    End Sub

End Class