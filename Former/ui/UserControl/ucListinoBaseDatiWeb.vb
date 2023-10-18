Imports System.IO
Imports FormerConfig
Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class ucListinoBaseDatiWeb
    Inherits ucFormerUserControl
    Private Sub ucListinoBaseDatiWeb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

    End Sub

    Private Sub btnSearchSito_Click(sender As Object, e As EventArgs) Handles btnSearchSito.Click

        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgSito.Text = OpenFileImg.FileName
        End If

        CaricaFotoHd()

    End Sub

    Private Sub CaricaAnteprima(Path As String)
        Try
            If Path.Length Then
                Dim i As Image = CloneImage(Path)
                pctAnteprima.Image = i
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CaricaIcone()

        Dim P As New Preventivazione
        P.Read(_L.IdPrev)

        Try
            pctIcoP.Image = Image.FromFile(P.ImgRif)
        Catch ex As Exception

        End Try

        Dim Fp As New FormatoProdotto
        Fp.Read(_L.IdFormProd)

        Try
            pctIcoFp.Image = Image.FromFile(Fp.ImgRif)
        Catch ex As Exception

        End Try

        Dim TC As New TipoCarta
        TC.Read(_L.IdTipoCarta)

        Try
            pctIcoTc.Image = Image.FromFile(TC.ImgRif)
        Catch ex As Exception

        End Try

        Dim CS As New ColoreStampa
        CS.Read(_L.IdColoreStampa)

        Try
            pctIcoCs.Image = Image.FromFile(CS.imgrif)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CaricaImgPrendiIcoDa()

        Select Case _L.PrendiIcoDa
            Case enPrendiIcoDa.TipoCarta
                Try
                    Dim TC As New TipoCarta
                    TC.Read(_L.IdTipoCarta)
                    pctPrendiIco.Image = Image.FromFile(TC.ImgRif)
                Catch ex As Exception

                End Try
            Case enPrendiIcoDa.Preventivazione
                Try
                    Dim P As New Preventivazione
                    P.Read(_L.IdPrev)
                    pctPrendiIco.Image = Image.FromFile(P.ImgRif)
                Catch ex As Exception

                End Try
            Case enPrendiIcoDa.FormatoProdotto
                Try
                    Dim FP As New FormatoProdotto
                    FP.Read(_L.IdFormProd)
                    pctPrendiIco.Image = Image.FromFile(FP.ImgRif)
                Catch ex As Exception

                End Try
            Case enPrendiIcoDa.ColoreDiStampa
                Try
                    Dim CS As New ColoreStampa
                    CS.Read(_L.IdColoreStampa)
                    pctPrendiIco.Image = Image.FromFile(CS.imgrif)
                Catch ex As Exception

                End Try

        End Select

    End Sub

    Private _IdListino As Integer = 0
    Private _L As ListinoBase = Nothing

    Private Function CloneImage(aImagePath As String) As Image
        ' create original image
        Dim originalImage As Image = New Bitmap(aImagePath)

        ' create an empty clone of the same size of original
        Dim clone As Bitmap = New Bitmap(originalImage.Width, originalImage.Height)

        ' get the object representing clone's currently empty drawing surface
        Dim g As Graphics = Graphics.FromImage(clone)

        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed

        ' copy the original image onto this surface
        g.DrawImage(originalImage, 0, 0, originalImage.Width, originalImage.Height)

        ' free graphics and original image
        g.Dispose()
        originalImage.Dispose()

        Return CType(clone, Image)
    End Function

    Friend Function Carica(IdListino As Integer) As Integer

        _IdListino = IdListino
        _L = New ListinoBase
        _L.Read(IdListino)

        lblNomeListinoBase.Text = _L.Nome

        txtDescrSito.Text = _L.DescrSito
        txtImgSito.Text = _L.ImgSito

        txtRicercaGoogle.Text = _L.GoogleDescr
        txtSEO.Text = _L.GoogleSEO

        txtImgAggiuntive.Text = FormerPath.PathListinoFoto & _L.IdListinoBase

        UcPictureWizard.PrefissoDaApplicare = FormerHelper.Web.NormalizzaPrefissoFile(_L.Nome) & "-"

        CaricaFotoHd()
        CaricaImgPrendiIcoDa()
        CaricaIcone()
        'CaricaFotoHd()

    End Function
    Private Sub CaricaFotoHd()
        Try
            'lvwHD.Columns(0).Width = 800
            pctAnteprima.Image = Nothing

            Dim ImgList As New ImageList
            ImgList.ImageSize = New Size(200, 66)

            Dim pathMain As String = txtImgSito.Text

            Dim ListaFile As New List(Of String)
            ListaFile.Add(pathMain)
            If FormerDebug.DebugAttivo Then
                pathMain = pathMain.ToLower.Replace("z:\", "w:\")
            End If
            Dim bmp As Image = Nothing

            Dim i As Image = Drawing.Image.FromFile(pathMain)
            Dim imgThumb As Image = i.GetThumbnailImage(200, 66, Nothing, New IntPtr())

            ImgList.Images.Add(imgThumb, Nothing)
            i.Dispose()

            Dim PathFotoHd As String = FormerPath.PathListinoFoto & _L.IdListinoBase

            If Directory.Exists(PathFotoHd) = False Then
                FormerLib.FormerHelper.File.CreateLongPath(PathFotoHd)
                '            Directory.CreateDirectory(PathFotoHd)
            End If

            If FormerDebug.DebugAttivo Then
                PathFotoHd = PathFotoHd.ToLower.Replace("z:\", "w:\")
            End If
            Try
                Dim dHD As New DirectoryInfo(PathFotoHd)
                For Each fileImg In dHD.GetFiles
                    If fileImg.Extension.ToLower = ".jpg" OrElse
                   fileImg.Extension.ToLower = ".png" Then
                        ListaFile.Add(fileImg.FullName)

                        i = CloneImage(fileImg.FullName)
                        imgThumb = i.GetThumbnailImage(200, 66, Nothing, New IntPtr())

                        ImgList.Images.Add(imgThumb, Nothing)
                        i.Dispose()
                    End If
                Next
            Catch ex As Exception

            End Try




            lvwHD.SmallImageList = ImgList
            lvwHD.LargeImageList = ImgList
            lvwHD.Items.Clear()

            Dim indexImg As Integer = 0
            For Each image In ListaFile

                Dim PathImg As String = image

                If FormerDebug.DebugAttivo Then
                    PathImg = PathImg.ToLower.Replace("z:\", "w:\")
                End If

                Dim lstviewItem As New ListViewItem(PathImg)
                lstviewItem.ImageIndex = indexImg


                lvwHD.Items.Add(lstviewItem)
                indexImg += 1
            Next


        Catch ex As Exception

        End Try

    End Sub
    Private Sub pctShellImg_Click(sender As Object, e As EventArgs) Handles pctShellImg.Click

        Dim PathFotoHd As String = FormerPath.PathListinoFoto & _L.IdListinoBase

        If Directory.Exists(PathFotoHd) = False Then
            Directory.CreateDirectory(PathFotoHd)
        End If

        FormerHelper.File.ShellExtended(PathFotoHd)

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim PathFotoHd As String = FormerPath.PathListinoFoto & _L.IdListinoBase

        If Directory.Exists(PathFotoHd) = False Then
            Directory.CreateDirectory(PathFotoHd)
        End If

        'FormerHelper.File.ShellExtended(PathFotoHd)

        Dim Ris As String = String.Empty

        ParentFormEx.Sottofondo()
        Using f As New frmOpenIMG
            f.PrefissoDaApplicare = FormerHelper.Web.NormalizzaPrefissoFile(_L.Nome) & "-"
            Ris = f.Carica(800, 267)
        End Using
        ParentFormEx.Sottofondo()

        If Ris.Length Then

            MgrIO.FileCopia(Me.ParentFormEx, Ris, PathFotoHd & "\" & FormerLib.FormerHelper.File.EstraiNomeFile(Ris))

        End If

        CaricaFotoHd()
    End Sub

    Private Sub lvwHD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwHD.SelectedIndexChanged
        If lvwHD.SelectedItems.Count Then
            Dim Selezionata As ListViewItem = lvwHD.SelectedItems(0)

            CaricaAnteprima(Selezionata.Text)

        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If lvwHD.SelectedItems.Count Then
            Dim Selezionata As ListViewItem = lvwHD.SelectedItems(0)

            If Selezionata.Text <> txtImgSito.Text AndAlso Selezionata.Text <> _L.ImgSito Then
                'qui la posso cancellare

                If MessageBox.Show("Confermi la cancellazione dell'immagine selezionata? (OPERAZIONE IRREVERSIBILE)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try

                        Dim PathImg As String = Selezionata.Text
                        lvwHD.Items.Remove(Selezionata)
                        lvwHD.Refresh()
                        Selezionata = Nothing

                        File.Delete(PathImg)
                        CaricaFotoHd()
                    Catch ex As Exception
                        MessageBox.Show("ERRORE nella cancellazione dell'immagine: " & ex.Message)
                    End Try
                End If
            Else
                MessageBox.Show("Non si può eliminare l'immagine principale del ListinoBase. Sostituirla dall'apposito controllo")
            End If

        End If
    End Sub

    Private Sub lnkApriCon_Click(sender As Object, e As EventArgs) Handles lnkApriCon.Click
        If lvwHD.SelectedItems.Count Then

            Dim Selezionata As ListViewItem = lvwHD.SelectedItems(0)

            FormerLib.FormerHelper.File.OpenWithDialog(Selezionata.Text)

            'If Selezionata.Text <> txtImgSito.Text AndAlso Selezionata.Text <> _L.ImgSito Then
            '    'qui la posso cancellare

            '    If MessageBox.Show("Confermi la cancellazione dell'immagine selezionata? (OPERAZIONE IRREVERSIBILE)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '        Try
            '            lvwHD.Items.Remove(Selezionata)
            '            File.Delete(Selezionata.Text)
            '            CaricaFotoHd()
            '        Catch ex As Exception
            '            MessageBox.Show("ERRORE nella cancellazione dell'immagine: " & ex.Message)
            '        End Try
            '    End If
            'Else
            '    MessageBox.Show("Non si può eliminare l'immagine principale del ListinoBase. Sostituirla dall'apposito controllo")
            'End If

        End If
    End Sub

    Private Sub lnkOpenFolder_Click(sender As Object, e As EventArgs) Handles lnkOpenFolder.Click
        If lvwHD.SelectedItems.Count Then
            Dim Selezionata As ListViewItem = lvwHD.SelectedItems(0)

            Dim PathToOpen As String = Selezionata.Text

            pctAnteprima.Image = Nothing

            PathToOpen = FormerHelper.File.GetFolder(PathToOpen)

            FormerLib.FormerHelper.File.ShellExtended(PathToOpen)

            'If Selezionata.Text <> txtImgSito.Text AndAlso Selezionata.Text <> _L.ImgSito Then
            '    'qui la posso cancellare

            '    If MessageBox.Show("Confermi la cancellazione dell'immagine selezionata? (OPERAZIONE IRREVERSIBILE)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '        Try
            '            lvwHD.Items.Remove(Selezionata)
            '            File.Delete(Selezionata.Text)
            '            CaricaFotoHd()
            '        Catch ex As Exception
            '            MessageBox.Show("ERRORE nella cancellazione dell'immagine: " & ex.Message)
            '        End Try
            '    End If
            'Else
            '    MessageBox.Show("Non si può eliminare l'immagine principale del ListinoBase. Sostituirla dall'apposito controllo")
            'End If

        End If
    End Sub
End Class
