Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class pFormatoW
    Inherits FormerFreePage
    Implements IFormerWizardPage

    Private _idP As Integer = 0
    Public P As PreventivazioneW
    Public ReadOnly Property IdP As Integer
        Get
            Return _idP
        End Get
    End Property

    Protected ReadOnly Property OgTitle As String Implements IFormerWizardPage.OgTitle
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = P.Descrizione
            Return ris
        End Get
    End Property

    Protected ReadOnly Property OgDescription As String Implements IFormerWizardPage.OgDescription
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = P.DescrizioneEstesa
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

        Session("PageTitle") = "Scegli un formato"

        'If Not IsPostBack Then

        Dim titoloPagina As String = "Stampa "

        _idP = Convert.ToInt32(Page.RouteData.Values("idp"))
        P = New PreventivazioneW
        P.Read(_idP)
        If P.DispOnline = False Then
            Response.Redirect("/")
        End If
        SpecificDescriptionBuffer = OgDescription
        MgrPlugin.CheckNeedPlugin(P, enStepWizard.FormatoProdotto)

        titoloPagina &= P.Descrizione & " "
        'lblProdotto.Text = P.Descrizione

        'titoloPagina &= " - Tipografiaformer.it, il tuo mondo della stampa a Roma"
        Title = titoloPagina
        'Header.Controls.Add(New HtmlMeta() With {.Name = "keywords", .Content = titoloPagina})

        If Not IsPostBack Then CaricaWizard()

        'End If

    End Sub

    Private Sub CaricaWizard()

        Dim lst As List(Of ListinoBaseW)

        'lst = DirectCast(Application("ListaListiniBase"), List(Of ListinoBaseW)).FindAll(Function(x) x.IdPrev = _idP)


        If FormerWebApp.UseStaticCollection = enSiNo.Si Then
            lst = FormerWebApp.StaticListiniBase.FindAll(Function(x) x.IdPrev = _idP)
        Else
            Using L As New ListinoBaseWDAO
                lst = L.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "idFormato"},
                            New LUNA.LunaSearchParameter("IdPrev", _idP),
                            New LUNA.LunaSearchParameter("NascondiOnline", enSiNo.Si, "<>"),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
            End Using
        End If


        'carico i listini base correlati
        Dim IdFormerChoice As Integer = 0

        For Each lb In lst
            If lb.IsFormerChoice = enSiNo.Si Then
                IdFormerChoice = lb.IdFormProd
                Exit For
            End If
        Next

        Using Pl As New PrevLinkListinoDAO
            Dim lstPL As List(Of PrevLinkListino) = Pl.FindAll(New LUNA.LunaSearchParameter("IdPreventivazione", _idP))
            For Each SingPl As PrevLinkListino In lstPL
                Dim singL As New ListinoBaseW
                singL.Read(SingPl.IdListinoBase)
                If singL.NascondiOnline <> enSiNo.Si AndAlso singL.Disattivo <> enSiNo.Si Then
                    singL.Linkato = True
                    lst.Add(singL)
                End If
            Next
        End Using

        'li ordino per grandezza
        Using P As New PreventivazioniWDAO
            P.OrdinaListinoPerFormatoProd(lst)
        End Using

        If lst.Count = 0 Then Response.Redirect("/")

        Dim CountFormati As Integer = 0
        Dim IdFirstFormato As Integer = 0
        Dim UltLis As ListinoBaseW = Nothing

        Dim strIdF As String = ","
        Dim strIdC As String = ","

        Dim R As New TableRow

        For Each cp As ListinoBaseW In lst
            UltLis = cp
            Dim imlInd As Integer = 0
            Dim IdFormato As Integer = cp.IdFormProd

            If IdFormato Then
                IdFirstFormato = IdFormato

                Dim MettiInCat As Boolean = False
                Dim IdCat As Integer = cp.FormatoProdotto.IdCatFormatoProdotto

                If IdCat Then
                    'qui devo vedere se creare la voce per la categoria
                    'se ci sono almeno altri 2 formati prodotto della stessa categoria 

                    Dim lFCat As List(Of ListinoBaseW) = lst.FindAll(Function(x) x.FormatoProdotto.IdCatFormatoProdotto = IdCat)

                    Dim IdFTrovati As String = ","
                    Dim FormatiInCatTrovati As Integer = 0
                    For Each singL As ListinoBaseW In lFCat
                        If IdFTrovati.IndexOf("," & singL.IdFormProd & ",") = -1 Then
                            IdFTrovati &= singL.IdFormProd & ","
                            FormatiInCatTrovati += 1
                        End If
                    Next

                    '***CATEGORIE SOLO SE CI SONO ALMENO 3 SCELTE
                    'If FormatiInCatTrovati > 2 Then
                    MettiInCat = True
                    'End If
                End If

                If MettiInCat Then
                    'qui creo la categoria
                    If strIdC.IndexOf("," & IdCat & ",") = -1 Then
                        CountFormati += 1
                        strIdC &= IdCat & ","

                        Using C As New CatFormatoProdottoW
                            C.Read(IdCat)
                            If R.Cells.Count = 4 Then
                                tableWizard.Rows.Add(R)
                                R = New TableRow
                            End If

                            Dim Cell As New TableCell
                            Dim Pt As New My.Templates.CatFormatoProdottoWizard

                            Pt.UrlPrecedente = cp.Preventivazione.NomeInUrl
                            Pt.IdPrev = cp.IdPrev
                            Pt.IdCat = IdCat
                            Pt.C = C
                            Pt.IdPrev = _idP
                            Cell.Text = Pt.TransformText
                            R.Cells.Add(Cell)
                        End Using
                    End If
                Else
                    'qui invece va calcolato singolo 
                    If strIdF.IndexOf("," & IdFormato & ",") = -1 Then
                        CountFormati += 1
                        strIdF &= IdFormato & ","
                        Using F As New FormatoProdottoW
                            F.Read(IdFormato)
                            If R.Cells.Count = 4 Then
                                tableWizard.Rows.Add(R)
                                R = New TableRow
                            End If

                            Dim C As New TableCell
                            Dim Pt As New My.Templates.FormatoProdottoWizard
                            If IdFormato = IdFormerChoice Then Pt.IsConsigliato = True
                            If cp.Linkato Then
                                Pt.UrlPrecedente = cp.Preventivazione.NomeInUrl
                                Pt.IdPrev = cp.IdPrev
                            Else
                                Pt.UrlPrecedente = Page.RouteData.Values("descrizione")
                                Pt.IdPrev = _idP
                            End If
                            Pt.F = F
                            C.Text = Pt.TransformText
                            R.Cells.Add(C)
                        End Using
                    End If
                End If


            End If
        Next

        If R.Cells.Count Then
            tableWizard.Rows.Add(R)
        End If

        If P.PercCoupon Then
            PrevPromo.WithHeader = True
            PrevPromo.WithFooter = False
            PrevPromo.Preventivazione = P
            PrevPromo.Visible = True
        Else
            PrevPromo.Visible = False
        End If

        If CountFormati = 1 Then
            Dim NuovaUrl As String = "/" & _idP & "/" & IdFirstFormato & "/" & UltLis.NomeInUrl

            Response.Redirect(NuovaUrl)

        End If

    End Sub

End Class