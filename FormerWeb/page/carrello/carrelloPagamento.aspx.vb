Imports FormerDALWeb
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

Public Class pCarrelloPagamento
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Carrello.Ordini.Count = 0 Then Response.Redirect("/carrello")

        If Not IsPostBack Then

            CaricaMetodiPagamento()

            If Carrello.ApplicatoCouponAlCarrello Then

                lblRisCoupon.Text = "Sconto per Coupon '" & Carrello.CodiceCouponApplicato.ToUpper & "' applicato all' ordine"
                pnlRisCoupon.Visible = True

            End If

        End If


    End Sub

    Private Sub CaricaMetodiPagamento()

        rdoPagam.Items.Clear()

        Using mgr As New TipiPagamentiWDAO
            Dim l As List(Of TipoPagamentoW) = mgr.FindAll("OrdOnline",
                                                           New LUNA.LunaSearchParameter("OrdOnline", 0, " <> "))

            If l.Find(Function(x) x.IdTipoPagam = UtenteConnesso.DefaultTipoPagamento) Is Nothing Then
                Dim Pdef As New TipoPagamentoW
                Pdef.Read(UtenteConnesso.DefaultTipoPagamento)
                l.Add(Pdef)
                If UtenteConnesso.DefaultTipoPagamento = enMetodoPagamento.AllaConsegna Then
                    Dim voceContrass As TipoPagamentoW = l.Find(Function(x) x.IdTipoPagam = enMetodoPagamento.ContrassegnoAlRitiro)
                    l.Remove(voceContrass)
                End If
            End If

            For Each singP As TipoPagamentoW In l
                Dim CheckImporto As Boolean = True

                If singP.ImportoMassimoPagabile <> 0 AndAlso Carrello.TotaleCarrello > singP.ImportoMassimoPagabile Then
                    CheckImporto = False
                End If

                If CheckImporto Then
                    Dim listSing As New ListItem
                    listSing.Text = "<div class=""TipoPagamento""><img src=""" & singP.ImgWeb & """><b style=""font-size:14px;"">"

                    If singP.IdTipoPagam = enMetodoPagamento.ContrassegnoAlRitiro Then

                        If Carrello.IdMetodoConsegnaScelto = enTipoCorriere.Gratis Then
                            listSing.Text &= "Al Ritiro"
                        Else
                            listSing.Text &= "Contrassegno"
                        End If
                    Else
                        listSing.Text &= singP.TipoPagam
                    End If

                    listSing.Text &= "</b>, <br>&nbsp;" & singP.Descrizione

                    If Carrello.IdMetodoConsegnaScelto <> enTipoCorriere.Gratis AndAlso singP.ImportoMaggiorazione <> 0 Then
                        listSing.Text &= " (* Può comportare una maggiorazione di <b>€ " & FormerHelper.Stringhe.FormattaPrezzo(singP.ImportoMaggiorazione) & "</b>)"
                    End If

                    'If singP.IdTipoPagam = enMetodoPagamento.Contrassegno Then
                    '    If Carrello.IdMetodoConsegnaScelto <> enTipoCorriere.Gratis Then
                    '        listSing.Text &= " (* Può comportare una maggiorazione di <b>€ " & FormerHelper.Stringhe.FormattaPrezzo(singP.ImportoMaggiorazione) & "</b>)"
                    '    End If
                    'Else
                    '    If singP.ImportoMaggiorazione Then
                    '        listSing.Text &= " (* Può comportare una maggiorazione di <b>€ " & FormerHelper.Stringhe.FormattaPrezzo(singP.ImportoMaggiorazione) & "</b>)"
                    '    End If
                    'End If

                    listSing.Text &= "</div>"
                    listSing.Value = singP.IdTipoPagam
                    'If listSing.Value = UtenteConnesso.DefaultTipoPagamento Then listSing.Selected = True
                    rdoPagam.Items.Add(listSing)
                End If
            Next

            For Each item As ListItem In rdoPagam.Items

                Dim IdTipoPagamentoScelto As Integer = Carrello.MetodoPagamentoScelto.IdTipoPagam

                If item.Value = IdTipoPagamentoScelto Then 'UtenteConnesso.DefaultTipoPagamento Then
                    item.Selected = True
                    Dim P As New TipoPagamentoW
                    P.Read(item.Value)
                    Carrello.MetodoPagamentoScelto = P
                End If
            Next

        End Using

        'qui devo selezionare il default, se non c'e' default scelgo paypal. Se il default non e' presente in quelli standard lo aggiungo perche sicuramente ha un accordo 

    End Sub

    Private Sub rdoPagam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdoPagam.SelectedIndexChanged

        Dim P As New TipoPagamentoW
        P.Read(rdoPagam.SelectedValue)
        Carrello.MetodoPagamentoScelto = P

    End Sub


    Private Sub btnCoupon_Click(sender As Object, e As EventArgs) Handles btnCoupon.Click
        Dim ValCoupon As String = Server.HtmlEncode(txtCoupon.Text.Trim(" "))

        Dim Ris As String = Carrello.ApplicaCoupon(ValCoupon, UtenteConnesso.Tipo)

        txtCoupon.Text = ValCoupon.ToUpper()

        If Ris.Length Then
            lblRisCoupon.Text = Ris
            pnlRisCoupon.Visible = True
        Else
            lblRisCoupon.Text = String.Empty
            pnlRisCoupon.Visible = False
        End If
    End Sub
End Class