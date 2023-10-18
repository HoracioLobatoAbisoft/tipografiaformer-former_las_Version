Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucTavolozzaColori
    Inherits FormerUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Using mgr As New ColoriRGBWDAO

                Dim l As List(Of ColoreRGBW) = mgr.GetAll()

                For Each singC As ColoreRGBW In l

                    Dim Tr As New TableRow
                    Dim tc As New TableCell
                    tc.Text = ""
                    tc.BackColor = FormerColori.GetColorefromHtml(singC.HtmlCode)
                    tc.Width = 50
                    Tr.Cells.Add(tc)

                    tc = New TableCell
                    tc.Text = singC.Nome
                    Tr.Cells.Add(tc)

                    tbColori.Rows.Add(Tr)
                Next

            End Using

        End If

    End Sub

End Class