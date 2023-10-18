Public Class MgrPDF

    Public Shared Sub StampaPDF(Path As String, Printer As String)

        Try
            Using p As New Spire.Pdf.PdfDocument
                p.LoadFromFile(Path)

                p.PrinterName = Printer
                p.PrintFromPage = 1
                p.PrintToPage = p.Pages.Count
                Using pdoc As Printing.PrintDocument = p.PrintDocument
                    pdoc.Print()
                End Using

                'Dim Img As Image = p.SaveAsImage(0)
                'Img.Save("C:\temp\gls.jpg")
                'Img.Dispose()
                p.Close()
            End Using

        Catch ex As Exception

        End Try

    End Sub
End Class
