Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class ituoicoupon
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "I tuoi Coupon di Sconto"
        If Not IsPostBack Then
            'qui devo caricare solo i coupon in corso di validita sia riservati che pubblici con il totale di volte usabili e il totale di volte gia usati

            CaricaCoupon()

        End If

    End Sub

    Private Sub CaricaCoupon()

        Dim lCouponMiei As New List(Of CouponW)

        Using mgr As New CouponWDAO

            Dim l As List(Of CouponW) = mgr.ListaCouponAttivi(UtenteConnesso.IdUtente, True)

            For Each SC As CouponW In l
                If SC.RiservatoATipoUtente = enTipoRubrica.Tutto OrElse SC.RiservatoATipoUtente = UtenteConnesso.Tipo Then
                    'Dim CheckOkVisibile As Boolean = True
                    'If SC.VisibileOnline = enSiNo.No Then
                    '    If SC.Riservato <> 0 And SC.Riservato <> UtenteConnesso.IdUtente Then
                    '        CheckOkVisibile = False
                    '    End If
                    'End If
                    'If CheckOkVisibile Then
                    SC.Utilizzati = mgr.TotaleCouponUtilizzati(SC.IdCoupon, UtenteConnesso.IdUtente)
                    If SC.Utilizzati < SC.MaxVolte Then lCouponMiei.Add(SC)
                    'End If

                End If
            Next

        End Using

        rptCoupon.DataSource = lCouponMiei
        rptCoupon.DataBind()

        If lCouponMiei.Count = 0 Then
            lblNoCoupon.Visible = True
        End If

    End Sub

    Private Sub rptCoupon_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptCoupon.ItemDataBound

        Dim C As CouponW = e.Item.DataItem
        Dim pnl As Panel = e.Item.FindControl("pnlLnkToProd")
        If Not pnl Is Nothing Then
            Dim imgL As HtmlImage = e.Item.FindControl("imgLB")
            If C.IdListinoBase Then
                imgL.Src = FormerWebApp.PathListinoImg & C.ListinoBase.GetImgFormato
                imgL.Attributes.Add("class", "imgLB")
                pnl.Visible = True
                Dim lbl As HtmlAnchor = e.Item.FindControl("LnkToProd")
                lbl.HRef = "/" & C.ListinoBase.IdPrev & _
                               "/" & C.ListinoBase.IdFormProd & _
                               "/" & C.ListinoBase.IdTipoCarta & _
                               "/" & C.ListinoBase.IdColoreStampa & _
                               "/" & C.ListinoBase.NomeInUrl
            Else
                imgL.Src = "/img/icoEuro50.png"
            End If
        End If
    End Sub
End Class