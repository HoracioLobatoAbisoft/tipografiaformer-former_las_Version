Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports System.IO
Imports FormerLib
Imports FormerConfig

Friend Class frmListinoDatiWebLB
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _IdListino As Integer = 0
    Private _L As ListinoBase = Nothing

    Friend Function Carica(IdListino As Integer) As Integer

        _IdListino = IdListino
 
        UcListinoBaseDatiWeb.Carica(IdListino)

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
        If MessageBox.Show("Confermi i Dati Web inseriti per il listino base?", "Listino Base", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _L = New ListinoBase
            _L.Read(_IdListino)

            Dim nuovoNomeFile As String = String.Empty
            If UcListinoBaseDatiWeb.txtImgSito.Text.Length Then
                If UcListinoBaseDatiWeb.txtImgSito.Text <> _L.ImgSito Then
                    If UcListinoBaseDatiWeb.txtImgSito.Text.StartsWith(FormerPath.PathListinoImg) Then
                        'non devo copiare
                        nuovoNomeFile = UcListinoBaseDatiWeb.txtImgSito.Text
                    Else
                        'devo copiare 
                        Dim F As New FileInfo(UcListinoBaseDatiWeb.txtImgSito.Text)
                        nuovoNomeFile = FormerPath.PathListinoImg & FormerLib.FormerHelper.File.GetNomeFileTemp("." & FormerLib.FormerHelper.File.GetEstensione(UcListinoBaseDatiWeb.txtImgSito.Text))
                        MgrIO.FileCopia(Me, UcListinoBaseDatiWeb.txtImgSito.Text, nuovoNomeFile)
                    End If
                Else
                    nuovoNomeFile = UcListinoBaseDatiWeb.txtImgSito.Text
                End If
            End If

            'aggiorno solo descrizione e imgsito
            Using Mgr As New ListinoBaseDAO
                Mgr.UpdateDatiWeb(_IdListino, nuovoNomeFile, UcListinoBaseDatiWeb.txtDescrSito.Text, UcListinoBaseDatiWeb.txtRicercaGoogle.Text, UcListinoBaseDatiWeb.txtSEO.Text)
            End Using
            Close()

        End If

    End Sub
End Class