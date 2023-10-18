Imports FormerDALSql
Imports FormerLib.FormerEnum
Public Class ucCommesseAnteprima
    Inherits ucFormerUserControl

    Private _Com As Commessa

    Friend Property Com() As Commessa
        Get
            Return _Com
        End Get
        Set(ByVal value As Commessa)
            _Com = value
        End Set
    End Property

    Public Sub Carica(ByVal IdCom As Integer)

        Dim x As New Commessa
        x.Read(IdCom)
        _Com = x

        CreaAnteprima()

        'carico i sorgenti
        lvwAllegati.Items.Clear()
        For Each O As Ordine In _Com.ListaOrdini
            For Each S As FileSorgente In O.ListaSorgenti
                Dim lv As New ListViewItem

                lv.ImageIndex = 1
                lv.Text = FormerLib.FormerHelper.File.EstraiNomeFile(S.FilePath)
                lv.Tag = S.FilePath

                lvwAllegati.Items.Add(lv)
            Next
        Next

    End Sub
    Private Sub lvwAllegati_MouseUp(sender As Object, e As MouseEventArgs) Handles lvwAllegati.MouseUp

        If e.Button = MouseButtons.Right Then

            ' Go to the node that the user clicked
            Dim node As ListViewItem = lvwAllegati.GetItemAt(e.X, e.Y)
            If Not node Is Nothing Then

                lvwAllegati.SelectedItems.Clear()
                node.Selected = True

                mnuAllegato.Show(lvwAllegati, New Point(e.X + 10, e.Y))

            End If

        End If

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
    Private Sub tlStrApriCon_Click(sender As Object, e As EventArgs) Handles tlStrApriCon.Click
        ApriCon()
    End Sub

    Private Sub CopiaPercorsoFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiaPercorsoFileToolStripMenuItem.Click
        If lvwAllegati.SelectedItems.Count Then

            Dim path As String
            path = lvwAllegati.SelectedItems(0).Tag
            Clipboard.Clear()
            Clipboard.SetText(path)

        End If
    End Sub

    Friend Sub Carica(ByVal Com As Commessa)

        _Com = Com

        CreaAnteprima()

    End Sub

    Private Sub CreaAnteprima()

        Try

            If Not _Com Is Nothing Then

                MgrAnteprime.CreaRiepilogoCom(_Com, WebPreview, enTipoAnteprima.Breve)
                System.Threading.Thread.Sleep(100)
                Application.DoEvents()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public ReadOnly Property WebPrew() As System.Windows.Forms.WebBrowser
        Get
            Return WebPreview
        End Get
    End Property

End Class
