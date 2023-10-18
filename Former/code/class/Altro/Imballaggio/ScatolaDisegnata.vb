Public Class ScatolaDisegnata

    Public Property Lunghezza As Single = 0
    Public Property Larghezza As Single = 0
    Public Property Profondita As Single = 0
    Public Property OriginalLunghezza As Single = 0
    Public Property OriginalLarghezza As Single = 0
    Public Property OriginalProfondita As Single = 0

    Public Sub New(LunghezzaN As Single, LarghezzaN As Single, ProfonditaN As Single)

        OriginalLunghezza = LunghezzaN
        OriginalLarghezza = LarghezzaN
        OriginalProfondita = ProfonditaN

        Lunghezza = LunghezzaN / 2
        Larghezza = LarghezzaN / 2
        Profondita = ProfonditaN / 2

    End Sub

    Public Function DrawMe(ByRef formGraphics As System.Drawing.Graphics,
                     Optional StartX As Single = 100,
                     Optional StartY As Single = 200) As Point()

        Dim PointRet(3) As Point

        Dim myBrush As New System.Drawing.SolidBrush(ColorToTrasparent(Color.Red))
        Dim myBrushB As New System.Drawing.SolidBrush(ColorToTrasparent(Color.Purple))
        Dim myBrushLc As New System.Drawing.SolidBrush(ColorToTrasparent(Color.Brown))

        'Dim myBrush As New System.Drawing.SolidBrush(ColorToTrasparent(System.Drawing.Color.FromArgb(141, 113, 67)))
        'Dim myBrushB As New System.Drawing.SolidBrush(ColorToTrasparent(System.Drawing.Color.FromArgb(110, 83, 44)))
        'Dim myBrushLc As New System.Drawing.SolidBrush(ColorToTrasparent(System.Drawing.Color.FromArgb(68, 47, 17)))

        Dim MargX As Single = StartX
        Dim MargY As Single = StartY
        Dim LatoLungo As Single = Math.Sqrt((Lunghezza ^ 2) + (Larghezza ^ 2))

        Dim Points(3) As Point
        Points(0).X = MargX
        Points(0).Y = MargY

        Points(1).X = MargX + Larghezza
        Points(1).Y = MargY - (Lunghezza / 2)

        Points(2).X = MargX + (Lunghezza * 2)
        Points(2).Y = MargY

        Points(3).X = MargX + Points(2).X - Points(1).X
        Points(3).Y = MargY + (Lunghezza / 2)

        Dim PointsFacciata(3) As Point
        PointsFacciata(0).X = Points(3).X
        PointsFacciata(0).Y = Points(3).Y

        PointsFacciata(1).X = Points(2).X
        PointsFacciata(1).Y = Points(2).Y

        PointsFacciata(2).X = Points(2).X
        PointsFacciata(2).Y = Points(2).Y + Profondita

        PointsFacciata(3).X = Points(3).X
        PointsFacciata(3).Y = Points(3).Y + Profondita

        Dim PointsLatoCorto(3) As Point
        PointsLatoCorto(0).X = Points(3).X
        PointsLatoCorto(0).Y = Points(3).Y

        PointsLatoCorto(1).X = Points(0).X
        PointsLatoCorto(1).Y = Points(0).Y

        PointsLatoCorto(2).X = Points(0).X
        PointsLatoCorto(2).Y = Points(0).Y + Profondita

        PointsLatoCorto(3).X = Points(3).X
        PointsLatoCorto(3).Y = Points(3).Y + Profondita

        formGraphics.FillPolygon(myBrush, Points)
        formGraphics.FillPolygon(myBrushB, PointsFacciata)
        formGraphics.FillPolygon(myBrushLc, PointsLatoCorto)

        Dim PartX As Single = ((Points(1).X - Points(0).X) / 2) + Points(0).X
        Dim PartY As Single = ((Points(0).Y - Points(1).Y) / 2) + Points(1).Y
        formGraphics.DrawString(OriginalLarghezza, New Font("Segoe UI", 12), New Drawing.SolidBrush(Color.Black), New Point(PartX, PartY))

        PartX = ((Points(2).X - Points(1).X) / 2) + Points(1).X
        PartY = ((Points(2).Y - Points(1).Y) / 2) + Points(1).Y
        formGraphics.DrawString(OriginalLunghezza, New Font("Segoe UI", 12), New Drawing.SolidBrush(Color.Black), New Point(PartX, PartY))

        PartX = Points(2).X - 10
        PartY = ((PointsFacciata(2).Y - Points(2).Y) / 2) + Points(2).Y
        formGraphics.DrawString(OriginalProfondita, New Font("Segoe UI", 12), New Drawing.SolidBrush(Color.Black), New Point(PartX, PartY))

        myBrush.Dispose()

        'Cioli_Graphic.PoligonoRegolare(formGraphics, Mypen, 200, 4, 100, 100, 30)

        'formGraphics.Dispose()

        Return Points

    End Function

    Private Function ColorToTrasparent(Colore As Color) As Color
        Return Color.FromArgb(128, Colore.R, Colore.G, Colore.B)
    End Function

End Class
