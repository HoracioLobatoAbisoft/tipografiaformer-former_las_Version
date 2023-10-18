Imports FormerDALWeb
Imports FormerLib.FormerEnum
Public Class ucPreventivazioniEx
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CaricaPreventivazioni()
        End If

    End Sub

    Public Sub CaricaPreventivazioni(Optional IdReparto As enRepartoWeb = enRepartoWeb.StampaOffset)

        Dim lst As List(Of PreventivazioneW) = Nothing
        Using P As New PreventivazioniWDAO
            lst = P.GetForHome(IdReparto)
        End Using
        rptPreventivazione.DataSource = lst
        rptPreventivazione.DataBind()

        Dim IdPrev As Integer = Convert.ToInt32(Page.RouteData.Values("idp"))
        If IdPrev Then

            _TabIndexMenu = lst.FindIndex(Function(x) x.IdPrev = IdPrev)

        End If

    End Sub

    Protected Function ShowDigitale() As Boolean
        Dim ris As Boolean = False
        Return ris
    End Function

    Protected Function ShowPackaging() As Boolean
        Dim ris As Boolean = False
        Return ris
    End Function

    Protected Function ShowRicamo() As Boolean
        Dim ris As Boolean = False
        Return ris
    End Function

    Protected Sub rptPreventivazione_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptPreventivazione.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim gvTemp As GridView = CType(e.Item.FindControl("gvwListinoBase"), GridView)

            gvTemp.DataSource = e.Item.DataItem.GetListiniBase
            gvTemp.DataBind()

        End If
    End Sub

    Private _TabIndexMenu As Integer = 0
    Protected ReadOnly Property TabIndexMenu As Integer
        Get
            Return _TabIndexMenu
        End Get
    End Property

End Class