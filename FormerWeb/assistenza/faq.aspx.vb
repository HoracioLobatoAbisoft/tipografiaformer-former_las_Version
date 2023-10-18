Imports FormerDALWeb
Public Class pFaq
    Inherits FormerFreePage

    'Protected Property TextToSearch As String = String.Empty

    Protected ReadOnly Property BufferGlossario As String
        Get
            Dim ris As String = ""

            If Cache("BufferGlossario") Is Nothing Then

                Dim lst As List(Of Glossario)
                Using Mgr As New GlossarioDAO
                    lst = Mgr.GetAll("Campo1")
                End Using
                For Each G As Glossario In lst
                    ris &= """" & StrConv(G.Campo1, VbStrConv.ProperCase) & ""","
                Next
                ris = ris.TrimEnd(",")


                Cache("BufferGlossario") = ris

            Else
                ris = Cache("BufferGlossario")
            End If

            Return ris
        End Get
    End Property

    Public Function VaiAGlossario() As Boolean
        Return _VaiAGlossario
    End Function

    Private _VaiAGlossario As Boolean = False

    Public Function VaiAFaq() As Boolean
        Return _VaiAFaq
    End Function

    Private _VaiAFaq As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Page.RouteData.DataTokens.Count Then
            If Page.RouteData.DataTokens("isGlossario") = True Then
                _VaiAGlossario = True
            ElseIf Page.RouteData.DataTokens("isFaq") = True Then
                _VaiAFaq = True
            End If
        End If

        Session("PageTitle") = "Assistenza Clienti"
       
        If Not IsPostBack Then

            CaricaArgomenti()

        End If

    End Sub

    Private Sub CaricaArgomenti()
        Dim Lst As List(Of Argomento)
        Using Arg As New ArgomentiDAO
            Lst = Arg.GetAll("Ordine")
        End Using


        rptArgomenti.DataSource = Lst
        rptArgomenti.DataBind()

    End Sub

    Protected Sub rptArgomenti_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptArgomenti.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim gvTemp As Repeater = CType(e.Item.FindControl("rptDomande"), Repeater)

            If Not gvTemp Is Nothing Then
                gvTemp.DataSource = e.Item.DataItem.GetTopN(100)
                gvTemp.DataBind()
            End If


        End If
    End Sub

    Private Sub Cerca(Optional Testo As String = "", Optional StartWith As String = "")

        Dim lst As List(Of Glossario) = Nothing

        Using G As New GlossarioDAO

            If Testo.Length Then
                lst = G.FindAll("Campo1", _
                                New LUNA.LunaSearchParameter("Campo1", "%" & Testo & "%", "LIKE"), _
                                New LUNA.LunaSearchParameter("Campo2", "%" & Testo & "%", "LIKE", LUNA.enLogicOperator.enOR))
            ElseIf StartWith.Length Then
                lst = G.FindAll("Campo1", _
                                New LUNA.LunaSearchParameter("Campo1", StartWith & "%", "LIKE"))
            End If

        End Using

        gridRis.DataSource = lst
        gridRis.DataBind()

    End Sub

    Private Sub lnkA_Click(sender As Object, e As EventArgs) Handles lnkA.Click, _
                                                                    lnkB.Click, _
                                                                    lnkC.Click, _
                                                                    lnkD.Click, _
                                                                    lnkE.Click, _
                                                                    lnkF.Click, _
                                                                    lnkG.Click, _
                                                                    lnkH.Click, _
                                                                    lnkI.Click, _
                                                                    lnkJ.Click, _
                                                                    lnkK.Click, _
                                                                    lnkL.Click, _
                                                                    lnkM.Click, _
                                                                    lnkN.Click, _
                                                                    lnkO.Click, _
                                                                    lnkP.Click, _
                                                                    lnkQ.Click, _
                                                                    lnkR.Click, _
                                                                    lnkS.Click, _
                                                                    lnkT.Click, _
                                                                    lnkU.Click, _
                                                                    lnkV.Click, _
                                                                    lnkW.Click, _
                                                                    lnkX.Click, _
                                                                    lnkY.Click, _
                                                                    lnkZ.Click


        Cerca("", sender.text)

    End Sub

    Private Sub lnkCerca_Click(sender As Object, e As EventArgs) Handles lnkCerca.Click

        Try

            If txtSearch.Text.Trim.Length > 2 Then

                'TextToSearch = txtSearch.Text
                Cerca(txtSearch.Text)

            End If

        Catch ex As Exception

        End Try
    End Sub
End Class