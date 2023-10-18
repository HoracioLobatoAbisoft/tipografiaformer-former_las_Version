#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.3.46.21861 
'Author: Diego Lunadei
'Date: 13/09/2013 
#End Region


Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Data.SqlClient
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table Td_formatoprodotto
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class FormatiProdottoWDAO
    Inherits _FormatiProdottoWDAO

    Public Function GetFormatiProdottoByPrev(IdPrev As Integer) As List(Of FormatoProdottoW)
        Dim ris As List(Of FormatoProdottoW) = Nothing

        Dim Sql As String = "SELECT * from td_Formatoprodotto where idformprod in (select distinct IdFormProd from T_LISTINOBASE  where idprev = " & IdPrev & ") order by Formato desc"

        ris = GetData(Sql)

        Return ris
    End Function

    Public Function GetFormatiProdottoFinitoHome() As List(Of FormatoProdottoW)

        Dim ris As List(Of FormatoProdottoW) = Nothing

        Dim sql As String = "SELECT * from td_Formatoprodotto where ProdottoFinito = " & enSiNo.Si & " and idformprod in (select distinct idformprod from t_listinobase where disattivo = " & enSiNo.No & " and idprev in (select idprev from t_preventivazione where disponline = " & enSiNo.Si & " )) order by Formato"

        ris = GetData(sql)

        Return ris

    End Function

    Public Function OrdinaFormatiProdotto(x As FormatoProdottoW, y As FormatoProdottoW) As Integer
        Dim ris As Integer = x.IdCatFormatoProdotto.CompareTo(y.IdCatFormatoProdotto)
        If ris = 0 Then
            ris = x.AreaCmQuadrati.CompareTo(y.AreaCmQuadrati)
        End If
        If ris = 0 Then
            ris = x.Orientamento.CompareTo(y.Orientamento)
            If ris = 0 Then
                ris = x.Formato.CompareTo(y.Formato)
            End If
        End If
        Return ris
    End Function

End Class