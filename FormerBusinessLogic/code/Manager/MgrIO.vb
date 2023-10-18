Imports FormerIO
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class MgrIO

    Public Shared Function FileCopia(ByVal Sender As Object,
                              ByVal Origine As String,
                              ByVal Destinazione As String) As Integer
        Dim ris As Integer = 0

        'If FormerDebug.DebugAttivo = False Then
        '    Sender.Sottofondo()

        '    Using X As New frmFileCopy

        '        ris = X.Copia(Origine, Destinazione)

        '    End Using

        '    Sender.Sottofondo()
        'End If

        ris = MgrFormerIO.FileCopy(Origine, Destinazione, Sender)

        Return ris

        'Return MgrFormerIO.MgrIO.FileCopia(Origine, Destinazione,, ResizeImg)

    End Function

    Public Shared Function FileSposta(ByVal Sender As Object,
                               ByVal Origine As String,
                               ByVal Destinazione As String) As Integer

        Dim ris As Integer = 0

        'Sender.Sottofondo()

        'Using X As New frmFileCopy

        '    ris = X.Sposta(Origine, Destinazione)

        'End Using

        'Sender.Sottofondo()

        ris = MgrFormerIO.FileMove(Origine, Destinazione, Sender)

        Return ris

    End Function

    Public Shared Function FtpTransfer(ByVal Sender As Object,
                                ByVal FtpConn As FTPclient,
                                ByVal Origine As String,
                                ByVal Destinazione As String,
                                ByVal TipoOp As enTipoOpFTP) As Integer

        Dim Ris As Integer = 0
        'Sender.Sottofondo()

        'Using X As New frmFileFTP
        '    X.FTPConnection = FtpConn
        '    Ris = X.Transfer(TipoOp, Origine, Destinazione)
        'End Using

        'Sender.Sottofondo()
        Ris = MgrFormerIO.FtpTransfer(FtpConn, Origine, Destinazione, TipoOp, Sender)
        Return Ris

    End Function

End Class
