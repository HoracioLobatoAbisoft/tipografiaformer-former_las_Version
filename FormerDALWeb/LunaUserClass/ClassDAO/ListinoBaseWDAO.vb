#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.3.46.21861 
'Author: Diego Lunadei
'Date: 13/09/2013 
#End Region

Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table T_listinobase
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class ListinoBaseWDAO
    Inherits _ListinoBaseWDAO

    'Public Function ListiniBaseRandom() As List(Of ListinoBaseW)


    '    Dim sql As String = ""
    '    sql = "select * from t_listinobase where IdFormProd in (select distinct idformprod from td_formatoprodotto where prodottofinito=" & enSiNo.Si & ") order by idlistinobase desc"

    '    Dim L As List(Of ListinoBaseW) = GetData(sql)
    '    Return L

    'End Function
    Public Function ListiniByCatVirtuale(IdCatVirtuale As Integer) As List(Of ListinoBaseW)
        Dim Ls As New List(Of ListinoBaseW)
        Try

            Dim sql As String = ""
            sql = "SELECT * FROM T_listinobase l, TR_CatVListini Cl WHERE Cl.idcatvirtuale = " & IdCatVirtuale & " AND cl.idlistinobase = l.idlistinobase AND l.nascondionline =  " & enSiNo.No & " AND l.disattivo <>  " & enSiNo.Si

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Function ListiniLinkatiAPreventivazione(IdPrev As Integer) As List(Of ListinoBaseW)
        Dim Ls As New List(Of ListinoBaseW)
        Try

            Dim sql As String = ""
            sql = "SELECT * FROM T_listinobase l, Tr_prevlistino pl WHERE pl.idpreventivazione = " & IdPrev & " AND pl.idlistinobase = l.idlistinobase AND l.nascondionline =  " & enSiNo.No & " AND l.disattivo <>  " & enSiNo.Si

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Function ListiniUtilizzabili() As List(Of ListinoBaseW)
        Dim Ls As New List(Of ListinoBaseW)
        Try

            Dim sql As String = ""
            sql = "SELECT l.* from T_listinobase L, T_PREVENTIVAZIONE P where P.DispOnline = " & enSiNo.Si & " and p.idprev = l.idprev and l.disattivo <> " & enSiNo.Si & " and l.NascondiOnline <> " & enSiNo.Si
            sql &= " order by Nome"

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function

    Public Function ListiniInPreventivazioneOrdinati(IdPrev As Integer) As List(Of ListinoBaseW)
        Dim Ls As New List(Of ListinoBaseW)
        Try

            Dim sql As String = ""
            sql = "SELECT l.* FROM T_Listinobase l inner join Td_formatoprodotto f on l.IdFormProd = f.idformprod inner join Td_formatocarta fc on f.IdFormCarta = fc.idformcarta inner join Td_coloristampa cs on cs.idcolorestampa = l.IdColoreStampa WHERE L.idprev = " & IdPrev & " and L.nascondionline= " & enSiNo.No & " and l.disattivo <> " & enSiNo.Si & " and l.idlistinobasesource<>0 order by l.ordinamento,(fc.altezza*fc.larghezza),f.orientamento, cs.FR"

            Ls = GetData(sql)

        Catch ex As Exception
            ManageError(ex)
        End Try
        Return Ls
    End Function


End Class