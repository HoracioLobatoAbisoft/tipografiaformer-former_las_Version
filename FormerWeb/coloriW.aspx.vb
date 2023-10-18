Imports FormerDALWeb
Imports FormerLib.FormerEnum
Public Class pColoriW
    Inherits FormerFreePage
    Implements IFormerWizardPage 

    Private _idFormatoSel As Integer = 0
    Private _idP As Integer = 0
    Public P As PreventivazioneW
    Public F As FormatoProdottoW
    Public TC As TipoCartaW

    Public ReadOnly Property IdP As Integer
        Get
            Return _idP
        End Get
    End Property

    Public ReadOnly Property IdFormatoSel As Integer
        Get
            Return _idFormatoSel
        End Get
    End Property

    Private _idTipoCartaSel As Integer = 0

    Public ReadOnly Property IdTipoCartaSel As Integer
        Get
            Return _idTipoCartaSel
        End Get
    End Property

    Protected ReadOnly Property OgTitle As String Implements IFormerWizardPage.OgTitle
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = P.Descrizione & " " & F.FormatoCartaStr & " " & TC.Tipologia
            Return ris
        End Get
    End Property

    Protected ReadOnly Property OgDescription As String Implements IFormerWizardPage.OgDescription
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = P.DescrizioneEstesa & " Formato " & F.FormatoCartaStr & " Carta " & TC.Tipologia
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
        Session("PageTitle") = "Scegli i Colori di stampa"
        ' If Not IsPostBack Then

        Dim titoloPagina As String = "Tipografia Former Online, il tuo mondo della stampa a Roma - Stampa "

        _idP = Convert.ToInt32(Page.RouteData.Values("idp"))
        _idFormatoSel = Convert.ToInt32(Page.RouteData.Values("idf"))
        _idTipoCartaSel = Convert.ToInt32(Page.RouteData.Values("idc"))

        P = New PreventivazioneW
        P.Read(_idP)
        If P.DispOnline = False Then
            Response.Redirect("/")
        End If

        MgrPlugin.CheckNeedPlugin(P, enStepWizard.ColoriStampa)

        titoloPagina &= P.Descrizione & " "

        F = New FormatoProdottoW
        F.Read(_idFormatoSel)
        titoloPagina &= F.Formato & " "

        TC = New TipoCartaW
        TC.Read(_idTipoCartaSel)
        titoloPagina &= TC.Tipologia & " "

        'titoloPagina &= " - Tipografiaformer.it, il tuo mondo della stampa a Roma"
        Title = titoloPagina
        'Header.Controls.Add(New HtmlMeta() With {.Name = "keywords", .Content = titoloPagina})
        If Not IsPostBack Then CaricaWizard()
        ' End If
    End Sub

    Private Sub CaricaWizard()


        Dim lst As List(Of ListinoBaseW)

        'lst = DirectCast(Application("ListaListiniBase"), List(Of ListinoBaseW)).FindAll(Function(x) x.IdPrev = _idP And x.IdFormProd = _idFormatoSel And x.IdTipoCarta = _idTipoCartaSel)


        If FormerWebApp.UseStaticCollection = enSiNo.Si Then
            lst = FormerWebApp.StaticListiniBase.FindAll(Function(x) x.IdPrev = _idP And
                                                             x.IdFormProd = _idFormatoSel And
                                                             x.IdTipoCarta = _idTipoCartaSel)
        Else

            Using mgr As New ListinoBaseWDAO
                lst = mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdFormProd"},
                            New LUNA.LunaSearchParameter("IdPrev", _idP),
                            New LUNA.LunaSearchParameter("IdTipoCarta", _idTipoCartaSel),
                            New LUNA.LunaSearchParameter("IdFormProd", _idFormatoSel),
                            New LUNA.LunaSearchParameter("NascondiOnline", enSiNo.Si, "<>"),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
            End Using
        End If


        Dim IdFirstColoreDiStampa As Integer = 0
        Dim CountColoriDiStampa As Integer = 0
        Dim UltLis As ListinoBaseW = Nothing
        'If P.IdColoreStampaDefault Then
        '    UltLis = lst.Find(Function(x) x.IdColoreStampa = P.IdColoreStampaDefault)
        '    If Not UltLis Is Nothing Then
        '        CountColoriDiStampa = 1
        '        IdFirstColoreDiStampa = P.IdColoreStampaDefault
        '    End If
        'End If

        Dim IdFormerChoice As Integer = 0

        For Each lb In lst
            If lb.IsFormerChoice = enSiNo.Si Then
                IdFormerChoice = lb.IdColoreStampa
                Exit For
            End If
        Next

        If UltLis Is Nothing Then
            'carico i listini base correlati
            Using Pl As New PrevLinkListinoDAO
                Dim lstPL As List(Of PrevLinkListino) = Pl.FindAll(New LUNA.LunaSearchParameter(LFM.PrevLinkListino.IdPreventivazione, _idP))
                For Each SingPl As PrevLinkListino In lstPL
                    Dim singL As New ListinoBaseW
                    singL.Read(SingPl.IdListinoBase)
                    If singL.IdFormProd = _idFormatoSel And singL.IdTipoCarta = _idTipoCartaSel Then
                        If singL.NascondiOnline <> enSiNo.Si And singL.Disattivo <> enSiNo.Si Then
                            singL.Linkato = True
                            lst.Add(singL)
                        End If
                    End If
                Next
            End Using

            Using mgr As New PreventivazioniWDAO
                mgr.OrdinaListinoPerColoreDiStampa(lst)
            End Using

            If lst.Count = 0 Then Response.Redirect("~/")
            Dim strTipiCarta As String = ","
            Dim R As New TableRow


            Dim CsNomeInUrl As String = String.Empty

            For Each cp As ListinoBaseW In lst
                UltLis = cp
                Dim imlInd As Integer = 0
                Dim IdColStampa As Integer = cp.IdColoreStampa

                If IdColStampa Then
                    CountColoriDiStampa += 1
                    IdFirstColoreDiStampa = IdColStampa
                    If strTipiCarta.IndexOf("," & IdColStampa & ",") = -1 Then
                        strTipiCarta &= IdColStampa & ","
                        Dim F As New ColoreStampaW
                        F.Read(IdColStampa)
                        If R.Cells.Count = 4 Then
                            tableWizard.Rows.Add(R)
                            R = New TableRow
                        End If
                        CsNomeInUrl = F.NomeInUrl
                        Dim C As New TableCell
                        Dim Pt As New My.Templates.ColoreStampaWizard
                        Pt.CS = F
                        If IdColStampa = IdFormerChoice Then Pt.IsConsigliato = True
                        If cp.Linkato Then
                            Pt.IdPrev = cp.IdPrev
                            Pt.UrlPrecedente = cp.Preventivazione.NomeInUrl & "-" & cp.FormatoProdotto.NomeInUrl & "-" & cp.TipoCarta.NomeInUrl
                        Else
                            Pt.UrlPrecedente = Page.RouteData.Values("descrizione")
                            Pt.IdPrev = _idP
                        End If
                        Pt.IdFormatoProdotto = _idFormatoSel
                        Pt.IdTipoCarta = _idTipoCartaSel
                        C.Text = Pt.TransformText
                        R.Cells.Add(C)
                    End If

                End If

            Next

            If R.Cells.Count Then
                tableWizard.Rows.Add(R)
            End If

        End If

        'arrivato qui se ho un solo colore di stampa devo passare oltre senza far scegliere
        If CountColoriDiStampa = 1 Then
            Dim NuovaUrl As String = "/" & _idP & "/" & _idFormatoSel & "/" & _idTipoCartaSel & "/" & IdFirstColoreDiStampa & "/" & UltLis.NomeInUrl

            Response.Redirect(NuovaUrl)

        End If

    End Sub

End Class