Imports FormerBusinessLogic
Imports FormerLib.FormerEnum

Friend Class frmListinoListaImgTemporanee
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        CaricaImmaginiInUso()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaImmaginiInUso()

        Dim l As List(Of FileTemporaneoInUso) = MgrPubblicazioneWeb.ListaImgTemporaneeInUso

        dgErrori.AutoGenerateColumns = False
        dgErrori.DataSource = l

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs)

        If MessageBox.Show("Confermi qualcosa?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub Risolvi()
        If dgErrori.SelectedRows.Count Then

            Dim ImgSel As FileTemporaneoInUso = dgErrori.SelectedRows(0).DataBoundItem
            Dim Ris As Integer = 0

            Sottofondo()

            'Preventivazione 
            'Lavorazione
            'Macchinario
            'CatProd
            'ColoreStampa
            'FormatoProdotto
            'TipoCarta
            'CategoriaFustella
            'TipoFustella
            'CatLav
            'CatFormatoProdotto

            Select Case ImgSel.TipoOggettoListino
                Case enTipoOggettoListino.Preventivazione
                    Using f As New frmListinoPreventivazione
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
                Case enTipoOggettoListino.Lavorazione
                    Using f As New frmListinoLavorazione
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
                Case enTipoOggettoListino.Macchinario
                    Using f As New frmListinoMacchinario
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
                Case enTipoOggettoListino.CatProd
                    Using f As New frmCatProd
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
                Case enTipoOggettoListino.ColoreStampa
                    Using f As New frmListinoColoreStampa
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
                Case enTipoOggettoListino.FormatoProdotto
                    Using f As New frmListinoFormatoProdotto
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
                Case enTipoOggettoListino.TipoCarta
                    Using f As New frmListinoTipoCarta
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
                Case enTipoOggettoListino.CategoriaFustella
                    Using f As New frmListinoCategoriaFustella
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
                Case enTipoOggettoListino.TipoFustella
                    Using f As New frmListinoTipoFustella
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
                Case enTipoOggettoListino.CatLav
                    Using f As New frmListinoCatLav
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
                Case enTipoOggettoListino.CatFormatoProdotto
                    Using f As New frmListinoCatFormato
                        Ris = f.Carica(ImgSel.IdRif)
                    End Using
            End Select

            Sottofondo()

            If Ris Then CaricaImmaginiInUso()

        Else
            MessageBox.Show("Seleziona un immagine temporanea")
        End If
    End Sub

    Private Sub lnkRisolvi_Click(sender As Object, e As EventArgs) Handles lnkRisolvi.Click

        Risolvi()

    End Sub

    Private Sub dgErrori_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgErrori.CellContentDoubleClick
        Risolvi()
    End Sub
End Class