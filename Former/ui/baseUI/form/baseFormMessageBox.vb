Imports System.Windows.Forms

Public Class baseFormMessageBox

    Private _Ris As System.Windows.Forms.DialogResult

    Public Overloads Function Show(Message As String,
                                   Optional Caption As String = "",
                                   Optional Buttons As System.Windows.Forms.MessageBoxButtons = MessageBoxButtons.OK,
                                   Optional Icon As System.Windows.Forms.MessageBoxIcon = MessageBoxIcon.Exclamation) As System.Windows.Forms.DialogResult
        Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (Height / 2)
        Left = 0
        Width = Screen.PrimaryScreen.WorkingArea.Width
        Dim maxSize As New Drawing.Size(Width - 80, 0)
        lblMessage.MaximumSize = maxSize
        lblMessage.Text = Message

        If Icon = MessageBoxIcon.Question Then
            pctMsg.Image = My.Resources.question_shield_48
        End If

        If Buttons = MessageBoxButtons.OKCancel Then
            pnlOk.Visible = False
            PnlSiNo.Visible = False
            pnlConfirmCancel.Visible = True
            'pnlConfirmCancel.Left = pnlOk.Left
        ElseIf Buttons = MessageBoxButtons.YesNo Then
            pnlOk.Visible = False
            pnlConfirmCancel.Visible = False
            PnlSiNo.Visible = True
            'PnlSiNo.Left = pnlOk.Left
        ElseIf Buttons = MessageBoxButtons.YesNoCancel Then
            pnlOk.Visible = False
            pnlConfirmCancel.Visible = False
            PnlSiNo.Visible = True
            'PnlSiNo.Left = pnlOk.Left
        Else
            Beep()
        End If

        ShowDialog()
        Return _Ris
    End Function

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        _Ris = DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        _Ris = DialogResult.Cancel
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConferma.Click
        _Ris = DialogResult.OK
        Close()
    End Sub

    Private Sub btnSi_Click(sender As Object, e As EventArgs) Handles btnSi.Click
        _Ris = Windows.Forms.DialogResult.Yes
        Close()
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        _Ris = Windows.Forms.DialogResult.No
        Close()
    End Sub

    Private Sub lblMessage_Click(sender As Object, e As EventArgs) Handles lblMessage.Click

    End Sub

    Private Sub lblMessage_Resize(sender As Object, e As EventArgs) Handles lblMessage.Resize
        Try
            If lblMessage.Height > 60 Then
                Dim diff As Integer = lblMessage.Height - 60
                Me.Height += diff
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmBaseForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F10 Then

            Using f As New frmBug
                f.Carica(Me)
            End Using
        ElseIf e.KeyCode = Keys.F12 Then
            Using f As New frmScreenShoot
                f.Carica(Me)
            End Using
        End If

    End Sub

End Class