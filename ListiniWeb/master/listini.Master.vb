Imports FormerDALWeb

Public Class listini
    Inherits FormerMasterPage

    Public Function getNominativoUtente() As String

        Dim ris As String = String.Empty

        ris = Server.HtmlEncode(UtenteConnesso.Nominativo)

        If ris.Length > 25 Then
            ris = ris.Substring(0, 25) & "..."
        End If

        Return ris

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'UtenteConnesso = New UtenteSito

    End Sub

    Protected Sub lnkEsci_Click(sender As Object, e As EventArgs) Handles lnkEsci.Click
        DirectCast(Page, FormerPage).TerminaSessioneLavoro()
    End Sub

End Class