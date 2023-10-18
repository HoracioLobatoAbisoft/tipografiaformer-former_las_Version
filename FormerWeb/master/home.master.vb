Imports FormerDALWeb
Imports FormerLib.FormerEnum
Public Class Home
    Inherits FormerMasterPage

    Private _PageTitle As String = "Prodotti"
    Public Property PageTitle As String
        Get
            Return _PageTitle
        End Get
        Set(value As String)
            _PageTitle = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("PageTitle") <> "" Then
            _PageTitle = Session("PageTitle")
        Else
            _PageTitle = "TipografiaFormer.it"
        End If

        If Not IsPostBack Then

            CaricaOfferte()
            CaricaProdottiFiniti()
            CaricaOmaggi()
            CaricaPromo()
            'CaricaInEvidenza()

        End If

    End Sub

    Private Sub CaricaOmaggi()

        rptOmaggi.DataSource = MgrOmaggi.GetOmaggi(UtenteConnesso)
        rptOmaggi.DataBind()

    End Sub

    Public ReadOnly Property IsPaginaPromo As Boolean
        Get
            Dim ris As Boolean = False

            Dim UrlCorrente As String = HttpContext.Current.Request.Url.AbsolutePath

            ris = UrlCorrente.EndsWith("/promo")

            Return ris
        End Get
    End Property

    Private Sub CaricaPromo()

        If MostraPromo Then
            Dim l As IEnumerable(Of IndiceRicerca) = Nothing
            Using mgr As New IndiciRicercaDAO
                l = mgr.GetPromo()
            End Using
            rptPromo.DataSource = l
            rptPromo.DataBind()

        End If

    End Sub

    Private Sub rptPromo_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptPromo.ItemDataBound

        Dim C As IndiceRicerca = e.Item.DataItem
        Dim R As ucRisultatoRicerca = e.Item.FindControl("RisultatoRicerca")
        If Not R Is Nothing Then
            R.IndiceRicerca = C
        End If

    End Sub

    Private _MostraOfferte As enSiNo = enSiNo.NonDefinito
    Public ReadOnly Property MostraOfferte As enSiNo
        Get
            If _MostraOfferte = enSiNo.NonDefinito Then
                Using mgr As New PreventivazioniWDAO
                    Dim l As List(Of PreventivazioneW) = mgr.FindAll(New LUNA.LunaSearchParameter("DispOnline", enSiNo.Si),
                                                                     New LUNA.LunaSearchParameter("PercCoupon", 0, "<>"))

                    If l.Count Then
                        _MostraOfferte = enSiNo.Si
                    Else
                        _MostraOfferte = enSiNo.No
                    End If
                End Using
            End If


            Return _MostraOfferte
        End Get
    End Property

    Private _MostraPromo As enSiNo = enSiNo.NonDefinito
    Public ReadOnly Property MostraPromo As enSiNo
        Get
            If _MostraPromo = enSiNo.NonDefinito Then
                If IsPaginaPromo = False Then
                    If FormerWebApp.MostraPromo() Then
                        _MostraPromo = enSiNo.Si
                    Else
                        _MostraPromo = enSiNo.No
                    End If
                End If
            End If

            Return _MostraPromo
        End Get
    End Property
    Public ReadOnly Property MostraOmaggi As Boolean
        Get
            Dim ris As Boolean = True

            ris = MgrOmaggi.MostraOmaggi(UtenteConnesso, New List(Of ProdottoInCarrello))

            Return ris
        End Get
    End Property

    Public Function GetBannerRotazioneEx() As String

        '<a href="/offerte-e-promozioni-in-corso" ><img src="/banner/08.jpg" alt="Più ordini più Sconti. Scopri i nostri Coupon di acquisto" /></a>

        Dim ris As String = String.Empty

        Using mgr As New BannerDAO
            Dim l As List(Of Banner) = mgr.GetAll(LFM.Banner.IdBanner)

            If l.Count Then
                Randomize()

                'Dim listaScelti As New List(Of Banner)

                Dim r As New Random
                Dim quanti As Integer = 5
                Dim Aggiunti As Integer = 0
                If l.Count < quanti Then quanti = l.Count

                Do Until Aggiunti = quanti

                    Dim bannerScelto As Banner = l(r.Next(l.Count))

                    l.Remove(bannerScelto)

                    ris &= "<li><a href=""" & bannerScelto.Url & """><img src=""/banner/" & bannerScelto.Path & """ alt=""" & bannerScelto.Alt & """ /></a></li>"
                    'ris &= "<li data-thumb=""/banner/" & bannerScelto.Path & """><a href=""" & bannerScelto.Url & """><img src=""/banner/" & bannerScelto.Path & """ alt=""" & bannerScelto.Alt & """ /></a></li>"
                    Aggiunti += 1
                Loop


            End If

        End Using

        Return ris

    End Function
    Public Function GetBannerRotazione() As String

        '<a href="/offerte-e-promozioni-in-corso" ><img src="/banner/08.jpg" alt="Più ordini più Sconti. Scopri i nostri Coupon di acquisto" /></a>

        Dim ris As String = String.Empty

        Using mgr As New BannerDAO
            Dim l As List(Of Banner) = mgr.GetAll(LFM.Banner.IdBanner)

            If l.Count Then
                Randomize()

                'Dim listaScelti As New List(Of Banner)

                Dim r As New Random
                Dim quanti As Integer = 3
                Dim Aggiunti As Integer = 0
                If l.Count < quanti Then quanti = l.Count

                Do Until Aggiunti = quanti

                    Dim bannerScelto As Banner = l(r.Next(l.Count))

                    l.Remove(bannerScelto)

                    ris &= "<a href=""" & bannerScelto.Url & """><img src=""/banner/" & bannerScelto.Path & """ alt=""" & bannerScelto.Alt & """ /></a>" & ControlChars.NewLine
                    Aggiunti += 1
                Loop


            End If

        End Using

        Return ris

    End Function

    'Private Sub CaricaInEvidenza()

    '    Dim l As List(Of ListinoBaseW) = Nothing 'Application("ListaListiniBase")

    '    Using mgr As New ListinoBaseWDAO
    '        l = mgr.ListiniUtilizzabili
    '    End Using

    '    Dim lEvid As List(Of ListinoBaseW) = l.FindAll(Function(x) x.InEvidenza = enSiNo.Si)

    '    lEvid = FormerWebApp.Liste.Shuffle(lEvid)

    '    If lEvid.Count < 4 Then
    '        l = FormerWebApp.Liste.Shuffle(l.FindAll(Function(x) x.InEvidenza = enSiNo.No))
    '        For i As Integer = lEvid.Count To 4
    '            lEvid.Add(l(i))
    '        Next
    '    End If

    '    Dim lEvidFin As New List(Of ListinoBaseW)

    '    Dim Inseriti As Integer = 0
    '    For Each singLb As ListinoBaseW In lEvid
    '        If Inseriti < 4 Then
    '            lEvidFin.Add(singLb)
    '            Inseriti += 1
    '        Else
    '            Exit For
    '        End If
    '    Next

    '    Dim tr As New TableRow

    '    For Each lb As ListinoBaseW In lEvidFin

    '        Dim td As New TableCell
    '        Dim bE As New My.Templates.BloccoInEvidenza

    '        bE.L = lb
    '        Dim buffer As String = bE.TransformText

    '        td.Text = buffer
    '        'td.Width = 25%
    '        'td.HorizontalAlign = HorizontalAlign.Center
    '        td.VerticalAlign = VerticalAlign.Middle

    '        tr.Cells.Add(td)

    '    Next

    '    tblEvidenza.Rows.Add(tr)

    'End Sub

    Private Sub CaricaProdottiFiniti()

        'Dim lst As List(Of FormatoProdottoW) = Nothing ' DirectCast(Application("ListaPreventivazioni"), List(Of PreventivazioneW)).FindAll(Function(x) x.IdReparto = RepartoScelto)
        'Using mgr As New FormatiProdottoWDAO
        '    lst = mgr.GetFormatiProdottoFinitoHome
        '    lst = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "Nome"}, New LUNA.LunaSearchParameter("InEvidenza", enSiNo.Si))
        'End Using

        'Dim R As New TableRow
        'For Each fp As FormatoProdottoW In lst
        '    If R.Cells.Count = 4 Then
        '        tableProdotti.Rows.Add(R)
        '        R = New TableRow
        '    End If
        '    Dim C As New TableCell
        '    Dim Pt As New My.Templates.FormatoProdottoFinito
        '    Pt.F = fp
        '    Using mgr As New PreventivazioniWDAO
        '        qui devo trovare la prima preventivazione in cui e' usato questo formato prodotto
        '        Dim P As PreventivazioneW = Nothing
        '        P = mgr.GetFirstPreventivazioneFromFP(fp.IdFormProd)
        '        Pt.P = P
        '    End Using
        '    C.Text = Pt.TransformText
        '    R.Cells.Add(C)
        'Next

        'If R.Cells.Count Then
        '    tableProdotti.Rows.Add(R)
        'End If

    End Sub

    Private Sub CaricaOfferte()

        Dim ShowLabel As Boolean = True

        'qui carico le promozioni
        Dim lp As List(Of PreventivazioneW) = Nothing 'DirectCast(Application("ListaPreventivazioni"), List(Of PreventivazioneW)).FindAll(Function(x) x.PercCoupon <> 0)
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

        RandomLb.Carica()
        RandomLb1.Carica()
        RandomLb2.Carica()
    End Sub

    Protected ReadOnly Property IsHomePage As Boolean
        Get

            Dim ris As Boolean = False

            If Page.AppRelativeVirtualPath = "~/default.aspx" Then
                ris = True
            End If

            Return ris

        End Get
    End Property

    '{ label: "anders", category: "" },
    '{ label: "andreas", category: "" },
    '{ label: "antal", category: "" },
    '{ label: "annhhx10", category: "Products" },
    '{ label: "annk K12", category: "Products" },
    '{ label: "annttop C13", category: "Products" },
    '{ label: "anders andersson", category: "People" },
    '{ label: "andreas andersson", category: "People" },
    '{ label: "andreas johnson", category: "People" }

    Private Sub rptOfferte_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptOfferte.ItemDataBound
        Dim Pre As PreventivazioneW = e.Item.DataItem
        Dim P As ucPrevPromo = e.Item.FindControl("PrevPromo")

        If Not P Is Nothing Then
            P.Preventivazione = Pre
        End If

    End Sub

End Class