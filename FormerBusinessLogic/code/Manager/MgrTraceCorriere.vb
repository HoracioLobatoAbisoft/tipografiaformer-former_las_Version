Imports System.IO
Imports System.Xml

Public Class MgrTraceCorriere

    'Private Shared UrlTraceGls As String = "http://www.gls-italy.com/tracktrace.asp?locpartenza=R2&numsped=@&tiporicerca=numsped"
    'Private Shared UrlTraceGls As String = "https://www.gls-italy.com/?option=com_gls&view=track_e_trace&mode=search&numero_spedizione=R2@&tipo_codice=nazionale"
    'Public Shared UrlTraceGlsXML As String = "https://www3.gls-italy.com/scripts/cgiip.exe/get_xml_track.p?locpartenza=R2&NumSped=@&CodCli=5708"

    Private Shared UrlTraceGls As String = "https://www.gls-italy.com/index.php?option=com_gls&view=track_e_trace&mode=search&diretto=yes&locpartenza=R2&numsped=@"
    Public Shared UrlTraceGlsXML As String = "https://wwwdr.gls-italy.com/XML/get_xml_track.php?locpartenza=R2&NumSped=@&CodCli=" & FormerConfig.FConfiguration.Gls.CodiceContratto
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

    Public Shared Function GetStatoConsegnaStrFromOnline(CodTrack As String) As String
        Dim ris As String = "Non Consegnato"

        Try
            Using W As New Net.WebClient

                Dim S As String
                Dim UrlTracking As String = MgrTraceCorriere.UrlTraceGlsXML.Replace("@", CodTrack)
                S = W.DownloadString(UrlTracking)

                Using wr As New StreamWriter(FormerConfig.FormerPath.PathTemp & "trackingsped.xml", False)
                    wr.Write(S)
                    wr.Close()
                End Using

                Dim StatoSped As String = String.Empty
                Using reader As XmlTextReader = New XmlTextReader(FormerConfig.FormerPath.PathTemp & "trackingsped.xml")
                    Do While reader.Read()
                        If reader.NodeType = XmlNodeType.Element Then
                            If reader.Name = "StatoSpedizione" Then
                                reader.Read()
                                StatoSped = reader.Value
                                If StatoSped.ToLower.Trim(" ") = "consegnato" Then
                                    ris = "Consegnato"
                                End If
                                Exit Do
                            End If
                        End If
                    Loop
                End Using

            End Using
        Catch ex As Exception
            'Throw ex
        End Try

        Return ris

    End Function

End Class
