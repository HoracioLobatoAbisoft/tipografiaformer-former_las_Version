Imports FormerDALSql

Friend Class frmHotFolder
    'Inherits baseFormInternaFixed

    Private _Ris As Integer
    Private _Id As Integer = 0

    Friend Function Carica(H As HotFolder) As Integer
        _Id = H.IdHotFolder
        txtNome.Text = H.Nome
        txtPath.Text = H.Path
        ShowDialog()

        Return _Ris
    End Function

    Friend Function Carica(Optional Id As Integer = 0) As Integer
        _Id = Id

        If _Id Then
            Using H As New HotFolder
                H.Read(_Id)
                txtNome.Text = H.Nome
                txtPath.Text = H.Path
            End Using

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
        Dim ErrBuff As String = String.Empty

        If txtNome.Text.Trim.Length = 0 Then
            ErrBuff = "Inserire un nome" & ControlChars.NewLine
        End If

        If txtPath.Text.Trim.Length = 0 Then
            ErrBuff &= "Inserire un nome"
        End If

        If ErrBuff.Length = 0 Then
            If MessageBox.Show("Confermi il salvataggio?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Using H As New HotFolder
                    H.Read(_Id)
                    H.Nome = txtNome.Text
                    H.Path = txtPath.Text
                    H.Save()
                End Using

                _Ris = 1
                Close()

            End If
        Else
            MessageBox.Show(ErrBuff)
        End If


    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim Ris As String = String.Empty
        If txtPath.Text.Trim.Length Then dlgFolder.SelectedPath = txtPath.Text
        If dlgFolder.ShowDialog = DialogResult.OK Then

            Ris = dlgFolder.SelectedPath
            txtPath.Text = Ris
        End If



    End Sub
End Class