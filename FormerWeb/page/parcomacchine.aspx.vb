Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class ParcoMacchine
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DirectCast(Page, FormerPage).Title = "Il Nostro Parco Macchine"
        Session("PageTitle") = "Il nostro Parco Macchine"

        If Not IsPostBack Then

            CaricaMacchinari()

        End If

    End Sub

    Private Sub CaricaMacchinari()

        Dim lst As List(Of MacchinarioW) = Nothing ' DirectCast(Application("ListaPreventivazioni"), List(Of PreventivazioneW)).FindAll(Function(x) x.IdReparto = RepartoScelto)
        Using P As New MacchinariWDAO
            lst = P.FindAll(New LUNA.LunaSearchParameter(LFM.MacchinarioW.VisibileOnline, enSiNo.Si))

            lst = lst.FindAll(Function(x) x.ImgRif.Length)
            lst.Sort(Function(x, y) x.DescrizioneEx.CompareTo(y.DescrizioneEx))
        End Using

        Dim R As New TableRow
        For Each M As MacchinarioW In lst
            If R.Cells.Count = 4 Then
                tableMacchinari.Rows.Add(R)
                R = New TableRow
            End If
            Dim C As New TableCell
            Dim Pt As New My.Templates.Macchinario
            Pt.M = M
            C.Text = Pt.TransformText
            R.Cells.Add(C)
        Next

        If R.Cells.Count Then
            tableMacchinari.Rows.Add(R)
        End If
    End Sub

End Class