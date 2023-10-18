Imports System.Windows.Forms

Public Class frmWait

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmWait_Load(sender As Object, e As EventArgs) Handles Me.Load
        WaitingBar.ShowText = True
        WaitingBar.Text = ""
        WaitingBar.StartWaiting()
    End Sub

    Public Sub SetLabel(Text As String)

        lblMessage.Text = Text

    End Sub

    Private _Valore As Integer = 0

    Private Sub tmrWait_Tick(sender As Object, e As EventArgs) Handles tmrWait.Tick

        _Valore += 1
        WaitingBar.Text = _Valore & " secondi"

    End Sub

    'Public Sub Carica()
    '    'tmrAvvio.Enabled = True
    '    Show()
    '    WaitingBar.StartWaiting()

    'End Sub

    'Public Sub Scarica()
    '    WaitingBar.StopWaiting()
    '    Hide()
    '    Close()

    'End Sub

    'Private Sub tmrAvvio_Tick(sender As Object, e As EventArgs) Handles tmrAvvio.Tick

    '    'tmrAvvio.Enabled = False
    '    _Valore += 1
    '    'Application.DoEvents()

    '    progressAvvio.Value1 = _Valore

    '    'Me.Refresh()
    '    'Application.DoEvents()

    '    'If _Valore = progressAvvio.Maximum Then
    '    '    Scarica()
    '    '    'Else
    '    '    '   tmrAvvio.Enabled = True
    '    'End If

    'End Sub

End Class
