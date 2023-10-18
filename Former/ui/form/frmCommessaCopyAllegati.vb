Imports System.IO
Imports FormerDALSql

Friend Class frmCommessaCopyAllegati
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _IdCom As Integer = 0

    Friend Function Carica(IdCom As Integer) As Integer
        _IdCom = IdCom
        AggiornaDrive(True)

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

        If MessageBox.Show("Confermi la copia sul drive selezionato?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Using c As New Commessa
                c.Read(_IdCom)

                For Each o As Ordine In c.ListaOrdini

                    For Each f As FileAllegato In o.ListaFileAllegati
                        Dim PathFinale As String = cmbDrive.Text

                        Dim NomeTemp As String = f.FileAllegato
                        Dim Newnome As String = String.Empty

                        Dim trovatoInizio As Boolean = False

                        For Each car As Char In NomeTemp
                            If trovatoInizio Then
                                Newnome &= car
                            Else
                                If Char.IsLetter(car) Then
                                    Newnome = car
                                    trovatoInizio = True
                                End If
                            End If
                        Next

                        PathFinale &= Newnome

                        MgrIO.FileCopia(Me, f.FilePath, PathFinale)

                    Next

                Next

            End Using

            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub btnAggiornaDischi_Click(sender As Object, e As EventArgs) Handles btnAggiornaDischi.Click
        AggiornaDrive(False)
    End Sub

    Private Sub AggiornaDrive(Optional Silent As Boolean = False)
        cmbDrive.Items.Clear()
        For Each D As DriveInfo In DriveInfo.GetDrives()
            If D.DriveType = DriveType.Removable Then
                'qui e' un drive rimovibile
                cmbDrive.Items.Add(D.RootDirectory)

            End If
        Next

        If cmbDrive.Items.Count Then cmbDrive.SelectedIndex = 0
        If Not Silent Then
            MessageBox.Show("Lista Drive Aggiornata")
        End If

    End Sub

End Class