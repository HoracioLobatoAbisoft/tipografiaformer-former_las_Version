Friend Class frmListinoImgTemporanea
    'Inherits baseFormInternaFixed

    Private _PathLastImg As String = String.Empty

    Friend Function Carica() As String

        'ritorna il path dell'immagine temporanea appena creata 

        txtTesto.Focus()

        ShowDialog()

        Return _PathLastImg

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        _PathLastImg = String.Empty

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtTesto.Text.Trim.Length Then
            If MessageBox.Show("Confermi il salvataggio dell'immagine?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                CreaImg()
                Close()

            End If
        Else
            MessageBox.Show("Inserire un testo!")
        End If

    End Sub

    Private Sub CreaImg()
        Try
            Using i As Image = New Bitmap(128, 128)

                Using flagGraphics As Graphics = Graphics.FromImage(i)

                    Dim orangeBr As New SolidBrush(Color.FromArgb(225, 128, 0))
                    Dim blackBr As New SolidBrush(Color.FromArgb(64, 64, 64))

                    Dim scrittaBr As SolidBrush = Nothing
                    Dim sfondoBr As SolidBrush = Nothing

                    scrittaBr = blackBr
                    sfondoBr = orangeBr

                    Dim drawRect As New RectangleF(0, 0, 128, 128)
                    flagGraphics.FillRectangle(sfondoBr, drawRect)

                    Dim f As New Font("Roboto Mono", 12, FontStyle.Bold)

                    Dim TestoDaInserire As String = txtTesto.Text.Trim

                    flagGraphics.DrawString(TestoDaInserire, f, scrittaBr, -1, 50)

                    flagGraphics.Save()

                    Dim Path As String = FormerConfig.FormerPath.PathListinoImg
                    Dim NomeImg As String = FormerLib.FormerHelper.File.GetNomeFileTemp(".png", True)

                    _PathLastImg = Path & NomeImg

                    'Path = "H:\temp\ico_" & Lettera & ".png"
                    i.Save(_PathLastImg)

                End Using
                'pctImgLav.Image = Image.FromFile(_PathLastImg)

                'FormerLib.FormerHelper.File.ShellExtended(Path)

            End Using
        Catch ex As Exception
            ManageError(ex)
        End Try

    End Sub

End Class