Imports FormerWebDao

Public Class popzioniW
    Inherits FormerPage

    Private _IdPrev As Integer = 0
    Private _IdFormato As Integer = 0
    Private _IdTipoCarta As Integer = 0
    Private _IdColori As Integer = 0
    Private _NFogli As Integer = 0
    Public L As ListinoBaseW
    Public P As PreventivazioneW
    Public F As FormatoProdottoW
    Public TC As TipoCartaW
    Public C As ColoreStampaW

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _IdPrev = Convert.ToInt32(Page.RouteData.Values("idp"))
        _IdFormato = Convert.ToInt32(Page.RouteData.Values("idf"))
        _IdTipoCarta = Convert.ToInt32(Page.RouteData.Values("idc"))
        _IdColori = Convert.ToInt32(Page.RouteData.Values("ids"))
        _NFogli = Convert.ToInt32(Page.RouteData.Values("nfogli"))

        Dim titoloPagina As String = "Stampa "
        Dim urlPagina As String = String.Empty

        P = New PreventivazioneW
        P.Read(_IdPrev)
        titoloPagina &= P.Descrizione & " "
        urlPagina &= P.NomeInUrl & "_"

        F = New FormatoProdottoW
        F.Read(_IdFormato)
        titoloPagina &= F.Formato & " "
        urlPagina &= F.NomeInUrl & "_"

        TC = New TipoCartaW
        TC.Read(_IdTipoCarta)
        titoloPagina &= TC.Tipologia & " "
        urlPagina &= TC.NomeInUrl & "_"

        C = New ColoreStampaW
        C.Read(_IdColori)
        titoloPagina &= C.Descrizione & " "
        urlPagina &= C.NomeInUrl

        Dim lst As List(Of ListinoBaseW) = (New ListinoBaseWDAO).Find(New LUNA.LunaSearchOption With {.OrderBy = "IdFormProd"}, _
                                                             New LUNA.LunaSearchParameter("IdPrev", _IdPrev), _
                                                             New LUNA.LunaSearchParameter("IdTipoCarta", _IdTipoCarta), _
                                                             New LUNA.LunaSearchParameter("IdColoreStampa", _IdColori), _
                                                             New LUNA.LunaSearchParameter("IdFormProd", _IdFormato))
        If lst.Count = 0 Then Response.Redirect("~/")
        L = lst(0)
        L.CaricaLavorazioniOpz()

        If L.LavorazioniOpz.Count = 0 Then
            Dim NFogli As Integer = 0
            NFogli = L.faccmin / 2
            Dim NumRif As Integer = 0

            If NFogli <> 1 Then
                If L.Target = enTarget.Foglio Then
                    urlPagina &= "_" & NFogli & "_" & L.GetLabelFogli

                Else
                    urlPagina &= "_" & L.faccmin & "_" & L.GetLabelFogli
                End If
            End If
            If L.Target = enTarget.Foglio Then
                NumRif = NFogli
            Else
                NumRif = L.faccmin
            End If

            Response.Redirect("/" & _IdPrev & "/" & _IdFormato & "/" & _IdTipoCarta & "/" & _IdColori & "/" & NumRif & "/0/" & urlPagina)
        Else
            'carico il wizard

        End If

    End Sub

End Class