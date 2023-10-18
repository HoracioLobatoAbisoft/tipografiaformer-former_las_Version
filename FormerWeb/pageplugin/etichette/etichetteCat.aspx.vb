Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum

Imports FormerBusinessLogicInterface
Public Class pEtichetteCat
    Inherits FormerPluginPage

    Private _IdP As Integer = 0

    Public P As PreventivazioneW

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("PageTitle") = "Scegli il tipo di etichetta"

        _idP = Convert.ToInt32(Page.RouteData.Values("idp"))

        P = New PreventivazioneW
        P.Read(_IdP)

        If P.DispOnline = False Then
            Response.Redirect("/")
        ElseIf MgrPlugin.GetIdPluginToUse(P) <> enPluginOnline.Etichette Then
            Response.Redirect("/")
        Else
            CaricaCat()
        End If

    End Sub

    Private Sub CaricaCat()

        Dim lst As List(Of CatFustellaW) = Nothing
        Using mgr As New CatFustelleWDAO
            lst = mgr.GetCatWithFustelle(_IdP)
        End Using

        Dim R As New TableRow
        For Each catfust As CatFustellaW In lst
            If R.Cells.Count = 4 Then
                tableWizard.Rows.Add(R)
                R = New TableRow
            End If
            Dim C As New TableCell
            Dim Pt As New My.Templates.CatFustella
            Pt.IdPreventivazione = _IdP
            Pt.C = catfust
            C.Text = Pt.TransformText
            R.Cells.Add(C)
        Next

        If R.Cells.Count Then
            tableWizard.Rows.Add(R)
        End If

    End Sub

End Class