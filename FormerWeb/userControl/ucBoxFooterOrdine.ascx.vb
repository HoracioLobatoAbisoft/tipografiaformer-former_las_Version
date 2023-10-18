Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports FormerBusinessLogic

Public Class ucBoxFooterOrdine
    Inherits FormerUserControl

    Public Property Ordine As Consegna

    Private Sub DelOrd()
        'qui devo eliminare l'ordine e tutti i lavori contenuti dentro
        'se arrivo qui sicuramente non c'e' nessun pagamento
        Dim UrlRif As String = Request.Url.AbsolutePath
        If Ordine.Modificabile Then
            'qui elimino ordine e tutti i lavori contenuti 

            Ordine.IdStatoConsegna = enStatoConsegna.Eliminata
            Ordine.Save()
            For Each Lav As OrdineWeb In Ordine.ListaOrdini
                Lav.Stato = enStatoOrdine.Eliminato
                Lav.StatoWeb = enStato.NonAttivo
                Lav.Save()
            Next

        End If

        Response.Redirect(UrlRif)

    End Sub

    Private Sub lnkDelOrd_Click(sender As Object, e As EventArgs) Handles lnkDelOrd.Click
        DelOrd()
    End Sub

    Public Function GetTraceUrl() As String

        Dim Url As String = String.Empty

        Select Case Ordine.IdCorriere
            Case enCorriere.GLS, enCorriere.PortoAssegnatoGLS, enCorriere.GLSIsole
                Url = MgrTraceCorriere.GetUrlTraceGLS(Ordine.CodTrack)
                'in caso di GLS basta mettere il codtrack nell'url 
            Case enCorriere.Bartolini, enCorriere.PortoAssegnatoBartolini
                Url = MgrTraceCorriere.GetUrlTraceBartolini(Ordine.CodTrack)
        End Select

        Return Url

    End Function

End Class