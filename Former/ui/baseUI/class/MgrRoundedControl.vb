Imports System.Drawing.Drawing2D

Public Class MgrRoundedControl

    Private Shared _radius As Int32 = 20     'Radius of the Corner Curve
    Private Shared _opacity As Int32 = 100   'Opacity of the Control

    Public Shared Sub RePaint(Sender As Object, e As PaintEventArgs)
        If Sender.RoundedBorder Then
            Dim rect As Rectangle = Sender.ClientRectangle 'Drawing Rounded Rectangle
            rect.X = rect.X + 1
            rect.Y = rect.Y + 1
            rect.Width -= 2
            rect.Height -= 2
            Using bb As GraphicsPath = GetPath(rect, _radius)
                Using br As Brush = New SolidBrush(Color.FromArgb(_opacity, Sender.BackColor))
                    e.Graphics.FillPath(br, bb)
                End Using
            End Using
        End If
    End Sub

    Protected Shared Function GetPath(ByVal rc As Rectangle, ByVal r As Int32) As GraphicsPath
        Dim x As Int32 = rc.X, y As Int32 = rc.Y, w As Int32 = rc.Width, h As Int32 = rc.Height
        r = r << 1
        Dim path As GraphicsPath = New GraphicsPath()
        If r > 0 Then
            If (r > h) Then r = h
            If (r > w) Then r = w
            path.AddArc(x, y, r, r, 180, 90)
            path.AddArc(x + w - r, y, r, r, 270, 90)
            path.AddArc(x + w - r, y + h - r, r, r, 0, 90)
            path.AddArc(x, y + h - r, r, r, 90, 90)
            path.CloseFigure()
        Else
            path.AddRectangle(rc)
        End If
        Return path
    End Function


End Class
