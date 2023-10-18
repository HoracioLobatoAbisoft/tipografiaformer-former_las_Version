Imports FormerDALSql
Friend Class frmListinoModelloCubetto
    'Inherits baseFormInternaFixed
    Private _Ris As Integer = 0
    Private _Cubetto As ModelloCubetto = Nothing

    Friend Function Carica(Cubetto As ModelloCubetto) As Integer

        _Cubetto = Cubetto

        txtNome.Text = _Cubetto.Nome
        txtLarghezza.Text = _Cubetto.Larghezza
        txtLunghezza.Text = _Cubetto.Lunghezza
        txtProfondita.Text = _Cubetto.Profondita

        UcListinoImpatto.CalcolaSuModelloCubetto(_Cubetto.IDModelloCubetto)

        CreaAnteprima()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CreaAnteprima()

        If Not _Cubetto Is Nothing Then
            If _Cubetto.IsValid Then
                Try
                    Dim bitmap As New Bitmap(600, 400)
                    Dim formGraphics As Graphics = Graphics.FromImage(bitmap)

                    Dim MargineX As Single = 3
                    Dim MargineY As Single = 3

                    Dim PartenzaX As Single = bitmap.Width / 3
                    Dim PartenzaY As Single = bitmap.Height / 3

                    Dim c As New CubettoDisegnato(_Cubetto.Lunghezza, _Cubetto.Larghezza, _Cubetto.Profondita)
                    c.DrawMe(formGraphics, PartenzaX, PartenzaY)

                    'Dim PathImg As String = FormerPath.PathTempLocale() & GetNomeFileTemp(".png")
                    'bitmap.Save(PathImg, Imaging.ImageFormat.Png)

                    formGraphics.Dispose()

                    pctPreview.Image = bitmap
                Catch ex As Exception
                    MessageBox.Show("Si è verificato un errore nella creazione dell'anteprima del cubetto")
                End Try

            End If

        End If

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
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

    Private Sub tbProd_Click(sender As Object, e As EventArgs) Handles tbProd.Click

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio del Modello di Cubetto?", "Salvataggio Modello Cubetto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'qui controllo prima che non ci sia gia un cubetto con queste misure
            _Cubetto.Larghezza = txtLarghezza.Text
            _Cubetto.Lunghezza = txtLunghezza.Text
            _Cubetto.Profondita = txtProfondita.Text
            _Cubetto.Nome = txtNome.Text

            Dim l As List(Of ModelloCubetto) = Nothing
            Using mgr As New ModelliCubettiDAO
                l = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ModelloCubetto.Larghezza, _Cubetto.Larghezza),
                                New LUNA.LunaSearchParameter(LFM.ModelloCubetto.Lunghezza, _Cubetto.Lunghezza),
                                New LUNA.LunaSearchParameter(LFM.ModelloCubetto.Profondita, _Cubetto.Profondita))
            End Using

            If l.Count Then
                MessageBox.Show("Esiste gia un modello di cubetto con queste dimensioni")
            Else
                If _Cubetto.IsValid Then

                    _Cubetto.Save()
                    _Ris = 1
                    Close()

                Else
                    MessageBox.Show("Dimensioni del modello di cubetto non valide")
                End If
            End If
            
        End If

    End Sub

    Private Sub txtLunghezza_TextChanged(sender As Object, e As EventArgs) Handles txtLunghezza.TextChanged
        Try
            _Cubetto.Lunghezza = txtLunghezza.Text
            CreaAnteprima()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtLarghezza_TextChanged(sender As Object, e As EventArgs) Handles txtLarghezza.TextChanged
        Try
            _Cubetto.Larghezza = txtLarghezza.Text
            CreaAnteprima()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtProfondita_TextChanged(sender As Object, e As EventArgs) Handles txtProfondita.TextChanged
        Try
            _Cubetto.Profondita = txtProfondita.Text
            CreaAnteprima()
        Catch ex As Exception

        End Try
    End Sub
End Class