Imports FormerDALWeb
Imports FormerLib.FormerEnum
Public Class pfogliW
    Inherits FormerFreePage
    Implements IFormerWizardPage 

    Private _IdPrev As Integer = 0
    Private _IdFormato As Integer = 0
    Private _IdTipoCarta As Integer = 0
    Private _IdColori As Integer = 0
    Public L As ListinoBaseW
    Public P As PreventivazioneW
    Public F As FormatoProdottoW
    Public TC As TipoCartaW
    Public C As ColoreStampaW

    Protected ReadOnly Property OgTitle As String Implements IFormerWizardPage.OgTitle
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = P.Descrizione & " " & F.FormatoCartaStr & " " & TC.Tipologia & " " & C.Descrizione
            Return ris
        End Get
    End Property

    Protected ReadOnly Property OgDescription As String Implements IFormerWizardPage.OgDescription
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = P.DescrizioneEstesa & " Formato " & F.FormatoCartaStr & " Carta " & TC.Tipologia & " " & C.Descrizione
            Return ris
        End Get
    End Property

    Protected ReadOnly Property OgKeywords As String Implements IFormerWizardPage.OgKeywords
        Get
            Dim ris As String = String.Empty

            ris = IIf(OgTitle.ToLower.StartsWith("stampa"), "", "Stampa ") & OgTitle & " online, " & OgTitle & ", Tipografia Former"

            Return ris
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _IdPrev = Convert.ToInt32(Page.RouteData.Values("idp"))
        _IdFormato = Convert.ToInt32(Page.RouteData.Values("idf"))
        _IdTipoCarta = Convert.ToInt32(Page.RouteData.Values("idc"))
        _IdColori = Convert.ToInt32(Page.RouteData.Values("ids"))

        Dim titoloPagina As String = "Stampa "
        Dim urlPagina As String = String.Empty

        P = New PreventivazioneW
        P.Read(_IdPrev)
        If P.DispOnline = False Then
            Response.Redirect("/")
        End If

        MgrPlugin.CheckNeedPlugin(P, enStepWizard.Fogli)

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
        'titoloPagina &= " - Tipografiaformer.it, il tuo mondo della stampa a Roma"
        Title = titoloPagina

        urlPagina &= C.NomeInUrl

        Dim lst As List(Of ListinoBaseW)

        'lst = DirectCast(Application("ListaListiniBase"), List(Of ListinoBaseW)).FindAll(Function(x) x.IdPrev = _IdPrev And _
        '                                                                                     x.IdFormProd = _IdFormato And _
        '                                                                                     x.IdColoreStampa = _IdColori And _
        '                                                                                     x.IdTipoCarta = _IdTipoCarta)



        If FormerWebApp.UseStaticCollection = enSiNo.Si Then
            lst = FormerWebApp.StaticListiniBase.FindAll(Function(x) x.IdPrev = _IdPrev And
                                                             x.IdFormProd = _IdFormato And
                                                             x.IdTipoCarta = _IdTipoCarta And
                                                             x.IdColoreStampa = _IdColori)
        Else

            Using Mgr As New ListinoBaseWDAO
                lst = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdFormProd"},
                            New LUNA.LunaSearchParameter("IdPrev", _IdPrev),
                            New LUNA.LunaSearchParameter("IdTipoCarta", _IdTipoCarta),
                            New LUNA.LunaSearchParameter("IdColoreStampa", _IdColori),
                            New LUNA.LunaSearchParameter("IdFormProd", _IdFormato),
                            New LUNA.LunaSearchParameter("NascondiOnline", enSiNo.Si, "<>"),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
            End Using
        End If



        'carico i listini base correlati
        Using Pl As New PrevLinkListinoDAO
            Dim lstPL As List(Of PrevLinkListino) = Pl.FindAll(New LUNA.LunaSearchParameter("IdPreventivazione", _IdPrev))
            For Each SingPl As PrevLinkListino In lstPL
                Dim singL As New ListinoBaseW
                singL.Read(SingPl.IdListinoBase)
                If singL.IdFormProd = _IdFormato And singL.IdTipoCarta = _IdTipoCarta And singL.IdColoreStampa = _IdColori Then
                    If singL.NascondiOnline <> enSiNo.Si AndAlso singL.Disattivo <> enSiNo.Si Then
                        singL.Linkato = True
                        lst.Add(singL)
                    End If
                End If
            Next
        End Using

        lst.Sort(Function(x, y) x.Linkato.CompareTo(y.Linkato))

        If lst.Count = 0 Then Response.Redirect("~/")
        L = lst(0)


        Dim LabelFogli As String = L.GetLabelFogli()
        Dim NextUrl As String = String.Empty
        Dim NumRif As Integer = 0

        If L.faccmin = L.faccmax Then
            Dim NFogli As Integer = 0
            NFogli = L.faccmin / 2


            If NFogli <> 1 Then
                If L.Target = enTargetListinoBase.Foglio Then
                    urlPagina &= "_" & NFogli & "_" & LabelFogli
                Else
                    urlPagina &= "_" & L.faccmin & "_" & LabelFogli
                End If
            End If

            'If L.Target = enTarget.Foglio Then
            NumRif = NFogli
            'Else
            '    NumRif = L.faccmin
            'End If

            'NextUrl = "/" & _IdPrev & "/" & _IdFormato & "/" & _IdTipoCarta & "/" & _IdColori & "/" & NumRif & "/" & L.NomeInUrl

        Else

            'qui non devo caricare il wizard ma scegliere direttamente il primo blocco di fogli 

            'Dim R As New TableRow
            'Dim ValMin = L.faccmin / 2
            'Dim ValMax = L.faccmax / 2
            'Dim Moltiplicatore As Integer = L.MultiploQta

            NumRif = L.faccmin / 2

            'Do

            '    If R.Cells.Count = 4 Then
            '        tableWizard.Rows.Add(R)
            '        R = New TableRow
            '    End If
            '    Dim C As New TableCell
            '    Dim F As New My.Templates.FogliWizard
            '    F.IdPrev = _IdPrev
            '    F.UrlPrecedente = L.NomeInUrl 'Page.RouteData.Values("descrizione")
            '    F.IdFormatoProdotto = _IdFormato
            '    F.IdTipoCarta = _IdTipoCarta
            '    F.IdColoriStampa = _IdColori
            '    F.LabelFogli = LabelFogli
            '    F.NFogliVis = IIf(L.Target = enTargetListinoBase.Foglio, ValMin, (ValMin * 2))
            '    F.NFogli = ValMin
            '    C.Text = F.TransformText

            '    R.Cells.Add(C)

            '    ValMin += Moltiplicatore

            'Loop Until ValMin > ValMax

            'If R.Cells.Count Then

            '    tableWizard.Rows.Add(R)

            'End If

        End If

        NextUrl = "/" & _IdPrev & "/" & _IdFormato & "/" & _IdTipoCarta & "/" & _IdColori & "/" & NumRif & "/" & L.NomeInUrl

        Response.Redirect(NextUrl)

    End Sub

End Class