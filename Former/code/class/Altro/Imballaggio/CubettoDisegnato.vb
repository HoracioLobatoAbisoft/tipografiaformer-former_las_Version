Public Class CubettoDisegnato
    Public Property Lunghezza As Single
    Public Property Larghezza As Single
    Public Property Profondita As Single

    Public Sub New(LunghezzaN As Single, LarghezzaN As Single, ProfonditaN As Single)

        Lunghezza = LunghezzaN / 2
        Larghezza = LarghezzaN / 2
        Profondita = ProfonditaN / 2

    End Sub

    Public Function DrawMe(ByRef formGraphics As System.Drawing.Graphics,
                      Optional StartX As Single = 100,
                      Optional StartY As Single = 200) As Point()

        Dim PointRet(3) As Point

        Dim myBrush As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(141, 113, 67))
        Dim myBrushB As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(110, 83, 44))
        Dim myBrushLc As New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(68, 47, 17))

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


        myBrush.Dispose()

        'Cioli_Graphic.PoligonoRegolare(formGraphics, Mypen, 200, 4, 100, 100, 30)

        'formGraphics.Dispose()

        Return Points

    End Function

End Class
