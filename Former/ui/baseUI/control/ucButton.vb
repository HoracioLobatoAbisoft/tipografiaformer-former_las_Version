Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports FormerLib.FormerEnum

Public Class ucButton
    Inherits Button

    Public Sub New()



    End Sub

    Private Function GetRoundPath(Rect As RectangleF) As GraphicsPath
        Dim r2 As Single = Radius / 2.0F
        Dim GraphPath As New GraphicsPath()

        GraphPath.AddArc(Rect.X, Rect.Y, Radius, Radius, 180, 90)
        GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y)
        GraphPath.AddArc(Rect.X + Rect.Width - Radius, Rect.Y, Radius, Radius, 270, 90)
        GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2)
        GraphPath.AddArc(Rect.X + Rect.Width - Radius, Rect.Y + Rect.Height - Radius, Radius, Radius, 0, 90)
        GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height)
        GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - Radius, Radius, Radius, 90, 90)
        GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2)

        GraphPath.CloseFigure()
        Return GraphPath
    End Function

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        If _RoundedButton Then
            Dim Rect As New RectangleF(0, 0, Me.Width, Me.Height)
            Dim GraphPath As GraphicsPath = GetRoundPath(Rect)

            Me.Region = New Region(GraphPath)
            Using pen As New Pen(BackColor, 2)
                pen.Alignment = PenAlignment.Inset
                e.Graphics.DrawPath(pen, GraphPath)
            End Using
        End If

    End Sub

    Public Property Radius As Integer = 5
    Private _RoundedButton As Boolean = False
    Public Property RoundedButton As Boolean
        Get
            Return _RoundedButton
        End Get
        Set(value As Boolean)

            If value Then
                FlatStyle = FlatStyle.Flat
            End If
            _RoundedButton = value
        End Set
    End Property

End Class
