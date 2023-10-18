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
'''DAO Class for table T_preventivazione
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class PreventivazioniWDAO
    Inherits _PreventivazioniWDAO
    Public Sub OrdinaListinoPerFormatoProd(ByRef Lst As List(Of ListinoBaseW))

        Lst.Sort(AddressOf Comparer)

    End Sub

    Public Sub OrdinaListinoPerGrammaturaCarta(ByRef Lst As List(Of ListinoBaseW))
        Lst.Sort(AddressOf ComparerGrammatura)
    End Sub

    Public Sub OrdinaAlberoWeb(ByRef Lst As List(Of ListinoBaseW))
        Lst.Sort(AddressOf ComparerAlberoWeb)
    End Sub

    Public Sub OrdinaListinoPerColoreDiStampa(ByRef Lst As List(Of ListinoBaseW))
        Lst.Sort(AddressOf ComparerTipoCarta)
    End Sub

    Private Shared Function ComparerTipoCarta(ByVal x As ListinoBaseW,
                                     ByVal y As ListinoBaseW) As Integer

        'Dim Result As Integer = y.TutteScatolePiene.CompareTo(x.TutteScatolePiene)
        'If Result = 0 Then Result = x.NumeroScatole.CompareTo(y.NumeroScatole)
        'If result = 0 Then result = x.SpazioSprecato.CompareTo(y.SpazioSprecato)

        Dim Result As Integer = x.ColoreStampa.NLastre.CompareTo(y.ColoreStampa.NLastre)
        If Result = 0 Then Result = x.ColoreStampa.Descrizione.CompareTo(y.ColoreStampa.Descrizione)

        Return Result

    End Function

    Private Function Comparer(x As ListinoBaseW, y As ListinoBaseW) As Integer
        Dim ris As Integer = x.Linkato.CompareTo(y.Linkato)
        If ris = 0 Then
            ris = x.Ordinamento.CompareTo(y.Ordinamento)
            If ris = 0 Then
                ris = x.FormatoProdotto.AreaCmQuadrati.CompareTo(y.FormatoProdotto.AreaCmQuadrati)
                If ris = 0 Then
                    ris = x.FormatoProdotto.Orientamento.CompareTo(y.FormatoProdotto.Orientamento)
                    If ris = 0 Then
                        ris = x.ColoreStampa.FR.CompareTo(y.ColoreStampa.FR)
                    End If
                End If
            End If
        End If

        Return ris
    End Function

    Private Function ComparerAlberoWeb(x As ListinoBaseW, y As ListinoBaseW) As Integer
        Dim ris As Integer = x.Linkato.CompareTo(y.Linkato)
        If ris = 0 Then
            If ris = 0 Then
                ris = x.FormatoProdotto.AreaCmQuadrati.CompareTo(y.FormatoProdotto.AreaCmQuadrati)
                If ris = 0 Then
                    ris = y.IsFormerChoice.CompareTo(x.IsFormerChoice)
                    If ris = 0 Then
                        ris = x.TipoCarta.Grammi.CompareTo(y.TipoCarta.Grammi)
                    End If
                End If
            End If
        End If
        Return ris
    End Function



    Private Function ComparerGrammatura(x As ListinoBaseW, y As ListinoBaseW) As Integer
        Dim ris As Integer = x.Linkato.CompareTo(y.Linkato)
        If ris = 0 Then
            ris = x.Ordinamento.CompareTo(y.Ordinamento)
            If ris = 0 Then
                ris = x.TipoCarta.Grammi.CompareTo(y.TipoCarta.Grammi)
            End If
        End If
        Return ris
    End Function

    Public Function GetForHome(IdReparto As enRepartoWeb,
                               Optional AddEmptyItem As Boolean = False) As List(Of PreventivazioneW)
        Dim ris As List(Of PreventivazioneW)

        'Dim sql = "select * from t_preventivazione where idprev in (select distinct idprev from t_listinobase) "
        'If IdReparto <> enRepartoWeb.Tutto Then
        '    sql &= " and IdReparto = " & CInt(IdReparto)
        'End If
        'sql &= " AND DispOnline = " & enSiNo.Si & " ORDER BY IdReparto, descrizione"

        Dim sql As String = "SELECT DISTINCT p.* FROM t_preventivazione p INNER JOIN t_listinobase l ON p.idprev = l.idprev"
        sql &= " WHERE DispOnline = " & enSiNo.Si
        sql &= " AND L.Disattivo <> " & enSiNo.Si

        If IdReparto <> enRepartoWeb.Tutto Then
            sql &= " AND IdReparto = " & CInt(IdReparto)
        End If

        sql &= " ORDER BY IdReparto, descrizione"

        ris = GetData(sql, AddEmptyItem)

        Return ris

    End Function

    Public Function GetFirstPreventivazioneFromFP(IdFp As Integer) As PreventivazioneW

        Dim ris As PreventivazioneW = Nothing

        Dim lst As List(Of PreventivazioneW)
        Dim SqlS As String = "SELECT * FROM t_preventivazione WHERE disponline = " & enSiNo.Si & " AND idprev in (select idprev from t_listinobase where disattivo = " & enSiNo.No & " and idformprod = " & IdFp & ")"

        lst = GetData(SqlS)
        ris = lst(0)

        Return ris

    End Function

End Class