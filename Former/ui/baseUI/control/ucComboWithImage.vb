Imports System.Drawing
Imports System.Windows.Forms
Imports FormerLib

Public Class ucComboWithImage
    Inherits ComboBox

    Private mWidth As Integer = 80
    Private mHeight As Integer = 60

    Public Property WidthImg As Integer
        Get
            Return mWidth
        End Get
        Set(value As Integer)
            mWidth = value
        End Set
    End Property

    Public Property HeightImg As Integer
        Get
            Return mHeight
        End Get
        Set(value As Integer)
            mHeight = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        DrawMode = DrawMode.OwnerDrawVariable
        'Set the DrawMode to OwnerDraw
        DropDownStyle = ComboBoxStyle.DropDownList
        ItemHeight = mHeight
        DropDownHeight = 500
        'IntegralHeight = True
    End Sub

    Protected Overrides Sub OnMeasureItem(e As Windows.Forms.MeasureItemEventArgs)
        Try
            Dim g As Graphics = CreateGraphics()
            Dim maxWidth = 0
            For Each item As Object In Items
                Try
                    Dim larghezza As Single = g.MeasureString(item.ToString(), Font).Width
                    If larghezza > maxWidth Then
                        maxWidth = larghezza
                    End If
                Catch ex As Exception

                End Try

            Next
            DropDownWidth = maxWidth + 200
        Catch ex As Exception

        End Try

    End Sub

    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Try
            e.DrawBackground()
            'e.DrawFocusRectangle()
            If e.Index <> -1 Then
                Dim item As IVoceComboConImmagine
                item = Me.Items(e.Index)

                'If item.Image Is Nothing Then
                Dim imageSize As New Size(mWidth, mHeight)

                Dim bounds As New Rectangle(e.Bounds.X, e.Bounds.Y, 500, e.Bounds.Height)
                'bounds = e.Bounds

                If Not item.Image Is Nothing Then e.Graphics.DrawImage(item.Image, bounds.Left, bounds.Top, mWidth, mHeight)
                Dim F As New Font("Segoe UI", 11, FontStyle.Bold)

                e.Graphics.DrawString(item.Text, F,
                                    New SolidBrush(e.ForeColor), mWidth + 2,
                                    bounds.Top)
                Dim FD As New Font("Segoe UI", 8, FontStyle.Italic)
                e.Graphics.DrawString(item.Description, FD,
                                      New SolidBrush(e.ForeColor), mWidth + 2,
                                      bounds.Top + F.Height)


                'item = Nothing
                e.DrawFocusRectangle()
                'End If
                MyBase.OnDrawItem(e)
            End If
        Catch ex As Exception
            ' Stop
            'in queste condizioni
        End Try
    End Sub


End Class

