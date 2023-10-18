Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucMailPreview
    Inherits ucFormerUserControl

    Private Mail As PreventivoMail = Nothing

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

        MgrControl.InizializeCollapsiblePanel(pnlTop)
    End Sub

    Public Sub Carica(P As PreventivoMail)
        Cursor = Cursors.WaitCursor

        Mail = P

        Try
            lblData.Text = Mail.DataRif
            lblTitolo.Text = Mail.Titolo

            If Mail.DalSito = enSiNo.Si OrElse (Not Mail.MailInizialeConversazione Is Nothing AndAlso Mail.MailInizialeConversazione.DalSito = enSiNo.Si) Then
                webPreview.Navigate("about:blank")
                webPreview.Document.OpenNew(False)
                webPreview.Document.Write(Mail.Testo)
                webPreview.Refresh()
                webPreview.Visible = True
                pnlPrezzo.Visible = True

                If Mail.DalSito = enSiNo.Si Then
                    lblPrezzoSuggerito.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Mail.PrezzoSuggerito)
                Else
                    lblPrezzoSuggerito.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Mail.MailInizialeConversazione.PrezzoSuggerito)
                End If
            Else
                txtPreview.Text = Mail.Testo
                webPreview.Visible = False
                pnlPrezzo.Visible = False
                lblPrezzoSuggerito.Text = "-"
            End If

            If Mail.IdUtFormer <> 0 And Mail.IdMailRif <> 0 Then
                txtPreview.Text &= ControlChars.NewLine & ControlChars.NewLine & ControlChars.NewLine &
                    "***************************************************************************************" & ControlChars.NewLine &
                    "In risposta a:" & ControlChars.NewLine &
                    "***************************************************************************************" & ControlChars.NewLine & ControlChars.NewLine &
                    Mail.MailRif.Testo
            End If

            'If mail.Letto = enSiNo.No Then
            '    mail.Letto = enSiNo.Si
            '    mail.Save()
            '    e.Node.NodeFont = New Font(e.Node.NodeFont, FontStyle.Regular)
            'End If

            If Mail.IdUtFormer Then
                Using U As New Utente
                    U.Read(Mail.IdUtFormer)
                    'lblMitt.Text = "Risposta di " & U.Login
                    lblMitt.Text = U.Login
                End Using
            Else
                If Mail.VoceRubrica Is Nothing Then
                    'lblMitt.Text = "Inviata da <" & Mail.Mittente & ">"
                    lblMitt.Text = "<" & Mail.Mittente & ">"
                Else
                    'lblMitt.Text = "Inviata da " & Mail.VoceRubrica.RagSocNome & " <" & Mail.Mittente & ">"
                    lblMitt.Text = Mail.VoceRubrica.RagSocNome '& " <" & Mail.Mittente & ">"
                End If
            End If

            lvwAllegati.Items.Clear()
            For Each alle As AttachPreventivoMail In Mail.Allegati
                Dim lv As New ListViewItem
                Dim ImgIndex As Integer = 0

                If alle.NomeFile.ToLower.EndsWith(".jpg") Then
                    ImgIndex = 2
                ElseIf alle.NomeFile.ToLower.EndsWith(".jpeg") Then
                    ImgIndex = 2
                ElseIf alle.NomeFile.ToLower.EndsWith(".png") Then
                    ImgIndex = 2
                ElseIf alle.NomeFile.ToLower.EndsWith(".zip") Then
                    ImgIndex = 0
                ElseIf alle.NomeFile.ToLower.EndsWith(".pdf") Then
                    ImgIndex = 1
                Else
                    ImgIndex = 3
                End If

                lv.ImageIndex = ImgIndex

                lv.Text = alle.NomeFile
                lv.Tag = alle.Path

                lvwAllegati.Items.Add(lv)
            Next

        Catch ex As Exception

        End Try

        Cursor = Cursors.Default

    End Sub

    Private Sub ApriAllegato()

        If lvwAllegati.SelectedItems.Count Then
            Dim path As String = lvwAllegati.SelectedItems(0).Tag

            FormerLib.FormerHelper.File.ShellExtended(path)

        End If

    End Sub

    Private Sub ApriCon()

        If lvwAllegati.SelectedItems.Count Then
            Dim path As String = lvwAllegati.SelectedItems(0).Tag

            FormerLib.FormerHelper.File.OpenWithDialog(path)

        End If

    End Sub



    Private Sub lvwAllegati_DoubleClick(sender As Object, e As EventArgs) Handles lvwAllegati.DoubleClick

        ApriAllegato()

    End Sub

    Private Sub ApriToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriToolStripMenuItem.Click

        ApriAllegato()

    End Sub

    Private Sub CopiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiaToolStripMenuItem.Click

        If lvwAllegati.SelectedItems.Count Then

            Dim path(0) As String
            path(0) = lvwAllegati.SelectedItems(0).Tag
            Dim d As New DataObject(DataFormats.FileDrop, path)
            Clipboard.Clear()
            Clipboard.SetDataObject(d, True)

        End If

    End Sub
    Private Sub pctSave_Click(sender As Object, e As EventArgs)

        If lvwAllegati.Items.Count Then

            Dim PathDest As String = String.Empty

            If dlgFolder.ShowDialog = DialogResult.OK Then
                PathDest = dlgFolder.SelectedPath & "\"

                For Each singItem As ListViewItem In lvwAllegati.Items
                    Dim path As String = singItem.Tag

                    MgrIO.FileCopia(Me.ParentFormEx, path, PathDest & FormerHelper.File.EstraiNomeFile(path))

                Next

            End If

        End If

    End Sub
    Private Sub CopiaPercorsoFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiaPercorsoFileToolStripMenuItem.Click
        If lvwAllegati.SelectedItems.Count Then

            Dim path As String
            path = lvwAllegati.SelectedItems(0).Tag
            Clipboard.Clear()
            Clipboard.SetText(path)

        End If
    End Sub

    Private Sub lvwAllegati_MouseUp(sender As Object, e As MouseEventArgs) Handles lvwAllegati.MouseUp

        If e.Button = MouseButtons.Right Then

            ' Go to the node that the user clicked
            Dim node As ListViewItem = lvwAllegati.GetItemAt(e.X, e.Y)
            If Not node Is Nothing Then

                lvwAllegati.SelectedItems.Clear()
                node.Selected = True

                mnuAllegato.Show(lvwAllegati, New Point(e.X, e.Y))

            End If

        End If

    End Sub

    Private Sub tlStrApriCon_Click(sender As Object, e As EventArgs) Handles tlStrApriCon.Click
        ApriCon()
    End Sub

    Private Sub lvwAllegati_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwAllegati.SelectedIndexChanged

    End Sub

    Private Sub lnkAllegati_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAllegati.LinkClicked
        If lvwAllegati.Items.Count Then

            Dim PathDest As String = String.Empty

            If dlgFolder.ShowDialog = DialogResult.OK Then
                PathDest = dlgFolder.SelectedPath & "\"

                For Each singItem As ListViewItem In lvwAllegati.Items
                    Dim path As String = singItem.Tag

                    MgrIO.FileCopia(Me.ParentFormEx, path, PathDest & FormerHelper.File.EstraiNomeFile(path))

                Next

            End If

        End If
    End Sub

    Private Sub lnkCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblMitt.LinkClicked

        If Mail.IdRub Then
            ParentFormEx.Sottofondo()
            Using f As New frmVoceRubrica
                f.Carica(Mail.IdRub)
            End Using
            ParentFormEx.Sottofondo()
        End If

    End Sub
End Class

