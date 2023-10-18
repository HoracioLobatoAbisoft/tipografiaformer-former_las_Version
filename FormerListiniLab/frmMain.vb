Imports System.IO
Imports FormerListiniLib

Public Class frmMain

    Private Sub btnTry_Click(sender As Object, e As EventArgs) Handles btnTry.Click

        Cursor = Cursors.WaitCursor
        btnTry.Enabled = False

        Dim L As New ListinoUtente
        L.IdUt = 1
        L.Nominativo = "Diego Graphic"
        L.ColoreSfondo = lblColSfondo.BackColor
        L.ColoreContrasto = lblColPrimoPiano.BackColor
        L.PercRicarico = txtPerc.Text

        Dim PathWeb As String = "http://www.tipografiaformer.it/"

        'If rdoLocalHost.Checked Then
        '    PathWeb = "http://localhost/"
        'End If

        Dim PathFileDest As String = Application.StartupPath & "\listino.pdf"

        If FormerLib.FormerHelper.File.IsFileLocked(PathFileDest) Then
            MessageBox.Show("Il file di destinazione risulta bloccato, chiudere Acrobat Reader e riprovare")
        Else

            MGRListini.CreaCatalogo(PathFileDest, L, PathWeb)
            FormerLib.FormerHelper.File.ShellExtended(PathFileDest)

        End If

        btnTry.Enabled = True
        Cursor = Cursors.Default

    End Sub

    Private Sub lblColSfondo_Click(sender As Object, e As EventArgs) Handles lblColSfondo.Click

        dlgColor.Color = lblColSfondo.BackColor

        If dlgColor.ShowDialog() = DialogResult.OK Then

            lblColSfondo.BackColor = dlgColor.Color

        End If

    End Sub

    Private Sub lblColPrimoPiano_Click(sender As Object, e As EventArgs) Handles lblColPrimoPiano.Click

        dlgColor.Color = lblColPrimoPiano.BackColor

        If dlgColor.ShowDialog() = DialogResult.OK Then

            lblColPrimoPiano.BackColor = dlgColor.Color

        End If

    End Sub

    Private Sub btnReOpen_Click(sender As Object, e As EventArgs) Handles btnReOpen.Click

        Dim PathFileDest As String = Application.StartupPath & "\listino.pdf"

        If File.Exists(PathFileDest) Then
            FormerLib.FormerHelper.File.ShellExtended(PathFileDest)
        Else
            MessageBox.Show("Il listino non è stato ancora generato")
        End If

    End Sub
End Class
