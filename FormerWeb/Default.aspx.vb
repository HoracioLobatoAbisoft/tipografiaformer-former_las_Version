Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class pHomePage
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("PageTitle") = "Scegli un Prodotto"
        If Not IsPostBack Then

            CaricaWizard()

        End If

    End Sub

    Private Sub CaricaWizard()

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

        Dim R As New TableRow
        For Each P As PreventivazioneW In lst
            If R.Cells.Count = 4 Then
                tableWizard.Rows.Add(R)
                R = New TableRow
            End If
            Dim C As New TableCell
            Dim Pt As New My.Templates.PreventivazioneWizard
            Pt.P = P
            C.Text = Pt.TransformText
            R.Cells.Add(C)
        Next

        If R.Cells.Count Then
            tableWizard.Rows.Add(R)
        End If

    End Sub

End Class