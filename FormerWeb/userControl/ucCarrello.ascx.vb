Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucCarrello
    Inherits FormerUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CaricaCarrello()
    End Sub

    Private Sub CaricaCarrello()
        If Carrello.Ordini.Count = 0 Then
            Dim Tr As New TableRow
            Dim Tc As New TableCell
            Tc.Text = "Il tuo Carrello è vuoto"
            Tc.HorizontalAlign = HorizontalAlign.Center
            Tr.Cells.Add(Tc)
            tblCarrello.Rows.Add(Tr)
        Else
            For Each O As ProdottoInCarrello In Carrello.Ordini
                Dim Tr As New TableRow
                Dim Tc As TableCell

                Dim Img As New Image
                Img.ImageUrl = FormerWeb.FormerWebApp.PathListinoImg & O.BoxImgRif
                Img.Width = 32
                Img.Height = 32
                Tc = New TableCell
                Tc.Controls.Add(Img)
                Tc.Width = 32

                Tr.Cells.Add(Tc)

                Tc = New TableCell
                Tc.HorizontalAlign = HorizontalAlign.Left
                Tc.Text = O.RiassuntoBox
                Tc.Wrap = True

                Tr.Cells.Add(Tc)

                Tc = New TableCell
                Tc.HorizontalAlign = HorizontalAlign.Right
                If O.Omaggio = enSiNo.Si Then
                    Tc.Text = "<b class=""OmaggioLabel"">OMAGGIO</b>"
                Else
                    Tc.Text = "<b> € " & FormerHelper.Stringhe.FormattaPrezzo(O.PrezzoCalcolatoNetto) & "</b>"
                End If

                Tc.VerticalAlign = VerticalAlign.Top
                Tr.Cells.Add(Tc)

                tblCarrello.Rows.Add(Tr)
            Next

            'Dim TrTot As New TableRow
            'Dim TcTot As New TableCell

            'TcTot.ColumnSpan = 3
            'TcTot.Text = "<hr>"

            'TrTot.Cells.Add(TcTot)
            'tblCarrello.Rows.Add(TrTot)

            'TrTot = New TableRow
            'TcTot = New TableCell
            'TcTot.Text = ""
            'TrTot.Cells.Add(TcTot)

            'TcTot = New TableCell
            'TcTot.HorizontalAlign = HorizontalAlign.Right
            'TcTot.Text = "TOTALE"
            'TcTot.VerticalAlign = VerticalAlign.Middle
            'TrTot.Cells.Add(TcTot)

            'TcTot = New TableCell
            'TcTot.HorizontalAlign = HorizontalAlign.Right
            'TcTot.Text = "<b> € " & Carrello.TotaleCarrelloStr & "</b>"
            'TcTot.Font.Size = 11
            'TcTot.Wrap = False
            'TcTot.Width = 80
            'TrTot.Cells.Add(TcTot)
            'tblCarrello.Rows.Add(TrTot)
        End If


    End Sub

End Class