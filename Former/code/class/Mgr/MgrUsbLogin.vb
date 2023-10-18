Imports FormerDALSql
Imports System.IO

Public Class MgrUsbLogin

    Public Shared Function TryLogin(Optional WithMessage As Boolean = False) As Utente

        'cerco tra gli harddrive se ce ne sta uno con la label FORMERKEY
        Dim Ris As Utente = Nothing
        Dim NumDriveFound As Integer = 0
        Dim DriveSuPc As DriveInfo() = Nothing
        Try
            DriveSuPc = DriveInfo.GetDrives()

        Catch ex As Exception

        End Try

        Try
            For Each D As DriveInfo In DriveSuPc
                If D.IsReady Then
                    If D.DriveType = DriveType.Removable Then
                        If WithMessage Then MessageBox.Show("Trovato drive (" & D.RootDirectory.ToString() & ")", , MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If D.VolumeLabel = "FORMERKEY" Then

                            NumDriveFound += 1
                            If WithMessage Then MessageBox.Show("Trovata FormerKey su Drive " & D.RootDirectory.ToString(), , MessageBoxButtons.OK, MessageBoxIcon.Information)
                            If NumDriveFound > 1 Then
                                MessageBox.Show("Attenzione sono collegate più di una FormerKey, il sistema non può individuare l'operatore collegato. Collegare una sola FormerKey!", , MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Ris = Nothing
                                Exit For
                            Else
                                'qui ho trovato la chiave devo fare il login
                                Dim PathLoginFile As String = D.RootDirectory.ToString & "user.xml"

                                Dim IdTrovato As String
                                Using r As New StreamReader(PathLoginFile)
                                    IdTrovato = r.ReadToEnd
                                End Using

                                Dim utSel As Utente = Nothing

                                If IdTrovato.Length AndAlso IsNumeric(IdTrovato) Then
                                    utSel = New Utente
                                    utSel.Read(IdTrovato)
                                End If

                                'Dim utMan As New UtentiDAO

                                'Dim U As Utente = utMan.ReadSerialize(PathLoginFile)

                                'Dim utSel As Utente = utMan.LoginUt(U)

                                Ris = utSel
                            End If

                        End If
                    End If
                End If

            Next
            If WithMessage Then
                If NumDriveFound = 0 Then
                    MessageBox.Show("Non è stata trovata nessuna FormerKey", , MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            If WithMessage Then
                MessageBox.Show("Errore su FormerKey: " & ex.Message, , MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            'ManageError(ex, "UsbLoginManager.TryLogin()")
        End Try
        Return Ris

    End Function

End Class
