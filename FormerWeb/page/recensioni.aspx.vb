Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class pRecensioni
    Inherits FormerFreePage
    Private RowCount As Integer = 0
    Private RecordPerPage As Integer = 10
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CaricaReview(RecordPerPage, 0)
        RowCount = ViewState("RowCountReview")
        CreatePagingControl()

    End Sub

    Private _TotRecensioni As Integer = 0
    Public Function GetTotRecensioni() As Integer
        Return _TotRecensioni
    End Function

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

    Private _TotVotiAggregati As Integer = 0

    Public Function AggregateRating() As Decimal
        Dim ris As Decimal = 0

        If _TotRecensioni Then
            ris = Math.Round((_TotVotiAggregati / _TotRecensioni), 2)
        End If

        Return ris
    End Function

    Private Sub lnk_ClickPage(ByVal sender As Object, ByVal e As EventArgs)

        Dim lnk As LinkButton = TryCast(sender, LinkButton)
        Dim currentPage As Integer = Integer.Parse(lnk.Text)
        Dim take As Integer = currentPage * RecordPerPage
        Dim skip As Integer = If(currentPage = 1, 0, take - RecordPerPage)
        CaricaReview(take, skip)

    End Sub

    Public Function GetStars() As String

        Dim ris As String = String.Empty
        Dim bufSingStarFull As String = "<img src=""/img/icoStarFull.png"">"
        Dim bufSingStarHalf As String = "<img src=""/img/icoStarHalf.png"">"
        Dim bufSingStarEmpty As String = "<img src=""/img/icoStarEmpty.png"">"

        Dim Voto As Decimal = AggregateRating()

        For i As Integer = 1 To 5

            If i <= Voto Then
                ris &= bufSingStarFull
            ElseIf (i > Math.Floor(Voto) And (i - Math.Floor(Voto) = 1) And Voto > Math.Floor(Voto)) Then
                ris &= bufSingStarHalf
            ElseIf i > Voto Then
                ris &= bufSingStarEmpty
            End If

        Next

        Return ris

    End Function

    Private Sub CaricaReview(ByVal take As Integer, ByVal pageSize As Integer)

        Using Mgr As New ReviewDAO

            Dim l As List(Of Review) = Mgr.FindAll("Quando desc",
                                                     New LUNA.LunaSearchParameter(LFM.Review.Stato, enStatoReview.Approvata))

            l = l.FindAll(Function(x) x.ListinoBase.Preventivazione.DispOnline = True)

            For Each singR As Review In l
                _TotVotiAggregati += singR.Voto
            Next

            _TotRecensioni = l.Count

            Dim query = From p In l.Take(take).Skip(pageSize)

            Dim page As New PagedDataSource()
            page.AllowCustomPaging = True
            page.AllowPaging = True
            page.DataSource = query
            page.PageSize = RecordPerPage
            rptReview.DataSource = page
            rptReview.DataBind()

            RowCount = l.Count
            ViewState("RowCountReview") = RowCount

        End Using

    End Sub

    Private Sub rptReview_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptReview.ItemDataBound
        Dim R As Review = e.Item.DataItem
        Dim ucR As ucReview = e.Item.FindControl("SingReview")
        If Not ucR Is Nothing Then
            ucR.WithProduct = True
            ucR.Review = R
        End If
    End Sub

End Class