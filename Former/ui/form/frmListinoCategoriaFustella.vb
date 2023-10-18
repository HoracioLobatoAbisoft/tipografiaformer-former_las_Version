Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerLib
Imports FormerConfig

Friend Class frmListinoCategoriaFustella
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Private _Cf As CategoriaFustella = Nothing

    Friend Function Carica(IdCat As Integer) As Integer

        Dim Cm As New CategoriaFustella
        Cm.Read(IdCat)

        Carica(Cm)

        Return _Ris

    End Function

    Friend Function Carica(Optional Cf As CategoriaFustella = Nothing) As Integer

        _Cf = Cf

        If _Cf Is Nothing Then
            _Cf = New CategoriaFustella
        Else
            txtCategoria.Text = _Cf.Categoria
            txtDescr.Text = _Cf.Descrizione
            txtAnima.Text = _Cf.Anima
            txtLargMax.Text = _Cf.LarghezzaMax

            txtImgRif.Text = _Cf.ImgRif

            If txtImgRif.Text.Length Then
                Try
                    pctImgLav.Image = Image.FromFile(txtImgRif.Text)
                Catch ex As Exception

                End Try

            End If
        End If

        ShowDialog()

        Return _Ris

    End Function

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If MessageBox.Show("Confermi il salvataggio dei dati?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Cf.Anima = txtAnima.Text
            _Cf.LarghezzaMax = txtLargMax.Text
            _Cf.Categoria = txtCategoria.Text
            _Cf.Descrizione = txtDescr.Text
            If _Cf.IsValid Then
                If txtImgRif.Text.Length Then
                    If txtImgRif.Text <> _Cf.ImgRif Then
                        Dim nuovoNome As String = String.Empty
                        If txtImgRif.Text.StartsWith(FormerPath.PathListinoImg) Then
                            'non devo copiare
                            nuovoNome = txtImgRif.Text
                        Else
                            'devo copiare 
                            Dim F As New FileInfo(txtImgRif.Text)
                            nuovoNome = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(txtImgRif.Text))
                            MgrIO.FileCopia(Me, txtImgRif.Text, nuovoNome)
                        End If
                        _Cf.ImgRif = nuovoNome
                    End If

                End If
                _Cf.Save()

            End If

            _Ris = 1
            Close()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileImg.ShowDialog()

        If OpenFileImg.FileName.Length Then
            txtImgRif.Text = OpenFileImg.FileName

            Try
                pctImgLav.Image = Image.FromFile(txtImgRif.Text)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub btnWizard_Click(sender As Object, e As EventArgs) 
        Using f As New frmListinoImgTemporanea
            Sottofondo()
            Dim PathTemp As String = f.Carica()
            Sottofondo()
            If PathTemp.Length Then
                txtImgRif.Text = PathTemp
                pctImgLav.Image = Image.FromFile(PathTemp)
            End If

        End Using
    End Sub
End Class