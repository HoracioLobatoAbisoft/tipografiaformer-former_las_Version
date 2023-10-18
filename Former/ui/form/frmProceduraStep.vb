Imports FormerDALSql

Friend Class frmProceduraStep
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _IdProcedura As Integer = 0
    Private _IdStep As Integer = 0
    Friend Function Carica(IdProcedura As Integer,
                           Optional IdStep As Integer = 0) As Integer

        _IdProcedura = IdProcedura
        _IdStep = IdStep

        If IdStep Then
            Using S As New StepProcedura
                S.Read(_IdStep)

                txtTitolo.Text = S.Titolo
                txtDescrizione.Text = S.Testo

                If S.FilePath.Length Then
                    txtImg.Text = S.FilePath
                    Try
                        pctImg.Image = Image.FromFile(S.FilePath)
                    Catch ex As Exception

                    End Try
                End If

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

        If MessageBox.Show("Confermi il salvataggio dello Step?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Using Mgr As New ProcedureDAO
                    Using S As New StepProcedura
                        If _IdStep Then S.Read(_IdStep)
                        S.IdProcedura = _IdProcedura
                        S.Titolo = txtTitolo.Text
                        S.Testo = txtDescrizione.Text
                        S.Ordine = Mgr.GetNextOrdine(_IdProcedura)
                        S.Save()

                        S.FilePath = txtImg.Text
                        If S.FilePath.Length <> 0 AndAlso S.FilePath.StartsWith(FormerConfig.FormerPath.PathProcedure) = False Then
                            Dim NewPath As String = FormerConfig.FormerPath.PathProcedure & "img\" & S.IdStep & "-" & FormerLib.FormerHelper.File.EstraiNomeFile(S.FilePath)
                            FileCopy(S.FilePath, NewPath)
                            S.FilePath = NewPath
                        End If
                        S.Save()

                    End Using
                End Using

                _Ris = 1
                Close()

            Catch ex As Exception
                ManageError(ex)
            End Try

        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImg.Text = OpenFileImg.FileName
            pctImg.Image = Image.FromFile(txtImg.Text)
        End If
    End Sub

End Class