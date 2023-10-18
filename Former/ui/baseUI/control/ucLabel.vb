Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ucLabel
    Inherits Label
    Implements IRoundedControl

    Private _T As Timer = Nothing

    Public Sub StartBlink()

        _T = New Timer
        _T.Interval = 1000

        AddHandler _T.Tick, AddressOf Blink
        _T.Start()

    End Sub

    Public Sub StopBlink()

        _T.Stop()
        _T = Nothing

    End Sub

    Public Sub Blink()
        If Visible Then
            Visible = False
        Else
            Visible = True
        End If

    End Sub

    Public Property RoundedBorder As Boolean Implements IRoundedControl.RoundedBorder

    Private Sub lblCreataAutomatico_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        MgrRoundedControl.RePaint(Me, e)
    End Sub


End Class
