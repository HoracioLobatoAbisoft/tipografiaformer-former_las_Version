Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks

Public Class WeTransferDownloader

    Public Shared Sub Download()

        'Dim DOWNLOAD_URL_PARAMS_PREFIX As String = "downloads/"

        'Dim CHUNK_SIZE As Integer = 1024

        'Dim Link As String = String.Empty

        'Dim Client As New HttpClient

        'Dim Response As HttpResponseMessage = Client.GetAsync(Link).Result

        'Response.EnsureSuccessStatusCode()

        'Dim responseUri As String = Response.RequestMessage.RequestUri.ToString()

        'Dim fileID As String = ""
        'Dim recipientID As String = ""
        'Dim securityHash As String = ""

        'Dim splittedLink As String() = responseUri.Split(New String() {DOWNLOAD_URL_PARAMS_PREFIX}, StringSplitOptions.RemoveEmptyEntries)

        'If splittedLink.Length > 1 Then

        '    Dim parameters As String() = splittedLink(1).Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        '    If parameters.Length < 2 Or parameters.Length > 3 Then

        '        If parameters.Length = 2 Then
        '            fileID = parameters(0)
        '            securityHash = parameters(1)

        '        Else
        '            fileID = parameters(0)
        '            recipientID = parameters(1)
        '            securityHash = parameters(2)

        '        End If


        '    End If

        'End If

        'Dim directDownloadLink As String = ""
        'Dim wc As New WebClient
        'Dim jsonstring As String = wc.DownloadString(String.Format("https://www.wetransfer.com/api/v1/transfers/{0}/download?recipient_id={1}&security_hash={2}&password=&ie=false", fileID, recipientID, securityHash))

        'Dim stringData = JsonConvert.DeserializeObject(jsonstring)


        'Byte[] data = null;

        '    String fileName


    End Sub

End Class
