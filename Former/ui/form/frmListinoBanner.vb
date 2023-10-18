Imports FormerDALSql
Imports System.IO
Imports FormerLib.FormerEnum
Imports FormerConfig

Friend Class frmListinoBanner
    'Inherits baseFormInternaFixed
    Private _Ris As Integer
    Private _IdBannerSito As Integer = 0

    Friend Function Carica(Optional Banner As BannerSito = Nothing) As Integer

        If Not Banner Is Nothing Then
            _IdBannerSito = Banner.IdBannerSito
            txtUrl.Text = Banner.Url
            txtAlternate.Text = Banner.Alternate
            txtImgRif.Text = Banner.imgRif
            Try
                pctImgRif.Load(Banner.imgRif)
            Catch ex As Exception

            End Try
            If Banner.Stato = enStato.Attivo Then rdoAttivo.Checked = True Else rdoNonAttivo.Checked = True
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio del banner?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim CheckImgOk As Boolean = True
            Dim DimensioniKb As Single = 0
            Dim RilWidth As Integer = 0
            Dim RilHeigth As Integer = 0

            If txtImgRif.Text.Length = 0 Then
                CheckImgOk = False
            Else
                If txtImgRif.Text.ToLower.EndsWith("jpg") = False Then
                    CheckImgOk = False
                Else
                    Dim f As New FileInfo(txtImgRif.Text)

                    DimensioniKb = f.Length / 1024

                    If DimensioniKb > 55 Then
                        CheckImgOk = False
                    End If

                    'qui controllo le dimensioni in pixel 
                    Dim b As New Bitmap(txtImgRif.Text)
                    RilWidth = b.Width
                    RilHeigth = b.Height
                    If b.Width <> 800 Or b.Height <> 200 Then
                        CheckImgOk = False
                    End If

                End If
            End If

            If CheckImgOk Then
                Dim b As New BannerSito
                If _IdBannerSito Then
                    b.Read(_IdBannerSito)
                Else
                    'qui devo prendere l'ordine giusto
                    Using mgr As New BannerSitoDAO
                        Dim l As List(Of BannerSito) = mgr.GetAll()
                        b.Ordine = l.Count + 1
                    End Using
                End If

                b.Url = txtUrl.Text
                If b.Url.StartsWith("https://www.tipografiaformer.it") Then
                    b.Url = b.Url.Substring("https://www.tipografiaformer.it".Length)
                End If
                If b.Url.StartsWith("/") = False AndAlso b.Url.StartsWith("http") = False Then
                    b.Url = "/" & b.Url
                End If

                If b.Url <> "/" Then
                    b.Alternate = txtAlternate.Text.Replace("""", "'")
                    b.Stato = IIf(rdoAttivo.Checked, enStato.Attivo, enStato.NonAttivo)
                    'b.imgRif = "/"
                    If b.IsValid Then
                        'copio l'immagine nella cartella centralizzata
                        If txtImgRif.Text.Length Then
                            If txtImgRif.Text <> b.imgRif Then
                                Dim nuovoNome As String = String.Empty
                                If txtImgRif.Text.StartsWith(FormerPath.PathBannerSito) Then
                                    'non devo copiare
                                    nuovoNome = txtImgRif.Text
                                Else
                                    'devo copiare 
                                    nuovoNome = FormerPath.PathBannerSito & FormerLib.FormerHelper.File.GetNomeFileTemp(".jpg")
                                    MgrIO.FileCopia(Me, txtImgRif.Text, nuovoNome)
                                End If
                                b.imgRif = nuovoNome
                            End If
                        End If

                        b.Save()
                        _Ris = 1
                        Close()

                    Else
                        MessageBox.Show("Inserisci tutti i dati per il salvataggio del banner!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Non è possibile impostare banner che linkano alla homepage.")
                End If


            Else
                MessageBox.Show("L'immagine del Banner è Obbligatoria, in formato JPG, dimensioni esatte 800 pixel (larghezza) per 200 pixel (altezza) con dimensioni massime di 55kb. Dimensioni rilevate: " & RilWidth & "x" & RilHeigth & " pixel - Kb:" & DimensioniKb)
            End If

        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgRif.Text = OpenFileImg.FileName
            pctImgRif.Image = Image.FromFile(txtImgRif.Text)
        End If
    End Sub

    Private Sub txtAlternate_TextChanged(sender As Object, e As EventArgs) Handles txtAlternate.TextChanged, txtUrl.TextChanged
        If sender.Text.Trim.Length = 0 Then
            sender.Text = sender.Tag
        End If
    End Sub

    Private Sub btnTestUrl_Click(sender As Object, e As EventArgs) Handles btnTestUrl.Click

        Dim Url As String = "https://www.tipografiaformer.it"

        Url &= txtUrl.Text

        FormerLib.FormerHelper.File.ShellExtended(Url)

    End Sub
End Class