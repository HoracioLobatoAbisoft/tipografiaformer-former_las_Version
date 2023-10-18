Public Class MgrTraceCorriere

    'Private Shared UrlTraceGls As String = "http://www.gls-italy.com/tracktrace.asp?locpartenza=R2&numsped=@&tiporicerca=numsped"
    Private Shared UrlTraceGls As String = "https://www.gls-italy.com/?option=com_gls&view=track_e_trace&mode=search&numero_spedizione=R2@&tipo_codice=nazionale"

    Private Shared UrlTraceBartolini As String = "http://as777.brt.it/vas/sped_det_show.hsm?referer=sped_numspe_par.htm&ChiSono=@"

    Public Shared Function GetUrlTraceGLS(CodTrack As String) As String
        Dim ris As String = UrlTraceGls

        ris = ris.Replace("@", CodTrack)

        Return ris
    End Function

    Public Shared Function GetUrlTraceBartolini(CodTrack As String) As String
        Dim ris As String = UrlTraceGls

        If CodTrack.Length > 15 Then
            CodTrack = CodTrack.Substring(0, 15)
        End If

        ris = ris.Replace("@", CodTrack)

        Return ris
    End Function

End Class
