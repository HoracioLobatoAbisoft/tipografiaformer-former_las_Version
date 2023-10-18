Imports System.Drawing
Imports System.Drawing.Imaging
Imports CsPotrace
Imports System.IO

Public Class FormerGraphicsEngine

    Public Class ColorImgTools

        Public Shared Sub GetColorPointFromBitmap(ByRef bmp As Bitmap, _
                                                  ByRef ListaColoriDisponibili As List(Of ColoreImg), _
                                                  Optional ColoreDaEscludere As Color = Nothing)

            If ColoreDaEscludere = Nothing Then ColoreDaEscludere = Color.White

            For x = 0 To bmp.Width - 1 'Pixels start with 0 so we need Height - 1 

                For y = 0 To bmp.Height - 1
                    Dim p As Color = bmp.GetPixel(x, y)

                    With p
                        If p <> ColoreDaEscludere Then

                            Dim ColoreTrovato As ColoreImg = ListaColoriDisponibili.Find(Function(xxx) xxx.R = p.R And xxx.B = p.B And xxx.G = p.G)
                            ColoreTrovato.Punti.Add(New Point(x, y))

                        End If
                    End With
                Next
            Next

        End Sub

    End Class

    Public Class JPGTools

        ' Saves an image as a jpeg image, with the given quality 
        ' Gets:
        '   path   - Path to which the image would be saved.
        '   quality - An integer from 0 to 100, with 100 being the 
        '           highest quality
        ' Written by Kourosh Derakshan 
        ' 
        Public Shared Sub OttimizzaJpeg(ByVal path As String, ByVal img As Image, ByVal quality As Long)
            If ((quality < 0) OrElse (quality > 100)) Then
                Throw New ArgumentOutOfRangeException("quality must be between 0 and 100.")
            End If

            ' Encoder parameter for image quality
            Dim qualityParam As New EncoderParameter(Encoder.Quality, quality)
            ' Jpeg image codec 
            Dim jpegCodec As ImageCodecInfo = GetEncoderInfo("image/jpeg")

            Dim encoderParams As New EncoderParameters(1)
            encoderParams.Param(0) = qualityParam
            img.Save(path, jpegCodec, encoderParams)
        End Sub

        ' Returns the image codec with the given mime type 
        Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
            ' Get image codecs for all image formats 
            ' Written by Kourosh Derakshan 
            ' 
            Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()

            ' Find the correct image codec 
            For i As Integer = 0 To codecs.Length - 1
                If (codecs(i).MimeType = mimeType) Then
                    Return codecs(i)
                End If
            Next i

            Return Nothing
        End Function

    End Class

    Public Class SVGTools

        Public Shared Function GetHTMLFromSVG(Buffer As String, _
                                          dimW As Integer, _
                                          dimH As Integer) As String

            Dim ris As String = String.Empty

            ris = "<svg width=""" & dimW & """ height=""" & dimH & """>" & ControlChars.NewLine
            ris &= Buffer
            ris &= "</svg>" & ControlChars.NewLine

            Return ris

        End Function

        Public Shared Sub SaveBufferToSVG(Buffer As String, _
                                          dimW As Integer, _
                                          dimH As Integer, _
                                          PathOutput As String)
            If Buffer.Length Then
                Dim head As String = "<?xml version=""1.0"" standalone=""no""?>" & ControlChars.NewLine

                head &= "<!DOCTYPE svg PUBLIC ""-//W3C//DTD SVG 20010904//EN"" " & ControlChars.NewLine
                head &= """http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd"">" & ControlChars.NewLine
                head &= "<svg version=""1.0"" xmlns=""http://www.w3.org/2000/svg"" preserveAspectRatio=""xMidYMid meet""" & ControlChars.NewLine
                head &= "width=""" & dimW & """ height=""" & dimH & """  viewBox=""0 0 " & dimW & " " & dimH & """ > " & ControlChars.NewLine
                head &= "<g>" & ControlChars.NewLine

                Dim footer As String = "</g>" & ControlChars.NewLine & "</svg>"

                Buffer = head & Buffer & footer

                Using w As New StreamWriter(PathOutput, False)
                    w.Write(Buffer)
                End Using
            End If
        End Sub

        Public Shared Function EsportaBMPToSVG(bmOrig As Bitmap) As String

            Dim ris As String = String.Empty

            Dim Matrix As Boolean(,)
            Dim ListOfCurveArray As ArrayList
            ListOfCurveArray = New ArrayList
            Potrace.turdsize = 16
            Potrace.alphamax = 1
            Potrace.opttolerance = 0.2
            Potrace.curveoptimizing = True
            Matrix = Potrace.BitMapToBinary(bmOrig, 128)
            Potrace.potrace_trace(Matrix, ListOfCurveArray)

            ris = Potrace.Export2SVG(ListOfCurveArray, bmOrig.Width, bmOrig.Height, False)

            Return ris

        End Function

    End Class

    Public Class MiscTools

        Public Shared Function GetColoreBase(C As Color) As Color
            Dim ris As Color
            Dim VecchiaDiff As Double = 1000000000000


            For Each ColoreBase As ColoreEx In ColoriPrimari.ListaColoriEx


                Dim distance As Double = Math.Sqrt(((C.R - CInt(ColoreBase.Colore.R))) ^ 2 + _
                                               ((C.G - CInt(ColoreBase.Colore.G))) ^ 2 + _
                                               ((C.B - CInt(ColoreBase.Colore.B))) ^ 2)

                If distance <= VecchiaDiff Then
                    VecchiaDiff = distance
                    ris = ColoreBase.Colore
                    'If distance = 0 Then Exit For
                End If

            Next

            Return ris
        End Function

    End Class

    Public Class BitmapTools

        Public Shared Property SogliaMinimaColore() As Integer

        Private Shared Sub Riadatta(ByRef Ris As RisLavorazioneImg, lColorPrimari As List(Of ColoreEx))
            Ris.ListaColoriUtilizzati.Clear()
            Ris.ListaColoriPresenti.Clear()
            Ris.NumeroPixel = 0
            Dim xmax As Integer = Ris.ImgRis.Width - 1
            Dim ymax As Integer = Ris.ImgRis.Height - 1

            For y = 0 To ymax
                For x = 0 To xmax

                    Dim singoloPixel As Color = Ris.ImgRis.GetPixel(x, y)

                    With singoloPixel
                        If .R <> 255 Or .G <> 255 Or .B <> 255 Then
                            Ris.NumeroPixel += 1
                            If Ris.ListaColoriPresenti.Find(Function(sx) sx.R = .R And sx.G = .G And sx.B = .B) = Nothing Then
                                Ris.ListaColoriPresenti.Add(Color.FromArgb(.R, .G, .B))
                            End If

                            Dim VecchiaDiff As Integer = 100000000
                            Dim ColoreTrovato As ColoreEx = Nothing

                            For Each colorepre In lColorPrimari

                                Dim diff As Double = Math.Sqrt(((CInt(.R) - CInt(colorepre.Colore.R))) ^ 2 + _
                                                               ((CInt(.G) - CInt(colorepre.Colore.G))) ^ 2 + _
                                                               ((CInt(.B) - CInt(colorepre.Colore.B))) ^ 2)

                                'Dim diff As Double = ((Math.Abs(CInt(.R) - CInt(colorepre.Colore.R))) + _
                                '                               Math.Abs((CInt(.G) - CInt(colorepre.Colore.G))) + _
                                '                               Math.Abs((CInt(.B) - CInt(colorepre.Colore.B)))) / 3


                                If diff <= VecchiaDiff Then
                                    VecchiaDiff = diff
                                    ColoreTrovato = colorepre
                                End If

                            Next

                            ' If Not ColoreTrovato Is Nothing Then
                            Dim ColoreGiaUsato As ColoreEx = Ris.ListaColoriUtilizzati.Find(Function(xx) xx.Colore.R = ColoreTrovato.Colore.R And xx.Colore.G = ColoreTrovato.Colore.G And xx.Colore.B = ColoreTrovato.Colore.B)

                            If ColoreGiaUsato Is Nothing Then
                                ColoreTrovato.NumeroPixel = 1
                                Ris.ListaColoriUtilizzati.Add(ColoreTrovato)

                            Else
                                ColoreGiaUsato.NumeroPixel += 1
                            End If

                            'Counter += 1
                            Ris.ImgRis.SetPixel(x, y, ColoreTrovato.Colore)

                            '                    End If

                        End If
                    End With
                Next x
            Next y


        End Sub

        Public Shared Function RedimBitmapProportionally(bm As Bitmap, Optional LatoLungoMax As Integer = 512) As Bitmap

            Dim dimW As Integer = 0
            Dim dimH As Integer = 0

            If bm.Width > bm.Height Then
                dimW = LatoLungoMax
                dimH = bm.Height * LatoLungoMax / bm.Width

            ElseIf bm.Height > bm.Width Then
                dimH = LatoLungoMax
                dimW = bm.Width * LatoLungoMax / bm.Height
            Else
                dimH = LatoLungoMax
                dimW = LatoLungoMax
            End If

            Dim bmpRis As New Bitmap(dimW, dimH)
            'RIATTIVARE
            Dim grN As Graphics = Graphics.FromImage(bmpRis)

            grN.DrawImage(bm, 0, 0, dimW, dimH)

            grN.Dispose()
            grN = Nothing

            Return bmpRis

        End Function

        Public Shared Function BitmapTo8bpp(bm As Bitmap) As Bitmap

            Dim r1 As Rectangle = New Rectangle(0, 0, bm.Width, bm.Height) ' bm.Width, bm.Height)
            Dim ris As Bitmap = bm.Clone(r1, PixelFormat.Format8bppIndexed)

            Return ris

        End Function

    End Class

    Public Class Thumbnail

        ' Orientations.
        Public Const OrientationId As Integer = &H112
        Public Enum ExifOrientations As Byte
            Unknown = 0
            TopLeft = 1
            TopRight = 2
            BottomRight = 3
            BottomLeft = 4
            LeftTop = 5
            RightTop = 6
            RightBottom = 7
            LeftBottom = 8
        End Enum

        Public Shared Function GetThumbnail(nomefile As String, lato As Integer, Optional Newfile As String = "", Optional Watermark As Boolean = False, Optional Quadrata As Boolean = True) As Image

            Dim i As Image
            i = New Bitmap(nomefile)

            'Dim wm As Image
            'wm = My.Resources.waterM

            Dim piuma As Image
            'piuma = My.Resources.bg_thumb

            Dim orientamento As Integer

            orientamento = ImageOrientation(i)

            Dim altezza As Integer = i.Height
            Dim larghezza As Integer = i.Width
            Dim nuovaaltezza As Integer
            Dim nuovalarghezza As Integer
            Dim margx As Integer = 0
            Dim margy As Integer = 0

            If altezza > larghezza Then
                nuovaaltezza = lato
                nuovalarghezza = lato * larghezza / altezza
                margx = (lato - nuovalarghezza) / 2
            Else
                nuovalarghezza = lato
                nuovaaltezza = lato * altezza / larghezza
                margy = (lato - nuovaaltezza) / 2
            End If

            Dim nuovaimmagine As Image

            If Quadrata Then
                nuovaimmagine = New Bitmap(lato, lato, i.PixelFormat)
            Else
                nuovaimmagine = New Bitmap(nuovalarghezza, nuovaaltezza, i.PixelFormat)
                margx = 0
                margy = 0
            End If

            Dim g As Graphics
            g = Graphics.FromImage(nuovaimmagine)

            With g
                .CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
                .InterpolationMode = Drawing2D.InterpolationMode.Default
                .SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            End With

            'ruoto lo sfondo se la foto che incollerò è ruotata
            If orientamento = ExifOrientations.LeftBottom Then
                piuma.RotateFlip(RotateFlipType.Rotate90FlipNone)
            ElseIf orientamento = ExifOrientations.RightTop Then
                piuma.RotateFlip(RotateFlipType.Rotate180FlipNone)
            End If

            'incollo lo sfondo
            If Quadrata Then g.DrawImage(piuma, 0, 0, lato, lato)

            'incollo l'immagine
            g.DrawImage(i, margx, margy, nuovalarghezza, nuovaaltezza)


            'MsgBox(orientamento)
            'ruoto l'immagine 
            If orientamento = ExifOrientations.LeftBottom Then
                nuovaimmagine.RotateFlip(RotateFlipType.Rotate270FlipNone)
            ElseIf orientamento = ExifOrientations.RightTop Then
                nuovaimmagine.RotateFlip(RotateFlipType.Rotate90FlipNone)
                'le altre possibilità non le metto, tipo macchina capovolta
            End If

            'scrivo il watermark
            'If Watermark Then
            '    Dim NewDim As Integer = CInt(nuovalarghezza / 8)
            '    If NewDim < 80 Then NewDim = 80
            '    g.DrawImage(wm, 10, 10, NewDim, NewDim)
            'End If

            g.Dispose()
            i.Dispose()
            'wm.Dispose()
            'piuma.Dispose()

            'nuovaimmagine.Save(NewFile, Imaging.ImageFormat.Jpeg)
            'SaveJpeg(NewFile, nuovaimmagine, 90)
            'nuovaimmagine.Dispose()
            Return nuovaimmagine
        End Function

        ' Return the image's orientation.
        Private Shared Function ImageOrientation(ByVal img As Image) As ExifOrientations
            ' Get the index of the orientation property.
            Dim orientation_index As Integer = Array.IndexOf(img.PropertyIdList, OrientationId)

            ' If there is no such property, return Unknown.
            If (orientation_index < 0) Then Return ExifOrientations.Unknown

            ' Return the orientation value.
            Return DirectCast(img.GetPropertyItem(OrientationId).Value(0), ExifOrientations)
        End Function





    End Class

End Class
