Imports FormerDALWeb


Public Class parametri
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            FormerWebApp.LogMe("Accesso alla pagina PARAMETRI", UtenteConnesso)

            Using mgr As New ListiniUtenteWDAO

                Dim l As List(Of ListinoUtenteW) = mgr.FindAll(New LUNA.LunaSearchParameter("IdUt", UtenteConnesso.IdUtente))

                If l.Count Then
                    txtPerc.Text = l(0).PercDefault
                Else
                    txtPerc.Text = FormerWebApp.PercDefaultRicarico
                End If

            End Using

        End If

    End Sub

    Public Function PercentualeMinimaRicarico() As Integer
        Dim ris As Integer = FormerWebApp.PercMinimaRicarico

        Return ris
    End Function

    Private Sub btnSalva_Click(sender As Object, e As EventArgs) Handles btnSalva.Click

        Try
            Dim NewPerc As Integer = 0
            If IsNumeric(txtPerc.Text) Then
                NewPerc = txtPerc.Text
                If NewPerc >= PercentualeMinimaRicarico() Then
                    Using mgr As New ListiniUtenteWDAO

                        Dim l As List(Of ListinoUtenteW) = mgr.FindAll(New LUNA.LunaSearchParameter("IdUt", UtenteConnesso.IdUtente))

                        If l.Count Then
                            Using listUt As ListinoUtenteW = l(0)
                                listUt.PercDefault = NewPerc
                                listUt.Save()
                            End Using
                            FormerWebApp.LogMe("Salvata percentuale di ricarico: " & NewPerc, UtenteConnesso)

                            Response.Redirect("/genera-listino")
                        End If

                    End Using
                Else
                    txtPerc.Text = PercentualeMinimaRicarico()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

End Class