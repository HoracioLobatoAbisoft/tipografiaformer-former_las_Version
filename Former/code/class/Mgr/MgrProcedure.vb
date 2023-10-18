Imports System.IO
Imports FormerDALSql
Imports FormerLib

Public Class MgrProcedure

    Public Shared Sub CreaHtmlProcedura(P As Procedura)

        Dim Buffer As String = String.Empty
        Dim Path As String = FormerConfig.FormerPath.PathProcedure & P.IdProcedura & ".htm"

        Buffer &= "<html>"
        Buffer &= "<head>"
        Buffer &= "<link rel=""stylesheet"" type=""text/css"" href=""https://fonts.googleapis.com/css?family=Roboto"" media=""all"" />"
        Buffer &= "<style>"
        Buffer &= "body {font-family: 'Roboto'; background-color: #d6e03d;}"
        Buffer &= "table {background-color: white; margin-left:auto;margin-right:auto; padding:20px;max-width:1000px;}"
        Buffer &= ".trTitolo {padding:10px;background-color: #f58220; color:white;}"
        Buffer &= ".trStep {padding:10px;background-color: #f1f1f1; }"
        Buffer &= "td {padding:20px;text-align: justify;}"
        Buffer &= "</style>"
        Buffer &= "</head>"
        Buffer &= "<body>"
        Buffer &= "<table>"
        Buffer &= "<tr class='trTitolo'><td align=center valign=top colspan=3><h1>" & P.RiferitoA & "</h1></td></tr>"
        Buffer &= "<tr><td valign=top>"
        Buffer &= "<img src="""

        If P.Macchinario.IdMacchinario Then
            Buffer &= P.Macchinario.ImgRif
        End If

        Buffer &= """ border=0>&nbsp;"
        Buffer &= "<img src="""

        If P.Lavorazione.IdLavoro Then
            Buffer &= P.Lavorazione.ImgRif
        End If

        Buffer &= """ border=0>&nbsp;"
        Buffer &= "</td>"
        Buffer &= "<td valign=top colspan=2>"
        Buffer &= "<h1>" & P.Nome & "</h1>"
        Buffer &= "<h3>" & P.Descrizione.Replace(ControlChars.NewLine, "<br>") & "</h3>"
        Buffer &= "</td></tr>"

        For Each S As StepProcedura In P.ElencoStep
            Buffer &= "<tr class='trStep'><td valign=top align=center><h1>" & S.Ordine & "</h1></td>"
            Buffer &= "<td valign=top>"
            Buffer &= "<h3>" & S.Titolo & "</h3>"
            Buffer &= "<h5>" & S.Testo.Replace(ControlChars.NewLine, "<br>") & "</h5>"
            Buffer &= "</td>"
            Buffer &= "<td valign=top align=center>"
            If S.FilePath.Length Then
                Buffer &= "<a href=""" & S.FilePath & """><img src=""" & S.FilePath & """ width=100 border=0></a>"
            End If
            Buffer &= "</td>"
            Buffer &= "</tr>"
        Next

        Buffer &= "<tr><td colspan=3 valign=top align=left><h3>FILE ALLEGATI</h3><ul>"
        For Each F As FileAllegato In P.ElencoFileAllegati
            Buffer &= "<li><a href=""" & F.FilePath & """>" & F.FilePath & "</a></li>"
        Next
        Buffer &= "</ul></td>"
        Buffer &= "</tr>"
        Buffer &= "<tr><td colspan=3 align=center><img src=""https://www.tipografiaformer.it/img/logoPiccolo.png""></td></tr>"
        Buffer &= "</table>"
        Buffer &= "</body>"
        Buffer &= "</html>"

        Using w As New StreamWriter(Path)
            w.Write(Buffer)
        End Using

    End Sub

End Class
