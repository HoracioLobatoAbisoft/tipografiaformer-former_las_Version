Imports FormerDALWeb
Imports FormerLib.FormerEnum
Public Class pCartaW
    Inherits FormerFreePage
    Implements IFormerWizardPage

    Private _idFormatoSel As Integer = 0
    Private _idP As Integer = 0
    Public P As PreventivazioneW
    Public F As FormatoProdottoW

    Protected ReadOnly Property OgTitle As String Implements IFormerWizardPage.OgTitle
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = P.Descrizione & " " & F.Formato
            Return ris
        End Get
    End Property

    Protected ReadOnly Property OgDescription As String Implements IFormerWizardPage.OgDescription
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = P.DescrizioneEstesa & " Formato " & F.FormatoCartaStr
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
        Session("PageTitle") = "Scegli una Tipologia di Carta"
        'If Not IsPostBack Then
        'modificated-dev
        Dim titoloPagina As String = "Stampa "

        _idP = Convert.ToInt32(Page.RouteData.Values("idp"))
        _idFormatoSel = Convert.ToInt32(Page.RouteData.Values("idf"))
        P = New PreventivazioneW
        P.Read(_idP)

        If P.DispOnline = False Then
            Response.Redirect("/")
        End If

        MgrPlugin.CheckNeedPlugin(P, enStepWizard.TipoCarta)

        titoloPagina &= P.Descrizione & " "

        F = New FormatoProdottoW
        F.Read(_idFormatoSel)

        titoloPagina &= F.Formato & " "
        'titoloPagina &= " - Tipografiaformer.it, il tuo mondo della stampa a Roma"
        'Header.Controls.Add(New HtmlMeta() With {.Name = "keywords", .Content = titoloPagina})
        Title = titoloPagina

        If Not IsPostBack Then CaricaWizard()
        ' End If
    End Sub

    Private Sub CaricaWizard()

        Dim lst As List(Of ListinoBaseW)

        'lst = DirectCast(Application("ListaListiniBase"), List(Of ListinoBaseW)).FindAll(Function(x) x.IdPrev = _idP And x.IdFormProd = _idFormatoSel)

        If FormerWebApp.UseStaticCollection = enSiNo.Si Then
            lst = FormerWebApp.StaticListiniBase.FindAll(Function(x) x.IdPrev = _idP And x.IdFormProd = _idFormatoSel)
        Else
            Using L As New ListinoBaseWDAO
                lst = L.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "IdFormProd"},
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdPrev, _idP),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.IdFormProd, _idFormatoSel),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.NascondiOnline, enSiNo.Si, "<>"),
                            New LUNA.LunaSearchParameter(LFM.ListinoBaseW.Disattivo, enSiNo.Si, "<>"))
            End Using
        End If

        Dim IdFormerChoice As Integer = 0

        For Each lb In lst
            If lb.IsFormerChoice = enSiNo.Si Then
                IdFormerChoice = lb.IdTipoCarta
                Exit For
            End If
        Next

        'carico i listini base correlati
        Using Pl As New PrevLinkListinoDAO
            Dim lstPL As List(Of PrevLinkListino) = Pl.FindAll(New LUNA.LunaSearchParameter("IdPreventivazione", _idP))
            For Each SingPl As PrevLinkListino In lstPL
                Dim singL As New ListinoBaseW
                singL.Read(SingPl.IdListinoBase)
                If singL.IdFormProd = _idFormatoSel Then
                    If singL.NascondiOnline <> enSiNo.Si AndAlso singL.Disattivo <> enSiNo.Si Then
                        singL.Linkato = True
                        lst.Add(singL)
                    End If
                End If
            Next
        End Using



        'li ordino per grandezza
        Using P As New PreventivazioniWDAO
            P.OrdinaListinoPerGrammaturaCarta(lst)
        End Using

        Dim CountTipoCarta As Integer = 0
        Dim IdFirstTipoCarta As Integer = 0
        Dim UltLis As ListinoBaseW = Nothing

        If lst.Count = 0 Then Response.Redirect("/")
        Dim strTipiCarta As String = ","
        Dim R As New TableRow

        For Each cp As ListinoBaseW In lst
            UltLis = cp
            Dim imlInd As Integer = 0
            Dim IdTipoCarta As Integer = cp.IdTipoCarta

            If IdTipoCarta Then
                IdFirstTipoCarta = IdTipoCarta
                If strTipiCarta.IndexOf("," & IdTipoCarta & ",") = -1 Then
                    CountTipoCarta += 1
                    strTipiCarta &= IdTipoCarta & ","
                    Dim F As New TipoCartaW
                    F.Read(IdTipoCarta)
                    If R.Cells.Count = 4 Then
                        tableWizard.Rows.Add(R)
                        R = New TableRow
                    End If
                    Dim C As New TableCell
                    Dim Pt As New My.Templates.TipoCartaWizard

                    If IdTipoCarta = IdFormerChoice Then Pt.IsConsigliato = True

                    Pt.TC = F
                    If cp.Linkato Then
                        Pt.IdPrev = cp.IdPrev
                        Pt.UrlPrecedente = cp.Preventivazione.NomeInUrl & "-" & cp.FormatoProdotto.NomeInUrl
                    Else
                        Pt.UrlPrecedente = Page.RouteData.Values("descrizione")
                        Pt.IdPrev = _idP
                    End If
                    Pt.IdFormatoProdotto = _idFormatoSel
                    C.Text = Pt.TransformText
                    R.Cells.Add(C)
                End If

            End If

        Next

        If R.Cells.Count Then
            tableWizard.Rows.Add(R)
        End If

        If CountTipoCarta = 1 Then
            Dim NuovaUrl As String = "/" & _idP & "/" & _idFormatoSel & "/" & IdFirstTipoCarta & "/" & UltLis.NomeInUrl

            Response.Redirect(NuovaUrl)

        End If

    End Sub

End Class