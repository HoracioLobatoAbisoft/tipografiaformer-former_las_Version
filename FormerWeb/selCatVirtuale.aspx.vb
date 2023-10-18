Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class selCatVirtuale
    Inherits FormerFreePage
    Implements IFormerWizardPage

    Private _idC As Integer = 0

    Public C As CatVirtualeW

    Protected ReadOnly Property OgTitle As String Implements IFormerWizardPage.OgTitle
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = C.Nome
            Return ris
        End Get
    End Property

    Protected ReadOnly Property OgDescription As String Implements IFormerWizardPage.OgDescription
        Get
            Dim ris As String = String.Empty 'Request.Url.AbsolutePath
            'ris = ris.Substring(ris.LastIndexOf("/") + 1).Replace("_", " ")
            ris = C.Nome
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

        Session("PageTitle") = "Scegli un prodotto"

        'If Not IsPostBack Then

        Dim titoloPagina As String = "Tipografia Former Online, il tuo mondo della stampa a Roma - Stampa "

        _idC = Convert.ToInt32(Page.RouteData.Values("idC"))
        C = New CatVirtualeW
        C.Read(_idC)
        If C.IdCatVirtuale = 0 Then
            Response.Redirect("/")
        End If

        SpecificDescriptionBuffer = OgDescription

        titoloPagina &= C.Nome & " "
        'lblProdotto.Text = P.Descrizione

        'titoloPagina &= " - Tipografiaformer.it, il tuo mondo della stampa a Roma"
        Title = titoloPagina
        'Header.Controls.Add(New HtmlMeta() With {.Name = "keywords", .Content = titoloPagina})

        If Not IsPostBack Then CaricaWizard()

        'End If

    End Sub

    Private Sub CaricaWizard()

        Dim lst As List(Of ListinoBaseW) = C.ListiniBase

        'lst = DirectCast(Application("ListaListiniBase"), List(Of ListinoBaseW)).FindAll(Function(x) x.IdPrev = _idP)

        'Using L As New ListinoBaseWDAO
        '    lst = L.ListiniByCatVirtuale(_idC)
        'End Using

        If lst.Count = 0 Then
            Response.Redirect("/")
        Else
            'li ordino per grandezza
            'Using P As New PreventivazioniWDAO
            '    P.OrdinaListinoPerFormatoProd(lst)
            'End Using

            lst.Sort(Function(x, y) x.Nome.CompareTo(y.Nome))

            Dim R As New TableRow

            For Each cp As ListinoBaseW In lst
                Dim imlInd As Integer = 0

                If R.Cells.Count = 4 Then
                    tableWizard.Rows.Add(R)
                    R = New TableRow
                End If

                Dim C As New TableCell

                Dim Pt As New My.Templates.ListinoBase
                Pt.L = cp
                C.Text = Pt.TransformText
                R.Cells.Add(C)
            Next

            If R.Cells.Count Then
                tableWizard.Rows.Add(R)
            End If
        End If



    End Sub

End Class