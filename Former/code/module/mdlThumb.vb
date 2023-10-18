Imports System.Drawing
Imports System.IO
'Imports System.Web.HttpServerUtility
Imports System.Drawing.Imaging
Namespace Grafica
    Module mdlThumbs
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

        Public Function thumbnail(nomefile As String, lato As Integer, Optional Newfile As String = "", Optional Watermark As Boolean = False, Optional Quadrata As Boolean = True) As Image

            Dim i As Image
            i = New Bitmap(nomefile)

            Dim wm As Image
            wm = My.Resources.waterM

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
            If Watermark Then
                Dim NewDim As Integer = CInt(nuovalarghezza / 8)
                If NewDim < 80 Then NewDim = 80
                g.DrawImage(wm, 10, 10, NewDim, NewDim)
            End If

            g.Dispose()
            i.Dispose()
            wm.Dispose()
            'piuma.Dispose()

            'nuovaimmagine.Save(NewFile, Imaging.ImageFormat.Jpeg)
            'SaveJpeg(NewFile, nuovaimmagine, 90)
            'nuovaimmagine.Dispose()
            Return nuovaimmagine
        End Function

        ' Return the image's orientation.
        Public Function ImageOrientation(ByVal img As Image) As ExifOrientations
            ' Get the index of the orientation property.
            Dim orientation_index As Integer = Array.IndexOf(img.PropertyIdList, OrientationId)

            ' If there is no such property, return Unknown.
            If (orientation_index < 0) Then Return ExifOrientations.Unknown

            ' Return the orientation value.
            Return DirectCast(img.GetPropertyItem(OrientationId).Value(0), ExifOrientations)
        End Function

    End Module
    'Module OttimizzaJPG
    '    ' Saves an image as a jpeg image, with the given quality 
    '    ' Gets:
    '    '   path   - Path to which the image would be saved.
    '    '   quality - An integer from 0 to 100, with 100 being the 
    '    '           highest quality
    '    ' Written by Kourosh Derakshan 
    '    ' 
    '    'Public Sub SaveJpeg(ByVal path As String, ByVal img As Image, ByVal quality As Long)
    '    '    If ((quality < 0) OrElse (quality > 100)) Then
    '    '        Throw New ArgumentOutOfRangeException("quality must be between 0 and 100.")
    '    '    End If

    '    '    ' Encoder parameter for image quality
    '    '    Dim qualityParam As New EncoderParameter(Encoder.Quality, quality)
    '    '    ' Jpeg image codec 
    '    '    Dim jpegCodec As ImageCodecInfo = GetEncoderInfo("image/jpeg")

    '    '    Dim encoderParams As New EncoderParameters(1)
    '    '    encoderParams.Param(0) = qualityParam
    '    '    img.Save(path, jpegCodec, encoderParams)
    '    'End Sub

    '    ' Returns the image codec with the given mime type 
    '    Private Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
    '        ' Get image codecs for all image formats 
    '        ' Written by Kourosh Derakshan 
    '        ' 
    '        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()

    '        ' Find the correct image codec 
    '        For i As Integer = 0 To codecs.Length - 1
    '            If (codecs(i).MimeType = mimeType) Then
    '                Return codecs(i)
    '            End If
    '        Next i

    '        Return Nothing
    '    End Function

    'End Module

End Namespace



