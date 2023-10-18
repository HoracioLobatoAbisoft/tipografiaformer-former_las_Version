Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class pElencoLavorazioni
    Inherits FormerFreePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("PageTitle") = "Le nostre lavorazioni"
        If Not IsPostBack Then

            CaricaLavorazioni()

        End If
    End Sub

    Private Sub CaricaLavorazioni()
        Dim lc As List(Of CatLavW)

        Using Mgr As New CatLavWDAO
            lc = Mgr.FindAll("Descrizione",
                             New LUNA.LunaSearchParameter("TipoCaratteristica", enSiNo.Si, "<>"),
                             New LUNA.LunaSearchParameter("IdCatLav", "(SELECT DISTINCT IdCatLav FROM T_Lavori WHERE idlavoro IN (select distinct idlavoro from tr_lavprev))", "IN"))
        End Using
        'Dim l As List(Of LavorazioneW) = (New LavorazioniWDAO).GetAll("IdCatLav")

        lc = lc.FindAll(Function(x) x.GetLavorazioni.FindAll(Function(y) y.LavorazioneInterna = enSiNo.No).Count)

        rptCatLav.DataSource = lc
        rptCatLav.DataBind()
        'tablelav
    End Sub

    Protected Sub rptCatLav_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptCatLav.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim gvTemp As Repeater = CType(e.Item.FindControl("rptLav"), Repeater)

            Dim cat As CatLavW = e.Item.DataItem

            gvTemp.DataSource = cat.GetLavorazioni.FindAll(Function(x) x.LavorazioneInterna = enSiNo.No)
            gvTemp.DataBind()

        End If
    End Sub

End Class