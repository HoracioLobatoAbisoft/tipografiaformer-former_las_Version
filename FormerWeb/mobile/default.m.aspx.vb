Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class default_m
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CaricaHome()
        End If
    End Sub

    Private Sub CaricaHome()

        Dim RepartoScelto As enRepartoWeb = enRepartoWeb.StampaOffset

        If Page.RouteData.DataTokens.Count Then
            RepartoScelto = Page.RouteData.DataTokens("IdR")
        Else
            'FUNZIONE PER MOSTRARE A CASO UN RIPARTO DIVERSO NELLA HOME A OGNI VISITA
            Dim NumCas As Integer = 0

            Dim rnd As New Random()
            Randomize()
            NumCas = rnd.Next(1, 1000)
            If NumCas > 850 And NumCas < 900 Then
                RepartoScelto = enRepartoWeb.StampaDigitale
            ElseIf NumCas >= 900 And NumCas < 930 Then
                RepartoScelto = enRepartoWeb.Ricamo
            ElseIf NumCas >= 930 And NumCas < 960 Then
                RepartoScelto = enRepartoWeb.Packaging
            ElseIf NumCas >= 960 And NumCas <= 1000 Then
                RepartoScelto = enRepartoWeb.Etichette
            End If

        End If

        Dim lst As List(Of PreventivazioneW) = Nothing ' DirectCast(Application("ListaPreventivazioni"), List(Of PreventivazioneW)).FindAll(Function(x) x.IdReparto = RepartoScelto)

        If FormerWebApp.UseStaticCollection = enSiNo.Si Then
            lst = FormerWebApp.StaticPreventivazioni.FindAll(Function(x) x.IdReparto = RepartoScelto)
        Else
            Using P As New PreventivazioniWDAO
                lst = P.GetForHome(RepartoScelto)
            End Using
        End If

        Dim lstV As List(Of GenericWebObject) = MgrGenericWebObject.FromListPreventivazione(lst)

        rptHome.DataSource = lstV
        rptHome.DataBind()

    End Sub

    Public Function GetBannerRandom() As String

        '<a href="/offerte-e-promozioni-in-corso" ><img src="/banner/08.jpg" alt="Più ordini più Sconti. Scopri i nostri Coupon di acquisto" /></a>

        Dim ris As String = String.Empty

        Using mgr As New BannerDAO
            Dim l As List(Of Banner) = mgr.GetAll(LFM.Banner.IdBanner)

            If l.Count Then
                Randomize()

                'Dim listaScelti As New List(Of Banner)

                Dim r As New Random
                Dim Quanti As Integer = 1
                Dim Aggiunti As Integer = 0
                If l.Count < Quanti Then Quanti = l.Count

                Do Until Aggiunti = Quanti

                    Dim bannerScelto As Banner = l(r.Next(l.Count))

                    l.Remove(bannerScelto)

                    ris &= "<a href=""" & bannerScelto.Url & """ class=""image.fit""><img src=""/banner/" & bannerScelto.Path & """ alt=""" & bannerScelto.Alt & """ /></a>"
                    'ris &= "<li data-thumb=""/banner/" & bannerScelto.Path & """><a href=""" & bannerScelto.Url & """><img src=""/banner/" & bannerScelto.Path & """ alt=""" & bannerScelto.Alt & """ /></a></li>"
                    Aggiunti += 1
                Loop

            End If

        End Using

        Return ris

    End Function

End Class