Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class ucSlideProdotti
    Inherits FormerUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CaricaInEvidenza()
        End If

    End Sub

    Private Sub CaricaInEvidenza()

        Dim l As List(Of ListinoBaseW) = Nothing 'Application("ListaListiniBase")

        If FormerWebApp.UseStaticCollection = enSiNo.Si Then
            l = FormerWebApp.StaticListiniBase
        Else
            Using mgr As New ListinoBaseWDAO
                l = mgr.ListiniUtilizzabili
            End Using
        End If


        Dim lEvid As List(Of ListinoBaseW) = l.FindAll(Function(x) x.InEvidenza = enSiNo.Si)

        lEvid = FormerWebApp.Liste.Shuffle(lEvid)

        rptProd.DataSource = lEvid
        rptProd.DataBind()

    End Sub

End Class