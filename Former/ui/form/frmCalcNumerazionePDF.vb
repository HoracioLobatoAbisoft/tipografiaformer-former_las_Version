Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Friend Class frmCalcNumerazionePDF
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _NumeroIniziale As Integer = 0
    Private _NumeroBlocchi As Integer = 0
    Private _NumeroFogliBlocco As Integer = 0
    Private _FogliScelti As Integer = 0
    Private _NumeroPosizioni As Integer = 0
    Private _GeneraBarCode As Boolean = False
    Private _ParteFissa As String = String.Empty

    Friend Function Carica(NumeroIniziale As Integer,
                           NumeroBlocchi As Integer,
                           NumeroFogliBlocco As Integer,
                           FogliScelti As Integer,
                           NumeroPosizioni As Integer,
                           Optional GeneraBarCode As Boolean = False,
                           Optional ParteFissa As String = "") As Integer

        _NumeroIniziale = NumeroIniziale
        _NumeroBlocchi = NumeroBlocchi
        _NumeroFogliBlocco = NumeroFogliBlocco
        _FogliScelti = FogliScelti
        _NumeroPosizioni = NumeroPosizioni
        _GeneraBarCode = GeneraBarCode
        _ParteFissa = ParteFissa

        Dim objFontCollection As System.Drawing.Text.FontCollection
        objFontCollection = New System.Drawing.Text.InstalledFontCollection()
        For Each objFontFamily In objFontCollection.Families
            cmbFont.Items.Add(objFontFamily.Name)
            cmbFontD.Items.Add(objFontFamily.Name)
            cmbFontD2.Items.Add(objFontFamily.Name)
        Next

        Dim DirF As New DirectoryInfo(Environment.GetEnvironmentVariable("SystemRoot") & "\fonts\")

        For Each f As FileInfo In DirF.GetFiles("*.ttf")
            FontFactory.Register(f.FullName)
        Next

        If _GeneraBarCode Then
            'Code EAN13
            MgrControl.SelectIndexCombo(cmbFont, "Code EAN13")
            MgrControl.SelectIndexCombo(cmbFontD, "Code EAN13")
            MgrControl.SelectIndexCombo(cmbFontD2, "Code EAN13")
            cmbFont.Enabled = False
            cmbFontD.Enabled = False
            cmbFontD2.Enabled = False
        Else
            MgrControl.SelectIndexCombo(cmbFont, "Segoe UI")
            MgrControl.SelectIndexCombo(cmbFontD, "Segoe UI")
            MgrControl.SelectIndexCombo(cmbFontD2, "Segoe UI")
        End If

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

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub GeneraPdf(ArrayEtichettaCsv As List(Of String))

        Dim NumeroRighe As Integer = 1
        Dim NumeroColonne As Integer = 1

        NumeroRighe = txtNumRighe.Text
        NumeroColonne = txtNumColonne.Text

        Dim NumeroIniziale As Integer = _NumeroIniziale
        Dim NumeroPosizioni As Integer = _NumeroPosizioni
        Dim NumeroFinale As Integer = ((_NumeroBlocchi * _NumeroFogliBlocco) * NumeroPosizioni) + NumeroIniziale - 1

        Dim NumeroCifre As Integer = NumeroFinale.ToString.Length

        Dim FogliScelti As Integer = _FogliScelti

        Dim ListaSerie As New List(Of List(Of Integer))
        Dim NumeroAttuale As Integer = NumeroIniziale

        For j = 1 To NumeroPosizioni
            Dim NumeroFinaleSerie As Integer = NumeroAttuale + FogliScelti
            Dim Serie As New List(Of Integer)
            For I = NumeroAttuale To NumeroFinaleSerie
                Serie.Add(I)
            Next
            ListaSerie.Add(Serie)
            NumeroAttuale = NumeroFinaleSerie
        Next

        Dim ValoreIniziale As Integer = 0
        Dim ValoreFinale As Integer = 0
        Dim StepFor As Integer = 1

        Dim Reverse As Boolean = chkInverso.Checked

        If Reverse = False Then
            ValoreIniziale = 0
            ValoreFinale = FogliScelti - 1
            StepFor = 1
        Else
            ValoreIniziale = FogliScelti - 1
            ValoreFinale = 0
            StepFor = -1
        End If

        Dim Finali As New List(Of String)
        For I As Integer = ValoreIniziale To ValoreFinale Step StepFor
            For Each Lista As List(Of Integer) In ListaSerie
                Dim Valore As String = String.Empty

                If chkCompletaZeri.Checked Then
                    Valore = FormerLib.FormerHelper.Stringhe.FormattaConZeri(Lista(I), NumeroCifre) ' - 1)
                Else
                    Valore = Lista(I) ' - 1)
                End If

                Finali.Add(Valore)
            Next
        Next

        Dim PathRis As String = String.Empty
        Dim PathFile As String = String.Empty
        Dim Fold As String = String.Empty
        If rdoMultiFile.Checked Then

            Dim Rnd As New Random()

            Fold = FormerConfig.FormerPath.PathTempLocale & Rnd.Next(10000, 99999) & "\"
            FormerLib.FormerHelper.File.CreateLongPath(Fold)

            PathFile = Fold & FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf")
        Else
            PathFile = FormerConfig.FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".pdf")
        End If


        Dim Larghezza As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtLarghezza.Text)
        Dim Altezza As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtAltezza.Text)

        Dim LarghezzaLabel As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtLarghezzaEtichetta.Text)
        Dim AltezzaLabel As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtAltezzaEtichetta.Text)
        Dim rectPage As iTextSharp.text.Rectangle = New iTextSharp.text.Rectangle(Larghezza, Altezza)

        Dim FontCont As Font = FontFactory.GetFont(cmbFont.Text, CSng(txtGrandezzaFont.Text))
        Dim FontContD As Font = FontFactory.GetFont(cmbFontD.Text, CSng(txtGrandezzaFontD.Text))
        Dim FontContD2 As Font = FontFactory.GetFont(cmbFontD2.Text, CSng(txtGrandezzaFontD2.Text))

        Dim PathSfondo As String = txtSfondo.Text
        Dim Reader As PdfReader = Nothing

        If chkPDFSfondo.Checked AndAlso PathSfondo.Length Then
            Reader = New PdfReader(PathSfondo)
        End If

        Dim Contatore As Integer = 0
        Dim document As Document = Nothing
        Dim writer As PdfWriter = Nothing
        Dim ContPagine As Integer = 0

        For x As Integer = 1 To FogliScelti

            If document Is Nothing Then
                Dim PathSingFile As String = PathFile
                If rdoMultiFile.Checked Then
                    PathSingFile = PathSingFile.Replace(".pdf", "." & Finali(Contatore) & ".pdf")
                End If
                document = New Document(rectPage, 0, 0, 0, 0)
                writer = PdfWriter.GetInstance(document, New FileStream(PathSingFile, FileMode.Create))
                document.Open()
                ContPagine = 1
            End If

            ' Text
            Dim cb As PdfContentByte = writer.DirectContent

            If Not Reader Is Nothing Then
                Dim page As PdfImportedPage = writer.GetImportedPage(Reader, 1)
                cb.AddTemplate(page, 0, 0)
            End If

            Dim BassoSinistraNumPagX As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtNumPagX.Text)
            Dim BassoSinistraNumPagY As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtNumPagY.Text)

            Dim BassoSinistraX As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtBassoX.Text)
            Dim BassoSinistraY As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtBassoY.Text)

            Dim BassoSinistraXD As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtBassoXD.Text)
            Dim BassoSinistraYD As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtBassoYD.Text)

            Dim BassoSinistraXD2 As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtBassoXD2.Text)
            Dim BassoSinistraYD2 As Single = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtBassoYD2.Text)

            Dim AltoDestraX As Single = BassoSinistraX + LarghezzaLabel
            Dim AltoDestraY As Single = BassoSinistraY - AltezzaLabel

            Dim AltoDestraXD As Single = BassoSinistraXD + LarghezzaLabel
            Dim AltoDestraYD As Single = BassoSinistraYD - AltezzaLabel

            Dim AltoDestraXD2 As Single = BassoSinistraXD2 + LarghezzaLabel
            Dim AltoDestraYD2 As Single = BassoSinistraYD2 - AltezzaLabel

            For J As Integer = 1 To NumeroColonne
                BassoSinistraY = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtBassoY.Text)
                AltoDestraY = BassoSinistraY - AltezzaLabel

                BassoSinistraYD = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtBassoYD.Text)
                AltoDestraYD = BassoSinistraYD - AltezzaLabel

                BassoSinistraYD2 = FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtBassoYD2.Text)
                AltoDestraYD2 = BassoSinistraYD2 - AltezzaLabel

                For I As Integer = 1 To NumeroRighe
                    Dim ValToPrint As String = ""
                    Dim SpaziRestanti As Integer = 0
                    SpaziRestanti = 12 - _ParteFissa.Length
                    Dim ValEan As String = _ParteFissa & FormerLib.FormerHelper.Stringhe.FormattaConZeri(Finali(Contatore), SpaziRestanti)

                    If _GeneraBarCode Then
                        ValToPrint = FormerLib.FormerHelper.EAN13.ToEAN13(ValEan)
                    Else
                        If ArrayEtichettaCsv Is Nothing Then
                            ValToPrint = txtPrefisso.Text & Finali(Contatore) & txtSuffisso.Text
                        Else
                            Dim Indice As Integer = Finali(Contatore)
                            ValToPrint = String.Empty
                            If Indice < ArrayEtichettaCsv.Count Then
                                ValToPrint = ArrayEtichettaCsv(Indice)
                            End If
                        End If
                    End If

                    If chkRuota.Checked Then
                        cb.SetFontAndSize(FontCont.BaseFont, FontCont.Size)
                        cb.BeginText()
                        cb.ShowTextAligned(Element.ALIGN_RIGHT, ValToPrint, BassoSinistraX, BassoSinistraY, lblOrient.Text)
                        cb.EndText()
                        cb.Stroke()
                    Else
                        Dim ct As New ColumnText(cb)
                        Dim pToIns As New Phrase(New Chunk(ValToPrint, FontCont))
                        ct.SetSimpleColumn(pToIns,
                                               BassoSinistraX,
                                               BassoSinistraY,
                                               AltoDestraX,
                                               AltoDestraY,
                                               0,
                                               Element.ALIGN_RIGHT Or Element.ALIGN_TOP)

                        ct.Go()
                    End If

                    If chkInserisciDuplicato.Checked Then

                        If _GeneraBarCode Then
                            ValToPrint = FormerLib.FormerHelper.EAN13.ToEAN13(ValEan)
                        Else
                            If ArrayEtichettaCsv Is Nothing Then
                                ValToPrint = txtPrefissoD.Text & Finali(Contatore) & txtSuffissoD.Text
                            Else
                                Dim Indice As Integer = Finali(Contatore)
                                ValToPrint = String.Empty
                                If Indice <= ArrayEtichettaCsv.Count Then
                                    ValToPrint = ArrayEtichettaCsv(Indice)
                                End If
                            End If
                        End If

                        If chkRuota1.Checked Then
                            cb.SetFontAndSize(FontContD.BaseFont, FontContD.Size)
                            cb.BeginText()
                            cb.ShowTextAligned(Element.ALIGN_RIGHT, ValToPrint, BassoSinistraXD, BassoSinistraYD, lblOrient1.Text)
                            cb.EndText()
                            cb.Stroke()
                        Else
                            Dim ct As New ColumnText(cb)
                            ct.SetSimpleColumn(New Phrase(ValToPrint, FontContD),
                                                BassoSinistraXD,
                                                BassoSinistraYD,
                                                AltoDestraXD,
                                                AltoDestraYD,
                                                0,
                                                Element.ALIGN_RIGHT Or Element.ALIGN_TOP)
                            ct.Go()
                        End If


                    End If

                    If chkInserisciDuplicato2.Checked Then

                        If _GeneraBarCode Then
                            ValToPrint = FormerLib.FormerHelper.EAN13.ToEAN13(ValEan)
                        Else
                            If ArrayEtichettaCsv Is Nothing Then
                                ValToPrint = txtPrefissoD2.Text & Finali(Contatore) & txtSuffissoD2.Text
                            Else
                                Dim Indice As Integer = Finali(Contatore)
                                ValToPrint = String.Empty
                                If Indice <= ArrayEtichettaCsv.Count Then
                                    ValToPrint = ArrayEtichettaCsv(Indice)
                                End If
                            End If
                        End If

                        If chkRuota2.Checked Then
                            cb.SetFontAndSize(FontContD2.BaseFont, FontContD2.Size)
                            cb.BeginText()
                            cb.ShowTextAligned(Element.ALIGN_RIGHT, ValToPrint, BassoSinistraXD2, BassoSinistraYD2, lblOrient2.Text)
                            cb.EndText()
                            cb.Stroke()
                        Else
                            Dim ct As New ColumnText(cb)
                            ct.SetSimpleColumn(New Phrase(ValToPrint, FontContD2),
                                                BassoSinistraXD2,
                                                BassoSinistraYD2,
                                                AltoDestraXD2,
                                                AltoDestraYD2,
                                                0,
                                                Element.ALIGN_RIGHT Or Element.ALIGN_TOP)
                            ct.Go()
                        End If

                    End If

                    BassoSinistraYD += FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtPassoYD.Text)
                    AltoDestraYD = BassoSinistraYD - AltezzaLabel

                    BassoSinistraYD2 += FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtPassoYD2.Text)
                    AltoDestraYD2 = BassoSinistraYD2 - AltezzaLabel

                    BassoSinistraY += FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtPassoY.Text)
                    AltoDestraY = BassoSinistraY - AltezzaLabel
                    Contatore += 1
                Next
                BassoSinistraX += FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtPassoX.Text)
                AltoDestraX = BassoSinistraX + LarghezzaLabel

                BassoSinistraXD += FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtPassoXD.Text)
                AltoDestraXD = BassoSinistraXD + LarghezzaLabel

                BassoSinistraXD2 += FormerLib.FormerHelper.PDF.TrasformaMmInPoint(txtPassoXD2.Text)
                AltoDestraXD2 = BassoSinistraXD2 + LarghezzaLabel

            Next

            If chkNumPagina.Checked Then

                Dim ct As New ColumnText(cb)
                Dim pToIns As New Phrase(New Chunk(ContPagine, FontCont))
                ct.SetSimpleColumn(pToIns,
                                       BassoSinistraNumPagX,
                                       BassoSinistraNumPagY,
                                       60,
                                       20,
                                       0,
                                       Element.ALIGN_RIGHT Or Element.ALIGN_BOTTOM)

                ct.Go()

            End If

            ContPagine += 1

            If chkOnlyFront.Checked Then
                document.NewPage()
            End If

            If rdoMultiFile.Checked Then

                If ContPagine < txtMaxPageFile.Text Then
                    document.NewPage()
                Else
                    document.Close()
                    writer.Close()
                    document = Nothing
                    writer = Nothing
                End If

            Else
                document.NewPage()
            End If

        Next

        If Not document Is Nothing Then document.Close()

        If Not Reader Is Nothing Then
            Reader.Close()
            Reader.Dispose()
            Reader = Nothing
        End If
        'End Using

        If rdoSingFile.Checked Then
            PathRis = PathFile
        Else
            PathRis = Fold
        End If

        FormerLib.FormerHelper.File.ShellExtended(PathRis)

    End Sub

    Private Sub btnGeneraPDF_Click(sender As Object, e As EventArgs) Handles btnGeneraPDF.Click

        Dim CheckRigheColonne As Boolean = True

        If (CInt(txtNumColonne.Text) * CInt(txtNumRighe.Text)) <> _NumeroPosizioni Then
            CheckRigheColonne = False
        End If

        Dim ArrayEtichetteCSV As List(Of String) = Nothing
        Dim CheckRigheCSV As Boolean = True
        Dim NumeroFinale As Integer = ((_NumeroBlocchi * _NumeroFogliBlocco) * _NumeroPosizioni) + _NumeroIniziale - 1
        If chkCSVEtichette.Checked AndAlso txtCSV.Text.Length <> 0 Then
            ArrayEtichetteCSV = New List(Of String)
            Dim RigheTrovate As Integer = 0
            Using r As New StreamReader(txtCSV.Text)
                While r.EndOfStream = False
                    If RigheTrovate <> 0 Then
                        ArrayEtichetteCSV.Add(r.ReadLine)
                    End If
                    RigheTrovate += 1
                    'r.ReadLine()
                End While
            End Using

            Dim DieciPerCento As Integer = ArrayEtichetteCSV.Count * 10 / 100
            Dim differenza As Integer = ArrayEtichetteCSV.Count - NumeroFinale

            If Math.Abs(differenza) > DieciPerCento Then
                'calcolo inpercentuale quanto e' la differenza tra i due 
                CheckRigheCSV = True
            End If
        Else
            CheckRigheCSV = False
        End If

        Dim GoOn As Boolean = True

        If CheckRigheColonne = False Then
            MessageBox.Show("Il numero di colonne e righe inserito non è compatibile con il numero di spazi inserito")
            GoOn = False
        Else
            If chkCSVEtichette.Checked = True And CheckRigheCSV = False Then
                MessageBox.Show("Il numero di righe nel CSV scelto per le etichette è sostanzialmente diverso dal numero di righe dalla soluzione proposta. Righe nel csv: " & ArrayEtichetteCSV.Count & ", numerazione finale: " & NumeroFinale)
                GoOn = False
            End If
        End If


        If GoOn Then

            Cursor.Current = Cursors.WaitCursor

            GeneraPdf(ArrayEtichetteCSV)

            Cursor.Current = Cursors.Default

        End If

    End Sub

    Private Sub txtPrefisso_TextChanged(sender As Object, e As EventArgs) Handles txtPrefisso.TextChanged
        txtPrefissoD.Text = txtPrefisso.Text
        txtPrefissoD2.Text = txtPrefisso.Text
    End Sub

    Private Sub txtLarghezzaEtichetta_TextChanged(sender As Object, e As EventArgs) Handles txtLarghezzaEtichetta.TextChanged
        txtLarghezzaEtichettaD.Text = txtLarghezzaEtichetta.Text
        txtLarghezzaEtichettaD2.Text = txtLarghezzaEtichetta.Text
    End Sub

    Private Sub txtAltezzaEtichetta_TextChanged(sender As Object, e As EventArgs) Handles txtAltezzaEtichetta.TextChanged
        txtAltezzaEtichettaD.Text = txtAltezzaEtichetta.Text
        txtAltezzaEtichettaD2.Text = txtAltezzaEtichetta.Text
    End Sub

    Private Sub txtSuffisso_TextChanged(sender As Object, e As EventArgs) Handles txtSuffisso.TextChanged
        txtSuffissoD.Text = txtSuffisso.Text
        txtSuffissoD2.Text = txtSuffisso.Text
    End Sub

    Private PathFile As String = String.Empty

    Private Sub btnApri_Click(sender As Object, e As EventArgs) Handles btnApri.Click

        dlgOpenFile.InitialDirectory = FormerConfig.FormerPath.PathTempLocale

        If dlgOpenFile.ShowDialog = DialogResult.OK Then

            PathFile = dlgOpenFile.FileName

            Dim buffer As String = String.Empty

            Using r As New StreamReader(PathFile)

                buffer = r.ReadToEnd()

            End Using

            Dim Valori() As String = buffer.Split(";")

            Try
                txtLarghezza.Text = Valori(0)
                txtAltezza.Text = Valori(1)
                txtNumColonne.Text = Valori(2)
                txtNumRighe.Text = Valori(3)
                MgrControl.SelectIndexCombo(cmbFont, Valori(4))
                txtGrandezzaFont.Text = Valori(5)
                txtLarghezzaEtichetta.Text = Valori(6)
                txtAltezzaEtichetta.Text = Valori(7)
                txtBassoX.Text = Valori(8)
                txtBassoY.Text = Valori(9)
                txtPassoX.Text = Valori(10)
                txtPassoY.Text = Valori(11)
                txtPrefisso.Text = Valori(12)
                txtSuffisso.Text = Valori(13)
                chkInserisciDuplicato.Checked = Valori(14)
                MgrControl.SelectIndexCombo(cmbFontD, Valori(15))
                txtGrandezzaFontD.Text = Valori(16)
                txtLarghezzaEtichettaD.Text = Valori(17)
                txtAltezzaEtichettaD.Text = Valori(18)
                txtBassoXD.Text = Valori(19)
                txtBassoYD.Text = Valori(20)
                txtPassoXD.Text = Valori(21)
                txtPassoYD.Text = Valori(22)
                txtPrefissoD.Text = Valori(23)
                txtSuffissoD.Text = Valori(24)

                If Valori.Length > 25 Then

                    chkInserisciDuplicato2.Checked = Valori(25)
                    MgrControl.SelectIndexCombo(cmbFontD2, Valori(26))
                    txtGrandezzaFontD2.Text = Valori(27)
                    txtLarghezzaEtichettaD2.Text = Valori(28)
                    txtAltezzaEtichettaD2.Text = Valori(29)
                    txtBassoXD2.Text = Valori(30)
                    txtBassoYD2.Text = Valori(31)
                    txtPassoXD2.Text = Valori(32)
                    txtPassoYD2.Text = Valori(33)
                    txtPrefissoD2.Text = Valori(34)
                    txtSuffissoD2.Text = Valori(35)

                End If

                MessageBox.Show("Dati caricati")

            Catch ex As Exception
                MessageBox.Show("Si è verificato un errore nel caricamento dei dati. I dati potrebbero essere incompleti")
            End Try

        End If

    End Sub

    Private Sub btnSalva_Click(sender As Object, e As EventArgs) Handles btnSalva.Click

        If MessageBox.Show("Confermi il salvataggio dei valori inseriti?", "Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            'Dim PathFile As String = String.Empty

            'PathFile = 

            If PathFile.Length Then dlgSaveFile.InitialDirectory = FormerLib.FormerHelper.File.GetFolder(PathFile) 'FormerConfig.FormerPath.PathTempLocale

            If dlgSaveFile.ShowDialog = DialogResult.OK Then

                PathFile = dlgSaveFile.FileName

                Dim buffer As String = String.Empty

                buffer = txtLarghezza.Text & ";" &
                         txtAltezza.Text & ";" &
                         txtNumColonne.Text & ";" &
                         txtNumRighe.Text & ";" &
                         cmbFont.Text & ";" &
                         txtGrandezzaFont.Text & ";" &
                         txtLarghezzaEtichetta.Text & ";" &
                         txtAltezzaEtichetta.Text & ";" &
                         txtBassoX.Text & ";" &
                         txtBassoY.Text & ";" &
                         txtPassoX.Text & ";" &
                         txtPassoY.Text & ";" &
                         txtPrefisso.Text & ";" &
                         txtSuffisso.Text & ";" &
                         chkInserisciDuplicato.Checked & ";" &
                         cmbFontD.Text & ";" &
                         txtGrandezzaFontD.Text & ";" &
                         txtLarghezzaEtichettaD.Text & ";" &
                         txtAltezzaEtichettaD.Text & ";" &
                         txtBassoXD.Text & ";" &
                         txtBassoYD.Text & ";" &
                         txtPassoXD.Text & ";" &
                         txtPassoYD.Text & ";" &
                         txtPrefissoD.Text & ";" &
                         txtSuffissoD.Text & ";" &
                         chkInserisciDuplicato2.Checked & ";" &
                         cmbFontD2.Text & ";" &
                         txtGrandezzaFontD2.Text & ";" &
                         txtLarghezzaEtichettaD2.Text & ";" &
                         txtAltezzaEtichettaD2.Text & ";" &
                         txtBassoXD2.Text & ";" &
                         txtBassoYD2.Text & ";" &
                         txtPassoXD2.Text & ";" &
                         txtPassoYD2.Text & ";" &
                         txtPrefissoD2.Text & ";" &
                         txtSuffissoD2.Text

                Using r As New StreamWriter(PathFile)

                    r.Write(buffer)

                End Using

                MessageBox.Show("Salvataggio effettuato")

            End If

        End If

    End Sub

    Private Sub txtGrandezzaFont_TextChanged(sender As Object, e As EventArgs) Handles txtGrandezzaFont.TextChanged
        txtGrandezzaFontD.Text = txtGrandezzaFont.Text
        txtGrandezzaFontD2.Text = txtGrandezzaFont.Text

    End Sub

    Private Sub txtPassoX_TextChanged(sender As Object, e As EventArgs) Handles txtPassoX.TextChanged
        txtPassoXD.Text = txtPassoX.Text
        txtPassoXD2.Text = txtPassoX.Text
    End Sub

    Private Sub txtPassoY_TextChanged(sender As Object, e As EventArgs) Handles txtPassoY.TextChanged
        txtPassoYD.Text = txtPassoY.Text
        txtPassoYD2.Text = txtPassoY.Text
    End Sub

    Private Sub ApriSfondo()

        dlgOpenSfondo.Filter = "File PDF|*.pdf"

        If dlgOpenSfondo.ShowDialog = DialogResult.OK Then

            txtSfondo.Text = dlgOpenSfondo.FileName
            chkPDFSfondo.Checked = True

        End If

    End Sub

    Private Sub ApriCsv()

        dlgOpenSfondo.Filter = "File CSV|*.csv|File TXT|*.txt"

        If dlgOpenSfondo.ShowDialog = DialogResult.OK Then

            txtCSV.Text = dlgOpenSfondo.FileName
            chkCSVEtichette.Checked = True

        End If

    End Sub

    Private Sub btnSfondo_Click(sender As Object, e As EventArgs) Handles btnSfondo.Click

        ApriSfondo()

    End Sub

    Private Sub chkPDFSfondo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPDFSfondo.CheckedChanged

        If chkPDFSfondo.Checked = False Then
            txtSfondo.Text = String.Empty
        Else
            If sender.focused Then ApriSfondo()
        End If

    End Sub

    Private Sub lblOrient_Click(sender As Object, e As EventArgs) Handles lblOrient.Click,
                                                                            lblOrient1.Click,
                                                                            lblOrient2.Click
        If sender.text = 90 Then
            sender.text = 180
        ElseIf sender.text = 180 Then
            sender.text = 270
        Else
            sender.text = 90
        End If

    End Sub

    Private Sub btnCSV_Click(sender As Object, e As EventArgs) Handles btnCSV.Click
        ApriCsv()
    End Sub
End Class