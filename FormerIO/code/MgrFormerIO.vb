Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrFormerIO

    Private Shared ReadOnly Property WithUinterface As Boolean
        Get
            Dim ris As Boolean = False

            ris = FormerConfig.FConfiguration.Altro.WithUIFileOperation

            Return ris
        End Get
    End Property

    Public Shared Function FileCopy(ByVal Origine As String,
                                    ByVal Destinazione As String,
                                    Optional SenderForm As Object = Nothing) As Integer

        Dim ris As Integer = 0

        If WithUinterface Then

            If Not SenderForm Is Nothing AndAlso TypeOf SenderForm Is FormerLib.IFormWithSottofondo Then
                SenderForm.SottoFondo()
            End If
            'My.Computer.FileSystem.CopyFile(Origine, Destinazione, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

            Using X As New frmFileCopy

                ris = X.Copia(Origine, Destinazione) ', ResizeImg)

            End Using

            If Not SenderForm Is Nothing AndAlso TypeOf SenderForm Is FormerLib.IFormWithSottofondo Then
                SenderForm.SottoFondo()
            End If

        Else
            System.IO.File.Copy(Origine, Destinazione, True)
        End If

        Return ris

    End Function

    Public Shared Function FileMove(ByVal Origine As String,
                                    ByVal Destinazione As String,
                                    Optional SenderForm As Object = Nothing) As Integer

        Dim ris As Integer = 0

        'Sender.Sottofondo()
        If WithUinterface Then
            If Not SenderForm Is Nothing AndAlso TypeOf SenderForm Is FormerLib.IFormWithSottofondo Then
                SenderForm.SottoFondo()
            End If

            'My.Computer.FileSystem.MoveFile(Origine, Destinazione, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
            Using X As New frmFileCopy

                ris = X.Sposta(Origine, Destinazione) ', ResizeImg)

            End Using

            If Not SenderForm Is Nothing AndAlso TypeOf SenderForm Is FormerLib.IFormWithSottofondo Then
                SenderForm.SottoFondo()
            End If

        Else
            System.IO.File.Move(Origine, Destinazione)
        End If
        'Sender.Sottofondo()

        Return ris

    End Function

    Public Shared Function FtpTransfer(ByVal FtpConn As FTPclient,
                                       ByVal Origine As String,
                                       ByVal Destinazione As String,
                                       ByVal TipoOp As enTipoOpFTP,
                                       Optional SenderForm As Object = Nothing) As Integer

        Dim Ris As Integer = 0
        If WithUinterface Then
            'Sender.Sottofondo()
            If Not SenderForm Is Nothing AndAlso TypeOf SenderForm Is FormerLib.IFormWithSottofondo Then
                SenderForm.SottoFondo()
            End If

            Using X As New frmFileFTP
                X.FTPConnection = FtpConn
                Ris = X.Transfer(TipoOp, Origine, Destinazione)
            End Using

            If Not SenderForm Is Nothing AndAlso TypeOf SenderForm Is FormerLib.IFormWithSottofondo Then
                SenderForm.SottoFondo()
            End If
        Else
            FtpConn.Upload(Origine, Destinazione)
        End If

        'Sender.Sottofondo()

        Return Ris

    End Function

    Public Shared Sub FileDelete(ByVal Path As String)

        'If WithUinterface Then
        '    My.Computer.FileSystem.DeleteFile(Path,
        '                                      FileIO.UIOption.OnlyErrorDialogs,
        '                                      FileIO.RecycleOption.SendToRecycleBin,
        '                                      FileIO.UICancelOption.DoNothing)
        'Else
        '    System.IO.File.Delete(Path)
        'End If
        System.IO.File.Delete(Path)
    End Sub

End Class
