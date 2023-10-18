Imports System.IO
Imports FormerDALSql
Imports FormerIO
Imports FormerLib

Friend Class frmCommessaDigitalePannelli
    'Inherits baseFormInternaFixed

    Private _Ris As Integer = 0
    Private _IdCom As Integer = 0

    Friend Function Carica(IdCom As Integer) As Integer

        _IdCom = IdCom

        Using c As New Commessa

            c.Read(IdCom)
            Dim l As New List(Of FileSorgente)
            For Each O As Ordine In c.ListaOrdini

                For Each S As FileSorgente In O.ListaSorgenti
                    l.Add(S)
                Next
            Next
            dgSorgenti.AutoGenerateColumns = False
            dgSorgenti.DataSource = l
        End Using

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChiudi.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub btnGeneraPDF_Click(sender As Object, e As EventArgs) Handles btnGeneraPDF.Click

        If dgSorgenti.SelectedRows.Count = 0 Then
            MessageBox.Show("Selezionare un file sorgente dalla lista")
        Else
            If MessageBox.Show("Confermi la generazione dei pannelli?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                GeneraPannelli()

            End If

        End If

    End Sub


    Private Sub Pannelli(SourcePdfFilePath As String,
                         DestinationPdfFilePath As String,
                         LarghezzaRotoloMM As Single,
                         AltezzaTotaleMM As Single,
                         NPannelli As Integer,
                         SormontoMM As Single,
                         Optional LarghezzaCrocini As Integer = 10,
                         Optional DimensioneFont As Integer = 54,
                         Optional StampaNumeriPagina As Boolean = True)

        'Dim SourcePdfFilePath As String = "D:\temp\digitale\source.pdf"
        'Dim DestinationPdfFilePath As String = "D:\temp\digitale\destination$.pdf"
        Dim PageNumber As Integer = 1

        'Dim dimensioni As Size = FormerHelper.PDF.GetDimensioniPagina("D:\temp\digitale\1_B.pdf")

        Using reader As iTextSharp.text.pdf.PdfReader = New iTextSharp.text.pdf.PdfReader(SourcePdfFilePath)
            Dim Larghezza As Single = FormerHelper.PDF.TrasformaMmInPoint(LarghezzaRotoloMM)
            Dim Altezza As Single = FormerHelper.PDF.TrasformaMmInPoint(AltezzaTotaleMM)
            Dim DimensioniDocumento As New iTextSharp.text.Rectangle(Larghezza, Altezza)

            Dim shift As Single = 0 '-28

            For i = 1 To NPannelli
                Dim doc As New iTextSharp.text.Document(DimensioniDocumento, 0, 0, 0, 0)

                Using writer As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc,
                                                                                               New FileStream(DestinationPdfFilePath.Replace(".$.pdf", "." & i & ".pdf"), FileMode.Create))

                    doc.Open()
                    'doc.Add(New text.Paragraph(""))
                    Dim cb As iTextSharp.text.pdf.PdfContentByte = writer.DirectContent
                    Dim page As iTextSharp.text.pdf.PdfImportedPage = writer.GetImportedPage(reader, 1)
                    Dim Scale As New iTextSharp.awt.geom.AffineTransform
                    cb.AddTemplate(page, (shift), 0, False)

                    'StampaNumeriPagina = False

                    If StampaNumeriPagina Then
                        cb.BeginText()
                        Dim f_cn As iTextSharp.text.pdf.BaseFont = iTextSharp.text.pdf.BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED)
                        cb.SetFontAndSize(f_cn, DimensioneFont)
                        cb.SetTextMatrix(5, 10)
                        cb.ShowText(i)
                        cb.EndText()
                    End If

                    If i > 1 Then
                        cb.SetLineWidth(0.5) '; // Make a bit thicker than 1.0 Default
                        cb.SetColorStroke(iTextSharp.text.BaseColor.GRAY)
                        cb.SetLineDash(15, 15, 100)
                        cb.MoveTo(FormerHelper.PDF.TrasformaMmInPoint(SormontoMM), 0)
                        cb.LineTo(FormerHelper.PDF.TrasformaMmInPoint(SormontoMM), Altezza)
                        cb.Stroke()
                    End If

                    cb.SetLineWidth(0.5) '; // Make a bit thicker than 1.0 Default
                    cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK)
                    cb.SetLineDash(1)

                    'basso SX
                    cb.MoveTo(0, 0)
                    cb.LineTo(FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini), 0)
                    cb.Stroke()

                    cb.MoveTo(0, 0)
                    cb.LineTo(0, FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini))
                    cb.Stroke()

                    'alto sx
                    cb.MoveTo(0, Altezza)
                    cb.LineTo(0, Altezza - FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini))
                    cb.Stroke()

                    cb.MoveTo(0, Altezza)
                    cb.LineTo(FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini), Altezza)
                    cb.Stroke()

                    'alto dx
                    cb.MoveTo(Larghezza, Altezza)
                    cb.LineTo(Larghezza, Altezza - FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini))
                    cb.Stroke()

                    cb.MoveTo(Larghezza, Altezza)
                    cb.LineTo(Larghezza - FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini), Altezza)
                    cb.Stroke()

                    'basso dx
                    cb.MoveTo(Larghezza, 0)
                    cb.LineTo(Larghezza - FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini), 0)
                    cb.Stroke()

                    cb.MoveTo(Larghezza, 0)
                    cb.LineTo(Larghezza, FormerHelper.PDF.TrasformaMmInPoint(LarghezzaCrocini))
                    cb.Stroke()

                    doc.Close()
                End Using
                shift -= Larghezza - FormerHelper.PDF.TrasformaMmInPoint(SormontoMM)
            Next

        End Using

    End Sub

    Private Function ResizePdf(PathSource As String,
                          LarghezzaMM As Single,
                          AltezzaMM As Single,
                          PathDestination As String) As Integer

        Dim Ris As Integer = 0

        Using reader As New iTextSharp.text.pdf.PdfReader(PathSource)
            Dim Larghezza As Single = FormerHelper.PDF.TrasformaMmInPoint(LarghezzaMM)
            Dim Altezza As Single = FormerHelper.PDF.TrasformaMmInPoint(AltezzaMM)

            If Larghezza > 14400 Or Altezza > 14400 Then
                Larghezza /= 2
                Altezza /= 2
                Ris = 1
            End If

            Dim DimensioniDocumento As New iTextSharp.text.Rectangle(Larghezza, Altezza)

            Using doc As New iTextSharp.text.Document(DimensioniDocumento, 0, 0, 0, 0)

                Dim writer As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc,
                                                                                         New FileStream(PathDestination, FileMode.Create))
                doc.Open()
                Dim cb As iTextSharp.text.pdf.PdfContentByte = writer.DirectContent

                Dim page As iTextSharp.text.pdf.PdfImportedPage = writer.GetImportedPage(reader, 1)

                Dim widthFactor As Single = doc.PageSize.Width / page.Width
                Dim heightFactor As Single = doc.PageSize.Height / page.Height
                Dim factor As Single = Math.Min(widthFactor, heightFactor)

                Dim offsetX As Single = (doc.PageSize.Width - (page.Width * factor)) / 2
                Dim offsetY As Single = (doc.PageSize.Height - (page.Height * factor)) / 2
                cb.AddTemplate(page, factor, 0, 0, factor, offsetX, offsetY)

                doc.Close()
            End Using
        End Using
        Return Ris

    End Function

    Private Sub GeneraPannelli()

        Dim F As FileSorgente = dgSorgenti.SelectedRows(0).DataBoundItem

        Dim OkCheckExternalLevel As Boolean = True

        Dim DocumentWithExternalLevel As Boolean = FormerLib.FormerHelper.PDF.DocumentWithExternalLevel(F.FilePath)

        If DocumentWithExternalLevel Then
            If MessageBox.Show("Il documento selezionato sembra avere livelli di taglio differenti dalla grandezza del documento. Si vuole continuare comunque?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                OkCheckExternalLevel = False
            End If
        End If

        If OkCheckExternalLevel Then
            Dim AltezzaTotale As Single = txtAltezzaTotale.Text
            Dim AltezzaPannello As Single = AltezzaTotale
            Dim LarghezzaTotale As Single = txtLarghezzaTotale.Text
            Dim NPannelli As Integer = txtNPannelli.Text
            Dim Sormonto As Single = txtSormonto.Text
            Dim Crocini As Single = 10
            Dim DimensioneFont As Integer = 54

            Dim LarghezzaPannello As Single = (LarghezzaTotale + ((NPannelli - 1) * Sormonto)) / NPannelli

            If LarghezzaPannello < (CInt(txtLarghezzaRotolo.Text) - 10) Then
                Cursor.Current = Cursors.WaitCursor
                Try

                    Dim PathDest As String = FormerConfig.FormerPath.PathFileDigitale & _IdCom & "\"
                    FormerHelper.File.CreateLongPath(PathDest)

                    Dim PathSource As String = PathDest & FormerHelper.File.EstraiNomeFile(F.FilePath).ToLower

                    Dim ris As Integer = ResizePdf(F.FilePath, LarghezzaTotale, AltezzaTotale, PathSource)

                    If ris Then
                        Sormonto /= 2
                        AltezzaPannello /= 2
                        LarghezzaPannello /= 2
                        Crocini /= 2
                        DimensioneFont /= 2
                    End If

                    Pannelli(PathSource,
                             PathSource.Replace(".pdf", ".$.pdf"),
                             LarghezzaPannello,
                             AltezzaPannello,
                             NPannelli,
                             Sormonto,
                             Crocini,
                             DimensioneFont,
                             chkStampaNumPag.Checked)

                    If ris Then
                        'qui devo duplicare i pannelli 
                        LarghezzaPannello *= 2
                        For i As Integer = 1 To NPannelli
                            Dim FileDest As String = PathSource.Replace(".pdf", ".$.pdf")
                            ResizePdf(FileDest.Replace(".$.pdf", "." & i & ".pdf"), LarghezzaPannello, AltezzaTotale, FileDest.Replace(".$.pdf", "_R." & i & ".pdf"))

                            Threading.Thread.Sleep(1000)
                            Application.DoEvents()
                        Next

                        For i As Integer = 1 To NPannelli
                            Dim FileDest As String = PathSource.Replace(".pdf", "." & i & ".pdf")

                            Try
                                MgrFormerIO.FileDelete(FileDest)
                            Catch ex As Exception

                            End Try

                        Next

                    End If

                    FormerLib.FormerHelper.File.ShellExtended(PathDest)

                Catch ex As Exception
                    ManageError(ex)
                End Try
                Cursor.Current = Cursors.Default
            Else

                MessageBox.Show("In base alle misure inserite i pannelli risultano troppo grandi")

            End If
        End If

    End Sub

    Private Sub lnkOpenFileSorg_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOpenFileSorg.LinkClicked

        If dgSorgenti.SelectedRows.Count Then

            Dim FileSel As FileSorgente

            FileSel = dgSorgenti.SelectedRows(0).DataBoundItem

            Try

                Dim PathMod As String = FileSel.FilePath

                Dim x As New Process

                x.StartInfo.FileName = PathMod
                x.Start()

            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If
    End Sub

    Private Sub btnFolder_Click(sender As Object, e As EventArgs) Handles btnFolder.Click

        Dim PathDest As String = FormerConfig.FormerPath.PathFileDigitale & _IdCom & "\"

        If File.Exists(PathDest) Then
            FormerHelper.File.ShellExtended(PathDest)
        Else
            MessageBox.Show("I pannelli non sono stati creati")
        End If

    End Sub

End Class
