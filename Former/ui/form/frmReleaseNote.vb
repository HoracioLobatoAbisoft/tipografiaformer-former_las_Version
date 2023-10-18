Imports System.IO

Friend Class frmReleaseNote
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        Dim LastRelease As Boolean = False
        Dim PathToLoad As String = PostazioneCorrente.PathReleaseNote

        If File.Exists(PathToLoad) = False Then
            PathToLoad = PostazioneCorrente.PathLastReleaseNote
            LastRelease = True
        End If

        If File.Exists(PathToLoad) Then

            Dim Buffer As String = String.Empty

            Using r As New StreamReader(PathToLoad)
                Buffer = r.ReadToEnd
            End Using

            txtNoteRilascio.Text = Buffer

            If LastRelease = False Then

                Try
                    File.Copy(PostazioneCorrente.PathReleaseNote, PostazioneCorrente.PathLastReleaseNote)

                Catch ex As Exception

                End Try

                Try
                    File.Delete(PostazioneCorrente.PathReleaseNote)

                Catch ex As Exception

                End Try

            End If

            ShowDialog()
        End If

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

End Class