Imports FormerDALWeb
Imports FormerLib
Imports FormerLib.FormerEnum
Imports System.Drawing
Imports FormerGraphics

Public Class pCreaRicamo
    Inherits FormerPluginPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("PageTitle") = "Crea il tuo ricamo"

        If Not IsPostBack Then

        End If

    End Sub

    Private _BufferSVG As String = String.Empty
    Public ReadOnly Property BufferSVG As String
        Get
            Return _BufferSVG
        End Get
    End Property

    Protected Sub btnElabora_Click(sender As Object, e As EventArgs) Handles btnElabora.Click

        Elabora()

    End Sub

    Private Sub Elabora()
        'qui devo prendere l'immagine originale e fare il procedimento per arrivare a un vettoriale su cui lavorare da javascript
        Try

            Dim ColoreSfondo As Color = Color.White
            Dim ColoreTrasparente As Color = Color.FromArgb(255, 211, 211, 211)
            Dim ColoreBianco As Color = Color.White

            Dim Estensione As String = FormerHelper.File.GetEstensione(uplImg.FileName)

            Dim NomeFileTemp As String = FormerHelper.File.GetNomeFileTemp("." & Estensione)
            Dim PathRis As String = Server.MapPath(FormerWebApp.PathImgTemp) & NomeFileTemp

            Dim NomeFileSvg As String = FormerHelper.File.GetNomeFileTemp(".svg")
            Dim PathSvg As String = Server.MapPath(FormerWebApp.PathImgTemp) & NomeFileSvg

            uplImg.SaveAs(PathRis)

            Dim bmpOrig As New Bitmap(PathRis)
          
            Dim bmpRedim As Bitmap = FormerGraphicsEngine.BitmapTools.RedimBitmapProportionally(bmpOrig, 512)

            bmpOrig.Dispose()
            bmpOrig = Nothing

            bmpRedim = FormerGraphicsEngine.BitmapTools.BitmapTo8bpp(bmpRedim)

            Dim I As Integer = 0

            Dim listaColori As New List(Of ColoreImg)

            Dim Miapalette As Imaging.ColorPalette = bmpRedim.Palette

            Dim IdInt As Integer = 0
            For Each c As Color In Miapalette.Entries

                If c <> ColoreTrasparente And c <> ColoreBianco Then
                    Dim NewColore As Color = FormerGraphicsEngine.MiscTools.GetColoreBase(c)

                    Dim ColoreTrovato As ColoreImg = listaColori.Find(Function(xxx) xxx.R = NewColore.R And xxx.B = NewColore.B And xxx.G = NewColore.G)

                    If ColoreTrovato Is Nothing Then
                        ColoreTrovato = New ColoreImg
                        ColoreTrovato.R = NewColore.R
                        ColoreTrovato.B = NewColore.B
                        ColoreTrovato.G = NewColore.G
                        listaColori.Add(ColoreTrovato)

                    End If

                    Miapalette.Entries(IdInt) = NewColore
                Else
                    Miapalette.Entries(IdInt) = ColoreBianco
                End If
                IdInt += 1
            Next

            bmpRedim.Palette = Miapalette

            Dim TotPunti As Integer = 0

            FormerGraphicsEngine.ColorImgTools.GetColorPointFromBitmap(bmpRedim, listaColori)

            Dim bufferRis As String = String.Empty

            For Each c As ColoreImg In listaColori.FindAll(Function(col) col.Punti.Count > 0)

                Dim b As New Bitmap(bmpRedim.Width, bmpRedim.Height)

                Using gra As Graphics = Graphics.FromImage(b)
                    gra.FillRectangle(New SolidBrush(Color.White), 0, 0, bmpRedim.Width, bmpRedim.Height)

                    For Each p As Point In c.Punti
                        gra.FillRectangle(New SolidBrush(Color.Black), p.X, p.Y, 1, 1)
                    Next

                End Using

                Dim buffSingImg As String = FormerGraphicsEngine.SVGTools.EsportaBMPToSVG(b)

                If buffSingImg.Length Then

                    buffSingImg = buffSingImg.Replace(" />".ToCharArray, " style=""fill:" & c.HtmlCode & """ />".ToCharArray)

                    bufferRis &= buffSingImg

                End If

            Next

            bufferRis = FormerGraphicsEngine.SVGTools.GetHTMLFromSVG(bufferRis, bmpRedim.Width, bmpRedim.Height)

            bmpRedim.Dispose()

            Try
                Kill(PathRis)
            Catch ex As Exception

            End Try

            _BufferSVG = bufferRis

        Catch ex As Exception

        End Try
    End Sub


End Class