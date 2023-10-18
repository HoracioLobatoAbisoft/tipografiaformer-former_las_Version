Imports FormerDALEventi

Public Class admin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Using mgr As New ContattiDAO

                Dim lC As List(Of Contatto) = mgr.GetAll()

                lblTot.Text = lC.Count
            End Using
        End If

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If txtPwd.Text = "t1p0gr4f14" Then

            Using mgr As New ContattiDAO

                Dim lC As List(Of Contatto) = mgr.FindAll(New LUNA.LunaSearchOption With {.Top = 20, .OrderBy = "IdContatto Desc"})

                'lblTot.Text = lC.Count

                'lC.Sort(Function(x, y) y.IdContatto.CompareTo(x.IdContatto))

                'Dim L As IEnumerable(Of Contatto) = (From n In lC).Take(20)

                grdDati.DataSource = lC
                grdDati.DataBind()

            End Using

        Else
            Response.Redirect("admin.aspx")
        End If

    End Sub
End Class