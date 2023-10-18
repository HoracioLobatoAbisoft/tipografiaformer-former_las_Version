Imports System.IO
Imports FormerConfig
Imports FormerIO
Imports FormerLib

Public Class frmBug

    Private Function captureScreen(ByVal locX As Integer,
                                   ByVal locY As Integer,
                                   ByVal width As Integer,
                                   ByVal height As Integer) As Bitmap
        Dim NewImage As New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(NewImage)
            g.CopyFromScreen(locX, locY, 0, 0, NewImage.Size)
        End Using
        Return NewImage
    End Function

    Private _NomeFormChiamante As String = String.Empty
    Private FromAnomalia As Boolean = False
    Private _ErrorCode As String = String.Empty

    Public Sub Carica(FormChiamante As IFormWithSottofondo,
                      Optional Testo As String = "",
                      Optional ErrorCode As String = "")
        _ErrorCode = ErrorCode

        If Not FormChiamante Is Nothing Then _NomeFormChiamante = FormChiamante.Name

        If Testo.Length Then
            txtAnomalia.Text = ControlChars.NewLine & ControlChars.NewLine & ControlChars.NewLine & "****************" & Testo
            FromAnomalia = True
        End If

        Dim PathScreen As String = FormerPath.PathTempLocale & "lastscreen.jpg"

        If IO.File.Exists(PathScreen) Then MgrFormerIO.FileDelete(PathScreen)

        Dim Screenshot As Image = captureScreen(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)
        'Dim Screenshot As Image = Clipboard.GetImage()
        'Screenshot.Save(PathScreen, System.Drawing.Imaging.ImageFormat.Jpeg)
        'Clipboard.Clear()

        pctScreenshot.Image = Screenshot

        'MessageBox.Show("Funzione di segnalazione bug non ancora completata. Disponibile a breve")
        'FormerLib.FormerHelper.File.ShellExtended(PathScreen)
        Location = New Point(80, 80)

        If Not FormChiamante Is Nothing Then FormChiamante.Sottofondo()

        ShowDialog()

        If Not FormChiamante Is Nothing Then FormChiamante.Sottofondo()

    End Sub

    'Public Sub Carica(FormChiamante As frmBaseFormEx,
    '                  Optional Testo As String = "")

    '    If Not FormChiamante Is Nothing Then _NomeFormChiamante = FormChiamante.Name

    '    If Testo.Length Then
    '        txtAnomalia.Text = ControlChars.NewLine & ControlChars.NewLine & ControlChars.NewLine & "****************" & Testo
    '        FromAnomalia = True
    '    End If

    '    Dim PathScreen As String = FormerPath.PathTempLocale & "lastscreen.jpg"

    '    If IO.File.Exists(PathScreen) Then MgrFormerIO.FileDelete(PathScreen)

    '    Dim Screenshot As Image = captureScreen(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)
    '    'Dim Screenshot As Image = Clipboard.GetImage()
    '    'Screenshot.Save(PathScreen, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    'Clipboard.Clear()

    '    pctScreenshot.Image = Screenshot

    '    'MessageBox.Show("Funzione di segnalazione bug non ancora completata. Disponibile a breve")
    '    'FormerLib.FormerHelper.File.ShellExtended(PathScreen)
    '    Location = New Point(80, 80)

    '    If Not FormChiamante Is Nothing Then FormChiamante.Sottofondo()

    '    ShowDialog()

    '    If Not FormChiamante Is Nothing Then FormChiamante.Sottofondo()

    'End Sub


    Private Sub btnChiudi_Click(sender As Object, e As EventArgs) Handles btnChiudi.Click

        Close()

    End Sub

    Private Sub btnSalva_Click(sender As Object, e As EventArgs) Handles btnSalva.Click

        If txtTitolo.Text.Trim.Length Then

            If txtAnomalia.Text.Trim.Length Then
                'qui vado a salvare screenshot e anomalia 
                If MessageBox.Show("Confermi la segnalazione dell'anomalia inserita?", "Segnalazione Anomalia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Cursor.Current = Cursors.WaitCursor
                    Try
                        'Dim PathFolder As String = FormerPath.PathBug


                        'Dim FolderName As String = Now.ToString("yyyyMMdd-HHmmss") & "-" & StrConv(PostazioneCorrente.UtenteConnesso.Login, VbStrConv.ProperCase) & "\"
                        'PathFolder &= FolderName

                        Dim PathFolder As String = FormerPath.PathBug

                        If _ErrorCode <> String.Empty Then
                            PathFolder &= "error\" & _ErrorCode & "\"
                        Else
                            PathFolder &= "todo\"
                        End If

                        FormerLib.FormerHelper.File.CreateLongPath(PathFolder)

                        Dim NumeroSegnalazione As String = PostazioneCorrente.UtenteConnesso.IdUt & "-" & Now.ToString("yyyyMMddHHmmss")

                        Dim TextPath As String = PathFolder & NumeroSegnalazione & ".txt"
                        Dim ScreenPath As String = PathFolder & NumeroSegnalazione & ".jpg"

                        Dim Screenshot As Image = pctScreenshot.Image
                        Screenshot.Save(ScreenPath, System.Drawing.Imaging.ImageFormat.Jpeg)

                        Dim BufferSegnalazione As String = "QUANDO: " & Now & ControlChars.NewLine
                        BufferSegnalazione &= "UTENTE: " & PostazioneCorrente.UtenteConnesso.Login & ControlChars.NewLine
                        BufferSegnalazione &= "VERSIONE: " & PostazioneCorrente.Versione & ControlChars.NewLine
                        BufferSegnalazione &= "POSTAZIONE: " & Environment.MachineName & ControlChars.NewLine
                        If _NomeFormChiamante.Length Then BufferSegnalazione &= "FORM CHIAMANTE: " & _NomeFormChiamante & ControlChars.NewLine
                        BufferSegnalazione &= "**************************************" & ControlChars.NewLine
                        BufferSegnalazione &= txtAnomalia.Text

                        Using w As New StreamWriter(TextPath)
                            w.Write(BufferSegnalazione)
                        End Using

                        Try
                            FormerLib.FormerHelper.Mail.InviaMail("Segnalazione Anomalia: " & txtTitolo.Text, BufferSegnalazione.Replace(ControlChars.NewLine, "<br>"), FormerLib.FormerConst.EmailAssistenzaTecnica,,, ScreenPath)
                        Catch ex As Exception

                        End Try
                        Cursor.Current = Cursors.Default

                        Close()

                    Catch ex As Exception
                        Cursor.Current = Cursors.Default
                        MessageBox.Show("Non riesco a salvare la segnalazione. Errore " & ex.Message)
                    End Try

                End If
            Else
                MessageBox.Show("Inserire una descrizione dettagliata dell'anomalia riscontrata o della modifica richiesta")
            End If

        Else
            MessageBox.Show("Inserire un titolo per questa segnalazione")
        End If

    End Sub
End Class