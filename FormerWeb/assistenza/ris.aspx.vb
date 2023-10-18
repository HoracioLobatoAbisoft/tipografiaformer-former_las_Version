Public Class risAssistenza
    Inherits FormerPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ris As Integer = Convert.ToInt32(Page.RouteData.Values("ris"))
        Select Case ris
            Case 0
                pnlOk.Visible = True
                pnlErr.Visible = False
                pnlCap.Visible = False
            Case 1
                pnlOk.Visible = False
                pnlErr.Visible = True
                pnlCap.Visible = False
            Case 2
                pnlOk.Visible = False
                pnlErr.Visible = False
                pnlCap.Visible = True
        End Select

    End Sub

End Class