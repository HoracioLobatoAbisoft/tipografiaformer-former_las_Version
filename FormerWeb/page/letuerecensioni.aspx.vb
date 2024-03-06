Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class pLetuerecensioni
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Le tue Recensioni"
        If Not IsPostBack Then
            'qui devo caricare solo i coupon in corso di validita sia riservati che pubblici con il totale di volte usabili e il totale di volte gia usati

            CaricaRecensioni()

        End If

    End Sub

    Private Sub CaricaRecensioni()

        Dim l As New List(Of OrdineWeb)

        Using mgr As New OrdiniWebDAO

            Dim lmese As List(Of OrdineWeb) = mgr.FindAll("DataIns desc", _
                                                          New LUNA.LunaSearchParameter("IdUt", UtenteConnesso.IdUtente), _
                                                          New LUNA.LunaSearchParameter("datediff(""d"",DataIns,GetDate())", 30, "<="), _
                                                          New LUNA.LunaSearchParameter("Stato", "(" & enStatoOrdine.UscitoMagazzino & "," & _
                                                                                       enStatoOrdine.InConsegna & "," & _
                                                                                       enStatoOrdine.Consegnato & "," & _
                                                                                       enStatoOrdine.PagatoInteramente & ")", " IN "))

            'Dim lmese As List(Of OrdineWeb) = mgr.FindAll("DataIns desc", _
            '                                  New LUNA.LunaSearchParameter("IdUt", UtenteConnesso.IdUtente))

            'qui ho tutti gli ordini di questo cliente nel mese, ora devo vedere se non sono stati gia recensiti nell'ultimo mese
            For Each singord As OrdineWeb In lmese
                Using mgrR As New ReviewDAO
                    Dim lR As List(Of Review) = mgrR.FindAll(New LUNA.LunaSearchParameter(LFM.Review.IdListinoBase, singord.IdListinoBase),
                                                             New LUNA.LunaSearchParameter(LFM.Review.IdUt, UtenteConnesso.IdUtente),
                                                             New LUNA.LunaSearchParameter("datediff(""d"",Quando,GetDate())", 30, "<="))
                    If lR.Count = 0 Then
                        If l.FindAll(Function(x) x.IdListinoBase = singord.IdListinoBase).Count = 0 Then
                            If singord.P.DispOnline Then
                                l.Add(singord)
                            End If
                        End If
                    End If
                End Using
            Next

        End Using

        rptRecensioni.DataSource = l
        rptRecensioni.DataBind()

        If l.Count = 0 Then
            lblNoRecensioni.Visible = True
        End If

    End Sub

    Private Sub rptCoupon_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptRecensioni.ItemDataBound

        Dim C As OrdineWeb = e.Item.DataItem
        Dim pnl As ucReviewAdd = e.Item.FindControl("reviewAdd")
        If Not pnl Is Nothing Then
            pnl.Lavoro = C
        End If
    End Sub

End Class