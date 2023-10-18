Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class pGetRssPromo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CaricaDati()

    End Sub

    Private Sub CaricaDati()

        Dim lstP As List(Of PromoW) = Nothing
        Using mgr As New PromoWDAO
            lstP = mgr.GetPromoDisponibili(False)
        End Using

        Dim lB As New List(Of ListinoBaseW)
        For Each P In lstP
            Dim LbSing As New ListinoBaseW
            LbSing.Read(P.IdListinoBase)
            lB.Add(LbSing)
        Next

        rptPromo.DataSource = lB
        rptPromo.DataBind()

    End Sub

    Public Function GetPubDate() As String
        '2014-12-29T11:51:27Z
        Dim ris As String = String.Empty

        ris = Now.Year & "-" & Now.Month & "-" & Now.Day & "T" & Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & ":00Z"

        Return ris

    End Function

End Class