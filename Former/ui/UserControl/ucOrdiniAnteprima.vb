Imports FormerDALSql
Imports FormerLib.FormerEnum
Public Class ucOrdiniAnteprima
    Inherits ucFormerUserControl
    Private _Ord As Ordine

    Friend Property Ord() As Ordine
        Get
            Return _Ord
        End Get
        Set(ByVal value As Ordine)
            _Ord = value
        End Set
    End Property

    Private _NoLavori As Boolean = False

    Private _RiepilogoImballo As Boolean = False

    Public Property NoLavori() As Boolean
        Get
            Return _NoLavori
        End Get
        Set(ByVal value As Boolean)
            _NoLavori = value
            'If _NoLavori = True Then tbMain.TabPages.Remove(tbLavorazioni)
        End Set
    End Property

    Friend Sub Carica(ByVal IdOrd As Integer,
                      Optional ByVal RimuoviResto As Boolean = True,
                      Optional ByVal RiepilogoImballo As Boolean = False)
        Try
            If NascondiResto Then
                tbMain.TabPages.Remove(tpCliente)
                tbMain.TabPages.Remove(tpDocumenti)
                tbMain.TabPages.Remove(tpPagamenti)
                tbMain.TabPages.Remove(tpMailRiferimento)
            End If

            Dim x As New Ordine
            x.Read(IdOrd)
            _Ord = x
            _RiepilogoImballo = RiepilogoImballo
            CaricaDati(RimuoviResto)

        Catch ex As Exception

        End Try


    End Sub

    Friend Sub Carica(ByVal Com As Commessa)
        Try
            'CreaRiepilogoCom(Com, UcCommesseAnteprimaOp.WebPrew, enTipoAnteprima.Breve)
            MgrAnteprime.CreaRiepilogoCom(Com, WebPreview, enTipoAnteprima.Breve)
            'WebPreview.Navigate(Com.Riepilogo)

            UcCaratProdotto.Carica(Com)

            'carico i sorgenti
            lvwAllegati.Items.Clear()
            For Each O As Ordine In Com.ListaOrdini
                For Each S As FileSorgente In O.ListaSorgenti
                    Dim lv As New ListViewItem

                    lv.ImageIndex = 1
                    lv.Text = FormerLib.FormerHelper.File.EstraiNomeFile(S.FilePath)
                    lv.Tag = S.FilePath

                    lvwAllegati.Items.Add(lv)
                Next

                For Each s As FileAllegato In O.ListaFileAllegati
                    Dim lv As New ListViewItem

                    If s.FilePath.ToLower.EndsWith("pdf") Then
                        lv.ImageIndex = 1
                    Else
                        lv.ImageIndex = 3
                    End If

                    lv.Text = FormerLib.FormerHelper.File.EstraiNomeFile(s.FilePath)
                    lv.Tag = s.FilePath

                    lvwAllegati.Items.Add(lv)
                Next
            Next
            '_Ord = Ord
            'CaricaDati()
        Catch ex As Exception

        End Try


    End Sub

    Friend Sub Carica(ByVal ModCom As ModelloCommessa)
        Try
            'If NascondiResto Then
            '    tbMain.TabPages.Remove(tpCliente)
            '    tbMain.TabPages.Remove(tpDocumenti)
            '    tbMain.TabPages.Remove(tpPagamenti)
            'End If

            tbMain.TabPages.Remove(tpCliente)
            tbMain.TabPages.Remove(tpDocumenti)
            tbMain.TabPages.Remove(tpPagamenti)

            WebPreview.Navigate(ModCom.RiepilogoHTML)
        Catch ex As Exception

        End Try


        '_Ord = Ord
        'CaricaDati()

    End Sub

    Friend Sub Carica(ByVal Ord As Ordine)
        Try
            _Ord = Ord
            CaricaDati()
            If NascondiResto Then
                tbMain.TabPages.Remove(tpCliente)
                tbMain.TabPages.Remove(tpDocumenti)
                tbMain.TabPages.Remove(tpPagamenti)
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CaricaDati(Optional ByVal RimuoviResto As Boolean = False)
        CreaAnteprima()

        'Dim P As New Prodotto
        'P.Read(_Ord.IdProd)

        UcCaratProdotto.Carica(_Ord)

        If RimuoviResto Then
            tbMain.TabPages.Remove(tpCliente)
            tbMain.TabPages.Remove(tpDocumenti)
            tbMain.TabPages.Remove(tpPagamenti)
            tbMain.TabPages.Remove(tpMailRiferimento)
        Else
            If _Ord.IdRub Then
                UcPagamenti.IdRub = _Ord.IdRub
                UcPagamenti.MostraDati(enTipoVoceContab.VoceVendita)

                UcContab.IdRub = _Ord.IdRub
                'UcContab.MostraDatiOld(True)

                UcSituazPagam.IdRub = _Ord.IdRub
                UcSituazPagam.MostraSituaz()

            End If
        End If

        tbMain.TabPages.Remove(tpMailRiferimento)
        If _Ord.IdMailPreventivo Then
            tbMain.TabPages.Add(tpMailRiferimento)
            Using p As New PreventivoMail
                p.Read(Ord.IdMailPreventivo)
                UcMailPreview.Carica(p)
            End Using
        End If

        tbMain.TabPages.Remove(tpAnteprimaCommessa)
        If Not _Ord.Commessa Is Nothing Then
            If _Ord.Commessa.ListaOrdini.Count > 1 Then
                tbMain.TabPages.Add(tpAnteprimaCommessa)
                WebPreviewCommessa.Navigate("blank")
            End If
        End If

        'carico i sorgenti
        lvwAllegati.Items.Clear()
        For Each S As FileSorgente In _Ord.ListaSorgenti
            Dim lv As New ListViewItem

            lv.ImageIndex = 1
            lv.Text = FormerLib.FormerHelper.File.EstraiNomeFile(S.FilePath)
            lv.Tag = S.FilePath

            lvwAllegati.Items.Add(lv)
        Next

    End Sub
    Private Sub lvwAllegati_MouseUp(sender As Object, e As MouseEventArgs) Handles lvwAllegati.MouseUp

        If e.Button = MouseButtons.Right Then

            ' Go to the node that the user clicked
            Dim node As ListViewItem = lvwAllegati.GetItemAt(e.X, e.Y)
            If Not node Is Nothing Then

                lvwAllegati.SelectedItems.Clear()
                node.Selected = True

                mnuAllegato.Show(lvwAllegati, New Point(e.X + 10, e.Y))

            End If

        End If

    End Sub

    Private Sub ApriAllegato()
        If lvwAllegati.SelectedItems.Count Then
            Dim path As String = lvwAllegati.SelectedItems(0).Tag

            FormerLib.FormerHelper.File.ShellExtended(path)

        End If
    End Sub

    Private Sub ApriCon()
        If lvwAllegati.SelectedItems.Count Then
            Dim path As String = lvwAllegati.SelectedItems(0).Tag

            FormerLib.FormerHelper.File.OpenWithDialog(path)

        End If
    End Sub



    Private Sub lvwAllegati_DoubleClick(sender As Object, e As EventArgs) Handles lvwAllegati.DoubleClick

        ApriAllegato()

    End Sub

    Private Sub ApriToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriToolStripMenuItem.Click

        ApriAllegato()

    End Sub

    Private Sub CopiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiaToolStripMenuItem.Click

        If lvwAllegati.SelectedItems.Count Then

            Dim path(0) As String
            path(0) = lvwAllegati.SelectedItems(0).Tag
            Dim d As New DataObject(DataFormats.FileDrop, path)
            Clipboard.Clear()
            Clipboard.SetDataObject(d, True)

        End If

    End Sub
    Private Sub tlStrApriCon_Click(sender As Object, e As EventArgs) Handles tlStrApriCon.Click
        ApriCon()
    End Sub

    Private Sub CopiaPercorsoFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiaPercorsoFileToolStripMenuItem.Click
        If lvwAllegati.SelectedItems.Count Then

            Dim path As String
            path = lvwAllegati.SelectedItems(0).Tag
            Clipboard.Clear()
            Clipboard.SetText(path)

        End If
    End Sub

    Private Sub CreaAnteprima()

        Try

            If Not _Ord Is Nothing Then

                'UcSituazPagam.MostraSituaz()
                If _RiepilogoImballo Then
                    MgrAnteprime.CreaRiepilogoOrd(_Ord, WebPreview, enTipoAnteprima.Imballo)
                Else
                    MgrAnteprime.CreaRiepilogoOrd(_Ord, WebPreview, enTipoAnteprima.Breve)
                End If
                System.Threading.Thread.Sleep(100)
                Application.DoEvents()
                'If _NoLavori = False Then CreaRiepilogoOrd(_Ord, webStatoLav, enTipoAnteprima.Lavorazioni)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If NascondiResto Then
            tbMain.TabPages.Remove(tpCliente)
            tbMain.TabPages.Remove(tpDocumenti)
            tbMain.TabPages.Remove(tpPagamenti)
        End If

    End Sub

    Private _NascondiResto As Boolean = False
    Public Property NascondiResto As Boolean
        Get
            Return _NascondiResto
        End Get
        Set(value As Boolean)
            _NascondiResto = value

        End Set
    End Property

    Public Sub Inizializza()
        If NascondiResto Then
            tbMain.TabPages.Remove(tpCliente)
            tbMain.TabPages.Remove(tpDocumenti)
            tbMain.TabPages.Remove(tpPagamenti)
        End If
    End Sub

    Public Sub New(ByVal RimuoviResto As Boolean)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'If LUNA.LunaContext.TotConnAttive Then
        If RimuoviResto Then
            tbMain.TabPages.Remove(tpCliente)
            tbMain.TabPages.Remove(tpDocumenti)
            tbMain.TabPages.Remove(tpPagamenti)
        End If
        'End If

    End Sub

    Private Sub CreaAnteprimaCommessa()
        If Not _Ord Is Nothing Then
            If Not _Ord.Commessa Is Nothing Then
                MgrAnteprime.CreaRiepilogoCom(_Ord.Commessa, WebPreviewCommessa, enTipoAnteprima.Generale)
            End If
        End If
    End Sub

    Private Sub tbMain_TabIndexChanged(sender As Object, e As EventArgs) Handles tbMain.TabIndexChanged



    End Sub

    Private Sub tbMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbMain.SelectedIndexChanged
        If tbMain.SelectedTab Is tpAnteprimaCommessa Then

            'If WebPreviewCommessa.Document Is Nothing OrElse WebPreviewCommessa.Url.AbsolutePath = "blank" Then
            CreaAnteprimaCommessa()
                'End If

            End If
    End Sub
End Class
