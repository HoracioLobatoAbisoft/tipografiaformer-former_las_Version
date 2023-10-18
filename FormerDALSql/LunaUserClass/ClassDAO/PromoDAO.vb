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
'''DAO Class for table T_promo
''' </summary>
''' <remarks>
'''Write your DATABASE custom method here
''' </remarks>
Public Class PromoDAO
    Inherits _PromoDAO

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Connection As DbConnection)
        MyBase.New(Connection)
    End Sub

    Protected Overrides Property EmptyItemDescription As String = "Selezionare una voce"

    Public Function GetPromo(IdListinoBase As Integer) As Promo
        Dim ris As Promo = Nothing

        Dim sql As String = "SELECT * FROM T_Promo WHERE IdListinoBase = " & IdListinoBase & " AND IdPromoOnline<>0 AND Stato = " & enStato.Attivo
        sql &= " AND datediff(n,getdate(),DataFineValidita)>0 order by IdPromo"

        Dim l As List(Of Promo) = GetData(sql)

        If l.Count Then
            ris = l(0)
        End If

        Return ris

    End Function

End Class