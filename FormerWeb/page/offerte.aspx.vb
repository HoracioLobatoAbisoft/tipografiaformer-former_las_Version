Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class pOfferte
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'qui devo caricare solo i coupon in corso di validita sia riservati che pubblici con il totale di volte usabili e il totale di volte gia usati

            CaricaOfferte()

        End If

    End Sub

    Private Sub CaricaOfferte()

               If Not IsPostBack Then

            Dim ShowLabel As Boolean = True

            'qui carico le promozioni
            Dim lp As List(Of PreventivazioneW) = Nothing
            Using mgr As New PreventivazioniWDAO
                lp = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.PreventivazioneW.DispOnline, enSiNo.Si),
                                 New LUNA.LunaSearchParameter(LFM.PreventivazioneW.PercCoupon, 0, "<>"))
            End Using

            If lp.Count Then
                rptOfferte.DataSource = lp
                rptOfferte.DataBind()
                ShowLabel = False
            End If

            'se non ci sono ne coupon ne promozioni mostro la label
            lblNoOfferte.Visible = ShowLabel
        End If

    End Sub

    Private Sub rptOfferte_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptOfferte.ItemDataBound
        Dim Pre As PreventivazioneW = e.Item.DataItem
        Dim P As ucPrevPromo = e.Item.FindControl("PrevPromo")

        If Not P Is Nothing Then
            P.Preventivazione = Pre
        End If

    End Sub
End Class