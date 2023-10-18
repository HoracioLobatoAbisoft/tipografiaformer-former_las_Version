Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Friend Class frmOrdiniPanoramica
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private Sub CaricaAnteprima(Sender As Object, e As MouseEventArgs)

        Try
            UcOrdiniAnteprima.Carica(DirectCast(Sender.tag, Ordine))
        Catch ex As Exception

        End Try

    End Sub

    Private _IdRub As Integer = 0

    Friend Function Carica(IdRub As Integer) As Integer

        _IdRub = IdRub
        'mostro tutti gli ordini di un cliente in un carosello di ricerca

        'RadCarousel.VisibleItemCount = 20

        Using R As New VoceRubrica

            R.Read(IdRub)

            Text &= " - " & R.RagSocNome
            lblRub.Text = R.RagSocNome

        End Using

        CaricaCombo()

        CaricaOrdini()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        Using mgr As New PreventivazioniDAO

            cmbCatProd.ValueMember = "IdPrev"
            cmbCatProd.DisplayMember = "Descrizione"

            Dim AddEmpty As Boolean = True
            Using mgrO As New OrdiniDAO
                Dim l As List(Of Ordine) = mgrO.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = LFM.Ordine.IdOrd.Name & " DESC"},
                                                        New LUNA.LunaSearchParameter(LFM.Ordine.IdRub, _IdRub),
                                                        New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.Eliminato, "<>"))
                If l.Count > 100 Then AddEmpty = False
            End Using

            cmbCatProd.DataSource = mgr.GetByIdRub(_IdRub, AddEmpty)
        End Using

    End Sub

    Private Sub CaricaOrdini()

        Cursor.Current = Cursors.WaitCursor

        Using mgr As New OrdiniDAO
            Dim l As List(Of Ordine) = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = LFM.Ordine.IdOrd.Name & " DESC"},
                                                   New LUNA.LunaSearchParameter(LFM.Ordine.IdRub, _IdRub),
                                                   New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.Eliminato, "<>"))

            Dim IdPrev As Integer = cmbCatProd.SelectedValue

            If IdPrev Then
                l = l.FindAll(Function(x) Not x.ListinoBase Is Nothing AndAlso x.ListinoBase.IdPrev = IdPrev)
            End If

            'For Each O As Ordine In l

            '    Application.DoEvents()

            '    Dim button As New RadButtonElement
            '    button.Text = O.IdOrd
            '    button.BackColor = FormerLib.FormerColori.GetColoreStatoOrdine(O.Stato)

            '    'button.MinSize = New Size(100, 100)
            '    'button.AutoSize = false;
            '    button.DisplayStyle = DisplayStyle.ImageAndText
            '    button.ImagePrimitive.ImageLayout = ImageLayout.Zoom
            '    button.Tag = O
            '    button.TextImageRelation = TextImageRelation.ImageAboveText
            '    'button.CustomFontSize = 12
            '    'button.CustomFont = "Segoe UI"
            '    'button.CustomFontStyle = FontStyle.Bold

            '    AddHandler button.MouseDown, AddressOf CaricaAnteprima

            '    RadCarousel.Items.Add(button)

            'Next
            If TabRisultati.SelectedIndex = 1 Then
                'carousel
                RadCarousel.DataSource = l
            Else
                'immagini

                For Each c As Control In flowPanel.Controls
                    RemoveHandler c.MouseDown, AddressOf CaricaAnteprima
                Next

                flowPanel.Controls.Clear()

                For Each o In l

                    Dim pan As New Panel
                    pan.BackColor = o.StatoColore
                    'pan.AutoSizeMode = AutoSizeMode.GrowAndShrink
                    pan.AutoSize = False
                    pan.Visible = True
                    pan.Size = New Size(86, 96)
                    pan.BorderStyle = BorderStyle.FixedSingle
                    pan.ForeColor = Color.FromArgb(64, 64, 64)
                    pan.Tag = o
                    pan.Cursor = Cursors.Hand

                    AddHandler pan.MouseDown, AddressOf CaricaAnteprima

                    Dim p As New PictureBox
                    p.Margin = New Padding(5)
                    p.Location = New Point(5, 15)
                    p.Image = o.ImgAnteprima
                    p.SizeMode = PictureBoxSizeMode.AutoSize
                    p.Tag = o
                    p.Cursor = Cursors.Hand

                    p.Visible = True

                    AddHandler p.MouseDown, AddressOf CaricaAnteprima

                    pan.Controls.Add(p)

                    Dim lb As New Label
                    lb.Font = New Font(FontFamily.GenericSansSerif, 8)
                    lb.Text = o.IdOrd
                    lb.Location = New Point(0, 0)
                    lb.ForeColor = FormerLib.FormerColori.GetForeColor(o.StatoColore)
                    lb.AutoSize = True
                    lb.Tag = o

                    AddHandler lb.MouseDown, AddressOf CaricaAnteprima

                    pan.Controls.Add(lb)
                    lb.BringToFront()

                    flowPanel.Controls.Add(pan)
                Next

            End If

            lblTotOrd.Text = l.Count & " lavori disponibili"

        End Using

        Cursor.Current = Cursors.Default

    End Sub

    'Private Sub radCarousel1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.ItemDataBoundEventArgs) Handles RadCarousel.ItemDataBound
    '    Dim button As RadButtonElement = CType(e.DataBoundItem, RadButtonElement)
    '    button.Text = CStr(e.DataItem)
    '    button.MinSize = New Size(20, 20)
    '    'button.AutoSize = false;
    '    button.DisplayStyle = DisplayStyle.Image
    '    button.ImagePrimitive.ImageLayout = ImageLayout.Zoom

    '    'AddHandler button.MouseDown, AddressOf button_MouseDown

    '    If RadCarousel.Items.Count < RadCarousel.VisibleItemCount Then
    '        LoadItemImage(button, True)
    '    End If
    'End Sub

    'Private Function GetThumbnailImageAbort() As Boolean
    '    Return False
    'End Function

    'Private Sub LoadItemImage(ByVal button As RadButtonElement, ByVal thumbnail As Boolean)
    '    If Not button Is Nothing AndAlso (Not String.IsNullOrEmpty(button.Text)) AndAlso (button.Image Is Nothing OrElse (Not thumbnail)) Then
    '        Dim res As Image = Image.FromFile(button.Text)

    '        If thumbnail Then
    '            button.Image = res.GetThumbnailImage(CInt(Fix(70.0R * (CDbl(res.Width) / res.Height))), 70, AddressOf GetThumbnailImageAbort, IntPtr.Zero)
    '        Else
    '            button.Image = res
    '        End If
    '    End If
    'End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object,
                                 ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub RadCarousel_ItemDataBound(sender As Object,
                                          e As ItemDataBoundEventArgs) Handles RadCarousel.ItemDataBound
        Dim button As RadButtonElement = CType(e.DataBoundItem, RadButtonElement)
        Dim O As Ordine = e.DataItem
        button.Text = O.IdOrd
        button.BackColor = FormerLib.FormerColori.GetColoreStatoOrdine(O.Stato)

        '    'button.MinSize = New Size(100, 100)
        '    'button.AutoSize = false;
        button.DisplayStyle = DisplayStyle.ImageAndText
        button.ImagePrimitive.ImageLayout = ImageLayout.Zoom
        button.Tag = O
        button.TextImageRelation = TextImageRelation.ImageAboveText
        AddHandler button.MouseDown, AddressOf CaricaAnteprima

        'If RadCarousel.Items.Count < RadCarousel.VisibleItemCount Then
        Try
            Dim res As Image = Image.FromFile(O.FilePath)

            Dim Altezza As Integer = 0
            Dim Larghezza As Integer = 0

            If res.Height > res.Width Then
                Altezza = 150
                Larghezza = (res.Width * 150) / res.Height
            Else
                Larghezza = 150
                Altezza = (res.Width * 150) / res.Height
            End If

            Dim ResNew As Image = New Bitmap(res, Altezza, Larghezza)

            button.Image = ResNew

        Catch ex As Exception

        End Try
        'End If

    End Sub

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked

        CaricaOrdini()

    End Sub

End Class