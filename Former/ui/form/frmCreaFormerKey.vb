Imports System.IO
Imports FormerDALSql
Imports System.Xml.Serialization

Friend Class frmCreaFormerKey
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        CaricaUtenti()
        AggiornaDrive(True)
        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaUtenti()
        Using utList As New UtentiDAO
            cmbUtente.ValueMember = "IdUt"
            cmbUtente.DisplayMember = "Login"
            cmbUtente.DataSource = utList.GetAll(LFM.Utente.Login)
        End Using
    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr
        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        AggiornaDrive()
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

    Private Sub btnChiudi_Click(sender As Object, e As EventArgs) Handles btnChiudi.Click

        Close()

    End Sub

    Private Sub btnCrea_Click(sender As Object, e As EventArgs) Handles btnCrea.Click

        If cmbDrive.Items.Count Then
            If MessageBox.Show("Vuoi associare la ChiaveUsb nel drive scelto all'utente selezionato?", , MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Try

                    Dim U As Utente = cmbUtente.SelectedItem
                    Dim PathXml As String = cmbDrive.Items(cmbDrive.SelectedIndex).ToString() & "user.xml"

                    Using W As New StreamWriter(PathXml)
                        W.Write(U.IdUt)
                    End Using

                    'UM.SaveSerialize(U, PathXml)

                    Dim DriveLetter As String = cmbDrive.Text.Substring(0, 1)
                    Dim D As New DriveInfo(DriveLetter)
                    D.VolumeLabel = "FORMERKEY"
                    MessageBox.Show("La FormerKey è pronta per l'utilizzo!", , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Si è verificato un errore nella creazione della FormerKey", , MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try

            End If
        Else
            MessageBox.Show("E' necessario collegare una Chiave Usb per creare una FormerKey", , MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnAggiornaDischi_Click(sender As Object, e As EventArgs) Handles btnAggiornaDischi.Click
        AggiornaDrive()
    End Sub
End Class