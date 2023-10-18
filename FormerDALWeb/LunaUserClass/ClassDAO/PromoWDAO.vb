#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.16.6.1 
'Author: Diego Lunadei
'Date: 18/01/2017 
#End Region


Imports System.Data.Common
Imports FormerLib.FormerEnum

''' <summary>
'''DAO Class for table Promo
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class PromoWDAO
    Inherits _PromoWDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function GetPromo(IdListinoBase As Integer,
                             Optional SoloAttivo As Boolean = enSiNo.Si) As PromoW
        Dim ris As PromoW = Nothing

        'Dim sql As String = "SELECT * FROM Promo WHERE IdListinoBase = " & IdListinoBase & " AND Stato = " & enStato.Attivo
        'sql &= " AND datediff(n,getdate(),DataFineValidita)>0 order by IdPromo"

        Dim sql As String = "Select P.* From Promo P, T_Listinobase L, T_preventivazione PR"
        sql &= " WHERE P.IdListinoBase = " & IdListinoBase
        sql &= " And P.IdListinoBase = l.IdListinoBase"
        sql &= " And L.Idprev = Pr.Idprev"
        If SoloAttivo Then
            sql &= " And P.Stato = " & enStato.Attivo
        End If
        sql &= " And pr.ggSlow<>0"
        sql &= " And DateDiff(n, getdate(), P.DataFineValidita) > 0"

        Dim l As List(Of PromoW) = GetData(sql)

        If l.Count Then
            ris = l(0)
        End If

        Return ris
    End Function

    Public Function GetPromoDisponibili(Optional SoloAttivi As Boolean = True) As List(Of PromoW)
        Dim ris As List(Of PromoW) = Nothing

        Dim sql As String = "Select P.* From Promo P, T_Listinobase L, T_preventivazione PR"
        sql &= " WHERE P.IdListinoBase = l.IdListinoBase"
        If SoloAttivi Then
            sql &= " And P.Stato = " & enStato.Attivo
        End If
        sql &= " And L.Idprev = Pr.Idprev"
        sql &= " And pr.ggSlow<>0"
        sql &= " And DateDiff(n, getdate(), P.DataFineValidita) > 0 order by IdListinoBase"

        ris = GetData(sql)

        Return ris
    End Function

End Class