Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class ucPrezziTabellari
    Inherits FormerUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Event SelezioneCambiata()

    Private _L As ListinoBaseW = Nothing

    Public QtaCaricate As New List(Of Integer)

    Private Function CreaRiga(Qta As Integer,
                              QtaCouponDisp As List(Of Integer)) As TableRow

        QtaCaricate.Add(Qta)

        Dim R As New TableRow
        Dim EtichettaQta As String = FormerLib.FormerHelper.Stringhe.FormattaNumero(Qta)
        If QtaCouponDisp.FindAll(Function(x) x = Qta).Count <> 0 Then EtichettaQta &= " *"

        Dim C As New TableCell

        C.Text = EtichettaQta

        R.Cells.Add(C)

        'qui devo calcolare i tre prezzi e aggiungere le 3 celle

        C = New TableCell
        C.Text = "Fast"
        R.Cells.Add(C)

        C = New TableCell
        C.Text = "normal"
        R.Cells.Add(C)

        C = New TableCell
        C.Text = "Slow/promo"
        R.Cells.Add(C)

        Return R

    End Function


End Class