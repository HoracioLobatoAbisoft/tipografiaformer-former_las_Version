Public Class frmWait

    Private Sub tmrProgress_Tick(sender As Object, e As EventArgs) Handles tmrProgress.Tick
        Try
            pShutDown.Value += 1
        Catch ex As Exception

        End Try


        Refresh()

    End Sub

End Class