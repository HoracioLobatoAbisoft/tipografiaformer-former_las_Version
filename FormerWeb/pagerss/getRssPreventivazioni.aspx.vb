Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class pGetRssPreventivazioni
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CaricaDati()

    End Sub

    Private Sub CaricaDati()

        Dim lstP As List(Of PreventivazioneW) = Nothing
        Using mgr As New PreventivazioniWDAO
            lstP = mgr.FindAll("IdReparto, Descrizione", New LUNA.LunaSearchParameter("DispOnline", enSiNo.Si))
        End Using

        rptPreventivazione.DataSource = lstP
        rptPreventivazione.DataBind()

    End Sub

    Public Function GetPubDate() As String
        '2014-12-29T11:51:27Z
        Dim ris As String = String.Empty

        ris = Now.Year & "-" & Now.Month & "-" & Now.Day & "T" & Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & ":00Z"

        Return ris

    End Function

End Class