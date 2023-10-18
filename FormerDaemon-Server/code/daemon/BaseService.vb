Imports System.Configuration
Imports FormerConfig

Friend MustInherit Class BaseService

    Public Enum enStatoServizio As Integer
        NonAttivo = 0
        Attivo = 1
    End Enum

    Public Shared Property Stato As enStatoServizio

    Private Shared PathLocale As String = AppDomain.CurrentDomain.BaseDirectory

    'PATH PARAMETER
    Public Shared ReadOnly Property PathSorgentiHCC As String
        Get
            Return FormerPath.PathSorgentiHCC
        End Get
    End Property

    Public Shared ReadOnly Property PathSorgentiHCC35x50 As String
        Get
            Return FormerPath.PathSorgentiHCC35x50
        End Get
    End Property

    Public Shared ReadOnly Property PathCommesse As String
        Get
            Return FormerPath.PathCommesse ' ConfigurationManager.AppSettings("PathFile")
        End Get
    End Property

    Public Shared ReadOnly Property PathBkpFile As String
        Get
            Return FormerPath.PathBkpFile
        End Get
    End Property

    Public Shared ReadOnly Property PathTemplate As String
        Get
            Return FormerPath.PathTemplate ' ConfigurationManager.AppSettings("PathTemplate")
        End Get
    End Property

    Public Shared ReadOnly Property PathNewVer As String
        Get
            Return FormerPath.PathNewVer ' ConfigurationManager.AppSettings("PathNewVer")
        End Get
    End Property

    Public Shared ReadOnly Property PathHCC As String
        Get
            Return FormerPath.PathHCC ' ConfigurationManager.AppSettings("PathHCC")
        End Get
    End Property

    Public Shared ReadOnly Property PathLogWeb As String
        Get
            Return FormerPath.PathLogWeb 'ConfigurationManager.AppSettings("Path-LogWeb")
        End Get
    End Property

    Public Shared ReadOnly Property PathFattureFE As String
        Get
            Return FormerPath.PathFattureFE 'ConfigurationManager.AppSettings("Path-LogWeb")
        End Get
    End Property

    Public Shared ReadOnly Property PathLog As String
        Get
            Return FormerPath.PathLog
        End Get
    End Property

    Public Shared ReadOnly Property PathLogCoupon As String
        Get
            Return FormerPath.PathLogCoupon
        End Get
    End Property

    Public Shared ReadOnly Property PathFileDigitale As String
        Get
            Return FormerPath.PathFileDigitale 'ConfigurationManager.AppSettings("PathFileDigitale")
        End Get
    End Property

    Public Shared ReadOnly Property PathFileRifiutati As String
        Get
            Return FormerPath.PathFileRifiutati 'ConfigurationManager.AppSettings("PathFileRifiutati")
        End Get
    End Property

    Public Shared ReadOnly Property PathTemp As String
        Get
            Return FormerPath.PathTemp 'ConfigurationManager.AppSettings("PathTemp")
        End Get
    End Property

    Public Shared ReadOnly Property PathFileBianco As String
        Get
            Return FormerPath.PathFileBianco 'ConfigurationManager.AppSettings("PathFileBianco")
        End Get
    End Property

    Public Shared ReadOnly Property PathTST10 As String
        Get
            Return PathLocale & "tst10\reboot.bat"
        End Get
    End Property

    Public Shared ReadOnly Property PathReport As String
        Get
            Return PathLocale & "report\"
        End Get
    End Property

    Public Shared ReadOnly Property PathFatture(IdAzienda As Integer) As String
        Get
            Return FormerPath.PathFatture(IdAzienda) 'ConfigurationManager.AppSettings("PathFatture")
        End Get
    End Property

    'FTP PARAMETER
    Public Shared ReadOnly Property FtpServer As String
        Get
            Return FConfiguration.Ftp.ServerNameProduzione ' ConfigurationManager.AppSettings("Ftp-Server")
        End Get
    End Property

    Public Shared ReadOnly Property FtpLogin As String
        Get
            Return FConfiguration.Ftp.ServerLoginProduzione ' ConfigurationManager.AppSettings("Ftp-Login")
        End Get
    End Property

    Public Shared ReadOnly Property FtpPwd As String
        Get
            Return FConfiguration.Ftp.ServerPwdProduzione
        End Get
    End Property


    Protected Shared Sub _LogMe(ByRef txtLog As TextBox,
                                ByRef lblLastOp As Label,
                                Testo As String,
                                ModuleName As String,
                                ModuleSigla As String,
                                Optional DontStore As Boolean = False,
                                Optional Errore As Exception = Nothing,
                                Optional TagLabel As String = "")

        FormerLog.LogMe(txtLog, lblLastOp, ModuleName, ModuleSigla, Testo, DontStore, Errore, TagLabel)

    End Sub

End Class

