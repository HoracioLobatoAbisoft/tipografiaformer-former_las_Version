Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface

Public Class pLavori
    Inherits FormerSecurePage
    Private RowCount As Integer = 0
    Private RecordPerPage As Integer = 10

    Private Sub myFormer_Load(sender As Object, e As EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "I tuoi Ordini"
        CaricaOrdini(RecordPerPage, 0)

        RowCount = ViewState("RowCount")
        CreatePagingControl()

    End Sub

    Private Sub CreatePagingControl()
        For i As Integer = 0 To (Math.Ceiling(RowCount / RecordPerPage)) - 1
            Dim lnk As New LinkButton()
            AddHandler lnk.Click, AddressOf lnk_Click
            lnk.ID = "lnkPage" & (i + 1).ToString()
            lnk.Text = (i + 1).ToString()
            lnk.CssClass = "pagerItem"
            plcPaging.Controls.Add(lnk)
            Dim spacer As New Label()
            spacer.Text = "&nbsp;"
            plcPaging.Controls.Add(spacer)
        Next i
    End Sub

    Private Sub lnk_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = TryCast(sender, LinkButton)
        Dim currentPage As Integer = Integer.Parse(lnk.Text)
        Dim take As Integer = currentPage * RecordPerPage
        Dim skip As Integer = If(currentPage = 1, 0, take - RecordPerPage)
        CaricaOrdini(take, skip)
    End Sub

    Private Sub CaricaOrdini(ByVal take As Integer, ByVal pageSize As Integer)
        Using mgr As New OrdiniWebDAO
            Dim l As List(Of OrdineWeb) = mgr.FindAll("DataIns desc, IdOrdine Desc",
                                                      New LUNA.LunaSearchParameter(LFM.OrdineWeb.IdUt, UtenteConnesso.Utente.IdUt),
                                                      New LUNA.LunaSearchParameter(LFM.OrdineWeb.StatoWeb, CInt(enStato.Attivo)),
                                                      New LUNA.LunaSearchParameter(LFM.OrdineWeb.OrdineInOmaggio, enSiNo.Si, "<>"))

            'Dim lg As List(Of OrdineInGriglia) = (New MGROrdiniInGriglia).GetGriglia(l)

            'gridOrdini.DataSource = lg
            'gridOrdini.DataBind()

            Dim query = From p In l.Take(take).Skip(pageSize)

            Dim page As New PagedDataSource()
            page.AllowCustomPaging = True
            page.AllowPaging = True
            page.DataSource = query
            page.PageSize = RecordPerPage
            rptOrdini.DataSource = page
            rptOrdini.DataBind()
            RowCount = l.Count
            ViewState("RowCount") = RowCount
        End Using

    End Sub

    Private Sub rptOrdini_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptOrdini.ItemDataBound

        Dim O As OrdineWeb = e.Item.DataItem
        Dim HO As ucBoxHeaderLavoro = e.Item.FindControl("HeaderOrdine")
        Dim CO As ucBoxCorpoLavoro = e.Item.FindControl("CorpoOrdine")
        Dim FO As ucBoxFooterLavoro = e.Item.FindControl("FooterOrdine")

        If Not HO Is Nothing Then
            HO.Ordine = O
            CO.Ordine = O
            FO.Ordine = O
        End If

    End Sub
End Class