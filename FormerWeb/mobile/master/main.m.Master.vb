Imports FormerBusinessLogic
Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class main_m
    Inherits FormerMasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CaricaPreventivazioni()
        End If
    End Sub


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

    Public Function GetSpecificDescription(Optional ConVirgolette As Boolean = True) As String

        Dim Ris As String = String.Empty
        Dim InsideContent As Boolean = False

        'If TypeOf body.Page Is IFormerWizardPage Then

        '    Dim P As IFormerWizardPage = body.Page
        '    Ris = P.OgDescription
        '    If Ris.Length Then InsideContent = True

        'End If

        If InsideContent = False Then
            Ris = FormerWebApp.MetaDescription
        End If

        If ConVirgolette Then
            Ris = """" & Ris & """"
        End If

        Return Ris

    End Function

    Public Sub CaricaPreventivazioni()

        Dim lstP As List(Of PreventivazioneW) = Nothing

        If FormerWebApp.UseStaticCollection = enSiNo.Si Then
            lstP = FormerWebApp.StaticPreventivazioni
        Else
            Using mgr As New PreventivazioniWDAO
                lstP = mgr.FindAll("IdReparto, Descrizione",
                                   New LUNA.LunaSearchParameter(LFM.PreventivazioneW.DispOnline, enSiNo.Si))
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

        Dim lstOffSetV As List(Of GenericWebObject) = MgrGenericWebObject.FromListPreventivazione(lstOffSet)

        rptPreventivazione.DataSource = lstOffSetV
        rptPreventivazione.DataBind()

        If lstDigit.Count Then
            _ShowDigitale = True
            Dim lstDigitV As List(Of GenericWebObject) = MgrGenericWebObject.FromListPreventivazione(lstDigit)
            rptDigitale.DataSource = lstDigitV
            rptDigitale.DataBind()
        End If

        If lstRicamo.Count Then
            _ShowRicamo = True
            Dim lstRicamoV As List(Of GenericWebObject) = MgrGenericWebObject.FromListPreventivazione(lstRicamo)
            rptRicamo.DataSource = lstRicamoV
            rptRicamo.DataBind()
        End If

        If lstPackaging.Count Then
            _ShowPackaging = True
            Dim lstPackagingV As List(Of GenericWebObject) = MgrGenericWebObject.FromListPreventivazione(lstPackaging)
            rptPackaging.DataSource = lstPackagingV
            rptPackaging.DataBind()
        End If

        If lstEtichette.Count Then
            _ShowEtichette = True
            Dim lstEtichetteV As List(Of GenericWebObject) = MgrGenericWebObject.FromListPreventivazione(lstEtichette)
            rptEtichette.DataSource = lstEtichetteV
            rptEtichette.DataBind()
        End If

        'If lstOff.Count Then
        '    rptOfferte.DataSource = lstOff
        '    rptOfferte.DataBind()
        '    _ShowOfferte = True
        'End If

        'Using mgr As New CatVirtualiWDAO
        '    Dim lstCatV As List(Of CatVirtualeW) = mgr.GetAll("Nome")

        '    lstCatV = lstCatV.FindAll(Function(X) X.ListiniBase.Count)

        '    rptCatVirtuali.DataSource = lstCatV
        '    rptCatVirtuali.DataBind()

        'End Using

    End Sub
    Protected Sub lnkEsci_Click(sender As Object, e As EventArgs) Handles lnkEsci.Click
        DirectCast(Page, FormerPage).TerminaSessioneLavoro()
    End Sub
    Public Function GetSpecificKeywords(Optional ConVirgolette As Boolean = True) As String

        Dim ris As String = String.Empty
        Dim InsideContent As Boolean = False


        'If TypeOf body.Page Is IFormerWizardPage Then

        '    Dim P As IFormerWizardPage = body.Page
        '    ris = P.OgKeywords
        '    If ris.Length Then
        '        InsideContent = True
        '    End If

        'End If

        If InsideContent = False Then
            ris = "Tipografia Former,Tipografia, Tipografia Roma, Stampa Offset, Stampa Digitale, Packaging, Ricamo"

            'ora se qui la content page mi fornisce keyword specifiche prendo le sue altrimenti aggiungo i  nomi di tutte le preventivazioni 

            ris &= ", " & Application("SpecificKeywords")

        End If

        If ConVirgolette Then
            ris = """" & ris & """"
        End If

        Return ris

    End Function


    Public Function getNominativoUtente() As String

        Dim ris As String = String.Empty

        ris = Server.HtmlEncode(UtenteConnesso.Nominativo)

        If ris.Length > 25 Then
            ris = ris.Substring(0, 25) & "..."
        End If

        Return ris

    End Function

    Private Sub btnCerca_Click(sender As Object, e As EventArgs) Handles btnCerca.Click

        'eseguoo il cerca

        Dim TestoToSearch As String = txtCerca.Text
        If TestoToSearch.Trim.Length > 1 Then

            TestoToSearch = FormerSearchEngine.EncryptRichiesta(TestoToSearch)

            Response.Redirect("/cerca/" & TestoToSearch)
        Else
            Response.Redirect("/")
        End If

    End Sub
End Class