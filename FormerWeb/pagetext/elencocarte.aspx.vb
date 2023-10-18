Imports FormerDALWeb
Public Class pElencoCarte
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("PageTitle") = "I tipi di carta tra cui scegliere"
        If Not IsPostBack Then

            CaricaCarte()

        End If
    End Sub

    Private Sub CaricaCarte()
        Dim lc As List(Of String)

        Using Mgr As New TipiCartaWDAO
            lc = Mgr.GetFiniture
        End Using
        'Dim l As List(Of LavorazioneW) = (New LavorazioniWDAO).GetAll("IdCatLav")
        rptCatLav.DataSource = lc
        rptCatLav.DataBind()
        'tablelav
    End Sub

    Protected Sub rptCatLav_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptCatLav.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim gvTemp As Repeater = CType(e.Item.FindControl("rptLav"), Repeater)
            Dim ls As List(Of TipoCartaW)
            Using mgr As New TipiCartaWDAO
                ls = mgr.FindAll("Grammi", New LUNA.LunaSearchParameter("Finitura", e.Item.DataItem.ToString))
            End Using

            gvTemp.DataSource = ls
            gvTemp.DataBind()

        End If
    End Sub

End Class