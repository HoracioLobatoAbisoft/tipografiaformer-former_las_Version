Imports FormerDALWeb
Imports FormerBusinessLogic

Public Class searchRis
    Inherits FormerFreePage
    Public RowCount As Integer = 0
    'Private RecordPerPage As Integer = 10

    'Private Sub CreatePagingControl()

    '    For i As Integer = 0 To (Math.Ceiling(RowCount / RecordPerPage)) - 1
    '        Dim lnk As New LinkButton()
    '        AddHandler lnk.Click, AddressOf lnk_ClickPage
    '        lnk.ID = "lnkPage" & (i + 1).ToString()
    '        lnk.Text = (i + 1).ToString()
    '        lnk.CssClass = "pagerItem"
    '        plcPaging.Controls.Add(lnk)
    '        Dim spacer As New Label()
    '        spacer.Text = "&nbsp;"
    '        plcPaging.Controls.Add(spacer)
    '    Next

    'End Sub

    'Private Sub ColoraPagina(NumPag As Integer)

    '    For Each c As Control In plcPaging.Controls
    '        Try
    '            Dim lnk As LinkButton = TryCast(c, LinkButton)
    '            If lnk.Text = NumPag Then
    '                lnk.Font.Bold = True
    '                lnk.BackColor = Drawing.Color.FromArgb(214, 224, 61)
    '            Else
    '                lnk.Font.Bold = False
    '                lnk.BackColor = Drawing.Color.White
    '            End If

    '        Catch ex As Exception

    '        End Try
    '    Next

    'End Sub

    'Private Sub lnk_ClickPage(ByVal sender As Object, ByVal e As EventArgs)

    '    Dim lnk As LinkButton = TryCast(sender, LinkButton)
    '    Dim currentPage As Integer = Integer.Parse(lnk.Text)
    '    ColoraPagina(currentPage)
    '    Dim take As Integer = currentPage * RecordPerPage
    '    Dim skip As Integer = If(currentPage = 1, 0, take - RecordPerPage)
    '    Cerca(take, skip)

    'End Sub

    Public KeywordsParam As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("PageTitle") = "Risultato Ricerca"

        Dim Keywords As String = Page.RouteData.Values("Keywords")

        Keywords = FormerSearchEngine.DecryptRichiesta(Keywords)

        KeywordsParam = Keywords

        'qui devo validare le keywords
        If Not IsPostBack Then

        End If

        RowCount = Cerca()

        If RowCount = 0 Then
            pnlNoRis.Visible = True
        End If

        'If RowCount Then
        '    CreatePagingControl()
        '    ColoraPagina(1)
        'Else
        '    pnlPagine.Visible = False
        '    pnlNoRis.Visible = True
        'End If


        'End If

    End Sub

    Public ReadOnly Property GetHtmlKeywords As String
        Get
            Return Server.HtmlEncode(KeywordsParam)
        End Get
    End Property

    Private Function Cerca() As Integer

        'cerco tra gli indici di ricerca
        Dim ris As Integer = 0
        Dim l As IEnumerable(Of IndiceRicerca) = FormerSearchEngine.Cerca(KeywordsParam)

        lblRisCount.Text = l.Count & " risultati trovato/i"

        'Dim query = From p In l.Take(take).Skip(pageSize)

        'Dim page As New PagedDataSource()
        'page.AllowCustomPaging = True
        'page.AllowPaging = True
        'page.DataSource = query
        'page.PageSize = RecordPerPage
        rptRis.DataSource = l
        rptRis.DataBind()

        'RowCount = l.Count
        'ViewState("RowCountCerca") = RowCount
        ris = l.Count

        Return ris
    End Function

    Private Sub rptRis_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptRis.ItemDataBound

        Dim C As IndiceRicerca = e.Item.DataItem
        Dim R As ucRisultatoRicerca = e.Item.FindControl("RisultatoRicerca")
        If Not R Is Nothing Then
            R.IndiceRicerca = C
        End If

    End Sub

End Class