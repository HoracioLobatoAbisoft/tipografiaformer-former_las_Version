Imports FormerDALSql
Public Class ucAnteprima
    Inherits ucFormerUserControl

    Private _PathStampa As String = ""

    Public Sub Carica(ByVal Path As String)

        WebPrint.Navigate("about:blank")

        _PathStampa = Path

        WebPrint.Navigate(Path)

    End Sub

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        If _PathStampa.Length Then


            ParentFormEx.Sottofondo()

            Dim x As New frmStampa

            x.carica(_PathStampa)

            ParentFormEx.Sottofondo()

        End If

    End Sub
End Class
