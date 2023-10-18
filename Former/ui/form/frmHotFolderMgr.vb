Imports FormerDALSql

Friend Class frmHotFolderMgr
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        CaricaHotFolder()

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

    Private Sub lnkAdd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAdd.LinkClicked

        Sottofondo()
        Dim ris As Integer = 0

        Using f As New frmHotFolder
            ris = f.Carica
        End Using
        Sottofondo()

        If ris Then CaricaHotFolder()

    End Sub

    Private Sub CaricaHotFolder()

        Using mgr As New HotFolderDAO
            Dim l As List(Of HotFolder) = mgr.GetAll(LFM.HotFolder.Nome)

            dgHotFolder.AutoGenerateColumns = False
            dgHotFolder.DataSource = l

        End Using

    End Sub

    Private Sub lnkMod_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMod.LinkClicked

        If dgHotFolder.SelectedRows.Count Then
            Dim H As HotFolder = dgHotFolder.SelectedRows(0).DataBoundItem

            Sottofondo()
            Dim ris As Integer = 0

            Using f As New frmHotFolder
                ris = f.Carica(H)
            End Using
            Sottofondo()

            If ris Then CaricaHotFolder()

        Else
            Beep()

        End If

    End Sub

    Private Sub lnkDel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDel.LinkClicked

        If dgHotFolder.SelectedRows.Count Then
            Dim H As HotFolder = dgHotFolder.SelectedRows(0).DataBoundItem
            If MessageBox.Show("Confermi la cancellazione dell'HotFolder selezionato? L'operazione non è reversibile. L'HotFolder sarà eliminato anche da tutti i listinibase a lui collegati", "Cancellazione HotFolder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Using mgr As New HotFolderDAO
                    mgr.ResetListiniBaseByIdHotFolder(H.IdHotFolder)
                    mgr.Delete(H.IdHotFolder)
                End Using
                CaricaHotFolder()

            End If
        End If



    End Sub
End Class