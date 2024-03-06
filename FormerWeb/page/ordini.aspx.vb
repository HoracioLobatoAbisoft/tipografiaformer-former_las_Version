Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface

Public Class pOrdini
    Inherits FormerSecurePage
    Private RowCount As Integer = 0
    Private RecordPerPage As Integer = 10

    Private Sub myFormer_Load(sender As Object, e As EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Le Tue Consegne"
        CaricaConsegne(RecordPerPage, 0)
        RowCount = ViewState("RowCountConsegne")
        CreatePagingControl()
        IframeRender()
    End Sub

    Private Sub IframeRender()
        Dim Eviroment As Boolean = UtenteConnesso.Eviroment
        Dim UrlProdottoEnviroment As String = UtenteConnesso.UrlIframe & "/iTuoiOrdini/" & UtenteConnesso.IdUtente
        'If Eviroment Then
        '    UrlProdottoEnviroment = "https://react.tipografiaformertest.it:6060/#/iTuoiOrdini/" & UtenteConnesso.IdUtente
        'Else
        '    UrlProdottoEnviroment = "http://localhost:5173/#/iTuoiOrdini/" & UtenteConnesso.IdUtente
        'End If

        If UtenteConnesso.UtenteAutorizato Then
            Dim UrlIndex As String = UrlProdottoEnviroment
            IframeOrdini.Text = "<iframe id='IFrameOrdini' src=" & UrlIndex & " style = 'width:100%;height:100%;border:none;'></iframe>"
        End If
    End Sub

    Private Sub CreatePagingControl()

        For i As Integer = 0 To (Math.Ceiling(RowCount / RecordPerPage)) - 1
            Dim lnk As New LinkButton()
            AddHandler lnk.Click, AddressOf lnk_ClickPage
            lnk.ID = "lnkPage" & (i + 1).ToString()
            lnk.Text = (i + 1).ToString()
            lnk.CssClass = "pagerItem"
            plcPaging.Controls.Add(lnk)
            Dim spacer As New Label()
            spacer.Text = "&nbsp;"
            plcPaging.Controls.Add(spacer)
        Next

    End Sub

    Protected Function ShowCoupon(TotaleSconti As Decimal, IdCoupon As Integer) As Boolean
        Dim ris As Boolean = False
        If TotaleSconti <> 0 And IdCoupon <> 0 Then
            ris = True
        End If
        Return ris
    End Function

    Private Sub lnk_ClickPage(ByVal sender As Object, ByVal e As EventArgs)

        Dim lnk As LinkButton = TryCast(sender, LinkButton)
        Dim currentPage As Integer = Integer.Parse(lnk.Text)
        Dim take As Integer = currentPage * RecordPerPage
        Dim skip As Integer = If(currentPage = 1, 0, take - RecordPerPage)
        CaricaConsegne(take, skip)

    End Sub

    Private Sub CaricaConsegne(ByVal take As Integer, ByVal pageSize As Integer)

        Using Mgr As New ConsegneDAO

            Dim l As List(Of Consegna) = Mgr.FindAll("DataInserimento Desc,Giorno Desc",
                                                     New LUNA.LunaSearchParameter(LFM.Consegna.IdUt, UtenteConnesso.IdUtente),
                                                     New LUNA.LunaSearchParameter(LFM.Consegna.IdStatoConsegna, enStatoConsegna.Eliminata, "<>"))

            l = l.FindAll(Function(x) x.ListaOrdini.Count > 0)

            Dim query = From p In l.Take(take).Skip(pageSize)

            Dim page As New PagedDataSource()
            page.AllowCustomPaging = True
            page.AllowPaging = True
            page.DataSource = query
            page.PageSize = RecordPerPage
            rptCons.DataSource = page
            rptCons.DataBind()

            RowCount = l.Count
            ViewState("RowCountConsegne") = RowCount


        End Using
    End Sub

    Private Sub rptCons_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptCons.ItemDataBound

        Dim C As Consegna = e.Item.DataItem
        Dim FO As ucBoxFooterOrdine = e.Item.FindControl("FooterOrdine")
        If Not FO Is Nothing Then
            FO.Ordine = C
            Dim rp As Repeater = e.Item.FindControl("rptOrdini")
            If Not rp Is Nothing Then
                AddHandler rp.ItemDataBound, AddressOf rptOrdini_ItemDataBound
                rp.DataSource = C.ListaOrdini
                rp.DataBind()
            End If
        End If

    End Sub

    Private Sub rptOrdini_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)

        Dim O As OrdineWeb = e.Item.DataItem
        Dim HO As ucBoxHeaderLavoro = e.Item.FindControl("HeaderLavoro")
        Dim CO As ucBoxCorpoLavoro = e.Item.FindControl("CorpoLavoro")
        Dim FO As ucBoxFooterLavoro = e.Item.FindControl("Footerlavoro")

        If Not HO Is Nothing Then

            HO.Ordine = O
            HO.FromConsegne = True
            CO.Ordine = O
            FO.Ordine = O

        End If

    End Sub

End Class