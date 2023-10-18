Imports FormerLib

Friend Class frmPdfTools
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)

        If MessageBox.Show("Confermi qualcosa?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub lnkAddFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddFile.LinkClicked

        Dim Path As String = String.Empty

        Using f As New frmOpenPDF
            Sottofondo()
            f.Carica()
            Sottofondo()
            If f.SelectedFile.Length Then
                Dim lv As New ListViewItem
                lv.ImageIndex = 0
                lv.Text = FormerLib.FormerHelper.File.EstraiNomeFile(f.SelectedFile)
                lv.Tag = f.SelectedFile

                lvwAllegati.Items.Add(lv)
            End If

        End Using



    End Sub

    Private Sub lnkElimina_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkElimina.LinkClicked

        If lvwAllegati.SelectedItems.Count Then
            If MessageBox.Show("Confermi la rimozione dei file selezionati?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                For i As Integer = lvwAllegati.SelectedItems.Count - 1 To 0
                    lvwAllegati.Items.Remove(lvwAllegati.SelectedItems(i))
                Next
            End If
        End If

    End Sub

    Private Sub lnkMergeFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMergeFile.LinkClicked

        If lvwAllegati.Items.Count Then

            If MessageBox.Show("Vuoi fare il merge di ogni pagina dei file selezionati in un unico file?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim ListaPdf As New List(Of String)

                For Each Sing As ListViewItem In lvwAllegati.SelectedItems
                    ListaPdf.Add(Sing.Tag)
                Next

                Dim NumPag As Integer = 0
                Dim CheckPagineOk As Boolean = True

                For Each singF In ListaPdf
                    If NumPag = 0 Then
                        NumPag = FormerHelper.PDF.GetNumeroPagine(singF)
                    Else
                        If NumPag <> FormerHelper.PDF.GetNumeroPagine(singF) Then
                            CheckPagineOk = False
                            Exit For
                        End If
                    End If
                Next

                If CheckPagineOk Then

                    Dim tmpPage As String = FormerConfig.FormerPath.PathTempLocale & "paginaTemp.$.pdf"

                    Dim R As New Random
                    Dim Casuale As Integer = R.Next(0, 1000)
                    Dim NomeFile As String = FormerConfig.FormerPath.PathTempLocale & "FileCombinato." & Casuale & ".pdf"
                    Dim ListaPdfPagine(NumPag) As String

                    For i As Integer = 1 To NumPag
                        Dim ListaPdfFinale(ListaPdf.Count) As String
                        Dim Counter As Integer = 0

                        For Each singf In ListaPdf

                            FormerLib.FormerHelper.PDF.EstraiPaginaFromPdf(singf, tmpPage.Replace("$", Counter), i)
                            ListaPdfFinale(Counter) = tmpPage.Replace("$", Counter)

                            Counter += 1

                        Next

                        Dim PathContenitore As String = FormerConfig.FormerPath.PathTempLocale & "contSingPag." & i & ".pdf"
                        Dim PathContenitoreTemp As String = FormerConfig.FormerPath.PathTempLocale & "contSingPagTmp.pdf"
                        System.IO.File.Copy(ListaPdfFinale(0), PathContenitoreTemp, True)

                        Dim Contatore As Integer = 0

                        For x As Integer = 0 To ListaPdfFinale.Count - 1
                            If Not ListaPdfFinale(x) Is Nothing Then
                                If Contatore <> 0 Then
                                    FormerHelper.PDF.CombinaPDF(PathContenitoreTemp, ListaPdfFinale(x), PathContenitore, 0, 0, 0, 0)
                                    System.IO.File.Copy(PathContenitore, PathContenitoreTemp, True)
                                End If
                                Contatore += 1
                            End If
                        Next

                        'qui in pathcontenuitore c'ho tutta la singola pagina 
                        ListaPdfPagine(i - 1) = PathContenitore

                        Application.DoEvents()

                    Next

                    'qui li monto insieme
                    FormerHelper.PDF.MergePdfFiles(ListaPdfPagine, NomeFile)

                    FormerHelper.File.ShellExtended(NomeFile)

                Else
                    MessageBox.Show("I file devono avere tutti lo stesso numero di pagine")
                End If

            End If
        Else
            MessageBox.Show("Aggiungere dei file alla cartella di lavoro")
        End If



    End Sub

    Private Sub lnkUnicoFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUnicoFile.LinkClicked

        If lvwAllegati.Items.Count Then
            If MessageBox.Show("Confermi la creazione di un unico file dei file selezionati ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim ListaPdf(lvwAllegati.SelectedItems.Count) As String
                Dim I As Integer = 0
                For Each Sing As ListViewItem In lvwAllegati.SelectedItems
                    ListaPdf(I) = Sing.Tag
                    I += 1
                Next

                'For i = 0 To lvwAllegati.SelectedItems.Count - 1
                '    Dim t As String = lvwAllegati.SelectedItems.ToString()
                '    ListaPdf(i) = lvwAllegati.SelectedItems(i).Tag

                'Next

                Dim R As New Random
                Dim Casuale As Integer = R.Next(0, 1000)
                Dim NomeFile As String = "FileCombinato." & Casuale & ".pdf"

                NomeFile = InputBox("Inserisci il nome del file che sarà creato unendo i file PDF selezionati", "Nome File Combinato", NomeFile)

                If NomeFile.Length Then
                    If NomeFile.EndsWith(".pdf") = False Then NomeFile &= ".pdf"

                    Dim PathEnd As String = FormerConfig.FormerPath.PathTempLocale & NomeFile

                    FormerHelper.PDF.MergePdfFiles(ListaPdf, PathEnd)

                    FormerHelper.File.ShellExtended(PathEnd)

                End If
            End If

        Else
            MessageBox.Show("Aggiungere dei file alla cartella di lavoro")
        End If

    End Sub
End Class