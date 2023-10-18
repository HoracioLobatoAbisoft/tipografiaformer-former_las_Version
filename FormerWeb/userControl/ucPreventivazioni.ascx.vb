Imports FormerBusinessLogicInterface
Imports FormerDALWeb
Imports FormerLib.FormerEnum
Public Class ucPreventivazioni
    Inherits FormerUserControl

    Private _IdPrev As Integer = 0

    Public ReadOnly Property IdPreventivazioneCliccata As Integer
        Get
            Return _IdPrev
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _IdPrev = Convert.ToInt32(Page.RouteData.Values("idp"))
        '_IdFormato = Convert.ToInt32(Page.RouteData.Values("idf"))
        '_IdTipoCarta = Convert.ToInt32(Page.RouteData.Values("idc"))
        '_IdColori = Convert.ToInt32(Page.RouteData.Values("ids"))
        ''       _DescrizioneUrl = Convert.ToString(Page.RouteData.Values("descrizione"))
        '        _Nfogli = Convert.ToInt32(Page.RouteData.Values("nfogli"))

        If Not IsPostBack Then
            CaricaPreventivazioni()
        End If

    End Sub

    Public Sub CaricaPreventivazioni()

        Dim lstP As List(Of PreventivazioneW) = Nothing

        If FormerWebApp.UseStaticCollection = enSiNo.Si Then
            lstP = FormerWebApp.StaticPreventivazioni
        Else
            Using mgr As New PreventivazioniWDAO
                lstP = mgr.FindAll("IdReparto, Descrizione", New LUNA.LunaSearchParameter("DispOnline", enSiNo.Si))
            End Using
        End If

        'lstP = Application("ListaPreventivazioni")

        Dim lstOffSet As List(Of PreventivazioneW) = Nothing
        Dim lstDigit As List(Of PreventivazioneW) = Nothing
        Dim lstRicamo As List(Of PreventivazioneW) = Nothing
        Dim lstPackaging As List(Of PreventivazioneW) = Nothing
        Dim lstOff As List(Of PreventivazioneW) = Nothing
        Dim lstEtichette As List(Of PreventivazioneW) = Nothing

        lstOffSet = lstP.FindAll(Function(x) x.IdReparto = enRepartoWeb.StampaOffset And x.NascondiAlbero = enSiNo.No)
        'lstOffSet.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))
        lstDigit = lstP.FindAll(Function(x) x.IdReparto = enRepartoWeb.StampaDigitale And x.NascondiAlbero = enSiNo.No)
        'lstDigit.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))
        lstRicamo = lstP.FindAll(Function(x) x.IdReparto = enRepartoWeb.Ricamo And x.NascondiAlbero = enSiNo.No)
        'lstRicamo.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))
        lstPackaging = lstP.FindAll(Function(x) x.IdReparto = enRepartoWeb.Packaging And x.NascondiAlbero = enSiNo.No)

        lstEtichette = lstP.FindAll(Function(x) x.IdReparto = enRepartoWeb.Etichette And x.NascondiAlbero = enSiNo.No)
        'lstPackaging.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))
        lstOff = lstP.FindAll(Function(x) x.PercCoupon <> 0)
        'lstOff.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))

        'If Cache(FormerWebApp.CacheKeyLstOffSet) Is Nothing Then
        '    Using P As New PreventivazioniWDAO
        '        lstOffSet = P.GetForHome(enRepartoWeb.StampaOffset)
        '        lstDigit = P.GetForHome(enRepartoWeb.StampaDigitale)
        '        lstRicamo = P.GetForHome(enRepartoWeb.Ricamo)
        '        lstPackaging = P.GetForHome(enRepartoWeb.Packaging)
        '    End Using
        '    Cache.Insert(FormerWebApp.CacheKeyLstOffSet, lstOffSet, Nothing, Now.AddHours(1), TimeSpan.Zero)
        '    Cache.Insert(FormerWebApp.CacheKeyLstDigitale, lstDigit, Nothing, Now.AddHours(1), TimeSpan.Zero)
        '    Cache.Insert(FormerWebApp.CacheKeyLstRicamo, lstRicamo, Nothing, Now.AddHours(1), TimeSpan.Zero)
        '    Cache.Insert(FormerWebApp.CacheKeyLstPackaging, lstPackaging, Nothing, Now.AddHours(1), TimeSpan.Zero)
        'Else
        '    lstOffSet = Cache(FormerWebApp.CacheKeyLstOffSet)
        '    lstDigit = Cache(FormerWebApp.CacheKeyLstDigitale)
        '    lstRicamo = Cache(FormerWebApp.CacheKeyLstRicamo)
        '    lstPackaging = Cache(FormerWebApp.CacheKeyLstPackaging)
        'End If

        rptPreventivazione.DataSource = lstOffSet
        rptPreventivazione.DataBind()

        If lstDigit.Count Then
            _ShowDigitale = True
            rptDigitale.DataSource = lstDigit
            rptDigitale.DataBind()
        End If

        If lstRicamo.Count Then
            _ShowRicamo = True
            rptRicamo.DataSource = lstRicamo
            rptRicamo.DataBind()
        End If

        If lstPackaging.Count Then
            _ShowPackaging = True
            rptPackaging.DataSource = lstPackaging
            rptPackaging.DataBind()
        End If

        If lstEtichette.Count Then
            _ShowEtichette = True
            rptEtichette.DataSource = lstEtichette
            rptEtichette.DataBind()
        End If

        If lstOff.Count Then
            rptOfferte.DataSource = lstOff
            rptOfferte.DataBind()
            _ShowOfferte = True
        End If

        Using mgr As New CatVirtualiWDAO
            Dim lstCatV As List(Of CatVirtualeW) = mgr.GetAll("Nome")

            lstCatV = lstCatV.FindAll(Function(X) X.ListiniBase.Count)

            rptCatVirtuali.DataSource = lstCatV
            rptCatVirtuali.DataBind()

        End Using

    End Sub

    Public Function GetClassSelectedItem(IdPrev As Integer) As String
        Dim ris As String = ""

        If IdPrev = IdPreventivazioneCliccata Then
            ris = "treeviewitemSelected"
        End If

        Return ris
    End Function

    Private Sub rptPreventivazione_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptPreventivazione.ItemDataBound,
                                                                                                        rptDigitale.ItemDataBound,
                                                                                                        rptEtichette.ItemDataBound,
                                                                                                        rptPackaging.ItemDataBound,
                                                                                                        rptRicamo.ItemDataBound

        If Not e.Item Is Nothing Then
            Dim p As PreventivazioneW = DirectCast(e.Item.DataItem, PreventivazioneW)
            If Not p Is Nothing Then
                If p.IdPrev = IdPreventivazioneCliccata Then

                    If p.IdPluginToUse = 0 Then
                        Dim l As New List(Of ListinoBaseW)

                        Dim LInt As List(Of ListinoBaseW) = p.GetListiniBase
                        'LInt.Sort(Function(x, y) x.TipoCarta.Grammi.CompareTo(y.TipoCarta.Grammi))


                        Using mgrP As New PreventivazioniWDAO
                            mgrP.OrdinaAlberoWeb(LInt)
                        End Using

                        'If p.IdColoreStampaDefault <> 0 Then
                        '    For Each singL As ListinoBaseW In LInt.FindAll(Function(x) x.IdColoreStampa = p.IdColoreStampaDefault)
                        '        If l.FindAll(Function(x) x.IdFormProd = singL.IdFormProd).Count = 0 Then
                        '            l.Add(singL)
                        '        End If
                        '    Next
                        'End If

                        For Each singL As ListinoBaseW In LInt
                            If l.FindAll(Function(x) x.IdFormProd = singL.IdFormProd).Count = 0 Then
                                l.Add(singL)
                            End If
                        Next

                        Dim rp As Repeater = e.Item.FindControl("rptListiniBase")
                        rp.DataSource = l
                        rp.DataBind()
                    End If

                End If
            End If
        End If

    End Sub

    Private _ShowOfferte As Boolean = False
    Protected ReadOnly Property ShowOfferte() As Boolean
        Get
            Return _ShowOfferte
        End Get
    End Property

    Private _ShowDigitale As Boolean = False
    Protected ReadOnly Property ShowDigitale() As Boolean
        Get
            Return _ShowDigitale
        End Get
    End Property

    Private _ShowPackaging As Boolean = False
    Protected ReadOnly Property ShowPackaging() As Boolean
        Get
            Return _ShowPackaging
        End Get
    End Property

    Private _ShowEtichette As Boolean = False
    Protected ReadOnly Property ShowEtichette() As Boolean
        Get
            Return _ShowEtichette
        End Get
    End Property

    Private _ShowRicamo As Boolean = False
    Protected ReadOnly Property ShowRicamo() As Boolean
        Get
            Return _ShowRicamo
        End Get
    End Property

End Class