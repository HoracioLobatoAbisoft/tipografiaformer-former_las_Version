Imports System.Drawing.Imaging
Imports FormerConfig

Friend Class frmOpenIMG
    'Inherits baseFormInternaFixed

    Private _Ris As String = String.Empty

    Friend Function Carica(Optional FWidth As Integer = 128,
                           Optional FHeight As Integer = 128) As String

        lblCrop.Width = FWidth
        lblCrop.Height = FHeight

        If FWidth > Width OrElse
           FHeight > Height Then
            WindowState = FormWindowState.Maximized
        End If

        webSearch.Navigate("https://www.google.it/imghp?hl=it")

        ShowDialog()

        Return _Ris

    End Function

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        lblCrop.Parent = pctMain
        lblCrop.Location = New Point(0, 0)
        lblCrop.BackColor = Color.Transparent

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Public Property PrefissoDaApplicare As String = String.Empty

    Private Sub CropImage()

        Try
            Dim Prefisso As String = "crop"

            If PrefissoDaApplicare.length Then
                Prefisso = PrefissoDaApplicare
            End If

            Dim Estensione As String = "." & FormerLib.FormerHelper.File.GetEstensione(_PathFileWork)
            Dim fileNameOutput = FormerPath.PathTempLocale & Prefisso & Now.ToString("yyyyMMddHHmmss") & ".jpg"

            Dim x As Integer = 0
            Dim y As Integer = 0

            x = lblCrop.Left ' - pctMain.Left
            y = lblCrop.Top ' - pctMain.Top

            Dim TempFile As String = String.Empty

            If txtTesto.Text.Length Then
                TempFile = ApplicaTesto(True)
            Else
                TempFile = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(Estensione)
                FormerLib.FormerHelper.MgrImage.ResizeImgPublic(_PathFileWork, TempFile, pctMain.Width, pctMain.Height, , False)
            End If

            Dim CropRect As New Rectangle(x, y, lblCrop.Width, lblCrop.Height) '128, 128)
            Dim OriginalImage = Image.FromFile(TempFile)
            Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
            Using grp = Graphics.FromImage(CropImage)
                grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                OriginalImage.Dispose()


                Dim enc As Imaging.ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
                Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                Dim myEncoderParameters As EncoderParameters = New EncoderParameters(1)

                Dim myEncoderParameter As EncoderParameter = New EncoderParameter(myEncoder, 90)
                myEncoderParameters.Param(0) = myEncoderParameter

                CropImage.Save(fileNameOutput, enc, myEncoderParameters)
            End Using

            _Ris = fileNameOutput

            'FormerLib.FormerHelper.File.ShellExtended(FormerLib.FormerHelper.File.GetFolder(fileNameOutput))

            Close()
        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore nel crop dell'immagine, riprovare. " & ex.Message)
        End Try

    End Sub

    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        For Each codec As ImageCodecInfo In codecs

            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next

        Return Nothing
    End Function

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il taglio dell'immagine selezionata?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            CropImage()

        End If

    End Sub

    Private _PathFileWork As String = String.Empty

    Private Sub LoadFile(Path As String, Optional ReplaceFileToWork As Boolean = True)
        Cursor = Cursors.WaitCursor
        pctMain.Image = Image.FromFile(Path)

        Dim misure As Size = FormerLib.FormerHelper.MgrImage.GetImageDimension(Path)
        pctMain.Width = misure.Width
        pctMain.Height = misure.Height

        If ReplaceFileToWork Then _PathFileWork = Path
        Cursor = Cursors.Default
    End Sub

    Private Sub lnkApri_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkApri.LinkClicked

        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgPath.Text = OpenFileImg.FileName
            LoadFile(OpenFileImg.FileName)
        End If

    End Sub

    Private Sub lnkScarica_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkScarica.LinkClicked

        If txtWeb.Text.Trim.Length Then
            Cursor = Cursors.WaitCursor
            Try
                Dim NomeFileOnline As String = txtWeb.Text.Trim.ToLower
                Dim Estensione As String = ".png"
                If NomeFileOnline.EndsWith("jpg") OrElse
                    NomeFileOnline.EndsWith("jpeg") OrElse
                    NomeFileOnline.EndsWith("png") Then
                    Estensione = "." & FormerLib.FormerHelper.File.GetEstensione(NomeFileOnline)
                End If

                Dim PathTempLocale As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(Estensione)

                FormerLib.FormerHelper.Web.GetFile(NomeFileOnline, PathTempLocale)
                pctMain.Image = Image.FromFile(PathTempLocale)
                Dim misure As Size = FormerLib.FormerHelper.MgrImage.GetImageDimension(PathTempLocale)
                pctMain.Width = misure.Width
                pctMain.Height = misure.Height

                _PathFileWork = PathTempLocale
            Catch ex As Exception
                MessageBox.Show("Si è verificato un errore nello scaricamento dell'immagine")
            End Try
            Cursor = Cursors.Default

        Else
            MessageBox.Show("Inserire un URL valido")
        End If




    End Sub

    Private Sub lblCrop_Click(sender As Object, e As EventArgs) Handles lblCrop.Click
        lblCrop.Focus()
    End Sub

    Private Sub lblCrop_MouseDown(sender As Object, e As MouseEventArgs) Handles lblCrop.MouseDown

        'SpostaCrop(e)

    End Sub

    Private Sub lblCrop_MouseUp(sender As Object, e As MouseEventArgs) Handles lblCrop.MouseUp



    End Sub

    Private Sub SpostaCrop(e As MouseEventArgs)

        Dim x As Integer = e.X
        Dim y As Integer = e.Y

        If x + (lblCrop.Width / 2) <= pctMain.Width Then

            If x - (lblCrop.Width / 2) < 0 Then
                lblCrop.Left = 0
            Else
                lblCrop.Left = x - (lblCrop.Width / 2)
            End If
        Else
            lblCrop.Left = pctMain.Width - lblCrop.Width
        End If

        If y + (lblCrop.Height / 2) <= pctMain.Height Then

            If y - (lblCrop.Height / 2) < 0 Then
                lblCrop.Top = 0
            Else
                lblCrop.Top = y - (lblCrop.Height / 2)
            End If
        Else
            lblCrop.Top = pctMain.Height - lblCrop.Height
        End If

    End Sub

    Private Sub SpostaCrop(e As KeyEventArgs)
        If Not pctMain.Image Is Nothing Then
            Dim Incremento As Integer = 1
            If e.Shift Then
                Incremento = 16
            End If

            If e.KeyCode = Keys.Left Then

                If lblCrop.Left - Incremento >= 0 Then
                    lblCrop.Left -= Incremento
                End If

            End If

            If e.KeyCode = Keys.Down Then

                If lblCrop.Top + lblCrop.Height + Incremento <= pctMain.Height Then
                    lblCrop.Top += Incremento
                End If

            End If

            If e.KeyCode = Keys.Right Then

                If lblCrop.Left + lblCrop.Width + Incremento <= pctMain.Width Then
                    lblCrop.Left += Incremento
                End If

            End If

            If e.KeyCode = Keys.Up Then

                If lblCrop.Top - Incremento >= 0 Then
                    lblCrop.Top -= Incremento
                End If

            End If

        End If

    End Sub

    Private Sub frmOpenIMG_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.Control = True AndAlso e.KeyCode = Keys.V Then

            PasteImg()

        Else
            SpostaCrop(e)
        End If
    End Sub

    Private Sub tbProd_Click(sender As Object, e As EventArgs) Handles tbProd.Click

    End Sub

    Private Sub tbProd_KeyDown(sender As Object, e As KeyEventArgs) Handles tbProd.KeyDown
        SpostaCrop(e)
    End Sub

    Private Sub pctMain_KeyDown(sender As Object, e As KeyEventArgs) Handles pctMain.KeyDown
        SpostaCrop(e)
    End Sub

    Private Sub lblCrop_KeyDown(sender As Object, e As KeyEventArgs) Handles lblCrop.KeyDown
        SpostaCrop(e)
    End Sub

    Private Sub pctMain_Click(sender As Object, e As EventArgs) Handles pctMain.Click

    End Sub

    Private Sub ResizeImg(e As MouseEventArgs)
        If Not pctMain.Image Is Nothing Then
            If e.Delta <> 0 Then

                If e.Delta <= 0 Then
                    If pctMain.Width <= lblCrop.Width Then Exit Sub '128 Then Exit Sub 'minimum 500?
                    If pctMain.Height <= lblCrop.Height Then Exit Sub '128 Then Exit Sub 'minimum 500?
                Else
                    If pctMain.Width > 3000 Then Exit Sub 'maximum 2000?
                    If pctMain.Height > 3000 Then Exit Sub 'maximum 2000?
                End If

                Dim diffW As Integer = CInt(pctMain.Width * e.Delta / 1000)
                Dim diffH As Integer = CInt(pctMain.Height * e.Delta / 1000)

                Dim NewMisW As Integer = pctMain.Width + diffW
                Dim NewMisH As Integer = pctMain.Height + diffH

                'If NewMisW<pctMain.Width Or 

                If NewMisW < lblCrop.Width Then
                    'qui e' troppo stretta allargo e ricalcolo di conseguenza l'altezza
                    NewMisW = lblCrop.Width
                    NewMisH = ((lblCrop.Width * NewMisH) / NewMisW)
                ElseIf NewMisH < lblCrop.Height Then
                    'qui e' troppo bassa alzo e ricalcolo di conseguenza la larghezza
                    NewMisH = lblCrop.Height
                    'NewMisH = ((lblCrop.Width * pctMain.Height) / pctMain.Width)
                    NewMisW = ((lblCrop.Height * NewMisW) / NewMisH)
                End If


                If NewMisW >= lblCrop.Width AndAlso NewMisH >= lblCrop.Height Then
                    pctMain.Width = NewMisW
                    pctMain.Height = NewMisH

                    If pctMain.Left < 0 Then

                        Dim NuovoLeft As Integer = pctMain.Left + Math.Abs(diffW)

                        If NuovoLeft > 0 Then NuovoLeft = 0

                        pctMain.Left = NuovoLeft
                        HScrollBar.Maximum = NuovoLeft
                    End If

                    If pctMain.Top < 0 Then

                        Dim NuovoTop As Integer = pctMain.Top + Math.Abs(diffH)

                        If NuovoTop > 0 Then NuovoTop = 0

                        pctMain.Top = NuovoTop
                        VScrollBar.Maximum = NuovoTop
                    End If
                    ApplicaTesto()
                End If


            End If
        End If

    End Sub

    Private Sub pctMain_MouseWheel(sender As Object, e As MouseEventArgs) Handles pctMain.MouseWheel
        ResizeImg(e)

    End Sub

    Private Sub lblCrop_MouseWheel(sender As Object, e As MouseEventArgs) Handles lblCrop.MouseWheel
        ResizeImg(e)
    End Sub

    Private Sub tbProd_MouseWheel(sender As Object, e As MouseEventArgs) Handles tbProd.MouseWheel
        ResizeImg(e)
    End Sub

    Private Sub pctMain_MouseDown(sender As Object, e As MouseEventArgs) Handles pctMain.MouseDown
        SpostaCrop(e)
    End Sub

    Private Sub pctMain_Resize(sender As Object, e As EventArgs) Handles pctMain.Resize

        'sposto il crop
        If pctMain.Left + pctMain.Width < (lblCrop.Left + lblCrop.Width) Then
            lblCrop.Left = Math.Abs(pctMain.Left) + pctMain.Width - lblCrop.Width
        End If

        If pctMain.Top + pctMain.Height < (lblCrop.Top + lblCrop.Height) Then
            lblCrop.Top = Math.Abs(pctMain.Top) + pctMain.Height - lblCrop.Height
        End If

        'abilito le scrollbars
        If pctMain.Width > pnlImg.Width Then
            HScrollBar.Enabled = True
            HScrollBar.SmallChange = 1
            HScrollBar.LargeChange = 25
            HScrollBar.Minimum = 0
            HScrollBar.Maximum = pctMain.Width - pnlImg.Width
        Else
            HScrollBar.Enabled = False
        End If

        If pctMain.Height > pnlImg.Height Then
            VScrollBar.Enabled = True
            VScrollBar.SmallChange = 1
            VScrollBar.LargeChange = 25
            VScrollBar.Minimum = 0
            VScrollBar.Maximum = pctMain.Height - pnlImg.Height
        Else
            VScrollBar.Enabled = False
        End If

    End Sub

    Private Sub HScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar.Scroll

        Dim actualValue As Integer = 0

        If pctMain.Left - HScrollBar.Value > 0 Then
            pctMain.Left = -HScrollBar.Value
        End If

    End Sub

    Private Sub VScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar.Scroll
        pctMain.Top = -VScrollBar.Value
    End Sub

    Private Sub pctMain_Move(sender As Object, e As EventArgs) Handles pctMain.Move

        'qui devo vedere se spostare il crop
        If lblCrop.Left + pctMain.Left < 0 Then
            lblCrop.Left = Math.Abs(pctMain.Left)
        ElseIf lblCrop.Left + lblCrop.Width + pctMain.Left > pctMain.Width Then
            lblCrop.Left = pnlImg.Width - lblCrop.Width + Math.Abs(pctMain.Left)
        End If

        If lblCrop.Top + pctMain.Top < 0 Then
            lblCrop.Top = Math.Abs(pctMain.Top)
        ElseIf lblCrop.Top + lblCrop.Height + pctMain.Top > pnlImg.Height Then
            lblCrop.Top = pnlImg.Height - lblCrop.Height + Math.Abs(pctMain.Top)
        End If

    End Sub

    Private Sub txtWeb_TextChanged(sender As Object, e As EventArgs) Handles txtWeb.TextChanged

    End Sub

    Private Sub txtWeb_Click(sender As Object, e As EventArgs) Handles txtWeb.Click



    End Sub

    Private Sub txtWeb_MouseDown(sender As Object, e As MouseEventArgs) Handles txtWeb.MouseDown
        If txtWeb.SelectionLength = 0 Then
            txtWeb.SelectAll()
        End If
    End Sub

    Private Sub lnkIncolla_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkIncolla.LinkClicked

        PasteImg()

    End Sub

    Private Sub PasteImg()

        If Clipboard.ContainsImage Then

            Dim PathTemp As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(".jpg")

            Using img As Image = Clipboard.GetImage
                img.Save(PathTemp, Imaging.ImageFormat.Jpeg)
            End Using
            LoadFile(PathTemp)
        Else
            Beep()
        End If

    End Sub

    Private Sub txtTesto_TextChanged(sender As Object, e As EventArgs) Handles txtTesto.TextChanged
        ApplicaTesto()
    End Sub

    Private Function ApplicaTesto(Optional ReplacePathFileToWork As Boolean = False) As String

        Dim Ris As String = String.Empty
        Try
            If _PathFileWork.Length Then
                'qui ho un file da lavorare
                Dim Estensione As String = ".png"
                If _PathFileWork.EndsWith("jpg") OrElse
                    _PathFileWork.EndsWith("jpeg") OrElse
                    _PathFileWork.EndsWith("png") Then
                    Estensione = "." & FormerLib.FormerHelper.File.GetEstensione(_PathFileWork)
                End If

                Dim PathTemp As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(Estensione)

                FormerLib.FormerHelper.MgrImage.ResizeImgPublic(_PathFileWork, PathTemp, pctMain.Width, pctMain.Height, , False)

                Dim PathTempFinale As String = FormerPath.PathTempLocale & FormerLib.FormerHelper.File.GetNomeFileTemp(Estensione)

                Using bmp As Bitmap = Bitmap.FromFile(PathTemp)
                    Using gr As Graphics = Graphics.FromImage(bmp)

                        Dim customBrush As Brush
                        customBrush = New Drawing.SolidBrush(lblColore.BackColor)

                        gr.DrawImageUnscaled(bmp, 0, 0)
                        gr.DrawString(txtTesto.Text, New Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold), customBrush, New RectangleF(0, 0, bmp.Width, bmp.Height))
                        bmp.Save(PathTempFinale, Imaging.ImageFormat.Jpeg)
                    End Using
                    'Using newImage As New Bitmap(pctMain.Width, pctMain.Height)
                    '    Using gr As Graphics = Graphics.FromImage(newImage)
                    '        gr.DrawImageUnscaled(bmp, 0, 0)
                    '        gr.DrawString(txtTesto.Text, New Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold), Brushes.DarkBlue, New RectangleF(0, 0, bmp.Width, 50))
                    '        newImage.Save(PathTemp)
                    '    End Using
                    'End Using
                End Using

                Ris = PathTempFinale

                LoadFile(PathTempFinale, ReplacePathFileToWork)

            End If
        Catch ex As Exception

        End Try


        Return Ris

    End Function

    Private Sub lnkColoreDef_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkColoreDef.LinkClicked
        lblColore.BackColor = Color.FromArgb(59, 79, 98)
        ApplicaTesto()
    End Sub

    Private Sub lnkColoreBlack_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkColoreBlack.LinkClicked
        lblColore.BackColor = Color.Black
        ApplicaTesto()
    End Sub

    Private Sub lnkColoreWhite_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkColoreWhite.LinkClicked
        lblColore.BackColor = Color.White
        ApplicaTesto()
    End Sub

    Private Sub lnkColoreCustom_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkColoreCustom.LinkClicked
        dlgColor.AllowFullOpen = True
        dlgColor.AnyColor = True
        If dlgColor.ShowDialog = DialogResult.OK Then
            lblColore.BackColor = dlgColor.Color
            ApplicaTesto()
        End If

    End Sub

    Private Sub lblColore_Click(sender As Object, e As EventArgs) Handles lblColore.Click
        dlgColor.AllowFullOpen = True
        dlgColor.AnyColor = True
        dlgColor.Color = lblColore.BackColor
        If dlgColor.ShowDialog = DialogResult.OK Then
            lblColore.BackColor = dlgColor.Color
            ApplicaTesto()
        End If
    End Sub

    Private Sub lblCrop_Resize(sender As Object, e As EventArgs) Handles lblCrop.Resize

    End Sub

    Private Sub lblCrop_SizeChanged(sender As Object, e As EventArgs) Handles lblCrop.SizeChanged
        lblCrop.Text = "(" & lblCrop.Size.Width & "x" & lblCrop.Size.Height & ")"
    End Sub
End Class